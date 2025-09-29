//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �}�X�^����M����
// �v���O�����T�v   : �f�[�^�Z���^�[�ɑ΂��Ēǉ��E�X�V�������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting;

namespace ConsoleServer
{
    /// <summary>
    /// Program �̊T�v�̐����ł��B
    /// </summary>
    class Program
    {
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);

            //�T�[�o�[���O�C�����i����
            ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_Center_UserAP);
            MstDCControlDB _mstDCControlDB = new MstDCControlDB();
            Console.ReadLine();
        }
    }
}
