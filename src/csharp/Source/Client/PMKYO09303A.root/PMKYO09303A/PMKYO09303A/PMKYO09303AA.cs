//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �����N���T�[�r�X����
// �v���O�����T�v   : �����N���T�[�r�X�̃t�@�C�����X�V����
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/21  �C�����e : �V�K�쐬
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
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Microsoft.Win32;
using System.IO;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using System.Collections;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ��M�f�[�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ȃ��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.04.29</br>
    /// </remarks>
    public class ServiceFilesInputAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private ServiceFilesInputAcs()
        {
            _conf = new conf();
            _commConf = new conf(); // ADD 杍^ 2014/10/02 
            _secInfo = new secInfo();//ADD 2011/09/01 #24278
        }
        
        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public static ServiceFilesInputAcs GetInstance()
        {
            if (_serviceFilesInputAcs == null)
            {
                _serviceFilesInputAcs = new ServiceFilesInputAcs();
            }

            return _serviceFilesInputAcs;
        }
        #endregion


        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�2
        // ===================================================================================== //
        # region ��Private Members
        private conf _conf = null;
        private conf _commConf = null; // ADD 杍^ 2014/10/02 
        private static ServiceFilesInputAcs _serviceFilesInputAcs = null;
        private IServiceFilesDB _serviceFilesDB = null;
        private secInfo _secInfo = null;//ADD 2011/09/01 #24278
        #endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region ��Properties
        /// <summary>
        /// �e�[�u���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public conf Conf
        {
            get
            {
                return this._conf;
            }
        }

        // ---- ADD 杍^ 2014/10/02 ---------------------------->>>>>
        /// <summary>
        /// �e�[�u���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public conf CommConf
        {
            get
            {
                return this._commConf;
            }
        }
        // ---- ADD 杍^ 2014/10/02 ----------------------------<<<<<

        //ADD 2011/09/01 #24278-------------->>>>>
        /// <summary>
        /// �e�[�u���I�u�W�F�N�g���擾���܂��B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.09.01</br>
        /// </remarks>
        public secInfo SecInfo
        {
            get
            {
                return this._secInfo;
            }
        }
        //ADD 2011/09/01 #24278--------------<<<<<
        #endregion


        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ��Private Methods
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="fileFlg">�t�@�C���t���O</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public int Search(ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (_serviceFilesDB == null)
            {
                _serviceFilesDB = MediationServiceFilesDB.GetServiceFilesDB();
            }

            // �t�@�C��
            object serviceFilesWork = (object)new ServiceFilesWork();


            status = _serviceFilesDB.Read(ref serviceFilesWork, ref msg, ref fileFlg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ServiceFilesWork serviceWork = (ServiceFilesWork)serviceFilesWork;

                try
                {
                    MemoryStream ms = new MemoryStream(serviceWork.FileContent);
                    _conf.ReadXml(ms);
                }
                catch
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    msg = "XML�t�@�C���̓��e���s���ł��B";
                    return status;
                }

                // ����ύX
                foreach (conf.ConfRow row in _conf.Conf)
                {
                    row.ChkStTime = GetFormatDate(row.ChkStTime);
                    row.ChkEdTime = GetFormatDate(row.ChkEdTime);
                }
            }

            return status;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="fileFlg">�t�@�C���t���O</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011.09.01</br>
        /// </remarks>
        public int SearchForAutoSendRecv(ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (_serviceFilesDB == null)
            {
                _serviceFilesDB = MediationServiceFilesDB.GetServiceFilesDB();
            }

            // �t�@�C��
            object serviceFilesWork = (object)new ServiceFilesWork();


            status = _serviceFilesDB.Read(ref serviceFilesWork, ref msg, ref fileFlg, 1);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ServiceFilesWork serviceWork = (ServiceFilesWork)serviceFilesWork;

                try
                {
                    _secInfo.Clear();
                    MemoryStream ms = new MemoryStream(serviceWork.FileContent);
                    _secInfo.ReadXml(ms);
                }
                catch
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    msg = "XML�t�@�C���̓��e���s���ł��B";
                    return status;
                }
            }

            return status;
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public int SaveData()
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            // �󔒍s���폜����
            ArrayList confRows = new ArrayList();
            //conf.ConfRow[] confRows = new conf.ConfRow[];
                //this.SelectConfRows(this._conf.Conf.PgIdColumn.ColumnName
                //+ "= '" + string.Empty + "'", this._conf.Conf);

            foreach (conf.ConfRow row in this._conf.Conf)
            {
                if (string.IsNullOrEmpty(row.PgId))
                {
                    confRows.Add(row);
                }
            }

            // �����������܂�
            foreach(conf.ConfRow row in confRows)
            {
                this._conf.Conf.RemoveConfRow(row);
            }

            // �����t�H�[�}�b�g
            foreach (conf.ConfRow row in _conf.Conf)
            {
                if (!string.IsNullOrEmpty(row.ChkStTime))
                {
                    row.ChkStTime = SetFormatDate(row.ChkStTime);
                    row.ChkEdTime = SetFormatDate(row.ChkEdTime);
                }
            }
            //ADD 2011/09/01 #24278 �f�[�^������M�������N�����܂���---------->>>>>
            _secInfo.SecInfo.Clear();
            secInfo.SecInfoRow secRow = _secInfo.SecInfo.NewSecInfoRow();
            secRow.BelongSec = LoginInfoAcquisition.Employee.BelongSectionCode;
            _secInfo.SecInfo.Rows.Add(secRow);
            string secXml = _secInfo.GetXml();
            byte[] secTmp = Encoding.Default.GetBytes(secXml);
            //ADD 2011/09/01 #24278 �f�[�^������M�������N�����܂���----------<<<<<
            // �t�@�C����ۑ�����
            string xml = _conf.GetXml();
            byte[] tmp = Encoding.Default.GetBytes(xml);

            if (_serviceFilesDB == null)
            {
                _serviceFilesDB = MediationServiceFilesDB.GetServiceFilesDB();
            }

            ServiceFilesWork serviceFilesWork = new ServiceFilesWork();
            serviceFilesWork.FileContent = tmp;
            object file = (object)serviceFilesWork;

            status = _serviceFilesDB.Write(file);

            //ADD 2011/09/01 #24278 �f�[�^������M�������N�����܂���---------->>>>>
            serviceFilesWork.FileContent = secTmp;
            object secFile = (object)serviceFilesWork;
            status = _serviceFilesDB.Write(secFile, 1);
            //ADD 2011/09/01 #24278 �f�[�^������M�������N�����܂���----------<<<<<

            // �����t�H�[�}�b�g
            foreach (conf.ConfRow row in _conf.Conf)
            {
                if (!string.IsNullOrEmpty(row.ChkStTime))
                {
                    row.ChkStTime = GetFormatDate(row.ChkStTime);
                    row.ChkEdTime = GetFormatDate(row.ChkEdTime);
                }
            }

            return status;
        }

        /// <summary>
        /// DateTime�t�H�[�}�b�g
        /// </summary>
        /// <param name="value">����</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private string GetFormatDate(string value)
        {
            string result = "";

            // length���f
            if (value.Length == 4)
            {
                result = value.Substring(0, 2) + ":" + value.Substring(2, 2);
            }
            else if (value.Length == 3)
            {
                result = "0" + value.Substring(0, 1) + ":" + value.Substring(1, 2);
            }
            else if (value.Length == 2)
            {
                result = "00:" + value;
            }
            else if (value.Length == 1)
            {
                result = "00:0" + value;
            }
            else
            {
                result = "00:00";
            }

            // �����͈͕s��
            if (Convert.ToInt32(result.Substring(0, 2)) > 23 || Convert.ToInt32(result.Substring(3, 2)) > 59)
            {
                result = "00:00";
            }

            return result;
        }

        /// <summary>
        /// DateTime�t�H�[�}�b�g
        /// </summary>
        /// <param name="value">����</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        private string SetFormatDate(string value)
        {
            string result = "";

            // �t�H�[�}�b�g
            if (value.Length == 4)
            {
                int i = 0;
                for (i = 0; i < 4; i++)
                {
                    if (!"0".Equals(value.Substring(i, 1)))
                    {
                        break;
                    }
                }

                // ���ʂ�߂�
                if (i == 4)
                {
                    result = "0";
                }
                else
                {
                    result = value.Substring(i);
                }
            }
            else
            {
                result = "0";
            }

            return result;
        }

        /// <summary>
        /// ��r�֐�
        /// </summary>
        /// <typeparam name="T">�^�w��</typeparam>
        /// <param name="condition">����</param>
        /// <param name="valueOnTrue">True�̎��̒l</param>
        /// <param name="valueOnFalse">False�̎��̒l</param>
        /// <returns>�����ɂ��I�����ꂽ�l</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        static public T diverge<T>(bool condition, T valueOnTrue, T valueOnFalse)
        {
            if (condition)
            {
                return valueOnTrue;
            }
            else
            {
                return valueOnFalse;
            }
        }

        /// <summary>
        /// �w�肵���t�B���^��������g�p���ăf�[�^�e�[�u���̑I�����s���A�Y������s�I�u�W�F�N�g�z����擾���܂��B
        /// </summary>
        /// <param name="filterExpression">�t�B���^�������邽�߂̊�ƂȂ镶����</param>
        /// <param name="confTable">�f�[�^�e�[�u���I�u�W�F�N�g</param>
        /// <returns>���㖾�׍s�I�u�W�F�N�g�z��</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public conf.ConfRow[] SelectConfRows(string filterExpression, conf.ConfDataTable confTable)
        {
            conf.ConfRow[] confRowArray = null;

            try
            {
                DataRow[] rowArray = confTable.Select(filterExpression);

                if (rowArray != null)
                {
                    confRowArray = (conf.ConfRow[])rowArray;
                }
            }
            catch { }

            return confRowArray;
        }

        /// <summary>
        /// �����_���̎擾������
        /// </summary>
        /// <returns>�����_����</returns>
        public string GetOwnSectionName(string loginSectionCode)
        {
            string ownSectionName = string.Empty;

            // �����_�̎擾
            SecInfoAcs _secInfoAcs = new SecInfoAcs();
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(loginSectionCode, out secInfoSet);
            if (secInfoSet != null)
            {
                // �����_�R�[�h�̕ۑ�
                ownSectionName = secInfoSet.SectionGuideNm;
            }

            return ownSectionName;
        }
        #endregion

        // ---- ADD 杍^ 2014/10/02 ---------------------------->>>>>
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="msg">���b�Z�[�W</param>
        /// <param name="fileFlg">�t�@�C���t���O</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.04.29</br>
        /// </remarks>
        public int SearchAll(ref string msg, ref int fileFlg)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            if (_serviceFilesDB == null)
            {
                _serviceFilesDB = MediationServiceFilesDB.GetServiceFilesDB();
            }

            // �t�@�C��
            object userServiceFilesWork = (object)new ServiceFilesWork();
            object commServiceFilesWork = (object)new ServiceFilesWork();


            status = _serviceFilesDB.Read(ref userServiceFilesWork, ref commServiceFilesWork, ref msg, ref fileFlg);
            
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ServiceFilesWork userServiceWork = (ServiceFilesWork)userServiceFilesWork;
                ServiceFilesWork commServiceWork = (ServiceFilesWork)commServiceFilesWork;
                try
                {
                    MemoryStream ms = new MemoryStream(userServiceWork.FileContent);
                    _conf.ReadXml(ms);

                    MemoryStream commMs = new MemoryStream(commServiceWork.FileContent);
                    _commConf.ReadXml(commMs);
                }
                catch
                {
                    status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                    msg = "XML�t�@�C���̓��e���s���ł��B";
                    return status;
                }

                // ����ύX
                foreach (conf.ConfRow row in _conf.Conf)
                {
                    row.ChkStTime = GetFormatDate(row.ChkStTime);
                    row.ChkEdTime = GetFormatDate(row.ChkEdTime);
                }
            }

            return status;
        }
        // ---- ADD 杍^ 2014/10/02 ----------------------------<<<<<
    }
}
