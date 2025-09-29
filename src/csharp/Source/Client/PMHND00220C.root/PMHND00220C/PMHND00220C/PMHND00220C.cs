//****************************************************************************//
// システム         : PM.NS                                                   //
// プログラム名称   : 商品バーコード関連付けファイル削除処理                  //
// プログラム概要   : 商品バーコード関連付けファイル削除処理 クラス           //
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.                       //
//============================================================================//
// 履歴                                                                       //
//----------------------------------------------------------------------------//
// 管理番号  11370006-00 作成担当 : 3H 余斐                                 　//
// 作 成 日  2017/07/20  修正内容 : 新規作成                                  //
//----------------------------------------------------------------------------//
// 管理番号  11470154-00 作成担当 : 陳艶丹                                    //
// 修 正 日  2018/10/16  修正内容 : ハンディターミナル五次対応                //
//----------------------------------------------------------------------------//
using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;

namespace PMHND00220C
{
    /// <summary>
    /// 商品バーコード関連付けファイル削除処理
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード関連付けファイル削除処理</br>
    /// <br>Programmer : 3H 余斐</br>
    /// <br>Date       : 2017/07/20</br>
    /// <br>Update Note: 2018/10/16 陳艶丹</br>
    /// <br>　　　　　 : ハンディターミナル五次対応</br>
    /// </remarks>
    static class PMHND00220C
    {
        # region private field
        /// <summary>ユーザー設定</summary>
        private static GoodsBarCodeRevnExtractTextUserConst UserSetting = null;

        /// <summary>検品照会ユーザー設定</summary>
        private static PrevInputValue InspectInfoSetting = null;// ADD 陳艶丹 2018/10/16 
        #endregion

        #region Const Memebers
        /// <summary>ファイル削除期限 ※単位：分（24H）</summary>
        private const int ThresholdSpan = 60 * 24;

        /// <summary>設定XMLファイル名</summary>
        private const string XmlFileName = "PMHND09210UC_Construction.XML";
        /// <summary>検品照会設定XMLファイル名</summary>
        private const string InspectXmlFileName = "PMHND04200U_Construction.XML";// ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応

        #endregion

        /// <summary>
        /// 商品バーコード関連付けファイル削除処理メインメソッド
        /// </summary>
        /// <param name="args">起動パラメータ</param>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けファイル削除処理メインメソッド</br>
        /// <br>Programmer : 3H 余斐</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2018/10/16 陳艶丹</br>
        /// <br>　　　　　 : ハンディターミナル五次対応</br>
        /// </remarks>
        static void Main(string[] args)
        {
            try
            {
                string msg = null;
                DateTime time = DateTime.Now;// ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応
                //アプリケーション開始準備処理。第二パラメータはアプリケーションのソフトウェアコードが指定出来る場合は指定。出来ない場合はプロダクトコード
                int status = ApplicationStartControl.StartApplication(out msg, ref args, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));

                if (status == 0)
                {
                    // 商品バーコード関連付けファイル出力ディレクトリ取得
                    string exportDirPath = GetTextFileExportDirPath();

                    // ファイル削除処理を行う
                    // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
                    //DeleteTxtFile(exportDirPath, DateTime.Now);
                    DeleteTxtFile(exportDirPath, time);

                    // 検品照会関連付けファイル出力ディレクトリ取得
                    string inspectExportDirPath = GetInspectFileExportDirPath();
                    // ファイル削除処理を行う
                    DeleteTxtFile(inspectExportDirPath, time);
                    // --- UPD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
                }
            }
            catch (Exception ex)
            {
                //エラーログを出力する
                TMsgDisp.Show(null, emErrorLevel.ERR_LEVEL_NODISP, "PMHND00220C.exe", "削除処理に失敗した", "", "", ex.Message, -1, null, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);
            }
            finally
            {
                ApplicationStartControl.EndApplication();
            }
        }

