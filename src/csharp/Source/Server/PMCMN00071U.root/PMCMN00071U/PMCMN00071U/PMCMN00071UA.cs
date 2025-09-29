using System;

namespace Broadleaf.Application.Batch
{
    /// <summary>
    /// LSMログ出力実行クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : LSMログファイルを変換しCLCログディレクトリに保存します。</br>
    /// <br>Programmer : 佐々木 亘</br>
    /// <br>Date       : 2015/05/26</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class PMCMN00071UA
    {
        /// <summary>
        /// Main処理
        /// </summary>
        /// <param name="args">引数</param>
        public static void Main(string[] args)
        {
            // LSMログファイル操作クラス
            LSMLogFileControl lsmLogFileCtrl = new LSMLogFileControl();

            // CLC用LSMログファイルを作成実行
            lsmLogFileCtrl.CopyLSMToCLCLogFileMain();
        }
    }
}
