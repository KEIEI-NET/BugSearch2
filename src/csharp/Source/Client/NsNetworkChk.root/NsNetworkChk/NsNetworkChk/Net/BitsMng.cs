using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using System.IO;
using Microsoft.Win32;
using Broadleaf.NSNetworkChk.Data;


namespace Broadleaf.NSNetworkChk.Net
{
    /// <summary>
    /// Bits関係クラス
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	上野　耕平</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	</br>                
    /// </remarks>
    public class BitsMng
    {
        //private BITS.Manager _bitsManager;  //ダウンロードマネージャ
        //private BITS.Job _currentJob;       //ダウンロードジョブ

        #region パブリックメソッド
        /// <summary>
        /// BITS経由でのダウンロード処理
        /// </summary>
        /// <returns></returns>
        public static bool Download(NSNetworkTestInfo nSNetworkTestInfo)
        {
            bool result = false;
            string souceUrl = nSNetworkTestInfo.NSNetworkTestTargetUri.ToString();//"http://www31.superfrontman.net/BAUContents/df2c9d819fdf4e9a8a282507ed988808.zip";
            string descriptionPath = Path.GetTempPath() + "\\tempFile.zip";
            string dounloadVersion = "0.0.0.1";

            //ダウンロードマネージャ
            BITS.Manager bitsManager = new BITS.Manager();
            
            //テストで使用したジョブが残っていた場合キャンセルする。
            foreach( BITS.Job job in bitsManager.GetListofJobs() )
            {
                if( job.Description == souceUrl )
                {
                    job.Cancel();
                }
            }

            if( File.Exists(descriptionPath) )
            {
                try
                {
                    File.Delete(descriptionPath);
                }
                catch
                {
                    //ここの例外は無視する。
                }
            }


            //ダウンロード準備メソッド
            Guid JobID = SetDownloadJob(souceUrl, descriptionPath, dounloadVersion,bitsManager, BITS.JobPriority.High);
            //ダウンロード準備が正常に出来ていたらダウンロード処理に移行
            if( JobID != Guid.Empty )
            {
                result = DownLoadProc(bitsManager, JobID, nSNetworkTestInfo);
                if( result )
                {

                    if( File.Exists(descriptionPath) )
                    {
                        try
                        {
                            File.Delete(descriptionPath);
                        }
                        catch
                        {
                            //ここの例外は無視する。
                        }
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                }
            }

            return result;
        }
        #endregion

        #region プライベートメソッド
        #region ダウンロード準備メソッド
        /// <summary>
        /// ダウンロード準備メソッド
        /// </summary>
        /// <param name="Source">ダウンロード先</param>
        /// <param name="Distination">ダウンロード元</param>
        /// <param name="DownloadingVersion">ダウンロードするパッチのバージョン</param>
        /// <param name="jobPriority">ダウンロードのプライオリティ</param>
        /// <returns>ダウンロードID</returns>
        private static Guid SetDownloadJob(string source, string distination, string downloadingVersion, BITS.Manager bitsManager, BITS.JobPriority jobPriority)
        {
            try
            {
                //Jobを作成する
                BITS.Job job = bitsManager.CreateJob(downloadingVersion, source);

                //ダウンロードのプライオリティ
                job.Priority = jobPriority;

                //配信先ディレクトリがなければ作成
                string DistDir = System.IO.Path.GetDirectoryName(distination);
                if( !System.IO.Directory.Exists(DistDir) )
                {
                    System.IO.Directory.CreateDirectory(DistDir);
                }

                //Jobにファイルを追加する
                job.AddFile(distination, source);

                //ID取得
                return job.ID;
            }
            catch( Exception ex )
            {
                //MessageBox.Show(ex.Message);
            }
            return Guid.Empty;
        }
        #endregion

        #region ダウンロード
        /// <summary>
        /// Bits経由ダウンロード
        /// </summary>
        /// <param name="JobID"></param>
        private static bool DownLoadProc(BITS.Manager bitsManager, Guid jobID, NSNetworkTestInfo nSNetworkTestInfo)
        {
            bool result = false;
            BITS.Job currentJob = null;
            bool completeFlg = false;


            try
            {
                currentJob = bitsManager.GetJob(jobID);

                if( nSNetworkTestInfo.ProxyInfo.IsProxy == ProxyInfo.ProxyType.USE )
                {
                    //TODO:プロキシ設定する（デフォルトで設定されているぽい）
                    //認証関係を制御する　
                }
                currentJob.ResumeJob();
                //最大300秒ダウンロード処理を行う
                for(int timeoutCnt = 0; timeoutCnt < 300; timeoutCnt++)
                {
                    switch( currentJob.State )
                    {
                        ///
                        ///ダウンロード中
                        ///
                        case BITS.JobState.Transferring:
                            {
                                //this.timer1.Enabled = false;
                                break;
                            }
                        ///
                        ///ダウンロード完了
                        ///
                        case BITS.JobState.Transferred:
                            {
                                result = true;
                                completeFlg = true;
                                currentJob.Complete();//ダウンロード完了
                                break;
                            }
                        ///
                        ///ダウンロード停止（再開）
                        ///
                        case BITS.JobState.Suspended:
                            {
                                //completeFlg = true;
                                break;
                            }
                        ///
                        ///ダウンロードエラー
                        ///
                        case BITS.JobState.Errors:
                            {
                                result = false;
                                completeFlg = true;
                                //例外をセット
                                nSNetworkTestInfo.Ex = new Exception( currentJob.GetError().Description );
                                if( nSNetworkTestInfo.Ex.Message == "プロキシの認証が必要です。\r\n" )
                                {
                                    //エラーメッセージがプロキシ認証の場合エラーコードに407をセットする。
                                    nSNetworkTestInfo.WebRequestStatusNo = 407;
                                }
                                else
                                {
                                    nSNetworkTestInfo.WebRequestStatusNo = -1;
                                }
                                currentJob.Cancel();//Jobキャンセル
                                break;
                            }
                        case BITS.JobState.TransientError:
                            {
                                result = false;
                                completeFlg = true;
                                currentJob.Cancel();//Jobキャンセル
                                break;
                            }
                    }

                    if( completeFlg )
                    {
                        break;
                    }

                    //一秒待機する。
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch( Exception ex )//Jobが見つからない、もしくはResumeJobに失敗した場合
            {
                nSNetworkTestInfo.Ex = ex;
                result = false;
            }
            return result;
        }
        #endregion
        #endregion

    }
}
