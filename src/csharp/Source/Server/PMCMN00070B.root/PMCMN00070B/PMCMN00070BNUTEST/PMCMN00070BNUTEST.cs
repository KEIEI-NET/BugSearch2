using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;
using Broadleaf.Library.Diagnostics;

namespace Broadleaf.TestTools.UnitTesting
{
    [TestFixture]
    public class PMCMN00070BNUTEST
    {
        private CLCLogTextOut cLCLogTextOut = null;

        /// <param name="pgId">PGID</param>
        /// <param name="productId">プロダクトID</param>
        /// <param name="message">LOG出力メッセージ</param>
        /// <param name="status">ステータス</param>
        /// <param name="exPara">例外エラー内容</param>
        /// <param name="ret">戻り値(正常時：ファイル名, エラー時：空白)</param>
        [TestCase("", "", "", 0, null, true, "")]                                   // ①不正ケース(全て未指定)(文字項目=空白)
        [TestCase(null, null, null, 0, null, true, "")]                             // ②不正ケース(全て未指定)(文字項目=NULL)
        [TestCase("", "Partsman", "Test1", 1000, null, true, "")]                   // ③不正ケース(PGID未指定)
        [TestCase("PMCMN00070BNUTEST", "", "", 0, null, false, "")]                 // ④正常ケース(PGID以外未指定)(文字項目=空白)
        [TestCase("PMCMN00070BNUTEST", null, null, 0, null, false, "")]             // ⑤正常ケース(PGID以外未指定)(文字項目=NULL)
        [TestCase("PMCMN00070BNUTEST", "Partsman", "Test2", 1000, null, false, "")] // ⑥正常ケース(エラー時パラメータ)
        [TestCase("PMCMN00070BNUTEST", "Partsman", "Test1", 0, null, false, "")]    // ⑦正常ケース(正常時のパラメータ)
        public void OutputClcLog(string pgId, string productId, string message, Int32 status, Exception exPara, bool equalFlg, string ret)
        {
            cLCLogTextOut = new CLCLogTextOut();

            if (message == "Test2")
            {
                exPara = new Exception("例外エラー");
            }

            string ret2 = cLCLogTextOut.OutputClcLog(pgId, productId, message, status, exPara);

            if (equalFlg)
                Assert.AreEqual(ret2, ret);
            else
                Assert.AreNotEqual(ret2, ret);
        }

        /// <summary>
        /// ファイルコピー処理
        /// </summary>
        /// <param name="fileFullPath">コピー元ファイルのフルパス</param>
        /// <param name="status">ステータス([0:成功, 4:コピー元ファイルが存在しない, 9:コピー失敗, -1:例外エラー)</param>
        [TestCase("D:\\test\\a\\Client.txt", 0)]         // ①正常ケース(ファイル有り)
        [TestCase("D:\\test\\a\\Client_Dummy.txt", 4)]   // ②不正ケース(ファイル無し)
        [TestCase("D:\\test\\a\\Cli", 4)]                // ③不正ケース(ファイル無し)(ファイル名不完全)
        [TestCase("D:\\test\\a", 4)]                     // ④不正ケース(ファイル無し)(フォルダ指定)
        [TestCase(null, 4)]                              // ⑤不正ケース(ファイル無し)(null)
        [TestCase("", 4)]                                // ⑥不正ケース(ファイル無し)(空白)
        [TestCase("D:\\test\\a\\Client_Fail.txt", 9)]    // ⑦不正ケース(書込み不可)
        // ⑧不正ケース(ファイル名超過例外)
        [TestCase("D:\\test\\a\\Client_FULL123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012341234567890123456789012345678901234567890.txt", -1)]
        public void CopyClcLogFile(string fileFullPath, int status)
        {
            cLCLogTextOut = new CLCLogTextOut();
            int st = cLCLogTextOut.CopyClcLogFile(fileFullPath);
            Assert.AreEqual(st, status);
        }
    }
}
