using System;
using System.IO;
using System.Drawing;
using System.Collections;

namespace Broadleaf.Application.UIData
{
	/// public class name:	FrePrtExport
	/// <summary>
	///                      自由帳票Exportクラス
	/// </summary>
	/// <remarks>
	/// <br>note			:	自由帳票Exportクラスヘッダファイル</br>
	/// <br>Programmer		:	自動生成</br>
	/// <br>Date			:	2007/11/06</br>
	/// <br>Genarated Date	:	2007/11/06  (CSharp File Generated Date)</br>
	/// <br></br>
	/// <br>Update Note		:	</br>
	/// </remarks>
	public class FrePrtExport
	{
		#region Const
		/// <summary>エクスポートファイル名</summary>
		public const string ctExportFileName = "FREPRTPSETEXPORT.xml";
		#endregion

		#region PrivateMember
		/// <summary>企業コード</summary>
		/// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
		private string _enterpriseCode = "";

		/// <summary>出力ファイル名</summary>
		/// <remarks>フォームファイルID or フォーマットファイルID</remarks>
		private string _outputFormFileName = "";

		/// <summary>ユーザー帳票ID枝番号</summary>
		private Int32 _userPrtPprIdDerivNo;

		/// <summary>出力名称</summary>
		/// <remarks>ガイド等に表示する名称</remarks>
		private string _displayName = "";

		/// <summary>帳票ユーザー枝番コメント</summary>
		private string _prtPprUserDerivNoCmt = "";

		/// <summary>エクスポートデータファイルパス</summary>
		private string _exportDataFilePath = "";

		/// <summary>データ入力システム</summary>
		/// <remarks>0:共通,1:整備,2:鈑金,3:車販</remarks>
		private Int32 _dataInputSystem;

		/// <summary>帳票使用区分</summary>
		/// <remarks>1:帳票,2:伝票,3:DM一覧表,4:DMはがき</remarks>
		private Int32 _printPaperUseDivcd;

		/// <summary>備考</summary>
		private string _note = "";

		/// <summary>伝票種別登録区分1</summary>
		/// <remarks>伝票登録時に使用（伝票種別:10）</remarks>
		private Int32 _slipKindEntryDiv1;

		/// <summary>伝票種別登録区分2</summary>
		/// <remarks>伝票登録時に使用（伝票種別:20）</remarks>
		private Int32 _slipKindEntryDiv2;

		/// <summary>伝票種別登録区分3</summary>
		/// <remarks>伝票登録時に使用（伝票種別:21）</remarks>
		private Int32 _slipKindEntryDiv3;

		/// <summary>伝票種別登録区分4</summary>
		/// <remarks>伝票登録時に使用（伝票種別:30）</remarks>
		private Int32 _slipKindEntryDiv4;

		/// <summary>抽出対象フラグ</summary>
		/// <remarks>0:非対象,1:対象</remarks>
		private Int32 _extractionItdedFlg;

		/// <summary>伝票印刷種別</summary>
		/// <remarks>10:見積書,20:指示書（注文書）,21:承り書,30:納品書,100:ワークシート,110:ボディ寸法図</remarks>
		private Int32 _slipPrtKind;

		/// <summary>帳票背景画像データ</summary>
		private Byte[] _printPprBgImageData;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
        /// <summary>自由帳票印刷項目グループコード</summary>
        private Int32 _freePrtPprItemGrpCd;
        /// <summary>自由帳票特殊用途コード</summary>
        private Int32 _freePrtPprSpPrpseCd;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
		#endregion

		#region Property
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

