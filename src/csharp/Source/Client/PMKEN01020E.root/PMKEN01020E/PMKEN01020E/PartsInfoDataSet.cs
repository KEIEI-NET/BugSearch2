//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 部品検索データクラス
// プログラム概要   : 部品検索抽出条件パラメータ
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号 :              作成担当 : 
// 作 成 日 : ----/--/--   修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号 : 11470007-00  作成担当 : 30757 佐々木　貴英
// 作 成 日 : 2018/04/05   修正内容 : ビルド時警告対応
//----------------------------------------------------------------------------//
using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text; // ADD 2010/05/17
using Broadleaf.Application.Controller;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.UIData
{
    // ADD 2010/05/17 品名表示対応 ---------->>>>>
    using GoodsNamePair = KeyValuePair<string, string>; // Key:品名／Value:品名(カナ)
    // ADD 2010/05/17 品名表示対応 ----------<<<<<

    /// <summary>
    /// 部品検索結果を格納するデータセットクラスです。
    /// </summary>
    /// <remarks>
    /// <br>Update Note	: 速度チューニング対応</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.10</br>
    /// <br></br>
    /// <br>Update Note	: 代替処理の修正、優良設定対応</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.02.17</br>
    /// <br></br>
    /// <br>Update Note : （検索見積向け変更）優良部品リストを返すとき種別名称をセットするよう変更。</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2009.03.25</br>
    /// <br></br>
    /// <br>Update Note : MANTIS[0013598] 代替部品と複数互換品を同時選択した場合に、QTYがセットされない不具合の修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009.06.23</br>
    /// <br></br>
    /// <br>Update Note	: 部品選択のソート順を変更する為、PartsInfoに項目追加。</br>
    /// <br>Programmer	: 22018　鈴木 正臣</br>
    /// <br>Date		: 2009.07.23</br>
    /// <br></br>
    /// <br>Update Note	: 品名表示方法を変更(BLコード検-優良品-品名表示区分:提供優先→優先順位:○提供,商品 ×商品)</br>
    /// <br>Programmer	: 20056 對馬 大輔</br>
    /// <br>Date		: 2009.08.03</br>
    /// <br></br>
    /// <br>Update Note : 2009/10/19 呉元嘯</br>
    /// <br>              PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>              PM.NS保守依頼②を追加</br>
    /// <br></br>
    /// <br>Update Note	: 品名表示方法を、PM7仕様と同様になるように変更</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/10/23</br>
    /// <br></br>
    /// <br>Update Note	: 品名表示方法を、PM7仕様と同様になるように変更(検索見積の対応)</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/10/27</br>
    /// <br></br>
    /// <br>Update Note : 2009/11/05 呉元嘯</br>
    /// <br>              PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>              Redmine#1087、#1134対応</br>
    /// <br></br>
    /// <br>Update Note : 2009/11/11 呉元嘯</br>
    /// <br>              PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>              Redmine#1222対応</br>
    /// <br></br>
    /// <br>Update Note : 2009/11/13 呉元嘯</br>
    /// <br>              PM.NS-3-A・PM.NS保守依頼②</br>
    /// <br>              印刷品番対応</br>
    /// <br></br>
    /// <br>Update Note : 2009/11/13② 李占川</br>
    /// <br>              PM.NS-4-A・PM.NS保守依頼③</br>
    /// <br>              TBO初期化フラグの追加</br>
    /// <br></br>
    /// <br>Update Note	: 結合マスタの提供データ表示順位の付番方法を変更</br>
    /// <br>Programmer	: 22008　長内 数馬</br>
    /// <br>Date		: 2009/10/30</br>
    /// <br></br>
    /// <br>Update Note	: MANTIS[0014671]対応
    /// <br>              ①UserGoodsInfoに検索品名取得メーカーを追加</br>
    /// <br>              ②BLコード検索で品名取得時、結合元の検索品名取得メーカーが0の場合は品名を取得しないように修正</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/11/24</br>
    /// <br></br>
    /// <br>Update Note	: ①UsrGoodsInfoテーブルに、価格摘要開始日(PartsPriceStDate)を追加(MANTIS[0014767])</br>
    /// <br>              ②売価未設定時区分対応(MANTIS[0013594])</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/12/10</br>
    /// <br></br>
    /// <br>Update Note	: ①代替処理について、パラメータの価格適用開始日を参照するように変更(MANTIS[0014773])</br>
    /// <br>              ②定価設定時、適用日≦画面日付で定価を取得するように修正(MANTIS[0014771])</br></br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/12/14</br>
    /// <br></br>
    /// <br>Update Note  : 代替先のQTYがゼロの場合は、代替元のQTYを使用するように変更(MANTIS[0014912])</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2010/03/16</br>
    /// <br></br>
    /// <br>Update Note  : 検索見積で、セット情報表示時にエラーになる件の対応(MANTIS[0015177])</br>
    /// <br>               ・コピーメソッドの追加</br>
    /// <br>Programmer   : 21024　佐々木 健</br>
    /// <br>Date         : 2010/03/19</br>
    /// <br></br>
    /// <br>Update Note  : 売上全体設定の純正代替＝代替しないの場合もQTYが正しく表示されるように修正</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2010/03/23</br>
    /// <br></br>
    /// <br>Update Note	: ＳＣＭの組込み（2009.06.03修正分の再組み込み）※ソースを検索する時は、2010/03/24で検索して下さい</br>
    /// <br>              ①キャンペーン価格取得デリゲート追加</br>
    /// <br>              ②自動連携値引き価格取得デリゲート追加</br>
    /// <br>              ③GetGoodsListメソッドで代替を行わないメソッドをオーバーロード</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2010/03/24</br>
    /// <br></br>
    /// <br>Update Note  : 自由検索オプション対応</br>
    /// <br>                 PartsInfoDataSetのPartsInfoにFreSrchPrtPropNoを追加。</br>
    /// <br>                 PartsInfoDataSetのPartsInfoにTbsPartsCodeFSを追加。</br>
    /// <br>                 PartsInfoDataSetのUsrGoodsInfoにFreSrchPrtPropNoを追加。</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2010/04/28</br>
    /// <br></br>
    /// <br>Update Note  : 品名表示対応</br>
    /// <br>Programmer   : 30434 工藤 恵優</br>
    /// <br>Date         : 2010/05/17</br>
    /// <br></br>
    /// <br>Update Note  : 品名半角対応</br>
    /// <br>Programmer   : 20056 對馬 大輔</br>
    /// <br>Date         : 2010/06/03</br>
    /// <br></br>
    /// <br>Update Note  : 成果物統合</br>
    /// <br>                 自由検索オプション 2010/04/28 の組込</br>
    /// <br>                 ７次改良(品名表示対応) 2010/05/17 の組込</br>
    /// <br>                 障害改良対応(7月分) 2010/06/03 の組込</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2010/06/04</br>
    /// <br></br>
    /// <br>Update Note  : 成果物統合</br>
    /// <br>                 品名表示対応の修正(※成果物統合によりミスマッチになった？)</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2010/06/11</br>
    /// <br></br>
    /// <br>Update Note  : 成果物統合</br>
    /// <br>                 2010/06/11修正への条件追加</br>
    /// <br>Programmer   : 20056 對馬 大輔</br>
    /// <br>Date         : 2010/06/30</br>
    /// <br></br>
    /// <br>Update Note  : 障害対応</br>
    /// <br>                 品名表示区分　任意設定でBLコードマスタから表示する場合、全角表示になる件の対応(半角とする)</br>
    /// <br>Programmer   : 20056 對馬 大輔</br>
    /// <br>Date         : 2010/06/30</br>
    /// <br></br>
    /// <br>Update Note  : 成果物統合２</br>
    /// <br>                 セット子品番を選択した時、セット名称を表示する為の対応。（内容設定自体はPMTKD06020Bで行う）</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2010/07/14</br>
    /// <br></br>
    /// <br>Update Note  : 障害改良対応</br>
    /// <br>                 MANTIS[0014853] 提供データに存在する純正品以外が結合元の場合に優良品情報が表示されない件の修正。</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2011/01/14</br>
    /// <br></br>
    /// <br>Update Note  : キャンペーン管理</br>
    /// <br>                 キャンペーン価格判定デリゲートの定義変更（キャンペーン管理マスタに合わせる）</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2011/05/16</br>
    /// <br></br>
    /// <br>Update Note  : PCCUOE対応</br>
    /// <br>             :   ・純正Index指定による選択を可能とする</br>
    /// <br>Programmer   : 20056 對馬 大輔</br>
    /// <br>Date         : 2011/09/04</br>    
    /// <br>Update Note  : 既存案件の保守</br>
    /// <br>                 BLコード検索でQTYが反映されないの変更</br>
    /// <br>Programmer   : yangmj</br>
    /// <br>Date         : 2011/11/24</br>
    /// <br>Update Note  : Redmine#8033</br>
    /// <br>Programmer   : 譚洪</br>
    /// <br>Date         : 2011/12/12</br>
    /// <br></br>
    /// <br>Update Note  : 特記事項対応</br>
    /// <br>             :   ・最新品番に特記が設定されていない場合、カタログ品番の特記を戻り値とする</br>
    /// <br>Programmer   : 20056 對馬 大輔</br>
    /// <br>Date         : 2012/01/16</br>    
    /// <br>Update Note  : 2012/03/29 wangf </br>
    /// <br>管理番号     : 10801804-00 2012/05/24配信分</br>
    /// <br>             : Redmine#29146 検索見積発行にで結合部品が表示されないの対応</br>
    /// <br>Update Note  : BL-Pダイレクト発注対応</br>
    /// <br>Programmer   : 20056 對馬 大輔</br>
    /// <br>Date         : 2012/04/09</br>  
    /// <br>Update Note  : 2012/04/25 wangf </br>
    /// <br>管理番号     : 10801804-00 2012/05/24配信分</br>
    /// <br>             : Redmine#29146 部品選択画面で代替部品を選択した場合に、結合する優良部品が２重で表示されるの対応</br>
    /// <br>Update Note  : 2012/08/15配信 SCM障害№10359対応</br>
    /// <br>Programmer   : 30745 吉岡 孝憲</br>
    /// <br>Date         : 2012/08/09</br>  
    /// <br>Update Note  : 特定品番で検索すると売伝が落ちる不具合対応</br>
    /// <br>Programmer   : 30517 夏野 駿希</br>
    /// <br>Date         : 2012/08/10</br>  
    /// <br>Update Note  : SCM障害№10492対応</br>
    /// <br>Programmer   : 30744 湯上 千加子</br>
    /// <br>Date         : 2013/03/25</br>  
    /// <br></br>
    /// <br>Update Note  : 10900269-00 SPK車台番号文字列対応</br>
    /// <br>             :   ParsInfoDataSetに「VIN生産No.(始期)」「VIN生産No.(終期)」を追加</br>
    /// <br>Programmer   : FSI斎藤 和宏</br>
    /// <br>Date         : 2013/03/27</br> 
    /// <br></br>
    /// <br>Update Note  : 2014/01/15 宮本 利明</br>
    /// <br>管理番号     : 10904597-00　純正定価印字対応</br>
    /// <br>               商品リスト作成処理(結合元情報含む)を追加</br>
    /// <br>Update Note  : 2014/01/29 宮本 利明</br>
    /// <br>管理番号     : 10904597-00　純正定価印字対応</br>
    /// <br>               セット品の場合も親情報を商品リストにセットする</br>
    /// <br>Update Note  : 2014/06/04 30744 湯上 千加子</br>
    /// <br>管理番号     : </br>
    /// <br>               SCM仕掛一覧№10659対応</br>
    /// <br></br>
    /// <br>Programmer   : 20073 西 毅</br>
    /// <br>Date         : 2014/05/16</br>  
    /// <br>Update Note  : 藤木自動車対応 代替品選択の場合代替元のQTYが引き継がれない。</br>
    /// <br></br>
    /// <br>Programmer   : 30744 湯上 千加子</br>
    /// <br>Date         : 2015/01/07</br>  
    /// <br>Update Note  : メーカー希望小売価格対応</br>
    /// <br></br>
    /// <br>Programmer   : 30744 湯上 千加子</br>
    /// <br>Date         : 2015/02/25</br>  
    /// <br>Update Note  : SCM高速化 C向け種別対応</br>
    /// <br></br>
    /// <br>Programmer   : 30744 湯上 千加子</br>
    /// <br>Date         : 2015/03/18</br>  
    /// <br>Update Note  : メーカー希望小売価格対応 2015/01/07対応分削除 提供データ価格情報プロパティ追加</br>
    /// <br>Update Note  : 2015/05/12 許雁波</br>
    /// <br>管理番号     : 11175064-00</br>
    /// <br>             : Redmine 45802 アライ商会様 №22 売上伝票にてセットマスタ登録商品を選択するとＱＴＹが１になる修正。</br>
    /// <br>Update Note  : 2018/04/05  30757 佐々木　貴英</br>
    /// <br>管理番号     : 11470007-00</br>
    /// <br>             : ビルド時警告対応</br>
    /// </remarks>
    partial class PartsInfoDataSet
    {
        #region [ 各データテーブル ]
        partial class UsrGoodsPriceDataTable
        {
            /// <summary>
            /// 指定した価格適用日に当たる価格を返す。
            /// </summary>
            /// <param name="GoodsMakerCd">メーカーコード</param>
            /// <param name="GoodsNo">品番</param>
            /// <param name="PriceApplyDate">価格適用日</param>
            /// <returns></returns>
            public UsrGoodsPriceRow FindApplyPrice(int GoodsMakerCd, string GoodsNo, int PriceApplyDate)
            {
                string query = string.Format("{0}={1} AND {2}='{3}'",
                    GoodsMakerCdColumn.ColumnName, GoodsMakerCd,
                    GoodsNoColumn.ColumnName, GoodsNo);
                UsrGoodsPriceRow[] rows = (UsrGoodsPriceRow[])Select(query, PriceStartDateColumn.ColumnName + " DESC");

                for (int i = 0; i < rows.Length; i++)
                {
                    int priceStartDate = rows[i].PriceStartDate.Year * 10000 + rows[i].PriceStartDate.Month * 100 + rows[i].PriceStartDate.Day;
                    if (PriceApplyDate >= priceStartDate)
                        return rows[i];
                }
                return null;
            }
        }

        partial class PartsInfoDataTable
        {
            /// <summary>
            /// 純正部品情報取得
            /// </summary>
            /// <param name="makerCode">メーカーコード</param>
            /// <param name="PartsNo">品番</param>
            /// <returns></returns>
            public PartsInfoRow FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(int makerCode, string PartsNo)
            {
                string query = string.Format("{0}={1} AND {2}='{3}'",
                            columnCatalogPartsMakerCd.ColumnName, makerCode,
                            columnClgPrtsNoWithHyphen.ColumnName, PartsNo);
                PartsInfoRow[] rows = (PartsInfoRow[])Select(query);
                if (rows.Length == 0)
                    return null;
                return rows[0];
            }
        }

        partial class UsrJoinPartsDataTable
        {
            /// <summary>
            /// 結合データが提供データかチェックする
            /// </summary>
            /// <param name="joinSrcMakerCd">結合元品メーカーコード</param>
            /// <param name="joinSrcPartsNo">結合元品番</param>
            /// <param name="joinDestMakerCd">結合先品メーカーコード</param>
            /// <param name="joinDestPartsNo">結合先品番</param>
            /// <returns>true:提供データ／false:ユーザーデータ又は該当結合データなし</returns>
            public bool IsOfferData(int joinSrcMakerCd, string joinSrcPartsNo, int joinDestMakerCd, string joinDestPartsNo)
            {
                string query = string.Format("{0}={1} AND {2}='{3}' AND {4}={5} AND {6}='{7}'",
                    columnJoinSourceMakerCode.ColumnName, joinSrcMakerCd,
                    columnJoinSrcPartsNoWithH.ColumnName, joinSrcPartsNo,
                    columnJoinDestMakerCd.ColumnName, joinDestMakerCd,
                    columnJoinDestPartsNo.ColumnName, joinDestPartsNo);
                UsrJoinPartsRow[] row = (UsrJoinPartsRow[])Select(query);
                if (row.Length == 0)
                    return false;
                if (row[0].JoinOfferDate == DateTime.MinValue)
                    return false;
                return true;
            }

        }

        partial class UsrSetPartsDataTable
        {
            /// <summary>
            /// 指定の品番・メーカーの部品がセット部品かどうかをチェックする。
            /// </summary>
            /// <param name="makerCd">メーカーコード</param>
            /// <param name="partsNo">品番</param>
            /// <returns>true:セット子あり／false:セット子なし</returns>
            public bool SetExist(int makerCd, string partsNo)
            {
                bool ret = false;
                string query = string.Format("{0} = {1} AND {2} = '{3}'",
                    ParentGoodsMakerCdColumn.ColumnName, makerCd, ParentGoodsNoColumn.ColumnName, partsNo);
                if (Select(query).Length > 0)
                    ret = true;
                return ret;
            }
        }

        partial class TBOInfoDataTable
        {
            /// <summary>
            /// 収録している部品のBLコード一覧を返す
            /// </summary>
            /// <returns></returns>
            public List<int> GetBLList()
            {
                List<int> lst = new List<int>();
                for (int i = 0; i < Count; i++)
                {
                    int blCd = (int)Rows[i][TbsPartsCodeColumn];
                    if (lst.Contains(blCd) == false)
                    {
                        lst.Add(blCd);
                    }
                }
                return lst;
            }
        }

        partial class StockDataTable
        {
            /// <summary>
            /// 選択状態の在庫をStockクラスで返す
            /// </summary>
            /// <returns>Stockクラス</returns>
            public Stock GetSelectedStock(DataViewRowState state)
            {
                string filter = string.Format("{0} = True", SelectionStateColumn.ColumnName);
                StockRow[] rows = (StockRow[])this.Select(filter, string.Empty, state);
                if (rows.Length > 0)
                {
                    Stock stock = GetStockFromStockRow(rows[0]);
                    return stock;
                }
                return null;
            }
        }

        partial class UsrSubstPartsDataTable
        {
            /// <summary>
            /// 選択状態の行を返す
            /// </summary>
            /// <param name="state"></param>
            /// <returns>選択状態の行(ない場合はnull)</returns>
            public UsrSubstPartsRow GetSelectedRow(DataViewRowState state)
            {
                string filter = string.Format("{0} = True", SelectionStateColumn.ColumnName);
                UsrSubstPartsRow[] rows = (UsrSubstPartsRow[])this.Select(filter, string.Empty, state);
                if (rows.Length > 0)
                    return rows[0];
                return null;
            }
        }

        partial class UsrGoodsInfoDataTable
        {
            #region 画面制御UI(PMKEN08000U)用
            private UsrGoodsInfoRow _rowToProcess = null;
            private UsrGoodsInfoRow _previouslyProcessedRow = null;
            private UsrGoodsInfoRow _prevPrevious = null;
#if TODELETE
            private UsrGoodsInfoRow _previousActiveRow = null;
            /// <summary>前回グリッド表示したアクティブローを取得又は設定します</summary>
            public UsrGoodsInfoRow PreviousActiveRow
            {
                get
                {
                    if (_previousActiveRow != null)
                        return _previousActiveRow;
                    if (this.DefaultView.Count > 0)
                        return (UsrGoodsInfoRow)this.DefaultView[0].Row;
                    return null;
                }
                set
                {
                    _previousActiveRow = value;
                }
            }

            /// <summary>前回グリッド表示したアクティブローをクリアします</summary>
            public void ClearPreviousActiveRow()
            {
                _previousActiveRow = null;
            }

            /// <summary>
            /// 選択状態を全てクリアする。
            /// </summary>
            public void ResetSelectionState()
            {
                for (int i = 0; i < Count; i++)
                {
                    Rows[i][SelectionStateColumn] = false;
                }
                AcceptChanges();
            }

            /// <summary>現在の選択UIの元のなる直前の選択UIのたローを取得します</summary>
            public UsrGoodsInfoRow PreviouslyProcessedRow
            {
                get
                {
                    return _previouslyProcessedRow;
                }
            }

            /// <summary>選択UIで処理するローをクリアします</summary>
            public void ClearRowToProcess()
            {
                _rowToProcess = null;
            }
#endif
            /// <summary>選択UIで処理するローを取得又は設定します</summary>
            public UsrGoodsInfoRow RowToProcess
            {
                get
                {
                    return _rowToProcess;
                }
                set
                {
                    _prevPrevious = _previouslyProcessedRow;
                    _previouslyProcessedRow = _rowToProcess;
                    _rowToProcess = value;
                }
            }

            /// <summary>以前の選択UI処理ローを現在選択UI処理ローに戻します。
            /// 　選択ボタンでなく、確定又は戻るボタンを押したときにこのメソッドを呼びます。</summary>
            public void SetPreviousRowToCurrentRow()
            {
                _rowToProcess = _previouslyProcessedRow;
                _previouslyProcessedRow = _prevPrevious;
                _prevPrevious = null;
            }
            #endregion

            /// <summary>
            /// 選択状態の行を返す
            /// </summary>
            /// <param name="state"></param>
            /// <returns>選択状態の行(ない場合はnull)</returns>
            public UsrGoodsInfoRow[] GetSelectedRow(DataViewRowState state)
            {
                string filter = string.Format("{0} = True", SelectionStateColumn.ColumnName);
                UsrGoodsInfoRow[] rows = (UsrGoodsInfoRow[])this.Select(filter, string.Empty, state);
                return rows;
            }

            /// <summary>
            /// 指定の部品が提供純正部品且つその部品の最新品番の部品がある場合、それを返す。
            /// </summary>
            /// <param name="row"></param>
            /// <returns>最新品番の部品情報又はnull</returns>
            internal UsrGoodsInfoRow GetNewPartsNoGoodsIfAny(UsrGoodsInfoRow row)
            {
                if (row.OfferKubun == 1 || row.OfferKubun == 3)
                {
                    PartsInfoRow[] rowOrg = (PartsInfoRow[])row.GetChildRows("UsrGoodsInfo_PartsInfo");
                    if (rowOrg.Length > 0 && rowOrg[0].ClgPrtsNoWithHyphen != rowOrg[0].NewPrtsNoWithHyphen)
                    {
                        return FindByGoodsMakerCdGoodsNo(rowOrg[0].CatalogPartsMakerCd, rowOrg[0].NewPrtsNoWithHyphen);
                    }
                }
                return null;
            }
        }
        #endregion

        #region [ 代替取得メソッド ]
        /// <summary>
        /// 提供代替品があれば返す。なければ元の品を返す。[結合先品・セット子品などの最新品番検索用]
        /// </summary>
        /// <param name="row">提供代替元</param>
        /// <returns></returns>
        public UsrGoodsInfoRow GetOfrSubst(UsrGoodsInfoRow row)
        {
            UsrGoodsInfoRow ret = row;
            string rowFilter;
            UsrSubstPartsRow[] substRows;
            // 2010/03/19 >>>
            //// 2009/12/14 ①　>>>
            ////int now = GetIntFromDt(DateTime.Now);
            //int now = GetIntFromDt(( this._searchCondition.PriceDate.Equals(DateTime.MinValue) ) ? DateTime.Now : this._searchCondition.PriceDate);
            //// 2009/12/14 ①　<<<

            int now = GetIntFromDt(( this._searchCondition == null || this._searchCondition.PriceDate.Equals(DateTime.MinValue) ) ? DateTime.Now : this._searchCondition.PriceDate);
            // 2010/03/19 <<<
            // 2009.02.17 >>>
            //for (int i = 1; i < 4; i++) // 仮に３世帯までとする。
            for (int i = 1; i < 11; i++) // 仮に１０世帯までとする。
            // 2009.02.17 <<<
            {
                rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4} = true", // 代替選択UIには提供のみ表示
                    tableUsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, ret.GoodsNo,
                    tableUsrSubstParts.ChgSrcMakerCdColumn.ColumnName, ret.GoodsMakerCd, tableUsrSubstParts.OfferKubunColumn.ColumnName);
                substRows = (UsrSubstPartsRow[])tableUsrSubstParts.Select(rowFilter);
                if (substRows.Length > 0)
                {
                    ret = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRows[0].ChgDestMakerCd, substRows[0].ChgDestGoodsNo);
                }
                else
                {
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// ユーザー代替品があれば返す。なければ元の品を返す。
        /// </summary>
        /// <param name="row">ユーザー代替元</param>
        /// <returns></returns>
        public UsrGoodsInfoRow GetUsrSubst(UsrGoodsInfoRow row)
        {
            UsrGoodsInfoRow ret = row;
            string rowFilter;
            UsrSubstPartsRow[] substRows;
            // 2010/03/19 >>>
            //// 2009/12/14 ①　>>>
            ////int now = GetIntFromDt(DateTime.Now);
            //int now = GetIntFromDt(( this._searchCondition.PriceDate.Equals(DateTime.MinValue) ) ? DateTime.Now : this._searchCondition.PriceDate);
            //// 2009/12/14 ①　<<<

            int now = GetIntFromDt(( this._searchCondition == null || this._searchCondition.PriceDate.Equals(DateTime.MinValue) ) ? DateTime.Now : this._searchCondition.PriceDate);
            // 2010/03/19 <<<

            // 2009.02.17 Add >>>
            UsrGoodsInfoRow findUsrGoodsInfoRow = row;

            // 代替検索用の品番、メーカー
            string goodsNo = row.GoodsNo;
            int goodsMakerCd = row.GoodsMakerCd;
            // 2009.02.17 Add <<<
            for (int i = 1; i < 11; i++)
            {
                // 2009.02.17 >>>
                //rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4} = false", // 代替選択UIには提供のみ表示
                //    tableUsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, ret.GoodsNo,
                //    tableUsrSubstParts.ChgSrcMakerCdColumn.ColumnName, ret.GoodsMakerCd, tableUsrSubstParts.OfferKubunColumn.ColumnName);

                rowFilter = String.Format("{0}='{1}' AND {2}={3} AND {4} = false", // 代替選択UIには提供のみ表示
                    tableUsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, goodsNo,
                    tableUsrSubstParts.ChgSrcMakerCdColumn.ColumnName, goodsMakerCd, tableUsrSubstParts.OfferKubunColumn.ColumnName);
                // 2009.02.17 <<<
                substRows = (UsrSubstPartsRow[])tableUsrSubstParts.Select(rowFilter);
                if (substRows.Length > 0 && substRows[0].ApplyStDate <= now && now <= substRows[0].ApplyEdDate)
                {
                    // 2009.02.17 >>>
                    //ret = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRows[0].ChgDestMakerCd, substRows[0].ChgDestGoodsNo);
                    // 代替検索用の品番、メーカーを置き換える
                    goodsNo = substRows[0].ChgDestGoodsNo;
                    goodsMakerCd = substRows[0].ChgDestMakerCd;

                    findUsrGoodsInfoRow = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(substRows[0].ChgDestMakerCd, substRows[0].ChgDestGoodsNo);

                    // 検索できた最後の部品を戻す
                    if (findUsrGoodsInfoRow != null)
                    {
                        ret = findUsrGoodsInfoRow;
                    }
                    // 2009.02.17 <<<
                }
                else
                {
                    break;
                }
            }
            return ret;
        }
        #endregion

        #region [ Private Member ]
        private ArrayList _goodsList = null;
        private PartsSearchUIData _searchCondition = null;
        private SelectUIKind _uiKind = SelectUIKind.None;

        /// <summary>選択部品リスト</summary>
        private Dictionary<int, SelectionInfo> lstSelInf = new Dictionary<int, SelectionInfo>();
        /// <summary>結合元部品</summary>
        private SelectionInfo joinSrcSelInf = null;
        /// <summary>セット親部品</summary>
        private SelectionInfo setSrcSelInf = null;
        /// <summary>代替元部品</summary>
        private SelectionInfo substSrcSelInf = null;
        /// <summary>結合画面表示時参照用</summary>
        private string goodsNoSel = string.Empty;

        /// <summary>優先倉庫リスト</summary>
        private List<string> lstPriorWarehouse;

        /// <summary>検索方法　0:BL検索(優良BL検索・TBO検索も含め)　1:品番検索</summary>
        private int searchMethod;

        /// <summary>品名表示フラグ(0:商品優先 / 1:提供優先)</summary>
        private int _partsNameDspDivCd;
        // 2009.02.10 Add >>>
        /// <summary>価格適用日</summary>
        private DateTime _priceApplyDate;
        // 2009.02.10 Add <<<

        //------------ADD 2009/10/19--------->>>>>
        /// <summary>表示区分プロセス</summary>
        private Int32 _priceSelectDispDiv;
        /// <summary>部品検索結果ﾃﾞｰﾀｸﾗｽ(結合元検索情報)</summary>
        private PartsInfoDataSet _partsInfoDataSetSrcParts;
        /// <summary>得意先コード</summary>
        private Int32 _customerCode;
        /// <summary>得意先掛率グループコードリスト</summary>
        private ArrayList _custRateGrpCodeList;
        /// <summary>標準価格選択区分リスト</summary>
        private List<PriceSelectSet> _priceSelectDivList;
        /// <summary>車両検索結果データクラス</summary>
        private PMKEN01010E _searchCarInfo;
        //------------ADD 2009/10/19---------<<<<<

        // ------------ADD 2009/11/13②--------->>>>>
        /// <summary>TBO初期化フラグ</summary>
        private Int32 _tBOInitializeFlg;
        // ------------ADD 2009/11/13②---------<<<<<

        // 2009/12/10 ②　Add >>>
        /// <summary>売価未設定時区分（0:ゼロ、1:定価）</summary>
        private int _unPrcNonSettingDiv;
        // 2009/12/10 ②　Add <<<

        // 2010/03/24 Add >>>
        /// <summary>BLコード枝番</summary>
        private int _blGoodsDrCode;
        /// <summary>処理モード(0:通常モード 1:自動回答モード)</summary>
        private int _mode;
        // 2010/03/24 Add <<<
        //>>>2011/09/04
        /// <summary>純正部品有効Index(複数自動回答時の商品情報取得時に使用)</summary>
        private int _selectIndex = -1;
        /// <summary>受発注種別(0:通常 1:PCCUOE)</summary>
        private int _acceptOrOrderKind = 0;
        //<<<2011/09/04

        // 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------->>>>>
        /// <summary>提供データ価格情報</summary>
        private PartsInfoDataSet.UsrGoodsPriceDataTable _ofrPriceDataTable = new UsrGoodsPriceDataTable();
        // 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------<<<<<

        #endregion

        #region [ Struct }

        // 2009.02.10 Add >>>
        # region [商品プライマリキー構造体]
        /// <summary>
        /// 商品プライマリキー構造体
        /// </summary>
        public struct GoodsPrimaryKey
        {
            /// <summary>商品コード</summary>
            private string _goodsNo;
            /// <summary>メーカー</summary>
            private int _goodsMakerCd;
            /// <summary>
            /// 商品コード
            /// </summary>
            public string GoodsNo
            {
                get { return _goodsNo; }
                set { _goodsNo = value; }
            }
            /// <summary>
            /// メーカー
            /// </summary>
            public int GoodsMakerCd
            {
                get { return _goodsMakerCd; }
                set { _goodsMakerCd = value; }
            }
            /// <summary>
            /// コンストラクタ
            /// </summary>
            /// <param name="goodsNo">商品コード</param>
            /// <param name="goodsMakerCd">メーカー</param>
            public GoodsPrimaryKey(string goodsNo, int goodsMakerCd)
            {
                _goodsNo = goodsNo;
                _goodsMakerCd = goodsMakerCd;
            }
        }
        # endregion
        // 2009.02.10 Add <<<

        #endregion

        #region [ Delegate ]

        // 2009.02.10 Add >>>
        /// <summary>
        /// 単価取得用デリゲート
        /// </summary>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="unitPriceCalcRet">単価算出結果リスト</param>
        public delegate void CalculateGoodsPriceCallback(List<GoodsUnitData> goodsUnitDataList, out List<UnitPriceCalcRet> unitPriceCalcRet);

        /// <summary>
        /// 価格計算用デリゲート
        /// </summary>
        /// <param name="taxationCode"></param>
        /// <param name="price"></param>
        /// <param name="priceTaxExc"></param>
        /// <param name="priceTaxInc"></param>
        public delegate void CalculatePriceCallback(int taxationCode, double price, out double priceTaxExc, out double priceTaxInc);
        // 2009.02.10 Add <<<

        //---------ADD 2009/10/19------------>>>>>
        /// <summary>
        /// 結合元情報を取得する
        /// </summary>
        /// <param name="mode">モード</param>
        /// <param name="goodsCndt">商品抽出条件クラス</param>
        /// <param name="partsInfoDataSet">部品検索結果データクラス</param>
        /// <param name="goodsUnitDataList">商品連結データクラス</param>
        /// <param name="msg">メッセージ</param>
        /// <remarks>
        /// <br>Note       : 結合元情報を取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public delegate void SearchPartsForSrcPartsCallBack(int mode, GoodsCndtn goodsCndt, out PartsInfoDataSet partsInfoDataSet, out List<GoodsUnitData> goodsUnitDataList, out String msg);

        /// <summary>
        /// 得意先掛率グループコード取得
        /// </summary>
        /// <param name="custRateGrpCodeList">得意先掛率グループコードリスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <remarks>
        /// <br>Note       : 得意先掛率グループコードを取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public delegate void GetCustRateGrpCallBack(ArrayList custRateGrpCodeList, Int32 customerCode, Int32 goodsMakerCode, out Int32 custRateGrpCode);

        /// <summary>
        /// 標準価格選択区分取得
        /// </summary>
        /// <param name="displayDivLis">表示区分リスト</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        /// <param name="priceSelectDiv">標準価格選択区分</param>
        /// <remarks>
        /// <br>Note       : 標準価格選択区分を取得する</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2009.10.15</br>
        /// </remarks>
        public delegate void GetDisplayDivCallBack(List<PriceSelectSet> displayDivLis, Int32 goodsMakerCode, Int32 blGoodsCode, 	Int32 customerCode, Int32 custRateGrpCode, out Int32 priceSelectDiv);

        //---------ADD 2009/10/19------------<<<<<

        // 2010/03/24 Add >>>
        // --- UPD m.suzuki 2011/05/16 ---------->>>>>
        ///// <summary>
        ///// キャンペーン価格反映デリゲート
        ///// </summary>
        ///// <param name="taxationCode"></param>
        ///// <param name="customerCode"></param>
        ///// <param name="goodsMGroup"></param>
        ///// <param name="blGoodsCode"></param>
        ///// <param name="goodsMakerCd"></param>
        ///// <param name="goodsNo"></param>
        ///// <param name="applyDate"></param>
        ///// <param name="price"></param>
        //public delegate void ReflectCampaignCallback(int taxationCode, int customerCode, int goodsMGroup, int blGoodsCode, int goodsMakerCd, string goodsNo, DateTime applyDate, ref double price);
        /// <summary>
        /// キャンペーン価格反映デリゲート
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="blGroupCode">グループコード</param>
        /// <param name="salesCode">販売区分</param>
        /// <param name="applyDate">価格適用日</param>
        /// <param name="price">対象金額</param>
        public delegate void ReflectCampaignCallback( int taxationCode, int customerCode, int blGoodsCode, int goodsMakerCd, string goodsNo, int blGroupCode, int salesCode, DateTime applyDate, ref double price );
        // --- UPD m.suzuki 2011/05/16 ----------<<<<<

        /// <summary>
        /// 自動連携値引き価格反映デリゲート
        /// </summary>
        /// <param name="taxationCode"></param>
        /// <param name="customerCode"></param>
        /// <param name="goodsMGroup"></param>
        /// <param name="blGoodsCode"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="goodsNo"></param>
        /// <param name="price"></param>
        public delegate void ReflectAutoDiscountCallback(int taxationCode, int customerCode, int goodsMGroup, int blGoodsCode, int goodsMakerCd, string goodsNo, ref double price);
        // 2010/03/24 Add <<<
        #endregion

        #region [ Events ]
        // 2009.02.10 Add >>>
        /// <summary>
        /// 単価算出用イベント
        /// </summary>
        public CalculateGoodsPriceCallback CalculateGoodsPrice;

        /// <summary>
        /// 価格計算用イベント
        /// </summary>
        public CalculatePriceCallback CalculatePrice;
        // 2009.02.10 Add <<<

        //------ADD 2009/10/19------------>>>>>
        /// <summary>
        /// 結合元検索用イベント
        /// </summary>
        public SearchPartsForSrcPartsCallBack SearchPartsForSrcParts;

        /// <summary>
        /// 得意先掛率グループ取得用イベント
        /// </summary>
        public GetCustRateGrpCallBack GetCustRateGrp;

        /// <summary>
        /// 標準価格選択区分取得用イベント
        /// </summary>
        public GetDisplayDivCallBack GetDisplayDiv;
        //------ADD 2009/10/19------------<<<<<

        // 2010/03/24 Add >>>
        /// <summary>
        /// キャンペーン価格反映イベント
        /// </summary>
        public ReflectCampaignCallback ReflectCampaign;

        /// <summary>
        /// 自動連携値引き価格反映イベント
        /// </summary>
        public ReflectAutoDiscountCallback ReflectAutoDiscount;
        // 2010/03/24 Add <<<

        #endregion

        #region [ Property ]
        /// <summary>次回表示する選択UIの指定するフラグを取得又は設定します。</summary>
        public SelectUIKind UIKind
        {
            get
            {
                return _uiKind;
            }
            set
            {
                _uiKind = value;
            }
        }

        /// <summary>検索時の検索条件を設定又は取得します</summary>
        public PartsSearchUIData SearchCondition
        {
            get { return _searchCondition; }
            set { _searchCondition = value; }
        }

        /// <summary>選択部品リストを取得します</summary>
        public Dictionary<int, SelectionInfo> ListSelectionInfo
        {
            get
            {
                return lstSelInf;
            }
            set { lstSelInf = value; } // 2012/04/09
        }

        /// <summary>結合元部品</summary>
        public SelectionInfo JoinSrcSelInf
        {
            get { return joinSrcSelInf; }
            set { joinSrcSelInf = value; }
        }

        /// <summary>セット親部品</summary>
        public SelectionInfo SetSrcSelInf
        {
            get { return setSrcSelInf; }
            set { setSrcSelInf = value; }
        }

        /// <summary>代替元部品</summary>
        public SelectionInfo SubstSrcSelInf
        {
            get { return substSrcSelInf; }
            set { substSrcSelInf = value; }
        }

        /// <summary>結合画面表示時参照用</summary>
        public string GoodsNoSel
        {
            get { return goodsNoSel; }
            set { goodsNoSel = value; }
        }

        /// <summary>優先倉庫リスト</summary>
        public List<string> ListPriorWarehouse
        {
            get { return lstPriorWarehouse; }
            set { lstPriorWarehouse = value; }
        }

        ///// <summary>優良設定情報リスト</summary>
        //public Dictionary<PrmSettingKey, PrmSettingUWork> PrmSettingWork
        //{
        //    get { return _drPrmSettingWork; }
        //    set { _drPrmSettingWork = value; }
        //}

        ///// <summary>拠点コード[優良設定用:ログイン拠点]</summary>
        //public string SectionCode
        //{
        //    get { return _sectionCode; }
        //    set { _sectionCode = value; }
        //}

        //------ADD 2009/10/19------->>>>>
        /// <summary>得意先コード</summary>
        public Int32 CustomerCode
        {
            get { return _customerCode; }
            set { _customerCode = value; }
        }

        /// <summary>表示区分プロセス</summary>
        public Int32 PriceSelectDispDiv
        {
            get { return _priceSelectDispDiv; }
            set { _priceSelectDispDiv = value; }
        }

        /// <summary>得意先掛率グループコードリスト</summary>
        public ArrayList CustRateGrpCodeList
        {
            get { return _custRateGrpCodeList; }
            set { _custRateGrpCodeList = value; }
        }

        /// <summary>標準価格選択区分リスト</summary>
        public List<PriceSelectSet> PriceSelectDivList
        {
            get { return _priceSelectDivList; }
            set { _priceSelectDivList = value; }
        }

        /// <summary>車両検索結果データクラス</summary>
        public PMKEN01010E SearchCarInfo
        {
            get { return _searchCarInfo; }
            set { _searchCarInfo = value; }
        }

        /// <summary>部品検索結果ﾃﾞｰﾀｸﾗｽ(結合元検索情報)</summary>
        public PartsInfoDataSet PartsInfoDataSetSrcParts
        {
            get { return _partsInfoDataSetSrcParts; }
            set { _partsInfoDataSetSrcParts = value; }
        }

        //------ADD 2009/11/13②------->>>>>
        /// <summary>TBO初期化フラグ</summary>
        public Int32 TBOInitializeFlg
        {
            get { return _tBOInitializeFlg; }
            set { _tBOInitializeFlg = value; }
        }
        //------ADD 2009/11/13②-------<<<<<

        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------>>>>>
        /// <summary>提供データ価格情報データテーブル</summary>
        public PartsInfoDataSet.UsrGoodsPriceDataTable OfrPriceDataTable
        {
            get { return _ofrPriceDataTable; }
            set { _ofrPriceDataTable = value; }
        }
        // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------<<<<<

        //------ADD 2009/10/19-------<<<<<
        /// <summary>
        /// 選択部品リストに項目追加する。
        /// </summary>
        /// <param name="_lstSelInf">リスト</param>
        /// <param name="key">key</param>
        /// <param name="selInfo">追加する項目</param>
        public void AddSelectionInfo(Dictionary<int, SelectionInfo> _lstSelInf, int key, ref SelectionInfo selInfo)
        {
            if (_lstSelInf.ContainsKey(key))
            {
                selInfo.ListChildGoods = _lstSelInf[key].ListChildGoods;
                selInfo.ListChildGoods2 = _lstSelInf[key].ListChildGoods2;
                selInfo.ListPlrlSubst = _lstSelInf[key].ListPlrlSubst;
                _lstSelInf[key] = selInfo;
                //_lstSelInf[key].Selected = selInfo.Selected;
                //if (selInfo.RowGoods.Equals(_lstSelInf[key].RowGoods) == false) // 代替の場合
                //    selInfo.RowGoods = _lstSelInf[key].RowGoods;
                //selInfo = _lstSelInf[key];
            }
            else
            {
                _lstSelInf.Add(key, selInfo);
            }
        }

        /// <summary>
        /// 選択部品リストから項目削除する。
        /// </summary>
        /// /// <param name="_lstSelInf">リスト</param>
        /// <param name="key">key</param>
        public void RemoveSelectionInfo(Dictionary<int, SelectionInfo> _lstSelInf, int key)
        {
            if (_lstSelInf.ContainsKey(key))
            {
                SelectionInfo selInfo = _lstSelInf[key];
                if (selInfo.ListChildGoods.Count > 0 || selInfo.ListChildGoods2.Count > 0 || selInfo.ListPlrlSubst.Count > 0)
                {
                    selInfo.Selected = false;
                }
                else
                {
                    _lstSelInf.Remove(key);
                }
            }
        }

        /// <summary>検索方法　0:BL検索(優良BL検索・TBO検索も含め)　1:品番検索</summary>
        public int SearchMethod
        {
            get { return searchMethod; }
            set { searchMethod = value; }
        }

        /// <summary>品名表示フラグ(0:商品優先 / 1:提供優先)</summary>
        public int PartsNameDspDivCd
        {
            get { return _partsNameDspDivCd; }
            set { _partsNameDspDivCd = value; }
        }

        // 2009.02.10 Add >>>
        /// <summary>価格適用日</summary>
        public DateTime PriceApplyDate
        {
            get { return _priceApplyDate; }
            set { _priceApplyDate = value; }
        }
        // 2009.02.10 Add <<<

        // 2009/12/10 ②　Add >>>
        /// <summary>売価未設定時区分(0:ゼロ、1:定価)</summary>
        public int UnPrcNonSettingDiv
        {
            get { return _unPrcNonSettingDiv; }
            set { _unPrcNonSettingDiv = value; }
        }
        // 2009/12/10 ②　Add <<<

        // 2010/03/24 Add >>>
        /// <summary>BLコード枝番</summary>
        public int BLGoodsDrCode
        {
            get { return _blGoodsDrCode; }
            set { _blGoodsDrCode = value; }
        }
        /// <summary>処理モード(0:通常モード 1:自動回答モード)</summary>
        public int Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }
        // 2010/03/24 Add <<<

        //>>>2011/09/04 PCCUOE対応
        /// <summary>純正部品有効Index(複数自動回答時の商品情報取得時に使用)</summary>
        public int SelectIndex
        {
            get { return _selectIndex; }
            set { _selectIndex = value; }
        }

        /// <summary>受発注種別</summary>
        public int AcceptOrOrderKind
        {
            get { return _acceptOrOrderKind; }
            set { _acceptOrOrderKind = value; }
        }
        //<<<2011/09/04
        #endregion

        // 2010/03/19 Add >>>
        /// <summary>
        /// コピー処理
        /// </summary>
        /// <returns></returns>
        public new DataSet Copy()
        {
            PartsInfoDataSet ret = (PartsInfoDataSet)base.Copy();

            ret.SearchCarInfo = ( this._searchCarInfo == null ) ? null : (PMKEN01010E)_searchCarInfo.Copy();
            ret.SearchCondition = ( this._searchCondition == null ) ? null : this._searchCondition.Clone();
            ret.CalculateGoodsPrice = ( this.CalculateGoodsPrice == null ) ? null : this.CalculateGoodsPrice;
            ret.CalculatePrice = ( this.CalculatePrice == null ) ? null : this.CalculatePrice;
            ret.SearchPartsForSrcParts = ( this.SearchPartsForSrcParts == null ) ? null : this.SearchPartsForSrcParts;
            ret.GetCustRateGrp = ( this.GetCustRateGrp == null ) ? null : this.GetCustRateGrp;
            ret.GetDisplayDiv = ( this.GetDisplayDiv == null ) ? null : this.GetDisplayDiv;
            // 2010/03/24 Add >>>
            ret.BLGoodsDrCode = this._blGoodsDrCode;
            ret.Mode = this._mode;
            ret.PriceApplyDate = this._priceApplyDate;
            // 2010/03/24 Add <<<
            // ADD 2010/05/17 品名表示対応 ---------->>>>>
            ret.GetBLGoodsInfo = (this.GetBLGoodsInfo == null) ? null : this.GetBLGoodsInfo;
            // ADD 2010/05/17 品名表示対応 ----------<<<<<
            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
            ret.OfrPriceDataTable = (this._ofrPriceDataTable == null) ? null : (PartsInfoDataSet.UsrGoodsPriceDataTable)this._ofrPriceDataTable.Copy();
            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
            return (DataSet)ret;
        }
        // 2010/03/19 Add <<<

        //>>>2012/04/09
        /// <summary>
        /// コピー処理
        /// </summary>
        /// <returns></returns>
        public new DataSet CopyForSCM()
        {
            PartsInfoDataSet ret = (PartsInfoDataSet)base.Copy();

            ret.SearchCarInfo = (this._searchCarInfo == null) ? null : (PMKEN01010E)_searchCarInfo.Copy();
            ret.SearchCondition = (this._searchCondition == null) ? null : this._searchCondition.Clone();
            ret.CalculateGoodsPrice = (this.CalculateGoodsPrice == null) ? null : this.CalculateGoodsPrice;
            ret.CalculatePrice = (this.CalculatePrice == null) ? null : this.CalculatePrice;
            ret.SearchPartsForSrcParts = (this.SearchPartsForSrcParts == null) ? null : this.SearchPartsForSrcParts;
            ret.GetCustRateGrp = (this.GetCustRateGrp == null) ? null : this.GetCustRateGrp;
            ret.GetDisplayDiv = (this.GetDisplayDiv == null) ? null : this.GetDisplayDiv;
            // 2010/03/24 Add >>>
            ret.BLGoodsDrCode = this._blGoodsDrCode;
            ret.Mode = this._mode;
            ret.PriceApplyDate = this._priceApplyDate;
            // 2010/03/24 Add <<<
            // ADD 2010/05/17 品名表示対応 ---------->>>>>
            ret.GetBLGoodsInfo = (this.GetBLGoodsInfo == null) ? null : this.GetBLGoodsInfo;
            // ADD 2010/05/17 品名表示対応 ----------<<<<<

            ret.ListSelectionInfo = (this.lstSelInf == null) ? null : this.lstSelInf; // 選択情報移行
            ret.JoinSrcSelInf = (this.joinSrcSelInf == null) ? null : this.joinSrcSelInf; // 結合情報移行

            // 2012/08/09 ADD 2012/08/15配信 SCM障害№10359 T.Yoshioka -------->>>>>>>>>>>>>>>>>>>>>>
            ret.PartsNameDspDivCd = this.PartsNameDspDivCd;     // 品名表示区分
            // 2012/08/09 ADD 2012/08/15配信 SCM障害№10359 T.Yoshioka --------<<<<<<<<<<<<<<<<<<<<<
            // 2013/03/25 SCM障害№10492対応 -------------------------------------------------->>>>>
            ret.BLCdPrtsNmDspDivCd1 = this.BLCdPrtsNmDspDivCd1;
            ret.BLCdPrtsNmDspDivCd2 = this.BLCdPrtsNmDspDivCd2;
            ret.BLCdPrtsNmDspDivCd3 = this.BLCdPrtsNmDspDivCd3;
            ret.BLCdPrtsNmDspDivCd4 = this.BLCdPrtsNmDspDivCd4;
            ret.GdNoPrtsNmDspDivCd1 = this.GdNoPrtsNmDspDivCd1;
            ret.GdNoPrtsNmDspDivCd2 = this.GdNoPrtsNmDspDivCd2;
            ret.GdNoPrtsNmDspDivCd3 = this.GdNoPrtsNmDspDivCd3;
            ret.GdNoPrtsNmDspDivCd4 = this.GdNoPrtsNmDspDivCd4;
            ret.PrmPrtsNmUseDivCd = this.PrmPrtsNmUseDivCd;
            // 2013/03/25 SCM障害№10492対応 --------------------------------------------------<<<<<

            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
            ret.OfrPriceDataTable = (this._ofrPriceDataTable == null) ? null : (PartsInfoDataSet.UsrGoodsPriceDataTable)this._ofrPriceDataTable.Copy();
            // ADD 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

            return (DataSet)ret;
        }
        //<<<2012/04/09

        #region [ 商品リスト取得処理 ]
        /// <summary>
        /// 商品リスト作成処理[品名は商品優先]
        /// </summary>
        /// <param name="selectedRowOnly">true:選択行のみ／false:全てのデータ</param>
        /// <returns></returns>
        public ArrayList GetGoodsList(bool selectedRowOnly)
        {
            return GetGoodsList(selectedRowOnly, 0);
        }

        // 2010/03/24 Add >>>
        /// <summary>
        /// 商品リスト作成処理[品名は商品優先]
        /// </summary>
        /// <param name="selectedRowOnly">true:選択行のみ／false:全てのデータ</param>
        /// <param name="partsNameDspDivCd"></param>
        /// <returns></returns>
        public ArrayList GetGoodsList( bool selectedRowOnly, int partsNameDspDivCd )
        {
            return GetGoodsList(selectedRowOnly, 0, true);
        }
        // 2010/03/24 Add <<<

        /// <summary>
        /// 商品リスト作成処理
        /// </summary>
        /// <param name="selectedRowOnly">true:選択行のみ／false:全てのデータ</param>
        /// <param name="partsNameDspDivCd">品名表示フラグ(0:商品優先 / 1:提供優先)</param>
        /// <param name="substFlg"></param>
        /// <returns></returns>
        // 2010/03/24 >>>
        //public ArrayList GetGoodsList(bool selectedRowOnly, int partsNameDspDivCd)
        public ArrayList GetGoodsList(bool selectedRowOnly, int partsNameDspDivCd, bool substFlg)
        // 2010/03/24 <<<
        {
            ArrayList retVal = null;

            if (_goodsList == null || _goodsList.Count != tableUsrGoodsInfo.Count) // キャッシュリストがない又はデータセットと数が違う場合はデータセットから
            {                                                                      // リストを作成する。
                retVal = new ArrayList();

                // 2010/03/24 >>>
                //GetArrayList(selectedRowOnly, retVal, partsNameDspDivCd);
                GetArrayList(selectedRowOnly, retVal, partsNameDspDivCd, substFlg);
                // 2010/03/24 <<<
            }
            else // GoodsUnitDataリストからデータセットを作成した場合はキャッシュしたリストから情報を取得する。
            {
                if (selectedRowOnly)
                {
                    retVal = new ArrayList();
                    foreach (SelectionInfo selInfo in lstSelInf.Values)
                    {
                        if (selInfo.Selected)
                        {
                            UsrGoodsInfoRow row = selInfo.RowGoods;
                            for (int j = 0; j < _goodsList.Count; j++)
                            {
                                GoodsUnitData goods = _goodsList[j] as GoodsUnitData;
                                if (goods != null && goods.GoodsNo == row.GoodsNo &&
                                    goods.GoodsMakerCd == row.GoodsMakerCd)
                                {
                                    GoodsUnitData goodsData = goods.Clone() as GoodsUnitData;
                                    goodsData.SelectedWarehouseCode = selInfo.WarehouseCode;
                                    retVal.Add(goodsData);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    //UsrGoodsInfoRow[] rows = tableUsrGoodsInfo.GetSelectedRow(DataViewRowState.Added);
                    //for (int i = 0; i < rows.Length; i++)
                    //{
                    //    for (int j = 0; j < _goodsList.Count; j++)
                    //    {
                    //        GoodsUnitData goods = _goodsList[j] as GoodsUnitData;
                    //        if (goods != null && goods.GoodsNo == rows[i].GoodsNo &&
                    //            goods.GoodsMakerCd == rows[i].GoodsMakerCd)
                    //        {
                    //            GoodsUnitData goodsData = goods.Clone() as GoodsUnitData;
                    //            retVal.Add(goodsData);
                    //            break;
                    //        }
                    //    }
                    //}
                }
                else
                {
                    retVal = (ArrayList)_goodsList.Clone();
                }
            }

            return retVal;
        }

        /// <summary>
        /// データセットからGoodsUnitDataのArrayListを作成する。
        /// </summary>
        /// <param name="selectedRowOnly"></param>
        /// <param name="retVal"></param> 
        /// <param name="partsNameDspDivCd">品名表示フラグ(0:商品優先 / 1:提供優先)</param>
        /// <param name="substFlg"></param>
        // 2010/03/24 >>>
        //private void GetArrayList(bool selectedRowOnly, ArrayList retVal, int partsNameDspDivCd)
        private void GetArrayList(bool selectedRowOnly, ArrayList retVal, int partsNameDspDivCd, bool substFlg)
        // 2010/03/24 <<<
        {
            // ユーザー部品から
            if (selectedRowOnly == false) // 全商品リストの場合
            {
                for (int i = 0; i < tableUsrGoodsInfo.Count; i++)
                {
                    // 2010/03/24 >>>
                    //GoodsUnitData goods = GetGUDFromDR(tableUsrGoodsInfo[i], selectedRowOnly, partsNameDspDivCd);
                    GoodsUnitData goods = GetGUDFromDR(tableUsrGoodsInfo[i], selectedRowOnly, partsNameDspDivCd, substFlg);
                    // 2010/03/24 <<<
                    retVal.Add(goods);
                    //string query;
                    //PartsInfoRow[] rows = null;
                    //if (tableUsrGoodsInfo[i].OfferKubun == 1 || tableUsrGoodsInfo[i].OfferKubun == 3) // 純正部品の場合
                    //{
                    //    // 年式違いの品番・メーカ同一の純正部品に対応するため下記の処理を行います。
                    //    query = string.Format("{0}={1} AND {2}='{3}'",
                    //        tablePartsInfo.CatalogPartsMakerCdColumn.ColumnName, tableUsrGoodsInfo[i].GoodsMakerCd,
                    //        tablePartsInfo.ClgPrtsNoWithHyphenColumn.ColumnName, tableUsrGoodsInfo[i].GoodsNo);
                    //    rows = (PartsInfoRow[])tablePartsInfo.Select(query);
                    //    if (rows == null || rows.Length == 0)
                    //    {
                    //        query = string.Format("{0}=True", tablePartsInfo.SelectionStateColumn.ColumnName);
                    //        rows = (PartsInfoRow[])tablePartsInfo.Select(query);
                    //    }

                    //    for (int j = 1; j < rows.Length; j++)
                    //    {
                    //        if (selectedRowOnly == false || rows[j].SelectionState == true)
                    //        {
                    //            goods = GetGUDFromDR(tableUsrGoodsInfo[i], selectedRowOnly);
                    //            retVal.Add(goods);
                    //        }
                    //    }
                    //}

                }
            }
            else
            {
                // 2010/03/24 >>>
                //GetSelectedArrayList(lstSelInf, retVal, partsNameDspDivCd);
                GetSelectedArrayList(lstSelInf, retVal, partsNameDspDivCd, substFlg);
                // 2010/03/24 <<<
            }
        }

        // 2010/03/24 >>>
        //private void GetSelectedArrayList(Dictionary<int, SelectionInfo> lstSelInf, ArrayList retLst, int partsNameDspDivCd)
        private void GetSelectedArrayList(Dictionary<int, SelectionInfo> lstSelInf, ArrayList retLst, int partsNameDspDivCd, bool substFlg)
        // 2010/03/24 <<<
        {
            foreach (SelectionInfo selInfo in lstSelInf.Values)
            {
                if (selInfo.Selected)
                {
                    // 2009/10/27 >>>
                    //// 2009/10/23 >>>
                    ////GoodsUnitData goods = GetGUDFromDR(selInfo.RowGoods, true, partsNameDspDivCd);
                    //GoodsUnitData goods = GetGUDFromDR(selInfo.RowGoods, true, partsNameDspDivCd, selInfo.Depth, false);
                    //// 2009/10/23 <<<

                    UsrGoodsInfoRow joinSrcRow = ( ( selInfo.Depth == 1 ) ) ? joinSrcSelInf.RowGoods : null;

                    // 2010/03/24 >>>
                    //GoodsUnitData goods = GetGUDFromDR(selInfo.RowGoods, true, partsNameDspDivCd, selInfo.Depth, false, joinSrcRow);
                    GoodsUnitData goods = GetGUDFromDR(selInfo.RowGoods, true, partsNameDspDivCd, selInfo.Depth, false, joinSrcRow, substFlg);
                    // 2010/03/24 <<<
                    // 2009/10/27 <<<
                    goods.SelectedWarehouseCode = selInfo.WarehouseCode;
                    retLst.Add(goods);
                }
                foreach (SelectionInfo selInfoSubst in selInfo.ListPlrlSubst)
                {
                    if (selInfoSubst.Selected)
                    {
                        // 2009/10/27 >>>
                        //// 2009/10/23 >>>
                        ////GoodsUnitData goods = GetGUDFromDR(selInfoSubst.RowGoods, true, partsNameDspDivCd);
                        //GoodsUnitData goods = GetGUDFromDR(selInfoSubst.RowGoods, true, partsNameDspDivCd, selInfoSubst.Depth, true);
                        //// 2009/10/23 <<<

                        // 2010/03/24 >>>
                        //GoodsUnitData goods = GetGUDFromDR(selInfoSubst.RowGoods, true, partsNameDspDivCd, selInfoSubst.Depth, true, null);
                        GoodsUnitData goods = GetGUDFromDR(selInfoSubst.RowGoods, true, partsNameDspDivCd, selInfoSubst.Depth, true, null, substFlg);
                        // 2010/03/24 <<<
                        // 2009/10/27 <<<
                        goods.SelectedWarehouseCode = selInfoSubst.WarehouseCode;
                        retLst.Add(goods);
                    }
                }
                // 2010/03/24 >>>
                //GetSelectedArrayList(selInfo.ListChildGoods, retLst, partsNameDspDivCd);
                //GetSelectedArrayList(selInfo.ListChildGoods2, retLst, partsNameDspDivCd);

                GetSelectedArrayList(selInfo.ListChildGoods, retLst, partsNameDspDivCd, substFlg);
                GetSelectedArrayList(selInfo.ListChildGoods2, retLst, partsNameDspDivCd, substFlg);
                // 2010/03/24 <<<
            }
        }

        // --- ADD 2014/01/15 T.Miyamoto ------------------------------>>>>>
        /// <summary>
        /// 商品リスト作成処理[品名は商品優先]
        /// </summary>
        /// <param name="selectedRowOnly">true:選択行のみ／false:全てのデータ</param>
        /// <returns></returns>
        public ArrayList GetGoodsListWithSrc(bool selectedRowOnly)
        {
            return GetGoodsListWithSrc(selectedRowOnly, 0);
        }

        /// <summary>
        /// 商品リスト作成処理[品名は商品優先]
        /// </summary>
        /// <param name="selectedRowOnly">true:選択行のみ／false:全てのデータ</param>
        /// <param name="partsNameDspDivCd"></param>
        /// <returns></returns>
        public ArrayList GetGoodsListWithSrc( bool selectedRowOnly, int partsNameDspDivCd )
        {
            return GetGoodsListWithSrc(selectedRowOnly, 0, true);
        }

        /// <summary>
        /// 商品リスト作成処理
        /// </summary>
        /// <param name="selectedRowOnly">true:選択行のみ／false:全てのデータ</param>
        /// <param name="partsNameDspDivCd">品名表示フラグ(0:商品優先 / 1:提供優先)</param>
        /// <param name="substFlg"></param>
        /// <returns></returns>
        public ArrayList GetGoodsListWithSrc( bool selectedRowOnly, int partsNameDspDivCd, bool substFlg )
        {
            ArrayList retVal = null;

            if (_goodsList == null || _goodsList.Count != tableUsrGoodsInfo.Count) // キャッシュリストがない又はデータセットと数が違う場合はデータセットから
            {                                                                      // リストを作成する。
                retVal = new ArrayList();

                GetArrayListWithSrc(selectedRowOnly, retVal, partsNameDspDivCd, substFlg);
            }
            else // GoodsUnitDataリストからデータセットを作成した場合はキャッシュしたリストから情報を取得する。
            {
                if (selectedRowOnly)
                {
                    retVal = new ArrayList();
                    foreach (SelectionInfo selInfo in lstSelInf.Values)
                    {
                        if (selInfo.Selected)
                        {
                            UsrGoodsInfoRow row = selInfo.RowGoods;
                            for (int j = 0; j < _goodsList.Count; j++)
                            {
                                GoodsUnitData goods = _goodsList[j] as GoodsUnitData;
                                if (goods != null && goods.GoodsNo == row.GoodsNo &&
                                    goods.GoodsMakerCd == row.GoodsMakerCd)
                                {
                                    GoodsUnitData goodsData = goods.Clone() as GoodsUnitData;
                                    goodsData.SelectedWarehouseCode = selInfo.WarehouseCode;
                                    retVal.Add(goodsData);
                                    break;
                                }
                            }
                            break;
                        }
                    }
                }
                else
                {
                    retVal = (ArrayList)_goodsList.Clone();
                }
            }
            return retVal;
        }

        /// <summary>
        /// データセットからGoodsUnitDataのArrayListを作成する。
        /// </summary>
        /// <param name="selectedRowOnly"></param>
        /// <param name="retVal"></param> 
        /// <param name="partsNameDspDivCd">品名表示フラグ(0:商品優先 / 1:提供優先)</param>
        /// <param name="substFlg"></param>
        private void GetArrayListWithSrc( bool selectedRowOnly, ArrayList retVal, int partsNameDspDivCd, bool substFlg )
        {
            // ユーザー部品から
            if (selectedRowOnly == false) // 全商品リストの場合
            {
                for (int i = 0; i < tableUsrGoodsInfo.Count; i++)
                {
                    GoodsUnitData goods = GetGUDFromDR(tableUsrGoodsInfo[i], selectedRowOnly, partsNameDspDivCd, substFlg);
                    retVal.Add(goods);
                }
            }
            else
            {
                GoodsPrimaryKey JoinSrcKey = new GoodsPrimaryKey();
                GetSelectedArrayListWithSrc(lstSelInf, retVal, partsNameDspDivCd, substFlg, JoinSrcKey);
            }
        }

        private void GetSelectedArrayListWithSrc(Dictionary<int, SelectionInfo> lstSelInf, ArrayList retLst, int partsNameDspDivCd, bool substFlg, GoodsPrimaryKey JoinSrcKey)
        {
            foreach (SelectionInfo selInfo in lstSelInf.Values)
            {
                if (selInfo.Depth == 0)
                {
                    // 結合元情報を保持
                    JoinSrcKey.GoodsMakerCd = selInfo.RowGoods.GoodsMakerCd;
                    JoinSrcKey.GoodsNo = selInfo.RowGoods.GoodsNo;
                }

                if (selInfo.Selected)
                {
                    UsrGoodsInfoRow joinSrcRow = ((selInfo.Depth == 1)) ? joinSrcSelInf.RowGoods : null;

                    GoodsUnitData goods = GetGUDFromDR(selInfo.RowGoods, true, partsNameDspDivCd, selInfo.Depth, false, joinSrcRow, substFlg);

                    goods.SelectedWarehouseCode = selInfo.WarehouseCode;

                    // --- UPD 2014/01/29 T.Miyamoto ------------------------------>>>>>
                    //if (selInfo.Depth == 1)
                    if (selInfo.Depth != 0)
                    // --- UPD 2014/01/29 T.Miyamoto ------------------------------<<<<<
                    {
                        // 結合元情報をセット
                        goods.JoinSourceMakerCode = JoinSrcKey.GoodsMakerCd;
                        goods.JoinSrcPartsNoWithH = JoinSrcKey.GoodsNo;
                    }
                    retLst.Add(goods);
                }
                foreach (SelectionInfo selInfoSubst in selInfo.ListPlrlSubst)
                {
                    if (selInfoSubst.Selected)
                    {
                        GoodsUnitData goods = GetGUDFromDR(selInfoSubst.RowGoods, true, partsNameDspDivCd, selInfoSubst.Depth, true, null, substFlg);

                        goods.SelectedWarehouseCode = selInfoSubst.WarehouseCode;
                        retLst.Add(goods);
                    }
                }
                GetSelectedArrayListWithSrc(selInfo.ListChildGoods, retLst, partsNameDspDivCd, substFlg, JoinSrcKey);
                GetSelectedArrayListWithSrc(selInfo.ListChildGoods2, retLst, partsNameDspDivCd, substFlg, JoinSrcKey);
            }
        }
        // --- ADD 2014/01/15 T.Miyamoto ------------------------------<<<<<

        // 2009.02.10 Add >>>
        /// <summary>
        /// 商品リスト作成処理
        /// </summary>
        /// <param name="primePartsRetList"></param>
        /// <returns></returns>
        public List<GoodsUnitData> GetGoodsList(List<PrimePartsRet> primePartsRetList)
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            foreach (PrimePartsRet primePartsRet in primePartsRetList)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(primePartsRet.GoodsMakerCd, primePartsRet.GoodsNo);
                // 2009/10/27 >>>
                //GoodsUnitData goods = GetGUDFromDR(row, false, 0);
                PartsInfoDataSet.UsrGoodsInfoRow joinSrcRow = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(primePartsRet.JoinSourceMakerCode, primePartsRet.JoinSourPartsNoWithH);

                // 2010/03/24 >>>
                //GoodsUnitData goods = GetGUDFromDR(row, false, PartsNameDspDivCd, 1, false, joinSrcRow);
                GoodsUnitData goods = GetGUDFromDR(row, false, PartsNameDspDivCd, 1, false, joinSrcRow, true);
                // 2010/03/24 <<<
                // 2009/10/27 <<<

                goodsUnitDataList.Add(goods.Clone());
            }

            return goodsUnitDataList;
        }
        // 2009.02.10 Add <<<

        /// <summary>
        /// 商品リスト作成処理
        /// </summary>
        /// <remarks>選択UIの選択状態関係なく、商品区分によって商品情報をリストに設定し返します。</remarks>
        /// <param name="goodsKind">[商品区分] 0:全て　1:親　2:結合先　4:セット子　8:代替先　16:代替先(互換)</param>
        /// <returns></returns>
        public List<GoodsUnitData> GetGoodsList(int goodsKind)
        {
            List<GoodsUnitData> ret = new List<GoodsUnitData>();

            // ユーザー部品から
            for (int i = 0; i < tableUsrGoodsInfo.Count; i++)
            {
                if (goodsKind == 0 ||
                    (goodsKind != 0 && (tableUsrGoodsInfo[i].GoodsKind & goodsKind) == goodsKind))
                {
                    GoodsUnitData goods = GetGUDFromDR(tableUsrGoodsInfo[i]);
                    ret.Add(goods);
                }
            }

            return ret;
        }

        /// <summary>
        /// 商品リスト作成処理
        /// </summary>
        /// <remarks>選択UIの選択状態関係なく、商品区分によって商品情報をリストに設定し返します。</remarks>
        /// <param name="goodsKind">[商品区分] 0:全て　1:親　2:結合先　4:セット子　8:代替先　16:代替先(互換)</param>
        /// <param name="makerCode">結合・セット・代替の元部品のメーカコード(商品区分1の場合は無視します)</param>
        /// <param name="goodsNo">結合・セット・代替の元部品の品番(商品区分0, 1の場合は無視します)</param>
        /// <returns></returns>
        public List<GoodsUnitData> GetGoodsList(int goodsKind, int makerCode, string goodsNo)
        {
            if (goodsKind == 0 || goodsKind == 1)
                return GetGoodsList(goodsKind);

            List<GoodsUnitData> ret = new List<GoodsUnitData>();
            string query = string.Empty;

            switch (goodsKind)
            {
                case 2:
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        tableUsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, makerCode,
                        tableUsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, goodsNo);
                    // 2009.02.17 >>>
                    //UsrJoinPartsRow[] rowJoins = (UsrJoinPartsRow[])tableUsrJoinParts.Select(query);
                    // 表示順位でソートして取得する
                    UsrJoinPartsRow[] rowJoins = (UsrJoinPartsRow[])tableUsrJoinParts.Select(query, tableUsrJoinParts.JoinDispOrderColumn.ColumnName);
                    // ユーザー登録分は100件までなので、提供分を再付番
                    int primeOrder = 101;
                    // 2009.02.17 <<<
                    
                    for (int i = 0; i < rowJoins.Length; i++)
                    {
                        UsrGoodsInfoRow rowGoods = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                            rowJoins[i].JoinDestMakerCd, rowJoins[i].JoinDestPartsNo);
                        if (rowGoods != null)
                        {
                            GoodsUnitData goods = GetGUDFromDR(rowGoods);
                            // 2009.02.17 Add >>>
                            // -- UPD 2009/10/30 ------------------------------------->>>
                            //if (rowJoins[i].JoinOfferDate != DateTime.MinValue)
                            if (rowJoins[i].JoinOfferDate != DateTime.MinValue && rowJoins[i].JoinDispOrder >= 100)
                            // -- UPD 2009/10/30 -------------------------------------<<<
                            {
                                goods.JoinDispOrder = primeOrder++;
                            }
                            // 2009.02.17 Add <<<
                            ret.Add(goods);
                        }
                    }
                    break;
                case 4:
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        tableUsrSetParts.ParentGoodsMakerCdColumn.ColumnName, makerCode,
                        tableUsrSetParts.ParentGoodsNoColumn.ColumnName, goodsNo);
                    UsrSetPartsRow[] rowSet = (UsrSetPartsRow[])tableUsrSetParts.Select(query);
                    for (int i = 0; i < rowSet.Length; i++)
                    {
                        UsrGoodsInfoRow rowGoods = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                            rowSet[i].SubGoodsMakerCd, rowSet[i].SubGoodsNo);
                        if (rowGoods != null)
                        {
                            GoodsUnitData goods = GetGUDFromDR(rowGoods);
                            ret.Add(goods);
                        }
                    }
                    break;
                case 8:
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        tableUsrSubstParts.ChgSrcMakerCdColumn.ColumnName, makerCode,
                        tableUsrSubstParts.ChgSrcGoodsNoColumn.ColumnName, goodsNo);
                    UsrSubstPartsRow[] rowSubst = (UsrSubstPartsRow[])tableUsrSubstParts.Select(query);
                    for (int i = 0; i < rowSubst.Length; i++)
                    {
                        UsrGoodsInfoRow rowGoods = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                            rowSubst[i].ChgDestMakerCd, rowSubst[i].ChgDestGoodsNo);
                        if (rowGoods != null)
                        {
                            GoodsUnitData goods = GetGUDFromDR(rowGoods);
                            ret.Add(goods);
                        }
                    }
                    break;
                case 16:
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        tableDSubstPartsInfo.CatalogPartsMakerCdColumn.ColumnName, makerCode,
                        tableDSubstPartsInfo.NewPartsNoWithHyphenColumn.ColumnName, goodsNo);
                    DSubstPartsInfoRow[] rowDSubst = (DSubstPartsInfoRow[])tableDSubstPartsInfo.Select(query);
                    for (int i = 0; i < rowDSubst.Length; i++)
                    {
                        UsrGoodsInfoRow rowGoods = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(
                            rowDSubst[i].CatalogPartsMakerCd, rowDSubst[i].OldPartsNoWithHyphen);
                        if (rowGoods != null)
                        {
                            GoodsUnitData goods = GetGUDFromDR(rowGoods);
                            ret.Add(goods);
                        }
                    }
                    break;
            }

            return ret;
        }

        /// <summary>
        /// 指定部品の結合先部品の情報を取得します。
        /// </summary>
        /// <param name="makerCd">結合元のメーカーコード</param>
        /// <param name="ctlgPartsNo">結合元の品番[カタログ品番]</param>
        /// <param name="newPartsNo">結合元の品番[最新品番](カタログ品番と同じ場合でも設定すること)</param>
        /// <param name="lstJoinDestParts">結合先部品の部品情報リスト</param>
        /// <returns>指定部品の結合先部品の結合情報リスト</returns>
        public UsrJoinPartsRow[] GetJoinDestParts(int makerCd, string ctlgPartsNo, string newPartsNo, out List<GoodsUnitData> lstJoinDestParts)
        {
            lstJoinDestParts = new List<GoodsUnitData>();
            string filter = string.Empty;
            if (ctlgPartsNo == newPartsNo)
                filter = string.Format("{0} = {1} AND {2} = '{3}'",
                     tableUsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, makerCd,
                     tableUsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, ctlgPartsNo);
            else
                filter = string.Format("{0} = {1} AND ({2} = '{3}' OR {4} = '{5}')",
                     tableUsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, makerCd,
                     tableUsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, ctlgPartsNo,
                     tableUsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, newPartsNo);
            UsrJoinPartsRow[] ret = (UsrJoinPartsRow[])tableUsrJoinParts.Select(filter, tableUsrJoinParts.JoinDispOrderColumn.ColumnName);
            for (int i = 0; i < ret.Length; i++)
            {
                UsrGoodsInfoRow rowUsrGoodsInfo = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(ret[i].JoinDestMakerCd, ret[i].JoinDestPartsNo);
                if (rowUsrGoodsInfo != null)
                {
                    GoodsUnitData goods = GetGUDFromDR(rowUsrGoodsInfo);
                    lstJoinDestParts.Add(goods);
                }
            }
            return ret;
        }
        // --- ADD m.suzuki 2011/01/14 ---------->>>>>
        /// <summary>
        /// 部品選択UIから選んだ純正部品の情報。
        /// </summary>
        /// <returns></returns>
        public List<GenuinePartsRet> GetSelectedGenuineParts()
        {
            return GetSelectedGenuineParts( false );
        }
        // --- ADD m.suzuki 2011/01/14 ----------<<<<<

        /// <summary>
        /// 部品選択UIから選んだ純正部品の情報。
        /// </summary>
        /// <returns></returns>
        // --- UPD m.suzuki 2011/01/14 ---------->>>>>
        //public List<GenuinePartsRet> GetSelectedGenuineParts()
        public List<GenuinePartsRet> GetSelectedGenuineParts( bool containsUserGoods )
        // --- UPD m.suzuki 2011/01/14 ----------<<<<<
        {
            List<GenuinePartsRet> retVal = new List<GenuinePartsRet>();

            int substFlg = SearchCondition.SearchCntSetWork.PrmSubstCondDivCd; // 0:代替しない  1:代替する（在庫判定あり） 2:代替する（在庫判定なし）
            int userSubstFlg = SearchCondition.SearchCntSetWork.SubstApplyDivCd;
            //UsrGoodsInfoRow[] usrRows = tableUsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
            //for (int i = 0; i < usrRows.Length; i++)
            foreach (SelectionInfo selInfo in lstSelInf.Values)
            {
                UsrGoodsInfoRow row = selInfo.RowGoods;
                // --- UPD m.suzuki 2011/01/14 ---------->>>>>
                //if (selInfo.Selected == false || row.OfferKubun % 2 == 0) //ユーザー登録品、優良部品（提供区分が偶数0,2,4）は処理しない
                //    continue;
                // ユーザー登録品、優良部品（提供区分が偶数0,2,4）を含めるかフラグで判断する。
                if ( selInfo.Selected == false || (row.OfferKubun % 2 == 0 && !containsUserGoods) )
                {   
                    continue;
                }
                // --- UPD m.suzuki 2011/01/14 ----------<<<<<
                GenuinePartsRet work = new GenuinePartsRet();

                UsrGoodsInfoRow rowNewPartsNo = tableUsrGoodsInfo.GetNewPartsNoGoodsIfAny(row);
                UsrGoodsInfoRow rowToProcess = null; // 設定する情報を持つ行
                work.BLGoodsCode = row.BlGoodsCode;

                if (row.NewGoodsNo == string.Empty) // 代替しなかった場合
                {
                    if (rowNewPartsNo == null)  // 最新品番とカタログ品番が同じ
                    {
                        work.GoodsNo = row.GoodsNo;
                        work.JoinSrcPartsNo = row.JoinSrcPrtsNo;
                        work.CtlgPartsNo = row.GoodsNo;
                        work.NewPartsNo = row.GoodsNo;

                        rowToProcess = row; //　カタログ品番情報
                    }
                    else                        // 最新品番とカタログ品番が異なる
                    {
                        work.GoodsNo = rowNewPartsNo.GoodsNo;
                        work.JoinSrcPartsNo = row.GoodsNo;
                        work.CtlgPartsNo = row.GoodsNo;
                        work.NewPartsNo = rowNewPartsNo.GoodsNo;

                        rowToProcess = rowNewPartsNo; //　最新品番情報
                    }
                }
                else // 代替した場合
                {
                    work.GoodsNo = row.NewGoodsNo;
                    work.JoinSrcPartsNo = row.JoinSrcPrtsNo;
                    work.CtlgPartsNo = row.GoodsNo;
                    if (rowNewPartsNo != null)
                        work.NewPartsNo = rowNewPartsNo.GoodsNo;
                    else
                        work.NewPartsNo = row.NewGoodsNo;

                    UsrGoodsInfoRow rowSubst = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd, row.NewGoodsNo);
                    if (rowSubst != null)
                    {
                        rowToProcess = rowSubst; //　代替した品番情報
                    }
                    else // あってはいけないケースだが、DBの整合性による問題を防ぐためこの処理をいれておく。
                    {
                        rowToProcess = row;
                    }
                }
                work.GoodsName = rowToProcess.GoodsName;
                work.GoodsNameKana = rowToProcess.GoodsNameKana;
                work.GoodsMakerCd = rowToProcess.GoodsMakerCd;
                work.GoodsMakerNm = rowToProcess.GoodsMakerNm;
                work.CreateDateTime = new DateTime(rowToProcess.CreateDateTime);
                work.DisplayOrder = rowToProcess.DisplayOrder;
                work.EnterpriseCode = rowToProcess.EnterpriseCode;
                work.EnterpriseGanreCode = rowToProcess.EnterpriseGanreCode;
                if (rowToProcess.IsFileHeaderGuidNull() == false)
                    work.FileHeaderGuid = rowToProcess.FileHeaderGuid;
                work.GoodsKindCode = rowToProcess.GoodsKindCode;
                work.GoodsMGroup = rowToProcess.GoodsMGroup;
                work.GoodsNote1 = rowToProcess.GoodsNote1;
                work.GoodsNote2 = rowToProcess.GoodsNote2;
                work.GoodsRateRank = rowToProcess.GoodsRateRank;
                work.GoodsSpecialNote = rowToProcess.GoodsSpecialNote;
                work.Jan = rowToProcess.Jan;
                work.LogicalDeleteCode = rowToProcess.LogicalDeleteCode;
                work.OfferDate = rowToProcess.OfferDate;
                work.TaxationDivCd = rowToProcess.TaxationDivCd;
                work.UpdAssemblyId1 = rowToProcess.UpdAssemblyId1;
                work.UpdAssemblyId2 = rowToProcess.UpdAssemblyId2;
                work.UpdateDate = rowToProcess.UpdateDate;
                work.UpdateDateTime = new DateTime(rowToProcess.UpdateDateTime);
                work.UpdEmployeeCode = rowToProcess.UpdEmployeeCode;

                PartsInfoRow[] rowOrg = (PartsInfoRow[])rowToProcess.GetChildRows("UsrGoodsInfo_PartsInfo");
                if (rowOrg.Length > 0)
                {
                    work.PartsQty = rowOrg[0].PartsQty;
                    work.PartsOpNm = rowOrg[0].PartsOpNm;
                    work.StandardName = rowOrg[0].StandardName;
                }

                PartsInfoRow rowCtlg = tablePartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(work.GoodsMakerCd, work.CtlgPartsNo);
                if (rowCtlg != null)
                {
                    work.CtlgPartsOpNm = rowCtlg.PartsOpNm;
                }

                #region [ 純正部品の価格・在庫情報設定 ]
                // 価格情報取得
                string query = string.Format("{0} = {1} AND {2} = '{3}'",
                    tableUsrGoodsPrice.GoodsMakerCdColumn.ColumnName, work.GoodsMakerCd,
                    tableUsrGoodsPrice.GoodsNoColumn.ColumnName, work.GoodsNo);
                UsrGoodsPriceRow[] rowPrice = (UsrGoodsPriceRow[])tableUsrGoodsPrice.Select(query);
                for (int j = 0; j < rowPrice.Length; j++)
                {
                    GoodsPrice prc = new GoodsPrice();
                    prc.CreateDateTime = new DateTime(rowPrice[j].CreateDateTime);
                    prc.UpdateDateTime = new DateTime(rowPrice[j].UpdateDateTime);
                    prc.EnterpriseCode = rowPrice[j].EnterpriseCode;
                    if (rowPrice[j].IsFileHeaderGuidNull() == false)
                        prc.FileHeaderGuid = rowPrice[j].FileHeaderGuid;
                    prc.UpdAssemblyId1 = rowPrice[j].UpdAssemblyId1;
                    prc.UpdAssemblyId2 = rowPrice[j].UpdAssemblyId2;
                    prc.UpdEmployeeCode = rowPrice[j].UpdEmployeeCode;
                    prc.LogicalDeleteCode = rowPrice[j].LogicalDeleteCode;

                    prc.GoodsMakerCd = rowPrice[j].GoodsMakerCd;
                    prc.GoodsNo = rowPrice[j].GoodsNo;
                    prc.ListPrice = rowPrice[j].ListPrice;
                    prc.OpenPriceDiv = rowPrice[j].OpenPriceDiv;
                    prc.PriceStartDate = rowPrice[j].PriceStartDate;
                    prc.SalesUnitCost = rowPrice[j].SalesUnitCost;
                    prc.StockRate = rowPrice[j].StockRate;
                    if (rowPrice[j].IsUpdateDateNull() == false)
                    {
                        prc.UpdateDate = rowPrice[j].UpdateDate;
                    }
                    else
                    {
                        prc.UpdateDate = DateTime.MinValue;
                    }
                    prc.OfferDate = rowPrice[j].OfferDate;
                    work.GoodsPriceList.Add(prc);
                }

                // 在庫情報取得
                query = string.Format("{0} = {1} AND {2} = '{3}'",
                    tableStock.GoodsMakerCdColumn.ColumnName, work.GoodsMakerCd,
                    tableStock.GoodsNoColumn.ColumnName, work.GoodsNo);
                StockRow[] stockRow = (StockRow[])tableStock.Select(query);
                for (int j = 0; j < stockRow.Length; j++)
                {
                    work.StockList.Add(GetStockFromStockRow(stockRow[j]));
                }
                #endregion

                #region [ 純正部品の結合部品情報設定 ]
                // 結合情報取得
                List<string> lst = new List<string>();
                query = string.Format("{0} = {1} AND {2} = '{3}'",
                     tableUsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, work.GoodsMakerCd,
                     tableUsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, work.JoinSrcPartsNo);
                UsrJoinPartsRow[] retJoin = (UsrJoinPartsRow[])tableUsrJoinParts.Select(query, tableUsrJoinParts.JoinDispOrderColumn.ColumnName);
                for (int j = 0; j < retJoin.Length; j++)
                {
                    UsrGoodsInfoRow rowUsrGoodsInfo = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(retJoin[j].JoinDestMakerCd, retJoin[j].JoinDestPartsNo);
                    if (rowUsrGoodsInfo != null)
                    {
                        if (substFlg != 1 || PartsStockCheck(retJoin[j].JoinDestPartsNo, retJoin[j].JoinDestMakerCd) == false)
                        {       // [代替条件：在庫判定有　且つ　旧品在庫ありの場合]以外は最新品番に代替する。
                            PartsInfoDataSet.UsrGoodsInfoRow rowNew = GetOfrSubst(rowUsrGoodsInfo);
                            if (userSubstFlg != 0) // ユーザー代替しない以外の場合
                            {
                                PartsInfoDataSet.UsrGoodsInfoRow rowSubst = GetUsrSubst(rowUsrGoodsInfo);
                                if (rowSubst.Equals(rowUsrGoodsInfo)) // 旧優良品に対しユーザー代替がない
                                {
                                    if (rowNew.Equals(rowUsrGoodsInfo) == false) // 最新品番がある場合
                                    {
                                        rowSubst = GetUsrSubst(rowNew);
                                        if (rowSubst.Equals(rowNew)) // 最新品に対しユーザー代替なし
                                        {
                                            rowUsrGoodsInfo = rowNew;
                                        }
                                        else // 最新品に対しユーザー代替あり
                                        {
                                            rowUsrGoodsInfo = rowSubst;
                                        }
                                    }
                                }
                                else // 旧優良品に対しユーザー代替がある場合
                                {
                                    rowUsrGoodsInfo = rowSubst;
                                }
                            }
                            else // ユーザー代替しないの場合最新品番に代替する。
                            {
                                rowUsrGoodsInfo = rowNew;
                            }
                            //row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                        }
                        /* ------------DEL START wangf 2012/04/25 FOR Redmine#29146--------->>>>
                        lst.Add(retJoin[j].JoinDestPartsNo);
                        PrimePartsRet primePartsWork = SetJoinInfo(retJoin[j], rowUsrGoodsInfo);

                        work.PrimePartsList.Add(primePartsWork);
                        // ------------DEL END wangf 2012/04/25 FOR Redmine#29146---------<<<<<*/
                        // ------------ADD START wangf 2012/04/25 FOR Redmine#29146--------->>>>
                        if (lst.Contains(retJoin[j].JoinDestPartsNo + "," + retJoin[j].JoinDestMakerCd) == false)
                        {
                            lst.Add(retJoin[j].JoinDestPartsNo + "," + retJoin[j].JoinDestMakerCd);
                            PrimePartsRet primePartsWork = SetJoinInfo(retJoin[j], rowUsrGoodsInfo);
                            work.PrimePartsList.Add(primePartsWork);
                        }
                        // ------------ADD END wangf 2012/04/25 FOR Redmine#29146---------<<<<<
                    }
                }
                if (work.JoinSrcPartsNo != work.NewPartsNo) // 結合元品番と最新品番が違うときのみ下記の処理を行う。
                {
                    query = string.Format("{0} = {1} AND {2} = '{3}'",
                         tableUsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, work.GoodsMakerCd,
                         tableUsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, work.NewPartsNo);
                    retJoin = (UsrJoinPartsRow[])tableUsrJoinParts.Select(query, tableUsrJoinParts.JoinDispOrderColumn.ColumnName);
                    for (int j = 0; j < retJoin.Length; j++)
                    {
                        UsrGoodsInfoRow rowUsrGoodsInfo = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(retJoin[j].JoinDestMakerCd, retJoin[j].JoinDestPartsNo);
                        if (rowUsrGoodsInfo != null)
                        {
                            if (substFlg != 1 || PartsStockCheck(retJoin[j].JoinDestPartsNo, retJoin[j].JoinDestMakerCd) == false)
                            {       // [代替条件：在庫判定有　且つ　旧品在庫ありの場合]以外は最新品番に代替する。
                                PartsInfoDataSet.UsrGoodsInfoRow rowNew = GetOfrSubst(rowUsrGoodsInfo);
                                if (userSubstFlg != 0) // ユーザー代替しない以外の場合
                                {
                                    PartsInfoDataSet.UsrGoodsInfoRow rowSubst = GetUsrSubst(rowUsrGoodsInfo);
                                    if (rowSubst.Equals(rowUsrGoodsInfo)) // 旧優良品に対しユーザー代替がない
                                    {
                                        if (rowNew.Equals(rowUsrGoodsInfo) == false) // 最新品番がある場合
                                        {
                                            rowSubst = GetUsrSubst(rowNew);
                                            if (rowSubst.Equals(rowNew)) // 最新品に対しユーザー代替なし
                                            {
                                                rowUsrGoodsInfo = rowNew;
                                            }
                                            else // 最新品に対しユーザー代替あり
                                            {
                                                rowUsrGoodsInfo = rowSubst;
                                            }
                                        }
                                    }
                                    else // 旧優良品に対しユーザー代替がある場合
                                    {
                                        rowUsrGoodsInfo = rowSubst;
                                    }
                                }
                                else // ユーザー代替しないの場合最新品番に代替する。
                                {
                                    rowUsrGoodsInfo = rowNew;
                                }
                                //row = _orgDataSet.UsrGoodsInfo.FindByGoodsMakerCdGoodsNo(makerCd, partsNoInUse);
                            }
                            //if (lst.Contains(retJoin[j].JoinDestPartsNo) == false)　// DEL wangf 2012/03/29 FOR Redmine#29146
                            if (lst.Contains(retJoin[j].JoinDestPartsNo + "," + retJoin[j].JoinDestMakerCd) == false)　// ADD wangf 2012/03/29 FOR Redmine#29146
                            {
                                //lst.Add(retJoin[j].JoinDestPartsNo); // DEL wangf 2012/03/29 FOR Redmine#29146
                                lst.Add(retJoin[j].JoinDestPartsNo + "," + retJoin[j].JoinDestMakerCd); // ADD wangf 2012/03/29 FOR Redmine#29146
                                PrimePartsRet primePartsWork = SetJoinInfo(retJoin[j], rowUsrGoodsInfo);
                                work.PrimePartsList.Add(primePartsWork);
                            }
                        }
                    }
                }
                #endregion

                retVal.Add(work);
                //// 年式違いの品番・メーカ同一の純正部品に対応するため下記の処理を行います。
                //query = string.Format("{0}={1} AND {2}='{3}'",
                //    tablePartsInfo.CatalogPartsMakerCdColumn.ColumnName, tableUsrGoodsInfo[i].GoodsMakerCd,
                //    tablePartsInfo.ClgPrtsNoWithHyphenColumn.ColumnName, tableUsrGoodsInfo[i].GoodsNo);
                //PartsInfoRow[] rows = (PartsInfoRow[])tablePartsInfo.Select(query);
                //for (int j = 1; j < rows.Length; j++)
                //{
                //    if (rows[j].SelectionState == true)
                //    {
                //        retVal.Add(work);
                //    }
                //}
            }
            return retVal;
        }

        /// <summary>
        /// カタログ品番の現在庫数チェック
        /// </summary>
        /// <param name="parts">品番</param>
        /// <param name="maker">メーカー</param>
        /// <returns>true:現在庫数あり　false:現在庫なし</returns>
        internal bool PartsStockCheck(string parts, int maker)
        {
            bool ret = false;
            string rowFilter = String.Format("{0}='{1}' AND {2}={3}",
                        tableStock.GoodsNoColumn.ColumnName, parts,
                        tableStock.GoodsMakerCdColumn.ColumnName, maker);
            StockRow[] rowStock = (StockRow[])tableStock.Select(rowFilter);
            if (rowStock.Length > 0) // 実は下記のコメントされた処理がもっと正しいと思われるが、PM7に合わせたほうが
                ret = true;          // いいということによりこの処理にする。
            //for (int i = 0; i < rowStock.Length; i++)
            //{
            //    if (rowStock[i].ShipmentPosCnt > 0)
            //    {
            //        ret = true;
            //        break;
            //    }
            //}
            return ret;
        }
