using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   FPprSchmGr
	/// <summary>
	///                      自由帳票スキーマグループマスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票スキーマグループマスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/12/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   橋本　裕毅  2007/08/22</br>
	/// <br>                 :   DM使用区分を追加</br>
	/// </remarks>
	public class FPprSchmGr
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

		/// <summary>自由帳票スキーマグループコード</summary>
		private Int32 _freePrtPprSchmGrpCd;

		/// <summary>出力ファイル名</summary>
		/// <remarks>フォームファイルID or フォーマットファイルID</remarks>
		private string _outputFormFileName = "";

		/// <summary>出力ファイルクラスID</summary>
		private string _outputFileClassId = "";

		/// <summary>自由帳票項目グループコード</summary>
		private Int32 _freePrtPprItemGrpCd;

		/// <summary>出力名称</summary>
		/// <remarks>ガイド等に表示する名称</remarks>
		private string _displayName = "";

		/// <summary>データ入力システム</summary>
		/// <remarks>0:共通,1:整備,2:鈑金,3:車販</remarks>
		private Int32 _dataInputSystem;

		/// <summary>帳票区分コード</summary>
		/// <remarks>1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票</remarks>
		private Int32 _printPaperDivCd;

		/// <summary>帳票使用区分</summary>
		/// <remarks>1:帳票,2:伝票,3:DM一覧表,4:DMはがき</remarks>
		private Int32 _printPaperUseDivcd;

		/// <summary>特殊コンバート使用区分</summary>
		/// <remarks>0:無,1:特種マクロコンバート有,2:フォントのみ</remarks>
		private Int32 _specialConvtUseDivCd;

		/// <summary>オプションコード</summary>
		/// <remarks>ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ</remarks>
		private string _optionCode = "";

		/// <summary>改頁行数</summary>
		private Int32 _formFeedLineCount;

		/// <summary>改行文字数</summary>
		/// <remarks>※伝票で作業・部品名称の改行文字数</remarks>
		private Int32 _crCharCnt;

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

		/// <summary>自由帳票項目グループ名称</summary>
		private string _freePrtPprItemGrpNm = "";

		/// <summary>データ入力システム名称</summary>
		/// <remarks>共通,整備,鈑金,車販</remarks>
		private string _dataInputSystemName = "";


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

		/// public propaty name  :  FreePrtPprSchmGrpCd
		/// <summary>自由帳票スキーマグループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票スキーマグループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPprSchmGrpCd
		{
			get{return _freePrtPprSchmGrpCd;}
			set{_freePrtPprSchmGrpCd = value;}
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

		/// public propaty name  :  OutputFileClassId
		/// <summary>出力ファイルクラスIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力ファイルクラスIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string OutputFileClassId
		{
			get{return _outputFileClassId;}
			set{_outputFileClassId = value;}
		}

		/// public propaty name  :  FreePrtPprItemGrpCd
		/// <summary>自由帳票項目グループコードプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票項目グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPprItemGrpCd
		{
			get{return _freePrtPprItemGrpCd;}
			set{_freePrtPprItemGrpCd = value;}
		}

		/// public propaty name  :  DisplayName
		/// <summary>出力名称プロパティ</summary>
		/// <value>ガイド等に表示する名称</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   出力名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DisplayName
		{
			get{return _displayName;}
			set{_displayName = value;}
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

		/// public propaty name  :  PrintPaperDivCd
		/// <summary>帳票区分コードプロパティ</summary>
		/// <value>1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票区分コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintPaperDivCd
		{
			get{return _printPaperDivCd;}
			set{_printPaperDivCd = value;}
		}

		/// public propaty name  :  PrintPaperUseDivcd
		/// <summary>帳票使用区分プロパティ</summary>
		/// <value>1:帳票,2:伝票,3:DM一覧表,4:DMはがき</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintPaperUseDivcd
		{
			get{return _printPaperUseDivcd;}
			set{_printPaperUseDivcd = value;}
		}

		/// public propaty name  :  SpecialConvtUseDivCd
		/// <summary>特殊コンバート使用区分プロパティ</summary>
		/// <value>0:無,1:特種マクロコンバート有,2:フォントのみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   特殊コンバート使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SpecialConvtUseDivCd
		{
			get{return _specialConvtUseDivCd;}
			set{_specialConvtUseDivCd = value;}
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

		/// public propaty name  :  FormFeedLineCount
		/// <summary>改頁行数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改頁行数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FormFeedLineCount
		{
			get{return _formFeedLineCount;}
			set{_formFeedLineCount = value;}
		}

		/// public propaty name  :  CrCharCnt
		/// <summary>改行文字数プロパティ</summary>
		/// <value>※伝票で作業・部品名称の改行文字数</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改行文字数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CrCharCnt
		{
			get{return _crCharCnt;}
			set{_crCharCnt = value;}
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

		/// public propaty name  :  FreePrtPprItemGrpNm
		/// <summary>自由帳票項目グループ名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票項目グループ名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FreePrtPprItemGrpNm
		{
			get{return _freePrtPprItemGrpNm;}
			set{_freePrtPprItemGrpNm = value;}
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


		/// <summary>
		/// 自由帳票スキーマグループマスタコンストラクタ
		/// </summary>
		/// <returns>FPprSchmGrクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmGrクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FPprSchmGr()
		{
		}

		/// <summary>
		/// 自由帳票スキーマグループマスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
		/// <param name="outputFormFileName">出力ファイル名(フォームファイルID or フォーマットファイルID)</param>
		/// <param name="outputFileClassId">出力ファイルクラスID</param>
		/// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
		/// <param name="displayName">出力名称(ガイド等に表示する名称)</param>
		/// <param name="dataInputSystem">データ入力システム(0:共通,1:整備,2:鈑金,3:車販)</param>
		/// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
		/// <param name="printPaperUseDivcd">帳票使用区分(1:帳票,2:伝票,3:DM一覧表,4:DMはがき)</param>
		/// <param name="specialConvtUseDivCd">特殊コンバート使用区分(0:無,1:特種マクロコンバート有,2:フォントのみ)</param>
		/// <param name="optionCode">オプションコード(ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ)</param>
		/// <param name="formFeedLineCount">改頁行数</param>
		/// <param name="crCharCnt">改行文字数(※伝票で作業・部品名称の改行文字数)</param>
		/// <param name="topMargin">上余白(cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8))</param>
		/// <param name="leftMargin">左余白(cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8))</param>
		/// <param name="rightMargin">右余白</param>
		/// <param name="bottomMargin">下余白</param>
		/// <param name="freePrtPprItemGrpNm">自由帳票項目グループ名称</param>
		/// <param name="dataInputSystemName">データ入力システム名称(共通,整備,鈑金,車販)</param>
		/// <returns>FPprSchmGrクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmGrクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FPprSchmGr(DateTime createDateTime,DateTime updateDateTime,Int32 logicalDeleteCode,Int32 freePrtPprSchmGrpCd,string outputFormFileName,string outputFileClassId,Int32 freePrtPprItemGrpCd,string displayName,Int32 dataInputSystem,Int32 printPaperDivCd,Int32 printPaperUseDivcd,Int32 specialConvtUseDivCd,string optionCode,Int32 formFeedLineCount,Int32 crCharCnt,Double topMargin,Double leftMargin,Double rightMargin,Double bottomMargin,string freePrtPprItemGrpNm,string dataInputSystemName)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._freePrtPprSchmGrpCd = freePrtPprSchmGrpCd;
			this._outputFormFileName = outputFormFileName;
			this._outputFileClassId = outputFileClassId;
			this._freePrtPprItemGrpCd = freePrtPprItemGrpCd;
			this._displayName = displayName;
			this._dataInputSystem = dataInputSystem;
			this._printPaperDivCd = printPaperDivCd;
			this._printPaperUseDivcd = printPaperUseDivcd;
			this._specialConvtUseDivCd = specialConvtUseDivCd;
			this._optionCode = optionCode;
			this._formFeedLineCount = formFeedLineCount;
			this._crCharCnt = crCharCnt;
			this._topMargin = topMargin;
			this._leftMargin = leftMargin;
			this._rightMargin = rightMargin;
			this._bottomMargin = bottomMargin;
			this._freePrtPprItemGrpNm = freePrtPprItemGrpNm;
			this._dataInputSystemName = dataInputSystemName;

		}

		/// <summary>
		/// 自由帳票スキーマグループマスタ複製処理
		/// </summary>
		/// <returns>FPprSchmGrクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいFPprSchmGrクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FPprSchmGr Clone()
		{
			return new FPprSchmGr(this._createDateTime,this._updateDateTime,this._logicalDeleteCode,this._freePrtPprSchmGrpCd,this._outputFormFileName,this._outputFileClassId,this._freePrtPprItemGrpCd,this._displayName,this._dataInputSystem,this._printPaperDivCd,this._printPaperUseDivcd,this._specialConvtUseDivCd,this._optionCode,this._formFeedLineCount,this._crCharCnt,this._topMargin,this._leftMargin,this._rightMargin,this._bottomMargin,this._freePrtPprItemGrpNm,this._dataInputSystemName);
		}

		/// <summary>
		/// 自由帳票スキーマグループマスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のFPprSchmGrクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmGrクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(FPprSchmGr target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.FreePrtPprSchmGrpCd == target.FreePrtPprSchmGrpCd)
				 && (this.OutputFormFileName == target.OutputFormFileName)
				 && (this.OutputFileClassId == target.OutputFileClassId)
				 && (this.FreePrtPprItemGrpCd == target.FreePrtPprItemGrpCd)
				 && (this.DisplayName == target.DisplayName)
				 && (this.DataInputSystem == target.DataInputSystem)
				 && (this.PrintPaperDivCd == target.PrintPaperDivCd)
				 && (this.PrintPaperUseDivcd == target.PrintPaperUseDivcd)
				 && (this.SpecialConvtUseDivCd == target.SpecialConvtUseDivCd)
				 && (this.OptionCode == target.OptionCode)
				 && (this.FormFeedLineCount == target.FormFeedLineCount)
				 && (this.CrCharCnt == target.CrCharCnt)
				 && (this.TopMargin == target.TopMargin)
				 && (this.LeftMargin == target.LeftMargin)
				 && (this.RightMargin == target.RightMargin)
				 && (this.BottomMargin == target.BottomMargin)
				 && (this.FreePrtPprItemGrpNm == target.FreePrtPprItemGrpNm)
				 && (this.DataInputSystemName == target.DataInputSystemName));
		}

		/// <summary>
		/// 自由帳票スキーマグループマスタ比較処理
		/// </summary>
		/// <param name="fPprSchmGr1">
		///                    比較するFPprSchmGrクラスのインスタンス
		/// </param>
		/// <param name="fPprSchmGr2">比較するFPprSchmGrクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmGrクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(FPprSchmGr fPprSchmGr1, FPprSchmGr fPprSchmGr2)
		{
			return ((fPprSchmGr1.CreateDateTime == fPprSchmGr2.CreateDateTime)
				 && (fPprSchmGr1.UpdateDateTime == fPprSchmGr2.UpdateDateTime)
				 && (fPprSchmGr1.LogicalDeleteCode == fPprSchmGr2.LogicalDeleteCode)
				 && (fPprSchmGr1.FreePrtPprSchmGrpCd == fPprSchmGr2.FreePrtPprSchmGrpCd)
				 && (fPprSchmGr1.OutputFormFileName == fPprSchmGr2.OutputFormFileName)
				 && (fPprSchmGr1.OutputFileClassId == fPprSchmGr2.OutputFileClassId)
				 && (fPprSchmGr1.FreePrtPprItemGrpCd == fPprSchmGr2.FreePrtPprItemGrpCd)
				 && (fPprSchmGr1.DisplayName == fPprSchmGr2.DisplayName)
				 && (fPprSchmGr1.DataInputSystem == fPprSchmGr2.DataInputSystem)
				 && (fPprSchmGr1.PrintPaperDivCd == fPprSchmGr2.PrintPaperDivCd)
				 && (fPprSchmGr1.PrintPaperUseDivcd == fPprSchmGr2.PrintPaperUseDivcd)
				 && (fPprSchmGr1.SpecialConvtUseDivCd == fPprSchmGr2.SpecialConvtUseDivCd)
				 && (fPprSchmGr1.OptionCode == fPprSchmGr2.OptionCode)
				 && (fPprSchmGr1.FormFeedLineCount == fPprSchmGr2.FormFeedLineCount)
				 && (fPprSchmGr1.CrCharCnt == fPprSchmGr2.CrCharCnt)
				 && (fPprSchmGr1.TopMargin == fPprSchmGr2.TopMargin)
				 && (fPprSchmGr1.LeftMargin == fPprSchmGr2.LeftMargin)
				 && (fPprSchmGr1.RightMargin == fPprSchmGr2.RightMargin)
				 && (fPprSchmGr1.BottomMargin == fPprSchmGr2.BottomMargin)
				 && (fPprSchmGr1.FreePrtPprItemGrpNm == fPprSchmGr2.FreePrtPprItemGrpNm)
				 && (fPprSchmGr1.DataInputSystemName == fPprSchmGr2.DataInputSystemName));
		}
		/// <summary>
		/// 自由帳票スキーマグループマスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のFPprSchmGrクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmGrクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(FPprSchmGr target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.FreePrtPprSchmGrpCd != target.FreePrtPprSchmGrpCd)resList.Add("FreePrtPprSchmGrpCd");
			if(this.OutputFormFileName != target.OutputFormFileName)resList.Add("OutputFormFileName");
			if(this.OutputFileClassId != target.OutputFileClassId)resList.Add("OutputFileClassId");
			if(this.FreePrtPprItemGrpCd != target.FreePrtPprItemGrpCd)resList.Add("FreePrtPprItemGrpCd");
			if(this.DisplayName != target.DisplayName)resList.Add("DisplayName");
			if(this.DataInputSystem != target.DataInputSystem)resList.Add("DataInputSystem");
			if(this.PrintPaperDivCd != target.PrintPaperDivCd)resList.Add("PrintPaperDivCd");
			if(this.PrintPaperUseDivcd != target.PrintPaperUseDivcd)resList.Add("PrintPaperUseDivcd");
			if(this.SpecialConvtUseDivCd != target.SpecialConvtUseDivCd)resList.Add("SpecialConvtUseDivCd");
			if(this.OptionCode != target.OptionCode)resList.Add("OptionCode");
			if(this.FormFeedLineCount != target.FormFeedLineCount)resList.Add("FormFeedLineCount");
			if(this.CrCharCnt != target.CrCharCnt)resList.Add("CrCharCnt");
			if(this.TopMargin != target.TopMargin)resList.Add("TopMargin");
			if(this.LeftMargin != target.LeftMargin)resList.Add("LeftMargin");
			if(this.RightMargin != target.RightMargin)resList.Add("RightMargin");
			if(this.BottomMargin != target.BottomMargin)resList.Add("BottomMargin");
			if(this.FreePrtPprItemGrpNm != target.FreePrtPprItemGrpNm)resList.Add("FreePrtPprItemGrpNm");
			if(this.DataInputSystemName != target.DataInputSystemName)resList.Add("DataInputSystemName");

			return resList;
		}

		/// <summary>
		/// 自由帳票スキーマグループマスタ比較処理
		/// </summary>
		/// <param name="fPprSchmGr1">比較するFPprSchmGrクラスのインスタンス</param>
		/// <param name="fPprSchmGr2">比較するFPprSchmGrクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FPprSchmGrクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(FPprSchmGr fPprSchmGr1, FPprSchmGr fPprSchmGr2)
		{
			ArrayList resList = new ArrayList();
			if(fPprSchmGr1.CreateDateTime != fPprSchmGr2.CreateDateTime)resList.Add("CreateDateTime");
			if(fPprSchmGr1.UpdateDateTime != fPprSchmGr2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(fPprSchmGr1.LogicalDeleteCode != fPprSchmGr2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(fPprSchmGr1.FreePrtPprSchmGrpCd != fPprSchmGr2.FreePrtPprSchmGrpCd)resList.Add("FreePrtPprSchmGrpCd");
			if(fPprSchmGr1.OutputFormFileName != fPprSchmGr2.OutputFormFileName)resList.Add("OutputFormFileName");
			if(fPprSchmGr1.OutputFileClassId != fPprSchmGr2.OutputFileClassId)resList.Add("OutputFileClassId");
			if(fPprSchmGr1.FreePrtPprItemGrpCd != fPprSchmGr2.FreePrtPprItemGrpCd)resList.Add("FreePrtPprItemGrpCd");
			if(fPprSchmGr1.DisplayName != fPprSchmGr2.DisplayName)resList.Add("DisplayName");
			if(fPprSchmGr1.DataInputSystem != fPprSchmGr2.DataInputSystem)resList.Add("DataInputSystem");
			if(fPprSchmGr1.PrintPaperDivCd != fPprSchmGr2.PrintPaperDivCd)resList.Add("PrintPaperDivCd");
			if(fPprSchmGr1.PrintPaperUseDivcd != fPprSchmGr2.PrintPaperUseDivcd)resList.Add("PrintPaperUseDivcd");
			if(fPprSchmGr1.SpecialConvtUseDivCd != fPprSchmGr2.SpecialConvtUseDivCd)resList.Add("SpecialConvtUseDivCd");
			if(fPprSchmGr1.OptionCode != fPprSchmGr2.OptionCode)resList.Add("OptionCode");
			if(fPprSchmGr1.FormFeedLineCount != fPprSchmGr2.FormFeedLineCount)resList.Add("FormFeedLineCount");
			if(fPprSchmGr1.CrCharCnt != fPprSchmGr2.CrCharCnt)resList.Add("CrCharCnt");
			if(fPprSchmGr1.TopMargin != fPprSchmGr2.TopMargin)resList.Add("TopMargin");
			if(fPprSchmGr1.LeftMargin != fPprSchmGr2.LeftMargin)resList.Add("LeftMargin");
			if(fPprSchmGr1.RightMargin != fPprSchmGr2.RightMargin)resList.Add("RightMargin");
			if(fPprSchmGr1.BottomMargin != fPprSchmGr2.BottomMargin)resList.Add("BottomMargin");
			if(fPprSchmGr1.FreePrtPprItemGrpNm != fPprSchmGr2.FreePrtPprItemGrpNm)resList.Add("FreePrtPprItemGrpNm");
			if(fPprSchmGr1.DataInputSystemName != fPprSchmGr2.DataInputSystemName)resList.Add("DataInputSystemName");

			return resList;
		}
	}
}
