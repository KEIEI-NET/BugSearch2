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
    /// <br>Update Note: </br>
    /// </remarks>
    public class Tbs031ServerServiceResource
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
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO07701R.DLL", "Broadleaf.Application.Remoting.SKControlDB", "MyAppSKControl", WellKnownObjectMode.Singleton ) );
            retList.Add( new RemoteAssemblyInfo( "", "PMKYO06701R.DLL", "Broadleaf.Application.Remoting.MstTotalMachControlDB", "MyAppMstTotalMachControl", WellKnownObjectMode.Singleton ) );
            #endregion

            return retList;
        }
    }
}
