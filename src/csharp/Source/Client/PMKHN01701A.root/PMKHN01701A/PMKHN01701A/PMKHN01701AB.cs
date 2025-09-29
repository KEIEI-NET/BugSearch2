//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 明治産業品番変換一括処理
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  11003519-00  作成担当 : 時シン
// 作 成 日  2015/03/02   修正内容 : Redmine#44209 「仕様変更」ログの項目名の対応
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 書式付テキスト出力
    /// </summary>
    public class FormattedTextWriter
    {
        #region プライベート変数

        #region プロパティで使用

        /// <summary>データソース</summary>
        private Object _dataSource;

        /// <summary>データメンバ名</summary>
        private String _dataMember;

        /// <summary>出力ファイル名</summary>
        private String _outputFileName;

        /// <summary>テキスト出力するカラム名一覧</summary>
        private List<String> _schemeList;

        /// <summary>項目の区切り文字(列)、"\t"ならばTAB</summary>
        private String _splitter;

        /// <summary>項目括り文字</summary>
        private string _encloser;

        /// <summary>項目括り文字を適用する型</summary>
        private List<Type> _enclosingTypeList;

        /// <summary>列単位の出力フォーマット指定リスト</summary>
        private Dictionary<String, String> _formatList;

        /// <summary>タイトル行出力フラグ</summary>
        private bool _captionOutput;

        /// <summary>固定長出力フラグ</summary>
        private bool _fixedLength;

        /// <summary>文字列置換する項目の一覧。</summary>
        private Dictionary<String, String> _replaceList;

        /// <summary>列単位の最大長指定リスト</summary>
        private Dictionary<string, int> _maxLengthList;

        /// <summary>同一ファイル存在時の処理(True:終点行へ追加するFalse:終点行へ追加しない)</summary>
        private bool _outputMode;

        #endregion // プロパティで使用

        #region 処理で使用

        private StreamWriter _sw;
        private Encoding _sjisEnc;

        #endregion // 処理で使用

        #endregion

        #region 定数

        /// <summary>返り値：正常終了</summary>
        private const int CT_RETURN_STATUS_OK = 0;

        /// <summary>返り値：エラー</summary>
        private const int CT_RETURN_STATUS_ERROR = 9;

        /// <summary>デフォルトの最大バイト長（columnに対してMaxLengthが設定されていない場合のみ使用）</summary>
        private const int CT_DEFAULT_MAXBYTECOUNT = 10;

        #endregion // 定数

        #region コンストラクタ

        /// <summary>
        /// テキスト出力部品
        /// </summary>
        public FormattedTextWriter()
        {
            // 初期値セット
            this._outputFileName = string.Empty;
            this._dataSource = null;
            this._dataMember = string.Empty;
            this._schemeList = null;
            this._captionOutput = true;
            this._fixedLength = false;
            this._splitter = ",";
            this._encloser = "\"";
            this._formatList = null;
            this._replaceList = null;
            this._outputMode = false;

            _sjisEnc = Encoding.GetEncoding("Shift_JIS");
        }

        #endregion // コンストラクタ

        #region プロパティ
        /// <summary>
        /// DataSource
        /// </summary>
        public Object DataSource
        {
            get { return this._dataSource; }
            set { this._dataSource = value; }
        }
        /// <summary>
        /// DataMember
        /// </summary>
        public String DataMember
        {
            get { return this._dataMember; }
            set { this._dataMember = value; }
        }
        /// <summary>
        /// OutputFileName
        /// </summary>
        public String OutputFileName
        {
            get { return this._outputFileName; }
            set { this._outputFileName = value; }
        }
        /// <summary>
        /// SchemeList
        /// </summary>
        public List<String> SchemeList
        {
            get { return this._schemeList; }
            set { this._schemeList = value; }
        }
        /// <summary>
        /// Splitter
        /// </summary>
        public String Splitter
        {
            get { return this._splitter; }
            set { this._splitter = value; }
        }
        /// <summary>
        /// Encloser
        /// </summary>
        public String Encloser
        {
            get { return this._encloser; }
            set { this._encloser = value; }
        }
        /// <summary>
        /// EnclosingTypeList
        /// </summary>
        public List<Type> EnclosingTypeList
        {
            get { return this._enclosingTypeList; }
            set { this._enclosingTypeList = value; }
        }
        /// <summary>
        /// FormatList
        /// </summary>
        public Dictionary<String, String> FormatList
        {
            get { return this._formatList; }
            set { this._formatList = value; }
        }
        /// <summary>
        /// CaptionOutput
        /// </summary>
        public bool CaptionOutput
        {
            get { return this._captionOutput; }
            set { this._captionOutput = value; }
        }
        /// <summary>
        /// FixedLength
        /// </summary>
        public bool FixedLength
        {
            get { return this._fixedLength; }
            set { this._fixedLength = value; }
        }
        /// <summary>
        /// ReplaceList
        /// </summary>
        public Dictionary<String, String> ReplaceList
        {
            get { return this._replaceList; }
            set { this._replaceList = value; }
        }
        /// <summary>
        /// MaxLengthList
        /// </summary>
        public Dictionary<string, int> MaxLengthList
        {
            get { return _maxLengthList; }
            set { _maxLengthList = value; }
        }
        /// <summary>
        /// OutputMode
        /// </summary>
        public bool OutputMode
        {
            get { return this._outputMode; }
            set { this._outputMode = value; }
        }
        #endregion

        #region メソッド

        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <param name="totalCount">outパラメータ 出力件数</param>
        /// <returns>正常:0, エラー:9</returns>
        public int TextOut(out int totalCount)
        {
            int status = CT_RETURN_STATUS_ERROR;
            totalCount = 0;

            // ----------------------------
            // プロパティ値のチェック
            // ----------------------------
            // ファイル名がない場合はエラー
            if (String.IsNullOrEmpty(this._outputFileName)) return status;
            // スキーマリストがない場合はエラー
            if (this._schemeList == null) return status;


            DataTable dt = new DataTable();
            DataView dv = new DataView();
            DataSet ds = new DataSet();

            // データソースの検査
            if (this._dataSource.GetType() == dt.GetType())
            {
                dt = (DataTable)this._dataSource;
                status = OutputData(dt, out totalCount);
            }
            else if (this._dataSource.GetType() == ds.GetType())
            {
                ds = (DataSet)this._dataSource;
                // データセットの場合、含まれるデータテーブルが複数の時にDataMemberが指定されていないとエラー
                if (ds.Tables.Count > 1 && String.IsNullOrEmpty(this._dataMember))
                {
                    return status;
                }
                else
                {
                    dt = ds.Tables[this._dataMember];
                    status = OutputData(dt, out totalCount);
                }
            }
            else if (this._dataSource.GetType() == dv.GetType())
            {
                dv = (DataView)this._dataSource;
                dt = dv.ToTable();
                status = OutputData(dt, out totalCount);
            }
            else
            {
                // DataSet, DataView, DataTable以外に対応する場合はelse ifを増やすこと
            }

            // 返り値は必要
            return status;
        }

        /// <summary>
        /// 出力ストリーム取得
        /// </summary>
        /// <returns></returns>
        private bool getStreamWriter()
        {
            try
            {
                // エンコーディングはShift_JISで固定
                Encoding enc = _sjisEnc;
                // outputModeはTrueの場合:終点行へ追加する
                if (this._outputMode)
                {
                    this._sw = new StreamWriter(this._outputFileName, true, enc);
                }
                // outputModeはFalseの場合:終点行へ追加しない
                else
                {
                    this._sw = new StreamWriter(this._outputFileName, false, enc);
                }
                return true;
            }
            catch (Exception ex)
            {
                // 出力失敗
                TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "FormattedTextWriter",
                    ex.Message, -1, MessageBoxButtons.OK);
                return false;
            }
        }


        /// <summary>
        /// 出力メイン
        /// </summary>
        /// <param name="dt">出力対象となるデータテーブル</param>
        /// <param name="outputLineCount">出力件数</param>
        /// <returns></returns>
        private int OutputData(DataTable dt, out int outputLineCount)
        {
            // 返り値の初期値はエラー
            int status = CT_RETURN_STATUS_ERROR;
            outputLineCount = 0;

            DataRowCollection rows;
            int colCount = 0;
            int lastColIndex = 0;
            int currentRow = 0;

            string formatStr = string.Empty;
            string replaceList = string.Empty;
            string colName = string.Empty;

            string repKey = string.Empty;
            string repValue = string.Empty;

            if (_maxLengthList == null)
            {
                _maxLengthList = new Dictionary<string, int>();
            }

            // 出力ストリーム取得
            if (!getStreamWriter())
            {
                return status;
            }

            // 出力する列数をカウント（スキーマリストにない列は出力されない）
            colCount = this._schemeList.Count;
            lastColIndex = colCount - 1;

            #region タイトル行出力

            // タイトル行を出力する
            if (this._captionOutput)
            {
                for (int i = 0; i < this._schemeList.Count; i++)
                {
                    DataColumn col = dt.Columns[this._schemeList[i]];

                    // 列が存在しなければエラーを返す（何のエラーかはわからない）
                    if (col == null) return status;

                    // 書き込みテキスト
                    string writeString = col.Caption;

                    // 最大長(バイト数指定)
                    int maxLength = CT_DEFAULT_MAXBYTECOUNT;
                    if (_maxLengthList.ContainsKey(col.ColumnName))
                    {
                        maxLength = _maxLengthList[col.ColumnName];
                    }

                    bool isString = false;

                    if (col.DataType == typeof(Int16) ||
                         col.DataType == typeof(Int32) ||
                         col.DataType == typeof(Int64) ||
                         col.DataType == typeof(decimal) ||
                         col.DataType == typeof(float) ||
                         col.DataType == typeof(double))
                    {
                    }
                    else
                    {
                        isString = true;
                    }

                    // 固定長
                    if (this._fixedLength)
                    {
                        if (isString)
                        {
                            // 左詰め (XXXXX_____)
                            writeString = this.BytePadRight(writeString, maxLength);
                        }
                        else
                        {
                            // 右詰め (_____XXXXX)
                            writeString = this.BytePadLeft(writeString, maxLength);
                        }
                    }

                    // 括り対象の型
                    if (_enclosingTypeList.Contains(col.DataType))
                    {
                        writeString = this._encloser + writeString + this._encloser;
                    }

                    // 書き込み
                    this._sw.Write(writeString);

                    // 区切り文字を書き込む
                    if (lastColIndex > i) this._sw.Write(this._splitter);
                }

                // 改行
                this._sw.Write(Environment.NewLine);
            }

            #endregion // タイトル行出力

            #region データ出力

            rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                // データを書き出す
                for (int i = 0; i < this._schemeList.Count; i++)
                {
                    DataColumn col = dt.Columns[this._schemeList[i]];
                    // 列が存在しなければエラーを返す（何のエラーかはわからない）
                    if (col == null) return status;

                    colName = this._schemeList[i].ToString();

                    // 最大長(バイト数指定)
                    int maxLength = CT_DEFAULT_MAXBYTECOUNT;
                    if (_maxLengthList.ContainsKey(col.ColumnName))
                    {
                        maxLength = _maxLengthList[col.ColumnName];
                    }

                    if (this._formatList != null && !String.IsNullOrEmpty(this._formatList[colName]))
                    {
                        // フォーマット指定あり
                        formatStr = this._formatList[colName].ToString();
                    }
                    else
                    {
                        // フォーマット指定なし
                        formatStr = string.Empty;
                    }

                    // 書き込みテキスト
                    string writeString = string.Empty;
                    bool isString = false;

                    // 標準テキスト内容
                    # region [標準テキスト内容]
                    if (row[colName] == DBNull.Value)
                    {
                        writeString = string.Empty;
                    }
                    else if (col.DataType == typeof(DateTime))
                    {
                        writeString = ((DateTime)row[colName]).ToString(formatStr);
                        isString = true;
                    }
                    else if (col.DataType == typeof(Int16))
                    {
                        writeString = ((Int16)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(Int32))
                    {
                        writeString = ((Int32)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(Int64))
                    {
                        writeString = ((Int64)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(decimal))
                    {
                        writeString = ((decimal)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(float))
                    {
                        writeString = ((float)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(double))
                    {
                        writeString = ((double)row[colName]).ToString(formatStr);
                    }
                    else if (col.DataType == typeof(string))
                    {
                        if (_replaceList != null)
                        {
                            // 文字列のみReplaceListと比較
                            foreach (KeyValuePair<string, string> rPage in this._replaceList)
                            {
                                if (row[colName].ToString().Contains(rPage.Key))
                                {
                                    writeString = row[colName].ToString().Replace(rPage.Key, rPage.Value);
                                }
                                else
                                {
                                    writeString = row[colName].ToString();
                                }
                            }
                        }
                        else
                        {
                            writeString = row[colName].ToString();
                        }
                        isString = true;
                    }
                    else
                    {
                        writeString = row[colName].ToString();
                        isString = true;
                    }
                    # endregion

                    // 固定長
                    if (this._fixedLength && maxLength > 0)
                    {
                        if (isString)
                        {
                            // 左詰め
                            writeString = this.BytePadRight(writeString, maxLength);
                        }
                        else
                        {
                            // 右詰め
                            writeString = this.BytePadLeft(writeString, maxLength);
                        }
                    }

                    // 括り対象の型
                    if (_enclosingTypeList.Contains(col.DataType))
                    {
                        writeString = this._encloser + writeString + this._encloser;
                    }

                    // 書き込み
                    this._sw.Write(writeString);

                    // 区切り文字を書き込む
                    if (lastColIndex > i) this._sw.Write(this._splitter);
                }

                // 改行
                this._sw.Write(Environment.NewLine);

                currentRow++;
            }

            #endregion // データ出力

            // 出力終了
            this._sw.Close();
            this._sw.Dispose();
            status = CT_RETURN_STATUS_OK;

            outputLineCount = currentRow;

            return status;
        }

        /// <summary>
        /// バイト単位PadLeft処理（右寄せ）（"_____XXXXX"）
        /// </summary>
        /// <param name="writeString"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        private string BytePadLeft(string writeString, int maxLength)
        {
            writeString = writeString.Trim();

            // あふれた分を取り除く
            writeString = SubStringOfByte(writeString, maxLength);

            // バイト数取得
            int orgByteCount = _sjisEnc.GetByteCount(writeString);

            // 足りない分を空白で左に埋める
            return new string(' ', maxLength - orgByteCount) + writeString;
        }
        /// <summary>
        /// バイト単位PadRight処理（左寄せ）（"XXXXX_____"）
        /// </summary>
        /// <param name="writeString"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        private string BytePadRight(string writeString, int maxLength)
        {
            writeString = writeString.Trim();

            // あふれた分を取り除く
            writeString = SubStringOfByte(writeString, maxLength);

            // バイト数取得
            int orgByteCount = _sjisEnc.GetByteCount(writeString);

            // 足りない分を空白で右に埋める
            return writeString + new string(' ', maxLength - orgByteCount);
        }
        /// <summary>
        /// 文字列　バイト数指定切り抜き
        /// </summary>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        private string SubStringOfByte(string orgString, int byteCount)
        {
            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.PadRight(byteCount).Substring(0, byteCount);

            int count;

            for (int i = orgString.Length; i >= 0; i--)
            {
                // 「文字数」を減らす
                resultString = orgString.Substring(0, i);

                // バイト数を取得して判定
                count = _sjisEnc.GetByteCount(resultString);
                if (count <= byteCount) break;
            }

            // 後ろの余白を取り除いて返す
            return resultString.TrimEnd();
        }

        #endregion
    }
}
