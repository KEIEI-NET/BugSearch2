//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : Class1 �̊T�v�̐����ł�
// �v���O�����T�v   : �A�v���P�[�V�����̃��C�� �G���g��
//----------------------------------------------------------------------------//
//                (c)Copyright  2012 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�             �쐬�S�� : FSI�����@�v
// �� �� ��  2012/09/07 �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using System.Runtime.Serialization.Formatters;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace ConsoleServer
{
    /// <summary>
    /// Class1 �̊T�v�̐����ł��B
    /// </summary>
    class Class1
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

            ISumSuppStPrintResultDB SumSuppStResultDB = new SumSuppStPrintResultDB();
            Console.ReadLine();
        }
    }
}
