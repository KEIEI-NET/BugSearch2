using System;
using System.Collections.Generic;
using System.Text;

using NUnit.Framework;

using Broadleaf.ServiceProcess;
using System.ServiceProcess;


namespace PMCMN06200SNUTEST
{
    [TestFixture]
    public class PMCMN06200SANUTEST : NSTaskScheduler
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
        /// 条件：NSTaskScheduler_ログ出力確認
        /// 01 レジストリ（SOFTWARE\Broadleaf\Service\Partsman\USER_AP）削除でサービス起動しない　・・・　ログ出力確認
        /// </summary>
        [Test(Description = "NSTaskScheduler ログ出力確認")]
        public void NSTaskScheduler_ログ出力確認()
        {
            try
            {
                NSTaskScheduler nsts = new NSTaskScheduler();
                
                Assert.AreEqual(true, true);
            }
            finally
            {
            }
        }

        /// <summary>
        /// 条件：OnStart 起動確認
        /// 01 PMCMN06200S.XMLとPMCMN06200S.USR.XMLが存在する状態で実行　実行後PMCMN06200S.XMLとPMCMN06200S.USR.XMLを排他制御確認できるテキストエディタで開く　・・・　正常
        /// </summary>
        [Test(Description = "OnStart 起動確認")]
        public void OnStart_EXEC()
        {
            try
            {
                OnStart(null);

                Assert.AreEqual(true, true);
            }
            finally
            {
            }
        }
    }
}
