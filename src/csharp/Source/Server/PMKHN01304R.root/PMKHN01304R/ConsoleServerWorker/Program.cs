//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d����ϊ��c�[��
// �v���O�����T�v   : ���i�Ǘ����}�X�^�̍œK���ׁ̈A�s�v�ȃ��R�[�h���폜����B
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �� �� ��  2009/07/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace ConsoleServerWorker
{
    /// <summary>
    /// �d����ϊ�����
    /// </summary>
    /// <remarks>
    /// Note       : �d����ϊ������ł��B<br />
    /// Programmer : 杍^<br />
    /// Date       : 2009/07/13<br />
    /// </remarks>
    class Program
    {
        /// <summary>
        /// �A�v���P�[�V�����̃��C�� �G���g�� �|�C���g�ł��B
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            SupplierChangeProcDB supplierChangeProcDB = new SupplierChangeProcDB();
            if (!ServerLoginInfoAcquisition.Initialize(ConstantManagement_SF_PRO.ProductCode, ConstantManagement_SF_PRO.ServerCode_UserAP))
            {
                // WriteErrorLog(this.ServiceName, "OnStart", "�T�[�o�[���O�C�����i�����̏����Ɏ��s���܂����B�T�[�o�[�������������ǂ����m�F���Ă��������B", null, -8);
            }
            Console.ReadLine();
        }
    }
}
