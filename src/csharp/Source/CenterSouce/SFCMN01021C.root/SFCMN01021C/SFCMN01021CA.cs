using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;

namespace Broadleaf.ServiceProcess
{
    /// <summary>
    /// ���[�U�[AP�����[�g�v���L�V�T�[�o�[�N���X���\�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���̃N���X�̓����[�g�I�u�W�F�N�g�̃v���L�V�N���X�p���\�[�X�ł��B</br>
    /// <br>Programmer : 20402�@���� ���F</br>
    /// <br>Date       : 2009.04.02</br>
    /// <br></br>
    /// <br>Update Note: 2011/08/16 22018 ��� ���b</br>
    /// <br>           : SCM�����v���W�F�N�g ���_�Ǘ����ǑΉ�</br>
    /// <br></br>
    /// <br>Update Note: 2014/09/24 22008 ���� ���n</br>
    /// <br>           : SCM�������Ή� �ʐM���O�f�[�^�X�V�p�����[�g�ǉ�</br>
    /// <br>Update     : 2015/10/08 30350 �N�� ����</br>
    /// <br>           : 11170140-00 LSM�T�[�o�[�z�M���� LSM���O�A�b�v�f�[�^��ǉ�</br>
    /// <br>Update Note: 2020/05/29 31794 �u�� �I�V</br>
    /// <br>           : 11570229-00 ���_�Ǘ��T�[�oAWS�ڍs�@�ʐM�`�F�b�N�c�[���̒ǉ�</br>
    /// </remarks>
    public class Tbs021ServerServiceResource
    {
        /// <summary>
        /// ���\�[�X���擾
        /// </summary>
        /// <returns>���\�[�X���</returns>
        public static List<RemoteAssemblyInfo> GetRemoteResource()
        {
            List<RemoteAssemblyInfo> retList = new List<RemoteAssemblyInfo>();

            #region �u���J�n�ʒu
            retList.Add( new RemoteAssemblyInfo( "", "PMKHN00021R.DLL", "Broadleaf.Application.Remoting.VersionChkWorkDB", "MyAppVersionChkWorkDB", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07401R.DLL", "Broadleaf.Application.Remoting.DCControlDB", "MyAppDCControl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07410R.DLL", "Broadleaf.Application.Remoting.DCSalesSlipDB", "MyAppDCSalesSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07420R.DLL", "Broadleaf.Application.Remoting.DCSalesDetailDB", "MyAppDCSalesDetail", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07430R.DLL", "Broadleaf.Application.Remoting.DCSalesHistoryDB", "MyAppDCSalesHistory", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07440R.DLL", "Broadleaf.Application.Remoting.DCSalesHistDtlDB", "MyAppDCSalesHistDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07450R.DLL", "Broadleaf.Application.Remoting.DCDepsitMainDB", "MyAppDCDepsitMain", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07460R.DLL", "Broadleaf.Application.Remoting.DCDepsitDtlDB", "MyAppDCDepsitDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07470R.DLL", "Broadleaf.Application.Remoting.DCStockSlipDB", "MyAppDCStockSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07480R.DLL", "Broadleaf.Application.Remoting.DCStockDetailDB", "MyAppDCStockDetail", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07490R.DLL", "Broadleaf.Application.Remoting.DCStockSlipHistDB", "MyAppDCStockSlipHist", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07500R.DLL", "Broadleaf.Application.Remoting.DCStockSlHistDtlDB", "MyAppDCStockSlHistDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07510R.DLL", "Broadleaf.Application.Remoting.DCPaymentSlpDB", "MyAppDCPaymentSlp", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07520R.DLL", "Broadleaf.Application.Remoting.DCPaymentDtlDB", "MyAppDCPaymentDtl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07530R.DLL", "Broadleaf.Application.Remoting.DCAcceptOdrDB", "MyAppDCAcceptOdr", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07540R.DLL", "Broadleaf.Application.Remoting.DCAcceptOdrCarDB", "MyAppDCAcceptOdrCar", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07550R.DLL", "Broadleaf.Application.Remoting.DCMTtlSalesSlipDB", "MyAppDCMTtlSalesSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07560R.DLL", "Broadleaf.Application.Remoting.DCGoodsMTtlSaSlipDB", "MyAppDCGoodsMTtlSaSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07570R.DLL", "Broadleaf.Application.Remoting.DCMTtlStockSlipDB", "MyAppDCMTtlStockSlip", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO06401R.DLL", "Broadleaf.Application.Remoting.MstDCControlDB", "MyAppMstDCControl", WellKnownObjectMode.Singleton ) );
            #endregion

            // --- ADD m.suzuki 2011/08/16 ---------->>>>>
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO09405R.DLL", "Broadleaf.Application.Remoting.SndRcvHisDB", "MyAppSndRcvHis", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO09505R.DLL", "Broadleaf.Application.Remoting.SndRcvHisTableDB", "MyAppSndRcvHisTable", WellKnownObjectMode.Singleton ) );
            // --- ADD m.suzuki 2011/08/16 ----------<<<<<
            // --- ADD -------- 2014/09/24 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMKYO00201R.DLL", "Broadleaf.Application.Remoting.APNSNetworkTestDB", "MyAppAPNSNetworkTest", WellKnownObjectMode.Singleton));
            // --- ADD -------- 2014/09/24 ---------->>>>>

            // --- ADD r.sakurai 2015/10/08 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "PMCMN00086R.DLL", "Broadleaf.Application.Remoting.LsmHisLogDB", "MyAppLsmHisLog", WellKnownObjectMode.Singleton));
            retList.Add(new RemoteAssemblyInfo("", "PMCMN00091R.DLL", "Broadleaf.Application.Remoting.LsmChkWordDB", "MyAppLsmChkWord", WellKnownObjectMode.Singleton));
            // --- ADD r.sakurai 2015/10/08 ---------->>>>>

            // --- ADD n.shiga 2015/10/08 ---------->>>>>
            retList.Add(new RemoteAssemblyInfo("", "NsNetworkChkAwsR.dll", "Broadleaf.Application.Remoting.AWSCommTstRsltDB", "MyAppAWSCommTstRslt", WellKnownObjectMode.Singleton));
            // --- ADD n.shiga 2015/10/08 ----------<<<<<

            return retList;
        }
    }
}
