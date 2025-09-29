using System;
using System.Text;

namespace Broadleaf.Windows.Forms
{
    internal static class TspXMLDecryptTableResource
    {
        /// <summary>
        /// 初期化ベクタ
        /// </summary>
        public static readonly byte[] InitVector = Encoding.Default.GetBytes("BRLFTSPN");

        /// <summary>
        /// 月毎ラウンドキーテーブル
        /// </summary>
        public static readonly byte[] Key = Encoding.Default.GetBytes("yｻﾙ5nuvｱSqs2vｻsQ");
    }
}
