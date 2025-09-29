using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
   /// public class name:   DmdPrtPtn
	/// <summary>
	///                      請求書印刷パターンマスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   請求書印刷パターンマスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   </br>
	/// <br>Genarated Date   :   2007/07/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   20081 疋田 勇人</br>
    /// <br>Update Note      :   2007.09.18 DC.NS用に変更</br>
    /// <br>UpdateNote       :   2008/06/13 30415 柴田 倫幸</br>
    /// <br>        	         ・データ項目の追加/削除による修正</br>   
    /// <br>UpdateNote       :   2009/04/03 30413 犬飼 項目追加</br>
    /// <br>UpdateNote       :   2010/02/18 30531 大矢 睦美</br>
    /// <br>                 :   注釈印字区分追加</br>
    /// <br>UpdateNote       :   2011/02/16  施ヘイ中</br>
    /// <br>                 :   自社名印字区分を追加</br>
    /// </remarks>
	public class DmdPrtPtn
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

		/// <summary>更新アセンブリID1</summary>
		/// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
		private string _updAssemblyId2 = "";

		/// <summary>論理削除区分</summary>
		/// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
		private Int32 _logicalDeleteCode;

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// <summary>請求書パターン番号</summary>
		private Int32 _demandPtnNo;

		/// <summary>請求書パターン番号名称</summary>
		private string _demandPtnNoNm = "";
           --- DEL 2008/06/13 --------------------------------<<<<< */
        
        /// <summary>請求 鑑タイトル１</summary>
		private string _dmdTtlFormTitle1 = "";

		/// <summary>請求 鑑タイトル２</summary>
		private string _dmdTtlFormTitle2 = "";

		/// <summary>請求 鑑タイトル３</summary>
		private string _dmdTtlFormTitle3 = "";

		/// <summary>請求 鑑タイトル４</summary>
		private string _dmdTtlFormTitle4 = "";

		/// <summary>請求 鑑タイトル５</summary>
		private string _dmdTtlFormTitle5 = "";

		/// <summary>請求 鑑タイトル６</summary>
		private string _dmdTtlFormTitle6 = "";

		/// <summary>請求 鑑タイトル７</summary>
		private string _dmdTtlFormTitle7 = "";

		/// <summary>請求 鑑タイトル８</summary>
		private string _dmdTtlFormTitle8 = "";
        
        /// <summary>請求 鑑設定項目区分１</summary>
		private Int32 _dmdTtlSetItemDiv1;

		/// <summary>請求 鑑設定項目区分２</summary>
		private Int32 _dmdTtlSetItemDiv2;

		/// <summary>請求 鑑設定項目区分３</summary>
		private Int32 _dmdTtlSetItemDiv3;

		/// <summary>請求 鑑設定項目区分４</summary>
		private Int32 _dmdTtlSetItemDiv4;

		/// <summary>請求 鑑設定項目区分５</summary>
		private Int32 _dmdTtlSetItemDiv5;

		/// <summary>請求 鑑設定項目区分６</summary>
		private Int32 _dmdTtlSetItemDiv6;

		/// <summary>請求 鑑設定項目区分７</summary>
		private Int32 _dmdTtlSetItemDiv7;

		/// <summary>請求 鑑設定項目区分８</summary>
		private Int32 _dmdTtlSetItemDiv8;

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// <summary>支払 鑑タイトル１</summary>
		private string _payTtlFormTitle1 = "";

		/// <summary>支払 鑑タイトル２</summary>
		private string _payTtlFormTitle2 = "";

		/// <summary>支払 鑑タイトル３</summary>
		private string _payTtlFormTitle3 = "";

		/// <summary>支払 鑑タイトル４</summary>
		private string _payTtlFormTitle4 = "";

		/// <summary>支払 鑑タイトル５</summary>
		private string _payTtlFormTitle5 = "";

		/// <summary>支払 鑑タイトル６</summary>
		private string _payTtlFormTitle6 = "";

		/// <summary>支払 鑑タイトル７</summary>
		private string _payTtlFormTitle7 = "";

		/// <summary>支払 鑑タイトル８</summary>
		private string _payTtlFormTitle8 = "";
           --- DEL 2008/06/13 --------------------------------<<<<< */

		/// <summary>請求書タイトル</summary>
		private string _dmdFormTitle = "";

		/// <summary>支払通知書タイトル</summary>
		//private string _paymentFormTitle = "";  // DEL 2008/06/13

		/// <summary>請求書コメント１</summary>
		private string _dmdFormComent1 = "";

		/// <summary>請求書コメント２</summary>
		private string _dmdFormComent2 = "";

		/// <summary>請求書コメント３</summary>
		private string _dmdFormComent3 = "";

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// <summary>請求書請求集計分類１</summary>
		private Int32 _dmdFmDmdTtlGenCd1;

		/// <summary>請求書請求集計分類２</summary>
		private Int32 _dmdFmDmdTtlGenCd2;

		/// <summary>請求書請求集計分類３</summary>
		private Int32 _dmdFmDmdTtlGenCd3;

		/// <summary>請求書支払集計分類１</summary>
		private Int32 _dmdFmPayTtlGenCd1;

		/// <summary>請求書支払集計分類２</summary>
		private Int32 _dmdFmPayTtlGenCd2;

		/// <summary>請求書支払集計分類３</summary>
		private Int32 _dmdFmPayTtlGenCd3;

		/// <summary>請求書請求集計分類名称２</summary>
		private string _dmdFmDmdTtlGenNm2 = "";

		/// <summary>請求書請求集計分類名称３</summary>
		/// <remarks>明細金額ゼロ時印字有無</remarks>
		private string _dmdFmDmdTtlGenNm3 = "";

		/// <summary>請求集計分類デフォルト名称</summary>
		private string _dmdTtlGenDefltNm = "";

		/// <summary>支払集計分類デフォルト名称</summary>
		private string _payTtlGenDefltNm = "";

		/// <summary>請求明細単価別出力有無</summary>
		/// <remarks>0:単価印字する 1:単価印字しない</remarks>
		private Int32 _dmdDtlUnitPrtDiv;

		/// <summary>支払明細単価別出力有無</summary>
		/// <remarks>0:単価印字する 1:単価印字しない</remarks>
		private Int32 _payDtlUnitPrtDiv;

		/// <summary>今回請求額ゼロ時印字有無</summary>
		/// <remarks>0:印字する 1:印字しない</remarks>
		private Int32 _thTmDmdZeroPrtDiv;

		/// <summary>請求明細金額ゼロ時印字有無</summary>
		/// <remarks>0:印字する 1:全て0のみ印字しない 2:相殺額が0の時印字しない</remarks>
		private Int32 _dmdDtlPrcZeroPrtDiv;

		/// <summary>支払明細金額ゼロ時印字有無</summary>
		/// <remarks>0:印字する 1:印字しない</remarks>
		private Int32 _payDtlPrcZeroPrtDiv;

		/// <summary>マイナス請求時印刷区分</summary>
		/// <remarks>0:支払通知書とする 1:マイナス請求書とする</remarks>
		private Int32 _minusDmdPrtDiv;
           --- DEL 2008/06/13 --------------------------------<<<<< */
        
        /// <summary>請求書入金集計明細印字区分</summary>
		/// <remarks>0:印字する 1:印字しない</remarks>
		private Int32 _dmdFmDepoTtlPrtDiv;

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// <summary>強制請求出力商品区分１</summary>
		private string _cmplDmdMdGoodsCd1 = "";

		/// <summary>強制請求出力商品区分２</summary>
		private string _cmplDmdMdGoodsCd2 = "";

		/// <summary>強制請求出力商品区分３</summary>
		private string _cmplDmdMdGoodsCd3 = "";

		/// <summary>強制請求出力商品区分４</summary>
		private string _cmplDmdMdGoodsCd4 = "";

		/// <summary>強制請求出力商品区分５</summary>
		private string _cmplDmdMdGoodsCd5 = "";

		/// <summary>強制請求出力商品区分６</summary>
		private string _cmplDmdMdGoodsCd6 = "";

		/// <summary>強制請求出力商品区分７</summary>
		private string _cmplDmdMdGoodsCd7 = "";

		/// <summary>強制請求出力商品区分８</summary>
		private string _cmplDmdMdGoodsCd8 = "";

		/// <summary>強制請求出力商品区分９</summary>
		private string _cmplDmdMdGoodsCd9 = "";

		/// <summary>強制請求出力商品区分１０</summary>
		private string _cmplDmdMdGoodsCd10 = "";

		/// <summary>強制支払出力商品区分１</summary>
		private string _cmplPayMdGoodsCd1 = "";

		/// <summary>強制支払出力商品区分２</summary>
		private string _cmplPayMdGoodsCd2 = "";

		/// <summary>強制支払出力商品区分３</summary>
		private string _cmplPayMdGoodsCd3 = "";

		/// <summary>強制支払出力商品区分４</summary>
		private string _cmplPayMdGoodsCd4 = "";

		/// <summary>強制支払出力商品区分５</summary>
		private string _cmplPayMdGoodsCd5 = "";

		/// <summary>強制支払出力商品区分６</summary>
		private string _cmplPayMdGoodsCd6 = "";

		/// <summary>強制支払出力商品区分７</summary>
		private string _cmplPayMdGoodsCd7 = "";

		/// <summary>強制支払出力商品区分８</summary>
		private string _cmplPayMdGoodsCd8 = "";

		/// <summary>強制支払出力商品区分９</summary>
		private string _cmplPayMdGoodsCd9 = "";

		/// <summary>強制支払出力商品区分１０</summary>
		private string _cmplPayMdGoodsCd10 = "";
           --- DEL 2008/06/13 --------------------------------<<<<< */

        // --- ADD 2008/06/13 -------------------------------->>>>>
        /// <summary>データ入力システム</summary>
        private Int32 _dataInputSystem;

        /// <summary>伝票印刷種別</summary>
        private Int32 _slipPrtKind;

        /// <summary>伝票印刷設定用帳票ID</summary>
        private string _slipPrtSetPaperId = "";

        /// <summary>伝票コメント</summary>
        private string _slipComment = "";

        /// <summary>出力ファイル名</summary>
        private string _outputFormFileName = "";

        /// <summary>上余白</summary>
        private Double _topMargin;

        /// <summary>左余白</summary>
        private Double _leftMargin;

        /// <summary>右余白</summary>
        private Double _rightMargin;

        /// <summary>下余白</summary>
        private Double _bottomMargin;

        /// <summary>複写枚数</summary>
        private Int32 _copyCount;

        /// <summary>請求書タイトル２</summary>
        private string _dmdFormTitle2 = "";

        /// <summary>請求明細摘要区分</summary>
        private Int32 _dmdDtlOutlineCode;

        /// <summary>請求明細書印字順位区分</summary>
        private Int32 _dmdDtlPtnOdrDiv;

        /// <summary>伝票計印字有無</summary>
        private Int32 _slipTtlPrtDiv;

        /// <summary>計上日計印字有無</summary>
        private Int32 _addDayTtlPrtDiv;

        /// <summary>得意先計印字有無</summary>
        private Int32 _customerTtlPrtDiv;

        /// <summary>明細金額ゼロ時印字有無</summary>
        private Int32 _dtlPrcZeroPrtDiv;

        /// <summary>入金明細印字有無区分</summary>
        private Int32 _depoDtlPrcPrtDiv;

        /// <summary>請求書敬称</summary>
        private string _billHonorificTtl = "";
        // --- ADD 2008/06/13 --------------------------------<<<<< 

        /// <summary>標準価格印字区分</summary>
        private Int32 _listPricePrtCd;

        /// <summary>品番印字区分</summary>
        private Int32 _partsNoPrtCd;

        /// <summary>機種別インセンティブ出力区分</summary>
		/// <remarks>0:集計印字 1:機種別印字</remarks>
		// private Int32 _cellphoneIncOutDiv;   // 2007.09.18 hikita del

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

        // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
        /// <summary>注釈印字区分</summary>
        /// <remarks>0:印字する,1:印字しない</remarks>
        private Int32 _annotationPrtCd;
        // --- ADD  大矢睦美  2010/02/18 ----------<<<<<


        // --- ADD  2011/02/16 ---------->>>>>
        /// <summary>自社名印字区分</summary>
        private Int32 _coNmPrintOutCd;
        // --- ADD  2011/02/16 ----------<<<<<

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
		/// <summary>更新アセンブリID1プロパティ</summary>
		/// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   更新アセンブリID1プロパティ</br>
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

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// public propaty name  :  DemandPtnNo
		/// <summary>請求書パターン番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書パターン番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DemandPtnNo
		{
			get{return _demandPtnNo;}
			set{_demandPtnNo = value;}
		}

		/// public propaty name  :  DemandPtnNoNm
		/// <summary>請求書パターン番号名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書パターン番号名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DemandPtnNoNm
		{
			get{return _demandPtnNoNm;}
			set{_demandPtnNoNm = value;}
		}
           --- DEL 2008/06/13 --------------------------------<<<<< */
        
        /// public propaty name  :  DmdTtlFormTitle1
		/// <summary>請求 鑑タイトル１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑タイトル１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdTtlFormTitle1
		{
			get{return _dmdTtlFormTitle1;}
			set{_dmdTtlFormTitle1 = value;}
		}

		/// public propaty name  :  DmdTtlFormTitle2
		/// <summary>請求 鑑タイトル２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑タイトル２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdTtlFormTitle2
		{
			get{return _dmdTtlFormTitle2;}
			set{_dmdTtlFormTitle2 = value;}
		}

		/// public propaty name  :  DmdTtlFormTitle3
		/// <summary>請求 鑑タイトル３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑タイトル３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdTtlFormTitle3
		{
			get{return _dmdTtlFormTitle3;}
			set{_dmdTtlFormTitle3 = value;}
		}

		/// public propaty name  :  DmdTtlFormTitle4
		/// <summary>請求 鑑タイトル４プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑タイトル４プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdTtlFormTitle4
		{
			get{return _dmdTtlFormTitle4;}
			set{_dmdTtlFormTitle4 = value;}
		}

		/// public propaty name  :  DmdTtlFormTitle5
		/// <summary>請求 鑑タイトル５プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑タイトル５プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdTtlFormTitle5
		{
			get{return _dmdTtlFormTitle5;}
			set{_dmdTtlFormTitle5 = value;}
		}

		/// public propaty name  :  DmdTtlFormTitle6
		/// <summary>請求 鑑タイトル６プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑タイトル６プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdTtlFormTitle6
		{
			get{return _dmdTtlFormTitle6;}
			set{_dmdTtlFormTitle6 = value;}
		}

		/// public propaty name  :  DmdTtlFormTitle7
		/// <summary>請求 鑑タイトル７プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑タイトル７プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdTtlFormTitle7
		{
			get{return _dmdTtlFormTitle7;}
			set{_dmdTtlFormTitle7 = value;}
		}

		/// public propaty name  :  DmdTtlFormTitle8
		/// <summary>請求 鑑タイトル８プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑タイトル８プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdTtlFormTitle8
		{
			get{return _dmdTtlFormTitle8;}
			set{_dmdTtlFormTitle8 = value;}
		}

		/// public propaty name  :  DmdTtlSetItemDiv1
		/// <summary>請求 鑑設定項目区分１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑設定項目区分１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdTtlSetItemDiv1
		{
			get{return _dmdTtlSetItemDiv1;}
			set{_dmdTtlSetItemDiv1 = value;}
		}

		/// public propaty name  :  DmdTtlSetItemDiv2
		/// <summary>請求 鑑設定項目区分２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑設定項目区分２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdTtlSetItemDiv2
		{
			get{return _dmdTtlSetItemDiv2;}
			set{_dmdTtlSetItemDiv2 = value;}
		}

		/// public propaty name  :  DmdTtlSetItemDiv3
		/// <summary>請求 鑑設定項目区分３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑設定項目区分３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdTtlSetItemDiv3
		{
			get{return _dmdTtlSetItemDiv3;}
			set{_dmdTtlSetItemDiv3 = value;}
		}

		/// public propaty name  :  DmdTtlSetItemDiv4
		/// <summary>請求 鑑設定項目区分４プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑設定項目区分４プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdTtlSetItemDiv4
		{
			get{return _dmdTtlSetItemDiv4;}
			set{_dmdTtlSetItemDiv4 = value;}
		}

		/// public propaty name  :  DmdTtlSetItemDiv5
		/// <summary>請求 鑑設定項目区分５プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑設定項目区分５プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdTtlSetItemDiv5
		{
			get{return _dmdTtlSetItemDiv5;}
			set{_dmdTtlSetItemDiv5 = value;}
		}

		/// public propaty name  :  DmdTtlSetItemDiv6
		/// <summary>請求 鑑設定項目区分６プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑設定項目区分６プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdTtlSetItemDiv6
		{
			get{return _dmdTtlSetItemDiv6;}
			set{_dmdTtlSetItemDiv6 = value;}
		}

		/// public propaty name  :  DmdTtlSetItemDiv7
		/// <summary>請求 鑑設定項目区分７プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑設定項目区分７プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdTtlSetItemDiv7
		{
			get{return _dmdTtlSetItemDiv7;}
			set{_dmdTtlSetItemDiv7 = value;}
		}

		/// public propaty name  :  DmdTtlSetItemDiv8
		/// <summary>請求 鑑設定項目区分８プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求 鑑設定項目区分８プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdTtlSetItemDiv8
		{
			get{return _dmdTtlSetItemDiv8;}
			set{_dmdTtlSetItemDiv8 = value;}
		}

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// public propaty name  :  PayTtlFormTitle1
		/// <summary>支払 鑑タイトル１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払 鑑タイトル１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayTtlFormTitle1
		{
			get{return _payTtlFormTitle1;}
			set{_payTtlFormTitle1 = value;}
		}

		/// public propaty name  :  PayTtlFormTitle2
		/// <summary>支払 鑑タイトル２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払 鑑タイトル２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayTtlFormTitle2
		{
			get{return _payTtlFormTitle2;}
			set{_payTtlFormTitle2 = value;}
		}

		/// public propaty name  :  PayTtlFormTitle3
		/// <summary>支払 鑑タイトル３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払 鑑タイトル３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayTtlFormTitle3
		{
			get{return _payTtlFormTitle3;}
			set{_payTtlFormTitle3 = value;}
		}

		/// public propaty name  :  PayTtlFormTitle4
		/// <summary>支払 鑑タイトル４プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払 鑑タイトル４プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayTtlFormTitle4
		{
			get{return _payTtlFormTitle4;}
			set{_payTtlFormTitle4 = value;}
		}

		/// public propaty name  :  PayTtlFormTitle5
		/// <summary>支払 鑑タイトル５プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払 鑑タイトル５プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayTtlFormTitle5
		{
			get{return _payTtlFormTitle5;}
			set{_payTtlFormTitle5 = value;}
		}

		/// public propaty name  :  PayTtlFormTitle6
		/// <summary>支払 鑑タイトル６プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払 鑑タイトル６プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayTtlFormTitle6
		{
			get{return _payTtlFormTitle6;}
			set{_payTtlFormTitle6 = value;}
		}

		/// public propaty name  :  PayTtlFormTitle7
		/// <summary>支払 鑑タイトル７プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払 鑑タイトル７プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayTtlFormTitle7
		{
			get{return _payTtlFormTitle7;}
			set{_payTtlFormTitle7 = value;}
		}

		/// public propaty name  :  PayTtlFormTitle8
		/// <summary>支払 鑑タイトル８プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払 鑑タイトル８プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayTtlFormTitle8
		{
			get{return _payTtlFormTitle8;}
			set{_payTtlFormTitle8 = value;}
		}
           --- DEL 2008/06/13 --------------------------------<<<<< */

		/// public propaty name  :  DmdFormTitle
		/// <summary>請求書タイトルプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書タイトルプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdFormTitle
		{
			get{return _dmdFormTitle;}
			set{_dmdFormTitle = value;}
		}

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// public propaty name  :  PaymentFormTitle
		/// <summary>支払通知書タイトルプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払通知書タイトルプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PaymentFormTitle
		{
			get{return _paymentFormTitle;}
			set{_paymentFormTitle = value;}
		}
           --- DEL 2008/06/13 --------------------------------<<<<< */

		/// public propaty name  :  DmdFormComent1
		/// <summary>請求書コメント１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書コメント１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdFormComent1
		{
			get{return _dmdFormComent1;}
			set{_dmdFormComent1 = value;}
		}

		/// public propaty name  :  DmdFormComent2
		/// <summary>請求書コメント２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書コメント２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdFormComent2
		{
			get{return _dmdFormComent2;}
			set{_dmdFormComent2 = value;}
		}

		/// public propaty name  :  DmdFormComent3
		/// <summary>請求書コメント３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書コメント３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdFormComent3
		{
			get{return _dmdFormComent3;}
			set{_dmdFormComent3 = value;}
		}

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// public propaty name  :  DmdFmDmdTtlGenCd1
		/// <summary>請求書請求集計分類１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書請求集計分類１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdFmDmdTtlGenCd1
		{
			get{return _dmdFmDmdTtlGenCd1;}
			set{_dmdFmDmdTtlGenCd1 = value;}
		}

		/// public propaty name  :  DmdFmDmdTtlGenCd2
		/// <summary>請求書請求集計分類２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書請求集計分類２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdFmDmdTtlGenCd2
		{
			get{return _dmdFmDmdTtlGenCd2;}
			set{_dmdFmDmdTtlGenCd2 = value;}
		}

		/// public propaty name  :  DmdFmDmdTtlGenCd3
		/// <summary>請求書請求集計分類３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書請求集計分類３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdFmDmdTtlGenCd3
		{
			get{return _dmdFmDmdTtlGenCd3;}
			set{_dmdFmDmdTtlGenCd3 = value;}
		}

		/// public propaty name  :  DmdFmPayTtlGenCd1
		/// <summary>請求書支払集計分類１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書支払集計分類１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdFmPayTtlGenCd1
		{
			get{return _dmdFmPayTtlGenCd1;}
			set{_dmdFmPayTtlGenCd1 = value;}
		}

		/// public propaty name  :  DmdFmPayTtlGenCd2
		/// <summary>請求書支払集計分類２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書支払集計分類２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdFmPayTtlGenCd2
		{
			get{return _dmdFmPayTtlGenCd2;}
			set{_dmdFmPayTtlGenCd2 = value;}
		}

		/// public propaty name  :  DmdFmPayTtlGenCd3
		/// <summary>請求書支払集計分類３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書支払集計分類３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdFmPayTtlGenCd3
		{
			get{return _dmdFmPayTtlGenCd3;}
			set{_dmdFmPayTtlGenCd3 = value;}
		}

		/// public propaty name  :  DmdFmDmdTtlGenNm2
		/// <summary>請求書請求集計分類名称２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書請求集計分類名称２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdFmDmdTtlGenNm2
		{
			get{return _dmdFmDmdTtlGenNm2;}
			set{_dmdFmDmdTtlGenNm2 = value;}
		}

		/// public propaty name  :  DmdFmDmdTtlGenNm3
		/// <summary>請求書請求集計分類名称３プロパティ</summary>
		/// <value>明細金額ゼロ時印字有無</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書請求集計分類名称３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdFmDmdTtlGenNm3
		{
			get{return _dmdFmDmdTtlGenNm3;}
			set{_dmdFmDmdTtlGenNm3 = value;}
		}

		/// public propaty name  :  DmdTtlGenDefltNm
		/// <summary>請求集計分類デフォルト名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求集計分類デフォルト名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DmdTtlGenDefltNm
		{
			get{return _dmdTtlGenDefltNm;}
			set{_dmdTtlGenDefltNm = value;}
		}

		/// public propaty name  :  PayTtlGenDefltNm
		/// <summary>支払集計分類デフォルト名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払集計分類デフォルト名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PayTtlGenDefltNm
		{
			get{return _payTtlGenDefltNm;}
			set{_payTtlGenDefltNm = value;}
		}

		/// public propaty name  :  DmdDtlUnitPrtDiv
		/// <summary>請求明細単価別出力有無プロパティ</summary>
		/// <value>0:単価印字する 1:単価印字しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求明細単価別出力有無プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdDtlUnitPrtDiv
		{
			get{return _dmdDtlUnitPrtDiv;}
			set{_dmdDtlUnitPrtDiv = value;}
		}

		/// public propaty name  :  PayDtlUnitPrtDiv
		/// <summary>支払明細単価別出力有無プロパティ</summary>
		/// <value>0:単価印字する 1:単価印字しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払明細単価別出力有無プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PayDtlUnitPrtDiv
		{
			get{return _payDtlUnitPrtDiv;}
			set{_payDtlUnitPrtDiv = value;}
		}

		/// public propaty name  :  ThTmDmdZeroPrtDiv
		/// <summary>今回請求額ゼロ時印字有無プロパティ</summary>
		/// <value>0:印字する 1:印字しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   今回請求額ゼロ時印字有無プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ThTmDmdZeroPrtDiv
		{
			get{return _thTmDmdZeroPrtDiv;}
			set{_thTmDmdZeroPrtDiv = value;}
		}

		/// public propaty name  :  DmdDtlPrcZeroPrtDiv
		/// <summary>請求明細金額ゼロ時印字有無プロパティ</summary>
		/// <value>0:印字する 1:全て0のみ印字しない 2:相殺額が0の時印字しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求明細金額ゼロ時印字有無プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdDtlPrcZeroPrtDiv
		{
			get{return _dmdDtlPrcZeroPrtDiv;}
			set{_dmdDtlPrcZeroPrtDiv = value;}
		}

		/// public propaty name  :  PayDtlPrcZeroPrtDiv
		/// <summary>支払明細金額ゼロ時印字有無プロパティ</summary>
		/// <value>0:印字する 1:印字しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   支払明細金額ゼロ時印字有無プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PayDtlPrcZeroPrtDiv
		{
			get{return _payDtlPrcZeroPrtDiv;}
			set{_payDtlPrcZeroPrtDiv = value;}
		}

		/// public propaty name  :  MinusDmdPrtDiv
		/// <summary>マイナス請求時印刷区分プロパティ</summary>
		/// <value>0:支払通知書とする 1:マイナス請求書とする</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   マイナス請求時印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MinusDmdPrtDiv
		{
			get{return _minusDmdPrtDiv;}
			set{_minusDmdPrtDiv = value;}
		}
           --- DEL 2008/06/13 --------------------------------<<<<< */

		/// public propaty name  :  DmdFmDepoTtlPrtDiv
		/// <summary>請求書入金集計明細印字区分プロパティ</summary>
		/// <value>0:印字する 1:印字しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   請求書入金集計明細印字区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmdFmDepoTtlPrtDiv
		{
			get{return _dmdFmDepoTtlPrtDiv;}
			set{_dmdFmDepoTtlPrtDiv = value;}
		}

        /* --- DEL 2008/06/13 -------------------------------->>>>>
		/// public propaty name  :  CmplDmdMdGoodsCd1
		/// <summary>強制請求出力商品区分１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制請求出力商品区分１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplDmdMdGoodsCd1
		{
			get{return _cmplDmdMdGoodsCd1;}
			set{_cmplDmdMdGoodsCd1 = value;}
		}

		/// public propaty name  :  CmplDmdMdGoodsCd2
		/// <summary>強制請求出力商品区分２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制請求出力商品区分２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplDmdMdGoodsCd2
		{
			get{return _cmplDmdMdGoodsCd2;}
			set{_cmplDmdMdGoodsCd2 = value;}
		}

		/// public propaty name  :  CmplDmdMdGoodsCd3
		/// <summary>強制請求出力商品区分３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制請求出力商品区分３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplDmdMdGoodsCd3
		{
			get{return _cmplDmdMdGoodsCd3;}
			set{_cmplDmdMdGoodsCd3 = value;}
		}

		/// public propaty name  :  CmplDmdMdGoodsCd4
		/// <summary>強制請求出力商品区分４プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制請求出力商品区分４プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplDmdMdGoodsCd4
		{
			get{return _cmplDmdMdGoodsCd4;}
			set{_cmplDmdMdGoodsCd4 = value;}
		}

		/// public propaty name  :  CmplDmdMdGoodsCd5
		/// <summary>強制請求出力商品区分５プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制請求出力商品区分５プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplDmdMdGoodsCd5
		{
			get{return _cmplDmdMdGoodsCd5;}
			set{_cmplDmdMdGoodsCd5 = value;}
		}

		/// public propaty name  :  CmplDmdMdGoodsCd6
		/// <summary>強制請求出力商品区分６プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制請求出力商品区分６プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplDmdMdGoodsCd6
		{
			get{return _cmplDmdMdGoodsCd6;}
			set{_cmplDmdMdGoodsCd6 = value;}
		}

		/// public propaty name  :  CmplDmdMdGoodsCd7
		/// <summary>強制請求出力商品区分７プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制請求出力商品区分７プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplDmdMdGoodsCd7
		{
			get{return _cmplDmdMdGoodsCd7;}
			set{_cmplDmdMdGoodsCd7 = value;}
		}

		/// public propaty name  :  CmplDmdMdGoodsCd8
		/// <summary>強制請求出力商品区分８プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制請求出力商品区分８プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplDmdMdGoodsCd8
		{
			get{return _cmplDmdMdGoodsCd8;}
			set{_cmplDmdMdGoodsCd8 = value;}
		}

		/// public propaty name  :  CmplDmdMdGoodsCd9
		/// <summary>強制請求出力商品区分９プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制請求出力商品区分９プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplDmdMdGoodsCd9
		{
			get{return _cmplDmdMdGoodsCd9;}
			set{_cmplDmdMdGoodsCd9 = value;}
		}

		/// public propaty name  :  CmplDmdMdGoodsCd10
		/// <summary>強制請求出力商品区分１０プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制請求出力商品区分１０プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplDmdMdGoodsCd10
		{
			get{return _cmplDmdMdGoodsCd10;}
			set{_cmplDmdMdGoodsCd10 = value;}
		}

		/// public propaty name  :  CmplPayMdGoodsCd1
		/// <summary>強制支払出力商品区分１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制支払出力商品区分１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplPayMdGoodsCd1
		{
			get{return _cmplPayMdGoodsCd1;}
			set{_cmplPayMdGoodsCd1 = value;}
		}

		/// public propaty name  :  CmplPayMdGoodsCd2
		/// <summary>強制支払出力商品区分２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制支払出力商品区分２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplPayMdGoodsCd2
		{
			get{return _cmplPayMdGoodsCd2;}
			set{_cmplPayMdGoodsCd2 = value;}
		}

		/// public propaty name  :  CmplPayMdGoodsCd3
		/// <summary>強制支払出力商品区分３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制支払出力商品区分３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplPayMdGoodsCd3
		{
			get{return _cmplPayMdGoodsCd3;}
			set{_cmplPayMdGoodsCd3 = value;}
		}

		/// public propaty name  :  CmplPayMdGoodsCd4
		/// <summary>強制支払出力商品区分４プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制支払出力商品区分４プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplPayMdGoodsCd4
		{
			get{return _cmplPayMdGoodsCd4;}
			set{_cmplPayMdGoodsCd4 = value;}
		}

		/// public propaty name  :  CmplPayMdGoodsCd5
		/// <summary>強制支払出力商品区分５プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制支払出力商品区分５プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplPayMdGoodsCd5
		{
			get{return _cmplPayMdGoodsCd5;}
			set{_cmplPayMdGoodsCd5 = value;}
		}

		/// public propaty name  :  CmplPayMdGoodsCd6
		/// <summary>強制支払出力商品区分６プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制支払出力商品区分６プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplPayMdGoodsCd6
		{
			get{return _cmplPayMdGoodsCd6;}
			set{_cmplPayMdGoodsCd6 = value;}
		}

		/// public propaty name  :  CmplPayMdGoodsCd7
		/// <summary>強制支払出力商品区分７プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制支払出力商品区分７プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplPayMdGoodsCd7
		{
			get{return _cmplPayMdGoodsCd7;}
			set{_cmplPayMdGoodsCd7 = value;}
		}

		/// public propaty name  :  CmplPayMdGoodsCd8
		/// <summary>強制支払出力商品区分８プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制支払出力商品区分８プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplPayMdGoodsCd8
		{
			get{return _cmplPayMdGoodsCd8;}
			set{_cmplPayMdGoodsCd8 = value;}
		}

		/// public propaty name  :  CmplPayMdGoodsCd9
		/// <summary>強制支払出力商品区分９プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制支払出力商品区分９プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplPayMdGoodsCd9
		{
			get{return _cmplPayMdGoodsCd9;}
			set{_cmplPayMdGoodsCd9 = value;}
		}

		/// public propaty name  :  CmplPayMdGoodsCd10
		/// <summary>強制支払出力商品区分１０プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   強制支払出力商品区分１０プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string CmplPayMdGoodsCd10
		{
			get{return _cmplPayMdGoodsCd10;}
			set{_cmplPayMdGoodsCd10 = value;}
		}
            --- DEL 2008/06/13 --------------------------------<<<<< */

		/// public propaty name  :  CellphoneIncOutDiv
		/// <summary>機種別インセンティブ出力区分プロパティ</summary>
		/// <value>0:集計印字 1:機種別印字</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   機種別インセンティブ出力区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
        // 2007.09.18 hikita del start ----------------------------------------->>
        //public Int32 CellphoneIncOutDiv
		//{
		//	get{return _cellphoneIncOutDiv;}
		//	set{_cellphoneIncOutDiv = value;}
		//}
        // 2007.09.18 hikita del end -------------------------------------------<<


        // --- ADD 2008/06/13 -------------------------------->>>>>
        /// public propaty name  :  DataInputSystem
        /// <summary>データ入力システムプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   データ入力システムプロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 DataInputSystem
        {
            get { return _dataInputSystem; }
            set { _dataInputSystem = value; }
        }

        /// public propaty name  :  SlipPrtKind
        /// <summary>伝票印刷種別プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票印刷種別プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SlipPrtKind
        {
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
        }

        /// public propaty name  :  SlipPrtSetPaperId
        /// <summary>伝票印刷設定用帳票IDプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票印刷設定用帳票IDプロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public string SlipPrtSetPaperId
        {
            get { return _slipPrtSetPaperId; }
            set { _slipPrtSetPaperId = value; }
        }

        /// public propaty name  :  SlipComment
        /// <summary>伝票コメントプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票コメントプロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public string SlipComment
        {
            get { return _slipComment; }
            set { _slipComment = value; }
        }

        /// public propaty name  :  OutputFormFileName
        /// <summary>出力ファイル名プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出力ファイル名プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public string OutputFormFileName
        {
            get { return _outputFormFileName; }
            set { _outputFormFileName = value; }
        }

        /// public propaty name  :  TopMargin
        /// <summary>上余白プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   上余白プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Double TopMargin
        {
            get { return _topMargin; }
            set { _topMargin = value; }
        }

        /// public propaty name  :  LeftMargin
        /// <summary>左余白プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   左余白プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Double LeftMargin
        {
            get { return _leftMargin; }
            set { _leftMargin = value; }
        }

        /// public propaty name  :  RightMargin
        /// <summary>右余白プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   右余白プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Double RightMargin
        {
            get { return _rightMargin; }
            set { _rightMargin = value; }
        }

        /// public propaty name  :  BottomMargin
        /// <summary>下余白プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   下余白プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Double BottomMargin
        {
            get { return _bottomMargin; }
            set { _bottomMargin = value; }
        }

        /// public propaty name  :  CopyCount
        /// <summary>複写枚数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   複写枚数プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CopyCount
        {
            get { return _copyCount; }
            set { _copyCount = value; }
        }

        /// public propaty name  :  DmdFormTitle2
        /// <summary>請求書タイトル２プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書タイトル２プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public string DmdFormTitle2
        {
            get { return _dmdFormTitle2; }
            set { _dmdFormTitle2 = value; }
        }

        /// public propaty name  :  DmdDtlOutlineCode
        /// <summary>請求明細摘要区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求明細摘要区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 DmdDtlOutlineCode
        {
            get { return _dmdDtlOutlineCode; }
            set { _dmdDtlOutlineCode = value; }
        }

        /// public propaty name  :  DmdDtlPtnOdrDiv
        /// <summary>請求明細書印字順位区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求明細書印字順位区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 DmdDtlPtnOdrDiv
        {
            get { return _dmdDtlPtnOdrDiv; }
            set { _dmdDtlPtnOdrDiv = value; }
        }

        /// public propaty name  :  SlipTtlPrtDiv
        /// <summary>伝票計印字有無プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票計印字有無プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 SlipTtlPrtDiv
        {
            get { return _slipTtlPrtDiv; }
            set { _slipTtlPrtDiv = value; }
        }

        /// public propaty name  :  AddDayTtlPrtDiv
        /// <summary>計上日計印字有無プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日計印字有無プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 AddDayTtlPrtDiv
        {
            get { return _addDayTtlPrtDiv; }
            set { _addDayTtlPrtDiv = value; }
        }

        /// public propaty name  :  CustomerTtlPrtDiv
        /// <summary>得意先計印字有無プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先計印字有無プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 CustomerTtlPrtDiv
        {
            get { return _customerTtlPrtDiv; }
            set { _customerTtlPrtDiv = value; }
        }

        /// public propaty name  :  DtlPrcZeroPrtDiv
        /// <summary>明細金額ゼロ時印字有無プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細金額ゼロ時印字有無プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 DtlPrcZeroPrtDiv
        {
            get { return _dtlPrcZeroPrtDiv; }
            set { _dtlPrcZeroPrtDiv = value; }
        }

        /// public propaty name  :  DepoDtlPrcPrtDiv
        /// <summary>入金明細印字有無区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金明細印字有無区分プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public Int32 DepoDtlPrcPrtDiv
        {
            get { return _depoDtlPrcPrtDiv; }
            set { _depoDtlPrcPrtDiv = value; }
        }

        /// public propaty name  :  BillHonorificTtl
        /// <summary>請求書敬称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書敬称プロパティ</br>
        /// <br>Programer        :   30415 柴田 倫幸</br>
        /// </remarks>
        public string BillHonorificTtl
        {
            get { return _billHonorificTtl; }
            set { _billHonorificTtl = value; }
        }
        // --- ADD 2008/06/13 --------------------------------<<<<< 

        /// public propaty name  :  ListPricePrtCd
        /// <summary>標準価格印字区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   標準価格印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ListPricePrtCd
        {
            get { return _listPricePrtCd; }
            set { _listPricePrtCd = value; }
        }

        /// public propaty name  :  PartsNoPrtCd
        /// <summary>品番印字区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsNoPrtCd
        {
            get { return _partsNoPrtCd; }
            set { _partsNoPrtCd = value; }
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

        // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
        /// public propaty name  :  AnnotationPrtCd
        /// <summary>注釈印字区分プロパティ</summary>
        /// <value>0:印字する,1:印字しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   注釈印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AnnotationPrtCd
        {
            get { return _annotationPrtCd; }
            set { _annotationPrtCd = value; }
        }
        // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

        // --- ADD  2011/02/16 ---------->>>>>
        /// public propaty name  :  CoNmPrintOutCd
        /// <summary>自社名印字区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名印字区分プロパティ</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public Int32 CoNmPrintOutCd
        {
            get { return _coNmPrintOutCd; }
            set { _coNmPrintOutCd = value; }
        }
        // --- ADD  2011/02/16 ----------<<<<<<<
		/// <summary>
		/// 請求書印刷パターンマスタコンストラクタ
		/// </summary>
		/// <returns>DmdPrtPtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DmdPrtPtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DmdPrtPtn()
		{
		}

		/// <summary>
		/// 請求書印刷パターンマスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID1(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        // --- ADD 2008/06/13 -------------------------------->>>>>
        /// <param name="">データ入力システム(0:共通,1:整備,2:鈑金,3:車販)</param>
        /// <param name="">伝票印刷種別(50:合計請求書,60:明細請求書,70:伝票合計請求書,80:領収書)</param>
        /// <param name="">伝票印刷設定用帳票ID(伝票印刷設定用)</param>
        /// <param name="">伝票コメント</param>
        /// <param name="">出力ファイル名(フォームファイルID or フォーマットファイルID)</param>
        /// <param name="">上余白(cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8))</param>
        /// <param name="">左余白(cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8))</param>
        /// <param name="">右余白</param>
        /// <param name="">下余白</param>
        /// <param name="">複写枚数</param>
        // --- ADD 2008/06/13 --------------------------------<<<<< 
        /// <param name="dmdTtlFormTitle1">請求 鑑タイトル１</param>
        /// <param name="dmdTtlFormTitle2">請求 鑑タイトル２</param>
        /// <param name="dmdTtlFormTitle3">請求 鑑タイトル３</param>
        /// <param name="dmdTtlFormTitle4">請求 鑑タイトル４</param>
        /// <param name="dmdTtlFormTitle5">請求 鑑タイトル５</param>
        /// <param name="dmdTtlFormTitle6">請求 鑑タイトル６</param>
        /// <param name="dmdTtlFormTitle7">請求 鑑タイトル７</param>
        /// <param name="dmdTtlFormTitle8">請求 鑑タイトル８</param>
        /// <param name="dmdTtlSetItemDiv1">請求 鑑設定項目区分１</param>
		/// <param name="dmdTtlSetItemDiv2">請求 鑑設定項目区分２</param>
		/// <param name="dmdTtlSetItemDiv3">請求 鑑設定項目区分３</param>
		/// <param name="dmdTtlSetItemDiv4">請求 鑑設定項目区分４</param>
		/// <param name="dmdTtlSetItemDiv5">請求 鑑設定項目区分５</param>
		/// <param name="dmdTtlSetItemDiv6">請求 鑑設定項目区分６</param>
		/// <param name="dmdTtlSetItemDiv7">請求 鑑設定項目区分７</param>
		/// <param name="dmdTtlSetItemDiv8">請求 鑑設定項目区分８</param>
        /// <param name="dmdFormTitle">請求書タイトル</param>
        // --- ADD 2008/06/13 -------------------------------->>>>>
        /// <param name="">請求書タイトル２(控え)</param>
        // --- ADD 2008/06/13 --------------------------------<<<<< 
		/// <param name="dmdFormComent1">請求書コメント１</param>
		/// <param name="dmdFormComent2">請求書コメント２</param>
		/// <param name="dmdFormComent3">請求書コメント３</param>
        // --- ADD 2008/06/13 -------------------------------->>>>>
        /// <param name="">請求明細摘要区分(0:印字しない 1:品番 2:定価)</param>
        /// <param name="">請求明細書印字順位区分(0:計上日+伝票番号 1:得意先+計上日+伝票番号)</param>
        /// <param name="">伝票計印字有無(0:印字する 1:印字しない)</param>
        /// <param name="">計上日計印字有無(0:印字する 1:印字しない)</param>
        /// <param name="">得意先計印字有無(0:印字する 1:印字しない)</param>
        /// <param name="">明細金額ゼロ時印字有無(0:印字する 1:印字しない)</param>
        /// <param name="">入金明細印字有無区分(0:印字しない 1:印字する(合計)  1:印字する (明細))</param>
        /// <param name="">請求書敬称(請求書用の敬称)</param>
        // --- ADD 2008/06/13 --------------------------------<<<<< 
        /// <param name="dmdFmDepoTtlPrtDiv">請求書入金集計明細印字区分(0:印字する 1:印字しない)</param>
		/// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
        // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
        /// <param name="annotationPrtCd">注釈印字区分(0:印字する 1:印字しない)</param>
        // --- ADD  大矢睦美  2010/02/18 ----------<<<<<
        // --- ADD  2011/02/16 ---------->>>>>
        /// <param name="coNmPrintOutCd">自社名印字区分(0:印字する,1:自社名,2:拠点名,3:ビットマップ,4:印字しない)</param>
        // --- ADD  2011/02/16----------<<<<<
		/// <returns>DmdPrtPtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DmdPrtPtnクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		//public DmdPrtPtn(DateTime createDateTime,DateTime updateDateTime,string enterpriseCode,Guid fileHeaderGuid,string updEmployeeCode,string updAssemblyId1,string updAssemblyId2,Int32 logicalDeleteCode,Int32 demandPtnNo,string demandPtnNoNm,string dmdTtlFormTitle1,string dmdTtlFormTitle2,string dmdTtlFormTitle3,string dmdTtlFormTitle4,string dmdTtlFormTitle5,string dmdTtlFormTitle6,string dmdTtlFormTitle7,string dmdTtlFormTitle8,Int32 dmdTtlSetItemDiv1,Int32 dmdTtlSetItemDiv2,Int32 dmdTtlSetItemDiv3,Int32 dmdTtlSetItemDiv4,Int32 dmdTtlSetItemDiv5,Int32 dmdTtlSetItemDiv6,Int32 dmdTtlSetItemDiv7,Int32 dmdTtlSetItemDiv8,string payTtlFormTitle1,string payTtlFormTitle2,string payTtlFormTitle3,string payTtlFormTitle4,string payTtlFormTitle5,string payTtlFormTitle6,string payTtlFormTitle7,string payTtlFormTitle8,string dmdFormTitle,string paymentFormTitle,string dmdFormComent1,string dmdFormComent2,string dmdFormComent3,Int32 dmdFmDmdTtlGenCd1,Int32 dmdFmDmdTtlGenCd2,Int32 dmdFmDmdTtlGenCd3,Int32 dmdFmPayTtlGenCd1,Int32 dmdFmPayTtlGenCd2,Int32 dmdFmPayTtlGenCd3,string dmdFmDmdTtlGenNm2,string dmdFmDmdTtlGenNm3,string dmdTtlGenDefltNm,string payTtlGenDefltNm,Int32 dmdDtlUnitPrtDiv,Int32 payDtlUnitPrtDiv,Int32 thTmDmdZeroPrtDiv,Int32 dmdDtlPrcZeroPrtDiv,Int32 payDtlPrcZeroPrtDiv,Int32 minusDmdPrtDiv,Int32 dmdFmDepoTtlPrtDiv,string cmplDmdMdGoodsCd1,string cmplDmdMdGoodsCd2,string cmplDmdMdGoodsCd3,string cmplDmdMdGoodsCd4,string cmplDmdMdGoodsCd5,string cmplDmdMdGoodsCd6,string cmplDmdMdGoodsCd7,string cmplDmdMdGoodsCd8,string cmplDmdMdGoodsCd9,string cmplDmdMdGoodsCd10,string cmplPayMdGoodsCd1,string cmplPayMdGoodsCd2,string cmplPayMdGoodsCd3,string cmplPayMdGoodsCd4,string cmplPayMdGoodsCd5,string cmplPayMdGoodsCd6,string cmplPayMdGoodsCd7,string cmplPayMdGoodsCd8,string cmplPayMdGoodsCd9,string cmplPayMdGoodsCd10,Int32 cellphoneIncOutDiv,string enterpriseName,string updEmployeeName)  // 2007.09.18 hikita del
        //public DmdPrtPtn(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 dataInputSystem, Int32 slipPrtKind, string slipPrtSetPaperId, string slipComment, string outputFormFileName, Double topMargin, Double leftMargin, Double rightMargin, Double bottomMargin, Int32 copyCount, string dmdTtlFormTitle1, string dmdTtlFormTitle2, string dmdTtlFormTitle3, string dmdTtlFormTitle4, string dmdTtlFormTitle5, string dmdTtlFormTitle6, string dmdTtlFormTitle7, string dmdTtlFormTitle8, Int32 dmdTtlSetItemDiv1, Int32 dmdTtlSetItemDiv2, Int32 dmdTtlSetItemDiv3, Int32 dmdTtlSetItemDiv4, Int32 dmdTtlSetItemDiv5, Int32 dmdTtlSetItemDiv6, Int32 dmdTtlSetItemDiv7, Int32 dmdTtlSetItemDiv8, string dmdFormTitle, string dmdFormTitle2, string dmdFormComent1, string dmdFormComent2, string dmdFormComent3, Int32 dmdDtlOutlineCode, Int32 dmdDtlPtnOdrDiv, Int32 slipTtlPrtDiv, Int32 addDayTtlPrtDiv, Int32 customerTtlPrtDiv, Int32 dtlPrcZeroPrtDiv, Int32 depoDtlPrcPrtDiv, string billHonorificTtl, Int32 dmdFmDepoTtlPrtDiv, string enterpriseName, string updEmployeeName)                             // 2007.09.18 hikita add
        // --- ADD  大矢睦美  2010/02/18 ---------->>>>>       
        //public DmdPrtPtn(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 dataInputSystem, Int32 slipPrtKind, string slipPrtSetPaperId, string slipComment, string outputFormFileName, Double topMargin, Double leftMargin, Double rightMargin, Double bottomMargin, Int32 copyCount, string dmdTtlFormTitle1, string dmdTtlFormTitle2, string dmdTtlFormTitle3, string dmdTtlFormTitle4, string dmdTtlFormTitle5, string dmdTtlFormTitle6, string dmdTtlFormTitle7, string dmdTtlFormTitle8, Int32 dmdTtlSetItemDiv1, Int32 dmdTtlSetItemDiv2, Int32 dmdTtlSetItemDiv3, Int32 dmdTtlSetItemDiv4, Int32 dmdTtlSetItemDiv5, Int32 dmdTtlSetItemDiv6, Int32 dmdTtlSetItemDiv7, Int32 dmdTtlSetItemDiv8, string dmdFormTitle, string dmdFormTitle2, string dmdFormComent1, string dmdFormComent2, string dmdFormComent3, Int32 dmdDtlOutlineCode, Int32 dmdDtlPtnOdrDiv, Int32 slipTtlPrtDiv, Int32 addDayTtlPrtDiv, Int32 customerTtlPrtDiv, Int32 dtlPrcZeroPrtDiv, Int32 depoDtlPrcPrtDiv, string billHonorificTtl, Int32 dmdFmDepoTtlPrtDiv, Int32 listPricePrtCd, Int32 partsNoPrtCd, string enterpriseName, string updEmployeeName)
        // --- UPD  2011/02/16 ---------->>>>>
         // public DmdPrtPtn(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 dataInputSystem, Int32 slipPrtKind, string slipPrtSetPaperId, string slipComment, string outputFormFileName, Double topMargin, Double leftMargin, Double rightMargin, Double bottomMargin, Int32 copyCount, string dmdTtlFormTitle1, string dmdTtlFormTitle2, string dmdTtlFormTitle3, string dmdTtlFormTitle4, string dmdTtlFormTitle5, string dmdTtlFormTitle6, string dmdTtlFormTitle7, string dmdTtlFormTitle8, Int32 dmdTtlSetItemDiv1, Int32 dmdTtlSetItemDiv2, Int32 dmdTtlSetItemDiv3, Int32 dmdTtlSetItemDiv4, Int32 dmdTtlSetItemDiv5, Int32 dmdTtlSetItemDiv6, Int32 dmdTtlSetItemDiv7, Int32 dmdTtlSetItemDiv8, string dmdFormTitle, string dmdFormTitle2, string dmdFormComent1, string dmdFormComent2, string dmdFormComent3, Int32 dmdDtlOutlineCode, Int32 dmdDtlPtnOdrDiv, Int32 slipTtlPrtDiv, Int32 addDayTtlPrtDiv, Int32 customerTtlPrtDiv, Int32 dtlPrcZeroPrtDiv, Int32 depoDtlPrcPrtDiv, string billHonorificTtl, Int32 dmdFmDepoTtlPrtDiv, Int32 listPricePrtCd, Int32 partsNoPrtCd, Int32 annotationPrtCd, string enterpriseName, string updEmployeeName)
        public DmdPrtPtn(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 dataInputSystem, Int32 slipPrtKind, string slipPrtSetPaperId, string slipComment, string outputFormFileName, Double topMargin, Double leftMargin, Double rightMargin, Double bottomMargin, Int32 copyCount, string dmdTtlFormTitle1, string dmdTtlFormTitle2, string dmdTtlFormTitle3, string dmdTtlFormTitle4, string dmdTtlFormTitle5, string dmdTtlFormTitle6, string dmdTtlFormTitle7, string dmdTtlFormTitle8, Int32 dmdTtlSetItemDiv1, Int32 dmdTtlSetItemDiv2, Int32 dmdTtlSetItemDiv3, Int32 dmdTtlSetItemDiv4, Int32 dmdTtlSetItemDiv5, Int32 dmdTtlSetItemDiv6, Int32 dmdTtlSetItemDiv7, Int32 dmdTtlSetItemDiv8, string dmdFormTitle, string dmdFormTitle2, string dmdFormComent1, string dmdFormComent2, string dmdFormComent3, Int32 dmdDtlOutlineCode, Int32 dmdDtlPtnOdrDiv, Int32 slipTtlPrtDiv, Int32 addDayTtlPrtDiv, Int32 customerTtlPrtDiv, Int32 dtlPrcZeroPrtDiv, Int32 depoDtlPrcPrtDiv, string billHonorificTtl, Int32 dmdFmDepoTtlPrtDiv, Int32 listPricePrtCd, Int32 partsNoPrtCd, Int32 annotationPrtCd, Int32 coNmPrintOutCd, string enterpriseName, string updEmployeeName)
        // --- UPD  2011/02/16 ----------<<<<<
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;

            // --- ADD 2008/06/13 -------------------------------->>>>>
            this._dataInputSystem = dataInputSystem;
            this._slipPrtKind = slipPrtKind;
            this._slipPrtSetPaperId = slipPrtSetPaperId;
            this._slipComment = slipComment;
            this._outputFormFileName = outputFormFileName;
            this._topMargin = topMargin;
            this._leftMargin = leftMargin;
            this._rightMargin = rightMargin;
            this._bottomMargin = bottomMargin;
            this._copyCount = copyCount;
            // --- ADD 2008/06/13 --------------------------------<<<<< 

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			this._demandPtnNo = demandPtnNo;
			this._demandPtnNoNm = demandPtnNoNm;
               --- DEL 2008/06/13 --------------------------------<<<<< */

            this._dmdTtlFormTitle1 = dmdTtlFormTitle1;
			this._dmdTtlFormTitle2 = dmdTtlFormTitle2;
			this._dmdTtlFormTitle3 = dmdTtlFormTitle3;
			this._dmdTtlFormTitle4 = dmdTtlFormTitle4;
			this._dmdTtlFormTitle5 = dmdTtlFormTitle5;
			this._dmdTtlFormTitle6 = dmdTtlFormTitle6;
			this._dmdTtlFormTitle7 = dmdTtlFormTitle7;
			this._dmdTtlFormTitle8 = dmdTtlFormTitle8;

			this._dmdTtlSetItemDiv1 = dmdTtlSetItemDiv1;
			this._dmdTtlSetItemDiv2 = dmdTtlSetItemDiv2;
			this._dmdTtlSetItemDiv3 = dmdTtlSetItemDiv3;
			this._dmdTtlSetItemDiv4 = dmdTtlSetItemDiv4;
			this._dmdTtlSetItemDiv5 = dmdTtlSetItemDiv5;
			this._dmdTtlSetItemDiv6 = dmdTtlSetItemDiv6;
			this._dmdTtlSetItemDiv7 = dmdTtlSetItemDiv7;
			this._dmdTtlSetItemDiv8 = dmdTtlSetItemDiv8;

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			this._payTtlFormTitle1 = payTtlFormTitle1;
			this._payTtlFormTitle2 = payTtlFormTitle2;
			this._payTtlFormTitle3 = payTtlFormTitle3;
			this._payTtlFormTitle4 = payTtlFormTitle4;
			this._payTtlFormTitle5 = payTtlFormTitle5;
			this._payTtlFormTitle6 = payTtlFormTitle6;
			this._payTtlFormTitle7 = payTtlFormTitle7;
			this._payTtlFormTitle8 = payTtlFormTitle8;
               --- DEL 2008/06/13 --------------------------------<<<<< */

			this._dmdFormTitle = dmdFormTitle;

            // --- ADD 2008/06/13 -------------------------------->>>>>
            this._dmdFormTitle2 = dmdFormTitle2;
            // --- ADD 2008/06/13 --------------------------------<<<<< 

			//this._paymentFormTitle = paymentFormTitle;  // DEL 2008/06/13
			this._dmdFormComent1 = dmdFormComent1;
			this._dmdFormComent2 = dmdFormComent2;
			this._dmdFormComent3 = dmdFormComent3;

            // --- ADD 2008/06/13 -------------------------------->>>>>
            this._dmdDtlOutlineCode = dmdDtlOutlineCode;
            this._dmdDtlPtnOdrDiv = dmdDtlPtnOdrDiv;
            this._slipTtlPrtDiv = slipTtlPrtDiv;
            this._addDayTtlPrtDiv = addDayTtlPrtDiv;
            this._customerTtlPrtDiv = customerTtlPrtDiv;
            this._dtlPrcZeroPrtDiv = dtlPrcZeroPrtDiv;
            this._depoDtlPrcPrtDiv = depoDtlPrcPrtDiv;
            this._billHonorificTtl = billHonorificTtl;
            // --- ADD 2008/06/13 --------------------------------<<<<< 

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			this._dmdFmDmdTtlGenCd1 = dmdFmDmdTtlGenCd1;
			this._dmdFmDmdTtlGenCd2 = dmdFmDmdTtlGenCd2;
			this._dmdFmDmdTtlGenCd3 = dmdFmDmdTtlGenCd3;
			this._dmdFmPayTtlGenCd1 = dmdFmPayTtlGenCd1;
			this._dmdFmPayTtlGenCd2 = dmdFmPayTtlGenCd2;
			this._dmdFmPayTtlGenCd3 = dmdFmPayTtlGenCd3;
			this._dmdFmDmdTtlGenNm2 = dmdFmDmdTtlGenNm2;
			this._dmdFmDmdTtlGenNm3 = dmdFmDmdTtlGenNm3;
			this._dmdTtlGenDefltNm = dmdTtlGenDefltNm;
			this._payTtlGenDefltNm = payTtlGenDefltNm;
			this._dmdDtlUnitPrtDiv = dmdDtlUnitPrtDiv;
			this._payDtlUnitPrtDiv = payDtlUnitPrtDiv;
			this._thTmDmdZeroPrtDiv = thTmDmdZeroPrtDiv;
			this._dmdDtlPrcZeroPrtDiv = dmdDtlPrcZeroPrtDiv;
			this._payDtlPrcZeroPrtDiv = payDtlPrcZeroPrtDiv;
			this._minusDmdPrtDiv = minusDmdPrtDiv;
               --- DEL 2008/06/13 --------------------------------<<<<< */

			this._dmdFmDepoTtlPrtDiv = dmdFmDepoTtlPrtDiv;

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			this._cmplDmdMdGoodsCd1 = cmplDmdMdGoodsCd1;
			this._cmplDmdMdGoodsCd2 = cmplDmdMdGoodsCd2;
			this._cmplDmdMdGoodsCd3 = cmplDmdMdGoodsCd3;
			this._cmplDmdMdGoodsCd4 = cmplDmdMdGoodsCd4;
			this._cmplDmdMdGoodsCd5 = cmplDmdMdGoodsCd5;
			this._cmplDmdMdGoodsCd6 = cmplDmdMdGoodsCd6;
			this._cmplDmdMdGoodsCd7 = cmplDmdMdGoodsCd7;
			this._cmplDmdMdGoodsCd8 = cmplDmdMdGoodsCd8;
			this._cmplDmdMdGoodsCd9 = cmplDmdMdGoodsCd9;
			this._cmplDmdMdGoodsCd10 = cmplDmdMdGoodsCd10;
			this._cmplPayMdGoodsCd1 = cmplPayMdGoodsCd1;
			this._cmplPayMdGoodsCd2 = cmplPayMdGoodsCd2;
			this._cmplPayMdGoodsCd3 = cmplPayMdGoodsCd3;
			this._cmplPayMdGoodsCd4 = cmplPayMdGoodsCd4;
			this._cmplPayMdGoodsCd5 = cmplPayMdGoodsCd5;
			this._cmplPayMdGoodsCd6 = cmplPayMdGoodsCd6;
			this._cmplPayMdGoodsCd7 = cmplPayMdGoodsCd7;
			this._cmplPayMdGoodsCd8 = cmplPayMdGoodsCd8;
			this._cmplPayMdGoodsCd9 = cmplPayMdGoodsCd9;
			this._cmplPayMdGoodsCd10 = cmplPayMdGoodsCd10;
               --- DEL 2008/06/13 --------------------------------<<<<< */

            this._listPricePrtCd = listPricePrtCd;
            this._partsNoPrtCd = partsNoPrtCd;
            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            this._annotationPrtCd = annotationPrtCd;
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            this._coNmPrintOutCd = coNmPrintOutCd;
            // --- ADD  2011/02/16 ----------<<<<<

			// this._cellphoneIncOutDiv = cellphoneIncOutDiv;  // 2007.09.18 hikita del
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;

		}

		/// <summary>
		/// 請求書印刷パターンマスタ複製処理
		/// </summary>
		/// <returns>DmdPrtPtnクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいDmdPrtPtnクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public DmdPrtPtn Clone()
		{
            //return new DmdPrtPtn(this._createDateTime,this._updateDateTime,this._enterpriseCode,this._fileHeaderGuid,this._updEmployeeCode,this._updAssemblyId1,this._updAssemblyId2,this._logicalDeleteCode,this._demandPtnNo,this._demandPtnNoNm,this._dmdTtlFormTitle1,this._dmdTtlFormTitle2,this._dmdTtlFormTitle3,this._dmdTtlFormTitle4,this._dmdTtlFormTitle5,this._dmdTtlFormTitle6,this._dmdTtlFormTitle7,this._dmdTtlFormTitle8,this._dmdTtlSetItemDiv1,this._dmdTtlSetItemDiv2,this._dmdTtlSetItemDiv3,this._dmdTtlSetItemDiv4,this._dmdTtlSetItemDiv5,this._dmdTtlSetItemDiv6,this._dmdTtlSetItemDiv7,this._dmdTtlSetItemDiv8,this._payTtlFormTitle1,this._payTtlFormTitle2,this._payTtlFormTitle3,this._payTtlFormTitle4,this._payTtlFormTitle5,this._payTtlFormTitle6,this._payTtlFormTitle7,this._payTtlFormTitle8,this._dmdFormTitle,this._paymentFormTitle,this._dmdFormComent1,this._dmdFormComent2,this._dmdFormComent3,this._dmdFmDmdTtlGenCd1,this._dmdFmDmdTtlGenCd2,this._dmdFmDmdTtlGenCd3,this._dmdFmPayTtlGenCd1,this._dmdFmPayTtlGenCd2,this._dmdFmPayTtlGenCd3,this._dmdFmDmdTtlGenNm2,this._dmdFmDmdTtlGenNm3,this._dmdTtlGenDefltNm,this._payTtlGenDefltNm,this._dmdDtlUnitPrtDiv,this._payDtlUnitPrtDiv,this._thTmDmdZeroPrtDiv,this._dmdDtlPrcZeroPrtDiv,this._payDtlPrcZeroPrtDiv,this._minusDmdPrtDiv,this._dmdFmDepoTtlPrtDiv,this._cmplDmdMdGoodsCd1,this._cmplDmdMdGoodsCd2,this._cmplDmdMdGoodsCd3,this._cmplDmdMdGoodsCd4,this._cmplDmdMdGoodsCd5,this._cmplDmdMdGoodsCd6,this._cmplDmdMdGoodsCd7,this._cmplDmdMdGoodsCd8,this._cmplDmdMdGoodsCd9,this._cmplDmdMdGoodsCd10,this._cmplPayMdGoodsCd1,this._cmplPayMdGoodsCd2,this._cmplPayMdGoodsCd3,this._cmplPayMdGoodsCd4,this._cmplPayMdGoodsCd5,this._cmplPayMdGoodsCd6,this._cmplPayMdGoodsCd7,this._cmplPayMdGoodsCd8,this._cmplPayMdGoodsCd9,this._cmplPayMdGoodsCd10,this._enterpriseName,this._updEmployeeName);                              // 2007.09.18 add
            //return new DmdPrtPtn(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._dataInputSystem, this._slipPrtKind, this._slipPrtSetPaperId, this._slipComment, this._outputFormFileName, this._topMargin, this._leftMargin, this._rightMargin, this._bottomMargin, this._copyCount, this._dmdTtlFormTitle1, this._dmdTtlFormTitle2, this._dmdTtlFormTitle3, this._dmdTtlFormTitle4, this._dmdTtlFormTitle5, this._dmdTtlFormTitle6, this._dmdTtlFormTitle7, this._dmdTtlFormTitle8, this._dmdTtlSetItemDiv1, this._dmdTtlSetItemDiv2, this._dmdTtlSetItemDiv3, this._dmdTtlSetItemDiv4, this._dmdTtlSetItemDiv5, this._dmdTtlSetItemDiv6, this._dmdTtlSetItemDiv7, this._dmdTtlSetItemDiv8, this._dmdFormTitle, this._dmdFormTitle2, this._dmdFormComent1, this._dmdFormComent2, this._dmdFormComent3, this._dmdDtlOutlineCode, this._dmdDtlPtnOdrDiv, this._slipTtlPrtDiv, this._addDayTtlPrtDiv, this._customerTtlPrtDiv, this._dtlPrcZeroPrtDiv, this._depoDtlPrcPrtDiv, this._billHonorificTtl, this._dmdFmDepoTtlPrtDiv, this._enterpriseName, this._updEmployeeName);                              // 2007.09.18 add
            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            //return new DmdPrtPtn(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._dataInputSystem, this._slipPrtKind, this._slipPrtSetPaperId, this._slipComment, this._outputFormFileName, this._topMargin, this._leftMargin, this._rightMargin, this._bottomMargin, this._copyCount, this._dmdTtlFormTitle1, this._dmdTtlFormTitle2, this._dmdTtlFormTitle3, this._dmdTtlFormTitle4, this._dmdTtlFormTitle5, this._dmdTtlFormTitle6, this._dmdTtlFormTitle7, this._dmdTtlFormTitle8, this._dmdTtlSetItemDiv1, this._dmdTtlSetItemDiv2, this._dmdTtlSetItemDiv3, this._dmdTtlSetItemDiv4, this._dmdTtlSetItemDiv5, this._dmdTtlSetItemDiv6, this._dmdTtlSetItemDiv7, this._dmdTtlSetItemDiv8, this._dmdFormTitle, this._dmdFormTitle2, this._dmdFormComent1, this._dmdFormComent2, this._dmdFormComent3, this._dmdDtlOutlineCode, this._dmdDtlPtnOdrDiv, this._slipTtlPrtDiv, this._addDayTtlPrtDiv, this._customerTtlPrtDiv, this._dtlPrcZeroPrtDiv, this._depoDtlPrcPrtDiv, this._billHonorificTtl, this._dmdFmDepoTtlPrtDiv, this._listPricePrtCd, this._partsNoPrtCd, this._enterpriseName, this._updEmployeeName);
            // --- UPD  2011/02/16 ---------->>>>>
            //return new DmdPrtPtn(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._dataInputSystem, this._slipPrtKind, this._slipPrtSetPaperId, this._slipComment, this._outputFormFileName, this._topMargin, this._leftMargin, this._rightMargin, this._bottomMargin, this._copyCount, this._dmdTtlFormTitle1, this._dmdTtlFormTitle2, this._dmdTtlFormTitle3, this._dmdTtlFormTitle4, this._dmdTtlFormTitle5, this._dmdTtlFormTitle6, this._dmdTtlFormTitle7, this._dmdTtlFormTitle8, this._dmdTtlSetItemDiv1, this._dmdTtlSetItemDiv2, this._dmdTtlSetItemDiv3, this._dmdTtlSetItemDiv4, this._dmdTtlSetItemDiv5, this._dmdTtlSetItemDiv6, this._dmdTtlSetItemDiv7, this._dmdTtlSetItemDiv8, this._dmdFormTitle, this._dmdFormTitle2, this._dmdFormComent1, this._dmdFormComent2, this._dmdFormComent3, this._dmdDtlOutlineCode, this._dmdDtlPtnOdrDiv, this._slipTtlPrtDiv, this._addDayTtlPrtDiv, this._customerTtlPrtDiv, this._dtlPrcZeroPrtDiv, this._depoDtlPrcPrtDiv, this._billHonorificTtl, this._dmdFmDepoTtlPrtDiv, this._listPricePrtCd, this._partsNoPrtCd, this._annotationPrtCd, this._enterpriseName, this._updEmployeeName);
            return new DmdPrtPtn(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._dataInputSystem, this._slipPrtKind, this._slipPrtSetPaperId, this._slipComment, this._outputFormFileName, this._topMargin, this._leftMargin, this._rightMargin, this._bottomMargin, this._copyCount, this._dmdTtlFormTitle1, this._dmdTtlFormTitle2, this._dmdTtlFormTitle3, this._dmdTtlFormTitle4, this._dmdTtlFormTitle5, this._dmdTtlFormTitle6, this._dmdTtlFormTitle7, this._dmdTtlFormTitle8, this._dmdTtlSetItemDiv1, this._dmdTtlSetItemDiv2, this._dmdTtlSetItemDiv3, this._dmdTtlSetItemDiv4, this._dmdTtlSetItemDiv5, this._dmdTtlSetItemDiv6, this._dmdTtlSetItemDiv7, this._dmdTtlSetItemDiv8, this._dmdFormTitle, this._dmdFormTitle2, this._dmdFormComent1, this._dmdFormComent2, this._dmdFormComent3, this._dmdDtlOutlineCode, this._dmdDtlPtnOdrDiv, this._slipTtlPrtDiv, this._addDayTtlPrtDiv, this._customerTtlPrtDiv, this._dtlPrcZeroPrtDiv, this._depoDtlPrcPrtDiv, this._billHonorificTtl, this._dmdFmDepoTtlPrtDiv, this._listPricePrtCd, this._partsNoPrtCd, this._annotationPrtCd, this._coNmPrintOutCd, this._enterpriseName, this._updEmployeeName);
            // --- UPD  2011/02/16 ----------<<<<<<
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

        }

		/// <summary>
		/// 請求書印刷パターンマスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のDmdPrtPtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DmdPrtPtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(DmdPrtPtn target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)

                 /* --- DEL 2008/06/13 -------------------------------->>>>>
				 && (this.DemandPtnNo == target.DemandPtnNo)
				 && (this.DemandPtnNoNm == target.DemandPtnNoNm)
                    --- DEL 2008/06/13 --------------------------------<<<<< */
                 && (this.DmdTtlFormTitle1 == target.DmdTtlFormTitle1)
				 && (this.DmdTtlFormTitle2 == target.DmdTtlFormTitle2)
				 && (this.DmdTtlFormTitle3 == target.DmdTtlFormTitle3)
				 && (this.DmdTtlFormTitle4 == target.DmdTtlFormTitle4)
				 && (this.DmdTtlFormTitle5 == target.DmdTtlFormTitle5)
				 && (this.DmdTtlFormTitle6 == target.DmdTtlFormTitle6)
				 && (this.DmdTtlFormTitle7 == target.DmdTtlFormTitle7)
				 && (this.DmdTtlFormTitle8 == target.DmdTtlFormTitle8)

				 && (this.DmdTtlSetItemDiv1 == target.DmdTtlSetItemDiv1)
				 && (this.DmdTtlSetItemDiv2 == target.DmdTtlSetItemDiv2)
				 && (this.DmdTtlSetItemDiv3 == target.DmdTtlSetItemDiv3)
				 && (this.DmdTtlSetItemDiv4 == target.DmdTtlSetItemDiv4)
				 && (this.DmdTtlSetItemDiv5 == target.DmdTtlSetItemDiv5)
				 && (this.DmdTtlSetItemDiv6 == target.DmdTtlSetItemDiv6)
				 && (this.DmdTtlSetItemDiv7 == target.DmdTtlSetItemDiv7)
				 && (this.DmdTtlSetItemDiv8 == target.DmdTtlSetItemDiv8)

                 /* --- DEL 2008/06/13 -------------------------------->>>>>
                 && (this.PayTtlFormTitle1 == target.PayTtlFormTitle1)
                 && (this.PayTtlFormTitle2 == target.PayTtlFormTitle2)
                 && (this.PayTtlFormTitle3 == target.PayTtlFormTitle3)
                 && (this.PayTtlFormTitle4 == target.PayTtlFormTitle4)
                 && (this.PayTtlFormTitle5 == target.PayTtlFormTitle5)
                 && (this.PayTtlFormTitle6 == target.PayTtlFormTitle6)
                 && (this.PayTtlFormTitle7 == target.PayTtlFormTitle7)
                 && (this.PayTtlFormTitle8 == target.PayTtlFormTitle8)
                   --- DEL 2008/06/13 --------------------------------<<<<< */

				 && (this.DmdFormTitle == target.DmdFormTitle)

				 //&& (this.PaymentFormTitle == target.PaymentFormTitle)  // DEL 2008/06/13

				 && (this.DmdFormComent1 == target.DmdFormComent1)
				 && (this.DmdFormComent2 == target.DmdFormComent2)
				 && (this.DmdFormComent3 == target.DmdFormComent3)

                 /* --- DEL 2008/06/13 -------------------------------->>>>>
				 && (this.DmdFmDmdTtlGenCd1 == target.DmdFmDmdTtlGenCd1)
				 && (this.DmdFmDmdTtlGenCd2 == target.DmdFmDmdTtlGenCd2)
				 && (this.DmdFmDmdTtlGenCd3 == target.DmdFmDmdTtlGenCd3)
				 && (this.DmdFmPayTtlGenCd1 == target.DmdFmPayTtlGenCd1)
				 && (this.DmdFmPayTtlGenCd2 == target.DmdFmPayTtlGenCd2)
				 && (this.DmdFmPayTtlGenCd3 == target.DmdFmPayTtlGenCd3)
				 && (this.DmdFmDmdTtlGenNm2 == target.DmdFmDmdTtlGenNm2)
				 && (this.DmdFmDmdTtlGenNm3 == target.DmdFmDmdTtlGenNm3)
				 && (this.DmdTtlGenDefltNm == target.DmdTtlGenDefltNm)
				 && (this.PayTtlGenDefltNm == target.PayTtlGenDefltNm)
				 && (this.DmdDtlUnitPrtDiv == target.DmdDtlUnitPrtDiv)
				 && (this.PayDtlUnitPrtDiv == target.PayDtlUnitPrtDiv)
				 && (this.ThTmDmdZeroPrtDiv == target.ThTmDmdZeroPrtDiv)
				 && (this.DmdDtlPrcZeroPrtDiv == target.DmdDtlPrcZeroPrtDiv)
				 && (this.PayDtlPrcZeroPrtDiv == target.PayDtlPrcZeroPrtDiv)
				 && (this.MinusDmdPrtDiv == target.MinusDmdPrtDiv)
                    --- DEL 2008/06/13 --------------------------------<<<<< */

				 && (this.DmdFmDepoTtlPrtDiv == target.DmdFmDepoTtlPrtDiv)

                 /* --- DEL 2008/06/13 -------------------------------->>>>>
				 && (this.CmplDmdMdGoodsCd1 == target.CmplDmdMdGoodsCd1)
				 && (this.CmplDmdMdGoodsCd2 == target.CmplDmdMdGoodsCd2)
				 && (this.CmplDmdMdGoodsCd3 == target.CmplDmdMdGoodsCd3)
				 && (this.CmplDmdMdGoodsCd4 == target.CmplDmdMdGoodsCd4)
				 && (this.CmplDmdMdGoodsCd5 == target.CmplDmdMdGoodsCd5)
				 && (this.CmplDmdMdGoodsCd6 == target.CmplDmdMdGoodsCd6)
				 && (this.CmplDmdMdGoodsCd7 == target.CmplDmdMdGoodsCd7)
				 && (this.CmplDmdMdGoodsCd8 == target.CmplDmdMdGoodsCd8)
				 && (this.CmplDmdMdGoodsCd9 == target.CmplDmdMdGoodsCd9)
				 && (this.CmplDmdMdGoodsCd10 == target.CmplDmdMdGoodsCd10)
				 && (this.CmplPayMdGoodsCd1 == target.CmplPayMdGoodsCd1)
				 && (this.CmplPayMdGoodsCd2 == target.CmplPayMdGoodsCd2)
				 && (this.CmplPayMdGoodsCd3 == target.CmplPayMdGoodsCd3)
				 && (this.CmplPayMdGoodsCd4 == target.CmplPayMdGoodsCd4)
				 && (this.CmplPayMdGoodsCd5 == target.CmplPayMdGoodsCd5)
				 && (this.CmplPayMdGoodsCd6 == target.CmplPayMdGoodsCd6)
				 && (this.CmplPayMdGoodsCd7 == target.CmplPayMdGoodsCd7)
				 && (this.CmplPayMdGoodsCd8 == target.CmplPayMdGoodsCd8)
				 && (this.CmplPayMdGoodsCd9 == target.CmplPayMdGoodsCd9)
				 && (this.CmplPayMdGoodsCd10 == target.CmplPayMdGoodsCd10)
                    --- DEL 2008/06/13 --------------------------------<<<<< */

                // --- ADD 2008/06/13 -------------------------------->>>>>
				 && (this.DataInputSystem    == target.DataInputSystem)
				 && (this.SlipPrtKind        == target.SlipPrtKind)
				 && (this.SlipPrtSetPaperId  == target.SlipPrtSetPaperId)
				 && (this.SlipComment        == target.SlipComment)
				 && (this.OutputFormFileName == target.OutputFormFileName)
				 && (this.TopMargin          == target.TopMargin)
				 && (this.LeftMargin         == target.LeftMargin)
				 && (this.RightMargin        == target.RightMargin)
				 && (this.BottomMargin       == target.BottomMargin)
				 && (this.CopyCount          == target.CopyCount)
				 && (this.DmdFormTitle2      == target.DmdFormTitle2)
				 && (this.DmdDtlOutlineCode  == target.DmdDtlOutlineCode)
				 && (this.DmdDtlPtnOdrDiv    == target.DmdDtlPtnOdrDiv)
				 && (this.SlipTtlPrtDiv      == target.SlipTtlPrtDiv)
				 && (this.AddDayTtlPrtDiv    == target.AddDayTtlPrtDiv)
				 && (this.CustomerTtlPrtDiv  == target.CustomerTtlPrtDiv)
				 && (this.DtlPrcZeroPrtDiv   == target.DtlPrcZeroPrtDiv)
				 && (this.DepoDtlPrcPrtDiv   == target.DepoDtlPrcPrtDiv)
                 && (this.BillHonorificTtl   == target.BillHonorificTtl)
                // --- ADD 2008/06/13 --------------------------------<<<<< 

                 && (this.ListPricePrtCd == target.ListPricePrtCd)
                 && (this.PartsNoPrtCd == target.PartsNoPrtCd)
                
                 // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
                 && (this.AnnotationPrtCd == target.AnnotationPrtCd)
                 // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

                 // --- ADD  2011/02/16 ---------->>>>>
                  && (this.CoNmPrintOutCd == target.CoNmPrintOutCd)
                 // --- ADD  2011/02/16 ----------<<<<<
				
                // && (this.CellphoneIncOutDiv == target.CellphoneIncOutDiv) // 2007.09.18 hikita del
				 
                 && (this.EnterpriseName == target.EnterpriseName)                 
				 && (this.UpdEmployeeName == target.UpdEmployeeName));
                 
                 
		}

		/// <summary>
		/// 請求書印刷パターンマスタ比較処理
		/// </summary>
		/// <param name="dmdPrtPtn1">
		///                    比較するDmdPrtPtnクラスのインスタンス
		/// </param>
		/// <param name="dmdPrtPtn2">比較するDmdPrtPtnクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DmdPrtPtnクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(DmdPrtPtn dmdPrtPtn1, DmdPrtPtn dmdPrtPtn2)
		{
			return ((dmdPrtPtn1.CreateDateTime == dmdPrtPtn2.CreateDateTime)
				 && (dmdPrtPtn1.UpdateDateTime == dmdPrtPtn2.UpdateDateTime)
				 && (dmdPrtPtn1.EnterpriseCode == dmdPrtPtn2.EnterpriseCode)
				 && (dmdPrtPtn1.FileHeaderGuid == dmdPrtPtn2.FileHeaderGuid)
				 && (dmdPrtPtn1.UpdEmployeeCode == dmdPrtPtn2.UpdEmployeeCode)
				 && (dmdPrtPtn1.UpdAssemblyId1 == dmdPrtPtn2.UpdAssemblyId1)
				 && (dmdPrtPtn1.UpdAssemblyId2 == dmdPrtPtn2.UpdAssemblyId2)
				 && (dmdPrtPtn1.LogicalDeleteCode == dmdPrtPtn2.LogicalDeleteCode)

                 /* --- DEL 2008/06/13 -------------------------------->>>>>
				 && (dmdPrtPtn1.DemandPtnNo == dmdPrtPtn2.DemandPtnNo)
				 && (dmdPrtPtn1.DemandPtnNoNm == dmdPrtPtn2.DemandPtnNoNm)
                    --- DEL 2008/06/13 --------------------------------<<<<< */

                 && (dmdPrtPtn1.DmdTtlFormTitle1 == dmdPrtPtn2.DmdTtlFormTitle1)
				 && (dmdPrtPtn1.DmdTtlFormTitle2 == dmdPrtPtn2.DmdTtlFormTitle2)
				 && (dmdPrtPtn1.DmdTtlFormTitle3 == dmdPrtPtn2.DmdTtlFormTitle3)
				 && (dmdPrtPtn1.DmdTtlFormTitle4 == dmdPrtPtn2.DmdTtlFormTitle4)
				 && (dmdPrtPtn1.DmdTtlFormTitle5 == dmdPrtPtn2.DmdTtlFormTitle5)
				 && (dmdPrtPtn1.DmdTtlFormTitle6 == dmdPrtPtn2.DmdTtlFormTitle6)
				 && (dmdPrtPtn1.DmdTtlFormTitle7 == dmdPrtPtn2.DmdTtlFormTitle7)
				 && (dmdPrtPtn1.DmdTtlFormTitle8 == dmdPrtPtn2.DmdTtlFormTitle8)

				 && (dmdPrtPtn1.DmdTtlSetItemDiv1 == dmdPrtPtn2.DmdTtlSetItemDiv1)
				 && (dmdPrtPtn1.DmdTtlSetItemDiv2 == dmdPrtPtn2.DmdTtlSetItemDiv2)
				 && (dmdPrtPtn1.DmdTtlSetItemDiv3 == dmdPrtPtn2.DmdTtlSetItemDiv3)
				 && (dmdPrtPtn1.DmdTtlSetItemDiv4 == dmdPrtPtn2.DmdTtlSetItemDiv4)
				 && (dmdPrtPtn1.DmdTtlSetItemDiv5 == dmdPrtPtn2.DmdTtlSetItemDiv5)
				 && (dmdPrtPtn1.DmdTtlSetItemDiv6 == dmdPrtPtn2.DmdTtlSetItemDiv6)
				 && (dmdPrtPtn1.DmdTtlSetItemDiv7 == dmdPrtPtn2.DmdTtlSetItemDiv7)
				 && (dmdPrtPtn1.DmdTtlSetItemDiv8 == dmdPrtPtn2.DmdTtlSetItemDiv8)

                /* --- DEL 2008/06/13 -------------------------------->>>>>
                && (dmdPrtPtn1.PayTtlFormTitle1 == dmdPrtPtn2.PayTtlFormTitle1)
                && (dmdPrtPtn1.PayTtlFormTitle2 == dmdPrtPtn2.PayTtlFormTitle2)
                && (dmdPrtPtn1.PayTtlFormTitle3 == dmdPrtPtn2.PayTtlFormTitle3)
                && (dmdPrtPtn1.PayTtlFormTitle4 == dmdPrtPtn2.PayTtlFormTitle4)
                && (dmdPrtPtn1.PayTtlFormTitle5 == dmdPrtPtn2.PayTtlFormTitle5)
                && (dmdPrtPtn1.PayTtlFormTitle6 == dmdPrtPtn2.PayTtlFormTitle6)
                && (dmdPrtPtn1.PayTtlFormTitle7 == dmdPrtPtn2.PayTtlFormTitle7)
                && (dmdPrtPtn1.PayTtlFormTitle8 == dmdPrtPtn2.PayTtlFormTitle8)
                   --- DEL 2008/06/13 --------------------------------<<<<< */
				 && (dmdPrtPtn1.DmdFormTitle == dmdPrtPtn2.DmdFormTitle)

				 //&& (dmdPrtPtn1.PaymentFormTitle == dmdPrtPtn2.PaymentFormTitle)  // DEL 2008/06/13

				 && (dmdPrtPtn1.DmdFormComent1 == dmdPrtPtn2.DmdFormComent1)
				 && (dmdPrtPtn1.DmdFormComent2 == dmdPrtPtn2.DmdFormComent2)
				 && (dmdPrtPtn1.DmdFormComent3 == dmdPrtPtn2.DmdFormComent3)

                 /* --- DEL 2008/06/13 -------------------------------->>>>>
				 && (dmdPrtPtn1.DmdFmDmdTtlGenCd1 == dmdPrtPtn2.DmdFmDmdTtlGenCd1)
				 && (dmdPrtPtn1.DmdFmDmdTtlGenCd2 == dmdPrtPtn2.DmdFmDmdTtlGenCd2)
				 && (dmdPrtPtn1.DmdFmDmdTtlGenCd3 == dmdPrtPtn2.DmdFmDmdTtlGenCd3)
				 && (dmdPrtPtn1.DmdFmPayTtlGenCd1 == dmdPrtPtn2.DmdFmPayTtlGenCd1)
				 && (dmdPrtPtn1.DmdFmPayTtlGenCd2 == dmdPrtPtn2.DmdFmPayTtlGenCd2)
				 && (dmdPrtPtn1.DmdFmPayTtlGenCd3 == dmdPrtPtn2.DmdFmPayTtlGenCd3)
				 && (dmdPrtPtn1.DmdFmDmdTtlGenNm2 == dmdPrtPtn2.DmdFmDmdTtlGenNm2)
				 && (dmdPrtPtn1.DmdFmDmdTtlGenNm3 == dmdPrtPtn2.DmdFmDmdTtlGenNm3)
				 && (dmdPrtPtn1.DmdTtlGenDefltNm == dmdPrtPtn2.DmdTtlGenDefltNm)
				 && (dmdPrtPtn1.PayTtlGenDefltNm == dmdPrtPtn2.PayTtlGenDefltNm)
				 && (dmdPrtPtn1.DmdDtlUnitPrtDiv == dmdPrtPtn2.DmdDtlUnitPrtDiv)
				 && (dmdPrtPtn1.PayDtlUnitPrtDiv == dmdPrtPtn2.PayDtlUnitPrtDiv)
				 && (dmdPrtPtn1.ThTmDmdZeroPrtDiv == dmdPrtPtn2.ThTmDmdZeroPrtDiv)
				 && (dmdPrtPtn1.DmdDtlPrcZeroPrtDiv == dmdPrtPtn2.DmdDtlPrcZeroPrtDiv)
				 && (dmdPrtPtn1.PayDtlPrcZeroPrtDiv == dmdPrtPtn2.PayDtlPrcZeroPrtDiv)
				 && (dmdPrtPtn1.MinusDmdPrtDiv == dmdPrtPtn2.MinusDmdPrtDiv)
                    --- DEL 2008/06/13 --------------------------------<<<<< */

				 && (dmdPrtPtn1.DmdFmDepoTtlPrtDiv == dmdPrtPtn2.DmdFmDepoTtlPrtDiv)

                 /* --- DEL 2008/06/13 -------------------------------->>>>>
				 && (dmdPrtPtn1.CmplDmdMdGoodsCd1 == dmdPrtPtn2.CmplDmdMdGoodsCd1)
				 && (dmdPrtPtn1.CmplDmdMdGoodsCd2 == dmdPrtPtn2.CmplDmdMdGoodsCd2)
				 && (dmdPrtPtn1.CmplDmdMdGoodsCd3 == dmdPrtPtn2.CmplDmdMdGoodsCd3)
				 && (dmdPrtPtn1.CmplDmdMdGoodsCd4 == dmdPrtPtn2.CmplDmdMdGoodsCd4)
				 && (dmdPrtPtn1.CmplDmdMdGoodsCd5 == dmdPrtPtn2.CmplDmdMdGoodsCd5)
				 && (dmdPrtPtn1.CmplDmdMdGoodsCd6 == dmdPrtPtn2.CmplDmdMdGoodsCd6)
				 && (dmdPrtPtn1.CmplDmdMdGoodsCd7 == dmdPrtPtn2.CmplDmdMdGoodsCd7)
				 && (dmdPrtPtn1.CmplDmdMdGoodsCd8 == dmdPrtPtn2.CmplDmdMdGoodsCd8)
				 && (dmdPrtPtn1.CmplDmdMdGoodsCd9 == dmdPrtPtn2.CmplDmdMdGoodsCd9)
				 && (dmdPrtPtn1.CmplDmdMdGoodsCd10 == dmdPrtPtn2.CmplDmdMdGoodsCd10)
				 && (dmdPrtPtn1.CmplPayMdGoodsCd1 == dmdPrtPtn2.CmplPayMdGoodsCd1)
				 && (dmdPrtPtn1.CmplPayMdGoodsCd2 == dmdPrtPtn2.CmplPayMdGoodsCd2)
				 && (dmdPrtPtn1.CmplPayMdGoodsCd3 == dmdPrtPtn2.CmplPayMdGoodsCd3)
				 && (dmdPrtPtn1.CmplPayMdGoodsCd4 == dmdPrtPtn2.CmplPayMdGoodsCd4)
				 && (dmdPrtPtn1.CmplPayMdGoodsCd5 == dmdPrtPtn2.CmplPayMdGoodsCd5)
				 && (dmdPrtPtn1.CmplPayMdGoodsCd6 == dmdPrtPtn2.CmplPayMdGoodsCd6)
				 && (dmdPrtPtn1.CmplPayMdGoodsCd7 == dmdPrtPtn2.CmplPayMdGoodsCd7)
				 && (dmdPrtPtn1.CmplPayMdGoodsCd8 == dmdPrtPtn2.CmplPayMdGoodsCd8)
				 && (dmdPrtPtn1.CmplPayMdGoodsCd9 == dmdPrtPtn2.CmplPayMdGoodsCd9)
				 && (dmdPrtPtn1.CmplPayMdGoodsCd10 == dmdPrtPtn2.CmplPayMdGoodsCd10)
                    --- DEL 2008/06/13 --------------------------------<<<<< */

                 // --- ADD 2008/06/13 -------------------------------->>>>>
                 && (dmdPrtPtn1.DataInputSystem    == dmdPrtPtn2.DataInputSystem)
				 && (dmdPrtPtn1.SlipPrtKind        == dmdPrtPtn2.SlipPrtKind)
				 && (dmdPrtPtn1.SlipPrtSetPaperId  == dmdPrtPtn2.SlipPrtSetPaperId)
				 && (dmdPrtPtn1.SlipComment        == dmdPrtPtn2.SlipComment)
				 && (dmdPrtPtn1.OutputFormFileName == dmdPrtPtn2.OutputFormFileName)
				 && (dmdPrtPtn1.TopMargin          == dmdPrtPtn2.TopMargin)
				 && (dmdPrtPtn1.LeftMargin         == dmdPrtPtn2.LeftMargin)
				 && (dmdPrtPtn1.RightMargin        == dmdPrtPtn2.RightMargin)
				 && (dmdPrtPtn1.BottomMargin       == dmdPrtPtn2.BottomMargin)
				 && (dmdPrtPtn1.CopyCount          == dmdPrtPtn2.CopyCount)
				 && (dmdPrtPtn1.DmdFormTitle2      == dmdPrtPtn2.DmdFormTitle2)
				 && (dmdPrtPtn1.DmdDtlOutlineCode  == dmdPrtPtn2.DmdDtlOutlineCode)
				 && (dmdPrtPtn1.DmdDtlPtnOdrDiv    == dmdPrtPtn2.DmdDtlPtnOdrDiv)
				 && (dmdPrtPtn1.SlipTtlPrtDiv      == dmdPrtPtn2.SlipTtlPrtDiv)
				 && (dmdPrtPtn1.AddDayTtlPrtDiv    == dmdPrtPtn2.AddDayTtlPrtDiv)
				 && (dmdPrtPtn1.CustomerTtlPrtDiv  == dmdPrtPtn2.CustomerTtlPrtDiv)
				 && (dmdPrtPtn1.DtlPrcZeroPrtDiv   == dmdPrtPtn2.DtlPrcZeroPrtDiv)
				 && (dmdPrtPtn1.DepoDtlPrcPrtDiv   == dmdPrtPtn2.DepoDtlPrcPrtDiv)
				 && (dmdPrtPtn1.BillHonorificTtl   == dmdPrtPtn2.BillHonorificTtl)
                 // --- ADD 2008/06/13 --------------------------------<<<<< 

                 && (dmdPrtPtn1.ListPricePrtCd == dmdPrtPtn2.ListPricePrtCd)
                 && (dmdPrtPtn1.PartsNoPrtCd == dmdPrtPtn2.PartsNoPrtCd)

                 // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
                 && (dmdPrtPtn1.AnnotationPrtCd == dmdPrtPtn2.AnnotationPrtCd)
                 // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

                 // --- ADD  2011/02/16 ---------->>>>>
                  && (dmdPrtPtn1.CoNmPrintOutCd == dmdPrtPtn2.CoNmPrintOutCd)
                // --- ADD  2011/02/16 ----------<<<<<
				 
                 // && (dmdPrtPtn1.CellphoneIncOutDiv == dmdPrtPtn2.CellphoneIncOutDiv)  // 2007.09.18 hikita del
				 && (dmdPrtPtn1.EnterpriseName == dmdPrtPtn2.EnterpriseName)                 
				 && (dmdPrtPtn1.UpdEmployeeName == dmdPrtPtn2.UpdEmployeeName));
		}
		/// <summary>
		/// 請求書印刷パターンマスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のDmdPrtPtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DmdPrtPtnクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(DmdPrtPtn target)
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

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			if(this.DemandPtnNo != target.DemandPtnNo)resList.Add("DemandPtnNo");
			if(this.DemandPtnNoNm != target.DemandPtnNoNm)resList.Add("DemandPtnNoNm");
               --- DEL 2008/06/13 --------------------------------<<<<< */

            if (this.DmdTtlFormTitle1 != target.DmdTtlFormTitle1)resList.Add("DmdTtlFormTitle1");
			if(this.DmdTtlFormTitle2 != target.DmdTtlFormTitle2)resList.Add("DmdTtlFormTitle2");
			if(this.DmdTtlFormTitle3 != target.DmdTtlFormTitle3)resList.Add("DmdTtlFormTitle3");
			if(this.DmdTtlFormTitle4 != target.DmdTtlFormTitle4)resList.Add("DmdTtlFormTitle4");
			if(this.DmdTtlFormTitle5 != target.DmdTtlFormTitle5)resList.Add("DmdTtlFormTitle5");
			if(this.DmdTtlFormTitle6 != target.DmdTtlFormTitle6)resList.Add("DmdTtlFormTitle6");
			if(this.DmdTtlFormTitle7 != target.DmdTtlFormTitle7)resList.Add("DmdTtlFormTitle7");
			if(this.DmdTtlFormTitle8 != target.DmdTtlFormTitle8)resList.Add("DmdTtlFormTitle8");

			if(this.DmdTtlSetItemDiv1 != target.DmdTtlSetItemDiv1)resList.Add("DmdTtlSetItemDiv1");
			if(this.DmdTtlSetItemDiv2 != target.DmdTtlSetItemDiv2)resList.Add("DmdTtlSetItemDiv2");
			if(this.DmdTtlSetItemDiv3 != target.DmdTtlSetItemDiv3)resList.Add("DmdTtlSetItemDiv3");
			if(this.DmdTtlSetItemDiv4 != target.DmdTtlSetItemDiv4)resList.Add("DmdTtlSetItemDiv4");
			if(this.DmdTtlSetItemDiv5 != target.DmdTtlSetItemDiv5)resList.Add("DmdTtlSetItemDiv5");
			if(this.DmdTtlSetItemDiv6 != target.DmdTtlSetItemDiv6)resList.Add("DmdTtlSetItemDiv6");
			if(this.DmdTtlSetItemDiv7 != target.DmdTtlSetItemDiv7)resList.Add("DmdTtlSetItemDiv7");
			if(this.DmdTtlSetItemDiv8 != target.DmdTtlSetItemDiv8)resList.Add("DmdTtlSetItemDiv8");

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			if(this.PayTtlFormTitle1 != target.PayTtlFormTitle1)resList.Add("PayTtlFormTitle1");
			if(this.PayTtlFormTitle2 != target.PayTtlFormTitle2)resList.Add("PayTtlFormTitle2");
			if(this.PayTtlFormTitle3 != target.PayTtlFormTitle3)resList.Add("PayTtlFormTitle3");
			if(this.PayTtlFormTitle4 != target.PayTtlFormTitle4)resList.Add("PayTtlFormTitle4");
			if(this.PayTtlFormTitle5 != target.PayTtlFormTitle5)resList.Add("PayTtlFormTitle5");
			if(this.PayTtlFormTitle6 != target.PayTtlFormTitle6)resList.Add("PayTtlFormTitle6");
			if(this.PayTtlFormTitle7 != target.PayTtlFormTitle7)resList.Add("PayTtlFormTitle7");
			if(this.PayTtlFormTitle8 != target.PayTtlFormTitle8)resList.Add("PayTtlFormTitle8");
               --- DEL 2008/06/13 --------------------------------<<<<< */

			if(this.DmdFormTitle != target.DmdFormTitle)resList.Add("DmdFormTitle");

			//if(this.PaymentFormTitle != target.PaymentFormTitle)resList.Add("PaymentFormTitle");  // DEL 2008/06/13

			if(this.DmdFormComent1 != target.DmdFormComent1)resList.Add("DmdFormComent1");
			if(this.DmdFormComent2 != target.DmdFormComent2)resList.Add("DmdFormComent2");
			if(this.DmdFormComent3 != target.DmdFormComent3)resList.Add("DmdFormComent3");

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			if(this.DmdFmDmdTtlGenCd1 != target.DmdFmDmdTtlGenCd1)resList.Add("DmdFmDmdTtlGenCd1");
			if(this.DmdFmDmdTtlGenCd2 != target.DmdFmDmdTtlGenCd2)resList.Add("DmdFmDmdTtlGenCd2");
			if(this.DmdFmDmdTtlGenCd3 != target.DmdFmDmdTtlGenCd3)resList.Add("DmdFmDmdTtlGenCd3");
			if(this.DmdFmPayTtlGenCd1 != target.DmdFmPayTtlGenCd1)resList.Add("DmdFmPayTtlGenCd1");
			if(this.DmdFmPayTtlGenCd2 != target.DmdFmPayTtlGenCd2)resList.Add("DmdFmPayTtlGenCd2");
			if(this.DmdFmPayTtlGenCd3 != target.DmdFmPayTtlGenCd3)resList.Add("DmdFmPayTtlGenCd3");
			if(this.DmdFmDmdTtlGenNm2 != target.DmdFmDmdTtlGenNm2)resList.Add("DmdFmDmdTtlGenNm2");
			if(this.DmdFmDmdTtlGenNm3 != target.DmdFmDmdTtlGenNm3)resList.Add("DmdFmDmdTtlGenNm3");
			if(this.DmdTtlGenDefltNm != target.DmdTtlGenDefltNm)resList.Add("DmdTtlGenDefltNm");
			if(this.PayTtlGenDefltNm != target.PayTtlGenDefltNm)resList.Add("PayTtlGenDefltNm");
			if(this.DmdDtlUnitPrtDiv != target.DmdDtlUnitPrtDiv)resList.Add("DmdDtlUnitPrtDiv");
			if(this.PayDtlUnitPrtDiv != target.PayDtlUnitPrtDiv)resList.Add("PayDtlUnitPrtDiv");
			if(this.ThTmDmdZeroPrtDiv != target.ThTmDmdZeroPrtDiv)resList.Add("ThTmDmdZeroPrtDiv");
			if(this.DmdDtlPrcZeroPrtDiv != target.DmdDtlPrcZeroPrtDiv)resList.Add("DmdDtlPrcZeroPrtDiv");
			if(this.PayDtlPrcZeroPrtDiv != target.PayDtlPrcZeroPrtDiv)resList.Add("PayDtlPrcZeroPrtDiv");
			if(this.MinusDmdPrtDiv != target.MinusDmdPrtDiv)resList.Add("MinusDmdPrtDiv");
               --- DEL 2008/06/13 --------------------------------<<<<< */

			if(this.DmdFmDepoTtlPrtDiv != target.DmdFmDepoTtlPrtDiv)resList.Add("DmdFmDepoTtlPrtDiv");

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			if(this.CmplDmdMdGoodsCd1 != target.CmplDmdMdGoodsCd1)resList.Add("CmplDmdMdGoodsCd1");
			if(this.CmplDmdMdGoodsCd2 != target.CmplDmdMdGoodsCd2)resList.Add("CmplDmdMdGoodsCd2");
			if(this.CmplDmdMdGoodsCd3 != target.CmplDmdMdGoodsCd3)resList.Add("CmplDmdMdGoodsCd3");
			if(this.CmplDmdMdGoodsCd4 != target.CmplDmdMdGoodsCd4)resList.Add("CmplDmdMdGoodsCd4");
			if(this.CmplDmdMdGoodsCd5 != target.CmplDmdMdGoodsCd5)resList.Add("CmplDmdMdGoodsCd5");
			if(this.CmplDmdMdGoodsCd6 != target.CmplDmdMdGoodsCd6)resList.Add("CmplDmdMdGoodsCd6");
			if(this.CmplDmdMdGoodsCd7 != target.CmplDmdMdGoodsCd7)resList.Add("CmplDmdMdGoodsCd7");
			if(this.CmplDmdMdGoodsCd8 != target.CmplDmdMdGoodsCd8)resList.Add("CmplDmdMdGoodsCd8");
			if(this.CmplDmdMdGoodsCd9 != target.CmplDmdMdGoodsCd9)resList.Add("CmplDmdMdGoodsCd9");
			if(this.CmplDmdMdGoodsCd10 != target.CmplDmdMdGoodsCd10)resList.Add("CmplDmdMdGoodsCd10");
			if(this.CmplPayMdGoodsCd1 != target.CmplPayMdGoodsCd1)resList.Add("CmplPayMdGoodsCd1");
			if(this.CmplPayMdGoodsCd2 != target.CmplPayMdGoodsCd2)resList.Add("CmplPayMdGoodsCd2");
			if(this.CmplPayMdGoodsCd3 != target.CmplPayMdGoodsCd3)resList.Add("CmplPayMdGoodsCd3");
			if(this.CmplPayMdGoodsCd4 != target.CmplPayMdGoodsCd4)resList.Add("CmplPayMdGoodsCd4");
			if(this.CmplPayMdGoodsCd5 != target.CmplPayMdGoodsCd5)resList.Add("CmplPayMdGoodsCd5");
			if(this.CmplPayMdGoodsCd6 != target.CmplPayMdGoodsCd6)resList.Add("CmplPayMdGoodsCd6");
			if(this.CmplPayMdGoodsCd7 != target.CmplPayMdGoodsCd7)resList.Add("CmplPayMdGoodsCd7");
			if(this.CmplPayMdGoodsCd8 != target.CmplPayMdGoodsCd8)resList.Add("CmplPayMdGoodsCd8");
			if(this.CmplPayMdGoodsCd9 != target.CmplPayMdGoodsCd9)resList.Add("CmplPayMdGoodsCd9");
			if(this.CmplPayMdGoodsCd10 != target.CmplPayMdGoodsCd10)resList.Add("CmplPayMdGoodsCd10");
               --- DEL 2008/06/13 --------------------------------<<<<< */

            // --- ADD 2008/06/13 -------------------------------->>>>>
			if(this.DataInputSystem    != target.DataInputSystem)    resList.Add("DataInputSystem");
			if(this.SlipPrtKind        != target.SlipPrtKind)        resList.Add("SlipPrtKind");
			if(this.SlipPrtSetPaperId  != target.SlipPrtSetPaperId)  resList.Add("SlipPrtSetPaperId");
			if(this.SlipComment        != target.SlipComment)        resList.Add("SlipComment");
			if(this.OutputFormFileName != target.OutputFormFileName) resList.Add("OutputFormFileName");
			if(this.TopMargin          != target.TopMargin)          resList.Add("TopMargin");
			if(this.LeftMargin         != target.LeftMargin)         resList.Add("LeftMargin");
			if(this.RightMargin        != target.RightMargin)        resList.Add("RightMargin");
			if(this.BottomMargin       != target.BottomMargin)       resList.Add("BottomMargin");
			if(this.CopyCount          != target.CopyCount)          resList.Add("CopyCount");
			if(this.DmdFormTitle2      != target.DmdFormTitle2)      resList.Add("DmdFormTitle2");
			if(this.DmdDtlOutlineCode  != target.DmdDtlOutlineCode)  resList.Add("DmdDtlOutlineCode");
			if(this.DmdDtlPtnOdrDiv    != target.DmdDtlPtnOdrDiv)    resList.Add("DmdDtlPtnOdrDiv");
			if(this.SlipTtlPrtDiv      != target.SlipTtlPrtDiv)      resList.Add("SlipTtlPrtDiv");
			if(this.AddDayTtlPrtDiv    != target.AddDayTtlPrtDiv)    resList.Add("AddDayTtlPrtDiv");
			if(this.CustomerTtlPrtDiv  != target.CustomerTtlPrtDiv)  resList.Add("CustomerTtlPrtDiv");
			if(this.DtlPrcZeroPrtDiv   != target.DtlPrcZeroPrtDiv)   resList.Add("DtlPrcZeroPrtDiv");
			if(this.DepoDtlPrcPrtDiv   != target.DepoDtlPrcPrtDiv)   resList.Add("DepoDtlPrcPrtDiv");
            if (this.BillHonorificTtl  != target.BillHonorificTtl)   resList.Add("BillHonorificTtl");
            // --- ADD 2008/06/13 --------------------------------<<<<< 

            if (this.ListPricePrtCd != target.ListPricePrtCd) resList.Add("ListPricePrtCd");
            if (this.PartsNoPrtCd != target.PartsNoPrtCd) resList.Add("PartsNoPrtCd");

            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            if (this.AnnotationPrtCd != target.AnnotationPrtCd) resList.Add("AnnotationPrtCd");
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            if (this.CoNmPrintOutCd != target.CoNmPrintOutCd) resList.Add("CoNmPrintOutCd");
            // --- ADD  2011/02/16 ----------<<<<<<

			// if(this.CellphoneIncOutDiv != target.CellphoneIncOutDiv)resList.Add("CellphoneIncOutDiv");  // 2007.09.18 hikita del
			if(this.EnterpriseName != target.EnterpriseName)resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
            
			return resList;
		}

		/// <summary>
		/// 請求書印刷パターンマスタ比較処理
		/// </summary>
		/// <param name="dmdPrtPtn1">比較するDmdPrtPtnクラスのインスタンス</param>
		/// <param name="dmdPrtPtn2">比較するDmdPrtPtnクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   DmdPrtPtnクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(DmdPrtPtn dmdPrtPtn1, DmdPrtPtn dmdPrtPtn2)
		{
			ArrayList resList = new ArrayList();
			if(dmdPrtPtn1.CreateDateTime != dmdPrtPtn2.CreateDateTime)resList.Add("CreateDateTime");
			if(dmdPrtPtn1.UpdateDateTime != dmdPrtPtn2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(dmdPrtPtn1.EnterpriseCode != dmdPrtPtn2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(dmdPrtPtn1.FileHeaderGuid != dmdPrtPtn2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(dmdPrtPtn1.UpdEmployeeCode != dmdPrtPtn2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(dmdPrtPtn1.UpdAssemblyId1 != dmdPrtPtn2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(dmdPrtPtn1.UpdAssemblyId2 != dmdPrtPtn2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(dmdPrtPtn1.LogicalDeleteCode != dmdPrtPtn2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			if(dmdPrtPtn1.DemandPtnNo != dmdPrtPtn2.DemandPtnNo)resList.Add("DemandPtnNo");
			if(dmdPrtPtn1.DemandPtnNoNm != dmdPrtPtn2.DemandPtnNoNm)resList.Add("DemandPtnNoNm");
               --- DEL 2008/06/13 --------------------------------<<<<< */

            if(dmdPrtPtn1.DmdTtlFormTitle1 != dmdPrtPtn2.DmdTtlFormTitle1)resList.Add("DmdTtlFormTitle1");
			if(dmdPrtPtn1.DmdTtlFormTitle2 != dmdPrtPtn2.DmdTtlFormTitle2)resList.Add("DmdTtlFormTitle2");
			if(dmdPrtPtn1.DmdTtlFormTitle3 != dmdPrtPtn2.DmdTtlFormTitle3)resList.Add("DmdTtlFormTitle3");
			if(dmdPrtPtn1.DmdTtlFormTitle4 != dmdPrtPtn2.DmdTtlFormTitle4)resList.Add("DmdTtlFormTitle4");
			if(dmdPrtPtn1.DmdTtlFormTitle5 != dmdPrtPtn2.DmdTtlFormTitle5)resList.Add("DmdTtlFormTitle5");
			if(dmdPrtPtn1.DmdTtlFormTitle6 != dmdPrtPtn2.DmdTtlFormTitle6)resList.Add("DmdTtlFormTitle6");
			if(dmdPrtPtn1.DmdTtlFormTitle7 != dmdPrtPtn2.DmdTtlFormTitle7)resList.Add("DmdTtlFormTitle7");
			if(dmdPrtPtn1.DmdTtlFormTitle8 != dmdPrtPtn2.DmdTtlFormTitle8)resList.Add("DmdTtlFormTitle8");

			if(dmdPrtPtn1.DmdTtlSetItemDiv1 != dmdPrtPtn2.DmdTtlSetItemDiv1)resList.Add("DmdTtlSetItemDiv1");
			if(dmdPrtPtn1.DmdTtlSetItemDiv2 != dmdPrtPtn2.DmdTtlSetItemDiv2)resList.Add("DmdTtlSetItemDiv2");
			if(dmdPrtPtn1.DmdTtlSetItemDiv3 != dmdPrtPtn2.DmdTtlSetItemDiv3)resList.Add("DmdTtlSetItemDiv3");
			if(dmdPrtPtn1.DmdTtlSetItemDiv4 != dmdPrtPtn2.DmdTtlSetItemDiv4)resList.Add("DmdTtlSetItemDiv4");
			if(dmdPrtPtn1.DmdTtlSetItemDiv5 != dmdPrtPtn2.DmdTtlSetItemDiv5)resList.Add("DmdTtlSetItemDiv5");
			if(dmdPrtPtn1.DmdTtlSetItemDiv6 != dmdPrtPtn2.DmdTtlSetItemDiv6)resList.Add("DmdTtlSetItemDiv6");
			if(dmdPrtPtn1.DmdTtlSetItemDiv7 != dmdPrtPtn2.DmdTtlSetItemDiv7)resList.Add("DmdTtlSetItemDiv7");
			if(dmdPrtPtn1.DmdTtlSetItemDiv8 != dmdPrtPtn2.DmdTtlSetItemDiv8)resList.Add("DmdTtlSetItemDiv8");

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			if(dmdPrtPtn1.PayTtlFormTitle1 != dmdPrtPtn2.PayTtlFormTitle1)resList.Add("PayTtlFormTitle1");
			if(dmdPrtPtn1.PayTtlFormTitle2 != dmdPrtPtn2.PayTtlFormTitle2)resList.Add("PayTtlFormTitle2");
			if(dmdPrtPtn1.PayTtlFormTitle3 != dmdPrtPtn2.PayTtlFormTitle3)resList.Add("PayTtlFormTitle3");
			if(dmdPrtPtn1.PayTtlFormTitle4 != dmdPrtPtn2.PayTtlFormTitle4)resList.Add("PayTtlFormTitle4");
			if(dmdPrtPtn1.PayTtlFormTitle5 != dmdPrtPtn2.PayTtlFormTitle5)resList.Add("PayTtlFormTitle5");
			if(dmdPrtPtn1.PayTtlFormTitle6 != dmdPrtPtn2.PayTtlFormTitle6)resList.Add("PayTtlFormTitle6");
			if(dmdPrtPtn1.PayTtlFormTitle7 != dmdPrtPtn2.PayTtlFormTitle7)resList.Add("PayTtlFormTitle7");
			if(dmdPrtPtn1.PayTtlFormTitle8 != dmdPrtPtn2.PayTtlFormTitle8)resList.Add("PayTtlFormTitle8");
               --- DEL 2008/06/13 --------------------------------<<<<< */
			if(dmdPrtPtn1.DmdFormTitle != dmdPrtPtn2.DmdFormTitle)resList.Add("DmdFormTitle");

			//if(dmdPrtPtn1.PaymentFormTitle != dmdPrtPtn2.PaymentFormTitle)resList.Add("PaymentFormTitle");  // DEL 2008/06/13

			if(dmdPrtPtn1.DmdFormComent1 != dmdPrtPtn2.DmdFormComent1)resList.Add("DmdFormComent1");
			if(dmdPrtPtn1.DmdFormComent2 != dmdPrtPtn2.DmdFormComent2)resList.Add("DmdFormComent2");
			if(dmdPrtPtn1.DmdFormComent3 != dmdPrtPtn2.DmdFormComent3)resList.Add("DmdFormComent3");

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			if(dmdPrtPtn1.DmdFmDmdTtlGenCd1 != dmdPrtPtn2.DmdFmDmdTtlGenCd1)resList.Add("DmdFmDmdTtlGenCd1");
			if(dmdPrtPtn1.DmdFmDmdTtlGenCd2 != dmdPrtPtn2.DmdFmDmdTtlGenCd2)resList.Add("DmdFmDmdTtlGenCd2");
			if(dmdPrtPtn1.DmdFmDmdTtlGenCd3 != dmdPrtPtn2.DmdFmDmdTtlGenCd3)resList.Add("DmdFmDmdTtlGenCd3");
			if(dmdPrtPtn1.DmdFmPayTtlGenCd1 != dmdPrtPtn2.DmdFmPayTtlGenCd1)resList.Add("DmdFmPayTtlGenCd1");
			if(dmdPrtPtn1.DmdFmPayTtlGenCd2 != dmdPrtPtn2.DmdFmPayTtlGenCd2)resList.Add("DmdFmPayTtlGenCd2");
			if(dmdPrtPtn1.DmdFmPayTtlGenCd3 != dmdPrtPtn2.DmdFmPayTtlGenCd3)resList.Add("DmdFmPayTtlGenCd3");
			if(dmdPrtPtn1.DmdFmDmdTtlGenNm2 != dmdPrtPtn2.DmdFmDmdTtlGenNm2)resList.Add("DmdFmDmdTtlGenNm2");
			if(dmdPrtPtn1.DmdFmDmdTtlGenNm3 != dmdPrtPtn2.DmdFmDmdTtlGenNm3)resList.Add("DmdFmDmdTtlGenNm3");
			if(dmdPrtPtn1.DmdTtlGenDefltNm != dmdPrtPtn2.DmdTtlGenDefltNm)resList.Add("DmdTtlGenDefltNm");
			if(dmdPrtPtn1.PayTtlGenDefltNm != dmdPrtPtn2.PayTtlGenDefltNm)resList.Add("PayTtlGenDefltNm");
			if(dmdPrtPtn1.DmdDtlUnitPrtDiv != dmdPrtPtn2.DmdDtlUnitPrtDiv)resList.Add("DmdDtlUnitPrtDiv");
			if(dmdPrtPtn1.PayDtlUnitPrtDiv != dmdPrtPtn2.PayDtlUnitPrtDiv)resList.Add("PayDtlUnitPrtDiv");
			if(dmdPrtPtn1.ThTmDmdZeroPrtDiv != dmdPrtPtn2.ThTmDmdZeroPrtDiv)resList.Add("ThTmDmdZeroPrtDiv");
			if(dmdPrtPtn1.DmdDtlPrcZeroPrtDiv != dmdPrtPtn2.DmdDtlPrcZeroPrtDiv)resList.Add("DmdDtlPrcZeroPrtDiv");
			if(dmdPrtPtn1.PayDtlPrcZeroPrtDiv != dmdPrtPtn2.PayDtlPrcZeroPrtDiv)resList.Add("PayDtlPrcZeroPrtDiv");
			if(dmdPrtPtn1.MinusDmdPrtDiv != dmdPrtPtn2.MinusDmdPrtDiv)resList.Add("MinusDmdPrtDiv");
               --- DEL 2008/06/13 --------------------------------<<<<< */

			if(dmdPrtPtn1.DmdFmDepoTtlPrtDiv != dmdPrtPtn2.DmdFmDepoTtlPrtDiv)resList.Add("DmdFmDepoTtlPrtDiv");

            /* --- DEL 2008/06/13 -------------------------------->>>>>
			if(dmdPrtPtn1.CmplDmdMdGoodsCd1 != dmdPrtPtn2.CmplDmdMdGoodsCd1)resList.Add("CmplDmdMdGoodsCd1");
			if(dmdPrtPtn1.CmplDmdMdGoodsCd2 != dmdPrtPtn2.CmplDmdMdGoodsCd2)resList.Add("CmplDmdMdGoodsCd2");
			if(dmdPrtPtn1.CmplDmdMdGoodsCd3 != dmdPrtPtn2.CmplDmdMdGoodsCd3)resList.Add("CmplDmdMdGoodsCd3");
			if(dmdPrtPtn1.CmplDmdMdGoodsCd4 != dmdPrtPtn2.CmplDmdMdGoodsCd4)resList.Add("CmplDmdMdGoodsCd4");
			if(dmdPrtPtn1.CmplDmdMdGoodsCd5 != dmdPrtPtn2.CmplDmdMdGoodsCd5)resList.Add("CmplDmdMdGoodsCd5");
			if(dmdPrtPtn1.CmplDmdMdGoodsCd6 != dmdPrtPtn2.CmplDmdMdGoodsCd6)resList.Add("CmplDmdMdGoodsCd6");
			if(dmdPrtPtn1.CmplDmdMdGoodsCd7 != dmdPrtPtn2.CmplDmdMdGoodsCd7)resList.Add("CmplDmdMdGoodsCd7");
			if(dmdPrtPtn1.CmplDmdMdGoodsCd8 != dmdPrtPtn2.CmplDmdMdGoodsCd8)resList.Add("CmplDmdMdGoodsCd8");
			if(dmdPrtPtn1.CmplDmdMdGoodsCd9 != dmdPrtPtn2.CmplDmdMdGoodsCd9)resList.Add("CmplDmdMdGoodsCd9");
			if(dmdPrtPtn1.CmplDmdMdGoodsCd10 != dmdPrtPtn2.CmplDmdMdGoodsCd10)resList.Add("CmplDmdMdGoodsCd10");
			if(dmdPrtPtn1.CmplPayMdGoodsCd1 != dmdPrtPtn2.CmplPayMdGoodsCd1)resList.Add("CmplPayMdGoodsCd1");
			if(dmdPrtPtn1.CmplPayMdGoodsCd2 != dmdPrtPtn2.CmplPayMdGoodsCd2)resList.Add("CmplPayMdGoodsCd2");
			if(dmdPrtPtn1.CmplPayMdGoodsCd3 != dmdPrtPtn2.CmplPayMdGoodsCd3)resList.Add("CmplPayMdGoodsCd3");
			if(dmdPrtPtn1.CmplPayMdGoodsCd4 != dmdPrtPtn2.CmplPayMdGoodsCd4)resList.Add("CmplPayMdGoodsCd4");
			if(dmdPrtPtn1.CmplPayMdGoodsCd5 != dmdPrtPtn2.CmplPayMdGoodsCd5)resList.Add("CmplPayMdGoodsCd5");
			if(dmdPrtPtn1.CmplPayMdGoodsCd6 != dmdPrtPtn2.CmplPayMdGoodsCd6)resList.Add("CmplPayMdGoodsCd6");
			if(dmdPrtPtn1.CmplPayMdGoodsCd7 != dmdPrtPtn2.CmplPayMdGoodsCd7)resList.Add("CmplPayMdGoodsCd7");
			if(dmdPrtPtn1.CmplPayMdGoodsCd8 != dmdPrtPtn2.CmplPayMdGoodsCd8)resList.Add("CmplPayMdGoodsCd8");
			if(dmdPrtPtn1.CmplPayMdGoodsCd9 != dmdPrtPtn2.CmplPayMdGoodsCd9)resList.Add("CmplPayMdGoodsCd9");
			if(dmdPrtPtn1.CmplPayMdGoodsCd10 != dmdPrtPtn2.CmplPayMdGoodsCd10)resList.Add("CmplPayMdGoodsCd10");
               --- DEL 2008/06/13 --------------------------------<<<<< */

            // --- ADD 2008/06/13 -------------------------------->>>>>
			if(dmdPrtPtn1.DataInputSystem    != dmdPrtPtn2.DataInputSystem)    resList.Add("DataInputSystem");
			if(dmdPrtPtn1.SlipPrtKind        != dmdPrtPtn2.SlipPrtKind)        resList.Add("SlipPrtKind");
			if(dmdPrtPtn1.SlipPrtSetPaperId  != dmdPrtPtn2.SlipPrtSetPaperId)  resList.Add("SlipPrtSetPaperId");
			if(dmdPrtPtn1.SlipComment        != dmdPrtPtn2.SlipComment)        resList.Add("SlipComment");
			if(dmdPrtPtn1.OutputFormFileName != dmdPrtPtn2.OutputFormFileName) resList.Add("OutputFormFileName");
			if(dmdPrtPtn1.TopMargin          != dmdPrtPtn2.TopMargin)          resList.Add("TopMargin");
			if(dmdPrtPtn1.LeftMargin         != dmdPrtPtn2.LeftMargin)         resList.Add("LeftMargin");
			if(dmdPrtPtn1.RightMargin        != dmdPrtPtn2.RightMargin)        resList.Add("RightMargin");
			if(dmdPrtPtn1.BottomMargin       != dmdPrtPtn2.BottomMargin)       resList.Add("BottomMargin");
			if(dmdPrtPtn1.CopyCount          != dmdPrtPtn2.CopyCount)          resList.Add("CopyCount");
			if(dmdPrtPtn1.DmdFormTitle2      != dmdPrtPtn2.DmdFormTitle2)      resList.Add("DmdFormTitle2");
			if(dmdPrtPtn1.DmdDtlOutlineCode  != dmdPrtPtn2.DmdDtlOutlineCode)  resList.Add("DmdDtlOutlineCode");
			if(dmdPrtPtn1.DmdDtlPtnOdrDiv    != dmdPrtPtn2.DmdDtlPtnOdrDiv)    resList.Add("DmdDtlPtnOdrDiv");
			if(dmdPrtPtn1.SlipTtlPrtDiv      != dmdPrtPtn2.SlipTtlPrtDiv)      resList.Add("SlipTtlPrtDiv");
			if(dmdPrtPtn1.AddDayTtlPrtDiv    != dmdPrtPtn2.AddDayTtlPrtDiv)    resList.Add("AddDayTtlPrtDiv");
			if(dmdPrtPtn1.CustomerTtlPrtDiv  != dmdPrtPtn2.CustomerTtlPrtDiv)  resList.Add("CustomerTtlPrtDiv");
			if(dmdPrtPtn1.DtlPrcZeroPrtDiv   != dmdPrtPtn2.DtlPrcZeroPrtDiv)   resList.Add("DtlPrcZeroPrtDiv");
			if(dmdPrtPtn1.DepoDtlPrcPrtDiv   != dmdPrtPtn2.DepoDtlPrcPrtDiv)   resList.Add("DepoDtlPrcPrtDiv");
            if (dmdPrtPtn1.BillHonorificTtl  != dmdPrtPtn2.BillHonorificTtl)   resList.Add("BillHonorificTtl");
            // --- ADD 2008/06/13 --------------------------------<<<<< 

            if (dmdPrtPtn1.ListPricePrtCd != dmdPrtPtn2.ListPricePrtCd) resList.Add("ListPricePrtCd");
            if (dmdPrtPtn1.PartsNoPrtCd != dmdPrtPtn2.PartsNoPrtCd) resList.Add("PartsNoPrtCd");

            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            if (dmdPrtPtn1.AnnotationPrtCd != dmdPrtPtn2.AnnotationPrtCd) resList.Add("AnnotationPrtCd");
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            if (dmdPrtPtn1.CoNmPrintOutCd != dmdPrtPtn2.CoNmPrintOutCd) resList.Add("CoNmPrintOutCd");
            // --- ADD  2011/02/16 ----------<<<<<

			// if(dmdPrtPtn1.CellphoneIncOutDiv != dmdPrtPtn2.CellphoneIncOutDiv)resList.Add("CellphoneIncOutDiv");   // 2007.09.18 hikita del
			if(dmdPrtPtn1.EnterpriseName != dmdPrtPtn2.EnterpriseName)resList.Add("EnterpriseName");
			if(dmdPrtPtn1.UpdEmployeeName != dmdPrtPtn2.UpdEmployeeName)resList.Add("UpdEmployeeName");            

			return resList;
		}
	}
}
