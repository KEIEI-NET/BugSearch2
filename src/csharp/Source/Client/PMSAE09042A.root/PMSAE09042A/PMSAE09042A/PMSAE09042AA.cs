//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカー・品番S＆E商品コード変換マスタメンテナンス
// プログラム概要   : メーカー・品番S＆E商品コード変換マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 寺田義啓
// 作 成 日  2020/02/20  修正内容 : 新規作成
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
    /// メーカー・品番S＆E商品コード変換マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカー・品番S＆E商品コード変換マスタのアクセス制御を行います。</br>
    /// <br>Programmer : 寺田義啓</br>
    /// <br>Date       : 2020.02.20</br>
    /// <br></br>
    /// </remarks>
    public class MakerGoodsCodeSetAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private ISAndEMkrGdsCdChgSetDB _iSAndEMkrGdsCdChgSetDB = null;

        #endregion

        #region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// <br></br>
        /// </remarks>
        public MakerGoodsCodeSetAcs()
        {
            // リモートオブジェクト取得
            this._iSAndEMkrGdsCdChgSetDB = (ISAndEMkrGdsCdChgSetDB)MediationSAndEMkrGdsCdChgSetDB.GetSAndEMkrGdsCdChgSetDB();
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
        /// <param name="sAndEMkrGdsCdChg">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int Write(ref SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            // UIデータクラス→ワーク
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(sAndEMkrGdsCdChg);

            object objectSAndEMkrGdsCdChgWork = sAndEMkrGdsCdChgWork;

            int status = 0;
            int writeMode = 0;

            // 書き込み処理
            status = this._iSAndEMkrGdsCdChgSetDB.Write(ref objectSAndEMkrGdsCdChgWork, writeMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡してワーククラスをデシリアライズする
                sAndEMkrGdsCdChgWork = objectSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // クラス内メンバコピー
                sAndEMkrGdsCdChg = CopyToSAndEMkrGdsCdChgSetFromSAndEMkrGdsCdChgWork(sAndEMkrGdsCdChgWork);
            }

            return status;
        }

        #endregion

        #region -- 削除処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">メーカー・品番S＆E商品コード変換マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタの論理削除を行います。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int LogicalDelete(ref SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(sAndEMkrGdsCdChg);

            object objectSAndEMkrGdsCdChgWork = sAndEMkrGdsCdChgWork;

            //  メーカー・品番S＆E商品コード変換マスタ情報論理削除
            int status = this._iSAndEMkrGdsCdChgSetDB.LogicalDelete(ref objectSAndEMkrGdsCdChgWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                sAndEMkrGdsCdChgWork = objectSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // クラス内メンバコピー
                sAndEMkrGdsCdChg = CopyToSAndEMkrGdsCdChgSetFromSAndEMkrGdsCdChgWork(sAndEMkrGdsCdChgWork);

            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">メーカー・品番S＆E商品コード変換マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタの物理削除を行います。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int Delete(SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(sAndEMkrGdsCdChg);

            // XMLへ変換し、文字列のバイナリ化
            object objectSAndEMkrGdsCdChgWork = sAndEMkrGdsCdChgWork;

            // メーカー・品番S＆E商品コード変換マスタ情報物理削除
            int status = this._iSAndEMkrGdsCdChgSetDB.Delete(ref objectSAndEMkrGdsCdChgWork);

            return status;
        }

        #endregion

        #region -- 検索･復活処理 --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchAll(out retList, enterpriseCode, SearchMode.Remote);
        }

        /// <summary>
        ///メーカー・品番S＆E商品コード変換マスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>             検索モードでローカル読み込みかリモーティングかを切り替えます。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, SearchMode searchMode)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, null, searchMode);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// メーカー・品番S＆E商品コード変換マスタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>  
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="prevSAndEMkrGdsCdChg">前回メーカー・品番S＆E商品コード変換マスタデータオブジェクト（初回はnull指定必須）</param>
        /// <param name="searchMode">検索モード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタの検索処理を行います。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, SAndEMkrGdsCdChg prevSAndEMkrGdsCdChg, SearchMode searchMode)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = new SAndEMkrGdsCdChgWork();

            if (prevSAndEMkrGdsCdChg != null)
            {
                sAndEMkrGdsCdChgWork = CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(prevSAndEMkrGdsCdChg);
            }

            sAndEMkrGdsCdChgWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new ArrayList();

            ArrayList sAndEMkrGdsCdChgWorkList = new ArrayList();

            // 読込対象データ総件数0で初期化
            retTotalCnt = 0;

            // 次データ有無初期化
            nextData = false;

            object paraobj = sAndEMkrGdsCdChgWork;
            object retobj = null;

            status = this._iSAndEMkrGdsCdChgSetDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                sAndEMkrGdsCdChgWorkList = retobj as ArrayList;

                if (sAndEMkrGdsCdChgWorkList == null)
                {
                    return status;
                }

                foreach (SAndEMkrGdsCdChgWork wkSAndEMkrGdsCdChgWork in sAndEMkrGdsCdChgWorkList)
                {
                    retList.Add(CopyToSAndEMkrGdsCdChgSetFromSAndEMkrGdsCdChgWork(wkSAndEMkrGdsCdChgWork));
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
        /// メーカー・品番S＆E商品コード変換マスタ論理削除復活処理
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">メーカー・品番S＆E商品コード変換マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタの復活を行います。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        public int Revival(ref SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(sAndEMkrGdsCdChg);

            // XMLへ変換し、文字列のバイナリ化
            object objectSAndEMkrGdsCdChgWork = sAndEMkrGdsCdChgWork;

            // 復活処理
            int status = this._iSAndEMkrGdsCdChgSetDB.RevivalLogicalDelete(ref objectSAndEMkrGdsCdChgWork);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡して商品コード変換ワーククラスをデシリアライズする
                sAndEMkrGdsCdChgWork = objectSAndEMkrGdsCdChgWork as SAndEMkrGdsCdChgWork;

                // クラス内メンバコピー
                sAndEMkrGdsCdChg = CopyToSAndEMkrGdsCdChgSetFromSAndEMkrGdsCdChgWork(sAndEMkrGdsCdChgWork);

            }

            return status;
        }

        # endregion

        #region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（メーカー・品番S＆E商品コード変換マスタワーククラス⇒メーカー・品番S＆E商品コード変換マスタクラス）
        /// </summary>
        /// <param name="sAndEMkrGdsCdChgWork">メーカー・品番S＆E商品コード変換マスタワーククラス</param>
        /// <returns>メーカー・品番S＆E商品コード変換マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタワーククラスからメーカー・品番S＆E商品コード変換マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private SAndEMkrGdsCdChg CopyToSAndEMkrGdsCdChgSetFromSAndEMkrGdsCdChgWork(SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork)
        {
            SAndEMkrGdsCdChg sAndEMkrGdsCdChg = new SAndEMkrGdsCdChg();
            sAndEMkrGdsCdChg.CreateDateTime = sAndEMkrGdsCdChgWork.CreateDateTime;
            sAndEMkrGdsCdChg.UpdateDateTime = sAndEMkrGdsCdChgWork.UpdateDateTime;
            sAndEMkrGdsCdChg.EnterpriseCode = sAndEMkrGdsCdChgWork.EnterpriseCode;
            sAndEMkrGdsCdChg.FileHeaderGuid = sAndEMkrGdsCdChgWork.FileHeaderGuid;
            sAndEMkrGdsCdChg.UpdEmployeeCode = sAndEMkrGdsCdChgWork.UpdEmployeeCode;
            sAndEMkrGdsCdChg.UpdAssemblyId1 = sAndEMkrGdsCdChgWork.UpdAssemblyId1;
            sAndEMkrGdsCdChg.UpdAssemblyId2 = sAndEMkrGdsCdChgWork.UpdAssemblyId2;
            sAndEMkrGdsCdChg.LogicalDeleteCode = sAndEMkrGdsCdChgWork.LogicalDeleteCode;
            sAndEMkrGdsCdChg.GoodsMakerCd = sAndEMkrGdsCdChgWork.GoodsMakerCd;
            sAndEMkrGdsCdChg.GoodsNo = sAndEMkrGdsCdChgWork.GoodsNo;
            sAndEMkrGdsCdChg.ABGoodsCode = sAndEMkrGdsCdChgWork.ABGoodsCode;
            sAndEMkrGdsCdChg.MakerName = sAndEMkrGdsCdChgWork.MakerName;

            return sAndEMkrGdsCdChg;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（メーカー・品番S＆E商品コード変換マスタ⇒メーカー・品番S＆E商品コード変換マスタワーククラス）
        /// </summary>
        /// <param name="sAndEMkrGdsCdChg">メーカー・品番S＆E商品コード変換マスタクラス</param>
        /// <returns>メーカー・品番S＆E商品コード変換マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : メーカー・品番S＆E商品コード変換マスタクラスからメーカー・品番S＆E商品コード変換マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 寺田義啓</br>
        /// <br>Date       : 2020.02.20</br>
        /// </remarks>
        private SAndEMkrGdsCdChgWork CopyToSAndEMkrGdsCdChgWorkFromSAndEMkrGdsCdChgSet(SAndEMkrGdsCdChg sAndEMkrGdsCdChg)
        {
            SAndEMkrGdsCdChgWork sAndEMkrGdsCdChgWork = new SAndEMkrGdsCdChgWork();
            sAndEMkrGdsCdChgWork.CreateDateTime = sAndEMkrGdsCdChg.CreateDateTime;
            sAndEMkrGdsCdChgWork.UpdateDateTime = sAndEMkrGdsCdChg.UpdateDateTime;
            sAndEMkrGdsCdChgWork.EnterpriseCode = sAndEMkrGdsCdChg.EnterpriseCode;
            sAndEMkrGdsCdChgWork.FileHeaderGuid = sAndEMkrGdsCdChg.FileHeaderGuid;
            sAndEMkrGdsCdChgWork.UpdEmployeeCode = sAndEMkrGdsCdChg.UpdEmployeeCode;
            sAndEMkrGdsCdChgWork.UpdAssemblyId1 = sAndEMkrGdsCdChg.UpdAssemblyId1;
            sAndEMkrGdsCdChgWork.UpdAssemblyId2 = sAndEMkrGdsCdChg.UpdAssemblyId2;
            sAndEMkrGdsCdChgWork.LogicalDeleteCode = sAndEMkrGdsCdChg.LogicalDeleteCode;
            sAndEMkrGdsCdChgWork.GoodsMakerCd = sAndEMkrGdsCdChg.GoodsMakerCd;
            sAndEMkrGdsCdChgWork.GoodsNo = sAndEMkrGdsCdChg.GoodsNo;
            sAndEMkrGdsCdChgWork.ABGoodsCode = sAndEMkrGdsCdChg.ABGoodsCode;
            sAndEMkrGdsCdChgWork.MakerName = sAndEMkrGdsCdChg.MakerName;

            return sAndEMkrGdsCdChgWork;

        }

        # endregion
    }
}
