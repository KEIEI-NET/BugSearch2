//****************************************************************************//
// システム         : .NSシリーズ
// プログラム名称   : 重点品目設定マスタ
// プログラム概要   : 重点品目設定の登録・変更・削除を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/05/22  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30413 犬飼
// 作 成 日  2009/06/17  修正内容 : 重点品目設定マスタの取得メソッド追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 30434 工藤
// 作 成 日  2009/08/25  修正内容 : チケット[14065]対応
//----------------------------------------------------------------------------//

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
    /// 重点品目設定マスタアクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 重点品目設定マスタのアクセス制御を行います。</br>
    /// <br>Programmer : 30413 犬飼</br>
    /// <br>Date       : 2009/05/22</br>
    /// <br></br>
    /// <br>UpdateNote : </br>
    /// </remarks>
    public class ImportantPrtStAcs
    {
        #region public const
        //----------------------------------------
        // 重点品目設定マスタ定数定義
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
        /// <summary>得意先コード</summary>
        public const string ct_COL_CUSTOMERCODE = "CustomerCode";
        /// <summary>商品中分類コード</summary>
        public const string ct_COL_GOODSMGROUP = "GoodsMGroup";
        /// <summary>BL商品コード</summary>
        public const string ct_COL_BLGOODSCODE = "BLGoodsCode";
        /// <summary>商品メーカーコード</summary>
        public const string ct_COL_GOODSMAKERCD = "GoodsMakerCd";
        /// <summary>商品番号</summary>
        public const string ct_COL_GOODSNO = "GoodsNo";
        /// <summary>有効区分</summary>
        public const string ct_COL_VALIDDIVCD = "ValidDivCd";

        /// <summary>有効区分(前回退避)</summary>
        public const string ct_COL_ValidDivCd_BACKUP = "ValidDivCd_Backup";

        /// <summary>拠点名称</summary>
        public const string ct_COL_SECTIONNM = "SectionNm";
        /// <summary>得意先名称</summary>
        public const string ct_COL_CUSTOMERNAME = "CustomerName";
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
        /// <summary>仕入先コード</summary>
        public const string ct_COL_SUPPLIERCD = "SupplierCd";
        /// <summary>仕入先略称</summary>
        public const string ct_COL_SUPPLIERSNM = "SupplierSnm";

        /// <summary>BLグループコード</summary>
        public const string ct_COL_BLGROUPCODE = "BLGroupCode";

        # region [ソート用]
        /// <summary>拠点コード</summary>
        public const string ct_COL_SECTIONCODE_SORT = "SectionCode_Sort";
        /// <summary>得意先コード</summary>
        public const string ct_COL_CUSTOMERCODE_SORT = "CustomerCode_Sort";
        /// <summary>仕入先コード</summary>
        public const string ct_COL_SUPPLIERCD_SORT = "SupplierCd_Sort";
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
        /// <summary>重点品目設定マスタworkオブジェクト(内部保持用)</summary>
        public const string ct_COL_IMPORTANTPRTSTWORKOBJECT = "ImportantPrtStWorkObject";


        // テーブル名
        /// <summary>重点品目設定テーブル</summary>
        public const string ct_TABLE_IMPORTANTPRTST = "ImportantPrtStTable";

        #endregion

        #region Private Members
        // ===================================================================================== //
        // プライベートメンバー
        // ===================================================================================== //
        // リモートオブジェクト格納バッファ
        private IImportantPrtStDB _iImportantPrtStDB = null;    // 重点品目設定リモート

        private DataSet _dataTableList = null;
        private DataView _dataView = null;
        private bool _excludeLogicalDeleteFromView;

        private GoodsAcs _goodsAcs;

        // ADD 2009/06/17 ------>>>
        // 重点品目設定データディクショナリー　キー項目
        public struct DICKEY
        {
            /// <summary> 拠点コード </summary>
            public string sectionCode;
            /// <summary> 得意先コード </summary>
            public int customerCode;
            /// <summary> 商品中分類 </summary>
            public int goodsMGroup;
            /// <summary> BLコード </summary>
            public int blGoodsCode;
            /// <summary> メーカーコード </summary>
            public int goodsMakerCd;
            /// <summary> 品番 </summary>
            public string goodsNo;
        }

        // 重点品目設定データディクショナリー
        private Dictionary<DICKEY, ImportantPrtSt> _ImportantPrtStDic = null;
        /// <summary>
        /// 重点品目設定データディクショナリー（全検索時のキャッシュ）
        /// </summary>
        public Dictionary<DICKEY, ImportantPrtSt> CachedImportantPrtStDic
        {
            get { return _ImportantPrtStDic; }
        }
        // ADD 2009/06/17 ------<<<

        /// <summary>企業コード</summary>
        private string _enterpriseCode = string.Empty;

        /// <summary>拠点コード</summary>
        private string _sectionCode = string.Empty;

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
        /// 重点品目設定マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 重点品目設定マスタアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public ImportantPrtStAcs()
        {
            try
            {
                // リモートオブジェクト取得
                this._iImportantPrtStDB = (IImportantPrtStDB)MediationImportantPrtStDB.GetImportantPrtStDB();
            }
            catch (Exception)
            {
                //オフライン時はnullをセット
                this._iImportantPrtStDB = null;
            }

            // 論理削除除外する
            _excludeLogicalDeleteFromView = true;
        }

        /// <summary>
        /// 重点品目設定マスタアクセスクラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 重点品目設定マスタアクセスクラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 30434 工藤</br>
        /// <br>Date       : 2009/07/14</br>
        /// </remarks>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        public ImportantPrtStAcs(string enterpriseCode, string sectionCode) : this()
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
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iImportantPrtStDB == null)
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
        /// 企業コードを取得または設定します。
        /// </summary>
        public string EnterpriseCode
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
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// 拠点コードを取得および設定します。
        /// </summary>
        public string SectionCode
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
            set { _sectionCode = value; }
        }

        /// <summary>
        /// 商品検索を取得します。
        /// </summary>
        private GoodsAcs GoodsAccesser
        {
            get
            {
                if (_goodsAcs == null)
                {
                    _goodsAcs = new GoodsAcs();
                    string msg = string.Empty;
                    _goodsAcs.SearchInitial(EnterpriseCode, SectionCode, out msg);
                }
                return _goodsAcs;
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
                _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Clear();
            }
        }

        /// <summary>
        /// 重点品目設定マスタ複数検索処理（論理削除含まない）重点品目設定マスメン以外用
        /// </summary>
        /// <param name="retList">読込結果コレクション</param>
        /// <param name="importantPrtStList">重点品目設定オブジェクトリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 重点品目設定マスタリストの条件に一致したデータを検索します。論理削除データは抽出対象外</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int Search( ImportantPrtStOrder paraData, out List<ImportantPrtSt> retList, out string message )
        {
            if ( _goodsAcs == null )
            {
                string msg;
                _goodsAcs = new GoodsAcs(SectionCode);
                _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
            }

            // 検索
            ArrayList retWorkList;
            int status = this.SearchProc( paraData, out retWorkList, ConstantManagement.LogicalMode.GetData0, out message );

            // 結果格納
            retList = new List<ImportantPrtSt>();
            if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL && retWorkList != null )
            {
                foreach ( object obj in retWorkList )
                {
                    if ( obj is ImportantPrtStWork )
                    {
                        ImportantPrtStWork retWork = (obj as ImportantPrtStWork);

                        // 商品管理情報より仕入先を取得
                        GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );

                        // 仕入先範囲判定
                        if ( goodsUnitData.SupplierCd < paraData.St_SupplierCd ||
                             (goodsUnitData.SupplierCd > paraData.Ed_SupplierCd && paraData.Ed_SupplierCd != 0) )
                        {
                            continue;
                        }

                        // 値をセット
                        ImportantPrtSt importantPrtSt = CopyToImportantPrtStFromImportantPrtStWork( retWork );
                        if ( goodsUnitData != null )
                        {
                            importantPrtSt.SupplierCd = goodsUnitData.SupplierCd;
                            importantPrtSt.SupplierSnm = goodsUnitData.SupplierSnm;
                        }
                        retList.Add( importantPrtSt );
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
            _goodsAcs = null;
            _ImportantPrtStDic = null;  // ADD 2009/06/17
            this.Clear();
        }

        /// <summary>
        /// 重点品目設定マスタ複数検索処理（論理削除含まない）重点品目設定マスメン用
        /// </summary>
        /// <param name="paraData"></param>
        /// <param name="retList"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public int Search( ImportantPrtStOrder paraData, out string message )
        {
            if ( _goodsAcs == null )
            {
                string msg;
                _goodsAcs = new GoodsAcs(SectionCode);
                _goodsAcs.SearchInitial( paraData.EnterpriseCode, SectionCode.Trim(), out msg );
            }

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
                    if ( obj is ImportantPrtStWork )
                    {
                        ImportantPrtStWork retWork = (obj as ImportantPrtStWork);

                        // アクセスクラス内のDataTableに追加
                        DataRow row = this._dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].NewRow();

                        // 商品管理情報より仕入先を取得
                        GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );

                        // 仕入先範囲判定
                        if ( goodsUnitData.SupplierCd < paraData.St_SupplierCd ||
                             (goodsUnitData.SupplierCd > paraData.Ed_SupplierCd && paraData.Ed_SupplierCd != 0) )
                        {
                            continue;
                        }

                        // 値をセット
                        CopyToDataRowFromImportantPrtStWork( ref row, retWork, goodsUnitData );
                        _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Rows.Add( row );
                    }
                }
            }
            if ( _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Rows.Count == 0 )
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
        /// <remarks>重点品目設定マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public ImportantPrtSt GetRecordForMaintenance( Guid guid )
        {
            ImportantPrtStWork importantPrtStWork = null;

            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_IMPORTANTPRTST] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    importantPrtStWork = CopyToImportantPrtStWorkFromDataRow( view[0].Row );
                }
            }

            // 該当無しなら空データ
            if ( importantPrtStWork == null )
            {
                importantPrtStWork = new ImportantPrtStWork();
            }

            return this.CopyToImportantPrtStFromImportantPrtStWork( importantPrtStWork );
        }
        /// <summary>
        /// マスメン向けレコード取得処理
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        /// <remarks>重点品目設定マスメンで使用する場合（DataTableに結果格納済みの場合）のみ対応します</remarks>
        public DataRow GetRowForMaintenance( Guid guid )
        {
            DataRow row = null;
            if ( _dataTableList != null )
            {
                DataView view = new DataView( this._dataTableList.Tables[ct_TABLE_IMPORTANTPRTST] );
                view.RowFilter = string.Format( "{0}='{1}'", ct_COL_FILEHEADERGUID, guid );

                if ( view.Count > 0 )
                {
                    row = view[0].Row;
                }
            }

            // 該当無しならNULL
            return row;
        }
        /// <summary>
        /// 商品管理情報取得処理
        /// </summary>
        /// <param name="scmPrtSettngWork"></param>
        /// <returns></returns>
        private GoodsUnitData GetGoodsMngInfo( ImportantPrtStWork scmPrtSettngWork )
        {
            GoodsUnitData goodsUnitData;

            if ( scmPrtSettngWork.GoodsNo == string.Empty )
            {
                goodsUnitData = new GoodsUnitData();

                goodsUnitData.EnterpriseCode = scmPrtSettngWork.EnterpriseCode.Trim();
                goodsUnitData.SectionCode = scmPrtSettngWork.SectionCode.Trim();
                goodsUnitData.GoodsMakerCd = scmPrtSettngWork.GoodsMakerCd;
                goodsUnitData.GoodsMGroup = scmPrtSettngWork.GoodsMGroup;
                goodsUnitData.BLGoodsCode = scmPrtSettngWork.BLGoodsCode;
                goodsUnitData.GoodsNo = scmPrtSettngWork.GoodsNo.Trim();

                GoodsAccesser.GetGoodsMngInfo( ref goodsUnitData );
            }
            else
            {
                GoodsAccesser.Read(scmPrtSettngWork.EnterpriseCode.Trim(), scmPrtSettngWork.GoodsMakerCd, scmPrtSettngWork.GoodsNo.Trim(), out goodsUnitData);
            }

            return goodsUnitData;
        }
        #endregion

        #region Write 書き込み処理
        /// <summary>
        /// 書き込み処理
        /// </summary>
        /// <param name="importantPrtStList">保存データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 書き込み処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int Write(ref ArrayList importantPrtStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // データ数分ループ
                ArrayList paraImportantPrtStList = new ArrayList();
                ImportantPrtStWork importantPrtStWork = null;

                for ( int i = 0; i < importantPrtStList.Count; i++ )
                {
                    // クラスデータをワーククラスデータに変換
                    importantPrtStWork = CopyToImportantPrtStWorkFromImportantPrtSt( (ImportantPrtSt)importantPrtStList[i] );
                    paraImportantPrtStList.Add( importantPrtStWork );
                }

                object paraObj = (object)paraImportantPrtStList;

                // 書き込み処理
                status = this._iImportantPrtStDB.Write( ref paraObj );

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
                this._iImportantPrtStDB = null;
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
                DataView view = new DataView( _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST] );
                view.RowFilter = string.Format( "{0}<>{1}", ct_COL_VALIDDIVCD, ct_COL_ValidDivCd_BACKUP );

                return view.Count;
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
                ArrayList paraImportantPrtStList = new ArrayList();
                foreach ( DataRow row in _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Rows )
                {
                    // 変更有無チェック
                    if ( (int)row[ct_COL_VALIDDIVCD] == (int)row[ct_COL_ValidDivCd_BACKUP] )
                    {
                        // 変更可能な項目がSearch時と変わらないので対象外にする
                        continue;
                    }

                    ImportantPrtStWork importantPrtStWork = CopyToImportantPrtStWorkFromDataRow( row );
                    paraImportantPrtStList.Add( importantPrtStWork );
                }
                // 変更有無チェック
                if ( paraImportantPrtStList.Count == 0 )
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    message = "更新対象のデータが存在しません";
                    return status;
                }

                object paraObj = (object)paraImportantPrtStList;


                // 書き込み処理
                status = this._iImportantPrtStDB.Write( ref paraObj );

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
                this._iImportantPrtStDB = null;
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
                    if ( obj is ImportantPrtStWork )
                    {
                        ImportantPrtStWork retWork = (ImportantPrtStWork)obj;

                        DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );
                        GoodsUnitData goodsUnitData = GetGoodsMngInfo( retWork );

                        if ( row == null )
                        {
                            // 追加
                            row = _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].NewRow();
                            CopyToDataRowFromImportantPrtStWork( ref row, retWork, goodsUnitData );
                            _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Rows.Add( row );
                        }
                        else
                        {
                            // 更新
                            CopyToDataRowFromImportantPrtStWork( ref row, retWork, goodsUnitData );
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 内部データテーブル書き換え処理(物理削除後)
        /// </summary>
        /// <param name="retObj"></param>
        private void DeleteFromDataTable( ArrayList importantPrtStWorkList )
        {
            foreach ( object obj in importantPrtStWorkList )
            {
                if ( obj is ImportantPrtStWork )
                {
                    ImportantPrtStWork retWork = (ImportantPrtStWork)obj;

                    DataRow row = this.GetRowForMaintenance( retWork.FileHeaderGuid );

                    if ( row != null )
                    {
                        // 削除
                        _dataTableList.Tables[ct_TABLE_IMPORTANTPRTST].Rows.Remove( row );
                    }
                }
            }
        }
        #endregion

        #region LogicalDelete 論理削除処理
        /// <summary>
        /// 論理削除処理
        /// </summary>
        /// <param name="importantPrtStList">論理削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 論理削除処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList importantPrtStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // データ数分ループ
                ArrayList paraImportantPrtStList = new ArrayList();
                ImportantPrtStWork importantPrtStWork = null;

                for (int i = 0; i < importantPrtStList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    importantPrtStWork = CopyToImportantPrtStWorkFromImportantPrtSt((ImportantPrtSt)importantPrtStList[i]);

                    paraImportantPrtStList.Add(importantPrtStWork);
                }
                object paraObj = (object)paraImportantPrtStList;

                // 論理削除処理
                status = this._iImportantPrtStDB.LogicalDelete( ref paraObj );

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
                this._iImportantPrtStDB = null;
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
        /// <param name="importantPrtStList">論理削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 復旧処理（論理削除復旧）を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int Revival(ref ArrayList importantPrtStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // データ数分ループ
                ArrayList paraImportantPrtStList = new ArrayList();
                ImportantPrtStWork importantPrtStWork = null;

                for (int i = 0; i < importantPrtStList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    importantPrtStWork = CopyToImportantPrtStWorkFromImportantPrtSt((ImportantPrtSt)importantPrtStList[i]);

                    paraImportantPrtStList.Add(importantPrtStWork);
                }

                object paraObj = (object)paraImportantPrtStList;

                // 書き込み処理
                status = this._iImportantPrtStDB.RevivalLogicalDelete(ref paraObj);

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
                this._iImportantPrtStDB = null;
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
        /// <param name="importantPrtStList">削除データリスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 削除処理（物理削除）を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int Delete(ref ArrayList importantPrtStList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                byte[] paraImportantPrtStWork = null;
                ImportantPrtStWork importantPrtStWork = null;
                ArrayList importantPrtStWorkList = new ArrayList(); // ワーククラス格納用ArrayList

                // ワーククラス格納用ArrayListへ詰め替え
                for (int i = 0; i < importantPrtStList.Count; i++)
                {
                    // クラスデータをワーククラスデータに変換
                    importantPrtStWork = CopyToImportantPrtStWorkFromImportantPrtSt((ImportantPrtSt)importantPrtStList[i]);
                    importantPrtStWorkList.Add(importantPrtStWork);
                }
                // ArrayListから配列を生成
                ImportantPrtStWork[] importantPrtStWorks = (ImportantPrtStWork[])importantPrtStWorkList.ToArray(typeof(ImportantPrtStWork));

                // シリアライズ
                paraImportantPrtStWork = XmlByteSerializer.Serialize(importantPrtStWorks);

                // 物理削除処理
                status = this._iImportantPrtStDB.Delete(paraImportantPrtStWork);

                if ( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL )
                {
                    if ( _dataTableList != null )
                    {
                        // テーブルから削除
                        DeleteFromDataTable( importantPrtStWorkList );
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
                this._iImportantPrtStDB = null;
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
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private void DataSetColumnConstruction()
        {
            //----------------------------------------------------------------
            // 重点品目設定テーブル列定義
            //----------------------------------------------------------------
            DataTable importantPrtStTable = new DataTable( ct_TABLE_IMPORTANTPRTST );


            // 作成日時
            importantPrtStTable.Columns.Add( ct_COL_CREATEDATETIME, typeof( DateTime ) );
            // 更新日時
            importantPrtStTable.Columns.Add( ct_COL_UPDATEDATETIME, typeof( DateTime ) );
            // 企業コード
            importantPrtStTable.Columns.Add( ct_COL_ENTERPRISECODE, typeof( string ) );
            // GUID
            importantPrtStTable.Columns.Add( ct_COL_FILEHEADERGUID, typeof( Guid ) );
            // 更新従業員コード
            importantPrtStTable.Columns.Add( ct_COL_UPDEMPLOYEECODE, typeof( string ) );
            // 更新アセンブリID1
            importantPrtStTable.Columns.Add( ct_COL_UPDASSEMBLYID1, typeof( string ) );
            // 更新アセンブリID2
            importantPrtStTable.Columns.Add( ct_COL_UPDASSEMBLYID2, typeof( string ) );
            // 論理削除区分
            importantPrtStTable.Columns.Add( ct_COL_LOGICALDELETECODE, typeof( Int32 ) );
            // 拠点コード
            importantPrtStTable.Columns.Add( ct_COL_SECTIONCODE, typeof( string ) );
            // 得意先コード
            importantPrtStTable.Columns.Add( ct_COL_CUSTOMERCODE, typeof( Int32 ) );
            // 商品中分類コード
            importantPrtStTable.Columns.Add( ct_COL_GOODSMGROUP, typeof( Int32 ) );
            // BL商品コード
            importantPrtStTable.Columns.Add( ct_COL_BLGOODSCODE, typeof( Int32 ) );
            // 商品メーカーコード
            importantPrtStTable.Columns.Add( ct_COL_GOODSMAKERCD, typeof( Int32 ) );
            // 商品番号
            importantPrtStTable.Columns.Add( ct_COL_GOODSNO, typeof( string ) );
            // 有効区分
            importantPrtStTable.Columns.Add( ct_COL_VALIDDIVCD, typeof( Int32 ) );

            // 有効区分
            importantPrtStTable.Columns.Add( ct_COL_ValidDivCd_BACKUP, typeof( Int32 ) );

            // 拠点名称
            importantPrtStTable.Columns.Add( ct_COL_SECTIONNM, typeof( string ) );
            // 得意先名称
            importantPrtStTable.Columns.Add( ct_COL_CUSTOMERNAME, typeof( string ) );
            // 商品中分類名称
            importantPrtStTable.Columns.Add( ct_COL_GOODSMGROUPNAME, typeof( string ) );
            // BLグループ名称
            importantPrtStTable.Columns.Add( ct_COL_BLGROUPNAME, typeof( string ) );
            // BL商品コード名称
            importantPrtStTable.Columns.Add( ct_COL_BLGOODSNAME, typeof( string ) );
            // メーカー名称
            importantPrtStTable.Columns.Add( ct_COL_MAKERNAME, typeof( string ) );
            // 商品名称
            importantPrtStTable.Columns.Add( ct_COL_GOODSNAME, typeof( string ) );
            // 仕入先コード
            importantPrtStTable.Columns.Add( ct_COL_SUPPLIERCD, typeof( Int32 ) );
            // 仕入先略称
            importantPrtStTable.Columns.Add( ct_COL_SUPPLIERSNM, typeof( string ) );

            // グループコード
            importantPrtStTable.Columns.Add( ct_COL_BLGROUPCODE, typeof( Int32 ) );

            # region [ソート用]
            // 拠点コード
            importantPrtStTable.Columns.Add( ct_COL_SECTIONCODE_SORT, typeof( string ) );
            // 得意先コード
            importantPrtStTable.Columns.Add( ct_COL_CUSTOMERCODE_SORT, typeof( Int32 ) );
            // 商品中分類コード
            importantPrtStTable.Columns.Add( ct_COL_GOODSMGROUP_SORT, typeof( Int32 ) );
            // BL商品コード
            importantPrtStTable.Columns.Add( ct_COL_BLGOODSCODE_SORT, typeof( Int32 ) );
            // 商品メーカーコード
            importantPrtStTable.Columns.Add( ct_COL_GOODSMAKERCD_SORT, typeof( Int32 ) );
            // 仕入先コード
            importantPrtStTable.Columns.Add( ct_COL_SUPPLIERCD_SORT, typeof( Int32 ) );
            // グループコード
            importantPrtStTable.Columns.Add( ct_COL_BLGROUPCODE_SORT, typeof( Int32 ) );
            # endregion


            // 論理削除日(表示用)
            importantPrtStTable.Columns.Add( ct_COL_LOGICALDELETEDATE, typeof( string ) );
            // オブジェクト(内部保持用)
            importantPrtStTable.Columns.Add( ct_COL_IMPORTANTPRTSTWORKOBJECT, typeof( ImportantPrtStWork ) );

            this._dataTableList.Tables.Add(importantPrtStTable);

            //----------------------------------------------------------------
            // データビュー生成
            //----------------------------------------------------------------
            this._dataView = new DataView( importantPrtStTable );
            this._dataView.Sort = string.Format( "{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}",
                                                ct_COL_SECTIONCODE_SORT,
                                                ct_COL_CUSTOMERCODE_SORT,
                                                ct_COL_SUPPLIERCD_SORT,
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
        /// クラスメンバーコピー処理（重点品目設定クラス⇒重点品目設定ワーククラス）
        /// </summary>
        /// <param name="importantPrtSt">重点品目設定クラス</param>
        /// <returns>ImportantPrtStWork</returns>
        /// <remarks>
        /// <br>Note       : 重点品目設定クラスから重点品目設定ワーククラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private ImportantPrtStWork CopyToImportantPrtStWorkFromImportantPrtSt(ImportantPrtSt importantPrtSt)
        {
            ImportantPrtStWork importantPrtStWork = new ImportantPrtStWork();

            importantPrtStWork.CreateDateTime = importantPrtSt.CreateDateTime;          // 作成日時
            importantPrtStWork.UpdateDateTime = importantPrtSt.UpdateDateTime;          // 更新日時
            importantPrtStWork.EnterpriseCode = importantPrtSt.EnterpriseCode;          // 企業コード
            importantPrtStWork.FileHeaderGuid = importantPrtSt.FileHeaderGuid;          // GUID
            importantPrtStWork.UpdEmployeeCode = importantPrtSt.UpdEmployeeCode;        // 更新従業員コード
            importantPrtStWork.UpdAssemblyId1 = importantPrtSt.UpdAssemblyId1;          // 更新アセンブリID1
            importantPrtStWork.UpdAssemblyId2 = importantPrtSt.UpdAssemblyId2;          // 更新アセンブリID2
            importantPrtStWork.LogicalDeleteCode = importantPrtSt.LogicalDeleteCode;    // 論理削除区分
            importantPrtStWork.SectionCode = importantPrtSt.SectionCode;                // 拠点コード
            importantPrtStWork.CustomerCode = importantPrtSt.CustomerCode;              // 得意先コード
            importantPrtStWork.GoodsMGroup = importantPrtSt.GoodsMGroup;                // 商品中分類コード
            importantPrtStWork.BLGroupCode = importantPrtSt.BLGroupCode;                // BLグループコード
            importantPrtStWork.BLGoodsCode = importantPrtSt.BLGoodsCode;                // BL商品コード
            importantPrtStWork.GoodsMakerCd = importantPrtSt.GoodsMakerCd;              // 商品メーカーコード
            importantPrtStWork.GoodsNo = importantPrtSt.GoodsNo;                        // 商品番号
            importantPrtStWork.ValidDivCd = importantPrtSt.ValidDivCd;                  // 有効区分
            importantPrtStWork.SectionNm = importantPrtSt.SectionNm;                    // 拠点名称
            importantPrtStWork.CustomerName = importantPrtSt.CustomerName;              // 得意先名称
            importantPrtStWork.GoodsMGroupName = importantPrtSt.GoodsMGroupName;        // 商品中分類名称
            importantPrtStWork.BLGroupName = importantPrtSt.BLGroupName;                // BLグループ名称
            importantPrtStWork.BLGoodsName = importantPrtSt.BLGoodsName;                // BL商品コード名称
            importantPrtStWork.MakerName = importantPrtSt.MakerName;                    // メーカー名称
            importantPrtStWork.GoodsName = importantPrtSt.GoodsName;                    // 商品名称
            //importantPrtStWork.SupplierCd = importantPrtSt.SupplierCd; // 仕入先コード
            //importantPrtStWork.SupplierSnm = importantPrtSt.SupplierSnm; // 仕入先略称

            return importantPrtStWork;
        }

        /// <summary>
        /// クラスメンバーコピー処理（重点品目設定ワーククラス⇒重点品目設定クラス）
        /// </summary>
        /// <param name="importantPrtStWork">重点品目設定ワーククラス</param>
        /// <returns>ImportantPrtSt</returns>
        /// <remarks>
        /// <br>Note       : 重点品目設定ワーククラスから重点品目設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private ImportantPrtSt CopyToImportantPrtStFromImportantPrtStWork(ImportantPrtStWork importantPrtStWork)
        {
            ImportantPrtSt importantPrtSt = new ImportantPrtSt();

            importantPrtSt.CreateDateTime = importantPrtStWork.CreateDateTime;          // 作成日時
            importantPrtSt.UpdateDateTime = importantPrtStWork.UpdateDateTime;          // 更新日時
            importantPrtSt.EnterpriseCode = importantPrtStWork.EnterpriseCode;          // 企業コード
            importantPrtSt.FileHeaderGuid = importantPrtStWork.FileHeaderGuid;          // GUID
            importantPrtSt.UpdEmployeeCode = importantPrtStWork.UpdEmployeeCode;        // 更新従業員コード
            importantPrtSt.UpdAssemblyId1 = importantPrtStWork.UpdAssemblyId1;          // 更新アセンブリID1
            importantPrtSt.UpdAssemblyId2 = importantPrtStWork.UpdAssemblyId2;          // 更新アセンブリID2
            importantPrtSt.LogicalDeleteCode = importantPrtStWork.LogicalDeleteCode;    // 論理削除区分
            importantPrtSt.SectionCode = importantPrtStWork.SectionCode;                // 拠点コード
            importantPrtSt.CustomerCode = importantPrtStWork.CustomerCode;              // 得意先コード
            importantPrtSt.GoodsMGroup = importantPrtStWork.GoodsMGroup;                // 商品中分類コード
            importantPrtSt.BLGroupCode = importantPrtStWork.BLGroupCode;                // BLグループコード
            importantPrtSt.BLGoodsCode = importantPrtStWork.BLGoodsCode;                // BL商品コード
            importantPrtSt.GoodsMakerCd = importantPrtStWork.GoodsMakerCd;              // 商品メーカーコード
            importantPrtSt.GoodsNo = importantPrtStWork.GoodsNo;                        // 商品番号
            importantPrtSt.ValidDivCd = importantPrtStWork.ValidDivCd;                  // 有効区分
            importantPrtSt.SectionNm = importantPrtStWork.SectionNm;                    // 拠点名称
            importantPrtSt.CustomerName = importantPrtStWork.CustomerName;              // 得意先名称
            importantPrtSt.GoodsMGroupName = importantPrtStWork.GoodsMGroupName;        // 商品中分類名称
            importantPrtSt.BLGroupName = importantPrtStWork.BLGroupName;                // BLグループ名称
            importantPrtSt.BLGoodsName = importantPrtStWork.BLGoodsName;                // BL商品コード名称
            importantPrtSt.MakerName = importantPrtStWork.MakerName;                    // メーカー名称
            importantPrtSt.GoodsName = importantPrtStWork.GoodsName;                    // 商品名称
            //importantPrtSt.SupplierCd = importantPrtStWork.SupplierCd; // 仕入先コード
            //importantPrtSt.SupplierSnm = importantPrtStWork.SupplierSnm; // 仕入先略称

            return importantPrtSt;
        }

        /// <summary>
        /// クラスメンバーコピー処理（重点品目設定クラス⇒DataRow）
        /// </summary>
        /// <param name="importantPrtStWork">重点品目設定クラス</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : 重点品目設定ワーククラスから重点品目設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private void CopyToDataRowFromImportantPrtStWork( ref DataRow dr, ImportantPrtStWork importantPrtStWork, GoodsUnitData goodsUnitData )
        {
            # region [dr←importantPrtSt]
            dr[ct_COL_CREATEDATETIME] = importantPrtStWork.CreateDateTime;          // 作成日時
            dr[ct_COL_UPDATEDATETIME] = importantPrtStWork.UpdateDateTime;          // 更新日時
            dr[ct_COL_ENTERPRISECODE] = importantPrtStWork.EnterpriseCode;          // 企業コード
            dr[ct_COL_FILEHEADERGUID] = importantPrtStWork.FileHeaderGuid;          // GUID
            dr[ct_COL_UPDEMPLOYEECODE] = importantPrtStWork.UpdEmployeeCode;        // 更新従業員コード
            dr[ct_COL_UPDASSEMBLYID1] = importantPrtStWork.UpdAssemblyId1;          // 更新アセンブリID1
            dr[ct_COL_UPDASSEMBLYID2] = importantPrtStWork.UpdAssemblyId2;          // 更新アセンブリID2
            dr[ct_COL_LOGICALDELETECODE] = importantPrtStWork.LogicalDeleteCode;    // 論理削除区分
            dr[ct_COL_SECTIONCODE] = importantPrtStWork.SectionCode;                // 拠点コード
            dr[ct_COL_CUSTOMERCODE] = importantPrtStWork.CustomerCode;              // 得意先コード
            dr[ct_COL_GOODSMGROUP] = importantPrtStWork.GoodsMGroup;                // 商品中分類コード
            dr[ct_COL_BLGOODSCODE] = importantPrtStWork.BLGoodsCode;                // BL商品コード
            dr[ct_COL_GOODSMAKERCD] = importantPrtStWork.GoodsMakerCd;              // 商品メーカーコード
            dr[ct_COL_GOODSNO] = importantPrtStWork.GoodsNo;                        // 商品番号
            dr[ct_COL_VALIDDIVCD] = importantPrtStWork.ValidDivCd;                  // 有効区分
            dr[ct_COL_ValidDivCd_BACKUP] = importantPrtStWork.ValidDivCd;           // 有効区分(前回値退避)

            // 論理削除日(表示用)
            if ( importantPrtStWork.LogicalDeleteCode == 0 )
            {
                dr[ct_COL_LOGICALDELETEDATE] = string.Empty;
            }
            else
            {
                dr[ct_COL_LOGICALDELETEDATE] = TDateTime.DateTimeToString( "ggYY/MM/DD", importantPrtStWork.UpdateDateTime );
            }

            dr[ct_COL_SECTIONNM] = importantPrtStWork.SectionNm;                    // 拠点名称
            dr[ct_COL_CUSTOMERNAME] = importantPrtStWork.CustomerName;              // 得意先名称
            dr[ct_COL_GOODSMGROUPNAME] = importantPrtStWork.GoodsMGroupName;        // 商品中分類名称
            dr[ct_COL_BLGROUPNAME] = importantPrtStWork.BLGroupName;                // BLグループ名称
            dr[ct_COL_BLGOODSNAME] = importantPrtStWork.BLGoodsName;                // BL商品コード名称
            dr[ct_COL_MAKERNAME] = importantPrtStWork.MakerName;                    // メーカー名称
            dr[ct_COL_GOODSNAME] = importantPrtStWork.GoodsName;                    // 商品名称
            dr[ct_COL_BLGROUPCODE] = importantPrtStWork.BLGroupCode;                // BLグループコード

            // 商品情報からセットする
            dr[ct_COL_SUPPLIERCD] = goodsUnitData.SupplierCd;                       // 仕入先コード
            dr[ct_COL_SUPPLIERSNM] = goodsUnitData.SupplierSnm;                     // 仕入先略称

            // ソート用カラム
            dr[ct_COL_SECTIONCODE_SORT] = GetSortValue( importantPrtStWork.SectionCode );   // 拠点コード
            dr[ct_COL_CUSTOMERCODE_SORT] = GetSortValue( importantPrtStWork.CustomerCode ); // 得意先コード
            dr[ct_COL_SUPPLIERCD_SORT] = GetSortValue( goodsUnitData.SupplierCd );          // 仕入先コード
            dr[ct_COL_GOODSMAKERCD_SORT] = GetSortValue( importantPrtStWork.GoodsMakerCd ); // 商品メーカーコード
            dr[ct_COL_GOODSMGROUP_SORT] = GetSortValue( importantPrtStWork.GoodsMGroup );   // 商品中分類コード
            dr[ct_COL_BLGROUPCODE_SORT] = GetSortValue( importantPrtStWork.BLGroupCode );   // BLグループコード
            dr[ct_COL_BLGOODSCODE_SORT] = GetSortValue( importantPrtStWork.BLGoodsCode );   // BL商品コード

            // オブジェクト(内部保持用)
            dr[ct_COL_IMPORTANTPRTSTWORKOBJECT] = importantPrtStWork;
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
        /// クラスメンバーコピー処理（DataRow⇒重点品目設定クラス）
        /// </summary>
        /// <param name="row"></param>
        /// <returns>ImportantPrtStWork</returns>
        /// <remarks>
        /// <br>Note       : 重点品目設定ワーククラスから重点品目設定クラスへメンバーのコピーを行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private ImportantPrtStWork CopyToImportantPrtStWorkFromDataRow( DataRow row )
        {
            ImportantPrtStWork importantPrtStWork = (ImportantPrtStWork)row[ct_COL_IMPORTANTPRTSTWORKOBJECT];
            
            // 書き換え可能項目のみ差し替える
            importantPrtStWork.ValidDivCd = (int)row[ct_COL_VALIDDIVCD];

            return importantPrtStWork;
        }

        /// <summary>
        /// 抽出条件クラスメンバーコピー処理
        /// </summary>
        /// <param name="paraData"></param>
        /// <returns></returns>
        private ImportantPrtStOrderWork CopyToImportantPrtStOrderWorkFromImportantPrtStOrder( ImportantPrtStOrder paraData )
        {
            ImportantPrtStOrderWork paraWork = new ImportantPrtStOrderWork();
            
            # region [paraWork←paraData]
            paraWork.EnterpriseCode = paraData.EnterpriseCode;      // 企業コード
            paraWork.SectionCode = paraData.SectionCode;            // 拠点コード
            paraWork.St_CustomerCode = paraData.St_CustomerCode;    // 開始得意先コード
            paraWork.Ed_CustomerCode = paraData.Ed_CustomerCode;    // 終了得意先コード
            //paraWork.St_SupplierCd = paraData.St_SupplierCd;  // 開始仕入先コード
            //paraWork.Ed_SupplierCd = paraData.Ed_SupplierCd;  // 終了仕入先コード
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
        #endregion

        #region SearchProc 検索処理メイン（論理削除含む）
        /// <summary>
        /// 検索処理メイン（論理削除含む）
        /// </summary>
        /// <param name="retList">読込結果テーブル</param>
        /// <param name="importantPrtStList">重点品目設定オブジェクトリスト</param>
        /// <param name="logicalMode">論理削除有無(0:正規データのみ 1:削除データのみ 2:全データ)</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 重点品目設定マスタの複数検索処理を行います。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        private int SearchProc( ImportantPrtStOrder paraData, out ArrayList retWorkList, ConstantManagement.LogicalMode logicalMode, out string message )
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";
            retWorkList = null;

            try
            {
                //ArrayList paraList = new ArrayList();
                //==========================================
                // 重点品目設定マスタ読み込み
                //==========================================
                ImportantPrtStOrderWork paraWork = CopyToImportantPrtStOrderWorkFromImportantPrtStOrder( paraData );

                // リモート戻りリスト
                object importantPrtStWorkList = null;
                // 重点品目設定マスタ検索
                status = this._iImportantPrtStDB.Search( out importantPrtStWorkList, paraWork, 0, logicalMode );

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retWorkList = (ArrayList)importantPrtStWorkList;
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
        /// 重点品目設定レコード取得処理
        /// </summary>
        /// <param name="importantPrtSt">重点品目設定データ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 検索処理を行います。
        ///                  importantPrtStクラスに検索データを設定し、結果もimportantPrtStクラスに格納します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/05/22</br>
        /// </remarks>
        public int Read(ref ImportantPrtSt importantPrtSt)
        {
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

                // 抽出条件パラメータ
                ImportantPrtStWork importantPrtStWork = CopyToImportantPrtStWorkFromImportantPrtSt( importantPrtSt );

                // XMLへ変換し、文字列のバイナリ化
                byte[] parabyte = XmlByteSerializer.Serialize( importantPrtStWork );
                status = this._iImportantPrtStDB.Read( ref parabyte, 0 );

                if (status == 0)
                {
                    // XMLの読み込み
                    importantPrtStWork = (ImportantPrtStWork)XmlByteSerializer.Deserialize( parabyte, typeof( ImportantPrtStWork ) );
                }

                if (status == 0)
                {
                    // クラス内メンバコピー
                    importantPrtSt = CopyToImportantPrtStFromImportantPrtStWork( importantPrtStWork );
                }

                return status;
            }
            catch (Exception)
            {
                //通信エラーは-1を戻す
                importantPrtSt = null;
                //オフライン時はnullをセット
                this._iImportantPrtStDB = null;
                return -1;
            }
        }
        #endregion

        // ADD 2009/06/17 ------>>>
        #region 重点品目設定データ取得処理
        /// <summary>
        /// 重点品目設定データ処理
        /// </summary>
        /// <param name="importantPrtSt">抽出結果の重点品目設定データ</param>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="customerCode">得意先コード</param>
        /// <param name="goodsMakerCd">メーカーコード</param>
        /// <param name="goodsMGroup">商品中分類</param>
        /// <param name="blGoodsCode">BLコード</param>
        /// <param name="goodsNo">品番</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 抽出条件から重点品目設定データを返します。</br>
        /// <br>Programmer : 30413 犬飼</br>
        /// <br>Date       : 2009/06/16</br>
        /// </remarks>
        public int GetImportantPrtSt(out ImportantPrtSt importantPrtSt, string enterpriseCode, string sectionCode, int customerCode,
                                     int goodsMakerCd, int goodsMGroup, int blGoodsCode, string goodsNo)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ADD 2009/08/25 チケット[14065]対応 ------>>>
            // キーを設定する際、スペースは削っているので、パラメータもスペースを削る
            sectionCode = sectionCode.Trim();
            goodsNo     = goodsNo.Trim();
            // ADD 2009/08/25 チケット[14065]対応 ------<<<

            if (_ImportantPrtStDic == null)
            {
                // 重点品目設定キャッシュにデータが無いので取得
                ImportantPrtStOrder importantPrtStOrder = new ImportantPrtStOrder();
                importantPrtStOrder.EnterpriseCode = enterpriseCode;
                importantPrtStOrder.SectionCode = null;

                List<ImportantPrtSt> retList;
                string message;

                // 重点品目設定マスタの全検索
                status = Search(importantPrtStOrder, out retList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // 全検索で失敗
                    importantPrtSt = null;
                    return status;
                }

                // 重点品目設定データのキャッシュ化
                _ImportantPrtStDic = new Dictionary<DICKEY, ImportantPrtSt>();

                foreach (ImportantPrtSt wkImportantPrtSt in retList)
                {
                    if (wkImportantPrtSt.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    // 追加キー作成
                    DICKEY addKey = new DICKEY();
                    addKey.sectionCode = wkImportantPrtSt.SectionCode.TrimEnd();
                    addKey.customerCode = wkImportantPrtSt.CustomerCode;
                    addKey.goodsMGroup = wkImportantPrtSt.GoodsMGroup;
                    addKey.blGoodsCode = wkImportantPrtSt.BLGoodsCode;
                    addKey.goodsMakerCd = wkImportantPrtSt.GoodsMakerCd;
                    addKey.goodsNo = wkImportantPrtSt.GoodsNo.Trim();

                    if (!_ImportantPrtStDic.ContainsKey(addKey))
                    {
                        _ImportantPrtStDic.Add(addKey, wkImportantPrtSt);
                    }
                }
            }

            // DEL 2009/08/25 チケット[14065]対応 ------>>>
            #region 削除コード
            //// キー作成
            //DICKEY key = new DICKEY();
            //key.sectionCode = sectionCode.TrimEnd();
            //key.customerCode = customerCode;
            //key.goodsMGroup = goodsMGroup;
            //key.blGoodsCode = blGoodsCode;
            //key.goodsMakerCd = goodsMakerCd;
            //key.goodsNo = goodsNo.Trim();

            //if (_ImportantPrtStDic.ContainsKey(key))
            //{
            //    // 該当データ有り
            //    importantPrtSt = _ImportantPrtStDic[key].Clone();
            //    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            //}
            //else
            //{
            //    // 該当データ無し
            //    importantPrtSt = null;
            //    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //}

            //return status;
            #endregion // 削除コード
            // DEL 2009/08/25 チケット[14065]対応 ------<<<

            // ADD 2009/08/25 チケット[14065]対応 ------>>>
            // 重点品目設定キャッシュからデータ取得

            #region 優先順位1:得意先＋メーカー＋品番

            DICKEY key1 = new DICKEY();
            {
                key1.sectionCode = string.Empty;
                key1.customerCode = customerCode;
                key1.goodsMakerCd = goodsMakerCd;
                key1.goodsNo = goodsNo.Trim();
            }
            if (_ImportantPrtStDic.ContainsKey(key1))
            {
                importantPrtSt = _ImportantPrtStDic[key1].Clone();
                return status;
            }

            #endregion

            #region 優先順位2:得意先＋メーカー＋BLコード

            DICKEY key2 = new DICKEY();
            {
                key2.sectionCode = string.Empty;
                key2.customerCode = customerCode;
                key2.goodsMakerCd = goodsMakerCd;
                key2.blGoodsCode = blGoodsCode;
                key2.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key2))
            {
                importantPrtSt = _ImportantPrtStDic[key2].Clone();
                return status;
            }

            #endregion

            #region 優先順位3:得意先＋メーカー＋中分類コード

            DICKEY key3 = new DICKEY();
            {
                key3.sectionCode = string.Empty;
                key3.customerCode = customerCode;
                key3.goodsMakerCd = goodsMakerCd;
                key3.goodsMGroup = goodsMGroup;
                key3.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key3))
            {
                importantPrtSt = _ImportantPrtStDic[key3].Clone();
                return status;
            }

            #endregion

            #region 優先順位4:得意先＋メーカー

            DICKEY key4 = new DICKEY();
            {
                key4.sectionCode = string.Empty;
                key4.customerCode = customerCode;
                key4.goodsMakerCd = goodsMakerCd;
                key4.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key4))
            {
                importantPrtSt = _ImportantPrtStDic[key4].Clone();
                return status;
            }

            #endregion

            #region 優先順位5:拠点＋メーカー＋品番

            DICKEY key5 = new DICKEY();
            {
                key5.sectionCode = sectionCode;
                key5.goodsMakerCd = goodsMakerCd;
                key5.goodsNo = goodsNo.Trim();
            }
            if (_ImportantPrtStDic.ContainsKey(key5))
            {
                importantPrtSt = _ImportantPrtStDic[key5].Clone();
                return status;
            }

            #endregion

            #region 優先順位6:拠点＋メーカー＋BLコード

            DICKEY key6 = new DICKEY();
            {
                key6.sectionCode = sectionCode;
                key6.goodsMakerCd = goodsMakerCd;
                key6.blGoodsCode = blGoodsCode;
                key6.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key6))
            {
                importantPrtSt = _ImportantPrtStDic[key6].Clone();
                return status;
            }

            #endregion

            #region 優先順位7:拠点＋メーカー＋中分類コード

            DICKEY key7 = new DICKEY();
            {
                key7.sectionCode = sectionCode;
                key7.goodsMakerCd = goodsMakerCd;
                key7.goodsMGroup = goodsMGroup;
                key7.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key7))
            {
                importantPrtSt = _ImportantPrtStDic[key7].Clone();
                return status;
            }

            #endregion

            #region 優先順位8:拠点＋メーカー

            DICKEY key8 = new DICKEY();
            {
                key8.sectionCode = sectionCode;
                key8.goodsMakerCd = goodsMakerCd;
                key8.goodsNo = string.Empty;
            }
            if (_ImportantPrtStDic.ContainsKey(key8))
            {
                importantPrtSt = _ImportantPrtStDic[key8].Clone();
                return status;
            }

            #endregion

            // 全社で再検索
            importantPrtSt = null;
            int sectionCodeNo = -1;
            if (int.TryParse(sectionCode.Trim(), out sectionCodeNo))
            {
                if (sectionCodeNo > 0)
                {
                    return GetImportantPrtSt(
                        out importantPrtSt,
                        enterpriseCode,
                        "00",   // 全社設定
                        customerCode,
                        goodsMakerCd,
                        goodsMGroup,
                        blGoodsCode,
                        goodsNo
                    );
                }
            }
            return status;
            // ADD 2009/08/25 チケット[14065]対応 ------<<<
        }
        #endregion
        // ADD 2009/06/17 ------<<<
    }
}
