using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text;
using System.Data;
using System.Diagnostics;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Library.Windows.Forms
{
    /// <summary>
    ///	部品選択UI制御クラス
    /// </summary>
    /// <remarks>
    /// <br>note			:	部品選択フローの制御を行い、それぞれの部品選択UIを表示します</br>
    /// <br>Programer		:	30290</br>
    /// <br>Date			:	2008.07.03</br>
    /// <br></br>
    /// <br></br>
    /// <br>Update Note	    : ＵＩのパラメータにオーナーフォームを追加（コメント無し)</br>
    /// <br>Programmer	    : 21024　佐々木 健</br>
    /// <br>Date		    : 2009.02.19</br>
    /// <br></br>
    /// <br>Update Note     : 2009/10/20 李占川</br>
    /// <br>                PM.NS-3-A・保守依頼②</br>
    /// <br>                標準価格選択ウインドウの表示処理の追加</br>
    /// <br>Update Note     : 2009/11/13 李占川</br>
    /// <br>                redmine#1268,表示パターンの修正</br>
    /// <br>Update Note     : 李占川 2009/11/16</br>
    /// <br>                : redmine#1320,標準価格選択表示の修正</br>
    /// <br></br>
    /// <br>Update Note　　 : 検索見積で、セット品を検索した場合にセット子情報が選択部品として戻り値になる不具合の修正(MANTIS[0014660])</br>
    /// <br>Programmer      : 21024　佐々木 健</br>
    /// <br>Date            : 2009/12/01</br>
    /// <br></br>
    /// <br>Update Note　　 : BLコード検索時、選択した品番は選択部品情報から取得するように修正</br>
    /// <br>Programmer      : 21024　佐々木 健</br>
    /// <br>Date            : 2009/12/14</br>
    /// <br></br>
    /// <br>Update Note　　 : PM7モードでBLコード検索時、部品選択後の各種ウィンドウでESC押下時に1品目単位で処理するように修正(MANTIS[0013829])</br>
    /// <br>Programmer      : 21024　佐々木 健</br>
    /// <br>Date            : 2009/12/16</br>
    /// <br></br>
    /// <br>Update Note　　 : 検索見積で代替品を選択しても部品選択画面に反映されない現象の修正(MANTIS[0014697])</br>
    /// <br>Programmer      : 21024　佐々木 健</br>
    /// <br>Date            : 2009/12/18</br>
    /// <br></br>
    /// <br>Update Note　　 : ＳＣＭの組み込み</br>
    /// <br>                  ・制御モード追加(SCM対応)</br>
    /// <br>Programmer      : 21024　佐々木 健</br>
    /// <br>Date            : 2010/02/25</br>
    /// <br></br>
    /// <br>Update Note　　 : 部品選択ウィンドウに表示される部品リストを取得できるメソッドを追加</br>
    /// <br>Programmer      : 21024　佐々木 健</br>
    /// <br>Date            : 2010/03/15</br>
    /// <br></br>
    /// <br>Update Note　　 : 優良の結合検索の場合にのみ結合元検索が動作するように修正</br>
    /// <br>Programmer      : 22008　長内 数馬</br>
    /// <br>Date            : 2010/04/16</br>
    /// <br></br>
    /// <br>Update Note　　 : 自由検索オプション対応　（ＢＬコード検索⇒自由検索部品⇒提供優良⇒セットが有る場合、画面制御変更が必要な為対応）</br>
    /// <br>Programmer      : 22018　鈴木 正臣</br>
    /// <br>Date            : 2010/04/28</br>
    /// <br></br>
    /// <br>Update Note　　 : 成果物統合</br>
    /// <br>                    ＤＣ配置(高速化) 2010/04/16 の組込</br>
    /// <br>                    自由検索 2010/04/28 の組込</br>
    /// <br>Programmer      : 22018　鈴木 正臣</br>
    /// <br>Date            : 2010/06/04</br>
    /// <br></br>
    /// <br>Update Note　　 : 成果物統合</br>
    /// <br>                    品番検索後に売伝を終了すると例外発生する件の対応(各種ウインドウ終了時にDispose追加)</br>
    /// <br>Programmer      : 20056 對馬 大輔</br>
    /// <br>Date            : 2010/07/01</br>
    /// <br></br>
    /// <br>Update Note　　 : 成果物統合２</br>
    /// <br>                    検索見積発行で、同一品番(オプション違い)の純正品のみ対象の場合に、</br>
    /// <br>                    部品選択＝「する」に設定しても選択ＵＩが表示されない件の修正。</br>
    /// <br>Programmer      : 22018　鈴木 正臣</br>
    /// <br>Date            : 2010/07/13</br>
    /// <br></br>
    /// <br>Update Note　　 : 部品選択UIの制御を修正</br>
    /// <br>                  （※部品選択で結合のある品番を複数選択して、２件目の結合選択でESC押下すると１件目の結合選択に戻ってしまう件の修正）</br>
    /// <br>Programmer      : 22018　鈴木 正臣</br>
    /// <br>Date            : 2010/10/01</br>
    /// <br></br>
    /// <br>Update Note　　 : MANTIS:16822 機能追加</br>
    /// <br>                    優良品番検索の場合、結合検索制御文字が含まれなくても標準価格選択処理を行う</br>
    /// <br>Programmer      : 20056 對馬 大輔</br>
    /// <br>Date            : 2010/12/14</br>
    /// <br></br>
    /// <br>Update Note　　 : 障害対応</br>
    /// <br>                    BLコード検索を行い表示区分マスタに該当しない場合、標準価格選択が表示されない件の対応</br>
    /// <br>Programmer      : 20056 對馬 大輔</br>
    /// <br>Date            : 2011/01/13</br>
    /// <br></br>
    /// <br>Update Note　　 : 障害対応</br>
    /// <br>                    "."無し品番検索で代替先の結合先を選択した際にエラー発生する件の修正</br>
    /// <br>                    (PM.NSは代替する時は部品検索を表示する仕様の為、この場合は結合検索ありと同等の処理が必要になる)</br>
    /// <br>Programmer      : 22018 鈴木 正臣</br>
    /// <br>Date            : 2011/01/27</br>
    /// <br></br>
    /// <br>Update Note　　 : 障害対応</br>
    /// <br>                    2011/01/27分の修正。優良品番"."無しで表示区分マスタに登録ない時は表示しないよう修正。(元の動作)</br>
    /// <br>Programmer      : 22018 鈴木 正臣</br>
    /// <br>Date            : 2011/02/10</br>
    /// <br></br>
    /// <br>Update Note　　 : 障害対応</br>
    /// <br>                    2010/12/14分の修正。ＢＬコード検索で優良品を選択時の処理が遅い件の修正。</br>
    /// <br>Programmer      : 22018 鈴木 正臣</br>
    /// <br>Date            : 2011/02/24</br>
    /// <br></br>
    /// <br>Update Note　　 : 障害対応</br>
    /// <br>                    2010/12/14分の修正。優良品の品番検索で処理が遅い件の修正。(結合元検索は必要な時だけ処理する)</br>
    /// <br>Programmer      : 22018 鈴木 正臣</br>
    /// <br>Date            : 2011/02/25</br>
    /// <br></br>
    /// <br>Update Note　　 : 優良品番 AND "."無し AND 表示区分マスタで"優良"に設定されている場合 は結合元検索しないよう変更。</br>
    /// <br>Programmer      : 22018 鈴木 正臣</br>
    /// <br>Date            : 2011/05/12</br>
    /// <br></br>
    /// <br>Update Note     : 2011/11/21 李占川 Redmine#7876の対応</br>
    /// <br>                  結合先品番を選択した訳ではないので標準価格選択ウインドの表示を行わない様に修正</br>
    /// <br></br>
    /// <br>Update Note　　 : 障害対応</br>
    /// <br>                    対応No120(#7876)のデグレ対応</br>
    /// <br>Programmer      : 20056 對馬 大輔</br>
    /// <br>Date            : 2011/12/16</br>
    /// <br></br>
    /// <br>Update Note     : 2012/04/06 鄧潘ハン</br>
    /// <br>管理番号        : 10801804-00 2012/05/24配信分</br>
    /// <br>                  Redmine#29153   標準価格選択画面が表示されないについての修正</br>
    /// <br>Update Note     : 2012/06/11 gezh</br>
    /// <br>管理番号        : 10801804-00</br>
    /// <br>                  Redmine#30392 売上伝票入力 標準価格選択表示の対応</br>
    /// <br>Update Note     : 2012/06/26 凌小青</br>
    /// <br>                  Redmine#30595 売上伝票入力標準価格選択ガイドの修正</br>
    /// <br></br>
    /// <br>Update Note     : 2015/04/06 30757 佐々木 貴英</br>
    /// <br>管理番号        : 11070149-00</br>
    /// <br>                  仕掛№2405 得意先変更時表示区分再取得対応</br>
    /// <br></br>
    /// </remarks>
    public static class UIDisplayControl
    {
        /// <summary>
        /// 部品選択制御メソッド
        /// </summary>
        /// <param name="carInfo">車型式情報データセット</param>
        /// <param name="partsInfo">部品情報データセット</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        /// <remarks>
        /// <br>note			:	</br>
        /// <br>Programer		:	30290</br>
        /// <br>Date			:	2008.07.03</br>
        /// </remarks>
        public static DialogResult ProcessPartsSearch(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            DialogResult ret = DialogResult.Cancel;
            int SearchUICntDivCd = partsInfo.SearchCondition.SearchCntSetWork.SearchUICntDivCd;
            if (SearchUICntDivCd == 0)  // PM7方式画面制御
            {
                ret = DisplayControlPM7(owner, carInfo, partsInfo);
            }
            else                         // PM.NS方式画面制御(本来は1ですが、0以外は1と見なす)
            {
                ret = DisplayControlNS(owner, carInfo, partsInfo);
            }
            return ret;
        }

        #region [PM7式選択UI制御]
        /// <summary>
        /// 部品選択制御メソッド(PM7方式)
        /// </summary>
        /// <param name="carInfo">車型式情報データセット</param>
        /// <param name="partsInfo">部品情報データセット</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        /// <remarks>
        /// <br>note			:	</br>
        /// <br>Programer		:	30290</br>
        /// <br>Date			:	2008.10.06</br>
        /// </remarks>
        private static DialogResult DisplayControlPM7(IWin32Window owner,PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            DialogResult ret = DialogResult.Cancel;
            SearchFlag flg = partsInfo.SearchCondition.SearchFlg;
            if ((int)flg < 2) // BL検索時
            {
                ret = BLSearch7(owner, carInfo, partsInfo);
            }
            else // 品番検索時
            {
                ret = PartsNoSearch7(owner, partsInfo, flg);
            }
            return ret;
        }

        /// <summary>
        /// BL検索時の画面制御(PM7式制御)
        /// </summary>
        /// <param name="carInfo">車両情報</param>
        /// <param name="partsInfo">部品情報</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 李占川 2009/10/20</br>
        /// <br>            : 標準価格の選択を可能にする。</br>
        /// </remarks>
        private static DialogResult BLSearch7(IWin32Window owner,PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            string goodsNo = string.Empty;
            PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet;
            List<PartsInfoDataSet.UsrGoodsInfoRow> lstSelected = new List<PartsInfoDataSet.UsrGoodsInfoRow>();
            Process currentProcess = Process.GetCurrentProcess();
            DialogResult retDialog = DialogResult.OK;

            retDialog = ShowPartsUI(owner, carInfo, partsInfo);
            currentProcess.Refresh();

            if (retDialog == DialogResult.Cancel)
                return retDialog;
            // 2009/12/16 >>>
#if false

            //PartsInfoDataSet.UsrGoodsInfoRow[] rows = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
            //partsInfo.UsrGoodsInfo.ResetSelectionState();
            //for (int i = 0; i < rows.Length; i++)
            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = selInfo.RowGoods;
                //string query = string.Format("{0}={1} AND {2}='{3}'",
                //    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, rows[i].GoodsMakerCd,
                //    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, rows[i].GoodsNo);
                PartsInfoDataSet.PartsInfoRow _partsInfoRow = null;
                PartsInfoDataSet.PartsInfoRow[] childRows = (PartsInfoDataSet.PartsInfoRow[])row.GetChildRows("UsrGoodsInfo_PartsInfo");
                if (childRows.Length > 0)
                {
                    _partsInfoRow = childRows[0];
                }
                string _clgPartsNo;
                string _newPartsNo;
                if (_partsInfoRow != null)
                {
                    _clgPartsNo = _partsInfoRow.ClgPrtsNoWithHyphen;
                    _newPartsNo = _partsInfoRow.NewPrtsNoWithHyphen;
                    // 2009/12/14 >>>
                    //if (_clgPartsNo != _newPartsNo &&
                    //    ((row.NewGoodsNo != _clgPartsNo && row.NewGoodsNo != partsInfo.GoodsNoSel) // カタログ品番以外に代替した場合
                    //    || partsInfo.GoodsNoSel == _clgPartsNo)) // カタログ品番に代替した場合
                    if (_clgPartsNo != _newPartsNo &&
                        ( ( row.NewGoodsNo != _clgPartsNo && row.NewGoodsNo != selInfo.SelectedPartsNo ) // カタログ品番以外に代替した場合
                        || selInfo.SelectedPartsNo == _clgPartsNo )) // カタログ品番に代替した場合
                    // 2009/12/14 <<<
                    { // NewGoodsNoは純正部品選択UIでの代替などによる処理のため使う。
                        _newPartsNo = _clgPartsNo;
                    }
                }
                else
                {
                    _clgPartsNo = row.GoodsNo;
                    _newPartsNo = row.GoodsNo;
                }
                string query = string.Format("{0}={1} AND ({2}='{3}' OR {4}='{5}')",
                    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, row.GoodsMakerCd,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, _clgPartsNo,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, _newPartsNo);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(query);

                if (rowGoodsJoin.Length == 0) // 選択した部品の結合部品がない
                {
                    // 純正部品に設定されているセット情報があれば処理する                    
                    if (row.NewGoodsNo != string.Empty) // 代替がある場合は代替品番でセット子検索
                        goodsNo = row.NewGoodsNo;
                    else
                        goodsNo = row.GoodsNo;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // 選択した部品のセット部品がない
                    {
                        if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                            selInfo.Selected = true;
                    }
                    else
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // セット選択UI表示

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        //PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                        //lstSelected.AddRange(rowsSet);
                    }

                    //------------ADD 2009/10/20--------->>>>>
                    partsInfo.UsrGoodsInfo.RowToProcess = row; // ADD 2009/11/30
                    retDialog = ShowPriceUI2(owner, carInfo, partsInfo); // 標準価格選択UI表示

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //------------ADD 2009/10/20---------<<<<<
                    continue;
                }
                partsInfo.JoinSrcSelInf = selInfo;
                retDialog = ShowJoinUI(owner, partsInfo, row); // 結合選択UI表示

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    return retDialog;
                }

                if (selInfo.JoinSet)
                {
                    // 純正部品に設定されているセット情報があれば処理する                    
                    if (row.NewGoodsNo != string.Empty) // 代替がある場合は代替品番でセット子検索
                        goodsNo = row.NewGoodsNo;
                    else
                        goodsNo = row.GoodsNo;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length != 0) // 選択した純正部品のセット部品がある
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // セット選択UI表示

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                    }
                }

                //PartsInfoDataSet.UsrGoodsInfoRow[] rowsJoin = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                //partsInfo.UsrGoodsInfo.ResetSelectionState();
                foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods.Values)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow row2 = selInfo2.RowGoods;
                    if (row2.NewGoodsNo != string.Empty) // 代替がある場合は代替品番でセット子検索
                        goodsNo = row2.NewGoodsNo;
                    else
                        goodsNo = row2.GoodsNo;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row2.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);
                    //query = string.Format("{0}={1} AND {2}='{3}'",
                    //    partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, rowsJoin[j].GoodsMakerCd,
                    //    partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, rowsJoin[j].GoodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // 選択した部品のセット部品がない
                    {
                        if (selInfo2.IsThereSelection == false)
                            selInfo2.Selected = true;

                        //------------ADD 2009/11/17--------->>>>>
                        partsInfo.UsrGoodsInfo.RowToProcess = row; // ADD 2009/11/30
                        retDialog = ShowPriceUI(owner, carInfo, partsInfo, row2); // 標準価格選択UI表示

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        //------------ADD 2009/11/17---------<<<<<
                        continue;
                    }
                    partsInfo.SetSrcSelInf = selInfo2;
                    retDialog = ShowSetUI(owner, partsInfo, row2); // セット選択UI表示

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                    //lstSelected.AddRange(rowsSet);

                    //------------ADD 2009/10/20--------->>>>>
                    retDialog = ShowPriceUI(owner, carInfo, partsInfo, row2); // 標準価格選択UI表示

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //------------ADD 2009/10/20---------<<<<<
                }
                if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                    selInfo.Selected = true;
            }

            //for (int i = 0; i < lstSelected.Count; i++)
            //{
            //    lstSelected[i].SelectionState = true;
            //}
            partsInfo.UsrGoodsInfo.AcceptChanges();
