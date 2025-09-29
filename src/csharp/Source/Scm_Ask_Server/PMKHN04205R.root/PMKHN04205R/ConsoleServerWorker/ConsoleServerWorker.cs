using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace ConsoleServerWorker
{
    /// <summary>
    /// Class1 �̊T�v�̐����ł��B
    /// </summary>
    class Class1
    {
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : �� ��</br>
        /// <br>Date       : 2010/11/11</br>
        /// </remarks>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            ScmInqLogInquiryDB _scmInqLogDB = new ScmInqLogInquiryDB();

            //�T�[�o�[���O�C�����i����
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_SCM_ASK_AP_NS);

#if DEBUG
            Console.WriteLine("���Е��i���������Ɖ� - Debug");
#else
            Console.WriteLine("���Е��i���������Ɖ�  - Release");
#endif

            Console.ReadLine();
        }
    }
}