        /// <summary>
        /// アプリケーション終了イベント
        /// </summary>
        /// <param name="sender">対象オブジェクト</param>
        /// <param name="e">イベントハンドラ</param>
        /// <remarks>
        /// <br>Note       : アプリケーション終了イベント</br>
        /// <br>Programmer : 3H 余斐</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private static void ApplicationReleased(object sender, EventArgs e)
        {
            //メッセージを出す前に全て開放
            ApplicationStartControl.EndApplication();
        }

        #region 商品バーコード関連付けファイル削除処理
        /// <summary>
        /// 商品バーコード関連付けファイル削除処理
        /// </summary>
        /// <param name="exportDirPath">商品バーコード関連付けファイルの出力パス</param>
        /// <param name="now">ファイル作成の経過時間の基準時刻</param>
        /// <remarks>
        /// <br>Note       : 指定ディレクトリ配下の対象ファイルを検索・削除する</br>
        /// <br>Programmer : 3H 余斐</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private static void DeleteTxtFile(string exportDirPath, DateTime now)
        {
            if (string.IsNullOrEmpty(exportDirPath))
            {
                //パスが無効な場合、処理を抜ける
                return;
            }

            System.IO.DirectoryInfo DirectoryInfo = new System.IO.DirectoryInfo(exportDirPath);

            // 出力ディレクトリの存在チェック
            if (DirectoryInfo.Exists)
            {
                try
                {
                    FileInfo[] Files = DirectoryInfo.GetFiles("*.*");

                    foreach (FileInfo File in Files)
                    {
                        // ファイルの存在チェック
                        if (File.Exists)
                        {
                            // 更新日時が24H以上経過したファイルのみ対象とする
                            DateTime UpdateFileTime = System.IO.File.GetLastWriteTime(File.FullName);
                            TimeSpan DiffTime = now.Subtract(UpdateFileTime);

                            // 更新日時が24H(1440分以上)以上経過したかチェック
                            if (DiffTime.TotalMinutes >= ThresholdSpan)
                            {
                                try
                                {
                                    // 読み取り専用属性の場合、削除前に属性解除する
                                    if ((File.Attributes & System.IO.FileAttributes.ReadOnly) == System.IO.FileAttributes.ReadOnly)
                                    {
                                        File.Attributes = System.IO.FileAttributes.Normal;
                                    }

                                    // ファイルの削除
                                    File.Delete();

                                }
                                catch (Exception ex)
                                {
                                    if (ex is System.UnauthorizedAccessException)
                                    {
                                        // ファイルのアクセス権限がなかった場合、ログを出力して次のファイルへ
                                        TMsgDisp.Show(null, emErrorLevel.ERR_LEVEL_NODISP, "PMHND00220C.exe", "アクセス権限拒否", "", "", ex.Message, -1, null, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                                    }
                                    else
                                    {
                                        //その他のIOエラーの場合、次のファイルへ
                                        TMsgDisp.Show(null, emErrorLevel.ERR_LEVEL_NODISP, "PMHND00220C.exe", "削除処理に失敗した", "", "", ex.Message, -1, null, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (ex is System.UnauthorizedAccessException)
                    {
                        // ディレクトリのアクセス権限がなかった場合、ログを出力する
                        TMsgDisp.Show(null, emErrorLevel.ERR_LEVEL_NODISP, "PMHND00220C.exe", "アクセス権限拒否", "", "", ex.Message, -1, null, ex, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxDefaultButton.Button1);
                    }
                }
            }
        }

        #endregion    

        #region 出力ディレクトリ取得
        /// <summary>
        /// 商品バーコード関連付けファイル出力ディレクトリ取得
        /// </summary>
        /// <returns>商品バーコード関連付けファイル出力ディレクトリ</returns>
        /// <remarks>
        /// <br>Note       : 商品バーコード関連付けファイル出力ディレクトリ取得</br>
        /// <br>Programer  : 3H 余斐</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        private static string GetTextFileExportDirPath()
        {
            string ExportDirPath = null;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XmlFileName)))
            {
                try
                {
                    // ユーザー設定の読み込み
                    UserSetting = UserSettingController.DeserializeUserSetting<GoodsBarCodeRevnExtractTextUserConst>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XmlFileName));
                }
                catch
                {
                    UserSetting = new GoodsBarCodeRevnExtractTextUserConst();
                }

                ExportDirPath = UserSetting.OutputFilePath;
            }

            return ExportDirPath;
        }
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
        /// <summary>
        /// 検品照会関連付けファイル出力ディレクトリ取得
        /// </summary>
        /// <returns>検品照会関連付けファイル出力ディレクトリ</returns>
        /// <remarks>
        /// <br>Note       : 検品照会関連付けファイル出力ディレクトリ取得</br>
        /// <br>Programmer : 陳艶丹</br>
        /// <br>Date       : 2018/10/16</br>
        /// </remarks>
        private static string GetInspectFileExportDirPath()
        {
            string inspectExportDirPath = null;

            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, InspectXmlFileName)))
            {
                try
                {
                    // ユーザー設定の読み込み
                    InspectInfoSetting = UserSettingController.DeserializeUserSetting<PrevInputValue>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, InspectXmlFileName));
                }
                catch
                {
                    InspectInfoSetting = new PrevInputValue();
                }

                inspectExportDirPath = InspectInfoSetting.OutputFilePath;
            }

            return inspectExportDirPath;
        }
        // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
        #endregion       
    }

    /// <summary>
    /// 商品バーコード一括登録用ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 商品バーコード一括登録のユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : 3H 余斐</br>
    /// <br>Date       : 2017/07/20</br>
    /// </remarks>
    [Serializable]
    public class GoodsBarCodeRevnExtractTextUserConst
    {
        #region プライベート変数
        // 出力パス
        private string _outputFilePath;
        // 出力ファイル名
        private string _outputFileName;
        #endregion

        #region プロパティ
        /// <summary>出力パス</summary>
        public string OutputFilePath
        {
            get { return _outputFilePath; }
            set { _outputFilePath = value; }
        }

        /// <summary>出力ファイル名</summary>
        public string OutputFileName
        {
            get { return _outputFileName; }
            set { _outputFileName = value; }
        }
        #endregion
    }

    // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応---------->>>>>
    # region 
    /// <summary>
    /// 検品照会ユーザー設定クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検品照会ユーザー設定情報を管理するクラス</br>
    /// <br>Programmer : 陳艶丹</br>
    /// <br>Date       : 2018/10/16</br>
    /// </remarks>
    [Serializable]
    public class PrevInputValue
    {
        // 取寄区分
        private int _orderDivCd;

        // パターン区分
        private int _patternDiv;

        // 出力パス
        private string _outputFilePath;
        // 出力ファイル名
        private string _outputFileName;

        /// <summary>
        /// 検品照会ユーザー設定クラス
        /// </summary>
        public PrevInputValue()
        {

        }

        /// <summary>
        /// 取寄区分
        /// </summary>
        public int OrderDivCd
        {
            get { return _orderDivCd; }
            set { _orderDivCd = value; }
        }

        /// <summary>
        /// パターン区分
        /// </summary>
        public int PatternDiv
        {
            get { return _patternDiv; }
            set { _patternDiv = value; }
        }

        /// <summary>
        /// 出力パス
        /// </summary>
        public string OutputFilePath
        {
            get { return _outputFilePath; }
            set { _outputFilePath = value; }
        }

        /// <summary>
        /// 出力ファイル名
        /// </summary>
        public string OutputFileName
        {
            get { return _outputFileName; }
            set { _outputFileName = value; }
        }
    }
    #endregion
    // --- ADD 陳艶丹 2018/10/16 ハンディターミナル五次対応----------<<<<<
}