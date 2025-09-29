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
    /// Bits�֌W�N���X
    /// </summary>
    /// <remarks> 
    /// <br>Note			:	</br>
    /// <br>Programer		:	���@�k��</br>                            
    /// <br>Date			:	2007.10.31</br>                              
    /// <br>Update Note		:	</br>                
    /// </remarks>
    public class BitsMng
    {
        //private BITS.Manager _bitsManager;  //�_�E�����[�h�}�l�[�W��
        //private BITS.Job _currentJob;       //�_�E�����[�h�W���u

        #region �p�u���b�N���\�b�h
        /// <summary>
        /// BITS�o�R�ł̃_�E�����[�h����
        /// </summary>
        /// <returns></returns>
        public static bool Download(NSNetworkTestInfo nSNetworkTestInfo)
        {
            bool result = false;
            string souceUrl = nSNetworkTestInfo.NSNetworkTestTargetUri.ToString();//"http://www31.superfrontman.net/BAUContents/df2c9d819fdf4e9a8a282507ed988808.zip";
            string descriptionPath = Path.GetTempPath() + "\\tempFile.zip";
            string dounloadVersion = "0.0.0.1";

            //�_�E�����[�h�}�l�[�W��
            BITS.Manager bitsManager = new BITS.Manager();
            
            //�e�X�g�Ŏg�p�����W���u���c���Ă����ꍇ�L�����Z������B
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
                    //�����̗�O�͖�������B
                }
            }


            //�_�E�����[�h�������\�b�h
            Guid JobID = SetDownloadJob(souceUrl, descriptionPath, dounloadVersion,bitsManager, BITS.JobPriority.High);
            //�_�E�����[�h����������ɏo���Ă�����_�E�����[�h�����Ɉڍs
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
                            //�����̗�O�͖�������B
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

        #region �v���C�x�[�g���\�b�h
        #region �_�E�����[�h�������\�b�h
        /// <summary>
        /// �_�E�����[�h�������\�b�h
        /// </summary>
        /// <param name="Source">�_�E�����[�h��</param>
        /// <param name="Distination">�_�E�����[�h��</param>
        /// <param name="DownloadingVersion">�_�E�����[�h����p�b�`�̃o�[�W����</param>
        /// <param name="jobPriority">�_�E�����[�h�̃v���C�I���e�B</param>
        /// <returns>�_�E�����[�hID</returns>
        private static Guid SetDownloadJob(string source, string distination, string downloadingVersion, BITS.Manager bitsManager, BITS.JobPriority jobPriority)
        {
            try
            {
                //Job���쐬����
                BITS.Job job = bitsManager.CreateJob(downloadingVersion, source);

                //�_�E�����[�h�̃v���C�I���e�B
                job.Priority = jobPriority;

                //�z�M��f�B���N�g�����Ȃ���΍쐬
                string DistDir = System.IO.Path.GetDirectoryName(distination);
                if( !System.IO.Directory.Exists(DistDir) )
                {
                    System.IO.Directory.CreateDirectory(DistDir);
                }

                //Job�Ƀt�@�C����ǉ�����
                job.AddFile(distination, source);

                //ID�擾
                return job.ID;
            }
            catch( Exception ex )
            {
                //MessageBox.Show(ex.Message);
            }
            return Guid.Empty;
        }
        #endregion

        #region �_�E�����[�h
        /// <summary>
        /// Bits�o�R�_�E�����[�h
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
                    //TODO:�v���L�V�ݒ肷��i�f�t�H���g�Őݒ肳��Ă���ۂ��j
                    //�F�؊֌W�𐧌䂷��@
                }
                currentJob.ResumeJob();
                //�ő�300�b�_�E�����[�h�������s��
                for(int timeoutCnt = 0; timeoutCnt < 300; timeoutCnt++)
                {
                    switch( currentJob.State )
                    {
                        ///
                        ///�_�E�����[�h��
                        ///
                        case BITS.JobState.Transferring:
                            {
                                //this.timer1.Enabled = false;
                                break;
                            }
                        ///
                        ///�_�E�����[�h����
                        ///
                        case BITS.JobState.Transferred:
                            {
                                result = true;
                                completeFlg = true;
                                currentJob.Complete();//�_�E�����[�h����
                                break;
                            }
                        ///
                        ///�_�E�����[�h��~�i�ĊJ�j
                        ///
                        case BITS.JobState.Suspended:
                            {
                                //completeFlg = true;
                                break;
                            }
                        ///
                        ///�_�E�����[�h�G���[
                        ///
                        case BITS.JobState.Errors:
                            {
                                result = false;
                                completeFlg = true;
                                //��O���Z�b�g
                                nSNetworkTestInfo.Ex = new Exception( currentJob.GetError().Description );
                                if( nSNetworkTestInfo.Ex.Message == "�v���L�V�̔F�؂��K�v�ł��B\r\n" )
                                {
                                    //�G���[���b�Z�[�W���v���L�V�F�؂̏ꍇ�G���[�R�[�h��407���Z�b�g����B
                                    nSNetworkTestInfo.WebRequestStatusNo = 407;
                                }
                                else
                                {
                                    nSNetworkTestInfo.WebRequestStatusNo = -1;
                                }
                                currentJob.Cancel();//Job�L�����Z��
                                break;
                            }
                        case BITS.JobState.TransientError:
                            {
                                result = false;
                                completeFlg = true;
                                currentJob.Cancel();//Job�L�����Z��
                                break;
                            }
                    }

                    if( completeFlg )
                    {
                        break;
                    }

                    //��b�ҋ@����B
                    System.Threading.Thread.Sleep(1000);
                }
            }
            catch( Exception ex )//Job��������Ȃ��A��������ResumeJob�Ɏ��s�����ꍇ
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
