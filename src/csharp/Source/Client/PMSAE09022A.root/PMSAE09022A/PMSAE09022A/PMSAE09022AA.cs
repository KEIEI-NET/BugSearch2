//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : オートバックス商品コード変換マスタメンテナンス
// プログラム概要   : 商品コード変換の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 張凱
// 作 成 日  2009/08/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.Adapter;
namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 商品コード変換アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品コード変換のアクセス制御を行います。</br>
    /// <br>Programmer : 張凱</br>
    /// <br>Date       : 2009.08.05</br>
    /// <br></br>
    /// </remarks>
    public class BLGoodsCodeSetAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private ISAndEGoodsCdChgSetDB _iSAndEGoodsCdChgSetDB = null;

        #endregion

        #region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// <br></br>
        /// </remarks>
        public BLGoodsCodeSetAcs()
        {
            // リモートオブジェクト取得
            this._iSAndEGoodsCdChgSetDB = (ISAndEGoodsCdChgSetDB)MediationSAndEGoodsCdChgSetDB.GetSAndEGoodsCdChgSetDB();
        }

        #endregion

        #region [ローカルアクセス用]
        /// <summary> 検索モード </summary>
        public enum SearchMode
        {
            /// <summary> ローカルアクセス </summary>
            Local = 0,
            /// <summary> リモートアクセス </summary>
            Remote = 1
        }
        #endregion

        #region -- 登録･更新処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 登録・更新処理
        /// </summary>
        /// <param name="sAndEGoodsCdChg">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int Write(ref SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            // UIデータクラス→ワーク
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(sAndEGoodsCdChg);

            object objectsAndEGoodsCdChgWork = sAndEGoodsCdChgWork;

            int status = 0;
            int writeMode = 0;

            // 書き込み処理
            status = this._iSAndEGoodsCdChgSetDB.Write(ref objectsAndEGoodsCdChgWork, writeMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡してワーククラスをデシリアライズする
                sAndEGoodsCdChgWork = objectsAndEGoodsCdChgWork as SAndEGoodsCdChgWork;

                // クラス内メンバコピー
                sAndEGoodsCdChg = CopyToSAndEGoodsCdChgSetFromSAndEGoodsCdChgWork(sAndEGoodsCdChgWork);
            }

            return status;
        }

        #endregion

        #region -- 削除処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="sAndEGoodsCdChg">商品コード変換オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品コード変換の論理削除を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int LogicalDelete(ref SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(sAndEGoodsCdChg);

            object objectsAndEGoodsCdChgWork = sAndEGoodsCdChgWork;

            //  商品コード変換情報論理削除
            int status = this._iSAndEGoodsCdChgSetDB.LogicalDelete(ref objectsAndEGoodsCdChgWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                sAndEGoodsCdChgWork = objectsAndEGoodsCdChgWork as SAndEGoodsCdChgWork;

                // クラス内メンバコピー
                sAndEGoodsCdChg = CopyToSAndEGoodsCdChgSetFromSAndEGoodsCdChgWork(sAndEGoodsCdChgWork);

            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="sAndEGoodsCdChg">商品コード変換オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品コード変換の物理削除を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int Delete(SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(sAndEGoodsCdChg);

            // XMLへ変換し、文字列のバイナリ化
            object objectSAndEGoodsCdChgWork = sAndEGoodsCdChgWork;

            // 商品コード変換情報物理削除
            int status = this._iSAndEGoodsCdChgSetDB.Delete(ref objectSAndEGoodsCdChgWork);

            return status;
        }

        #endregion

        #region -- 検索･復活処理 --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 商品コード変換検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品コード変換の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);
        }

        /// <summary>
        ///商品コード変換検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品コード変換の全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 商品コード変換検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>  
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevSAndEGoodsCdChg">前回商品コード変換データオブジェクト（初回はnull指定必須）</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品コード変換の検索処理を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SAndEGoodsCdChg prevSAndEGoodsCdChg, SearchMode searchMode)
        {
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = new SAndEGoodsCdChgWork();

            if (prevSAndEGoodsCdChg != null)
            {
                sAndEGoodsCdChgWork = CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(prevSAndEGoodsCdChg);
            }

            sAndEGoodsCdChgWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new ArrayList();

            ArrayList sAndEGoodsCdChgWorkList = new ArrayList();

            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            // 次データ有無初期化
            nextData = false;

            object paraobj = sAndEGoodsCdChgWork;
            object retobj = null;

            status = this._iSAndEGoodsCdChgSetDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                sAndEGoodsCdChgWorkList = retobj as ArrayList;

                if (sAndEGoodsCdChgWorkList == null)
                {
                    return status;
                }

                foreach (SAndEGoodsCdChgWork wksAndEGoodsCdChgWork in sAndEGoodsCdChgWorkList)
                {
                    retList.Add(CopyToSAndEGoodsCdChgSetFromSAndEGoodsCdChgWork(wksAndEGoodsCdChgWork));
                }

                // 読込対象データ総件数←ArrayListの件数
                retTotalCnt = retList.Count;
            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            // 全件リードの場合は戻り値の件数をセット
            if (readCnt == 0)
            {
                retTotalCnt = retList.Count;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 商品コード変換論理削除復活処理
        /// </summary>
        /// <param name="sAndEGoodsCdChg">商品コード変換オブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 商品コード変換の復活を行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        public int Revival(ref SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(sAndEGoodsCdChg);

            // XMLへ変換し、文字列のバイナリ化
            object objectsAndEGoodsCdChgWork = sAndEGoodsCdChgWork;

            // 復活処理
            int status = this._iSAndEGoodsCdChgSetDB.RevivalLogicalDelete(ref objectsAndEGoodsCdChgWork);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡して商品コード変換ワーククラスをデシリアライズする
                sAndEGoodsCdChgWork = objectsAndEGoodsCdChgWork as SAndEGoodsCdChgWork;

                // クラス内メンバコピー
                sAndEGoodsCdChg = CopyToSAndEGoodsCdChgSetFromSAndEGoodsCdChgWork(sAndEGoodsCdChgWork);

            }

            return status;
        }

        # endregion

        #region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（商品コード変換ワーククラス⇒商品コード変換クラス）
        /// </summary>
        /// <param name="sAndEGoodsCdChgWork">商品コード変換ワーククラス</param>
        /// <returns>商品コード変換クラス</returns>
        /// <remarks>
        /// <br>Note       : 商品コード変換ワーククラスから商品コード変換クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private SAndEGoodsCdChg CopyToSAndEGoodsCdChgSetFromSAndEGoodsCdChgWork(SAndEGoodsCdChgWork sAndEGoodsCdChgWork)
        {
            SAndEGoodsCdChg sAndEGoodsCdChg = new SAndEGoodsCdChg();
            sAndEGoodsCdChg.CreateDateTime = sAndEGoodsCdChgWork.CreateDateTime;
            sAndEGoodsCdChg.UpdateDateTime = sAndEGoodsCdChgWork.UpdateDateTime;
            sAndEGoodsCdChg.EnterpriseCode = sAndEGoodsCdChgWork.EnterpriseCode;
            sAndEGoodsCdChg.FileHeaderGuid = sAndEGoodsCdChgWork.FileHeaderGuid;
            sAndEGoodsCdChg.UpdEmployeeCode = sAndEGoodsCdChgWork.UpdEmployeeCode;
            sAndEGoodsCdChg.UpdAssemblyId1 = sAndEGoodsCdChgWork.UpdAssemblyId1;
            sAndEGoodsCdChg.UpdAssemblyId2 = sAndEGoodsCdChgWork.UpdAssemblyId2;
            sAndEGoodsCdChg.LogicalDeleteCode = sAndEGoodsCdChgWork.LogicalDeleteCode;
            sAndEGoodsCdChg.BLGoodsCode = sAndEGoodsCdChgWork.BLGoodsCode;
            sAndEGoodsCdChg.ABGoodsCode = sAndEGoodsCdChgWork.ABGoodsCode;
            sAndEGoodsCdChg.BLGoodsHalfName = sAndEGoodsCdChgWork.BLGoodsHalfName;

            return sAndEGoodsCdChg;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（商品コード変換マスタ⇒商品コード変換ワーククラス）
        /// </summary>
        /// <param name="sAndEGoodsCdChg">商品コード変換クラス</param>
        /// <returns>商品コード変換クラス</returns>
        /// <remarks>
        /// <br>Note       : 商品コード変換クラスから商品コード変換ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 張凱</br>
        /// <br>Date       : 2009.08.05</br>
        /// </remarks>
        private SAndEGoodsCdChgWork CopyToSAndEGoodsCdChgWorkFromSAndEGoodsCdChgSet(SAndEGoodsCdChg sAndEGoodsCdChg)
        {
            SAndEGoodsCdChgWork sAndEGoodsCdChgWork = new SAndEGoodsCdChgWork();
            sAndEGoodsCdChgWork.CreateDateTime = sAndEGoodsCdChg.CreateDateTime;
            sAndEGoodsCdChgWork.UpdateDateTime = sAndEGoodsCdChg.UpdateDateTime;
            sAndEGoodsCdChgWork.EnterpriseCode = sAndEGoodsCdChg.EnterpriseCode;
            sAndEGoodsCdChgWork.FileHeaderGuid = sAndEGoodsCdChg.FileHeaderGuid;
            sAndEGoodsCdChgWork.UpdEmployeeCode = sAndEGoodsCdChg.UpdEmployeeCode;
            sAndEGoodsCdChgWork.UpdAssemblyId1 = sAndEGoodsCdChg.UpdAssemblyId1;
            sAndEGoodsCdChgWork.UpdAssemblyId2 = sAndEGoodsCdChg.UpdAssemblyId2;
            sAndEGoodsCdChgWork.LogicalDeleteCode = sAndEGoodsCdChg.LogicalDeleteCode;
            sAndEGoodsCdChgWork.BLGoodsCode = sAndEGoodsCdChg.BLGoodsCode;
            sAndEGoodsCdChgWork.ABGoodsCode = sAndEGoodsCdChg.ABGoodsCode;
            sAndEGoodsCdChgWork.BLGoodsHalfName = sAndEGoodsCdChg.BLGoodsHalfName;

            return sAndEGoodsCdChgWork;

        }

        # endregion
    }
}
