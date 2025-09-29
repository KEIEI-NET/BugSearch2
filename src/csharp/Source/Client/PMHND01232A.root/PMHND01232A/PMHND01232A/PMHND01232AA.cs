//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : メーカー品番パターンマスタ
// プログラム概要   : メーカー品番パターンマスタ アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright 2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// 管理番号  11570249-00   作成担当 : 陳艶丹
// 作 成 日  2020/03/09    修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// メーカー品番パターンマスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : メーカー品番パターンマスタアクセスクラス</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2020/03/09</br>
    /// </remarks>
    public class HandyMakerGoodsPtrnAcs
    {
        #region ■ Private Members
        private IHandyMakerGoodsPtrnDB IMakerGoodsPtrnDB;       // メーカー品番パターンマスタ
        private DateGetAcs DateGetAcs;                          // データ取得アクセス
        #endregion ■ Private Members

        #region ■ Constructor
        /// <summary>
        /// メーカー品番パターンマスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタアクセスクラス</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public HandyMakerGoodsPtrnAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this.IMakerGoodsPtrnDB = (IHandyMakerGoodsPtrnDB)MediationHandyMakerGoodsPtrnDB.GetHandyMakerGoodsPtrnDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this.IMakerGoodsPtrnDB = null;
            }

            this.DateGetAcs = DateGetAcs.GetInstance();
        }
        #endregion ■ Constructor

        #region ■ Public Methods
        #region オンラインモード取得
        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this.IMakerGoodsPtrnDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        #endregion オンラインモード取得

        #region 検索処理
        /// <summary>
        /// 指定された条件のメーカー品番パターンマスタ情報検索(メーカー品番パターンNo.の情報)
        /// </summary>
        /// <param name="makerGoodsPtrnList">結果リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="barCodeLength">バーコード桁数</param>
        /// <param name="controlStr">制御文字列</param>
        /// <param name="mode">0：マスタ用；1：部品制御用</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のメーカー品番パターンマスタ情報を戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int ReadByMakerAndBarCodeLength(out ArrayList makerGoodsPtrnList, string enterpriseCode, int goodsMakerCd, int barCodeLength, string controlStr, int mode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            makerGoodsPtrnList = new ArrayList();

            try
            {
                HandyMakerGoodsPtrnWork paraMakerGoodsPtrn = new HandyMakerGoodsPtrnWork();
                paraMakerGoodsPtrn.EnterpriseCode = enterpriseCode;
                paraMakerGoodsPtrn.GoodsMakerCd = goodsMakerCd;
                paraMakerGoodsPtrn.BarCodeLength = barCodeLength;
                paraMakerGoodsPtrn.ControlStr = controlStr;

                object retObj = null;
                //マスタ読み込み
                status = this.IMakerGoodsPtrnDB.ReadByMakerAndBarCodeLength(out retObj, paraMakerGoodsPtrn, 0, mode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList al = retObj as ArrayList;
                    if (al == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // データ変換
                    foreach (HandyMakerGoodsPtrnWork makerGoodsPtrnWork in al)
                    {
                        makerGoodsPtrnList.Add(makerGoodsPtrnWork);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 指定された条件のメーカー品番パターンマスタ情報検索(メーカー品番パターンNo.の情報)
        /// </summary>
        /// <param name="makerGoodsPtrnWork">Primary Key情報リスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="makerGoodsPtrnNo">メーカー品番パターンNo.</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 指定された条件のメーカー品番パターンマスタ情報を戻します</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int Read(out HandyMakerGoodsPtrnWork makerGoodsPtrnWork, string enterpriseCode, int makerGoodsPtrnNo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            makerGoodsPtrnWork = null;

            try
            {
                HandyMakerGoodsPtrnWork paraMakerGoodsPtrn = new HandyMakerGoodsPtrnWork();
                paraMakerGoodsPtrn.EnterpriseCode = enterpriseCode;
                paraMakerGoodsPtrn.MakerGoodsPtrnNo = makerGoodsPtrnNo;

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(paraMakerGoodsPtrn);

                //従業員読み込み
                status = this.IMakerGoodsPtrnDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XMLの読み込み
                    makerGoodsPtrnWork = (HandyMakerGoodsPtrnWork)XmlByteSerializer.Deserialize(parabyte, typeof(HandyMakerGoodsPtrnWork));
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 検索処理(メーカー品番パターンマスタ)
        /// </summary>
        /// <param name="retList">メーカー品番パターンマスタリスト</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタを検索します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            retList = new ArrayList();

            try
            {
                HandyMakerGoodsPtrnWork paraWork = new HandyMakerGoodsPtrnWork();
                paraWork.EnterpriseCode = enterpriseCode;
                object retObj = null;

                // 検索処理
                status = this.IMakerGoodsPtrnDB.Search(out retObj, paraWork, 0, ConstantManagement.LogicalMode.GetData01);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // パラメータが渡って来ているか確認
                    ArrayList al = retObj as ArrayList;
                    if (retList == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }

                    // データ変換
                    foreach (HandyMakerGoodsPtrnWork makerGoodsPtrnWork in al)
                    {
                        // クラスメンバコピー処理(D→E)
                        retList.Add(makerGoodsPtrnWork);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 検索処理

        #region 更新処理
        /// <summary>
        /// 更新処理(メーカー品番パターンマスタ)
        /// </summary>
        /// <param name="makerGoodsPtrnWork">メーカー品番パターンマスタ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタを更新します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       :2020/03/09</br>
        /// </remarks>
        public int Write(ref HandyMakerGoodsPtrnWork makerGoodsPtrnWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(makerGoodsPtrnWork);

                // 更新処理
                status = this.IMakerGoodsPtrnDB.Write(ref parabyte);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                    makerGoodsPtrnWork = (HandyMakerGoodsPtrnWork)XmlByteSerializer.Deserialize(parabyte, typeof(HandyMakerGoodsPtrnWork));
                    if (makerGoodsPtrnWork == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 更新処理

        #region 論理削除処理
        /// <summary>
        /// 論理削除処理(メーカー品番パターンマスタ)
        /// </summary>
        /// <param name="paraWork">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタを論理削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int LogicalDelete(ref HandyMakerGoodsPtrnWork paraWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object paraObj = (object)paraWork;
                // 論理削除処理
                status = this.IMakerGoodsPtrnDB.LogicalDelete(ref paraObj);
                paraWork = paraObj as HandyMakerGoodsPtrnWork;
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 論理削除処理

        #region 物理削除処理
        /// <summary>
        /// 物理削除処理(メーカー品番パターンマスタ)
        /// </summary>
        /// <param name="paraWork">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタを物理削除します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int Delete(HandyMakerGoodsPtrnWork paraWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // 物理削除処理
                status = this.IMakerGoodsPtrnDB.Delete(paraWork);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 物理削除処理

        #region 復活処理
        /// <summary>
        /// 復活処理(メーカー品番パターンマスタ)
        /// </summary>
        /// <param name="paraWork">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタを復活します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int Revival(ref HandyMakerGoodsPtrnWork paraWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                object paraObj = (object)paraWork;
                // 論理削除処理
                status = this.IMakerGoodsPtrnDB.RevivalLogicalDelete(ref paraObj);
                paraWork = paraObj as HandyMakerGoodsPtrnWork; 
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 復活処理

        #region [照会]
        /// <summary>
        /// メーカー品番パターンマスタ検索履歴抽出処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="retObj">メーカー品番パターンマスタ検索履歴データ情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターンマスタ検索履歴抽出処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHis(object condObj, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retObj = null;
            try
            {
                // メーカー品番パターンマスタ検索履歴抽出
                status = IMakerGoodsPtrnDB.SearchHis(condObj, out retObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region 在庫一括削除
        /// <summary>
        /// 画面条件によって、在庫一括削除処理
        /// </summary>
        /// <param name="deleteStockCondWork">検索条件</param>
        /// <remarks>
        /// <br>Note		: 画面条件によって、処理結果取得。</br>
        /// <br>Programmer  : 陳艶丹</br>
        /// <br>Date        : 2020/03/09</br>
        /// </remarks>
        public int DeleteStockWithMng(HandyDeleteStockCondWork deleteStockCondWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ArrayList handyDeleteStockList = null;
            object handyDeleteStockRsltList = null;

            // 在庫一括削除対象抽出
            status = this.IMakerGoodsPtrnDB.SearchDeleteStockWithMng((object)deleteStockCondWork, out handyDeleteStockRsltList);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                handyDeleteStockList = handyDeleteStockRsltList as ArrayList;
                foreach (HandyDeleteStockRsltWork handyDeleteStock in handyDeleteStockList)
                {
                    // 在庫一括削除
                    status = this.IMakerGoodsPtrnDB.DeleteStockWithMng((object)handyDeleteStock, deleteStockCondWork.EnterpriseCode);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        break;
                    }
                }
            }

            // 操作履歴ログ登録
            OperationHistoryLog operationHistoryLog = new OperationHistoryLog();
            string operationMsg;

            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            {
                operationMsg = "削除対象データがありません。";
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                operationMsg = "正常に終了しました。";
            }
            else
            {
                operationMsg = "エラーが発生しました。";
            }

            operationHistoryLog.WriteOperationLog(this, LogDataKind.OperationLog, "PMKHN09770U", "在庫一括削除", "", 6, status, operationMsg, "");

            return status;
        }

        #endregion 在庫一括削除

        #region 商品バーコード関連付けマスタ検索
        /// <summary>
        /// 商品バーコード関連付けマスタ検索処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="goodsBarCode">パーコード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="retObj">商品バーコード関連付けマスタ情報</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けマスタ検索処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchGoodsBarCodeRevn(string enterpriseCode, string goodsBarCode, int goodsMakerCd, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retObj = null;
            try
            {
                // 商品バーコード関連付けマスタ検索
                status = IMakerGoodsPtrnDB.SearchGoodsBarCodeRevn(enterpriseCode, goodsBarCode, goodsMakerCd, out retObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region UOE発注データ検索
        /// <summary>
        /// UOE発注データ検索処理
        /// </summary>
        /// <param name="condObj">検索条件</param>
        /// <param name="count">戻り件数</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : UOE発注データ検索処理を行います。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyUOEOrder(ref object condObj, out int count)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            count = 0;
            try
            {
                // UOE発注データ存在チェック
                status = IMakerGoodsPtrnDB.SearchHandyUOEOrder(ref condObj, out count);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        #endregion

        #region メーカー品番パターン検索履歴データ登録
        /// <summary>
        /// メーカー品番パターン検索履歴データ登録
        /// </summary>
        /// <param name="searcHisWork">メーカー品番パターン検索履歴データ</param>
        /// <param name="mode">0:新規登録；1：更新</param>
        /// <param name="callMode">0：パターン検索処理；1：パターン検索処理以外</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : メーカー品番パターン検索履歴データを登録・更新します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int WriteHis(ref HandyMakerGoodsPtrnHisResultWork searcHisWork, int mode, int callMode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize(searcHisWork);

                // 更新処理
                status = this.IMakerGoodsPtrnDB.WriteHis(ref parabyte, mode, callMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ファイル名を渡してメーカー品番パターン検索履歴データワーククラスをデシリアライズする
                    searcHisWork = (HandyMakerGoodsPtrnHisResultWork)XmlByteSerializer.Deserialize(parabyte, typeof(HandyMakerGoodsPtrnHisResultWork));
                    if (searcHisWork == null)
                    {
                        return ((int)ConstantManagement.DB_Status.ctDB_ERROR);
                    }
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 更新処理

        #region ハンディ在庫登録管理データ登録
        /// <summary>
        /// ハンディ在庫登録管理データ登録
        /// </summary>
        /// <param name="mngWork">検索条件</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ハンディ在庫登録管理データを登録・更新します。</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int WriteMng(HandyZaikoRegistMngWork mngWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {

                // 更新処理
                object condObj = (object)mngWork;
                status = this.IMakerGoodsPtrnDB.WriteMng(condObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (status);
        }
        #endregion 更新処理
        #endregion ■ Public Methods

    }
}