		/// public propaty name  :  ExportDataFilePath
		/// <summary>エクスポートデータファイルパスプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   エクスポートデータファイルパスプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string ExportDataFilePath
		{
			get { return _exportDataFilePath; }
			set { _exportDataFilePath = value; }
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

		/// public propaty name  :  Note
		/// <summary>備考プロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   備考プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public string Note
		{
			get { return _note; }
			set { _note = value; }
		}

		/// public propaty name  :  SlipKindEntryDiv1
		/// <summary>伝票種別登録区分1プロパティ</summary>
		/// <value>伝票登録時に使用（伝票種別:10）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票種別登録区分1プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipKindEntryDiv1
		{
			get { return _slipKindEntryDiv1; }
			set { _slipKindEntryDiv1 = value; }
		}

		/// public propaty name  :  SlipKindEntryDiv2
		/// <summary>伝票種別登録区分2プロパティ</summary>
		/// <value>伝票登録時に使用（伝票種別:20）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票種別登録区分2プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipKindEntryDiv2
		{
			get { return _slipKindEntryDiv2; }
			set { _slipKindEntryDiv2 = value; }
		}

		/// public propaty name  :  SlipKindEntryDiv3
		/// <summary>伝票種別登録区分3プロパティ</summary>
		/// <value>伝票登録時に使用（伝票種別:21）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票種別登録区分3プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipKindEntryDiv3
		{
			get { return _slipKindEntryDiv3; }
			set { _slipKindEntryDiv3 = value; }
		}

		/// public propaty name  :  SlipKindEntryDiv4
		/// <summary>伝票種別登録区分4プロパティ</summary>
		/// <value>伝票登録時に使用（伝票種別:30）</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票種別登録区分4プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipKindEntryDiv4
		{
			get { return _slipKindEntryDiv4; }
			set { _slipKindEntryDiv4 = value; }
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

		/// public propaty name  :  SlipPrtKind
		/// <summary>伝票印刷種別プロパティ</summary>
		/// <value>10:見積書,20:指示書（注文書）,21:承り書,30:納品書,100:ワークシート,110:ボディ寸法図</value>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   伝票印刷種別プロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Int32 SlipPrtKind
		{
			get { return _slipPrtKind; }
			set { _slipPrtKind = value; }
		}

		/// public propaty name  :  PrintPprBgImageData
		/// <summary>帳票背景画像データプロパティ</summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>note             :   帳票背景画像データプロパティ</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public Byte[] PrintPprBgImageData
		{
			get { return _printPprBgImageData; }
			set { _printPprBgImageData = value; }
		}

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/02 ADD
        /// public propaty name  :  FreePrtPprItemGrpCd
        /// <summary>自由帳票印刷項目グループコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由帳票印刷項目グループコードプロパティ</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public Int32 FreePrtPprItemGrpCd
        {
            get { return _freePrtPprItemGrpCd; }
            set { _freePrtPprItemGrpCd = value; }
        }
        /// public propaty name  :  FreePrtPprSpPrpseCd
        /// <summary>自由帳票特殊用途コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   自由帳票特殊用途コードプロパティ</br>
        /// <br>Programer        :   </br>
        /// </remarks>
        public Int32 FreePrtPprSpPrpseCd
        {
            get { return _freePrtPprSpPrpseCd; }
            set { _freePrtPprSpPrpseCd = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/02 ADD
		#endregion

		#region PublicMethod
		/// <summary>
		/// 帳票背景画像取得処理
		/// </summary>
		/// <returns>帳票背景画像</returns>
		public Image GetPrintPprBgImageDataImage()
		{
			MemoryStream stream = new MemoryStream(_printPprBgImageData);
			stream.Position = 0;
			return Image.FromStream(stream);
		}

		/// <summary>
		/// 帳票背景画像設定処理
		/// </summary>
		/// <param name="image">帳票背景画像</param>
		public void SetPrintPprBgImageDataImage(Image image)
		{
			_printPprBgImageData = null;
			MemoryStream stream = new MemoryStream();
			image.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
			_printPprBgImageData = stream.ToArray();
		}
		#endregion

		#region Constructor
		/// <summary>
		/// 自由帳票Exportクラスコンストラクタ
		/// </summary>
		/// <returns>FrePrtExportクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note			:	FrePrtExportクラスの新しいインスタンスを生成します</br>
		/// <br>Programer		:	自動生成</br>
		/// </remarks>
		public FrePrtExport()
		{
		}
		#endregion
	}
}
