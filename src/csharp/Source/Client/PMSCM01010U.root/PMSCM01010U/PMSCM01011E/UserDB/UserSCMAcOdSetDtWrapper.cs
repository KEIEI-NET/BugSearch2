//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : qijh  
// 作 成 日  2013/02/27  修正内容 : Redmine#34752
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/09  修正内容 : SCM障害№10470対応・商品規格・特記事項追加
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢 憲弘
// 修 正 日  2015/01/19  修正内容 : SCM高速化 PMNS対応 項目追加 メーカー希望小売価格、オープン価格区分
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30745 吉岡
// 修 正 日  2015/02/10  修正内容 : SCM高速化 回答納期区分対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30746 高川 悟
// 修 正 日  2015/02/20  修正内容 : SCM高速化 C向け種別・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/02/27  修正内容 : SCM高速化 セット品に優良設定詳細コード２、優良設定詳細名称、在庫状況区分追加
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.UIData
{

    using RecordType = Broadleaf.Application.Remoting.ParamData.SCMAcOdSetDtWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdSetDt;

    /// <summary>
    /// ユーザーDB SCM受注セット部品データのラッパークラス（お約束）
    /// </summary>
    /// <remarks>
    /// <br>Update Note      :   2018/04/16 田建委</br>
    /// <br>管理番号         :   11470007-00</br>
    /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
    /// </remarks>
    public abstract partial class UserSCMAcOdSetDtWrapper : ISCMAcOdSetDtRecord
    {
        #region <Override>

        /// <summary>
        /// 等しいか判断します。
        /// </summary>
        /// <param name="obj">オブジェクト</param>
        /// <returns><c>true</c> :等しいです。<br/><c>false</c>:等しくありません。</returns>
        public override bool Equals(object obj)
        {
            return RealRecord.Equals(obj);
        }

        /// <summary>
        /// ハッシュコードを取得します。
        /// </summary>
        /// <returns>ハッシュコード</returns>
        public override int GetHashCode()
        {
            return RealRecord.GetHashCode();
        }

        /// <summary>
        /// 文字列に変換します。
        /// </summary>
        /// <returns>文字列</returns>
        public override string ToString()
        {
            return RealRecord.ToString();
        }

        #endregion // </Override>

        #region <Adaptee>

        /// <summary>本物のレコード</summary>
        private readonly RecordType _realRecord;
        /// <summary>本物のレコードを取得します。</summary>
        public RecordType RealRecord { get { return _realRecord; } }

        #endregion // </Adaptee>

        #region <Constructor>

        /// <summary>
        /// デフォルトコンストラクタ
        /// </summary>
        protected UserSCMAcOdSetDtWrapper() : this(new RecordType()) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        protected UserSCMAcOdSetDtWrapper(RecordType realRecord)
        {
            _realRecord = realRecord;
        }

        #endregion // </Constructor>

        #region <Automatic Code>

        #region <01.作成日時>

        /// <summary>作成日時を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        public DateTime CreateDateTime
        {
            get { return RealRecord.CreateDateTime; }
            set { RealRecord.CreateDateTime = value; }
        }

        #endregion </01.作成日時>

        #region <02.更新日時>

        /// <summary>更新日時を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        public DateTime UpdateDateTime
        {
            get { return RealRecord.UpdateDateTime; }
            set { RealRecord.UpdateDateTime = value; }
        }

        #endregion </02.更新日時>

        #region <03.企業コード>

        /// <summary>企業コードを取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        public string EnterpriseCode
        {
            get { return RealRecord.EnterpriseCode; }
            set { RealRecord.EnterpriseCode = value; }
        }

        #endregion </03.企業コード>

        #region <04.GUID>

        /// <summary>GUIDを取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        public Guid FileHeaderGuid
        {
            get { return RealRecord.FileHeaderGuid; }
            set { RealRecord.FileHeaderGuid = value; }
        }

        #endregion </04.GUID>

        #region <05.更新従業員コード>

        /// <summary>更新従業員コードを取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ</remarks>
        public string UpdEmployeeCode
        {
            get { return RealRecord.UpdEmployeeCode; }
            set { RealRecord.UpdEmployeeCode = value; }
        }

        #endregion </05.更新従業員コード>

        #region <06.更新アセンブリID1>

        /// <summary>更新アセンブリID1を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（UI側の更新アセンブリID+「:」+バージョン）</remarks>
        public string UpdAssemblyId1
        {
            get { return RealRecord.UpdAssemblyId1; }
            set { RealRecord.UpdAssemblyId1 = value; }
        }

        #endregion </06.更新アセンブリID1>

        #region <07.更新アセンブリID2>

        /// <summary>更新アセンブリID2を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ（Server側の更新アセンブリID+「:」+バージョン）</remarks>
        public string UpdAssemblyId2
        {
            get { return RealRecord.UpdAssemblyId2; }
            set { RealRecord.UpdAssemblyId2 = value; }
        }

        #endregion </07.更新アセンブリID2>

        #region <08.論理削除区分>

        /// <summary>論理削除区分を取得または設定します。</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        public int LogicalDeleteCode
        {
            get { return RealRecord.LogicalDeleteCode; }
            set { RealRecord.LogicalDeleteCode = value; }
        }

        #endregion </08.論理削除区分>

        #region <09.問合せ元企業コード>

        /// <summary>問合せ元企業コードを取得または設定します。</summary>
        public string InqOriginalEpCd
        {
            get { return RealRecord.InqOriginalEpCd; }
            set { RealRecord.InqOriginalEpCd = value; }
        }

        #endregion </09.問合せ元企業コード>

        #region <10.問合せ元拠点コード>

        /// <summary>問合せ元拠点コードを取得または設定します。</summary>
        public string InqOriginalSecCd
        {
            get { return RealRecord.InqOriginalSecCd; }
            set { RealRecord.InqOriginalSecCd = value; }
        }

        #endregion </10.問合せ元拠点コード>

        #region <11.問合せ先企業コード>

        /// <summary>問合せ先企業コードを取得または設定します。</summary>
        public string InqOtherEpCd
        {
            get { return RealRecord.InqOtherEpCd; }
            set { RealRecord.InqOtherEpCd = value; }
        }

        #endregion </11.問合せ先企業コード>

        #region <12.問合せ先拠点コード>

        /// <summary>問合せ先拠点コードを取得または設定します。</summary>
        public string InqOtherSecCd
        {
            get { return RealRecord.InqOtherSecCd; }
            set { RealRecord.InqOtherSecCd = value; }
        }

        #endregion </12.問合せ先拠点コード>

        #region <13.問合せ番号>

        /// <summary>問合せ番号を取得または設定します。</summary>
        public long InquiryNumber
        {
            get { return RealRecord.InquiryNumber; }
            set { RealRecord.InquiryNumber = value; }
        }

        #endregion </13.問合せ番号>

        #region <14.セット部品メーカーコード>

        /// <summary>セット部品メーカーコードを取得または設定します。</summary>
        public int SetPartsMkrCd
        {
            get { return RealRecord.SetPartsMkrCd; }
            set { RealRecord.SetPartsMkrCd = value; }
        }

        #endregion </14.セット部品メーカーコード>

        #region <15.セット部品番号>

        /// <summary>セット部品番号を取得または設定します。</summary>
        public string SetPartsNumber
        {
            get { return RealRecord.SetPartsNumber; }
            set { RealRecord.SetPartsNumber = value; }
        }

        #endregion </15.セット部品番号>

        #region <16.セット部品親子番号>

        /// <summary>セット部品親子番号を取得または設定します。</summary>
        public int SetPartsMainSubNo
        {
            get { return RealRecord.SetPartsMainSubNo; }
            set { RealRecord.SetPartsMainSubNo = value; }
        }

        #endregion </16.セット部品親子番号>

        #region <17.商品種別>

        /// <summary>商品種別を取得または設定します。</summary>
        /// <remarks>0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場</remarks>
        public int GoodsDivCd
        {
            get { return RealRecord.GoodsDivCd; }
            set { RealRecord.GoodsDivCd = value; }
        }

        #endregion </17.商品種別>

        #region <18.リサイクル部品種別>

        /// <summary>リサイクル部品種別を取得または設定します。</summary>
        /// <remarks>1:リビルド 2:中古</remarks>
        public int RecyclePrtKindCode
        {
            get { return RealRecord.RecyclePrtKindCode; }
            set { RealRecord.RecyclePrtKindCode = value; }
        }

        #endregion </18.リサイクル部品種別>

        #region <19.リサイクル部品種別名称>

        /// <summary>リサイクル部品種別名称を取得または設定します。</summary>
        public string RecyclePrtKindName
        {
            get { return RealRecord.RecyclePrtKindName; }
            set { RealRecord.RecyclePrtKindName = value; }
        }

        #endregion </19.リサイクル部品種別名称>

        #region <20.納品区分>

        /// <summary>納品区分を取得または設定します。</summary>
        /// <remarks>0:配送,1:引取</remarks>
        public int DeliveredGoodsDiv
        {
            get { return RealRecord.DeliveredGoodsDiv; }
            set { RealRecord.DeliveredGoodsDiv = value; }
        }

        #endregion </20.納品区分>

        #region <21.取扱区分>

        /// <summary>取扱区分を取得または設定します。</summary>
        /// <remarks>0:取り扱い品,1:納期確認中,2:未取り扱い品</remarks>
        public int HandleDivCode
        {
            get { return RealRecord.HandleDivCode; }
            set { RealRecord.HandleDivCode = value; }
        }

        #endregion </21.取扱区分>

        #region <22.商品形態>

        /// <summary>商品形態を取得または設定します。</summary>
        /// <remarks>1:部品,2:用品</remarks>
        public int GoodsShape
        {
            get { return RealRecord.GoodsShape; }
            set { RealRecord.GoodsShape = value; }
        }

        #endregion </22.商品形態>

        #region <23.納品確認区分>

        /// <summary>納品確認区分を取得または設定します。</summary>
        /// <remarks>0:未確認,1:確認</remarks>
        public int DelivrdGdsConfCd
        {
            get { return RealRecord.DelivrdGdsConfCd; }
            set { RealRecord.DelivrdGdsConfCd = value; }
        }

        #endregion </23.納品確認区分>

        #region <24.納品完了予定日>

        /// <summary>納品完了予定日を取得または設定します。</summary>
        /// <remarks>納品予定日付 YYYYMMDD</remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return RealRecord.DeliGdsCmpltDueDate; }
            set { RealRecord.DeliGdsCmpltDueDate = value; }
        }

        #endregion </24.納品完了予定日>

        #region <25.回答納期>

        /// <summary>回答納期を取得または設定します。</summary>
        public string AnswerDeliveryDate
        {
            get { return RealRecord.AnswerDeliveryDate; }
            set { RealRecord.AnswerDeliveryDate = value; }
        }

        #endregion </25.回答納期>

        #region <26.BL商品コード>

        /// <summary>BL商品コードを取得または設定します。</summary>
        public int BLGoodsCode
        {
            get { return RealRecord.BLGoodsCode; }
            set { RealRecord.BLGoodsCode = value; }
        }

        #endregion </26.BL商品コード>

        #region <27.BL商品コード枝番>

        /// <summary>BL商品コード枝番を取得または設定します。</summary>
        public int BLGoodsDrCode
        {
            get { return RealRecord.BLGoodsDrCode; }
            set { RealRecord.BLGoodsDrCode = value; }
        }

        #endregion </27.BL商品コード枝番>

        #region <28.問発商品名>

        /// <summary>問発商品名を取得または設定します。</summary>
        public string InqGoodsName
        {
            get { return RealRecord.InqGoodsName; }
            set { RealRecord.InqGoodsName = value; }
        }

        #endregion </28.問発商品名>

        #region <29.回答商品名>

        /// <summary>回答商品名を取得または設定します。</summary>
        public string AnsGoodsName
        {
            get { return RealRecord.AnsGoodsName; }
            set { RealRecord.AnsGoodsName = value; }
        }

        #endregion </29.回答商品名>

        #region <30.発注数>

        /// <summary>発注数を取得または設定します。</summary>
        public double SalesOrderCount
        {
            get { return RealRecord.SalesOrderCount; }
            set { RealRecord.SalesOrderCount = value; }
        }

        #endregion </30.発注数>

        #region <31.納品数>

        /// <summary>納品数を取得または設定します。</summary>
        public double DeliveredGoodsCount
        {
            get { return RealRecord.DeliveredGoodsCount; }
            set { RealRecord.DeliveredGoodsCount = value; }
        }

        #endregion </31.納品数>

        #region <32.商品番号>

        /// <summary>商品番号を取得または設定します。</summary>
        public string GoodsNo
        {
            get { return RealRecord.GoodsNo; }
            set { RealRecord.GoodsNo = value; }
        }

        #endregion </32.商品番号>

        #region <33.商品メーカーコード>

        /// <summary>商品メーカーコードを取得または設定します。</summary>
        public int GoodsMakerCd
        {
            get { return RealRecord.GoodsMakerCd; }
            set { RealRecord.GoodsMakerCd = value; }
        }

        #endregion </33.商品メーカーコード>

        #region <34.商品メーカー名称>

        /// <summary>商品メーカー名称を取得または設定します。</summary>
        public string GoodsMakerNm
        {
            get { return RealRecord.GoodsMakerNm; }
            set { RealRecord.GoodsMakerNm = value; }
        }

        #endregion </34.商品メーカー名称>

        #region <35.純正商品メーカーコード>

        /// <summary>純正商品メーカーコードを取得または設定します。</summary>
        public int PureGoodsMakerCd
        {
            get { return RealRecord.PureGoodsMakerCd; }
            set { RealRecord.PureGoodsMakerCd = value; }
        }

        #endregion </35.純正商品メーカーコード>

        #region <36.問発純正商品番号>

        /// <summary>問発純正商品番号を取得または設定します。</summary>
        public string InqPureGoodsNo
        {
            get { return RealRecord.InqPureGoodsNo; }
            set { RealRecord.InqPureGoodsNo = value; }
        }

        #endregion </36.問発純正商品番号>

        #region <37.回答純正商品番号>

        /// <summary>回答純正商品番号を取得または設定します。</summary>
        public string AnsPureGoodsNo
        {
            get { return RealRecord.AnsPureGoodsNo; }
            set { RealRecord.AnsPureGoodsNo = value; }
        }

        #endregion </37.回答純正商品番号>

        #region <38.定価>

        /// <summary>定価を取得または設定します。</summary>
        public long ListPrice
        {
            get { return RealRecord.ListPrice; }
            set { RealRecord.ListPrice = value; }
        }

        #endregion </38.定価>

        #region <39.単価>

        /// <summary>単価を取得または設定します。</summary>
        public long UnitPrice
        {
            get { return RealRecord.UnitPrice; }
            set { RealRecord.UnitPrice = value; }
        }

        #endregion </39.単価>

        #region <40.商品補足情報>

        /// <summary>商品補足情報を取得または設定します。</summary>
        /// <remarks>PSのＵＲＬ</remarks>
        public string GoodsAddInfo
        {
            get { return RealRecord.GoodsAddInfo; }
            set { RealRecord.GoodsAddInfo = value; }
        }

        #endregion </40.商品補足情報>

        #region <41.粗利額>

        /// <summary>粗利額を取得または設定します。</summary>
        public long RoughRrofit
        {
            get { return RealRecord.RoughRrofit; }
            set { RealRecord.RoughRrofit = value; }
        }

        #endregion </41.粗利額>

        #region <42.粗利率>

        /// <summary>粗利率を取得または設定します。</summary>
        public double RoughRate
        {
            get { return RealRecord.RoughRate; }
            set { RealRecord.RoughRate = value; }
        }

        #endregion </42.粗利率>

        #region <43.回答期限>

        /// <summary>回答期限を取得または設定します。</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime AnswerLimitDate
        {
            get { return RealRecord.AnswerLimitDate; }
            set { RealRecord.AnswerLimitDate = value; }
        }

        #endregion </43.回答期限>

        #region <44.備考(明細)>

        /// <summary>備考(明細)を取得または設定します。</summary>
        public string CommentDtl
        {
            get { return RealRecord.CommentDtl; }
            set { RealRecord.CommentDtl = value; }
        }

        #endregion </44.備考(明細)>

        #region <45.棚番>

        /// <summary>棚番を取得または設定します。</summary>
        public string ShelfNo
        {
            get { return RealRecord.ShelfNo; }
            set { RealRecord.ShelfNo = value; }
        }

        #endregion </45.棚番>

        #region <46.PM受注ステータス>

        /// <summary>PM受注ステータスを取得または設定します。</summary>
        /// <remarks>10:見積,20:受注,30:売上</remarks>
        public int PMAcptAnOdrStatus
        {
            get { return RealRecord.PMAcptAnOdrStatus; }
            set { RealRecord.PMAcptAnOdrStatus = value; }
        }

        #endregion </46.PM受注ステータス>

        #region <47.PM売上伝票番号>

        /// <summary>訂正区分を取得または設定します。</summary>
        public int PMSalesSlipNum
        {
            get { return RealRecord.PMSalesSlipNum; }
            set { RealRecord.PMSalesSlipNum = value; }
        }

        #endregion </47.PM売上伝票番号>

        #region <48.PM売上行番号>

        /// <summary>PM売上行番号を取得または設定します。</summary>
        public int PMSalesRowNo
        {
            get { return RealRecord.PMSalesRowNo; }
            set { RealRecord.PMSalesRowNo = value; }
        }

        #endregion </48.PM売上行番号>

        #region <49.PM倉庫コード>

        /// <summary>
        /// PM倉庫コードを取得または設定します。(※項目名の違いを吸収)
        /// </summary>
        public string PmWarehouseCd
        {
            get { return RealRecord.PmWarehouseCd; }
            set { RealRecord.PmWarehouseCd = value; }
        }

        #endregion </49.PM倉庫コード>

        #region <50.PM倉庫名称>

        /// <summary>
        /// PM倉庫名称を取得または設定します。(※項目名の違いを吸収)
        /// </summary>
        public string PmWarehouseName
        {
            get { return RealRecord.PmWarehouseName; }
            set { RealRecord.PmWarehouseName = value; }
        }

        #endregion </50.PM倉庫名称>

        #region <51.PM棚番>

        /// <summary>
        /// PM棚番を取得または設定します。(※項目名の違いを吸収)
        /// </summary>
        public string PmShelfNo
        {
            get { return RealRecord.PmShelfNo; }
            set { RealRecord.PmShelfNo = value; }
        }

        #endregion </51.PM棚番>

        #region <52.PM現在個数>

        /// <summary>PM現在個数を取得または設定します。</summary>
        public double PmPrsntCount
        {
            get { return RealRecord.PmPrsntCount; }
            set { RealRecord.PmPrsntCount = value; }
        }

        #endregion </52.PM現在個数>

        // ------------ ADD 2013/02/27 qijh #34752 ---------- >>>>>>
        #region <53.PM主管倉庫コード>
        /// <summary>
        /// PM主管倉庫コードを取得または設定します。
        /// </summary>
        public string PmMainMngWarehouseCd
        {
            get { return RealRecord.PmMainMngWarehouseCd; }
            set { RealRecord.PmMainMngWarehouseCd = value; }
        }
        #endregion </53.PM主管倉庫コード>

        #region <54.PM主管倉庫名称>
        /// <summary>
        /// PM主管倉庫名称を取得または設定します。
        /// </summary>
        public string PmMainMngWarehouseName
        {
            get { return RealRecord.PmMainMngWarehouseName; }
            set { RealRecord.PmMainMngWarehouseName = value; }
        }
        #endregion </54.PM主管倉庫名称>

        #region <55.PM主管棚番>
        /// <summary>
        /// PM主管棚番を取得または設定します。
        /// </summary>
        public string PmMainMngShelfNo
        {
            get { return RealRecord.PmMainMngShelfNo; }
            set { RealRecord.PmMainMngShelfNo = value; }
        }
        #endregion </55.PM主管棚番>

        #region <56.PM主管現在個数>
        /// <summary>
        /// PM主管現在個数を取得または設定します。
        /// </summary>
        public double PmMainMngPrsntCount
        {
            get { return RealRecord.PmMainMngPrsntCount; }
            set { RealRecord.PmMainMngPrsntCount = value; }
        }
        #endregion </56.PM主管現在個数>
        // ------------ ADD 2013/02/27 qijh #34752 ---------- <<<<<<

        // ADD 2013/05/09 SCM障害№10470対応 ----------------------------------------->>>>>
        #region <57.商品規格・特記事項>

        /// <summary>商品規格・特記事項を取得または設定します。</summary>
        public string GoodsSpclInstruction
        {
            get { return RealRecord.GoodsSpclInstruction; }
            set { RealRecord.GoodsSpclInstruction = value; }
        }

        #endregion </53.商品規格・特記事項>
        // ADD 2013/05/09 SCM障害№10470対応 -----------------------------------------<<<<<

        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// <summary> メーカー希望小売価格を取得または設定します。 </summary>
        public Int64 MkrSuggestRtPric
        {
            get { return RealRecord.MkrSuggestRtPric; }
            set { RealRecord.MkrSuggestRtPric = value; }
        }

        /// <summary> オープン価格区分を取得または設定します。 </summary>
        public Int32 OpenPriceDiv
        {
            get { return RealRecord.OpenPriceDiv; }
            set { RealRecord.OpenPriceDiv = value; }
        }
        // ADD 2015/01/19 豊沢 SCM高速化 PMNS対応 ---------------------------------<<<<<
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary> 回答納期区分を取得または設定します。 </summary>
        public Int16 AnsDeliDateDiv
        {
            get { return RealRecord.AnsDeliDateDiv; }
            set { RealRecord.AnsDeliDateDiv = value; }
        }
        // ADD 2015/02/10 吉岡 SCM高速化 回答納期区分対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ---------->>>>>>>>>>
        /// <summary>商品規格・特記事項(工場向け)を取得または設定します。</summary>
        public string GoodsSpecialNtForFac
        {
            get { return RealRecord.GoodsSpecialNtForFac; }
            set { RealRecord.GoodsSpecialNtForFac = value; }
        }

        /// <summary>商品規格・特記事項(カーオーナー向け)を取得または設定します。</summary>
        public string GoodsSpecialNtForCOw
        {
            get { return RealRecord.GoodsSpecialNtForCOw; }
            set { RealRecord.GoodsSpecialNtForCOw = value; }
        }

        /// <summary>優良設定詳細名称２(工場向け)を取得または設定します。</summary>
        public string PrmSetDtlName2ForFac
        {
            get { return RealRecord.PrmSetDtlName2ForFac; }
            set { RealRecord.PrmSetDtlName2ForFac = value; }
        }

        /// <summary>優良設定詳細名称２(カーオーナー向け)を取得または設定します。</summary>
        public string PrmSetDtlName2ForCOw
        {
            get { return RealRecord.PrmSetDtlName2ForCOw; }
            set { RealRecord.PrmSetDtlName2ForCOw = value; }
        }
        // 2015/02/20 ADD TAKAGAWA SCM高速化 C向け種別・特記事項対応 ----------<<<<<<<<<<

        // ADD 2015/02/27 SCM高速化 C向け種別対応 -------------------------------->>>>>
        /// <summary>優良設定詳細コード２を取得または設定します。</summary>
        public int PrmSetDtlNo2
        {
            get { return RealRecord.PrmSetDtlNo2; }
            set { RealRecord.PrmSetDtlNo2 = value; }
        }
        /// <summary>優良設定詳細名称２を取得または設定します。</summary>
        public string PrmSetDtlName2
        {
            get { return RealRecord.PrmSetDtlName2; }
            set { RealRecord.PrmSetDtlName2 = value; }
        }
        /// <summary>在庫状況区分を取得または設定します。</summary>
        public short StockStatusDiv
        {
            get { return RealRecord.StockStatusDiv; }
            set { RealRecord.StockStatusDiv = value; }
        }
        // ADD 2015/02/27 SCM高速化 C向け種別対応 --------------------------------<<<<<

        // ADD 2018/04/16 田建委 新BLコード対応 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>問発BL統一部品コード(スリーコード版)を取得または設定します。</summary>
        public string InqBlUtyPtThCd
        {
            get { return RealRecord.InqBlUtyPtThCd; }
            set { RealRecord.InqBlUtyPtThCd = value; }
        }

        /// <summary>問発BL統一部品サブコードを取得または設定します。</summary>
        public Int32 InqBlUtyPtSbCd
        {
            get { return RealRecord.InqBlUtyPtSbCd; }
            set { RealRecord.InqBlUtyPtSbCd = value; }
        }

        /// <summary>回答BL統一部品コード(スリーコード版)を取得または設定します。</summary>
        public string AnsBlUtyPtThCd
        {
            get { return RealRecord.AnsBlUtyPtThCd; }
            set { RealRecord.AnsBlUtyPtThCd = value; }
        }

        /// <summary>回答BL統一部品サブコードを取得または設定します。</summary>
        public Int32 AnsBlUtyPtSbCd
        {
            get { return RealRecord.AnsBlUtyPtSbCd; }
            set { RealRecord.AnsBlUtyPtSbCd = value; }
        }

        /// <summary>回答BL商品コードを取得または設定します。</summary>
        public Int32 AnsBLGoodsCode
        {
            get { return RealRecord.AnsBLGoodsCode; }
            set { RealRecord.AnsBLGoodsCode = value; }
        }

        /// <summary>回答BL商品コード枝番を取得または設定します。</summary>
        public Int32 AnsBLGoodsDrCode
        {
            get { return RealRecord.AnsBLGoodsDrCode; }
            set { RealRecord.AnsBLGoodsDrCode = value; }
        }
        // ADD 2018/04/16 田建委 新BLコード対応 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

#endregion // </Automatic Code>

    }
}

