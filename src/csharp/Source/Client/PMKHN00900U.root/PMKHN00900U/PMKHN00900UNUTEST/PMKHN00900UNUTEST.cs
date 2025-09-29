using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Threading;
using NUnit.Framework;

namespace Broadleaf.TestTools.UnitTesting
{

    [TestFixture]
    public class PMKHN00900UNUTEST
    {
        private const string Dummy_PgId = "[XXXXX00000U]";
        private const string Dummy_Date = "[13:28:58]";
        private const string Dummy_Space = " ";

        private bool _firstFlg = true;
        private int _count = 0;


        #region NormalTest ����n�e�X�g
        // Client�蓮/Client����/Server�̊e�����Ő���Ƀ��O���o�͂���邩�̃e�X�g�ł��B
        // �{�e�X�g�͑S�Ĉꊇ�ŏ����\�ł��B

        # region CostomClientManualClcLOG
        /// <param name="checkRow">�o�̓t�@�C���̃`�F�b�N�s���i0�̏ꍇ�̂ݏo�̓t�@�C�������`�F�b�N�j</param>
        [TestCase(0)] // �o�̓t�@�C����
        [TestCase(1)] // 1�s�ڃ`�F�b�N
        [TestCase(2)] // 2�s�ڃ`�F�b�N
        public void CostomClientManualClcLOG(int checkRow)
        {
            // �N���C�A���g�蓮���s�i�����̂݁j
            _count++;

            int retryTime = 5000; // �}�V�������ɂ���ď������x���ꍇ�͐L�΂��i��PG����ւ��������S�Ċ�������܂ł̎��Ԃ�ݒ�j
            string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

            string textString = string.Empty; // ���O���e�̕�����
            string compareString = string.Empty; // ���۔�r�p������

            int counter = 0; // �`�F�b�N�s�J�E���^�[
            int retrycount = 0; // �Ď{�s��

            try
            {
                //if (_firstFlg)
                //{
                _firstFlg = false;

                // �t�@�C���폜����
                // 5�񃊃g���C���s��
                while (retrycount < 5)
                {
                    if (DeleteDirectry(outputPass, ref retrycount, retryTime) == 0)
                        break;
                }

                System.Diagnostics.Process exe =
                    System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT");

                // �t�@�C���o�͂܂Ŏ��Ԃ��|����
                Thread.Sleep(retryTime);
                //}

                // �o�̓t�@�C�������擾
                string[] files = Directory.GetFiles(outputPass);

                // �o�̓t�@�C�������`�F�b�N
                // �{�e�X�g�ł�1���݂̂̏o�͂ƂȂ�
                if (checkRow == 0)
                {
                    Assert.AreEqual(files.Length, 1);
                    return;
                }

                // �o�̓t�@�C�����e���擾
                using (System.IO.StreamReader sr = new System.IO.StreamReader(files[0].ToString()))
                {
                    while ((textString = sr.ReadLine()) != null)
                    {
                        counter++;

                        if (counter == checkRow)
                        {
                            switch (counter)
                            {
                                case 1:
                                    // 1�s�ڂ̓��e���`�F�b�N
                                    compareString = compareString = CreateCompareString(textString, 3);
                                    Assert.AreEqual(compareString, "Environment = Client, Mode = Manual");
                                    break;
                                case 2:
                                    // 2�s�ڂ̓��e���`�F�b�N
                                    Assert.AreEqual(textString, "�ʃv���O�����̓����ɐ������܂����B status=0");
                                    break;
                                default:
                                    break;

                            }
                        }
                    }
                }
            }
            finally
            {
                //if (_count == 4)
                //{
                //    _count = 0;
                //    _firstFlg = true;
                //}
            }
        }
        # endregion

