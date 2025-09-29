//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM関連データデータパラメータ
//                  :   PMSCM01023D.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   22008 長内 数馬
// Date             :   2009.05.13
//----------------------------------------------------------------------
// Update Note      :   ○項目追加
//                        キャンセル状態区分
// Programmer       :   21024 佐々木 健
// Date             :   2010/05/26
//----------------------------------------------------------------------
// Update Note      :   ○項目追加
//                        PM現在個数
//                        セット部品メーカーコード
//                        セット部品番号
//                        セット部品親子番号
// Programmer       :   高峰
// Date             :   2011/08/10
//----------------------------------------------------------------------
// Update Note      :   ○項目追加
//                        商品規格・特記事項
// Programmer       :   西 毅
// Date             :   2012/01/10
//----------------------------------------------------------------------
// Update Note      :   ○項目追加
//                        PS管理番号
// Programmer       :   吉岡 孝憲 30745
// Date             :   2012/04/12
//----------------------------------------------------------------------
// Update Note      :   ○項目追加
//                        自動見積部品コード
// Programmer       :   西 毅
// Date             :   2012/05/30
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
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    # region delete
    /*
    /// public class name:   SCMAcOdrDtlAsWork
	/// <summary>
	///                      SCM受注明細データ（回答）ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受注明細データ（回答）ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/04/13</br>
	/// <br>Genarated Date   :   2009/06/16  (CSharp File Generated Date)</br>
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
	/// <br>                 :   問合せ・発注種別</br>
	/// <br>                 :   表示順位</br>
	/// <br>                 :   ○桁数変更</br>
	/// <br>                 :   回答納期　20→10</br>
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
	/// <br>Update Note      :   2009/06/02  杉村</br>
	/// <br>                 :   ○桁数変更</br>
	/// <br>                 :   純正商品メーカーコード　2→3</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   商品メーカー名称</br>
	/// <br>Update Note      :   2009/06/15  杉村</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   商品名（カナ）</br>
	/// <br>                 :   純正商品番号</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   問発商品名</br>
	/// <br>                 :   回答商品名</br>
	/// <br>                 :   問発純正商品番号</br>
	/// <br>                 :   回答純正商品番号</br>
	/// <br>                 :   ○キー追加</br>
	/// <br>                 :   3,9,10,11,12,13,14,15,16,17,53,54,55</br>
    /// <br></br>
    /// <br>Update Note      :   2010/05/26  21024 佐々木 健</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   キャンセル状態区分</br>
    /// <br></br>
    /// <br>Update Note      :   2011/02/09  21024 佐々木 健</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   明細取込区分</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdrDtlAsWork : IFileHeader
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

		/// <summary>更新時間</summary>
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
        private Byte[] _appendingFileDtl = new Byte[0];

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

        // 2010/05/26 Add >>>
        /// <summary>キャンセル状態区分</summary>
        /// <remarks>0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定</remarks>
        private Int16 _cancelCndtinDiv;
        // 2010/05/26 Add <<<
        // 2011/02/09 Add >>>
        /// <summary>明細取込区分</summary>
        /// <remarks>0:未取込 1:取込済</remarks>
        private Int32 _dtlTakeinDivCd;
        // 2011/02/09 Add <<<

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
            get { return _appendingFileDtl; }
            set { _appendingFileDtl = value; }
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

        // 2010/05/26 Add >>>
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
        // 2010/05/26 Add <<<

        // 2011/02/09 Add >>>
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
        // 2011/02/09 Add <<<

		/// <summary>
		/// SCM受注明細データ（回答）ワークコンストラクタ
		/// </summary>
		/// <returns>SCMAcOdrDtlAsWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdrDtlAsWork()
		{
		}

    }
    */
    # endregion

	/// public class name:   SCMAcOdrDtlAsWork
	/// <summary>
	///                      SCM受注明細データ（回答）ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   SCM受注明細データ（回答）ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2009/04/13</br>
	/// <br>Genarated Date   :   2011/05/20  (CSharp File Generated Date)</br>
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
	/// <br>                 :   問合せ・発注種別</br>
	/// <br>                 :   表示順位</br>
	/// <br>                 :   ○桁数変更</br>
	/// <br>                 :   回答納期　20→10</br>
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
	/// <br>Update Note      :   2009/06/02  杉村</br>
	/// <br>                 :   ○桁数変更</br>
	/// <br>                 :   純正商品メーカーコード　2→3</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   商品メーカー名称</br>
	/// <br>Update Note      :   2009/06/15  杉村</br>
	/// <br>                 :   ○項目削除</br>
	/// <br>                 :   商品名（カナ）</br>
	/// <br>                 :   純正商品番号</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   問発商品名</br>
	/// <br>                 :   回答商品名</br>
	/// <br>                 :   問発純正商品番号</br>
	/// <br>                 :   回答純正商品番号</br>
	/// <br>                 :   ○キー追加</br>
	/// <br>                 :   3,9,10,11,12,13,14,15,16,17,53,54,55</br>
	/// <br>Update Note      :   2009/06/26  杉村</br>
	/// <br>                 :   ○補足変更</br>
	/// <br>                 :   在庫区分</br>
	/// <br>                 :   0:非在庫,1:委託在庫,2:得意先在庫,3:優先倉庫,4:自社在庫</br>
	/// <br>Update Note      :   2010/05/25  長内</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   キャンセル状態区分</br>
	/// <br>Update Note      :   2011/2/9  長内</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   明細取込区分</br>
	/// <br>Update Note      :   2011/5/19  長内</br>
	/// <br>                 :   ○項目追加</br>
	/// <br>                 :   倉庫コード</br>
	/// <br>                 :   倉庫名称</br>
	/// <br>                 :   倉庫棚番</br>
    /// <br>Update Note      :   2011/08/10  高峰</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   PM現在個数</br>
    /// <br>                 :   セット部品メーカーコード</br>
    /// <br>                 :   セット部品番号</br>
    /// <br>                 :   セット部品親子番号</br>
    /// <br>Update Note      :   2012/01/10  西 毅</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   商品規格・特記事項</br>
    /// <br>Update Note      :   2012/04/12  吉岡 孝憲 30745</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   PS管理番号</br>
    /// <br>Update Note      :   2012/05/30  西 毅</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   自動見積部品コード</br>
    /// <br>Update Note      :   2013/05/08  吉岡</br>
    /// <br>                 :   2013/06/18配信　SCM障害№10308,№10528</br>
    /// <br>Update Note      :   2013/05/15  吉岡</br>
    /// <br>                 :   2013/06/18配信　SCM障害№10410</br>
    /// <br>Update Note      :   管理番号  10900690-00 作成担当 : qijh</br>
    /// <br>                 :   配信日なし分 Redmine#34752 「PMSCMのNo.10385」BLPの対応 </br>
    /// <br>Update Note      :   2014/06/04  湯上 千加子</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   優良設定詳細コード２</br>
    /// <br>                 :   優良設定詳細名称２</br>
    /// <br>                 :   在庫状況区分</br>
    /// <br>Update Note      :   2014/12/19 30744 湯上 千加子</br>
    /// <br>                 :   管理番号 11070266-00</br>
    /// <br>			     :   SCM高速化 PMNS対応 貸出区分、メーカー希望小売価格、オープン価格区分の追加</br>
    /// <br>Update Note      :   2015/01/19  31065 豊沢 憲弘</br>
    /// <br>                 :   管理番号 11070266-00</br>
    /// <br>                 :   リコメンド対応</br>
    /// <br>Update Note      :   2015/01/30  30744 湯上 千加子</br>
    /// <br>                 :   管理番号 11070266-00</br>
    /// <br>                 :   SCM高速化 生産年式、車台番号対応 型式別部品採用年月、型式別部品廃止年月、型式別部品採用車台番号、型式別部品廃止車台番号の追加</br>
    /// <br>Update Note      :   2015/02/10  30745 吉岡</br>
    /// <br>                 :   管理番号 11070266-00</br>
    /// <br>                 :   SCM高速化 回答納期区分対応 項目追加</br>
    /// <br>Update Note      :   2015/02/20  31126 下口</br>
    /// <br>                 :   管理番号 11070266-00</br>
    /// <br>                 :   SCM高速化 Ｃ向け種別特記対応</br>
    /// <br>                 :   商品規格・特記事項(工場向け)、商品規格・特記事項(カーオーナー向け)、優良設定詳細名称２(工場向け)、優良設定詳細名称２(カーオーナー向け)の追加</br>
    /// <br>Update Note      :   2018/04/16  田建委</br>
    /// <br>                 :   管理番号 11470007-00</br>
    /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SCMAcOdrDtlAsWork : IFileHeader
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

		/// <summary>更新時間</summary>
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
		private Byte[] _appendingFileDtl = new Byte[0];

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
		/// <remarks>0:非在庫,1:委託在庫,2:得意先在庫,3:優先倉庫,4:自社在庫</remarks>
		private Int32 _stockDiv;

		/// <summary>問合せ・発注種別</summary>
		/// <remarks>1:問合せ 2:発注</remarks>
		private Int32 _inqOrdDivCd;

		/// <summary>表示順位</summary>
		private Int32 _displayOrder;

		/// <summary>商品管理番号</summary>
		/// <remarks>PS管理番号</remarks>
		private Int32 _goodsMngNo;

		/// <summary>キャンセル状態区分</summary>
		/// <remarks>0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定</remarks>
		private Int16 _cancelCndtinDiv;

		/// <summary>明細取込区分</summary>
		/// <remarks>0:未取込 1:取込済</remarks>
		private Int32 _dtlTakeinDivCd;

		/// <summary>倉庫コード</summary>
		private string _warehouseCode = "";

		/// <summary>倉庫名称</summary>
		private string _warehouseName = "";

		/// <summary>倉庫棚番</summary>
		private string _warehouseShelfNo = "";

        // -- ADD 2011/08/10   ------ >>>>>>
        /// <summary>PM現在個数</summary>
        private Double _pmPrsntCount;

        /// <summary>セット部品メーカーコード</summary>
        private Int32 _setPartsMkrCd;

        /// <summary>セット部品番号</summary>
        private string _setPartsNumber = "";

        /// <summary>セット部品親子番号</summary>
        /// <remarks>0:親,1-*:子</remarks>
        private Int32 _setPartsMainSubNo;
        // -- ADD 2011/08/10   ------ <<<<<<

        // 2012/01/10 Add >>>
        /// <summary>商品規格・特記事項</summary>
        private string _GoodsSpecialNote = "";
        // 2012/01/10 Add <<<

        // 2012/04/12 Add >>> 
        /// <summary>PS管理番号</summary>
        private Int32 _psMngNo;
        // 2012/04/12 Add <<<
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        /// <summary>自動見積部品コード</summary>
        private string _AutoEstimatePartsCd = "";
        // --- ADD T.Nishi 2012/05/30 ----------<<<<<

        // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> 売上伝票合計（税込）を取得または設定します。 </summary>
        private Int64 _salesTotalTaxInc;
        /// <summary> 売上伝票合計（税抜）を取得または設定します。</summary>
        private Int64 _salesTotalTaxExc;
        /// <summary>SCM消費税転嫁方式を取得または設定します。</summary>
        private Int32 _scmConsTaxLayMethod;
        /// <summary>消費税税率を取得または設定します。</summary>
        private Double _consTaxRate;
        /// <summary> SCM端数処理区分を取得または設定します。</summary>
        private Int32 _scmFractionProcCd;
        /// <summary> 売掛消費税を取得または設定します。</summary>
        private Int64 _accRecConsTax;
        /// <summary> PM売上日を取得または設定します。 </summary>
        private Int32 _pMSalesDate;
        /// <summary> 仕入先伝票発行時刻を取得または設定します。</summary>
        private Int32 _suppSlpPrtTime;
        /// <summary> 売上金額（税込み）を取得または設定します。 </summary>
        private Int64 _salesMoneyTaxInc;
        /// <summary> 売上金額（税抜き）を取得または設定します。</summary>
        private Int64 _salesMoneyTaxExc;
        // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> データ入力システムを取得または設定します。 </summary>
        private Int32 _dataInputSystem;
        // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        /// <summary>PM主管倉庫コード</summary>
        private string _pmMainMngWarehouseCd = "";

        /// <summary>PM主管倉庫名称</summary>
        private string _pmMainMngWarehouseName = "";

        /// <summary>PM主管棚番</summary>
        private string _pmMainMngShelfNo = "";

        /// <summary>PM主管現在個数</summary>
        private Double _pmMainMngPrsntCount;
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

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
        private Int16 _rentDiv = 0;
        /// <summary>メーカー希望小売価格</summary>
        private Int64 _mkrSuggestRtPric = 0;
        /// <summary>オープン価格区分</summary>
        private Int32 _openPriceDiv = 0;
        // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

        // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
        /// <summary>お買得商品選択区分</summary>
        private Int16 _bgnGoodsDiv = 0;
        // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<

        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
        /// <summary>型式別部品採用年月</summary>
        private Int32 _modelPrtsAdptYm = 0;
        /// <summary>型式別部品廃止年月</summary>
        private Int32 _modelPrtsAblsYm = 0;
        /// <summary>型式別部品採用車台番号</summary>
        private Int32 _modelPrtsAdptFrameNo = 0;
        /// <summary>型式別部品廃止車台番号</summary>
        private Int32 _modelPrtsAblsFrameNo = 0;
        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

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
		/// <value>0:非在庫,1:委託在庫,2:得意先在庫,3:優先倉庫,4:自社在庫</value>
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
			get{return _cancelCndtinDiv;}
			set{_cancelCndtinDiv = value;}
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
			get{return _dtlTakeinDivCd;}
			set{_dtlTakeinDivCd = value;}
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

        // -- ADD 2011/08/10   ------ >>>>>>
        /// public propaty name  :  PmPrsntCount
        /// <summary>PM現在個数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM現在個数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Double PmPrsntCount
        {
            get { return _pmPrsntCount; }
            set { _pmPrsntCount = value; }
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
            get { return _setPartsMkrCd; }
            set { _setPartsMkrCd = value; }
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
            get { return _setPartsNumber; }
            set { _setPartsNumber = value; }
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
            get { return _setPartsMainSubNo; }
            set { _setPartsMainSubNo = value; }
        }
        // -- ADD 2011/08/10   ------ <<<<<<

        // 2012/01/10 Add >>>
        /// public propaty name  :  GoodsSpecialNote
        /// <summary>商品規格・特記事項プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品規格・特記事項プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string GoodsSpecialNote
        {
            get { return _GoodsSpecialNote; }
            set { _GoodsSpecialNote = value; }
        }
        // 2012/01/10 Add <<<
        // 2012/04/12 Add >>>
        /// public propaty name  :  PSMngNo
        /// <summary>PS管理番号</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PS管理番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PSMngNo
        {
            get { return _psMngNo; }
            set { _psMngNo = value; }
        }
        // 2012/04/12 Add <<<
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        /// public propaty name  :  AutoEstimatePartsCd
        /// <summary>自動見積部品コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自動見積部品コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AutoEstimatePartsCd
        {
            get { return _AutoEstimatePartsCd; }
            set { _AutoEstimatePartsCd = value; }
        }
        // --- ADD T.Nishi 2012/05/30 ----------<<<<<


        // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  SalesTotalTaxInc
        /// <summary>売上伝票合計（税込）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税込）名称プロパティ</br>
        /// </remarks>
        public Int64 SalesTotalTaxInc
        {
            get { return _salesTotalTaxInc; }
            set { _salesTotalTaxInc = value; }
        }

        /// public propaty name  :  SalesTotalTaxExc
        /// <summary>売上伝票合計（税抜）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票合計（税抜）プロパティ</br>
        /// </remarks>
        public Int64 SalesTotalTaxExc
        {
            get { return _salesTotalTaxExc; }
            set { _salesTotalTaxExc = value; }
        }

        /// public propaty name  :  ScmConsTaxLayMethod
        /// <summary>SCM消費税転嫁方式プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM消費税転嫁方式プロパティ</br>
        /// </remarks>
        public Int32 ScmConsTaxLayMethod
        {
            get { return _scmConsTaxLayMethod; }
            set { _scmConsTaxLayMethod = value; }
        }

        /// public propaty name  :  ConsTaxRate
        /// <summary>消費税税率プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税税率プロパティ</br>
        /// </remarks>
        public Double ConsTaxRate
        {
            get { return _consTaxRate; }
            set { _consTaxRate = value; }
        }

        /// public propaty name  :  ScmFractionProcCd
        /// <summary>SCM端数処理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM端数処理区分プロパティ</br>
        /// </remarks>
        public Int32 ScmFractionProcCd
        {
            get { return _scmFractionProcCd; }
            set { _scmFractionProcCd = value; }
        }

        /// public propaty name  :  AccRecConsTax
        /// <summary>売掛消費税プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛消費税プロパティ</br>
        /// </remarks>
        public Int64 AccRecConsTax
        {
            get { return _accRecConsTax; }
            set { _accRecConsTax = value; }
        }

        /// public propaty name  :  PMSalesDate
        /// <summary>PM売上日プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   PM売上日プロパティ</br>
        /// </remarks>
        public Int32 PMSalesDate
        {
            get { return _pMSalesDate; }
            set { _pMSalesDate = value; }
        }

        /// public propaty name  :  SuppSlpPrtTime
        /// <summary>仕入先伝票発行時刻プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入先伝票発行時刻プロパティ</br>
        /// </remarks>
        public Int32 SuppSlpPrtTime
        {
            get { return _suppSlpPrtTime; }
            set { _suppSlpPrtTime = value; }
        }

        /// public propaty name  :  SalesMoneyTaxInc
        /// <summary>売上金額（税込み）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税込み）プロパティ</br>
        /// </remarks>
        public Int64 SalesMoneyTaxInc
        {
            get { return _salesMoneyTaxInc; }
            set { _salesMoneyTaxInc = value; }
        }

        /// public propaty name  :  SalesMoneyTaxExc
        /// <summary>売上金額（税抜き）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額（税抜き）プロパティ</br>
        /// </remarks>
        public Int64 SalesMoneyTaxExc
        {
            get { return _salesMoneyTaxExc; }
            set { _salesMoneyTaxExc = value; }
        }
        // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// public propaty name  :  DataInputSystem
        /// <summary>データ入力システムプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ入力システムプロパティ</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
        }
        // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
            get { return _pmMainMngWarehouseCd; }
            set { _pmMainMngWarehouseCd = value; }
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
        /// <summary>型式別部品廃止年月プロパティ</summary>
        /// <value></value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   型式別部品廃止年月プロパティ</br>
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

        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
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
        // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
		/// SCM受注明細データ（回答）ワークコンストラクタ
		/// </summary>
		/// <returns>SCMAcOdrDtlAsWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SCMAcOdrDtlAsWork()
		{
		}

	}

    # region delete
    /*
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMAcOdrDtlAsWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SCMAcOdrDtlAsWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SCMAcOdrDtlAsWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SCMAcOdrDtlAsWork || graph is ArrayList || graph is SCMAcOdrDtlAsWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SCMAcOdrDtlAsWork).FullName));

            if (graph != null && graph is SCMAcOdrDtlAsWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SCMAcOdrDtlAsWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SCMAcOdrDtlAsWork[])graph).Length;
            }
            else if (graph is SCMAcOdrDtlAsWork)
            {
                serInfo.RetTypeInfo = 1;
                occurrence = 1;
            }

            serInfo.Occurrence = occurrence;		 //繰り返し数	

            //作成日時
            serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
            //更新日時
            serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
            //企業コード
            serInfo.MemberInfo.Add(typeof(string)); //EnterpriseCode
            //GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //FileHeaderGuid
            //更新従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //UpdEmployeeCode
            //更新アセンブリID1
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId1
            //更新アセンブリID2
            serInfo.MemberInfo.Add(typeof(string)); //UpdAssemblyId2
            //論理削除区分
            serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
            //問合せ元企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalEpCd
            //問合せ元拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOriginalSecCd
            //問合せ先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherEpCd
            //問合せ先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InqOtherSecCd
            //問合せ番号
            serInfo.MemberInfo.Add(typeof(Int64)); //InquiryNumber
            //更新年月日
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateDate
            //更新時間
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateTime
            //問合せ行番号
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumber
            //問合せ行番号枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //InqRowNumDerivedNo
            //問合せ元明細識別GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOrgDtlDiscGuid
            //問合せ先明細識別GUID
            serInfo.MemberInfo.Add(typeof(byte[]));  //InqOthDtlDiscGuid
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
            //回答納期
            serInfo.MemberInfo.Add(typeof(string)); //AnswerDeliveryDate
            //BL商品コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsCode
            //BL商品コード枝番
            serInfo.MemberInfo.Add(typeof(Int32)); //BLGoodsDrCode
            //問発商品名
            serInfo.MemberInfo.Add(typeof(string)); //InqGoodsName
            //回答商品名
            serInfo.MemberInfo.Add(typeof(string)); //AnsGoodsName
            //発注数
            serInfo.MemberInfo.Add(typeof(Double)); //SalesOrderCount
            //納品数
            serInfo.MemberInfo.Add(typeof(Double)); //DeliveredGoodsCount
            //商品番号
            serInfo.MemberInfo.Add(typeof(string)); //GoodsNo
            //商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMakerCd
            //商品メーカー名称
            serInfo.MemberInfo.Add(typeof(string)); //GoodsMakerNm
            //純正商品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //PureGoodsMakerCd
            //問発純正商品番号
            serInfo.MemberInfo.Add(typeof(string)); //InqPureGoodsNo
            //回答純正商品番号
            serInfo.MemberInfo.Add(typeof(string)); //AnsPureGoodsNo
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
            //添付ファイル(明細)
            serInfo.MemberInfo.Add(typeof(Byte[])); //AppendingFileDtl
            //添付ファイル名(明細)
            serInfo.MemberInfo.Add(typeof(string)); //AppendingFileNmDtl
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
            //キャンペーンコード
            serInfo.MemberInfo.Add(typeof(Int32)); //CampaignCode
            //在庫区分
            serInfo.MemberInfo.Add(typeof(Int32)); //StockDiv
            //問合せ・発注種別
            serInfo.MemberInfo.Add(typeof(Int32)); //InqOrdDivCd
            //表示順位
            serInfo.MemberInfo.Add(typeof(Int32)); //DisplayOrder
            //商品管理番号
            serInfo.MemberInfo.Add(typeof(Int32)); //GoodsMngNo
            // 2010/05/26 Add >>>
            //キャンセル状態区分
            serInfo.MemberInfo.Add(typeof(Int16)); //CancelCndtinDiv
            // 2010/05/26 Add <<<
            // 2011/02/09 Add >>>
            //明細取込区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlTakeinDivCd
            // 2011/02/09 Add <<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SCMAcOdrDtlAsWork)
            {
                SCMAcOdrDtlAsWork temp = (SCMAcOdrDtlAsWork)graph;

                SetSCMAcOdrDtlAsWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SCMAcOdrDtlAsWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SCMAcOdrDtlAsWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SCMAcOdrDtlAsWork temp in lst)
                {
                    SetSCMAcOdrDtlAsWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SCMAcOdrDtlAsWorkメンバ数(publicプロパティ数)
        /// </summary>
        // 2011/02/09 >>>
        //// 2010/05/26 >>>
        ////private const int currentMemberCount = 60;
        //private const int currentMemberCount = 61;
        //// 2010/05/26 <<<
        private const int currentMemberCount = 62;
        // 2011/02/09 <<<

        /// <summary>
        ///  SCMAcOdrDtlAsWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetSCMAcOdrDtlAsWork(System.IO.BinaryWriter writer, SCMAcOdrDtlAsWork temp)
        {
            //作成日時
            writer.Write((Int64)temp.CreateDateTime.Ticks);
            //更新日時
            writer.Write((Int64)temp.UpdateDateTime.Ticks);
            //企業コード
            writer.Write(temp.EnterpriseCode);
            //GUID
            byte[] fileHeaderGuidArray = temp.FileHeaderGuid.ToByteArray();
            writer.Write(fileHeaderGuidArray.Length);
            writer.Write(temp.FileHeaderGuid.ToByteArray());
            //更新従業員コード
            writer.Write(temp.UpdEmployeeCode);
            //更新アセンブリID1
            writer.Write(temp.UpdAssemblyId1);
            //更新アセンブリID2
            writer.Write(temp.UpdAssemblyId2);
            //論理削除区分
            writer.Write(temp.LogicalDeleteCode);
            //問合せ元企業コード
            writer.Write(temp.InqOriginalEpCd);
            //問合せ元拠点コード
            writer.Write(temp.InqOriginalSecCd);
            //問合せ先企業コード
            writer.Write(temp.InqOtherEpCd);
            //問合せ先拠点コード
            writer.Write(temp.InqOtherSecCd);
            //問合せ番号
            writer.Write(temp.InquiryNumber);
            //更新年月日
            writer.Write((Int64)temp.UpdateDate.Ticks);
            //更新時間
            writer.Write(temp.UpdateTime);
            //問合せ行番号
            writer.Write(temp.InqRowNumber);
            //問合せ行番号枝番
            writer.Write(temp.InqRowNumDerivedNo);
            //問合せ元明細識別GUID
            byte[] inqOrgDtlDiscGuidArray = temp.InqOrgDtlDiscGuid.ToByteArray();
            writer.Write(inqOrgDtlDiscGuidArray.Length);
            writer.Write(temp.InqOrgDtlDiscGuid.ToByteArray());
            //問合せ先明細識別GUID
            byte[] inqOthDtlDiscGuidArray = temp.InqOthDtlDiscGuid.ToByteArray();
            writer.Write(inqOthDtlDiscGuidArray.Length);
            writer.Write(temp.InqOthDtlDiscGuid.ToByteArray());
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
            //回答納期
            writer.Write(temp.AnswerDeliveryDate);
            //BL商品コード
            writer.Write(temp.BLGoodsCode);
            //BL商品コード枝番
            writer.Write(temp.BLGoodsDrCode);
            //問発商品名
            writer.Write(temp.InqGoodsName);
            //回答商品名
            writer.Write(temp.AnsGoodsName);
            //発注数
            writer.Write(temp.SalesOrderCount);
            //納品数
            writer.Write(temp.DeliveredGoodsCount);
            //商品番号
            writer.Write(temp.GoodsNo);
            //商品メーカーコード
            writer.Write(temp.GoodsMakerCd);
            //商品メーカー名称
            writer.Write(temp.GoodsMakerNm);
            //純正商品メーカーコード
            writer.Write(temp.PureGoodsMakerCd);
            //問発純正商品番号
            writer.Write(temp.InqPureGoodsNo);
            //回答純正商品番号
            writer.Write(temp.AnsPureGoodsNo);
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
            writer.Write((Int64)temp.AnswerLimitDate.Ticks);
            //備考(明細)
            writer.Write(temp.CommentDtl);
            //添付ファイル(明細)
            writer.Write(temp.AppendingFileDtl.Length);
            writer.Write(temp.AppendingFileDtl);
            //添付ファイル名(明細)
            writer.Write(temp.AppendingFileNmDtl);
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
            //キャンペーンコード
            writer.Write(temp.CampaignCode);
            //在庫区分
            writer.Write(temp.StockDiv);
            //問合せ・発注種別
            writer.Write(temp.InqOrdDivCd);
            //表示順位
            writer.Write(temp.DisplayOrder);
            //商品管理番号
            writer.Write(temp.GoodsMngNo);
            // 2010/05/26 Add >>>
            //キャンセル状態区分
            writer.Write(temp.CancelCndtinDiv);
            // 2010/05/26 Add <<<
            // 2011/02/09 Add >>>
            //明細取込区分
            writer.Write(temp.DtlTakeinDivCd);
            // 2011/02/09 Add <<<
        }

        /// <summary>
        ///  SCMAcOdrDtlAsWorkインスタンス取得
        /// </summary>
        /// <returns>SCMAcOdrDtlAsWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private SCMAcOdrDtlAsWork GetSCMAcOdrDtlAsWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SCMAcOdrDtlAsWork temp = new SCMAcOdrDtlAsWork();

            //作成日時
            temp.CreateDateTime = new DateTime(reader.ReadInt64());
            //更新日時
            temp.UpdateDateTime = new DateTime(reader.ReadInt64());
            //企業コード
            temp.EnterpriseCode = reader.ReadString();
            //GUID
            int lenOfFileHeaderGuidArray = reader.ReadInt32();
            byte[] fileHeaderGuidArray = reader.ReadBytes(lenOfFileHeaderGuidArray);
            temp.FileHeaderGuid = new Guid(fileHeaderGuidArray);
            //更新従業員コード
            temp.UpdEmployeeCode = reader.ReadString();
            //更新アセンブリID1
            temp.UpdAssemblyId1 = reader.ReadString();
            //更新アセンブリID2
            temp.UpdAssemblyId2 = reader.ReadString();
            //論理削除区分
            temp.LogicalDeleteCode = reader.ReadInt32();
            //問合せ元企業コード
            temp.InqOriginalEpCd = reader.ReadString();
            //問合せ元拠点コード
            temp.InqOriginalSecCd = reader.ReadString();
            //問合せ先企業コード
            temp.InqOtherEpCd = reader.ReadString();
            //問合せ先拠点コード
            temp.InqOtherSecCd = reader.ReadString();
            //問合せ番号
            temp.InquiryNumber = reader.ReadInt64();
            //更新年月日
            temp.UpdateDate = new DateTime(reader.ReadInt64());
            //更新時間
            temp.UpdateTime = reader.ReadInt32();
            //問合せ行番号
            temp.InqRowNumber = reader.ReadInt32();
            //問合せ行番号枝番
            temp.InqRowNumDerivedNo = reader.ReadInt32();
            //問合せ元明細識別GUID
            int lenOfInqOrgDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOrgDtlDiscGuidArray = reader.ReadBytes(lenOfInqOrgDtlDiscGuidArray);
            temp.InqOrgDtlDiscGuid = new Guid(inqOrgDtlDiscGuidArray);
            //問合せ先明細識別GUID
            int lenOfInqOthDtlDiscGuidArray = reader.ReadInt32();
            byte[] inqOthDtlDiscGuidArray = reader.ReadBytes(lenOfInqOthDtlDiscGuidArray);
            temp.InqOthDtlDiscGuid = new Guid(inqOthDtlDiscGuidArray);
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
            //添付ファイル(明細)
            int appendingFileDtlLength = reader.ReadInt32();
            temp.AppendingFileDtl = reader.ReadBytes(appendingFileDtlLength);
            //添付ファイル名(明細)
            temp.AppendingFileNmDtl = reader.ReadString();
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
            //キャンペーンコード
            temp.CampaignCode = reader.ReadInt32();
            //在庫区分
            temp.StockDiv = reader.ReadInt32();
            //問合せ・発注種別
            temp.InqOrdDivCd = reader.ReadInt32();
            //表示順位
            temp.DisplayOrder = reader.ReadInt32();
            //商品管理番号
            temp.GoodsMngNo = reader.ReadInt32();
            // 2010/05/26 Add >>>
            //キャンセル状態区分
            temp.CancelCndtinDiv = reader.ReadInt16();
            // 2010/05/26 Add <<<
            // 2011/02/09 Add >>>
            //明細取込区分
            temp.DtlTakeinDivCd = reader.ReadInt32();
            // 2011/02/09 Add <<<

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
        /// <returns>SCMAcOdrDtlAsWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SCMAcOdrDtlAsWork temp = GetSCMAcOdrDtlAsWork(reader, serInfo);
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
                    retValue = (SCMAcOdrDtlAsWork[])lst.ToArray(typeof(SCMAcOdrDtlAsWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
    */
    # endregion

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SCMAcOdrDtlAsWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      :   2018/04/16  田建委</br>
    /// <br>                 :   管理番号 11470007-00</br>
    /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
    /// </remarks>
    public class SCMAcOdrDtlAsWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
	    #region ICustomSerializationSurrogate メンバ
    	
	    /// <summary>
	    ///  Ver5.10.1.0用のカスタムシリアライザです
	    /// </summary>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16  田建委</br>
        /// <br>                 :   管理番号 11470007-00</br>
        /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
	    /// </remarks>
	    public void Serialize(System.IO.BinaryWriter writer, object graph)
	    {
		    // TODO:  SCMAcOdrDtlAsWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
		    if(  writer == null )
			    throw new ArgumentNullException();

		    if( graph != null && !( graph is SCMAcOdrDtlAsWork || graph is ArrayList || graph is SCMAcOdrDtlAsWork[]) )
			    throw new ArgumentException( string.Format( "graphが{0}のインスタンスでありません", typeof(SCMAcOdrDtlAsWork).FullName ) );

		    if( graph != null && graph is SCMAcOdrDtlAsWork )
		    {
			    Type t = graph.GetType();
			    if( !CustomFormatterServices.NeedCustomSerialization( t ) )
				    throw new ArgumentException( string.Format( "graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName ) );
		    }

		    //SerializationTypeInfo
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo( ", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork" );

		    //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
		    int occurrence = 0;     //一般にゼロの場合もありえます
		    if( graph is ArrayList )
		    {
			    serInfo.RetTypeInfo = 0;
			    occurrence = ((ArrayList)graph).Count;
		    }else if( graph is SCMAcOdrDtlAsWork[] )
		    {
			    serInfo.RetTypeInfo = 2;
			    occurrence = ((SCMAcOdrDtlAsWork[])graph).Length;
		    }
		    else if( graph is SCMAcOdrDtlAsWork )
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
		    //更新年月日
		    serInfo.MemberInfo.Add( typeof(Int32) ); //UpdateDate
		    //更新時間
		    serInfo.MemberInfo.Add( typeof(Int32) ); //UpdateTime
		    //問合せ行番号
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InqRowNumber
		    //問合せ行番号枝番
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InqRowNumDerivedNo
		    //問合せ元明細識別GUID
		    serInfo.MemberInfo.Add( typeof(byte[]) );  //InqOrgDtlDiscGuid
		    //問合せ先明細識別GUID
		    serInfo.MemberInfo.Add( typeof(byte[]) );  //InqOthDtlDiscGuid
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
		    //添付ファイル(明細)
		    serInfo.MemberInfo.Add( typeof(Byte[]) ); //AppendingFileDtl
		    //添付ファイル名(明細)
		    serInfo.MemberInfo.Add( typeof(string) ); //AppendingFileNmDtl
		    //棚番
		    serInfo.MemberInfo.Add( typeof(string) ); //ShelfNo
		    //追加区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AdditionalDivCd
		    //訂正区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CorrectDivCD
		    //受注ステータス
		    serInfo.MemberInfo.Add( typeof(Int32) ); //AcptAnOdrStatus
		    //売上伝票番号
		    serInfo.MemberInfo.Add( typeof(string) ); //SalesSlipNum
		    //売上行番号
		    serInfo.MemberInfo.Add( typeof(Int32) ); //SalesRowNo
		    //キャンペーンコード
		    serInfo.MemberInfo.Add( typeof(Int32) ); //CampaignCode
		    //在庫区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //StockDiv
		    //問合せ・発注種別
		    serInfo.MemberInfo.Add( typeof(Int32) ); //InqOrdDivCd
		    //表示順位
		    serInfo.MemberInfo.Add( typeof(Int32) ); //DisplayOrder
		    //商品管理番号
		    serInfo.MemberInfo.Add( typeof(Int32) ); //GoodsMngNo
		    //キャンセル状態区分
		    serInfo.MemberInfo.Add( typeof(Int16) ); //CancelCndtinDiv
		    //明細取込区分
		    serInfo.MemberInfo.Add( typeof(Int32) ); //DtlTakeinDivCd
		    //倉庫コード
		    serInfo.MemberInfo.Add( typeof(string) ); //WarehouseCode
		    //倉庫名称
		    serInfo.MemberInfo.Add( typeof(string) ); //WarehouseName
		    //倉庫棚番
		    serInfo.MemberInfo.Add( typeof(string) ); //WarehouseShelfNo

            // -- ADD 2011/08/10   ------ >>>>>>
            //PM現在個数
            serInfo.MemberInfo.Add(typeof(Double)); //PmPrsntCount
            //セット部品メーカーコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SetPartsMkrCd
            //セット部品番号
            serInfo.MemberInfo.Add(typeof(string)); //SetPartsNumber
            //セット部品親子番号
            serInfo.MemberInfo.Add(typeof(Int32)); //SetPartsMainSubNo
            // -- ADD 2011/08/10   ------ <<<<<<
            // 2012/01/10 Add >>>
            // <summary>商品規格・特記事項</summary>
            serInfo.MemberInfo.Add(typeof(string)); //GoodsSpecialNote
            // 2012/01/10 Add <<<
            // 2012/04/12 Add >>>　
            // <summary>PS管理番号</summary>
            serInfo.MemberInfo.Add(typeof(Int32)); //PSMngNo
            // 2012/04/12 Add <<<
            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            // <summary>自動見積部品コード</summary>
            serInfo.MemberInfo.Add(typeof(string)); //AutoEstimatePartsCd
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<

            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 売上伝票合計（税込）
            serInfo.MemberInfo.Add(typeof(Int64)); // SalesTotalTaxInc 
            // 売上伝票合計（税抜）
            serInfo.MemberInfo.Add(typeof(Int64)); // SalesTotalTaxExc
            // SCM消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); // ScmConsTaxLayMethod
            // 消費税税率
            serInfo.MemberInfo.Add(typeof(Double)); // ConsTaxRate
            // SCM端数処理区分
            serInfo.MemberInfo.Add(typeof(Int32)); // ScmFractionProcCd
            // 売掛消費税
            serInfo.MemberInfo.Add(typeof(Int64)); // AccRecConsTax
            // PM売上日
            serInfo.MemberInfo.Add(typeof(Int32)); // PMSalesDate
            // 仕入先伝票発行時刻
            serInfo.MemberInfo.Add(typeof(Int32)); // SuppSlpPrtTime
            // 売上金額（税込み）
            serInfo.MemberInfo.Add(typeof(Int64)); // SalesMoneyTaxInc 
            // 売上金額（税抜き）
            serInfo.MemberInfo.Add(typeof(Int64)); // SalesMoneyTaxExc
            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // データ入力システム
            serInfo.MemberInfo.Add(typeof(Int32)); // DataInputSystem
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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

            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            //優良設定詳細コード２
            serInfo.MemberInfo.Add(typeof(Int32)); //PrmSetDtlNo2
            //優良設定詳細名称２
            serInfo.MemberInfo.Add(typeof(string)); //PrmSetDtlName2
            //優良設定詳細コード２
            serInfo.MemberInfo.Add(typeof(Int16)); //StockStatusDiv
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<

            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            //貸出区分
            serInfo.MemberInfo.Add(typeof(Int16)); //RentDiv
            //メーカー希望小売価格
            serInfo.MemberInfo.Add(typeof(Int64)); //MkrSuggestRtPric
            //オープン価格区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OpenPriceDiv
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

            // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
	        // お買得商品選択区分
            serInfo.MemberInfo.Add(typeof(Int16)); //BgnGoodsDiv
            // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<

            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
            //型式別部品採用年月
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelPrtsAdptYm
            //型式別部品廃止年月
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelPrtsAblsYm
            //型式別部品採用車台番号
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelPrtsAdptFrameNo
            //型式別部品廃止車台番号
            serInfo.MemberInfo.Add(typeof(Int32)); //ModelPrtsAblsFrameNo
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 回答納期区分
            serInfo.MemberInfo.Add(typeof(Int16)); // AnsDeliDateDiv
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
		    if( graph is SCMAcOdrDtlAsWork )
		    {
			    SCMAcOdrDtlAsWork temp = (SCMAcOdrDtlAsWork)graph;

			    SetSCMAcOdrDtlAsWork(writer, temp);
		    }
		    else
		    {
			    ArrayList lst= null;
			    if(graph is SCMAcOdrDtlAsWork[])
			    {
				    lst = new ArrayList();
				    lst.AddRange((SCMAcOdrDtlAsWork[])graph);
			    }
			    else
			    {
				    lst = (ArrayList)graph;	
			    }

			    foreach(SCMAcOdrDtlAsWork temp in lst)
			    {
				    SetSCMAcOdrDtlAsWork(writer, temp);
			    }

		    }

    		
	    }


	    /// <summary>
	    /// SCMAcOdrDtlAsWorkメンバ数(publicプロパティ数)
	    /// </summary>
        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        #region 旧ソース
        //// DEL 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //#region 旧ソース
        ////private const int currentMemberCount = 65; // DEL 2011/08/10
        //// 2012/01/10 UPD >>>
        ////private const int currentMemberCount = 69; // ADD 2011/08/10
        ////private const int currentMemberCount = 70; // 2012/04/12 DEL  
        //// 2012/01/10 UPD <<<
        ////private const int currentMemberCount = 71; // 2012/04/12 ADD //DEL 2012/05/30
        ////// UPD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        ////// private const int currentMemberCount = 72;  //ADD 2012/05/30
        ////// 他の案件と修正が被る。当案件の対応で、10件の追加。
        ////private const int currentMemberCount = 82;
        ////// UPD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //#endregion
        //// DEL 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //// ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        //// 他の案件と修正が被る。当案件の対応で、№10308,№10528で10件の追加、№10410で1件の追加
        ////private const int currentMemberCount = 83;    // DEL 2013/02/27 qijh #34752
        //// DEL 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
        ////private const int currentMemberCount = 87;      // ADD 2013/02/27 qijh #34752
        //// DEL 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
        //// ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        //// ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
        //// UPD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
        ////private const int currentMemberCount = 90;
        //// UPD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<
        ////private const int currentMemberCount = 93;
        //// UPD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
        ////private const int currentMemberCount = 94;
        //private const int currentMemberCount = 98;
        //// UPD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<
        //// UPD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
        //// UPD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<
        //// ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
        #endregion
        //private const int currentMemberCount = 99;    // DEL 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応
        //private const int currentMemberCount = 103;     // ADD 2015/02/20 下口 SCM高速化 Ｃ向け種別特記対応// DEL 2018/04/16 田建委 新BLコード対応
        private const int currentMemberCount = 109;// ADD 2018/04/16 田建委 新BLコード対応
        // UPD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
    		
	    /// <summary>
	    ///  SCMAcOdrDtlAsWorkインスタンス書き込み
	    /// </summary>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16  田建委</br>
        /// <br>                 :   管理番号 11470007-00</br>
        /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
	    /// </remarks>
	    private void SetSCMAcOdrDtlAsWork( System.IO.BinaryWriter writer, SCMAcOdrDtlAsWork temp )
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
		    //更新年月日
		    writer.Write( (Int64)temp.UpdateDate.Ticks );
		    //更新時間
		    writer.Write( temp.UpdateTime );
		    //問合せ行番号
		    writer.Write( temp.InqRowNumber );
		    //問合せ行番号枝番
		    writer.Write( temp.InqRowNumDerivedNo );
		    //問合せ元明細識別GUID
		    byte[] inqOrgDtlDiscGuidArray = temp.InqOrgDtlDiscGuid.ToByteArray();
		    writer.Write( inqOrgDtlDiscGuidArray.Length );
		    writer.Write( temp.InqOrgDtlDiscGuid.ToByteArray() );
		    //問合せ先明細識別GUID
		    byte[] inqOthDtlDiscGuidArray = temp.InqOthDtlDiscGuid.ToByteArray();
		    writer.Write( inqOthDtlDiscGuidArray.Length );
		    writer.Write( temp.InqOthDtlDiscGuid.ToByteArray() );
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
		    writer.Write( (Int64)temp.DeliGdsCmpltDueDate.Ticks );
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
		    writer.Write( (Int64)temp.AnswerLimitDate.Ticks );
		    //備考(明細)
		    writer.Write( temp.CommentDtl );
		    //添付ファイル(明細)
            writer.Write( temp.AppendingFileDtl.Length );
            writer.Write( temp.AppendingFileDtl );
		    //添付ファイル名(明細)
		    writer.Write( temp.AppendingFileNmDtl );
		    //棚番
		    writer.Write( temp.ShelfNo );
		    //追加区分
		    writer.Write( temp.AdditionalDivCd );
		    //訂正区分
		    writer.Write( temp.CorrectDivCD );
		    //受注ステータス
		    writer.Write( temp.AcptAnOdrStatus );
		    //売上伝票番号
		    writer.Write( temp.SalesSlipNum );
		    //売上行番号
		    writer.Write( temp.SalesRowNo );
		    //キャンペーンコード
		    writer.Write( temp.CampaignCode );
		    //在庫区分
		    writer.Write( temp.StockDiv );
		    //問合せ・発注種別
		    writer.Write( temp.InqOrdDivCd );
		    //表示順位
		    writer.Write( temp.DisplayOrder );
		    //商品管理番号
		    writer.Write( temp.GoodsMngNo );
		    //キャンセル状態区分
		    writer.Write( temp.CancelCndtinDiv );
		    //明細取込区分
		    writer.Write( temp.DtlTakeinDivCd );
		    //倉庫コード
		    writer.Write( temp.WarehouseCode );
		    //倉庫名称
		    writer.Write( temp.WarehouseName );
		    //倉庫棚番
		    writer.Write( temp.WarehouseShelfNo );

            // -- ADD 2011/08/10   ------ >>>>>>
            //PM現在個数
            writer.Write(temp.PmPrsntCount);
            //セット部品メーカーコード
            writer.Write(temp.SetPartsMkrCd);
            //セット部品番号
            writer.Write(temp.SetPartsNumber);
            //セット部品親子番号
            writer.Write(temp.SetPartsMainSubNo);
            // -- ADD 2011/08/10   ------ <<<<<<
            // 2012/01/10 ADD >>>
            //商品規格・特記事項
            writer.Write(temp.GoodsSpecialNote);
            // 2012/01/10 ADD <<<
            // 2012/04/12 ADD >>> 
            //PS管理番号
            writer.Write(temp.PSMngNo);
            // 2012/04/12 ADD <<<
            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            //自動見積部品コード
            writer.Write(temp.AutoEstimatePartsCd);
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<

            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 売上伝票合計（税込）
            writer.Write(temp.SalesTotalTaxInc);
            // 売上伝票合計（税抜）
            writer.Write(temp.SalesTotalTaxExc);
            // SCM消費税転嫁方式
            writer.Write(temp.ScmConsTaxLayMethod);
            // 消費税税率
            writer.Write(temp.ConsTaxRate);
            // SCM端数処理区分
            writer.Write(temp.ScmFractionProcCd);
            // 売掛消費税を取得または設定します。
            writer.Write(temp.AccRecConsTax);
            // PM売上日を取得または設定します。
            writer.Write(temp.PMSalesDate);
            // 仕入先伝票発行時刻を取得または設定します。
            writer.Write(temp.SuppSlpPrtTime);
            // 売上金額（税込み）
            writer.Write(temp.SalesMoneyTaxInc);
            // 売上金額（税抜き）
            writer.Write(temp.SalesMoneyTaxExc);
            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // データ入力システム
            writer.Write(temp.DataInputSystem);
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            // 優良設定詳細コード２
            writer.Write(temp.PrmSetDtlNo2);
            // 優良設定詳細名称２
            writer.Write(temp.PrmSetDtlName2);
            // 在庫状況区分
            writer.Write(temp.StockStatusDiv);
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<

            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            // 貸出区分
            writer.Write(temp.RentDiv);
            // メーカー希望小売価格
            writer.Write(temp.MkrSuggestRtPric);
            // オープン価格区分
            writer.Write(temp.OpenPriceDiv);
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

            // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
	        // お買得商品選択区分
            writer.Write(temp.BgnGoodsDiv);
            // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<

            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
            // 型式別部品採用年月
            writer.Write(temp.ModelPrtsAdptYm);
            // 型式別部品廃止年月
            writer.Write(temp.ModelPrtsAblsYm);
            // 型式別部品採用車台番号
            writer.Write(temp.ModelPrtsAdptFrameNo);
            // 型式別部品廃止車台番号
            writer.Write(temp.ModelPrtsAblsFrameNo);
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 回答納期区分
            writer.Write(temp.AnsDeliDateDiv);
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
	    ///  SCMAcOdrDtlAsWorkインスタンス取得
	    /// </summary>
	    /// <returns>SCMAcOdrDtlAsWorkクラスのインスタンス</returns>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2018/04/16  田建委</br>
        /// <br>                 :   管理番号 11470007-00</br>
        /// <br>                 :   問発BL統一部品コード(スリーコード版)、問発BL統一部品サブコード、回答BL統一部品コード(スリーコード版)、回答BL統一部品サブコード、回答BL商品コード、回答BL商品コード枝番の追加</br>
	    /// </remarks>
	    private SCMAcOdrDtlAsWork GetSCMAcOdrDtlAsWork( System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo )
	    {
		    // V5.1.0.0なので不要ですが、V5.1.0.1以降では
		    // serInfo.MemberInfo.Count < currentMemberCount
		    // のケースについての配慮が必要になります。

		    SCMAcOdrDtlAsWork temp = new SCMAcOdrDtlAsWork();

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
		    //更新年月日
		    temp.UpdateDate = new DateTime(reader.ReadInt64());
		    //更新時間
		    temp.UpdateTime = reader.ReadInt32();
		    //問合せ行番号
		    temp.InqRowNumber = reader.ReadInt32();
		    //問合せ行番号枝番
		    temp.InqRowNumDerivedNo = reader.ReadInt32();
		    //問合せ元明細識別GUID
		    int lenOfInqOrgDtlDiscGuidArray = reader.ReadInt32();
		    byte[] inqOrgDtlDiscGuidArray = reader.ReadBytes(lenOfInqOrgDtlDiscGuidArray);
		    temp.InqOrgDtlDiscGuid = new Guid( inqOrgDtlDiscGuidArray );
		    //問合せ先明細識別GUID
		    int lenOfInqOthDtlDiscGuidArray = reader.ReadInt32();
		    byte[] inqOthDtlDiscGuidArray = reader.ReadBytes(lenOfInqOthDtlDiscGuidArray);
		    temp.InqOthDtlDiscGuid = new Guid( inqOthDtlDiscGuidArray );
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
		    //添付ファイル(明細)
		    int appendingFileDtlLength = reader.ReadInt32();
            temp.AppendingFileDtl = reader.ReadBytes(appendingFileDtlLength);
		    //添付ファイル名(明細)
		    temp.AppendingFileNmDtl = reader.ReadString();
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
		    //キャンペーンコード
		    temp.CampaignCode = reader.ReadInt32();
		    //在庫区分
		    temp.StockDiv = reader.ReadInt32();
		    //問合せ・発注種別
		    temp.InqOrdDivCd = reader.ReadInt32();
		    //表示順位
		    temp.DisplayOrder = reader.ReadInt32();
		    //商品管理番号
		    temp.GoodsMngNo = reader.ReadInt32();
		    //キャンセル状態区分
		    temp.CancelCndtinDiv = reader.ReadInt16();
		    //明細取込区分
		    temp.DtlTakeinDivCd = reader.ReadInt32();
		    //倉庫コード
		    temp.WarehouseCode = reader.ReadString();
		    //倉庫名称
		    temp.WarehouseName = reader.ReadString();
		    //倉庫棚番
		    temp.WarehouseShelfNo = reader.ReadString();

            // -- ADD 2011/08/10   ------ >>>>>>
            //PM現在個数
            temp.PmPrsntCount = reader.ReadDouble();
            //セット部品メーカーコード
            temp.SetPartsMkrCd = reader.ReadInt32();
            //セット部品番号
            temp.SetPartsNumber = reader.ReadString();
            //セット部品親子番号
            temp.SetPartsMainSubNo = reader.ReadInt32();
            // -- ADD 2011/08/10   ------ <<<<<<
            // 2012/01/10 ADD >>>
            //商品規格・特記事項
            temp.GoodsSpecialNote = reader.ReadString();
            // 2012/01/10 ADD <<<
            // 2012/04/12 ADD >>> 
            //PS管理番号
            temp.PSMngNo = reader.ReadInt32();
            // 2012/04/12 ADD <<<
            // --- ADD T.Nishi 2012/05/30 ---------->>>>>
            //自動見積部品コード
            temp.AutoEstimatePartsCd = reader.ReadString();
            // --- ADD T.Nishi 2012/05/30 ----------<<<<<
            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 売上伝票合計（税込）
            temp.SalesTotalTaxInc = reader.ReadInt64();
            // 売上伝票合計（税抜）
            temp.SalesTotalTaxExc = reader.ReadInt64();
            // SCM消費税転嫁方式
            temp.ScmConsTaxLayMethod = reader.ReadInt32();
            // 消費税税率
            temp.ConsTaxRate = reader.ReadDouble();
            // SCM端数処理区分
            temp.ScmFractionProcCd = reader.ReadInt32();
            // 売掛消費税
            temp.AccRecConsTax = reader.ReadInt64();
            // PM売上日
            temp.PMSalesDate = reader.ReadInt32();
            // 仕入先伝票発行時刻
            temp.SuppSlpPrtTime = reader.ReadInt32();
            // 売上金額（税込み）
            temp.SalesMoneyTaxInc = reader.ReadInt64();
            // 売上金額（税抜き）
            temp.SalesMoneyTaxExc = reader.ReadInt64();
            // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // データ入力システム
            temp.DataInputSystem = reader.ReadInt32();
            // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
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

            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
            // 優良設定詳細コード２
            temp.PrmSetDtlNo2 = reader.ReadInt32();
            // 優良設定詳細名称２
            temp.PrmSetDtlName2 = reader.ReadString();
            // 在庫状況区分
            temp.StockStatusDiv = reader.ReadInt16();
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<

            // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
            // 貸出区分
            temp.RentDiv = reader.ReadInt16();
            // メーカー希望小売価格
            temp.MkrSuggestRtPric = reader.ReadInt64();
            // オープン価格区分
            temp.OpenPriceDiv = reader.ReadInt32();
            // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

            // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
            // お買得商品選択区分
            temp.BgnGoodsDiv = reader.ReadInt16();
            // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<

            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
            // 型式別部品採用年月
            temp.ModelPrtsAdptYm = reader.ReadInt32();
            // 型式別部品廃止年月
            temp.ModelPrtsAblsYm = reader.ReadInt32();
            // 型式別部品採用車台番号
            temp.ModelPrtsAdptFrameNo = reader.ReadInt32();
            // 型式別部品廃止車台番号
            temp.ModelPrtsAblsFrameNo = reader.ReadInt32();
            // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
            // 回答納期区分
            temp.AnsDeliDateDiv = reader.ReadInt16();
            // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

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
	    /// <returns>SCMAcOdrDtlAsWorkクラスのインスタンス(object)</returns>
	    /// <remarks>
	    /// <br>Note　　　　　　 :   SCMAcOdrDtlAsWorkクラスのカスタムデシリアライザを定義します</br>
	    /// <br>Programer        :   自動生成</br>
	    /// </remarks>
	    public object Deserialize(System.IO.BinaryReader reader)
	    {
		    object retValue = null;
		    Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject( reader );
		    ArrayList lst = new ArrayList();
		    for( int cnt = 0 ; cnt < serInfo.Occurrence ; ++cnt )
		    {
			    SCMAcOdrDtlAsWork temp = GetSCMAcOdrDtlAsWork( reader, serInfo );
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
				    retValue = (SCMAcOdrDtlAsWork[])lst.ToArray(typeof(SCMAcOdrDtlAsWork));
				    break;
		    }
		    return retValue;
	    }

	    #endregion
    }
}
