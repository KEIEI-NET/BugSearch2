//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 掛率マスタ（エクスポート）
// プログラム概要   : 掛率マスタ（エクスポート）を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2013 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  ********-** 作成担当 : FSI菅原 庸平
// 作 成 日  2013/06/12  修正内容 : サポートツール対応、新規作成
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : K.Miura
// 修 正 日  2015/10/14   修正内容 : クラス名重複のため変更 
//                                   StockMasWork → RateTextWork
//                                   IStockMasDB → IRateTextDB
//                                   MediationStockMasDB → MediationRateTextDB
//----------------------------------------------------------------------------//
// 管理番号               作成担当 : 黒澤　直貴
// 修 正 日  2015/10/14   修正内容 : クラス名重複のため変更 
//                                   StockMasExportAcs → RateTextExportAcs
//                                   StockMasShWork → RateTextShWork
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 掛率マスタ（エクスポート）クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 掛率マスタ（エクスポート）インスタンスの作成を行う。</br>
    /// <br>Programmer : FSI菅原 庸平</br>
    /// <br>Date       : 2013/06/12</br>
    /// </remarks>
// --- CHG  2015/10/14 黒澤　直貴 --- >>>>
//  public class StockMasExportAcs
    public class RateTextExportAcs
// --- CHG  2015/10/14 黒澤　直貴 --- <<<<
    {
        #region ■ Private Member
        private const string PRINTSET_TABLE = "StockMasExp";

        /// <summary>リモートオブジェクト格納バッファ</summary>
// --- CHG  2015/10/14 K.Miura --- >>>>
        //Remoting.IStockMasDB _stockMasDB = null;
        IRateTextDB _rateTextDB = null;
// --- CHG  2015/10/14 K.Miura --- <<<<

        /// <summary>仕入先マスタアクセスクラス</summary>
        private SupplierAcs _supplierAcs;

        /// <summary>仕入先マスタキャッシュ</summary>
        private Dictionary<int,Supplier> _supplierDic;

        #endregion

        # region ■Constracter
        /// <summary>
        /// 掛率マスタ（エクスポート）アクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 在庫マスタ（テキスト変換）アクセスクラス。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        public RateTextExportAcs()
        {
            try
            {
                // リモートオブジェクト取得
// --- CHG  2015/10/14 K.Miura --- >>>>
//              this._stockMasDB = (IStockMasDB)MediationStockMasDB.GetStockMasDB();
                this._rateTextDB = (IRateTextDB)MediationRateTextDB.GetRateTextDB();
// --- CHG  2015/10/14 K.Miura --- <<<<
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._rateTextDB = null;
            }

            // 仕入先アクセスクラス
            _supplierAcs = new SupplierAcs();

        }
        # endregion

        #region ■ 仕入先マスタ情報検索
        /// <summary>
        /// 掛率マスタ（エクスポート）マスタデータ取得処理
        /// </summary>
        /// <param name="condition">検索条件</param>
        /// <param name="dataTable">検索データ</param>
        /// <returns>Status</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタ（エクスポート）マスタデータ取得処理を行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
// --- CHG  2015/10/14 黒澤　直貴 --- >>>>
//      public int Search(UIData.StockMasShWork condition, out DataTable dataTable)
        public int Search(UIData.RateTextShWork condition, out DataTable dataTable)
// --- CHG  2015/10/14 黒澤　直貴 --- <<<<
        {
            int status = 0;
            ArrayList retList = null;
            dataTable = new DataTable(PRINTSET_TABLE);

            // DataTableのColumnsを追加する
            CreateDataTable(ref dataTable);
            // 検索
            status = SearchProc(out retList, condition);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // 検索結果をConvertToDataTable
                ConverToDataSetStockMasInf(retList, condition, ref dataTable);
            }
            if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND || status == (int)ConstantManagement.DB_Status.ctDB_EOF)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            return status;
        }
        # endregion

        #region ■ Private Methods

        /// <summary>
        /// 掛率マスタ（エクスポート）テキストデータ検索処理
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="retTotalCnt">読込対象データ総件数(prevSupplierがnullの場合のみ戻る)</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="prevSupplier">前回最終担当者データオブジェクト（初回はnull指定必須）</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 掛率マスタの検索処理を行います。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
// --- CHG  2015/10/14 黒澤　直貴 --- >>>
//      private int SearchProc(out ArrayList retList, UIData.StockMasShWork condition)
        private int SearchProc(out ArrayList retList, UIData.RateTextShWork condition)
