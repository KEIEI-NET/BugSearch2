using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

using Broadleaf.Application.UIData;
//using Broadleaf.Application.UIData.UserDB;

#if DEBUG
//using SCMAcOdrData = Broadleaf.Application.UIData.StubDB.SCMAcOdrData;
//using SCMAcOdrDtlIq = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlIq;
//using SCMAcOdrDtlAs = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtlAs;
//using SCMAcOdrDtCar = Broadleaf.Application.UIData.StubDB.SCMAcOdrDtCar;
using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;

#else
using SCMAcOdrData = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDataWork;
using SCMAcOdrDtlIq = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlIqWork;
using SCMAcOdrDtlAs = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtlAsWork;
using SCMAcOdrDtCar = Broadleaf.Application.Remoting.ParamData.SCMAcOdrDtCarWork;
#endif

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// 旧システム連携用CSVファイル出力クラス
    /// </summary>
    public static class CSVWriter
    {
        #region private定数
        private const string CT_HeaderFileName  = "ScmOdrDataCSV";  // "SCM受注データ.csv";
        private const string CT_CarFileName = "ScmOdDtCarCSV";      // "SCM受注データ（車両情報）.csv";
        private const string CT_DetailFileName  = "ScmOdDtInqCSV";  // "SCM受注明細データ（問合せ・発注）.csv";
        #endregion

        /// <summary>
        /// CSV出力処理
        /// </summary>
        /// <param name="pMsg"></param>
        public static int CSVWrite(string enterPriseCd, string oldSysCoopFolder,
            List<List<string>> headerList, List<List<string>> detailList, List<List<string>> carList)
        {
            if (headerList == null
                || headerList.Count == 0)
            {
                return (int)Result.Code.Normal;
            }

            if (oldSysCoopFolder == string.Empty)
            {
                LogWriter.LogWrite("旧システム連携フォルダが設定されていません。");
                return (int)Result.Code.Error;
            }
            else
            {
                // 受信用フォルダパスを設定
                oldSysCoopFolder = SCMConfig.GetSCMReceivedDataPath(oldSysCoopFolder);
            }

            // CSV出力先を補正
            if (!oldSysCoopFolder.EndsWith("\\")
                && !oldSysCoopFolder.EndsWith("/"))
            {
                oldSysCoopFolder += "\\";
            }
            LogWriter.WriteDebugLog("CSVWriter.CSVWrite()", "CSV出力処理中..." + oldSysCoopFolder);

            // ファイル名作成 (企業コード + 時間)
            string fileNameWithExtension = enterPriseCd
                            + "_"
                            + DateTime.Now.ToString("yyyyMMddHHmmss")
                            //+ "_";
                            +".csv";

            try
            {
                // CSV出力
                LogWriter.WriteDebugLog("CSVWriter.CSVWrite()", "ヘッダ出力処理中..." + headerList.Count.ToString() + " 件");
                OutputCSVFile(oldSysCoopFolder, CT_HeaderFileName + "_" + fileNameWithExtension, headerList);

                LogWriter.WriteDebugLog("CSVWriter.CSVWrite()", "明細出力処理中..." + detailList.Count.ToString() + " 件");
                OutputCSVFile(oldSysCoopFolder, CT_DetailFileName + "_" + fileNameWithExtension, detailList);

                LogWriter.WriteDebugLog("CSVWriter.CSVWrite()", "車両出力処理中..." + carList.Count.ToString() + " 件");
                OutputCSVFile(oldSysCoopFolder, CT_CarFileName + "_" + fileNameWithExtension, carList);
            }
            catch(Exception e)
            {
                LogWriter.LogWrite("CSV出力処理でエラーが発生しました。");
                LogWriter.LogWrite(e.Message);

                return (int)Result.Code.Error;
            }

            return (int)Result.Code.Normal;
        }

        /// <summary>
        /// SCM受発注データ(問合せ・受注)のCSV出力処理
        /// </summary>
        /// <param name="oldSysCoopFolder"></param>
        /// <param name="baseFileName"></param>
        /// <param name="scmAcOdrDataList"></param>
        private static void OutputCSVFile(string oldSysCoopFolder, string baseFileName, List<List<string>> outputList)
        {
            FileStream _fs; // ファイルストリーム
            StreamWriter _sw; // ストリームwriter

            string filePath = oldSysCoopFolder + baseFileName;

            Directory.CreateDirectory(oldSysCoopFolder);
            _fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            _sw = new StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));

            try
            {
                // 1行データ
                StringBuilder outputStrSB = new StringBuilder();

                // 受注データの1行データ作成
                foreach (List<string> oneLineStr in outputList)
                {
                    //MakeSCMAcOdrDataStr(outputSCMAcOdrData, ref outputStrSB);
                    foreach (string oneColumn in oneLineStr)
                    {
                        AppendString(oneColumn, ref outputStrSB);
                    }

                    // 最後のダブルクォーテーションを設定
                    outputStrSB.Append(@"""");

                    _sw.WriteLine(outputStrSB.ToString());
                    outputStrSB.Length = 0;
                }
            }
            finally
            {
                if (_sw != null)
                    _sw.Close();
                if (_fs != null)
                    _fs.Close();
            }
        }

        /// <summary>
        /// 各データをダブルクォーテーションで囲む
        /// </summary>
        /// <param name="str"></param>
        /// <param name="strSB"></param>
        private static void AppendString(string str, ref StringBuilder strSB)
        {
            if (strSB.Length != 0)
            {
                strSB.Append(@"""");
                strSB.Append(",");
            }

            strSB.Append(@"""");
            strSB.Append(str);

        }
    }
}
