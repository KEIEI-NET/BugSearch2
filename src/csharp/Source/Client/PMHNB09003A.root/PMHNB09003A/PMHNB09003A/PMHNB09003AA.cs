//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 表示区分マスタメンテナンス
// プログラム概要   : 表示区分マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 作 成 日  2009/10/15  修正内容 : 新規作成
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
    /// 表示区分マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 表示区分マスタのアクセス制御を行います。</br>
    /// <br>Programmer : 呉元嘯</br>
    /// <br>Date       : 2009.10.15</br>
    /// <br></br>
    /// </remarks>
    public class PriceSelectSetAcs
    {
        #region -- リモートオブジェクト格納バッファ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// リモートオブジェクト格納バッファ
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private IPriceSelectSetDB _iPriceSelectSetDB = null;

        // ローカルＤＢモード
        private static bool _isLocalDBRead = false;	// デフォルトはリモート

        #endregion

        #region -- コンストラクタ --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// <br></br>
        /// </remarks>
        public PriceSelectSetAcs()
        {
            // リモートオブジェクト取得
            this._iPriceSelectSetDB = (IPriceSelectSetDB)MediationPriceSelectSetDB.GetPriceSelectSetDB();
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
        /// <param name="priceSelectSet">UIデータクラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 登録・更新処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int Write(ref PriceSelectSet priceSelectSet)
        {
            // UIデータクラス→ワーク
            PriceSelectSetWork priceSelectSetWork = CopyToPriceSelectSetWorkFromPriceSelectSet(priceSelectSet);

            object objPriceSelectSetWork = priceSelectSetWork;

            int status = 0;
            int writeMode = 0;

            // 書き込み処理
            status = this._iPriceSelectSetDB.Write(ref objPriceSelectSetWork, writeMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                priceSelectSetWork = objPriceSelectSetWork as PriceSelectSetWork;

                // クラス内メンバコピー
                priceSelectSet = CopyToPriceSelectSetFromPriceSelectSetWork(priceSelectSetWork);
            }

            return status;
        }

        #endregion

        #region -- 削除処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="priceSelectSet">表示区分マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタの論理削除を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int LogicalDelete(ref PriceSelectSet priceSelectSet)
        {
            PriceSelectSetWork priceSelectSetWork = CopyToPriceSelectSetWorkFromPriceSelectSet(priceSelectSet);
            object objPriceSelectSetWork = priceSelectSetWork;

            // 拠点情報論理削除
            int status = this._iPriceSelectSetDB.LogicalDelete(ref objPriceSelectSetWork);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                priceSelectSetWork = objPriceSelectSetWork as PriceSelectSetWork;

                // クラス内メンバコピー
                priceSelectSet = CopyToPriceSelectSetFromPriceSelectSetWork(priceSelectSetWork);

            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 物理削除処理
        /// </summary>
        /// <param name="priceSelectSet">表示区分マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタの物理削除を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int Delete(PriceSelectSet priceSelectSet)
        {
            PriceSelectSetWork priceSelectSetWork = CopyToPriceSelectSetWorkFromPriceSelectSet(priceSelectSet);

            // XMLへ変換し、文字列のバイナリ化
            object objPriceSelectSetWork = priceSelectSetWork;

            // 拠点情報物理削除
            int status = this._iPriceSelectSetDB.Delete(ref objPriceSelectSetWork);

            return status;
        }

        #endregion

        #region -- 検索･復活処理 --

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 表示区分マスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, SearchMode.Remote, ConstantManagement.LogicalMode.GetData01);
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 表示区分マスタ検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, SearchMode.Remote, ConstantManagement.LogicalMode.GetData0);
        }

