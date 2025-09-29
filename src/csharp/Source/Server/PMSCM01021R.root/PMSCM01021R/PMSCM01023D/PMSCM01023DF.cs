//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM受注セット部品データ
//                  :   PMSCM01023D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   高峰
// Date             :   2011/08/10
//----------------------------------------------------------------------
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : 下記項目の追加
//                                     問発BL統一部品コード(スリーコード版)
//                                     問発BL統一部品サブコード
//                                     回答BL統一部品コード(スリーコード版)
//                                     回答BL統一部品サブコード
//                                     回答BL商品コード
//                                     回答BL商品コード枝番
//----------------------------------------------------------------------
//                (c)Copyright  2011 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SCMAcOdSetDtWork
	/// <summary>
	///                      SCM受注セット部品データワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受注セット部品データワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/04/30</br>
	/// <br>Genarated Date   :   2011/08/11  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/18  杉村</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   受注ステータス</br>
	/// <br>                 :   売上伝票番号</br>
	/// <br>                 :   売上伝票合計（税込み）</br>
	/// <br>                 :   売上小計（税）</br>
	/// <br>Update Note      :   2009/05/26  杉村</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   発注日</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   問合せ・発注種別</br>
	/// <br>                 :   問発・回答種別</br>
	/// <br>                 :   受信日時</br>
	/// <br>Update Note      :   2009/05/29  杉村</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   回答作成区分</br>
	/// <br>Update Note      :   2009/06/15  杉村</br>
	/// <br>                 :   ○キー変更</br>
	/// <br>                 :   3,9,11,13,14,15,17,18→3,9,11,13,14,15,17,18,29,30</br>
	/// <br>Update Note      :   2009/06/16  杉村</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   問合せ元企業名称</br>
	/// <br>                 :   問合せ元拠点名称</br>
	/// <br>                 :   ○桁数変更</br>
	/// <br>                 :   問合せ元拠点コード　16→6</br>
	/// <br>                 :   ○キー変更</br>
	/// <br>                 :   3,9,11,13,14,15,17,18,29,30→3,9,10,11,12,13,15,16,27,28</br>
	/// <br>Update Note      :   2010/05/25  長内</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   キャンセル区分</br>
	/// <br>                 :   CMT連携区分</br>
	/// <br>Update Note      :   2011/2/17  長内</br>
	/// <br>                 :   ○CMT連携区分補足 修正</br>
	/// <br>                 :   11:問合せ自動回答 12:発注自動回答を追加</br>
	/// <br>Update Note      :   2011/5/19  長内</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   SF-PM連携指示書番号</br>
    /// <br>Update Note      :   管理番号  10900690-00 作成担当 : qijh</br>
    /// <br>                 :   配信日なし分 Redmine#34752 「PMSCMのNo.10385」BLPの対応 </br>
    /// <br>Update Note      :   2013/05/09 30744 湯上 千加子</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   商品規格・特記事項</br>
    /// <br>                 :   SCM障害№10470対応</br>
    /// <br>Update Note      :   2015/01/19  31065 豊沢 憲弘</br>
    /// <br>                 :   管理番号 11070266-00</br>
    /// <br>                 :   SCM高速化 PMNS対応 セット品にメーカー希望小売価格、オープン価格区分の追加</br>
    /// <br>Update Note      :   2015/02/10  30745 吉岡</br>
    /// <br>                 :   管理番号 11070266-00</br>
    /// <br>                 :   SCM高速化 回答納期区分対応 項目追加</br>
    /// <br>Update Note      :   2015/02/20  31126 下口</br>
    /// <br>                 :   管理番号 11070266-00</br>
    /// <br>                 :   SCM高速化 Ｃ向け種別特記対応</br>
    /// <br>                 :   商品規格・特記事項(工場向け)、商品規格・特記事項(カーオーナー向け)、優良設定詳細名称２(工場向け)、優良設定詳細名称２(カーオーナー向け)の追加</br>
    /// <br>Update Note      :   2015/02/27  30744 湯上</br>
    /// <br>                 :   管理番号 11070266-00</br>
    /// <br>                 :   SCM高速化 Ｃ向け種別特記対応</br>
    /// <br>                 :   優良設定詳細名称２コード、優良設定詳細名称２、在庫状況区分の追加</br>
    /// <br>Update Note      :   2018/04/16  田建委</br>
    /// <br>                 :   管理番号 11470007-00</br>
    /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdSetDtWork : IFileHeader
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

		/// <summary>セット部品メーカーコード</summary>
		private Int32 _setPartsMkrCd;

		/// <summary>セット部品番号</summary>
		private string _setPartsNumber = "";

		/// <summary>セット部品親子番号</summary>
		/// <remarks>0:親,1-*:子</remarks>
		private Int32 _setPartsMainSubNo;

		/// <summary>商品種別</summary>
		/// <remarks>0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場 99:値引き</remarks>
		private Int32 _goodsDivCd;

		/// <summary>リサイクル部品種別</summary>
		/// <remarks>1:リビルド 2:中古</remarks>
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

		/// <summary>PM受注ステータス</summary>
		/// <remarks>10：見積 20:受注 30:売上 40:出荷</remarks>
		private Int32 _pMAcptAnOdrStatus;

		/// <summary>PM売上伝票番号</summary>
		/// <remarks>PMの売上伝票番号</remarks>
		private Int32 _pMSalesSlipNum;

		/// <summary>PM売上行番号</summary>
		private Int32 _pMSalesRowNo;

		/// <summary>PM倉庫コード</summary>
		private string _pmWarehouseCd = "";

		/// <summary>PM倉庫名称</summary>
		private string _pmWarehouseName = "";

		/// <summary>PM棚番</summary>
		private string _pmShelfNo = "";

		/// <summary>PM現在個数</summary>
		private Double _pmPrsntCount;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>PM主管倉庫コード</summary>
        private string _pmMainMngWarehouseCde = "";

        /// <summary>PM主管倉庫名称</summary>
        private string _pmMainMngWarehouseName = "";

        /// <summary>PM主管棚番</summary>
        private string _pmMainMngShelfNo = "";

        /// <summary>PM主管現在個数</summary>
        private Double _pmMainMngPrsntCount;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
        /// <summary>商品規格・特記事項</summary>
        private string _goodsSpclInstruction = "";
        // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<

        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// <summary>メーカー希望小売価格</summary>
        private Int64 _mkrSuggestRtPric = 0;
        /// <summary>オープン価格区分</summary>
        private Int32 _openPriceDiv = 0;
        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<

        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> 回答納期区分</summary>
        private Int16 _ansDeliDateDiv = 0;
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>商品規格・特記事項(工場向け)</summary>
        private string _goodsSpecialNtForFac = "";
        /// <summary>商品規格・特記事項(カーオーナー向け)</summary>
        private string _goodsSpecialNtForCOw = "";
        /// <summary>優良設定詳細名称２(工場向け)</summary>
        private string _prmSetDtlName2ForFac = "";
        /// <summary>優良設定詳細名称２(カーオーナー向け)</summary>
        private string _prmSetDtlName2ForCOw = "";
        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
        /// <summary>優良設定詳細コード２</summary>
        private Int32 _prmSetDtlNo2 = 0;
        /// <summary>優良設定詳細名称２</summary>
        private string _prmSetDtlName2 = "";
        /// <summary>在庫状況区分</summary>
        private Int16 _stockStatusDiv = 0;
        // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<

        // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>問発BL統一部品コード(スリーコード版)</summary>
        /// <remarks>.C コード体系項目</remarks>
        private string _inqBlUtyPtThCd = "";

        /// <summary>問発BL統一部品サブコード</summary>
        /// <remarks>.C コード体系項目</remarks>
        private Int32 _inqBlUtyPtSbCd;

        /// <summary>回答BL統一部品コード(スリーコード版)</summary>
        /// <remarks>.C コード体系項目</remarks>
        private string _ansBlUtyPtThCd = "";

        /// <summary>回答BL統一部品サブコード</summary>
        /// <remarks>.C コード体系項目</remarks>
        private Int32 _ansBlUtyPtSbCd;

        /// <summary>回答BL商品コード</summary>
        private Int32 _ansBLGoodsCode;

        /// <summary>回答BL商品コード枝番</summary>
        private Int32 _ansBLGoodsDrCode;
        // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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

		/// public propaty name  :  InqOriginalEpCd
		/// <summary>問合せ元企業コードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元企業コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string InqOriginalEpCd
		{
			get{return _inqOriginalEpCd;}
			set{_inqOriginalEpCd = value;}
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
			get{return _inqOriginalSecCd;}
			set{_inqOriginalSecCd = value;}
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
			get{return _goodsDivCd;}
			set{_goodsDivCd = value;}
		}

		/// public propaty name  :  RecyclePrtKindCode
		/// <summary>リサイクル部品種別プロパティ</summary>
		/// <value>1:リビルド 2:中古</value>
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

		/// public propaty name  :  GoodsMakerNm
		/// <summary>商品メーカー名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品メーカー名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string GoodsMakerNm
		{
			get{return _goodsMakerNm;}
			set{_goodsMakerNm = value;}
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

		/// public propaty name  :  ListPrice
		/// <summary>定価プロパティ</summary>
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
        public DateTime AnswerLimitDate
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
			get{return _pMAcptAnOdrStatus;}
			set{_pMAcptAnOdrStatus = value;}
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
			get{return _pMSalesSlipNum;}
			set{_pMSalesSlipNum = value;}
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
			get{return _pMSalesRowNo;}
			set{_pMSalesRowNo = value;}
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
			get{return _pmWarehouseCd;}
			set{_pmWarehouseCd = value;}
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
			get{return _pmWarehouseName;}
			set{_pmWarehouseName = value;}
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
			get{return _pmShelfNo;}
			set{_pmShelfNo = value;}
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

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// public propaty name  :  PmMainMngWarehouseCd
        /// <summary>PM主管倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM主管倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmMainMngWarehouseCd
        {
            get { return _pmMainMngWarehouseCde; }
            set { _pmMainMngWarehouseCde = value; }
        }

        /// public propaty name  :  PmMainMngWarehouseName
        /// <summary>PM主管倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM主管倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmMainMngWarehouseName
        {
            get { return _pmMainMngWarehouseName; }
            set { _pmMainMngWarehouseName = value; }
        }

        /// public propaty name  :  PmMainMngShelfNo
        /// <summary>PM主管棚番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM主管棚番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PmMainMngShelfNo
        {
            get { return _pmMainMngShelfNo; }
            set { _pmMainMngShelfNo = value; }
        }

        /// public propaty name  :  PmMainMngPrsntCount
        /// <summary>PM主管現在個数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM主管現在個数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PmMainMngPrsntCount
        {
            get { return _pmMainMngPrsntCount; }
            set { _pmMainMngPrsntCount = value; }
        }
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>

        /// public propaty name  :  GoodsSpclInstruction
        /// <summary>商品規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsSpclInstruction
        {
            get { return _goodsSpclInstruction; }
            set { _goodsSpclInstruction = value; }
        }

        // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<

        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// public propaty name  :  MkrSuggestRtPric
        /// <summary>メーカー希望小売価格プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メーカー希望小売価格プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 MkrSuggestRtPric
        {
            get { return _mkrSuggestRtPric; }
            set { _mkrSuggestRtPric = value; }
        }

        /// public propaty name  :  OpenPriceDiv
        /// <summary>オープン価格区分プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オープン価格区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OpenPriceDiv
        {
            get { return _openPriceDiv; }
            set { _openPriceDiv = value; }
        }
        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<

        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  AnsDeliDateDiv
        /// <summary>回答納期区分プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答納期区分プロパティ</br>
        /// </remarks>
        public Int16 AnsDeliDateDiv
        {
            get { return _ansDeliDateDiv; }
            set { _ansDeliDateDiv = value; }
        }
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  GoodsSpecialNtForFac
        /// <summary>商品規格・特記事項(工場向け)プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  商品規格・特記事項(工場向け)プロパティ</br>
        /// </remarks>
        public string GoodsSpecialNtForFac
        {
            get { return _goodsSpecialNtForFac; }
            set { _goodsSpecialNtForFac = value; }
        }

        /// public propaty name  :  GoodsSpecialNtForCOw
        /// <summary>商品規格・特記事項(カーオーナー向け)プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  商品規格・特記事項(カーオーナー向け)プロパティ</br>
        /// </remarks>
        public string GoodsSpecialNtForCOw
        {
            get { return _goodsSpecialNtForCOw; }
            set { _goodsSpecialNtForCOw = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForFac
        /// <summary>優良設定詳細名称２(工場向け)プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  優良設定詳細名称２(工場向け)プロパティ</br>
        /// </remarks>
        public string PrmSetDtlName2ForFac
        {
            get { return _prmSetDtlName2ForFac; }
            set { _prmSetDtlName2ForFac = value; }
        }

        /// public propaty name  :  PrmSetDtlName2ForCOw
        /// <summary>優良設定詳細名称２(カーオーナー向け)プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  優良設定詳細名称２(カーオーナー向け)プロパティ</br>
        /// </remarks>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>優良設定詳細コード２プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  優良設定詳細コード２プロパティ</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrmSetDtlName2
        /// <summary>優良設定詳細名称２プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  優良設定詳細名称２プロパティ</br>
        /// </remarks>
        public string PrmSetDtlName2
        {
            get { return _prmSetDtlName2; }
            set { _prmSetDtlName2 = value; }
        }

        /// public propaty name  :  StockStatusDiv
        /// <summary>在庫状況区分プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :  在庫状況区分プロパティ</br>
        /// </remarks>
        public Int16 StockStatusDiv
        {
            get { return _stockStatusDiv; }
            set { _stockStatusDiv = value; }
        }
        // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<

        // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  InqBlUtyPtThCd
        /// <summary>問発BL統一部品コード(スリーコード版)プロパティ</summary>
        /// <value>.C コード体系項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問発BL統一部品コード(スリーコード版)プロパティ</br>
        /// <br>Programer        :   田建委</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public string InqBlUtyPtThCd
        {
            get { return _inqBlUtyPtThCd; }
            set { _inqBlUtyPtThCd = value; }
        }

        /// public propaty name  :  InqBlUtyPtSbCd
        /// <summary>問発BL統一部品サブコードプロパティ</summary>
        /// <value>.C コード体系項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問発BL統一部品サブコードプロパティ</br>
        /// <br>Programer        :   田建委</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public Int32 InqBlUtyPtSbCd
        {
            get { return _inqBlUtyPtSbCd; }
            set { _inqBlUtyPtSbCd = value; }
        }

        /// public propaty name  :  AnsBlUtyPtThCd
        /// <summary>回答BL統一部品コード(スリーコード版)プロパティ</summary>
        /// <value>.C コード体系項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答BL統一部品コード(スリーコード版)プロパティ</br>
        /// <br>Programer        :   田建委</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public string AnsBlUtyPtThCd
        {
            get { return _ansBlUtyPtThCd; }
            set { _ansBlUtyPtThCd = value; }
        }

        /// public propaty name  :  AnsBlUtyPtSbCd
        /// <summary>回答BL統一部品サブコードプロパティ</summary>
        /// <value>.C コード体系項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答BL統一部品サブコードプロパティ</br>
        /// <br>Programer        :   田建委</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public Int32 AnsBlUtyPtSbCd
        {
            get { return _ansBlUtyPtSbCd; }
            set { _ansBlUtyPtSbCd = value; }
        }

        /// public propaty name  :  AnsBLGoodsCode
        /// <summary>回答BL商品コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答BL商品コードプロパティ</br>
        /// <br>Programer        :   田建委</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public Int32 AnsBLGoodsCode
        {
            get { return _ansBLGoodsCode; }
            set { _ansBLGoodsCode = value; }
        }

        /// public propaty name  :  AnsBLGoodsDrCode
        /// <summary>回答BL商品コード枝番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回答BL商品コード枝番プロパティ</br>
        /// <br>Programer        :   田建委</br>
        /// <br>Date             :   2018/04/16</br>
        /// </remarks>
        public Int32 AnsBLGoodsDrCode
        {
            get { return _ansBLGoodsDrCode; }
            set { _ansBLGoodsDrCode = value; }
        }
        // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<


        /// <summary>
		/// SCM受注セット部品データワークコンストラクタ
		/// </summary>
		/// <returns>SCMAcOdSetDtWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdSetDtWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdSetDtWork()
		{
		}

        /// <summary>
        /// SCM受注セット部品データワークコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="inqOriginalEpCd">問合せ元企業コード</param>
        /// <param name="inqOriginalSecCd">問合せ元拠点コード</param>
        /// <param name="inqOtherEpCd">問合せ先企業コード</param>
        /// <param name="inqOtherSecCd">問合せ先拠点コード</param>
        /// <param name="inquiryNumber">問合せ番号</param>
        /// <param name="setPartsMkrCd">セット部品メーカーコード</param>
        /// <param name="setPartsNumber">セット部品番号</param>
        /// <param name="setPartsMainSubNo">セット部品親子番号(0:親,1-*:子)</param>
        /// <param name="goodsDivCd">商品種別(0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場 99:値引き)</param>
        /// <param name="recyclePrtKindCode">リサイクル部品種別(1:リビルド 2:中古)</param>
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
        /// <param name="pMAcptAnOdrStatus">PM受注ステータス(10：見積 20:受注 30:売上 40:出荷)</param>
        /// <param name="pMSalesSlipNum">PM売上伝票番号(PMの売上伝票番号)</param>
        /// <param name="pMSalesRowNo">PM売上行番号</param>
        /// <param name="pmWarehouseCd">PM倉庫コード</param>
        /// <param name="pmWarehouseName">PM倉庫名称</param>
        /// <param name="pmShelfNo">PM棚番</param>
        /// <param name="pmPrsntCount">PM現在個数</param>
        /// <param name="pmMainMngWarehouseCd">PM主管倉庫コード</param>
        /// <param name="pmMainMngWarehouseName">PM主管倉庫名称</param>
        /// <param name="pmMainMngShelfNo">PM主管棚番</param>
        /// <param name="pmMainMngPrsntCount">PM主管現在個数</param>
        /// <param name="goodsSpclInstruction">商品規格・特記事項</param>
        /// <param name="mkrSuggestRtPric">メーカー希望小売価格</param>
        /// <param name="openPriceDiv">オープン価格区分</param>
        /// <param name="ansDeliDateDiv">回答納期区分</param>
        /// <param name="goodsSpecialNtForFac">商品規格・特記事項(工場向け)</param>
        /// <param name="goodsSpecialNtForCOw">商品規格・特記事項(カーオーナー向け)</param>
        /// <param name="prmSetDtlName2ForFac">優良設定詳細名称２(工場向け)</param>
        /// <param name="prmSetDtlName2ForCOw">優良設定詳細名称２(カーオーナー向け)</param>
        /// <param name="prmSetDtlNo2">優良設定詳細コード２</param>
        /// <param name="prmSetDtlName2">優良設定詳細名称２</param>
        /// <param name="stockStatusDiv">在庫状況区分</param>
        /// <param name="inqBlUtyPtThCd">問発BL統一部品コード(スリーコード版)(.C コード体系項目)</param>
        /// <param name="inqBlUtyPtSbCd">問発BL統一部品サブコード(.C コード体系項目)</param>
        /// <param name="ansBlUtyPtThCd">回答BL統一部品コード(スリーコード版)(.C コード体系項目)</param>
        /// <param name="ansBlUtyPtSbCd">回答BL統一部品サブコード(.C コード体系項目)</param>
        /// <param name="ansBLGoodsCode">回答BL商品コード</param>
        /// <param name="ansBLGoodsDrCode">回答BL商品コード枝番</param>
        /// <returns>SCMAcOdSetDtWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdSetDtWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16  田建委</br>
        /// <br>                 :   管理番号 11470007-00</br>
        /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
        /// </remarks>
        public SCMAcOdSetDtWork(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, Int32 setPartsMkrCd, string setPartsNumber, Int32 setPartsMainSubNo, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, string shelfNo, Int32 pMAcptAnOdrStatus, Int32 pMSalesSlipNum, Int32 pMSalesRowNo, string pmWarehouseCd, string pmWarehouseName, string pmShelfNo, Double pmPrsntCount
            , string pmMainMngWarehouseCd, string pmMainMngWarehouseName, string pmMainMngShelfNo, Double pmMainMngPrsntCount // ADD 2013/02/27 qijh #34752
            // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
            , string goodsSpclInstruction
            // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
            , Int64 mkrSuggestRtPric, Int32 openPriceDiv // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応
            , Int16 ansDeliDateDiv // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
            , string goodsSpecialNtForFac // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応
            , string goodsSpecialNtForCOw // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応
            , string prmSetDtlName2ForFac // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応
            , string prmSetDtlName2ForCOw // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応
            , int prmSetDtlNo2      // ADD 2015/02/27 SCM高速化 Ｃ向け種別特記対応
            , string prmSetDtlName2 // ADD 2015/02/27 SCM高速化 Ｃ向け種別特記対応
            , short stockStatusDiv    // ADD 2015/02/27 SCM高速化 Ｃ向け種別特記対応
            // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            , string inqBlUtyPtThCd
            ,Int32 inqBlUtyPtSbCd
            ,string ansBlUtyPtThCd
            ,Int32 ansBlUtyPtSbCd
            ,Int32 ansBLGoodsCode
            ,Int32 ansBLGoodsDrCode
            // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            )
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._inqOriginalEpCd = inqOriginalEpCd.Trim();	//@@@@20230303
            this._inqOriginalSecCd = inqOriginalSecCd;
            this._inqOtherEpCd = inqOtherEpCd;
            this._inqOtherSecCd = inqOtherSecCd;
            this._inquiryNumber = inquiryNumber;
            this._setPartsMkrCd = setPartsMkrCd;
            this._setPartsNumber = setPartsNumber;
            this._setPartsMainSubNo = setPartsMainSubNo;
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
            this._answerLimitDate = answerLimitDate;
            this._commentDtl = commentDtl;
            this._shelfNo = shelfNo;
            this._pMAcptAnOdrStatus = pMAcptAnOdrStatus;
            this._pMSalesSlipNum = pMSalesSlipNum;
            this._pMSalesRowNo = pMSalesRowNo;
            this._pmWarehouseCd = pmWarehouseCd;
            this._pmWarehouseName = pmWarehouseName;
            this._pmShelfNo = pmShelfNo;
            this._pmPrsntCount = pmPrsntCount;
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            this._pmMainMngWarehouseCde = pmMainMngWarehouseCd;
            this._pmMainMngWarehouseName = pmMainMngWarehouseName;
            this._pmMainMngShelfNo = pmMainMngShelfNo;
            this._pmMainMngPrsntCount = pmMainMngPrsntCount;
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
            this._goodsSpclInstruction = GoodsSpclInstruction;
            // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
            // ADD 2015/01/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            this._mkrSuggestRtPric = mkrSuggestRtPric;
            this._openPriceDiv = openPriceDiv;
            // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._ansDeliDateDiv = ansDeliDateDiv;
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._goodsSpecialNtForFac = goodsSpecialNtForFac;
            this._goodsSpecialNtForCOw = goodsSpecialNtForCOw;
            this._prmSetDtlName2ForFac = prmSetDtlName2ForFac;
            this._prmSetDtlName2ForCOw = prmSetDtlName2ForCOw;
            // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
            this._prmSetDtlNo2 = prmSetDtlNo2;
            this._prmSetDtlName2 = prmSetDtlName2;
            this._stockStatusDiv = stockStatusDiv;
            // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<
            // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._inqBlUtyPtThCd = inqBlUtyPtThCd;
            this._inqBlUtyPtSbCd = inqBlUtyPtSbCd;
            this._ansBlUtyPtThCd = ansBlUtyPtThCd;
            this._ansBlUtyPtSbCd = ansBlUtyPtSbCd;
            this._ansBLGoodsCode = ansBLGoodsCode;
            this._ansBLGoodsDrCode = ansBLGoodsDrCode;
            // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
        /// SCM受注セット部品データワーク複製処理
        /// </summary>
        /// <returns>SCMAcOdSetDtWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSCMAcOdSetDtWorkクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16  田建委</br>
        /// <br>                 :   管理番号 11470007-00</br>
        /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
        /// </remarks>
        public SCMAcOdSetDtWork Clone()
        {
            return new SCMAcOdSetDtWork(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._setPartsMkrCd, this._setPartsNumber, this._setPartsMainSubNo, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._shelfNo, this._pMAcptAnOdrStatus, this._pMSalesSlipNum, this._pMSalesRowNo, this._pmWarehouseCd, this._pmWarehouseName, this._pmShelfNo, this._pmPrsntCount//@@@@20230303
                , this._pmMainMngWarehouseCde, this._pmMainMngWarehouseName, this._pmMainMngShelfNo, this._pmMainMngPrsntCount // ADD 2013/02/27 qijh #34752
            // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
                , this._goodsSpclInstruction
            // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
                , this._mkrSuggestRtPric, this._openPriceDiv // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応
                , this._ansDeliDateDiv  // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応
                , this._goodsSpecialNtForFac  // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応
                , this._goodsSpecialNtForCOw  // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応
                , this._prmSetDtlName2ForFac  // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応
                , this._prmSetDtlName2ForCOw  // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応
                , this._prmSetDtlNo2       // ADD 2015/02/27 SCM高速化 Ｃ向け種別特記対応
                , this._prmSetDtlName2     // ADD 2015/02/27 SCM高速化 Ｃ向け種別特記対応
                , this._stockStatusDiv     // ADD 2015/02/27 SCM高速化 Ｃ向け種別特記対応
                // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                , this._inqBlUtyPtThCd
                , this._inqBlUtyPtSbCd
                , this._ansBlUtyPtThCd
                , this._ansBlUtyPtSbCd
                , this._ansBLGoodsCode
                , this._ansBLGoodsDrCode
                // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                );
        }

        /// <summary>
        /// SCM受注セット部品データワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のSCMAcOdSetDtWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdSetDtWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16  田建委</br>
        /// <br>                 :   管理番号 11470007-00</br>
        /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
        /// </remarks>
        public bool Equals(SCMAcOdSetDtWork target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim())	//@@@@20230303
                 && (this.InqOriginalSecCd == target.InqOriginalSecCd)
                 && (this.InqOtherEpCd == target.InqOtherEpCd)
                 && (this.InqOtherSecCd == target.InqOtherSecCd)
                 && (this.InquiryNumber == target.InquiryNumber)
                 && (this.SetPartsMkrCd == target.SetPartsMkrCd)
                 && (this.SetPartsNumber == target.SetPartsNumber)
                 && (this.SetPartsMainSubNo == target.SetPartsMainSubNo)
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
                 && (this.PMAcptAnOdrStatus == target.PMAcptAnOdrStatus)
                 && (this.PMSalesSlipNum == target.PMSalesSlipNum)
                 && (this.PMSalesRowNo == target.PMSalesRowNo)
                 && (this.PmWarehouseCd == target.PmWarehouseCd)
                 && (this.PmWarehouseName == target.PmWarehouseName)
                 && (this.PmShelfNo == target.PmShelfNo)
                 && (this.PmPrsntCount == target.PmPrsntCount)
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                 && (this.PmMainMngWarehouseCd == target.PmMainMngWarehouseCd)
                 && (this.PmMainMngWarehouseName == target.PmMainMngWarehouseName)
                 && (this.PmMainMngShelfNo == target.PmMainMngShelfNo)
                 && (this.PmMainMngPrsntCount == target.PmMainMngPrsntCount)
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
                 && (this.PmPrsntCount == target.PmPrsntCount)
                 && (this.GoodsSpclInstruction == target.GoodsSpclInstruction)
                // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
                // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
                 && (this.MkrSuggestRtPric == target.MkrSuggestRtPric)
                 && (this.OpenPriceDiv == target.OpenPriceDiv)
                // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                && (this.AnsDeliDateDiv == target.AnsDeliDateDiv)
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                && (this.GoodsSpecialNtForFac == target.GoodsSpecialNtForFac)
                && (this.GoodsSpecialNtForCOw == target.GoodsSpecialNtForCOw)
                && (this.PrmSetDtlName2ForFac == target.PrmSetDtlName2ForFac)
                && (this.PrmSetDtlName2ForCOw == target.PrmSetDtlName2ForCOw)
                // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
                && (this.PrmSetDtlNo2 == target.PrmSetDtlNo2)
                && (this.PrmSetDtlName2 == target.PrmSetDtlName2)
                && (this.StockStatusDiv == target.StockStatusDiv)
                // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<
                // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (this.InqBlUtyPtThCd == target.InqBlUtyPtThCd)
                 && (this.InqBlUtyPtSbCd == target.InqBlUtyPtSbCd)
                 && (this.AnsBlUtyPtThCd == target.AnsBlUtyPtThCd)
                 && (this.AnsBlUtyPtSbCd == target.AnsBlUtyPtSbCd)
                 && (this.AnsBLGoodsCode == target.AnsBLGoodsCode)
                 && (this.AnsBLGoodsDrCode == target.AnsBLGoodsDrCode)
                // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                );
        }

        /// <summary>
        /// SCM受注セット部品データワーク比較処理
        /// </summary>
        /// <param name="scmAcOdSetDt1">
        ///                    比較するSCMAcOdSetDtWorkクラスのインスタンス
        /// </param>
        /// <param name="scmAcOdSetDt2">比較するSCMAcOdSetDtWorkクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdSetDtWorkクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16  田建委</br>
        /// <br>                 :   管理番号 11470007-00</br>
        /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
        /// </remarks>
        public static bool Equals(SCMAcOdSetDtWork scmAcOdSetDt1, SCMAcOdSetDtWork scmAcOdSetDt2)
        {
            return ((scmAcOdSetDt1.CreateDateTime == scmAcOdSetDt2.CreateDateTime)
                 && (scmAcOdSetDt1.UpdateDateTime == scmAcOdSetDt2.UpdateDateTime)
                 && (scmAcOdSetDt1.EnterpriseCode == scmAcOdSetDt2.EnterpriseCode)
                 && (scmAcOdSetDt1.FileHeaderGuid == scmAcOdSetDt2.FileHeaderGuid)
                 && (scmAcOdSetDt1.UpdEmployeeCode == scmAcOdSetDt2.UpdEmployeeCode)
                 && (scmAcOdSetDt1.UpdAssemblyId1 == scmAcOdSetDt2.UpdAssemblyId1)
                 && (scmAcOdSetDt1.UpdAssemblyId2 == scmAcOdSetDt2.UpdAssemblyId2)
                 && (scmAcOdSetDt1.LogicalDeleteCode == scmAcOdSetDt2.LogicalDeleteCode)
                 && (scmAcOdSetDt1.InqOriginalEpCd.Trim() == scmAcOdSetDt2.InqOriginalEpCd.Trim())	//@@@@20230303
                 && (scmAcOdSetDt1.InqOriginalSecCd == scmAcOdSetDt2.InqOriginalSecCd)
                 && (scmAcOdSetDt1.InqOtherEpCd == scmAcOdSetDt2.InqOtherEpCd)
                 && (scmAcOdSetDt1.InqOtherSecCd == scmAcOdSetDt2.InqOtherSecCd)
                 && (scmAcOdSetDt1.InquiryNumber == scmAcOdSetDt2.InquiryNumber)
                 && (scmAcOdSetDt1.SetPartsMkrCd == scmAcOdSetDt2.SetPartsMkrCd)
                 && (scmAcOdSetDt1.SetPartsNumber == scmAcOdSetDt2.SetPartsNumber)
                 && (scmAcOdSetDt1.SetPartsMainSubNo == scmAcOdSetDt2.SetPartsMainSubNo)
                 && (scmAcOdSetDt1.GoodsDivCd == scmAcOdSetDt2.GoodsDivCd)
                 && (scmAcOdSetDt1.RecyclePrtKindCode == scmAcOdSetDt2.RecyclePrtKindCode)
                 && (scmAcOdSetDt1.RecyclePrtKindName == scmAcOdSetDt2.RecyclePrtKindName)
                 && (scmAcOdSetDt1.DeliveredGoodsDiv == scmAcOdSetDt2.DeliveredGoodsDiv)
                 && (scmAcOdSetDt1.HandleDivCode == scmAcOdSetDt2.HandleDivCode)
                 && (scmAcOdSetDt1.GoodsShape == scmAcOdSetDt2.GoodsShape)
                 && (scmAcOdSetDt1.DelivrdGdsConfCd == scmAcOdSetDt2.DelivrdGdsConfCd)
                 && (scmAcOdSetDt1.DeliGdsCmpltDueDate == scmAcOdSetDt2.DeliGdsCmpltDueDate)
                 && (scmAcOdSetDt1.AnswerDeliveryDate == scmAcOdSetDt2.AnswerDeliveryDate)
                 && (scmAcOdSetDt1.BLGoodsCode == scmAcOdSetDt2.BLGoodsCode)
                 && (scmAcOdSetDt1.BLGoodsDrCode == scmAcOdSetDt2.BLGoodsDrCode)
                 && (scmAcOdSetDt1.InqGoodsName == scmAcOdSetDt2.InqGoodsName)
                 && (scmAcOdSetDt1.AnsGoodsName == scmAcOdSetDt2.AnsGoodsName)
                 && (scmAcOdSetDt1.SalesOrderCount == scmAcOdSetDt2.SalesOrderCount)
                 && (scmAcOdSetDt1.DeliveredGoodsCount == scmAcOdSetDt2.DeliveredGoodsCount)
                 && (scmAcOdSetDt1.GoodsNo == scmAcOdSetDt2.GoodsNo)
                 && (scmAcOdSetDt1.GoodsMakerCd == scmAcOdSetDt2.GoodsMakerCd)
                 && (scmAcOdSetDt1.GoodsMakerNm == scmAcOdSetDt2.GoodsMakerNm)
                 && (scmAcOdSetDt1.PureGoodsMakerCd == scmAcOdSetDt2.PureGoodsMakerCd)
                 && (scmAcOdSetDt1.InqPureGoodsNo == scmAcOdSetDt2.InqPureGoodsNo)
                 && (scmAcOdSetDt1.AnsPureGoodsNo == scmAcOdSetDt2.AnsPureGoodsNo)
                 && (scmAcOdSetDt1.ListPrice == scmAcOdSetDt2.ListPrice)
                 && (scmAcOdSetDt1.UnitPrice == scmAcOdSetDt2.UnitPrice)
                 && (scmAcOdSetDt1.GoodsAddInfo == scmAcOdSetDt2.GoodsAddInfo)
                 && (scmAcOdSetDt1.RoughRrofit == scmAcOdSetDt2.RoughRrofit)
                 && (scmAcOdSetDt1.RoughRate == scmAcOdSetDt2.RoughRate)
                 && (scmAcOdSetDt1.AnswerLimitDate == scmAcOdSetDt2.AnswerLimitDate)
                 && (scmAcOdSetDt1.CommentDtl == scmAcOdSetDt2.CommentDtl)
                 && (scmAcOdSetDt1.ShelfNo == scmAcOdSetDt2.ShelfNo)
                 && (scmAcOdSetDt1.PMAcptAnOdrStatus == scmAcOdSetDt2.PMAcptAnOdrStatus)
                 && (scmAcOdSetDt1.PMSalesSlipNum == scmAcOdSetDt2.PMSalesSlipNum)
                 && (scmAcOdSetDt1.PMSalesRowNo == scmAcOdSetDt2.PMSalesRowNo)
                 && (scmAcOdSetDt1.PmWarehouseCd == scmAcOdSetDt2.PmWarehouseCd)
                 && (scmAcOdSetDt1.PmWarehouseName == scmAcOdSetDt2.PmWarehouseName)
                 && (scmAcOdSetDt1.PmShelfNo == scmAcOdSetDt2.PmShelfNo)
                 && (scmAcOdSetDt1.PmPrsntCount == scmAcOdSetDt2.PmPrsntCount)
                // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
                 && (scmAcOdSetDt1.PmMainMngWarehouseCd == scmAcOdSetDt2.PmMainMngWarehouseCd)
                 && (scmAcOdSetDt1.PmMainMngWarehouseName == scmAcOdSetDt2.PmMainMngWarehouseName)
                 && (scmAcOdSetDt1.PmMainMngShelfNo == scmAcOdSetDt2.PmMainMngShelfNo)
                 && (scmAcOdSetDt1.PmMainMngPrsntCount == scmAcOdSetDt2.PmMainMngPrsntCount)
                // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
                // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
                 && (scmAcOdSetDt1.PmPrsntCount == scmAcOdSetDt2.PmPrsntCount)
                 && (scmAcOdSetDt1.GoodsSpclInstruction == scmAcOdSetDt2.GoodsSpclInstruction)
                // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
                // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
                 && (scmAcOdSetDt1.MkrSuggestRtPric == scmAcOdSetDt2.MkrSuggestRtPric)
                 && (scmAcOdSetDt1.OpenPriceDiv == scmAcOdSetDt2.OpenPriceDiv)
                // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                && (scmAcOdSetDt1.AnsDeliDateDiv == scmAcOdSetDt2.AnsDeliDateDiv)
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                && (scmAcOdSetDt1.GoodsSpecialNtForFac == scmAcOdSetDt2.GoodsSpecialNtForFac)
                && (scmAcOdSetDt1.GoodsSpecialNtForCOw == scmAcOdSetDt2.GoodsSpecialNtForCOw)
                && (scmAcOdSetDt1.PrmSetDtlName2ForFac == scmAcOdSetDt2.PrmSetDtlName2ForFac)
                && (scmAcOdSetDt1.PrmSetDtlName2ForCOw == scmAcOdSetDt2.PrmSetDtlName2ForCOw)
                // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
                && (scmAcOdSetDt1.PrmSetDtlNo2 == scmAcOdSetDt2.PrmSetDtlNo2)
                && (scmAcOdSetDt1.PrmSetDtlName2 == scmAcOdSetDt2.PrmSetDtlName2)
                && (scmAcOdSetDt1.StockStatusDiv == scmAcOdSetDt2.StockStatusDiv)
                // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<
                // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (scmAcOdSetDt1.InqBlUtyPtThCd == scmAcOdSetDt2.InqBlUtyPtThCd)
                 && (scmAcOdSetDt1.InqBlUtyPtSbCd == scmAcOdSetDt2.InqBlUtyPtSbCd)
                 && (scmAcOdSetDt1.AnsBlUtyPtThCd == scmAcOdSetDt2.AnsBlUtyPtThCd)
                 && (scmAcOdSetDt1.AnsBlUtyPtSbCd == scmAcOdSetDt2.AnsBlUtyPtSbCd)
                 && (scmAcOdSetDt1.AnsBLGoodsCode == scmAcOdSetDt2.AnsBLGoodsCode)
                 && (scmAcOdSetDt1.AnsBLGoodsDrCode == scmAcOdSetDt2.AnsBLGoodsDrCode)
                // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                );
        }
        /// <summary>
        /// SCM受注セット部品データワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のSCMAcOdSetDtWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdSetDtWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16  田建委</br>
        /// <br>                 :   管理番号 11470007-00</br>
        /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
        /// </remarks>
        public ArrayList Compare(SCMAcOdSetDtWork target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");	//@@@@20230303
            if (this.InqOriginalSecCd != target.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (this.InqOtherEpCd != target.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (this.InqOtherSecCd != target.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (this.InquiryNumber != target.InquiryNumber) resList.Add("InquiryNumber");
            if (this.SetPartsMkrCd != target.SetPartsMkrCd) resList.Add("SetPartsMkrCd");
            if (this.SetPartsNumber != target.SetPartsNumber) resList.Add("SetPartsNumber");
            if (this.SetPartsMainSubNo != target.SetPartsMainSubNo) resList.Add("SetPartsMainSubNo");
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
            if (this.PMAcptAnOdrStatus != target.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
            if (this.PMSalesSlipNum != target.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
            if (this.PMSalesRowNo != target.PMSalesRowNo) resList.Add("PMSalesRowNo");
            if (this.PmWarehouseCd != target.PmWarehouseCd) resList.Add("PmWarehouseCd");
            if (this.PmWarehouseName != target.PmWarehouseName) resList.Add("PmWarehouseName");
            if (this.PmShelfNo != target.PmShelfNo) resList.Add("PmShelfNo");
            if (this.PmPrsntCount != target.PmPrsntCount) resList.Add("PmPrsntCount");
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            if (this.PmMainMngWarehouseCd != target.PmMainMngWarehouseCd) resList.Add("PmMainMngWarehouseCd");
            if (this.PmMainMngWarehouseName != target.PmMainMngWarehouseName) resList.Add("PmMainMngWarehouseName");
            if (this.PmMainMngShelfNo != target.PmMainMngShelfNo) resList.Add("PmMainMngShelfNo");
            if (this.PmMainMngPrsntCount != target.PmMainMngPrsntCount) resList.Add("PmMainMngPrsntCount");
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
            if (this.GoodsSpclInstruction != target.GoodsSpclInstruction) resList.Add("GoodsSpclInstruction");
            // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
            // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
            if (this.MkrSuggestRtPric != target.MkrSuggestRtPric) resList.Add("MkrSuggestRtPric");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.AnsDeliDateDiv != target.AnsDeliDateDiv) resList.Add("AnsDeliDateDiv");
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.GoodsSpecialNtForFac != target.GoodsSpecialNtForFac) resList.Add("GoodsSpecialNtForFac");
            if (this.GoodsSpecialNtForCOw != target.GoodsSpecialNtForCOw) resList.Add("GoodsSpecialNtForCOw");
            if (this.PrmSetDtlName2ForFac != target.PrmSetDtlName2ForFac) resList.Add("PrmSetDtlName2ForFac");
            if (this.PrmSetDtlName2ForCOw != target.PrmSetDtlName2ForCOw) resList.Add("PrmSetDtlName2ForCOw");
            // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
            if (this.PrmSetDtlNo2 != target.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (this.PrmSetDtlName2 != target.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (this.StockStatusDiv != target.StockStatusDiv) resList.Add("StockStatusDiv");
            // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<
            // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.InqBlUtyPtThCd != target.InqBlUtyPtThCd) resList.Add("InqBlUtyPtThCd");
            if (this.InqBlUtyPtSbCd != target.InqBlUtyPtSbCd) resList.Add("InqBlUtyPtSbCd");
            if (this.AnsBlUtyPtThCd != target.AnsBlUtyPtThCd) resList.Add("AnsBlUtyPtThCd");
            if (this.AnsBlUtyPtSbCd != target.AnsBlUtyPtSbCd) resList.Add("AnsBlUtyPtSbCd");
            if (this.AnsBLGoodsCode != target.AnsBLGoodsCode) resList.Add("AnsBLGoodsCode");
            if (this.AnsBLGoodsDrCode != target.AnsBLGoodsDrCode) resList.Add("AnsBLGoodsDrCode");
            // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            return resList;
        }

        /// <summary>
        /// SCM受注セット部品データワーク比較処理
        /// </summary>
        /// <param name="scmAcOdSetDt1">比較するSCMAcOdSetDtWorkクラスのインスタンス</param>
        /// <param name="scmAcOdSetDt2">比較するSCMAcOdSetDtWorkクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdSetDtWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16  田建委</br>
        /// <br>                 :   管理番号 11470007-00</br>
        /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
        /// </remarks>
        public static ArrayList Compare(SCMAcOdSetDtWork scmAcOdSetDt1, SCMAcOdSetDtWork scmAcOdSetDt2)
        {
            ArrayList resList = new ArrayList();
            if (scmAcOdSetDt1.CreateDateTime != scmAcOdSetDt2.CreateDateTime) resList.Add("CreateDateTime");
            if (scmAcOdSetDt1.UpdateDateTime != scmAcOdSetDt2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (scmAcOdSetDt1.EnterpriseCode != scmAcOdSetDt2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (scmAcOdSetDt1.FileHeaderGuid != scmAcOdSetDt2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (scmAcOdSetDt1.UpdEmployeeCode != scmAcOdSetDt2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (scmAcOdSetDt1.UpdAssemblyId1 != scmAcOdSetDt2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (scmAcOdSetDt1.UpdAssemblyId2 != scmAcOdSetDt2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (scmAcOdSetDt1.LogicalDeleteCode != scmAcOdSetDt2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (scmAcOdSetDt1.InqOriginalEpCd.Trim() != scmAcOdSetDt2.InqOriginalEpCd.Trim()) resList.Add("InqOriginalEpCd");	//@@@@20230303
            if (scmAcOdSetDt1.InqOriginalSecCd != scmAcOdSetDt2.InqOriginalSecCd) resList.Add("InqOriginalSecCd");
            if (scmAcOdSetDt1.InqOtherEpCd != scmAcOdSetDt2.InqOtherEpCd) resList.Add("InqOtherEpCd");
            if (scmAcOdSetDt1.InqOtherSecCd != scmAcOdSetDt2.InqOtherSecCd) resList.Add("InqOtherSecCd");
            if (scmAcOdSetDt1.InquiryNumber != scmAcOdSetDt2.InquiryNumber) resList.Add("InquiryNumber");
            if (scmAcOdSetDt1.SetPartsMkrCd != scmAcOdSetDt2.SetPartsMkrCd) resList.Add("SetPartsMkrCd");
            if (scmAcOdSetDt1.SetPartsNumber != scmAcOdSetDt2.SetPartsNumber) resList.Add("SetPartsNumber");
            if (scmAcOdSetDt1.SetPartsMainSubNo != scmAcOdSetDt2.SetPartsMainSubNo) resList.Add("SetPartsMainSubNo");
            if (scmAcOdSetDt1.GoodsDivCd != scmAcOdSetDt2.GoodsDivCd) resList.Add("GoodsDivCd");
            if (scmAcOdSetDt1.RecyclePrtKindCode != scmAcOdSetDt2.RecyclePrtKindCode) resList.Add("RecyclePrtKindCode");
            if (scmAcOdSetDt1.RecyclePrtKindName != scmAcOdSetDt2.RecyclePrtKindName) resList.Add("RecyclePrtKindName");
            if (scmAcOdSetDt1.DeliveredGoodsDiv != scmAcOdSetDt2.DeliveredGoodsDiv) resList.Add("DeliveredGoodsDiv");
            if (scmAcOdSetDt1.HandleDivCode != scmAcOdSetDt2.HandleDivCode) resList.Add("HandleDivCode");
            if (scmAcOdSetDt1.GoodsShape != scmAcOdSetDt2.GoodsShape) resList.Add("GoodsShape");
            if (scmAcOdSetDt1.DelivrdGdsConfCd != scmAcOdSetDt2.DelivrdGdsConfCd) resList.Add("DelivrdGdsConfCd");
            if (scmAcOdSetDt1.DeliGdsCmpltDueDate != scmAcOdSetDt2.DeliGdsCmpltDueDate) resList.Add("DeliGdsCmpltDueDate");
            if (scmAcOdSetDt1.AnswerDeliveryDate != scmAcOdSetDt2.AnswerDeliveryDate) resList.Add("AnswerDeliveryDate");
            if (scmAcOdSetDt1.BLGoodsCode != scmAcOdSetDt2.BLGoodsCode) resList.Add("BLGoodsCode");
            if (scmAcOdSetDt1.BLGoodsDrCode != scmAcOdSetDt2.BLGoodsDrCode) resList.Add("BLGoodsDrCode");
            if (scmAcOdSetDt1.InqGoodsName != scmAcOdSetDt2.InqGoodsName) resList.Add("InqGoodsName");
            if (scmAcOdSetDt1.AnsGoodsName != scmAcOdSetDt2.AnsGoodsName) resList.Add("AnsGoodsName");
            if (scmAcOdSetDt1.SalesOrderCount != scmAcOdSetDt2.SalesOrderCount) resList.Add("SalesOrderCount");
            if (scmAcOdSetDt1.DeliveredGoodsCount != scmAcOdSetDt2.DeliveredGoodsCount) resList.Add("DeliveredGoodsCount");
            if (scmAcOdSetDt1.GoodsNo != scmAcOdSetDt2.GoodsNo) resList.Add("GoodsNo");
            if (scmAcOdSetDt1.GoodsMakerCd != scmAcOdSetDt2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (scmAcOdSetDt1.GoodsMakerNm != scmAcOdSetDt2.GoodsMakerNm) resList.Add("GoodsMakerNm");
            if (scmAcOdSetDt1.PureGoodsMakerCd != scmAcOdSetDt2.PureGoodsMakerCd) resList.Add("PureGoodsMakerCd");
            if (scmAcOdSetDt1.InqPureGoodsNo != scmAcOdSetDt2.InqPureGoodsNo) resList.Add("InqPureGoodsNo");
            if (scmAcOdSetDt1.AnsPureGoodsNo != scmAcOdSetDt2.AnsPureGoodsNo) resList.Add("AnsPureGoodsNo");
            if (scmAcOdSetDt1.ListPrice != scmAcOdSetDt2.ListPrice) resList.Add("ListPrice");
            if (scmAcOdSetDt1.UnitPrice != scmAcOdSetDt2.UnitPrice) resList.Add("UnitPrice");
            if (scmAcOdSetDt1.GoodsAddInfo != scmAcOdSetDt2.GoodsAddInfo) resList.Add("GoodsAddInfo");
            if (scmAcOdSetDt1.RoughRrofit != scmAcOdSetDt2.RoughRrofit) resList.Add("RoughRrofit");
            if (scmAcOdSetDt1.RoughRate != scmAcOdSetDt2.RoughRate) resList.Add("RoughRate");
            if (scmAcOdSetDt1.AnswerLimitDate != scmAcOdSetDt2.AnswerLimitDate) resList.Add("AnswerLimitDate");
            if (scmAcOdSetDt1.CommentDtl != scmAcOdSetDt2.CommentDtl) resList.Add("CommentDtl");
            if (scmAcOdSetDt1.ShelfNo != scmAcOdSetDt2.ShelfNo) resList.Add("ShelfNo");
            if (scmAcOdSetDt1.PMAcptAnOdrStatus != scmAcOdSetDt2.PMAcptAnOdrStatus) resList.Add("PMAcptAnOdrStatus");
            if (scmAcOdSetDt1.PMSalesSlipNum != scmAcOdSetDt2.PMSalesSlipNum) resList.Add("PMSalesSlipNum");
            if (scmAcOdSetDt1.PMSalesRowNo != scmAcOdSetDt2.PMSalesRowNo) resList.Add("PMSalesRowNo");
            if (scmAcOdSetDt1.PmWarehouseCd != scmAcOdSetDt2.PmWarehouseCd) resList.Add("PmWarehouseCd");
            if (scmAcOdSetDt1.PmWarehouseName != scmAcOdSetDt2.PmWarehouseName) resList.Add("PmWarehouseName");
            if (scmAcOdSetDt1.PmShelfNo != scmAcOdSetDt2.PmShelfNo) resList.Add("PmShelfNo");
            if (scmAcOdSetDt1.PmPrsntCount != scmAcOdSetDt2.PmPrsntCount) resList.Add("PmPrsntCount");
            // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
            if (scmAcOdSetDt1.PmMainMngWarehouseCd != scmAcOdSetDt2.PmMainMngWarehouseCd) resList.Add("PmMainMngWarehouseCd");
            if (scmAcOdSetDt1.PmMainMngWarehouseName != scmAcOdSetDt2.PmMainMngWarehouseName) resList.Add("PmMainMngWarehouseName");
            if (scmAcOdSetDt1.PmMainMngShelfNo != scmAcOdSetDt2.PmMainMngShelfNo) resList.Add("PmMainMngShelfNo");
            if (scmAcOdSetDt1.PmMainMngPrsntCount != scmAcOdSetDt2.PmMainMngPrsntCount) resList.Add("PmMainMngPrsntCount");
            // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
            // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
            if (scmAcOdSetDt1.GoodsSpclInstruction != scmAcOdSetDt2.GoodsSpclInstruction) resList.Add("GoodsSpclInstruction");
            // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
            // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
            if (scmAcOdSetDt1.MkrSuggestRtPric != scmAcOdSetDt2.MkrSuggestRtPric) resList.Add("MkrSuggestRtPric");
            if (scmAcOdSetDt1.OpenPriceDiv != scmAcOdSetDt2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (scmAcOdSetDt1.AnsDeliDateDiv != scmAcOdSetDt2.AnsDeliDateDiv) resList.Add("AnsDeliDateDiv");
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (scmAcOdSetDt1.GoodsSpecialNtForFac != scmAcOdSetDt2.GoodsSpecialNtForFac) resList.Add("GoodsSpecialNtForFac");
            if (scmAcOdSetDt1.GoodsSpecialNtForCOw != scmAcOdSetDt2.GoodsSpecialNtForCOw) resList.Add("GoodsSpecialNtForCOw");
            if (scmAcOdSetDt1.PrmSetDtlName2ForFac != scmAcOdSetDt2.PrmSetDtlName2ForFac) resList.Add("PrmSetDtlName2ForFac");
            if (scmAcOdSetDt1.PrmSetDtlName2ForCOw != scmAcOdSetDt2.PrmSetDtlName2ForCOw) resList.Add("PrmSetDtlName2ForCOw");
            // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
            if (scmAcOdSetDt1.PrmSetDtlNo2 != scmAcOdSetDt2.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (scmAcOdSetDt1.PrmSetDtlName2 != scmAcOdSetDt2.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (scmAcOdSetDt1.StockStatusDiv != scmAcOdSetDt2.StockStatusDiv) resList.Add("StockStatusDiv");
            // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<
            // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (scmAcOdSetDt1.InqBlUtyPtThCd != scmAcOdSetDt2.InqBlUtyPtThCd) resList.Add("InqBlUtyPtThCd");
            if (scmAcOdSetDt1.InqBlUtyPtSbCd != scmAcOdSetDt2.InqBlUtyPtSbCd) resList.Add("InqBlUtyPtSbCd");
            if (scmAcOdSetDt1.AnsBlUtyPtThCd != scmAcOdSetDt2.AnsBlUtyPtThCd) resList.Add("AnsBlUtyPtThCd");
            if (scmAcOdSetDt1.AnsBlUtyPtSbCd != scmAcOdSetDt2.AnsBlUtyPtSbCd) resList.Add("AnsBlUtyPtSbCd");
            if (scmAcOdSetDt1.AnsBLGoodsCode != scmAcOdSetDt2.AnsBLGoodsCode) resList.Add("AnsBLGoodsCode");
            if (scmAcOdSetDt1.AnsBLGoodsDrCode != scmAcOdSetDt2.AnsBLGoodsDrCode) resList.Add("AnsBLGoodsDrCode");
            // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            return resList;
        }
	}
	
	/// <summary>
///  Ver5.10.1.0用のカスタムシライアライザです。
/// </summary>
/// <returns>SCMAcOdSetDtWorkクラスのインスタンス(object)</returns>
/// <remarks>
/// <br>Note　　　　　　 :   SCMAcOdSetDtWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      :   2018/04/16  田建委</br>
    /// <br>                 :   管理番号 11470007-00</br>
    /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
/// </remarks>
public class ScmAcOdSetDtWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
{
	#region ICustomSerializationSurrogate メンバ
	
	/// <summary>
	///  Ver5.10.1.0用のカスタムシリアライザです
	/// </summary>
	/// <remarks>
	/// <br>Note　　　　　　 :   SCMAcOdSetDtWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      :   2018/04/16  田建委</br>
    /// <br>                 :   管理番号 11470007-00</br>
    /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
	/// </remarks>
	public void Serialize(System.IO.BinaryWriter writer, object graph)
	{
		// TODO:  ScmAcOdSetDtWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
		if(  writer == null )
			throw new ArgumentNullException();

		if( graph != null && !( graph is SCMAcOdSetDtWork || graph is ArrayList || graph is SCMAcOdSetDtWork[]) )
			throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(SCMAcOdSetDtWork).FullName ) );

		if( graph != null && graph is SCMAcOdSetDtWork )
		{
			Type t = graph.GetType();
			if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
		}

		//SerializationTypeInfo
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdSetDtWork" );

		//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
		int occurrence = 0;     //一般にゼロの場合もありえます
		if( graph is ArrayList )
		{
			serInfo.RetTypeInfo = 0;
			occurrence = ((ArrayList)graph).Count;
		}
                else if( graph is SCMAcOdSetDtWork[] )
		{
			serInfo.RetTypeInfo = 2;
			occurrence = ((SCMAcOdSetDtWork[])graph).Length;
		}
		else if( graph is SCMAcOdSetDtWork )
		{
			serInfo.RetTypeInfo = 1;
			occurrence = 1;
		}

		serInfo.Occurrence = occurrence;		 //繰り返し数	

		//作成日時
		serInfo.MemberInfo.Add( typeof(Int64) ); //CreateDateTime
		//更新日時
		serInfo.MemberInfo.Add( typeof(Int64) ); //UpdateDateTime
		//企業コード
		serInfo.MemberInfo.Add( typeof(string) ); //EnterpriseCode
		//GUID
		serInfo.MemberInfo.Add( typeof(byte[]) );  //FileHeaderGuid
		//更新従業員コード
		serInfo.MemberInfo.Add( typeof(string) ); //UpdEmployeeCode
		//更新アセンブリID1
		serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId1
		//更新アセンブリID2
		serInfo.MemberInfo.Add( typeof(string) ); //UpdAssemblyId2
		//論理削除区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //LogicalDeleteCode
		//問合せ元企業コード
		serInfo.MemberInfo.Add( typeof(string) ); //InqOriginalEpCd
		//問合せ元拠点コード
		serInfo.MemberInfo.Add( typeof(string) ); //InqOriginalSecCd
		//問合せ先企業コード
		serInfo.MemberInfo.Add( typeof(string) ); //InqOtherEpCd
		//問合せ先拠点コード
		serInfo.MemberInfo.Add( typeof(string) ); //InqOtherSecCd
		//問合せ番号
		serInfo.MemberInfo.Add( typeof(Int64) ); //InquiryNumber
		//セット部品メーカーコード
		serInfo.MemberInfo.Add( typeof(Int32) ); //SetPartsMkrCd
		//セット部品番号
		serInfo.MemberInfo.Add( typeof(string) ); //SetPartsNumber
		//セット部品親子番号
		serInfo.MemberInfo.Add( typeof(Int32) ); //SetPartsMainSubNo
		//商品種別
		serInfo.MemberInfo.Add( typeof(Int32) ); //GoodsDivCd
		//リサイクル部品種別
		serInfo.MemberInfo.Add( typeof(Int32) ); //RecyclePrtKindCode
		//リサイクル部品種別名称
		serInfo.MemberInfo.Add( typeof(string) ); //RecyclePrtKindName
		//納品区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //DeliveredGoodsDiv
		//取扱区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //HandleDivCode
		//商品形態
		serInfo.MemberInfo.Add( typeof(Int32) ); //GoodsShape
		//納品確認区分
		serInfo.MemberInfo.Add( typeof(Int32) ); //DelivrdGdsConfCd
		//納品完了予定日
		serInfo.MemberInfo.Add( typeof(Int32) ); //DeliGdsCmpltDueDate
		//回答納期
		serInfo.MemberInfo.Add( typeof(string) ); //AnswerDeliveryDate
		//BL商品コード
		serInfo.MemberInfo.Add( typeof(Int32) ); //BLGoodsCode
		//BL商品コード枝番
		serInfo.MemberInfo.Add( typeof(Int32) ); //BLGoodsDrCode
		//問発商品名
		serInfo.MemberInfo.Add( typeof(string) ); //InqGoodsName
		//回答商品名
		serInfo.MemberInfo.Add( typeof(string) ); //AnsGoodsName
		//発注数
		serInfo.MemberInfo.Add( typeof(Double) ); //SalesOrderCount
		//納品数
		serInfo.MemberInfo.Add( typeof(Double) ); //DeliveredGoodsCount
		//商品番号
		serInfo.MemberInfo.Add( typeof(string) ); //GoodsNo
		//商品メーカーコード
		serInfo.MemberInfo.Add( typeof(Int32) ); //GoodsMakerCd
		//商品メーカー名称
		serInfo.MemberInfo.Add( typeof(string) ); //GoodsMakerNm
		//純正商品メーカーコード
		serInfo.MemberInfo.Add( typeof(Int32) ); //PureGoodsMakerCd
		//問発純正商品番号
		serInfo.MemberInfo.Add( typeof(string) ); //InqPureGoodsNo
		//回答純正商品番号
		serInfo.MemberInfo.Add( typeof(string) ); //AnsPureGoodsNo
		//定価
		serInfo.MemberInfo.Add( typeof(Int64) ); //ListPrice
		//単価
		serInfo.MemberInfo.Add( typeof(Int64) ); //UnitPrice
		//商品補足情報
		serInfo.MemberInfo.Add( typeof(string) ); //GoodsAddInfo
		//粗利額
		serInfo.MemberInfo.Add( typeof(Int64) ); //RoughRrofit
		//粗利率
		serInfo.MemberInfo.Add( typeof(Double) ); //RoughRate
		//回答期限
		serInfo.MemberInfo.Add( typeof(Int32) ); //AnswerLimitDate
		//備考(明細)
		serInfo.MemberInfo.Add( typeof(string) ); //CommentDtl
		//棚番
		serInfo.MemberInfo.Add( typeof(string) ); //ShelfNo
		//PM受注ステータス
		serInfo.MemberInfo.Add( typeof(Int32) ); //PMAcptAnOdrStatus
		//PM売上伝票番号
		serInfo.MemberInfo.Add( typeof(Int32) ); //PMSalesSlipNum
		//PM売上行番号
		serInfo.MemberInfo.Add( typeof(Int32) ); //PMSalesRowNo
		//PM倉庫コード
		serInfo.MemberInfo.Add( typeof(string) ); //PmWarehouseCd
		//PM倉庫名称
		serInfo.MemberInfo.Add( typeof(string) ); //PmWarehouseName
		//PM棚番
		serInfo.MemberInfo.Add( typeof(string) ); //PmShelfNo
		//PM現在個数
		serInfo.MemberInfo.Add( typeof(Double) ); //PmPrsntCount
        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        //PM主管倉庫コード
        serInfo.MemberInfo.Add(typeof(string)); //PmMainMngWarehouseCd 
        //PM主管倉庫名称
        serInfo.MemberInfo.Add(typeof(string)); //PmMainMngWarehouseName
        //PM主管棚番
        serInfo.MemberInfo.Add(typeof(string)); //PmMainMngShelfNo
        //PM主管現在個数
        serInfo.MemberInfo.Add(typeof(Double)); //PmMainMngPrsntCount
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
        //商品規格・特記事項
        serInfo.MemberInfo.Add(typeof(string)); //GoodsSpclInstruction
        // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<

        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
        // メーカー希望小売価格
        serInfo.MemberInfo.Add(typeof(Int64)); //MkrSuggestRtPric
	    // オープン価格区分
        serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<

        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // 回答納期区分
        serInfo.MemberInfo.Add(typeof(Int16)); // AnsDeliDateDiv
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
        // 優良設定詳細コード２
        serInfo.MemberInfo.Add(typeof(Int32)); // PrmSetDtlNo2
        // 優良設定詳細名称２
        serInfo.MemberInfo.Add(typeof(string)); // PrmSetDtlName2
        // 在庫状況区分
        serInfo.MemberInfo.Add(typeof(Int32)); // StockStatusDiv
        // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<

        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // 商品規格・特記事項(工場向け)
        serInfo.MemberInfo.Add(typeof(string)); // GoodsSpecialNtForFac
        // 商品規格・特記事項(カーオーナー向け)
        serInfo.MemberInfo.Add(typeof(string)); // GoodsSpecialNtForCOw
        // 優良設定詳細名称２(工場向け)
        serInfo.MemberInfo.Add(typeof(string)); // PrmSetDtlName2ForFac
        // 優良設定詳細名称２(カーオーナー向け)
        serInfo.MemberInfo.Add(typeof(string)); // PrmSetDtlName2ForCOw
        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //問発BL統一部品コード(スリーコード版)
        serInfo.MemberInfo.Add(typeof(string)); //InqBlUtyPtThCd
        //問発BL統一部品サブコード
        serInfo.MemberInfo.Add(typeof(Int32)); //InqBlUtyPtSbCd
        //回答BL統一部品コード(スリーコード版)
        serInfo.MemberInfo.Add(typeof(string)); //AnsBlUtyPtThCd
        //回答BL統一部品サブコード
        serInfo.MemberInfo.Add(typeof(Int32)); //AnsBlUtyPtSbCd
        //回答BL商品コード
        serInfo.MemberInfo.Add(typeof(Int32)); //AnsBLGoodsCode
        //回答BL商品コード枝番
        serInfo.MemberInfo.Add(typeof(Int32)); //AnsBLGoodsDrCode
        // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        serInfo.Serialize(writer, serInfo);
		if( graph is SCMAcOdSetDtWork )
		{
			SCMAcOdSetDtWork temp = (SCMAcOdSetDtWork)graph;

			SetScmAcOdSetDtWork(writer, temp);
		}
		else
		{
			ArrayList lst= null;
			if(graph is SCMAcOdSetDtWork[])
			{
				lst = new ArrayList();
				lst.AddRange((SCMAcOdSetDtWork[])graph);
			}
			else
			{
				lst = (ArrayList)graph;	
			}

			foreach(SCMAcOdSetDtWork temp in lst)
			{
				SetScmAcOdSetDtWork(writer, temp);
			}

		}

		
	}


	/// <summary>
	/// SCMAcOdSetDtWorkメンバ数(publicプロパティ数)
	/// </summary>
    // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
    #region 旧ソース
    ////private const int currentMemberCount = 52;// DEL 2013/02/27 qijh #34752
    //// UPD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
    ////private const int currentMemberCount = 56; // ADD 2013/02/27 qijh #34752	
    //// UPD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
    ////private const int currentMemberCount = 57;
    //private const int currentMemberCount = 59;
    //// UPD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
    //// UPD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
    #endregion
    //private const int currentMemberCount = 60;    // DEL 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応
    //private const int currentMemberCount = 64;      // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応
    //private const int currentMemberCount = 67;      // ADD 2015/02/27 SCM高速化 Ｃ向け種別特記対応// DEL 2018/04/16 田建委 新BLコード対応
    private const int currentMemberCount = 73;// ADD 2018/04/16 田建委 新BLコード対応
    // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
	
	/// <summary>
	///  SCMAcOdSetDtWorkインスタンス書き込み
	/// </summary>
	/// <remarks>
	/// <br>Note　　　　　　 :   SCMAcOdSetDtWorkのインスタンスを書き込み</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      :   2018/04/16  田建委</br>
    /// <br>                 :   管理番号 11470007-00</br>
    /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
	/// </remarks>
	private void SetScmAcOdSetDtWork( System.IO.BinaryWriter writer, SCMAcOdSetDtWork temp )
	{
		//作成日時
		writer.Write( (Int64)temp.CreateDateTime.Ticks );
		//更新日時
		writer.Write( (Int64)temp.UpdateDateTime.Ticks );
		//企業コード
		writer.Write( temp.EnterpriseCode );
		//GUID
		byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
		writer.Write( fileHeaderGuidArray.Length );
		writer.Write( temp.FileHeaderGuid.ToByteArray() );
		//更新従業員コード
		writer.Write( temp.UpdEmployeeCode );
		//更新アセンブリID1
		writer.Write( temp.UpdAssemblyId1 );
		//更新アセンブリID2
		writer.Write( temp.UpdAssemblyId2 );
		//論理削除区分
		writer.Write( temp.LogicalDeleteCode );
		//問合せ元企業コード
        writer.Write(temp.InqOriginalEpCd.Trim());	//@@@@20230303
		//問合せ元拠点コード
		writer.Write( temp.InqOriginalSecCd );
		//問合せ先企業コード
		writer.Write( temp.InqOtherEpCd );
		//問合せ先拠点コード
		writer.Write( temp.InqOtherSecCd );
		//問合せ番号
		writer.Write( temp.InquiryNumber );
		//セット部品メーカーコード
		writer.Write( temp.SetPartsMkrCd );
		//セット部品番号
		writer.Write( temp.SetPartsNumber );
		//セット部品親子番号
		writer.Write( temp.SetPartsMainSubNo );
		//商品種別
		writer.Write( temp.GoodsDivCd );
		//リサイクル部品種別
		writer.Write( temp.RecyclePrtKindCode );
		//リサイクル部品種別名称
		writer.Write( temp.RecyclePrtKindName );
		//納品区分
		writer.Write( temp.DeliveredGoodsDiv );
		//取扱区分
		writer.Write( temp.HandleDivCode );
		//商品形態
		writer.Write( temp.GoodsShape );
		//納品確認区分
		writer.Write( temp.DelivrdGdsConfCd );
		//納品完了予定日
        writer.Write((Int64)temp.CreateDateTime.Ticks);
		//回答納期
		writer.Write( temp.AnswerDeliveryDate );
		//BL商品コード
		writer.Write( temp.BLGoodsCode );
		//BL商品コード枝番
		writer.Write( temp.BLGoodsDrCode );
		//問発商品名
		writer.Write( temp.InqGoodsName );
		//回答商品名
		writer.Write( temp.AnsGoodsName );
		//発注数
		writer.Write( temp.SalesOrderCount );
		//納品数
		writer.Write( temp.DeliveredGoodsCount );
		//商品番号
		writer.Write( temp.GoodsNo );
		//商品メーカーコード
		writer.Write( temp.GoodsMakerCd );
		//商品メーカー名称
		writer.Write( temp.GoodsMakerNm );
		//純正商品メーカーコード
		writer.Write( temp.PureGoodsMakerCd );
		//問発純正商品番号
		writer.Write( temp.InqPureGoodsNo );
		//回答純正商品番号
		writer.Write( temp.AnsPureGoodsNo );
		//定価
		writer.Write( temp.ListPrice );
		//単価
		writer.Write( temp.UnitPrice );
		//商品補足情報
		writer.Write( temp.GoodsAddInfo );
		//粗利額
		writer.Write( temp.RoughRrofit );
		//粗利率
		writer.Write( temp.RoughRate );
		//回答期限
        writer.Write((Int64)temp.CreateDateTime.Ticks);
		//備考(明細)
		writer.Write( temp.CommentDtl );
		//棚番
		writer.Write( temp.ShelfNo );
		//PM受注ステータス
		writer.Write( temp.PMAcptAnOdrStatus );
		//PM売上伝票番号
		writer.Write( temp.PMSalesSlipNum );
		//PM売上行番号
		writer.Write( temp.PMSalesRowNo );
		//PM倉庫コード
		writer.Write( temp.PmWarehouseCd );
		//PM倉庫名称
		writer.Write( temp.PmWarehouseName );
		//PM棚番
		writer.Write( temp.PmShelfNo );
		//PM現在個数
		writer.Write( temp.PmPrsntCount );
        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        //PM主管倉庫コード
        writer.Write(temp.PmMainMngWarehouseCd);
        //PM主管倉庫名称
        writer.Write(temp.PmMainMngWarehouseName);
        //PM主管棚番
        writer.Write(temp.PmMainMngShelfNo);
        //PM主管現在個数
        writer.Write(temp.PmMainMngPrsntCount);
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
        // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
        //商品規格・特記事項
        writer.Write(temp.GoodsSpclInstruction);
        // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
        //メーカー希望小売価格
        writer.Write(temp.MkrSuggestRtPric);
        //オープン価格区分
        writer.Write(temp.OpenPriceDiv);
        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // 回答納期区分
        writer.Write(temp.AnsDeliDateDiv);
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
        // 優良設定詳細コード２
        writer.Write(temp.PrmSetDtlNo2);
        // 優良設定詳細名称２
        writer.Write(temp.PrmSetDtlName2);
        // 在庫状況区分
        writer.Write(temp.StockStatusDiv);
        // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<
        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // 商品規格・特記事項(工場向け)
        writer.Write(temp.GoodsSpecialNtForFac);
        // 商品規格・特記事項(カーオーナー向け)
        writer.Write(temp.GoodsSpecialNtForCOw);
        // 優良設定詳細名称２(工場向け)
        writer.Write(temp.PrmSetDtlName2ForFac);
        // 優良設定詳細名称２(カーオーナー向け)
        writer.Write(temp.PrmSetDtlName2ForCOw);
        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //問発BL統一部品コード(スリーコード版)
        writer.Write(temp.InqBlUtyPtThCd);
        //問発BL統一部品サブコード
        writer.Write(temp.InqBlUtyPtSbCd);
        //回答BL統一部品コード(スリーコード版)
        writer.Write(temp.AnsBlUtyPtThCd);
        //回答BL統一部品サブコード
        writer.Write(temp.AnsBlUtyPtSbCd);
        //回答BL商品コード
        writer.Write(temp.AnsBLGoodsCode);
        //回答BL商品コード枝番
        writer.Write(temp.AnsBLGoodsDrCode);
        // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    }

	/// <summary>
	///  SCMAcOdSetDtWorkインスタンス取得
	/// </summary>
	/// <returns>SCMAcOdSetDtWorkクラスのインスタンス</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   SCMAcOdSetDtWorkのインスタンスを取得します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      :   2018/04/16  田建委</br>
    /// <br>                 :   管理番号 11470007-00</br>
    /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
	/// </remarks>
	private SCMAcOdSetDtWork GetScmAcOdSetDtWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	{
		// V5.1.0.0なので不要ですが、V5.1.0.1以降では
		// serInfo.MemberInfo.Count < currentMemberCount
		// のケースについての配慮が必要になります。

		SCMAcOdSetDtWork temp = new SCMAcOdSetDtWork();

		//作成日時
		temp.CreateDateTime = new DateTime(reader.ReadInt64());
		//更新日時
		temp.UpdateDateTime = new DateTime(reader.ReadInt64());
		//企業コード
		temp.EnterpriseCode = reader.ReadString();
		//GUID
		int lenOfFileHeaderGuidArray = reader.ReadInt32();
		byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
		temp.FileHeaderGuid = new Guid( fileHeaderGuidArray );
		//更新従業員コード
		temp.UpdEmployeeCode = reader.ReadString();
		//更新アセンブリID1
		temp.UpdAssemblyId1 = reader.ReadString();
		//更新アセンブリID2
		temp.UpdAssemblyId2 = reader.ReadString();
		//論理削除区分
		temp.LogicalDeleteCode = reader.ReadInt32();
		//問合せ元企業コード
        temp.InqOriginalEpCd = reader.ReadString().Trim();//@@@@20230303
		//問合せ元拠点コード
		temp.InqOriginalSecCd = reader.ReadString();
		//問合せ先企業コード
		temp.InqOtherEpCd = reader.ReadString();
		//問合せ先拠点コード
		temp.InqOtherSecCd = reader.ReadString();
		//問合せ番号
		temp.InquiryNumber = reader.ReadInt64();
		//セット部品メーカーコード
		temp.SetPartsMkrCd = reader.ReadInt32();
		//セット部品番号
		temp.SetPartsNumber = reader.ReadString();
		//セット部品親子番号
		temp.SetPartsMainSubNo = reader.ReadInt32();
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
		//回答納期
		temp.AnswerDeliveryDate = reader.ReadString();
		//BL商品コード
		temp.BLGoodsCode = reader.ReadInt32();
		//BL商品コード枝番
		temp.BLGoodsDrCode = reader.ReadInt32();
		//問発商品名
		temp.InqGoodsName = reader.ReadString();
		//回答商品名
		temp.AnsGoodsName = reader.ReadString();
		//発注数
		temp.SalesOrderCount = reader.ReadDouble();
		//納品数
		temp.DeliveredGoodsCount = reader.ReadDouble();
		//商品番号
		temp.GoodsNo = reader.ReadString();
		//商品メーカーコード
		temp.GoodsMakerCd = reader.ReadInt32();
		//商品メーカー名称
		temp.GoodsMakerNm = reader.ReadString();
		//純正商品メーカーコード
		temp.PureGoodsMakerCd = reader.ReadInt32();
		//問発純正商品番号
		temp.InqPureGoodsNo = reader.ReadString();
		//回答純正商品番号
		temp.AnsPureGoodsNo = reader.ReadString();
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
        temp.AnswerLimitDate = new DateTime(reader.ReadInt64());
		//備考(明細)
		temp.CommentDtl = reader.ReadString();
		//棚番
		temp.ShelfNo = reader.ReadString();
		//PM受注ステータス
		temp.PMAcptAnOdrStatus = reader.ReadInt32();
		//PM売上伝票番号
		temp.PMSalesSlipNum = reader.ReadInt32();
		//PM売上行番号
		temp.PMSalesRowNo = reader.ReadInt32();
		//PM倉庫コード
		temp.PmWarehouseCd = reader.ReadString();
		//PM倉庫名称
		temp.PmWarehouseName = reader.ReadString();
		//PM棚番
		temp.PmShelfNo = reader.ReadString();
		//PM現在個数
		temp.PmPrsntCount = reader.ReadDouble();
        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        //PM主管倉庫コード
        temp.PmMainMngWarehouseCd = reader.ReadString();
        //PM主管倉庫名称
        temp.PmMainMngWarehouseName = reader.ReadString();
        //PM主管棚番
        temp.PmMainMngShelfNo = reader.ReadString();
        //PM主管現在個数
        temp.PmMainMngPrsntCount = reader.ReadDouble();
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<
        // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
        //商品規格・特記事項
        temp.GoodsSpclInstruction = reader.ReadString();
        // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<
        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
        //メーカー希望小売価格
        temp.MkrSuggestRtPric = reader.ReadInt64();
        //オープン価格区分
        temp.OpenPriceDiv = reader.ReadInt32();
        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<

        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // 回答納期区分
        temp.AnsDeliDateDiv = reader.ReadInt16();
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
        // 優良設定詳細コード２
        temp.PrmSetDtlNo2 = reader.ReadInt32();
        // 優良設定詳細名称２
        temp.PrmSetDtlName2 = reader.ReadString();
        // 在庫状況区分
        temp.StockStatusDiv = reader.ReadInt16();
        // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<

        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        // 商品規格・特記事項(工場向け)
        temp.GoodsSpecialNtForFac = reader.ReadString();
        // 商品規格・特記事項(カーオーナー向け)
        temp.GoodsSpecialNtForCOw = reader.ReadString();
        // 優良設定詳細名称２(工場向け)
        temp.PrmSetDtlName2ForFac = reader.ReadString();
        // 優良設定詳細名称２(カーオーナー向け)
        temp.PrmSetDtlName2ForCOw = reader.ReadString();
        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //問発BL統一部品コード(スリーコード版)
        temp.InqBlUtyPtThCd = reader.ReadString();
        //問発BL統一部品サブコード
        temp.InqBlUtyPtSbCd = reader.ReadInt32();
        //回答BL統一部品コード(スリーコード版)
        temp.AnsBlUtyPtThCd = reader.ReadString();
        //回答BL統一部品サブコード
        temp.AnsBlUtyPtSbCd = reader.ReadInt32();
        //回答BL商品コード
        temp.AnsBLGoodsCode = reader.ReadInt32();
        //回答BL商品コード枝番
        temp.AnsBLGoodsDrCode = reader.ReadInt32();
        // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        //以下は読み飛ばしです。このバージョンが想定する EmployeeWork型以降のバージョンの
		//データをデシリアライズする場合、シリアライズしたフォーマッタが記述した
		//型情報にしたがって、ストリームから情報を読み出します...といっても
		//読み出して捨てることになります。
		for( int k = currentMemberCount ; k < serInfo.MemberInfo.Count ; ++k )
		{
			//byte[],char[]をデシリアライズする直前に、そのlengthが
			//デシリアライズされているケースがある、byte[],char[]の
			//デシリアライズにはlengthが必要なのでint型のデータをデ
			//シリアライズした場合は、この値をこの変数に退避します。
			int optCount = 0;   
			object oMemberType = serInfo.MemberInfo[k];
			if( oMemberType is Type )
			{
				Type t = (Type)oMemberType;
				object oData = TypeDeserializer.DeserializePrimitiveType( reader, t, optCount );
				if( t.Equals( typeof(int) ) )
				{
					optCount = Convert.ToInt32(oData);
				}
				else
				{
					optCount = 0;
				}
			}
			else if( oMemberType is string )
			{
				Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate formatter = CustomFormatterServices.GetSurrogate( (string)oMemberType );
				object userData = formatter.Deserialize( reader );  //読み飛ばし
			}
		}
		return temp;
	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムデシリアライザです
	/// </summary>
	/// <returns>SCMAcOdSetDtWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   SCMAcOdSetDtWorkクラスのカスタムデシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public object Deserialize(System.IO.BinaryReader reader)
	{
		object retValue = null;
		Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		ArrayList lst = new ArrayList();
		for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		{
			SCMAcOdSetDtWork temp = GetScmAcOdSetDtWork( reader, serInfo );
			lst.Add( temp );
		}
		switch(serInfo.RetTypeInfo)
		{
			case 0:
				retValue = lst;
				break;
			case 1:
				retValue = lst[0];
				break;
			case 2:
				retValue = (SCMAcOdSetDtWork[])lst.ToArray(typeof(SCMAcOdSetDtWork));
				break;
		}
		return retValue;
	}

	#endregion
}

}
