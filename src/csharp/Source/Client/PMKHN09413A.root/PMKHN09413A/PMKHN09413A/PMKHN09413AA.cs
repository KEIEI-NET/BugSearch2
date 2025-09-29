//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���}�X�^���p�o�^
// �v���O�����T�v   : �|���}�X�^���p�o�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���m
// �� �� ��  2009/04/08  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10801804-00  �쐬�S�� : chenyd
// �C �� �� 2013/03/18   �C�����e : 2013/05/15�z�M��
//                         Redmine#35046���p�o�^�ŕs���ȑg�ݍ��킹�̃f�[�^������
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ��ؑn
// �� �� ��  2021/09/06  �C�����e : ���p�����Ӑ�|���O���[�v�R�[�h��0000�̂Ƃ��A�|���ݒ�敪�i���Ӑ�j���u3(���Ӑ�|��G+�d����)�v�Ɓu4(���Ӑ�|��G)�v�ȊO�̃��R�[�h�������ΏۂƂ��Ȃ��B
//                                  BLINCIDENT-2384 PM(NS) �|���}�X�^���p�o�^�̏������m�F�������B
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using System.Collections;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ��M�f�[�^�t�H�[���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �Ȃ��B</br>
    /// <br>Programmer : ���m</br>
    /// <br>Date       : 2009.04.29</br>
    /// </remarks>
    public class RateQuoteInputAcs
    {
        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region ��Constructor
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private RateQuoteInputAcs()
        {
            _stockQuoteData = new StockQuoteData();
            _rateAcs = new RateAcs();
        }

        /// <summary>
        /// �A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�A�N�Z�X�N���X �C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public static RateQuoteInputAcs GetInstance()
        {
            if (_rateQuoteInputAcs == null)
            {
                _rateQuoteInputAcs = new RateQuoteInputAcs();
            }

            return _rateQuoteInputAcs;
        }
        #endregion


        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region ��Private Members
        private static RateQuoteInputAcs _rateQuoteInputAcs = null;
        private StockQuoteData _stockQuoteData = null;
        private RateAcs _rateAcs = null;
        private IRateQuoteDB _rateQuoteDB = null;
        #endregion

        // ===================================================================================== //
        // ����
        // ===================================================================================== //
        # region ��Propertity

        /// <summary>
        /// UI�f�[�^
        /// </summary>
        public StockQuoteData StockQuoteData
        {
            get { return this._stockQuoteData; }
        }
        #endregion


        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region ��Private Methods

        /// <summary>
        /// �����f�[�^�����C���X�^���X��������
        /// </summary>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public void CreateStockQuoteInitialData()
        {
            StockQuoteData stockQuoteData = new StockQuoteData();

            // ���_�����l
            stockQuoteData.BfSectionCode = "00";
            stockQuoteData.BfSectionName = "�S��";
            stockQuoteData.AfSectionCode = "00";
            stockQuoteData.AfSectionName = "�S��";
            stockQuoteData.ObjectDistinctionCode = 0;
            stockQuoteData.UpdateDistinctionCode = 0;

            this.CacheStockQuoteData(stockQuoteData);
        }

        /// <summary>
        /// �����f�[�^�L���b�V������
        /// </summary>
        /// <param name="source">����f�[�^�C���X�^���X</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public void CacheStockQuoteData(StockQuoteData source)
        {
            this._stockQuoteData = source.Clone();
        }

        /// <summary>
        /// �ۑ�����
        /// </summary>
        /// <returns>�X�e�[�^�X</returns>
        /// <param name="bfCustRateGrpCodeIsZero">���p���̓��Ӑ�|���O���[�v�R�[�h���u0000�v�̂Ƃ�True</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        public int SaveData(ref string msg, bool bfCustRateGrpCodeIsZero)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            // �����N���A
            this._stockQuoteData.ReadCount = 0;
            this._stockQuoteData.ProcessCount = 0;

            if (_rateQuoteDB == null)
            {
                _rateQuoteDB = MediationRateQuoteDB.GetRateQuoteDB();
            }

            // ���p�������擾
            ArrayList bfRetList = new ArrayList();

            status = this.getBfRateData(ref bfRetList);

            // �G���[�̏ꍇ
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    msg = "���p���̃f�[�^�����݂��܂���B";
                }
                else
                {
                    msg = "�ۑ����������s���܂��B";
                }
                return status;
            }

            // ADD BLINCIDENT-2384 2021/09/06 --------------------------------------------------->>>>>

            // ���p�����Ӑ�|���O���[�v�R�[�h��0�̏ꍇ�A
            // DB����擾���Ă������p����񂩂�A�|���ݒ�敪�i���Ӑ�j���u3(���Ӑ�|��G+�d����)�v�Ɓu4(���Ӑ�|��G)�v�ȊO�̂��̂��폜����B
            //   (DB��A���Ӑ�|���O���[�v�R�[�h���u0�v�Ɓu�w��Ȃ��v�͓���0�ŕ\������Ă���A��ʂ��t���Ȃ�����)
            if (bfCustRateGrpCodeIsZero)
            {
                bfRetList = RemoveBfRateNullRecord(bfRetList);
            }

            // ADD BLINCIDENT-2384 2021/09/06 ---------------------------------------------------<<<<<

            // �ǂ݌���
            _stockQuoteData.ReadCount = bfRetList.Count;

            // ���p����
            ArrayList afRetList = new ArrayList();

            status = this.getAfRateData(ref afRetList);

            // �G���[�̏ꍇ
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                msg = "�ۑ����������s���܂��B";
                return status;
            }

            // �ǉ��A�X�V�f�[�^���擾����
            ArrayList updateList = new ArrayList();
            ArrayList insertList = new ArrayList();
            ArrayList deleteList = new ArrayList();

            this.DivisionArrayList(bfRetList, afRetList, ref updateList, ref insertList, ref deleteList);

            object paraInsertList = (object)insertList;
            object paraUpdateList = (object)updateList;
            object paraDeleteList = (object)deleteList;

            if (_stockQuoteData.UpdateDistinctionCode == 0)
            {
                // �ǉ��E�X�V�̏ꍇ
                status = _rateQuoteDB.Update(ref paraInsertList, ref paraUpdateList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._stockQuoteData.ProcessCount = insertList.Count + updateList.Count;
                }
            }
            else
            {
                // �X�V��񂪂Ȃ��̏ꍇ
                // 2009/06/09�@�Ή������@�ǉ��̏ꍇ�A�_���폜�敪�f�[�^�X�V���Ȃ�
                // if (insertList.Count == 0 && deleteList.Count == 0)
                if (insertList.Count == 0)
                {
                    msg = "�Y���f�[�^�����݂��܂���B";
                    status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    this._stockQuoteData.ProcessCount = 0;
                }
                else
                {
                    status = _rateQuoteDB.Write(ref paraInsertList, ref paraDeleteList);

                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        this._stockQuoteData.ProcessCount = insertList.Count;
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// ���p��
        /// </summary>
        /// <param name="rateList">�|���}�X�^</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int getBfRateData(ref ArrayList rateList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ArrayList retList = new ArrayList();

            // �����ݒ�
            Rate rate = new Rate();
            string errMsg = null;
            // ��ƃR�[�h
            rate.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���_�R�[�h
            rate.SectionCode = this._stockQuoteData.BfSectionCode;
            // ���Ӑ�R�[�h
            rate.CustomerCode = this._stockQuoteData.BfCustomerCode;
            // ���Ӑ�|���O���[�v
            rate.CustRateGrpCode = this._stockQuoteData.BfCustRateGrpCode;

            rate.UnitPriceKind = string.Empty;
            // �_���폜�敪
            rate.LogicalDeleteCode = 0;

            status = _rateAcs.SearchAll(out retList, ref rate, out errMsg);

            // �������A�G���[�𔭐�����
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                return status;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �����擾����
                foreach (Rate rateData in retList)
                {
                    if (rateData.LogicalDeleteCode == 0 && !rateData.RateMngGoodsCd.Equals("A"))
                    {
                        // �Ώۋ敪���h����E���i�h�̏ꍇ
                        if (this._stockQuoteData.ObjectDistinctionCode == 0)
                        {
                            if (("1".Equals(rateData.UnitPriceKind) || "3".Equals(rateData.UnitPriceKind)) && (rateData.CustRateGrpCode == this._stockQuoteData.BfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.BfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                        // �Ώۋ敪���h����̂݁h�̏ꍇ
                        else if (this._stockQuoteData.ObjectDistinctionCode == 1)
                        {
                            if ("1".Equals(rateData.UnitPriceKind) && (rateData.CustRateGrpCode == this._stockQuoteData.BfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.BfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                        // �Ώۋ敪�����h���i�̂݁h�̏ꍇ
                        else
                        {
                            if ("3".Equals(rateData.UnitPriceKind) && (rateData.CustRateGrpCode == this._stockQuoteData.BfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.BfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                    }
                }
            }

            // �X�e�[�^�X
            if (rateList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// �����̊|�����X�g�ɂ��āA�|���ݒ�敪�i���Ӑ�j���u3(���Ӑ�|��G+�d����)�v�Ɓu4(���Ӑ�|��G)�v�ȊO�̃��R�[�h����菜��
        /// </summary>
        /// <param name="rate">�|���}�X�^</param>
        /// <returns>��菜�������ʂ�ArrayList</returns>
        /// <remarks>
        /// <br>Note       : BLINCIDENT-2384 2021/09/06</br>
        /// <br>Programmer : ��ؑn</br>
        /// <br>Date       : 2021.09.06</br>
        /// </remarks>
        private ArrayList RemoveBfRateNullRecord(ArrayList rate)
        {
            ArrayList ret = new ArrayList();

            foreach (Rate r in rate)
            {

                // ���Ӑ�|���O���[�v�R�[�h��0�ȊO�̏ꍇ�X�L�b�v
                if (r.CustRateGrpCode != 0) continue;

                // �|���ݒ�敪�i���Ӑ�j���u3(���Ӑ�|��G+�d����)�v�Ɓu4(���Ӑ�|��G)�v�ȊO�̏ꍇ�X�L�b�v
                if (r.RateMngCustCd != "3" & r.RateMngCustCd != "4") continue;

                // �ԋp�p���X�g�ɒǉ�
                ret.Add(r);

            }

            return ret;
        }

        /// <summary>
        /// ���p��
        /// </summary>
        /// <param name="rateList">��������</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private int getAfRateData(ref ArrayList rateList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            ArrayList retList = new ArrayList();

            // �����ݒ�
            Rate rate = new Rate();
            string errMsg = null;
            // ��ƃR�[�h
            rate.EnterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            // ���_�R�[�h
            rate.SectionCode = this._stockQuoteData.AfSectionCode;
            // ���Ӑ�R�[�h
            rate.CustomerCode = this._stockQuoteData.AfCustomerCode;
            // ���Ӑ�|���O���[�v
            rate.CustRateGrpCode = this._stockQuoteData.AfCustRateGrpCode;
            // �P���敪
            rate.UnitPriceKind = string.Empty;

            status = _rateAcs.SearchAll(out retList, ref rate, out errMsg);

            // �������A�G���[�𔭐�����
            if (status == (int)ConstantManagement.DB_Status.ctDB_ERROR)
            {
                return status;
            }
            else if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �����擾����
                foreach (Rate rateData in retList)
                {
                    if (!rateData.RateMngGoodsCd.Equals("A"))
                    {
                        // �Ώۋ敪���h����E���i�h�̏ꍇ
                        if (this._stockQuoteData.ObjectDistinctionCode == 0)
                        {
                            if (("1".Equals(rateData.UnitPriceKind) || "3".Equals(rateData.UnitPriceKind))
                                && (rateData.CustRateGrpCode == this._stockQuoteData.AfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                        // �Ώۋ敪���h����̂݁h�̏ꍇ
                        else if (this._stockQuoteData.ObjectDistinctionCode == 1)
                        {
                            if ("1".Equals(rateData.UnitPriceKind) && (rateData.CustRateGrpCode == this._stockQuoteData.AfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                        // �Ώۋ敪�����h���i�̂݁h�̏ꍇ
                        else
                        {
                            if ("3".Equals(rateData.UnitPriceKind) && (rateData.CustRateGrpCode == this._stockQuoteData.AfCustRateGrpCode || string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName)))
                            {
                                rateList.Add(rateData);
                            }
                        }
                    }
                }
            }

            // �X�e�[�^�X
            if (rateList.Count == 0)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }

        /// <summary>
        /// �X�V�f�[�^�쐬����
        /// </summary>
        /// <param name="bfRateList">���p���f�[�^</param>
        /// <param name="afRateList">���p��f�[�^</param>
        /// <param name="updateList">�X�V�f�[�^</param>
        /// <param name="insertList">�V�K�f�[�^</param>
        /// <param name="deleteList">�_���폜�f�[�^</param>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private void DivisionArrayList(ArrayList bfRateList, ArrayList afRateList, ref ArrayList updateList, ref ArrayList insertList, ref ArrayList deleteList)
        {
            // ���p���f�[�^�����݂��Ȃ��ꍇ
            if (bfRateList == null || bfRateList.Count == 0) return;

            // ���p��f�[�^�����݂��Ȃ��ꍇ
            if (afRateList == null || afRateList.Count == 0)
            {
                foreach (Rate bfRate in bfRateList)
                {
                    insertList.Add(RateConvert(bfRate));
                }
                return;
            }

            // ���������ݎ�
            foreach(Rate bfRate in bfRateList)
            {
                // �|���ݒ�敪�擾
                string rateMngGoodsCd = bfRate.RateMngGoodsCd;

                bool isExist = false;

                switch (rateMngGoodsCd)
                {
                    // �� 2009.06.18 ���m modify ���b�g���폜
                    case "A":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�A���i�ԍ��A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsNo.Equals(bfRate.GoodsNo) && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }

                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�A���i�ԍ��v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsNo.Equals(bfRate.GoodsNo))
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    case "B":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�A���i�|�������N�ABL���i�R�[�h�A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGoodsCode == bfRate.BLGoodsCode && afRate.LotCount == bfRate.LotCount
                                        && afRate.GoodsNo.Equals(bfRate.GoodsNo))
                                        // && bfRate.SupplierCd == afRate.SupplierCd)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�A���i�|�������N�ABL���i�R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGoodsCode == bfRate.BLGoodsCode && afRate.GoodsNo.Equals(bfRate.GoodsNo))
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    case "C":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�A���i�|�������N�ABL�O���[�v�R�[�h�A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateRank.Equals(bfRate.GoodsRateRank)
                                        && afRate.BLGroupCode == bfRate.BLGroupCode && bfRate.SupplierCd == afRate.SupplierCd)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�A���i�|�������N�ABL�O���[�v�R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateRank.Equals(bfRate.GoodsRateRank) && afRate.BLGroupCode == bfRate.BLGroupCode)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    case "D":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�ABL���i�R�[�h�A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGoodsCode == bfRate.BLGoodsCode && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�ABL���i�R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGoodsCode == bfRate.BLGoodsCode)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    case "E":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�ABL�O���[�v�R�[�h�A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGroupCode == bfRate.BLGroupCode && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�ABL�O���[�v�R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.BLGroupCode == bfRate.BLGroupCode)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    case "F":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�A���i�|���O���[�v�R�[�h�A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateGrpCode == bfRate.GoodsRateGrpCode && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�A���i�|���O���[�v�R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateGrpCode == bfRate.GoodsRateGrpCode)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    case "G":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�A���i�|�������N�A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateRank.Equals(bfRate.GoodsRateRank) && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�A���i�|�������N�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && afRate.GoodsRateRank.Equals(bfRate.GoodsRateRank))
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    case "H":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A�a�k�R�[�h�A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.BLGoodsCode == afRate.BLGoodsCode
                                        && bfRate.SupplierCd == afRate.SupplierCd)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A�a�k�R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.BLGoodsCode == afRate.BLGoodsCode)
                                    // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    case "I":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�ABL�O���[�v�R�[�h�A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.BLGroupCode == afRate.BLGroupCode
                                        && bfRate.SupplierCd == afRate.SupplierCd)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�ABL�O���[�v�R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.BLGroupCode == afRate.BLGroupCode)
                                        // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    case "J":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i�|���O���[�v�R�[�h�A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsRateGrpCode.Equals(afRate.GoodsRateGrpCode)
                                        && bfRate.SupplierCd == afRate.SupplierCd)
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i�|���O���[�v�R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsRateGrpCode.Equals(afRate.GoodsRateGrpCode))
                                        // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    case "K":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd
                                        && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A���i���[�J�[�R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.GoodsMakerCd == afRate.GoodsMakerCd)
                                        // && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    case "L":
                        {
                            // �P���|���ݒ�敪�ϊ�
                            string result = this.UnitRateSetDivCdConvert(bfRate.UnitRateSetDivCd);
                            // ���f
                            if ("1".Equals(result.Substring(1, 1)) || "3".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�A�d����R�[�h�v
                                    if (result.Equals(afRate.UnitRateSetDivCd) && bfRate.SupplierCd == afRate.SupplierCd)
                                        // && afRate.LotCount == bfRate.LotCount)
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }
                            else if ("2".Equals(result.Substring(1, 1)) || "4".Equals(result.Substring(1, 1)))
                            {
                                foreach (Rate afRate in afRateList)
                                {
                                    // �u�ϊ������P���|���ݒ�敪�v
                                    if (result.Equals(afRate.UnitRateSetDivCd))
                                        //  && afRate.LotCount == bfRate.LotCount
                                    {
                                        isExist = true;

                                        RateWork rateWork = RateConvert(bfRate);
                                        rateWork.UpdateDateTime = afRate.UpdateDateTime;
                                        // �X�V���X�g
                                        updateList.Add(rateWork);
                                        // �_���폜���X�g
                                        if (afRate.LogicalDeleteCode == 1)
                                        {
                                            // �_���폜�t���O
                                            afRate.LogicalDeleteCode = 0;
                                            deleteList.Add(this.CopyToRateWorkFromRate(afRate));
                                        }
                                        // �� 2009.06.18 ���m add
                                        break;
                                        // �� 2009.06.18 ���m add
                                    }
                                }
                            }

                            break;
                        }
                    default:
                        {
                            break;
                        }
                    // �� 2009.06.18 ���m modify
                }

                // ���݂��Ȃ��ꍇ�A�ǉ�����
                if (!isExist)
                {
                    // �V�K���X�g
                    insertList.Add(RateConvert(bfRate));
                }
            }
        }

        /// <summary>
        /// �f�[�^�ϊ�
        /// </summary>
        /// <param name="rate">�|���}�X�^</param>
        /// <returns>�|���}�X�^</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private RateWork RateConvert(Rate rate)
        {
            RateWork result = new RateWork();

            // �ϊ�
            result = this.CopyToRateWorkFromRate(rate);
            // ���_�R�[�h
            result.SectionCode = this._stockQuoteData.AfSectionCode;
            // �� 2009.07.22 ���m modify
            // ���Ӑ�|���}�X�^
            // result.CustRateGrpCode = this._stockQuoteData.AfCustRateGrpCode;
            //------------ DEL By chenyd 2013/03/18 For Redmine #35046----------------------------------------->>>>>
            //if (!string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName))
            //{
            //    result.CustRateGrpCode = this._stockQuoteData.AfCustRateGrpCode;
            //}
            //else
            //{
            //    result.CustRateGrpCode = rate.CustRateGrpCode;
            //}
            //------------ DEL By chenyd 2013/03/18 For Redmine #35046-----------------------------------------<<<<<
            // ���Ӑ�|���}�X�^
            result.CustRateGrpCode = this._stockQuoteData.AfCustRateGrpCode;// ADD By chenyd 2013/03/18 For Redmine #35046

            // ���Ӑ�R�[�h
            // result.CustomerCode = this._stockQuoteData.AfCustomerCode;
            //------------ DEL By chenyd 2013/03/18 For Redmine #35046----------------------------------------->>>>>
            //if (this._stockQuoteData.AfCustomerCode != 0)
            //{
            //    result.CustomerCode = this._stockQuoteData.AfCustomerCode;
            //}
            //else
            //{
            //    result.CustomerCode = rate.CustomerCode;
            //}
            //------------ DEL By chenyd 2013/03/18 For Redmine #35046-----------------------------------------<<<<<
            // �� 2009.07.22 ���m modify
            
            // ���Ӑ�R�[�h
            result.CustomerCode = this._stockQuoteData.AfCustomerCode;// ADD By chenyd 2013/03/18 For Redmine #35046

            // ���p���̓��Ӑ�@�ˁ@���p��̓��Ӑ�|���O���[�v
            if (this._stockQuoteData.BfCustomerCode != 0 && !string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName))
            {
                string value = rate.UnitRateSetDivCd.Substring(1, 1);
                if ("1".Equals(value))
                {
                    // �P���|���ݒ�敪
                    result.UnitRateSetDivCd = rate.UnitRateSetDivCd.Substring(0, 1) + "3" + rate.UnitRateSetDivCd.Substring(2);
                    // �|���ݒ�敪
                    result.RateSettingDivide = "3" + rate.RateSettingDivide.Substring(1);
                    // �|���ݒ�敪�i���Ӑ�j
                    result.RateMngCustCd = "3";
                    // �|���ݒ薼�́i���Ӑ�j
                    result.RateMngCustNm = "���Ӑ�|��G+�d����";
                }
                else if ("2".Equals(value))
                {
                    // �P���|���ݒ�敪
                    result.UnitRateSetDivCd = rate.UnitRateSetDivCd.Substring(0, 1) + "4" + rate.UnitRateSetDivCd.Substring(2);
                    // �|���ݒ�敪
                    result.RateSettingDivide = "4" + rate.RateSettingDivide.Substring(1);
                    // �|���ݒ�敪�i���Ӑ�j
                    result.RateMngCustCd = "4";
                    // �|���ݒ薼�́i���Ӑ�j
                    result.RateMngCustNm = "���Ӑ�|��G";
                }
            }
            // ���p���̓��Ӑ�|���O���[�v�@�ˁ@���p��̓��Ӑ�
            else if (!string.IsNullOrEmpty(this._stockQuoteData.BfCustRateGrpName) && this._stockQuoteData.AfCustomerCode != 0)
            {
                string value = rate.UnitRateSetDivCd.Substring(1, 1);
                if ("3".Equals(value))
                {
                    // �P���|���ݒ�敪
                    result.UnitRateSetDivCd = rate.UnitRateSetDivCd.Substring(0, 1) + "1" + rate.UnitRateSetDivCd.Substring(2);
                    // �|���ݒ�敪
                    result.RateSettingDivide = "1" + rate.RateSettingDivide.Substring(1);
                    // �|���ݒ�敪�i���Ӑ�j
                    result.RateMngCustCd = "1";
                    // �|���ݒ薼�́i���Ӑ�j
                    result.RateMngCustNm = "���Ӑ�+�d����";
                }
                else if ("4".Equals(value))
                {
                    // �P���|���ݒ�敪
                    result.UnitRateSetDivCd = rate.UnitRateSetDivCd.Substring(0, 1) + "2" + rate.UnitRateSetDivCd.Substring(2);
                    // �|���ݒ�敪
                    result.RateSettingDivide = "2" + rate.RateSettingDivide.Substring(1);
                    // �|���ݒ�敪�i���Ӑ�j
                    result.RateMngCustCd = "2";
                    // �|���ݒ薼�́i���Ӑ�j
                    result.RateMngCustNm = "���Ӑ�";
                }
            }

            return result;
        }

        /// <summary>
        /// �P���|���ݒ�敪�ϊ�
        /// </summary>
        /// <param name="unitRateSetDivCd">�P���|���ݒ�敪</param>
        /// <returns>����</returns>
        /// <remarks>
        /// <br>Note       : �Ȃ��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009.05.14</br>
        /// </remarks>
        private string UnitRateSetDivCdConvert(string unitRateSetDivCd)
        {
            string result = unitRateSetDivCd;

            // ���p���̓��Ӑ�@�ˁ@���p��̓��Ӑ�|���O���[�v
            if (this._stockQuoteData.BfCustomerCode != 0 && !string.IsNullOrEmpty(this._stockQuoteData.AfCustRateGrpName))
            {
                string value = unitRateSetDivCd.Substring(1, 1);
                if ("1".Equals(value))
                {
                    // �P���|���ݒ�敪
                    result = unitRateSetDivCd.Substring(0, 1) + "3" + unitRateSetDivCd.Substring(2);
                }
                else if ("2".Equals(value))
                {
                    // �P���|���ݒ�敪
                    result = unitRateSetDivCd.Substring(0, 1) + "4" + unitRateSetDivCd.Substring(2);
                }
            }
            // ���p���̓��Ӑ�|���O���[�v�@�ˁ@���p��̓��Ӑ�
            else if (!string.IsNullOrEmpty(this._stockQuoteData.BfCustRateGrpName) && this._stockQuoteData.AfCustomerCode != 0)
            {
                string value = unitRateSetDivCd.Substring(1, 1);
                if ("3".Equals(value))
                {
                    // �P���|���ݒ�敪
                    result = unitRateSetDivCd.Substring(0, 1) + "1" + unitRateSetDivCd.Substring(2);
                }
                else if ("4".Equals(value))
                {
                    // �P���|���ݒ�敪
                    result = unitRateSetDivCd.Substring(0, 1) + "2" + unitRateSetDivCd.Substring(2);
                }
            }

            return result;
        }


        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�|���ݒ�N���X�ˊ|���ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="rate">�|���ݒ�N���X</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ�N���X����|���ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : ���m</br>
        /// <br>Date       : 2009/04/01</br>
        /// </remarks>
        private RateWork CopyToRateWorkFromRate(Rate rate)
        {
            RateWork rateWork = new RateWork();

            // �쐬����
            rateWork.CreateDateTime = rate.CreateDateTime;
            // �X�V����
            rateWork.UpdateDateTime = rate.UpdateDateTime;
            // ��ƃR�[�h
            rateWork.EnterpriseCode = rate.EnterpriseCode;
            // GUID
            rateWork.FileHeaderGuid = rate.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2;
            // �_���폜�敪
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode;
            // ���_�R�[�h
            rateWork.SectionCode = rate.SectionCode;
            // �P���|���ݒ�敪
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;
            // �P�����
            rateWork.UnitPriceKind = rate.UnitPriceKind;
            // �|���ݒ�敪
            rateWork.RateSettingDivide = rate.RateSettingDivide;
            // �|���ݒ�敪�i���i�j
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd;
            // �|���ݒ薼�́i���i�j
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm;
            // �|���ݒ�敪�i���Ӑ�j
            rateWork.RateMngCustCd = rate.RateMngCustCd;
            // �|���ݒ薼�́i���Ӑ�j
            rateWork.RateMngCustNm = rate.RateMngCustNm;
            // ���i���[�J�[�R�[�h
            rateWork.GoodsMakerCd = rate.GoodsMakerCd;
            // ���i�ԍ�
            rateWork.GoodsNo = rate.GoodsNo;
            // ���i�|�������N
            rateWork.GoodsRateRank = rate.GoodsRateRank;
            // BL���i�R�[�h
            rateWork.BLGoodsCode = rate.BLGoodsCode;
            // ���Ӑ�R�[�h
            rateWork.CustomerCode = rate.CustomerCode;
            // ���Ӑ�|���O���[�v�R�[�h
            rateWork.CustRateGrpCode = rate.CustRateGrpCode;
            // �d����R�[�h
            rateWork.SupplierCd = rate.SupplierCd;
            // ���b�g��
            rateWork.LotCount = rate.LotCount;
            // ���i
            rateWork.PriceFl = rate.PriceFl;
            // �|��
            rateWork.RateVal = rate.RateVal;
            // �P���[�������P��
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;
            // �P���[�������敪
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;
            // ���i�|���O���[�v�R�[�h
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;
            // BL�O���[�v�R�[�h
            rateWork.BLGroupCode = rate.BLGroupCode;
            // UP��
            rateWork.UpRate = rate.UpRate;
            // �e���m�ۗ�
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;

            return rateWork;
        }
        #endregion
    }
}
