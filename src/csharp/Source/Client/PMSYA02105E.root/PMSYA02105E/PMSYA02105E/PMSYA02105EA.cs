//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 当月車検車両一覧表テーブルスキーマ定義クラス
// プログラム概要   : 定義・初期化及びインスタンス生成を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 薛祺
// 作 成 日  2010/04/21  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 
// 修 正 日              修正内容 : 
//----------------------------------------------------------------------------//
// Update Note  : 2010/05/08 王海立 redmine #7156の対応
//　　　　　　　: 車種と得意先コードの帳票の印字
//----------------------------------------------------------------------------//
using System;
using System.Data;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 当月車検車両一覧テーブルスキーマ定義クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 当月車検車両一覧テーブルスキーマクラスの定義・初期化及びインスタンス生成を行う。</br>
    /// <br>Programmer : 薛祺</br>
    /// <br>Date       : 2010.04.21</br>
    /// </remarks>
    public class PMSYA02105EA
    {
        #region ■ Public Const

        /// <summary> テーブル名称 </summary>
        public const string ct_Tbl_MonthCarInspectListReportData = "Tbl_MonthCarInspectListReportData";

        /// <summary> 得意先略称 </summary>
        public const string ct_Col_CustomerSnm = "CustomerSnm";
        /// <summary> 管理拠点コード </summary>
        public const string ct_Col_MngSectionCode = "MngSectionCode";
        /// <summary> 企業コード </summary>
        public const string ct_Col_EnterpriseCode = "EnterpriseCode";
        /// <summary> 論理削除区分 </summary>
        public const string ct_Col_LogicalDeleteCode = "LogicalDeleteCode";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 車両管理番号 </summary>
        public const string ct_Col_CarMngNo = "CarMngNo";
        /// <summary> 車輌管理コード </summary>
        public const string ct_Col_CarMngCode = "CarMngCode";
        /// <summary> 登録番号 </summary>
        public const string ct_Col_NumberPlate = "NumberPlate";
        /// <summary> 初年度 </summary>
        public const string ct_Col_FirstEntryDate = "FirstEntryDate";
        /// <summary> 車種コード </summary>
        public const string ct_Col_ModelCode = "ModelCode";
        /// <summary> 車種半角名称 </summary>
        public const string ct_Col_ModelHalfName = "ModelHalfName";
        /// <summary> 型式（フル型） </summary>
        public const string ct_Col_FullModel = "FullModel";
        /// <summary> 車台番号 </summary>
        public const string ct_Col_FrameNo = "FrameNo";
        /// <summary> 車検満期日 </summary>
        public const string ct_Col_InspectMaturityDate = "InspectMaturityDate";
        /// <summary> 車検期間 </summary>
        public const string ct_Col_CarInspectYear = "CarInspectYear";
        /// <summary> ROW </summary>
        public const string ct_Col_Row = "Row";
        /// <summary> Group </summary>
        public const string ct_Col_Group = "Group";

        #endregion ■ Public Const

        #region ■ Constructor
        /// <summary>
        /// 当月車検車両一覧テーブルスキーマ定義クラスコンストラクタ
        /// </summary>
        /// <remarks>
        /// <br>Note       : 当月車検車両一覧テーブルスキーマクラスの初期化及びインスタンス生成を行う。</br>
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
        /// </remarks>
        public PMSYA02105EA()
        {
        }
        #endregion

        #region ■ Static Public Method
        #region ◆ 返品理由一覧DataSetテーブルスキーマ設定
        /// <summary>
        /// 当月車検車両一覧DataSetテーブルスキーマ設定
        /// </summary>
        /// <param name="ds">設定対象データテーブル</param>
        /// <remarks>
        /// <br>Note       : 当月車検車両一覧データセットのスキーマを設定する。</br>
        /// <br>Programmer : 薛祺</br>
        /// <br>Date       : 2010.04.21</br>
        /// <br>Update Note: 2010/05/10 王海立 車種と得意先コードの帳票の印字</br>
        /// </remarks>
        static public void CreateDataTable(ref DataSet ds)
        {
            if (ds == null)
                ds = new DataSet();

            // テーブルが存在するかどうかのチェック
            if (ds.Tables.Contains(ct_Tbl_MonthCarInspectListReportData))
            {
                // テーブルが存在するときはクリアーするのみ。スキーマをもう一度設定するようなことはしない。
                ds.Tables[ct_Tbl_MonthCarInspectListReportData].Clear();
            }
            else
            {
                // スキーマ設定
                ds.Tables.Add(ct_Tbl_MonthCarInspectListReportData);

                DataTable dt = ds.Tables[ct_Tbl_MonthCarInspectListReportData];

                // 得意先略称
                dt.Columns.Add(ct_Col_CustomerSnm, typeof(string));
                dt.Columns[ct_Col_CustomerSnm].DefaultValue = string.Empty;
                // 管理拠点コード
                dt.Columns.Add(ct_Col_MngSectionCode, typeof(string));
                dt.Columns[ct_Col_MngSectionCode].DefaultValue = string.Empty;
                // 企業コード
                dt.Columns.Add(ct_Col_EnterpriseCode, typeof(string));
                dt.Columns[ct_Col_EnterpriseCode].DefaultValue = string.Empty;
                // 論理削除区分
                dt.Columns.Add(ct_Col_LogicalDeleteCode, typeof(Int32));
                dt.Columns[ct_Col_LogicalDeleteCode].DefaultValue = 0;
                // 得意先コード
                // --- UPD 2010/05/10 ---------->>>>>
                //dt.Columns.Add(ct_Col_CustomerCode, typeof(Int32));
                dt.Columns.Add(ct_Col_CustomerCode, typeof(string));
                // --- UPD 2010/05/10 ----------<<<<<
                dt.Columns[ct_Col_CustomerCode].DefaultValue = 0;
                // 車両管理番号
                dt.Columns.Add(ct_Col_CarMngNo, typeof(Int32));
                dt.Columns[ct_Col_CarMngNo].DefaultValue = 0;
                // 車輌管理コード
                dt.Columns.Add(ct_Col_CarMngCode, typeof(string));
                dt.Columns[ct_Col_CarMngCode].DefaultValue = string.Empty;
                // 登録番号
                dt.Columns.Add(ct_Col_NumberPlate, typeof(string));
                dt.Columns[ct_Col_NumberPlate].DefaultValue = string.Empty;
                // 初年度
                dt.Columns.Add(ct_Col_FirstEntryDate, typeof(string));
                dt.Columns[ct_Col_FirstEntryDate].DefaultValue = string.Empty;
                // 車種コード
                dt.Columns.Add(ct_Col_ModelCode, typeof(string));
                dt.Columns[ct_Col_ModelCode].DefaultValue = string.Empty;
                // 車種半角名称
                dt.Columns.Add(ct_Col_ModelHalfName, typeof(string));
                dt.Columns[ct_Col_ModelHalfName].DefaultValue = string.Empty;
                // 型式（フル型）
                dt.Columns.Add(ct_Col_FullModel, typeof(string));
                dt.Columns[ct_Col_FullModel].DefaultValue = string.Empty;
                // 車台番号
                dt.Columns.Add(ct_Col_FrameNo, typeof(string));
                dt.Columns[ct_Col_FrameNo].DefaultValue = string.Empty;
                // 車検満期日
                dt.Columns.Add(ct_Col_InspectMaturityDate, typeof(string));
                dt.Columns[ct_Col_InspectMaturityDate].DefaultValue = string.Empty;
                // 車検期間
                dt.Columns.Add(ct_Col_CarInspectYear, typeof(Int32));
                dt.Columns[ct_Col_CarInspectYear].DefaultValue = 0;
                // Row
                dt.Columns.Add(ct_Col_Row, typeof(Int32));
                dt.Columns[ct_Col_Row].DefaultValue = 1;
                // Group
                dt.Columns.Add(ct_Col_Group, typeof(string));
                dt.Columns[ct_Col_Group].DefaultValue = string.Empty;
            }
        }
        #endregion
        #endregion
    }
}