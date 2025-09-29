using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 明細情報データテーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 明細情報データのテーブルスキーマ情報クラスです。</br>
    /// <br>Programmer : 肖緒徳</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// </remarks>
    class PMJKN09011UC
    {
        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 明細情報データテーブルスキーマ情報クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 明細情報データテーブルスキーマ情報クラスの初期化、</br>
        /// <br>             及びインスタンス生成を行います。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public PMJKN09011UC()
        {
        }
        #endregion

        #region -- Public Members --
        /*----------------------------------------------------------------------------------*/
        // DataTable名
        /// <summary> 明細情報データテーブル名称 </summary>
        public const string TBL_DETAILVIEW = "DETAILVIEW";

        // DataTable列名
        /// <summary>No.</summary>
        public const string COL_NO_TITLE = "No.";
        /// <summary>品番</summary>
        public const string COL_GOODSNO_TITLE = "品番";
        /// <summary>メーカー</summary>
        public const string COL_MAKER_TITLE = "ﾒｰｶｰ";
        /// <summary>BLコード</summary>
        public const string COL_BLCODE_TITLE = "BLｺｰﾄﾞ";
        /// <summary>品名</summary>
        public const string COL_GOODSNM_TITLE = "品名";
        /// <summary>QTY</summary>
        public const string COL_PARTSQTY_TITLE = "QTY";
        /// <summary>標準価格</summary>
        public const string COL_COSTRATE_TITLE = "標準価格";
        /// <summary>生産年式</summary>
        public const string COL_CREATEYEAR_TITLE = "生産年式";
        /// <summary>生産車台番号</summary>
        public const string COL_CREATECARNO_TITLE = "生産車台番号";
        /// <summary>グレード</summary>
        public const string COL_MODELGRADENM_TITLE = "ｸﾞﾚｰﾄﾞ";
        /// <summary>ボディ</summary>
        public const string COL_BODYNAME_TITLE = "ﾎﾞﾃﾞｨ";
        /// <summary>ドア</summary>
        public const string COL_DOORCOUNT_TITLE = "ﾄﾞｱ";
        /// <summary>エンジン</summary>
        public const string COL_ENGINEMODELNM_TITLE = "ｴﾝｼﾞﾝ";
        /// <summary>排気量</summary>
        public const string COL_ENGINEDISPLACENM_TITLE = "排気量";
        /// <summary>E区分</summary>
        public const string COL_EDIVNM_TITLE = "E区分";
        /// <summary>ミッション</summary>
        public const string COL_TRANSMISSIONNM_TITLE = "ﾐｯｼｮﾝ";
        /// <summary>駆動形式</summary>
        public const string COL_WHEELDRIVEMETHODNM_TITLE = "駆動方式";
        /// <summary>シフト</summary>
        public const string COL_SHIFTNM_TITLE = "ｼﾌﾄ";
        /// <summary>摘要</summary>
        public const string COL_ADDICARSPEC_TITLE = "摘要";
        /// <summary>自由検索部品固有番号</summary>
        public const string COL_FRESRCHPRTPROPNO_TITLE = "自由検索部品固有番号";
        /// <summary>型式グループ区分</summary>
        public const string COL_FULLMODELGROUP_TITLE = "型式グループ区分";

        #endregion

        #region -- Public Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データセットスキーマ設定処理
        /// </summary>
        /// <param name="ds">設定対象データセット</param>
        /// <remarks>
        /// <br>Note       : データセットのスキーマを設定します。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public void DataSetColumnConstruction(ref DataSet ds)
        {
            if (ds.Tables.Contains(TBL_DETAILVIEW))
            {
                // テーブルが存在する場合はクリアーのみ
                // スキーマをもう一度設定するようなことはしない
                ds.Tables[TBL_DETAILVIEW].Clear();
            }
            else
            {
                // テーブルが存在しない場合のみスキーマを設定

                // スキーマ設定
                ds.Tables.Add(TBL_DETAILVIEW);
                DataTable dt = ds.Tables[TBL_DETAILVIEW];

                // No.
                dt.Columns.Add(COL_NO_TITLE, typeof(string));
                dt.Columns[COL_NO_TITLE].DefaultValue = "";
                // 品番
                dt.Columns.Add(COL_GOODSNO_TITLE, typeof(string));
                dt.Columns[COL_GOODSNO_TITLE].DefaultValue = "";
                // メーカー
                dt.Columns.Add(COL_MAKER_TITLE, typeof(string));
                dt.Columns[COL_MAKER_TITLE].DefaultValue = "";
                // BLコード
                dt.Columns.Add(COL_BLCODE_TITLE, typeof(string));
                dt.Columns[COL_BLCODE_TITLE].DefaultValue = "";
                // 排気量
                dt.Columns.Add(COL_GOODSNM_TITLE, typeof(string));
                dt.Columns[COL_GOODSNM_TITLE].DefaultValue = "";
                // QTY
                dt.Columns.Add(COL_PARTSQTY_TITLE, typeof(string));
                dt.Columns[COL_PARTSQTY_TITLE].DefaultValue = "";
                // 標準価格
                dt.Columns.Add(COL_COSTRATE_TITLE, typeof(string));
                dt.Columns[COL_COSTRATE_TITLE].DefaultValue = "";
                // 開始生産年式
                dt.Columns.Add(COL_CREATEYEAR_TITLE, typeof(string));
                dt.Columns[COL_CREATEYEAR_TITLE].DefaultValue = "";
                // 生産車台番号
                dt.Columns.Add(COL_CREATECARNO_TITLE, typeof(string));
                dt.Columns[COL_CREATECARNO_TITLE].DefaultValue = "";
                // グレード
                dt.Columns.Add(COL_MODELGRADENM_TITLE, typeof(string));
                dt.Columns[COL_MODELGRADENM_TITLE].DefaultValue = "";
                // ボディ
                dt.Columns.Add(COL_BODYNAME_TITLE, typeof(string));
                dt.Columns[COL_BODYNAME_TITLE].DefaultValue = "";
                // ドア
                dt.Columns.Add(COL_DOORCOUNT_TITLE, typeof(string));
                dt.Columns[COL_DOORCOUNT_TITLE].DefaultValue = "";
                // エンジン
                dt.Columns.Add(COL_ENGINEMODELNM_TITLE, typeof(string));
                dt.Columns[COL_ENGINEMODELNM_TITLE].DefaultValue = "";
                // 排気量
                dt.Columns.Add(COL_ENGINEDISPLACENM_TITLE, typeof(string));
                dt.Columns[COL_ENGINEDISPLACENM_TITLE].DefaultValue = "";
                // E区分
                dt.Columns.Add(COL_EDIVNM_TITLE, typeof(string));
                dt.Columns[COL_EDIVNM_TITLE].DefaultValue = "";
                // ミッション
                dt.Columns.Add(COL_TRANSMISSIONNM_TITLE, typeof(string));
                dt.Columns[COL_TRANSMISSIONNM_TITLE].DefaultValue = "";
                // 駆動形式
                dt.Columns.Add(COL_WHEELDRIVEMETHODNM_TITLE, typeof(string));
                dt.Columns[COL_WHEELDRIVEMETHODNM_TITLE].DefaultValue = "";
                // シフト
                dt.Columns.Add(COL_SHIFTNM_TITLE, typeof(string));
                dt.Columns[COL_SHIFTNM_TITLE].DefaultValue = "";
                // 摘要
                dt.Columns.Add(COL_ADDICARSPEC_TITLE, typeof(string));
                dt.Columns[COL_ADDICARSPEC_TITLE].DefaultValue = "";
                // 自由検索部品固有番号
                dt.Columns.Add(COL_FRESRCHPRTPROPNO_TITLE, typeof(string));
                dt.Columns[COL_FRESRCHPRTPROPNO_TITLE].DefaultValue = "";
                // 型式グループ区分
                dt.Columns.Add(COL_FULLMODELGROUP_TITLE, typeof(string));
                dt.Columns[COL_FULLMODELGROUP_TITLE].DefaultValue = "";
            }
        }
        #endregion
    }
}
