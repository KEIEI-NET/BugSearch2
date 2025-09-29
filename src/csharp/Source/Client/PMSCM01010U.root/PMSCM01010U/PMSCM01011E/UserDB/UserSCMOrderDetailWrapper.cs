//****************************************************************************//
// システム         : 自働回答処理
// プログラム名称   : 自働回答処理アクセス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2009/05/29  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2010/05/26  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/09  修正内容 :テーブルレイアウト変更対応(明細取込区分の追加)
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018　鈴木 正臣
// 作 成 日  2011/05/23  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : LDNS wangqx
// 作 成 日  2011/08/08  修正内容 : テーブルレイアウト変更対応
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 30517 夏野 駿希
// 作 成 日  2012/01/16  修正内容 : SCM改良対応・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡 孝憲
// 作 成 日  2012/04/12  修正内容 : 障害№170 PS管理番号項目追加
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20073 西 毅
// 作 成 日  2012/05/30  修正内容 : SCM改良対応・自動見積部品コード
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡
// 作 成 日  2013/05/08  修正内容 : 2013/06/18配信　SCM障害№10308,№10528
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 30745 吉岡
// 作 成 日  2013/05/15  修正内容 : 2013/06/18配信　SCM障害№10410
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 修 正 日  2014/06/04  修正内容 : SCM仕掛一覧№10659対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2014/12/19  修正内容 : SCM高速化 PMNS対応 項目追加　貸出区分、メーカー希望小売価格、オープン価格区分
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢 憲弘
// 修 正 日  2015/01/19  修正内容 : リコメンド対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上 千加子
// 修 正 日  2015/01/30  修正内容 : SCM高速化 生産年式、車台番号対応　項目追加　型式別部品採用年月、型式別部品廃止年月、型式別部品採用車台番号、型式別部品廃止車台番号
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30745 吉岡
// 修 正 日  2015/02/10  修正内容 : SCM高速化 回答納期区分対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30746 高川 悟
// 修 正 日  2015/02/20  修正内容 : SCM高速化 C向け種別・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  11470007-00 作成担当 : 田建委
// 修 正 日  2018/04/16  修正内容 : SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.UIData
{
    using RecordType    = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
    using RecordTypeWeb = Broadleaf.Application.UIData.ScmOdDtInq;

    /// <summary>
    /// ユーザーDB SCM受注明細データ(問合せ・発注)のラッパークラス（お約束）
    /// </summary>
    /// <remarks>
    /// <br>Update Note      :   2018/04/16 田建委</br>
    /// <br>管理番号         :   11470007-00</br>
    /// <br>                 :   SFからの問合せ・発注のデータに新BLコード、新BLサブコード項目追加</br>
    /// </remarks>
    public abstract partial class UserSCMOrderDetailWrapper : ISCMOrderDetailRecord
    {
        #region <ICloneable Member>

        ///// <summary>
        ///// ディープコピーを行います。
        ///// </summary>
        ///// <returns>コピーインスタンス</returns>
        //public object Clone()
        //{
        //    return RealRecord.Clone();
        //}

        #endregion // <IClonable Member>

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
        protected UserSCMOrderDetailWrapper() : this(new RecordType()) { }

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="realRecord">本物のレコード</param>
        protected UserSCMOrderDetailWrapper(RecordType realRecord)
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

        #region <14.更新年月日>

        /// <summary>更新年月日を取得または設定します。</summary>
        /// <remarks>YYYYMMDD</remarks>
        public DateTime UpdateDate
        {
            get { return RealRecord.UpdateDate; }
            set { RealRecord.UpdateDate = value; }
        }

        #endregion </14.更新年月日>

        #region <15.更新時分秒ミリ秒>

        /// <summary>更新時分秒ミリ秒を取得または設定します。</summary>
        /// <remarks>HHMMSSXXX</remarks>
        public int UpdateTime
        {
            get { return RealRecord.UpdateTime; }
            set { RealRecord.UpdateTime = value; }
        }

        #endregion </15.更新時分秒ミリ秒>

        #region <16.問合せ行番号>

        /// <summary>問合せ行番号を取得または設定します。</summary>
        public int InqRowNumber
        {
            get { return RealRecord.InqRowNumber; }
            set { RealRecord.InqRowNumber = value; }
        }

        #endregion </16.問合せ行番号>

        #region <17.問合せ行番号枝番>

        /// <summary>問合せ行番号枝番を取得または設定します。</summary>
        public int InqRowNumDerivedNo
        {
            get { return RealRecord.InqRowNumDerivedNo; }
            set { RealRecord.InqRowNumDerivedNo = value; }
        }

        #endregion </17.問合せ行番号枝番>

        #region <18.問合せ元明細識別GUID>

        /// <summary>問合せ元明細識別GUIDを取得または設定します。</summary>
        public Guid InqOrgDtlDiscGuid
        {
            get { return RealRecord.InqOrgDtlDiscGuid; }
            set { RealRecord.InqOrgDtlDiscGuid = value; }
        }

        #endregion </18.問合せ元明細識別GUID>

        #region <19.問合せ先明細識別GUID>

        /// <summary>問合せ先明細識別GUIDを取得または設定します。</summary>
        /// <remarks>回答データの場合有効、問合せ／発注元の明細GUIDを設定</remarks>
        public Guid InqOthDtlDiscGuid
        {
            get { return RealRecord.InqOthDtlDiscGuid; }
            set { RealRecord.InqOthDtlDiscGuid = value; }
        }

        #endregion </19.問合せ先明細識別GUID>

        #region <20.商品種別>

        /// <summary>商品種別を取得または設定します。</summary>
        /// <remarks>0:純正部品 1:優良部品 2:リサイクル部品 3:平均相場</remarks>
        public int GoodsDivCd
        {
            get { return RealRecord.GoodsDivCd; }
            set { RealRecord.GoodsDivCd = value; }
        }

        #endregion </20.商品種別>

        #region <21.リサイクル部品種別>

        /// <summary>リサイクル部品種別を取得または設定します。</summary>
        /// <remarks>1:リビルド 2:中古</remarks>
        public int RecyclePrtKindCode
        {
            get { return RealRecord.RecyclePrtKindCode; }
            set { RealRecord.RecyclePrtKindCode = value; }
        }

        #endregion </21.リサイクル部品種別>

        #region <22.リサイクル部品種別名称>

        /// <summary>リサイクル部品種別名称を取得または設定します。</summary>
        public string RecyclePrtKindName
        {
            get { return RealRecord.RecyclePrtKindName; }
            set { RealRecord.RecyclePrtKindName = value; }
        }

        #endregion </22.リサイクル部品種別名称>

        #region <23.納品区分>

        /// <summary>納品区分を取得または設定します。</summary>
        /// <remarks>0:配送,1:引取</remarks>
        public int DeliveredGoodsDiv
        {
            get { return RealRecord.DeliveredGoodsDiv; }
            set { RealRecord.DeliveredGoodsDiv = value; }
        }

        #endregion </23.納品区分>

        #region <24.取扱区分>

        /// <summary>取扱区分を取得または設定します。</summary>
        /// <remarks>0:取り扱い品,1:納期確認中,2:未取り扱い品</remarks>
        public int HandleDivCode
        {
            get { return RealRecord.HandleDivCode; }
            set { RealRecord.HandleDivCode = value; }
        }

        #endregion </24.取扱区分>

        #region <25.商品形態>

        /// <summary>商品形態を取得または設定します。</summary>
        /// <remarks>1:部品,2:用品</remarks>
        public int GoodsShape
        {
            get { return RealRecord.GoodsShape; }
            set { RealRecord.GoodsShape = value; }
        }

        #endregion </25.商品形態>

        #region <26.納品確認区分>

        /// <summary>納品確認区分を取得または設定します。</summary>
        /// <remarks>0:未確認,1:確認</remarks>
        public int DelivrdGdsConfCd
        {
            get { return RealRecord.DelivrdGdsConfCd; }
            set { RealRecord.DelivrdGdsConfCd = value; }
        }

        #endregion </26.納品確認区分>

        #region <27.納品完了予定日>

        /// <summary>納品完了予定日を取得または設定します。</summary>
        /// <remarks>納品予定日付 YYYYMMDD</remarks>
        public DateTime DeliGdsCmpltDueDate
        {
            get { return RealRecord.DeliGdsCmpltDueDate; }
            set { RealRecord.DeliGdsCmpltDueDate = value; }
        }

        #endregion </27.納品完了予定日>

        #region <28.回答納期>

        /// <summary>回答納期を取得または設定します。</summary>
        public string AnswerDeliveryDate
        {
            get { return RealRecord.AnswerDeliveryDate; }
            set { RealRecord.AnswerDeliveryDate = value; }
        }

        #endregion </28.回答納期>

        #region <29.BL商品コード>

        /// <summary>BL商品コードを取得または設定します。</summary>
        public int BLGoodsCode
        {
            get { return RealRecord.BLGoodsCode; }
            set { RealRecord.BLGoodsCode = value; }
        }

        #endregion </29.BL商品コード>

        #region <30.BL商品コード枝番>

        /// <summary>BL商品コード枝番を取得または設定します。</summary>
        public int BLGoodsDrCode
        {
            get { return RealRecord.BLGoodsDrCode; }
            set { RealRecord.BLGoodsDrCode = value; }
        }

        #endregion </30.BL商品コード枝番>

        //#region <31.商品名（カナ）>

        ///// <summary>商品名（カナ）を取得または設定します。</summary>
        //public string GoodsName
        //{
        //    get { return RealRecord.GoodsName; }
        //    set { RealRecord.GoodsName = value; }
        //}

        //#endregion </31.商品名（カナ）>

        #region <31.問発商品名>

        /// <summary>問発商品名を取得または設定します。</summary>
        public string InqGoodsName
        {
            get { return RealRecord.InqGoodsName; }
            set { RealRecord.InqGoodsName = value; }
        }

        #endregion </31.問発商品名>

        #region <31.回答商品名>

        /// <summary>回答商品名を取得または設定します。</summary>
        public string AnsGoodsName
        {
            get { return RealRecord.AnsGoodsName; }
            set { RealRecord.AnsGoodsName = value; }
        }

        #endregion </31.回答商品名>

        #region <32.発注数>

        /// <summary>発注数を取得または設定します。</summary>
        public double SalesOrderCount
        {
            get { return RealRecord.SalesOrderCount; }
            set { RealRecord.SalesOrderCount = value; }
        }

        #endregion </32.発注数>

        #region <33.納品数>

        /// <summary>納品数を取得または設定します。</summary>
        public double DeliveredGoodsCount
        {
            get { return RealRecord.DeliveredGoodsCount; }
            set { RealRecord.DeliveredGoodsCount = value; }
        }

        #endregion </33.納品数>

        #region <34.商品番号>

        /// <summary>商品番号を取得または設定します。</summary>
        public string GoodsNo
        {
            get { return RealRecord.GoodsNo; }
            set { RealRecord.GoodsNo = value; }
        }

        #endregion </34.商品番号>

        #region <35.商品メーカーコード>

        /// <summary>商品メーカーコードを取得または設定します。</summary>
        public int GoodsMakerCd
        {
            get { return RealRecord.GoodsMakerCd; }
            set { RealRecord.GoodsMakerCd = value; }
        }

        #endregion </35.商品メーカーコード>

        #region <36.商品メーカー名称>

        /// <summary>商品メーカー名称を取得または設定します。</summary>
        public string GoodsMakerNm
        {
            get { return RealRecord.GoodsMakerNm; }
            set { RealRecord.GoodsMakerNm = value; }
        }

        #endregion </36.商品メーカー名称>

        #region <37.純正商品メーカーコード>

        /// <summary>純正商品メーカーコードを取得または設定します。</summary>
        public int PureGoodsMakerCd
        {
            get { return RealRecord.PureGoodsMakerCd; }
            set { RealRecord.PureGoodsMakerCd = value; }
        }

        #endregion </37.純正商品メーカーコード>

        //#region <38.純正商品番号>

        ///// <summary>純正商品番号を取得または設定します。</summary>
        //public string PureGoodsNo
        //{
        //    get { return RealRecord.PureGoodsNo; }
        //    set { RealRecord.PureGoodsNo = value; }
        //}

        //#endregion </38.純正商品番号>

        #region <38.純正商品番号>

        /// <summary>純正商品番号を取得または設定します。</summary>
        public string InqPureGoodsNo
        {
            get { return RealRecord.InqPureGoodsNo; }
            set { RealRecord.InqPureGoodsNo = value; }
        }

        #endregion </38.純正商品番号>

        #region <38.回答純正商品番号>

        /// <summary>回答純正商品番号を取得または設定します。</summary>
        public string AnsPureGoodsNo
        {
            get { return RealRecord.AnsPureGoodsNo; }
            set { RealRecord.AnsPureGoodsNo = value; }
        }

        #endregion </38.回答純正商品番号>

        #region <39.定価>

        /// <summary>定価を取得または設定します。</summary>
        public long ListPrice
        {
            get { return RealRecord.ListPrice; }
            set { RealRecord.ListPrice = value; }
        }

        #endregion </39.定価>

        #region <40.単価>

        /// <summary>単価を取得または設定します。</summary>
        public long UnitPrice
        {
            get { return RealRecord.UnitPrice; }
            set { RealRecord.UnitPrice = value; }
        }

        #endregion </40.単価>

        #region <41.商品補足情報>

        /// <summary>商品補足情報を取得または設定します。</summary>
        public string GoodsAddInfo
        {
            get { return RealRecord.GoodsAddInfo; }
            set { RealRecord.GoodsAddInfo = value; }
        }

        #endregion </41.商品補足情報>

        #region <42.粗利額>

        /// <summary>粗利額を取得または設定します。</summary>
        public long RoughRrofit
        {
            get { return RealRecord.RoughRrofit; }
            set { RealRecord.RoughRrofit = value; }
        }

        #endregion </42.粗利額>

        #region <43.粗利率>

        /// <summary>粗利率を取得または設定します。</summary>
        public double RoughRate
        {
            get { return RealRecord.RoughRate; }
            set { RealRecord.RoughRate = value; }
        }

        #endregion </43.粗利率>

        #region <44.回答期限>

        ///// <summary>回答期限を取得または設定します。</summary>
        ///// <remarks>YYYYMMDD</remarks>
        //public DateTime AnswerLimitDate
        //{
        //    get { return RealRecord.AnswerLimitDate; }
        //    set { RealRecord.AnswerLimitDate = value; }
        //}

        #endregion </44.回答期限>

        #region <45.備考(明細)>

        /// <summary>備考(明細)を取得または設定します。</summary>
        public string CommentDtl
        {
            get { return RealRecord.CommentDtl; }
            set { RealRecord.CommentDtl = value; }
        }

        #endregion </45.備考(明細)>

        #region <46.添付ファイル(明細)>

        /// <summary>添付ファイル(明細)を取得または設定します。</summary>
        public byte[] AppendingFileDtl
        {
            get { return RealRecord.AppendingFileDtl; }
            set { RealRecord.AppendingFileDtl = value; }
        }

        #endregion </46.添付ファイル(明細)>

        #region <47.添付ファイル名(明細)>

        /// <summary>添付ファイル名(明細)を取得または設定します。</summary>
        public string AppendingFileNmDtl
        {
            get { return RealRecord.AppendingFileNmDtl; }
            set { RealRecord.AppendingFileNmDtl = value; }
        }

        #endregion </47.添付ファイル名(明細)>

        #region <48.棚番>

        /// <summary>棚番を取得または設定します。</summary>
        public string ShelfNo
        {
            get { return RealRecord.ShelfNo; }
            set { RealRecord.ShelfNo = value; }
        }

        #endregion </48.棚番>

        #region <49.追加区分>

        /// <summary>追加区分を取得または設定します。</summary>
        public int AdditionalDivCd
        {
            get { return RealRecord.AdditionalDivCd; }
            set { RealRecord.AdditionalDivCd = value; }
        }

        #endregion </49.追加区分>

        #region <50.訂正区分>

        /// <summary>訂正区分を取得または設定します。</summary>
        public int CorrectDivCD
        {
            get { return RealRecord.CorrectDivCD; }
            set { RealRecord.CorrectDivCD = value; }
        }

        #endregion </50.訂正区分>

        //#region <51.受注ステータス>

        ///// <summary>受注ステータスを取得または設定します。</summary>
        ///// <remarks>10:見積,20:受注,30:売上</remarks>
        //public int AcptAnOdrStatus
        //{
        //    get { return RealRecord.AcptAnOdrStatus; }
        //    set { RealRecord.AcptAnOdrStatus = value; }
        //}

        //#endregion </51.受注ステータス>

        //#region <52.売上伝票番号>

        ///// <summary>売上伝票番号を取得または設定します。</summary>
        ///// <remarks>見積伝票番号,受注伝票番号,出荷伝票番号,売上伝票番号を兼ねる。</remarks>
        //public string SalesSlipNum
        //{
        //    get { return RealRecord.SalesSlipNum; }
        //    set { RealRecord.SalesSlipNum = value; }
        //}

        //#endregion </52.売上伝票番号>

        #region <53.問合せ・発注種別>

        /// <summary>問合せ・発注種別を取得または設定します。</summary>
        /// <remarks>1:問合せ 2:発注</remarks>
        public int InqOrdDivCd
        {
            get { return RealRecord.InqOrdDivCd; }
            set { RealRecord.InqOrdDivCd = value; }
        }

        #endregion </53.問合せ・発注種別>

        #region <54.表示順位>

        /// <summary>表示順位を取得または設定します。</summary>
        public int DisplayOrder
        {
            get { return RealRecord.DisplayOrder; }
            set { RealRecord.DisplayOrder = value; }
        }

        #endregion </54.表示順位>


        // 2010/05/26 Add >>>

        #region <55.キャンセル状態区分>

        /// <summary>キャンセル状態区分を取得または設定します。</summary>
        /// <remarks>0:キャンセルなし 10:キャンセル要求 20:キャンセル却下 30:キャンセル確定</remarks>
        public short CancelCndtinDiv
        {
            get { return RealRecord.CancelCndtinDiv; }
            set { RealRecord.CancelCndtinDiv = value; }
        }

        #endregion </55.キャンセル状態区分>

        #region <56.受注ステータス>

        /// <summary>受注ステータスを取得または設定します。</summary>
        /// <remarks>10：見積 20:受注 30:売上 40:出荷</remarks>
        public int AcptAnOdrStatus
        {
            get { return RealRecord.AcptAnOdrStatus; }
            set { RealRecord.AcptAnOdrStatus = value; }
        }

        #endregion </56.受注ステータス>

        #region <57.売上伝票番号>

        /// <summary>売上伝票番号を取得または設定します。</summary>
        public string SalesSlipNum
        {
            get { return RealRecord.SalesSlipNum; }
            set { RealRecord.SalesSlipNum = value; }
        }

        #endregion </57.売上伝票番号>

        #region <58.売上行番号>

        /// <summary>売上行番号を取得または設定します。</summary>
        public int SalesRowNo
        {
            get { return RealRecord.SalesRowNo; }
            set { RealRecord.SalesRowNo = value; }
        }

        #endregion </58.売上行番号>

        // 2010/05/26 Add <<<

        // 2011/02/09 Add >>>

        #region <59.明細取込区分>
        /// <summary>明細取込区分を取得または設定します。</summary>
        public int DtlTakeinDivCd
        {
            get { return RealRecord.DtlTakeinDivCd; }
            set { RealRecord.DtlTakeinDivCd = value; }
        }
        #endregion </59.明細取込区分>

        // 2011/02/09 Add <<<

        // --- ADD m.suzuki 2011/05/23 ---------->>>>>
        /// <summary>
        /// PM倉庫コードを取得または設定します。(※項目名の違いを吸収)
        /// </summary>
        public string PmWarehouseCd
        {
            get { return RealRecord.WarehouseCode; }
            set { RealRecord.WarehouseCode = value; }
        }
        /// <summary>
        /// PM倉庫名称を取得または設定します。(※項目名の違いを吸収)
        /// </summary>
        public string PmWarehouseName
        {
            get { return RealRecord.WarehouseName; }
            set { RealRecord.WarehouseName = value; }
        }
        /// <summary>
        /// PM棚番を取得または設定します。(※項目名の違いを吸収)
        /// </summary>
        public string PmShelfNo
        {
            get { return RealRecord.WarehouseShelfNo; }
            set { RealRecord.WarehouseShelfNo = value; }
        }
        // --- ADD m.suzuki 2011/05/23 ----------<<<<<

        // --- ADD LDNS wangqx 2011/08/08 ---------->>>>>
        /// <summary>
        /// PM現在庫数を取得または設定します。
        /// </summary>
        public double PmPrsntCount
        {
            get { return RealRecord.PmPrsntCount; }
            set { RealRecord.PmPrsntCount = value; }
        }
        /// <summary>
        /// セット部品メーカーコードを取得または設定します。
        /// </summary>
        public int SetPartsMkrCd
        {
            get { return RealRecord.SetPartsMkrCd; }
            set { RealRecord.SetPartsMkrCd = value; }
        }
        /// <summary>
        /// セット部品番号を取得または設定します。
        /// </summary>
        public string SetPartsNumber
        {
            get { return RealRecord.SetPartsNumber; }
            set { RealRecord.SetPartsNumber = value; }
        }
        /// <summary>
        /// セット部品親子番号を取得または設定します。
        /// </summary>
        public int SetPartsMainSubNo
        {
            get { return RealRecord.SetPartsMainSubNo; }
            set { RealRecord.SetPartsMainSubNo = value; }
        }
        // --- ADD LDNS wangqx 2011/08/08 ----------<<<<<

        // --- ADD 2011/10/10 ---------->>>>>
        /// <summary>
        /// キャンペーンコードを取得または設定します。
        /// </summary>
        public int CampaignCode
        {
            get { return RealRecord.CampaignCode; }
            set { RealRecord.CampaignCode = value; }
        }
        // --- ADD 2011/10/10 ----------<<<<<

        // 2012/01/16 Add >>>
        /// <summary>
        /// 特記事項を取得または設定します。
        /// </summary>
        public string GoodsSpecialNote
        {
            get { return RealRecord.GoodsSpecialNote; }
            set { RealRecord.GoodsSpecialNote = value; }
        }
        // 2012/01/16 Add <<<
        // --- ADD 吉岡 2012/04/12 №170 ---------->>>>>
        /// <summary>
        /// PS管理番号
        /// </summary>
        public int PsMngNo
        {
            get { return RealRecord.PsMngNo; }
            set { RealRecord.PsMngNo = value; }
        }
        // --- ADD 吉岡 2012/04/12 №170 ----------<<<<<
        // --- ADD T.Nishi 2012/05/30 ---------->>>>>
        /// <summary>
        /// 自動見積部品コードを取得または設定します。
        /// </summary>
        public string AutoEstimatePartsCd
        {
            get { return RealRecord.AutoEstimatePartsCd; }
            set { RealRecord.AutoEstimatePartsCd = value; }
        }
        // --- ADD T.Nishi 2012/05/30 ----------<<<<<

        // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// 売上伝票合計（税込）を取得または設定します。
        /// </summary>
        public long SalesTotalTaxInc
        {
            get { return RealRecord.SalesTotalTaxInc; }
            set { RealRecord.SalesTotalTaxInc = value; }
        }
        /// <summary>
        /// 売上伝票合計（税抜）を取得または設定します。
        /// </summary>
        public long SalesTotalTaxExc
        {
            get { return RealRecord.SalesTotalTaxExc; }
            set { RealRecord.SalesTotalTaxExc = value; }
        }
        /// <summary>
        /// SCM消費税転嫁方式を取得または設定します。
        /// </summary>
        public int ScmConsTaxLayMethod
        {
            get { return RealRecord.ScmConsTaxLayMethod; }
            set { RealRecord.ScmConsTaxLayMethod = value; }
        }
        /// <summary>
        /// 消費税税率を取得または設定します。
        /// </summary>
        public double ConsTaxRate
        {
            get { return RealRecord.ConsTaxRate; }
            set { RealRecord.ConsTaxRate = value; }
        }
        /// <summary>
        /// SCM端数処理区分を取得または設定します。
        /// </summary>
        public int ScmFractionProcCd
        {
            get { return RealRecord.ScmFractionProcCd; }
            set { RealRecord.ScmFractionProcCd = value; }
        }

        /// <summary>
        /// 売掛消費税を取得または設定します。
        /// </summary>
        public long AccRecConsTax
        {
            get { return RealRecord.AccRecConsTax; }
            set { RealRecord.AccRecConsTax = value; }
        }
        /// <summary>
        /// PM売上日を取得または設定します。
        /// </summary>
        public int PMSalesDate
        {
            get { return RealRecord.PMSalesDate; }
            set { RealRecord.PMSalesDate = value; }
        }
        /// <summary>
        /// 仕入先伝票発行時刻を取得または設定します。
        /// </summary>
        public int SuppSlpPrtTime
        {
            get { return RealRecord.SuppSlpPrtTime; }
            set { RealRecord.SuppSlpPrtTime = value; }
        }
        /// <summary>
        /// 売上金額（税込み）を取得または設定します。
        /// </summary>
        public long SalesMoneyTaxInc
        {
            get { return RealRecord.SalesMoneyTaxInc; }
            set { RealRecord.SalesMoneyTaxInc = value; }
        }

        /// <summary>
        /// 売上金額（税抜き）を取得または設定します。
        /// </summary>
        public long SalesMoneyTaxExc
        {
            get { return RealRecord.SalesMoneyTaxExc; }
            set { RealRecord.SalesMoneyTaxExc = value; }
        }
        // ADD 2013/05/08 吉岡 2013/06/18配信 SCM障害№10308,№10528 ---------<<<<<<<<<<<<<<<<<<<<<<<<<
        // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 --------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// データ入力システムを取得または設定します。
        /// </summary>
        public int DataInputSystem
        {
            get { return RealRecord.DataInputSystem; }
            set { RealRecord.DataInputSystem = value; }
        }
        // ADD 2013/05/15 吉岡 2013/06/18配信 SCM障害№10410 ---------<<<<<<<<<<<<<<<<<<<<<<<<<

        // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------------------------->>>>>
        /// <summary>
        /// 優良設定詳細コード２を取得または設定します。
        /// </summary>
        public int PrmSetDtlNo2
        {
            get { return RealRecord.PrmSetDtlNo2; }
            set { RealRecord.PrmSetDtlNo2 = value; }
        }
        /// <summary>
        /// 優良設定詳細名称２を取得または設定します。
        /// </summary>
        public string PrmSetDtlName2
        {
            get { return RealRecord.PrmSetDtlName2; }
            set { RealRecord.PrmSetDtlName2 = value; }
        }
        /// <summary>
        /// 在庫状況区分を取得または設定します。
        /// </summary>
        public Int16 StockStatusDiv
        {
            get { return RealRecord.StockStatusDiv; }
            set { RealRecord.StockStatusDiv = value; }
        }
        // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------------------------<<<<<
        // ADD 2014/12/19 SCM高速化 PMNS対応 --------------------------------->>>>>
        /// <summary> 貸出区分を取得または設定します。 </summary>
        public Int16 RentDiv
        {
            get { return RealRecord.RentDiv; }
            set { RealRecord.RentDiv = value; }
        }
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
        // ADD 2014/12/19 SCM高速化 PMNS対応 ---------------------------------<<<<<

        // ADD 2015/01/19 豊沢 リコメンド対応 --------------------->>>>>
        /// <summary>お買得商品選択区分</summary>
        public Int16 BgnGoodsDiv
        {
            get { return RealRecord.BgnGoodsDiv; }
            set { RealRecord.BgnGoodsDiv = value; }
        }
        // ADD 2015/01/19 豊沢 リコメンド対応 ---------------------<<<<<


        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 ----------------------------->>>>>
        /// <summary> 型式別部品採用年月を取得または設定します。 </summary>
        public Int32 ModelPrtsAdptYm
        {
            get { return RealRecord.ModelPrtsAdptYm; }
            set { RealRecord.ModelPrtsAdptYm = value; }
        }

        /// <summary> 型式別部品廃止年月を取得または設定します。 </summary>
        public Int32 ModelPrtsAblsYm
        {
            get { return RealRecord.ModelPrtsAblsYm; }
            set { RealRecord.ModelPrtsAblsYm = value; }
        }

        /// <summary> 型式別部品採用車台番号を取得または設定します。 </summary>
        public Int32 ModelPrtsAdptFrameNo
        {
            get { return RealRecord.ModelPrtsAdptFrameNo; }
            set { RealRecord.ModelPrtsAdptFrameNo = value; }
        }

        /// <summary> 型式別部品廃止車台番号を取得または設定します。 </summary>
        public Int32 ModelPrtsAblsFrameNo
        {
            get { return RealRecord.ModelPrtsAblsFrameNo; }
            set { RealRecord.ModelPrtsAblsFrameNo = value; }
        }
        // ADD 2015/01/30 SCM高速化 生産年式、車台番号対応 -----------------------------<<<<<

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
