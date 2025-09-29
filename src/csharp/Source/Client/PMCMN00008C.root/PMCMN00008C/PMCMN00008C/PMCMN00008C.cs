using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Windows.Forms;//ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する

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

        // ADD 2010/08/23 ---- >>>>
        /// <summary>同一ファイル存在時の処理(True:終点行へ追加するFalse:終点行へ追加しない)</summary>
        private bool _outputMode;
        // ADD 2010/08/23 ---- <<<<

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

        // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>
        /// <summary>返り値：中断</summary>
        private const int CT_RETURN_STATUS_CANCLE = 1;
        // --- ADD licb K2014/03/10 FRO 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<

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
            this._outputMode = false;  // ADD 2010/08/23

            _sjisEnc = Encoding.GetEncoding( "Shift_JIS" );
        }

        #endregion // コンストラクタ

        #region プロパティ

        public Object DataSource
        {
            get { return this._dataSource; }
            set { this._dataSource = value; }
        }

        public String DataMember
        {
            get { return this._dataMember; }
            set { this._dataMember = value; }
        }

        public String OutputFileName
        {
            get { return this._outputFileName; }
            set { this._outputFileName = value; }
        }

        public List<String> SchemeList
        {
            get { return this._schemeList; }
            set { this._schemeList = value; }
        }

        public String Splitter
        {
            get { return this._splitter; }
            set { this._splitter = value; }
        }

        public String Encloser
        {
            get { return this._encloser; }
            set { this._encloser = value; }
        }

        public List<Type> EnclosingTypeList
        {
            get { return this._enclosingTypeList; }
            set { this._enclosingTypeList = value; }
        }

        public Dictionary<String, String> FormatList
        {
            get { return this._formatList; }
            set { this._formatList = value; }
        }

        public bool CaptionOutput
        {
            get { return this._captionOutput; }
            set { this._captionOutput = value; }
        }

        public bool FixedLength
        {
            get { return this._fixedLength; }
            set { this._fixedLength = value; }
        }

        public Dictionary<String, String> ReplaceList
        {
            get { return this._replaceList; }
            set { this._replaceList = value; }
        }

        public Dictionary<string, int> MaxLengthList
        {
            get { return _maxLengthList; }
            set { _maxLengthList = value; }
        }

        // ADD 2010/08/23 --- >>>>
        public bool OutputMode
        {
            get { return this._outputMode; }
            set { this._outputMode = value; }
        }
        // ADD 2010/08/23 --- <<<<
        #endregion

        # region イベント

        /// <summary>データ変更後発生イベント</summary>
        public event EventHandler RecordWritten;//(object sender, int count);

        # endregion

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
                //Encoding enc = Encoding.GetEncoding("Shift_JIS");
                Encoding enc = _sjisEnc;
                // UPD 2010/08/23 --- >>>>
                // this._sw = new StreamWriter(this._outputFileName, false, enc);
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
                // UPD 2010/08/23 --- <<<<
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

            //Int16 i16 = new short();
            //Int32 i32 = new int();
            //Int64 i64 = new long();
            //Double dbl = new double();
            //Decimal dec = new decimal();
            //String str = string.Empty;

            DataRowCollection rows;
            int colCount = 0;
            int lastColIndex = 0;
            int currentRow = 0;

            string formatStr = string.Empty;
            string replaceList = string.Empty;
            string colName = string.Empty;

            string repKey = string.Empty;
            string repValue = string.Empty;

            if ( _maxLengthList == null )
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

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/26 DEL
                    # region // DEL
                    //#region Captionの文字チェック

                    //// 考える必要なし(鈴木)

                    ////// 強制的に"で囲む必要があるかどうか調べる
                    ////if (headerCaption.IndexOf('"') > -1 ||  // "を含む
                    ////    headerCaption.IndexOf(',') > -1 ||  // ,を含む
                    ////    headerCaption.IndexOf('\r') > -1 || // 改行を含む
                    ////    headerCaption.IndexOf('\n') > -1 || // 
                    ////    headerCaption.StartsWith(" ") ||    // スペースで始まる
                    ////    headerCaption.StartsWith("\t") ||   // タブで始まる
                    ////    headerCaption.EndsWith(" ") ||      // スペースで終わる
                    ////    headerCaption.EndsWith("\t"))       // タブで終わる
                    ////{
                    ////    if (headerCaption.IndexOf('"') > -1)
                    ////    {
                    ////        // "を""とする
                    ////        headerCaption = headerCaption.Replace("\"", "\"\"");
                    ////    }
                    ////    headerCaption = "\"" + headerCaption + "\"";

                    //#endregion

                    //if (this._fixedLength)
                    //{
                    //    // 数値型なら右寄せ, その他なら左寄せ
                    //    if (col.DataType == i16.GetType() || col.DataType == i32.GetType() ||
                    //        col.DataType == i64.GetType() || col.DataType == dec.GetType() ||
                    //        col.DataType == dbl.GetType())
                    //    {
                    //        this._sw.Write(this._encloser + col.Caption.PadLeft(col.MaxLength, ' ') + this._encloser);
                    //    }
                    //    else
                    //    {
                    //        this._sw.Write(this._encloser + col.Caption.PadRight(col.MaxLength, ' ') + this._encloser);
                    //    }
                    //}
                    //else
                    //{
                    //    this._sw.Write(this._encloser + col.Caption + this._encloser);
                    //}

                    //// 区切り文字を書き込む
                    //if (lastColIndex > i) this._sw.Write(this._splitter);
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/26 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/26 ADD
                    // 書き込みテキスト
                    string writeString = col.Caption.Trim();

                    // 最大長(バイト数指定)
                    int maxLength = CT_DEFAULT_MAXBYTECOUNT;
                    if ( _maxLengthList.ContainsKey( col.ColumnName ) )
                    {
                        maxLength = _maxLengthList[col.ColumnName];
                    }

                    bool isString = false;

                    if ( col.DataType == typeof( Int16 ) ||
                         col.DataType == typeof( Int32 ) ||
                         col.DataType == typeof( Int64 ) ||
                         col.DataType == typeof( decimal ) ||
                         col.DataType == typeof( float ) ||
                         col.DataType == typeof( double ) )
                    {
                    }
                    else
                    {
                        isString = true;
                    }

                    // 固定長
                    if ( this._fixedLength )
                    {
                        if ( isString )
                        {
                            // 左詰め (XXXXX_____)
                            //writeString = writeString.PadRight( maxLength, ' ' );
                            writeString = this.BytePadRight( writeString, maxLength );
                        }
                        else
                        {
                            // 右詰め (_____XXXXX)
                            //writeString = writeString.PadLeft( maxLength, ' ' );
                            writeString = this.BytePadLeft( writeString, maxLength );
                        }
                    }

                    // 括り対象の型
                    if ( _enclosingTypeList.Contains( col.DataType ) )
                    {
                        writeString = this._encloser + writeString + this._encloser;
                    }

                    // 書き込み
                    this._sw.Write( writeString );

                    // 区切り文字を書き込む
                    if ( lastColIndex > i ) this._sw.Write( this._splitter );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/26 ADD
                }

                // 改行
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/26 DEL
                //this._sw.Write("\r\n");
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/26 ADD
                this._sw.Write( Environment.NewLine );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/26 ADD
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
                    //colName = col.Caption;

                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/26 DEL
                    # region //DEL
                    //if (this._formatList != null && !String.IsNullOrEmpty(this._formatList[colName]))
                    //{
                    //    // フォーマット指定あり
                    //    formatStr = this._formatList[colName].ToString();

                    //    // 固定長
                    //    if (this._fixedLength)
                    //    {
                    //        // 数値型なら右寄せ, その他なら左寄せ
                    //        if (col.DataType == i16.GetType() || col.DataType == i32.GetType() ||
                    //            col.DataType == i64.GetType() || col.DataType == dec.GetType() ||
                    //            col.DataType == dbl.GetType())
                    //        {
                    //            this._sw.Write(this._encloser + String.Format(formatStr, row[colName].ToString()).PadLeft(col.MaxLength, ' ') + this._encloser);
                    //        }
                    //        else if (col.DataType == str.GetType())
                    //        {
                    //            // 文字列のみReplaceListと比較
                    //            foreach (KeyValuePair<string, string> rPage in this._replaceList)
                    //            {
                    //                if (row[colName].ToString().Contains(rPage.Key))
                    //                {
                    //                    this._sw.Write(this._encloser + String.Format(formatStr, row[colName].ToString().Replace(rPage.Key, rPage.Value)).PadRight(col.MaxLength, ' ') + this._encloser);
                    //                }
                    //                else
                    //                {
                    //                    this._sw.Write(this._encloser + String.Format(formatStr, row[colName].ToString()).PadRight(col.MaxLength, ' ') + this._encloser);
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            this._sw.Write(this._encloser + String.Format(formatStr, row[colName].ToString().PadRight(col.MaxLength, ' ')) + this._encloser);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        this._sw.Write(this._encloser + String.Format(formatStr, row[colName].ToString()) + this._encloser);
                    //    }
                    //}
                    //else
                    //{
                    //    // フォーマット指定なし
                    //    if (this._fixedLength)
                    //    {
                    //        // 数値型なら右寄せ, その他なら左寄せ
                    //        if (col.DataType == i16.GetType() || col.DataType == i32.GetType() ||
                    //            col.DataType == i64.GetType() || col.DataType == dec.GetType() ||
                    //            col.DataType == dbl.GetType())
                    //        {
                    //            this._sw.Write(this._encloser + row[colName].ToString().PadLeft(col.MaxLength, ' ') + this._encloser);
                    //        }
                    //        else if (col.DataType == str.GetType())
                    //        {
                    //            // 文字列のみReplaceListと比較
                    //            foreach (KeyValuePair<string, string> rPage in this._replaceList)
                    //            {
                    //                if (row[colName].ToString().Contains(rPage.Key))
                    //                {
                    //                    this._sw.Write(this._encloser + row[colName].ToString().Replace(rPage.Key, rPage.Value).PadRight(col.MaxLength, ' ') + this._encloser);
                    //                }
                    //                else
                    //                {
                    //                    this._sw.Write(this._encloser + row[colName].ToString().PadRight(col.MaxLength, ' ') + this._encloser);
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            this._sw.Write(this._encloser + row[colName].ToString().PadRight(col.MaxLength, ' ') + this._encloser);
                    //        }
                    //    }
                    //    else
                    //    {
                    //        this._sw.Write(this._encloser + row[colName].ToString() + this._encloser);
                    //    }
                    //}
                    # endregion
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/26 DEL
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/26 ADD
                    // 最大長(バイト数指定)
                    int maxLength = CT_DEFAULT_MAXBYTECOUNT;
                    if ( _maxLengthList.ContainsKey( col.ColumnName ) )
                    {
                        maxLength = _maxLengthList[col.ColumnName];
                    }
                    
                    if ( this._formatList != null && !String.IsNullOrEmpty( this._formatList[colName] ) )
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
                    if ( row[colName] == DBNull.Value )
                    {
                        writeString = string.Empty;
                    }
                    else if ( col.DataType == typeof( DateTime ) )
                    {
                        writeString = ((DateTime)row[colName]).ToString( formatStr );
                        isString = true;
                    }
                    else if ( col.DataType == typeof( Int16 ) )
                    {
                        writeString = ((Int16)row[colName]).ToString( formatStr );
                    }
                    else if ( col.DataType == typeof( Int32 ) )
                    {
                        writeString = ((Int32)row[colName]).ToString( formatStr );
                    }
                    else if ( col.DataType == typeof( Int64 ) )
                    {
                        writeString = ((Int64)row[colName]).ToString( formatStr );
                    }
                    else if ( col.DataType == typeof( decimal ) )
                    {
                        writeString = ((decimal)row[colName]).ToString( formatStr );
                    }
                    else if ( col.DataType == typeof( float ) )
                    {
                        writeString = ((float)row[colName]).ToString( formatStr );
                    }
                    else if ( col.DataType == typeof( double ) )
                    {
                        writeString = ((double)row[colName]).ToString( formatStr );
                    }
                    else if ( col.DataType == typeof( string ) )
                    {
                        if ( _replaceList != null )
                        {
                            // 文字列のみReplaceListと比較
                            foreach ( KeyValuePair<string, string> rPage in this._replaceList )
                            {
                                if ( row[colName].ToString().Contains( rPage.Key ) )
                                {
                                    writeString = row[colName].ToString().Replace( rPage.Key, rPage.Value );
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
                    if ( this._fixedLength && maxLength > 0 )
                    {
                        if ( isString )
                        {
                            // 左詰め
                            //writeString = writeString.PadRight( maxLength, ' ' );
                            writeString = this.BytePadRight( writeString, maxLength );
                        }
                        else
                        {
                            // 右詰め
                            //writeString = writeString.PadLeft( maxLength, ' ' );
                            writeString = this.BytePadLeft( writeString, maxLength );
                        }
                    }

                    // 括り対象の型
                    if ( _enclosingTypeList.Contains( col.DataType ) )
                    {
                        writeString = this._encloser + writeString + this._encloser;
                    }

                    // 書き込み
                    this._sw.Write( writeString );
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/26 ADD

                    // 区切り文字を書き込む
                    if (lastColIndex > i) this._sw.Write(this._splitter);
                }

                // 改行
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/26 DEL
                //this._sw.Write("\r\n");
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/26 DEL
                // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/26 ADD
                this._sw.Write( Environment.NewLine );
                // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/26 ADD

                currentRow++;
            }

            #endregion // データ出力

            // 出力終了
            this._sw.Close();
            this._sw.Dispose();  //2010/06/22 yamaji ADD
            status = CT_RETURN_STATUS_OK;

            outputLineCount = currentRow;

            return status;
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/12/26 ADD
        /// <summary>
        /// バイト単位PadLeft処理（右寄せ）（"_____XXXXX"）
        /// </summary>
        /// <param name="writeString"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        private string BytePadLeft( string writeString, int maxLength )
        {
            writeString = writeString.Trim();

            // あふれた分を取り除く
            writeString = SubStringOfByte( writeString, maxLength );

            // バイト数取得
            int orgByteCount = _sjisEnc.GetByteCount( writeString );

            // 足りない分を空白で左に埋める
            return new string( ' ', maxLength - orgByteCount ) + writeString;
        }
        /// <summary>
        /// バイト単位PadRight処理（左寄せ）（"XXXXX_____"）
        /// </summary>
        /// <param name="writeString"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        private string BytePadRight( string writeString, int maxLength )
        {
            writeString = writeString.Trim();

            // あふれた分を取り除く
            writeString = SubStringOfByte( writeString, maxLength );

            // バイト数取得
            int orgByteCount = _sjisEnc.GetByteCount( writeString );

            // 足りない分を空白で右に埋める
            return writeString + new string( ' ', maxLength - orgByteCount );
        }
        /// <summary>
        /// 文字列　バイト数指定切り抜き
        /// </summary>
        /// <param name="encoding">エンコーディング</param>
        /// <param name="orgString">元の文字列</param>
        /// <param name="byteCount">バイト数</param>
        /// <returns>指定バイト数で切り抜いた文字列</returns>
        private string SubStringOfByte( string orgString, int byteCount )
        {
            string resultString = string.Empty;

            // あらかじめ「文字数」を指定して切り抜いておく
            // (この段階でbyte数は<文字数>～2*<文字数>の間になる)
            orgString = orgString.PadRight( byteCount ).Substring( 0, byteCount );

            int count;

            for ( int i = orgString.Length; i >= 0; i-- )
            {
                // 「文字数」を減らす
                resultString = orgString.Substring( 0, i );

                // バイト数を取得して判定
                count = _sjisEnc.GetByteCount( resultString );
                if ( count <= byteCount ) break;
            }

            // 後ろの余白を取り除いて返す
            return resultString.TrimEnd();
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/12/26 ADD

        #endregion

        // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- >>>>>

        #region 信越自動車個別開発用
        /// <summary>
        /// テキスト出力処理
        /// </summary>
        /// <param name="totalCount">outパラメータ 出力件数</param>
        /// <returns>正常:0, エラー:9</returns>
        /// <remarks>
        /// <br>Note	   : テキスト出力処理</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        public int SietuTextOut(out int totalCount)
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
                status = SietuOutputData(dt, out totalCount);
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
                    status = SietuOutputData(dt, out totalCount);
                }
            }
            else if (this._dataSource.GetType() == dv.GetType())
            {
                dv = (DataView)this._dataSource;
                dt = dv.ToTable();
                status = SietuOutputData(dt, out totalCount);
            }
            else
            {
                // DataSet, DataView, DataTable以外に対応する場合はelse ifを増やすこと
            }

            // 返り値は必要
            return status;
        }

        /// <summary>
        /// 出力メイン
        /// </summary>
        /// <param name="dt">出力対象となるデータテーブル</param>
        /// <param name="outputLineCount">出力件数</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note	   : 出力メイン</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private int SietuOutputData(DataTable dt, out int outputLineCount)
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
            #region データ出力
            this.ShowProgressDialog();
            bool cancelFlag = false;//Cancle フラグ

            rows = dt.Rows;
            foreach (DataRow row in rows)
            {
                //中断処理を行う
                if (_cancle)
                {
                    cancelFlag = true;
                    HideProgressDialog();
                    break;
                }
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
                            writeString = this.SietuBytePadRight(writeString, maxLength);
                        }
                        else
                        {
                            // 右詰め
                            writeString = this.SietuBytePadLeft(writeString, maxLength, colName);
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

            HideProgressDialog();

            if (cancelFlag)
            {
                status = CT_RETURN_STATUS_CANCLE;
            }

            return status;
        }

        /// <summary>
        /// バイト単位PadRight処理（左寄せ）（"XXXXX_____"）
        /// </summary>
        /// <param name="writeString"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note	   : 出力メイン</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private string SietuBytePadRight(string writeString, int maxLength)
        {
            // あふれた分を取り除く
            writeString = SubStringOfByte(writeString, maxLength);

            // バイト数取得
            int orgByteCount = _sjisEnc.GetByteCount(writeString);

            // 足りない分を空白で右に埋める
            return writeString + new string(' ', maxLength - orgByteCount);
        }

        /// <summary>
        /// バイト単位PadLeft処理（右寄せ）（"_____XXXXX"）
        /// </summary>
        /// <param name="writeString"></param>
        /// <param name="maxLength"></param>
        /// <param name="colName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note	   : 出力メイン</br>
        /// <br>Programmer : licb</br>
        /// <br>Date       : K2014/03/10</br>
        /// </remarks>
        private string SietuBytePadLeft(string writeString, int maxLength, string colName)
        {
            writeString = writeString.Trim();

            if (colName.Equals("StockCount") || colName.Equals("StockAmountPrice"))
            {
                if (writeString.IndexOf('-') >= 0&&(writeString.Length > maxLength))
                {
                    maxLength = maxLength + 1;
                }
            }

            // あふれた分を取り除く
            writeString = SubStringOfByte(writeString, maxLength);

            // バイト数取得
            int orgByteCount = _sjisEnc.GetByteCount(writeString);

            // 足りない分を空白で左に埋める
            return new string(' ', maxLength - orgByteCount) + writeString;
        }

        # region [処理中ダイアログ]
        // 印刷ダイアログ
        private SFCMN00299CA _progressDialog;
        private bool _progressDialogDisposed;
        private bool _cancle;

        /// <summary>
        /// 処理中ダイアログ表示
        /// </summary>
        public void ShowProgressDialog()
        {
            _progressDialogDisposed = false;

            if (_progressDialog == null)
            {
                _progressDialog = new SFCMN00299CA();
                _progressDialog.Title = "出力処理";
                _progressDialog.DispCancelButton = true;
                _progressDialog.CancelButtonClick += new EventHandler(ProgressDialog_CancelButtonClick);
            }
            _progressDialog.Message = "現在、出力中です。";
            _progressDialog.Show();
        }
        /// <summary>
        /// 処理中ダイアログキャンセル時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressDialog_CancelButtonClick(object sender, EventArgs e)
        {
            // キャンセル処理呼び出し
            this.Cancel();
        }
        /// <summary>
        /// 処理中ダイアログ終了
        /// </summary>
        public void HideProgressDialog()
        {
            if (_progressDialog != null)
            {
                if (!_progressDialogDisposed)
                {
                    _progressDialog.Dispose();
                    _progressDialog = null;
                    _progressDialogDisposed = true;
                }
            }
        }
        /// <summary>
        /// キャンセル処理
        /// </summary>
        public void Cancel()
        {

            // キャンセルメッセージ表示
            if (_progressDialog != null)
            {
                _progressDialog.Message = "中断します。";
            }
            _cancle = true;
        }

        # endregion

        #endregion
        // --- ADD licb K2014/03/10 FOR 信越自動車商会個別開発 テキスト出力機能を追加する --- <<<<<
    }
}
