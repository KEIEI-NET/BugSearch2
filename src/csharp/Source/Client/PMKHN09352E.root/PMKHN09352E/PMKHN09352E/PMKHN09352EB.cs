//**********************************************************************//
// システム         ：.NSシリーズ
// プログラム名称   ：得意先一括修正
// プログラム概要   ：得意先の変更を一括で行う
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// 履歴
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30414 忍 幸史
// 修正日    2008/11/27     修正内容：新規作成
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30413 犬飼
// 修正日    2009/04/07     修正内容：Mantis【13030】領収書出力区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/01/29     修正内容：Mantis【14950】請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加
// ---------------------------------------------------------------------//
// 管理番号                 作成担当：30434 工藤
// 修正日    2010/02/24     修正内容：Mantis【15033】伝票印刷区分×5を追加
// ---------------------------------------------------------------------//

using System;
using System.Collections;

using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CustomerCustomerChangeResult
    /// <summary>
    ///                      得意先一括修正クラスワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先一括修正クラスワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/11/20  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CustomerCustomerChangeResult
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

        /// <summary>得意先コード</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private Int32 _customerCode;

        /// <summary>得意先サブコード</summary>
        private string _customerSubCode = "";

        /// <summary>名称</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _name = "";

        /// <summary>名称2</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _name2 = "";

        /// <summary>敬称</summary>
        private string _honorificTitle = "";

        /// <summary>カナ</summary>
        private string _kana = "";

        /// <summary>得意先略称</summary>
        private string _customerSnm = "";

        /// <summary>諸口コード</summary>
        /// <remarks>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</remarks>
        private Int32 _outputNameCode;

        /// <summary>諸口名称</summary>
        private string _outputName = "";

        /// <summary>個人・法人区分</summary>
        /// <remarks>0:個人,1:法人,2:大口法人,3:業者,4:社員</remarks>
        private Int32 _corporateDivCode;

        /// <summary>得意先属性区分</summary>
        /// <remarks>0:正式取引先,8:社内取引先,9:諸口口座</remarks>
        private Int32 _customerAttributeDiv;

        /// <summary>職種コード</summary>
        private Int32 _jobTypeCode;

        /// <summary>職種名称</summary>
        private string _jobTypeName = "";

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>業種名称</summary>
        private string _businessTypeName = "";

        /// <summary>販売エリアコード</summary>
        private Int32 _salesAreaCode;

        /// <summary>販売エリア名称</summary>
        private string _salesAreaName = "";

        /// <summary>郵便番号</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _postNo = "";

        /// <summary>住所1（都道府県市区郡・町村・字）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _address1 = "";

        /// <summary>住所3（番地）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _address3 = "";

        /// <summary>住所4（アパート名称）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _address4 = "";

        /// <summary>電話番号（自宅）</summary>
        /// <remarks>ハイフンを含めた16桁の番号</remarks>
        private string _homeTelNo = "";

        /// <summary>電話番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _officeTelNo = "";

        /// <summary>電話番号（携帯）</summary>
        private string _portableTelNo = "";

        /// <summary>FAX番号（自宅）</summary>
        private string _homeFaxNo = "";

        /// <summary>FAX番号（勤務先）</summary>
        /// <remarks>納入先の場合の使用可能項目</remarks>
        private string _officeFaxNo = "";

        /// <summary>電話番号（その他）</summary>
        private string _othersTelNo = "";

        /// <summary>主連絡先区分</summary>
        /// <remarks>0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</remarks>
        private Int32 _mainContactCode;

        /// <summary>電話番号（検索用下4桁）</summary>
        private string _searchTelNo = "";

        /// <summary>管理拠点コード</summary>
        private string _mngSectionCode = "";

        /// <summary>管理拠点名称</summary>
        private string _mngSectionName = "";

        /// <summary>入力拠点コード</summary>
        private string _inpSectionCode = "";

        /// <summary>得意先分析コード1</summary>
        private Int32 _custAnalysCode1;

        /// <summary>得意先分析コード2</summary>
        private Int32 _custAnalysCode2;

        /// <summary>得意先分析コード3</summary>
        private Int32 _custAnalysCode3;

        /// <summary>得意先分析コード4</summary>
        private Int32 _custAnalysCode4;

        /// <summary>得意先分析コード5</summary>
        private Int32 _custAnalysCode5;

        /// <summary>得意先分析コード6</summary>
        private Int32 _custAnalysCode6;

        /// <summary>請求書出力区分コード</summary>
        /// <remarks>0:請求書発行する,1:しない</remarks>
        private Int32 _billOutputCode;

        /// <summary>請求書出力区分名称</summary>
        private string _billOutputName = "";

        /// <summary>締日</summary>
        /// <remarks>DD</remarks>
        private Int32 _totalDay;

        /// <summary>集金月区分コード</summary>
        /// <remarks>0:当月,1:翌月,2:翌々月</remarks>
        private Int32 _collectMoneyCode;

        /// <summary>集金月区分名称</summary>
        /// <remarks>当月,翌月,翌々月</remarks>
        private string _collectMoneyName = "";

        /// <summary>集金日</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>回収条件</summary>
        /// <remarks>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</remarks>
        private Int32 _collectCond;

        /// <summary>回収サイト</summary>
        /// <remarks>手形サイト　180等</remarks>
        private Int32 _collectSight;

        /// <summary>請求先コード</summary>
        /// <remarks>請求先得意先。納入先の場合の使用可能項目</remarks>
        private Int32 _claimCode;

        /// <summary>請求先名称</summary>
        private string _claimName = "";

        /// <summary>請求先名称2</summary>
        private string _claimName2 = "";

        /// <summary>請求先略所</summary>
        private string _claimSnm = "";

        /// <summary>取引中止日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _transStopDate;

        /// <summary>DM出力区分</summary>
        /// <remarks>0:出力する,1:出力しない</remarks>
        private Int32 _dmOutCode;

        /// <summary>DM出力区分名称</summary>
        /// <remarks>全角で管理</remarks>
        private string _dmOutName = "";

        /// <summary>主送信先メールアドレス区分</summary>
        /// <remarks>0:メールアドレス1,1:メールアドレス2</remarks>
        private Int32 _mainSendMailAddrCd;

        /// <summary>メールアドレス種別コード1</summary>
        /// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
        private Int32 _mailAddrKindCode1;

        /// <summary>メールアドレス種別名称1</summary>
        private string _mailAddrKindName1 = "";

        /// <summary>メールアドレス1</summary>
        private string _mailAddress1 = "";

        /// <summary>メール送信区分コード1</summary>
        /// <remarks>0:非送信,1:送信</remarks>
        private Int32 _mailSendCode1;

        /// <summary>メール送信区分名称1</summary>
        private string _mailSendName1 = "";

        /// <summary>メールアドレス種別コード2</summary>
        /// <remarks>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</remarks>
        private Int32 _mailAddrKindCode2;

        /// <summary>メールアドレス種別名称2</summary>
        private string _mailAddrKindName2 = "";

        /// <summary>メールアドレス2</summary>
        private string _mailAddress2 = "";

        /// <summary>メール送信区分コード2</summary>
        /// <remarks>0:非送信,1:送信</remarks>
        private Int32 _mailSendCode2;

        /// <summary>メール送信区分名称2</summary>
        private string _mailSendName2 = "";

        /// <summary>顧客担当従業員コード</summary>
        /// <remarks>文字型</remarks>
        private string _customerAgentCd = "";

        /// <summary>顧客担当従業員名称</summary>
        private string _customerAgentNm = "";

        /// <summary>集金担当従業員コード</summary>
        private string _billCollecterCd = "";

        /// <summary>旧顧客担当従業員コード</summary>
        private string _oldCustomerAgentCd = "";

        /// <summary>旧顧客担当従業員名称</summary>
        private string _oldCustomerAgentNm = "";

        /// <summary>顧客担当変更日</summary>
        /// <remarks>YYYYMMDD</remarks>
        private DateTime _custAgentChgDate;

        /// <summary>業販先区分</summary>
        /// <remarks>0:業販先以外,1:業販先,2:納入先</remarks>
        private Int32 _acceptWholeSale;

        /// <summary>与信管理区分</summary>
        private Int32 _creditMngCode;

        /// <summary>入金消込区分</summary>
        /// <remarks>PM(0:しない,1:する) G/D( 0:しない,1:する(請求別),2:する(納品別)）</remarks>
        private Int32 _depoDelCode;

        /// <summary>売掛区分</summary>
        /// <remarks>0:売掛なし,1:売掛</remarks>
        private Int32 _accRecDivCd;

        /// <summary>相手伝票番号管理区分</summary>
        /// <remarks>0:しない　1:する</remarks>
        private Int32 _custSlipNoMngCd;

        /// <summary>純正区分</summary>
        /// <remarks>0:純正、1:その他（PMは優良）　</remarks>
        private Int32 _pureCode;

        /// <summary>得意先消費税転嫁方式参照区分</summary>
        /// <remarks>0:税率設定マスタを参照　1:得意先マスタを参照</remarks>
        private Int32 _custCTaXLayRefCd;

        /// <summary>消費税転嫁方式</summary>
        /// <remarks>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</remarks>
        private Int32 _consTaxLayMethod;

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// <summary>総額表示方法参照区分</summary>
        /// <remarks>0:全体設定参照 1:得意先参照</remarks>
        private Int32 _totalAmntDspWayRef;

        /// <summary>銀行口座1</summary>
        private string _accountNoInfo1 = "";

        /// <summary>銀行口座2</summary>
        private string _accountNoInfo2 = "";

        /// <summary>銀行口座3</summary>
        private string _accountNoInfo3 = "";

        /// <summary>売上単価端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesUnPrcFrcProcCd;

        /// <summary>売上金額端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesMoneyFrcProcCd;

        /// <summary>売上消費税端数処理コード</summary>
        /// <remarks>0の場合は 標準設定とする。</remarks>
        private Int32 _salesCnsTaxFrcProcCd;

        /// <summary>得意先伝票番号区分</summary>
        /// <remarks>0:使用しない,1:連番,2:締毎,3:期末</remarks>
        private Int32 _customerSlipNoDiv;

        /// <summary>次回勘定開始日</summary>
        /// <remarks>01～31まで（省略可能）</remarks>
        private Int32 _nTimeCalcStDate;

        /// <summary>得意先担当者</summary>
        /// <remarks>得意先（仕入先）の問い合わせ先社員名</remarks>
        private string _customerAgent = "";

        /// <summary>請求拠点コード</summary>
        /// <remarks>請求を行う拠点</remarks>
        private string _claimSectionCode = "";

        /// <summary>請求拠点名称</summary>
        /// <remarks>拠点ガイド略称</remarks>
        private string _claimSectionName = "";

        /// <summary>車輌管理区分</summary>
        /// <remarks>0:しない、1:登録(確認)、2:登録(自動) 3:登録無</remarks>
        private Int32 _carMngDivCd;

        /// <summary>品番印字区分(請求書)</summary>
        /// <remarks>0:商品マスタ、1:有、2:無</remarks>
        private Int32 _billPartsNoPrtCd;

        /// <summary>品番印字区分(納品書）</summary>
        /// <remarks>0:商品マスタ、1:有、2:無</remarks>
        private Int32 _deliPartsNoPrtCd;

        /// <summary>伝票区分初期値</summary>
        private Int32 _defSalesSlipCd;

        /// <summary>工賃レバレートランク</summary>
        private Int32 _lavorRateRank;

        /// <summary>伝票タイトルパターン</summary>
        /// <remarks>0000:未設定、0100:基本タイトル、0200・・</remarks>
        private Int32 _slipTtlPrn;

        /// <summary>入金銀行コード</summary>
        private Int32 _depoBankCode;

        /// <summary>入金銀行名称</summary>
        private string _depoBankName = "";

        /// <summary>得意先優先倉庫コード</summary>
        private string _custWarehouseCd;

        /// <summary>得意先優先倉庫名称</summary>
        private string _custWarehouseName = "";

        /// <summary>QRコード印刷</summary>
        private Int32 _qrcodePrtCd;

        /// <summary>納品書敬称</summary>
        /// <remarks>納品書用の敬称</remarks>
        private string _deliHonorificTtl = "";

        /// <summary>請求書敬称</summary>
        /// <remarks>請求書用の敬称</remarks>
        private string _billHonorificTtl = "";

        /// <summary>見積書敬称</summary>
        /// <remarks>見積書用の敬称</remarks>
        private string _estmHonorificTtl = "";

        /// <summary>領収書敬称</summary>
        /// <remarks>領収書用の敬称</remarks>
        private string _rectHonorificTtl = "";

        /// <summary>納品書敬称印字区分</summary>
        /// <remarks>0:得意先マスタ 1:全体項目設定参照 2:非印字</remarks>
        private Int32 _deliHonorTtlPrtDiv;

        /// <summary>請求書敬称印字区分</summary>
        /// <remarks>0:得意先マスタ 1:全体項目設定参照 2:非印字</remarks>
        private Int32 _billHonorTtlPrtDiv;

        /// <summary>見積書敬称印字区分</summary>
        /// <remarks>0:得意先マスタ 1:全体項目設定参照 2:非印字</remarks>
        private Int32 _estmHonorTtlPrtDiv;

        /// <summary>領収書敬称印字区分</summary>
        /// <remarks>0:得意先マスタ 1:全体項目設定参照 2:非印字</remarks>
        private Int32 _rectHonorTtlPrtDiv;

        /// <summary>備考1</summary>
        private string _note1 = "";

        /// <summary>備考2</summary>
        private string _note2 = "";

        /// <summary>備考3</summary>
        private string _note3 = "";

        /// <summary>備考4</summary>
        private string _note4 = "";

        /// <summary>備考5</summary>
        private string _note5 = "";

        /// <summary>備考6</summary>
        private string _note6 = "";

        /// <summary>備考7</summary>
        private string _note7 = "";

        /// <summary>備考8</summary>
        private string _note8 = "";

        /// <summary>備考9</summary>
        private string _note9 = "";

        /// <summary>備考10</summary>
        private string _note10 = "";

        /// <summary>与信額[変動情報]</summary>
        /// <remarks>デッドライン</remarks>
        private Int64 _creditMoney;

        /// <summary>警告与信額[変動情報]</summary>
        /// <remarks>警告表示用</remarks>
        private Int64 _warningCreditMoney;

        /// <summary>現在売掛残高[変動情報]</summary>
        /// <remarks>入金データ、売上データ（売掛）を登録する場合にリアルに更新</remarks>
        private Int64 _prsntAccRecBalance;

        /// <summary>純正区分[掛率]</summary>
        /// <remarks>0:純正、1:優良</remarks>
        private Int32 _rateGPureCode;

        /// <summary>商品メーカーコード[掛率]</summary>
        private Int32 _goodsMakerCd;

        /// <summary>得意先掛率グループコード[掛率]</summary>
        private Int32 _custRateGrpCode;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        /// <summary>入力拠点名称</summary>
        private string _inpSectionName = "";

        /// <summary>請求書出力区分名称</summary>
        /// <remarks>請求書発行する,しない</remarks>
        private string _billOutPutCodeNm = "";

        /// <summary>集金担当従業員名称</summary>
        private string _billCollecterNm = "";

        // ADD 2009/04/07 ------>>>
        /// <summary>領収書出力区分コード</summary>
        /// <remarks>0:する,1:しない</remarks>
        private Int32 _receiptOutputCode;
        // ADD 2009/04/07 ------<<<

        // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ---------->>>>>
        /// <summary>納品書出力（売上伝票発行区分）</summary>
        /// <remarks>0:標準 1:未使用 2:使用</remarks>
        private int _salesSlipPrtDiv;

        /// <summary>受注伝票出力（受注伝票発行区分）</summary>
        /// <remarks>0:標準 1:未使用 2:使用</remarks>
        private int _acpOdrrSlipPrtDiv;

        /// <summary>貸出伝票出力（出荷伝票発行区分）</summary>
        /// <remarks>0:標準 1:未使用 2:使用</remarks>
        private int _shipmSlipPrtDiv;

        /// <summary>見積伝票出力（見積伝票発行区分）</summary>
        /// <remarks>0:標準 1:未使用 2:使用</remarks>
        private int _estimatePrtDiv;

        /// <summary>UOE伝票出力（UOE伝票発行区分）</summary>
        /// <remarks>0:標準 1:未使用 2:使用</remarks>
        private int _uoeSlipPrtDiv;
        // ADD 2010/02/24 MANTIS対応[15033]：伝票印刷区分×5を追加 ----------<<<<<

        // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ---------->>>>>
        /// <summary>合計請求書出力区分</summary>
        /// <remarks>0:標準 1:使用 2:未使用</remarks>
        private int _totalBillOutputDiv;

        /// <summary>明細請求書出力区分</summary>
        /// <remarks>0:標準 1:使用 2:未使用</remarks>
        private int _detailBillOutputCode;

        /// <summary>伝票合計請求書出力区分</summary>
        /// <remarks>0:標準 1:使用 2:未使用</remarks>
        private int _slipTtlBillOutputDiv;
        // ADD 2010/01/29 MANTIS対応[14950]：請求書出力区分の削除と合計請求書出力区分、明細請求書出力区分、伝票合計請求書出力区分の追加 ----------<<<<<

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

        /// public propaty name  :  CustomerCode
        /// <summary>得意先コードプロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// public propaty name  :  CustomerSubCode
        /// <summary>得意先サブコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先サブコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSubCode
        {
            get { return _customerSubCode; }
            set { _customerSubCode = value; }
        }

        /// public propaty name  :  Name
        /// <summary>名称プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// public propaty name  :  Name2
        /// <summary>名称2プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Name2
        {
            get { return _name2; }
            set { _name2 = value; }
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

        /// public propaty name  :  Kana
        /// <summary>カナプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   カナプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Kana
        {
            get { return _kana; }
            set { _kana = value; }
        }

        /// public propaty name  :  CustomerSnm
        /// <summary>得意先略称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先略称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSnm
        {
            get { return _customerSnm; }
            set { _customerSnm = value; }
        }

        /// public propaty name  :  OutputNameCode
        /// <summary>諸口コードプロパティ</summary>
        /// <value>0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   諸口コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OutputNameCode
        {
            get { return _outputNameCode; }
            set { _outputNameCode = value; }
        }

        /// public propaty name  :  OutputName
        /// <summary>諸口名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   諸口名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OutputName
        {
            get { return _outputName; }
            set { _outputName = value; }
        }

        /// public propaty name  :  CorporateDivCode
        /// <summary>個人・法人区分プロパティ</summary>
        /// <value>0:個人,1:法人,2:大口法人,3:業者,4:社員</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   個人・法人区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CorporateDivCode
        {
            get { return _corporateDivCode; }
            set { _corporateDivCode = value; }
        }

        /// public propaty name  :  CustomerAttributeDiv
        /// <summary>得意先属性区分プロパティ</summary>
        /// <value>0:正式取引先,8:社内取引先,9:諸口口座</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先属性区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerAttributeDiv
        {
            get { return _customerAttributeDiv; }
            set { _customerAttributeDiv = value; }
        }

        /// public propaty name  :  JobTypeCode
        /// <summary>職種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   職種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JobTypeCode
        {
            get { return _jobTypeCode; }
            set { _jobTypeCode = value; }
        }

        /// public propaty name  :  JobTypeName
        /// <summary>職種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   職種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string JobTypeName
        {
            get { return _jobTypeName; }
            set { _jobTypeName = value; }
        }

        /// public propaty name  :  BusinessTypeCode
        /// <summary>業種コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BusinessTypeCode
        {
            get { return _businessTypeCode; }
            set { _businessTypeCode = value; }
        }

        /// public propaty name  :  BusinessTypeName
        /// <summary>業種名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業種名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BusinessTypeName
        {
            get { return _businessTypeName; }
            set { _businessTypeName = value; }
        }

        /// public propaty name  :  SalesAreaCode
        /// <summary>販売エリアコードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリアコードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesAreaCode
        {
            get { return _salesAreaCode; }
            set { _salesAreaCode = value; }
        }

        /// public propaty name  :  SalesAreaName
        /// <summary>販売エリア名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   販売エリア名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SalesAreaName
        {
            get { return _salesAreaName; }
            set { _salesAreaName = value; }
        }

        /// public propaty name  :  PostNo
        /// <summary>郵便番号プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   郵便番号プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PostNo
        {
            get { return _postNo; }
            set { _postNo = value; }
        }

        /// public propaty name  :  Address1
        /// <summary>住所1（都道府県市区郡・町村・字）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所1（都道府県市区郡・町村・字）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }

        /// public propaty name  :  Address3
        /// <summary>住所3（番地）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所3（番地）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address3
        {
            get { return _address3; }
            set { _address3 = value; }
        }

        /// public propaty name  :  Address4
        /// <summary>住所4（アパート名称）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   住所4（アパート名称）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Address4
        {
            get { return _address4; }
            set { _address4 = value; }
        }

        /// public propaty name  :  HomeTelNo
        /// <summary>電話番号（自宅）プロパティ</summary>
        /// <value>ハイフンを含めた16桁の番号</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeTelNo
        {
            get { return _homeTelNo; }
            set { _homeTelNo = value; }
        }

        /// public propaty name  :  OfficeTelNo
        /// <summary>電話番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeTelNo
        {
            get { return _officeTelNo; }
            set { _officeTelNo = value; }
        }

        /// public propaty name  :  PortableTelNo
        /// <summary>電話番号（携帯）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（携帯）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string PortableTelNo
        {
            get { return _portableTelNo; }
            set { _portableTelNo = value; }
        }

        /// public propaty name  :  HomeFaxNo
        /// <summary>FAX番号（自宅）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（自宅）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string HomeFaxNo
        {
            get { return _homeFaxNo; }
            set { _homeFaxNo = value; }
        }

        /// public propaty name  :  OfficeFaxNo
        /// <summary>FAX番号（勤務先）プロパティ</summary>
        /// <value>納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   FAX番号（勤務先）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OfficeFaxNo
        {
            get { return _officeFaxNo; }
            set { _officeFaxNo = value; }
        }

        /// public propaty name  :  OthersTelNo
        /// <summary>電話番号（その他）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（その他）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OthersTelNo
        {
            get { return _othersTelNo; }
            set { _othersTelNo = value; }
        }

        /// public propaty name  :  MainContactCode
        /// <summary>主連絡先区分プロパティ</summary>
        /// <value>0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主連絡先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MainContactCode
        {
            get { return _mainContactCode; }
            set { _mainContactCode = value; }
        }

        /// public propaty name  :  SearchTelNo
        /// <summary>電話番号（検索用下4桁）プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   電話番号（検索用下4桁）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SearchTelNo
        {
            get { return _searchTelNo; }
            set { _searchTelNo = value; }
        }

        /// public propaty name  :  MngSectionCode
        /// <summary>管理拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionCode
        {
            get { return _mngSectionCode; }
            set { _mngSectionCode = value; }
        }

        /// public propaty name  :  MngSectionName
        /// <summary>管理拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   管理拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MngSectionName
        {
            get { return _mngSectionName; }
            set { _mngSectionName = value; }
        }

        /// public propaty name  :  InpSectionCode
        /// <summary>入力拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InpSectionCode
        {
            get { return _inpSectionCode; }
            set { _inpSectionCode = value; }
        }

        /// public propaty name  :  CustAnalysCode1
        /// <summary>得意先分析コード1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode1
        {
            get { return _custAnalysCode1; }
            set { _custAnalysCode1 = value; }
        }

        /// public propaty name  :  CustAnalysCode2
        /// <summary>得意先分析コード2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode2
        {
            get { return _custAnalysCode2; }
            set { _custAnalysCode2 = value; }
        }

        /// public propaty name  :  CustAnalysCode3
        /// <summary>得意先分析コード3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode3
        {
            get { return _custAnalysCode3; }
            set { _custAnalysCode3 = value; }
        }

        /// public propaty name  :  CustAnalysCode4
        /// <summary>得意先分析コード4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode4
        {
            get { return _custAnalysCode4; }
            set { _custAnalysCode4 = value; }
        }

        /// public propaty name  :  CustAnalysCode5
        /// <summary>得意先分析コード5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode5
        {
            get { return _custAnalysCode5; }
            set { _custAnalysCode5 = value; }
        }

        /// public propaty name  :  CustAnalysCode6
        /// <summary>得意先分析コード6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先分析コード6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustAnalysCode6
        {
            get { return _custAnalysCode6; }
            set { _custAnalysCode6 = value; }
        }

        /// public propaty name  :  BillOutputCode
        /// <summary>請求書出力区分コードプロパティ</summary>
        /// <value>0:請求書発行する,1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書出力区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillOutputCode
        {
            get { return _billOutputCode; }
            set { _billOutputCode = value; }
        }

        /// public propaty name  :  BillOutputName
        /// <summary>請求書出力区分名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書出力区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillOutputName
        {
            get { return _billOutputName; }
            set { _billOutputName = value; }
        }

        /// public propaty name  :  TotalDay
        /// <summary>締日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalDay
        {
            get { return _totalDay; }
            set { _totalDay = value; }
        }

        /// public propaty name  :  CollectMoneyCode
        /// <summary>集金月区分コードプロパティ</summary>
        /// <value>0:当月,1:翌月,2:翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectMoneyCode
        {
            get { return _collectMoneyCode; }
            set { _collectMoneyCode = value; }
        }

        /// public propaty name  :  CollectMoneyName
        /// <summary>集金月区分名称プロパティ</summary>
        /// <value>当月,翌月,翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金月区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CollectMoneyName
        {
            get { return _collectMoneyName; }
            set { _collectMoneyName = value; }
        }

        /// public propaty name  :  CollectMoneyDay
        /// <summary>集金日プロパティ</summary>
        /// <value>DD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectMoneyDay
        {
            get { return _collectMoneyDay; }
            set { _collectMoneyDay = value; }
        }

        /// public propaty name  :  CollectCond
        /// <summary>回収条件プロパティ</summary>
        /// <value>10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収条件プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectCond
        {
            get { return _collectCond; }
            set { _collectCond = value; }
        }

        /// public propaty name  :  CollectSight
        /// <summary>回収サイトプロパティ</summary>
        /// <value>手形サイト　180等</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   回収サイトプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CollectSight
        {
            get { return _collectSight; }
            set { _collectSight = value; }
        }

        /// public propaty name  :  ClaimCode
        /// <summary>請求先コードプロパティ</summary>
        /// <value>請求先得意先。納入先の場合の使用可能項目</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ClaimCode
        {
            get { return _claimCode; }
            set { _claimCode = value; }
        }

        /// public propaty name  :  ClaimName
        /// <summary>請求先名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName
        {
            get { return _claimName; }
            set { _claimName = value; }
        }

        /// public propaty name  :  ClaimName2
        /// <summary>請求先名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimName2
        {
            get { return _claimName2; }
            set { _claimName2 = value; }
        }

        /// public propaty name  :  ClaimSnm
        /// <summary>請求先略所プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求先略所プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSnm
        {
            get { return _claimSnm; }
            set { _claimSnm = value; }
        }

        /// public propaty name  :  TransStopDate
        /// <summary>取引中止日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引中止日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime TransStopDate
        {
            get { return _transStopDate; }
            set { _transStopDate = value; }
        }

        /// public propaty name  :  TransStopDateJpFormal
        /// <summary>取引中止日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引中止日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransStopDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateJpInFormal
        /// <summary>取引中止日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引中止日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransStopDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateAdFormal
        /// <summary>取引中止日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引中止日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransStopDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  TransStopDateAdInFormal
        /// <summary>取引中止日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   取引中止日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string TransStopDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _transStopDate); }
            set { }
        }

        /// public propaty name  :  DmOutCode
        /// <summary>DM出力区分プロパティ</summary>
        /// <value>0:出力する,1:出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DM出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DmOutCode
        {
            get { return _dmOutCode; }
            set { _dmOutCode = value; }
        }

        /// public propaty name  :  DmOutName
        /// <summary>DM出力区分名称プロパティ</summary>
        /// <value>全角で管理</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   DM出力区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DmOutName
        {
            get { return _dmOutName; }
            set { _dmOutName = value; }
        }

        /// public propaty name  :  MainSendMailAddrCd
        /// <summary>主送信先メールアドレス区分プロパティ</summary>
        /// <value>0:メールアドレス1,1:メールアドレス2</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   主送信先メールアドレス区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MainSendMailAddrCd
        {
            get { return _mainSendMailAddrCd; }
            set { _mainSendMailAddrCd = value; }
        }

        /// public propaty name  :  MailAddrKindCode1
        /// <summary>メールアドレス種別コード1プロパティ</summary>
        /// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailAddrKindCode1
        {
            get { return _mailAddrKindCode1; }
            set { _mailAddrKindCode1 = value; }
        }

        /// public propaty name  :  MailAddrKindName1
        /// <summary>メールアドレス種別名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddrKindName1
        {
            get { return _mailAddrKindName1; }
            set { _mailAddrKindName1 = value; }
        }

        /// public propaty name  :  MailAddress1
        /// <summary>メールアドレス1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddress1
        {
            get { return _mailAddress1; }
            set { _mailAddress1 = value; }
        }

        /// public propaty name  :  MailSendCode1
        /// <summary>メール送信区分コード1プロパティ</summary>
        /// <value>0:非送信,1:送信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分コード1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailSendCode1
        {
            get { return _mailSendCode1; }
            set { _mailSendCode1 = value; }
        }

        /// public propaty name  :  MailSendName1
        /// <summary>メール送信区分名称1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分名称1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailSendName1
        {
            get { return _mailSendName1; }
            set { _mailSendName1 = value; }
        }

        /// public propaty name  :  MailAddrKindCode2
        /// <summary>メールアドレス種別コード2プロパティ</summary>
        /// <value>0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailAddrKindCode2
        {
            get { return _mailAddrKindCode2; }
            set { _mailAddrKindCode2 = value; }
        }

        /// public propaty name  :  MailAddrKindName2
        /// <summary>メールアドレス種別名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス種別名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddrKindName2
        {
            get { return _mailAddrKindName2; }
            set { _mailAddrKindName2 = value; }
        }

        /// public propaty name  :  MailAddress2
        /// <summary>メールアドレス2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メールアドレス2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailAddress2
        {
            get { return _mailAddress2; }
            set { _mailAddress2 = value; }
        }

        /// public propaty name  :  MailSendCode2
        /// <summary>メール送信区分コード2プロパティ</summary>
        /// <value>0:非送信,1:送信</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分コード2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MailSendCode2
        {
            get { return _mailSendCode2; }
            set { _mailSendCode2 = value; }
        }

        /// public propaty name  :  MailSendName2
        /// <summary>メール送信区分名称2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メール送信区分名称2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string MailSendName2
        {
            get { return _mailSendName2; }
            set { _mailSendName2 = value; }
        }

        /// public propaty name  :  CustomerAgentCd
        /// <summary>顧客担当従業員コードプロパティ</summary>
        /// <value>文字型</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentCd
        {
            get { return _customerAgentCd; }
            set { _customerAgentCd = value; }
        }

        /// public propaty name  :  CustomerAgentNm
        /// <summary>顧客担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgentNm
        {
            get { return _customerAgentNm; }
            set { _customerAgentNm = value; }
        }

        /// public propaty name  :  BillCollecterCd
        /// <summary>集金担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterCd
        {
            get { return _billCollecterCd; }
            set { _billCollecterCd = value; }
        }

        /// public propaty name  :  OldCustomerAgentCd
        /// <summary>旧顧客担当従業員コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧顧客担当従業員コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldCustomerAgentCd
        {
            get { return _oldCustomerAgentCd; }
            set { _oldCustomerAgentCd = value; }
        }

        /// public propaty name  :  OldCustomerAgentNm
        /// <summary>旧顧客担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   旧顧客担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string OldCustomerAgentNm
        {
            get { return _oldCustomerAgentNm; }
            set { _oldCustomerAgentNm = value; }
        }

        /// public propaty name  :  CustAgentChgDate
        /// <summary>顧客担当変更日プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当変更日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CustAgentChgDate
        {
            get { return _custAgentChgDate; }
            set { _custAgentChgDate = value; }
        }

        /// public propaty name  :  CustAgentChgDateJpFormal
        /// <summary>顧客担当変更日 和暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当変更日 和暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustAgentChgDateJpFormal
        {
            get { return TDateTime.DateTimeToString("GGYYMMDD", _custAgentChgDate); }
            set { }
        }

        /// public propaty name  :  CustAgentChgDateJpInFormal
        /// <summary>顧客担当変更日 和暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当変更日 和暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustAgentChgDateJpInFormal
        {
            get { return TDateTime.DateTimeToString("ggYY/MM/DD", _custAgentChgDate); }
            set { }
        }

        /// public propaty name  :  CustAgentChgDateAdFormal
        /// <summary>顧客担当変更日 西暦プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当変更日 西暦プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustAgentChgDateAdFormal
        {
            get { return TDateTime.DateTimeToString("YYYY/MM/DD", _custAgentChgDate); }
            set { }
        }

        /// public propaty name  :  CustAgentChgDateAdInFormal
        /// <summary>顧客担当変更日 西暦(略)プロパティ</summary>
        /// <value>YYYYMMDD</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客担当変更日 西暦(略)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustAgentChgDateAdInFormal
        {
            get { return TDateTime.DateTimeToString("YY/MM/DD", _custAgentChgDate); }
            set { }
        }

        /// public propaty name  :  AcceptWholeSale
        /// <summary>業販先区分プロパティ</summary>
        /// <value>0:業販先以外,1:業販先,2:納入先</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   業販先区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcceptWholeSale
        {
            get { return _acceptWholeSale; }
            set { _acceptWholeSale = value; }
        }

        /// public propaty name  :  CreditMngCode
        /// <summary>与信管理区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CreditMngCode
        {
            get { return _creditMngCode; }
            set { _creditMngCode = value; }
        }

        /// public propaty name  :  DepoDelCode
        /// <summary>入金消込区分プロパティ</summary>
        /// <value>PM(0:しない,1:する) G/D( 0:しない,1:する(請求別),2:する(納品別)）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金消込区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepoDelCode
        {
            get { return _depoDelCode; }
            set { _depoDelCode = value; }
        }

        /// public propaty name  :  AccRecDivCd
        /// <summary>売掛区分プロパティ</summary>
        /// <value>0:売掛なし,1:売掛</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売掛区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AccRecDivCd
        {
            get { return _accRecDivCd; }
            set { _accRecDivCd = value; }
        }

        /// public propaty name  :  CustSlipNoMngCd
        /// <summary>相手伝票番号管理区分プロパティ</summary>
        /// <value>0:しない　1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   相手伝票番号管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustSlipNoMngCd
        {
            get { return _custSlipNoMngCd; }
            set { _custSlipNoMngCd = value; }
        }

        /// public propaty name  :  PureCode
        /// <summary>純正区分プロパティ</summary>
        /// <value>0:純正、1:その他（PMは優良）　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PureCode
        {
            get { return _pureCode; }
            set { _pureCode = value; }
        }

        /// public propaty name  :  CustCTaXLayRefCd
        /// <summary>得意先消費税転嫁方式参照区分プロパティ</summary>
        /// <value>0:税率設定マスタを参照　1:得意先マスタを参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先消費税転嫁方式参照区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustCTaXLayRefCd
        {
            get { return _custCTaXLayRefCd; }
            set { _custCTaXLayRefCd = value; }
        }

        /// public propaty name  :  ConsTaxLayMethod
        /// <summary>消費税転嫁方式プロパティ</summary>
        /// <value>0:伝票単位1:明細単位2:請求親3:請求子　9:非課税</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税転嫁方式プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ConsTaxLayMethod
        {
            get { return _consTaxLayMethod; }
            set { _consTaxLayMethod = value; }
        }

        /// public propaty name  :  TotalAmountDispWayCd
        /// <summary>総額表示方法区分プロパティ</summary>
        /// <value>0:総額表示しない（税抜き）,1:総額表示する（税込み）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// public propaty name  :  TotalAmntDspWayRef
        /// <summary>総額表示方法参照区分プロパティ</summary>
        /// <value>0:全体設定参照 1:得意先参照</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示方法参照区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalAmntDspWayRef
        {
            get { return _totalAmntDspWayRef; }
            set { _totalAmntDspWayRef = value; }
        }

        /// public propaty name  :  AccountNoInfo1
        /// <summary>銀行口座1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AccountNoInfo1
        {
            get { return _accountNoInfo1; }
            set { _accountNoInfo1 = value; }
        }

        /// public propaty name  :  AccountNoInfo2
        /// <summary>銀行口座2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AccountNoInfo2
        {
            get { return _accountNoInfo2; }
            set { _accountNoInfo2 = value; }
        }

        /// public propaty name  :  AccountNoInfo3
        /// <summary>銀行口座3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   銀行口座3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string AccountNoInfo3
        {
            get { return _accountNoInfo3; }
            set { _accountNoInfo3 = value; }
        }

        /// public propaty name  :  SalesUnPrcFrcProcCd
        /// <summary>売上単価端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上単価端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesUnPrcFrcProcCd
        {
            get { return _salesUnPrcFrcProcCd; }
            set { _salesUnPrcFrcProcCd = value; }
        }

        /// public propaty name  :  SalesMoneyFrcProcCd
        /// <summary>売上金額端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上金額端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesMoneyFrcProcCd
        {
            get { return _salesMoneyFrcProcCd; }
            set { _salesMoneyFrcProcCd = value; }
        }

        /// public propaty name  :  SalesCnsTaxFrcProcCd
        /// <summary>売上消費税端数処理コードプロパティ</summary>
        /// <value>0の場合は 標準設定とする。</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上消費税端数処理コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesCnsTaxFrcProcCd
        {
            get { return _salesCnsTaxFrcProcCd; }
            set { _salesCnsTaxFrcProcCd = value; }
        }

        /// public propaty name  :  CustomerSlipNoDiv
        /// <summary>得意先伝票番号区分プロパティ</summary>
        /// <value>0:使用しない,1:連番,2:締毎,3:期末</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先伝票番号区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerSlipNoDiv
        {
            get { return _customerSlipNoDiv; }
            set { _customerSlipNoDiv = value; }
        }

        /// public propaty name  :  NTimeCalcStDate
        /// <summary>次回勘定開始日プロパティ</summary>
        /// <value>01～31まで（省略可能）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   次回勘定開始日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 NTimeCalcStDate
        {
            get { return _nTimeCalcStDate; }
            set { _nTimeCalcStDate = value; }
        }

        /// public propaty name  :  CustomerAgent
        /// <summary>得意先担当者プロパティ</summary>
        /// <value>得意先（仕入先）の問い合わせ先社員名</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先担当者プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerAgent
        {
            get { return _customerAgent; }
            set { _customerAgent = value; }
        }

        /// public propaty name  :  ClaimSectionCode
        /// <summary>請求拠点コードプロパティ</summary>
        /// <value>請求を行う拠点</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSectionCode
        {
            get { return _claimSectionCode; }
            set { _claimSectionCode = value; }
        }

        /// public propaty name  :  ClaimSectionName
        /// <summary>請求拠点名称プロパティ</summary>
        /// <value>拠点ガイド略称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ClaimSectionName
        {
            get { return _claimSectionName; }
            set { _claimSectionName = value; }
        }

        /// public propaty name  :  CarMngDivCd
        /// <summary>車輌管理区分プロパティ</summary>
        /// <value>0:しない、1:登録(確認)、2:登録(自動) 3:登録無</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   車輌管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CarMngDivCd
        {
            get { return _carMngDivCd; }
            set { _carMngDivCd = value; }
        }

        /// public propaty name  :  BillPartsNoPrtCd
        /// <summary>品番印字区分(請求書)プロパティ</summary>
        /// <value>0:商品マスタ、1:有、2:無</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番印字区分(請求書)プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillPartsNoPrtCd
        {
            get { return _billPartsNoPrtCd; }
            set { _billPartsNoPrtCd = value; }
        }

        /// public propaty name  :  DeliPartsNoPrtCd
        /// <summary>品番印字区分(納品書）プロパティ</summary>
        /// <value>0:商品マスタ、1:有、2:無</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   品番印字区分(納品書）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliPartsNoPrtCd
        {
            get { return _deliPartsNoPrtCd; }
            set { _deliPartsNoPrtCd = value; }
        }

        /// public propaty name  :  DefSalesSlipCd
        /// <summary>伝票区分初期値プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票区分初期値プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefSalesSlipCd
        {
            get { return _defSalesSlipCd; }
            set { _defSalesSlipCd = value; }
        }

        /// public propaty name  :  LavorRateRank
        /// <summary>工賃レバレートランクプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   工賃レバレートランクプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LavorRateRank
        {
            get { return _lavorRateRank; }
            set { _lavorRateRank = value; }
        }

        /// public propaty name  :  SlipTtlPrn
        /// <summary>伝票タイトルパターンプロパティ</summary>
        /// <value>0000:未設定、0100:基本タイトル、0200・・</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票タイトルパターンプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipTtlPrn
        {
            get { return _slipTtlPrn; }
            set { _slipTtlPrn = value; }
        }

        /// public propaty name  :  DepoBankCode
        /// <summary>入金銀行コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金銀行コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DepoBankCode
        {
            get { return _depoBankCode; }
            set { _depoBankCode = value; }
        }

        /// public propaty name  :  DepoBankName
        /// <summary>入金銀行名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入金銀行名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DepoBankName
        {
            get { return _depoBankName; }
            set { _depoBankName = value; }
        }

        /// public propaty name  :  CustWarehouseCd
        /// <summary>得意先優先倉庫コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先優先倉庫コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustWarehouseCd
        {
            get { return _custWarehouseCd; }
            set { _custWarehouseCd = value; }
        }

        /// public propaty name  :  CustWarehouseName
        /// <summary>得意先優先倉庫名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先優先倉庫名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustWarehouseName
        {
            get { return _custWarehouseName; }
            set { _custWarehouseName = value; }
        }

        /// public propaty name  :  QrcodePrtCd
        /// <summary>QRコード印刷プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   QRコード印刷プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 QrcodePrtCd
        {
            get { return _qrcodePrtCd; }
            set { _qrcodePrtCd = value; }
        }

        /// public propaty name  :  DeliHonorificTtl
        /// <summary>納品書敬称プロパティ</summary>
        /// <value>納品書用の敬称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品書敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string DeliHonorificTtl
        {
            get { return _deliHonorificTtl; }
            set { _deliHonorificTtl = value; }
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

        /// public propaty name  :  EstmHonorificTtl
        /// <summary>見積書敬称プロパティ</summary>
        /// <value>見積書用の敬称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string EstmHonorificTtl
        {
            get { return _estmHonorificTtl; }
            set { _estmHonorificTtl = value; }
        }

        /// public propaty name  :  RectHonorificTtl
        /// <summary>領収書敬称プロパティ</summary>
        /// <value>領収書用の敬称</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   領収書敬称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string RectHonorificTtl
        {
            get { return _rectHonorificTtl; }
            set { _rectHonorificTtl = value; }
        }

        /// public propaty name  :  DeliHonorTtlPrtDiv
        /// <summary>納品書敬称印字区分プロパティ</summary>
        /// <value>0:得意先マスタ 1:全体項目設定参照 2:非印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品書敬称印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DeliHonorTtlPrtDiv
        {
            get { return _deliHonorTtlPrtDiv; }
            set { _deliHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  BillHonorTtlPrtDiv
        /// <summary>請求書敬称印字区分プロパティ</summary>
        /// <value>0:得意先マスタ 1:全体項目設定参照 2:非印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書敬称印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 BillHonorTtlPrtDiv
        {
            get { return _billHonorTtlPrtDiv; }
            set { _billHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  EstmHonorTtlPrtDiv
        /// <summary>見積書敬称印字区分プロパティ</summary>
        /// <value>0:得意先マスタ 1:全体項目設定参照 2:非印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書敬称印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstmHonorTtlPrtDiv
        {
            get { return _estmHonorTtlPrtDiv; }
            set { _estmHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  RectHonorTtlPrtDiv
        /// <summary>領収書敬称印字区分プロパティ</summary>
        /// <value>0:得意先マスタ 1:全体項目設定参照 2:非印字</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   領収書敬称印字区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RectHonorTtlPrtDiv
        {
            get { return _rectHonorTtlPrtDiv; }
            set { _rectHonorTtlPrtDiv = value; }
        }

        /// public propaty name  :  Note1
        /// <summary>備考1プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考1プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note1
        {
            get { return _note1; }
            set { _note1 = value; }
        }

        /// public propaty name  :  Note2
        /// <summary>備考2プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考2プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note2
        {
            get { return _note2; }
            set { _note2 = value; }
        }

        /// public propaty name  :  Note3
        /// <summary>備考3プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考3プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note3
        {
            get { return _note3; }
            set { _note3 = value; }
        }

        /// public propaty name  :  Note4
        /// <summary>備考4プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考4プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note4
        {
            get { return _note4; }
            set { _note4 = value; }
        }

        /// public propaty name  :  Note5
        /// <summary>備考5プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考5プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note5
        {
            get { return _note5; }
            set { _note5 = value; }
        }

        /// public propaty name  :  Note6
        /// <summary>備考6プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考6プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note6
        {
            get { return _note6; }
            set { _note6 = value; }
        }

        /// public propaty name  :  Note7
        /// <summary>備考7プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考7プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note7
        {
            get { return _note7; }
            set { _note7 = value; }
        }

        /// public propaty name  :  Note8
        /// <summary>備考8プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考8プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note8
        {
            get { return _note8; }
            set { _note8 = value; }
        }

        /// public propaty name  :  Note9
        /// <summary>備考9プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考9プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note9
        {
            get { return _note9; }
            set { _note9 = value; }
        }

        /// public propaty name  :  Note10
        /// <summary>備考10プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   備考10プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string Note10
        {
            get { return _note10; }
            set { _note10 = value; }
        }

        /// public propaty name  :  CreditMoney
        /// <summary>与信額[変動情報]プロパティ</summary>
        /// <value>デッドライン</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   与信額[変動情報]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 CreditMoney
        {
            get { return _creditMoney; }
            set { _creditMoney = value; }
        }

        /// public propaty name  :  WarningCreditMoney
        /// <summary>警告与信額[変動情報]プロパティ</summary>
        /// <value>警告表示用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   警告与信額[変動情報]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 WarningCreditMoney
        {
            get { return _warningCreditMoney; }
            set { _warningCreditMoney = value; }
        }

        /// public propaty name  :  PrsntAccRecBalance
        /// <summary>現在売掛残高[変動情報]プロパティ</summary>
        /// <value>入金データ、売上データ（売掛）を登録する場合にリアルに更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   現在売掛残高[変動情報]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 PrsntAccRecBalance
        {
            get { return _prsntAccRecBalance; }
            set { _prsntAccRecBalance = value; }
        }

        /// public propaty name  :  RateGPureCode
        /// <summary>純正区分[掛率]プロパティ</summary>
        /// <value>0:純正、1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   純正区分[掛率]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RateGPureCode
        {
            get { return _rateGPureCode; }
            set { _rateGPureCode = value; }
        }

        /// public propaty name  :  GoodsMakerCd
        /// <summary>商品メーカーコード[掛率]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品メーカーコード[掛率]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsMakerCd
        {
            get { return _goodsMakerCd; }
            set { _goodsMakerCd = value; }
        }

        /// public propaty name  :  CustRateGrpCode
        /// <summary>得意先掛率グループコード[掛率]プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先掛率グループコード[掛率]プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustRateGrpCode
        {
            get { return _custRateGrpCode; }
            set { _custRateGrpCode = value; }
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

        /// public propaty name  :  InpSectionName
        /// <summary>入力拠点名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   入力拠点名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string InpSectionName
        {
            get { return _inpSectionName; }
            set { _inpSectionName = value; }
        }

        /// public propaty name  :  BillOutPutCodeNm
        /// <summary>請求書出力区分名称プロパティ</summary>
        /// <value>請求書発行する,しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   請求書出力区分名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillOutPutCodeNm
        {
            get { return _billOutPutCodeNm; }
            set { _billOutPutCodeNm = value; }
        }

        /// public propaty name  :  BillCollecterNm
        /// <summary>集金担当従業員名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   集金担当従業員名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string BillCollecterNm
        {
            get { return _billCollecterNm; }
            set { _billCollecterNm = value; }
        }

        /// public propaty name  :  ReceiptOutputCode
        /// <summary>領収書出力区分コードプロパティ</summary>
        /// <value>0:する 1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   領収書出力区分コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ReceiptOutputCode
        {
            get { return _receiptOutputCode; }
            set { _receiptOutputCode = value; }
        }

        /// public propaty name  :  TotalBillOutputDiv
        /// <summary>合計請求書出力区分プロパティ</summary>
        /// <value>0:標準 1:使用 2:未使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int TotalBillOutputDiv
        {
            get { return _totalBillOutputDiv; }
            set { _totalBillOutputDiv = value; }
        }

        /// public propaty name  :  DetailBillOutputCode
        /// <summary>明細請求書出力区分プロパティ</summary>
        /// <value>0:標準 1:使用 2:未使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int DetailBillOutputCode
        {
            get { return _detailBillOutputCode; }
            set { _detailBillOutputCode = value; }
        }

        /// public propaty name  :  SlipTtlBillOutputDiv
        /// <summary>伝票合計請求書出力区分プロパティ</summary>
        /// <value>0:標準 1:使用 2:未使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int SlipTtlBillOutputDiv
        {
            get { return _slipTtlBillOutputDiv; }
            set { _slipTtlBillOutputDiv = value; }
        }

        /// public propaty name  :  SalesSlipPrtDiv
        /// <summary>納品書出力（売上伝票発行区分）プロパティ</summary>
        /// <value>0:標準 1:未使用 2:使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   納品書出力（売上伝票発行区分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int SalesSlipPrtDiv
        {
            get { return _salesSlipPrtDiv; }
            set { _salesSlipPrtDiv = value; }
        }

        /// public propaty name  :  AcpOdrrSlipPrtDiv
        /// <summary>受注伝票出力（受注伝票発行区分）プロパティ</summary>
        /// <value>0:標準 1:未使用 2:使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注伝票出力（受注伝票発行区分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int AcpOdrrSlipPrtDiv
        {
            get { return _acpOdrrSlipPrtDiv; }
            set { _acpOdrrSlipPrtDiv = value; }
        }

        /// public propaty name  :  ShipmSlipPrtDiv
        /// <summary>貸出伝票出力（出荷伝票発行区分）プロパティ</summary>
        /// <value>0:標準 1:未使用 2:使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   貸出伝票出力（出荷伝票発行区分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int ShipmSlipPrtDiv
        {
            get { return _shipmSlipPrtDiv; }
            set { _shipmSlipPrtDiv = value; }
        }

        /// public propaty name  :  EstimatePrtDiv
        /// <summary>見積伝票出力（見積伝票発行区分）プロパティ</summary>
        /// <value>0:標準 1:未使用 2:使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積伝票出力（見積伝票発行区分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int EstimatePrtDiv
        {
            get { return _estimatePrtDiv; }
            set { _estimatePrtDiv = value; }
        }

        /// public propaty name  :  UOESlipPrtDiv
        /// <summary>UOE伝票出力（UOE伝票発行区分）プロパティ</summary>
        /// <value>0:標準 1:未使用 2:使用</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE伝票出力（UOE伝票発行区分）プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public int UOESlipPrtDiv
        {
            get { return _uoeSlipPrtDiv; }
            set { _uoeSlipPrtDiv = value; }
        }

        /// <summary>
        /// 得意先一括修正クラスワークコンストラクタ
        /// </summary>
        /// <returns>CustomerCustomerChangeResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerCustomerChangeResult()
        {
        }

        /// <summary>
        /// 得意先一括修正クラスワークコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="customerCode">得意先コード(納入先の場合の使用可能項目)</param>
        /// <param name="customerSubCode">得意先サブコード</param>
        /// <param name="name">名称(納入先の場合の使用可能項目)</param>
        /// <param name="name2">名称2(納入先の場合の使用可能項目)</param>
        /// <param name="honorificTitle">敬称</param>
        /// <param name="kana">カナ</param>
        /// <param name="customerSnm">得意先略称</param>
        /// <param name="outputNameCode">諸口コード(0:顧客名称1と2,1:顧客名称1,2:顧客名称2,3:諸口名称)</param>
        /// <param name="outputName">諸口名称</param>
        /// <param name="corporateDivCode">個人・法人区分(0:個人,1:法人,2:大口法人,3:業者,4:社員)</param>
        /// <param name="customerAttributeDiv">得意先属性区分(0:正式取引先,8:社内取引先,9:諸口口座)</param>
        /// <param name="jobTypeCode">職種コード</param>
        /// <param name="jobTypeName">職種名称</param>
        /// <param name="businessTypeCode">業種コード</param>
        /// <param name="businessTypeName">業種名称</param>
        /// <param name="salesAreaCode">販売エリアコード</param>
        /// <param name="salesAreaName">販売エリア名称</param>
        /// <param name="postNo">郵便番号(納入先の場合の使用可能項目)</param>
        /// <param name="address1">住所1（都道府県市区郡・町村・字）(納入先の場合の使用可能項目)</param>
        /// <param name="address3">住所3（番地）(納入先の場合の使用可能項目)</param>
        /// <param name="address4">住所4（アパート名称）(納入先の場合の使用可能項目)</param>
        /// <param name="homeTelNo">電話番号（自宅）(ハイフンを含めた16桁の番号)</param>
        /// <param name="officeTelNo">電話番号（勤務先）(納入先の場合の使用可能項目)</param>
        /// <param name="portableTelNo">電話番号（携帯）</param>
        /// <param name="homeFaxNo">FAX番号（自宅）</param>
        /// <param name="officeFaxNo">FAX番号（勤務先）(納入先の場合の使用可能項目)</param>
        /// <param name="othersTelNo">電話番号（その他）</param>
        /// <param name="mainContactCode">主連絡先区分(0:自宅,1:勤務先,2:携帯,3:自宅FAX,4:勤務先FAX･･･)</param>
        /// <param name="searchTelNo">電話番号（検索用下4桁）</param>
        /// <param name="mngSectionCode">管理拠点コード</param>
        /// <param name="mngSectionName">管理拠点名称</param>
        /// <param name="inpSectionCode">入力拠点コード</param>
        /// <param name="custAnalysCode1">得意先分析コード1</param>
        /// <param name="custAnalysCode2">得意先分析コード2</param>
        /// <param name="custAnalysCode3">得意先分析コード3</param>
        /// <param name="custAnalysCode4">得意先分析コード4</param>
        /// <param name="custAnalysCode5">得意先分析コード5</param>
        /// <param name="custAnalysCode6">得意先分析コード6</param>
        /// <param name="billOutputCode">請求書出力区分コード(0:請求書発行する,1:しない)</param>
        /// <param name="billOutputName">請求書出力区分名称</param>
        /// <param name="totalDay">締日(DD)</param>
        /// <param name="collectMoneyCode">集金月区分コード(0:当月,1:翌月,2:翌々月)</param>
        /// <param name="collectMoneyName">集金月区分名称(当月,翌月,翌々月)</param>
        /// <param name="collectMoneyDay">集金日(DD)</param>
        /// <param name="collectCond">回収条件(10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他)</param>
        /// <param name="collectSight">回収サイト(手形サイト　180等)</param>
        /// <param name="claimCode">請求先コード(請求先得意先。納入先の場合の使用可能項目)</param>
        /// <param name="claimName">請求先名称</param>
        /// <param name="claimName2">請求先名称2</param>
        /// <param name="claimSnm">請求先略所</param>
        /// <param name="transStopDate">取引中止日(YYYYMMDD)</param>
        /// <param name="dmOutCode">DM出力区分(0:出力する,1:出力しない)</param>
        /// <param name="dmOutName">DM出力区分名称(全角で管理)</param>
        /// <param name="mainSendMailAddrCd">主送信先メールアドレス区分(0:メールアドレス1,1:メールアドレス2)</param>
        /// <param name="mailAddrKindCode1">メールアドレス種別コード1(0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他)</param>
        /// <param name="mailAddrKindName1">メールアドレス種別名称1</param>
        /// <param name="mailAddress1">メールアドレス1</param>
        /// <param name="mailSendCode1">メール送信区分コード1(0:非送信,1:送信)</param>
        /// <param name="mailSendName1">メール送信区分名称1</param>
        /// <param name="mailAddrKindCode2">メールアドレス種別コード2(0:自宅,1:会社,2:携帯端末,3:本人以外,99:その他)</param>
        /// <param name="mailAddrKindName2">メールアドレス種別名称2</param>
        /// <param name="mailAddress2">メールアドレス2</param>
        /// <param name="mailSendCode2">メール送信区分コード2(0:非送信,1:送信)</param>
        /// <param name="mailSendName2">メール送信区分名称2</param>
        /// <param name="customerAgentCd">顧客担当従業員コード(文字型)</param>
        /// <param name="customerAgentNm">顧客担当従業員名称</param>
        /// <param name="billCollecterCd">集金担当従業員コード</param>
        /// <param name="oldCustomerAgentCd">旧顧客担当従業員コード</param>
        /// <param name="oldCustomerAgentNm">旧顧客担当従業員名称</param>
        /// <param name="custAgentChgDate">顧客担当変更日(YYYYMMDD)</param>
        /// <param name="acceptWholeSale">業販先区分(0:業販先以外,1:業販先,2:納入先)</param>
        /// <param name="creditMngCode">与信管理区分</param>
        /// <param name="depoDelCode">入金消込区分(PM(0:しない,1:する) G/D( 0:しない,1:する(請求別),2:する(納品別)）)</param>
        /// <param name="accRecDivCd">売掛区分(0:売掛なし,1:売掛)</param>
        /// <param name="custSlipNoMngCd">相手伝票番号管理区分(0:しない　1:する)</param>
        /// <param name="pureCode">純正区分(0:純正、1:その他（PMは優良）　)</param>
        /// <param name="custCTaXLayRefCd">得意先消費税転嫁方式参照区分(0:税率設定マスタを参照　1:得意先マスタを参照)</param>
        /// <param name="consTaxLayMethod">消費税転嫁方式(0:伝票単位1:明細単位2:請求親3:請求子　9:非課税)</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
        /// <param name="totalAmntDspWayRef">総額表示方法参照区分(0:全体設定参照 1:得意先参照)</param>
        /// <param name="accountNoInfo1">銀行口座1</param>
        /// <param name="accountNoInfo2">銀行口座2</param>
        /// <param name="accountNoInfo3">銀行口座3</param>
        /// <param name="salesUnPrcFrcProcCd">売上単価端数処理コード(0の場合は 標準設定とする。)</param>
        /// <param name="salesMoneyFrcProcCd">売上金額端数処理コード(0の場合は 標準設定とする。)</param>
        /// <param name="salesCnsTaxFrcProcCd">売上消費税端数処理コード(0の場合は 標準設定とする。)</param>
        /// <param name="customerSlipNoDiv">得意先伝票番号区分(0:使用しない,1:連番,2:締毎,3:期末)</param>
        /// <param name="nTimeCalcStDate">次回勘定開始日(01～31まで（省略可能）)</param>
        /// <param name="customerAgent">得意先担当者(得意先（仕入先）の問い合わせ先社員名)</param>
        /// <param name="claimSectionCode">請求拠点コード(請求を行う拠点)</param>
        /// <param name="claimSectionName">請求拠点名称(拠点ガイド略称)</param>
        /// <param name="carMngDivCd">車輌管理区分(0:しない、1:登録(確認)、2:登録(自動) 3:登録無)</param>
        /// <param name="billPartsNoPrtCd">品番印字区分(請求書)(0:商品マスタ、1:有、2:無)</param>
        /// <param name="deliPartsNoPrtCd">品番印字区分(納品書）(0:商品マスタ、1:有、2:無)</param>
        /// <param name="defSalesSlipCd">伝票区分初期値</param>
        /// <param name="lavorRateRank">工賃レバレートランク</param>
        /// <param name="slipTtlPrn">伝票タイトルパターン(0000:未設定、0100:基本タイトル、0200・・)</param>
        /// <param name="depoBankCode">入金銀行コード</param>
        /// <param name="depoBankName">入金銀行名称</param>
        /// <param name="custWarehouseCd">得意先優先倉庫コード</param>
        /// <param name="custWarehouseName">得意先優先倉庫名称</param>
        /// <param name="qrcodePrtCd">QRコード印刷</param>
        /// <param name="deliHonorificTtl">納品書敬称(納品書用の敬称)</param>
        /// <param name="billHonorificTtl">請求書敬称(請求書用の敬称)</param>
        /// <param name="estmHonorificTtl">見積書敬称(見積書用の敬称)</param>
        /// <param name="rectHonorificTtl">領収書敬称(領収書用の敬称)</param>
        /// <param name="deliHonorTtlPrtDiv">納品書敬称印字区分(0:得意先マスタ 1:全体項目設定参照 2:非印字)</param>
        /// <param name="billHonorTtlPrtDiv">請求書敬称印字区分(0:得意先マスタ 1:全体項目設定参照 2:非印字)</param>
        /// <param name="estmHonorTtlPrtDiv">見積書敬称印字区分(0:得意先マスタ 1:全体項目設定参照 2:非印字)</param>
        /// <param name="rectHonorTtlPrtDiv">領収書敬称印字区分(0:得意先マスタ 1:全体項目設定参照 2:非印字)</param>
        /// <param name="note1">備考1</param>
        /// <param name="note2">備考2</param>
        /// <param name="note3">備考3</param>
        /// <param name="note4">備考4</param>
        /// <param name="note5">備考5</param>
        /// <param name="note6">備考6</param>
        /// <param name="note7">備考7</param>
        /// <param name="note8">備考8</param>
        /// <param name="note9">備考9</param>
        /// <param name="note10">備考10</param>
        /// <param name="creditMoney">与信額[変動情報](デッドライン)</param>
        /// <param name="warningCreditMoney">警告与信額[変動情報](警告表示用)</param>
        /// <param name="prsntAccRecBalance">現在売掛残高[変動情報](入金データ、売上データ（売掛）を登録する場合にリアルに更新)</param>
        /// <param name="rateGPureCode">純正区分[掛率](0:純正、1:優良)</param>
        /// <param name="goodsMakerCd">商品メーカーコード[掛率]</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード[掛率]</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="inpSectionName">入力拠点名称</param>
        /// <param name="billOutPutCodeNm">請求書出力区分名称(請求書発行する,しない)</param>
        /// <param name="billCollecterNm">集金担当従業員名称</param>
        /// <param name="receiptOutputCode">領収書出力区分コード</param>
        /// <param name="salesSlipPrtDiv">納品書出力（売上伝票発行区分）</param>
        /// <param name="acpOdrrSlipPrtDiv">受注伝票出力（受注伝票発行区分）</param>
        /// <param name="shipmSlipPrtDiv">貸出伝票出力（出荷伝票発行区分）</param>
        /// <param name="estimatePrtDiv">見積伝票出力（見積伝票発行区分）</param>
        /// <param name="uoeSlipPrtDiv">UOE伝票出力（UOE伝票発行区分）</param>
        /// <param name="totalBillOutputDiv">合計請求書出力区分</param>
        /// <param name="detailBillOutputCode">明細請求書出力区分</param>
        /// <param name="slipTtlBillOutputDiv">伝票合計請求書出力出力区分</param>
        /// <returns>CustomerCustomerChangeResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeResultクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerCustomerChangeResult(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 customerCode, string customerSubCode, string name, string name2, string honorificTitle, string kana, string customerSnm, Int32 outputNameCode, string outputName, Int32 corporateDivCode, Int32 customerAttributeDiv, Int32 jobTypeCode, string jobTypeName, Int32 businessTypeCode, string businessTypeName, Int32 salesAreaCode, string salesAreaName, string postNo, string address1, string address3, string address4, string homeTelNo, string officeTelNo, string portableTelNo, string homeFaxNo, string officeFaxNo, string othersTelNo, Int32 mainContactCode, string searchTelNo, string mngSectionCode, string mngSectionName, string inpSectionCode, Int32 custAnalysCode1, Int32 custAnalysCode2, Int32 custAnalysCode3, Int32 custAnalysCode4, Int32 custAnalysCode5, Int32 custAnalysCode6, Int32 billOutputCode, string billOutputName, Int32 totalDay, Int32 collectMoneyCode, string collectMoneyName, Int32 collectMoneyDay, Int32 collectCond, Int32 collectSight, Int32 claimCode, string claimName, string claimName2, string claimSnm, DateTime transStopDate, Int32 dmOutCode, string dmOutName, Int32 mainSendMailAddrCd, Int32 mailAddrKindCode1, string mailAddrKindName1, string mailAddress1, Int32 mailSendCode1, string mailSendName1, Int32 mailAddrKindCode2, string mailAddrKindName2, string mailAddress2, Int32 mailSendCode2, string mailSendName2, string customerAgentCd, string customerAgentNm, string billCollecterCd, string oldCustomerAgentCd, string oldCustomerAgentNm, DateTime custAgentChgDate, Int32 acceptWholeSale, Int32 creditMngCode, Int32 depoDelCode, Int32 accRecDivCd, Int32 custSlipNoMngCd, Int32 pureCode, Int32 custCTaXLayRefCd, Int32 consTaxLayMethod, Int32 totalAmountDispWayCd, Int32 totalAmntDspWayRef, string accountNoInfo1, string accountNoInfo2, string accountNoInfo3, Int32 salesUnPrcFrcProcCd, Int32 salesMoneyFrcProcCd, Int32 salesCnsTaxFrcProcCd, Int32 customerSlipNoDiv, Int32 nTimeCalcStDate, string customerAgent, string claimSectionCode, string claimSectionName, Int32 carMngDivCd, Int32 billPartsNoPrtCd, Int32 deliPartsNoPrtCd, Int32 defSalesSlipCd, Int32 lavorRateRank, Int32 slipTtlPrn, Int32 depoBankCode, string depoBankName, string custWarehouseCd, string custWarehouseName, Int32 qrcodePrtCd, string deliHonorificTtl, string billHonorificTtl, string estmHonorificTtl, string rectHonorificTtl, Int32 deliHonorTtlPrtDiv, Int32 billHonorTtlPrtDiv, Int32 estmHonorTtlPrtDiv, Int32 rectHonorTtlPrtDiv, string note1, string note2, string note3, string note4, string note5, string note6, string note7, string note8, string note9, string note10, Int64 creditMoney, Int64 warningCreditMoney, Int64 prsntAccRecBalance, Int32 rateGPureCode, Int32 goodsMakerCd, Int32 custRateGrpCode, string enterpriseName, string updEmployeeName, string inpSectionName, string billOutPutCodeNm, string billCollecterNm, Int32 receiptOutputCode
            , int salesSlipPrtDiv, int acpOdrrSlipPrtDiv, int shipmSlipPrtDiv, int estimatePrtDiv, int uoeSlipPrtDiv
            , int totalBillOutputDiv, int detailBillOutputCode, int slipTtlBillOutputDiv)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._customerCode = customerCode;
            this._customerSubCode = customerSubCode;
            this._name = name;
            this._name2 = name2;
            this._honorificTitle = honorificTitle;
            this._kana = kana;
            this._customerSnm = customerSnm;
            this._outputNameCode = outputNameCode;
            this._outputName = outputName;
            this._corporateDivCode = corporateDivCode;
            this._customerAttributeDiv = customerAttributeDiv;
            this._jobTypeCode = jobTypeCode;
            this._jobTypeName = jobTypeName;
            this._businessTypeCode = businessTypeCode;
            this._businessTypeName = businessTypeName;
            this._salesAreaCode = salesAreaCode;
            this._salesAreaName = salesAreaName;
            this._postNo = postNo;
            this._address1 = address1;
            this._address3 = address3;
            this._address4 = address4;
            this._homeTelNo = homeTelNo;
            this._officeTelNo = officeTelNo;
            this._portableTelNo = portableTelNo;
            this._homeFaxNo = homeFaxNo;
            this._officeFaxNo = officeFaxNo;
            this._othersTelNo = othersTelNo;
            this._mainContactCode = mainContactCode;
            this._searchTelNo = searchTelNo;
            this._mngSectionCode = mngSectionCode;
            this._mngSectionName = mngSectionName;
            this._inpSectionCode = inpSectionCode;
            this._custAnalysCode1 = custAnalysCode1;
            this._custAnalysCode2 = custAnalysCode2;
            this._custAnalysCode3 = custAnalysCode3;
            this._custAnalysCode4 = custAnalysCode4;
            this._custAnalysCode5 = custAnalysCode5;
            this._custAnalysCode6 = custAnalysCode6;
            this._billOutputCode = billOutputCode;
            this._billOutputName = billOutputName;
            this._totalDay = totalDay;
            this._collectMoneyCode = collectMoneyCode;
            this._collectMoneyName = collectMoneyName;
            this._collectMoneyDay = collectMoneyDay;
            this._collectCond = collectCond;
            this._collectSight = collectSight;
            this._claimCode = claimCode;
            this._claimName = claimName;
            this._claimName2 = claimName2;
            this._claimSnm = claimSnm;
            this.TransStopDate = transStopDate;
            this._dmOutCode = dmOutCode;
            this._dmOutName = dmOutName;
            this._mainSendMailAddrCd = mainSendMailAddrCd;
            this._mailAddrKindCode1 = mailAddrKindCode1;
            this._mailAddrKindName1 = mailAddrKindName1;
            this._mailAddress1 = mailAddress1;
            this._mailSendCode1 = mailSendCode1;
            this._mailSendName1 = mailSendName1;
            this._mailAddrKindCode2 = mailAddrKindCode2;
            this._mailAddrKindName2 = mailAddrKindName2;
            this._mailAddress2 = mailAddress2;
            this._mailSendCode2 = mailSendCode2;
            this._mailSendName2 = mailSendName2;
            this._customerAgentCd = customerAgentCd;
            this._customerAgentNm = customerAgentNm;
            this._billCollecterCd = billCollecterCd;
            this._oldCustomerAgentCd = oldCustomerAgentCd;
            this._oldCustomerAgentNm = oldCustomerAgentNm;
            this.CustAgentChgDate = custAgentChgDate;
            this._acceptWholeSale = acceptWholeSale;
            this._creditMngCode = creditMngCode;
            this._depoDelCode = depoDelCode;
            this._accRecDivCd = accRecDivCd;
            this._custSlipNoMngCd = custSlipNoMngCd;
            this._pureCode = pureCode;
            this._custCTaXLayRefCd = custCTaXLayRefCd;
            this._consTaxLayMethod = consTaxLayMethod;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            this._totalAmntDspWayRef = totalAmntDspWayRef;
            this._accountNoInfo1 = accountNoInfo1;
            this._accountNoInfo2 = accountNoInfo2;
            this._accountNoInfo3 = accountNoInfo3;
            this._salesUnPrcFrcProcCd = salesUnPrcFrcProcCd;
            this._salesMoneyFrcProcCd = salesMoneyFrcProcCd;
            this._salesCnsTaxFrcProcCd = salesCnsTaxFrcProcCd;
            this._customerSlipNoDiv = customerSlipNoDiv;
            this._nTimeCalcStDate = nTimeCalcStDate;
            this._customerAgent = customerAgent;
            this._claimSectionCode = claimSectionCode;
            this._claimSectionName = claimSectionName;
            this._carMngDivCd = carMngDivCd;
            this._billPartsNoPrtCd = billPartsNoPrtCd;
            this._deliPartsNoPrtCd = deliPartsNoPrtCd;
            this._defSalesSlipCd = defSalesSlipCd;
            this._lavorRateRank = lavorRateRank;
            this._slipTtlPrn = slipTtlPrn;
            this._depoBankCode = depoBankCode;
            this._depoBankName = depoBankName;
            this._custWarehouseCd = custWarehouseCd;
            this._custWarehouseName = custWarehouseName;
            this._qrcodePrtCd = qrcodePrtCd;
            this._deliHonorificTtl = deliHonorificTtl;
            this._billHonorificTtl = billHonorificTtl;
            this._estmHonorificTtl = estmHonorificTtl;
            this._rectHonorificTtl = rectHonorificTtl;
            this._deliHonorTtlPrtDiv = deliHonorTtlPrtDiv;
            this._billHonorTtlPrtDiv = billHonorTtlPrtDiv;
            this._estmHonorTtlPrtDiv = estmHonorTtlPrtDiv;
            this._rectHonorTtlPrtDiv = rectHonorTtlPrtDiv;
            this._note1 = note1;
            this._note2 = note2;
            this._note3 = note3;
            this._note4 = note4;
            this._note5 = note5;
            this._note6 = note6;
            this._note7 = note7;
            this._note8 = note8;
            this._note9 = note9;
            this._note10 = note10;
            this._creditMoney = creditMoney;
            this._warningCreditMoney = warningCreditMoney;
            this._prsntAccRecBalance = prsntAccRecBalance;
            this._rateGPureCode = rateGPureCode;
            this._goodsMakerCd = goodsMakerCd;
            this._custRateGrpCode = custRateGrpCode;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            this._inpSectionName = inpSectionName;
            this._billOutPutCodeNm = billOutPutCodeNm;
            this._billCollecterNm = billCollecterNm;
            this._receiptOutputCode = receiptOutputCode;
            this._salesSlipPrtDiv = salesSlipPrtDiv;
            this._acpOdrrSlipPrtDiv = acpOdrrSlipPrtDiv;
            this._shipmSlipPrtDiv = shipmSlipPrtDiv;
            this._estimatePrtDiv = estimatePrtDiv;
            this._uoeSlipPrtDiv = uoeSlipPrtDiv;
            this._totalBillOutputDiv = totalBillOutputDiv;
            this._detailBillOutputCode = detailBillOutputCode;
            this._slipTtlBillOutputDiv = slipTtlBillOutputDiv;
        }

        /// <summary>
        /// 得意先一括修正クラスワーク複製処理
        /// </summary>
        /// <returns>CustomerCustomerChangeResultクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCustomerCustomerChangeResultクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CustomerCustomerChangeResult Clone()
        {
            return new CustomerCustomerChangeResult(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._customerCode, this._customerSubCode, this._name, this._name2, this._honorificTitle, this._kana, this._customerSnm, this._outputNameCode, this._outputName, this._corporateDivCode, this._customerAttributeDiv, this._jobTypeCode, this._jobTypeName, this._businessTypeCode, this._businessTypeName, this._salesAreaCode, this._salesAreaName, this._postNo, this._address1, this._address3, this._address4, this._homeTelNo, this._officeTelNo, this._portableTelNo, this._homeFaxNo, this._officeFaxNo, this._othersTelNo, this._mainContactCode, this._searchTelNo, this._mngSectionCode, this._mngSectionName, this._inpSectionCode, this._custAnalysCode1, this._custAnalysCode2, this._custAnalysCode3, this._custAnalysCode4, this._custAnalysCode5, this._custAnalysCode6, this._billOutputCode, this._billOutputName, this._totalDay, this._collectMoneyCode, this._collectMoneyName, this._collectMoneyDay, this._collectCond, this._collectSight, this._claimCode, this._claimName, this._claimName2, this._claimSnm, this._transStopDate, this._dmOutCode, this._dmOutName, this._mainSendMailAddrCd, this._mailAddrKindCode1, this._mailAddrKindName1, this._mailAddress1, this._mailSendCode1, this._mailSendName1, this._mailAddrKindCode2, this._mailAddrKindName2, this._mailAddress2, this._mailSendCode2, this._mailSendName2, this._customerAgentCd, this._customerAgentNm, this._billCollecterCd, this._oldCustomerAgentCd, this._oldCustomerAgentNm, this._custAgentChgDate, this._acceptWholeSale, this._creditMngCode, this._depoDelCode, this._accRecDivCd, this._custSlipNoMngCd, this._pureCode, this._custCTaXLayRefCd, this._consTaxLayMethod, this._totalAmountDispWayCd, this._totalAmntDspWayRef, this._accountNoInfo1, this._accountNoInfo2, this._accountNoInfo3, this._salesUnPrcFrcProcCd, this._salesMoneyFrcProcCd, this._salesCnsTaxFrcProcCd, this._customerSlipNoDiv, this._nTimeCalcStDate, this._customerAgent, this._claimSectionCode, this._claimSectionName, this._carMngDivCd, this._billPartsNoPrtCd, this._deliPartsNoPrtCd, this._defSalesSlipCd, this._lavorRateRank, this._slipTtlPrn, this._depoBankCode, this._depoBankName, this._custWarehouseCd, this._custWarehouseName, this._qrcodePrtCd, this._deliHonorificTtl, this._billHonorificTtl, this._estmHonorificTtl, this._rectHonorificTtl, this._deliHonorTtlPrtDiv, this._billHonorTtlPrtDiv, this._estmHonorTtlPrtDiv, this._rectHonorTtlPrtDiv, this._note1, this._note2, this._note3, this._note4, this._note5, this._note6, this._note7, this._note8, this._note9, this._note10, this._creditMoney, this._warningCreditMoney, this._prsntAccRecBalance, this._rateGPureCode, this._goodsMakerCd, this._custRateGrpCode, this._enterpriseName, this._updEmployeeName, this._inpSectionName, this._billOutPutCodeNm, this._billCollecterNm, this._receiptOutputCode
                , this._salesSlipPrtDiv, this._acpOdrrSlipPrtDiv, this._shipmSlipPrtDiv, this._estimatePrtDiv, this._uoeSlipPrtDiv 
                , this._totalBillOutputDiv, this._detailBillOutputCode, this._slipTtlBillOutputDiv);
        }

        /// <summary>
        /// 得意先一括修正クラスワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のCustomerCustomerChangeResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CustomerCustomerChangeResult target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.CustomerCode == target.CustomerCode)
                 && (this.CustomerSubCode == target.CustomerSubCode)
                 && (this.Name == target.Name)
                 && (this.Name2 == target.Name2)
                 && (this.HonorificTitle == target.HonorificTitle)
                 && (this.Kana == target.Kana)
                 && (this.CustomerSnm == target.CustomerSnm)
                 && (this.OutputNameCode == target.OutputNameCode)
                 //&& (this.OutputName == target.OutputName)
                 && (this.CorporateDivCode == target.CorporateDivCode)
                 && (this.CustomerAttributeDiv == target.CustomerAttributeDiv)
                 && (this.JobTypeCode == target.JobTypeCode)
                 && (this.JobTypeName == target.JobTypeName)
                 && (this.BusinessTypeCode == target.BusinessTypeCode)
                 && (this.BusinessTypeName == target.BusinessTypeName)
                 && (this.SalesAreaCode == target.SalesAreaCode)
                 && (this.SalesAreaName == target.SalesAreaName)
                 && (this.PostNo == target.PostNo)
                 && (this.Address1 == target.Address1)
                 && (this.Address3 == target.Address3)
                 && (this.Address4 == target.Address4)
                 && (this.HomeTelNo == target.HomeTelNo)
                 && (this.OfficeTelNo == target.OfficeTelNo)
                 && (this.PortableTelNo == target.PortableTelNo)
                 && (this.HomeFaxNo == target.HomeFaxNo)
                 && (this.OfficeFaxNo == target.OfficeFaxNo)
                 && (this.OthersTelNo == target.OthersTelNo)
                 && (this.MainContactCode == target.MainContactCode)
                 && (this.SearchTelNo == target.SearchTelNo)
                 && (this.MngSectionCode == target.MngSectionCode)
                 && (this.MngSectionName == target.MngSectionName)
                 && (this.InpSectionCode == target.InpSectionCode)
                 && (this.CustAnalysCode1 == target.CustAnalysCode1)
                 && (this.CustAnalysCode2 == target.CustAnalysCode2)
                 && (this.CustAnalysCode3 == target.CustAnalysCode3)
                 && (this.CustAnalysCode4 == target.CustAnalysCode4)
                 && (this.CustAnalysCode5 == target.CustAnalysCode5)
                 && (this.CustAnalysCode6 == target.CustAnalysCode6)
                 && (this.BillOutputCode == target.BillOutputCode)
                 && (this.BillOutputName == target.BillOutputName)
                 && (this.TotalDay == target.TotalDay)
                 && (this.CollectMoneyCode == target.CollectMoneyCode)
                 && (this.CollectMoneyName == target.CollectMoneyName)
                 && (this.CollectMoneyDay == target.CollectMoneyDay)
                 && (this.CollectCond == target.CollectCond)
                 && (this.CollectSight == target.CollectSight)
                 && (this.ClaimCode == target.ClaimCode)
                 && (this.ClaimName == target.ClaimName)
                 && (this.ClaimName2 == target.ClaimName2)
                 && (this.ClaimSnm == target.ClaimSnm)
                 && (this.TransStopDate == target.TransStopDate)
                 && (this.DmOutCode == target.DmOutCode)
                 && (this.DmOutName == target.DmOutName)
                 && (this.MainSendMailAddrCd == target.MainSendMailAddrCd)
                 && (this.MailAddrKindCode1 == target.MailAddrKindCode1)
                 && (this.MailAddrKindName1 == target.MailAddrKindName1)
                 && (this.MailAddress1 == target.MailAddress1)
                 && (this.MailSendCode1 == target.MailSendCode1)
                 && (this.MailSendName1 == target.MailSendName1)
                 && (this.MailAddrKindCode2 == target.MailAddrKindCode2)
                 && (this.MailAddrKindName2 == target.MailAddrKindName2)
                 && (this.MailAddress2 == target.MailAddress2)
                 && (this.MailSendCode2 == target.MailSendCode2)
                 && (this.MailSendName2 == target.MailSendName2)
                 && (this.CustomerAgentCd == target.CustomerAgentCd)
                 && (this.CustomerAgentNm == target.CustomerAgentNm)
                 && (this.BillCollecterCd == target.BillCollecterCd)
                 && (this.OldCustomerAgentCd == target.OldCustomerAgentCd)
                 && (this.OldCustomerAgentNm == target.OldCustomerAgentNm)
                 && (this.CustAgentChgDate == target.CustAgentChgDate)
                 && (this.AcceptWholeSale == target.AcceptWholeSale)
                 && (this.CreditMngCode == target.CreditMngCode)
                 && (this.DepoDelCode == target.DepoDelCode)
                 && (this.AccRecDivCd == target.AccRecDivCd)
                 && (this.CustSlipNoMngCd == target.CustSlipNoMngCd)
                 && (this.PureCode == target.PureCode)
                 && (this.CustCTaXLayRefCd == target.CustCTaXLayRefCd)
                 && (this.ConsTaxLayMethod == target.ConsTaxLayMethod)
                 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                 && (this.TotalAmntDspWayRef == target.TotalAmntDspWayRef)
                 && (this.AccountNoInfo1 == target.AccountNoInfo1)
                 && (this.AccountNoInfo2 == target.AccountNoInfo2)
                 && (this.AccountNoInfo3 == target.AccountNoInfo3)
                 && (this.SalesUnPrcFrcProcCd == target.SalesUnPrcFrcProcCd)
                 && (this.SalesMoneyFrcProcCd == target.SalesMoneyFrcProcCd)
                 && (this.SalesCnsTaxFrcProcCd == target.SalesCnsTaxFrcProcCd)
                 && (this.CustomerSlipNoDiv == target.CustomerSlipNoDiv)
                 && (this.NTimeCalcStDate == target.NTimeCalcStDate)
                 && (this.CustomerAgent == target.CustomerAgent)
                 && (this.ClaimSectionCode == target.ClaimSectionCode)
                 && (this.ClaimSectionName == target.ClaimSectionName)
                 && (this.CarMngDivCd == target.CarMngDivCd)
                 && (this.BillPartsNoPrtCd == target.BillPartsNoPrtCd)
                 && (this.DeliPartsNoPrtCd == target.DeliPartsNoPrtCd)
                 && (this.DefSalesSlipCd == target.DefSalesSlipCd)
                 && (this.LavorRateRank == target.LavorRateRank)
                 && (this.SlipTtlPrn == target.SlipTtlPrn)
                 && (this.DepoBankCode == target.DepoBankCode)
                 && (this.DepoBankName == target.DepoBankName)
                 && (this.CustWarehouseCd == target.CustWarehouseCd)
                 && (this.CustWarehouseName == target.CustWarehouseName)
                 && (this.QrcodePrtCd == target.QrcodePrtCd)
                 && (this.DeliHonorificTtl == target.DeliHonorificTtl)
                 && (this.BillHonorificTtl == target.BillHonorificTtl)
                 && (this.EstmHonorificTtl == target.EstmHonorificTtl)
                 && (this.RectHonorificTtl == target.RectHonorificTtl)
                 && (this.DeliHonorTtlPrtDiv == target.DeliHonorTtlPrtDiv)
                 && (this.BillHonorTtlPrtDiv == target.BillHonorTtlPrtDiv)
                 && (this.EstmHonorTtlPrtDiv == target.EstmHonorTtlPrtDiv)
                 && (this.RectHonorTtlPrtDiv == target.RectHonorTtlPrtDiv)
                 && (this.Note1 == target.Note1)
                 && (this.Note2 == target.Note2)
                 && (this.Note3 == target.Note3)
                 && (this.Note4 == target.Note4)
                 && (this.Note5 == target.Note5)
                 && (this.Note6 == target.Note6)
                 && (this.Note7 == target.Note7)
                 && (this.Note8 == target.Note8)
                 && (this.Note9 == target.Note9)
                 && (this.Note10 == target.Note10)
                 && (this.CreditMoney == target.CreditMoney)
                 && (this.WarningCreditMoney == target.WarningCreditMoney)
                 && (this.PrsntAccRecBalance == target.PrsntAccRecBalance)
                 && (this.RateGPureCode == target.RateGPureCode)
                 && (this.GoodsMakerCd == target.GoodsMakerCd)
                 && (this.CustRateGrpCode == target.CustRateGrpCode)
                 && (this.EnterpriseName == target.EnterpriseName)
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.InpSectionName == target.InpSectionName)
                 && (this.BillOutPutCodeNm == target.BillOutPutCodeNm)
                 //&& (this.BillCollecterNm == target.BillCollecterNm)
                 && (this.ReceiptOutputCode == target.ReceiptOutputCode)

                 && (this.SalesSlipPrtDiv == target.SalesSlipPrtDiv)
                 && (this.AcpOdrrSlipPrtDiv == target.AcpOdrrSlipPrtDiv)
                 && (this.ShipmSlipPrtDiv == target.ShipmSlipPrtDiv)
                 && (this.EstimatePrtDiv == target.EstimatePrtDiv)
                 && (this.UOESlipPrtDiv == target.UOESlipPrtDiv)

                 && (this.TotalBillOutputDiv == target.TotalBillOutputDiv)
                 && (this.DetailBillOutputCode == target.DetailBillOutputCode)
                 && (this.SlipTtlBillOutputDiv == target.SlipTtlBillOutputDiv)
                 );
        }

        /// <summary>
        /// 得意先一括修正クラスワーク比較処理
        /// </summary>
        /// <param name="customerCustomerChangeResult1">
        ///                    比較するCustomerCustomerChangeResultクラスのインスタンス
        /// </param>
        /// <param name="customerCustomerChangeResult2">比較するCustomerCustomerChangeResultクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeResultクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CustomerCustomerChangeResult customerCustomerChangeResult1, CustomerCustomerChangeResult customerCustomerChangeResult2)
        {
            return ((customerCustomerChangeResult1.CreateDateTime == customerCustomerChangeResult2.CreateDateTime)
                 && (customerCustomerChangeResult1.UpdateDateTime == customerCustomerChangeResult2.UpdateDateTime)
                 && (customerCustomerChangeResult1.EnterpriseCode == customerCustomerChangeResult2.EnterpriseCode)
                 && (customerCustomerChangeResult1.FileHeaderGuid == customerCustomerChangeResult2.FileHeaderGuid)
                 && (customerCustomerChangeResult1.UpdEmployeeCode == customerCustomerChangeResult2.UpdEmployeeCode)
                 && (customerCustomerChangeResult1.UpdAssemblyId1 == customerCustomerChangeResult2.UpdAssemblyId1)
                 && (customerCustomerChangeResult1.UpdAssemblyId2 == customerCustomerChangeResult2.UpdAssemblyId2)
                 && (customerCustomerChangeResult1.LogicalDeleteCode == customerCustomerChangeResult2.LogicalDeleteCode)
                 && (customerCustomerChangeResult1.CustomerCode == customerCustomerChangeResult2.CustomerCode)
                 && (customerCustomerChangeResult1.CustomerSubCode == customerCustomerChangeResult2.CustomerSubCode)
                 && (customerCustomerChangeResult1.Name == customerCustomerChangeResult2.Name)
                 && (customerCustomerChangeResult1.Name2 == customerCustomerChangeResult2.Name2)
                 && (customerCustomerChangeResult1.HonorificTitle == customerCustomerChangeResult2.HonorificTitle)
                 && (customerCustomerChangeResult1.Kana == customerCustomerChangeResult2.Kana)
                 && (customerCustomerChangeResult1.CustomerSnm == customerCustomerChangeResult2.CustomerSnm)
                 && (customerCustomerChangeResult1.OutputNameCode == customerCustomerChangeResult2.OutputNameCode)
                 //&& (customerCustomerChangeResult1.OutputName == customerCustomerChangeResult2.OutputName)
                 && (customerCustomerChangeResult1.CorporateDivCode == customerCustomerChangeResult2.CorporateDivCode)
                 && (customerCustomerChangeResult1.CustomerAttributeDiv == customerCustomerChangeResult2.CustomerAttributeDiv)
                 && (customerCustomerChangeResult1.JobTypeCode == customerCustomerChangeResult2.JobTypeCode)
                 && (customerCustomerChangeResult1.JobTypeName == customerCustomerChangeResult2.JobTypeName)
                 && (customerCustomerChangeResult1.BusinessTypeCode == customerCustomerChangeResult2.BusinessTypeCode)
                 && (customerCustomerChangeResult1.BusinessTypeName == customerCustomerChangeResult2.BusinessTypeName)
                 && (customerCustomerChangeResult1.SalesAreaCode == customerCustomerChangeResult2.SalesAreaCode)
                 && (customerCustomerChangeResult1.SalesAreaName == customerCustomerChangeResult2.SalesAreaName)
                 && (customerCustomerChangeResult1.PostNo == customerCustomerChangeResult2.PostNo)
                 && (customerCustomerChangeResult1.Address1 == customerCustomerChangeResult2.Address1)
                 && (customerCustomerChangeResult1.Address3 == customerCustomerChangeResult2.Address3)
                 && (customerCustomerChangeResult1.Address4 == customerCustomerChangeResult2.Address4)
                 && (customerCustomerChangeResult1.HomeTelNo == customerCustomerChangeResult2.HomeTelNo)
                 && (customerCustomerChangeResult1.OfficeTelNo == customerCustomerChangeResult2.OfficeTelNo)
                 && (customerCustomerChangeResult1.PortableTelNo == customerCustomerChangeResult2.PortableTelNo)
                 && (customerCustomerChangeResult1.HomeFaxNo == customerCustomerChangeResult2.HomeFaxNo)
                 && (customerCustomerChangeResult1.OfficeFaxNo == customerCustomerChangeResult2.OfficeFaxNo)
                 && (customerCustomerChangeResult1.OthersTelNo == customerCustomerChangeResult2.OthersTelNo)
                 && (customerCustomerChangeResult1.MainContactCode == customerCustomerChangeResult2.MainContactCode)
                 && (customerCustomerChangeResult1.SearchTelNo == customerCustomerChangeResult2.SearchTelNo)
                 && (customerCustomerChangeResult1.MngSectionCode == customerCustomerChangeResult2.MngSectionCode)
                 && (customerCustomerChangeResult1.MngSectionName == customerCustomerChangeResult2.MngSectionName)
                 && (customerCustomerChangeResult1.InpSectionCode == customerCustomerChangeResult2.InpSectionCode)
                 && (customerCustomerChangeResult1.CustAnalysCode1 == customerCustomerChangeResult2.CustAnalysCode1)
                 && (customerCustomerChangeResult1.CustAnalysCode2 == customerCustomerChangeResult2.CustAnalysCode2)
                 && (customerCustomerChangeResult1.CustAnalysCode3 == customerCustomerChangeResult2.CustAnalysCode3)
                 && (customerCustomerChangeResult1.CustAnalysCode4 == customerCustomerChangeResult2.CustAnalysCode4)
                 && (customerCustomerChangeResult1.CustAnalysCode5 == customerCustomerChangeResult2.CustAnalysCode5)
                 && (customerCustomerChangeResult1.CustAnalysCode6 == customerCustomerChangeResult2.CustAnalysCode6)
                 && (customerCustomerChangeResult1.BillOutputCode == customerCustomerChangeResult2.BillOutputCode)
                 && (customerCustomerChangeResult1.BillOutputName == customerCustomerChangeResult2.BillOutputName)
                 && (customerCustomerChangeResult1.TotalDay == customerCustomerChangeResult2.TotalDay)
                 && (customerCustomerChangeResult1.CollectMoneyCode == customerCustomerChangeResult2.CollectMoneyCode)
                 && (customerCustomerChangeResult1.CollectMoneyName == customerCustomerChangeResult2.CollectMoneyName)
                 && (customerCustomerChangeResult1.CollectMoneyDay == customerCustomerChangeResult2.CollectMoneyDay)
                 && (customerCustomerChangeResult1.CollectCond == customerCustomerChangeResult2.CollectCond)
                 && (customerCustomerChangeResult1.CollectSight == customerCustomerChangeResult2.CollectSight)
                 && (customerCustomerChangeResult1.ClaimCode == customerCustomerChangeResult2.ClaimCode)
                 && (customerCustomerChangeResult1.ClaimName == customerCustomerChangeResult2.ClaimName)
                 && (customerCustomerChangeResult1.ClaimName2 == customerCustomerChangeResult2.ClaimName2)
                 && (customerCustomerChangeResult1.ClaimSnm == customerCustomerChangeResult2.ClaimSnm)
                 && (customerCustomerChangeResult1.TransStopDate == customerCustomerChangeResult2.TransStopDate)
                 && (customerCustomerChangeResult1.DmOutCode == customerCustomerChangeResult2.DmOutCode)
                 && (customerCustomerChangeResult1.DmOutName == customerCustomerChangeResult2.DmOutName)
                 && (customerCustomerChangeResult1.MainSendMailAddrCd == customerCustomerChangeResult2.MainSendMailAddrCd)
                 && (customerCustomerChangeResult1.MailAddrKindCode1 == customerCustomerChangeResult2.MailAddrKindCode1)
                 && (customerCustomerChangeResult1.MailAddrKindName1 == customerCustomerChangeResult2.MailAddrKindName1)
                 && (customerCustomerChangeResult1.MailAddress1 == customerCustomerChangeResult2.MailAddress1)
                 && (customerCustomerChangeResult1.MailSendCode1 == customerCustomerChangeResult2.MailSendCode1)
                 && (customerCustomerChangeResult1.MailSendName1 == customerCustomerChangeResult2.MailSendName1)
                 && (customerCustomerChangeResult1.MailAddrKindCode2 == customerCustomerChangeResult2.MailAddrKindCode2)
                 && (customerCustomerChangeResult1.MailAddrKindName2 == customerCustomerChangeResult2.MailAddrKindName2)
                 && (customerCustomerChangeResult1.MailAddress2 == customerCustomerChangeResult2.MailAddress2)
                 && (customerCustomerChangeResult1.MailSendCode2 == customerCustomerChangeResult2.MailSendCode2)
                 && (customerCustomerChangeResult1.MailSendName2 == customerCustomerChangeResult2.MailSendName2)
                 && (customerCustomerChangeResult1.CustomerAgentCd == customerCustomerChangeResult2.CustomerAgentCd)
                 && (customerCustomerChangeResult1.CustomerAgentNm == customerCustomerChangeResult2.CustomerAgentNm)
                 && (customerCustomerChangeResult1.BillCollecterCd == customerCustomerChangeResult2.BillCollecterCd)
                 && (customerCustomerChangeResult1.OldCustomerAgentCd == customerCustomerChangeResult2.OldCustomerAgentCd)
                 && (customerCustomerChangeResult1.OldCustomerAgentNm == customerCustomerChangeResult2.OldCustomerAgentNm)
                 && (customerCustomerChangeResult1.CustAgentChgDate == customerCustomerChangeResult2.CustAgentChgDate)
                 && (customerCustomerChangeResult1.AcceptWholeSale == customerCustomerChangeResult2.AcceptWholeSale)
                 && (customerCustomerChangeResult1.CreditMngCode == customerCustomerChangeResult2.CreditMngCode)
                 && (customerCustomerChangeResult1.DepoDelCode == customerCustomerChangeResult2.DepoDelCode)
                 && (customerCustomerChangeResult1.AccRecDivCd == customerCustomerChangeResult2.AccRecDivCd)
                 && (customerCustomerChangeResult1.CustSlipNoMngCd == customerCustomerChangeResult2.CustSlipNoMngCd)
                 && (customerCustomerChangeResult1.PureCode == customerCustomerChangeResult2.PureCode)
                 && (customerCustomerChangeResult1.CustCTaXLayRefCd == customerCustomerChangeResult2.CustCTaXLayRefCd)
                 && (customerCustomerChangeResult1.ConsTaxLayMethod == customerCustomerChangeResult2.ConsTaxLayMethod)
                 && (customerCustomerChangeResult1.TotalAmountDispWayCd == customerCustomerChangeResult2.TotalAmountDispWayCd)
                 && (customerCustomerChangeResult1.TotalAmntDspWayRef == customerCustomerChangeResult2.TotalAmntDspWayRef)
                 && (customerCustomerChangeResult1.AccountNoInfo1 == customerCustomerChangeResult2.AccountNoInfo1)
                 && (customerCustomerChangeResult1.AccountNoInfo2 == customerCustomerChangeResult2.AccountNoInfo2)
                 && (customerCustomerChangeResult1.AccountNoInfo3 == customerCustomerChangeResult2.AccountNoInfo3)
                 && (customerCustomerChangeResult1.SalesUnPrcFrcProcCd == customerCustomerChangeResult2.SalesUnPrcFrcProcCd)
                 && (customerCustomerChangeResult1.SalesMoneyFrcProcCd == customerCustomerChangeResult2.SalesMoneyFrcProcCd)
                 && (customerCustomerChangeResult1.SalesCnsTaxFrcProcCd == customerCustomerChangeResult2.SalesCnsTaxFrcProcCd)
                 && (customerCustomerChangeResult1.CustomerSlipNoDiv == customerCustomerChangeResult2.CustomerSlipNoDiv)
                 && (customerCustomerChangeResult1.NTimeCalcStDate == customerCustomerChangeResult2.NTimeCalcStDate)
                 && (customerCustomerChangeResult1.CustomerAgent == customerCustomerChangeResult2.CustomerAgent)
                 && (customerCustomerChangeResult1.ClaimSectionCode == customerCustomerChangeResult2.ClaimSectionCode)
                 && (customerCustomerChangeResult1.ClaimSectionName == customerCustomerChangeResult2.ClaimSectionName)
                 && (customerCustomerChangeResult1.CarMngDivCd == customerCustomerChangeResult2.CarMngDivCd)
                 && (customerCustomerChangeResult1.BillPartsNoPrtCd == customerCustomerChangeResult2.BillPartsNoPrtCd)
                 && (customerCustomerChangeResult1.DeliPartsNoPrtCd == customerCustomerChangeResult2.DeliPartsNoPrtCd)
                 && (customerCustomerChangeResult1.DefSalesSlipCd == customerCustomerChangeResult2.DefSalesSlipCd)
                 && (customerCustomerChangeResult1.LavorRateRank == customerCustomerChangeResult2.LavorRateRank)
                 && (customerCustomerChangeResult1.SlipTtlPrn == customerCustomerChangeResult2.SlipTtlPrn)
                 && (customerCustomerChangeResult1.DepoBankCode == customerCustomerChangeResult2.DepoBankCode)
                 && (customerCustomerChangeResult1.DepoBankName == customerCustomerChangeResult2.DepoBankName)
                 && (customerCustomerChangeResult1.CustWarehouseCd == customerCustomerChangeResult2.CustWarehouseCd)
                 && (customerCustomerChangeResult1.CustWarehouseName == customerCustomerChangeResult2.CustWarehouseName)
                 && (customerCustomerChangeResult1.QrcodePrtCd == customerCustomerChangeResult2.QrcodePrtCd)
                 && (customerCustomerChangeResult1.DeliHonorificTtl == customerCustomerChangeResult2.DeliHonorificTtl)
                 && (customerCustomerChangeResult1.BillHonorificTtl == customerCustomerChangeResult2.BillHonorificTtl)
                 && (customerCustomerChangeResult1.EstmHonorificTtl == customerCustomerChangeResult2.EstmHonorificTtl)
                 && (customerCustomerChangeResult1.RectHonorificTtl == customerCustomerChangeResult2.RectHonorificTtl)
                 && (customerCustomerChangeResult1.DeliHonorTtlPrtDiv == customerCustomerChangeResult2.DeliHonorTtlPrtDiv)
                 && (customerCustomerChangeResult1.BillHonorTtlPrtDiv == customerCustomerChangeResult2.BillHonorTtlPrtDiv)
                 && (customerCustomerChangeResult1.EstmHonorTtlPrtDiv == customerCustomerChangeResult2.EstmHonorTtlPrtDiv)
                 && (customerCustomerChangeResult1.RectHonorTtlPrtDiv == customerCustomerChangeResult2.RectHonorTtlPrtDiv)
                 && (customerCustomerChangeResult1.Note1 == customerCustomerChangeResult2.Note1)
                 && (customerCustomerChangeResult1.Note2 == customerCustomerChangeResult2.Note2)
                 && (customerCustomerChangeResult1.Note3 == customerCustomerChangeResult2.Note3)
                 && (customerCustomerChangeResult1.Note4 == customerCustomerChangeResult2.Note4)
                 && (customerCustomerChangeResult1.Note5 == customerCustomerChangeResult2.Note5)
                 && (customerCustomerChangeResult1.Note6 == customerCustomerChangeResult2.Note6)
                 && (customerCustomerChangeResult1.Note7 == customerCustomerChangeResult2.Note7)
                 && (customerCustomerChangeResult1.Note8 == customerCustomerChangeResult2.Note8)
                 && (customerCustomerChangeResult1.Note9 == customerCustomerChangeResult2.Note9)
                 && (customerCustomerChangeResult1.Note10 == customerCustomerChangeResult2.Note10)
                 && (customerCustomerChangeResult1.CreditMoney == customerCustomerChangeResult2.CreditMoney)
                 && (customerCustomerChangeResult1.WarningCreditMoney == customerCustomerChangeResult2.WarningCreditMoney)
                 && (customerCustomerChangeResult1.PrsntAccRecBalance == customerCustomerChangeResult2.PrsntAccRecBalance)
                 && (customerCustomerChangeResult1.RateGPureCode == customerCustomerChangeResult2.RateGPureCode)
                 && (customerCustomerChangeResult1.GoodsMakerCd == customerCustomerChangeResult2.GoodsMakerCd)
                 && (customerCustomerChangeResult1.CustRateGrpCode == customerCustomerChangeResult2.CustRateGrpCode)
                 && (customerCustomerChangeResult1.EnterpriseName == customerCustomerChangeResult2.EnterpriseName)
                 && (customerCustomerChangeResult1.UpdEmployeeName == customerCustomerChangeResult2.UpdEmployeeName)
                 && (customerCustomerChangeResult1.InpSectionName == customerCustomerChangeResult2.InpSectionName)
                 && (customerCustomerChangeResult1.BillOutPutCodeNm == customerCustomerChangeResult2.BillOutPutCodeNm)
                 //&& (customerCustomerChangeResult1.BillCollecterNm == customerCustomerChangeResult2.BillCollecterNm)
                 && (customerCustomerChangeResult1.ReceiptOutputCode == customerCustomerChangeResult2.ReceiptOutputCode)

                 && (customerCustomerChangeResult1.SalesSlipPrtDiv == customerCustomerChangeResult2.SalesSlipPrtDiv)
                 && (customerCustomerChangeResult1.AcpOdrrSlipPrtDiv == customerCustomerChangeResult2.AcpOdrrSlipPrtDiv)
                 && (customerCustomerChangeResult1.ShipmSlipPrtDiv == customerCustomerChangeResult2.ShipmSlipPrtDiv)
                 && (customerCustomerChangeResult1.EstimatePrtDiv == customerCustomerChangeResult2.EstimatePrtDiv)
                 && (customerCustomerChangeResult1.UOESlipPrtDiv == customerCustomerChangeResult2.UOESlipPrtDiv)

                 && (customerCustomerChangeResult1.TotalBillOutputDiv == customerCustomerChangeResult2.TotalBillOutputDiv)
                 && (customerCustomerChangeResult1.DetailBillOutputCode == customerCustomerChangeResult2.DetailBillOutputCode)
                 && (customerCustomerChangeResult1.SlipTtlBillOutputDiv == customerCustomerChangeResult2.SlipTtlBillOutputDiv)
                 );
        }
        /// <summary>
        /// 得意先一括修正クラスワーク比較処理
        /// </summary>
        /// <param name="target">比較対象のCustomerCustomerChangeResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeResultクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CustomerCustomerChangeResult target)
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
            if (this.CustomerCode != target.CustomerCode) resList.Add("CustomerCode");
            if (this.CustomerSubCode != target.CustomerSubCode) resList.Add("CustomerSubCode");
            if (this.Name != target.Name) resList.Add("Name");
            if (this.Name2 != target.Name2) resList.Add("Name2");
            if (this.HonorificTitle != target.HonorificTitle) resList.Add("HonorificTitle");
            if (this.Kana != target.Kana) resList.Add("Kana");
            if (this.CustomerSnm != target.CustomerSnm) resList.Add("CustomerSnm");
            if (this.OutputNameCode != target.OutputNameCode) resList.Add("OutputNameCode");
            if (this.OutputName != target.OutputName) resList.Add("OutputName");
            if (this.CorporateDivCode != target.CorporateDivCode) resList.Add("CorporateDivCode");
            if (this.CustomerAttributeDiv != target.CustomerAttributeDiv) resList.Add("CustomerAttributeDiv");
            if (this.JobTypeCode != target.JobTypeCode) resList.Add("JobTypeCode");
            if (this.JobTypeName != target.JobTypeName) resList.Add("JobTypeName");
            if (this.BusinessTypeCode != target.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (this.BusinessTypeName != target.BusinessTypeName) resList.Add("BusinessTypeName");
            if (this.SalesAreaCode != target.SalesAreaCode) resList.Add("SalesAreaCode");
            if (this.SalesAreaName != target.SalesAreaName) resList.Add("SalesAreaName");
            if (this.PostNo != target.PostNo) resList.Add("PostNo");
            if (this.Address1 != target.Address1) resList.Add("Address1");
            if (this.Address3 != target.Address3) resList.Add("Address3");
            if (this.Address4 != target.Address4) resList.Add("Address4");
            if (this.HomeTelNo != target.HomeTelNo) resList.Add("HomeTelNo");
            if (this.OfficeTelNo != target.OfficeTelNo) resList.Add("OfficeTelNo");
            if (this.PortableTelNo != target.PortableTelNo) resList.Add("PortableTelNo");
            if (this.HomeFaxNo != target.HomeFaxNo) resList.Add("HomeFaxNo");
            if (this.OfficeFaxNo != target.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (this.OthersTelNo != target.OthersTelNo) resList.Add("OthersTelNo");
            if (this.MainContactCode != target.MainContactCode) resList.Add("MainContactCode");
            if (this.SearchTelNo != target.SearchTelNo) resList.Add("SearchTelNo");
            if (this.MngSectionCode != target.MngSectionCode) resList.Add("MngSectionCode");
            if (this.MngSectionName != target.MngSectionName) resList.Add("MngSectionName");
            if (this.InpSectionCode != target.InpSectionCode) resList.Add("InpSectionCode");
            if (this.CustAnalysCode1 != target.CustAnalysCode1) resList.Add("CustAnalysCode1");
            if (this.CustAnalysCode2 != target.CustAnalysCode2) resList.Add("CustAnalysCode2");
            if (this.CustAnalysCode3 != target.CustAnalysCode3) resList.Add("CustAnalysCode3");
            if (this.CustAnalysCode4 != target.CustAnalysCode4) resList.Add("CustAnalysCode4");
            if (this.CustAnalysCode5 != target.CustAnalysCode5) resList.Add("CustAnalysCode5");
            if (this.CustAnalysCode6 != target.CustAnalysCode6) resList.Add("CustAnalysCode6");
            if (this.BillOutputCode != target.BillOutputCode) resList.Add("BillOutputCode");
            if (this.BillOutputName != target.BillOutputName) resList.Add("BillOutputName");
            if (this.TotalDay != target.TotalDay) resList.Add("TotalDay");
            if (this.CollectMoneyCode != target.CollectMoneyCode) resList.Add("CollectMoneyCode");
            if (this.CollectMoneyName != target.CollectMoneyName) resList.Add("CollectMoneyName");
            if (this.CollectMoneyDay != target.CollectMoneyDay) resList.Add("CollectMoneyDay");
            if (this.CollectCond != target.CollectCond) resList.Add("CollectCond");
            if (this.CollectSight != target.CollectSight) resList.Add("CollectSight");
            if (this.ClaimCode != target.ClaimCode) resList.Add("ClaimCode");
            if (this.ClaimName != target.ClaimName) resList.Add("ClaimName");
            if (this.ClaimName2 != target.ClaimName2) resList.Add("ClaimName2");
            if (this.ClaimSnm != target.ClaimSnm) resList.Add("ClaimSnm");
            if (this.TransStopDate != target.TransStopDate) resList.Add("TransStopDate");
            if (this.DmOutCode != target.DmOutCode) resList.Add("DmOutCode");
            if (this.DmOutName != target.DmOutName) resList.Add("DmOutName");
            if (this.MainSendMailAddrCd != target.MainSendMailAddrCd) resList.Add("MainSendMailAddrCd");
            if (this.MailAddrKindCode1 != target.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (this.MailAddrKindName1 != target.MailAddrKindName1) resList.Add("MailAddrKindName1");
            if (this.MailAddress1 != target.MailAddress1) resList.Add("MailAddress1");
            if (this.MailSendCode1 != target.MailSendCode1) resList.Add("MailSendCode1");
            if (this.MailSendName1 != target.MailSendName1) resList.Add("MailSendName1");
            if (this.MailAddrKindCode2 != target.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (this.MailAddrKindName2 != target.MailAddrKindName2) resList.Add("MailAddrKindName2");
            if (this.MailAddress2 != target.MailAddress2) resList.Add("MailAddress2");
            if (this.MailSendCode2 != target.MailSendCode2) resList.Add("MailSendCode2");
            if (this.MailSendName2 != target.MailSendName2) resList.Add("MailSendName2");
            if (this.CustomerAgentCd != target.CustomerAgentCd) resList.Add("CustomerAgentCd");
            if (this.CustomerAgentNm != target.CustomerAgentNm) resList.Add("CustomerAgentNm");
            if (this.BillCollecterCd != target.BillCollecterCd) resList.Add("BillCollecterCd");
            if (this.OldCustomerAgentCd != target.OldCustomerAgentCd) resList.Add("OldCustomerAgentCd");
            if (this.OldCustomerAgentNm != target.OldCustomerAgentNm) resList.Add("OldCustomerAgentNm");
            if (this.CustAgentChgDate != target.CustAgentChgDate) resList.Add("CustAgentChgDate");
            if (this.AcceptWholeSale != target.AcceptWholeSale) resList.Add("AcceptWholeSale");
            if (this.CreditMngCode != target.CreditMngCode) resList.Add("CreditMngCode");
            if (this.DepoDelCode != target.DepoDelCode) resList.Add("DepoDelCode");
            if (this.AccRecDivCd != target.AccRecDivCd) resList.Add("AccRecDivCd");
            if (this.CustSlipNoMngCd != target.CustSlipNoMngCd) resList.Add("CustSlipNoMngCd");
            if (this.PureCode != target.PureCode) resList.Add("PureCode");
            if (this.CustCTaXLayRefCd != target.CustCTaXLayRefCd) resList.Add("CustCTaXLayRefCd");
            if (this.ConsTaxLayMethod != target.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (this.TotalAmntDspWayRef != target.TotalAmntDspWayRef) resList.Add("TotalAmntDspWayRef");
            if (this.AccountNoInfo1 != target.AccountNoInfo1) resList.Add("AccountNoInfo1");
            if (this.AccountNoInfo2 != target.AccountNoInfo2) resList.Add("AccountNoInfo2");
            if (this.AccountNoInfo3 != target.AccountNoInfo3) resList.Add("AccountNoInfo3");
            if (this.SalesUnPrcFrcProcCd != target.SalesUnPrcFrcProcCd) resList.Add("SalesUnPrcFrcProcCd");
            if (this.SalesMoneyFrcProcCd != target.SalesMoneyFrcProcCd) resList.Add("SalesMoneyFrcProcCd");
            if (this.SalesCnsTaxFrcProcCd != target.SalesCnsTaxFrcProcCd) resList.Add("SalesCnsTaxFrcProcCd");
            if (this.CustomerSlipNoDiv != target.CustomerSlipNoDiv) resList.Add("CustomerSlipNoDiv");
            if (this.NTimeCalcStDate != target.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (this.CustomerAgent != target.CustomerAgent) resList.Add("CustomerAgent");
            if (this.ClaimSectionCode != target.ClaimSectionCode) resList.Add("ClaimSectionCode");
            if (this.ClaimSectionName != target.ClaimSectionName) resList.Add("ClaimSectionName");
            if (this.CarMngDivCd != target.CarMngDivCd) resList.Add("CarMngDivCd");
            if (this.BillPartsNoPrtCd != target.BillPartsNoPrtCd) resList.Add("BillPartsNoPrtCd");
            if (this.DeliPartsNoPrtCd != target.DeliPartsNoPrtCd) resList.Add("DeliPartsNoPrtCd");
            if (this.DefSalesSlipCd != target.DefSalesSlipCd) resList.Add("DefSalesSlipCd");
            if (this.LavorRateRank != target.LavorRateRank) resList.Add("LavorRateRank");
            if (this.SlipTtlPrn != target.SlipTtlPrn) resList.Add("SlipTtlPrn");
            if (this.DepoBankCode != target.DepoBankCode) resList.Add("DepoBankCode");
            if (this.DepoBankName != target.DepoBankName) resList.Add("DepoBankName");
            if (this.CustWarehouseCd != target.CustWarehouseCd) resList.Add("CustWarehouseCd");
            if (this.CustWarehouseName != target.CustWarehouseName) resList.Add("CustWarehouseName");
            if (this.QrcodePrtCd != target.QrcodePrtCd) resList.Add("QrcodePrtCd");
            if (this.DeliHonorificTtl != target.DeliHonorificTtl) resList.Add("DeliHonorificTtl");
            if (this.BillHonorificTtl != target.BillHonorificTtl) resList.Add("BillHonorificTtl");
            if (this.EstmHonorificTtl != target.EstmHonorificTtl) resList.Add("EstmHonorificTtl");
            if (this.RectHonorificTtl != target.RectHonorificTtl) resList.Add("RectHonorificTtl");
            if (this.DeliHonorTtlPrtDiv != target.DeliHonorTtlPrtDiv) resList.Add("DeliHonorTtlPrtDiv");
            if (this.BillHonorTtlPrtDiv != target.BillHonorTtlPrtDiv) resList.Add("BillHonorTtlPrtDiv");
            if (this.EstmHonorTtlPrtDiv != target.EstmHonorTtlPrtDiv) resList.Add("EstmHonorTtlPrtDiv");
            if (this.RectHonorTtlPrtDiv != target.RectHonorTtlPrtDiv) resList.Add("RectHonorTtlPrtDiv");
            if (this.Note1 != target.Note1) resList.Add("Note1");
            if (this.Note2 != target.Note2) resList.Add("Note2");
            if (this.Note3 != target.Note3) resList.Add("Note3");
            if (this.Note4 != target.Note4) resList.Add("Note4");
            if (this.Note5 != target.Note5) resList.Add("Note5");
            if (this.Note6 != target.Note6) resList.Add("Note6");
            if (this.Note7 != target.Note7) resList.Add("Note7");
            if (this.Note8 != target.Note8) resList.Add("Note8");
            if (this.Note9 != target.Note9) resList.Add("Note9");
            if (this.Note10 != target.Note10) resList.Add("Note10");
            if (this.CreditMoney != target.CreditMoney) resList.Add("CreditMoney");
            if (this.WarningCreditMoney != target.WarningCreditMoney) resList.Add("WarningCreditMoney");
            if (this.PrsntAccRecBalance != target.PrsntAccRecBalance) resList.Add("PrsntAccRecBalance");
            if (this.RateGPureCode != target.RateGPureCode) resList.Add("RateGPureCode");
            if (this.GoodsMakerCd != target.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (this.CustRateGrpCode != target.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (this.InpSectionName != target.InpSectionName) resList.Add("InpSectionName");
            if (this.BillOutPutCodeNm != target.BillOutPutCodeNm) resList.Add("BillOutPutCodeNm");
            if (this.BillCollecterNm != target.BillCollecterNm) resList.Add("BillCollecterNm");
            if (this.ReceiptOutputCode != target.ReceiptOutputCode) resList.Add("ReceiptOutputCode");

            if (this.SalesSlipPrtDiv != target.SalesSlipPrtDiv) resList.Add("SalesSlipPrtDiv");
            if (this.AcpOdrrSlipPrtDiv != target.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (this.ShipmSlipPrtDiv != target.ShipmSlipPrtDiv) resList.Add("ShipmSlipPrtDiv");
            if (this.EstimatePrtDiv != target.EstimatePrtDiv) resList.Add("EstimatePrtDiv");
            if (this.UOESlipPrtDiv != target.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");

            if (this.TotalBillOutputDiv != target.TotalBillOutputDiv) resList.Add("TotalBillOutputDiv");
            if (this.DetailBillOutputCode != target.DetailBillOutputCode) resList.Add("DetailBillOutputCode");
            if (this.SlipTtlBillOutputDiv != target.SlipTtlBillOutputDiv) resList.Add("SlipTtlBillOutputDiv");

            return resList;
        }

        /// <summary>
        /// 得意先一括修正クラスワーク比較処理
        /// </summary>
        /// <param name="customerCustomerChangeResult1">比較するCustomerCustomerChangeResultクラスのインスタンス</param>
        /// <param name="customerCustomerChangeResult2">比較するCustomerCustomerChangeResultクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerCustomerChangeResultクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CustomerCustomerChangeResult customerCustomerChangeResult1, CustomerCustomerChangeResult customerCustomerChangeResult2)
        {
            ArrayList resList = new ArrayList();
            if (customerCustomerChangeResult1.CreateDateTime != customerCustomerChangeResult2.CreateDateTime) resList.Add("CreateDateTime");
            if (customerCustomerChangeResult1.UpdateDateTime != customerCustomerChangeResult2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (customerCustomerChangeResult1.EnterpriseCode != customerCustomerChangeResult2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (customerCustomerChangeResult1.FileHeaderGuid != customerCustomerChangeResult2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (customerCustomerChangeResult1.UpdEmployeeCode != customerCustomerChangeResult2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (customerCustomerChangeResult1.UpdAssemblyId1 != customerCustomerChangeResult2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (customerCustomerChangeResult1.UpdAssemblyId2 != customerCustomerChangeResult2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (customerCustomerChangeResult1.LogicalDeleteCode != customerCustomerChangeResult2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (customerCustomerChangeResult1.CustomerCode != customerCustomerChangeResult2.CustomerCode) resList.Add("CustomerCode");
            if (customerCustomerChangeResult1.CustomerSubCode != customerCustomerChangeResult2.CustomerSubCode) resList.Add("CustomerSubCode");
            if (customerCustomerChangeResult1.Name != customerCustomerChangeResult2.Name) resList.Add("Name");
            if (customerCustomerChangeResult1.Name2 != customerCustomerChangeResult2.Name2) resList.Add("Name2");
            if (customerCustomerChangeResult1.HonorificTitle != customerCustomerChangeResult2.HonorificTitle) resList.Add("HonorificTitle");
            if (customerCustomerChangeResult1.Kana != customerCustomerChangeResult2.Kana) resList.Add("Kana");
            if (customerCustomerChangeResult1.CustomerSnm != customerCustomerChangeResult2.CustomerSnm) resList.Add("CustomerSnm");
            if (customerCustomerChangeResult1.OutputNameCode != customerCustomerChangeResult2.OutputNameCode) resList.Add("OutputNameCode");
            if (customerCustomerChangeResult1.OutputName != customerCustomerChangeResult2.OutputName) resList.Add("OutputName");
            if (customerCustomerChangeResult1.CorporateDivCode != customerCustomerChangeResult2.CorporateDivCode) resList.Add("CorporateDivCode");
            if (customerCustomerChangeResult1.CustomerAttributeDiv != customerCustomerChangeResult2.CustomerAttributeDiv) resList.Add("CustomerAttributeDiv");
            if (customerCustomerChangeResult1.JobTypeCode != customerCustomerChangeResult2.JobTypeCode) resList.Add("JobTypeCode");
            if (customerCustomerChangeResult1.JobTypeName != customerCustomerChangeResult2.JobTypeName) resList.Add("JobTypeName");
            if (customerCustomerChangeResult1.BusinessTypeCode != customerCustomerChangeResult2.BusinessTypeCode) resList.Add("BusinessTypeCode");
            if (customerCustomerChangeResult1.BusinessTypeName != customerCustomerChangeResult2.BusinessTypeName) resList.Add("BusinessTypeName");
            if (customerCustomerChangeResult1.SalesAreaCode != customerCustomerChangeResult2.SalesAreaCode) resList.Add("SalesAreaCode");
            if (customerCustomerChangeResult1.SalesAreaName != customerCustomerChangeResult2.SalesAreaName) resList.Add("SalesAreaName");
            if (customerCustomerChangeResult1.PostNo != customerCustomerChangeResult2.PostNo) resList.Add("PostNo");
            if (customerCustomerChangeResult1.Address1 != customerCustomerChangeResult2.Address1) resList.Add("Address1");
            if (customerCustomerChangeResult1.Address3 != customerCustomerChangeResult2.Address3) resList.Add("Address3");
            if (customerCustomerChangeResult1.Address4 != customerCustomerChangeResult2.Address4) resList.Add("Address4");
            if (customerCustomerChangeResult1.HomeTelNo != customerCustomerChangeResult2.HomeTelNo) resList.Add("HomeTelNo");
            if (customerCustomerChangeResult1.OfficeTelNo != customerCustomerChangeResult2.OfficeTelNo) resList.Add("OfficeTelNo");
            if (customerCustomerChangeResult1.PortableTelNo != customerCustomerChangeResult2.PortableTelNo) resList.Add("PortableTelNo");
            if (customerCustomerChangeResult1.HomeFaxNo != customerCustomerChangeResult2.HomeFaxNo) resList.Add("HomeFaxNo");
            if (customerCustomerChangeResult1.OfficeFaxNo != customerCustomerChangeResult2.OfficeFaxNo) resList.Add("OfficeFaxNo");
            if (customerCustomerChangeResult1.OthersTelNo != customerCustomerChangeResult2.OthersTelNo) resList.Add("OthersTelNo");
            if (customerCustomerChangeResult1.MainContactCode != customerCustomerChangeResult2.MainContactCode) resList.Add("MainContactCode");
            if (customerCustomerChangeResult1.SearchTelNo != customerCustomerChangeResult2.SearchTelNo) resList.Add("SearchTelNo");
            if (customerCustomerChangeResult1.MngSectionCode != customerCustomerChangeResult2.MngSectionCode) resList.Add("MngSectionCode");
            if (customerCustomerChangeResult1.MngSectionName != customerCustomerChangeResult2.MngSectionName) resList.Add("MngSectionName");
            if (customerCustomerChangeResult1.InpSectionCode != customerCustomerChangeResult2.InpSectionCode) resList.Add("InpSectionCode");
            if (customerCustomerChangeResult1.CustAnalysCode1 != customerCustomerChangeResult2.CustAnalysCode1) resList.Add("CustAnalysCode1");
            if (customerCustomerChangeResult1.CustAnalysCode2 != customerCustomerChangeResult2.CustAnalysCode2) resList.Add("CustAnalysCode2");
            if (customerCustomerChangeResult1.CustAnalysCode3 != customerCustomerChangeResult2.CustAnalysCode3) resList.Add("CustAnalysCode3");
            if (customerCustomerChangeResult1.CustAnalysCode4 != customerCustomerChangeResult2.CustAnalysCode4) resList.Add("CustAnalysCode4");
            if (customerCustomerChangeResult1.CustAnalysCode5 != customerCustomerChangeResult2.CustAnalysCode5) resList.Add("CustAnalysCode5");
            if (customerCustomerChangeResult1.CustAnalysCode6 != customerCustomerChangeResult2.CustAnalysCode6) resList.Add("CustAnalysCode6");
            if (customerCustomerChangeResult1.BillOutputCode != customerCustomerChangeResult2.BillOutputCode) resList.Add("BillOutputCode");
            if (customerCustomerChangeResult1.BillOutputName != customerCustomerChangeResult2.BillOutputName) resList.Add("BillOutputName");
            if (customerCustomerChangeResult1.TotalDay != customerCustomerChangeResult2.TotalDay) resList.Add("TotalDay");
            if (customerCustomerChangeResult1.CollectMoneyCode != customerCustomerChangeResult2.CollectMoneyCode) resList.Add("CollectMoneyCode");
            if (customerCustomerChangeResult1.CollectMoneyName != customerCustomerChangeResult2.CollectMoneyName) resList.Add("CollectMoneyName");
            if (customerCustomerChangeResult1.CollectMoneyDay != customerCustomerChangeResult2.CollectMoneyDay) resList.Add("CollectMoneyDay");
            if (customerCustomerChangeResult1.CollectCond != customerCustomerChangeResult2.CollectCond) resList.Add("CollectCond");
            if (customerCustomerChangeResult1.CollectSight != customerCustomerChangeResult2.CollectSight) resList.Add("CollectSight");
            if (customerCustomerChangeResult1.ClaimCode != customerCustomerChangeResult2.ClaimCode) resList.Add("ClaimCode");
            if (customerCustomerChangeResult1.ClaimName != customerCustomerChangeResult2.ClaimName) resList.Add("ClaimName");
            if (customerCustomerChangeResult1.ClaimName2 != customerCustomerChangeResult2.ClaimName2) resList.Add("ClaimName2");
            if (customerCustomerChangeResult1.ClaimSnm != customerCustomerChangeResult2.ClaimSnm) resList.Add("ClaimSnm");
            if (customerCustomerChangeResult1.TransStopDate != customerCustomerChangeResult2.TransStopDate) resList.Add("TransStopDate");
            if (customerCustomerChangeResult1.DmOutCode != customerCustomerChangeResult2.DmOutCode) resList.Add("DmOutCode");
            if (customerCustomerChangeResult1.DmOutName != customerCustomerChangeResult2.DmOutName) resList.Add("DmOutName");
            if (customerCustomerChangeResult1.MainSendMailAddrCd != customerCustomerChangeResult2.MainSendMailAddrCd) resList.Add("MainSendMailAddrCd");
            if (customerCustomerChangeResult1.MailAddrKindCode1 != customerCustomerChangeResult2.MailAddrKindCode1) resList.Add("MailAddrKindCode1");
            if (customerCustomerChangeResult1.MailAddrKindName1 != customerCustomerChangeResult2.MailAddrKindName1) resList.Add("MailAddrKindName1");
            if (customerCustomerChangeResult1.MailAddress1 != customerCustomerChangeResult2.MailAddress1) resList.Add("MailAddress1");
            if (customerCustomerChangeResult1.MailSendCode1 != customerCustomerChangeResult2.MailSendCode1) resList.Add("MailSendCode1");
            if (customerCustomerChangeResult1.MailSendName1 != customerCustomerChangeResult2.MailSendName1) resList.Add("MailSendName1");
            if (customerCustomerChangeResult1.MailAddrKindCode2 != customerCustomerChangeResult2.MailAddrKindCode2) resList.Add("MailAddrKindCode2");
            if (customerCustomerChangeResult1.MailAddrKindName2 != customerCustomerChangeResult2.MailAddrKindName2) resList.Add("MailAddrKindName2");
            if (customerCustomerChangeResult1.MailAddress2 != customerCustomerChangeResult2.MailAddress2) resList.Add("MailAddress2");
            if (customerCustomerChangeResult1.MailSendCode2 != customerCustomerChangeResult2.MailSendCode2) resList.Add("MailSendCode2");
            if (customerCustomerChangeResult1.MailSendName2 != customerCustomerChangeResult2.MailSendName2) resList.Add("MailSendName2");
            if (customerCustomerChangeResult1.CustomerAgentCd != customerCustomerChangeResult2.CustomerAgentCd) resList.Add("CustomerAgentCd");
            if (customerCustomerChangeResult1.CustomerAgentNm != customerCustomerChangeResult2.CustomerAgentNm) resList.Add("CustomerAgentNm");
            if (customerCustomerChangeResult1.BillCollecterCd != customerCustomerChangeResult2.BillCollecterCd) resList.Add("BillCollecterCd");
            if (customerCustomerChangeResult1.OldCustomerAgentCd != customerCustomerChangeResult2.OldCustomerAgentCd) resList.Add("OldCustomerAgentCd");
            if (customerCustomerChangeResult1.OldCustomerAgentNm != customerCustomerChangeResult2.OldCustomerAgentNm) resList.Add("OldCustomerAgentNm");
            if (customerCustomerChangeResult1.CustAgentChgDate != customerCustomerChangeResult2.CustAgentChgDate) resList.Add("CustAgentChgDate");
            if (customerCustomerChangeResult1.AcceptWholeSale != customerCustomerChangeResult2.AcceptWholeSale) resList.Add("AcceptWholeSale");
            if (customerCustomerChangeResult1.CreditMngCode != customerCustomerChangeResult2.CreditMngCode) resList.Add("CreditMngCode");
            if (customerCustomerChangeResult1.DepoDelCode != customerCustomerChangeResult2.DepoDelCode) resList.Add("DepoDelCode");
            if (customerCustomerChangeResult1.AccRecDivCd != customerCustomerChangeResult2.AccRecDivCd) resList.Add("AccRecDivCd");
            if (customerCustomerChangeResult1.CustSlipNoMngCd != customerCustomerChangeResult2.CustSlipNoMngCd) resList.Add("CustSlipNoMngCd");
            if (customerCustomerChangeResult1.PureCode != customerCustomerChangeResult2.PureCode) resList.Add("PureCode");
            if (customerCustomerChangeResult1.CustCTaXLayRefCd != customerCustomerChangeResult2.CustCTaXLayRefCd) resList.Add("CustCTaXLayRefCd");
            if (customerCustomerChangeResult1.ConsTaxLayMethod != customerCustomerChangeResult2.ConsTaxLayMethod) resList.Add("ConsTaxLayMethod");
            if (customerCustomerChangeResult1.TotalAmountDispWayCd != customerCustomerChangeResult2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            if (customerCustomerChangeResult1.TotalAmntDspWayRef != customerCustomerChangeResult2.TotalAmntDspWayRef) resList.Add("TotalAmntDspWayRef");
            if (customerCustomerChangeResult1.AccountNoInfo1 != customerCustomerChangeResult2.AccountNoInfo1) resList.Add("AccountNoInfo1");
            if (customerCustomerChangeResult1.AccountNoInfo2 != customerCustomerChangeResult2.AccountNoInfo2) resList.Add("AccountNoInfo2");
            if (customerCustomerChangeResult1.AccountNoInfo3 != customerCustomerChangeResult2.AccountNoInfo3) resList.Add("AccountNoInfo3");
            if (customerCustomerChangeResult1.SalesUnPrcFrcProcCd != customerCustomerChangeResult2.SalesUnPrcFrcProcCd) resList.Add("SalesUnPrcFrcProcCd");
            if (customerCustomerChangeResult1.SalesMoneyFrcProcCd != customerCustomerChangeResult2.SalesMoneyFrcProcCd) resList.Add("SalesMoneyFrcProcCd");
            if (customerCustomerChangeResult1.SalesCnsTaxFrcProcCd != customerCustomerChangeResult2.SalesCnsTaxFrcProcCd) resList.Add("SalesCnsTaxFrcProcCd");
            if (customerCustomerChangeResult1.CustomerSlipNoDiv != customerCustomerChangeResult2.CustomerSlipNoDiv) resList.Add("CustomerSlipNoDiv");
            if (customerCustomerChangeResult1.NTimeCalcStDate != customerCustomerChangeResult2.NTimeCalcStDate) resList.Add("NTimeCalcStDate");
            if (customerCustomerChangeResult1.CustomerAgent != customerCustomerChangeResult2.CustomerAgent) resList.Add("CustomerAgent");
            if (customerCustomerChangeResult1.ClaimSectionCode != customerCustomerChangeResult2.ClaimSectionCode) resList.Add("ClaimSectionCode");
            if (customerCustomerChangeResult1.ClaimSectionName != customerCustomerChangeResult2.ClaimSectionName) resList.Add("ClaimSectionName");
            if (customerCustomerChangeResult1.CarMngDivCd != customerCustomerChangeResult2.CarMngDivCd) resList.Add("CarMngDivCd");
            if (customerCustomerChangeResult1.BillPartsNoPrtCd != customerCustomerChangeResult2.BillPartsNoPrtCd) resList.Add("BillPartsNoPrtCd");
            if (customerCustomerChangeResult1.DeliPartsNoPrtCd != customerCustomerChangeResult2.DeliPartsNoPrtCd) resList.Add("DeliPartsNoPrtCd");
            if (customerCustomerChangeResult1.DefSalesSlipCd != customerCustomerChangeResult2.DefSalesSlipCd) resList.Add("DefSalesSlipCd");
            if (customerCustomerChangeResult1.LavorRateRank != customerCustomerChangeResult2.LavorRateRank) resList.Add("LavorRateRank");
            if (customerCustomerChangeResult1.SlipTtlPrn != customerCustomerChangeResult2.SlipTtlPrn) resList.Add("SlipTtlPrn");
            if (customerCustomerChangeResult1.DepoBankCode != customerCustomerChangeResult2.DepoBankCode) resList.Add("DepoBankCode");
            if (customerCustomerChangeResult1.DepoBankName != customerCustomerChangeResult2.DepoBankName) resList.Add("DepoBankName");
            if (customerCustomerChangeResult1.CustWarehouseCd != customerCustomerChangeResult2.CustWarehouseCd) resList.Add("CustWarehouseCd");
            if (customerCustomerChangeResult1.CustWarehouseName != customerCustomerChangeResult2.CustWarehouseName) resList.Add("CustWarehouseName");
            if (customerCustomerChangeResult1.QrcodePrtCd != customerCustomerChangeResult2.QrcodePrtCd) resList.Add("QrcodePrtCd");
            if (customerCustomerChangeResult1.DeliHonorificTtl != customerCustomerChangeResult2.DeliHonorificTtl) resList.Add("DeliHonorificTtl");
            if (customerCustomerChangeResult1.BillHonorificTtl != customerCustomerChangeResult2.BillHonorificTtl) resList.Add("BillHonorificTtl");
            if (customerCustomerChangeResult1.EstmHonorificTtl != customerCustomerChangeResult2.EstmHonorificTtl) resList.Add("EstmHonorificTtl");
            if (customerCustomerChangeResult1.RectHonorificTtl != customerCustomerChangeResult2.RectHonorificTtl) resList.Add("RectHonorificTtl");
            if (customerCustomerChangeResult1.DeliHonorTtlPrtDiv != customerCustomerChangeResult2.DeliHonorTtlPrtDiv) resList.Add("DeliHonorTtlPrtDiv");
            if (customerCustomerChangeResult1.BillHonorTtlPrtDiv != customerCustomerChangeResult2.BillHonorTtlPrtDiv) resList.Add("BillHonorTtlPrtDiv");
            if (customerCustomerChangeResult1.EstmHonorTtlPrtDiv != customerCustomerChangeResult2.EstmHonorTtlPrtDiv) resList.Add("EstmHonorTtlPrtDiv");
            if (customerCustomerChangeResult1.RectHonorTtlPrtDiv != customerCustomerChangeResult2.RectHonorTtlPrtDiv) resList.Add("RectHonorTtlPrtDiv");
            if (customerCustomerChangeResult1.Note1 != customerCustomerChangeResult2.Note1) resList.Add("Note1");
            if (customerCustomerChangeResult1.Note2 != customerCustomerChangeResult2.Note2) resList.Add("Note2");
            if (customerCustomerChangeResult1.Note3 != customerCustomerChangeResult2.Note3) resList.Add("Note3");
            if (customerCustomerChangeResult1.Note4 != customerCustomerChangeResult2.Note4) resList.Add("Note4");
            if (customerCustomerChangeResult1.Note5 != customerCustomerChangeResult2.Note5) resList.Add("Note5");
            if (customerCustomerChangeResult1.Note6 != customerCustomerChangeResult2.Note6) resList.Add("Note6");
            if (customerCustomerChangeResult1.Note7 != customerCustomerChangeResult2.Note7) resList.Add("Note7");
            if (customerCustomerChangeResult1.Note8 != customerCustomerChangeResult2.Note8) resList.Add("Note8");
            if (customerCustomerChangeResult1.Note9 != customerCustomerChangeResult2.Note9) resList.Add("Note9");
            if (customerCustomerChangeResult1.Note10 != customerCustomerChangeResult2.Note10) resList.Add("Note10");
            if (customerCustomerChangeResult1.CreditMoney != customerCustomerChangeResult2.CreditMoney) resList.Add("CreditMoney");
            if (customerCustomerChangeResult1.WarningCreditMoney != customerCustomerChangeResult2.WarningCreditMoney) resList.Add("WarningCreditMoney");
            if (customerCustomerChangeResult1.PrsntAccRecBalance != customerCustomerChangeResult2.PrsntAccRecBalance) resList.Add("PrsntAccRecBalance");
            if (customerCustomerChangeResult1.RateGPureCode != customerCustomerChangeResult2.RateGPureCode) resList.Add("RateGPureCode");
            if (customerCustomerChangeResult1.GoodsMakerCd != customerCustomerChangeResult2.GoodsMakerCd) resList.Add("GoodsMakerCd");
            if (customerCustomerChangeResult1.CustRateGrpCode != customerCustomerChangeResult2.CustRateGrpCode) resList.Add("CustRateGrpCode");
            if (customerCustomerChangeResult1.EnterpriseName != customerCustomerChangeResult2.EnterpriseName) resList.Add("EnterpriseName");
            if (customerCustomerChangeResult1.UpdEmployeeName != customerCustomerChangeResult2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            if (customerCustomerChangeResult1.InpSectionName != customerCustomerChangeResult2.InpSectionName) resList.Add("InpSectionName");
            if (customerCustomerChangeResult1.BillOutPutCodeNm != customerCustomerChangeResult2.BillOutPutCodeNm) resList.Add("BillOutPutCodeNm");
            if (customerCustomerChangeResult1.BillCollecterNm != customerCustomerChangeResult2.BillCollecterNm) resList.Add("BillCollecterNm");
            if (customerCustomerChangeResult1.ReceiptOutputCode != customerCustomerChangeResult2.ReceiptOutputCode) resList.Add("ReceiptOutputCode");

            if (customerCustomerChangeResult1.SalesSlipPrtDiv != customerCustomerChangeResult2.SalesSlipPrtDiv) resList.Add("SalesSlipPrtDiv");
            if (customerCustomerChangeResult1.AcpOdrrSlipPrtDiv != customerCustomerChangeResult2.AcpOdrrSlipPrtDiv) resList.Add("AcpOdrrSlipPrtDiv");
            if (customerCustomerChangeResult1.ShipmSlipPrtDiv != customerCustomerChangeResult2.ShipmSlipPrtDiv) resList.Add("ShipmSlipPrtDiv");
            if (customerCustomerChangeResult1.EstimatePrtDiv != customerCustomerChangeResult2.EstimatePrtDiv) resList.Add("EstimatePrtDiv");
            if (customerCustomerChangeResult1.UOESlipPrtDiv != customerCustomerChangeResult2.UOESlipPrtDiv) resList.Add("UOESlipPrtDiv");

            if (customerCustomerChangeResult1.TotalBillOutputDiv != customerCustomerChangeResult2.TotalBillOutputDiv) resList.Add("TotalBillOutputDiv");
            if (customerCustomerChangeResult1.DetailBillOutputCode != customerCustomerChangeResult2.DetailBillOutputCode) resList.Add("DetailBillOutputCode");
            if (customerCustomerChangeResult1.SlipTtlBillOutputDiv != customerCustomerChangeResult2.SlipTtlBillOutputDiv) resList.Add("SlipTtlBillOutputDiv");

            return resList;
        }
    }
}
