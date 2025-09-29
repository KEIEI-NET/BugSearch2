using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData.StubDB
{
	/// public class name:   SCMAcOdrDtlAs
	/// <summary>
	///                      SCM受注明細データ（回答）
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受注明細データ（回答）ヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/04/13</br>
	/// <br>Genarated Date   :   2009/06/15  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2009/05/13  杉村</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   回答行番号</br>
	/// <br>                 :   回答行番号枝番</br>
	/// <br>                 :   ○キー変更</br>
	/// <br>                 :   時刻をキーに追加 3,9,10,11,12,13,14,15</br>
	/// <br>Update Note      :   2009/05/26  杉村</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   明細取込区分</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   リサイクル部品種別</br>
	/// <br>                 :   リサイクル部品種別名称</br>
	/// <br>                 :   回答納期</br>
	/// <br>                 :   表示順位</br>
	/// <br>Update Note      :   2009/05/27  杉村</br>
	/// <br>                 :   ○項目追加(キーに追加）</br>
	/// <br>                 :   問合せ先企業コード</br>
	/// <br>                 :   問合せ先拠点コード</br>
	/// <br>                 :   ○キー変更</br>
	/// <br>                 :   3,9,10,11,12,13,14,15,16,17</br>
	/// <br>Update Note      :   2009/05/28  杉村</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   商品管理番号</br>
	/// <br>                 :   ○桁数変更</br>
	/// <br>                 :   商品補足情報　24→255</br>
    /// <br>Update Note      :   2014/06/04  30744 湯上</br>
    /// <br>                 :   SCM仕掛一覧№10659対応</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   優良設定詳細コード２</br>
    /// <br>                 :   優良設定詳細名称２</br>
    /// <br>                 :   在庫状況区分</br>
    /// <br>Update Note      :   2014/12/19  30744 湯上</br>
    /// <br>管理番号         :   11070266-00</br>
    /// <br>                 :   SCM高速化 PMNS対応</br>
    /// <br>                 :   項目追加　貸出区分、メーカー希望小売価格、オープン価格区分</br>
    /// <br>Update Note      :   2015/01/19  31065 豊沢 憲弘</br>
    /// <br>管理番号         :   11070266-00</br>
    /// <br>                 :   リコメンド対応</br>
    /// <br>Update Note      :   2015/01/30  30744 湯上</br>
    /// <br>管理番号         :   11070266-00</br>
    /// <br>                 :   SCM高速化 生産年式、車台番号対応</br>
    /// <br>                 :   項目追加　型式別部品採用年月、型式別部品廃止年月、型式別部品採用車台番号、型式別部品廃止車台番号</br>
    /// <br>Update Note      :   2015/02/10  30745 吉岡</br>
    /// <br>管理番号         :   11070266-00</br>
    /// <br>                 :   SCM高速化 回答納期区分対応 項目追加</br>
    /// <br>Update Note      :   2015/02/20  30746 高川 悟</br>
    /// <br>管理番号         :   11070266-00</br>
    /// <br>                 :   SCM高速化 C向け種別・特記事項対応</br>
    /// <br>Update Note      :   ○項目追加</br>
    /// <br>                 :   問発BL統一部品コード(スリーコード版)</br>
    /// <br>                 :   問発BL統一部品サブコード</br>
    /// <br>                 :   回答BL統一部品コード(スリーコード版)</br>
    /// <br>                 :   回答BL統一部品サブコード</br>
    /// <br>                 :   回答BL商品コード</br>
    /// <br>                 :   回答BL商品コード枝番</br>
    /// <br>管理番号         :   11470007-00</br>
    /// <br>                 :   2018/04/16 田建委</br>
    /// </remarks>
	public class SCMAcOdrDtlAs
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
		/// <remarks>0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場</remarks>
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
		/// <remarks>0:オープン価格</remarks>
		private Int64 _listPrice;

		/// <summary>単価</summary>
		private Int64 _unitPrice;

		/// <summary>商品補足情報</summary>
		/// <remarks>PSのＵＲＬ</remarks>
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

		/// <summary>添付ファイル(明細)</summary>
		private Byte[] _appendingFileDtl;

		/// <summary>添付ファイル名(明細)</summary>
		private string _appendingFileNmDtl = "";

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

		/// <summary>キャンペーンコード</summary>
		/// <remarks>任意の無重複コードとする（自動付番はしない）</remarks>
		private Int32 _campaignCode;

		/// <summary>在庫区分</summary>
		/// <remarks>委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫</remarks>
		private Int32 _stockDiv;

		/// <summary>問合せ・発注種別</summary>
		/// <remarks>1:問合せ 2:発注</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>表示順位</summary>
		private Int32 _displayOrder;

		/// <summary>商品管理番号</summary>
		/// <remarks>PS管理番号</remarks>
		private Int32 _goodsMngNo;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>BL商品コード名称</summary>
		private string _bLGoodsName = "";

        // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
        /// <summary>優良設定詳細コード２</summary>
        /// <remarks>優良設定マスタより取得　種別コード</remarks>
        private Int32 _prmSetDtlNo2 = 0;

        /// <summary>優良設定詳細名称２</summary>
        /// <remarks>優良設定マスタより取得</remarks>
        private string _prmSetDtlName2 = "";

        /// <summary>在庫状況区分</summary>
        private Int16 _stockStatusDiv = 0;
        // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<

        // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// <summary>貸出区分</summary>
        /// <remarks></remarks>
        private Int16 _rentDiv = 0;
        /// <summary>メーカー希望小売価格</summary>
        /// <remarks></remarks>
        private Int64 _mkrSuggestRtPric = 0;
        /// <summary>オープン価格区分</summary>
        /// <remarks></remarks>
        private Int32 _openPriceDiv = 0;
        // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

        // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
        /// <summary>お買得商品選択区分</summary>
        /// <remarks></remarks>
        private Int16 _bgnGoodsDiv = 0; 
        // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<

        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
        /// <summary>型式別部品採用年月</summary>
        /// <remarks></remarks>
        private Int32 _modelPrtsAdptYm = 0;

        /// <summary>型式別部品廃止年月</summary>
        /// <remarks></remarks>
        private Int32 _modelPrtsAblsYm = 0;

        /// <summary>型式別部品採用車台番号</summary>
        /// <remarks></remarks>
        private Int32 _modelPrtsAdptFrameNo = 0;

        /// <summary>型式別部品廃止車台番号</summary>
        /// <remarks></remarks>
        private Int32 _modelPrtsAblsFrameNo = 0;
        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> 回答納期区分を取得または設定します。</summary>
        private Int16 _ansDeliDateDiv = 0;
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
        /// <summary>商品規格・特記事項(工場向け)</summary>
        /// <remarks>整備工場・鈑金工場などが理解可能な説明文が入る (半角全角混在)</remarks>
        private string _goodsSpecialNtForFac = "";

        /// <summary>商品規格・特記事項(カーオーナー向け)</summary>
        /// <remarks>カーオーナーが理解可能な説明文が入る (半角全角混在)</remarks>
        private string _goodsSpecialNtForCOw = "";

        /// <summary>優良設定詳細名称２(工場向け)</summary>
        /// <remarks>整備工場・鈑金工場などが理解可能な説明文が入る (半角全角混在)</remarks>
        private string _prmSetDtlName2ForFac = "";

        /// <summary>優良設定詳細名称２(カーオーナー向け)</summary>
        /// <remarks>カーオーナーが理解可能な説明文が入る (半角全角混在)</remarks>
        private string _prmSetDtlName2ForCOw = "";
        // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<

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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _updateDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _updateDate);}
			set{}
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
			get{return _updateTime;}
			set{_updateTime = value;}
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

		/// public propaty name  :  InqOrgDtlDiscGuid
		/// <summary>問合せ元明細識別GUIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   問合せ元明細識別GUIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid InqOrgDtlDiscGuid
		{
			get{return _inqOrgDtlDiscGuid;}
			set{_inqOrgDtlDiscGuid = value;}
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
			get{return _inqOthDtlDiscGuid;}
			set{_inqOthDtlDiscGuid = value;}
		}

		/// public propaty name  :  GoodsDivCd
		/// <summary>商品種別プロパティ</summary>
		/// <value>0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場</value>
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
			get{return TDateTime.DateTimeToString("GGYYMMDD", _deliGdsCmpltDueDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("ggYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YYYY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
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
			get{return TDateTime.DateTimeToString("YY/MM/DD", _deliGdsCmpltDueDate);}
			set{}
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
		/// <value>PSのＵＲＬ</value>
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

		/// public propaty name  :  AppendingFileDtl
		/// <summary>添付ファイル(明細)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   添付ファイル(明細)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Byte[] AppendingFileDtl
		{
			get{return _appendingFileDtl;}
			set{_appendingFileDtl = value;}
		}

		/// public propaty name  :  AppendingFileNmDtl
		/// <summary>添付ファイル名(明細)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   添付ファイル名(明細)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string AppendingFileNmDtl
		{
			get{return _appendingFileNmDtl;}
			set{_appendingFileNmDtl = value;}
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

		/// public propaty name  :  CampaignCode
		/// <summary>キャンペーンコードプロパティ</summary>
		/// <value>任意の無重複コードとする（自動付番はしない）</value>
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

		/// public propaty name  :  GoodsMngNo
		/// <summary>商品管理番号プロパティ</summary>
		/// <value>PS管理番号</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   商品管理番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GoodsMngNo
		{
			get{return _goodsMngNo;}
			set{_goodsMngNo = value;}
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

        // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
        /// public propaty name  :  PrmSetDtlNo2
        /// <summary>優良設定詳細コード２プロパティ</summary>
        /// <value>優良設定マスタより取得　種別コード</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細コード２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSetDtlNo2
        {
            get { return _prmSetDtlNo2; }
            set { _prmSetDtlNo2 = value; }
        }

        /// public propaty name  :  PrmSetDtlName2
        /// <summary>優良設定詳細名称２プロパティ</summary>
        /// <value>優良設定マスタより取得</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良設定詳細名称２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>note             :   在庫状況区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 StockStatusDiv
        {
            get { return _stockStatusDiv; }
            set { _stockStatusDiv = value; }
        }
        // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<

        // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// public propaty name  :  RentDiv
        /// <summary>貸出区分プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   貸出区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 RentDiv
        {
            get { return _rentDiv; }
            set { _rentDiv = value; }
        }
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
        // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

        // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
        /// public propaty name  :  BgnGoodsDiv
        /// <summary>お買得商品選択区分プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   お買得商品選択区分プロパティプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int16 BgnGoodsDiv
        {
            get { return _bgnGoodsDiv; }
            set { _bgnGoodsDiv = value; }
        }
        // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<

        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
        /// public propaty name  :  ModelPrtsAdptYm
        /// <summary>型式別部品採用年月プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品採用年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelPrtsAdptYm
        {
            get { return _modelPrtsAdptYm; }
            set { _modelPrtsAdptYm = value; }
        }

        /// public propaty name  :  ModelPrtsAblsYm
        /// <summary>型式別部品採用年月プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品採用年月プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelPrtsAblsYm
        {
            get { return _modelPrtsAblsYm; }
            set { _modelPrtsAblsYm = value; }
        }

        /// public propaty name  :  ModelPrtsAdptFrameNo
        /// <summary>型式別部品採用車台番号プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品採用車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelPrtsAdptFrameNo
        {
            get { return _modelPrtsAdptFrameNo; }
            set { _modelPrtsAdptFrameNo = value; }
        }

        /// public propaty name  :  ModelPrtsAblsFrameNo
        /// <summary>型式別部品廃止車台番号プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品廃止車台番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ModelPrtsAblsFrameNo
        {
            get { return _modelPrtsAblsFrameNo; }
            set { _modelPrtsAblsFrameNo = value; }
        }
        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

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

        // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
        /// public propaty name  :  GoodsSpecialNtForFac
        /// <summary>商品規格・特記事項(工場向け)プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項(工場向け)プロパティ</br>
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
        /// <br>note             :   商品規格・特記事項(カーオーナー向け)プロパティ</br>
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
        /// <br>note             :   優良設定詳細名称２(工場向け)プロパティ</br>
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
        /// <br>note             :   優良設定詳細名称２(カーオーナー向け)プロパティ</br>
        /// </remarks>
        public string PrmSetDtlName2ForCOw
        {
            get { return _prmSetDtlName2ForCOw; }
            set { _prmSetDtlName2ForCOw = value; }
        }
        // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
        
        // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  InqBlUtyPtThCd
        /// <summary>問発BL統一部品コード(スリーコード版)プロパティ</summary>
        /// <value>.C コード体系項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   問発BL統一部品コード(スリーコード版)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
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
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnsBLGoodsDrCode
        {
            get { return _ansBLGoodsDrCode; }
            set { _ansBLGoodsDrCode = value; }
        }
        // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        
        /// <summary>
		/// SCM受注明細データ（回答）コンストラクタ
		/// </summary>
		/// <returns>SCMAcOdrDtlAsクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtlAsクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdrDtlAs()
		{
		}

		/// <summary>
		/// SCM受注明細データ（回答）コンストラクタ
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
		/// <param name="updateDate">更新年月日(YYYYMMDD)</param>
		/// <param name="updateTime">更新時分秒ミリ秒(HHMMSSXXX)</param>
		/// <param name="inqRowNumber">問合せ行番号</param>
		/// <param name="inqRowNumDerivedNo">問合せ行番号枝番</param>
		/// <param name="inqOrgDtlDiscGuid">問合せ元明細識別GUID</param>
		/// <param name="inqOthDtlDiscGuid">問合せ先明細識別GUID(回答データの場合有効、問合せ／発注元の明細GUIDを設定)</param>
		/// <param name="goodsDivCd">商品種別(0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場)</param>
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
		/// <param name="listPrice">定価(0:オープン価格)</param>
		/// <param name="unitPrice">単価</param>
		/// <param name="goodsAddInfo">商品補足情報(PSのＵＲＬ)</param>
		/// <param name="roughRrofit">粗利額</param>
		/// <param name="roughRate">粗利率</param>
		/// <param name="answerLimitDate">回答期限(YYYYMMDD)</param>
		/// <param name="commentDtl">備考(明細)</param>
		/// <param name="appendingFileDtl">添付ファイル(明細)</param>
		/// <param name="appendingFileNmDtl">添付ファイル名(明細)</param>
		/// <param name="shelfNo">棚番</param>
		/// <param name="additionalDivCd">追加区分</param>
		/// <param name="correctDivCD">訂正区分</param>
		/// <param name="acptAnOdrStatus">受注ステータス(10:見積,20:受注,30:売上)</param>
		/// <param name="salesSlipNum">売上伝票番号(見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。)</param>
		/// <param name="salesRowNo">売上行番号</param>
		/// <param name="campaignCode">キャンペーンコード(任意の無重複コードとする（自動付番はしない）)</param>
		/// <param name="stockDiv">在庫区分(委託在庫、得意先在庫、優先倉庫、自社在庫、非在庫)</param>
		/// <param name="inqOrdDivCd">問合せ・発注種別(1:問合せ 2:発注)</param>
		/// <param name="displayOrder">表示順位</param>
		/// <param name="goodsMngNo">商品管理番号(PS管理番号)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="bLGoodsName">BL商品コード名称</param>
        /// <param name="prmSetDtlNo2">優良設定詳細コード２</param>
        /// <param name="prmSetDtlName2">優良設定詳細名称２</param>
        /// <param name="stockStatusDiv">在庫状況区分</param>
        /// <param name="rentDiv">貸出区分</param>
        /// <param name="mkrSuggestRtPric">メーカー希望小売価格</param>
        /// <param name="openPriceDiv">オープン価格区分</param>
        /// <param name="bgnGoodsDiv">お買得商品選択区分</param>
        /// <param name="modelPrtsAdptYm">型式別部品採用年月</param>
        /// <param name="modelPrtsAblsYm">型式別部品廃止年月</param>
        /// <param name="modelPrtsAdptFrameNo">型式別部品採用車台番号</param>
        /// <param name="modelPrtsAblsFrameNo">型式別部品廃止車台番号</param>
        /// <param name="ansDeliDateDiv">回答納期区分</param>
        /// <param name="goodsSpecialNtForCOw">商品規格・特記事項(工場向け)</param>
        /// <param name="goodsSpecialNtForFac">商品規格・特記事項(カーオーナー向け)</param>
        /// <param name="prmSetDtlName2ForCOw">優良設定詳細名称２(工場向け)</param>
        /// <param name="prmSetDtlName2ForFac">優良設定詳細名称２(カーオーナー向け)</param>
        /// <param name="inqBlUtyPtThCd">問発BL統一部品コード(スリーコード版)(.C コード体系項目)</param>
        /// <param name="inqBlUtyPtSbCd">問発BL統一部品サブコード(.C コード体系項目)</param>
        /// <param name="ansBlUtyPtThCd">回答BL統一部品コード(スリーコード版)(.C コード体系項目)</param>
        /// <param name="ansBlUtyPtSbCd">回答BL統一部品サブコード(.C コード体系項目)</param>
        /// <param name="ansBLGoodsCode">回答BL商品コード</param>
        /// <param name="ansBLGoodsDrCode">回答BL商品コード枝番</param>
        /// <returns>SCMAcOdrDtlAsクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtlAsクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
		/// </remarks>
        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region 旧ソース
        //// UPD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
        ////public SCMAcOdrDtlAs(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, Byte[] appendingFileDtl, string appendingFileNmDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 campaignCode, Int32 stockDiv, Int32 inqOrdDivCd, Int32 displayOrder, Int32 goodsMngNo, string enterpriseName, string updEmployeeName, string bLGoodsName)
        //// UPD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
        ////public SCMAcOdrDtlAs(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, Byte[] appendingFileDtl, string appendingFileNmDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 campaignCode, Int32 stockDiv, Int32 inqOrdDivCd, Int32 displayOrder, Int32 goodsMngNo, string enterpriseName, string updEmployeeName, string bLGoodsName, Int32 prmSetDtlNo2, string prmSetDtlName2, Int16 stockStatusDiv)
        //// UPD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
        ////public SCMAcOdrDtlAs(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, Byte[] appendingFileDtl, string appendingFileNmDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 campaignCode, Int32 stockDiv, Int32 inqOrdDivCd, Int32 displayOrder, Int32 goodsMngNo, string enterpriseName, string updEmployeeName, string bLGoodsName, Int32 prmSetDtlNo2, string prmSetDtlName2, Int16 stockStatusDiv, Int16 rentDiv, Int64 mkrSuggestRtPric, Int32 openPriceDiv)
        //// UPD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
        ////public SCMAcOdrDtlAs(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, Byte[] appendingFileDtl, string appendingFileNmDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 campaignCode, Int32 stockDiv, Int32 inqOrdDivCd, Int32 displayOrder, Int32 goodsMngNo, string enterpriseName, string updEmployeeName, string bLGoodsName, Int32 prmSetDtlNo2, string prmSetDtlName2, Int16 stockStatusDiv, Int16 rentDiv, Int64 mkrSuggestRtPric, Int32 openPriceDiv, Int16 bgnGoodsDiv)
        //public SCMAcOdrDtlAs(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, Byte[] appendingFileDtl, string appendingFileNmDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 campaignCode, Int32 stockDiv, Int32 inqOrdDivCd, Int32 displayOrder, Int32 goodsMngNo, string enterpriseName, string updEmployeeName, string bLGoodsName, Int32 prmSetDtlNo2, string prmSetDtlName2, Int16 stockStatusDiv, Int16 rentDiv, Int64 mkrSuggestRtPric, Int32 openPriceDiv, Int16 bgnGoodsDiv, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo, Int32 modelPrtsAblsFrameNo)
        //// UPD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
        //// UPD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<
        //// UPD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
        //// UPD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
        #endregion
        public SCMAcOdrDtlAs(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string inqOriginalEpCd, string inqOriginalSecCd, string inqOtherEpCd, string inqOtherSecCd, Int64 inquiryNumber, DateTime updateDate, Int32 updateTime, Int32 inqRowNumber, Int32 inqRowNumDerivedNo, Guid inqOrgDtlDiscGuid, Guid inqOthDtlDiscGuid, Int32 goodsDivCd, Int32 recyclePrtKindCode, string recyclePrtKindName, Int32 deliveredGoodsDiv, Int32 handleDivCode, Int32 goodsShape, Int32 delivrdGdsConfCd, DateTime deliGdsCmpltDueDate, string answerDeliveryDate, Int32 bLGoodsCode, Int32 bLGoodsDrCode, string inqGoodsName, string ansGoodsName, Double salesOrderCount, Double deliveredGoodsCount, string goodsNo, Int32 goodsMakerCd, string goodsMakerNm, Int32 pureGoodsMakerCd, string inqPureGoodsNo, string ansPureGoodsNo, Int64 listPrice, Int64 unitPrice, string goodsAddInfo, Int64 roughRrofit, Double roughRate, DateTime answerLimitDate, string commentDtl, Byte[] appendingFileDtl, string appendingFileNmDtl, string shelfNo, Int32 additionalDivCd, Int32 correctDivCD, Int32 acptAnOdrStatus, string salesSlipNum, Int32 salesRowNo, Int32 campaignCode, Int32 stockDiv, Int32 inqOrdDivCd, Int32 displayOrder, Int32 goodsMngNo, string enterpriseName, string updEmployeeName, string bLGoodsName, Int32 prmSetDtlNo2, string prmSetDtlName2, Int16 stockStatusDiv, Int16 rentDiv, Int64 mkrSuggestRtPric, Int32 openPriceDiv, Int16 bgnGoodsDiv, Int32 modelPrtsAdptYm, Int32 modelPrtsAblsYm, Int32 modelPrtsAdptFrameNo, Int32 modelPrtsAblsFrameNo
            , Int16 ansDeliDateDiv
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
            , string goodsSpecialNtForFac
            , string goodsSpecialNtForCOw
            , string prmSetDtlName2ForFac
            , string prmSetDtlName2ForCOw
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
            // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            , string inqBlUtyPtThCd
            , Int32 inqBlUtyPtSbCd
            , string ansBlUtyPtThCd
            , Int32 ansBlUtyPtSbCd
            , Int32 ansBLGoodsCode
            , Int32 ansBLGoodsDrCode
            // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            )
        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._inqOriginalEpCd = inqOriginalEpCd.Trim();//@@@@20230303
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
			this._answerLimitDate = answerLimitDate;
			this._commentDtl = commentDtl;
			this._appendingFileDtl = appendingFileDtl;
			this._appendingFileNmDtl = appendingFileNmDtl;
			this._shelfNo = shelfNo;
			this._additionalDivCd = additionalDivCd;
			this._correctDivCD = correctDivCD;
			this._acptAnOdrStatus = acptAnOdrStatus;
			this._salesSlipNum = salesSlipNum;
			this._salesRowNo = salesRowNo;
			this._campaignCode = campaignCode;
			this._stockDiv = stockDiv;
			this._inqOrdDivCd = inqOrdDivCd;
			this._displayOrder = displayOrder;
			this._goodsMngNo = goodsMngNo;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._bLGoodsName = bLGoodsName;
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            this._prmSetDtlNo2 = prmSetDtlNo2;
            this._prmSetDtlName2 = prmSetDtlName2;
            this._stockStatusDiv = stockStatusDiv;
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            this._rentDiv = rentDiv;
            this._mkrSuggestRtPric = mkrSuggestRtPric;
            this._openPriceDiv = openPriceDiv;
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
            this._bgnGoodsDiv = bgnGoodsDiv; // ADD 2015/01/19 豊沢 リコメンド対応
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
            this._modelPrtsAdptYm = modelPrtsAdptYm;
            this._modelPrtsAblsYm = modelPrtsAblsYm;
            this._modelPrtsAdptFrameNo = modelPrtsAdptFrameNo;
            this._modelPrtsAblsFrameNo = modelPrtsAblsFrameNo;
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            this._ansDeliDateDiv = ansDeliDateDiv;
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
            this._goodsSpecialNtForFac = goodsSpecialNtForFac;
            this._goodsSpecialNtForCOw = goodsSpecialNtForCOw;
            this._prmSetDtlName2ForFac = prmSetDtlName2ForFac;
            this._prmSetDtlName2ForCOw = prmSetDtlName2ForCOw;
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
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
		/// SCM受注明細データ（回答）複製処理
		/// </summary>
		/// <returns>SCMAcOdrDtlAsクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSCMAcOdrDtlAsクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
		/// </remarks>
		public SCMAcOdrDtlAs Clone()
		{
            // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            #region 旧ソース
            //// UPD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            ////return new SCMAcOdrDtlAs(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._appendingFileDtl, this._appendingFileNmDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._campaignCode, this._stockDiv, this._inqOrdDivCd, this._displayOrder, this._goodsMngNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName);
            //// ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            ////return new SCMAcOdrDtlAs(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._appendingFileDtl, this._appendingFileNmDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._campaignCode, this._stockDiv, this._inqOrdDivCd, this._displayOrder, this._goodsMngNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._prmSetDtlNo2, this._prmSetDtlName2, this._stockStatusDiv);
            //// UPD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
            ////return new SCMAcOdrDtlAs(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._appendingFileDtl, this._appendingFileNmDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._campaignCode, this._stockDiv, this._inqOrdDivCd, this._displayOrder, this._goodsMngNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._prmSetDtlNo2, this._prmSetDtlName2, this._stockStatusDiv, this._rentDiv, this._mkrSuggestRtPric, this._openPriceDiv);
            //// UPD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
            ////return new SCMAcOdrDtlAs(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._appendingFileDtl, this._appendingFileNmDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._campaignCode, this._stockDiv, this._inqOrdDivCd, this._displayOrder, this._goodsMngNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._prmSetDtlNo2, this._prmSetDtlName2, this._stockStatusDiv, this._rentDiv, this._mkrSuggestRtPric, this._openPriceDiv, this._bgnGoodsDiv);
            //return new SCMAcOdrDtlAs(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd, this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._appendingFileDtl, this._appendingFileNmDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._campaignCode, this._stockDiv, this._inqOrdDivCd, this._displayOrder, this._goodsMngNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._prmSetDtlNo2, this._prmSetDtlName2, this._stockStatusDiv, this._rentDiv, this._mkrSuggestRtPric, this._openPriceDiv, this._bgnGoodsDiv, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo);
            //// UPD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
            //// UPD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<
            //// ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
            //// UPD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
            #endregion
            return new SCMAcOdrDtlAs(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._inqOriginalEpCd.Trim(), this._inqOriginalSecCd, this._inqOtherEpCd, this._inqOtherSecCd, this._inquiryNumber, this._updateDate, this._updateTime, this._inqRowNumber, this._inqRowNumDerivedNo, this._inqOrgDtlDiscGuid, this._inqOthDtlDiscGuid, this._goodsDivCd, this._recyclePrtKindCode, this._recyclePrtKindName, this._deliveredGoodsDiv, this._handleDivCode, this._goodsShape, this._delivrdGdsConfCd, this._deliGdsCmpltDueDate, this._answerDeliveryDate, this._bLGoodsCode, this._bLGoodsDrCode, this._inqGoodsName, this._ansGoodsName, this._salesOrderCount, this._deliveredGoodsCount, this._goodsNo, this._goodsMakerCd, this._goodsMakerNm, this._pureGoodsMakerCd, this._inqPureGoodsNo, this._ansPureGoodsNo, this._listPrice, this._unitPrice, this._goodsAddInfo, this._roughRrofit, this._roughRate, this._answerLimitDate, this._commentDtl, this._appendingFileDtl, this._appendingFileNmDtl, this._shelfNo, this._additionalDivCd, this._correctDivCD, this._acptAnOdrStatus, this._salesSlipNum, this._salesRowNo, this._campaignCode, this._stockDiv, this._inqOrdDivCd, this._displayOrder, this._goodsMngNo, this._enterpriseName, this._updEmployeeName, this._bLGoodsName, this._prmSetDtlNo2, this._prmSetDtlName2, this._stockStatusDiv, this._rentDiv, this._mkrSuggestRtPric, this._openPriceDiv, this._bgnGoodsDiv, this._modelPrtsAdptYm, this._modelPrtsAblsYm, this._modelPrtsAdptFrameNo, this._modelPrtsAblsFrameNo//@@@@20230303
                ,this._ansDeliDateDiv
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
                , this._goodsSpecialNtForFac
                , this._goodsSpecialNtForCOw
                , this._prmSetDtlName2ForFac
                , this._prmSetDtlName2ForCOw
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
                // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                , this._inqBlUtyPtThCd
                , this._inqBlUtyPtSbCd
                , this._ansBlUtyPtThCd
                , this._ansBlUtyPtSbCd
                , this._ansBLGoodsCode
                , this._ansBLGoodsDrCode
                // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                );
            // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

		}

		/// <summary>
		/// SCM受注明細データ（回答）比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMAcOdrDtlAsクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtlAsクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
		/// </remarks>
		public bool Equals(SCMAcOdrDtlAs target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.InqOriginalEpCd.Trim() == target.InqOriginalEpCd.Trim()) //@@@@20230303
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
				 && (this.AppendingFileDtl == target.AppendingFileDtl)
				 && (this.AppendingFileNmDtl == target.AppendingFileNmDtl)
				 && (this.ShelfNo == target.ShelfNo)
				 && (this.AdditionalDivCd == target.AdditionalDivCd)
				 && (this.CorrectDivCD == target.CorrectDivCD)
				 && (this.AcptAnOdrStatus == target.AcptAnOdrStatus)
				 && (this.SalesSlipNum == target.SalesSlipNum)
				 && (this.SalesRowNo == target.SalesRowNo)
				 && (this.CampaignCode == target.CampaignCode)
				 && (this.StockDiv == target.StockDiv)
				 && (this.InqOrdDivCd == target.InqOrdDivCd)
				 && (this.DisplayOrder == target.DisplayOrder)
				 && (this.GoodsMngNo == target.GoodsMngNo)
				 && (this.EnterpriseName == target.EnterpriseName)
				 && (this.UpdEmployeeName == target.UpdEmployeeName)
				 && (this.BLGoodsName == target.BLGoodsName)
                 // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
                 && (this.PrmSetDtlNo2 == target.PrmSetDtlNo2)
                 && (this.PrmSetDtlName2 == target.PrmSetDtlName2)
                 && (this.StockStatusDiv == target.StockStatusDiv)
                 // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
                // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
                 && (this.RentDiv == target.RentDiv)
                 && (this.MkrSuggestRtPric == target.MkrSuggestRtPric)
                 && (this.OpenPriceDiv == target.OpenPriceDiv)
                // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
                 && (this.BgnGoodsDiv == target.BgnGoodsDiv) // ADD 2015/01/19 豊沢 リコメンド対応
                // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
                 && (this.ModelPrtsAdptYm == target.ModelPrtsAdptYm)
                 && (this.ModelPrtsAblsYm == target.ModelPrtsAblsYm)
                 && (this.ModelPrtsAdptFrameNo == target.ModelPrtsAdptFrameNo)
                 && (this.ModelPrtsAblsFrameNo == target.ModelPrtsAblsFrameNo)
                // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (this.AnsDeliDateDiv == target.AnsDeliDateDiv)
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
                 && (this.GoodsSpecialNtForFac == target.GoodsSpecialNtForFac)
                 && (this.GoodsSpecialNtForCOw == target.GoodsSpecialNtForCOw)
                 && (this.PrmSetDtlName2ForFac == target.PrmSetDtlName2ForFac)
                 && (this.PrmSetDtlName2ForCOw == target.PrmSetDtlName2ForCOw)
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
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
		/// SCM受注明細データ（回答）比較処理
		/// </summary>
		/// <param name="sCMAcOdrDtlAs1">
		///                    比較するSCMAcOdrDtlAsクラスのインスタンス
		/// </param>
		/// <param name="sCMAcOdrDtlAs2">比較するSCMAcOdrDtlAsクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtlAsクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
		/// </remarks>
		public static bool Equals(SCMAcOdrDtlAs sCMAcOdrDtlAs1, SCMAcOdrDtlAs sCMAcOdrDtlAs2)
		{
			return ((sCMAcOdrDtlAs1.CreateDateTime == sCMAcOdrDtlAs2.CreateDateTime)
				 && (sCMAcOdrDtlAs1.UpdateDateTime == sCMAcOdrDtlAs2.UpdateDateTime)
				 && (sCMAcOdrDtlAs1.EnterpriseCode == sCMAcOdrDtlAs2.EnterpriseCode)
				 && (sCMAcOdrDtlAs1.FileHeaderGuid == sCMAcOdrDtlAs2.FileHeaderGuid)
				 && (sCMAcOdrDtlAs1.UpdEmployeeCode == sCMAcOdrDtlAs2.UpdEmployeeCode)
				 && (sCMAcOdrDtlAs1.UpdAssemblyId1 == sCMAcOdrDtlAs2.UpdAssemblyId1)
				 && (sCMAcOdrDtlAs1.UpdAssemblyId2 == sCMAcOdrDtlAs2.UpdAssemblyId2)
				 && (sCMAcOdrDtlAs1.LogicalDeleteCode == sCMAcOdrDtlAs2.LogicalDeleteCode)
				 && (sCMAcOdrDtlAs1.InqOriginalEpCd.Trim() == sCMAcOdrDtlAs2.InqOriginalEpCd.Trim()) //@@@@20230303
				 && (sCMAcOdrDtlAs1.InqOriginalSecCd == sCMAcOdrDtlAs2.InqOriginalSecCd)
				 && (sCMAcOdrDtlAs1.InqOtherEpCd == sCMAcOdrDtlAs2.InqOtherEpCd)
				 && (sCMAcOdrDtlAs1.InqOtherSecCd == sCMAcOdrDtlAs2.InqOtherSecCd)
				 && (sCMAcOdrDtlAs1.InquiryNumber == sCMAcOdrDtlAs2.InquiryNumber)
				 && (sCMAcOdrDtlAs1.UpdateDate == sCMAcOdrDtlAs2.UpdateDate)
				 && (sCMAcOdrDtlAs1.UpdateTime == sCMAcOdrDtlAs2.UpdateTime)
				 && (sCMAcOdrDtlAs1.InqRowNumber == sCMAcOdrDtlAs2.InqRowNumber)
				 && (sCMAcOdrDtlAs1.InqRowNumDerivedNo == sCMAcOdrDtlAs2.InqRowNumDerivedNo)
				 && (sCMAcOdrDtlAs1.InqOrgDtlDiscGuid == sCMAcOdrDtlAs2.InqOrgDtlDiscGuid)
				 && (sCMAcOdrDtlAs1.InqOthDtlDiscGuid == sCMAcOdrDtlAs2.InqOthDtlDiscGuid)
				 && (sCMAcOdrDtlAs1.GoodsDivCd == sCMAcOdrDtlAs2.GoodsDivCd)
				 && (sCMAcOdrDtlAs1.RecyclePrtKindCode == sCMAcOdrDtlAs2.RecyclePrtKindCode)
				 && (sCMAcOdrDtlAs1.RecyclePrtKindName == sCMAcOdrDtlAs2.RecyclePrtKindName)
				 && (sCMAcOdrDtlAs1.DeliveredGoodsDiv == sCMAcOdrDtlAs2.DeliveredGoodsDiv)
				 && (sCMAcOdrDtlAs1.HandleDivCode == sCMAcOdrDtlAs2.HandleDivCode)
				 && (sCMAcOdrDtlAs1.GoodsShape == sCMAcOdrDtlAs2.GoodsShape)
				 && (sCMAcOdrDtlAs1.DelivrdGdsConfCd == sCMAcOdrDtlAs2.DelivrdGdsConfCd)
				 && (sCMAcOdrDtlAs1.DeliGdsCmpltDueDate == sCMAcOdrDtlAs2.DeliGdsCmpltDueDate)
				 && (sCMAcOdrDtlAs1.AnswerDeliveryDate == sCMAcOdrDtlAs2.AnswerDeliveryDate)
				 && (sCMAcOdrDtlAs1.BLGoodsCode == sCMAcOdrDtlAs2.BLGoodsCode)
				 && (sCMAcOdrDtlAs1.BLGoodsDrCode == sCMAcOdrDtlAs2.BLGoodsDrCode)
				 && (sCMAcOdrDtlAs1.InqGoodsName == sCMAcOdrDtlAs2.InqGoodsName)
				 && (sCMAcOdrDtlAs1.AnsGoodsName == sCMAcOdrDtlAs2.AnsGoodsName)
				 && (sCMAcOdrDtlAs1.SalesOrderCount == sCMAcOdrDtlAs2.SalesOrderCount)
				 && (sCMAcOdrDtlAs1.DeliveredGoodsCount == sCMAcOdrDtlAs2.DeliveredGoodsCount)
				 && (sCMAcOdrDtlAs1.GoodsNo == sCMAcOdrDtlAs2.GoodsNo)
				 && (sCMAcOdrDtlAs1.GoodsMakerCd == sCMAcOdrDtlAs2.GoodsMakerCd)
				 && (sCMAcOdrDtlAs1.GoodsMakerNm == sCMAcOdrDtlAs2.GoodsMakerNm)
				 && (sCMAcOdrDtlAs1.PureGoodsMakerCd == sCMAcOdrDtlAs2.PureGoodsMakerCd)
				 && (sCMAcOdrDtlAs1.InqPureGoodsNo == sCMAcOdrDtlAs2.InqPureGoodsNo)
				 && (sCMAcOdrDtlAs1.AnsPureGoodsNo == sCMAcOdrDtlAs2.AnsPureGoodsNo)
				 && (sCMAcOdrDtlAs1.ListPrice == sCMAcOdrDtlAs2.ListPrice)
				 && (sCMAcOdrDtlAs1.UnitPrice == sCMAcOdrDtlAs2.UnitPrice)
				 && (sCMAcOdrDtlAs1.GoodsAddInfo == sCMAcOdrDtlAs2.GoodsAddInfo)
				 && (sCMAcOdrDtlAs1.RoughRrofit == sCMAcOdrDtlAs2.RoughRrofit)
				 && (sCMAcOdrDtlAs1.RoughRate == sCMAcOdrDtlAs2.RoughRate)
				 && (sCMAcOdrDtlAs1.AnswerLimitDate == sCMAcOdrDtlAs2.AnswerLimitDate)
				 && (sCMAcOdrDtlAs1.CommentDtl == sCMAcOdrDtlAs2.CommentDtl)
				 && (sCMAcOdrDtlAs1.AppendingFileDtl == sCMAcOdrDtlAs2.AppendingFileDtl)
				 && (sCMAcOdrDtlAs1.AppendingFileNmDtl == sCMAcOdrDtlAs2.AppendingFileNmDtl)
				 && (sCMAcOdrDtlAs1.ShelfNo == sCMAcOdrDtlAs2.ShelfNo)
				 && (sCMAcOdrDtlAs1.AdditionalDivCd == sCMAcOdrDtlAs2.AdditionalDivCd)
				 && (sCMAcOdrDtlAs1.CorrectDivCD == sCMAcOdrDtlAs2.CorrectDivCD)
				 && (sCMAcOdrDtlAs1.AcptAnOdrStatus == sCMAcOdrDtlAs2.AcptAnOdrStatus)
				 && (sCMAcOdrDtlAs1.SalesSlipNum == sCMAcOdrDtlAs2.SalesSlipNum)
				 && (sCMAcOdrDtlAs1.SalesRowNo == sCMAcOdrDtlAs2.SalesRowNo)
				 && (sCMAcOdrDtlAs1.CampaignCode == sCMAcOdrDtlAs2.CampaignCode)
				 && (sCMAcOdrDtlAs1.StockDiv == sCMAcOdrDtlAs2.StockDiv)
				 && (sCMAcOdrDtlAs1.InqOrdDivCd == sCMAcOdrDtlAs2.InqOrdDivCd)
				 && (sCMAcOdrDtlAs1.DisplayOrder == sCMAcOdrDtlAs2.DisplayOrder)
				 && (sCMAcOdrDtlAs1.GoodsMngNo == sCMAcOdrDtlAs2.GoodsMngNo)
				 && (sCMAcOdrDtlAs1.EnterpriseName == sCMAcOdrDtlAs2.EnterpriseName)
				 && (sCMAcOdrDtlAs1.UpdEmployeeName == sCMAcOdrDtlAs2.UpdEmployeeName)
				 && (sCMAcOdrDtlAs1.BLGoodsName == sCMAcOdrDtlAs2.BLGoodsName)
                 // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
                 && (sCMAcOdrDtlAs1.PrmSetDtlNo2 == sCMAcOdrDtlAs2.PrmSetDtlNo2)
                 && (sCMAcOdrDtlAs1.PrmSetDtlName2 == sCMAcOdrDtlAs2.PrmSetDtlName2)
                 && (sCMAcOdrDtlAs1.StockStatusDiv == sCMAcOdrDtlAs2.StockStatusDiv)
                 // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
                // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
                 && (sCMAcOdrDtlAs1.RentDiv == sCMAcOdrDtlAs2.RentDiv)
                 && (sCMAcOdrDtlAs1.MkrSuggestRtPric == sCMAcOdrDtlAs2.MkrSuggestRtPric)
                 && (sCMAcOdrDtlAs1.OpenPriceDiv == sCMAcOdrDtlAs2.OpenPriceDiv)
                // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
                 && (sCMAcOdrDtlAs1.BgnGoodsDiv == sCMAcOdrDtlAs2.BgnGoodsDiv) // ADD 2015/01/19 豊沢 リコメンド対応
                // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
                 && (sCMAcOdrDtlAs1.ModelPrtsAdptYm == sCMAcOdrDtlAs2.ModelPrtsAdptYm)
                 && (sCMAcOdrDtlAs1.ModelPrtsAblsYm == sCMAcOdrDtlAs2.ModelPrtsAblsYm)
                 && (sCMAcOdrDtlAs1.ModelPrtsAdptFrameNo == sCMAcOdrDtlAs2.ModelPrtsAdptFrameNo)
                 && (sCMAcOdrDtlAs1.ModelPrtsAblsFrameNo == sCMAcOdrDtlAs2.ModelPrtsAblsFrameNo)
                // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (sCMAcOdrDtlAs1.AnsDeliDateDiv == sCMAcOdrDtlAs2.AnsDeliDateDiv)
                // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
                 && (sCMAcOdrDtlAs1.GoodsSpecialNtForFac == sCMAcOdrDtlAs2.GoodsSpecialNtForFac)
                 && (sCMAcOdrDtlAs1.GoodsSpecialNtForCOw == sCMAcOdrDtlAs2.GoodsSpecialNtForCOw)
                 && (sCMAcOdrDtlAs1.PrmSetDtlName2ForFac == sCMAcOdrDtlAs2.PrmSetDtlName2ForFac)
                 && (sCMAcOdrDtlAs1.PrmSetDtlName2ForCOw == sCMAcOdrDtlAs2.PrmSetDtlName2ForCOw)
                // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
                // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
                 && (sCMAcOdrDtlAs1.InqBlUtyPtThCd == sCMAcOdrDtlAs2.InqBlUtyPtThCd)
                 && (sCMAcOdrDtlAs1.InqBlUtyPtSbCd == sCMAcOdrDtlAs2.InqBlUtyPtSbCd)
                 && (sCMAcOdrDtlAs1.AnsBlUtyPtThCd == sCMAcOdrDtlAs2.AnsBlUtyPtThCd)
                 && (sCMAcOdrDtlAs1.AnsBlUtyPtSbCd == sCMAcOdrDtlAs2.AnsBlUtyPtSbCd)
                 && (sCMAcOdrDtlAs1.AnsBLGoodsCode == sCMAcOdrDtlAs2.AnsBLGoodsCode)
                 && (sCMAcOdrDtlAs1.AnsBLGoodsDrCode == sCMAcOdrDtlAs2.AnsBLGoodsDrCode)
                // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
                 );
		}
		/// <summary>
		/// SCM受注明細データ（回答）比較処理
		/// </summary>
		/// <param name="target">比較対象のSCMAcOdrDtlAsクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtlAsクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
		/// </remarks>
		public ArrayList Compare(SCMAcOdrDtlAs target)
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
			if(this.InqOriginalEpCd.Trim() != target.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(this.InqOriginalSecCd != target.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(this.InqOtherEpCd != target.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(this.InqOtherSecCd != target.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(this.InquiryNumber != target.InquiryNumber)resList.Add("InquiryNumber");
			if(this.UpdateDate != target.UpdateDate)resList.Add("UpdateDate");
			if(this.UpdateTime != target.UpdateTime)resList.Add("UpdateTime");
			if(this.InqRowNumber != target.InqRowNumber)resList.Add("InqRowNumber");
			if(this.InqRowNumDerivedNo != target.InqRowNumDerivedNo)resList.Add("InqRowNumDerivedNo");
			if(this.InqOrgDtlDiscGuid != target.InqOrgDtlDiscGuid)resList.Add("InqOrgDtlDiscGuid");
			if(this.InqOthDtlDiscGuid != target.InqOthDtlDiscGuid)resList.Add("InqOthDtlDiscGuid");
			if(this.GoodsDivCd != target.GoodsDivCd)resList.Add("GoodsDivCd");
			if(this.RecyclePrtKindCode != target.RecyclePrtKindCode)resList.Add("RecyclePrtKindCode");
			if(this.RecyclePrtKindName != target.RecyclePrtKindName)resList.Add("RecyclePrtKindName");
			if(this.DeliveredGoodsDiv != target.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(this.HandleDivCode != target.HandleDivCode)resList.Add("HandleDivCode");
			if(this.GoodsShape != target.GoodsShape)resList.Add("GoodsShape");
			if(this.DelivrdGdsConfCd != target.DelivrdGdsConfCd)resList.Add("DelivrdGdsConfCd");
			if(this.DeliGdsCmpltDueDate != target.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(this.AnswerDeliveryDate != target.AnswerDeliveryDate)resList.Add("AnswerDeliveryDate");
			if(this.BLGoodsCode != target.BLGoodsCode)resList.Add("BLGoodsCode");
			if(this.BLGoodsDrCode != target.BLGoodsDrCode)resList.Add("BLGoodsDrCode");
			if(this.InqGoodsName != target.InqGoodsName)resList.Add("InqGoodsName");
			if(this.AnsGoodsName != target.AnsGoodsName)resList.Add("AnsGoodsName");
			if(this.SalesOrderCount != target.SalesOrderCount)resList.Add("SalesOrderCount");
			if(this.DeliveredGoodsCount != target.DeliveredGoodsCount)resList.Add("DeliveredGoodsCount");
			if(this.GoodsNo != target.GoodsNo)resList.Add("GoodsNo");
			if(this.GoodsMakerCd != target.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(this.GoodsMakerNm != target.GoodsMakerNm)resList.Add("GoodsMakerNm");
			if(this.PureGoodsMakerCd != target.PureGoodsMakerCd)resList.Add("PureGoodsMakerCd");
			if(this.InqPureGoodsNo != target.InqPureGoodsNo)resList.Add("InqPureGoodsNo");
			if(this.AnsPureGoodsNo != target.AnsPureGoodsNo)resList.Add("AnsPureGoodsNo");
			if(this.ListPrice != target.ListPrice)resList.Add("ListPrice");
			if(this.UnitPrice != target.UnitPrice)resList.Add("UnitPrice");
			if(this.GoodsAddInfo != target.GoodsAddInfo)resList.Add("GoodsAddInfo");
			if(this.RoughRrofit != target.RoughRrofit)resList.Add("RoughRrofit");
			if(this.RoughRate != target.RoughRate)resList.Add("RoughRate");
			if(this.AnswerLimitDate != target.AnswerLimitDate)resList.Add("AnswerLimitDate");
			if(this.CommentDtl != target.CommentDtl)resList.Add("CommentDtl");
			if(this.AppendingFileDtl != target.AppendingFileDtl)resList.Add("AppendingFileDtl");
			if(this.AppendingFileNmDtl != target.AppendingFileNmDtl)resList.Add("AppendingFileNmDtl");
			if(this.ShelfNo != target.ShelfNo)resList.Add("ShelfNo");
			if(this.AdditionalDivCd != target.AdditionalDivCd)resList.Add("AdditionalDivCd");
			if(this.CorrectDivCD != target.CorrectDivCD)resList.Add("CorrectDivCD");
			if(this.AcptAnOdrStatus != target.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(this.SalesSlipNum != target.SalesSlipNum)resList.Add("SalesSlipNum");
			if(this.SalesRowNo != target.SalesRowNo)resList.Add("SalesRowNo");
			if(this.CampaignCode != target.CampaignCode)resList.Add("CampaignCode");
			if(this.StockDiv != target.StockDiv)resList.Add("StockDiv");
			if(this.InqOrdDivCd != target.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(this.DisplayOrder != target.DisplayOrder)resList.Add("DisplayOrder");
			if(this.GoodsMngNo != target.GoodsMngNo)resList.Add("GoodsMngNo");
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.BLGoodsName != target.BLGoodsName)resList.Add("BLGoodsName");
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            if (this.PrmSetDtlNo2 != target.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (this.PrmSetDtlName2 != target.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (this.StockStatusDiv != target.StockStatusDiv) resList.Add("StockStatusDiv");
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            if (this.RentDiv != target.RentDiv) resList.Add("RentDiv");
            if (this.MkrSuggestRtPric != target.MkrSuggestRtPric) resList.Add("MkrSuggestRtPric");
            if (this.OpenPriceDiv != target.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
            if (this.BgnGoodsDiv != target.BgnGoodsDiv) resList.Add("BgnGoodsDiv"); // ADD 2015/01/19 豊沢 リコメンド対応
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
            if (this.ModelPrtsAdptYm != target.ModelPrtsAdptYm) resList.Add("ModelPrtsAdptYm");
            if (this.ModelPrtsAblsYm != target.ModelPrtsAblsYm) resList.Add("ModelPrtsAblsYm");
            if (this.ModelPrtsAdptFrameNo != target.ModelPrtsAdptFrameNo) resList.Add("ModelPrtsAdptFrameNo");
            if (this.ModelPrtsAblsFrameNo != target.ModelPrtsAblsFrameNo) resList.Add("ModelPrtsAblsFrameNo");
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (this.AnsDeliDateDiv != target.AnsDeliDateDiv) resList.Add("AnsDeliDateDiv");
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
            if (this.GoodsSpecialNtForFac != target.GoodsSpecialNtForFac) resList.Add("GoodsSpecialNtForFac");
            if (this.GoodsSpecialNtForCOw != target.GoodsSpecialNtForCOw) resList.Add("GoodsSpecialNtForCOw");
            if (this.PrmSetDtlName2ForFac != target.PrmSetDtlName2ForFac) resList.Add("PrmSetDtlName2ForFac");
            if (this.PrmSetDtlName2ForCOw != target.PrmSetDtlName2ForCOw) resList.Add("PrmSetDtlName2ForCOw");
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
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
		/// SCM受注明細データ（回答）比較処理
		/// </summary>
		/// <param name="sCMAcOdrDtlAs1">比較するSCMAcOdrDtlAsクラスのインスタンス</param>
		/// <param name="sCMAcOdrDtlAs2">比較するSCMAcOdrDtlAsクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtlAsクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16 田建委</br>
        /// <br>管理番号         :   11470007-00</br>
        /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
		/// </remarks>
		public static ArrayList Compare(SCMAcOdrDtlAs sCMAcOdrDtlAs1, SCMAcOdrDtlAs sCMAcOdrDtlAs2)
		{
			ArrayList resList = new ArrayList();
			if(sCMAcOdrDtlAs1.CreateDateTime != sCMAcOdrDtlAs2.CreateDateTime)resList.Add("CreateDateTime");
			if(sCMAcOdrDtlAs1.UpdateDateTime != sCMAcOdrDtlAs2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(sCMAcOdrDtlAs1.EnterpriseCode != sCMAcOdrDtlAs2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(sCMAcOdrDtlAs1.FileHeaderGuid != sCMAcOdrDtlAs2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(sCMAcOdrDtlAs1.UpdEmployeeCode != sCMAcOdrDtlAs2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(sCMAcOdrDtlAs1.UpdAssemblyId1 != sCMAcOdrDtlAs2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(sCMAcOdrDtlAs1.UpdAssemblyId2 != sCMAcOdrDtlAs2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(sCMAcOdrDtlAs1.LogicalDeleteCode != sCMAcOdrDtlAs2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(sCMAcOdrDtlAs1.InqOriginalEpCd.Trim() != sCMAcOdrDtlAs2.InqOriginalEpCd.Trim())resList.Add("InqOriginalEpCd");//@@@@20230303
			if(sCMAcOdrDtlAs1.InqOriginalSecCd != sCMAcOdrDtlAs2.InqOriginalSecCd)resList.Add("InqOriginalSecCd");
			if(sCMAcOdrDtlAs1.InqOtherEpCd != sCMAcOdrDtlAs2.InqOtherEpCd)resList.Add("InqOtherEpCd");
			if(sCMAcOdrDtlAs1.InqOtherSecCd != sCMAcOdrDtlAs2.InqOtherSecCd)resList.Add("InqOtherSecCd");
			if(sCMAcOdrDtlAs1.InquiryNumber != sCMAcOdrDtlAs2.InquiryNumber)resList.Add("InquiryNumber");
			if(sCMAcOdrDtlAs1.UpdateDate != sCMAcOdrDtlAs2.UpdateDate)resList.Add("UpdateDate");
			if(sCMAcOdrDtlAs1.UpdateTime != sCMAcOdrDtlAs2.UpdateTime)resList.Add("UpdateTime");
			if(sCMAcOdrDtlAs1.InqRowNumber != sCMAcOdrDtlAs2.InqRowNumber)resList.Add("InqRowNumber");
			if(sCMAcOdrDtlAs1.InqRowNumDerivedNo != sCMAcOdrDtlAs2.InqRowNumDerivedNo)resList.Add("InqRowNumDerivedNo");
			if(sCMAcOdrDtlAs1.InqOrgDtlDiscGuid != sCMAcOdrDtlAs2.InqOrgDtlDiscGuid)resList.Add("InqOrgDtlDiscGuid");
			if(sCMAcOdrDtlAs1.InqOthDtlDiscGuid != sCMAcOdrDtlAs2.InqOthDtlDiscGuid)resList.Add("InqOthDtlDiscGuid");
			if(sCMAcOdrDtlAs1.GoodsDivCd != sCMAcOdrDtlAs2.GoodsDivCd)resList.Add("GoodsDivCd");
			if(sCMAcOdrDtlAs1.RecyclePrtKindCode != sCMAcOdrDtlAs2.RecyclePrtKindCode)resList.Add("RecyclePrtKindCode");
			if(sCMAcOdrDtlAs1.RecyclePrtKindName != sCMAcOdrDtlAs2.RecyclePrtKindName)resList.Add("RecyclePrtKindName");
			if(sCMAcOdrDtlAs1.DeliveredGoodsDiv != sCMAcOdrDtlAs2.DeliveredGoodsDiv)resList.Add("DeliveredGoodsDiv");
			if(sCMAcOdrDtlAs1.HandleDivCode != sCMAcOdrDtlAs2.HandleDivCode)resList.Add("HandleDivCode");
			if(sCMAcOdrDtlAs1.GoodsShape != sCMAcOdrDtlAs2.GoodsShape)resList.Add("GoodsShape");
			if(sCMAcOdrDtlAs1.DelivrdGdsConfCd != sCMAcOdrDtlAs2.DelivrdGdsConfCd)resList.Add("DelivrdGdsConfCd");
			if(sCMAcOdrDtlAs1.DeliGdsCmpltDueDate != sCMAcOdrDtlAs2.DeliGdsCmpltDueDate)resList.Add("DeliGdsCmpltDueDate");
			if(sCMAcOdrDtlAs1.AnswerDeliveryDate != sCMAcOdrDtlAs2.AnswerDeliveryDate)resList.Add("AnswerDeliveryDate");
			if(sCMAcOdrDtlAs1.BLGoodsCode != sCMAcOdrDtlAs2.BLGoodsCode)resList.Add("BLGoodsCode");
			if(sCMAcOdrDtlAs1.BLGoodsDrCode != sCMAcOdrDtlAs2.BLGoodsDrCode)resList.Add("BLGoodsDrCode");
			if(sCMAcOdrDtlAs1.InqGoodsName != sCMAcOdrDtlAs2.InqGoodsName)resList.Add("InqGoodsName");
			if(sCMAcOdrDtlAs1.AnsGoodsName != sCMAcOdrDtlAs2.AnsGoodsName)resList.Add("AnsGoodsName");
			if(sCMAcOdrDtlAs1.SalesOrderCount != sCMAcOdrDtlAs2.SalesOrderCount)resList.Add("SalesOrderCount");
			if(sCMAcOdrDtlAs1.DeliveredGoodsCount != sCMAcOdrDtlAs2.DeliveredGoodsCount)resList.Add("DeliveredGoodsCount");
			if(sCMAcOdrDtlAs1.GoodsNo != sCMAcOdrDtlAs2.GoodsNo)resList.Add("GoodsNo");
			if(sCMAcOdrDtlAs1.GoodsMakerCd != sCMAcOdrDtlAs2.GoodsMakerCd)resList.Add("GoodsMakerCd");
			if(sCMAcOdrDtlAs1.GoodsMakerNm != sCMAcOdrDtlAs2.GoodsMakerNm)resList.Add("GoodsMakerNm");
			if(sCMAcOdrDtlAs1.PureGoodsMakerCd != sCMAcOdrDtlAs2.PureGoodsMakerCd)resList.Add("PureGoodsMakerCd");
			if(sCMAcOdrDtlAs1.InqPureGoodsNo != sCMAcOdrDtlAs2.InqPureGoodsNo)resList.Add("InqPureGoodsNo");
			if(sCMAcOdrDtlAs1.AnsPureGoodsNo != sCMAcOdrDtlAs2.AnsPureGoodsNo)resList.Add("AnsPureGoodsNo");
			if(sCMAcOdrDtlAs1.ListPrice != sCMAcOdrDtlAs2.ListPrice)resList.Add("ListPrice");
			if(sCMAcOdrDtlAs1.UnitPrice != sCMAcOdrDtlAs2.UnitPrice)resList.Add("UnitPrice");
			if(sCMAcOdrDtlAs1.GoodsAddInfo != sCMAcOdrDtlAs2.GoodsAddInfo)resList.Add("GoodsAddInfo");
			if(sCMAcOdrDtlAs1.RoughRrofit != sCMAcOdrDtlAs2.RoughRrofit)resList.Add("RoughRrofit");
			if(sCMAcOdrDtlAs1.RoughRate != sCMAcOdrDtlAs2.RoughRate)resList.Add("RoughRate");
			if(sCMAcOdrDtlAs1.AnswerLimitDate != sCMAcOdrDtlAs2.AnswerLimitDate)resList.Add("AnswerLimitDate");
			if(sCMAcOdrDtlAs1.CommentDtl != sCMAcOdrDtlAs2.CommentDtl)resList.Add("CommentDtl");
			if(sCMAcOdrDtlAs1.AppendingFileDtl != sCMAcOdrDtlAs2.AppendingFileDtl)resList.Add("AppendingFileDtl");
			if(sCMAcOdrDtlAs1.AppendingFileNmDtl != sCMAcOdrDtlAs2.AppendingFileNmDtl)resList.Add("AppendingFileNmDtl");
			if(sCMAcOdrDtlAs1.ShelfNo != sCMAcOdrDtlAs2.ShelfNo)resList.Add("ShelfNo");
			if(sCMAcOdrDtlAs1.AdditionalDivCd != sCMAcOdrDtlAs2.AdditionalDivCd)resList.Add("AdditionalDivCd");
			if(sCMAcOdrDtlAs1.CorrectDivCD != sCMAcOdrDtlAs2.CorrectDivCD)resList.Add("CorrectDivCD");
			if(sCMAcOdrDtlAs1.AcptAnOdrStatus != sCMAcOdrDtlAs2.AcptAnOdrStatus)resList.Add("AcptAnOdrStatus");
			if(sCMAcOdrDtlAs1.SalesSlipNum != sCMAcOdrDtlAs2.SalesSlipNum)resList.Add("SalesSlipNum");
			if(sCMAcOdrDtlAs1.SalesRowNo != sCMAcOdrDtlAs2.SalesRowNo)resList.Add("SalesRowNo");
			if(sCMAcOdrDtlAs1.CampaignCode != sCMAcOdrDtlAs2.CampaignCode)resList.Add("CampaignCode");
			if(sCMAcOdrDtlAs1.StockDiv != sCMAcOdrDtlAs2.StockDiv)resList.Add("StockDiv");
			if(sCMAcOdrDtlAs1.InqOrdDivCd != sCMAcOdrDtlAs2.InqOrdDivCd)resList.Add("InqOrdDivCd");
			if(sCMAcOdrDtlAs1.DisplayOrder != sCMAcOdrDtlAs2.DisplayOrder)resList.Add("DisplayOrder");
			if(sCMAcOdrDtlAs1.GoodsMngNo != sCMAcOdrDtlAs2.GoodsMngNo)resList.Add("GoodsMngNo");
			if(sCMAcOdrDtlAs1.EnterpriseName != sCMAcOdrDtlAs2.EnterpriseName)resList.Add("EnterpriseName");
			if(sCMAcOdrDtlAs1.UpdEmployeeName != sCMAcOdrDtlAs2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(sCMAcOdrDtlAs1.BLGoodsName != sCMAcOdrDtlAs2.BLGoodsName)resList.Add("BLGoodsName");
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            if (sCMAcOdrDtlAs1.PrmSetDtlNo2 != sCMAcOdrDtlAs2.PrmSetDtlNo2) resList.Add("PrmSetDtlNo2");
            if (sCMAcOdrDtlAs1.PrmSetDtlName2 != sCMAcOdrDtlAs2.PrmSetDtlName2) resList.Add("PrmSetDtlName2");
            if (sCMAcOdrDtlAs1.StockStatusDiv != sCMAcOdrDtlAs2.StockStatusDiv) resList.Add("StockStatusDiv");
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            if (sCMAcOdrDtlAs1.RentDiv != sCMAcOdrDtlAs2.RentDiv) resList.Add("RentDiv");
            if (sCMAcOdrDtlAs1.MkrSuggestRtPric != sCMAcOdrDtlAs2.MkrSuggestRtPric) resList.Add("MkrSuggestRtPric");
            if (sCMAcOdrDtlAs1.OpenPriceDiv != sCMAcOdrDtlAs2.OpenPriceDiv) resList.Add("OpenPriceDiv");
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
            if (sCMAcOdrDtlAs1.BgnGoodsDiv != sCMAcOdrDtlAs2.BgnGoodsDiv) resList.Add("BgnGoodsDiv"); // ADD 2015/01/19 豊沢 リコメンド対応
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
            if (sCMAcOdrDtlAs1.ModelPrtsAdptYm != sCMAcOdrDtlAs2.ModelPrtsAdptYm) resList.Add("ModelPrtsAdptYm");
            if (sCMAcOdrDtlAs1.ModelPrtsAblsYm != sCMAcOdrDtlAs2.ModelPrtsAblsYm) resList.Add("ModelPrtsAblsYm");
            if (sCMAcOdrDtlAs1.ModelPrtsAdptFrameNo != sCMAcOdrDtlAs2.ModelPrtsAdptFrameNo) resList.Add("ModelPrtsAdptFrameNo");
            if (sCMAcOdrDtlAs1.ModelPrtsAblsFrameNo != sCMAcOdrDtlAs2.ModelPrtsAblsFrameNo) resList.Add("ModelPrtsAblsFrameNo");
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (sCMAcOdrDtlAs1.AnsDeliDateDiv != sCMAcOdrDtlAs2.AnsDeliDateDiv) resList.Add("AnsDeliDateDiv");
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
            if (sCMAcOdrDtlAs1.GoodsSpecialNtForFac != sCMAcOdrDtlAs2.GoodsSpecialNtForFac) resList.Add("GoodsSpecialNtForFac");
            if (sCMAcOdrDtlAs1.GoodsSpecialNtForCOw != sCMAcOdrDtlAs2.GoodsSpecialNtForCOw) resList.Add("GoodsSpecialNtForCOw");
            if (sCMAcOdrDtlAs1.PrmSetDtlName2ForFac != sCMAcOdrDtlAs2.PrmSetDtlName2ForFac) resList.Add("PrmSetDtlName2ForFac");
            if (sCMAcOdrDtlAs1.PrmSetDtlName2ForCOw != sCMAcOdrDtlAs2.PrmSetDtlName2ForCOw) resList.Add("PrmSetDtlName2ForCOw");
            // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<
            // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            if (sCMAcOdrDtlAs1.InqBlUtyPtThCd != sCMAcOdrDtlAs2.InqBlUtyPtThCd) resList.Add("InqBlUtyPtThCd");
            if (sCMAcOdrDtlAs1.InqBlUtyPtSbCd != sCMAcOdrDtlAs2.InqBlUtyPtSbCd) resList.Add("InqBlUtyPtSbCd");
            if (sCMAcOdrDtlAs1.AnsBlUtyPtThCd != sCMAcOdrDtlAs2.AnsBlUtyPtThCd) resList.Add("AnsBlUtyPtThCd");
            if (sCMAcOdrDtlAs1.AnsBlUtyPtSbCd != sCMAcOdrDtlAs2.AnsBlUtyPtSbCd) resList.Add("AnsBlUtyPtSbCd");
            if (sCMAcOdrDtlAs1.AnsBLGoodsCode != sCMAcOdrDtlAs2.AnsBLGoodsCode) resList.Add("AnsBLGoodsCode");
            if (sCMAcOdrDtlAs1.AnsBLGoodsDrCode != sCMAcOdrDtlAs2.AnsBLGoodsDrCode) resList.Add("AnsBLGoodsDrCode");
            // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

			return resList;
		}
	}
}
