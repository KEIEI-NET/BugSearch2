using System;
using System.Data;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 締日算出モジュール／データクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 締日算出モジュールで使用するデータスキーマクラスです。</br>
    /// <br>Programmer : 22018 鈴木 正臣</br>
    /// <br>Date       : 2008.07.31</br>
    /// <br></br>
    /// </remarks>
    public class PMCMN00101EA
    {
        # region [public const]
        /// <summary> 処理区分 </summary>
        public const string ct_Col_ProcDiv = "ProcDiv";
        /// <summary> 拠点コード </summary>
        public const string ct_Col_SectionCode = "SectionCode";
        /// <summary> 得意先コード </summary>
        public const string ct_Col_CustomerCode = "CustomerCode";
        /// <summary> 仕入先コード </summary>
        public const string ct_Col_SupplierCd = "SupplierCd";
        /// <summary> 前回締処理日 </summary>
        public const string ct_Col_PrevTotalDay = "PrevTotalDay";
        /// <summary> 今回締処理日 </summary>
        public const string ct_Col_CurrentTotalDay = "CurrentTotalDay";
        /// <summary> 前回締処理月 </summary>
        public const string ct_Col_PrevTotalMonth = "PrevTotalMonth";
        /// <summary> 今回締処理月 </summary>
        public const string ct_Col_CurrentTotalMonth = "CurrentTotalMonth";
        /// <summary> リモート処理済フラグ </summary>
        public const string ct_Col_RemotedFlag = "RemotedFlag";
        /// <summary> 今回締処理算出済フラグ </summary>
        public const string ct_Col_CurrentCalcFlag = "CurrentCalcFlag";
        /// <summary> コンバート処理区分 </summary>
        public const string ct_Col_ConvertProcessDivCd = "ConvertProcessDivCd";
        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
        /// <summary> 締次更新開始年月日 </summary>
        public const string ct_Col_StartCAddUpUpdDate = "StartCAddUpUpdDate";
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD

        /// <summary>
        /// 処理区分　請求売掛
        /// </summary>
        public const Int32 ct_ProcDiv_AccRec = 0;
        /// <summary>
        /// 処理区分　支払買掛
        /// </summary>
        public const Int32 ct_ProcDiv_AccPay = 1;

        # endregion

        # region [private const]
        /// <summary>Int32初期値</summary>
        private const Int32 defaultValueOfInt32 = 0;
        /// <summary>String初期値</summary>
        private const String defaultValueOfstring = "";
        # endregion

        # region [テーブル生成]
        /// <summary>
        /// 履歴月次テーブル生成
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfHisMonthly()
        {
            DataTable dt = new DataTable();

            # region [列定義]
            // 処理区分
            dt.Columns.Add( ct_Col_ProcDiv, typeof( Int32 ) );
            dt.Columns[ct_Col_ProcDiv].DefaultValue = defaultValueOfInt32;
            // 拠点コード
            dt.Columns.Add( ct_Col_SectionCode, typeof( string ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // 前回締処理日
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // 今回締処理日
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // 前回締処理月
            dt.Columns.Add( ct_Col_PrevTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalMonth].DefaultValue = DateTime.MinValue;
            // 今回締処理月
            dt.Columns.Add( ct_Col_CurrentTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalMonth].DefaultValue = DateTime.MinValue;
            // コンバート処理区分
            dt.Columns.Add( ct_Col_ConvertProcessDivCd, typeof( Int32 ) );
            dt.Columns[ct_Col_ConvertProcessDivCd].DefaultValue = defaultValueOfInt32;
            // リモート処理済フラグ
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // 今回締処理算出済フラグ
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // 締次更新開始年月日
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // プライマリキー設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_ProcDiv], dt.Columns[ct_Col_SectionCode] };

            return dt;
        }
        /// <summary>
        /// 金額月次売掛テーブル生成
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfPrcAccRec()
        {
            DataTable dt = new DataTable();

            # region [列定義]
            // 拠点コード
            dt.Columns.Add( ct_Col_SectionCode, typeof( String ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // 得意先コード
            dt.Columns.Add( ct_Col_CustomerCode, typeof( Int32 ) );
            dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfInt32;
            // 前回締処理日
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // 今回締処理日
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // 前回締処理月
            dt.Columns.Add( ct_Col_PrevTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalMonth].DefaultValue = DateTime.MinValue;
            // 今回締処理月
            dt.Columns.Add( ct_Col_CurrentTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalMonth].DefaultValue = DateTime.MinValue;
            // リモート処理済フラグ
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // 今回締処理算出済フラグ
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // 締次更新開始年月日
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // プライマリキー設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode], dt.Columns[ct_Col_CustomerCode] };

            return dt;
        }
        /// <summary>
        /// 金額月次買掛テーブル生成
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfPrcAccPay()
        {
            DataTable dt = new DataTable();

            # region [列定義]
            // 拠点コード
            dt.Columns.Add( ct_Col_SectionCode, typeof( String ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // 仕入先コード
            dt.Columns.Add( ct_Col_SupplierCd, typeof( Int32 ) );
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defaultValueOfInt32;
            // 前回締処理日
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // 今回締処理日
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // 前回締処理月
            dt.Columns.Add( ct_Col_PrevTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalMonth].DefaultValue = DateTime.MinValue;
            // 今回締処理月
            dt.Columns.Add( ct_Col_CurrentTotalMonth, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalMonth].DefaultValue = DateTime.MinValue;
            // リモート処理済フラグ
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // 今回締処理算出済フラグ
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // 締次更新開始年月日
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // プライマリキー設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode], dt.Columns[ct_Col_SupplierCd] };

            return dt;
        }
        /// <summary>
        /// 履歴請求テーブル生成
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfHisDmdC()
        {
            DataTable dt = new DataTable();

            # region [列定義]
            // 拠点コード
            dt.Columns.Add( ct_Col_SectionCode, typeof( string ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // 前回締処理日
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // 今回締処理日
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // コンバート処理区分
            dt.Columns.Add( ct_Col_ConvertProcessDivCd, typeof( Int32 ) );
            dt.Columns[ct_Col_ConvertProcessDivCd].DefaultValue = defaultValueOfInt32;
            // リモート処理済フラグ
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // 今回締処理算出済フラグ
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // 締次更新開始年月日
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // プライマリキー設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode] };

            return dt;
        }
        /// <summary>
        /// 履歴支払テーブル生成
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfHisPayment()
        {
            DataTable dt = new DataTable();

            # region [列定義]
            // 拠点コード
            dt.Columns.Add( ct_Col_SectionCode, typeof( string ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // 前回締処理日
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // 今回締処理日
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // コンバート処理区分
            dt.Columns.Add( ct_Col_ConvertProcessDivCd, typeof( Int32 ) );
            dt.Columns[ct_Col_ConvertProcessDivCd].DefaultValue = defaultValueOfInt32;
            // リモート処理済フラグ
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // 今回締処理算出済フラグ
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // 締次更新開始年月日
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // プライマリキー設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode] };

            return dt;
        }
        /// <summary>
        /// 金額請求テーブル生成
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfPrcDmdC()
        {
            DataTable dt = new DataTable();

            # region [列定義]
            // 拠点コード
            dt.Columns.Add( ct_Col_SectionCode, typeof( String ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // 得意先コード
            dt.Columns.Add( ct_Col_CustomerCode, typeof( Int32 ) );
            dt.Columns[ct_Col_CustomerCode].DefaultValue = defaultValueOfInt32;
            // 前回締処理日
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // 今回締処理日
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // リモート処理済フラグ
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // 今回締処理算出済フラグ
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // 締次更新開始年月日
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // プライマリキー設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode], dt.Columns[ct_Col_CustomerCode] };

            return dt;
        }
        /// <summary>
        /// 金額支払テーブル生成
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableOfPrcPayment()
        {
            DataTable dt = new DataTable();

            # region [列定義]
            // 拠点コード
            dt.Columns.Add( ct_Col_SectionCode, typeof( String ) );
            dt.Columns[ct_Col_SectionCode].DefaultValue = defaultValueOfstring;
            // 仕入先コード
            dt.Columns.Add( ct_Col_SupplierCd, typeof( Int32 ) );
            dt.Columns[ct_Col_SupplierCd].DefaultValue = defaultValueOfInt32;
            // 前回締処理日
            dt.Columns.Add( ct_Col_PrevTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_PrevTotalDay].DefaultValue = DateTime.MinValue;
            // 今回締処理日
            dt.Columns.Add( ct_Col_CurrentTotalDay, typeof( DateTime ) );
            dt.Columns[ct_Col_CurrentTotalDay].DefaultValue = DateTime.MinValue;
            // リモート処理済フラグ
            dt.Columns.Add( ct_Col_RemotedFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_RemotedFlag].DefaultValue = defaultValueOfInt32;
            // 今回締処理算出済フラグ
            dt.Columns.Add( ct_Col_CurrentCalcFlag, typeof( Int32 ) );
            dt.Columns[ct_Col_CurrentCalcFlag].DefaultValue = defaultValueOfInt32;
            // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/05/14 ADD
            // 締次更新開始年月日
            dt.Columns.Add( ct_Col_StartCAddUpUpdDate, typeof( DateTime ) );
            dt.Columns[ct_Col_StartCAddUpUpdDate].DefaultValue = DateTime.MinValue;
            // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/05/14 ADD
            # endregion

            // プライマリキー設定
            dt.PrimaryKey = new DataColumn[] { dt.Columns[ct_Col_SectionCode], dt.Columns[ct_Col_SupplierCd] };

            return dt;
        }
        # endregion
    }
}
