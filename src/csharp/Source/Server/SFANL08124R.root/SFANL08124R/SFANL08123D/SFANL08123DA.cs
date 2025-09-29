using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   FrePrtPSetWork
	/// <summary>
	///                      自由帳票印字位置設定ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   自由帳票印字位置設定ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/10/16  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class FrePrtPSetWork : IFileHeader
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
		/// <remarks>1:帳票,2:伝票,3:DM一覧表,4:DMはがき</remarks>
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
		private Int32 _rDetailBackColor;

		/// <summary>明細背景色(G)</summary>
		private Int32 _gDetailBackColor;

		/// <summary>明細背景色(B)</summary>
		private Int32 _bDetailBackColor;

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
			get { return _createDateTime; }
			set { _createDateTime = value; }
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
			get { return _updateDateTime; }
			set { _updateDateTime = value; }
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
			get { return _enterpriseCode; }
			set { _enterpriseCode = value; }
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
			get { return _fileHeaderGuid; }
			set { _fileHeaderGuid = value; }
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
			get { return _updEmployeeCode; }
			set { _updEmployeeCode = value; }
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
			get { return _updAssemblyId1; }
			set { _updAssemblyId1 = value; }
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
			get { return _updAssemblyId2; }
			set { _updAssemblyId2 = value; }
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
			get { return _logicalDeleteCode; }
			set { _logicalDeleteCode = value; }
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
			get { return _outputFormFileName; }
			set { _outputFormFileName = value; }
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
			get { return _userPrtPprIdDerivNo; }
			set { _userPrtPprIdDerivNo = value; }
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
			get { return _printPaperUseDivcd; }
			set { _printPaperUseDivcd = value; }
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
			get { return _printPaperDivCd; }
			set { _printPaperDivCd = value; }
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
			get { return _extractionPgId; }
			set { _extractionPgId = value; }
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
			get { return _extractionPgClassId; }
			set { _extractionPgClassId = value; }
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
			get { return _outputPgId; }
			set { _outputPgId = value; }
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
			get { return _outputPgClassId; }
			set { _outputPgClassId = value; }
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
			get { return _outConfimationMsg; }
			set { _outConfimationMsg = value; }
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
			get { return _displayName; }
			set { _displayName = value; }
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
			get { return _prtPprUserDerivNoCmt; }
			set { _prtPprUserDerivNoCmt = value; }
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
			get { return _printPositionVer; }
			set { _printPositionVer = value; }
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
			get { return _mergeablePrintPosVer; }
			set { _mergeablePrintPosVer = value; }
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
			get { return _dataInputSystem; }
			set { _dataInputSystem = value; }
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
			get { return _optionCode; }
			set { _optionCode = value; }
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
			get { return _freePrtPprItemGrpCd; }
			set { _freePrtPprItemGrpCd = value; }
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
			get { return _prtPprBgImageRowPos; }
			set { _prtPprBgImageRowPos = value; }
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
			get { return _prtPprBgImageColPos; }
			set { _prtPprBgImageColPos = value; }
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
			get { return _takeInImageGroupCd; }
			set { _takeInImageGroupCd = value; }
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
			get { return _printPosClassData; }
			set { _printPosClassData = value; }
		}


		/// <summary>
		/// 自由帳票印字位置設定ワークコンストラクタ
		/// </summary>
		/// <returns>FrePrtPSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtPSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public FrePrtPSetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>FrePrtPSetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   FrePrtPSetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class FrePrtPSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtPSetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  FrePrtPSetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is FrePrtPSetWork || graph is ArrayList || graph is FrePrtPSetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(FrePrtPSetWork).FullName));

			if (graph != null && graph is FrePrtPSetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.FrePrtPSetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is FrePrtPSetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((FrePrtPSetWork[])graph).Length;
			}
			else if (graph is FrePrtPSetWork)
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
			//出力ファイル名
			serInfo.MemberInfo.Add(typeof(string)); //OutputFormFileName
			//ユーザー帳票ID枝番号
			serInfo.MemberInfo.Add(typeof(Int32)); //UserPrtPprIdDerivNo
			//帳票使用区分
			serInfo.MemberInfo.Add(typeof(Int32)); //PrintPaperUseDivcd
			//帳票区分コード
			serInfo.MemberInfo.Add(typeof(Int32)); //PrintPaperDivCd
			//抽出プログラムID
			serInfo.MemberInfo.Add(typeof(string)); //ExtractionPgId
			//抽出プログラムクラスID
			serInfo.MemberInfo.Add(typeof(string)); //ExtractionPgClassId
			//出力プログラムID
			serInfo.MemberInfo.Add(typeof(string)); //OutputPgId
			//出力プログラムクラスID
			serInfo.MemberInfo.Add(typeof(string)); //OutputPgClassId
			//出力確認メッセージ
			serInfo.MemberInfo.Add(typeof(string)); //OutConfimationMsg
			//出力名称
			serInfo.MemberInfo.Add(typeof(string)); //DisplayName
			//帳票ユーザー枝番コメント
			serInfo.MemberInfo.Add(typeof(string)); //PrtPprUserDerivNoCmt
			//印字位置バージョン
			serInfo.MemberInfo.Add(typeof(Int32)); //PrintPositionVer
			//マージ可能印字位置バージョン
			serInfo.MemberInfo.Add(typeof(Int32)); //MergeablePrintPosVer
			//データ入力システム
			serInfo.MemberInfo.Add(typeof(Int32)); //DataInputSystem
			//オプションコード
			serInfo.MemberInfo.Add(typeof(string)); //OptionCode
			//自由帳票項目グループコード
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprItemGrpCd
			//改頁行数
			serInfo.MemberInfo.Add(typeof(Int32)); //FormFeedLineCount
			//端文字処理区分
			serInfo.MemberInfo.Add(typeof(Int32)); //EdgeCharProcDivCd
			//帳票背景画像縦位置
			serInfo.MemberInfo.Add(typeof(Double)); //PrtPprBgImageRowPos
			//帳票背景画像横位置
			serInfo.MemberInfo.Add(typeof(Double)); //PrtPprBgImageColPos
			//取込画像グループコード
			serInfo.MemberInfo.Add(typeof(byte[]));  //TakeInImageGroupCd
			//抽出拠点種別区分
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraSectionKindCd
			//抽出拠点選択有無
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraSectionSelExist
			//明細背景色(R)
			serInfo.MemberInfo.Add(typeof(Int32)); //RDetailBackColor
			//明細背景色(G)
			serInfo.MemberInfo.Add(typeof(Int32)); //GDetailBackColor
			//明細背景色(B)
			serInfo.MemberInfo.Add(typeof(Int32)); //BDetailBackColor
			//改行文字数
			serInfo.MemberInfo.Add(typeof(Int32)); //CrCharCnt
			//自由帳票 特種用途区分
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprSpPrpseCd
			//印字位置クラスデータ
			serInfo.MemberInfo.Add(typeof(Byte[])); //PrintPosClassData


			serInfo.Serialize(writer, serInfo);
			if (graph is FrePrtPSetWork)
			{
				FrePrtPSetWork temp = (FrePrtPSetWork)graph;

				SetFrePrtPSetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is FrePrtPSetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((FrePrtPSetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (FrePrtPSetWork temp in lst)
				{
					SetFrePrtPSetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// FrePrtPSetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 37;

		/// <summary>
		///  FrePrtPSetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtPSetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetFrePrtPSetWork(System.IO.BinaryWriter writer, FrePrtPSetWork temp)
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
			//出力ファイル名
			writer.Write(temp.OutputFormFileName);
			//ユーザー帳票ID枝番号
			writer.Write(temp.UserPrtPprIdDerivNo);
			//帳票使用区分
			writer.Write(temp.PrintPaperUseDivcd);
			//帳票区分コード
			writer.Write(temp.PrintPaperDivCd);
			//抽出プログラムID
			writer.Write(temp.ExtractionPgId);
			//抽出プログラムクラスID
			writer.Write(temp.ExtractionPgClassId);
			//出力プログラムID
			writer.Write(temp.OutputPgId);
			//出力プログラムクラスID
			writer.Write(temp.OutputPgClassId);
			//出力確認メッセージ
			writer.Write(temp.OutConfimationMsg);
			//出力名称
			writer.Write(temp.DisplayName);
			//帳票ユーザー枝番コメント
			writer.Write(temp.PrtPprUserDerivNoCmt);
			//印字位置バージョン
			writer.Write(temp.PrintPositionVer);
			//マージ可能印字位置バージョン
			writer.Write(temp.MergeablePrintPosVer);
			//データ入力システム
			writer.Write(temp.DataInputSystem);
			//オプションコード
			writer.Write(temp.OptionCode);
			//自由帳票項目グループコード
			writer.Write(temp.FreePrtPprItemGrpCd);
			//改頁行数
			writer.Write(temp.FormFeedLineCount);
			//端文字処理区分
			writer.Write(temp.EdgeCharProcDivCd);
			//帳票背景画像縦位置
			writer.Write(temp.PrtPprBgImageRowPos);
			//帳票背景画像横位置
			writer.Write(temp.PrtPprBgImageColPos);
			//取込画像グループコード
			byte[] takeInImageGroupCdArray = temp.TakeInImageGroupCd.ToByteArray();
			writer.Write(takeInImageGroupCdArray.Length);
			writer.Write(temp.TakeInImageGroupCd.ToByteArray());
			//抽出拠点種別区分
			writer.Write(temp.ExtraSectionKindCd);
			//抽出拠点選択有無
			writer.Write(temp.ExtraSectionSelExist);
			//明細背景色(R)
			writer.Write(temp.RDetailBackColor);
			//明細背景色(G)
			writer.Write(temp.GDetailBackColor);
			//明細背景色(B)
			writer.Write(temp.BDetailBackColor);
			//改行文字数
			writer.Write(temp.CrCharCnt);
			//自由帳票 特種用途区分
			writer.Write(temp.FreePrtPprSpPrpseCd);
			//印字位置クラスデータ
			writer.Write(temp.PrintPosClassData);

		}

		/// <summary>
		///  FrePrtPSetWorkインスタンス取得
		/// </summary>
		/// <returns>FrePrtPSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtPSetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private FrePrtPSetWork GetFrePrtPSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			FrePrtPSetWork temp = new FrePrtPSetWork();

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
			//出力ファイル名
			temp.OutputFormFileName = reader.ReadString();
			//ユーザー帳票ID枝番号
			temp.UserPrtPprIdDerivNo = reader.ReadInt32();
			//帳票使用区分
			temp.PrintPaperUseDivcd = reader.ReadInt32();
			//帳票区分コード
			temp.PrintPaperDivCd = reader.ReadInt32();
			//抽出プログラムID
			temp.ExtractionPgId = reader.ReadString();
			//抽出プログラムクラスID
			temp.ExtractionPgClassId = reader.ReadString();
			//出力プログラムID
			temp.OutputPgId = reader.ReadString();
			//出力プログラムクラスID
			temp.OutputPgClassId = reader.ReadString();
			//出力確認メッセージ
			temp.OutConfimationMsg = reader.ReadString();
			//出力名称
			temp.DisplayName = reader.ReadString();
			//帳票ユーザー枝番コメント
			temp.PrtPprUserDerivNoCmt = reader.ReadString();
			//印字位置バージョン
			temp.PrintPositionVer = reader.ReadInt32();
			//マージ可能印字位置バージョン
			temp.MergeablePrintPosVer = reader.ReadInt32();
			//データ入力システム
			temp.DataInputSystem = reader.ReadInt32();
			//オプションコード
			temp.OptionCode = reader.ReadString();
			//自由帳票項目グループコード
			temp.FreePrtPprItemGrpCd = reader.ReadInt32();
			//改頁行数
			temp.FormFeedLineCount = reader.ReadInt32();
			//端文字処理区分
			temp.EdgeCharProcDivCd = reader.ReadInt32();
			//帳票背景画像縦位置
			temp.PrtPprBgImageRowPos = reader.ReadDouble();
			//帳票背景画像横位置
			temp.PrtPprBgImageColPos = reader.ReadDouble();
			//取込画像グループコード
			int lenOfTakeInImageGroupCdArray = reader.ReadInt32();
			byte[] takeInImageGroupCdArray = reader.ReadBytes(lenOfTakeInImageGroupCdArray);
			temp.TakeInImageGroupCd = new Guid(takeInImageGroupCdArray);
			//抽出拠点種別区分
			temp.ExtraSectionKindCd = reader.ReadInt32();
			//抽出拠点選択有無
			temp.ExtraSectionSelExist = reader.ReadInt32();
			//明細背景色(R)
			temp.RDetailBackColor = reader.ReadInt32();
			//明細背景色(G)
			temp.GDetailBackColor = reader.ReadInt32();
			//明細背景色(B)
			temp.BDetailBackColor = reader.ReadInt32();
			//改行文字数
			temp.CrCharCnt = reader.ReadInt32();
			//自由帳票 特種用途区分
			temp.FreePrtPprSpPrpseCd = reader.ReadInt32();
			//印字位置クラスデータ


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
		/// <returns>FrePrtPSetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   FrePrtPSetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				FrePrtPSetWork temp = GetFrePrtPSetWork(reader, serInfo);
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
					retValue = (FrePrtPSetWork[])lst.ToArray(typeof(FrePrtPSetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}
}