// --- CHG  2015/10/14 黒澤　直貴 --- <<<<
        {

            // 初期化
            retList = new ArrayList();
            //retTotalCnt = 0;

            // Searchパラメータ
            ArrayList paraList = new ArrayList();

            // 検索条件セット
// --- CHG  2015/10/14 K.Miura --- >>>>
//          StockMasWork stockMasWorkSt = new StockMasWork();
//          StockMasWork stockMasWorkEd = new StockMasWork();
            RateTextWork rateTextWorkSt = new RateTextWork();
            RateTextWork rateTextWorkEd = new RateTextWork();
// --- CHG  2015/10/14 K.Miura --- <<<<


            // 開始
            rateTextWorkSt.EnterpriseCode = condition.EnterpriseCode;     //企業コード
            rateTextWorkSt.SectionCode = condition.SectionCodeSt;         //拠点コード（開始）
            rateTextWorkSt.WarehouseCd = condition.WarehouseCdSt;       //単価種類

            // 終了
            rateTextWorkEd.SectionCode = condition.SectionCodeEd;         //拠点コード（終了）

            // Searchパラメータ
            paraList.Add(rateTextWorkSt);
            paraList.Add(rateTextWorkEd);

            object paraobj = paraList;

            // 検索
            object retobj = null;

            int status_o = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // リモート
            status_o = this._rateTextDB.Search(out retobj, paraobj, 0, 0);

            // 検索結果判定
            switch (status_o)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:

                    if (retobj != null)
                    {

                        retList = (ArrayList)retobj;

                    }
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    status_o = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    break;
                default:
                    return status_o;
            }

            return status_o;
        }

 
        /// <summary>
        /// DataTableのColumnsを追加する
        /// </summary>
        /// <param name="dataTable">結果DataTable</param>
        /// <remarks>
        /// <br>Note       : DataTableのColumnsを追加する。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void CreateDataTable(ref DataTable dataTable)
        {
            dataTable.Columns.Add("enterpriseCode", typeof(string));           // 企業コード
            dataTable.Columns.Add("拠点コード", typeof(string));               // 拠点コード
            dataTable.Columns.Add("単価掛率設定区分", typeof(string));         // 単価掛率設定区分
            dataTable.Columns.Add("単価種類", typeof(string));                 // 単価種類
            dataTable.Columns.Add("掛率設定区分", typeof(string));             // 掛率設定区分
            dataTable.Columns.Add("掛率設定区分(商品)", typeof(string));       // 掛率設定区分(商品)
            dataTable.Columns.Add("掛率設定名称(商品)", typeof(string));       // 掛率設定名称(商品)
            dataTable.Columns.Add("掛率設定区分(得意先)", typeof(string));     // 掛率設定区分(得意先)
            dataTable.Columns.Add("掛率設定名称(得意先)", typeof(string));     // 掛率設定名称(得意先)
            dataTable.Columns.Add("商品メーカーコード", typeof(string));       // 商品メーカーコード
            dataTable.Columns.Add("商品番号", typeof(string));                 // 商品番号
            dataTable.Columns.Add("商品掛率ランク", typeof(string));           // 商品掛率ランク
            dataTable.Columns.Add("商品掛率グループコード", typeof(string));   // 商品掛率グループコード
            dataTable.Columns.Add("BLグループコード", typeof(string));         // BLグループコード
            dataTable.Columns.Add("BL商品コード", typeof(string));             // BL商品コード
            dataTable.Columns.Add("得意先コード", typeof(string));             // 得意先コード
            dataTable.Columns.Add("得意先掛率グループコード", typeof(string)); // 得意先掛率グループコード
            dataTable.Columns.Add("仕入先コード", typeof(string));             // 仕入先コード
            dataTable.Columns.Add("ロット数", typeof(string));                 // ロット数
            dataTable.Columns.Add("価格(浮動)", typeof(string));               // 価格(浮動)
            dataTable.Columns.Add("掛率", typeof(string));                     // 掛率
            dataTable.Columns.Add("UP率", typeof(string));                     // UP率
            dataTable.Columns.Add("粗利確保率", typeof(string));               // 粗利確保率
            dataTable.Columns.Add("単価端数処理単位", typeof(string));         // 単価端数処理単位
            dataTable.Columns.Add("単価端数処理区分", typeof(string));         // 単価端数処理区分
        }

        /// <summary>
        /// 検索結果をConvertToDataTable
        /// </summary>
        /// <param name="retList">検索結果</param>
        /// <param name="postcardEnvelopeDMWork">検索条件</param>
        /// <param name="dataTable">結果</param>
        /// <remarks>
        /// <br>Note       : 検索結果をConvertToDataTableに行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
