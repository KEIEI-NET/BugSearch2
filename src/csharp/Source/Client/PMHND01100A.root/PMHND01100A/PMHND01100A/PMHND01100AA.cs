//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j�A�N�Z�X�N���X
// �v���O�����T�v   : �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j�A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370074-00 �쐬�S�� : 杍^
// �� �� ��  2017/08/11  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11475093-00 �쐬�S�� : ���R
// �� �� ��  2018/09/14  �C�����e : Redmine#49751 ���i�Ǘ� �݌ɓ��ɍX�VPKG���ّΉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11570136-00 �쐬�S�� : ��
// �� �� ��  2019/11/13  �C�����e : �n���f�B�U������
//----------------------------------------------------------------------------//

using System;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j�A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 杍^</br>
    /// <br>Date       : 2017/08/11</br>
    /// <br>Update Note: Redmine#49751 ���i�Ǘ� �݌ɓ��ɍX�VPKG���ّΉ�</br>
    /// <br>Programmer : ���R</br>
    /// <br>Date       : 2018/09/14</br>
    /// </remarks>
    public class HandyStockSupplierAcs
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
        private const string LogPath = @"\Log\PMHND";
        /// <summary>�f�t�H���g���O�t�@�C������</summary>
        private const string PgId = "PMHND01100A_";
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
        /// <summary>�������_�R�[�h</summary>
        private const string BelongSectionCode = "�������_�R�[�h:";
        
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
        /// <summary>�X�V�敪</summary>
        private const string UpdateDiv = "�X�V�敪:";
        /// <summary>�d�����גʔ�</summary>
        private const string StockSlipDtlNum = "�d�����גʔ�:";
        /// <summary>�����敪</summary>
        private const string OpDiv = "�����敪:";
        /// <summary>������R�[�h</summary>
        private const string UOESupplierCd = "������R�[�h:";
        /// <summary>���ɋ敪</summary>
        private const string WarehousingDivCd = "���ɋ敪:";
        /// <summary>�I�����C���ԍ�</summary>
        private const string OnlineNo = "�I�����C���ԍ�:";
        /// <summary>UOE�����ԍ�</summary>
        private const string UOESalesOrderNo = "UOE�����ԍ�:";

        /// <summary>�p�����[�^null���b�Z�[�W</summary>
        private const string ConditionsError = "�o�^������null�ł��B";
        /// <summary>�p�����[�^�G���[���b�Z�[�W</summary>
        private const string ParametersError = "���̓p�����[�^�G���[���������܂����B";

        /// <summary>BO�`�[�ԍ�1</summary>
        private const string EnterUpdDivBO1SlipNo = "��ݺ޳ż BO1";
        /// <summary>BO�`�[�ԍ�2</summary>
        private const string EnterUpdDivBO2SlipNo = "��ݺ޳ż BO2";
        /// <summary>BO�`�[�ԍ�3</summary>
        private const string EnterUpdDivBO3SlipNo = "��ݺ޳ż BO3";
        /// <summary>Ұ��</summary>
        private const string EnterUpdDivMakerSlipNo = "��ݺ޳ż Ұ��";
        /// <summary>EO</summary>
        private const string EnterUpdDivEOSlipNo = "��ݺ޳ż EO";
        /// <summary>UOE���_�`�[�ԍ�</summary>
        private const string EnterUpdDivSecSlipNo = "��ݺ޳ż ����";

        /// <summary>���_</summary>
        private const int WarehousingSectionDiv = 1;
        /// <summary>BO1</summary>
        private const int WarehousingBo1Div = 2;
        /// <summary>BO2</summary>
        private const int WarehousingBo2Div = 3;
        /// <summary>BO3</summary>
        private const int WarehousingBo3Div = 4;
        /// <summary>���[�J�[</summary>
        private const int WarehousingMakerDiv = 5;
        /// <summary>EO</summary>
        private const int WarehousingEoDiv = 6;

        /// <summary>�d����BO�`�[�ԍ��ҏW�p-F</summary>
        private const string DuplicationSlipNoF = "-F";
        /// <summary>�d����BO�`�[�ԍ��ҏW�p-F2</summary>
        private const string DuplicationSlipNoF2 = "-F2";
        /// <summary>�d����BO�`�[�ԍ��ҏW�p-F3</summary>
        private const string DuplicationSlipNoF3 = "-F3";
        /// <summary>�f�B�N�V���i���[�p</summary>
        private const string Separator = "|";

        /// <summary>���ɍX�V�敪�i���_�j�u0:�����Ɂv</summary>
        private const int EnterUpdDivSecData0 = 0;
        /// <summary>���ɍX�V�敪�iBO1�j�u0:�����Ɂv</summary>
        private const int EnterUpdDivBO1Data0 = 0;
        /// <summary>���ɍX�V�敪�iBO2�j�u0:�����Ɂv</summary>
        private const int EnterUpdDivBO2Data0 = 0;
        /// <summary>���ɍX�V�敪�iBO3�j�u0:�����Ɂv</summary>
        private const int EnterUpdDivBO3Data0 = 0;
        /// <summary>���ɍX�V�敪�iҰ���j�u0:�����Ɂv</summary>
        private const int EnterUpdDivMakerData0 = 0;
        /// <summary>���ɍX�V�敪�iEO�j�u0:�����Ɂv</summary>
        private const int EnterUpdDivEOData0 = 0;
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
        public HandyStockSupplierAcs()
        {
            LogLockObj = new object();
        }
        # endregion

        # region [�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�o�^]
        /// <summary>
        /// �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j�̓o�^����
        /// </summary>
        /// <param name="inspectDataAddListObj">�o�^�p�p�����[�^�I�u�W�F�N�g</param>
        /// <returns>�X�e�[�^�X[0: ����A 0�ȊO: �G���[]</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j��o�^���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// <br>Update Note: Redmine#49751 ���i�Ǘ� �݌ɓ��ɍX�VPKG���ّΉ�</br>
        /// <br>Programmer : ���R</br>
        /// <br>Date       : 2018/09/14</br>
        /// <br>Update Note: �n���f�B�U������</br>
        /// <br>Programmer : ��</br>
        /// <br>Date       : 2019/11/13</br>
        /// </remarks>
        public int WriteHandyStockSupplier(ref object inspectDataAddListObj)
        {
            // --- ADD 2019/11/13 ---------->>>>>
            // �����敪���̃f�B�N�V���i����`
            Dictionary<int, ArrayList> OpDivList = new Dictionary<int, ArrayList>();
            // --- ADD 2019/11/13 ----------<<<<<

            int status = StatusError;

            // �o�^�p�p�����[�^�f�[�^���Ȃ��ꍇ
            if (inspectDataAddListObj == null)
            {
                // ���O�o�͂��܂��B
                this.WriteLog(null, ConditionsError);
                return status;
            }

            ArrayList inspectDataAddList = inspectDataAddListObj as ArrayList;
            // �X�V�敪�t���O
            bool updateDivFlg = true;
            foreach (InspectDataAddWork inspectDataAddParamWork in inspectDataAddList)
            {
                // �K�{���͍��ڂ̃`�F�b�N
                // �R���s���[�^��
                if (String.IsNullOrEmpty(inspectDataAddParamWork.MachineName.Trim())
                    // �]�ƈ��R�[�h
                  || String.IsNullOrEmpty(inspectDataAddParamWork.EmployeeCode.Trim())
                    // ��ƃR�[�h
                  || String.IsNullOrEmpty(inspectDataAddParamWork.EnterpriseCode.Trim())
                    // �q�ɃR�[�h
                  //|| String.IsNullOrEmpty(inspectDataAddParamWork.WarehouseCode.Trim()) // DEL ���R 2018/09/14 Redmine#49751 ���i�Ǘ� �݌ɓ��ɍX�VPKG���ّΉ�
                    // ����.�����敪���u1,2�v�ȊO�̏ꍇ�AST_ERR(-1)��ԋp���܂��B
                  || (inspectDataAddParamWork.OpDiv != 1 && inspectDataAddParamWork.OpDiv != 2)
                    // ���[�J�[�R�[�h
                  || (inspectDataAddParamWork.GoodsMakerCd <= 0)
                    // ������R�[�h
                  || (inspectDataAddParamWork.UOESupplierCd <= 0)
                    // �d�����גʔ�
                  || (inspectDataAddParamWork.StockSlipDtlNum <= 0)
                    // ����.���ɋ敪���u1:���_ 2:BO1 3:BO2 4:BO3 5:Ұ�� 6�FEO�v�ȊO�̏ꍇ�AST_ERR(-1)��ԋp���܂��B
                  || (inspectDataAddParamWork.WarehousingDivCd != 1 && inspectDataAddParamWork.WarehousingDivCd != 2
                      && inspectDataAddParamWork.WarehousingDivCd != 3 && inspectDataAddParamWork.WarehousingDivCd != 4
                      && inspectDataAddParamWork.WarehousingDivCd != 5 && inspectDataAddParamWork.WarehousingDivCd != 6)
                    // ����.�X�V�敪���u0,1,2,3,9�v�ȊO�̏ꍇ�AST_ERR(-1)��ԋp���܂��B
                  || ((inspectDataAddParamWork.UpdateDiv != 0)
                      && (inspectDataAddParamWork.UpdateDiv != 1)
                      && (inspectDataAddParamWork.UpdateDiv != 2)
                      && (inspectDataAddParamWork.UpdateDiv != 3)
                      && (inspectDataAddParamWork.UpdateDiv != 9))
                    // ���i�ԍ�
                  || String.IsNullOrEmpty(inspectDataAddParamWork.GoodsNo.Trim()))
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inspectDataAddParamWork, ParametersError);
                    return status;
                }

                // ���̃`�F�b�N
                if (inspectDataAddParamWork.GoodsMakerCd > 999999
                    || inspectDataAddParamWork.GoodsNo.Length > 40
                    // ---UPD ���R 2018/09/14 Redmine#49751 ���i�Ǘ� �݌ɓ��ɍX�VPKG���ّΉ� ------>>>>>
                    //|| inspectDataAddParamWork.WarehouseCode.Length > 6
                    || ((!String.IsNullOrEmpty(inspectDataAddParamWork.WarehouseCode)) && (inspectDataAddParamWork.WarehouseCode.Length > 6))
                    // ---UPD ���R 2018/09/14 Redmine#49751 ���i�Ǘ� �݌ɓ��ɍX�VPKG���ّΉ� ------<<<<<
                    || inspectDataAddParamWork.InspectStatus > 99
                    || inspectDataAddParamWork.InspectCode > 99
                    || inspectDataAddParamWork.InspectCnt > 99999999.99
                    || inspectDataAddParamWork.MachineName.Length > 80
                    || inspectDataAddParamWork.EmployeeCode.Length > 9)
                {
                    // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                    this.WriteLog(inspectDataAddParamWork, ParametersError);
                    return status;
                }

                if (inspectDataAddParamWork.UpdateDiv != 2)
                {
                    updateDivFlg = false;
                }

                // --- ADD 2019/11/13 ---------->>>>>
                // OpDiv�����X�g�ɖ����ꍇ�͍쐬
                if (!OpDivList.ContainsKey(inspectDataAddParamWork.OpDiv))
                {
                    ArrayList opDivArrayList = new ArrayList();
                    OpDivList.Add(inspectDataAddParamWork.OpDiv, opDivArrayList);
                }
                // ���X�g�Ɍ��݂̍s��ǉ�
                OpDivList[inspectDataAddParamWork.OpDiv].Add(inspectDataAddParamWork);
                // --- ADD 2019/11/13 ----------<<<<<
            }

            // �S�ă��R�[�h.�X�V�敪���u 2�F�����ׁv�̏ꍇ�AST_NFOUND(4)��ԋp���܂��B
            if (updateDivFlg)
            {
                status = StatusNotFound;
                return status;
            }

            try
            {
                // --- ADD 2019/11/13 ---------->>>>>
                // �����̏����敪���l�������`�ɉ���
                ArrayList resultArrayList = new ArrayList();
                foreach(KeyValuePair<int,ArrayList> item in OpDivList){
                    ArrayList targetList = item.Value;
                    // --- ADD 2019/11/13 ----------<<<<<

                    // ��������ݒ肵�܂��B
                    UOEStockUpdSearch uoeStockUpdSearch = new UOEStockUpdSearch();
                    // �]�ƈ��R�[�h
                    // --- MOD 2019/11/13 ---------->>>>>
                    //uoeStockUpdSearch.EnterpriseCode = ((InspectDataAddWork)inspectDataAddList[0]).EnterpriseCode;
                    uoeStockUpdSearch.EnterpriseCode = ((InspectDataAddWork)targetList[0]).EnterpriseCode;
                    // --- MOD 2019/11/13 ----------<<<<<
                    // �������_�R�[�h
                    // --- MOD 2019/11/13 ---------->>>>>
                    //uoeStockUpdSearch.SectionCode = ((InspectDataAddWork)inspectDataAddList[0]).BelongSectionCode;
                    uoeStockUpdSearch.SectionCode = ((InspectDataAddWork)targetList[0]).BelongSectionCode;
                    // --- MOD 2019/11/13 ----------<<<<<

                    // --- MOD 2019/11/13 ---------->>>>>
                    // �����敪
                    //if (((InspectDataAddWork)inspectDataAddList[0]).OpDiv == 1)
                    //{
                    //    // ����.�����敪���u1:�݌Ɉꊇ���v�̏ꍇ
                    //    uoeStockUpdSearch.ProcDiv = 0;
                    //}
                    //else
                    //{
                    //    // ����.�����敪���u 2:���̑��v�̏ꍇ
                    //    uoeStockUpdSearch.ProcDiv = 1;
                    //}
                    if (item.Key == 1)
                    {
                        // ����.�����敪���u1:�݌Ɉꊇ���v�̏ꍇ
                        uoeStockUpdSearch.ProcDiv = 0;
                    }
                    else
                    {
                        // ����.�����敪���u 2:���̑��v�̏ꍇ
                        uoeStockUpdSearch.ProcDiv = 1;
                    }
                    // --- MOD 2019/11/13 ----------<<<<<
                    // �����R�[�h
                    // --- MOD 2019/11/13 ---------->>>>>
                    //uoeStockUpdSearch.UOESupplierCd = ((InspectDataAddWork)inspectDataAddList[0]).UOESupplierCd;
                    uoeStockUpdSearch.UOESupplierCd = ((InspectDataAddWork)targetList[0]).UOESupplierCd;
                    // --- MOD 2019/11/13 ----------<<<<<

                    // �݌ɓ��ɍX�V�A�N�Z�X�e��f�[�^��荞��
                    PMUOE01203AA pmUOE01203AA = new PMUOE01203AA(uoeStockUpdSearch.EnterpriseCode, uoeStockUpdSearch.SectionCode, out status);

                    // �݌ɓ��ɍX�V�A�N�Z�X���������s�ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // ---ADD ���R 2018/09/14 Redmine#49751 ���i�Ǘ� �݌ɓ��ɍX�VPKG���ّΉ� ------>>>>>
                    // �݌Ɉꊇ�i�ԋ敪
                    UOESettingAcs uoeSettingAcs = new UOESettingAcs();
                    UOESetting uoeSetting = null;
                    int uoeStatus = uoeSettingAcs.Read(out uoeSetting, uoeStockUpdSearch.EnterpriseCode, uoeStockUpdSearch.SectionCode);
                    if (uoeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        pmUOE01203AA.StockBlnktPrtNoDiv = uoeSetting.StockBlnktPrtNoDiv;           // �݌Ɉꊇ�i�ԋ敪
                    }
                    else
                    {
                        status = StatusError;
                        return status;
                    }
                    // ---ADD ���R 2018/09/14 Redmine#49751 ���i�Ǘ� �݌ɓ��ɍX�VPKG���ّΉ� ------<<<<<

                    // UOE�����f�[�^��񌟍�����
                    status = pmUOE01203AA.SetSearchDataForHandy(uoeStockUpdSearch);

                    // UOE�����f�[�^��񌟍��������^�C���A�E�g�ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        // UOE�����f�[�^��񌟍��������^�C���A�E�g�ꍇ
                        if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                        {
                            status = StatusTimeout;
                            return status;
                        }
                        // UOE�����f�[�^�����擾���s�ꍇ
                        else
                        {
                            status = StatusError;
                            return status;
                        }
                    }


                    // �X�V�敪��ݒ肵�܂��B
                    // --- MOD 2019/11/13 ---------->>>>>
                    //status = pmUOE01203AA.SetUpdateDivForHandy(inspectDataAddList);
                    status = pmUOE01203AA.SetUpdateDivForHandy(targetList);
                    // --- MOD 2019/11/13 ----------<<<<<

                    // �X�V�敪��ݒ莸�s�̏ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // ���ɍX�V�p�f�[�^����������
                    string msg = string.Empty;
                    object uoeStcUpdDataListObj = null;
                    status = pmUOE01203AA.DecisionDataForHandy(out uoeStcUpdDataListObj, out msg);

                    // ���ɍX�V�p�f�[�^���������s�̏ꍇ
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusError;
                        return status;
                    }

                    // ���ɍX�V����
                    IHandyStockSupplierDB IHandyStockSupplierDBAdapter = MediationHandyStockSupplierDB.GetHandyStockSuppliersDB();
                    // --- MOD 2019/11/13 ---------->>>>>
                    //status = IHandyStockSupplierDBAdapter.WriteStockSupplier(ref inspectDataAddListObj, ref uoeStcUpdDataListObj);
                    object inspectDataAddObj = (object)targetList;
                    status = IHandyStockSupplierDBAdapter.WriteStockSupplier(ref inspectDataAddObj, ref uoeStcUpdDataListObj);
                    // --- MOD 2019/11/13 ----------<<<<<

                    // ���ɍX�V����������̏ꍇ
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        status = StatusNomal;
                    }
                    // ���ɍX�V�������^�C���A�E�g�ꍇ
                    else if (status == (int)ConstantManagement.DB_Status.ctDB_SQLCMD_TIMEOUT)
                    {
                        status = StatusTimeout;
                    }
                    // ���ɍX�V���s�ꍇ
                    else
                    {
                        status = StatusError;
                    }
                    // --- ADD 2019/11/13 ---------->>>>>
                    resultArrayList.AddRange(targetList);
                }
                // ���̕ϐ��֍Đݒ�
                inspectDataAddListObj = (object)resultArrayList;
                // --- ADD 2019/11/13 ----------<<<<<
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

        # region [�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ���o����]
        /// <summary>
        /// �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ���o����
        /// </summary>
        /// <param name="paraHandyStockSupplierCondObj">�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ���o���o�������X�g</param>
        /// <param name="resultHandyStockSupplierObj">�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ���o���ʃ��X�g</param>
        /// <returns>�X�e�[�^�X[0: ����, 4:������Ȃ��A5:�^�C���A�E�g -1: �G���[]</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j���ꗗ���o���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyStockSupplierList(ref object paraHandyStockSupplierCondObj, out object resultHandyStockSupplierObj)
        {
            int status = StatusError;
            resultHandyStockSupplierObj = new object();

            HandyUOEOrderListParamWork handyUOEOrderListParamWorkData = paraHandyStockSupplierCondObj as HandyUOEOrderListParamWork;

            // �K�{���͍��ڂ̃`�F�b�N
            // �R���s���[�^��
            if (String.IsNullOrEmpty(handyUOEOrderListParamWorkData.MachineName.Trim())
                // �]�ƈ��R�[�h
              || String.IsNullOrEmpty(handyUOEOrderListParamWorkData.EmployeeCode.Trim())
                // ����.�����敪���u1,2�v�ȊO�̏ꍇ�AST_ERR(-1)��ԋp���܂��B
              || (handyUOEOrderListParamWorkData.OpDiv != 1 && handyUOEOrderListParamWorkData.OpDiv != 2))
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(handyUOEOrderListParamWorkData, ParametersError);
                return status;
            }

            try
            {
                // �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ���o�����[�g�Ăяo��
                byte[] condByte = XmlByteSerializer.Serialize(handyUOEOrderListParamWorkData);

                object stockSupplierListObj = null;
                IHandyStockSupplierDB iHandyStockSupplierDBAdapter = MediationHandyStockSupplierDB.GetHandyStockSuppliersDB();
                status = iHandyStockSupplierDBAdapter.SearchStockSupplierList(condByte, out stockSupplierListObj);

                // �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ���𐳏�擾����ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    ArrayList retList = stockSupplierListObj as ArrayList;
                    // �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ���𐮗����܂��B
                    ArrayList htapRetList = this.CreateHandyStockSupplierList(retList);
                    resultHandyStockSupplierObj = (object)htapRetList;
                }
                // �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ��񂪌�����Ȃ��ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ���Ǎ����̃^�C���A�E�g�ꍇ
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

        # region [�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_���ג��o����]
        /// <summary>
        /// �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_���ג��o����
        /// </summary>
        /// <param name="paraHandyStockSupplierCondObj">�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ���o���o�������X�g</param>
        /// <param name="resultHandyStockSupplierObj">�n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_�ꗗ���o���ʃ��X�g</param>
        /// <returns>�X�e�[�^�X[0: ����, 4:������Ȃ��A5:�^�C���A�E�g -1: �G���[]</returns>
        /// <remarks>
        /// <br>Note       : �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_���׏��𒊏o���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        public int SearchHandyStockSupplierSlipNum(ref object paraHandyStockSupplierCondObj, out object resultHandyStockSupplierObj)
        {
            int status = StatusError;
            resultHandyStockSupplierObj = new object();

            HandyUOEOrderDtlParamWork handyUOEOrderDtlParamWorkData = paraHandyStockSupplierCondObj as HandyUOEOrderDtlParamWork;

            // �K�{���͍��ڂ̃`�F�b�N
            // �R���s���[�^��
            if (String.IsNullOrEmpty(handyUOEOrderDtlParamWorkData.MachineName.Trim())
                // �]�ƈ��R�[�h
              || String.IsNullOrEmpty(handyUOEOrderDtlParamWorkData.EmployeeCode.Trim())
                // ����.�����敪���u11�v�ȊO�̏ꍇ�AST_ERR(-1)��ԋp���܂��B
              || (handyUOEOrderDtlParamWorkData.OpDiv != 11)
                // ����.���ɋ敪���u1:���_ 2:BO1 3:BO2 4:BO3 5:Ұ�� 6�FEO�v�ȊO�̏ꍇ�AST_ERR(-1)��ԋp���܂��B
              || (handyUOEOrderDtlParamWorkData.WarehousingDivCd != 1 && handyUOEOrderDtlParamWorkData.WarehousingDivCd != 2
                  && handyUOEOrderDtlParamWorkData.WarehousingDivCd != 3 && handyUOEOrderDtlParamWorkData.WarehousingDivCd != 4
                  && handyUOEOrderDtlParamWorkData.WarehousingDivCd != 5 && handyUOEOrderDtlParamWorkData.WarehousingDivCd != 6)
                // �I�����C���ԍ�
              || (handyUOEOrderDtlParamWorkData.OnlineNo <= 0)
                // UOE�����ԍ�
              || (handyUOEOrderDtlParamWorkData.UOESalesOrderNo <= 0))
            {
                // �G���[���b�Z�[�W�Ɉ����̖��O�ƒl�����O�o�͂��܂��B
                this.WriteLog(handyUOEOrderDtlParamWorkData, ParametersError);
                return status;
            }

            try
            {
                // �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_���ג��o�����[�g�Ăяo��
                byte[] condByte = XmlByteSerializer.Serialize(handyUOEOrderDtlParamWorkData);

                object stockSupplierDtlObj = null;
                IHandyStockSupplierDB iHandyStockSupplierDBAdapter = MediationHandyStockSupplierDB.GetHandyStockSuppliersDB();
                status = iHandyStockSupplierDBAdapter.SearchHandyStockSupplierSlipNum(condByte, out stockSupplierDtlObj);

                // �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_���׏��𐳏�擾����ꍇ
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    resultHandyStockSupplierObj = stockSupplierDtlObj;
                }
                // �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_���׏�񂪌�����Ȃ��ꍇ
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = StatusNotFound;
                }
                // �n���f�B�^�[�~�i���݌Ɏd���i���ɍX�V�j_���׏��Ǎ����̃^�C���A�E�g�ꍇ
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
        /// UOE���ɍX�V���C���f�[�^�쐬
        /// </summary>
        /// <param name="arrayList">UOE�����f�[�^���X�g</param>
        /// <remarks>
        /// <returns>UOE���ɍX�V���C���f�[�^</returns>
        /// <br>Note       : UOE�����f�[�^����UOE���ɍX�V���C���f�[�^���擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private ArrayList CreateHandyStockSupplierList(ArrayList arrayList)
        {
            ArrayList retArrayList = new ArrayList();
            HandyUOEOrderListWork handyUOEOrderListWork = null;
            HandyUOEOrderResultListWork handyUOEOrderResultListWork = null;
            Dictionary<string, string> resultWorkDic = new Dictionary<string, string>();
            string dicKey = string.Empty;
 
            for (int index = 0; index <= arrayList.Count - 1; index++)
            {
                handyUOEOrderListWork = (HandyUOEOrderListWork)arrayList[index];

                // �d����BO�`�[�ԍ��ҏW����
                this.UpdBOSlipNo(ref handyUOEOrderListWork);

                #region UOE���_�`�[�ԍ�
                if (handyUOEOrderListWork.EnterUpdDivSec == EnterUpdDivSecData0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingSectionDiv;

                    if (string.IsNullOrEmpty(handyUOEOrderListWork.UOESectionSlipNo.Trim()))
                    {
                        handyUOEOrderResultListWork.SlipNo = EnterUpdDivSecSlipNo;
                    }
                    else
                    {
                        handyUOEOrderResultListWork.SlipNo = handyUOEOrderListWork.UOESectionSlipNo;
                    }

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion

                #region BO�`�[�ԍ�1
                if (handyUOEOrderListWork.EnterUpdDivBO1 == EnterUpdDivBO1Data0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingBo1Div;

                    if (string.IsNullOrEmpty(handyUOEOrderListWork.BOSlipNo1.Trim()))
                    {
                        handyUOEOrderResultListWork.SlipNo = EnterUpdDivBO1SlipNo;
                    }
                    else
                    {
                        handyUOEOrderResultListWork.SlipNo = handyUOEOrderListWork.BOSlipNo1;
                    }

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion

                #region BO�`�[�ԍ�2
                if (handyUOEOrderListWork.EnterUpdDivBO2 == EnterUpdDivBO2Data0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingBo2Div;

                    if (string.IsNullOrEmpty(handyUOEOrderListWork.BOSlipNo2.Trim()))
                    {
                        handyUOEOrderResultListWork.SlipNo = EnterUpdDivBO2SlipNo;
                    }
                    else
                    {
                        handyUOEOrderResultListWork.SlipNo = handyUOEOrderListWork.BOSlipNo2;
                    }

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion

                #region BO�`�[�ԍ�3
                if (handyUOEOrderListWork.EnterUpdDivBO3 == EnterUpdDivBO3Data0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingBo3Div;

                    if (string.IsNullOrEmpty(handyUOEOrderListWork.BOSlipNo3.Trim()))
                    {
                        handyUOEOrderResultListWork.SlipNo = EnterUpdDivBO3SlipNo;
                    }
                    else
                    {
                        handyUOEOrderResultListWork.SlipNo = handyUOEOrderListWork.BOSlipNo3;
                    }

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion

                #region Ұ��
                if (handyUOEOrderListWork.EnterUpdDivMaker == EnterUpdDivMakerData0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingMakerDiv;
                    handyUOEOrderResultListWork.SlipNo = EnterUpdDivMakerSlipNo;

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion

                #region EO
                if (handyUOEOrderListWork.EnterUpdDivEO == EnterUpdDivEOData0)
                {
                    handyUOEOrderResultListWork = new HandyUOEOrderResultListWork();
                    handyUOEOrderResultListWork.OnlineNo = handyUOEOrderListWork.OnlineNo;
                    handyUOEOrderResultListWork.UoeRemark1 = handyUOEOrderListWork.UoeRemark1;
                    handyUOEOrderResultListWork.UOESalesOrderNo = handyUOEOrderListWork.UOESalesOrderNo;
                    handyUOEOrderResultListWork.WarehousingDivCd = WarehousingEoDiv;
                    handyUOEOrderResultListWork.SlipNo = EnterUpdDivEOSlipNo;

                    dicKey = this.GetDicKey(handyUOEOrderResultListWork.OnlineNo, handyUOEOrderResultListWork.UOESalesOrderNo, handyUOEOrderResultListWork.SlipNo);

                    if (!resultWorkDic.ContainsKey(dicKey))
                    {
                        retArrayList.Add(handyUOEOrderResultListWork);
                        resultWorkDic.Add(dicKey, string.Empty);
                    }
                }
                #endregion
            }

            return retArrayList;
        }

        /// <summary>
        /// �d����BO�`�[�ԍ��f�B�N�V���i���L�[�̍쐬����
        /// </summary>
        /// <param name="onlineNo">�I�����C���ԍ�</param>
        /// <param name="uoeSalesOrderNo">UOE�����ԍ�</param>
        /// <param name="slipNo">�`�[�ԍ�</param>
        /// <remarks>
        /// <br>Note       : �d����BO�`�[�ԍ��f�B�N�V���i���L�[�̍쐬�������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private string GetDicKey(int onlineNo, int uoeSalesOrderNo, string slipNo)
        {
            string dicKey = string.Empty;

            StringBuilder sb = new StringBuilder();
            // �I�����C���ԍ�
            sb.Append(onlineNo.ToString());
            sb.Append(Separator);
            // UOE�����ԍ�
            sb.Append(uoeSalesOrderNo.ToString());
            sb.Append(Separator);
            // �`�[�ԍ�
            sb.Append(slipNo);

            dicKey = sb.ToString();
            return dicKey;
        }

        /// <summary>
        /// �d����BO�`�[�ԍ��ҏW����
        /// </summary>
        /// <param name="handyUOEOrderListWork">UOE�����f�[�^</param>
        /// <remarks>
        /// <br>Note       : �d����BO�`�[�ԍ��ɂ���āA�ʐMID��āA�u-F�v�̕ҏW�������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/08/11</br>
        /// </remarks>
        private void UpdBOSlipNo(ref HandyUOEOrderListWork handyUOEOrderListWork)
        {
            // UOE�`�[�ԍ�
            string tempUOESectionSlipNo = handyUOEOrderListWork.UOESectionSlipNo;
            // BO1�`�[�ԍ�
            string tempBOSlipNo1 = handyUOEOrderListWork.BOSlipNo1;
            // BO2�`�[�ԍ�
            string tempBOSlipNo2 = handyUOEOrderListWork.BOSlipNo2;
            // BO3�`�[�ԍ�
            string tempBOSlipNo3 = handyUOEOrderListWork.BOSlipNo3;

            switch (handyUOEOrderListWork.CommAssemblyId.Trim())
            {
                // �z���_ e-Parts�u�ʐMID�F0502�v�̏ꍇ
                case EnumUoeConst.ctCommAssemblyId_0502:
                    {
                        // BO1�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            handyUOEOrderListWork.BOSlipNo1 = tempBOSlipNo1 + DuplicationSlipNoF;
                        }

                        // BO2�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo))
                            {
                                handyUOEOrderListWork.BOSlipNo2 = tempBOSlipNo2 + DuplicationSlipNoF2;
                            }
                        }

                        // BO3�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) || tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                handyUOEOrderListWork.BOSlipNo3 = tempBOSlipNo3 + DuplicationSlipNoF3;
                            }
                        }

                        break;
                    }
                // �z���_ e-Parts�u�ʐMID�F0502�v�ȊO�̏ꍇ
                default:
                    {
                        // BO1�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo1) && !string.IsNullOrEmpty(tempBOSlipNo1.Trim()))
                        {
                            if (tempBOSlipNo1.Equals(tempUOESectionSlipNo))
                            {
                                handyUOEOrderListWork.BOSlipNo1 = tempBOSlipNo1 + DuplicationSlipNoF;
                            }
                        }

                        // BO2�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo2) && !string.IsNullOrEmpty(tempBOSlipNo2.Trim()))
                        {
                            if (tempBOSlipNo2.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo2.Equals(tempBOSlipNo1))
                            {
                                handyUOEOrderListWork.BOSlipNo2 = tempBOSlipNo2 + DuplicationSlipNoF2;
                            }
                        }

                        // BO3�`�[�ԍ�������ꍇ
                        if (!string.IsNullOrEmpty(tempBOSlipNo3) && !string.IsNullOrEmpty(tempBOSlipNo3.Trim()))
                        {
                            if (tempBOSlipNo3.Equals(tempUOESectionSlipNo) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo1) ||
                                tempBOSlipNo3.Equals(tempBOSlipNo2))
                            {
                                handyUOEOrderListWork.BOSlipNo3 = tempBOSlipNo3 + DuplicationSlipNoF3;
                            }
                        }

                        break;
                    }
            }
        }


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
                if (logObj is InspectDataAddWork)
                {
                    InspectDataAddWork inspectDataAddWork = logObj as InspectDataAddWork;
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCod + inspectDataAddWork.EnterpriseCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + inspectDataAddWork.MachineName);
                    // �������_�R�[�h
                    writer.WriteLine(BelongSectionCode + inspectDataAddWork.BelongSectionCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + inspectDataAddWork.EmployeeCode);
                    // ���i���[�J�[�R�[�h
                    writer.WriteLine(GoodsMakerCd + inspectDataAddWork.GoodsMakerCd);
                    // ���i�ԍ�
                    writer.WriteLine(GoodsNo + inspectDataAddWork.GoodsNo);
                    // �q�ɃR�[�h
                    writer.WriteLine(WarehouseCode + inspectDataAddWork.WarehouseCode);
                    // ���i�X�e�[�^�X
                    writer.WriteLine(InspectStatus + inspectDataAddWork.InspectStatus);
                    // ���i�敪
                    writer.WriteLine(InspectCode + inspectDataAddWork.InspectCode);
                    // ���i��
                    writer.WriteLine(InspectCnt + inspectDataAddWork.InspectCnt);
                    // �X�V�敪
                    writer.WriteLine(UpdateDiv + inspectDataAddWork.UpdateDiv);
                    // �d�����גʔ�
                    writer.WriteLine(StockSlipDtlNum + inspectDataAddWork.StockSlipDtlNum);
                    // �����敪
                    writer.WriteLine(OpDiv + inspectDataAddWork.OpDiv);
                    // ������R�[�h
                    writer.WriteLine(UOESupplierCd + inspectDataAddWork.UOESupplierCd);
                    // ���ɋ敪
                    writer.WriteLine(WarehousingDivCd + inspectDataAddWork.WarehousingDivCd);
                }
                else if (logObj is HandyUOEOrderListParamWork)
                {
                    HandyUOEOrderListParamWork handyUOEOrderListParamWorkData = logObj as HandyUOEOrderListParamWork;
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCod + handyUOEOrderListParamWorkData.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + handyUOEOrderListParamWorkData.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + handyUOEOrderListParamWorkData.MachineName);
                    // �����敪
                    writer.WriteLine(OpDiv + handyUOEOrderListParamWorkData.OpDiv);
                    // ������R�[�h
                    writer.WriteLine(UOESupplierCd + handyUOEOrderListParamWorkData.SupplierCode);
                }
                else if (logObj is HandyUOEOrderDtlParamWork)
                {
                    HandyUOEOrderDtlParamWork handyUOEOrderDtlParamWorkData = logObj as HandyUOEOrderDtlParamWork;
                    // ��ƃR�[�h
                    writer.WriteLine(EnterpriseCod + handyUOEOrderDtlParamWorkData.EnterpriseCode);
                    // �]�ƈ��R�[�h
                    writer.WriteLine(EmployeeCode + handyUOEOrderDtlParamWorkData.EmployeeCode);
                    // �R���s���[�^��
                    writer.WriteLine(MachineName + handyUOEOrderDtlParamWorkData.MachineName);
                    // �����敪
                    writer.WriteLine(OpDiv + handyUOEOrderDtlParamWorkData.OpDiv);
                    // �I�����C���ԍ�
                    writer.WriteLine(OnlineNo + handyUOEOrderDtlParamWorkData.OnlineNo);
                    // UOE�����ԍ�
                    writer.WriteLine(UOESalesOrderNo + handyUOEOrderDtlParamWorkData.UOESalesOrderNo);
                    // ���ɋ敪
                    writer.WriteLine(WarehousingDivCd + handyUOEOrderDtlParamWorkData.WarehousingDivCd);
                }

                // �t�@�C���X�g���[����null�ł͂Ȃ��ꍇ�A
                if (writer != null) writer.Close();
                if (fileStream != null) fileStream.Close();
            }
        }
        #endregion
    }
}
