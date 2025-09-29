//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���[�J�[�i�ԃp�^�[�����䕔�i
// �v���O�����T�v   : ���[�J�[�i�ԃp�^�[�����䕔�i �A�N�Z�X�N���X
//----------------------------------------------------------------------------//
//                (c)Copyright  2020 Broadleaf Co.,Ltd.
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570249-00  �쐬�S�� : 杍^
// �� �� ��  2020/03/09   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11601223-00   �쐬�S�� : ������
// �� �� ��  2021/06/21    �C�����e : PMKOBETSU-3268�̑Ή�
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Net.NetworkInformation;
using Microsoft.Win32;

using Broadleaf.Application.Common;
using Broadleaf.Library.Resources;
using System.IO;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Reflection;
using Broadleaf.Application.UIData;


namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���[�J�[�i�ԃp�^�[�����䕔�i�A�N�Z�X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[�J�[�i�ԃp�^�[�����䕔�i�A�N�Z�X</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2020/03/09</br>
    /// <br>Update Note: 2021/06/21 ������</br>
    /// <br>�Ǘ��ԍ�   : 11601223-00</br>
    /// <br>           : PMKOBETSU-3268�̑Ή�</br> 
    /// </remarks>
    public class HandyMakerGoodsContrAcs
    {
        # region �� Constructor ��
        /// <summary>
        /// ���[�J�[�i�ԃp�^�[�����䕔�i�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br> Note      : ���[�J�[�i�ԃp�^�[�����䕔�i�A�N�Z�X�N���X�R���X�g���N�^</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public HandyMakerGoodsContrAcs()
        {
            LogLockObj = new object();
        }
        # endregion �� Constructor ��

        # region �� Const Members ��
        // ���擾������ɏI�������X�e�[�^�X
        private const int StatusNomal = 0;
        /// <summary>��񂪌�����Ȃ��ꍇ�̃X�e�[�^�X</summary>
        private const int StatusNotFound = 4;
        /// <summary>�^�C���A�E�g���������ꍇ�̃X�e�[�^�X</summary>
        private const int StatusTimeout = 5;
        /// <summary>DB�������ŃG���[�����������ꍇ�̃X�e�[�^�X</summary>
        private const int StatusError = -1;
        /// <summary>�p�����[�^null���b�Z�[�W</summary>
        private const string ErrorMsgNull = "����������null�ł��B";
        /// <summary>�p�����[�^�G���[���b�Z�[�W</summary>
        private const string ErrorMsgParam = "���̓p�����[�^�G���[���������܂����B";
        /// <summary>�p�����[�^�G���[���b�Z�[�W</summary>
        private const string ErrorMsgGoodsBarCodeRevn = "���̓p�[�R�[�h�̃o�[�R�[�h�֘A�}�X�^���������f�[�^��߂�܂����B";
        /// <summary>�p�����[�^�G���[���b�Z�[�W</summary>
        private const string ErrorWarehouseAcquisitionFailure = "�q�ɏ��̎擾�Ɏ��s���܂����B";
        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>���O�p�X</summary>
        private const string PathLog = "Log\\PMHND";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNamePgid = "PMHND01230B_";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNameFile = ".log";
        /// <summary>�f�t�H���g���O�t�@�C�����̓����t�H�[�}�b�g</summary>
        private const string DefaultNameTime = "yyyyMMdd";
        /// <summary>�f�t�H���g���O���e�t�H�[�}�b�g</summary>
        private const string DefaultLogFormat = "{0,-19} {1,-5} {2,-200}";     // yyyy/MM/dd hh:mm:ss
        /// <summary>�B�������^�u</summary>
        private const string AmStr = "*";
        /// <summary>�R���s���[�^�[��</summary>
        private const string EmployeeCode = "�R���s���[�^�[��:";
        /// <summary>�]�ƈ��R�[�h</summary>
        private const string MachineName = "�]�ƈ��R�[�h:";
        /// <summary>��ƃR�[�h</summary>
        private const string EnterpriseCode = "��ƃR�[�h:";
        /// <summary>���[�J�[�R�[�h</summary>
        private const string GoodsMakerCd = "���[�J�[�R�[�h:";
        /// <summary>�o�[�R�[�h���</summary>
        private const string BarCodeData = "�o�[�R�[�h�f�[�^:";
        /// <summary>���i�ԍ�</summary>
        private const string GoodsNo = "���i�ԍ�:";
        /// <summary>�q�ɃR�[�h</summary>
        private const string WarehouseCode = "�q�ɃR�[�h:";
        /// <summary>�q�ɒI��</summary>
        private const string WarehouseShelfNo = "�q�ɒI��:";
        /// <summary>�d����</summary>
        private const string SupplierCd = "�d����:";
        /// <summary>���ɐ�</summary>
        private const string StockCount = "���ɐ�:";
        /// <summary>���i����</summary>
        private const string GoodsKindCode = "���i����:";
        /// <summary>�ېŋ敪</summary>
        private const string TaxationDivCd = "�ېŋ敪:";
        /// <summary>�݌ɋ敪</summary>
        private const string StockDiv = "�݌ɋ敪:";
        /// <summary>�p�^�[����������ʔ�</summary>
        private const string MakerGoodsSerchHisNo = "�p�^�[����������ʔ�:";

        // ===================================================================================== //
        // Static �ϐ�
        // ===================================================================================== //
        #region Static Members
        /// <summary>���O�p���b�N</summary>
        static object LogLockObj = null;
        # endregion

        # endregion �� Const Members ��

        #region �� �p�^�[������
        /// <summary>
        /// �p�^�[������
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="retObj">�������ʃI�u�W�F�N�g</param>
        /// <param name="makerGoodsSerchHisNoObj">��������ʔ�</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �p�^�[���������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyStockPaturn(object condObj, out object retObj, out object makerGoodsSerchHisNoObj)
        {
            int status = StatusError;
            retObj = null;
            makerGoodsSerchHisNoObj = null;
            int makerGoodsSerchHisNo = 0;
            int makerGoodsPtrnNo = 0;
            string goodsNo = string.Empty;
            HandyMakerGoodsPtrnAcs handyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
            // ��������
            HandyGoodsSearchCondWork condWork = condObj as HandyGoodsSearchCondWork;

            #region �p�����[�^�`�F�b�N
            // �p�����[�^��null�̏ꍇ�A
            if (condWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ErrorMsgNull);
                return status;
            }
            else
            {
                //���[�J�[�w��Ȃ��ŌĂ΂ꂽ�ꍇ�́A�i�Ԍ������Ăяo��
                if (condWork.GoodsMakerCd == 0)
                {
                    return this.SearchHandyStockGoodsNo(condObj, out retObj, out makerGoodsSerchHisNoObj);

                }

                // �p�����[�^�`�F�b�N
                // ���̓p�����[�^�u��ƃR�[�h�A�R���s���[�^�[���A�]�ƈ��R�[�h�A���[�J�[�R�[�h�A�p�[�R�[�h���v�͋󂪂���ꍇ�A�G���[��߂�܂��B
                if (string.IsNullOrEmpty(condWork.EnterpriseCode.Trim())
                    || string.IsNullOrEmpty(condWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(condWork.MachineName.Trim())
                    || condWork.GoodsMakerCd == 0
                    || string.IsNullOrEmpty(condWork.BarCodeData.Trim()))
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(condWork, ErrorMsgParam);
                    return status;
                }
            }
            #endregion

            try
            {
                #region ���i�o�[�R�[�h�֘A�t���}�X�^����
                // ���i�o�[�R�[�h�֘A�t���}�X�^����
                Object resultObj;
                ArrayList handyGoodsBarCodeRevnResultWork = new ArrayList();
                status = handyMakerGoodsPtrnAcs.SearchGoodsBarCodeRevn(condWork.EnterpriseCode, condWork.BarCodeData, 0, out resultObj);
                #endregion

                // �o�[�R�[�h�֘A�}�X�^��񂠂�ꍇ�˕i�Ԍ���
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ���i�o�[�R�[�h�֘A�}�X�^�̒��o���ʂ�1���ڂ��g�p
                    ArrayList goodsBarCodeRevnDataList = resultObj as ArrayList;

                    ArrayList resultList = new ArrayList();

                    foreach (object goods in goodsBarCodeRevnDataList)
                    {

                        GoodsBarCodeRevnWork work = (GoodsBarCodeRevnWork)goods;
                        goodsNo = work.GoodsNo;

                        object resultWk = null;

                        // �i�Ԍ���
                        status = SearchGoodsNo(condObj, work.GoodsMakerCd, goodsNo, 0, out resultWk);
                        if (status == StatusNomal)
                        {
                            foreach (HandyStockInsGoodsInfo info in (ArrayList)resultWk)
                            {
                                resultList.Add(info);
                            }
                        }
                        else if (status != StatusNotFound)
                        {
                            return status;
                        }

                    }

                    if (resultList.Count <= 0)
                    {
                        return StatusNotFound;
                    }

                    retObj = resultList;

                    // ���[�J�[�i�ԃp�^�[�����������̓o�^
                    status = WriteHisByInsert(condWork, 0, 0, string.Empty, 1, out makerGoodsSerchHisNo);
                    makerGoodsSerchHisNoObj = (object)makerGoodsSerchHisNo;

                }
                // �o�[�R�[�h�֘A�}�X�^��񂪂Ȃ��ꍇ�˃��[�J�[�i�ԃp�^�[���}�X�^������
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    #region ���[�J�[�i�ԃp�^�[���}�X�^����
                    // ���[�J�[�i�ԃp�^�[���}�X�^����
                    ArrayList retList = null;
                    ArrayList goodsNoList = new ArrayList();
                    status = handyMakerGoodsPtrnAcs.ReadByMakerAndBarCodeLength(out retList, condWork.EnterpriseCode, condWork.GoodsMakerCd, condWork.BarCodeData.Length, string.Empty, 1);
                    #endregion

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL || status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        #region ���[�J�[�i�ԃp�^�[���}�X�^��������
                        if (retList.Count == 0)
                        {
                            // �o�[�R�[�h����i�ԂƂ���
                            goodsNo = condWork.BarCodeData;

                            // �i�Ԍ����i�B�������j
                            status = SearchGoodsNo(condObj, condWork.GoodsMakerCd, goodsNo, 1, out retObj);

                            if (status != StatusNomal)
                            {
                                return status;
                            }

                            // ���[�J�[�i�ԃp�^�[�����������̓o�^
                            status = WriteHisByInsert(condWork, makerGoodsPtrnNo, condWork.GoodsMakerCd, goodsNo, 0, out makerGoodsSerchHisNo);
                            makerGoodsSerchHisNoObj = (object)makerGoodsSerchHisNo;
                        }
                        #endregion

                        #region ���[�J�[�i�ԃp�^�[���}�X�^��������
                        else
                        {
                            //�����i�Ԃ��i�Ԍ����E����o�^���s��
                            foreach (HandyMakerGoodsPtrnWork work in retList)
                            {
                                // ���[�J�[�i�ԃp�^�[��No.
                                makerGoodsPtrnNo = work.MakerGoodsPtrnNo;
                                // �i�Ԓ��o
                                goodsNo = GetGoodsNo(condWork.BarCodeData, work);

                                // �i�Ԍ����i�B�������j
                                status = SearchGoodsNo(condObj, condWork.GoodsMakerCd, goodsNo, 1, out retObj);

                                if (status != StatusNomal)
                                {
                                    continue;
                                }

                                // ���[�J�[�i�ԃp�^�[�����������̓o�^
                                status = WriteHisByInsert(condWork, makerGoodsPtrnNo, condWork.GoodsMakerCd, goodsNo, 0, out makerGoodsSerchHisNo);
                                makerGoodsSerchHisNoObj = (object)makerGoodsSerchHisNo;
                                if (status == StatusNomal)
                                {
                                    break;
                                }

                            }

                        }
                        #endregion
                    }
                    // �Ǎ����̃^�C���A�E�g�ꍇ
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        return StatusTimeout;
                    }
                    // DB�������ŃG���[�����������ꍇ
                    else
                    {
                        return StatusError;
                    }
                }
                // �Ǎ����̃^�C���A�E�g�ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    return StatusTimeout;
                }
                // DB�������ŃG���[�����������ꍇ
                else
                {
                    return StatusError;
                } 

            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(condWork, ex.ToString());
                status = StatusError;
            }

            return status;
        }

        /// <summary>
        /// ���[�J�[�i�ԃp�^�[�����������̓o�^
        /// </summary>
        /// <param name="condWork">��������</param>
        /// <param name="makerGoodsPtrnNo">���[�J�[�i�ԃp�^�[��No.</param>
        /// <param name="goodsMakerCd">���i���[�J�[</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="callMode">0�F�p�^�[�����������G1�F�p�^�[�����������ȊO</param>
        /// <param name="makerGoodsSerchHisNo">��������ʔ�</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[�����������̓o�^���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int WriteHisByInsert(HandyGoodsSearchCondWork condWork, int makerGoodsPtrnNo, int goodsMakerCd, string goodsNo, int callMode, out int makerGoodsSerchHisNo)
        {
            // ��������
            makerGoodsSerchHisNo = 0;
            HandyMakerGoodsPtrnHisResultWork searchHisWork = new HandyMakerGoodsPtrnHisResultWork();
            // ��ƃR�[�h
            searchHisWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���s���t
            searchHisWork.SearchDate = GetLongDate(DateTime.Today);
            // ���[�J�[�R�[�h
            searchHisWork.GoodsMakerCd = goodsMakerCd;
            // �o�[�R�[�h�f�[�^
            searchHisWork.BarCodeData = condWork.BarCodeData;
            // ���[�J�[�i�ԃp�^�[��No.
            searchHisWork.MakerGoodsPtrnNo = makerGoodsPtrnNo;
            // �������i�ԍ�
            searchHisWork.SearchGoodsNo = goodsNo;
            // �g�p��
            searchHisWork.UseCount = 1;
            // �o�^�X�e�[�^�X
            searchHisWork.EntryStatus = 0;
            // UOE�����f�[�^�敪
            searchHisWork.UOEOrderTdlKind = 0;

            // ���[�J�[�i�ԃp�^�[����������o�^
            HandyMakerGoodsPtrnAcs HandyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
            int status = HandyMakerGoodsPtrnAcs.WriteHis(ref searchHisWork, 0, callMode);

            // ���擾������ɏI�������ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                makerGoodsSerchHisNo = searchHisWork.MakerGoodsSerchHisNo;
                status = StatusNomal;
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

            return status;
        }

        /// <summary>
        /// ���t���l�擾����
        /// </summary>
        /// <param name="date">DateTime�^���t</param>
        /// <returns>���l���t(YYYYMMDD)</returns>
        /// <remarks>
        /// <br>Note       : ���t���l�擾�������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private static int GetLongDate(DateTime date)
        {
            if (date == DateTime.MinValue)
            {
                return 0;
            }
            else
            {
                return ((date.Year * 10000) + (date.Month * 100) + (date.Day));
            }
        }

        /// <summary>
        /// �p�^�[������
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="mode">0�F���S����;1:�B������</param>
        /// <param name="retObj">�������ʃI�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �p�^�[���������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int SearchGoodsNo(object condObj, int goodsMakerCd, string goodsNo, int mode, out object retObj)
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            // 0�F���S����;1:�B������
            string goodsNoChange = (mode == 0) ? goodsNo : goodsNo + AmStr;
            string msg = string.Empty;
            retObj = null;
            HandyGoodsSearchCondWork condWork = condObj as HandyGoodsSearchCondWork;

            // �i�Ԍ�������
            GoodsCndtn cndtn = new GoodsCndtn();
            // ��ƃR�[�h
            cndtn.EnterpriseCode = condWork.EnterpriseCode;
            // ���i���[�J�[
            cndtn.GoodsMakerCd = goodsMakerCd;
            // �i��
            cndtn.GoodsNo = goodsNoChange;
            // ���_
            cndtn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // ���i�J�n��
            cndtn.PriceApplyDate = DateTime.Today;
            // �_���폜�敪
            cndtn.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;

            // �i�Ԍ���(�������������A����i�ԕ\���Ȃ�)
            GoodsAcs handyGoodsAcs = new GoodsAcs();
            int status = handyGoodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, false, out goodsUnitDataList, out msg);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {

                #region �������ʃZ�b�g
                ArrayList resultList = new ArrayList();
                ArrayList stockList = new ArrayList();
                HandyStockInsGoodsInfo goodInfo;
                HandyStockInsStockInfo stockInfo;

                //���i�A���f�[�^�˃n���f�B���i�A���f�[�^�ɃZ�b�g
                foreach (GoodsUnitData data in goodsUnitDataList)
                {
                    // �_���폜���ꂽ���[�U�[���i���ΏۊO
                    if (data.OfferDataDiv == 0 && data.LogicalDeleteCode == 1) continue;
                    goodInfo = new HandyStockInsGoodsInfo();
                    stockList = new ArrayList();
                    goodInfo.GoodsMakerCd = data.GoodsMakerCd;
                    goodInfo.GoodsMakerShortName = data.MakerName;
                    goodInfo.GoodsNo = data.GoodsNo;
                    goodInfo.GoodsName = data.GoodsName;
                    goodInfo.SupplierCd = data.SupplierCd;
                    goodInfo.SupplierSNm = data.SupplierSnm;

                    //�݌ɏ��
                    foreach (Stock stock in data.StockList)
                    {
                        stockInfo = new HandyStockInsStockInfo();
                        stockInfo.WarehouseCode = stock.WarehouseCode;
                        stockInfo.WarehouseShelfNo = stock.WarehouseShelfNo;
                        stockInfo.ShipmentPosCnt = stock.ShipmentPosCnt;
                        stockList.Add(stockInfo);
                    }
                    goodInfo.StockList = stockList;
                    resultList.Add(goodInfo);
                }
                retObj = (object)resultList;
                if (resultList.Count == 0)
                {
                    status = StatusNotFound;
                    return status;
                }
                #endregion
                status = StatusNomal;
            }
            else
            {
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
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
            }
            return status;
        }

        /// <summary>
        /// �i�Ԓ��o
        /// </summary>
        /// <param name="barCodeData">�p�[�R�[�h���</param>
        /// <param name="makerGoodsPtrnWork">���[�J�[�i�ԃp�^�[���}�X�^</param>
        /// <returns>�i��</returns>
        /// <remarks>
        /// <br>Note       : �i�Ԓ��o���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private string GetGoodsNo(string barCodeData, HandyMakerGoodsPtrnWork makerGoodsPtrnWork)
        {
            string goodsNo = string.Empty;
            StringBuilder str = new StringBuilder();

            if (!string.IsNullOrEmpty(makerGoodsPtrnWork.ControlStr))
            {
                // ���䕶����
                char[] tempChar = makerGoodsPtrnWork.ControlStr.ToCharArray();
                // �p�[�R�[�h���
                char[] barCodeChar = barCodeData.ToCharArray();

                for (int i = 0; i < tempChar.Length; i++)
                {
                    // �o�[�R�[�h���Ɛ��䕶������r���ĕi�Ԃ𒊏o����B
                    if (tempChar[i] == '1')
                    {
                        if (i < barCodeData.Length)
                        {
                            str.Append(barCodeChar[i].ToString());
                        }
                    }
                    else if (tempChar[i] == '9')
                    {
                        str.Append(barCodeChar[i].ToString());
                        break;
                    }
                }
            }
            goodsNo = str.ToString();
            // �q�b�g����Ȃ��ꍇ�A�o�[�R�[�h�������i�ԂƂ��ė��p����
            if (string.IsNullOrEmpty(goodsNo))
            {
                goodsNo = barCodeData;
            }
            return goodsNo;
        }

        #endregion

        #region �� �i�Ԍ�������
        /// <summary>
        /// �i�Ԍ���
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="retObj">�������ʃI�u�W�F�N�g</param>
        /// <param name="makerGoodsSerchHisNoObj">��������ʔ�</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�w��̏ꍇ�A�i�Ԍ������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyStockGoodsNo(object condObj, out object retObj, out object makerGoodsSerchHisNoObj)
        {
            int status = StatusError;
            retObj = null;
            int makerGoodsSerchHisNo = 0;
            makerGoodsSerchHisNoObj = null;

            // ��������
            HandyGoodsSearchCondWork condWork = condObj as HandyGoodsSearchCondWork;
            int mode = 0;
            int goodsMakerCd = 0;
            string goodsNo = string.Empty;

            #region �p�����[�^�`�F�b�N
            // �p�����[�^��null�̏ꍇ
            if (condWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ErrorMsgNull);
                return status;
            }
            else
            {
                // 0�F�p�^�[������(���[�J�[���w��)/1�F�i�Ԍ���
                if (condWork.GoodsMakerCd == 0 && !string.IsNullOrEmpty(condWork.BarCodeData))
                {
                    mode = 0;
                }
                else
                {
                    mode = 1;
                }
                // �p�����[�^�`�F�b�N
                if (mode == 1)
                {
                    // ���̓p�����[�^�u��ƃR�[�h�A�R���s���[�^�[���A�]�ƈ��R�[�h�A���i�ԍ��v�͋󂪂���ꍇ�A�G���[��߂�܂��B
                    if (string.IsNullOrEmpty(condWork.EnterpriseCode.Trim())
                        || string.IsNullOrEmpty(condWork.EmployeeCode.Trim())
                        || string.IsNullOrEmpty(condWork.MachineName.Trim())
                        || string.IsNullOrEmpty(condWork.GoodsNo.Trim()))
                    {
                        // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                        this.WriteLog(condWork, ErrorMsgParam);
                        return status;
                    }
                }
                else
                {
                    // ���̓p�����[�^�u��ƃR�[�h�A�R���s���[�^�[���A�]�ƈ��R�[�h�A�p�[�R�[�h���v�͋󂪂���ꍇ�A�G���[��߂�܂��B
                    if (string.IsNullOrEmpty(condWork.EnterpriseCode.Trim())
                        || string.IsNullOrEmpty(condWork.EmployeeCode.Trim())
                        || string.IsNullOrEmpty(condWork.MachineName.Trim())
                        || string.IsNullOrEmpty(condWork.BarCodeData.Trim()))
                    {
                        // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                        this.WriteLog(condWork, ErrorMsgParam);
                        return status;
                    }
                }
            }
            #endregion

            try
            {
                // ���[�J�[
                goodsMakerCd = condWork.GoodsMakerCd;
                // �i��
                goodsNo = condWork.GoodsNo;

                // 0�F�i�Ԍ���(���[�J�[���w��)�̏ꍇ
                if (mode == 0)
                {
                    #region ���i�o�[�R�[�h�֘A�t���}�X�^����
                    // ���i�o�[�R�[�h�֘A�t���}�X�^����
                    Object resultObj;
                    ArrayList handyGoodsBarCodeRevnResultWork = new ArrayList();
                    HandyMakerGoodsPtrnAcs handyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
                    status = handyMakerGoodsPtrnAcs.SearchGoodsBarCodeRevn(condWork.EnterpriseCode, condWork.BarCodeData, 0, out resultObj);
                    // ���擾������ɏI�������ꍇ
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        handyGoodsBarCodeRevnResultWork = resultObj as ArrayList;

                        ArrayList resultList = new ArrayList();

                        foreach (object workObj in handyGoodsBarCodeRevnResultWork)
                        {
                            GoodsBarCodeRevnWork work = (GoodsBarCodeRevnWork)workObj;

                            object resultWk = null;
                            // �i�Ԍ���
                            status = SearchGoodsNo(condObj, work.GoodsMakerCd, work.GoodsNo, mode, out resultWk);
                            if (status == StatusNomal)
                            {
                                foreach (HandyStockInsGoodsInfo info in (ArrayList)resultWk)
                                {
                                    resultList.Add(info);
                                }
                            }
                            else if (status != StatusNotFound)
                            {
                                return status;
                            }
                        }

                        if (resultList.Count <= 0)
                        {
                            return StatusNotFound;
                        }

                        retObj = resultList;

                        // ���[�J�[�i�ԃp�^�[�����������̓o�^
                        status = WriteHisByInsert(condWork, 0, 0, string.Empty, 1, out makerGoodsSerchHisNo);
                        makerGoodsSerchHisNoObj = (object)makerGoodsSerchHisNo;

                        return status;
                    }
                    // ��񂪌�����Ȃ��ꍇ
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        return StatusNotFound;
                    }
                    // �Ǎ����̃^�C���A�E�g�ꍇ
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        return StatusTimeout;
                    }
                    // DB�������ŃG���[�����������ꍇ
                    else
                    {
                        return StatusError;
                    }
                    #endregion
                }
                
                // �i�Ԍ���
                status = SearchGoodsNo(condObj, goodsMakerCd, goodsNo, mode, out retObj);
                if (status != StatusNomal)
                {
                    return status;
                }

                // ���[�J�[�i�ԃp�^�[�����������̓o�^
                status = WriteHisByInsert(condWork, 0, goodsMakerCd, goodsNo, 1, out makerGoodsSerchHisNo);
                makerGoodsSerchHisNoObj = (object)makerGoodsSerchHisNo;

            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(condWork, ex.ToString());
                status = StatusError;
            }

            return status;
        }
        #endregion

        #region �� �݌ɓo�^
        /// <summary>
        /// �݌ɓo�^
        /// </summary>
        /// <param name="paraHandyStockInfoCondObj">���������I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɓo�^���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// <br>Update Note: 2021/06/21 ������</br>
        /// <br>�Ǘ��ԍ�   : 11601223-00</br>
        /// <br>           : PMKOBETSU-3268�̑Ή�</br> 
        /// </remarks>
        public int WriteHandyStock(object paraHandyStockInfoCondObj)
        {
            int status = StatusError;
            // ��������
            HandyGoodsUpdateCondWork condWork = paraHandyStockInfoCondObj as HandyGoodsUpdateCondWork;
            GoodsUnitData goodsUnitData = null;
            GoodsMngWork curMngWork = new GoodsMngWork();
            List<Stock> prevStockList = new List<Stock>();
            string msg = string.Empty;

            #region �p�����[�^�`�F�b�N
            // �p�����[�^��null�̏ꍇ
            if (condWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLogByUpdate(null, ErrorMsgNull);
                return status;
            }
            else
            {
                // �p�����[�^�`�F�b�N
                // ���̓p�����[�^�u��ƃR�[�h�A�R���s���[�^�[���A�]�ƈ��R�[�h�A���[�J�[�R�[�h�A���i�ԍ��A�q�ɃR�[�h�A���ɐ��A�p�^�[����������ʔԁv�͋󂪂���ꍇ�A�G���[��߂�܂��B
                if (string.IsNullOrEmpty(condWork.EnterpriseCode.Trim())
                    || string.IsNullOrEmpty(condWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(condWork.MachineName.Trim())
                    || condWork.GoodsMakerCd == 0
                    || string.IsNullOrEmpty(condWork.GoodsNo.Trim())
                    || condWork.StockCount == 0
                    || condWork.MakerGoodsSerchHisNo == 0)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLogByUpdate(condWork, ErrorMsgParam);
                    return status;
                }
            }
            #endregion

            WarehouseAcs warehouseAcs = new WarehouseAcs();
            Warehouse warehouseResult = null;

            try
            {
                // �q�ɏ��擾
                status = warehouseAcs.Read(out warehouseResult, condWork.EnterpriseCode, string.Empty, condWork.WarehouseCode);
                if (warehouseResult == null || status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    this.WriteLogByUpdate(condWork, ErrorWarehouseAcquisitionFailure);
                    status = StatusNotFound;
                    return status;
                }

                // ���i�݌Ɍ���
                status = SearchGoodsNo(condWork, out goodsUnitData);
                if (status != StatusNomal)
                {
                    return status;
                }

                if (goodsUnitData != null)
                {
                    // �X�V�p�p�����[�^�̍쐬
                    foreach (Stock stock in goodsUnitData.StockList)
                    {
                        prevStockList.Add(stock.Clone());
                    }
                }

                // �X�V�p�p�����[�^�̍쐬
                bool isNewStock = true;
                if (goodsUnitData.StockList != null)
                {
                    foreach (Stock goodsStock in goodsUnitData.StockList)
                    {
                        if (!string.IsNullOrEmpty(condWork.WarehouseCode.Trim()) && condWork.WarehouseCode.Trim() == goodsStock.WarehouseCode.Trim())
                        {
                            isNewStock = false;
                        }
                    }
                }

                SetGoodsUnitData(ref goodsUnitData, condWork, ref curMngWork, warehouseResult);

                if (curMngWork.SupplierCd == 0) curMngWork = null;
                // ���i�݌ɍX�V�ďo
                List<Rate> rateList = new List<Rate>();
                GoodsAcs handyGoodsAcs = new GoodsAcs();
                //-----UPD 2021/06/21 ������ PMKOBETSU-3268�̑Ή�----->>>>>
                //status = handyGoodsAcs.Write(ref goodsUnitData, prevStockList, ref rateList, curMngWork, out msg);
                status = handyGoodsAcs.WriteHandy(ref goodsUnitData, prevStockList, ref rateList, curMngWork, out msg, condWork.MachineName.Trim());
                //-----UPD 2021/06/21 ������ PMKOBETSU-3268�̑Ή�-----<<<<<
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // ��������
                    HandyZaikoRegistMngWork mngWork = new HandyZaikoRegistMngWork();
                    // ��ƃR�[�h
                    mngWork.EnterpriseCode = condWork.EnterpriseCode;
                    // ���i���[�J�[
                    mngWork.GoodsMakerCd = condWork.GoodsMakerCd;
                    // �i��
                    mngWork.GoodsNo = condWork.GoodsNo;
                    // ���_
                    mngWork.SectionCode = warehouseResult.SectionCode;
                    // ���_
                    mngWork.WarehouseCode = condWork.WarehouseCode;

                    if (isNewStock)
                    {
                        // �n���f�B�݌ɓo�^�Ǘ��f�[�^��o�^
                        HandyMakerGoodsPtrnAcs handyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
                        status = handyMakerGoodsPtrnAcs.WriteMng(mngWork);
                    }

                    // ���[�J�[�i�ԃp�^�[�����������f�[�^�X�V
                    status = WriteHisByUpdate(condWork, condWork.GoodsNo, 1, 0);  

                }
                else
                {
                    // ���[�J�[�i�ԃp�^�[�����������f�[�^�X�V
                    status = WriteHisByUpdate(condWork, condWork.GoodsNo, -1, 0);
                }

            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLogByUpdate(condWork, ex.ToString());
                status = StatusError;
            }

            return status;
        }

        /// <summary>
        /// ���[�J�[�i�ԃp�^�[�����������̓o�^
        /// </summary>
        /// <param name="condWork">��������</param>
        /// <param name="entryGoodsNo">�m��ԍ�</param>
        /// <param name="entryStatus">�o�^�X�e�[�^�X</param>
        /// <param name="uOEOrderTdlKind">UOE�����f�[�^�敪</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[�i�ԃp�^�[�����������̓o�^���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int WriteHisByUpdate(HandyGoodsUpdateCondWork condWork, string entryGoodsNo, int entryStatus, int uOEOrderTdlKind)
        {
            // ��������
            HandyMakerGoodsPtrnHisResultWork searchHisWork = new HandyMakerGoodsPtrnHisResultWork();
            // ��ƃR�[�h
            searchHisWork.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // �p�^�[����������ʔ�
            searchHisWork.MakerGoodsSerchHisNo = condWork.MakerGoodsSerchHisNo;
            // ���s���t
            searchHisWork.SearchDate = GetLongDate(DateTime.Today);
            // �m��i��
            searchHisWork.EntryGoodsNo = entryGoodsNo;
            // �o�^�X�e�[�^�X
            searchHisWork.EntryStatus = entryStatus;
            // UOE�����f�[�^�敪
            searchHisWork.UOEOrderTdlKind = uOEOrderTdlKind;

            searchHisWork.SearchGoodsNo = condWork.GoodsNo;

            searchHisWork.GoodsMakerCd = condWork.GoodsMakerCd;

            // ���[�J�[�i�ԃp�^�[����������o�^
            HandyMakerGoodsPtrnAcs handyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
            int status = handyMakerGoodsPtrnAcs.WriteHis(ref searchHisWork, 1, 1);

            // ���擾������ɏI�������ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = StatusNomal;
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
            return status;
        }

        /// <summary>
        /// �݌ɓo�^�p�i�Ԍ���
        /// </summary>
        /// <param name="condWork">���������I�u�W�F�N�g</param>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �݌ɓo�^�p�i�Ԍ������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private int SearchGoodsNo(HandyGoodsUpdateCondWork condWork, out GoodsUnitData goodsUnitData)
        {
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            string msg = string.Empty;
            goodsUnitData = null;

            // �i�Ԍ�������
            GoodsCndtn cndtn = new GoodsCndtn();
            // ��ƃR�[�h
            cndtn.EnterpriseCode = condWork.EnterpriseCode;
            // ���i���[�J�[
            cndtn.GoodsMakerCd = condWork.GoodsMakerCd;
            // �i��
            cndtn.GoodsNo = condWork.GoodsNo;
            // ���_
            cndtn.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            // ���i�J�n��
            cndtn.PriceApplyDate = DateTime.Today;
            // �_���폜�敪
            cndtn.LogicalMode = (int)ConstantManagement.LogicalMode.GetData01;

            // �i�Ԍ���(�������������A����i�ԕ\���Ȃ�)
            GoodsAcs handyGoodsAcs = new GoodsAcs();
            int status = handyGoodsAcs.SearchPartsFromGoodsNoNonVariousSearch(cndtn, false, out goodsUnitDataList, out msg);
            if (goodsUnitDataList.Count > 0) goodsUnitData = goodsUnitDataList[0];
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                GoodsUnitData wkGoodsUnitData;
                List<Rate> wkRateList;
                int wkStatus = handyGoodsAcs.ReadGoodsWithRate(condWork.EnterpriseCode, goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo, ConstantManagement.LogicalMode.GetData01, out wkGoodsUnitData, out wkRateList);
                if (wkStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    goodsUnitData = wkGoodsUnitData;
                    status = StatusNomal;
                }
            }
            else
            {
                if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
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
            }

            return status;
        }

        /// <summary>
        /// �X�V�p�p�����[�^�̍쐬
        /// </summary>
        /// <param name="data">���i�A���f�[�^</param>
        /// <param name="condWork">��������</param>
        /// <param name="curMngWork">���i�Ǘ����}�X�^</param>
        /// <param name="warehouseWork">�q�ɏ��</param>
        /// <remarks>
        /// <br>Note       : �X�V�p�p�����[�^�̍쐬���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void SetGoodsUnitData(ref GoodsUnitData data, HandyGoodsUpdateCondWork condWork, ref GoodsMngWork curMngWork, Warehouse warehouseWork)
        {

            // �񋟕��V�K�f�[�^�ɂ��āA�V�K�Ƃ��ď��i�݌ɂ��쐬
            if (data.OfferKubun != 0 && data.LogicalDeleteCode == 0)
            {
                // ���i�A���f�[�^
                // ���i����
                //data.GoodsKindCode = condWork.GoodsKindCode;  // ���i�����Ŏ擾�����l���g�p�i�ݒ��ʂ̏����l0�F�����Œ񋟗D�Ǖi��V�K�݌ɓo�^�����ꍇ�A���i������0�F�����œo�^����Ă��܂��j
                
                // �ېŋ敪
                //data.TaxationDivCd = condWork.TaxationDivCd;  // ���i�����Ŏ擾�����l���g�p

                // �݌ɏ��p�����[�^�̍쐬
                Stock wkStock = new Stock();

                CreateNewStock(ref wkStock, condWork, warehouseWork);

                data.StockList.Add(wkStock);

                // ���i�Ǘ����}�X�^�p�����[�^�̍쐬
                if (condWork.SupplierCd != 0)
                {
                    //�u�S�Ћ���+���[�J�[�{�i�ԁv��V�K�o�^����

                    CreateNewGoodsMng(ref curMngWork, condWork, warehouseWork);

                }
            }
            // ���ɑ��݂̃��[�U�[�݌ɕi�F�݌ɐ����X�V �����i�Ǘ������쐬�s�v
            else
            {
                // ���i�A���f�[�^
                // ���i����
                // data.GoodsKindCode = condWork.GoodsKindCode;  // ���i�����Ŏ擾�����l���g�p
                // �ېŋ敪
                // data.TaxationDivCd = condWork.TaxationDivCd;  // ���i�����Ŏ擾�����l���g�p

                // ��������
                if (data.LogicalDeleteCode == 1)
                {
                    data.LogicalDeleteCode = 0;
                }

                // �݌ɏ��
                bool isAtStock = false;
                foreach (Stock stock in data.StockList)
                {
                    if (stock.WarehouseCode.Trim() == condWork.WarehouseCode.Trim())
                    {
                        // �݌ɂ���
                        if (stock.LogicalDeleteCode == 0)
                        {
                            // �d���݌ɐ��Ɉ���.���ɐ������Z����
                            stock.SupplierStock = stock.SupplierStock + condWork.StockCount;
                            // �݌ɋ敪
                            stock.StockDiv = condWork.StockDiv;
                            // �q�ɒI��
                            stock.WarehouseShelfNo = condWork.WarehouseShelfNo;
                        }
                        // �݌ɘ_���폜�̏��i�ːV�K�݌ɂƂ��č쐬
                        else if (stock.LogicalDeleteCode == 1)
                        {
                            Stock wkStock = stock.Clone();

                            CreateNewStock(ref wkStock, condWork, warehouseWork);

                            data.StockList.Remove(stock);
                            data.StockList.Add(wkStock);
                        }
                        isAtStock = true;
                        break;
                    }
                }
                // �݌ɂȂ��ːV�K�݌ɂƂ��č쐬
                if (isAtStock == false)
                {
                    Stock wkStock = new Stock();

                    CreateNewStock(ref wkStock, condWork, warehouseWork);

                    data.StockList.Add(wkStock);
                }
            }
        }

        /// <summary>
        /// �V�K���i�݌ɏ��쐬
        /// </summary>
        /// <param name="curMngWork">���i�݌ɏ��</param>
        /// <param name="condWork">��������</param>
        /// <param name="warehouseWork">�q�ɏ��</param>
        /// <remarks>
        /// <br>Note       : �V�K���i�݌ɏ��쐬���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void CreateNewGoodsMng(ref GoodsMngWork curMngWork, HandyGoodsUpdateCondWork condWork, Warehouse warehouseWork)
        {
            curMngWork = new GoodsMngWork();
            curMngWork.EnterpriseCode = condWork.EnterpriseCode;
            curMngWork.LogicalDeleteCode = 0;

            curMngWork.SectionCode = "00";

            curMngWork.GoodsMGroup = 0;
            curMngWork.GoodsMakerCd = condWork.GoodsMakerCd;
            curMngWork.BLGoodsCode = 0;
            curMngWork.GoodsNo = string.Empty;
            curMngWork.SupplierCd = condWork.SupplierCd;
            curMngWork.SupplierLot = 0;
        }

        /// <summary>
        /// �V�K�݌ɏ��쐬
        /// </summary>
        /// <param name="stock">�݌ɏ��</param>
        /// <param name="condWork">��������</param>
        /// <param name="warehouseWork">�q�ɏ��</param>
        /// <remarks>
        /// <br>Note       : �V�K�݌ɏ��쐬���s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void CreateNewStock(ref Stock stock, HandyGoodsUpdateCondWork condWork, Warehouse warehouseWork)
        {
            stock.EnterpriseCode = condWork.EnterpriseCode;
            stock.LogicalDeleteCode = 0;

            stock.SectionCode = warehouseWork.SectionCode;

            stock.WarehouseCode = condWork.WarehouseCode;
            // --- ADD 2020/04/22 ---------->>>>>
            stock.WarehouseName = condWork.WarehouseName;
            stock.PartsManagementDivide1 = "0";
            stock.PartsManagementDivide2 = "0";
            // --- ADD 2020/04/22 ----------<<<<<
            stock.GoodsMakerCd = condWork.GoodsMakerCd;
            stock.GoodsNo = condWork.GoodsNo;
            stock.StockUnitPriceFl = 0;
            stock.SupplierStock = condWork.StockCount;
            stock.AcpOdrCount = 0;
            stock.MonthOrderCount = 0;
            stock.SalesOrderCount = 0;
            stock.StockDiv = condWork.StockDiv;
            stock.MovingSupliStock = 0;
            stock.ShipmentPosCnt = 0;
            stock.StockTotalPrice = 0;
            stock.LastStockDate = DateTime.MinValue;
            stock.LastSalesDate = DateTime.MinValue;
            stock.LastInventoryUpdate = DateTime.MinValue;
            stock.MinimumStockCnt = 0;
            stock.MaximumStockCnt = 0;
            stock.NmlSalOdrCount = 0;
            stock.SalesOrderUnit = 0;
            stock.StockSupplierCode = 0;
            stock.GoodsNoNoneHyphen = condWork.GoodsNo.Replace("-", "");
            stock.WarehouseShelfNo = condWork.WarehouseShelfNo;
            stock.DuplicationShelfNo1 = string.Empty;
            stock.DuplicationShelfNo2 = string.Empty;
            stock.StockNote1 = string.Empty;
            stock.StockNote2 = string.Empty;
            stock.ShipmentCnt = 0;
            stock.ArrivalCnt = 0;
            stock.StockCreateDate = DateTime.Today;
            stock.UpdateDate = DateTime.Today;
        }

        #endregion

        #region �� UOE�����f�[�^����
        /// <summary>
        /// UOE�����f�[�^����
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="count">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���w��̏ꍇ�A�i�Ԍ������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        public int SearchHandyUOEOrder(object condObj, out object count)
        {
            int status = StatusError;
            count = null;
            int countR = 0;
            // ��������
            HandyGoodsUpdateCondWork condWork = condObj as HandyGoodsUpdateCondWork;

            #region �p�����[�^�`�F�b�N
            // �p�����[�^��null�̏ꍇ�A
            if (condWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLogByUpdate(null, ErrorMsgNull);
                return status;
            }
            else
            {
                // �p�����[�^�`�F�b�N
                // ���̓p�����[�^�u��ƃR�[�h�A�R���s���[�^�[���A�]�ƈ��R�[�h�A���[�J�[�R�[�h�A���i�ԍ��A�p�^�[����������ʔԁv�͋󂪂���ꍇ�A�G���[��߂�܂��B
                if (string.IsNullOrEmpty(condWork.EnterpriseCode.Trim())
                    || string.IsNullOrEmpty(condWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(condWork.MachineName.Trim())
                    || condWork.GoodsMakerCd == 0
                    || string.IsNullOrEmpty(condWork.GoodsNo.Trim())
                    || condWork.MakerGoodsSerchHisNo == 0)

                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLogByUpdate(condWork, ErrorMsgParam);
                    return status;
                }
            }
            #endregion

            try
            {
                // UOE�����f�[�^����
                HandyMakerGoodsPtrnAcs HandyMakerGoodsPtrnAcs = new HandyMakerGoodsPtrnAcs();
                status = HandyMakerGoodsPtrnAcs.SearchHandyUOEOrder(ref condObj, out countR);
                // ���擾������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    count = (object)countR;
                    // ���[�J�[�i�ԃp�^�[�����������f�[�^�X�V
                    // --- UPD 2020/04/28 M.KISHI ---------->>>>>
                    //status = WriteHisByUpdate(condWork, string.Empty, 0, 1);
                    int paraKind = 0;
                    if (countR > 0)
                    {
                        paraKind = 1;
                    }
                    status = WriteHisByUpdate(condWork, string.Empty, 0, paraKind);
                    // --- UPD 2020/04/28 M.KISHI ----------<<<<<

                }
                // �Ǎ����̃^�C���A�E�g�ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                {
                    return StatusTimeout;
                }
                // DB�������ŃG���[�����������ꍇ
                else
                {
                    return StatusError;
                }
            }
            catch (Exception ex)
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLogByUpdate(condWork, ex.ToString());
                status = StatusError;
            }

            return status;

        }
        #endregion

        #region �� �G���[���O�o�͏���
        /// <summary>
        /// �G���[���O�o�͏���
        /// </summary>
        /// <param name="condWork">���������I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �G���[���O�����o�͂��܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void WriteLog(HandyGoodsSearchCondWork condWork, string errMsg)
        {
            FileStream fileStream = null;
            StreamWriter writer = null;
            try
            {
                string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), PathLog);

                lock (LogLockObj)
                {
                    // �t�H���_�����݂��Ȃ��ꍇ�A
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    fileStream = new FileStream(Path.Combine(path, DefaultNamePgid + DateTime.Now.ToString(DefaultNameTime) + DefaultNameFile), FileMode.Append, FileAccess.Write, FileShare.Write);
                    writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                    DateTime writingDateTime = DateTime.Now;
                    writer.WriteLine(string.Format(DefaultLogFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                    // �p�����[�^��null�ł͂Ȃ��ꍇ�A�G���[���b�Z�[�W�Ɉ����̖��O�ƒl���o�͂��܂��B
                    if (condWork != null)
                    {
                        // ��ƃR�[�h
                        writer.WriteLine(EnterpriseCode + condWork.EnterpriseCode);
                        // �R���s���[�^�[��
                        writer.WriteLine(EmployeeCode + condWork.MachineName);
                        // �]�ƈ��R�[�h
                        writer.WriteLine(MachineName + condWork.EmployeeCode);
                        // ���[�J�[�R�[�h
                        writer.WriteLine(GoodsMakerCd + condWork.GoodsMakerCd);
                        // ���i�ԍ�
                        writer.WriteLine(GoodsNo + condWork.GoodsNo);
                        // �p�[�R�[�h���
                        writer.WriteLine(BarCodeData + condWork.BarCodeData);
                    }
                }
            }
            catch
            {
                // �����Ȃ�
            }
            finally
            {   
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }

        }

        /// <summary>
        /// �G���[���O�o�͏����i�݌ɍX�V�p�j
        /// </summary>
        /// <param name="condWork">���������I�u�W�F�N�g</param>
        /// <param name="errMsg">�G���[���b�Z�[�W</param>
        /// <returns>�Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �G���[���O�����o�͂��܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2020/03/09</br>
        /// </remarks>
        private void WriteLogByUpdate(HandyGoodsUpdateCondWork condWork, string errMsg)
        {
            FileStream fileStream = null;
            StreamWriter writer = null;
            try
            {
                string path = Path.Combine(System.IO.Directory.GetCurrentDirectory(), PathLog);

                lock (LogLockObj)
                {
                    // �t�H���_�����݂��Ȃ��ꍇ�A
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    fileStream = new FileStream(Path.Combine(path, DefaultNamePgid + DateTime.Now.ToString(DefaultNameTime) + DefaultNameFile), FileMode.Append, FileAccess.Write, FileShare.Write);
                    writer = new StreamWriter(fileStream, Encoding.GetEncoding(DefaultEncode));
                    DateTime writingDateTime = DateTime.Now;
                    writer.WriteLine(string.Format(DefaultLogFormat, writingDateTime, writingDateTime.Millisecond, errMsg));
                    // �p�����[�^��null�ł͂Ȃ��ꍇ�A�G���[���b�Z�[�W�Ɉ����̖��O�ƒl���o�͂��܂��B
                    if (condWork != null)
                    {
                        // ��ƃR�[�h
                        writer.WriteLine(EnterpriseCode + condWork.EnterpriseCode);
                        // �R���s���[�^�[��
                        writer.WriteLine(EmployeeCode + condWork.MachineName);
                        // �]�ƈ��R�[�h
                        writer.WriteLine(MachineName + condWork.EmployeeCode);
                        // ���[�J�[�R�[�h
                        writer.WriteLine(GoodsMakerCd + condWork.GoodsMakerCd);
                        // ���i�ԍ�
                        writer.WriteLine(GoodsNo + condWork.GoodsNo);
                        // �q�ɃR�[�h
                        writer.WriteLine(WarehouseCode + condWork.WarehouseCode);
                        // �q�ɒI��
                        writer.WriteLine(WarehouseShelfNo + condWork.WarehouseShelfNo);
                        // �d����
                        writer.WriteLine(SupplierCd + condWork.SupplierCd);
                        // ���ɐ�
                        writer.WriteLine(StockCount + condWork.StockCount);
                        // ���i����
                        writer.WriteLine(GoodsKindCode + condWork.GoodsKindCode);
                        // �ېŋ敪
                        writer.WriteLine(TaxationDivCd + condWork.TaxationDivCd);
                        // �݌ɋ敪
                        writer.WriteLine(StockDiv + condWork.StockDiv);
                        // �p�^�[����������ʔ�
                        writer.WriteLine(MakerGoodsSerchHisNo + condWork.MakerGoodsSerchHisNo);
                    }
                }
            }
            catch
            {
                // �����Ȃ�
            }
            finally
            {
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}
