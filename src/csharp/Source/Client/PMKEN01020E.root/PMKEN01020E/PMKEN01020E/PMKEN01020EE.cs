using System;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// public class name:   SearchCntSetWork
    /// <summary>
    ///                      検索制御設定ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   検索制御設定ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2008/3/17</br>
    /// <br>Genarated Date   :   2008/09/29  (CSharp File Generated Date)</br>
    /// <br></br>
    /// <br>Update Note  : 検索見積で、セット情報表示時にエラーになる件の対応(MANTIS[0015177])</br>
    /// <br>               ・カスタムコンストラクタ、クローンメソッドの追加</br>
    /// <br>Programmer   : 21024　佐々木 健</br>
    /// <br>Date         : 2010/03/19</br>
    /// </remarks>
    public class SearchCntSetWork
    {
        /// <summary>代替条件区分</summary>
        /// <remarks>0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）</remarks>
        private Int32 _substCondDivCd;

        /// <summary>優良代替条件区分</summary>
        /// <remarks>0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）</remarks>
        private Int32 _prmSubstCondDivCd;

        /// <summary>代替適用区分</summary>
        /// <remarks>0:しない, 1:する(結合、セット), 2:全て（結合、セット、純正）</remarks>
        private Int32 _substApplyDivCd;

        /// <summary>部品検索優先順区分[未使用]</summary>
        /// <remarks>0:純正　1:優良</remarks>
        private Int32 _partsSearchPriDivCd;

        /// <summary>結合初期表示区分</summary>
        /// <remarks>0:表示順 1:在庫順</remarks>
        private Int32 _joinInitDispDiv;

        /// <summary>検索画面制御区分</summary>
        /// <remarks>0:PM7, 1:PM.NS</remarks>
        private Int32 _searchUICntDivCd;

        /// <summary>エンターキー処理区分</summary>
        /// <remarks>0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）</remarks>
        private Int32 _enterProcDivCd;

        ///// <summary>品番検索区分</summary>
        ///// <remarks>0:PM7（セットのみ）, 1:結合･セット･代替あり，</remarks>
        //private Int32 _partsNoSearchDivCd;

        ///// <summary>品番結合制御区分</summary>
        ///// <remarks>初期値”.”</remarks>
        //private string _partsJoinCntDivCd = "";

        /// <summary>元号表示区分１</summary>
        /// <remarks>0:西暦　1:和暦（年式）</remarks>
        private Int32 _eraNameDispCd1;

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        private Int32 _totalAmountDispWayCd;

        /// public propaty name  :  SubstCondDivCd
        /// <summary>代替条件区分プロパティ</summary>
        /// <value>0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代替条件区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubstCondDivCd
        {
            get { return _substCondDivCd; }
            set { _substCondDivCd = value; }
        }

        /// public propaty name  :  PrmSubstCondDivCd
        /// <summary>優良代替条件区分プロパティ</summary>
        /// <value>0:代替しない 1:代替する(在庫無) 2:代替する（在庫無視）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   優良代替条件区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PrmSubstCondDivCd
        {
            get { return _prmSubstCondDivCd; }
            set { _prmSubstCondDivCd = value; }
        }

        /// public propaty name  :  SubstApplyDivCd
        /// <summary>代替適用区分プロパティ</summary>
        /// <value>0:しない, 1:する(結合、セット), 2:全て（結合、セット、純正）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   代替適用区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SubstApplyDivCd
        {
            get { return _substApplyDivCd; }
            set { _substApplyDivCd = value; }
        }

        /// public propaty name  :  PartsSearchPriDivCd
        /// <summary>部品検索優先順区分プロパティ[未使用/SearchFlagを使うため]</summary>
        /// <value>0:純正　1:優良</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   部品検索優先順区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 PartsSearchPriDivCd
        {
            get { return _partsSearchPriDivCd; }
            set { _partsSearchPriDivCd = value; }
        }

        /// public propaty name  :  JoinInitDispDiv
        /// <summary>結合初期表示区分プロパティ</summary>
        /// <value>0:表示順 1:在庫順</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   結合初期表示区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 JoinInitDispDiv
        {
            get { return _joinInitDispDiv; }
            set { _joinInitDispDiv = value; }
        }

        /// public propaty name  :  SearchUICntDivCd
        /// <summary>検索画面制御区分プロパティ</summary>
        /// <value>0:PM7, 1:PM.NS</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   検索画面制御区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 SearchUICntDivCd
        {
            get { return _searchUICntDivCd; }
            set { _searchUICntDivCd = value; }
        }

        /// public propaty name  :  EnterProcDivCd
        /// <summary>エンターキー処理区分プロパティ</summary>
        /// <value>0:PM7, 1:選択 2:次画面（純正⇒結合、結合⇒セット、セット⇒確定）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   エンターキー処理区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EnterProcDivCd
        {
            get { return _enterProcDivCd; }
            set { _enterProcDivCd = value; }
        }

        ///// public propaty name  :  PartsNoSearchDivCd
        ///// <summary>品番検索区分プロパティ</summary>
        ///// <value>0:PM7（セットのみ）, 1:結合･セット･代替あり，</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   品番検索区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public Int32 PartsNoSearchDivCd
        //{
        //    get { return _partsNoSearchDivCd; }
        //    set { _partsNoSearchDivCd = value; }
        //}

        ///// public propaty name  :  PartsJoinCntDivCd
        ///// <summary>品番結合制御区分プロパティ</summary>
        ///// <value>初期値”.”</value>
        ///// ----------------------------------------------------------------------
        ///// <remarks>
        ///// <br>note             :   品番結合制御区分プロパティ</br>
        ///// <br>Programer        :   自動生成</br>
        ///// </remarks>
        //public string PartsJoinCntDivCd
        //{
        //    get { return _partsJoinCntDivCd; }
        //    set { _partsJoinCntDivCd = value; }
        //}

        /// public propaty name  :  EraNameDispCd1
        /// <summary>元号表示区分１プロパティ</summary>
        /// <value>0:西暦　1:和暦（年式）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   元号表示区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EraNameDispCd1
        {
            get { return _eraNameDispCd1; }
            set { _eraNameDispCd1 = value; }
        }

        /// <summary>総額表示方法区分</summary>
        /// <remarks>0:総額表示しない（税抜き）,1:総額表示する（税込み）</remarks>
        public Int32 TotalAmountDispWayCd
        {
            get { return _totalAmountDispWayCd; }
            set { _totalAmountDispWayCd = value; }
        }

        /// <summary>
        /// 検索制御設定ワークコンストラクタ
        /// </summary>
        /// <returns>SearchCntSetWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SearchCntSetWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SearchCntSetWork()
        {
            _substCondDivCd = 0; // デフォルト　0:代替しない
            _prmSubstCondDivCd = 0; // デフォルト　0:代替しない
            _substApplyDivCd = 0; // デフォルト　0:しない
            _searchUICntDivCd = 1; // デフォルト　1:PM.NS 
            _enterProcDivCd = 1; // デフォルト　1:選択
            //_partsNoSearchDivCd = 0; // デフォルト　0:PM7（セットのみ）
            //_partsJoinCntDivCd = "."; // デフォルト　"."
            _eraNameDispCd1 = 0; // デフォルト　0:西暦
        }

        // 2010/03/19 Add >>>
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="substCondDivCd"></param>
        /// <param name="prmSubstCondDivCd"></param>
        /// <param name="substApplyDivCd"></param>
        /// <param name="partsSearchPriDivCd"></param>
        /// <param name="joinInitDispDiv"></param>
        /// <param name="searchUICntDivCd"></param>
        /// <param name="enterProcDivCd"></param>
        /// <param name="eraNameDispCd1"></param>
        /// <param name="totalAmountDispWayCd"></param>
        public SearchCntSetWork(int substCondDivCd, int prmSubstCondDivCd, int substApplyDivCd, int partsSearchPriDivCd, int joinInitDispDiv, int searchUICntDivCd, int enterProcDivCd, int eraNameDispCd1, int totalAmountDispWayCd)
        {
            _substCondDivCd = substCondDivCd;

            _prmSubstCondDivCd = prmSubstCondDivCd;

            _substApplyDivCd = substApplyDivCd;

            _partsSearchPriDivCd = partsSearchPriDivCd;

            _joinInitDispDiv = joinInitDispDiv;

            _searchUICntDivCd = searchUICntDivCd;

            _enterProcDivCd = enterProcDivCd;

            _eraNameDispCd1 = eraNameDispCd1;

            _totalAmountDispWayCd = totalAmountDispWayCd;
        }

        /// <summary>
        /// クローン処理
        /// </summary>
        /// <returns></returns>
        public SearchCntSetWork Clone()
        {
            return new SearchCntSetWork(
                _substCondDivCd,
                _prmSubstCondDivCd,
                _substApplyDivCd,
                _partsSearchPriDivCd,
                _joinInitDispDiv,
                _searchUICntDivCd,
                _enterProcDivCd,
                _eraNameDispCd1,
                _totalAmountDispWayCd
                );
        }
        // 2010/03/19 Add <<<
    }
}
