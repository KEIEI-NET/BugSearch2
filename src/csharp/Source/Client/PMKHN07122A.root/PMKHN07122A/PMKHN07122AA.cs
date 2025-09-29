//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＢＬコードマスタ（エクスポート）
// プログラム概要   : ＢＬコードマスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/12  修正内容 : 新規作成
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
    public class BLGoodsCdSetExpAcs
    {

        private static bool _isLocalDBRead = false;

        private BLGoodsCdAcs _bLGoodsCdAcs;

        private Dictionary<int, BLGroupU> _blGroupUDic;
        private BLGroupUAcs _bLGroupUAcs;

        private Dictionary<int, GoodsGroupU> _goodsGroupUDic;
        private GoodsGroupUAcs _goodsGroupUAcs;

        // 装備分類
        private const int EQUIPGANRE_CODE_0 = 0;
        private const int EQUIPGANRE_CODE_1001 = 1001;
        private const int EQUIPGANRE_CODE_1005 = 1005;
        private const int EQUIPGANRE_CODE_1010 = 1010;
        private const string EQUIPGANRE_NAME_0 = "無し";
        private const string EQUIPGANRE_NAME_1001 = "バッテリー";
        private const string EQUIPGANRE_NAME_1005 = "タイヤ";
        private const string EQUIPGANRE_NAME_1010 = "オイル";

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
        /// BLコードマスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLコードマスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public BLGoodsCdSetExpAcs()
        {
            this._bLGroupUAcs = new BLGroupUAcs();
            this._goodsGroupUAcs = new GoodsGroupUAcs();
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
        /// BLコードマスタ全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <param name="bLGoodsCdExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BLコードマスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, BLGoodsCdExportWork bLGoodsCdExportWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, bLGoodsCdExportWork);
        }

        /// <summary>
        /// BLコードマスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>	
        /// <param name="bLGoodsCdExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BLコードマスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, BLGoodsCdExportWork bLGoodsCdExportWork)
        {

            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, bLGoodsCdExportWork);
        }

        /// <summary>
        /// BLコードマスタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="bLGoodsCdExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : BLコードマスタの検索処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, BLGoodsCdExportWork bLGoodsCdExportWork)
        {

            this._bLGoodsCdAcs = new BLGoodsCdAcs();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList bLGoodsCdUMnts = null;

            status = this._bLGoodsCdAcs.SearchAll(
                                out bLGoodsCdUMnts,
                                enterpriseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                foreach (BLGoodsCdUMnt bLGoodsCdUMnt in bLGoodsCdUMnts)
                {
                    // 抽出処理
                    checkstatus = DataFiler(bLGoodsCdUMnt, bLGoodsCdExportWork);
                    if (checkstatus == 0)
                    {

                        //BLコード情報クラスへメンバコピー
                        retList.Add(CopyToBLGoodsCdSetFromSecInfoSetWork(bLGoodsCdUMnt, enterpriseCode));

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
        /// クラスメンバーコピー処理（BLコードマスタワーククラス⇒BLコードマスタクラス）
        /// </summary>
        /// <param name="bLGoodsCdUMnt">BLコードマスタワーククラス</param>
        /// <param name="enterpriseCode"></param>
        /// <returns>BLコードマスタクラス</returns>
        /// <remarks>
        /// <br>Note       : BLコードマスタワーククラスからBLコードマスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private BLGoodsCdSetExp CopyToBLGoodsCdSetFromSecInfoSetWork(BLGoodsCdUMnt bLGoodsCdUMnt, string enterpriseCode)
        {

            BLGoodsCdSetExp bLGoodsCdSet = new BLGoodsCdSetExp();

            bLGoodsCdSet.BLGoodsCode = bLGoodsCdUMnt.BLGoodsCode;
            bLGoodsCdSet.BLGoodsFullName = bLGoodsCdUMnt.BLGoodsFullName;
            bLGoodsCdSet.BLGoodsHalfName = bLGoodsCdUMnt.BLGoodsHalfName;
            bLGoodsCdSet.BLGroupCode = bLGoodsCdUMnt.BLGloupCode;
            bLGoodsCdSet.BLGroupKanaName = GetBLGroupName(bLGoodsCdUMnt.BLGloupCode, enterpriseCode);
            bLGoodsCdSet.GoodsRateGrpCode = bLGoodsCdUMnt.GoodsRateGrpCode;
            bLGoodsCdSet.GoodsRateGrpCodeName = GetGoodsRateGrpName(bLGoodsCdUMnt.GoodsRateGrpCode, enterpriseCode);
            bLGoodsCdSet.BLGoodsGenreCode = bLGoodsCdUMnt.BLGoodsGenreCode;
            bLGoodsCdSet.BLGoodsGenreCodeName = GetEquipGenreName(bLGoodsCdUMnt.BLGoodsGenreCode);

            return bLGoodsCdSet;
        }

        /// <summary>
        /// BLグループ名称取得処理
        /// </summary>
        /// <param name="blGroupCode">BLグループコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : BLグループ名称を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetBLGroupName(int blGroupCode, string enterpriseCode)
        {
            string blGroupName = "";

            ReadBLGroup(enterpriseCode);
            if (this._blGroupUDic.ContainsKey(blGroupCode))
            {
                blGroupName = this._blGroupUDic[blGroupCode].BLGroupName.Trim();
            }

            return blGroupName;
        }

        /// <summary>
        /// BLグループ読込処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : BLグループ一覧を読み込みます。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ReadBLGroup(string enterpriseCode)
        {
            try
            {
                if (this._blGroupUDic.Count == 0)
                {
                    this._blGroupUDic = new Dictionary<int, BLGroupU>();

                    ArrayList retList;

                    int status = this._bLGroupUAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (BLGroupU bLGroupU in retList)
                        {
                            if (bLGroupU.LogicalDeleteCode == 0)
                            {
                                this._blGroupUDic.Add(bLGroupU.BLGroupCode, bLGroupU);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._blGroupUDic = new Dictionary<int, BLGroupU>();

                ArrayList retList;

                int status = this._bLGroupUAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (BLGroupU bLGroupU in retList)
                    {
                        if (bLGroupU.LogicalDeleteCode == 0)
                        {
                            this._blGroupUDic.Add(bLGroupU.BLGroupCode, bLGroupU);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// 商品掛率グループ名称取得処理
        /// </summary>
        /// <param name="goodsGroupUCode">商品掛率グループコード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <returns>商品掛率グループ名称</returns>
        /// <br>Note       : 商品掛率グループ名称を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetGoodsRateGrpName(int goodsGroupUCode, string enterpriseCode)
        {
            string goodsGroupUName = "";

            ReadGoodsRateGrp(enterpriseCode);
            if (this._goodsGroupUDic.ContainsKey(goodsGroupUCode))
            {
                goodsGroupUName = this._goodsGroupUDic[goodsGroupUCode].GoodsMGroupName.Trim();
            }

            return goodsGroupUName;
        }

        /// <summary>
        /// 商品掛率グループ読込処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <remarks>
        /// <br>Note       : 商品掛率グループ一覧を読み込みます。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private void ReadGoodsRateGrp(string enterpriseCode)
        {
            try
            {
                if (this._goodsGroupUDic.Count == 0)
                {
                    this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

                    ArrayList retList;

                    int status = this._goodsGroupUAcs.SearchAll(out retList, enterpriseCode);
                    if (status == 0)
                    {
                        foreach (GoodsGroupU goodsGroupU in retList)
                        {
                            if (goodsGroupU.LogicalDeleteCode == 0)
                            {
                                this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                            }
                        }
                    }
                }
            }
            catch
            {
                this._goodsGroupUDic = new Dictionary<int, GoodsGroupU>();

                ArrayList retList;

                int status = this._goodsGroupUAcs.SearchAll(out retList, enterpriseCode);
                if (status == 0)
                {
                    foreach (GoodsGroupU goodsGroupU in retList)
                    {
                        if (goodsGroupU.LogicalDeleteCode == 0)
                        {
                            this._goodsGroupUDic.Add(goodsGroupU.GoodsMGroup, goodsGroupU);
                        }
                    }
                }
            }
            return;
        }

        /// <summary>
        /// 装備分類名称取得処理
        /// </summary>
        /// <param name="equipGenreCode">ステータス</param>
        /// <remarks>
        /// <br>Note       : 装備分類名称を取得します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private string GetEquipGenreName(int equipGenreCode)
        {
            string EquipGenreName = "";

            switch (equipGenreCode)
            {
                case EQUIPGANRE_CODE_0:
                    EquipGenreName = EQUIPGANRE_NAME_0;
                    break;
                case EQUIPGANRE_CODE_1001:
                    EquipGenreName = EQUIPGANRE_NAME_1001;
                    break;
                case EQUIPGANRE_CODE_1005:
                    EquipGenreName = EQUIPGANRE_NAME_1005;
                    break;
                case EQUIPGANRE_CODE_1010:
                    EquipGenreName = EQUIPGANRE_NAME_1010;
                    break;
                default:
                    break;
            }

            return EquipGenreName;
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="bLGoodsCdUMnt"></param>
        /// <param name="bLGoodsCdExportWork"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.12</br>
        /// </remarks>
        private int DataFiler(BLGoodsCdUMnt bLGoodsCdUMnt, BLGoodsCdExportWork bLGoodsCdExportWork)
        {
            int status = 0;

            // 論理削除区分
            if (bLGoodsCdUMnt.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }

            // ＢＬコードコード
            if (bLGoodsCdExportWork.BLGoodsCodeSt != 0 &&
                bLGoodsCdExportWork.BLGoodsCodeEd != 0)
            {
                if (bLGoodsCdUMnt.BLGoodsCode < bLGoodsCdExportWork.BLGoodsCodeSt ||
                   bLGoodsCdUMnt.BLGoodsCode > bLGoodsCdExportWork.BLGoodsCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGoodsCdExportWork.BLGoodsCodeSt != 0)
            {
                if (bLGoodsCdUMnt.BLGoodsCode < bLGoodsCdExportWork.BLGoodsCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (bLGoodsCdExportWork.BLGoodsCodeEd != 0)
            {
                if (bLGoodsCdUMnt.BLGoodsCode > bLGoodsCdExportWork.BLGoodsCodeEd)
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
