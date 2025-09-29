using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    class ProcClass
    {
        /// <summary> CSV読み込み用TextFieldParser </summary>
        private TextFieldParser _csvRead;
        /// <summary> CSV書き込み用StreamWriter </summary>
        private StreamWriter _csvWrite;
        /// <summary> ログ書き込み用StreamWriter </summary>
        private StreamWriter _logWrite;
        /// <summary> Shift_JISコード </summary>
        private static readonly Encoding encSJIS = Encoding.GetEncoding("Shift_JIS");

        #region -- Internal Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 各種ファイルの存在チェック
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal bool CheckFilePathsExists(PMKHN09951A_Common.CSVCheckToolPara param, out string msg)
        {
            #region
            msg = String.Empty;

            #region ---- メインファイルパスのチェック ----
            if ((param.MainFilePath == null) || (param.MainFilePath.Length <= 0))
            {
                msg = param.MainFileDispName + "ファイルを選択してください。";
                return false;
            }

            if (!this.CheckExists(1, param.MainFilePath))
            {
                msg = param.MainFileDispName + "で選択されたCSVファイルが存在しません。";
                return false;
            }

            if (!this.CheckExists(3, param.MainFilePath))
            {
                msg = param.MainFileDispName + "でCSVファイル以外が選択されています。\r\nCSVファイルを選択してください。";
                return false;
            }
            #endregion

            #region ---- サブファイルパスのチェック ----
            if ((param.SubFilePathList == null) || (param.SubFilePathList.Count <= 0))
            {
                msg = "比較サブファイルを選択してください。";
                return false;
            }

            foreach (string key in param.SubFilePathList.Keys)
            {
                if (!this.CheckExists(1, param.SubFilePathList[key]))
                {
                    msg = key + "で選択されたCSVファイルが存在しません。";
                    return false;
                }
            }

            foreach (string key in param.SubFilePathList.Keys)
            {
                if (!this.CheckExists(3, param.SubFilePathList[key]))
                {
                    msg = key + "でCSVファイル以外が選択されています。\r\nCSVファイルを選択してください。";
                    return false;
                }
            }
            #endregion

            #region ---- 出力ファイルパスのチェック ----
            if ((param.OutputFilePath == null) || (param.OutputFilePath.Length <= 0))
            {
                msg = "出力ファイルを選択してください。";
                return false;
            }

            string outputFilePath = Path.GetDirectoryName(param.OutputFilePath);
            if (!this.CheckExists(2, outputFilePath))
            {
                msg = "選択された出力先が存在しません。";
                return false;
            }

            if (!this.CheckExists(3, param.OutputFilePath))
            {
                msg = "出力ファイル名でCSVファイル以外が選択されています。\r\nCSVファイルを選択してください。";
                return false;
            }
            #endregion

            return true;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// メインファイルデータ取得
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <param name="headerLine">ヘッダー行</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>DataView</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal DataView GetMainFileData(PMKHN09951A_Common.CSVCheckToolPara param, out string headerLine, out string msg)
        {
            #region
            headerLine = String.Empty;
            msg = String.Empty;

            DataView retDV = null;
            DataTable dt = new DataTable(param.MainFileDispName);

            this._csvRead = null;

            try
            {
                this._csvRead = new TextFieldParser(param.MainFilePath, encSJIS);
                this._csvRead.TextFieldType = FieldType.Delimited;     // フィールド：区切り形式
                this._csvRead.SetDelimiters(",");     // 区切り記号：「,」カンマ

                // ヘッダー行がある場合
                if (param.HeaderLineExistDiv)
                    // ファイルのヘッダー行を取得
                    headerLine = this._csvRead.ReadLine();

                string[] csvRowData;

                // CSVファイルのデータ読み込み
                while (!this._csvRead.EndOfData)
                {
                    csvRowData = this._csvRead.ReadFields();

                    this.SetDTFromCSVRowData(ref dt, csvRowData);
                }

                if (dt.Rows.Count > 0)
                    // キー情報に従って並び替え
                    retDV = this.CreateSortedDataView(dt, param.PrimaryKeyList);
                else
                    msg = param.MainFileDispName + "で空のCSVファイルが選択されています。\r\nCSVファイルを選択してください。";
            }
            catch (Exception ex)
            {
                retDV = null;
                msg = "CSVファイル情報の取得に失敗しました。\r\n" + ex.Message;
            }
            finally
            {
                if (this._csvRead != null)
                    this._csvRead.Close();
            }

            return retDV;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// サブファイルデータ取得
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>Dictionary</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal Dictionary<string, DataView> GetSubFileData(PMKHN09951A_Common.CSVCheckToolPara param, out string msg)
        {
            #region
            msg = String.Empty;

            Dictionary<string, DataView> retDic = null;

            this._csvRead = null;

            try
            {
                foreach (string key in param.SubFilePathList.Keys)
                {
                    DataTable dt = new DataTable();

                    this._csvRead = new TextFieldParser(param.SubFilePathList[key], encSJIS);
                    this._csvRead.TextFieldType = FieldType.Delimited;     // フィールド：区切り形式
                    this._csvRead.SetDelimiters(",");     // 区切り記号：「,」カンマ

                    // ヘッダー行がある場合
                    if (param.HeaderLineExistDiv)
                        // ファイルのヘッダー行は読み飛ばしを取得
                        this._csvRead.ReadLine();

                    string[] csvRowData;

                    // CSVファイルのデータ読み込み
                    while (!this._csvRead.EndOfData)
                    {
                        csvRowData = this._csvRead.ReadFields();

                        this.SetDTFromCSVRowData(ref dt, csvRowData);
                    }

                    if (dt.Rows.Count > 0)
                    {
                        // キー情報に従って並び替え
                        DataView dv = this.CreateSortedDataView(dt, param.PrimaryKeyList);

                        if (retDic == null)
                            retDic = new Dictionary<string, DataView>();

                        if (!retDic.ContainsKey(key))
                            retDic.Add(key, dv);
                    }
                }

                if ((retDic == null) || (retDic.Count <= 0))
                    msg = "比較サブで空のCSVファイルが選択されています。\r\nCSVファイルを選択してください。";
            }
            catch (Exception ex)
            {
                retDic = null;
                msg = "CSVファイル情報の取得に失敗しました。\r\n" + ex.Message;
            }
            finally
            {
                if (this._csvRead != null)
                    this._csvRead.Close();
            }

            return retDic;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 項目数チェック処理
        /// </summary>
        /// <param name="mainDV">メインDataView</param>
        /// <param name="subDic">サブDataViewのDictoinary</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal bool CheckItemsCount(DataView mainDV, Dictionary<string, DataView> subDic)
        {
            int mainItemsCount = mainDV.Table.Columns.Count;

            foreach (DataView dv in subDic.Values)
            {
                if (!dv.Table.Columns.Count.Equals(mainItemsCount))
                    // 各CSVファイルの項目数が合わない場合は、次へ進まない
                    return false;
            }

            return true;
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ比較処理
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <param name="mainDV">メインDataView</param>
        /// <param name="subDic">サブDataViewのDictoinary</param>
        /// <param name="header">ヘッダー情報</param>
        /// <param name="msgDiv">メッセージ区分</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>MethodResult</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal ConstantManagement.MethodResult CompareData(PMKHN09951A_Common.CSVCheckToolPara param,
            DataView mainDV, Dictionary<string, DataView> subDic, string header, out bool msgDiv, out string msg)
        {
            #region
            ConstantManagement.MethodResult status = ConstantManagement.MethodResult.ctFNC_CANCEL;
            msgDiv = false;
            msg = String.Empty;

            // キー情報リスト　(key1の値)_(key2の値)_(key3の値)_…の形式で格納
            // 文字列レベルでのソートしかできない。。。
            SortedList<string, string> keyValList = new SortedList<string, string>();

            // メインデータを元にキー情報リストを生成
            foreach (DataRowView drv in mainDV)
            {
                string mainKey = String.Empty;

                for (int count = 1; count <= param.PrimaryKeyList.Count; count++)
                {
                    if (mainKey.Length > 0)
                        mainKey += "__";

                    mainKey += "(" + drv["col" + param.PrimaryKeyList[count].ToString()] + ")";
                }

                if (!keyValList.ContainsKey(mainKey))
                    // 追加
                    keyValList.Add(mainKey, mainKey);
            }

            // サブデータを元にキー情報リストを生成
            foreach (DataView dv in subDic.Values)
            {
                foreach (DataRowView drv in dv)
                {
                    string subKey = String.Empty;

                    for (int count = 1; count <= param.PrimaryKeyList.Count; count++)
                    {
                        if (subKey.Length > 0)
                            subKey += "__";

                        subKey += "(" + drv["col" + param.PrimaryKeyList[count].ToString()] + ")";
                    }

                    if (!keyValList.ContainsKey(subKey))
                        // 追加
                        keyValList.Add(subKey, subKey);
                }
            }

            // 差異格納用DataTable
            DataTable dt = null;

            switch (param.OutputMode)
            {
                #region ---- キー単位に羅列 ----
                case PMKHN09951A_Common.OutputMode.ctByTheKey:
                    {
                        // TODO : 比較処理　実行

                        // TODO : 機能拡張時に実装
                        switch (status)
                        {
                            default:
                                {
                                    break;
                                }
                        }

                        break;
                    }
                #endregion

                #region ---- ベースとの比較チェック ----
                case PMKHN09951A_Common.OutputMode.ctForCompCheck:
                    {
                        // 比較処理　実行
                        status = this.Compare_ForCheck(param, mainDV, subDic, keyValList, out dt);

                        if (status == ConstantManagement.MethodResult.ctFNC_NORMAL)
                        {
                            if ((dt == null) || (dt.Rows.Count <= 0))
                            {
                                // 差異なし

                                msgDiv = true;
                                msg = "正常に処理が終了しました。　差異はありません。";
                            }
                            else
                            {
                                // 差異あり

                                // 差異データをCSV変換して出力
                                status = this.ExportCSVFile(param, header, dt, out msg);

                                if (status == ConstantManagement.MethodResult.ctFNC_NORMAL)
                                {
                                    msgDiv = true;
                                    //msg = "正常に処理が終了しました。　○件中○件に差異が発生しています。\r\n" 
                                    msg = "正常に処理が終了しました。　" + dt.Rows.Count / 2 + "件 差異が発生しています。\r\n"
                                        + "出力ファイルを参照してください。\r\n\r\n"
                                        + "　　出力先：" + param.OutputFilePath;
                                }
                            }
                        }

                        break;
                    }
                #endregion

                #region ---- 統合用 ----
                case PMKHN09951A_Common.OutputMode.ctForConsolidate:
                    {
                        // TODO : 比較処理　実行

                        // TODO : 機能拡張時に実装
                        switch (status)
                        {
                            default:
                                {
                                    break;
                                }
                        }

                        break;
                    }
                #endregion

                default:
                    {
                        status = ConstantManagement.MethodResult.ctFNC_CANCEL;
                        break;
                    }
            }

            return status;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ログ出力
        /// </summary>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        internal void WriteLog(PMKHN09951A_Common.CSVCheckToolPara param, string msg)
        {
            #region
            this._logWrite = null;

            try
            {
                // ログは、出力結果と同じ階層に出力する
                string path = Path.Combine(Path.GetDirectoryName(param.OutputFilePath), "CSV比較ツール.log");

                this._logWrite = new StreamWriter(path, true, encSJIS);

                if (File.Exists(path))
                    // 既存ファイルに追記する場合は、罫線追加
                    this._logWrite.WriteLine("----------------------------------------");

                // ヘッダー部
                this._logWrite.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss" + "　実施"));
                // メイン
                this._logWrite.WriteLine("　・" + param.MainFileDispName + "：" + param.MainFilePath);
                // サブ
                foreach (string key in param.SubFilePathList.Keys)
                    this._logWrite.WriteLine("　・" + key + "：" + param.SubFilePathList[key]);
                // 空の改行
                this._logWrite.WriteLine();
                // 結果
                this._logWrite.WriteLine(msg);
                // 空の改行
                this._logWrite.WriteLine();
            }
            catch
            {
                // 何もしない
            }
            finally
            {
                if (this._logWrite != null)
                    this._logWrite.Close();
            }
            #endregion
        }
        #endregion

        #region -- Private Methods --
        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 存在チェック
        /// </summary>
        /// <param name="mode">モード（1：ファイル、2：ディレクトリ、3：拡張子チェック）</param>
        /// <param name="filePath">ファイルパス</param>
        /// <returns>bool</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        private bool CheckExists(int mode, string filePath)
        {
            #region
            try
            {
                switch (mode)
                {
                    // ファイル存在チェック
                    case 1:
                        return File.Exists(filePath);

                    // ディレクトリ存在チェック
                    case 2:
                        return Directory.Exists(filePath);

                    // 拡張子チェック
                    case 3:
                        {
                            string extension = Path.GetExtension(filePath);

                            bool checkDiv = extension.Equals(".csv");

                            if (!checkDiv)
                                checkDiv = extension.Equals(".CSV");

                            return checkDiv;
                        }

                    default:
                        return false;
                }
            }
            catch
            {
                return false;
            }
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// CSV1行からDataTableの行データへ変換
        /// </summary>
        /// <param name="dt">DataTable</param>
        /// <param name="csvRowData">CSV1行のデータ</param>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        private void SetDTFromCSVRowData(ref DataTable dt, string[] csvRowData)
        {
            #region
            if ((csvRowData == null) || (csvRowData.Length <= 0))
                return;

            if (dt == null)
                dt = new DataTable();

            if (dt.Columns.Count <= 0)
            {
                // カラム生成
                for (int index = 1; index <= csvRowData.Length; index++)
                {
                    DataColumn dc = new DataColumn("col" + index.ToString());
                    dt.Columns.Add(dc);
                }
            }

            // 行データ生成
            DataRow dr = dt.NewRow();
            for (int index = 1; index <= csvRowData.Length; index++)
                dr["col" + index.ToString()] = csvRowData[index - 1];

            // DataTableにadd
            dt.Rows.Add(dr);
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// ソートしたDataTableの作成
        /// </summary>
        /// <param name="baseDT">DataTable</param>
        /// <param name="PKList">プライマリーキーList</param>
        /// <returns>DataView</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        private DataView CreateSortedDataView(DataTable baseDT, SortedList<int, int> PKList)
        {
            #region
            DataView dv = new DataView(baseDT);

            string sortCondi = String.Empty;
            for (int count = 1; count <= PKList.Count; count++)
            {
                if (sortCondi.Length > 0)
                    sortCondi += ", ";

                sortCondi += "col" + PKList[count].ToString();
            }

            sortCondi += " ASC";

            // キー情報に従って並び替え
            dv.Sort = sortCondi;

            return dv;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// データ比較処理
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <param name="mainDV">メインDataView</param>
        /// <param name="subDic">サブDataViewのDictoinary</param>
        /// <param name="keyValList">キー情報</param>
        /// <param name="difDataTable">差異格納用DataTable</param>
        /// <returns>MethodResult</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        private ConstantManagement.MethodResult Compare_ForCheck(PMKHN09951A_Common.CSVCheckToolPara param,
            DataView mainDV, Dictionary<string, DataView> subDic, SortedList<string, string> keyValList, out DataTable difDataTable)
        {
            #region
            ConstantManagement.MethodResult status = ConstantManagement.MethodResult.ctFNC_CANCEL;
            string[] split = {")__("};
            string subName = String.Empty;

            difDataTable = new DataTable();

            try
            {
                // 差異格納用DataTableの生成
                for (int col = 0; col <= mainDV.Table.Columns.Count; col++)
                {
                    // 0番目はヘッダー用
                    DataColumn dc = new DataColumn("col" + col.ToString());
                    difDataTable.Columns.Add(dc);
                }

                // ここではメイン：サブ = 1：1の比較のみを行う
                // 片方にのみ存在するデータも「差異」とみなす

                DataView subDV = null;
                foreach (string subKey in param.SubFilePathList.Keys)
                {
                    if (subDic.ContainsKey(subKey))
                    {
                        subName = subKey;
                        subDV = subDic[subKey];
                        break;
                    }
                }

                // キー情報を元に差分チェックを行う
                foreach (string keyVal in keyValList.Keys)
                {
                    // キー情報を分割
                    string[] values = keyVal.Split(split, StringSplitOptions.RemoveEmptyEntries);
                    // フィルター
                    string filter = String.Empty;

                    for (int count = 1; count <= values.Length; count++)
                    {
                        // キー指定されているカラムの値でフィルターをかけたい

                        string value = values[count - 1];

                        if (count == 1)
                            // 頭の不要文字列を削除
                            value = value.Remove(0, 1);
                        else if (count == values.Length)
                            // 末尾の不要文字列を削除
                            value = value.Remove(value.Length - 1, 1);

                        if (filter.Length > 0)
                            filter += " AND ";

                        filter += "col" + param.PrimaryKeyList[count].ToString() + "='" + value + "'";
                    }

                    mainDV.RowFilter = filter;

                    subDV.RowFilter = filter;

                    if (mainDV.Count <= 0)
                    {
                        // メインは空行を追加
                        DataRow dr_null = difDataTable.NewRow();
                        dr_null["col0"] = param.MainFileDispName;
                        difDataTable.Rows.Add(dr_null);

                        #region ---- サブにのみ存在するため、出力対象に追加 ----
                        DataRow dr = difDataTable.NewRow();

                        // キーを指定して抜き出してるので、複数明細は存在しない。。。ハズ
                        DataRowView drv = subDV[0];

                        for (int col = 0; col <= drv.DataView.Table.Columns.Count; col++)
                        {
                            if (col == 0)
                                // ヘッダー部
                                dr["col0"] = subName;
                            else
                                // その他データ
                                dr["col" + col.ToString()] = drv["col" + col.ToString()];
                        }

                        difDataTable.Rows.Add(dr);
                        #endregion
                    }
                    else if (subDV.Count <= 0)
                    {
                        #region ---- メインにのみ存在するため、出力対象に追加 ----
                        DataRow dr = difDataTable.NewRow();

                        // キーを指定して抜き出してるので、複数明細は存在しない。。。ハズ
                        DataRowView drv = mainDV[0];

                        for (int col = 0; col <= drv.DataView.Table.Columns.Count; col++)
                        {
                            if (col == 0)
                                // ヘッダー部
                                dr["col0"] = param.MainFileDispName;
                            else
                                // その他データ
                                dr["col" + col.ToString()] = drv["col" + col.ToString()];
                        }

                        difDataTable.Rows.Add(dr);
                        #endregion

                        // サブは空行を追加
                        DataRow dr_null = difDataTable.NewRow();
                        dr_null["col0"] = subName;
                        difDataTable.Rows.Add(dr_null);
                    }
                    else
                    {
                        #region ---- 両方に存在するため、1項目毎に比較 ----

                        // キーを指定して抜き出してるので、複数明細は存在しない。。。ハズ

                        // 1項目毎に差異チェックを実施
                        bool difDiv = false;
                        for (int col = 1; col <= mainDV[0].DataView.Table.Columns.Count; col++)
                        {
                            if (!mainDV[0]["col" + col.ToString()].Equals(subDV[0]["col" + col.ToString()]))
                            {
                                // 差異があるので、チェック中断
                                difDiv = true;
                                break;
                            }
                        }

                        if (difDiv)
                        {
                            // 差異あり

                            #region ---- メインのレコードを出力対象に追加 ----
                            DataRow mainDR = difDataTable.NewRow();

                            // キーを指定して抜き出してるので、複数明細は存在しない。。。ハズ
                            DataRowView mainDRV = mainDV[0];

                            for (int col = 0; col <= mainDRV.DataView.Table.Columns.Count; col++)
                            {
                                if (col == 0)
                                    // ヘッダー部
                                    mainDR["col0"] = param.MainFileDispName;
                                else
                                    // その他データ
                                    mainDR["col" + col.ToString()] = mainDRV["col" + col.ToString()];
                            }

                            difDataTable.Rows.Add(mainDR);
                            #endregion

                            #region ---- サブのレコードを出力対象に追加 ----
                            DataRow subDR = difDataTable.NewRow();

                            // キーを指定して抜き出してるので、複数明細は存在しない。。。ハズ
                            DataRowView subDRV = subDV[0];

                            for (int col = 0; col <= subDRV.DataView.Table.Columns.Count; col++)
                            {
                                if (col == 0)
                                    // ヘッダー部
                                    subDR["col0"] = subName;
                                else
                                    // その他データ
                                    subDR["col" + col.ToString()] = subDRV["col" + col.ToString()];
                            }

                            difDataTable.Rows.Add(subDR);
                            #endregion
                        }
                        else
                        {
                            // 差異なしなので、何もしない
                        }
                        #endregion
                    }
                }

                status = ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch
            {
                difDataTable = null;
                status = ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
            #endregion
        }

        /*----------------------------------------------------------------------------------*/
        /// <summary>
        /// 差異CSV出力
        /// </summary>
        /// <param name="param">パラメータ</param>
        /// <param name="headerLine">ヘッダー情報</param>
        /// <param name="difDT">差異格納用DataTable</param>
        /// <param name="msg">メッセージ</param>
        /// <returns>MethodResult</returns>
        /// <remarks>
        /// <br>Note		: </br>
        /// <br>Programmer	: 23006  高橋 明子</br>
        /// <br>Date		: 2014.08.27</br>
        /// </remarks>
        private ConstantManagement.MethodResult ExportCSVFile(PMKHN09951A_Common.CSVCheckToolPara param, string headerLine, DataTable difDT, out string msg)
        {
            #region
            ConstantManagement.MethodResult status = ConstantManagement.MethodResult.ctFNC_CANCEL;
            msg = String.Empty;

            this._csvWrite = null;

            try
            {
                // CSVは　二重引用符付き、カンマ区切り　で出力

                this._csvWrite = new StreamWriter(param.OutputFilePath, false, encSJIS);

                // ヘッダー書き込み
                if (headerLine.Length > 0)
                {
                    headerLine = "ヘッダ," + headerLine;
                    this._csvWrite.WriteLine(headerLine);
                }

                string writeStr = String.Empty;

                foreach (DataRow dr in difDT.Rows)
                {
                    StringBuilder sb = new StringBuilder();

                    for (int col = 0; col < dr.Table.Columns.Count; col++)
                    {
                        if (sb.Length > 0)
                            sb.Append(",");

                        sb.Append("\"" + dr["col" + col.ToString()] + "\"");
                    }

                    // 1行分の文字列と改行を書き込み
                    this._csvWrite.WriteLine(sb.ToString());
                }

                status = ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            catch (Exception ex)
            {
                msg = "CSVファイル情報の出力に失敗しました。\r\n" + ex.Message;
                status = ConstantManagement.MethodResult.ctFNC_ERROR;
            }
            finally
            {
                if (this._csvWrite != null)
                    this._csvWrite.Close();
            }

            return status;
            #endregion
        }
        #endregion
    }
}
