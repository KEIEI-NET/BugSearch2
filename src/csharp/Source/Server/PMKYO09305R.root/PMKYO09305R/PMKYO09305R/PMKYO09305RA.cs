//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����N���T�[�r�X����
// �v���O�����T�v   : �����N���T�[�r�X�t�@�C����ۑ�
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/01  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ������
// �C �� ��  2011/09/01  �C�����e : #24278 �f�[�^������M�������N�����܂���
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2014/10/02  �C�����e : �c�[���`�F�b�N�̏C��
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting;
using System.Data.SqlClient;
using System.Collections;
using System.Data;
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System.IO;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �����N���T�[�r�X�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �����N���T�[�r�X�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.3.31</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ServiceFilesDB : RemoteDB, IServiceFilesDB
    {
        #region read
        /// <summary>
        /// �t�@�C���ǂ�
        /// </summary>
        /// <param name="file">�t�@�C�����e</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="fileFlg">�t�@�C���t���O</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.4.29</br>
        public int Read(ref object file, ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string workDir = string.Empty;

            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (key == null) // �����Ă͂����Ȃ��P�[�X
                {
                    msg = "���W�X�g���̎擾�Ɏ��s���܂����B";
                    ServiceFilesWork serviceFilesWork = new ServiceFilesWork();
                    serviceFilesWork.FileContent = new byte[128];
                    file = serviceFilesWork as object;
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = ReadCfgFile(ref file, workDir, ref msg, ref fileFlg);
            }
            return status;
        }


        /// <summary>
        /// �ݒ�t�@�C���Ǎ���
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private int ReadCfgFile(ref object file, string workDir, ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ServiceFilesWork serviceFilesWork = (ServiceFilesWork)file;

            try
            {
                string fileNm = Path.Combine(workDir, "PMCMN06200S.USR.XML");

                bool isExist = File.Exists(fileNm);

                // �t�@�C�����݃`�F�b�N
                if (isExist)
                {
                    FileStream fs = new FileStream(fileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                    byte[] tmp = new byte[fs.Length];
                    int cnt = fs.Read(tmp, 0, (int)fs.Length);
                    for (int i = 0; i < cnt; i++)
                    {
                        tmp[i] += 8;
                    }

                    fs.Dispose();

                    // �t���O
                    fileFlg = 1;
                    serviceFilesWork.FileContent = tmp;
                }
                else
                {
                    fileNm = Path.Combine(workDir, "PMCMN06200S.XML");

                    isExist = File.Exists(fileNm);

                    // �t�@�C�����݃`�F�b�N
                    if (isExist)
                    {
                        FileStream fs = new FileStream(fileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                        byte[] tmp = new byte[fs.Length];
                        int cnt = fs.Read(tmp, 0, (int)fs.Length);
                        for (int i = 0; i < cnt; i++)
                        {
                            tmp[i] += 8;
                        }

                        fs.Dispose();

                        // �t���O
                        fileFlg = 2;
                        serviceFilesWork.FileContent = tmp;
                    }
                    else
                    {
                        serviceFilesWork.FileContent = new byte[128];
                        msg = "�w�肳�ꂽ�ݒ�t�@�C��������܂���B";
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
            }
            catch
            {
                msg = "XML�t�@�C���̓��e���s���ł��B";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            file = serviceFilesWork as object;

            return status;
        }
        #endregion

        #region

        /// <summary>
        /// �t�@�C������
        /// </summary>
        /// <param name="file">�t�@�C�����e</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.3.31</br>
        public int Write(object file)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ServiceFilesWork serviceFilesWork = (ServiceFilesWork)file;

            string workDir = string.Empty;

            try
            {
                if (serviceFilesWork != null)
                {

                    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                    if (key == null) // �����Ă͂����Ȃ��P�[�X
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    else
                    {
                        workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                    }


                    string fileNm = Path.Combine(workDir, "PMCMN06200S.USR.XML");

                    FileStream fs = new FileStream(fileNm, FileMode.Create, FileAccess.Write, FileShare.Write);

                    for (int i = 0; i < serviceFilesWork.FileContent.Length; i++)
                    {
                        serviceFilesWork.FileContent[i] -= 8;
                    }

                    fs.Write(serviceFilesWork.FileContent, 0, serviceFilesWork.FileContent.Length);

                    fs.Close();
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region 2011/09/01 #24278 �f�[�^������M�������N�����܂���
        #region read
        /// <summary>
        /// �t�@�C���ǂ�
        /// </summary>
        /// <param name="file">�t�@�C�����e</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="fileFlg">�t�@�C���t���O</param>
        /// <param name="dataType">�f�[�^�^�C�v</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.09.01</br>
        public int Read(ref object file, ref string msg, ref int fileFlg, int dataType)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string workDir = string.Empty;

            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (key == null) // �����Ă͂����Ȃ��P�[�X
                {
                    msg = "���W�X�g���̎擾�Ɏ��s���܂����B";
                    ServiceFilesWork serviceFilesWork = new ServiceFilesWork();
                    serviceFilesWork.FileContent = new byte[128];
                    file = serviceFilesWork as object;
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = ReadCfgFile(ref file, workDir, ref msg, ref fileFlg, dataType);
            }
            return status;
        }


        /// <summary>
        /// �ݒ�t�@�C���Ǎ���
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.09.01</br>
        /// </remarks>
        private int ReadCfgFile(ref object file, string workDir, ref string msg, ref int fileFlg, int dataType)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ServiceFilesWork serviceFilesWork = (ServiceFilesWork)file;            
            string fileName = "PMCMN06200S.SCM.XML";

            try
            {
                if(dataType == 1)
                {
                    fileName = "PMCMN06200S.SCM.XML";
                }

                string fileNm = Path.Combine(workDir, fileName);

                bool isExist = File.Exists(fileNm);

                // �t�@�C�����݃`�F�b�N
                if (isExist)
                {
                    FileStream fs = new FileStream(fileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                    byte[] tmp = new byte[fs.Length];
                    int cnt = fs.Read(tmp, 0, (int)fs.Length);
                    for (int i = 0; i < cnt; i++)
                    {
                        tmp[i] += 8;
                    }

                    fs.Dispose();

                    // �t���O
                    fileFlg = 1;
                    serviceFilesWork.FileContent = tmp;
                }
                else
                { 
                    serviceFilesWork.FileContent = new byte[128];
                    msg = "�w�肳�ꂽ�ݒ�t�@�C��������܂���B";
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    //}
                }
            }
            catch
            {
                msg = "XML�t�@�C���̓��e���s���ł��B";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            file = serviceFilesWork as object;

            return status;
        }
        #endregion

        #region write

        /// <summary>
        /// �t�@�C������
        /// </summary>
        /// <param name="file">�t�@�C�����e</param>
        /// <param name="dataType">�f�[�^�^�C�v</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �f�[�^�擾</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.09.01</br>
        public int Write(object file, int dataType)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ServiceFilesWork serviceFilesWork = (ServiceFilesWork)file;

            string workDir = string.Empty;
            string fileName = "PMCMN06200S.SCM.XML";
            try
            {
                if (serviceFilesWork != null)
                {

                    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                    if (key == null) // �����Ă͂����Ȃ��P�[�X
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    }
                    else
                    {
                        workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                    }

                    if (dataType == 1)
                    {
                        fileName = "PMCMN06200S.SCM.XML";
                    }
                    string fileNm = Path.Combine(workDir, fileName);

                    FileStream fs = new FileStream(fileNm, FileMode.Create, FileAccess.Write, FileShare.Write);

                    for (int i = 0; i < serviceFilesWork.FileContent.Length; i++)
                    {
                        serviceFilesWork.FileContent[i] -= 8;
                    }

                    fs.Write(serviceFilesWork.FileContent, 0, serviceFilesWork.FileContent.Length);

                    fs.Close();
                }
                else
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion
        #endregion


        // ---- ADD 杍^ 2014/10/02 ---------------------------->>>>>
        /// <summary>
        /// �t�@�C���ǂ�
        /// </summary>
        /// <param name="file">�t�@�C�����e</param>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="fileFlg">�t�@�C���t���O</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/10/02</br>
        public int Read(ref object userFile, ref object commFile, ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            string workDir = string.Empty;

            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (key == null) // �����Ă͂����Ȃ��P�[�X
                {
                    msg = "���W�X�g���̎擾�Ɏ��s���܂����B";
                    ServiceFilesWork userServiceFilesWork = new ServiceFilesWork();
                    userServiceFilesWork.FileContent = new byte[128];
                    userFile = userServiceFilesWork as object;

                    ServiceFilesWork commServiceFilesWork = new ServiceFilesWork();
                    commServiceFilesWork.FileContent = new byte[128];
                    commFile = commServiceFilesWork as object;

                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
                else
                {
                    workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
                }
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = ReadCfgFile(ref userFile, ref commFile, workDir, ref msg, ref fileFlg);
            }
            return status;
        }



        /// <summary>
        /// �ݒ�t�@�C���Ǎ���
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/10/02</br>
        /// </remarks>
        private int ReadCfgFile(ref object userFile, ref object commFile, string workDir, ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ServiceFilesWork userServiceFilesWork = (ServiceFilesWork)userFile;
            ServiceFilesWork commServiceFilesWork = (ServiceFilesWork)commFile;

            try
            {
                string userFileNm = Path.Combine(workDir, "PMCMN06200S.USR.XML");

                bool userIsExist = File.Exists(userFileNm);

                // �t�@�C�����݃`�F�b�N
                if (userIsExist)
                {
                    FileStream fs = new FileStream(userFileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                    byte[] tmp = new byte[fs.Length];
                    int cnt = fs.Read(tmp, 0, (int)fs.Length);
                    for (int i = 0; i < cnt; i++)
                    {
                        tmp[i] += 8;
                    }

                    fs.Dispose();

                    // �t���O
                    fileFlg = 1;
                    userServiceFilesWork.FileContent = tmp;
                }
                else
                {
                    userFileNm = Path.Combine(workDir, "PMCMN06200S.XML");

                    userIsExist = File.Exists(userFileNm);

                    // �t�@�C�����݃`�F�b�N
                    if (userIsExist)
                    {
                        FileStream fs = new FileStream(userFileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                        byte[] tmp = new byte[fs.Length];
                        int cnt = fs.Read(tmp, 0, (int)fs.Length);
                        for (int i = 0; i < cnt; i++)
                        {
                            tmp[i] += 8;
                        }

                        fs.Dispose();

                        // �t���O
                        fileFlg = 2;
                        userServiceFilesWork.FileContent = tmp;
                    }
                    else
                    {
                        userServiceFilesWork.FileContent = new byte[128];
                        msg = "�w�肳�ꂽ�ݒ�t�@�C��������܂���B";
                        status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }

                string commFileNm = Path.Combine(workDir, "PMCMN06200S.XML");

                bool commIsExist = File.Exists(commFileNm);

                // �t�@�C�����݃`�F�b�N
                if (commIsExist)
                {
                    FileStream fs = new FileStream(commFileNm, FileMode.Open, FileAccess.Read, FileShare.Read);
                    byte[] tmp = new byte[fs.Length];
                    int cnt = fs.Read(tmp, 0, (int)fs.Length);
                    for (int i = 0; i < cnt; i++)
                    {
                        tmp[i] += 8;
                    }

                    fs.Dispose();

                    // �t���O
                    commServiceFilesWork.FileContent = tmp;
                }


                if (!userIsExist)
                {
                    userServiceFilesWork.FileContent = new byte[128];
                }

                if (!commIsExist)
                {
                    commServiceFilesWork.FileContent = new byte[128];
                }

                if (!userIsExist && !commIsExist)
                {
                    msg = "�w�肳�ꂽ�ݒ�t�@�C��������܂���B";
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }
            }
            catch
            {
                msg = "XML�t�@�C���̓��e���s���ł��B";
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            userFile = userServiceFilesWork as object;
            commFile = commServiceFilesWork as object;

            return status;
        }
        // ---- ADD 杍^ 2014/10/02 ----------------------------<<<<<
    }
}
