//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 手形明細表テーブルスキーマ定義クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 王開強
// 作 成 日  2010/04/28  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 手形明細表テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 手形明細表テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 王開強</br>
    /// <br>Date       : 2010.04.28</br>
    /// </remarks>
    public class PMTEG02105EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_TegataMeisaiListReportData = "Tbl_TegataMeisaiListReportData";

        /// <summary> 手形種別コード </summary>
        public const string ct_Col_DraftKindCd = "DraftKindCd";
        /// <summary> 手形種別名称 </summary>
        public const string ct_Col_DraftKindName = "DraftKindName";
        /// <summary> 銀行・支店コード </summary>
        public const string ct_Col_BankAndBranchCd = "BankAndBranchCd";
        /// <summary> 銀行・支店名称 </summary>
        public const string ct_Col_BankAndBranchNm = "BankAndBranchNm";
        /// <summary> 入金日/支払日 </summary>
        public const string ct_Col_DepositDate = "DepositDate";
        /// <summary> 振出日 </summary>
        public const string ct_Col_DraftDrawingDate = "DraftDrawingDate";
        /// <summary> 満期日 </summary>
        public const string ct_Col_ValidityTerm = "ValidityTerm";
        /// <summary> サイト </summary>
        public const string ct_Col_Site = "Site";
        /// <summary> 手形区分 </summary>
        public const string ct_Col_DraftDivide = "DraftDivide";
        /// <summary> 受取手形番号 </summary>
        public const string ct_Col_RcvDraftNo = "RcvDraftNo";
        /// <summary> 計上拠点コード </summary>
        public const string ct_Col_AddUpSecCode = "AddUpSecCode";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 入金金額/支払金額 </summary>
        public const string ct_Col_Deposit = "Deposit";
        /// <summary> 伝票摘要1 </summary>
        public const string ct_Col_Outline1 = "Outline1";
        /// <summary> 伝票摘要2 </summary>
        public const string ct_Col_Outline2 = "Outline2";

        /// <summary> 改頁 </summary>
        public const string ct_Col_ChangePage = "ChangePage";
        /// <summary> 満期日(グループ用) </summary>
        public const string ct_Col_ValidityTermForGroup = "ValidityTermForGroup";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 手形明細表テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 手形明細表テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        public PMTEG02105EA()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ 手形明細表DataSetテーブルスキーマ設定
        /// <summary>
        /// 手形明細表DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 手形明細表データセットのスキーマを設定する。</br>
        /// <br>Programmer : 王開強</br>
        /// <br>Date       : 2010.04.28</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_TegataMeisaiListReportData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_TegataMeisaiListReportData].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_TegataMeisaiListReportData);

                DataTable dt = ds.Tables[ct_Tbl_TegataMeisaiListReportData];
                // 手形種別コード
                dt.Columns.Add(ct_Col_DraftKindCd, typeof(string));
                dt.Columns[ct_Col_DraftKindCd].DefaultValue = string.Empty;
                // 手形種別名称
                dt.Columns.Add(ct_Col_DraftKindName, typeof(string));
                dt.Columns[ct_Col_DraftKindName].DefaultValue = string.Empty;
                // 銀行・支店コード
                dt.Columns.Add(ct_Col_BankAndBranchCd, typeof(string));
                dt.Columns[ct_Col_BankAndBranchCd].DefaultValue = string.Empty;
                // 銀行・支店名称
                dt.Columns.Add(ct_Col_BankAndBranchNm, typeof(string));
                dt.Columns[ct_Col_BankAndBranchNm].DefaultValue = string.Empty;
                // 入金日/支払日 
                //  todo
                dt.Columns.Add(ct_Col_DepositDate, typeof(string));
                dt.Columns[ct_Col_DepositDate].DefaultValue = string.Empty;
                // 振出日
                dt.Columns.Add(ct_Col_DraftDrawingDate, typeof(string));
                dt.Columns[ct_Col_DraftDrawingDate].DefaultValue = string.Empty;
                // 満期日
                dt.Columns.Add(ct_Col_ValidityTerm, typeof(string));
                dt.Columns[ct_Col_ValidityTerm].DefaultValue = string.Empty;
                // サイト
                dt.Columns.Add(ct_Col_Site, typeof(string));
                dt.Columns[ct_Col_Site].DefaultValue = string.Empty;
                // 手形区分
                dt.Columns.Add(ct_Col_DraftDivide, typeof(string));
                dt.Columns[ct_Col_DraftDivide].DefaultValue = string.Empty;
                // 受取手形番号
                dt.Columns.Add(ct_Col_RcvDraftNo, typeof(string));
                dt.Columns[ct_Col_RcvDraftNo].DefaultValue = string.Empty;
                // 計上拠点コード 
                dt.Columns.Add(ct_Col_AddUpSecCode, typeof(string));
                dt.Columns[ct_Col_AddUpSecCode].DefaultValue = string.Empty;
                // 得意先コード
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                dt.Columns[ct_Col_CustomerCode].DefaultValue = string.Empty;
                // 得意先略称
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = string.Empty;
                // 入金金額/支払金額 
                dt.Columns.Add(ct_Col_Deposit, typeof(long));
                dt.Columns[ct_Col_Deposit].DefaultValue = 0;
                // 伝票摘要1 
                dt.Columns.Add(ct_Col_Outline1, typeof(string));
                dt.Columns[ct_Col_Outline1].DefaultValue = string.Empty;
                // 伝票摘要2
                dt.Columns.Add(ct_Col_Outline2, typeof(string));
                dt.Columns[ct_Col_Outline2].DefaultValue = string.Empty;
                // 改頁
                dt.Columns.Add(ct_Col_ChangePage, typeof(string));
                dt.Columns[ct_Col_ChangePage].DefaultValue = string.Empty;
                // 満期日(グループ用)
                dt.Columns.Add(ct_Col_ValidityTermForGroup, typeof(string));
                dt.Columns[ct_Col_ValidityTermForGroup].DefaultValue = string.Empty;

            }
        }
        #endregion
        #endregion
    }
}