using System;
using System.IO;
using System.Text;
using System.Drawing;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	// ------------------------------------------------------------
	//  ※各種比較メソッドを手動で修正
	//  ※byte[]の自動で生成されるImage型のプロパティを削除
	//  ※明細背景色の初期値を255に変更
	// ------------------------------------------------------------

	/// public class name:   FrePrtPSet
	/// <summary>
	///                      自由帳票印字位置設定マスタ
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票印字位置設定マスタヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/07/19  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	public class FrePrtPSet
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

		/// <summary>出力ファイル名</summary>
		/// <remarks>フォームファイルID or フォーマットファイルID</remarks>
		private string _outputFormFileName = "";

		/// <summary>ユーザー帳票ID枝番号</summary>
		private Int32 _userPrtPprIdDerivNo;

		/// <summary>帳票使用区分</summary>
		/// <remarks>1:帳票,2:伝票</remarks>
		private Int32 _printPaperUseDivcd;

		/// <summary>帳票区分コード</summary>
		private Int32 _printPaperDivCd;

		/// <summary>抽出プログラムID</summary>
		private string _extractionPgId = "";

		/// <summary>抽出プログラムクラスID</summary>
		/// <remarks>印刷プログラムID or テキスト出力プログラムID</remarks>
		private string _extractionPgClassId = "";

		/// <summary>出力プログラムID</summary>
		private string _outputPgId = "";

		/// <summary>出力プログラムクラスID</summary>
		private string _outputPgClassId = "";

		/// <summary>出力確認メッセージ</summary>
		private string _outConfimationMsg = "";

		/// <summary>出力名称</summary>
		/// <remarks>ガイド等に表示する名称</remarks>
		private string _displayName = "";

		/// <summary>帳票ユーザー枝番コメント</summary>
		private string _prtPprUserDerivNoCmt = "";

		/// <summary>印字位置バージョン</summary>
		private Int32 _printPositionVer;

		/// <summary>マージ可能印字位置バージョン</summary>
		private Int32 _mergeablePrintPosVer;

		/// <summary>データ入力システム</summary>
		/// <remarks>0:共通,1:整備,2:鈑金,3:車販</remarks>
		private Int32 _dataInputSystem;

		/// <summary>オプションコード</summary>
		/// <remarks>ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ</remarks>
		private string _optionCode = "";

		/// <summary>自由帳票項目グループコード</summary>
		private Int32 _freePrtPprItemGrpCd;

		/// <summary>改頁行数</summary>
		private Int32 _formFeedLineCount;

		/// <summary>端文字処理区分</summary>
		/// <remarks>1:端文字切捨て,2:フォント縮小</remarks>
		private Int32 _edgeCharProcDivCd;

		/// <summary>帳票背景画像縦位置</summary>
		/// <remarks>Z9.9</remarks>
		private Double _prtPprBgImageRowPos;

		/// <summary>帳票背景画像横位置</summary>
		/// <remarks>Z9.9</remarks>
		private Double _prtPprBgImageColPos;

		/// <summary>取込画像グループコード</summary>
		/// <remarks>取込画像のグループ識別するためのGUID</remarks>
		private Guid _takeInImageGroupCd;

		/// <summary>抽出拠点種別区分</summary>
		/// <remarks>0:使用しない 1:実績・請求 2:仕入・販売</remarks>
		private Int32 _extraSectionKindCd;

		/// <summary>抽出拠点選択有無</summary>
		/// <remarks>0:使用しない 1:使用する(複数選択) 2:使用する(単体選択)</remarks>
		private Int32 _extraSectionSelExist;

		/// <summary>明細背景色(R)</summary>
		private Int32 _rDetailBackColor = 255;

		/// <summary>明細背景色(G)</summary>
		private Int32 _gDetailBackColor = 255;

		/// <summary>明細背景色(B)</summary>
		private Int32 _bDetailBackColor = 255;

		/// <summary>改行文字数</summary>
		/// <remarks>※伝票で作業・部品名称の改行文字数</remarks>
		private Int32 _crCharCnt;

		/// <summary>自由帳票 特種用途区分</summary>
		/// <remarks>0:使用しない,1:案内文印刷タイプ,2:専用帳票,3:官製はがき</remarks>
		private Int32 _freePrtPprSpPrpseCd;

		/// <summary>印字位置クラスデータ</summary>
		private Byte[] _printPosClassData;

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

		/// public propaty name  :  PrintPaperUseDivcd
		/// <summary>帳票使用区分プロパティ</summary>
		/// <value>1:帳票,2:伝票</value>
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

		/// public propaty name  :  PrintPaperDivCd
		/// <summary>帳票区分コードプロパティ</summary>
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

		/// public propaty name  :  ExtractionPgId
		/// <summary>抽出プログラムIDプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出プログラムIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExtractionPgId
		{
			get{return _extractionPgId;}
			set{_extractionPgId = value;}
		}

		/// public propaty name  :  ExtractionPgClassId
		/// <summary>抽出プログラムクラスIDプロパティ</summary>
		/// <value>印刷プログラムID or テキスト出力プログラムID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出プログラムクラスIDプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExtractionPgClassId
		{
			get{return _extractionPgClassId;}
			set{_extractionPgClassId = value;}
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

		/// public propaty name  :  PrintPositionVer
		/// <summary>印字位置バージョンプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印字位置バージョンプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintPositionVer
		{
			get{return _printPositionVer;}
			set{_printPositionVer = value;}
		}

		/// public propaty name  :  MergeablePrintPosVer
		/// <summary>マージ可能印字位置バージョンプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   マージ可能印字位置バージョンプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 MergeablePrintPosVer
		{
			get{return _mergeablePrintPosVer;}
			set{_mergeablePrintPosVer = value;}
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

		/// public propaty name  :  FormFeedLineCount
		/// <summary>改頁行数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改頁行数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FormFeedLineCount
		{
			get { return _formFeedLineCount; }
			set { _formFeedLineCount = value; }
		}

		/// public propaty name  :  EdgeCharProcDivCd
		/// <summary>端文字処理区分プロパティ</summary>
		/// <value>1:端文字切捨て,2:フォント縮小</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   端文字処理区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 EdgeCharProcDivCd
		{
			get { return _edgeCharProcDivCd; }
			set { _edgeCharProcDivCd = value; }
		}

		/// public propaty name  :  PrtPprBgImageRowPos
		/// <summary>帳票背景画像縦位置プロパティ</summary>
		/// <value>Z9.9</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票背景画像縦位置プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double PrtPprBgImageRowPos
		{
			get{return _prtPprBgImageRowPos;}
			set{_prtPprBgImageRowPos = value;}
		}

		/// public propaty name  :  PrtPprBgImageColPos
		/// <summary>帳票背景画像横位置プロパティ</summary>
		/// <value>Z9.9</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票背景画像横位置プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Double PrtPprBgImageColPos
		{
			get{return _prtPprBgImageColPos;}
			set{_prtPprBgImageColPos = value;}
		}

		/// public propaty name  :  TakeInImageGroupCd
		/// <summary>取込画像グループコードプロパティ</summary>
		/// <value>取込画像のグループ識別するためのGUID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   取込画像グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Guid TakeInImageGroupCd
		{
			get{return _takeInImageGroupCd;}
			set{_takeInImageGroupCd = value;}
		}

		/// public propaty name  :  ExtraSectionKindCd
		/// <summary>抽出拠点種別区分プロパティ</summary>
		/// <value>0:使用しない 1:実績・請求 2:仕入・販売</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出拠点種別区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtraSectionKindCd
		{
			get { return _extraSectionKindCd; }
			set { _extraSectionKindCd = value; }
		}

		/// public propaty name  :  ExtraSectionSelExist
		/// <summary>抽出拠点選択有無プロパティ</summary>
		/// <value>0:使用しない 1:使用する(複数選択) 2:使用する(単体選択)</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出拠点選択有無プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtraSectionSelExist
		{
			get { return _extraSectionSelExist; }
			set { _extraSectionSelExist = value; }
		}

		/// public propaty name  :  RDetailBackColor
		/// <summary>明細背景色(R)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細背景色(R)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 RDetailBackColor
		{
			get { return _rDetailBackColor; }
			set { _rDetailBackColor = value; }
		}

		/// public propaty name  :  GDetailBackColor
		/// <summary>明細背景色(G)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細背景色(G)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GDetailBackColor
		{
			get { return _gDetailBackColor; }
			set { _gDetailBackColor = value; }
		}

		/// public propaty name  :  BDetailBackColor
		/// <summary>明細背景色(B)プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細背景色(B)プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BDetailBackColor
		{
			get { return _bDetailBackColor; }
			set { _bDetailBackColor = value; }
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
			get { return _crCharCnt; }
			set { _crCharCnt = value; }
		}

		/// public propaty name  :  FreePrtPprSpPrpseCd
		/// <summary>自由帳票 特種用途区分プロパティ</summary>
		/// <value>0:使用しない,1:案内文印刷タイプ,2:専用帳票,3:官製はがき</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票 特種用途区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPprSpPrpseCd
		{
			get { return _freePrtPprSpPrpseCd; }
			set { _freePrtPprSpPrpseCd = value; }
		}

		/// public propaty name  :  PrintPosClassData
		/// <summary>印字位置クラスデータプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印字位置クラスデータプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Byte[] PrintPosClassData
		{
			get{return _printPosClassData;}
			set{_printPosClassData = value;}
		}


		/// <summary>
		/// 自由帳票印字位置設定マスタコンストラクタ
		/// </summary>
		/// <returns>FrePrtPSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtPSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePrtPSet()
		{
		}

		/// <summary>
		/// 自由帳票印字位置設定マスタコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
		/// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
		/// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
		/// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="outputFormFileName">出力ファイル名(フォームファイルID or フォーマットファイルID)</param>
		/// <param name="userPrtPprIdDerivNo">ユーザー帳票ID枝番号</param>
		/// <param name="printPaperUseDivcd">帳票使用区分(1:帳票,2:伝票)</param>
		/// <param name="printPaperDivCd">帳票区分コード</param>
		/// <param name="extractionPgId">抽出プログラムID</param>
		/// <param name="extractionPgClassId">抽出プログラムクラスID(印刷プログラムID or テキスト出力プログラムID)</param>
		/// <param name="outputPgId">出力プログラムID</param>
		/// <param name="outputPgClassId">出力プログラムクラスID</param>
		/// <param name="outConfimationMsg">出力確認メッセージ</param>
		/// <param name="displayName">出力名称(ガイド等に表示する名称)</param>
		/// <param name="prtPprUserDerivNoCmt">帳票ユーザー枝番コメント</param>
		/// <param name="printPositionVer">印字位置バージョン</param>
		/// <param name="mergeablePrintPosVer">マージ可能印字位置バージョン</param>
		/// <param name="dataInputSystem">データ入力システム(0:共通,1:整備,2:鈑金,3:車販)</param>
		/// <param name="optionCode">オプションコード(ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ)</param>
		/// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
		/// <param name="formFeedLineCount">改頁行数</param>
		/// <param name="edgeCharProcDivCd">端文字処理区分(1:端文字切捨て,2:フォント縮小)</param>
		/// <param name="prtPprBgImageRowPos">帳票背景画像縦位置(Z9.9)</param>
		/// <param name="prtPprBgImageColPos">帳票背景画像横位置(Z9.9)</param>
		/// <param name="takeInImageGroupCd">取込画像グループコード(取込画像のグループ識別するためのGUID)</param>
		/// <param name="extraSectionKindCd">抽出拠点種別区分(0:使用しない 1:実績・請求 2:仕入・販売)</param>
		/// <param name="extraSectionSelExist">抽出拠点選択有無(0:使用しない 1:使用する(複数選択) 2:使用する(単体選択))</param>
		/// <param name="rDetailBackColor">明細背景色(R)</param>
		/// <param name="gDetailBackColor">明細背景色(G)</param>
		/// <param name="bDetailBackColor">明細背景色(B)</param>
		/// <param name="crCharCnt">改行文字数(※伝票で作業・部品名称の改行文字数)</param>
		/// <param name="freePrtPprSpPrpseCd">自由帳票 特種用途区分(0:使用しない,1:案内文印刷タイプ,2:専用帳票,3:官製はがき)</param>
		/// <param name="printPosClassData">印字位置クラスデータ</param>
		/// <returns>FrePrtPSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtPSetクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePrtPSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string outputFormFileName, Int32 userPrtPprIdDerivNo, Int32 printPaperUseDivcd, Int32 printPaperDivCd, string extractionPgId, string extractionPgClassId, string outputPgId, string outputPgClassId, string outConfimationMsg, string displayName, string prtPprUserDerivNoCmt, Int32 printPositionVer, Int32 mergeablePrintPosVer, Int32 dataInputSystem, string optionCode, Int32 freePrtPprItemGrpCd, Int32 formFeedLineCount, Int32 edgeCharProcDivCd, Double prtPprBgImageRowPos, Double prtPprBgImageColPos, Guid takeInImageGroupCd, Int32 extraSectionKindCd, Int32 extraSectionSelExist, Int32 rDetailBackColor, Int32 gDetailBackColor, Int32 bDetailBackColor, Int32 crCharCnt, Int32 freePrtPprSpPrpseCd, Byte[] printPosClassData)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._enterpriseCode = enterpriseCode;
			this._fileHeaderGuid = fileHeaderGuid;
			this._updEmployeeCode = updEmployeeCode;
			this._updAssemblyId1 = updAssemblyId1;
			this._updAssemblyId2 = updAssemblyId2;
			this._logicalDeleteCode = logicalDeleteCode;
			this._outputFormFileName = outputFormFileName;
			this._userPrtPprIdDerivNo = userPrtPprIdDerivNo;
			this._printPaperUseDivcd = printPaperUseDivcd;
			this._printPaperDivCd = printPaperDivCd;
			this._extractionPgId = extractionPgId;
			this._extractionPgClassId = extractionPgClassId;
			this._outputPgId = outputPgId;
			this._outputPgClassId = outputPgClassId;
			this._outConfimationMsg = outConfimationMsg;
			this._displayName = displayName;
			this._prtPprUserDerivNoCmt = prtPprUserDerivNoCmt;
			this._printPositionVer = printPositionVer;
			this._mergeablePrintPosVer = mergeablePrintPosVer;
			this._dataInputSystem = dataInputSystem;
			this._optionCode = optionCode;
			this._freePrtPprItemGrpCd = freePrtPprItemGrpCd;
			this._formFeedLineCount = formFeedLineCount;
			this._edgeCharProcDivCd = edgeCharProcDivCd;
			this._prtPprBgImageRowPos = prtPprBgImageRowPos;
			this._prtPprBgImageColPos = prtPprBgImageColPos;
			this._takeInImageGroupCd = takeInImageGroupCd;
			this._extraSectionKindCd = extraSectionKindCd;
			this._extraSectionSelExist = extraSectionSelExist;
			this._rDetailBackColor = rDetailBackColor;
			this._gDetailBackColor = gDetailBackColor;
			this._bDetailBackColor = bDetailBackColor;
			this._crCharCnt = crCharCnt;
			this._freePrtPprSpPrpseCd = freePrtPprSpPrpseCd;
			this._printPosClassData = printPosClassData;

		}

		/// <summary>
		/// 自由帳票印字位置設定マスタ複製処理
		/// </summary>
		/// <returns>FrePrtPSetクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいFrePrtPSetクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePrtPSet Clone()
		{
			return new FrePrtPSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._outputFormFileName, this._userPrtPprIdDerivNo, this._printPaperUseDivcd, this._printPaperDivCd, this._extractionPgId, this._extractionPgClassId, this._outputPgId, this._outputPgClassId, this._outConfimationMsg, this._displayName, this._prtPprUserDerivNoCmt, this._printPositionVer, this._mergeablePrintPosVer, this._dataInputSystem, this._optionCode, this._freePrtPprItemGrpCd, this._formFeedLineCount, this._edgeCharProcDivCd, this._prtPprBgImageRowPos, this._prtPprBgImageColPos, this._takeInImageGroupCd, this._extraSectionKindCd, this._extraSectionSelExist, this._rDetailBackColor, this._gDetailBackColor, this._bDetailBackColor, this._crCharCnt, this._freePrtPprSpPrpseCd, this._printPosClassData);
		}

		/// <summary>
		/// 自由帳票印字位置設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のFrePrtPSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtPSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(FrePrtPSet target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.EnterpriseCode == target.EnterpriseCode)
				 && (this.FileHeaderGuid == target.FileHeaderGuid)
				 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
				 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
				 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.OutputFormFileName == target.OutputFormFileName)
				 && (this.UserPrtPprIdDerivNo == target.UserPrtPprIdDerivNo)
				 && (this.PrintPaperUseDivcd == target.PrintPaperUseDivcd)
				 && (this.PrintPaperDivCd == target.PrintPaperDivCd)
				 && (this.ExtractionPgId == target.ExtractionPgId)
				 && (this.ExtractionPgClassId == target.ExtractionPgClassId)
				 && (this.OutputPgId == target.OutputPgId)
				 && (this.OutputPgClassId == target.OutputPgClassId)
				 && (this.OutConfimationMsg == target.OutConfimationMsg)
				 && (this.DisplayName == target.DisplayName)
				 && (this.PrtPprUserDerivNoCmt == target.PrtPprUserDerivNoCmt)
				 && (this.PrintPositionVer == target.PrintPositionVer)
				 && (this.MergeablePrintPosVer == target.MergeablePrintPosVer)
				 && (this.DataInputSystem == target.DataInputSystem)
				 && (this.OptionCode == target.OptionCode)
				 && (this.FreePrtPprItemGrpCd == target.FreePrtPprItemGrpCd)
				 && (this.FormFeedLineCount == target.FormFeedLineCount)
				 && (this.EdgeCharProcDivCd == target.EdgeCharProcDivCd)
				 && (this.PrtPprBgImageRowPos == target.PrtPprBgImageRowPos)
				 && (this.PrtPprBgImageColPos == target.PrtPprBgImageColPos)
				 && (this.TakeInImageGroupCd == target.TakeInImageGroupCd)
				 && (this.ExtraSectionKindCd == target.ExtraSectionKindCd)
				 && (this.ExtraSectionSelExist == target.ExtraSectionSelExist)
				 && (this.RDetailBackColor == target.RDetailBackColor)
				 && (this.GDetailBackColor == target.GDetailBackColor)
				 && (this.BDetailBackColor == target.BDetailBackColor)
				 && (this.CrCharCnt == target.CrCharCnt)
				 && (this.FreePrtPprSpPrpseCd == target.FreePrtPprSpPrpseCd)
				//&& (this.PrintPosClassData == target.PrintPosClassData)
				);
		}

		/// <summary>
		/// 自由帳票印字位置設定マスタ比較処理
		/// </summary>
		/// <param name="frePrtPSet1">
		///                    比較するFrePrtPSetクラスのインスタンス
		/// </param>
		/// <param name="frePrtPSet2">比較するFrePrtPSetクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtPSetクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(FrePrtPSet frePrtPSet1, FrePrtPSet frePrtPSet2)
		{
			return ((frePrtPSet1.CreateDateTime == frePrtPSet2.CreateDateTime)
				 && (frePrtPSet1.UpdateDateTime == frePrtPSet2.UpdateDateTime)
				 && (frePrtPSet1.EnterpriseCode == frePrtPSet2.EnterpriseCode)
				 && (frePrtPSet1.FileHeaderGuid == frePrtPSet2.FileHeaderGuid)
				 && (frePrtPSet1.UpdEmployeeCode == frePrtPSet2.UpdEmployeeCode)
				 && (frePrtPSet1.UpdAssemblyId1 == frePrtPSet2.UpdAssemblyId1)
				 && (frePrtPSet1.UpdAssemblyId2 == frePrtPSet2.UpdAssemblyId2)
				 && (frePrtPSet1.LogicalDeleteCode == frePrtPSet2.LogicalDeleteCode)
				 && (frePrtPSet1.OutputFormFileName == frePrtPSet2.OutputFormFileName)
				 && (frePrtPSet1.UserPrtPprIdDerivNo == frePrtPSet2.UserPrtPprIdDerivNo)
				 && (frePrtPSet1.PrintPaperUseDivcd == frePrtPSet2.PrintPaperUseDivcd)
				 && (frePrtPSet1.PrintPaperDivCd == frePrtPSet2.PrintPaperDivCd)
				 && (frePrtPSet1.ExtractionPgId == frePrtPSet2.ExtractionPgId)
				 && (frePrtPSet1.ExtractionPgClassId == frePrtPSet2.ExtractionPgClassId)
				 && (frePrtPSet1.OutputPgId == frePrtPSet2.OutputPgId)
				 && (frePrtPSet1.OutputPgClassId == frePrtPSet2.OutputPgClassId)
				 && (frePrtPSet1.OutConfimationMsg == frePrtPSet2.OutConfimationMsg)
				 && (frePrtPSet1.DisplayName == frePrtPSet2.DisplayName)
				 && (frePrtPSet1.PrtPprUserDerivNoCmt == frePrtPSet2.PrtPprUserDerivNoCmt)
				 && (frePrtPSet1.PrintPositionVer == frePrtPSet2.PrintPositionVer)
				 && (frePrtPSet1.MergeablePrintPosVer == frePrtPSet2.MergeablePrintPosVer)
				 && (frePrtPSet1.DataInputSystem == frePrtPSet2.DataInputSystem)
				 && (frePrtPSet1.OptionCode == frePrtPSet2.OptionCode)
				 && (frePrtPSet1.FreePrtPprItemGrpCd == frePrtPSet2.FreePrtPprItemGrpCd)
				 && (frePrtPSet1.FormFeedLineCount == frePrtPSet2.FormFeedLineCount)
				 && (frePrtPSet1.EdgeCharProcDivCd == frePrtPSet2.EdgeCharProcDivCd)
				 && (frePrtPSet1.PrtPprBgImageRowPos == frePrtPSet2.PrtPprBgImageRowPos)
				 && (frePrtPSet1.PrtPprBgImageColPos == frePrtPSet2.PrtPprBgImageColPos)
				 && (frePrtPSet1.TakeInImageGroupCd == frePrtPSet2.TakeInImageGroupCd)
				 && (frePrtPSet1.ExtraSectionKindCd == frePrtPSet2.ExtraSectionKindCd)
				 && (frePrtPSet1.ExtraSectionSelExist == frePrtPSet2.ExtraSectionSelExist)
				 && (frePrtPSet1.RDetailBackColor == frePrtPSet2.RDetailBackColor)
				 && (frePrtPSet1.GDetailBackColor == frePrtPSet2.GDetailBackColor)
				 && (frePrtPSet1.BDetailBackColor == frePrtPSet2.BDetailBackColor)
				 && (frePrtPSet1.CrCharCnt == frePrtPSet2.CrCharCnt)
				 && (frePrtPSet1.FreePrtPprSpPrpseCd == frePrtPSet2.FreePrtPprSpPrpseCd)
				//&& (frePrtPSet1.PrintPosClassData == frePrtPSet2.PrintPosClassData)
				 );
		}
		/// <summary>
		/// 自由帳票印字位置設定マスタ比較処理
		/// </summary>
		/// <param name="target">比較対象のFrePrtPSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtPSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(FrePrtPSet target)
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
			if (this.OutputFormFileName != target.OutputFormFileName) resList.Add("OutputFormFileName");
			if (this.UserPrtPprIdDerivNo != target.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
			if (this.PrintPaperUseDivcd != target.PrintPaperUseDivcd) resList.Add("PrintPaperUseDivcd");
			if (this.PrintPaperDivCd != target.PrintPaperDivCd) resList.Add("PrintPaperDivCd");
			if (this.ExtractionPgId != target.ExtractionPgId) resList.Add("ExtractionPgId");
			if (this.ExtractionPgClassId != target.ExtractionPgClassId) resList.Add("ExtractionPgClassId");
			if (this.OutputPgId != target.OutputPgId) resList.Add("OutputPgId");
			if (this.OutputPgClassId != target.OutputPgClassId) resList.Add("OutputPgClassId");
			if (this.OutConfimationMsg != target.OutConfimationMsg) resList.Add("OutConfimationMsg");
			if (this.DisplayName != target.DisplayName) resList.Add("DisplayName");
			if (this.PrtPprUserDerivNoCmt != target.PrtPprUserDerivNoCmt) resList.Add("PrtPprUserDerivNoCmt");
			if (this.PrintPositionVer != target.PrintPositionVer) resList.Add("PrintPositionVer");
			if (this.MergeablePrintPosVer != target.MergeablePrintPosVer) resList.Add("MergeablePrintPosVer");
			if (this.DataInputSystem != target.DataInputSystem) resList.Add("DataInputSystem");
			if (this.OptionCode != target.OptionCode) resList.Add("OptionCode");
			if (this.FreePrtPprItemGrpCd != target.FreePrtPprItemGrpCd) resList.Add("FreePrtPprItemGrpCd");
			if (this.FormFeedLineCount != target.FormFeedLineCount) resList.Add("FormFeedLineCount");
			if (this.EdgeCharProcDivCd != target.EdgeCharProcDivCd) resList.Add("EdgeCharProcDivCd");
			if (this.PrtPprBgImageRowPos != target.PrtPprBgImageRowPos) resList.Add("PrtPprBgImageRowPos");
			if (this.PrtPprBgImageColPos != target.PrtPprBgImageColPos) resList.Add("PrtPprBgImageColPos");
			if (this.TakeInImageGroupCd != target.TakeInImageGroupCd) resList.Add("TakeInImageGroupCd");
			if (this.ExtraSectionKindCd != target.ExtraSectionKindCd) resList.Add("ExtraSectionKindCd");
			if (this.ExtraSectionSelExist != target.ExtraSectionSelExist) resList.Add("ExtraSectionSelExist");
			if (this.RDetailBackColor != target.RDetailBackColor) resList.Add("RDetailBackColor");
			if (this.GDetailBackColor != target.GDetailBackColor) resList.Add("GDetailBackColor");
			if (this.BDetailBackColor != target.BDetailBackColor) resList.Add("BDetailBackColor");
			if (this.CrCharCnt != target.CrCharCnt) resList.Add("CrCharCnt");
			if (this.FreePrtPprSpPrpseCd != target.FreePrtPprSpPrpseCd) resList.Add("FreePrtPprSpPrpseCd");
			//if (this.PrintPosClassData != target.PrintPosClassData) resList.Add("PrintPosClassData");

			return resList;
		}

		/// <summary>
		/// 自由帳票印字位置設定マスタ比較処理
		/// </summary>
		/// <param name="frePrtPSet1">比較するFrePrtPSetクラスのインスタンス</param>
		/// <param name="frePrtPSet2">比較するFrePrtPSetクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtPSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(FrePrtPSet frePrtPSet1, FrePrtPSet frePrtPSet2)
		{
			ArrayList resList = new ArrayList();
			if (frePrtPSet1.CreateDateTime != frePrtPSet2.CreateDateTime) resList.Add("CreateDateTime");
			if (frePrtPSet1.UpdateDateTime != frePrtPSet2.UpdateDateTime) resList.Add("UpdateDateTime");
			if (frePrtPSet1.EnterpriseCode != frePrtPSet2.EnterpriseCode) resList.Add("EnterpriseCode");
			if (frePrtPSet1.FileHeaderGuid != frePrtPSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
			if (frePrtPSet1.UpdEmployeeCode != frePrtPSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
			if (frePrtPSet1.UpdAssemblyId1 != frePrtPSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
			if (frePrtPSet1.UpdAssemblyId2 != frePrtPSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
			if (frePrtPSet1.LogicalDeleteCode != frePrtPSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
			if (frePrtPSet1.OutputFormFileName != frePrtPSet2.OutputFormFileName) resList.Add("OutputFormFileName");
			if (frePrtPSet1.UserPrtPprIdDerivNo != frePrtPSet2.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
			if (frePrtPSet1.PrintPaperUseDivcd != frePrtPSet2.PrintPaperUseDivcd) resList.Add("PrintPaperUseDivcd");
			if (frePrtPSet1.PrintPaperDivCd != frePrtPSet2.PrintPaperDivCd) resList.Add("PrintPaperDivCd");
			if (frePrtPSet1.ExtractionPgId != frePrtPSet2.ExtractionPgId) resList.Add("ExtractionPgId");
			if (frePrtPSet1.ExtractionPgClassId != frePrtPSet2.ExtractionPgClassId) resList.Add("ExtractionPgClassId");
			if (frePrtPSet1.OutputPgId != frePrtPSet2.OutputPgId) resList.Add("OutputPgId");
			if (frePrtPSet1.OutputPgClassId != frePrtPSet2.OutputPgClassId) resList.Add("OutputPgClassId");
			if (frePrtPSet1.OutConfimationMsg != frePrtPSet2.OutConfimationMsg) resList.Add("OutConfimationMsg");
			if (frePrtPSet1.DisplayName != frePrtPSet2.DisplayName) resList.Add("DisplayName");
			if (frePrtPSet1.PrtPprUserDerivNoCmt != frePrtPSet2.PrtPprUserDerivNoCmt) resList.Add("PrtPprUserDerivNoCmt");
			if (frePrtPSet1.PrintPositionVer != frePrtPSet2.PrintPositionVer) resList.Add("PrintPositionVer");
			if (frePrtPSet1.MergeablePrintPosVer != frePrtPSet2.MergeablePrintPosVer) resList.Add("MergeablePrintPosVer");
			if (frePrtPSet1.DataInputSystem != frePrtPSet2.DataInputSystem) resList.Add("DataInputSystem");
			if (frePrtPSet1.OptionCode != frePrtPSet2.OptionCode) resList.Add("OptionCode");
			if (frePrtPSet1.FreePrtPprItemGrpCd != frePrtPSet2.FreePrtPprItemGrpCd) resList.Add("FreePrtPprItemGrpCd");
			if (frePrtPSet1.FormFeedLineCount != frePrtPSet2.FormFeedLineCount) resList.Add("FormFeedLineCount");
			if (frePrtPSet1.EdgeCharProcDivCd != frePrtPSet2.EdgeCharProcDivCd) resList.Add("EdgeCharProcDivCd");
			if (frePrtPSet1.PrtPprBgImageRowPos != frePrtPSet2.PrtPprBgImageRowPos) resList.Add("PrtPprBgImageRowPos");
			if (frePrtPSet1.PrtPprBgImageColPos != frePrtPSet2.PrtPprBgImageColPos) resList.Add("PrtPprBgImageColPos");
			if (frePrtPSet1.TakeInImageGroupCd != frePrtPSet2.TakeInImageGroupCd) resList.Add("TakeInImageGroupCd");
			if (frePrtPSet1.ExtraSectionKindCd != frePrtPSet2.ExtraSectionKindCd) resList.Add("ExtraSectionKindCd");
			if (frePrtPSet1.ExtraSectionSelExist != frePrtPSet2.ExtraSectionSelExist) resList.Add("ExtraSectionSelExist");
			if (frePrtPSet1.RDetailBackColor != frePrtPSet2.RDetailBackColor) resList.Add("RDetailBackColor");
			if (frePrtPSet1.GDetailBackColor != frePrtPSet2.GDetailBackColor) resList.Add("GDetailBackColor");
			if (frePrtPSet1.BDetailBackColor != frePrtPSet2.BDetailBackColor) resList.Add("BDetailBackColor");
			if (frePrtPSet1.CrCharCnt != frePrtPSet2.CrCharCnt) resList.Add("CrCharCnt");
			if (frePrtPSet1.FreePrtPprSpPrpseCd != frePrtPSet2.FreePrtPprSpPrpseCd) resList.Add("FreePrtPprSpPrpseCd");
			//if (frePrtPSet1.PrintPosClassData != frePrtPSet2.PrintPosClassData) resList.Add("PrintPosClassData");

			return resList;
		}

		/// <summary>
		/// 印字位置クラスデータ比較処理
		/// </summary>
		/// <param name="target">比較対象</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note       : バイト配列の内容が一致するか比較します。</br>
		/// <br>Programmer : 22024 寺坂誉志</br>
		/// <br>Date       : 2007.04.12</br>
		/// </remarks>
		public bool EqualsPrintPosClassData(byte[] target)
		{
			bool isEqual = false;

			if (this.PrintPosClassData == null && target == null)
				isEqual = true;
			else if (this.PrintPosClassData != null && target != null)
			{
				isEqual = Encoding.Unicode.GetString(this.PrintPosClassData).Equals(
							Encoding.Unicode.GetString(target));
			}

			return isEqual;
		}

		/// <summary>
		/// 明細背景色取得処理
		/// </summary>
		/// <returns>明細背景色</returns>
		/// <remarks>
		/// <br>Note       : 明細背景色を取得します。</br>
		/// <br>Programmer : 22024 寺坂誉志</br>
		/// <br>Date       : 2007.09.27</br>
		/// </remarks>
		public Color GetDetailBackColor()
		{
			return Color.FromArgb(_rDetailBackColor, _gDetailBackColor, _bDetailBackColor);
		}

		/// <summary>
		/// 明細背景色設定処理
		/// </summary>
		/// <param name="detailBackColor">明細背景色</param>
		/// <remarks>
		/// <br>Note       : 明細背景色を設定します。</br>
		/// <br>Programmer : 22024 寺坂誉志</br>
		/// <br>Date       : 2007.09.27</br>
		/// </remarks>
		public void SetDetailBackColor(Color detailBackColor)
		{
			_rDetailBackColor = detailBackColor.R;
			_gDetailBackColor = detailBackColor.G;
			_bDetailBackColor = detailBackColor.B;
		}
	}
}
