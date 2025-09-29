using System;
using System.IO;
using System.Collections;
using System.Drawing;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   SFANL08230AF
    /// <summary>
    ///                      自由帳票印字位置DL画面データ
    /// </summary>
    /// <remarks>
    /// <br>note             :   自由帳票印字位置DL画面データヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/03/15</br>
    /// <br>Genarated Date   :   2007/06/12  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SFANL08230AF
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
        /// <remarks>1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票</remarks>
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
        /// <remarks>0:共通,1:SF,2:BK,3:SH</remarks>
        private Int32 _dataInputSystem;

        /// <summary>オプションコード</summary>
        /// <remarks>ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ</remarks>
        private string _optionCode = "";

        /// <summary>自由帳票項目グループコード</summary>
        private Int32 _freePrtPprItemGrpCd;

        /// <summary>帳票背景画像縦位置</summary>
        /// <remarks>Z9.9</remarks>
        private Double _prtPprBgImageRowPos;

        /// <summary>帳票背景画像横位置</summary>
        /// <remarks>Z9.9</remarks>
        private Double _prtPprBgImageColPos;

        /// <summary>印字位置クラスデータ</summary>
        private Byte[] _printPosClassData;

        /// <summary>帳票背景画像データ</summary>
        private Byte[] _printPprBgImageData;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>自由帳票項目グループ名称</summary>
        private string _freePrtPprItemGrpNm = "";

        /// <summary>キー番号</summary>
        private string _keyNo = "";

        /// <summary>更新フラグ</summary>
        private Int32 _updateFlag;

        /// <summary>既存フラグ</summary>
        private Int32 _existingFlag;

        /// <summary>取込画像グループコード</summary>
        /// <remarks>取込画像のグループ識別するためのGUID</remarks>
        private Guid _takeInImageGroupCd;
        /// <summary>自由帳票 特種用途区分　0:使用しない,1:案内文印刷タイプ,2:専用帳票,3:官製はがき</summary>
        private Int32 _FreePrtPprSpPrpseCd;
        


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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _createDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("GGYYMMDD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _updateDateTime); }
            set { }
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
            get { return TDateTime.DateTimeToString("YY/MM/DD", _updateDateTime); }
            set { }
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
        /// <value>1:帳票,2:伝票</value>
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
        /// <value>1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票</value>
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
        /// <value>0:共通,1:SF,2:BK,3:SH</value>
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

        /// public propaty field.NameJp  :  PrintPosClassDataImageObject
        /// <summary>印字位置クラスデータプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   印字位置クラスデータプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Image PrintPosClassDataImageObject
        {
            get
            {
                MemoryStream mem = new MemoryStream(_printPosClassData);
                mem.Position = 0;
                return Image.FromStream(mem);
            }
            set
            {
                _printPosClassData = null;
                MemoryStream mem = new MemoryStream();
                Image img = value;
                img.Save(mem, System.Drawing.Imaging.ImageFormat.Bmp);
                _printPosClassData = mem.ToArray();
            }
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

        /// public propaty field.NameJp  :  PrintPprBgImageDataImageObject
        /// <summary>帳票背景画像データプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   帳票背景画像データプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Image PrintPprBgImageDataImageObject
        {
            get
            {
                MemoryStream mem = new MemoryStream(_printPprBgImageData);
                mem.Position = 0;
                return Image.FromStream(mem);
            }
            set
            {
                _printPprBgImageData = null;
                MemoryStream mem = new MemoryStream();
                Image img = value;
                img.Save(mem, System.Drawing.Imaging.ImageFormat.Bmp);
                _printPprBgImageData = mem.ToArray();
            }
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
            get { return _enterpriseName; }
            set { _enterpriseName = value; }
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
            get { return _updEmployeeName; }
            set { _updEmployeeName = value; }
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
            get { return _freePrtPprItemGrpNm; }
            set { _freePrtPprItemGrpNm = value; }
        }

        /// public propaty name  :  KeyNo
        /// <summary>キー番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   キー番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string KeyNo
        {
            get { return _keyNo; }
            set { _keyNo = value; }
        }

        /// public propaty name  :  UpdateFlag
        /// <summary>更新フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UpdateFlag
        {
            get { return _updateFlag; }
            set { _updateFlag = value; }
        }

        /// public propaty name  :  ExistingDataFlag
        /// <summary>既存フラグプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   既存フラグプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ExistingDataFlag
        {
            get { return _existingFlag; }
            set { _existingFlag = value; }
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

        /// <summary>
        /// 自由帳票 特種用途区分プロパティ　0:使用しない,1:案内文印刷タイプ,2:専用帳票,3:官製はがき
        /// </summary>
        public Int32 FreePrtPprSpPrpseCd
        {
            get { return _FreePrtPprSpPrpseCd; }
            set { _FreePrtPprSpPrpseCd = value; }
        }


        /// <summary>
        /// 自由帳票印字位置DL画面データコンストラクタ
        /// </summary>
        /// <returns>SFANL08230AFクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SFANL08230AFクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SFANL08230AF()
        {
        }

        /// <summary>
        /// 自由帳票印字位置DL画面データコンストラクタ
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
        /// <param name="slipOrPrtPprDivCd">帳票使用区分(1:帳票,2:伝票)</param>
        /// <param name="printPaperDivCd">帳票区分コード(1:日次帳票,2:月次帳票,3:年次帳票,4:随時帳票)</param>
        /// <param name="extractionPgId">抽出プログラムID</param>
        /// <param name="extractionPgClassId">抽出プログラムクラスID(印刷プログラムID or テキスト出力プログラムID)</param>
        /// <param name="outputPgId">出力プログラムID</param>
        /// <param name="outputPgClassId">出力プログラムクラスID</param>
        /// <param name="outConfimationMsg">出力確認メッセージ</param>
        /// <param name="displayName">出力名称(ガイド等に表示する名称)</param>
        /// <param name="prtPprUserDerivNoCmt">帳票ユーザー枝番コメント</param>
        /// <param name="printPositionVer">印字位置バージョン</param>
        /// <param name="mergeablePrintPosVer">マージ可能印字位置バージョン</param>
        /// <param name="systemDivCd">データ入力システム(0:共通,1:SF,2:BK,3:SH)</param>
        /// <param name="optionCode">オプションコード(ｼｽﾃﾑ上のｵﾌﾟｼｮﾝｺｰﾄﾞ)</param>
        /// <param name="freePrtPprItemGrpCd">自由帳票項目グループコード</param>
        /// <param name="prtPprBgImageRowPos">帳票背景画像縦位置(Z9.9)</param>
        /// <param name="prtPprBgImageColPos">帳票背景画像横位置(Z9.9)</param>
        /// <param name="printPosClassData">印字位置クラスデータ</param>
        /// <param name="printPprBgImageData">帳票背景画像データ</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="freePrtPprItemGrpNm">自由帳票項目グループ名称</param>
        /// <param name="keyNo">キー番号</param>
        /// <param name="updateFlag">更新フラグ</param>
        /// <param name="existingFlag">既存フラグ</param>
        /// <param name="FreePrtPprSpPrpseCd">自由帳票 特殊用途区分</param>
        /// <param name="takeInImageGroupCd">取込画像グループコード(取込画像のグループ識別するためのGUID)</param>
        /// <returns>SFANL08230AFクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SFANL08230AFクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SFANL08230AF(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string outputFormFileName, Int32 userPrtPprIdDerivNo, Int32 slipOrPrtPprDivCd, Int32 printPaperDivCd, string extractionPgId, string extractionPgClassId, string outputPgId, string outputPgClassId, string outConfimationMsg, string displayName, string prtPprUserDerivNoCmt, Int32 printPositionVer, Int32 mergeablePrintPosVer, Int32 systemDivCd, string optionCode, Int32 freePrtPprItemGrpCd, Double prtPprBgImageRowPos, Double prtPprBgImageColPos, Byte[] printPosClassData, Byte[] printPprBgImageData, string enterpriseName, string updEmployeeName, string freePrtPprItemGrpNm, string keyNo, Int32 updateFlag, Int32 existingFlag, Guid takeInImageGroupCd, Int32 FreePrtPprSpPrpseCd)
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
            this._printPaperUseDivcd = slipOrPrtPprDivCd;
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
            this._dataInputSystem = systemDivCd;
            this._optionCode = optionCode;
            this._freePrtPprItemGrpCd = freePrtPprItemGrpCd;
            this._prtPprBgImageRowPos = prtPprBgImageRowPos;
            this._prtPprBgImageColPos = prtPprBgImageColPos;
            this._printPosClassData = printPosClassData;
            this._printPprBgImageData = printPprBgImageData;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._freePrtPprItemGrpNm = freePrtPprItemGrpNm;
            this._keyNo = keyNo;
            this._updateFlag = updateFlag;
            this._existingFlag = existingFlag;
            this._takeInImageGroupCd = takeInImageGroupCd;
            this._FreePrtPprSpPrpseCd = FreePrtPprSpPrpseCd;
        }

        /// <summary>
        /// 自由帳票印字位置DL画面データ複製処理
        /// </summary>
        /// <returns>SFANL08230AFクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいSFANL08230AFクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SFANL08230AF Clone()
        {
            return new SFANL08230AF(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._outputFormFileName, this._userPrtPprIdDerivNo, this._printPaperUseDivcd, this._printPaperDivCd, this._extractionPgId, this._extractionPgClassId, this._outputPgId, this._outputPgClassId, this._outConfimationMsg, this._displayName, this._prtPprUserDerivNoCmt, this._printPositionVer, this._mergeablePrintPosVer, this._dataInputSystem, this._optionCode, this._freePrtPprItemGrpCd, this._prtPprBgImageRowPos, this._prtPprBgImageColPos, this._printPosClassData, this._printPprBgImageData, this._enterpriseName, this._updEmployeeName, this._freePrtPprItemGrpNm, this._keyNo, this._updateFlag, this._existingFlag, this._takeInImageGroupCd, this._FreePrtPprSpPrpseCd);
        }

        /// <summary>
        /// 自由帳票印字位置DL画面データ比較処理
        /// </summary>
        /// <param name="target">比較対象のSFANL08230AFクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SFANL08230AFクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(SFANL08230AF target)
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
                 && (this.PrtPprBgImageRowPos == target.PrtPprBgImageRowPos)
                 && (this.PrtPprBgImageColPos == target.PrtPprBgImageColPos)
                 && (this.PrintPosClassData == target.PrintPosClassData)
                 && (this.PrintPprBgImageData == target.PrintPprBgImageData)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.FreePrtPprItemGrpNm == target.FreePrtPprItemGrpNm)
                 && (this.KeyNo == target.KeyNo)
                 && (this.UpdateFlag == target.UpdateFlag)
                 && (this.ExistingDataFlag == target.ExistingDataFlag)
                 && (this.TakeInImageGroupCd == target.TakeInImageGroupCd)
                 && (this.FreePrtPprSpPrpseCd == target.FreePrtPprSpPrpseCd));
        }

        /// <summary>
        /// 自由帳票印字位置DL画面データ比較処理
        /// </summary>
        /// <param name="sFANL08230AF1">
        ///                    比較するSFANL08230AFクラスのインスタンス
        /// </param>
        /// <param name="sFANL08230AF2">比較するSFANL08230AFクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SFANL08230AFクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(SFANL08230AF sFANL08230AF1, SFANL08230AF sFANL08230AF2)
        {
            return ((sFANL08230AF1.CreateDateTime == sFANL08230AF2.CreateDateTime)
                 && (sFANL08230AF1.UpdateDateTime == sFANL08230AF2.UpdateDateTime)
                 && (sFANL08230AF1.EnterpriseCode == sFANL08230AF2.EnterpriseCode)
                 && (sFANL08230AF1.FileHeaderGuid == sFANL08230AF2.FileHeaderGuid)
                 && (sFANL08230AF1.UpdEmployeeCode == sFANL08230AF2.UpdEmployeeCode)
                 && (sFANL08230AF1.UpdAssemblyId1 == sFANL08230AF2.UpdAssemblyId1)
                 && (sFANL08230AF1.UpdAssemblyId2 == sFANL08230AF2.UpdAssemblyId2)
                 && (sFANL08230AF1.LogicalDeleteCode == sFANL08230AF2.LogicalDeleteCode)
                 && (sFANL08230AF1.OutputFormFileName == sFANL08230AF2.OutputFormFileName)
                 && (sFANL08230AF1.UserPrtPprIdDerivNo == sFANL08230AF2.UserPrtPprIdDerivNo)
                 && (sFANL08230AF1.PrintPaperUseDivcd == sFANL08230AF2.PrintPaperUseDivcd)
                 && (sFANL08230AF1.PrintPaperDivCd == sFANL08230AF2.PrintPaperDivCd)
                 && (sFANL08230AF1.ExtractionPgId == sFANL08230AF2.ExtractionPgId)
                 && (sFANL08230AF1.ExtractionPgClassId == sFANL08230AF2.ExtractionPgClassId)
                 && (sFANL08230AF1.OutputPgId == sFANL08230AF2.OutputPgId)
                 && (sFANL08230AF1.OutputPgClassId == sFANL08230AF2.OutputPgClassId)
                 && (sFANL08230AF1.OutConfimationMsg == sFANL08230AF2.OutConfimationMsg)
                 && (sFANL08230AF1.DisplayName == sFANL08230AF2.DisplayName)
                 && (sFANL08230AF1.PrtPprUserDerivNoCmt == sFANL08230AF2.PrtPprUserDerivNoCmt)
                 && (sFANL08230AF1.PrintPositionVer == sFANL08230AF2.PrintPositionVer)
                 && (sFANL08230AF1.MergeablePrintPosVer == sFANL08230AF2.MergeablePrintPosVer)
                 && (sFANL08230AF1.DataInputSystem == sFANL08230AF2.DataInputSystem)
                 && (sFANL08230AF1.OptionCode == sFANL08230AF2.OptionCode)
                 && (sFANL08230AF1.FreePrtPprItemGrpCd == sFANL08230AF2.FreePrtPprItemGrpCd)
                 && (sFANL08230AF1.PrtPprBgImageRowPos == sFANL08230AF2.PrtPprBgImageRowPos)
                 && (sFANL08230AF1.PrtPprBgImageColPos == sFANL08230AF2.PrtPprBgImageColPos)
                 && (sFANL08230AF1.PrintPosClassData == sFANL08230AF2.PrintPosClassData)
                 && (sFANL08230AF1.PrintPprBgImageData == sFANL08230AF2.PrintPprBgImageData)
                 && (sFANL08230AF1.EnterpriseName == sFANL08230AF2.EnterpriseName)
                 && (sFANL08230AF1.UpdEmployeeName == sFANL08230AF2.UpdEmployeeName)
                 && (sFANL08230AF1.FreePrtPprItemGrpNm == sFANL08230AF2.FreePrtPprItemGrpNm)
                 && (sFANL08230AF1.KeyNo == sFANL08230AF2.KeyNo)
                 && (sFANL08230AF1.UpdateFlag == sFANL08230AF2.UpdateFlag)
                 && (sFANL08230AF1.ExistingDataFlag == sFANL08230AF2.ExistingDataFlag)
                 && (sFANL08230AF1.TakeInImageGroupCd == sFANL08230AF2.TakeInImageGroupCd)
                 && (sFANL08230AF1.FreePrtPprSpPrpseCd == sFANL08230AF2.FreePrtPprSpPrpseCd));
        }
        /// <summary>
        /// 自由帳票印字位置DL画面データ比較処理
        /// </summary>
        /// <param name="target">比較対象のSFANL08230AFクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SFANL08230AFクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(SFANL08230AF target)
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
            if (this.PrtPprBgImageRowPos != target.PrtPprBgImageRowPos) resList.Add("PrtPprBgImageRowPos");
            if (this.PrtPprBgImageColPos != target.PrtPprBgImageColPos) resList.Add("PrtPprBgImageColPos");
            if (this.PrintPosClassData != target.PrintPosClassData) resList.Add("PrintPosClassData");
            if (this.PrintPprBgImageData != target.PrintPprBgImageData) resList.Add("PrintPprBgImageData");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.FreePrtPprItemGrpNm != target.FreePrtPprItemGrpNm) resList.Add("FreePrtPprItemGrpNm");
            if (this.KeyNo != target.KeyNo) resList.Add("KeyNo");
            if (this.UpdateFlag != target.UpdateFlag) resList.Add("UpdateFlag");
            if (this.ExistingDataFlag != target.ExistingDataFlag) resList.Add("ExistingDataFlag");
            if (this.TakeInImageGroupCd != target.TakeInImageGroupCd) resList.Add("TakeInImageGroupCd");
            if (this.FreePrtPprSpPrpseCd != target.FreePrtPprSpPrpseCd) resList.Add("FreePrtPprSpPrpseCd");
            return resList;
        }

        /// <summary>
        /// 自由帳票印字位置DL画面データ比較処理
        /// </summary>
        /// <param name="sFANL08230AF1">比較するSFANL08230AFクラスのインスタンス</param>
        /// <param name="sFANL08230AF2">比較するSFANL08230AFクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SFANL08230AFクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(SFANL08230AF sFANL08230AF1, SFANL08230AF sFANL08230AF2)
        {
            ArrayList resList = new ArrayList();
            if (sFANL08230AF1.CreateDateTime != sFANL08230AF2.CreateDateTime) resList.Add("CreateDateTime");
            if (sFANL08230AF1.UpdateDateTime != sFANL08230AF2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (sFANL08230AF1.EnterpriseCode != sFANL08230AF2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (sFANL08230AF1.FileHeaderGuid != sFANL08230AF2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (sFANL08230AF1.UpdEmployeeCode != sFANL08230AF2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (sFANL08230AF1.UpdAssemblyId1 != sFANL08230AF2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (sFANL08230AF1.UpdAssemblyId2 != sFANL08230AF2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (sFANL08230AF1.LogicalDeleteCode != sFANL08230AF2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (sFANL08230AF1.OutputFormFileName != sFANL08230AF2.OutputFormFileName) resList.Add("OutputFormFileName");
            if (sFANL08230AF1.UserPrtPprIdDerivNo != sFANL08230AF2.UserPrtPprIdDerivNo) resList.Add("UserPrtPprIdDerivNo");
            if (sFANL08230AF1.PrintPaperUseDivcd != sFANL08230AF2.PrintPaperUseDivcd) resList.Add("PrintPaperUseDivcd");
            if (sFANL08230AF1.PrintPaperDivCd != sFANL08230AF2.PrintPaperDivCd) resList.Add("PrintPaperDivCd");
            if (sFANL08230AF1.ExtractionPgId != sFANL08230AF2.ExtractionPgId) resList.Add("ExtractionPgId");
            if (sFANL08230AF1.ExtractionPgClassId != sFANL08230AF2.ExtractionPgClassId) resList.Add("ExtractionPgClassId");
            if (sFANL08230AF1.OutputPgId != sFANL08230AF2.OutputPgId) resList.Add("OutputPgId");
            if (sFANL08230AF1.OutputPgClassId != sFANL08230AF2.OutputPgClassId) resList.Add("OutputPgClassId");
            if (sFANL08230AF1.OutConfimationMsg != sFANL08230AF2.OutConfimationMsg) resList.Add("OutConfimationMsg");
            if (sFANL08230AF1.DisplayName != sFANL08230AF2.DisplayName) resList.Add("DisplayName");
            if (sFANL08230AF1.PrtPprUserDerivNoCmt != sFANL08230AF2.PrtPprUserDerivNoCmt) resList.Add("PrtPprUserDerivNoCmt");
            if (sFANL08230AF1.PrintPositionVer != sFANL08230AF2.PrintPositionVer) resList.Add("PrintPositionVer");
            if (sFANL08230AF1.MergeablePrintPosVer != sFANL08230AF2.MergeablePrintPosVer) resList.Add("MergeablePrintPosVer");
            if (sFANL08230AF1.DataInputSystem != sFANL08230AF2.DataInputSystem) resList.Add("DataInputSystem");
            if (sFANL08230AF1.OptionCode != sFANL08230AF2.OptionCode) resList.Add("OptionCode");
            if (sFANL08230AF1.FreePrtPprItemGrpCd != sFANL08230AF2.FreePrtPprItemGrpCd) resList.Add("FreePrtPprItemGrpCd");
            if (sFANL08230AF1.PrtPprBgImageRowPos != sFANL08230AF2.PrtPprBgImageRowPos) resList.Add("PrtPprBgImageRowPos");
            if (sFANL08230AF1.PrtPprBgImageColPos != sFANL08230AF2.PrtPprBgImageColPos) resList.Add("PrtPprBgImageColPos");
            if (sFANL08230AF1.PrintPosClassData != sFANL08230AF2.PrintPosClassData) resList.Add("PrintPosClassData");
            if (sFANL08230AF1.PrintPprBgImageData != sFANL08230AF2.PrintPprBgImageData) resList.Add("PrintPprBgImageData");
            if (sFANL08230AF1.EnterpriseName != sFANL08230AF2.EnterpriseName) resList.Add("EnterpriseName");
            if (sFANL08230AF1.UpdEmployeeName != sFANL08230AF2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (sFANL08230AF1.FreePrtPprItemGrpNm != sFANL08230AF2.FreePrtPprItemGrpNm) resList.Add("FreePrtPprItemGrpNm");
            if (sFANL08230AF1.KeyNo != sFANL08230AF2.KeyNo) resList.Add("KeyNo");
            if (sFANL08230AF1.UpdateFlag != sFANL08230AF2.UpdateFlag) resList.Add("UpdateFlag");
            if (sFANL08230AF1.ExistingDataFlag != sFANL08230AF2.ExistingDataFlag) resList.Add("ExistingDataFlag");
            if (sFANL08230AF1.TakeInImageGroupCd != sFANL08230AF2.TakeInImageGroupCd) resList.Add("TakeInImageGroupCd");
            if (sFANL08230AF1.FreePrtPprSpPrpseCd != sFANL08230AF2.FreePrtPprSpPrpseCd) resList.Add("FreePrtPprSpPrpseCd");
            return resList;
        }
    }
}