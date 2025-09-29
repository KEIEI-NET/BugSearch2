//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   SCM�f�[�^��M�����N�������[�g�I�u�W�F�N�g
//                  :   PMSCM01055R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21024�@���X�� ��
// Date             :   2010/05/20
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Microsoft.Win32;
using System.Diagnostics;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// SCM�f�[�^��M�����N�������[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ȒP�⍇���ڑ����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SCMDtRcveExecDB : RemoteDB,ISCMDtRcveExecDB
    {
        /// <summary>
        /// SCM�f�[�^��M�����N�������[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/05/19</br>
        /// </remarks>
        public SCMDtRcveExecDB() 
        {

        }

        /// <summary>
        /// �f�[�^��M���������s���܂�
        /// </summary>
        /// <param name="wait"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : SCM�f�[�^��M���������s���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/05/19</br>
        /// </remarks>
        public int ExecuteDataReceive(bool wait)
        {
            return this.ExecuteDataReceiveProc(wait);
        }

        /// <summary>
        /// �f�[�^��M���������s���܂�
        /// </summary>
        /// <param name="wait"></param>
        /// <returns></returns>
        private int ExecuteDataReceiveProc(bool wait)
        {
            try
            {
                string dir = this.GetTargetDir();
                if (string.IsNullOrEmpty(dir) || !System.IO.Directory.Exists(dir))
                {
                    return -1;
                }

                string path = System.IO.Path.Combine(dir, "PMSCM01000U.exe");

                if (!System.IO.File.Exists(path)) return -2;


                Process pr = Process.Start(path);

                if (wait) pr.WaitForExit();

                return 0;
            }
            catch (Exception ex)
            {
                return -999;
            }
        }

        /// <summary>
        /// �Ώۃf�B���N�g���̂��擾���܂�
        /// </summary>
        /// <returns>USER_AP�̃f�B���N�g���i�擾�ł��Ȃ������ꍇ�̓J�����g�f�B���N�g���j</returns>
        private string GetTargetDir()
        {
            string dir = string.Empty;
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (key != null) // �����Ă͂����Ȃ��P�[�X
                {
                    dir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
            }
            catch
            {
            }
            if (string.IsNullOrEmpty(dir)) dir = System.IO.Directory.GetCurrentDirectory();

            return dir;
        }
    }
}
