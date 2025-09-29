using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
	/// public class name:   SlipPrtSetWork
	/// <summary>
	///                      伝票印刷設定ワーク
	/// </summary>
	/// <remarks>
	/// <br>note             :   伝票印刷設定ワークヘッダファイル</br>
	/// <br>Programmer       :   自動生成</br>
	/// <br>Date             :   2008/3/26</br>
	/// <br>Genarated Date   :   2008/06/03  (CSharp File Generated Date)</br>
	/// <br>Update Note      :   </br>
    /// <br>Update Note      :   2011/02/16  鄧潘ハン</br>
    /// <br>                     自社名称１，２が縦倍角になっていない不具合の対応</br>
    /// <br>Update Note      :   2011/7/19  chenyd</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   SCM回答マーク印字区分</br>
    /// <br>                 :   通常発行マーク</br>
    /// <br>                 :   SCM手動回答マーク</br>
    /// <br>                 :   SCM自動回答マーク</br>
    /// </remarks>
	[Serializable]
	[Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
	public class SlipPrtSetWork : IFileHeader
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
        /// <remarks>10:見積書,20:指示書（注文書）,21:承り書,30:納品書40:返品伝票,100:ワークシート,110:ボディ寸法図</remarks>
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
        /// <remarks>0:標準 1:印字しない 2:印字する 3:返品含む</remarks>
        private Int32 _qRCodePrintDivCd;

        /// <summary>時刻印字区分</summary>
        /// <remarks>0:非印字,1:印字</remarks>
        private Int32 _timePrintDivCd;

        /// <summary>再発行マーク</summary>
        /// <remarks>全角３文字まで</remarks>
        private string _reissueMark = "";

        /// <summary>消費税印字区分</summary>
        /// <remarks>0:非印字,1:印字</remarks>
        private Int32 _consTaxPrtCd;

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

        /// <summary>消費税印字区分</summary>
        /// <remarks>0:非印字 1:印字</remarks>
        private Int32 _consTaxPrtCdRF;

        // --- ADD 2009/12/31 ---------->>>>>
        /// <summary>伝票備考桁数</summary>
        private Int32 _slipNoteCharCnt;

        /// <summary>伝票備考２桁数</summary>
        private Int32 _slipNote2CharCnt;

        /// <summary>伝票備考３桁数</summary>
        private Int32 _slipNote3CharCnt;
        // --- ADD 2009/12/31 ----------<<<<<

        // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;

        /// <summary>更新フラグ</summary>
        private Int32 _updateFlag;
        // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

        // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>
        /// <summary>自社名印字拡大区分</summary>
        private Int32 _entNmPrtExpDiv;
        // ---ADD 2011/02/16 ------------------------------------------------------------<<<<<

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
        // ---ADD 2011/07/19 ------------------------------------------------------------<<<<<

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
            get { return _slipPrtKind; }
            set { _slipPrtKind = value; }
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
            get { return _slipPrtSetPaperId; }
            set { _slipPrtSetPaperId = value; }
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
            get { return _slipComment; }
            set { _slipComment = value; }
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
            get { return _enterpriseNamePrtCd; }
            set { _enterpriseNamePrtCd = value; }
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
            get { return _prtCirculation; }
            set { _prtCirculation = value; }
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
            get { return _slipFormCd; }
            set { _slipFormCd = value; }
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
            get { return _topMargin; }
            set { _topMargin = value; }
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
            get { return _leftMargin; }
            set { _leftMargin = value; }
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
            get { return _rightMargin; }
            set { _rightMargin = value; }
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
            get { return _bottomMargin; }
            set { _bottomMargin = value; }
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
            get { return _prtPreviewExistCode; }
            set { _prtPreviewExistCode = value; }
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
            get { return _outputPurpose; }
            set { _outputPurpose = value; }
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
            get { return _eachSlipTypeColId1; }
            set { _eachSlipTypeColId1 = value; }
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
            get { return _eachSlipTypeColNm1; }
            set { _eachSlipTypeColNm1 = value; }
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
            get { return _eachSlipTypeColPrt1; }
            set { _eachSlipTypeColPrt1 = value; }
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
            get { return _eachSlipTypeColId2; }
            set { _eachSlipTypeColId2 = value; }
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
            get { return _eachSlipTypeColNm2; }
            set { _eachSlipTypeColNm2 = value; }
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
            get { return _eachSlipTypeColPrt2; }
            set { _eachSlipTypeColPrt2 = value; }
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
            get { return _eachSlipTypeColId3; }
            set { _eachSlipTypeColId3 = value; }
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
            get { return _eachSlipTypeColNm3; }
            set { _eachSlipTypeColNm3 = value; }
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
            get { return _eachSlipTypeColPrt3; }
            set { _eachSlipTypeColPrt3 = value; }
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
            get { return _eachSlipTypeColId4; }
            set { _eachSlipTypeColId4 = value; }
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
            get { return _eachSlipTypeColNm4; }
            set { _eachSlipTypeColNm4 = value; }
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
            get { return _eachSlipTypeColPrt4; }
            set { _eachSlipTypeColPrt4 = value; }
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
            get { return _eachSlipTypeColId5; }
            set { _eachSlipTypeColId5 = value; }
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
            get { return _eachSlipTypeColNm5; }
            set { _eachSlipTypeColNm5 = value; }
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
            get { return _eachSlipTypeColPrt5; }
            set { _eachSlipTypeColPrt5 = value; }
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
            get { return _eachSlipTypeColId6; }
            set { _eachSlipTypeColId6 = value; }
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
            get { return _eachSlipTypeColNm6; }
            set { _eachSlipTypeColNm6 = value; }
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
            get { return _eachSlipTypeColPrt6; }
            set { _eachSlipTypeColPrt6 = value; }
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
            get { return _eachSlipTypeColId7; }
            set { _eachSlipTypeColId7 = value; }
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
            get { return _eachSlipTypeColNm7; }
            set { _eachSlipTypeColNm7 = value; }
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
            get { return _eachSlipTypeColPrt7; }
            set { _eachSlipTypeColPrt7 = value; }
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
            get { return _eachSlipTypeColId8; }
            set { _eachSlipTypeColId8 = value; }
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
            get { return _eachSlipTypeColNm8; }
            set { _eachSlipTypeColNm8 = value; }
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
            get { return _eachSlipTypeColPrt8; }
            set { _eachSlipTypeColPrt8 = value; }
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
            get { return _eachSlipTypeColId9; }
            set { _eachSlipTypeColId9 = value; }
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
            get { return _eachSlipTypeColNm9; }
            set { _eachSlipTypeColNm9 = value; }
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
            get { return _eachSlipTypeColPrt9; }
            set { _eachSlipTypeColPrt9 = value; }
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
            get { return _eachSlipTypeColId10; }
            set { _eachSlipTypeColId10 = value; }
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
            get { return _eachSlipTypeColNm10; }
            set { _eachSlipTypeColNm10 = value; }
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
            get { return _eachSlipTypeColPrt10; }
            set { _eachSlipTypeColPrt10 = value; }
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
            get { return _slipFontName; }
            set { _slipFontName = value; }
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
            get { return _slipFontSize; }
            set { _slipFontSize = value; }
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
            get { return _slipFontStyle; }
            set { _slipFontStyle = value; }
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
            get { return _slipBaseColorRed1; }
            set { _slipBaseColorRed1 = value; }
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
            get { return _slipBaseColorGrn1; }
            set { _slipBaseColorGrn1 = value; }
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
            get { return _slipBaseColorBlu1; }
            set { _slipBaseColorBlu1 = value; }
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
            get { return _slipBaseColorRed2; }
            set { _slipBaseColorRed2 = value; }
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
            get { return _slipBaseColorGrn2; }
            set { _slipBaseColorGrn2 = value; }
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
            get { return _slipBaseColorBlu2; }
            set { _slipBaseColorBlu2 = value; }
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
            get { return _slipBaseColorRed3; }
            set { _slipBaseColorRed3 = value; }
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
            get { return _slipBaseColorGrn3; }
            set { _slipBaseColorGrn3 = value; }
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
            get { return _slipBaseColorBlu3; }
            set { _slipBaseColorBlu3 = value; }
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
            get { return _slipBaseColorRed4; }
            set { _slipBaseColorRed4 = value; }
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
            get { return _slipBaseColorGrn4; }
            set { _slipBaseColorGrn4 = value; }
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
            get { return _slipBaseColorBlu4; }
            set { _slipBaseColorBlu4 = value; }
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
            get { return _slipBaseColorRed5; }
            set { _slipBaseColorRed5 = value; }
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
            get { return _slipBaseColorGrn5; }
            set { _slipBaseColorGrn5 = value; }
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
            get { return _slipBaseColorBlu5; }
            set { _slipBaseColorBlu5 = value; }
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
            get { return _copyCount; }
            set { _copyCount = value; }
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
            get { return _titleName1; }
            set { _titleName1 = value; }
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
            get { return _titleName2; }
            set { _titleName2 = value; }
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
            get { return _titleName3; }
            set { _titleName3 = value; }
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
            get { return _titleName4; }
            set { _titleName4 = value; }
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
            get { return _specialPurpose1; }
            set { _specialPurpose1 = value; }
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
            get { return _specialPurpose2; }
            set { _specialPurpose2 = value; }
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
            get { return _specialPurpose3; }
            set { _specialPurpose3 = value; }
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
            get { return _specialPurpose4; }
            set { _specialPurpose4 = value; }
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
            get { return _titleName102; }
            set { _titleName102 = value; }
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
            get { return _titleName103; }
            set { _titleName103 = value; }
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
            get { return _titleName104; }
            set { _titleName104 = value; }
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
            get { return _titleName105; }
            set { _titleName105 = value; }
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
            get { return _titleName202; }
            set { _titleName202 = value; }
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
            get { return _titleName203; }
            set { _titleName203 = value; }
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
            get { return _titleName204; }
            set { _titleName204 = value; }
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
            get { return _titleName205; }
            set { _titleName205 = value; }
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
            get { return _titleName302; }
            set { _titleName302 = value; }
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
            get { return _titleName303; }
            set { _titleName303 = value; }
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
            get { return _titleName304; }
            set { _titleName304 = value; }
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
            get { return _titleName305; }
            set { _titleName305 = value; }
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
            get { return _titleName402; }
            set { _titleName402 = value; }
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
            get { return _titleName403; }
            set { _titleName403 = value; }
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
            get { return _titleName404; }
            set { _titleName404 = value; }
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
            get { return _titleName405; }
            set { _titleName405 = value; }
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
            get { return _note1; }
            set { _note1 = value; }
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
            get { return _note2; }
            set { _note2 = value; }
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
            get { return _note3; }
            set { _note3 = value; }
        }

        /// public propaty name  :  QRCodePrintDivCd
        /// <summary>QRコード印字区分プロパティ</summary>
        /// <value>0:標準 1:印字しない 2:印字する 3:返品含む</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   QRコード印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 QRCodePrintDivCd
        {
            get { return _qRCodePrintDivCd; }
            set { _qRCodePrintDivCd = value; }
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
            get { return _timePrintDivCd; }
            set { _timePrintDivCd = value; }
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
            get { return _reissueMark; }
            set { _reissueMark = value; }
        }

        /// public propaty name  :  ConsTaxPrtCd
        /// <summary>消費税印字区分プロパティ</summary>
        /// <value>0:非印字,1:印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxPrtCd
        {
            get { return _consTaxPrtCd; }
            set { _consTaxPrtCd = value; }
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
            get { return _refConsTaxDivCd; }
            set { _refConsTaxDivCd = value; }
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
            get { return _refConsTaxPrtNm; }
            set { _refConsTaxPrtNm = value; }
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
            get { return _detailRowCount; }
            set { _detailRowCount = value; }
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
            get { return _honorificTitle; }
            set { _honorificTitle = value; }
        }

        /// public propaty name  :  ConsTaxPrtCdRF 
        /// <summary>消費税印字区分プロパティ</summary>
        /// <value>0:非印字 1:印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxPrtCdRF
        {
            get { return _consTaxPrtCdRF; }
            set { _consTaxPrtCdRF = value; }
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
        /// <br>note             :  伝票備考２桁数プロパティ</br>
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
        /// <summary>EntNmPrtExpDiv</summary>
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
        /// 伝票印刷設定ワークコンストラクタ
        /// </summary>
        /// <returns>SlipPrtSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipPrtSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SlipPrtSetWork()
        {
        }

	}
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>SlipPrtSetWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   SlipPrtSetWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class SlipPrtSetWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipPrtSetWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      : 2011/02/16  鄧潘ハン</br>
        /// <br>                        自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  SlipPrtSetWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is SlipPrtSetWork || graph is ArrayList || graph is SlipPrtSetWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(SlipPrtSetWork).FullName));

            if (graph != null && graph is SlipPrtSetWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.SlipPrtSetWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is SlipPrtSetWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((SlipPrtSetWork[])graph).Length;
            }
            else if (graph is SlipPrtSetWork)
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
            //データ入力システム
            serInfo.MemberInfo.Add(typeof(Int32)); //DataInputSystem
            //伝票印刷種別
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipPrtKind
            //伝票印刷設定用帳票ID
            serInfo.MemberInfo.Add(typeof(string)); //SlipPrtSetPaperId
            //伝票コメント
            serInfo.MemberInfo.Add(typeof(string)); //SlipComment
            //出力プログラムID
            serInfo.MemberInfo.Add(typeof(string)); //OutputPgId
            //出力プログラムクラスID
            serInfo.MemberInfo.Add(typeof(string)); //OutputPgClassId
            //出力ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //OutputFormFileName
            //自社名印刷区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EnterpriseNamePrtCd
            //印刷部数
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtCirculation
            //伝票用紙区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipFormCd
            //出力確認メッセージ
            serInfo.MemberInfo.Add(typeof(string)); //OutConfimationMsg
            //オプションコード
            serInfo.MemberInfo.Add(typeof(string)); //OptionCode
            //上余白
            serInfo.MemberInfo.Add(typeof(Double)); //TopMargin
            //左余白
            serInfo.MemberInfo.Add(typeof(Double)); //LeftMargin
            //右余白
            serInfo.MemberInfo.Add(typeof(Double)); //RightMargin
            //下余白
            serInfo.MemberInfo.Add(typeof(Double)); //BottomMargin
            //印刷プレビュ有無区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PrtPreviewExistCode
            //出力用途
            serInfo.MemberInfo.Add(typeof(Int32)); //OutputPurpose
            //伝票タイプ別列ID1
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId1
            //伝票タイプ別列名称1
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm1
            //伝票タイプ別列印字区分1
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt1
            //伝票タイプ別列ID2
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId2
            //伝票タイプ別列名称2
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm2
            //伝票タイプ別列印字区分2
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt2
            //伝票タイプ別列ID3
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId3
            //伝票タイプ別列名称3
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm3
            //伝票タイプ別列印字区分3
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt3
            //伝票タイプ別列ID4
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId4
            //伝票タイプ別列名称4
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm4
            //伝票タイプ別列印字区分4
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt4
            //伝票タイプ別列ID5
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId5
            //伝票タイプ別列名称5
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm5
            //伝票タイプ別列印字区分5
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt5
            //伝票タイプ別列ID6
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId6
            //伝票タイプ別列名称6
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm6
            //伝票タイプ別列印字区分6
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt6
            //伝票タイプ別列ID7
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId7
            //伝票タイプ別列名称7
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm7
            //伝票タイプ別列印字区分7
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt7
            //伝票タイプ別列ID8
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId8
            //伝票タイプ別列名称8
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm8
            //伝票タイプ別列印字区分8
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt8
            //伝票タイプ別列ID9
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId9
            //伝票タイプ別列名称9
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm9
            //伝票タイプ別列印字区分9
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt9
            //伝票タイプ別列ID10
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColId10
            //伝票タイプ別列名称10
            serInfo.MemberInfo.Add(typeof(string)); //EachSlipTypeColNm10
            //伝票タイプ別列印字区分10
            serInfo.MemberInfo.Add(typeof(Int32)); //EachSlipTypeColPrt10
            //伝票フォント名称
            serInfo.MemberInfo.Add(typeof(string)); //SlipFontName
            //伝票フォントサイズ
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipFontSize
            //伝票フォントスタイル
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipFontStyle
            //伝票基準色赤1
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorRed1
            //伝票基準色緑1
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorGrn1
            //伝票基準色青1
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorBlu1
            //伝票基準色赤2
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorRed2
            //伝票基準色緑2
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorGrn2
            //伝票基準色青2
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorBlu2
            //伝票基準色赤3
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorRed3
            //伝票基準色緑3
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorGrn3
            //伝票基準色青3
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorBlu3
            //伝票基準色赤4
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorRed4
            //伝票基準色緑4
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorGrn4
            //伝票基準色青4
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorBlu4
            //伝票基準色赤5
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorRed5
            //伝票基準色緑5
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorGrn5
            //伝票基準色青5
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipBaseColorBlu5
            //複写枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //CopyCount
            //タイトル1
            serInfo.MemberInfo.Add(typeof(string)); //TitleName1
            //タイトル2
            serInfo.MemberInfo.Add(typeof(string)); //TitleName2
            //タイトル3
            serInfo.MemberInfo.Add(typeof(string)); //TitleName3
            //タイトル4
            serInfo.MemberInfo.Add(typeof(string)); //TitleName4
            //特殊用途1
            serInfo.MemberInfo.Add(typeof(string)); //SpecialPurpose1
            //特殊用途2
            serInfo.MemberInfo.Add(typeof(string)); //SpecialPurpose2
            //特殊用途3
            serInfo.MemberInfo.Add(typeof(string)); //SpecialPurpose3
            //特殊用途4
            serInfo.MemberInfo.Add(typeof(string)); //SpecialPurpose4
            //タイトル1-2
            serInfo.MemberInfo.Add(typeof(string)); //TitleName102
            //タイトル1-3
            serInfo.MemberInfo.Add(typeof(string)); //TitleName103
            //タイトル1-4
            serInfo.MemberInfo.Add(typeof(string)); //TitleName104
            //タイトル1-5
            serInfo.MemberInfo.Add(typeof(string)); //TitleName105
            //タイトル2-2
            serInfo.MemberInfo.Add(typeof(string)); //TitleName202
            //タイトル2-3
            serInfo.MemberInfo.Add(typeof(string)); //TitleName203
            //タイトル2-4
            serInfo.MemberInfo.Add(typeof(string)); //TitleName204
            //タイトル2-5
            serInfo.MemberInfo.Add(typeof(string)); //TitleName205
            //タイトル3-2
            serInfo.MemberInfo.Add(typeof(string)); //TitleName302
            //タイトル3-3
            serInfo.MemberInfo.Add(typeof(string)); //TitleName303
            //タイトル3-4
            serInfo.MemberInfo.Add(typeof(string)); //TitleName304
            //タイトル3-5
            serInfo.MemberInfo.Add(typeof(string)); //TitleName305
            //タイトル4-2
            serInfo.MemberInfo.Add(typeof(string)); //TitleName402
            //タイトル4-3
            serInfo.MemberInfo.Add(typeof(string)); //TitleName403
            //タイトル4-4
            serInfo.MemberInfo.Add(typeof(string)); //TitleName404
            //タイトル4-5
            serInfo.MemberInfo.Add(typeof(string)); //TitleName405
            //備考１
            serInfo.MemberInfo.Add(typeof(string)); //Note1
            //備考２
            serInfo.MemberInfo.Add(typeof(string)); //Note2
            //備考３
            serInfo.MemberInfo.Add(typeof(string)); //Note3
            //QRコード印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //QRCodePrintDivCd
            //時刻印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TimePrintDivCd
            //再発行マーク
            serInfo.MemberInfo.Add(typeof(string)); //ReissueMark
            //消費税印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxPrtCd
            //参考消費税区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RefConsTaxDivCd
            //参考消費税印字名称
            serInfo.MemberInfo.Add(typeof(string)); //RefConsTaxPrtNm
            //明細行数
            serInfo.MemberInfo.Add(typeof(Int32)); //DetailRowCount
            //敬称
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTitle
            //消費税印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxPrtCdRF 

            // --- ADD 2009/12/31 ---------->>>>>
            //伝票備考桁数
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipNoteCharCnt 
            //伝票備考２桁数
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipNote2CharCnt 
            //伝票備考３桁数
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipNote3CharCnt 
            // --- ADD 2009/12/31 ----------<<<<<

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            serInfo.MemberInfo.Add(typeof(Int32)); //UpdateFlag
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

            // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>
            //自社名印字拡大区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EntNmPrtExpDiv 
            // ---ADD 2011/02/16 ------------------------------------------------------------<<<<<

            // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
            //SCM回答マーク印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SCMAnsMarkPrtDiv
            //通常発行マーク
            serInfo.MemberInfo.Add(typeof(string)); //NormalPrtMark
            //SCM手動回答マーク
            serInfo.MemberInfo.Add(typeof(string)); //SCMManualAnsMark
            //SCM自動回答マーク
            serInfo.MemberInfo.Add(typeof(string)); //SCMAutoAnsMark
            // ---ADD 2011/07/19 ------------------------------------------------------------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is SlipPrtSetWork)
            {
                SlipPrtSetWork temp = (SlipPrtSetWork)graph;

                SetSlipPrtSetWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is SlipPrtSetWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((SlipPrtSetWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (SlipPrtSetWork temp in lst)
                {
                    SetSlipPrtSetWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// SlipPrtSetWorkメンバ数(publicプロパティ数)
        /// </summary>
        //private const int currentMemberCount = 114;
        //private const int currentMemberCount = 116; // DEL 2011/02/16
        //private const int currentMemberCount = 117; // ADD 2011/02/16  // DEL 2011/07/19
        private const int currentMemberCount = 121; // ADD 2011/07/19

        /// <summary>
        ///  SlipPrtSetWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipPrtSetWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      : 2011/02/16  鄧潘ハン</br>
        /// <br>                        自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
        private void SetSlipPrtSetWork(System.IO.BinaryWriter writer, SlipPrtSetWork temp)
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
            //データ入力システム
            writer.Write(temp.DataInputSystem);
            //伝票印刷種別
            writer.Write(temp.SlipPrtKind);
            //伝票印刷設定用帳票ID
            writer.Write(temp.SlipPrtSetPaperId);
            //伝票コメント
            writer.Write(temp.SlipComment);
            //出力プログラムID
            writer.Write(temp.OutputPgId);
            //出力プログラムクラスID
            writer.Write(temp.OutputPgClassId);
            //出力ファイル名
            writer.Write(temp.OutputFormFileName);
            //自社名印刷区分
            writer.Write(temp.EnterpriseNamePrtCd);
            //印刷部数
            writer.Write(temp.PrtCirculation);
            //伝票用紙区分
            writer.Write(temp.SlipFormCd);
            //出力確認メッセージ
            writer.Write(temp.OutConfimationMsg);
            //オプションコード
            writer.Write(temp.OptionCode);
            //上余白
            writer.Write(temp.TopMargin);
            //左余白
            writer.Write(temp.LeftMargin);
            //右余白
            writer.Write(temp.RightMargin);
            //下余白
            writer.Write(temp.BottomMargin);
            //印刷プレビュ有無区分
            writer.Write(temp.PrtPreviewExistCode);
            //出力用途
            writer.Write(temp.OutputPurpose);
            //伝票タイプ別列ID1
            writer.Write(temp.EachSlipTypeColId1);
            //伝票タイプ別列名称1
            writer.Write(temp.EachSlipTypeColNm1);
            //伝票タイプ別列印字区分1
            writer.Write(temp.EachSlipTypeColPrt1);
            //伝票タイプ別列ID2
            writer.Write(temp.EachSlipTypeColId2);
            //伝票タイプ別列名称2
            writer.Write(temp.EachSlipTypeColNm2);
            //伝票タイプ別列印字区分2
            writer.Write(temp.EachSlipTypeColPrt2);
            //伝票タイプ別列ID3
            writer.Write(temp.EachSlipTypeColId3);
            //伝票タイプ別列名称3
            writer.Write(temp.EachSlipTypeColNm3);
            //伝票タイプ別列印字区分3
            writer.Write(temp.EachSlipTypeColPrt3);
            //伝票タイプ別列ID4
            writer.Write(temp.EachSlipTypeColId4);
            //伝票タイプ別列名称4
            writer.Write(temp.EachSlipTypeColNm4);
            //伝票タイプ別列印字区分4
            writer.Write(temp.EachSlipTypeColPrt4);
            //伝票タイプ別列ID5
            writer.Write(temp.EachSlipTypeColId5);
            //伝票タイプ別列名称5
            writer.Write(temp.EachSlipTypeColNm5);
            //伝票タイプ別列印字区分5
            writer.Write(temp.EachSlipTypeColPrt5);
            //伝票タイプ別列ID6
            writer.Write(temp.EachSlipTypeColId6);
            //伝票タイプ別列名称6
            writer.Write(temp.EachSlipTypeColNm6);
            //伝票タイプ別列印字区分6
            writer.Write(temp.EachSlipTypeColPrt6);
            //伝票タイプ別列ID7
            writer.Write(temp.EachSlipTypeColId7);
            //伝票タイプ別列名称7
            writer.Write(temp.EachSlipTypeColNm7);
            //伝票タイプ別列印字区分7
            writer.Write(temp.EachSlipTypeColPrt7);
            //伝票タイプ別列ID8
            writer.Write(temp.EachSlipTypeColId8);
            //伝票タイプ別列名称8
            writer.Write(temp.EachSlipTypeColNm8);
            //伝票タイプ別列印字区分8
            writer.Write(temp.EachSlipTypeColPrt8);
            //伝票タイプ別列ID9
            writer.Write(temp.EachSlipTypeColId9);
            //伝票タイプ別列名称9
            writer.Write(temp.EachSlipTypeColNm9);
            //伝票タイプ別列印字区分9
            writer.Write(temp.EachSlipTypeColPrt9);
            //伝票タイプ別列ID10
            writer.Write(temp.EachSlipTypeColId10);
            //伝票タイプ別列名称10
            writer.Write(temp.EachSlipTypeColNm10);
            //伝票タイプ別列印字区分10
            writer.Write(temp.EachSlipTypeColPrt10);
            //伝票フォント名称
            writer.Write(temp.SlipFontName);
            //伝票フォントサイズ
            writer.Write(temp.SlipFontSize);
            //伝票フォントスタイル
            writer.Write(temp.SlipFontStyle);
            //伝票基準色赤1
            writer.Write(temp.SlipBaseColorRed1);
            //伝票基準色緑1
            writer.Write(temp.SlipBaseColorGrn1);
            //伝票基準色青1
            writer.Write(temp.SlipBaseColorBlu1);
            //伝票基準色赤2
            writer.Write(temp.SlipBaseColorRed2);
            //伝票基準色緑2
            writer.Write(temp.SlipBaseColorGrn2);
            //伝票基準色青2
            writer.Write(temp.SlipBaseColorBlu2);
            //伝票基準色赤3
            writer.Write(temp.SlipBaseColorRed3);
            //伝票基準色緑3
            writer.Write(temp.SlipBaseColorGrn3);
            //伝票基準色青3
            writer.Write(temp.SlipBaseColorBlu3);
            //伝票基準色赤4
            writer.Write(temp.SlipBaseColorRed4);
            //伝票基準色緑4
            writer.Write(temp.SlipBaseColorGrn4);
            //伝票基準色青4
            writer.Write(temp.SlipBaseColorBlu4);
            //伝票基準色赤5
            writer.Write(temp.SlipBaseColorRed5);
            //伝票基準色緑5
            writer.Write(temp.SlipBaseColorGrn5);
            //伝票基準色青5
            writer.Write(temp.SlipBaseColorBlu5);
            //複写枚数
            writer.Write(temp.CopyCount);
            //タイトル1
            writer.Write(temp.TitleName1);
            //タイトル2
            writer.Write(temp.TitleName2);
            //タイトル3
            writer.Write(temp.TitleName3);
            //タイトル4
            writer.Write(temp.TitleName4);
            //特殊用途1
            writer.Write(temp.SpecialPurpose1);
            //特殊用途2
            writer.Write(temp.SpecialPurpose2);
            //特殊用途3
            writer.Write(temp.SpecialPurpose3);
            //特殊用途4
            writer.Write(temp.SpecialPurpose4);
            //タイトル1-2
            writer.Write(temp.TitleName102);
            //タイトル1-3
            writer.Write(temp.TitleName103);
            //タイトル1-4
            writer.Write(temp.TitleName104);
            //タイトル1-5
            writer.Write(temp.TitleName105);
            //タイトル2-2
            writer.Write(temp.TitleName202);
            //タイトル2-3
            writer.Write(temp.TitleName203);
            //タイトル2-4
            writer.Write(temp.TitleName204);
            //タイトル2-5
            writer.Write(temp.TitleName205);
            //タイトル3-2
            writer.Write(temp.TitleName302);
            //タイトル3-3
            writer.Write(temp.TitleName303);
            //タイトル3-4
            writer.Write(temp.TitleName304);
            //タイトル3-5
            writer.Write(temp.TitleName305);
            //タイトル4-2
            writer.Write(temp.TitleName402);
            //タイトル4-3
            writer.Write(temp.TitleName403);
            //タイトル4-4
            writer.Write(temp.TitleName404);
            //タイトル4-5
            writer.Write(temp.TitleName405);
            //備考１
            writer.Write(temp.Note1);
            //備考２
            writer.Write(temp.Note2);
            //備考３
            writer.Write(temp.Note3);
            //QRコード印字区分
            writer.Write(temp.QRCodePrintDivCd);
            //時刻印字区分
            writer.Write(temp.TimePrintDivCd);
            //再発行マーク
            writer.Write(temp.ReissueMark);
            //消費税印字区分
            writer.Write(temp.ConsTaxPrtCd);
            //参考消費税区分
            writer.Write(temp.RefConsTaxDivCd);
            //参考消費税印字名称
            writer.Write(temp.RefConsTaxPrtNm);
            //明細行数
            writer.Write(temp.DetailRowCount);
            //敬称
            writer.Write(temp.HonorificTitle);
            //消費税印字区分
            writer.Write(temp.ConsTaxPrtCdRF);
            // --- ADD 2009/12/31 ---------->>>>>
            //伝票備考桁数
            writer.Write(temp.SlipNoteCharCnt);
            //伝票備考２桁数
            writer.Write(temp.SlipNote2CharCnt);
            //伝票備考３桁数
            writer.Write(temp.SlipNote3CharCnt);
            // --- ADD 2009/12/31 ----------<<<<<

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            //得意先コード
            writer.Write(temp.CustomerCode);
            //更新フラグ
            writer.Write(temp.UpdateFlag);
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<
            
            // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>
            //自社名印字拡大区分
            writer.Write(temp.EntNmPrtExpDiv); 
            // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>

            // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
            //SCM回答マーク印字区分
            writer.Write(temp.SCMAnsMarkPrtDiv);
            //通常発行マーク
            writer.Write(temp.NormalPrtMark);
            //SCM手動回答マーク
            writer.Write(temp.SCMManualAnsMark);
            //SCM自動回答マーク
            writer.Write(temp.SCMAutoAnsMark);
            // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
        }

        /// <summary>
        ///  SlipPrtSetWorkインスタンス取得
        /// </summary>
        /// <returns>SlipPrtSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipPrtSetWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      : 2011/02/16  鄧潘ハン</br>
        /// <br>                        自社名称１，２が縦倍角になっていない不具合の対応</br>
        /// </remarks>
        private SlipPrtSetWork GetSlipPrtSetWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            SlipPrtSetWork temp = new SlipPrtSetWork();

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
            //データ入力システム
            temp.DataInputSystem = reader.ReadInt32();
            //伝票印刷種別
            temp.SlipPrtKind = reader.ReadInt32();
            //伝票印刷設定用帳票ID
            temp.SlipPrtSetPaperId = reader.ReadString();
            //伝票コメント
            temp.SlipComment = reader.ReadString();
            //出力プログラムID
            temp.OutputPgId = reader.ReadString();
            //出力プログラムクラスID
            temp.OutputPgClassId = reader.ReadString();
            //出力ファイル名
            temp.OutputFormFileName = reader.ReadString();
            //自社名印刷区分
            temp.EnterpriseNamePrtCd = reader.ReadInt32();
            //印刷部数
            temp.PrtCirculation = reader.ReadInt32();
            //伝票用紙区分
            temp.SlipFormCd = reader.ReadInt32();
            //出力確認メッセージ
            temp.OutConfimationMsg = reader.ReadString();
            //オプションコード
            temp.OptionCode = reader.ReadString();
            //上余白
            temp.TopMargin = reader.ReadDouble();
            //左余白
            temp.LeftMargin = reader.ReadDouble();
            //右余白
            temp.RightMargin = reader.ReadDouble();
            //下余白
            temp.BottomMargin = reader.ReadDouble();
            //印刷プレビュ有無区分
            temp.PrtPreviewExistCode = reader.ReadInt32();
            //出力用途
            temp.OutputPurpose = reader.ReadInt32();
            //伝票タイプ別列ID1
            temp.EachSlipTypeColId1 = reader.ReadString();
            //伝票タイプ別列名称1
            temp.EachSlipTypeColNm1 = reader.ReadString();
            //伝票タイプ別列印字区分1
            temp.EachSlipTypeColPrt1 = reader.ReadInt32();
            //伝票タイプ別列ID2
            temp.EachSlipTypeColId2 = reader.ReadString();
            //伝票タイプ別列名称2
            temp.EachSlipTypeColNm2 = reader.ReadString();
            //伝票タイプ別列印字区分2
            temp.EachSlipTypeColPrt2 = reader.ReadInt32();
            //伝票タイプ別列ID3
            temp.EachSlipTypeColId3 = reader.ReadString();
            //伝票タイプ別列名称3
            temp.EachSlipTypeColNm3 = reader.ReadString();
            //伝票タイプ別列印字区分3
            temp.EachSlipTypeColPrt3 = reader.ReadInt32();
            //伝票タイプ別列ID4
            temp.EachSlipTypeColId4 = reader.ReadString();
            //伝票タイプ別列名称4
            temp.EachSlipTypeColNm4 = reader.ReadString();
            //伝票タイプ別列印字区分4
            temp.EachSlipTypeColPrt4 = reader.ReadInt32();
            //伝票タイプ別列ID5
            temp.EachSlipTypeColId5 = reader.ReadString();
            //伝票タイプ別列名称5
            temp.EachSlipTypeColNm5 = reader.ReadString();
            //伝票タイプ別列印字区分5
            temp.EachSlipTypeColPrt5 = reader.ReadInt32();
            //伝票タイプ別列ID6
            temp.EachSlipTypeColId6 = reader.ReadString();
            //伝票タイプ別列名称6
            temp.EachSlipTypeColNm6 = reader.ReadString();
            //伝票タイプ別列印字区分6
            temp.EachSlipTypeColPrt6 = reader.ReadInt32();
            //伝票タイプ別列ID7
            temp.EachSlipTypeColId7 = reader.ReadString();
            //伝票タイプ別列名称7
            temp.EachSlipTypeColNm7 = reader.ReadString();
            //伝票タイプ別列印字区分7
            temp.EachSlipTypeColPrt7 = reader.ReadInt32();
            //伝票タイプ別列ID8
            temp.EachSlipTypeColId8 = reader.ReadString();
            //伝票タイプ別列名称8
            temp.EachSlipTypeColNm8 = reader.ReadString();
            //伝票タイプ別列印字区分8
            temp.EachSlipTypeColPrt8 = reader.ReadInt32();
            //伝票タイプ別列ID9
            temp.EachSlipTypeColId9 = reader.ReadString();
            //伝票タイプ別列名称9
            temp.EachSlipTypeColNm9 = reader.ReadString();
            //伝票タイプ別列印字区分9
            temp.EachSlipTypeColPrt9 = reader.ReadInt32();
            //伝票タイプ別列ID10
            temp.EachSlipTypeColId10 = reader.ReadString();
            //伝票タイプ別列名称10
            temp.EachSlipTypeColNm10 = reader.ReadString();
            //伝票タイプ別列印字区分10
            temp.EachSlipTypeColPrt10 = reader.ReadInt32();
            //伝票フォント名称
            temp.SlipFontName = reader.ReadString();
            //伝票フォントサイズ
            temp.SlipFontSize = reader.ReadInt32();
            //伝票フォントスタイル
            temp.SlipFontStyle = reader.ReadInt32();
            //伝票基準色赤1
            temp.SlipBaseColorRed1 = reader.ReadInt32();
            //伝票基準色緑1
            temp.SlipBaseColorGrn1 = reader.ReadInt32();
            //伝票基準色青1
            temp.SlipBaseColorBlu1 = reader.ReadInt32();
            //伝票基準色赤2
            temp.SlipBaseColorRed2 = reader.ReadInt32();
            //伝票基準色緑2
            temp.SlipBaseColorGrn2 = reader.ReadInt32();
            //伝票基準色青2
            temp.SlipBaseColorBlu2 = reader.ReadInt32();
            //伝票基準色赤3
            temp.SlipBaseColorRed3 = reader.ReadInt32();
            //伝票基準色緑3
            temp.SlipBaseColorGrn3 = reader.ReadInt32();
            //伝票基準色青3
            temp.SlipBaseColorBlu3 = reader.ReadInt32();
            //伝票基準色赤4
            temp.SlipBaseColorRed4 = reader.ReadInt32();
            //伝票基準色緑4
            temp.SlipBaseColorGrn4 = reader.ReadInt32();
            //伝票基準色青4
            temp.SlipBaseColorBlu4 = reader.ReadInt32();
            //伝票基準色赤5
            temp.SlipBaseColorRed5 = reader.ReadInt32();
            //伝票基準色緑5
            temp.SlipBaseColorGrn5 = reader.ReadInt32();
            //伝票基準色青5
            temp.SlipBaseColorBlu5 = reader.ReadInt32();
            //複写枚数
            temp.CopyCount = reader.ReadInt32();
            //タイトル1
            temp.TitleName1 = reader.ReadString();
            //タイトル2
            temp.TitleName2 = reader.ReadString();
            //タイトル3
            temp.TitleName3 = reader.ReadString();
            //タイトル4
            temp.TitleName4 = reader.ReadString();
            //特殊用途1
            temp.SpecialPurpose1 = reader.ReadString();
            //特殊用途2
            temp.SpecialPurpose2 = reader.ReadString();
            //特殊用途3
            temp.SpecialPurpose3 = reader.ReadString();
            //特殊用途4
            temp.SpecialPurpose4 = reader.ReadString();
            //タイトル1-2
            temp.TitleName102 = reader.ReadString();
            //タイトル1-3
            temp.TitleName103 = reader.ReadString();
            //タイトル1-4
            temp.TitleName104 = reader.ReadString();
            //タイトル1-5
            temp.TitleName105 = reader.ReadString();
            //タイトル2-2
            temp.TitleName202 = reader.ReadString();
            //タイトル2-3
            temp.TitleName203 = reader.ReadString();
            //タイトル2-4
            temp.TitleName204 = reader.ReadString();
            //タイトル2-5
            temp.TitleName205 = reader.ReadString();
            //タイトル3-2
            temp.TitleName302 = reader.ReadString();
            //タイトル3-3
            temp.TitleName303 = reader.ReadString();
            //タイトル3-4
            temp.TitleName304 = reader.ReadString();
            //タイトル3-5
            temp.TitleName305 = reader.ReadString();
            //タイトル4-2
            temp.TitleName402 = reader.ReadString();
            //タイトル4-3
            temp.TitleName403 = reader.ReadString();
            //タイトル4-4
            temp.TitleName404 = reader.ReadString();
            //タイトル4-5
            temp.TitleName405 = reader.ReadString();
            //備考１
            temp.Note1 = reader.ReadString();
            //備考２
            temp.Note2 = reader.ReadString();
            //備考３
            temp.Note3 = reader.ReadString();
            //QRコード印字区分
            temp.QRCodePrintDivCd = reader.ReadInt32();
            //時刻印字区分
            temp.TimePrintDivCd = reader.ReadInt32();
            //再発行マーク
            temp.ReissueMark = reader.ReadString();
            //消費税印字区分
            temp.ConsTaxPrtCd = reader.ReadInt32();
            //参考消費税区分
            temp.RefConsTaxDivCd = reader.ReadInt32();
            //参考消費税印字名称
            temp.RefConsTaxPrtNm = reader.ReadString();
            //明細行数
            temp.DetailRowCount = reader.ReadInt32();
            //敬称
            temp.HonorificTitle = reader.ReadString();
            //消費税印字区分
            temp.ConsTaxPrtCdRF = reader.ReadInt32();
            // --- ADD 2009/12/31 ---------->>>>>
            //伝票備考桁数
            temp.SlipNoteCharCnt = reader.ReadInt32();
            //伝票備考２桁数
            temp.SlipNote2CharCnt = reader.ReadInt32();
            //伝票備考３桁数
            temp.SlipNote3CharCnt = reader.ReadInt32();
            // --- ADD 2009/12/31 ----------<<<<<

            // ---ADD 2010/08/06 ------------------------------------------------------------>>>>>
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //更新フラグ
            temp.UpdateFlag = reader.ReadInt32();
            // ---ADD 2010/08/06 ------------------------------------------------------------<<<<<

            // ---ADD 2011/02/16 ------------------------------------------------------------>>>>>
            //自社名印字拡大区分
            temp.EntNmPrtExpDiv = reader.ReadInt32();
            // ---ADD 2011/02/16 ------------------------------------------------------------<<<<<

            // ---ADD 2011/07/19 ------------------------------------------------------------>>>>>
            //SCM回答マーク印字区分
            temp.SCMAnsMarkPrtDiv = reader.ReadInt32();
            //通常発行マーク
            temp.NormalPrtMark = reader.ReadString();
            //SCM手動回答マーク
            temp.SCMManualAnsMark = reader.ReadString();
            //SCM自動回答マーク
            temp.SCMAutoAnsMark = reader.ReadString();
            // ---ADD 2011/07/19 ------------------------------------------------------------<<<<<
            
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
        /// <returns>SlipPrtSetWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SlipPrtSetWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                SlipPrtSetWork temp = GetSlipPrtSetWork(reader, serInfo);
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
                    retValue = (SlipPrtSetWork[])lst.ToArray(typeof(SlipPrtSetWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}


