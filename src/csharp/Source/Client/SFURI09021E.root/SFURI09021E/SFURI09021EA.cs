using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SlipPrtSet
    /// <summary>
    ///                      伝票印刷設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   伝票印刷設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2006/12/08  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   2007.12.17  30167 上野　弘貴</br>
	/// <br>                      ・DC.NS対応</br>
    /// <br>Update Note      : 2009/12/31  張凱</br>
    /// <br>                        PM.NS-5-A・PM.NS保守依頼④</br>
    /// <br>                        伝票備考桁数、伝票備考２桁数、伝票備考３桁数を追加対応</br>
    /// <br>Update Note      : 2010/08/06  caowj</br>
    /// <br>                        PM.NS1012</br>
    /// <br>                        伝票印刷ﾊﾟﾀｰﾝ設定対応</br>
    /// <br>Update Note      : 2011/02/16  鄧潘ハン</br>
    /// <br>                        自社名称１，２が縦倍角になっていない不具合の対応</br>
    /// <br>Update Note      :   2011/7/19  chenyd</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   SCM回答マーク印字区分</br>
    /// <br>                 :   通常発行マーク</br>
    /// <br>                 :   SCM手動回答マーク</br>
    /// <br>                 :   SCM自動回答マーク</br>
    /// </remarks>
    public class SlipPrtSet
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

		/// <summary>データ入力システム</summary>
		/// <remarks>0:共通,1:整備,2:鈑金,3:車販</remarks>
		private Int32 _dataInputSystem;

		/// <summary>伝票印刷種別</summary>
		/// <remarks>10:見積書,20:指示書（注文書）,21:承り書,30:納品書,40:返品伝票,100:ワークシート,110:ボディ寸法図</remarks>
		private Int32 _slipPrtKind;

		/// <summary>伝票印刷設定用帳票ID</summary>
		/// <remarks>伝票印刷設定用</remarks>
		private string _slipPrtSetPaperId = "";

		/// <summary>伝票コメント</summary>
		private string _slipComment = "";

		/// <summary>出力プログラムID</summary>
		private string _outputPgId = "";

		/// <summary>出力プログラムクラスID</summary>
		private string _outputPgClassId = "";

		/// <summary>出力ファイル名</summary>
		/// <remarks>フォームファイルID or フォーマットファイルID</remarks>
		private string _outputFormFileName = "";

		/// <summary>自社名印刷区分</summary>
		/// <remarks>0:自社名印字　1:拠点名印字　2:ビットマップを印字　3:印字しない</remarks>
		private Int32 _enterpriseNamePrtCd;

		/// <summary>印刷部数</summary>
		/// <remarks>1～99</remarks>
		private Int32 _prtCirculation;

		/// <summary>伝票用紙区分</summary>
		/// <remarks>0:白紙,1:専用伝票,2:連帳</remarks>
		private Int32 _slipFormCd;

		/// <summary>出力確認メッセージ</summary>
		private string _outConfimationMsg = "";

		/// <summary>オプションコード</summary>
		/// <remarks>ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ</remarks>
		private string _optionCode = "";

		/// <summary>上余白</summary>
		/// <remarks>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</remarks>
		private Double _topMargin;

		/// <summary>左余白</summary>
		/// <remarks>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</remarks>
		private Double _leftMargin;

		/// <summary>右余白</summary>
		private Double _rightMargin;

		/// <summary>下余白</summary>
		private Double _bottomMargin;

		/// <summary>印刷プレビュ有無区分</summary>
		/// <remarks>0:無し,1:有り</remarks>
		private Int32 _prtPreviewExistCode;

		/// <summary>出力用途</summary>
		/// <remarks>自由に設定可能</remarks>
		private Int32 _outputPurpose;

		/// <summary>伝票タイプ別列ID1</summary>
		private string _eachSlipTypeColId1 = "";

		/// <summary>伝票タイプ別列名称1</summary>
		private string _eachSlipTypeColNm1 = "";

		/// <summary>伝票タイプ別列印字区分1</summary>
		/// <remarks>0:印字しない,1:印字する</remarks>
		private Int32 _eachSlipTypeColPrt1;

		/// <summary>伝票タイプ別列ID2</summary>
		private string _eachSlipTypeColId2 = "";

		/// <summary>伝票タイプ別列名称2</summary>
		private string _eachSlipTypeColNm2 = "";

		/// <summary>伝票タイプ別列印字区分2</summary>
		/// <remarks>0:印字しない,1:印字する</remarks>
		private Int32 _eachSlipTypeColPrt2;

		/// <summary>伝票タイプ別列ID3</summary>
		private string _eachSlipTypeColId3 = "";

		/// <summary>伝票タイプ別列名称3</summary>
		private string _eachSlipTypeColNm3 = "";

		/// <summary>伝票タイプ別列印字区分3</summary>
		/// <remarks>0:印字しない,1:印字する</remarks>
		private Int32 _eachSlipTypeColPrt3;

		/// <summary>伝票タイプ別列ID4</summary>
		private string _eachSlipTypeColId4 = "";

		/// <summary>伝票タイプ別列名称4</summary>
		private string _eachSlipTypeColNm4 = "";

		/// <summary>伝票タイプ別列印字区分4</summary>
		/// <remarks>0:印字しない,1:印字する</remarks>
		private Int32 _eachSlipTypeColPrt4;

		/// <summary>伝票タイプ別列ID5</summary>
		private string _eachSlipTypeColId5 = "";

		/// <summary>伝票タイプ別列名称5</summary>
		private string _eachSlipTypeColNm5 = "";

		/// <summary>伝票タイプ別列印字区分5</summary>
		/// <remarks>0:印字しない,1:印字する</remarks>
		private Int32 _eachSlipTypeColPrt5;

		/// <summary>伝票タイプ別列ID6</summary>
		private string _eachSlipTypeColId6 = "";

		/// <summary>伝票タイプ別列名称6</summary>
		private string _eachSlipTypeColNm6 = "";

		/// <summary>伝票タイプ別列印字区分6</summary>
		/// <remarks>0:印字しない,1:印字する</remarks>
		private Int32 _eachSlipTypeColPrt6;

		/// <summary>伝票タイプ別列ID7</summary>
		private string _eachSlipTypeColId7 = "";

		/// <summary>伝票タイプ別列名称7</summary>
		private string _eachSlipTypeColNm7 = "";

		/// <summary>伝票タイプ別列印字区分7</summary>
		/// <remarks>0:印字しない,1:印字する</remarks>
		private Int32 _eachSlipTypeColPrt7;

		/// <summary>伝票タイプ別列ID8</summary>
		private string _eachSlipTypeColId8 = "";

		/// <summary>伝票タイプ別列名称8</summary>
		private string _eachSlipTypeColNm8 = "";

		/// <summary>伝票タイプ別列印字区分8</summary>
		/// <remarks>0:印字しない,1:印字する</remarks>
		private Int32 _eachSlipTypeColPrt8;

		/// <summary>伝票タイプ別列ID9</summary>
		private string _eachSlipTypeColId9 = "";

		/// <summary>伝票タイプ別列名称9</summary>
		private string _eachSlipTypeColNm9 = "";

		/// <summary>伝票タイプ別列印字区分9</summary>
		/// <remarks>0:印字しない,1:印字する</remarks>
		private Int32 _eachSlipTypeColPrt9;

		/// <summary>伝票タイプ別列ID10</summary>
		private string _eachSlipTypeColId10 = "";

		/// <summary>伝票タイプ別列名称10</summary>
		private string _eachSlipTypeColNm10 = "";

		/// <summary>伝票タイプ別列印字区分10</summary>
		/// <remarks>0:印字しない,1:印字する</remarks>
		private Int32 _eachSlipTypeColPrt10;

		/// <summary>伝票フォント名称</summary>
		private string _slipFontName = "";

		/// <summary>伝票フォントサイズ</summary>
		/// <remarks>0:標準,1:大</remarks>
		private Int32 _slipFontSize;

		/// <summary>伝票フォントスタイル</summary>
		/// <remarks>0:標準,1:太字</remarks>
		private Int32 _slipFontStyle;

		/// <summary>伝票基準色赤1</summary>
		private Int32 _slipBaseColorRed1;

		/// <summary>伝票基準色緑1</summary>
		private Int32 _slipBaseColorGrn1;

		/// <summary>伝票基準色青1</summary>
		private Int32 _slipBaseColorBlu1;

		/// <summary>伝票基準色赤2</summary>
		private Int32 _slipBaseColorRed2;

		/// <summary>伝票基準色緑2</summary>
		private Int32 _slipBaseColorGrn2;

		/// <summary>伝票基準色青2</summary>
		private Int32 _slipBaseColorBlu2;

		/// <summary>伝票基準色赤3</summary>
		private Int32 _slipBaseColorRed3;

		/// <summary>伝票基準色緑3</summary>
		private Int32 _slipBaseColorGrn3;

		/// <summary>伝票基準色青3</summary>
		private Int32 _slipBaseColorBlu3;

		/// <summary>伝票基準色赤4</summary>
		private Int32 _slipBaseColorRed4;

		/// <summary>伝票基準色緑4</summary>
		private Int32 _slipBaseColorGrn4;

		/// <summary>伝票基準色青4</summary>
		private Int32 _slipBaseColorBlu4;

		/// <summary>伝票基準色赤5</summary>
		private Int32 _slipBaseColorRed5;

		/// <summary>伝票基準色緑5</summary>
		private Int32 _slipBaseColorGrn5;

		/// <summary>伝票基準色青5</summary>
		private Int32 _slipBaseColorBlu5;

		/// <summary>複写枚数</summary>
		private Int32 _copyCount;

		/// <summary>タイトル1</summary>
		private string _titleName1 = "";

		/// <summary>タイトル2</summary>
		private string _titleName2 = "";

		/// <summary>タイトル3</summary>
		private string _titleName3 = "";

		/// <summary>タイトル4</summary>
		private string _titleName4 = "";

		/// <summary>特殊用途1</summary>
		/// <remarks>伝票種別置換項目(例 10,20,30等を設定）　＊見積書を納品書で印字する場合等に使用</remarks>
		private string _specialPurpose1 = "";

		/// <summary>特殊用途2</summary>
		/// <remarks>自由に設定可能（特殊な伝票の場合に使用）＊マスメン不可</remarks>
		private string _specialPurpose2 = "";

		/// <summary>特殊用途3</summary>
		/// <remarks>自由に設定可能（特殊な伝票の場合に使用）＊マスメン不可</remarks>
		private string _specialPurpose3 = "";

		/// <summary>特殊用途4</summary>
		/// <remarks>自由に設定可能（特殊な伝票の場合に使用）＊マスメン不可</remarks>
		private string _specialPurpose4 = "";

		/// <summary>タイトル1-2</summary>
		private string _titleName102 = "";

		/// <summary>タイトル1-3</summary>
		private string _titleName103 = "";

		/// <summary>タイトル1-4</summary>
		private string _titleName104 = "";

		/// <summary>タイトル1-5</summary>
		private string _titleName105 = "";

		/// <summary>タイトル2-2</summary>
		private string _titleName202 = "";

		/// <summary>タイトル2-3</summary>
		private string _titleName203 = "";

		/// <summary>タイトル2-4</summary>
		private string _titleName204 = "";

		/// <summary>タイトル2-5</summary>
		private string _titleName205 = "";

		/// <summary>タイトル3-2</summary>
		private string _titleName302 = "";

		/// <summary>タイトル3-3</summary>
		private string _titleName303 = "";

		/// <summary>タイトル3-4</summary>
		private string _titleName304 = "";

		/// <summary>タイトル3-5</summary>
		private string _titleName305 = "";

		/// <summary>タイトル4-2</summary>
		private string _titleName402 = "";

		/// <summary>タイトル4-3</summary>
		private string _titleName403 = "";

		/// <summary>タイトル4-4</summary>
		private string _titleName404 = "";

		/// <summary>タイトル4-5</summary>
		private string _titleName405 = "";

		/// <summary>備考１</summary>
		private string _note1 = "";

		/// <summary>備考２</summary>
		private string _note2 = "";

		/// <summary>備考３</summary>
		private string _note3 = "";

		/// <summary>QRコード印字区分</summary>
		/// <remarks>0:非印字,1:印字</remarks>
		private Int32 _qRCodePrintDivCd;

		/// <summary>時刻印字区分</summary>
		/// <remarks>0:非印字,1:印字</remarks>
		private Int32 _timePrintDivCd;

		/// <summary>再発行マーク</summary>
		/// <remarks>全角３文字まで</remarks>
		private string _reissueMark = "";

		/// <summary>参考消費税区分</summary>
		/// <remarks>0:非印字,1:印字</remarks>
		private Int32 _refConsTaxDivCd;

		/// <summary>参考消費税印字名称</summary>
		/// <remarks>全角５文字まで</remarks>
		private string _refConsTaxPrtNm = "";

		/// <summary>明細行数</summary>
		/// <remarks>MAX999</remarks>
		private Int32 _detailRowCount;

		/// <summary>敬称</summary>
		private string _honorificTitle = "";

        // --- ADD 2009/12/31 ---------->>>>>
        /// <summary>伝票備考桁数</summary>
        private Int32 _slipNoteCharCnt;

        /// <summary>伝票備考２桁数</summary>
        private Int32 _slipNote2CharCnt;

        /// <summary>伝票備考３桁数</summary>
        private Int32 _slipNote3CharCnt;
        // --- ADD 2009/12/31 ----------<<<<<

        /// <summary>消費税印字区分</summary>
        /// /// <remarks>0:非印字 1:印字</remarks>
        private Int32 _consTaxPrtCd;

		/// <summary>企業名称</summary>
		private string _enterpriseName = "";

		/// <summary>更新従業員名称</summary>
		private string _updEmployeeName = "";

		/// <summary>データ入力システム名称</summary>
		/// <remarks>共通,整備,鈑金,車販</remarks>
		private string _dataInputSystemName = "";

        // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>更新フラグ</summary>
        private Int32 _updateFlag;
        // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

        // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>
        /// <summary>自社名印字拡大区分</summary>
        private Int32 _entNmPrtExpDiv;
        // ---ADD 2011/02/16 ------------------------------------------------------------<<<<<<

        // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
        /// <summary>SCM回答マーク印字区分</summary>
        /// <remarks>0:しない,1:する</remarks>
        private Int32 _sCMAnsMarkPrtDiv;

        /// <summary>通常発行マーク</summary>
        private string _normalPrtMark = "";

        /// <summary>SCM手動回答マーク</summary>
        private string _sCMManualAnsMark = "";

        /// <summary>SCM自動回答マーク</summary>
        private string _sCMAutoAnsMark = "";
        // ---ADD 2011/07/19 ------------------------------------------------------------<<<<<<
        
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

		/// public propaty name  :  DataInputSystem
		/// <summary>データ入力システムプロパティ</summary>
		/// <value>0:共通,1:整備,2:鈑金,3:車販</value>
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

		/// public propaty name  :  SlipPrtKind
		/// <summary>伝票印刷種別プロパティ</summary>
		/// <value>10:見積書,20:指示書（注文書）,21:承り書,30:納品書,40:返品伝票,100:ワークシート,110:ボディ寸法図</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票印刷種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipPrtKind
		{
			get{return _slipPrtKind;}
			set{_slipPrtKind = value;}
		}

		/// public propaty name  :  SlipPrtSetPaperId
		/// <summary>伝票印刷設定用帳票IDプロパティ</summary>
		/// <value>伝票印刷設定用</value>
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

		/// public propaty name  :  SlipComment
		/// <summary>伝票コメントプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票コメントプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipComment
		{
			get{return _slipComment;}
			set{_slipComment = value;}
		}

		/// public propaty name  :  OutputPgId
		/// <summary>出力プログラムIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力プログラムIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutputPgId
		{
			get{return _outputPgId;}
			set{_outputPgId = value;}
		}

		/// public propaty name  :  OutputPgClassId
		/// <summary>出力プログラムクラスIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力プログラムクラスIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutputPgClassId
		{
			get{return _outputPgClassId;}
			set{_outputPgClassId = value;}
		}

		/// public propaty name  :  OutputFormFileName
		/// <summary>出力ファイル名プロパティ</summary>
		/// <value>フォームファイルID or フォーマットファイルID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力ファイル名プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutputFormFileName
		{
			get{return _outputFormFileName;}
			set{_outputFormFileName = value;}
		}

		/// public propaty name  :  EnterpriseNamePrtCd
		/// <summary>自社名印刷区分プロパティ</summary>
		/// <value>0:自社名印字　1:拠点名印字　2:ビットマップを印字　3:印字しない</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自社名印刷区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EnterpriseNamePrtCd
		{
			get{return _enterpriseNamePrtCd;}
			set{_enterpriseNamePrtCd = value;}
		}

		/// public propaty name  :  PrtCirculation
		/// <summary>印刷部数プロパティ</summary>
		/// <value>1～99</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷部数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrtCirculation
		{
			get{return _prtCirculation;}
			set{_prtCirculation = value;}
		}

		/// public propaty name  :  SlipFormCd
		/// <summary>伝票用紙区分プロパティ</summary>
		/// <value>0:白紙,1:専用伝票,2:連帳</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票用紙区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipFormCd
		{
			get{return _slipFormCd;}
			set{_slipFormCd = value;}
		}

		/// public propaty name  :  OutConfimationMsg
		/// <summary>出力確認メッセージプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力確認メッセージプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutConfimationMsg
		{
			get{return _outConfimationMsg;}
			set{_outConfimationMsg = value;}
		}

		/// public propaty name  :  OptionCode
		/// <summary>オプションコードプロパティ</summary>
		/// <value>ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   オプションコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OptionCode
		{
			get{return _optionCode;}
			set{_optionCode = value;}
		}

		/// public propaty name  :  TopMargin
		/// <summary>上余白プロパティ</summary>
		/// <value>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   上余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double TopMargin
		{
			get{return _topMargin;}
			set{_topMargin = value;}
		}

		/// public propaty name  :  LeftMargin
		/// <summary>左余白プロパティ</summary>
		/// <value>cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   左余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double LeftMargin
		{
			get{return _leftMargin;}
			set{_leftMargin = value;}
		}

		/// public propaty name  :  RightMargin
		/// <summary>右余白プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   右余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double RightMargin
		{
			get{return _rightMargin;}
			set{_rightMargin = value;}
		}

		/// public propaty name  :  BottomMargin
		/// <summary>下余白プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   下余白プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double BottomMargin
		{
			get{return _bottomMargin;}
			set{_bottomMargin = value;}
		}

		/// public propaty name  :  PrtPreviewExistCode
		/// <summary>印刷プレビュ有無区分プロパティ</summary>
		/// <value>0:無し,1:有り</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印刷プレビュ有無区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrtPreviewExistCode
		{
			get{return _prtPreviewExistCode;}
			set{_prtPreviewExistCode = value;}
		}

		/// public propaty name  :  OutputPurpose
		/// <summary>出力用途プロパティ</summary>
		/// <value>自由に設定可能</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力用途プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 OutputPurpose
		{
			get{return _outputPurpose;}
			set{_outputPurpose = value;}
		}

		/// public propaty name  :  EachSlipTypeColId1
		/// <summary>伝票タイプ別列ID1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列ID1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColId1
		{
			get{return _eachSlipTypeColId1;}
			set{_eachSlipTypeColId1 = value;}
		}

		/// public propaty name  :  EachSlipTypeColNm1
		/// <summary>伝票タイプ別列名称1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列名称1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColNm1
		{
			get{return _eachSlipTypeColNm1;}
			set{_eachSlipTypeColNm1 = value;}
		}

		/// public propaty name  :  EachSlipTypeColPrt1
		/// <summary>伝票タイプ別列印字区分1プロパティ</summary>
		/// <value>0:印字しない,1:印字する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列印字区分1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EachSlipTypeColPrt1
		{
			get{return _eachSlipTypeColPrt1;}
			set{_eachSlipTypeColPrt1 = value;}
		}

		/// public propaty name  :  EachSlipTypeColId2
		/// <summary>伝票タイプ別列ID2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列ID2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColId2
		{
			get{return _eachSlipTypeColId2;}
			set{_eachSlipTypeColId2 = value;}
		}

		/// public propaty name  :  EachSlipTypeColNm2
		/// <summary>伝票タイプ別列名称2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列名称2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColNm2
		{
			get{return _eachSlipTypeColNm2;}
			set{_eachSlipTypeColNm2 = value;}
		}

		/// public propaty name  :  EachSlipTypeColPrt2
		/// <summary>伝票タイプ別列印字区分2プロパティ</summary>
		/// <value>0:印字しない,1:印字する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列印字区分2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EachSlipTypeColPrt2
		{
			get{return _eachSlipTypeColPrt2;}
			set{_eachSlipTypeColPrt2 = value;}
		}

		/// public propaty name  :  EachSlipTypeColId3
		/// <summary>伝票タイプ別列ID3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列ID3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColId3
		{
			get{return _eachSlipTypeColId3;}
			set{_eachSlipTypeColId3 = value;}
		}

		/// public propaty name  :  EachSlipTypeColNm3
		/// <summary>伝票タイプ別列名称3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列名称3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColNm3
		{
			get{return _eachSlipTypeColNm3;}
			set{_eachSlipTypeColNm3 = value;}
		}

		/// public propaty name  :  EachSlipTypeColPrt3
		/// <summary>伝票タイプ別列印字区分3プロパティ</summary>
		/// <value>0:印字しない,1:印字する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列印字区分3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EachSlipTypeColPrt3
		{
			get{return _eachSlipTypeColPrt3;}
			set{_eachSlipTypeColPrt3 = value;}
		}

		/// public propaty name  :  EachSlipTypeColId4
		/// <summary>伝票タイプ別列ID4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列ID4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColId4
		{
			get{return _eachSlipTypeColId4;}
			set{_eachSlipTypeColId4 = value;}
		}

		/// public propaty name  :  EachSlipTypeColNm4
		/// <summary>伝票タイプ別列名称4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列名称4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColNm4
		{
			get{return _eachSlipTypeColNm4;}
			set{_eachSlipTypeColNm4 = value;}
		}

		/// public propaty name  :  EachSlipTypeColPrt4
		/// <summary>伝票タイプ別列印字区分4プロパティ</summary>
		/// <value>0:印字しない,1:印字する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列印字区分4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EachSlipTypeColPrt4
		{
			get{return _eachSlipTypeColPrt4;}
			set{_eachSlipTypeColPrt4 = value;}
		}

		/// public propaty name  :  EachSlipTypeColId5
		/// <summary>伝票タイプ別列ID5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列ID5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColId5
		{
			get{return _eachSlipTypeColId5;}
			set{_eachSlipTypeColId5 = value;}
		}

		/// public propaty name  :  EachSlipTypeColNm5
		/// <summary>伝票タイプ別列名称5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列名称5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColNm5
		{
			get{return _eachSlipTypeColNm5;}
			set{_eachSlipTypeColNm5 = value;}
		}

		/// public propaty name  :  EachSlipTypeColPrt5
		/// <summary>伝票タイプ別列印字区分5プロパティ</summary>
		/// <value>0:印字しない,1:印字する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列印字区分5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EachSlipTypeColPrt5
		{
			get{return _eachSlipTypeColPrt5;}
			set{_eachSlipTypeColPrt5 = value;}
		}

		/// public propaty name  :  EachSlipTypeColId6
		/// <summary>伝票タイプ別列ID6プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列ID6プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColId6
		{
			get{return _eachSlipTypeColId6;}
			set{_eachSlipTypeColId6 = value;}
		}

		/// public propaty name  :  EachSlipTypeColNm6
		/// <summary>伝票タイプ別列名称6プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列名称6プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColNm6
		{
			get{return _eachSlipTypeColNm6;}
			set{_eachSlipTypeColNm6 = value;}
		}

		/// public propaty name  :  EachSlipTypeColPrt6
		/// <summary>伝票タイプ別列印字区分6プロパティ</summary>
		/// <value>0:印字しない,1:印字する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列印字区分6プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EachSlipTypeColPrt6
		{
			get{return _eachSlipTypeColPrt6;}
			set{_eachSlipTypeColPrt6 = value;}
		}

		/// public propaty name  :  EachSlipTypeColId7
		/// <summary>伝票タイプ別列ID7プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列ID7プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColId7
		{
			get{return _eachSlipTypeColId7;}
			set{_eachSlipTypeColId7 = value;}
		}

		/// public propaty name  :  EachSlipTypeColNm7
		/// <summary>伝票タイプ別列名称7プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列名称7プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColNm7
		{
			get{return _eachSlipTypeColNm7;}
			set{_eachSlipTypeColNm7 = value;}
		}

		/// public propaty name  :  EachSlipTypeColPrt7
		/// <summary>伝票タイプ別列印字区分7プロパティ</summary>
		/// <value>0:印字しない,1:印字する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列印字区分7プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EachSlipTypeColPrt7
		{
			get{return _eachSlipTypeColPrt7;}
			set{_eachSlipTypeColPrt7 = value;}
		}

		/// public propaty name  :  EachSlipTypeColId8
		/// <summary>伝票タイプ別列ID8プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列ID8プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColId8
		{
			get{return _eachSlipTypeColId8;}
			set{_eachSlipTypeColId8 = value;}
		}

		/// public propaty name  :  EachSlipTypeColNm8
		/// <summary>伝票タイプ別列名称8プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列名称8プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColNm8
		{
			get{return _eachSlipTypeColNm8;}
			set{_eachSlipTypeColNm8 = value;}
		}

		/// public propaty name  :  EachSlipTypeColPrt8
		/// <summary>伝票タイプ別列印字区分8プロパティ</summary>
		/// <value>0:印字しない,1:印字する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列印字区分8プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EachSlipTypeColPrt8
		{
			get{return _eachSlipTypeColPrt8;}
			set{_eachSlipTypeColPrt8 = value;}
		}

		/// public propaty name  :  EachSlipTypeColId9
		/// <summary>伝票タイプ別列ID9プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列ID9プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColId9
		{
			get{return _eachSlipTypeColId9;}
			set{_eachSlipTypeColId9 = value;}
		}

		/// public propaty name  :  EachSlipTypeColNm9
		/// <summary>伝票タイプ別列名称9プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列名称9プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColNm9
		{
			get{return _eachSlipTypeColNm9;}
			set{_eachSlipTypeColNm9 = value;}
		}

		/// public propaty name  :  EachSlipTypeColPrt9
		/// <summary>伝票タイプ別列印字区分9プロパティ</summary>
		/// <value>0:印字しない,1:印字する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列印字区分9プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EachSlipTypeColPrt9
		{
			get{return _eachSlipTypeColPrt9;}
			set{_eachSlipTypeColPrt9 = value;}
		}

		/// public propaty name  :  EachSlipTypeColId10
		/// <summary>伝票タイプ別列ID10プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列ID10プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColId10
		{
			get{return _eachSlipTypeColId10;}
			set{_eachSlipTypeColId10 = value;}
		}

		/// public propaty name  :  EachSlipTypeColNm10
		/// <summary>伝票タイプ別列名称10プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列名称10プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string EachSlipTypeColNm10
		{
			get{return _eachSlipTypeColNm10;}
			set{_eachSlipTypeColNm10 = value;}
		}

		/// public propaty name  :  EachSlipTypeColPrt10
		/// <summary>伝票タイプ別列印字区分10プロパティ</summary>
		/// <value>0:印字しない,1:印字する</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票タイプ別列印字区分10プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EachSlipTypeColPrt10
		{
			get{return _eachSlipTypeColPrt10;}
			set{_eachSlipTypeColPrt10 = value;}
		}

		/// public propaty name  :  SlipFontName
		/// <summary>伝票フォント名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票フォント名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SlipFontName
		{
			get{return _slipFontName;}
			set{_slipFontName = value;}
		}

		/// public propaty name  :  SlipFontSize
		/// <summary>伝票フォントサイズプロパティ</summary>
		/// <value>0:標準,1:大</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票フォントサイズプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipFontSize
		{
			get{return _slipFontSize;}
			set{_slipFontSize = value;}
		}

		/// public propaty name  :  SlipFontStyle
		/// <summary>伝票フォントスタイルプロパティ</summary>
		/// <value>0:標準,1:太字</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票フォントスタイルプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipFontStyle
		{
			get{return _slipFontStyle;}
			set{_slipFontStyle = value;}
		}

		/// public propaty name  :  SlipBaseColorRed1
		/// <summary>伝票基準色赤1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色赤1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorRed1
		{
			get{return _slipBaseColorRed1;}
			set{_slipBaseColorRed1 = value;}
		}

		/// public propaty name  :  SlipBaseColorGrn1
		/// <summary>伝票基準色緑1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色緑1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorGrn1
		{
			get{return _slipBaseColorGrn1;}
			set{_slipBaseColorGrn1 = value;}
		}

		/// public propaty name  :  SlipBaseColorBlu1
		/// <summary>伝票基準色青1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色青1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorBlu1
		{
			get{return _slipBaseColorBlu1;}
			set{_slipBaseColorBlu1 = value;}
		}

		/// public propaty name  :  SlipBaseColorRed2
		/// <summary>伝票基準色赤2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色赤2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorRed2
		{
			get{return _slipBaseColorRed2;}
			set{_slipBaseColorRed2 = value;}
		}

		/// public propaty name  :  SlipBaseColorGrn2
		/// <summary>伝票基準色緑2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色緑2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorGrn2
		{
			get{return _slipBaseColorGrn2;}
			set{_slipBaseColorGrn2 = value;}
		}

		/// public propaty name  :  SlipBaseColorBlu2
		/// <summary>伝票基準色青2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色青2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorBlu2
		{
			get{return _slipBaseColorBlu2;}
			set{_slipBaseColorBlu2 = value;}
		}

		/// public propaty name  :  SlipBaseColorRed3
		/// <summary>伝票基準色赤3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色赤3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorRed3
		{
			get{return _slipBaseColorRed3;}
			set{_slipBaseColorRed3 = value;}
		}

		/// public propaty name  :  SlipBaseColorGrn3
		/// <summary>伝票基準色緑3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色緑3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorGrn3
		{
			get{return _slipBaseColorGrn3;}
			set{_slipBaseColorGrn3 = value;}
		}

		/// public propaty name  :  SlipBaseColorBlu3
		/// <summary>伝票基準色青3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色青3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorBlu3
		{
			get{return _slipBaseColorBlu3;}
			set{_slipBaseColorBlu3 = value;}
		}

		/// public propaty name  :  SlipBaseColorRed4
		/// <summary>伝票基準色赤4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色赤4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorRed4
		{
			get{return _slipBaseColorRed4;}
			set{_slipBaseColorRed4 = value;}
		}

		/// public propaty name  :  SlipBaseColorGrn4
		/// <summary>伝票基準色緑4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色緑4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorGrn4
		{
			get{return _slipBaseColorGrn4;}
			set{_slipBaseColorGrn4 = value;}
		}

		/// public propaty name  :  SlipBaseColorBlu4
		/// <summary>伝票基準色青4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色青4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorBlu4
		{
			get{return _slipBaseColorBlu4;}
			set{_slipBaseColorBlu4 = value;}
		}

		/// public propaty name  :  SlipBaseColorRed5
		/// <summary>伝票基準色赤5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色赤5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorRed5
		{
			get{return _slipBaseColorRed5;}
			set{_slipBaseColorRed5 = value;}
		}

		/// public propaty name  :  SlipBaseColorGrn5
		/// <summary>伝票基準色緑5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色緑5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorGrn5
		{
			get{return _slipBaseColorGrn5;}
			set{_slipBaseColorGrn5 = value;}
		}

		/// public propaty name  :  SlipBaseColorBlu5
		/// <summary>伝票基準色青5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票基準色青5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipBaseColorBlu5
		{
			get{return _slipBaseColorBlu5;}
			set{_slipBaseColorBlu5 = value;}
		}

		/// public propaty name  :  CopyCount
		/// <summary>複写枚数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   複写枚数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CopyCount
		{
			get{return _copyCount;}
			set{_copyCount = value;}
		}

		/// public propaty name  :  TitleName1
		/// <summary>タイトル1プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName1
		{
			get{return _titleName1;}
			set{_titleName1 = value;}
		}

		/// public propaty name  :  TitleName2
		/// <summary>タイトル2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName2
		{
			get{return _titleName2;}
			set{_titleName2 = value;}
		}

		/// public propaty name  :  TitleName3
		/// <summary>タイトル3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName3
		{
			get{return _titleName3;}
			set{_titleName3 = value;}
		}

		/// public propaty name  :  TitleName4
		/// <summary>タイトル4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName4
		{
			get{return _titleName4;}
			set{_titleName4 = value;}
		}

		/// public propaty name  :  SpecialPurpose1
		/// <summary>特殊用途1プロパティ</summary>
		/// <value>伝票種別置換項目(例 10,20,30等を設定）　＊見積書を納品書で印字する場合等に使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   特殊用途1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SpecialPurpose1
		{
			get{return _specialPurpose1;}
			set{_specialPurpose1 = value;}
		}

		/// public propaty name  :  SpecialPurpose2
		/// <summary>特殊用途2プロパティ</summary>
		/// <value>自由に設定可能（特殊な伝票の場合に使用）＊マスメン不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   特殊用途2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SpecialPurpose2
		{
			get{return _specialPurpose2;}
			set{_specialPurpose2 = value;}
		}

		/// public propaty name  :  SpecialPurpose3
		/// <summary>特殊用途3プロパティ</summary>
		/// <value>自由に設定可能（特殊な伝票の場合に使用）＊マスメン不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   特殊用途3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SpecialPurpose3
		{
			get{return _specialPurpose3;}
			set{_specialPurpose3 = value;}
		}

		/// public propaty name  :  SpecialPurpose4
		/// <summary>特殊用途4プロパティ</summary>
		/// <value>自由に設定可能（特殊な伝票の場合に使用）＊マスメン不可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   特殊用途4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string SpecialPurpose4
		{
			get{return _specialPurpose4;}
			set{_specialPurpose4 = value;}
		}

		/// public propaty name  :  TitleName102
		/// <summary>タイトル1-2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル1-2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName102
		{
			get{return _titleName102;}
			set{_titleName102 = value;}
		}

		/// public propaty name  :  TitleName103
		/// <summary>タイトル1-3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル1-3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName103
		{
			get{return _titleName103;}
			set{_titleName103 = value;}
		}

		/// public propaty name  :  TitleName104
		/// <summary>タイトル1-4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル1-4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName104
		{
			get{return _titleName104;}
			set{_titleName104 = value;}
		}

		/// public propaty name  :  TitleName105
		/// <summary>タイトル1-5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル1-5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName105
		{
			get{return _titleName105;}
			set{_titleName105 = value;}
		}

		/// public propaty name  :  TitleName202
		/// <summary>タイトル2-2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル2-2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName202
		{
			get{return _titleName202;}
			set{_titleName202 = value;}
		}

		/// public propaty name  :  TitleName203
		/// <summary>タイトル2-3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル2-3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName203
		{
			get{return _titleName203;}
			set{_titleName203 = value;}
		}

		/// public propaty name  :  TitleName204
		/// <summary>タイトル2-4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル2-4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName204
		{
			get{return _titleName204;}
			set{_titleName204 = value;}
		}

		/// public propaty name  :  TitleName205
		/// <summary>タイトル2-5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル2-5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName205
		{
			get{return _titleName205;}
			set{_titleName205 = value;}
		}

		/// public propaty name  :  TitleName302
		/// <summary>タイトル3-2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル3-2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName302
		{
			get{return _titleName302;}
			set{_titleName302 = value;}
		}

		/// public propaty name  :  TitleName303
		/// <summary>タイトル3-3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル3-3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName303
		{
			get{return _titleName303;}
			set{_titleName303 = value;}
		}

		/// public propaty name  :  TitleName304
		/// <summary>タイトル3-4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル3-4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName304
		{
			get{return _titleName304;}
			set{_titleName304 = value;}
		}

		/// public propaty name  :  TitleName305
		/// <summary>タイトル3-5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル3-5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName305
		{
			get{return _titleName305;}
			set{_titleName305 = value;}
		}

		/// public propaty name  :  TitleName402
		/// <summary>タイトル4-2プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル4-2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName402
		{
			get{return _titleName402;}
			set{_titleName402 = value;}
		}

		/// public propaty name  :  TitleName403
		/// <summary>タイトル4-3プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル4-3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName403
		{
			get{return _titleName403;}
			set{_titleName403 = value;}
		}

		/// public propaty name  :  TitleName404
		/// <summary>タイトル4-4プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル4-4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName404
		{
			get{return _titleName404;}
			set{_titleName404 = value;}
		}

		/// public propaty name  :  TitleName405
		/// <summary>タイトル4-5プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   タイトル4-5プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string TitleName405
		{
			get{return _titleName405;}
			set{_titleName405 = value;}
		}

		/// public propaty name  :  Note1
		/// <summary>備考１プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   備考１プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Note1
		{
			get{return _note1;}
			set{_note1 = value;}
		}

		/// public propaty name  :  Note2
		/// <summary>備考２プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   備考２プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Note2
		{
			get{return _note2;}
			set{_note2 = value;}
		}

		/// public propaty name  :  Note3
		/// <summary>備考３プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   備考３プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Note3
		{
			get{return _note3;}
			set{_note3 = value;}
		}

		/// public propaty name  :  QRCodePrintDivCd
		/// <summary>QRコード印字区分プロパティ</summary>
		/// <value>0:非印字,1:印字</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   QRコード印字区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 QRCodePrintDivCd
		{
			get{return _qRCodePrintDivCd;}
			set{_qRCodePrintDivCd = value;}
		}

		/// public propaty name  :  TimePrintDivCd
		/// <summary>時刻印字区分プロパティ</summary>
		/// <value>0:非印字,1:印字</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   時刻印字区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TimePrintDivCd
		{
			get{return _timePrintDivCd;}
			set{_timePrintDivCd = value;}
		}

		/// public propaty name  :  ReissueMark
		/// <summary>再発行マークプロパティ</summary>
		/// <value>全角３文字まで</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   再発行マークプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ReissueMark
		{
			get{return _reissueMark;}
			set{_reissueMark = value;}
		}

		/// public propaty name  :  RefConsTaxDivCd
		/// <summary>参考消費税区分プロパティ</summary>
		/// <value>0:非印字,1:印字</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   参考消費税区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RefConsTaxDivCd
		{
			get{return _refConsTaxDivCd;}
			set{_refConsTaxDivCd = value;}
		}

		/// public propaty name  :  RefConsTaxPrtNm
		/// <summary>参考消費税印字名称プロパティ</summary>
		/// <value>全角５文字まで</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   参考消費税印字名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string RefConsTaxPrtNm
		{
			get{return _refConsTaxPrtNm;}
			set{_refConsTaxPrtNm = value;}
		}

		/// public propaty name  :  DetailRowCount
		/// <summary>明細行数プロパティ</summary>
		/// <value>MAX999</value>
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

        // --- ADD 2009/12/31 ---------->>>>>
        /// public propaty name  :  SlipNoteCharCnt
        /// <summary>伝票備考桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNoteCharCnt
        {
            get { return _slipNoteCharCnt; }
            set { _slipNoteCharCnt = value; }
        }

        /// public propaty name  :  SlipNote2CharCnt
        /// <summary>伝票備考２桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考２桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNote2CharCnt
        {
            get { return _slipNote2CharCnt; }
            set { _slipNote2CharCnt = value; }
        }

        /// public propaty name  :  SlipNote3CharCnt
        /// <summary>伝票備考３桁数プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票備考３桁数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipNote3CharCnt
        {
            get { return _slipNote3CharCnt; }
            set { _slipNote3CharCnt = value; }
        }
        // --- ADD 2009/12/31 ----------<<<<<

        /// public propaty name  :  ConsTaxPrtCd
        /// <summary>消費税印字区分</summary>
        /// <value>0:非印字 1:印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細行数プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxPrtCd
        {
            get { return _consTaxPrtCd; }
            set { _consTaxPrtCd = value; }
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

        // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
        /// public propaty name  :  CustomerCode
        /// <summary>得意先コード</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コード</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  UpdateFlag
        /// <summary>更新フラグ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新フラグ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateFlag
        {
            get { return _updateFlag; }
            set { _updateFlag = value; }
        }
        // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

        // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>
        /// public propaty name  :  EntNmPrtExpDiv
        /// <summary>自社名印字拡大区分</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自社名印字拡大区分</br>
        /// <br>Programer        :   2011/02/16  鄧潘ハン 自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
        public Int32 EntNmPrtExpDiv
        {
            get { return _entNmPrtExpDiv; }
            set { _entNmPrtExpDiv = value; }
        }
        // ---ADD 2011/02/16 ------------------------------------------------------------<<<<<

        // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
        /// public propaty name  :  SCMAnsMarkPrtDiv
        /// <summary>SCM回答マーク印字区分プロパティ</summary>
        /// <value>0:しない,1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM回答マーク印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SCMAnsMarkPrtDiv
        {
            get { return _sCMAnsMarkPrtDiv; }
            set { _sCMAnsMarkPrtDiv = value; }
        }

        /// public propaty name  :  NormalPrtMark
        /// <summary>通常発行マークプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   通常発行マークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string NormalPrtMark
        {
            get { return _normalPrtMark; }
            set { _normalPrtMark = value; }
        }

        /// public propaty name  :  SCMManualAnsMark
        /// <summary>SCM手動回答マークプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM手動回答マークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SCMManualAnsMark
        {
            get { return _sCMManualAnsMark; }
            set { _sCMManualAnsMark = value; }
        }

        /// public propaty name  :  SCMAutoAnsMark
        /// <summary>SCM自動回答マークプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   SCM自動回答マークプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SCMAutoAnsMark
        {
            get { return _sCMAutoAnsMark; }
            set { _sCMAutoAnsMark = value; }
        }
        // ---ADD 2011/07/19 ------------------------------------------------------------<<<<<

		/// <summary>
		/// 伝票印刷設定マスタコンストラクタ
		/// </summary>
		/// <returns>SlipPrtSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipPrtSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SlipPrtSet()
		{
		}

		/// <summary>
		/// 伝票印刷設定マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="dataInputSystem">データ入力システム(0:共通,1:整備,2:鈑金,3:車販)</param>
		/// <param name="slipPrtKind">伝票印刷種別(10:見積書,20:指示書（注文書）,21:承り書,30:納品書,40:返品伝票,100:ワークシート,110:ボディ寸法図)</param>
		/// <param name="slipPrtSetPaperId">伝票印刷設定用帳票ID(伝票印刷設定用)</param>
		/// <param name="slipComment">伝票コメント</param>
		/// <param name="outputPgId">出力プログラムID</param>
		/// <param name="outputPgClassId">出力プログラムクラスID</param>
		/// <param name="outputFormFileName">出力ファイル名(フォームファイルID or フォーマットファイルID)</param>
		/// <param name="enterpriseNamePrtCd">自社名印刷区分(0:自社名印字　1:拠点名印字　2:ビットマップを印字　3:印字しない)</param>
		/// <param name="prtCirculation">印刷部数(1～99)</param>
		/// <param name="slipFormCd">伝票用紙区分(0:白紙,1:専用伝票,2:連帳)</param>
		/// <param name="outConfimationMsg">出力確認メッセージ</param>
		/// <param name="optionCode">オプションコード(ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ)</param>
		/// <param name="topMargin">上余白(cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8))</param>
		/// <param name="leftMargin">左余白(cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8))</param>
		/// <param name="rightMargin">右余白</param>
		/// <param name="bottomMargin">下余白</param>
		/// <param name="prtPreviewExistCode">印刷プレビュ有無区分(0:無し,1:有り)</param>
		/// <param name="outputPurpose">出力用途(自由に設定可能)</param>
		/// <param name="eachSlipTypeColId1">伝票タイプ別列ID1</param>
		/// <param name="eachSlipTypeColNm1">伝票タイプ別列名称1</param>
		/// <param name="eachSlipTypeColPrt1">伝票タイプ別列印字区分1(0:印字しない,1:印字する)</param>
		/// <param name="eachSlipTypeColId2">伝票タイプ別列ID2</param>
		/// <param name="eachSlipTypeColNm2">伝票タイプ別列名称2</param>
		/// <param name="eachSlipTypeColPrt2">伝票タイプ別列印字区分2(0:印字しない,1:印字する)</param>
		/// <param name="eachSlipTypeColId3">伝票タイプ別列ID3</param>
		/// <param name="eachSlipTypeColNm3">伝票タイプ別列名称3</param>
		/// <param name="eachSlipTypeColPrt3">伝票タイプ別列印字区分3(0:印字しない,1:印字する)</param>
		/// <param name="eachSlipTypeColId4">伝票タイプ別列ID4</param>
		/// <param name="eachSlipTypeColNm4">伝票タイプ別列名称4</param>
		/// <param name="eachSlipTypeColPrt4">伝票タイプ別列印字区分4(0:印字しない,1:印字する)</param>
		/// <param name="eachSlipTypeColId5">伝票タイプ別列ID5</param>
		/// <param name="eachSlipTypeColNm5">伝票タイプ別列名称5</param>
		/// <param name="eachSlipTypeColPrt5">伝票タイプ別列印字区分5(0:印字しない,1:印字する)</param>
		/// <param name="eachSlipTypeColId6">伝票タイプ別列ID6</param>
		/// <param name="eachSlipTypeColNm6">伝票タイプ別列名称6</param>
		/// <param name="eachSlipTypeColPrt6">伝票タイプ別列印字区分6(0:印字しない,1:印字する)</param>
		/// <param name="eachSlipTypeColId7">伝票タイプ別列ID7</param>
		/// <param name="eachSlipTypeColNm7">伝票タイプ別列名称7</param>
		/// <param name="eachSlipTypeColPrt7">伝票タイプ別列印字区分7(0:印字しない,1:印字する)</param>
		/// <param name="eachSlipTypeColId8">伝票タイプ別列ID8</param>
		/// <param name="eachSlipTypeColNm8">伝票タイプ別列名称8</param>
		/// <param name="eachSlipTypeColPrt8">伝票タイプ別列印字区分8(0:印字しない,1:印字する)</param>
		/// <param name="eachSlipTypeColId9">伝票タイプ別列ID9</param>
		/// <param name="eachSlipTypeColNm9">伝票タイプ別列名称9</param>
		/// <param name="eachSlipTypeColPrt9">伝票タイプ別列印字区分9(0:印字しない,1:印字する)</param>
		/// <param name="eachSlipTypeColId10">伝票タイプ別列ID10</param>
		/// <param name="eachSlipTypeColNm10">伝票タイプ別列名称10</param>
		/// <param name="eachSlipTypeColPrt10">伝票タイプ別列印字区分10(0:印字しない,1:印字する)</param>
		/// <param name="slipFontName">伝票フォント名称</param>
		/// <param name="slipFontSize">伝票フォントサイズ(0:標準,1:大)</param>
		/// <param name="slipFontStyle">伝票フォントスタイル(0:標準,1:太字)</param>
		/// <param name="slipBaseColorRed1">伝票基準色赤1</param>
		/// <param name="slipBaseColorGrn1">伝票基準色緑1</param>
		/// <param name="slipBaseColorBlu1">伝票基準色青1</param>
		/// <param name="slipBaseColorRed2">伝票基準色赤2</param>
		/// <param name="slipBaseColorGrn2">伝票基準色緑2</param>
		/// <param name="slipBaseColorBlu2">伝票基準色青2</param>
		/// <param name="slipBaseColorRed3">伝票基準色赤3</param>
		/// <param name="slipBaseColorGrn3">伝票基準色緑3</param>
		/// <param name="slipBaseColorBlu3">伝票基準色青3</param>
		/// <param name="slipBaseColorRed4">伝票基準色赤4</param>
		/// <param name="slipBaseColorGrn4">伝票基準色緑4</param>
		/// <param name="slipBaseColorBlu4">伝票基準色青4</param>
		/// <param name="slipBaseColorRed5">伝票基準色赤5</param>
		/// <param name="slipBaseColorGrn5">伝票基準色緑5</param>
		/// <param name="slipBaseColorBlu5">伝票基準色青5</param>
		/// <param name="copyCount">複写枚数</param>
		/// <param name="titleName1">タイトル1</param>
		/// <param name="titleName2">タイトル2</param>
		/// <param name="titleName3">タイトル3</param>
		/// <param name="titleName4">タイトル4</param>
		/// <param name="specialPurpose1">特殊用途1(伝票種別置換項目(例 10,20,30等を設定）　＊見積書を納品書で印字する場合等に使用)</param>
		/// <param name="specialPurpose2">特殊用途2(自由に設定可能（特殊な伝票の場合に使用）＊マスメン不可)</param>
		/// <param name="specialPurpose3">特殊用途3(自由に設定可能（特殊な伝票の場合に使用）＊マスメン不可)</param>
		/// <param name="specialPurpose4">特殊用途4(自由に設定可能（特殊な伝票の場合に使用）＊マスメン不可)</param>
		/// <param name="titleName102">タイトル1-2</param>
		/// <param name="titleName103">タイトル1-3</param>
		/// <param name="titleName104">タイトル1-4</param>
		/// <param name="titleName105">タイトル1-5</param>
		/// <param name="titleName202">タイトル2-2</param>
		/// <param name="titleName203">タイトル2-3</param>
		/// <param name="titleName204">タイトル2-4</param>
		/// <param name="titleName205">タイトル2-5</param>
		/// <param name="titleName302">タイトル3-2</param>
		/// <param name="titleName303">タイトル3-3</param>
		/// <param name="titleName304">タイトル3-4</param>
		/// <param name="titleName305">タイトル3-5</param>
		/// <param name="titleName402">タイトル4-2</param>
		/// <param name="titleName403">タイトル4-3</param>
		/// <param name="titleName404">タイトル4-4</param>
		/// <param name="titleName405">タイトル4-5</param>
		/// <param name="note1">備考１</param>
		/// <param name="note2">備考２</param>
		/// <param name="note3">備考３</param>
		/// <param name="qRCodePrintDivCd">QRコード印字区分(0:非印字,1:印字)</param>
		/// <param name="timePrintDivCd">時刻印字区分(0:非印字,1:印字)</param>
		/// <param name="reissueMark">再発行マーク(全角３文字まで)</param>
		/// <param name="refConsTaxDivCd">参考消費税区分(0:非印字,1:印字)</param>
		/// <param name="refConsTaxPrtNm">参考消費税印字名称(全角５文字まで)</param>
		/// <param name="detailRowCount">明細行数(MAX999)</param>
		/// <param name="honorificTitle">敬称</param>
        /// <param name="slipNoteCharCnt">伝票備考桁数</param>
        /// <param name="slipNote2CharCnt">伝票備考２桁数</param>
        /// <param name="slipNote3CharCnt">伝票備考３桁数</param>
        /// <param name="consTaxPrtCd">消費税印字区分</param>
        /// <param name="enterpriseName">企業名称</param>
		/// <param name="updEmployeeName">更新従業員名称</param>
		/// <param name="dataInputSystemName">データ入力システム名称(共通,整備,鈑金,車販)</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="updateFlag">更新フラグ</param>
        /// <param name="entNmPrtExpDiv">自社名印字拡大区分</param> //ADD 2011/02/16
        /// <param name="sCMAnsMarkPrtDiv">SCM回答マーク印字区分(0:しない,1:する)</param>
        /// <param name="normalPrtMark">通常発行マーク</param>
        /// <param name="sCMManualAnsMark">SCM手動回答マーク</param>
        /// <param name="sCMAutoAnsMark">SCM自動回答マーク</param>
		/// <returns>SlipPrtSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipPrtSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/02/16  鄧潘ハン</br>
        /// <br>                     自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
        // --- UPD 2011/07/19 --------------->>>>>
        // --- UPD 2011/02/16 --------------->>>>>
        // --- UPD 2010/08/06 --------------->>>>>
        //public SlipPrtSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 dataInputSystem, Int32 slipPrtKind, string slipPrtSetPaperId, string slipComment, string outputPgId, string outputPgClassId, string outputFormFileName, Int32 enterpriseNamePrtCd, Int32 prtCirculation, Int32 slipFormCd, string outConfimationMsg, string optionCode, Double topMargin, Double leftMargin, Double rightMargin, Double bottomMargin, Int32 prtPreviewExistCode, Int32 outputPurpose, string eachSlipTypeColId1, string eachSlipTypeColNm1, Int32 eachSlipTypeColPrt1, string eachSlipTypeColId2, string eachSlipTypeColNm2, Int32 eachSlipTypeColPrt2, string eachSlipTypeColId3, string eachSlipTypeColNm3, Int32 eachSlipTypeColPrt3, string eachSlipTypeColId4, string eachSlipTypeColNm4, Int32 eachSlipTypeColPrt4, string eachSlipTypeColId5, string eachSlipTypeColNm5, Int32 eachSlipTypeColPrt5, string eachSlipTypeColId6, string eachSlipTypeColNm6, Int32 eachSlipTypeColPrt6, string eachSlipTypeColId7, string eachSlipTypeColNm7, Int32 eachSlipTypeColPrt7, string eachSlipTypeColId8, string eachSlipTypeColNm8, Int32 eachSlipTypeColPrt8, string eachSlipTypeColId9, string eachSlipTypeColNm9, Int32 eachSlipTypeColPrt9, string eachSlipTypeColId10, string eachSlipTypeColNm10, Int32 eachSlipTypeColPrt10, string slipFontName, Int32 slipFontSize, Int32 slipFontStyle, Int32 slipBaseColorRed1, Int32 slipBaseColorGrn1, Int32 slipBaseColorBlu1, Int32 slipBaseColorRed2, Int32 slipBaseColorGrn2, Int32 slipBaseColorBlu2, Int32 slipBaseColorRed3, Int32 slipBaseColorGrn3, Int32 slipBaseColorBlu3, Int32 slipBaseColorRed4, Int32 slipBaseColorGrn4, Int32 slipBaseColorBlu4, Int32 slipBaseColorRed5, Int32 slipBaseColorGrn5, Int32 slipBaseColorBlu5, Int32 copyCount, string titleName1, string titleName2, string titleName3, string titleName4, string specialPurpose1, string specialPurpose2, string specialPurpose3, string specialPurpose4, string titleName102, string titleName103, string titleName104, string titleName105, string titleName202, string titleName203, string titleName204, string titleName205, string titleName302, string titleName303, string titleName304, string titleName305, string titleName402, string titleName403, string titleName404, string titleName405, string note1, string note2, string note3, Int32 qRCodePrintDivCd, Int32 timePrintDivCd, string reissueMark, Int32 refConsTaxDivCd, string refConsTaxPrtNm, Int32 detailRowCount, string honorificTitle, Int32 slipNoteCharCnt, Int32 slipNote2CharCnt, Int32 slipNote3CharCnt, Int32 consTaxPrtCd, string enterpriseName, string updEmployeeName, string dataInputSystemName)
        //public SlipPrtSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 dataInputSystem, Int32 slipPrtKind, string slipPrtSetPaperId, string slipComment, string outputPgId, string outputPgClassId, string outputFormFileName, Int32 enterpriseNamePrtCd, Int32 prtCirculation, Int32 slipFormCd, string outConfimationMsg, string optionCode, Double topMargin, Double leftMargin, Double rightMargin, Double bottomMargin, Int32 prtPreviewExistCode, Int32 outputPurpose, string eachSlipTypeColId1, string eachSlipTypeColNm1, Int32 eachSlipTypeColPrt1, string eachSlipTypeColId2, string eachSlipTypeColNm2, Int32 eachSlipTypeColPrt2, string eachSlipTypeColId3, string eachSlipTypeColNm3, Int32 eachSlipTypeColPrt3, string eachSlipTypeColId4, string eachSlipTypeColNm4, Int32 eachSlipTypeColPrt4, string eachSlipTypeColId5, string eachSlipTypeColNm5, Int32 eachSlipTypeColPrt5, string eachSlipTypeColId6, string eachSlipTypeColNm6, Int32 eachSlipTypeColPrt6, string eachSlipTypeColId7, string eachSlipTypeColNm7, Int32 eachSlipTypeColPrt7, string eachSlipTypeColId8, string eachSlipTypeColNm8, Int32 eachSlipTypeColPrt8, string eachSlipTypeColId9, string eachSlipTypeColNm9, Int32 eachSlipTypeColPrt9, string eachSlipTypeColId10, string eachSlipTypeColNm10, Int32 eachSlipTypeColPrt10, string slipFontName, Int32 slipFontSize, Int32 slipFontStyle, Int32 slipBaseColorRed1, Int32 slipBaseColorGrn1, Int32 slipBaseColorBlu1, Int32 slipBaseColorRed2, Int32 slipBaseColorGrn2, Int32 slipBaseColorBlu2, Int32 slipBaseColorRed3, Int32 slipBaseColorGrn3, Int32 slipBaseColorBlu3, Int32 slipBaseColorRed4, Int32 slipBaseColorGrn4, Int32 slipBaseColorBlu4, Int32 slipBaseColorRed5, Int32 slipBaseColorGrn5, Int32 slipBaseColorBlu5, Int32 copyCount, string titleName1, string titleName2, string titleName3, string titleName4, string specialPurpose1, string specialPurpose2, string specialPurpose3, string specialPurpose4, string titleName102, string titleName103, string titleName104, string titleName105, string titleName202, string titleName203, string titleName204, string titleName205, string titleName302, string titleName303, string titleName304, string titleName305, string titleName402, string titleName403, string titleName404, string titleName405, string note1, string note2, string note3, Int32 qRCodePrintDivCd, Int32 timePrintDivCd, string reissueMark, Int32 refConsTaxDivCd, string refConsTaxPrtNm, Int32 detailRowCount, string honorificTitle, Int32 slipNoteCharCnt, Int32 slipNote2CharCnt, Int32 slipNote3CharCnt, Int32 consTaxPrtCd, string enterpriseName, string updEmployeeName, string dataInputSystemName, Int32 customerCode, Int32 updateFlag)
        //public SlipPrtSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 dataInputSystem, Int32 slipPrtKind, string slipPrtSetPaperId, string slipComment, string outputPgId, string outputPgClassId, string outputFormFileName, Int32 enterpriseNamePrtCd, Int32 prtCirculation, Int32 slipFormCd, string outConfimationMsg, string optionCode, Double topMargin, Double leftMargin, Double rightMargin, Double bottomMargin, Int32 prtPreviewExistCode, Int32 outputPurpose, string eachSlipTypeColId1, string eachSlipTypeColNm1, Int32 eachSlipTypeColPrt1, string eachSlipTypeColId2, string eachSlipTypeColNm2, Int32 eachSlipTypeColPrt2, string eachSlipTypeColId3, string eachSlipTypeColNm3, Int32 eachSlipTypeColPrt3, string eachSlipTypeColId4, string eachSlipTypeColNm4, Int32 eachSlipTypeColPrt4, string eachSlipTypeColId5, string eachSlipTypeColNm5, Int32 eachSlipTypeColPrt5, string eachSlipTypeColId6, string eachSlipTypeColNm6, Int32 eachSlipTypeColPrt6, string eachSlipTypeColId7, string eachSlipTypeColNm7, Int32 eachSlipTypeColPrt7, string eachSlipTypeColId8, string eachSlipTypeColNm8, Int32 eachSlipTypeColPrt8, string eachSlipTypeColId9, string eachSlipTypeColNm9, Int32 eachSlipTypeColPrt9, string eachSlipTypeColId10, string eachSlipTypeColNm10, Int32 eachSlipTypeColPrt10, string slipFontName, Int32 slipFontSize, Int32 slipFontStyle, Int32 slipBaseColorRed1, Int32 slipBaseColorGrn1, Int32 slipBaseColorBlu1, Int32 slipBaseColorRed2, Int32 slipBaseColorGrn2, Int32 slipBaseColorBlu2, Int32 slipBaseColorRed3, Int32 slipBaseColorGrn3, Int32 slipBaseColorBlu3, Int32 slipBaseColorRed4, Int32 slipBaseColorGrn4, Int32 slipBaseColorBlu4, Int32 slipBaseColorRed5, Int32 slipBaseColorGrn5, Int32 slipBaseColorBlu5, Int32 copyCount, string titleName1, string titleName2, string titleName3, string titleName4, string specialPurpose1, string specialPurpose2, string specialPurpose3, string specialPurpose4, string titleName102, string titleName103, string titleName104, string titleName105, string titleName202, string titleName203, string titleName204, string titleName205, string titleName302, string titleName303, string titleName304, string titleName305, string titleName402, string titleName403, string titleName404, string titleName405, string note1, string note2, string note3, Int32 qRCodePrintDivCd, Int32 timePrintDivCd, string reissueMark, Int32 refConsTaxDivCd, string refConsTaxPrtNm, Int32 detailRowCount, string honorificTitle, Int32 slipNoteCharCnt, Int32 slipNote2CharCnt, Int32 slipNote3CharCnt, Int32 consTaxPrtCd, string enterpriseName, string updEmployeeName, string dataInputSystemName, Int32 customerCode, Int32 updateFlag, Int32 entNmPrtExpDiv)
        public SlipPrtSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 dataInputSystem, Int32 slipPrtKind, string slipPrtSetPaperId, string slipComment, string outputPgId, string outputPgClassId, string outputFormFileName, Int32 enterpriseNamePrtCd, Int32 prtCirculation, Int32 slipFormCd, string outConfimationMsg, string optionCode, Double topMargin, Double leftMargin, Double rightMargin, Double bottomMargin, Int32 prtPreviewExistCode, Int32 outputPurpose, string eachSlipTypeColId1, string eachSlipTypeColNm1, Int32 eachSlipTypeColPrt1, string eachSlipTypeColId2, string eachSlipTypeColNm2, Int32 eachSlipTypeColPrt2, string eachSlipTypeColId3, string eachSlipTypeColNm3, Int32 eachSlipTypeColPrt3, string eachSlipTypeColId4, string eachSlipTypeColNm4, Int32 eachSlipTypeColPrt4, string eachSlipTypeColId5, string eachSlipTypeColNm5, Int32 eachSlipTypeColPrt5, string eachSlipTypeColId6, string eachSlipTypeColNm6, Int32 eachSlipTypeColPrt6, string eachSlipTypeColId7, string eachSlipTypeColNm7, Int32 eachSlipTypeColPrt7, string eachSlipTypeColId8, string eachSlipTypeColNm8, Int32 eachSlipTypeColPrt8, string eachSlipTypeColId9, string eachSlipTypeColNm9, Int32 eachSlipTypeColPrt9, string eachSlipTypeColId10, string eachSlipTypeColNm10, Int32 eachSlipTypeColPrt10, string slipFontName, Int32 slipFontSize, Int32 slipFontStyle, Int32 slipBaseColorRed1, Int32 slipBaseColorGrn1, Int32 slipBaseColorBlu1, Int32 slipBaseColorRed2, Int32 slipBaseColorGrn2, Int32 slipBaseColorBlu2, Int32 slipBaseColorRed3, Int32 slipBaseColorGrn3, Int32 slipBaseColorBlu3, Int32 slipBaseColorRed4, Int32 slipBaseColorGrn4, Int32 slipBaseColorBlu4, Int32 slipBaseColorRed5, Int32 slipBaseColorGrn5, Int32 slipBaseColorBlu5, Int32 copyCount, string titleName1, string titleName2, string titleName3, string titleName4, string specialPurpose1, string specialPurpose2, string specialPurpose3, string specialPurpose4, string titleName102, string titleName103, string titleName104, string titleName105, string titleName202, string titleName203, string titleName204, string titleName205, string titleName302, string titleName303, string titleName304, string titleName305, string titleName402, string titleName403, string titleName404, string titleName405, string note1, string note2, string note3, Int32 qRCodePrintDivCd, Int32 timePrintDivCd, string reissueMark, Int32 refConsTaxDivCd, string refConsTaxPrtNm, Int32 detailRowCount, string honorificTitle, Int32 slipNoteCharCnt, Int32 slipNote2CharCnt, Int32 slipNote3CharCnt, Int32 consTaxPrtCd, string enterpriseName, string updEmployeeName, string dataInputSystemName, Int32 customerCode, Int32 updateFlag, Int32 entNmPrtExpDiv, Int32 sCMAnsMarkPrtDiv, string normalPrtMark, string sCMManualAnsMark, string sCMAutoAnsMark)
        // --- UPD 2010/08/06 ---------------<<<<<
		// --- UPD 2011/02/16 ---------------<<<<<
        // --- UPD 2011/07/19 ---------------<<<<<
        {
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._dataInputSystem = dataInputSystem;
			this._slipPrtKind = slipPrtKind;
			this._slipPrtSetPaperId = slipPrtSetPaperId;
			this._slipComment = slipComment;
			this._outputPgId = outputPgId;
			this._outputPgClassId = outputPgClassId;
			this._outputFormFileName = outputFormFileName;
			this._enterpriseNamePrtCd = enterpriseNamePrtCd;
			this._prtCirculation = prtCirculation;
			this._slipFormCd = slipFormCd;
			this._outConfimationMsg = outConfimationMsg;
			this._optionCode = optionCode;
			this._topMargin = topMargin;
			this._leftMargin = leftMargin;
			this._rightMargin = rightMargin;
			this._bottomMargin = bottomMargin;
			this._prtPreviewExistCode = prtPreviewExistCode;
			this._outputPurpose = outputPurpose;
			this._eachSlipTypeColId1 = eachSlipTypeColId1;
			this._eachSlipTypeColNm1 = eachSlipTypeColNm1;
			this._eachSlipTypeColPrt1 = eachSlipTypeColPrt1;
			this._eachSlipTypeColId2 = eachSlipTypeColId2;
			this._eachSlipTypeColNm2 = eachSlipTypeColNm2;
			this._eachSlipTypeColPrt2 = eachSlipTypeColPrt2;
			this._eachSlipTypeColId3 = eachSlipTypeColId3;
			this._eachSlipTypeColNm3 = eachSlipTypeColNm3;
			this._eachSlipTypeColPrt3 = eachSlipTypeColPrt3;
			this._eachSlipTypeColId4 = eachSlipTypeColId4;
			this._eachSlipTypeColNm4 = eachSlipTypeColNm4;
			this._eachSlipTypeColPrt4 = eachSlipTypeColPrt4;
			this._eachSlipTypeColId5 = eachSlipTypeColId5;
			this._eachSlipTypeColNm5 = eachSlipTypeColNm5;
			this._eachSlipTypeColPrt5 = eachSlipTypeColPrt5;
			this._eachSlipTypeColId6 = eachSlipTypeColId6;
			this._eachSlipTypeColNm6 = eachSlipTypeColNm6;
			this._eachSlipTypeColPrt6 = eachSlipTypeColPrt6;
			this._eachSlipTypeColId7 = eachSlipTypeColId7;
			this._eachSlipTypeColNm7 = eachSlipTypeColNm7;
			this._eachSlipTypeColPrt7 = eachSlipTypeColPrt7;
			this._eachSlipTypeColId8 = eachSlipTypeColId8;
			this._eachSlipTypeColNm8 = eachSlipTypeColNm8;
			this._eachSlipTypeColPrt8 = eachSlipTypeColPrt8;
			this._eachSlipTypeColId9 = eachSlipTypeColId9;
			this._eachSlipTypeColNm9 = eachSlipTypeColNm9;
			this._eachSlipTypeColPrt9 = eachSlipTypeColPrt9;
			this._eachSlipTypeColId10 = eachSlipTypeColId10;
			this._eachSlipTypeColNm10 = eachSlipTypeColNm10;
			this._eachSlipTypeColPrt10 = eachSlipTypeColPrt10;
			this._slipFontName = slipFontName;
			this._slipFontSize = slipFontSize;
			this._slipFontStyle = slipFontStyle;
			this._slipBaseColorRed1 = slipBaseColorRed1;
			this._slipBaseColorGrn1 = slipBaseColorGrn1;
			this._slipBaseColorBlu1 = slipBaseColorBlu1;
			this._slipBaseColorRed2 = slipBaseColorRed2;
			this._slipBaseColorGrn2 = slipBaseColorGrn2;
			this._slipBaseColorBlu2 = slipBaseColorBlu2;
			this._slipBaseColorRed3 = slipBaseColorRed3;
			this._slipBaseColorGrn3 = slipBaseColorGrn3;
			this._slipBaseColorBlu3 = slipBaseColorBlu3;
			this._slipBaseColorRed4 = slipBaseColorRed4;
			this._slipBaseColorGrn4 = slipBaseColorGrn4;
			this._slipBaseColorBlu4 = slipBaseColorBlu4;
			this._slipBaseColorRed5 = slipBaseColorRed5;
			this._slipBaseColorGrn5 = slipBaseColorGrn5;
			this._slipBaseColorBlu5 = slipBaseColorBlu5;
			this._copyCount = copyCount;
			this._titleName1 = titleName1;
			this._titleName2 = titleName2;
			this._titleName3 = titleName3;
			this._titleName4 = titleName4;
			this._specialPurpose1 = specialPurpose1;
			this._specialPurpose2 = specialPurpose2;
			this._specialPurpose3 = specialPurpose3;
			this._specialPurpose4 = specialPurpose4;
			this._titleName102 = titleName102;
			this._titleName103 = titleName103;
			this._titleName104 = titleName104;
			this._titleName105 = titleName105;
			this._titleName202 = titleName202;
			this._titleName203 = titleName203;
			this._titleName204 = titleName204;
			this._titleName205 = titleName205;
			this._titleName302 = titleName302;
			this._titleName303 = titleName303;
			this._titleName304 = titleName304;
			this._titleName305 = titleName305;
			this._titleName402 = titleName402;
			this._titleName403 = titleName403;
			this._titleName404 = titleName404;
			this._titleName405 = titleName405;
			this._note1 = note1;
			this._note2 = note2;
			this._note3 = note3;
			this._qRCodePrintDivCd = qRCodePrintDivCd;
			this._timePrintDivCd = timePrintDivCd;
			this._reissueMark = reissueMark;
			this._refConsTaxDivCd = refConsTaxDivCd;
			this._refConsTaxPrtNm = refConsTaxPrtNm;
			this._detailRowCount = detailRowCount;
			this._honorificTitle = honorificTitle;
            // --- ADD 2009/12/31 ---------->>>>>
            this._slipNoteCharCnt = slipNoteCharCnt;
            this._slipNote2CharCnt = slipNote2CharCnt;
            this._slipNote3CharCnt = slipNote3CharCnt;
            // --- ADD 2009/12/31 ----------<<<<<
            this._consTaxPrtCd = consTaxPrtCd;
			this._enterpriseName = enterpriseName;
			this._updEmployeeName = updEmployeeName;
			this._dataInputSystemName = dataInputSystemName;
            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            this._customerCode = customerCode;
            this._updateFlag = updateFlag;
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
            this._entNmPrtExpDiv = entNmPrtExpDiv; //ADD 2011/02/16
            // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
            this._sCMAnsMarkPrtDiv = sCMAnsMarkPrtDiv;
            this._normalPrtMark = normalPrtMark;
            this._sCMManualAnsMark = sCMManualAnsMark;
            this._sCMAutoAnsMark = sCMAutoAnsMark;
            // ---ADD 2011/07/19 ------------------------------------------------------------<<<<<

		}

		/// <summary>
		/// 伝票印刷設定マスタ複製処理
		/// </summary>
		/// <returns>SlipPrtSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSlipPrtSetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/02/16  鄧潘ハン</br>
        /// <br>                     自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
		public SlipPrtSet Clone()
		{
            //return new SlipPrtSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._dataInputSystem, this._slipPrtKind, this._slipPrtSetPaperId, this._slipComment, this._outputPgId, this._outputPgClassId, this._outputFormFileName, this._enterpriseNamePrtCd, this._prtCirculation, this._slipFormCd, this._outConfimationMsg, this._optionCode, this._topMargin, this._leftMargin, this._rightMargin, this._bottomMargin, this._prtPreviewExistCode, this._outputPurpose, this._eachSlipTypeColId1, this._eachSlipTypeColNm1, this._eachSlipTypeColPrt1, this._eachSlipTypeColId2, this._eachSlipTypeColNm2, this._eachSlipTypeColPrt2, this._eachSlipTypeColId3, this._eachSlipTypeColNm3, this._eachSlipTypeColPrt3, this._eachSlipTypeColId4, this._eachSlipTypeColNm4, this._eachSlipTypeColPrt4, this._eachSlipTypeColId5, this._eachSlipTypeColNm5, this._eachSlipTypeColPrt5, this._eachSlipTypeColId6, this._eachSlipTypeColNm6, this._eachSlipTypeColPrt6, this._eachSlipTypeColId7, this._eachSlipTypeColNm7, this._eachSlipTypeColPrt7, this._eachSlipTypeColId8, this._eachSlipTypeColNm8, this._eachSlipTypeColPrt8, this._eachSlipTypeColId9, this._eachSlipTypeColNm9, this._eachSlipTypeColPrt9, this._eachSlipTypeColId10, this._eachSlipTypeColNm10, this._eachSlipTypeColPrt10, this._slipFontName, this._slipFontSize, this._slipFontStyle, this._slipBaseColorRed1, this._slipBaseColorGrn1, this._slipBaseColorBlu1, this._slipBaseColorRed2, this._slipBaseColorGrn2, this._slipBaseColorBlu2, this._slipBaseColorRed3, this._slipBaseColorGrn3, this._slipBaseColorBlu3, this._slipBaseColorRed4, this._slipBaseColorGrn4, this._slipBaseColorBlu4, this._slipBaseColorRed5, this._slipBaseColorGrn5, this._slipBaseColorBlu5, this._copyCount, this._titleName1, this._titleName2, this._titleName3, this._titleName4, this._specialPurpose1, this._specialPurpose2, this._specialPurpose3, this._specialPurpose4, this._titleName102, this._titleName103, this._titleName104, this._titleName105, this._titleName202, this._titleName203, this._titleName204, this._titleName205, this._titleName302, this._titleName303, this._titleName304, this._titleName305, this._titleName402, this._titleName403, this._titleName404, this._titleName405, this._note1, this._note2, this._note3, this._qRCodePrintDivCd, this._timePrintDivCd, this._reissueMark, this._refConsTaxDivCd, this._refConsTaxPrtNm, this._detailRowCount, this._honorificTitle, this._slipNoteCharCnt, this._slipNote2CharCnt, this._slipNote3CharCnt, this._consTaxPrtCd, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName, this._customerCode, this._updateFlag);// DEL 2011/02/16
            //return new SlipPrtSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._dataInputSystem, this._slipPrtKind, this._slipPrtSetPaperId, this._slipComment, this._outputPgId, this._outputPgClassId, this._outputFormFileName, this._enterpriseNamePrtCd, this._prtCirculation, this._slipFormCd, this._outConfimationMsg, this._optionCode, this._topMargin, this._leftMargin, this._rightMargin, this._bottomMargin, this._prtPreviewExistCode, this._outputPurpose, this._eachSlipTypeColId1, this._eachSlipTypeColNm1, this._eachSlipTypeColPrt1, this._eachSlipTypeColId2, this._eachSlipTypeColNm2, this._eachSlipTypeColPrt2, this._eachSlipTypeColId3, this._eachSlipTypeColNm3, this._eachSlipTypeColPrt3, this._eachSlipTypeColId4, this._eachSlipTypeColNm4, this._eachSlipTypeColPrt4, this._eachSlipTypeColId5, this._eachSlipTypeColNm5, this._eachSlipTypeColPrt5, this._eachSlipTypeColId6, this._eachSlipTypeColNm6, this._eachSlipTypeColPrt6, this._eachSlipTypeColId7, this._eachSlipTypeColNm7, this._eachSlipTypeColPrt7, this._eachSlipTypeColId8, this._eachSlipTypeColNm8, this._eachSlipTypeColPrt8, this._eachSlipTypeColId9, this._eachSlipTypeColNm9, this._eachSlipTypeColPrt9, this._eachSlipTypeColId10, this._eachSlipTypeColNm10, this._eachSlipTypeColPrt10, this._slipFontName, this._slipFontSize, this._slipFontStyle, this._slipBaseColorRed1, this._slipBaseColorGrn1, this._slipBaseColorBlu1, this._slipBaseColorRed2, this._slipBaseColorGrn2, this._slipBaseColorBlu2, this._slipBaseColorRed3, this._slipBaseColorGrn3, this._slipBaseColorBlu3, this._slipBaseColorRed4, this._slipBaseColorGrn4, this._slipBaseColorBlu4, this._slipBaseColorRed5, this._slipBaseColorGrn5, this._slipBaseColorBlu5, this._copyCount, this._titleName1, this._titleName2, this._titleName3, this._titleName4, this._specialPurpose1, this._specialPurpose2, this._specialPurpose3, this._specialPurpose4, this._titleName102, this._titleName103, this._titleName104, this._titleName105, this._titleName202, this._titleName203, this._titleName204, this._titleName205, this._titleName302, this._titleName303, this._titleName304, this._titleName305, this._titleName402, this._titleName403, this._titleName404, this._titleName405, this._note1, this._note2, this._note3, this._qRCodePrintDivCd, this._timePrintDivCd, this._reissueMark, this._refConsTaxDivCd, this._refConsTaxPrtNm, this._detailRowCount, this._honorificTitle, this._slipNoteCharCnt, this._slipNote2CharCnt, this._slipNote3CharCnt, this._consTaxPrtCd, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName, this._customerCode, this._updateFlag, this._entNmPrtExpDiv);// ADD 2011/02/16 //DEL 2011/07/19
            return new SlipPrtSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._dataInputSystem, this._slipPrtKind, this._slipPrtSetPaperId, this._slipComment, this._outputPgId, this._outputPgClassId, this._outputFormFileName, this._enterpriseNamePrtCd, this._prtCirculation, this._slipFormCd, this._outConfimationMsg, this._optionCode, this._topMargin, this._leftMargin, this._rightMargin, this._bottomMargin, this._prtPreviewExistCode, this._outputPurpose, this._eachSlipTypeColId1, this._eachSlipTypeColNm1, this._eachSlipTypeColPrt1, this._eachSlipTypeColId2, this._eachSlipTypeColNm2, this._eachSlipTypeColPrt2, this._eachSlipTypeColId3, this._eachSlipTypeColNm3, this._eachSlipTypeColPrt3, this._eachSlipTypeColId4, this._eachSlipTypeColNm4, this._eachSlipTypeColPrt4, this._eachSlipTypeColId5, this._eachSlipTypeColNm5, this._eachSlipTypeColPrt5, this._eachSlipTypeColId6, this._eachSlipTypeColNm6, this._eachSlipTypeColPrt6, this._eachSlipTypeColId7, this._eachSlipTypeColNm7, this._eachSlipTypeColPrt7, this._eachSlipTypeColId8, this._eachSlipTypeColNm8, this._eachSlipTypeColPrt8, this._eachSlipTypeColId9, this._eachSlipTypeColNm9, this._eachSlipTypeColPrt9, this._eachSlipTypeColId10, this._eachSlipTypeColNm10, this._eachSlipTypeColPrt10, this._slipFontName, this._slipFontSize, this._slipFontStyle, this._slipBaseColorRed1, this._slipBaseColorGrn1, this._slipBaseColorBlu1, this._slipBaseColorRed2, this._slipBaseColorGrn2, this._slipBaseColorBlu2, this._slipBaseColorRed3, this._slipBaseColorGrn3, this._slipBaseColorBlu3, this._slipBaseColorRed4, this._slipBaseColorGrn4, this._slipBaseColorBlu4, this._slipBaseColorRed5, this._slipBaseColorGrn5, this._slipBaseColorBlu5, this._copyCount, this._titleName1, this._titleName2, this._titleName3, this._titleName4, this._specialPurpose1, this._specialPurpose2, this._specialPurpose3, this._specialPurpose4, this._titleName102, this._titleName103, this._titleName104, this._titleName105, this._titleName202, this._titleName203, this._titleName204, this._titleName205, this._titleName302, this._titleName303, this._titleName304, this._titleName305, this._titleName402, this._titleName403, this._titleName404, this._titleName405, this._note1, this._note2, this._note3, this._qRCodePrintDivCd, this._timePrintDivCd, this._reissueMark, this._refConsTaxDivCd, this._refConsTaxPrtNm, this._detailRowCount, this._honorificTitle, this._slipNoteCharCnt, this._slipNote2CharCnt, this._slipNote3CharCnt, this._consTaxPrtCd, this._enterpriseName, this._updEmployeeName, this._dataInputSystemName, this._customerCode, this._updateFlag, this._entNmPrtExpDiv,this._sCMAnsMarkPrtDiv,this._normalPrtMark,this._sCMManualAnsMark,this._sCMAutoAnsMark);// ADD 2011/07/19
		}

		/// <summary>
		/// 伝票印刷設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のSlipPrtSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipPrtSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/02/16  鄧潘ハン</br>
        /// <br>                     自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
		public bool Equals(SlipPrtSet target)
		{
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.DataInputSystem == target.DataInputSystem)
                 && (this.SlipPrtKind == target.SlipPrtKind)
                 && (this.SlipPrtSetPaperId == target.SlipPrtSetPaperId)
                 && (this.SlipComment == target.SlipComment)
                 && (this.OutputPgId == target.OutputPgId)
                 && (this.OutputPgClassId == target.OutputPgClassId)
                 && (this.OutputFormFileName == target.OutputFormFileName)
                 && (this.EnterpriseNamePrtCd == target.EnterpriseNamePrtCd)
                 && (this.PrtCirculation == target.PrtCirculation)
                 && (this.SlipFormCd == target.SlipFormCd)
                 && (this.OutConfimationMsg == target.OutConfimationMsg)
                 && (this.OptionCode == target.OptionCode)
                 && (this.TopMargin == target.TopMargin)
                 && (this.LeftMargin == target.LeftMargin)
                 && (this.RightMargin == target.RightMargin)
                 && (this.BottomMargin == target.BottomMargin)
                 && (this.PrtPreviewExistCode == target.PrtPreviewExistCode)
                 && (this.OutputPurpose == target.OutputPurpose)
                 && (this.EachSlipTypeColId1 == target.EachSlipTypeColId1)
                 && (this.EachSlipTypeColNm1 == target.EachSlipTypeColNm1)
                 && (this.EachSlipTypeColPrt1 == target.EachSlipTypeColPrt1)
                 && (this.EachSlipTypeColId2 == target.EachSlipTypeColId2)
                 && (this.EachSlipTypeColNm2 == target.EachSlipTypeColNm2)
                 && (this.EachSlipTypeColPrt2 == target.EachSlipTypeColPrt2)
                 && (this.EachSlipTypeColId3 == target.EachSlipTypeColId3)
                 && (this.EachSlipTypeColNm3 == target.EachSlipTypeColNm3)
                 && (this.EachSlipTypeColPrt3 == target.EachSlipTypeColPrt3)
                 && (this.EachSlipTypeColId4 == target.EachSlipTypeColId4)
                 && (this.EachSlipTypeColNm4 == target.EachSlipTypeColNm4)
                 && (this.EachSlipTypeColPrt4 == target.EachSlipTypeColPrt4)
                 && (this.EachSlipTypeColId5 == target.EachSlipTypeColId5)
                 && (this.EachSlipTypeColNm5 == target.EachSlipTypeColNm5)
                 && (this.EachSlipTypeColPrt5 == target.EachSlipTypeColPrt5)
                 && (this.EachSlipTypeColId6 == target.EachSlipTypeColId6)
                 && (this.EachSlipTypeColNm6 == target.EachSlipTypeColNm6)
                 && (this.EachSlipTypeColPrt6 == target.EachSlipTypeColPrt6)
                 && (this.EachSlipTypeColId7 == target.EachSlipTypeColId7)
                 && (this.EachSlipTypeColNm7 == target.EachSlipTypeColNm7)
                 && (this.EachSlipTypeColPrt7 == target.EachSlipTypeColPrt7)
                 && (this.EachSlipTypeColId8 == target.EachSlipTypeColId8)
                 && (this.EachSlipTypeColNm8 == target.EachSlipTypeColNm8)
                 && (this.EachSlipTypeColPrt8 == target.EachSlipTypeColPrt8)
                 && (this.EachSlipTypeColId9 == target.EachSlipTypeColId9)
                 && (this.EachSlipTypeColNm9 == target.EachSlipTypeColNm9)
                 && (this.EachSlipTypeColPrt9 == target.EachSlipTypeColPrt9)
                 && (this.EachSlipTypeColId10 == target.EachSlipTypeColId10)
                 && (this.EachSlipTypeColNm10 == target.EachSlipTypeColNm10)
                 && (this.EachSlipTypeColPrt10 == target.EachSlipTypeColPrt10)
                 && (this.SlipFontName == target.SlipFontName)
                 && (this.SlipFontSize == target.SlipFontSize)
                 && (this.SlipFontStyle == target.SlipFontStyle)
                 && (this.SlipBaseColorRed1 == target.SlipBaseColorRed1)
                 && (this.SlipBaseColorGrn1 == target.SlipBaseColorGrn1)
                 && (this.SlipBaseColorBlu1 == target.SlipBaseColorBlu1)
                 && (this.SlipBaseColorRed2 == target.SlipBaseColorRed2)
                 && (this.SlipBaseColorGrn2 == target.SlipBaseColorGrn2)
                 && (this.SlipBaseColorBlu2 == target.SlipBaseColorBlu2)
                 && (this.SlipBaseColorRed3 == target.SlipBaseColorRed3)
                 && (this.SlipBaseColorGrn3 == target.SlipBaseColorGrn3)
                 && (this.SlipBaseColorBlu3 == target.SlipBaseColorBlu3)
                 && (this.SlipBaseColorRed4 == target.SlipBaseColorRed4)
                 && (this.SlipBaseColorGrn4 == target.SlipBaseColorGrn4)
                 && (this.SlipBaseColorBlu4 == target.SlipBaseColorBlu4)
                 && (this.SlipBaseColorRed5 == target.SlipBaseColorRed5)
                 && (this.SlipBaseColorGrn5 == target.SlipBaseColorGrn5)
                 && (this.SlipBaseColorBlu5 == target.SlipBaseColorBlu5)
                 && (this.CopyCount == target.CopyCount)
                 && (this.TitleName1 == target.TitleName1)
                 && (this.TitleName2 == target.TitleName2)
                 && (this.TitleName3 == target.TitleName3)
                 && (this.TitleName4 == target.TitleName4)
                 && (this.SpecialPurpose1 == target.SpecialPurpose1)
                 && (this.SpecialPurpose2 == target.SpecialPurpose2)
                 && (this.SpecialPurpose3 == target.SpecialPurpose3)
                 && (this.SpecialPurpose4 == target.SpecialPurpose4)
                 && (this.TitleName102 == target.TitleName102)
                 && (this.TitleName103 == target.TitleName103)
                 && (this.TitleName104 == target.TitleName104)
                 && (this.TitleName105 == target.TitleName105)
                 && (this.TitleName202 == target.TitleName202)
                 && (this.TitleName203 == target.TitleName203)
                 && (this.TitleName204 == target.TitleName204)
                 && (this.TitleName205 == target.TitleName205)
                 && (this.TitleName302 == target.TitleName302)
                 && (this.TitleName303 == target.TitleName303)
                 && (this.TitleName304 == target.TitleName304)
                 && (this.TitleName305 == target.TitleName305)
                 && (this.TitleName402 == target.TitleName402)
                 && (this.TitleName403 == target.TitleName403)
                 && (this.TitleName404 == target.TitleName404)
                 && (this.TitleName405 == target.TitleName405)
                 && (this.Note1 == target.Note1)
                 && (this.Note2 == target.Note2)
                 && (this.Note3 == target.Note3)
                 && (this.QRCodePrintDivCd == target.QRCodePrintDivCd)
                 && (this.TimePrintDivCd == target.TimePrintDivCd)
                 && (this.ReissueMark == target.ReissueMark)
                 && (this.RefConsTaxDivCd == target.RefConsTaxDivCd)
                 && (this.RefConsTaxPrtNm == target.RefConsTaxPrtNm)
                 && (this.DetailRowCount == target.DetailRowCount)
                 && (this.HonorificTitle == target.HonorificTitle)
                // --- ADD 2009/12/31 ---------->>>>>
                 && (this.SlipNoteCharCnt == target.SlipNoteCharCnt)
                 && (this.SlipNote2CharCnt == target.SlipNote2CharCnt)
                 && (this.SlipNote3CharCnt == target.SlipNote3CharCnt)
                // --- ADD 2009/12/31 ----------<<<<<
                 && (this.ConsTaxPrtCd == target.ConsTaxPrtCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.DataInputSystemName == target.DataInputSystemName)
                // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.UpdateFlag == target.UpdateFlag)
                // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
                 && (this.EntNmPrtExpDiv == target.EntNmPrtExpDiv)) // ADD 2011/02/16
                // --- ADD 2011/07/19 ---------->>>>>
                 && (this.SCMAnsMarkPrtDiv == target.SCMAnsMarkPrtDiv)
                 && (this.NormalPrtMark == target.NormalPrtMark)
                 && (this.SCMManualAnsMark == target.SCMManualAnsMark)
                 && (this.SCMAutoAnsMark == target.SCMAutoAnsMark);
                // --- ADD 2011/07/19 ----------<<<<<
    
		}

		/// <summary>
		/// 伝票印刷設定マスタ比較処理
		/// </summary>
		/// <param name="slipPrtSet1">
		///                    比較するSlipPrtSetクラスのインスタンス
		/// </param>
		/// <param name="slipPrtSet2">比較するSlipPrtSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipPrtSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/02/16  鄧潘ハン</br>
        /// <br>                     自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
		public static bool Equals(SlipPrtSet slipPrtSet1, SlipPrtSet slipPrtSet2)
		{
            return ((slipPrtSet1.CreateDateTime == slipPrtSet2.CreateDateTime)
                 && (slipPrtSet1.UpdateDateTime == slipPrtSet2.UpdateDateTime)
                 && (slipPrtSet1.EnterpriseCode == slipPrtSet2.EnterpriseCode)
                 && (slipPrtSet1.FileHeaderGuid == slipPrtSet2.FileHeaderGuid)
                 && (slipPrtSet1.UpdEmployeeCode == slipPrtSet2.UpdEmployeeCode)
                 && (slipPrtSet1.UpdAssemblyId1 == slipPrtSet2.UpdAssemblyId1)
                 && (slipPrtSet1.UpdAssemblyId2 == slipPrtSet2.UpdAssemblyId2)
                 && (slipPrtSet1.LogicalDeleteCode == slipPrtSet2.LogicalDeleteCode)
                 && (slipPrtSet1.DataInputSystem == slipPrtSet2.DataInputSystem)
                 && (slipPrtSet1.SlipPrtKind == slipPrtSet2.SlipPrtKind)
                 && (slipPrtSet1.SlipPrtSetPaperId == slipPrtSet2.SlipPrtSetPaperId)
                 && (slipPrtSet1.SlipComment == slipPrtSet2.SlipComment)
                 && (slipPrtSet1.OutputPgId == slipPrtSet2.OutputPgId)
                 && (slipPrtSet1.OutputPgClassId == slipPrtSet2.OutputPgClassId)
                 && (slipPrtSet1.OutputFormFileName == slipPrtSet2.OutputFormFileName)
                 && (slipPrtSet1.EnterpriseNamePrtCd == slipPrtSet2.EnterpriseNamePrtCd)
                 && (slipPrtSet1.PrtCirculation == slipPrtSet2.PrtCirculation)
                 && (slipPrtSet1.SlipFormCd == slipPrtSet2.SlipFormCd)
                 && (slipPrtSet1.OutConfimationMsg == slipPrtSet2.OutConfimationMsg)
                 && (slipPrtSet1.OptionCode == slipPrtSet2.OptionCode)
                 && (slipPrtSet1.TopMargin == slipPrtSet2.TopMargin)
                 && (slipPrtSet1.LeftMargin == slipPrtSet2.LeftMargin)
                 && (slipPrtSet1.RightMargin == slipPrtSet2.RightMargin)
                 && (slipPrtSet1.BottomMargin == slipPrtSet2.BottomMargin)
                 && (slipPrtSet1.PrtPreviewExistCode == slipPrtSet2.PrtPreviewExistCode)
                 && (slipPrtSet1.OutputPurpose == slipPrtSet2.OutputPurpose)
                 && (slipPrtSet1.EachSlipTypeColId1 == slipPrtSet2.EachSlipTypeColId1)
                 && (slipPrtSet1.EachSlipTypeColNm1 == slipPrtSet2.EachSlipTypeColNm1)
                 && (slipPrtSet1.EachSlipTypeColPrt1 == slipPrtSet2.EachSlipTypeColPrt1)
                 && (slipPrtSet1.EachSlipTypeColId2 == slipPrtSet2.EachSlipTypeColId2)
                 && (slipPrtSet1.EachSlipTypeColNm2 == slipPrtSet2.EachSlipTypeColNm2)
                 && (slipPrtSet1.EachSlipTypeColPrt2 == slipPrtSet2.EachSlipTypeColPrt2)
                 && (slipPrtSet1.EachSlipTypeColId3 == slipPrtSet2.EachSlipTypeColId3)
                 && (slipPrtSet1.EachSlipTypeColNm3 == slipPrtSet2.EachSlipTypeColNm3)
                 && (slipPrtSet1.EachSlipTypeColPrt3 == slipPrtSet2.EachSlipTypeColPrt3)
                 && (slipPrtSet1.EachSlipTypeColId4 == slipPrtSet2.EachSlipTypeColId4)
                 && (slipPrtSet1.EachSlipTypeColNm4 == slipPrtSet2.EachSlipTypeColNm4)
                 && (slipPrtSet1.EachSlipTypeColPrt4 == slipPrtSet2.EachSlipTypeColPrt4)
                 && (slipPrtSet1.EachSlipTypeColId5 == slipPrtSet2.EachSlipTypeColId5)
                 && (slipPrtSet1.EachSlipTypeColNm5 == slipPrtSet2.EachSlipTypeColNm5)
                 && (slipPrtSet1.EachSlipTypeColPrt5 == slipPrtSet2.EachSlipTypeColPrt5)
                 && (slipPrtSet1.EachSlipTypeColId6 == slipPrtSet2.EachSlipTypeColId6)
                 && (slipPrtSet1.EachSlipTypeColNm6 == slipPrtSet2.EachSlipTypeColNm6)
                 && (slipPrtSet1.EachSlipTypeColPrt6 == slipPrtSet2.EachSlipTypeColPrt6)
                 && (slipPrtSet1.EachSlipTypeColId7 == slipPrtSet2.EachSlipTypeColId7)
                 && (slipPrtSet1.EachSlipTypeColNm7 == slipPrtSet2.EachSlipTypeColNm7)
                 && (slipPrtSet1.EachSlipTypeColPrt7 == slipPrtSet2.EachSlipTypeColPrt7)
                 && (slipPrtSet1.EachSlipTypeColId8 == slipPrtSet2.EachSlipTypeColId8)
                 && (slipPrtSet1.EachSlipTypeColNm8 == slipPrtSet2.EachSlipTypeColNm8)
                 && (slipPrtSet1.EachSlipTypeColPrt8 == slipPrtSet2.EachSlipTypeColPrt8)
                 && (slipPrtSet1.EachSlipTypeColId9 == slipPrtSet2.EachSlipTypeColId9)
                 && (slipPrtSet1.EachSlipTypeColNm9 == slipPrtSet2.EachSlipTypeColNm9)
                 && (slipPrtSet1.EachSlipTypeColPrt9 == slipPrtSet2.EachSlipTypeColPrt9)
                 && (slipPrtSet1.EachSlipTypeColId10 == slipPrtSet2.EachSlipTypeColId10)
                 && (slipPrtSet1.EachSlipTypeColNm10 == slipPrtSet2.EachSlipTypeColNm10)
                 && (slipPrtSet1.EachSlipTypeColPrt10 == slipPrtSet2.EachSlipTypeColPrt10)
                 && (slipPrtSet1.SlipFontName == slipPrtSet2.SlipFontName)
                 && (slipPrtSet1.SlipFontSize == slipPrtSet2.SlipFontSize)
                 && (slipPrtSet1.SlipFontStyle == slipPrtSet2.SlipFontStyle)
                 && (slipPrtSet1.SlipBaseColorRed1 == slipPrtSet2.SlipBaseColorRed1)
                 && (slipPrtSet1.SlipBaseColorGrn1 == slipPrtSet2.SlipBaseColorGrn1)
                 && (slipPrtSet1.SlipBaseColorBlu1 == slipPrtSet2.SlipBaseColorBlu1)
                 && (slipPrtSet1.SlipBaseColorRed2 == slipPrtSet2.SlipBaseColorRed2)
                 && (slipPrtSet1.SlipBaseColorGrn2 == slipPrtSet2.SlipBaseColorGrn2)
                 && (slipPrtSet1.SlipBaseColorBlu2 == slipPrtSet2.SlipBaseColorBlu2)
                 && (slipPrtSet1.SlipBaseColorRed3 == slipPrtSet2.SlipBaseColorRed3)
                 && (slipPrtSet1.SlipBaseColorGrn3 == slipPrtSet2.SlipBaseColorGrn3)
                 && (slipPrtSet1.SlipBaseColorBlu3 == slipPrtSet2.SlipBaseColorBlu3)
                 && (slipPrtSet1.SlipBaseColorRed4 == slipPrtSet2.SlipBaseColorRed4)
                 && (slipPrtSet1.SlipBaseColorGrn4 == slipPrtSet2.SlipBaseColorGrn4)
                 && (slipPrtSet1.SlipBaseColorBlu4 == slipPrtSet2.SlipBaseColorBlu4)
                 && (slipPrtSet1.SlipBaseColorRed5 == slipPrtSet2.SlipBaseColorRed5)
                 && (slipPrtSet1.SlipBaseColorGrn5 == slipPrtSet2.SlipBaseColorGrn5)
                 && (slipPrtSet1.SlipBaseColorBlu5 == slipPrtSet2.SlipBaseColorBlu5)
                 && (slipPrtSet1.CopyCount == slipPrtSet2.CopyCount)
                 && (slipPrtSet1.TitleName1 == slipPrtSet2.TitleName1)
                 && (slipPrtSet1.TitleName2 == slipPrtSet2.TitleName2)
                 && (slipPrtSet1.TitleName3 == slipPrtSet2.TitleName3)
                 && (slipPrtSet1.TitleName4 == slipPrtSet2.TitleName4)
                 && (slipPrtSet1.SpecialPurpose1 == slipPrtSet2.SpecialPurpose1)
                 && (slipPrtSet1.SpecialPurpose2 == slipPrtSet2.SpecialPurpose2)
                 && (slipPrtSet1.SpecialPurpose3 == slipPrtSet2.SpecialPurpose3)
                 && (slipPrtSet1.SpecialPurpose4 == slipPrtSet2.SpecialPurpose4)
                 && (slipPrtSet1.TitleName102 == slipPrtSet2.TitleName102)
                 && (slipPrtSet1.TitleName103 == slipPrtSet2.TitleName103)
                 && (slipPrtSet1.TitleName104 == slipPrtSet2.TitleName104)
                 && (slipPrtSet1.TitleName105 == slipPrtSet2.TitleName105)
                 && (slipPrtSet1.TitleName202 == slipPrtSet2.TitleName202)
                 && (slipPrtSet1.TitleName203 == slipPrtSet2.TitleName203)
                 && (slipPrtSet1.TitleName204 == slipPrtSet2.TitleName204)
                 && (slipPrtSet1.TitleName205 == slipPrtSet2.TitleName205)
                 && (slipPrtSet1.TitleName302 == slipPrtSet2.TitleName302)
                 && (slipPrtSet1.TitleName303 == slipPrtSet2.TitleName303)
                 && (slipPrtSet1.TitleName304 == slipPrtSet2.TitleName304)
                 && (slipPrtSet1.TitleName305 == slipPrtSet2.TitleName305)
                 && (slipPrtSet1.TitleName402 == slipPrtSet2.TitleName402)
                 && (slipPrtSet1.TitleName403 == slipPrtSet2.TitleName403)
                 && (slipPrtSet1.TitleName404 == slipPrtSet2.TitleName404)
                 && (slipPrtSet1.TitleName405 == slipPrtSet2.TitleName405)
                 && (slipPrtSet1.Note1 == slipPrtSet2.Note1)
                 && (slipPrtSet1.Note2 == slipPrtSet2.Note2)
                 && (slipPrtSet1.Note3 == slipPrtSet2.Note3)
                 && (slipPrtSet1.QRCodePrintDivCd == slipPrtSet2.QRCodePrintDivCd)
                 && (slipPrtSet1.TimePrintDivCd == slipPrtSet2.TimePrintDivCd)
                 && (slipPrtSet1.ReissueMark == slipPrtSet2.ReissueMark)
                 && (slipPrtSet1.RefConsTaxDivCd == slipPrtSet2.RefConsTaxDivCd)
                 && (slipPrtSet1.RefConsTaxPrtNm == slipPrtSet2.RefConsTaxPrtNm)
                 && (slipPrtSet1.DetailRowCount == slipPrtSet2.DetailRowCount)
                 && (slipPrtSet1.HonorificTitle == slipPrtSet2.HonorificTitle)
                // --- ADD 2009/12/31 ---------->>>>>
                 && (slipPrtSet1.SlipNoteCharCnt == slipPrtSet2.SlipNoteCharCnt)
                 && (slipPrtSet1.SlipNote2CharCnt == slipPrtSet2.SlipNote2CharCnt)
                 && (slipPrtSet1.SlipNote3CharCnt == slipPrtSet2.SlipNote3CharCnt)
                // --- ADD 2009/12/31 ----------<<<<<
                 && (slipPrtSet1.ConsTaxPrtCd == slipPrtSet2.ConsTaxPrtCd)
                 && (slipPrtSet1.EnterpriseName == slipPrtSet2.EnterpriseName)
                 && (slipPrtSet1.UpdEmployeeName == slipPrtSet2.UpdEmployeeName)
                 && (slipPrtSet1.DataInputSystemName == slipPrtSet2.DataInputSystemName)
                // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
                 && (slipPrtSet1.CustomerCode == slipPrtSet2.CustomerCode)
                 && (slipPrtSet1.UpdateFlag == slipPrtSet2.UpdateFlag)
                // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
                && (slipPrtSet1.EntNmPrtExpDiv == slipPrtSet2.EntNmPrtExpDiv)) // ADD 2011/02/16
                // --- ADD 2011/07/19 ---------->>>>>
                && (slipPrtSet1.SCMAnsMarkPrtDiv == slipPrtSet2.SCMAnsMarkPrtDiv)
                && (slipPrtSet1.NormalPrtMark == slipPrtSet2.NormalPrtMark)
                && (slipPrtSet1.SCMManualAnsMark == slipPrtSet2.SCMManualAnsMark)
                && (slipPrtSet1.SCMAutoAnsMark == slipPrtSet2.SCMAutoAnsMark);
                // --- ADD 2011/07/19 ----------<<<<<

		}
		/// <summary>
		/// 伝票印刷設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のSlipPrtSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipPrtSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/02/16  鄧潘ハン</br>
        /// <br>                     自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
		public ArrayList Compare(SlipPrtSet target)
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
			if(this.DataInputSystem != target.DataInputSystem)resList.Add("DataInputSystem");
			if(this.SlipPrtKind != target.SlipPrtKind)resList.Add("SlipPrtKind");
			if(this.SlipPrtSetPaperId != target.SlipPrtSetPaperId)resList.Add("SlipPrtSetPaperId");
			if(this.SlipComment != target.SlipComment)resList.Add("SlipComment");
			if(this.OutputPgId != target.OutputPgId)resList.Add("OutputPgId");
			if(this.OutputPgClassId != target.OutputPgClassId)resList.Add("OutputPgClassId");
			if(this.OutputFormFileName != target.OutputFormFileName)resList.Add("OutputFormFileName");
			if(this.EnterpriseNamePrtCd != target.EnterpriseNamePrtCd)resList.Add("EnterpriseNamePrtCd");
			if(this.PrtCirculation != target.PrtCirculation)resList.Add("PrtCirculation");
			if(this.SlipFormCd != target.SlipFormCd)resList.Add("SlipFormCd");
			if(this.OutConfimationMsg != target.OutConfimationMsg)resList.Add("OutConfimationMsg");
			if(this.OptionCode != target.OptionCode)resList.Add("OptionCode");
			if(this.TopMargin != target.TopMargin)resList.Add("TopMargin");
			if(this.LeftMargin != target.LeftMargin)resList.Add("LeftMargin");
			if(this.RightMargin != target.RightMargin)resList.Add("RightMargin");
			if(this.BottomMargin != target.BottomMargin)resList.Add("BottomMargin");
			if(this.PrtPreviewExistCode != target.PrtPreviewExistCode)resList.Add("PrtPreviewExistCode");
			if(this.OutputPurpose != target.OutputPurpose)resList.Add("OutputPurpose");
			if(this.EachSlipTypeColId1 != target.EachSlipTypeColId1)resList.Add("EachSlipTypeColId1");
			if(this.EachSlipTypeColNm1 != target.EachSlipTypeColNm1)resList.Add("EachSlipTypeColNm1");
			if(this.EachSlipTypeColPrt1 != target.EachSlipTypeColPrt1)resList.Add("EachSlipTypeColPrt1");
			if(this.EachSlipTypeColId2 != target.EachSlipTypeColId2)resList.Add("EachSlipTypeColId2");
			if(this.EachSlipTypeColNm2 != target.EachSlipTypeColNm2)resList.Add("EachSlipTypeColNm2");
			if(this.EachSlipTypeColPrt2 != target.EachSlipTypeColPrt2)resList.Add("EachSlipTypeColPrt2");
			if(this.EachSlipTypeColId3 != target.EachSlipTypeColId3)resList.Add("EachSlipTypeColId3");
			if(this.EachSlipTypeColNm3 != target.EachSlipTypeColNm3)resList.Add("EachSlipTypeColNm3");
			if(this.EachSlipTypeColPrt3 != target.EachSlipTypeColPrt3)resList.Add("EachSlipTypeColPrt3");
			if(this.EachSlipTypeColId4 != target.EachSlipTypeColId4)resList.Add("EachSlipTypeColId4");
			if(this.EachSlipTypeColNm4 != target.EachSlipTypeColNm4)resList.Add("EachSlipTypeColNm4");
			if(this.EachSlipTypeColPrt4 != target.EachSlipTypeColPrt4)resList.Add("EachSlipTypeColPrt4");
			if(this.EachSlipTypeColId5 != target.EachSlipTypeColId5)resList.Add("EachSlipTypeColId5");
			if(this.EachSlipTypeColNm5 != target.EachSlipTypeColNm5)resList.Add("EachSlipTypeColNm5");
			if(this.EachSlipTypeColPrt5 != target.EachSlipTypeColPrt5)resList.Add("EachSlipTypeColPrt5");
			if(this.EachSlipTypeColId6 != target.EachSlipTypeColId6)resList.Add("EachSlipTypeColId6");
			if(this.EachSlipTypeColNm6 != target.EachSlipTypeColNm6)resList.Add("EachSlipTypeColNm6");
			if(this.EachSlipTypeColPrt6 != target.EachSlipTypeColPrt6)resList.Add("EachSlipTypeColPrt6");
			if(this.EachSlipTypeColId7 != target.EachSlipTypeColId7)resList.Add("EachSlipTypeColId7");
			if(this.EachSlipTypeColNm7 != target.EachSlipTypeColNm7)resList.Add("EachSlipTypeColNm7");
			if(this.EachSlipTypeColPrt7 != target.EachSlipTypeColPrt7)resList.Add("EachSlipTypeColPrt7");
			if(this.EachSlipTypeColId8 != target.EachSlipTypeColId8)resList.Add("EachSlipTypeColId8");
			if(this.EachSlipTypeColNm8 != target.EachSlipTypeColNm8)resList.Add("EachSlipTypeColNm8");
			if(this.EachSlipTypeColPrt8 != target.EachSlipTypeColPrt8)resList.Add("EachSlipTypeColPrt8");
			if(this.EachSlipTypeColId9 != target.EachSlipTypeColId9)resList.Add("EachSlipTypeColId9");
			if(this.EachSlipTypeColNm9 != target.EachSlipTypeColNm9)resList.Add("EachSlipTypeColNm9");
			if(this.EachSlipTypeColPrt9 != target.EachSlipTypeColPrt9)resList.Add("EachSlipTypeColPrt9");
			if(this.EachSlipTypeColId10 != target.EachSlipTypeColId10)resList.Add("EachSlipTypeColId10");
			if(this.EachSlipTypeColNm10 != target.EachSlipTypeColNm10)resList.Add("EachSlipTypeColNm10");
			if(this.EachSlipTypeColPrt10 != target.EachSlipTypeColPrt10)resList.Add("EachSlipTypeColPrt10");
			if(this.SlipFontName != target.SlipFontName)resList.Add("SlipFontName");
			if(this.SlipFontSize != target.SlipFontSize)resList.Add("SlipFontSize");
			if(this.SlipFontStyle != target.SlipFontStyle)resList.Add("SlipFontStyle");
			if(this.SlipBaseColorRed1 != target.SlipBaseColorRed1)resList.Add("SlipBaseColorRed1");
			if(this.SlipBaseColorGrn1 != target.SlipBaseColorGrn1)resList.Add("SlipBaseColorGrn1");
			if(this.SlipBaseColorBlu1 != target.SlipBaseColorBlu1)resList.Add("SlipBaseColorBlu1");
			if(this.SlipBaseColorRed2 != target.SlipBaseColorRed2)resList.Add("SlipBaseColorRed2");
			if(this.SlipBaseColorGrn2 != target.SlipBaseColorGrn2)resList.Add("SlipBaseColorGrn2");
			if(this.SlipBaseColorBlu2 != target.SlipBaseColorBlu2)resList.Add("SlipBaseColorBlu2");
			if(this.SlipBaseColorRed3 != target.SlipBaseColorRed3)resList.Add("SlipBaseColorRed3");
			if(this.SlipBaseColorGrn3 != target.SlipBaseColorGrn3)resList.Add("SlipBaseColorGrn3");
			if(this.SlipBaseColorBlu3 != target.SlipBaseColorBlu3)resList.Add("SlipBaseColorBlu3");
			if(this.SlipBaseColorRed4 != target.SlipBaseColorRed4)resList.Add("SlipBaseColorRed4");
			if(this.SlipBaseColorGrn4 != target.SlipBaseColorGrn4)resList.Add("SlipBaseColorGrn4");
			if(this.SlipBaseColorBlu4 != target.SlipBaseColorBlu4)resList.Add("SlipBaseColorBlu4");
			if(this.SlipBaseColorRed5 != target.SlipBaseColorRed5)resList.Add("SlipBaseColorRed5");
			if(this.SlipBaseColorGrn5 != target.SlipBaseColorGrn5)resList.Add("SlipBaseColorGrn5");
			if(this.SlipBaseColorBlu5 != target.SlipBaseColorBlu5)resList.Add("SlipBaseColorBlu5");
			if(this.CopyCount != target.CopyCount)resList.Add("CopyCount");
			if(this.TitleName1 != target.TitleName1)resList.Add("TitleName1");
			if(this.TitleName2 != target.TitleName2)resList.Add("TitleName2");
			if(this.TitleName3 != target.TitleName3)resList.Add("TitleName3");
			if(this.TitleName4 != target.TitleName4)resList.Add("TitleName4");
			if(this.SpecialPurpose1 != target.SpecialPurpose1)resList.Add("SpecialPurpose1");
			if(this.SpecialPurpose2 != target.SpecialPurpose2)resList.Add("SpecialPurpose2");
			if(this.SpecialPurpose3 != target.SpecialPurpose3)resList.Add("SpecialPurpose3");
			if(this.SpecialPurpose4 != target.SpecialPurpose4)resList.Add("SpecialPurpose4");
			if(this.TitleName102 != target.TitleName102)resList.Add("TitleName102");
			if(this.TitleName103 != target.TitleName103)resList.Add("TitleName103");
			if(this.TitleName104 != target.TitleName104)resList.Add("TitleName104");
			if(this.TitleName105 != target.TitleName105)resList.Add("TitleName105");
			if(this.TitleName202 != target.TitleName202)resList.Add("TitleName202");
			if(this.TitleName203 != target.TitleName203)resList.Add("TitleName203");
			if(this.TitleName204 != target.TitleName204)resList.Add("TitleName204");
			if(this.TitleName205 != target.TitleName205)resList.Add("TitleName205");
			if(this.TitleName302 != target.TitleName302)resList.Add("TitleName302");
			if(this.TitleName303 != target.TitleName303)resList.Add("TitleName303");
			if(this.TitleName304 != target.TitleName304)resList.Add("TitleName304");
			if(this.TitleName305 != target.TitleName305)resList.Add("TitleName305");
			if(this.TitleName402 != target.TitleName402)resList.Add("TitleName402");
			if(this.TitleName403 != target.TitleName403)resList.Add("TitleName403");
			if(this.TitleName404 != target.TitleName404)resList.Add("TitleName404");
			if(this.TitleName405 != target.TitleName405)resList.Add("TitleName405");
			if(this.Note1 != target.Note1)resList.Add("Note1");
			if(this.Note2 != target.Note2)resList.Add("Note2");
			if(this.Note3 != target.Note3)resList.Add("Note3");
			if(this.QRCodePrintDivCd != target.QRCodePrintDivCd)resList.Add("QRCodePrintDivCd");
			if(this.TimePrintDivCd != target.TimePrintDivCd)resList.Add("TimePrintDivCd");
			if(this.ReissueMark != target.ReissueMark)resList.Add("ReissueMark");
			if(this.RefConsTaxDivCd != target.RefConsTaxDivCd)resList.Add("RefConsTaxDivCd");
			if(this.RefConsTaxPrtNm != target.RefConsTaxPrtNm)resList.Add("RefConsTaxPrtNm");
			if(this.DetailRowCount != target.DetailRowCount)resList.Add("DetailRowCount");
			if(this.HonorificTitle != target.HonorificTitle)resList.Add("HonorificTitle");
            // --- ADD 2009/12/31 ---------->>>>>
            if (this.SlipNoteCharCnt != target.SlipNoteCharCnt) resList.Add("SlipNoteCharCnt");
            if (this.SlipNote2CharCnt != target.SlipNote2CharCnt) resList.Add("SlipNote2CharCnt");
            if (this.SlipNote3CharCnt != target.SlipNote3CharCnt) resList.Add("SlipNote3CharCnt");
            // --- ADD 2009/12/31 ----------<<<<<
            if (this.ConsTaxPrtCd != target.ConsTaxPrtCd) resList.Add("ConsTaxPrtCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
			if(this.UpdEmployeeName != target.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(this.DataInputSystemName != target.DataInputSystemName)resList.Add("DataInputSystemName");

            // --- ADD 2010/08/06 ---------->>>>>
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.UpdateFlag != target.UpdateFlag) resList.Add("UpdateFlag");
            // --- ADD 2010/08/06 ----------<<<<<
            if (this.EntNmPrtExpDiv != target.EntNmPrtExpDiv) resList.Add("EntNmPrtExpDiv"); // ADD 2011/02/16
            // --- ADD 2011/07/19 ---------->>>>>
            if (this.SCMAnsMarkPrtDiv != target.SCMAnsMarkPrtDiv) resList.Add("SCMAnsMarkPrtDiv");
            if (this.NormalPrtMark != target.NormalPrtMark) resList.Add("NormalPrtMark");
            if (this.SCMManualAnsMark != target.SCMManualAnsMark) resList.Add("SCMManualAnsMark");
            if (this.SCMAutoAnsMark != target.SCMAutoAnsMark) resList.Add("SCMAutoAnsMark");
            // --- ADD 2011/07/19 ----------<<<<<
			
            return resList;
		}

		/// <summary>
		/// 伝票印刷設定マスタ比較処理
		/// </summary>
		/// <param name="slipPrtSet1">比較するSlipPrtSetクラスのインスタンス</param>
		/// <param name="slipPrtSet2">比較するSlipPrtSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SlipPrtSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/02/16  鄧潘ハン</br>
        /// <br>                     自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
		public static ArrayList Compare(SlipPrtSet slipPrtSet1, SlipPrtSet slipPrtSet2)
		{
			ArrayList resList = new ArrayList();
			if(slipPrtSet1.CreateDateTime != slipPrtSet2.CreateDateTime)resList.Add("CreateDateTime");
			if(slipPrtSet1.UpdateDateTime != slipPrtSet2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(slipPrtSet1.EnterpriseCode != slipPrtSet2.EnterpriseCode)resList.Add("EnterpriseCode");
			if(slipPrtSet1.FileHeaderGuid != slipPrtSet2.FileHeaderGuid)resList.Add("FileHeaderGuid");
			if(slipPrtSet1.UpdEmployeeCode != slipPrtSet2.UpdEmployeeCode)resList.Add("UpdEmployeeCode");
			if(slipPrtSet1.UpdAssemblyId1 != slipPrtSet2.UpdAssemblyId1)resList.Add("UpdAssemblyId1");
			if(slipPrtSet1.UpdAssemblyId2 != slipPrtSet2.UpdAssemblyId2)resList.Add("UpdAssemblyId2");
			if(slipPrtSet1.LogicalDeleteCode != slipPrtSet2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(slipPrtSet1.DataInputSystem != slipPrtSet2.DataInputSystem)resList.Add("DataInputSystem");
			if(slipPrtSet1.SlipPrtKind != slipPrtSet2.SlipPrtKind)resList.Add("SlipPrtKind");
			if(slipPrtSet1.SlipPrtSetPaperId != slipPrtSet2.SlipPrtSetPaperId)resList.Add("SlipPrtSetPaperId");
			if(slipPrtSet1.SlipComment != slipPrtSet2.SlipComment)resList.Add("SlipComment");
			if(slipPrtSet1.OutputPgId != slipPrtSet2.OutputPgId)resList.Add("OutputPgId");
			if(slipPrtSet1.OutputPgClassId != slipPrtSet2.OutputPgClassId)resList.Add("OutputPgClassId");
			if(slipPrtSet1.OutputFormFileName != slipPrtSet2.OutputFormFileName)resList.Add("OutputFormFileName");
			if(slipPrtSet1.EnterpriseNamePrtCd != slipPrtSet2.EnterpriseNamePrtCd)resList.Add("EnterpriseNamePrtCd");
			if(slipPrtSet1.PrtCirculation != slipPrtSet2.PrtCirculation)resList.Add("PrtCirculation");
			if(slipPrtSet1.SlipFormCd != slipPrtSet2.SlipFormCd)resList.Add("SlipFormCd");
			if(slipPrtSet1.OutConfimationMsg != slipPrtSet2.OutConfimationMsg)resList.Add("OutConfimationMsg");
			if(slipPrtSet1.OptionCode != slipPrtSet2.OptionCode)resList.Add("OptionCode");
			if(slipPrtSet1.TopMargin != slipPrtSet2.TopMargin)resList.Add("TopMargin");
			if(slipPrtSet1.LeftMargin != slipPrtSet2.LeftMargin)resList.Add("LeftMargin");
			if(slipPrtSet1.RightMargin != slipPrtSet2.RightMargin)resList.Add("RightMargin");
			if(slipPrtSet1.BottomMargin != slipPrtSet2.BottomMargin)resList.Add("BottomMargin");
			if(slipPrtSet1.PrtPreviewExistCode != slipPrtSet2.PrtPreviewExistCode)resList.Add("PrtPreviewExistCode");
			if(slipPrtSet1.OutputPurpose != slipPrtSet2.OutputPurpose)resList.Add("OutputPurpose");
			if(slipPrtSet1.EachSlipTypeColId1 != slipPrtSet2.EachSlipTypeColId1)resList.Add("EachSlipTypeColId1");
			if(slipPrtSet1.EachSlipTypeColNm1 != slipPrtSet2.EachSlipTypeColNm1)resList.Add("EachSlipTypeColNm1");
			if(slipPrtSet1.EachSlipTypeColPrt1 != slipPrtSet2.EachSlipTypeColPrt1)resList.Add("EachSlipTypeColPrt1");
			if(slipPrtSet1.EachSlipTypeColId2 != slipPrtSet2.EachSlipTypeColId2)resList.Add("EachSlipTypeColId2");
			if(slipPrtSet1.EachSlipTypeColNm2 != slipPrtSet2.EachSlipTypeColNm2)resList.Add("EachSlipTypeColNm2");
			if(slipPrtSet1.EachSlipTypeColPrt2 != slipPrtSet2.EachSlipTypeColPrt2)resList.Add("EachSlipTypeColPrt2");
			if(slipPrtSet1.EachSlipTypeColId3 != slipPrtSet2.EachSlipTypeColId3)resList.Add("EachSlipTypeColId3");
			if(slipPrtSet1.EachSlipTypeColNm3 != slipPrtSet2.EachSlipTypeColNm3)resList.Add("EachSlipTypeColNm3");
			if(slipPrtSet1.EachSlipTypeColPrt3 != slipPrtSet2.EachSlipTypeColPrt3)resList.Add("EachSlipTypeColPrt3");
			if(slipPrtSet1.EachSlipTypeColId4 != slipPrtSet2.EachSlipTypeColId4)resList.Add("EachSlipTypeColId4");
			if(slipPrtSet1.EachSlipTypeColNm4 != slipPrtSet2.EachSlipTypeColNm4)resList.Add("EachSlipTypeColNm4");
			if(slipPrtSet1.EachSlipTypeColPrt4 != slipPrtSet2.EachSlipTypeColPrt4)resList.Add("EachSlipTypeColPrt4");
			if(slipPrtSet1.EachSlipTypeColId5 != slipPrtSet2.EachSlipTypeColId5)resList.Add("EachSlipTypeColId5");
			if(slipPrtSet1.EachSlipTypeColNm5 != slipPrtSet2.EachSlipTypeColNm5)resList.Add("EachSlipTypeColNm5");
			if(slipPrtSet1.EachSlipTypeColPrt5 != slipPrtSet2.EachSlipTypeColPrt5)resList.Add("EachSlipTypeColPrt5");
			if(slipPrtSet1.EachSlipTypeColId6 != slipPrtSet2.EachSlipTypeColId6)resList.Add("EachSlipTypeColId6");
			if(slipPrtSet1.EachSlipTypeColNm6 != slipPrtSet2.EachSlipTypeColNm6)resList.Add("EachSlipTypeColNm6");
			if(slipPrtSet1.EachSlipTypeColPrt6 != slipPrtSet2.EachSlipTypeColPrt6)resList.Add("EachSlipTypeColPrt6");
			if(slipPrtSet1.EachSlipTypeColId7 != slipPrtSet2.EachSlipTypeColId7)resList.Add("EachSlipTypeColId7");
			if(slipPrtSet1.EachSlipTypeColNm7 != slipPrtSet2.EachSlipTypeColNm7)resList.Add("EachSlipTypeColNm7");
			if(slipPrtSet1.EachSlipTypeColPrt7 != slipPrtSet2.EachSlipTypeColPrt7)resList.Add("EachSlipTypeColPrt7");
			if(slipPrtSet1.EachSlipTypeColId8 != slipPrtSet2.EachSlipTypeColId8)resList.Add("EachSlipTypeColId8");
			if(slipPrtSet1.EachSlipTypeColNm8 != slipPrtSet2.EachSlipTypeColNm8)resList.Add("EachSlipTypeColNm8");
			if(slipPrtSet1.EachSlipTypeColPrt8 != slipPrtSet2.EachSlipTypeColPrt8)resList.Add("EachSlipTypeColPrt8");
			if(slipPrtSet1.EachSlipTypeColId9 != slipPrtSet2.EachSlipTypeColId9)resList.Add("EachSlipTypeColId9");
			if(slipPrtSet1.EachSlipTypeColNm9 != slipPrtSet2.EachSlipTypeColNm9)resList.Add("EachSlipTypeColNm9");
			if(slipPrtSet1.EachSlipTypeColPrt9 != slipPrtSet2.EachSlipTypeColPrt9)resList.Add("EachSlipTypeColPrt9");
			if(slipPrtSet1.EachSlipTypeColId10 != slipPrtSet2.EachSlipTypeColId10)resList.Add("EachSlipTypeColId10");
			if(slipPrtSet1.EachSlipTypeColNm10 != slipPrtSet2.EachSlipTypeColNm10)resList.Add("EachSlipTypeColNm10");
			if(slipPrtSet1.EachSlipTypeColPrt10 != slipPrtSet2.EachSlipTypeColPrt10)resList.Add("EachSlipTypeColPrt10");
			if(slipPrtSet1.SlipFontName != slipPrtSet2.SlipFontName)resList.Add("SlipFontName");
			if(slipPrtSet1.SlipFontSize != slipPrtSet2.SlipFontSize)resList.Add("SlipFontSize");
			if(slipPrtSet1.SlipFontStyle != slipPrtSet2.SlipFontStyle)resList.Add("SlipFontStyle");
			if(slipPrtSet1.SlipBaseColorRed1 != slipPrtSet2.SlipBaseColorRed1)resList.Add("SlipBaseColorRed1");
			if(slipPrtSet1.SlipBaseColorGrn1 != slipPrtSet2.SlipBaseColorGrn1)resList.Add("SlipBaseColorGrn1");
			if(slipPrtSet1.SlipBaseColorBlu1 != slipPrtSet2.SlipBaseColorBlu1)resList.Add("SlipBaseColorBlu1");
			if(slipPrtSet1.SlipBaseColorRed2 != slipPrtSet2.SlipBaseColorRed2)resList.Add("SlipBaseColorRed2");
			if(slipPrtSet1.SlipBaseColorGrn2 != slipPrtSet2.SlipBaseColorGrn2)resList.Add("SlipBaseColorGrn2");
			if(slipPrtSet1.SlipBaseColorBlu2 != slipPrtSet2.SlipBaseColorBlu2)resList.Add("SlipBaseColorBlu2");
			if(slipPrtSet1.SlipBaseColorRed3 != slipPrtSet2.SlipBaseColorRed3)resList.Add("SlipBaseColorRed3");
			if(slipPrtSet1.SlipBaseColorGrn3 != slipPrtSet2.SlipBaseColorGrn3)resList.Add("SlipBaseColorGrn3");
			if(slipPrtSet1.SlipBaseColorBlu3 != slipPrtSet2.SlipBaseColorBlu3)resList.Add("SlipBaseColorBlu3");
			if(slipPrtSet1.SlipBaseColorRed4 != slipPrtSet2.SlipBaseColorRed4)resList.Add("SlipBaseColorRed4");
			if(slipPrtSet1.SlipBaseColorGrn4 != slipPrtSet2.SlipBaseColorGrn4)resList.Add("SlipBaseColorGrn4");
			if(slipPrtSet1.SlipBaseColorBlu4 != slipPrtSet2.SlipBaseColorBlu4)resList.Add("SlipBaseColorBlu4");
			if(slipPrtSet1.SlipBaseColorRed5 != slipPrtSet2.SlipBaseColorRed5)resList.Add("SlipBaseColorRed5");
			if(slipPrtSet1.SlipBaseColorGrn5 != slipPrtSet2.SlipBaseColorGrn5)resList.Add("SlipBaseColorGrn5");
			if(slipPrtSet1.SlipBaseColorBlu5 != slipPrtSet2.SlipBaseColorBlu5)resList.Add("SlipBaseColorBlu5");
			if(slipPrtSet1.CopyCount != slipPrtSet2.CopyCount)resList.Add("CopyCount");
			if(slipPrtSet1.TitleName1 != slipPrtSet2.TitleName1)resList.Add("TitleName1");
			if(slipPrtSet1.TitleName2 != slipPrtSet2.TitleName2)resList.Add("TitleName2");
			if(slipPrtSet1.TitleName3 != slipPrtSet2.TitleName3)resList.Add("TitleName3");
			if(slipPrtSet1.TitleName4 != slipPrtSet2.TitleName4)resList.Add("TitleName4");
			if(slipPrtSet1.SpecialPurpose1 != slipPrtSet2.SpecialPurpose1)resList.Add("SpecialPurpose1");
			if(slipPrtSet1.SpecialPurpose2 != slipPrtSet2.SpecialPurpose2)resList.Add("SpecialPurpose2");
			if(slipPrtSet1.SpecialPurpose3 != slipPrtSet2.SpecialPurpose3)resList.Add("SpecialPurpose3");
			if(slipPrtSet1.SpecialPurpose4 != slipPrtSet2.SpecialPurpose4)resList.Add("SpecialPurpose4");
			if(slipPrtSet1.TitleName102 != slipPrtSet2.TitleName102)resList.Add("TitleName102");
			if(slipPrtSet1.TitleName103 != slipPrtSet2.TitleName103)resList.Add("TitleName103");
			if(slipPrtSet1.TitleName104 != slipPrtSet2.TitleName104)resList.Add("TitleName104");
			if(slipPrtSet1.TitleName105 != slipPrtSet2.TitleName105)resList.Add("TitleName105");
			if(slipPrtSet1.TitleName202 != slipPrtSet2.TitleName202)resList.Add("TitleName202");
			if(slipPrtSet1.TitleName203 != slipPrtSet2.TitleName203)resList.Add("TitleName203");
			if(slipPrtSet1.TitleName204 != slipPrtSet2.TitleName204)resList.Add("TitleName204");
			if(slipPrtSet1.TitleName205 != slipPrtSet2.TitleName205)resList.Add("TitleName205");
			if(slipPrtSet1.TitleName302 != slipPrtSet2.TitleName302)resList.Add("TitleName302");
			if(slipPrtSet1.TitleName303 != slipPrtSet2.TitleName303)resList.Add("TitleName303");
			if(slipPrtSet1.TitleName304 != slipPrtSet2.TitleName304)resList.Add("TitleName304");
			if(slipPrtSet1.TitleName305 != slipPrtSet2.TitleName305)resList.Add("TitleName305");
			if(slipPrtSet1.TitleName402 != slipPrtSet2.TitleName402)resList.Add("TitleName402");
			if(slipPrtSet1.TitleName403 != slipPrtSet2.TitleName403)resList.Add("TitleName403");
			if(slipPrtSet1.TitleName404 != slipPrtSet2.TitleName404)resList.Add("TitleName404");
			if(slipPrtSet1.TitleName405 != slipPrtSet2.TitleName405)resList.Add("TitleName405");
			if(slipPrtSet1.Note1 != slipPrtSet2.Note1)resList.Add("Note1");
			if(slipPrtSet1.Note2 != slipPrtSet2.Note2)resList.Add("Note2");
			if(slipPrtSet1.Note3 != slipPrtSet2.Note3)resList.Add("Note3");
			if(slipPrtSet1.QRCodePrintDivCd != slipPrtSet2.QRCodePrintDivCd)resList.Add("QRCodePrintDivCd");
			if(slipPrtSet1.TimePrintDivCd != slipPrtSet2.TimePrintDivCd)resList.Add("TimePrintDivCd");
			if(slipPrtSet1.ReissueMark != slipPrtSet2.ReissueMark)resList.Add("ReissueMark");
			if(slipPrtSet1.RefConsTaxDivCd != slipPrtSet2.RefConsTaxDivCd)resList.Add("RefConsTaxDivCd");
			if(slipPrtSet1.RefConsTaxPrtNm != slipPrtSet2.RefConsTaxPrtNm)resList.Add("RefConsTaxPrtNm");
			if(slipPrtSet1.DetailRowCount != slipPrtSet2.DetailRowCount)resList.Add("DetailRowCount");
			if(slipPrtSet1.HonorificTitle != slipPrtSet2.HonorificTitle)resList.Add("HonorificTitle");
            // --- ADD 2009/12/31 ---------->>>>>
            if (slipPrtSet1.SlipNoteCharCnt != slipPrtSet2.SlipNoteCharCnt) resList.Add("SlipNoteCharCnt");
            if (slipPrtSet1.SlipNote2CharCnt != slipPrtSet2.SlipNote2CharCnt) resList.Add("SlipNote2CharCnt");
            if (slipPrtSet1.SlipNote3CharCnt != slipPrtSet2.SlipNote3CharCnt) resList.Add("SlipNote3CharCnt");
            // --- ADD 2009/12/31 ----------<<<<<
            if (slipPrtSet1.ConsTaxPrtCd != slipPrtSet2.ConsTaxPrtCd) resList.Add("ConsTaxPrtCd");
            if (slipPrtSet1.EnterpriseName != slipPrtSet2.EnterpriseName) resList.Add("EnterpriseName");
			if(slipPrtSet1.UpdEmployeeName != slipPrtSet2.UpdEmployeeName)resList.Add("UpdEmployeeName");
			if(slipPrtSet1.DataInputSystemName != slipPrtSet2.DataInputSystemName)resList.Add("DataInputSystemName");

            // --- ADD 2010/08/06 ---------->>>>>
            if (slipPrtSet1.CustomerCode != slipPrtSet2.CustomerCode) resList.Add("CustomerCode");
            if (slipPrtSet1.UpdateFlag != slipPrtSet2.UpdateFlag) resList.Add("UpdateFlag");
            // --- ADD 2010/08/06 ----------<<<<<

            if (slipPrtSet1.EntNmPrtExpDiv != slipPrtSet2.EntNmPrtExpDiv) resList.Add("EntNmPrtExpDiv"); // ADD 2011/02/16
            // --- ADD 2011/07/19 ---------->>>>>
            if (slipPrtSet1.SCMAnsMarkPrtDiv != slipPrtSet2.SCMAnsMarkPrtDiv) resList.Add("SCMAnsMarkPrtDiv");
            if (slipPrtSet1.NormalPrtMark != slipPrtSet2.NormalPrtMark) resList.Add("NormalPrtMark");
            if (slipPrtSet1.SCMManualAnsMark != slipPrtSet2.SCMManualAnsMark) resList.Add("SCMManualAnsMark");
            if (slipPrtSet1.SCMAutoAnsMark != slipPrtSet2.SCMAutoAnsMark) resList.Add("SCMAutoAnsMark");
            // --- ADD 2011/07/19 ----------<<<<<

            return resList;
		}
	}
}
