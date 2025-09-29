//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���݌Ɉړ��A�N�Z�X�N���X
// �v���O�����T�v   : �n���f�B�^�[�~�i���݌Ɉړ��A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : ���O
// �� �� ��  2017/08/02  �C�����e : �V�K�쐬
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
using Broadleaf.Library.Collections;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �n���f�B�^�[�~�i���݌Ɉړ��A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �n���f�B�^�[�~�i���݌Ɉړ��A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : 2017/08/02</br>
    /// </remarks>
    public class HandyStockMoveAcs
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
        /// <summary>�`�[�����i�ΏۊO�̏ꍇ</summary>
        private const int StatusNonTarget = 6;
        /// <summary>���i�X�e�[�^�X�u3:���i�ς݁v</summary>
        private const int InspectStatusInspected = 3;
        /// <summary>�f�t�H���g�G���R�[�h</summary>
        private const string DefaultEncode = "shift_jis";
        /// <summary>���O�p�X</summary>
        private const string PathLog = @"\Log\PMHND";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string DefaultNamePgid = "PMHND01210A_";
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
        /// <summary>�݌Ɉړ��`�[�ԍ�</summary>
        private const string StockMoveSlipNo = "�݌Ɉړ��`�[�ԍ�:";
        /// <summary>�݌Ɉړ��`�[�ԍ�</summary>
        private const string StockMoveSlipNumNo = "�݌Ɉړ��s�ԍ�:";
        /// <summary>�q�ɃR�[�h</summary>
        private const string WarehouseCode = "�q�ɃR�[�h:";
        /// <summary>���i���[�J�[�R�[�h</summary>
        private const string GoodsMakerCd = "���i���[�J�[�R�[�h:";
        /// <summary>���i�ԍ�</summary>
        private const string GoodsNo = "���i�ԍ�:";
        /// <summary>�q�ɒI��</summary>
        private const string WarehouseShelfNo = "�I��:";
        /// <summary>���i�敪</summary>
        private const string InspectCode = "���i�敪:";
        /// <summary>���i��</summary>
        private const string InspectCnt = "���i��:";
        /// <summary>���i�X�e�[�^�X</summary>
        private const string InspectStatus = "���i�X�e�[�^�X:";
        /// <summary>�p�����[�^null���b�Z�[�W</summary>
        private const string ErrorMsgNull = "����������null�ł��B";
        /// <summary>�p�����[�^�G���[���b�Z�[�W</summary>
        private const string ErrorMsgParam = "���̓p�����[�^�G���[���������܂����B";
        /// <summary>�݌ɊǗ��S�̐ݒ�}�X�^�Ǎ��G���[���b�Z�[�W</summary>
        private const string StockMngTtlErrorMsg = "�݌ɊǗ��S�̐ݒ�}�X�^�̎擾�����s���܂����B";
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
        public HandyStockMoveAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [Public Methods]
        /// <summary>
        /// �n���f�B�^�[�~�i���݌Ɉړ��`�[���擾����
        /// </summary>
        /// <param name="condObj">���������I�u�W�F�N�g</param>
        /// <param name="retObj">�������ʃI�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���݌Ɉړ��`�[�����擾���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int SearchStockMoveData(object condObj, out object retObj)
        {
            retObj = null;
            int status = StatusError;

            // ��������
            HandyStockMoveCondWork stockMoveCondWork = condObj as HandyStockMoveCondWork;

            // �p�����[�^��null�̏ꍇ�A
            if (stockMoveCondWork == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(stockMoveCondWork, ErrorMsgNull);
                return status;
            }
            // �p�����[�^��null�ł͂Ȃ��ꍇ�A�p�����[�^���`�F�b�N���܂��B
            else
            {
                // ���̓p�����[�^��ƃR�[�h�A�]�ƈ��R�[�h�A�R���s���[�^���A�`�[�ԍ��͋󂪂���ꍇ�A�G���[��߂�܂��B
                if (string.IsNullOrEmpty(stockMoveCondWork.EnterpriseCode)
                    || string.IsNullOrEmpty(stockMoveCondWork.EmployeeCode.Trim())
                    || string.IsNullOrEmpty(stockMoveCondWork.MachineName.Trim()))
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(stockMoveCondWork, ErrorMsgParam);
                    return status;
                }
                // �����敪���u15,16�v�ȊO�̏ꍇ�AST_ERR(-1)��ԋp���܂��B
                if (stockMoveCondWork.ProcDiv != 15 && stockMoveCondWork.ProcDiv != 16)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(stockMoveCondWork, ErrorMsgParam);
                    return status;
                }
            }
            try
            {
                // �݌ɊǗ��S�̐ݒ�}�X�^�Ǎ�
                StockMngTtlSt RetWork = new StockMngTtlSt();
                StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
                status = stockMngTtlStAcs.Read(out RetWork, stockMoveCondWork.EnterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �݌Ɉړ��m��敪�擾
                    stockMoveCondWork.StockMoveFixCode = RetWork.StockMoveFixCode;
                }
                else
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(stockMoveCondWork, StockMngTtlErrorMsg);
                    return status;
                }

                #region �݌Ɉړ��`�[���擾
                byte[] condByte = XmlByteSerializer.Serialize(stockMoveCondWork);
                IHandyStockMoveDB iStockMoveDBObj = (IHandyStockMoveDB)MediationHandyStockMoveDB.GetHandyStockMoveDB();
                // �݌Ɉړ��`�[���擾���s���܂�
                status = iStockMoveDBObj.Search(condByte, out retObj);

                // ���擾������ɏI�������ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    bool beenInspected = true;

                    foreach (HandyStockMoveWork retWork in retObj as ArrayList)
                    {
                        // ����.�����敪���u16�F�݌Ɉړ����׌��i�v�̏ꍇ��݌Ɉړ��m��敪���u1�F�m�肠��v�̏ꍇ
                        if (stockMoveCondWork.ProcDiv == 16 && stockMoveCondWork.StockMoveFixCode == 1)
                        {
                            // ���i�X�e�[�^�X���u3:���i�ς݁v�ł͂Ȃ��ꍇ&&�ړ���Զޢ9�F���׍ςݣ�ł͂Ȃ��ꍇ
                            if (retWork.InspectStatus != InspectStatusInspected && retWork.MoveStatus != 9)
                            {
                                // ���i�ΏۂƂ���
                                beenInspected = false;
                                break;
                            }
                        }
                        else
                        {
                            // ���i�X�e�[�^�X���u3:���i�ς݁v�ł͂Ȃ��ꍇ
                            if (retWork.InspectStatus != InspectStatusInspected)
                            {
                                // ���i�ΏۂƂ���
                                beenInspected = false;
                                break;
                            }
                        }
                    }
                    // ���i�X�e�[�^�X�S�����u3:���i�ς݁v�̏ꍇ
                    if (beenInspected)
                    {
                        // ���i�ΏۊO�Ƃ��A���i�Ώۃf�[�^��ԋp���܂���B
                        status = StatusNonTarget;
                    }
                    // ���i�X�e�[�^�X���u3:���i�ς݁v�ȊO�̃f�[�^������ꍇ
                    else
                    {
                        status = StatusNomal;
                    }
                }
                // �݌Ɉړ��`�[��񂪌�����Ȃ��ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // �Ǎ����Ƀ^�C���A�E�g�����������ꍇ
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
                this.WriteLog(stockMoveCondWork, ex.ToString());
                status = StatusError;
            }
            finally
            {
                // �����Ȃ��B
            }

            return status;
        }

        # region [�݌Ɉړ��i�o�ׁE���ׁj���i�f�[�^�o�^]
        /// <summary>
        /// �݌Ɉړ��i�o�ׁE���ׁj���i�f�[�^�o�^����
        /// </summary>
        /// <param name="inspectDataObj">�o�^�f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �݌Ɉړ��i�o�ׁE���ׁj���i�f�[�^�o�^��o�^���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2017/08/02</br>
        /// </remarks>
        public int WriteStockMoveInspect(object inspectDataObj)
        {
            int status = StatusError;
            ArrayList inspectDataList = new ArrayList();
            ArrayList stockMoveList = new ArrayList();
            StockMoveWork stockWork = null;
            StockMoveSlipSearchCondWork stockMoveSlipSearchWork = null;
            int stockMoveFixCode = 0;
            int moveStockAutoInsDiv = 0;
            int procDiv = 0;
            bool firstFlg = true;
            bool searchFirstFlg = true;
            object reqObj = null;
            object resObj = null;
            bool stockMoveFixFlg = true;
            // �p�����[�^��null�̏ꍇ�A
            if (inspectDataObj == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ErrorMsgNull);
                return status;
            }

            ArrayList inspectDataWorkList = inspectDataObj as ArrayList;
            IHandyStockMoveDB iHandyStockMoveDBObj = (IHandyStockMoveDB)MediationHandyStockMoveDB.GetHandyStockMoveDB();
            foreach (HandyInspectDataWork inspectDataWork in inspectDataWorkList)
            {
                // �K�{���͍��ڂ̃`�F�b�N
                if (String.IsNullOrEmpty(inspectDataWork.MachineName.Trim()) ||            // �R���s���[�^��
                    String.IsNullOrEmpty(inspectDataWork.EmployeeCode.Trim()) ||           // �]�ƈ��R�[�h
                    String.IsNullOrEmpty(inspectDataWork.WarehouseCode.Trim()) ||           // �q�ɃR�[�h
                    String.IsNullOrEmpty(inspectDataWork.AcPaySlipNum.Trim()) ||           // �`�[�ԍ�
                    (inspectDataWork.AcPaySlipRowNo <= 0) ||           // �s�ԍ�
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
                    inspectDataWork.AcPaySlipNum.Length > 9 ||
                    inspectDataWork.AcPaySlipRowNo > 9999 ||
                    inspectDataWork.InspectStatus > 99 ||
                    inspectDataWork.InspectCnt > 99999999.99 ||
                    inspectDataWork.MachineName.Length > 20 ||
                    inspectDataWork.EmployeeCode.Length > 9)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inspectDataWork, ErrorMsgParam);
                    return status;
                }

                if (inspectDataWork.ProcDiv != 15 && inspectDataWork.ProcDiv != 16)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inspectDataWork, ErrorMsgParam);
                    return status;
                }

                // �󕥌�����敪(10�F�ʏ�)
                inspectDataWork.AcPayTransCd = 10;

                // �n���f�B�^�[�~�i���敪:�Œ�l(1:�n���f�B�^�[�~�i��)
                inspectDataWork.HandTerminalCode = 1;

                // �����敪���u15�v�̏ꍇ�F30�F�ړ��o�� 
                if (inspectDataWork.ProcDiv == 15)
                {
                    inspectDataWork.AcPaySlipCd = 30;

                }
                else
                {
                    // �����敪���u16�v�̏ꍇ�F31�F�ړ�����
                    inspectDataWork.AcPaySlipCd = 31;
                }
                procDiv = inspectDataWork.ProcDiv;
                if (firstFlg)
                {
                    // �݌ɊǗ��S�̐ݒ�}�X�^�Ǎ�
                    StockMngTtlSt retWork = new StockMngTtlSt();
                    StockMngTtlStAcs stockMngTtlStAcs = new StockMngTtlStAcs();
                    status = stockMngTtlStAcs.Read(out retWork, inspectDataWork.EnterpriseCode);
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // �݌Ɉړ��m��敪�擾
                        stockMoveFixCode = retWork.StockMoveFixCode;
                        moveStockAutoInsDiv = retWork.MoveStockAutoInsDiv;
                        firstFlg = false;
                    }
                    else
                    {
                        // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                        this.WriteLog(inspectDataWork, StockMngTtlErrorMsg);
                        return status;
                    }
                }

                inspectDataWork.StockMoveFixCode = stockMoveFixCode;

                // ���i�f�[�^���X�g�ɃZ�b�g����
                inspectDataList.Add(inspectDataWork);

                // �݌Ɉړ��m��敪���u1�F���׊m��L��v�̏ꍇ�A�����敪���u16�F�ړ����ׁv�̏ꍇ�͓��׊m�菈�����s���܂��B
                if (inspectDataWork.StockMoveFixCode == 1 && inspectDataWork.ProcDiv == 16)
                {
                    // ���i�ς݈ȊO�̖��ׂ��L��ꍇ�͓��׊m��t���O��False�ɂ��A��ɓ��׊m�肵�Ȃ��Ƃ��܂��B
                    if (inspectDataWork.InspectStatus != InspectStatusInspected)
                    {
                        stockMoveFixFlg = false;
                        stockMoveList.Clear();
                    }
                    if (stockMoveFixFlg)
                    {
                        if (searchFirstFlg)
                        {
                            // �����������[�N�N���X
                            stockMoveSlipSearchWork = new StockMoveSlipSearchCondWork();
                            // ��ƃR�[�h
                            stockMoveSlipSearchWork.EnterpriseCode = inspectDataWork.EnterpriseCode;
                            // �݌Ɉړ��`�[�ԍ�
                            stockMoveSlipSearchWork.StockMoveSlipNo = Convert.ToInt32(inspectDataWork.AcPaySlipNum.Trim());
                            // �ړ����(2�F������)�Œ�Ō���
                            int[] moveStatus = { 2 };
                            stockMoveSlipSearchWork.MoveStatus = moveStatus;
                            // �݌Ɉړ��m��敪
                            stockMoveSlipSearchWork.StockMoveFixCode = inspectDataWork.StockMoveFixCode;
                            // �u1�F�o�ɓ`�[�v�Œ�ŏo�ו�����
                            stockMoveSlipSearchWork.SlipDiv = 1;
                            // �����������i�[
                            reqObj = stockMoveSlipSearchWork as object;

                            // �݌Ɉړ��`�[�����擾����
                            status = iHandyStockMoveDBObj.SearchStockMove(reqObj, out resObj);
                            searchFirstFlg = false;
                        }
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            foreach (StockMoveWork stMoveWork in resObj as ArrayList)
                            {
                                // �݌Ɉړ��`�[�ԍ�+�݌Ɉړ��`�[�s�ԍ��Ńq�b�g����
                                if (stMoveWork.StockMoveSlipNo == Convert.ToInt32(inspectDataWork.AcPaySlipNum.Trim()) &&
                                    stMoveWork.StockMoveRowNo == inspectDataWork.AcPaySlipRowNo)
                                {
                                    #region �o�ו��݌Ɉړ��X�V�f�[�^���X�g�쐬
                                    stockWork = new StockMoveWork();

                                    stockWork.AfEnterWarehCode = stMoveWork.AfEnterWarehCode;
                                    stockWork.AfEnterWarehName = stMoveWork.AfEnterWarehName;
                                    stockWork.AfSectionCode = stMoveWork.AfSectionCode;
                                    stockWork.AfSectionGuideSnm = stMoveWork.AfSectionGuideSnm;
                                    stockWork.AfShelfNo = stMoveWork.AfShelfNo;
                                    // ���ד�(�V�X�e�����t)
                                    stockWork.ArrivalGoodsDay = DateTime.Now;
                                    stockWork.AutoGoodsInsDiv = stMoveWork.AutoGoodsInsDiv;
                                    stockWork.BfEnterWarehCode = stMoveWork.BfEnterWarehCode;
                                    stockWork.BfEnterWarehName = stMoveWork.BfEnterWarehName;
                                    stockWork.BfSectionCode = stMoveWork.BfSectionCode;
                                    stockWork.BfSectionGuideSnm = stMoveWork.BfSectionGuideSnm;
                                    stockWork.BfShelfNo = stMoveWork.BfShelfNo;
                                    stockWork.BLGoodsCode = stMoveWork.BLGoodsCode;
                                    stockWork.BLGoodsFullName = stMoveWork.BLGoodsFullName;
                                    stockWork.CreateDateTime = stMoveWork.CreateDateTime;
                                    stockWork.EnterpriseCode = inspectDataWork.EnterpriseCode;
                                    stockWork.FileHeaderGuid = stMoveWork.FileHeaderGuid;
                                    stockWork.GoodsMakerCd = stMoveWork.GoodsMakerCd;
                                    stockWork.GoodsName = stMoveWork.GoodsName;
                                    stockWork.GoodsNameKana = stMoveWork.GoodsNameKana;
                                    stockWork.GoodsNo = stMoveWork.GoodsNo;
                                    // ���͓�(�V�X�e�����t)
                                    stockWork.InputDay = DateTime.Now;
                                    stockWork.ListPriceFl = stMoveWork.ListPriceFl;
                                    stockWork.LogicalDeleteCode = 0;
                                    stockWork.MakerName = stMoveWork.MakerName;
                                    stockWork.MoveCount = stMoveWork.MoveCount;
                                    // �ړ����(9�F���׍ς�)
                                    stockWork.MoveStatus = 9;
                                    stockWork.Outline = stMoveWork.Outline;
                                    stockWork.ReceiveAgentCd = stMoveWork.ReceiveAgentCd;
                                    stockWork.ReceiveAgentNm = stMoveWork.ReceiveAgentNm;
                                    stockWork.ShipAgentCd = stMoveWork.ShipAgentCd;
                                    stockWork.ShipAgentNm = stMoveWork.ShipAgentNm;
                                    stockWork.StockDiv = stMoveWork.StockDiv;
                                    stockWork.StockMoveFixCode = inspectDataWork.StockMoveFixCode;
                                    stockWork.StockMoveFormal = stMoveWork.StockMoveFormal;
                                    stockWork.StockMovePrice = stMoveWork.StockMovePrice;
                                    stockWork.StockMoveRowNo = stMoveWork.StockMoveRowNo;
                                    stockWork.StockMoveSlipNo = stMoveWork.StockMoveSlipNo;
                                    stockWork.StockMvEmpCode = stMoveWork.StockMvEmpCode;
                                    stockWork.StockMvEmpName = stMoveWork.StockMvEmpName;
                                    stockWork.StockUnitPriceFl = stMoveWork.StockUnitPriceFl;
                                    stockWork.SupplierCd = stMoveWork.SupplierCd;
                                    stockWork.SupplierSnm = stMoveWork.SupplierSnm;
                                    stockWork.TaxationDivCd = stMoveWork.TaxationDivCd;
                                    stockWork.UpdAssemblyId1 = stMoveWork.UpdAssemblyId1;
                                    stockWork.UpdAssemblyId2 = stMoveWork.UpdAssemblyId2;
                                    stockWork.UpdateDateTime = stMoveWork.UpdateDateTime;
                                    // �X�V���_�R�[�h(�����D�]�ƈ��R�[�h�̏������_�R�[�h)
                                    stockWork.UpdateSecCd = inspectDataWork.BelongSectionCode;
                                    // �X�V�]�ƈ��R�[�h(�����D�]�ƈ��R�[�h)
                                    stockWork.UpdEmployeeCode = inspectDataWork.EmployeeCode;
                                    stockWork.WarehouseNote1 = stMoveWork.WarehouseNote1;
                                    stockWork.SlipPrintFinishCd = stMoveWork.SlipPrintFinishCd;
                                    stockWork.MoveStockAutoInsDiv = moveStockAutoInsDiv;
                                    stockWork.ShipmentScdlDay = stMoveWork.ShipmentScdlDay;
                                    stockWork.ShipmentFixDay = stMoveWork.ShipmentFixDay;

                                    stockMoveList.Add(stockWork);
                                    #endregion
                                }
                            }
                        }
                    }
                }
            }
            try
            {
                // �݌Ɉړ��m��敪���u1�F���׊m��L��v�A�����敪���u16�F�ړ����ׁv�A�S���ׂ����i�ς݂̏ꍇ�͓��׊m�菈�����s���܂��B
                if (stockMoveFixCode == 1 && procDiv == 16 && stockMoveFixFlg)
                {
                    // �J�X�^���V���A���C�Y�A���C���X�g����
                    CustomSerializeArrayList customSerializeArrayList = new CustomSerializeArrayList();

                    // ���i�A���f�[�^���[�N�N���X���X�g�쐬
                    ArrayList saveGoodsUnitDataWorkList = CreateSaveGoodsUnitDataWorkListArrival(stockMoveList);

                    // �J�X�^���V���A���C�Y�A���C���X�g�ɍ݌Ɉړ��f�[�^���i�[
                    customSerializeArrayList.Add(stockMoveList);
                    // �J�X�^���V���A���C�Y�A���C���X�g�ɏ��i�A���f�[�^��ǉ�
                    if (saveGoodsUnitDataWorkList.Count != 0)
                    {
                        customSerializeArrayList.Add(saveGoodsUnitDataWorkList);
                    }
                    // �J�X�^���V���A���C�Y�A���C���X�g�Ɍ��i�f�[�^���i�[
                    customSerializeArrayList.Add(inspectDataList);
                    // �����[�e�B���O���n�I�u�W�F�N�g
                    object obj = customSerializeArrayList;
                    string msg;

                    IStockMoveDB iStockMoveDB = (IStockMoveDB)MediationStockMoveDB.GetStockMoveDB();
                    // �݌Ɉړ��`�[�o�^����(���׏����ƌ��i�o�^)
                    status = iStockMoveDB.Write(ref obj, out msg);
                }
                // ��ɓ��׏������s��Ȃ��ׁA���i�f�[�^�o�^�����݂̂��s���܂�
                else
                {
                    inspectDataObj = inspectDataList as object;
                    status = iHandyStockMoveDBObj.Write(ref inspectDataObj, 0);
                }

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
        /// <br>Programmer : ���O</br>
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
                if (logObj is HandyStockMoveCondWork)
                {
                    HandyStockMoveCondWork handyStockCondWork = logObj as HandyStockMoveCondWork;
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCode + handyStockCondWork.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + handyStockCondWork.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + handyStockCondWork.MachineName);
                    // �����敪
                    writer.WriteLine(ProcDiv + handyStockCondWork.ProcDiv);
                    // �`�[�ԍ�
                    writer.WriteLine(StockMoveSlipNo + handyStockCondWork.StockMoveSlipNo);
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
                    // �����敪
                    writer.WriteLine(ProcDiv + handyInspectDataWork.ProcDiv);
                    // �݌Ɉړ��`�[�ԍ�
                    writer.WriteLine(StockMoveSlipNo + handyInspectDataWork.AcPaySlipNum);
                    // �݌Ɉړ��s�ԍ�
                    writer.WriteLine(StockMoveSlipNumNo + handyInspectDataWork.AcPaySlipRowNo);
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
                    // ���i�X�e�[�^�X
                    writer.WriteLine(InspectStatus + handyInspectDataWork.InspectStatus);
                }
                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
            
        }

        /// <summary>
        /// ���i�f�[�^���X�g�쐬����
        /// </summary>
        /// <param name="stockMoveList">�݌Ɉړ��f�[�^���X�g</param>
        /// <returns>���i�f�[�^���X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ���i�f�[�^���X�g���쐬���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private ArrayList CreateSaveGoodsUnitDataWorkListArrival(ArrayList stockMoveList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string errMsg;
            ArrayList saveGoodsUnitDataWorkList = new ArrayList();

            GoodsAcs goodsAcs = new GoodsAcs();
            GoodsUnitDataWork goodsUnitDataWork;
            List<GoodsUnitData> goodsUnitDataList = new List<GoodsUnitData>();
            Dictionary<string, GoodsUnitData> goodsUnitDataDic = new Dictionary<string,GoodsUnitData>();

            foreach (StockMoveWork stockMoveWork in stockMoveList)
            {
                goodsUnitDataList = new List<GoodsUnitData>();

                if (goodsUnitDataDic.ContainsKey(stockMoveWork.GoodsMakerCd.ToString("0000") + stockMoveWork.GoodsNo.Trim()) == true)
                {
                    goodsUnitDataList.Add((GoodsUnitData)goodsUnitDataDic[stockMoveWork.GoodsMakerCd.ToString("0000") + stockMoveWork.GoodsNo.Trim()]);
                }
                else
                {
                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    goodsCndtn.EnterpriseCode = stockMoveWork.EnterpriseCode;
                    goodsCndtn.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
                    goodsCndtn.GoodsNo = stockMoveWork.GoodsNo;

                    status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, out goodsUnitDataList, out errMsg);
                    if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                    {
                        goodsUnitDataDic.Add(stockMoveWork.GoodsMakerCd.ToString("0000") + stockMoveWork.GoodsNo.Trim(), goodsUnitDataList[0]);
                    }
                }

                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) && (goodsUnitDataList != null) && (goodsUnitDataList.Count > 0))
                {
                    GoodsUnitData goodsUnitData = goodsUnitDataList[0];

                    if (goodsUnitData.OfferKubun != -1)
                    {
                        // ���i�f�[�^�����[�U�[�E�񋟂̂ǂ��炩�ɑ��݂���ꍇ
                        if (goodsUnitDataList[0].OfferKubun != 0)
                        {
                            // �񋟃f�[�^�̏ꍇ
                            goodsUnitDataWork = CopyToGoodsUnitDataWorkFromGoodsUnitData(goodsUnitDataList[0]);
                            UpdateGoodsUnitDataWork(ref goodsUnitDataWork, stockMoveWork);
                            saveGoodsUnitDataWorkList.Add(goodsUnitDataWork);
                        }
                    }
                }
                else
                {
                    // ���i�f�[�^�����[�U�[�E�񋟗����ɑ��݂��Ȃ��ꍇ
                    goodsUnitDataWork = CreateGoodsUnitDataWork(stockMoveWork);
                    saveGoodsUnitDataWorkList.Add(goodsUnitDataWork);
                }
            }

            return saveGoodsUnitDataWorkList;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(���i�A���f�[�^�����i�A���f�[�^���[�N)
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^</param>
        /// <returns>���i�A���f�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private GoodsUnitDataWork CopyToGoodsUnitDataWorkFromGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            GoodsUnitDataWork goodsUnitDataWork = new GoodsUnitDataWork();

            goodsUnitDataWork.CreateDateTime = goodsUnitData.CreateDateTime;
            goodsUnitDataWork.UpdateDateTime = goodsUnitData.UpdateDateTime;
            goodsUnitDataWork.EnterpriseCode = goodsUnitData.EnterpriseCode;
            goodsUnitDataWork.FileHeaderGuid = goodsUnitData.FileHeaderGuid;
            goodsUnitDataWork.UpdEmployeeCode = goodsUnitData.UpdEmployeeCode;
            goodsUnitDataWork.UpdAssemblyId1 = goodsUnitData.UpdAssemblyId1;
            goodsUnitDataWork.UpdAssemblyId2 = goodsUnitData.UpdAssemblyId2;
            goodsUnitDataWork.LogicalDeleteCode = goodsUnitData.LogicalDeleteCode;
            goodsUnitDataWork.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
            goodsUnitDataWork.GoodsNo = goodsUnitData.GoodsNo;
            goodsUnitDataWork.GoodsName = goodsUnitData.GoodsName;
            goodsUnitDataWork.GoodsNameKana = goodsUnitData.GoodsNameKana;
            goodsUnitDataWork.Jan = goodsUnitData.Jan;
            goodsUnitDataWork.BLGoodsCode = goodsUnitData.BLGoodsCode;
            goodsUnitDataWork.DisplayOrder = goodsUnitData.DisplayOrder;
            goodsUnitDataWork.GoodsRateRank = goodsUnitData.GoodsRateRank;
            goodsUnitDataWork.TaxationDivCd = goodsUnitData.TaxationDivCd;
            goodsUnitDataWork.GoodsNoNoneHyphen = goodsUnitData.GoodsNoNoneHyphen;
            goodsUnitDataWork.OfferDate = goodsUnitData.OfferDate;
            goodsUnitDataWork.GoodsKindCode = goodsUnitData.GoodsKindCode;
            goodsUnitDataWork.GoodsNote1 = goodsUnitData.GoodsNote1;
            goodsUnitDataWork.GoodsNote2 = goodsUnitData.GoodsNote2;
            goodsUnitDataWork.GoodsSpecialNote = goodsUnitData.GoodsSpecialNote;
            goodsUnitDataWork.EnterpriseGanreCode = goodsUnitData.EnterpriseGanreCode;
            goodsUnitDataWork.UpdateDate = goodsUnitData.UpdateDate;
            ArrayList priceWorkList = new ArrayList();
            foreach (GoodsPrice goodsPrice in goodsUnitData.GoodsPriceList)
            {
                priceWorkList.Add(CopyToGoodsPriceUWorkFromGoodsPrice(goodsPrice));
            }
            goodsUnitDataWork.PriceList = priceWorkList;
            ArrayList stockWorkList = new ArrayList();
            foreach (Stock stock in goodsUnitData.StockList)
            {
                stockWorkList.Add(CopyToStockWorkFromStock(stock));
            }
            goodsUnitDataWork.StockList = stockWorkList;

            return goodsUnitDataWork;
        }

        /// <summary>
        /// ���i�f�[�^�X�V����
        /// </summary>
        /// <param name="goodsUnitDataWork">���i�f�[�^���[�N�N���X</param>
        /// <param name="stockMoveWork">�݌Ɉړ��f�[�^���[�N�N���X</param>
        /// <remarks>
        /// <br>Note�@�@�@  : ���i�f�[�^���X�V���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private void UpdateGoodsUnitDataWork(ref GoodsUnitDataWork goodsUnitDataWork, StockMoveWork stockMoveWork)
        {
            goodsUnitDataWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
            goodsUnitDataWork.BLGoodsCode = stockMoveWork.BLGoodsCode;
            goodsUnitDataWork.GoodsName = stockMoveWork.GoodsName;
            goodsUnitDataWork.GoodsNameKana = stockMoveWork.GoodsNameKana;
        }

        /// <summary>
        /// ���i�f�[�^�쐬����
        /// </summary>
        /// <param name="stockMoveWork">�݌Ɉړ��f�[�^</param>
        /// <returns>���i�f�[�^</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ���i�f�[�^���쐬���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private GoodsUnitDataWork CreateGoodsUnitDataWork(StockMoveWork stockMoveWork)
        {
            GoodsUnitDataWork goodsUnitDataWork = new GoodsUnitDataWork();

            goodsUnitDataWork.EnterpriseCode = stockMoveWork.EnterpriseCode;
            goodsUnitDataWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
            goodsUnitDataWork.GoodsNo = stockMoveWork.GoodsNo;
            goodsUnitDataWork.GoodsName = stockMoveWork.GoodsName;
            goodsUnitDataWork.GoodsNameKana = stockMoveWork.GoodsNameKana;
            goodsUnitDataWork.BLGoodsCode = stockMoveWork.BLGoodsCode;
            goodsUnitDataWork.GoodsNoNoneHyphen = GetGoodsNoNoneHyphen(stockMoveWork.GoodsNo);
            ArrayList priceList = new ArrayList();
            priceList.Add(CreateGoodsPriceUWork(stockMoveWork));
            goodsUnitDataWork.PriceList = priceList;

            return goodsUnitDataWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(���i�}�X�^�����i�}�X�^���[�N)
        /// </summary>
        /// <param name="goodsPrice">���i�}�X�^</param>
        /// <returns>���i�}�X�^���[�N</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private GoodsPriceUWork CopyToGoodsPriceUWorkFromGoodsPrice(GoodsPrice goodsPrice)
        {
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

            goodsPriceUWork.CreateDateTime = goodsPrice.CreateDateTime;
            goodsPriceUWork.UpdateDateTime = goodsPrice.UpdateDateTime;
            goodsPriceUWork.EnterpriseCode = goodsPrice.EnterpriseCode;
            goodsPriceUWork.FileHeaderGuid = goodsPrice.FileHeaderGuid;
            goodsPriceUWork.UpdEmployeeCode = goodsPrice.UpdEmployeeCode;
            goodsPriceUWork.UpdAssemblyId1 = goodsPrice.UpdAssemblyId1;
            goodsPriceUWork.UpdAssemblyId2 = goodsPrice.UpdAssemblyId2;
            goodsPriceUWork.LogicalDeleteCode = goodsPrice.LogicalDeleteCode;
            goodsPriceUWork.GoodsMakerCd = goodsPrice.GoodsMakerCd;
            goodsPriceUWork.GoodsNo = goodsPrice.GoodsNo;
            goodsPriceUWork.PriceStartDate = goodsPrice.PriceStartDate;
            goodsPriceUWork.ListPrice = goodsPrice.ListPrice;
            goodsPriceUWork.SalesUnitCost = goodsPrice.SalesUnitCost;
            goodsPriceUWork.StockRate = goodsPrice.StockRate;
            goodsPriceUWork.OpenPriceDiv = goodsPrice.OpenPriceDiv;
            goodsPriceUWork.OfferDate = goodsPrice.OfferDate;
            goodsPriceUWork.UpdateDate = goodsPrice.UpdateDate;

            return goodsPriceUWork;
        }

        /// <summary>
        /// �N���X�����o�R�s�[����(�݌Ƀf�[�^���݌Ƀf�[�^���[�N)
        /// </summary>
        /// <param name="stock">�݌Ƀf�[�^</param>
        /// <returns>�݌Ƀf�[�^���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �N���X�����o���R�s�[���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private StockWork CopyToStockWorkFromStock(Stock stock)
        {
            StockWork stockWork = new StockWork();

            stockWork.CreateDateTime = stock.CreateDateTime;
            stockWork.UpdateDateTime = stock.UpdateDateTime;
            stockWork.EnterpriseCode = stock.EnterpriseCode;
            stockWork.FileHeaderGuid = stock.FileHeaderGuid;
            stockWork.UpdEmployeeCode = stock.UpdEmployeeCode;
            stockWork.UpdAssemblyId1 = stock.UpdAssemblyId1;
            stockWork.UpdAssemblyId2 = stock.UpdAssemblyId2;
            stockWork.LogicalDeleteCode = stock.LogicalDeleteCode;
            stockWork.SectionCode = stock.SectionCode;
            stockWork.WarehouseCode = stock.WarehouseCode;
            stockWork.GoodsMakerCd = stock.GoodsMakerCd;
            stockWork.GoodsNo = stock.GoodsNo;
            stockWork.StockUnitPriceFl = stock.StockUnitPriceFl;
            stockWork.SupplierStock = stock.SupplierStock;
            stockWork.AcpOdrCount = stock.AcpOdrCount;
            stockWork.MonthOrderCount = stock.MonthOrderCount;
            stockWork.SalesOrderCount = stock.SalesOrderCount;
            stockWork.StockDiv = stock.StockDiv;
            stockWork.MovingSupliStock = stock.MovingSupliStock;
            stockWork.ShipmentPosCnt = stock.ShipmentPosCnt;
            stockWork.StockTotalPrice = stock.StockTotalPrice;
            stockWork.LastStockDate = stock.LastStockDate;
            stockWork.LastSalesDate = stock.LastSalesDate;
            stockWork.LastInventoryUpdate = stock.LastInventoryUpdate;
            stockWork.MinimumStockCnt = stock.MinimumStockCnt;
            stockWork.MaximumStockCnt = stock.MaximumStockCnt;
            stockWork.NmlSalOdrCount = stock.NmlSalOdrCount;
            stockWork.SalesOrderUnit = stock.SalesOrderUnit;
            stockWork.StockSupplierCode = stock.StockSupplierCode;
            stockWork.GoodsNoNoneHyphen = stock.GoodsNoNoneHyphen;
            stockWork.WarehouseShelfNo = stock.WarehouseShelfNo;
            stockWork.DuplicationShelfNo1 = stock.DuplicationShelfNo1;
            stockWork.DuplicationShelfNo2 = stock.DuplicationShelfNo2;
            stockWork.PartsManagementDivide1 = stock.PartsManagementDivide1;
            stockWork.PartsManagementDivide2 = stock.PartsManagementDivide2;
            stockWork.StockNote1 = stock.StockNote1;
            stockWork.StockNote2 = stock.StockNote2;
            stockWork.ShipmentCnt = stock.ShipmentCnt;
            stockWork.ArrivalCnt = stock.ArrivalCnt;
            stockWork.StockCreateDate = stock.StockCreateDate;
            stockWork.UpdateDate = stock.UpdateDate;

            return stockWork;
        }

        /// <summary>
        /// �n�C�t�����i�Ԏ擾����
        /// </summary>
        /// <param name="goodsNo">�i��</param>
        /// <returns>�n�C�t�����i��</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : �n�C�t�����i�Ԃ��擾���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private string GetGoodsNoNoneHyphen(string goodsNo)
        {
            string goodsNoNoneHyphen = "";

            // �n�C�t�����폜���܂�
            for (int i = goodsNo.Length - 1; i >= 0; i--)
            {
                if (goodsNo[i].ToString() == "-")
                {
                    goodsNo = goodsNo.Remove(i, 1);
                }
            }

            goodsNoNoneHyphen = goodsNo;
            return goodsNoNoneHyphen;
        }

        /// <summary>
        /// ���i���[�N�N���X�쐬����
        /// </summary>
        /// <param name="stockMoveWork">�݌Ɉړ����[�N�N���X</param>
        /// <returns>���i���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ���i���[�N�N���X���쐬���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private GoodsPriceUWork CreateGoodsPriceUWork(StockMoveWork stockMoveWork)
        {
            GoodsPriceUWork goodsPriceUWork = new GoodsPriceUWork();

            goodsPriceUWork.EnterpriseCode = stockMoveWork.EnterpriseCode;
            goodsPriceUWork.GoodsMakerCd = stockMoveWork.GoodsMakerCd;
            goodsPriceUWork.GoodsNo = stockMoveWork.GoodsNo;
            goodsPriceUWork.PriceStartDate = GetPriceStartDate(stockMoveWork.ShipmentFixDay);
            goodsPriceUWork.ListPrice = stockMoveWork.ListPriceFl;
            goodsPriceUWork.SalesUnitCost = stockMoveWork.StockUnitPriceFl;

            return goodsPriceUWork;
        }

        /// <summary>
        /// ���i�J�n���擾����
        /// </summary>
        /// <param name="dateTime">�o�׊m���</param>
        /// <returns>���i�J�n��</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ���i���[�N�N���X���쐬���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private DateTime GetPriceStartDate(DateTime dateTime)
        {
            try
            {
                //--------------------------------------------------
                // �ʏ�́A�O�񌎎��X�V���̗���
                //--------------------------------------------------
                DateTime prevTotalDay = GetHisTotalDayMonthly();
                if (prevTotalDay != DateTime.MinValue)
                {
                    // �O�񌎎��X�V���̗���
                    return prevTotalDay.AddDays(1);
                }

                //--------------------------------------------------
                // �i���V�K�������Ĉ�x�������X�V�����Ă��Ȃ��悤�ȏꍇ�j����.�����
                //--------------------------------------------------
                DateGetAcs dateGetAcs = DateGetAcs.GetInstance(); // ���t�擾���i
                List<DateTime> startMonthDateList;
                List<DateTime> endMonthDateList;

                CompanyInf companyInf = dateGetAcs.GetCompanyInf();
                if (companyInf != null && companyInf.CompanyBiginDate != 0)
                {
                    dateGetAcs.GetFinancialYearTable(out startMonthDateList, out endMonthDateList);
                    if (startMonthDateList != null && startMonthDateList.Count > 0)
                    {
                        // ��������ŏ��̌��̊J�n��
                        return startMonthDateList[0];
                    }
                }
                dateGetAcs = null;
            }
            catch
            {
            }

            // ���ʏ�͔������Ȃ�����������擾�ł��Ȃ������ꍇ�͊��������Ɠ��l�B
            return dateTime;
        }

        /// <summary>
        /// �O�񌎎��X�V���擾
        /// </summary>
        /// <returns>�O�񌎎��X�V��</returns>
        /// <remarks>
        /// <br>Note�@�@�@  : ���i���[�N�N���X���쐬���܂��B</br>
        /// <br>Programmer  : ���O</br>
        /// <br>Date        : 2017/08/02</br>
        /// </remarks>
        private DateTime GetHisTotalDayMonthly()
        {
            TotalDayCalculator totalDayCalculator = TotalDayCalculator.GetInstance(); // �����`�F�b�N���i

            int status;
            DateTime prevTotalDay;

            // �����Z�o���W���[���̃L���b�V���N���A
            totalDayCalculator.ClearCache();

            // ���|�I�v�V��������
            PurchaseStatus ps;
            ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_StockingPayment);
            if (ps == PurchaseStatus.Contract)
            {
                // ���|�I�v�V��������
                // ���㌎���������A�d�������������̌Â��N���擾
                totalDayCalculator.InitializeHisMonthly();
                status = totalDayCalculator.GetHisTotalDayMonthly(string.Empty, out prevTotalDay);
                if (prevTotalDay == DateTime.MinValue)
                {
                    // ���㌎���������擾
                    status = totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay);
                    if (prevTotalDay == DateTime.MinValue)
                    {
                        // �d�������������擾
                        status = totalDayCalculator.GetHisTotalDayMonthlyAccPay(string.Empty, out prevTotalDay);
                    }
                }
            }
            else
            {
                // ���|�I�v�V�����Ȃ�
                // ���㌎���������擾
                totalDayCalculator.InitializeHisMonthlyAccRec();
                status = totalDayCalculator.GetHisTotalDayMonthlyAccRec(string.Empty, out prevTotalDay);
            }

            totalDayCalculator = null;

            return prevTotalDay;
        }
        #endregion
    }
}
