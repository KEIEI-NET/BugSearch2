using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.UIData;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Controller;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 印刷用データ生成クラス
    /// </summary>
    /// <remarks>
    /// <br>Note		: 自由帳票抽出条件クラスを元に印刷用抽出条件文字列を生成します</br>
    /// <br>            : 自由帳票ソート順位マスタを元にソート用文字列を生成します</br>
    /// <br>Programmer	: 22011 柏原 頼人</br>
    /// <br>Date		: 2007.07.03</br>
    /// <br>UpdateNote	: 2007.12.12 22011 Kashihara 伝票番号をゼロ埋めにするロジックを追加</br>
    /// </remarks>
    public class SFANL08235CC : SFANL08235CA
    {
        #region private const
        // -- 抽出条件区分 ------------------------
        /// <summary>抽出条件区分：使用不可</summary>
        private const Int32 CT_EXTCNDDIV_NUSE = 0;
        /// <summary>抽出条件区分：数値型</summary>
        private const Int32 CT_EXTCNDDIV_NMRC = 1;
        /// <summary>抽出条件区分：文字列</summary>
        private const Int32 CT_EXTCNDDIV_STRG = 3;
        /// <summary>抽出条件区分：日付</summary>
        private const Int32 CT_EXTCNDDIV_DATE = 4;
        /// <summary>抽出条件区分：コンボボックス</summary>
        private const Int32 CT_EXTCNDDIV_CMBB = 5;
        /// <summary>抽出条件区分：チェックボックス</summary>
        private const Int32 CT_EXTCNDDIV_CHKB = 6;        
        #endregion

        #region public methods

        #region 抽出条件文字列作成
        /// <summary>
        /// 抽出条件文字列作成
        /// </summary>
        /// <param name="frePprECndList">自由帳票抽出条件クラスのリスト</param>
        /// <param name="frePExCndDList">自由帳票抽出条件明細クラスのリスト</param>
        /// <param name="frePrtDataSet">自由帳票印刷用データセット</param>
        /// <returns>ステータス 正常:0</returns>
        public int GeneratExtractionCnd(List<FrePprECnd> frePprECndList, List<FrePExCndD> frePExCndDList,ref DataSet frePrtDataSet)
        {
            // データテーブルの作成
            GenerateFrePprPrintExtr_DT(ref frePrtDataSet);
            // 自由帳票抽出条件
            if (frePprECndList != null)
            {
                foreach (FrePprECnd frePprEcnd in frePprECndList)
                {
                    // 条件区分が使用不可の場合はコンティニュー
                    if (frePprEcnd.ExtraConditionDivCd == CT_EXTCNDDIV_NUSE) continue;

                    String extCndStr = "";  // 抽出条件文字列

                    switch (frePprEcnd.ExtraConditionDivCd)
                    {
                        case CT_EXTCNDDIV_NMRC: //数値
                            {
                                //2007.12.12 ADD ----START
                                if (frePprEcnd.DDName.EndsWith("SLIPNORF", true, null))
                                {
                                    extCndStr = GetConditionStr_NumericRangeZeroPad(frePprEcnd.ExtraConditionTitle, frePprEcnd.StExtraNumCode, frePprEcnd.EdExtraNumCode, frePprEcnd.InputCharCnt, frePprEcnd.ExtraConditionTypeCd);
                                    break;
                                }
                                else
                                {
                                    extCndStr = GetConditionStr_NumericRange(frePprEcnd.ExtraConditionTitle, frePprEcnd.StExtraNumCode, frePprEcnd.EdExtraNumCode, frePprEcnd.InputCharCnt, frePprEcnd.ExtraConditionTypeCd);
                                    break;
                                }
                                //extCndStr = GetConditionStr_NumericRange(frePprEcnd.ExtraConditionTitle, frePprEcnd.StExtraNumCode, frePprEcnd.EdExtraNumCode, frePprEcnd.InputCharCnt);
                                //break;
                                //2007.12.12 ADD ----END
                            }
                        case CT_EXTCNDDIV_STRG: //文字型
                            {
                                extCndStr = GetConditionStr_StringRange(frePprEcnd.ExtraConditionTitle, frePprEcnd.StExtraCharCode, frePprEcnd.EdExtraCharCode, frePprEcnd.ExtraConditionTypeCd);
                                break;
                            }
                        case CT_EXTCNDDIV_DATE: //日付型
                            {
                                DateTime strDate = new DateTime();
                                DateTime endDate = new DateTime();
                                // DateTime導出
                                FrePprEcndToDateTime(frePprEcnd, ref strDate, ref endDate);
                                extCndStr = GetConditionStr_DateRange(frePprEcnd.ExtraConditionTitle, strDate, endDate, frePprEcnd.ExtraConditionTypeCd);
                                break;
                            }
                        case
                            CT_EXTCNDDIV_CMBB: //コンボボックス
                            {
                                extCndStr = (frePprEcnd.ExtraConditionTitle + "： " + GetDtlTitle(frePprEcnd.ExtraCondDetailGrpCd, (int)frePprEcnd.StExtraNumCode, frePExCndDList));
                                break;
                            }
                        case
                            CT_EXTCNDDIV_CHKB: //チェックボックス
                            {
                                extCndStr = GetConditionStr_CheckBoxChecked(frePprEcnd, frePExCndDList);
                                break;
                            }
                    }

                    //データテーブルに追加
                    if (extCndStr == string.Empty) continue;
                    DataRow dr = frePrtDataSet.Tables[CT_FREPPRPRINT_EXTR_DT].NewRow();
                    dr[CT_EXTRACTCONDS] = extCndStr;
                    frePrtDataSet.Tables[CT_FREPPRPRINT_EXTR_DT].Rows.Add(dr);
                }
            }
            return 0;
        }

        /// <summary>
        /// 抽出条件文字列作成
        /// </summary>
        /// <param name="extCondStrList">抽出条件文字列のリスト</param>
        /// <param name="frePrtDataSet"></param>
        /// <returns>ステータス 正常:0</returns>
        public int GeneratExtractionCnd(List<string> extCondStrList, ref DataSet frePrtDataSet)
        {
            // データテーブルの作成
            GenerateFrePprPrintExtr_DT(ref frePrtDataSet);
            // 自由帳票抽出条件
            if (extCondStrList != null)
            {
                foreach (string extCndStr in extCondStrList)
                {
                    //データテーブルに追加
                    DataRow dr = frePrtDataSet.Tables[CT_FREPPRPRINT_EXTR_DT].NewRow();
                    dr[CT_EXTRACTCONDS] = extCndStr;
                    frePrtDataSet.Tables[CT_FREPPRPRINT_EXTR_DT].Rows.Add(dr);
                }
            }
            return 0;
        }
        #endregion

        #region ソート用文字列作成
        /// <summary>
        /// DataTableのソート用文字列を作成します(印刷用データテーブル及び値も作成します)
        /// </summary>
        /// <param name="frePprSrtOLs">自由帳票ソート順位</param>
        /// <param name="sortOder">ソート順位用の文字列</param>
        /// <param name="frePrtDataSet">自由帳票印刷用データセット</param>
        /// <returns>ステータス</returns>
        public int GeneratSortOrderStr(List<FrePprSrtO> frePprSrtOLs, out string sortOder, ref DataSet frePrtDataSet)
        {
            sortOder = "";
            StringBuilder sb = new StringBuilder();
            int count = 0;
            
            // データテーブルの作成
            GenerateFrePprPrintSrtO_DT(ref frePrtDataSet);

            try
            {
                // ソート順位マスタからソート用文字列を作成
                if (frePprSrtOLs != null)
                {
                    foreach (FrePprSrtO frePprSrt in frePprSrtOLs)
                    {
                        //区分が「使用しない」の場合コンティニュー
                        if (frePprSrt.SortingOrderDivCd == 0)
                        {
                            continue;
                        }

                        count++;

                        if (!string.IsNullOrEmpty(frePprSrt.FileNm) && !string.IsNullOrEmpty(frePprSrt.DDName))
                        {
                            if(sb.Length != 0) sb.Append(", ");
                            sb.Append(frePprSrt.FileNm + "." + frePprSrt.DDName);
                        }
                        else if (!string.IsNullOrEmpty(frePprSrt.FileNm))
                        {
                            if (sb.Length != 0) sb.Append(", ");
                            sb.Append(frePprSrt.FileNm);
                        }
                        else if (!string.IsNullOrEmpty(frePprSrt.DDName))
                        {
                            if (sb.Length != 0) sb.Append(", ");
                            sb.Append(frePprSrt.DDName);
                        }
                        else
                            continue;

                        if (frePprSrt.SortingOrderDivCd == 1)
                        {
                            sb.Append(" ASC");
                        }
                        else if (frePprSrt.SortingOrderDivCd == 2)
                        {
                            sb.Append(" DESC");
                        }


                        if (count <= 5)
                        {
                            //データテーブルに追加
                            DataRow dr = frePrtDataSet.Tables[CT_FREPPRPRINT_SRTO_DT].Rows[0];
                            dr[CT_SORTODER + count.ToString()] = frePprSrt.FreePrtPaperItemNm + "順";
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }

            sortOder = sb.ToString();
            return 0;
        }

        /// <summary>
        /// DataTableのソート用文字列を作成します(印刷用データテーブル及び値も作成します)
        /// </summary>
        /// <param name="SrtOdrStrLs">自由帳票ソート順位</param>
        /// <param name="frePrtDataSet">自由帳票印刷用データセット</param>
        /// <returns>ステータス</returns>
        public int GeneratSortOrderStr(List<string> SrtOdrStrLs, ref DataSet frePrtDataSet)
        {
            int count = 0;

            // データテーブルの作成
            GenerateFrePprPrintSrtO_DT(ref frePrtDataSet);

            try
            {
                // ソート順位マスタからソート用文字列を作成
                if (SrtOdrStrLs != null)
                {
                    foreach (string frePprSrt in SrtOdrStrLs)
                    {
                        count++;
                        if (count <= 5)
                        {
                            //データテーブルに追加
                            DataRow dr = frePrtDataSet.Tables[CT_FREPPRPRINT_SRTO_DT].Rows[0];
                            dr[CT_SORTODER + count.ToString()] = frePprSrt;
                        }
                    }
                }
            }
            catch
            {
                return -1;
            }
            return 0;
        }
        #endregion

        #region レポートフッタデータ作成
        /// <summary>
        /// DataTableのソート用文字列を作成します(印刷用データテーブル及び値も作成します)
        /// </summary>
        /// <param name="frePrtDataSet">自由帳票印刷用データセット</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ステータス</returns>
        public int GeneratPrintRepFooter(ref DataSet frePrtDataSet, out string message)
        {
            int status = 0;
            PrtOutSet prtoutset = null;

            // データテーブルの作成
            GenerateFrePprPrintPFtr_DT(ref frePrtDataSet);
            status = ReadPrtOutSet(out prtoutset,out message);

            //データテーブルに追加
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                DataRow dr = frePrtDataSet.Tables[CT_FREPPRPRINT_PFTR_DT].NewRow();
                if (prtoutset.FooterPrintOutCode == 0)
                {
                    dr[CT_PRINTFOOTER1] = prtoutset.PrintFooter1;
                    dr[CT_PRINTFOOTER2] = prtoutset.PrintFooter2;
                }
                frePrtDataSet.Tables[CT_FREPPRPRINT_PFTR_DT].Rows.Add(dr);
            }

            return status;
        }

        #endregion

        #region 印刷メインデータテーブル再構築
        /// <summary>
        /// 印刷メインデータテーブル再構築処理(DefaultViewの内容でDataTableを再構築)
        /// </summary>
        /// <param name="printDataSet"></param>
        public void MainDataTableReConstruction(ref DataSet printDataSet)
        {
            DataTable bufDT = new DataTable();
            bufDT = printDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_MAIN_DT].Clone();
            bufDT.Clear();

            foreach (DataRowView drv in printDataSet.Tables[SFANL08235CD.CT_FREPPRPRINT_MAIN_DT].DefaultView)
            {
                bufDT.ImportRow(drv.Row);
            }
            printDataSet.Tables.Remove(SFANL08235CD.CT_FREPPRPRINT_MAIN_DT);
            printDataSet.Tables.Add(bufDT);            
        }
        #endregion

        #endregion

        #region private methods

        #region 抽出範囲文字列作成(string)
        /// <summary>
		/// 抽出範囲文字列作成(string)
		/// </summary>
		/// <returns>作成文字列</returns>
        private string GetConditionStr_StringRange(string title, string startString, string endString, int extraConditionTypeCd)
		{
			string result = string.Empty;
			if ((startString != "") || (endString != ""))
			{
                if ((startString != null) || (endString != null))
                {
                    string start = "ＴＯＰ";
                    string end = "ＥＮＤ";
                    if (startString != "") start = startString;
                    if (endString != "") end = endString;
                    if (startString != "" || endString != "")
                    {
                        //一致か曖昧のときはスタート文字だけ
                        if ((extraConditionTypeCd == 0) || (extraConditionTypeCd == 2))
                            result = title + "： "+ start;
                        else
                            result = String.Format(title + "： {0} ～ {1}", start, end);
                    }
                }
			}
			return result;
        }
        #endregion

        #region 抽出範囲文字列作成(数値ゼロ埋め)
        //2007.12.12 ADD ----START
        /// <summary>
        /// 抽出範囲文字列作成(数値ゼロ埋め)
        /// </summary>
        /// <returns>作成文字列</returns>
        private string GetConditionStr_NumericRangeZeroPad(string title, Int64 startInt, Int64 endInt, int inputCharCnt, int extraConditionTypeCd)
        {
            string start = string.Empty;
            string end = string.Empty;
            double maxValue = 0;
            // 最大値を取得
            maxValue = (Math.Pow(10, inputCharCnt) - 1);


            if (startInt != 0)
                start = TStrUtils.PadZeroLeft(startInt.ToString(), inputCharCnt);
            if ((endInt != 0) && (endInt != maxValue))
                end = TStrUtils.PadZeroLeft(endInt.ToString(), inputCharCnt);

            string rengeStr = GetConditionStr_StringRange(title, start, end, extraConditionTypeCd);
            if (rengeStr != "")
                return (rengeStr);
            else
                return string.Empty;
        }
        //2007.12.12 ADD ----END
        #endregion

        #region 抽出範囲文字列作成(数値)
        /// <summary>
		/// 抽出範囲文字列作成(数値)
		/// </summary>
		/// <returns>作成文字列</returns>
        private string GetConditionStr_NumericRange(string title, Int64 startInt, Int64 endInt, int inputCharCnt, int extraConditionTypeCd)
		{
            string rengeStr = EditCodeRange(startInt, endInt, inputCharCnt, extraConditionTypeCd);
            if (rengeStr != "")
                return (title + "： " + rengeStr);
            else
                return string.Empty;
        }
        #endregion

        #region 抽出範囲文字列作成(日付)
        /// <summary>
		/// 抽出範囲文字列作成(日付)
		/// </summary>
		/// <returns>作成文字列</returns>
        private string GetConditionStr_DateRange(string title, DateTime startDateTime, DateTime endDateTime, int extraConditionTypeCd)
		{
            string result = "";
            int status;
            // 対象期間
            int yy = 0;
            int mm = 0;
            int dd = 0;
            string strGengo = "";

            if ((startDateTime == DateTime.MinValue) && (endDateTime == DateTime.MinValue))
                return result;
            
            //開始対象年月日
            if (startDateTime == DateTime.MinValue)
            {
                result = title + "： ＴＯＰ";
            }
            else
            {
                status = TDateTime.SplitDate("GGYYMMDD", startDateTime,
                    ref strGengo,
                    ref yy,
                    ref mm,
                    ref dd);
                if (status == 0)
                {
                    result = String.Format(title + "： {0}{1,2}年{2,2}月{3,2}日", strGengo, yy, mm, dd);
                }
            }

            //条件タイプが一致、月一致の時はスタート条件のみ
            if ((extraConditionTypeCd == 0) || (extraConditionTypeCd == 5))
                return result;

            //終了対象年月日
            if (endDateTime == DateTime.MinValue)
            {
                result += " ～ ＥＮＤ";
            }
            else
            {
                status = TDateTime.SplitDate("GGYYMMDD", endDateTime,
                    ref strGengo,
                    ref yy,
                    ref mm,
                    ref dd);
                if (status == 0)
                {
                    result += String.Format(" ～ {0}{1,2}年{2,2}月{3,2}日", strGengo, yy, mm, dd);
                }
            }
			return result;
        }
        #endregion

        #region 抽出文字列作成(チェックボックス)
        /// <summary>
		/// 抽出範囲文字列作成(チェックボックス)
		/// </summary>
		/// <returns>作成文字列</returns>
        private string GetConditionStr_CheckBoxChecked(FrePprECnd frePprECnd, List<FrePExCndD> frePExCndDLs)
        {
            StringBuilder result = new StringBuilder();
            Boolean dotFlg = false;        // '・'追加のフラグ(true:追加必要)
            int selectCnt = 0;             // チェックされている件数
            int detailCnt = 0;             // 有効な明細の数

            detailCnt = (frePExCndDLs.FindAll(delegate(FrePExCndD frePExCndD)
                        {
                            if ((frePExCndD.ExtraCondDetailCode != -1) && (frePExCndD.ExtraCondDetailGrpCd == frePprECnd.ExtraCondDetailGrpCd))
                            { return true; }
                            else
                            {
                                return false;
                            }
                         })).Count;

            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode1, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode2, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode3, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode4, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode5, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode6, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode7, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode8, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode9, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);
            AppendCheckedTitle(frePprECnd.ExtraCondDetailGrpCd, frePprECnd.CheckItemCode10, frePExCndDLs, ref result, ref dotFlg, ref selectCnt);

            //有効な明細数とチェック数が同じときは全件抽出なので印字しない
            if ((result.Length != 0) && (detailCnt != selectCnt))
                return frePprECnd.ExtraConditionTitle + "： " + result.ToString();
            else
                return string.Empty;
        }

        /// <summary>
        /// 抽出条件明細取得
        /// </summary>
        /// <param name="groupCd"></param>
        /// <param name="checkItemCode"></param>
        /// <param name="frePExCndDLs"></param>
        /// <param name="sb"></param>
        /// <param name="dotFlg"></param>
        /// <param name="selectCnt"></param>
        private void AppendCheckedTitle(int groupCd, int checkItemCode, List<FrePExCndD> frePExCndDLs, ref StringBuilder sb, ref bool dotFlg, ref int selectCnt)
        {
            if (checkItemCode == -1)
            {
                return;
            }

            string title = string.Empty;
            title = GetDtlTitle(groupCd, checkItemCode, frePExCndDLs);
            if (title != string.Empty)
            {
                selectCnt++;
                if (dotFlg)
                {
                    sb.Append("･");
                }
                sb.Append(title);
                dotFlg = true;
            }
        }
        #endregion

        #region 抽出条件文字列編集
        /// <summary>
        /// 抽出条件文字列編集(コードの範囲)
        /// </summary>
        private string EditCodeRange(Int64 startCd, Int64 endCd, int inputCharCnt, int extraConditionTypeCd)
        {
            string startValue = string.Empty;
            string endValue = string.Empty;
            double maxValue = 0;
            // 最大値を取得
            maxValue = (Math.Pow(10, inputCharCnt) - 1);

            if (startCd == 0)
                startValue = "ＴＯＰ";
            else
                startValue = startCd.ToString();

            if ((endCd == 0) || (endCd == maxValue))
                endValue = "ＥＮＤ";
            else
                endValue = endCd.ToString();

            if (startCd != 0 || endCd != 0)
            {
                //条件タイプが一致のときはスタートのみ
                if (extraConditionTypeCd == 0)
                    return startValue.ToString();
                else
                    return String.Format("{0} ～ {1}", startValue, endValue);
            }
            else
                return string.Empty;
        }

        /// <summary>
        /// 自由帳票抽出条件明細から指定されたコードの名称を取得します
        /// </summary>
        /// <param name="groupCd">抽出条件グループコード</param>
        /// <param name="detailCd">抽出条件明細コード</param>
        /// <param name="frePExCndDLs"></param>
        /// <returns></returns>
        private string GetDtlTitle(int groupCd, int detailCd, List<FrePExCndD> frePExCndDLs)
        {
            string result = string.Empty;
            if (frePExCndDLs != null)
            {
                FrePExCndD exCndD = null;
                exCndD = frePExCndDLs.Find(delegate(FrePExCndD frePExCndD)
                         {
                             if ((frePExCndD.ExtraCondDetailCode == detailCd) && (frePExCndD.ExtraCondDetailGrpCd == groupCd))
                                 return true;
                             else
                                 return false;
                         });

                if (exCndD != null)
                    result = exCndD.ExtraCondDetailName;
            }
            return result;
        }
        #endregion

        #region 抽出条件クラス→DateTime導出
        /// <summary>
        /// 抽出条件クラスからDateTimeを生成します
        /// </summary>
        /// <param name="frePprECnd">自由帳票抽出条件</param>
        /// <param name="startDateTime">開始日付</param>
        /// <param name="endDateTime">終了日付</param>
        /// <returns>ステータス： 正常:0</returns>
        private int FrePprEcndToDateTime(FrePprECnd frePprECnd, ref DateTime startDateTime, ref DateTime endDateTime)
        {
            //条件区分が日付でなければ終了
            if (frePprECnd.ExtraConditionDivCd != CT_EXTCNDDIV_DATE)
            {
                return -1;
            }
           
            try
            {
                // 開始日付
                startDateTime = TDateTime.LongDateToDateTime(frePprECnd.StartExtraDate);
                // 終了日付
                endDateTime = TDateTime.LongDateToDateTime(frePprECnd.EndExtraDate);
                return 0;
            }
            catch
            {
                return -1;
            }
        }
        #endregion

        #region 帳票出力設定読込
        /// <summary>
        /// 帳票出力設定読込
        /// </summary>
        /// <param name="prtOutSet">帳票出力設定データクラス</param>
        /// <param name="message">エラーメッセージ</param>
        /// <returns>ConstantManagement.DB_Status</returns>
        private int ReadPrtOutSet(out PrtOutSet prtOutSet, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            prtOutSet = null;
            message = "";
            PrtOutSetAcs prtOutSetAcs = new PrtOutSetAcs();
            string mySectionCode = "";

            try
            {
                // ログイン拠点取得
                Employee loginEmployee = LoginInfoAcquisition.Employee.Clone();
                if (loginEmployee != null)
                {
                    mySectionCode = loginEmployee.BelongSectionCode;
                }

                status = prtOutSetAcs.Read(out prtOutSet, LoginInfoAcquisition.EnterpriseCode, mySectionCode);
                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        prtOutSet = new PrtOutSet();
                        break;
                    default:
                        prtOutSet = new PrtOutSet();
                        message = "帳票出力設定の読込に失敗しました。";
                        break;
                }
            }
            catch (Exception ex)
            {
                status = -1;
                message = ex.Message;
            }
            return status;
        }
        #endregion

        #endregion
    }
}
