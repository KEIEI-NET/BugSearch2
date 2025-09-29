using System;
using System.Data;
using System.ServiceProcess;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Resources;

namespace Broadleaf.ServiceProcess
{

	/// <summary>
	/// ���[�U�[AP�����[�g�v���L�V�T�[�o�[�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���̃N���X�̓����[�g�I�u�W�F�N�g�̃v���L�V�N���X�ł��B</br>
	/// <br>Programmer : 20402�@���� ���F</br>
	/// <br>Date       : 2009.04.02</br>
	/// </remarks>
	public class Tbs021ServerService : System.ServiceProcess.ServiceBase
	{

		/// <summary>
		/// �K�v�ȃf�U�C�i�ϐ��ł��B
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		public Tbs021ServerService()
		{
			// ���̌Ăяo���́AWindows.Forms �R���|�[�l���g �f�U�C�i�ŕK�v�ł��B
			InitializeComponent();

			// TODO: InitComponent �Ăяo���̌�ɏ�����������ǉ����Ă��������B
		}

		// �����̃��C�� �G���g�� �|�C���g�ł��B
		static void Main()
		{
			System.ServiceProcess.ServiceBase[] ServicesToRun;
	
			// 2 �ȏ�� NT �T�[�r�X�𓯂��������Ŏ��s�ł��܂��B�ʂ̃T�[�r�X��
			// ���̏����ɒǉ�����ɂ́A�ȉ��̍s��ύX����
			// 2 �Ԗڂ̃T�[�r�X �I�u�W�F�N�g���쐬���Ă��������B�� :
			//
			//   ServicesToRun = New System.ServiceProcess.ServiceBase[] {new Service1(), new MySecondUserService()};
			//
			ServicesToRun = new System.ServiceProcess.ServiceBase[] { new Tbs021ServerService() };

			System.ServiceProcess.ServiceBase.Run(ServicesToRun);
		}

		/// <summary>
		/// �f�U�C�i �T�|�[�g�ɕK�v�ȃ��\�b�h�ł��B���̃��\�b�h�̓��e��
		/// �R�[�h �G�f�B�^�ŕύX���Ȃ��ł��������B
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// Tbs001ServerService
			// 
			this.ServiceName = "Tbs021ServerService";

		}

		/// <summary>
		/// �g�p����Ă��郊�\�[�X�Ɍ㏈�������s���܂��B
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// ���삪�؂�Ȃ��s���A�T�[�r�X�̎��s���W�����Ȃ��悤�ɐݒ肵�܂��B
		/// </summary>
		protected override void OnStart(string[] args)
		{
			try
			{
                //�T�[�r�X�X�^�[�g
                int status = ServerServiceStartControl.StartServerService(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_Center_UserAP, Tbs021ServerServiceResource.GetRemoteResource());
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    WriteErrorLog(this.ServiceName, "OnStart", string.Format("StartServerService�ɂ�ERROR�����B�T�[�o�[�����������Ă�������"), null, status);
                }
			}
			catch(Exception ex)
			{
				WriteErrorLog(this.ServiceName,"OnStart",ex.Message,ex,-1);
			}
		}

		/// <summary>
		/// �G���[Log����
		/// </summary>
		/// <param name="pgId"></param>
		/// <param name="method"></param>
		/// <param name="Msg"></param>
		/// <param name="ex"></param>
		/// <param name="status"></param>
		private void WriteErrorLog(string pgId,string method,string Msg,Exception ex,int status)
		{
			string exceptionMsg = "����";
			if (ex != null) exceptionMsg = ex.Message;
			string msg = string.Format("Method:{0} Msg:{1} Exception.Msg:{2}",method,Msg,exceptionMsg);
			LogTextOut logTextOut = new LogTextOut();
			logTextOut.Output(pgId,msg,status);
            this.Stop();    //2006.07.11 add �v�ۓc
		}
 
		/// <summary>
		/// ���̃T�[�r�X���~���܂��B
		/// </summary>
		protected override void OnStop()
		{
			// TODO: �T�[�r�X���~����̂ɕK�v�ȏI�����������s����R�[�h�������ɒǉ����܂��B
		}

	}


}
