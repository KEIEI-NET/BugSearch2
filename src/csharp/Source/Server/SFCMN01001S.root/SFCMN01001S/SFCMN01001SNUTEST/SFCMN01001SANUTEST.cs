using System;

using NUnit.Framework;

using System.Configuration;

using Broadleaf.Library.Resources;
using Broadleaf.ServiceProcess;

using System.ServiceProcess;

namespace System.ServiceProcess.ServiceBase
{

    [TestFixture]
    public class SFCMN01001SANUTEST : Tbs001ServerService
    {

        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }
        
        /// <summary>
        /// 条件：StartServicePMTaskScheduler エラー系確認
        /// 結果：status = ConstantManagement.DB_Status.ctDB_ERROR,
        /// 01 レジストリ（SOFTWARE\Broadleaf\Service\Partsman\USER_AP）削除で「Partsman.NS Task Scheduler」サービス起動しない　・・・　サービス起動しない、エラー終了
        /// </summary>
        [Test(Description = "StartServicePMTaskScheduler エラー系確認")]
        public void StartServicePMTaskScheduler_ERROR()
        {
            try
            {
                StartServicePMTaskScheduler();
            }
            finally
            {
            }
        }

        /// <summary>
        /// 条件：StartServicePMTaskScheduler 正常系確認
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        /// 01 サービスなし、レジストリ無し、サービス停止　・・・　サービス停止のまま、正常終了
        /// 02 サービスなし、レジストリ有り、サービス停止　・・・　サービス停止のまま、正常終了
        /// 03 サービスあり、レジストリ無し、サービス停止　・・・　サービス停止のまま、正常終了
        /// 04 サービスあり、レジストリ無し、サービス起動　・・・　サービス停止のまま、正常終了
        /// 05 サービスあり、レジストリ有り、サービス停止　・・・　サービス起動する、正常終了
        /// 06 サービスあり、レジストリ有り、サービス起動　・・・　サービス起動のまま、正常終了
        /// </summary>
        [Test(Description = "StartServicePMTaskScheduler 正常系確認")]
        public void StartServicePMTaskScheduler_NORMAL()
        {
            try
            {
                StartServicePMTaskScheduler();
            }
            finally
            {
            }
        }

        /// <summary>
        /// 条件：StopServicePMTaskScheduler エラー系確認
        /// 結果：status = ConstantManagement.DB_Status.ctDB_ERROR,
        /// 01 OnStopイベント中に例外発生させる
        /// </summary>
        [Test(Description = "StopServicePMTaskScheduler エラー系確認")]
        public void StopServicePMTaskScheduler_ERROR()
        {
            try
            {
                StopServicePMTaskScheduler();
            }
            finally
            {
            }
        }

        /// <summary>
        /// 条件：StopServicePMTaskScheduler 正常系確認
        /// 結果：status = ConstantManagement.DB_Status.ctDB_NORMAL,
        /// 01 サービスなし、レジストリ無し、サービス停止　・・・　サービス停止のまま、正常終了
        /// 02 サービスなし、レジストリ有り、サービス停止　・・・　サービス停止のまま、正常終了
        /// 03 サービスあり、レジストリ無し、サービス停止　・・・　サービス停止のまま、正常終了
        /// 04 サービスあり、レジストリ無し、サービス起動　・・・　サービス起動のまま、正常終了
        /// 05 サービスあり、レジストリ有り、サービス停止　・・・　サービス停止のまま、正常終了
        /// 06 サービスあり、レジストリ有り、サービス起動　・・・　サービス停止する、正常終了
        /// </summary>
        [Test(Description = "StopServicePMTaskScheduler 正常系確認")]
        public void StopServicePMTaskScheduler_NORMAL()
        {
            try
            {
                StopServicePMTaskScheduler();
            }
            finally
            {
            }
        }

        /// <summary>
        /// 条件：ChkServiceStartMode エラー系確認
        /// 結果：status = false
        /// 01 レジストリ無し　・・・　サービス起動不可（false）
        /// 02 レジストリ有り、文字列なし　・・・　サービス起動不可（false）
        /// 03 レジストリ有り、文字列あり、スタートアップの種類：無効　・・・　サービス起動不可（false）
        /// </summary>
        [Test(Description = "ChkServiceStartMode エラー系確認")]
        public void ChkServiceStartMode_ERROR()
        {
            try
            {
                Boolean status = ChkServiceStartMode("Partsman.NS Task Scheduler");

                Assert.AreEqual(status, false);
            }
            finally
            {
            }
        }

        /// <summary>
        /// 条件：ChkServiceStartMode 正常系確認
        /// 結果：status = true
        /// 01 レジストリあり、文字列あり、スタートアップの種類：手動　・・・　サービス起動可能（true）
        /// 02 レジストリあり、文字列あり、スタートアップの種類：自動　・・・　サービス起動可能（true）
        /// </summary>
        [Test(Description = "ChkServiceStartMode 正常系確認")]
        public void ChkServiceStartMode_NORMAL()
        {
            try
            {
                Boolean status = ChkServiceStartMode("Partsman.NS Task Scheduler");

                Assert.AreEqual(status, true);
            }
            finally
            {
            }
        }

        /// <summary>
        /// 条件：OnStart 起動確認
        /// 結果：true
        /// 01 サービス起動　・・・　サービス起動のまま
        /// 02 サービス停止　・・・　サービス起動する
        /// </summary>
        [Test(Description = "OnStart 起動確認")]
        public void OnStart_EXEC()
        {
            try
            {
                OnStart(null);
            }
            finally
            {
            }
        }

        /// <summary>
        /// 条件：OnStop 起動確認
        /// 結果：true
        /// 01 サービス起動　・・・　サービス停止する
        /// 02 サービス停止　・・・　サービス停止のまま
        /// </summary>
        [Test(Description = "OnStop 起動確認")]
        public void OnStop_EXEC()
        {
            try
            {
                OnStop();
            }
            finally
            {
            }
        }

        /// <summary>
        /// 条件：ReadLsmCheckFile 正常系確認
        /// デフォルト値：LsmCheckInterval(監視間隔)=5分、LsmStartTime(定期起動時刻)="21:00"
        /// 01 SFCMN01001S_LsmCheckInfo.XMLなし⇒OK
        /// 02 SFCMN01001S_LsmCheckInfo.XMLあり、設定値＝デフォルト値⇒OK
        /// 02 SFCMN01001S_LsmCheckInfo.XMLあり、設定値≠デフォルト値⇒NG
        /// </summary>
        [Test(Description = "ReadLsmCheckFile 正常系確認")]
        public void ReadLsmCheckFile_NORMAL()
        {
            try
            {
                LsmServiceCheckInfo lsmServiceCheckInfo = new LsmServiceCheckInfo();
                ReadLsmCheckFile(ref lsmServiceCheckInfo);

                Assert.AreEqual(5,lsmServiceCheckInfo.LsmCheckInterval);
                Assert.AreEqual(21, lsmServiceCheckInfo.LsmStartTime_HH);
                Assert.AreEqual(00, lsmServiceCheckInfo.LsmStartTime_mm);
            }
            finally
            {
            }
        }

    }
}