#endif
            retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
            // 2009/12/16 <<<
            return retDialog;
        }
#if  DEF20081024
        private static DialogResult BLSearch7(PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            List<PartsInfoDataSet.UsrGoodsInfoRow> lstSelected = new List<PartsInfoDataSet.UsrGoodsInfoRow>();
            Process currentProcess = Process.GetCurrentProcess();
            DialogResult retDialog = DialogResult.OK;

            retDialog = ShowPartsUI(carInfo, partsInfo);
            currentProcess.Refresh();

            if (retDialog == DialogResult.Cancel)
                return retDialog;

            PartsInfoDataSet.UsrGoodsInfoRow[] rows = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
            partsInfo.UsrGoodsInfo.ResetSelectionState();
            for (int i = 0; i < rows.Length; i++)
            {
                string query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, rows[i].GoodsMakerCd,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, rows[i].GoodsNo);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(query);

                if (rowGoodsJoin.Length == 0) // 選択した部品の結合部品がない
                {
                    // 純正部品に設定されているセット情報があれば処理する
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, rows[i].GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, rows[i].GoodsNo);
                    PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // 選択した部品のセット部品がない
                    {
                        lstSelected.Add(rows[i]);
                    }
                    else
                    {
                        retDialog = ShowSetUI(partsInfo, rows[i]); // セット選択UI表示

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                        lstSelected.AddRange(rowsSet);
                    }
                    continue;
                }

                retDialog = ShowJoinUI(partsInfo, rows[i]); // 結合選択UI表示

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    return retDialog;
                }

                PartsInfoDataSet.UsrGoodsInfoRow[] rowsJoin = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                partsInfo.UsrGoodsInfo.ResetSelectionState();
                for (int j = 0; j < rowsJoin.Length; j++)
                {
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, rowsJoin[j].GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, rowsJoin[j].GoodsNo);
                    PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // 選択した部品のセット部品がない
                    {
                        lstSelected.Add(rowsJoin[j]);
                        continue;
                    }

                    retDialog = ShowSetUI(partsInfo, rowsJoin[j]); // セット選択UI表示

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                    lstSelected.AddRange(rowsSet);
                }

            }

            for (int i = 0; i < lstSelected.Count; i++)
            {
                lstSelected[i].SelectionState = true;
            }
            partsInfo.UsrGoodsInfo.AcceptChanges();

            return retDialog;
        }
#endif

        // 2009/12/16 Add >>>
        /// <summary>
        /// PM7モードのBLコード検索で、部品選択後のウィンドウ制御を行います。
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="carInfo">車両情報</param>
        /// <param name="partsInfo">部品情報</param>
        /// <returns></returns>
        private static DialogResult BLSearch7WinCtrlProc_AfterPrtSel(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            string goodsNo = string.Empty;
            PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet;
            DialogResult retDialog = DialogResult.Cancel;
            bool isCancel = false;

            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
            {
                // --- DEL m.suzuki 2010/04/28 ---------->>>>>
                //if (selInfo.IsThereSelection || selInfo.Selected)
                //{
                //    retDialog = DialogResult.OK;
                //    continue;
                //}
                // --- DEL m.suzuki 2010/04/28 ----------<<<<<
                // --- ADD m.suzuki 2010/10/01 ---------->>>>>
                if ( (selInfo.IsThereSelection || selInfo.Selected) && !selInfo.ExtractSetParent )
                {
                    retDialog = DialogResult.OK;
                    continue;
                }
                // --- ADD m.suzuki 2010/10/01 ----------<<<<<

                PartsInfoDataSet.UsrGoodsInfoRow row = selInfo.RowGoods;
                PartsInfoDataSet.PartsInfoRow _partsInfoRow = null;
                PartsInfoDataSet.PartsInfoRow[] childRows = (PartsInfoDataSet.PartsInfoRow[])row.GetChildRows("UsrGoodsInfo_PartsInfo");
                if (childRows.Length > 0)
                {
                    _partsInfoRow = childRows[0];
                }
                string _clgPartsNo;
                string _newPartsNo;
                if (_partsInfoRow != null)
                {
                    _clgPartsNo = _partsInfoRow.ClgPrtsNoWithHyphen;
                    _newPartsNo = _partsInfoRow.NewPrtsNoWithHyphen;
                    if (_clgPartsNo != _newPartsNo &&
                        ( ( row.NewGoodsNo != _clgPartsNo && row.NewGoodsNo != selInfo.SelectedPartsNo ) // カタログ品番以外に代替した場合
                        || selInfo.SelectedPartsNo == _clgPartsNo )) // カタログ品番に代替した場合
                    { // NewGoodsNoは純正部品選択UIでの代替などによる処理のため使う。
                        _newPartsNo = _clgPartsNo;
                    }
                }
                else
                {
                    _clgPartsNo = row.GoodsNo;
                    _newPartsNo = row.GoodsNo;
                }
                string query = string.Format("{0}={1} AND ({2}='{3}' OR {4}='{5}')",
                    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, row.GoodsMakerCd,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, _clgPartsNo,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, _newPartsNo);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(query);

                if (rowGoodsJoin.Length == 0) // 選択した部品の結合部品がない
                {
                    // 純正部品に設定されているセット情報があれば処理する                    
                    if (row.NewGoodsNo != string.Empty) // 代替がある場合は代替品番でセット子検索
                        goodsNo = row.NewGoodsNo;
                    else
                        goodsNo = row.GoodsNo;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // 選択した部品のセット部品がない
                    {
                        if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                            selInfo.Selected = true;
                    }
                    else
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // セット選択UI表示

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            // 選択部品情報から削除する
                            partsInfo.RemoveSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key);
                            partsInfo.AcceptChanges();
                            isCancel = true;
                            retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
                            break;
                        }
                    }

                    partsInfo.UsrGoodsInfo.RowToProcess = row;
                    retDialog = ShowPriceUI2(owner, carInfo, partsInfo); // 標準価格選択UI表示

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        // 選択部品情報から削除する
                        partsInfo.RemoveSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key);
                        partsInfo.AcceptChanges();
                        isCancel = true;

                        retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
                        break;
                    }
                    continue;
                }
                partsInfo.JoinSrcSelInf = selInfo;
                retDialog = ShowJoinUI(owner, partsInfo, row); // 結合選択UI表示

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();

                    // 選択部品情報から削除する
                    partsInfo.RemoveSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key);
                    partsInfo.AcceptChanges();
                    isCancel = true;
                    retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
                    break;
                }

                if (selInfo.JoinSet)
                {
                    // 純正部品に設定されているセット情報があれば処理する                    
                    if (row.NewGoodsNo != string.Empty) // 代替がある場合は代替品番でセット子検索
                        goodsNo = row.NewGoodsNo;
                    else
                        goodsNo = row.GoodsNo;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length != 0) // 選択した純正部品のセット部品がある
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // セット選択UI表示

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            // 選択部品情報から削除する
                            partsInfo.RemoveSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key);
                            partsInfo.AcceptChanges();
                            isCancel = true;
                            retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
                            break;
                        }
                    }
                }

                if (selInfo.ListChildGoods != null && selInfo.ListChildGoods.Count > 0)
                {
                    retDialog = BLSearch7WinCtrlProc_AfterJoinSel(owner, carInfo, partsInfo, row, selInfo);
                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        // 選択部品情報から削除する
                        partsInfo.RemoveSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key);
                        partsInfo.AcceptChanges();
                        isCancel = true;
                        retDialog = BLSearch7WinCtrlProc_AfterPrtSel(owner, carInfo, partsInfo);
                        break;
                    }
                }

                if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                    selInfo.Selected = true;
            }

            partsInfo.UsrGoodsInfo.AcceptChanges();

            // キャンセルを押した履歴があり、且つ選択情報が何もない
            if (isCancel && partsInfo.ListSelectionInfo.Keys.Count == 0)
            {
                retDialog = DialogResult.Cancel;
            }

            return retDialog;
        }

        /// <summary>
        /// PM7モードのBLコード検索で、結合選択後のウィンドウ制御を行います。
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="carInfo"></param>
        /// <param name="partsInfo"></param>
        /// <param name="selInfo"></param>
        /// <returns></returns>
        private static DialogResult BLSearch7WinCtrlProc_AfterJoinSel(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo, PartsInfoDataSet.UsrGoodsInfoRow row, SelectionInfo selInfo)
        {
            string goodsNo = string.Empty;
            DialogResult retDialog = DialogResult.Cancel;
            bool isCancel = false;
            string query;
            PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet;
            foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods.Values)
            {
                // 既に選択されたデータがある場合は飛ばす（再帰によって複数回呼ばれる為）
                if (selInfo2.IsThereSelection || selInfo2.Selected)
                {
                    retDialog = DialogResult.OK;
                    continue;
                }

                PartsInfoDataSet.UsrGoodsInfoRow row2 = selInfo2.RowGoods;
                if (row2.NewGoodsNo != string.Empty) // 代替がある場合は代替品番でセット子検索
                    goodsNo = row2.NewGoodsNo;
                else
                    goodsNo = row2.GoodsNo;
                query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row2.GoodsMakerCd,
                    partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);

                rowJoinSet =
                    (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                if (rowJoinSet.Length == 0) // 選択した部品のセット部品がない
                {
                    if (selInfo2.IsThereSelection == false)
                        selInfo2.Selected = true;

                    partsInfo.UsrGoodsInfo.RowToProcess = row;
                    retDialog = ShowPriceUI(owner, carInfo, partsInfo, row2); // 標準価格選択UI表示

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        partsInfo.RemoveSelectionInfo(selInfo.ListChildGoods, selInfo2.Key);
                        partsInfo.AcceptChanges();
                        isCancel = true;
                        retDialog = BLSearch7WinCtrlProc_AfterJoinSel(owner, carInfo, partsInfo, row, selInfo);
                        break;
                    }
                    continue;
                }
                partsInfo.SetSrcSelInf = selInfo2;
                retDialog = ShowSetUI(owner, partsInfo, row2); // セット選択UI表示

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    partsInfo.RemoveSelectionInfo(selInfo.ListChildGoods, selInfo2.Key);
                    partsInfo.AcceptChanges();
                    isCancel = true;
                    retDialog = BLSearch7WinCtrlProc_AfterJoinSel(owner, carInfo, partsInfo, row, selInfo);
                    break;
                }
                partsInfo.UsrGoodsInfo.RowToProcess = row; //ADD 凌小青 on 2012/06/26 for Redmine#30595
                retDialog = ShowPriceUI(owner, carInfo, partsInfo, row2); // 標準価格選択UI表示

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    partsInfo.RemoveSelectionInfo(selInfo.ListChildGoods, selInfo2.Key);
                    partsInfo.AcceptChanges();
                    isCancel = true;
                    retDialog = BLSearch7WinCtrlProc_AfterJoinSel(owner, carInfo, partsInfo, row, selInfo);
                    break;
                }
            }

            // キャンセルを押した履歴があり、且つ選択情報が何もない
            if (isCancel && selInfo.ListChildGoods.Keys.Count == 0)
            {
                retDialog = DialogResult.Cancel;
            }

            return retDialog;
        }
        // 2009/12/16 Add <<<

        /// <summary>
        /// 品番検索時の画面制御(PM7式制御)
        /// </summary>
        /// <param name="partsInfo">部品情報</param>
        /// <param name="flg">検索フラグ(完全一致検索・あいまい検索など)</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 李占川 2009/10/20</br>
        /// <br>            : 標準価格の選択を可能にする。</br>
        /// </remarks>
        private static DialogResult PartsNoSearch7(IWin32Window owner, PartsInfoDataSet partsInfo, SearchFlag flg)
        {
            PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet;
            List<PartsInfoDataSet.UsrGoodsInfoRow> lstSelected = new List<PartsInfoDataSet.UsrGoodsInfoRow>();
            Process currentProcess = Process.GetCurrentProcess();
            DialogResult retDialog = DialogResult.OK;

            retDialog = ShowSamePartsNoUI(owner, partsInfo, flg);
            currentProcess.Refresh();

            if (retDialog == DialogResult.Cancel)
                return retDialog;

            //PartsInfoDataSet.UsrGoodsInfoRow[] rows = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
            //partsInfo.UsrGoodsInfo.ResetSelectionState();
            //for (int i = 0; i < rows.Length; i++)
            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = selInfo.RowGoods;
                string query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, row.GoodsMakerCd,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, row.GoodsNo);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(query);

                if (rowGoodsJoin.Length == 0) // 選択した部品の結合部品がない
                {
                    // 純正部品に設定されているセット情報があれば処理する
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, row.GoodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // 選択した部品のセット部品がない
                    {
                        if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                            selInfo.Selected = true;
                    }
                    else
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // セット選択UI表示

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        //PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                        //lstSelected.AddRange(rowsSet);
                    }

                    //------------ADD 2009/10/20--------->>>>>
                    retDialog = ShowPriceUI2(owner, partsInfo.SearchCarInfo, partsInfo); // 標準価格選択UI表示

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //------------ADD 2009/10/20---------<<<<<
                    continue;
                }
                partsInfo.JoinSrcSelInf = selInfo;
                retDialog = ShowJoinUI(owner, partsInfo, row); // 結合選択UI表示

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    return retDialog;
                }

                if (selInfo.JoinSet)
                {
                    // 純正部品に設定されているセット情報があれば処理する
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, row.GoodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length != 0) // 選択した純正部品のセット部品がある                
                    {
                        partsInfo.SetSrcSelInf = selInfo;
                        retDialog = ShowSetUI(owner, partsInfo, row); // セット選択UI表示

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                    }
                }

                //PartsInfoDataSet.UsrGoodsInfoRow[] rowsJoin = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                //partsInfo.UsrGoodsInfo.ResetSelectionState();
                //for (int j = 0; j < rowsJoin.Length; j++)
                foreach (SelectionInfo selInfo2 in selInfo.ListChildGoods.Values)
                {
                    PartsInfoDataSet.UsrGoodsInfoRow row2 = selInfo2.RowGoods;
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, row2.GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, row2.GoodsNo);
                    rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // 選択した部品のセット部品がない
                    {
                        if (selInfo2.IsThereSelection == false)
                            selInfo2.Selected = true;

                        //------------ADD 2009/11/17--------->>>>>
                        retDialog = ShowPriceUI(owner, partsInfo.SearchCarInfo, partsInfo, row2); // 標準価格選択UI表示

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        //------------ADD 2009/11/17---------<<<<<

                        continue;
                    }
                    partsInfo.SetSrcSelInf = selInfo2;
                    retDialog = ShowSetUI(owner, partsInfo, row2); // セット選択UI表示

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                    //lstSelected.AddRange(rowsSet);

                    //------------ADD 2009/10/20--------->>>>>
                    partsInfo.UsrGoodsInfo.RowToProcess = row; //ADD 凌小青 on 2012/06/26 for Redmine#30595
                    retDialog = ShowPriceUI(owner, partsInfo.SearchCarInfo, partsInfo, row2); // 標準価格選択UI表示

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    //------------ADD 2009/10/20---------<<<<<
                }

                if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                    selInfo.Selected = true;

            }

            //for (int i = 0; i < lstSelected.Count; i++)
            //{
            //    lstSelected[i].SelectionState = true;
            //}
            partsInfo.UsrGoodsInfo.AcceptChanges();

            return retDialog;
        }