#if old  
        public List<GenuinePartsRet> GetSelectedGenuineParts()
        {
            List<GenuinePartsRet> retVal = new List<GenuinePartsRet>();

            UsrGoodsInfoRow[] usrRows = tableUsrGoodsInfo.GetSelectedRow(DataViewRowState.CurrentRows);
            for (int i = 0; i < usrRows.Length; i++)
            {
                if (usrRows[i].OfferKubun % 2 == 0) //ユーザー登録品、優良部品（提供区分が偶数0,2,4）は処理しない
                    continue;
                GenuinePartsRet work = new GenuinePartsRet();

                UsrGoodsInfoRow rowNewPartsNo = tableUsrGoodsInfo.GetNewPartsNoGoodsIfAny(usrRows[i]);
                UsrGoodsInfoRow rowToProcess = null; // 設定する情報を持つ行
                work.BLGoodsCode = usrRows[i].BlGoodsCode;

                if (usrRows[i].NewGoodsNo == string.Empty) // 代替しなかった場合
                {
                    if (rowNewPartsNo == null)  // 最新品番とカタログ品番が同じ
                    {
                        work.GoodsNo = usrRows[i].GoodsNo;
                        work.JoinSrcPartsNo = usrRows[i].GoodsNo;
                        work.CtlgPartsNo = usrRows[i].GoodsNo;
                        work.NewPartsNo = usrRows[i].GoodsNo;

                        rowToProcess = usrRows[i]; //　カタログ品番情報
                    }
                    else                        // 最新品番とカタログ品番が異なる
                    {
                        work.GoodsNo = rowNewPartsNo.GoodsNo;
                        work.JoinSrcPartsNo = usrRows[i].GoodsNo;
                        work.CtlgPartsNo = usrRows[i].GoodsNo;
                        work.NewPartsNo = rowNewPartsNo.GoodsNo;

                        rowToProcess = rowNewPartsNo; //　最新品番情報
                    }
                }
                else // 代替した場合
                {
                    work.GoodsNo = usrRows[i].NewGoodsNo;
                    work.JoinSrcPartsNo = usrRows[i].NewGoodsNo;
                    work.CtlgPartsNo = usrRows[i].GoodsNo;
                    work.NewPartsNo = rowNewPartsNo.GoodsNo;

                    UsrGoodsInfoRow rowSubst = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(usrRows[i].GoodsMakerCd, usrRows[i].NewGoodsNo);
                    if (rowSubst != null)
                    {
                        rowToProcess = rowSubst; //　代替した品番情報
                    }
                    else // あってはいけないケースだが、DBの整合性による問題を防ぐためこの処理をいれておく。
                    {
                        rowToProcess = usrRows[i];
                    }
                }
                work.GoodsName = rowToProcess.GoodsName;
                work.GoodsMakerCd = rowToProcess.GoodsMakerCd;
                work.GoodsMakerNm = rowToProcess.GoodsMakerNm;
                work.CreateDateTime = new DateTime(rowToProcess.CreateDateTime);
                work.DisplayOrder = rowToProcess.DisplayOrder;
                work.EnterpriseCode = rowToProcess.EnterpriseCode;
                work.EnterpriseGanreCode = rowToProcess.EnterpriseGanreCode;
                if (rowToProcess.IsFileHeaderGuidNull() == false)
                    work.FileHeaderGuid = rowToProcess.FileHeaderGuid;
                work.GoodsKindCode = rowToProcess.GoodsKindCode;
                work.GoodsMGroup = rowToProcess.GoodsMGroup;
                work.GoodsNameKana = rowToProcess.GoodsNameKana;
                work.GoodsNote1 = rowToProcess.GoodsNote1;
                work.GoodsNote2 = rowToProcess.GoodsNote2;
                work.GoodsRateRank = rowToProcess.GoodsRateRank;
                work.GoodsSpecialNote = rowToProcess.GoodsSpecialNote;
                work.Jan = rowToProcess.Jan;
                work.LogicalDeleteCode = rowToProcess.LogicalDeleteCode;
                work.OfferDate = rowToProcess.OfferDate;
                work.TaxationDivCd = rowToProcess.TaxationDivCd;
                work.UpdAssemblyId1 = rowToProcess.UpdAssemblyId1;
                work.UpdAssemblyId2 = rowToProcess.UpdAssemblyId2;
                work.UpdateDate = rowToProcess.UpdateDate;
                work.UpdateDateTime = new DateTime(rowToProcess.UpdateDateTime);
                work.UpdEmployeeCode = rowToProcess.UpdEmployeeCode;

                PartsInfoRow[] rowOrg = (PartsInfoRow[])rowToProcess.GetChildRows("UsrGoodsInfo_PartsInfo");
                if (rowOrg.Length > 0)
                {
                    work.PartsQty = rowOrg[0].PartsQty;
                    work.PartsOpNm = rowOrg[0].PartsOpNm;
                    work.StandardName = rowOrg[0].StandardName;
                }

                PartsInfoRow rowCtlg = tablePartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(work.GoodsMakerCd, work.CtlgPartsNo);
                if (rowCtlg != null)
                {
                    work.CtlgPartsOpNm = rowCtlg.PartsOpNm;
                }

                // 価格情報取得
                string query = string.Format("{0} = {1} AND {2} = '{3}'",
                    tableUsrGoodsPrice.GoodsMakerCdColumn.ColumnName, work.GoodsMakerCd,
                    tableUsrGoodsPrice.GoodsNoColumn.ColumnName, work.GoodsNo);
                UsrGoodsPriceRow[] rowPrice = (UsrGoodsPriceRow[])tableUsrGoodsPrice.Select(query);
                for (int j = 0; j < rowPrice.Length; j++)
                {
                    GoodsPrice prc = new GoodsPrice();
                    prc.CreateDateTime = new DateTime(rowPrice[j].CreateDateTime);
                    prc.UpdateDateTime = new DateTime(rowPrice[j].UpdateDateTime);
                    prc.EnterpriseCode = rowPrice[j].EnterpriseCode;
                    if (rowPrice[j].IsFileHeaderGuidNull() == false)
                        prc.FileHeaderGuid = rowPrice[j].FileHeaderGuid;
                    prc.UpdAssemblyId1 = rowPrice[j].UpdAssemblyId1;
                    prc.UpdAssemblyId2 = rowPrice[j].UpdAssemblyId2;
                    prc.UpdEmployeeCode = rowPrice[j].UpdEmployeeCode;
                    prc.LogicalDeleteCode = rowPrice[j].LogicalDeleteCode;

                    prc.GoodsMakerCd = rowPrice[j].GoodsMakerCd;
                    prc.GoodsNo = rowPrice[j].GoodsNo;
                    prc.ListPrice = rowPrice[j].ListPrice;
                    prc.OpenPriceDiv = rowPrice[j].OpenPriceDiv;
                    prc.PriceStartDate = rowPrice[j].PriceStartDate;
                    prc.SalesUnitCost = rowPrice[j].SalesUnitCost;
                    prc.StockRate = rowPrice[j].StockRate;
                    if (rowPrice[j].IsUpdateDateNull() == false)
                    {
                        prc.UpdateDate = rowPrice[j].UpdateDate;
                    }
                    else
                    {
                        prc.UpdateDate = DateTime.MinValue;
                    }
                    prc.OfferDate = rowPrice[j].OfferDate;
                    work.GoodsPriceList.Add(prc);
                }

                // 在庫情報取得
                query = string.Format("{0} = {1} AND {2} = '{3}'",
                    tableStock.GoodsMakerCdColumn.ColumnName, work.GoodsMakerCd,
                    tableStock.GoodsNoColumn.ColumnName, work.GoodsNo);
                StockRow[] stockRow = (StockRow[])tableStock.Select(query);
                for (int j = 0; j < stockRow.Length; j++)
                {
                    work.StockList.Add(GetStockFromStockRow(stockRow[j]));
                }

                // 結合情報取得
                List<string> lst = new List<string>();
                query = string.Format("{0} = {1} AND {2} = '{3}'",
                     tableUsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, work.GoodsMakerCd,
                     tableUsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, work.JoinSrcPartsNo);
                UsrJoinPartsRow[] retJoin = (UsrJoinPartsRow[])tableUsrJoinParts.Select(query, tableUsrJoinParts.JoinDispOrderColumn.ColumnName);
                for (int j = 0; j < retJoin.Length; j++)
                {
                    UsrGoodsInfoRow rowUsrGoodsInfo = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(retJoin[j].JoinDestMakerCd, retJoin[j].JoinDestPartsNo);
                    if (rowUsrGoodsInfo != null)
                    {
                        lst.Add(retJoin[j].JoinDestPartsNo);
                        PrimePartsRet primePartsWork = SetJoinInfo(retJoin[j], rowUsrGoodsInfo);

                        work.PrimePartsList.Add(primePartsWork);
                    }
                }
                query = string.Format("{0} = {1} AND {2} = '{3}'",
                     tableUsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, work.GoodsMakerCd,
                     tableUsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, work.NewPartsNo);
                retJoin = (UsrJoinPartsRow[])tableUsrJoinParts.Select(query, tableUsrJoinParts.JoinDispOrderColumn.ColumnName);
                for (int j = 0; j < retJoin.Length; j++)
                {
                    UsrGoodsInfoRow rowUsrGoodsInfo = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(retJoin[j].JoinDestMakerCd, retJoin[j].JoinDestPartsNo);
                    if (rowUsrGoodsInfo != null && lst.Contains(retJoin[j].JoinDestPartsNo) == false)
                    {
                        lst.Add(retJoin[j].JoinDestPartsNo);
                        PrimePartsRet primePartsWork = SetJoinInfo(retJoin[j], rowUsrGoodsInfo);

                        work.PrimePartsList.Add(primePartsWork);
                    }
                }
                retVal.Add(work);
                // 年式違いの品番・メーカ同一の純正部品に対応するため下記の処理を行います。
                query = string.Format("{0}={1} AND {2}='{3}'",
                    tablePartsInfo.CatalogPartsMakerCdColumn.ColumnName, tableUsrGoodsInfo[i].GoodsMakerCd,
                    tablePartsInfo.ClgPrtsNoWithHyphenColumn.ColumnName, tableUsrGoodsInfo[i].GoodsNo);
                PartsInfoRow[] rows = (PartsInfoRow[])tablePartsInfo.Select(query);
                for (int j = 1; j < rows.Length; j++)
                {
                    if (rows[j].SelectionState == true)
                    {
                        retVal.Add(work);
                    }
                }
            }
            return retVal;
        }
