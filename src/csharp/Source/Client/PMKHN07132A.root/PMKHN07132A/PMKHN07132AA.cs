//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカーマスタ（エクスポート）（エクスポート）
// プログラム概要   : メーカーマスタ（エクスポート）のｴｸｽﾎﾟｰﾄ処理を行う
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
    /// メーカーマスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカーマスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.05.12</br>
    /// <br></br>
    /// </remarks>
    public class MakerSetExpAcs
    {

        private static bool _isLocalDBRead = false;

        private MakerAcs _makerAcs;

        /// <summary> ローカルＤＢ参照モードプロパティ</summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        /// <summary>
        /// メーカーマスタタテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカーマスタタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public MakerSetExpAcs()
        {
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
        /// メーカーマスタタ全検索処理（論理削除除く）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>	
        /// <param name="makerExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカーマスタタの全検索処理を行います。論理削除データは抽出対象外となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, MakerExportWork makerExportWork)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, 0, 0, makerExportWork);
        }

        /// <summary>
        /// メーカーマスタタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>	
        /// <param name="makerExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカーマスタタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, MakerExportWork makerExportWork)
        {

            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, makerExportWork);
        }

        /// <summary>
        /// メーカーマスタタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="makerExportWork">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカーマスタタの検索処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, MakerExportWork makerExportWork)
        {

            this._makerAcs = new MakerAcs();

            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList makerUMnts = null;

            // 検索
            status = this._makerAcs.SearchAll(
                                out makerUMnts,
                                enterpriseCode);

            // 正常の場合
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND
                || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                foreach (MakerUMnt makerUMnt in makerUMnts)
                {
                    // 抽出処理
                    checkstatus = DataCheck(makerUMnt, makerExportWork);
                    if (checkstatus == 0)
                    {
                        //メーカー情報クラスへメンバコピー
                        retList.Add(CopyToMakerSetFromSecInfoSetWork(makerUMnt, enterpriseCode));

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
        /// クラスメンバーコピー処理（メーカーマスタタワーククラス⇒メーカーマスタタクラス）
        /// </summary>
        /// <param name="makerUMnt">メーカーマスタタワーククラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>メーカーマスタタクラス</returns>
        /// <remarks>
        /// <br>Note       : メーカーマスタタワーククラスからメーカーマスタタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        /// </remarks>
        private MakerSetExp CopyToMakerSetFromSecInfoSetWork(MakerUMnt makerUMnt, string enterpriseCode)
        {

            MakerSetExp makerSetExp = new MakerSetExp();

            makerSetExp.GoodsMakerCd = makerUMnt.GoodsMakerCd;
            makerSetExp.MakerName = makerUMnt.MakerName;
            makerSetExp.MakerShortName = makerUMnt.MakerShortName;
            makerSetExp.MakerKanaName = makerUMnt.MakerKanaName;
            makerSetExp.DisplayOrder = makerUMnt.DisplayOrder;

            return makerSetExp;
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="makerUMnt">検索結果</param>
        /// <param name="makerExportWork">抽出条件</param>
        /// <returns></returns>
        /// <br>Note       : 抽出処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.05.13</br>
        private int DataCheck(MakerUMnt makerUMnt, MakerExportWork makerExportWork)
        {
            int status = 0;

            // 論理削除区分
            if (makerUMnt.LogicalDeleteCode != 0)
            {
                status = -1;
                return status;
            }

            // 商品メーカーコード
            if (makerExportWork.GoodsMakerCdSt != 0 &&
                makerExportWork.GoodsMakerCdEd != 0)
            {
                if (makerUMnt.GoodsMakerCd < makerExportWork.GoodsMakerCdSt ||
                   makerUMnt.GoodsMakerCd > makerExportWork.GoodsMakerCdEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerExportWork.GoodsMakerCdSt != 0)
            {
                if (makerUMnt.GoodsMakerCd < makerExportWork.GoodsMakerCdSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (makerExportWork.GoodsMakerCdEd != 0)
            {
                if (makerUMnt.GoodsMakerCd > makerExportWork.GoodsMakerCdEd)
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
