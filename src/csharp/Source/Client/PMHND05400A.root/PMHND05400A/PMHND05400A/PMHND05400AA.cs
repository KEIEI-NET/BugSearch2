//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���I������(���)�A�N�Z�X�N���X
// �v���O�����T�v   : �n���f�B�^�[�~�i���I������(���)�A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : ���O
// �� �� ��  2017/08/16  �C�����e : �V�K�쐬
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
using System.Collections.Generic;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �n���f�B�^�[�~�i���I������(���)�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �n���f�B�^�[�~�i���I������(���)�A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/08/16</br>
    /// </remarks>
    public class HandyInventAcs
    {
        #region [�萔]
        /// <summary>����������ɏI�������ꍇ�̃X�e�[�^�X</summary>
        private const int StatusNomal = 0;
        /// <summary>��񂪌�����Ȃ��ꍇ�̃X�e�[�^�X</summary>
        private const int StatusNotFound = 4;
        /// <summary>�^�C���A�E�g���������ꍇ�̃X�e�[�^�X</summary>
        private const int StatusTimeout = 5;
        /// <summary>DB�������ŃG���[�����������ꍇ�̃X�e�[�^�X</summary>
        private const int StatusError = -1;
        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>���O�p�X</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNamePgid = "PMHND05400A_";
        /// <summary>�f�t�H���g���O�t�@�C���g���q</summary>
        private const string DefaultNameFile = ".log";
        /// <summary>�f�t�H���g���O�t�@�C�����̓��t�t�H�[�}�b�g</summary>
        private const string DefaultNameTime = "yyyyMMdd";
        /// <summary>�f�t�H���g���O���e�t�H�[�}�b�g</summary>
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>��ƃR�[�h</summary>
        private const string EnterpriseCode = "��ƃR�[�h:";
        /// <summary>�]�ƈ��R�[�h</summary>
        private const string EmployeeCode = "�]�ƈ��R�[�h:";
        /// <summary>�R���s���[�^��</summary>
        private const string MachineName = "�R���s���[�^��:";
        /// <summary>�q�ɃR�[�h</summary>
        private const string WarehouseCode = "�q�ɃR�[�h:";
        /// <summary>���i���[�J�[�R�[�h</summary>
        private const string GoodsMakerCd = "���i���[�J�[�R�[�h:";
        /// <summary>���i�o�[�R�[�h</summary>
        private const string GoodsBarCode = "���i�o�[�R�[�h:";
        /// <summary>�z�I���ʔ�</summary>
        private const string InventorySeqNo = "�z�I���ʔ�:";
        /// <summary>�I����</summary>
        private const string InventoryDate = "�I����:";
        /// <summary>�I����</summary>
        private const string InventoryStockCnt = "�I����:";
        /// <summary>���_�R�[�h</summary>
        private const string SectionCode = "���_�R�[�h:";
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
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public HandyInventAcs()
        {
            LogLockObj = new object(); 
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// �I������(���)_�I�����݊m�F����
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I������(���)�̒I���Ώۏ�񂪑��݂��邩���m�F���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchCount(object condObj)
        {
            int status = StatusError;
            // ��������
            HandyInventoryCondWork handyInventoryCondWork = condObj as HandyInventoryCondWork;
            // �p�����[�^��null�̏ꍇ�A
            if (handyInventoryCondWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ErrorMsgNull, 1);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // ���̓p�����[�^��ƃR�[�h�A�]�ƈ��R�[�h�A�R���s���[�^���A�q�ɃR�[�h�A�I�����͋󂪂���ꍇ�A�G���[��߂�܂��B
                if (string.IsNullOrEmpty(handyInventoryCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(handyInventoryCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(handyInventoryCondWork.MachineName.Trim())
                    || string.IsNullOrEmpty(handyInventoryCondWork.WarehouseCode)
                    || (handyInventoryCondWork.InventoryDate <=0))
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(handyInventoryCondWork, ErrorMsgParam, 1);
                    return status;
                }
            }
            try
            {
                #region �I���Ώۊm�F����
                // �n���f�B�^�[�~�i���z�I�������[�e�B���O�I�u�W�F�N�g
                IHandyInventoryDataDB iHandyDataObj = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                // �I���Ώۊm�F�����s���܂�
                status = iHandyDataObj.SearchCount(condObj);
                // �I�����擾������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // �I���f�[�^������Ȃ��ꍇ
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
                this.WriteLog(handyInventoryCondWork, ex.ToString(), 1);
                status = StatusError;
            }
            finally
            {
                // �����Ȃ��B
            }
            return status;
        }

        /// <summary>
        /// �I������(���)_�I���Ώێ擾
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="retObj">�������ʃI�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I������(���)�̒I���Ώۏ����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// <br>Note       : �i�Ԃƃo�[�R�[�h�����ɋ�̏ꍇ�ɃG���[�ƂȂ�悤�C��</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        public int SearchInventory(object condObj, out object retObj)
        {
            int status = StatusError;
            retObj = null;
            // ��������
            HandyInventoryCondWork inventoryCondWork = condObj as HandyInventoryCondWork;

            // �p�����[�^��null�̏ꍇ�A
            if (inventoryCondWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ErrorMsgNull, 2);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // --- MOD 2019/11/13 ---------->>>>>
                // ���̓p�����[�^��ƃR�[�h�A�]�ƈ��R�[�h�A�R���s���[�^���A�q�ɃR�[�h�A���i�o�[�R�[�h�͋󂪂���ꍇ�A�G���[��߂�܂��B
                //if (string.IsNullOrEmpty(inventoryCondWork.EnterpriseCode)
                //    || string.IsNullOrEmpty(inventoryCondWork.EmployeeCode.Trim())
                //    || string.IsNullOrEmpty(inventoryCondWork.MachineName.Trim())
                //    || string.IsNullOrEmpty(inventoryCondWork.WarehouseCode)
                //    || string.IsNullOrEmpty(inventoryCondWork.GoodsBarCode))
                //{
                //    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                //    this.WriteLog(inventoryCondWork, ErrorMsgParam, 2);
                //    return status;
                //}
                if (string.IsNullOrEmpty(inventoryCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(inventoryCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(inventoryCondWork.MachineName.Trim())
                    || string.IsNullOrEmpty(inventoryCondWork.WarehouseCode)
                    || (string.IsNullOrEmpty(inventoryCondWork.GoodsBarCode) && string.IsNullOrEmpty(inventoryCondWork.GoodsNo)))
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inventoryCondWork, ErrorMsgParam, 2);
                    return status;
                }
                // --- MOD 2019/11/13 ----------<<<<<
            }
            try
            {
                #region �I������(���)_�I���Ώێ擾
                // �n���f�B�^�[�~�i���z�I�������[�e�B���O�I�u�W�F�N�g
                IHandyInventoryDataDB iHandyInventoryDataDB = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                // �I�����擾�����s���܂�
                // --- MOD 2019/11/13 ---------->>>>>
                //status = iHandyInventoryDataDB.Search(condObj, out retObj);
                status = iHandyInventoryDataDB.SearchHandy(condObj, out retObj);
                // --- MOD 2019/11/13 ----------<<<<<

                // �I�����擾������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // �I����񂪌�����Ȃ��ꍇ
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
                this.WriteLog(inventoryCondWork, ex.ToString(), 2);
                status = StatusError;
            }
            finally
            {
                // �����Ȃ��B
            }
            return status;
        }

        # region [�I�����o�^]
        /// <summary>
        /// �I������(���)_�I���f�[�^�X�V
        /// </summary>
        /// <param name="inventoryDataObj">�o�^�p�����[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I������(���)�̒I������I���f�[�^�ɓo�^���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int WriteInventoryData(object inventoryDataObj)
        {
            int status = StatusError;
            HandyInventoryCondWork inventoryDataWork = inventoryDataObj as HandyInventoryCondWork;
            // �p�����[�^��null�̏ꍇ�A
            if (inventoryDataWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ErrorMsgNull, 3);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // �K�{���͍��ڂ̃`�F�b�N
                if (String.IsNullOrEmpty(inventoryDataWork.MachineName.Trim()) ||            // �R���s���[�^��
                    String.IsNullOrEmpty(inventoryDataWork.EmployeeCode.Trim()) ||           // �]�ƈ��R�[�h
                    String.IsNullOrEmpty(inventoryDataWork.WarehouseCode.Trim()) ||           // �q�ɃR�[�h
                    String.IsNullOrEmpty(inventoryDataWork.BelongSectionCode.Trim()) ||       // ���_�R�[�h
                    (inventoryDataWork.CirculInventSeqNo <= 0) ||      // �z�I���ʔ�
                    (inventoryDataWork.InventoryStockCnt < 0))     // �I����
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inventoryDataWork, ErrorMsgParam, 3);
                    return status;
                }
                // ���̃`�F�b�N
                if (inventoryDataWork.WarehouseCode.Length > 6 ||
                    inventoryDataWork.CirculInventSeqNo > 999999 ||
                    inventoryDataWork.InventoryStockCnt > 99999999.99 ||
                    inventoryDataWork.BelongSectionCode.Length > 6 ||
                    inventoryDataWork.MachineName.Length > 20 ||
                    inventoryDataWork.EmployeeCode.Length > 9)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inventoryDataWork, ErrorMsgParam, 3);
                    return status;
                }
            }
            try
            {
                #region �I������(���)_�I���f�[�^�X�V
                // �n���f�B�^�[�~�i���z�I�������[�e�B���O�I�u�W�F�N�g
                IHandyInventoryDataDB iInventoryDataDB = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                // �I���f�[�^�o�^�����s���܂��B
                status = iInventoryDataDB.Write(inventoryDataObj);
                // �I���f�[�^�o�^������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // �o�^���̃^�C���A�E�g�ꍇ
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
                this.WriteLog(inventoryDataWork, ex.ToString(), 3);
                status = StatusError;
            }
            finally
            {
                // �����Ȃ��B
            }
            return status;
        }
        # endregion
        # endregion

        # region [private Methods]
        /// <summary>
        /// �G���[���O�o�͏���
        /// </summary>
        /// <param name="handyInventoryWork">���������I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="mode">1:�I���Ώۊm�F�A2:�I���Ώێ擾�A3�F�I���f�[�^�X�V</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �G���[���O�����o�͂��܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void WriteLog(HandyInventoryCondWork handyInventoryWork, string errMsg, int mode)
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
                if (handyInventoryWork != null)
                {
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCode + handyInventoryWork.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + handyInventoryWork.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + handyInventoryWork.MachineName);
                    if (mode == 1)
                    {
                        // �I����
                        writer.WriteLine(InventoryDate + handyInventoryWork.InventoryDate);
                    }
                   
                    if (mode == 2)
                    {
                        // ���i�o�[�R�[�h
                        writer.WriteLine(GoodsBarCode + handyInventoryWork.GoodsBarCode);
                    }
                    if (mode == 3)
                    {
                        // �z�I���ʔ�
                        writer.WriteLine(InventorySeqNo + handyInventoryWork.CirculInventSeqNo);
                        // �I����
                        writer.WriteLine(InventoryStockCnt + handyInventoryWork.InventoryStockCnt);
                        // ���_�R�[�h
                        writer.WriteLine(SectionCode + handyInventoryWork.BelongSectionCode);
                    }
                    // �q�ɃR�[�h
                    writer.WriteLine(WarehouseCode + handyInventoryWork.WarehouseCode);
                }
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}
