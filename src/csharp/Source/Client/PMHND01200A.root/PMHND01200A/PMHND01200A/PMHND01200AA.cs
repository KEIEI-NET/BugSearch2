//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���݌Ɏd���A�N�Z�X�N���X
// �v���O�����T�v   : �n���f�B�^�[�~�i���݌Ɏd���A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : ���O
// �� �� ��  2017/08/02  �C�����e : �V�K�쐬
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
using Broadleaf.Application.UIData;
using System.Collections.Generic;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �n���f�B�^�[�~�i���݌Ɏd���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �n���f�B�^�[�~�i���݌Ɏd���A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/08/02</br>
    /// </remarks>
    public class HandyStockAcs
    {
        #region [�萔]
        //// <summary>����������ɏI�������ꍇ�̃X�e�[�^�X</summary>
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
        /// <summary>�f�t�H���g���O�t�@�C����</summary>
        private const string DefaultNamePgid = "PMHND01200A_";
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
        private const string OpDiv = "�����敪:";
        /// <summary>�q�ɃR�[�h</summary>
        private const string WarehouseCode = "�q�ɃR�[�h:";
        /// <summary>���i���[�J�[�R�[�h</summary>
        private const string GoodsMakerCd = "���i���[�J�[�R�[�h:";
        /// <summary>���i�ԍ�</summary>
        private const string GoodsNo = "���i�ԍ�:";
        /// <summary>���i�o�[�R�[�h</summary>
        private const string CustomerGoodsCode = "���i�o�[�R�[�h:";
        /// <summary>�q�ɒI��</summary>
        private const string WarehouseShelfNo = "�I��:";
        /// <summary>���i�X�e�[�^�X</summary>
        private const string InspectStatus = "���i�X�e�[�^�X:";
        /// <summary>���i�敪</summary>
        private const string InspectCode = "���i�敪:";
        /// <summary>���i��</summary>
        private const string InspectCnt = "���i��:";
        /// <summary>�p�����[�^null���b�Z�[�W</summary>
        private const string ErrorMsgNull = "����������null�ł��B";
        /// <summary>�p�����[�^�G���[���b�Z�[�W</summary>
        private const string ErrorMsgParam = "���̓p�����[�^�G���[���������܂����B";
        /// <summary>���i�Ǘ����̎擾�G���[���b�Z�[�W</summary>
        private const string GoodsDataErrorMsg = "���i�Ǘ����̎擾�����s���܂����B";
        #endregion

        #region �� Private Member
        /// <summary>�d����}�X�^���[�J���L���b�V��</summary>
        private Dictionary<string, Supplier> SupplierDic = new Dictionary<string, Supplier>();
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
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public HandyStockAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// �n���f�B�^�[�~�i���݌Ɏd��_�݌ɏ��擾����
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="retObj">�������ʃI�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���݌Ɏd���̍݌ɏ��擾�������s���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchStock(object condObj, out object retObj)
        {
            retObj = null;
            int status = StatusError;
            // --- DEL 2019/11/13 ---------->>>>>
            //HandyStockWork retWork = null;
            // --- DEL 2019/11/13 ---------->>>>>
            // --- ADD 2019/11/13 ---------->>>>>
            ArrayList retWorkArray = null;
            // --- ADD 2019/11/13 ----------<<<<<

            // ��������
            HandyStockCondWork stockCondWork = condObj as HandyStockCondWork;

            // �p�����[�^��null�̏ꍇ�A
            if (stockCondWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(stockCondWork, ErrorMsgNull);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // �����敪���u13�v�A�u14�v�ȊO�̏ꍇ�̓G���[�Ƃ��܂��B
                // ��ƃR�[�h�A�]�ƈ��R�[�h�A�R���s���[�^���A�q�ɃR�[�h�A���i�o�[�R�[�h�͋�l�̏ꍇ�A�G���[�Ƃ��܂��B
                // --- MOD 2019/11/13 ---------->>>>>
                //if ((stockCondWork.OpDiv != 13 && stockCondWork.OpDiv !=14)
                //    || string.IsNullOrEmpty(stockCondWork.EnterpriseCode)
                //    || string.IsNullOrEmpty(stockCondWork.EmployeeCode.Trim())
                //    || string.IsNullOrEmpty(stockCondWork.MachineName.Trim())
                //    || string.IsNullOrEmpty(stockCondWork.WarehouseCode)
                //    || string.IsNullOrEmpty(stockCondWork.CustomerGoodsCode))
                //{
                //    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                //    this.WriteLog(stockCondWork, ErrorMsgParam);
                //    return status;
                //}
                // 2019/11�@��ƃR�[�h�A�]�ƈ��R�[�h�A�R���s���[�^���A�q�ɃR�[�h�A���i�o�[�R�[�h�{���i�ԍ��͋�l�̏ꍇ�A�G���[�Ƃ��܂��B
                if ((stockCondWork.OpDiv != 13 && stockCondWork.OpDiv != 14)
                    || string.IsNullOrEmpty(stockCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(stockCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(stockCondWork.MachineName.Trim())
                    || string.IsNullOrEmpty(stockCondWork.WarehouseCode)
                    || (string.IsNullOrEmpty(stockCondWork.CustomerGoodsCode) && string.IsNullOrEmpty(stockCondWork.GoodsNo)))
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(stockCondWork, ErrorMsgParam);
                    return status;
                }
                // --- MOD 2019/11/13 ----------<<<<<
            }

            try
            {
                #region �݌ɏ��擾
                byte[] condByte = XmlByteSerializer.Serialize(stockCondWork);
                // --- MOD 2019/11/13 ---------->>>>>
                //byte[] retByte = null;
                object retByte = null;
                // --- MOD 2019/11/13 ----------<<<<<
                // �݌Ɂi�d���E�ړ��j�����[�e�B���O�I�u�W�F�N�g
                IHandyStockMoveDB iStockMoveDBObj = (IHandyStockMoveDB)MediationHandyStockMoveDB.GetHandyStockMoveDB();
                // �݌ɏ��擾���s���܂��B
                // MOD 2019/11/13 ---------->>>>>
                //status = iStockMoveDBObj.SearchStock(condByte, out retByte);
                status = iStockMoveDBObj.SearchStockHandy(condByte, out retByte);
                // MOD 2019/11/13 ----------<<<<<

                // ���擾������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �ԋp�p�����[�^�Z�b�g
                    // --- MOD 2019/11/13 ---------->>>>>
                    //retObj = XmlByteSerializer.Deserialize(retByte, typeof(HandyStockWork));
                    //retWork = retObj as HandyStockWork;
                    retObj = retByte;
                    retWorkArray = retObj as ArrayList;
                    // --- MOD 2019/11/13 ----------<<<<<
                    // --- ADD 2019/11/13 ---------->>>>>
                    ArrayList retArray = new ArrayList();
                    foreach (HandyStockWork retWork in retWorkArray)
                    {
                        // --- ADD 2019/11/13 ----------<<<<<
                        GoodsUnitData goodsUnitData = null;
                        // ���i�Ǘ������擾���܂��B�i�d����擾�p�j
                        this.GetGoodsMngInfo(ref goodsUnitData, retWork, stockCondWork);
                        int SupplierCd = 0;
                        if (goodsUnitData != null)
                        {
                            CacheSupplierData(stockCondWork.EnterpriseCode);
                            SupplierCd = goodsUnitData.SupplierCd;
                            // �d����}�X�^����d���於�̂��擾
                            if (SupplierDic.ContainsKey(SupplierCd.ToString("d06")))
                            {
                                // �d����}�X�^�ɑ���
                                Supplier Supplier = SupplierDic[SupplierCd.ToString("d06")];
                                // �d���於�̂�ݒ�
                                retWork.SupplierNm = Supplier.SupplierSnm;
                            }
                        }
                        else
                        {
                            // �G���[���O�o�͂��܂��B
                            this.WriteLog(stockCondWork, GoodsDataErrorMsg);
                        }
                        // �݌ɔ�����R�[�h�̃`�F�b�N
                        int StockSupplierCd = 0;
                        if (retWork.StockSupplierCode != 0)
                        {
                            StockSupplierCd = retWork.StockSupplierCode;
                        }
                        else
                        {
                            // �݌ɔ�����R�[�h�����ݒ�̏ꍇ�A�d����R�[�h�𔭒���R�[�h�Ƃ���B
                            StockSupplierCd = SupplierCd;
                        }
                        // UOE������}�X�^�����擾���܂��B�i�����於�̎擾�p�j
                        if (StockSupplierCd != 0)
                        {
                            retWork.StockSupplierCode = StockSupplierCd;
                            UOESupplierAcs uOESupplierAcs = new UOESupplierAcs();
                            UOESupplier UoeSupplier;
                            uOESupplierAcs.Read(out UoeSupplier, stockCondWork.EnterpriseCode, StockSupplierCd, retWork.SectionCode);
                            if (UoeSupplier != null)
                            {
                                // UOE������}�X�^�ɑ��݂����ꍇ��UOE�����於�̂𔭒��於�̂Ƃ���B
                                retWork.UOESupplierName = UoeSupplier.UOESupplierName;

                            }
                            else
                            {
                                // UOE������}�X�^�ɑ��݂��Ȃ��ꍇ�͎d���於�̂𔭒��於�̂Ƃ���B
                                retWork.UOESupplierName = retWork.SupplierNm;
                            }
                        }

                        // --- ADD 2019/11/13 ---------->>>>>
                        retArray.Add(retWork);
                    }
                    // --- ADD 2019/11/13 ----------<<<<<


                    // --- MOD 2019/11/13 ---------->>>>>
                    //retObj = retWork;
                    retObj = retArray;
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
                this.WriteLog(stockCondWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // �����Ȃ��B
            }

            return status;
        }

        # region [���i�f�[�^�o�^]
        /// <summary>
        /// �݌Ɏd��_���i�f�[�^�o�^(��s���i)����
        /// </summary>
        /// <param name="inspectDataObj">�o�^�f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �݌Ɏd���i�o�ׁE���ׁj�̌��i�f�[�^(��s���i)��o�^���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int WriteHandyInspect(object inspectDataObj)
        {
            int status = StatusError;
            HandyInspectDataWork inspectDataWork = inspectDataObj as HandyInspectDataWork;
            ArrayList inspectDataWorkList = new ArrayList();
            // �p�����[�^��null�̏ꍇ�A
            if (inspectDataWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ErrorMsgNull);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // �K�{���͍��ڂ̃`�F�b�N
                if (String.IsNullOrEmpty(inspectDataWork.MachineName.Trim()) ||            // �R���s���[�^��
                    String.IsNullOrEmpty(inspectDataWork.EmployeeCode.Trim()) ||           // �]�ƈ��R�[�h
                    String.IsNullOrEmpty(inspectDataWork.WarehouseCode.Trim()) ||           // �q�ɃR�[�h
                    (inspectDataWork.GoodsMakerCd <= 0) ||           // ���[�J�[�R�[�h
                    String.IsNullOrEmpty(inspectDataWork.GoodsNo.Trim()))                  // ���i�ԍ�
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inspectDataWork, ErrorMsgParam);
                    return status;
                }

                // ���̃`�F�b�N
                if (inspectDataWork.GoodsMakerCd > 999999 ||
                    inspectDataWork.GoodsNo.Length > 40 ||
                    inspectDataWork.WarehouseCode.Length > 6 ||
                    inspectDataWork.InspectCode > 99 ||
                    inspectDataWork.InspectStatus > 99 ||
                    inspectDataWork.InspectCnt > 99999999.99 ||
                    inspectDataWork.MachineName.Length > 20 ||
                    inspectDataWork.EmployeeCode.Length > 9)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inspectDataWork, ErrorMsgParam);
                    return status;
                }
                if (inspectDataWork.ProcDiv != 13 && inspectDataWork.ProcDiv != 14)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inspectDataWork, ErrorMsgParam);
                    return status;
                }
                // �󕥌��`�[�ԍ�(�����[�g�ɂč̔�)
                inspectDataWork.AcPaySlipNum = string.Empty;
                // �󕥌��`�[�敪(10:�d��)
                inspectDataWork.AcPaySlipCd = 10;

                // �󕥌��s�ԍ�(0�Œ�)
                inspectDataWork.AcPaySlipRowNo = 0;


                if (inspectDataWork.ProcDiv == 13)
                {
                    // �󕥌�����敪(10�F�ʏ�)
                    inspectDataWork.AcPayTransCd = 10;
                }
                else
                {
                    // �󕥌�����敪(11�F�ԕi)
                    inspectDataWork.AcPayTransCd = 11;
                }

                // �n���f�B�^�[�~�i���敪:�Œ�l(1:�n���f�B�^�[�~�i��)
                inspectDataWork.HandTerminalCode = 1;
                inspectDataWorkList.Add(inspectDataWork);
            }
            try
            {
                inspectDataObj = inspectDataWorkList as object;
                // �݌Ɂi�d���E�ړ��j�����[�e�B���O�I�u�W�F�N�g
                IHandyStockMoveDB iHandyStockMoveDBObj = (IHandyStockMoveDB)MediationHandyStockMoveDB.GetHandyStockMoveDB();
                // ���i�f�[�^(��s���i)��o�^���܂��B
                status = iHandyStockMoveDBObj.Write(ref inspectDataObj, 1);

                // �o�^������ɏI�������ꍇ
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
            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(inspectDataWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // �������Ȃ�
            }

            return status;
        }
        # endregion
        # endregion

        #region ���i�A�N�Z�X�N���X(���i�Ǘ����擾)
        /// <summary>
        /// ���i�A�N�Z�X�N���X(���i�Ǘ����擾)
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^�N���X</param>
        /// <param name="resultWork">���o���ʃf�[�^�N���X</param>
        /// <param name="stockCondWork">��������</param>
        /// <remarks>
        /// <br>Note       : ���i�Ǘ������擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        private void GetGoodsMngInfo(ref GoodsUnitData goodsUnitData, HandyStockWork resultWork, HandyStockCondWork stockCondWork)
        {
            goodsUnitData = new GoodsUnitData();
            //���i�A�N�Z�X�N���X�̏�����
            string message = "";
            GoodsAcs goodsObj = new GoodsAcs();
            goodsObj.IsGetSupplier = true;
            goodsObj.SearchInitial(stockCondWork.EnterpriseCode, stockCondWork.SectionCode.TrimEnd(), out message);

            // ���o�����ݒ�
            goodsUnitData.SectionCode = resultWork.SectionCode;            // ���_�R�[�h
            goodsUnitData.GoodsMakerCd = resultWork.GoodsMakerCd;          // ���[�J�[�R�[�h
            goodsUnitData.GoodsNo = resultWork.GoodsNo;                    // �i��
            goodsUnitData.BLGoodsCode = resultWork.BLGoodsCode;            // BL�R�[�h

            //BL�R�[�h�}�X�^�擾(BL�O���[�v�R�[�h�擾�p)
            BLGoodsCdUMnt goodsCdUMnt;
            goodsObj.GetBLGoodsCd(resultWork.BLGoodsCode, out goodsCdUMnt);

            //BL�O���[�v�R�[�h�}�X�^�擾(���i�����ރR�[�h�擾�p)
            BLGroupU bLGroupU = null;
            if (goodsCdUMnt != null)
            {
                goodsObj.GetBLGroup(goodsUnitData.EnterpriseCode, goodsCdUMnt.BLGloupCode, out bLGroupU);
            }

            //�����ރZ�b�g
            if (bLGroupU != null)
            {
                goodsUnitData.GoodsMGroup = bLGroupU.GoodsMGroup;
            }

            // ���i�Ǘ����̎擾
            goodsObj.GetGoodsMngInfo(ref goodsUnitData);
        }
        #endregion

        #region �d����}�X�^�̃��[�J���L���b�V��
        /// <summary>
        /// �d����}�X�^�̃��[�J���L���b�V��
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <remarks>
        /// <br>Note       : �d����}�X�^�̃��[�J���L���b�V�����쐬���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        private void CacheSupplierData(string enterpriseCode)
        {
            int status = StatusError;
            ArrayList retList = new ArrayList();
            SupplierAcs supplierAcs = new SupplierAcs();

            // �d����}�X�^�̃��[�J���L���b�V�����N���A
            SupplierDic = new Dictionary<string, Supplier>();

            // �d����}�X�^�̎擾
            status = supplierAcs.SearchAll(out retList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                foreach (Supplier supplierWork in retList)
                {
                    if (supplierWork.LogicalDeleteCode == 0)
                    {
                        string key = supplierWork.SupplierCd.ToString("d06");
                        if (SupplierDic.ContainsKey(key))
                        {
                            // ���ɃL���b�V���ɑ��݂��Ă���ꍇ�͍폜
                            SupplierDic.Remove(key);
                        }
                        SupplierDic.Add(key, supplierWork);
                    }
                }
            }
        }
        #endregion

        # region [private Methods]
        /// <summary>
        /// �G���[���O�o�͏���
        /// </summary>
        /// <param name="logObj">���������I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �G���[���O�����o�͂��܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date       : 2017/08/02</br>
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
                if (logObj is HandyStockCondWork)
                {
                    HandyStockCondWork handyStockCondWork = logObj as HandyStockCondWork;
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
                    // ���i�o�[�R�[�h
                    writer.WriteLine(CustomerGoodsCode + handyStockCondWork.CustomerGoodsCode);
                    // �q�ɒI��
                    writer.WriteLine(WarehouseShelfNo + handyStockCondWork.WarehouseShelfNo);
                }
                // �p�����[�^��null�ł͂Ȃ��ꍇ�A�G���[���b�Z�[�W�Ɉ����̖��O�ƒl���o�͂��܂��B
                else if (logObj is HandyInspectDataWork)
                {
                    HandyInspectDataWork handyInspectDataWork = logObj as HandyInspectDataWork;
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCode + handyInspectDataWork.EnterpriseCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + handyInspectDataWork.MachineName);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + handyInspectDataWork.EmployeeCode);
                    // ���i���[�J�[�R�[�h
                    writer.WriteLine(GoodsMakerCd + handyInspectDataWork.GoodsMakerCd);
                    // ���i�ԍ�
                    writer.WriteLine(GoodsNo + handyInspectDataWork.GoodsNo);
                    // �q�ɃR�[�h
                    writer.WriteLine(WarehouseCode + handyInspectDataWork.WarehouseCode);
                    // ���i�X�e�[�^�X
                    writer.WriteLine(InspectStatus + handyInspectDataWork.InspectStatus);
                    // ���i�敪
                    writer.WriteLine(InspectCode + handyInspectDataWork.InspectCode);
                    // ���i��
                    writer.WriteLine(InspectCnt + handyInspectDataWork.InspectCnt);
                    // �����敪
                    writer.WriteLine(OpDiv + handyInspectDataWork.ProcDiv);
                }
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }
        #endregion
    }
}