#if old
        private static DialogResult PartsNoSearch7(PartsInfoDataSet partsInfo, SearchFlag flg)
        {
            List<PartsInfoDataSet.UsrGoodsInfoRow> lstSelected = new List<PartsInfoDataSet.UsrGoodsInfoRow>();
            Process currentProcess = Process.GetCurrentProcess();
            DialogResult retDialog = DialogResult.OK;

            retDialog = ShowSamePartsNoUI(partsInfo, flg);
            currentProcess.Refresh();

            if (retDialog == DialogResult.Cancel)
                return retDialog;

            PartsInfoDataSet.UsrGoodsInfoRow[] rows = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
            partsInfo.UsrGoodsInfo.ResetSelectionState();
            for (int i = 0; i < rows.Length; i++)
            {
                string query = string.Format("{0}={1} AND {2}='{3}'",
                    partsInfo.UsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, rows[i].GoodsMakerCd,
                    partsInfo.UsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, rows[i].GoodsNo);
                PartsInfoDataSet.UsrJoinPartsRow[] rowGoodsJoin =
                    (PartsInfoDataSet.UsrJoinPartsRow[])partsInfo.UsrJoinParts.Select(query);

                if (rowGoodsJoin.Length == 0) // 選択した部品の結合部品がない
                {
                    // 純正部品に設定されているセット情報があれば処理する
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, rows[i].GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, rows[i].GoodsNo);
                    PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // 選択した部品のセット部品がない
                    {
                        lstSelected.Add(rows[i]);
                    }
                    else
                    {
                        retDialog = ShowSetUI(partsInfo, rows[i]); // セット選択UI表示

                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                            return retDialog;
                        }
                        PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                        lstSelected.AddRange(rowsSet);
                    }
                    continue;
                }

                retDialog = ShowJoinUI(partsInfo, rows[i]); // 結合選択UI表示

                if (retDialog == DialogResult.Cancel)
                {
                    partsInfo.RejectChanges();
                    return retDialog;
                }

                PartsInfoDataSet.UsrGoodsInfoRow[] rowsJoin = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                partsInfo.UsrGoodsInfo.ResetSelectionState();
                for (int j = 0; j < rowsJoin.Length; j++)
                {
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        partsInfo.UsrSetParts.ParentGoodsMakerCdColumn.ColumnName, rowsJoin[j].GoodsMakerCd,
                        partsInfo.UsrSetParts.ParentGoodsNoColumn.ColumnName, rowsJoin[j].GoodsNo);
                    PartsInfoDataSet.UsrSetPartsRow[] rowJoinSet =
                        (PartsInfoDataSet.UsrSetPartsRow[])partsInfo.UsrSetParts.Select(query);

                    if (rowJoinSet.Length == 0) // 選択した部品のセット部品がない
                    {
                        lstSelected.Add(rowsJoin[j]);
                        continue;
                    }

                    retDialog = ShowSetUI(partsInfo, rowsJoin[j]); // セット選択UI表示

                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        return retDialog;
                    }
                    PartsInfoDataSet.UsrGoodsInfoRow[] rowsSet = partsInfo.UsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
                    lstSelected.AddRange(rowsSet);
                }

            }

            for (int i = 0; i < lstSelected.Count; i++)
            {
                lstSelected[i].SelectionState = true;
            }
            partsInfo.UsrGoodsInfo.AcceptChanges();

            return retDialog;
        }
