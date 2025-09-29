using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   AllDefSet
    /// <summary>
    ///                      全体初期値設定マスタ
    /// </summary>
    /// <remarks>
    /// <br>note             :   全体初期値設定マスタヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   </br>
    /// <br>Genarated Date   :   2008/01/10  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   2008/06/04 30414  忍　幸史</br>
    /// <br>                     「顧客コード自動発番」「得意先削除チェック」「会員情報管理」削除</br>
    /// <br>Update Note      :   2010/01/18 30531  大矢 睦美</br>
    /// <br>                     請求書タイプ毎の出力区分項目追加（３項目）</br>
    /// <br>Update Note      : 2011/07/19 zhouyu</br>
    /// <br>                ・連番 1028</br>
    /// <br>                  修正内容：連番 1028 在庫仕入入力で、品番入力後に自動で 仕入数=１ と表示され、現在庫数が足されて表示になり分かりずらい</br>
    /// <br>                  PM7では、仕入数=1と表示され仕入前の現在個数を表示、行移動後に現在個数が再表示される</br>
    /// <br>                  売上伝票入力，仕入伝票入力 も同じ</br>
    /// <br>Update Note      :   2013/05/02 王君</br>
    /// <br>管理番号　       :   10901273-00 2013/06/18配信分　
    /// 　　　　　　　　　   :   Redmine#35434 商品在庫マスタ起動区分の追加</br>
    /// </remarks>
    public class AllDefSet
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

        /// <summary>拠点コード</summary>
        private string _sectionCode = "";

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>得意先削除チェック区分</summary>
        /// <remarks>0:未引当伝票が存在する場合は削除不可とする,1:未引当伝票が存在する場合でも削除可能とする</remarks>
        private Int32 _customerDelChkDivCd;

        /// <summary>顧客コード自動発番区分</summary>
        /// <remarks>0:手入力可,1:手入力不可</remarks>
        private Int32 _custCdAutoNumbering;
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>初期表示顧客締日</summary>
        /// <remarks>0～31</remarks>
        private Int32 _defDspCustTtlDay;

        /// <summary>初期表示顧客集金日</summary>
        /// <remarks>0～31</remarks>
        private Int32 _defDspCustClctMnyDay;

        /// <summary>初期表示集金月区分</summary>
        /// <remarks>0:当月,1:翌月,2:翌々月</remarks>
        private Int32 _defDspClctMnyMonthCd;

        /// <summary>初期表示個人・法人区分</summary>
        /// <remarks>0:個人,1:法人</remarks>
        private Int32 _iniDspPrslOrCorpCd;

        /// <summary>初期表示DM区分</summary>
        /// <remarks>0:ＤＭ出力する,1:ＤＭ出力しない</remarks>
        private Int32 _initDspDmDiv;

        /// <summary>初期表示請求書出力区分</summary>
        /// <remarks>0:請求書出力する,1:請求書出力しない</remarks>
        private Int32 _defDspBillPrtDivCd;

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// <summary>会員情報管理区分</summary>
        /// <remarks>0:会員情報管理する、1:会員情報管理しない</remarks>
        private Int32 _memberInfoDispCd;
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// <summary>元号表示区分１</summary>
        /// <remarks>0:西暦　1:和暦（通常）　　</remarks>
        private Int32 _eraNameDispCd1;

        /// <summary>元号表示区分２</summary>
        /// <remarks>0:西暦　1:和暦（年式）</remarks>
        private Int32 _eraNameDispCd2;

        /// <summary>元号表示区分３</summary>
        /// <remarks>0:西暦　1:和暦（その他）</remarks>
        private Int32 _eraNameDispCd3;

        /// <summary>部署管理区分</summary>
        /// <remarks>0:拠点　1:拠点＋部　2:拠点＋部＋課</remarks>
        private Int32 _secMngDiv;

        /// <summary>商品番号入力区分</summary>
        /// <remarks>0:任意　1:必須</remarks>
        private Int32 _goodsNoInpDiv;



        /// <summary>消費税自動補正区分</summary>
        /// <remarks>0:自動　1:手動</remarks>
        private Int32 _cnsTaxAutoCorrDiv;

        /// <summary>残数管理区分</summary>
        /// <remarks>0:する 1:しない ※伝票削除時に残に戻すかどうか</remarks>
        private Int32 _remainCntMngDiv;

        /// <summary>メモ複写区分</summary>
        /// <remarks>0:する　1:社外メモのみ　2:しない</remarks>
        private Int32 _memoMoveDiv;

        /// <summary>残数自動表示区分</summary>
        /// <remarks>0:しない,1:出荷残,入荷残のみ，2:受発注残のみ，3:出荷残,入荷残 ->受発注残 4:受発注残 -> 出荷残,入荷残</remarks>
        private Int32 _remCntAutoDspDiv;

        /// <summary>総額表示掛率適用区分</summary>
        /// <remarks>0：税込単価, 1:税抜単価</remarks>
        private Int32 _ttlAmntDspRateDivCd;

        /// <summary>企業名称</summary>
        private string _enterpriseName = "";

        /// <summary>更新従業員名称</summary>
        private string _updEmployeeName = "";

        // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
        /// <summary>初期表示合計請求書出力区分</summary>
        /// <remarks>0:出力する　1:出力しない</remarks>
        private Int32 _defTtlBillOutput;

        /// <summary>初期表示明細請求書出力区分</summary>
        /// <remarks>0:出力する　1:出力しない</remarks>
        private Int32 _defDtlBillOutput;

        /// <summary>初期表示伝票合計請求書出力区分</summary>
        /// <remarks>0:出力する　1:出力しない</remarks>
        private Int32 _defSlTtlBillOutput;
        // --- ADD  大矢睦美  2010/01/18 ----------<<<<<

        //ADD 2011/07/19
        /// <summary>仕入・出荷後数表示区分</summary>
        /// <remarks>0:品番確定後更新　1:明細確定後更新</remarks>
        private Int32 _dtlCalcStckCntDsp;
        //ADD 2011/07/19

        // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
        /// <summary>商品在庫マスタ表示区分</summary>
        /// <remarks>0:商品在庫マスタⅠ　1:商品在庫マスタⅡ</remarks>
        private Int32 _goodsStockMSTBootDiv;
        // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<

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

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
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

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  CustomerDelChkDivCd
        /// <summary>得意先削除チェック区分プロパティ</summary>
        /// <value>0:未引当伝票が存在する場合は削除不可とする,1:未引当伝票が存在する場合でも削除可能とする</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   得意先削除チェック区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustomerDelChkDivCd
        {
            get { return _customerDelChkDivCd; }
            set { _customerDelChkDivCd = value; }
        }

        /// public propaty name  :  CustCdAutoNumbering
        /// <summary>顧客コード自動発番区分プロパティ</summary>
        /// <value>0:手入力可,1:手入力不可</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   顧客コード自動発番区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CustCdAutoNumbering
        {
            get { return _custCdAutoNumbering; }
            set { _custCdAutoNumbering = value; }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  DefDspCustTtlDay
        /// <summary>初期表示顧客締日プロパティ</summary>
        /// <value>0～31</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示顧客締日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefDspCustTtlDay
        {
            get { return _defDspCustTtlDay; }
            set { _defDspCustTtlDay = value; }
        }

        /// public propaty name  :  DefDspCustClctMnyDay
        /// <summary>初期表示顧客集金日プロパティ</summary>
        /// <value>0～31</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示顧客集金日プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefDspCustClctMnyDay
        {
            get { return _defDspCustClctMnyDay; }
            set { _defDspCustClctMnyDay = value; }
        }

        /// public propaty name  :  DefDspClctMnyMonthCd
        /// <summary>初期表示集金月区分プロパティ</summary>
        /// <value>0:当月,1:翌月,2:翌々月</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示集金月区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefDspClctMnyMonthCd
        {
            get { return _defDspClctMnyMonthCd; }
            set { _defDspClctMnyMonthCd = value; }
        }

        /// public propaty name  :  IniDspPrslOrCorpCd
        /// <summary>初期表示個人・法人区分プロパティ</summary>
        /// <value>0:個人,1:法人</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示個人・法人区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 IniDspPrslOrCorpCd
        {
            get { return _iniDspPrslOrCorpCd; }
            set { _iniDspPrslOrCorpCd = value; }
        }

        /// public propaty name  :  InitDspDmDiv
        /// <summary>初期表示DM区分プロパティ</summary>
        /// <value>0:ＤＭ出力する,1:ＤＭ出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示DM区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 InitDspDmDiv
        {
            get { return _initDspDmDiv; }
            set { _initDspDmDiv = value; }
        }

        /// public propaty name  :  DefDspBillPrtDivCd
        /// <summary>初期表示請求書出力区分プロパティ</summary>
        /// <value>0:請求書出力する,1:請求書出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefDspBillPrtDivCd
        {
            get { return _defDspBillPrtDivCd; }
            set { _defDspBillPrtDivCd = value; }
        }

        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        /// public propaty name  :  MemberInfoDispCd
        /// <summary>会員情報管理区分プロパティ</summary>
        /// <value>0:会員情報管理する、1:会員情報管理しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   会員情報管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MemberInfoDispCd
        {
            get { return _memberInfoDispCd; }
            set { _memberInfoDispCd = value; }
        }
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/

        /// public propaty name  :  EraNameDispCd1
        /// <summary>元号表示区分１プロパティ</summary>
        /// <value>0:西暦　1:和暦（通常）　　</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   元号表示区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EraNameDispCd1
        {
            get { return _eraNameDispCd1; }
            set { _eraNameDispCd1 = value; }
        }

        /// public propaty name  :  EraNameDispCd2
        /// <summary>元号表示区分２プロパティ</summary>
        /// <value>0:西暦　1:和暦（年式）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   元号表示区分２プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EraNameDispCd2
        {
            get { return _eraNameDispCd2; }
            set { _eraNameDispCd2 = value; }
        }

        /// public propaty name  :  EraNameDispCd3
        /// <summary>元号表示区分３プロパティ</summary>
        /// <value>0:西暦　1:和暦（その他）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   元号表示区分３プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EraNameDispCd3
        {
            get { return _eraNameDispCd3; }
            set { _eraNameDispCd3 = value; }
        }

        /// public propaty name  :  SecMngDiv
        /// <summary>部署管理区分プロパティ</summary>
        /// <value>0:拠点　1:拠点＋部　2:拠点＋部＋課</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部署管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SecMngDiv
        {
            get { return _secMngDiv; }
            set { _secMngDiv = value; }
        }

        /// public propaty name  :  GoodsNoInpDiv
        /// <summary>商品番号入力区分プロパティ</summary>
        /// <value>0:任意　1:必須</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品番号入力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsNoInpDiv
        {
            get { return _goodsNoInpDiv; }
            set { _goodsNoInpDiv = value; }
        }


        /// public propaty name  :  CnsTaxAutoCorrDiv
        /// <summary>消費税自動補正区分プロパティ</summary>
        /// <value>0:自動　1:手動</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   消費税自動補正区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 CnsTaxAutoCorrDiv
        {
            get { return _cnsTaxAutoCorrDiv; }
            set { _cnsTaxAutoCorrDiv = value; }
        }

        /// public propaty name  :  RemainCntMngDiv
        /// <summary>残数管理区分プロパティ</summary>
        /// <value>0:する 1:しない ※伝票削除時に残に戻すかどうか</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数管理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RemainCntMngDiv
        {
            get { return _remainCntMngDiv; }
            set { _remainCntMngDiv = value; }
        }

        /// public propaty name  :  MemoMoveDiv
        /// <summary>メモ複写区分プロパティ</summary>
        /// <value>0:する　1:社外メモのみ　2:しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   メモ複写区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 MemoMoveDiv
        {
            get { return _memoMoveDiv; }
            set { _memoMoveDiv = value; }
        }

        /// public propaty name  :  RemCntAutoDspDiv
        /// <summary>残数自動表示区分プロパティ</summary>
        /// <value>0:しない,1:出荷残,入荷残のみ，2:受発注残のみ，3:出荷残,入荷残 ->受発注残 4:受発注残 -> 出荷残,入荷残</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   残数自動表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 RemCntAutoDspDiv
        {
            get { return _remCntAutoDspDiv; }
            set { _remCntAutoDspDiv = value; }
        }

        /// public propaty name  :  TtlAmntDspRateDivCd
        /// <summary>総額表示掛率適用区分プロパティ</summary>
        /// <value>0：税込単価, 1:税抜単価</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   総額表示掛率適用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 TtlAmntDspRateDivCd
        {
            get { return _ttlAmntDspRateDivCd; }
            set { _ttlAmntDspRateDivCd = value; }
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

        // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
        /// public propaty name  :  DefTtlBillOutput
        /// <summary>初期表示合計請求書出力区分プロパティ</summary>
        /// <value>0:出力する　1:出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefTtlBillOutput
        {
            get { return _defTtlBillOutput; }
            set { _defTtlBillOutput = value; }
        }

        /// public propaty name  :  DefDtlBillOutput
        /// <summary>初期表示明細請求書出力区分プロパティ</summary>
        /// <value>0:出力する　1:出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示明細請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefDtlBillOutput
        {
            get { return _defDtlBillOutput; }
            set { _defDtlBillOutput = value; }
        }

        /// public propaty name  :  DefSlTtlBillOutput
        /// <summary>初期表示伝票合計請求書出力区分プロパティ</summary>
        /// <value>0:出力する　1:出力しない</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   初期表示伝票合計請求書出力区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DefSlTtlBillOutput
        {
            get { return _defSlTtlBillOutput; }
            set { _defSlTtlBillOutput = value; }
        }
        // --- ADD  大矢睦美  2010/01/18 ----------<<<<<

        //ADD 2011/07/19
        /// <summary>仕入・出荷後数表示区分プロパティ</summary>
        /// <value>0:品番確定後更新　1:明細確定後更新</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   仕入・出荷後数表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 DtlCalcStckCntDsp
        {
            get { return _dtlCalcStckCntDsp; }
            set { _dtlCalcStckCntDsp = value; }
        }
        //ADD 2011/07/19

        // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
        /// <summary>商品在庫マスタ表示区分プロパティ</summary>
        /// <value>0:商品在庫マスタⅠ　1:商品在庫マスタⅡ</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   商品在庫表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 GoodsStockMSTBootDiv
        {
            get { return _goodsStockMSTBootDiv; }
            set { _goodsStockMSTBootDiv = value; }
        }
        // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<

        /// <summary>
        /// 全体初期値設定マスタコンストラクタ
        /// </summary>
        /// <returns>AllDefSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AllDefSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public AllDefSet()
        {
        }

        /// <summary>
        /// 全体初期値設定マスタコンストラクタ
        /// </summary>
        /// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="fileHeaderGuid">GUID(共通ファイルヘッダ)</param>
        /// <param name="updEmployeeCode">更新従業員コード(共通ファイルヘッダ)</param>
        /// <param name="updAssemblyId1">更新アセンブリID1(共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="updAssemblyId2">更新アセンブリID2(共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）)</param>
        /// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="totalAmountDispWayCd">総額表示方法区分(0:総額表示しない（税抜き）,1:総額表示する（税込み）)</param>
        /// <param name="defDspCustTtlDay">初期表示顧客締日(0～31)</param>
        /// <param name="defDspCustClctMnyDay">初期表示顧客集金日(0～31)</param>
        /// <param name="defDspClctMnyMonthCd">初期表示集金月区分(0:当月,1:翌月,2:翌々月)</param>
        /// <param name="iniDspPrslOrCorpCd">初期表示個人・法人区分(0:個人,1:法人)</param>
        /// <param name="initDspDmDiv">初期表示DM区分(0:ＤＭ出力する,1:ＤＭ出力しない)</param>
        /// <param name="defDspBillPrtDivCd">初期表示請求書出力区分(0:請求書出力する,1:請求書出力しない)</param>
        /// <param name="eraNameDispCd1">元号表示区分１(0:西暦　1:和暦（通常）　　)</param>
        /// <param name="eraNameDispCd2">元号表示区分２(0:西暦　1:和暦（年式）)</param>
        /// <param name="eraNameDispCd3">元号表示区分３(0:西暦　1:和暦（その他）)</param>
        /// <param name="secMngDiv">部署管理区分(0:拠点　1:拠点＋部　2:拠点＋部＋課)</param>
        /// <param name="goodsNoInpDiv">商品番号入力区分(0:任意　1:必須)</param>
        /// <param name="cnsTaxAutoCorrDiv">消費税自動補正区分(0:自動　1:手動)</param>
        /// <param name="remainCntMngDiv">残数管理区分(0:する 1:しない ※伝票削除時に残に戻すかどうか)</param>
        /// <param name="memoMoveDiv">メモ複写区分(0:する　1:社外メモのみ　2:しない)</param>
        /// <param name="remCntAutoDspDiv">残数自動表示区分(0:しない,1:出荷残,入荷残のみ，2:受発注残のみ，3:出荷残,入荷残 ->受発注残 4:受発注残 -> 出荷残,入荷残)</param>
        /// <param name="ttlAmntDspRateDivCd">総額表示掛率適用区分(0：税込単価, 1:税抜単価)</param>
        /// <param name="enterpriseName">企業名称</param>
        /// <param name="updEmployeeName">更新従業員名称</param>
        /// <param name="dtlCalcStckCntDsp">明細算出後在庫数表示区分(0:検索後反映 1:行移動時反映)</param>
        /// <returns>AllDefSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AllDefSetクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2013/05/02 王君</br>
        /// <br>管理番号　       :   10901273-00 2013/06/18配信分　
        /// 　　　　　　　　　   :   Redmine#35434 商品在庫マスタ起動区分の追加</br>
        /// </remarks>
        /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
        public AllDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 totalAmountDispWayCd, Int32 customerDelChkDivCd, Int32 custCdAutoNumbering, Int32 defDspCustTtlDay, Int32 defDspCustClctMnyDay, Int32 defDspClctMnyMonthCd, Int32 iniDspPrslOrCorpCd, Int32 initDspDmDiv, Int32 defDspBillPrtDivCd, Int32 memberInfoDispCd, Int32 eraNameDispCd1, Int32 eraNameDispCd2, Int32 eraNameDispCd3, Int32 secMngDiv, Int32 goodsNoInpDiv, Int32 cnsTaxAutoCorrDiv, Int32 remainCntMngDiv, Int32 memoMoveDiv, Int32 remCntAutoDspDiv, Int32 ttlAmntDspRateDivCd, string enterpriseName, string updEmployeeName)
           --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
        // --- UPD  大矢睦美  2010/01/18 ---------->>>>>
        //public AllDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 totalAmountDispWayCd, Int32 defDspCustTtlDay, Int32 defDspCustClctMnyDay, Int32 defDspClctMnyMonthCd, Int32 iniDspPrslOrCorpCd, Int32 initDspDmDiv, Int32 defDspBillPrtDivCd, Int32 eraNameDispCd1, Int32 eraNameDispCd2, Int32 eraNameDispCd3, Int32 secMngDiv, Int32 goodsNoInpDiv, Int32 cnsTaxAutoCorrDiv, Int32 remainCntMngDiv, Int32 memoMoveDiv, Int32 remCntAutoDspDiv, Int32 ttlAmntDspRateDivCd, string enterpriseName, string updEmployeeName)
        //public AllDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 totalAmountDispWayCd, Int32 defDspCustTtlDay, Int32 defDspCustClctMnyDay, Int32 defDspClctMnyMonthCd, Int32 iniDspPrslOrCorpCd, Int32 initDspDmDiv, Int32 defDspBillPrtDivCd, Int32 eraNameDispCd1, Int32 eraNameDispCd2, Int32 eraNameDispCd3, Int32 secMngDiv, Int32 goodsNoInpDiv, Int32 cnsTaxAutoCorrDiv, Int32 remainCntMngDiv, Int32 memoMoveDiv, Int32 remCntAutoDspDiv, Int32 ttlAmntDspRateDivCd, string enterpriseName, string updEmployeeName, Int32 defTtlBillOutput, Int32 defDtlBillOutput, Int32 defSlTtlBillOutput)  //DEL 2011/07/19
        // --- UPD  大矢睦美  2010/01/18 ----------<<<<<
        //public AllDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 totalAmountDispWayCd, Int32 defDspCustTtlDay, Int32 defDspCustClctMnyDay, Int32 defDspClctMnyMonthCd, Int32 iniDspPrslOrCorpCd, Int32 initDspDmDiv, Int32 defDspBillPrtDivCd, Int32 eraNameDispCd1, Int32 eraNameDispCd2, Int32 eraNameDispCd3, Int32 secMngDiv, Int32 goodsNoInpDiv, Int32 cnsTaxAutoCorrDiv, Int32 remainCntMngDiv, Int32 memoMoveDiv, Int32 remCntAutoDspDiv, Int32 ttlAmntDspRateDivCd, string enterpriseName, string updEmployeeName, Int32 defTtlBillOutput, Int32 defDtlBillOutput, Int32 defSlTtlBillOutput, Int32 dtlCalcStckCntDsp)  //ADD 2011/07/19  //DEL 王君 2013/05/02 Redmine#35434
        public AllDefSet(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, string sectionCode, Int32 totalAmountDispWayCd, Int32 defDspCustTtlDay, Int32 defDspCustClctMnyDay, Int32 defDspClctMnyMonthCd, Int32 iniDspPrslOrCorpCd, Int32 initDspDmDiv, Int32 defDspBillPrtDivCd, Int32 eraNameDispCd1, Int32 eraNameDispCd2, Int32 eraNameDispCd3, Int32 secMngDiv, Int32 goodsNoInpDiv, Int32 cnsTaxAutoCorrDiv, Int32 remainCntMngDiv, Int32 memoMoveDiv, Int32 remCntAutoDspDiv, Int32 ttlAmntDspRateDivCd, string enterpriseName, string updEmployeeName, Int32 defTtlBillOutput, Int32 defDtlBillOutput, Int32 defSlTtlBillOutput, Int32 dtlCalcStckCntDsp, Int32 goodsStockMSTBootDiv)  //ADD 王君 2013/05/02 Redmine#35434
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._sectionCode = sectionCode;
            this._totalAmountDispWayCd = totalAmountDispWayCd;
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            this._customerDelChkDivCd = customerDelChkDivCd;
            this._custCdAutoNumbering = custCdAutoNumbering;
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            this._defDspCustTtlDay = defDspCustTtlDay;
            this._defDspCustClctMnyDay = defDspCustClctMnyDay;
            this._defDspClctMnyMonthCd = defDspClctMnyMonthCd;
            this._iniDspPrslOrCorpCd = iniDspPrslOrCorpCd;
            this._initDspDmDiv = initDspDmDiv;
            this._defDspBillPrtDivCd = defDspBillPrtDivCd;
            //this._memberInfoDispCd = memberInfoDispCd;  // DEL 2008/06/04
            this._eraNameDispCd1 = eraNameDispCd1;
            this._eraNameDispCd2 = eraNameDispCd2;
            this._eraNameDispCd3 = eraNameDispCd3;
            this._secMngDiv = secMngDiv;
            this._goodsNoInpDiv = goodsNoInpDiv;
            this._cnsTaxAutoCorrDiv = cnsTaxAutoCorrDiv;
            this._remainCntMngDiv = remainCntMngDiv;
            this._memoMoveDiv = memoMoveDiv;
            this._remCntAutoDspDiv = remCntAutoDspDiv;
            this._ttlAmntDspRateDivCd = ttlAmntDspRateDivCd;
            this._enterpriseName = enterpriseName;
            this._updEmployeeName = updEmployeeName;
            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            this._defTtlBillOutput = defTtlBillOutput;
            this._defDtlBillOutput = defDtlBillOutput;
            this._defSlTtlBillOutput = defSlTtlBillOutput;
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            this._dtlCalcStckCntDsp = dtlCalcStckCntDsp; //ADD 2011/07/19
            this._goodsStockMSTBootDiv = goodsStockMSTBootDiv; // ADD 王君　2013/05/02　Redmine#35434

        }

        /// <summary>
        /// 全体初期値設定マスタ複製処理
        /// </summary>
        /// <returns>AllDefSetクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいAllDefSetクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2013/05/02 王君</br>
        /// <br>管理番号　       :   10901273-00 2013/06/18配信分　
        /// 　　　　　　　　　   :   Redmine#35434 商品在庫マスタ起動区分の追加</br>
        /// </remarks>
        public AllDefSet Clone()
        {
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            return new AllDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._totalAmountDispWayCd, this._customerDelChkDivCd, this._custCdAutoNumbering, this._defDspCustTtlDay, this._defDspCustClctMnyDay, this._defDspClctMnyMonthCd, this._iniDspPrslOrCorpCd, this._initDspDmDiv, this._defDspBillPrtDivCd, this._memberInfoDispCd, this._eraNameDispCd1, this._eraNameDispCd2, this._eraNameDispCd3, this._secMngDiv, this._goodsNoInpDiv, this._cnsTaxAutoCorrDiv, this._remainCntMngDiv, this._memoMoveDiv, this._remCntAutoDspDiv, this._ttlAmntDspRateDivCd, this._enterpriseName, this._updEmployeeName);
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            //return new AllDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._totalAmountDispWayCd, this._defDspCustTtlDay, this._defDspCustClctMnyDay, this._defDspClctMnyMonthCd, this._iniDspPrslOrCorpCd, this._initDspDmDiv, this._defDspBillPrtDivCd, this._eraNameDispCd1, this._eraNameDispCd2, this._eraNameDispCd3, this._secMngDiv, this._goodsNoInpDiv, this._cnsTaxAutoCorrDiv, this._remainCntMngDiv, this._memoMoveDiv, this._remCntAutoDspDiv, this._ttlAmntDspRateDivCd, this._enterpriseName, this._updEmployeeName);
            //return new AllDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._totalAmountDispWayCd, this._defDspCustTtlDay, this._defDspCustClctMnyDay, this._defDspClctMnyMonthCd, this._iniDspPrslOrCorpCd, this._initDspDmDiv, this._defDspBillPrtDivCd, this._eraNameDispCd1, this._eraNameDispCd2, this._eraNameDispCd3, this._secMngDiv, this._goodsNoInpDiv, this._cnsTaxAutoCorrDiv, this._remainCntMngDiv, this._memoMoveDiv, this._remCntAutoDspDiv, this._ttlAmntDspRateDivCd, this._enterpriseName, this._updEmployeeName, this._defTtlBillOutput, this._defDtlBillOutput, this._defSlTtlBillOutput);  //DEL 2011/07/19
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            //return new AllDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._totalAmountDispWayCd, this._defDspCustTtlDay, this._defDspCustClctMnyDay, this._defDspClctMnyMonthCd, this._iniDspPrslOrCorpCd, this._initDspDmDiv, this._defDspBillPrtDivCd, this._eraNameDispCd1, this._eraNameDispCd2, this._eraNameDispCd3, this._secMngDiv, this._goodsNoInpDiv, this._cnsTaxAutoCorrDiv, this._remainCntMngDiv, this._memoMoveDiv, this._remCntAutoDspDiv, this._ttlAmntDspRateDivCd, this._enterpriseName, this._updEmployeeName, this._defTtlBillOutput, this._defDtlBillOutput, this._defSlTtlBillOutput, this._dtlCalcStckCntDsp);  //ADD 2011/07/19 //DEL 王君 2013/05/02 Redmine#35434
            return new AllDefSet(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._sectionCode, this._totalAmountDispWayCd, this._defDspCustTtlDay, this._defDspCustClctMnyDay, this._defDspClctMnyMonthCd, this._iniDspPrslOrCorpCd, this._initDspDmDiv, this._defDspBillPrtDivCd, this._eraNameDispCd1, this._eraNameDispCd2, this._eraNameDispCd3, this._secMngDiv, this._goodsNoInpDiv, this._cnsTaxAutoCorrDiv, this._remainCntMngDiv, this._memoMoveDiv, this._remCntAutoDspDiv, this._ttlAmntDspRateDivCd, this._enterpriseName, this._updEmployeeName, this._defTtlBillOutput, this._defDtlBillOutput, this._defSlTtlBillOutput, this._dtlCalcStckCntDsp, this._goodsStockMSTBootDiv);   //ADD 王君 2013/05/02 Redmine#35434
        }

        /// <summary>
        /// 全体初期値設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のAllDefSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AllDefSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(AllDefSet target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.SectionCode == target.SectionCode)
                 && (this.TotalAmountDispWayCd == target.TotalAmountDispWayCd)
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                && (this.CustomerDelChkDivCd == target.CustomerDelChkDivCd)
                && (this.CustCdAutoNumbering == target.CustCdAutoNumbering)
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                 && (this.DefDspCustTtlDay == target.DefDspCustTtlDay)
                 && (this.DefDspCustClctMnyDay == target.DefDspCustClctMnyDay)
                 && (this.DefDspClctMnyMonthCd == target.DefDspClctMnyMonthCd)
                 && (this.IniDspPrslOrCorpCd == target.IniDspPrslOrCorpCd)
                 && (this.InitDspDmDiv == target.InitDspDmDiv)
                 && (this.DefDspBillPrtDivCd == target.DefDspBillPrtDivCd)
                //&& (this.MemberInfoDispCd == target.MemberInfoDispCd)  // DEL 2008/06/04
                 && (this.EraNameDispCd1 == target.EraNameDispCd1)
                 && (this.EraNameDispCd2 == target.EraNameDispCd2)
                 && (this.EraNameDispCd3 == target.EraNameDispCd3)
                 && (this.SecMngDiv == target.SecMngDiv)
                 && (this.GoodsNoInpDiv == target.GoodsNoInpDiv)
                 && (this.CnsTaxAutoCorrDiv == target.CnsTaxAutoCorrDiv)
                 && (this.RemainCntMngDiv == target.RemainCntMngDiv)
                 && (this.MemoMoveDiv == target.MemoMoveDiv)
                 && (this.RemCntAutoDspDiv == target.RemCntAutoDspDiv)
                 && (this.TtlAmntDspRateDivCd == target.TtlAmntDspRateDivCd)
                 && (this.EnterpriseName == target.EnterpriseName)
                // --- UPD  大矢睦美  2010/01/18 ---------->>>>>
                //&& (this.UpdEmployeeName == target.UpdEmployeeName));
                 && (this.UpdEmployeeName == target.UpdEmployeeName)
                 && (this.DefTtlBillOutput == target.DefTtlBillOutput)
                 && (this.DefDtlBillOutput == target.DefDtlBillOutput)
                 //&& (this.DefSlTtlBillOutput == target.DefSlTtlBillOutput)); //DEL 2011/07/19
                // --- UPD  大矢睦美  2010/01/18 ----------<<<<<
                // ----- ADD 王君 2013/05/02 Redmine#35434 ----->>>>>
                && (this.GoodsStockMSTBootDiv == target.GoodsStockMSTBootDiv)
                // ----- ADD 王君 2013/05/02 Redmine#35434 -----<<<<<
                //ADD 2011/07/19
                && (this.DefSlTtlBillOutput == target.DefSlTtlBillOutput)
                && (this.DtlCalcStckCntDsp == target.DtlCalcStckCntDsp));
                //ADD 2011/07/19
        }

        /// <summary>
        /// 全体初期値設定マスタ比較処理
        /// </summary>
        /// <param name="allDefSet1">
        ///                    比較するAllDefSetクラスのインスタンス
        /// </param>
        /// <param name="allDefSet2">比較するAllDefSetクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AllDefSetクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2013/05/02 王君</br>
        /// <br>管理番号　       :   10901273-00 2013/06/18配信分　
        /// 　　　　　　　　　   :   Redmine#35434 商品在庫マスタ起動区分の追加</br>
        /// </remarks>
        public static bool Equals(AllDefSet allDefSet1, AllDefSet allDefSet2)
        {
            return ((allDefSet1.CreateDateTime == allDefSet2.CreateDateTime)
                 && (allDefSet1.UpdateDateTime == allDefSet2.UpdateDateTime)
                 && (allDefSet1.EnterpriseCode == allDefSet2.EnterpriseCode)
                 && (allDefSet1.FileHeaderGuid == allDefSet2.FileHeaderGuid)
                 && (allDefSet1.UpdEmployeeCode == allDefSet2.UpdEmployeeCode)
                 && (allDefSet1.UpdAssemblyId1 == allDefSet2.UpdAssemblyId1)
                 && (allDefSet1.UpdAssemblyId2 == allDefSet2.UpdAssemblyId2)
                 && (allDefSet1.LogicalDeleteCode == allDefSet2.LogicalDeleteCode)
                 && (allDefSet1.SectionCode == allDefSet2.SectionCode)
                 && (allDefSet1.TotalAmountDispWayCd == allDefSet2.TotalAmountDispWayCd)
                /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
                && (allDefSet1.CustomerDelChkDivCd == allDefSet2.CustomerDelChkDivCd)
                && (allDefSet1.CustCdAutoNumbering == allDefSet2.CustCdAutoNumbering)
                   --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
                 && (allDefSet1.DefDspCustTtlDay == allDefSet2.DefDspCustTtlDay)
                 && (allDefSet1.DefDspCustClctMnyDay == allDefSet2.DefDspCustClctMnyDay)
                 && (allDefSet1.DefDspClctMnyMonthCd == allDefSet2.DefDspClctMnyMonthCd)
                 && (allDefSet1.IniDspPrslOrCorpCd == allDefSet2.IniDspPrslOrCorpCd)
                 && (allDefSet1.InitDspDmDiv == allDefSet2.InitDspDmDiv)
                 && (allDefSet1.DefDspBillPrtDivCd == allDefSet2.DefDspBillPrtDivCd)
                //&& (allDefSet1.MemberInfoDispCd == allDefSet2.MemberInfoDispCd)  // DEL 2008/06/04
                 && (allDefSet1.EraNameDispCd1 == allDefSet2.EraNameDispCd1)
                 && (allDefSet1.EraNameDispCd2 == allDefSet2.EraNameDispCd2)
                 && (allDefSet1.EraNameDispCd3 == allDefSet2.EraNameDispCd3)
                 && (allDefSet1.SecMngDiv == allDefSet2.SecMngDiv)
                 && (allDefSet1.GoodsNoInpDiv == allDefSet2.GoodsNoInpDiv)
                 && (allDefSet1.CnsTaxAutoCorrDiv == allDefSet2.CnsTaxAutoCorrDiv)
                 && (allDefSet1.RemainCntMngDiv == allDefSet2.RemainCntMngDiv)
                 && (allDefSet1.MemoMoveDiv == allDefSet2.MemoMoveDiv)
                 && (allDefSet1.RemCntAutoDspDiv == allDefSet2.RemCntAutoDspDiv)
                 && (allDefSet1.TtlAmntDspRateDivCd == allDefSet2.TtlAmntDspRateDivCd)
                 && (allDefSet1.EnterpriseName == allDefSet2.EnterpriseName)
                // --- UPD  大矢睦美  2010/01/18 ---------->>>>>
                //&& (allDefSet1.UpdEmployeeName == allDefSet2.UpdEmployeeName));
                 && (allDefSet1.UpdEmployeeName == allDefSet2.UpdEmployeeName)
                 && (allDefSet1.DefTtlBillOutput == allDefSet2.DefTtlBillOutput)
                 && (allDefSet1.DefDtlBillOutput == allDefSet2.DefDtlBillOutput)
                 //&& (allDefSet1.DefSlTtlBillOutput == allDefSet2.DefSlTtlBillOutput)); //DEL 2011/07/19
                // --- UPD  大矢睦美  2010/01/18 ----------<<<<<
                 && (allDefSet1.GoodsStockMSTBootDiv == allDefSet2.GoodsStockMSTBootDiv) //  ADD 王君 2013/05/02 Redmine#35434 
                //ADD 2011/07/19
                && (allDefSet1.DefSlTtlBillOutput == allDefSet2.DefSlTtlBillOutput)
                && (allDefSet1.DtlCalcStckCntDsp == allDefSet2.DtlCalcStckCntDsp));
                //ADD 2011/07/19
        }
        /// <summary>
        /// 全体初期値設定マスタ比較処理
        /// </summary>
        /// <param name="target">比較対象のAllDefSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AllDefSetクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2013/05/02 王君</br>
        /// <br>管理番号　       :   10901273-00 2013/06/18配信分　
        /// 　　　　　　　　　   :   Redmine#35434 商品在庫マスタ起動区分の追加</br>
        /// </remarks>
        public ArrayList Compare(AllDefSet target)
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
            if (this.SectionCode != target.SectionCode) resList.Add("SectionCode");
            if (this.TotalAmountDispWayCd != target.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (this.CustomerDelChkDivCd != target.CustomerDelChkDivCd) resList.Add("CustomerDelChkDivCd");
            if (this.CustCdAutoNumbering != target.CustCdAutoNumbering) resList.Add("CustCdAutoNumbering");
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            if (this.DefDspCustTtlDay != target.DefDspCustTtlDay) resList.Add("DefDspCustTtlDay");
            if (this.DefDspCustClctMnyDay != target.DefDspCustClctMnyDay) resList.Add("DefDspCustClctMnyDay");
            if (this.DefDspClctMnyMonthCd != target.DefDspClctMnyMonthCd) resList.Add("DefDspClctMnyMonthCd");
            if (this.IniDspPrslOrCorpCd != target.IniDspPrslOrCorpCd) resList.Add("IniDspPrslOrCorpCd");
            if (this.InitDspDmDiv != target.InitDspDmDiv) resList.Add("InitDspDmDiv");
            if (this.DefDspBillPrtDivCd != target.DefDspBillPrtDivCd) resList.Add("DefDspBillPrtDivCd");
            //if (this.MemberInfoDispCd != target.MemberInfoDispCd) resList.Add("MemberInfoDispCd");  // DEL 2008/06/04
            if (this.EraNameDispCd1 != target.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (this.EraNameDispCd2 != target.EraNameDispCd2) resList.Add("EraNameDispCd2");
            if (this.EraNameDispCd3 != target.EraNameDispCd3) resList.Add("EraNameDispCd3");
            if (this.SecMngDiv != target.SecMngDiv) resList.Add("SecMngDiv");
            if (this.GoodsNoInpDiv != target.GoodsNoInpDiv) resList.Add("GoodsNoInpDiv");
            if (this.CnsTaxAutoCorrDiv != target.CnsTaxAutoCorrDiv) resList.Add("CnsTaxAutoCorrDiv");
            if (this.RemainCntMngDiv != target.RemainCntMngDiv) resList.Add("RemainCntMngDiv");
            if (this.MemoMoveDiv != target.MemoMoveDiv) resList.Add("MemoMoveDiv");
            if (this.RemCntAutoDspDiv != target.RemCntAutoDspDiv) resList.Add("RemCntAutoDspDiv");
            if (this.TtlAmntDspRateDivCd != target.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (this.EnterpriseName != target.EnterpriseName) resList.Add("EnterpriseName");
            if (this.UpdEmployeeName != target.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            if (this.DefTtlBillOutput != target.DefTtlBillOutput) resList.Add("DefTtlBillOutput");
            if (this.DefDtlBillOutput != target.DefDtlBillOutput) resList.Add("DefDtlBillOutput");
            if (this.DefSlTtlBillOutput != target.DefSlTtlBillOutput) resList.Add("DefSlTtlBillOutput");
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            if (this.DtlCalcStckCntDsp != target.DtlCalcStckCntDsp) resList.Add("DtlCalcStckCntDsp"); //ADD 2011/07/19
            if (this.GoodsStockMSTBootDiv != target.GoodsStockMSTBootDiv) resList.Add("GoodsStockMSTBootDiv"); // ADD 王君 2013/05/02 Redmine#35434

            return resList;
        }

        /// <summary>
        /// 全体初期値設定マスタ比較処理
        /// </summary>
        /// <param name="allDefSet1">比較するAllDefSetクラスのインスタンス</param>
        /// <param name="allDefSet2">比較するAllDefSetクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   AllDefSetクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// <br>Update Note      :   2013/05/02 王君</br>
        /// <br>管理番号　       :   10901273-00 2013/06/18配信分　
        /// 　　　　　　　　　   :   Redmine#35434 商品在庫マスタ起動区分の追加</br>
        /// </remarks>
        public static ArrayList Compare(AllDefSet allDefSet1, AllDefSet allDefSet2)
        {
            ArrayList resList = new ArrayList();
            if (allDefSet1.CreateDateTime != allDefSet2.CreateDateTime) resList.Add("CreateDateTime");
            if (allDefSet1.UpdateDateTime != allDefSet2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (allDefSet1.EnterpriseCode != allDefSet2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (allDefSet1.FileHeaderGuid != allDefSet2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (allDefSet1.UpdEmployeeCode != allDefSet2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (allDefSet1.UpdAssemblyId1 != allDefSet2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (allDefSet1.UpdAssemblyId2 != allDefSet2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (allDefSet1.LogicalDeleteCode != allDefSet2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (allDefSet1.SectionCode != allDefSet2.SectionCode) resList.Add("SectionCode");
            if (allDefSet1.TotalAmountDispWayCd != allDefSet2.TotalAmountDispWayCd) resList.Add("TotalAmountDispWayCd");
            /* --- DEL 2008/06/04 --------------------------------------------------------------------->>>>>
            if (allDefSet1.CustomerDelChkDivCd != allDefSet2.CustomerDelChkDivCd) resList.Add("CustomerDelChkDivCd");
            if (allDefSet1.CustCdAutoNumbering != allDefSet2.CustCdAutoNumbering) resList.Add("CustCdAutoNumbering");
               --- DEL 2008/06/04 ---------------------------------------------------------------------<<<<<*/
            if (allDefSet1.DefDspCustTtlDay != allDefSet2.DefDspCustTtlDay) resList.Add("DefDspCustTtlDay");
            if (allDefSet1.DefDspCustClctMnyDay != allDefSet2.DefDspCustClctMnyDay) resList.Add("DefDspCustClctMnyDay");
            if (allDefSet1.DefDspClctMnyMonthCd != allDefSet2.DefDspClctMnyMonthCd) resList.Add("DefDspClctMnyMonthCd");
            if (allDefSet1.IniDspPrslOrCorpCd != allDefSet2.IniDspPrslOrCorpCd) resList.Add("IniDspPrslOrCorpCd");
            if (allDefSet1.InitDspDmDiv != allDefSet2.InitDspDmDiv) resList.Add("InitDspDmDiv");
            if (allDefSet1.DefDspBillPrtDivCd != allDefSet2.DefDspBillPrtDivCd) resList.Add("DefDspBillPrtDivCd");
            //if (allDefSet1.MemberInfoDispCd != allDefSet2.MemberInfoDispCd) resList.Add("MemberInfoDispCd");  // DEL 2008/06/04
            if (allDefSet1.EraNameDispCd1 != allDefSet2.EraNameDispCd1) resList.Add("EraNameDispCd1");
            if (allDefSet1.EraNameDispCd2 != allDefSet2.EraNameDispCd2) resList.Add("EraNameDispCd2");
            if (allDefSet1.EraNameDispCd3 != allDefSet2.EraNameDispCd3) resList.Add("EraNameDispCd3");
            if (allDefSet1.SecMngDiv != allDefSet2.SecMngDiv) resList.Add("SecMngDiv");
            if (allDefSet1.GoodsNoInpDiv != allDefSet2.GoodsNoInpDiv) resList.Add("GoodsNoInpDiv");


            if (allDefSet1.CnsTaxAutoCorrDiv != allDefSet2.CnsTaxAutoCorrDiv) resList.Add("CnsTaxAutoCorrDiv");
            if (allDefSet1.RemainCntMngDiv != allDefSet2.RemainCntMngDiv) resList.Add("RemainCntMngDiv");
            if (allDefSet1.MemoMoveDiv != allDefSet2.MemoMoveDiv) resList.Add("MemoMoveDiv");
            if (allDefSet1.RemCntAutoDspDiv != allDefSet2.RemCntAutoDspDiv) resList.Add("RemCntAutoDspDiv");
            if (allDefSet1.TtlAmntDspRateDivCd != allDefSet2.TtlAmntDspRateDivCd) resList.Add("TtlAmntDspRateDivCd");
            if (allDefSet1.EnterpriseName != allDefSet2.EnterpriseName) resList.Add("EnterpriseName");
            if (allDefSet1.UpdEmployeeName != allDefSet2.UpdEmployeeName) resList.Add("UpdEmployeeName");
            // --- ADD  大矢睦美  2010/01/18 ---------->>>>>
            if (allDefSet1.DefTtlBillOutput != allDefSet2.DefTtlBillOutput) resList.Add("DefTtlBillOutput");
            if (allDefSet1.DefDtlBillOutput != allDefSet2.DefDtlBillOutput) resList.Add("DefDtlBillOutput");
            if (allDefSet1.DefSlTtlBillOutput != allDefSet2.DefSlTtlBillOutput) resList.Add("DefSlTtlBillOutput");
            // --- ADD  大矢睦美  2010/01/18 ----------<<<<<
            if (allDefSet1.DtlCalcStckCntDsp != allDefSet2.DtlCalcStckCntDsp) resList.Add("DtlCalcStckCntDsp"); //ADD 2011/07/19
            if (allDefSet1.GoodsStockMSTBootDiv != allDefSet2.GoodsStockMSTBootDiv) resList.Add("GoodsStockMSTBootDiv"); // ADD 王君 2013/05/02 Redmine#35434

            return resList;
        }
    }
}
