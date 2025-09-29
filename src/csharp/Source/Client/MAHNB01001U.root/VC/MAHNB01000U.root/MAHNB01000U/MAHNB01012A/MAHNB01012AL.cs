using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Library.Collections;
using System.Windows.Forms;
using System.Drawing;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 調査用操作ログ出力アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 調査用操作ログ出力機能。</br>
    /// <br>Programmer : 曹文傑</br>
    /// <br>Date       : 2011/02/11</br>
    /// <br>Update Note: 2011/03/07 曹文傑</br>
    /// <br>             Redmine #19637の対応</br>
    /// <br>Update Note: 2013/01/24 鄧潘ハン</br>
    /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
    /// <br>             Redmine#34141 一括値引功能を追加についての対応</br>
    /// <br></br>
    /// </remarks>
    public class SurveyUseLogOutputAcs
    {
        #region ■プライベート変数
        // bmpファイル保存用
        private Bitmap _bmp;

        // ファイル名
        private string _fileName = string.Empty;

        // ファイル名生成用
        private DateTime dateTime;

        private List<LogData> logList = null;

        public bool _isErrorFlag = false;
        #endregion

        #region ■Const Members
        private const string preFileName = "ErrorLog_MAHNB01001U_";
        private const string txtEndFileName = ".csv";
        private const string datEndFileName = ".dat";
        private const string bmpEndFileName = ".bmp";
        private const string timeFormat = "yyyyMMddHHmmss";
        //private const string filePath = @"C:\\Program Files\\Partsman\\Log\\";   // DEL 2011/03/07
        #endregion

        #region ■Constructor
        public SurveyUseLogOutputAcs()
        {
            this.dateTime = new DateTime();
            this.logList = new List<LogData>();
        }
        #endregion

        #region ■プライベート メソッド
        /// <summary>
        /// エラーデータクラスをファイルにシリアライズ
        /// </summary>
        /// <param name="customSerializeArrayList">売上リスト</param>
        /// <remarks>
        /// <br>Note       : エラーデータクラスをファイルにシリアライズする。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/11</br> 
        /// <br>Update Note: 2011/03/07 曹文傑</br>
        /// <br>             Redmine #19637の対応</br>
        /// </remarks>
        private void OutputErrorDateFile(CustomSerializeArrayList customSerializeArrayList)
        {
            if (this.dateTime == DateTime.MinValue)
            {
                this.SetDateTime();
            }
            // ファイル名の生成
            string datFileName = preFileName + this.dateTime.ToString(timeFormat) + datEndFileName;
            string filePath = Path.GetFullPath(Path.Combine("log", datFileName)); // ADD 2011/03/07
            object obj = customSerializeArrayList;

            //System.IO.FileStream mem = new System.IO.FileStream(filePath + datFileName, System.IO.FileMode.OpenOrCreate); // DEL 2011/03/07
            System.IO.FileStream mem = new System.IO.FileStream(filePath, System.IO.FileMode.OpenOrCreate); // ADD 2011/03/07
            System.IO.BinaryWriter bWriter = new System.IO.BinaryWriter(mem);

            CustomSerializeArrayList_SerializationSurrogate_For_V51010 serializer
                                             = new CustomSerializeArrayList_SerializationSurrogate_For_V51010();
            serializer.Serialize(bWriter, obj);

            mem.Close();
            mem.Dispose();
            bWriter.Close();
        }

        /// <summary>
        /// 画面キャプチャ画像をbmpファイルに出力
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面キャプチャ画像をbmpファイルに出力する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/11</br> 
        /// <br>Update Note: 2011/03/07 曹文傑</br>
        /// <br>             Redmine #19637の対応</br>
        /// </remarks>
        private void OutputBmpFile()
        {
            if (this.dateTime == DateTime.MinValue)
            {
                this.SetDateTime();
            }
            // ファイル名の生成
            string bmpFileName = preFileName + this.dateTime.ToString(timeFormat) + bmpEndFileName;
            string filePath = Path.GetFullPath(Path.Combine("log", bmpFileName)); // ADD 2011/03/07

            if (this._bmp == null)
            {
                this.CacheImage();
            }

            //this._bmp.Save(filePath + bmpFileName); // DEL 2011/03/07
            this._bmp.Save(filePath); // ADD 2011/03/07
        }

        /// <summary>
        /// 操作分類と内容を取る
        /// </summary>
        /// <param name="logNo">ログ番号</param>
        /// <param name="slipNo">伝票番号など</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <remarks>
        /// <br>Note       : 操作分類と内容を取る。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/11</br> 
        /// <br>Update Note: 2013/01/24 鄧潘ハン</br>
        /// <br>管理番号   : 10806793-00 2013/03/13配信分</br>
        /// <br>             Redmine#34141 一括値引功能を追加についての対応</br>
        /// </remarks>
        private string GetLogFromLogNo(int logNo, int slipNo, int acptAnOdrStatus)
        {
            string logText = string.Empty;

            #region 操作分類と内容を取る。
            switch (logNo)
            {
                case 1:
                    logText = "START,起動";
                    break;
                case 2:
                    logText = "FUNCTION,終了(F1)";
                    break;
                case 3:
                    logText = "FUNCTION,新規(F9)";
                    break;
                case 4:
                    logText = "FUNCTION,確定(F10)";
                    break;
                case 5:
                    logText = "FUNCTION,保存(F10)";
                    break;
                case 6:
                    logText = "FUNCTION,伝票削除(F12)";
                    break;
                case 7:
                    logText = "FUNCTION,戻る(F2)";
                    break;
                case 8:
                    logText = "FUNCTION,進む(F3)";
                    break;
                case 9:
                    logText = "FUNCTION,検索切替(F4)";
                    break;
                case 10:
                    logText = "FUNCTION,ガイド(F5)";
                    break;
                case 11:
                    logText = "FUNCTION,伝票呼出(X)";
                    break;
                case 12:
                    logText = "FUNCTION,貸出計上(I)";
                    break;
                case 13:
                    logText = "FUNCTION,受注計上(H)";
                    break;
                case 14:
                    logText = "FUNCTION,見積計上(Q)";
                    break;
                case 15:
                    logText = "FUNCTION,見出貼付(F6)";
                    break;
                case 16:
                    logText = "FUNCTION,更新(V)";
                    break;
                case 17:
                    logText = "FUNCTION,元に戻す(U)";
                    break;
                case 18:
                    logText = "FUNCTION,赤伝(R)";
                    break;
                case 19:
                    logText = "FUNCTION,返品(Y)";
                    break;
                case 20:
                    logText = "FUNCTION,伝票複写(P)";
                    break;
                case 21:
                    logText = "FUNCTION,設定(O)";
                    break;
                case 22:
                    logText = "FUNCTION,最新情報(A)";
                    break;
                case 23:
                    logText = "ACTION,コピー(C)";
                    break;
                case 24:
                    logText = "ACTION,貼り付け(V)";
                    break;
                case 25:
                    logText = "ACTION,挿入(I)";
                    break;
                case 26:
                    logText = "ACTION,削除(F11)";
                    break;
                case 27:
                    logText = "ACTION,切り取り(T)";
                    break;
                case 28:
                    logText = "ACTION,入力切替(F7)";
                    break;
                case 29:
                    logText = "ACTION,仕入(F6)";
                    break;
                case 30:
                    logText = "ACTION,発注(F12)";
                    break;
                case 31:
                    logText = "ACTION,行値引(M)";
                    break;
                case 32:
                    logText = "ACTION,商品値引(N)";
                    break;
                case 33:
                    logText = "ACTION,注釈(L)";
                    break;
                case 34:
                    logText = "ACTION,車種変更(S)";
                    break;
                case 35:
                    logText = "ACTION,在庫検索(Z)";
                    break;
                case 36:
                    logText = "ACTION,倉庫切替(F8)";
                    break;
                case 37:
                    logText = "ACTION,TBO(B)";
                    break;
                case 38:
                    logText = "ACTION,前行複写(J)";
                    break;
                case 39:
                    logText = "ACTION,一括複写(K)";
                    break;
                case 40:
                    logText = "READ,伝票読込（伝票番号=" + slipNo.ToString("D9") + "、受注ステータス=" + acptAnOdrStatus.ToString("D2") + "）";
                    break;
                case 41:
                    logText = "WRITE,伝票登録（伝票番号=" + slipNo.ToString("D9") + "、受注ステータス=" + acptAnOdrStatus.ToString("D2") + "）";
                    break;
                case 42:
                    logText = "ERROR,伝票登録（伝票番号=" + slipNo.ToString("D9") + "、受注ステータス=" + acptAnOdrStatus.ToString("D2") + "）";
                    break;
                case 43:
                    logText = ",受注ステータス=" + acptAnOdrStatus.ToString("D2");
                    break;
                case 44:
                    logText = ",売上伝票区分=" + slipNo.ToString();
                    break;
                case 45:
                    logText = ",売上伝票番号=" + slipNo.ToString("D9");
                    break;
                case 46:
                    logText = ",売上行番号=" + slipNo.ToString();
                    break;
                case 47:
                    logText = ",売上日付=" + slipNo.ToString("####/##/##");
                    break;
                case 48:
                    logText = ",拠点コード=" + slipNo.ToString("D2");
                    break;
                case 49:
                    logText = ",得意先コード=" + slipNo.ToString("D8");
                    break;
                // ----ADD 2013/01/24 鄧潘ハン REDMINE#34141---- >>>>>
                case 50:
                    logText = "FUNCTION,一括値引(E)";
                    break;
                // ----ADD 2013/01/24 鄧潘ハン REDMINE#34141---- <<<<<
                default:
                    break;
            }
            #endregion

            return logText;
        }
        #endregion

        #region ■パブリック メソッド
        /// <summary>
        /// ログを内部保持するログリストに追加
        /// </summary>
        /// <param name="logNo">ログ番号</param>
        /// <param name="slipNo">伝票番号など</param>
        /// <param name="acptAnOdrStatus">受注ステータス</param>
        /// <remarks>
        /// <br>Note       : ログを内部保持するログリストに追加する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/11</br> 
        /// </remarks>
        public void AddLine(int logNo, int slipNo, int acptAnOdrStatus)
        {
            // ログが100件を超える場合は、最初の１レコードをリストから削除する。
            if (this.logList.Count == 100)
            {
                this.logList.RemoveAt(0);
            }

            // 内部的にログ出力予定の内容のデータを生成
            LogData logData = new LogData();
            DateTime dt = DateTime.Now;
            logData.SysDateTime = dt.Ticks;                    //日時
            logData.LogNo = (byte)logNo;                       //ログ番号
            logData.SalesSlipNo = slipNo;                      //売上伝票番号など
            logData.AcptAnOdrStatus = (byte)acptAnOdrStatus;   //受注ステータス

            logList.Add(logData);
        }

        /// <summary>
        /// 画面内容をキャプチャして内部保持
        /// </summary>
        /// <remarks>
        /// <br>Note       : 画面内容をキャプチャして内部保持する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/11</br> 
        /// </remarks>
        public void CacheImage()
        {
            // 画面内容保存
            int count = Screen.AllScreens.Length;
            this._bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width * count, Screen.PrimaryScreen.Bounds.Height);
            Graphics g = Graphics.FromImage(this._bmp);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), _bmp.Size);
            g.Dispose();
        }

        /// <summary>
        /// 伝票登録ＯＫのログをログリストに追加
        /// </summary>
        /// <param name="customSerializeArrayList">売上リスト</param>
        /// <remarks>
        /// <br>Note       : 伝票登録ＯＫのログをログリストに追加する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/11</br> 
        /// <br>Update Note: 2011/03/07 曹文傑</br>
        /// <br>             Redmine #19637の対応</br>
        /// </remarks>
        public void Succeed(CustomSerializeArrayList customSerializeArrayList)
        {
            // 伝票登録OKの場合、ログエータをログリストに追加する
            SalesSlipWork salesSlipWork = new SalesSlipWork();
            foreach (object obj in customSerializeArrayList)
            {
                if (obj is SalesSlipWork)
                {
                    salesSlipWork = (SalesSlipWork)obj;
                }
                else
                {
                    continue;
                }

                // ログエータをログリストに追加する
                int salesSlipNum = 0;
                bool isIntFlg = int.TryParse(salesSlipWork.SalesSlipNum, out salesSlipNum);
                if (isIntFlg == false) return;
                this.AddLine(41, salesSlipNum, salesSlipWork.AcptAnOdrStatus);
            }

            // ログエータをログリストに追加前、２回前の伝票登録ＯＫのログよりも前のログは、ログリストから削除する。
            List<LogData> logDateList = new List<LogData>();
            int writeLogNoCount = 0;
            for (int i = this.logList.Count - 1; i >= 0; i--)
            {
                if (i != this.logList.Count - 1)
                {
                    if (writeLogNoCount > 3)
                    {
                        break;
                    }

                    if (logList[i].LogNo == logList[i + 1].LogNo)
                    {
                        logDateList.Add(logList[i]);
                    }

                    if (logList[i].LogNo != logList[i + 1].LogNo && (logList[i].LogNo == 41 || logList[i + 1].LogNo == 41))
                    {
                        writeLogNoCount++;
                        // ---UPD 2011/03/07------------->>>>
                        //logDateList.Add(logList[i]);
                        if (writeLogNoCount != 4)
                        {
                            logDateList.Add(logList[i]);
                        }
                        // ---UPD 2011/03/07-------------<<<<
                    }

                    if (logList[i].LogNo != logList[i + 1].LogNo && logList[i].LogNo != 41 && logList[i + 1].LogNo != 41)
                    {
                        logDateList.Add(logList[i]);
                    }
                }
                else
                {
                    if ((int)logList[i].LogNo == 41)
                    {
                        writeLogNoCount++;
                        logDateList.Add(logList[i]);
                    }
                }
            }
            logDateList.Reverse();
            this.logList = logDateList;

            // CacheImageで生成したbmp情報を破棄する。
            this._bmp = null;
        }

        /// <summary>
        /// ログファイルとエラーデータファイルを出力
        /// </summary>
        /// <param name="customSerializeArrayList">売上リスト</param>
        /// <remarks>
        /// <br>Note       : ログファイルとエラーデータファイルを出力する。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/11</br> 
        /// <br>Update Note: 2011/03/07 曹文傑</br>
        /// <br>             Redmine #19637の対応</br>
        /// </remarks>
        public void WriteErrorLog(CustomSerializeArrayList customSerializeArrayList)
        {
            #region ログリストの内容をログファイル(.txt)に出力
            if (this.dateTime == DateTime.MinValue)
            {
                this.SetDateTime();
            }
            // ファイル名の生成
            string txtFileName = preFileName + this.dateTime.ToString(timeFormat) + txtEndFileName;
            string filePath = Path.GetFullPath(Path.Combine("log", "")); // ADD 2011/03/07
            System.IO.FileStream fs = null; ;										// ファイルストリーム
            System.IO.StreamWriter sw = null; ;										// ストリームwriter
            string textContent = string.Empty;
            DateTime dt;
            try
            {
                if (Directory.Exists(filePath))
                {
                    // なし。
                }
                else
                {
                    Directory.CreateDirectory(filePath);
                }
                filePath = Path.GetFullPath(Path.Combine("log", txtFileName)); // ADD 2011/03/07
                //fs = new FileStream(filePath + txtFileName, FileMode.Append, FileAccess.Write, FileShare.Write); // DEL 2011/03/07
                fs = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Write); // ADD 2011/03/07
                sw = new System.IO.StreamWriter(fs, System.Text.Encoding.GetEncoding("shift_jis"));
                foreach (LogData logData in this.logList)
                {
                    dt = new DateTime(logData.SysDateTime);
                    textContent = dt.ToString("yyyy/MM/dd") + "," + dt.ToString("HH:mm:ss") + "," + GetLogFromLogNo(logData.LogNo, logData.SalesSlipNo, logData.AcptAnOdrStatus);
                    sw.WriteLine(textContent);
                }
            }
            catch
            {
                // なし。
            }
            finally
            {
                if (sw != null)
                    sw.Close();
                if (fs != null)
                    fs.Close();
            }
            #endregion

            // エラーデータファイルを出力
            this.OutputErrorDateFile(customSerializeArrayList);

            // 画面キャプチャ画像をbmpファイルに出力
            this.OutputBmpFile();
            // 画面キャプチャ画像をbmpファイルに出力した後、メモリ上のbmp情報を破棄する。
            this._bmp = null;
        }

        /// <summary>
        /// システム時間を取る（ファイル名を取る用）
        /// </summary>
        /// <remarks>
        /// <br>Note       : システム時間を取る。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/11</br> 
        /// </remarks>
        public void SetDateTime()
        {
            this.dateTime = DateTime.Now;
        }

        /// <summary>
        /// システム時間を取る（登録前のチェック用）
        /// </summary>
        /// <remarks>
        /// <br>Note       : システム時間を取る（登録前のチェック用）</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2011/02/11</br> 
        /// </remarks>
        public DateTime GetDateTime()
        {
            if (this.dateTime == DateTime.MinValue)
            {
                this.SetDateTime();
            }
            return this.dateTime;
        }
        #endregion
    }
}
