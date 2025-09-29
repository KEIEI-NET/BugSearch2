using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   DmdPrtPtnWork
    /// <summary>
    ///                      請求書印刷パターンワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   請求書印刷パターンワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/26</br>
    /// <br>Genarated Date   :   2008/06/09  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2010/02/18  30531 大矢睦美</br>
    /// <br>                 :   注釈印字区分追加</br> 
    /// <br>Update Note      :   2011/02/16  施ヘイ中</br> 																								
    /// <br>                 :   自社名印字区分を追加</br> 																								
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class DmdPrtPtnWork : IFileHeader
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

        /// <summary>データ入力システム</summary>
        /// <remarks>0:共通,1:整備,2:鈑金,3:車販</remarks>
        private Int32 _dataInputSystem;

        /// <summary>伝票印刷種別</summary>
        /// <remarks>50:合計請求書,60:明細請求書,70:伝票合計請求書,80:領収書</remarks>
        private Int32 _slipPrtKind;

        /// <summary>伝票印刷設定用帳票ID</summary>
        /// <remarks>伝票印刷設定用</remarks>
        private string _slipPrtSetPaperId = "";

        /// <summary>伝票コメント</summary>
        private string _slipComment = "";

        /// <summary>出力ファイル名</summary>
        /// <remarks>フォームファイルID or フォーマットファイルID</remarks>
        private string _outputFormFileName = "";

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

        /// <summary>複写枚数</summary>
        private Int32 _copyCount;

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

        /// <summary>請求書タイトル</summary>
        private string _dmdFormTitle = "";

        /// <summary>請求書タイトル２</summary>
        /// <remarks>控え</remarks>
        private string _dmdFormTitle2 = "";

        /// <summary>請求書コメント１</summary>
        private string _dmdFormComent1 = "";

        /// <summary>請求書コメント２</summary>
        private string _dmdFormComent2 = "";

        /// <summary>請求書コメント３</summary>
        private string _dmdFormComent3 = "";

        /// <summary>請求明細摘要区分</summary>
        /// <remarks>0:印字しない 1:品番 2:定価</remarks>
        private Int32 _dmdDtlOutlineCode;

        /// <summary>請求明細書印字順位区分</summary>
        /// <remarks>0:計上日+伝票番号 1:得意先+計上日+伝票番号</remarks>
        private Int32 _dmdDtlPtnOdrDiv;

        /// <summary>伝票計印字有無</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _slipTtlPrtDiv;

        /// <summary>計上日計印字有無</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _addDayTtlPrtDiv;

        /// <summary>得意先計印字有無</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _customerTtlPrtDiv;

        /// <summary>明細金額ゼロ時印字有無</summary>
        /// <remarks>0:印字する 1:印字しない</remarks>
        private Int32 _dtlPrcZeroPrtDiv;

        /// <summary>入金明細印字有無区分</summary>
        /// <remarks>0:印字しない 1:印字する(合計)  1:印字する (明細)</remarks>
        private Int32 _depoDtlPrcPrtDiv;

        /// <summary>請求書敬称</summary>
        /// <remarks>請求書用の敬称</remarks>
        private string _billHonorificTtl = "";

        /// <summary>標準価格印字区分</summary>
        /// <remarks>0:印字しない 1:印字する 2:掛率＜１</remarks>
        private Int32 _listPricePrtCd;

        /// <summary>品番印字区分</summary>
        /// <remarks>0:印字しない,1:印字する</remarks>
        private Int32 _partsNoPrtCd;

        // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
        /// <summary>注釈印字区分</summary>
        /// <remarks>0:印字する,1:印字しない</remarks>
        private Int32 _annotationPrtCd;
        // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

        // --- ADD  2011/02/16 ---------->>>>>
        /// <summary>自社名印字区分</summary>
        /// <remarks>0:標準1:自社名2:拠点名3:ビットマップ4:印字しない</remarks>
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
        /// <summary>更新アセンブリID1プロパティ</summary>
        /// <value>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新アセンブリID1プロパティ</br>
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
        /// <value>50:合計請求書,60:明細請求書,70:伝票合計請求書,80:領収書</value>
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

        /// public propaty name  :  DmdTtlFormTitle1
        /// <summary>請求 鑑タイトル１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求 鑑タイトル１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DmdTtlFormTitle1
        {
            get { return _dmdTtlFormTitle1; }
            set { _dmdTtlFormTitle1 = value; }
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
            get { return _dmdTtlFormTitle2; }
            set { _dmdTtlFormTitle2 = value; }
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
            get { return _dmdTtlFormTitle3; }
            set { _dmdTtlFormTitle3 = value; }
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
            get { return _dmdTtlFormTitle4; }
            set { _dmdTtlFormTitle4 = value; }
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
            get { return _dmdTtlFormTitle5; }
            set { _dmdTtlFormTitle5 = value; }
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
            get { return _dmdTtlFormTitle6; }
            set { _dmdTtlFormTitle6 = value; }
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
            get { return _dmdTtlFormTitle7; }
            set { _dmdTtlFormTitle7 = value; }
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
            get { return _dmdTtlFormTitle8; }
            set { _dmdTtlFormTitle8 = value; }
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
            get { return _dmdTtlSetItemDiv1; }
            set { _dmdTtlSetItemDiv1 = value; }
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
            get { return _dmdTtlSetItemDiv2; }
            set { _dmdTtlSetItemDiv2 = value; }
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
            get { return _dmdTtlSetItemDiv3; }
            set { _dmdTtlSetItemDiv3 = value; }
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
            get { return _dmdTtlSetItemDiv4; }
            set { _dmdTtlSetItemDiv4 = value; }
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
            get { return _dmdTtlSetItemDiv5; }
            set { _dmdTtlSetItemDiv5 = value; }
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
            get { return _dmdTtlSetItemDiv6; }
            set { _dmdTtlSetItemDiv6 = value; }
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
            get { return _dmdTtlSetItemDiv7; }
            set { _dmdTtlSetItemDiv7 = value; }
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
            get { return _dmdTtlSetItemDiv8; }
            set { _dmdTtlSetItemDiv8 = value; }
        }

        /// public propaty name  :  DmdFormTitle
        /// <summary>請求書タイトルプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書タイトルプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DmdFormTitle
        {
            get { return _dmdFormTitle; }
            set { _dmdFormTitle = value; }
        }

        /// public propaty name  :  DmdFormTitle2
        /// <summary>請求書タイトル２プロパティ</summary>
        /// <value>控え</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書タイトル２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DmdFormTitle2
        {
            get { return _dmdFormTitle2; }
            set { _dmdFormTitle2 = value; }
        }

        /// public propaty name  :  DmdFormComent1
        /// <summary>請求書コメント１プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書コメント１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DmdFormComent1
        {
            get { return _dmdFormComent1; }
            set { _dmdFormComent1 = value; }
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
            get { return _dmdFormComent2; }
            set { _dmdFormComent2 = value; }
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
            get { return _dmdFormComent3; }
            set { _dmdFormComent3 = value; }
        }

        /// public propaty name  :  DmdDtlOutlineCode
        /// <summary>請求明細摘要区分プロパティ</summary>
        /// <value>0:印字しない 1:品番 2:定価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求明細摘要区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DmdDtlOutlineCode
        {
            get { return _dmdDtlOutlineCode; }
            set { _dmdDtlOutlineCode = value; }
        }

        /// public propaty name  :  DmdDtlPtnOdrDiv
        /// <summary>請求明細書印字順位区分プロパティ</summary>
        /// <value>0:計上日+伝票番号 1:得意先+計上日+伝票番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求明細書印字順位区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DmdDtlPtnOdrDiv
        {
            get { return _dmdDtlPtnOdrDiv; }
            set { _dmdDtlPtnOdrDiv = value; }
        }

        /// public propaty name  :  SlipTtlPrtDiv
        /// <summary>伝票計印字有無プロパティ</summary>
        /// <value>0:印字する 1:印字しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票計印字有無プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipTtlPrtDiv
        {
            get { return _slipTtlPrtDiv; }
            set { _slipTtlPrtDiv = value; }
        }

        /// public propaty name  :  AddDayTtlPrtDiv
        /// <summary>計上日計印字有無プロパティ</summary>
        /// <value>0:印字する 1:印字しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   計上日計印字有無プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AddDayTtlPrtDiv
        {
            get { return _addDayTtlPrtDiv; }
            set { _addDayTtlPrtDiv = value; }
        }

        /// public propaty name  :  CustomerTtlPrtDiv
        /// <summary>得意先計印字有無プロパティ</summary>
        /// <value>0:印字する 1:印字しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先計印字有無プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerTtlPrtDiv
        {
            get { return _customerTtlPrtDiv; }
            set { _customerTtlPrtDiv = value; }
        }

        /// public propaty name  :  DtlPrcZeroPrtDiv
        /// <summary>明細金額ゼロ時印字有無プロパティ</summary>
        /// <value>0:印字する 1:印字しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細金額ゼロ時印字有無プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DtlPrcZeroPrtDiv
        {
            get { return _dtlPrcZeroPrtDiv; }
            set { _dtlPrcZeroPrtDiv = value; }
        }

        /// public propaty name  :  DepoDtlPrcPrtDiv
        /// <summary>入金明細印字有無区分プロパティ</summary>
        /// <value>0:印字しない 1:印字する(合計)  1:印字する (明細)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金明細印字有無区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepoDtlPrcPrtDiv
        {
            get { return _depoDtlPrcPrtDiv; }
            set { _depoDtlPrcPrtDiv = value; }
        }

        /// public propaty name  :  BillHonorificTtl
        /// <summary>請求書敬称プロパティ</summary>
        /// <value>請求書用の敬称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillHonorificTtl
        {
            get { return _billHonorificTtl; }
            set { _billHonorificTtl = value; }
        }

        /// public propaty name  :  ListPricePrtCd
        /// <summary>標準価格印字区分プロパティ</summary>
        /// <value>0:印字しない 1:印字する 2:掛率＜１</value>
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
        /// <value>0:印字しない,1:印字する</value>
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
        /// <br>note             :   自社名印字区分を追加</br>
        /// <br>Programer        :   2011/02/16  施ヘイ中</br>
        /// </remarks>
        public Int32 CoNmPrintOutCd
        {
            get { return _coNmPrintOutCd; }
            set { _coNmPrintOutCd = value; }
        }
        // --- ADD  2011/02/16 ----------<<<<<

        /// <summary>
        /// 請求書印刷パターンワークコンストラクタ
        /// </summary>
        /// <returns>DmdPrtPtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DmdPrtPtnWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DmdPrtPtnWork()
        {
        }

    }

    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>DmdPrtPtnWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   DmdPrtPtnWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// <br>Update Note      :   2011/02/16  施ヘイ中</br> 																								
    /// <br>                 :   自社名印字区分を追加</br> 
    /// </remarks>
    public class DmdPrtPtnWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DmdPrtPtnWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  DmdPrtPtnWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is DmdPrtPtnWork || graph is ArrayList || graph is DmdPrtPtnWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(DmdPrtPtnWork).FullName));

            if (graph != null && graph is DmdPrtPtnWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.DmdPrtPtnWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is DmdPrtPtnWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((DmdPrtPtnWork[])graph).Length;
            }
            else if (graph is DmdPrtPtnWork)
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
            //更新アセンブリID1
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
            //出力ファイル名
            serInfo.MemberInfo.Add(typeof(string)); //OutputFormFileName
            //上余白
            serInfo.MemberInfo.Add(typeof(Double)); //TopMargin
            //左余白
            serInfo.MemberInfo.Add(typeof(Double)); //LeftMargin
            //右余白
            serInfo.MemberInfo.Add(typeof(Double)); //RightMargin
            //下余白
            serInfo.MemberInfo.Add(typeof(Double)); //BottomMargin
            //複写枚数
            serInfo.MemberInfo.Add(typeof(Int32)); //CopyCount
            //請求 鑑タイトル１
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle1
            //請求 鑑タイトル２
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle2
            //請求 鑑タイトル３
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle3
            //請求 鑑タイトル４
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle4
            //請求 鑑タイトル５
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle5
            //請求 鑑タイトル６
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle6
            //請求 鑑タイトル７
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle7
            //請求 鑑タイトル８
            serInfo.MemberInfo.Add(typeof(string)); //DmdTtlFormTitle8
            //請求 鑑設定項目区分１
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv1
            //請求 鑑設定項目区分２
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv2
            //請求 鑑設定項目区分３
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv3
            //請求 鑑設定項目区分４
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv4
            //請求 鑑設定項目区分５
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv5
            //請求 鑑設定項目区分６
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv6
            //請求 鑑設定項目区分７
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv7
            //請求 鑑設定項目区分８
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdTtlSetItemDiv8
            //請求書タイトル
            serInfo.MemberInfo.Add(typeof(string)); //DmdFormTitle
            //請求書タイトル２
            serInfo.MemberInfo.Add(typeof(string)); //DmdFormTitle2
            //請求書コメント１
            serInfo.MemberInfo.Add(typeof(string)); //DmdFormComent1
            //請求書コメント２
            serInfo.MemberInfo.Add(typeof(string)); //DmdFormComent2
            //請求書コメント３
            serInfo.MemberInfo.Add(typeof(string)); //DmdFormComent3
            //請求明細摘要区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdDtlOutlineCode
            //請求明細書印字順位区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DmdDtlPtnOdrDiv
            //伝票計印字有無
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipTtlPrtDiv
            //計上日計印字有無
            serInfo.MemberInfo.Add(typeof(Int32)); //AddDayTtlPrtDiv
            //得意先計印字有無
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerTtlPrtDiv
            //明細金額ゼロ時印字有無
            serInfo.MemberInfo.Add(typeof(Int32)); //DtlPrcZeroPrtDiv
            //入金明細印字有無区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DepoDtlPrcPrtDiv
            //請求書敬称
            serInfo.MemberInfo.Add(typeof(string)); //BillHonorificTtl
            //標準価格印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ListPricePrtCd
            //品番印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PartsNoPrtCd
            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            //注釈印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AnnotationPrtCd
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            //自社名印字区分
            serInfo.MemberInfo.Add(typeof(Int32));
            // --- ADD  2011/02/16 ----------<<<<<

            serInfo.Serialize(writer, serInfo);
            if (graph is DmdPrtPtnWork)
            {
                DmdPrtPtnWork temp = (DmdPrtPtnWork)graph;

                SetDmdPrtPtnWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is DmdPrtPtnWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((DmdPrtPtnWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (DmdPrtPtnWork temp in lst)
                {
                    SetDmdPrtPtnWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// DmdPrtPtnWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- UPD  大矢睦美  2010/02/18 ---------->>>>>
        //private const int currentMemberCount = 49;
        // --- UPD  2011/02/16 ---------->>>>>
        //private const int currentMemberCount = 50;
        private const int currentMemberCount = 51;
        // --- UPD  2011/02/16 ----------<<<<
        // --- UPD  大矢睦美  2010/02/18 ----------<<<<<

        /// <summary>
        ///  DmdPrtPtnWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   DmdPrtPtnWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/02/16  施ヘイ中</br> 																								
        /// <br>                 :   自社名印字区分を追加</br> 
        /// </remarks>
        private void SetDmdPrtPtnWork(System.IO.BinaryWriter writer, DmdPrtPtnWork temp)
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
            //更新アセンブリID1
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
            //出力ファイル名
            writer.Write(temp.OutputFormFileName);
            //上余白
            writer.Write(temp.TopMargin);
            //左余白
            writer.Write(temp.LeftMargin);
            //右余白
            writer.Write(temp.RightMargin);
            //下余白
            writer.Write(temp.BottomMargin);
            //複写枚数
            writer.Write(temp.CopyCount);
            //請求 鑑タイトル１
            writer.Write(temp.DmdTtlFormTitle1);
            //請求 鑑タイトル２
            writer.Write(temp.DmdTtlFormTitle2);
            //請求 鑑タイトル３
            writer.Write(temp.DmdTtlFormTitle3);
            //請求 鑑タイトル４
            writer.Write(temp.DmdTtlFormTitle4);
            //請求 鑑タイトル５
            writer.Write(temp.DmdTtlFormTitle5);
            //請求 鑑タイトル６
            writer.Write(temp.DmdTtlFormTitle6);
            //請求 鑑タイトル７
            writer.Write(temp.DmdTtlFormTitle7);
            //請求 鑑タイトル８
            writer.Write(temp.DmdTtlFormTitle8);
            //請求 鑑設定項目区分１
            writer.Write(temp.DmdTtlSetItemDiv1);
            //請求 鑑設定項目区分２
            writer.Write(temp.DmdTtlSetItemDiv2);
            //請求 鑑設定項目区分３
            writer.Write(temp.DmdTtlSetItemDiv3);
            //請求 鑑設定項目区分４
            writer.Write(temp.DmdTtlSetItemDiv4);
            //請求 鑑設定項目区分５
            writer.Write(temp.DmdTtlSetItemDiv5);
            //請求 鑑設定項目区分６
            writer.Write(temp.DmdTtlSetItemDiv6);
            //請求 鑑設定項目区分７
            writer.Write(temp.DmdTtlSetItemDiv7);
            //請求 鑑設定項目区分８
            writer.Write(temp.DmdTtlSetItemDiv8);
            //請求書タイトル
            writer.Write(temp.DmdFormTitle);
            //請求書タイトル２
            writer.Write(temp.DmdFormTitle2);
            //請求書コメント１
            writer.Write(temp.DmdFormComent1);
            //請求書コメント２
            writer.Write(temp.DmdFormComent2);
            //請求書コメント３
            writer.Write(temp.DmdFormComent3);
            //請求明細摘要区分
            writer.Write(temp.DmdDtlOutlineCode);
            //請求明細書印字順位区分
            writer.Write(temp.DmdDtlPtnOdrDiv);
            //伝票計印字有無
            writer.Write(temp.SlipTtlPrtDiv);
            //計上日計印字有無
            writer.Write(temp.AddDayTtlPrtDiv);
            //得意先計印字有無
            writer.Write(temp.CustomerTtlPrtDiv);
            //明細金額ゼロ時印字有無
            writer.Write(temp.DtlPrcZeroPrtDiv);
            //入金明細印字有無区分
            writer.Write(temp.DepoDtlPrcPrtDiv);
            //請求書敬称
            writer.Write(temp.BillHonorificTtl);
            //標準価格印字区分
            writer.Write(temp.ListPricePrtCd);
            //品番印字区分
            writer.Write(temp.PartsNoPrtCd);
            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            //注釈印字区分
            writer.Write(temp.AnnotationPrtCd);
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<
            // --- ADD  2011/02/16 ---------->>>>>
            writer.Write(temp.CoNmPrintOutCd);
            // --- ADD  2011/02/16 ----------<<<<<

        }

        /// <summary>
        ///  DmdPrtPtnWorkインスタンス取得
        /// </summary>
        /// <returns>DmdPrtPtnWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DmdPrtPtnWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2011/02/16  施ヘイ中</br> 																								
        /// <br>                 :   自社名印字区分を追加</br> 
        /// </remarks>
        private DmdPrtPtnWork GetDmdPrtPtnWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            DmdPrtPtnWork temp = new DmdPrtPtnWork();

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
            //更新アセンブリID1
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
            //出力ファイル名
            temp.OutputFormFileName = reader.ReadString();
            //上余白
            temp.TopMargin = reader.ReadDouble();
            //左余白
            temp.LeftMargin = reader.ReadDouble();
            //右余白
            temp.RightMargin = reader.ReadDouble();
            //下余白
            temp.BottomMargin = reader.ReadDouble();
            //複写枚数
            temp.CopyCount = reader.ReadInt32();
            //請求 鑑タイトル１
            temp.DmdTtlFormTitle1 = reader.ReadString();
            //請求 鑑タイトル２
            temp.DmdTtlFormTitle2 = reader.ReadString();
            //請求 鑑タイトル３
            temp.DmdTtlFormTitle3 = reader.ReadString();
            //請求 鑑タイトル４
            temp.DmdTtlFormTitle4 = reader.ReadString();
            //請求 鑑タイトル５
            temp.DmdTtlFormTitle5 = reader.ReadString();
            //請求 鑑タイトル６
            temp.DmdTtlFormTitle6 = reader.ReadString();
            //請求 鑑タイトル７
            temp.DmdTtlFormTitle7 = reader.ReadString();
            //請求 鑑タイトル８
            temp.DmdTtlFormTitle8 = reader.ReadString();
            //請求 鑑設定項目区分１
            temp.DmdTtlSetItemDiv1 = reader.ReadInt32();
            //請求 鑑設定項目区分２
            temp.DmdTtlSetItemDiv2 = reader.ReadInt32();
            //請求 鑑設定項目区分３
            temp.DmdTtlSetItemDiv3 = reader.ReadInt32();
            //請求 鑑設定項目区分４
            temp.DmdTtlSetItemDiv4 = reader.ReadInt32();
            //請求 鑑設定項目区分５
            temp.DmdTtlSetItemDiv5 = reader.ReadInt32();
            //請求 鑑設定項目区分６
            temp.DmdTtlSetItemDiv6 = reader.ReadInt32();
            //請求 鑑設定項目区分７
            temp.DmdTtlSetItemDiv7 = reader.ReadInt32();
            //請求 鑑設定項目区分８
            temp.DmdTtlSetItemDiv8 = reader.ReadInt32();
            //請求書タイトル
            temp.DmdFormTitle = reader.ReadString();
            //請求書タイトル２
            temp.DmdFormTitle2 = reader.ReadString();
            //請求書コメント１
            temp.DmdFormComent1 = reader.ReadString();
            //請求書コメント２
            temp.DmdFormComent2 = reader.ReadString();
            //請求書コメント３
            temp.DmdFormComent3 = reader.ReadString();
            //請求明細摘要区分
            temp.DmdDtlOutlineCode = reader.ReadInt32();
            //請求明細書印字順位区分
            temp.DmdDtlPtnOdrDiv = reader.ReadInt32();
            //伝票計印字有無
            temp.SlipTtlPrtDiv = reader.ReadInt32();
            //計上日計印字有無
            temp.AddDayTtlPrtDiv = reader.ReadInt32();
            //得意先計印字有無
            temp.CustomerTtlPrtDiv = reader.ReadInt32();
            //明細金額ゼロ時印字有無
            temp.DtlPrcZeroPrtDiv = reader.ReadInt32();
            //入金明細印字有無区分
            temp.DepoDtlPrcPrtDiv = reader.ReadInt32();
            //請求書敬称
            temp.BillHonorificTtl = reader.ReadString();
            //標準価格印字区分
            temp.ListPricePrtCd = reader.ReadInt32();
            //品番印字区分
            temp.PartsNoPrtCd = reader.ReadInt32();
            // --- ADD  大矢睦美  2010/02/18 ---------->>>>>
            //注釈印字区分
            temp.AnnotationPrtCd = reader.ReadInt32();
            // --- ADD  大矢睦美  2010/02/18 ----------<<<<<

            // --- ADD  2011/02/16 ---------->>>>>
            //自社名印字区分
            temp.CoNmPrintOutCd = reader.ReadInt32();
            // --- ADD  2011/02/16 ----------<<<<<

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
        /// <returns>DmdPrtPtnWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   DmdPrtPtnWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for ( int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                DmdPrtPtnWork temp = GetDmdPrtPtnWork(reader, serInfo);
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
                    retValue = (DmdPrtPtnWork[])lst.ToArray(typeof(DmdPrtPtnWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }
}

