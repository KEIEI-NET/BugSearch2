//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 商品連結データクラス
// プログラム概要   : 商品抽出条件パラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 :              作成担当 : 
// 作 成 日 : 2008/10/01   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 : 11470007-00  作成担当 : 30757 佐々木　貴英
// 作 成 日 : 2018/04/05   修正内容 : NS3Ai対応（BL統一部品コード対応）
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Application.UIData
{
	/// public class name:   GoodsCndtn
	/// <summary>
	///                      商品抽出条件クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   商品抽出条件クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/10/1</br>
	/// <br>Genarated Date   :   2009/02/13  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note      :   2009/12/18　21024 佐々木 健</br>
    /// <br>                     論理削除モードを追加(MANTIS[0014661])</br>
    /// <br></br>
    /// <br>Update Note      :   2011/05/18　22018 鈴木 正臣</br>
    /// <br>                     SCM改良　BLコード枝番を追加</br>
    /// <br>Update Note      :   2015/08/17 田建委</br>
    /// <br>                     Redmine#47036 商品在庫一括登録修正 管理拠点・倉庫の追加</br>
    /// <br>Update Note      :   2018/04/05  30757 佐々木　貴英</br>
    /// <br>管理番号         :   11470007-00</br>
    /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
    /// <br>                     BL統一部品コード関連メンバーの追加</br>
    /// </remarks>
	public class GoodsCndtn
	{
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>商品メーカーコード</summary>
		private Int32 _goodsMakerCd;

		/// <summary>メーカー名称</summary>
		private string _makerName = "";

		/// <summary>商品番号</summary>
		private string _goodsNo = "";

		/// <summary>商品番号検索区分</summary>
		/// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致</remarks>
		private Int32 _goodsNoSrchTyp;

		/// <summary>商品名称</summary>
		private string _goodsName = "";

		/// <summary>商品名称検索区分</summary>
		/// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致</remarks>
		private Int32 _goodsNameSrchTyp;

		/// <summary>商品名称カナ</summary>
		private string _goodsNameKana = "";

		/// <summary>商品カナ名称検索区分</summary>
		/// <remarks>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致</remarks>
		private Int32 _goodsNameKanaSrchTyp;

		/// <summary>JANコード</summary>
		/// <remarks>標準タイプ13桁または短縮タイプ8桁のJANコード</remarks>
		private string _jan = "";

		/// <summary>BL商品コード</summary>
		private Int32 _bLGoodsCode;

		/// <summary>商品大分類コード</summary>
		/// <remarks>旧大分類（ユーザーガイド）</remarks>
		private Int32 _goodsLGroup;

		/// <summary>商品大分類名称</summary>
		private string _goodsLGroupName = "";

		/// <summary>商品中分類コード</summary>
		/// <remarks>旧中分類（マスタ有）</remarks>
		private Int32 _goodsMGroup;

		/// <summary>商品中分類名称</summary>
		private string _goodsMGroupName = "";

		/// <summary>BLグループコード</summary>
		/// <remarks>旧グループコード</remarks>
		private Int32 _bLGroupCode;

		/// <summary>BLグループコード名称</summary>
		private string _bLGroupName = "";

		/// <summary>商品属性</summary>
		/// <remarks>9:全て対象</remarks>
		private Int32 _goodsKindCode;

		/// <summary>拠点コード</summary>
		private string _sectionCode = "";

		/// <summary>結合検索区分</summary>
		/// <remarks>0:結合検索なし,1:結合検索あり</remarks>
		private Int32 _joinSearchDiv;

		/// <summary>車両検索結果クラス</summary>
		/// <remarks>BLコード検索時のみ使用</remarks>
		private PMKEN01010E _searchCarInfo;

		/// <summary>代替条件区分</summary>
		/// <remarks>0:代替しない,1:代替する(在庫無),2:代替する(在庫無視)　エントリからの部品検索時のみ有効</remarks>
		private Int32 _substCondDivCd;

		/// <summary>優良代替条件区分</summary>
		/// <remarks>0:代替しない,1:代替する(在庫無),2:代替する(在庫無視)　エントリからの部品検索時のみ有効</remarks>
		private Int32 _prmSubstCondDivCd;

		/// <summary>代替適用区分</summary>
		/// <remarks>0:しない,1:する(結合、セット),2:全て(結合、セット、純正)　エントリからの部品検索時のみ有効</remarks>
		private Int32 _substApplyDivCd;

		/// <summary>検索画面制御区分</summary>
		/// <remarks>0:PM7,1:PM.NS　エントリからの部品検索時のみ有効</remarks>
		private Int32 _searchUICntDivCd;

		/// <summary>エンターキー処理区分</summary>
		/// <remarks>0:PM7,1:選択,2:次画面　エントリからの部品検索時のみ有効</remarks>
		private Int32 _enterProcDivCd;

		/// <summary>品番検索区分</summary>
		/// <remarks>0:PM7(セットのみ),1:結合・セット・代替あり　エントリからの部品検索時のみ有効</remarks>
		private Int32 _partsNoSearchDivCd;

		/// <summary>品番結合制御区分</summary>
		/// <remarks>初期値”.”　エントリからの部品検索時のみ有効</remarks>
		private string _partsJoinCntDivCd = "";

		/// <summary>元号表示区分１</summary>
		/// <remarks>0:西暦,1:和歴（年式）　エントリからの部品検索時のみ有効</remarks>
		private Int32 _eraNameDispCd1;

		/// <summary>部品検索優先順区分</summary>
		/// <remarks>0:純正,1:優良</remarks>
		private Int32 _partsSearchPriDivCd;

		/// <summary>結合初期表示区分</summary>
		/// <remarks>0:表示順,1:在庫順</remarks>
		private Int32 _joinInitDispDiv;

		/// <summary>得意先コード</summary>
		/// <remarks>単価算出用</remarks>
		private Int32 _customerCode;

		/// <summary>得意先掛率グループコード</summary>
		/// <remarks>単価算出用</remarks>
		private Int32 _custRateGrpCode;

		/// <summary>価格適用日</summary>
		/// <remarks>単価算出用</remarks>
		private DateTime _priceApplyDate;

		/// <summary>売上単価端数処理コード</summary>
		/// <remarks>単価算出用</remarks>
		private Int32 _salesUnPrcFrcProcCd;

		/// <summary>仕入単価端数処理コード</summary>
		/// <remarks>単価算出用</remarks>
		private Int32 _stockUnPrcFrcProcCd;

		/// <summary>税率</summary>
		/// <remarks>単価算出用</remarks>
		private Double _taxRate;

		/// <summary>総額表示方法区分</summary>
		/// <remarks>単価算出用</remarks>
		private Int32 _totalAmountDispWayCd;

		/// <summary>総額表示掛率適用区分</summary>
		/// <remarks>単価算出用</remarks>
		private Int32 _ttlAmntDspRateDivCd;

		/// <summary>売上消費税端数処理コード</summary>
		/// <remarks>単価算出用</remarks>
		private Int32 _salesCnsTaxFrcProcCd;

		/// <summary>仕入消費税端数処理コード</summary>
		/// <remarks>単価算出用</remarks>
		private Int32 _stockCnsTaxFrcProcCd;

		/// <summary>優先倉庫コードリスト</summary>
		/// <remarks>同一品番選択ウインドウの初期選択在庫情報の決定に使用</remarks>
		private List<string> _listPriorWarehouse;

		/// <summary>仕入先情報取得区分</summary>
		/// <remarks>0:設定あり 1:設定なし</remarks>
		private Int32 _isSettingSupplier;

		/// <summary>消費税転嫁方式</summary>
		/// <remarks>0:伝票転嫁 1:明細転嫁 2:請求親 3:請求子 9:非課税</remarks>
		private Int32 _consTaxLayMethod;

		/// <summary>不足情報設定区分</summary>
		/// <remarks>0:設定あり 1:設定なし</remarks>
		private Int32 _isSettingVariousMst;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>BL商品コード名称</summary>
		private string _bLGoodsName = "";

        // 2009/12/18 Add >>>
        /// <summary>論理削除モード</summary>
        private int _logicalMode = 0;
        // 2009/12/18 Add <<<
        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>BLコード枝番</summary>
        private int _bLGoodsDrCode = 0;
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        //----- ADD 2015/08/17 田建委 Redmine#47036 ---------->>>>>
        /// <summary>管理拠点コード</summary>
        private string _addUpSectionCode = "";

        /// <summary>倉庫コード</summary>
        private string _warehouseCode = "";
        //----- ADD 2015/08/17 田建委 Redmine#47036 ----------<<<<<

        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        /// <summary>BL統一部品コード(スリーコード版)</summary>
        private string _blUtyPtThCd = string.Empty;
        /// <summary>BL統一部品サブコード</summary>
        private Int32 _blUtyPtSbCd = 0;
        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

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

		/// public propaty name  :  GoodsNoSrchTyp
		/// <summary>商品番号検索区分プロパティ</summary>
		/// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品番号検索区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsNoSrchTyp
		{
			get{return _goodsNoSrchTyp;}
			set{_goodsNoSrchTyp = value;}
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

		/// public propaty name  :  GoodsNameSrchTyp
		/// <summary>商品名称検索区分プロパティ</summary>
		/// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称検索区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsNameSrchTyp
		{
			get{return _goodsNameSrchTyp;}
			set{_goodsNameSrchTyp = value;}
		}

		/// public propaty name  :  GoodsNameKana
		/// <summary>商品名称カナプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品名称カナプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsNameKana
		{
			get{return _goodsNameKana;}
			set{_goodsNameKana = value;}
		}

		/// public propaty name  :  GoodsNameKanaSrchTyp
		/// <summary>商品カナ名称検索区分プロパティ</summary>
		/// <value>0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品カナ名称検索区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsNameKanaSrchTyp
		{
			get{return _goodsNameKanaSrchTyp;}
			set{_goodsNameKanaSrchTyp = value;}
		}

		/// public propaty name  :  Jan
		/// <summary>JANコードプロパティ</summary>
		/// <value>標準タイプ13桁または短縮タイプ8桁のJANコード</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   JANコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Jan
		{
			get{return _jan;}
			set{_jan = value;}
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
		/// <value>旧中分類（マスタ有）</value>
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

		/// public propaty name  :  GoodsKindCode
		/// <summary>商品属性プロパティ</summary>
		/// <value>9:全て対象</value>
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

		/// public propaty name  :  JoinSearchDiv
		/// <summary>結合検索区分プロパティ</summary>
		/// <value>0:結合検索なし,1:結合検索あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合検索区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinSearchDiv
		{
			get{return _joinSearchDiv;}
			set{_joinSearchDiv = value;}
		}

		/// public propaty name  :  SearchCarInfo
		/// <summary>車両検索結果クラスプロパティ</summary>
		/// <value>BLコード検索時のみ使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   車両検索結果クラスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PMKEN01010E SearchCarInfo
		{
			get{return _searchCarInfo;}
			set{_searchCarInfo = value;}
		}

		/// public propaty name  :  SubstCondDivCd
		/// <summary>代替条件区分プロパティ</summary>
		/// <value>0:代替しない,1:代替する(在庫無),2:代替する(在庫無視)　エントリからの部品検索時のみ有効</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   代替条件区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SubstCondDivCd
		{
			get{return _substCondDivCd;}
			set{_substCondDivCd = value;}
		}

		/// public propaty name  :  PrmSubstCondDivCd
		/// <summary>優良代替条件区分プロパティ</summary>
		/// <value>0:代替しない,1:代替する(在庫無),2:代替する(在庫無視)　エントリからの部品検索時のみ有効</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優良代替条件区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrmSubstCondDivCd
		{
			get{return _prmSubstCondDivCd;}
			set{_prmSubstCondDivCd = value;}
		}

		/// public propaty name  :  SubstApplyDivCd
		/// <summary>代替適用区分プロパティ</summary>
		/// <value>0:しない,1:する(結合、セット),2:全て(結合、セット、純正)　エントリからの部品検索時のみ有効</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   代替適用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SubstApplyDivCd
		{
			get{return _substApplyDivCd;}
			set{_substApplyDivCd = value;}
		}

		/// public propaty name  :  SearchUICntDivCd
		/// <summary>検索画面制御区分プロパティ</summary>
		/// <value>0:PM7,1:PM.NS　エントリからの部品検索時のみ有効</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   検索画面制御区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SearchUICntDivCd
		{
			get{return _searchUICntDivCd;}
			set{_searchUICntDivCd = value;}
		}

		/// public propaty name  :  EnterProcDivCd
		/// <summary>エンターキー処理区分プロパティ</summary>
		/// <value>0:PM7,1:選択,2:次画面　エントリからの部品検索時のみ有効</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   エンターキー処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EnterProcDivCd
		{
			get{return _enterProcDivCd;}
			set{_enterProcDivCd = value;}
		}

		/// public propaty name  :  PartsNoSearchDivCd
		/// <summary>品番検索区分プロパティ</summary>
		/// <value>0:PM7(セットのみ),1:結合・セット・代替あり　エントリからの部品検索時のみ有効</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品番検索区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PartsNoSearchDivCd
		{
			get{return _partsNoSearchDivCd;}
			set{_partsNoSearchDivCd = value;}
		}

		/// public propaty name  :  PartsJoinCntDivCd
		/// <summary>品番結合制御区分プロパティ</summary>
		/// <value>初期値”.”　エントリからの部品検索時のみ有効</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   品番結合制御区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PartsJoinCntDivCd
		{
			get{return _partsJoinCntDivCd;}
			set{_partsJoinCntDivCd = value;}
		}

		/// public propaty name  :  EraNameDispCd1
		/// <summary>元号表示区分１プロパティ</summary>
		/// <value>0:西暦,1:和歴（年式）　エントリからの部品検索時のみ有効</value>
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

		/// public propaty name  :  PartsSearchPriDivCd
		/// <summary>部品検索優先順区分プロパティ</summary>
		/// <value>0:純正,1:優良</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   部品検索優先順区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PartsSearchPriDivCd
		{
			get{return _partsSearchPriDivCd;}
			set{_partsSearchPriDivCd = value;}
		}

		/// public propaty name  :  JoinInitDispDiv
		/// <summary>結合初期表示区分プロパティ</summary>
		/// <value>0:表示順,1:在庫順</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   結合初期表示区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 JoinInitDispDiv
		{
			get{return _joinInitDispDiv;}
			set{_joinInitDispDiv = value;}
		}

		/// public propaty name  :  CustomerCode
		/// <summary>得意先コードプロパティ</summary>
		/// <value>単価算出用</value>
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

		/// public propaty name  :  CustRateGrpCode
		/// <summary>得意先掛率グループコードプロパティ</summary>
		/// <value>単価算出用</value>
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

		/// public propaty name  :  PriceApplyDate
		/// <summary>価格適用日プロパティ</summary>
		/// <value>単価算出用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   価格適用日プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DateTime PriceApplyDate
		{
			get{return _priceApplyDate;}
			set{_priceApplyDate = value;}
		}

		/// public propaty name  :  SalesUnPrcFrcProcCd
		/// <summary>売上単価端数処理コードプロパティ</summary>
		/// <value>単価算出用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上単価端数処理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesUnPrcFrcProcCd
		{
			get{return _salesUnPrcFrcProcCd;}
			set{_salesUnPrcFrcProcCd = value;}
		}

		/// public propaty name  :  StockUnPrcFrcProcCd
		/// <summary>仕入単価端数処理コードプロパティ</summary>
		/// <value>単価算出用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入単価端数処理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockUnPrcFrcProcCd
		{
			get{return _stockUnPrcFrcProcCd;}
			set{_stockUnPrcFrcProcCd = value;}
		}

		/// public propaty name  :  TaxRate
		/// <summary>税率プロパティ</summary>
		/// <value>単価算出用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   税率プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double TaxRate
		{
			get{return _taxRate;}
			set{_taxRate = value;}
		}

		/// public propaty name  :  TotalAmountDispWayCd
		/// <summary>総額表示方法区分プロパティ</summary>
		/// <value>単価算出用</value>
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

		/// public propaty name  :  TtlAmntDspRateDivCd
		/// <summary>総額表示掛率適用区分プロパティ</summary>
		/// <value>単価算出用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   総額表示掛率適用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TtlAmntDspRateDivCd
		{
			get{return _ttlAmntDspRateDivCd;}
			set{_ttlAmntDspRateDivCd = value;}
		}

		/// public propaty name  :  SalesCnsTaxFrcProcCd
		/// <summary>売上消費税端数処理コードプロパティ</summary>
		/// <value>単価算出用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   売上消費税端数処理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SalesCnsTaxFrcProcCd
		{
			get{return _salesCnsTaxFrcProcCd;}
			set{_salesCnsTaxFrcProcCd = value;}
		}

		/// public propaty name  :  StockCnsTaxFrcProcCd
		/// <summary>仕入消費税端数処理コードプロパティ</summary>
		/// <value>単価算出用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入消費税端数処理コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 StockCnsTaxFrcProcCd
		{
			get{return _stockCnsTaxFrcProcCd;}
			set{_stockCnsTaxFrcProcCd = value;}
		}

		/// public propaty name  :  ListPriorWarehouse
		/// <summary>優先倉庫コードリストプロパティ</summary>
		/// <value>同一品番選択ウインドウの初期選択在庫情報の決定に使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   優先倉庫コードリストプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public List<string> ListPriorWarehouse
		{
			get{return _listPriorWarehouse;}
			set{_listPriorWarehouse = value;}
		}

		/// public propaty name  :  IsSettingSupplier
		/// <summary>仕入先情報取得区分プロパティ</summary>
		/// <value>0:設定あり 1:設定なし</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   仕入先情報取得区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 IsSettingSupplier
		{
			get{return _isSettingSupplier;}
			set{_isSettingSupplier = value;}
		}

		/// public propaty name  :  ConsTaxLayMethod
		/// <summary>消費税転嫁方式プロパティ</summary>
		/// <value>0:伝票転嫁 1:明細転嫁 2:請求親 3:請求子 9:非課税</value>
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

		/// public propaty name  :  IsSettingVariousMst
		/// <summary>不足情報設定区分プロパティ</summary>
		/// <value>0:設定あり 1:設定なし</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   不足情報設定区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 IsSettingVariousMst
		{
			get{return _isSettingVariousMst;}
			set{_isSettingVariousMst = value;}
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

        // 2009/12/18 Add >>>
        /// public propaty name  :  LogicalMode
        /// <summary>論理削除モードプロパティ</summary>
        public Int32 LogicalMode
        {
            get { return _logicalMode; }
            set { _logicalMode = value; }
        }
        // 2009/12/18 Add <<<
        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// public propaty name  :  BLGoodsDrCode
        /// <summary>BLコード枝番プロパティ</summary>
        public Int32 BLGoodsDrCode
        {
            get { return _bLGoodsDrCode; }
            set { _bLGoodsDrCode = value; }
        }
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        //----- ADD 2015/08/17 田建委 Redmine#47036 ---------->>>>>
        /// public propaty name  :  AddUpSectionCode
        /// <summary>管理拠点プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AddUpSectionCode
        {
            get { return _addUpSectionCode; }
            set { _addUpSectionCode = value; }
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
            get { return _warehouseCode; }
            set { _warehouseCode = value; }
        }
        //----- ADD 2015/08/17 田建委 Redmine#47036 ----------<<<<<

        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        /// <summary>BL統一部品コード(スリーコード版)パラメータ</summary>
        /// <value>BL統一部品コード(スリーコード版)</value>
        /// <remarks>
        /// <br>Note       : BL統一部品コード(スリーコード版)の取得と設定</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>管理番号   : 11470007-00</br>
        /// <br>           : NS3Ai対応（BL統一部品コード対応）</br>
        /// </remarks>
        public string BlUtyPtThCd
        {
            get { return this._blUtyPtThCd; }
            set { this._blUtyPtThCd = value; }
        }
        /// <summary>BL統一部品サブコードパラメータ</summary>
        /// <value>BL統一部品サブコード</value>
        /// <remarks>
        /// <br>Note       : BL統一部品サブコードの取得と設定</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>管理番号   : 11470007-00</br>
        /// <br>           : NS3Ai対応（BL統一部品コード対応）</br>
        /// </remarks>
        public Int32 BlUtyPtSbCd
        {
            get { return this._blUtyPtSbCd; }
            set { this._blUtyPtSbCd = value; }
        }
        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

		/// <summary>
		/// 商品抽出条件クラスコンストラクタ
		/// </summary>
		/// <returns>GoodsCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public GoodsCndtn()
		{
		}

		/// <summary>
		/// 商品抽出条件クラスコンストラクタ
		/// </summary>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="goodsMakerCd">商品メーカーコード</param>
		/// <param name="makerName">メーカー名称</param>
		/// <param name="goodsNo">商品番号</param>
		/// <param name="goodsNoSrchTyp">商品番号検索区分(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致)</param>
		/// <param name="goodsName">商品名称</param>
		/// <param name="goodsNameSrchTyp">商品名称検索区分(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致)</param>
		/// <param name="goodsNameKana">商品名称カナ</param>
		/// <param name="goodsNameKanaSrchTyp">商品カナ名称検索区分(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致)</param>
		/// <param name="jan">JANコード(標準タイプ13桁または短縮タイプ8桁のJANコード)</param>
		/// <param name="bLGoodsCode">BL商品コード</param>
		/// <param name="goodsLGroup">商品大分類コード(旧大分類（ユーザーガイド）)</param>
		/// <param name="goodsLGroupName">商品大分類名称</param>
		/// <param name="goodsMGroup">商品中分類コード(旧中分類（マスタ有）)</param>
		/// <param name="goodsMGroupName">商品中分類名称</param>
		/// <param name="bLGroupCode">BLグループコード(旧グループコード)</param>
		/// <param name="bLGroupName">BLグループコード名称</param>
		/// <param name="goodsKindCode">商品属性(9:全て対象)</param>
		/// <param name="sectionCode">拠点コード</param>
		/// <param name="joinSearchDiv">結合検索区分(0:結合検索なし,1:結合検索あり)</param>
		/// <param name="searchCarInfo">車両検索結果クラス(BLコード検索時のみ使用)</param>
		/// <param name="substCondDivCd">代替条件区分(0:代替しない,1:代替する(在庫無),2:代替する(在庫無視)　エントリからの部品検索時のみ有効)</param>
		/// <param name="prmSubstCondDivCd">優良代替条件区分(0:代替しない,1:代替する(在庫無),2:代替する(在庫無視)　エントリからの部品検索時のみ有効)</param>
		/// <param name="substApplyDivCd">代替適用区分(0:しない,1:する(結合、セット),2:全て(結合、セット、純正)　エントリからの部品検索時のみ有効)</param>
		/// <param name="searchUICntDivCd">検索画面制御区分(0:PM7,1:PM.NS　エントリからの部品検索時のみ有効)</param>
		/// <param name="enterProcDivCd">エンターキー処理区分(0:PM7,1:選択,2:次画面　エントリからの部品検索時のみ有効)</param>
		/// <param name="partsNoSearchDivCd">品番検索区分(0:PM7(セットのみ),1:結合・セット・代替あり　エントリからの部品検索時のみ有効)</param>
		/// <param name="partsJoinCntDivCd">品番結合制御区分(初期値”.”　エントリからの部品検索時のみ有効)</param>
		/// <param name="eraNameDispCd1">元号表示区分１(0:西暦,1:和歴（年式）　エントリからの部品検索時のみ有効)</param>
		/// <param name="partsSearchPriDivCd">部品検索優先順区分(0:純正,1:優良)</param>
		/// <param name="joinInitDispDiv">結合初期表示区分(0:表示順,1:在庫順)</param>
		/// <param name="customerCode">得意先コード(単価算出用)</param>
		/// <param name="custRateGrpCode">得意先掛率グループコード(単価算出用)</param>
		/// <param name="priceApplyDate">価格適用日(単価算出用)</param>
		/// <param name="salesUnPrcFrcProcCd">売上単価端数処理コード(単価算出用)</param>
		/// <param name="stockUnPrcFrcProcCd">仕入単価端数処理コード(単価算出用)</param>
		/// <param name="taxRate">税率(単価算出用)</param>
		/// <param name="totalAmountDispWayCd">総額表示方法区分(単価算出用)</param>
		/// <param name="ttlAmntDspRateDivCd">総額表示掛率適用区分(単価算出用)</param>
		/// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード(単価算出用)</param>
		/// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード(単価算出用)</param>
		/// <param name="listPriorWarehouse">優先倉庫コードリスト(同一品番選択ウインドウの初期選択在庫情報の決定に使用)</param>
		/// <param name="isSettingSupplier">仕入先情報取得区分(0:設定あり 1:設定なし)</param>
		/// <param name="consTaxLayMethod">消費税転嫁方式(0:伝票転嫁 1:明細転嫁 2:請求親 3:請求子 9:非課税)</param>
		/// <param name="isSettingVariousMst">不足情報設定区分(0:設定あり 1:設定なし)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="bLGoodsName">BL商品コード名称</param>
		/// <returns>GoodsCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsCndtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2015/08/17 田建委</br>
        /// <br>                     Redmine#47036 商品在庫一括登録修正 管理拠点・倉庫の追加</br>
		/// </remarks>
        // --- UPD m.suzuki 2011/05/18 ---------->>>>>
        //// 2009/12/18 >>>
        ////public GoodsCndtn(string enterpriseCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNameSrchTyp, string goodsNameKana, Int32 goodsNameKanaSrchTyp, string jan, Int32 bLGoodsCode, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 goodsKindCode, string sectionCode, Int32 joinSearchDiv, PMKEN01010E searchCarInfo, Int32 substCondDivCd, Int32 prmSubstCondDivCd, Int32 substApplyDivCd, Int32 searchUICntDivCd, Int32 enterProcDivCd, Int32 partsNoSearchDivCd, string partsJoinCntDivCd, Int32 eraNameDispCd1, Int32 partsSearchPriDivCd, Int32 joinInitDispDiv, Int32 customerCode, Int32 custRateGrpCode, DateTime priceApplyDate, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, List<string> listPriorWarehouse, Int32 isSettingSupplier, Int32 consTaxLayMethod, Int32 isSettingVariousMst, string enterpriseName, string bLGoodsName)
        //public GoodsCndtn(string enterpriseCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNameSrchTyp, string goodsNameKana, Int32 goodsNameKanaSrchTyp, string jan, Int32 bLGoodsCode, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 goodsKindCode, string sectionCode, Int32 joinSearchDiv, PMKEN01010E searchCarInfo, Int32 substCondDivCd, Int32 prmSubstCondDivCd, Int32 substApplyDivCd, Int32 searchUICntDivCd, Int32 enterProcDivCd, Int32 partsNoSearchDivCd, string partsJoinCntDivCd, Int32 eraNameDispCd1, Int32 partsSearchPriDivCd, Int32 joinInitDispDiv, Int32 customerCode, Int32 custRateGrpCode, DateTime priceApplyDate, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, List<string> listPriorWarehouse, Int32 isSettingSupplier, Int32 consTaxLayMethod, Int32 isSettingVariousMst, string enterpriseName, string bLGoodsName, Int32 logicalMode)
        //// 2009/12/18 <<<
        //public GoodsCndtn( string enterpriseCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNameSrchTyp, string goodsNameKana, Int32 goodsNameKanaSrchTyp, string jan, Int32 bLGoodsCode, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 goodsKindCode, string sectionCode, Int32 joinSearchDiv, PMKEN01010E searchCarInfo, Int32 substCondDivCd, Int32 prmSubstCondDivCd, Int32 substApplyDivCd, Int32 searchUICntDivCd, Int32 enterProcDivCd, Int32 partsNoSearchDivCd, string partsJoinCntDivCd, Int32 eraNameDispCd1, Int32 partsSearchPriDivCd, Int32 joinInitDispDiv, Int32 customerCode, Int32 custRateGrpCode, DateTime priceApplyDate, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, List<string> listPriorWarehouse, Int32 isSettingSupplier, Int32 consTaxLayMethod, Int32 isSettingVariousMst, string enterpriseName, string bLGoodsName, Int32 logicalMode, Int32 bLGoodsDrCode ) // DEL 2015/08/17 田建委 Redmine#47036
        // --- UPD m.suzuki 2011/05/18 ----------<<<<<
        //----- ADD 2015/08/17 田建委 Redmine#47036 ---------->>>>>
        public GoodsCndtn( string enterpriseCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNameSrchTyp, string goodsNameKana, Int32 goodsNameKanaSrchTyp, string jan, Int32 bLGoodsCode, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup, string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 goodsKindCode, string sectionCode, Int32 joinSearchDiv, PMKEN01010E searchCarInfo, Int32 substCondDivCd, Int32 prmSubstCondDivCd, Int32 substApplyDivCd, Int32 searchUICntDivCd, Int32 enterProcDivCd, Int32 partsNoSearchDivCd, string partsJoinCntDivCd, Int32 eraNameDispCd1, Int32 partsSearchPriDivCd, Int32 joinInitDispDiv, Int32 customerCode, Int32 custRateGrpCode, DateTime priceApplyDate, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd, Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, List<string> listPriorWarehouse, Int32 isSettingSupplier, Int32 consTaxLayMethod, Int32 isSettingVariousMst, string enterpriseName, string bLGoodsName, Int32 logicalMode, Int32 bLGoodsDrCode,
            string addUpSectionCode, string warehouseCode)
        //----- ADD 2015/08/17 田建委 Redmine#47036 ----------<<<<<
        {
			this._enterpriseCode = enterpriseCode;
			this._goodsMakerCd = goodsMakerCd;
			this._makerName = makerName;
			this._goodsNo = goodsNo;
			this._goodsNoSrchTyp = goodsNoSrchTyp;
			this._goodsName = goodsName;
			this._goodsNameSrchTyp = goodsNameSrchTyp;
			this._goodsNameKana = goodsNameKana;
			this._goodsNameKanaSrchTyp = goodsNameKanaSrchTyp;
			this._jan = jan;
			this._bLGoodsCode = bLGoodsCode;
			this._goodsLGroup = goodsLGroup;
			this._goodsLGroupName = goodsLGroupName;
			this._goodsMGroup = goodsMGroup;
			this._goodsMGroupName = goodsMGroupName;
			this._bLGroupCode = bLGroupCode;
			this._bLGroupName = bLGroupName;
			this._goodsKindCode = goodsKindCode;
			this._sectionCode = sectionCode;
			this._joinSearchDiv = joinSearchDiv;
			this._searchCarInfo = searchCarInfo;
			this._substCondDivCd = substCondDivCd;
			this._prmSubstCondDivCd = prmSubstCondDivCd;
			this._substApplyDivCd = substApplyDivCd;
			this._searchUICntDivCd = searchUICntDivCd;
			this._enterProcDivCd = enterProcDivCd;
			this._partsNoSearchDivCd = partsNoSearchDivCd;
			this._partsJoinCntDivCd = partsJoinCntDivCd;
			this._eraNameDispCd1 = eraNameDispCd1;
			this._partsSearchPriDivCd = partsSearchPriDivCd;
			this._joinInitDispDiv = joinInitDispDiv;
			this._customerCode = customerCode;
			this._custRateGrpCode = custRateGrpCode;
			this._priceApplyDate = priceApplyDate;
			this._salesUnPrcFrcProcCd = salesUnPrcFrcProcCd;
			this._stockUnPrcFrcProcCd = stockUnPrcFrcProcCd;
			this._taxRate = taxRate;
			this._totalAmountDispWayCd = totalAmountDispWayCd;
			this._ttlAmntDspRateDivCd = ttlAmntDspRateDivCd;
			this._salesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;
			this._stockCnsTaxFrcProcCd = stockCnsTaxFrcProcCd;
			this._listPriorWarehouse = listPriorWarehouse;
			this._isSettingSupplier = isSettingSupplier;
			this._consTaxLayMethod = consTaxLayMethod;
			this._isSettingVariousMst = isSettingVariousMst;
			this._enterpriseName = enterpriseName;
			this._bLGoodsName = bLGoodsName;
            this._logicalMode = logicalMode;    // 2009/12/18 Add
            this._bLGoodsDrCode = bLGoodsDrCode;    // ADD m.suzuki 2011/05/18
            //----- ADD 2015/08/17 田建委 Redmine#47036 ---------->>>>>
            this._addUpSectionCode = addUpSectionCode;
            this._warehouseCode = warehouseCode;
            //----- ADD 2015/08/17 田建委 Redmine#47036 ----------<<<<<
        }

        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        /// <summary>
        /// 商品抽出条件クラスコンストラクタ
        /// </summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="goodsMakerCd">商品メーカーコード</param>
        /// <param name="makerName">メーカー名称</param>
        /// <param name="goodsNo">商品番号</param>
        /// <param name="goodsNoSrchTyp">商品番号検索区分(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致)</param>
        /// <param name="goodsName">商品名称</param>
        /// <param name="goodsNameSrchTyp">商品名称検索区分(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致)</param>
        /// <param name="goodsNameKana">商品名称カナ</param>
        /// <param name="goodsNameKanaSrchTyp">商品カナ名称検索区分(0:完全一致,1:前方一致検索,2:後方一致検索,3:曖昧検索,4:ハイフン無し完全一致)</param>
        /// <param name="jan">JANコード(標準タイプ13桁または短縮タイプ8桁のJANコード)</param>
        /// <param name="bLGoodsCode">BL商品コード</param>
        /// <param name="goodsLGroup">商品大分類コード(旧大分類（ユーザーガイド）)</param>
        /// <param name="goodsLGroupName">商品大分類名称</param>
        /// <param name="goodsMGroup">商品中分類コード(旧中分類（マスタ有）)</param>
        /// <param name="goodsMGroupName">商品中分類名称</param>
        /// <param name="bLGroupCode">BLグループコード(旧グループコード)</param>
        /// <param name="bLGroupName">BLグループコード名称</param>
        /// <param name="goodsKindCode">商品属性(9:全て対象)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="joinSearchDiv">結合検索区分(0:結合検索なし,1:結合検索あり)</param>
        /// <param name="searchCarInfo">車両検索結果クラス(BLコード検索時のみ使用)</param>
        /// <param name="substCondDivCd">代替条件区分(0:代替しない,1:代替する(在庫無),2:代替する(在庫無視)　エントリからの部品検索時のみ有効)</param>
        /// <param name="prmSubstCondDivCd">優良代替条件区分(0:代替しない,1:代替する(在庫無),2:代替する(在庫無視)　エントリからの部品検索時のみ有効)</param>
        /// <param name="substApplyDivCd">代替適用区分(0:しない,1:する(結合、セット),2:全て(結合、セット、純正)　エントリからの部品検索時のみ有効)</param>
        /// <param name="searchUICntDivCd">検索画面制御区分(0:PM7,1:PM.NS　エントリからの部品検索時のみ有効)</param>
        /// <param name="enterProcDivCd">エンターキー処理区分(0:PM7,1:選択,2:次画面　エントリからの部品検索時のみ有効)</param>
        /// <param name="partsNoSearchDivCd">品番検索区分(0:PM7(セットのみ),1:結合・セット・代替あり　エントリからの部品検索時のみ有効)</param>
        /// <param name="partsJoinCntDivCd">品番結合制御区分(初期値”.”　エントリからの部品検索時のみ有効)</param>
        /// <param name="eraNameDispCd1">元号表示区分１(0:西暦,1:和歴（年式）　エントリからの部品検索時のみ有効)</param>
        /// <param name="partsSearchPriDivCd">部品検索優先順区分(0:純正,1:優良)</param>
        /// <param name="joinInitDispDiv">結合初期表示区分(0:表示順,1:在庫順)</param>
        /// <param name="customerCode">得意先コード(単価算出用)</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード(単価算出用)</param>
        /// <param name="priceApplyDate">価格適用日(単価算出用)</param>
        /// <param name="salesUnPrcFrcProcCd">売上単価端数処理コード(単価算出用)</param>
        /// <param name="stockUnPrcFrcProcCd">仕入単価端数処理コード(単価算出用)</param>
        /// <param name="taxRate">税率(単価算出用)</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分(単価算出用)</param>
        /// <param name="ttlAmntDspRateDivCd">総額表示掛率適用区分(単価算出用)</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード(単価算出用)</param>
        /// <param name="stockCnsTaxFrcProcCd">仕入消費税端数処理コード(単価算出用)</param>
        /// <param name="listPriorWarehouse">優先倉庫コードリスト(同一品番選択ウインドウの初期選択在庫情報の決定に使用)</param>
        /// <param name="isSettingSupplier">仕入先情報取得区分(0:設定あり 1:設定なし)</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式(0:伝票転嫁 1:明細転嫁 2:請求親 3:請求子 9:非課税)</param>
        /// <param name="isSettingVariousMst">不足情報設定区分(0:設定あり 1:設定なし)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="addUpSectionCode"></param>
        /// <param name="bLGoodsDrCode">BL商品コード枝番</param>
        /// <param name="logicalMode"></param>
        /// <param name="warehouseCode">倉庫コード</param>
        /// <param name="blUtyPtSbCdRF">BL統一部品サブコード</param>
        /// <param name="blUtyPtThCdRF">BL統一部品コード(スリーコード版)</param>
        /// <returns>GoodsCndtnクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note       : BL統一部品サブコードの取得と設定</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>管理番号   : 11470007-00</br>
        /// <br>           : NS3Ai対応（BL統一部品コード対応）</br>
        /// </remarks>
        public GoodsCndtn(
              string enterpriseCode, Int32 goodsMakerCd, string makerName, string goodsNo, Int32 goodsNoSrchTyp, string goodsName, Int32 goodsNameSrchTyp
            , string goodsNameKana, Int32 goodsNameKanaSrchTyp, string jan, Int32 bLGoodsCode, Int32 goodsLGroup, string goodsLGroupName, Int32 goodsMGroup
            , string goodsMGroupName, Int32 bLGroupCode, string bLGroupName, Int32 goodsKindCode, string sectionCode, Int32 joinSearchDiv, PMKEN01010E searchCarInfo 
            , Int32 substCondDivCd, Int32 prmSubstCondDivCd, Int32 substApplyDivCd, Int32 searchUICntDivCd, Int32 enterProcDivCd, Int32 partsNoSearchDivCd
            , string partsJoinCntDivCd, Int32 eraNameDispCd1, Int32 partsSearchPriDivCd, Int32 joinInitDispDiv, Int32 customerCode, Int32 custRateGrpCode
            , DateTime priceApplyDate, Int32 salesUnPrcFrcProcCd, Int32 stockUnPrcFrcProcCd, Double taxRate, Int32 totalAmountDispWayCd, Int32 ttlAmntDspRateDivCd
            , Int32 salesCnsTaxFrcProcCd, Int32 stockCnsTaxFrcProcCd, List<string> listPriorWarehouse, Int32 isSettingSupplier, Int32 consTaxLayMethod
            , Int32 isSettingVariousMst, string enterpriseName, string bLGoodsName, Int32 logicalMode, Int32 bLGoodsDrCode, string addUpSectionCode
            , string warehouseCode, string blUtyPtThCdRF, Int32 blUtyPtSbCdRF
            ) : this( enterpriseCode, goodsMakerCd, makerName, goodsNo, goodsNoSrchTyp, goodsName, goodsNameSrchTyp
            , goodsNameKana, goodsNameKanaSrchTyp, jan, bLGoodsCode, goodsLGroup, goodsLGroupName, goodsMGroup
            , goodsMGroupName, bLGroupCode, bLGroupName, goodsKindCode, sectionCode, joinSearchDiv, searchCarInfo
            , substCondDivCd, prmSubstCondDivCd, substApplyDivCd, searchUICntDivCd, enterProcDivCd, partsNoSearchDivCd
            , partsJoinCntDivCd, eraNameDispCd1, partsSearchPriDivCd, joinInitDispDiv, customerCode, custRateGrpCode
            , priceApplyDate, salesUnPrcFrcProcCd, stockUnPrcFrcProcCd, taxRate, totalAmountDispWayCd, ttlAmntDspRateDivCd
            , salesCnsTaxFrcProcCd, stockCnsTaxFrcProcCd, listPriorWarehouse, isSettingSupplier, consTaxLayMethod
            , isSettingVariousMst, enterpriseName, bLGoodsName, logicalMode, bLGoodsDrCode,addUpSectionCode, warehouseCode
            )
        {
            this._blUtyPtThCd = blUtyPtThCdRF;
            this._blUtyPtSbCd = blUtyPtSbCdRF;
        }
        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

		/// <summary>
		/// 商品抽出条件クラス複製処理
		/// </summary>
		/// <returns>GoodsCndtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいGoodsCndtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2015/08/17 田建委</br>
        /// <br>                     Redmine#47036 商品在庫一括登録修正 管理拠点・倉庫の追加</br>
        /// <br>Update Note      :   2018/04/05  30757 佐々木　貴英</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
        /// <br>                     BL統一部品コード関連メンバーの追加</br>
		/// </remarks>
		public GoodsCndtn Clone()
		{
            // ----UPD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
            //// --- UPD m.suzuki 2011/05/18 ---------->>>>>
            ////// 2009/12/18 >>>
            //////return new GoodsCndtn(this._enterpriseCode,this._goodsMakerCd,this._makerName,this._goodsNo,this._goodsNoSrchTyp,this._goodsName,this._goodsNameSrchTyp,this._goodsNameKana,this._goodsNameKanaSrchTyp,this._jan,this._bLGoodsCode,this._goodsLGroup,this._goodsLGroupName,this._goodsMGroup,this._goodsMGroupName,this._bLGroupCode,this._bLGroupName,this._goodsKindCode,this._sectionCode,this._joinSearchDiv,this._searchCarInfo,this._substCondDivCd,this._prmSubstCondDivCd,this._substApplyDivCd,this._searchUICntDivCd,this._enterProcDivCd,this._partsNoSearchDivCd,this._partsJoinCntDivCd,this._eraNameDispCd1,this._partsSearchPriDivCd,this._joinInitDispDiv,this._customerCode,this._custRateGrpCode,this._priceApplyDate,this._salesUnPrcFrcProcCd,this._stockUnPrcFrcProcCd,this._taxRate,this._totalAmountDispWayCd,this._ttlAmntDspRateDivCd,this._salesCnsTaxFrcProcCd,this._stockCnsTaxFrcProcCd,this._listPriorWarehouse,this._isSettingSupplier,this._consTaxLayMethod,this._isSettingVariousMst,this._enterpriseName,this._bLGoodsName);
            ////return new GoodsCndtn(this._enterpriseCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNameSrchTyp, this._goodsNameKana, this._goodsNameKanaSrchTyp, this._jan, this._bLGoodsCode, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsKindCode, this._sectionCode, this._joinSearchDiv, this._searchCarInfo, this._substCondDivCd, this._prmSubstCondDivCd, this._substApplyDivCd, this._searchUICntDivCd, this._enterProcDivCd, this._partsNoSearchDivCd, this._partsJoinCntDivCd, this._eraNameDispCd1, this._partsSearchPriDivCd, this._joinInitDispDiv, this._customerCode, this._custRateGrpCode, this._priceApplyDate, this._salesUnPrcFrcProcCd, this._stockUnPrcFrcProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._salesCnsTaxFrcProcCd, this._stockCnsTaxFrcProcCd, this._listPriorWarehouse, this._isSettingSupplier, this._consTaxLayMethod, this._isSettingVariousMst, this._enterpriseName, this._bLGoodsName, this._logicalMode);
            ////// 2009/12/18 <<<
            ////return new GoodsCndtn( this._enterpriseCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNameSrchTyp, this._goodsNameKana, this._goodsNameKanaSrchTyp, this._jan, this._bLGoodsCode, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsKindCode, this._sectionCode, this._joinSearchDiv, this._searchCarInfo, this._substCondDivCd, this._prmSubstCondDivCd, this._substApplyDivCd, this._searchUICntDivCd, this._enterProcDivCd, this._partsNoSearchDivCd, this._partsJoinCntDivCd, this._eraNameDispCd1, this._partsSearchPriDivCd, this._joinInitDispDiv, this._customerCode, this._custRateGrpCode, this._priceApplyDate, this._salesUnPrcFrcProcCd, this._stockUnPrcFrcProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._salesCnsTaxFrcProcCd, this._stockCnsTaxFrcProcCd, this._listPriorWarehouse, this._isSettingSupplier, this._consTaxLayMethod, this._isSettingVariousMst, this._enterpriseName, this._bLGoodsName, this._logicalMode, this._bLGoodsDrCode ); // DEL 2015/08/17 田建委 Redmine#47036
            //// --- UPD m.suzuki 2011/05/18 ----------<<<<<
            ////----- ADD 2015/08/17 田建委 Redmine#47036 ---------->>>>>
            //return new GoodsCndtn(this._enterpriseCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNameSrchTyp, this._goodsNameKana, this._goodsNameKanaSrchTyp, this._jan, this._bLGoodsCode, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsKindCode, this._sectionCode, this._joinSearchDiv, this._searchCarInfo, this._substCondDivCd, this._prmSubstCondDivCd, this._substApplyDivCd, this._searchUICntDivCd, this._enterProcDivCd, this._partsNoSearchDivCd, this._partsJoinCntDivCd, this._eraNameDispCd1, this._partsSearchPriDivCd, this._joinInitDispDiv, this._customerCode, this._custRateGrpCode, this._priceApplyDate, this._salesUnPrcFrcProcCd, this._stockUnPrcFrcProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._salesCnsTaxFrcProcCd, this._stockCnsTaxFrcProcCd, this._listPriorWarehouse, this._isSettingSupplier, this._consTaxLayMethod, this._isSettingVariousMst, this._enterpriseName, this._bLGoodsName, this._logicalMode, this._bLGoodsDrCode, 
            //    this._addUpSectionCode, this._warehouseCode);
            ////----- ADD 2015/08/17 田建委 Redmine#47036 ----------<<<<<
            return new GoodsCndtn(this._enterpriseCode, this._goodsMakerCd, this._makerName, this._goodsNo, this._goodsNoSrchTyp, this._goodsName, this._goodsNameSrchTyp, this._goodsNameKana, this._goodsNameKanaSrchTyp, this._jan, this._bLGoodsCode, this._goodsLGroup, this._goodsLGroupName, this._goodsMGroup, this._goodsMGroupName, this._bLGroupCode, this._bLGroupName, this._goodsKindCode, this._sectionCode, this._joinSearchDiv, this._searchCarInfo, this._substCondDivCd, this._prmSubstCondDivCd, this._substApplyDivCd, this._searchUICntDivCd, this._enterProcDivCd, this._partsNoSearchDivCd, this._partsJoinCntDivCd, this._eraNameDispCd1, this._partsSearchPriDivCd, this._joinInitDispDiv, this._customerCode, this._custRateGrpCode, this._priceApplyDate, this._salesUnPrcFrcProcCd, this._stockUnPrcFrcProcCd, this._taxRate, this._totalAmountDispWayCd, this._ttlAmntDspRateDivCd, this._salesCnsTaxFrcProcCd, this._stockCnsTaxFrcProcCd, this._listPriorWarehouse, this._isSettingSupplier, this._consTaxLayMethod, this._isSettingVariousMst, this._enterpriseName, this._bLGoodsName, this._logicalMode, this._bLGoodsDrCode, 
                this._addUpSectionCode, this._warehouseCode,this._blUtyPtThCd, this._blUtyPtSbCd);
            // ----UPD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
        }

		/// <summary>
		/// 商品抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のGoodsCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2015/08/17 田建委</br>
        /// <br>                     Redmine#47036 商品在庫一括登録修正 管理拠点・倉庫の追加</br>
        /// <br>Update Note      :   2018/04/05  30757 佐々木　貴英</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
        /// <br>                     BL統一部品コード関連メンバーの追加</br>
		/// </remarks>
		public bool Equals(GoodsCndtn target)
		{
			return ((this.EnterpriseCode == target.EnterpriseCode)
				 && (this.GoodsMakerCd == target.GoodsMakerCd)
				 && (this.MakerName == target.MakerName)
				 && (this.GoodsNo == target.GoodsNo)
				 && (this.GoodsNoSrchTyp == target.GoodsNoSrchTyp)
				 && (this.GoodsName == target.GoodsName)
				 && (this.GoodsNameSrchTyp == target.GoodsNameSrchTyp)
				 && (this.GoodsNameKana == target.GoodsNameKana)
				 && (this.GoodsNameKanaSrchTyp == target.GoodsNameKanaSrchTyp)
				 && (this.Jan == target.Jan)
				 && (this.BLGoodsCode == target.BLGoodsCode)
				 && (this.GoodsLGroup == target.GoodsLGroup)
				 && (this.GoodsLGroupName == target.GoodsLGroupName)
				 && (this.GoodsMGroup == target.GoodsMGroup)
				 && (this.GoodsMGroupName == target.GoodsMGroupName)
				 && (this.BLGroupCode == target.BLGroupCode)
				 && (this.BLGroupName == target.BLGroupName)
				 && (this.GoodsKindCode == target.GoodsKindCode)
				 && (this.SectionCode == target.SectionCode)
				 && (this.JoinSearchDiv == target.JoinSearchDiv)
				 && (this.SearchCarInfo == target.SearchCarInfo)
				 && (this.SubstCondDivCd == target.SubstCondDivCd)
				 && (this.PrmSubstCondDivCd == target.PrmSubstCondDivCd)
				 && (this.SubstApplyDivCd == target.SubstApplyDivCd)
				 && (this.SearchUICntDivCd == target.SearchUICntDivCd)
				 && (this.EnterProcDivCd == target.EnterProcDivCd)
				 && (this.PartsNoSearchDivCd == target.PartsNoSearchDivCd)
				 && (this.PartsJoinCntDivCd == target.PartsJoinCntDivCd)
				 && (this.EraNameDispCd1 == target.EraNameDispCd1)
				 && (this.PartsSearchPriDivCd == target.PartsSearchPriDivCd)
				 && (this.JoinInitDispDiv == target.JoinInitDispDiv)
				 && (this.CustomerCode == target.CustomerCode)
				 && (this.CustRateGrpCode == target.CustRateGrpCode)
				 && (this.PriceApplyDate == target.PriceApplyDate)
				 && (this.SalesUnPrcFrcProcCd == target.SalesUnPrcFrcProcCd)
				 && (this.StockUnPrcFrcProcCd == target.StockUnPrcFrcProcCd)
				 && (this.TaxRate == target.TaxRate)
				 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
				 && (this.TtlAmntDspRateDivCd == target.TtlAmntDspRateDivCd)
				 && (this.SalesCnsTaxFrcProcCd == target.SalesCnsTaxFrcProcCd)
				 && (this.StockCnsTaxFrcProcCd == target.StockCnsTaxFrcProcCd)
				 && (this.ListPriorWarehouse == target.ListPriorWarehouse)
				 && (this.IsSettingSupplier == target.IsSettingSupplier)
				 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
				 && (this.IsSettingVariousMst == target.IsSettingVariousMst)
				 && (this.EnterpriseName == target.EnterpriseName)
                 && ( this.LogicalMode == target.LogicalMode )   // 2009/12/18 Add
                 && (this.BLGoodsDrCode == target.BLGoodsDrCode)    // ADD m.suzuki 2011/05/18
                 //----- ADD 2015/08/17 田建委 Redmine#47036 ---------->>>>>
                 && (this.AddUpSectionCode == target.AddUpSectionCode)
                 && (this.WarehouseCode == target.WarehouseCode)
                 //----- ADD 2015/08/17 田建委 Redmine#47036 ----------<<<<<
                 // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
                 && (this.BlUtyPtThCd == target.BlUtyPtThCd)
                 && (this.BlUtyPtSbCd == target.BlUtyPtSbCd) 
                 // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
                 && (this.BLGoodsName == target.BLGoodsName));
		}

		/// <summary>
		/// 商品抽出条件クラス比較処理
		/// </summary>
		/// <param name="goodsCndtn1">
		///                    比較するGoodsCndtnクラスのインスタンス
		/// </param>
		/// <param name="goodsCndtn2">比較するGoodsCndtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsCndtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2015/08/17 田建委</br>
        /// <br>                     Redmine#47036 商品在庫一括登録修正 管理拠点・倉庫の追加</br>
        /// <br>Update Note      :   2018/04/05  30757 佐々木　貴英</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
        /// <br>                     BL統一部品コード関連メンバーの追加</br>
		/// </remarks>
		public static bool Equals(GoodsCndtn goodsCndtn1, GoodsCndtn goodsCndtn2)
		{
			return ((goodsCndtn1.EnterpriseCode == goodsCndtn2.EnterpriseCode)
				 && (goodsCndtn1.GoodsMakerCd == goodsCndtn2.GoodsMakerCd)
				 && (goodsCndtn1.MakerName == goodsCndtn2.MakerName)
				 && (goodsCndtn1.GoodsNo == goodsCndtn2.GoodsNo)
				 && (goodsCndtn1.GoodsNoSrchTyp == goodsCndtn2.GoodsNoSrchTyp)
				 && (goodsCndtn1.GoodsName == goodsCndtn2.GoodsName)
				 && (goodsCndtn1.GoodsNameSrchTyp == goodsCndtn2.GoodsNameSrchTyp)
				 && (goodsCndtn1.GoodsNameKana == goodsCndtn2.GoodsNameKana)
				 && (goodsCndtn1.GoodsNameKanaSrchTyp == goodsCndtn2.GoodsNameKanaSrchTyp)
				 && (goodsCndtn1.Jan == goodsCndtn2.Jan)
				 && (goodsCndtn1.BLGoodsCode == goodsCndtn2.BLGoodsCode)
				 && (goodsCndtn1.GoodsLGroup == goodsCndtn2.GoodsLGroup)
				 && (goodsCndtn1.GoodsLGroupName == goodsCndtn2.GoodsLGroupName)
				 && (goodsCndtn1.GoodsMGroup == goodsCndtn2.GoodsMGroup)
				 && (goodsCndtn1.GoodsMGroupName == goodsCndtn2.GoodsMGroupName)
				 && (goodsCndtn1.BLGroupCode == goodsCndtn2.BLGroupCode)
				 && (goodsCndtn1.BLGroupName == goodsCndtn2.BLGroupName)
				 && (goodsCndtn1.GoodsKindCode == goodsCndtn2.GoodsKindCode)
				 && (goodsCndtn1.SectionCode == goodsCndtn2.SectionCode)
				 && (goodsCndtn1.JoinSearchDiv == goodsCndtn2.JoinSearchDiv)
				 && (goodsCndtn1.SearchCarInfo == goodsCndtn2.SearchCarInfo)
				 && (goodsCndtn1.SubstCondDivCd == goodsCndtn2.SubstCondDivCd)
				 && (goodsCndtn1.PrmSubstCondDivCd == goodsCndtn2.PrmSubstCondDivCd)
				 && (goodsCndtn1.SubstApplyDivCd == goodsCndtn2.SubstApplyDivCd)
				 && (goodsCndtn1.SearchUICntDivCd == goodsCndtn2.SearchUICntDivCd)
				 && (goodsCndtn1.EnterProcDivCd == goodsCndtn2.EnterProcDivCd)
				 && (goodsCndtn1.PartsNoSearchDivCd == goodsCndtn2.PartsNoSearchDivCd)
				 && (goodsCndtn1.PartsJoinCntDivCd == goodsCndtn2.PartsJoinCntDivCd)
				 && (goodsCndtn1.EraNameDispCd1 == goodsCndtn2.EraNameDispCd1)
				 && (goodsCndtn1.PartsSearchPriDivCd == goodsCndtn2.PartsSearchPriDivCd)
				 && (goodsCndtn1.JoinInitDispDiv == goodsCndtn2.JoinInitDispDiv)
				 && (goodsCndtn1.CustomerCode == goodsCndtn2.CustomerCode)
				 && (goodsCndtn1.CustRateGrpCode == goodsCndtn2.CustRateGrpCode)
				 && (goodsCndtn1.PriceApplyDate == goodsCndtn2.PriceApplyDate)
				 && (goodsCndtn1.SalesUnPrcFrcProcCd == goodsCndtn2.SalesUnPrcFrcProcCd)
				 && (goodsCndtn1.StockUnPrcFrcProcCd == goodsCndtn2.StockUnPrcFrcProcCd)
				 && (goodsCndtn1.TaxRate == goodsCndtn2.TaxRate)
				 && (goodsCndtn1.TotalAmountDispWayCd == goodsCndtn2.TotalAmountDispWayCd)
				 && (goodsCndtn1.TtlAmntDspRateDivCd == goodsCndtn2.TtlAmntDspRateDivCd)
				 && (goodsCndtn1.SalesCnsTaxFrcProcCd == goodsCndtn2.SalesCnsTaxFrcProcCd)
				 && (goodsCndtn1.StockCnsTaxFrcProcCd == goodsCndtn2.StockCnsTaxFrcProcCd)
				 && (goodsCndtn1.ListPriorWarehouse == goodsCndtn2.ListPriorWarehouse)
				 && (goodsCndtn1.IsSettingSupplier == goodsCndtn2.IsSettingSupplier)
				 && (goodsCndtn1.ConsTaxLayMethod == goodsCndtn2.ConsTaxLayMethod)
				 && (goodsCndtn1.IsSettingVariousMst == goodsCndtn2.IsSettingVariousMst)
				 && (goodsCndtn1.EnterpriseName == goodsCndtn2.EnterpriseName)
                 && ( goodsCndtn1.LogicalMode == goodsCndtn2.LogicalMode )      // 2009/12/18 Add
                 && (goodsCndtn1.BLGoodsDrCode == goodsCndtn2.BLGoodsDrCode)    // ADD m.suzuki 2011/05/18
                //----- ADD 2015/08/17 田建委 Redmine#47036 ---------->>>>>
                 && (goodsCndtn1.AddUpSectionCode == goodsCndtn2.AddUpSectionCode)
                 && (goodsCndtn1.WarehouseCode == goodsCndtn2.WarehouseCode)
                //----- ADD 2015/08/17 田建委 Redmine#47036 ----------<<<<<
                 // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
                 && (goodsCndtn1.BlUtyPtThCd == goodsCndtn2.BlUtyPtThCd)
                 && (goodsCndtn1.BlUtyPtSbCd == goodsCndtn2.BlUtyPtSbCd) 
                 // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
                 && (goodsCndtn1.BLGoodsName == goodsCndtn2.BLGoodsName));
		}
		/// <summary>
		/// 商品抽出条件クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のGoodsCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsCndtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2015/08/17 田建委</br>
        /// <br>                     Redmine#47036 商品在庫一括登録修正 管理拠点・倉庫の追加</br>
        /// <br>Update Note      :   2018/04/05  30757 佐々木　貴英</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
        /// <br>                     BL統一部品コード関連メンバーの追加</br>
		/// </remarks>
		public ArrayList Compare(GoodsCndtn target)
		{
			ArrayList resList = new ArrayList();
			if(this.EnterpriseCode != target.EnterpriseCode)resList.Add("EnterpriseCode");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.MakerName != target.MakerName)resList.Add("MakerName");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsNoSrchTyp != target.GoodsNoSrchTyp)resList.Add("GoodsNoSrchTyp");
			if(this.GoodsName != target.GoodsName)resList.Add("GoodsName");
			if(this.GoodsNameSrchTyp != target.GoodsNameSrchTyp)resList.Add("GoodsNameSrchTyp");
			if(this.GoodsNameKana != target.GoodsNameKana)resList.Add("GoodsNameKana");
			if(this.GoodsNameKanaSrchTyp != target.GoodsNameKanaSrchTyp)resList.Add("GoodsNameKanaSrchTyp");
			if(this.Jan != target.Jan)resList.Add("Jan");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.GoodsLGroup != target.GoodsLGroup)resList.Add("GoodsLGroup");
			if(this.GoodsLGroupName != target.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(this.GoodsMGroup != target.GoodsMGroup)resList.Add("GoodsMGroup");
			if(this.GoodsMGroupName != target.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(this.BLGroupCode != target.BLGroupCode)resList.Add("BLGroupCode");
			if(this.BLGroupName != target.BLGroupName)resList.Add("BLGroupName");
			if(this.GoodsKindCode != target.GoodsKindCode)resList.Add("GoodsKindCode");
			if(this.SectionCode != target.SectionCode)resList.Add("SectionCode");
			if(this.JoinSearchDiv != target.JoinSearchDiv)resList.Add("JoinSearchDiv");
			if(this.SearchCarInfo != target.SearchCarInfo)resList.Add("SearchCarInfo");
			if(this.SubstCondDivCd != target.SubstCondDivCd)resList.Add("SubstCondDivCd");
			if(this.PrmSubstCondDivCd != target.PrmSubstCondDivCd)resList.Add("PrmSubstCondDivCd");
			if(this.SubstApplyDivCd != target.SubstApplyDivCd)resList.Add("SubstApplyDivCd");
			if(this.SearchUICntDivCd != target.SearchUICntDivCd)resList.Add("SearchUICntDivCd");
			if(this.EnterProcDivCd != target.EnterProcDivCd)resList.Add("EnterProcDivCd");
			if(this.PartsNoSearchDivCd != target.PartsNoSearchDivCd)resList.Add("PartsNoSearchDivCd");
			if(this.PartsJoinCntDivCd != target.PartsJoinCntDivCd)resList.Add("PartsJoinCntDivCd");
			if(this.EraNameDispCd1 != target.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(this.PartsSearchPriDivCd != target.PartsSearchPriDivCd)resList.Add("PartsSearchPriDivCd");
			if(this.JoinInitDispDiv != target.JoinInitDispDiv)resList.Add("JoinInitDispDiv");
			if(this.CustomerCode != target.CustomerCode)resList.Add("CustomerCode");
			if(this.CustRateGrpCode != target.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(this.PriceApplyDate != target.PriceApplyDate)resList.Add("PriceApplyDate");
			if(this.SalesUnPrcFrcProcCd != target.SalesUnPrcFrcProcCd)resList.Add("SalesUnPrcFrcProcCd");
			if(this.StockUnPrcFrcProcCd != target.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(this.TaxRate != target.TaxRate)resList.Add("TaxRate");
			if(this.TotalAmountDispWayCd != target.TotalAmountDispWayCd)resList.Add("TotalAmountDispWayCd");
			if(this.TtlAmntDspRateDivCd != target.TtlAmntDspRateDivCd)resList.Add("TtlAmntDspRateDivCd");
			if(this.SalesCnsTaxFrcProcCd != target.SalesCnsTaxFrcProcCd)resList.Add("SalesCnsTaxFrcProcCd");
			if(this.StockCnsTaxFrcProcCd != target.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(this.ListPriorWarehouse != target.ListPriorWarehouse)resList.Add("ListPriorWarehouse");
			if(this.IsSettingSupplier != target.IsSettingSupplier)resList.Add("IsSettingSupplier");
			if(this.ConsTaxLayMethod != target.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(this.IsSettingVariousMst != target.IsSettingVariousMst)resList.Add("IsSettingVariousMst");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");
            if (this.LogicalMode != target.LogicalMode) resList.Add("LogicalMode"); // 2009/12/18 Add
            if ( this.BLGoodsDrCode != target.BLGoodsDrCode ) resList.Add( "LogicalMode" ); // ADD m.suzuki 2011/05/18
            //----- ADD 2015/08/17 田建委 Redmine#47036 ---------->>>>>
            if (this.AddUpSectionCode != target.AddUpSectionCode) resList.Add("AddUpSectionCode");
            if (this.WarehouseCode != target.WarehouseCode) resList.Add("WarehouseCode");
            //----- ADD 2015/08/17 田建委 Redmine#47036 ----------<<<<<
            // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
            if (this.BlUtyPtThCd != target.BlUtyPtThCd) resList.Add("BlUtyPtThCd");
            if (this.BlUtyPtSbCd != target.BlUtyPtSbCd) resList.Add("BlUtyPtSbCd");
            // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

			return resList;
		}

		/// <summary>
		/// 商品抽出条件クラス比較処理
		/// </summary>
		/// <param name="goodsCndtn1">比較するGoodsCndtnクラスのインスタンス</param>
		/// <param name="goodsCndtn2">比較するGoodsCndtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   GoodsCndtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2015/08/17 田建委</br>
        /// <br>                     Redmine#47036 商品在庫一括登録修正 管理拠点・倉庫の追加</br>
        /// <br>Update Note      :   2018/04/05  30757 佐々木　貴英</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   NS3Ai対応（BL統一部品コード対応）</br>
        /// <br>                     BL統一部品コード関連メンバーの追加</br>
		/// </remarks>
		public static ArrayList Compare(GoodsCndtn goodsCndtn1, GoodsCndtn goodsCndtn2)
		{
			ArrayList resList = new ArrayList();
			if(goodsCndtn1.EnterpriseCode != goodsCndtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(goodsCndtn1.GoodsMakerCd != goodsCndtn2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(goodsCndtn1.MakerName != goodsCndtn2.MakerName)resList.Add("MakerName");
			if(goodsCndtn1.GoodsNo != goodsCndtn2.GoodsNo)resList.Add("GoodsNo");
			if(goodsCndtn1.GoodsNoSrchTyp != goodsCndtn2.GoodsNoSrchTyp)resList.Add("GoodsNoSrchTyp");
			if(goodsCndtn1.GoodsName != goodsCndtn2.GoodsName)resList.Add("GoodsName");
			if(goodsCndtn1.GoodsNameSrchTyp != goodsCndtn2.GoodsNameSrchTyp)resList.Add("GoodsNameSrchTyp");
			if(goodsCndtn1.GoodsNameKana != goodsCndtn2.GoodsNameKana)resList.Add("GoodsNameKana");
			if(goodsCndtn1.GoodsNameKanaSrchTyp != goodsCndtn2.GoodsNameKanaSrchTyp)resList.Add("GoodsNameKanaSrchTyp");
			if(goodsCndtn1.Jan != goodsCndtn2.Jan)resList.Add("Jan");
			if(goodsCndtn1.BLGoodsCode != goodsCndtn2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(goodsCndtn1.GoodsLGroup != goodsCndtn2.GoodsLGroup)resList.Add("GoodsLGroup");
			if(goodsCndtn1.GoodsLGroupName != goodsCndtn2.GoodsLGroupName)resList.Add("GoodsLGroupName");
			if(goodsCndtn1.GoodsMGroup != goodsCndtn2.GoodsMGroup)resList.Add("GoodsMGroup");
			if(goodsCndtn1.GoodsMGroupName != goodsCndtn2.GoodsMGroupName)resList.Add("GoodsMGroupName");
			if(goodsCndtn1.BLGroupCode != goodsCndtn2.BLGroupCode)resList.Add("BLGroupCode");
			if(goodsCndtn1.BLGroupName != goodsCndtn2.BLGroupName)resList.Add("BLGroupName");
			if(goodsCndtn1.GoodsKindCode != goodsCndtn2.GoodsKindCode)resList.Add("GoodsKindCode");
			if(goodsCndtn1.SectionCode != goodsCndtn2.SectionCode)resList.Add("SectionCode");
			if(goodsCndtn1.JoinSearchDiv != goodsCndtn2.JoinSearchDiv)resList.Add("JoinSearchDiv");
			if(goodsCndtn1.SearchCarInfo != goodsCndtn2.SearchCarInfo)resList.Add("SearchCarInfo");
			if(goodsCndtn1.SubstCondDivCd != goodsCndtn2.SubstCondDivCd)resList.Add("SubstCondDivCd");
			if(goodsCndtn1.PrmSubstCondDivCd != goodsCndtn2.PrmSubstCondDivCd)resList.Add("PrmSubstCondDivCd");
			if(goodsCndtn1.SubstApplyDivCd != goodsCndtn2.SubstApplyDivCd)resList.Add("SubstApplyDivCd");
			if(goodsCndtn1.SearchUICntDivCd != goodsCndtn2.SearchUICntDivCd)resList.Add("SearchUICntDivCd");
			if(goodsCndtn1.EnterProcDivCd != goodsCndtn2.EnterProcDivCd)resList.Add("EnterProcDivCd");
			if(goodsCndtn1.PartsNoSearchDivCd != goodsCndtn2.PartsNoSearchDivCd)resList.Add("PartsNoSearchDivCd");
			if(goodsCndtn1.PartsJoinCntDivCd != goodsCndtn2.PartsJoinCntDivCd)resList.Add("PartsJoinCntDivCd");
			if(goodsCndtn1.EraNameDispCd1 != goodsCndtn2.EraNameDispCd1)resList.Add("EraNameDispCd1");
			if(goodsCndtn1.PartsSearchPriDivCd != goodsCndtn2.PartsSearchPriDivCd)resList.Add("PartsSearchPriDivCd");
			if(goodsCndtn1.JoinInitDispDiv != goodsCndtn2.JoinInitDispDiv)resList.Add("JoinInitDispDiv");
			if(goodsCndtn1.CustomerCode != goodsCndtn2.CustomerCode)resList.Add("CustomerCode");
			if(goodsCndtn1.CustRateGrpCode != goodsCndtn2.CustRateGrpCode)resList.Add("CustRateGrpCode");
			if(goodsCndtn1.PriceApplyDate != goodsCndtn2.PriceApplyDate)resList.Add("PriceApplyDate");
			if(goodsCndtn1.SalesUnPrcFrcProcCd != goodsCndtn2.SalesUnPrcFrcProcCd)resList.Add("SalesUnPrcFrcProcCd");
			if(goodsCndtn1.StockUnPrcFrcProcCd != goodsCndtn2.StockUnPrcFrcProcCd)resList.Add("StockUnPrcFrcProcCd");
			if(goodsCndtn1.TaxRate != goodsCndtn2.TaxRate)resList.Add("TaxRate");
			if(goodsCndtn1.TotalAmountDispWayCd != goodsCndtn2.TotalAmountDispWayCd)resList.Add("TotalAmountDispWayCd");
			if(goodsCndtn1.TtlAmntDspRateDivCd != goodsCndtn2.TtlAmntDspRateDivCd)resList.Add("TtlAmntDspRateDivCd");
			if(goodsCndtn1.SalesCnsTaxFrcProcCd != goodsCndtn2.SalesCnsTaxFrcProcCd)resList.Add("SalesCnsTaxFrcProcCd");
			if(goodsCndtn1.StockCnsTaxFrcProcCd != goodsCndtn2.StockCnsTaxFrcProcCd)resList.Add("StockCnsTaxFrcProcCd");
			if(goodsCndtn1.ListPriorWarehouse != goodsCndtn2.ListPriorWarehouse)resList.Add("ListPriorWarehouse");
			if(goodsCndtn1.IsSettingSupplier != goodsCndtn2.IsSettingSupplier)resList.Add("IsSettingSupplier");
			if(goodsCndtn1.ConsTaxLayMethod != goodsCndtn2.ConsTaxLayMethod)resList.Add("ConsTaxLayMethod");
			if(goodsCndtn1.IsSettingVariousMst != goodsCndtn2.IsSettingVariousMst)resList.Add("IsSettingVariousMst");
			if(goodsCndtn1.EnterpriseName != goodsCndtn2.EnterpriseName)resList.Add("EnterpriseName");
			if(goodsCndtn1.BLGoodsName != goodsCndtn2.BLGoodsName)resList.Add("BLGoodsName");
            if (goodsCndtn1.LogicalMode != goodsCndtn2.LogicalMode) resList.Add("LogicalMode");     // 2009/12/18 Add
            if ( goodsCndtn1.BLGoodsDrCode != goodsCndtn2.BLGoodsDrCode ) resList.Add( "BLGoodsDrCode" );     // ADD m.suzuki 2011/05/18
            //----- ADD 2015/08/17 田建委 Redmine#47036 ---------->>>>>
            if (goodsCndtn1.AddUpSectionCode != goodsCndtn2.AddUpSectionCode) resList.Add("AddUpSectionCode");
            if (goodsCndtn1.WarehouseCode != goodsCndtn2.WarehouseCode) resList.Add("WarehouseCode");
            //----- ADD 2015/08/17 田建委 Redmine#47036 ----------<<<<<
            // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
            if (goodsCndtn1.BlUtyPtThCd != goodsCndtn2.BlUtyPtThCd) resList.Add("BlUtyPtThCd");
            if (goodsCndtn1.BlUtyPtSbCd != goodsCndtn2.BlUtyPtSbCd) resList.Add("BlUtyPtSbCd");
            // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

			return resList;
		}

        /// <summary>
        /// 商品マスタ（抽出条件クラス）生成処理
        /// </summary>
        /// <returns></returns>
        public GoodsCndtn Create()
        {
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsCndtn.EnterpriseCode = this.EnterpriseCode;

            // 下記項目は元データをほじする
            goodsCndtn.GoodsNoSrchTyp = this.GoodsNoSrchTyp;
            goodsCndtn.GoodsNameKanaSrchTyp = this.GoodsNameKanaSrchTyp;
            goodsCndtn.GoodsNameSrchTyp = this.GoodsNameSrchTyp;
            goodsCndtn.GoodsKindCode = this.GoodsKindCode;

            return goodsCndtn;
        }

        /// <summary>
        /// 結合検索区分
        /// </summary>
        public enum JoinSearchDivType : int
        {
            /// <summary>検索なし</summary>
            NoSearch = 0,
            /// <summary>検索あり</summary>
            Search = 1
        }
	}
}
