//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : ＴＢＯ検索マスタ（エクスポート）
// プログラム概要   : ＴＢＯ検索マスタのｴｸｽﾎﾟｰﾄ処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/05/14  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 朱宝軍
// 作 成 日  2009/06/24  修正内容 : PVCS268 出力データが違い
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
// ADD 2009/06/24 --->>>
// 出力データが違い
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
// ADD 2009/06/24 ---<<<

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ＴＢＯ検索マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : ＴＢＯ検索マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.14</br>
    /// <br></br>
    /// </remarks>
    public class TBOSearchSetExpAcs
    {
        private ITBOSearchUDB _iTBOSearchUDB;


        private static bool _isLocalDBRead = false;

        /// <summary>TBO検索マスタアクセスクラス</summary>
        private TBOSearchUAcs _tBOSearchUAcs;

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
        /// ＴＢＯ検索マスタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : ＴＢＯ検索マスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public TBOSearchSetExpAcs()
        {
            _tBOSearchUAcs = new TBOSearchUAcs();
            this._iTBOSearchUDB = (ITBOSearchUDB)MediationTBOSearchUDB.GetTBOSearchUDB();
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
        /// ＴＢＯ検索マスタ全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tBOSearchExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ＴＢＯ検索マスタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, TBOSearchExportWork tBOSearchExportWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, tBOSearchExportWork);
        }

        /// <summary>
        /// ＴＢＯ検索マスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="tBOSearchExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ＴＢＯ検索マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, TBOSearchExportWork tBOSearchExportWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, tBOSearchExportWork);
        }

        /// <summary>
        /// ＴＢＯ検索マスタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="tBOSearchExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ＴＢＯ検索マスタ検索処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, TBOSearchExportWork tBOSearchExportWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int checkstatus = 0;
            nextData = false;
            retTotalCnt = 0;

            // 検索結果
            retList = new ArrayList();
            retList.Clear();
            // MODIFY 2009/06/24 --->>>
            // 出力データが違い
            //ArrayList paraList = new ArrayList();
            //paraList.Clear();

            //object retobj = new ArrayList();

            TBOSearchUWork paraWork = new TBOSearchUWork();
            paraWork.EnterpriseCode = enterpriseCode;

            ArrayList tboSearchUWorkList = new ArrayList();
            object paraList = tboSearchUWorkList;
            object paraObj = paraWork;
            status = _iTBOSearchUDB.Search(ref paraList, paraObj, 0, ConstantManagement.LogicalMode.GetData0);

            // 検索
            //status = this._tBOSearchUAcs.SearchAll(out paraList, enterpriseCode);
            // MODIFY 2009/06/24 ---<<<

            // 正常場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                // MODIFY 2009/06/24 --->>>
                // 出力データが違い
                //foreach (TBOSearchU tBOSearchU in paraList)
                foreach (TBOSearchUWork tBOSearchU in (ArrayList)paraList)
                // MODIFY 2009/06/24 ---<<<
                {
                    // 抽出処理
                    checkstatus = DataCheck(tBOSearchU, tBOSearchExportWork);
                    if (checkstatus == 0)
                    {
                    //ＴＢＯ検索マスタ情報クラスへメンバコピー
                    retList.Add(CopyToTBOSearchSetExpFromtBOSearchU(tBOSearchU, enterpriseCode));
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
        /// クラスメンバーコピー処理（ＴＢＯ検索マスタワーククラス⇒ＴＢＯ検索マスタクラス）
        /// </summary>
        /// <param name="tBOSearchU">ＴＢＯ検索マスタワーククラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ＴＢＯ検索マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : ＴＢＯ検索マスタワーククラスからＴＢＯ検索マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        // MODIFY 2009/06/24 --->>>
        // 出力データが違い
        //private TBOSearchSetExp CopyToTBOSearchSetExpFromtBOSearchU(TBOSearchU tBOSearchU, string enterpriseCode)
        private TBOSearchSetExp CopyToTBOSearchSetExpFromtBOSearchU(TBOSearchUWork tBOSearchU, string enterpriseCode)
        // MODIFY 2009/06/24 ---<<<
        {
            TBOSearchSetExp tBOSearchSetExp = new TBOSearchSetExp();

            tBOSearchSetExp.EquipGenreCode = tBOSearchU.EquipGenreCode;
            // DELETE 2009/06/24 --->>>
            // 出力データが違い
            //tBOSearchSetExp.EnterpriseName = tBOSearchU.EnterpriseName;
            // DELETE 2009/06/24 ---<<<
            tBOSearchSetExp.EquipName = tBOSearchU.EquipName;
            tBOSearchSetExp.CarInfoJoinDispOrder = tBOSearchU.CarInfoJoinDispOrder;
            tBOSearchSetExp.JoinDestPartsNo = tBOSearchU.JoinDestPartsNo;
            tBOSearchSetExp.JoinDestMakerCd = tBOSearchU.JoinDestMakerCd;
            tBOSearchSetExp.BLGoodsCode = tBOSearchU.BLGoodsCode;
            tBOSearchSetExp.JoinQty = tBOSearchU.JoinQty;
            tBOSearchSetExp.EquipSpecialNote = tBOSearchU.EquipSpecialNote;

            return tBOSearchSetExp;
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="tBOSearchU">検索結果</param>
        /// <param name="tBOSearchExportWork">抽出条件</param>
        /// <returns></returns>
        // MODIFY 2009/06/24 --->>>
        // 出力データが違い
        //private int DataCheck(TBOSearchU tBOSearchU, TBOSearchExportWork tBOSearchExportWork)
        private int DataCheck(TBOSearchUWork tBOSearchU, TBOSearchExportWork tBOSearchExportWork)
        // MODIFY 2009/06/24 ---<<<
        {
            int status = 0;

            // 論理削除区分
            if (tBOSearchU.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }

            // 結合先メーカーコード
            if (tBOSearchExportWork.JoinDestMakerCdSt != 0 &&
                tBOSearchExportWork.JoinDestMakerCdEd != 0)
            {
                if (tBOSearchU.JoinDestMakerCd < tBOSearchExportWork.JoinDestMakerCdSt ||
                   tBOSearchU.JoinDestMakerCd > tBOSearchExportWork.JoinDestMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (tBOSearchExportWork.JoinDestMakerCdSt != 0)
            {
                if (tBOSearchU.JoinDestMakerCd < tBOSearchExportWork.JoinDestMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (tBOSearchExportWork.JoinDestMakerCdEd != 0)
            {
                if (tBOSearchU.JoinDestMakerCd > tBOSearchExportWork.JoinDestMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }

            // 装備分類
            if (tBOSearchExportWork.EquipGenreCodeCd != 0)
            {
                if (tBOSearchU.EquipGenreCode != tBOSearchExportWork.EquipGenreCodeCd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}
