using System;
using System.Collections;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SalesSlipDetailSearchResultWork
	/// <summary>
	///                      売上伝票明細検索抽出結果ワークワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   売上伝票明細検索抽出結果ワークワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2008/06/23  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   AcceptAnOrderNoをInt64からInt32に変更</br>
    /// <br>Programmer       :   23015 森本 大輝</br>
    /// <br>Date             :   2008/09/16</br>
    /// <br>Update Note      :   2011/7/12  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   自動回答区分(SCM)</br>
    /// <br>Update Note      :   鄧潘ハン Redmine 26538</br>
    /// <br>Date             :   2011/11/11</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SalesSlipDetailSearchResultWork
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

		/// <summary>受注番号</summary>
		private Int32 _acceptAnOrderNo;

		/// <summary>受注ステータス</summary>
		/// <remarks>10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  </remarks>
		private Int32 _acptAnOdrStatus;

		/// <summary>売上伝票番号</summary>
		/// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
		private string _salesSlipNum = "";

		/// <summary>売上行番号</summary>
		private Int32 _salesRowNo;

		/// <summary>売上行番号枝番</summary>
		/// <remarks>検索見積の対比で使用する</remarks>
		private Int32 _salesRowDerivNo;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>拠点ガイド名称</summary>
		private string _sectionGuideNm = "";

		/// <summary>部門コード</summary>
		private Int32 _subSectionCode;

		/// <summary>部門名称</summary>
		private string _subSectionName = "";

		/// <summary>売上日付</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _salesDate;

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
		/// <remarks>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</remarks>
		private Int32 _salesSlipCdDtl;

		/// <summary>納品完了予定日</summary>
		/// <remarks>客先納期(YYYYMMDD)</remarks>
		private DateTime _deliGdsCmpltDueDate;

		/// <summary>商品属性</summary>
		/// <remarks>0:純正 1:優良</remarks>
		private Int32 _goodsKindCode;

		/// <summary>商品検索区分</summary>
		/// <remarks>0:BL検索 1:品番 2:手入力</remarks>
		private Int32 _goodsSearchDivCd;

		/// <summary>商品メーカーコード</summary>
		/// <remarks>ﾊﾟｯｹｰｼﾞ毎にﾕｰｻﾞｰ登録範囲が異なる</remarks>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>商品大分類コード</summary>
		/// <remarks>旧大分類（ユーザーガイド）</remarks>
		private Int32 _goodsLGroup;

		/// <summary>商品大分類名称</summary>
		private string _goodsLGroupName = "";

		/// <summary>商品中分類コード</summary>
		/// <remarks>旧中分類コード</remarks>
		private Int32 _goodsMGroup;

		/// <summary>商品中分類名称</summary>
		private string _goodsMGroupName = "";

		/// <summary>BLグループコード</summary>
		/// <remarks>旧グループコード</remarks>
		private Int32 _bLGroupCode;

		/// <summary>BLグループコード名称</summary>
		private string _bLGroupName = "";

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
		/// <remarks>0:取寄せ，1:在庫</remarks>
		private Int32 _salesOrderDivCd;

		/// <summary>オープン価格区分</summary>
		/// <remarks>0:通常／1:オープン価格</remarks>
		private Int32 _openPriceDiv;

		/// <summary>商品掛率ランク</summary>
		/// <remarks>商品の掛率用ランク</remarks>
		private string _goodsRateRank = "";

		/// <summary>得意先掛率グループコード</summary>
		private Int32 _custRateGrpCode;

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

		/// <summary>BL商品コード（印刷）</summary>
		/// <remarks>掛率算出時に使用したBLコード（商品検索結果）</remarks>
		private Int32 _prtBLGoodsCode;

		/// <summary>BL商品コード名称（印刷）</summary>
		/// <remarks>掛率算出時に使用したBLコード名称（商品検索結果）</remarks>
		private string _prtBLGoodsName = "";

		/// <summary>販売区分コード</summary>
		private Int32 _salesCode;

		/// <summary>販売区分名称</summary>
		private string _salesCdNm = "";

		/// <summary>作業工数</summary>
		private Double _workManHour;

		/// <summary>出荷数</summary>
		private Double _shipmentCnt;

		/// <summary>受注数量</summary>
		/// <remarks>受注,出荷で使用</remarks>
		private Double _acceptAnOrderCnt;

		/// <summary>受注調整数</summary>
		/// <remarks>現在の受注数は「受注数量＋受注調整数」で算出</remarks>
		private Double _acptAnOdrAdjustCnt;

		/// <summary>受注残数</summary>
		/// <remarks>受注数量＋受注調整数－出荷数</remarks>
		private Double _acptAnOdrRemainCnt;

		/// <summary>残数更新日</summary>
		/// <remarks>YYYYMMDD</remarks>
		private DateTime _remainCntUpdDate;

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
		private Int64 _salesPriceConsTax;

		/// <summary>課税区分</summary>
		/// <remarks>0:課税,1:非課税,2:課税（内税）</remarks>
		private Int32 _taxationDivCd;

		/// <summary>相手先伝票番号（明細）</summary>
		/// <remarks>得意先注文番号（仮伝No）</remarks>
		private string _partySlipNumDtl = "";

		/// <summary>明細備考</summary>
		private string _dtlNote = "";

		/// <summary>仕入先コード</summary>
		private Int32 _supplierCd;

		/// <summary>仕入先略称</summary>
		private string _supplierSnm = "";

		/// <summary>発注番号</summary>
		private string _orderNumber = "";

		/// <summary>注文方法</summary>
		/// <remarks>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</remarks>
		private Int32 _wayToOrder;

		/// <summary>伝票メモ１</summary>
		private string _slipMemo1 = "";

		/// <summary>伝票メモ２</summary>
		private string _slipMemo2 = "";

		/// <summary>伝票メモ３</summary>
		private string _slipMemo3 = "";

		/// <summary>社内メモ１</summary>
		private string _insideMemo1 = "";

		/// <summary>社内メモ２</summary>
		private string _insideMemo2 = "";

		/// <summary>社内メモ３</summary>
		private string _insideMemo3 = "";

		/// <summary>変更前定価</summary>
		/// <remarks>税抜き、掛率算出結果</remarks>
		private Double _bfListPrice;

		/// <summary>変更前売価</summary>
		/// <remarks>税抜き、掛率算出結果</remarks>
		private Double _bfSalesUnitPrice;

		/// <summary>変更前原価</summary>
		/// <remarks>税抜き、掛率算出結果</remarks>
		private Double _bfUnitCost;

		/// <summary>一式明細番号</summary>
		/// <remarks>0:一式なし　1～一式連番</remarks>
		private Int32 _cmpltSalesRowNo;

		/// <summary>メーカーコード（一式）</summary>
		private Int32 _cmpltGoodsMakerCd;

		/// <summary>メーカー名称（一式）</summary>
		private string _cmpltMakerName = "";

		/// <summary>商品名称（一式）</summary>
		private string _cmpltGoodsName = "";

		/// <summary>数量（一式）</summary>
		private Double _cmpltShipmentCnt;

		/// <summary>売上単価（一式）</summary>
		/// <remarks>売上金額（一式の合計）/ 数量  ※少数第３位四捨五入</remarks>
		private Double _cmpltSalesUnPrcFl;

		/// <summary>売上金額（一式）</summary>
		/// <remarks>売上金額（税抜き）の同一一式明細の合計</remarks>
		private Int64 _cmpltSalesMoney;

		/// <summary>原価単価（一式）</summary>
		/// <remarks>原価金額（一式の合計）/ 数量  ※少数第３位四捨五入</remarks>
		private Double _cmpltSalesUnitCost;

		/// <summary>原価金額（一式）</summary>
		/// <remarks>原価の同一一式明細の合計</remarks>
		private Int64 _cmpltCost;

		/// <summary>相手先伝票番号（一式）</summary>
		/// <remarks>得意先注文番号</remarks>
		private string _cmpltPartySalSlNum = "";

		/// <summary>一式備考</summary>
		private string _cmpltNote = "";

        /// <summary>自動回答区分(SCM)</summary>
        /// <remarks>0:通常(PCC連携なし)、1:手動回答、2:自動回答</remarks>
        private Int32 _autoAnswerDivSCM;

        //---ADD 2011/11/11 ------------------------->>>>>
        /// <summary>受発注種別</summary>
        /// <remarks>0:PCCforNS　,1:BLﾊﾟｰﾂｵｰﾀﾞｰ</remarks>
        private Int16 _acceptOrOrderKind;
        //---ADD 2011/11/11 -------------------------<<<<<
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

		/// public propaty name  :  AcptAnOdrStatus
		/// <summary>受注ステータスプロパティ</summary>
		/// <value>10:見積,20:受注,30:売上,40:出荷,70:指示書,80:クレーム,99:一時保管  </value>
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

		/// public propaty name  :  SalesRowDerivNo
		/// <summary>売上行番号枝番プロパティ</summary>
		/// <value>検索見積の対比で使用する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上行番号枝番プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesRowDerivNo
		{
			get{return _salesRowDerivNo;}
			set{_salesRowDerivNo = value;}
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

		/// public propaty name  :  SectionGuideNm
		/// <summary>拠点ガイド名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   拠点ガイド名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SectionGuideNm
		{
			get{return _sectionGuideNm;}
			set{_sectionGuideNm = value;}
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

		/// public propaty name  :  SubSectionName
		/// <summary>部門名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部門名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SubSectionName
		{
			get{return _subSectionName;}
			set{_subSectionName = value;}
		}

		/// public propaty name  :  SalesDate
		/// <summary>売上日付プロパティ</summary>
		/// <value>YYYYMMDD</value>
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
		/// <value>0:売上,1:返品,2:値引,3:注釈,4:小計,5:作業</value>
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

		/// public propaty name  :  DeliGdsCmpltDueDate
		/// <summary>納品完了予定日プロパティ</summary>
		/// <value>客先納期(YYYYMMDD)</value>
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

		/// public propaty name  :  GoodsKindCode
		/// <summary>商品属性プロパティ</summary>
		/// <value>0:純正 1:優良</value>
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

		/// public propaty name  :  GoodsSearchDivCd
		/// <summary>商品検索区分プロパティ</summary>
		/// <value>0:BL検索 1:品番 2:手入力</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品検索区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsSearchDivCd
		{
			get{return _goodsSearchDivCd;}
			set{_goodsSearchDivCd = value;}
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

		/// public propaty name  :  GoodsLGroup
		/// <summary>商品大分類コードプロパティ</summary>
		/// <value>旧大分類（ユーザーガイド）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品大分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsLGroup
		{
			get{return _goodsLGroup;}
			set{_goodsLGroup = value;}
		}

		/// public propaty name  :  GoodsLGroupName
		/// <summary>商品大分類名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品大分類名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsLGroupName
		{
			get{return _goodsLGroupName;}
			set{_goodsLGroupName = value;}
		}

		/// public propaty name  :  GoodsMGroup
		/// <summary>商品中分類コードプロパティ</summary>
		/// <value>旧中分類コード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMGroup
		{
			get{return _goodsMGroup;}
			set{_goodsMGroup = value;}
		}

		/// public propaty name  :  GoodsMGroupName
		/// <summary>商品中分類名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品中分類名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsMGroupName
		{
			get{return _goodsMGroupName;}
			set{_goodsMGroupName = value;}
		}

		/// public propaty name  :  BLGroupCode
		/// <summary>BLグループコードプロパティ</summary>
		/// <value>旧グループコード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BLグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BLGroupCode
		{
			get{return _bLGroupCode;}
			set{_bLGroupCode = value;}
		}

		/// public propaty name  :  BLGroupName
		/// <summary>BLグループコード名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BLグループコード名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string BLGroupName
		{
			get{return _bLGroupName;}
			set{_bLGroupName = value;}
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
		/// <value>0:取寄せ，1:在庫</value>
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

		/// public propaty name  :  PrtBLGoodsCode
		/// <summary>BL商品コード（印刷）プロパティ</summary>
		/// <value>掛率算出時に使用したBLコード（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード（印刷）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrtBLGoodsCode
		{
			get{return _prtBLGoodsCode;}
			set{_prtBLGoodsCode = value;}
		}

		/// public propaty name  :  PrtBLGoodsName
		/// <summary>BL商品コード名称（印刷）プロパティ</summary>
		/// <value>掛率算出時に使用したBLコード名称（商品検索結果）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   BL商品コード名称（印刷）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrtBLGoodsName
		{
			get{return _prtBLGoodsName;}
			set{_prtBLGoodsName = value;}
		}

		/// public propaty name  :  SalesCode
		/// <summary>販売区分コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesCode
		{
			get{return _salesCode;}
			set{_salesCode = value;}
		}

		/// public propaty name  :  SalesCdNm
		/// <summary>販売区分名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   販売区分名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SalesCdNm
		{
			get{return _salesCdNm;}
			set{_salesCdNm = value;}
		}

		/// public propaty name  :  WorkManHour
		/// <summary>作業工数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   作業工数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double WorkManHour
		{
			get{return _workManHour;}
			set{_workManHour = value;}
		}

		/// public propaty name  :  ShipmentCnt
		/// <summary>出荷数プロパティ</summary>
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

		/// public propaty name  :  AcceptAnOrderCnt
		/// <summary>受注数量プロパティ</summary>
		/// <value>受注,出荷で使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注数量プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double AcceptAnOrderCnt
		{
			get{return _acceptAnOrderCnt;}
			set{_acceptAnOrderCnt = value;}
		}

		/// public propaty name  :  AcptAnOdrAdjustCnt
		/// <summary>受注調整数プロパティ</summary>
		/// <value>現在の受注数は「受注数量＋受注調整数」で算出</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   受注調整数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double AcptAnOdrAdjustCnt
		{
			get{return _acptAnOdrAdjustCnt;}
			set{_acptAnOdrAdjustCnt = value;}
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

		/// public propaty name  :  RemainCntUpdDate
		/// <summary>残数更新日プロパティ</summary>
		/// <value>YYYYMMDD</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   残数更新日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime RemainCntUpdDate
		{
			get{return _remainCntUpdDate;}
			set{_remainCntUpdDate = value;}
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

		/// public propaty name  :  SalesPriceConsTax
		/// <summary>売上金額消費税額プロパティ</summary>
		/// <value>売上金額（税込み）- 売上金額（税抜き）※消費税調整額も兼ねる</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上金額消費税額プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 SalesPriceConsTax
		{
			get{return _salesPriceConsTax;}
			set{_salesPriceConsTax = value;}
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
		/// <value>得意先注文番号（仮伝No）</value>
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

		/// public propaty name  :  OrderNumber
		/// <summary>発注番号プロパティ</summary>
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

		/// public propaty name  :  WayToOrder
		/// <summary>注文方法プロパティ</summary>
		/// <value>0:発注書発注,1:FAX送信,2:オンライン発注,4:発注済事後登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   注文方法プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 WayToOrder
		{
			get{return _wayToOrder;}
			set{_wayToOrder = value;}
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

		/// public propaty name  :  CmpltSalesRowNo
		/// <summary>一式明細番号プロパティ</summary>
		/// <value>0:一式なし　1～一式連番</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   一式明細番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CmpltSalesRowNo
		{
			get{return _cmpltSalesRowNo;}
			set{_cmpltSalesRowNo = value;}
		}

		/// public propaty name  :  CmpltGoodsMakerCd
		/// <summary>メーカーコード（一式）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカーコード（一式）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CmpltGoodsMakerCd
		{
			get{return _cmpltGoodsMakerCd;}
			set{_cmpltGoodsMakerCd = value;}
		}

		/// public propaty name  :  CmpltMakerName
		/// <summary>メーカー名称（一式）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   メーカー名称（一式）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmpltMakerName
		{
			get{return _cmpltMakerName;}
			set{_cmpltMakerName = value;}
		}

		/// public propaty name  :  CmpltGoodsName
		/// <summary>商品名称（一式）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称（一式）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmpltGoodsName
		{
			get{return _cmpltGoodsName;}
			set{_cmpltGoodsName = value;}
		}

		/// public propaty name  :  CmpltShipmentCnt
		/// <summary>数量（一式）プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   数量（一式）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double CmpltShipmentCnt
		{
			get{return _cmpltShipmentCnt;}
			set{_cmpltShipmentCnt = value;}
		}

		/// public propaty name  :  CmpltSalesUnPrcFl
		/// <summary>売上単価（一式）プロパティ</summary>
		/// <value>売上金額（一式の合計）/ 数量  ※少数第３位四捨五入</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上単価（一式）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double CmpltSalesUnPrcFl
		{
			get{return _cmpltSalesUnPrcFl;}
			set{_cmpltSalesUnPrcFl = value;}
		}

		/// public propaty name  :  CmpltSalesMoney
		/// <summary>売上金額（一式）プロパティ</summary>
		/// <value>売上金額（税抜き）の同一一式明細の合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上金額（一式）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 CmpltSalesMoney
		{
			get{return _cmpltSalesMoney;}
			set{_cmpltSalesMoney = value;}
		}

		/// public propaty name  :  CmpltSalesUnitCost
		/// <summary>原価単価（一式）プロパティ</summary>
		/// <value>原価金額（一式の合計）/ 数量  ※少数第３位四捨五入</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価単価（一式）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double CmpltSalesUnitCost
		{
			get{return _cmpltSalesUnitCost;}
			set{_cmpltSalesUnitCost = value;}
		}

		/// public propaty name  :  CmpltCost
		/// <summary>原価金額（一式）プロパティ</summary>
		/// <value>原価の同一一式明細の合計</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   原価金額（一式）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int64 CmpltCost
		{
			get{return _cmpltCost;}
			set{_cmpltCost = value;}
		}

		/// public propaty name  :  CmpltPartySalSlNum
		/// <summary>相手先伝票番号（一式）プロパティ</summary>
		/// <value>得意先注文番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   相手先伝票番号（一式）プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmpltPartySalSlNum
		{
			get{return _cmpltPartySalSlNum;}
			set{_cmpltPartySalSlNum = value;}
		}

		/// public propaty name  :  CmpltNote
		/// <summary>一式備考プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   一式備考プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmpltNote
		{
			get{return _cmpltNote;}
			set{_cmpltNote = value;}
		}

        /// public propaty name  :  AutoAnswerDivSCM
        /// <summary>自動回答区分(SCM)プロパティ</summary>
        /// <value>0:通常(PCC連携なし)、1:手動回答、2:自動回答</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動回答区分(SCM)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AutoAnswerDivSCM
        {
            get { return _autoAnswerDivSCM; }
            set { _autoAnswerDivSCM = value; }
        }

        //---ADD 2011/11/11 ----------------------->>>>>

        /// public propaty name  :  AcceptOrOrderKindRF
        /// <summary>受発注種別プロパティ</summary>
        /// <value>0:PCCforNS　,1:BLﾊﾟｰﾂｵｰﾀﾞｰ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受発注種別プロパティ</br>
        /// <br>Programer        :   鄧潘ハン</br>
        /// </remarks>
        public Int16 AcceptOrOrderKind
        {
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }
        //---ADD 2011/11/11 -----------------------<<<<<

		/// <summary>
		/// 売上伝票明細検索抽出結果ワークワークコンストラクタ
		/// </summary>
		/// <returns>SalesSlipDetailSearchResultWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SalesSlipDetailSearchResultWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SalesSlipDetailSearchResultWork()
		{
		}

	}
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SalesSlipDetailSearchResultWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SalesSlipDetailSearchResultWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SalesSlipDetailSearchResultWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipDetailSearchResultWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SalesSlipDetailSearchResultWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SalesSlipDetailSearchResultWork || graph is ArrayList || graph is SalesSlipDetailSearchResultWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SalesSlipDetailSearchResultWork).FullName));

            if (graph != null && graph is SalesSlipDetailSearchResultWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SalesSlipDetailSearchResultWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SalesSlipDetailSearchResultWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SalesSlipDetailSearchResultWork[])graph).Length;
            }
            else if (graph is SalesSlipDetailSearchResultWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //受注番号
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptAnOrderNo
            //受注ステータス
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatus
            //売上伝票番号
            serInfo.MemberInfo.Add(typeof(string)); //SalesSlipNum
            //売上行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowNo
            //売上行番号枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesRowDerivNo
            //拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //SectionCode
            //拠点ガイド名称
            serInfo.MemberInfo.Add(typeof(string)); //SectionGuideNm
            //部門コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SubSectionCode
            //部門名称
            serInfo.MemberInfo.Add(typeof(string)); //SubSectionName
            //売上日付
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesDate
            //共通通番
            serInfo.MemberInfo.Add(typeof(Int64)); //CommonSeqNo
            //売上明細通番
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNum
            //受注ステータス（元）
            serInfo.MemberInfo.Add(typeof(Int32)); //AcptAnOdrStatusSrc
            //売上明細通番（元）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesSlipDtlNumSrc
            //仕入形式（同時）
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierFormalSync
            //仕入明細通番（同時）
            serInfo.MemberInfo.Add(typeof(Int64)); //StockSlipDtlNumSync
            //売上伝票区分（明細）
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipCdDtl
            //納品完了予定日
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliGdsCmpltDueDate
            //商品属性
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsKindCode
            //商品検索区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsSearchDivCd
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //MakerName
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsName
            //商品大分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsLGroup
            //商品大分類名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsLGroupName
            //商品中分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMGroup
            //商品中分類名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMGroupName
            //BLグループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGroupCode
            //BLグループコード名称
            serInfo.MemberInfo.Add(typeof(string)); //BLGroupName
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード名称（全角）
            serInfo.MemberInfo.Add(typeof(string)); //BLGoodsFullName
            //自社分類コード
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseGanreCode
            //自社分類名称
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseGanreName
            //倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseCode
            //倉庫名称
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseName
            //倉庫棚番
            serInfo.MemberInfo.Add(typeof(string)); //WarehouseShelfNo
            //売上在庫取寄せ区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesOrderDivCd
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            //商品掛率ランク
            serInfo.MemberInfo.Add(typeof(string)); //GoodsRateRank
            //得意先掛率グループコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustRateGrpCode
            //定価率
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceRate
            //掛率設定拠点（定価）
            serInfo.MemberInfo.Add(typeof(string)); //RateSectPriceUnPrc
            //掛率設定区分（定価）
            serInfo.MemberInfo.Add(typeof(string)); //RateDivLPrice
            //単価算出区分（定価）
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdLPrice
            //価格区分（定価）
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdLPrice
            //基準単価（定価）
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcLPrice
            //端数処理単位（定価）
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitLPrice
            //端数処理（定価）
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcLPrice
            //定価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxIncFl
            //定価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //ListPriceTaxExcFl
            //定価変更区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPriceChngCd
            //売価率
            serInfo.MemberInfo.Add(typeof(Double)); //SalesRate
            //掛率設定拠点（売上単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateSectSalUnPrc
            //掛率設定区分（売上単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateDivSalUnPrc
            //単価算出区分（売上単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdSalUnPrc
            //価格区分（売上単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdSalUnPrc
            //基準単価（売上単価）
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcSalUnPrc
            //端数処理単位（売上単価）
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitSalUnPrc
            //端数処理（売上単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcSalUnPrc
            //売上単価（税込，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxIncFl
            //売上単価（税抜，浮動）
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnPrcTaxExcFl
            //売上単価変更区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcChngCd
            //原価率
            serInfo.MemberInfo.Add(typeof(Double)); //CostRate
            //掛率設定拠点（原価単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateSectCstUnPrc
            //掛率設定区分（原価単価）
            serInfo.MemberInfo.Add(typeof(string)); //RateDivUnCst
            //単価算出区分（原価単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //UnPrcCalcCdUnCst
            //価格区分（原価単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //PriceCdUnCst
            //基準単価（原価単価）
            serInfo.MemberInfo.Add(typeof(Double)); //StdUnPrcUnCst
            //端数処理単位（原価単価）
            serInfo.MemberInfo.Add(typeof(Double)); //FracProcUnitUnCst
            //端数処理（原価単価）
            serInfo.MemberInfo.Add(typeof(Int32)); //FracProcUnCst
            //原価単価
            serInfo.MemberInfo.Add(typeof(Double)); //SalesUnitCost
            //原価単価変更区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnitCostChngDiv
            //BL商品コード（掛率）
            serInfo.MemberInfo.Add(typeof(Int32)); //RateBLGoodsCode
            //BL商品コード名称（掛率）
            serInfo.MemberInfo.Add(typeof(string)); //RateBLGoodsName
            //BL商品コード（印刷）
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtBLGoodsCode
            //BL商品コード名称（印刷）
            serInfo.MemberInfo.Add(typeof(string)); //PrtBLGoodsName
            //販売区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCode
            //販売区分名称
            serInfo.MemberInfo.Add(typeof(string)); //SalesCdNm
            //作業工数
            serInfo.MemberInfo.Add(typeof(Double)); //WorkManHour
            //出荷数
            serInfo.MemberInfo.Add(typeof(Double)); //ShipmentCnt
            //受注数量
            serInfo.MemberInfo.Add(typeof(Double)); //AcceptAnOrderCnt
            //受注調整数
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrAdjustCnt
            //受注残数
            serInfo.MemberInfo.Add(typeof(Double)); //AcptAnOdrRemainCnt
            //残数更新日
            serInfo.MemberInfo.Add(typeof(Int32)); //RemainCntUpdDate
            //売上金額（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxInc
            //売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesMoneyTaxExc
            //原価
            serInfo.MemberInfo.Add(typeof(Int64)); //Cost
            //粗利チェック区分
            serInfo.MemberInfo.Add(typeof(Int32)); //GrsProfitChkDiv
            //売上商品区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesGoodsCd
            //売上金額消費税額
            serInfo.MemberInfo.Add(typeof(Int64)); //SalesPriceConsTax
            //課税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TaxationDivCd
            //相手先伝票番号（明細）
            serInfo.MemberInfo.Add(typeof(string)); //PartySlipNumDtl
            //明細備考
            serInfo.MemberInfo.Add(typeof(string)); //DtlNote
            //仕入先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SupplierCd
            //仕入先略称
            serInfo.MemberInfo.Add(typeof(string)); //SupplierSnm
            //発注番号
            serInfo.MemberInfo.Add(typeof(string)); //OrderNumber
            //注文方法
            serInfo.MemberInfo.Add(typeof(Int32)); //WayToOrder
            //伝票メモ１
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo1
            //伝票メモ２
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo2
            //伝票メモ３
            serInfo.MemberInfo.Add(typeof(string)); //SlipMemo3
            //社内メモ１
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo1
            //社内メモ２
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo2
            //社内メモ３
            serInfo.MemberInfo.Add(typeof(string)); //InsideMemo3
            //変更前定価
            serInfo.MemberInfo.Add(typeof(Double)); //BfListPrice
            //変更前売価
            serInfo.MemberInfo.Add(typeof(Double)); //BfSalesUnitPrice
            //変更前原価
            serInfo.MemberInfo.Add(typeof(Double)); //BfUnitCost
            //一式明細番号
            serInfo.MemberInfo.Add(typeof(Int32)); //CmpltSalesRowNo
            //メーカーコード（一式）
            serInfo.MemberInfo.Add(typeof(Int32)); //CmpltGoodsMakerCd
            //メーカー名称（一式）
            serInfo.MemberInfo.Add(typeof(string)); //CmpltMakerName
            //商品名称（一式）
            serInfo.MemberInfo.Add(typeof(string)); //CmpltGoodsName
            //数量（一式）
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltShipmentCnt
            //売上単価（一式）
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltSalesUnPrcFl
            //売上金額（一式）
            serInfo.MemberInfo.Add(typeof(Int64)); //CmpltSalesMoney
            //原価単価（一式）
            serInfo.MemberInfo.Add(typeof(Double)); //CmpltSalesUnitCost
            //原価金額（一式）
            serInfo.MemberInfo.Add(typeof(Int64)); //CmpltCost
            //相手先伝票番号（一式）
            serInfo.MemberInfo.Add(typeof(string)); //CmpltPartySalSlNum
            //一式備考
            serInfo.MemberInfo.Add(typeof(string)); //CmpltNote
            //自動回答区分(SCM)
            serInfo.MemberInfo.Add(typeof(Int32)); //AutoAnswerDivSCM
            //受発注種別
            serInfo.MemberInfo.Add(typeof(Int16)); //AcceptOrOrderKind// ADD 2011/11/11
            serInfo.Serialize(writer, serInfo);
            if (graph is SalesSlipDetailSearchResultWork)
            {
                SalesSlipDetailSearchResultWork temp = (SalesSlipDetailSearchResultWork)graph;

                SetSalesSlipDetailSearchResultWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SalesSlipDetailSearchResultWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SalesSlipDetailSearchResultWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SalesSlipDetailSearchResultWork temp in lst)
                {
                    SetSalesSlipDetailSearchResultWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SalesSlipDetailSearchResultWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 121; // DEL 2011/11/11
        private const int currentMemberCount = 122; //ADD 2011/11/11
        /// <summary>
        ///  SalesSlipDetailSearchResultWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipDetailSearchResultWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSalesSlipDetailSearchResultWork(System.IO.BinaryWriter writer, SalesSlipDetailSearchResultWork temp)
        {
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //受注番号
            writer.Write(temp.AcceptAnOrderNo);
            //受注ステータス
            writer.Write(temp.AcptAnOdrStatus);
            //売上伝票番号
            writer.Write(temp.SalesSlipNum);
            //売上行番号
            writer.Write(temp.SalesRowNo);
            //売上行番号枝番
            writer.Write(temp.SalesRowDerivNo);
            //拠点コード
            writer.Write(temp.SectionCode);
            //拠点ガイド名称
            writer.Write(temp.SectionGuideNm);
            //部門コード
            writer.Write(temp.SubSectionCode);
            //部門名称
            writer.Write(temp.SubSectionName);
            //売上日付
            writer.Write((Int64)temp.SalesDate.Ticks);
            //共通通番
            writer.Write(temp.CommonSeqNo);
            //売上明細通番
            writer.Write(temp.SalesSlipDtlNum);
            //受注ステータス（元）
            writer.Write(temp.AcptAnOdrStatusSrc);
            //売上明細通番（元）
            writer.Write(temp.SalesSlipDtlNumSrc);
            //仕入形式（同時）
            writer.Write(temp.SupplierFormalSync);
            //仕入明細通番（同時）
            writer.Write(temp.StockSlipDtlNumSync);
            //売上伝票区分（明細）
            writer.Write(temp.SalesSlipCdDtl);
            //納品完了予定日
            writer.Write((Int64)temp.DeliGdsCmpltDueDate.Ticks);
            //商品属性
            writer.Write(temp.GoodsKindCode);
            //商品検索区分
            writer.Write(temp.GoodsSearchDivCd);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //メーカー名称
            writer.Write(temp.MakerName);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品名称
            writer.Write(temp.GoodsName);
            //商品大分類コード
            writer.Write(temp.GoodsLGroup);
            //商品大分類名称
            writer.Write(temp.GoodsLGroupName);
            //商品中分類コード
            writer.Write(temp.GoodsMGroup);
            //商品中分類名称
            writer.Write(temp.GoodsMGroupName);
            //BLグループコード
            writer.Write(temp.BLGroupCode);
            //BLグループコード名称
            writer.Write(temp.BLGroupName);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード名称（全角）
            writer.Write(temp.BLGoodsFullName);
            //自社分類コード
            writer.Write(temp.EnterpriseGanreCode);
            //自社分類名称
            writer.Write(temp.EnterpriseGanreName);
            //倉庫コード
            writer.Write(temp.WarehouseCode);
            //倉庫名称
            writer.Write(temp.WarehouseName);
            //倉庫棚番
            writer.Write(temp.WarehouseShelfNo);
            //売上在庫取寄せ区分
            writer.Write(temp.SalesOrderDivCd);
            //オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            //商品掛率ランク
            writer.Write(temp.GoodsRateRank);
            //得意先掛率グループコード
            writer.Write(temp.CustRateGrpCode);
            //定価率
            writer.Write(temp.ListPriceRate);
            //掛率設定拠点（定価）
            writer.Write(temp.RateSectPriceUnPrc);
            //掛率設定区分（定価）
            writer.Write(temp.RateDivLPrice);
            //単価算出区分（定価）
            writer.Write(temp.UnPrcCalcCdLPrice);
            //価格区分（定価）
            writer.Write(temp.PriceCdLPrice);
            //基準単価（定価）
            writer.Write(temp.StdUnPrcLPrice);
            //端数処理単位（定価）
            writer.Write(temp.FracProcUnitLPrice);
            //端数処理（定価）
            writer.Write(temp.FracProcLPrice);
            //定価（税込，浮動）
            writer.Write(temp.ListPriceTaxIncFl);
            //定価（税抜，浮動）
            writer.Write(temp.ListPriceTaxExcFl);
            //定価変更区分
            writer.Write(temp.ListPriceChngCd);
            //売価率
            writer.Write(temp.SalesRate);
            //掛率設定拠点（売上単価）
            writer.Write(temp.RateSectSalUnPrc);
            //掛率設定区分（売上単価）
            writer.Write(temp.RateDivSalUnPrc);
            //単価算出区分（売上単価）
            writer.Write(temp.UnPrcCalcCdSalUnPrc);
            //価格区分（売上単価）
            writer.Write(temp.PriceCdSalUnPrc);
            //基準単価（売上単価）
            writer.Write(temp.StdUnPrcSalUnPrc);
            //端数処理単位（売上単価）
            writer.Write(temp.FracProcUnitSalUnPrc);
            //端数処理（売上単価）
            writer.Write(temp.FracProcSalUnPrc);
            //売上単価（税込，浮動）
            writer.Write(temp.SalesUnPrcTaxIncFl);
            //売上単価（税抜，浮動）
            writer.Write(temp.SalesUnPrcTaxExcFl);
            //売上単価変更区分
            writer.Write(temp.SalesUnPrcChngCd);
            //原価率
            writer.Write(temp.CostRate);
            //掛率設定拠点（原価単価）
            writer.Write(temp.RateSectCstUnPrc);
            //掛率設定区分（原価単価）
            writer.Write(temp.RateDivUnCst);
            //単価算出区分（原価単価）
            writer.Write(temp.UnPrcCalcCdUnCst);
            //価格区分（原価単価）
            writer.Write(temp.PriceCdUnCst);
            //基準単価（原価単価）
            writer.Write(temp.StdUnPrcUnCst);
            //端数処理単位（原価単価）
            writer.Write(temp.FracProcUnitUnCst);
            //端数処理（原価単価）
            writer.Write(temp.FracProcUnCst);
            //原価単価
            writer.Write(temp.SalesUnitCost);
            //原価単価変更区分
            writer.Write(temp.SalesUnitCostChngDiv);
            //BL商品コード（掛率）
            writer.Write(temp.RateBLGoodsCode);
            //BL商品コード名称（掛率）
            writer.Write(temp.RateBLGoodsName);
            //BL商品コード（印刷）
            writer.Write(temp.PrtBLGoodsCode);
            //BL商品コード名称（印刷）
            writer.Write(temp.PrtBLGoodsName);
            //販売区分コード
            writer.Write(temp.SalesCode);
            //販売区分名称
            writer.Write(temp.SalesCdNm);
            //作業工数
            writer.Write(temp.WorkManHour);
            //出荷数
            writer.Write(temp.ShipmentCnt);
            //受注数量
            writer.Write(temp.AcceptAnOrderCnt);
            //受注調整数
            writer.Write(temp.AcptAnOdrAdjustCnt);
            //受注残数
            writer.Write(temp.AcptAnOdrRemainCnt);
            //残数更新日
            writer.Write((Int64)temp.RemainCntUpdDate.Ticks);
            //売上金額（税込み）
            writer.Write(temp.SalesMoneyTaxInc);
            //売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            //原価
            writer.Write(temp.Cost);
            //粗利チェック区分
            writer.Write(temp.GrsProfitChkDiv);
            //売上商品区分
            writer.Write(temp.SalesGoodsCd);
            //売上金額消費税額
            writer.Write(temp.SalesPriceConsTax);
            //課税区分
            writer.Write(temp.TaxationDivCd);
            //相手先伝票番号（明細）
            writer.Write(temp.PartySlipNumDtl);
            //明細備考
            writer.Write(temp.DtlNote);
            //仕入先コード
            writer.Write(temp.SupplierCd);
            //仕入先略称
            writer.Write(temp.SupplierSnm);
            //発注番号
            writer.Write(temp.OrderNumber);
            //注文方法
            writer.Write(temp.WayToOrder);
            //伝票メモ１
            writer.Write(temp.SlipMemo1);
            //伝票メモ２
            writer.Write(temp.SlipMemo2);
            //伝票メモ３
            writer.Write(temp.SlipMemo3);
            //社内メモ１
            writer.Write(temp.InsideMemo1);
            //社内メモ２
            writer.Write(temp.InsideMemo2);
            //社内メモ３
            writer.Write(temp.InsideMemo3);
            //変更前定価
            writer.Write(temp.BfListPrice);
            //変更前売価
            writer.Write(temp.BfSalesUnitPrice);
            //変更前原価
            writer.Write(temp.BfUnitCost);
            //一式明細番号
            writer.Write(temp.CmpltSalesRowNo);
            //メーカーコード（一式）
            writer.Write(temp.CmpltGoodsMakerCd);
            //メーカー名称（一式）
            writer.Write(temp.CmpltMakerName);
            //商品名称（一式）
            writer.Write(temp.CmpltGoodsName);
            //数量（一式）
            writer.Write(temp.CmpltShipmentCnt);
            //売上単価（一式）
            writer.Write(temp.CmpltSalesUnPrcFl);
            //売上金額（一式）
            writer.Write(temp.CmpltSalesMoney);
            //原価単価（一式）
            writer.Write(temp.CmpltSalesUnitCost);
            //原価金額（一式）
            writer.Write(temp.CmpltCost);
            //相手先伝票番号（一式）
            writer.Write(temp.CmpltPartySalSlNum);
            //一式備考
            writer.Write(temp.CmpltNote);
            //自動回答区分(SCM)
            writer.Write(temp.AutoAnswerDivSCM);
            //受発注種別
            writer.Write(temp.AcceptOrOrderKind);// ADD 2011/11/11

        }

        /// <summary>
        ///  SalesSlipDetailSearchResultWorkインスタンス取得
        /// </summary>
        /// <returns>SalesSlipDetailSearchResultWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipDetailSearchResultWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SalesSlipDetailSearchResultWork GetSalesSlipDetailSearchResultWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SalesSlipDetailSearchResultWork temp = new SalesSlipDetailSearchResultWork();

            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //受注番号
            temp.AcceptAnOrderNo = reader.ReadInt32();
            //受注ステータス
            temp.AcptAnOdrStatus = reader.ReadInt32();
            //売上伝票番号
            temp.SalesSlipNum = reader.ReadString();
            //売上行番号
            temp.SalesRowNo = reader.ReadInt32();
            //売上行番号枝番
            temp.SalesRowDerivNo = reader.ReadInt32();
            //拠点コード
            temp.SectionCode = reader.ReadString();
            //拠点ガイド名称
            temp.SectionGuideNm = reader.ReadString();
            //部門コード
            temp.SubSectionCode = reader.ReadInt32();
            //部門名称
            temp.SubSectionName = reader.ReadString();
            //売上日付
            temp.SalesDate = new DateTime(reader.ReadInt64());
            //共通通番
            temp.CommonSeqNo = reader.ReadInt64();
            //売上明細通番
            temp.SalesSlipDtlNum = reader.ReadInt64();
            //受注ステータス（元）
            temp.AcptAnOdrStatusSrc = reader.ReadInt32();
            //売上明細通番（元）
            temp.SalesSlipDtlNumSrc = reader.ReadInt64();
            //仕入形式（同時）
            temp.SupplierFormalSync = reader.ReadInt32();
            //仕入明細通番（同時）
            temp.StockSlipDtlNumSync = reader.ReadInt64();
            //売上伝票区分（明細）
            temp.SalesSlipCdDtl = reader.ReadInt32();
            //納品完了予定日
            temp.DeliGdsCmpltDueDate = new DateTime(reader.ReadInt64());
            //商品属性
            temp.GoodsKindCode = reader.ReadInt32();
            //商品検索区分
            temp.GoodsSearchDivCd = reader.ReadInt32();
            //商品メーカーコード
            temp.GoodsMakerCd = reader.ReadInt32();
            //メーカー名称
            temp.MakerName = reader.ReadString();
            //商品番号
            temp.GoodsNo = reader.ReadString();
            //商品名称
            temp.GoodsName = reader.ReadString();
            //商品大分類コード
            temp.GoodsLGroup = reader.ReadInt32();
            //商品大分類名称
            temp.GoodsLGroupName = reader.ReadString();
            //商品中分類コード
            temp.GoodsMGroup = reader.ReadInt32();
            //商品中分類名称
            temp.GoodsMGroupName = reader.ReadString();
            //BLグループコード
            temp.BLGroupCode = reader.ReadInt32();
            //BLグループコード名称
            temp.BLGroupName = reader.ReadString();
            //BL商品コード
            temp.BLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（全角）
            temp.BLGoodsFullName = reader.ReadString();
            //自社分類コード
            temp.EnterpriseGanreCode = reader.ReadInt32();
            //自社分類名称
            temp.EnterpriseGanreName = reader.ReadString();
            //倉庫コード
            temp.WarehouseCode = reader.ReadString();
            //倉庫名称
            temp.WarehouseName = reader.ReadString();
            //倉庫棚番
            temp.WarehouseShelfNo = reader.ReadString();
            //売上在庫取寄せ区分
            temp.SalesOrderDivCd = reader.ReadInt32();
            //オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            //商品掛率ランク
            temp.GoodsRateRank = reader.ReadString();
            //得意先掛率グループコード
            temp.CustRateGrpCode = reader.ReadInt32();
            //定価率
            temp.ListPriceRate = reader.ReadDouble();
            //掛率設定拠点（定価）
            temp.RateSectPriceUnPrc = reader.ReadString();
            //掛率設定区分（定価）
            temp.RateDivLPrice = reader.ReadString();
            //単価算出区分（定価）
            temp.UnPrcCalcCdLPrice = reader.ReadInt32();
            //価格区分（定価）
            temp.PriceCdLPrice = reader.ReadInt32();
            //基準単価（定価）
            temp.StdUnPrcLPrice = reader.ReadDouble();
            //端数処理単位（定価）
            temp.FracProcUnitLPrice = reader.ReadDouble();
            //端数処理（定価）
            temp.FracProcLPrice = reader.ReadInt32();
            //定価（税込，浮動）
            temp.ListPriceTaxIncFl = reader.ReadDouble();
            //定価（税抜，浮動）
            temp.ListPriceTaxExcFl = reader.ReadDouble();
            //定価変更区分
            temp.ListPriceChngCd = reader.ReadInt32();
            //売価率
            temp.SalesRate = reader.ReadDouble();
            //掛率設定拠点（売上単価）
            temp.RateSectSalUnPrc = reader.ReadString();
            //掛率設定区分（売上単価）
            temp.RateDivSalUnPrc = reader.ReadString();
            //単価算出区分（売上単価）
            temp.UnPrcCalcCdSalUnPrc = reader.ReadInt32();
            //価格区分（売上単価）
            temp.PriceCdSalUnPrc = reader.ReadInt32();
            //基準単価（売上単価）
            temp.StdUnPrcSalUnPrc = reader.ReadDouble();
            //端数処理単位（売上単価）
            temp.FracProcUnitSalUnPrc = reader.ReadDouble();
            //端数処理（売上単価）
            temp.FracProcSalUnPrc = reader.ReadInt32();
            //売上単価（税込，浮動）
            temp.SalesUnPrcTaxIncFl = reader.ReadDouble();
            //売上単価（税抜，浮動）
            temp.SalesUnPrcTaxExcFl = reader.ReadDouble();
            //売上単価変更区分
            temp.SalesUnPrcChngCd = reader.ReadInt32();
            //原価率
            temp.CostRate = reader.ReadDouble();
            //掛率設定拠点（原価単価）
            temp.RateSectCstUnPrc = reader.ReadString();
            //掛率設定区分（原価単価）
            temp.RateDivUnCst = reader.ReadString();
            //単価算出区分（原価単価）
            temp.UnPrcCalcCdUnCst = reader.ReadInt32();
            //価格区分（原価単価）
            temp.PriceCdUnCst = reader.ReadInt32();
            //基準単価（原価単価）
            temp.StdUnPrcUnCst = reader.ReadDouble();
            //端数処理単位（原価単価）
            temp.FracProcUnitUnCst = reader.ReadDouble();
            //端数処理（原価単価）
            temp.FracProcUnCst = reader.ReadInt32();
            //原価単価
            temp.SalesUnitCost = reader.ReadDouble();
            //原価単価変更区分
            temp.SalesUnitCostChngDiv = reader.ReadInt32();
            //BL商品コード（掛率）
            temp.RateBLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（掛率）
            temp.RateBLGoodsName = reader.ReadString();
            //BL商品コード（印刷）
            temp.PrtBLGoodsCode = reader.ReadInt32();
            //BL商品コード名称（印刷）
            temp.PrtBLGoodsName = reader.ReadString();
            //販売区分コード
            temp.SalesCode = reader.ReadInt32();
            //販売区分名称
            temp.SalesCdNm = reader.ReadString();
            //作業工数
            temp.WorkManHour = reader.ReadDouble();
            //出荷数
            temp.ShipmentCnt = reader.ReadDouble();
            //受注数量
            temp.AcceptAnOrderCnt = reader.ReadDouble();
            //受注調整数
            temp.AcptAnOdrAdjustCnt = reader.ReadDouble();
            //受注残数
            temp.AcptAnOdrRemainCnt = reader.ReadDouble();
            //残数更新日
            temp.RemainCntUpdDate = new DateTime(reader.ReadInt64());
            //売上金額（税込み）
            temp.SalesMoneyTaxInc = reader.ReadInt64();
            //売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            //原価
            temp.Cost = reader.ReadInt64();
            //粗利チェック区分
            temp.GrsProfitChkDiv = reader.ReadInt32();
            //売上商品区分
            temp.SalesGoodsCd = reader.ReadInt32();
            //売上金額消費税額
            temp.SalesPriceConsTax = reader.ReadInt64();
            //課税区分
            temp.TaxationDivCd = reader.ReadInt32();
            //相手先伝票番号（明細）
            temp.PartySlipNumDtl = reader.ReadString();
            //明細備考
            temp.DtlNote = reader.ReadString();
            //仕入先コード
            temp.SupplierCd = reader.ReadInt32();
            //仕入先略称
            temp.SupplierSnm = reader.ReadString();
            //発注番号
            temp.OrderNumber = reader.ReadString();
            //注文方法
            temp.WayToOrder = reader.ReadInt32();
            //伝票メモ１
            temp.SlipMemo1 = reader.ReadString();
            //伝票メモ２
            temp.SlipMemo2 = reader.ReadString();
            //伝票メモ３
            temp.SlipMemo3 = reader.ReadString();
            //社内メモ１
            temp.InsideMemo1 = reader.ReadString();
            //社内メモ２
            temp.InsideMemo2 = reader.ReadString();
            //社内メモ３
            temp.InsideMemo3 = reader.ReadString();
            //変更前定価
            temp.BfListPrice = reader.ReadDouble();
            //変更前売価
            temp.BfSalesUnitPrice = reader.ReadDouble();
            //変更前原価
            temp.BfUnitCost = reader.ReadDouble();
            //一式明細番号
            temp.CmpltSalesRowNo = reader.ReadInt32();
            //メーカーコード（一式）
            temp.CmpltGoodsMakerCd = reader.ReadInt32();
            //メーカー名称（一式）
            temp.CmpltMakerName = reader.ReadString();
            //商品名称（一式）
            temp.CmpltGoodsName = reader.ReadString();
            //数量（一式）
            temp.CmpltShipmentCnt = reader.ReadDouble();
            //売上単価（一式）
            temp.CmpltSalesUnPrcFl = reader.ReadDouble();
            //売上金額（一式）
            temp.CmpltSalesMoney = reader.ReadInt64();
            //原価単価（一式）
            temp.CmpltSalesUnitCost = reader.ReadDouble();
            //原価金額（一式）
            temp.CmpltCost = reader.ReadInt64();
            //相手先伝票番号（一式）
            temp.CmpltPartySalSlNum = reader.ReadString();
            //一式備考
            temp.CmpltNote = reader.ReadString();
            //自動回答区分(SCM)
            temp.AutoAnswerDivSCM = reader.ReadInt32();
            //受発注種別
            temp.AcceptOrOrderKind = reader.ReadInt16(); // ADD 2011/11/11

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
        /// <returns>SalesSlipDetailSearchResultWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SalesSlipDetailSearchResultWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SalesSlipDetailSearchResultWork temp = GetSalesSlipDetailSearchResultWork(reader, serInfo);
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
                    retValue = (SalesSlipDetailSearchResultWork[])lst.ToArray(typeof(SalesSlipDetailSearchResultWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}
