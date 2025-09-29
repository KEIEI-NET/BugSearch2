using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;

namespace ConsoleServer
{
    /// <summary>
    /// Class2 �̊T�v�̐����ł��B
    /// </summary>
    public class Class2
    {
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            //�T�[�o�[���O�C�����i����
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP);

#if DEBUG
            Console.WriteLine("��`�f�[�^�}�X�^ - Debug ");
#else
            Console.WriteLine("��`�f�[�^�}�X�^ - Release ");
#endif

            PayDraftDataDB _payDraftDataDB = new PayDraftDataDB();

            Console.ReadLine();
        }
    }
}
