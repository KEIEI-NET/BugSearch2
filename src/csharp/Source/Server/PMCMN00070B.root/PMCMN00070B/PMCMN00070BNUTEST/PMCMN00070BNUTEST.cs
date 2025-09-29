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
        /// <param name="productId">�v���_�N�gID</param>
        /// <param name="message">LOG�o�̓��b�Z�[�W</param>
        /// <param name="status">�X�e�[�^�X</param>
        /// <param name="exPara">��O�G���[���e</param>
        /// <param name="ret">�߂�l(���펞�F�t�@�C����, �G���[���F��)</param>
        [TestCase("", "", "", 0, null, true, "")]                                   // �@�s���P�[�X(�S�Ė��w��)(��������=��)
        [TestCase(null, null, null, 0, null, true, "")]                             // �A�s���P�[�X(�S�Ė��w��)(��������=NULL)
        [TestCase("", "Partsman", "Test1", 1000, null, true, "")]                   // �B�s���P�[�X(PGID���w��)
        [TestCase("PMCMN00070BNUTEST", "", "", 0, null, false, "")]                 // �C����P�[�X(PGID�ȊO���w��)(��������=��)
        [TestCase("PMCMN00070BNUTEST", null, null, 0, null, false, "")]             // �D����P�[�X(PGID�ȊO���w��)(��������=NULL)
        [TestCase("PMCMN00070BNUTEST", "Partsman", "Test2", 1000, null, false, "")] // �E����P�[�X(�G���[���p�����[�^)
        [TestCase("PMCMN00070BNUTEST", "Partsman", "Test1", 0, null, false, "")]    // �F����P�[�X(���펞�̃p�����[�^)
        public void OutputClcLog(string pgId, string productId, string message, Int32 status, Exception exPara, bool equalFlg, string ret)
        {
            cLCLogTextOut = new CLCLogTextOut();

            if (message == "Test2")
            {
                exPara = new Exception("��O�G���[");
            }

            string ret2 = cLCLogTextOut.OutputClcLog(pgId, productId, message, status, exPara);

            if (equalFlg)
                Assert.AreEqual(ret2, ret);
            else
                Assert.AreNotEqual(ret2, ret);
        }

        /// <summary>
        /// �t�@�C���R�s�[����
        /// </summary>
        /// <param name="fileFullPath">�R�s�[���t�@�C���̃t���p�X</param>
        /// <param name="status">�X�e�[�^�X([0:����, 4:�R�s�[���t�@�C�������݂��Ȃ�, 9:�R�s�[���s, -1:��O�G���[)</param>
        [TestCase("D:\\test\\a\\Client.txt", 0)]         // �@����P�[�X(�t�@�C���L��)
        [TestCase("D:\\test\\a\\Client_Dummy.txt", 4)]   // �A�s���P�[�X(�t�@�C������)
        [TestCase("D:\\test\\a\\Cli", 4)]                // �B�s���P�[�X(�t�@�C������)(�t�@�C�����s���S)
        [TestCase("D:\\test\\a", 4)]                     // �C�s���P�[�X(�t�@�C������)(�t�H���_�w��)
        [TestCase(null, 4)]                              // �D�s���P�[�X(�t�@�C������)(null)
        [TestCase("", 4)]                                // �E�s���P�[�X(�t�@�C������)(��)
        [TestCase("D:\\test\\a\\Client_Fail.txt", 9)]    // �F�s���P�[�X(�����ݕs��)
        // �G�s���P�[�X(�t�@�C�������ߗ�O)
        [TestCase("D:\\test\\a\\Client_FULL123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012341234567890123456789012345678901234567890.txt", -1)]
        public void CopyClcLogFile(string fileFullPath, int status)
        {
            cLCLogTextOut = new CLCLogTextOut();
            int st = cLCLogTextOut.CopyClcLogFile(fileFullPath);
            Assert.AreEqual(st, status);
        }
    }
}
