using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	/// public class name:   FrePrtGuideSearchRet
	/// <summary>
	///                      自由帳票ガイド検索結果クラス
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票ガイド検索結果クラスヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/5/24</br>
	/// <br>Genarated Date   :   2007/12/26  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class FrePrtGuideSearchRet
	{
		/// <summary>更新日時</summary>
		/// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
		private DateTime _updateDateTime;

		/// <summary>出力ファイル名</summary>
		/// <remarks>フォームファイルID or フォーマットファイルID</remarks>
		private string _outputFormFileName = "";

		/// <summary>ユーザー帳票ID枝番号</summary>
		private Int32 _userPrtPprIdDerivNo;

		/// <summary>自由帳票スキーマグループコード</summary>
		private Int32 _freePrtPprSchmGrpCd;

		/// <summary>自由帳票項目グループコード</summary>
		private Int32 _freePrtPprItemGrpCd;

		/// <summary>出力名称</summary>
		/// <remarks>ガイド等に表示する名称</remarks>
		private string _displayName = "";

		/// <summary>帳票ユーザー枝番コメント</summary>
		private string _prtPprUserDerivNoCmt = "";

		/// <summary>出力ファイルクラスID</summary>
		private string _outputFileClassId = "";

		/// <summary>データ入力システム</summary>
		/// <remarks>0:共通,1:整備,2:鈑金,3:車販</remarks>
		private Int32 _dataInputSystem;

		/// <summary>帳票使用区分</summary>
		/// <remarks>1:帳票,2:伝票,3:DM一覧表,4:DMはがき</remarks>
		private Int32 _printPaperUseDivcd;

		/// <summary>特殊コンバート使用区分</summary>
		/// <remarks>0:無,1:マクロ</remarks>
		private Int32 _specialConvtUseDivCd;

		/// <summary>オプションコード</summary>
		/// <remarks>ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ</remarks>
		private string _optionCode = "";

		/// <summary>改頁行数</summary>
		private Int32 _formFeedLineCount;

		/// <summary>改行文字数</summary>
		/// <remarks>※伝票で作業・部品名称の改行文字数</remarks>
		private Int32 _crCharCnt;

		/// <summary>プログラムID</summary>
		private string _pgId = "";

		/// <summary>DMナンバー</summary>
		private Int32 _dmNo;

		/// <summary>プログラム通し番号</summary>
		/// <remarks>ﾌﾟﾛｸﾞﾗﾑID毎に1から採番(0は最終選択帳票)</remarks>
		private Int32 _pgSequenceNo;

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

		/// public propaty name  :  UserPrtPprIdDerivNo
		/// <summary>ユーザー帳票ID枝番号プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ユーザー帳票ID枝番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 UserPrtPprIdDerivNo
		{
			get{return _userPrtPprIdDerivNo;}
			set{_userPrtPprIdDerivNo = value;}
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

		/// public propaty name  :  PrtPprUserDerivNoCmt
		/// <summary>帳票ユーザー枝番コメントプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票ユーザー枝番コメントプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PrtPprUserDerivNoCmt
		{
			get{return _prtPprUserDerivNoCmt;}
			set{_prtPprUserDerivNoCmt = value;}
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
		/// <value>0:無,1:マクロ</value>
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

		/// public propaty name  :  PgId
		/// <summary>プログラムIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   プログラムIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string PgId
		{
			get{return _pgId;}
			set{_pgId = value;}
		}

		/// public propaty name  :  DmNo
		/// <summary>DMナンバープロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DMナンバープロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DmNo
		{
			get{return _dmNo;}
			set{_dmNo = value;}
		}

		/// public propaty name  :  PgSequenceNo
		/// <summary>プログラム通し番号プロパティ</summary>
		/// <value>ﾌﾟﾛｸﾞﾗﾑID毎に1から採番(0は最終選択帳票)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   プログラム通し番号プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PgSequenceNo
		{
			get{return _pgSequenceNo;}
			set{_pgSequenceNo = value;}
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
		/// 自由帳票ガイド検索結果クラスコンストラクタ
		/// </summary>
		/// <returns>FrePrtGuideSearchRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtGuideSearchRetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePrtGuideSearchRet()
		{
		}

		/// <summary>
		/// 自由帳票ガイド検索結果クラスコンストラクタ
		/// </summary>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="outputFormFileName">出力ファイル名(フォームファイルID or フォーマットファイルID)</param>
		/// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
		/// <param name="freePrtPprSchmGrpCd">自由帳票スキーマグループコード</param>
		/// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
		/// <param name="displayName">出力名称(ガイド等に表示する名称)</param>
		/// <param name="prtPprUserDerivNoCmt">帳票ユーザー枝番コメント</param>
		/// <param name="outputFileClassId">出力ファイルクラスID</param>
		/// <param name="dataInputSystem">データ入力システム(0:共通,1:整備,2:鈑金,3:車販)</param>
		/// <param name="printPaperUseDivcd">帳票使用区分(1:帳票,2:伝票,3:DM一覧表,4:DMはがき)</param>
		/// <param name="specialConvtUseDivCd">特殊コンバート使用区分(0:無,1:マクロ)</param>
		/// <param name="optionCode">オプションコード(ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ)</param>
		/// <param name="formFeedLineCount">改頁行数</param>
		/// <param name="crCharCnt">改行文字数(※伝票で作業・部品名称の改行文字数)</param>
		/// <param name="pgId">プログラムID</param>
		/// <param name="dmNo">DMナンバー</param>
		/// <param name="pgSequenceNo">プログラム通し番号(ﾌﾟﾛｸﾞﾗﾑID毎に1から採番(0は最終選択帳票))</param>
		/// <param name="topMargin">上余白(cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8))</param>
		/// <param name="leftMargin">左余白(cmで指定。マイナス入力不可。有効桁数は小数点第１位まで（例0.8))</param>
		/// <param name="rightMargin">右余白</param>
		/// <param name="bottomMargin">下余白</param>
		/// <param name="freePrtPprItemGrpNm">自由帳票項目グループ名称</param>
		/// <param name="dataInputSystemName">データ入力システム名称(共通,整備,鈑金,車販)</param>
		/// <returns>FrePrtGuideSearchRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtGuideSearchRetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePrtGuideSearchRet(DateTime updateDateTime,string outputFormFileName,Int32 userPrtPprIdDerivNo,Int32 freePrtPprSchmGrpCd,Int32 freePrtPprItemGrpCd,string displayName,string prtPprUserDerivNoCmt,string outputFileClassId,Int32 dataInputSystem,Int32 printPaperUseDivcd,Int32 specialConvtUseDivCd,string optionCode,Int32 formFeedLineCount,Int32 crCharCnt,string pgId,Int32 dmNo,Int32 pgSequenceNo,Double topMargin,Double leftMargin,Double rightMargin,Double bottomMargin,string freePrtPprItemGrpNm,string dataInputSystemName)
		{
			this.UpdateDateTime = updateDateTime;
			this._outputFormFileName = outputFormFileName;
			this._userPrtPprIdDerivNo = userPrtPprIdDerivNo;
			this._freePrtPprSchmGrpCd = freePrtPprSchmGrpCd;
			this._freePrtPprItemGrpCd = freePrtPprItemGrpCd;
			this._displayName = displayName;
			this._prtPprUserDerivNoCmt = prtPprUserDerivNoCmt;
			this._outputFileClassId = outputFileClassId;
			this._dataInputSystem = dataInputSystem;
			this._printPaperUseDivcd = printPaperUseDivcd;
			this._specialConvtUseDivCd = specialConvtUseDivCd;
			this._optionCode = optionCode;
			this._formFeedLineCount = formFeedLineCount;
			this._crCharCnt = crCharCnt;
			this._pgId = pgId;
			this._dmNo = dmNo;
			this._pgSequenceNo = pgSequenceNo;
			this._topMargin = topMargin;
			this._leftMargin = leftMargin;
			this._rightMargin = rightMargin;
			this._bottomMargin = bottomMargin;
			this._freePrtPprItemGrpNm = freePrtPprItemGrpNm;
			this._dataInputSystemName = dataInputSystemName;

		}

		/// <summary>
		/// 自由帳票ガイド検索結果クラス複製処理
		/// </summary>
		/// <returns>FrePrtGuideSearchRetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいFrePrtGuideSearchRetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePrtGuideSearchRet Clone()
		{
			return new FrePrtGuideSearchRet(this._updateDateTime,this._outputFormFileName,this._userPrtPprIdDerivNo,this._freePrtPprSchmGrpCd,this._freePrtPprItemGrpCd,this._displayName,this._prtPprUserDerivNoCmt,this._outputFileClassId,this._dataInputSystem,this._printPaperUseDivcd,this._specialConvtUseDivCd,this._optionCode,this._formFeedLineCount,this._crCharCnt,this._pgId,this._dmNo,this._pgSequenceNo,this._topMargin,this._leftMargin,this._rightMargin,this._bottomMargin,this._freePrtPprItemGrpNm,this._dataInputSystemName);
		}

		/// <summary>
		/// 自由帳票ガイド検索結果クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のFrePrtGuideSearchRetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtGuideSearchRetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(FrePrtGuideSearchRet target)
		{
			return ((this.UpdateDateTime == target.UpdateDateTime)
				 && (this.OutputFormFileName == target.OutputFormFileName)
				 && (this.UserPrtPprIdDerivNo == target.UserPrtPprIdDerivNo)
				 && (this.FreePrtPprSchmGrpCd == target.FreePrtPprSchmGrpCd)
				 && (this.FreePrtPprItemGrpCd == target.FreePrtPprItemGrpCd)
				 && (this.DisplayName == target.DisplayName)
				 && (this.PrtPprUserDerivNoCmt == target.PrtPprUserDerivNoCmt)
				 && (this.OutputFileClassId == target.OutputFileClassId)
				 && (this.DataInputSystem == target.DataInputSystem)
				 && (this.PrintPaperUseDivcd == target.PrintPaperUseDivcd)
				 && (this.SpecialConvtUseDivCd == target.SpecialConvtUseDivCd)
				 && (this.OptionCode == target.OptionCode)
				 && (this.FormFeedLineCount == target.FormFeedLineCount)
				 && (this.CrCharCnt == target.CrCharCnt)
				 && (this.PgId == target.PgId)
				 && (this.DmNo == target.DmNo)
				 && (this.PgSequenceNo == target.PgSequenceNo)
				 && (this.TopMargin == target.TopMargin)
				 && (this.LeftMargin == target.LeftMargin)
				 && (this.RightMargin == target.RightMargin)
				 && (this.BottomMargin == target.BottomMargin)
				 && (this.FreePrtPprItemGrpNm == target.FreePrtPprItemGrpNm)
				 && (this.DataInputSystemName == target.DataInputSystemName));
		}

		/// <summary>
		/// 自由帳票ガイド検索結果クラス比較処理
		/// </summary>
		/// <param name="frePrtGuideSearchRet1">
		///                    比較するFrePrtGuideSearchRetクラスのインスタンス
		/// </param>
		/// <param name="frePrtGuideSearchRet2">比較するFrePrtGuideSearchRetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtGuideSearchRetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(FrePrtGuideSearchRet frePrtGuideSearchRet1, FrePrtGuideSearchRet frePrtGuideSearchRet2)
		{
			return ((frePrtGuideSearchRet1.UpdateDateTime == frePrtGuideSearchRet2.UpdateDateTime)
				 && (frePrtGuideSearchRet1.OutputFormFileName == frePrtGuideSearchRet2.OutputFormFileName)
				 && (frePrtGuideSearchRet1.UserPrtPprIdDerivNo == frePrtGuideSearchRet2.UserPrtPprIdDerivNo)
				 && (frePrtGuideSearchRet1.FreePrtPprSchmGrpCd == frePrtGuideSearchRet2.FreePrtPprSchmGrpCd)
				 && (frePrtGuideSearchRet1.FreePrtPprItemGrpCd == frePrtGuideSearchRet2.FreePrtPprItemGrpCd)
				 && (frePrtGuideSearchRet1.DisplayName == frePrtGuideSearchRet2.DisplayName)
				 && (frePrtGuideSearchRet1.PrtPprUserDerivNoCmt == frePrtGuideSearchRet2.PrtPprUserDerivNoCmt)
				 && (frePrtGuideSearchRet1.OutputFileClassId == frePrtGuideSearchRet2.OutputFileClassId)
				 && (frePrtGuideSearchRet1.DataInputSystem == frePrtGuideSearchRet2.DataInputSystem)
				 && (frePrtGuideSearchRet1.PrintPaperUseDivcd == frePrtGuideSearchRet2.PrintPaperUseDivcd)
				 && (frePrtGuideSearchRet1.SpecialConvtUseDivCd == frePrtGuideSearchRet2.SpecialConvtUseDivCd)
				 && (frePrtGuideSearchRet1.OptionCode == frePrtGuideSearchRet2.OptionCode)
				 && (frePrtGuideSearchRet1.FormFeedLineCount == frePrtGuideSearchRet2.FormFeedLineCount)
				 && (frePrtGuideSearchRet1.CrCharCnt == frePrtGuideSearchRet2.CrCharCnt)
				 && (frePrtGuideSearchRet1.PgId == frePrtGuideSearchRet2.PgId)
				 && (frePrtGuideSearchRet1.DmNo == frePrtGuideSearchRet2.DmNo)
				 && (frePrtGuideSearchRet1.PgSequenceNo == frePrtGuideSearchRet2.PgSequenceNo)
				 && (frePrtGuideSearchRet1.TopMargin == frePrtGuideSearchRet2.TopMargin)
				 && (frePrtGuideSearchRet1.LeftMargin == frePrtGuideSearchRet2.LeftMargin)
				 && (frePrtGuideSearchRet1.RightMargin == frePrtGuideSearchRet2.RightMargin)
				 && (frePrtGuideSearchRet1.BottomMargin == frePrtGuideSearchRet2.BottomMargin)
				 && (frePrtGuideSearchRet1.FreePrtPprItemGrpNm == frePrtGuideSearchRet2.FreePrtPprItemGrpNm)
				 && (frePrtGuideSearchRet1.DataInputSystemName == frePrtGuideSearchRet2.DataInputSystemName));
		}
		/// <summary>
		/// 自由帳票ガイド検索結果クラス比較処理
		/// </summary>
		/// <param name="target">比較対象のFrePrtGuideSearchRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtGuideSearchRetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(FrePrtGuideSearchRet target)
		{
			ArrayList resList = new ArrayList();
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.OutputFormFileName != target.OutputFormFileName)resList.Add("OutputFormFileName");
			if(this.UserPrtPprIdDerivNo != target.UserPrtPprIdDerivNo)resList.Add("UserPrtPprIdDerivNo");
			if(this.FreePrtPprSchmGrpCd != target.FreePrtPprSchmGrpCd)resList.Add("FreePrtPprSchmGrpCd");
			if(this.FreePrtPprItemGrpCd != target.FreePrtPprItemGrpCd)resList.Add("FreePrtPprItemGrpCd");
			if(this.DisplayName != target.DisplayName)resList.Add("DisplayName");
			if(this.PrtPprUserDerivNoCmt != target.PrtPprUserDerivNoCmt)resList.Add("PrtPprUserDerivNoCmt");
			if(this.OutputFileClassId != target.OutputFileClassId)resList.Add("OutputFileClassId");
			if(this.DataInputSystem != target.DataInputSystem)resList.Add("DataInputSystem");
			if(this.PrintPaperUseDivcd != target.PrintPaperUseDivcd)resList.Add("PrintPaperUseDivcd");
			if(this.SpecialConvtUseDivCd != target.SpecialConvtUseDivCd)resList.Add("SpecialConvtUseDivCd");
			if(this.OptionCode != target.OptionCode)resList.Add("OptionCode");
			if(this.FormFeedLineCount != target.FormFeedLineCount)resList.Add("FormFeedLineCount");
			if(this.CrCharCnt != target.CrCharCnt)resList.Add("CrCharCnt");
			if(this.PgId != target.PgId)resList.Add("PgId");
			if(this.DmNo != target.DmNo)resList.Add("DmNo");
			if(this.PgSequenceNo != target.PgSequenceNo)resList.Add("PgSequenceNo");
			if(this.TopMargin != target.TopMargin)resList.Add("TopMargin");
			if(this.LeftMargin != target.LeftMargin)resList.Add("LeftMargin");
			if(this.RightMargin != target.RightMargin)resList.Add("RightMargin");
			if(this.BottomMargin != target.BottomMargin)resList.Add("BottomMargin");
			if(this.FreePrtPprItemGrpNm != target.FreePrtPprItemGrpNm)resList.Add("FreePrtPprItemGrpNm");
			if(this.DataInputSystemName != target.DataInputSystemName)resList.Add("DataInputSystemName");

			return resList;
		}

		/// <summary>
		/// 自由帳票ガイド検索結果クラス比較処理
		/// </summary>
		/// <param name="frePrtGuideSearchRet1">比較するFrePrtGuideSearchRetクラスのインスタンス</param>
		/// <param name="frePrtGuideSearchRet2">比較するFrePrtGuideSearchRetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtGuideSearchRetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(FrePrtGuideSearchRet frePrtGuideSearchRet1, FrePrtGuideSearchRet frePrtGuideSearchRet2)
		{
			ArrayList resList = new ArrayList();
			if(frePrtGuideSearchRet1.UpdateDateTime != frePrtGuideSearchRet2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(frePrtGuideSearchRet1.OutputFormFileName != frePrtGuideSearchRet2.OutputFormFileName)resList.Add("OutputFormFileName");
			if(frePrtGuideSearchRet1.UserPrtPprIdDerivNo != frePrtGuideSearchRet2.UserPrtPprIdDerivNo)resList.Add("UserPrtPprIdDerivNo");
			if(frePrtGuideSearchRet1.FreePrtPprSchmGrpCd != frePrtGuideSearchRet2.FreePrtPprSchmGrpCd)resList.Add("FreePrtPprSchmGrpCd");
			if(frePrtGuideSearchRet1.FreePrtPprItemGrpCd != frePrtGuideSearchRet2.FreePrtPprItemGrpCd)resList.Add("FreePrtPprItemGrpCd");
			if(frePrtGuideSearchRet1.DisplayName != frePrtGuideSearchRet2.DisplayName)resList.Add("DisplayName");
			if(frePrtGuideSearchRet1.PrtPprUserDerivNoCmt != frePrtGuideSearchRet2.PrtPprUserDerivNoCmt)resList.Add("PrtPprUserDerivNoCmt");
			if(frePrtGuideSearchRet1.OutputFileClassId != frePrtGuideSearchRet2.OutputFileClassId)resList.Add("OutputFileClassId");
			if(frePrtGuideSearchRet1.DataInputSystem != frePrtGuideSearchRet2.DataInputSystem)resList.Add("DataInputSystem");
			if(frePrtGuideSearchRet1.PrintPaperUseDivcd != frePrtGuideSearchRet2.PrintPaperUseDivcd)resList.Add("PrintPaperUseDivcd");
			if(frePrtGuideSearchRet1.SpecialConvtUseDivCd != frePrtGuideSearchRet2.SpecialConvtUseDivCd)resList.Add("SpecialConvtUseDivCd");
			if(frePrtGuideSearchRet1.OptionCode != frePrtGuideSearchRet2.OptionCode)resList.Add("OptionCode");
			if(frePrtGuideSearchRet1.FormFeedLineCount != frePrtGuideSearchRet2.FormFeedLineCount)resList.Add("FormFeedLineCount");
			if(frePrtGuideSearchRet1.CrCharCnt != frePrtGuideSearchRet2.CrCharCnt)resList.Add("CrCharCnt");
			if(frePrtGuideSearchRet1.PgId != frePrtGuideSearchRet2.PgId)resList.Add("PgId");
			if(frePrtGuideSearchRet1.DmNo != frePrtGuideSearchRet2.DmNo)resList.Add("DmNo");
			if(frePrtGuideSearchRet1.PgSequenceNo != frePrtGuideSearchRet2.PgSequenceNo)resList.Add("PgSequenceNo");
			if(frePrtGuideSearchRet1.TopMargin != frePrtGuideSearchRet2.TopMargin)resList.Add("TopMargin");
			if(frePrtGuideSearchRet1.LeftMargin != frePrtGuideSearchRet2.LeftMargin)resList.Add("LeftMargin");
			if(frePrtGuideSearchRet1.RightMargin != frePrtGuideSearchRet2.RightMargin)resList.Add("RightMargin");
			if(frePrtGuideSearchRet1.BottomMargin != frePrtGuideSearchRet2.BottomMargin)resList.Add("BottomMargin");
			if(frePrtGuideSearchRet1.FreePrtPprItemGrpNm != frePrtGuideSearchRet2.FreePrtPprItemGrpNm)resList.Add("FreePrtPprItemGrpNm");
			if(frePrtGuideSearchRet1.DataInputSystemName != frePrtGuideSearchRet2.DataInputSystemName)resList.Add("DataInputSystemName");

			return resList;
		}
	}
}
