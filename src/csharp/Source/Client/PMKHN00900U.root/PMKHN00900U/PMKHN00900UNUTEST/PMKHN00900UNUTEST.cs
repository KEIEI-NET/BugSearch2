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


        #region NormalTest 正常系テスト
        // Client手動/Client自動/Serverの各処理で正常にログが出力されるかのテストです。
        // 本テストは全て一括で処理可能です。

        # region CostomClientManualClcLOG
        /// <param name="checkRow">出力ファイルのチェック行数（0の場合のみ出力ファイル数をチェック）</param>
        [TestCase(0)] // 出力ファイル数
        [TestCase(1)] // 1行目チェック
        [TestCase(2)] // 2行目チェック
        public void CostomClientManualClcLOG(int checkRow)
        {
            // クライアント手動実行（差分のみ）
            _count++;

            int retryTime = 5000; // マシン環境等によって処理が遅い場合は伸ばす（個別PG入れ替え処理が全て完了するまでの時間を設定）
            string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

            string textString = string.Empty; // ログ内容の文字列
            string compareString = string.Empty; // 成否比較用文字列

            int counter = 0; // チェック行カウンター
            int retrycount = 0; // 再施行回数

            try
            {
                //if (_firstFlg)
                //{
                _firstFlg = false;

                // ファイル削除処理
                // 5回リトライを行う
                while (retrycount < 5)
                {
                    if (DeleteDirectry(outputPass, ref retrycount, retryTime) == 0)
                        break;
                }

                System.Diagnostics.Process exe =
                    System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT");

                // ファイル出力まで時間が掛かる
                Thread.Sleep(retryTime);
                //}

                // 出力ファイル数を取得
                string[] files = Directory.GetFiles(outputPass);

                // 出力ファイル数をチェック
                // 本テストでは1件のみの出力となる
                if (checkRow == 0)
                {
                    Assert.AreEqual(files.Length, 1);
                    return;
                }

                // 出力ファイル内容を取得
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
                                    // 1行目の内容をチェック
                                    compareString = compareString = CreateCompareString(textString, 3);
                                    Assert.AreEqual(compareString, "Environment = Client, Mode = Manual");
                                    break;
                                case 2:
                                    // 2行目の内容をチェック
                                    Assert.AreEqual(textString, "個別プログラムの導入に成功しました。 status=0");
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
        /// <param name="checkRow">出力ファイルのチェック行数（0の場合のみ出力ファイル数をチェック）</param>
        [TestCase(0)]  // 出力ファイル数
        [TestCase(1)]  // 1行目チェック
        [TestCase(2)]  // 8行目チェック
        public void CostomClientManualAllClcLOG(int checkRow)
        {
            // クライアント手動実行（全入替）
            _count++;

            int retryTime = 20000; // マシン環境等によって処理が遅い場合は伸ばす（個別PG入れ替え処理が全て完了するまでの時間を設定）
            string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

            string textString = string.Empty; // ログ内容の文字列
            string compareString = string.Empty; // 成否比較用文字列


            int counter = 0; // チェック行カウンター
            int retrycount = 0; // 再施行回数

            try
            {
                //if (_firstFlg)
                //{
                _firstFlg = false;

                // ファイル削除処理
                // 5回リトライを行う
                while (retrycount < 5)
                {
                    if (DeleteDirectry(outputPass, ref retrycount, retryTime) == 0)
                        break;
                }

                System.Diagnostics.Process exe =
                    System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT");

                // ファイル出力まで時間が掛かる
                Thread.Sleep(retryTime);
                //}

                // 出力ファイル数を取得
                string[] files = Directory.GetFiles(outputPass);

                // 出力ファイル数をチェック
                // 本テストでは1件のみの出力となる
                if (checkRow == 0)
                {
                    Assert.AreEqual(files.Length, 1);
                    return;
                }

                // 出力ファイル内容を取得
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
                                    // 1行目の内容をチェック
                                    compareString = CreateCompareString(textString, 3);
                                    Assert.AreEqual(compareString, "Environment = Client, Mode = Manual");
                                    break;
                                case 2:
                                    // 2行目の内容をチェック
                                    Assert.AreEqual(textString, "個別プログラムの導入に成功しました。 status=0");
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
        /// <param name="checkRow">出力ファイルのチェック行数（0の場合のみ出力ファイル数をチェック）</param>
        [TestCase(0)] // 出力ファイル数
        [TestCase(1)] // 1行目チェック
        [TestCase(2)] // 2行目チェック
        public void CostomClientAutoClcLOG(int checkRow)
        {
            // クライアント自動実行
            _count++;

            int retryTime = 2000; // マシン環境等によって処理が遅い場合は伸ばす（個別PG入れ替え処理が全て完了するまでの時間を設定）
            string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

            string textString = string.Empty; // ログ内容の文字列
            string compareString = string.Empty; // 成否比較用文字列

            int counter = 0; // チェック行カウンター
            int retrycount = 0; // 再施行回数

            try
            {
                //if (_firstFlg)
                //{
                _firstFlg = false;

                // ファイル削除処理
                // 5回リトライを行う
                while (retrycount < 5)
                {
                    if (DeleteDirectry(outputPass, ref retrycount, retryTime) == 0)
                        break;
                }

                System.Diagnostics.Process exe =
                    System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT /AUTO");

                // ファイル出力まで時間が掛かる
                Thread.Sleep(retryTime);
                //}

                // 出力ファイル数を取得
                string[] files = Directory.GetFiles(outputPass);

                // 出力ファイル数をチェック
                // 本テストでは1件のみの出力となる
                if (checkRow == 0)
                {
                    Assert.AreEqual(files.Length, 1);
                    return;
                }

                // 出力ファイル内容を取得
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
                                    // 1行目の内容をチェック
                                    compareString = CreateCompareString(textString, 3);
                                    Assert.AreEqual(compareString, "Environment = Client, Mode = Auto");
                                    break;
                                case 2:
                                    // 2行目の内容をチェック
                                    Assert.AreEqual(textString, "個別プログラムの導入に成功しました。 status=0");
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
        /// <param name="checkRow">出力ファイルのチェック行数（0の場合のみ出力ファイル数をチェック）</param>
        [TestCase(0)] // 出力ファイル数
        [TestCase(1)] // 1行目チェック
        [TestCase(2)] // 2行目チェック
        public void CostomServerAutoClcLOG(int checkRow)
        {
            // サーバー自動実行
            _count++;

            int retryTime = 10000; // マシン環境等によって処理が遅い場合は伸ばす（個別PG入れ替え処理が全て完了するまでの時間を設定）
            string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

            string textString = string.Empty; // ログ内容の文字列
            string compareString = string.Empty; // 成否比較用文字列

            int counter = 0; // チェック行カウンター
            int retrycount = 0; // 再施行回数

            try
            {

                //if (_firstFlg)
                //{
                _firstFlg = false;

                // ファイル削除処理
                // 5回リトライを行う
                while (retrycount < 5)
                {
                    if (DeleteDirectry(outputPass, ref retrycount, retryTime) == 0)
                        break;
                }

                System.Diagnostics.Process exe =
                    System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/AUTO");

                // ファイル出力まで時間が掛かる
                Thread.Sleep(retryTime);
                //}

                // 出力ファイル数を取得
                string[] files = Directory.GetFiles(outputPass);

                // 出力ファイル数をチェック
                // 本テストでは1件のみの出力となる
                if (checkRow == 0)
                {
                    Assert.AreEqual(files.Length, 1);
                    return;
                }

                // 出力ファイル内容を取得
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
                                    // 1行目の内容をチェック
                                    compareString = CreateCompareString(textString, 3);
                                    Assert.AreEqual(compareString, "Environment = Server, Mode = Auto");
                                    break;
                                case 2:
                                    // 2行目の内容をチェック
                                    Assert.AreEqual(textString, "個別プログラムの導入に成功しました。 status=0");
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

        # region ErrorTest 不正系テスト
        // Client手動/Client自動/Serverの各処理でエラー発生時にCLCログが出力されるかのテストです。
        // 既存のログ出力箇所と同じ箇所で出力する為、全ログ出力パターンは網羅しません。
        // 本テストはエラー時のテストとなる為、一括で処理できません。
        // テストを実施する際には、１つのメソッドだけ有効に設定して下さい。

        # region CostomClientManualClcErrorLOG
        ///// <param name="checkRow">出力ファイルのチェック行数（0の場合のみ出力ファイル数をチェック）</param>
        //[TestCase(0)] // 出力ファイル数
        //[TestCase(1)] // 1行目チェック
        //[TestCase(2)] // 2行目チェック
        //[TestCase(3)] // 3行目チェック
        //[TestCase(4)] // 4行目チェック
        //public void CostomClientManualClcErrorLOG(int checkRow)
        //{
        //    // クライアント手動実行（差分のみ）

        //    // ※※※エラーケースは前準備が必要な為、連続して実行すると他のテストケースでもNGになります。※※※
        //    // 【本ケースの前準備】
        //    // ①CLCログフォルダを空にしておく
        //    // ②入れ替え対象[CustomDeliveryFiles.dat]を読取専用で配信先へ配置する

        //    int retryTime = 10000; // マシン環境等によって処理が遅い場合は伸ばす（個別PG入れ替え処理が全て完了するまでの時間を設定）
        //    string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

        //    string textString = string.Empty; // ログ内容の文字列
        //    string compareString = string.Empty; // 成否比較用文字列

        //    int counter = 0; // チェック行カウンター

        //    // 出力ファイル数を取得
        //    string[] files = Directory.GetFiles(outputPass);

        //    if (files.Length == 0)
        //    {
        //        System.Diagnostics.Process exe =
        //            System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT");

        //        // ファイル出力まで時間が掛かる
        //        Thread.Sleep(retryTime);
        //    }

        //    // 出力ファイル数をチェック
        //    // 本テストでは1件のみの出力となる
        //    if (checkRow == 0)
        //    {
        //        Assert.AreEqual(files.Length, 1);
        //        return;
        //    }

        //    if ((files == null) || (files.Length == 0))
        //        files = Directory.GetFiles(outputPass);

        //    // 出力ファイル内容を取得
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
        //                        // 1行目の内容をチェック
        //                        compareString = CreateCompareString(textString, 3);
        //                        Assert.AreEqual(compareString, "Environment = Client, Mode = Manual");
        //                        break;
        //                    case 2:
        //                        // 2行目の内容をチェック
        //                        compareString = CreateCompareString(textString, 2);
        //                        Assert.AreEqual(compareString, "パス 'R:\\SFNETASM\\CustomDeliveryFiles.dat' へのアクセスが拒否されました。 (CustomDeliveryFiles.dat)");
        //                        break;
        //                    case 3:
        //                        // 3行目の内容をチェック
        //                        Assert.AreEqual(textString, "個別プログラムの導入に失敗しました。 status=1000");
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
        // <param name="checkRow">出力ファイルのチェック行数（0の場合のみ出力ファイル数をチェック）</param>
        //[TestCase(0)]  // 出力ファイル数
        //[TestCase(1)]  // 1行目チェック
        //[TestCase(2)]  // 2行目チェック
        //[TestCase(3)]  // 3行目チェック
        //public void CostomClientManualAllClcErrorLOG(int checkRow)
        //{
        //     クライアント手動実行（全入替）

        //     ※※※エラーケースは前準備が必要な為、連続して実行すると他のテストケースでもNGになります。※※※
        //     【本ケースの前準備】
        //     ①CLCログフォルダを空にしておく
        //     ②入れ替え対象[PMHNB02882PC_01A4C.dll]を読取専用で配信先へ配置する

        //    int retryTime = 20000; // マシン環境等によって処理が遅い場合は伸ばす（個別PG入れ替え処理が全て完了するまでの時間を設定）
        //    string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

        //    string textString = string.Empty; // ログ内容の文字列
        //    string compareString = string.Empty; // 成否比較用文字列

        //    int counter = 0; // チェック行カウンター

        //     出力ファイル数を取得
        //    string[] files = Directory.GetFiles(outputPass);

        //    if (files.Length == 0)
        //    {
        //        System.Diagnostics.Process exe =
        //            System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT");

        //         ファイル出力まで時間が掛かる
        //        Thread.Sleep(retryTime);
        //    }

        //     出力ファイル数をチェック
        //     本テストでは1件のみの出力となる
        //    if (checkRow == 0)
        //    {
        //        Assert.AreEqual(files.Length, 1);
        //        return;
        //    }

        //    if ((files == null) || (files.Length == 0))
        //        files = Directory.GetFiles(outputPass);

        //     出力ファイル内容を取得
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
        //                         1行目の内容をチェック
        //                        compareString = CreateCompareString(textString, 3);
        //                        Assert.AreEqual(compareString, "Environment = Client, Mode = Manual");
        //                        break;
        //                    case 2:
        //                         2行目の内容をチェック
        //                        compareString = CreateCompareString(textString, 2);
        //                        Assert.AreEqual(compareString, "パス 'R:\\SFNETASM\\PMHNB02882PC_01A4C.dll' へのアクセスが拒否されました。 (PMHNB02882PC_01A4C.dll)");
        //                        break;
        //                    case 3:
        //                         3行目の内容をチェック
        //                        Assert.AreEqual(compareString, "個別プログラムの導入に失敗しました。 status=1000");
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
        ///// <param name="checkRow">出力ファイルのチェック行数（0の場合のみ出力ファイル数をチェック）</param>
        //[TestCase(0)] // 出力ファイル数
        //[TestCase(1)] // 1行目チェック
        //[TestCase(2)] // 2行目チェック
        //[TestCase(3)] // 3行目チェック
        //public void CostomClientAutoClcErrorLOG(int checkRow)
        //{
        //    // クライアント自動実行

        //    // ※※※エラーケースは前準備が必要な為、連続して実行すると他のテストケースでもNGになります。※※※
        //    // 【本ケースの前準備】
        //    // ①CLCログフォルダを空にしておく
        //    // ②入れ替え対象[CustomDeliveryFiles.dat]を読取専用で配信先へ配置する

        //    int retryTime = 10000; // マシン環境等によって処理が遅い場合は伸ばす（個別PG入れ替え処理が全て完了するまでの時間を設定）
        //    string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

        //    string textString = string.Empty; // ログ内容の文字列
        //    string compareString = string.Empty; // 成否比較用文字列

        //    int counter = 0; // チェック行カウンター

        //    // 出力ファイル数を取得
        //    string[] files = Directory.GetFiles(outputPass);

        //    if (files.Length == 0)
        //    {
        //        System.Diagnostics.Process exe =
        //            System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/CLIENT /AUTO");

        //        // ファイル出力まで時間が掛かる
        //        Thread.Sleep(retryTime);
        //    }

        //    // 出力ファイル数をチェック
        //    // 本テストでは1件のみの出力となる
        //    if (checkRow == 0)
        //    {
        //        Assert.AreEqual(files.Length, 1);
        //        return;
        //    }

        //    if ((files == null) || (files.Length == 0))
        //        files = Directory.GetFiles(outputPass);

        //    // 出力ファイル内容を取得
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
        //                        // 1行目の内容をチェック
        //                        compareString = CreateCompareString(textString, 3);
        //                        Assert.AreEqual(compareString, "Environment = Client, Mode = Auto");
        //                        break;
        //                    case 2:
        //                        // 2行目の内容をチェック
        //                        compareString = CreateCompareString(textString, 2);
        //                        Assert.AreEqual(compareString, "パス 'R:\\SFNETASM\\CustomDeliveryFiles.dat' へのアクセスが拒否されました。 (CustomDeliveryFiles.dat)");
        //                        break;
        //                    case 3:
        //                        // 3行目の内容をチェック
        //                        Assert.AreEqual(textString, "個別プログラムの導入に失敗しました。 status=1000");
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
        ///// <param name="checkRow">出力ファイルのチェック行数（0の場合のみ出力ファイル数をチェック）</param>
        //[TestCase(0)] // 出力ファイル数
        //[TestCase(1)] // 1行目チェック
        //[TestCase(2)] // 2行目チェック
        //[TestCase(3)] // 3行目チェック
        //public void CostomServerAutoClcErrorLOG(int checkRow)
        //{
        //    // サーバー自動実行（サービス開始失敗）

        //    // ※※※エラーケースは前準備が必要な為、連続して実行すると他のテストケースでもNGになります。※※※
        //    // 【本ケースの前準備】
        //    // ①CLCログフォルダを空にしておく
        //    // ②PM001ServerServiceを停止
        //    // ③PM001ServerServiceの実ファイル名を「C:\Program Files (x86)\PartsmanServer\USER_AP\SFCMN01001S_.exe」に変更

        //    int retryTime = 10000; // マシン環境等によって処理が遅い場合は伸ばす（個別PG入れ替え処理が全て完了するまでの時間を設定）
        //    string outputPass = "C:\\ProgramData\\Broadleaf\\CLC\\Service\\Partsman\\CLCLogTextOut";

        //    string textString = string.Empty; // ログ内容の文字列
        //    string compareString = string.Empty; // 成否比較用文字列

        //    int counter = 0; // チェック行カウンター

        //    // 出力ファイル数を取得
        //    string[] files = Directory.GetFiles(outputPass);

        //    if (files.Length == 0)
        //    {
        //        System.Diagnostics.Process exe =
        //            System.Diagnostics.Process.Start("R:\\SFNETASM\\PMKHN00900U.exe", "/AUTO");

        //        // ファイル出力まで時間が掛かる
        //        Thread.Sleep(retryTime);
        //    }

        //    // 出力ファイル数をチェック
        //    // 本テストでは1件のみの出力となる
        //    if (checkRow == 0)
        //    {
        //        Assert.AreEqual(files.Length, 1);
        //        return;
        //    }

        //    if ((files == null) || (files.Length == 0))
        //        files = Directory.GetFiles(outputPass);

        //    // 出力ファイル内容を取得
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
        //                        // 1行目の内容をチェック
        //                        compareString = CreateCompareString(textString, 3);
        //                        Assert.AreEqual(compareString, "Environment = Server, Mode = Auto");
        //                        break;
        //                    case 2:
        //                        // 2行目の内容をチェック
        //                        compareString = CreateCompareString(textString, 2);
        //                        Assert.AreEqual(compareString, "コンピュータ '.' でサービス 'PM001ServerService' を開始できません。 (PM001ServerService - 開始)");
        //                        break;
        //                    case 3:
        //                        // 3行目の内容をチェック
        //                        Assert.AreEqual(textString, "個別プログラムの導入に失敗しました。 status=1000");
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

        # region 内部処理用メソッド（テストケースではありません）
        /// <param name="outputPass">削除フォルダパス</param>
        /// <param name="count">リトライ回数</param> 
        /// <param name="retryTime">リトライ時間</param> 
        private int DeleteDirectry(string outputPass, ref int count, int retryTime)
        {
            try
            {
                // フォルダが存在する場合、削除を実施
                if (System.IO.Directory.Exists(outputPass))
                    System.IO.Directory.Delete(outputPass, true);

                count = 0;
            }
            catch(Exception)
            {
                // 削除に失敗した場合はリトライ回数を増やし、1秒停止
                Thread.Sleep(1000);
                count++;
            }

            return count;
        }

        /// <param name="orignalString">変更前の文字列</param> 
        /// <param name="removeDiv">文字列削除形式(1:PGID削除, 2:日付削除, 3:PGIDと日付削除)</param> 
        private string CreateCompareString(string orignalString, int removeDiv)
        {
            string compareString = string.Empty; // 成否比較用文字列
            string removeString = string.Empty; // 削除用文字列

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

            // 削除用文字列より、引数の文字列が大きい場合のみ削除実行
            if (orignalString.Length > removeString.Length)
                compareString = orignalString.Remove(0, removeString.Length);
            else
                compareString = orignalString;

            return compareString;
        }
        #endregion
    }
}
