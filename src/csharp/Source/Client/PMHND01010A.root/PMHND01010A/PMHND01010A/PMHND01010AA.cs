//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : ���i�f�[�^�o�^(��s���i)�A�N�Z�X�N���X
// �v���O�����T�v   : ���i�f�[�^�o�^(��s���i)�A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : ���O
// �� �� ��  2017/06/30  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using System.Collections;
using System.Text;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�f�[�^�o�^(��s���i)�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�f�[�^�o�^(��s���i)�A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/06/30</br>
    /// </remarks>
    public class HandySenKouInspectAcs
    {
        #region [�萔]
        // �o�^����������ɏI�������X�e�[�^�X
        private const int NomalStatus = 0;
        // �o�^�������^�C���A�E�g�X�e�[�^�X
        private const int TimeoutStatus = 5;
        // DB�������ŃG���[�����������X�e�[�^�X
        private const int ErrorStatus = -1;
        // �݌ɊǗ��Ȃ���"0"
        private const string Zero = "0";
        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>���O�p�X</summary>
        private const string LogPath = @"\Log\PMHND";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string PgId = "PMHND01010A_";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string File = ".log";
        /// <summary>�f�t�H���g���O�t�@�C�����̓����t�H�[�}�b�g</summary>
        private const string DefaultTime = "yyyyMMdd";
        /// <summary>�f�t�H���g���O���e�t�H�[�}�b�g</summary>
        private const string DefaultFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>��ƃR�[�h</summary>
        private const string EnterpriseCod = "��ƃR�[�h:";
        /// <summary>���O�C��ID</summary>
        private const string LoginId = "�]�ƈ��R�[�h:";
        /// <summary>�R���s���[�^��</summary>
        private const string MachineName = "�R���s���[�^��:";
        /// <summary>���i���[�J�[�R�[�h</summary>
        private const string GoodsMakerCd = "���i���[�J�[�R�[�h:";
        /// <summary>���i�ԍ�</summary>
        private const string GoodsNo = "���i�ԍ�:";
        /// <summary>�q�ɃR�[�h</summary>
        private const string WarehouseCode = "�q�ɃR�[�h:";
        /// <summary>���i�敪</summary>
        private const string InspectCode = "���i�敪:";
        /// <summary>���i��</summary>
        private const string InspectCnt = "���i��:";
        /// <summary>�p�����[�^null���b�Z�[�W</summary>
        private const string ConditionsError = "�o�^������null�ł��B";
        /// <summary>�p�����[�^�G���[���b�Z�[�W</summary>
        private const string ParametersError = "���̓p�����[�^�G���[���������܂����B";
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
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        public HandySenKouInspectAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// ���i�f�[�^�o�^(��s���i)����
        /// </summary>
        /// <param name="inspectDataObj">�o�^�f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���i�f�[�^(��s���i)��o�^���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        public int WriteSenKouInspect(object inspectDataObj)
        {
            int status = ErrorStatus;
            HandyInspectDataWork inspectDataWork = inspectDataObj as HandyInspectDataWork;
            // �p�����[�^��null�̏ꍇ�A
            if (inspectDataWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ConditionsError);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // �K�{���͍��ڂ̃`�F�b�N
                if (String.IsNullOrEmpty(inspectDataWork.MachineName.Trim()) ||            // �R���s���[�^��
                    String.IsNullOrEmpty(inspectDataWork.EmployeeCode.Trim()) ||           // �]�ƈ��R�[�h
                    (inspectDataWork.GoodsMakerCd <= 0) ||           // ���[�J�[�R�[�h
                    String.IsNullOrEmpty(inspectDataWork.GoodsNo.Trim()))                  // ���i�ԍ�
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inspectDataWork, ParametersError);
                    return status;
                }

                // ���̃`�F�b�N
                if (inspectDataWork.GoodsMakerCd > 999999 ||
                    inspectDataWork.GoodsNo.Length > 40 ||
                    inspectDataWork.WarehouseCode.Length > 6 ||
                    inspectDataWork.InspectCode > 9999 ||
                    inspectDataWork.InspectCnt > 99999999 ||
                    inspectDataWork.MachineName.Length > 20 ||
                    inspectDataWork.EmployeeCode.Length > 9)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inspectDataWork, ParametersError);
                    return status;
                }
               
                inspectDataWork.AcPaySlipNum = string.Empty;
                // �󕥌��`�[�敪(20:����)
                inspectDataWork.AcPaySlipCd = 20;

                // �󕥌��s�ԍ�(0)
                inspectDataWork.AcPaySlipRowNo = 0;

                // �󕥌�����敪(11)
                inspectDataWork.AcPayTransCd = 11;

                // �q�ɃR�[�h�@(��̎���"0")
                if (String.IsNullOrEmpty(inspectDataWork.WarehouseCode))
                {
                    inspectDataWork.WarehouseCode = Zero;
                }

                // ���i�X�e�[�^�X(3:���i�ς�)
                inspectDataWork.InspectStatus = 3;

                // �n���f�B�^�[�~�i���敪:�Œ�l(1:�n���f�B�^�[�~�i��)
                inspectDataWork.HandTerminalCode = 1;
            }
            try
            {
                // �����[�g�擾
                IInspectDataDB iHandyInspectDB = (IInspectDataDB)MediationInspectDataDB.GetDeleteInspectDataDB();
                status = iHandyInspectDB.WriteInspectData(ref inspectDataObj, 1);

                // �o�^����������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = NomalStatus;
                }
                // �o�^�������^�C���A�E�g�̏ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = TimeoutStatus;
                }
                // DB�������ŃG���[�����������ꍇ
                else
                {
                    status = ErrorStatus;
                }
            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(inspectDataWork, ex.ToString());
                status = ErrorStatus;
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
        /// <param name="handyInspectDataWork">���������I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �G���[���O�����o�͂��܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/06/30</br>
        /// </remarks>
        private void WriteLog(HandyInspectDataWork handyInspectDataWork, string errMsg)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + LogPath;

            lock (LogLockObj)
            {
                // �t�H���_�����݂��Ȃ��ꍇ�A
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                FileStream fileStream = new FileStream(Path.Combine(path, PgId + DateTime.Now.ToString(DefaultTime) + File), FileMode.Append, FileAccess.Write, FileShare.Write);
                StreamWriter writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                DateTime writingDateTime = DateTime.Now;
                writer.WriteLine(string.Format(DefaultFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                // �p�����[�^��null�ł͂Ȃ��ꍇ�A�G���[���b�Z�[�W�Ɉ����̖��O�ƒl���o�͂��܂��B
                if (handyInspectDataWork != null)
                {
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCod + handyInspectDataWork.EnterpriseCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + handyInspectDataWork.MachineName);
                    // ���O�C��ID
                    writer.WriteLine(LoginId + handyInspectDataWork.EmployeeCode);
                    // ���i���[�J�[�R�[�h
                    writer.WriteLine(GoodsMakerCd + handyInspectDataWork.GoodsMakerCd);
                    // ���i�ԍ�
                    writer.WriteLine(GoodsNo + handyInspectDataWork.GoodsNo);
                    // �q�ɃR�[�h
                    writer.WriteLine(WarehouseCode + handyInspectDataWork.WarehouseCode);
                    // ���i�敪
                    writer.WriteLine(InspectCode + handyInspectDataWork.InspectCode);
                    // ���i��
                    writer.WriteLine(InspectCnt + handyInspectDataWork.InspectCnt);
                }
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}
