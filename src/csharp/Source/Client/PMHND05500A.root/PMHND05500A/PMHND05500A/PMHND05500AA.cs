//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���z�I���A�N�Z�X�N���X
// �v���O�����T�v   : �n���f�B�^�[�~�i���z�I���A�N�Z�X�N���X�ł�
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
using System.Collections;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �n���f�B�^�[�~�i���z�I���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �n���f�B�^�[�~�i���z�I���A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/08/16</br>
    /// </remarks>
    public class HandyCirculInventAcs
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
        private const string DefaultNamePgid = "PMHND05500A_";
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
        /// <summary>�����敪</summary>
        private const string ProcDiv = "�����敪:";
        /// <summary>�q�ɃR�[�h</summary>
        private const string WarehouseCode = "�q�ɃR�[�h:";
        /// <summary>���i�o�[�R�[�h</summary>
        private const string GoodsBarCode = "���i�o�[�R�[�h:";
        /// <summary>���i���[�J�[�R�[�h</summary>
        private const string GoodsMakerCd = "���i���[�J�[�R�[�h:";
        /// <summary>���i�ԍ�</summary>
        private const string GoodsNo = "���i�ԍ�:";
        /// <summary>�z�I���ʔ�</summary>
        private const string InventorySeqNo = "�z�I���ʔ�:";
        /// <summary>�I��</summary>
        private const string WarehouseShelfNo = "�I��:";
        /// <summary>�I����</summary>
        private const string InventoryStockCnt = "�I����:";
        /// <summary>���l</summary>
        private const string Note = "���l:";
        /// <summary>����t���O</summary>
        private const string FirstFlg = "����t���O:"; 
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
        public HandyCirculInventAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// �I�������i�z��)_�q�ɑ��݊m�F����
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�������i�z��)�w��q�ɂɍ݌ɏ�񂪑��݂��Ă��邩���m�F���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchStockCount(object condObj)
        {
            int status = StatusError;

            // ��������
            HandyInventoryCondWork circulInventCondWork = condObj as HandyInventoryCondWork;

            // �p�����[�^��null�̏ꍇ�A
            if (circulInventCondWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ErrorMsgNull, 1);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // ���̓p�����[�^��ƃR�[�h�A�]�ƈ��R�[�h�A�R���s���[�^���A�q�ɃR�[�h�͋󂪂���ꍇ�A�G���[��߂�܂��B
                if (string.IsNullOrEmpty(circulInventCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(circulInventCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(circulInventCondWork.MachineName.Trim())
                    || string.IsNullOrEmpty(circulInventCondWork.WarehouseCode))
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(circulInventCondWork, ErrorMsgParam, 1);
                    return status;
                }
            }
            try
            {
                #region �q�ɑ��݊m�F
                byte[] condByte = XmlByteSerializer.Serialize(circulInventCondWork);
                IHandyInventoryDataDB iInventoryDataDBObj = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                status = iInventoryDataDBObj.SearchStockCount(condByte);

                // ���擾������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    status = StatusNomal;
                }
                // �q�ɂɍ݌ɏ�񂪌�����Ȃ��ꍇ
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
                this.WriteLog(circulInventCondWork, ex.ToString(), 1);
                status = StatusError;
            }
            finally
            {
                // �����Ȃ��B
            }

            return status;
        }

        /// <summary>
        /// �I�������i�z��)_�݌ɏ��擾����
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="retObj">�������ʃI�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I�������i�z��)�̎w��݌ɕi�̍݌ɏ����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchStock(object condObj,out object retObj)
        {
            int status = StatusError;
            retObj = null;
            // ��������
            HandyStockCondWork stockCondWork = new HandyStockCondWork();
            HandyInventoryCondWork circulInventCondWork = condObj as HandyInventoryCondWork;
            // �����敪�F����͖��g�p�ׁ̈A�f�t�H���g�l���u0:����Ǎ��v
            // --- MOD 2019/11/13 ---------->>>>>
            //stockCondWork.OpDiv = circulInventCondWork.ProcDiv;
            stockCondWork.OpDiv = circulInventCondWork.ProcDiv;
            if (string.IsNullOrEmpty(circulInventCondWork.GoodsBarCode) && !string.IsNullOrEmpty(circulInventCondWork.GoodsNo))
            {
                // �i�Ԍ���
                stockCondWork.GoodsNo = circulInventCondWork.GoodsNo;
            }
            // --- MOD 2019/11/13 ----------<<<<<
            // ��ƃR�[�h
            stockCondWork.EnterpriseCode = circulInventCondWork.EnterpriseCode;
            // �]�ƈ��R�[�h
            stockCondWork.EmployeeCode = circulInventCondWork.EmployeeCode;
            // �R���s���[�^��
            stockCondWork.MachineName = circulInventCondWork.MachineName;
            // �q�ɃR�[�h
            stockCondWork.WarehouseCode = circulInventCondWork.WarehouseCode;
            // ���i�o�[�R�[�h
            stockCondWork.CustomerGoodsCode = circulInventCondWork.GoodsBarCode;

            // �p�����[�^��null�̏ꍇ�A
            if (circulInventCondWork == null)
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
                //if (string.IsNullOrEmpty(circulInventCondWork.EnterpriseCode)
                //    || string.IsNullOrEmpty(circulInventCondWork.EmployeeCode.Trim())
                //    || string.IsNullOrEmpty(circulInventCondWork.MachineName.Trim())
                //    || string.IsNullOrEmpty(circulInventCondWork.WarehouseCode.Trim())
                //    || string.IsNullOrEmpty(circulInventCondWork.GoodsBarCode.Trim())
                //    || circulInventCondWork.ProcDiv != 0)
                //{
                //    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                //    this.WriteLog(circulInventCondWork, ErrorMsgParam, 2);
                //    return status;
                //}
                // 2019/11 ���̓p�����[�^��ƃR�[�h�A�]�ƈ��R�[�h�A�R���s���[�^���A�q�ɃR�[�h�A���i�o�[�R�[�h�{���i�ԍ��͋󂪂���ꍇ�A�G���[��߂�܂��B
                if (string.IsNullOrEmpty(circulInventCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(circulInventCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(circulInventCondWork.MachineName.Trim())
                    || string.IsNullOrEmpty(circulInventCondWork.WarehouseCode.Trim())
                    || (string.IsNullOrEmpty(circulInventCondWork.GoodsBarCode.Trim()) && string.IsNullOrEmpty(circulInventCondWork.GoodsNo.Trim()))
                    || circulInventCondWork.ProcDiv != 0)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(circulInventCondWork, ErrorMsgParam, 2);
                    return status;
                }
                // --- MOD 2019/11/13 ----------<<<<<
            }
            try
            {
                #region �I�������i�z��)_�݌ɏ��擾����
                byte[] condByte = XmlByteSerializer.Serialize(stockCondWork);
                IHandyInventoryDataDB iInventoryDataDB = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                status = iInventoryDataDB.SearchStockHandy(condByte, out retObj);

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
                this.WriteLog(circulInventCondWork, ex.ToString(), 2);
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
        /// �I�������i�z��)_�I�����o�^
        /// </summary>
        /// <param name="inventoryDataObj">�o�^�p�����[�^</param>
        /// <param name="retObj">�z�I���ʔ�</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �I������o�^���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int WriteCirculInventoryData(object inventoryDataObj, out object retObj)
        {
            int status = StatusError;
            retObj = null;
            HandyInventoryCondWork circulInventCondWork = inventoryDataObj as HandyInventoryCondWork;
            // �p�����[�^��null�̏ꍇ�A
            if (circulInventCondWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ErrorMsgNull, 3);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // �K�{���͍��ڂ̃`�F�b�N
                if (String.IsNullOrEmpty(circulInventCondWork.EnterpriseCode.Trim()) ||            // ��ƃR�[�h
                    String.IsNullOrEmpty(circulInventCondWork.MachineName.Trim()) ||            // �R���s���[�^��
                    String.IsNullOrEmpty(circulInventCondWork.EmployeeCode.Trim()) ||           // �]�ƈ��R�[�h
                    String.IsNullOrEmpty(circulInventCondWork.WarehouseCode.Trim()) ||           // �q�ɃR�[�h
                    (circulInventCondWork.GoodsMakerCd <= 0) ||           // ���[�J�[�R�[�h
                    (circulInventCondWork.CirculInventSeqNo < 0) ||      // �z�I���ʔ�
                    (circulInventCondWork.InventoryStockCnt < 0) ||      // �I����
                    (circulInventCondWork.FirstFlg <= 0) ||      // ����t���O
                    String.IsNullOrEmpty(circulInventCondWork.GoodsNo.Trim()))                  // ���i�ԍ�
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(circulInventCondWork, ErrorMsgParam, 3);
                    return status;
                }

                // ���̃`�F�b�N
                if (circulInventCondWork.GoodsMakerCd > 999999 ||
                    circulInventCondWork.GoodsNo.Length > 40 ||
                    circulInventCondWork.WarehouseCode.Length > 6 ||
                    circulInventCondWork.CirculInventSeqNo > 999999999 ||
                    circulInventCondWork.InventoryStockCnt > 99999999.99 ||
                    circulInventCondWork.WarehouseShelfNo.Length > 8 ||
                    circulInventCondWork.Note.TrimEnd().Length > 20 ||
                    circulInventCondWork.MachineName.Length > 20 ||
                    circulInventCondWork.EmployeeCode.Length > 9)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(circulInventCondWork, ErrorMsgParam, 3);
                    return status;
                }

                // ����.����t���O���u1,2�v�ȊO�̏ꍇ�AST_ERR(-1)��ԋp���܂��B
                if (circulInventCondWork.FirstFlg != 1 && circulInventCondWork.FirstFlg != 2)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(circulInventCondWork, ErrorMsgParam, 3);
                    return status;
                }
                // ����.����t���O���u1�v�̏ꍇ�A����.�z�I���ʔԂ��[���ȊO�ł���΁AST_ERR(-1)��ԋp���܂��B
                if (circulInventCondWork.FirstFlg == 1)
                {
                    if (circulInventCondWork.CirculInventSeqNo != 0)
                    {
                        // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                        this.WriteLog(circulInventCondWork, ErrorMsgParam, 3);
                        return status;
                    }
                }
                // ����.����t���O���u2�v�̏ꍇ�A����.�z�I���ʔԂ��[���ł���΁AST_ERR(-1)��ԋp���܂��B
                else
                {
                    if (circulInventCondWork.CirculInventSeqNo == 0)
                    {
                        // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                        this.WriteLog(circulInventCondWork, ErrorMsgParam, 3);
                        return status;
                    }
                }
            }
            try
            {
                List<GoodsUnitData> goodsUnitDataList;
                string msg;
                // �����������쐬
                GoodsCndtn cnd = new GoodsCndtn();
                cnd.ListPriorWarehouse = new List<string>();
                // ��ƃR�[�h
                cnd.EnterpriseCode = circulInventCondWork.EnterpriseCode;
                // ���_�R�[�h
                cnd.SectionCode = circulInventCondWork.BelongSectionCode;
                // ���i�ԍ�
                cnd.GoodsNo = circulInventCondWork.GoodsNo;
                // ���i���[�J�[�R�[�h
                cnd.GoodsMakerCd = circulInventCondWork.GoodsMakerCd;
                // �D��q�ɃR�[�h���X�g
                cnd.ListPriorWarehouse.Add(circulInventCondWork.WarehouseCode);
                // ���i�ԍ������敪(0�F���S��v�Œ�)
                cnd.GoodsNoSrchTyp = 0;
                // ���i����(9�F�S��)
                cnd.GoodsKindCode = 9;
                // ���i�K�p��(�V�X�e�����t)
                cnd.PriceApplyDate = DateTime.Now;
                // �݌ɒ������׃f�[�^���X�g
                ArrayList stockAdjustDtlList = new ArrayList();
                // �݌ɒ����f�[�^���X�g
                ArrayList stockAdjustList = new ArrayList();
                // �݌ɍX�V�p���X�g
                ArrayList stockUpdateList = new ArrayList();
                // �z�I�����𖾍׃f�[�^���X�g
                ArrayList circulInventHisDtlList = new ArrayList();
                // �z�I�������f�[�^���X�g
                ArrayList circulInventHisDataList = new ArrayList();
                CustomSerializeArrayList csArrayList = new CustomSerializeArrayList();
                CustomSerializeArrayList upArrayList = new CustomSerializeArrayList();
                long stockPriceTaxExc;
                // ���i�A�����擾
                GoodsAcs goodsObj = new GoodsAcs();
                status = goodsObj.Search(cnd, out goodsUnitDataList, out msg);
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                    {
                        foreach (Stock stock in goodsUnitData.StockList)
                        {
                            if (stock.WarehouseCode == circulInventCondWork.WarehouseCode)
                            {
                                // �擾�������i�A����񂩂�A�݌ɏ��D�o�׉\����������.�I�����̏ꍇ�A�݌ɒ������f�[�^���X�g���쐬����
                                if (stock.ShipmentPosCnt != circulInventCondWork.InventoryStockCnt)
                                {
                                    // �݌ɒ������׃f�[�^���X�g�̍쐬
                                    stockAdjustDtlList.Add(CreateStockAdjustDtl(goodsUnitData, circulInventCondWork, stock, out stockPriceTaxExc));
                                    csArrayList.Add(stockAdjustDtlList);
                                    // �݌ɒ����f�[�^���X�g�̍쐬
                                    stockAdjustList.Add(CreateStockAdjust(circulInventCondWork, stockPriceTaxExc));
                                    csArrayList.Add(stockAdjustList);
                                }
                                // �݌ɏ��D�o�׉\����������.�I�����A�������͒I�Ԃ��ύX���ꂽ�ꍇ�ɍ݌ɍX�V�p���X�g���쐬����
                                if (stock.ShipmentPosCnt != circulInventCondWork.InventoryStockCnt || stock.WarehouseShelfNo != circulInventCondWork.WarehouseShelfNo)
                                {
                                    // �݌ɍX�V�p���X�g�̍쐬
                                    stockUpdateList.Add(GetStockWork(stock, circulInventCondWork));
                                    csArrayList.Add(stockUpdateList);
                                }
                                // ����t���O���u1�F����v�̏ꍇ�̂ݏz�I�������f�[�^�쐬
                                if (circulInventCondWork.FirstFlg == 1)
                                {
                                    // �z�I�������f�[�^�̍쐬
                                    circulInventHisDataList.Add(GetCirculInventHisData(circulInventCondWork));
                                    csArrayList.Add(circulInventHisDataList);
                                }
                                // �z�I�����𖾍׃f�[�^���X�g�̍쐬
                                circulInventHisDtlList.Add(GetCirculInventHisDtl(stock, circulInventCondWork));
                                csArrayList.Add(circulInventHisDtlList);
                                break;
                            }  
                        }
                    }
                    // �f�[�^���X�g���i�[����
                    upArrayList.Add(csArrayList);

                    object csArrayObj = upArrayList;
                    int circulInventSeqNo = 0;
                    IHandyInventoryDataDB iHandyInventoryDataDB = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                    // �c�a�X�V
                    status = iHandyInventoryDataDB.WriteCirculInvent(csArrayObj, out circulInventSeqNo);

                    // �o�^������ɏI�������ꍇ
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        HandyInventoryDataWork inventoryData = new HandyInventoryDataWork();
                        inventoryData.CirculInventSeqNo = circulInventSeqNo;
                        retObj = (object)inventoryData;
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
                }
                else
                {
                    status = StatusError;
                }
               
            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(circulInventCondWork, ex.ToString(), 3);
                status = StatusError;
            }
            finally
            {
                // �������Ȃ�
            }

            return status;
        }
        # endregion

        # region [�z�I���Ɖ�]
        /// <summary>
        /// �z�I���Ɖ�擾����
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="retObj">�������ʃI�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �z�I���Ɖ�����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public int SearchCirculInvent(object condObj, out object retObj)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retObj = null;
            try
            {
                IHandyInventoryDataDB iHandyInventoryDataDB = (IHandyInventoryDataDB)MediationHandyInventoryDataDB.GetHandyInventoryDataDB();
                status = iHandyInventoryDataDB.SearchCirculInventData(condObj, out retObj);
            }
            catch
            {
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        # endregion
        # endregion

        # region [private Methods]
        /// <summary>
        /// �݌ɒ������׃f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="goodsUnitData">���i�A�����</param>
        /// <param name="inventoryDataWork">�p�����[�^</param>
        /// <param name="stock"> �݌ɏ��</param>
        /// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
        /// <returns>�f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ������׃f�[�^���[�N�N���X�����������s���B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private StockAdjustDtlWork CreateStockAdjustDtl(GoodsUnitData goodsUnitData, HandyInventoryCondWork inventoryDataWork, Stock stock, out long stockPriceTaxExc)
        {
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();
            // ��ƃR�[�h
            stockAdjustDtlWork.EnterpriseCode = goodsUnitData.EnterpriseCode;
            stockAdjustDtlWork.LogicalDeleteCode = 0;
            // ���_�R�[�h
            stockAdjustDtlWork.SectionCode = inventoryDataWork.BelongSectionCode;
            // ���_��
            stockAdjustDtlWork.SectionGuideNm = GetSectionName(stockAdjustDtlWork.SectionCode.Trim());
            // �݌ɒ����`�[�ԍ�
            stockAdjustDtlWork.StockAdjustSlipNo = 0;
            // �݌ɒ����s�ԍ�
            stockAdjustDtlWork.StockAdjustRowNo = 1;
            // �d���`��(��)(�[���Œ�)
            stockAdjustDtlWork.SupplierFormalSrc = 0;
            // �d�����גʔ�(��)(�[���Œ�)
            stockAdjustDtlWork.StockSlipDtlNumSrc = 0;
            // �󕥌��`�[�敪(50:�I��)
            stockAdjustDtlWork.AcPaySlipCd = 50;
            // �󕥌�����敪(40:�ߕs���X�V)
            stockAdjustDtlWork.AcPayTransCd = 40;
            // �������t
            // �O����������擾
            DateTime prevTotalDay = GetPrevTotalDay(inventoryDataWork.BelongSectionCode);
            if (DateTime.Now <= prevTotalDay)
            {
                // �I�����{�����Z�b�g
                stockAdjustDtlWork.AdjustDate = prevTotalDay.AddDays(1);
            }
            else
            {
                // �I�������Z�b�g
                stockAdjustDtlWork.AdjustDate = DateTime.Now;
            }
            // ���͓��t
            stockAdjustDtlWork.InputDay = DateTime.Now;
            // ���[�J�[�R�[�h
            stockAdjustDtlWork.GoodsMakerCd = inventoryDataWork.GoodsMakerCd;
            // ���[�J�[����
            stockAdjustDtlWork.MakerName = goodsUnitData.MakerName;
            // ���i�R�[�h
            stockAdjustDtlWork.GoodsNo = inventoryDataWork.GoodsNo;
            // ���i����
            stockAdjustDtlWork.GoodsName = goodsUnitData.GoodsName;
            // �d���P��
            stockAdjustDtlWork.StockUnitPriceFl = GetStockUnitPrice(goodsUnitData, inventoryDataWork.BelongSectionCode, inventoryDataWork.EnterpriseCode);
            // �ύX�O�d���P��
            stockAdjustDtlWork.BfStockUnitPriceFl = stockAdjustDtlWork.StockUnitPriceFl;
            // ������
            stockAdjustDtlWork.AdjustCount = inventoryDataWork.InventoryStockCnt - stock.ShipmentPosCnt;
            // ���ה��l
            stockAdjustDtlWork.DtlNote = string.Empty;
            // �q�ɃR�[�h
            stockAdjustDtlWork.WarehouseCode = inventoryDataWork.WarehouseCode;
            // �q�ɖ���
            stockAdjustDtlWork.WarehouseName = stock.WarehouseName;
            // BL�R�[�h
            stockAdjustDtlWork.BLGoodsCode = goodsUnitData.BLGoodsCode;
            // BL�R�[�h����
            stockAdjustDtlWork.BLGoodsFullName = goodsUnitData.BLGoodsFullName;
            // �q�ɒI��
            stockAdjustDtlWork.WarehouseShelfNo = stock.WarehouseShelfNo;
            // �d�����z
            long retMoney = 0;
            StockMngTtlSt stockMngTtlStWork = new StockMngTtlSt();
            FractionCalculate.FracCalcMoney(stockAdjustDtlWork.AdjustCount * stockAdjustDtlWork.StockUnitPriceFl, 1.00, stockMngTtlStWork.FractionProcCd, out retMoney);
            stockAdjustDtlWork.StockPriceTaxExc = retMoney;
            stockPriceTaxExc = stockAdjustDtlWork.StockPriceTaxExc;
            // �艿
            List<GoodsPrice> goodsPriceList = goodsUnitData.GoodsPriceList;
            stockAdjustDtlWork.ListPriceFl = GetListPriceFl2(stockAdjustDtlWork.AdjustDate, goodsPriceList);
            // �I�[�v�����i�敪
            foreach (GoodsPrice goodsPrice in goodsPriceList)
            {
                stockAdjustDtlWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
            }

             return stockAdjustDtlWork;

        }

        /// <summary>
        /// �݌ɒ����f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="data">�I���X�V�f�[�^���[�N�N���X</param>
        /// <param name="stockPriceTaxExc">�d�����z�i�Ŕ����j</param>
        /// <returns>�݌ɒ����f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɒ����f�[�^���[�N�N���X�𐶐����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private StockAdjustWork CreateStockAdjust(HandyInventoryCondWork data, long stockPriceTaxExc)
        {
            StockAdjustWork workData = new StockAdjustWork();

            // ��ƃR�[�h
            workData.EnterpriseCode = data.EnterpriseCode;
            // �_���폜�敪
            workData.LogicalDeleteCode = 0;
            // ���_�R�[�h
            workData.SectionCode = data.BelongSectionCode;
            // ���_��
            workData.SectionGuideNm = GetSectionName(workData.SectionCode.Trim());
            // �󕥌��`�[�敪(50�F�I��)
            workData.AcPaySlipCd = 50;
            // �󕥌�����敪(40�F�ߕs���X�V)
            workData.AcPayTransCd = 40;
            // �������t
            // �O����������擾
            DateTime prevTotalDay = GetPrevTotalDay(data.BelongSectionCode);
            if (DateTime.Now <= prevTotalDay)
            {
                // �I�����{�����Z�b�g
                workData.AdjustDate = prevTotalDay.AddDays(1);
            }
            else
            {
                // �I�������Z�b�g
                workData.AdjustDate = DateTime.Now;
            }
            // ���͓��t
            workData.InputDay = DateTime.Now; 
            // �d�����_�R�[�h
            workData.StockSectionCd = data.BelongSectionCode;
            // �d�����_����
            workData.StockSectionGuideNm = GetSectionName(data.BelongSectionCode.Trim());
            // �d�����͎҃R�[�h
            workData.StockInputCode = data.EmployeeCode;
            // �d�����͎Җ���
            workData.StockInputName = GetEmployeeName(data.EnterpriseCode, data.EmployeeCode.Trim());
            // �d���S���҃R�[�h
            workData.StockAgentCode = data.EmployeeCode;
            // �d���S���Җ���
            workData.StockAgentName = GetEmployeeName(data.EnterpriseCode, data.EmployeeCode.Trim());
            workData.SlipNote = string.Empty;
            // �d�����z���v
            workData.StockSubttlPrice = stockPriceTaxExc;
            return workData;
        }

        /// <summary>
        /// �݌Ƀf�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="stock">�݌ɏ��</param>
        /// <param name="inventoryDataWork">�p�����[�^</param>
        /// <returns>�݌Ƀf�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀf�[�^���[�N�N���X�𐶐����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private StockWork GetStockWork(Stock stock, HandyInventoryCondWork inventoryDataWork)
        {
            StockWork stockWork = new StockWork();

            stockWork.CreateDateTime = stock.CreateDateTime; // �쐬����
            stockWork.UpdateDateTime = stock.UpdateDateTime; // �X�V����
            stockWork.EnterpriseCode = inventoryDataWork.EnterpriseCode; // ��ƃR�[�h
            stockWork.FileHeaderGuid = stock.FileHeaderGuid; // GUID
            stockWork.UpdEmployeeCode = inventoryDataWork.EnterpriseCode; // �X�V�]�ƈ��R�[�h
            stockWork.UpdAssemblyId1 = stock.UpdAssemblyId1; // �X�V�A�Z���u��ID1
            stockWork.UpdAssemblyId2 = stock.UpdAssemblyId2; // �X�V�A�Z���u��ID2
            stockWork.LogicalDeleteCode = 0; // �_���폜�敪
            stockWork.SectionCode = stock.SectionCode.TrimEnd(); // ���_�R�[�h
            stockWork.WarehouseCode = inventoryDataWork.WarehouseCode.TrimEnd(); // �q�ɃR�[�h
            stockWork.GoodsMakerCd = inventoryDataWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            stockWork.GoodsNo = inventoryDataWork.GoodsNo.TrimEnd(); // ���i�ԍ�
            stockWork.StockUnitPriceFl = stock.StockUnitPriceFl; // �d���P���i�Ŕ�,�����j
            stockWork.SupplierStock = inventoryDataWork.InventoryStockCnt - stock.ShipmentPosCnt; // �d���݌ɐ�
            stockWork.AcpOdrCount = 0; // �󒍐�
            stockWork.MonthOrderCount = stock.MonthOrderCount; // M/O������
            stockWork.SalesOrderCount = 0; // ������
            stockWork.StockDiv = stock.StockDiv; // �݌ɋ敪
            stockWork.MovingSupliStock = 0; // �ړ����d���݌ɐ�
            stockWork.ShipmentPosCnt = stock.ShipmentPosCnt; // �o�׉\��
            stockWork.StockTotalPrice = stock.StockTotalPrice; // �݌ɕۗL���z
            stockWork.LastStockDate = stock.LastStockDate; // �ŏI�d���N����
            stockWork.LastSalesDate = stock.LastSalesDate; // �ŏI�����
            stockWork.LastInventoryUpdate = DateTime.Now; // �ŏI�I���X�V��
            stockWork.MinimumStockCnt = stock.MinimumStockCnt; // �Œ�݌ɐ�
            stockWork.MaximumStockCnt = stock.MaximumStockCnt; // �ō��݌ɐ�
            stockWork.NmlSalOdrCount = stock.NmlSalOdrCount; // �������
            stockWork.SalesOrderUnit = stock.SalesOrderUnit; // �����P��
            stockWork.StockSupplierCode = stock.StockSupplierCode; // �݌ɔ�����R�[�h
            stockWork.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen.TrimEnd(); // �n�C�t�������i�ԍ�
            stockWork.WarehouseShelfNo = inventoryDataWork.WarehouseShelfNo.TrimEnd(); // �q�ɒI��
            stockWork.DuplicationShelfNo1 = stock.DuplicationShelfNo1.TrimEnd(); // �d���I�ԂP
            stockWork.DuplicationShelfNo2 = stock.DuplicationShelfNo2.TrimEnd(); // �d���I�ԂQ
            stockWork.PartsManagementDivide1 = stock.PartsManagementDivide1.TrimEnd(); // ���i�Ǘ��敪�P
            stockWork.PartsManagementDivide2 = stock.PartsManagementDivide2.TrimEnd(); // ���i�Ǘ��敪�Q
            stockWork.StockNote1 = stock.StockNote1.TrimEnd(); // �݌ɔ��l�P
            stockWork.StockNote2 = stock.StockNote2.TrimEnd(); // �݌ɔ��l�Q
            stockWork.ShipmentCnt = 0; // �o�א��i���v��j
            stockWork.ArrivalCnt = 0; // ���א��i���v��j
            stockWork.StockCreateDate = stock.StockCreateDate; // �݌ɓo�^��
            stockWork.UpdateDate = DateTime.Now; // �X�V�N����

            return stockWork;
        }

        /// <summary>
        /// �z�I�������f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="inventoryDataWork">�p�����[�^</param>
        /// <returns>�z�I�������f�[�^�f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �z�I�������f�[�^�f�[�^���[�N�N���X�𐶐����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private CirculInventHisDataWork GetCirculInventHisData(HandyInventoryCondWork inventoryDataWork)
        {
            CirculInventHisDataWork dataWork = new CirculInventHisDataWork();
            dataWork.EnterpriseCode = inventoryDataWork.EnterpriseCode; // ��ƃR�[�h
            dataWork.UpdEmployeeCode = inventoryDataWork.EmployeeCode; // �X�V�]�ƈ��R�[�h
            dataWork.LogicalDeleteCode = 0; // �_���폜�敪
            dataWork.SectionCode = inventoryDataWork.BelongSectionCode.TrimEnd(); // ���_�R�[�h
            dataWork.CirculInventSeqNo = 0; // �z�I���ʔ�
            dataWork.WarehouseCode = inventoryDataWork.WarehouseCode; // �q�ɃR�[�h
            dataWork.Note = inventoryDataWork.Note.TrimEnd(); // ���l
            dataWork.EmployeeCode = inventoryDataWork.EmployeeCode; // �]�ƈ��R�[�h
            return dataWork;
        }

        /// <summary>
        /// �z�I�����𖾍׃f�[�^���[�N�N���X��������
        /// </summary>
        /// <param name="stock"> �݌ɏ��</param>
        /// <param name="inventoryDataWork">�p�����[�^</param>
        /// <returns>�z�I�����𖾍׃f�[�^�f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �z�I�����𖾍׃f�[�^�f�[�^���[�N�N���X�𐶐����܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private CirculInventHisDtlWork GetCirculInventHisDtl(Stock stock, HandyInventoryCondWork inventoryDataWork)
        {
            CirculInventHisDtlWork dtlWork = new CirculInventHisDtlWork();
            dtlWork.EnterpriseCode = inventoryDataWork.EnterpriseCode; // ��ƃR�[�h
            dtlWork.UpdEmployeeCode = inventoryDataWork.EmployeeCode; // �X�V�]�ƈ��R�[�h
            dtlWork.LogicalDeleteCode = 0; // �_���폜�敪
            dtlWork.SectionCode = inventoryDataWork.BelongSectionCode.TrimEnd(); // ���_�R�[�h
            dtlWork.CirculInventSeqNo = inventoryDataWork.CirculInventSeqNo; // �z�I���ʔ�
            dtlWork.WarehouseCode = inventoryDataWork.WarehouseCode.TrimEnd(); // �q�ɃR�[�h
            dtlWork.GoodsMakerCd = inventoryDataWork.GoodsMakerCd; // ���i���[�J�[�R�[�h
            dtlWork.GoodsNo = inventoryDataWork.GoodsNo.TrimEnd(); // ���i�ԍ�
            dtlWork.WarehouseShelfNo = inventoryDataWork.WarehouseShelfNo.TrimEnd(); // �q�ɒI��
            dtlWork.PresentStockCnt = stock.ShipmentPosCnt; // ���݌ɐ���
            dtlWork.InventoryStockCnt = inventoryDataWork.InventoryStockCnt; // �I���݌ɐ�
            dtlWork.InventoryDateTime = DateTime.Now; // �I�����{����
            return dtlWork;
        }

        #region �]�ƈ����̎擾
        /// <summary>
        /// �]�ƈ����̎擾����
        /// </summary>
        /// <param name="enterpriseCode"> ��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ�����</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����̂��擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public string GetEmployeeName(string enterpriseCode, string employeeCode)
        {
            string EmployeeName = string.Empty;
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            try
            {
                ArrayList retList;
                ArrayList retList2;
                EmployeeAcs employeeAcs = new EmployeeAcs();
                status = employeeAcs.Search(out retList, out retList2, enterpriseCode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (Employee employeeWork in retList)
                    {
                        if (employeeWork.LogicalDeleteCode == 0 && employeeWork.EmployeeCode.Trim().Equals(employeeCode.Trim().PadLeft(4, '0')))
                        {
                            EmployeeName = employeeWork.Name.Trim();
                        }
                    }
                }
            }
            catch
            {
                // �����Ȃ�
            }

            return EmployeeName;
        }
        #endregion

        #region ���_���̎擾����
        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note       : ���_���̂��擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";
            try
            {
                SecInfoAcs secInfoObj = new SecInfoAcs();

                foreach (SecInfoSet secInfoSet in secInfoObj.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode == 0 && secInfoSet.SectionCode.Trim().Equals(sectionCode.PadLeft(2, '0')))
                    {
                        sectionName = secInfoSet.SectionGuideNm.Trim();
                    }
                }
            }
            catch
            {
                // �Ȃ�
            }

            return sectionName;
        }
        #endregion

        /// <summary>
        /// �ŏI�����X�V���擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>�ŏI�����X�V��</returns>
        /// <remarks>
        /// <br>Note       : �ŏI�����X�V�����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private DateTime GetPrevTotalDay(string sectionCode)
        {
            DateTime prevTotalDay = new DateTime();

            int status = StatusError;
            try
            {
                // �����Z�o���W���[��
                TotalDayCalculator totalDayCalculatorObj = TotalDayCalculator.GetInstance();
                status = totalDayCalculatorObj.GetHisTotalDayMonthly(sectionCode, out prevTotalDay);
                if (prevTotalDay == DateTime.MinValue)
                {
                    status = totalDayCalculatorObj.GetHisTotalDayMonthly(string.Empty, out prevTotalDay);
                }

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    prevTotalDay = new DateTime();
                }
            }
            catch
            {
                prevTotalDay = new DateTime();
            }
            return prevTotalDay;
        }

        /// <summary>
        /// ���P���擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>���P��</returns>
        /// <remarks>
        /// <br>Note       : �݌Ƀ}�X�^�A���i�A���f�[�^��茴�P�����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private Double GetStockUnitPrice(GoodsUnitData goodsUnitData, string sectionCode, string enterpriseCode)
        {
            Double stockUnitPrice = 0;

            // ���i�A���f�[�^����P���Z�o���ʃI�u�W�F�N�g���擾
            UnitPriceCalcRet unitPriceCalcRet = GetUnitPriceCalcRet(goodsUnitData, sectionCode, enterpriseCode);

            // �P���Z�o���ʃI�u�W�F�N�g��茴�P���擾
            stockUnitPrice = unitPriceCalcRet.UnitPriceTaxExcFl;

            return stockUnitPrice;
        }

        /// <summary>
        /// �P���Z�o���ʃI�u�W�F�N�g�擾����
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�P���Z�o���ʃI�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : ���i�A���f�[�^���P���Z�o���ʃI�u�W�F�N�g���擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private UnitPriceCalcRet GetUnitPriceCalcRet(GoodsUnitData goodsUnitData, string sectionCode, string enterpriseCode)
        {
            // �P���Z�o�p�����[�^�ݒ�
            UnitPriceCalcParam unitPriceCalcParam = new UnitPriceCalcParam();
            unitPriceCalcParam.SectionCode = sectionCode;    // ���_�R�[�h
            unitPriceCalcParam.GoodsMakerCd = goodsUnitData.GoodsMakerCd;                               // ���i���[�J�[�R�[�h
            unitPriceCalcParam.GoodsNo = goodsUnitData.GoodsNo;                                         // ���i�ԍ�
            unitPriceCalcParam.GoodsRateRank = goodsUnitData.GoodsRateRank;                             // ���i�|�������N
            unitPriceCalcParam.GoodsRateGrpCode = goodsUnitData.GoodsRateGrpCode;                       // ���i�|���O���[�v�R�[�h
            unitPriceCalcParam.BLGroupCode = goodsUnitData.BLGroupCode;                                 // BL�O���[�v�R�[�h
            unitPriceCalcParam.BLGoodsCode = goodsUnitData.BLGoodsCode;                                 // BL���i�R�[�h
            unitPriceCalcParam.SupplierCd = goodsUnitData.SupplierCd;                                   // �d����R�[�h
            unitPriceCalcParam.PriceApplyDate = DateTime.Today;                                       // ���i�K�p��
            unitPriceCalcParam.CountFl = 1;                                                             // ����
            unitPriceCalcParam.TaxationDivCd = goodsUnitData.TaxationDivCd;                             // �ېŋ敪
            TaxRateSet taxRateSet = new TaxRateSet();
            TaxRateSetAcs taxRateSetAcs = new TaxRateSetAcs();
            // �ŗ��ݒ�}�X�^�擾(�ŗ��R�[�h=0�Œ�)
            taxRateSetAcs.Read(out taxRateSet, enterpriseCode, 0);
            unitPriceCalcParam.TaxRate = TaxRateSetAcs.GetTaxRate(taxRateSet, DateTime.Today);    // �ŗ�
            unitPriceCalcParam.StockCnsTaxFrcProcCd = goodsUnitData.StockCnsTaxFrcProcCd;               // �d������Œ[�������R�[�h
            unitPriceCalcParam.StockUnPrcFrcProcCd = goodsUnitData.StockUnPrcFrcProcCd;                 // �d���P���[�������R�[�h
            unitPriceCalcParam.TotalAmountDispWayCd = 0;                                                // ���z�\�����@�敪
            unitPriceCalcParam.TtlAmntDspRateDivCd = 1;                                                 // ���z�\���|���K�p�敪
            unitPriceCalcParam.ConsTaxLayMethod = taxRateSet.ConsTaxLayMethod;                    // ����œ]�ŕ���

            List<UnitPriceCalcRet> unitPriceCalcRetList;
            CompanyInf companyInf = null;                 // ���Џ��
            CompanyInfAcs companyInfAcs = new CompanyInfAcs();
            companyInfAcs.Read(out companyInf, enterpriseCode);
            UnitPriceCalculation unitPriceCalculation = new UnitPriceCalculation();
            // ���Аݒ�|���D�揇�ʋ敪(���P���Z�o�p)
            if (companyInf != null)
            {
                unitPriceCalculation.RatePriorityDiv = companyInf.RatePriorityDiv;
            }
            unitPriceCalculation.CalculateUnitCost(unitPriceCalcParam, goodsUnitData, out unitPriceCalcRetList);

            foreach (UnitPriceCalcRet unitPriceCalcRetWk in unitPriceCalcRetList)
            {
                if (unitPriceCalcRetWk.UnitPriceKind == UnitPriceCalculation.ctUnitPriceKind_UnitCost)
                {
                    return unitPriceCalcRetWk;
                }
            }

            return new UnitPriceCalcRet();
        }

        /// <summary>
        /// ���i���i�擾����
        /// </summary>
        /// <param name="targetDate">�������t</param>
        /// <param name="goodsPriceList">���i���i���X�g</param>
        /// <returns>���i���i</returns>
        /// <remarks>
        /// <br>Note       : ���i���i���擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private double GetListPriceFl2(DateTime targetDate, List<GoodsPrice> goodsPriceList)
        {
            double listPriceFl = 0;

            GoodsAcs goodsAcs = new GoodsAcs();
            GoodsPrice retGoodsPrice = goodsAcs.GetGoodsPriceFromGoodsPriceList(targetDate, goodsPriceList);
            if (retGoodsPrice != null)
            {
                listPriceFl = retGoodsPrice.ListPrice;
            }

            return listPriceFl;
        }

        /// <summary>
        /// �G���[���O�o�͏���
        /// </summary>
        /// <param name="inventoryCondWork">���������I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <param name="mode">1:�q�ɑ��݊m�F�A2:�݌ɏ��擾�A3�F�I�����o�^</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �G���[���O�����o�͂��܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date       : 2017/08/16</br>
        /// </remarks>
        private void WriteLog(HandyInventoryCondWork inventoryCondWork, string errMsg, int mode)
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
                if (inventoryCondWork != null)
                {
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCode + inventoryCondWork.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + inventoryCondWork.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + inventoryCondWork.MachineName);
                    // �q�ɃR�[�h
                    writer.WriteLine(WarehouseCode + inventoryCondWork.WarehouseCode);
                    if (mode == 2)
                    {
                        // �����敪
                        writer.WriteLine(ProcDiv + inventoryCondWork.ProcDiv);
                        // ���i�o�[�R�[�h
                        writer.WriteLine(GoodsBarCode + inventoryCondWork.GoodsBarCode);
                    }
                    if (mode == 3)
                    {
                        // �z�I���ʔ�
                        writer.WriteLine(InventorySeqNo + inventoryCondWork.CirculInventSeqNo);
                        // �I����
                        writer.WriteLine(InventoryStockCnt + inventoryCondWork.InventoryStockCnt);
                        // ���i���[�J�[�R�[�h
                        writer.WriteLine(GoodsMakerCd + inventoryCondWork.GoodsMakerCd);
                        // ���i�ԍ�
                        writer.WriteLine(GoodsNo + inventoryCondWork.GoodsNo);
                        // �I��
                        writer.WriteLine(WarehouseShelfNo + inventoryCondWork.WarehouseShelfNo);
                        // ���l
                        writer.WriteLine(Note + inventoryCondWork.Note.TrimEnd());
                        // ����t���O
                        writer.WriteLine(FirstFlg + inventoryCondWork.FirstFlg);
                    }
                }
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }
        #endregion
    }
}
