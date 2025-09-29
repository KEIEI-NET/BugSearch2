//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 未入金一覧表テーブルスキーマ定義クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 22018 鈴木正臣
// 作 成 日  2010/07/01  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : liyp
// 作 成 日  2010/12/20  修正内容 : 帳票レイアウト上の日付項目を売上日項目と入力日項目に分ける
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 未入金一覧表テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 未入金一覧表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 22018 鈴木正臣</br>
    /// <br>Date       : 2010/07/01</br>
    /// </remarks>
    public class PMKAU02005EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_NoDepSalListData = "Tbl_NoDepSalListData";

        /// <summary> 企業コード </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> 請求計上拠点コード </summary>
        public const string ct_Col_DemandAddUpSecCd = "DemandAddUpSecCd";
        /// <summary> 請求計上拠点名称 </summary>
        public const string ct_Col_DemandAddUpSecNm = "DemandAddUpSecNm";
        /// <summary> 請求先コード </summary>
        public const string ct_Col_ClaimCode = "ClaimCode";
        /// <summary> 請求先名称 </summary>
        public const string ct_Col_ClaimName = "ClaimName";
        /// <summary> 請求先名称2 </summary>
        public const string ct_Col_ClaimName2 = "ClaimName2";
        /// <summary> 請求先略称 </summary>
        public const string ct_Col_ClaimSnm = "ClaimSnm";
        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 拠点名称 </summary>
        public const string ct_Col_SectionName = "SectionName";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先名称 </summary>
        public const string ct_Col_CustomerName = "CustomerName";
        /// <summary> 得意先名称2 </summary>
        public const string ct_Col_CustomerName2 = "CustomerName2";
        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 売上日付 </summary>
        public const string ct_Col_SalesDate = "SalesDate";
        ///// <summary> 伝票検索日付 </summary>
        //public const string ct_Col_SearchSlipDate = "SearchSlipDate";
        // ---------------ADD 2010/12/20 ----------->>>>>
        /// <summary> 伝票検索日付 </summary>
        public const string ct_Col_SearchSlipDate = "SearchSlipDate";
        // ---------------ADD 2010/12/20 -----------<<<<<
        /// <summary> 売上伝票番号 </summary>
        public const string ct_Col_SalesSlipNum = "SalesSlipNum";
        /// <summary> 売上伝票区分 </summary>
        public const string ct_Col_SalesSlipCd = "SalesSlipCd";
        ///// <summary> 売上伝票合計（税込み） </summary>
        //public const string ct_Col_SalesTotalTaxInc = "SalesTotalTaxInc";
        ///// <summary> 売上伝票合計（税抜き） </summary>
        //public const string ct_Col_SalesTotalTaxExc = "SalesTotalTaxExc";
        /// <summary> 売上伝票合計（税込/税抜 判断後の値） </summary>
        public const string ct_Col_SalesTotal = "SalesTotal";
        /// <summary> 売上入力者コード </summary>
        public const string ct_Col_SalesInputCode = "SalesInputCode";
        /// <summary> 売上入力者名称 </summary>
        public const string ct_Col_SalesInputName = "SalesInputName";
        /// <summary> 受付従業員コード </summary>
        public const string ct_Col_FrontEmployeeCd = "FrontEmployeeCd";
        /// <summary> 受付従業員名称 </summary>
        public const string ct_Col_FrontEmployeeNm = "FrontEmployeeNm";
        /// <summary> 販売従業員コード </summary>
        public const string ct_Col_SalesEmployeeCd = "SalesEmployeeCd";
        /// <summary> 販売従業員名称 </summary>
        public const string ct_Col_SalesEmployeeNm = "SalesEmployeeNm";
        /// <summary> 伝票備考 </summary>
        public const string ct_Col_SlipNote = "SlipNote";
        /// <summary> 伝票備考２ </summary>
        public const string ct_Col_SlipNote2 = "SlipNote2";
        /// <summary> 伝票備考３ </summary>
        public const string ct_Col_SlipNote3 = "SlipNote3";
        /// <summary> 売上伝票区分名称 </summary>
        public const string ct_Col_SalesSlipCdNm = "SalesSlipCdNm";
        /// <summary> 入金引当残高 </summary>
        public const string ct_Col_DepositAlwcBlnce = "DepositAlwcBlnce";
        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 未入金一覧表テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 未入金一覧表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// </remarks>
        public PMKAU02005EA()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ 未入金一覧表DataSetテーブルスキーマ設定
        /// <summary>
        /// 未入金一覧表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 未入金一覧表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 22018 鈴木正臣</br>
        /// <br>Date       : 2010/07/01</br>
        /// <br>Update Note: 2010/12/20 liyp</br>
        /// <br>             帳票レイアウト上の日付項目を売上日項目と入力日項目に分ける</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_NoDepSalListData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_NoDepSalListData].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_NoDepSalListData);
                DataTable dt = ds.Tables[ct_Tbl_NoDepSalListData];

                // 企業コード
                dt.Columns.Add( ct_Col_EnterpriseCode, typeof( string ) );
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;
                // 請求計上拠点コード
                dt.Columns.Add( ct_Col_DemandAddUpSecCd, typeof( string ) );
                dt.Columns[ct_Col_DemandAddUpSecCd].DefaultValue = string.Empty;
                // 請求計上拠点名称
                dt.Columns.Add( ct_Col_DemandAddUpSecNm, typeof( string ) );
                dt.Columns[ct_Col_DemandAddUpSecNm].DefaultValue = string.Empty;
                // 請求先コード
                dt.Columns.Add( ct_Col_ClaimCode, typeof( Int32 ) );
                dt.Columns[ct_Col_ClaimCode].DefaultValue = 0;
                // 請求先名称
                dt.Columns.Add( ct_Col_ClaimName, typeof( string ) );
                dt.Columns[ct_Col_ClaimName].DefaultValue = string.Empty;
                // 請求先名称2
                dt.Columns.Add( ct_Col_ClaimName2, typeof( string ) );
                dt.Columns[ct_Col_ClaimName2].DefaultValue = string.Empty;
                // 請求先略称
                dt.Columns.Add( ct_Col_ClaimSnm, typeof( string ) );
                dt.Columns[ct_Col_ClaimSnm].DefaultValue = string.Empty;
                // 拠点コード
                dt.Columns.Add( ct_Col_SectionCode, typeof( string ) );
                dt.Columns[ct_Col_SectionCode].DefaultValue = string.Empty;
                // 拠点名称
                dt.Columns.Add( ct_Col_SectionName, typeof( string ) );
                dt.Columns[ct_Col_SectionName].DefaultValue = string.Empty;
                // 得意先コード
                dt.Columns.Add( ct_Col_CustomerCode, typeof( Int32 ) );
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                // 得意先名称
                dt.Columns.Add( ct_Col_CustomerName, typeof( string ) );
                dt.Columns[ct_Col_CustomerName].DefaultValue = string.Empty;
                // 得意先名称2
                dt.Columns.Add( ct_Col_CustomerName2, typeof( string ) );
                dt.Columns[ct_Col_CustomerName2].DefaultValue = string.Empty;
                // 得意先略称
                dt.Columns.Add( ct_Col_CustomerSnm, typeof( string ) );
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = string.Empty;
                // 売上日付
                dt.Columns.Add( ct_Col_SalesDate, typeof( string ) );
                dt.Columns[ct_Col_SalesDate].DefaultValue = string.Empty;
                //// 伝票検索日付
                //dt.Columns.Add( ct_Col_SearchSlipDate, typeof( Int32 ) );
                //dt.Columns[ct_Col_SearchSlipDate].DefaultValue = 0;
                // ---------------ADD 2010/12/20 ----------->>>>>
                // 伝票検索日付
                dt.Columns.Add(ct_Col_SearchSlipDate, typeof(string));
                dt.Columns[ct_Col_SearchSlipDate].DefaultValue = string.Empty;
                // ---------------ADD 2010/12/20 -----------<<<<<
                // 売上伝票番号
                dt.Columns.Add( ct_Col_SalesSlipNum, typeof( string ) );
                dt.Columns[ct_Col_SalesSlipNum].DefaultValue = string.Empty;
                // 売上伝票区分
                dt.Columns.Add( ct_Col_SalesSlipCd, typeof( Int32 ) );
                dt.Columns[ct_Col_SalesSlipCd].DefaultValue = 0;
                //// 売上伝票合計（税込み）
                //dt.Columns.Add( ct_Col_SalesTotalTaxInc, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxInc].DefaultValue = 0;
                //// 売上伝票合計（税抜き）
                //dt.Columns.Add( ct_Col_SalesTotalTaxExc, typeof( Int64 ) );
                //dt.Columns[ct_Col_SalesTotalTaxExc].DefaultValue = 0;
                // 売上伝票合計（税込/税抜 判断後の値）
                dt.Columns.Add( ct_Col_SalesTotal, typeof( Int64 ) );
                dt.Columns[ct_Col_SalesTotal].DefaultValue = 0;
                // 売上入力者コード
                dt.Columns.Add( ct_Col_SalesInputCode, typeof( string ) );
                dt.Columns[ct_Col_SalesInputCode].DefaultValue = string.Empty;
                // 売上入力者名称
                dt.Columns.Add( ct_Col_SalesInputName, typeof( string ) );
                dt.Columns[ct_Col_SalesInputName].DefaultValue = string.Empty;
                // 受付従業員コード
                dt.Columns.Add( ct_Col_FrontEmployeeCd, typeof( string ) );
                dt.Columns[ct_Col_FrontEmployeeCd].DefaultValue = string.Empty;
                // 受付従業員名称
                dt.Columns.Add( ct_Col_FrontEmployeeNm, typeof( string ) );
                dt.Columns[ct_Col_FrontEmployeeNm].DefaultValue = string.Empty;
                // 販売従業員コード
                dt.Columns.Add( ct_Col_SalesEmployeeCd, typeof( string ) );
                dt.Columns[ct_Col_SalesEmployeeCd].DefaultValue = string.Empty;
                // 販売従業員名称
                dt.Columns.Add( ct_Col_SalesEmployeeNm, typeof( string ) );
                dt.Columns[ct_Col_SalesEmployeeNm].DefaultValue = string.Empty;
                // 伝票備考
                dt.Columns.Add( ct_Col_SlipNote, typeof( string ) );
                dt.Columns[ct_Col_SlipNote].DefaultValue = string.Empty;
                // 伝票備考２
                dt.Columns.Add( ct_Col_SlipNote2, typeof( string ) );
                dt.Columns[ct_Col_SlipNote2].DefaultValue = string.Empty;
                // 伝票備考３
                dt.Columns.Add( ct_Col_SlipNote3, typeof( string ) );
                dt.Columns[ct_Col_SlipNote3].DefaultValue = string.Empty;
                // 売上伝票区分名称
                dt.Columns.Add( ct_Col_SalesSlipCdNm, typeof( string ) );
                dt.Columns[ct_Col_SalesSlipCdNm].DefaultValue = string.Empty;
                // 入金引当残高
                dt.Columns.Add( ct_Col_DepositAlwcBlnce, typeof( Int64 ) );
                dt.Columns[ct_Col_DepositAlwcBlnce].DefaultValue = 0;
            }
        }
        #endregion
        #endregion
    }
}