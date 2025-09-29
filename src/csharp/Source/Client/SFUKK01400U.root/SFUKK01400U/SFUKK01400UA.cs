using System;
using System.Windows.Forms;

using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Windows.Forms;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// �������͋N���t���[���N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �������̓t���[���N���X���N�����܂��B</br>
	/// <br>Programmer : 97036 amami</br>
	/// <br>Date       : 2005.08.20</br>
    /// <br></br>
    /// <br>UpdateNote : 2010/07/03  22018  ��ؐ��b</br>
    /// <br>             �������ꗗ�\��ǉ�����ׁAActiveReports�̃��C�Z���X����t���B(licenses.licx)</br>
    /// <br>Update Note: 2013/02/05 �c����</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/13�z�M��</br>
    /// <br>           : Redmine#33735 ��ʂ����Ƃ��A��O���N����Ή�</br>
	/// </remarks>
	public class SFUKK01400UA : ApplicationContext
	{
		private static ApplicationContext _apli = null;
		private static string[] _parameter = null;

		/// <summary>
		/// �������͋N���t���[���N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �g�p���郁���o�̏��������s���܂��B</br>
		/// <br>Programmer : 97036 amami</br>
		/// <br>Date       : 2005.08.20</br>
		/// </remarks>
		public SFUKK01400UA()
		{
			// �N���p�����[�^�̎擾
			SFUKK01401UA.StartingParameter startingParameter = new SFUKK01401UA.StartingParameter();
			if (_parameter.Length >= (int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOMERCODE + 1)
				startingParameter.CustomerCode		= Convert.ToInt32(_parameter[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOMERCODE]);

			if (_parameter.Length >= (int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_ACCEPTANORDERNO + 1)
				startingParameter.AcceptAnOrderNo	= Convert.ToInt32(_parameter[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_ACCEPTANORDERNO]);

            // �� 20070130 18322 a MA.NS�p�ɕύX
			if (_parameter.Length >= (int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_ACCEPTANORDERNO + 1)
            {
                // ���`
				startingParameter.SalesSlipNum = _parameter[(int)ConstantManagement_SF_AP.ExeParameterIndex.ctPRM_CUSTOM1];
            }
            // �� 20070130 18322 a

			// �N�����[�h�̌���
			SFUKK01401UA.StartingMode startingMode = new SFUKK01401UA.StartingMode();
			if (startingParameter.AcceptAnOrderNo != 0)
			{
				startingMode = SFUKK01401UA.StartingMode.AcceptAnOrderNo;
			}
            // �� 20070130 18322 a MA.NS�p�ɕύX
			else if (startingParameter.SalesSlipNum != "")
			{
				startingMode = SFUKK01401UA.StartingMode.SalesSlipNum;
			}
            // �� 20070130 18322 a
			else if (startingParameter.CustomerCode != 0)
			{
				startingMode = SFUKK01401UA.StartingMode.CustomerCode;
			}
			else
			{
				startingMode = SFUKK01401UA.StartingMode.Normal;
			}

			// �N���t�H�[���̌ďo
			SFUKK01401UA frm = new SFUKK01401UA();
			frm.Closed += new EventHandler(OnFormClosed);
			frm.Show(startingMode, startingParameter);
		}
		/// <summary>
		/// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
		/// </summary>
		[STAThread]
		static void Main(string[] args)
		{
			try
			{
				string msg = "";
				_parameter = args;

				// VisualStyle��L�� ��XP�̃X�^�C���ɂȂ�
				System.Windows.Forms.Application.EnableVisualStyles();

				//�A�v���P�[�V�����J�n���������B���p�����[�^�̓A�v���P�[�V�����̃\�t�g�E�F�A�R�[�h���w��o����ꍇ�͎w��B�o���Ȃ��ꍇ�̓v���_�N�g�R�[�h
				int status = ApplicationStartControl.StartApplication(out msg, ref _parameter, ConstantManagement_SF_PRO.ProductCode, new EventHandler(ApplicationReleased));
				if (status == 0)
				{
					// �I�����C����Ԕ��f
					if (!Broadleaf.Application.Common.LoginInfoAcquisition.OnlineFlag)
					{
						TMsgDisp.Show(emErrorLevel.ERR_LEVEL_EXCLAMATION, "SFUKK01400U",
							"�I�t���C����ԂŖ{�@�\�͂��g�p�ł��܂���B", 0, MessageBoxButtons.OK);
					}
					else
					{
                        // �N���\������
                        if (!Broadleaf.Application.Controller.Facade.OpeAuthCtrlFacade.CanRunEntry("SFUKK01400U", true))
                        {
                            return;
                        }

						// �A�v���P�[�V�����J�n
						_apli = new SFUKK01400UA();
                        System.Windows.Forms.Application.ApplicationExit += new EventHandler(Application_ApplicationExit); // ADD 2013/02/05 �c���� Redmine#33735
						System.Windows.Forms.Application.Run(_apli);
					}
				}
				
				if (status != 0)	TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFUKK01400U", msg, 0, MessageBoxButtons.OK);
			}
			catch(Exception ex)
			{
				TMsgDisp.Show(emErrorLevel.ERR_LEVEL_STOPDISP, "SFUKK01400U", ex.Message, -1, MessageBoxButtons.OK);
			}
			finally
			{
				ApplicationStartControl.EndApplication();
			}
		}

        //----- ADD 2013/02/05 �c���� Redmine#33735 ------------------->>>>>
        /// <summary>
        /// �A�v���P�[�V�����I���C�x���g
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        //----- ADD 2013/02/05 �c���� Redmine#33735 -------------------<<<<<
		
		/// <summary>
		/// �A�v���P�[�V�����I���C�x���g
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">���b�Z�[�W</param>
		private static void ApplicationReleased(object sender, EventArgs e)
		{
			//���b�Z�[�W���o���O�ɑS�ĊJ��
			ApplicationStartControl.EndApplication();

			//�]�ƈ����O�I�t�̃��b�Z�[�W��\��
			TMsgDisp.Show(emErrorLevel.ERR_LEVEL_INFO, "SFUKK01400U", e.ToString(), 0, MessageBoxButtons.OK);

			//�A�v���P�[�V�����I��
			System.Windows.Forms.Application.Exit();
		}
		
        /// <summary>
        /// �N���t�H�[���̃N���[�Y�C�x���g�n���h���ł��B
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// <br>Update Note: 2013/02/05 �c����</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 2013/03/13�z�M��</br>
        /// <br>           : Redmine#33735 ��ʂ����Ƃ��A��O���N����Ή�</br>
        /// </remarks>
		private void OnFormClosed(object sender, EventArgs e) 
		{
			// �X���b�h�̃��b�Z�[�W���[�v�I���̌ďo
			ExitThread();
            //Environment.Exit(0); // DEL 2013/02/05 �c���� Redmine#33735
		}

		/// <summary>
		/// �X���b�h�̏I���ł��B
		/// </summary>
		protected override void ExitThreadCore()
		{
			// Application�I�u�W�F�N�g�ɂăX���b�h�I��
			base.ExitThreadCore ();
		}
	}
}
