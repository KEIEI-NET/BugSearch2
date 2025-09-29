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
// 作 成 日  2009/05/20  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 工藤 恵優
// 作 成 日  2010/04/05  修正内容 : 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 20056　對馬 大輔
// 作 成 日  2010/04/21  修正内容 : 品番検索／ＢＬコード検索で代替区分の設定を可能とする
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/14  修正内容 : 返品時のデータセット修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 21024　佐々木 健
// 作 成 日  2011/02/18  修正内容 : ①キャンセル仕様変更対応
//                                 ②計上元からGoodsUnitDataの選択倉庫をセットする
//                                 ③計上時の数量は発注情報を優先する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2011/07/20  修正内容 : 標準価格と原単価の水色の設定の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 高峰
// 作 成 日  2011/08/10  修正内容 : PCCUOE自動回答
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 譚洪
// 作 成 日  2011/09/15  修正内容 : Redmine#24913 倉庫コードを入力可能にして、伝票発行可能の修正
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2011/09/20  修正内容 : Redmine#25362 SCM PM側　SFから返品した場合に関して
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/01/04  修正内容 : SCM改良対応
//                                  1)純正情報設定対応
//                                  2)表示順位設定対応
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 30517 夏野 駿希
// 作 成 日  2012/01/16  修正内容 : SCM改良対応・特記事項対応
//----------------------------------------------------------------------------//
// 管理番号  10800003-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/02/07  修正内容 : SCM改良対応・特記事項対応 40桁以上カット対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20056 對馬 大輔
// 作 成 日  2012/04/09  修正内容 : BL-Pダイレクト発注対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 20073 西 毅
// 作 成 日  2012/05/07  修正内容 : 販売区分セットの条件変更
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 三戸　伸悟
// 作 成 日  2012/05/18  修正内容 : 障害一覧表№117対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/06/25  修正内容 : SCM障害№10281 自動回答対象の倉庫は委託倉庫、優先（自拠点）倉庫のみ
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/07/06  修正内容 : システム障害№53　同一商品の判断条件変更（SCM障害№10281対応時の不具合対応）
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 吉岡　孝憲
// 作 成 日  2012/07/26  修正内容 : 2012/08/07配信 システム障害№123対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 湯上 千加子
// 作 成 日  2012/05/15  修正内容 : 障害対応 SF連携の売上計上時の発注ボタン有効にする対応
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 三戸　伸悟
// 作 成 日  2012/06/06  修正内容 : 障害№10282 手動回答時に作成される売上データに、委託在庫以外でも販売区分を反映する
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/09  修正内容 : SCM改良№10337,10338,10341,10364,10431対応 PCCforNS、BLPの自動回答判定処理統合
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2012/11/20  修正内容 : 2012/12/12配信予定システムテスト障害№40対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/02/13  修正内容 : 2013/03/06配信 SCM障害追加②対応 
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : zhubj
// 作 成 日  2013/02/18  
// 修正内容 : 2013/03/13配信分　 システム障害 管理№10471対応
//                 セット品管理マスタの不具合対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/05/13  修正内容 : SCM障害№10530対応 
//----------------------------------------------------------------------------//
// 管理番号  10902175-00 作成担当 : 宮本 利明
// 作 成 日  2013/08/16  修正内容 : Redmine#39877対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30744 湯上 千加子
// 作 成 日  2013/12/09  修正内容 : SCM仕掛一覧№10608対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 宮本 利明
// 作 成 日  2014/01/16  修正内容 : 純正定価印字対応
//----------------------------------------------------------------------------//
// 管理番号  11070147-00 作成担当 : 鄧潘ハン
// 作 成 日  2014/07/23  修正内容 : SCM仕掛一覧№10659の3SCM受発注明細データに在庫状況区分のセットの対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : duzg
// 作 成 日  2014/08/11  修正内容 : 検証／総合テスト障害No.5
//----------------------------------------------------------------------------//
// 管理番号  11070221-00 作成担当 : 30744 湯上
// 作 成 日  2014/11/10  修正内容 : 2014/11/26配信システムテスト障害対応
//                                : 品番検索時に結合先品番が回答されない障害の対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢
// 作 成 日  2015/02/02  修正内容 : PM-SCM社内障害一覧No.69対応
//                                : メーカー違いの同一品番が複数存在する場合の再問合せエラー対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 31065 豊沢
// 作 成 日  2015/02/04  修正内容 : PM-SCM社内障害一覧No.72対応
//                                : 商品規格・特記事項の桁数変更対応
//----------------------------------------------------------------------------//
// 管理番号  11070266-00 作成担当 : 30744 湯上
// 作 成 日  2015/03/03  修正内容 : SCM高速化Redmine#300対応
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Controller.Agent;
using Broadleaf.Application.Controller.Auto;
using Broadleaf.Application.Controller.Util;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    using GoodsAcsServer = SingletonInstance<GoodsAcsAgent>;    // 初期化済み商品検索クラス
    using SalesTtlStServer = SingletonInstance<SalesTtlStAgent>;// 売上全体設定マスタ
    using SCMOrderDetailRecordType = ISCMOrderDetailRecord;    // SCM受注明細データ(問合せ・発注) // ADD 2011/08/10

    /// <summary>
    /// SCM検索結果クラス
    /// </summary>
    // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
    //public sealed class SCMSearchedResult
    // DEL 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
    public class SCMSearchedResult
    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
    {
        /// <summary>
        /// 商品検索区分列挙型
        /// </summary>
        public enum GoodsSearchDivCd : int
        {
            /// <summary>BLコード検索</summary>
            BLCode = 0,
            /// <summary>品番検索</summary>
            GoodsNo = 1,
            /// <summary>用品入力</summary>
            GoodsName = 2 // ADD 2011/08/10
        }

        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
        /// <summary>品番検索の自動モード定数(0:通常モード)</summary>
        public const int MODE_OF_SEARCHING_GOODS_NO_IS_NOMAL = 0;
        // ADD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

        #region <SCM受注データ>

        /// <summary>元となったSCM受注明細データ(問合せ・発注)のレコード</summary>
        private readonly ISCMOrderDetailRecord _sourceDetailRecord;
        /// <summary>元となったSCM受注明細データ(問合せ・発注)のレコードを取得します。</summary>
        private ISCMOrderDetailRecord SourceDetailRecord { get { return _sourceDetailRecord; } }

        #endregion // </SCM受注データ>

        #region <部品情報>

        /// <summary>
        /// 部品情報のUsrJoinPartsテーブルのカラム名列挙型
        /// </summary>
        private enum UsrJoinPartsColumnName : int
        {
            /// <summary>表示順位</summary>
            JoinDispOrder,
            /// <summary>メーカーコード</summary>
            JoinDestMakerCd,
            /// <summary>品番</summary>
            JoinDestPartsNo
        }

        /// <summary>部品情報DB</summary>
        //private readonly PartsInfoDataSet _partsInfoDB; // 2012/01/04
        private PartsInfoDataSet _partsInfoDB; // 2012/01/04
        /// <summary>部品情報DBを取得します。</summary>
        //>>>2012/01/04
        //private PartsInfoDataSet PartsInfoDB { get { return _partsInfoDB; } }
        public PartsInfoDataSet PartsInfoDB { 
            get { return _partsInfoDB; }
            set { _partsInfoDB = value; }
        }
        //<<<2012/01/04

        // ----- ADD 2011/08/10 ----- >>>>>
        /// <summary>部品情報DB</summary>
        private readonly PartsInfoDataSet _partsInfoDBForPccuoe;
        /// <summary>部品情報DBを取得します。</summary>
        private PartsInfoDataSet PartsInfoDBForPccuoe { get { return _partsInfoDBForPccuoe; } }
        // ----- ADD 2011/08/10 ----- <<<<<

        #endregion // </部品情報>

        // 2011/01/11 Add >>>
        /// <summary></summary>
        private int _status;

        /// <summary>検索ステータスプロパティ</summary>
        public int Status
        {
            get { return _status; }
            set { _status = value; }
        }
        // 2011/01/11 Add <<<

        #region <商品連結データ>

        /// <summary>商品連結データリスト</summary>
        private readonly List<GoodsUnitData> _goodsUnitDataList;

        /// <summary>選択された商品連結データリスト</summary>
        private List<GoodsUnitData> _selectedGoodsUnitDataList;

        // ----- ADD 2011/08/10 ----- >>>>>
        /// <summary>商品リストを取得します。</summary>
        public List<GoodsUnitData> GoodsUnitDataListForPccuoe
        {
            get
            {
                if (PartsInfoDBForPccuoe != null && PartsInfoDBForPccuoe.UsrGoodsInfo.Count > 0)
                {
                    // --- UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
                    //return new List<GoodsUnitData>((GoodsUnitData[])PartsInfoDBForPccuoe.GetGoodsList(false).ToArray(typeof(GoodsUnitData)));
                    return new List<GoodsUnitData>((GoodsUnitData[])PartsInfoDBForPccuoe.GetGoodsListWithSrc(false).ToArray(typeof(GoodsUnitData)));
                    // --- UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
                }
                else
                {
                    return _goodsUnitDataList;
                }
            }

        }
        // ----- ADD 2011/08/10 ----- <<<<<

        /// <summary>商品連結データリストを取得します。</summary>
        public List<GoodsUnitData> GoodsUnitDataList
        {
            get
            {
                // 品番検索(BLコード検索）結果が1件の場合、そのまま返す
                if (_selectedGoodsUnitDataList == null && _goodsUnitDataList.Count.Equals(1))
                {
                    _selectedGoodsUnitDataList = _goodsUnitDataList;
                }
                // 品番検索(BLコード検索）結果が複数の場合、選択されたものを返す
                else if (_selectedGoodsUnitDataList == null)
                {
                    _selectedGoodsUnitDataList = new List<GoodsUnitData>(
                        // --- UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
                        //(GoodsUnitData[])PartsInfoDB.GetGoodsList(true).ToArray(typeof(GoodsUnitData))
                        (GoodsUnitData[])PartsInfoDB.GetGoodsListWithSrc(true).ToArray(typeof(GoodsUnitData))
                        // --- UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
                    );
                }

                // 補正して返す
                if (!Revised(_selectedGoodsUnitDataList))
                {
                    _selectedGoodsUnitDataList = ReviseGoodsUnitData(_selectedGoodsUnitDataList, SourceDetailRecord);
                }
                return _selectedGoodsUnitDataList;
            }
        }

        /// <summary>
        /// 補正済みか判断します。
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データのリスト</param>
        /// <returns>
        /// <c>true</c> :補正済みです。
        /// <c>false</c>:未補正です。
        /// </returns>
        private static bool Revised(List<GoodsUnitData> goodsUnitDataList)
        {
            if (ListUtil.IsNullOrEmpty<GoodsUnitData>(goodsUnitDataList)) return true;

            foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
            {
                if (
                    string.IsNullOrEmpty(goodsUnitData.SectionCode.Trim())
                        ||
                    string.IsNullOrEmpty(goodsUnitData.EnterpriseCode.Trim())
                )
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 商品連結データを補正します。
        /// </summary>
        /// <remarks>
        /// MAHNB01012AD.cs SalesSlipInputInitDataAcs.SettingGoodsUnitDataListFromVariousMst() 1782行目より移植
        /// </remarks>
        /// <param name="goodsUnitDataList">商品連結データのリスト</param>
        /// <param name="sourceDetailRecord">SCM受注明細データ(問合せ・発注)のレコード</param>
        /// <returns>補正された商品連結データのリスト</returns>
        private static List<GoodsUnitData> ReviseGoodsUnitData(
            List<GoodsUnitData> goodsUnitDataList,
            ISCMOrderDetailRecord sourceDetailRecord
        )
        {
            GoodsAcs goodsAccesser = GoodsAcsServer.Singleton.Instance.GetGoodsAccesser(sourceDetailRecord);

            bool isSettingSupplier = true;  // 固定

            List<GoodsUnitData> revisedGoodsUnitDataList = new List<GoodsUnitData>();
            {
                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    // 検索件数0件でも検索されたとみなす場合用
                    // 例：手動回答で品番検索で件数0件の場合
                    if (goodsUnitData is NullGoodsUnitData)
                    {
                        revisedGoodsUnitDataList.Add(goodsUnitData);
                        continue;
                    }

                    GoodsUnitData revisedGoodsUnitData = goodsUnitData.Clone();
                    {
                        revisedGoodsUnitData.EnterpriseCode = sourceDetailRecord.InqOtherEpCd;
                        revisedGoodsUnitData.SectionCode    = sourceDetailRecord.InqOtherSecCd;
                    }
                    // ADD 2012/07/26 T.Yoshioka 2012/08/07配信 システムテスト障害№123 --------->>>>>>>>>>>>>>>>>>>>>
                    string wSectionCode = revisedGoodsUnitData.SectionCode;
                    // ADD 2012/07/26 T.Yoshioka 2012/08/07配信 システムテスト障害№123 ---------<<<<<<<<<<<<<<<<<<<<<

                    // DEL 2014/08/11 duzg For 検証／総合テスト障害No.5 ------------------------>>>>>>>>>>>>>>>>>>>>>>
                    //goodsAccesser.SettingGoodsUnitDataFromVariousMst(
                    //    ref revisedGoodsUnitData,
                    //    isSettingSupplier ? 0 : 1
                    //);
                    // DEL 2014/08/11 duzg For 検証／総合テスト障害No.5 ------------------------<<<<<<<<<<<<<<<<<<<<<<

                    // Add 2014/08/11 duzg For 検証／総合テスト障害No.5 ------------------------>>>>>>>>>>>>>>>>>>>>>>
                    goodsAccesser.SettingGoodsUnitDataFromVariousMst2(
                        ref revisedGoodsUnitData,
                        isSettingSupplier ? 0 : 1
                    );
                    // Add 2014/08/11 duzg For 検証／総合テスト障害No.5 ------------------------<<<<<<<<<<<<<<<<<<<<<<

                    // ADD 2012/07/26 T.Yoshioka 2012/08/07配信 システムテスト障害№123 --------->>>>>>>>>>>>>>>>>>>>>
                    // 拠点コードが商品管理情報の拠点コードで上書きされるので、元に戻す
                    revisedGoodsUnitData.SectionCode = wSectionCode;
                    // ADD 2012/07/26 T.Yoshioka 2012/08/07配信 システムテスト障害№123 ---------<<<<<<<<<<<<<<<<<<<<<
                    if (revisedGoodsUnitData != null)
                    {
                        revisedGoodsUnitDataList.Add(revisedGoodsUnitData);
                    }
                }
            }
            return revisedGoodsUnitDataList;
        }

        #endregion // </商品連結データ>

        #region <検索種別>

        /// <summary>検索種別</summary>
        private readonly GoodsSearchDivCd _searchedType;
        /// <summary>検索種別を取得します。</summary>
        public GoodsSearchDivCd SearchedType { get { return _searchedType; } }

        #endregion // </検索種別>

        #region <車両検索結果>

        /// <summary>車両検索結果</summary>
        private readonly PMKEN01010E _searchCarInfo;
        /// <summary>車両検索結果を取得します。</summary>
        public PMKEN01010E SearchCarInfo { get { return _searchCarInfo; } }

        /// <summary>
        /// 車両検索結果が存在するか判断します。
        /// </summary>
        /// <returns><c>true</c> :存在します。<br/><c>false</c>:存在しません。</returns>
        public bool HasSearchCarInfo()
        {
            return SearchCarInfo != null;
        }

        #endregion // </車両検索結果>

        #region <Constructor>

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="sourceDetailRecord">元となったSCM受注明細データ(問合せ・発注)</param>
        /// <param name="acceptOrOrderKind">受発注種別</param>
        /// <param name="status">ステータス</param>
        /// <param name="partsInfoDB">部品情報DB</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="searchedType">検索種別</param>
        /// <param name="searchCarInfo">車両検索結果</param>
        /// <param name="substDiv">代替区分</param>
        //>>>2010/04/21
        //public SCMSearchedResult(
        //    ISCMOrderDetailRecord sourceDetailRecord,
        //    PartsInfoDataSet partsInfoDB,
        //    List<GoodsUnitData> goodsUnitDataList,
        //    GoodsSearchDivCd searchedType,
        //    PMKEN01010E searchCarInfo
        //)
        public SCMSearchedResult(
            ISCMOrderDetailRecord sourceDetailRecord,
            Int16 acceptOrOrderKind, // ADD 2011/08/10
            // 2011/01/11 Add >>>
            int status,
            // 2011/01/11 Add <<<
            PartsInfoDataSet partsInfoDB,
            List<GoodsUnitData> goodsUnitDataList,
            GoodsSearchDivCd searchedType,
            PMKEN01010E searchCarInfo,
            bool substDiv
        )
        //<<<2010/04/21
        {
            _sourceDetailRecord = sourceDetailRecord;
            _partsInfoDB        = partsInfoDB;
            _partsInfoDBForPccuoe = (PartsInfoDataSet)partsInfoDB.Copy(); // ADD 2011/08/10
            // 2011/01/11 Add >>>
            _status = status;
            // 2011/01/11 Add <<<

            // ADD 2011/08/10 gaofeng >>>
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            // PCCUOEの場合
            //if (acceptOrOrderKind == (int)EnumAcceptOrOrderKind.PCCUOE)
            //{
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                // 品番の場合
                if (searchedType == SCMSearchedResult.GoodsSearchDivCd.GoodsNo)
                {
                    SalesTtlSt foundSalesTtlSt = SalesTtlStDB.Find(sourceDetailRecord.InqOtherEpCd, sourceDetailRecord.InqOtherSecCd);
                    if (foundSalesTtlSt != null)
                    {
                        _selectedGoodsUnitDataList = new List<GoodsUnitData>(
                            // --- UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
                            //(GoodsUnitData[])_partsInfoDB.GetGoodsList(
                            (GoodsUnitData[])_partsInfoDB.GetGoodsListWithSrc(
                            // --- UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
                                true,                               // 選択行のみ
                                foundSalesTtlSt.PartsNameDspDivCd,  // 品名表示区分
                            //false                               // 代替区分 // 2010/04/21
                                substDiv                               // 代替区分 // 2010/04/21
                            ).ToArray(typeof(GoodsUnitData))
                        );
                    }
                    else
                    {
                        _selectedGoodsUnitDataList = new List<GoodsUnitData>(
                            // --- UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
                            //(GoodsUnitData[])_partsInfoDB.GetGoodsList(true).ToArray(typeof(GoodsUnitData))
                            (GoodsUnitData[])_partsInfoDB.GetGoodsListWithSrc(true).ToArray(typeof(GoodsUnitData))
                            // --- UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
                        );
                    }

                    // ADD 2012/11/20 2012/12/12配信予定 システムテスト障害№40対応 ---------------------------------->>>>>
                    // UPD 2014/11/10 PM-SCM優先案件11月対応分 ------------------------------------------>>>>>
                    //// 品番の場合、親の品番のみ抽出
                    ////_selectedGoodsUnitDataList = _selectedGoodsUnitDataList.FindAll(delegate(GoodsUnitData goodsUnitData)//DEL 2013/02/18 zhubj 管理№10471---- >>>>>
                    //List<GoodsUnitData> tempSelectedGoodsUnitDataList = _selectedGoodsUnitDataList.FindAll(delegate(GoodsUnitData goodsUnitData)//ADD 2013/02/18 zhubj 管理№10471---- >>>>>
                    //{
                    //    if (goodsUnitData.GoodsKind != (int)GoodsKind.Parent) return false;
                    //    return true;
                    //});
                    // 品番の場合、結合元、結合先品番のみ抽出
                    List<GoodsUnitData> tempSelectedGoodsUnitDataList = _selectedGoodsUnitDataList.FindAll(delegate(GoodsUnitData goodsUnitData)
                    {
                        // UPD 2015/02/02 豊沢 PM-SCM社内障害一覧No.69対応 ------------------------------------------>>>>>
                        //if ((goodsUnitData.GoodsKind == (int)GoodsKind.Parent || goodsUnitData.GoodsKind == (int)GoodsKind.Join) &&
                        //     goodsUnitData.GoodsNo == sourceDetailRecord.GoodsNo) return true;
                        //else return false;
                        if (sourceDetailRecord.GoodsMakerCd != 0)
                        {
                            if (SCMReferee.ContainsJoinAtGoodsKind(goodsUnitData)
                                && goodsUnitData.GoodsNo == sourceDetailRecord.GoodsNo
                                && goodsUnitData.GoodsMakerCd == sourceDetailRecord.GoodsMakerCd) return true;
                            else return false;
                        }
                        else
                        {
                            if (SCMReferee.ContainsJoinAtGoodsKind(goodsUnitData) &&
                                 goodsUnitData.GoodsNo == sourceDetailRecord.GoodsNo) return true;
                            else return false;
                        }
                        // UPD 2015/02/02 豊沢 PM-SCM社内障害一覧No.69対応 ------------------------------------------<<<<<
                    });
                    // UPD 2014/11/10 PM-SCM優先案件11月対応分 ------------------------------------------<<<<<

                    // ----ADD 2013/02/18 zhubj 管理№10471---- >>>>>
                    // 親の品番存在する場合、親の品番のみを使用。親の品番存在しない場合、選択された商品連結データを使用
                    if (tempSelectedGoodsUnitDataList != null && tempSelectedGoodsUnitDataList.Count != 0)
                    {
                        _selectedGoodsUnitDataList = tempSelectedGoodsUnitDataList;
                    }
                    // ----ADD 2013/02/18 zhubj 管理№10471---- <<<<<
                    // ADD 2012/11/20 2012/12/12配信予定 システムテスト障害№40対応 ----------------------------------<<<<<

                    // ADD 2013/12/09 SCM仕掛一覧№10608対応 ------------------------------------------->>>>>
                    // 親品番が存在しない場合、問合せ時の品番を抽出
                    if (tempSelectedGoodsUnitDataList == null || tempSelectedGoodsUnitDataList.Count == 0)
                    {
                        foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                        {
                            if (sourceDetailRecord.GoodsMakerCd == goodsUnitData.GoodsMakerCd &&
                                sourceDetailRecord.GoodsNo == goodsUnitData.GoodsNo)
                            {
                                if (tempSelectedGoodsUnitDataList == null) tempSelectedGoodsUnitDataList = new List<GoodsUnitData>();
                                tempSelectedGoodsUnitDataList.Add(goodsUnitData);
                            }
                        }
                        if (tempSelectedGoodsUnitDataList != null && tempSelectedGoodsUnitDataList.Count != 0)
                        {
                            _selectedGoodsUnitDataList = tempSelectedGoodsUnitDataList;
                        }
                    }
                    // ADD 2013/12/09 SCM仕掛一覧№10608対応 -------------------------------------------<<<<<

                    // FIXME:PartsInfoDataSet.GetGoodsList(true)が空のArrayListを返すことがある？
                    if (ListUtil.IsNullOrEmpty<GoodsUnitData>(_selectedGoodsUnitDataList))
                    {
                        _selectedGoodsUnitDataList = goodsUnitDataList;
                    }

                    // DEL 2012/11/20 2012/12/12配信予定 システムテスト障害№40対応 ---------------------------------->>>>>
                    //// 品番の場合、親の品番のみ抽出
                    //_selectedGoodsUnitDataList = _selectedGoodsUnitDataList.FindAll(delegate(GoodsUnitData goodsUnitData)
                    //{
                    //    if (goodsUnitData.GoodsKind != (int)GoodsKind.Parent) return false;
                    //    return true;
                    //});
                    // DEL 2012/11/20 2012/12/12配信予定 システムテスト障害№40対応 ----------------------------------<<<<<
                }
                // BLコードの場合/用品入力の場合
                else
                {
                    //>>>2012/04/09 発注時は選択行のみ対象とする
                    //_selectedGoodsUnitDataList = goodsUnitDataList;

                    // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
                    //if (SourceDetailRecord.InqOrdDivCd.Equals(2))
                    //{
                    // 発注または手動回答時
                    if (SourceDetailRecord.InqOrdDivCd.Equals(2) || partsInfoDB.Mode.Equals(MODE_OF_SEARCHING_GOODS_NO_IS_NOMAL))
                    {  
                    // UPD 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<
                        // 発注
                        SalesTtlSt foundSalesTtlSt = SalesTtlStDB.Find(sourceDetailRecord.InqOtherEpCd, sourceDetailRecord.InqOtherSecCd);
                        if (foundSalesTtlSt != null)
                        {
                            _selectedGoodsUnitDataList = new List<GoodsUnitData>(
                                // --- UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
                                //(GoodsUnitData[])_partsInfoDB.GetGoodsList(
                                (GoodsUnitData[])_partsInfoDB.GetGoodsListWithSrc(
                                // --- UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
                                    true,                               // 選択行のみ
                                    foundSalesTtlSt.PartsNameDspDivCd,  // 品名表示区分
                                //false                               // 代替区分 // 2010/04/21
                                    substDiv                               // 代替区分 // 2010/04/21
                                ).ToArray(typeof(GoodsUnitData))
                            );
                        }
                        else
                        {
                            _selectedGoodsUnitDataList = new List<GoodsUnitData>(
                                // --- UPD 2014/01/16 T.Miyamoto ------------------------------>>>>>
                                //(GoodsUnitData[])_partsInfoDB.GetGoodsList(true).ToArray(typeof(GoodsUnitData))
                                (GoodsUnitData[])_partsInfoDB.GetGoodsListWithSrc(true).ToArray(typeof(GoodsUnitData))
                                // --- UPD 2014/01/16 T.Miyamoto ------------------------------<<<<<
                            );
                        }

                        // FIXME:PartsInfoDataSet.GetGoodsList(true)が空のArrayListを返すことがある？
                        if (ListUtil.IsNullOrEmpty<GoodsUnitData>(_selectedGoodsUnitDataList))
                        {
                            _selectedGoodsUnitDataList = goodsUnitDataList;
                        }
                    }
                    else
                    {
                        // 在庫確認
                        _selectedGoodsUnitDataList = goodsUnitDataList;
                    }
                    //<<<2012/04/09
                }
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ---------------------------------->>>>>
            #region 削除(SCM改良のため)
            //}
            //// SCMの場合
            //else
            //{
            //// ADD 2011/08/10 gaofeng <<<
            //    SalesTtlSt foundSalesTtlSt = SalesTtlStDB.Find(sourceDetailRecord.InqOtherEpCd, sourceDetailRecord.InqOtherSecCd);
            //    if (foundSalesTtlSt != null)
            //    {
            //        _selectedGoodsUnitDataList = new List<GoodsUnitData>(
            //            (GoodsUnitData[])_partsInfoDB.GetGoodsList(
            //                true,                               // 選択行のみ
            //                foundSalesTtlSt.PartsNameDspDivCd,  // 品名表示区分
            //            //false                               // 代替区分 // 2010/04/21
            //                substDiv                               // 代替区分 // 2010/04/21
            //            ).ToArray(typeof(GoodsUnitData))
            //        );
            //    }
            //    else
            //    {
            //        _selectedGoodsUnitDataList = new List<GoodsUnitData>(
            //            (GoodsUnitData[])_partsInfoDB.GetGoodsList(true).ToArray(typeof(GoodsUnitData))
            //        );
            //    }

            //    // FIXME:PartsInfoDataSet.GetGoodsList(true)が空のArrayListを返すことがある？
            //    if (ListUtil.IsNullOrEmpty<GoodsUnitData>(_selectedGoodsUnitDataList))
            //    {
            //        _selectedGoodsUnitDataList = goodsUnitDataList;
            //    }
            //} // ADD 2011/08/10 gaofeng
            #endregion
            // DEL 2012/11/09 2012/12/12配信予定 SCM改良№10337,10338,10341,10364,10431対応 ----------------------------------<<<<<

            _goodsUnitDataList  = goodsUnitDataList;
            _searchedType       = searchedType;
            _searchCarInfo      = searchCarInfo;

            // ADD 2012/06/25 T.Yoshioka №10281 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            // 在庫リストと選択倉庫の編集
            foreach (GoodsUnitData goods in _selectedGoodsUnitDataList)
            {
                foreach (SCMSearcher.WarehouseInfo wInf in SCMSearcher.warehouseInfoList)
                {
                    // UPD 2012/07/06 T.Yoshioka 障害№53 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    if (goods.GoodsNo == wInf.GoodsNo && goods.GoodsMakerCd == wInf.MakerCd)
                    // if (goods.GoodsNo == wInf.GoodsNo)
                    // UPD 2012/07/06 T.Yoshioka 障害№53 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    {
                        // 在庫リスト
                        goods.StockList = new List<Stock>();
                        goods.StockList = wInf.StockList;

                        // 選択倉庫
                        goods.SelectedWarehouseCode = wInf.Selected;
                        // UPD 2012/07/06 T.Yoshioka 障害№53 ------------------>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        break;
                        // UPD 2012/07/06 T.Yoshioka 障害№53 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    }
                }
            }
            // ADD 2012/06/25 T.Yoshioka №10281 ------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // --- UPD 2013/08/16 T.Miyamoto ------------------------------>>>>>
            //// ----- UPD 2011/08/10 ----- >>>>>
            ////// 初期化します。
            ////Initialize();
            //// SCMの場合
            //if (acceptOrOrderKind == (int)EnumAcceptOrOrderKind.SCM)
            //{
            //    // 初期化します。
            //    Initialize();
            //}
            //// ----- UPD 2011/08/10 ----- <<<<<
            // 初期化します。
            Initialize();
            // --- UPD 2013/08/16 T.Miyamoto ------------------------------<<<<<
        }

        /// <summary>純正の表示順位</summary>
        /// <remarks>注意！自動回答処理で独自の値です。</remarks>
        public const int PURE_DISPLAY_ORDER = int.MinValue;

        /// <summary>
        /// 初期化します。
        /// </summary>
        /// <remarks>
        /// ①拠点コードを設定します。<br/>
        /// ②表示順位を設定します。
        /// </remarks>
        private void Initialize()
        {
            int pureCount = 0;
            // 2010/03/17 >>>
            DataView partsView = PartsInfoDB.UsrJoinParts.DefaultView;
            string defFilter = partsView.RowFilter;
            string defSort = partsView.Sort;
            string newFilter = string.Empty;
            partsView.Sort = UsrJoinPartsColumnName.JoinDispOrder.ToString();
            try
            {
                // 2010/03/17 <<<
                foreach (GoodsUnitData goodsUnitData in GoodsUnitDataList)
                {
                    goodsUnitData.SectionCode = SourceDetailRecord.InqOtherSecCd;   // 商品連結データに拠点コードを設定
                    // FIXME:不足情報を設定…GoodsAccesser.SettingGoodsUnitDataFromVariousMst(ref goodsUnitData, (isSettingSupplier ? 0 : 1));

                    // 表示順位を設定
                    StringBuilder filter = new StringBuilder();
                    {
                        int joinDestMakerCd = goodsUnitData.GoodsMakerCd;
                        string joinDestPartsNo = goodsUnitData.GoodsNo;

                        filter.Append(UsrJoinPartsColumnName.JoinDestMakerCd).Append("=").Append(joinDestMakerCd);
                        filter.Append(" and ");
                        filter.Append(UsrJoinPartsColumnName.JoinDestPartsNo).Append("='").Append(joinDestPartsNo).Append("'");
                    }
                    // 2010/03/17 >>>
                    //DataRow[] foundUsrJoinPartsRows = PartsInfoDB.UsrJoinParts.Select(
                    //    filter.ToString(),
                    //    UsrJoinPartsColumnName.JoinDispOrder.ToString()
                    //);
                    //if (foundUsrJoinPartsRows.Length > 0)
                    partsView.RowFilter = filter.ToString();
                    if (partsView.Count > 0)
                    // 2010/03/17 <<<
                    {
                        // 2010/03/17 >>>
                        //// Debug.Assert(foundUsrJoinPartsRows.Length.Equals(1), "UsrJoinPartsテーブルに同じ部品が複数あります。");
                        //Debug.WriteLine(foundUsrJoinPartsRows.Length.Equals(1) ? "結合品の表示順位OK" : "UsrJoinPartsテーブルに同じ部品が複数あります。");

                        //PartsInfoDataSet.UsrJoinPartsRow foundUsrJoinPartsRow = ( (PartsInfoDataSet.UsrJoinPartsRow)foundUsrJoinPartsRows[0] );
                        //goodsUnitData.PrimePartsDisplayOrder = foundUsrJoinPartsRow.JoinDispOrder;

                        Debug.WriteLine(partsView.Count.Equals(1) ? "結合品の表示順位OK" : "UsrJoinPartsテーブルに同じ部品が複数あります。");

                        goodsUnitData.PrimePartsDisplayOrder = (int)partsView[0][UsrJoinPartsColumnName.JoinDispOrder.ToString()];
                    }
                    else
                    {
                        pureCount++;
                        goodsUnitData.PrimePartsDisplayOrder = PURE_DISPLAY_ORDER;

                        //Debug.Assert(pureCount.Equals(1), "GoodsUnitDataListに純正品が複数ある？");
                        Debug.WriteLine(pureCount.Equals(1) ? "純正品の表示順位OK" : "GoodsUnitDataListに純正品が複数ある？");
                    }
                }
            }
            // 2010/03/17 Add >>>
            finally
            {
                PartsInfoDB.UsrJoinParts.DefaultView.RowFilter = defFilter;
                PartsInfoDB.UsrJoinParts.DefaultView.Sort = defSort;
            }
            // 2010/03/17 Add <<<
        }

        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="sourceDetailRecord">元となったSCM受注明細データ(問合せ・発注)</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="searchedType">検索種別</param>
        /// <param name="searchCarInfo">車両検索結果</param>
        protected SCMSearchedResult(
            ISCMOrderDetailRecord sourceDetailRecord,
            List<GoodsUnitData> goodsUnitDataList,
            GoodsSearchDivCd searchedType
            // 2011/02/09 >>>
            ,PMKEN01010E searchCarInfo
            // 2011/02/09 <<<
        )
        {
            _sourceDetailRecord         = sourceDetailRecord;
            _selectedGoodsUnitDataList  = goodsUnitDataList;
            _goodsUnitDataList          = goodsUnitDataList;
            _searchedType               = searchedType;
            _searchCarInfo = searchCarInfo;    // 2011/02/09 Add
        }
        // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<

        #endregion // </Constructor>

        #region <売上全体設定マスタ>

        /// <summary>
        /// 売上全体設定マスタを取得します。
        /// </summary>
        private static SalesTtlStAgent SalesTtlStDB
        {
            get { return SalesTtlStServer.Singleton.Instance; }
        }

        #endregion // </売上全体設定マスタ>
    }

    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ---------->>>>>
    /// <summary>
    /// 回答済みSCM検索結果クラス
    /// </summary>
    public sealed class AnsweredSCMSearchedResult : SCMSearchedResult
    {
        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="sourceDetailRecord">元となったSCM受注明細データ(問合せ・発注)</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="searchedType">検索種別</param>
        /// <param name="searchCarInfo">車両検索結果</param>
        // 2011/02/09 Add >>>
        //public AnsweredSCMSearchedResult(
        //    ISCMOrderDetailRecord sourceDetailRecord,
        //    List<GoodsUnitData> goodsUnitDataList,
        //    GoodsSearchDivCd searchedType
        //) : base(sourceDetailRecord, goodsUnitDataList, searchedType)
        //{ }

        public AnsweredSCMSearchedResult(
            ISCMOrderDetailRecord sourceDetailRecord
            , List<GoodsUnitData> goodsUnitDataList
            , GoodsSearchDivCd searchedType
            , PMKEN01010E searchCarInfo
            )
            : base(sourceDetailRecord, goodsUnitDataList, searchedType, searchCarInfo)
        { }
        // 2011/02/09 Add <<<

        #endregion // Constructor

        /// <summary>
        /// 回答済み商品検索結果項目を生成します。
        /// </summary>
        /// <param name="answeredRecord">回答済みSCM受注明細データ(回答)</param>
        /// <param name="entriedSalesDetails">発行済み売上明細データ</param>
        /// <returns>
        /// 発行済み売上明細データまたは回答済みSCM受注明細データ(回答)からの商品検索結果項目
        /// （売上明細データまたは回答データから取得できるプロパティのみ設定されます）
        /// </returns>
        public static AnsweredGoodsUnitData CreateAnsweredGoodsUnitData(
            ISCMOrderAnswerRecord answeredRecord,
            SalesDetailWork[] entriedSalesDetails
        )
        {
            UserSCMOrderAnswerRecord userAnsweredRecord = answeredRecord as UserSCMOrderAnswerRecord;
            Debug.Assert(userAnsweredRecord != null, "回答データの型が不正です。");

            AnsweredGoodsUnitData goodsUnitData = new AnsweredGoodsUnitData(userAnsweredRecord, entriedSalesDetails);
            {
                goodsUnitData.EnterpriseCode= userAnsweredRecord.EnterpriseCode;    // 企業コード
                goodsUnitData.SectionCode   = userAnsweredRecord.InqOtherSecCd;     // 拠点コード
                
                if (entriedSalesDetails != null && entriedSalesDetails.Length > 0)
                {
                    #region 登録済み売上明細データから商品情報を構築

                    goodsUnitData.GoodsKindCode         = goodsUnitData.SourceEntriedSalesDetail.GoodsKindCode;         // 商品属性
                    goodsUnitData.GoodsMakerCd          = goodsUnitData.SourceEntriedSalesDetail.GoodsMakerCd;          // 商品メーカーコード
                    goodsUnitData.MakerName             = goodsUnitData.SourceEntriedSalesDetail.MakerName;             // メーカー名称
                    goodsUnitData.MakerKanaName         = goodsUnitData.SourceEntriedSalesDetail.MakerKanaName;         // メーカーカナ名称
                    goodsUnitData.GoodsNo               = goodsUnitData.SourceEntriedSalesDetail.GoodsNo;               // 商品番号
                    goodsUnitData.GoodsName             = goodsUnitData.SourceEntriedSalesDetail.GoodsName;             // 商品名称
                    goodsUnitData.GoodsNameKana         = goodsUnitData.SourceEntriedSalesDetail.GoodsNameKana;         // 商品名称カナ
                    goodsUnitData.GoodsLGroup           = goodsUnitData.SourceEntriedSalesDetail.GoodsLGroup;           // 商品大分類コード
                    goodsUnitData.GoodsLGroupName       = goodsUnitData.SourceEntriedSalesDetail.GoodsLGroupName;       // 商品大分類名称
                    goodsUnitData.GoodsMGroup           = goodsUnitData.SourceEntriedSalesDetail.GoodsMGroup;           // 商品中分類コード
                    goodsUnitData.GoodsMGroupName       = goodsUnitData.SourceEntriedSalesDetail.GoodsMGroupName;       // 商品中分類名称
                    goodsUnitData.BLGroupCode           = goodsUnitData.SourceEntriedSalesDetail.BLGroupCode;           // BLグループコード
                    goodsUnitData.BLGroupName           = goodsUnitData.SourceEntriedSalesDetail.BLGroupName;           // BLグループコード名称
                    goodsUnitData.BLGoodsCode           = goodsUnitData.SourceEntriedSalesDetail.BLGoodsCode;           // BL商品コード
                    goodsUnitData.BLGoodsFullName       = goodsUnitData.SourceEntriedSalesDetail.BLGoodsFullName;       // BL商品コード名称(全角)
                    goodsUnitData.EnterpriseGanreCode   = goodsUnitData.SourceEntriedSalesDetail.EnterpriseGanreCode;   // 自社分類コード
                    goodsUnitData.EnterpriseGanreName   = goodsUnitData.SourceEntriedSalesDetail.EnterpriseGanreName;   // 自社分類名称
                    goodsUnitData.GoodsRateRank         = goodsUnitData.SourceEntriedSalesDetail.GoodsRateRank;         // 商品掛率ランク
                    goodsUnitData.GoodsRateGrpCode      = goodsUnitData.SourceEntriedSalesDetail.RateGoodsRateGrpCd;    // 商品掛率グループコード(掛率)
                    goodsUnitData.GoodsRateGrpName      = goodsUnitData.SourceEntriedSalesDetail.RateGoodsRateGrpNm;    // 商品掛率グループ名称(掛率)
                    goodsUnitData.SalesCode             = goodsUnitData.SourceEntriedSalesDetail.SalesCode;             // 販売区分コード
                    goodsUnitData.SalesCodeName         = goodsUnitData.SourceEntriedSalesDetail.SalesCdNm;             // 販売区分名称
                    goodsUnitData.TaxationDivCd         = goodsUnitData.SourceEntriedSalesDetail.TaxationDivCd;         // 課税区分
                    goodsUnitData.SupplierCd            = goodsUnitData.SourceEntriedSalesDetail.SupplierCd;            // 仕入先コード
                    goodsUnitData.SupplierSnm           = goodsUnitData.SourceEntriedSalesDetail.SupplierSnm;           // 仕入先略称
                    goodsUnitData.PrtGoodsNo            = goodsUnitData.SourceEntriedSalesDetail.PrtGoodsNo;            // 印刷用品番
                    goodsUnitData.PrtMakerCode          = goodsUnitData.SourceEntriedSalesDetail.PrtMakerCode;          // 印刷用メーカーコード
                    goodsUnitData.PrtMakerName          = goodsUnitData.SourceEntriedSalesDetail.PrtMakerName;          // 印刷用メーカー名称
                    // ADD 2014/07/23 Redmine#43080の2SCM受発注明細データに在庫状況区分のセット----------------------->>>>>
                    goodsUnitData.PrmSetDtlNo2 = goodsUnitData.SourceAnsweredRecord.PrmSetDtlNo2;              // 優良設定詳細コード２
                    goodsUnitData.PrmSetDtlName2 = goodsUnitData.SourceAnsweredRecord.PrmSetDtlName2;            // 優良設定詳細名称２
                    // ADD 2014/07/23 Redmine#43080の2SCM受発注明細データに在庫状況区分のセット-----------------------<<<<<

                    // ADD 2015/03/03 SCM高速化Redmine#300対応 ------------------------------------>>>>>
                    goodsUnitData.PrmSetDtlName2ForFac = goodsUnitData.SourceAnsweredRecord.PrmSetDtlName2ForFac;   // 優良設定詳細名称２（工場向け）
                    goodsUnitData.PrmSetDtlName2ForCOw = goodsUnitData.SourceAnsweredRecord.PrmSetDtlName2ForCOw;   // 優良設定詳細名称２（カーオーナー向け）
                    // ADD 2015/03/03 SCM高速化Redmine#300対応 ------------------------------------<<<<<

                    //>>>2012/02/07
                    //// 2012/01/16 Add >>>
                    //goodsUnitData.GoodsSpecialNote = goodsUnitData.SourceEntriedSalesDetail.GoodsSpecialNote;
                    //// 2012/01/16 Add <<<
                    goodsUnitData.GoodsSpecialNote = goodsUnitData.SourceEntriedSalesDetail.GoodsSpecialNote;
                    // DEL 2015/02/04 豊沢 PM-SCM社内障害一覧No.72対応 ------------------------------------------>>>>>
                    //if (goodsUnitData.SourceEntriedSalesDetail.GoodsSpecialNote.Length > 40) goodsUnitData.GoodsSpecialNote = goodsUnitData.SourceEntriedSalesDetail.GoodsSpecialNote.Substring(0, 40);
                    // DEL 2015/02/04 豊沢 PM-SCM社内障害一覧No.72対応 ------------------------------------------<<<<<
                    //<<<2012/02/07
                    
                    // 2011/02/18 Add >>>
                    goodsUnitData.SelectedWarehouseCode = goodsUnitData.SourceEntriedSalesDetail.WarehouseCode;         // 倉庫コード
                    goodsUnitData.StockList = new List<Stock>();
                    // 2011/02/18 Add <<<

                    #endregion // 登録済み売上明細データから商品情報を構築
                }
                else
                {
                    #region 回答済み回答データから商品情報を構築

                    goodsUnitData.BLGoodsCode   = userAnsweredRecord.BLGoodsCode;       // BL商品コード
                    goodsUnitData.GoodsName     = userAnsweredRecord.AnsGoodsName;      // 商品名(カナ)
                    goodsUnitData.GoodsNo       = userAnsweredRecord.GoodsNo;           // 商品番号
                    goodsUnitData.GoodsMakerCd  = userAnsweredRecord.GoodsMakerCd;      // 商品メーカーコード
                    goodsUnitData.MakerName     = userAnsweredRecord.GoodsMakerNm;      // 商品メーカー名称
                    goodsUnitData.SelectedWarehouseCode = userAnsweredRecord.PmWarehouseCd;      // PM倉庫コード // ADD 2011/08/10

                    #endregion // 回答済み回答データから商品情報を構築
                }
            }
            return goodsUnitData;
        }

        // ----- ADD 2011/08/10 ----->>>>>
        /// <summary>
        /// 回答済み商品検索結果項目を生成します。
        /// </summary>
        /// <param name="scmOrderDetailRecord">検索条件</param>
        /// <param name="searchedType">検索種別</param>
        /// <returns>
        /// 発行済み売上明細データまたは回答済みSCM受注明細データ(回答)からの商品検索結果項目
        /// （売上明細データまたは回答データから取得できるプロパティのみ設定されます）
        /// </returns>
        public static GoodsUnitData CreateAnsweredGoodsUnitDataForPccuoe(SCMOrderDetailRecordType scmOrderDetailRecord, SCMSearchedResult.GoodsSearchDivCd searchedType)
        {
            const string CONST_GOODSNAME = "ｶﾞｲﾄｳﾅｼ";
            GoodsUnitData goodsUnitData = new GoodsUnitData();

            switch (searchedType)
            {
                // 品番検索の場合
                case SCMSearchedResult.GoodsSearchDivCd.GoodsNo:
                    {
                        goodsUnitData.EnterpriseCode = scmOrderDetailRecord.EnterpriseCode;    // 企業コード
                        goodsUnitData.SectionCode = scmOrderDetailRecord.InqOtherSecCd;     // 拠点コード
                        goodsUnitData.GoodsMakerCd = scmOrderDetailRecord.GoodsMakerCd;          // 商品メーカーコード
                        goodsUnitData.GoodsNo = scmOrderDetailRecord.GoodsNo;               // 商品番号
                        goodsUnitData.GoodsName = CONST_GOODSNAME;             // 商品名称

                        break;
                    }

                // BLコード検索の場合
                case SCMSearchedResult.GoodsSearchDivCd.BLCode:
                    {
                        goodsUnitData.EnterpriseCode = scmOrderDetailRecord.EnterpriseCode;    // 企業コード
                        goodsUnitData.SectionCode = scmOrderDetailRecord.InqOtherSecCd;     // 拠点コード
                        goodsUnitData.BLGoodsCode = scmOrderDetailRecord.BLGoodsCode;    // BLコード

                        BLGoodsCdAcs _bLGoodsCdAcs = new BLGoodsCdAcs();
                        BLGoodsCdUMnt bLGoodsCdUMnt = null;

                        int sta = _bLGoodsCdAcs.Read(out bLGoodsCdUMnt, scmOrderDetailRecord.EnterpriseCode, scmOrderDetailRecord.BLGoodsCode);
                        if (sta.Equals((int)ResultUtil.ResultCode.Normal) && bLGoodsCdUMnt != null)
                        {
                            goodsUnitData.GoodsName = bLGoodsCdUMnt.BLGoodsHalfName; // 商品名称
                        }
                        else
                        {
                            goodsUnitData.GoodsName = CONST_GOODSNAME;             // 商品名称
                        }

                        break;
                    }

                // 用品の場合
                case SCMSearchedResult.GoodsSearchDivCd.GoodsName:
                    {
                        goodsUnitData.EnterpriseCode = scmOrderDetailRecord.EnterpriseCode;    // 企業コード
                        goodsUnitData.SectionCode = scmOrderDetailRecord.InqOtherSecCd;     // 拠点コード
                        // UPD 2013/02/13 SCM障害追加②対応 2013/03/06配信-------------------------------------------->>>>>
                        //goodsUnitData.GoodsName = scmOrderDetailRecord.InqGoodsName;             // 商品名称
                        goodsUnitData.GoodsName = CONST_GOODSNAME;                                 // 商品名称
                        // UPD 2013/02/13 SCM障害追加②対応 --------------------------------------------<<<<<

                        break;
                    }
                default:
                    break;                    
            }
            goodsUnitData.StockList = new List<Stock>();
            return goodsUnitData;
        }
        // ----- ADD 2011/08/10 -----<<<<<
    }

    /// <summary>
    /// 回答済み商品検索結果項目クラス
    /// </summary>
    public sealed class AnsweredGoodsUnitData : GoodsUnitData
    {
        #region 元となった回答済みデータ

        /// <summary>元となった回答済みデータ</summary>
        private readonly UserSCMOrderAnswerRecord _sourceAnsweredRecord;
        /// <summary>元となった回答済みデータを取得します。</summary>
        public UserSCMOrderAnswerRecord SourceAnsweredRecord { get { return _sourceAnsweredRecord; } }

        #endregion // 元となった回答済みデータ

        #region 元となった登録済み売上明細データ

        /// <summary>元となった登録済み売上明細データ</summary>
        private readonly SalesDetailWork[] _sourceEntriedSalesDetails;
        /// <summary>元となった登録済み売上明細データを取得します。（見積計上を想定しているため、見積伝票のデータとなります）</summary>
        public SalesDetailWork SourceEntriedSalesDetail
        {
            get
            {
                if (_sourceEntriedSalesDetails == null || _sourceEntriedSalesDetails.Length.Equals(0)) return null;

                Debug.Assert(_sourceEntriedSalesDetails.Length.Equals(1), "対応する見積明細データが1件ではありません。");

                const int SINGLE_ITEM = 0;  // 対応する明細は1件だけのはず
                return _sourceEntriedSalesDetails[SINGLE_ITEM];
            }
        }

        #endregion // 元となった登録済み売上明細データ

        #region 価格情報

        /// <summary>価格情報リスト</summary>
        private List<UnitPriceCalcRet> _unitPriceList;
        /// <summary>価格情報リストを取得します。</summary>
        public List<UnitPriceCalcRet> UnitPriceList
        {
            get
            {
                if (_unitPriceList == null)
                {
                    _unitPriceList = CreateUnitPriceList(SourceEntriedSalesDetail, SourceAnsweredRecord);
                }
                return _unitPriceList;
            }
        }

        /// <summary>
        /// 価格情報リストを生成します。
        /// </summary>
        /// <param name="sourceEntriedSalesDetail">元となる回答データ</param>
        /// <param name="sourceAnsweredRecord">元となる売上明細データ</param>
        /// <returns>価格情報リスト</returns>
        private static List<UnitPriceCalcRet> CreateUnitPriceList(
            SalesDetailWork sourceEntriedSalesDetail,
            UserSCMOrderAnswerRecord sourceAnsweredRecord
        )
        {
            List<UnitPriceCalcRet> unitPriceList = new List<UnitPriceCalcRet>();
            {
                if (sourceEntriedSalesDetail != null)
                {
                    #region 売上明細より構築

                    // 定価
                    if (sourceEntriedSalesDetail.ListPriceTaxExcFl > 0.0)
                    {
                        UnitPriceCalcRet listPrice = new UnitPriceCalcRet();
                        {
                            listPrice.UnitPriceKind = UnitPriceCalculation.ctUnitPriceKind_ListPrice;
                            listPrice.SectionCode = sourceEntriedSalesDetail.SectionCode;   // 014.拠点コード

                            listPrice.RateVal = sourceEntriedSalesDetail.ListPriceRate;                 // 050.定価率               …単価算出戻りパラメータ(UnitPriceCalcRet)
                            listPrice.SectionCode = sourceEntriedSalesDetail.RateSectPriceUnPrc;        // 051.掛率設定拠点(定価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            listPrice.RateSettingDivide = sourceEntriedSalesDetail.RateDivLPrice;       // 052.掛率設定区分(定価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            listPrice.UnitPrcCalcDiv = sourceEntriedSalesDetail.UnPrcCalcCdLPrice;      // 053.単価算出区分(定価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            listPrice.PriceDiv = sourceEntriedSalesDetail.PriceCdLPrice;                // 054.価格区分(定価)       …単価算出戻りパラメータ(UnitPriceCalcRet)
                            listPrice.StdUnitPrice = sourceEntriedSalesDetail.StdUnPrcLPrice;           // 055.基準単価(定価)       …単価算出戻りパラメータ(UnitPriceCalcRet)
                            listPrice.UnPrcFracProcUnit = sourceEntriedSalesDetail.FracProcUnitLPrice;  // 056.端数処理単位(定価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            listPrice.UnPrcFracProcDiv = sourceEntriedSalesDetail.FracProcLPrice;       // 057.端数処理(定価)       …単価算出戻りパラメータ(UnitPriceCalcRet)
                            listPrice.UnitPriceTaxIncFl = sourceEntriedSalesDetail.ListPriceTaxIncFl;   // 058.定価(税込,浮動)      …単価算出戻りパラメータ(UnitPriceCalcRet)
                            listPrice.UnitPriceTaxExcFl = sourceEntriedSalesDetail.ListPriceTaxExcFl;   // 059.定価(税抜,浮動)      …単価算出戻りパラメータ(UnitPriceCalcRet)
                        }
                        unitPriceList.Add(listPrice);
                    }
                    // 単価
                    if (sourceEntriedSalesDetail.SalesUnPrcTaxExcFl > 0.0)
                    {
                        UnitPriceCalcRet unitPrice = new UnitPriceCalcRet();
                        {
                            unitPrice.UnitPriceKind = UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice;
                            unitPrice.SectionCode = sourceEntriedSalesDetail.SectionCode;   // 014.拠点コード

                            unitPrice.RateVal = sourceEntriedSalesDetail.SalesRate;                         // 061.売価率               …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitPrice.SectionCode = sourceEntriedSalesDetail.RateSectSalUnPrc;              // 062.掛率設定拠点(売価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitPrice.RateSettingDivide = sourceEntriedSalesDetail.RateDivSalUnPrc;         // 063.掛率設定区分(売価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitPrice.UnitPrcCalcDiv = sourceEntriedSalesDetail.UnPrcCalcCdSalUnPrc;        // 064.単価算出区分(売価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitPrice.PriceDiv = sourceEntriedSalesDetail.PriceCdSalUnPrc;                  // 065.価格区分(売価)       …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitPrice.StdUnitPrice = sourceEntriedSalesDetail.StdUnPrcSalUnPrc;             // 066.基準単価(売価)       …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitPrice.UnPrcFracProcUnit = sourceEntriedSalesDetail.FracProcUnitSalUnPrc;    // 067.端数処理単位(売価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitPrice.UnPrcFracProcDiv = sourceEntriedSalesDetail.FracProcSalUnPrc;         // 068.端数処理(売価)       …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitPrice.UnitPriceTaxIncFl = sourceEntriedSalesDetail.SalesUnPrcTaxIncFl;      // 069.売価(税込,浮動)      …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitPrice.UnitPriceTaxExcFl = sourceEntriedSalesDetail.SalesUnPrcTaxExcFl;      // 070.売価(税抜,浮動)      …単価算出戻りパラメータ(UnitPriceCalcRet)
                        }
                        unitPriceList.Add(unitPrice);
                    }
                    // 原価
                    if (sourceEntriedSalesDetail.SalesUnitCost > 0.0)
                    {
                        UnitPriceCalcRet unitCost = new UnitPriceCalcRet();
                        {
                            unitCost.UnitPriceKind = UnitPriceCalculation.ctUnitPriceKind_UnitCost;
                            unitCost.SectionCode = sourceEntriedSalesDetail.SectionCode;    // 014.拠点コード

                            unitCost.RateVal = sourceEntriedSalesDetail.CostRate;                       // 072.原価率                   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitCost.SectionCode = sourceEntriedSalesDetail.RateSectCstUnPrc;           // 073.掛率設定拠点(原価単価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitCost.RateSettingDivide = sourceEntriedSalesDetail.RateDivUnCst;         // 074.掛率設定区分(原価単価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitCost.UnitPrcCalcDiv = sourceEntriedSalesDetail.UnPrcCalcCdUnCst;        // 075.単価算出区分(原価単価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitCost.PriceDiv = sourceEntriedSalesDetail.PriceCdUnCst;                  // 076.価格区分(原価単価)       …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitCost.StdUnitPrice = sourceEntriedSalesDetail.StdUnPrcUnCst;             // 077.基準単価(原価単価)       …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitCost.UnPrcFracProcUnit = sourceEntriedSalesDetail.FracProcUnitUnCst;    // 078.端数処理単位(原価単価)   …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitCost.UnPrcFracProcDiv = sourceEntriedSalesDetail.FracProcUnCst;         // 079.端数処理(原価単価)       …単価算出戻りパラメータ(UnitPriceCalcRet)
                            unitCost.UnitPriceTaxExcFl = sourceEntriedSalesDetail.SalesUnitCost;        // 080.原価単価                 …単価算出戻りパラメータ(UnitPriceCalcRet)
                        }
                        unitPriceList.Add(unitCost);
                    }

                    #endregion // 売上明細より構築
                }
                else
                {
                    #region 回答データより構築

                    // 定価
                    if (sourceAnsweredRecord.ListPrice > 0)
                    {
                        UnitPriceCalcRet listPrice = new UnitPriceCalcRet();
                        {
                            listPrice.UnitPriceKind = UnitPriceCalculation.ctUnitPriceKind_ListPrice;
                            listPrice.SectionCode = sourceAnsweredRecord.InqOtherSecCd;

                            listPrice.GoodsMakerCd = sourceAnsweredRecord.GoodsMakerCd;             // 商品メーカーコード
                            listPrice.GoodsNo = sourceAnsweredRecord.GoodsNo;                       // 商品番号
                            listPrice.UnitPriceTaxExcFl = (double)sourceAnsweredRecord.ListPrice;   // 定価
                        }
                        unitPriceList.Add(listPrice);
                    }
                    // 単価
                    if (sourceAnsweredRecord.UnitPrice > 0)
                    {
                        UnitPriceCalcRet unitPrice = new UnitPriceCalcRet();
                        {
                            unitPrice.UnitPriceKind = UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice;
                            unitPrice.SectionCode = sourceAnsweredRecord.InqOtherSecCd;

                            unitPrice.GoodsMakerCd = sourceAnsweredRecord.GoodsMakerCd;             // 商品メーカーコード
                            unitPrice.GoodsNo = sourceAnsweredRecord.GoodsNo;                       // 商品番号
                            unitPrice.UnitPriceTaxExcFl = (double)sourceAnsweredRecord.UnitPrice;   // 単価
                        }
                        unitPriceList.Add(unitPrice);
                    }

                    #endregion // 回答データより構築
                }
            }
            return unitPriceList;
        }

        #endregion // 価格情報

        #region Constructor

        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="sourceAnsweredRecord">元となった回答済みデータ</param>
        /// <param name="sourceEntriedSalesDetails">元となった登録済み売上明細データ</param>
        public AnsweredGoodsUnitData(
            UserSCMOrderAnswerRecord sourceAnsweredRecord,
            SalesDetailWork[] sourceEntriedSalesDetails
        ) : base()
        {
            _sourceAnsweredRecord       = sourceAnsweredRecord;
            _sourceEntriedSalesDetails  = sourceEntriedSalesDetails;

            StockList = new List<Stock>();  // HACK:在庫情報は無視してよい？
        }

        #endregion // Constructor

        /// <summary>
        /// 売上計上します。(回答データに前回の回答データの情報を設定します)
        /// </summary>
        /// <param name="userAnswerRecord">回答データ</param>
        public void AddUpSalesDetail(UserSCMOrderAnswerRecord userAnswerRecord)
        {
            #region Guard Phrase

            if (userAnswerRecord == null) return;
            if (SourceAnsweredRecord == null) return;

            #endregion // Guard Phrase

            //if (userAnswerRecord.UnitPrice >= 0)    // 負の値≡SCM品目設定で価格設定しない印 // DEL 2011/08/10
            if (userAnswerRecord.UnitPrice >= 0 && SourceEntriedSalesDetail != null)    // 負の値≡SCM品目設定で価格設定しない印 // ADD 2011/08/10
            {
                userAnswerRecord.UnitPrice = (long)SourceEntriedSalesDetail.SalesUnPrcTaxIncFl;
            }

            // 2011/02/14 Add >>>
            // 計上元明細の受注ステータスが「売上」の場合は、返品データを生成する
            if (SourceAnsweredRecord.AcptAnOdrStatus == (int)AcptAnOdrStatus.Sales)
            {
                userAnswerRecord.DeliveredGoodsCount *= -1;
                userAnswerRecord.CancelCndtinDiv = (int)CancelCndtinDiv.Cancelled;

                // 2011/02/18 Add >>>
                userAnswerRecord.AnswerDeliveryDate = SourceAnsweredRecord.AnswerDeliveryDate;
                // 2011/02/18 Add <<<
            }
            // 2011/02/14 Add <<<

            // 回答済み商品検索結果では在庫情報を取得していないので、倉庫由来のデータを再設定
            userAnswerRecord.ShelfNo = SourceAnsweredRecord.ShelfNo;
            userAnswerRecord.StockDiv= SourceAnsweredRecord.StockDiv;
        }

        /// <summary>
        /// 売上計上します。(売上明細データに前回の見積明細データの情報を設定します)
        /// </summary>
        /// <param name="salesDetail">売上明細データ</param>
        /// <br>UpdateNote : 2011/07/20 譚洪 Redmine#23082 標準価格と原単価の水色の設定の修正</br>
        /// <br>UpdateNote : 2011/09/15 譚洪 Redmine#24913 倉庫コードを入力可能にして、伝票発行可能の修正</br>
        /// <br>UpdateNote : 2011/09/20 朱宝軍 Redmine#25362 SCM PM側　SFから返品した場合に関して</br>
        public void AddUpSalesDetail(SalesDetail salesDetail)
        {
            #region Guard Phrase

            if (salesDetail == null) return;
            if (SourceEntriedSalesDetail == null) return;

            #endregion // Guard Phrase

            // 2011/09/15 Del >>> 
            //salesDetail.AcptAnOdrStatusSrc = SourceEntriedSalesDetail.AcptAnOdrStatus;  // 計上元受注ステータス
            // --- ADD s.sannohe 2012/05/18 ---------->>>>>
            // DEL 2013/05/13 SCM障害№10530対応 --------------------------------->>>>>
            //salesDetail.AcceptAnOrderNo = SourceEntriedSalesDetail.AcceptAnOrderNo;     // 計上元受注番号
            // DEL 2013/05/13 SCM障害№10530対応 ---------------------------------<<<<<
            // --- ADD s.sannohe 2012/05/18 ----------<<<<<
            salesDetail.AcptAnOdrStatusSrc = SourceEntriedSalesDetail.AcptAnOdrStatus;  // 計上元受注ステータス// 2011/09/20 Add 
            salesDetail.SalesSlipDtlNumSrc = SourceEntriedSalesDetail.SalesSlipDtlNum;  // 計上元明細通番
            // 2011/09/15 Del <<<

            // 2011/02/18 Del >>>
            //salesDetail.ShipmentCnt = SourceEntriedSalesDetail.AcptAnOdrRemainCnt;          // 出荷数
            // 2011/02/18 Del <<<
            // salesDetail.ShipmentCntDisplay = SourceEntriedSalesDetail.AcptAnOdrRemainCnt;   // 出荷数(表示)…SalesDetailDataTableの項目
            salesDetail.ShipmentCntDefault = SourceEntriedSalesDetail.AcptAnOdrRemainCnt;   // 出荷数初期化
            // salesDetail.AddUpEnableCnt = SourceEntriedSalesDetail.AcptAnOdrRemainCnt;   // 計上可能数…SalesDetailDataTableの項目
            // salesDetail.AlreadyAddUpCnt = 0;            // 計上済数量…SalesDetailDataTableの項目
            // salesDetail.AcceptAnOrderCntDisplay = 0;    // 受注数(表示)…SalesDetailDataTableの項目
            salesDetail.AcceptAnOrderCntDefault = SourceEntriedSalesDetail.AcceptAnOrderCnt;    // 受注数初期化
            // 2011/02/18 Del >>>
            //salesDetail.AcceptAnOrderCnt = SourceEntriedSalesDetail.AcceptAnOrderCnt;           // 受注数
            // 2011/02/18 Del <<<
            salesDetail.AcptAnOdrAdjustCnt = 0; // 受注調整数
            // 2012/05/15 Del >>>
            //salesDetail.AcptAnOdrRemainCnt = 0; // 受注残数
            // 2012/05/15 Del <<<
            // --- ADD 2011/07/20  ---- >>>>>>>>
            salesDetail.CampaignCode = SourceEntriedSalesDetail.CampaignCode;  // キャンペーンコード 
            salesDetail.BfListPrice = SourceEntriedSalesDetail.BfListPrice;
            salesDetail.BfUnitCost = SourceEntriedSalesDetail.BfUnitCost;
            salesDetail.BfSalesUnitPrice = SourceEntriedSalesDetail.BfSalesUnitPrice;
            // --- ADD 2011/07/20  ---- <<<<<<<<
            // 2011/02/14 Add >>>
            // 計上元の受注ステータス＝売上の場合は返品として判断する
            if (salesDetail.AcptAnOdrStatusSrc == (int)AcptAnOdrStatus.Sales)
            {
                //salesDetail.ShipmentCnt *= -1;          // 出荷数←残
                //salesDetail.ShipmentCntDefault *= -1;   // 出荷数(初期値)
                //salesDetail.AcceptAnOrderCntDefault *= -1;   // 出荷数(表示)←残
                //salesDetail.AcceptAnOrderCnt *= -1;       // 計上可能数←残

                //salesDetail.AcptAnOdrStatus = SourceEntriedSalesDetail.AcptAnOdrStatus;  // 計上元受注ステータス
                //salesDetail.SalesSlipDtlNum = SourceEntriedSalesDetail.SalesSlipDtlNum;  // 計上元明細通番
                //salesDetail.AcptAnOdrStatusSrc =0;                                       // 受注ステータス
                //salesDetail.SalesSlipDtlNumSrc = 0;                                      // 計上元明細通番

                // 返品時、元明細より再セット
                salesDetail.AcptAnOdrRemainCnt = SourceEntriedSalesDetail.AcptAnOdrRemainCnt;
                salesDetail.ShipmentCnt = SourceEntriedSalesDetail.ShipmentCnt;
                salesDetail.AcptAnOdrAdjustCnt = SourceEntriedSalesDetail.AcptAnOdrAdjustCnt;
                salesDetail.AcceptAnOrderCnt = SourceEntriedSalesDetail.AcceptAnOrderCnt;    


                salesDetail.SalesSlipCdDtl = 1;
            }
            // 2011/02/14 Add <<<

            // 回答済み商品検索結果では在庫情報を取得していないので、倉庫由来のデータを再設定
            salesDetail.WarehouseCode = SourceEntriedSalesDetail.WarehouseCode;         // 043.倉庫コード
            salesDetail.WarehouseName = SourceEntriedSalesDetail.WarehouseName;         // 044.倉庫名称
            salesDetail.WarehouseShelfNo = SourceEntriedSalesDetail.WarehouseShelfNo;   // 045.倉庫棚番
            salesDetail.SalesOrderDivCd = SourceEntriedSalesDetail.SalesOrderDivCd;     // 046.売上在庫取寄せ区分

            // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
            salesDetail.CmpltSalesRowNo = SourceEntriedSalesDetail.CmpltSalesRowNo;      // 純正-BL商品コード
            salesDetail.CmpltGoodsMakerCd = SourceEntriedSalesDetail.CmpltGoodsMakerCd;  // 純正-メーカー
            salesDetail.CmpltGoodsName = SourceEntriedSalesDetail.CmpltGoodsName;        // 純正-商品番号
            salesDetail.CmpltSalesUnPrcFl = SourceEntriedSalesDetail.CmpltSalesUnPrcFl;  // 純正-定価
            // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>

            //2012/05/07 T.Nishi ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            if (SourceEntriedSalesDetail.AutoAnswerDivSCM == 2)  //前回、自動回答の場合
            {
                // --- UPD 三戸 2012/06/06 №10282 ---------->>>>>
                //if (salesDetail.SalesSlipCdDtl != 1)  //返品以外の場合
                if ((salesDetail.SalesSlipCdDtl != (int)SalesSlipInputAcs.SalesSlipCdDtl.Sales)
                    && (salesDetail.SalesSlipCdDtl != (int)SalesSlipInputAcs.SalesSlipCdDtl.RetGoods)) //売上、返品以外の場合
                // --- UPD 三戸 2012/06/06 №10282 ----------<<<<<
                {
                    if (salesDetail.SalesSlipCdDtl != 1)  //返品以外の場合
                    {
                        // 販売区分設定（クリア）
                        salesDetail.SalesCode = 0;            // 090.販売区分コード
                        salesDetail.SalesCdNm = "";           // 091.販売区分名称
                    }
                }
                else  //今回、自動回答の場合
                {
                    //上書きしない
                }
            }
            else  //前回手動回答の場合
            {
                //上書きしない
            }
            //2012/05/07 T.Nishi ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }
    }
    // ADD 2010/04/05 以前に見積伝票データを作成している発注の場合、作成する回答データおよび売上伝票データは見積伝票データを元に作成する ----------<<<<<
}
