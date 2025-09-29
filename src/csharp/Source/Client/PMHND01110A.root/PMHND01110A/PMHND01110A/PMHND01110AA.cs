//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏��擾�A�N�Z�X�N���X
// �v���O�����T�v   : �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏��擾�A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 杍^
// �� �� ��  2017/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏��擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏��擾�A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2017/08/11</br>
    /// <br></br>
    /// <br>Update Note:</br>
    /// </remarks>
    public class HandyNonUOEInspectAcs
    {
        #region [�萔]
        // ���擾������ɏI�������X�e�[�^�X
        private const int StatusNomal = 0;
        // ۸޲�ID��������Ȃ��X�e�[�^�X
        private const int StatusNotFound = 4;
        // �Ǎ����̃^�C���A�E�g�X�e�[�^�X
        private const int StatusTimeout = 5;
        // �d����`�[�ԍ��̏d���`�F�b�N�X�e�[�^�X
        private const int StatusRegists = 7;
        // DB�������ŃG���[�����������X�e�[�^�X
        private const int StatusError = -1;
        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>���O�p�X</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNamePgid = "PMHND01110A_";
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
        /// <summary>�d��SEQ�ԍ�</summary>
        private const string SupplierSlipNo = "�d��SEQ�ԍ�:";
        /// <summary>���i���[�J�[�R�[�h</summary>
        private const string GoodsMakerCd = "���i���[�J�[�R�[�h:";
        /// <summary>���i�ԍ�</summary>
        private const string GoodsNo = "���i�ԍ�:";
        /// <summary>�q�ɃR�[�h</summary>
        private const string WarehouseCode = "�q�ɃR�[�h:";
        /// <summary>���i�X�e�[�^�X</summary>
        private const string InspectStatus = "���i�X�e�[�^�X:";
        /// <summary>���i�敪</summary>
        private const string InspectCode = "���i�敪:";
        /// <summary>���i��</summary>
        private const string InspectCnt = "���i��:";
        /// <summary>�d�����גʔ�</summary>
        private const string StockSlipDtlNum = "�d�����גʔ�:";
        /// <summary>�d����`�[�ԍ�</summary>
        private const string PartySaleSlipNum = "�d����`�[�ԍ�:";

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
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public HandyNonUOEInspectAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏��擾����
        /// <summary>
        /// �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏��擾����
        /// </summary>
        /// <param name="paraHandyNonUOEStockSupplierCondObj">���������I�u�W�F�N�g</param>
        /// <param name="resultHandyNonUOEStockSupplierObj">�������ʃI�u�W�F�N�g</param>
        /// <returns>�������ʃX�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏����擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyNonUOEStockSupplier(ref object paraHandyNonUOEStockSupplierCondObj, out object resultHandyNonUOEStockSupplierObj)
        {
            resultHandyNonUOEStockSupplierObj = null;
            int status = StatusError;

            // ��������
            HandyNonUOEStockParamWork handyNonUOEStockParamWork = paraHandyNonUOEStockSupplierCondObj as HandyNonUOEStockParamWork;

            // �p�����[�^��null�̏ꍇ�A
            if (handyNonUOEStockParamWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(handyNonUOEStockParamWork, ErrorMsgNull);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // �p�����[�^�`�F�b�N
                // ���̓p�����[�^�u��ƃR�[�h�A�]�ƈ��R�[�h�A�R���s���[�^���A�����敪�v�͋󂪂���ꍇ�A�G���[��߂�܂��B
                if (string.IsNullOrEmpty(handyNonUOEStockParamWork.EnterpriseCode.Trim())
                    || string.IsNullOrEmpty(handyNonUOEStockParamWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(handyNonUOEStockParamWork.MachineName.Trim())
                    // ����.�����敪���u12�v�ȊO�̏ꍇ�AST_ERR(-1)��ԋp���܂��B
                    || handyNonUOEStockParamWork.OpDiv != 12)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(handyNonUOEStockParamWork, ErrorMsgParam);
                    return status;
                }
            }

            try
            {
                #region �n���f�B�^�[�~�i���݌Ɏd��(UOE�ȊO)���׏����擾����
                // �����[�g�擾
                IHandyStockSupplierDB iHandyStockSupplierDB = (IHandyStockSupplierDB)MediationHandyStockSupplierDB.GetHandyStockSuppliersDB();

                // �n���f�B�^�[�~�i���݌Ɏd�����擾�����[�g�Ăяo��
                byte[] condByte = XmlByteSerializer.Serialize(handyNonUOEStockParamWork);

                status = iHandyStockSupplierDB.SearchNonUOEStockSupplier(condByte, out resultHandyNonUOEStockSupplierObj);

                // ���擾������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
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
                this.WriteLog(handyNonUOEStockParamWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                //�@�����Ȃ��B
            }

            return status;
        }
        # endregion

        # region [�n���f�B�^�[�~�i���݌Ɏd���iUOE�ȊO�j_�o�^]
        /// <summary>
        /// �n���f�B�^�[�~�i���݌Ɏd���iUOE�ȊO�j�̓o�^����
        /// </summary>
        /// <param name="nonUOEInspectListObj">�o�^�p�p�����[�^�I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X[0: ����A 0�ȊO: �G���[]</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���݌Ɏd���iUOE�ȊO�j��o�^���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int WriteHandyNonUOEInspect(ref object nonUOEInspectListObj)
        {
            int status = StatusError;

            // �o�^�p�p�����[�^�f�[�^���Ȃ��ꍇ
            if (nonUOEInspectListObj == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ErrorMsgNull);
                return status;
            }

            ArrayList nonUOEInspectList = nonUOEInspectListObj as ArrayList;
            Dictionary<long, string> nonUOEInspectDic = new Dictionary<long, string>();
            // �o�^�p���i�f�[�^�I�u�W�F�N�g
            object nonUOEInspectWriteObj = null;
            // �o�^�p���i�f�[�^���X�g
            ArrayList nonUOEInspectWriteList = new ArrayList();

            foreach (HandyNonUOEInspectParamWork handyNonUOEInspectParamWork in nonUOEInspectList)
            {
                // �K�{���͍��ڂ̃`�F�b�N
                // �R���s���[�^��
                if (String.IsNullOrEmpty(handyNonUOEInspectParamWork.MachineName.Trim())
                    // �]�ƈ��R�[�h
                  || String.IsNullOrEmpty(handyNonUOEInspectParamWork.EmployeeCode.Trim())
                    // ��ƃR�[�h
                  || String.IsNullOrEmpty(handyNonUOEInspectParamWork.EnterpriseCode.Trim())
                    // �q�ɃR�[�h
                  || String.IsNullOrEmpty(handyNonUOEInspectParamWork.WarehouseCode.Trim())
                    // ����.�����敪���u12:�݌Ɏd���iUOE�ȊO�j�v�ȊO�̏ꍇ�AST_ERR(-1)��ԋp���܂��B
                  || (handyNonUOEInspectParamWork.OpDiv != 12)
                    // ���[�J�[�R�[�h
                  || (handyNonUOEInspectParamWork.GoodsMakerCd <= 0)
                    // �d��SEQ�ԍ�
                  || (handyNonUOEInspectParamWork.SupplierSlipNo <= 0)
                    // �d�����גʔ�
                  || (handyNonUOEInspectParamWork.StockSlipDtlNum <= 0)
                    // ���i�ԍ�
                  || String.IsNullOrEmpty(handyNonUOEInspectParamWork.GoodsNo.Trim()))
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(handyNonUOEInspectParamWork, ErrorMsgParam);
                    return status;
                }

                // ���̃`�F�b�N
                if (handyNonUOEInspectParamWork.GoodsMakerCd > 999999
                    || handyNonUOEInspectParamWork.PartySaleSlipNum.Length > 19
                    || handyNonUOEInspectParamWork.GoodsNo.Length > 40
                    || handyNonUOEInspectParamWork.WarehouseCode.Length > 6
                    || handyNonUOEInspectParamWork.InspectStatus > 99
                    || handyNonUOEInspectParamWork.InspectCode > 99
                    || handyNonUOEInspectParamWork.InspectCnt > 99999999.99
                    || handyNonUOEInspectParamWork.MachineName.Length > 80
                    || handyNonUOEInspectParamWork.EmployeeCode.Length > 9)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(handyNonUOEInspectParamWork, ErrorMsgParam);
                    return status;
                }

                // ���i��>0�̏ꍇ�A�����p�����[�^�f�B�N�V���i���[���쐬���܂��B
                if (handyNonUOEInspectParamWork.InspectCnt > 0)
                {
                    if (!nonUOEInspectDic.ContainsKey(handyNonUOEInspectParamWork.StockSlipDtlNum))
                    {
                        nonUOEInspectDic.Add(handyNonUOEInspectParamWork.StockSlipDtlNum, string.Empty);
                    }

                    nonUOEInspectWriteList.Add(handyNonUOEInspectParamWork);
                }
            }

            // ����.���i��>0�̃f�[�^���Ȃ��ꍇ
            if (nonUOEInspectWriteList.Count == 0)
            {
                status = StatusNomal;
                return status;
            }

            try
            {
                // ���ɍX�V����
                IHandyStockSupplierDB iHandyStockSupplierDBAdapter = MediationHandyStockSupplierDB.GetHandyStockSuppliersDB();

                HandyNonUOEInspectParamWork handyNonUOEInspectParamWork = (HandyNonUOEInspectParamWork)nonUOEInspectList[0];

                // �n���f�B�^�[�~�i���݌Ɏd�����擾�����[�g�Ăяo��
                byte[] condByte = XmlByteSerializer.Serialize(handyNonUOEInspectParamWork);

                object orderListResultObj = null;
                status = iHandyStockSupplierDBAdapter.SearchHandyNonUOESlipInfo(condByte, out orderListResultObj);

                // �݌Ɏd�����̓A�N�Z�X���������s�ꍇ
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusError;
                    return status;
                }

                List<OrderListResultWork> orderListResultWorkList = new List<OrderListResultWork>();

                foreach (OrderListResultWork orderListResultWork in (ArrayList)orderListResultObj)
                {
                    if (nonUOEInspectDic.ContainsKey(orderListResultWork.StockSlipDtlNum))
                    {
                        orderListResultWorkList.Add(orderListResultWork);
                    }
                }

                // �݌Ɏd�����̓A�N�Z�X���������s�ꍇ
                if (orderListResultWorkList.Count == 0)
                {
                    status = StatusError;
                    return status;
                }

                object stockWriteDataListObj = null;
                // ����.�d����`�[�ԍ���NULL�̏ꍇ
                if (string.IsNullOrEmpty(handyNonUOEInspectParamWork.PartySaleSlipNum.Trim()))
                {
                    // �݌Ɏd�����̓A�N�Z�X������
                    AdjustStockAcs adjustStockAcs = new AdjustStockAcs(handyNonUOEInspectParamWork.EnterpriseCode, handyNonUOEInspectParamWork.BelongSectionCode, out status);

                    // �݌Ɏd�����̓A�N�Z�X���������s�̏ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // �݌Ɏd�����̃f�[�^�Z�b�g����
                    status = adjustStockAcs.OrderListResultWorkToGridForHandy(handyNonUOEInspectParamWork.BelongSectionCode, orderListResultWorkList);

                    // �݌Ɏd�����̃f�[�^�Z�b�g�������s�̏ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // �݌Ɏd�����̎d�����A�d���㐔�̕␳����
                    status = adjustStockAcs.SetInspectDataForHandy(nonUOEInspectList);

                    // �݌Ɏd�����̎d�����A�d���㐔�̕␳���������s�̏ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // �݌Ɏd�����o�^�f�[�^�̎擾����
                    status = adjustStockAcs.GetSaveDBDataForHandy(handyNonUOEInspectParamWork.BelongSectionCode, handyNonUOEInspectParamWork.EmployeeCode, out stockWriteDataListObj);

                    // �݌Ɏd�����o�^�f�[�^�̎擾���������s�̏ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }
                }
                // ����.�d����`�[�ԍ���NULL�ł͂Ȃ��ꍇ
                else
                {
                    // �d�����̓A�N�Z�X������
                    StockSlipInputAcs stockSlipInputAcs = new StockSlipInputAcs(handyNonUOEInspectParamWork.EnterpriseCode, handyNonUOEInspectParamWork.BelongSectionCode, orderListResultWorkList.Count, out status);

                    // �d�����̓A�N�Z�X���������s�ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // �d����`�[�ԍ��̏d���`�F�b�N
                    status = stockSlipInputAcs.ReadStockSlipForHandy(handyNonUOEInspectParamWork.EnterpriseCode, handyNonUOEInspectParamWork.BelongSectionCode, handyNonUOEInspectParamWork.PartySaleSlipNum, orderListResultWorkList[0].SupplierCd);

                    // �n���f�B��p��ReadStockSlipForHandy�̖߂�l������I���̏ꍇ�AST_REGISTS(7)��ԋp���܂��B
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusRegists;
                        return status;
                    }
                    // �d����`�[�ԍ��d�����Ȃ��ꍇ�A�o�^�����𑱂���B
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        // �����Ȃ��B
                    }
                    // �d����`�[�ԍ��̏d���`�F�b�N�������^�C���A�E�g�ꍇ
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        status = StatusTimeout;
                        return status;
                    }
                    // �d����`�[�ԍ��̏d���`�F�b�N�������s�ꍇ
                    else
                    {
                        status = StatusError;
                        return status;
                    }

                    // �d�����׃f�[�^�s�̃f�[�^�Z�b�g����
                    status = stockSlipInputAcs.StockDetailRowSettingFromOrderListResultWorkListForHandy(handyNonUOEInspectParamWork.BelongSectionCode, orderListResultWorkList);

                    // �d�����׃f�[�^�s�̃f�[�^�Z�b�g���������s�̏ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // ���i���̐ݒ菈��
                    status = stockSlipInputAcs.SetInspectDataForHandy(nonUOEInspectList);

                    // ���i���̐ݒ菈�������s�̏ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // �d���f�[�^�̎擾����
                    status = stockSlipInputAcs.GetSaveDataForHandy(handyNonUOEInspectParamWork.EmployeeCode, handyNonUOEInspectParamWork.BelongSectionCode, out stockWriteDataListObj);

                    // �d���f�[�^�̎擾���������s�̏ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }
                }

                // ���i�f�[�^�o�^����
                nonUOEInspectWriteObj = (object)nonUOEInspectWriteList;
                status = iHandyStockSupplierDBAdapter.WriteHandyStockData(ref nonUOEInspectWriteObj, ref stockWriteDataListObj);

                // ���ɍX�V(UOE�ȊO)����������̏ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // ���ɍX�V(UOE�ȊO)�������^�C���A�E�g�ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    status = StatusTimeout;
                }
                // ���ɍX�V(UOE�ȊO)�������s�ꍇ
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
                if (logObj is HandyNonUOEStockParamWork)
                {
                    HandyNonUOEStockParamWork handyNonUOEStockParamWork = logObj as HandyNonUOEStockParamWork;
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCode + handyNonUOEStockParamWork.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + handyNonUOEStockParamWork.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + handyNonUOEStockParamWork.MachineName);
                    // �����敪
                    writer.WriteLine(OpDiv + handyNonUOEStockParamWork.OpDiv);
                    // �d��SEQ�ԍ�
                    writer.WriteLine(SupplierSlipNo + handyNonUOEStockParamWork.SlipNo);
                }
                else if (logObj is HandyNonUOEInspectParamWork)
                {
                    HandyNonUOEInspectParamWork handyNonUOEInspectParamWork = logObj as HandyNonUOEInspectParamWork;
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCode + handyNonUOEInspectParamWork.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + handyNonUOEInspectParamWork.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + handyNonUOEInspectParamWork.MachineName);
                    // ���i���[�J�[�R�[�h
                    writer.WriteLine(GoodsMakerCd + handyNonUOEInspectParamWork.GoodsMakerCd);
                    // ���i�ԍ�
                    writer.WriteLine(GoodsNo + handyNonUOEInspectParamWork.GoodsNo);
                    // �q�ɃR�[�h
                    writer.WriteLine(WarehouseCode + handyNonUOEInspectParamWork.WarehouseCode);
                    // ���i�X�e�[�^�X
                    writer.WriteLine(InspectStatus + handyNonUOEInspectParamWork.InspectStatus);
                    // ���i�敪
                    writer.WriteLine(InspectCode + handyNonUOEInspectParamWork.InspectCode);
                    // ���i��
                    writer.WriteLine(InspectCnt + handyNonUOEInspectParamWork.InspectCnt);
                    // �����敪
                    writer.WriteLine(OpDiv + handyNonUOEInspectParamWork.OpDiv);
                    // �d��SEQ�ԍ�
                    writer.WriteLine(SupplierSlipNo + handyNonUOEInspectParamWork.SupplierSlipNo);
                    // �d�����גʔ�
                    writer.WriteLine(StockSlipDtlNum + handyNonUOEInspectParamWork.StockSlipDtlNum);
                    // �d����`�[�ԍ�
                    writer.WriteLine(PartySaleSlipNum + handyNonUOEInspectParamWork.PartySaleSlipNum);
                }
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}
