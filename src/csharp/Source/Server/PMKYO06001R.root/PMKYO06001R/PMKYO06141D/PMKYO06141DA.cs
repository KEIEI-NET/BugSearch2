//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   マスタ送受信抽出・更新DB仲介クラス              //
//                  :   PMKYO06141D.DLL                                 //
// Name Space       :   Broadleaf.Application.Remoting.ParamData        //
// Programmer       :   呉元嘯                                          //
// Date             :   2009.04.28                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   APCustomerWork
    /// <summary>
    ///                      得意先ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   得意先ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/18</br>
    /// <br>Genarated Date   :   2009/05/26  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/5/1  杉村</br>
    /// <br>                 :   得意先掛率グループコードを削除</br>
    /// <br>Update Note      :   2008/6/16  長内</br>
    /// <br>                 :   得意先伝票番号の補足説明変更</br>
    /// <br>                 :   0:使用しない,1:使用する</br>
    /// <br>                 :   　　　↓</br>
    /// <br>                 :   0:使用しない,1:連番,2:締毎,3:期末</br>
    /// <br>Update Note      :   2008/11/10  杉村</br>
    /// <br>                 :   ○補足変更</br>
    /// <br>                 :   QRコード印字区分</br>
    /// <br>                 :   0:標準 1:印字しない 2:印字する 3:返品含む</br>
    /// <br>Update Note      :   2008/11/11  杉村</br>
    /// <br>                 :   ○補足変更</br>
    /// <br>                 :   0:しない　1:する</br>
    /// <br>                 :   ↓</br>
    /// <br>                 :   0:全体設定参照 1:しない　2:する</br>
    /// <br>Update Note      :   2008/12/1  杉村</br>
    /// <br>                 :   ○ データ型変更</br>
    /// <br>                 :   得意先優先倉庫コード</br>
    /// <br>                 :   Int32　⇒　nchar 6 12byte</br>
    /// <br>                 :   集金月区分名称</br>
    /// <br>                 :   nvarchar 3 6byte　⇒　nvarchar 4 8byte</br>
    /// <br>Update Note      :   2008/12/19  杉村</br>
    /// <br>                 :   ○ 項目追加</br>
    /// <br>                 :   売上伝票発行区分 </br>
    /// <br>                 :   出荷伝票発行区分 </br>
    /// <br>                 :   受注伝票発行区分 </br>
    /// <br>                 :   見積書発行区分  </br>
    /// <br>                 :   UOE伝票発行区分  </br>
    /// <br>Update Note      :   2009/2/6  杉村</br>
    /// <br>                 :   ○補足修正</br>
    /// <br>                 :   回収条件</br>
    /// <br>                 :   10:現金,20:振込,30:小切手,40:手形,50:手数料,60:相殺,70:値引,80:その他</br>
    /// <br>                 :   ↓</br>
    /// <br>                 :   51:現金,52:振込,53:小切手,54:手形56:相殺,58:その他</br>
    /// <br>Update Note      :   2009/3/19  長内</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   領収書出力区分コード</br>
    /// <br>Update Note      :   2009/5/11  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   得意先企業コード</br>
    /// <br>                 :   得意先拠点コード</br>
    /// <br>                 :   得意先拠点略称</br>
    /// <br>                 :   オンライン種別区分</br>
    /// <br>Update Note      :   2009/5/19  杉村</br>
    /// <br>                 :   ○項目削除</br>
    /// <br>                 :   得意先拠点略称</br>
    /// <br>                 :   ○補足修正</br>
    /// <br>                 :   オンライン種別区分</br>
    /// <br>                 :   10:SCM、20:TSP.NS、30:TSP.NSインライン、40:TSPメール</br>
    /// <br>                 :   ↓</br>
    /// <br>                 :   0:なし 10:SCM、20:TSP.NS、30:TSP.NSインライン、40:TSPメール</br>
    /// <br>Update Note      :   2009/5/22  長内</br>
    /// <br>                 :   ○DDバイトミス修正</br>
    /// <br>                 :   　得意先拠点コード</br>
    /// <br>                 :   　32→12</br>
    /// <br>Update Note      :   2009/6/4  長内</br>
    /// <br>                 :   ○補足修正</br>
    /// <br>                 :   　個人・法人区分</br>
    /// <br>                 :   　5:AAを追加（全体初期値設定に合わせる）</br>
    /// <br>Update Note      :   2010/1/7  杉村</br>
    /// <br>                 :   ○項目追加</br>
    /// <br>                 :   合計請求書出力区分</br>
    /// <br>                 :   明細請求書出力区分</br>
    /// <br>                 :   伝票合計請求書出力区分</br>
    /// </remarks>
    [Serializable]
    [Broadleaf.Library.Runtime.Serialization.CustomSerializationData]
    public class APCustomerWork : IFileHeader
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

        /// <summary>業種コード</summary>
        private Int32 _businessTypeCode;

        /// <summary>販売エリアコード</summary>
        private Int32 _salesAreaCode;

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
        /// <remarks>当月,翌月,翌々月,翌々々月</remarks>
        private string _collectMoneyName = "";

        /// <summary>集金日</summary>
        /// <remarks>DD</remarks>
        private Int32 _collectMoneyDay;

        /// <summary>回収条件</summary>
        /// <remarks>51:現金,52:振込,53:小切手,54:手形56:相殺,58:その他</remarks>
        private Int32 _collectCond;

        /// <summary>回収サイト</summary>
        /// <remarks>手形サイト　180等</remarks>
        private Int32 _collectSight;

        /// <summary>請求先コード</summary>
        /// <remarks>請求先得意先。納入先の場合の使用可能項目</remarks>
        private Int32 _claimCode;

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

        /// <summary>集金担当従業員コード</summary>
        private string _billCollecterCd = "";

        /// <summary>旧顧客担当従業員コード</summary>
        private string _oldCustomerAgentCd = "";

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
        /// <remarks>0:全体設定参照 1:しない　2:する</remarks>
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

        /// <summary>得意先優先倉庫コード</summary>
        private string _custWarehouseCd = "";

        /// <summary>QRコード印刷</summary>
        /// <remarks>0:標準 1:印字しない 2:印字する 3:返品含む</remarks>
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

        /// <summary>売上伝票発行区分</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _salesSlipPrtDiv;

        /// <summary>出荷伝票発行区分</summary>
        /// <remarks>0:する　1:しない　（貸出）</remarks>
        private Int32 _shipmSlipPrtDiv;

        /// <summary>受注伝票発行区分</summary>
        /// <remarks>0:しない 1:する</remarks>
        private Int32 _acpOdrrSlipPrtDiv;

        /// <summary>見積書発行区分</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _estimatePrtDiv;

        /// <summary>UOE伝票発行区分</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _uOESlipPrtDiv;

        /// <summary>領収書出力区分コード</summary>
        /// <remarks>0:する　1:しない</remarks>
        private Int32 _receiptOutputCode;

        /// <summary>得意先企業コード</summary>
        /// <remarks>システム連動可能な場合のみ登録される</remarks>
        private string _customerEpCode = "";

        /// <summary>得意先拠点コード</summary>
        /// <remarks>システム連動可能な場合のみ登録される</remarks>
        private string _customerSecCode = "";

        /// <summary>オンライン種別区分</summary>
        /// <remarks>0:なし 10:SCM、20:TSP.NS、30:TSP.NSインライン、40:TSPメール</remarks>
        private Int32 _onlineKindDiv;

        /// <summary>合計請求書出力区分</summary>
        /// <remarks>0:標準　1:使用する　2:使用しない</remarks>
        private Int32 _totalBillOutputDiv;

        /// <summary>明細請求書出力区分</summary>
        /// <remarks>0:標準　1:使用する　2:使用しない</remarks>
        private Int32 _detailBillOutputCode;

        /// <summary>伝票合計請求書出力区分</summary>
        /// <remarks>0:標準　1:使用する　2:使用しない</remarks>
        private Int32 _slipTtlBillOutputDiv;


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
        /// <value>当月,翌月,翌々月,翌々々月</value>
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
        /// <value>51:現金,52:振込,53:小切手,54:手形56:相殺,58:その他</value>
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
        /// <value>0:全体設定参照 1:しない　2:する</value>
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

        /// public propaty name  :  QrcodePrtCd
        /// <summary>QRコード印刷プロパティ</summary>
        /// <value>0:標準 1:印字しない 2:印字する 3:返品含む</value>
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

        /// public propaty name  :  SalesSlipPrtDiv
        /// <summary>売上伝票発行区分プロパティ</summary>
        /// <value>0:する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   売上伝票発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SalesSlipPrtDiv
        {
            get { return _salesSlipPrtDiv; }
            set { _salesSlipPrtDiv = value; }
        }

        /// public propaty name  :  ShipmSlipPrtDiv
        /// <summary>出荷伝票発行区分プロパティ</summary>
        /// <value>0:する　1:しない　（貸出）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   出荷伝票発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ShipmSlipPrtDiv
        {
            get { return _shipmSlipPrtDiv; }
            set { _shipmSlipPrtDiv = value; }
        }

        /// public propaty name  :  AcpOdrrSlipPrtDiv
        /// <summary>受注伝票発行区分プロパティ</summary>
        /// <value>0:しない 1:する</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   受注伝票発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 AcpOdrrSlipPrtDiv
        {
            get { return _acpOdrrSlipPrtDiv; }
            set { _acpOdrrSlipPrtDiv = value; }
        }

        /// public propaty name  :  EstimatePrtDiv
        /// <summary>見積書発行区分プロパティ</summary>
        /// <value>0:する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   見積書発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EstimatePrtDiv
        {
            get { return _estimatePrtDiv; }
            set { _estimatePrtDiv = value; }
        }

        /// public propaty name  :  UOESlipPrtDiv
        /// <summary>UOE伝票発行区分プロパティ</summary>
        /// <value>0:する　1:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   UOE伝票発行区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 UOESlipPrtDiv
        {
            get { return _uOESlipPrtDiv; }
            set { _uOESlipPrtDiv = value; }
        }

        /// public propaty name  :  ReceiptOutputCode
        /// <summary>領収書出力区分コードプロパティ</summary>
        /// <value>0:する　1:しない</value>
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

        /// public propaty name  :  CustomerEpCode
        /// <summary>得意先企業コードプロパティ</summary>
        /// <value>システム連動可能な場合のみ登録される</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerEpCode
        {
            get { return _customerEpCode; }
            set { _customerEpCode = value; }
        }

        /// public propaty name  :  CustomerSecCode
        /// <summary>得意先拠点コードプロパティ</summary>
        /// <value>システム連動可能な場合のみ登録される</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CustomerSecCode
        {
            get { return _customerSecCode; }
            set { _customerSecCode = value; }
        }

        /// public propaty name  :  OnlineKindDiv
        /// <summary>オンライン種別区分プロパティ</summary>
        /// <value>0:なし 10:SCM、20:TSP.NS、30:TSP.NSインライン、40:TSPメール</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   オンライン種別区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 OnlineKindDiv
        {
            get { return _onlineKindDiv; }
            set { _onlineKindDiv = value; }
        }
 
        /// public propaty name  :  TotalBillOutputDiv
        /// <summary>合計請求書出力区分プロパティ</summary>
        /// <value>0:標準　1:使用する　2:使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TotalBillOutputDiv
        {
            get { return _totalBillOutputDiv; }
            set { _totalBillOutputDiv = value; }
        }

        /// public propaty name  :  DetailBillOutputCode
        /// <summary>明細請求書出力区分プロパティ</summary>
        /// <value>0:標準　1:使用する　2:使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   明細請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DetailBillOutputCode
        {
            get { return _detailBillOutputCode; }
            set { _detailBillOutputCode = value; }
        }

        /// public propaty name  :  SlipTtlBillOutputDiv
        /// <summary>伝票合計請求書出力区分プロパティ</summary>
        /// <value>0:標準　1:使用する　2:使用しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   伝票合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SlipTtlBillOutputDiv
        {
            get { return _slipTtlBillOutputDiv; }
            set { _slipTtlBillOutputDiv = value; }
        }


        /// <summary>
        /// 得意先ワークコンストラクタ
        /// </summary>
        /// <returns>CustomerWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public APCustomerWork()
        {
        }

    }
    /// <summary>
    ///  Ver5.10.1.0用のカスタムシライアライザです。
    /// </summary>
    /// <returns>CustomerWorkクラスのインスタンス(object)</returns>
    /// <remarks>
    /// <br>Note　　　　　　 :   CustomerWorkクラスのカスタムシリアライザを定義します</br>
    /// <br>Programer        :   自動生成</br>
    /// </remarks>
    public class CustomerWork_SerializationSurrogate_For_V51010 : Broadleaf.Library.Runtime.Serialization.ICustomSerializationSurrogate
    {
        #region ICustomSerializationSurrogate メンバ

        /// <summary>
        ///  Ver5.10.1.0用のカスタムシリアライザです
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerWorkクラスのカスタムシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public void Serialize(System.IO.BinaryWriter writer, object graph)
        {
            // TODO:  CustomerWork_SerializationSurrogate_For_V51010.Serialize 実装を追加します。
            if (writer == null)
                throw new ArgumentNullException();

            if (graph != null && !(graph is APCustomerWork || graph is ArrayList || graph is APCustomerWork[]))
                throw new ArgumentException(string.Format("graphが{0}のインスタンスでありません", typeof(APCustomerWork).FullName));

            if (graph != null && graph is APCustomerWork)
            {
                Type t = graph.GetType();
                if (!CustomFormatterServices.NeedCustomSerialization(t))
                    throw new ArgumentException(string.Format("graphの型:{0}がカスタムシリアライズの対象でありません", t.FullName));
            }

            //SerializationTypeInfo
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = new Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo(", Version=5.10.1.0, Culture=neutral, publicKeyToken=null", "Broadleaf.Application.Remoting.ParamData.CustomerWork");

            //繰り返し数の判定を行います。この部分は適宜業務要件に応じて行ってください。
            int occurrence = 0;     //一般にゼロの場合もありえます
            if (graph is ArrayList)
            {
                serInfo.RetTypeInfo = 0;
                occurrence = ((ArrayList)graph).Count;
            }
            else if (graph is APCustomerWork[])
            {
                serInfo.RetTypeInfo = 2;
                occurrence = ((APCustomerWork[])graph).Length;
            }
            else if (graph is APCustomerWork)
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
            //得意先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerCode
            //得意先サブコード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSubCode
            //名称
            serInfo.MemberInfo.Add(typeof(string)); //Name
            //名称2
            serInfo.MemberInfo.Add(typeof(string)); //Name2
            //敬称
            serInfo.MemberInfo.Add(typeof(string)); //HonorificTitle
            //カナ
            serInfo.MemberInfo.Add(typeof(string)); //Kana
            //得意先略称
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSnm
            //諸口コード
            serInfo.MemberInfo.Add(typeof(Int32)); //OutputNameCode
            //諸口名称
            serInfo.MemberInfo.Add(typeof(string)); //OutputName
            //個人・法人区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CorporateDivCode
            //得意先属性区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerAttributeDiv
            //職種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //JobTypeCode
            //業種コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BusinessTypeCode
            //販売エリアコード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesAreaCode
            //郵便番号
            serInfo.MemberInfo.Add(typeof(string)); //PostNo
            //住所1（都道府県市区郡・町村・字）
            serInfo.MemberInfo.Add(typeof(string)); //Address1
            //住所3（番地）
            serInfo.MemberInfo.Add(typeof(string)); //Address3
            //住所4（アパート名称）
            serInfo.MemberInfo.Add(typeof(string)); //Address4
            //電話番号（自宅）
            serInfo.MemberInfo.Add(typeof(string)); //HomeTelNo
            //電話番号（勤務先）
            serInfo.MemberInfo.Add(typeof(string)); //OfficeTelNo
            //電話番号（携帯）
            serInfo.MemberInfo.Add(typeof(string)); //PortableTelNo
            //FAX番号（自宅）
            serInfo.MemberInfo.Add(typeof(string)); //HomeFaxNo
            //FAX番号（勤務先）
            serInfo.MemberInfo.Add(typeof(string)); //OfficeFaxNo
            //電話番号（その他）
            serInfo.MemberInfo.Add(typeof(string)); //OthersTelNo
            //主連絡先区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MainContactCode
            //電話番号（検索用下4桁）
            serInfo.MemberInfo.Add(typeof(string)); //SearchTelNo
            //管理拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //MngSectionCode
            //入力拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //InpSectionCode
            //得意先分析コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode1
            //得意先分析コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode2
            //得意先分析コード3
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode3
            //得意先分析コード4
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode4
            //得意先分析コード5
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode5
            //得意先分析コード6
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAnalysCode6
            //請求書出力区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //BillOutputCode
            //請求書出力区分名称
            serInfo.MemberInfo.Add(typeof(string)); //BillOutputName
            //締日
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalDay
            //集金月区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyCode
            //集金月区分名称
            serInfo.MemberInfo.Add(typeof(string)); //CollectMoneyName
            //集金日
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectMoneyDay
            //回収条件
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectCond
            //回収サイト
            serInfo.MemberInfo.Add(typeof(Int32)); //CollectSight
            //請求先コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ClaimCode
            //取引中止日
            serInfo.MemberInfo.Add(typeof(Int32)); //TransStopDate
            //DM出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DmOutCode
            //DM出力区分名称
            serInfo.MemberInfo.Add(typeof(string)); //DmOutName
            //主送信先メールアドレス区分
            serInfo.MemberInfo.Add(typeof(Int32)); //MainSendMailAddrCd
            //メールアドレス種別コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //MailAddrKindCode1
            //メールアドレス種別名称1
            serInfo.MemberInfo.Add(typeof(string)); //MailAddrKindName1
            //メールアドレス1
            serInfo.MemberInfo.Add(typeof(string)); //MailAddress1
            //メール送信区分コード1
            serInfo.MemberInfo.Add(typeof(Int32)); //MailSendCode1
            //メール送信区分名称1
            serInfo.MemberInfo.Add(typeof(string)); //MailSendName1
            //メールアドレス種別コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //MailAddrKindCode2
            //メールアドレス種別名称2
            serInfo.MemberInfo.Add(typeof(string)); //MailAddrKindName2
            //メールアドレス2
            serInfo.MemberInfo.Add(typeof(string)); //MailAddress2
            //メール送信区分コード2
            serInfo.MemberInfo.Add(typeof(Int32)); //MailSendCode2
            //メール送信区分名称2
            serInfo.MemberInfo.Add(typeof(string)); //MailSendName2
            //顧客担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgentCd
            //集金担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //BillCollecterCd
            //旧顧客担当従業員コード
            serInfo.MemberInfo.Add(typeof(string)); //OldCustomerAgentCd
            //顧客担当変更日
            serInfo.MemberInfo.Add(typeof(Int32)); //CustAgentChgDate
            //業販先区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcceptWholeSale
            //与信管理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CreditMngCode
            //入金消込区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DepoDelCode
            //売掛区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AccRecDivCd
            //相手伝票番号管理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CustSlipNoMngCd
            //純正区分
            serInfo.MemberInfo.Add(typeof(Int32)); //PureCode
            //得意先消費税転嫁方式参照区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CustCTaXLayRefCd
            //消費税転嫁方式
            serInfo.MemberInfo.Add(typeof(Int32)); //ConsTaxLayMethod
            //総額表示方法区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmountDispWayCd
            //総額表示方法参照区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalAmntDspWayRef
            //銀行口座1
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo1
            //銀行口座2
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo2
            //銀行口座3
            serInfo.MemberInfo.Add(typeof(string)); //AccountNoInfo3
            //売上単価端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesUnPrcFrcProcCd
            //売上金額端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesMoneyFrcProcCd
            //売上消費税端数処理コード
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesCnsTaxFrcProcCd
            //得意先伝票番号区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CustomerSlipNoDiv
            //次回勘定開始日
            serInfo.MemberInfo.Add(typeof(Int32)); //NTimeCalcStDate
            //得意先担当者
            serInfo.MemberInfo.Add(typeof(string)); //CustomerAgent
            //請求拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //ClaimSectionCode
            //車輌管理区分
            serInfo.MemberInfo.Add(typeof(Int32)); //CarMngDivCd
            //品番印字区分(請求書)
            serInfo.MemberInfo.Add(typeof(Int32)); //BillPartsNoPrtCd
            //品番印字区分(納品書）
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliPartsNoPrtCd
            //伝票区分初期値
            serInfo.MemberInfo.Add(typeof(Int32)); //DefSalesSlipCd
            //工賃レバレートランク
            serInfo.MemberInfo.Add(typeof(Int32)); //LavorRateRank
            //伝票タイトルパターン
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipTtlPrn
            //入金銀行コード
            serInfo.MemberInfo.Add(typeof(Int32)); //DepoBankCode
            //得意先優先倉庫コード
            serInfo.MemberInfo.Add(typeof(string)); //CustWarehouseCd
            //QRコード印刷
            serInfo.MemberInfo.Add(typeof(Int32)); //QrcodePrtCd
            //納品書敬称
            serInfo.MemberInfo.Add(typeof(string)); //DeliHonorificTtl
            //請求書敬称
            serInfo.MemberInfo.Add(typeof(string)); //BillHonorificTtl
            //見積書敬称
            serInfo.MemberInfo.Add(typeof(string)); //EstmHonorificTtl
            //領収書敬称
            serInfo.MemberInfo.Add(typeof(string)); //RectHonorificTtl
            //納品書敬称印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DeliHonorTtlPrtDiv
            //請求書敬称印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //BillHonorTtlPrtDiv
            //見積書敬称印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EstmHonorTtlPrtDiv
            //領収書敬称印字区分
            serInfo.MemberInfo.Add(typeof(Int32)); //RectHonorTtlPrtDiv
            //備考1
            serInfo.MemberInfo.Add(typeof(string)); //Note1
            //備考2
            serInfo.MemberInfo.Add(typeof(string)); //Note2
            //備考3
            serInfo.MemberInfo.Add(typeof(string)); //Note3
            //備考4
            serInfo.MemberInfo.Add(typeof(string)); //Note4
            //備考5
            serInfo.MemberInfo.Add(typeof(string)); //Note5
            //備考6
            serInfo.MemberInfo.Add(typeof(string)); //Note6
            //備考7
            serInfo.MemberInfo.Add(typeof(string)); //Note7
            //備考8
            serInfo.MemberInfo.Add(typeof(string)); //Note8
            //備考9
            serInfo.MemberInfo.Add(typeof(string)); //Note9
            //備考10
            serInfo.MemberInfo.Add(typeof(string)); //Note10
            //売上伝票発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SalesSlipPrtDiv
            //出荷伝票発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //ShipmSlipPrtDiv
            //受注伝票発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //AcpOdrrSlipPrtDiv
            //見積書発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //EstimatePrtDiv
            //UOE伝票発行区分
            serInfo.MemberInfo.Add(typeof(Int32)); //UOESlipPrtDiv
            //領収書出力区分コード
            serInfo.MemberInfo.Add(typeof(Int32)); //ReceiptOutputCode
            //得意先企業コード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerEpCode
            //得意先拠点コード
            serInfo.MemberInfo.Add(typeof(string)); //CustomerSecCode
            //オンライン種別区分
            serInfo.MemberInfo.Add(typeof(Int32)); //OnlineKindDiv
            //合計請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //TotalBillOutputDiv
            //明細請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //DetailBillOutputCode
            //伝票合計請求書出力区分
            serInfo.MemberInfo.Add(typeof(Int32)); //SlipTtlBillOutputDiv


            serInfo.Serialize(writer, serInfo);
            if (graph is APCustomerWork)
            {
                APCustomerWork temp = (APCustomerWork)graph;

                SetCustomerWork(writer, temp);
            }
            else
            {
                ArrayList lst = null;
                if (graph is APCustomerWork[])
                {
                    lst = new ArrayList();
                    lst.AddRange((APCustomerWork[])graph);
                }
                else
                {
                    lst = (ArrayList)graph;
                }

                foreach (APCustomerWork temp in lst)
                {
                    SetCustomerWork(writer, temp);
                }

            }


        }


        /// <summary>
        /// CustomerWorkメンバ数(publicプロパティ数)
        /// </summary>
        // --- ADD  大矢睦美  2010/01/21 ---------->>>>>
        //private const int currentMemberCount = 125;
        private const int currentMemberCount = 128;
        // --- ADD  大矢睦美  2010/01/21 ----------<<<<<

        /// <summary>
        ///  CustomerWorkインスタンス書き込み
        /// </summary>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerWorkのインスタンスを書き込み</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private void SetCustomerWork(System.IO.BinaryWriter writer, APCustomerWork temp)
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
            //得意先コード
            writer.Write(temp.CustomerCode);
            //得意先サブコード
            writer.Write(temp.CustomerSubCode);
            //名称
            writer.Write(temp.Name);
            //名称2
            writer.Write(temp.Name2);
            //敬称
            writer.Write(temp.HonorificTitle);
            //カナ
            writer.Write(temp.Kana);
            //得意先略称
            writer.Write(temp.CustomerSnm);
            //諸口コード
            writer.Write(temp.OutputNameCode);
            //諸口名称
            writer.Write(temp.OutputName);
            //個人・法人区分
            writer.Write(temp.CorporateDivCode);
            //得意先属性区分
            writer.Write(temp.CustomerAttributeDiv);
            //職種コード
            writer.Write(temp.JobTypeCode);
            //業種コード
            writer.Write(temp.BusinessTypeCode);
            //販売エリアコード
            writer.Write(temp.SalesAreaCode);
            //郵便番号
            writer.Write(temp.PostNo);
            //住所1（都道府県市区郡・町村・字）
            writer.Write(temp.Address1);
            //住所3（番地）
            writer.Write(temp.Address3);
            //住所4（アパート名称）
            writer.Write(temp.Address4);
            //電話番号（自宅）
            writer.Write(temp.HomeTelNo);
            //電話番号（勤務先）
            writer.Write(temp.OfficeTelNo);
            //電話番号（携帯）
            writer.Write(temp.PortableTelNo);
            //FAX番号（自宅）
            writer.Write(temp.HomeFaxNo);
            //FAX番号（勤務先）
            writer.Write(temp.OfficeFaxNo);
            //電話番号（その他）
            writer.Write(temp.OthersTelNo);
            //主連絡先区分
            writer.Write(temp.MainContactCode);
            //電話番号（検索用下4桁）
            writer.Write(temp.SearchTelNo);
            //管理拠点コード
            writer.Write(temp.MngSectionCode);
            //入力拠点コード
            writer.Write(temp.InpSectionCode);
            //得意先分析コード1
            writer.Write(temp.CustAnalysCode1);
            //得意先分析コード2
            writer.Write(temp.CustAnalysCode2);
            //得意先分析コード3
            writer.Write(temp.CustAnalysCode3);
            //得意先分析コード4
            writer.Write(temp.CustAnalysCode4);
            //得意先分析コード5
            writer.Write(temp.CustAnalysCode5);
            //得意先分析コード6
            writer.Write(temp.CustAnalysCode6);
            //請求書出力区分コード
            writer.Write(temp.BillOutputCode);
            //請求書出力区分名称
            writer.Write(temp.BillOutputName);
            //締日
            writer.Write(temp.TotalDay);
            //集金月区分コード
            writer.Write(temp.CollectMoneyCode);
            //集金月区分名称
            writer.Write(temp.CollectMoneyName);
            //集金日
            writer.Write(temp.CollectMoneyDay);
            //回収条件
            writer.Write(temp.CollectCond);
            //回収サイト
            writer.Write(temp.CollectSight);
            //請求先コード
            writer.Write(temp.ClaimCode);
            //取引中止日
            writer.Write((Int64)temp.TransStopDate.Ticks);
            //DM出力区分
            writer.Write(temp.DmOutCode);
            //DM出力区分名称
            writer.Write(temp.DmOutName);
            //主送信先メールアドレス区分
            writer.Write(temp.MainSendMailAddrCd);
            //メールアドレス種別コード1
            writer.Write(temp.MailAddrKindCode1);
            //メールアドレス種別名称1
            writer.Write(temp.MailAddrKindName1);
            //メールアドレス1
            writer.Write(temp.MailAddress1);
            //メール送信区分コード1
            writer.Write(temp.MailSendCode1);
            //メール送信区分名称1
            writer.Write(temp.MailSendName1);
            //メールアドレス種別コード2
            writer.Write(temp.MailAddrKindCode2);
            //メールアドレス種別名称2
            writer.Write(temp.MailAddrKindName2);
            //メールアドレス2
            writer.Write(temp.MailAddress2);
            //メール送信区分コード2
            writer.Write(temp.MailSendCode2);
            //メール送信区分名称2
            writer.Write(temp.MailSendName2);
            //顧客担当従業員コード
            writer.Write(temp.CustomerAgentCd);
            //集金担当従業員コード
            writer.Write(temp.BillCollecterCd);
            //旧顧客担当従業員コード
            writer.Write(temp.OldCustomerAgentCd);
            //顧客担当変更日
            writer.Write((Int64)temp.CustAgentChgDate.Ticks);
            //業販先区分
            writer.Write(temp.AcceptWholeSale);
            //与信管理区分
            writer.Write(temp.CreditMngCode);
            //入金消込区分
            writer.Write(temp.DepoDelCode);
            //売掛区分
            writer.Write(temp.AccRecDivCd);
            //相手伝票番号管理区分
            writer.Write(temp.CustSlipNoMngCd);
            //純正区分
            writer.Write(temp.PureCode);
            //得意先消費税転嫁方式参照区分
            writer.Write(temp.CustCTaXLayRefCd);
            //消費税転嫁方式
            writer.Write(temp.ConsTaxLayMethod);
            //総額表示方法区分
            writer.Write(temp.TotalAmountDispWayCd);
            //総額表示方法参照区分
            writer.Write(temp.TotalAmntDspWayRef);
            //銀行口座1
            writer.Write(temp.AccountNoInfo1);
            //銀行口座2
            writer.Write(temp.AccountNoInfo2);
            //銀行口座3
            writer.Write(temp.AccountNoInfo3);
            //売上単価端数処理コード
            writer.Write(temp.SalesUnPrcFrcProcCd);
            //売上金額端数処理コード
            writer.Write(temp.SalesMoneyFrcProcCd);
            //売上消費税端数処理コード
            writer.Write(temp.SalesCnsTaxFrcProcCd);
            //得意先伝票番号区分
            writer.Write(temp.CustomerSlipNoDiv);
            //次回勘定開始日
            writer.Write(temp.NTimeCalcStDate);
            //得意先担当者
            writer.Write(temp.CustomerAgent);
            //請求拠点コード
            writer.Write(temp.ClaimSectionCode);
            //車輌管理区分
            writer.Write(temp.CarMngDivCd);
            //品番印字区分(請求書)
            writer.Write(temp.BillPartsNoPrtCd);
            //品番印字区分(納品書）
            writer.Write(temp.DeliPartsNoPrtCd);
            //伝票区分初期値
            writer.Write(temp.DefSalesSlipCd);
            //工賃レバレートランク
            writer.Write(temp.LavorRateRank);
            //伝票タイトルパターン
            writer.Write(temp.SlipTtlPrn);
            //入金銀行コード
            writer.Write(temp.DepoBankCode);
            //得意先優先倉庫コード
            writer.Write(temp.CustWarehouseCd);
            //QRコード印刷
            writer.Write(temp.QrcodePrtCd);
            //納品書敬称
            writer.Write(temp.DeliHonorificTtl);
            //請求書敬称
            writer.Write(temp.BillHonorificTtl);
            //見積書敬称
            writer.Write(temp.EstmHonorificTtl);
            //領収書敬称
            writer.Write(temp.RectHonorificTtl);
            //納品書敬称印字区分
            writer.Write(temp.DeliHonorTtlPrtDiv);
            //請求書敬称印字区分
            writer.Write(temp.BillHonorTtlPrtDiv);
            //見積書敬称印字区分
            writer.Write(temp.EstmHonorTtlPrtDiv);
            //領収書敬称印字区分
            writer.Write(temp.RectHonorTtlPrtDiv);
            //備考1
            writer.Write(temp.Note1);
            //備考2
            writer.Write(temp.Note2);
            //備考3
            writer.Write(temp.Note3);
            //備考4
            writer.Write(temp.Note4);
            //備考5
            writer.Write(temp.Note5);
            //備考6
            writer.Write(temp.Note6);
            //備考7
            writer.Write(temp.Note7);
            //備考8
            writer.Write(temp.Note8);
            //備考9
            writer.Write(temp.Note9);
            //備考10
            writer.Write(temp.Note10);
            //売上伝票発行区分
            writer.Write(temp.SalesSlipPrtDiv);
            //出荷伝票発行区分
            writer.Write(temp.ShipmSlipPrtDiv);
            //受注伝票発行区分
            writer.Write(temp.AcpOdrrSlipPrtDiv);
            //見積書発行区分
            writer.Write(temp.EstimatePrtDiv);
            //UOE伝票発行区分
            writer.Write(temp.UOESlipPrtDiv);
            //領収書出力区分コード
            writer.Write(temp.ReceiptOutputCode);
            //得意先企業コード
            writer.Write(temp.CustomerEpCode);
            //得意先拠点コード
            writer.Write(temp.CustomerSecCode);
            //オンライン種別区分
            writer.Write(temp.OnlineKindDiv);
            //合計請求書出力区分
            writer.Write(temp.TotalBillOutputDiv);
            //明細請求書出力区分
            writer.Write(temp.DetailBillOutputCode);
            //伝票合計請求書出力区分
            writer.Write(temp.SlipTtlBillOutputDiv);


        }

        /// <summary>
        ///  CustomerWorkインスタンス取得
        /// </summary>
        /// <returns>CustomerWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerWorkのインスタンスを取得します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        private APCustomerWork GetCustomerWork(System.IO.BinaryReader reader, Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo)
        {
            // V5.1.0.0なので不要ですが、V5.1.0.1以降では
            // serInfo.MemberInfo.Count < currentMemberCount
            // のケースについての配慮が必要になります。

            APCustomerWork temp = new APCustomerWork();

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
            //得意先コード
            temp.CustomerCode = reader.ReadInt32();
            //得意先サブコード
            temp.CustomerSubCode = reader.ReadString();
            //名称
            temp.Name = reader.ReadString();
            //名称2
            temp.Name2 = reader.ReadString();
            //敬称
            temp.HonorificTitle = reader.ReadString();
            //カナ
            temp.Kana = reader.ReadString();
            //得意先略称
            temp.CustomerSnm = reader.ReadString();
            //諸口コード
            temp.OutputNameCode = reader.ReadInt32();
            //諸口名称
            temp.OutputName = reader.ReadString();
            //個人・法人区分
            temp.CorporateDivCode = reader.ReadInt32();
            //得意先属性区分
            temp.CustomerAttributeDiv = reader.ReadInt32();
            //職種コード
            temp.JobTypeCode = reader.ReadInt32();
            //業種コード
            temp.BusinessTypeCode = reader.ReadInt32();
            //販売エリアコード
            temp.SalesAreaCode = reader.ReadInt32();
            //郵便番号
            temp.PostNo = reader.ReadString();
            //住所1（都道府県市区郡・町村・字）
            temp.Address1 = reader.ReadString();
            //住所3（番地）
            temp.Address3 = reader.ReadString();
            //住所4（アパート名称）
            temp.Address4 = reader.ReadString();
            //電話番号（自宅）
            temp.HomeTelNo = reader.ReadString();
            //電話番号（勤務先）
            temp.OfficeTelNo = reader.ReadString();
            //電話番号（携帯）
            temp.PortableTelNo = reader.ReadString();
            //FAX番号（自宅）
            temp.HomeFaxNo = reader.ReadString();
            //FAX番号（勤務先）
            temp.OfficeFaxNo = reader.ReadString();
            //電話番号（その他）
            temp.OthersTelNo = reader.ReadString();
            //主連絡先区分
            temp.MainContactCode = reader.ReadInt32();
            //電話番号（検索用下4桁）
            temp.SearchTelNo = reader.ReadString();
            //管理拠点コード
            temp.MngSectionCode = reader.ReadString();
            //入力拠点コード
            temp.InpSectionCode = reader.ReadString();
            //得意先分析コード1
            temp.CustAnalysCode1 = reader.ReadInt32();
            //得意先分析コード2
            temp.CustAnalysCode2 = reader.ReadInt32();
            //得意先分析コード3
            temp.CustAnalysCode3 = reader.ReadInt32();
            //得意先分析コード4
            temp.CustAnalysCode4 = reader.ReadInt32();
            //得意先分析コード5
            temp.CustAnalysCode5 = reader.ReadInt32();
            //得意先分析コード6
            temp.CustAnalysCode6 = reader.ReadInt32();
            //請求書出力区分コード
            temp.BillOutputCode = reader.ReadInt32();
            //請求書出力区分名称
            temp.BillOutputName = reader.ReadString();
            //締日
            temp.TotalDay = reader.ReadInt32();
            //集金月区分コード
            temp.CollectMoneyCode = reader.ReadInt32();
            //集金月区分名称
            temp.CollectMoneyName = reader.ReadString();
            //集金日
            temp.CollectMoneyDay = reader.ReadInt32();
            //回収条件
            temp.CollectCond = reader.ReadInt32();
            //回収サイト
            temp.CollectSight = reader.ReadInt32();
            //請求先コード
            temp.ClaimCode = reader.ReadInt32();
            //取引中止日
            temp.TransStopDate = new DateTime(reader.ReadInt64());
            //DM出力区分
            temp.DmOutCode = reader.ReadInt32();
            //DM出力区分名称
            temp.DmOutName = reader.ReadString();
            //主送信先メールアドレス区分
            temp.MainSendMailAddrCd = reader.ReadInt32();
            //メールアドレス種別コード1
            temp.MailAddrKindCode1 = reader.ReadInt32();
            //メールアドレス種別名称1
            temp.MailAddrKindName1 = reader.ReadString();
            //メールアドレス1
            temp.MailAddress1 = reader.ReadString();
            //メール送信区分コード1
            temp.MailSendCode1 = reader.ReadInt32();
            //メール送信区分名称1
            temp.MailSendName1 = reader.ReadString();
            //メールアドレス種別コード2
            temp.MailAddrKindCode2 = reader.ReadInt32();
            //メールアドレス種別名称2
            temp.MailAddrKindName2 = reader.ReadString();
            //メールアドレス2
            temp.MailAddress2 = reader.ReadString();
            //メール送信区分コード2
            temp.MailSendCode2 = reader.ReadInt32();
            //メール送信区分名称2
            temp.MailSendName2 = reader.ReadString();
            //顧客担当従業員コード
            temp.CustomerAgentCd = reader.ReadString();
            //集金担当従業員コード
            temp.BillCollecterCd = reader.ReadString();
            //旧顧客担当従業員コード
            temp.OldCustomerAgentCd = reader.ReadString();
            //顧客担当変更日
            temp.CustAgentChgDate = new DateTime(reader.ReadInt64());
            //業販先区分
            temp.AcceptWholeSale = reader.ReadInt32();
            //与信管理区分
            temp.CreditMngCode = reader.ReadInt32();
            //入金消込区分
            temp.DepoDelCode = reader.ReadInt32();
            //売掛区分
            temp.AccRecDivCd = reader.ReadInt32();
            //相手伝票番号管理区分
            temp.CustSlipNoMngCd = reader.ReadInt32();
            //純正区分
            temp.PureCode = reader.ReadInt32();
            //得意先消費税転嫁方式参照区分
            temp.CustCTaXLayRefCd = reader.ReadInt32();
            //消費税転嫁方式
            temp.ConsTaxLayMethod = reader.ReadInt32();
            //総額表示方法区分
            temp.TotalAmountDispWayCd = reader.ReadInt32();
            //総額表示方法参照区分
            temp.TotalAmntDspWayRef = reader.ReadInt32();
            //銀行口座1
            temp.AccountNoInfo1 = reader.ReadString();
            //銀行口座2
            temp.AccountNoInfo2 = reader.ReadString();
            //銀行口座3
            temp.AccountNoInfo3 = reader.ReadString();
            //売上単価端数処理コード
            temp.SalesUnPrcFrcProcCd = reader.ReadInt32();
            //売上金額端数処理コード
            temp.SalesMoneyFrcProcCd = reader.ReadInt32();
            //売上消費税端数処理コード
            temp.SalesCnsTaxFrcProcCd = reader.ReadInt32();
            //得意先伝票番号区分
            temp.CustomerSlipNoDiv = reader.ReadInt32();
            //次回勘定開始日
            temp.NTimeCalcStDate = reader.ReadInt32();
            //得意先担当者
            temp.CustomerAgent = reader.ReadString();
            //請求拠点コード
            temp.ClaimSectionCode = reader.ReadString();
            //車輌管理区分
            temp.CarMngDivCd = reader.ReadInt32();
            //品番印字区分(請求書)
            temp.BillPartsNoPrtCd = reader.ReadInt32();
            //品番印字区分(納品書）
            temp.DeliPartsNoPrtCd = reader.ReadInt32();
            //伝票区分初期値
            temp.DefSalesSlipCd = reader.ReadInt32();
            //工賃レバレートランク
            temp.LavorRateRank = reader.ReadInt32();
            //伝票タイトルパターン
            temp.SlipTtlPrn = reader.ReadInt32();
            //入金銀行コード
            temp.DepoBankCode = reader.ReadInt32();
            //得意先優先倉庫コード
            temp.CustWarehouseCd = reader.ReadString();
            //QRコード印刷
            temp.QrcodePrtCd = reader.ReadInt32();
            //納品書敬称
            temp.DeliHonorificTtl = reader.ReadString();
            //請求書敬称
            temp.BillHonorificTtl = reader.ReadString();
            //見積書敬称
            temp.EstmHonorificTtl = reader.ReadString();
            //領収書敬称
            temp.RectHonorificTtl = reader.ReadString();
            //納品書敬称印字区分
            temp.DeliHonorTtlPrtDiv = reader.ReadInt32();
            //請求書敬称印字区分
            temp.BillHonorTtlPrtDiv = reader.ReadInt32();
            //見積書敬称印字区分
            temp.EstmHonorTtlPrtDiv = reader.ReadInt32();
            //領収書敬称印字区分
            temp.RectHonorTtlPrtDiv = reader.ReadInt32();
            //備考1
            temp.Note1 = reader.ReadString();
            //備考2
            temp.Note2 = reader.ReadString();
            //備考3
            temp.Note3 = reader.ReadString();
            //備考4
            temp.Note4 = reader.ReadString();
            //備考5
            temp.Note5 = reader.ReadString();
            //備考6
            temp.Note6 = reader.ReadString();
            //備考7
            temp.Note7 = reader.ReadString();
            //備考8
            temp.Note8 = reader.ReadString();
            //備考9
            temp.Note9 = reader.ReadString();
            //備考10
            temp.Note10 = reader.ReadString();
            //売上伝票発行区分
            temp.SalesSlipPrtDiv = reader.ReadInt32();
            //出荷伝票発行区分
            temp.ShipmSlipPrtDiv = reader.ReadInt32();
            //受注伝票発行区分
            temp.AcpOdrrSlipPrtDiv = reader.ReadInt32();
            //見積書発行区分
            temp.EstimatePrtDiv = reader.ReadInt32();
            //UOE伝票発行区分
            temp.UOESlipPrtDiv = reader.ReadInt32();
            //領収書出力区分コード
            temp.ReceiptOutputCode = reader.ReadInt32();
            //得意先企業コード
            temp.CustomerEpCode = reader.ReadString();
            //得意先拠点コード
            temp.CustomerSecCode = reader.ReadString();
            //オンライン種別区分
            temp.OnlineKindDiv = reader.ReadInt32();
            //合計請求書出力区分
            temp.TotalBillOutputDiv = reader.ReadInt32();
            //明細請求書出力区分
            temp.DetailBillOutputCode = reader.ReadInt32();
            //伝票合計請求書出力区分
            temp.SlipTtlBillOutputDiv = reader.ReadInt32();



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
        /// <returns>CustomerWorkクラスのインスタンス(object)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CustomerWorkクラスのカスタムデシリアライザを定義します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public object Deserialize(System.IO.BinaryReader reader)
        {
            object retValue = null;
            Broadleaf.Library.Runtime.Serialization.TypeSerializationInfo serInfo = TypeSerializationInfo.DeserializedObject(reader);
            ArrayList lst = new ArrayList();
            for (int cnt = 0; cnt < serInfo.Occurrence; ++cnt)
            {
                APCustomerWork temp = GetCustomerWork(reader, serInfo);
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
                    retValue = (APCustomerWork[])lst.ToArray(typeof(APCustomerWork));
                    break;
            }
            return retValue;
        }

        #endregion
    }


}