        # region CostomClientManualAllClcLOG
        /// <param name="checkRow">�o�̓t�@�C���̃`�F�b�N�s���i0�̏ꍇ�̂ݏo�̓t�@�C�������`�F�b�N�j</param>
        [TestCase(0)]  // �o�̓t�@�C����
        [TestCase(1)]  // 1�s�ڃ`�F�b�N
        [TestCase(2)]  // 8�s�ڃ`�F�b�N
        public void CostomClientManualAllClcLOG(int checkRow)
        {
            // �N���C�A���g�蓮���s�i�S���ցj
            _count++;

            int retryTime = 20000; // �}�V�������ɂ���ď������x���ꍇ�͐L�΂��i��PG����ւ��������S�Ċ�������܂ł̎��Ԃ�ݒ�j
            string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

            string textString = string.Empty; // ���O���e�̕�����
            string compareString = string.Empty; // ���۔�r�p������


            int counter = 0; // �`�F�b�N�s�J�E���^�[
            int retrycount = 0; // �Ď{�s��

            try
            {
                //if (_firstFlg)
                //{
                _firstFlg = false;

                // �t�@�C���폜����
                // 5�񃊃g���C���s��
                while (retrycount < 5)
                {
                    if (DeleteDirectry(outputPass, ref retrycount, retryTime) == 0)
                        break;
                }

                System.Diagnostics.Process exe =
                    System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT");

                // �t�@�C���o�͂܂Ŏ��Ԃ��|����
                Thread.Sleep(retryTime);
                //}

                // �o�̓t�@�C�������擾
                string[] files = Directory.GetFiles(outputPass);

                // �o�̓t�@�C�������`�F�b�N
                // �{�e�X�g�ł�1���݂̂̏o�͂ƂȂ�
                if (checkRow == 0)
                {
                    Assert.AreEqual(files.Length, 1);
                    return;
                }

                // �o�̓t�@�C�����e���擾
                using (System.IO.StreamReader sr = new System.IO.StreamReader(files[0].ToString()))
                {
                    while ((textString = sr.ReadLine()) != null)
                    {
                        counter++;

                        if (counter == checkRow)
                        {
                            switch (counter)
                            {
                                case 1:
                                    // 1�s�ڂ̓��e���`�F�b�N
                                    compareString = CreateCompareString(textString, 3);
                                    Assert.AreEqual(compareString, "Environment = Client, Mode = Manual");
                                    break;
                                case 2:
                                    // 2�s�ڂ̓��e���`�F�b�N
                                    Assert.AreEqual(textString, "�ʃv���O�����̓����ɐ������܂����B status=0");
                                    break;
                                default:
                                    break;

                            }
                        }
                    }
                }
            }
            finally
            {
                //if (_count == 5)
                //{
                //    _count = 0;
                //    _firstFlg = true;
                //}
            }
        }
        # endregion

        # region CostomClientAutoClcLOG
        /// <param name="checkRow">�o�̓t�@�C���̃`�F�b�N�s���i0�̏ꍇ�̂ݏo�̓t�@�C�������`�F�b�N�j</param>
        [TestCase(0)] // �o�̓t�@�C����
        [TestCase(1)] // 1�s�ڃ`�F�b�N
        [TestCase(2)] // 2�s�ڃ`�F�b�N
        public void CostomClientAutoClcLOG(int checkRow)
        {
            // �N���C�A���g�������s
            _count++;

            int retryTime = 2000; // �}�V�������ɂ���ď������x���ꍇ�͐L�΂��i��PG����ւ��������S�Ċ�������܂ł̎��Ԃ�ݒ�j
            string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

            string textString = string.Empty; // ���O���e�̕�����
            string compareString = string.Empty; // ���۔�r�p������

            int counter = 0; // �`�F�b�N�s�J�E���^�[
            int retrycount = 0; // �Ď{�s��

            try
            {
                //if (_firstFlg)
                //{
                _firstFlg = false;

                // �t�@�C���폜����
                // 5�񃊃g���C���s��
                while (retrycount < 5)
                {
                    if (DeleteDirectry(outputPass, ref retrycount, retryTime) == 0)
                        break;
                }

                System.Diagnostics.Process exe =
                    System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT /AUTO");

                // �t�@�C���o�͂܂Ŏ��Ԃ��|����
                Thread.Sleep(retryTime);
                //}

                // �o�̓t�@�C�������擾
                string[] files = Directory.GetFiles(outputPass);

                // �o�̓t�@�C�������`�F�b�N
                // �{�e�X�g�ł�1���݂̂̏o�͂ƂȂ�
                if (checkRow == 0)
                {
                    Assert.AreEqual(files.Length, 1);
                    return;
                }

                // �o�̓t�@�C�����e���擾
                using (System.IO.StreamReader sr = new System.IO.StreamReader(files[0].ToString()))
                {
                    while ((textString = sr.ReadLine()) != null)
                    {
                        counter++;

                        if (counter == checkRow)
                        {
                            switch (counter)
                            {
                                case 1:
                                    // 1�s�ڂ̓��e���`�F�b�N
                                    compareString = CreateCompareString(textString, 3);
                                    Assert.AreEqual(compareString, "Environment = Client, Mode = Auto");
                                    break;
                                case 2:
                                    // 2�s�ڂ̓��e���`�F�b�N
                                    Assert.AreEqual(textString, "�ʃv���O�����̓����ɐ������܂����B status=0");
                                    break;
                                default:
                                    break;

                            }
                        }
                    }
                }
            }
            finally
            {
                //if (_count == 4)
                //{
                //    _count = 0;
                //    _firstFlg = true;
                //}
            }
        }
        # endregion