#endif
        private PrimePartsRet SetJoinInfo(UsrJoinPartsRow retJoin, UsrGoodsInfoRow rowUsrGoodsInfo)
        {
            PrimePartsRet primePartsWork = new PrimePartsRet();

            primePartsWork.BLGoodsCode = rowUsrGoodsInfo.BlGoodsCode;
            primePartsWork.CreateDateTime = new DateTime(rowUsrGoodsInfo.CreateDateTime);
            primePartsWork.DisplayOrder = rowUsrGoodsInfo.DisplayOrder;
            primePartsWork.EnterpriseCode = rowUsrGoodsInfo.EnterpriseCode;
            primePartsWork.EnterpriseGanreCode = rowUsrGoodsInfo.EnterpriseGanreCode;
            if (rowUsrGoodsInfo.IsFileHeaderGuidNull() == false)
                primePartsWork.FileHeaderGuid = rowUsrGoodsInfo.FileHeaderGuid;
            primePartsWork.GoodsKindCode = rowUsrGoodsInfo.GoodsKindCode;
            primePartsWork.GoodsMakerCd = rowUsrGoodsInfo.GoodsMakerCd;
            primePartsWork.GoodsName = rowUsrGoodsInfo.GoodsName;
            primePartsWork.GoodsNameKana = rowUsrGoodsInfo.GoodsNameKana;
            primePartsWork.GoodsNo = rowUsrGoodsInfo.GoodsNo;
            primePartsWork.GoodsNoNoneHyphen = rowUsrGoodsInfo.GoodsNoNoneHyphen;
            primePartsWork.GoodsNote1 = rowUsrGoodsInfo.GoodsNote1;
            primePartsWork.GoodsNote2 = rowUsrGoodsInfo.GoodsNote2;
            primePartsWork.GoodsRateRank = rowUsrGoodsInfo.GoodsRateRank;
            primePartsWork.GoodsSpecialNote = rowUsrGoodsInfo.GoodsSpecialNote;
            primePartsWork.Jan = rowUsrGoodsInfo.Jan;
            primePartsWork.JoinDestMakerCd = retJoin.JoinDestMakerCd;
            primePartsWork.JoinDestPartsNo = retJoin.JoinDestPartsNo;
            primePartsWork.JoinDispOrder = retJoin.JoinDispOrder;
            primePartsWork.JoinQty = retJoin.JoinQty;
            primePartsWork.JoinSourceMakerCode = retJoin.JoinSourceMakerCode;
            primePartsWork.JoinSourPartsNoNoneH = retJoin.JoinSrcPartsNoNoneH;
            primePartsWork.JoinSourPartsNoWithH = retJoin.JoinSrcPartsNoWithH;
            primePartsWork.JoinSpecialNote = retJoin.JoinSpecialNote;
            primePartsWork.LogicalDeleteCode = rowUsrGoodsInfo.LogicalDeleteCode;
            primePartsWork.OfferDate = rowUsrGoodsInfo.OfferDate;
            primePartsWork.TaxationDivCd = rowUsrGoodsInfo.TaxationDivCd;
            primePartsWork.UpdAssemblyId1 = rowUsrGoodsInfo.UpdAssemblyId1;
            primePartsWork.UpdAssemblyId2 = rowUsrGoodsInfo.UpdAssemblyId2;
            primePartsWork.UpdateDate = rowUsrGoodsInfo.UpdateDate;
            primePartsWork.UpdateDateTime = new DateTime(rowUsrGoodsInfo.UpdateDateTime);
            primePartsWork.UpdEmployeeCode = rowUsrGoodsInfo.UpdEmployeeCode;

            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/25 ADD
            // 優良設定 種別名称
            primePartsWork.PrmSetDtlName2 = rowUsrGoodsInfo.PrmSetDtlName2;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/25 ADD

            return primePartsWork;
        }

        internal static Stock GetStockFromStockRow(StockRow row)
        {
            Stock stock = new Stock();
            stock.EnterpriseCode = row.EnterpriseCode;
            stock.AcpOdrCount = row.AcpOdrCount;
            stock.ArrivalCnt = row.ArrivalCnt;
            stock.CreateDateTime = row.CreateDateTime;
            stock.DuplicationShelfNo1 = row.DuplicationShelfNo1;
            stock.DuplicationShelfNo2 = row.DuplicationShelfNo2;
            stock.FileHeaderGuid = row.FileHeaderGuid;
            stock.GoodsMakerCd = row.GoodsMakerCd;
            stock.GoodsNo = row.GoodsNo;
            stock.GoodsNoNoneHyphen = row.GoodsNoNoneHyphen;
            stock.LastInventoryUpdate = row.LastInventoryUpdate;
            stock.LastSalesDate = row.LastSalesDate;
            stock.LastStockDate = row.LastStockDate;
            stock.LogicalDeleteCode = row.LogicalDeleteCode;
            stock.MaximumStockCnt = row.MaximumStockCnt;
            stock.MinimumStockCnt = row.MinimumStockCnt;
            stock.MonthOrderCount = row.MonthOrderCount;
            stock.MovingSupliStock = row.MovingSupliStock;
            stock.NmlSalOdrCount = row.NmlSalOdrCount;
            stock.PartsManagementDivide1 = row.PartsManagementDivide1;
            stock.PartsManagementDivide2 = row.PartsManagementDivide2;
            stock.SalesOrderCount = row.SalesOrderCount;
            stock.SalesOrderUnit = row.SalesOrderUnit;
            stock.SectionCode = row.SectionCode;
            //stock.SectionGuideNm = row.SectionGuideNm;
            stock.ShipmentCnt = row.ShipmentCnt;
            stock.ShipmentPosCnt = row.ShipmentPosCnt;
            stock.StockCreateDate = row.StockCreateDate;
            stock.StockDiv = row.StockDiv;
            stock.StockNote1 = row.StockNote1;
            stock.StockNote2 = row.StockNote2;
            stock.StockSupplierCode = row.StockSupplierCode;
            stock.StockTotalPrice = row.StockTotalPrice;
            stock.StockUnitPriceFl = row.StockUnitPriceFl;
            stock.SupplierStock = row.SupplierStock;
            stock.UpdAssemblyId1 = row.UpdAssemblyId1;
            stock.UpdAssemblyId2 = row.UpdAssemblyId2;
            stock.UpdateDate = row.UpdateDate;
            stock.UpdateDateTime = row.UpdateDateTime;
            stock.UpdEmployeeCode = row.UpdEmployeeCode;
            stock.WarehouseCode = row.WarehouseCode;
            stock.WarehouseName = row.WarehouseName;
            stock.WarehouseShelfNo = row.WarehouseShelfNo;

            return stock;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        internal GoodsUnitData GetGUDFromDR(UsrGoodsInfoRow row)
        {
            return GetGUDFromDR(row, false, 0);
        }

        /// <summary>
        /// GoodsUnitDataデータクラス取得
        /// </summary>
        /// <param name="row"></param>
        /// <param name="flg">選択部品のみフラグ</param>
        /// <returns></returns>
        internal GoodsUnitData GetGUDFromDR(UsrGoodsInfoRow row, bool flg)
        {
            return GetGUDFromDR(row, flg, 0);
        }

        // 2010/03/24 Add >>>
        /// <summary>
        /// GoodsUnitDataデータクラス取得
        /// </summary>
        /// <param name="row"></param>
        /// <param name="flg"></param>
        /// <param name="nameFlg"></param>
        /// <returns></returns>
        internal GoodsUnitData GetGUDFromDR(UsrGoodsInfoRow row, bool flg, int nameFlg)
        {
            return this.GetGUDFromDR(row, flg, nameFlg, 0, false, null, true);
        }
        // 2010/03/24 Add <<<

        // 2009/10/23 Add >>>
        /// <summary>
        /// GoodsUnitDataデータクラス取得
        /// </summary>
        /// <param name="row"></param>
        /// <param name="flg"></param>
        /// <param name="nameFlg"></param>
        /// <param name="substFlg"></param>
        // 2010/03/24 >>>
        //internal GoodsUnitData GetGUDFromDR(UsrGoodsInfoRow row, bool flg, int nameFlg)
        internal GoodsUnitData GetGUDFromDR(UsrGoodsInfoRow row, bool flg, int nameFlg, bool substFlg)
        // 2010/03/24 <<<
        {
            // 2010/03/24 >>>
            //// 2009/10/27 >>>
            ////return this.GetGUDFromDR(row, flg, nameFlg, 0, false);
            //return this.GetGUDFromDR(row, flg, nameFlg, 0, false, null);
            //// 2009/10/27 <<<

            return this.GetGUDFromDR(row, flg, nameFlg, 0, false, null, substFlg);
            // 2010/03/24 <<<
        }
        // 2009/10/23 Add <<<

        /// <summary>
        /// GoodsUnitDataデータクラス取得
        /// </summary>
        /// <param name="row"></param>
        /// <param name="flg">選択部品のみフラグ</param>
        /// <param name="nameFlg">品名表示フラグ(0:商品優先 / 1:提供優先)</param>
        /// <param name="depth">部品確定ウィンドウ</param>
        /// <param name="plrlSubst">True:複数互換</param>
        /// <param name="joinSrcRow">結合元部品情報</param>
        /// <param name="substFlg"></param>
        /// <returns></returns>
        // 2010/03/24 >>>
        //// 2009/10/27 >>>
        ////// 2009/10/23 >>>
        //////internal GoodsUnitData GetGUDFromDR(UsrGoodsInfoRow row, bool flg, int nameFlg)
        ////internal GoodsUnitData GetGUDFromDR(UsrGoodsInfoRow row, bool flg, int nameFlg, int depth, bool plrlSubst)
        ////// 2009/10/23 <<<
        //internal GoodsUnitData GetGUDFromDR(UsrGoodsInfoRow row, bool flg, int nameFlg, int depth, bool plrlSubst, UsrGoodsInfoRow joinSrcRow)
        //// 2009/10/27 <<<

        internal GoodsUnitData GetGUDFromDR(UsrGoodsInfoRow row, bool flg, int nameFlg, int depth, bool plrlSubst, UsrGoodsInfoRow joinSrcRow, bool substFlg)
        // 2010/03/24 <<<
        {
            //>>>2010/06/30
            //// --- ADD m.suzuki 2010/06/11 ---------->>>>>
            //// ※成果物統合後、品名表示フラグが正しく取得出来ないケースが
            ////   発生した為、プロパティの値で書き換える。
            ////   但し、売上全体設定の内容が渡ってこなかった場合は"0"のまま。
            //if (searchMethod == 0)
            //{
            //    // BL検索
            //    if (BLCdPrtsNmDspDivCd1 != 0 ||
            //        BLCdPrtsNmDspDivCd2 != 0 ||
            //        BLCdPrtsNmDspDivCd3 != 0 ||
            //        BLCdPrtsNmDspDivCd4 != 0)
            //    {
            //        nameFlg = PartsNameDspDivCd;
            //    }
            //}
            //else
            //{
            //    // 品番検索
            //    if (GdNoPrtsNmDspDivCd1 != 0 ||
            //        GdNoPrtsNmDspDivCd2 != 0 ||
            //        GdNoPrtsNmDspDivCd3 != 0 ||
            //        GdNoPrtsNmDspDivCd4 != 0)
            //    {
            //        nameFlg = PartsNameDspDivCd;
            //    }
            //}
            //// --- ADD m.suzuki 2010/06/11 ----------<<<<<

            if (PartsNameDspDivCd == 2)
            {
                if (searchMethod == 0)
                {
                    // BL検索
                    if (BLCdPrtsNmDspDivCd1 != 0 ||
                        BLCdPrtsNmDspDivCd2 != 0 ||
                        BLCdPrtsNmDspDivCd3 != 0 ||
                        BLCdPrtsNmDspDivCd4 != 0)
                    {
                        nameFlg = PartsNameDspDivCd;
                    }
                }
                else
                {
                    // 品番検索
                    if (GdNoPrtsNmDspDivCd1 != 0 ||
                        GdNoPrtsNmDspDivCd2 != 0 ||
                        GdNoPrtsNmDspDivCd3 != 0 ||
                        GdNoPrtsNmDspDivCd4 != 0)
                    {
                        nameFlg = PartsNameDspDivCd;
                    }
                }
            }
            else
            {
                nameFlg = PartsNameDspDivCd;
            }
            //<<<2010/06/30


            GoodsUnitData goods = new GoodsUnitData();
            UsrGoodsInfoRow rowToProcess = null;
            // 2009/10/27 Del >>>
            //// 2009/10/23 Add >>>
            //// 結合選択UIで選択された場合は、結合元情報を取得する
            //UsrGoodsInfoRow joinSrcRow = ( ( depth == 1 ) ) ? joinSrcSelInf.RowGoods : null;
            //// 2009/10/23 Add <<<
            // 2009/10/27 Del <<<
            if (substFlg)   // 2010/03/24 Add
            {               // 2010/03/24 Add
                if (flg && ( row.OfferKubun == 1 || row.OfferKubun == 3 )) // 選択部品のみかつ提供純正の場合
                {
                    PartsInfoDataSet.UsrGoodsInfoRow rowNewPartsNo = tableUsrGoodsInfo.GetNewPartsNoGoodsIfAny(row);
                    if (row.NewGoodsNo == string.Empty) // 代替しなかった場合
                    {
                        if (rowNewPartsNo == null)  // 最新品番とカタログ品番が同じ
                        {
                            rowToProcess = row;
                            goods.GoodsNo = row.GoodsNo;
                        }
                        else
                        {
                            rowToProcess = rowNewPartsNo;
                            goods.GoodsNo = rowNewPartsNo.GoodsNo;
                        }
                    }
                    else
                    {
                        rowToProcess = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(row.GoodsMakerCd, row.NewGoodsNo);
                        if (rowToProcess == null) // あってはいけないケースだが、念のため入れておく
                            rowToProcess = row;
                        goods.GoodsNo = row.NewGoodsNo;
                    }
                }
                else // 提供純正以外の場合
                {
                    rowToProcess = row;
                    goods.GoodsNo = row.GoodsNo;
                }
            // 2010/03/24 Add >>>
            }
            else
            {
                rowToProcess = row;
                goods.GoodsNo = row.GoodsNo;
            }
            // 2010/03/24 Add <<<

            goods.CreateDateTime = new DateTime(rowToProcess.CreateDateTime);
            goods.UpdateDateTime = new DateTime(rowToProcess.UpdateDateTime);
            goods.EnterpriseCode = rowToProcess.EnterpriseCode;
            if (rowToProcess.IsFileHeaderGuidNull() == false)
                goods.FileHeaderGuid = rowToProcess.FileHeaderGuid;
            goods.UpdAssemblyId1 = rowToProcess.UpdAssemblyId1;
            goods.UpdAssemblyId2 = rowToProcess.UpdAssemblyId2;
            goods.UpdEmployeeCode = rowToProcess.UpdEmployeeCode;
            goods.LogicalDeleteCode = rowToProcess.LogicalDeleteCode;

            goods.DisplayOrder = rowToProcess.DisplayOrder;
            goods.BLGoodsCode = rowToProcess.BlGoodsCode;
            goods.GoodsMakerCd = rowToProcess.GoodsMakerCd;
            goods.MakerName = rowToProcess.GoodsMakerNm;

            // 2009/11/24 Add >>>
            if (( depth == 0 ) && !( plrlSubst ) && ( ( _searchCondition != null ) && ( _searchCondition.TbsPartsCode != 0 ) ))
            {
                goods.SearchBLCode = _searchCondition.TbsPartsCode;
            }
            // 2009/11/24 Add <<<

            goods.GoodsNoNoneHyphen = rowToProcess.GoodsNoNoneHyphen;

            if (searchMethod == 0) // BL検索・TBO検索・オリジナル検索の場合
            {
                // --- ADD m.suzuki 2010/04/28 ---------->>>>>
                // 自由検索部品固有番号
                goods.FreSrchPrtPropNo = rowToProcess.FreSrchPrtPropNo;
                // --- ADD m.suzuki 2010/04/28 ----------<<<<<

                // ADD 2010/05/17 品名表示対応 ---------->>>>>
                // --- UPD m.suzuki 2010/07/14 ---------->>>>>
                //if ( nameFlg == 2 )  // 品名表示フラグが[2:任意設定]の場合
                if ( rowToProcess.GoodsKind == (int)GoodsKind.Set )
                {
                    // セット子ならば、セット品名を採用する。
                    goods.GoodsName = rowToProcess.GoodsName;
                    goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                }
                else if ( nameFlg == 2 )  // 品名表示フラグが[2:任意設定]の場合
                // --- UPD m.suzuki 2010/07/14 ----------<<<<<
                {
                    // TODO:品名表示フラグが[2:任意設定]の場合…BLコード検索版
                    GoodsNameSelector goodsNameSelector = CreateGoodsNameSelector(
                        (int)SearchingMethodValue.None,
                        rowToProcess,
                        plrlSubst,
                        joinSrcRow
                    );
                    System.Diagnostics.Debug.WriteLine( "以下の順で品名を選択します：" + goodsNameSelector.ToString() );
                    GoodsNamePair goodsNamePair = goodsNameSelector.GetGoodsName( goods, this.GetBLGoodsInfo );
                    {
                        goods.GoodsName = goodsNamePair.Key;
                        goods.GoodsNameKana = goodsNamePair.Value;
                    }
                }
                // ADD 2010/05/17 品名表示対応 ----------<<<<<
                // 2009/10/23 >>>
                //if ((rowToProcess.OfferKubun == 1 || rowToProcess.OfferKubun == 3) && // 純正部品
                //    rowToProcess.SearchPartsFullName != string.Empty) // 検索品名がある場合
                //{
                //    goods.GoodsName = rowToProcess.SearchPartsFullName;
                //    goods.GoodsNameKana = rowToProcess.SearchPartsHalfName;
                //}

                // 複数互換(サブ）もしくは、結合品で結合元が複数互換品の場合
                // DEL 2010/05/17 品名表示対応 ---------->>>>>
                //if (( plrlSubst ) ||
                // DEL 2010/05/17 品名表示対応 ----------<<<<<
                // ADD 2010/05/17 品名表示対応 ---------->>>>>
                else if ( (plrlSubst) ||
                    // ADD 2010/05/17 品名表示対応 ----------<<<<<
                    (joinSrcRow != null) && (((joinSrcRow.GoodsKind & (int)GoodsKind.SubstPlrl) == (int)GoodsKind.SubstPlrl)) )
                {
                    goods.GoodsName = rowToProcess.GoodsName;
                    goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                }
                else if (( rowToProcess.OfferKubun == 1 ||      // 提供純正編集
                           rowToProcess.OfferKubun == 3 ||      // 提供純正
                           rowToProcess.OfferKubun == 7 ) &&    // オリジナル部品
                    rowToProcess.SearchPartsFullName != string.Empty) // 検索品名がある場合
                {
                    goods.GoodsName = rowToProcess.SearchPartsFullName;
                    goods.GoodsNameKana = rowToProcess.SearchPartsHalfName;
                }
                // 2009/10/23 <<<
                // 2009.08.03 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //else if (rowToProcess.GoodsName != string.Empty) // 商品名称がある場合
                //{
                //    goods.GoodsName = rowToProcess.GoodsName;
                //    goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                //}
                //else
                //{
                //    goods.GoodsName = rowToProcess.GoodsOfrName;
                //    goods.GoodsNameKana = rowToProcess.GoodsOfrNameKana;
                //}
                else
                {
                    if (nameFlg == 0) // 品名表示フラグが[0:商品優先]の場合
                    {
                        if (rowToProcess.GoodsName != string.Empty) // 商品名称がある場合
                        {
                            goods.GoodsName = rowToProcess.GoodsName;
                            goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                        }
                        else
                        {
                            goods.GoodsName = rowToProcess.GoodsOfrName;
                            goods.GoodsNameKana = rowToProcess.GoodsOfrNameKana;
                        }
                    }
                    else // 品名表示フラグが[1:提供優先]の場合
                    {
                        // 2009/10/23 >>>
                        //if (rowToProcess.GoodsOfrName != string.Empty) // 部品名称がある場合
                        //{
                        //    goods.GoodsName = rowToProcess.GoodsOfrName;
                        //    goods.GoodsNameKana = rowToProcess.GoodsOfrNameKana;
                        //}
                        //else
                        //{
                        //    goods.GoodsName = rowToProcess.GoodsName;
                        //    goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                        //}

                        // 2009/11/24 >>>
                        //// 結合元部品があり、結合元に検索品名が入っている場合は、最優先
                        //if (( joinSrcRow != null ) && ( !string.IsNullOrEmpty(joinSrcRow.SearchPartsFullName) ))

                        // 結合元部品があり、結合元にメーカーコード有りの検索品名が入っている場合は、最優先
                        if (( joinSrcRow != null ) && ( !string.IsNullOrEmpty(joinSrcRow.SearchPartsFullName) ) && ( joinSrcRow.SrchPNmAcqrCarMkrCd != 0 ))
                        // 2009/11/24 <<<
                        {
                            goods.GoodsName = joinSrcRow.SearchPartsFullName;
                            goods.GoodsNameKana = joinSrcRow.SearchPartsHalfName;
                        }
                        else
                        {

                            // 優良品は、検索品名を取得できなかった場合はユーザー登録分を優先して表示
                            if (( rowToProcess.OfferKubun == 2 ) || ( rowToProcess.OfferKubun == 4 ))
                            {
                                if (rowToProcess.GoodsName != string.Empty) // 商品名称がある場合
                                {
                                    goods.GoodsName = rowToProcess.GoodsName;
                                    goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                                }
                                else
                                {
                                    goods.GoodsName = rowToProcess.GoodsOfrName;
                                    goods.GoodsNameKana = rowToProcess.GoodsOfrNameKana;
                                }
                            }
                            else
                            {
                                // DEL 2010/05/17 品名表示対応 ---------->>>>>
                                //if (rowToProcess.GoodsOfrName != string.Empty) // 部品名称がある場合
                                //{
                                //    goods.GoodsName = rowToProcess.GoodsOfrName;
                                //    goods.GoodsNameKana = rowToProcess.GoodsOfrNameKana;
                                //}
                                //else
                                //{
                                //    goods.GoodsName = rowToProcess.GoodsName;
                                //    goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                                //}
                                // DEL 2010/05/17 品名表示対応 ----------<<<<<
                                // ADD 2010/05/17 品名表示対応 ---------->>>>>
                                // 商品マスタを優先
                                if ( rowToProcess.GoodsName != string.Empty ) // 商品名称がある場合
                                {
                                    goods.GoodsName = rowToProcess.GoodsName;
                                    goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                                }
                                else
                                {
                                    goods.GoodsName = rowToProcess.GoodsOfrName;
                                    goods.GoodsNameKana = rowToProcess.GoodsOfrNameKana;
                                }
                                // ADD 2010/05/17 品名表示対応 ----------<<<<<
                            } 
                        }
                        // 2009/10/23 <<<
                    }
                }
                // 2009.08.03 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
            }
            else // 品番検索の場合
            {
                // --- UPD m.suzuki 2010/07/14 ---------->>>>>
                //if (nameFlg == 0) // 品名表示フラグが[0:商品優先]の場合
                if ( rowToProcess.GoodsKind == (int)GoodsKind.Set)
                {
                    // セット子ならば、セット品名を採用する。
                    goods.GoodsName = rowToProcess.GoodsName;
                    goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                }
                else if (nameFlg == 0) // 品名表示フラグが[0:商品優先]の場合
                // --- UPD m.suzuki 2010/07/14 ----------<<<<<
                {
                    if (rowToProcess.GoodsName != string.Empty) // 商品名称がある場合
                    {
                        goods.GoodsName = rowToProcess.GoodsName;
                        goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                    }
                    else
                    {
                        goods.GoodsName = rowToProcess.GoodsOfrName;
                        goods.GoodsNameKana = rowToProcess.GoodsOfrNameKana;
                    }
                }
                // ADD 2010/05/17 品名表示対応 ---------->>>>>
                else if ( nameFlg == 2 )  // 品名表示フラグが[2:任意設定]の場合
                {
                    // TODO:品名表示フラグが[2:任意設定]の場合…品番検索版
                    GoodsNameSelector goodsNameSelector = CreateGoodsNameSelector(
                        (int)SearchingMethodValue.ByGoodsNo,
                        rowToProcess,
                        plrlSubst,
                        joinSrcRow
                    );
                    System.Diagnostics.Debug.WriteLine( "以下の順で品名を選択します：" + goodsNameSelector.ToString() );
                    GoodsNamePair goodsNamePair = goodsNameSelector.GetGoodsName( goods, this.GetBLGoodsInfo );
                    {
                        goods.GoodsName = goodsNamePair.Key;
                        goods.GoodsNameKana = goodsNamePair.Value;
                    }
                }
                // ADD 2010/05/17 品名表示対応 ----------<<<<<
                else // 品名表示フラグが[1:提供優先]の場合
                {
                    // 2009/10/23 >>>
                    //// 2009.08.03 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    ////if (rowToProcess.GoodsOfrName != string.Empty) // 部品名称がある場合
                    ////{
                    ////    goods.GoodsName = rowToProcess.GoodsOfrName;
                    ////    goods.GoodsNameKana = rowToProcess.GoodsOfrNameKana;
                    ////}
                    ////else
                    ////{
                    ////    goods.GoodsName = rowToProcess.GoodsName;
                    ////    goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                    ////}
                    //if (rowToProcess.GoodsName != string.Empty) // 部品名称がある場合
                    //{
                    //    goods.GoodsName = rowToProcess.GoodsName;
                    //    goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                    //}
                    //else
                    //{
                    //    goods.GoodsName = rowToProcess.GoodsOfrName;
                    //    goods.GoodsNameKana = rowToProcess.GoodsOfrNameKana;
                    //}
                    //// 2009.08.03 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                    // 優良部品はユーザー商品を優先
                    if (( rowToProcess.OfferKubun == 2 ) || ( rowToProcess.OfferKubun == 4 ))
                    {
                        if ( rowToProcess.GoodsName != string.Empty ) // 部品名称がある場合
                        {
                            goods.GoodsName = rowToProcess.GoodsName;
                            goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                        }
                        else
                        {
                            goods.GoodsName = rowToProcess.GoodsOfrName;
                            goods.GoodsNameKana = rowToProcess.GoodsOfrNameKana;
                        }
                    }
                    // 純正部品は提供品名を優先
                    else
                    {
                        if (rowToProcess.GoodsOfrName != string.Empty) // 部品名称がある場合
                        {
                            goods.GoodsName = rowToProcess.GoodsOfrName;
                            goods.GoodsNameKana = rowToProcess.GoodsOfrNameKana;
                        }
                        else
                        {
                            goods.GoodsName = rowToProcess.GoodsName;
                            goods.GoodsNameKana = rowToProcess.GoodsNameKana;
                        }

                    }
                    // 2009/10/23 <<<
                }
            }

            goods.GoodsMGroup = rowToProcess.GoodsMGroup;
            //goods.PrmSetDtlNo1 = row.PrmSetDtlNo1;
            //goods.PrmSetDtlNo2 = row.PrmSetDtlNo2;
            goods.GoodsNote1 = rowToProcess.GoodsNote1;
            goods.GoodsNote2 = rowToProcess.GoodsNote2;
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 ------------------------------------->>>>>
            goods.PrmSetDtlNo2 = rowToProcess.PrmSetDtlNo2;
            goods.PrmSetDtlName2 = rowToProcess.PrmSetDtlName2;
            // ADD 2014/06/04 SCM仕掛一覧№10659対応 -------------------------------------<<<<<
            // ADD 2015/02/25 SCM高速化 C向け種別対応 -------------------------->>>>>
            goods.PrmSetDtlName2ForFac = rowToProcess.PrmSetDtlName2ForFac;
            goods.PrmSetDtlName2ForCOw = rowToProcess.PrmSetDtlName2ForCOw;
            // ADD 2015/02/25 SCM高速化 C向け種別対応 --------------------------<<<<<
            //>>>2012/01/16
            //goods.GoodsSpecialNote = rowToProcess.GoodsSpecialNote;
            if (string.IsNullOrEmpty(rowToProcess.GoodsSpecialNote))
            {
                goods.GoodsSpecialNote = row.GoodsSpecialNote;
            }
            else
            {
                goods.GoodsSpecialNote = rowToProcess.GoodsSpecialNote;
            }
            //<<<2012/01/16
            goods.OfferDate = rowToProcess.OfferDate;
            goods.TaxationDivCd = rowToProcess.TaxationDivCd;
            goods.Jan = rowToProcess.Jan;

            // --- ADD 2011/12/12 ------- >>>>
            if (goods.GoodsMakerCd < 1000 && rowToProcess.OfferKubun > 0)
            {
                goods.GoodsKindCode = 0;
            }
            else
            {
                goods.GoodsKindCode = rowToProcess.GoodsKindCode;
            }
            // --- ADD 2011/12/12 ------- <<<<
            //goods.GoodsKindCode = rowToProcess.GoodsKindCode; // DEL 2011/12/12

            goods.EnterpriseGanreCode = rowToProcess.EnterpriseGanreCode;
            goods.GoodsRateRank = rowToProcess.GoodsRateRank;
            goods.TaxationDivCd = rowToProcess.TaxationDivCd;
            goods.OfferKubun = rowToProcess.OfferKubun;
            goods.GoodsKind = rowToProcess.GoodsKind;
            goods.GoodsKindResolved = rowToProcess.GoodsKindResolved;
            goods.OfferDataDiv = rowToProcess.OfferDataDiv;
            //------------ADD 2009/10/19--------->>>>>
            goods.SelectedListPrice = rowToProcess.SelectedListPrice;
            goods.SelectedListPriceDiv = rowToProcess.SelectedListPriceDiv;
            goods.PrtGoodsNo = rowToProcess.PrtGoodsNo;
            goods.PrtMakerCode = rowToProcess.PrtMakerCode;
            goods.PrtMakerName = rowToProcess.PrtMakerName;
            //------------ADD 2009/10/19--------->>>>>
            goods.SelectedGoodsNoDiv = rowToProcess.SelectedGoodsNoDiv; // ADD 2009/11/13

            string query = string.Format("{0}={1} AND {2}='{3}'",
                tableUsrJoinParts.JoinDestMakerCdColumn.ColumnName, goods.GoodsMakerCd,
                tableUsrJoinParts.JoinDestPartsNoColumn.ColumnName, goods.GoodsNo);
            UsrJoinPartsRow[] rowJoin = (UsrJoinPartsRow[])tableUsrJoinParts.Select(query);
            if (rowJoin.Length > 0)
            {
                goods.JoinDispOrder = rowJoin[0].JoinDispOrder;
                goods.JoinQty = rowJoin[0].JoinQty;
                goods.JoinSpecialNote = rowJoin[0].JoinSpecialNote;
            }
            query = string.Format("{0}={1} AND {2}='{3}'",
                tableUsrSetParts.SubGoodsMakerCdColumn.ColumnName, goods.GoodsMakerCd,
                tableUsrSetParts.SubGoodsNoColumn.ColumnName, goods.GoodsNo);
            UsrSetPartsRow[] rowSet = (UsrSetPartsRow[])tableUsrSetParts.Select(query);
            if (rowSet.Length > 0)
            {
                goods.SetDispOrder = rowSet[0].DisplayOrder;
                goods.SetQty = rowSet[0].CntFl;
                goods.SetSpecialNote = rowSet[0].SetSpecialNote;
            }
            PartsInfoRow rowParts = tablePartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(goods.GoodsMakerCd, goods.GoodsNo);
            if (rowParts != null)
            {
                goods.PartsQty = rowParts.PartsQty;
            }
            else
            {
                query = string.Format("{0}={1} AND {2}='{3}'",
                    tableSubstPartsInfo.CatalogPartsMakerCdColumn.ColumnName, goods.GoodsMakerCd,
                    tableSubstPartsInfo.NewPartsNoWithHyphenColumn.ColumnName, goods.GoodsNo);
                SubstPartsInfoRow[] rowSubst = (SubstPartsInfoRow[])tableSubstPartsInfo.Select(query);
                if (rowSubst.Length > 0)
                {
                    goods.PartsQty = rowSubst[0].PartsQty;

                    // --- UPD m.suzuki 2010/03/23 ---------->>>>>
                    //// --- ADD m.suzuki 2010/03/16 ---------->>>>>
                    //// 代替先のQTYがゼロならば、代替元のQTYで書き換える
                    //if ( goods.PartsQty == 0 )
                    //{
                    //    PartsInfoRow rowOldParts = tablePartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( rowSubst[0].CatalogPartsMakerCd, rowSubst[0].OldPartsNoWithHyphen );
                    //    if (rowOldParts != null)
                    //    {
                    //        goods.PartsQty = rowOldParts.PartsQty;
                    //    }
                    //}
                    //// --- ADD m.suzuki 2010/03/16 ----------<<<<<

                    // 取得したQTYがゼロのとき
                    if (goods.PartsQty == 0)
                    {
                        PartsInfoRow targetPartsInfoRow = null;
                        if (!string.IsNullOrEmpty(rowSubst[0].OldPartsNoWithHyphen))
                        {
                            // 代替先のQTYがゼロならば、代替元のQTYで書き換える
                            targetPartsInfoRow = tablePartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(rowSubst[0].CatalogPartsMakerCd, rowSubst[0].OldPartsNoWithHyphen);
                        }
                        else
                        {
                            // 代替元を取得できない場合（売上全体設定の純正代替＝代替しない）は、
                            // 最新品番でSELECTをかける。

                            query = string.Format("{0}='{1}' AND {2}='{3}'",
                                tablePartsInfo.NewPrtsNoWithHyphenColumn.ColumnName, rowSubst[0].NewPartsNoWithHyphen,
                                tablePartsInfo.CatalogPartsMakerCdColumn.ColumnName, rowSubst[0].CatalogPartsMakerCd);

                            PartsInfoRow[] targetRows = (PartsInfoRow[])tablePartsInfo.Select(query);
                            if (targetRows.Length > 0)
                            {
                                targetPartsInfoRow = targetRows[0];
                            }
                        }

                        // QTYを差し替える
                        if (targetPartsInfoRow != null)
                        {
                            goods.PartsQty = targetPartsInfoRow.PartsQty;
                        }
                    }
                    // --- UPD m.suzuki 2010/03/23 ----------<<<<<
                }
                else
                {
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        tableDSubstPartsInfo.CatalogPartsMakerCdColumn.ColumnName, goods.GoodsMakerCd,
                        tableDSubstPartsInfo.NewPartsNoWithHyphenColumn.ColumnName, goods.GoodsNo);
                    DSubstPartsInfoRow[] rowDSubst = (DSubstPartsInfoRow[])tableDSubstPartsInfo.Select(query);
                    if (rowDSubst.Length > 0)
                    {
                        goods.PartsQty = rowDSubst[0].PartsQty;

                        // --- DEL m.suzuki 2010/03/23 ---------->>>>>
                        //// --- ADD m.suzuki 2010/03/16 ---------->>>>>
                        //// 代替先のQTYがゼロならば、代替元のQTYで書き換える
                        //if ( goods.PartsQty == 0 )
                        //{
                        //    PartsInfoRow rowOldParts = tablePartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen( rowDSubst[0].CatalogPartsMakerCd, rowDSubst[0].OldPartsNoWithHyphen );
                        //    if ( rowOldParts != null )
                        //    {
                        //        goods.PartsQty = rowOldParts.PartsQty;
                        //    }
                        //}
                        //// --- ADD m.suzuki 2010/03/16 ----------<<<<<
                        // --- DEL m.suzuki 2010/03/23 ----------<<<<<
                    }
                }
                // --- ADD 2014/05/16 T.Nishi ---------->>>>>
                // 代替先のQTYがゼロならば、代替元のQTYで書き換える
                //ユーザー代替のテーブルを参照していないので参照処理を追加
                if (goods.PartsQty == 0)
                {
                    query = string.Format("{0}={1} AND {2}='{3}'",
                        tableUsrSubstParts.ChgDestMakerCdColumn.ColumnName, goods.GoodsMakerCd,
                        UsrSubstParts.ChgDestGoodsNoColumn.ColumnName, goods.GoodsNo);
                    UsrSubstPartsRow[] rowUsrSubst = (UsrSubstPartsRow[])tableUsrSubstParts.Select(query);
                    if (rowUsrSubst.Length > 0)
                    {
                        PartsInfoRow targetPartsInfoRow = null;
                        targetPartsInfoRow = tablePartsInfo.FindByCatalogPartsMakerCdClgPrtsNoWithHyphen(rowUsrSubst[0].ChgSrcMakerCd, rowUsrSubst[0].ChgSrcGoodsNo);

                        // QTYを差し替える
                        if (targetPartsInfoRow != null)
                        {
                            goods.PartsQty = targetPartsInfoRow.PartsQty;
                        }
                    }
                }
                // --- ADD 2014/05/16 T.Nishi ----------<<<<<
            }
            switch (rowToProcess.GoodsKindResolved)
            {
                //-----ADD 2011/11/24----->>>>>
                case (int)GoodsKind.Parent:
                    if (rowToProcess.GoodsKind == (int)GoodsKind.Join)
                    {
                        goods.JoinQty = rowToProcess.QTY;
                    }
                    break;
                //-----ADD 2011/11/24-----<<<<<
                case (int)GoodsKind.Join:
                    goods.JoinQty = rowToProcess.QTY;
                    break;
                case (int)GoodsKind.Set:
                    goods.SetQty = rowToProcess.QTY;
                    break;
                case (int)GoodsKind.Subst:
                case (int)GoodsKind.SubstPlrl:
                    // 2009.06.23 >>>
                    //goods.PartsQty = rowToProcess.QTY;
                    if (goods.PartsQty <= 0)
                    {
                        goods.PartsQty = rowToProcess.QTY;
                    }
                    // 2009.06.23 <<<
                    break;
            }
            // ADD  許雁波 2015/05/12 Redmine 45802の対応 ----->>>>>
            if (goods.PartsQty <= 0) goods.PartsQty = rowToProcess.QTY;
            if (goods.PartsQty <= 0) goods.PartsQty = 1;
            // ADD  許雁波 2015/05/12 Redmine 45802の対応 -----<<<<<

            List<GoodsPrice> priceList = new List<GoodsPrice>();
            // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
            //// ADD 2015/01/07 メーカー希望小売価格対応 --------------------->>>>>
            //List<GoodsPrice> mkrSuggestRtPricList = new List<GoodsPrice>(); // メーカー希望小売価格リスト
            //// ADD 2015/01/07 メーカー希望小売価格対応 ---------------------<<<<<
            // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

            UsrGoodsPriceRow[] rowPrice = (UsrGoodsPriceRow[])rowToProcess.GetChildRows("UsrGoodsInfo_UsrGoodsPrice");
            for (int j = 0; j < rowPrice.Length; j++)
            {
                GoodsPrice prc = new GoodsPrice();
                prc.CreateDateTime = new DateTime(rowPrice[j].CreateDateTime);
                prc.UpdateDateTime = new DateTime(rowPrice[j].UpdateDateTime);
                prc.EnterpriseCode = rowPrice[j].EnterpriseCode;
                if (rowPrice[j].IsFileHeaderGuidNull() == false)
                    prc.FileHeaderGuid = rowPrice[j].FileHeaderGuid;
                prc.UpdAssemblyId1 = rowPrice[j].UpdAssemblyId1;
                prc.UpdAssemblyId2 = rowPrice[j].UpdAssemblyId2;
                prc.UpdEmployeeCode = rowPrice[j].UpdEmployeeCode;
                prc.LogicalDeleteCode = rowPrice[j].LogicalDeleteCode;

                prc.GoodsMakerCd = rowPrice[j].GoodsMakerCd;
                prc.GoodsNo = rowPrice[j].GoodsNo;
                prc.ListPrice = rowPrice[j].ListPrice;
                prc.OpenPriceDiv = rowPrice[j].OpenPriceDiv;
                prc.PriceStartDate = rowPrice[j].PriceStartDate;
                prc.SalesUnitCost = rowPrice[j].SalesUnitCost;
                prc.StockRate = rowPrice[j].StockRate;
                if (rowPrice[j].IsUpdateDateNull() == false)
                {
                    prc.UpdateDate = rowPrice[j].UpdateDate;
                }
                else
                {
                    prc.UpdateDate = DateTime.MinValue;
                }
                prc.OfferDate = rowPrice[j].OfferDate;
                priceList.Add(prc);
                // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
                //// ADD 2015/01/07 メーカー希望小売価格対応 --------------------->>>>>
                //// メーカー希望小売価格リストを生成
                //GoodsPrice prc2 = prc.Clone();
                //prc2.ListPrice = rowPrice[j].MkrSuggestRtPric; // メーカー希望小売価格
                //mkrSuggestRtPricList.Add(prc2);
                //// ADD 2015/01/07 メーカー希望小売価格対応 ---------------------<<<<<
                // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<
            }
            goods.GoodsPriceList = priceList;

            // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 ------------------------------------->>>>>
            //// ADD 2015/01/07 メーカー希望小売価格対応 --------------------->>>>>
            //goods.MkrSuggestRtPricList = mkrSuggestRtPricList;
            //// ADD 2015/01/07 メーカー希望小売価格対応 ---------------------<<<<<
            // DEL 2015/03/18 SCM高速化 メーカー希望小売価格対応 -------------------------------------<<<<<

            List<Stock> stockList = new List<Stock>();
            StockRow[] stockRow = (StockRow[])rowToProcess.GetChildRows("UsrGoodsInfo_Stock");
            for (int j = 0; j < stockRow.Length; j++)
            {
                stockList.Add(GetStockFromStockRow(stockRow[j]));
            }
            goods.StockList = stockList;

            //>>>2010/07/09
            if (!string.IsNullOrEmpty(goods.GoodsNameKana)) goods.GoodsName = goods.GoodsNameKana;
            //<<<2010/07/09

            return goods;
        }

        #endregion

        #region [ リスト→データセット（旧商品検索から選択UIにデータを表示させるため） ]
        /// <summary>
        /// 商品リストからデータセット作成
        /// </summary>
        /// <param name="goodsList">商品リスト</param>
        /// <returns>true:成功／false:失敗</returns>
        public bool SetGoodsListToDataSet(ArrayList goodsList)
        {
            Clear();
            //tableUsrGoodsInfo.Clear();
            //tableStock.Clear();
            try
            {
                foreach (GoodsUnitData goods in goodsList)
                {
                    UsrGoodsInfoRow usrGoodsRow = tableUsrGoodsInfo.NewUsrGoodsInfoRow();

                    usrGoodsRow.BlGoodsCode = goods.BLGoodsCode;
                    usrGoodsRow.CreateDateTime = goods.CreateDateTime.Ticks;
                    usrGoodsRow.DisplayOrder = goods.DisplayOrder;
                    usrGoodsRow.EnterpriseCode = goods.EnterpriseCode;
                    usrGoodsRow.EnterpriseGanreCode = goods.EnterpriseGanreCode;
                    usrGoodsRow.FileHeaderGuid = goods.FileHeaderGuid;
                    usrGoodsRow.GoodsKind = (int)GoodsKind.Parent;
                    //usrGoodsRow.OfferKubun = goods.OfferKubun;
                    usrGoodsRow.GoodsKindCode = goods.GoodsKindCode;
                    usrGoodsRow.GoodsMakerCd = goods.GoodsMakerCd;
                    usrGoodsRow.GoodsMakerNm = goods.MakerName;
                    usrGoodsRow.GoodsMGroup = goods.GoodsMGroup;
                    usrGoodsRow.GoodsName = goods.GoodsName;
                    usrGoodsRow.GoodsNameKana = goods.GoodsNameKana;
                    usrGoodsRow.GoodsNo = goods.GoodsNo;
                    usrGoodsRow.GoodsNoNoneHyphen = goods.GoodsNoNoneHyphen;
                    usrGoodsRow.GoodsNote1 = goods.GoodsNote1;
                    usrGoodsRow.GoodsNote2 = goods.GoodsNote2;
                    usrGoodsRow.GoodsRateRank = goods.GoodsRateRank;
                    usrGoodsRow.GoodsSpecialNote = goods.GoodsSpecialNote;
                    usrGoodsRow.Jan = goods.Jan;
                    usrGoodsRow.LogicalDeleteCode = goods.LogicalDeleteCode;
                    usrGoodsRow.OfferDate = goods.OfferDate;
                    usrGoodsRow.TaxationDivCd = goods.TaxationDivCd;
                    usrGoodsRow.UpdAssemblyId1 = goods.UpdAssemblyId1;
                    usrGoodsRow.UpdAssemblyId2 = goods.UpdAssemblyId2;
                    usrGoodsRow.UpdateDate = goods.UpdateDate;
                    usrGoodsRow.UpdateDateTime = goods.UpdateDateTime.Ticks;
                    usrGoodsRow.UpdEmployeeCode = goods.UpdEmployeeCode;

                    tableUsrGoodsInfo.AddUsrGoodsInfoRow(usrGoodsRow);

                    foreach (GoodsPrice goodsPrice in goods.GoodsPriceList)
                    {
                        UsrGoodsPriceRow usrPriceRow = UsrGoodsPrice.NewUsrGoodsPriceRow();

                        usrPriceRow.CreateDateTime = goodsPrice.CreateDateTime.Ticks;
                        usrPriceRow.EnterpriseCode = goodsPrice.EnterpriseCode;
                        usrPriceRow.FileHeaderGuid = goodsPrice.FileHeaderGuid;
                        usrPriceRow.GoodsMakerCd = goodsPrice.GoodsMakerCd;
                        usrPriceRow.GoodsNo = goodsPrice.GoodsNo;
                        usrPriceRow.ListPrice = goodsPrice.ListPrice;
                        usrPriceRow.LogicalDeleteCode = goodsPrice.LogicalDeleteCode;
                        usrPriceRow.OfferDate = goodsPrice.OfferDate;
                        usrPriceRow.OpenPriceDiv = goodsPrice.OpenPriceDiv;
                        usrPriceRow.PriceStartDate = goodsPrice.PriceStartDate;
                        usrPriceRow.SalesUnitCost = goodsPrice.SalesUnitCost;
                        usrPriceRow.StockRate = goodsPrice.StockRate;
                        usrPriceRow.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1;
                        usrPriceRow.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2;
                        usrPriceRow.UpdateDate = goodsPrice.UpdateDate;
                        usrPriceRow.UpdateDateTime = goodsPrice.UpdateDateTime.Ticks;
                        usrPriceRow.UpdEmployeeCode = goodsPrice.UpdEmployeeCode;
                        usrPriceRow.UsrGoodsInfoRowParent = usrGoodsRow;

                        UsrGoodsPrice.AddUsrGoodsPriceRow(usrPriceRow);
                    }

                    foreach (Stock goodsStock in goods.StockList)
                    {
                        StockRow usrStockRow = tableStock.NewStockRow();

                        usrStockRow.AcpOdrCount = goodsStock.AcpOdrCount;
                        usrStockRow.ArrivalCnt = goodsStock.ArrivalCnt;
                        usrStockRow.CreateDateTime = goodsStock.CreateDateTime;
                        usrStockRow.DuplicationShelfNo1 = goodsStock.DuplicationShelfNo1;
                        usrStockRow.DuplicationShelfNo2 = goodsStock.DuplicationShelfNo2;
                        usrStockRow.EnterpriseCode = goodsStock.EnterpriseCode;
                        usrStockRow.FileHeaderGuid = goodsStock.FileHeaderGuid;
                        usrStockRow.GoodsMakerCd = goodsStock.GoodsMakerCd;
                        usrStockRow.GoodsNo = goodsStock.GoodsNo;
                        usrStockRow.GoodsNoNoneHyphen = goodsStock.GoodsNoNoneHyphen;
                        usrStockRow.LastInventoryUpdate = goodsStock.LastInventoryUpdate;
                        usrStockRow.LastSalesDate = goodsStock.LastSalesDate;
                        usrStockRow.LastStockDate = goodsStock.LastStockDate;
                        usrStockRow.LogicalDeleteCode = goodsStock.LogicalDeleteCode;
                        usrStockRow.MaximumStockCnt = goodsStock.MaximumStockCnt;
                        usrStockRow.MinimumStockCnt = goodsStock.MinimumStockCnt;
                        usrStockRow.MonthOrderCount = goodsStock.MonthOrderCount;
                        usrStockRow.MovingSupliStock = goodsStock.MovingSupliStock;
                        usrStockRow.NmlSalOdrCount = goodsStock.NmlSalOdrCount;
                        usrStockRow.PartsManagementDivide1 = goodsStock.PartsManagementDivide1;
                        usrStockRow.PartsManagementDivide2 = goodsStock.PartsManagementDivide2;
                        usrStockRow.SalesOrderCount = goodsStock.SalesOrderCount;
                        usrStockRow.SalesOrderUnit = goodsStock.SalesOrderUnit;
                        usrStockRow.SectionCode = goodsStock.SectionCode;
                        usrStockRow.ShipmentCnt = goodsStock.ShipmentCnt;
                        usrStockRow.ShipmentPosCnt = goodsStock.ShipmentPosCnt;
                        usrStockRow.StockCreateDate = goodsStock.StockCreateDate;
                        usrStockRow.StockDiv = goodsStock.StockDiv;
                        usrStockRow.StockNote1 = goodsStock.StockNote1;
                        usrStockRow.StockNote2 = goodsStock.StockNote2;
                        usrStockRow.StockSupplierCode = goodsStock.StockSupplierCode;
                        usrStockRow.StockTotalPrice = goodsStock.StockTotalPrice;
                        usrStockRow.StockUnitPriceFl = goodsStock.StockUnitPriceFl;
                        usrStockRow.SupplierStock = goodsStock.SupplierStock;
                        usrStockRow.UpdAssemblyId1 = goodsStock.UpdAssemblyId1;
                        usrStockRow.UpdAssemblyId2 = goodsStock.UpdAssemblyId2;
                        usrStockRow.UpdateDate = goodsStock.UpdateDate;
                        usrStockRow.UpdateDateTime = goodsStock.UpdateDateTime;
                        usrStockRow.UpdEmployeeCode = goodsStock.UpdEmployeeCode;
                        usrStockRow.WarehouseCode = goodsStock.WarehouseCode;
                        usrStockRow.WarehouseName = goodsStock.WarehouseName;
                        usrStockRow.WarehouseShelfNo = goodsStock.WarehouseShelfNo;
                        usrStockRow.UsrGoodsInfoRowParent = usrGoodsRow;

                        tableStock.AddStockRow(usrStockRow);
                    }
                }
                _goodsList = (ArrayList)goodsList.Clone();
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

        #region [ 単価設定処理 ]
        /// <summary>
        /// 単価設定
        /// </summary>
        /// <param name="lstUnitPrice">単価リスト</param>
        ///// <param name="priceDate">価格適用日</param>
        public void SetUnitPriceInfo(List<UnitPriceCalcRet> lstUnitPrice)
        {
            int cnt = lstUnitPrice.Count;
            for (int i = 0; i < cnt; i++)
            {
                UnitPriceCalcRet unitPriceInfo = lstUnitPrice[i];
                UsrGoodsInfoRow row = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(unitPriceInfo.GoodsMakerCd, unitPriceInfo.GoodsNo);
                if (row != null)
                {
                    switch (unitPriceInfo.UnitPriceKind)
                    {
                        case UnitPriceCalculation.ctUnitPriceKind_ListPrice: // 定価
                            row.PriceTaxExc = unitPriceInfo.UnitPriceTaxExcFl;
                            row.PriceTaxInc = unitPriceInfo.UnitPriceTaxIncFl; // 総額表示用
                            row.RateDivLPrice = unitPriceInfo.RateSettingDivide; // 掛率設定区分(定価) // ADD 2009/10/19

                            break;
                        case UnitPriceCalculation.ctUnitPriceKind_SalesUnitPrice: // 売上単価
                            row.SalesUnitPriceTaxExc = unitPriceInfo.UnitPriceTaxExcFl;
                            row.SalesUnitPriceTaxInc = unitPriceInfo.UnitPriceTaxIncFl; // 総額表示用
                            row.RateDivSalUnPrc = unitPriceInfo.RateSettingDivide; // 掛率設定区分（売上単価）  // 2009/12/10 ② Add 
                            break;
                        case UnitPriceCalculation.ctUnitPriceKind_UnitCost: // 原価単価
                            row.UnitCostTaxExc = unitPriceInfo.UnitPriceTaxExcFl;
                            row.UnitCostTaxInc = unitPriceInfo.UnitPriceTaxIncFl; // 総額表示用
                            row.RateDivUnCst = unitPriceInfo.RateSettingDivide; // 掛率設定区分（原価単価）  // 2009/12/10 ② Add 
                            break;
                    }
                }
            }
            tableUsrGoodsInfo.AcceptChanges();
        }
        #endregion

        #region [ その他メソッド ]

        /// <summary>
        /// 結合先品のQtyを取得する
        /// </summary>
        /// <param name="joinSrcMakerCd">結合元品メーカーコード</param>
        /// <param name="joinSrcPartsNo">結合元品番</param>
        /// <param name="joinDestMakerCd">結合先品メーカーコード</param>
        /// <param name="joinDestPartsNo">結合先品番</param>
        /// <returns>Qty(結合マスタにQtyがあればその値を、なければ結合元品のQtyを返す。どちでも0なら1にする)</returns>
        public double GetJoinQty(int joinSrcMakerCd, string joinSrcPartsNo, int joinDestMakerCd, string joinDestPartsNo)
            {
                double retQty = 1;
                string query = string.Format("{0}={1} AND {2}='{3}' AND {4}={5} AND {6}='{7}'",
                    tableUsrJoinParts.JoinSourceMakerCodeColumn.ColumnName, joinSrcMakerCd,
                    tableUsrJoinParts.JoinSrcPartsNoWithHColumn.ColumnName, joinSrcPartsNo,
                    tableUsrJoinParts.JoinDestMakerCdColumn.ColumnName, joinDestMakerCd,
                    tableUsrJoinParts.JoinDestPartsNoColumn.ColumnName, joinDestPartsNo);
                UsrJoinPartsRow[] row = (UsrJoinPartsRow[])tableUsrJoinParts.Select(query);
                
                if (row.Length != 0 )
                {
                    if (row[0].JoinQty == 0)
                    {
                        UsrGoodsInfoRow rowGoods = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(joinSrcMakerCd, joinSrcPartsNo);
                        if (rowGoods != null && rowGoods.QTY != 0)
                        {
                            retQty = rowGoods.QTY;
                        }
                    }
                    else
                    {
                        retQty = row[0].JoinQty;
                    }
                }
                return retQty;
            }

        internal int GetIntFromDt(DateTime dt)
        {
            return (dt.Year * 10000 + dt.Month * 100 + dt.Day);
        }

        /// <summary>
        /// データセットクリア処理
        /// </summary>
        public new void Clear()
        {
            lstSelInf.Clear();
            joinSrcSelInf = null;
            setSrcSelInf = null;
            substSrcSelInf = null;
            goodsNoSel = string.Empty;
            base.Clear();
        }
        #endregion

        // 2009.02.10 Add >>>
        #region [ 価格セット、単価算出関係のメソッド ]

        /// <summary>
        /// データセットからGoodsUnitDataのArrayListを取得
        /// </summary>
        /// <param name="goodsPrimaryKeyList">商品プライマリキーリスト</param>
        /// <param name="goodsUnitDataList">商品連結データリスト</param>
        /// <param name="usrGoodsInfoRowList"></param>
        // 2009/12/10 ②　>>>
        //private List<GoodsUnitData> GetGoodsList(List<GoodsPrimaryKey> goodsPrimaryKeyList)
        private void GetGoodsList(List<GoodsPrimaryKey> goodsPrimaryKeyList, out List<GoodsUnitData> goodsUnitDataList, out List<PartsInfoDataSet.UsrGoodsInfoRow> usrGoodsInfoRowList)
        // 2009/12/10 ②　<<<
        {
            // 2009/12/10 ②　>>>
            //List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            goodsUnitDataList = new List<GoodsUnitData>();
            usrGoodsInfoRowList = new List<UsrGoodsInfoRow>();
            // 2009/12/10 ②　<<<
            foreach (GoodsPrimaryKey goodsPrimaryKey in goodsPrimaryKeyList)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(goodsPrimaryKey.GoodsMakerCd, goodsPrimaryKey.GoodsNo);
                if (row.CalcPrice) continue;
                // 2009/12/10 ②　>>>
                usrGoodsInfoRowList.Add(row);
                // 2009/12/10 ②　<<<
                row.CalcPrice = true;
                GoodsUnitData goods = GetGUDFromDR( row, false, 0 );
                goodsUnitDataList.Add(goods.Clone());
            }
            //return goodsUnitDataList;     // 2009/12/10 ②　Del
        }

        /// <summary>
        /// 初期標準価格設定処理
        /// </summary>
        public bool SettingDefaultListPrice(List<GoodsPrimaryKey> goodsPrimaryKeyList)
        {
            if (this.CalculatePrice == null || PriceApplyDate == DateTime.MinValue) return false;

            this.SettingDefaultListPriceProc(goodsPrimaryKeyList);
            return true;
        }

        /// <summary>
        /// 単価設定処理
        /// </summary>
        /// <param name="goodsPrimaryKeyList"></param>
        public bool SettingGoodsPrice(List<GoodsPrimaryKey> goodsPrimaryKeyList)
        {
            if (this.CalculateGoodsPrice == null) return false;

            this.CalculateUnitPriceProc(goodsPrimaryKeyList);

            return true;
        }

        /// <summary>
        /// 単価計算処理
        /// </summary>
        /// <param name="goodsPrimaryKeyList"></param>
        private void CalculateUnitPriceProc(List<GoodsPrimaryKey> goodsPrimaryKeyList)
        {
            // 2009/12/10 ②　>>>
            //List<GoodsUnitData> goodsUnitDataList = this.GetGoodsList(goodsPrimaryKeyList);
            List<GoodsUnitData> goodsUnitDataList;
            List<PartsInfoDataSet.UsrGoodsInfoRow> usrGoodsInfoRowList;
            this.GetGoodsList(goodsPrimaryKeyList, out goodsUnitDataList, out usrGoodsInfoRowList);
            // 2009/12/10 ②　<<<

            if (goodsUnitDataList != null && goodsUnitDataList.Count > 0)
            {
                List<UnitPriceCalcRet> unitPriceCalcRetList;
                this.CalculateGoodsPrice(goodsUnitDataList, out unitPriceCalcRetList);

                if (unitPriceCalcRetList != null && unitPriceCalcRetList.Count > 0)
                    this.SetUnitPriceInfo(unitPriceCalcRetList);

                // 2009/12/10 ② Add >>>
                // 売価未設定時「定価を使用する」場合
                if (this._unPrcNonSettingDiv == 1)
                {
                    foreach (PartsInfoDataSet.UsrGoodsInfoRow row in usrGoodsInfoRowList)
                    {
                        // 売価がセットされなかった場合
                        if (string.IsNullOrEmpty(row.RateDivSalUnPrc))
                        {
                            row.SalesUnitPriceTaxExc = row.PriceTaxExc; // 税抜き単価
                            row.SalesUnitPriceTaxInc = row.PriceTaxInc; // 税込み単価
                        }
                    }
                }
                // 2009/12/10 ② Add <<<
            }
        }

        /// <summary>
        /// 初期標準価格設定処理
        /// </summary>
        /// <param name="goodsPrimaryKeyList"></param>
        private void SettingDefaultListPriceProc(List<GoodsPrimaryKey> goodsPrimaryKeyList)
        {
            foreach (GoodsPrimaryKey key in goodsPrimaryKeyList)
            {
                PartsInfoDataSet.UsrGoodsInfoRow row = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(key.GoodsMakerCd, key.GoodsNo);

                if (row == null) continue;

                // 価格情報から、対象商品の価格で価格適用日が該当する情報を取得する
                // 2009/12/14 ②　>>>
                //string filter = string.Format("{0}='{1}' AND {2}={3} AND {4} < '{5}'",
                // upd 2012/08/10 >>>
                //string filter = string.Format("{0}='{1}' AND {2}={3} AND {4} <= '{5}'",
                string filter = string.Format("convert({0},'System.String') = '{1}' AND {2}={3} AND {4} <= '{5}'",
                // upd 2012/08/10 <<<
                // 2009/12/14 ②　<<<
                    tableUsrGoodsPrice.GoodsNoColumn.ColumnName,
                    row.GoodsNo,
                    tableUsrGoodsPrice.GoodsMakerCdColumn.ColumnName,
                    row.GoodsMakerCd,
                    tableUsrGoodsPrice.PriceStartDateColumn.ColumnName,
                    _priceApplyDate);

                // 価格適用日の大きい方から並べる（selectしたデータの先頭が該当データ）
                string sort = string.Format("{0} DESC", tableUsrGoodsPrice.PriceStartDateColumn.ColumnName);

                UsrGoodsPriceRow[] usrGoodsPriceRows = (UsrGoodsPriceRow[])tableUsrGoodsPrice.Select(filter, sort);

                if (usrGoodsPriceRows != null && usrGoodsPriceRows.Length > 0)
                {
                    double listPriceTaxInc, listPriceTaxExc;
                    this.CalculatePriceCall(row.TaxationDivCd, usrGoodsPriceRows[0].ListPrice, out listPriceTaxExc, out listPriceTaxInc);
                    row.PriceTaxExc = listPriceTaxExc;
                    row.PriceTaxInc = listPriceTaxInc;
                }
            }
        }

        /// <summary>
        /// 価格計算イベントコール
        /// </summary>
        /// <param name="taxationCode">課税区分</param>
        /// <param name="listPrice">標準価格</param>
        /// <param name="listPriceTaxExc">税抜き標準価格</param>
        /// <param name="listPriceTaxInc">税込み標準価格</param>
        private void CalculatePriceCall(int taxationCode, double listPrice, out double listPriceTaxExc, out double listPriceTaxInc)
        {
            listPriceTaxInc = listPriceTaxExc = listPrice;
            if (this.CalculatePrice != null)
            {
                this.CalculatePrice(taxationCode, listPrice, out listPriceTaxExc, out listPriceTaxInc);
            }
        }
        #endregion
        // 2009.02.10 Add <<<

        //-------2009/10/19------------>>>>>
        #region [結合元セット、得意先掛率グループコードセット、標準価格選択区分セット処理関係のメソッド]
        /// <summary>
        /// 結合元検索情報の設定処理
        /// </summary>
        /// <param name="goodsCndtn">商品抽出条件クラス</param>
        public bool SettingSrcPartsInfo(GoodsCndtn goodsCndtn)
        {
            if (this.SearchPartsForSrcParts == null) return false;

            this.SearchPartsForSrcPartsProc(goodsCndtn);

            return true;
        }
        /// <summary>
        /// 結合元検索情報の設定処理
        /// </summary>
        /// <param name="goodsCndtn">商品抽出条件クラス</param>
        private void SearchPartsForSrcPartsProc(GoodsCndtn goodsCndtn)
        {
            if (goodsCndtn != null)
            {
                PartsInfoDataSet partsInfoDataSet;
                List<GoodsUnitData> goodsUnitDataList;
                string msg;
                //-------UPD 2009/11/05------->>>>>
                this.SearchPartsForSrcParts(1, goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg);
                if (partsInfoDataSet != null)
                {
                    List<PartsInfoDataSet.GoodsPrimaryKey> goodsPrimaryKeyList = new List<PartsInfoDataSet.GoodsPrimaryKey>();
                    if ((partsInfoDataSet.UsrGoodsInfo != null) && (partsInfoDataSet.UsrGoodsInfo.Count > 0))
                    {
                        for (int i = 0; i < partsInfoDataSet.UsrGoodsInfo.Count; i++)
                        {
                            goodsPrimaryKeyList.Add(new PartsInfoDataSet.GoodsPrimaryKey(partsInfoDataSet.UsrGoodsInfo[i].GoodsNo, partsInfoDataSet.UsrGoodsInfo[i].GoodsMakerCd));
                        }
                        partsInfoDataSet.SettingDefaultListPrice(goodsPrimaryKeyList);
                        this._partsInfoDataSetSrcParts = partsInfoDataSet;
                    }
                    else
                    {
                        this._partsInfoDataSetSrcParts = null;

                    }

                }
                //-------UPD 2009/11/05-------<<<<<
                else
                {
                    this._partsInfoDataSetSrcParts = null;
                }

            }
        }

        /// <summary>
        /// 得意先掛率グループコード取得処理
        /// </summary>
        /// <param name="custRateGrpCodeList">得意先掛率グループコードリスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsNo"> 品番</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        public bool SettingCustRateGrpCode(ArrayList custRateGrpCodeList, Int32 customerCode, string goodsNo, Int32 goodsMakerCode)
        {
            if (this.GetCustRateGrp == null) return false;

            this.GetCustRateGrpProc(custRateGrpCodeList, customerCode, goodsMakerCode, goodsNo);

            return true;
        }

        /// <summary>
        /// 得意先掛率グループコード取得処理
        /// </summary>
        /// <param name="custRateGrpCodeList">得意先掛率グループコードリスト</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="goodsNo">品番</param>
        private void GetCustRateGrpProc(ArrayList custRateGrpCodeList, Int32 customerCode, Int32 goodsMakerCode, string goodsNo)
        {
            //-------ADD 2009/11/11------->>>>>
            UsrGoodsInfoRow row = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(goodsMakerCode, goodsNo);
            if (row == null) return;
            if (custRateGrpCodeList != null)
            {
                Int32 custRateGrpCode;
                this.GetCustRateGrp(custRateGrpCodeList, customerCode, goodsMakerCode, out custRateGrpCode);
                row.CustRateGrpCode = custRateGrpCode;
                tableUsrGoodsInfo.AcceptChanges();
            }
            else
            {
                row.CustRateGrpCode = 0;
                tableUsrGoodsInfo.AcceptChanges();
            }
            //-------ADD 2009/11/11-------<<<<<
        }

        /// <summary>
        /// 標準価格選択区分取得処理
        /// </summary>
        /// <param name="priceSelectDivList">標準価格選択区分リスト</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        public bool SettingDisplayDiv(List<PriceSelectSet> priceSelectDivList, string goodsNo, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode)
        {
            if (this.GetDisplayDiv == null) return false;
            this.GetDisplayDivProc(priceSelectDivList, goodsMakerCode, blGoodsCode, customerCode, custRateGrpCode, goodsNo);

            return true;
        }

        /// <summary>
        /// 標準価格選択区分取得処理
        /// </summary>
        /// <param name="priceSelectDivList">標準価格選択区分リスト</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="goodsMakerCode">メーカーコード</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="custRateGrpCode">得意先掛率グループコード</param>
        private void GetDisplayDivProc(List<PriceSelectSet> priceSelectDivList, Int32 goodsMakerCode, Int32 blGoodsCode, Int32 customerCode, Int32 custRateGrpCode, string goodsNo)
        {
            //-------ADD 2009/11/11------->>>>>
            UsrGoodsInfoRow row = tableUsrGoodsInfo.FindByGoodsMakerCdGoodsNo(goodsMakerCode, goodsNo);
            if (row == null) return;

            if (priceSelectDivList != null)
            {
                Int32 priceSelectDiv;
                this.GetDisplayDiv(priceSelectDivList, goodsMakerCode, blGoodsCode, customerCode, custRateGrpCode, out priceSelectDiv);
                row.PriceSelectDiv = priceSelectDiv;
                tableUsrGoodsInfo.AcceptChanges();

            }
            else
            {
                row.PriceSelectDiv = -1;
                tableUsrGoodsInfo.AcceptChanges();
            }
            //-------ADD 2009/11/11-------<<<<<
        }
        #endregion
        //-------2009/10/19------------<<<<<

        // ADD 2010/05/17 品名表示対応 ---------->>>>>
        /// <summary>
        /// BL商品情報取得
        /// </summary>
        /// <param name="blGoodsCode">BLコード</param>
        public delegate BLGoodsCdUMnt GetBLGoodsInfoCallBack( int blGoodsCode );

        /// <summary>
        /// BL商品情報取得イベント
        /// </summary>
        public GetBLGoodsInfoCallBack GetBLGoodsInfo;

        #region 品名表示パターン

        #region BLコード検索品名表示区分

        /// <summary>BLコード検索品名表示区分１</summary>
        private int _blCdPrtsNmDspDivCd1;
        /// <summary>BLコード検索品名表示区分１を取得または設定します。</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private int BLCdPrtsNmDspDivCd1
        {
            get { return _blCdPrtsNmDspDivCd1; }
            set { _blCdPrtsNmDspDivCd1 = value; }
        }

        /// <summary>BLコード検索品名表示区分２</summary>
        private int _blCdPrtsNmDspDivCd2;
        /// <summary>BLコード検索品名表示区分２を取得または設定します。</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private int BLCdPrtsNmDspDivCd2
        {
            get { return _blCdPrtsNmDspDivCd2; }
            set { _blCdPrtsNmDspDivCd2 = value; }
        }

        /// <summary>BLコード検索品名表示区分３</summary>
        private int _blCdPrtsNmDspDivCd3;
        /// <summary>BLコード検索品名表示区分３を取得または設定します。</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private int BLCdPrtsNmDspDivCd3
        {
            get { return _blCdPrtsNmDspDivCd3; }
            set { _blCdPrtsNmDspDivCd3 = value; }
        }

        /// <summary>BLコード検索品名表示区分４</summary>
        private int _blCdPrtsNmDspDivCd4;
        /// <summary>BLコード検索品名表示区分４を取得または設定します。</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private int BLCdPrtsNmDspDivCd4
        {
            get { return _blCdPrtsNmDspDivCd4; }
            set { _blCdPrtsNmDspDivCd4 = value; }
        }

        #endregion // BLコード検索品名表示区分

        #region 品番検索品名表示区分

        /// <summary>品番検索品名表示区分１</summary>
        private int _gdNoPrtsNmDspDivCd1;
        /// <summary>品番検索品名表示区分１を取得または設定します。</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private int GdNoPrtsNmDspDivCd1
        {
            get { return _gdNoPrtsNmDspDivCd1; }
            set { _gdNoPrtsNmDspDivCd1 = value; }
        }

        /// <summary>品番検索品名表示区分２</summary>
        private int _gdNoPrtsNmDspDivCd2;
        /// <summary>品番検索品名表示区分２を取得または設定します。</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private int GdNoPrtsNmDspDivCd2
        {
            get { return _gdNoPrtsNmDspDivCd2; }
            set { _gdNoPrtsNmDspDivCd2 = value; }

        }

        /// <summary>品番検索品名表示区分３</summary>
        private int _gdNoPrtsNmDspDivCd3;
        /// <summary>品番検索品名表示区分３を取得または設定します。</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private int GdNoPrtsNmDspDivCd3
        {
            get { return _gdNoPrtsNmDspDivCd3; }
            set { _gdNoPrtsNmDspDivCd3 = value; }

        }

        /// <summary>品番検索品名表示区分４</summary>
        private int _gdNoPrtsNmDspDivCd4;
        /// <summary>品番検索品名表示区分４を取得または設定します。</summary>
        /// <remarks>0:無し　1:商品マスタ　2:部品マスタ　3:検索品名マスタ　4:BLコードマスタ</remarks>
        private int GdNoPrtsNmDspDivCd4
        {
            get { return _gdNoPrtsNmDspDivCd4; }
            set { _gdNoPrtsNmDspDivCd4 = value; }
        }

        #endregion // 品番検索品名表示区分

        #region 優良部品検索品名使用区分

        /// <summary>優良部品検索品名使用区分</summary>
        private int _prmPrtsNmUseDivCd;
        /// <summary>優良部品検索品名使用区分を取得または設定します。</summary>
        /// <remarks>0:使用 1:未使用</remarks>
        private int PrmPrtsNmUseDivCd
        {
            get { return _prmPrtsNmUseDivCd; }
            set { _prmPrtsNmUseDivCd = value; }
        }

        #endregion // 優良部品検索品名使用区分

        /// <summary>
        /// 品名表示パターン
        /// (品名表示区分、BLコード検索品名表示区分、品番検索品名表示区分、優良部品検索品名使用区分)
        /// を設定します。
        /// </summary>
        /// <param name="salesTtlSt">売上全体設定</param>
        public void SetPartsNameDisplayPattern( SalesTtlSt salesTtlSt )
        {
            PartsNameDspDivCd = salesTtlSt.PartsNameDspDivCd;       // 品名表示区分
            BLCdPrtsNmDspDivCd1 = salesTtlSt.BLCdPrtsNmDspDivCd1;   // BLコード検索品名表示区分1
            BLCdPrtsNmDspDivCd2 = salesTtlSt.BLCdPrtsNmDspDivCd2;   // BLコード検索品名表示区分2
            BLCdPrtsNmDspDivCd3 = salesTtlSt.BLCdPrtsNmDspDivCd3;   // BLコード検索品名表示区分3
            BLCdPrtsNmDspDivCd4 = salesTtlSt.BLCdPrtsNmDspDivCd4;   // BLコード検索品名表示区分4
            GdNoPrtsNmDspDivCd1 = salesTtlSt.GdNoPrtsNmDspDivCd1;   // 品番検索品名表示区分1
            GdNoPrtsNmDspDivCd2 = salesTtlSt.GdNoPrtsNmDspDivCd2;   // 品番検索品名表示区分2
            GdNoPrtsNmDspDivCd3 = salesTtlSt.GdNoPrtsNmDspDivCd3;   // 品番検索品名表示区分3
            GdNoPrtsNmDspDivCd4 = salesTtlSt.GdNoPrtsNmDspDivCd4;   // 品番検索品名表示区分4
            PrmPrtsNmUseDivCd = salesTtlSt.PrmPrtsNmUseDivCd;       // 優良部品検索品名使用区分
        }

        /// <summary>
        /// 品名表示パターンに応じた品名の選択者を生成します。
        /// </summary>
        /// <param name="searchingMethod">検索方法</param>
        /// <param name="userGoodsInfoRow">部品情報</param>
        /// <param name="isPluralCompatibleSubset">複数互換（サブ）フラグ</param>
        /// <param name="joinSourceRow">結合元部品情報</param>
        /// <returns>品名表示パターンに応じた品名の選択者</returns>
        private GoodsNameSelector CreateGoodsNameSelector(
            int searchingMethod,
            UsrGoodsInfoRow userGoodsInfoRow,
            bool isPluralCompatibleSubset,
            UsrGoodsInfoRow joinSourceRow
        )
        {
            GoodsNameSelector goodsNameSelector = null;
            {
                if ( !GoodsNameSelector.IsSearchingByGoodsNo( searchingMethod ) )
                {
                    // BLコード検索
                    #region BLコード検索品名表示区分で生成

                    goodsNameSelector = GoodsNameSelectorFactory.Create(
                        BLCdPrtsNmDspDivCd1,    // BLコード検索品名表示区分1
                        userGoodsInfoRow,
                        isPluralCompatibleSubset,
                        joinSourceRow,
                        PrmPrtsNmUseDivCd,
                        searchingMethod
                    );
                    goodsNameSelector.SetNextSelector(
                        GoodsNameSelectorFactory.Create(
                            BLCdPrtsNmDspDivCd2,// BLコード検索品名表示区分2
                            userGoodsInfoRow,
                            isPluralCompatibleSubset,
                            joinSourceRow,
                            PrmPrtsNmUseDivCd,
                            searchingMethod
                        )
                    ).SetNextSelector(
                        GoodsNameSelectorFactory.Create(
                            BLCdPrtsNmDspDivCd3,// BLコード検索品名表示区分3
                            userGoodsInfoRow,
                            isPluralCompatibleSubset,
                            joinSourceRow,
                            PrmPrtsNmUseDivCd,
                            searchingMethod
                        )
                    ).SetNextSelector(
                        GoodsNameSelectorFactory.Create(
                            BLCdPrtsNmDspDivCd4,// BLコード検索品名表示区分4
                            userGoodsInfoRow,
                            isPluralCompatibleSubset,
                            joinSourceRow,
                            PrmPrtsNmUseDivCd,
                            searchingMethod
                        )
                    );

                    #endregion // BLコード検索品名表示区分で生成
                }
                else
                {
                    // 品番検索
                    #region 品番検索品名表示区分で生成

                    goodsNameSelector = GoodsNameSelectorFactory.Create(
                        GdNoPrtsNmDspDivCd1,    // 品番検索品名表示区分1
                        userGoodsInfoRow,
                        isPluralCompatibleSubset,
                        joinSourceRow,
                        PrmPrtsNmUseDivCd,
                        searchingMethod
                    );
                    goodsNameSelector.SetNextSelector(
                        GoodsNameSelectorFactory.Create(
                            GdNoPrtsNmDspDivCd2,// 品番検索品名表示区分2
                            userGoodsInfoRow,
                            isPluralCompatibleSubset,
                            joinSourceRow,
                            PrmPrtsNmUseDivCd,
                            searchingMethod
                        )
                    ).SetNextSelector(
                        GoodsNameSelectorFactory.Create(
                            GdNoPrtsNmDspDivCd3,// 品番検索品名表示区分3
                            userGoodsInfoRow,
                            isPluralCompatibleSubset,
                            joinSourceRow,
                            PrmPrtsNmUseDivCd,
                            searchingMethod
                        )
                    ).SetNextSelector(
                        GoodsNameSelectorFactory.Create(
                            GdNoPrtsNmDspDivCd4,// 品番検索品名表示区分4
                            userGoodsInfoRow,
                            isPluralCompatibleSubset,
                            joinSourceRow,
                            PrmPrtsNmUseDivCd,
                            searchingMethod
                        )
                    );

                    #endregion // 品番検索品名表示区分で生成
                }
            }
            return goodsNameSelector;
        }

        #region 品名の選択処理

        /// <summary>
        /// 検索方法の値列挙型
        /// </summary>
        private enum SearchingMethodValue : int
        {
            /// <summary>0:なし(BL検索、TBO検索等)</summary>
            None = 0,
            /// <summary>1:品番検索</summary>
            ByGoodsNo = 1,
        }

        #region 品名の選択処理：base

        /// <summary>
        /// 品名の選択処理クラス
        /// </summary>
        private abstract class GoodsNameSelector
        {
            #region 部品情報

            /// <summary>部品情報</summary>
            private readonly UsrGoodsInfoRow _userGoodsInfoRow;
            /// <summary>部品情報を取得します。</summary>
            protected UsrGoodsInfoRow UserGoodsInfoRow { get { return _userGoodsInfoRow; } }

            #endregion // 部品情報

            #region 複数互換（サブ）フラグ

            /// <summary>複数互換（サブ）フラグ</summary>
            private readonly bool _isPluralCompatibleSubset;
            /// <summary>複数互換フラグ（サブ）を取得します。</summary>
            protected bool IsPluralCompatibleSubset { get { return _isPluralCompatibleSubset; } }

            #endregion // 複数互換（サブ）フラグ

            #region 結合元部品情報

            /// <summary>結合元部品情報</summary>
            private readonly UsrGoodsInfoRow _joinSourceRow;
            /// <summary>結合元部品情報を取得します。</summary>
            protected UsrGoodsInfoRow JoinSourceRow { get { return _joinSourceRow; } }

            #endregion // 結合元部品情報

            #region 優良部品検索品名使用区分

            /// <summary>優良部品検索品名使用区分</summary>
            private readonly int _prmPrtsNmUseDivCd;
            /// <summary>優良部品検索品名使用区分を取得または設定します。</summary>
            /// <remarks>0:使用 1:未使用</remarks>
            protected int PrmPrtsNmUseDivCd { get { return _prmPrtsNmUseDivCd; } }

            #endregion // 優良部品検索品名使用区分

            #region 検索方法

            /// <summary>検索方法</summary>
            private readonly int _searchingMethod;
            /// <summary>検索方法</summary>
            /// <remarks>1:品番検索</remarks>
            protected int SearchingMethod { get { return _searchingMethod; } }

            #endregion // 品番検索フラグ

            #region 次の選択処理

            /// <summary>次の選択処理</summary>
            private GoodsNameSelector _nextSelectror;
            /// <summary>次の選択処理を取得または設定します。</summary>
            protected GoodsNameSelector NextSelectror
            {
                get { return _nextSelectror; }
                private set { _nextSelectror = value; }
            }

            /// <summary>
            /// 次の選択処理を設定します。
            /// </summary>
            /// <param name="nextSelector">次の選択処理</param>
            /// <returns><c>nextSelector</c>を返します。</returns>
            public GoodsNameSelector SetNextSelector( GoodsNameSelector nextSelector )
            {
                NextSelectror = nextSelector;
                return nextSelector;
            }

            #endregion // 次の選択処理

            #region デフォルト名称

            /// <summary>
            /// デフォルト品名を取得します。
            /// </summary>
            protected string DefaultGoodsName
            {
                get
                {
                    return string.IsNullOrEmpty( UserGoodsInfoRow.GoodsName ) ? UserGoodsInfoRow.GoodsOfrName : UserGoodsInfoRow.GoodsName;
                }
            }

            /// <summary>
            /// デフォルト品名カナを取得します。
            /// </summary>
            protected string DefaultGoodsNameKana
            {
                get
                {
                    return string.IsNullOrEmpty( UserGoodsInfoRow.GoodsName ) ? UserGoodsInfoRow.GoodsOfrNameKana : UserGoodsInfoRow.GoodsNameKana;
                }
            }

            #endregion // デフォルト名称

            /// <summary>
            /// 品番検索であるか判断します。
            /// </summary>
            /// <param name="searchingMethod">検索方法</param>
            /// <returns>
            /// <c>true</c> :品番検索です。（検索方法が 1）<br/>
            /// <c>false</c>:品番検索ではありません。
            /// </returns>
            public static bool IsSearchingByGoodsNo( int searchingMethod )
            {
                return searchingMethod.Equals( (int)SearchingMethodValue.ByGoodsNo );
            }

            /// <summary>
            /// TBO検索であるか判断します。
            /// </summary>
            /// <param name="userGoodsInfoRow">部品情報</param>
            /// <returns>
            /// <c>true</c> :TBO検索です。（<c>userGoodsInfoRow.OfferKubun</c>が 5）<br/>
            /// <c>false</c>:TBO検索ではありません。
            /// </returns>
            protected static bool IsSearchingByTBO( UsrGoodsInfoRow userGoodsInfoRow )
            {
                return userGoodsInfoRow.OfferKubun.Equals( 5 );
            }

            /// <summary>
            /// 優良部品であるか判断します。
            /// </summary>
            /// <param name="userGoodsInfoRow">部品情報</param>
            /// <returns>
            /// <c>true</c> :優良部品です。（<c>UserGoodsInfoRow.OfferKubun</c>が 2 または 4）<br/>
            /// <c>false</c>:優良部品ではありません。
            /// </returns>
            protected static bool IsPrimaryGoods( UsrGoodsInfoRow userGoodsInfoRow )
            {
                return userGoodsInfoRow.OfferKubun.Equals( 2 ) || userGoodsInfoRow.OfferKubun.Equals( 4 );
            }

            /// <summary>
            /// 純正部品であるか判断します。
            /// </summary>
            /// <param name="userGoodsInfoRow">部品情報</param>
            /// <returns>
            /// <c>true</c> :純正部品です。（<c>userGoodsInfoRow.OfferKubun</c>が 1:提供純正編集 または 3:提供純正）<br/>
            /// <c>false</c>:純正部品ではありません。
            /// </returns>
            protected static bool IsPureGoods( UsrGoodsInfoRow userGoodsInfoRow )
            {
                return userGoodsInfoRow.OfferKubun.Equals( 1 ) || userGoodsInfoRow.OfferKubun.Equals( 3 );
            }

            /// <summary>
            /// オリジナル部品(優良BL検索)であるか判断します。
            /// </summary>
            /// <param name="userGoodsInfoRow">部品情報</param>
            /// <returns>
            /// <c>true</c> :オリジナル部品(優良BL検索)です。（<c>userGoodsInfoRow.OfferKubun</c>が 7:オリジナル部品）<br/>
            /// <c>false</c>:オリジナル部品(優良BL検索)ではありません。
            /// </returns>
            protected static bool IsOriginalGoods( UsrGoodsInfoRow userGoodsInfoRow )
            {
                return userGoodsInfoRow.OfferKubun.Equals( 7 );
            }

            /// <summary>
            /// 複数互換品であるか判断します。
            /// </summary>
            /// <param name="joinSourceRow">部品情報(※通常は結合元部品情報を渡します)</param>
            /// <returns>
            /// <c>(((joinSourceRow.GoodsKind ＆ (int)GoodsKind.SubstPlrl) == (int)GoodsKind.SubstPlrl));</c>
            /// </returns>
            protected static bool IsPluralCompatible( UsrGoodsInfoRow joinSourceRow )
            {

                return joinSourceRow != null
                    &&
                (((joinSourceRow.GoodsKind & (int)GoodsKind.SubstPlrl) == (int)GoodsKind.SubstPlrl));
            }

            /// <summary>
            /// 名称を取得します。
            /// </summary>
            protected abstract string Name { get; }

            /// <summary>
            /// 品名を取得します。
            /// </summary>
            /// <param name="goodsUnitData">商品連結データ</param>
            /// <param name="getBLGoodsInfo">BLコード情報を取得するデリゲート</param>
            /// <returns>
            /// <c>Key</c>  :品名
            /// <c>Value</c>:品名(カナ)
            /// </returns>
            public abstract GoodsNamePair GetGoodsName(
                GoodsUnitData goodsUnitData,
                GetBLGoodsInfoCallBack getBLGoodsInfo
            );

            /// <summary>
            /// 文字列に変換します。
            /// </summary>
            /// <returns>品名の選択順を返します。</returns>
            public override string ToString()
            {
                StringBuilder str = new StringBuilder();
                {
                    str.Append( Name );
                    if ( NextSelectror != null )
                    {
                        str.Append( "->" ).Append( NextSelectror );
                    }
                }
                return str.ToString();
            }

            #region Constructor

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="userGoodsInfoRow">部品情報</param>
            /// <param name="isPluralCompatibleSubset">複数互換（サブ）フラグ</param>
            /// <param name="joinSourceRow">結合元部品情報</param>
            /// <param name="prmPrtsNmUseDivCd">優良部品検索品名使用区分</param>
            /// <param name="searchingMethod">検索方法</param>
            protected GoodsNameSelector(
                UsrGoodsInfoRow userGoodsInfoRow,
                bool isPluralCompatibleSubset,
                UsrGoodsInfoRow joinSourceRow,
                int prmPrtsNmUseDivCd,
                int searchingMethod
            )
            {
                _userGoodsInfoRow = userGoodsInfoRow;
                _isPluralCompatibleSubset = isPluralCompatibleSubset;
                _joinSourceRow = joinSourceRow;
                _prmPrtsNmUseDivCd = prmPrtsNmUseDivCd;
                _searchingMethod = searchingMethod;
            }

            #endregion // Constructor

            /// <summary>
            /// 選択処理の名称を表示します。
            /// </summary>
            /// <param name="name">選択処理の名称</param>
            [System.Diagnostics.Conditional( "DEBUG" )]
            protected static void PrintSelectorName( string name )
            {
                const string FORMAT = "{0} で品名を選択しました。";
                System.Diagnostics.Debug.WriteLine( string.Format( FORMAT, name ) );
            }
        }

        #endregion // 品名の選択処理：base

        #region 品名の選択処理：検索品名表示区分「0:無し」

        /// <summary>
        /// 検索品名表示区分「0:無し」の場合の品名の選択処理クラス
        /// </summary>
        private sealed class NonSelector : GoodsNameSelector
        {
            #region Constructor

            /// <summary>
            /// デフォルトコンストラクタ
            /// </summary>
            public NonSelector() : base( null, false, null, 0, 0 ) { }

            #endregion // Constructor

            /// <summary>
            /// 名称を取得します。
            /// </summary>
            /// <see cref="GoodsNameSelector"/>
            protected override string Name { get { return "「0:無し」"; } }

            /// <summary>
            /// 品名を取得します。
            /// </summary>
            /// <param name="goodsUnitData">商品連結データ</param>
            /// <param name="getBLGoodsInfo">BLコード情報を取得するデリゲート</param>
            /// <returns>
            /// <c>Key</c>  :品名
            /// <c>Value</c>:品名(カナ)
            /// </returns>
            /// <see cref="GoodsNameSelector"/>
            public override GoodsNamePair GetGoodsName(
                GoodsUnitData goodsUnitData,
                GetBLGoodsInfoCallBack getBLGoodsInfo
            )
            {
                // 1)「0:無し」
                // ・品名を取得しない
                // 次の品名の選択処理へ
                if ( NextSelectror != null )
                {
                    return NextSelectror.GetGoodsName( goodsUnitData, getBLGoodsInfo );
                }
                return new GoodsNamePair( DefaultGoodsName, DefaultGoodsNameKana );
            }
        }

        #endregion // 品名の選択処理：検索品名表示区分「0:無し」

        #region 品名の選択処理：検索品名表示区分「1:商品マスタ」

        /// <summary>
        /// 検索品名表示区分「1:商品マスタ」の場合の品名の選択処理クラス
        /// </summary>
        private sealed class GoodsMasterSelector : GoodsNameSelector
        {
            #region Constructor

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="userGoodsInfoRow">部品情報</param>
            /// <param name="isPluralCompatibleSubset">複数互換（サブ）フラグ</param>
            /// <param name="joinSourceRow">結合元部品情報</param>
            /// <param name="prmPrtsNmUseDivCd">優良部品検索品名使用区分</param>
            /// <param name="searchingMethod">検索方法</param>
            public GoodsMasterSelector(
                UsrGoodsInfoRow userGoodsInfoRow,
                bool isPluralCompatibleSubset,
                UsrGoodsInfoRow joinSourceRow,
                int prmPrtsNmUseDivCd,
                int searchingMethod
            )
                : base( userGoodsInfoRow, isPluralCompatibleSubset, joinSourceRow, prmPrtsNmUseDivCd, searchingMethod )
            { }

            #endregion // Constructor

            /// <summary>
            /// 名称を取得します。
            /// </summary>
            /// <see cref="GoodsNameSelector"/>
            protected override string Name { get { return "「1:商品マスタ」"; } }

            /// <summary>
            /// 品名を取得します。
            /// </summary>
            /// <param name="goodsUnitData">商品連結データ</param>
            /// <param name="getBLGoodsInfo">BLコード情報を取得するデリゲート</param>
            /// <returns>
            /// <c>Key</c>  :品名
            /// <c>Value</c>:品名(カナ)
            /// </returns>
            /// <see cref="GoodsNameSelector"/>
            public override GoodsNamePair GetGoodsName(
                GoodsUnitData goodsUnitData,
                GetBLGoodsInfoCallBack getBLGoodsInfo
            )
            {
                // 2)「1:商品マスタ」
                string goodsName = string.Empty;
                string goodsNameKana = string.Empty;

                if ( IsPrimaryGoods( UserGoodsInfoRow ) )
                {
                    // 優良部品の場合
                    goodsName = UserGoodsInfoRow.GoodsName;
                    goodsNameKana = UserGoodsInfoRow.GoodsNameKana;
                    if ( string.IsNullOrEmpty( goodsName ) )
                    {
                        goodsName = UserGoodsInfoRow.GoodsOfrName;
                        goodsNameKana = UserGoodsInfoRow.GoodsOfrNameKana;
                    }
                }
                else if ( IsUserGoodsMaster( UserGoodsInfoRow ) )
                {
                    // ユーザー商品マスタの場合
                    goodsName = UserGoodsInfoRow.GoodsName;
                    goodsNameKana = UserGoodsInfoRow.GoodsNameKana;
                    if ( string.IsNullOrEmpty( goodsName ) )
                    {
                        goodsName = UserGoodsInfoRow.GoodsOfrName;
                        goodsNameKana = UserGoodsInfoRow.GoodsOfrNameKana;
                    }
                }

                if ( !string.IsNullOrEmpty( goodsName ) )
                {
                    PrintSelectorName( Name );
                    return new GoodsNamePair( goodsName, goodsNameKana );
                }
                // 品名が選択できなかった場合、次の品名の選択処理へ
                if ( NextSelectror != null )
                {
                    return NextSelectror.GetGoodsName( goodsUnitData, getBLGoodsInfo );
                }
                return new GoodsNamePair( DefaultGoodsName, DefaultGoodsNameKana );
            }

            /// <summary>
            /// ユーザー商品マスタであるか判断します。
            /// </summary>
            /// <param name="userGoodsInfoRow">部品情報</param>
            /// <returns>
            /// <c>true</c> :ユーザー商品マスタです。（<c>UserGoodsInfoRow.CreateDateTime</c>が 0 でない）<br/>
            /// <c>false</c>:ユーザー商品マスタではありません。
            /// </returns>
            private static bool IsUserGoodsMaster( UsrGoodsInfoRow userGoodsInfoRow )
            {
                return !userGoodsInfoRow.CreateDateTime.Equals( 0 );
            }
        }

        #endregion // 品名の選択処理：検索品名表示区分「1:商品マスタ」

        #region 品名の選択処理：検索品名表示区分「2:部品マスタ」

        /// <summary>
        /// 検索品名表示区分「2:部品マスタ」の場合の品名の選択処理クラス
        /// </summary>
        private sealed class PartsMasterSelector : GoodsNameSelector
        {
            #region Constructor

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="userGoodsInfoRow">部品情報</param>
            /// <param name="isPluralCompatibleSubset">複数互換（サブ）フラグ</param>
            /// <param name="joinSourceRow">結合元部品情報</param>
            /// <param name="prmPrtsNmUseDivCd">優良部品検索品名使用区分</param>
            /// <param name="searchingMethod">検索方法</param>
            public PartsMasterSelector(
                UsrGoodsInfoRow userGoodsInfoRow,
                bool isPluralCompatibleSubset,
                UsrGoodsInfoRow joinSourceRow,
                int prmPrtsNmUseDivCd,
                int searchingMethod
            )
                : base( userGoodsInfoRow, isPluralCompatibleSubset, joinSourceRow, prmPrtsNmUseDivCd, searchingMethod )
            { }

            #endregion // Constructor

            /// <summary>
            /// 名称を取得します。
            /// </summary>
            /// <see cref="GoodsNameSelector"/>
            protected override string Name { get { return "「2:部品マスタ」"; } }

            /// <summary>
            /// 品名を取得します。
            /// </summary>
            /// <param name="goodsUnitData">商品連結データ</param>
            /// <param name="getBLGoodsInfo">BLコード情報を取得するデリゲート</param>
            /// <returns>
            /// <c>Key</c>  :品名
            /// <c>Value</c>:品名(カナ)
            /// </returns>
            /// <see cref="GoodsNameSelector"/>
            public override GoodsNamePair GetGoodsName(
                GoodsUnitData goodsUnitData,
                GetBLGoodsInfoCallBack getBLGoodsInfo
            )
            {
                // 3)「2:部品マスタ」
                string goodsName = string.Empty;
                string goodsNameKana = string.Empty;

                // ・優良部品の場合は取得しない
                if ( !IsPrimaryGoods( UserGoodsInfoRow ) )
                {
                    goodsName = UserGoodsInfoRow.GoodsOfrName;
                    goodsNameKana = UserGoodsInfoRow.GoodsOfrNameKana;
                }

                if ( !string.IsNullOrEmpty( goodsName ) )
                {
                    PrintSelectorName( Name );
                    return new GoodsNamePair( goodsName, goodsNameKana );
                }
                // 品名が選択できなかった場合、次の品名の選択処理へ
                if ( NextSelectror != null )
                {
                    return NextSelectror.GetGoodsName( goodsUnitData, getBLGoodsInfo );
                }
                return new GoodsNamePair( DefaultGoodsName, DefaultGoodsNameKana );
            }
        }

        #endregion // 品名の選択処理：検索品名表示区分「2:部分マスタ」

        #region 品名の選択処理：検索品名表示区分「3:検索品名マスタ」

        /// <summary>
        /// 検索品名表示区分「3:検索品名マスタ」の場合の品名の選択処理クラス
        /// </summary>
        private sealed class SearchedGoodsNameMasterSelector : GoodsNameSelector
        {
            #region Constructor

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="userGoodsInfoRow">部品情報</param>
            /// <param name="isPluralCompatibleSubset">複数互換（サブ）フラグ</param>
            /// <param name="joinSourceRow">結合元部品情報</param>
            /// <param name="prmPrtsNmUseDivCd">優良部品検索品名使用区分</param>
            /// <param name="searchingMethod">検索方法</param>
            public SearchedGoodsNameMasterSelector(
                UsrGoodsInfoRow userGoodsInfoRow,
                bool isPluralCompatibleSubset,
                UsrGoodsInfoRow joinSourceRow,
                int prmPrtsNmUseDivCd,
                int searchingMethod
            )
                : base( userGoodsInfoRow, isPluralCompatibleSubset, joinSourceRow, prmPrtsNmUseDivCd, searchingMethod )
            { }

            #endregion // Constructor

            /// <summary>
            /// 名称を取得します。
            /// </summary>
            /// <see cref="GoodsNameSelector"/>
            protected override string Name { get { return "「3:検索品名マスタ」"; } }

            /// <summary>
            /// 品名を取得します。
            /// </summary>
            /// <param name="goodsUnitData">商品連結データ</param>
            /// <param name="getBLGoodsInfo">BLコード情報を取得するデリゲート</param>
            /// <returns>
            /// <c>Key</c>  :品名
            /// <c>Value</c>:品名(カナ)
            /// </returns>
            /// <see cref="GoodsNameSelector"/>
            public override GoodsNamePair GetGoodsName(
                GoodsUnitData goodsUnitData,
                GetBLGoodsInfoCallBack getBLGoodsInfo
            )
            {
                // 4)「3:検索品名マスタ」
                string goodsName = string.Empty;
                string goodsNameKana = string.Empty;

                // ・品番検索の場合は取得しない
                if ( !IsSearchingByGoodsNo( SearchingMethod ) )
                {
                    // ・結合元部品有り、且つ結合元にメーカーコード有りの検索品名が入っている場合
                    if (
                        JoinSourceRow != null
                            &&
                        !string.IsNullOrEmpty( JoinSourceRow.SearchPartsFullName )
                            &&
                        JoinSourceRow.SrchPNmAcqrCarMkrCd != 0
                    )
                    {
                        // 優良部品検索品名使用区分が「未使用」の場合には取得しない
                        if ( PrmPrtsNmUseDivCd.Equals( (int)SalesTtlSt.PrmPrtsNmUseDivCdValue.Using ) )
                        {
                            goodsName = JoinSourceRow.SearchPartsFullName;
                            goodsNameKana = JoinSourceRow.SearchPartsHalfName;
                        }
                    }
                    if ( string.IsNullOrEmpty( goodsName ) )
                    {
                        // ・純正部品、オリジナル部品(優良BL検索)の場合
                        if ( IsPureGoods( UserGoodsInfoRow ) || IsOriginalGoods( UserGoodsInfoRow ) )
                        {
                            // 複数互換（サブ）もしくは、結合品で結合元が複数互換品の場合には品名を取得しない
                            if ( !(IsPluralCompatibleSubset || IsPluralCompatible( JoinSourceRow )) )
                            {
                                goodsName = UserGoodsInfoRow.SearchPartsFullName;
                                goodsNameKana = UserGoodsInfoRow.SearchPartsHalfName;
                            }
                        }
                    }
                }

                if ( !string.IsNullOrEmpty( goodsName ) )
                {
                    PrintSelectorName( Name );
                    return new GoodsNamePair( goodsName, goodsNameKana );
                }
                // 品名が選択できなかった場合、次の品名の選択処理へ
                if ( NextSelectror != null )
                {
                    return NextSelectror.GetGoodsName( goodsUnitData, getBLGoodsInfo );
                }
                return new GoodsNamePair( DefaultGoodsName, DefaultGoodsNameKana );
            }
        }

        #endregion // 品名の選択処理：検索品名表示区分「3:検索品名マスタ」

        #region 品名の選択処理：検索品名表示区分「4:BLコードマスタ」

        /// <summary>
        /// 検索品名表示区分「4:BLコードマスタ」の場合の品名の選択処理クラス
        /// </summary>
        private sealed class BLCodeMasterSelector : GoodsNameSelector
        {
            #region Constructor

            /// <summary>
            /// カスタムコンストラクタ
            /// </summary>
            /// <param name="userGoodsInfoRow">部品情報</param>
            /// <param name="isPluralCompatibleSubset">複数互換（サブ）フラグ</param>
            /// <param name="joinSourceRow">結合元部品情報</param>
            /// <param name="prmPrtsNmUseDivCd">優良部品検索品名使用区分</param>
            /// <param name="searchingMethod">検索方法</param>
            public BLCodeMasterSelector(
                UsrGoodsInfoRow userGoodsInfoRow,
                bool isPluralCompatibleSubset,
                UsrGoodsInfoRow joinSourceRow,
                int prmPrtsNmUseDivCd,
                int searchingMethod
            )
                : base( userGoodsInfoRow, isPluralCompatibleSubset, joinSourceRow, prmPrtsNmUseDivCd, searchingMethod )
            { }

            #endregion // Constructor

            /// <summary>
            /// 名称を取得します。
            /// </summary>
            /// <see cref="GoodsNameSelector"/>
            protected override string Name { get { return "「4:BLコードマスタ」"; } }

            /// <summary>
            /// 品名を取得します。
            /// </summary>
            /// <param name="goodsUnitData">商品連結データ</param>
            /// <param name="getBLGoodsInfo">BLコード情報を取得するデリゲート</param>
            /// <returns>
            /// <c>Key</c>  :品名
            /// <c>Value</c>:品名(カナ)
            /// </returns>
            /// <see cref="GoodsNameSelector"/>
            public override GoodsNamePair GetGoodsName(
                GoodsUnitData goodsUnitData,
                GetBLGoodsInfoCallBack getBLGoodsInfo
            )
            {
                // 5)「4:BLコードマスタ」
                string goodsName = string.Empty;
                string goodsNameKana = string.Empty;

                // TBO検索の場合は取得しない
                if ( !IsSearchingByTBO( UserGoodsInfoRow ) )
                {
                    if ( getBLGoodsInfo != null )
                    {
                        // ・検索BLコードがセットされている場合は、検索BLコードを使用してBLコード名称を取得する
                        // （最終的に、エントリ画面で表示されるBLコードの名称を取得する）
                        int blGoodsCode = goodsUnitData.SearchBLCode.Equals( 0 ) ? goodsUnitData.BLGoodsCode : goodsUnitData.SearchBLCode;
                        BLGoodsCdUMnt blGoodsInfo = getBLGoodsInfo( blGoodsCode );
                        if ( blGoodsInfo != null )
                        {
                            goodsName = blGoodsInfo.BLGoodsFullName;
                            goodsNameKana = blGoodsInfo.BLGoodsHalfName;
                        }
                    }
                }

                if ( !string.IsNullOrEmpty( goodsName ) )
                {
                    PrintSelectorName( Name );
                    return new GoodsNamePair( goodsName, goodsNameKana );
                }
                // 品名が選択できなかった場合、次の品名の選択処理へ
                if ( NextSelectror != null )
                {
                    return NextSelectror.GetGoodsName( goodsUnitData, getBLGoodsInfo );
                }
                return new GoodsNamePair( DefaultGoodsName, DefaultGoodsNameKana );
            }
        }

        #endregion // 品名の選択処理：検索品名表示区分「4:BLコードマスタ」

        #region 品名の選択処理：FactoryMethod

        /// <summary>
        /// 品名の選択処理のファクトリクラス
        /// </summary>
        private static class GoodsNameSelectorFactory
        {
            /// <summary>
            /// 品名の選択処理を生成します。
            /// </summary>
            /// <param name="prtNmDspDivCd">○○検索品名表示区分</param>
            /// <param name="userGoodsInfoRow">部品情報</param>
            /// <param name="isPluralCompatibleSubset">複数互換（サブ）フラグ</param>
            /// <param name="joinSourceRow">結合元部品情報</param>
            /// <param name="prmPrtsNmUseDivCd">優良部品検索品名使用区分</param>
            /// <param name="searchingMethod">検索方法</param>
            /// <returns>検索品名表示区分に応じた品名の選択処理</returns>
            public static GoodsNameSelector Create(
                int prtNmDspDivCd,
                UsrGoodsInfoRow userGoodsInfoRow,
                bool isPluralCompatibleSubset,
                UsrGoodsInfoRow joinSourceRow,
                int prmPrtsNmUseDivCd,
                int searchingMethod
            )
            {
                switch ( prtNmDspDivCd )
                {
                    // 「1:商品マスタ」
                    case (int)SalesTtlSt.PrtsNmDspDivCdValue.GoodsMaster:
                        return new GoodsMasterSelector(
                            userGoodsInfoRow,
                            isPluralCompatibleSubset,
                            joinSourceRow,
                            prmPrtsNmUseDivCd,
                            searchingMethod
                        );
                    // 「2:部品マスタ」
                    case (int)SalesTtlSt.PrtsNmDspDivCdValue.PartsMaster:
                        return new PartsMasterSelector(
                            userGoodsInfoRow,
                            isPluralCompatibleSubset,
                            joinSourceRow,
                            prmPrtsNmUseDivCd,
                            searchingMethod
                        );
                    // 「3:検索品名マスタ」
                    case (int)SalesTtlSt.PrtsNmDspDivCdValue.SearchedGoodsNameMaster:
                        return new SearchedGoodsNameMasterSelector(
                            userGoodsInfoRow,
                            isPluralCompatibleSubset,
                            joinSourceRow,
                            prmPrtsNmUseDivCd,
                            searchingMethod
                        );
                    // 「4:BLコードマスタ」
                    case (int)SalesTtlSt.PrtsNmDspDivCdValue.BLCodeMaster:
                        {
                            return new BLCodeMasterSelector(
                                userGoodsInfoRow,
                                isPluralCompatibleSubset,
                                joinSourceRow,
                                prmPrtsNmUseDivCd,
                                searchingMethod
                            );
                        }
                    // 「0:無し」
                    default:
                        return new NonSelector();
                }
            }
        }

        #endregion // 品名の選択処理：FactoryMethod

        #endregion // 品名の選択処理

        #endregion // 品名表示パターン
        // ADD 2010/05/17 品名表示対応 ----------<<<<<

        //>>>2010/06/03
        #region 品名半角設定処理
        /// <summary>
        /// 品名半角設定処理
        /// </summary>
        public void ReSettingGoodsName()
        {
            foreach ( JoinPartsRow row in tableJoinParts )
            {
                if ( !string.IsNullOrEmpty( row.PrimePartsKanaName ) ) row.PrimePartsName = row.PrimePartsKanaName;
            }

            foreach ( PartsInfoRow row in tablePartsInfo )
            {
                if ( !string.IsNullOrEmpty( row.PartsNameKana ) ) row.PartsName = row.PartsNameKana;
            }

            foreach ( SubstPartsInfoRow row in tableSubstPartsInfo )
            {
                if ( !string.IsNullOrEmpty( row.PartsNameKana ) ) row.PartsName = row.PartsNameKana;
            }

            foreach ( UsrGoodsInfoRow row in tableUsrGoodsInfo )
            {
                if ( !string.IsNullOrEmpty( row.GoodsNameKana ) ) row.GoodsName = row.GoodsNameKana;
                if ( !string.IsNullOrEmpty( row.GoodsOfrNameKana ) ) row.GoodsOfrName = row.GoodsOfrNameKana;
                if ( !string.IsNullOrEmpty( row.SearchPartsHalfName ) ) row.SearchPartsFullName = row.SearchPartsHalfName;
            }

            foreach ( DSubstPartsInfoRow row in tableDSubstPartsInfo )
            {
                if ( !string.IsNullOrEmpty( row.PartsNameKana ) ) row.PartsName = row.PartsNameKana;
            }

            foreach ( TBOInfoRow row in tableTBOInfo )
            {
                if ( !string.IsNullOrEmpty( row.PrimePartsKanaName ) ) row.PrimePartsName = row.PrimePartsKanaName;
            }
        }
        #endregion
        //<<<2010/06/03
    }
}
