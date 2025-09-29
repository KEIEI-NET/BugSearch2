//****************************************************************************//
// �V�X�e��         : PM.NS�V���[�Y
// �v���O��������   : �n���f�B�^�[�~�i���݌ɏ��擾(��s���i)�A�N�Z�X�N���X
// �v���O�����T�v   : �n���f�B�^�[�~�i���݌ɏ��擾(��s���i)�A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 杍^
// �� �� ��  2017/06/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00 �쐬�S�� : ��
// �� �� ��  2019/11/13  �C�����e : �n���f�B�U������
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

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �n���f�B�^�[�~�i���݌ɏ��擾(��s���i)�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �n���f�B�^�[�~�i���݌ɏ��擾(��s���i)�A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2017/06/15</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    public class HandyStockInspectAcs
    {
        #region [�萔]
        // ���擾������ɏI�������X�e�[�^�X
        private const int StatusNomal = 0;
        // ۸޲�ID��������Ȃ��X�e�[�^�X
        private const int StatusNotFound = 4;
        // �Ǎ����̃^�C���A�E�g�X�e�[�^�X
        private const int StatusTimeout = 5;
        // DB�������ŃG���[�����������X�e�[�^�X
        private const int StatusError = -1;
        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>���O�p�X</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNamePgid = "PMHND04110A_";
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
        private const string OpDiv = "�����敪:";
        /// <summary>�q�ɃR�[�h</summary>
        private const string WarehouseCode = "�q�ɃR�[�h:";
        /// <summary>���i���[�J�[�R�[�h</summary>
        private const string GoodsMakerCd = "���i���[�J�[�R�[�h:";
        /// <summary>���i�ԍ�</summary>
        private const string GoodsNo = "���i�ԍ�:";
        /// <summary>����揤�i�R�[�h(JAN��)</summary>
        private const string CustomerGoodsCode = "���i�o�[�R�[�h:";
        /// <summary>�q�ɒI��</summary>
        private const string WarehouseShelfNo = "�I��:";
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
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/06/15</br>
        /// </remarks>
        public HandyStockInspectAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// �n���f�B�^�[�~�i���݌ɏ��擾(��s���i)�擾����
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="retObj">�������ʃI�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���݌ɏ��擾(��s���i)���擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/06/15</br>
        /// <br>Note       : �i�Ԃƃo�[�R�[�h�����ɋ�̏ꍇ�ɃG���[�ƂȂ�悤�C��</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        public int SearchHandyStockInspect(object condObj, out object retObj)
        {
            retObj = null;
            int status = StatusError;

            // ��������
            HandyStockCondWork handyStockCondWork = condObj as HandyStockCondWork;

            // �p�����[�^��null�̏ꍇ�A
            if (handyStockCondWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(handyStockCondWork, ErrorMsgNull);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // ���̓p�����[�^�u�擾�敪���u0�v�ł͂Ȃ��ꍇ�v�A�u��ƃR�[�h�A�]�ƈ��R�[�h�A�R���s���[�^���A�q�ɃR�[�h�A����揤�i�R�[�h(JAN��)�v�͋󂪂���ꍇ�A�G���[��߂�܂��B
                // --- MOD 2019/11/13 ---------->>>>>
                //if (handyStockCondWork.OpDiv != 0 
                //    || string.IsNullOrEmpty(handyStockCondWork.EnterpriseCode)
                //    || string.IsNullOrEmpty(handyStockCondWork.EmployeeCode.Trim())
                //    || string.IsNullOrEmpty(handyStockCondWork.MachineName.Trim()) 
                //    || string.IsNullOrEmpty(handyStockCondWork.WarehouseCode)
                //    || string.IsNullOrEmpty(handyStockCondWork.CustomerGoodsCode))
                //{
                //    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                //    this.WriteLog(handyStockCondWork, ErrorMsgParam);
                //    return status;
                //}
                if (handyStockCondWork.OpDiv != 0
                    || string.IsNullOrEmpty(handyStockCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(handyStockCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(handyStockCondWork.MachineName.Trim())
                    || string.IsNullOrEmpty(handyStockCondWork.WarehouseCode)
                    || (string.IsNullOrEmpty(handyStockCondWork.CustomerGoodsCode) && string.IsNullOrEmpty(handyStockCondWork.GoodsNo)))
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(handyStockCondWork, ErrorMsgParam);
                    return status;
                }
                // --- MOD 2019/11/13 ----------<<<<<
            }

            try
            {
                #region �݌ɏ��擾(��s���i)���擾����
                // �����[�g�擾
                IHandyStockDB iHandyStockDB = (IHandyStockDB)MediationHandyStockDB.GetHandyStockDB();

                // �n���f�B�^�[�~�i�����O�C�����擾�����[�g�Ăяo��
                byte[] condByte = XmlByteSerializer.Serialize(handyStockCondWork);
                // --- MOD 2019/11/13 ---------->>>>>
                //byte[] retByte = null;
                object retByte = null;
                // --- MOD 2019/11/13 ----------<<<<<

                status = iHandyStockDB.SearchHandy(condByte, out retByte);

                // ���擾������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ԋp�p�����[�^�Z�b�g
                    // --- MOD 2019/11/13 ---------->>>>>
                    //retObj = XmlByteSerializer.Deserialize(retByte, typeof(HandyStockWork));
                    retObj = retByte;
                    // --- MOD 2019/11/13 ----------<<<<<
                    status = StatusNomal;
                }
                // �݌ɏ�񂪌�����Ȃ��ꍇ
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
                this.WriteLog(handyStockCondWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // �����Ȃ��B
            }

            return status;
        }
        # endregion

        # region [private Methods]
        /// <summary>
        /// �G���[���O�o�͏���
        /// </summary>
        /// <param name="handyStockCondWork">���������I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �G���[���O�����o�͂��܂��B</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2017/06/05</br>
        /// </remarks>
        private void WriteLog(HandyStockCondWork handyStockCondWork, string errMsg)
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
                if (handyStockCondWork != null)
                {
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCode + handyStockCondWork.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + handyStockCondWork.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + handyStockCondWork.MachineName);
                    // �����敪
                    writer.WriteLine(OpDiv + handyStockCondWork.OpDiv);
                    // �q�ɃR�[�h
                    writer.WriteLine(WarehouseCode + handyStockCondWork.WarehouseCode);
                    // ���i���[�J�[�R�[�h
                    writer.WriteLine(GoodsMakerCd + handyStockCondWork.GoodsMakerCd);
                    // ���i�ԍ�
                    writer.WriteLine(GoodsNo + handyStockCondWork.GoodsNo);
                    // ����揤�i�R�[�h(JAN��)
                    writer.WriteLine(CustomerGoodsCode + handyStockCondWork.CustomerGoodsCode);
                    // �q�ɒI��
                    writer.WriteLine(WarehouseShelfNo + handyStockCondWork.WarehouseShelfNo);
                }
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }
        #endregion
    }
}
