//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : AB商品コードﾞ変換マスタアクセスクラス
// プログラム概要   : AB商品コードﾞ変換マスタの登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 李占川
// 作 成 日  2009/08/05  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// AB商品コードﾞ変換マスタテーブルアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : AB商品コードﾞ変換マスタテーブルのアクセス制御を行います。</br>
    /// <br>Programmer : 李占川</br>
    /// <br>Date       : 2009.08.04</br>
    /// <br></br>
    /// </remarks>
    public class ABGoodsCdChgAcs
    {
        private BLGoodsCodeSetAcs _bLGoodsCodeSetAcs;
        /// <summary>
        /// AB商品コードﾞテーブルアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : AB商品コードﾞマスタテーブルアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.04</br>
        /// </remarks>
        public ABGoodsCdChgAcs()
        {

        }

        /// <summary>
        /// AB商品コード検索処理（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="enterpriseCode">企業コード</param>	
        /// <param name="aBGoodsCdChgPrint">AB商品コードﾞ変換マスタ（印刷）条件クラス</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AB商品コードの全検索処理を行います。論理削除データも抽出対象となります。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.04</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode, ABGoodsCdChgPrint aBGoodsCdChgPrint)
        {
            bool nextData;
            int retTotalCnt;
            return SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetData01, 0, aBGoodsCdChgPrint);
        }

        /// <summary>
        /// AB商品コード検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevEmployeeがnullの場合のみ戻る)</param>
        /// <param name="nextData">次データ有無</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="readCnt">読込件数</param>
        /// <param name="aBGoodsCdChgPrint">抽出条件</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : AB商品コードの検索処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.04</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, ABGoodsCdChgPrint aBGoodsCdChgPrint)
        {
            this._bLGoodsCodeSetAcs = new BLGoodsCodeSetAcs();

            int status = 0;
            int checkstatus = 0;

            //次データ有無初期化
            nextData = false;
            //0で初期化
            retTotalCnt = 0;

            retList = new ArrayList();
            retList.Clear();

            ArrayList resultList = null;

            status = this._bLGoodsCodeSetAcs.SearchAll(
                                out resultList,
                                enterpriseCode);

            foreach (SAndEGoodsCdChg sAndEGoodsCdChg in resultList)
            {
                // 抽出処理
                checkstatus = DataCheck(sAndEGoodsCdChg, aBGoodsCdChgPrint);
                if (checkstatus == 0)
                {
                    //AB商品コードﾞ変換マスタ情報クラスへメンバコピー
                    retList.Add(CopyToABGoodsCdChgSetFromSAndEGoodsCdChg(sAndEGoodsCdChg, enterpriseCode));
                }
            }

            //全件リードの場合は戻り値の件数をセット
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        /// <summary>
        /// クラスメンバーコピー処理
        /// </summary>
        /// <param name="sAndEGoodsCdChg">商品コード変換クラス</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <returns>AB商品コードﾞ変換マスタ（印刷）条件クラス</returns>
        /// <remarks>
        /// <br>Note       : コピーを行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.04</br>
        /// </remarks>
        private ABGoodsCdChgSet CopyToABGoodsCdChgSetFromSAndEGoodsCdChg(SAndEGoodsCdChg sAndEGoodsCdChg, string enterpriseCode)
        {
            ABGoodsCdChgSet aBGoodsCdChgSet = new ABGoodsCdChgSet();
            aBGoodsCdChgSet.BLGoodsCode = sAndEGoodsCdChg.BLGoodsCode;
            aBGoodsCdChgSet.BLGoodsHalfName = sAndEGoodsCdChg.BLGoodsHalfName;
            aBGoodsCdChgSet.ABGoodsCode = sAndEGoodsCdChg.ABGoodsCode;

            return aBGoodsCdChgSet;
        }

        /// <summary>
        /// 抽出処理
        /// </summary>
        /// <param name="sAndEGoodsCdChg"></param>
        /// <param name="aBGoodsCdChgPrint"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 抽出処理を行います。</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009.08.06</br>
        /// </remarks>
        private int DataCheck(SAndEGoodsCdChg sAndEGoodsCdChg, ABGoodsCdChgPrint aBGoodsCdChgPrint)
        {
            int status = 0;

            // 削除指定
            if (sAndEGoodsCdChg.LogicalDeleteCode != aBGoodsCdChgPrint.LogicalDeleteCode)
            {
                status = -1;
                return status;
            }

            // 更新日時
            string upDateTime = sAndEGoodsCdChg.UpdateDateTime.Year.ToString("0000") +
                    sAndEGoodsCdChg.UpdateDateTime.Month.ToString("00") +
                    sAndEGoodsCdChg.UpdateDateTime.Day.ToString("00");

            if (aBGoodsCdChgPrint.LogicalDeleteCode == 1 &&
                aBGoodsCdChgPrint.DeleteDateTimeSt != 0 &&
                aBGoodsCdChgPrint.DeleteDateTimeEd != 0)
            {

                if (Int32.Parse(upDateTime) < aBGoodsCdChgPrint.DeleteDateTimeSt ||
                    Int32.Parse(upDateTime) > aBGoodsCdChgPrint.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (aBGoodsCdChgPrint.LogicalDeleteCode == 1 &&
                        aBGoodsCdChgPrint.DeleteDateTimeSt != 0 &&
                        aBGoodsCdChgPrint.DeleteDateTimeEd == 0)
            {
                if (Int32.Parse(upDateTime) < aBGoodsCdChgPrint.DeleteDateTimeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (aBGoodsCdChgPrint.LogicalDeleteCode == 1 &&
                    aBGoodsCdChgPrint.DeleteDateTimeSt == 0 &&
                    aBGoodsCdChgPrint.DeleteDateTimeEd != 0)
            {
                if (Int32.Parse(upDateTime) > aBGoodsCdChgPrint.DeleteDateTimeEd)
                {
                    status = -1;
                    return status;
                }
            }

            // BLコード
            if (aBGoodsCdChgPrint.BLGoodsCodeSt != 0 &&
                aBGoodsCdChgPrint.BLGoodsCodeEd != 0)
            {
                if (sAndEGoodsCdChg.BLGoodsCode < aBGoodsCdChgPrint.BLGoodsCodeSt ||
                   sAndEGoodsCdChg.BLGoodsCode > aBGoodsCdChgPrint.BLGoodsCodeEd)
                {
                    status = -1;
                    return status;
                }
            }
            else if (aBGoodsCdChgPrint.BLGoodsCodeSt != 0)
            {
                if (sAndEGoodsCdChg.BLGoodsCode < aBGoodsCdChgPrint.BLGoodsCodeSt)
                {
                    status = -1;
                    return status;
                }
            }
            else if (aBGoodsCdChgPrint.BLGoodsCodeEd != 0)
            {
                if (sAndEGoodsCdChg.BLGoodsCode > aBGoodsCdChgPrint.BLGoodsCodeEd)
                {
                    status = -1;
                    return status;
                }
            }

            return status;
        }
    }
}