//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : キャンペーン管理マスタ
// プログラム概要   : キャンペーン管理の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/28  修正内容 : 新規作成
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2009/07/14  修正内容 : サーバ対応(LoginInfoAcquisition.Employee.BelongSectionCodeを使用しない)
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2009/08/25  修正内容 : チケット[14065]対応
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2009/08/31  修正内容 : チケット[14194]対応
// 管理番号              作成担当 : 20056 對馬 大輔
// 作 成 日  2010/04/13  修正内容 : キャンペーン設定マスタとキャンペーン管理マスタの拠点チェック方法修正
//                                : (キャンペーン設定マスタで全社設定にした場合、全ての設定にヒットしない)
// 管理番号              作成担当 : 22008 長内 数馬
// 作 成 日  2010/09/29  修正内容 : 売伝で明細数量変更時の速度アップ対応
//----------------------------------------------------------------------------//
#define _USING_VERSION_2_   // 改訂版を使用するフラグ

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// キャンペーン管理マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : キャンペーン管理マスタのアクセス制御を行います。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2009/05/28</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class CampaignMngAcs
    {
        #region public const
        //----------------------------------------
        // キャンペーン管理マスタ定数定義
        //----------------------------------------
        /// <summary>作成日時</summary>
        public const string ct_COL_CREATEDATETIME = "CreateDateTime";
        /// <summary>更新日時</summary>
        public const string ct_COL_UPDATEDATETIME = "UpdateDateTime";
        /// <summary>企業コード</summary>
        public const string ct_COL_ENTERPRISECODE = "EnterpriseCode";
        /// <summary>GUID</summary>
        public const string ct_COL_FILEHEADERGUID = "FileHeaderGuid";
        /// <summary>更新従業員コード</summary>
        public const string ct_COL_UPDEMPLOYEECODE = "UpdEmployeeCode";
        /// <summary>更新アセンブリID1</summary>
        public const string ct_COL_UPDASSEMBLYID1 = "UpdAssemblyId1";
        /// <summary>更新アセンブリID2</summary>
        public const string ct_COL_UPDASSEMBLYID2 = "UpdAssemblyId2";
        /// <summary>論理削除区分</summary>
        public const string ct_COL_LOGICALDELETECODE = "LogicalDeleteCode";
        /// <summary>拠点コード</summary>
        public const string ct_COL_SECTIONCODE = "SectionCode";
        /// <summary>商品中分類コード</summary>
        public const string ct_COL_GOODSMGROUP = "GoodsMGroup";
        /// <summary>BL商品コード</summary>
        public const string ct_COL_BLGOODSCODE = "BLGoodsCode";
        /// <summary>商品メーカーコード</summary>
        public const string ct_COL_GOODSMAKERCD = "GoodsMakerCd";
        /// <summary>商品番号</summary>
        public const string ct_COL_GOODSNO = "GoodsNo";
        /// <summary>売上目標金額</summary>
        public const string ct_COL_SALESTARGETMONEY = "SalesTargetMoney";
        /// <summary>売上目標粗利額</summary>
        public const string ct_COL_SALESTARGETPROFIT = "SalesTargetProfit";
        /// <summary>売上目標数量</summary>
        public const string ct_COL_SALESTARGETCOUNT = "SalesTargetCount";
        /// <summary>キャンペーンコード</summary>
        public const string ct_COL_CAMPAIGNCODE = "CampaignCode";
        /// <summary>売価率</summary>
        public const string ct_COL_RATEVAL = "RateVal";
        /// <summary>売価額</summary>
        public const string ct_COL_PRICEFL = "PriceFl";

        /// <summary>キャンペーンコードガイド</summary>
        public const string ct_COL_CAMPAIGNCODEGUIDE = "CampaignCodeGuide";
        /// <summary>キャンペーン名称</summary>
        public const string ct_COL_CAMPAIGNNAME = "CampaignName";

        /// <summary>キャンペーンコード(前回退避)</summary>
        public const string ct_COL_CAMPAIGNCODE_BACKUP = "CampaignCode_Backup";
        /// <summary>売価率(前回退避)</summary>
        public const string ct_COL_RATEVAL_BACKUP = "RateVal_Backup";
        /// <summary>売価額(前回退避)</summary>
        public const string ct_COL_PRICEFL_BACKUP = "PriceFl_Backup";

        /// <summary>BLグループコード</summary>
        public const string ct_COL_BLGROUPCODE = "BLGroupCode";
        
        /// <summary>拠点名称</summary>
        public const string ct_COL_SECTIONNM = "SectionNm";
        /// <summary>商品中分類名称</summary>
        public const string ct_COL_GOODSMGROUPNAME = "GoodsMGroupName";
        /// <summary>BLグループ名称</summary>
        public const string ct_COL_BLGROUPNAME = "BLGroupName";
        /// <summary>BL商品コード名称</summary>
        public const string ct_COL_BLGOODSNAME = "BLGoodsName";
        /// <summary>メーカー名称</summary>
        public const string ct_COL_MAKERNAME = "MakerName";
        /// <summary>商品名称</summary>
        public const string ct_COL_GOODSNAME = "GoodsName";
        
        # region [ソート用]
        /// <summary>拠点コード</summary>
        public const string ct_COL_SECTIONCODE_SORT = "SectionCode_Sort";
        /// <summary>商品メーカーコード</summary>
        public const string ct_COL_GOODSMAKERCD_SORT = "GoodsMakerCd_Sort";
        /// <summary>商品中分類コード</summary>
        public const string ct_COL_GOODSMGROUP_SORT = "GoodsMGroup_Sort";
        /// <summary>BLグループコード</summary>
        public const string ct_COL_BLGROUPCODE_SORT = "BLGroupCode_Sort";
        /// <summary>BL商品コード</summary>
        public const string ct_COL_BLGOODSCODE_SORT = "BLGoodsCode_Sort";
        # endregion

        /// <summary>論理削除日(表示用)</summary>
        public const string ct_COL_LOGICALDELETEDATE = "LogicalDeleteDate";
        /// <summary>キャンペーン管理マスタworkオブジェクト(内部保持用)</summary>
        public const string ct_COL_CAMPAIGNMNGWORKOBJECT = "CampaignMngWorkObject";


        // テーブル名
        /// <summary>キャンペーン管理テーブル</summary>
        public const string ct_TABLE_CAMPAIGNMNG = "CampaignMngTable";

        #endregion

        #region Private Members
        // ===================================================================================== //
        // プライベートメンバー
        // ===================================================================================== //
        // リモートオブジェクト格納バッファ
        private ICampaignMngDB _iCampaignMngDB = null;      // キャンペーン管理リモート

        private DataSet _dataTableList = null;
        private DataView _dataView = null;
        private bool _excludeLogicalDeleteFromView;

        //private GoodsAcs _goodsAcs;  // DEL 2010/09/29

        // キャンペーン設定アクセスクラス
        private CampaignStAcs _campaignStAcs;
        // キャンペーン設定ディクショナリ
        private Dictionary<int, CampaignSt> _campaignStDic;

        // ADD 2009/08/25 チケット[14065]対応 ------>>>
        /// <summary>
        /// キャンペーン設定ディクショナリ（全検索時のキャッシュデータ）を取得します。
        /// </summary>
        public Dictionary<int, CampaignSt> CachedCampaignStDic
        {
            get { return _campaignStDic; }
        }

        /// <summary>キャンペーン売価率、売価額取得処理で使用されたキャンペーン関連設定データ</summary>
        private ArrayList _usedCampaignLinkList;
        /// <summary>
        /// キャンペーン売価率、売価額取得処理で使用されたキャンペーン関連設定データを取得します。<br/>
        /// （キャンペーン設定.CampaignObjDiv == 1 でリモートアクセスします）
        /// </summary>
        public ArrayList UsedCampaignLinkList
        {
            get { return _usedCampaignLinkList; }
        }

        /// <summary>処理結果状況</summary>
        private string _statusOfResult = string.Empty;
        /// <summary>
        /// 処理結果状況を取得します。<br/>
        /// (GetRatePriceOfCampaignMng()を呼出し時に変化します)
        /// </summary>
        public string StatusOfResult
        {
            get { return _statusOfResult; }
        }
        // ADD 2009/08/25 チケット[14065]対応 ------<<<

        // キャンペーン管理データディクショナリー　キー項目
        public struct DICKEY
        {
            /// <summary> 拠点コード </summary>
            public string sectionCode;
            /// <summary> 商品中分類 </summary>
            public int goodsMGroup;
            /// <summary> BLコード </summary>
            public int blGoodsCode;
            /// <summary> メーカーコード </summary>
            public int goodsMakerCd;
            /// <summary> 品番 </summary>
            public string goodsNo;
        }

        // キャンペーン管理データディクショナリー
        private Dictionary<DICKEY, CampaignMng> _campaignMngDic = null;
        // ADD 2009/08/25 チケット[14065]対応 ------>>>
        /// <summary>
        /// キャンペーン管理データディクショナリー（全検索時のキャッシュデータ）を取得します。
        /// </summary>
        public Dictionary<DICKEY, CampaignMng> CachedCampaignMngDic
        {
            get { return _campaignMngDic; }
        }
        // ADD 2009/08/25 チケット[14065]対応 ------<<<

        /// <summary>企業コード</summary>
        private readonly string _enterpriseCode = string.Empty;

        /// <summary>拠点コード</summary>
        private readonly string _sectionCode = string.Empty;

        #endregion

        # region enum
        // 列挙型
        /// <summary>オンラインモードの列挙型です。</summary>
        public enum OnlineMode
        {
            /// <summary>オフライン</summary>
            Offline,
            /// <summary>オンライン</summary>
            Online
        }
        # endregion

        #region Construcstor
        /// <summary>
        /// キャンペーン管理マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン管理マスタアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public CampaignMngAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iCampaignMngDB = (ICampaignMngDB)MediationCampaignMngDB.GetCampaignMngDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iCampaignMngDB = null;
            }

            // 論理削除除外する
            _excludeLogicalDeleteFromView = true;
        }

        /// <summary>
        /// キャンペーン管理マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : キャンペーン管理マスタアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30434 工藤</br>
        /// <br>Date       : 2009/07/14</br>
        /// </remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        public CampaignMngAcs(string enterpriseCode, string sectionCode) : this()
        {
            _enterpriseCode = enterpriseCode;
            _sectionCode    = sectionCode;
        }
        #endregion

        /// <summary>
        /// オンラインモード取得処理
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : オンラインモードを取得します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iCampaignMngDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// データテーブル更新後イベント
        /// </summary>
        public event EventHandler AfterTableUpdate;


        #region Property
        /// <summary>
        /// データビュー（マスタ一覧用）
        /// </summary>
        public DataView DataViewForMstList
        {
            get 
            {
                // 生成前にget要求されたら初期生成処理を実行する
                if ( _dataTableList == null )
                {
                    this._dataTableList = new DataSet();
                    DataSetColumnConstruction();
                }
                return _dataView; 
            }
        }
        /// <summary>
        /// DataView論理削除除外フラグ
        /// </summary>
        public bool ExcludeLogicalDeleteFromView
        {
            set
            {
                DataView view = this.DataViewForMstList;
                if ( value == true )
                {
                    // 論理削除除く
                    view.RowFilter = string.Format( "{0}='{1}'", ct_COL_LOGICALDELETECODE, 0 );
                }
                else
                {
                    // 論理削除含む
                    view.RowFilter = string.Empty;
                }
            }
            get { return _excludeLogicalDeleteFromView; }
        }

        /// <summary>
        /// 企業コードを取得します。
        /// </summary>
        private string EnterpriseCode
        {
            get
            {
                if (string.IsNullOrEmpty(_enterpriseCode.Trim()))
                {
                    return LoginInfoAcquisition.EnterpriseCode;
                }
                else
                {
                    return _enterpriseCode;
                }
            }
        }

        /// <summary>
        /// 拠点コードを取得します。
        /// </summary>
        private string SectionCode
        {
            get
            {
                if (string.IsNullOrEmpty(_sectionCode.Trim()))
                {
                    return LoginInfoAcquisition.Employee.BelongSectionCode;
                }
                else
                {
                    return _sectionCode;
                }
            }
        }
        #endregion

        #region Search 検索処理
        /// <summary>
        /// 検索結果クリア処理
        /// </summary>
        public void Clear()
        {
            // 格納先テーブル準備
            if ( _dataTableList == null )
            {
                // 初回のみ生成
                this._dataTableList = new DataSet();
                DataSetColumnConstruction();
            }
            else
            {
                // ２回目以降はクリアのみ
                _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Clear();
            }
        }

        /// <summary>
        /// キャンペーン管理マスタ複数検索処理（論理削除含まない）キャンペーン管理マスメン以外用
        /// </summary>
        /// <param name="paraData">キャンペーン管理オブジェクトリスト</param>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="message">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン管理マスタリストの条件に一致したデータを検索します。論理削除データは抽出対象外</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int Search( CampaignMngOrder paraData, out List<CampaignMng> retList, out string message )
        {
            // -- DEL 2010/09/29 -------------------------------------->>>
            //if ( _goodsAcs == null )
            //{
            //    string msg;
            //    _goodsAcs = new GoodsAcs(SectionCode);
            //    _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
            //}
            // -- DEL 2010/09/29 --------------------------------------<<<

            // 検索
            ArrayList retWorkList;
            int status = this.SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetData0, out message );

            // 結果格納
            retList = new List<CampaignMng>();
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is CampaignMngWork )
                    {
                        CampaignMngWork retWork = (obj as CampaignMngWork);

                        // 値をセット
                        CampaignMng campaignMng = CopyToCampaignMngFromCampaignMngWork( retWork );
                        retList.Add( campaignMng );
                    }
                }
            }

            if ( retList.Count == 0 )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            return status;
        }

        /// <summary>
        /// 最新情報取得処理
        /// </summary>
        public void Renewal()
        {
            //_goodsAcs = null; // DEL 2010/09/29
            _campaignMngDic = null;
            this.Clear();
        }

        /// <summary>
        /// キャンペーン管理マスタ複数検索処理（論理削除含まない）キャンペーン管理マスメン用
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int Search( CampaignMngOrder paraData, out string message )
        {
            // -- DEL 2010/09/29 -------------------------->>>
            //if ( _goodsAcs == null )
            //{
            //    string msg;
            //    _goodsAcs = new GoodsAcs(SectionCode);
            //    _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
            //}
            // -- DEL 2010/09/29 --------------------------<<<

            // 初期化/クリア
            this.Clear();

            // 検索
            ArrayList retWorkList;
            int status = SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetDataAll, out message );

            // 結果格納
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is CampaignMngWork )
                    {
                        CampaignMngWork retWork = (obj as CampaignMngWork);

                        // アクセスクラス内のDataTableに追加
                        DataRow row = this._dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].NewRow();

                        // 値をセット
                        CopyToDataRowFromCampaignMngWork(ref row, retWork);
                        _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows.Add( row );
                    }
                }
            }
            if ( _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows.Count == 0 )
            {
                status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            // テーブル更新後イベント
            if ( AfterTableUpdate != null )
            {
                AfterTableUpdate( this, new EventArgs() );
            }

            return status;
        }

        /// <summary>
        /// マスメン向けレコード取得処理
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>キャンペーン管理マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public CampaignMng GetRecordForMaintenance( Guid guid )
        {
            CampaignMngWork campaignMngWork = null;

            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_CAMPAIGNMNG] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    campaignMngWork = CopyToCampaignMngWorkFromDataRow( view[0].Row );
                }
            }

            // 該当無しなら空データ
            if ( campaignMngWork == null )
            {
                campaignMngWork = new CampaignMngWork();
            }

            return this.CopyToCampaignMngFromCampaignMngWork( campaignMngWork );
        }
        /// <summary>
        /// マスメン向けレコード取得処理
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>キャンペーン管理マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public DataRow GetRowForMaintenance( Guid guid )
        {
            DataRow row = null;
            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_CAMPAIGNMNG] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    row = view[0].Row;
                }
            }

            // 該当無しならNULL
            return row;
        }
        #endregion

        #region Write 書き込み処理
        /// <summary>
        /// 書き込み処理
        /// </summary>
        /// <param name="campaignMngList">保存データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 書き込み処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int Write(ref ArrayList campaignMngList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // データ数分ループ
                ArrayList paraCampaignMngList = new ArrayList();
                CampaignMngWork campaignMngWork = null;

                for ( int i = 0; i < campaignMngList.Count; i++ )
                {
                    // クラスデータをワーククラスデータに変換
                    campaignMngWork = CopyToCampaignMngWorkFromCampaignMng( (CampaignMng)campaignMngList[i] );
                    paraCampaignMngList.Add( campaignMngWork );
                }

                object paraObj = (object)paraCampaignMngList;

                // 書き込み処理
                status = this._iCampaignMngDB.Write( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 正常更新

                    // DataTableを使用している場合のみ書き換えを行う
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
                {
                    // 何かしらのエラー発生
                    message = "登録に失敗しました。";
                    return status;
                }
            }
            catch ( Exception ex )
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iCampaignMngDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        /// <summary>
        /// 更新件数の取得（内部DataTableより）
        /// </summary>
        /// <returns></returns>
        public int GetUpdateCountFromTable()
        {
            if ( _dataTableList != null )
            {
                int count = 0;

                foreach ( DataRow row in _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows )
                {
                    // 売価率と売価額の変換
                    double rateVal = 0.0;
                    double rateValBk = 0.0;
                    double priceFl = 0.0;
                    double priceFlBk = 0.0;

                    if (row[ct_COL_RATEVAL] != null && row[ct_COL_RATEVAL] != DBNull.Value)
                    {
                        rateVal = (double)row[ct_COL_RATEVAL];
                    }
                    if (row[ct_COL_RATEVAL_BACKUP] != null && row[ct_COL_RATEVAL_BACKUP] != DBNull.Value)
                    {
                        rateValBk = (double)row[ct_COL_RATEVAL_BACKUP];
                    }
                    if (row[ct_COL_PRICEFL] != null && row[ct_COL_PRICEFL] != DBNull.Value)
                    {
                        priceFl = (double)row[ct_COL_PRICEFL];
                    }
                    if (row[ct_COL_PRICEFL_BACKUP] != null && row[ct_COL_PRICEFL_BACKUP] != DBNull.Value)
                    {
                        priceFlBk = (double)row[ct_COL_PRICEFL_BACKUP];
                    }

                    // 更新有無チェック
                    string campaignCode = row[ct_COL_CAMPAIGNCODE].ToString();
                    if (string.IsNullOrEmpty(campaignCode.Trim()))
                    {
                        row[ct_COL_CAMPAIGNCODE] = 0;
                    }
                    if (((int)row[ct_COL_CAMPAIGNCODE] != (int)row[ct_COL_CAMPAIGNCODE_BACKUP]) ||
                        (rateVal != rateValBk) ||
                        (priceFl != priceFlBk))
                    {
                        // 更新有
                        count++;
                    }
                }

                return count;
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// DataTableからの一括書き込み処理
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public int WriteAll( out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // DataTableから書き込みリスト生成
                ArrayList paraCampaignMngList = new ArrayList();
                foreach ( DataRow row in _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows )
                {
                    // 売価率と売価額の変換
                    double rateVal = 0.0;
                    double rateValBk = 0.0;
                    double priceFl = 0.0;
                    double priceFlBk = 0.0;

                    if (row[ct_COL_RATEVAL] != null && row[ct_COL_RATEVAL] != DBNull.Value)
                    {
                        rateVal = (double)row[ct_COL_RATEVAL];
                    }
                    if (row[ct_COL_RATEVAL_BACKUP] != null && row[ct_COL_RATEVAL_BACKUP] != DBNull.Value)
                    {
                        rateValBk = (double)row[ct_COL_RATEVAL_BACKUP];
                    }
                    if (row[ct_COL_PRICEFL] != null && row[ct_COL_PRICEFL] != DBNull.Value)
                    {
                        priceFl = (double)row[ct_COL_PRICEFL];
                    }
                    if (row[ct_COL_PRICEFL_BACKUP] != null && row[ct_COL_PRICEFL_BACKUP] != DBNull.Value)
                    {
                        priceFlBk = (double)row[ct_COL_PRICEFL_BACKUP];
                    }

                    // 変更有無チェック
                    if (((int)row[ct_COL_CAMPAIGNCODE] == (int)row[ct_COL_CAMPAIGNCODE_BACKUP]) &&
                        (rateVal == rateValBk) &&
                        (priceFl == priceFlBk))
                    {
                        // 変更可能な項目がSearch時と変わらないので対象外にする
                        continue;
                    }

                    CampaignMngWork campaignMngWork = CopyToCampaignMngWorkFromDataRow( row );
                    paraCampaignMngList.Add( campaignMngWork );
                }
                // 変更有無チェック
                if ( paraCampaignMngList.Count == 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "更新対象のデータが存在しません";
                    return status;
                }

                object paraObj = (object)paraCampaignMngList;


                // 書き込み処理
                status = this._iCampaignMngDB.Write( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    // 正常更新

                    // DataTableを使用している場合のみ書き換えを行う
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
                {
                    // 何かしらのエラー発生
                    message = "登録に失敗しました。";
                    return status;
                }
            }
            catch ( Exception ex )
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iCampaignMngDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }

        /// <summary>
        /// 内部データテーブル書き換え処理
        /// </summary>
        /// <param name="paraObj"></param>
        private void UpdateDataTable( object retObj )
        {
            if ( retObj is ArrayList )
            {
                foreach ( object obj in (retObj as ArrayList) )
                {
                    if ( obj is CampaignMngWork )
                    {
                        CampaignMngWork retWork = (CampaignMngWork)obj;

                        DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );
                        
                        if ( row == null )
                        {
                            // 追加
                            row = _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].NewRow();
                            CopyToDataRowFromCampaignMngWork(ref row, retWork);
                            _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows.Add( row );
                        }
                        else
                        {
                            // 更新
                            CopyToDataRowFromCampaignMngWork(ref row, retWork);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 内部データテーブル書き換え処理(物理削除後)
        /// </summary>
        /// <param name="retObj"></param>
        private void DeleteFromDataTable( ArrayList campaignMngWorkList )
        {
            foreach ( object obj in campaignMngWorkList )
            {
                if ( obj is CampaignMngWork )
                {
                    CampaignMngWork retWork = (CampaignMngWork)obj;

                    DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );

                    if ( row != null )
                    {
                        // 削除
                        _dataTableList.Tables[ct_TABLE_CAMPAIGNMNG].Rows.Remove( row );
                    }
                }
            }
        }
        #endregion

        #region LogicalDelete 論理削除処理
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="campaignMngList">論理削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 論理削除処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList campaignMngList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // データ数分ループ
                ArrayList paraCampaignMngList = new ArrayList();
                CampaignMngWork campaignMngWork = null;

                for (int i = 0; i < campaignMngList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    campaignMngWork = CopyToCampaignMngWorkFromCampaignMng((CampaignMng)campaignMngList[i]);

                    paraCampaignMngList.Add(campaignMngWork);
                }
                object paraObj = (object)paraCampaignMngList;

                // 論理削除処理
                status = this._iCampaignMngDB.LogicalDelete( ref paraObj );

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
                {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iCampaignMngDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region Revival 復旧処理
        /// <summary>
        /// 復旧処理
        /// </summary>
        /// <param name="campaignMngList">論理削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 復旧処理（論理削除復旧）を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int Revival(ref ArrayList campaignMngList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // データ数分ループ
                ArrayList paraCampaignMngList = new ArrayList();
                CampaignMngWork campaignMngWork = null;

                for (int i = 0; i < campaignMngList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    campaignMngWork = CopyToCampaignMngWorkFromCampaignMng((CampaignMng)campaignMngList[i]);

                    paraCampaignMngList.Add(campaignMngWork);
                }

                object paraObj = (object)paraCampaignMngList;

                // 書き込み処理
                status = this._iCampaignMngDB.RevivalLogicalDelete(ref paraObj);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        UpdateDataTable( paraObj );
                    }
                }
                else
                {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iCampaignMngDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region Delete 削除処理
        /// <summary>
        /// 削除処理
        /// </summary>
        /// <param name="campaignMngList">削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 削除処理（物理削除）を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int Delete(ref ArrayList campaignMngList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                byte[] paraCampaignMngWork = null;
                CampaignMngWork campaignMngWork = null;
                ArrayList campaignMngWorkList = new ArrayList(); // ワーククラス格納用ArrayList

                // ワーククラス格納用ArrayListへ詰め替え
                for (int i = 0; i < campaignMngList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    campaignMngWork = CopyToCampaignMngWorkFromCampaignMng((CampaignMng)campaignMngList[i]);
                    campaignMngWorkList.Add(campaignMngWork);
                }
                // ArrayListから配列を生成
                CampaignMngWork[] campaignMngWorks = (CampaignMngWork[])campaignMngWorkList.ToArray(typeof(CampaignMngWork));

                // シリアライズ
                paraCampaignMngWork = XmlByteSerializer.Serialize(campaignMngWorks);

                // 物理削除処理
                status = this._iCampaignMngDB.Delete(paraCampaignMngWork);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        // テーブルから削除
                        DeleteFromDataTable( campaignMngWorkList );
                    }
                }
                else
                {
                    // 何かしらのエラー発生
                    message = "削除に失敗しました。";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // オフライン時はnullをセット
                this._iCampaignMngDB = null;
                // 通信エラー
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region データセット列情報構築処理
        /// <summary>
        /// データセット列情報構築処理
        /// </summary>
        /// <param name="ds">データセット</param>
        /// <remarks>
        /// <br>Note       : データセットの列情報を構築します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //----------------------------------------------------------------
            // キャンペーン管理テーブル列定義
            //----------------------------------------------------------------
            DataTable campaignMngTable = new DataTable( ct_TABLE_CAMPAIGNMNG );


            // 作成日時
            campaignMngTable.Columns.Add( ct_COL_CREATEDATETIME, typeof( DateTime ) );
            // 更新日時
            campaignMngTable.Columns.Add( ct_COL_UPDATEDATETIME, typeof( DateTime ) );
            // 企業コード
            campaignMngTable.Columns.Add( ct_COL_ENTERPRISECODE, typeof( string ) );
            // GUID
            campaignMngTable.Columns.Add( ct_COL_FILEHEADERGUID, typeof( Guid ) );
            // 更新従業員コード
            campaignMngTable.Columns.Add( ct_COL_UPDEMPLOYEECODE, typeof( string ) );
            // 更新アセンブリID1
            campaignMngTable.Columns.Add( ct_COL_UPDASSEMBLYID1, typeof( string ) );
            // 更新アセンブリID2
            campaignMngTable.Columns.Add( ct_COL_UPDASSEMBLYID2, typeof( string ) );
            // 論理削除区分
            campaignMngTable.Columns.Add( ct_COL_LOGICALDELETECODE, typeof( Int32 ) );
            // 拠点コード
            campaignMngTable.Columns.Add( ct_COL_SECTIONCODE, typeof( string ) );
            // 商品中分類コード
            campaignMngTable.Columns.Add( ct_COL_GOODSMGROUP, typeof( Int32 ) );
            // BL商品コード
            campaignMngTable.Columns.Add( ct_COL_BLGOODSCODE, typeof( Int32 ) );
            // 商品メーカーコード
            campaignMngTable.Columns.Add( ct_COL_GOODSMAKERCD, typeof( Int32 ) );
            // 商品番号
            campaignMngTable.Columns.Add( ct_COL_GOODSNO, typeof( string ) );
            // 売上目標金額
            campaignMngTable.Columns.Add(ct_COL_SALESTARGETMONEY, typeof(Int64));
            // 売上目標粗利額
            campaignMngTable.Columns.Add(ct_COL_SALESTARGETPROFIT, typeof(Int64));
            // 売上目標数量
            campaignMngTable.Columns.Add(ct_COL_SALESTARGETCOUNT, typeof(double));
            // キャンペーンコード
            campaignMngTable.Columns.Add( ct_COL_CAMPAIGNCODE, typeof( Int32 ) );
            // キャンペーンコードガイド
            campaignMngTable.Columns.Add(ct_COL_CAMPAIGNCODEGUIDE, typeof(Int32));
            // キャンペーン名称
            campaignMngTable.Columns.Add(ct_COL_CAMPAIGNNAME, typeof(string));
            // 売価率
            campaignMngTable.Columns.Add(ct_COL_RATEVAL, typeof(double));
            // 売価額
            campaignMngTable.Columns.Add(ct_COL_PRICEFL, typeof(double));

            // キャンペーンコード(前回退避)
            campaignMngTable.Columns.Add( ct_COL_CAMPAIGNCODE_BACKUP, typeof( Int32 ) );
            // 売価率(前回退避)
            campaignMngTable.Columns.Add(ct_COL_RATEVAL_BACKUP, typeof(double));
            // 売価額(前回退避)
            campaignMngTable.Columns.Add(ct_COL_PRICEFL_BACKUP, typeof(double));

            // グループコード
            campaignMngTable.Columns.Add(ct_COL_BLGROUPCODE, typeof(Int32));
            
            // 拠点名称
            campaignMngTable.Columns.Add( ct_COL_SECTIONNM, typeof( string ) );
            // 商品中分類名称
            campaignMngTable.Columns.Add( ct_COL_GOODSMGROUPNAME, typeof( string ) );
            // BLグループ名称
            campaignMngTable.Columns.Add( ct_COL_BLGROUPNAME, typeof( string ) );
            // BL商品コード名称
            campaignMngTable.Columns.Add( ct_COL_BLGOODSNAME, typeof( string ) );
            // メーカー名称
            campaignMngTable.Columns.Add( ct_COL_MAKERNAME, typeof( string ) );
            // 商品名称
            campaignMngTable.Columns.Add( ct_COL_GOODSNAME, typeof( string ) );
            
            
            # region [ソート用]
            // 拠点コード
            campaignMngTable.Columns.Add( ct_COL_SECTIONCODE_SORT, typeof( string ) );
            // 商品中分類コード
            campaignMngTable.Columns.Add( ct_COL_GOODSMGROUP_SORT, typeof( Int32 ) );
            // BL商品コード
            campaignMngTable.Columns.Add( ct_COL_BLGOODSCODE_SORT, typeof( Int32 ) );
            // 商品メーカーコード
            campaignMngTable.Columns.Add( ct_COL_GOODSMAKERCD_SORT, typeof( Int32 ) );
            // グループコード
            campaignMngTable.Columns.Add( ct_COL_BLGROUPCODE_SORT, typeof( Int32 ) );
            # endregion


            // 論理削除日(表示用)
            campaignMngTable.Columns.Add( ct_COL_LOGICALDELETEDATE, typeof( string ) );
            // オブジェクト(内部保持用)
            campaignMngTable.Columns.Add( ct_COL_CAMPAIGNMNGWORKOBJECT, typeof( CampaignMngWork ) );

            this._dataTableList.Tables.Add(campaignMngTable);

            //----------------------------------------------------------------
            // データビュー生成
            //----------------------------------------------------------------
            this._dataView = new DataView( campaignMngTable );
            this._dataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}",
                                                ct_COL_SECTIONCODE_SORT,
                                                ct_COL_GOODSMAKERCD_SORT,
                                                ct_COL_GOODSMGROUP_SORT,
                                                ct_COL_BLGROUPCODE_SORT,
                                                ct_COL_BLGOODSCODE_SORT,
                                                ct_COL_GOODSNO 
                                                );
        }
        #endregion

        #region クラスメンバコピー処理
        /// <summary>
        /// クラスメンバーコピー処理（キャンペーン管理クラス⇒キャンペーン管理ワーククラス）
        /// </summary>
        /// <param name="campaignMng">キャンペーン管理クラス</param>
        /// <returns>CampaignMngWork</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン管理クラスからキャンペーン管理ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private CampaignMngWork CopyToCampaignMngWorkFromCampaignMng(CampaignMng campaignMng)
        {
            CampaignMngWork campaignMngWork = new CampaignMngWork();

            campaignMngWork.CreateDateTime = campaignMng.CreateDateTime;            // 作成日時
            campaignMngWork.UpdateDateTime = campaignMng.UpdateDateTime;            // 更新日時
            campaignMngWork.EnterpriseCode = campaignMng.EnterpriseCode;            // 企業コード
            campaignMngWork.FileHeaderGuid = campaignMng.FileHeaderGuid;            // GUID
            campaignMngWork.UpdEmployeeCode = campaignMng.UpdEmployeeCode;          // 更新従業員コード
            campaignMngWork.UpdAssemblyId1 = campaignMng.UpdAssemblyId1;            // 更新アセンブリID1
            campaignMngWork.UpdAssemblyId2 = campaignMng.UpdAssemblyId2;            // 更新アセンブリID2
            campaignMngWork.LogicalDeleteCode = campaignMng.LogicalDeleteCode;      // 論理削除区分

            campaignMngWork.SectionCode = campaignMng.SectionCode;                  // 拠点コード
            campaignMngWork.GoodsMGroup = campaignMng.GoodsMGroup;                  // 商品中分類コード
            campaignMngWork.BLGroupCode = campaignMng.BLGroupCode;                  // BLグループコード
            campaignMngWork.BLGoodsCode = campaignMng.BLGoodsCode;                  // BL商品コード
            campaignMngWork.GoodsMakerCd = campaignMng.GoodsMakerCd;                // 商品メーカーコード
            campaignMngWork.GoodsNo = campaignMng.GoodsNo;                          // 商品番号
            campaignMngWork.SalesTargetMoney = campaignMng.SalesTargetMoney;        // 売上目標金額
            campaignMngWork.SalesTargetProfit = campaignMng.SalesTargetProfit;      // 売上目標粗利額
            campaignMngWork.SalesTargetCount = campaignMng.SalesTargetCount;        // 売上目標数量
            campaignMngWork.CampaignCode = campaignMng.CampaignCode;                // キャンペーンコード
            campaignMngWork.RateVal = campaignMng.RateVal;                          // 売価率
            campaignMngWork.PriceFl = campaignMng.PriceFl;                          // 売価額
            campaignMngWork.SectionNm = campaignMng.SectionNm;                      // 拠点名称
            campaignMngWork.GoodsMGroupName = campaignMng.GoodsMGroupName;          // 商品中分類名称
            campaignMngWork.BLGroupName = campaignMng.BLGroupName;                  // BLグループ名称
            campaignMngWork.BLGoodsName = campaignMng.BLGoodsName;                  // BL商品コード名称
            campaignMngWork.MakerName = campaignMng.MakerName;                      // メーカー名称
            campaignMngWork.GoodsName = campaignMng.GoodsName;                      // 商品名称
            
            return campaignMngWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（キャンペーン管理ワーククラス⇒キャンペーン管理クラス）
        /// </summary>
        /// <param name="campaignMngWork">キャンペーン管理ワーククラス</param>
        /// <returns>CampaignMng</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン管理ワーククラスからキャンペーン管理クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private CampaignMng CopyToCampaignMngFromCampaignMngWork(CampaignMngWork campaignMngWork)
        {
            CampaignMng campaignMng = new CampaignMng();

            campaignMng.CreateDateTime = campaignMngWork.CreateDateTime;            // 作成日時
            campaignMng.UpdateDateTime = campaignMngWork.UpdateDateTime;            // 更新日時
            campaignMng.EnterpriseCode = campaignMngWork.EnterpriseCode;            // 企業コード
            campaignMng.FileHeaderGuid = campaignMngWork.FileHeaderGuid;            // GUID
            campaignMng.UpdEmployeeCode = campaignMngWork.UpdEmployeeCode;          // 更新従業員コード
            campaignMng.UpdAssemblyId1 = campaignMngWork.UpdAssemblyId1;            // 更新アセンブリID1
            campaignMng.UpdAssemblyId2 = campaignMngWork.UpdAssemblyId2;            // 更新アセンブリID2
            campaignMng.LogicalDeleteCode = campaignMngWork.LogicalDeleteCode;      // 論理削除区分
            campaignMng.SectionCode = campaignMngWork.SectionCode;                  // 拠点コード
            campaignMng.GoodsMGroup = campaignMngWork.GoodsMGroup;                  // 商品中分類コード
            campaignMng.BLGroupCode = campaignMngWork.BLGroupCode;                  // BLグループコード
            campaignMng.BLGoodsCode = campaignMngWork.BLGoodsCode;                  // BL商品コード
            campaignMng.GoodsMakerCd = campaignMngWork.GoodsMakerCd;                // 商品メーカーコード
            campaignMng.GoodsNo = campaignMngWork.GoodsNo;                          // 商品番号
            campaignMng.SalesTargetMoney = campaignMngWork.SalesTargetMoney;        // 売上目標金額
            campaignMng.SalesTargetProfit = campaignMngWork.SalesTargetProfit;      // 売上目標粗利額
            campaignMng.SalesTargetCount = campaignMngWork.SalesTargetCount;        // 売上目標数量
            campaignMng.CampaignCode = campaignMngWork.CampaignCode;                // キャンペーンコード
            campaignMng.RateVal = campaignMngWork.RateVal;                          // 売価率
            campaignMng.PriceFl = campaignMngWork.PriceFl;                          // 売価額
            campaignMng.SectionNm = campaignMngWork.SectionNm;                      // 拠点名称
            campaignMng.GoodsMGroupName = campaignMngWork.GoodsMGroupName;          // 商品中分類名称
            campaignMng.BLGroupName = campaignMngWork.BLGroupName;                  // BLグループ名称
            campaignMng.BLGoodsName = campaignMngWork.BLGoodsName;                  // BL商品コード名称
            campaignMng.MakerName = campaignMngWork.MakerName;                      // メーカー名称
            campaignMng.GoodsName = campaignMngWork.GoodsName;                      // 商品名称
            
            return campaignMng;
        }

        /// <summary>
        /// クラスメンバーコピー処理（キャンペーン管理クラス⇒DataRow）
        /// </summary>
        /// <param name="dr">データ行</param>
        /// <param name="campaignMngWork">キャンペーン管理クラス</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン管理ワーククラスからキャンペーン管理クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private void CopyToDataRowFromCampaignMngWork(ref DataRow dr, CampaignMngWork campaignMngWork)
        {
            # region [dr←campaignMng]
            dr[ct_COL_CREATEDATETIME] = campaignMngWork.CreateDateTime;         // 作成日時
            dr[ct_COL_UPDATEDATETIME] = campaignMngWork.UpdateDateTime;         // 更新日時
            dr[ct_COL_ENTERPRISECODE] = campaignMngWork.EnterpriseCode;         // 企業コード
            dr[ct_COL_FILEHEADERGUID] = campaignMngWork.FileHeaderGuid;         // GUID
            dr[ct_COL_UPDEMPLOYEECODE] = campaignMngWork.UpdEmployeeCode;       // 更新従業員コード
            dr[ct_COL_UPDASSEMBLYID1] = campaignMngWork.UpdAssemblyId1;         // 更新アセンブリID1
            dr[ct_COL_UPDASSEMBLYID2] = campaignMngWork.UpdAssemblyId2;         // 更新アセンブリID2
            dr[ct_COL_LOGICALDELETECODE] = campaignMngWork.LogicalDeleteCode;   // 論理削除区分
            dr[ct_COL_SECTIONCODE] = campaignMngWork.SectionCode;               // 拠点コード
            dr[ct_COL_GOODSMGROUP] = campaignMngWork.GoodsMGroup;               // 商品中分類コード
            dr[ct_COL_BLGOODSCODE] = campaignMngWork.BLGoodsCode;               // BL商品コード
            dr[ct_COL_GOODSMAKERCD] = campaignMngWork.GoodsMakerCd;             // 商品メーカーコード
            dr[ct_COL_GOODSNO] = campaignMngWork.GoodsNo;                       // 商品番号
            dr[ct_COL_SALESTARGETMONEY] = campaignMngWork.SalesTargetMoney;     // 売上目標金額
            dr[ct_COL_SALESTARGETPROFIT] = campaignMngWork.SalesTargetProfit;   // 売上目標粗利額
            dr[ct_COL_SALESTARGETCOUNT] = campaignMngWork.SalesTargetCount;     // 売上目標数量
            dr[ct_COL_CAMPAIGNCODE] = campaignMngWork.CampaignCode;             // キャンペーンコード
            dr[ct_COL_CAMPAIGNNAME] = GetCampaignName(campaignMngWork.CampaignCode);    // キャンペーン名称

            // 売価率
            if (campaignMngWork.RateVal == 0.00)
            {
                dr[ct_COL_RATEVAL] = DBNull.Value;
                dr[ct_COL_RATEVAL_BACKUP] = DBNull.Value;
            }
            else
            {
                dr[ct_COL_RATEVAL] = campaignMngWork.RateVal;
                dr[ct_COL_RATEVAL_BACKUP] = campaignMngWork.RateVal;                // 売価率(前回値退避)
            }
            

            // 売価額
            if (campaignMngWork.PriceFl == 0.00)
            {
                dr[ct_COL_PRICEFL] = DBNull.Value;
                dr[ct_COL_PRICEFL_BACKUP] = DBNull.Value;
            }
            else
            {
                dr[ct_COL_PRICEFL] = campaignMngWork.PriceFl;
                dr[ct_COL_PRICEFL_BACKUP] = campaignMngWork.PriceFl;            // 売価額(前回値退避)
            }

            dr[ct_COL_CAMPAIGNCODE_BACKUP] = campaignMngWork.CampaignCode;      // キャンペーンコード(前回値退避)

            // 論理削除日(表示用)
            if ( campaignMngWork.LogicalDeleteCode == 0 )
            {
                dr[ct_COL_LOGICALDELETEDATE] = string.Empty;
            }
            else
            {
                dr[ct_COL_LOGICALDELETEDATE] = TDateTime.DateTimeToString( "ggYY/MM/DD", campaignMngWork.UpdateDateTime );
            }

            dr[ct_COL_SECTIONNM] = campaignMngWork.SectionNm;                   // 拠点名称
            dr[ct_COL_GOODSMGROUPNAME] = campaignMngWork.GoodsMGroupName;       // 商品中分類名称
            dr[ct_COL_BLGROUPNAME] = campaignMngWork.BLGroupName;               // BLグループ名称
            dr[ct_COL_BLGOODSNAME] = campaignMngWork.BLGoodsName;               // BL商品コード名称
            dr[ct_COL_MAKERNAME] = campaignMngWork.MakerName;                   // メーカー名称
            dr[ct_COL_GOODSNAME] = campaignMngWork.GoodsName;                   // 商品名称
            dr[ct_COL_BLGROUPCODE] = campaignMngWork.BLGroupCode;               // BLグループコード

            // ソート用カラム
            dr[ct_COL_SECTIONCODE_SORT] = GetSortValue( campaignMngWork.SectionCode );      // 拠点コード
            dr[ct_COL_GOODSMAKERCD_SORT] = GetSortValue( campaignMngWork.GoodsMakerCd );    // 商品メーカーコード
            dr[ct_COL_GOODSMGROUP_SORT] = GetSortValue( campaignMngWork.GoodsMGroup );      // 商品中分類コード
            dr[ct_COL_BLGROUPCODE_SORT] = GetSortValue( campaignMngWork.BLGroupCode );      // BLグループコード
            dr[ct_COL_BLGOODSCODE_SORT] = GetSortValue( campaignMngWork.BLGoodsCode );      // BL商品コード

            // オブジェクト(内部保持用)
            dr[ct_COL_CAMPAIGNMNGWORKOBJECT] = campaignMngWork;
            # endregion
        }
        /// <summary>
        /// ソート値取得（数値）
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private int GetSortValue( int value )
        {
            if ( value != 0 )
            {
                return value;
            }
            else
            {
                // 未設定が後ろになるようにする
                return Int32.MaxValue;
            }
        }
        /// <summary>
        /// ソート値取得（文字列）
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        private string GetSortValue( string value )
        {
            if ( value.Trim() != string.Empty )
            {
                return value;
            }
            else
            {
                // 未設定が後ろになるようにする
                // (※現状は拠点のみで使用しているので便宜的にAAにしています)
                return "AA";
            }
        }
        /// <summary>
        /// クラスメンバーコピー処理（DataRow⇒キャンペーン管理クラス）
        /// </summary>
        /// <param name="row"></param>
        /// <returns>CampaignMngWork</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン管理ワーククラスからキャンペーン管理クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private CampaignMngWork CopyToCampaignMngWorkFromDataRow( DataRow row )
        {
            CampaignMngWork campaignMngWork = (CampaignMngWork)row[ct_COL_CAMPAIGNMNGWORKOBJECT];
            
            // 書き換え可能項目のみ差し替える
            campaignMngWork.CampaignCode = (int)row[ct_COL_CAMPAIGNCODE];   // キャンペーンコード

            // 売価率
            if (row[ct_COL_RATEVAL] == null || row[ct_COL_RATEVAL] == DBNull.Value)
            {
                campaignMngWork.RateVal = 0.00;
            }
            else
            {
                campaignMngWork.RateVal = (double)row[ct_COL_RATEVAL];
            }

            // 売価額
            if (row[ct_COL_PRICEFL] == null || row[ct_COL_PRICEFL] == DBNull.Value)
            {
                campaignMngWork.PriceFl = 0.00;
            }
            else
            {
                campaignMngWork.PriceFl = (double)row[ct_COL_PRICEFL];
            }

            return campaignMngWork;
        }

        /// <summary>
        /// 抽出条件クラスメンバーコピー処理
        /// </summary>
        /// <param name="paraData"></param>
        /// <returns></returns>
        private CampaignMngOrderWork CopyToCampaignMngOrderWorkFromCampaignMngOrder( CampaignMngOrder paraData )
        {
            CampaignMngOrderWork paraWork = new CampaignMngOrderWork();
            
            # region [paraWork←paraData]
            paraWork.EnterpriseCode = paraData.EnterpriseCode;      // 企業コード
            paraWork.SectionCode = paraData.SectionCode;            // 拠点コード
            paraWork.St_GoodsMGroup = paraData.St_GoodsMGroup;      // 開始商品中分類コード
            paraWork.Ed_GoodsMGroup = paraData.Ed_GoodsMGroup;      // 終了商品中分類コード
            paraWork.St_BLGroupCode = paraData.St_BLGroupCode;      // 開始BLグループコード
            paraWork.Ed_BLGroupCode = paraData.Ed_BLGroupCode;      // 終了BLグループコード
            paraWork.St_BLGoodsCode = paraData.St_BLGoodsCode;      // 開始BL商品コード
            paraWork.Ed_BLGoodsCode = paraData.Ed_BLGoodsCode;      // 終了BL商品コード
            paraWork.St_GoodsMakerCd = paraData.St_GoodsMakerCd;    // 開始商品メーカーコード
            paraWork.Ed_GoodsMakerCd = paraData.Ed_GoodsMakerCd;    // 終了商品メーカーコード
            # endregion
            
            return paraWork;
        }

        /// <summary>
        /// キャンペーン名称取得処理
        /// </summary>
        /// <remarks>
        /// <br>Note        : キャンペーン設定マスタを読み込み、キャンペーン名称を取得します。</br>
        /// <br>Programmer  : 30413 犬飼</br>
        /// <br>Date        : 2009/05/28</br>
        /// </remarks>
        private string GetCampaignName(int campaignCode)
        {
            string name = string.Empty;

            if (_campaignStAcs == null)
            {
                _campaignStAcs = new CampaignStAcs();
            }

            if (_campaignStDic == null)
            {
                this._campaignStDic = new Dictionary<int, CampaignSt>();

                ArrayList retList;
                int status = this._campaignStAcs.SearchAll(out retList, EnterpriseCode);

                if (status == 0)
                {
                    foreach (CampaignSt campaignSt in retList)
                    {
                        if (campaignSt.LogicalDeleteCode == 0)
                        {
                            this._campaignStDic.Add(campaignSt.CampaignCode, campaignSt);
                        }
                    }
                }
            }

            if (this._campaignStDic.ContainsKey(campaignCode))
            {
                name = this._campaignStDic[campaignCode].CampaignName;
            }

            return name;
        }
        #endregion

        #region SearchProc 検索処理メイン（論理削除含む）
        /// <summary>
        /// 検索処理メイン（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果テーブル</param>
        /// <param name="campaignMngList">キャンペーン管理オブジェクトリスト</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン管理マスタの複数検索処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        private int SearchProc( CampaignMngOrder paraData, out ArrayList retWorkList, ConstantManagement.LogicalMode logicalMode, out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            retWorkList = null;

            try
            {
                //ArrayList paraList = new ArrayList();
                //==========================================
                // キャンペーン管理マスタ読み込み
                //==========================================
                CampaignMngOrderWork paraWork = CopyToCampaignMngOrderWorkFromCampaignMngOrder( paraData );

                // リモート戻りリスト
                object campaignMngWorkList = null;
                // キャンペーン管理マスタ検索
                status = this._iCampaignMngDB.Search( out campaignMngWorkList, paraWork, 0, logicalMode );

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retWorkList = (ArrayList)campaignMngWorkList;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }
        #endregion

        #region Read 検索処理
        /// <summary>
        /// キャンペーン管理レコード取得処理
        /// </summary>
        /// <param name="campaignMng">キャンペーン管理データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。
        ///                  campaignMngクラスに検索データを設定し、結果もcampaignMngクラスに格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int Read(ref CampaignMng campaignMng)
        {
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // 抽出条件パラメータ
                CampaignMngWork campaignMngWork = CopyToCampaignMngWorkFromCampaignMng( campaignMng );

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize( campaignMngWork );
                status = this._iCampaignMngDB.Read( ref parabyte, 0 );

                if (status == 0)
                {
                    // XMLの読み込み
                    campaignMngWork = (CampaignMngWork)XmlByteSerializer.Deserialize( parabyte, typeof( CampaignMngWork ) );
                }

                if (status == 0)
                {
                    // クラス内メンバコピー
                    campaignMng = CopyToCampaignMngFromCampaignMngWork( campaignMngWork );
                }

                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                campaignMng = null;
                //オフライン時はnullをセット
                this._iCampaignMngDB = null;
                return -1;
            }
        }
        #endregion

        #region キャンペーン売価率、売価額取得処理

        // ADD 2009/08/31 チケット[14194]対応 ------>>>
        /// <summary>
        /// キャンペーン売価率、売価額取得処理（改訂版）
        /// </summary>
        /// <param name="campaignMng">抽出結果キャンペーン管理データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsMGroup">商品中分類</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="applyDate">適用日</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価率、売価額取得の取得を行います。
        ///                  抽出条件からキャンペーン売価率、売価額取得処理が設定されているキャンペーン管理データを返します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// <br>Note       : 適用日が期間外の場合、次に該当するキャンペーン管理マスタのレコードを取得するようGetRatePriceOfCampaignMng()を改造</br>
        /// <br>Programmer : 30434 工藤</br>
        /// <br>Date       : 2009/08/31</br>
        /// </remarks>
        private int GetRatePriceOfCampaignMng2(
            out CampaignMng campaignMng,
            string enterpriseCode,
            string sectionCode,
            int customerCode,
            int goodsMakerCd,
            int goodsMGroup,
            int blGoodsCode,
            string goodsNo,
            DateTime applyDate
        )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ADD 2009/08/25 チケット[14065]対応 ------>>>
            // キーを設定する際、スペースは削っているので、パラメータもスペースを削る
            sectionCode = sectionCode.Trim();
            goodsNo     = goodsNo.Trim();
            // ADD 2009/08/25 チケット[14065]対応 ------<<<

            #region キャンペーン管理マスタの拠点検索結果をキャッシュ

            if (_campaignMngDic == null)
            {
                // キャンペーン管理キャッシュにデータが無いので取得
                CampaignMngOrder campaignMngOrder = new CampaignMngOrder();
                campaignMngOrder.EnterpriseCode = enterpriseCode;
                campaignMngOrder.SectionCode = null;

                List<CampaignMng> retList;
                string message;

                // キャンペーン管理マスタの全検索
                status = Search(campaignMngOrder, out retList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 全検索で失敗
                    campaignMng = null;

                    _statusOfResult = "キャンペーン管理マスタの全検索で失敗";

                    return status;
                }

                //キャンペーン管理データのキャッシュ化
                _campaignMngDic = new Dictionary<DICKEY, CampaignMng>();

                foreach (CampaignMng wkCampaignMng in retList)
                {
                    if (wkCampaignMng.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    // 追加キー作成
                    DICKEY addKey = new DICKEY();
                    addKey.sectionCode = wkCampaignMng.SectionCode.TrimEnd();
                    addKey.goodsMGroup = wkCampaignMng.GoodsMGroup;
                    addKey.blGoodsCode = wkCampaignMng.BLGoodsCode;
                    addKey.goodsMakerCd = wkCampaignMng.GoodsMakerCd;
                    addKey.goodsNo = wkCampaignMng.GoodsNo.Trim();

                    if (!_campaignMngDic.ContainsKey(addKey))
                    {
                        _campaignMngDic.Add(addKey, wkCampaignMng);
                    }
                }
            }

            #endregion // キャンペーン管理マスタの拠点検索結果をキャッシュ

            #region 候補となるキャンペーン管理マスタのレコードを全て取得

            // キャンペーン管理キャッシュからデータ取得
            List<KeyValuePair<string, CampaignMng>> foundCampaignMngList = new List<KeyValuePair<string, CampaignMng>>();
            {
                // キー作成
                DICKEY key = new DICKEY();
                key.sectionCode = sectionCode.TrimEnd();
                key.goodsMakerCd = goodsMakerCd;
                key.goodsNo = goodsNo.Trim();
                if (!string.IsNullOrEmpty(key.goodsNo) && _campaignMngDic.ContainsKey(key))
                {
                    // ①メーカー＋品番
                    string info = string.Format(
                        "①拠点(={0}) + メーカー(={1}) + 品番(={2})",
                        sectionCode,
                        goodsMakerCd,
                        goodsNo
                    );
                    foundCampaignMngList.Add(new KeyValuePair<string, CampaignMng>(info, _campaignMngDic[key].Clone()));
                }

                // キー変更
                key.goodsNo = string.Empty;
                key.blGoodsCode = blGoodsCode;
                if (key.blGoodsCode > 0 && _campaignMngDic.ContainsKey(key))
                {
                    // ②メーカー＋BLコード
                    string info = string.Format(
                        "②拠点(={0}) + メーカー(={1}) + BLコード(={2})",
                        sectionCode,
                        goodsMakerCd,
                        blGoodsCode
                    );
                    foundCampaignMngList.Add(new KeyValuePair<string, CampaignMng>(info, _campaignMngDic[key].Clone()));
                }

                // キー変更
                key.blGoodsCode = 0;
                key.goodsMGroup = goodsMGroup;
                if (key.goodsMGroup > 0 && _campaignMngDic.ContainsKey(key))
                {
                    // ③メーカー＋商品中分類
                    string info = string.Format(
                        "③拠点(={0}) + メーカー(={1}) + 商品中分類(={2})",
                        sectionCode,
                        goodsMakerCd,
                        goodsMGroup
                    );
                    foundCampaignMngList.Add(new KeyValuePair<string, CampaignMng>(info, _campaignMngDic[key].Clone()));
                }

                // キー変更
                key.goodsMGroup = 0;
                if (_campaignMngDic.ContainsKey(key))
                {
                    // ④メーカー
                    string info = string.Format("④拠点(={0}) + メーカー(={1})", sectionCode, goodsMakerCd);
                    foundCampaignMngList.Add(new KeyValuePair<string, CampaignMng>(info, _campaignMngDic[key].Clone()));
                }

                if (foundCampaignMngList.Count.Equals(0))
                {
                    // 該当データ無し
                    campaignMng = null;

                    // ADD 2009/08/25 チケット[14065]対応 ------>>>
                    _statusOfResult = "キャンペーン管理マスタに該当データ無し";

                    // 全社で再検索
                    int sectionCodeNo = int.Parse(sectionCode.Trim());
                    if (sectionCodeNo > 0)
                    {
                        _statusOfResult = "全社設定で再検索";

                        return GetRatePriceOfCampaignMng(
                            out campaignMng,
                            enterpriseCode,
                            "00",
                            customerCode,
                            goodsMakerCd,
                            goodsMGroup,
                            blGoodsCode,
                            goodsNo,
                            applyDate
                        );
                    }
                    // ADD 2009/08/25 チケット[14065]対応 ------<<<

                    return status;
                }
            }   // List<KeyValuePair<string, CampaignMng>> foundCampaignMngList = new List<KeyValuePair<string, CampaignMng>>();

            #endregion // 候補となるキャンペーン管理マスタのレコードを全て取得

            CampaignMng readCampaignMng = null;
            string keyInfo = string.Empty;
            foreach (KeyValuePair<string, CampaignMng> foundCampaignMng in foundCampaignMngList)
            {
                readCampaignMng = foundCampaignMng.Value;
                keyInfo         = foundCampaignMng.Key;

                // キャンペーン設定マスタの読込(ディクショナリーが未設定の場合もあるので)
                string name = GetCampaignName(readCampaignMng.CampaignCode);
                Debug.WriteLine(readCampaignMng.CampaignCode.ToString() + ":" + name);

                // キャンペーン設定マスタと一致するか
                if (this._campaignStDic.ContainsKey(readCampaignMng.CampaignCode))
                {
                    CampaignSt campaignSt = this._campaignStDic[readCampaignMng.CampaignCode];
                    //>>>2010/04/13
                    if (campaignSt.CampaignObjDiv == 9) // 9:中止
                    {
                        campaignMng = null;
                        readCampaignMng = null;
                        _statusOfResult = "キャンペーン管理マスタ　キャンペーン対象区分[2:中止]";
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                    //<<<2010/04/13

                    //>>>2010/04/13
                    //if (campaignSt.SectionCode.TrimEnd() != sectionCode.TrimEnd())
                    if ((campaignSt.SectionCode.TrimEnd() != "00") &&
                        (campaignSt.SectionCode.TrimEnd() != sectionCode.TrimEnd()))
                    //<<<2010/04/13
                    {
                        // 拠点が不一致の場合は処理終了
                        campaignMng = null;
                        readCampaignMng = null;

                        _statusOfResult = "キャンペーン管理マスタとキャンペーン設定マスタの拠点が不一致";

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                    // 適用日が範囲内か
                    if ((campaignSt.ApplyStaDate > applyDate) ||
                        (campaignSt.ApplyEndDate < applyDate))
                    {
                        // 適用開始日前、または適用終了日後の場合は処理終了
                        campaignMng = null;
                        readCampaignMng = null;

                        _statusOfResult = "適用日が範囲外";
                        Debug.WriteLine(_statusOfResult + ":" + keyInfo);

                        // 期間外の場合、次に優先されるキャンペーン管理情報へ
                        continue;
                        // TODO:ゴミ掃除…return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                    if (campaignSt.CampaignObjDiv == 0)
                    {
                        // キャンペーン対象区分："全得意先"
                        CustomerInfo customerInfo;
                        CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

                        status = customerInfoAcs.ReadDBData(enterpriseCode, customerCode, out customerInfo);
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 該当する得意先が無いので処理終了
                            campaignMng = null;
                            readCampaignMng = null;

                            _statusOfResult = "得意先マスタに該当する得意先がない（得意先=）" + customerCode.ToString();

                            return status;
                        }

                        if (!sectionCode.Trim().Equals("00"))   // ADD 2009/08/25 チケット[14065]対応 全社設定ではチェックしない
                        {
                            if (customerInfo.MngSectionCode.TrimEnd() != sectionCode.TrimEnd())
                            {
                                // 該当する得意先の管理拠点が一致しないので処理終了
                                campaignMng = null;
                                readCampaignMng = null;

                                _statusOfResult = string.Format(
                                    "該当する得意先の管理拠点が一致しない（得意先={0}??{1}, 拠点={2}??{3}）",
                                    customerInfo.CustomerCode,
                                    customerCode,
                                    customerInfo.MngSectionCode,
                                    sectionCode
                                );

                                return status;
                            }
                        }
                    }
                    else if (campaignSt.CampaignObjDiv == 1)
                    {
                        // キャンペーン対象区分："対象得意先"
                        ArrayList retList;
                        CampaignLinkAcs campaignLinkAcs = new CampaignLinkAcs();

                        status = campaignLinkAcs.SearchDetail(out retList, enterpriseCode, campaignSt.CampaignCode);

                        // ADD 2009/08/25 チケット[14065]対応 ------>>>
                        // 調査用に保持
                        _usedCampaignLinkList = retList;
                        // ADD 2009/08/25 チケット[14065]対応 ------<<<

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // 該当するキャンペーン関連マスタが無いので処理終了
                            campaignMng = null;
                            readCampaignMng = null;

                            _statusOfResult = "該当するキャンペーン関連マスタが無い";

                            return status;
                        }
                        else if ((retList == null) || (retList.Count == 0))
                        {
                            // 検索結果が0件の場合も処理終了
                            campaignMng = null;
                            readCampaignMng = null;

                            _statusOfResult = "キャンペーン関連マスタの検索結果が0件";

                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }

                        bool searchFlg = false;
                        foreach (CampaignLink wkCampaignLink in retList)
                        {
                            if (wkCampaignLink.CustomerCode == customerCode)
                            {
                                // キャンペーン関連の得意先と一致
                                searchFlg = true;
                                break;
                            }
                        }

                        if (!searchFlg)
                        {
                            // キャンペーン関連に該当得意先が無いので処理終了
                            campaignMng = null;
                            readCampaignMng = null;

                            _statusOfResult = "キャンペーン関連に該当得意先が無い";

                            return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                        }
                    }
                    else if (campaignSt.CampaignObjDiv == 2)
                    {
                        // キャンペーン対象区分："中止"
                        campaignMng = null;
                        readCampaignMng = null;

                        _statusOfResult = "キャンペーン対象区分：「中止」";

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else
                {
                    // 該当するキャンペーンコードが無いので処理終了
                    campaignMng = null;
                    readCampaignMng = null;

                    _statusOfResult = "該当するキャンペーンコードが無い";

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                if (readCampaignMng != null) break;
            }   // foreach (KeyValuePair<string, CampaignMng> foundCampaignMng in foundCampaignMngList)

            // キャンペーン対象
            if (readCampaignMng != null)
            {
                campaignMng = readCampaignMng.Clone();
            }
            else
            {
                campaignMng = null;
            }
            _statusOfResult = _statusOfResult.Equals("全社設定で再検索") ? "全社設定で再検索" : "キャンペーン管理情報を特定できました。";
            _statusOfResult += ":" + keyInfo;

            return status;
        }
        // ADD 2009/08/31 チケット[14194]対応 ------>>>

        /// <summary>
        /// キャンペーン売価率、売価額取得処理
        /// </summary>
        /// <param name="campaignMng">抽出結果キャンペーン管理データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsMGroup">商品中分類</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="goodsNo">品番</param>
        /// <param name="applyDate">適用日</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : キャンペーン売価率、売価額取得の取得を行います。
        ///                  抽出条件からキャンペーン売価率、売価額取得処理が設定されているキャンペーン管理データを返します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/28</br>
        /// </remarks>
        public int GetRatePriceOfCampaignMng(out CampaignMng campaignMng, string enterpriseCode, string sectionCode, int customerCode, 
                                             int goodsMakerCd, int goodsMGroup, int blGoodsCode, string goodsNo, DateTime applyDate)
        {
        #if _USING_VERSION_2_

            // ADD 2009/08/31 チケット[14194]対応 ------>>>
            return GetRatePriceOfCampaignMng2(
                out campaignMng,
                enterpriseCode,
                sectionCode,
                customerCode,
                goodsMakerCd,
                goodsMGroup,
                blGoodsCode,
                goodsNo,
                applyDate
            );
            // ADD 2009/08/31 チケット[14194]対応 ------>>>

        #else

            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ADD 2009/08/25 チケット[14065]対応 ------>>>
            // キーを設定する際、スペースは削っているので、パラメータもスペースを削る
            sectionCode = sectionCode.Trim();
            goodsNo     = goodsNo.Trim();
            // ADD 2009/08/25 チケット[14065]対応 ------<<<

            if (_campaignMngDic == null)
            {
                // キャンペーン管理キャッシュにデータが無いので取得
                CampaignMngOrder campaignMngOrder = new CampaignMngOrder();
                campaignMngOrder.EnterpriseCode = enterpriseCode;
                campaignMngOrder.SectionCode = null;

                List<CampaignMng> retList;
                string message;

                // キャンペーン管理マスタの全検索
                status = Search(campaignMngOrder, out retList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 全検索で失敗
                    campaignMng = null;

                    _statusOfResult = "キャンペーン管理マスタの全検索で失敗";

                    return status;
                }

                //キャンペーン管理データのキャッシュ化
                _campaignMngDic = new Dictionary<DICKEY, CampaignMng>();

                foreach (CampaignMng wkCampaignMng in retList)
                {
                    if (wkCampaignMng.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    // 追加キー作成
                    DICKEY addKey = new DICKEY();
                    addKey.sectionCode = wkCampaignMng.SectionCode.TrimEnd();
                    addKey.goodsMGroup = wkCampaignMng.GoodsMGroup;
                    addKey.blGoodsCode = wkCampaignMng.BLGoodsCode;
                    addKey.goodsMakerCd = wkCampaignMng.GoodsMakerCd;
                    addKey.goodsNo = wkCampaignMng.GoodsNo.Trim();

                    if (!_campaignMngDic.ContainsKey(addKey))
                    {
                        _campaignMngDic.Add(addKey, wkCampaignMng);
                    }
                }
            }

            // キャンペーン管理キャッシュからデータ取得
            CampaignMng readCampaignMng = new CampaignMng();
            // キー作成
            DICKEY key = new DICKEY();
            key.sectionCode = sectionCode.TrimEnd();
            key.goodsMakerCd = goodsMakerCd;
            key.goodsNo = goodsNo.Trim();
            if (_campaignMngDic.ContainsKey(key))
            {
                // ①メーカー＋品番
                readCampaignMng = _campaignMngDic[key].Clone();
            }
            else
            {
                // キー変更
                key.goodsNo = string.Empty;
                key.blGoodsCode = blGoodsCode;
                if (_campaignMngDic.ContainsKey(key))
                {
                    // ②メーカー＋BLコード
                    readCampaignMng = _campaignMngDic[key].Clone();
                }
                else
                {
                    // キー変更
                    key.blGoodsCode = 0;
                    key.goodsMGroup = goodsMGroup;
                    if (_campaignMngDic.ContainsKey(key))
                    {
                        // ③メーカー＋商品中分類
                        readCampaignMng = _campaignMngDic[key].Clone();
                    }
                    else
                    {
                        // キー変更
                        key.goodsMGroup = 0;
                        if (_campaignMngDic.ContainsKey(key))
                        {
                            // ④メーカー
                            readCampaignMng = _campaignMngDic[key].Clone();
                        }
                        else
                        {
                            // 該当データ無し
                            campaignMng = null;

                            // ADD 2009/08/25 チケット[14065]対応 ------>>>
                            _statusOfResult = "キャンペーン管理マスタに該当データ無し";

                            // 全社で再検索
                            int sectionCodeNo = int.Parse(sectionCode.Trim());
                            if (sectionCodeNo > 0)
                            {
                                _statusOfResult = "全社設定で再検索";

                                return GetRatePriceOfCampaignMng(
                                    out campaignMng,
                                    enterpriseCode,
                                    "00",
                                    customerCode,
                                    goodsMakerCd,
                                    goodsMGroup,
                                    blGoodsCode,
                                    goodsNo,
                                    applyDate
                                );
                            }
                            // ADD 2009/08/25 チケット[14065]対応 ------<<<

                            return status;
                        }
                    }
                }
            }

            // キャンペーン設定マスタの読込(ディクショナリーが未設定の場合もあるので)
            string name = GetCampaignName(readCampaignMng.CampaignCode);

            // キャンペーン設定マスタと一致するか
            if (this._campaignStDic.ContainsKey(readCampaignMng.CampaignCode))
            {
                CampaignSt campaignSt = this._campaignStDic[readCampaignMng.CampaignCode];
                if (campaignSt.SectionCode.TrimEnd() != sectionCode.TrimEnd())
                {
                    // 拠点が不一致の場合は処理終了
                    campaignMng = null;

                    _statusOfResult = "キャンペーン管理マスタとキャンペーン設定マスタの拠点が不一致";

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                // 適用日が範囲内か
                if ((campaignSt.ApplyStaDate > applyDate) ||
                    (campaignSt.ApplyEndDate < applyDate))
                {
                    // 適用開始日前、または適用終了日後の場合は処理終了
                    campaignMng = null;

                    _statusOfResult = "適用日が範囲外";

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                if (campaignSt.CampaignObjDiv == 0)
                {
                    // キャンペーン対象区分："全得意先"
                    CustomerInfo customerInfo;
                    CustomerInfoAcs customerInfoAcs = new CustomerInfoAcs();

                    status = customerInfoAcs.ReadDBData(enterpriseCode, customerCode, out customerInfo);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 該当する得意先が無いので処理終了
                        campaignMng = null;

                        _statusOfResult = "得意先マスタに該当する得意先がない（得意先=）" + customerCode.ToString();

                        return status;
                    }

                    if (!sectionCode.Trim().Equals("00"))   // ADD 2009/08/25 チケット[14065]対応 全社設定ではチェックしない
                    {
                        if (customerInfo.MngSectionCode.TrimEnd() != sectionCode.TrimEnd())
                        {
                            // 該当する得意先の管理拠点が一致しないので処理終了
                            campaignMng = null;

                            _statusOfResult = string.Format(
                                "該当する得意先の管理拠点が一致しない（得意先={0}??{1}, 拠点={2}??{3}）",
                                customerInfo.CustomerCode,
                                customerCode,
                                customerInfo.MngSectionCode,
                                sectionCode
                            );

                            return status;
                        }
                    }
                }
                else if (campaignSt.CampaignObjDiv == 1)
                {
                    // キャンペーン対象区分："対象得意先"
                    ArrayList retList;
                    CampaignLinkAcs campaignLinkAcs = new CampaignLinkAcs();

                    status = campaignLinkAcs.SearchDetail(out retList, enterpriseCode, campaignSt.CampaignCode);

                    // ADD 2009/08/25 チケット[14065]対応 ------>>>
                    // 調査用に保持
                    _usedCampaignLinkList = retList;
                    // ADD 2009/08/25 チケット[14065]対応 ------<<<

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // 該当するキャンペーン関連マスタが無いので処理終了
                        campaignMng = null;

                        _statusOfResult = "該当するキャンペーン関連マスタが無い";

                        return status;
                    }
                    else if ((retList == null) || (retList.Count == 0))
                    {
                        // 検索結果が0件の場合も処理終了
                        campaignMng = null;

                        _statusOfResult = "キャンペーン関連マスタの検索結果が0件";

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }

                    bool searchFlg = false;
                    foreach (CampaignLink wkCampaignLink in retList)
                    {
                        if (wkCampaignLink.CustomerCode == customerCode)
                        {
                            // キャンペーン関連の得意先と一致
                            searchFlg = true;
                            break;
                        }
                    }

                    if (!searchFlg)
                    {
                        // キャンペーン関連に該当得意先が無いので処理終了
                        campaignMng = null;

                        _statusOfResult = "キャンペーン関連に該当得意先が無い";

                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                else if (campaignSt.CampaignObjDiv == 2)
                {
                    // キャンペーン対象区分："中止"
                    campaignMng = null;
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            else
            {
                // 該当するキャンペーンコードが無いので処理終了
                campaignMng = null;

                _statusOfResult = "該当するキャンペーンコードが無い";

                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // キャンペーン対象
            campaignMng = readCampaignMng.Clone();

            _statusOfResult = _statusOfResult.Equals("全社設定で再検索") ? "全社設定で再検索" : "キャンペーン管理情報を特定できました。";

            return status;

        #endif
        }
        #endregion
    }
}
