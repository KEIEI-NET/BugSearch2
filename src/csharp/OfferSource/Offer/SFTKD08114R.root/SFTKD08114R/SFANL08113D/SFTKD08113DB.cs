using System;
using System.Collections;

using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   PrtItemSetWork
	/// <summary>
	///                      印字項目設定ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   印字項目設定ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2007/03/15</br>
	/// <br>Genarated Date   :   2007/10/12  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
	/// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class PrtItemSetWork : IFileHeaderOffer
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

		/// <summary>自由帳票項目グループコード</summary>
		private Int32 _freePrtPprItemGrpCd;

		/// <summary>自由帳票項目コード</summary>
		/// <remarks>1～100:ActiveReport用,101～:.NS用</remarks>
		private Int32 _freePrtPaperItemCd;

		/// <summary>自由帳票項目名称</summary>
		private string _freePrtPaperItemNm = "";

		/// <summary>ファイル名称</summary>
		/// <remarks>DBのテーブルID</remarks>
		private string _fileNm = "";

		/// <summary>DD桁数</summary>
		private Int32 _dDCharCnt;

		/// <summary>DD名称</summary>
		/// <remarks>小文字で登録</remarks>
		private string _dDName = "";

		/// <summary>レポートコントロール区分</summary>
		/// <remarks>1:TextBox,2:Label,3:Picture,4:Shape,5:Line,6:BarCode</remarks>
		private Int32 _reportControlCode;

		/// <summary>ヘッダー使用区分</summary>
		/// <remarks>0:使用不可,1:使用可</remarks>
		private Int32 _headerUseDivCd;

		/// <summary>明細使用区分</summary>
		/// <remarks>0:使用不可,1:使用可</remarks>
		private Int32 _detailUseDivCd;

		/// <summary>フッター使用区分</summary>
		/// <remarks>0:使用不可,1:使用可</remarks>
		private Int32 _footerUseDivCd;

		/// <summary>抽出条件区分</summary>
		/// <remarks>0:使用不可,1:数値型,2:文字型（半角）,3:文字型（全角）,4:日付型,5:コンボ型,6:チェック型</remarks>
		private Int32 _extraConditionDivCd;

		/// <summary>抽出条件タイプ</summary>
		/// <remarks>0:一致,1:範囲,2:あいまい,3:期間</remarks>
		private Int32 _extraConditionTypeCd;

		/// <summary>カンマ編集有無</summary>
		/// <remarks>0:なし,1:"#,###",2:"#,##0",3:"0.0",4:"0.00"</remarks>
		private Int32 _commaEditExistCd;

		/// <summary>印字ページ制御区分</summary>
		/// <remarks>0:全ページ,1:1ページ目のみ,2:最終ページのみ</remarks>
		private Int32 _printPageCtrlDivCd;

		/// <summary>システム区分</summary>
		/// <remarks>0:共通,1:SF,2:BK,3:SH</remarks>
		private Int32 _systemDivCd;

		/// <summary>オプションコード</summary>
		/// <remarks>ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ</remarks>
		private string _optionCode = "";

		/// <summary>抽出条件明細グループコード</summary>
		/// <remarks>抽出条件区分がコンボボックス型の時に使用</remarks>
		private Int32 _extraCondDetailGrpCd;

		/// <summary>集計項目区分</summary>
		/// <remarks>0:使用不可,1:使用可</remarks>
		private Int32 _totalItemDivCd;

		/// <summary>改頁項目区分</summary>
		/// <remarks>0:使用不可,1:使用可</remarks>
		private Int32 _formFeedItemDivCd;

		/// <summary>自由帳票表示グループコード</summary>
		/// <remarks>1:得意先情報,2:車両系情報,3:金額系情報,4:自社情報</remarks>
		private Int32 _freePrtPprDispGrpCd;

		/// <summary>必須抽出条件区分</summary>
		/// <remarks>0:任意,1:必須</remarks>
		private Int32 _necessaryExtraCondCd;

		/// <summary>暗号化フラグ</summary>
		/// <remarks>0:暗号化無,1:暗号化有</remarks>
		private Int32 _cipherFlg;

		/// <summary>抽出対象フラグ</summary>
		/// <remarks>0:非対象,1:対象</remarks>
		private Int32 _extractionItdedFlg;

		/// <summary>グループサプレス区分</summary>
		/// <remarks>0:なし,1:あり</remarks>
		private Int32 _groupSuppressCd;

		/// <summary>明細色変更区分</summary>
		/// <remarks>0:非対象,1:対象</remarks>
		private Int32 _dtlColorChangeCd;

		/// <summary>高さ調整区分</summary>
		/// <remarks>0:非対象,1:対象</remarks>
		private Int32 _heightAdjustDivCd;

		/// <summary>追加項目使用区分</summary>
		/// <remarks>0:使用不可,1:使用可</remarks>
		private Int32 _addItemUseDivCd;

		/// <summary>入力桁数</summary>
		/// <remarks>条件の入力制限で使用</remarks>
		private Int32 _inputCharCnt;

		/// <summary>バーコードスタイル</summary>
		/// <remarks>1:Code_128_A,2:JapanesePostal,3:QRCode</remarks>
		private Int32 _barCodeStyle;


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

		/// public propaty name  :  FreePrtPaperItemCd
		/// <summary>自由帳票項目コードプロパティ</summary>
		/// <value>1～100:ActiveReport用,101～:.NS用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票項目コードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPaperItemCd
		{
			get { return _freePrtPaperItemCd; }
			set { _freePrtPaperItemCd = value; }
		}

		/// public propaty name  :  FreePrtPaperItemNm
		/// <summary>自由帳票項目名称プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票項目名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FreePrtPaperItemNm
		{
			get { return _freePrtPaperItemNm; }
			set { _freePrtPaperItemNm = value; }
		}

		/// public propaty name  :  FileNm
		/// <summary>ファイル名称プロパティ</summary>
		/// <value>DBのテーブルID</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ファイル名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string FileNm
		{
			get { return _fileNm; }
			set { _fileNm = value; }
		}

		/// public propaty name  :  DDCharCnt
		/// <summary>DD桁数プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DD桁数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DDCharCnt
		{
			get { return _dDCharCnt; }
			set { _dDCharCnt = value; }
		}

		/// public propaty name  :  DDName
		/// <summary>DD名称プロパティ</summary>
		/// <value>小文字で登録</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   DD名称プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string DDName
		{
			get { return _dDName; }
			set { _dDName = value; }
		}

		/// public propaty name  :  ReportControlCode
		/// <summary>レポートコントロール区分プロパティ</summary>
		/// <value>1:TextBox,2:Label,3:Picture,4:Shape,5:Line,6:BarCode</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   レポートコントロール区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ReportControlCode
		{
			get { return _reportControlCode; }
			set { _reportControlCode = value; }
		}

		/// public propaty name  :  HeaderUseDivCd
		/// <summary>ヘッダー使用区分プロパティ</summary>
		/// <value>0:使用不可,1:使用可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   ヘッダー使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 HeaderUseDivCd
		{
			get { return _headerUseDivCd; }
			set { _headerUseDivCd = value; }
		}

		/// public propaty name  :  DetailUseDivCd
		/// <summary>明細使用区分プロパティ</summary>
		/// <value>0:使用不可,1:使用可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DetailUseDivCd
		{
			get { return _detailUseDivCd; }
			set { _detailUseDivCd = value; }
		}

		/// public propaty name  :  FooterUseDivCd
		/// <summary>フッター使用区分プロパティ</summary>
		/// <value>0:使用不可,1:使用可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   フッター使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FooterUseDivCd
		{
			get { return _footerUseDivCd; }
			set { _footerUseDivCd = value; }
		}

		/// public propaty name  :  ExtraConditionDivCd
		/// <summary>抽出条件区分プロパティ</summary>
		/// <value>0:使用不可,1:数値型,2:文字型（半角）,3:文字型（全角）,4:日付型,5:コンボ型,6:チェック型</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出条件区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtraConditionDivCd
		{
			get { return _extraConditionDivCd; }
			set { _extraConditionDivCd = value; }
		}

		/// public propaty name  :  ExtraConditionTypeCd
		/// <summary>抽出条件タイププロパティ</summary>
		/// <value>0:一致,1:範囲,2:あいまい,3:期間</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出条件タイププロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtraConditionTypeCd
		{
			get { return _extraConditionTypeCd; }
			set { _extraConditionTypeCd = value; }
		}

		/// public propaty name  :  CommaEditExistCd
		/// <summary>カンマ編集有無プロパティ</summary>
		/// <value>0:なし,1:"#,###",2:"#,##0",3:"0.0",4:"0.00"</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   カンマ編集有無プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CommaEditExistCd
		{
			get { return _commaEditExistCd; }
			set { _commaEditExistCd = value; }
		}

		/// public propaty name  :  PrintPageCtrlDivCd
		/// <summary>印字ページ制御区分プロパティ</summary>
		/// <value>0:全ページ,1:1ページ目のみ,2:最終ページのみ</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   印字ページ制御区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 PrintPageCtrlDivCd
		{
			get { return _printPageCtrlDivCd; }
			set { _printPageCtrlDivCd = value; }
		}

		/// public propaty name  :  SystemDivCd
		/// <summary>システム区分プロパティ</summary>
		/// <value>0:共通,1:SF,2:BK,3:SH</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   システム区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SystemDivCd
		{
			get { return _systemDivCd; }
			set { _systemDivCd = value; }
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

		/// public propaty name  :  ExtraCondDetailGrpCd
		/// <summary>抽出条件明細グループコードプロパティ</summary>
		/// <value>抽出条件区分がコンボボックス型の時に使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出条件明細グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtraCondDetailGrpCd
		{
			get { return _extraCondDetailGrpCd; }
			set { _extraCondDetailGrpCd = value; }
		}

		/// public propaty name  :  TotalItemDivCd
		/// <summary>集計項目区分プロパティ</summary>
		/// <value>0:使用不可,1:使用可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   集計項目区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 TotalItemDivCd
		{
			get { return _totalItemDivCd; }
			set { _totalItemDivCd = value; }
		}

		/// public propaty name  :  FormFeedItemDivCd
		/// <summary>改頁項目区分プロパティ</summary>
		/// <value>0:使用不可,1:使用可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   改頁項目区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FormFeedItemDivCd
		{
			get { return _formFeedItemDivCd; }
			set { _formFeedItemDivCd = value; }
		}

		/// public propaty name  :  FreePrtPprDispGrpCd
		/// <summary>自由帳票表示グループコードプロパティ</summary>
		/// <value>1:得意先情報,2:車両系情報,3:金額系情報,4:自社情報</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   自由帳票表示グループコードプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 FreePrtPprDispGrpCd
		{
			get { return _freePrtPprDispGrpCd; }
			set { _freePrtPprDispGrpCd = value; }
		}

		/// public propaty name  :  NecessaryExtraCondCd
		/// <summary>必須抽出条件区分プロパティ</summary>
		/// <value>0:任意,1:必須</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   必須抽出条件区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 NecessaryExtraCondCd
		{
			get { return _necessaryExtraCondCd; }
			set { _necessaryExtraCondCd = value; }
		}

		/// public propaty name  :  CipherFlg
		/// <summary>暗号化フラグプロパティ</summary>
		/// <value>0:暗号化無,1:暗号化有</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   暗号化フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 CipherFlg
		{
			get { return _cipherFlg; }
			set { _cipherFlg = value; }
		}

		/// public propaty name  :  ExtractionItdedFlg
		/// <summary>抽出対象フラグプロパティ</summary>
		/// <value>0:非対象,1:対象</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   抽出対象フラグプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 ExtractionItdedFlg
		{
			get { return _extractionItdedFlg; }
			set { _extractionItdedFlg = value; }
		}

		/// public propaty name  :  GroupSuppressCd
		/// <summary>グループサプレス区分プロパティ</summary>
		/// <value>0:なし,1:あり</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   グループサプレス区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 GroupSuppressCd
		{
			get { return _groupSuppressCd; }
			set { _groupSuppressCd = value; }
		}

		/// public propaty name  :  DtlColorChangeCd
		/// <summary>明細色変更区分プロパティ</summary>
		/// <value>0:非対象,1:対象</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   明細色変更区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 DtlColorChangeCd
		{
			get { return _dtlColorChangeCd; }
			set { _dtlColorChangeCd = value; }
		}

		/// public propaty name  :  HeightAdjustDivCd
		/// <summary>高さ調整区分プロパティ</summary>
		/// <value>0:非対象,1:対象</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   高さ調整区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 HeightAdjustDivCd
		{
			get { return _heightAdjustDivCd; }
			set { _heightAdjustDivCd = value; }
		}

		/// public propaty name  :  AddItemUseDivCd
		/// <summary>追加項目使用区分プロパティ</summary>
		/// <value>0:使用不可,1:使用可</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   追加項目使用区分プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 AddItemUseDivCd
		{
			get { return _addItemUseDivCd; }
			set { _addItemUseDivCd = value; }
		}

		/// public propaty name  :  InputCharCnt
		/// <summary>入力桁数プロパティ</summary>
		/// <value>条件の入力制限で使用</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   入力桁数プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 InputCharCnt
		{
			get { return _inputCharCnt; }
			set { _inputCharCnt = value; }
		}

		/// public propaty name  :  BarCodeStyle
		/// <summary>バーコードスタイルプロパティ</summary>
		/// <value>1:Code_128_A,2:JapanesePostal,3:QRCode</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   バーコードスタイルプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 BarCodeStyle
		{
			get { return _barCodeStyle; }
			set { _barCodeStyle = value; }
		}


		/// <summary>
		/// 印字項目設定ワークコンストラクタ
		/// </summary>
		/// <returns>PrtItemSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrtItemSetWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public PrtItemSetWork()
		{
		}

	}

	/// <summary>
	///  Ver5.10.1.0用のカスタムシライアライザです。
	/// </summary>
	/// <returns>PrtItemSetWorkクラスのインスタンス(object)</returns>
	/// <remarks>
	/// <br>Note　　　　　　 :   PrtItemSetWorkクラスのカスタムシリアライザを定義します</br>
	/// <br>Programer        :   自動生成</br>
	/// </remarks>
	public class PrtItemSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
	{
		#region ICustomSerializationSurrogate メンバ

		/// <summary>
		///  Ver5.10.1.0用のカスタムシリアライザです
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrtItemSetWorkクラスのカスタムシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public void Serialize(System.IO.BinaryWriter writer, object graph)
		{
			// TODO:  PrtItemSetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
			if (writer == null)
				throw new ArgumentNullException();

			if (graph != null && !(graph is PrtItemSetWork || graph is ArrayList || graph is PrtItemSetWork[]))
				throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(PrtItemSetWork).FullName));

			if (graph != null && graph is PrtItemSetWork)
			{
				Type t = graph.GetType();
				if (!CustomFormatterServices.NeedCustomSerialization(t))
					throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
			}

			//SerializationTypeInfo
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.PrtItemSetWork");

			//繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
			int occurrence = 0;     //一般にゼロの場合もありえます
			if (graph is ArrayList)
			{
				serInfo.RetTypeInfo = 0;
				occurrence = ((ArrayList)graph).Count;
			}
			else if (graph is PrtItemSetWork[])
			{
				serInfo.RetTypeInfo = 2;
				occurrence = ((PrtItemSetWork[])graph).Length;
			}
			else if (graph is PrtItemSetWork)
			{
				serInfo.RetTypeInfo = 1;
				occurrence = 1;
			}

			serInfo.Occurrence = occurrence;		 //繰り返し数	

			//作成日時
			serInfo.MemberInfo.Add(typeof(Int64)); //CreateDateTime
			//更新日時
			serInfo.MemberInfo.Add(typeof(Int64)); //UpdateDateTime
			//論理削除区分
			serInfo.MemberInfo.Add(typeof(Int32)); //LogicalDeleteCode
			//自由帳票項目グループコード
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprItemGrpCd
			//自由帳票項目コード
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPaperItemCd
			//自由帳票項目名称
			serInfo.MemberInfo.Add(typeof(string)); //FreePrtPaperItemNm
			//ファイル名称
			serInfo.MemberInfo.Add(typeof(string)); //FileNm
			//DD桁数
			serInfo.MemberInfo.Add(typeof(Int32)); //DDCharCnt
			//DD名称
			serInfo.MemberInfo.Add(typeof(string)); //DDName
			//レポートコントロール区分
			serInfo.MemberInfo.Add(typeof(Int32)); //ReportControlCode
			//ヘッダー使用区分
			serInfo.MemberInfo.Add(typeof(Int32)); //HeaderUseDivCd
			//明細使用区分
			serInfo.MemberInfo.Add(typeof(Int32)); //DetailUseDivCd
			//フッター使用区分
			serInfo.MemberInfo.Add(typeof(Int32)); //FooterUseDivCd
			//抽出条件区分
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraConditionDivCd
			//抽出条件タイプ
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraConditionTypeCd
			//カンマ編集有無
			serInfo.MemberInfo.Add(typeof(Int32)); //CommaEditExistCd
			//印字ページ制御区分
			serInfo.MemberInfo.Add(typeof(Int32)); //PrintPageCtrlDivCd
			//システム区分
			serInfo.MemberInfo.Add(typeof(Int32)); //SystemDivCd
			//オプションコード
			serInfo.MemberInfo.Add(typeof(string)); //OptionCode
			//抽出条件明細グループコード
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtraCondDetailGrpCd
			//集計項目区分
			serInfo.MemberInfo.Add(typeof(Int32)); //TotalItemDivCd
			//改頁項目区分
			serInfo.MemberInfo.Add(typeof(Int32)); //FormFeedItemDivCd
			//自由帳票表示グループコード
			serInfo.MemberInfo.Add(typeof(Int32)); //FreePrtPprDispGrpCd
			//必須抽出条件区分
			serInfo.MemberInfo.Add(typeof(Int32)); //NecessaryExtraCondCd
			//暗号化フラグ
			serInfo.MemberInfo.Add(typeof(Int32)); //CipherFlg
			//抽出対象フラグ
			serInfo.MemberInfo.Add(typeof(Int32)); //ExtractionItdedFlg
			//グループサプレス区分
			serInfo.MemberInfo.Add(typeof(Int32)); //GroupSuppressCd
			//明細色変更区分
			serInfo.MemberInfo.Add(typeof(Int32)); //DtlColorChangeCd
			//高さ調整区分
			serInfo.MemberInfo.Add(typeof(Int32)); //HeightAdjustDivCd
			//追加項目使用区分
			serInfo.MemberInfo.Add(typeof(Int32)); //AddItemUseDivCd
			//入力桁数
			serInfo.MemberInfo.Add(typeof(Int32)); //InputCharCnt
			//バーコードスタイル
			serInfo.MemberInfo.Add(typeof(Int32)); //BarCodeStyle


			serInfo.Serialize(writer, serInfo);
			if (graph is PrtItemSetWork)
			{
				PrtItemSetWork temp = (PrtItemSetWork)graph;

				SetPrtItemSetWork(writer, temp);
			}
			else
			{
				ArrayList lst = null;
				if (graph is PrtItemSetWork[])
				{
					lst = new ArrayList();
					lst.AddRange((PrtItemSetWork[])graph);
				}
				else
				{
					lst = (ArrayList)graph;
				}

				foreach (PrtItemSetWork temp in lst)
				{
					SetPrtItemSetWork(writer, temp);
				}

			}


		}


		/// <summary>
		/// PrtItemSetWorkメンバ数(publicプロパティ数)
		/// </summary>
		private const int currentMemberCount = 32;

		/// <summary>
		///  PrtItemSetWorkインスタンス書き込み
		/// </summary>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrtItemSetWorkのインスタンスを書き込み</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private void SetPrtItemSetWork(System.IO.BinaryWriter writer, PrtItemSetWork temp)
		{
			//作成日時
			writer.Write((Int64)temp.CreateDateTime.Ticks);
			//更新日時
			writer.Write((Int64)temp.UpdateDateTime.Ticks);
			//論理削除区分
			writer.Write(temp.LogicalDeleteCode);
			//自由帳票項目グループコード
			writer.Write(temp.FreePrtPprItemGrpCd);
			//自由帳票項目コード
			writer.Write(temp.FreePrtPaperItemCd);
			//自由帳票項目名称
			writer.Write(temp.FreePrtPaperItemNm);
			//ファイル名称
			writer.Write(temp.FileNm);
			//DD桁数
			writer.Write(temp.DDCharCnt);
			//DD名称
			writer.Write(temp.DDName);
			//レポートコントロール区分
			writer.Write(temp.ReportControlCode);
			//ヘッダー使用区分
			writer.Write(temp.HeaderUseDivCd);
			//明細使用区分
			writer.Write(temp.DetailUseDivCd);
			//フッター使用区分
			writer.Write(temp.FooterUseDivCd);
			//抽出条件区分
			writer.Write(temp.ExtraConditionDivCd);
			//抽出条件タイプ
			writer.Write(temp.ExtraConditionTypeCd);
			//カンマ編集有無
			writer.Write(temp.CommaEditExistCd);
			//印字ページ制御区分
			writer.Write(temp.PrintPageCtrlDivCd);
			//システム区分
			writer.Write(temp.SystemDivCd);
			//オプションコード
			writer.Write(temp.OptionCode);
			//抽出条件明細グループコード
			writer.Write(temp.ExtraCondDetailGrpCd);
			//集計項目区分
			writer.Write(temp.TotalItemDivCd);
			//改頁項目区分
			writer.Write(temp.FormFeedItemDivCd);
			//自由帳票表示グループコード
			writer.Write(temp.FreePrtPprDispGrpCd);
			//必須抽出条件区分
			writer.Write(temp.NecessaryExtraCondCd);
			//暗号化フラグ
			writer.Write(temp.CipherFlg);
			//抽出対象フラグ
			writer.Write(temp.ExtractionItdedFlg);
			//グループサプレス区分
			writer.Write(temp.GroupSuppressCd);
			//明細色変更区分
			writer.Write(temp.DtlColorChangeCd);
			//高さ調整区分
			writer.Write(temp.HeightAdjustDivCd);
			//追加項目使用区分
			writer.Write(temp.AddItemUseDivCd);
			//入力桁数
			writer.Write(temp.InputCharCnt);
			//バーコードスタイル
			writer.Write(temp.BarCodeStyle);

		}

		/// <summary>
		///  PrtItemSetWorkインスタンス取得
		/// </summary>
		/// <returns>PrtItemSetWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrtItemSetWorkのインスタンスを取得します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		private PrtItemSetWork GetPrtItemSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
		{
			// V5.1.0.0なので不要ですが、V5.1.0.1以降では
			// serInfo.MemberInfo.Count < currentMemberCount
			// のケースについての配慮が必要になります。

			PrtItemSetWork temp = new PrtItemSetWork();

			//作成日時
			temp.CreateDateTime = new DateTime(reader.ReadInt64());
			//更新日時
			temp.UpdateDateTime = new DateTime(reader.ReadInt64());
			//論理削除区分
			temp.LogicalDeleteCode = reader.ReadInt32();
			//自由帳票項目グループコード
			temp.FreePrtPprItemGrpCd = reader.ReadInt32();
			//自由帳票項目コード
			temp.FreePrtPaperItemCd = reader.ReadInt32();
			//自由帳票項目名称
			temp.FreePrtPaperItemNm = reader.ReadString();
			//ファイル名称
			temp.FileNm = reader.ReadString();
			//DD桁数
			temp.DDCharCnt = reader.ReadInt32();
			//DD名称
			temp.DDName = reader.ReadString();
			//レポートコントロール区分
			temp.ReportControlCode = reader.ReadInt32();
			//ヘッダー使用区分
			temp.HeaderUseDivCd = reader.ReadInt32();
			//明細使用区分
			temp.DetailUseDivCd = reader.ReadInt32();
			//フッター使用区分
			temp.FooterUseDivCd = reader.ReadInt32();
			//抽出条件区分
			temp.ExtraConditionDivCd = reader.ReadInt32();
			//抽出条件タイプ
			temp.ExtraConditionTypeCd = reader.ReadInt32();
			//カンマ編集有無
			temp.CommaEditExistCd = reader.ReadInt32();
			//印字ページ制御区分
			temp.PrintPageCtrlDivCd = reader.ReadInt32();
			//システム区分
			temp.SystemDivCd = reader.ReadInt32();
			//オプションコード
			temp.OptionCode = reader.ReadString();
			//抽出条件明細グループコード
			temp.ExtraCondDetailGrpCd = reader.ReadInt32();
			//集計項目区分
			temp.TotalItemDivCd = reader.ReadInt32();
			//改頁項目区分
			temp.FormFeedItemDivCd = reader.ReadInt32();
			//自由帳票表示グループコード
			temp.FreePrtPprDispGrpCd = reader.ReadInt32();
			//必須抽出条件区分
			temp.NecessaryExtraCondCd = reader.ReadInt32();
			//暗号化フラグ
			temp.CipherFlg = reader.ReadInt32();
			//抽出対象フラグ
			temp.ExtractionItdedFlg = reader.ReadInt32();
			//グループサプレス区分
			temp.GroupSuppressCd = reader.ReadInt32();
			//明細色変更区分
			temp.DtlColorChangeCd = reader.ReadInt32();
			//高さ調整区分
			temp.HeightAdjustDivCd = reader.ReadInt32();
			//追加項目使用区分
			temp.AddItemUseDivCd = reader.ReadInt32();
			//入力桁数
			temp.InputCharCnt = reader.ReadInt32();
			//バーコードスタイル
			temp.BarCodeStyle = reader.ReadInt32();


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
		/// <returns>PrtItemSetWorkクラスのインスタンス(object)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   PrtItemSetWorkクラスのカスタムデシリアライザを定義します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public object Deserialize(System.IO.BinaryReader reader)
		{
			object retValue = null;
			Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
			ArrayList lst = new ArrayList();
			for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
			{
				PrtItemSetWork temp = GetPrtItemSetWork(reader, serInfo);
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
					retValue = (PrtItemSetWork[])lst.ToArray(typeof(PrtItemSetWork));
					break;
			}
			return retValue;
		}

		#endregion
	}

}
