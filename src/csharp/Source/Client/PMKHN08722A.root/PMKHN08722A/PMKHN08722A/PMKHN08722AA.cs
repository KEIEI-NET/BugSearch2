//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタ（印刷）
// プログラム概要   : 表示区分マスタ（印刷）アクセスクラス
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10801804-00 作成担当 : 姚学剛
// 作 成 日  2012/06/11  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 表示区分マスタ印刷クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 表示区分マスタ印刷インスタンスの作成を行う。</br>
    /// <br>Programmer : 姚学剛</br>
    /// <br>Date       : 2012/06/11</br>
    /// <br>管理番号   : 10801804-00</br>
    /// </remarks>
    public class PriceSelectSetAcs
    {
        #region ■ Private Member

        //private PriceSelectSetAcs _priceSelectSetAcs;

        IPriceSelectSetWorkDB _iPriceSelectSetWorkDB;

        #endregion

        # region ■Constracter
        /// <summary>
        /// 表示区分マスタ印刷アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 表示区分マスタ印刷アクセスクラス。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public PriceSelectSetAcs()
        {
            try
            {
                this._iPriceSelectSetWorkDB = (IPriceSelectSetWorkDB)MediationPriceSelectSetWorkDB.GetPriceSelectSetWorkDB();
            }
            catch (Exception)
            {

                _iPriceSelectSetWorkDB = null;
            }

        }
        #endregion

        #region ■ 表示区分マスタ情報検索

        /// <summary>
        /// 表示区分マスタデータ取得処理
        /// </summary>
        /// <param name="retList">検索条件</param>
        /// <param name="enterpriseCode">検索データ</param>
        /// <param name="priceSelectSetPrint">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタデータ取得処理を行う。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode, PriceSelectSetPrint priceSelectSetPrint)
        {
            return SearchProc(out retList, enterpriseCode, 0, 0, priceSelectSetPrint);
        }
        #endregion

        #region ■ Private Methods

        /// <summary>
        /// 表示区分マスタ検索処理（論理削除）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>	
        /// <param name="priceSelectSetPrint">取得データ</param>	
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        public int SearchDelete(out ArrayList retList, string enterpriseCode, PriceSelectSetPrint priceSelectSetPrint)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, priceSelectSetPrint);
        }

        /// <summary>
        /// 表示区分マスタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ )</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="priceSelectSetPrint">取得データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタの検索処理を行います。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PriceSelectSetPrint priceSelectSetPrint)
        {

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            retList = new ArrayList();
            retList.Clear();

            try
            {
                PriceSelectSetCndtnWork priceSelectSetCndtnWork = new PriceSelectSetCndtnWork();
                // 抽出条件展開 
                status = this.DevReatCndtn(priceSelectSetPrint, enterpriseCode, out priceSelectSetCndtnWork);
                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    return status;
                }

                // データ取得  
                object retReatList = null;

                status = this._iPriceSelectSetWorkDB.Search(out retReatList, priceSelectSetCndtnWork, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        // データ展開処理
                        DevReatData(priceSelectSetPrint, (ArrayList)retReatList, out retList);

                        if (retList.Count == 0)
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        break;
                    default:
                        break;
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// 取得データ展開処理
        /// </summary>
        /// <param name="priceSelectSetPrint">UI抽出条件クラス</param>
        /// <param name="arrayList">取得データ</param>
        /// <param name="retList">読込結果コレクション</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private void DevReatData(PriceSelectSetPrint priceSelectSetPrint, ArrayList arrayList, out ArrayList retList)
        {
            retList = new ArrayList();

            foreach (PriceSelectSetResultWork priceSelectSetResultWork in arrayList)
            {
                PriceSelectSet priceSelectSet = new PriceSelectSet();

                priceSelectSet.UpdateDateTime = priceSelectSetResultWork.UpdateDateTime;
                priceSelectSet.CustomerCode = priceSelectSetResultWork.CustomerCode;
                priceSelectSet.CustomerSnm = priceSelectSetResultWork.CustomerSnm;
                priceSelectSet.BLGroupCode = priceSelectSetResultWork.BLGroupCode;
                priceSelectSet.GoodsMakerCd = priceSelectSetResultWork.GoodsMakerCd;
                priceSelectSet.GoodsMakerSnm = priceSelectSetResultWork.GoodsMakerSnm;
                priceSelectSet.BLGoodsCode = priceSelectSetResultWork.BLGoodsCode;
                priceSelectSet.BLGoodsHalfName = priceSelectSetResultWork.BLGoodsHalfName;
                priceSelectSet.PriceSelectDiv = priceSelectSetResultWork.PriceSelectDiv;
                priceSelectSet.PriceSelectPtn = priceSelectSetResultWork.PriceSelectPtn;
                retList.Add(priceSelectSet);
            }
        }

        /// <summary>
        /// 抽出条件展開処理
        /// </summary>
        /// <param name="priceSelectSetPrint">UI抽出条件クラス</param>
        /// <param name="enterpriseCode">errMsg</param>
        /// <param name="priceSelectSetCndtnWork">リモート抽出条件クラス</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 取得データを展開する。</br>
        /// <br>Programmer : 姚学剛</br>
        /// <br>Date       : 2012/06/11</br>
        /// <br>管理番号   : 10801804-00</br>
        /// </remarks>
        private int DevReatCndtn(PriceSelectSetPrint priceSelectSetPrint, string enterpriseCode, out PriceSelectSetCndtnWork priceSelectSetCndtnWork)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            priceSelectSetCndtnWork = new PriceSelectSetCndtnWork();
            try
            {
                // 企業コード
                priceSelectSetCndtnWork.EnterpriseCode = enterpriseCode;
                // 標準価格選択設定
                priceSelectSetCndtnWork.PriceSelectPtn = priceSelectSetPrint.PrintType;
                // メーカー開始
                priceSelectSetCndtnWork.St_GoodsMakerCd = priceSelectSetPrint.GoodsMakerCdSt;
                // メーカー終了
                priceSelectSetCndtnWork.Ed_GoodsMakerCd = priceSelectSetPrint.GoodsMakerCdEd;
                // ＢＬコード開始
                priceSelectSetCndtnWork.St_BLGoodsCode = priceSelectSetPrint.BLGoodsCodeSt;
                // ＢＬコード終了
                priceSelectSetCndtnWork.Ed_BLGoodsCode = priceSelectSetPrint.BLGoodsCodeEd;
                // 得意先開始
                priceSelectSetCndtnWork.St_CustomerCode = priceSelectSetPrint.CustomerCodeSt;
                // 得意先終了
                priceSelectSetCndtnWork.Ed_CustomerCode = priceSelectSetPrint.CustomerCodeEd;
                // 得意先掛率グループコード開始
                priceSelectSetCndtnWork.St_BLGroupCode = priceSelectSetPrint.BLGroupCodeSt;
                // 得意先掛率グループコード終了
                priceSelectSetCndtnWork.Ed_BLGroupCode = priceSelectSetPrint.BLGroupCodeEd;
                // 論理削除区分
                priceSelectSetCndtnWork.LogicalDeleteCode = priceSelectSetPrint.LogicalDeleteCode;
                // 削除日開始
                priceSelectSetCndtnWork.DeleteDateTimeSt = priceSelectSetPrint.DeleteDateTimeSt;
                // 削除日終了
                priceSelectSetCndtnWork.DeleteDateTimeEd = priceSelectSetPrint.DeleteDateTimeEd;
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }
        #endregion
    }
}
