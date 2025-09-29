//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���ϑ��݌ɕ�[�A�N�Z�X�N���X
// �v���O�����T�v   : �n���f�B�^�[�~�i���ϑ��݌ɕ�[�A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 杍^
// �� �� ��  2017/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370104-00 �쐬�S�� : �e�c�@���V
// �C �� ��  2017/12/14  �C�����e :�n���f�B�^�[�~�i���O���Ή�
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �n���f�B�^�[�~�i���ϑ��݌ɕ�[�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �n���f�B�^�[�~�i���ϑ��݌ɕ�[�A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2017/08/11</br>
    /// </remarks>
    public class HandyConsStockRepAcs
    {
        #region [�萔]
        // ���擾������ɏI�������X�e�[�^�X
        private const int StatusNomal = 0;
        // ۸޲�ID��������Ȃ��X�e�[�^�X
        private const int StatusNotFound = 4;
        // �Ǎ����̃^�C���A�E�g�X�e�[�^�X
        private const int StatusTimeout = 5;
        // ���i�ΏۊO�X�e�[�^�X
        private const int StatusNonTarget = 6;
        // DB�������ŃG���[�����������X�e�[�^�X
        private const int StatusError = -1;
        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>���O�p�X</summary>
        private const string LogPath = @"\Log\PMHND";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string PgId = "PMHND01300A_";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string File = ".log";
        /// <summary>�f�t�H���g���O�t�@�C�����̓����t�H�[�}�b�g</summary>
        private const string DefaultTime = "yyyyMMdd";
        /// <summary>�f�t�H���g���O���e�t�H�[�}�b�g</summary>
        private const string DefaultFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>��ƃR�[�h</summary>
        private const string EnterpriseCod = "��ƃR�[�h:";
        /// <summary>�]�ƈ��R�[�h</summary>
        private const string EmployeeCode = "�]�ƈ��R�[�h:";
        /// <summary>�R���s���[�^��</summary>
        private const string MachineName = "�R���s���[�^��:";
        /// <summary>�ϑ��q�ɃR�[�h</summary>
        private const string ConsignWarehouseCode = "�ϑ��q�ɃR�[�h:";
        /// <summary>��ǌ��q�ɃR�[�h</summary>
        private const string MainMngWarehouseCode = "��ǌ��q�ɃR�[�h:";
        /// <summary>�o�ד�</summary>
        private const string ShipmentDay = "�o�ד�:";
        /// <summary>���i���[�J�[�R�[�h</summary>
        private const string GoodsMakerCd = "���i���[�J�[�R�[�h:";
        /// <summary>���i�ԍ�</summary>
        private const string GoodsNo = "���i�ԍ�:";
        /// <summary>�q�ɃR�[�h</summary>
        private const string WarehouseCode = "�ϑ���q�ɃR�[�h:";
        /// <summary>���i�X�e�[�^�X</summary>
        private const string InspectStatus = "���i�X�e�[�^�X:";
        /// <summary>���i�敪</summary>
        private const string InspectCode = "���i�敪:";
        /// <summary>���i��</summary>
        private const string InspectCnt = "���i��:";
        /// <summary>�����敪</summary>
        private const string OpDiv = "�����敪:";
        /// <summary>�݌ɒ����`�[�ԍ�</summary>
        private const string AcPaySlipNum = "�ϑ���݌ɒ����`�[�ԍ�:";
        /// <summary>�݌ɒ����s�ԍ�</summary>
        private const string AcPaySlipRowNo = "�ϑ���݌ɒ����s�ԍ�:";

        /// <summary>�󕥌��`�[�敪�u70:��[���Ɂv</summary>
        private const int AcPaySlipCdData70 = 70;
        /// <summary>�󕥌�����敪�u30:�݌ɐ������v</summary>
        private const int AcPayTransCdData30 = 30;
        /// <summary>�n���f�B�^�[�~�i���敪�u1:�n���f�B�^�[�~�i���v</summary>
        private const int HandTerminalCodeData1 = 1;
        /// <summary>���i�o�^�敪�u0:���i�f�[�^�o�^�v</summary>
        private const int InspectInsertModeData0 = 0;
        /// <summary>���i�X�e�[�^�X�u3:���i�ς݁v</summary>
        private const int InspectStatusData3 = 3;

        /// <summary>�p�����[�^null���b�Z�[�W</summary>
        private const string ConditionsError = "�o�^������null�ł��B";
        /// <summary>�p�����[�^�G���[���b�Z�[�W</summary>
        private const string ParametersError = "���̓p�����[�^�G���[���������܂����B";
        #endregion

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
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public HandyConsStockRepAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [�n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i���o�^����]
        /// <summary>
        /// �n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i���o�^����
        /// </summary>
        /// <param name="inspectDataListObj">�o�^�p�p�����[�^�I�u�W�F�N�g</param>
        /// <returns>�o�^���ʃX�e�[�^�X[0: ����A 0�ȊO: �G���[]</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i����o�^���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int WriteHandyConsStockRepInspect(ref object inspectDataListObj)
        {
            int status = StatusError;

            // �o�^�p�p�����[�^�f�[�^���Ȃ��ꍇ
            if (inspectDataListObj == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ConditionsError);
                return status;
            }

            ArrayList inspectDataList = inspectDataListObj as ArrayList;

            foreach (ConsStockRepInspectDataParamWork consStockRepInspectDataParamWork in inspectDataList)
            {
                // �K�{���͍��ڂ̃`�F�b�N
                // �R���s���[�^��
                if (string.IsNullOrEmpty(consStockRepInspectDataParamWork.MachineName.Trim())
                    // �]�ƈ��R�[�h
                  || string.IsNullOrEmpty(consStockRepInspectDataParamWork.EmployeeCode.Trim())
                    // ��ƃR�[�h
                  || string.IsNullOrEmpty(consStockRepInspectDataParamWork.EnterpriseCode.Trim())
                    // ����.�����敪���u17�v�ȊO�̏ꍇ�AST_ERR(-1)��ԋp���܂��B
                  || consStockRepInspectDataParamWork.OpDiv != 17
                    // �ϑ���݌ɒ����`�[�ԍ�
                  || string.IsNullOrEmpty(consStockRepInspectDataParamWork.AcPaySlipNum.Trim())
                    // �ϑ���݌ɒ����s�ԍ�
                  || consStockRepInspectDataParamWork.AcPaySlipRowNo <= 0
                    // ���i���[�J�[�R�[�h
                  || consStockRepInspectDataParamWork.GoodsMakerCd <= 0
                    // ���i�ԍ�
                  || string.IsNullOrEmpty(consStockRepInspectDataParamWork.GoodsNo.Trim())
                    // �ϑ���q�ɃR�[�h
                  || string.IsNullOrEmpty(consStockRepInspectDataParamWork.WarehouseCode.Trim()))
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(consStockRepInspectDataParamWork, ParametersError);
                    return status;
                }

                // ���̃`�F�b�N
                if (consStockRepInspectDataParamWork.GoodsMakerCd > 999999
                    || consStockRepInspectDataParamWork.AcPaySlipNum.Length > 9
                    || consStockRepInspectDataParamWork.AcPaySlipRowNo > 9999
                    || consStockRepInspectDataParamWork.GoodsNo.Length > 40
                    || consStockRepInspectDataParamWork.WarehouseCode.Length > 6
                    || consStockRepInspectDataParamWork.InspectStatus > 99
                    || consStockRepInspectDataParamWork.InspectCode > 99
                    || consStockRepInspectDataParamWork.InspectCnt > 99999999.99
                    || consStockRepInspectDataParamWork.MachineName.Length > 80
                    || consStockRepInspectDataParamWork.EmployeeCode.Length > 9)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(consStockRepInspectDataParamWork, ParametersError);
                    return status;
                }
            }

            try
            {
                ArrayList inspectDataWriteList = new ArrayList();
                HandyInspectDataWork handyInspectDataWork = null;
                foreach (ConsStockRepInspectDataParamWork consStockRepInspectDataParamWork in inspectDataList)
                {
                    handyInspectDataWork = new HandyInspectDataWork();
                    // ��ƃR�[�h
                    handyInspectDataWork.EnterpriseCode = consStockRepInspectDataParamWork.EnterpriseCode;
                    // �󕥌��`�[�敪�u�Œ�l(70:��[����)�v
                    handyInspectDataWork.AcPaySlipCd = AcPaySlipCdData70;
                    // �󕥌��`�[�ԍ�
                    handyInspectDataWork.AcPaySlipNum = consStockRepInspectDataParamWork.AcPaySlipNum;
                    // �󕥌��s�ԍ�
                    handyInspectDataWork.AcPaySlipRowNo = consStockRepInspectDataParamWork.AcPaySlipRowNo;
                    // �󕥌�����敪�u�Œ�l(30:�݌ɐ�����)�v
                    handyInspectDataWork.AcPayTransCd = AcPayTransCdData30;
                    // ���i���[�J�[�R�[�h
                    handyInspectDataWork.GoodsMakerCd = consStockRepInspectDataParamWork.GoodsMakerCd;
                    // ���i�ԍ�
                    handyInspectDataWork.GoodsNo = consStockRepInspectDataParamWork.GoodsNo;
                    // �q�ɃR�[�h
                    handyInspectDataWork.WarehouseCode = consStockRepInspectDataParamWork.WarehouseCode;
                    // ���i�X�e�[�^�X
                    handyInspectDataWork.InspectStatus = consStockRepInspectDataParamWork.InspectStatus;
                    // ���i��
                    handyInspectDataWork.InspectCnt = consStockRepInspectDataParamWork.InspectCnt;
                    // ���i�敪
                    handyInspectDataWork.InspectCode = consStockRepInspectDataParamWork.InspectCode;
                    // �n���f�B�^�[�~�i���敪�u�Œ�l(1:�n���f�B�^�[�~�i��)�v
                    handyInspectDataWork.HandTerminalCode = HandTerminalCodeData1;
                    // �[������
                    handyInspectDataWork.MachineName = consStockRepInspectDataParamWork.MachineName;
                    // �]�ƈ��R�[�h
                    handyInspectDataWork.EmployeeCode = consStockRepInspectDataParamWork.EmployeeCode;
                    inspectDataWriteList.Add(handyInspectDataWork);
                }

                object inspectDataWriteListObj = (object)inspectDataWriteList;

                // ���i���o�^����
                IInspectDataDB iInspectDataDBAdapter = MediationInspectDataDB.GetDeleteInspectDataDB();
                status = iInspectDataDBAdapter.WriteInspectData(ref inspectDataWriteListObj, InspectInsertModeData0);

                // ���i���o�^����������̏ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // ���i���o�^�������^�C���A�E�g�ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // ���i���o�^���s�ꍇ
                else
                {
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(null, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // �������Ȃ�
            }

            return status;
        }
        # endregion

        # region [�n���f�B�^�[�~�i���ϑ��݌ɕ�[_�q�ɏ�񒊏o����]
        /// <summary>
        /// �n���f�B�^�[�~�i���ϑ��݌ɕ�[_�q�ɏ�񒊏o����
        /// </summary>
        /// <param name="paraHandyWarehouseInfoCondObj">�n���f�B�^�[�~�i���ϑ��݌ɕ�[_�q�ɏ�񒊏o�������X�g</param>
        /// <param name="resultHandyWarehouseInfoObj">�n���f�B�^�[�~�i���ϑ��݌ɕ�[_�q�ɏ�񒊏o���ʃ��X�g</param>
        /// <returns>���o���ʃX�e�[�^�X[0: ����, 4:������Ȃ��A5:�^�C���A�E�g -1: �G���[]</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���ϑ��݌ɕ�[_�q�ɏ��𒊏o���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyWarehouseInfo(ref object paraHandyWarehouseInfoCondObj, out object resultHandyWarehouseInfoObj)
        {
            int status = StatusError;
            resultHandyWarehouseInfoObj = new object();

            ConsStockRepWarehouseParamWork consStockRepWarehouseParamWork = paraHandyWarehouseInfoCondObj as ConsStockRepWarehouseParamWork;

            // �K�{���͍��ڂ̃`�F�b�N
            // ��ƃR�[�h
            if (string.IsNullOrEmpty(consStockRepWarehouseParamWork.EnterpriseCode.Trim())
            // �R���s���[�^��
              || string.IsNullOrEmpty(consStockRepWarehouseParamWork.MachineName.Trim())
                // �]�ƈ��R�[�h
              || string.IsNullOrEmpty(consStockRepWarehouseParamWork.EmployeeCode.Trim())
                // ����.�q�ɃR�[�h
              || string.IsNullOrEmpty(consStockRepWarehouseParamWork.WarehouseCode))
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(consStockRepWarehouseParamWork, ParametersError);
                return status;
            }

            try
            {
                // �n���f�B�^�[�~�i���ϑ��݌ɕ�[_�q�ɏ�񒊏o�����[�g�Ăяo��
                byte[] condByte = XmlByteSerializer.Serialize(consStockRepWarehouseParamWork);

                object consStockRepWarehouseListObj = null;
                IHandyConsStockRepDB iHandyConsStockRepDBAdapter = MediationHandyConsStockRepDB.GetHandyConsStockRepDB();
                status = iHandyConsStockRepDBAdapter.SearchHandyWarehouseInfo(condByte, out consStockRepWarehouseListObj);

                // �n���f�B�^�[�~�i���ϑ��݌ɕ�[_�q�ɏ��𐳏�擾����ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    resultHandyWarehouseInfoObj = consStockRepWarehouseListObj;
                }
                // �n���f�B�^�[�~�i���ϑ��݌ɕ�[_�q�ɏ�񂪌�����Ȃ��ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // �n���f�B�^�[�~�i���ϑ��݌ɕ�[_�q�ɏ��Ǎ����̃^�C���A�E�g�ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // DB�������ŃG���[�����������ꍇ
                else
                {
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(null, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // �������Ȃ�
            }

            return status;
        }
        # endregion

        # region [�n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i��񒊏o����]
        /// <summary>
        /// �n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i��񒊏o����
        /// </summary>
        /// <param name="paraHandyInspectInfoCondObj">�n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i��񒊏o�������X�g</param>
        /// <param name="resultHandyInspectInfoObj">�n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i��񒊏o���ʃ��X�g</param>
        /// <returns>���o���ʃX�e�[�^�X[0: ����, 4:������Ȃ��A5:�^�C���A�E�g -1: �G���[]</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i���𒊏o���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyInspectInfo(ref object paraHandyInspectInfoCondObj, out object resultHandyInspectInfoObj)
        {
            int status = StatusError;
            resultHandyInspectInfoObj = new object();

            ConsStockRepInspectParamWork consStockRepInspectParamWork = paraHandyInspectInfoCondObj as ConsStockRepInspectParamWork;

            // �K�{���͍��ڂ̃`�F�b�N
            // ��ƃR�[�h
            if (string.IsNullOrEmpty(consStockRepInspectParamWork.EnterpriseCode.Trim())
            // �R���s���[�^��
              || string.IsNullOrEmpty(consStockRepInspectParamWork.MachineName.Trim())
                // �]�ƈ��R�[�h
              || string.IsNullOrEmpty(consStockRepInspectParamWork.EmployeeCode.Trim())
                // �ϑ��q�ɃR�[�h
              || string.IsNullOrEmpty(consStockRepInspectParamWork.ConsignWarehouseCode.Trim())
            // --- ADD 2017/12/14 Y.Wakita ---------->>>>>
              //  // �o�ד�
              //|| consStockRepInspectParamWork.ShipmentDay <= 0)
                // �o�ד�
              || consStockRepInspectParamWork.ShipmentDay <= 0
                // ��Ǒq�ɃR�[�h
              || string.IsNullOrEmpty(consStockRepInspectParamWork.MainMngWarehouseCode.Trim()))
            // --- ADD 2017/12/14 Y.Wakita ----------<<<<<
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(consStockRepInspectParamWork, ParametersError);
                return status;
            }

            try
            {
                // �n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i��񒊏o�����[�g�Ăяo��
                byte[] condByte = XmlByteSerializer.Serialize(consStockRepInspectParamWork);

                object inspectInfoObj = null;
                IHandyConsStockRepDB iHandyConsStockRepDBAdapter = MediationHandyConsStockRepDB.GetHandyConsStockRepDB();
                status = iHandyConsStockRepDBAdapter.SearchHandyInspectInfo(condByte, out inspectInfoObj);

                // �n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i���𐳏�擾����ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList resultHandyInspectInfoList = new ArrayList();
                    ArrayList inspectInfoList = inspectInfoObj as ArrayList;

                    foreach (ConsStockRepInspectRetWork consStockRepInspectRetWork in inspectInfoList)
                    {
                        // ���i�X�e�[�^�X���u3:���i�ς݁v�ł͂Ȃ��ꍇ�A���i�ΏۂƂ���
                        if (consStockRepInspectRetWork.InspectStatus != InspectStatusData3)
                        {
                            resultHandyInspectInfoList.Add(consStockRepInspectRetWork);
                        }
                    }
                    // �S�Ă̌��i�X�e�[�^�X���u 3:���i�ς݁v�̏ꍇ�A���i�ΏۊO�Ƃ��܂��B
                    if (resultHandyInspectInfoList.Count == 0)
                    {
                        status = StatusNonTarget;
                    }
                    // ���i�X�e�[�^�X���u3:���i�ς݁v�ȊO�̃f�[�^������ꍇ
                    else
                    {
                        status = StatusNomal;
                        resultHandyInspectInfoObj = (object)resultHandyInspectInfoList;
                    }
                }
                // �n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i��񂪌�����Ȃ��ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // �n���f�B�^�[�~�i���ϑ��݌ɕ�[_���i���Ǎ����̃^�C���A�E�g�ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // DB�������ŃG���[�����������ꍇ
                else
                {
                    status = StatusError;
                }
            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(null, ex.ToString());
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
        /// <param name="logObj">���������I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �G���[���O�����o�͂��܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private void WriteLog(object logObj, string errMsg)
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
                if (logObj is ConsStockRepWarehouseParamWork)
                {
                    ConsStockRepWarehouseParamWork consStockRepWarehouseParamWork = logObj as ConsStockRepWarehouseParamWork;
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCod + consStockRepWarehouseParamWork.EnterpriseCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + consStockRepWarehouseParamWork.MachineName);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + consStockRepWarehouseParamWork.EmployeeCode);
                    // �ϑ��q�ɃR�[�h
                    writer.WriteLine(ConsignWarehouseCode + consStockRepWarehouseParamWork.WarehouseCode);
                }
                else if (logObj is ConsStockRepInspectParamWork)
                {
                    ConsStockRepInspectParamWork consStockRepInspectParamWork = logObj as ConsStockRepInspectParamWork;
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCod + consStockRepInspectParamWork.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + consStockRepInspectParamWork.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + consStockRepInspectParamWork.MachineName);
                    // �ϑ��q�ɃR�[�h
                    writer.WriteLine(ConsignWarehouseCode + consStockRepInspectParamWork.ConsignWarehouseCode);
                    // �o�ד�
                    writer.WriteLine(ShipmentDay + consStockRepInspectParamWork.ShipmentDay);
                }
                else if (logObj is ConsStockRepInspectDataParamWork)
                {
                    ConsStockRepInspectDataParamWork consStockRepInspectDataParamWork = logObj as ConsStockRepInspectDataParamWork;
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCod + consStockRepInspectDataParamWork.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + consStockRepInspectDataParamWork.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + consStockRepInspectDataParamWork.MachineName);
                    // �����敪
                    writer.WriteLine(OpDiv + consStockRepInspectDataParamWork.OpDiv);
                    // �ϑ���݌ɒ����`�[�ԍ�
                    writer.WriteLine(AcPaySlipNum + consStockRepInspectDataParamWork.AcPaySlipNum);
                    // �ϑ���݌ɒ����s�ԍ�
                    writer.WriteLine(AcPaySlipRowNo + consStockRepInspectDataParamWork.AcPaySlipRowNo);
                    // ���[�J�[�R�[�h
                    writer.WriteLine(GoodsMakerCd + consStockRepInspectDataParamWork.GoodsMakerCd);
                    // ���i�ԍ�
                    writer.WriteLine(GoodsNo + consStockRepInspectDataParamWork.GoodsNo);
                    // �ϑ���q�ɃR�[�h
                    writer.WriteLine(WarehouseCode + consStockRepInspectDataParamWork.WarehouseCode);
                    // ���i��
                    writer.WriteLine(InspectCnt + consStockRepInspectDataParamWork.InspectCnt);
                    // ���i�敪
                    writer.WriteLine(InspectCode + consStockRepInspectDataParamWork.InspectCode);
                    // ���i�X�e�[�^�X
                    writer.WriteLine(InspectStatus + consStockRepInspectDataParamWork.InspectStatus);
                }

                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}