/*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 表示区分マスタ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>  
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="searchMode">検索モード</param>
        /// <param name="logicalMode">論理削除有無(0:正規ﾃﾞｰﾀのみ 1:削除ﾃﾞｰﾀのみ 2:保留ﾃﾞｰﾀのみ 3:完全削除ﾃﾞｰﾀのみ 4:全件 5:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ 6:正規ﾃﾞｰﾀ+削除ﾃﾞｰﾀ+保留ﾃﾞｰﾀ)</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタの検索処理を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, SearchMode searchMode, ConstantManagement.LogicalMode logicalMode)
        {
            LogWrite("ローカルモード判定");
            _isLocalDBRead = searchMode == SearchMode.Local ? true : false;

            LogWrite("Dクラスインスタンス生成");
            PriceSelectSetWork priceSelectSetWork = new PriceSelectSetWork();

            priceSelectSetWork.EnterpriseCode = enterpriseCode;

            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList priceSelectSetWorkList = new ArrayList();
            priceSelectSetWorkList.Clear();

            object paraobj = priceSelectSetWork;
            object retobj = null;

            LogWrite("リモート　検索処理");
            status = this._iPriceSelectSetDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                LogWrite("正常処理");

                priceSelectSetWorkList = retobj as ArrayList;

                foreach (PriceSelectSetWork wkPriceSelectSetWork in priceSelectSetWorkList)
                {
                    retList.Add(CopyToPriceSelectSetFromPriceSelectSetWork(wkPriceSelectSetWork));
                }
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;

            }

            // STATUS を設定
            if ((status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (retList.Count == 0))
            {
                LogWrite("該当なし");

                status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
            }

            return status;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 表示区分マスタ論理削除復活処理
        /// </summary>
        /// <param name="priceSelectSet">表示区分マスタオブジェクト</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタの復活を行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public int Revival(ref PriceSelectSet priceSelectSet)
        {
            PriceSelectSetWork priceSelectSetWork = CopyToPriceSelectSetWorkFromPriceSelectSet(priceSelectSet);

            // XMLへ変換し、文字列のバイナリ化
            object objPriceSelectSetWork = priceSelectSetWork;

            // 復活処理
            int status = this._iPriceSelectSetDB.RevivalLogicalDelete(ref objPriceSelectSetWork);


            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // ファイル名を渡して拠点情報ワーククラスをデシリアライズする
                priceSelectSetWork = objPriceSelectSetWork as PriceSelectSetWork;

                // クラス内メンバコピー
                priceSelectSet = CopyToPriceSelectSetFromPriceSelectSetWork(priceSelectSetWork);

            }

            return status;
        }

        # endregion

        #region -- 標準価格選択区分取得 --
        /// <summary>
        /// 標準価格選択区分取得
        /// </summary>
        /// <param name="displayDivList">表示区分リスト</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="blGoodsCode">/ BLコード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="priceSelectDiv">標準価格選択区分</param>
        /// <remarks>
        /// <br>Note       : 標準価格選択区分取得処理を行います</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public void GetDisplayDiv(List<PriceSelectSet> displayDivList, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode, out Int32  priceSelectDiv)
        {
            GetDisplayDivProc(displayDivList, goodsMakerCode, blGoodsCode, customerCode, custRateGrpCode, out  priceSelectDiv);
        }

        /// <summary>
        /// 標準価格選択区分取得
        /// </summary>
        /// <param name="displayDivList">表示区分リスト</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="blGoodsCode">/ BLコード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="priceSelectDiv">標準価格選択区分</param>
        /// <remarks>
        /// <br>Note       : 標準価格選択区分取得処理を行います</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private void GetDisplayDivProc(List<PriceSelectSet> displayDivList, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode, out Int32 priceSelectDiv)
        {
            priceSelectDiv = 0;
            int location = -1;
            for (int i = 0; i < displayDivList.Count; i++)
            {
                // 0:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先ｺｰﾄﾞ
                if (goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                    blGoodsCode == displayDivList[i].BLGoodsCode &&
                    customerCode == displayDivList[i].CustomerCode &&
                    0 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 1:ﾒｰｶｰｺｰﾄﾞ・得意先ｺｰﾄﾞ 
                else if (goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                    customerCode == displayDivList[i].CustomerCode &&
                    1 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 2:BLｺｰﾄﾞ・得意先ｺｰﾄﾞ 
                else if (blGoodsCode == displayDivList[i].BLGoodsCode &&
                    customerCode == displayDivList[i].CustomerCode &&
                    2 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 3:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                else if (goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                    blGoodsCode == displayDivList[i].BLGoodsCode &&
                    custRateGrpCode == displayDivList[i].CustRateGrpCode &&
                    3 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 4:ﾒｰｶｰｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                else if (goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                    custRateGrpCode == displayDivList[i].CustRateGrpCode &&
                    4 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 5:BLｺｰﾄﾞ・得意先掛率ｸﾞﾙｰﾌﾟ 
                else if (blGoodsCode == displayDivList[i].BLGoodsCode &&
                   custRateGrpCode == displayDivList[i].CustRateGrpCode &&
                   5 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 6:ﾒｰｶｰｺｰﾄﾞ・BLｺｰﾄﾞ 
                else if (blGoodsCode == displayDivList[i].BLGoodsCode &&
                    goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                    6 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 7:ﾒｰｶｰｺｰﾄﾞ 
                else if (goodsMakerCode == displayDivList[i].GoodsMakerCd &&
                         7 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
                // 8:BLｺｰﾄﾞ
                else if (blGoodsCode == displayDivList[i].BLGoodsCode &&
                         8 == displayDivList[i].PriceSelectPtn)
                {
                    location = i;
                    break;

                }
            }
            if (location < 0)
            {
                priceSelectDiv = -1;
            }
            else
            {
                priceSelectDiv = displayDivList[location].PriceSelectDiv;
            }
        }
        #endregion

        #region -- クラスメンバーコピー処理 --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（表示区分マスタワーククラス⇒表示区分マスタクラス）
        /// </summary>
        /// <param name="priceSelectSetWork">表示区分マスタワーククラス</param>
        /// <returns>表示区分マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタワーククラスから表示区分マスタクラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private PriceSelectSet CopyToPriceSelectSetFromPriceSelectSetWork(PriceSelectSetWork priceSelectSetWork)
        {
            PriceSelectSet priceSelectSet = new PriceSelectSet();
            priceSelectSet.CreateDateTime = priceSelectSetWork.CreateDateTime;
            priceSelectSet.UpdateDateTime = priceSelectSetWork.UpdateDateTime;
            priceSelectSet.EnterpriseCode = priceSelectSetWork.EnterpriseCode;
            priceSelectSet.FileHeaderGuid = priceSelectSetWork.FileHeaderGuid;
            priceSelectSet.UpdEmployeeCode = priceSelectSetWork.UpdEmployeeCode;
            priceSelectSet.UpdAssemblyId1 = priceSelectSetWork.UpdAssemblyId1;
            priceSelectSet.UpdAssemblyId2 = priceSelectSetWork.UpdAssemblyId2;
            priceSelectSet.LogicalDeleteCode = priceSelectSetWork.LogicalDeleteCode;
            priceSelectSet.PriceSelectPtn = priceSelectSetWork.PriceSelectPtn;
            priceSelectSet.GoodsMakerCd = priceSelectSetWork.GoodsMakerCd;
            priceSelectSet.BLGoodsCode = priceSelectSetWork.BLGoodsCode;
            priceSelectSet.CustRateGrpCode = priceSelectSetWork.CustRateGrpCode;
            priceSelectSet.CustomerCode = priceSelectSetWork.CustomerCode;
            priceSelectSet.PriceSelectDiv = priceSelectSetWork.PriceSelectDiv;
            priceSelectSet.CustomerSnm = priceSelectSetWork.CustomerSnm;
            priceSelectSet.BLGoodsFullName = priceSelectSetWork.BLGoodsFullName;
            priceSelectSet.MakerName = priceSelectSetWork.MakerName;

            return priceSelectSet;

        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// クラスメンバーコピー処理（表示区分マスタクラス⇒表示区分マスタワーククラス）
        /// </summary>
        /// <param name="priceSelectSet">表示区分マスタクラス</param>
        /// <returns>表示区分マスタクラス</returns>
        /// <remarks>
        /// <br>Note       : 表示区分マスタクラスから表示区分マスタワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        private PriceSelectSetWork CopyToPriceSelectSetWorkFromPriceSelectSet(PriceSelectSet priceSelectSet)
        {
            PriceSelectSetWork priceSelectSetWork = new PriceSelectSetWork();
            priceSelectSetWork.CreateDateTime = priceSelectSet.CreateDateTime;
            priceSelectSetWork.UpdateDateTime = priceSelectSet.UpdateDateTime;
            priceSelectSetWork.EnterpriseCode = priceSelectSet.EnterpriseCode;
            priceSelectSetWork.FileHeaderGuid = priceSelectSet.FileHeaderGuid;
            priceSelectSetWork.UpdEmployeeCode = priceSelectSet.UpdEmployeeCode;
            priceSelectSetWork.UpdAssemblyId1 = priceSelectSet.UpdAssemblyId1;
            priceSelectSetWork.UpdAssemblyId2 = priceSelectSet.UpdAssemblyId2;
            priceSelectSetWork.LogicalDeleteCode = priceSelectSet.LogicalDeleteCode;
            priceSelectSetWork.PriceSelectPtn = priceSelectSet.PriceSelectPtn;
            priceSelectSetWork.GoodsMakerCd = priceSelectSet.GoodsMakerCd;
            priceSelectSetWork.BLGoodsCode = priceSelectSet.BLGoodsCode;
            priceSelectSetWork.CustRateGrpCode = priceSelectSet.CustRateGrpCode;
            priceSelectSetWork.CustomerCode = priceSelectSet.CustomerCode;
            priceSelectSetWork.PriceSelectDiv = priceSelectSet.PriceSelectDiv;
            priceSelectSetWork.CustomerSnm = priceSelectSet.CustomerSnm;
            priceSelectSetWork.BLGoodsFullName = priceSelectSet.BLGoodsFullName;
            priceSelectSetWork.MakerName = priceSelectSet.MakerName;

            return priceSelectSetWork;
        }

        # endregion

        /// <summary>
        /// ログ出力(DEBUG)処理
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
#if DEBUG
            System.IO.FileStream _fs;										// ファイルストリーム
            System.IO.StreamWriter _sw;										// ストリームwriter
            _fs = new System.IO.FileStream("PMHNB09003A.Log", System.IO.FileMode.Append, System.IO.FileAccess.Write, System.IO.FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
#endif
        }
    }
}
