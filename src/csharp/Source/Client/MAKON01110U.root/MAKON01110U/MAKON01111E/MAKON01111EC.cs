using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   SalesTemp
	/// <summary>
	///                      売上データ（仕入同時計上）
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上データ（仕入同時計上）ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/03/05  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class SalesTemp
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

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>部門コード</summary>
		private Int32 _subSectionCode;

		/// <summary>課コード</summary>
		private Int32 _minSectionCode;

		/// <summary>赤伝区分</summary>
		/// <remarks>0:黒伝,1:赤伝,2:元黒</remarks>
		private Int32 _debitNoteDiv;

		/// <summary>赤黒連結受注番号</summary>
		/// <remarks>赤黒の相手方受注番号</remarks>
		private Int32 _debitNLnkAcptAnOdr;

		/// <summary>売上伝票区分</summary>
		/// <remarks>0:売上,1:返品</remarks>
		private Int32 _salesSlipCd;

		/// <summary>売掛区分</summary>
		/// <remarks>0:売掛なし,1:売掛</remarks>
		private Int32 _accRecDivCd;

		/// <summary>売上入力拠点コード</summary>
		/// <remarks>文字型 売上を入力した拠点コード</remarks>
		private string _salesInpSecCd = "";

		/// <summary>請求計上拠点コード</summary>
		/// <remarks>文字型</remarks>
		private string _demandAddUpSecCd = "";

		/// <summary>実績計上拠点コード</summary>
		/// <remarks>実績計上を行う企業内の拠点コード</remarks>
		private string _resultsAddUpSecCd = "";

		/// <summary>更新拠点コード</summary>
		/// <remarks>文字型 データの登録更新拠点</remarks>
		private string _updateSecCd = "";

		/// <summary>伝票検索日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _searchSlipDate;

		/// <summary>出荷日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _shipmentDay;

		/// <summary>売上日付</summary>
		/// <remarks>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</remarks>
		private DateTime _salesDate;

		/// <summary>計上日付</summary>
		/// <remarks>請求日　(YYYYMMDD)</remarks>
		private DateTime _addUpADate;

		/// <summary>来勘区分</summary>
		/// <remarks>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</remarks>
		private Int32 _delayPaymentDiv;

		/// <summary>請求先コード</summary>
		private Int32 _claimCode;

		/// <summary>請求先略称</summary>
		private string _claimSnm = "";

		/// <summary>得意先コード</summary>
		private Int32 _customerCode;

		/// <summary>得意先名称</summary>
		private string _customerName = "";

		/// <summary>得意先名称2</summary>
		private string _customerName2 = "";

		/// <summary>得意先略称</summary>
		private string _customerSnm = "";

		/// <summary>敬称</summary>
		private string _honorificTitle = "";

		/// <summary>諸口コード</summary>
		/// <remarks>0:正式得意先,1:諸口得意先</remarks>
		private Int32 _outputNameCode;

		/// <summary>業種コード</summary>
		private Int32 _businessTypeCode;

		/// <summary>業種名称</summary>
		private string _businessTypeName = "";

		/// <summary>販売エリアコード</summary>
		/// <remarks>地区コード</remarks>
		private Int32 _salesAreaCode;

		/// <summary>販売エリア名称</summary>
		private string _salesAreaName = "";

		/// <summary>売上入力者コード</summary>
		/// <remarks>入力担当者</remarks>
		private string _salesInputCode = "";

		/// <summary>売上入力者名称</summary>
		private string _salesInputName = "";

		/// <summary>受付従業員コード</summary>
		/// <remarks>受付担当者</remarks>
		private string _frontEmployeeCd = "";

		/// <summary>受付従業員名称</summary>
		private string _frontEmployeeNm = "";

		/// <summary>販売従業員コード</summary>
		/// <remarks>計上担当者</remarks>
		private string _salesEmployeeCd = "";

		/// <summary>販売従業員名称</summary>
		private string _salesEmployeeNm = "";

		/// <summary>消費税転嫁方式</summary>
		/// <remarks>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</remarks>
		private Int32 _consTaxLayMethod;

		/// <summary>消費税税率</summary>
		/// <remarks>変更2007/8/22(型,桁) 塩原</remarks>
		private Double _consTaxRate;

		/// <summary>端数処理区分</summary>
		/// <remarks>1:切捨て,2:四捨五入,3:切上げ　（消費税）</remarks>
		private Int32 _fractionProcCd;

		/// <summary>自動入金区分</summary>
		/// <remarks>0:通常入金,1:自動入金</remarks>
		private Int32 _autoDepositCd;

		/// <summary>自動入金伝票番号</summary>
		/// <remarks>自動入金時の入金伝票番号</remarks>
		private Int32 _autoDepoSlipNum;

		/// <summary>伝票住所区分</summary>
		/// <remarks>1:得意先,2:納入先</remarks>
		private Int32 _slipAddressDiv;

		/// <summary>納品先コード</summary>
		private Int32 _addresseeCode;

		/// <summary>納品先名称</summary>
		private string _addresseeName = "";

		/// <summary>納品先名称2</summary>
		/// <remarks>追加(登録漏れ) 塩原</remarks>
		private string _addresseeName2 = "";

		/// <summary>納品先郵便番号</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseePostNo = "";

		/// <summary>納品先住所1(都道府県市区郡・町村・字)</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseeAddr1 = "";

		/// <summary>納品先住所2(丁目)</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private Int32 _addresseeAddr2;

		/// <summary>納品先住所3(番地)</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseeAddr3 = "";

		/// <summary>納品先住所4(アパート名称)</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseeAddr4 = "";

		/// <summary>納品先電話番号</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseeTelNo = "";

		/// <summary>納品先FAX番号</summary>
		/// <remarks>伝票住所区分に従う内容</remarks>
		private string _addresseeFaxNo = "";

		/// <summary>相手先伝票番号</summary>
		/// <remarks>得意先注文番号</remarks>
		private string _partySaleSlipNum = "";

		/// <summary>伝票備考</summary>
		private string _slipNote = "";

		/// <summary>伝票備考２</summary>
		private string _slipNote2 = "";

		/// <summary>返品理由コード</summary>
		private Int32 _retGoodsReasonDiv;

		/// <summary>返品理由</summary>
		private string _retGoodsReason = "";

		/// <summary>明細行数</summary>
		/// <remarks>伝票内の明細の行数（諸費用明細は除く）</remarks>
		private Int32 _detailRowCount;

		/// <summary>納品区分</summary>
		/// <remarks>例) 1:配達,2:店頭渡し,3:直送,…</remarks>
		private Int32 _deliveredGoodsDiv;

		/// <summary>納品区分名称</summary>
		private string _deliveredGoodsDivNm = "";

		/// <summary>消込フラグ</summary>
		/// <remarks>0:残あり 1:残無し　（受注、出荷にて使用）</remarks>
		private Int32 _reconcileFlag;

		/// <summary>伝票印刷設定用帳票ID</summary>
		/// <remarks>売上形式とセットで伝票タイプ管理マスタを参照</remarks>
		private string _slipPrtSetPaperId = "";

		/// <summary>一式伝票区分</summary>
		/// <remarks>0:通常伝票,1:一式伝票</remarks>
		private Int32 _completeCd;

		/// <summary>請求先区分</summary>
		/// <remarks>官庁請求区分（0:一般　1:官庁標準　2:官庁伝票）</remarks>
		private Int32 _claimType;

		/// <summary>売上金額端数処理区分</summary>
		/// <remarks>1:切捨て,2:四捨五入,3:切上げ　（売上明細データの金額用）</remarks>
		private Int32 _salesPriceFracProcCd;

		/// <summary>定価印刷区分</summary>
		private Int32 _listPricePrintDiv;

		/// <summary>元号表示区分１</summary>
		/// <remarks>通常　　0:西暦　1:和暦</remarks>
		private Int32 _eraNameDispCd1;

		/// <summary>受注番号</summary>
		private Int32 _acceptAnOrderNo;

		/// <summary>共通通番</summary>
		private Int64 _commonSeqNo;

		/// <summary>売上明細通番</summary>
		private Int64 _salesSlipDtlNum;

		/// <summary>受注ステータス（元）</summary>
		/// <remarks>10:見積,20:受注,30:売上,40:出荷</remarks>
		private Int32 _acptAnOdrStatusSrc;

		/// <summary>売上明細通番（元）</summary>
		/// <remarks>計上時の元データ明細通番をセット</remarks>
		private Int64 _salesSlipDtlNumSrc;

		/// <summary>仕入形式（同時）</summary>
		/// <remarks>0:仕入,1:入荷</remarks>
		private Int32 _supplierFormalSync;

		/// <summary>仕入明細通番（同時）</summary>
		/// <remarks>同時計上時の仕入明細通番をセット</remarks>
		private Int64 _stockSlipDtlNumSync;

		/// <summary>売上伝票区分（明細）</summary>
		/// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計</remarks>
		private Int32 _salesSlipCdDtl;

		/// <summary>発注番号</summary>
		/// <remarks>売上形式＝"出荷"の時にセット（発注の計上）</remarks>
		private string _orderNumber = "";

		/// <summary>在庫管理有無区分</summary>
		/// <remarks>0:在庫管理しない,1:在庫管理する</remarks>
		private Int32 _stockMngExistCd;

		/// <summary>納品完了予定日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>商品属性</summary>
		/// <remarks>0:純正 1:その他</remarks>
		private Int32 _goodsKindCode;

		/// <summary>商品メーカーコード</summary>
		/// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>商品名略称</summary>
		private string _goodsShortName = "";

		/// <summary>セット商品区分</summary>
		/// <remarks>0:通常,1:親商品,2:子商品</remarks>
		private Int32 _goodsSetDivCd;

		/// <summary>商品区分グループコード</summary>
		/// <remarks>旧：商品大分類コード</remarks>
		private string _largeGoodsGanreCode = "";

		/// <summary>商品区分グループ名称</summary>
		/// <remarks>旧：商品大分類名称</remarks>
		private string _largeGoodsGanreName = "";

		/// <summary>商品区分コード</summary>
		/// <remarks>旧：商品中分類コード</remarks>
		private string _mediumGoodsGanreCode = "";

		/// <summary>商品区分名称</summary>
		/// <remarks>旧：商品中分類名称</remarks>
		private string _mediumGoodsGanreName = "";

		/// <summary>商品区分詳細コード</summary>
		private string _detailGoodsGanreCode = "";

		/// <summary>商品区分詳細名称</summary>
		private string _detailGoodsGanreName = "";

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>BL商品コード名称（全角）</summary>
		private string _bLGoodsFullName = "";

		/// <summary>自社分類コード</summary>
		private Int32 _enterpriseGanreCode;

		/// <summary>自社分類名称</summary>
		private string _enterpriseGanreName = "";

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

		/// <summary>倉庫棚番</summary>
		private string _warehouseShelfNo = "";

		/// <summary>売上在庫取寄せ区分</summary>
		/// <remarks>0:取寄せ,1:在庫</remarks>
		private Int32 _salesOrderDivCd;

		/// <summary>オープン価格区分</summary>
		/// <remarks>0:通常／1:オープン価格</remarks>
		private Int32 _openPriceDiv;

		/// <summary>単位コード</summary>
		private Int32 _unitCode;

		/// <summary>単位名称</summary>
		private string _unitName = "";

		/// <summary>商品掛率ランク</summary>
		/// <remarks>商品の掛率用ランク</remarks>
		private string _goodsRateRank = "";

		/// <summary>得意先掛率グループコード</summary>
		private Int32 _custRateGrpCode;

		/// <summary>仕入先掛率グループコード</summary>
		private Int32 _suppRateGrpCode;

		/// <summary>定価率</summary>
		private Double _listPriceRate;

		/// <summary>掛率設定拠点（定価）</summary>
		/// <remarks>0:全社設定, その他:拠点コード</remarks>
		private string _rateSectPriceUnPrc = "";

		/// <summary>掛率設定区分（定価）</summary>
		/// <remarks>A1,A2,…</remarks>
		private string _rateDivLPrice = "";

		/// <summary>単価算出区分（定価）</summary>
		/// <remarks>1:掛率,2:原価ＵＰ率,3:粗利率</remarks>
		private Int32 _unPrcCalcCdLPrice;

		/// <summary>価格区分（定価）</summary>
		/// <remarks>0:定価,1:登録販売店価格,… 9:ユーザー定価</remarks>
		private Int32 _priceCdLPrice;

		/// <summary>基準単価（定価）</summary>
		private Double _stdUnPrcLPrice;

		/// <summary>端数処理単位（定価）</summary>
		private Double _fracProcUnitLPrice;

		/// <summary>端数処理（定価）</summary>
		/// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
		private Int32 _fracProcLPrice;

		/// <summary>定価（税込，浮動）</summary>
		/// <remarks>税抜き</remarks>
		private Double _listPriceTaxIncFl;

		/// <summary>定価（税抜，浮動）</summary>
		/// <remarks>税込み</remarks>
		private Double _listPriceTaxExcFl;

		/// <summary>定価変更区分</summary>
		/// <remarks>0:変更なし,1:変更あり　（定価手入力）</remarks>
		private Int32 _listPriceChngCd;

		/// <summary>売価率</summary>
		private Double _salesRate;

		/// <summary>掛率設定拠点（売上単価）</summary>
		/// <remarks>0:全社設定, その他:拠点コード</remarks>
		private string _rateSectSalUnPrc = "";

		/// <summary>掛率設定区分（売上単価）</summary>
		/// <remarks>A1,A2,…</remarks>
		private string _rateDivSalUnPrc = "";

		/// <summary>単価算出区分（売上単価）</summary>
		/// <remarks>1:掛率,2:原価ＵＰ率,3:粗利率</remarks>
		private Int32 _unPrcCalcCdSalUnPrc;

		/// <summary>価格区分（売上単価）</summary>
		/// <remarks>0:定価,1:登録販売店価格,…</remarks>
		private Int32 _priceCdSalUnPrc;

		/// <summary>基準単価（売上単価）</summary>
		private Double _stdUnPrcSalUnPrc;

		/// <summary>端数処理単位（売上単価）</summary>
		private Double _fracProcUnitSalUnPrc;

		/// <summary>端数処理（売上単価）</summary>
		/// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
		private Int32 _fracProcSalUnPrc;

		/// <summary>売上単価（税込，浮動）</summary>
		private Double _salesUnPrcTaxIncFl;

		/// <summary>売上単価（税抜，浮動）</summary>
		private Double _salesUnPrcTaxExcFl;

		/// <summary>売上単価変更区分</summary>
		/// <remarks>0:変更なし,1:変更あり　（売上単価手入力）</remarks>
		private Int32 _salesUnPrcChngCd;

		/// <summary>原価率</summary>
		private Double _costRate;

		/// <summary>掛率設定拠点（原価単価）</summary>
		/// <remarks>0:全社設定, その他:拠点コード</remarks>
		private string _rateSectCstUnPrc = "";

		/// <summary>掛率設定区分（原価単価）</summary>
		/// <remarks>A7,A8,…</remarks>
		private string _rateDivUnCst = "";

		/// <summary>単価算出区分（原価単価）</summary>
		/// <remarks>1:掛率,2:原価ＵＰ率,3:粗利率</remarks>
		private Int32 _unPrcCalcCdUnCst;

		/// <summary>価格区分（原価単価）</summary>
		/// <remarks>0:定価,1:登録販売店価格,…</remarks>
		private Int32 _priceCdUnCst;

		/// <summary>基準単価（原価単価）</summary>
		private Double _stdUnPrcUnCst;

		/// <summary>端数処理単位（原価単価）</summary>
		private Double _fracProcUnitUnCst;

		/// <summary>端数処理（原価単価）</summary>
		/// <remarks>1：切捨て,2：四捨五入,3:切上げ</remarks>
		private Int32 _fracProcUnCst;

		/// <summary>原価単価</summary>
		private Double _salesUnitCost;

		/// <summary>原価単価変更区分</summary>
		/// <remarks>0:変更なし,1:変更あり　（原価単価手入力）</remarks>
		private Int32 _salesUnitCostChngDiv;

		/// <summary>BL商品コード（掛率）</summary>
		/// <remarks>掛率算出時に使用したBLコード（商品検索結果）</remarks>
		private Int32 _rateBLGoodsCode;

		/// <summary>BL商品コード名称（掛率）</summary>
		/// <remarks>掛率算出時に使用したBLコード名称（商品検索結果）</remarks>
		private string _rateBLGoodsName = "";

		/// <summary>特売区分コード</summary>
		private Int32 _bargainCd;

		/// <summary>特売区分名称</summary>
		private string _bargainNm = "";

		/// <summary>出荷数</summary>
		/// <remarks>売上：売上数、受注：受注数、出荷：出荷数、見積：見積数</remarks>
		private Double _shipmentCnt;

		/// <summary>売上金額（税込み）</summary>
		private Int64 _salesMoneyTaxInc;

		/// <summary>売上金額（税抜き）</summary>
		private Int64 _salesMoneyTaxExc;

		/// <summary>原価</summary>
		private Int64 _cost;

		/// <summary>粗利チェック区分</summary>
		/// <remarks>0:正常,1:原価割れ,2:利益の上げ過ぎ</remarks>
		private Int32 _grsProfitChkDiv;

		/// <summary>売上商品区分</summary>
		/// <remarks>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動)</remarks>
		private Int32 _salesGoodsCd;

		/// <summary>売上金額消費税額</summary>
		/// <remarks>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</remarks>
		private Int64 _salsePriceConsTax;

		/// <summary>課税区分</summary>
		/// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
		private Int32 _taxationDivCd;

		/// <summary>相手先伝票番号（明細）</summary>
		/// <remarks>得意先注文番号</remarks>
		private string _partySlipNumDtl = "";

		/// <summary>明細備考</summary>
		private string _dtlNote = "";

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>仕入先略称</summary>
		private string _supplierSnm = "";

		/// <summary>伝票メモ１</summary>
		private string _slipMemo1 = "";

		/// <summary>伝票メモ２</summary>
		private string _slipMemo2 = "";

		/// <summary>伝票メモ３</summary>
		private string _slipMemo3 = "";

		/// <summary>伝票メモ４</summary>
		private string _slipMemo4 = "";

		/// <summary>伝票メモ５</summary>
		private string _slipMemo5 = "";

		/// <summary>伝票メモ６</summary>
		private string _slipMemo6 = "";

		/// <summary>社内メモ１</summary>
		private string _insideMemo1 = "";

		/// <summary>社内メモ２</summary>
		private string _insideMemo2 = "";

		/// <summary>社内メモ３</summary>
		private string _insideMemo3 = "";

		/// <summary>社内メモ４</summary>
		private string _insideMemo4 = "";

		/// <summary>社内メモ５</summary>
		private string _insideMemo5 = "";

		/// <summary>社内メモ６</summary>
		private string _insideMemo6 = "";

		/// <summary>変更前定価</summary>
		/// <remarks>税抜き、掛率算出結果</remarks>
		private Double _bfListPrice;

		/// <summary>変更前売価</summary>
		/// <remarks>税抜き、掛率算出結果</remarks>
		private Double _bfSalesUnitPrice;

		/// <summary>変更前原価</summary>
		/// <remarks>税抜き、掛率算出結果</remarks>
		private Double _bfUnitCost;

		/// <summary>印刷用商品番号</summary>
		private string _prtGoodsNo = "";

		/// <summary>印刷用商品名称</summary>
		private string _prtGoodsName = "";

		/// <summary>印刷用商品メーカーコード</summary>
		private Int32 _prtGoodsMakerCd;

		/// <summary>印刷用商品メーカー名称</summary>
		private string _prtGoodsMakerNm = "";

		/// <summary>仕入伝票区分</summary>
		private Int32 _supplierSlipCd;

		/// <summary>総額表示方法区分</summary>
		/// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
		private Int32 _totalAmountDispWayCd;

		/// <summary>総額表示掛率適用区分</summary>
		/// <remarks>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</remarks>
		private Int32 _ttlAmntDispRateApy;

		/// <summary>確認区分</summary>
		private bool _confirmedDiv;

		/// <summary>次回勘定開始日</summary>
		/// <remarks>01～31まで（省略可能）</remarks>
		private Int32 _nTimeCalcStDate;

		/// <summary>締日</summary>
		/// <remarks>DD</remarks>
		private Int32 _totalDay;

		/// <summary>明細関連付けGUID</summary>
		private Guid _dtlRelationGuid;

		/// <summary>受注残数</summary>
		/// <remarks>受注数量＋受注調整数－出荷数</remarks>
		private Double _acptAnOdrRemainCnt;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>実績計上拠点名称</summary>
		private string _resultsAddUpSecNm = "";

		/// <summary>諸口名称</summary>
		private string _outputName = "";

		/// <summary>BL商品コード名称</summary>
		private string _bLGoodsName = "";


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

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// <value>10:見積,20:受注,30:売上,40:出荷</value>
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

		/// public propaty name  :  SubSectionCode
		/// <summary>部門コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部門コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SubSectionCode
		{
			get{return _subSectionCode;}
			set{_subSectionCode = value;}
		}

		/// public propaty name  :  MinSectionCode
		/// <summary>課コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   課コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MinSectionCode
		{
			get{return _minSectionCode;}
			set{_minSectionCode = value;}
		}

		/// public propaty name  :  DebitNoteDiv
		/// <summary>赤伝区分プロパティ</summary>
		/// <value>0:黒伝,1:赤伝,2:元黒</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   赤伝区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DebitNoteDiv
		{
			get{return _debitNoteDiv;}
			set{_debitNoteDiv = value;}
		}

		/// public propaty name  :  DebitNLnkAcptAnOdr
		/// <summary>赤黒連結受注番号プロパティ</summary>
		/// <value>赤黒の相手方受注番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   赤黒連結受注番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DebitNLnkAcptAnOdr
		{
			get{return _debitNLnkAcptAnOdr;}
			set{_debitNLnkAcptAnOdr = value;}
		}

		/// public propaty name  :  SalesSlipCd
		/// <summary>売上伝票区分プロパティ</summary>
		/// <value>0:売上,1:返品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipCd
		{
			get{return _salesSlipCd;}
			set{_salesSlipCd = value;}
		}

		/// public propaty name  :  AccRecDivCd
		/// <summary>売掛区分プロパティ</summary>
		/// <value>0:売掛なし,1:売掛</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売掛区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AccRecDivCd
		{
			get{return _accRecDivCd;}
			set{_accRecDivCd = value;}
		}

		/// public propaty name  :  SalesInpSecCd
		/// <summary>売上入力拠点コードプロパティ</summary>
		/// <value>文字型 売上を入力した拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上入力拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesInpSecCd
		{
			get{return _salesInpSecCd;}
			set{_salesInpSecCd = value;}
		}

		/// public propaty name  :  DemandAddUpSecCd
		/// <summary>請求計上拠点コードプロパティ</summary>
		/// <value>文字型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DemandAddUpSecCd
		{
			get{return _demandAddUpSecCd;}
			set{_demandAddUpSecCd = value;}
		}

		/// public propaty name  :  ResultsAddUpSecCd
		/// <summary>実績計上拠点コードプロパティ</summary>
		/// <value>実績計上を行う企業内の拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   実績計上拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ResultsAddUpSecCd
		{
			get{return _resultsAddUpSecCd;}
			set{_resultsAddUpSecCd = value;}
		}

		/// public propaty name  :  UpdateSecCd
		/// <summary>更新拠点コードプロパティ</summary>
		/// <value>文字型 データの登録更新拠点</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新拠点コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UpdateSecCd
		{
			get{return _updateSecCd;}
			set{_updateSecCd = value;}
		}

		/// public propaty name  :  SearchSlipDate
		/// <summary>伝票検索日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票検索日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime SearchSlipDate
		{
			get{return _searchSlipDate;}
			set{_searchSlipDate = value;}
		}

		/// public propaty name  :  SearchSlipDateJpFormal
		/// <summary>伝票検索日付 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票検索日付 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SearchSlipDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _searchSlipDate);}
			set{}
		}

		/// public propaty name  :  SearchSlipDateJpInFormal
		/// <summary>伝票検索日付 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票検索日付 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SearchSlipDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _searchSlipDate);}
			set{}
		}

		/// public propaty name  :  SearchSlipDateAdFormal
		/// <summary>伝票検索日付 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票検索日付 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SearchSlipDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _searchSlipDate);}
			set{}
		}

		/// public propaty name  :  SearchSlipDateAdInFormal
		/// <summary>伝票検索日付 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票検索日付 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SearchSlipDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _searchSlipDate);}
			set{}
		}

		/// public propaty name  :  ShipmentDay
		/// <summary>出荷日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime ShipmentDay
		{
			get{return _shipmentDay;}
			set{_shipmentDay = value;}
		}

		/// public propaty name  :  ShipmentDayJpFormal
		/// <summary>出荷日付 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷日付 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ShipmentDayJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _shipmentDay);}
			set{}
		}

		/// public propaty name  :  ShipmentDayJpInFormal
		/// <summary>出荷日付 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷日付 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ShipmentDayJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _shipmentDay);}
			set{}
		}

		/// public propaty name  :  ShipmentDayAdFormal
		/// <summary>出荷日付 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷日付 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ShipmentDayAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _shipmentDay);}
			set{}
		}

		/// public propaty name  :  ShipmentDayAdInFormal
		/// <summary>出荷日付 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷日付 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ShipmentDayAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _shipmentDay);}
			set{}
		}

		/// public propaty name  :  SalesDate
		/// <summary>売上日付プロパティ</summary>
		/// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime SalesDate
		{
			get{return _salesDate;}
			set{_salesDate = value;}
		}

		/// public propaty name  :  SalesDateJpFormal
		/// <summary>売上日付 和暦プロパティ</summary>
		/// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上日付 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _salesDate);}
			set{}
		}

		/// public propaty name  :  SalesDateJpInFormal
		/// <summary>売上日付 和暦(略)プロパティ</summary>
		/// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上日付 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _salesDate);}
			set{}
		}

		/// public propaty name  :  SalesDateAdFormal
		/// <summary>売上日付 西暦プロパティ</summary>
		/// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上日付 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _salesDate);}
			set{}
		}

		/// public propaty name  :  SalesDateAdInFormal
		/// <summary>売上日付 西暦(略)プロパティ</summary>
		/// <value>見積日、受注日、売上日を兼ねる。(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上日付 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _salesDate);}
			set{}
		}

		/// public propaty name  :  AddUpADate
		/// <summary>計上日付プロパティ</summary>
		/// <value>請求日　(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime AddUpADate
		{
			get{return _addUpADate;}
			set{_addUpADate = value;}
		}

		/// public propaty name  :  AddUpADateJpFormal
		/// <summary>計上日付 和暦プロパティ</summary>
		/// <value>請求日　(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  AddUpADateJpInFormal
		/// <summary>計上日付 和暦(略)プロパティ</summary>
		/// <value>請求日　(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  AddUpADateAdFormal
		/// <summary>計上日付 西暦プロパティ</summary>
		/// <value>請求日　(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  AddUpADateAdInFormal
		/// <summary>計上日付 西暦(略)プロパティ</summary>
		/// <value>請求日　(YYYYMMDD)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   計上日付 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddUpADateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _addUpADate);}
			set{}
		}

		/// public propaty name  :  DelayPaymentDiv
		/// <summary>来勘区分プロパティ</summary>
		/// <value>0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   来勘区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DelayPaymentDiv
		{
			get{return _delayPaymentDiv;}
			set{_delayPaymentDiv = value;}
		}

		/// public propaty name  :  ClaimCode
		/// <summary>請求先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ClaimCode
		{
			get{return _claimCode;}
			set{_claimCode = value;}
		}

		/// public propaty name  :  ClaimSnm
		/// <summary>請求先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ClaimSnm
		{
			get{return _claimSnm;}
			set{_claimSnm = value;}
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

		/// public propaty name  :  CustomerName2
		/// <summary>得意先名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerName2
		{
			get{return _customerName2;}
			set{_customerName2 = value;}
		}

		/// public propaty name  :  CustomerSnm
		/// <summary>得意先略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CustomerSnm
		{
			get{return _customerSnm;}
			set{_customerSnm = value;}
		}

		/// public propaty name  :  HonorificTitle
		/// <summary>敬称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   敬称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string HonorificTitle
		{
			get{return _honorificTitle;}
			set{_honorificTitle = value;}
		}

		/// public propaty name  :  OutputNameCode
		/// <summary>諸口コードプロパティ</summary>
		/// <value>0:正式得意先,1:諸口得意先</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   諸口コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OutputNameCode
		{
			get{return _outputNameCode;}
			set{_outputNameCode = value;}
		}

		/// public propaty name  :  BusinessTypeCode
		/// <summary>業種コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   業種コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BusinessTypeCode
		{
			get{return _businessTypeCode;}
			set{_businessTypeCode = value;}
		}

		/// public propaty name  :  BusinessTypeName
		/// <summary>業種名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   業種名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BusinessTypeName
		{
			get{return _businessTypeName;}
			set{_businessTypeName = value;}
		}

		/// public propaty name  :  SalesAreaCode
		/// <summary>販売エリアコードプロパティ</summary>
		/// <value>地区コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売エリアコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesAreaCode
		{
			get{return _salesAreaCode;}
			set{_salesAreaCode = value;}
		}

		/// public propaty name  :  SalesAreaName
		/// <summary>販売エリア名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売エリア名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesAreaName
		{
			get{return _salesAreaName;}
			set{_salesAreaName = value;}
		}

		/// public propaty name  :  SalesInputCode
		/// <summary>売上入力者コードプロパティ</summary>
		/// <value>入力担当者</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上入力者コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesInputCode
		{
			get{return _salesInputCode;}
			set{_salesInputCode = value;}
		}

		/// public propaty name  :  SalesInputName
		/// <summary>売上入力者名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上入力者名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesInputName
		{
			get{return _salesInputName;}
			set{_salesInputName = value;}
		}

		/// public propaty name  :  FrontEmployeeCd
		/// <summary>受付従業員コードプロパティ</summary>
		/// <value>受付担当者</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受付従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrontEmployeeCd
		{
			get{return _frontEmployeeCd;}
			set{_frontEmployeeCd = value;}
		}

		/// public propaty name  :  FrontEmployeeNm
		/// <summary>受付従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受付従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FrontEmployeeNm
		{
			get{return _frontEmployeeNm;}
			set{_frontEmployeeNm = value;}
		}

		/// public propaty name  :  SalesEmployeeCd
		/// <summary>販売従業員コードプロパティ</summary>
		/// <value>計上担当者</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売従業員コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesEmployeeCd
		{
			get{return _salesEmployeeCd;}
			set{_salesEmployeeCd = value;}
		}

		/// public propaty name  :  SalesEmployeeNm
		/// <summary>販売従業員名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売従業員名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesEmployeeNm
		{
			get{return _salesEmployeeNm;}
			set{_salesEmployeeNm = value;}
		}

		/// public propaty name  :  ConsTaxLayMethod
		/// <summary>消費税転嫁方式プロパティ</summary>
		/// <value>0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税転嫁方式プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ConsTaxLayMethod
		{
			get{return _consTaxLayMethod;}
			set{_consTaxLayMethod = value;}
		}

		/// public propaty name  :  ConsTaxRate
		/// <summary>消費税税率プロパティ</summary>
		/// <value>変更2007/8/22(型,桁) 塩原</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消費税税率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ConsTaxRate
		{
			get{return _consTaxRate;}
			set{_consTaxRate = value;}
		}

		/// public propaty name  :  FractionProcCd
		/// <summary>端数処理区分プロパティ</summary>
		/// <value>1:切捨て,2:四捨五入,3:切上げ　（消費税）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FractionProcCd
		{
			get{return _fractionProcCd;}
			set{_fractionProcCd = value;}
		}

		/// public propaty name  :  AutoDepositCd
		/// <summary>自動入金区分プロパティ</summary>
		/// <value>0:通常入金,1:自動入金</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動入金区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoDepositCd
		{
			get{return _autoDepositCd;}
			set{_autoDepositCd = value;}
		}

		/// public propaty name  :  AutoDepoSlipNum
		/// <summary>自動入金伝票番号プロパティ</summary>
		/// <value>自動入金時の入金伝票番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自動入金伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AutoDepoSlipNum
		{
			get{return _autoDepoSlipNum;}
			set{_autoDepoSlipNum = value;}
		}

		/// public propaty name  :  SlipAddressDiv
		/// <summary>伝票住所区分プロパティ</summary>
		/// <value>1:得意先,2:納入先</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票住所区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipAddressDiv
		{
			get{return _slipAddressDiv;}
			set{_slipAddressDiv = value;}
		}

		/// public propaty name  :  AddresseeCode
		/// <summary>納品先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddresseeCode
		{
			get{return _addresseeCode;}
			set{_addresseeCode = value;}
		}

		/// public propaty name  :  AddresseeName
		/// <summary>納品先名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeName
		{
			get{return _addresseeName;}
			set{_addresseeName = value;}
		}

		/// public propaty name  :  AddresseeName2
		/// <summary>納品先名称2プロパティ</summary>
		/// <value>追加(登録漏れ) 塩原</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeName2
		{
			get{return _addresseeName2;}
			set{_addresseeName2 = value;}
		}

		/// public propaty name  :  AddresseePostNo
		/// <summary>納品先郵便番号プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先郵便番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseePostNo
		{
			get{return _addresseePostNo;}
			set{_addresseePostNo = value;}
		}

		/// public propaty name  :  AddresseeAddr1
		/// <summary>納品先住所1(都道府県市区郡・町村・字)プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先住所1(都道府県市区郡・町村・字)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeAddr1
		{
			get{return _addresseeAddr1;}
			set{_addresseeAddr1 = value;}
		}

		/// public propaty name  :  AddresseeAddr2
		/// <summary>納品先住所2(丁目)プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先住所2(丁目)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddresseeAddr2
		{
			get{return _addresseeAddr2;}
			set{_addresseeAddr2 = value;}
		}

		/// public propaty name  :  AddresseeAddr3
		/// <summary>納品先住所3(番地)プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先住所3(番地)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeAddr3
		{
			get{return _addresseeAddr3;}
			set{_addresseeAddr3 = value;}
		}

		/// public propaty name  :  AddresseeAddr4
		/// <summary>納品先住所4(アパート名称)プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先住所4(アパート名称)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeAddr4
		{
			get{return _addresseeAddr4;}
			set{_addresseeAddr4 = value;}
		}

		/// public propaty name  :  AddresseeTelNo
		/// <summary>納品先電話番号プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先電話番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeTelNo
		{
			get{return _addresseeTelNo;}
			set{_addresseeTelNo = value;}
		}

		/// public propaty name  :  AddresseeFaxNo
		/// <summary>納品先FAX番号プロパティ</summary>
		/// <value>伝票住所区分に従う内容</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品先FAX番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AddresseeFaxNo
		{
			get{return _addresseeFaxNo;}
			set{_addresseeFaxNo = value;}
		}

		/// public propaty name  :  PartySaleSlipNum
		/// <summary>相手先伝票番号プロパティ</summary>
		/// <value>得意先注文番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手先伝票番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PartySaleSlipNum
		{
			get{return _partySaleSlipNum;}
			set{_partySaleSlipNum = value;}
		}

		/// public propaty name  :  SlipNote
		/// <summary>伝票備考プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票備考プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipNote
		{
			get{return _slipNote;}
			set{_slipNote = value;}
		}

		/// public propaty name  :  SlipNote2
		/// <summary>伝票備考２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票備考２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipNote2
		{
			get{return _slipNote2;}
			set{_slipNote2 = value;}
		}

		/// public propaty name  :  RetGoodsReasonDiv
		/// <summary>返品理由コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品理由コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RetGoodsReasonDiv
		{
			get{return _retGoodsReasonDiv;}
			set{_retGoodsReasonDiv = value;}
		}

		/// public propaty name  :  RetGoodsReason
		/// <summary>返品理由プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   返品理由プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RetGoodsReason
		{
			get{return _retGoodsReason;}
			set{_retGoodsReason = value;}
		}

		/// public propaty name  :  DetailRowCount
		/// <summary>明細行数プロパティ</summary>
		/// <value>伝票内の明細の行数（諸費用明細は除く）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細行数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DetailRowCount
		{
			get{return _detailRowCount;}
			set{_detailRowCount = value;}
		}

		/// public propaty name  :  DeliveredGoodsDiv
		/// <summary>納品区分プロパティ</summary>
		/// <value>例) 1:配達,2:店頭渡し,3:直送,…</value>
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

		/// public propaty name  :  DeliveredGoodsDivNm
		/// <summary>納品区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliveredGoodsDivNm
		{
			get{return _deliveredGoodsDivNm;}
			set{_deliveredGoodsDivNm = value;}
		}

		/// public propaty name  :  ReconcileFlag
		/// <summary>消込フラグプロパティ</summary>
		/// <value>0:残あり 1:残無し　（受注、出荷にて使用）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   消込フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ReconcileFlag
		{
			get{return _reconcileFlag;}
			set{_reconcileFlag = value;}
		}

		/// public propaty name  :  SlipPrtSetPaperId
		/// <summary>伝票印刷設定用帳票IDプロパティ</summary>
		/// <value>売上形式とセットで伝票タイプ管理マスタを参照</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipPrtSetPaperId
		{
			get{return _slipPrtSetPaperId;}
			set{_slipPrtSetPaperId = value;}
		}

		/// public propaty name  :  CompleteCd
		/// <summary>一式伝票区分プロパティ</summary>
		/// <value>0:通常伝票,1:一式伝票</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   一式伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CompleteCd
		{
			get{return _completeCd;}
			set{_completeCd = value;}
		}

		/// public propaty name  :  ClaimType
		/// <summary>請求先区分プロパティ</summary>
		/// <value>官庁請求区分（0:一般　1:官庁標準　2:官庁伝票）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求先区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ClaimType
		{
			get{return _claimType;}
			set{_claimType = value;}
		}

		/// public propaty name  :  SalesPriceFracProcCd
		/// <summary>売上金額端数処理区分プロパティ</summary>
		/// <value>1:切捨て,2:四捨五入,3:切上げ　（売上明細データの金額用）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上金額端数処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesPriceFracProcCd
		{
			get{return _salesPriceFracProcCd;}
			set{_salesPriceFracProcCd = value;}
		}

		/// public propaty name  :  ListPricePrintDiv
		/// <summary>定価印刷区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ListPricePrintDiv
		{
			get{return _listPricePrintDiv;}
			set{_listPricePrintDiv = value;}
		}

		/// public propaty name  :  EraNameDispCd1
		/// <summary>元号表示区分１プロパティ</summary>
		/// <value>通常　　0:西暦　1:和暦</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   元号表示区分１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EraNameDispCd1
		{
			get{return _eraNameDispCd1;}
			set{_eraNameDispCd1 = value;}
		}

		/// public propaty name  :  AcceptAnOrderNo
		/// <summary>受注番号プロパティ</summary>
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

		/// public propaty name  :  CommonSeqNo
		/// <summary>共通通番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   共通通番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 CommonSeqNo
		{
			get{return _commonSeqNo;}
			set{_commonSeqNo = value;}
		}

		/// public propaty name  :  SalesSlipDtlNum
		/// <summary>売上明細通番プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上明細通番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesSlipDtlNum
		{
			get{return _salesSlipDtlNum;}
			set{_salesSlipDtlNum = value;}
		}

		/// public propaty name  :  AcptAnOdrStatusSrc
		/// <summary>受注ステータス（元）プロパティ</summary>
		/// <value>10:見積,20:受注,30:売上,40:出荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注ステータス（元）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AcptAnOdrStatusSrc
		{
			get{return _acptAnOdrStatusSrc;}
			set{_acptAnOdrStatusSrc = value;}
		}

		/// public propaty name  :  SalesSlipDtlNumSrc
		/// <summary>売上明細通番（元）プロパティ</summary>
		/// <value>計上時の元データ明細通番をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上明細通番（元）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesSlipDtlNumSrc
		{
			get{return _salesSlipDtlNumSrc;}
			set{_salesSlipDtlNumSrc = value;}
		}

		/// public propaty name  :  SupplierFormalSync
		/// <summary>仕入形式（同時）プロパティ</summary>
		/// <value>0:仕入,1:入荷</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入形式（同時）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierFormalSync
		{
			get{return _supplierFormalSync;}
			set{_supplierFormalSync = value;}
		}

		/// public propaty name  :  StockSlipDtlNumSync
		/// <summary>仕入明細通番（同時）プロパティ</summary>
		/// <value>同時計上時の仕入明細通番をセット</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入明細通番（同時）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 StockSlipDtlNumSync
		{
			get{return _stockSlipDtlNumSync;}
			set{_stockSlipDtlNumSync = value;}
		}

		/// public propaty name  :  SalesSlipCdDtl
		/// <summary>売上伝票区分（明細）プロパティ</summary>
		/// <value>0:売上,1:返品,2:値引,3:注釈,4:小計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上伝票区分（明細）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesSlipCdDtl
		{
			get{return _salesSlipCdDtl;}
			set{_salesSlipCdDtl = value;}
		}

		/// public propaty name  :  OrderNumber
		/// <summary>発注番号プロパティ</summary>
		/// <value>売上形式＝"出荷"の時にセット（発注の計上）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   発注番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OrderNumber
		{
			get{return _orderNumber;}
			set{_orderNumber = value;}
		}

		/// public propaty name  :  StockMngExistCd
		/// <summary>在庫管理有無区分プロパティ</summary>
		/// <value>0:在庫管理しない,1:在庫管理する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   在庫管理有無区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockMngExistCd
		{
			get{return _stockMngExistCd;}
			set{_stockMngExistCd = value;}
		}

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>納品完了予定日プロパティ</summary>
		/// <value>YYYYMMDD</value>
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

		/// public propaty name  :  DeliGdsCmpltDueDateJpFormal
		/// <summary>納品完了予定日 和暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 和暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpFormal
		{
			get{return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateJpInFormal
		/// <summary>納品完了予定日 和暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 和暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateJpInFormal
		{
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdFormal
		/// <summary>納品完了予定日 西暦プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 西暦プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdFormal
		{
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  DeliGdsCmpltDueDateAdInFormal
		/// <summary>納品完了予定日 西暦(略)プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   納品完了予定日 西暦(略)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DeliGdsCmpltDueDateAdInFormal
		{
			get{return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
		}

		/// public propaty name  :  GoodsKindCode
		/// <summary>商品属性プロパティ</summary>
		/// <value>0:純正 1:その他</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品属性プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsKindCode
		{
			get{return _goodsKindCode;}
			set{_goodsKindCode = value;}
		}

		/// public propaty name  :  GoodsMakerCd
		/// <summary>商品メーカーコードプロパティ</summary>
		/// <value>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</value>
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

		/// public propaty name  :  GoodsShortName
		/// <summary>商品名略称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名略称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsShortName
		{
			get{return _goodsShortName;}
			set{_goodsShortName = value;}
		}

		/// public propaty name  :  GoodsSetDivCd
		/// <summary>セット商品区分プロパティ</summary>
		/// <value>0:通常,1:親商品,2:子商品</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   セット商品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsSetDivCd
		{
			get{return _goodsSetDivCd;}
			set{_goodsSetDivCd = value;}
		}

		/// public propaty name  :  LargeGoodsGanreCode
		/// <summary>商品区分グループコードプロパティ</summary>
		/// <value>旧：商品大分類コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LargeGoodsGanreCode
		{
			get{return _largeGoodsGanreCode;}
			set{_largeGoodsGanreCode = value;}
		}

		/// public propaty name  :  LargeGoodsGanreName
		/// <summary>商品区分グループ名称プロパティ</summary>
		/// <value>旧：商品大分類名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分グループ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string LargeGoodsGanreName
		{
			get{return _largeGoodsGanreName;}
			set{_largeGoodsGanreName = value;}
		}

		/// public propaty name  :  MediumGoodsGanreCode
		/// <summary>商品区分コードプロパティ</summary>
		/// <value>旧：商品中分類コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MediumGoodsGanreCode
		{
			get{return _mediumGoodsGanreCode;}
			set{_mediumGoodsGanreCode = value;}
		}

		/// public propaty name  :  MediumGoodsGanreName
		/// <summary>商品区分名称プロパティ</summary>
		/// <value>旧：商品中分類名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string MediumGoodsGanreName
		{
			get{return _mediumGoodsGanreName;}
			set{_mediumGoodsGanreName = value;}
		}

		/// public propaty name  :  DetailGoodsGanreCode
		/// <summary>商品区分詳細コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分詳細コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DetailGoodsGanreCode
		{
			get{return _detailGoodsGanreCode;}
			set{_detailGoodsGanreCode = value;}
		}

		/// public propaty name  :  DetailGoodsGanreName
		/// <summary>商品区分詳細名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品区分詳細名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DetailGoodsGanreName
		{
			get{return _detailGoodsGanreName;}
			set{_detailGoodsGanreName = value;}
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

		/// public propaty name  :  EnterpriseGanreCode
		/// <summary>自社分類コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EnterpriseGanreCode
		{
			get{return _enterpriseGanreCode;}
			set{_enterpriseGanreCode = value;}
		}

		/// public propaty name  :  EnterpriseGanreName
		/// <summary>自社分類名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社分類名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EnterpriseGanreName
		{
			get{return _enterpriseGanreName;}
			set{_enterpriseGanreName = value;}
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

		/// public propaty name  :  SalesOrderDivCd
		/// <summary>売上在庫取寄せ区分プロパティ</summary>
		/// <value>0:取寄せ,1:在庫</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上在庫取寄せ区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesOrderDivCd
		{
			get{return _salesOrderDivCd;}
			set{_salesOrderDivCd = value;}
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

		/// public propaty name  :  UnitCode
		/// <summary>単位コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単位コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnitCode
		{
			get{return _unitCode;}
			set{_unitCode = value;}
		}

		/// public propaty name  :  UnitName
		/// <summary>単位名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単位名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string UnitName
		{
			get{return _unitName;}
			set{_unitName = value;}
		}

		/// public propaty name  :  GoodsRateRank
		/// <summary>商品掛率ランクプロパティ</summary>
		/// <value>商品の掛率用ランク</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品掛率ランクプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsRateRank
		{
			get{return _goodsRateRank;}
			set{_goodsRateRank = value;}
		}

		/// public propaty name  :  CustRateGrpCode
		/// <summary>得意先掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   得意先掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CustRateGrpCode
		{
			get{return _custRateGrpCode;}
			set{_custRateGrpCode = value;}
		}

		/// public propaty name  :  SuppRateGrpCode
		/// <summary>仕入先掛率グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先掛率グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SuppRateGrpCode
		{
			get{return _suppRateGrpCode;}
			set{_suppRateGrpCode = value;}
		}

		/// public propaty name  :  ListPriceRate
		/// <summary>定価率プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceRate
		{
			get{return _listPriceRate;}
			set{_listPriceRate = value;}
		}

		/// public propaty name  :  RateSectPriceUnPrc
		/// <summary>掛率設定拠点（定価）プロパティ</summary>
		/// <value>0:全社設定, その他:拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定拠点（定価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateSectPriceUnPrc
		{
			get{return _rateSectPriceUnPrc;}
			set{_rateSectPriceUnPrc = value;}
		}

		/// public propaty name  :  RateDivLPrice
		/// <summary>掛率設定区分（定価）プロパティ</summary>
		/// <value>A1,A2,…</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定区分（定価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateDivLPrice
		{
			get{return _rateDivLPrice;}
			set{_rateDivLPrice = value;}
		}

		/// public propaty name  :  UnPrcCalcCdLPrice
		/// <summary>単価算出区分（定価）プロパティ</summary>
		/// <value>1:掛率,2:原価ＵＰ率,3:粗利率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価算出区分（定価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnPrcCalcCdLPrice
		{
			get{return _unPrcCalcCdLPrice;}
			set{_unPrcCalcCdLPrice = value;}
		}

		/// public propaty name  :  PriceCdLPrice
		/// <summary>価格区分（定価）プロパティ</summary>
		/// <value>0:定価,1:登録販売店価格,… 9:ユーザー定価</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格区分（定価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceCdLPrice
		{
			get{return _priceCdLPrice;}
			set{_priceCdLPrice = value;}
		}

		/// public propaty name  :  StdUnPrcLPrice
		/// <summary>基準単価（定価）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   基準単価（定価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StdUnPrcLPrice
		{
			get{return _stdUnPrcLPrice;}
			set{_stdUnPrcLPrice = value;}
		}

		/// public propaty name  :  FracProcUnitLPrice
		/// <summary>端数処理単位（定価）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理単位（定価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double FracProcUnitLPrice
		{
			get{return _fracProcUnitLPrice;}
			set{_fracProcUnitLPrice = value;}
		}

		/// public propaty name  :  FracProcLPrice
		/// <summary>端数処理（定価）プロパティ</summary>
		/// <value>1：切捨て,2：四捨五入,3:切上げ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理（定価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FracProcLPrice
		{
			get{return _fracProcLPrice;}
			set{_fracProcLPrice = value;}
		}

		/// public propaty name  :  ListPriceTaxIncFl
		/// <summary>定価（税込，浮動）プロパティ</summary>
		/// <value>税抜き</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価（税込，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceTaxIncFl
		{
			get{return _listPriceTaxIncFl;}
			set{_listPriceTaxIncFl = value;}
		}

		/// public propaty name  :  ListPriceTaxExcFl
		/// <summary>定価（税抜，浮動）プロパティ</summary>
		/// <value>税込み</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ListPriceTaxExcFl
		{
			get{return _listPriceTaxExcFl;}
			set{_listPriceTaxExcFl = value;}
		}

		/// public propaty name  :  ListPriceChngCd
		/// <summary>定価変更区分プロパティ</summary>
		/// <value>0:変更なし,1:変更あり　（定価手入力）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   定価変更区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ListPriceChngCd
		{
			get{return _listPriceChngCd;}
			set{_listPriceChngCd = value;}
		}

		/// public propaty name  :  SalesRate
		/// <summary>売価率プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売価率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesRate
		{
			get{return _salesRate;}
			set{_salesRate = value;}
		}

		/// public propaty name  :  RateSectSalUnPrc
		/// <summary>掛率設定拠点（売上単価）プロパティ</summary>
		/// <value>0:全社設定, その他:拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定拠点（売上単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateSectSalUnPrc
		{
			get{return _rateSectSalUnPrc;}
			set{_rateSectSalUnPrc = value;}
		}

		/// public propaty name  :  RateDivSalUnPrc
		/// <summary>掛率設定区分（売上単価）プロパティ</summary>
		/// <value>A1,A2,…</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定区分（売上単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateDivSalUnPrc
		{
			get{return _rateDivSalUnPrc;}
			set{_rateDivSalUnPrc = value;}
		}

		/// public propaty name  :  UnPrcCalcCdSalUnPrc
		/// <summary>単価算出区分（売上単価）プロパティ</summary>
		/// <value>1:掛率,2:原価ＵＰ率,3:粗利率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価算出区分（売上単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnPrcCalcCdSalUnPrc
		{
			get{return _unPrcCalcCdSalUnPrc;}
			set{_unPrcCalcCdSalUnPrc = value;}
		}

		/// public propaty name  :  PriceCdSalUnPrc
		/// <summary>価格区分（売上単価）プロパティ</summary>
		/// <value>0:定価,1:登録販売店価格,…</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格区分（売上単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceCdSalUnPrc
		{
			get{return _priceCdSalUnPrc;}
			set{_priceCdSalUnPrc = value;}
		}

		/// public propaty name  :  StdUnPrcSalUnPrc
		/// <summary>基準単価（売上単価）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   基準単価（売上単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StdUnPrcSalUnPrc
		{
			get{return _stdUnPrcSalUnPrc;}
			set{_stdUnPrcSalUnPrc = value;}
		}

		/// public propaty name  :  FracProcUnitSalUnPrc
		/// <summary>端数処理単位（売上単価）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理単位（売上単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double FracProcUnitSalUnPrc
		{
			get{return _fracProcUnitSalUnPrc;}
			set{_fracProcUnitSalUnPrc = value;}
		}

		/// public propaty name  :  FracProcSalUnPrc
		/// <summary>端数処理（売上単価）プロパティ</summary>
		/// <value>1：切捨て,2：四捨五入,3:切上げ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理（売上単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FracProcSalUnPrc
		{
			get{return _fracProcSalUnPrc;}
			set{_fracProcSalUnPrc = value;}
		}

		/// public propaty name  :  SalesUnPrcTaxIncFl
		/// <summary>売上単価（税込，浮動）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上単価（税込，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesUnPrcTaxIncFl
		{
			get{return _salesUnPrcTaxIncFl;}
			set{_salesUnPrcTaxIncFl = value;}
		}

		/// public propaty name  :  SalesUnPrcTaxExcFl
		/// <summary>売上単価（税抜，浮動）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上単価（税抜，浮動）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesUnPrcTaxExcFl
		{
			get{return _salesUnPrcTaxExcFl;}
			set{_salesUnPrcTaxExcFl = value;}
		}

		/// public propaty name  :  SalesUnPrcChngCd
		/// <summary>売上単価変更区分プロパティ</summary>
		/// <value>0:変更なし,1:変更あり　（売上単価手入力）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上単価変更区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesUnPrcChngCd
		{
			get{return _salesUnPrcChngCd;}
			set{_salesUnPrcChngCd = value;}
		}

		/// public propaty name  :  CostRate
		/// <summary>原価率プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double CostRate
		{
			get{return _costRate;}
			set{_costRate = value;}
		}

		/// public propaty name  :  RateSectCstUnPrc
		/// <summary>掛率設定拠点（原価単価）プロパティ</summary>
		/// <value>0:全社設定, その他:拠点コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定拠点（原価単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateSectCstUnPrc
		{
			get{return _rateSectCstUnPrc;}
			set{_rateSectCstUnPrc = value;}
		}

		/// public propaty name  :  RateDivUnCst
		/// <summary>掛率設定区分（原価単価）プロパティ</summary>
		/// <value>A7,A8,…</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   掛率設定区分（原価単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateDivUnCst
		{
			get{return _rateDivUnCst;}
			set{_rateDivUnCst = value;}
		}

		/// public propaty name  :  UnPrcCalcCdUnCst
		/// <summary>単価算出区分（原価単価）プロパティ</summary>
		/// <value>1:掛率,2:原価ＵＰ率,3:粗利率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   単価算出区分（原価単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UnPrcCalcCdUnCst
		{
			get{return _unPrcCalcCdUnCst;}
			set{_unPrcCalcCdUnCst = value;}
		}

		/// public propaty name  :  PriceCdUnCst
		/// <summary>価格区分（原価単価）プロパティ</summary>
		/// <value>0:定価,1:登録販売店価格,…</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格区分（原価単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PriceCdUnCst
		{
			get{return _priceCdUnCst;}
			set{_priceCdUnCst = value;}
		}

		/// public propaty name  :  StdUnPrcUnCst
		/// <summary>基準単価（原価単価）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   基準単価（原価単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double StdUnPrcUnCst
		{
			get{return _stdUnPrcUnCst;}
			set{_stdUnPrcUnCst = value;}
		}

		/// public propaty name  :  FracProcUnitUnCst
		/// <summary>端数処理単位（原価単価）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理単位（原価単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double FracProcUnitUnCst
		{
			get{return _fracProcUnitUnCst;}
			set{_fracProcUnitUnCst = value;}
		}

		/// public propaty name  :  FracProcUnCst
		/// <summary>端数処理（原価単価）プロパティ</summary>
		/// <value>1：切捨て,2：四捨五入,3:切上げ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端数処理（原価単価）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FracProcUnCst
		{
			get{return _fracProcUnCst;}
			set{_fracProcUnCst = value;}
		}

		/// public propaty name  :  SalesUnitCost
		/// <summary>原価単価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価単価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double SalesUnitCost
		{
			get{return _salesUnitCost;}
			set{_salesUnitCost = value;}
		}

		/// public propaty name  :  SalesUnitCostChngDiv
		/// <summary>原価単価変更区分プロパティ</summary>
		/// <value>0:変更なし,1:変更あり　（原価単価手入力）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価単価変更区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesUnitCostChngDiv
		{
			get{return _salesUnitCostChngDiv;}
			set{_salesUnitCostChngDiv = value;}
		}

		/// public propaty name  :  RateBLGoodsCode
		/// <summary>BL商品コード（掛率）プロパティ</summary>
		/// <value>掛率算出時に使用したBLコード（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード（掛率）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RateBLGoodsCode
		{
			get{return _rateBLGoodsCode;}
			set{_rateBLGoodsCode = value;}
		}

		/// public propaty name  :  RateBLGoodsName
		/// <summary>BL商品コード名称（掛率）プロパティ</summary>
		/// <value>掛率算出時に使用したBLコード名称（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称（掛率）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RateBLGoodsName
		{
			get{return _rateBLGoodsName;}
			set{_rateBLGoodsName = value;}
		}

		/// public propaty name  :  BargainCd
		/// <summary>特売区分コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   特売区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BargainCd
		{
			get{return _bargainCd;}
			set{_bargainCd = value;}
		}

		/// public propaty name  :  BargainNm
		/// <summary>特売区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   特売区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BargainNm
		{
			get{return _bargainNm;}
			set{_bargainNm = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>出荷数プロパティ</summary>
		/// <value>売上：売上数、受注：受注数、出荷：出荷数、見積：見積数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出荷数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double ShipmentCnt
		{
			get{return _shipmentCnt;}
			set{_shipmentCnt = value;}
		}

		/// public propaty name  :  SalesMoneyTaxInc
		/// <summary>売上金額（税込み）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上金額（税込み）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesMoneyTaxInc
		{
			get{return _salesMoneyTaxInc;}
			set{_salesMoneyTaxInc = value;}
		}

		/// public propaty name  :  SalesMoneyTaxExc
		/// <summary>売上金額（税抜き）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上金額（税抜き）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesMoneyTaxExc
		{
			get{return _salesMoneyTaxExc;}
			set{_salesMoneyTaxExc = value;}
		}

		/// public propaty name  :  Cost
		/// <summary>原価プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 Cost
		{
			get{return _cost;}
			set{_cost = value;}
		}

		/// public propaty name  :  GrsProfitChkDiv
		/// <summary>粗利チェック区分プロパティ</summary>
		/// <value>0:正常,1:原価割れ,2:利益の上げ過ぎ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   粗利チェック区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GrsProfitChkDiv
		{
			get{return _grsProfitChkDiv;}
			set{_grsProfitChkDiv = value;}
		}

		/// public propaty name  :  SalesGoodsCd
		/// <summary>売上商品区分プロパティ</summary>
		/// <value>0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上商品区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesGoodsCd
		{
			get{return _salesGoodsCd;}
			set{_salesGoodsCd = value;}
		}

		/// public propaty name  :  SalsePriceConsTax
		/// <summary>売上金額消費税額プロパティ</summary>
		/// <value>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上金額消費税額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalsePriceConsTax
		{
			get{return _salsePriceConsTax;}
			set{_salsePriceConsTax = value;}
		}

		/// public propaty name  :  TaxationDivCd
		/// <summary>課税区分プロパティ</summary>
		/// <value>0:課税,1:非課税,2:課税（内税）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   課税区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TaxationDivCd
		{
			get{return _taxationDivCd;}
			set{_taxationDivCd = value;}
		}

		/// public propaty name  :  PartySlipNumDtl
		/// <summary>相手先伝票番号（明細）プロパティ</summary>
		/// <value>得意先注文番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手先伝票番号（明細）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PartySlipNumDtl
		{
			get{return _partySlipNumDtl;}
			set{_partySlipNumDtl = value;}
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

		/// public propaty name  :  SupplierCd
		/// <summary>仕入先コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierCd
		{
			get{return _supplierCd;}
			set{_supplierCd = value;}
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
			get{return _supplierSnm;}
			set{_supplierSnm = value;}
		}

		/// public propaty name  :  SlipMemo1
		/// <summary>伝票メモ１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票メモ１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipMemo1
		{
			get{return _slipMemo1;}
			set{_slipMemo1 = value;}
		}

		/// public propaty name  :  SlipMemo2
		/// <summary>伝票メモ２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票メモ２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipMemo2
		{
			get{return _slipMemo2;}
			set{_slipMemo2 = value;}
		}

		/// public propaty name  :  SlipMemo3
		/// <summary>伝票メモ３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票メモ３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipMemo3
		{
			get{return _slipMemo3;}
			set{_slipMemo3 = value;}
		}

		/// public propaty name  :  SlipMemo4
		/// <summary>伝票メモ４プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票メモ４プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipMemo4
		{
			get{return _slipMemo4;}
			set{_slipMemo4 = value;}
		}

		/// public propaty name  :  SlipMemo5
		/// <summary>伝票メモ５プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票メモ５プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipMemo5
		{
			get{return _slipMemo5;}
			set{_slipMemo5 = value;}
		}

		/// public propaty name  :  SlipMemo6
		/// <summary>伝票メモ６プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票メモ６プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipMemo6
		{
			get{return _slipMemo6;}
			set{_slipMemo6 = value;}
		}

		/// public propaty name  :  InsideMemo1
		/// <summary>社内メモ１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内メモ１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InsideMemo1
		{
			get{return _insideMemo1;}
			set{_insideMemo1 = value;}
		}

		/// public propaty name  :  InsideMemo2
		/// <summary>社内メモ２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内メモ２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InsideMemo2
		{
			get{return _insideMemo2;}
			set{_insideMemo2 = value;}
		}

		/// public propaty name  :  InsideMemo3
		/// <summary>社内メモ３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内メモ３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InsideMemo3
		{
			get{return _insideMemo3;}
			set{_insideMemo3 = value;}
		}

		/// public propaty name  :  InsideMemo4
		/// <summary>社内メモ４プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内メモ４プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InsideMemo4
		{
			get{return _insideMemo4;}
			set{_insideMemo4 = value;}
		}

		/// public propaty name  :  InsideMemo5
		/// <summary>社内メモ５プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内メモ５プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InsideMemo5
		{
			get{return _insideMemo5;}
			set{_insideMemo5 = value;}
		}

		/// public propaty name  :  InsideMemo6
		/// <summary>社内メモ６プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   社内メモ６プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InsideMemo6
		{
			get{return _insideMemo6;}
			set{_insideMemo6 = value;}
		}

		/// public propaty name  :  BfListPrice
		/// <summary>変更前定価プロパティ</summary>
		/// <value>税抜き、掛率算出結果</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変更前定価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double BfListPrice
		{
			get{return _bfListPrice;}
			set{_bfListPrice = value;}
		}

		/// public propaty name  :  BfSalesUnitPrice
		/// <summary>変更前売価プロパティ</summary>
		/// <value>税抜き、掛率算出結果</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変更前売価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double BfSalesUnitPrice
		{
			get{return _bfSalesUnitPrice;}
			set{_bfSalesUnitPrice = value;}
		}

		/// public propaty name  :  BfUnitCost
		/// <summary>変更前原価プロパティ</summary>
		/// <value>税抜き、掛率算出結果</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   変更前原価プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double BfUnitCost
		{
			get{return _bfUnitCost;}
			set{_bfUnitCost = value;}
		}

		/// public propaty name  :  PrtGoodsNo
		/// <summary>印刷用商品番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷用商品番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrtGoodsNo
		{
			get{return _prtGoodsNo;}
			set{_prtGoodsNo = value;}
		}

		/// public propaty name  :  PrtGoodsName
		/// <summary>印刷用商品名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷用商品名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrtGoodsName
		{
			get{return _prtGoodsName;}
			set{_prtGoodsName = value;}
		}

		/// public propaty name  :  PrtGoodsMakerCd
		/// <summary>印刷用商品メーカーコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷用商品メーカーコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrtGoodsMakerCd
		{
			get{return _prtGoodsMakerCd;}
			set{_prtGoodsMakerCd = value;}
		}

		/// public propaty name  :  PrtGoodsMakerNm
		/// <summary>印刷用商品メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷用商品メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrtGoodsMakerNm
		{
			get{return _prtGoodsMakerNm;}
			set{_prtGoodsMakerNm = value;}
		}

		/// public propaty name  :  SupplierSlipCd
		/// <summary>仕入伝票区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入伝票区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SupplierSlipCd
		{
			get{return _supplierSlipCd;}
			set{_supplierSlipCd = value;}
		}

		/// public propaty name  :  TotalAmountDispWayCd
		/// <summary>総額表示方法区分プロパティ</summary>
		/// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   総額表示方法区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalAmountDispWayCd
		{
			get{return _totalAmountDispWayCd;}
			set{_totalAmountDispWayCd = value;}
		}

		/// public propaty name  :  TtlAmntDispRateApy
		/// <summary>総額表示掛率適用区分プロパティ</summary>
		/// <value>0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   総額表示掛率適用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TtlAmntDispRateApy
		{
			get{return _ttlAmntDispRateApy;}
			set{_ttlAmntDispRateApy = value;}
		}

		/// public propaty name  :  ConfirmedDiv
		/// <summary>確認区分プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   確認区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool ConfirmedDiv
		{
			get{return _confirmedDiv;}
			set{_confirmedDiv = value;}
		}

		/// public propaty name  :  NTimeCalcStDate
		/// <summary>次回勘定開始日プロパティ</summary>
		/// <value>01～31まで（省略可能）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   次回勘定開始日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NTimeCalcStDate
		{
			get{return _nTimeCalcStDate;}
			set{_nTimeCalcStDate = value;}
		}

		/// public propaty name  :  TotalDay
		/// <summary>締日プロパティ</summary>
		/// <value>DD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   締日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalDay
		{
			get{return _totalDay;}
			set{_totalDay = value;}
		}

		/// public propaty name  :  DtlRelationGuid
		/// <summary>明細関連付けGUIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細関連付けGUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid DtlRelationGuid
		{
			get{return _dtlRelationGuid;}
			set{_dtlRelationGuid = value;}
		}

		/// public propaty name  :  AcptAnOdrRemainCnt
		/// <summary>受注残数プロパティ</summary>
		/// <value>受注数量＋受注調整数－出荷数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注残数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double AcptAnOdrRemainCnt
		{
			get{return _acptAnOdrRemainCnt;}
			set{_acptAnOdrRemainCnt = value;}
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

		/// public propaty name  :  ResultsAddUpSecNm
		/// <summary>実績計上拠点名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   実績計上拠点名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ResultsAddUpSecNm
		{
			get{return _resultsAddUpSecNm;}
			set{_resultsAddUpSecNm = value;}
		}

		/// public propaty name  :  OutputName
		/// <summary>諸口名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   諸口名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutputName
		{
			get{return _outputName;}
			set{_outputName = value;}
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


		/// <summary>
		/// 売上データ（仕入同時計上）コンストラクタ
		/// </summary>
		/// <returns>SalesTempクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTempクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesTemp()
		{
		}

		/// <summary>
		/// 売上データ（仕入同時計上）コンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上,40:出荷)</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="subSectionCode">部門コード</param>
		/// <param name="minSectionCode">課コード</param>
		/// <param name="debitNoteDiv">赤伝区分(0:黒伝,1:赤伝,2:元黒)</param>
		/// <param name="debitNLnkAcptAnOdr">赤黒連結受注番号(赤黒の相手方受注番号)</param>
		/// <param name="salesSlipCd">売上伝票区分(0:売上,1:返品)</param>
		/// <param name="accRecDivCd">売掛区分(0:売掛なし,1:売掛)</param>
		/// <param name="salesInpSecCd">売上入力拠点コード(文字型 売上を入力した拠点コード)</param>
		/// <param name="demandAddUpSecCd">請求計上拠点コード(文字型)</param>
		/// <param name="resultsAddUpSecCd">実績計上拠点コード(実績計上を行う企業内の拠点コード)</param>
		/// <param name="updateSecCd">更新拠点コード(文字型 データの登録更新拠点)</param>
		/// <param name="searchSlipDate">伝票検索日付(YYYYMMDD)</param>
		/// <param name="shipmentDay">出荷日付(YYYYMMDD)</param>
		/// <param name="salesDate">売上日付(見積日、受注日、売上日を兼ねる。(YYYYMMDD))</param>
		/// <param name="addUpADate">計上日付(請求日　(YYYYMMDD))</param>
		/// <param name="delayPaymentDiv">来勘区分(0:当月(来勘なし),1:来月,2:再来月…9:9ヵ月後)</param>
		/// <param name="claimCode">請求先コード</param>
		/// <param name="claimSnm">請求先略称</param>
		/// <param name="customerCode">得意先コード</param>
		/// <param name="customerName">得意先名称</param>
		/// <param name="customerName2">得意先名称2</param>
		/// <param name="customerSnm">得意先略称</param>
		/// <param name="honorificTitle">敬称</param>
		/// <param name="outputNameCode">諸口コード(0:正式得意先,1:諸口得意先)</param>
		/// <param name="businessTypeCode">業種コード</param>
		/// <param name="businessTypeName">業種名称</param>
		/// <param name="salesAreaCode">販売エリアコード(地区コード)</param>
		/// <param name="salesAreaName">販売エリア名称</param>
		/// <param name="salesInputCode">売上入力者コード(入力担当者)</param>
		/// <param name="salesInputName">売上入力者名称</param>
		/// <param name="frontEmployeeCd">受付従業員コード(受付担当者)</param>
		/// <param name="frontEmployeeNm">受付従業員名称</param>
		/// <param name="salesEmployeeCd">販売従業員コード(計上担当者)</param>
		/// <param name="salesEmployeeNm">販売従業員名称</param>
		/// <param name="consTaxLayMethod">消費税転嫁方式(0:伝票単位1:明細単位2:請求親 3:請求子 9:非課税)</param>
		/// <param name="consTaxRate">消費税税率(変更2007/8/22(型,桁) 塩原)</param>
		/// <param name="fractionProcCd">端数処理区分(1:切捨て,2:四捨五入,3:切上げ　（消費税）)</param>
		/// <param name="autoDepositCd">自動入金区分(0:通常入金,1:自動入金)</param>
		/// <param name="autoDepoSlipNum">自動入金伝票番号(自動入金時の入金伝票番号)</param>
		/// <param name="slipAddressDiv">伝票住所区分(1:得意先,2:納入先)</param>
		/// <param name="addresseeCode">納品先コード</param>
		/// <param name="addresseeName">納品先名称</param>
		/// <param name="addresseeName2">納品先名称2(追加(登録漏れ) 塩原)</param>
		/// <param name="addresseePostNo">納品先郵便番号(伝票住所区分に従う内容)</param>
		/// <param name="addresseeAddr1">納品先住所1(都道府県市区郡・町村・字)(伝票住所区分に従う内容)</param>
		/// <param name="addresseeAddr2">納品先住所2(丁目)(伝票住所区分に従う内容)</param>
		/// <param name="addresseeAddr3">納品先住所3(番地)(伝票住所区分に従う内容)</param>
		/// <param name="addresseeAddr4">納品先住所4(アパート名称)(伝票住所区分に従う内容)</param>
		/// <param name="addresseeTelNo">納品先電話番号(伝票住所区分に従う内容)</param>
		/// <param name="addresseeFaxNo">納品先FAX番号(伝票住所区分に従う内容)</param>
		/// <param name="partySaleSlipNum">相手先伝票番号(得意先注文番号)</param>
		/// <param name="slipNote">伝票備考</param>
		/// <param name="slipNote2">伝票備考２</param>
		/// <param name="retGoodsReasonDiv">返品理由コード</param>
		/// <param name="retGoodsReason">返品理由</param>
		/// <param name="detailRowCount">明細行数(伝票内の明細の行数（諸費用明細は除く）)</param>
		/// <param name="deliveredGoodsDiv">納品区分(例) 1:配達,2:店頭渡し,3:直送,…)</param>
		/// <param name="deliveredGoodsDivNm">納品区分名称</param>
		/// <param name="reconcileFlag">消込フラグ(0:残あり 1:残無し　（受注、出荷にて使用）)</param>
		/// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID(売上形式とセットで伝票タイプ管理マスタを参照)</param>
		/// <param name="completeCd">一式伝票区分(0:通常伝票,1:一式伝票)</param>
		/// <param name="claimType">請求先区分(官庁請求区分（0:一般　1:官庁標準　2:官庁伝票）)</param>
		/// <param name="salesPriceFracProcCd">売上金額端数処理区分(1:切捨て,2:四捨五入,3:切上げ　（売上明細データの金額用）)</param>
		/// <param name="listPricePrintDiv">定価印刷区分</param>
		/// <param name="eraNameDispCd1">元号表示区分１(通常　　0:西暦　1:和暦)</param>
		/// <param name="acceptAnOrderNo">受注番号</param>
		/// <param name="commonSeqNo">共通通番</param>
		/// <param name="salesSlipDtlNum">売上明細通番</param>
		/// <param name="acptAnOdrStatusSrc">受注ステータス（元）(10:見積,20:受注,30:売上,40:出荷)</param>
		/// <param name="salesSlipDtlNumSrc">売上明細通番（元）(計上時の元データ明細通番をセット)</param>
		/// <param name="supplierFormalSync">仕入形式（同時）(0:仕入,1:入荷)</param>
		/// <param name="stockSlipDtlNumSync">仕入明細通番（同時）(同時計上時の仕入明細通番をセット)</param>
		/// <param name="salesSlipCdDtl">売上伝票区分（明細）(0:売上,1:返品,2:値引,3:注釈,4:小計)</param>
		/// <param name="orderNumber">発注番号(売上形式＝"出荷"の時にセット（発注の計上）)</param>
		/// <param name="stockMngExistCd">在庫管理有無区分(0:在庫管理しない,1:在庫管理する)</param>
		/// <param name="deliGdsCmpltDueDate">納品完了予定日(YYYYMMDD)</param>
		/// <param name="goodsKindCode">商品属性(0:純正 1:その他)</param>
		/// <param name="goodsMakerCd">商品メーカーコード(ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる)</param>
		/// <param name="makerName">メーカー名称</param>
		/// <param name="goodsNo">商品番号</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="goodsShortName">商品名略称</param>
		/// <param name="goodsSetDivCd">セット商品区分(0:通常,1:親商品,2:子商品)</param>
		/// <param name="largeGoodsGanreCode">商品区分グループコード(旧：商品大分類コード)</param>
		/// <param name="largeGoodsGanreName">商品区分グループ名称(旧：商品大分類名称)</param>
		/// <param name="mediumGoodsGanreCode">商品区分コード(旧：商品中分類コード)</param>
		/// <param name="mediumGoodsGanreName">商品区分名称(旧：商品中分類名称)</param>
		/// <param name="detailGoodsGanreCode">商品区分詳細コード</param>
		/// <param name="detailGoodsGanreName">商品区分詳細名称</param>
		/// <param name="bLGoodsCode">BL商品コード</param>
		/// <param name="bLGoodsFullName">BL商品コード名称（全角）</param>
		/// <param name="enterpriseGanreCode">自社分類コード</param>
		/// <param name="enterpriseGanreName">自社分類名称</param>
		/// <param name="warehouseCode">倉庫コード</param>
		/// <param name="warehouseName">倉庫名称</param>
		/// <param name="warehouseShelfNo">倉庫棚番</param>
		/// <param name="salesOrderDivCd">売上在庫取寄せ区分(0:取寄せ,1:在庫)</param>
		/// <param name="openPriceDiv">オープン価格区分(0:通常／1:オープン価格)</param>
		/// <param name="unitCode">単位コード</param>
		/// <param name="unitName">単位名称</param>
		/// <param name="goodsRateRank">商品掛率ランク(商品の掛率用ランク)</param>
		/// <param name="custRateGrpCode">得意先掛率グループコード</param>
		/// <param name="suppRateGrpCode">仕入先掛率グループコード</param>
		/// <param name="listPriceRate">定価率</param>
		/// <param name="rateSectPriceUnPrc">掛率設定拠点（定価）(0:全社設定, その他:拠点コード)</param>
		/// <param name="rateDivLPrice">掛率設定区分（定価）(A1,A2,…)</param>
		/// <param name="unPrcCalcCdLPrice">単価算出区分（定価）(1:掛率,2:原価ＵＰ率,3:粗利率)</param>
		/// <param name="priceCdLPrice">価格区分（定価）(0:定価,1:登録販売店価格,… 9:ユーザー定価)</param>
		/// <param name="stdUnPrcLPrice">基準単価（定価）</param>
		/// <param name="fracProcUnitLPrice">端数処理単位（定価）</param>
		/// <param name="fracProcLPrice">端数処理（定価）(1：切捨て,2：四捨五入,3:切上げ)</param>
		/// <param name="listPriceTaxIncFl">定価（税込，浮動）(税抜き)</param>
		/// <param name="listPriceTaxExcFl">定価（税抜，浮動）(税込み)</param>
		/// <param name="listPriceChngCd">定価変更区分(0:変更なし,1:変更あり　（定価手入力）)</param>
		/// <param name="salesRate">売価率</param>
		/// <param name="rateSectSalUnPrc">掛率設定拠点（売上単価）(0:全社設定, その他:拠点コード)</param>
		/// <param name="rateDivSalUnPrc">掛率設定区分（売上単価）(A1,A2,…)</param>
		/// <param name="unPrcCalcCdSalUnPrc">単価算出区分（売上単価）(1:掛率,2:原価ＵＰ率,3:粗利率)</param>
		/// <param name="priceCdSalUnPrc">価格区分（売上単価）(0:定価,1:登録販売店価格,…)</param>
		/// <param name="stdUnPrcSalUnPrc">基準単価（売上単価）</param>
		/// <param name="fracProcUnitSalUnPrc">端数処理単位（売上単価）</param>
		/// <param name="fracProcSalUnPrc">端数処理（売上単価）(1：切捨て,2：四捨五入,3:切上げ)</param>
		/// <param name="salesUnPrcTaxIncFl">売上単価（税込，浮動）</param>
		/// <param name="salesUnPrcTaxExcFl">売上単価（税抜，浮動）</param>
		/// <param name="salesUnPrcChngCd">売上単価変更区分(0:変更なし,1:変更あり　（売上単価手入力）)</param>
		/// <param name="costRate">原価率</param>
		/// <param name="rateSectCstUnPrc">掛率設定拠点（原価単価）(0:全社設定, その他:拠点コード)</param>
		/// <param name="rateDivUnCst">掛率設定区分（原価単価）(A7,A8,…)</param>
		/// <param name="unPrcCalcCdUnCst">単価算出区分（原価単価）(1:掛率,2:原価ＵＰ率,3:粗利率)</param>
		/// <param name="priceCdUnCst">価格区分（原価単価）(0:定価,1:登録販売店価格,…)</param>
		/// <param name="stdUnPrcUnCst">基準単価（原価単価）</param>
		/// <param name="fracProcUnitUnCst">端数処理単位（原価単価）</param>
		/// <param name="fracProcUnCst">端数処理（原価単価）(1：切捨て,2：四捨五入,3:切上げ)</param>
		/// <param name="salesUnitCost">原価単価</param>
		/// <param name="salesUnitCostChngDiv">原価単価変更区分(0:変更なし,1:変更あり　（原価単価手入力）)</param>
		/// <param name="rateBLGoodsCode">BL商品コード（掛率）(掛率算出時に使用したBLコード（商品検索結果）)</param>
		/// <param name="rateBLGoodsName">BL商品コード名称（掛率）(掛率算出時に使用したBLコード名称（商品検索結果）)</param>
		/// <param name="bargainCd">特売区分コード</param>
		/// <param name="bargainNm">特売区分名称</param>
		/// <param name="shipmentCnt">出荷数(売上：売上数、受注：受注数、出荷：出荷数、見積：見積数)</param>
		/// <param name="salesMoneyTaxInc">売上金額（税込み）</param>
		/// <param name="salesMoneyTaxExc">売上金額（税抜き）</param>
		/// <param name="cost">原価</param>
		/// <param name="grsProfitChkDiv">粗利チェック区分(0:正常,1:原価割れ,2:利益の上げ過ぎ)</param>
		/// <param name="salesGoodsCd">売上商品区分(0:商品,1:商品外,2:消費税調整,3:残高調整,4:売掛用消費税調整,5:売掛用残高調整,10:売掛用消費税調整(自動),11:相殺,12:相殺(自動))</param>
		/// <param name="salsePriceConsTax">売上金額消費税額(売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる)</param>
		/// <param name="taxationDivCd">課税区分(0:課税,1:非課税,2:課税（内税）)</param>
		/// <param name="partySlipNumDtl">相手先伝票番号（明細）(得意先注文番号)</param>
		/// <param name="dtlNote">明細備考</param>
		/// <param name="supplierCd">仕入先コード</param>
		/// <param name="supplierSnm">仕入先略称</param>
		/// <param name="slipMemo1">伝票メモ１</param>
		/// <param name="slipMemo2">伝票メモ２</param>
		/// <param name="slipMemo3">伝票メモ３</param>
		/// <param name="slipMemo4">伝票メモ４</param>
		/// <param name="slipMemo5">伝票メモ５</param>
		/// <param name="slipMemo6">伝票メモ６</param>
		/// <param name="insideMemo1">社内メモ１</param>
		/// <param name="insideMemo2">社内メモ２</param>
		/// <param name="insideMemo3">社内メモ３</param>
		/// <param name="insideMemo4">社内メモ４</param>
		/// <param name="insideMemo5">社内メモ５</param>
		/// <param name="insideMemo6">社内メモ６</param>
		/// <param name="bfListPrice">変更前定価(税抜き、掛率算出結果)</param>
		/// <param name="bfSalesUnitPrice">変更前売価(税抜き、掛率算出結果)</param>
		/// <param name="bfUnitCost">変更前原価(税抜き、掛率算出結果)</param>
		/// <param name="prtGoodsNo">印刷用商品番号</param>
		/// <param name="prtGoodsName">印刷用商品名称</param>
		/// <param name="prtGoodsMakerCd">印刷用商品メーカーコード</param>
		/// <param name="prtGoodsMakerNm">印刷用商品メーカー名称</param>
		/// <param name="supplierSlipCd">仕入伝票区分</param>
		/// <param name="totalAmountDispWayCd">総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
		/// <param name="ttlAmntDispRateApy">総額表示掛率適用区分(0：基準価格(税込)×掛率, 1:基準価格(税抜)×掛率)</param>
		/// <param name="confirmedDiv">確認区分</param>
		/// <param name="nTimeCalcStDate">次回勘定開始日(01～31まで（省略可能）)</param>
		/// <param name="totalDay">締日(DD)</param>
		/// <param name="dtlRelationGuid">明細関連付けGUID</param>
		/// <param name="acptAnOdrRemainCnt">受注残数(受注数量＋受注調整数－出荷数)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="resultsAddUpSecNm">実績計上拠点名称</param>
		/// <param name="outputName">諸口名称</param>
		/// <param name="bLGoodsName">BL商品コード名称</param>
		/// <returns>SalesTempクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTempクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesTemp(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 acptAnOdrStatus,string sectionCode,Int32 subSectionCode,Int32 minSectionCode,Int32 debitNoteDiv,Int32 debitNLnkAcptAnOdr,Int32 salesSlipCd,Int32 accRecDivCd,string salesInpSecCd,string demandAddUpSecCd,string resultsAddUpSecCd,string updateSecCd,DateTime searchSlipDate,DateTime shipmentDay,DateTime salesDate,DateTime addUpADate,Int32 delayPaymentDiv,Int32 claimCode,string claimSnm,Int32 customerCode,string customerName,string customerName2,string customerSnm,string honorificTitle,Int32 outputNameCode,Int32 businessTypeCode,string businessTypeName,Int32 salesAreaCode,string salesAreaName,string salesInputCode,string salesInputName,string frontEmployeeCd,string frontEmployeeNm,string salesEmployeeCd,string salesEmployeeNm,Int32 consTaxLayMethod,Double consTaxRate,Int32 fractionProcCd,Int32 autoDepositCd,Int32 autoDepoSlipNum,Int32 slipAddressDiv,Int32 addresseeCode,string addresseeName,string addresseeName2,string addresseePostNo,string addresseeAddr1,Int32 addresseeAddr2,string addresseeAddr3,string addresseeAddr4,string addresseeTelNo,string addresseeFaxNo,string partySaleSlipNum,string slipNote,string slipNote2,Int32 retGoodsReasonDiv,string retGoodsReason,Int32 detailRowCount,Int32 deliveredGoodsDiv,string deliveredGoodsDivNm,Int32 reconcileFlag,string slipPrtSetPaperId,Int32 completeCd,Int32 claimType,Int32 salesPriceFracProcCd,Int32 listPricePrintDiv,Int32 eraNameDispCd1,Int32 acceptAnOrderNo,Int64 commonSeqNo,Int64 salesSlipDtlNum,Int32 acptAnOdrStatusSrc,Int64 salesSlipDtlNumSrc,Int32 supplierFormalSync,Int64 stockSlipDtlNumSync,Int32 salesSlipCdDtl,string orderNumber,Int32 stockMngExistCd,DateTime deliGdsCmpltDueDate,Int32 goodsKindCode,Int32 goodsMakerCd,string makerName,string goodsNo,string goodsName,string goodsShortName,Int32 goodsSetDivCd,string largeGoodsGanreCode,string largeGoodsGanreName,string mediumGoodsGanreCode,string mediumGoodsGanreName,string detailGoodsGanreCode,string detailGoodsGanreName,Int32 bLGoodsCode,string bLGoodsFullName,Int32 enterpriseGanreCode,string enterpriseGanreName,string warehouseCode,string warehouseName,string warehouseShelfNo,Int32 salesOrderDivCd,Int32 openPriceDiv,Int32 unitCode,string unitName,string goodsRateRank,Int32 custRateGrpCode,Int32 suppRateGrpCode,Double listPriceRate,string rateSectPriceUnPrc,string rateDivLPrice,Int32 unPrcCalcCdLPrice,Int32 priceCdLPrice,Double stdUnPrcLPrice,Double fracProcUnitLPrice,Int32 fracProcLPrice,Double listPriceTaxIncFl,Double listPriceTaxExcFl,Int32 listPriceChngCd,Double salesRate,string rateSectSalUnPrc,string rateDivSalUnPrc,Int32 unPrcCalcCdSalUnPrc,Int32 priceCdSalUnPrc,Double stdUnPrcSalUnPrc,Double fracProcUnitSalUnPrc,Int32 fracProcSalUnPrc,Double salesUnPrcTaxIncFl,Double salesUnPrcTaxExcFl,Int32 salesUnPrcChngCd,Double costRate,string rateSectCstUnPrc,string rateDivUnCst,Int32 unPrcCalcCdUnCst,Int32 priceCdUnCst,Double stdUnPrcUnCst,Double fracProcUnitUnCst,Int32 fracProcUnCst,Double salesUnitCost,Int32 salesUnitCostChngDiv,Int32 rateBLGoodsCode,string rateBLGoodsName,Int32 bargainCd,string bargainNm,Double shipmentCnt,Int64 salesMoneyTaxInc,Int64 salesMoneyTaxExc,Int64 cost,Int32 grsProfitChkDiv,Int32 salesGoodsCd,Int64 salsePriceConsTax,Int32 taxationDivCd,string partySlipNumDtl,string dtlNote,Int32 supplierCd,string supplierSnm,string slipMemo1,string slipMemo2,string slipMemo3,string slipMemo4,string slipMemo5,string slipMemo6,string insideMemo1,string insideMemo2,string insideMemo3,string insideMemo4,string insideMemo5,string insideMemo6,Double bfListPrice,Double bfSalesUnitPrice,Double bfUnitCost,string prtGoodsNo,string prtGoodsName,Int32 prtGoodsMakerCd,string prtGoodsMakerNm,Int32 supplierSlipCd,Int32 totalAmountDispWayCd,Int32 ttlAmntDispRateApy,bool confirmedDiv,Int32 nTimeCalcStDate,Int32 totalDay,Guid dtlRelationGuid,Double acptAnOdrRemainCnt,string enterpriseName,string updEmployeeName,string resultsAddUpSecNm,string outputName,string bLGoodsName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._sectionCode = sectionCode;
			this._subSectionCode = subSectionCode;
			this._minSectionCode = minSectionCode;
			this._debitNoteDiv = debitNoteDiv;
			this._debitNLnkAcptAnOdr = debitNLnkAcptAnOdr;
			this._salesSlipCd = salesSlipCd;
			this._accRecDivCd = accRecDivCd;
			this._salesInpSecCd = salesInpSecCd;
			this._demandAddUpSecCd = demandAddUpSecCd;
			this._resultsAddUpSecCd = resultsAddUpSecCd;
			this._updateSecCd = updateSecCd;
			this.SearchSlipDate = searchSlipDate;
			this.ShipmentDay = shipmentDay;
			this.SalesDate = salesDate;
			this.AddUpADate = addUpADate;
			this._delayPaymentDiv = delayPaymentDiv;
			this._claimCode = claimCode;
			this._claimSnm = claimSnm;
			this._customerCode = customerCode;
			this._customerName = customerName;
			this._customerName2 = customerName2;
			this._customerSnm = customerSnm;
			this._honorificTitle = honorificTitle;
			this._outputNameCode = outputNameCode;
			this._businessTypeCode = businessTypeCode;
			this._businessTypeName = businessTypeName;
			this._salesAreaCode = salesAreaCode;
			this._salesAreaName = salesAreaName;
			this._salesInputCode = salesInputCode;
			this._salesInputName = salesInputName;
			this._frontEmployeeCd = frontEmployeeCd;
			this._frontEmployeeNm = frontEmployeeNm;
			this._salesEmployeeCd = salesEmployeeCd;
			this._salesEmployeeNm = salesEmployeeNm;
			this._consTaxLayMethod = consTaxLayMethod;
			this._consTaxRate = consTaxRate;
			this._fractionProcCd = fractionProcCd;
			this._autoDepositCd = autoDepositCd;
			this._autoDepoSlipNum = autoDepoSlipNum;
			this._slipAddressDiv = slipAddressDiv;
			this._addresseeCode = addresseeCode;
			this._addresseeName = addresseeName;
			this._addresseeName2 = addresseeName2;
			this._addresseePostNo = addresseePostNo;
			this._addresseeAddr1 = addresseeAddr1;
			this._addresseeAddr2 = addresseeAddr2;
			this._addresseeAddr3 = addresseeAddr3;
			this._addresseeAddr4 = addresseeAddr4;
			this._addresseeTelNo = addresseeTelNo;
			this._addresseeFaxNo = addresseeFaxNo;
			this._partySaleSlipNum = partySaleSlipNum;
			this._slipNote = slipNote;
			this._slipNote2 = slipNote2;
			this._retGoodsReasonDiv = retGoodsReasonDiv;
			this._retGoodsReason = retGoodsReason;
			this._detailRowCount = detailRowCount;
			this._deliveredGoodsDiv = deliveredGoodsDiv;
			this._deliveredGoodsDivNm = deliveredGoodsDivNm;
			this._reconcileFlag = reconcileFlag;
			this._slipPrtSetPaperId = slipPrtSetPaperId;
			this._completeCd = completeCd;
			this._claimType = claimType;
			this._salesPriceFracProcCd = salesPriceFracProcCd;
			this._listPricePrintDiv = listPricePrintDiv;
			this._eraNameDispCd1 = eraNameDispCd1;
			this._acceptAnOrderNo = acceptAnOrderNo;
			this._commonSeqNo = commonSeqNo;
			this._salesSlipDtlNum = salesSlipDtlNum;
			this._acptAnOdrStatusSrc = acptAnOdrStatusSrc;
			this._salesSlipDtlNumSrc = salesSlipDtlNumSrc;
			this._supplierFormalSync = supplierFormalSync;
			this._stockSlipDtlNumSync = stockSlipDtlNumSync;
			this._salesSlipCdDtl = salesSlipCdDtl;
			this._orderNumber = orderNumber;
			this._stockMngExistCd = stockMngExistCd;
			this.DeliGdsCmpltDueDate = deliGdsCmpltDueDate;
			this._goodsKindCode = goodsKindCode;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._goodsNo = goodsNo;
			this._goodsName = goodsName;
			this._goodsShortName = goodsShortName;
			this._goodsSetDivCd = goodsSetDivCd;
			this._largeGoodsGanreCode = largeGoodsGanreCode;
			this._largeGoodsGanreName = largeGoodsGanreName;
			this._mediumGoodsGanreCode = mediumGoodsGanreCode;
			this._mediumGoodsGanreName = mediumGoodsGanreName;
			this._detailGoodsGanreCode = detailGoodsGanreCode;
			this._detailGoodsGanreName = detailGoodsGanreName;
			this._bLGoodsCode = bLGoodsCode;
			this._bLGoodsFullName = bLGoodsFullName;
			this._enterpriseGanreCode = enterpriseGanreCode;
			this._enterpriseGanreName = enterpriseGanreName;
			this._warehouseCode = warehouseCode;
			this._warehouseName = warehouseName;
			this._warehouseShelfNo = warehouseShelfNo;
			this._salesOrderDivCd = salesOrderDivCd;
			this._openPriceDiv = openPriceDiv;
			this._unitCode = unitCode;
			this._unitName = unitName;
			this._goodsRateRank = goodsRateRank;
			this._custRateGrpCode = custRateGrpCode;
			this._suppRateGrpCode = suppRateGrpCode;
			this._listPriceRate = listPriceRate;
			this._rateSectPriceUnPrc = rateSectPriceUnPrc;
			this._rateDivLPrice = rateDivLPrice;
			this._unPrcCalcCdLPrice = unPrcCalcCdLPrice;
			this._priceCdLPrice = priceCdLPrice;
			this._stdUnPrcLPrice = stdUnPrcLPrice;
			this._fracProcUnitLPrice = fracProcUnitLPrice;
			this._fracProcLPrice = fracProcLPrice;
			this._listPriceTaxIncFl = listPriceTaxIncFl;
			this._listPriceTaxExcFl = listPriceTaxExcFl;
			this._listPriceChngCd = listPriceChngCd;
			this._salesRate = salesRate;
			this._rateSectSalUnPrc = rateSectSalUnPrc;
			this._rateDivSalUnPrc = rateDivSalUnPrc;
			this._unPrcCalcCdSalUnPrc = unPrcCalcCdSalUnPrc;
			this._priceCdSalUnPrc = priceCdSalUnPrc;
			this._stdUnPrcSalUnPrc = stdUnPrcSalUnPrc;
			this._fracProcUnitSalUnPrc = fracProcUnitSalUnPrc;
			this._fracProcSalUnPrc = fracProcSalUnPrc;
			this._salesUnPrcTaxIncFl = salesUnPrcTaxIncFl;
			this._salesUnPrcTaxExcFl = salesUnPrcTaxExcFl;
			this._salesUnPrcChngCd = salesUnPrcChngCd;
			this._costRate = costRate;
			this._rateSectCstUnPrc = rateSectCstUnPrc;
			this._rateDivUnCst = rateDivUnCst;
			this._unPrcCalcCdUnCst = unPrcCalcCdUnCst;
			this._priceCdUnCst = priceCdUnCst;
			this._stdUnPrcUnCst = stdUnPrcUnCst;
			this._fracProcUnitUnCst = fracProcUnitUnCst;
			this._fracProcUnCst = fracProcUnCst;
			this._salesUnitCost = salesUnitCost;
			this._salesUnitCostChngDiv = salesUnitCostChngDiv;
			this._rateBLGoodsCode = rateBLGoodsCode;
			this._rateBLGoodsName = rateBLGoodsName;
			this._bargainCd = bargainCd;
			this._bargainNm = bargainNm;
			this._shipmentCnt = shipmentCnt;
			this._salesMoneyTaxInc = salesMoneyTaxInc;
			this._salesMoneyTaxExc = salesMoneyTaxExc;
			this._cost = cost;
			this._grsProfitChkDiv = grsProfitChkDiv;
			this._salesGoodsCd = salesGoodsCd;
			this._salsePriceConsTax = salsePriceConsTax;
			this._taxationDivCd = taxationDivCd;
			this._partySlipNumDtl = partySlipNumDtl;
			this._dtlNote = dtlNote;
			this._supplierCd = supplierCd;
			this._supplierSnm = supplierSnm;
			this._slipMemo1 = slipMemo1;
			this._slipMemo2 = slipMemo2;
			this._slipMemo3 = slipMemo3;
			this._slipMemo4 = slipMemo4;
			this._slipMemo5 = slipMemo5;
			this._slipMemo6 = slipMemo6;
			this._insideMemo1 = insideMemo1;
			this._insideMemo2 = insideMemo2;
			this._insideMemo3 = insideMemo3;
			this._insideMemo4 = insideMemo4;
			this._insideMemo5 = insideMemo5;
			this._insideMemo6 = insideMemo6;
			this._bfListPrice = bfListPrice;
			this._bfSalesUnitPrice = bfSalesUnitPrice;
			this._bfUnitCost = bfUnitCost;
			this._prtGoodsNo = prtGoodsNo;
			this._prtGoodsName = prtGoodsName;
			this._prtGoodsMakerCd = prtGoodsMakerCd;
			this._prtGoodsMakerNm = prtGoodsMakerNm;
			this._supplierSlipCd = supplierSlipCd;
			this._totalAmountDispWayCd = totalAmountDispWayCd;
			this._ttlAmntDispRateApy = ttlAmntDispRateApy;
			this._confirmedDiv = confirmedDiv;
			this._nTimeCalcStDate = nTimeCalcStDate;
			this._totalDay = totalDay;
			this._dtlRelationGuid = dtlRelationGuid;
			this._acptAnOdrRemainCnt = acptAnOdrRemainCnt;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._resultsAddUpSecNm = resultsAddUpSecNm;
			this._outputName = outputName;
			this._bLGoodsName = bLGoodsName;

		}

		/// <summary>
		/// 売上データ（仕入同時計上）複製処理
		/// </summary>
		/// <returns>SalesTempクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSalesTempクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesTemp Clone()
		{
			return new SalesTemp(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._acptAnOdrStatus,this._sectionCode,this._subSectionCode,this._minSectionCode,this._debitNoteDiv,this._debitNLnkAcptAnOdr,this._salesSlipCd,this._accRecDivCd,this._salesInpSecCd,this._demandAddUpSecCd,this._resultsAddUpSecCd,this._updateSecCd,this._searchSlipDate,this._shipmentDay,this._salesDate,this._addUpADate,this._delayPaymentDiv,this._claimCode,this._claimSnm,this._customerCode,this._customerName,this._customerName2,this._customerSnm,this._honorificTitle,this._outputNameCode,this._businessTypeCode,this._businessTypeName,this._salesAreaCode,this._salesAreaName,this._salesInputCode,this._salesInputName,this._frontEmployeeCd,this._frontEmployeeNm,this._salesEmployeeCd,this._salesEmployeeNm,this._consTaxLayMethod,this._consTaxRate,this._fractionProcCd,this._autoDepositCd,this._autoDepoSlipNum,this._slipAddressDiv,this._addresseeCode,this._addresseeName,this._addresseeName2,this._addresseePostNo,this._addresseeAddr1,this._addresseeAddr2,this._addresseeAddr3,this._addresseeAddr4,this._addresseeTelNo,this._addresseeFaxNo,this._partySaleSlipNum,this._slipNote,this._slipNote2,this._retGoodsReasonDiv,this._retGoodsReason,this._detailRowCount,this._deliveredGoodsDiv,this._deliveredGoodsDivNm,this._reconcileFlag,this._slipPrtSetPaperId,this._completeCd,this._claimType,this._salesPriceFracProcCd,this._listPricePrintDiv,this._eraNameDispCd1,this._acceptAnOrderNo,this._commonSeqNo,this._salesSlipDtlNum,this._acptAnOdrStatusSrc,this._salesSlipDtlNumSrc,this._supplierFormalSync,this._stockSlipDtlNumSync,this._salesSlipCdDtl,this._orderNumber,this._stockMngExistCd,this._deliGdsCmpltDueDate,this._goodsKindCode,this._goodsMakerCd,this._makerName,this._goodsNo,this._goodsName,this._goodsShortName,this._goodsSetDivCd,this._largeGoodsGanreCode,this._largeGoodsGanreName,this._mediumGoodsGanreCode,this._mediumGoodsGanreName,this._detailGoodsGanreCode,this._detailGoodsGanreName,this._bLGoodsCode,this._bLGoodsFullName,this._enterpriseGanreCode,this._enterpriseGanreName,this._warehouseCode,this._warehouseName,this._warehouseShelfNo,this._salesOrderDivCd,this._openPriceDiv,this._unitCode,this._unitName,this._goodsRateRank,this._custRateGrpCode,this._suppRateGrpCode,this._listPriceRate,this._rateSectPriceUnPrc,this._rateDivLPrice,this._unPrcCalcCdLPrice,this._priceCdLPrice,this._stdUnPrcLPrice,this._fracProcUnitLPrice,this._fracProcLPrice,this._listPriceTaxIncFl,this._listPriceTaxExcFl,this._listPriceChngCd,this._salesRate,this._rateSectSalUnPrc,this._rateDivSalUnPrc,this._unPrcCalcCdSalUnPrc,this._priceCdSalUnPrc,this._stdUnPrcSalUnPrc,this._fracProcUnitSalUnPrc,this._fracProcSalUnPrc,this._salesUnPrcTaxIncFl,this._salesUnPrcTaxExcFl,this._salesUnPrcChngCd,this._costRate,this._rateSectCstUnPrc,this._rateDivUnCst,this._unPrcCalcCdUnCst,this._priceCdUnCst,this._stdUnPrcUnCst,this._fracProcUnitUnCst,this._fracProcUnCst,this._salesUnitCost,this._salesUnitCostChngDiv,this._rateBLGoodsCode,this._rateBLGoodsName,this._bargainCd,this._bargainNm,this._shipmentCnt,this._salesMoneyTaxInc,this._salesMoneyTaxExc,this._cost,this._grsProfitChkDiv,this._salesGoodsCd,this._salsePriceConsTax,this._taxationDivCd,this._partySlipNumDtl,this._dtlNote,this._supplierCd,this._supplierSnm,this._slipMemo1,this._slipMemo2,this._slipMemo3,this._slipMemo4,this._slipMemo5,this._slipMemo6,this._insideMemo1,this._insideMemo2,this._insideMemo3,this._insideMemo4,this._insideMemo5,this._insideMemo6,this._bfListPrice,this._bfSalesUnitPrice,this._bfUnitCost,this._prtGoodsNo,this._prtGoodsName,this._prtGoodsMakerCd,this._prtGoodsMakerNm,this._supplierSlipCd,this._totalAmountDispWayCd,this._ttlAmntDispRateApy,this._confirmedDiv,this._nTimeCalcStDate,this._totalDay,this._dtlRelationGuid,this._acptAnOdrRemainCnt,this._enterpriseName,this._updEmployeeName,this._resultsAddUpSecNm,this._outputName,this._bLGoodsName);
		}

		/// <summary>
		/// 売上データ（仕入同時計上）比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesTempクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTempクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SalesTemp target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
				 && (this.SectionCode == target.SectionCode)
				 && (this.SubSectionCode == target.SubSectionCode)
				 && (this.MinSectionCode == target.MinSectionCode)
				 && (this.DebitNoteDiv == target.DebitNoteDiv)
				 && (this.DebitNLnkAcptAnOdr == target.DebitNLnkAcptAnOdr)
				 && (this.SalesSlipCd == target.SalesSlipCd)
				 && (this.AccRecDivCd == target.AccRecDivCd)
				 && (this.SalesInpSecCd == target.SalesInpSecCd)
				 && (this.DemandAddUpSecCd == target.DemandAddUpSecCd)
				 && (this.ResultsAddUpSecCd == target.ResultsAddUpSecCd)
				 && (this.UpdateSecCd == target.UpdateSecCd)
				 && (this.SearchSlipDate == target.SearchSlipDate)
				 && (this.ShipmentDay == target.ShipmentDay)
				 && (this.SalesDate == target.SalesDate)
				 && (this.AddUpADate == target.AddUpADate)
				 && (this.DelayPaymentDiv == target.DelayPaymentDiv)
				 && (this.ClaimCode == target.ClaimCode)
				 && (this.ClaimSnm == target.ClaimSnm)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustomerName == target.CustomerName)
				 && (this.CustomerName2 == target.CustomerName2)
				 && (this.CustomerSnm == target.CustomerSnm)
				 && (this.HonorificTitle == target.HonorificTitle)
				 && (this.OutputNameCode == target.OutputNameCode)
				 && (this.BusinessTypeCode == target.BusinessTypeCode)
				 && (this.BusinessTypeName == target.BusinessTypeName)
				 && (this.SalesAreaCode == target.SalesAreaCode)
				 && (this.SalesAreaName == target.SalesAreaName)
				 && (this.SalesInputCode == target.SalesInputCode)
				 && (this.SalesInputName == target.SalesInputName)
				 && (this.FrontEmployeeCd == target.FrontEmployeeCd)
				 && (this.FrontEmployeeNm == target.FrontEmployeeNm)
				 && (this.SalesEmployeeCd == target.SalesEmployeeCd)
				 && (this.SalesEmployeeNm == target.SalesEmployeeNm)
				 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
				 && (this.ConsTaxRate == target.ConsTaxRate)
				 && (this.FractionProcCd == target.FractionProcCd)
				 && (this.AutoDepositCd == target.AutoDepositCd)
				 && (this.AutoDepoSlipNum == target.AutoDepoSlipNum)
				 && (this.SlipAddressDiv == target.SlipAddressDiv)
				 && (this.AddresseeCode == target.AddresseeCode)
				 && (this.AddresseeName == target.AddresseeName)
				 && (this.AddresseeName2 == target.AddresseeName2)
				 && (this.AddresseePostNo == target.AddresseePostNo)
				 && (this.AddresseeAddr1 == target.AddresseeAddr1)
				 && (this.AddresseeAddr2 == target.AddresseeAddr2)
				 && (this.AddresseeAddr3 == target.AddresseeAddr3)
				 && (this.AddresseeAddr4 == target.AddresseeAddr4)
				 && (this.AddresseeTelNo == target.AddresseeTelNo)
				 && (this.AddresseeFaxNo == target.AddresseeFaxNo)
				 && (this.PartySaleSlipNum == target.PartySaleSlipNum)
				 && (this.SlipNote == target.SlipNote)
				 && (this.SlipNote2 == target.SlipNote2)
				 && (this.RetGoodsReasonDiv == target.RetGoodsReasonDiv)
				 && (this.RetGoodsReason == target.RetGoodsReason)
				 && (this.DetailRowCount == target.DetailRowCount)
				 && (this.DeliveredGoodsDiv == target.DeliveredGoodsDiv)
				 && (this.DeliveredGoodsDivNm == target.DeliveredGoodsDivNm)
				 && (this.ReconcileFlag == target.ReconcileFlag)
				 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
				 && (this.CompleteCd == target.CompleteCd)
				 && (this.ClaimType == target.ClaimType)
				 && (this.SalesPriceFracProcCd == target.SalesPriceFracProcCd)
				 && (this.ListPricePrintDiv == target.ListPricePrintDiv)
				 && (this.EraNameDispCd1 == target.EraNameDispCd1)
				 && (this.AcceptAnOrderNo == target.AcceptAnOrderNo)
				 && (this.CommonSeqNo == target.CommonSeqNo)
				 && (this.SalesSlipDtlNum == target.SalesSlipDtlNum)
				 && (this.AcptAnOdrStatusSrc == target.AcptAnOdrStatusSrc)
				 && (this.SalesSlipDtlNumSrc == target.SalesSlipDtlNumSrc)
				 && (this.SupplierFormalSync == target.SupplierFormalSync)
				 && (this.StockSlipDtlNumSync == target.StockSlipDtlNumSync)
				 && (this.SalesSlipCdDtl == target.SalesSlipCdDtl)
				 && (this.OrderNumber == target.OrderNumber)
				 && (this.StockMngExistCd == target.StockMngExistCd)
				 && (this.DeliGdsCmpltDueDate == target.DeliGdsCmpltDueDate)
				 && (this.GoodsKindCode == target.GoodsKindCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsName == target.GoodsName)
				 && (this.GoodsShortName == target.GoodsShortName)
				 && (this.GoodsSetDivCd == target.GoodsSetDivCd)
				 && (this.LargeGoodsGanreCode == target.LargeGoodsGanreCode)
				 && (this.LargeGoodsGanreName == target.LargeGoodsGanreName)
				 && (this.MediumGoodsGanreCode == target.MediumGoodsGanreCode)
				 && (this.MediumGoodsGanreName == target.MediumGoodsGanreName)
				 && (this.DetailGoodsGanreCode == target.DetailGoodsGanreCode)
				 && (this.DetailGoodsGanreName == target.DetailGoodsGanreName)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.BLGoodsFullName == target.BLGoodsFullName)
				 && (this.EnterpriseGanreCode == target.EnterpriseGanreCode)
				 && (this.EnterpriseGanreName == target.EnterpriseGanreName)
				 && (this.WarehouseCode == target.WarehouseCode)
				 && (this.WarehouseName == target.WarehouseName)
				 && (this.WarehouseShelfNo == target.WarehouseShelfNo)
				 && (this.SalesOrderDivCd == target.SalesOrderDivCd)
				 && (this.OpenPriceDiv == target.OpenPriceDiv)
				 && (this.UnitCode == target.UnitCode)
				 && (this.UnitName == target.UnitName)
				 && (this.GoodsRateRank == target.GoodsRateRank)
				 && (this.CustRateGrpCode == target.CustRateGrpCode)
				 && (this.SuppRateGrpCode == target.SuppRateGrpCode)
				 && (this.ListPriceRate == target.ListPriceRate)
				 && (this.RateSectPriceUnPrc == target.RateSectPriceUnPrc)
				 && (this.RateDivLPrice == target.RateDivLPrice)
				 && (this.UnPrcCalcCdLPrice == target.UnPrcCalcCdLPrice)
				 && (this.PriceCdLPrice == target.PriceCdLPrice)
				 && (this.StdUnPrcLPrice == target.StdUnPrcLPrice)
				 && (this.FracProcUnitLPrice == target.FracProcUnitLPrice)
				 && (this.FracProcLPrice == target.FracProcLPrice)
				 && (this.ListPriceTaxIncFl == target.ListPriceTaxIncFl)
				 && (this.ListPriceTaxExcFl == target.ListPriceTaxExcFl)
				 && (this.ListPriceChngCd == target.ListPriceChngCd)
				 && (this.SalesRate == target.SalesRate)
				 && (this.RateSectSalUnPrc == target.RateSectSalUnPrc)
				 && (this.RateDivSalUnPrc == target.RateDivSalUnPrc)
				 && (this.UnPrcCalcCdSalUnPrc == target.UnPrcCalcCdSalUnPrc)
				 && (this.PriceCdSalUnPrc == target.PriceCdSalUnPrc)
				 && (this.StdUnPrcSalUnPrc == target.StdUnPrcSalUnPrc)
				 && (this.FracProcUnitSalUnPrc == target.FracProcUnitSalUnPrc)
				 && (this.FracProcSalUnPrc == target.FracProcSalUnPrc)
				 && (this.SalesUnPrcTaxIncFl == target.SalesUnPrcTaxIncFl)
				 && (this.SalesUnPrcTaxExcFl == target.SalesUnPrcTaxExcFl)
				 && (this.SalesUnPrcChngCd == target.SalesUnPrcChngCd)
				 && (this.CostRate == target.CostRate)
				 && (this.RateSectCstUnPrc == target.RateSectCstUnPrc)
				 && (this.RateDivUnCst == target.RateDivUnCst)
				 && (this.UnPrcCalcCdUnCst == target.UnPrcCalcCdUnCst)
				 && (this.PriceCdUnCst == target.PriceCdUnCst)
				 && (this.StdUnPrcUnCst == target.StdUnPrcUnCst)
				 && (this.FracProcUnitUnCst == target.FracProcUnitUnCst)
				 && (this.FracProcUnCst == target.FracProcUnCst)
				 && (this.SalesUnitCost == target.SalesUnitCost)
				 && (this.SalesUnitCostChngDiv == target.SalesUnitCostChngDiv)
				 && (this.RateBLGoodsCode == target.RateBLGoodsCode)
				 && (this.RateBLGoodsName == target.RateBLGoodsName)
				 && (this.BargainCd == target.BargainCd)
				 && (this.BargainNm == target.BargainNm)
				 && (this.ShipmentCnt == target.ShipmentCnt)
				 && (this.SalesMoneyTaxInc == target.SalesMoneyTaxInc)
				 && (this.SalesMoneyTaxExc == target.SalesMoneyTaxExc)
				 && (this.Cost == target.Cost)
				 && (this.GrsProfitChkDiv == target.GrsProfitChkDiv)
				 && (this.SalesGoodsCd == target.SalesGoodsCd)
				 && (this.SalsePriceConsTax == target.SalsePriceConsTax)
				 && (this.TaxationDivCd == target.TaxationDivCd)
				 && (this.PartySlipNumDtl == target.PartySlipNumDtl)
				 && (this.DtlNote == target.DtlNote)
				 && (this.SupplierCd == target.SupplierCd)
				 && (this.SupplierSnm == target.SupplierSnm)
				 && (this.SlipMemo1 == target.SlipMemo1)
				 && (this.SlipMemo2 == target.SlipMemo2)
				 && (this.SlipMemo3 == target.SlipMemo3)
				 && (this.SlipMemo4 == target.SlipMemo4)
				 && (this.SlipMemo5 == target.SlipMemo5)
				 && (this.SlipMemo6 == target.SlipMemo6)
				 && (this.InsideMemo1 == target.InsideMemo1)
				 && (this.InsideMemo2 == target.InsideMemo2)
				 && (this.InsideMemo3 == target.InsideMemo3)
				 && (this.InsideMemo4 == target.InsideMemo4)
				 && (this.InsideMemo5 == target.InsideMemo5)
				 && (this.InsideMemo6 == target.InsideMemo6)
				 && (this.BfListPrice == target.BfListPrice)
				 && (this.BfSalesUnitPrice == target.BfSalesUnitPrice)
				 && (this.BfUnitCost == target.BfUnitCost)
				 && (this.PrtGoodsNo == target.PrtGoodsNo)
				 && (this.PrtGoodsName == target.PrtGoodsName)
				 && (this.PrtGoodsMakerCd == target.PrtGoodsMakerCd)
				 && (this.PrtGoodsMakerNm == target.PrtGoodsMakerNm)
				 && (this.SupplierSlipCd == target.SupplierSlipCd)
				 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
				 && (this.TtlAmntDispRateApy == target.TtlAmntDispRateApy)
				 && (this.ConfirmedDiv == target.ConfirmedDiv)
				 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
				 && (this.TotalDay == target.TotalDay)
				 && (this.DtlRelationGuid == target.DtlRelationGuid)
				 && (this.AcptAnOdrRemainCnt == target.AcptAnOdrRemainCnt)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.ResultsAddUpSecNm == target.ResultsAddUpSecNm)
				 && (this.OutputName == target.OutputName)
				 && (this.BLGoodsName == target.BLGoodsName));
		}

		/// <summary>
		/// 売上データ（仕入同時計上）比較処理
		/// </summary>
		/// <param name="salesTemp1">
		///                    比較するSalesTempクラスのインスタンス
		/// </param>
		/// <param name="salesTemp2">比較するSalesTempクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTempクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SalesTemp salesTemp1, SalesTemp salesTemp2)
		{
			return ((salesTemp1.CreateDateTime == salesTemp2.CreateDateTime)
				 && (salesTemp1.UpdateDateTime == salesTemp2.UpdateDateTime)
				 && (salesTemp1.EnterpriseCode == salesTemp2.EnterpriseCode)
				 && (salesTemp1.FileHeaderGuid == salesTemp2.FileHeaderGuid)
				 && (salesTemp1.UpdEmployeeCode == salesTemp2.UpdEmployeeCode)
				 && (salesTemp1.UpdAssemblyId1 == salesTemp2.UpdAssemblyId1)
				 && (salesTemp1.UpdAssemblyId2 == salesTemp2.UpdAssemblyId2)
				 && (salesTemp1.LogicalDeleteCode == salesTemp2.LogicalDeleteCode)
				 && (salesTemp1.AcptAnOdrStatus == salesTemp2.AcptAnOdrStatus)
				 && (salesTemp1.SectionCode == salesTemp2.SectionCode)
				 && (salesTemp1.SubSectionCode == salesTemp2.SubSectionCode)
				 && (salesTemp1.MinSectionCode == salesTemp2.MinSectionCode)
				 && (salesTemp1.DebitNoteDiv == salesTemp2.DebitNoteDiv)
				 && (salesTemp1.DebitNLnkAcptAnOdr == salesTemp2.DebitNLnkAcptAnOdr)
				 && (salesTemp1.SalesSlipCd == salesTemp2.SalesSlipCd)
				 && (salesTemp1.AccRecDivCd == salesTemp2.AccRecDivCd)
				 && (salesTemp1.SalesInpSecCd == salesTemp2.SalesInpSecCd)
				 && (salesTemp1.DemandAddUpSecCd == salesTemp2.DemandAddUpSecCd)
				 && (salesTemp1.ResultsAddUpSecCd == salesTemp2.ResultsAddUpSecCd)
				 && (salesTemp1.UpdateSecCd == salesTemp2.UpdateSecCd)
				 && (salesTemp1.SearchSlipDate == salesTemp2.SearchSlipDate)
				 && (salesTemp1.ShipmentDay == salesTemp2.ShipmentDay)
				 && (salesTemp1.SalesDate == salesTemp2.SalesDate)
				 && (salesTemp1.AddUpADate == salesTemp2.AddUpADate)
				 && (salesTemp1.DelayPaymentDiv == salesTemp2.DelayPaymentDiv)
				 && (salesTemp1.ClaimCode == salesTemp2.ClaimCode)
				 && (salesTemp1.ClaimSnm == salesTemp2.ClaimSnm)
				 && (salesTemp1.CustomerCode == salesTemp2.CustomerCode)
				 && (salesTemp1.CustomerName == salesTemp2.CustomerName)
				 && (salesTemp1.CustomerName2 == salesTemp2.CustomerName2)
				 && (salesTemp1.CustomerSnm == salesTemp2.CustomerSnm)
				 && (salesTemp1.HonorificTitle == salesTemp2.HonorificTitle)
				 && (salesTemp1.OutputNameCode == salesTemp2.OutputNameCode)
				 && (salesTemp1.BusinessTypeCode == salesTemp2.BusinessTypeCode)
				 && (salesTemp1.BusinessTypeName == salesTemp2.BusinessTypeName)
				 && (salesTemp1.SalesAreaCode == salesTemp2.SalesAreaCode)
				 && (salesTemp1.SalesAreaName == salesTemp2.SalesAreaName)
				 && (salesTemp1.SalesInputCode == salesTemp2.SalesInputCode)
				 && (salesTemp1.SalesInputName == salesTemp2.SalesInputName)
				 && (salesTemp1.FrontEmployeeCd == salesTemp2.FrontEmployeeCd)
				 && (salesTemp1.FrontEmployeeNm == salesTemp2.FrontEmployeeNm)
				 && (salesTemp1.SalesEmployeeCd == salesTemp2.SalesEmployeeCd)
				 && (salesTemp1.SalesEmployeeNm == salesTemp2.SalesEmployeeNm)
				 && (salesTemp1.ConsTaxLayMethod == salesTemp2.ConsTaxLayMethod)
				 && (salesTemp1.ConsTaxRate == salesTemp2.ConsTaxRate)
				 && (salesTemp1.FractionProcCd == salesTemp2.FractionProcCd)
				 && (salesTemp1.AutoDepositCd == salesTemp2.AutoDepositCd)
				 && (salesTemp1.AutoDepoSlipNum == salesTemp2.AutoDepoSlipNum)
				 && (salesTemp1.SlipAddressDiv == salesTemp2.SlipAddressDiv)
				 && (salesTemp1.AddresseeCode == salesTemp2.AddresseeCode)
				 && (salesTemp1.AddresseeName == salesTemp2.AddresseeName)
				 && (salesTemp1.AddresseeName2 == salesTemp2.AddresseeName2)
				 && (salesTemp1.AddresseePostNo == salesTemp2.AddresseePostNo)
				 && (salesTemp1.AddresseeAddr1 == salesTemp2.AddresseeAddr1)
				 && (salesTemp1.AddresseeAddr2 == salesTemp2.AddresseeAddr2)
				 && (salesTemp1.AddresseeAddr3 == salesTemp2.AddresseeAddr3)
				 && (salesTemp1.AddresseeAddr4 == salesTemp2.AddresseeAddr4)
				 && (salesTemp1.AddresseeTelNo == salesTemp2.AddresseeTelNo)
				 && (salesTemp1.AddresseeFaxNo == salesTemp2.AddresseeFaxNo)
				 && (salesTemp1.PartySaleSlipNum == salesTemp2.PartySaleSlipNum)
				 && (salesTemp1.SlipNote == salesTemp2.SlipNote)
				 && (salesTemp1.SlipNote2 == salesTemp2.SlipNote2)
				 && (salesTemp1.RetGoodsReasonDiv == salesTemp2.RetGoodsReasonDiv)
				 && (salesTemp1.RetGoodsReason == salesTemp2.RetGoodsReason)
				 && (salesTemp1.DetailRowCount == salesTemp2.DetailRowCount)
				 && (salesTemp1.DeliveredGoodsDiv == salesTemp2.DeliveredGoodsDiv)
				 && (salesTemp1.DeliveredGoodsDivNm == salesTemp2.DeliveredGoodsDivNm)
				 && (salesTemp1.ReconcileFlag == salesTemp2.ReconcileFlag)
				 && (salesTemp1.SlipPrtSetPaperId == salesTemp2.SlipPrtSetPaperId)
				 && (salesTemp1.CompleteCd == salesTemp2.CompleteCd)
				 && (salesTemp1.ClaimType == salesTemp2.ClaimType)
				 && (salesTemp1.SalesPriceFracProcCd == salesTemp2.SalesPriceFracProcCd)
				 && (salesTemp1.ListPricePrintDiv == salesTemp2.ListPricePrintDiv)
				 && (salesTemp1.EraNameDispCd1 == salesTemp2.EraNameDispCd1)
				 && (salesTemp1.AcceptAnOrderNo == salesTemp2.AcceptAnOrderNo)
				 && (salesTemp1.CommonSeqNo == salesTemp2.CommonSeqNo)
				 && (salesTemp1.SalesSlipDtlNum == salesTemp2.SalesSlipDtlNum)
				 && (salesTemp1.AcptAnOdrStatusSrc == salesTemp2.AcptAnOdrStatusSrc)
				 && (salesTemp1.SalesSlipDtlNumSrc == salesTemp2.SalesSlipDtlNumSrc)
				 && (salesTemp1.SupplierFormalSync == salesTemp2.SupplierFormalSync)
				 && (salesTemp1.StockSlipDtlNumSync == salesTemp2.StockSlipDtlNumSync)
				 && (salesTemp1.SalesSlipCdDtl == salesTemp2.SalesSlipCdDtl)
				 && (salesTemp1.OrderNumber == salesTemp2.OrderNumber)
				 && (salesTemp1.StockMngExistCd == salesTemp2.StockMngExistCd)
				 && (salesTemp1.DeliGdsCmpltDueDate == salesTemp2.DeliGdsCmpltDueDate)
				 && (salesTemp1.GoodsKindCode == salesTemp2.GoodsKindCode)
				 && (salesTemp1.GoodsMakerCd == salesTemp2.GoodsMakerCd)
				 && (salesTemp1.MakerName == salesTemp2.MakerName)
				 && (salesTemp1.GoodsNo == salesTemp2.GoodsNo)
				 && (salesTemp1.GoodsName == salesTemp2.GoodsName)
				 && (salesTemp1.GoodsShortName == salesTemp2.GoodsShortName)
				 && (salesTemp1.GoodsSetDivCd == salesTemp2.GoodsSetDivCd)
				 && (salesTemp1.LargeGoodsGanreCode == salesTemp2.LargeGoodsGanreCode)
				 && (salesTemp1.LargeGoodsGanreName == salesTemp2.LargeGoodsGanreName)
				 && (salesTemp1.MediumGoodsGanreCode == salesTemp2.MediumGoodsGanreCode)
				 && (salesTemp1.MediumGoodsGanreName == salesTemp2.MediumGoodsGanreName)
				 && (salesTemp1.DetailGoodsGanreCode == salesTemp2.DetailGoodsGanreCode)
				 && (salesTemp1.DetailGoodsGanreName == salesTemp2.DetailGoodsGanreName)
				 && (salesTemp1.BLGoodsCode == salesTemp2.BLGoodsCode)
				 && (salesTemp1.BLGoodsFullName == salesTemp2.BLGoodsFullName)
				 && (salesTemp1.EnterpriseGanreCode == salesTemp2.EnterpriseGanreCode)
				 && (salesTemp1.EnterpriseGanreName == salesTemp2.EnterpriseGanreName)
				 && (salesTemp1.WarehouseCode == salesTemp2.WarehouseCode)
				 && (salesTemp1.WarehouseName == salesTemp2.WarehouseName)
				 && (salesTemp1.WarehouseShelfNo == salesTemp2.WarehouseShelfNo)
				 && (salesTemp1.SalesOrderDivCd == salesTemp2.SalesOrderDivCd)
				 && (salesTemp1.OpenPriceDiv == salesTemp2.OpenPriceDiv)
				 && (salesTemp1.UnitCode == salesTemp2.UnitCode)
				 && (salesTemp1.UnitName == salesTemp2.UnitName)
				 && (salesTemp1.GoodsRateRank == salesTemp2.GoodsRateRank)
				 && (salesTemp1.CustRateGrpCode == salesTemp2.CustRateGrpCode)
				 && (salesTemp1.SuppRateGrpCode == salesTemp2.SuppRateGrpCode)
				 && (salesTemp1.ListPriceRate == salesTemp2.ListPriceRate)
				 && (salesTemp1.RateSectPriceUnPrc == salesTemp2.RateSectPriceUnPrc)
				 && (salesTemp1.RateDivLPrice == salesTemp2.RateDivLPrice)
				 && (salesTemp1.UnPrcCalcCdLPrice == salesTemp2.UnPrcCalcCdLPrice)
				 && (salesTemp1.PriceCdLPrice == salesTemp2.PriceCdLPrice)
				 && (salesTemp1.StdUnPrcLPrice == salesTemp2.StdUnPrcLPrice)
				 && (salesTemp1.FracProcUnitLPrice == salesTemp2.FracProcUnitLPrice)
				 && (salesTemp1.FracProcLPrice == salesTemp2.FracProcLPrice)
				 && (salesTemp1.ListPriceTaxIncFl == salesTemp2.ListPriceTaxIncFl)
				 && (salesTemp1.ListPriceTaxExcFl == salesTemp2.ListPriceTaxExcFl)
				 && (salesTemp1.ListPriceChngCd == salesTemp2.ListPriceChngCd)
				 && (salesTemp1.SalesRate == salesTemp2.SalesRate)
				 && (salesTemp1.RateSectSalUnPrc == salesTemp2.RateSectSalUnPrc)
				 && (salesTemp1.RateDivSalUnPrc == salesTemp2.RateDivSalUnPrc)
				 && (salesTemp1.UnPrcCalcCdSalUnPrc == salesTemp2.UnPrcCalcCdSalUnPrc)
				 && (salesTemp1.PriceCdSalUnPrc == salesTemp2.PriceCdSalUnPrc)
				 && (salesTemp1.StdUnPrcSalUnPrc == salesTemp2.StdUnPrcSalUnPrc)
				 && (salesTemp1.FracProcUnitSalUnPrc == salesTemp2.FracProcUnitSalUnPrc)
				 && (salesTemp1.FracProcSalUnPrc == salesTemp2.FracProcSalUnPrc)
				 && (salesTemp1.SalesUnPrcTaxIncFl == salesTemp2.SalesUnPrcTaxIncFl)
				 && (salesTemp1.SalesUnPrcTaxExcFl == salesTemp2.SalesUnPrcTaxExcFl)
				 && (salesTemp1.SalesUnPrcChngCd == salesTemp2.SalesUnPrcChngCd)
				 && (salesTemp1.CostRate == salesTemp2.CostRate)
				 && (salesTemp1.RateSectCstUnPrc == salesTemp2.RateSectCstUnPrc)
				 && (salesTemp1.RateDivUnCst == salesTemp2.RateDivUnCst)
				 && (salesTemp1.UnPrcCalcCdUnCst == salesTemp2.UnPrcCalcCdUnCst)
				 && (salesTemp1.PriceCdUnCst == salesTemp2.PriceCdUnCst)
				 && (salesTemp1.StdUnPrcUnCst == salesTemp2.StdUnPrcUnCst)
				 && (salesTemp1.FracProcUnitUnCst == salesTemp2.FracProcUnitUnCst)
				 && (salesTemp1.FracProcUnCst == salesTemp2.FracProcUnCst)
				 && (salesTemp1.SalesUnitCost == salesTemp2.SalesUnitCost)
				 && (salesTemp1.SalesUnitCostChngDiv == salesTemp2.SalesUnitCostChngDiv)
				 && (salesTemp1.RateBLGoodsCode == salesTemp2.RateBLGoodsCode)
				 && (salesTemp1.RateBLGoodsName == salesTemp2.RateBLGoodsName)
				 && (salesTemp1.BargainCd == salesTemp2.BargainCd)
				 && (salesTemp1.BargainNm == salesTemp2.BargainNm)
				 && (salesTemp1.ShipmentCnt == salesTemp2.ShipmentCnt)
				 && (salesTemp1.SalesMoneyTaxInc == salesTemp2.SalesMoneyTaxInc)
				 && (salesTemp1.SalesMoneyTaxExc == salesTemp2.SalesMoneyTaxExc)
				 && (salesTemp1.Cost == salesTemp2.Cost)
				 && (salesTemp1.GrsProfitChkDiv == salesTemp2.GrsProfitChkDiv)
				 && (salesTemp1.SalesGoodsCd == salesTemp2.SalesGoodsCd)
				 && (salesTemp1.SalsePriceConsTax == salesTemp2.SalsePriceConsTax)
				 && (salesTemp1.TaxationDivCd == salesTemp2.TaxationDivCd)
				 && (salesTemp1.PartySlipNumDtl == salesTemp2.PartySlipNumDtl)
				 && (salesTemp1.DtlNote == salesTemp2.DtlNote)
				 && (salesTemp1.SupplierCd == salesTemp2.SupplierCd)
				 && (salesTemp1.SupplierSnm == salesTemp2.SupplierSnm)
				 && (salesTemp1.SlipMemo1 == salesTemp2.SlipMemo1)
				 && (salesTemp1.SlipMemo2 == salesTemp2.SlipMemo2)
				 && (salesTemp1.SlipMemo3 == salesTemp2.SlipMemo3)
				 && (salesTemp1.SlipMemo4 == salesTemp2.SlipMemo4)
				 && (salesTemp1.SlipMemo5 == salesTemp2.SlipMemo5)
				 && (salesTemp1.SlipMemo6 == salesTemp2.SlipMemo6)
				 && (salesTemp1.InsideMemo1 == salesTemp2.InsideMemo1)
				 && (salesTemp1.InsideMemo2 == salesTemp2.InsideMemo2)
				 && (salesTemp1.InsideMemo3 == salesTemp2.InsideMemo3)
				 && (salesTemp1.InsideMemo4 == salesTemp2.InsideMemo4)
				 && (salesTemp1.InsideMemo5 == salesTemp2.InsideMemo5)
				 && (salesTemp1.InsideMemo6 == salesTemp2.InsideMemo6)
				 && (salesTemp1.BfListPrice == salesTemp2.BfListPrice)
				 && (salesTemp1.BfSalesUnitPrice == salesTemp2.BfSalesUnitPrice)
				 && (salesTemp1.BfUnitCost == salesTemp2.BfUnitCost)
				 && (salesTemp1.PrtGoodsNo == salesTemp2.PrtGoodsNo)
				 && (salesTemp1.PrtGoodsName == salesTemp2.PrtGoodsName)
				 && (salesTemp1.PrtGoodsMakerCd == salesTemp2.PrtGoodsMakerCd)
				 && (salesTemp1.PrtGoodsMakerNm == salesTemp2.PrtGoodsMakerNm)
				 && (salesTemp1.SupplierSlipCd == salesTemp2.SupplierSlipCd)
				 && (salesTemp1.TotalAmountDispWayCd == salesTemp2.TotalAmountDispWayCd)
				 && (salesTemp1.TtlAmntDispRateApy == salesTemp2.TtlAmntDispRateApy)
				 && (salesTemp1.ConfirmedDiv == salesTemp2.ConfirmedDiv)
				 && (salesTemp1.NTimeCalcStDate == salesTemp2.NTimeCalcStDate)
				 && (salesTemp1.TotalDay == salesTemp2.TotalDay)
				 && (salesTemp1.DtlRelationGuid == salesTemp2.DtlRelationGuid)
				 && (salesTemp1.AcptAnOdrRemainCnt == salesTemp2.AcptAnOdrRemainCnt)
				 && (salesTemp1.EnterpriseName == salesTemp2.EnterpriseName)
				 && (salesTemp1.UpdEmployeeName == salesTemp2.UpdEmployeeName)
				 && (salesTemp1.ResultsAddUpSecNm == salesTemp2.ResultsAddUpSecNm)
				 && (salesTemp1.OutputName == salesTemp2.OutputName)
				 && (salesTemp1.BLGoodsName == salesTemp2.BLGoodsName));
		}
		/// <summary>
		/// 売上データ（仕入同時計上）比較処理
		/// </summary>
		/// <param name="target">比較対象のSalesTempクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTempクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SalesTemp target)
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
			if(this.AcptAnOdrStatus != target.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.SubSectionCode != target.SubSectionCode)resList.Add("SubSectionCode");
			if(this.MinSectionCode != target.MinSectionCode)resList.Add("MinSectionCode");
			if(this.DebitNoteDiv != target.DebitNoteDiv)resList.Add("DebitNoteDiv");
			if(this.DebitNLnkAcptAnOdr != target.DebitNLnkAcptAnOdr)resList.Add("DebitNLnkAcptAnOdr");
			if(this.SalesSlipCd != target.SalesSlipCd)resList.Add("SalesSlipCd");
			if(this.AccRecDivCd != target.AccRecDivCd)resList.Add("AccRecDivCd");
			if(this.SalesInpSecCd != target.SalesInpSecCd)resList.Add("SalesInpSecCd");
			if(this.DemandAddUpSecCd != target.DemandAddUpSecCd)resList.Add("DemandAddUpSecCd");
			if(this.ResultsAddUpSecCd != target.ResultsAddUpSecCd)resList.Add("ResultsAddUpSecCd");
			if(this.UpdateSecCd != target.UpdateSecCd)resList.Add("UpdateSecCd");
			if(this.SearchSlipDate != target.SearchSlipDate)resList.Add("SearchSlipDate");
			if(this.ShipmentDay != target.ShipmentDay)resList.Add("ShipmentDay");
			if(this.SalesDate != target.SalesDate)resList.Add("SalesDate");
			if(this.AddUpADate != target.AddUpADate)resList.Add("AddUpADate");
			if(this.DelayPaymentDiv != target.DelayPaymentDiv)resList.Add("DelayPaymentDiv");
			if(this.ClaimCode != target.ClaimCode)resList.Add("ClaimCode");
			if(this.ClaimSnm != target.ClaimSnm)resList.Add("ClaimSnm");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustomerName != target.CustomerName)resList.Add("CustomerName");
			if(this.CustomerName2 != target.CustomerName2)resList.Add("CustomerName2");
			if(this.CustomerSnm != target.CustomerSnm)resList.Add("CustomerSnm");
			if(this.HonorificTitle != target.HonorificTitle)resList.Add("HonorificTitle");
			if(this.OutputNameCode != target.OutputNameCode)resList.Add("OutputNameCode");
			if(this.BusinessTypeCode != target.BusinessTypeCode)resList.Add("BusinessTypeCode");
			if(this.BusinessTypeName != target.BusinessTypeName)resList.Add("BusinessTypeName");
			if(this.SalesAreaCode != target.SalesAreaCode)resList.Add("SalesAreaCode");
			if(this.SalesAreaName != target.SalesAreaName)resList.Add("SalesAreaName");
			if(this.SalesInputCode != target.SalesInputCode)resList.Add("SalesInputCode");
			if(this.SalesInputName != target.SalesInputName)resList.Add("SalesInputName");
			if(this.FrontEmployeeCd != target.FrontEmployeeCd)resList.Add("FrontEmployeeCd");
			if(this.FrontEmployeeNm != target.FrontEmployeeNm)resList.Add("FrontEmployeeNm");
			if(this.SalesEmployeeCd != target.SalesEmployeeCd)resList.Add("SalesEmployeeCd");
			if(this.SalesEmployeeNm != target.SalesEmployeeNm)resList.Add("SalesEmployeeNm");
			if(this.ConsTaxLayMethod != target.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(this.ConsTaxRate != target.ConsTaxRate)resList.Add("ConsTaxRate");
			if(this.FractionProcCd != target.FractionProcCd)resList.Add("FractionProcCd");
			if(this.AutoDepositCd != target.AutoDepositCd)resList.Add("AutoDepositCd");
			if(this.AutoDepoSlipNum != target.AutoDepoSlipNum)resList.Add("AutoDepoSlipNum");
			if(this.SlipAddressDiv != target.SlipAddressDiv)resList.Add("SlipAddressDiv");
			if(this.AddresseeCode != target.AddresseeCode)resList.Add("AddresseeCode");
			if(this.AddresseeName != target.AddresseeName)resList.Add("AddresseeName");
			if(this.AddresseeName2 != target.AddresseeName2)resList.Add("AddresseeName2");
			if(this.AddresseePostNo != target.AddresseePostNo)resList.Add("AddresseePostNo");
			if(this.AddresseeAddr1 != target.AddresseeAddr1)resList.Add("AddresseeAddr1");
			if(this.AddresseeAddr2 != target.AddresseeAddr2)resList.Add("AddresseeAddr2");
			if(this.AddresseeAddr3 != target.AddresseeAddr3)resList.Add("AddresseeAddr3");
			if(this.AddresseeAddr4 != target.AddresseeAddr4)resList.Add("AddresseeAddr4");
			if(this.AddresseeTelNo != target.AddresseeTelNo)resList.Add("AddresseeTelNo");
			if(this.AddresseeFaxNo != target.AddresseeFaxNo)resList.Add("AddresseeFaxNo");
			if(this.PartySaleSlipNum != target.PartySaleSlipNum)resList.Add("PartySaleSlipNum");
			if(this.SlipNote != target.SlipNote)resList.Add("SlipNote");
			if(this.SlipNote2 != target.SlipNote2)resList.Add("SlipNote2");
			if(this.RetGoodsReasonDiv != target.RetGoodsReasonDiv)resList.Add("RetGoodsReasonDiv");
			if(this.RetGoodsReason != target.RetGoodsReason)resList.Add("RetGoodsReason");
			if(this.DetailRowCount != target.DetailRowCount)resList.Add("DetailRowCount");
			if(this.DeliveredGoodsDiv != target.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(this.DeliveredGoodsDivNm != target.DeliveredGoodsDivNm)resList.Add("DeliveredGoodsDivNm");
			if(this.ReconcileFlag != target.ReconcileFlag)resList.Add("ReconcileFlag");
			if(this.SlipPrtSetPaperId != target.SlipPrtSetPaperId)resList.Add("SlipPrtSetPaperId");
			if(this.CompleteCd != target.CompleteCd)resList.Add("CompleteCd");
			if(this.ClaimType != target.ClaimType)resList.Add("ClaimType");
			if(this.SalesPriceFracProcCd != target.SalesPriceFracProcCd)resList.Add("SalesPriceFracProcCd");
			if(this.ListPricePrintDiv != target.ListPricePrintDiv)resList.Add("ListPricePrintDiv");
			if(this.EraNameDispCd1 != target.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(this.AcceptAnOrderNo != target.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(this.CommonSeqNo != target.CommonSeqNo)resList.Add("CommonSeqNo");
			if(this.SalesSlipDtlNum != target.SalesSlipDtlNum)resList.Add("SalesSlipDtlNum");
			if(this.AcptAnOdrStatusSrc != target.AcptAnOdrStatusSrc)resList.Add("AcptAnOdrStatusSrc");
			if(this.SalesSlipDtlNumSrc != target.SalesSlipDtlNumSrc)resList.Add("SalesSlipDtlNumSrc");
			if(this.SupplierFormalSync != target.SupplierFormalSync)resList.Add("SupplierFormalSync");
			if(this.StockSlipDtlNumSync != target.StockSlipDtlNumSync)resList.Add("StockSlipDtlNumSync");
			if(this.SalesSlipCdDtl != target.SalesSlipCdDtl)resList.Add("SalesSlipCdDtl");
			if(this.OrderNumber != target.OrderNumber)resList.Add("OrderNumber");
			if(this.StockMngExistCd != target.StockMngExistCd)resList.Add("StockMngExistCd");
			if(this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(this.GoodsKindCode != target.GoodsKindCode)resList.Add("GoodsKindCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.GoodsShortName != target.GoodsShortName)resList.Add("GoodsShortName");
			if(this.GoodsSetDivCd != target.GoodsSetDivCd)resList.Add("GoodsSetDivCd");
			if(this.LargeGoodsGanreCode != target.LargeGoodsGanreCode)resList.Add("LargeGoodsGanreCode");
			if(this.LargeGoodsGanreName != target.LargeGoodsGanreName)resList.Add("LargeGoodsGanreName");
			if(this.MediumGoodsGanreCode != target.MediumGoodsGanreCode)resList.Add("MediumGoodsGanreCode");
			if(this.MediumGoodsGanreName != target.MediumGoodsGanreName)resList.Add("MediumGoodsGanreName");
			if(this.DetailGoodsGanreCode != target.DetailGoodsGanreCode)resList.Add("DetailGoodsGanreCode");
			if(this.DetailGoodsGanreName != target.DetailGoodsGanreName)resList.Add("DetailGoodsGanreName");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsFullName != target.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(this.EnterpriseGanreCode != target.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(this.EnterpriseGanreName != target.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(this.WarehouseCode != target.WarehouseCode)resList.Add("WarehouseCode");
			if(this.WarehouseName != target.WarehouseName)resList.Add("WarehouseName");
			if(this.WarehouseShelfNo != target.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(this.SalesOrderDivCd != target.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(this.OpenPriceDiv != target.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(this.UnitCode != target.UnitCode)resList.Add("UnitCode");
			if(this.UnitName != target.UnitName)resList.Add("UnitName");
			if(this.GoodsRateRank != target.GoodsRateRank)resList.Add("GoodsRateRank");
			if(this.CustRateGrpCode != target.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(this.SuppRateGrpCode != target.SuppRateGrpCode)resList.Add("SuppRateGrpCode");
			if(this.ListPriceRate != target.ListPriceRate)resList.Add("ListPriceRate");
			if(this.RateSectPriceUnPrc != target.RateSectPriceUnPrc)resList.Add("RateSectPriceUnPrc");
			if(this.RateDivLPrice != target.RateDivLPrice)resList.Add("RateDivLPrice");
			if(this.UnPrcCalcCdLPrice != target.UnPrcCalcCdLPrice)resList.Add("UnPrcCalcCdLPrice");
			if(this.PriceCdLPrice != target.PriceCdLPrice)resList.Add("PriceCdLPrice");
			if(this.StdUnPrcLPrice != target.StdUnPrcLPrice)resList.Add("StdUnPrcLPrice");
			if(this.FracProcUnitLPrice != target.FracProcUnitLPrice)resList.Add("FracProcUnitLPrice");
			if(this.FracProcLPrice != target.FracProcLPrice)resList.Add("FracProcLPrice");
			if(this.ListPriceTaxIncFl != target.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(this.ListPriceTaxExcFl != target.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(this.ListPriceChngCd != target.ListPriceChngCd)resList.Add("ListPriceChngCd");
			if(this.SalesRate != target.SalesRate)resList.Add("SalesRate");
			if(this.RateSectSalUnPrc != target.RateSectSalUnPrc)resList.Add("RateSectSalUnPrc");
			if(this.RateDivSalUnPrc != target.RateDivSalUnPrc)resList.Add("RateDivSalUnPrc");
			if(this.UnPrcCalcCdSalUnPrc != target.UnPrcCalcCdSalUnPrc)resList.Add("UnPrcCalcCdSalUnPrc");
			if(this.PriceCdSalUnPrc != target.PriceCdSalUnPrc)resList.Add("PriceCdSalUnPrc");
			if(this.StdUnPrcSalUnPrc != target.StdUnPrcSalUnPrc)resList.Add("StdUnPrcSalUnPrc");
			if(this.FracProcUnitSalUnPrc != target.FracProcUnitSalUnPrc)resList.Add("FracProcUnitSalUnPrc");
			if(this.FracProcSalUnPrc != target.FracProcSalUnPrc)resList.Add("FracProcSalUnPrc");
			if(this.SalesUnPrcTaxIncFl != target.SalesUnPrcTaxIncFl)resList.Add("SalesUnPrcTaxIncFl");
			if(this.SalesUnPrcTaxExcFl != target.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(this.SalesUnPrcChngCd != target.SalesUnPrcChngCd)resList.Add("SalesUnPrcChngCd");
			if(this.CostRate != target.CostRate)resList.Add("CostRate");
			if(this.RateSectCstUnPrc != target.RateSectCstUnPrc)resList.Add("RateSectCstUnPrc");
			if(this.RateDivUnCst != target.RateDivUnCst)resList.Add("RateDivUnCst");
			if(this.UnPrcCalcCdUnCst != target.UnPrcCalcCdUnCst)resList.Add("UnPrcCalcCdUnCst");
			if(this.PriceCdUnCst != target.PriceCdUnCst)resList.Add("PriceCdUnCst");
			if(this.StdUnPrcUnCst != target.StdUnPrcUnCst)resList.Add("StdUnPrcUnCst");
			if(this.FracProcUnitUnCst != target.FracProcUnitUnCst)resList.Add("FracProcUnitUnCst");
			if(this.FracProcUnCst != target.FracProcUnCst)resList.Add("FracProcUnCst");
			if(this.SalesUnitCost != target.SalesUnitCost)resList.Add("SalesUnitCost");
			if(this.SalesUnitCostChngDiv != target.SalesUnitCostChngDiv)resList.Add("SalesUnitCostChngDiv");
			if(this.RateBLGoodsCode != target.RateBLGoodsCode)resList.Add("RateBLGoodsCode");
			if(this.RateBLGoodsName != target.RateBLGoodsName)resList.Add("RateBLGoodsName");
			if(this.BargainCd != target.BargainCd)resList.Add("BargainCd");
			if(this.BargainNm != target.BargainNm)resList.Add("BargainNm");
			if(this.ShipmentCnt != target.ShipmentCnt)resList.Add("ShipmentCnt");
			if(this.SalesMoneyTaxInc != target.SalesMoneyTaxInc)resList.Add("SalesMoneyTaxInc");
			if(this.SalesMoneyTaxExc != target.SalesMoneyTaxExc)resList.Add("SalesMoneyTaxExc");
			if(this.Cost != target.Cost)resList.Add("Cost");
			if(this.GrsProfitChkDiv != target.GrsProfitChkDiv)resList.Add("GrsProfitChkDiv");
			if(this.SalesGoodsCd != target.SalesGoodsCd)resList.Add("SalesGoodsCd");
			if(this.SalsePriceConsTax != target.SalsePriceConsTax)resList.Add("SalsePriceConsTax");
			if(this.TaxationDivCd != target.TaxationDivCd)resList.Add("TaxationDivCd");
			if(this.PartySlipNumDtl != target.PartySlipNumDtl)resList.Add("PartySlipNumDtl");
			if(this.DtlNote != target.DtlNote)resList.Add("DtlNote");
			if(this.SupplierCd != target.SupplierCd)resList.Add("SupplierCd");
			if(this.SupplierSnm != target.SupplierSnm)resList.Add("SupplierSnm");
			if(this.SlipMemo1 != target.SlipMemo1)resList.Add("SlipMemo1");
			if(this.SlipMemo2 != target.SlipMemo2)resList.Add("SlipMemo2");
			if(this.SlipMemo3 != target.SlipMemo3)resList.Add("SlipMemo3");
			if(this.SlipMemo4 != target.SlipMemo4)resList.Add("SlipMemo4");
			if(this.SlipMemo5 != target.SlipMemo5)resList.Add("SlipMemo5");
			if(this.SlipMemo6 != target.SlipMemo6)resList.Add("SlipMemo6");
			if(this.InsideMemo1 != target.InsideMemo1)resList.Add("InsideMemo1");
			if(this.InsideMemo2 != target.InsideMemo2)resList.Add("InsideMemo2");
			if(this.InsideMemo3 != target.InsideMemo3)resList.Add("InsideMemo3");
			if(this.InsideMemo4 != target.InsideMemo4)resList.Add("InsideMemo4");
			if(this.InsideMemo5 != target.InsideMemo5)resList.Add("InsideMemo5");
			if(this.InsideMemo6 != target.InsideMemo6)resList.Add("InsideMemo6");
			if(this.BfListPrice != target.BfListPrice)resList.Add("BfListPrice");
			if(this.BfSalesUnitPrice != target.BfSalesUnitPrice)resList.Add("BfSalesUnitPrice");
			if(this.BfUnitCost != target.BfUnitCost)resList.Add("BfUnitCost");
			if(this.PrtGoodsNo != target.PrtGoodsNo)resList.Add("PrtGoodsNo");
			if(this.PrtGoodsName != target.PrtGoodsName)resList.Add("PrtGoodsName");
			if(this.PrtGoodsMakerCd != target.PrtGoodsMakerCd)resList.Add("PrtGoodsMakerCd");
			if(this.PrtGoodsMakerNm != target.PrtGoodsMakerNm)resList.Add("PrtGoodsMakerNm");
			if(this.SupplierSlipCd != target.SupplierSlipCd)resList.Add("SupplierSlipCd");
			if(this.TotalAmountDispWayCd != target.TotalAmountDispWayCd)resList.Add("TotalAmountDispWayCd");
			if(this.TtlAmntDispRateApy != target.TtlAmntDispRateApy)resList.Add("TtlAmntDispRateApy");
			if(this.ConfirmedDiv != target.ConfirmedDiv)resList.Add("ConfirmedDiv");
			if(this.NTimeCalcStDate != target.NTimeCalcStDate)resList.Add("NTimeCalcStDate");
			if(this.TotalDay != target.TotalDay)resList.Add("TotalDay");
			if(this.DtlRelationGuid != target.DtlRelationGuid)resList.Add("DtlRelationGuid");
			if(this.AcptAnOdrRemainCnt != target.AcptAnOdrRemainCnt)resList.Add("AcptAnOdrRemainCnt");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.ResultsAddUpSecNm != target.ResultsAddUpSecNm)resList.Add("ResultsAddUpSecNm");
			if(this.OutputName != target.OutputName)resList.Add("OutputName");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}

		/// <summary>
		/// 売上データ（仕入同時計上）比較処理
		/// </summary>
		/// <param name="salesTemp1">比較するSalesTempクラスのインスタンス</param>
		/// <param name="salesTemp2">比較するSalesTempクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesTempクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SalesTemp salesTemp1, SalesTemp salesTemp2)
		{
			ArrayList resList = new ArrayList();
			if(salesTemp1.CreateDateTime != salesTemp2.CreateDateTime)resList.Add("CreateDateTime");
			if(salesTemp1.UpdateDateTime != salesTemp2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(salesTemp1.EnterpriseCode != salesTemp2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(salesTemp1.FileHeaderGuid != salesTemp2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(salesTemp1.UpdEmployeeCode != salesTemp2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(salesTemp1.UpdAssemblyId1 != salesTemp2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(salesTemp1.UpdAssemblyId2 != salesTemp2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(salesTemp1.LogicalDeleteCode != salesTemp2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(salesTemp1.AcptAnOdrStatus != salesTemp2.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(salesTemp1.SectionCode != salesTemp2.SectionCode)resList.Add("SectionCode");
			if(salesTemp1.SubSectionCode != salesTemp2.SubSectionCode)resList.Add("SubSectionCode");
			if(salesTemp1.MinSectionCode != salesTemp2.MinSectionCode)resList.Add("MinSectionCode");
			if(salesTemp1.DebitNoteDiv != salesTemp2.DebitNoteDiv)resList.Add("DebitNoteDiv");
			if(salesTemp1.DebitNLnkAcptAnOdr != salesTemp2.DebitNLnkAcptAnOdr)resList.Add("DebitNLnkAcptAnOdr");
			if(salesTemp1.SalesSlipCd != salesTemp2.SalesSlipCd)resList.Add("SalesSlipCd");
			if(salesTemp1.AccRecDivCd != salesTemp2.AccRecDivCd)resList.Add("AccRecDivCd");
			if(salesTemp1.SalesInpSecCd != salesTemp2.SalesInpSecCd)resList.Add("SalesInpSecCd");
			if(salesTemp1.DemandAddUpSecCd != salesTemp2.DemandAddUpSecCd)resList.Add("DemandAddUpSecCd");
			if(salesTemp1.ResultsAddUpSecCd != salesTemp2.ResultsAddUpSecCd)resList.Add("ResultsAddUpSecCd");
			if(salesTemp1.UpdateSecCd != salesTemp2.UpdateSecCd)resList.Add("UpdateSecCd");
			if(salesTemp1.SearchSlipDate != salesTemp2.SearchSlipDate)resList.Add("SearchSlipDate");
			if(salesTemp1.ShipmentDay != salesTemp2.ShipmentDay)resList.Add("ShipmentDay");
			if(salesTemp1.SalesDate != salesTemp2.SalesDate)resList.Add("SalesDate");
			if(salesTemp1.AddUpADate != salesTemp2.AddUpADate)resList.Add("AddUpADate");
			if(salesTemp1.DelayPaymentDiv != salesTemp2.DelayPaymentDiv)resList.Add("DelayPaymentDiv");
			if(salesTemp1.ClaimCode != salesTemp2.ClaimCode)resList.Add("ClaimCode");
			if(salesTemp1.ClaimSnm != salesTemp2.ClaimSnm)resList.Add("ClaimSnm");
			if(salesTemp1.CustomerCode != salesTemp2.CustomerCode)resList.Add("CustomerCode");
			if(salesTemp1.CustomerName != salesTemp2.CustomerName)resList.Add("CustomerName");
			if(salesTemp1.CustomerName2 != salesTemp2.CustomerName2)resList.Add("CustomerName2");
			if(salesTemp1.CustomerSnm != salesTemp2.CustomerSnm)resList.Add("CustomerSnm");
			if(salesTemp1.HonorificTitle != salesTemp2.HonorificTitle)resList.Add("HonorificTitle");
			if(salesTemp1.OutputNameCode != salesTemp2.OutputNameCode)resList.Add("OutputNameCode");
			if(salesTemp1.BusinessTypeCode != salesTemp2.BusinessTypeCode)resList.Add("BusinessTypeCode");
			if(salesTemp1.BusinessTypeName != salesTemp2.BusinessTypeName)resList.Add("BusinessTypeName");
			if(salesTemp1.SalesAreaCode != salesTemp2.SalesAreaCode)resList.Add("SalesAreaCode");
			if(salesTemp1.SalesAreaName != salesTemp2.SalesAreaName)resList.Add("SalesAreaName");
			if(salesTemp1.SalesInputCode != salesTemp2.SalesInputCode)resList.Add("SalesInputCode");
			if(salesTemp1.SalesInputName != salesTemp2.SalesInputName)resList.Add("SalesInputName");
			if(salesTemp1.FrontEmployeeCd != salesTemp2.FrontEmployeeCd)resList.Add("FrontEmployeeCd");
			if(salesTemp1.FrontEmployeeNm != salesTemp2.FrontEmployeeNm)resList.Add("FrontEmployeeNm");
			if(salesTemp1.SalesEmployeeCd != salesTemp2.SalesEmployeeCd)resList.Add("SalesEmployeeCd");
			if(salesTemp1.SalesEmployeeNm != salesTemp2.SalesEmployeeNm)resList.Add("SalesEmployeeNm");
			if(salesTemp1.ConsTaxLayMethod != salesTemp2.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(salesTemp1.ConsTaxRate != salesTemp2.ConsTaxRate)resList.Add("ConsTaxRate");
			if(salesTemp1.FractionProcCd != salesTemp2.FractionProcCd)resList.Add("FractionProcCd");
			if(salesTemp1.AutoDepositCd != salesTemp2.AutoDepositCd)resList.Add("AutoDepositCd");
			if(salesTemp1.AutoDepoSlipNum != salesTemp2.AutoDepoSlipNum)resList.Add("AutoDepoSlipNum");
			if(salesTemp1.SlipAddressDiv != salesTemp2.SlipAddressDiv)resList.Add("SlipAddressDiv");
			if(salesTemp1.AddresseeCode != salesTemp2.AddresseeCode)resList.Add("AddresseeCode");
			if(salesTemp1.AddresseeName != salesTemp2.AddresseeName)resList.Add("AddresseeName");
			if(salesTemp1.AddresseeName2 != salesTemp2.AddresseeName2)resList.Add("AddresseeName2");
			if(salesTemp1.AddresseePostNo != salesTemp2.AddresseePostNo)resList.Add("AddresseePostNo");
			if(salesTemp1.AddresseeAddr1 != salesTemp2.AddresseeAddr1)resList.Add("AddresseeAddr1");
			if(salesTemp1.AddresseeAddr2 != salesTemp2.AddresseeAddr2)resList.Add("AddresseeAddr2");
			if(salesTemp1.AddresseeAddr3 != salesTemp2.AddresseeAddr3)resList.Add("AddresseeAddr3");
			if(salesTemp1.AddresseeAddr4 != salesTemp2.AddresseeAddr4)resList.Add("AddresseeAddr4");
			if(salesTemp1.AddresseeTelNo != salesTemp2.AddresseeTelNo)resList.Add("AddresseeTelNo");
			if(salesTemp1.AddresseeFaxNo != salesTemp2.AddresseeFaxNo)resList.Add("AddresseeFaxNo");
			if(salesTemp1.PartySaleSlipNum != salesTemp2.PartySaleSlipNum)resList.Add("PartySaleSlipNum");
			if(salesTemp1.SlipNote != salesTemp2.SlipNote)resList.Add("SlipNote");
			if(salesTemp1.SlipNote2 != salesTemp2.SlipNote2)resList.Add("SlipNote2");
			if(salesTemp1.RetGoodsReasonDiv != salesTemp2.RetGoodsReasonDiv)resList.Add("RetGoodsReasonDiv");
			if(salesTemp1.RetGoodsReason != salesTemp2.RetGoodsReason)resList.Add("RetGoodsReason");
			if(salesTemp1.DetailRowCount != salesTemp2.DetailRowCount)resList.Add("DetailRowCount");
			if(salesTemp1.DeliveredGoodsDiv != salesTemp2.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(salesTemp1.DeliveredGoodsDivNm != salesTemp2.DeliveredGoodsDivNm)resList.Add("DeliveredGoodsDivNm");
			if(salesTemp1.ReconcileFlag != salesTemp2.ReconcileFlag)resList.Add("ReconcileFlag");
			if(salesTemp1.SlipPrtSetPaperId != salesTemp2.SlipPrtSetPaperId)resList.Add("SlipPrtSetPaperId");
			if(salesTemp1.CompleteCd != salesTemp2.CompleteCd)resList.Add("CompleteCd");
			if(salesTemp1.ClaimType != salesTemp2.ClaimType)resList.Add("ClaimType");
			if(salesTemp1.SalesPriceFracProcCd != salesTemp2.SalesPriceFracProcCd)resList.Add("SalesPriceFracProcCd");
			if(salesTemp1.ListPricePrintDiv != salesTemp2.ListPricePrintDiv)resList.Add("ListPricePrintDiv");
			if(salesTemp1.EraNameDispCd1 != salesTemp2.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(salesTemp1.AcceptAnOrderNo != salesTemp2.AcceptAnOrderNo)resList.Add("AcceptAnOrderNo");
			if(salesTemp1.CommonSeqNo != salesTemp2.CommonSeqNo)resList.Add("CommonSeqNo");
			if(salesTemp1.SalesSlipDtlNum != salesTemp2.SalesSlipDtlNum)resList.Add("SalesSlipDtlNum");
			if(salesTemp1.AcptAnOdrStatusSrc != salesTemp2.AcptAnOdrStatusSrc)resList.Add("AcptAnOdrStatusSrc");
			if(salesTemp1.SalesSlipDtlNumSrc != salesTemp2.SalesSlipDtlNumSrc)resList.Add("SalesSlipDtlNumSrc");
			if(salesTemp1.SupplierFormalSync != salesTemp2.SupplierFormalSync)resList.Add("SupplierFormalSync");
			if(salesTemp1.StockSlipDtlNumSync != salesTemp2.StockSlipDtlNumSync)resList.Add("StockSlipDtlNumSync");
			if(salesTemp1.SalesSlipCdDtl != salesTemp2.SalesSlipCdDtl)resList.Add("SalesSlipCdDtl");
			if(salesTemp1.OrderNumber != salesTemp2.OrderNumber)resList.Add("OrderNumber");
			if(salesTemp1.StockMngExistCd != salesTemp2.StockMngExistCd)resList.Add("StockMngExistCd");
			if(salesTemp1.DeliGdsCmpltDueDate != salesTemp2.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(salesTemp1.GoodsKindCode != salesTemp2.GoodsKindCode)resList.Add("GoodsKindCode");
			if(salesTemp1.GoodsMakerCd != salesTemp2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(salesTemp1.MakerName != salesTemp2.MakerName)resList.Add("MakerName");
			if(salesTemp1.GoodsNo != salesTemp2.GoodsNo)resList.Add("GoodsNo");
			if(salesTemp1.GoodsName != salesTemp2.GoodsName)resList.Add("GoodsName");
			if(salesTemp1.GoodsShortName != salesTemp2.GoodsShortName)resList.Add("GoodsShortName");
			if(salesTemp1.GoodsSetDivCd != salesTemp2.GoodsSetDivCd)resList.Add("GoodsSetDivCd");
			if(salesTemp1.LargeGoodsGanreCode != salesTemp2.LargeGoodsGanreCode)resList.Add("LargeGoodsGanreCode");
			if(salesTemp1.LargeGoodsGanreName != salesTemp2.LargeGoodsGanreName)resList.Add("LargeGoodsGanreName");
			if(salesTemp1.MediumGoodsGanreCode != salesTemp2.MediumGoodsGanreCode)resList.Add("MediumGoodsGanreCode");
			if(salesTemp1.MediumGoodsGanreName != salesTemp2.MediumGoodsGanreName)resList.Add("MediumGoodsGanreName");
			if(salesTemp1.DetailGoodsGanreCode != salesTemp2.DetailGoodsGanreCode)resList.Add("DetailGoodsGanreCode");
			if(salesTemp1.DetailGoodsGanreName != salesTemp2.DetailGoodsGanreName)resList.Add("DetailGoodsGanreName");
			if(salesTemp1.BLGoodsCode != salesTemp2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(salesTemp1.BLGoodsFullName != salesTemp2.BLGoodsFullName)resList.Add("BLGoodsFullName");
			if(salesTemp1.EnterpriseGanreCode != salesTemp2.EnterpriseGanreCode)resList.Add("EnterpriseGanreCode");
			if(salesTemp1.EnterpriseGanreName != salesTemp2.EnterpriseGanreName)resList.Add("EnterpriseGanreName");
			if(salesTemp1.WarehouseCode != salesTemp2.WarehouseCode)resList.Add("WarehouseCode");
			if(salesTemp1.WarehouseName != salesTemp2.WarehouseName)resList.Add("WarehouseName");
			if(salesTemp1.WarehouseShelfNo != salesTemp2.WarehouseShelfNo)resList.Add("WarehouseShelfNo");
			if(salesTemp1.SalesOrderDivCd != salesTemp2.SalesOrderDivCd)resList.Add("SalesOrderDivCd");
			if(salesTemp1.OpenPriceDiv != salesTemp2.OpenPriceDiv)resList.Add("OpenPriceDiv");
			if(salesTemp1.UnitCode != salesTemp2.UnitCode)resList.Add("UnitCode");
			if(salesTemp1.UnitName != salesTemp2.UnitName)resList.Add("UnitName");
			if(salesTemp1.GoodsRateRank != salesTemp2.GoodsRateRank)resList.Add("GoodsRateRank");
			if(salesTemp1.CustRateGrpCode != salesTemp2.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(salesTemp1.SuppRateGrpCode != salesTemp2.SuppRateGrpCode)resList.Add("SuppRateGrpCode");
			if(salesTemp1.ListPriceRate != salesTemp2.ListPriceRate)resList.Add("ListPriceRate");
			if(salesTemp1.RateSectPriceUnPrc != salesTemp2.RateSectPriceUnPrc)resList.Add("RateSectPriceUnPrc");
			if(salesTemp1.RateDivLPrice != salesTemp2.RateDivLPrice)resList.Add("RateDivLPrice");
			if(salesTemp1.UnPrcCalcCdLPrice != salesTemp2.UnPrcCalcCdLPrice)resList.Add("UnPrcCalcCdLPrice");
			if(salesTemp1.PriceCdLPrice != salesTemp2.PriceCdLPrice)resList.Add("PriceCdLPrice");
			if(salesTemp1.StdUnPrcLPrice != salesTemp2.StdUnPrcLPrice)resList.Add("StdUnPrcLPrice");
			if(salesTemp1.FracProcUnitLPrice != salesTemp2.FracProcUnitLPrice)resList.Add("FracProcUnitLPrice");
			if(salesTemp1.FracProcLPrice != salesTemp2.FracProcLPrice)resList.Add("FracProcLPrice");
			if(salesTemp1.ListPriceTaxIncFl != salesTemp2.ListPriceTaxIncFl)resList.Add("ListPriceTaxIncFl");
			if(salesTemp1.ListPriceTaxExcFl != salesTemp2.ListPriceTaxExcFl)resList.Add("ListPriceTaxExcFl");
			if(salesTemp1.ListPriceChngCd != salesTemp2.ListPriceChngCd)resList.Add("ListPriceChngCd");
			if(salesTemp1.SalesRate != salesTemp2.SalesRate)resList.Add("SalesRate");
			if(salesTemp1.RateSectSalUnPrc != salesTemp2.RateSectSalUnPrc)resList.Add("RateSectSalUnPrc");
			if(salesTemp1.RateDivSalUnPrc != salesTemp2.RateDivSalUnPrc)resList.Add("RateDivSalUnPrc");
			if(salesTemp1.UnPrcCalcCdSalUnPrc != salesTemp2.UnPrcCalcCdSalUnPrc)resList.Add("UnPrcCalcCdSalUnPrc");
			if(salesTemp1.PriceCdSalUnPrc != salesTemp2.PriceCdSalUnPrc)resList.Add("PriceCdSalUnPrc");
			if(salesTemp1.StdUnPrcSalUnPrc != salesTemp2.StdUnPrcSalUnPrc)resList.Add("StdUnPrcSalUnPrc");
			if(salesTemp1.FracProcUnitSalUnPrc != salesTemp2.FracProcUnitSalUnPrc)resList.Add("FracProcUnitSalUnPrc");
			if(salesTemp1.FracProcSalUnPrc != salesTemp2.FracProcSalUnPrc)resList.Add("FracProcSalUnPrc");
			if(salesTemp1.SalesUnPrcTaxIncFl != salesTemp2.SalesUnPrcTaxIncFl)resList.Add("SalesUnPrcTaxIncFl");
			if(salesTemp1.SalesUnPrcTaxExcFl != salesTemp2.SalesUnPrcTaxExcFl)resList.Add("SalesUnPrcTaxExcFl");
			if(salesTemp1.SalesUnPrcChngCd != salesTemp2.SalesUnPrcChngCd)resList.Add("SalesUnPrcChngCd");
			if(salesTemp1.CostRate != salesTemp2.CostRate)resList.Add("CostRate");
			if(salesTemp1.RateSectCstUnPrc != salesTemp2.RateSectCstUnPrc)resList.Add("RateSectCstUnPrc");
			if(salesTemp1.RateDivUnCst != salesTemp2.RateDivUnCst)resList.Add("RateDivUnCst");
			if(salesTemp1.UnPrcCalcCdUnCst != salesTemp2.UnPrcCalcCdUnCst)resList.Add("UnPrcCalcCdUnCst");
			if(salesTemp1.PriceCdUnCst != salesTemp2.PriceCdUnCst)resList.Add("PriceCdUnCst");
			if(salesTemp1.StdUnPrcUnCst != salesTemp2.StdUnPrcUnCst)resList.Add("StdUnPrcUnCst");
			if(salesTemp1.FracProcUnitUnCst != salesTemp2.FracProcUnitUnCst)resList.Add("FracProcUnitUnCst");
			if(salesTemp1.FracProcUnCst != salesTemp2.FracProcUnCst)resList.Add("FracProcUnCst");
			if(salesTemp1.SalesUnitCost != salesTemp2.SalesUnitCost)resList.Add("SalesUnitCost");
			if(salesTemp1.SalesUnitCostChngDiv != salesTemp2.SalesUnitCostChngDiv)resList.Add("SalesUnitCostChngDiv");
			if(salesTemp1.RateBLGoodsCode != salesTemp2.RateBLGoodsCode)resList.Add("RateBLGoodsCode");
			if(salesTemp1.RateBLGoodsName != salesTemp2.RateBLGoodsName)resList.Add("RateBLGoodsName");
			if(salesTemp1.BargainCd != salesTemp2.BargainCd)resList.Add("BargainCd");
			if(salesTemp1.BargainNm != salesTemp2.BargainNm)resList.Add("BargainNm");
			if(salesTemp1.ShipmentCnt != salesTemp2.ShipmentCnt)resList.Add("ShipmentCnt");
			if(salesTemp1.SalesMoneyTaxInc != salesTemp2.SalesMoneyTaxInc)resList.Add("SalesMoneyTaxInc");
			if(salesTemp1.SalesMoneyTaxExc != salesTemp2.SalesMoneyTaxExc)resList.Add("SalesMoneyTaxExc");
			if(salesTemp1.Cost != salesTemp2.Cost)resList.Add("Cost");
			if(salesTemp1.GrsProfitChkDiv != salesTemp2.GrsProfitChkDiv)resList.Add("GrsProfitChkDiv");
			if(salesTemp1.SalesGoodsCd != salesTemp2.SalesGoodsCd)resList.Add("SalesGoodsCd");
			if(salesTemp1.SalsePriceConsTax != salesTemp2.SalsePriceConsTax)resList.Add("SalsePriceConsTax");
			if(salesTemp1.TaxationDivCd != salesTemp2.TaxationDivCd)resList.Add("TaxationDivCd");
			if(salesTemp1.PartySlipNumDtl != salesTemp2.PartySlipNumDtl)resList.Add("PartySlipNumDtl");
			if(salesTemp1.DtlNote != salesTemp2.DtlNote)resList.Add("DtlNote");
			if(salesTemp1.SupplierCd != salesTemp2.SupplierCd)resList.Add("SupplierCd");
			if(salesTemp1.SupplierSnm != salesTemp2.SupplierSnm)resList.Add("SupplierSnm");
			if(salesTemp1.SlipMemo1 != salesTemp2.SlipMemo1)resList.Add("SlipMemo1");
			if(salesTemp1.SlipMemo2 != salesTemp2.SlipMemo2)resList.Add("SlipMemo2");
			if(salesTemp1.SlipMemo3 != salesTemp2.SlipMemo3)resList.Add("SlipMemo3");
			if(salesTemp1.SlipMemo4 != salesTemp2.SlipMemo4)resList.Add("SlipMemo4");
			if(salesTemp1.SlipMemo5 != salesTemp2.SlipMemo5)resList.Add("SlipMemo5");
			if(salesTemp1.SlipMemo6 != salesTemp2.SlipMemo6)resList.Add("SlipMemo6");
			if(salesTemp1.InsideMemo1 != salesTemp2.InsideMemo1)resList.Add("InsideMemo1");
			if(salesTemp1.InsideMemo2 != salesTemp2.InsideMemo2)resList.Add("InsideMemo2");
			if(salesTemp1.InsideMemo3 != salesTemp2.InsideMemo3)resList.Add("InsideMemo3");
			if(salesTemp1.InsideMemo4 != salesTemp2.InsideMemo4)resList.Add("InsideMemo4");
			if(salesTemp1.InsideMemo5 != salesTemp2.InsideMemo5)resList.Add("InsideMemo5");
			if(salesTemp1.InsideMemo6 != salesTemp2.InsideMemo6)resList.Add("InsideMemo6");
			if(salesTemp1.BfListPrice != salesTemp2.BfListPrice)resList.Add("BfListPrice");
			if(salesTemp1.BfSalesUnitPrice != salesTemp2.BfSalesUnitPrice)resList.Add("BfSalesUnitPrice");
			if(salesTemp1.BfUnitCost != salesTemp2.BfUnitCost)resList.Add("BfUnitCost");
			if(salesTemp1.PrtGoodsNo != salesTemp2.PrtGoodsNo)resList.Add("PrtGoodsNo");
			if(salesTemp1.PrtGoodsName != salesTemp2.PrtGoodsName)resList.Add("PrtGoodsName");
			if(salesTemp1.PrtGoodsMakerCd != salesTemp2.PrtGoodsMakerCd)resList.Add("PrtGoodsMakerCd");
			if(salesTemp1.PrtGoodsMakerNm != salesTemp2.PrtGoodsMakerNm)resList.Add("PrtGoodsMakerNm");
			if(salesTemp1.SupplierSlipCd != salesTemp2.SupplierSlipCd)resList.Add("SupplierSlipCd");
			if(salesTemp1.TotalAmountDispWayCd != salesTemp2.TotalAmountDispWayCd)resList.Add("TotalAmountDispWayCd");
			if(salesTemp1.TtlAmntDispRateApy != salesTemp2.TtlAmntDispRateApy)resList.Add("TtlAmntDispRateApy");
			if(salesTemp1.ConfirmedDiv != salesTemp2.ConfirmedDiv)resList.Add("ConfirmedDiv");
			if(salesTemp1.NTimeCalcStDate != salesTemp2.NTimeCalcStDate)resList.Add("NTimeCalcStDate");
			if(salesTemp1.TotalDay != salesTemp2.TotalDay)resList.Add("TotalDay");
			if(salesTemp1.DtlRelationGuid != salesTemp2.DtlRelationGuid)resList.Add("DtlRelationGuid");
			if(salesTemp1.AcptAnOdrRemainCnt != salesTemp2.AcptAnOdrRemainCnt)resList.Add("AcptAnOdrRemainCnt");
			if(salesTemp1.EnterpriseName != salesTemp2.EnterpriseName)resList.Add("EnterpriseName");
			if(salesTemp1.UpdEmployeeName != salesTemp2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(salesTemp1.ResultsAddUpSecNm != salesTemp2.ResultsAddUpSecNm)resList.Add("ResultsAddUpSecNm");
			if(salesTemp1.OutputName != salesTemp2.OutputName)resList.Add("OutputName");
			if(salesTemp1.BLGoodsName != salesTemp2.BLGoodsName)resList.Add("BLGoodsName");

			return resList;
		}
	}
}