#endif
        #endregion

        #region [PM.NS式選択UI制御]
        /// <summary>
        /// 部品選択制御メソッド(PM.NS方式)
        /// </summary>
        /// <param name="carInfo">車型式情報データセット</param>
        /// <param name="partsInfo">部品情報データセット</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        /// <remarks>
        /// <br>note			:	</br>
        /// <br>Programer		:	30290</br>
        /// <br>Date			:	2008.10.06</br>
        /// </remarks>
        private static DialogResult DisplayControlNS(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            DialogResult ret = DialogResult.Cancel;
            SearchFlag flg = partsInfo.SearchCondition.SearchFlg;
            if ((int)flg < 2) // BL検索時
            {
                ret = BLSearch(owner, carInfo, partsInfo);
            }
            else // 品番検索時
            {
                ret = PartsNoSearch(owner, partsInfo, flg);
            }
            return ret;
        }

        /// <summary>
        /// BL検索時の画面制御
        /// </summary>
        /// <param name="carInfo">車両情報</param>
        /// <param name="partsInfo">部品情報</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 李占川 2009/10/20</br>
        /// <br>            : 標準価格の選択を可能にする。</br>
        /// <br>Update Note : 李占川 2009/11/13</br>
        /// <br>            : redmine#1268,表示パターンの修正</br>
        /// <br>Update Note : 李占川 2009/11/16</br>
        /// <br>            : redmine#1320,標準価格選択表示の修正</br>
        /// </remarks>
        private static DialogResult BLSearch(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            Process currentProcess = Process.GetCurrentProcess();

            int originalPartsFlg = 0; // 0:純正　1:オリジナル部品　2:TBO
            //SelectionFormSb frmSubstParts = null;
            SelectionParts frmClgParts = null;
            SelectionPrimeBLParts frmPrmBLParts = null;
            SelectionFormJ frmJoinParts = null;
            SelectionFormSet frmSetParts = null;
            //SearchFlag flg = partsInfo.SearchCondition.SearchFlg;

            // 2010/02/25 Add >>>
            if (partsInfo.Mode == 1)
            {
                // 2010/03/15 >>>
                //// SCM自動回答モード
                //if (partsInfo.PartsInfo.Count == 1)
                //{
                //    // 純正１品番
                //    int i = 0;
                //    foreach (PartsInfoDataSet.UsrGoodsInfoRow row in partsInfo.UsrGoodsInfo)
                //    {
                //        //row.SelectionState = true;

                //        SelectionInfo selInfo = new SelectionInfo();
                //        selInfo.Depth = 0;
                //        selInfo.Key = i;
                //        selInfo.RowGoods = row;
                //        selInfo.Selected = true;
                //        partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);

                //        if (( row.GoodsKindResolved != 2 ) && ( row.GoodsKindResolved != 4 ))
                //        {
                //            string filter = string.Format("{0}={1} AND {2}='{3}' ",
                //                partsInfo.Stock.GoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                //                partsInfo.Stock.GoodsNoColumn.ColumnName, row.GoodsNo);
                //            partsInfo.Stock.DefaultView.RowFilter = filter;
                //            if (partsInfo.ListPriorWarehouse != null)
                //            {
                //                for (int k = 0; k < partsInfo.ListPriorWarehouse.Count; k++)
                //                {
                //                    string warehouseCd = partsInfo.ListPriorWarehouse[k].Trim();
                //                    bool breakFlg = false;
                //                    for (int j = 0; j < partsInfo.Stock.DefaultView.Count; j++)
                //                    {
                //                        if (warehouseCd.Equals(partsInfo.Stock.DefaultView[j][partsInfo.Stock.WarehouseCodeColumn.ColumnName]))
                //                        {
                //                            selInfo.WarehouseCode = warehouseCd;
                //                            //return DialogResult.OK;
                //                            breakFlg = true;
                //                            break;
                //                        }
                //                    }
                //                    if (breakFlg) break;
                //                }
                //            }
                //        }

                //        i++;
                //    }

                //    return DialogResult.OK;
                //}
                //else
                //{
                //    // 純正複数品番
                //    return DialogResult.None;
                //}

                frmClgParts = new SelectionParts(carInfo, partsInfo, 2);

                DialogResult ret = frmClgParts.SelectParts();
                if (ret == DialogResult.OK)
                {
                    SelectionFormJ join = new SelectionFormJ(partsInfo, 1);
                    join.SelectAllJoinParts();
                }
                return ret;
                // 2010/03/15 <<<
            }

            // 2010/02/25 Add <<<

            if (partsInfo.OfrPrimeParts.Count > 0)
            {
                originalPartsFlg = 1;
                frmPrmBLParts = new SelectionPrimeBLParts(partsInfo);
            }
            else if (partsInfo.TBOInfo.Count > 0)
            {
                originalPartsFlg = 2;
            }
            else
            {
                frmClgParts = new SelectionParts(carInfo, partsInfo);
            }

            int cnt = partsInfo.UsrGoodsInfo.Count;

            partsInfo.PartsInfo.DefaultView.RowFilter = string.Empty;
            partsInfo.JoinParts.DefaultView.RowFilter = string.Empty;
            partsInfo.UsrGoodsInfo.DefaultView.RowFilter = string.Empty;

            DialogResult retDialog = DialogResult.OK;
            //if (cnt > 1)
            //{
            partsInfo.UsrGoodsInfo.RowToProcess = partsInfo.UsrGoodsInfo[0];
            if (originalPartsFlg == 1) // オリジナル部品処理
            {
                retDialog = frmPrmBLParts.ShowDialog(owner);//SelectionPrimeSearchParts.ShowDialog(partsInfo);
            }
            else if (originalPartsFlg == 2) // TBO
            {
                retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
            }
            else // 純正部品処理
            {
                retDialog = frmClgParts.ShowDialog(owner);
            }

            // --- DEL 2009/11/13 ---------->>>>> 
            //// --- ADD 2009/10/20 ---------->>>>> 
            //if (retDialog == DialogResult.OK)
            //{
            //    foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
            //    {
            //        if (selInfo.IsThereSelection == false) // 選択された部品がない場合
            //            selInfo.Selected = true;
            //    }

            //    retDialog = ShowPriceUI(owner, carInfo, partsInfo);
            //}
            //// --- ADD 2009/10/20 ----------<<<<<
            // --- DEL 2009/11/13 ----------<<<<<

            //}
            //else
            //{
            //    if (cnt == 1)
            //        partsInfo.UsrGoodsInfo[0].SelectionState = true;
            //    return retDialog;
            //}
            currentProcess.Refresh();
            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            if (originalPartsFlg == 0)
            {
                if (frmClgParts.IsDialogShown)
                    UiDisplayStack.Push(SelectUIKind.PartsSelection);
            }
            else
            {
                if (originalPartsFlg == 2 || frmPrmBLParts.IsDialogShown)
                    UiDisplayStack.Push(SelectUIKind.PartsSelection);
            }
            UiDisplayStack.Push(partsInfo.UIKind);

            if (retDialog != DialogResult.Retry) // 部品選択UIで選択確定であればそのまま終了
            {
                // --- ADD 2009/11/13 ---------->>>>> 
                foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                {
                    if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                        selInfo.Selected = true;
                }
                retDialog = ShowPriceUI2(owner, carInfo, partsInfo);
                // --- ADD 2009/11/13 ----------<<<<<
                return retDialog;
            }

            // 部品選択UI指定[内部処理用]
            SelectUIKind befkind = SelectUIKind.PartsSelection;　// ADD 2009/11/13

            do
            {
                switch (partsInfo.UIKind)
                {
                    case SelectUIKind.PartsSelection:
                        // --- ADD 2009/11/13 ---------->>>>>
                        // 結合選択UI指定場合
                        if (befkind == SelectUIKind.Join)
                        {
                            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                            {
                                if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                                    selInfo.Selected = true;
                            }
                            retDialog = ShowPriceUI2(owner, carInfo, partsInfo);
                        }
                        // --- ADD 2009/11/13 ----------<<<<<

                        if (originalPartsFlg == 1) // オリジナル部品処理
                        {
                            retDialog = frmPrmBLParts.ShowDialog(owner); //retDialog = SelectionPrimeSearchParts.ShowDialog(partsInfo);
                        }
                        else if (originalPartsFlg == 2) // TBO
                        {
                            retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
                        }
                        else
                        {
                            retDialog = frmClgParts.ShowDialog(owner);
                        }
                        break;
                    case SelectUIKind.Subst:
                        //if (frmSubstParts == null) frmSubstParts = new SelectionFormSb(partsInfo);
                        //retDialog = frmSubstParts.ShowDialog();
                        retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                        if (retDialog == DialogResult.OK)
                        {
                            if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                            {
                                partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                            }
                            //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                            //if (substRow != null)
                            //{
                            //    substRow.SelectionState = false; // ここの処理のみのためなので、念のためクリアする。
                            //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                            //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                            //    if (goodsInfoRow != null)
                            //    {
                            //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                            //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                            //    }
                            //}
                            //else
                            //{
                            //    if (partsInfo.UsrGoodsInfo.RowToProcess.SelectionState) // 代替として代替元品番が選択された場合
                            //    { // 提供純正のカタログ品番と最新品番が異なる場合、カタログ品番の部品を選ぶためにこの処理が必要
                            //        partsInfo.UsrGoodsInfo.RowToProcess.NewGoodsNo = partsInfo.UsrGoodsInfo.RowToProcess.GoodsNo;
                            //    } // 代替品番として自分自身の品番を設定しておき、カタログ品番が選択できるようにする。
                            //}
                        }
                        break;
                    case SelectUIKind.Join:
                        if (frmJoinParts == null) frmJoinParts = new SelectionFormJ(partsInfo);
                        retDialog = frmJoinParts.ShowDialog(owner);

                        // --- ADD 2009/11/16 ---------->>>>>
                        SelectUIKind dummykind = SelectUIKind.PartsSelection;
                        Stack<SelectUIKind> dummyUiDisplayStack = new Stack<SelectUIKind>();
                        dummyUiDisplayStack = UiDisplayStack;
                        dummykind = dummyUiDisplayStack.Pop();

                        // 結合選択で終了する場合(部品選択画面無しの場合)
                        if (dummyUiDisplayStack.Peek() == SelectUIKind.None)
                        {
                            if (retDialog == DialogResult.OK)
                            {
                                foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                                {
                                    if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                                        selInfo.Selected = true;
                                }
                                retDialog = ShowPriceUI2(owner, partsInfo.SearchCarInfo, partsInfo); 
                            }
                        }
                        dummyUiDisplayStack.Push(dummykind);
                        // --- ADD 2009/11/16 ----------<<<<<
                        break;
                    case SelectUIKind.Set:
                        if (frmSetParts == null) frmSetParts = new SelectionFormSet(partsInfo);
                        retDialog = frmSetParts.ShowDialog(owner);
                        break;
                }

                befkind = partsInfo.UIKind;　// ADD 2009/11/13

                currentProcess.Refresh();
                if (retDialog == DialogResult.Retry)
                {
                    oldUI = partsInfo.UIKind;
                    partsInfo.AcceptChanges();
                }
                //else if (retDialog == DialogResult.Abort) // ×ボタンによる完全終了(前の画面に戻らず、選択終了とする)
                //{
                //    retDialog = DialogResult.Cancel;
                //    break;
                //}
                else if (retDialog == DialogResult.Ignore) // 選択確定(前の画面に戻らず、選択終了とする)
                {
                    retDialog = DialogResult.OK;
                    break;
                }
                else
                {
                    if (UiDisplayStack.Count == 0)
                        break;
                    if (UiDisplayStack.Peek() == oldUI)
                        UiDisplayStack.Pop();
                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                        if (partsInfo.UsrGoodsInfo.RowToProcess != null)
                            partsInfo.UsrGoodsInfo.RowToProcess.NewGoodsNo = string.Empty; // 代替関連情報をクリアする。
                    }
                    else
                    {
                        partsInfo.AcceptChanges();
                    }
                    partsInfo.UIKind = UiDisplayStack.Pop();
                    oldUI = partsInfo.UIKind;
                    partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                }
                if (oldUI != SelectUIKind.None)
                    UiDisplayStack.Push(oldUI);
            } while (UiDisplayStack.Count > 0);

            return retDialog;
        }

        /// <summary>
        /// 品番検索時の画面制御
        /// </summary>
        /// <param name="partsInfo">部品情報</param>
        /// <param name="flg">検索フラグ(完全一致検索・あいまい検索など)</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note : 李占川 2009/10/20</br>
        /// <br>            : 標準価格の選択を可能にする。</br>
        /// <br>Update Note : 李占川 2009/11/13</br>
        /// <br>            : redmine#1268,表示パターンの修正</br>
        /// </remarks>
        private static DialogResult PartsNoSearch(IWin32Window owner, PartsInfoDataSet partsInfo, SearchFlag flg)
        {
            Process currentProcess = Process.GetCurrentProcess();
            SelectionSamePartsNoParts frmSamePartsNo = null;
            //SelectionFormSb frmSubstParts = null;
            SelectionFormJ frmJoinParts = null;
            SelectionFormSet frmSetParts = null;

            // 2010/02/25 Add >>>
            if (partsInfo.Mode == 1)
            {
                // SCM自動回答モード
                //if (partsInfo.PartsInfo.Count == 1)
                if (checkPureCode(partsInfo))
                {
                    // 純正１品番
                    int i = 0;
                    foreach (PartsInfoDataSet.UsrGoodsInfoRow row in partsInfo.UsrGoodsInfo)
                    {
                        //row.SelectionState = true;

                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Depth = 0;
                        selInfo.Key = i;
                        selInfo.RowGoods = row;
                        selInfo.Selected = true;
                        partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);

                        if ((row.GoodsKindResolved != 2) && (row.GoodsKindResolved != 4))
                        {
                            string filter = string.Format("{0}={1} AND {2}='{3}' ",
                                partsInfo.Stock.GoodsMakerCdColumn.ColumnName, row.GoodsMakerCd,
                                partsInfo.Stock.GoodsNoColumn.ColumnName, row.GoodsNo);
                            partsInfo.Stock.DefaultView.RowFilter = filter;
                            if (partsInfo.ListPriorWarehouse != null)
                            {
                                for (int k = 0; k < partsInfo.ListPriorWarehouse.Count; k++)
                                {
                                    string warehouseCd = partsInfo.ListPriorWarehouse[k].Trim();
                                    bool breakFlg = false;
                                    for (int j = 0; j < partsInfo.Stock.DefaultView.Count; j++)
                                    {
                                        if (warehouseCd.Equals(partsInfo.Stock.DefaultView[j][partsInfo.Stock.WarehouseCodeColumn.ColumnName]))
                                        {
                                            selInfo.WarehouseCode = warehouseCd;
                                            //return DialogResult.OK;
                                            breakFlg = true;
                                            break;
                                        }
                                    }
                                    if (breakFlg) break;
                                }
                            }
                        }

                        i++;
                    }

                    return DialogResult.OK;
                }
                else
                {
                    // 純正複数品番
                    return DialogResult.None;
                }
            }
            // 2010/02/25 Add <<<

            int cnt = partsInfo.UsrGoodsInfo.Count;

            partsInfo.PartsInfo.DefaultView.RowFilter = string.Empty;
            partsInfo.JoinParts.DefaultView.RowFilter = string.Empty;
            partsInfo.UsrGoodsInfo.DefaultView.RowFilter = string.Empty;

            DialogResult retDialog = DialogResult.OK;
            if (flg == SearchFlag.PartsNoJoinSearch)// || flg == SearchFlag.GoodsAndSetInfo)
            {
                frmSamePartsNo = new SelectionSamePartsNoParts(partsInfo, 1, null);
            }
            else
            {
                frmSamePartsNo = new SelectionSamePartsNoParts(partsInfo, 2, null);
            }
            retDialog = frmSamePartsNo.ShowDialog(owner);

            currentProcess.Refresh();

            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            if (frmSamePartsNo.IsDialogShown)
            {
                UiDisplayStack.Push(SelectUIKind.SamePartsNo);
            }
            UiDisplayStack.Push(partsInfo.UIKind);

            if (retDialog != DialogResult.Retry) // 同一品番選択UIで選択確定であればそのまま終了
            {
                foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                {
                    if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                        selInfo.Selected = true;
                }

                retDialog = ShowPriceUI2(owner, partsInfo.SearchCarInfo, partsInfo);
                return retDialog;
            }

            SelectUIKind befkind = partsInfo.UIKind;  // ADD 2009/11/13

            do
            {
                switch (partsInfo.UIKind)
                {
                    case SelectUIKind.SamePartsNo:
                        retDialog = frmSamePartsNo.ShowDialog(owner, retDialog);
                        if (retDialog == DialogResult.OK)
                        {
                            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                            {
                                if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                                    selInfo.Selected = true;
                            }
                        }
                        break;
                    case SelectUIKind.Subst:
                        //if (frmSubstParts == null) frmSubstParts = new SelectionFormSb(partsInfo);
                        //retDialog = frmSubstParts.ShowDialog();
                        retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                        if (retDialog == DialogResult.OK)
                        {
                            if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                            {
                                partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                            }
                            //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                            //if (substRow != null)
                            //{
                            //    substRow.SelectionState = false; // ここの処理のみのためなので、念のためクリアする。
                            //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                            //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                            //    if (goodsInfoRow != null)
                            //    {
                            //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                            //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                            //    }
                            //}
                        }
                        break;
                    case SelectUIKind.Join:
                        if (frmJoinParts == null) frmJoinParts = new SelectionFormJ(partsInfo);
                        retDialog = frmJoinParts.ShowDialog(owner);
                        if (frmJoinParts.IsDialogShown == false)
                        {
                            UiDisplayStack.Pop();
                        }

                        // --- ADD 2009/10/20 ---------->>>>> 
                        if (retDialog == DialogResult.OK)
                        {
                            foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                            {
                                if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                                    selInfo.Selected = true;
                            }
                            retDialog = ShowPriceUI2(owner, partsInfo.SearchCarInfo, partsInfo);
                        }
                        // --- ADD 2009/10/20 ----------<<<<<

                        break;
                    case SelectUIKind.Set:
                        if (frmSetParts == null) frmSetParts = new SelectionFormSet(partsInfo);
                        retDialog = frmSetParts.ShowDialog(owner);

                        // --- ADD 2009/11/13 ---------->>>>> 
                        Stack<SelectUIKind> dummyUiDisplayStack = new Stack<SelectUIKind>();
                        dummyUiDisplayStack = UiDisplayStack;
                        befkind = dummyUiDisplayStack.Pop();
                        if (befkind == SelectUIKind.Set)
                        {
                            if (dummyUiDisplayStack.Peek() != SelectUIKind.Join)
                            {
                                if (retDialog == DialogResult.OK)
                                {
                                    foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                                    {
                                        if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                                            selInfo.Selected = true;
                                    }
                                    retDialog = ShowPriceUI2(owner, partsInfo.SearchCarInfo, partsInfo);
                                }
                            }
                        }
                        dummyUiDisplayStack.Push(befkind);
                        // --- ADD 2009/11/13 ----------<<<<<

                        // --- DEL 2009/11/13 ---------->>>>> 
                        //// --- ADD 2009/10/20 ---------->>>>> 
                        //if (retDialog == DialogResult.OK)
                        //{
                        //    foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                        //    {
                        //        if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                        //            selInfo.Selected = true;
                        //    }

                        //    retDialog = ShowPriceUI(owner, partsInfo.SearchCarInfo, partsInfo);
                        //}
                        //// --- ADD 2009/10/20 ----------<<<<<
                        // --- DEL 2009/11/13 ----------<<<<<

                        break;
                }
                currentProcess.Refresh();
                if (retDialog == DialogResult.Retry)
                {
                    oldUI = partsInfo.UIKind;
                    partsInfo.AcceptChanges();
                }
                //else if (retDialog == DialogResult.Abort) // ×ボタンによる完全終了(前の画面に戻らず、選択終了とする)
                //{
                //    retDialog = DialogResult.Cancel;
                //    break;
                //}
                else if (retDialog == DialogResult.Ignore) // 選択確定(前の画面に戻らず、選択終了とする)
                {
                    retDialog = DialogResult.OK;
                    break;
                }
                else
                {
                    if (UiDisplayStack.Count == 0)
                        break;
                    if (UiDisplayStack.Peek() == oldUI)
                        UiDisplayStack.Pop();
                    partsInfo.UIKind = UiDisplayStack.Pop();
                    oldUI = partsInfo.UIKind;
                    partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                    }
                    else
                    {
                        partsInfo.AcceptChanges();
                    }
                }
                if (oldUI != SelectUIKind.None)
                    UiDisplayStack.Push(oldUI);
            } while (UiDisplayStack.Count > 0);

            return retDialog;

        }

        // 2010/02/25 Add >>>
        /// <summary>
        /// 純正１品番チェック
        /// </summary>
        /// <param name="partsInfo"></param>
        private static bool checkPureCode(PartsInfoDataSet partsInfo)
        {
            int count = 0;
            bool ret = false;
            foreach (PartsInfoDataSet.UsrGoodsInfoRow row in partsInfo.UsrGoodsInfo)
            {
                int goodsKind = row.GoodsKind % 2;
                int offerKubun = row.OfferKubun;
                if (( goodsKind == 1 ) && ( ( offerKubun == 1 ) || ( offerKubun == 3 ) ))
                {
                    count++;
                }
            }
            //>>>2011/09/04
            //if (count == 1) ret = true;
            if (partsInfo.AcceptOrOrderKind == 0)
            {
                if (count == 1) ret = true;
            }
            else
            {
                if (count >= 1) ret = true;
            }
            //<<<2011/09/04

            return ret;
        }

        // 2010/02/25 Add <<<
        #endregion

        #region [ 検索見積用部品選択制御モジュール ]
        /// <summary>
        /// 検索見積用部品選択制御メソッド(BLコードの場合)
        /// </summary>
        /// <param name="carInfo">車型式情報データセット</param>
        /// <param name="partsInfo">部品情報データセット</param>
        /// <param name="flg">選択UI表示フラグ　0:表示　1:非表示</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        public static DialogResult SearchEstimateBL(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo, int flg)
        {
            int originalPartsFlg = 0; // 0:純正　1:オリジナル部品　2:TBO
            //SelectionFormSb frmSubstParts = null;
            SelectionParts frmClgParts = null;
            SelectionPrimeBLParts frmPrmBLParts = null;

            if (partsInfo.OfrPrimeParts.Count > 0)
            {
                originalPartsFlg = 1;
                frmPrmBLParts = new SelectionPrimeBLParts(partsInfo, 1); // 検索見積専用の部品選択UI(セット情報表示なし)
            }
            else if (partsInfo.TBOInfo.Count > 0)
            {
                originalPartsFlg = 2;
            }
            else
            {
                frmClgParts = new SelectionParts(carInfo, partsInfo, 1); // 検索見積専用の部品選択UI(結合情報表示なし)
            }

            // --- UPD m.suzuki 2010/07/13 ---------->>>>>
            //string filter = string.Format("{0}=1 OR {1}=3 OR {2}=7", partsInfo.UsrGoodsInfo.OfferKubunColumn.ColumnName, partsInfo.UsrGoodsInfo.OfferKubunColumn.ColumnName, partsInfo.UsrGoodsInfo.OfferKubunColumn.ColumnName);
            //PartsInfoDataSet.UsrGoodsInfoRow[] rowGoodsInfo = (PartsInfoDataSet.UsrGoodsInfoRow[])partsInfo.UsrGoodsInfo.Select(filter);
            //int cnt = rowGoodsInfo.Length;
            int cnt = partsInfo.PartsInfo.DefaultView.Count;
            // --- UPD m.suzuki 2010/07/13 ----------<<<<<

            partsInfo.PartsInfo.DefaultView.RowFilter = string.Empty;
            partsInfo.JoinParts.DefaultView.RowFilter = string.Empty;
            partsInfo.UsrGoodsInfo.DefaultView.RowFilter = string.Empty;

            DialogResult retDialog = DialogResult.OK;
            if ((flg == 0 && (cnt > 1 || partsInfo.SubstPartsInfo.Count > 0)) || originalPartsFlg == 2) // TBOの場合は表示フラグが非表示でも表示する
            {
                partsInfo.UsrGoodsInfo.RowToProcess = partsInfo.UsrGoodsInfo[0];
                if (originalPartsFlg == 1) // オリジナル部品処理
                {
                    retDialog = frmPrmBLParts.ShowDialog(owner);//SelectionPrimeSearchParts.ShowDialog(partsInfo);
                }
                else if (originalPartsFlg == 2) // TBO
                {
                    retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
                }
                else // 純正部品処理
                {
                    retDialog = frmClgParts.ShowDialog(owner);
                }
            }
            else
            {
                if (originalPartsFlg == 0) // 純正部品の場合
                {
                    cnt = frmClgParts.PartsInfo.Count;
                    for (int i = 0; i < cnt; i++)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowUGInfo;
                        if (frmClgParts.PartsInfo[i].UsrSubst)
                            rowUGInfo = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(frmClgParts.PartsInfo[i].CatalogPartsMakerCd, frmClgParts.PartsInfo[i].PartsNo);
                        else
                            rowUGInfo = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(frmClgParts.PartsInfo[i].CatalogPartsMakerCd, frmClgParts.PartsInfo[i].JoinSrcPartsNo);

                        SelectionInfo selInfo = new SelectionInfo();
                        selInfo.Key = i;
                        selInfo.Selected = true;
                        selInfo.RowGoods = rowUGInfo;
                        partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);
                    }
                }
                else
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowUGInfo = partsInfo.UsrGoodsInfo[i];
                        if ((rowUGInfo.OfferKubun == 1 || rowUGInfo.OfferKubun == 3 || rowUGInfo.OfferKubun == 7) // 提供の純正又は・オリジナル部品か
                            && (rowUGInfo.GoodsKind & (int)GoodsKind.Parent) == (int)GoodsKind.Parent) // 提供の代替は除く
                        {
                            SelectionInfo selInfo = new SelectionInfo();
                            selInfo.Key = i;
                            selInfo.Selected = true;
                            selInfo.RowGoods = rowUGInfo;
                            partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);
                        }
                    }
                }

                return retDialog;
            }
            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            //UiDisplayStack.Push(SelectUIKind.PartsSelection);
            if (originalPartsFlg != 0 || frmClgParts.IsDialogShown)
            {
                UiDisplayStack.Push(SelectUIKind.PartsSelection);
            }

            UiDisplayStack.Push(partsInfo.UIKind);

            if (retDialog != DialogResult.Retry)
            {
                return retDialog;
            }
            else if (partsInfo.UIKind != SelectUIKind.PartsSelection && partsInfo.UIKind != SelectUIKind.Subst)
            { // これは純正部品1個のみで結合部品がある場合。検索見積は結合選択UI表示しないため選択終了とする。
                if (partsInfo.ListSelectionInfo.Count > 0)
                    partsInfo.ListSelectionInfo[0].Selected = true;
                return DialogResult.OK;
            }

            do
            {
                switch (partsInfo.UIKind)
                {
                    case SelectUIKind.PartsSelection:
                        if (originalPartsFlg == 1) // オリジナル部品処理
                        {
                            retDialog = frmPrmBLParts.ShowDialog(owner); //SelectionPrimeSearchParts.ShowDialog(partsInfo);
                        }
                        else if (originalPartsFlg == 2) // TBO
                        {
                            retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
                        }
                        else
                        {
                            // 2009/12/18 >>>
                            //retDialog = frmClgParts.ShowDialog();
                            retDialog = frmClgParts.ShowDialog(owner);
                            // 2009/12/18 <<<
                        }
                        break;
                    case SelectUIKind.Subst:
                        //if (frmSubstParts == null) frmSubstParts = new SelectionFormSb(partsInfo);
                        //retDialog = frmSubstParts.ShowDialog();
                        retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                        if (retDialog == DialogResult.OK)
                        {
                            if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                            {
                                partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                            }
                            //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.CurrentRows);
                            //if (substRow != null)
                            //{
                            //    substRow.SelectionState = false; // ここの処理のみのためなので、念のためクリアする。
                            //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                            //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                            //    if (goodsInfoRow != null)
                            //    {
                            //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                            //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                            //    }
                            //}
                            //else
                            //{
                            //    if (partsInfo.UsrGoodsInfo.RowToProcess.SelectionState) // 代替として代替元品番が選択された場合
                            //    { // 提供純正のカタログ品番と最新品番が異なる場合、カタログ品番の部品を選ぶためにこの処理が必要
                            //        partsInfo.UsrGoodsInfo.RowToProcess.NewGoodsNo = partsInfo.UsrGoodsInfo.RowToProcess.GoodsNo;
                            //    } // 代替品番として自分自身の品番を設定しておき、カタログ品番が選択できるようにする。
                            //}
                        }
                        break;
                }
                if (retDialog == DialogResult.Retry)
                {
                    oldUI = partsInfo.UIKind;
                    //partsInfo.AcceptChanges();
                }
                //else if (retDialog == DialogResult.Abort)
                //{
                //    retDialog = DialogResult.Cancel;
                //    break;
                //}
                else
                {
                    if (UiDisplayStack.Count == 0)
                        break;
                    if (UiDisplayStack.Peek() == oldUI)
                        UiDisplayStack.Pop();
                    partsInfo.UIKind = UiDisplayStack.Pop();
                    oldUI = partsInfo.UIKind;
                    partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                    if (retDialog == DialogResult.Cancel)
                    {
                        partsInfo.RejectChanges();
                    }
                    else
                    {
                        partsInfo.AcceptChanges();
                    }
                }
                if (oldUI != SelectUIKind.None)
                    UiDisplayStack.Push(oldUI);
            } while (UiDisplayStack.Count > 0);

            return retDialog;
        }

        /// <summary>
        /// 検索見積用部品選択制御メソッド(品番の場合)
        /// </summary>
        /// <param name="partsInfo">部品情報データセット</param>
        /// <param name="flg">選択UI表示フラグ　0:表示　1:非表示</param>
        /// <returns>ダイアログボックスの戻り値</returns>
        public static DialogResult SearchEstimatePNo(IWin32Window owner, PartsInfoDataSet partsInfo, int flg)
        {
            SelectionSamePartsNoParts frmSamePartsNo = null;
            string filter = string.Format("{0} = {1}", partsInfo.UsrGoodsInfo.GoodsKindColumn.ColumnName, (int)GoodsKind.Parent);
            PartsInfoDataSet.UsrGoodsInfoRow[] rowsGoodsInfo = (PartsInfoDataSet.UsrGoodsInfoRow[])partsInfo.UsrGoodsInfo.Select(filter);
            int cnt = rowsGoodsInfo.Length;

            partsInfo.PartsInfo.DefaultView.RowFilter = string.Empty;
            partsInfo.JoinParts.DefaultView.RowFilter = string.Empty;
            partsInfo.UsrGoodsInfo.DefaultView.RowFilter = string.Empty;

            DialogResult retDialog = DialogResult.OK;
            if (cnt > 1 && flg == 0)
            {
                frmSamePartsNo = new SelectionSamePartsNoParts(partsInfo, 2, null);
                retDialog = frmSamePartsNo.ShowDialog(owner);
                if (retDialog == DialogResult.OK)
                {
                    foreach (SelectionInfo selInfo in partsInfo.ListSelectionInfo.Values)
                    {
                        if (selInfo.IsThereSelection == false) // 選択された部品がない場合
                            selInfo.Selected = true;
                    }
                }
            }
            else
            {
                if (cnt == 1)
                {
                    SelectionInfo selInfo = new SelectionInfo();
                    selInfo.Key = 0;
                    selInfo.Selected = true;
                    // 2009/12/01 >>>
                    //selInfo.RowGoods = partsInfo.UsrGoodsInfo[0];
                    selInfo.RowGoods = rowsGoodsInfo[0];
                    // 2009/12/01 <<<
                    partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);
                    //partsInfo.UsrGoodsInfo[0].SelectionState = true;
                }
                else if (flg == 1)
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        PartsInfoDataSet.UsrGoodsInfoRow rowUGInfo = rowsGoodsInfo[i];
                        if (rowUGInfo.GoodsKind == (int)GoodsKind.Parent) // 提供・ユーザー登録の部品
                        {
                            SelectionInfo selInfo = new SelectionInfo();
                            selInfo.Key = i;
                            selInfo.Selected = true;
                            selInfo.RowGoods = rowUGInfo;
                            partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);
                            //PartsInfoDataSet.PartsInfoRow rowGPInfo =
                            //    partsInfo.PartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(rowUGInfo.GoodsMakerCd, rowUGInfo.GoodsNo);
                            //if (rowGPInfo != null && rowGPInfo.ClgPrtsNoWithHyphen != rowGPInfo.NewPrtsNoWithHyphen) //最新品番とカタログ品番が違う場合
                            //{
                            //    PartsInfoDataSet.UsrGoodsInfoRow rowNewGoods =
                            //        partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(rowGPInfo.CatalogPartsMakerCd, rowGPInfo.NewPrtsNoWithHyphen);
                            //    if (rowNewGoods != null)
                            //    {
                            //        rowNewGoods.SelectionState = true;
                            //    }
                            //    else // あってはいけないケース。データの不整合などによる不具合防止のため。
                            //    {
                            //        rowUGInfo.SelectionState = true;
                            //    }
                            //}
                            //else
                            //{
                            //    rowUGInfo.SelectionState = true;
                            //}
                        }
                    }
                }

            }
            return retDialog;
        }

        /// <summary>
        /// 検索見積用セット選択UI制御メソッド
        /// </summary>
        /// <param name="partsInfo"></param>
        /// <param name="setParentMakerCd"></param>
        /// <param name="setParentGoodsNo"></param>
        /// <returns></returns>
        public static DialogResult SESetUI(IWin32Window owner, PartsInfoDataSet partsInfo, int setParentMakerCd, string setParentGoodsNo)
        {
            PartsInfoDataSet.UsrGoodsInfoRow rowToProcess =
                partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(setParentMakerCd, setParentGoodsNo);
            SelectionInfo selInfo = new SelectionInfo();
            selInfo.Key = 0;
            selInfo.RowGoods = rowToProcess;
            partsInfo.SetSrcSelInf = selInfo;
            partsInfo.AddSelectionInfo(partsInfo.ListSelectionInfo, selInfo.Key, ref selInfo);
            return ShowSetUI(owner, partsInfo, rowToProcess);
        }
        #endregion

        #region [ 選択UI表示メソッド(代替選択UI表示機能付き) ]
        /// <summary>
        /// 純正部品選択UI制御メソッド
        /// </summary>
        /// <param name="carInfo"></param>
        /// <param name="partsInfo"></param>        
        /// <returns></returns>
        private static DialogResult ShowPartsUI(IWin32Window owner,PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            int originalPartsFlg = 0; // 0:純正　1:オリジナル部品　2:TBO
            SelectionParts frmClgParts = null;
            SelectionPrimeBLParts frmPrmBLParts = null;
            DialogResult retDialog = DialogResult.OK;
            //partsInfo.UsrGoodsInfo.ResetSelectionState();

            if (partsInfo.OfrPrimeParts.Count > 0)
            {
                originalPartsFlg = 1;
                frmPrmBLParts = new SelectionPrimeBLParts(partsInfo);
            }
            else if (partsInfo.TBOInfo.Count > 0)
            {
                originalPartsFlg = 2;
            }
            else
            {
                //if (partsInfo.PartsInfo.Count == 1 && partsInfo.SubstPartsInfo.Count == 0 && partsInfo.DSubstPartsInfo.Count == 0)
                //{
                //    frmClgParts = null;
                //    partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                //        partsInfo.PartsInfo[0].CatalogPartsMakerCd, partsInfo.PartsInfo[0].ClgPrtsNoWithHyphen).SelectionState = true;
                //    partsInfo.UsrGoodsInfo.AcceptChanges();
                //}
                //else
                //{
                frmClgParts = new SelectionParts(carInfo, partsInfo);
                //}
            }
            partsInfo.UsrGoodsInfo.RowToProcess = partsInfo.UsrGoodsInfo[0];
            if (originalPartsFlg == 1) // オリジナル部品処理
            {
                retDialog = frmPrmBLParts.ShowDialog(owner);//SelectionPrimeSearchParts.ShowDialog(partsInfo);
            }
            else if (originalPartsFlg == 2) // TBO
            {
                retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
            }
            else // 純正部品処理
            {
                if (frmClgParts != null) // 純正部品が複数又は純正部品1個と代替品がある場合
                {
                    retDialog = frmClgParts.ShowDialog(owner); // 純正部品選択UIを表示する。
                }
            }

            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            UiDisplayStack.Push(SelectUIKind.PartsSelection);
            UiDisplayStack.Push(partsInfo.UIKind);
            if (retDialog == DialogResult.Retry)
            {
                do
                {
                    switch (partsInfo.UIKind)
                    {
                        case SelectUIKind.Subst:
                            retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                            if (retDialog == DialogResult.OK)
                            {
                                if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                                {
                                    partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                                }
                                //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                                //if (substRow != null)
                                //{
                                //    substRow.SelectionState = false; // ここの処理のみのためなので、念のためクリアする。
                                //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                                //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                                //    if (goodsInfoRow != null)
                                //    {
                                //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                                //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                                //    }
                                //}
                                //else
                                //{
                                //    if (partsInfo.UsrGoodsInfo.RowToProcess.SelectionState) // 代替として代替元品番が選択された場合
                                //    { // 提供純正のカタログ品番と最新品番が異なる場合、カタログ品番の部品を選ぶためにこの処理が必要
                                //        partsInfo.UsrGoodsInfo.RowToProcess.NewGoodsNo = partsInfo.UsrGoodsInfo.RowToProcess.GoodsNo;
                                //    } // 代替品番として自分自身の品番を設定しておき、カタログ品番が選択できるようにする。
                                //}
                            }
                            break;
                        case SelectUIKind.PartsSelection:
                            if (originalPartsFlg == 1) // オリジナル部品処理
                            {
                                retDialog = frmPrmBLParts.ShowDialog(owner);//SelectionPrimeSearchParts.ShowDialog(partsInfo);
                            }
                            else if (originalPartsFlg == 2) // TBO
                            {
                                retDialog = SelectionCarInfoJoinParts.ShowDialog(owner, carInfo, partsInfo);
                            }
                            else
                            {
                                retDialog = frmClgParts.ShowDialog(owner);
                            }
                            break;
                    }
                    if (retDialog == DialogResult.Retry)
                    {
                        oldUI = partsInfo.UIKind;
                        //partsInfo.AcceptChanges();
                    }
                    //else if (retDialog == DialogResult.Abort)
                    //{
                    //    retDialog = DialogResult.Cancel;
                    //    break;
                    //}
                    else
                    {
                        if (UiDisplayStack.Count == 0)
                            break;
                        if (UiDisplayStack.Peek() == oldUI)
                            UiDisplayStack.Pop();
                        partsInfo.UIKind = UiDisplayStack.Pop();
                        oldUI = partsInfo.UIKind;
                        partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                        }
                        else
                        {
                            partsInfo.AcceptChanges();
                        }
                    }
                    if (oldUI != SelectUIKind.None)
                        UiDisplayStack.Push(oldUI);
                } while (UiDisplayStack.Count > 0);
            }

            //>>>2010/07/01
            if (frmPrmBLParts != null) frmPrmBLParts.Dispose();
            if (frmClgParts != null) frmClgParts.Dispose();
            //<<<2010/07/01

            return retDialog;
        }

        /// <summary>
        /// 同一品番選択UI制御メソッド
        /// </summary>
        /// <param name="partsInfo"></param>    
        /// <param name="flg"></param>
        /// <returns></returns>
        private static DialogResult ShowSamePartsNoUI(IWin32Window owner,PartsInfoDataSet partsInfo, SearchFlag flg)
        {
            DialogResult retDialog = DialogResult.OK;
            //partsInfo.UsrGoodsInfo.ResetSelectionState();
            SelectionSamePartsNoParts frmSamePartsNo = null;

            if (flg == SearchFlag.PartsNoJoinSearch)
            {
                frmSamePartsNo = new SelectionSamePartsNoParts(partsInfo, 1, null);
            }
            else
            {
                frmSamePartsNo = new SelectionSamePartsNoParts(partsInfo, 2, null);
            }
            retDialog = frmSamePartsNo.ShowDialog(owner);

            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            UiDisplayStack.Push(SelectUIKind.SamePartsNo);
            UiDisplayStack.Push(partsInfo.UIKind);

            if (retDialog == DialogResult.Retry)
            {
                do
                {
                    switch (partsInfo.UIKind)
                    {
                        case SelectUIKind.Subst:
                            retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                            if (retDialog == DialogResult.OK)
                            {
                                if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                                {
                                    partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                                }
                                //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                                //if (substRow != null)
                                //{
                                //    substRow.SelectionState = false; // ここの処理のみのためなので、念のためクリアする。
                                //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                                //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                                //    if (goodsInfoRow != null)
                                //    {
                                //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                                //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                                //    }
                                //}
                            }
                            break;
                        case SelectUIKind.SamePartsNo:
                            retDialog = frmSamePartsNo.ShowDialog(owner, retDialog);
                            break;
                    }
                    if (retDialog == DialogResult.Retry)
                    {
                        oldUI = partsInfo.UIKind;
                        //partsInfo.AcceptChanges();
                    }
                    //else if (retDialog == DialogResult.Abort)
                    //{
                    //    retDialog = DialogResult.Cancel;
                    //    break;
                    //}
                    else
                    {
                        if (UiDisplayStack.Count == 0)
                            break;
                        if (UiDisplayStack.Peek() == oldUI)
                            UiDisplayStack.Pop();
                        partsInfo.UIKind = UiDisplayStack.Pop();
                        oldUI = partsInfo.UIKind;
                        partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                        }
                        else
                        {
                            partsInfo.AcceptChanges();
                        }
                    }
                    if (oldUI != SelectUIKind.None)
                        UiDisplayStack.Push(oldUI);
                } while (UiDisplayStack.Count > 0);
            }

            if (frmSamePartsNo != null) frmSamePartsNo.Dispose(); // 2010/07/01

            return retDialog;
        }

        /// <summary>
        /// 結合選択UI制御メソッド
        /// </summary>
        /// <param name="partsInfo"></param>
        /// <param name="rowToProcess"></param>
        /// <returns></returns>
        private static DialogResult ShowJoinUI(IWin32Window owner, PartsInfoDataSet partsInfo, PartsInfoDataSet.UsrGoodsInfoRow rowToProcess)
        {
            //partsInfo.UsrGoodsInfo.ResetSelectionState();
            partsInfo.UsrGoodsInfo.RowToProcess = rowToProcess;
            SelectionFormJ frmJoinParts = new SelectionFormJ(partsInfo);
            DialogResult retDialog = frmJoinParts.ShowDialog(owner);

            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            UiDisplayStack.Push(SelectUIKind.Join);
            UiDisplayStack.Push(partsInfo.UIKind);
            if (retDialog == DialogResult.Retry)
            {
                do
                {
                    switch (partsInfo.UIKind)
                    {
                        case SelectUIKind.Subst:
                            retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                            if (retDialog == DialogResult.OK)
                            {
                                if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                                {
                                    partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                                }
                                //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                                //if (substRow != null)
                                //{
                                //    substRow.SelectionState = false; // ここの処理のみのためなので、念のためクリアする。
                                //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                                //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                                //    if (goodsInfoRow != null)
                                //    {
                                //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                                //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                                //    }
                                //}
                            }
                            break;
                        case SelectUIKind.Join:
                            if (frmJoinParts == null) frmJoinParts = new SelectionFormJ(partsInfo);
                            retDialog = frmJoinParts.ShowDialog(owner);
                            break;
                    }
                    if (retDialog == DialogResult.Retry)
                    {
                        oldUI = partsInfo.UIKind;
                        //partsInfo.AcceptChanges();
                    }
                    //else if (retDialog == DialogResult.Abort)
                    //{
                    //    retDialog = DialogResult.Cancel;
                    //    break;
                    //}
                    else
                    {
                        if (UiDisplayStack.Count == 0)
                            break;
                        if (UiDisplayStack.Peek() == oldUI)
                            UiDisplayStack.Pop();
                        partsInfo.UIKind = UiDisplayStack.Pop();
                        oldUI = partsInfo.UIKind;
                        partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                        }
                        else
                        {
                            partsInfo.AcceptChanges();
                        }
                    }
                    if (oldUI != SelectUIKind.None)
                        UiDisplayStack.Push(oldUI);
                } while (UiDisplayStack.Count > 0);
            }

            if (frmJoinParts != null) frmJoinParts.Dispose(); // 2010/07/01

            return retDialog;
        }

        /// <summary>
        /// セット選択UI制御メソッド
        /// </summary>
        /// <param name="partsInfo"></param>
        /// <param name="rowToProcess"></param>
        /// <returns></returns>
        private static DialogResult ShowSetUI(IWin32Window owner, PartsInfoDataSet partsInfo, PartsInfoDataSet.UsrGoodsInfoRow rowToProcess)
        {
            //partsInfo.UsrGoodsInfo.ResetSelectionState();
            partsInfo.UsrGoodsInfo.RowToProcess = rowToProcess;
            SelectionFormSet frmSetParts = new SelectionFormSet(partsInfo);
            DialogResult retDialog = frmSetParts.ShowDialog(owner);

            Stack<SelectUIKind> UiDisplayStack = new Stack<SelectUIKind>();
            SelectUIKind oldUI = partsInfo.UIKind;
            UiDisplayStack.Push(SelectUIKind.None);
            UiDisplayStack.Push(SelectUIKind.Set);
            UiDisplayStack.Push(partsInfo.UIKind);
            if (retDialog == DialogResult.Retry)
            {
                do
                {
                    switch (partsInfo.UIKind)
                    {
                        case SelectUIKind.Subst:
                            retDialog = SelectionSubstParts.ShowDialog(owner, partsInfo);
                            if (retDialog == DialogResult.OK)
                            {
                                if (partsInfo.SubstSrcSelInf != null && partsInfo.SubstSrcSelInf.ListPlrlSubst.Count > 0)
                                {
                                    partsInfo.SubstSrcSelInf.RowGoods.NewGoodsNo = partsInfo.SubstSrcSelInf.ListPlrlSubst[0].RowGoods.GoodsNo;
                                }
                                //PartsInfoDataSet.UsrSubstPartsRow substRow = partsInfo.UsrSubstParts.GetSelectedRow(DataViewRowState.ModifiedCurrent);
                                //if (substRow != null)
                                //{
                                //    substRow.SelectionState = false; // ここの処理のみのためなので、念のためクリアする。
                                //    PartsInfoDataSet.UsrGoodsInfoRow goodsInfoRow
                                //        = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRow.ChgSrcMakerCd, substRow.ChgSrcGoodsNo);
                                //    if (goodsInfoRow != null)
                                //    {
                                //        goodsInfoRow.NewGoodsNo = substRow.ChgDestGoodsNo;
                                //        //goodsInfoRow.NewMakerCd = substRow.ChgDestMakerCd;
                                //    }
                                //}
                            }
                            break;
                        case SelectUIKind.Set:
                            if (frmSetParts == null) frmSetParts = new SelectionFormSet(partsInfo);
                            retDialog = frmSetParts.ShowDialog(owner);
                            break;
                    }
                    if (retDialog == DialogResult.Retry)
                    {
                        oldUI = partsInfo.UIKind;
                        //partsInfo.AcceptChanges();
                    }
                    //else if (retDialog == DialogResult.Abort)
                    //{
                    //    retDialog = DialogResult.Cancel;
                    //    break;
                    //}
                    else
                    {
                        if (UiDisplayStack.Count == 0)
                            break;
                        if (UiDisplayStack.Peek() == oldUI)
                            UiDisplayStack.Pop();
                        partsInfo.UIKind = UiDisplayStack.Pop();
                        oldUI = partsInfo.UIKind;
                        partsInfo.UsrGoodsInfo.SetPreviousRowToCurrentRow();
                        if (retDialog == DialogResult.Cancel)
                        {
                            partsInfo.RejectChanges();
                        }
                        else
                        {
                            partsInfo.AcceptChanges();
                        }
                    }
                    if (oldUI != SelectUIKind.None)
                        UiDisplayStack.Push(oldUI);
                } while (UiDisplayStack.Count > 0);
            }

            if (frmSetParts != null) frmSetParts.Dispose(); // 2010/07/01

            return retDialog;
        }

        //------------ADD 2009/10/20--------->>>>>
        /// <summary>
        /// 標準価格選択UI制御メソッド
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="carInfo">車両検索結果データクラス</param>
        /// <param name="partsInfo">部品検索結果データセット</param>
        /// <param name="rowToProcess">UsrGoodsInfoRow</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 標準価格選択UI表示、入力を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/10/20</br>
        /// <br>Update Note: 2011/11/21 李占川 Redmine#7876の対応</br>
        /// <br>             結合先品番を選択した訳ではないので標準価格選択ウインドの表示を行わない様に修正</br>
        /// <br>Update Note: 2012/04/06 鄧潘ハン</br>
        /// <br>管理番号   : 10801804-00 2012/05/24配信分</br>
        /// <br>             Redmine#29153   標準価格選択画面が表示されないについての修正</br>
        /// <br>Update Note: 2012/06/11 gezh</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             Redmine#30392 売上伝票入力 標準価格選択表示の対応</br>
        /// </remarks>
        //private static DialogResult ShowPriceUI(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo) // DEL 2009/11/17
        private static DialogResult ShowPriceUI(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo, PartsInfoDataSet.UsrGoodsInfoRow rowToProcess) // ADD 2009/11/17
        {
            DialogResult retDialog = DialogResult.OK;
            //------------DEL 2009/11/17--------->>>>>
            //// 品番
            //string goodsNo = string.Empty;
            //// メーカーコード
            //int goodsMakerCode = 0;
            //// BLコード
            //int bLGoodsCode = 0;
            //// 純正／優良
            //int goodsKindCode = 0;
            //------------DEL 2009/11/17---------<<<<<
            // 優良品番検索
            bool goodSearch = false;
            // 結合選択で選択された優良品番
            bool partsJoinFlag = true;

            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow = null;

            //PartsInfoDataSet.UsrGoodsInfoRow row = partsInfo.UsrGoodsInfo.RowToProcess; // ADD 2009/11/30 //DEL 鄧潘ハン 2012/04/06 Redmine#29153
            PartsInfoDataSet.UsrGoodsInfoRow row = partsInfo.UsrGoodsInfo.RowToProcess; //ADD 凌小青 on 2012/06/26 for Redmine#30595

            //>>>2011/12/16
            SearchFlag flg = partsInfo.SearchCondition.SearchFlg;
            //<<<2011/12/16

            // 参照するクラスを切り替える
            foreach (SelectionInfo selectionInfo in partsInfo.ListSelectionInfo.Values)
            { 
                //---ADD 凌小青 on 2012/06/26 for Redmine#30595---->>>>>
                if (row.GoodsNo != selectionInfo.RowGoods.GoodsNo)
                {
                    continue;
                }
                //---ADD 凌小青 on 2012/06/26 for Redmine#30595----<<<<<
                //---DEL 鄧潘ハン 2012/04/06 Redmine#29153---->>>>>
                //------------ADD 2009/11/30--------->>>>>
                //if (row.GoodsNo != selectionInfo.RowGoods.GoodsNo)
                //{
                //    continue;
                //}
                //------------ADD 2009/11/30---------<<<<<
                //---DEL 鄧潘ハン 2012/04/06 Redmine#29153----<<<<<

                // 優良品番検索を行った場合
                //if (selectionInfo.RowGoods.GoodsKindCode == 1)  // DEL 2012/06/11 gezh Redmine#30392
                if (selectionInfo.RowGoods.GoodsMakerCd >= 1000)  // ADD 2012/06/11 gezh Redmine#30392
                {
                    // 結合選択で選択なし
                    if (selectionInfo.ListChildGoods.Count == 0)
                    {
                        //>>>2011/12/16
                        //partsJoinFlag = false;  // ADD 2011/11/21

                        if ((int)flg < 2) // BL検索時
                        {
                            partsJoinFlag = false;
                        }
                        //<<<2011/12/16

                        // ｾｯﾄ選択で子品番選択なし
                        if (selectionInfo.ListChildGoods2.Count == 0)
                        {
                            usrGoodsInfoRow = selectionInfo.RowGoods;
                        }
                    }

                    // 優良品番検索
                    goodSearch = true;
                }
                // BLコード検索
                // 純正品番検索
                else
                {
                    // 結合選択で選択あり
                    if (selectionInfo.ListChildGoods.Count != 0)
                    {
                        foreach (SelectionInfo selectionInfo2 in selectionInfo.ListChildGoods.Values)
                        {
                            //if (selectionInfo2.RowGoods.GoodsKindCode == 0)  // DEL 2012/06/11 gezh Redmine#30392
                            if (selectionInfo2.RowGoods.GoodsMakerCd < 1000)  // ADD 2012/06/11 gezh Redmine#30392
                            {
                                partsJoinFlag = false;
                            }

                            // ｾｯﾄ選択で子品番選択なし
                            if (selectionInfo2.ListChildGoods.Count == 0)
                            {
                                //------------UPD 2009/11/17--------->>>>>
                                if (rowToProcess.GoodsNo == selectionInfo2.RowGoods.GoodsNo
                                    && rowToProcess.GoodsMakerCd == selectionInfo2.RowGoods.GoodsMakerCd)
                                {
                                    usrGoodsInfoRow = selectionInfo2.RowGoods;
                                    break;
                                }
                                //------------UPD 2009/11/17---------<<<<<
                            }
                            //break; // DEL 2009/11/17 
                        }
                    }
                }
                //break; // DEL 2009/11/30
            }

            // 標準価格選択UI制御メソッド
            retDialog = ShowPriceUIProc(owner, carInfo, partsInfo, usrGoodsInfoRow, goodSearch, partsJoinFlag);

            return retDialog;
        }
        //------------ADD 2009/10/20---------<<<<<

        //------------ADD 2009/11/17--------->>>>>
        /// <summary>
        /// 標準価格選択UI制御メソッド
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="carInfo">車両検索結果データクラス</param>
        /// <param name="partsInfo">部品検索結果データセット</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 標準価格選択UI表示、入力を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/11/17</br>
        /// <br>Update Note: 2011/11/21 李占川 Redmine#7876の対応</br>
        /// <br>             結合先品番を選択した訳ではないので標準価格選択ウインドの表示を行わない様に修正</br>
        /// <br>Update Note: 2012/04/06 鄧潘ハン</br>
        /// <br>管理番号   : 10801804-00 2012/05/24配信分</br>
        /// <br>             Redmine#29153   標準価格選択画面が表示されないについての修正</br>
        /// <br>Update Note: 2012/06/11 gezh</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             Redmine#30392 売上伝票入力 標準価格選択表示の対応</br>
        /// </remarks>
        private static DialogResult ShowPriceUI2(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo)
        {
            DialogResult retDialog = DialogResult.OK;
            bool goodSearch = false;
            // 結合選択で選択された優良品番
            bool partsJoinFlag = true;

            PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow = null;

            //PartsInfoDataSet.UsrGoodsInfoRow row = partsInfo.UsrGoodsInfo.RowToProcess; // ADD 2009/11/30 //DEL 鄧潘ハン 2012/04/06 Redmine#29153
            PartsInfoDataSet.UsrGoodsInfoRow row = partsInfo.UsrGoodsInfo.RowToProcess; //ADD 凌小青 on 2012/06/26 for Redmine#30595

            //>>>2011/12/16
            SearchFlag flg = partsInfo.SearchCondition.SearchFlg;
            //<<<2011/12/16
            
            // 参照するクラスを切り替える
            foreach (SelectionInfo selectionInfo in partsInfo.ListSelectionInfo.Values)
            {
                //---ADD 凌小青 on 2012/06/26 for Redmine#30595---->>>>>
                if (row.GoodsNo != selectionInfo.RowGoods.GoodsNo)
                {
                    continue;
                }
                //---ADD 凌小青 on 2012/06/26 for Redmine#30595----<<<<<
                //---DEL 鄧潘ハン 2012/04/06 Redmine#29153---->>>>>
                //------------ADD 2009/11/30--------->>>>>
                //if (row.GoodsNo != selectionInfo.RowGoods.GoodsNo)
                //{
                //    continue;
                //}
                //------------ADD 2009/11/30---------<<<<<
                //---DEL 鄧潘ハン 2012/04/06 Redmine#29153----<<<<<

                // 優良品番検索を行った場合
                //if (selectionInfo.RowGoods.GoodsKindCode == 1)  // DEL 2012/06/11 gezh Redmine#30392
                if (selectionInfo.RowGoods.GoodsMakerCd >= 1000)  // ADD 2012/06/11 gezh Redmine#30392
                {
                    // 結合選択で選択なし
                    if (selectionInfo.ListChildGoods.Count == 0)
                    {
                        //>>>2011/12/16
                        //partsJoinFlag = false;  // ADD 2011/11/21

                        if ((int)flg < 2) // BL検索時
                        {
                            partsJoinFlag = false;
                        }
                        //<<<2011/12/16

                        // ｾｯﾄ選択で子品番選択なし
                        if (selectionInfo.ListChildGoods2.Count == 0)
                        {
                            usrGoodsInfoRow = selectionInfo.RowGoods;
                        }
                    }

                    // 優良品番検索
                    goodSearch = true;

                    // 標準価格選択UI制御メソッド
                    retDialog = ShowPriceUIProc(owner, carInfo, partsInfo, usrGoodsInfoRow, goodSearch, partsJoinFlag);
                }
                // BLコード検索
                // 純正品番検索
                else
                {
                    // 結合選択で選択あり
                    if (selectionInfo.ListChildGoods.Count != 0)
                    {
                        foreach (SelectionInfo selectionInfo2 in selectionInfo.ListChildGoods.Values)
                        {
                            //if (selectionInfo2.RowGoods.GoodsKindCode == 0)  // DEL 2012/06/11 gezh Redmine#30392
                            if (selectionInfo2.RowGoods.GoodsMakerCd < 1000)  // ADD 2012/06/11 gezh Redmine#30392
                            {
                                partsJoinFlag = false;
                            }

                            // ｾｯﾄ選択で子品番選択なし
                            if (selectionInfo2.ListChildGoods.Count == 0)
                            {
                                usrGoodsInfoRow = selectionInfo2.RowGoods;

                                // 標準価格選択UI制御メソッド
                                retDialog = ShowPriceUIProc(owner, carInfo, partsInfo, usrGoodsInfoRow, goodSearch, partsJoinFlag);
                            }
                        }
                    }
                }
                break;
            }

            return retDialog;
        }

        //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>
        /// <summary>
        /// 選択純正品番情報リスト
        /// </summary>
        private static List<GoodsUnitData> _selectedSrcList = new List<GoodsUnitData>();

        /// <summary>
        /// 選択純正品番情報リストの取得
        /// </summary>
        public static List<GoodsUnitData> SelectedSrcList
        {
            get { return UIDisplayControl._selectedSrcList; }
        }

        /// <summary>
        /// 選択純正品番情報リストのクリア
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕掛№2405 得意先変更時表示区分再取得対応</br>
        /// <br>Programmer : 30757 佐々木 貴英</br>
        /// <br>Date       : 2015/04/06</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br></br>
        /// <br>Update Note: </br>
        /// <br>           : </br>
        /// <br></br>
        /// </remarks>
        public static void CrearSelectedSrcList()
        {
            UIDisplayControl._selectedSrcList.Clear();
        }
        //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<

        /// <summary>
        /// 標準価格選択UI制御メソッド
        /// </summary>
        /// <param name="owner"></param>
        /// <param name="carInfo">車両検索結果データクラス</param>
        /// <param name="partsInfo">部品検索結果データセット</param>
        /// <param name="goodSearch">goodSearch</param>
        /// <param name="partsJoinFlag">結合選択で選択された優良品番</param>
        /// <param name="usrGoodsInfoRow">usrGoodsInfoRow</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 標準価格選択UI表示、入力を行う</br>
        /// <br>Programmer : 李占川</br>
        /// <br>Date       : 2009/11/17</br>
        /// <br>Update Note: 2012/06/11 gezh</br>
        /// <br>管理番号   : 10801804-00</br>
        /// <br>             Redmine#30392 売上伝票入力 標準価格選択表示の対応</br>
        /// <br>Update Note: 2015/04/06 30757 佐々木 貴英</br>
        /// <br>管理番号   : 11070149-00</br>
        /// <br>             仕掛№2405 得意先変更時表示区分再取得対応</br>
        /// </remarks>
        private static DialogResult ShowPriceUIProc(IWin32Window owner, PMKEN01010E carInfo, PartsInfoDataSet partsInfo, PartsInfoDataSet.UsrGoodsInfoRow usrGoodsInfoRow,bool goodSearch, bool partsJoinFlag)
        {
            DialogResult retDialog = DialogResult.OK;

            // 品番
            string goodsNo = string.Empty;
            // メーカーコード
            int goodsMakerCode = 0;
            // BLコード
            int bLGoodsCode = 0;
            // 純正／優良
            int goodsKindCode = 0;

            if (usrGoodsInfoRow != null)
            {
                goodsNo = usrGoodsInfoRow.GoodsNo;
                goodsMakerCode = usrGoodsInfoRow.GoodsMakerCd;
                bLGoodsCode = usrGoodsInfoRow.BlGoodsCode;
                goodsKindCode = usrGoodsInfoRow.GoodsKindCode;
            }
            else
            {
                return retDialog;
            }

            bool result = false;

            // --- ADD m.suzuki 2011/02/25 ---------->>>>>
            //----------------------------------------
            // 表示区分プロセス実行前チェック
            //----------------------------------------
            // 純優区分≠1:優良
            // 表示区分プロセス≠1:する
            // 結合選択で選択された優良品番以外
            //if ( goodsKindCode != 1  // DEL 2012/06/11 gezh Redmine#30392
            if (goodsMakerCode < 1000  // ADD 2012/06/11 gezh Redmine#30392
                || partsInfo.PriceSelectDispDiv != 1
                || !partsJoinFlag )
            {
                return retDialog;
            }

            // 品番検索かつ"."無しかつ表示区分マスタリストなし⇒表示区分プロセスしないと同じと判断
            if ( (partsInfo.SearchMethod == 1) &&
                 (partsInfo.SearchCondition.SearchFlg != SearchFlag.PartsNoJoinSearch) &&
                 (partsInfo.PriceSelectDivList == null || partsInfo.PriceSelectDivList.Count == 0) )
            {
                return retDialog;
            }

            //----------------------------------------
            // 表示区分マスタ参照
            //----------------------------------------
            PartsInfoDataSet.UsrGoodsInfoRow row = null;
            //if ( goodsKindCode == 1 )  // DEL 2012/06/11 gezh Redmine#30392
            if (goodsMakerCode >= 1000)  // ADD 2012/06/11 gezh Redmine#30392
            {
                // 得意先掛率グループコードの取得
                result = partsInfo.SettingCustRateGrpCode( partsInfo.CustRateGrpCodeList,
                            partsInfo.CustomerCode,
                            goodsNo,
                            goodsMakerCode );

                if ( !result )
                {
                    return retDialog;
                }

                int custRateGrpCode = -1;
                row = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo( goodsMakerCode, goodsNo );

                if ( row != null )
                {
                    custRateGrpCode = row.CustRateGrpCode;
                }
                // 標準価格選択区分の取得
                result = partsInfo.SettingDisplayDiv( partsInfo.PriceSelectDivList,
                    goodsNo,
                    goodsMakerCode,
                    bLGoodsCode,
                    partsInfo.CustomerCode,
                    custRateGrpCode );

                if ( !result )
                {
                    return retDialog;
                }

                // 品番検索かつ"."無しかつ表示区分設定マスタに未登録⇒表示区分プロセスしないと同じと判断
                if ( (partsInfo.SearchMethod == 1) &&
                     (partsInfo.SearchCondition.SearchFlg != SearchFlag.PartsNoJoinSearch) &&
                     (row.PriceSelectDiv < 0) )
                {
                    return retDialog;
                }
            }
            // --- ADD m.suzuki 2011/02/25 ----------<<<<<

            // 品番検索後、結合元検索を行い結合元検索情報の取得
            // 品番検索の場合
            // --- UPD m.suzuki 2011/05/12 ---------->>>>>
            # region // DEL
            //// --- UPD m.suzuki 2011/02/24 ---------->>>>>
            ////// --- UPD m.suzuki 2011/01/27 ---------->>>>>
            ////////>>>2010/12/14
            ////////// -- UPD 2010/04/16 ----------------------------->>>
            ////////// 優良の結合検索有りの場合のみ、結合元検索を行うように修正
            //////////if ((int)partsInfo.SearchCondition.SearchFlg >= 2
            //////////    && goodsKindCode == 1)
            ////////if ( (int)partsInfo.SearchCondition.SearchFlg >= 4
            ////////    && goodsKindCode == 1 )
            ////////// -- UPD 2010/04/16 -----------------------------<<<
            //////
            //////// 結合検索無しでも、優良品番検索の場合、処理を行う
            //////if (((int)partsInfo.SearchCondition.SearchFlg >= 4 && goodsKindCode == 1) ||
            //////    (usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4))
            ////////<<<2010/12/14
            ////
            ////// 結合検索無しでも、優良品番検索の場合、処理を行う
            ////// 結合検索無しでも、代替ありなら代替先の結合検索ありにする為に、処理を行う
            ////if ( ((int)partsInfo.SearchCondition.SearchFlg >= 4 && goodsKindCode == 1) ||
            ////     (usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4) ||
            ////     (partsInfo.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo && (partsInfo.UsrJoinParts.Count > 0 || partsInfo.JoinParts.Count > 0)) )
            ////// --- UPD m.suzuki 2011/01/27 ----------<<<<<
            //
            //// 結合検索無しでも、優良品番検索の場合、処理を行う
            //// 結合検索無しでも、代替ありなら代替先の結合検索ありにする為に、処理を行う
            //if ( ((int)partsInfo.SearchCondition.SearchFlg >= 4 && goodsKindCode == 1) ||
            //     ((partsInfo.SearchMethod == 1) && ((usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4))) ||
            //     (partsInfo.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo && (partsInfo.UsrJoinParts.Count > 0 || partsInfo.JoinParts.Count > 0)) )
            //// --- UPD m.suzuki 2011/02/24 ----------<<<<<
            # endregion
            // 結合元検索フラグ(true:結合元検索を実行する)
            bool srcPartsSearchFlag = false;

            if ( partsInfo.SearchMethod == 1 && ((usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4)) )
            {
                // 品番検索・優良品番
                if ( row.PriceSelectDiv == 0 )
                {
                    // 品番検索・優良品番・表示区分マスタ＝優良⇒結合元検索しない
                    srcPartsSearchFlag = false;
                }
                else
                {
                    // その他の、品番検索・優良品番⇒結合元検索する
                    srcPartsSearchFlag = true;
                }
            }
            //else if ( (int)partsInfo.SearchCondition.SearchFlg >= 4 && goodsKindCode == 1 )  // DEL 2012/06/11 gezh Redmine#30392
            else if ((int)partsInfo.SearchCondition.SearchFlg >= 4 && goodsMakerCode >= 1000)  // ADD 2012/06/11 gezh Redmine#30392
            {
                // 結合検索あり("."付)⇒結合元検索を実行
                srcPartsSearchFlag = true;
            }
            else if ( partsInfo.SearchCondition.SearchFlg == SearchFlag.GoodsAndSetInfo && (partsInfo.UsrJoinParts.Count > 0 || partsInfo.JoinParts.Count > 0) )
            {
                // 結合検索なしでも、代替ありの場合は代替先の結合検索ありにする⇒結合元検索する
                srcPartsSearchFlag = true;
            }

            // 結合元検索する
            if ( srcPartsSearchFlag )
            // --- UPD m.suzuki 2011/05/12 ----------<<<<<
            {
                GoodsCndtn goodsCndtn = new GoodsCndtn();
                goodsCndtn.EnterpriseCode = partsInfo.SearchCondition.EnterpriseCode;
                goodsCndtn.SectionCode = partsInfo.SearchCondition.SectionCode;
                goodsCndtn.GoodsMakerCd = goodsMakerCode;
                goodsCndtn.GoodsNo = goodsNo;
                // 結合元検索情報をPartsInfoDataSetへ設定する。
                result = partsInfo.SettingSrcPartsInfo(goodsCndtn);

                // 検索失敗場合
                if (!result)
                {
                    return retDialog;
                }

                // 結合元検索情報がない場合
                if (partsInfo.PartsInfoDataSetSrcParts == null)
                {
                    return retDialog;
                }
            }

            // --- DEL m.suzuki 2011/02/25 ---------->>>>> // 結合元検索の前に移動
            //PartsInfoDataSet.UsrGoodsInfoRow row = null;
            //if (goodsKindCode == 1)
            //{
            //    // 得意先掛率グループコードの取得
            //    result = partsInfo.SettingCustRateGrpCode(partsInfo.CustRateGrpCodeList,
            //                partsInfo.CustomerCode,
            //                goodsNo,
            //                goodsMakerCode);

            //    if (!result)
            //    {
            //        return retDialog;
            //    }

            //    int custRateGrpCode = -1;
            //    row = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(goodsMakerCode, goodsNo);

            //    if (row != null)
            //    {
            //        custRateGrpCode = row.CustRateGrpCode;
            //    }
            //    // 標準価格選択区分の取得
            //    result = partsInfo.SettingDisplayDiv(partsInfo.PriceSelectDivList,
            //        goodsNo,
            //        goodsMakerCode,
            //        bLGoodsCode,
            //        partsInfo.CustomerCode,
            //        custRateGrpCode);

            //    if (!result)
            //    {
            //        return retDialog;
            //    }
            //}
            // --- DEL m.suzuki 2011/02/25 ----------<<<<<

            // 標準価格選択ウインドウの表示条件
            // 確定した品番が優良の場合
            // 定価に対する掛率がヒットしていない場合
            // 標準価格選択表示区分が「する」の場合
            // --- UPD m.suzuki 2011/05/12 ---------->>>>>
            //if (goodsKindCode == 1
            //    && partsInfo.PriceSelectDispDiv == 1
            //    && partsJoinFlag)
            //if (goodsKindCode == 1  // DEL 2012/06/11 gezh Redmine#30392
            if (goodsMakerCode >= 1000  // ADD 2012/06/11 gezh Redmine#30392
                && partsInfo.PriceSelectDispDiv == 1
                && partsJoinFlag
                && row.PriceSelectDiv != 0 )
            // --- UPD m.suzuki 2011/05/12 ----------<<<<<
            {
                // 優良品番検索時(*1)で、結合を含む検索を行った場合
                if (goodSearch)
                {
                    //>>>2010/12/14
                    //if ((int)partsInfo.SearchCondition.SearchFlg < 4)
                    //{
                    //    return retDialog;
                    //}

                    // 結合検索無しでも、優良品番検索の場合は終了しない
                    if (((int)partsInfo.SearchCondition.SearchFlg < 4) &&
                        (usrGoodsInfoRow.OfferKubun != 2) && (usrGoodsInfoRow.OfferKubun != 4))
                    {
                        return retDialog;
                    }
                    //<<<2010/12/14
                }

                // RateDivLPriceの値は、(*1)で対象となる部品情報で算出および更新を行う。
                if (partsInfo.CalculateGoodsPrice == null) return retDialog;

                List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();

                // 結合元
                goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(goodsNo, goodsMakerCode));

                // 商品情報が存在する場合は価格計算
                if (goodsPrimaryKeyList.Count > 0)
                {
                    partsInfo.SettingGoodsPrice(goodsPrimaryKeyList);
                }

                row = partsInfo.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(goodsMakerCode, goodsNo);

                int priceSelectDiv = -1;
                if (row != null)
                {
                    if (!string.IsNullOrEmpty(row.RateDivLPrice))
                    {
                        return retDialog;
                    }
                    priceSelectDiv = row.PriceSelectDiv;
                }

                // --- UPD m.suzuki 2011/02/10 ---------->>>>>
                # region // DEL
                ////>>>2011/01/13
                //////>>>2010/12/14
                ////// 優良品番検索を行い、結合検索無し、表示区分マスタ該当無しの場合、標準価格ウインドウ表示無し
                ////if (((int)partsInfo.SearchCondition.SearchFlg < 4) &&
                ////    ((usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4)) &&
                ////    (priceSelectDiv == -1))
                ////{
                ////    return retDialog;
                ////}
                //////<<<2010/12/14
                //
                //// 優良品番検索を行い、結合検索無し、表示区分マスタ該当無しの場合、標準価格ウインドウ表示無し
                //if (((int)partsInfo.SearchCondition.SearchFlg >= 2) && // BLコード検索は判定対象外
                //    // --- ADD m.suzuki 2011/01/27 ---------->>>>>
                //    ((int)partsInfo.SearchCondition.SearchFlg != 3 || (partsInfo.UsrJoinParts.Count == 0 && partsInfo.JoinParts.Count == 0)) &&
                //    // --- ADD m.suzuki 2011/01/27 ----------<<<<<
                //    ((int)partsInfo.SearchCondition.SearchFlg < 4) &&
                //    ((usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4)) &&
                //    (priceSelectDiv == -1))
                //{
                //    return retDialog;
                //}
                ////<<<2011/01/13
                # endregion
                // 優良品番検索を行い、結合検索無し、表示区分マスタ該当無しの場合、標準価格ウインドウ表示無し
                if ( ((int)partsInfo.SearchCondition.SearchFlg >= 2) && // BLコード検索は判定対象外
                    ((int)partsInfo.SearchCondition.SearchFlg < 4) &&
                    ((usrGoodsInfoRow.OfferKubun == 2) || (usrGoodsInfoRow.OfferKubun == 4)) &&
                    (priceSelectDiv == -1) )
                {
                    return retDialog;
                }
                // --- UPD m.suzuki 2011/02/10 ----------<<<<<

                // 標準価格選択ウインドウ表示処理
                SelectionListPrice frmSetPrice = new SelectionListPrice(goodsMakerCode, goodsNo, carInfo, partsInfo, priceSelectDiv);
                retDialog = frmSetPrice.ShowDialog(owner);
                //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ---------------->>>>>

                // 標準価格選択ウインドウで[1:標準]以外が選択（結合元(純正)品が確定）された場合
                // 選択純正品番情報リストに対象の優良品の結合元(純正)品情報を追加する。
                if (!string.IsNullOrEmpty(frmSetPrice.SrcGoodsNo))
                {
                    GoodsUnitData nowGoodsUnitData = new GoodsUnitData();
                    nowGoodsUnitData.BLGoodsCode = usrGoodsInfoRow.BlGoodsCode;
                    nowGoodsUnitData.GoodsNo = usrGoodsInfoRow.GoodsNo;
                    nowGoodsUnitData.GoodsMakerCd = usrGoodsInfoRow.GoodsMakerCd;
                    nowGoodsUnitData.JoinSourceMakerCode = frmSetPrice.SrcGoodsMakerCode;
                    nowGoodsUnitData.JoinSrcPartsNoWithH = (string)frmSetPrice.SrcGoodsNo.Clone();

                    _selectedSrcList.Add(nowGoodsUnitData);
                }
                //---ADD 30757 佐々木 貴英 2015/04/06 仕掛№2405 得意先変更時表示区分再取得対応 ----------------<<<<<
                frmSetPrice.Dispose(); // 2010/07/01
            }
            else
            {
                return retDialog;
            }

            return retDialog;
        }
        //------------ADD 2009/11/17---------<<<<<
        #endregion
    }
}
