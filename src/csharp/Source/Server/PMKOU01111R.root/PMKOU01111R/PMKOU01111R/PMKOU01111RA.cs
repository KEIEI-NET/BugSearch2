//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �d�������W�v�f�[�^�X�V�����[�g�I�u�W�F�N�g
//                  :   PMKOU01111R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   30290
// Date             :   2008.12.12
//----------------------------------------------------------------------
// Update Note      :�@ 2009/12/24 杍^ �o�l�D�m�r�ێ�˗��C
//                             �E�ꊇ���A���X�V�̐V�K��Ή�
//----------------------------------------------------------------------
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Library.Diagnostics;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using Broadleaf.Library.Globarization;

using System.Collections.Generic; // ADD 2010/03/30

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �d�������W�v�f�[�^�X�V�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d�������W�v�f�[�^�X�V�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.12.12</br>
    /// <br></br>
    /// <br>Update Note: 2009.03.04 �����W�v�f�[�^MANTIS�Ή�</br>
    /// <br>Update Note: 2009/12/24 杍^ �o�l�D�m�r�ێ�˗��C</br>
    /// <br>                �E�ꊇ���A���X�V�̐V�K��Ή�</br>
    /// <br>Update Note: 2010/02/24 ���� �ꊇ���A���X�V ���x�A�b�v�Ή�</br>
    /// <br>                �E�X�^���h�A���[���}�V���Ŏ��s�����ꍇ�ɁA�b�o�t���ׂ������邽�߁A</br>
    /// <br>                  �P�����P�ʂɏ�������悤�ɏC��</br>
    /// <br>Update Note: 2010/03/04 ��� ���b �ꊇ���A���X�V �^�C���A�E�g�G���[�Ή�</br>
    /// <br>                �E�����̏W�v���R�[�h���폜����ۂ̃^�C���A�E�g�l��ύX</br>
    /// <br>                �@�i���[�U�[�f�[�^�̔��㑤�ŃG���[�ɂȂ�ꍇ���������ׁA�ύX����j</br>
    /// <br>Update Note: 2010/03/30 ���� ���n �ꊇ���A���X�V ���x�A�b�v�Ή�</br>
    /// </remarks>
    [Serializable]
    public class MonthlyTtlStockUpdDB : RemoteWithAppLockDB, IMonthlyTtlStockUpdDB
    {
        /// <summary>
        /// �d�������W�v�f�[�^�X�V�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        public MonthlyTtlStockUpdDB()
            : base("PMKOU01113D", "Broadleaf.Application.Remoting.ParamData.MTtlStockSlipWork", "MTTLSTOCKSLIPRF")
        {

        }

        /// <summary>
        /// �A�v���P�[�V���� ���b�N���s���ۂ̃��\�[�X�����擾���܂��B
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWork�I�u�W�F�N�g</param>
        /// <returns>���b�N ���\�[�X��</returns>
        private string GetLockResourceName(MTtlStockUpdParaWork mTtlStockUpdParaWork)
        {
            return this.GetResourceName(mTtlStockUpdParaWork.EnterpriseCode);
        }

        private CompanyInfWork _CompanyInfWork = null;

        private CompanyInfWork GetCompanyInformation(string enterpriseCode)
        {
            if (this._CompanyInfWork == null)
            {
                CompanyInfDB companyInfDB = new CompanyInfDB();

                CompanyInfWork companyInfWork = new CompanyInfWork();

                companyInfWork.EnterpriseCode = enterpriseCode;
                companyInfWork.CompanyCode = 0;

                byte[] paraByte = XmlByteSerializer.Serialize(companyInfWork);

                int status = companyInfDB.Read(ref paraByte, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._CompanyInfWork = (CompanyInfWork)XmlByteSerializer.Deserialize(paraByte, typeof(CompanyInfWork));
                }
            }

            return this._CompanyInfWork;
        }

        # region [�o�^�E�X�V����]

        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�d�������W�v�f�[�^��ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="newStockSlips">�ǉ��E�X�V����d���`�[�f�[�^</param>
        /// <param name="oldStockSlips">�o�^�O�̎d���`�[�f�[�^</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�d�������W�v�f�[�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        public int Write(MTtlStockUpdParaWork mTtlStockUpdParaWork, ArrayList newStockSlips, ArrayList oldStockSlips, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [�p�����[�^�[�`�F�b�N]

            if (mTtlStockUpdParaWork == null)
            {
                return status;
            }

            if (newStockSlips == null)
            {
                return status;
            }

            // �{���\�b�h���� SqlConnection �𐶐������ꍇ�� true ��ݒ�
            bool CreatedConnection = false;

            if (connection == null)
            {
                connection = this.CreateSqlConnection(true);

                if (connection == null)
                {
                    return status;
                }
                else
                {
                    CreatedConnection = true;
                }
            }

            // �{���\�b�h���� SqlTransaction �𐶐������ꍇ�� true ��ݒ�
            bool CreatedTransaction = false;

            if (transaction == null)
            {
                transaction = this.CreateTransaction(ref connection);

                if (transaction == null)
                {
                    return status;
                }
                else
                {
                    CreatedTransaction = true;
                }
            }

            # endregion

            // �r�����b�N���s��
            status = this.Lock(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            try
            {
                ArrayList totaledStockSlips = null;

                // �d���`�[�f�[�^ ���O�W�v����
                status = this.PreTotal(newStockSlips, oldStockSlips, out totaledStockSlips);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }


                if (ListUtils.IsNotEmpty(totaledStockSlips))
                {
                    // �d�������W�v�f�[�^�X�V����
                    status = this.WriteMTtlStock(mTtlStockUpdParaWork, totaledStockSlips, connection, transaction);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }

                }
            }
            finally
            {
                // �r�����b�N��������� ���߂�l�̓X���[
                this.Release(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);

                if (CreatedTransaction)
                {
                    if (transaction != null)
                    {
                        if (transaction.Connection != null)
                        {
                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // ����I���̏ꍇ�̓R�~�b�g
                                transaction.Commit();
                            }
                            else
                            {
                                // �ُ�I���̏ꍇ�̓��[���o�b�N
                                transaction.Rollback();
                            }
                        }

                        transaction.Dispose();
                    }
                }

                if (CreatedConnection)
                {
                    if (connection != null)
                    {
                        connection.Close();
                        connection.Dispose();
                    }
                }
            }

            return status;
        }

        /// <summary>
        /// �d���`�[�f�[�^ ���O�W�v����
        /// </summary>
        /// <param name="newStockSlips">�o�^��̎d���`�[�f�[�^</param>
        /// <param name="oldStockSlips">�o�^�O�̎d���`�[�f�[�^</param>
        /// <param name="ttlStockSlips">���O�W�v��̎d���`�[�f�[�^</param>
        /// <returns>STATUS</returns>
        private int PreTotal(ArrayList newStockSlips, ArrayList oldStockSlips, out ArrayList ttlStockSlips)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ttlStockSlips = new ArrayList();

            try
            {
                ArrayList newSlip = null;          // �o�^�� �d���`�[�f�[�^(�d���f�[�^�{�d�����׃f�[�^)
                StockSlipWork newHeader = null;    // �o�^�� �d���f�[�^
                ArrayList newDetails = null;       // �o�^�� �d�����׃f�[�^(�S���ו�)

                StockSlipWork oldHeader = null;    // �o�^�O �d���f�[�^
                ArrayList oldDetails = null;       // �o�^�O �d�����׃f�[�^(�S���ו�)

                // �X�V���"�d���f�[�^"����W�v�Ώۂ𒊏o
                if (ListUtils.IsNotEmpty(newStockSlips))
                {
                    foreach (object item in newStockSlips)
                    {
                        if (item is ArrayList)
                        {
                            newHeader = ListUtils.Find((item as ArrayList), typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                            newDetails = ListUtils.Find((item as ArrayList), typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                            if (newHeader != null && newDetails != null && newHeader.SupplierFormal == 0)
                            {
                                ArrayList clnSlip = new ArrayList();  // �d�����
                                ArrayList clnDtls = new ArrayList();  // �d�����׏�񃊃X�g
                                ArrayList clnAdds = new ArrayList();  // ���גǉ���񃊃X�g(�_�~�[)

                                //newHeader = newHeader.Clone();
                                clnSlip.Add(newHeader.Clone());
                                clnSlip.Add(clnDtls);
                                clnSlip.Add(clnAdds);

                                foreach (StockDetailWork newDetail in newDetails)
                                {
                                    //// �d���`�[�敪(����)�� 0:�d�� 1:�ԕi 2:�l�� �̖��ׂ������W�v�ΏۂƂ���
                                    //�d���`����0:�d���̖��ׂ������W�v�ΏۂƂ���
                                    switch (newDetail.StockSlipCdDtl)
                                    {
                                        case 0:  // �d��
                                        case 1:  // �ԕi
                                        case 2:  // �l��
                                            {
                                                StockDetailWork clnDetail = newDetail.Clone();
                                                //clnDetail.ShipmCntDifference = 0;
                                                clnDetail.StockCountDifference = 0;
                                                clnDtls.Add(clnDetail);
                                                break;
                                            }
                                    }
                                }

                                ttlStockSlips.Add(clnSlip);
                            }
                        }
                    }
                }

                // �X�V�O�̎d���f�[�^�����݂���ꍇ�ɂ̂ݎ��O�W�v���s��
                if (ListUtils.IsNotEmpty(oldStockSlips))
                {
                    StockHeaderComparer StockHdrComp = new StockHeaderComparer();
                    StockHeaderComparer2 StockHdrComp2 = new StockHeaderComparer2();
                    StockDetailComparer StockDtlComp = new StockDetailComparer();

                    foreach (ArrayList oldslip in oldStockSlips)
                    {
                        if (ListUtils.IsNotEmpty(oldslip))
                        {
                            oldHeader = ListUtils.Find(oldslip, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                            oldDetails = ListUtils.Find(oldslip, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                            if (oldHeader != null && oldDetails != null && oldHeader.SupplierFormal == 0)
                            {
                                if (oldHeader.DebitNoteDiv == 2)
                                {
                                    // �����͏W�v�Ώۂ��珜�O����
                                    continue;
                                }

                                ttlStockSlips.Sort(StockHdrComp);
                                int stockIndex = ttlStockSlips.BinarySearch(oldslip, StockHdrComp);
                                ttlStockSlips.Sort(StockHdrComp2);
                                int stockIndex2 = ttlStockSlips.BinarySearch(oldslip, StockHdrComp2);

                                if (stockIndex2 > -1)
                                {
                                    // ����L�[�̎d���`�[�f�[�^�����݂���ꍇ
                                    newSlip = ttlStockSlips[stockIndex2] as ArrayList;
                                    newHeader = ListUtils.Find(newSlip, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                                    newDetails = ListUtils.Find(newSlip, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                                    foreach (StockDetailWork oldDetail in oldDetails)
                                    {
                                        newDetails.Sort(StockDtlComp);
                                        //int hdrComp = StockHdrComp.Compare(oldHeader, newHeader);
                                        int detailIndex = newDetails.BinarySearch(oldDetail, StockDtlComp);

                                        if (detailIndex > -1)
                                        //if (hdrComp == 0 && detailIndex > -1)
                                        {
                                            // ����L�[�̎d�����׃f�[�^�����݂���ꍇ �� ���ׂ̓��e���ύX���ꂽ or �����ς���Ă��Ȃ�
                                            StockDetailWork newDetail = newDetails[detailIndex] as StockDetailWork;

                                            newDetail.StockCount -= oldDetail.StockCount;                // �o�א� �̕ϓ������l���Z�o����
                                            newDetail.StockPriceTaxExc -= oldDetail.StockPriceTaxExc;    // �d�����z(�Ŕ�) �̕ϓ������l���Z�o����

                                            newDetail.StockCountDifference = 1;                          // <�d�v> �o�׍������� 1 ��ݒ肷�鎖�ɂ��A"�o�^�ςݖ���"�Ƃ���
                                        }
                                        else
                                        {
                                            // ����L�[�̎d�����׃f�[�^�����݂��Ȃ��ꍇ �� ���ׂ��폜���ꂽ
                                            //// �d���`�[�敪(����)�� 0:�d�� 1:�ԕi 2:�l�� �̖��ׂ������W�v�ΏۂƂ���
                                            //�d���`����0:�d���̖��ׂ������W�v�ΏۂƂ���
                                            switch (oldDetail.StockSlipCdDtl)
                                            {
                                                case 0:  // �d��
                                                case 1:  // �ԕi
                                                case 2:  // �l��
                                                    {
                                                        StockDetailWork clnDetail = oldDetail.Clone();
                                                        clnDetail.StockCount *= -1;                                  // �o�א� �̕����𔽓]������
                                                        clnDetail.StockPriceTaxExc *= -1;                            // �d�����z(�Ŕ�) �̕����𔽓]������

                                                        clnDetail.StockCountDifference = -1;                         // <�d�v> �o�׍������� -1 ��ݒ肷�鎖�ɂ��A"�폜���ꂽ����"�Ƃ���
                                                        newDetails.Add(clnDetail);                                   // �폜���ꂽ���Ƃ��Ēǉ�����
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                }
                                else if (stockIndex > -1) // �w�b�_��񂪕ύX���ꂽ�ꍇ
                                {
                                    ArrayList clnSlip = new ArrayList();  // �d�����
                                    ArrayList clnDtls = new ArrayList();  // �d�����׏�񃊃X�g
                                    ArrayList clnAdds = new ArrayList();  // ���גǉ���񃊃X�g(�_�~�[) 

                                    // ����L�[�̎d���`�[�f�[�^�����݂���ꍇ
                                    newSlip = ttlStockSlips[stockIndex] as ArrayList;

                                    clnSlip.Add(oldHeader.Clone());
                                    clnSlip.Add(clnDtls);
                                    clnSlip.Add(clnAdds);

                                    //StockSlipWork wrkHeader = oldHeader.Clone();
                                    newDetails = ListUtils.Find(newSlip, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                                    //wrkSlip.Add(wrkHeader);
                                    foreach (StockDetailWork oldDetail in oldDetails)
                                    {
                                        //newDetails.Sort(StockDtlComp);
                                        //int detailIndex = newDetails.BinarySearch(oldDetail, StockDtlComp);

                                        //if (detailIndex > -1)
                                        //{
                                        //    // ����L�[�̎d�����׃f�[�^�����݂���ꍇ �� ���ׂ̓��e���ύX���ꂽ or �����ς���Ă��Ȃ�
                                        //    StockDetailWork newDetail = newDetails[detailIndex] as StockDetailWork;
                                        //    StockDetailWork clnDetail = newDetail.Clone();
                                        //    //newDetail.ShipmentCnt -= oldDetail.ShipmentCnt;            // �o�א� �̕ϓ������l���Z�o����
                                        //    //newDetail.Cost -= oldDetail.Cost;                          // ���� �̕ϓ������l���Z�o����
                                        //    //newDetail.SalesMoneyTaxExc -= oldDetail.SalesMoneyTaxExc;  // ������z(�Ŕ�) �̕ϓ������l���Z�o����
                                        //    clnDetail.StockCount -= oldDetail.StockCount;                // �o�א� �̕ϓ������l���Z�o����
                                        //    //newDetail.Cost -= oldDetail.Cost;                          // ���� �̕ϓ������l���Z�o����
                                        //    clnDetail.StockPriceTaxExc -= oldDetail.StockPriceTaxExc;    // �d�����z(�Ŕ�) �̕ϓ������l���Z�o����

                                        //    clnDetail.StockCountDifference = 1;                          // <�d�v> �o�׍������� 1 ��ݒ肷�鎖�ɂ��A"�o�^�ςݖ���"�Ƃ���

                                        //    clnDtls.Add(clnDetail);
                                        //}
                                        //else
                                        //{
                                        // ����L�[�̎d�����׃f�[�^�����݂��Ȃ��ꍇ �� ���ׂ��폜���ꂽ
                                        //// �d���`�[�敪(����)�� 0:�d�� 1:�ԕi 2:�l�� �̖��ׂ������W�v�ΏۂƂ���
                                        //�d���`����0:�d���̖��ׂ������W�v�ΏۂƂ���
                                        switch (oldDetail.StockSlipCdDtl)
                                        {
                                            case 0:  // �d��                                            
                                            case 1:  // �ԕi
                                            case 2:  // �l��
                                                {
                                                    StockDetailWork clnDetail = oldDetail.Clone();

                                                    clnDetail.StockCount *= -1;                                  // �o�א� �̕����𔽓]������
                                                    clnDetail.StockPriceTaxExc *= -1;                            // �d�����z(�Ŕ�) �̕����𔽓]������

                                                    clnDetail.StockCountDifference = -1;                         // <�d�v> �o�׍������� -1 ��ݒ肷�鎖�ɂ��A"�폜���ꂽ����"�Ƃ���

                                                    clnDtls.Add(clnDetail);                                   // �폜���ꂽ���Ƃ��Ēǉ�����
                                                    break;
                                                }
                                        }
                                        //}
                                    }

                                    ttlStockSlips.Add(clnSlip);
                                }
                                else
                                {
                                    // �o�^�O �d���`�[�f�[�^���A�o�^�� �d���`�[�f�[�^�̒��Ɋ܂܂�Ă��Ȃ��ꍇ�A�`�[�폜�Ƃ��Ĉ����B
                                    ArrayList wrkSlip = new ArrayList();
                                    ArrayList wrkDetails = new ArrayList();

                                    StockSlipWork wrkHeader = oldHeader.Clone();
                                    //oldHeader = oldHeader.Clone();

                                    //wrkSlip.Add(oldHeader);
                                    wrkSlip.Add(wrkHeader);
                                    wrkSlip.Add(wrkDetails);

                                    foreach (StockDetailWork oldDetail in oldDetails)
                                    {
                                        //// �d���`�[�敪(����)�� 0:�d�� 1:�ԕi 2:�l�� �̖��ׂ������W�v�ΏۂƂ���
                                        //�d���`����0:�d���̖��ׂ������W�v�ΏۂƂ���
                                        switch (oldDetail.StockSlipCdDtl)
                                        {
                                            case 0:  // �d��                                            
                                            case 1:  // �ԕi
                                            case 2:  // �l��
                                                {
                                                    StockDetailWork clnDetail = oldDetail.Clone();
                                                    clnDetail.StockCountDifference = 0;                              // <�d�v> �`�[�폜�̏ꍇ�ɂ͏o�׍������� 0 ��ݒ肷��(��q�����̒��덇�킹)
                                                    wrkDetails.Add(clnDetail);
                                                    break;
                                                }
                                        }
                                    }

                                    ttlStockSlips.Add(wrkSlip);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }

            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            return status;
        }

        /// <summary>
        /// �d�������W�v�f�[�^ �W�v�E�o�^����
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="totaledStockSlips">���O�W�v�ςݎd���`�[�f�[�^���X�g</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <remarks>���O�W�v���I�����d���`�[�f�[�^���W�v���A�d�������W�v�f�[�^�֒ǉ��E�X�V���s���܂��B</remarks>
        /// <returns>STATUS</returns>
        private int WriteMTtlStock(MTtlStockUpdParaWork mTtlStockUpdParaWork, ArrayList totaledStockSlips, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ���t�擾���i�̃C���X�^���X���擾
            FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlStockUpdParaWork.EnterpriseCode));

            // �d�������W�v�f�[�^��r�p�N���X�̃C���X�^���X���擾
            MTtlStockSlipComparer mTtlStockSlipComparer = new MTtlStockSlipComparer();

            // �`�[�o�^���ɂ͉��Z�A�`�[�폜���ɂ͌��Z���s��
            int sign = (mTtlStockUpdParaWork.SlipRegDiv == 0) ? -1 : 1;

            # region [�d�������W�v����]
            foreach (ArrayList slip in totaledStockSlips)
            {
                // �o�^�E�X�V�ΏۂƂȂ�d�������W�v�f�[�^��ێ�����z��
                // -- UPD 2010/03/30 ------------------<<<
                //ArrayList MTtlStockList = new ArrayList();
                Dictionary<string, MTtlStockSlipWork> MTtlStockDic = new Dictionary<string, MTtlStockSlipWork>();
                // -- UPD 2010/03/30 ------------------<<<
                MTtlStockSlipWork mTtlStockSlipWork = null;

                StockSlipWork header = ListUtils.Find(slip, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                ArrayList details = ListUtils.Find(slip, typeof(StockDetailWork), ListUtils.FindType.Array) as ArrayList;

                if (header == null || ListUtils.IsEmpty(details))
                {
                    continue;
                }

                foreach (StockDetailWork detail in details)
                {
                    // [�g�p�t���O(0:�o�^�s�� 1:���яW�v�敪�N���A 2:�]�ƈ��R�[�h�N���A 3:�o�^�\), �d�������W�v�f�[�^] �����Q�����z��𐶐�
                    // ���㌎���W�v�͏]�ƈ��敪(3)*���яW�v�敪(4)=12�����A�d���ɂ͎��яW�v�敪(3)�����Ȃ��B
                    object[,] MTtlStockSlipArray = new object[3, 2];
                    //object[,] MTtlStockSlipArray = new object[12, 2];

                    for (int index = 0; index < MTtlStockSlipArray.GetLength(0); index++)
                    {
                        mTtlStockSlipWork = new MTtlStockSlipWork();

                        # region [�L�[���ڂ̐ݒ�]
                        // �L�[���ڂ̐ݒ�
                        MTtlStockSlipArray[index, 0] = 0;
                        MTtlStockSlipArray[index, 1] = mTtlStockSlipWork;

                        mTtlStockSlipWork.EnterpriseCode = detail.EnterpriseCode;        // ��ƃR�[�h
                        mTtlStockSlipWork.LogicalDeleteCode = detail.LogicalDeleteCode;  // �_���폜�t���O
                        //mTtlStockSlipWork.AddUpSecCode = header.ResultsAddUpSecCd;       // �v�㋒�_�R�[�h �� ���ьv�㋒�_�R�[�h
                        mTtlStockSlipWork.StockSectionCd = header.StockSectionCd;

                        // ���яW�v�敪 (0:���v 1:�݌� 2:����)
                        mTtlStockSlipWork.RsltTtlDivCd = index; //(int)index / 3;

                        switch (mTtlStockSlipWork.RsltTtlDivCd)
                        {
                            case 0:
                                {
                                    // 2009/03/04 MANTIS 11429-1>>>>>>>>>>>>
                                    // ���v���͂����тɓo�^����悤�ɏC��
                                    //// �d�����i�敪 = 0:���i
                                    //if (detail.StockGoodsCd == 0)
                                    // �d�����i�敪 = 0:���i,6:���v����
                                    if (detail.StockGoodsCd == 0 || detail.StockGoodsCd == 6)
                                    {
                                        MTtlStockSlipArray[index, 0] = 1;
                                    }
                                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<< 
                                    break;
                                }
                            case 1:
                                {
                                    //// �݌ɍX�V�敪
                                    //if (detail.StockUpdateDiv)

                                    // ���i�l���͍݌ɂ̏ꍇ�ł��W�v���邽�߁A�ȉ��̂悤�ɏC������B(2009/01/19)

                                    // �݌ɊǗ��������
                                    // �@ �q�ɃR�[�h���ݒ肳��Ă���
                                    // �A �d���݌Ɏ�񂹋敪�� 1:�݌�
                                    // �B �d������0�ȊO
                                    // �C �d���`�[�敪(����)�� 0:���� 1:�ԕi 2:���i�l���̏ꍇ
                                    // (�d������0�ȊO�̔��f�ɂ�茋�ǎd���`�[�敪(����)�̔��f�͕s�v)

                                    if (!string.IsNullOrEmpty(detail.WarehouseCode) &&
                                        detail.StockOrderDivCd == 1 &&
                                        detail.StockCount != 0)
                                    {
                                        MTtlStockSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    // ���i���� = 0:����
                                    if (detail.GoodsKindCode == 0)
                                    {
                                        MTtlStockSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            //case 3:
                            //    {
                            //        // ����`�[�敪(����) = 1:���
                            //        if (detail.SalesSlipCdDtl == 1)
                            //        {
                            //            MTtlStockSlipArray[index, 0] = 1;
                            //        }
                            //        break;
                            //    }
                        }
                        // �]�ƈ��R�[�h
                        mTtlStockSlipWork.EmployeeCode = header.StockAgentCode; // �d���S���҃R�[�h
                        MTtlStockSlipArray[index, 0] = ((int)MTtlStockSlipArray[index, 0]) + 2; // �o�^�\�ɂ���

                        //mTtlStockSlipWork.CustomerCode = header.CustomerCode;  // ���Ӑ�R�[�h
                        mTtlStockSlipWork.SupplierCd = header.SupplierCd;      // �d����R�[�h
                        //mTtlStockSlipWork.SalesCode = detail.SalesCode;        // �̔��敪�R�[�h

                        # endregion

                        # region [�W�v���ڂ̐ݒ�]
                        if ((int)MTtlStockSlipArray[index, 0] == 3)
                        {
                            // �d������莩�В��̔N���x���擾 �����S���|�鎖���\�z����邽�߁A�o�^�\�ȃ��R�[�h�ɂ̂ݐݒ肷��
                            DateTime AddUpDate;
                            //dateGetAcs.GetYearMonth(detail.SalesDate, out AddUpDate);
                            //mTtlStockSlipWork.AddUpYearMonth = AddUpDate;                    // �v��N��
                            //dateGetAcs.GetYearMonth(header.StockAddUpADate, out AddUpDate); // �d���v����t   // DEL 2009/12/24
                            dateGetAcs.GetYearMonth(header.StockDate, out AddUpDate); // �d����     // ADD 2009/12/24
                            mTtlStockSlipWork.StockDateYm = AddUpDate;              // �d���N��

                            //// �o�׉�
                            //if (header.DebitNoteDiv == 0 && header.SalesSlipCd == 0 && detail.SalesSlipCdDtl == 0)
                            //{
                            //    if (detail.StockCountDifference != 1)
                            //    {
                            //        // ���דo�^�̏ꍇ�͉��Z�A���׍폜�̏ꍇ�͌��Z���s��
                            //        int value = (detail.StockCountDifference == 0) ? 1 : -1;

                            //        // "�d��"�̖��ׂ݂̂��W�v�̑ΏۂƂ��܂��A�܂��`�[�폜���ɂ͌��Z���܂�
                            //        mTtlStockSlipWork.SalesTimes += sign * value;  // �o�׉�
                            //    }
                            //}

                            // �d�����v
                            //if (header.DebitNoteDiv == 0 && detail.SalesSlipCdDtl == 0)
                            // 2009/03/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            // �ԓ`�A���i�l�������ɐ��ʂ����Z����Ȃ��s��̏C�� MANTIS 11430
                            // ���v���͎��ɐ��ʂ��J�E���g�����s��̏C�� MANTIS 11429-2
                            //if (header.DebitNoteDiv == 0 && detail.StockSlipCdDtl != 2) // �l���ȊO���J�E���g����
                            //if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1) && (detail.StockSlipCdDtl == 0 || detail.StockSlipCdDtl == 1 || (detail.StockSlipCdDtl == 2 && detail.StockCount != 0)) && detail.StockGoodsCd == 0) // �l���ȊO���J�E���g���� // DEL 2009/12/24
                            if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1 || header.DebitNoteDiv == 2) && (detail.StockSlipCdDtl == 0 || detail.StockSlipCdDtl == 1 || (detail.StockSlipCdDtl == 2 && detail.StockCount != 0)) && detail.StockGoodsCd == 0) // �l���ȊO���J�E���g���� // ADD 2009/12/24
                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            {
                                // �d�������[�g������ɋt�]�������l�����邽�߁A�����ł̔��]�����s�v
                                //// �d���`�[�敪�� 10:�d�� �̏ꍇ�͉��Z�A1:�ԕi �̏ꍇ�͌��Z���s��
                                //int value = (header.SupplierSlipCd == 10) ? 1 : -1;

                                //mTtlStockSlipWork.TotalStockCount += sign * value * detail.ShipmentCnt;  // �d�����v
                                //mTtlStockSlipWork.TotalStockCount += sign * value * detail.StockCount;  // �d�����v
                                mTtlStockSlipWork.TotalStockCount += sign * detail.StockCount;  // �d�����v
                            }

                            if (header.SupplierSlipCd == 10) //�d��
                            {
                                switch (detail.StockSlipCdDtl)
                                {
                                    case 0:  // 0:�d��
                                        {
                                            // �d�����z���v
                                            mTtlStockSlipWork.StockTotalPrice = sign * detail.StockPriceTaxExc;

                                            break;
                                        }
                                    case 1:  // 1:�ԕi
                                        {
                                            // �ԕi�z
                                            mTtlStockSlipWork.StockRetGoodsPrice = sign * detail.StockPriceTaxExc;

                                            break;
                                        }
                                    case 2:  // 2:�l��
                                        {
                                            //if (mTtlStockSlipWork.RsltTtlDivCd == 0 || // ���i���v�̏ꍇ�͑S�ďW�v����B
                                            //    (mTtlStockSlipWork.RsltTtlDivCd == 2 && detail.StockCount != 0) )
                                            //    // Mantis 10028 �s�l���������Ƃ��ďW�v����Ȃ��悤�ɂ���B
                                            if (detail.StockCount != 0) // PM7�̎d�l�ɍ��킹�A�s�l���̓��A���X�V�ΏۊO�Ƃ���B
                                            {
                                                // �l�����z
                                                mTtlStockSlipWork.StockTotalDiscount = sign * detail.StockPriceTaxExc;
                                            }
                                            // 2009/03/04 �d���̍s�l���͎d�����z�ɔ��f����>>>>>>>>>>
                                            else
                                            {
                                                // �d�����z���v
                                                mTtlStockSlipWork.StockTotalPrice = sign * detail.StockPriceTaxExc;
                                            }
                                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                            
                                            break;
                                        }
                                }
                            }

                            if (header.SupplierSlipCd == 20) //�ԕi
                            {
                                //2009/02/05 >>>>>>>>>>>>>>>>>>>>>>>>>
                                // Mantis 11102�̑Ή� �ԕi�`�[�̍s�l�����z��l�������z�ɃZ�b�g����
                                //// �ԕi�z
                                //mTtlStockSlipWork.StockRetGoodsPrice = sign * detail.StockPriceTaxExc;

                                switch (detail.StockSlipCdDtl)
                                {
                                    case 1: //1:�ԕi
                                        {
                                            // �ԕi�z
                                            mTtlStockSlipWork.StockRetGoodsPrice = sign * detail.StockPriceTaxExc;

                                            break;
                                        }
                                    case 2: //2:�l��
                                        {

                                            //���ʁ�0 ���i�l�����ׂ̂̂ݑΏہi�s�l�������ׂ͑ΏۊO�Ƃ���j
                                            if (detail.StockCount != 0) 
                                            {
                                                // �l�����z
                                                mTtlStockSlipWork.StockTotalDiscount = sign * detail.StockPriceTaxExc;
                                            }
                                            // 2009/03/04 �ԕi�̍s�l���͕ԕi���z�ɔ��f����>>>>>>>>>>
                                            else
                                            {
                                                // �ԕi�z
                                                mTtlStockSlipWork.StockRetGoodsPrice = sign * detail.StockPriceTaxExc;
                                            }
                                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                            break;
                                        }
                                }
                                //2009/02/05 <<<<<<<<<<<<<<<<<<<<<<<<<

                            }

                            // -- DEL 2010/03/30 ------------------------>>>
                            //MTtlStockList.Sort(mTtlStockSlipComparer);

                            //int SearchIndex = MTtlStockList.BinarySearch(mTtlStockSlipWork, mTtlStockSlipComparer);
                            // -- DEL 2010/03/30 ------------------------<<<

                            // -- UPD 2010/03/30 ------------------------>>>
                            //if (SearchIndex < 0)
                            //{
                            //    // ����L�[�����݂��Ȃ��ꍇ�͓o�^���X�g�ɒǉ�����
                            //    MTtlStockList.Add(mTtlStockSlipWork);
                            //}
                            //else
                            //{
                            //    // ����L�[�����݂��Ă���ꍇ�͏W�v���ڂ����Z����
                            //    (MTtlStockList[SearchIndex] as MTtlStockSlipWork).TotalStockCount += mTtlStockSlipWork.TotalStockCount;
                            //    (MTtlStockList[SearchIndex] as MTtlStockSlipWork).StockTotalPrice += mTtlStockSlipWork.StockTotalPrice;
                            //    (MTtlStockList[SearchIndex] as MTtlStockSlipWork).StockTotalDiscount += mTtlStockSlipWork.StockTotalDiscount;
                            //    (MTtlStockList[SearchIndex] as MTtlStockSlipWork).StockRetGoodsPrice += mTtlStockSlipWork.StockRetGoodsPrice; // ***
                            //}

                            if (!MTtlStockDic.ContainsKey(MakeKeyMTtlStockSlip(mTtlStockSlipWork)))
                            {
                                // ����L�[�����݂��Ȃ��ꍇ�͓o�^���X�g�ɒǉ�����
                                MTtlStockDic.Add(MakeKeyMTtlStockSlip(mTtlStockSlipWork), mTtlStockSlipWork);
                            }
                            else
                            {
                                MTtlStockSlipWork work = MTtlStockDic[MakeKeyMTtlStockSlip(mTtlStockSlipWork)];
                                // ����L�[�����݂��Ă���ꍇ�͏W�v���ڂ����Z����
                                work.TotalStockCount += mTtlStockSlipWork.TotalStockCount;
                                work.StockTotalPrice += mTtlStockSlipWork.StockTotalPrice;
                                work.StockTotalDiscount += mTtlStockSlipWork.StockTotalDiscount;
                                work.StockRetGoodsPrice += mTtlStockSlipWork.StockRetGoodsPrice; 
                            }
                            // -- UPD 2010/03/30 ------------------------<<<

                        }
                        # endregion
                    }
                }

                # region [�d�������W�v�f�[�^�o�^]

                string sqlText = string.Empty;
                SqlCommand command = new SqlCommand(sqlText, connection, transaction);
                SqlDataReader reader = null;

                try
                {
                    // -- UPD 2010/03/30 -------------------------------->>>
                    //foreach (MTtlStockSlipWork item in MTtlStockList)
                    foreach (MTtlStockSlipWork item in MTtlStockDic.Values)
                    // -- UPD 2010/03/30 -------------------------------->>>
                    {
                        # region [SELECT��]
                        sqlText = string.Empty;
                        sqlText += "SELECT" + Environment.NewLine;
                        sqlText += "  MTTL.CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,MTTL.UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,MTTL.ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,MTTL.FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,MTTL.UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,MTTL.UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,MTTL.UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,MTTL.LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,MTTL.STOCKSECTIONCDRF" + Environment.NewLine;
                        sqlText += " ,MTTL.STOCKDATEYMRF" + Environment.NewLine;
                        sqlText += " ,MTTL.RSLTTTLDIVCDRF" + Environment.NewLine;
                        sqlText += " ,MTTL.EMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,MTTL.SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += " ,MTTL.STOCKTOTALPRICERF" + Environment.NewLine;
                        sqlText += " ,MTTL.TOTALSTOCKCOUNTRF" + Environment.NewLine;
                        sqlText += " ,MTTL.STOCKRETGOODSPRICERF" + Environment.NewLine;
                        sqlText += " ,MTTL.STOCKTOTALDISCOUNTRF" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  MTTLSTOCKSLIPRF AS MTTL" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  MTTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND MTTL.LOGICALDELETECODERF = 0" + Environment.NewLine;
                        sqlText += "  AND MTTL.STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
                        sqlText += "  AND MTTL.STOCKDATEYMRF = @FINDSTOCKDATEYM" + Environment.NewLine;
                        sqlText += "  AND MTTL.RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += "  AND MTTL.EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND MTTL.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                        command.CommandText = sqlText;
                        command.Parameters.Clear();
                        # endregion

                        # region [�����p �p�����[�^�I�u�W�F�N�g�̍쐬]
                        SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                        SqlParameter findStockSectionCd = command.Parameters.Add("@FINDSTOCKSECTIONCD", SqlDbType.NChar);  // �d�����_�R�[�h
                        SqlParameter findStockDateYM = command.Parameters.Add("@FINDSTOCKDATEYM", SqlDbType.Int);          // �d���N��
                        SqlParameter findRsltTtlDivCd = command.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);        // ���яW�v�敪
                        SqlParameter findEmployeeCode = command.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);      // �]�ƈ��R�[�h                    
                        SqlParameter findSupplierCd = command.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);            // �d����R�[�h
                        # endregion

                        # region [�����p �p�����[�^�I�u�W�F�N�g�̒l�ݒ�]
                        findEnterpriseCode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);              // ��ƃR�[�h
                        findStockSectionCd.Value = SqlDataMediator.SqlSetString(item.StockSectionCd);              // �d�����_�R�[�h
                        findStockDateYM.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.StockDateYm);        // �d���N��
                        findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // ���яW�v�敪
                        findEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // �]�ƈ��R�[�h
                        findSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // �d����R�[�h
                        # endregion

                        reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            # region [UPDATE��]
                            sqlText = string.Empty;
                            sqlText += "UPDATE MTTLSTOCKSLIPRF" + Environment.NewLine;
                            sqlText += "SET" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,STOCKSECTIONCDRF = @STOCKSECTIONCD" + Environment.NewLine;
                            sqlText += " ,STOCKDATEYMRF = @STOCKDATEYM" + Environment.NewLine;
                            sqlText += " ,RSLTTTLDIVCDRF = @RSLTTTLDIVCD" + Environment.NewLine;
                            sqlText += " ,EMPLOYEECODERF = @EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,SUPPLIERCDRF = @SUPPLIERCD" + Environment.NewLine;
                            sqlText += " ,STOCKTOTALPRICERF = @STOCKTOTALPRICE" + Environment.NewLine;
                            sqlText += " ,TOTALSTOCKCOUNTRF = @TOTALSTOCKCOUNT" + Environment.NewLine;
                            sqlText += " ,STOCKRETGOODSPRICERF = @STOCKRETGOODSPRICE" + Environment.NewLine;
                            sqlText += " ,STOCKTOTALDISCOUNTRF = @STOCKTOTALDISCOUNT" + Environment.NewLine;
                            sqlText += "WHERE" + Environment.NewLine;
                            sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                            sqlText += "  AND STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
                            sqlText += "  AND STOCKDATEYMRF = @FINDSTOCKDATEYM" + Environment.NewLine;
                            sqlText += "  AND RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                            sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += "  AND SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                            command.CommandText = sqlText;
                            # endregion

                            # region [����L�[�̃f�[�^�����ɑ��݂��Ă���ꍇ�͏W�v(���Z)����]
                            item.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(reader, reader.GetOrdinal("CREATEDATETIMERF"));   // �쐬����
                            item.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(reader, reader.GetOrdinal("UPDATEDATETIMERF"));   // �X�V����
                            item.EnterpriseCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("ENTERPRISECODERF"));              // ��ƃR�[�h
                            item.FileHeaderGuid = SqlDataMediator.SqlGetGuid(reader, reader.GetOrdinal("FILEHEADERGUIDRF"));                // GUID
                            item.UpdEmployeeCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("UPDEMPLOYEECODERF"));            // �X�V�]�ƈ��R�[�h
                            item.UpdAssemblyId1 = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("UPDASSEMBLYID1RF"));              // �X�V�A�Z���u��ID1
                            item.UpdAssemblyId2 = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("UPDASSEMBLYID2RF"));              // �X�V�A�Z���u��ID2
                            item.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("LOGICALDELETECODERF"));         // �_���폜�敪
                            item.StockSectionCd = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("STOCKSECTIONCDRF"));              // �d�����_�R�[�h
                            item.StockDateYm = SqlDataMediator.SqlGetDateTimeFromYYYYMM(reader, reader.GetOrdinal("STOCKDATEYMRF"));        // �d���N��
                            item.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("RSLTTTLDIVCDRF"));                   // ���яW�v�敪
                            item.EmployeeCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("EMPLOYEECODERF"));                  // �]�ƈ��R�[�h
                            item.SupplierCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SUPPLIERCDRF"));                       // �d����R�[�h
                            item.StockTotalPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("STOCKTOTALPRICERF"));            // �d�����z���v
                            item.TotalStockCount += SqlDataMediator.SqlGetDouble(reader, reader.GetOrdinal("TOTALSTOCKCOUNTRF"));           // �d�����v
                            item.StockRetGoodsPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("STOCKRETGOODSPRICERF"));      // �d���ԕi�z
                            item.StockTotalDiscount += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("STOCKTOTALDISCOUNTRF"));      // �d���l���v
                            # endregion

                            //�X�V�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)item;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetUpdateHeader(ref flhd, obj);
                        }
                        else
                        {
                            # region [INSERT��]
                            sqlText = string.Empty;
                            sqlText += "INSERT INTO MTTLSTOCKSLIPRF" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                            sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                            sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                            sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                            sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                            sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                            sqlText += " ,STOCKSECTIONCDRF" + Environment.NewLine;
                            sqlText += " ,STOCKDATEYMRF" + Environment.NewLine;
                            sqlText += " ,RSLTTTLDIVCDRF" + Environment.NewLine;
                            sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                            sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                            sqlText += " ,STOCKTOTALPRICERF" + Environment.NewLine;
                            sqlText += " ,TOTALSTOCKCOUNTRF" + Environment.NewLine;
                            sqlText += " ,STOCKRETGOODSPRICERF" + Environment.NewLine;
                            sqlText += " ,STOCKTOTALDISCOUNTRF" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            sqlText += "VALUES" + Environment.NewLine;
                            sqlText += "(" + Environment.NewLine;
                            sqlText += "  @CREATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@UPDATEDATETIME" + Environment.NewLine;
                            sqlText += " ,@ENTERPRISECODE" + Environment.NewLine;
                            sqlText += " ,@FILEHEADERGUID" + Environment.NewLine;
                            sqlText += " ,@UPDEMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID1" + Environment.NewLine;
                            sqlText += " ,@UPDASSEMBLYID2" + Environment.NewLine;
                            sqlText += " ,@LOGICALDELETECODE" + Environment.NewLine;
                            sqlText += " ,@STOCKSECTIONCD" + Environment.NewLine;
                            sqlText += " ,@STOCKDATEYM" + Environment.NewLine;
                            sqlText += " ,@RSLTTTLDIVCD" + Environment.NewLine;
                            sqlText += " ,@EMPLOYEECODE" + Environment.NewLine;
                            sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                            sqlText += " ,@STOCKTOTALPRICE" + Environment.NewLine;
                            sqlText += " ,@TOTALSTOCKCOUNT" + Environment.NewLine;
                            sqlText += " ,@STOCKRETGOODSPRICE" + Environment.NewLine;
                            sqlText += " ,@STOCKTOTALDISCOUNT" + Environment.NewLine;
                            sqlText += ")" + Environment.NewLine;
                            command.CommandText = sqlText;
                            # endregion

                            //�o�^�w�b�_����ݒ�
                            object obj = (object)this;
                            IFileHeader flhd = (IFileHeader)item;
                            FileHeader fileHeader = new FileHeader(obj);
                            fileHeader.SetInsertHeader(ref flhd, obj);
                        }

                        reader.Close();
                        reader.Dispose();

                        # region [�o�^�E�X�V�p �p�����[�^�I�u�W�F�N�g�̍쐬]
                        SqlParameter paraCreateDateTime = command.Parameters.Add("@CREATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraUpdateDateTime = command.Parameters.Add("@UPDATEDATETIME", SqlDbType.BigInt);
                        SqlParameter paraEnterpriseCode = command.Parameters.Add("@ENTERPRISECODE", SqlDbType.NChar);
                        SqlParameter paraFileHeaderGuid = command.Parameters.Add("@FILEHEADERGUID", SqlDbType.UniqueIdentifier);
                        SqlParameter paraUpdEmployeeCode = command.Parameters.Add("@UPDEMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraUpdAssemblyId1 = command.Parameters.Add("@UPDASSEMBLYID1", SqlDbType.NVarChar);
                        SqlParameter paraUpdAssemblyId2 = command.Parameters.Add("@UPDASSEMBLYID2", SqlDbType.NVarChar);
                        SqlParameter paraLogicalDeleteCode = command.Parameters.Add("@LOGICALDELETECODE", SqlDbType.Int);
                        SqlParameter paraStockSectionCd = command.Parameters.Add("@STOCKSECTIONCD", SqlDbType.NChar);
                        SqlParameter paraStockDateYM = command.Parameters.Add("@STOCKDATEYM", SqlDbType.Int);
                        SqlParameter paraRsltTtlDivCd = command.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                        SqlParameter paraEmployeeCode = command.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                        SqlParameter paraSupplierCd = command.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                        SqlParameter paraStockTotalPrice = command.Parameters.Add("@STOCKTOTALPRICE", SqlDbType.BigInt);
                        SqlParameter paraTotalStockCount = command.Parameters.Add("@TOTALSTOCKCOUNT", SqlDbType.Float);
                        SqlParameter paraStockRetGoodsPrice = command.Parameters.Add("@STOCKRETGOODSPRICE", SqlDbType.BigInt);
                        SqlParameter paraStockTotalDiscount = command.Parameters.Add("@STOCKTOTALDISCOUNT", SqlDbType.BigInt);
                        # endregion

                        # region [�o�^�E�X�V�p �p�����[�^�I�u�W�F�N�g�̒l�ݒ�]
                        paraCreateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(item.CreateDateTime);   // �쐬����
                        paraUpdateDateTime.Value = SqlDataMediator.SqlSetDateTimeFromTicks(item.UpdateDateTime);   // �X�V����
                        paraEnterpriseCode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);              // ��ƃR�[�h
                        paraFileHeaderGuid.Value = SqlDataMediator.SqlSetGuid(item.FileHeaderGuid);                // GUID
                        paraUpdEmployeeCode.Value = SqlDataMediator.SqlSetString(item.UpdEmployeeCode);            // �X�V�]�ƈ��R�[�h
                        paraUpdAssemblyId1.Value = SqlDataMediator.SqlSetString(item.UpdAssemblyId1);              // �X�V�A�Z���u��ID1
                        paraUpdAssemblyId2.Value = SqlDataMediator.SqlSetString(item.UpdAssemblyId2);              // �X�V�A�Z���u��ID2
                        paraLogicalDeleteCode.Value = SqlDataMediator.SqlSetInt32(item.LogicalDeleteCode);         // �_���폜�敪
                        paraStockSectionCd.Value = SqlDataMediator.SqlSetString(item.StockSectionCd);              // �d�����_�R�[�h
                        paraStockDateYM.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.StockDateYm);        // �d���N��
                        paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // ���яW�v�敪
                        paraEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // �]�ƈ��R�[�h
                        paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // �d����R�[�h
                        paraStockTotalPrice.Value = SqlDataMediator.SqlSetInt64(item.StockTotalPrice);             // �d�����z���v
                        paraTotalStockCount.Value = SqlDataMediator.SqlSetDouble(item.TotalStockCount);            // �d�����v
                        paraStockRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(item.StockRetGoodsPrice);       // �d���ԕi�z
                        paraStockTotalDiscount.Value = SqlDataMediator.SqlSetInt64(item.StockTotalDiscount);       // �d���l���v
                        # endregion

                        command.ExecuteNonQuery();
                    }

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
                catch (SqlException ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
                }
                catch (Exception ex)
                {
                    string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                    base.WriteErrorLog(ex, errmsg, status);
                }
                finally
                {
                    if (reader != null)
                    {
                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }

                        reader.Dispose();
                    }

                    if (command != null)
                    {
                        command.Cancel();
                        command.Dispose();
                    }
                }

                # endregion
            }
            # endregion

            return status;
        }

        // -- ADD 2010/03/30 ----------------------------->>>
        /// <summary>
        /// ���㌎���W�v�f�[�^�pKey��񐶐�
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string MakeKeyMTtlStockSlip(MTtlStockSlipWork item)
        {
            return SqlDataMediator.SqlSetString(item.EnterpriseCode) + "-" +                            // ��ƃR�[�h
                    SqlDataMediator.SqlSetString(item.StockSectionCd) + "-" +                            // �d�����_�R�[�h
                    SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.StockDateYm).ToString() + "-" +        // �d���N��
                    SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd).ToString() + "-" +                    // ���яW�v�敪
                    SqlDataMediator.SqlSetString(item.EmployeeCode) +"-" +                               // �]�ƈ��R�[�h
                    SqlDataMediator.SqlSetInt32(item.SupplierCd);                                        // �d����R�[�h

        }
        // -- ADD 2010/03/30 -----------------------------<<<

        # region [��r���\�b�h (���ёւ��⌟���Ŏg�p)]

        /// <summary>
        /// �d���f�[�^�p ��r���\�b�h
        /// </summary>
        private class StockHeaderComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                StockSlipWork xSlip = ListUtils.Find((ArrayList)x, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                StockSlipWork ySlip = ListUtils.Find((ArrayList)y, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // ��ƃR�[�h�Ŕ�r
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // �d���`���Ŕ�r
                        cmpret = xSlip.SupplierFormal - ySlip.SupplierFormal;
                    }

                    if (cmpret == 0)
                    {
                        // �d���`�[�ԍ��Ŕ�r
                        cmpret = xSlip.SupplierSlipNo - ySlip.SupplierSlipNo;//string.Compare(xSlip.SupplierSlipNo, ySlip.SupplierSlipNo);
                    }
                }

                return cmpret;
            }
        }

        /// <summary>
        /// �d���f�[�^�p ��r���\�b�h2
        /// </summary>
        private class StockHeaderComparer2 : IComparer
        {
            public int Compare(object x, object y)
            {
                StockSlipWork xSlip = ListUtils.Find((ArrayList)x, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;
                StockSlipWork ySlip = ListUtils.Find((ArrayList)y, typeof(StockSlipWork), ListUtils.FindType.Class) as StockSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // ��ƃR�[�h�Ŕ�r
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // �d���`���Ŕ�r
                        cmpret = xSlip.SupplierFormal - ySlip.SupplierFormal;
                    }

                    if (cmpret == 0)
                    {
                        // �d���`�[�ԍ��Ŕ�r
                        cmpret = xSlip.SupplierSlipNo - ySlip.SupplierSlipNo;//string.Compare(xSlip.SupplierSlipNo, ySlip.SupplierSlipNo);
                    }

                    // Mantis 10027�Ή�[�w�b�_���ύX�ɂ��W�v�X�V�̂���]     ����������
                    if (cmpret == 0)
                    {
                        // �d�����_�R�[�h�Ŕ�r
                        cmpret = string.Compare(xSlip.StockSectionCd, ySlip.StockSectionCd);
                    }

                    if (cmpret == 0)
                    {
                        // �d�����Ŕ�r
                        cmpret = DateTime.Compare(xSlip.StockDate, ySlip.StockDate);
                    }

                    if (cmpret == 0)
                    {
                        // �d���S���҃R�[�h�Ŕ�r
                        cmpret = string.Compare(xSlip.StockAgentCode, ySlip.StockAgentCode);
                    }

                    if (cmpret == 0)
                    {
                        // �d����R�[�h�Ŕ�r
                        cmpret = xSlip.SupplierCd - ySlip.SupplierCd;
                    }
                    // Mantis 10027�Ή�[�w�b�_���ύX�ɂ��W�v�X�V�̂���]     ����������
                }

                return cmpret;
            }
        }

        /// <summary>
        /// �d�����׃f�[�^�p ��r���\�b�h
        /// </summary>
        private class StockDetailComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                StockDetailWork xDetail = x as StockDetailWork;
                StockDetailWork yDetail = y as StockDetailWork;

                int cmpret = (xDetail == null ? 0 : 1) - (yDetail == null ? 0 : 1);

                if (cmpret == 0 && xDetail != null)
                {
                    // ��ƃR�[�h�Ŕ�r
                    cmpret = string.Compare(xDetail.EnterpriseCode, yDetail.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // �d���`���Ŕ�r
                        cmpret = xDetail.SupplierFormal - yDetail.SupplierFormal;
                    }

                    if (cmpret == 0)
                    {
                        // �d�����גʔԂŔ�r
                        cmpret = (int)(xDetail.StockSlipDtlNum - yDetail.StockSlipDtlNum);
                    }
                }

                return cmpret;
            }
        }

        /// <summary>
        /// �d�������W�v�f�[�^�p ��r���\�b�h
        /// </summary>
        private class MTtlStockSlipComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                MTtlStockSlipWork xSlip = x as MTtlStockSlipWork;
                MTtlStockSlipWork ySlip = y as MTtlStockSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // ��ƃR�[�h�Ŕ�r
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // �d�����_�R�[�h�Ŕ�r
                        cmpret = string.Compare(xSlip.StockSectionCd, ySlip.StockSectionCd);
                    }

                    if (cmpret == 0)
                    {
                        // �d���N���Ŕ�r
                        cmpret = DateTime.Compare(xSlip.StockDateYm, ySlip.StockDateYm);
                    }

                    if (cmpret == 0)
                    {
                        // ���яW�v�敪�Ŕ�r
                        cmpret = xSlip.RsltTtlDivCd - ySlip.RsltTtlDivCd;
                    }

                    if (cmpret == 0)
                    {
                        // �]�ƈ��R�[�h�Ŕ�r
                        cmpret = string.Compare(xSlip.EmployeeCode, ySlip.EmployeeCode);
                    }

                    if (cmpret == 0)
                    {
                        // �d����R�[�h�Ŕ�r
                        cmpret = xSlip.SupplierCd - ySlip.SupplierCd;
                    }

                }

                return cmpret;
            }
        }

        # endregion

        # endregion

        # region [�폜����]

        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^�𕨗��폜���܂��B
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        public int Delete(MTtlStockUpdParaWork mTtlStockUpdParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection connection = this.CreateSqlConnection(true);

            if (connection == null)
            {
                return status;
            }

            SqlTransaction transaction = this.CreateTransaction(ref connection);

            if (transaction == null)
            {
                return status;
            }

            try
            {
                status = this.Delete(mTtlStockUpdParaWork, connection, transaction);
            }
            finally
            {
                if (transaction != null)
                {
                    if (transaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                    }

                    transaction.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^�𕨗��폜���܂��B
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        public int Delete(MTtlStockUpdParaWork mTtlStockUpdParaWork, SqlConnection connection, SqlTransaction transaction)
        {
            // �r�����b�N���s��
            int status = this.Lock(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);

            try
            {
                status = this.DeleteMTtlStock(mTtlStockUpdParaWork, connection, transaction);
            }
            finally
            {
                // �r�����b�N���������
                this.Release(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�d�������W�v�f�[�^�𕨗��폜���܂��B
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        private int DeleteMTtlStock(MTtlStockUpdParaWork mTtlStockUpdParaWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            try
            {
                using (SqlCommand command = new SqlCommand("", connection, transaction))
                {
                    #region [DELETE��]
                    string sqlText = string.Empty;
                    sqlText += "DELETE" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  MTTLSTOCKSLIPRF" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

                    //sqlText += "  AND STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine; // DEL 2009/12/24

                    // ---ADD 2009/12/24 -------->>>
                    if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCd))
                    {
                        sqlText += "  AND STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
                        command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCd;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND STOCKSECTIONCDRF >= @FINDSTOCKSECTIONCD" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdSt;
                        }
                        else if (string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && !string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND STOCKSECTIONCDRF <= @FINDSTOCKSECTIONCD" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdEd;
                        }
                        else if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && !string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND STOCKSECTIONCDRF >= @FINDSTOCKSECTIONCDST AND STOCKSECTIONCDRF <= @FINDSTOCKSECTIONCDED" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCDST", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdSt;
                            command.Parameters.Add("FINDSTOCKSECTIONCDED", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdEd;
                        }
                    }
                    // ---ADD 2009/12/24 --------<<<

                    if (mTtlStockUpdParaWork.StockDateYmSt != 0)
                    {
                        sqlText += "  AND STOCKDATEYMRF >= @FINDSTOCKDATEYMST" + Environment.NewLine;
                        command.Parameters.Add("FINDSTOCKDATEYMST", SqlDbType.Int).Value = mTtlStockUpdParaWork.StockDateYmSt;
                    }

                    if (mTtlStockUpdParaWork.StockDateYmEd != 0)
                    {
                        sqlText += "  AND STOCKDATEYMRF <= @FINDSTOCKDATEYMED" + Environment.NewLine;
                        command.Parameters.Add("FINDSTOCKDATEYMED", SqlDbType.Int).Value = mTtlStockUpdParaWork.StockDateYmEd;
                    }

                    command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.EnterpriseCode;
                    //command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCd;  // ---DEL 2009/12/24

                    command.CommandText = sqlText;

#if DEBUG
                    Console.Clear();  // �R���\�[����ʂ̏������͔C��
                    Console.WriteLine(NSDebug.GetSqlCommand(command));
#endif
                    # endregion;

                    // --- ADD m.suzuki 2010/03/04 ---------->>>>>
                    command.CommandTimeout = 3600; // =1.0H
                    // --- ADD m.suzuki 2010/03/04 ----------<<<<<
                    command.ExecuteNonQuery();

                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                }
            }
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }

            return status;
        }
        # endregion

        # region [�ďW�v����]

        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�d�������W�v�f�[�^���ďW�v���܂��B
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlStockUpdParaWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�d�������W�v�f�[�^���ďW�v���܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        /// <br>Update Note: 2009/12/24 杍^ �o�l�D�m�r�ێ�˗��C</br>
        /// <br>                �E�ꊇ���A���X�V�̐V�K��Ή�</br>
        public int ReCount(MTtlStockUpdParaWork mTtlStockUpdParaWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            SqlConnection connection = this.CreateSqlConnection(true);

            if (connection == null)
            {
                return status;
            }

            SqlTransaction transaction = this.CreateTransaction(ref connection);

            if (transaction == null)
            {
                return status;
            }

            // ---DEL 2009/12/24 -------->>>
            //SqlCommand command = new SqlCommand("", connection, transaction);
            //SqlDataReader reader = null;
            // ---DEL 2009/12/24 --------<<<

            try
            {
                status = this.ReCountProc(mTtlStockUpdParaWork, ref connection, ref transaction);  // ADD 2009/12/24

                #region �폜
                // ---DEL 2009/12/24 -------->>>
            //    ArrayList newStockSlips = new ArrayList();

            //    # region [�d�����t����d���N����(�J�n�`�I��)���Z�o]

            //    // ���t�擾���i�𗘗p����
            //    FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlStockUpdParaWork.EnterpriseCode));

            //    DateTime tmpStart;
            //    DateTime tmpEnd;
            //    int StockDateYmSt = 0;
            //    int StockDateYmEd = 0;

            //    // �d���N��(�J�n)�����Ɍ��x�J�n�����擾
            //    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlStockUpdParaWork.StockDateYmSt * 100 + 1), out tmpStart, out tmpEnd);
            //    StockDateYmSt = tmpStart.Year * 100 + tmpStart.Month;

            //    // �d���N��(�I��)�����Ɍ��x�I�������擾
            //    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlStockUpdParaWork.StockDateYmEd * 100 + 1), out tmpStart, out tmpEnd);
            //    StockDateYmEd = tmpEnd.Year * 100 + tmpEnd.Month;

            //    # endregion

            //    # region [�d�������f�[�^�̎擾]

            //    // �d�������f�[�^���擾
            //    string sqlText = string.Empty;
            //    sqlText += "SELECT" + Environment.NewLine;
            //    sqlText += "  HIST.CREATEDATETIMERF" + Environment.NewLine;
            //    sqlText += "  HIST.UPDATEDATETIMERF" + Environment.NewLine;
            //    sqlText += "  HIST.ENTERPRISECODERF" + Environment.NewLine;
            //    sqlText += "  HIST.FILEHEADERGUIDRF" + Environment.NewLine;
            //    sqlText += "  HIST.UPDEMPLOYEECODERF" + Environment.NewLine;
            //    sqlText += "  HIST.UPDASSEMBLYID1RF" + Environment.NewLine;
            //    sqlText += "  HIST.UPDASSEMBLYID2RF" + Environment.NewLine;
            //    sqlText += "  HIST.LOGICALDELETECODERF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERFORMALRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERSLIPNORF" + Environment.NewLine;
            //    sqlText += "  HIST.SECTIONCODERF" + Environment.NewLine;
            //    sqlText += "  HIST.SUBSECTIONCODERF" + Environment.NewLine;
            //    sqlText += "  HIST.DEBITNOTEDIVRF" + Environment.NewLine;
            //    sqlText += "  HIST.DEBITNLNKSUPPSLIPNORF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERSLIPCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKGOODSCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.ACCPAYDIVCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKSECTIONCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKADDUPSECTIONCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKSLIPUPDATECDRF" + Environment.NewLine;
            //    sqlText += "  HIST.INPUTDAYRF" + Environment.NewLine;
            //    sqlText += "  HIST.ARRIVALGOODSDAYRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKDATERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKADDUPADATERF" + Environment.NewLine;
            //    sqlText += "  HIST.DELAYPAYMENTDIVRF" + Environment.NewLine;
            //    sqlText += "  HIST.PAYEECODERF" + Environment.NewLine;
            //    sqlText += "  HIST.PAYEESNMRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERNM1RF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERNM2RF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERSNMRF" + Environment.NewLine;
            //    sqlText += "  HIST.BUSINESSTYPECODERF" + Environment.NewLine;
            //    sqlText += "  HIST.BUSINESSTYPENAMERF" + Environment.NewLine;
            //    sqlText += "  HIST.SALESAREACODERF" + Environment.NewLine;
            //    sqlText += "  HIST.SALESAREANAMERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKINPUTCODERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKINPUTNAMERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKAGENTCODERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKAGENTNAMERF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPTTLAMNTDSPWAYCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.TTLAMNTDISPRATEAPYRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKTOTALPRICERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKSUBTTLPRICERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKTTLPRICTAXINCRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKTTLPRICTAXEXCRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKNETPRICERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKPRICECONSTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.TTLITDEDSTCOUTTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.TTLITDEDSTCINTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.TTLITDEDSTCTAXFREERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKOUTTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.STCKPRCCONSTAXINCLURF" + Environment.NewLine;
            //    sqlText += "  HIST.STCKDISTTLTAXEXCRF" + Environment.NewLine;
            //    sqlText += "  HIST.ITDEDSTOCKDISOUTTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.ITDEDSTOCKDISINTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.ITDEDSTOCKDISTAXFRERF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKDISOUTTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.STCKDISTTLTAXINCLURF" + Environment.NewLine;
            //    sqlText += "  HIST.TAXADJUSTRF" + Environment.NewLine;
            //    sqlText += "  HIST.BALANCEADJUSTRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPCTAXLAYCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERCONSTAXRATERF" + Environment.NewLine;
            //    sqlText += "  HIST.ACCPAYCONSTAXRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKFRACTIONPROCCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.AUTOPAYMENTRF" + Environment.NewLine;
            //    sqlText += "  HIST.AUTOPAYSLIPNUMRF" + Environment.NewLine;
            //    sqlText += "  HIST.RETGOODSREASONDIVRF" + Environment.NewLine;
            //    sqlText += "  HIST.RETGOODSREASONRF" + Environment.NewLine;
            //    sqlText += "  HIST.PARTYSALESLIPNUMRF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERSLIPNOTE1RF" + Environment.NewLine;
            //    sqlText += "  HIST.SUPPLIERSLIPNOTE2RF" + Environment.NewLine;
            //    sqlText += "  HIST.DETAILROWCOUNTRF" + Environment.NewLine;
            //    sqlText += "  HIST.EDISENDDATERF" + Environment.NewLine;
            //    sqlText += "  HIST.EDITAKEINDATERF" + Environment.NewLine;
            //    sqlText += "  HIST.UOEREMARK1RF" + Environment.NewLine;
            //    sqlText += "  HIST.UOEREMARK2RF" + Environment.NewLine;
            //    sqlText += "  HIST.SLIPPRINTDIVCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.SLIPPRINTFINISHCDRF" + Environment.NewLine;
            //    sqlText += "  HIST.STOCKSLIPPRINTDATERF" + Environment.NewLine;
            //    sqlText += "  HIST.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
            //    sqlText += "FROM" + Environment.NewLine;
            //    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
            //    sqlText += "WHERE" + Environment.NewLine;
            //    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            //    sqlText += "  AND HIST.SUPPLIERFORMALRF = 0" + Environment.NewLine;
            //    sqlText += "  AND HIST.STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
            //    //sqlText += "  AND (HIST.SALESDATERF >= @FINDSALESDATEST AND HIST.SALESDATERF <= @FINDSALESDATEED)" + Environment.NewLine;
            //    // ������̑���́u���ד��v�Ȃ̂��u�d�����v�Ȃ̂�
            //    sqlText += "  AND (HIST.STOCKDATERF >= @FINDSTOCKDATEST AND HIST.STOCKDATERF <= @FINDSTOCKDATEED)" + Environment.NewLine;
            //    command.CommandText = sqlText;

            //    command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.EnterpriseCode;
            //    command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCd;
            //    command.Parameters.Add("FINDSTOCKDATEST", SqlDbType.Int).Value = StockDateYmSt;
            //    command.Parameters.Add("FINDSTOCKDATEED", SqlDbType.Int).Value = StockDateYmEd;

            //    reader = command.ExecuteReader();

            //    ArrayList headerList = new ArrayList();

            //    while (reader.Read())
            //    {
            //        headerList.Add(this.CopyToStockSlipWorkFromReader(reader));
            //    }

            //    command.Parameters.Clear();

            //    # endregion

            //    # region [�d�����𖾍׃f�[�^�̎擾]

            //    // �d�����𖾍׃f�[�^���擾
            //    sqlText = string.Empty;
            //    sqlText += "SELECT" + Environment.NewLine;
            //    sqlText += "  DTIL.CREATEDATETIMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.UPDATEDATETIMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.ENTERPRISECODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.FILEHEADERGUIDRF" + Environment.NewLine;
            //    sqlText += "  DTIL.UPDEMPLOYEECODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.UPDASSEMBLYID1RF" + Environment.NewLine;
            //    sqlText += "  DTIL.UPDASSEMBLYID2RF" + Environment.NewLine;
            //    sqlText += "  DTIL.LOGICALDELETECODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.ACCEPTANORDERNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.SUPPLIERFORMALRF" + Environment.NewLine;
            //    sqlText += "  DTIL.SUPPLIERSLIPNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKROWNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.SECTIONCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.SUBSECTIONCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.COMMONSEQNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKSLIPDTLNUMRF" + Environment.NewLine;
            //    sqlText += "  DTIL.SUPPLIERFORMALSRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKSLIPDTLNUMSRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.ACPTANODRSTATUSSYNCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.SALESSLIPDTLNUMSYNCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKSLIPCDDTLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKAGENTCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKAGENTNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSKINDCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSMAKERCDRF" + Environment.NewLine;
            //    sqlText += "  DTIL.MAKERNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.MAKERKANANAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.CMPLTMAKERKANANAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSNAMEKANARF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSLGROUPRF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSLGROUPNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSMGROUPRF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSMGROUPNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.BLGROUPCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.BLGROUPNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.BLGOODSCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.BLGOODSFULLNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.ENTERPRISEGANRECODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.ENTERPRISEGANRENAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.WAREHOUSECODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.WAREHOUSENAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.WAREHOUSESHELFNORF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKORDERDIVCDRF" + Environment.NewLine;
            //    sqlText += "  DTIL.OPENPRICEDIVRF" + Environment.NewLine;
            //    sqlText += "  DTIL.GOODSRATERANKRF" + Environment.NewLine;
            //    sqlText += "  DTIL.CUSTRATEGRPCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.SUPPRATEGRPCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.LISTPRICETAXEXCFLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.LISTPRICETAXINCFLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKRATERF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATESECTSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEDIVSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.UNPRCCALCCDSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.PRICECDSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STDUNPRCSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.FRACPROCUNITSTCUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.FRACPROCSTCKUNPRCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKUNITPRICEFLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKUNITTAXPRICEFLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKUNITCHNGDIVRF" + Environment.NewLine;
            //    sqlText += "  DTIL.BFSTOCKUNITPRICEFLRF" + Environment.NewLine;
            //    sqlText += "  DTIL.BFLISTPRICERF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEBLGOODSCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEBLGOODSNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEGOODSRATEGRPCDRF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEGOODSRATEGRPNMRF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEBLGROUPCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.RATEBLGROUPNAMERF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKCOUNTRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKPRICETAXEXCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKPRICETAXINCRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKGOODSCDRF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKPRICECONSTAXRF" + Environment.NewLine;
            //    sqlText += "  DTIL.TAXATIONCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.STOCKDTISLIPNOTE1RF" + Environment.NewLine;
            //    sqlText += "  DTIL.SALESCUSTOMERCODERF" + Environment.NewLine;
            //    sqlText += "  DTIL.SALESCUSTOMERSNMRF" + Environment.NewLine;
            //    sqlText += "  DTIL.ORDERNUMBERRF" + Environment.NewLine;
            //    sqlText += "  DTIL.SLIPMEMO1RF" + Environment.NewLine;
            //    sqlText += "  DTIL.SLIPMEMO2RF" + Environment.NewLine;
            //    sqlText += "  DTIL.SLIPMEMO3RF" + Environment.NewLine;
            //    sqlText += "  DTIL.INSIDEMEMO1RF" + Environment.NewLine;
            //    sqlText += "  DTIL.INSIDEMEMO2RF" + Environment.NewLine;
            //    sqlText += "  DTIL.INSIDEMEMO3RF" + Environment.NewLine;
            //    sqlText += "FROM" + Environment.NewLine;
            //    sqlText += "  STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;
            //    sqlText += "WHERE" + Environment.NewLine;
            //    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
            //    sqlText += "  AND DTIL.SUPPLIERFORMALRF = 0" + Environment.NewLine;
            //    sqlText += "  AND DTIL.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;

            //    command.CommandText = sqlText;

            //    SqlParameter findEnterpriseCode = command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar);
            //    SqlParameter findSupplierSlipNo = command.Parameters.Add("FINDSUPPLIERSLIPNO", SqlDbType.Int);

            //    foreach (StockSlipWork header in headerList)
            //    {
            //        findEnterpriseCode.Value = header.EnterpriseCode;
            //        findSupplierSlipNo.Value = header.SupplierSlipNo;

            //        if (!reader.IsClosed)
            //        {
            //            reader.Close();
            //        }

            //        reader = command.ExecuteReader();

            //        ArrayList detail = new ArrayList();

            //        while (reader.Read())
            //        {
            //            detail.Add(this.CopyToStockDetailWorkFromReader(reader));
            //        }

            //        ArrayList stockSlip = new ArrayList();
            //        stockSlip.Add(header);
            //        stockSlip.Add(detail);

            //        newStockSlips.Add(stockSlip);
            //    }
            //    # endregion

            //    if (ListUtils.IsEmpty(newStockSlips))
            //    {
            //        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            //    }
            //    else
            //    {
            //        // �r�����b�N���s��
            //        status = this.Lock(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);

            //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //        {
            //            return status;
            //        }

            //        try
            //        {
            //            // �ďW�v�O�ɑΏ۔͈͂���x�S�č폜����
            //            status = this.Delete(mTtlStockUpdParaWork, connection, transaction);

            //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            //            {
            //                return status;
            //            }

            //            // �`�[�o�^�敪�� 2:�ďW�v �ɐݒ�
            //            mTtlStockUpdParaWork.SlipRegDiv = 2;

            //            // �ďW�v���s��
            //            status = this.Write(mTtlStockUpdParaWork, newStockSlips, null, connection, transaction);
            //        }
            //        finally
            //        {
            //            // �r�����b�N���������
            //            this.Release(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);
            //        }
            //    }
                // ---DEL 2009/12/24 --------<<<
                #endregion
            }
            finally
            {
                #region �폜
                // ---DEL 2009/12/24 -------->>>
            //    if (reader != null)
            //    {
            //        if (!reader.IsClosed)
            //        {
            //            reader.Close();
            //        }
            //        reader.Dispose();
            //    }

            //    if (command != null)
            //    {
            //        command.Cancel();
            //        command.Dispose();
            //    }
                // ---DEL 2009/12/24 --------<<<
                #endregion

                if (transaction != null)
                {
                    if (transaction.Connection != null)
                    {
                        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            // ����I���̏ꍇ�̓R�~�b�g�������s��
                            transaction.Commit();
                        }
                        else
                        {
                            // �ُ�I���̏ꍇ�̓��[���o�b�N�������s��
                            transaction.Rollback();
                        }
                    }

                    transaction.Dispose();
                }

                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }

            return status;
        }

        // ---ADD 2009/12/24-------------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B
        /// </summary>
        /// <param name="mTtlStockUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="connection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009.12.24</br>
        public int ReCountProc(MTtlStockUpdParaWork mTtlStockUpdParaWork, ref SqlConnection connection, ref SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (connection == null)
            {
                return status;
            }

            if (transaction == null)
            {
                return status;
            }

            SqlCommand command = new SqlCommand("", connection, transaction);
            SqlDataReader reader = null;

            // -- ADD 2010/02/24 ---------------------------------->>>
            Int32 monthRange = ((mTtlStockUpdParaWork.StockDateYmEd / 100) - (mTtlStockUpdParaWork.StockDateYmSt / 100)) * 12 + (mTtlStockUpdParaWork.StockDateYmEd % 100) - (mTtlStockUpdParaWork.StockDateYmSt % 100) + 1;
            DateTime dt = new DateTime(mTtlStockUpdParaWork.StockDateYmSt / 100, mTtlStockUpdParaWork.StockDateYmSt % 100, 1); 
            // -- ADD 2010/02/24 ----------------------------------<<<

            try
            {
                // -- ADD 2010/02/24 ------------------------------>>>
                for (int i = 0; i < monthRange; i++)
                {
                    mTtlStockUpdParaWork.StockDateYmSt = Int32.Parse(dt.ToString("yyyyMM"));
                    mTtlStockUpdParaWork.StockDateYmEd = Int32.Parse(dt.ToString("yyyyMM"));

                    command.Parameters.Clear();
                // -- ADD 2010/02/24 ------------------------------<<<

                    ArrayList newStockSlips = new ArrayList();

                    # region [�d�����t����d���N����(�J�n�`�I��)���Z�o]

                    // ���t�擾���i�𗘗p����
                    FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlStockUpdParaWork.EnterpriseCode));

                    DateTime tmpStart;
                    DateTime tmpEnd;
                    int StockDateYmSt = 0;
                    int StockDateYmEd = 0;

                    // �d���N��(�J�n)�����Ɍ��x�J�n�����擾
                    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlStockUpdParaWork.StockDateYmSt * 100 + 1), out tmpStart, out tmpEnd);
                    //StockDateYmSt = tmpStart.Year * 100 + tmpStart.Month;                        // DEL 2009/12/24
                    StockDateYmSt = tmpStart.Year * 10000 + tmpStart.Month * 100 + tmpStart.Day;   // ADD 2009/12/24

                    // �d���N��(�I��)�����Ɍ��x�I�������擾
                    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlStockUpdParaWork.StockDateYmEd * 100 + 1), out tmpStart, out tmpEnd);
                    //StockDateYmEd = tmpEnd.Year * 100 + tmpEnd.Month;                        // DEL 2009/12/24
                    StockDateYmEd = tmpEnd.Year * 10000 + tmpEnd.Month * 100 + tmpEnd.Day;     // ADD 2009/12/24

                    # endregion

                    # region [�d�������f�[�^�̎擾]

                    // �d�������f�[�^���擾
                    string sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    // ---UPD 2009/12/24 ------------->>>>>>>>>>>
                    sqlText += "  HIST.CREATEDATETIMERF," + Environment.NewLine;
                    sqlText += "  HIST.UPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "  HIST.FILEHEADERGUIDRF," + Environment.NewLine;
                    sqlText += "  HIST.UPDEMPLOYEECODERF," + Environment.NewLine;
                    sqlText += "  HIST.UPDASSEMBLYID1RF," + Environment.NewLine;
                    sqlText += "  HIST.UPDASSEMBLYID2RF," + Environment.NewLine;
                    sqlText += "  HIST.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERFORMALRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERSLIPNORF," + Environment.NewLine;
                    sqlText += "  HIST.SECTIONCODERF," + Environment.NewLine;
                    sqlText += "  HIST.SUBSECTIONCODERF," + Environment.NewLine;
                    sqlText += "  HIST.DEBITNOTEDIVRF," + Environment.NewLine;
                    sqlText += "  HIST.DEBITNLNKSUPPSLIPNORF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERSLIPCDRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKGOODSCDRF," + Environment.NewLine;
                    sqlText += "  HIST.ACCPAYDIVCDRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKSECTIONCDRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKADDUPSECTIONCDRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKSLIPUPDATECDRF," + Environment.NewLine;
                    sqlText += "  HIST.INPUTDAYRF," + Environment.NewLine;
                    sqlText += "  HIST.ARRIVALGOODSDAYRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKDATERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKADDUPADATERF," + Environment.NewLine;
                    sqlText += "  HIST.DELAYPAYMENTDIVRF," + Environment.NewLine;
                    sqlText += "  HIST.PAYEECODERF," + Environment.NewLine;
                    sqlText += "  HIST.PAYEESNMRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERCDRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERNM1RF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERNM2RF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERSNMRF," + Environment.NewLine;
                    sqlText += "  HIST.BUSINESSTYPECODERF," + Environment.NewLine;
                    sqlText += "  HIST.BUSINESSTYPENAMERF," + Environment.NewLine;
                    sqlText += "  HIST.SALESAREACODERF," + Environment.NewLine;
                    sqlText += "  HIST.SALESAREANAMERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKINPUTCODERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKINPUTNAMERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKAGENTCODERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKAGENTNAMERF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPTTLAMNTDSPWAYCDRF," + Environment.NewLine;
                    sqlText += "  HIST.TTLAMNTDISPRATEAPYRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKTOTALPRICERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKSUBTTLPRICERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKTTLPRICTAXINCRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKTTLPRICTAXEXCRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKNETPRICERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKPRICECONSTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.TTLITDEDSTCOUTTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.TTLITDEDSTCINTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.TTLITDEDSTCTAXFREERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKOUTTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.STCKPRCCONSTAXINCLURF," + Environment.NewLine;
                    sqlText += "  HIST.STCKDISTTLTAXEXCRF," + Environment.NewLine;
                    sqlText += "  HIST.ITDEDSTOCKDISOUTTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.ITDEDSTOCKDISINTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.ITDEDSTOCKDISTAXFRERF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKDISOUTTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.STCKDISTTLTAXINCLURF," + Environment.NewLine;
                    sqlText += "  HIST.TAXADJUSTRF," + Environment.NewLine;
                    sqlText += "  HIST.BALANCEADJUSTRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPCTAXLAYCDRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERCONSTAXRATERF," + Environment.NewLine;
                    sqlText += "  HIST.ACCPAYCONSTAXRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKFRACTIONPROCCDRF," + Environment.NewLine;
                    sqlText += "  HIST.AUTOPAYMENTRF," + Environment.NewLine;
                    sqlText += "  HIST.AUTOPAYSLIPNUMRF," + Environment.NewLine;
                    sqlText += "  HIST.RETGOODSREASONDIVRF," + Environment.NewLine;
                    sqlText += "  HIST.RETGOODSREASONRF," + Environment.NewLine;
                    sqlText += "  HIST.PARTYSALESLIPNUMRF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERSLIPNOTE1RF," + Environment.NewLine;
                    sqlText += "  HIST.SUPPLIERSLIPNOTE2RF," + Environment.NewLine;
                    sqlText += "  HIST.DETAILROWCOUNTRF," + Environment.NewLine;
                    sqlText += "  HIST.EDISENDDATERF," + Environment.NewLine;
                    sqlText += "  HIST.EDITAKEINDATERF," + Environment.NewLine;
                    sqlText += "  HIST.UOEREMARK1RF," + Environment.NewLine;
                    sqlText += "  HIST.UOEREMARK2RF," + Environment.NewLine;
                    sqlText += "  HIST.SLIPPRINTDIVCDRF," + Environment.NewLine;
                    sqlText += "  HIST.SLIPPRINTFINISHCDRF," + Environment.NewLine;
                    sqlText += "  HIST.STOCKSLIPPRINTDATERF," + Environment.NewLine;
                    // ---UPD 2009/12/24 -------------<<<<<<<<<<<
                    sqlText += "  HIST.SLIPPRTSETPAPERIDRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLIPHISTRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.SUPPLIERFORMALRF = 0" + Environment.NewLine;

                    // ---UPD 2009/12/24 ----------->>>>
                    //sqlText += "  AND HIST.STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
                    if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCd))
                    {
                        sqlText += "  AND HIST.STOCKSECTIONCDRF = @FINDSTOCKSECTIONCD" + Environment.NewLine;
                        command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCd;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND HIST.STOCKSECTIONCDRF >= @FINDSTOCKSECTIONCD" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdSt;
                        }
                        else if (string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && !string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND HIST.STOCKSECTIONCDRF <= @FINDSTOCKSECTIONCD" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdEd;
                        }
                        else if (!string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdSt) && !string.IsNullOrEmpty(mTtlStockUpdParaWork.StockSectionCdEd))
                        {
                            sqlText += "  AND HIST.STOCKSECTIONCDRF >= @FINDSTOCKSECTIONCDST AND HIST.STOCKSECTIONCDRF <= @FINDSTOCKSECTIONCDED" + Environment.NewLine;
                            command.Parameters.Add("FINDSTOCKSECTIONCDST", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdSt;
                            command.Parameters.Add("FINDSTOCKSECTIONCDED", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCdEd;
                        }
                    }
                    sqlText += "  AND HIST.LOGICALDELETECODERF = 0 " + Environment.NewLine;
                    // ---UPD 2009/12/24 -----------<<<


                    //sqlText += "  AND (HIST.SALESDATERF >= @FINDSALESDATEST AND HIST.SALESDATERF <= @FINDSALESDATEED)" + Environment.NewLine;
                    // ������̑���́u���ד��v�Ȃ̂��u�d�����v�Ȃ̂�
                    sqlText += "  AND (HIST.STOCKDATERF >= @FINDSTOCKDATEST AND HIST.STOCKDATERF <= @FINDSTOCKDATEED)" + Environment.NewLine;
                    command.CommandText = sqlText;

                    command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.EnterpriseCode;
                    //command.Parameters.Add("FINDSTOCKSECTIONCD", SqlDbType.NVarChar).Value = mTtlStockUpdParaWork.StockSectionCd;  // DEL 2009/12/24
                    command.Parameters.Add("FINDSTOCKDATEST", SqlDbType.Int).Value = StockDateYmSt;
                    command.Parameters.Add("FINDSTOCKDATEED", SqlDbType.Int).Value = StockDateYmEd;

                    reader = command.ExecuteReader();

                    ArrayList headerList = new ArrayList();

                    while (reader.Read())
                    {
                        headerList.Add(this.CopyToStockSlipWorkFromReader(reader));
                    }

                    command.Parameters.Clear();

                    # endregion

                    # region [�d�����𖾍׃f�[�^�̎擾]

                    // �d�����𖾍׃f�[�^���擾
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    // ---UPD 2009/12/24 ------------->>>>>>>>>>>
                    sqlText += "  DTIL.CREATEDATETIMERF," + Environment.NewLine;
                    sqlText += "  DTIL.UPDATEDATETIMERF," + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF," + Environment.NewLine;
                    sqlText += "  DTIL.FILEHEADERGUIDRF," + Environment.NewLine;
                    sqlText += "  DTIL.UPDEMPLOYEECODERF," + Environment.NewLine;
                    sqlText += "  DTIL.UPDASSEMBLYID1RF," + Environment.NewLine;
                    sqlText += "  DTIL.UPDASSEMBLYID2RF," + Environment.NewLine;
                    sqlText += "  DTIL.LOGICALDELETECODERF," + Environment.NewLine;
                    sqlText += "  DTIL.ACCEPTANORDERNORF," + Environment.NewLine;
                    sqlText += "  DTIL.SUPPLIERFORMALRF," + Environment.NewLine;
                    sqlText += "  DTIL.SUPPLIERSLIPNORF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKROWNORF," + Environment.NewLine;
                    sqlText += "  DTIL.SECTIONCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.SUBSECTIONCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.COMMONSEQNORF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKSLIPDTLNUMRF," + Environment.NewLine;
                    sqlText += "  DTIL.SUPPLIERFORMALSRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKSLIPDTLNUMSRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.ACPTANODRSTATUSSYNCRF," + Environment.NewLine;
                    sqlText += "  DTIL.SALESSLIPDTLNUMSYNCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKSLIPCDDTLRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKAGENTCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKAGENTNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSKINDCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSMAKERCDRF," + Environment.NewLine;
                    sqlText += "  DTIL.MAKERNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.MAKERKANANAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.CMPLTMAKERKANANAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSNORF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSNAMEKANARF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSLGROUPRF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSLGROUPNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSMGROUPRF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSMGROUPNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.BLGROUPCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.BLGROUPNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.BLGOODSCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.BLGOODSFULLNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISEGANRECODERF," + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISEGANRENAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.WAREHOUSECODERF," + Environment.NewLine;
                    sqlText += "  DTIL.WAREHOUSENAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.WAREHOUSESHELFNORF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKORDERDIVCDRF," + Environment.NewLine;
                    sqlText += "  DTIL.OPENPRICEDIVRF," + Environment.NewLine;
                    sqlText += "  DTIL.GOODSRATERANKRF," + Environment.NewLine;
                    sqlText += "  DTIL.CUSTRATEGRPCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.SUPPRATEGRPCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.LISTPRICETAXEXCFLRF," + Environment.NewLine;
                    sqlText += "  DTIL.LISTPRICETAXINCFLRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKRATERF," + Environment.NewLine;
                    sqlText += "  DTIL.RATESECTSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEDIVSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.UNPRCCALCCDSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.PRICECDSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STDUNPRCSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.FRACPROCUNITSTCUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.FRACPROCSTCKUNPRCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKUNITPRICEFLRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKUNITTAXPRICEFLRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKUNITCHNGDIVRF," + Environment.NewLine;
                    sqlText += "  DTIL.BFSTOCKUNITPRICEFLRF," + Environment.NewLine;
                    sqlText += "  DTIL.BFLISTPRICERF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEBLGOODSCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEBLGOODSNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEGOODSRATEGRPCDRF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEGOODSRATEGRPNMRF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEBLGROUPCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.RATEBLGROUPNAMERF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKCOUNTRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKPRICETAXEXCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKPRICETAXINCRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKGOODSCDRF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKPRICECONSTAXRF," + Environment.NewLine;
                    sqlText += "  DTIL.TAXATIONCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.STOCKDTISLIPNOTE1RF," + Environment.NewLine;
                    sqlText += "  DTIL.SALESCUSTOMERCODERF," + Environment.NewLine;
                    sqlText += "  DTIL.SALESCUSTOMERSNMRF," + Environment.NewLine;
                    sqlText += "  DTIL.ORDERNUMBERRF," + Environment.NewLine;
                    sqlText += "  DTIL.SLIPMEMO1RF," + Environment.NewLine;
                    sqlText += "  DTIL.SLIPMEMO2RF," + Environment.NewLine;
                    sqlText += "  DTIL.SLIPMEMO3RF," + Environment.NewLine;
                    sqlText += "  DTIL.INSIDEMEMO1RF," + Environment.NewLine;
                    sqlText += "  DTIL.INSIDEMEMO2RF," + Environment.NewLine;
                    // ---UPD 2009/12/24 -------------<<<<<<<
                    sqlText += "  DTIL.INSIDEMEMO3RF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  STOCKSLHISTDTLRF AS DTIL" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DTIL.SUPPLIERFORMALRF = 0" + Environment.NewLine;
                    sqlText += "  AND DTIL.SUPPLIERSLIPNORF = @FINDSUPPLIERSLIPNO" + Environment.NewLine;
                    sqlText += "  AND DTIL.LOGICALDELETECODERF = 0" + Environment.NewLine;             // ADD 2009/12/24

                    command.CommandText = sqlText;

                    SqlParameter findEnterpriseCode = command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar);
                    SqlParameter findSupplierSlipNo = command.Parameters.Add("FINDSUPPLIERSLIPNO", SqlDbType.Int);

                    foreach (StockSlipWork header in headerList)
                    {
                        findEnterpriseCode.Value = header.EnterpriseCode;
                        findSupplierSlipNo.Value = header.SupplierSlipNo;

                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }

                        reader = command.ExecuteReader();

                        ArrayList detail = new ArrayList();

                        while (reader.Read())
                        {
                            detail.Add(this.CopyToStockDetailWorkFromReader(reader));
                        }

                        ArrayList stockSlip = new ArrayList();
                        stockSlip.Add(header);
                        stockSlip.Add(detail);

                        newStockSlips.Add(stockSlip);
                    }

                    // ---ADD 2009/12/24 --->>>
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    // ---ADD 2009/12/24 ---<<<
                    # endregion

                    if (ListUtils.IsEmpty(newStockSlips))
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     // ADD 2009/12/24

                        // �r�����b�N���s��
                        status = this.Lock(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                        try
                        {
                            // �ďW�v�O�ɑΏ۔͈͂���x�S�č폜����
                            status = this.Delete(mTtlStockUpdParaWork, connection, transaction);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return status;
                            }

                            // �`�[�o�^�敪�� 2:�ďW�v �ɐݒ�
                            mTtlStockUpdParaWork.SlipRegDiv = 2;

                            // �ďW�v���s��
                            status = this.Write(mTtlStockUpdParaWork, newStockSlips, null, connection, transaction);
                        }
                        finally
                        {
                            // �r�����b�N���������
                            this.Release(this.GetLockResourceName(mTtlStockUpdParaWork), connection, transaction);
                        }
                    }

                    dt = dt.AddMonths(1); // ADD 2010/02/24
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     // ADD 2010/02/24

                } // ADD 2010/02/24

            }
            // -- ADD 2010/02/24 ------------------------>>>
            catch (SqlException ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                status = base.WriteSQLErrorLog(ex, errmsg, ex.Number);
            }
            catch (Exception ex)
            {
                string errmsg = NSDebug.GetExecutingMethodName(new System.Diagnostics.StackFrame());
                base.WriteErrorLog(ex, errmsg, status);
            }
            // -- ADD 2010/02/24 ------------------------<<<
            finally
            {
                if (reader != null)
                {
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    reader.Dispose();
                }

                if (command != null)
                {
                    command.Cancel();
                    command.Dispose();
                }
            }
            return status;
        }
        // ---ADD 2009/12/24--------------------------------------------------------<<<<<<<<<<<<<<<<<
        # endregion

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� stockHistoryWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>stockHistoryWork</returns>
        /// <remarks>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.12.12</br>
        /// </remarks>
        private StockSlipWork CopyToStockSlipWorkFromReader(SqlDataReader myReader)
        {
            StockSlipWork wkStockSlipWork = new StockSlipWork();

            this.CopyToStockSlipWorkFromReader(myReader, ref wkStockSlipWork);

            return wkStockSlipWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="wkStockSlipWork"></param>
        private void CopyToStockSlipWorkFromReader(SqlDataReader myReader, ref StockSlipWork wkStockSlipWork)
        {
            if (wkStockSlipWork != null)
            {
                #region �N���X�֊i�[
                wkStockSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                wkStockSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                wkStockSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkStockSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                wkStockSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                wkStockSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                wkStockSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                wkStockSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                wkStockSlipWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                wkStockSlipWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                wkStockSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                wkStockSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                wkStockSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                wkStockSlipWork.DebitNLnkSuppSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNLNKSUPPSLIPNORF"));
                wkStockSlipWork.SupplierSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPCDRF"));
                wkStockSlipWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                wkStockSlipWork.AccPayDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCPAYDIVCDRF"));
                wkStockSlipWork.StockSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKSECTIONCDRF"));
                wkStockSlipWork.StockAddUpSectionCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKADDUPSECTIONCDRF"));
                wkStockSlipWork.StockSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPUPDATECDRF"));
                wkStockSlipWork.InputDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("INPUTDAYRF"));
                wkStockSlipWork.ArrivalGoodsDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ARRIVALGOODSDAYRF"));
                wkStockSlipWork.StockDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKDATERF"));
                wkStockSlipWork.StockAddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKADDUPADATERF"));
                wkStockSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
                wkStockSlipWork.PayeeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PAYEECODERF"));
                wkStockSlipWork.PayeeSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PAYEESNMRF"));
                wkStockSlipWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                wkStockSlipWork.SupplierNm1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM1RF"));
                wkStockSlipWork.SupplierNm2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERNM2RF"));
                wkStockSlipWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                wkStockSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                wkStockSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                wkStockSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                wkStockSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                wkStockSlipWork.StockInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTCODERF"));
                wkStockSlipWork.StockInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKINPUTNAMERF"));
                wkStockSlipWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                wkStockSlipWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                wkStockSlipWork.SuppTtlAmntDspWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPTTLAMNTDSPWAYCDRF"));
                wkStockSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
                wkStockSlipWork.StockTotalPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTOTALPRICERF"));
                wkStockSlipWork.StockSubttlPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSUBTTLPRICERF"));
                wkStockSlipWork.StockTtlPricTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXINCRF"));
                wkStockSlipWork.StockTtlPricTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKTTLPRICTAXEXCRF"));
                wkStockSlipWork.StockNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKNETPRICERF"));
                wkStockSlipWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                wkStockSlipWork.TtlItdedStcOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCOUTTAXRF"));
                wkStockSlipWork.TtlItdedStcInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCINTAXRF"));
                wkStockSlipWork.TtlItdedStcTaxFree = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TTLITDEDSTCTAXFREERF"));
                wkStockSlipWork.StockOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKOUTTAXRF"));
                wkStockSlipWork.StckPrcConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKPRCCONSTAXINCLURF"));
                wkStockSlipWork.StckDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXEXCRF"));
                wkStockSlipWork.ItdedStockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISOUTTAXRF"));
                wkStockSlipWork.ItdedStockDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISINTAXRF"));
                wkStockSlipWork.ItdedStockDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSTOCKDISTAXFRERF"));
                wkStockSlipWork.StockDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKDISOUTTAXRF"));
                wkStockSlipWork.StckDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STCKDISTTLTAXINCLURF"));
                wkStockSlipWork.TaxAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TAXADJUSTRF"));
                wkStockSlipWork.BalanceAdjust = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("BALANCEADJUSTRF"));
                wkStockSlipWork.SuppCTaxLayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPCTAXLAYCDRF"));
                wkStockSlipWork.SupplierConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SUPPLIERCONSTAXRATERF"));
                wkStockSlipWork.AccPayConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCPAYCONSTAXRF"));
                wkStockSlipWork.StockFractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKFRACTIONPROCCDRF"));
                wkStockSlipWork.AutoPayment = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYMENTRF"));
                wkStockSlipWork.AutoPaySlipNum = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTOPAYSLIPNUMRF"));
                wkStockSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                wkStockSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                wkStockSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                wkStockSlipWork.SupplierSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE1RF"));
                wkStockSlipWork.SupplierSlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSLIPNOTE2RF"));
                wkStockSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                wkStockSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                wkStockSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                wkStockSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                wkStockSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                wkStockSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
                wkStockSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                wkStockSlipWork.StockSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("STOCKSLIPPRINTDATERF"));
                wkStockSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                #endregion
            }
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� StockHistDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>StockHistDtlWork</returns>
        /// <remarks>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private StockDetailWork CopyToStockDetailWorkFromReader(SqlDataReader myReader)
        {
            StockDetailWork wkStockDetailWork = new StockDetailWork();

            this.CopyToStockDetailWorkFromReader(myReader, ref wkStockDetailWork);

            return wkStockDetailWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="wkStockDetailWork"></param>
        private void CopyToStockDetailWorkFromReader(SqlDataReader myReader, ref StockDetailWork wkStockDetailWork)
        {
            if (wkStockDetailWork != null)
            {
                #region �N���X�֊i�[
                wkStockDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                wkStockDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                wkStockDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkStockDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                wkStockDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                wkStockDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                wkStockDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                wkStockDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                wkStockDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                wkStockDetailWork.SupplierFormal = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALRF"));
                wkStockDetailWork.SupplierSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERSLIPNORF"));
                wkStockDetailWork.StockRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKROWNORF"));
                wkStockDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                wkStockDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                wkStockDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                wkStockDetailWork.StockSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMRF"));
                wkStockDetailWork.SupplierFormalSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSRCRF"));
                wkStockDetailWork.StockSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSRCRF"));
                wkStockDetailWork.AcptAnOdrStatusSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSYNCRF"));
                wkStockDetailWork.SalesSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSYNCRF"));
                wkStockDetailWork.StockSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKSLIPCDDTLRF"));
                wkStockDetailWork.StockAgentCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTCODERF"));
                wkStockDetailWork.StockAgentName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKAGENTNAMERF"));
                wkStockDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                wkStockDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                wkStockDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                wkStockDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
                wkStockDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));
                wkStockDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                wkStockDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                wkStockDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                wkStockDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                wkStockDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
                wkStockDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                wkStockDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                wkStockDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                wkStockDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
                wkStockDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                wkStockDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                wkStockDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                wkStockDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
                wkStockDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                wkStockDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                wkStockDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                wkStockDetailWork.StockOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKORDERDIVCDRF"));
                wkStockDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                wkStockDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                wkStockDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                wkStockDetailWork.SuppRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPRATEGRPCODERF"));
                wkStockDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                wkStockDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                wkStockDetailWork.StockRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKRATERF"));
                wkStockDetailWork.RateSectStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSTCKUNPRCRF"));
                wkStockDetailWork.RateDivStckUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSTCKUNPRCRF"));
                wkStockDetailWork.UnPrcCalcCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSTCKUNPRCRF"));
                wkStockDetailWork.PriceCdStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSTCKUNPRCRF"));
                wkStockDetailWork.StdUnPrcStckUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSTCKUNPRCRF"));
                wkStockDetailWork.FracProcUnitStcUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSTCUNPRCRF"));
                wkStockDetailWork.FracProcStckUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSTCKUNPRCRF"));
                wkStockDetailWork.StockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITPRICEFLRF"));
                wkStockDetailWork.StockUnitTaxPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKUNITTAXPRICEFLRF"));
                wkStockDetailWork.StockUnitChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKUNITCHNGDIVRF"));
                wkStockDetailWork.BfStockUnitPriceFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSTOCKUNITPRICEFLRF"));
                wkStockDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                wkStockDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
                wkStockDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
                wkStockDetailWork.RateGoodsRateGrpCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPCDRF"));
                wkStockDetailWork.RateGoodsRateGrpNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEGOODSRATEGRPNMRF"));
                wkStockDetailWork.RateBLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGROUPCODERF"));
                wkStockDetailWork.RateBLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGROUPNAMERF"));
                wkStockDetailWork.StockCount = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STOCKCOUNTRF"));
                wkStockDetailWork.StockPriceTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXEXCRF"));
                wkStockDetailWork.StockPriceTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICETAXINCRF"));
                wkStockDetailWork.StockGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("STOCKGOODSCDRF"));
                wkStockDetailWork.StockPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKPRICECONSTAXRF"));
                wkStockDetailWork.TaxationCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONCODERF"));
                wkStockDetailWork.StockDtiSlipNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("STOCKDTISLIPNOTE1RF"));
                wkStockDetailWork.SalesCustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCUSTOMERCODERF"));
                wkStockDetailWork.SalesCustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCUSTOMERSNMRF"));
                wkStockDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                wkStockDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                wkStockDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                wkStockDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                wkStockDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                wkStockDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                wkStockDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                #endregion
            }
        }
        #endregion
    }
}
