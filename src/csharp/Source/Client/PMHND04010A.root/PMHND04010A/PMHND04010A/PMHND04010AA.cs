//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���i�Ώێ擾(�ꊇ���i)�A�N�Z�X�N���X
// �v���O�����T�v   : ���i�Ώێ擾(�ꊇ���i)�A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���R
// �� �� ��  2017/06/13  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�Ώێ擾(�ꊇ���i)�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�Ώێ擾(�ꊇ���i)�A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2017/06/13</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    public class HandyInspectTotalAcs
    {
        #region [�萔]
        // ���擾������ɏI�������X�e�[�^�X
        private const int StatusNomal = 0;
        // ۸޲�ID��������Ȃ��X�e�[�^�X
        private const int StatusNotFound = 4;
        // �Ǎ����̃^�C���A�E�g�X�e�[�^�X
        private const int StatusTimeout = 5;
        // ���i�Ώۓ`�[�ł͂Ȃ��ꍇ
        private const int StatusNonTarget = 6;
        // DB�������ŃG���[�����������X�e�[�^�X
        private const int StatusError = -1;
        // ���i�X�e�[�^�X�i2:���i�ς݁j
        private const int InspectStatusAlreadyPicking = 2;
        // ���i�X�e�[�^�X�i3:���i�ς݁j
        private const int InspectStatusInspected = 3;
        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>���O�p�X</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNamePgid = "PMHND04010A_";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNameFile = ".log";
        /// <summary>�f�t�H���g���O�t�@�C�����̓����t�H�[�}�b�g</summary>
        private const string DefaultNameTime = "yyyyMMdd";
        /// <summary>�f�t�H���g���O���e�t�H�[�}�b�g</summary>
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>��ƃR�[�h</summary>
        private const string EnterpriseCode = "��ƃR�[�h:";
        /// <summary>�]�ƈ��R�[�h</summary>
        private const string EmployeeCode = "�]�ƈ��R�[�h:";
        /// <summary>�R���s���[�^��</summary>
        private const string MachineName = "�R���s���[�^��:";
        /// <summary>�����敪</summary>
        private const string ProcDiv = "�����敪:";
        /// <summary>�`�[�ԍ�</summary>
        private const string SlipNum = "�`�[�ԍ�:";
        /// <summary>�p�����[�^null���b�Z�[�W</summary>
        private const string ErrorMsgNull = "����������null�ł��B";
        /// <summary>�p�����[�^�G���[���b�Z�[�W</summary>
        private const string ErrorMsgParam = "���̓p�����[�^�G���[���������܂����B";
        #endregion

        // ===================================================================================== //
        // Static �ϐ�
        // ===================================================================================== //
        #region Static Members
        /// <summary>���O�p���b�N</summary>
        static object LogLockObj = null;
        #endregion

        # region [�R���X�g���N�^]
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �R���X�g���N�^�ł��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/13</br>
        /// </remarks>
        public HandyInspectTotalAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// ���i�Ώێ擾(�ꊇ���i)����
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="retObj">�������ʃI�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ώێ擾(�ꊇ���i)���擾���܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/13</br>
        /// </remarks>
        public int SearchHandyInspectData(object condObj, out object retObj)
        {
            retObj = null;
            int status = StatusError;

            // ��������
            HandyInspectCondWork handyInspectCondWork = condObj as HandyInspectCondWork;

            // �p�����[�^��null�̏ꍇ�A
            if (handyInspectCondWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(handyInspectCondWork, ErrorMsgNull);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // �K�{���͍��ڃ`�F�b�N
                if (String.IsNullOrEmpty(handyInspectCondWork.EnterpriseCode.Trim())  // ��ƃR�[�h���󔒂̏ꍇ
                   || String.IsNullOrEmpty(handyInspectCondWork.MachineName.Trim())   // �R���s���[�^�����󔒂̏ꍇ
                   || String.IsNullOrEmpty(handyInspectCondWork.EmployeeCode.Trim())  // �]�ƈ��R�[�h���󔒂̏ꍇ
                   || String.IsNullOrEmpty(handyInspectCondWork.SlipNum.Trim())       // �`�[�ԍ����󔒂̏ꍇ
                   || (handyInspectCondWork.ProcDiv != 1                              // �����敪���u1,2�v�ȊO�̏ꍇ
                    && handyInspectCondWork.ProcDiv != 2))                       
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(handyInspectCondWork, ErrorMsgParam);
                    return status;
                }
            }

            try
            {
                #region ���i�Ώۏ����擾����
                // �����[�g�擾
                IHandyInspectDB iHandyInspectDB = (IHandyInspectDB)MediationHandyInspectDB.GetHandyInspectDB();

                // ���i�Ώێ擾(�ꊇ���i)�����[�g�Ăяo��
                byte[] condByte = XmlByteSerializer.Serialize(handyInspectCondWork);

                object resultObj;
                status = iHandyInspectDB.SearchTotal(condByte, out resultObj);

                // ���擾������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList newRetList = new ArrayList();
                    ArrayList retList = resultObj as ArrayList;
                    foreach (HandyInspectWork retWork in retList)
                    {
                        // ���i�X�e�[�^�X���u3:���i�ς݁v�ł͂Ȃ��ꍇ�A���A
                        // (���i�X�e�[�^�X���u2:�s�b�L���O�ς݁v�@AND�@�o�ɐ� = ���i��)�ł͂Ȃ��ꍇ
                        if (retWork.InspectStatus != InspectStatusInspected
                            && !(retWork.InspectStatus == InspectStatusAlreadyPicking
                                && retWork.ShipmentCnt == retWork.InspectCnt))
                        {
                            // ���i�ΏۂƂ���
                            newRetList.Add(retWork);
                        }
                    }
                    // ���i�X�e�[�^�X�S�����u3:���i�ς݁v�̏ꍇ�A�����́A
                    // (���i�X�e�[�^�X���u2:�s�b�L���O�ς݁v�@AND�@�o�ɐ� = ���i��)�ꍇ�A
                    if (newRetList.Count == 0)
                    {
                        // ���i�ΏۊO�Ƃ���A���i�Ώۃf�[�^��ԋp���܂���B
                        status = StatusNonTarget;
                    }
                    // // ���i�X�e�[�^�X���u3:���i�ς݁v�ȊO�̃f�[�^������ꍇ
                    else
                    {
                        status = StatusNomal;
                        retObj = (object)newRetList;
                    }
                }
                // ���i�Ώۂ�������Ȃ��ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // �Ǎ����̃^�C���A�E�g�ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // DB�������ŃG���[�����������ꍇ
                else
                {
                    status = StatusError;
                }
                #endregion
            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(handyInspectCondWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // �������Ȃ�
            }

            return status;
        }
        # endregion

        # region [private Methods]
        /// <summary>
        /// �G���[���O�o�͏���
        /// </summary>
        /// <param name="handyInspectCondWork">���������I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �G���[���O�����o�͂��܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private void WriteLog(HandyInspectCondWork handyInspectCondWork, string errMsg)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + PathLog;

            lock (LogLockObj)
            {
                // �t�H���_�����݂��Ȃ��ꍇ�A
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream fileStream = new FileStream(Path.Combine(path, DefaultNamePgid + DateTime.Now.ToString(DefaultNameTime) + DefaultNameFile), FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                DateTime writingDateTime = DateTime.Now;
                writer.WriteLine(string.Format(DefaultLogFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                // �p�����[�^��null�ł͂Ȃ��ꍇ�A�G���[���b�Z�[�W�Ɉ����̖��O�ƒl���o�͂��܂��B
                if (handyInspectCondWork != null)
                {
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCode + handyInspectCondWork.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + handyInspectCondWork.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + handyInspectCondWork.MachineName);
                    // �����敪
                    writer.WriteLine(ProcDiv + handyInspectCondWork.ProcDiv);
                    // �`�[�ԍ�
                    writer.WriteLine(SlipNum + handyInspectCondWork.SlipNum);
                }
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }
        #endregion
    }
}
