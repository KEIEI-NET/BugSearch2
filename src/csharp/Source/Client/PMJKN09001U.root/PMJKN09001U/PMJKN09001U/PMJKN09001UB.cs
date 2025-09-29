//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 諸元情報データテーブルスキーマ情報クラス
// プログラム概要   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10602352-00 作成担当 : 肖緒徳
// 作 成 日  2010/04/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// 諸元情報データテーブルスキーマ情報クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 諸元情報データのテーブルスキーマ情報クラスです。</br>
    /// <br>Programmer : 肖緒徳</br>
    /// <br>Date       : 2010.04.26</br>
    /// <br></br>
    /// </remarks>
    class PMJKN09001UB
    {
        #region -- Constructor --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 諸元情報データテーブルスキーマ情報クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 諸元情報データテーブルスキーマ情報クラスの初期化、</br>
        /// <br>             及びインスタンス生成を行います。</br>
        /// <br>Programmer : 肖緒徳</br>
        /// <br>Date       : 2010.04.26</br>
        /// </remarks>
        public PMJKN09001UB()
        {
        }
        #endregion

        #region -- Public Members --
        /*----------------------------------------------------------------------------------*/
        // DataTable名
        /// <summary> 諸元情報データテーブル名称 </summary>
        public const string TBL_CARSPECVIEW = "CARSPECVIEW";

        // DataTable列名
        /// <summary>グレード</summary>
        public const string COL_MODELGRADENM_TITLE = "グレード";
        /// <summary>ボディ</summary>
        public const string COL_BODYNAME_TITLE = "ボディ";
        /// <summary>ドア</summary>
        public const string COL_DOORCOUNT_TITLE = "ドア";
        /// <summary>エンジン</summary>
        public const string COL_ENGINEMODELNM_TITLE = "エンジン";
        /// <summary>排気量</summary>
        public const string COL_ENGINEDISPLACENM_TITLE = "排気量";
        /// <summary>E区分</summary>
        public const string COL_EDIVNM_TITLE = "E区分";
        /// <summary>ミッション</summary>
        public const string COL_TRANSMISSIONNM_TITLE = "ミッション";
        /// <summary>駆動形式</summary>
        public const string COL_WHEELDRIVEMETHODNM_TITLE = "駆動形式";
        /// <summary>シフト</summary>
        public const string COL_SHIFTNM_TITLE = "シフト";
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
        static public void DataSetColumnConstruction(ref DataSet ds)
        {
            if (ds.Tables.Contains(TBL_CARSPECVIEW))
            {
                // テーブルが存在する場合はクリアーのみ
                // スキーマをもう一度設定するようなことはしない
                ds.Tables[TBL_CARSPECVIEW].Clear();
            }
            else
            {
                // テーブルが存在しない場合のみスキーマを設定

                // スキーマ設定
                ds.Tables.Add(TBL_CARSPECVIEW);
                DataTable dt = ds.Tables[TBL_CARSPECVIEW];

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
            }
        }
        #endregion
    }
}