        # region CostomServerAutoClcLOG
        /// <param name="checkRow">�o�̓t�@�C���̃`�F�b�N�s���i0�̏ꍇ�̂ݏo�̓t�@�C�������`�F�b�N�j</param>
        [TestCase(0)] // �o�̓t�@�C����
        [TestCase(1)] // 1�s�ڃ`�F�b�N
        [TestCase(2)] // 2�s�ڃ`�F�b�N
        public void CostomServerAutoClcLOG(int checkRow)
        {
            // �T�[�o�[�������s
            _count++;

            int retryTime = 10000; // �}�V�������ɂ���ď������x���ꍇ�͐L�΂��i��PG����ւ��������S�Ċ�������܂ł̎��Ԃ�ݒ�j
            string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

            string textString = string.Empty; // ���O���e�̕�����
            string compareString = string.Empty; // ���۔�r�p������

            int counter = 0; // �`�F�b�N�s�J�E���^�[
            int retrycount = 0; // �Ď{�s��

            try
            {

                //if (_firstFlg)
                //{
                _firstFlg = false;

                // �t�@�C���폜����
                // 5�񃊃g���C���s��
                while (retrycount < 5)
                {
                    if (DeleteDirectry(outputPass, ref retrycount, retryTime) == 0)
                        break;
                }

                System.Diagnostics.Process exe =
                    System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/AUTO");

                // �t�@�C���o�͂܂Ŏ��Ԃ��|����
                Thread.Sleep(retryTime);
                //}

                // �o�̓t�@�C�������擾
                string[] files = Directory.GetFiles(outputPass);

                // �o�̓t�@�C�������`�F�b�N
                // �{�e�X�g�ł�1���݂̂̏o�͂ƂȂ�
                if (checkRow == 0)
                {
                    Assert.AreEqual(files.Length, 1);
                    return;
                }

                // �o�̓t�@�C�����e���擾
                using (System.IO.StreamReader sr = new System.IO.StreamReader(files[0].ToString()))
                {
                    while ((textString = sr.ReadLine()) != null)
                    {
                        counter++;

                        if (counter == checkRow)
                        {
                            switch (counter)
                            {
                                case 1:
                                    // 1�s�ڂ̓��e���`�F�b�N
                                    compareString = CreateCompareString(textString, 3);
                                    Assert.AreEqual(compareString, "Environment = Server, Mode = Auto");
                                    break;
                                case 2:
                                    // 2�s�ڂ̓��e���`�F�b�N
                                    Assert.AreEqual(textString, "�ʃv���O�����̓����ɐ������܂����B status=0");
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
            finally
            {
                //if (_count == 8)
                //{
                //    _count = 0;
                //    _firstFlg = true;
                //}
            }
        }
        # endregion
        # endregion

        # region ErrorTest �s���n�e�X�g
        // Client�蓮/Client����/Server�̊e�����ŃG���[��������CLC���O���o�͂���邩�̃e�X�g�ł��B
        // �����̃��O�o�͉ӏ��Ɠ����ӏ��ŏo�͂���ׁA�S���O�o�̓p�^�[���͖ԗ����܂���B
        // �{�e�X�g�̓G���[���̃e�X�g�ƂȂ�ׁA�ꊇ�ŏ����ł��܂���B
        // �e�X�g�����{����ۂɂ́A�P�̃��\�b�h�����L���ɐݒ肵�ĉ������B

        # region CostomClientManualClcErrorLOG
        ///// <param name="checkRow">�o�̓t�@�C���̃`�F�b�N�s���i0�̏ꍇ�̂ݏo�̓t�@�C�������`�F�b�N�j</param>
        //[TestCase(0)] // �o�̓t�@�C����
        //[TestCase(1)] // 1�s�ڃ`�F�b�N
        //[TestCase(2)] // 2�s�ڃ`�F�b�N
        //[TestCase(3)] // 3�s�ڃ`�F�b�N
        //[TestCase(4)] // 4�s�ڃ`�F�b�N
        //public void CostomClientManualClcErrorLOG(int checkRow)
        //{
        //    // �N���C�A���g�蓮���s�i�����̂݁j

        //    // �������G���[�P�[�X�͑O�������K�v�ȈׁA�A�����Ď��s����Ƒ��̃e�X�g�P�[�X�ł�NG�ɂȂ�܂��B������
        //    // �y�{�P�[�X�̑O�����z
        //    // �@CLC���O�t�H���_����ɂ��Ă���
        //    // �A����ւ��Ώ�[CustomDeliveryFiles.dat]��ǎ��p�Ŕz�M��֔z�u����

        //    int retryTime = 10000; // �}�V�������ɂ���ď������x���ꍇ�͐L�΂��i��PG����ւ��������S�Ċ�������܂ł̎��Ԃ�ݒ�j
        //    string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

        //    string textString = string.Empty; // ���O���e�̕�����
        //    string compareString = string.Empty; // ���۔�r�p������

        //    int counter = 0; // �`�F�b�N�s�J�E���^�[

        //    // �o�̓t�@�C�������擾
        //    string[] files = Directory.GetFiles(outputPass);

        //    if (files.Length == 0)
        //    {
        //        System.Diagnostics.Process exe =
        //            System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT");

        //        // �t�@�C���o�͂܂Ŏ��Ԃ��|����
        //        Thread.Sleep(retryTime);
        //    }

        //    // �o�̓t�@�C�������`�F�b�N
        //    // �{�e�X�g�ł�1���݂̂̏o�͂ƂȂ�
        //    if (checkRow == 0)
        //    {
        //        Assert.AreEqual(files.Length, 1);
        //        return;
        //    }

        //    if ((files == null) || (files.Length == 0))
        //        files = Directory.GetFiles(outputPass);

        //    // �o�̓t�@�C�����e���擾
        //    using (System.IO.StreamReader sr = new System.IO.StreamReader(files[0].ToString()))
        //    {
        //        while ((textString = sr.ReadLine()) != null)
        //        {
        //            counter++;

        //            if (counter == checkRow)
        //            {
        //                switch (counter)
        //                {
        //                    case 1:
        //                        // 1�s�ڂ̓��e���`�F�b�N
        //                        compareString = CreateCompareString(textString, 3);
        //                        Assert.AreEqual(compareString, "Environment = Client, Mode = Manual");
        //                        break;
        //                    case 2:
        //                        // 2�s�ڂ̓��e���`�F�b�N
        //                        compareString = CreateCompareString(textString, 2);
        //                        Assert.AreEqual(compareString, "�p�X 'R:\\SFNETASM\\CustomDeliveryFiles.dat' �ւ̃A�N�Z�X�����ۂ���܂����B (CustomDeliveryFiles.dat)");
        //                        break;
        //                    case 3:
        //                        // 3�s�ڂ̓��e���`�F�b�N
        //                        Assert.AreEqual(textString, "�ʃv���O�����̓����Ɏ��s���܂����B status=1000");
        //                        break;
        //                    default:
        //                        break;

        //                }
        //            }
        //        }
        //    }
        //}
        # endregion

        # region CostomClientManualAllClcErrorLOG
        // <param name="checkRow">�o�̓t�@�C���̃`�F�b�N�s���i0�̏ꍇ�̂ݏo�̓t�@�C�������`�F�b�N�j</param>
        //[TestCase(0)]  // �o�̓t�@�C����
        //[TestCase(1)]  // 1�s�ڃ`�F�b�N
        //[TestCase(2)]  // 2�s�ڃ`�F�b�N
        //[TestCase(3)]  // 3�s�ڃ`�F�b�N
        //public void CostomClientManualAllClcErrorLOG(int checkRow)
        //{
        //     �N���C�A���g�蓮���s�i�S���ցj

        //     �������G���[�P�[�X�͑O�������K�v�ȈׁA�A�����Ď��s����Ƒ��̃e�X�g�P�[�X�ł�NG�ɂȂ�܂��B������
        //     �y�{�P�[�X�̑O�����z
        //     �@CLC���O�t�H���_����ɂ��Ă���
        //     �A����ւ��Ώ�[PMHNB02882PC_01A4C.dll]��ǎ��p�Ŕz�M��֔z�u����

        //    int retryTime = 20000; // �}�V�������ɂ���ď������x���ꍇ�͐L�΂��i��PG����ւ��������S�Ċ�������܂ł̎��Ԃ�ݒ�j
        //    string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

        //    string textString = string.Empty; // ���O���e�̕�����
        //    string compareString = string.Empty; // ���۔�r�p������

        //    int counter = 0; // �`�F�b�N�s�J�E���^�[

        //     �o�̓t�@�C�������擾
        //    string[] files = Directory.GetFiles(outputPass);

        //    if (files.Length == 0)
        //    {
        //        System.Diagnostics.Process exe =
        //            System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT");

        //         �t�@�C���o�͂܂Ŏ��Ԃ��|����
        //        Thread.Sleep(retryTime);
        //    }

        //     �o�̓t�@�C�������`�F�b�N
        //     �{�e�X�g�ł�1���݂̂̏o�͂ƂȂ�
        //    if (checkRow == 0)
        //    {
        //        Assert.AreEqual(files.Length, 1);
        //        return;
        //    }

        //    if ((files == null) || (files.Length == 0))
        //        files = Directory.GetFiles(outputPass);

        //     �o�̓t�@�C�����e���擾
        //    using (System.IO.StreamReader sr = new System.IO.StreamReader(files[0].ToString()))
        //    {
        //        while ((textString = sr.ReadLine()) != null)
        //        {
        //            counter++;

        //            if (counter == checkRow)
        //            {
        //                switch (counter)
        //                {
        //                    case 1:
        //                         1�s�ڂ̓��e���`�F�b�N
        //                        compareString = CreateCompareString(textString, 3);
        //                        Assert.AreEqual(compareString, "Environment = Client, Mode = Manual");
        //                        break;
        //                    case 2:
        //                         2�s�ڂ̓��e���`�F�b�N
        //                        compareString = CreateCompareString(textString, 2);
        //                        Assert.AreEqual(compareString, "�p�X 'R:\\SFNETASM\\PMHNB02882PC_01A4C.dll' �ւ̃A�N�Z�X�����ۂ���܂����B (PMHNB02882PC_01A4C.dll)");
        //                        break;
        //                    case 3:
        //                         3�s�ڂ̓��e���`�F�b�N
        //                        Assert.AreEqual(compareString, "�ʃv���O�����̓����Ɏ��s���܂����B status=1000");
        //                        break;
        //                    default:
        //                        break;

        //                }
        //            }
        //        }
        //    }
        //}
        # endregion

        # region CostomClientAutoClcErrorLOG
        ///// <param name="checkRow">�o�̓t�@�C���̃`�F�b�N�s���i0�̏ꍇ�̂ݏo�̓t�@�C�������`�F�b�N�j</param>
        //[TestCase(0)] // �o�̓t�@�C����
        //[TestCase(1)] // 1�s�ڃ`�F�b�N
        //[TestCase(2)] // 2�s�ڃ`�F�b�N
        //[TestCase(3)] // 3�s�ڃ`�F�b�N
        //public void CostomClientAutoClcErrorLOG(int checkRow)
        //{
        //    // �N���C�A���g�������s

        //    // �������G���[�P�[�X�͑O�������K�v�ȈׁA�A�����Ď��s����Ƒ��̃e�X�g�P�[�X�ł�NG�ɂȂ�܂��B������
        //    // �y�{�P�[�X�̑O�����z
        //    // �@CLC���O�t�H���_����ɂ��Ă���
        //    // �A����ւ��Ώ�[CustomDeliveryFiles.dat]��ǎ��p�Ŕz�M��֔z�u����

        //    int retryTime = 10000; // �}�V�������ɂ���ď������x���ꍇ�͐L�΂��i��PG����ւ��������S�Ċ�������܂ł̎��Ԃ�ݒ�j
        //    string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

        //    string textString = string.Empty; // ���O���e�̕�����
        //    string compareString = string.Empty; // ���۔�r�p������

        //    int counter = 0; // �`�F�b�N�s�J�E���^�[

        //    // �o�̓t�@�C�������擾
        //    string[] files = Directory.GetFiles(outputPass);

        //    if (files.Length == 0)
        //    {
        //        System.Diagnostics.Process exe =
        //            System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT /AUTO");

        //        // �t�@�C���o�͂܂Ŏ��Ԃ��|����
        //        Thread.Sleep(retryTime);
        //    }

        //    // �o�̓t�@�C�������`�F�b�N
        //    // �{�e�X�g�ł�1���݂̂̏o�͂ƂȂ�
        //    if (checkRow == 0)
        //    {
        //        Assert.AreEqual(files.Length, 1);
        //        return;
        //    }

        //    if ((files == null) || (files.Length == 0))
        //        files = Directory.GetFiles(outputPass);

        //    // �o�̓t�@�C�����e���擾
        //    using (System.IO.StreamReader sr = new System.IO.StreamReader(files[0].ToString()))
        //    {
        //        while ((textString = sr.ReadLine()) != null)
        //        {
        //            counter++;

        //            if (counter == checkRow)
        //            {
        //                switch (counter)
        //                {
        //                    case 1:
        //                        // 1�s�ڂ̓��e���`�F�b�N
        //                        compareString = CreateCompareString(textString, 3);
        //                        Assert.AreEqual(compareString, "Environment = Client, Mode = Auto");
        //                        break;
        //                    case 2:
        //                        // 2�s�ڂ̓��e���`�F�b�N
        //                        compareString = CreateCompareString(textString, 2);
        //                        Assert.AreEqual(compareString, "�p�X 'R:\\SFNETASM\\CustomDeliveryFiles.dat' �ւ̃A�N�Z�X�����ۂ���܂����B (CustomDeliveryFiles.dat)");
        //                        break;
        //                    case 3:
        //                        // 3�s�ڂ̓��e���`�F�b�N
        //                        Assert.AreEqual(textString, "�ʃv���O�����̓����Ɏ��s���܂����B status=1000");
        //                        break;
        //                    default:
        //                        break;

        //                }
        //            }
        //        }
        //    }
        //}
        # endregion

        # region CostomServerAutoClcErrorLOG
        ///// <param name="checkRow">�o�̓t�@�C���̃`�F�b�N�s���i0�̏ꍇ�̂ݏo�̓t�@�C�������`�F�b�N�j</param>
        //[TestCase(0)] // �o�̓t�@�C����
        //[TestCase(1)] // 1�s�ڃ`�F�b�N
        //[TestCase(2)] // 2�s�ڃ`�F�b�N
        //[TestCase(3)] // 3�s�ڃ`�F�b�N
        //public void CostomServerAutoClcErrorLOG(int checkRow)
        //{
        //    // �T�[�o�[�������s�i�T�[�r�X�J�n���s�j

        //    // �������G���[�P�[�X�͑O�������K�v�ȈׁA�A�����Ď��s����Ƒ��̃e�X�g�P�[�X�ł�NG�ɂȂ�܂��B������
        //    // �y�{�P�[�X�̑O�����z
        //    // �@CLC���O�t�H���_����ɂ��Ă���
        //    // �APM001ServerService���~
        //    // �BPM001ServerService�̎��t�@�C�������uC:\Program Files (x86)\PartsmanServer\USER_AP\SFCMN01001S_.exe�v�ɕύX

        //    int retryTime = 10000; // �}�V�������ɂ���ď������x���ꍇ�͐L�΂��i��PG����ւ��������S�Ċ�������܂ł̎��Ԃ�ݒ�j
        //    string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

        //    string textString = string.Empty; // ���O���e�̕�����
        //    string compareString = string.Empty; // ���۔�r�p������

        //    int counter = 0; // �`�F�b�N�s�J�E���^�[

        //    // �o�̓t�@�C�������擾
        //    string[] files = Directory.GetFiles(outputPass);

        //    if (files.Length == 0)
        //    {
        //        System.Diagnostics.Process exe =
        //            System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/AUTO");

        //        // �t�@�C���o�͂܂Ŏ��Ԃ��|����
        //        Thread.Sleep(retryTime);
        //    }

        //    // �o�̓t�@�C�������`�F�b�N
        //    // �{�e�X�g�ł�1���݂̂̏o�͂ƂȂ�
        //    if (checkRow == 0)
        //    {
        //        Assert.AreEqual(files.Length, 1);
        //        return;
        //    }

        //    if ((files == null) || (files.Length == 0))
        //        files = Directory.GetFiles(outputPass);

        //    // �o�̓t�@�C�����e���擾
        //    using (System.IO.StreamReader sr = new System.IO.StreamReader(files[0].ToString()))
        //    {
        //        while ((textString = sr.ReadLine()) != null)
        //        {
        //            counter++;

        //            if (counter == checkRow)
        //            {
        //                switch (counter)
        //                {
        //                    case 1:
        //                        // 1�s�ڂ̓��e���`�F�b�N
        //                        compareString = CreateCompareString(textString, 3);
        //                        Assert.AreEqual(compareString, "Environment = Server, Mode = Auto");
        //                        break;
        //                    case 2:
        //                        // 2�s�ڂ̓��e���`�F�b�N
        //                        compareString = CreateCompareString(textString, 2);
        //                        Assert.AreEqual(compareString, "�R���s���[�^ '.' �ŃT�[�r�X 'PM001ServerService' ���J�n�ł��܂���B (PM001ServerService - �J�n)");
        //                        break;
        //                    case 3:
        //                        // 3�s�ڂ̓��e���`�F�b�N
        //                        Assert.AreEqual(textString, "�ʃv���O�����̓����Ɏ��s���܂����B status=1000");
        //                        break;
        //                    default:
        //                        break;

        //                }
        //            }
        //        }
        //    }
        //}
        # endregion
        # endregion

        # region ���������p���\�b�h�i�e�X�g�P�[�X�ł͂���܂���j
        /// <param name="outputPass">�폜�t�H���_�p�X</param>
        /// <param name="count">���g���C��</param> 
        /// <param name="retryTime">���g���C����</param> 
        private int DeleteDirectry(string outputPass, ref int count, int retryTime)
        {
            try
            {
                // �t�H���_�����݂���ꍇ�A�폜�����{
                if (System.IO.Directory.Exists(outputPass))
                    System.IO.Directory.Delete(outputPass, true);

                count = 0;
            }
            catch(Exception)
            {
                // �폜�Ɏ��s�����ꍇ�̓��g���C�񐔂𑝂₵�A1�b��~
                Thread.Sleep(1000);
                count++;
            }

            return count;
        }

        /// <param name="orignalString">�ύX�O�̕�����</param> 
        /// <param name="removeDiv">������폜�`��(1:PGID�폜, 2:���t�폜, 3:PGID�Ɠ��t�폜)</param> 
        private string CreateCompareString(string orignalString, int removeDiv)
        {
            string compareString = string.Empty; // ���۔�r�p������
            string removeString = string.Empty; // �폜�p������

            switch (removeDiv)
            {
                case 1:
                    removeString = Dummy_PgId + Dummy_Space;
                    break;
                case 2:
                    removeString = Dummy_Date + Dummy_Space;
                    break;
                case 3:
                    removeString = Dummy_PgId + Dummy_Space + Dummy_Date + Dummy_Space;
                    break;
                default:
                    break;
            }

            // �폜�p��������A�����̕����񂪑傫���ꍇ�̂ݍ폜���s
            if (orignalString.Length > removeString.Length)
                compareString = orignalString.Remove(0, removeString.Length);
            else
                compareString = orignalString;

            return compareString;
        }
        #endregion
    }
}