// --- CHG  2015/10/14 黒澤　直貴 --- >>>>
//      private void ConverToDataSetStockMasInf(ArrayList retList, UIData.StockMasShWork StockMasShWork, ref DataTable dataTable)
        private void ConverToDataSetStockMasInf(ArrayList retList, UIData.RateTextShWork rateTextShWork, ref DataTable dataTable)
// --- CHG  2015/10/14 黒澤　直貴 --- <<<<
        {
            _supplierDic = new Dictionary<int, Supplier>();

// --- CHG  2015/10/14 K.Miura --- >>>>
//          foreach (StockMasWork work in retList)
            foreach (RateTextWork work in retList)
// --- CHG  2015/10/14 K.Miura --- <<<<
            {
                DataRow dataRow = dataTable.NewRow();

                SetValue(ref dataRow, "enterpriseCode", work.EnterpriseCode, 0, 0);            // 企業コード              (string)
                SetValue(ref dataRow, "拠点コード", work.SectionCode, 0, 0);                   // 拠点コード              (string)
                SetValue(ref dataRow, "単価掛率設定区分", work.UnitRateSetDivCd, 0, 0);        // 単価掛率設定区分        (string)
                SetValue(ref dataRow, "単価種類", work.UnitPriceKind, 0, 0);                   // 単価種類                (string)
                SetValue(ref dataRow, "掛率設定区分", work.RateSettingDivide, 0, 0);           // 掛率設定区分            (string)
                SetValue(ref dataRow, "掛率設定区分(商品)", work.RateMngGoodsCd, 0, 0);        // 掛率設定区分(商品)      (string)
                SetValue(ref dataRow, "掛率設定名称(商品)", work.RateMngGoodsNm, 0, 0);        // 掛率設定名称(商品)      (string)
                SetValue(ref dataRow, "掛率設定区分(得意先)", work.RateMngCustCd, 0, 0);       // 掛率設定区分(得意先)    (string)
                SetValue(ref dataRow, "掛率設定名称(得意先)", work.RateMngCustNm, 0, 0);       // 掛率設定名称(得意先)    (string)
                SetValue(ref dataRow, "商品メーカーコード", work.GoodsMakerCd, 6, 0);          // 商品メーカーコード      (Int32)
                SetValue(ref dataRow, "商品番号", work.GoodsNo, 0, 0);                         // 商品番号                (string)
                SetValue(ref dataRow, "商品掛率ランク", work.GoodsRateRank, 0, 0);             // 商品掛率ランク          (string)
                SetValue(ref dataRow, "商品掛率グループコード", work.GoodsRateGrpCode, 4, 0);  // 商品掛率グループコード  (Int32)
                SetValue(ref dataRow, "BLグループコード", work.BLGroupCode, 5, 0);             // BLグループコード        (Int32)
                SetValue(ref dataRow, "BL商品コード", work.BLGoodsCode, 8, 0);                 // BL商品コード            (Int32)
                SetValue(ref dataRow, "得意先コード", work.CustomerCode, 9, 0);                // 得意先コード            (Int32)
                SetValue(ref dataRow, "得意先掛率グループコード", work.CustRateGrpCode, 4, 0); // 得意先掛率グループコード(Int32)
                SetValue(ref dataRow, "仕入先コード", work.SupplierCd, 9, 0);                  // 仕入先コード            (Int32)
                SetValue(ref dataRow, "ロット数", work.LotCount, 7, 2);                        // ロット数                (Double)
                SetValue(ref dataRow, "価格(浮動)", work.PriceFl, 9, 2);                       // 価格(浮動)              (Double)
                SetValue(ref dataRow, "掛率", work.RateVal, 6, 2);                             // 掛率                    (Double)
                SetValue(ref dataRow, "UP率", work.UpRate, 3, 2);                              // UP率                    (Double)
                SetValue(ref dataRow, "粗利確保率", work.GrsProfitSecureRate, 2, 2);           // 粗利確保率              (Double)
                SetValue(ref dataRow, "単価端数処理単位", work.UnPrcFracProcUnit, 6, 2);       // 単価端数処理単位        (Double)
                SetValue(ref dataRow, "単価端数処理区分", work.UnPrcFracProcDiv, 2, 0);        // 単価端数処理区分        (Int32)

                dataTable.Rows.Add(dataRow);
            }
        }

        /// <summary>
        /// 結果格納用DataRowに値を設定
        /// </summary>
        /// <param name="dataRow">値を設定するDataRow</param>
        /// <param name="key">設定する値のキー</param>
        /// <param name="value">設定する値</param>
        /// <param name="length">設定する値が数値だった場合の出力桁数</param>
        /// <param name="length">設定する値がDouble型だった場合の小数点以下出力桁数</param>
        /// <remarks>
        /// <br>Note       : AppendZero行う。</br>
        /// <br>Programmer : FSI菅原 庸平</br>
        /// <br>Date       : 2013/06/12</br>
        /// </remarks>
        private void SetValue(ref DataRow dataRow, string key, object value, int length, int pointLength)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException("key");
            }
            if (null == value)
            {
                dataRow[key] = string.Empty;
            }
            else if (value is string)
            {
                string stringVal = value as string;
                if (!string.IsNullOrEmpty(stringVal))
                {
                    // カンマの文字変換
                    stringVal = stringVal.Replace(
                        Properties.Resources.OldStringComma, Properties.Resources.NewStringComma);
                    // ダブルクォーテーションの文字変換
                    stringVal = stringVal.Replace(
                        Properties.Resources.OldStringDQuotation, Properties.Resources.NewStringDQuotation);
                    // エンマークの文字変換
                    if (!string.IsNullOrEmpty(Properties.Resources.OldStringYen))
                    {
                        stringVal = stringVal.Replace(
                            Properties.Resources.OldStringYen, Properties.Resources.NewStringYen);
                    }
                }
                dataRow[key] = stringVal;
            }
            else if ((value is double) || (value is Double))
            {
                double dVal = Convert.ToDouble(value);
                bool neg = dVal < 0;
                int len = neg ? length - 1 : length;
                dVal = Math.Abs(dVal); // 絶対値を取得
                string outFormat = new string('0', len); // 整数部の桁数を指定する
                if (pointLength > 0)
                {
                    // 小数部のフォーマットを桁数分追記する
                    outFormat += "." + new string('0', pointLength);
                }
                string valueString = dVal.ToString(outFormat);

                // 桁あふれチェック
                int pos = valueString.IndexOf('.');
                if (pos > len)
                {
                    valueString = valueString.Substring(pos - len, len + (pointLength > 0 ? pointLength + 1 : 0));
                }
                dataRow[key] = (neg ? "-" : "") + valueString;
            }
            else if ((value is int) || (value is Int32) || (value is Int64))
            {
                long longVal = Convert.ToInt64(value);
                bool neg = longVal < 0;
                int len = neg ? length - 1 : length;
                string outFormat = new string('0', len); // 整数部の桁数を指定する
                string valueString = longVal.ToString(outFormat);

                // 桁あふれチェック
                valueString = valueString.Substring(valueString.Length - len, len);
                dataRow[key] = (neg ? "-" : "") + valueString;
            }
            else
            {
                dataRow[key] = value.ToString();
            }
        }

        # endregion

    }
}
