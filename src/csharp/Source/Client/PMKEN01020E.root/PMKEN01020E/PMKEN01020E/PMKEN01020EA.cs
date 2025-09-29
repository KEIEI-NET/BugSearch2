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
// 作 成 日 : 2018/04/05   修正内容 : NS3Ai対応（BL統一部品コード対応）
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;  // 2009/12/16 Add

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 部品検索抽出条件クラス
    /// </summary>
    /// <remarks>
    /// <br>Update Note	: 論理削除モードを追加(MANTIS[0014661])</br>
    /// <br>Programmer	: 21024　佐々木 健</br>
    /// <br>Date		: 2009/12/17</br>
    /// <br></br>
    /// <br>Update Note  : 検索見積で、セット情報表示時にエラーになる件の対応(MANTIS[0015177])</br>
    /// <br>               ・カスタムコンストラクタ、クローンメソッドの追加</br>
    /// <br>Programmer   : 21024　佐々木 健</br>
    /// <br>Date         : 2010/03/19</br>
    /// <br></br>
    /// <br>Update Note  : SCM改良</br>
    /// <br>                 BLコード枝番追加</br>
    /// <br>Programmer   : 22018 鈴木 正臣</br>
    /// <br>Date         : 2011/05/18</br>
    /// <br>Update Note  : 2018/04/05  30757 佐々木　貴英</br>
    /// <br>管理番号     : 11470007-00</br>
    /// <br>             : NS3Ai対応（BL統一部品コード対応）</br>
    /// <br>               BL統一部品コード関連メンバーの追加</br>
    /// </remarks>
    public class PartsSearchUIData
    {
        // 企業コード
        private string _enterpriseCode;

        // 品番
        private string _prtsNo = string.Empty;

        ////ハイフンなし品番
        //private string _prtsNoNoneHyphen = string.Empty;

        //ＢＬコード
        private int _tbsPartsCode = 0;

        //部品メーカーコード
        private int _partsMakerCode;

        //検索フラグ
        private SearchFlag _searchFlg;

        //検索タイプ
        private SearchType _searchType;

        // 2009/12/17 Add >>>
        //論理削除モード
        private ConstantManagement.LogicalMode _logicalMode = ConstantManagement.LogicalMode.GetData0;
        // 2009/12/17 Add <<<

        /// <summary>優良設定情報格納バッファ(VALUE:優良設定情報オブジェクト)</summary>
        // 2009.02.12 >>>
        //private Dictionary<PrmSettingKey, PrmSettingUWork> _drPrmSettingWork;
        private List<PrmSettingUWork> _drPrmSettingWork;
        // 2009.02.12 <<<

        /// <summary>拠点コード</summary>
        private string _sectionCode;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        /// <summary>価格適用日</summary>
        private DateTime _priceDate;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD

        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>BLコード枝番</summary>
        private Int32 _tbsPartsCdDerivedNo;
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        //検索制御設定
        private SearchCntSetWork _searchCntSetWork;

        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        /// <summary>BL統一部品コード(スリーコード版)</summary>
        private string _blUtyPtThCd = string.Empty;
        /// <summary>BL統一部品サブコード</summary>
        private Int32 _blUtyPtSbCd = 0;
        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PartsSearchUIData()
        {
        }

        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="logicalMode">論理削除モード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="tbsPartsCode">BLコード</param>
        /// <param name="prtsNo">品番</param>
        /// <param name="partsMakerCode">メーカーコード</param>
        /// <param name="searchFlag">検索フラグ</param>
        /// <param name="searchType">検索タイプ</param>
        /// <param name="prmSettingUWorkList">優良設定リスト</param>
        /// <param name="searchCntSetWork">検索制御設定</param>
        /// <param name="priceDate">価格適用日</param>
        /// <param name="tbsPartsCdDerivedNo">BLコード枝番</param>
        public PartsSearchUIData( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, string sectionCode, int tbsPartsCode, string prtsNo, int partsMakerCode, SearchFlag searchFlag, SearchType searchType, List<PrmSettingUWork> prmSettingUWorkList, SearchCntSetWork searchCntSetWork, DateTime priceDate, Int32 tbsPartsCdDerivedNo )
        {
            _logicalMode = logicalMode;
            _enterpriseCode = enterpriseCode;
            _sectionCode = sectionCode;
            _tbsPartsCode = tbsPartsCode;
            _tbsPartsCdDerivedNo = tbsPartsCdDerivedNo;
            _prtsNo = prtsNo;
            _partsMakerCode = partsMakerCode;
            _searchFlg = searchFlag;
            _searchType = searchType;
            _priceDate = priceDate;
            _searchCntSetWork = searchCntSetWork.Clone();

            _drPrmSettingWork = new List<PrmSettingUWork>();
        }
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<
        // 2010/03/19 Add >>>
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="logicalMode">論理削除モード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="tbsPartsCode">BLコード</param>
        /// <param name="prtsNo">品番</param>
        /// <param name="partsMakerCode">メーカーコード</param>
        /// <param name="searchFlag">検索フラグ</param>
        /// <param name="searchType">検索タイプ</param>
        /// <param name="prmSettingUWorkList">優良設定リスト</param>
        /// <param name="searchCntSetWork">検索制御設定</param>
        /// <param name="priceDate">価格適用日</param>
        public PartsSearchUIData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, string sectionCode, int tbsPartsCode, string prtsNo, int partsMakerCode, SearchFlag searchFlag, SearchType searchType, List<PrmSettingUWork> prmSettingUWorkList, SearchCntSetWork searchCntSetWork, DateTime priceDate)
        {
            _logicalMode = logicalMode;
            _enterpriseCode = enterpriseCode;
            _sectionCode = sectionCode;
            _tbsPartsCode = tbsPartsCode;
            _prtsNo = prtsNo;
            _partsMakerCode = partsMakerCode;
            _searchFlg = searchFlag;
            _searchType = searchType;
            _priceDate = priceDate;
            _searchCntSetWork = searchCntSetWork.Clone();

            // TODO：クローン処理が無い
            _drPrmSettingWork = new List<PrmSettingUWork>();
        }

        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        /// <summary>
        /// カスタムコンストラクタ
        /// </summary>
        /// <param name="logicalMode">論理削除モード</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="tbsPartsCode">BLコード</param>
        /// <param name="prtsNo">品番</param>
        /// <param name="partsMakerCode">メーカーコード</param>
        /// <param name="searchFlag">検索フラグ</param>
        /// <param name="searchType">検索タイプ</param>
        /// <param name="prmSettingUWorkList">優良設定リスト</param>
        /// <param name="searchCntSetWork">検索制御設定</param>
        /// <param name="priceDate">価格適用日</param>
        /// <param name="tbsPartsCdDerivedNo">BLコード枝番</param>
        /// <param name="blUtyPtThCdRF">BL統一部品コード(スリーコード版)</param>
        /// <param name="blUtyPtSbCdRF">BL統一部品サブコード</param>
        /// <remarks>
        /// <br>Note       : BL統一部品コード(スリーコード版)の取得と設定</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>管理番号   : 11470007-00</br>
        /// <br>           : NS3Ai対応（BL統一部品コード対応）</br>
        /// </remarks>
        public PartsSearchUIData( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, string sectionCode, int tbsPartsCode, string prtsNo, int partsMakerCode, SearchFlag searchFlag, SearchType searchType, List<PrmSettingUWork> prmSettingUWorkList, SearchCntSetWork searchCntSetWork, DateTime priceDate, Int32 tbsPartsCdDerivedNo, string blUtyPtThCdRF, Int32 blUtyPtSbCdRF )
            : this( logicalMode, enterpriseCode, sectionCode, tbsPartsCode, prtsNo, partsMakerCode, searchFlag, searchType, prmSettingUWorkList, searchCntSetWork, priceDate, tbsPartsCdDerivedNo )
        {
            this._blUtyPtThCd = blUtyPtThCdRF;
            this._blUtyPtSbCd = blUtyPtSbCdRF;
        }
        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<

        /// <summary>
        /// クローン処理
        /// </summary>
        /// <returns></returns>
        public PartsSearchUIData Clone()
        {
            // ----UPD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
            #region #過去コード
            //// --- UPD m.suzuki 2011/05/18 ---------->>>>>
            ////return new PartsSearchUIData(
            ////    _logicalMode,
            ////    _enterpriseCode,
            ////    _sectionCode,
            ////    _tbsPartsCode,
            ////    _prtsNo,
            ////    _partsMakerCode,
            ////    _searchFlg,
            ////    _searchType,
            ////    _drPrmSettingWork,
            ////    _searchCntSetWork,
            ////    _priceDate);
            //return new PartsSearchUIData(
            //    _logicalMode,
            //    _enterpriseCode,
            //    _sectionCode,
            //    _tbsPartsCode,
            //    _prtsNo,
            //    _partsMakerCode,
            //    _searchFlg,
            //    _searchType,
            //    _drPrmSettingWork,
            //    _searchCntSetWork,
            //    _priceDate,
            //    _tbsPartsCdDerivedNo );
            //// --- UPD m.suzuki 2011/05/18 ----------<<<<<
            #endregion //#過去コード
            return new PartsSearchUIData(
                  this._logicalMode
                , this._enterpriseCode
                , this._sectionCode
                , this._tbsPartsCode
                , this._prtsNo
                , this._partsMakerCode
                , this._searchFlg
                , this._searchType
                , this._drPrmSettingWork
                , this._searchCntSetWork
                , this._priceDate
                , this._tbsPartsCdDerivedNo
                , this._blUtyPtThCd
                , this._blUtyPtSbCd
                );
            // ----UPD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
        }
        // 2010/03/19 Add <<<

        ///// <summary>
        ///// ハイフンなし品番
        ///// </summary>
        //public string PrtsNoNoneHyphen
        //{
        //    get { return _prtsNoNoneHyphen; }
        //    set { _prtsNoNoneHyphen = value; }
        //}

        /// <summary>
        /// 企業コード
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// 品番 [ハイフンあり・なし共通]
        /// </summary>
        public string PartsNo
        {
            get { return _prtsNo; }
            set { _prtsNo = value; }
        }

        /// <summary>
        /// ＢＬコード
        /// </summary>
        public int TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// <summary>
        /// 部品メーカーコード
        /// </summary>
        public int PartsMakerCode
        {
            get { return _partsMakerCode; }
            set { _partsMakerCode = value; }
        }

        /// <summary>
        /// 検索フラグ
        /// </summary>
        public SearchFlag SearchFlg
        {
            get { return _searchFlg; }
            set { _searchFlg = value; }
        }

        /// <summary>
        /// 検索タイプ
        /// </summary>
        public SearchType SearchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }

        /// <summary>優良設定情報リスト</summary>
        // 2009.02.12 >>>
        //public Dictionary<PrmSettingKey, PrmSettingUWork> PrmSettingWork
        public List<PrmSettingUWork> PrmSettingWork
        // 2009.02.12 <<<
        {
            get
            {
                // 2009.02.12 >>>
                //if (_drPrmSettingWork == null)
                //    _drPrmSettingWork = new Dictionary<PrmSettingKey, PrmSettingUWork>();
                if (_drPrmSettingWork == null)
                    _drPrmSettingWork = new List<PrmSettingUWork>();
                // 2009.02.12 <<<
                return _drPrmSettingWork;
            }
            set { _drPrmSettingWork = value; }
        }

        /// <summary>拠点コード[優良設定用:ログイン拠点]</summary>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// <summary>
        /// 検索制御設定
        /// </summary>
        public SearchCntSetWork SearchCntSetWork
        {
            get
            {
                if (_searchCntSetWork != null)
                    return _searchCntSetWork;
                return new SearchCntSetWork();
            }
            set { _searchCntSetWork = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        /// <summary>
        /// 価格適用日
        /// </summary>
        public DateTime PriceDate
        {
            get { return _priceDate; }
            set { _priceDate = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD

        // 2009/12/17 Add >>>
        /// <summary>
        /// 論理削除モード
        /// </summary>
        public ConstantManagement.LogicalMode LogicalMode
        {
            get { return _logicalMode; }
            set { this._logicalMode = value; }
        }
        // 2009/12/17 Add <<<

        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>
        /// BLコード枝番
        /// </summary>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） ------->>>>>
        /// <summary>BL統一部品コード(スリーコード版)パラメータ</summary>
        /// <value>BL統一部品コード(スリーコード版)</value>
        /// <remarks>
        /// <br>Note       : BL統一部品コード(スリーコード版)の取得と設定</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>管理番号   : 11470007-00</br>
        /// <br>           : NS3Ai対応（BL統一部品コード対応）</br>
        /// </remarks>
        public string BlUtyPtThCd
        {
            get { return this._blUtyPtThCd; }
            set { this._blUtyPtThCd = value; }
        }
        /// <summary>BL統一部品サブコードパラメータ</summary>
        /// <value>BL統一部品サブコード</value>
        /// <remarks>
        /// <br>Note       : BL統一部品サブコードの取得と設定</br>
        /// <br>Programmer : 30757 佐々木　貴英</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>管理番号   : 11470007-00</br>
        /// <br>           : NS3Ai対応（BL統一部品コード対応）</br>
        /// </remarks>
        public Int32 BlUtyPtSbCd
        {
            get { return this._blUtyPtSbCd; }
            set { this._blUtyPtSbCd = value; }
        }
        // ----ADD 2018/04/05 30757 佐々木　貴英 11470007-00 NS3Ai対応（BL統一部品コード対応） -------<<<<<
    }

}
