//****************************************************************************//
// �V�X�e��         : NS�ҋ@����
// �v���O��������   : ���M�R�}���h
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2010/06/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Diagnostics;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���M�R�}���h�N���X
    /// </summary>
    public sealed class SendingCommand : ISendingCommand
    {
        #region ISendingCommand �����o

        /// <summary>����</summary>
        private readonly string _name;
        /// <summary>���̂��擾���܂��B</summary>
        /// <see cref="ISendingCommand"/>
        public string Name { get { return _name; } }

        /// <summary>
        /// ���s���܂��B
        /// </summary>
        /// <returns>�������ʃX�e�[�^�X</returns>
        /// <see cref="ISendingCommand"/>
        public int Execute()
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                {
                    // �N���f�B���N�g����ݒ肷��
                    processStartInfo.WorkingDirectory = Environment.CurrentDirectory;

                    // �N������A�v���P�[�V������ݒ肷��
                    processStartInfo.FileName = SendingAppName;

                    // �R�}���h���C��������ݒ肷��
                    processStartInfo.Arguments = CommandLineArg;

                    #region �Q�l

                    //// �V�����E�B���h�E���쐬���邩�ǂ�����ݒ肷�� (�����l false)
                    //processStartInfo.CreateNoWindow = true;

                    //// �V�F�����g�p���邩�ǂ����ݒ肷�� (�����l true)
                    //processStartInfo.UseShellExecute = false;

                    //// �N���ł��Ȃ��������ɃG���[�_�C�A���O��\�����邩�ǂ�����ݒ肷�� (�����l false)
                    //processStartInfo.ErrorDialog = true;

                    //// �G���[�_�C�A���O��\������̂ɕK�v�Ȑe�n���h����ݒ肷��
                    //processStartInfo.ErrorDialogParentHandle = this.Handle;

                    //// �A�v���P�[�V�������N�����鎞�̓�����ݒ肷��
                    //processStartInfo.Verb = "Open";

                    //// �N�����̃E�B���h�E�̏�Ԃ�ݒ肷��
                    //processStartInfo.WindowStyle = ProcessWindowStyle.Normal;     //�ʏ�
                    //processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;     //��\��
                    //processStartInfo.WindowStyle = ProcessWindowStyle.Minimized;  //�ŏ���
                    //processStartInfo.WindowStyle = ProcessWindowStyle.Maximized;  //�ő剻

                    #endregion // �Q�l
                }
                using (Process nsScmSendApp = Process.Start(processStartInfo))
                {
                    // �I������܂őҋ@
                    nsScmSendApp.WaitForExit();

                    // �I��������j��
                    nsScmSendApp.Close();
                }

                return 0;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return 1;
            }
        }

        #endregion // ISendingCommand �����o

        #region �R�}���h���C��

        /// <summary>���M�������s���A�v���P�[�V������</summary>
        private readonly string _sendingAppName;
        /// <summary>���M�������s���A�v���P�[�V���������擾���܂��B</summary>
        private string SendingAppName { get { return _sendingAppName; } }

        /// <summary>�R�}���h���C������</summary>
        private readonly string _commandLineArg;
        /// <summary>�R�}���h���C���������擾���܂��B</summary>
        private string CommandLineArg { get { return _commandLineArg; } }

        #endregion // �R�}���h���C��

        #region Constructor

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="name">����</param>
        /// <param name="sendingAppName">���M�������s���A�v���P�[�V������</param>
        /// <param name="commandLineArg">�R�}���h���C������</param>
        public SendingCommand(
            string name,
            string sendingAppName,
            string commandLineArg
        )
        {
            _name = name;
            _sendingAppName = sendingAppName;
            _commandLineArg = commandLineArg;
        }

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SendingCommand() : this(string.Empty, string.Empty, string.Empty) { }

        #endregion // Constructor
    }
}
