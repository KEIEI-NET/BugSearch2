//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : BLグループマスタ（エクスポート）
// プログラム概要   : BLグループマスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/13  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// BLコードマスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : BLコードマスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br></br>
    /// </remarks>
    public class BLGroupSetExpAcs
    {

        private static bool _isLocalDBRead = false;

        private BLGroupUAcs _bLGroupUAcs;

        private Dictionary<int, UserGdBd> _salesCodeDic;
        private Dictionary<int, UserGdBd> _goodsLGroupDic;
        private UserGuideAcs _userGuideAcs;

        private Dictionary<int, GoodsGroupU> _goodsGroupDic;
        private GoodsGroupUAcs _goodsGroupUAcs;

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
        /// ＢＬグループマスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＢＬグループマスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public BLGroupSetExpAcs()
        {
            this._goodsGroupUAcs = new GoodsGroupUAcs();
            this._userGuideAcs = new UserGuideAcs();
        }

        /// <summary>オンラインモードの列挙型です。</summary>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }

        /// <summary>
        /// ＢＬグループマスタ全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="BLGroupExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ＢＬグループマスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, BLGroupExportWork BLGroupExportWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, BLGroupExportWork);
        }

        /// <summary>
        /// ＢＬグループマスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="BLGroupExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ＢＬグループマスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, BLGroupExportWork BLGroupExportWork)
        {

            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, BLGroupExportWork);
        }

        /// <summary>
        /// ＢＬグループマスタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="BLGroupExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ＢＬグループマスタの検索処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, BLGroupExportWork BLGroupExportWork)
        {
            this._bLGroupUAcs = new BLGroupUAcs();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList bLGroupUs = null;

            status = this._bLGroupUAcs.SearchAll(
                                out bLGroupUs,
                                enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                foreach (BLGroupU bLGroupU in bLGroupUs)
                {
                    // 抽出処理
                    checkstatus = DataCheck(bLGroupU, BLGroupExportWork);
                    if (checkstatus == 0)
                    {

                        //ＢＬグループ情報クラスへメンバコピー
                        retList.Add(CopyToBLGroupSetExpFromSecInfoSetWork(bLGroupU, enterpriseCode));

                    }
                }
            }
            else
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            //全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// クラスメンバーコピー処理（ＢＬグループマスタワーククラス⇒ＢＬグループマスタクラス）
        /// </summary>
        /// <param name="bLGroupU">ＢＬグループマスタワーククラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ＢＬグループマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : ＢＬグループマスタワーククラスからＢＬグループマスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private BLGroupSetExp CopyToBLGroupSetExpFromSecInfoSetWork(BLGroupU bLGroupU, string enterpriseCode)
        {

            BLGroupSetExp bLGroupSetExp = new BLGroupSetExp();

            bLGroupSetExp.BLGroupCode = bLGroupU.BLGroupCode;
            bLGroupSetExp.BLGroupName = bLGroupU.BLGroupName;
            bLGroupSetExp.BLGroupKanaName = bLGroupU.BLGroupKanaName;
            bLGroupSetExp.SalesCode = bLGroupU.SalesCode;
            bLGroupSetExp.SalesCodeName = GetSalesCodeName(bLGroupU.SalesCode, enterpriseCode);
            bLGroupSetExp.GoodsLGroup = bLGroupU.GoodsLGroup;
            bLGroupSetExp.GoodsLGroupName = GetGoodsLGroupName(bLGroupU.GoodsLGroup, enterpriseCode);
            bLGroupSetExp.GoodsMGroup = bLGroupU.GoodsMGroup;
            bLGroupSetExp.GoodsMGroupName = GetGoodsMGroupName(bLGroupU.GoodsMGroup, enterpriseCode);

            return bLGroupSetExp;
        }

        /// <summary>
        /// 販売区分名称取得処理
        /// </summary>
        /// <param name="salesCode">販売区分コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 販売区分名称を取得します。</br>
        /// </remarks>
        private string GetSalesCodeName(int salesCode, string enterpriseCode)
        {
            string salesCodeName = "";
            ReadSalesCode(enterpriseCode);
            if (this._salesCodeDic.ContainsKey(salesCode))
            {
                salesCodeName = this._salesCodeDic[salesCode].GuideName.Trim();
            }

            return salesCodeName;
        }


        /// <summary>
        /// 販売区分読込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 販売区分一覧を読み込みます。</br>
        /// </remarks>
        private void ReadSalesCode(string enterpriseCode)
        {
            try
            {
                if (this._salesCodeDic.Count == 0)
                {
                    this._salesCodeDic = new Dictionary<int, UserGdBd>();

                    ArrayList retList;

                    // ユーザーガイドデータ取得(販売区分)
                    int status = GetUserGuideBd(out retList, 71, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (UserGdBd userGdBd in retList)
                        {
                            if (userGdBd.LogicalDeleteCode == 0)
                            {
                                this._salesCodeDic.Add(userGdBd.GuideCode, userGdBd);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._salesCodeDic = new Dictionary<int, UserGdBd>();

                ArrayList retList;

                // ユーザーガイドデータ取得(販売区分)
                int status = GetUserGuideBd(out retList, 71, enterpriseCode);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._salesCodeDic.Add(userGdBd.GuideCode, userGdBd);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// 商品大分類名称取得処理
        /// </summary>
        /// <param name="goodsLGroupCode">商品大分類コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 商品大分類名称を取得します。</br>
        /// </remarks>
        private string GetGoodsLGroupName(int goodsLGroupCode, string enterpriseCode)
        {
            string goodsLGroupName = "";
            ReadGoodsLGroup(enterpriseCode);
            if (this._goodsLGroupDic.ContainsKey(goodsLGroupCode))
            {
                goodsLGroupName = this._goodsLGroupDic[goodsLGroupCode].GuideName.Trim();
            }

            return goodsLGroupName;
        }

        /// <summary>
        /// 商品大分類読込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 商品大分類一覧を読み込みます。</br>
        /// </remarks>
        private void ReadGoodsLGroup(string enterpriseCode)
        {
            try
            {
                if (this._goodsLGroupDic.Count == 0)
                {
                    this._goodsLGroupDic = new Dictionary<int, UserGdBd>();

                    ArrayList retList;

                    // ユーザーガイドデータ取得(商品大分類)
                    int status = GetUserGuideBd(out retList, 70, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (UserGdBd userGdBd in retList)
                        {
                            if (userGdBd.LogicalDeleteCode == 0)
                            {
                                this._goodsLGroupDic.Add(userGdBd.GuideCode, userGdBd);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._goodsLGroupDic = new Dictionary<int, UserGdBd>();

                ArrayList retList;

                // ユーザーガイドデータ取得(商品大分類)
                int status = GetUserGuideBd(out retList, 70, enterpriseCode);
                if (status == 0)
                {
                    foreach (UserGdBd userGdBd in retList)
                    {
                        if (userGdBd.LogicalDeleteCode == 0)
                        {
                            this._goodsLGroupDic.Add(userGdBd.GuideCode, userGdBd);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// ユーザーガイドデータ取得処理
        /// </summary>
        /// <param name="retList"></param>
        /// <param name="userGuideDivCd"></param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : ユーザーガイドデータを取得します。</br>
        /// </remarks>
        private int GetUserGuideBd(out ArrayList retList, int userGuideDivCd, string enterpriseCode)
        {
            int status;
            retList = new ArrayList();

            status = this._userGuideAcs.SearchAllDivCodeBody(out retList, enterpriseCode,
                                                             userGuideDivCd, UserGuideAcsData.UserBodyData);

            return status;
        }

        /// <summary>
        /// 商品中分類名称取得処理
        /// </summary>
        /// <param name="goodsMGroupCode">商品中分類コード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 商品中分類名称を取得します。</br>
        /// </remarks>
        private string GetGoodsMGroupName(int goodsMGroupCode, string enterpriseCode)
        {
            string goodsMGroupName = "";
            ReadGoodsMGroup(enterpriseCode);
            if (this._goodsGroupDic.ContainsKey(goodsMGroupCode))
            {
                goodsMGroupName = this._goodsGroupDic[goodsMGroupCode].GoodsMGroupName.Trim();
            }

            return goodsMGroupName;
        }

        /// <summary>
        /// 商品中分類読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 商品中分類一覧を読み込みます。</br>
        /// </remarks>
        private void ReadGoodsMGroup(string enterpriseCode)
        {
            try
            {
                if (this._goodsGroupDic.Count == 0)
                {
                    this._goodsGroupDic = new Dictionary<int, GoodsGroupU>();

                    ArrayList retList;

                    int status = this._goodsGroupUAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (GoodsGroupU goodsGroupU in retList)
                        {
                            if (goodsGroupU.LogicalDeleteCode == 0)
                            {
                                this._goodsGroupDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupDic = new Dictionary<int, GoodsGroupU>();

                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="bLGroupU"></param>
        /// <param name="BLGroupExportWork"></param>
        /// <returns></returns>
        private int DataCheck(BLGroupU bLGroupU, BLGroupExportWork BLGroupExportWork)
        {
            int status = 0;

            // 論理削除区分
            if (bLGroupU.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }

            // 商品BLグループコード
            if (BLGroupExportWork.BLGroupCodeSt != 0 &&
                BLGroupExportWork.BLGroupCodeEd != 0)
            {
                if (bLGroupU.BLGroupCode < BLGroupExportWork.BLGroupCodeSt ||
                   bLGroupU.BLGroupCode > BLGroupExportWork.BLGroupCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (BLGroupExportWork.BLGroupCodeSt != 0)
            {
                if (bLGroupU.BLGroupCode < BLGroupExportWork.BLGroupCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (BLGroupExportWork.BLGroupCodeEd != 0)
            {
                if (bLGroupU.BLGroupCode > BLGroupExportWork.BLGroupCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            // 提供データ区分

            return status;
        }
    }
}
