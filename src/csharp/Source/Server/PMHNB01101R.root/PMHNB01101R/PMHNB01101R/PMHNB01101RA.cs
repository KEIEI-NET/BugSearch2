//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   ���㌎���W�v�f�[�^�X�VDB�����[�g�I�u�W�F�N�g
//                  :   PMHNB01101R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21112�@�v�ۓc�@��
// Date             :   2008.05.19
//----------------------------------------------------------------------
// Update Note      :�@ 2009/12/24 杍^ �o�l�D�m�r�ێ�˗��C
//                             �E�ꊇ���A���X�V�̐V�K��Ή�
//----------------------------------------------------------------------// 
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �s�i��  						
// �C �� ��  2012/03/30  �C�����e : 2012/05/24�z�M���ARedmine#29142 						
//                                 �u���i�l���v�̏ꍇ�͏W�v�ΏۊO�ƂȂ�悤�ɏC������						
//----------------------------------------------------------------------//  
// �Ǘ��ԍ�  10707327-00 �쐬�S�� : �����H 						
// �C �� ��  2012/03/31  �C�����e : 2012/05/24�z�M���ARedmine#29215�@ 						
//                                  ���Ӑ�d�q�����Ƌ��z������Ȃ��̏C��						
//----------------------------------------------------------------------//
// �Ǘ��ԍ�  11600006-00 �쐬�S�� : �c���� 						
// �C �� ��  2020/08/28  �C�����e : PMKOBETSU-4076�@ 						
//                                  �^�C���A�E�g�ݒ�						
//----------------------------------------------------------------------// 						
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

using System.Collections.Generic;// ADD 2010/03/30
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
using Microsoft.Win32;
using System.Xml;
using System.IO;
// --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// ���㌎���W�v�f�[�^�X�VDB�����[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���㌎���W�v�f�[�^�X�V�̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21112�@�v�ۓc�@��</br>
    /// <br>Date       : 2008.05.19</br>
    /// <br></br>
    /// <br>Update Note: 2009.03.04 �����W�v�f�[�^MANTIS�Ή�</br>
    /// <br>Update Note: 2009/12/24 杍^ �o�l�D�m�r�ێ�˗��C</br>
    /// <br>                �E�ꊇ���A���X�V�̐V�K��Ή�</br>
    /// <br>Update Note: 2010/02/24 ���� �ꊇ���A���X�V ���x�A�b�v�Ή�</br>
    /// <br>                �E�X�^���h�A���[���}�V���Ŏ��s�����ꍇ�ɁA�b�o�t���ׂ������邽�߁A</br>
    /// <br>                  �P�����P�ʂɏ�������悤�ɏC��</br>
    /// <br>Update Note: 2010/03/04 ��� ���b �ꊇ���A���X�V �^�C���A�E�g�G���[�Ή�</br>
    /// <br>                �E�����̏W�v���R�[�h���폜����ۂ̃^�C���A�E�g�l��ύX</br>
    /// <br>                �@�i���[�U�[�f�[�^�ŃG���[�ɂȂ�ꍇ���������ׁA�ύX����j</br>
    /// <br>Update Note: 2010/03/30 ���� ���n �ꊇ���A���X�V ���x�A�b�v�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2010/07/12 30517 �Ė� �x�� ����f�[�^���Ȃ��Ɣ��㌎���W�v�f�[�^���폜����Ȃ��s��̏C��</br>
    /// <br>Update Note: 2012/03/30 �s�i�� </br>
    /// <br>�Ǘ��ԍ�   �F10801804-00 2012/05/24�z�M��</br>
    /// <br>             Redmine#29142 �u���i�l���v�̏ꍇ�͏W�v�ΏۊO�ƂȂ�悤�ɏC������</br>
    /// <br>Update Note: 2012/03/31 �����H</br>							
    /// <br>�Ǘ��ԍ�   �F10707327-00 2012/05/24�z�M��</br>							
    /// <br>             Redmine#29215�@���Ӑ�d�q�����Ƌ��z������Ȃ��̏C��</br>
    /// <br>Update Note: 2020/08/28 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11600006-00</br>
    /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
    /// </remarks>
    [Serializable]
    public class MonthlyTtlSalesUpdDB : RemoteWithAppLockDB, IMonthlyTtlSalesUpdDB
    {
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>> 
        // �`�[�X�V�^�C���A�E�g���Ԑݒ�t�@�C��
        private const string XML_FILE_NAME = "DbCommandTimeoutSet.xml";
        // XML�t�@�C�����������̃f�t�H���g�l
        private const int DB_COMMAND_TIMEOUT = 120;
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
        /// <summary>
        /// ���㌎���W�v�f�[�^�X�VDB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.05.19</br>
        /// </remarks>
        public MonthlyTtlSalesUpdDB()
            : base("PMHNB01103D", "Broadleaf.Application.Remoting.ParamData.MTtlSalesSlipWork", "MTTLSALESSLIPRF")
        {

        }

        /// <summary>
        /// �A�v���P�[�V���� ���b�N���s���ۂ̃��\�[�X�����擾���܂��B
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <returns>���b�N ���\�[�X��</returns>
        private string GetLockResourceName(MTtlSalesUpdParaWork mTtlSalesUpdParaWork)
        {
            return this.GetResourceName(mTtlSalesUpdParaWork.EnterpriseCode);
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
        /// �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^��ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="newSalesSlips">�ǉ��E�X�V���锄��`�[�f�[�^</param>
        /// <param name="oldSalesSlips">�o�^�O�̔���`�[�f�[�^</param>
        /// <param name="connection">�o�^�O�̔���`�[�f�[�^</param>
        /// <param name="transaction">�o�^�O�̔���`�[�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^��ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.05.19</br>
        public int Write(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, ArrayList newSalesSlips, ArrayList oldSalesSlips, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            # region [�p�����[�^�[�`�F�b�N]

            if (mTtlSalesUpdParaWork == null)
            {
                return status;
            }

            if (newSalesSlips == null)
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

#if !DEBUG
            // �r�����b�N���s��
            status = this.Lock(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }
#endif

            try
            {
                ArrayList totaledSalesSlips = null;
                
                // ����`�[�f�[�^ ���O�W�v����
                if (mTtlSalesUpdParaWork.MTtlSalesPrcFlg == 1 || mTtlSalesUpdParaWork.GoodsMTtlSaPrcFlg == 1)
                {
                    status = this.PreTotal(newSalesSlips, oldSalesSlips, out totaledSalesSlips);

                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        return status;
                    }
                }

                if (ListUtils.IsNotEmpty(totaledSalesSlips))
                {
                    // ���㌎���W�v�f�[�^�X�V����
                    if (mTtlSalesUpdParaWork.MTtlSalesPrcFlg == 1)
                    {
                        status = this.WriteMTtlSales(mTtlSalesUpdParaWork, totaledSalesSlips, connection, transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                    }

                    // ���i�ʔ��㌎���W�v�f�[�^�X�V����
                    if (mTtlSalesUpdParaWork.GoodsMTtlSaPrcFlg == 1)
                    {
                        status = this.WriteGoodsMTtlSales(mTtlSalesUpdParaWork, totaledSalesSlips, connection, transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                    }
                }
            }
            finally
            {
#if !DEBUG
                // �r�����b�N��������� ���߂�l�̓X���[
                this.Release(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
#endif

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
        /// ����`�[�f�[�^ ���O�W�v����
        /// </summary>
        /// <param name="newSalesSlips">�o�^��̔���`�[�f�[�^</param>
        /// <param name="oldSalesSlips">�o�^�O�̔���`�[�f�[�^</param>
        /// <param name="ttlSalesSlips">���O�W�v��̔���`�[�f�[�^</param>
        /// <returns>STATUS</returns>
        private int PreTotal(ArrayList newSalesSlips, ArrayList oldSalesSlips, out ArrayList ttlSalesSlips)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            ttlSalesSlips = new ArrayList();

            try
            {
                ArrayList newSlip = null;          // �o�^�� ����`�[�f�[�^(����f�[�^�{���㖾�׃f�[�^)
                SalesSlipWork newHeader = null;    // �o�^�� ����f�[�^
                ArrayList newDetails = null;       // �o�^�� ���㖾�׃f�[�^(�S���ו�)

                SalesSlipWork oldHeader = null;    // �o�^�O ����f�[�^
                ArrayList oldDetails = null;       // �o�^�O ���㖾�׃f�[�^(�S���ו�)
                
                // �X�V���"����f�[�^"����W�v�Ώۂ𒊏o
                if (ListUtils.IsNotEmpty(newSalesSlips))
                {
                    foreach (object item in newSalesSlips)
                    {
                        if (item is ArrayList)
                        {
                            newHeader = ListUtils.Find((item as ArrayList), typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                            newDetails = ListUtils.Find((item as ArrayList), typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                            if (newHeader != null && newDetails != null && newHeader.AcptAnOdrStatus == 30)  // ����̂ݏW�v�ΏۂƂ���
                            {
                                ArrayList clnSlip = new ArrayList();  // ������
                                ArrayList clnDtls = new ArrayList();  // ���㖾�׏�񃊃X�g
                                ArrayList clnAdds = new ArrayList();  // ���גǉ���񃊃X�g(�_�~�[)

                                SalesSlipWork clnHeader = newHeader.Clone();
                                clnSlip.Add(clnHeader);
                                clnSlip.Add(clnDtls);
                                clnSlip.Add(clnAdds);
                                
                                foreach (SalesDetailWork newDetail in newDetails)
                                {
                                    // ����`�[�敪(����)�� 0:���� 1:�ԕi 2:�l�� �̖��ׂ������W�v�ΏۂƂ���
                                    switch (newDetail.SalesSlipCdDtl)
                                    {
                                        case 0:  // ����
                                        case 1:  // �ԕi
                                        case 2:  // �l��
                                            {
                                                SalesDetailWork clnDetail = newDetail.Clone();
                                                clnDetail.ShipmCntDifference = 0;
                                                clnDtls.Add(clnDetail);
                                                break;
                                            }
                                    }
                                }

                                ttlSalesSlips.Add(clnSlip);
                            }
                        }
                    }
                }

                // �X�V�O�̔���f�[�^�����݂���ꍇ�ɂ̂ݎ��O�W�v���s��
                // ��oldSalesSlips �ԕi�`�[�̌��`�[���ݒ肳�ꂽ�ꍇ�A�W�v��������
                //�@ ���E����Ă��܂��̂Ōďo�����Ō��`�[��ݒ肵�Ȃ��l�ɒ��ӂ���
                if (ListUtils.IsNotEmpty(oldSalesSlips))
                {
                    SalesHeaderComparer SalesHdrComp = new SalesHeaderComparer();
                    SalesDetailComparer SalesDtlComp = new SalesDetailComparer();

                    foreach (ArrayList oldslip in oldSalesSlips)
                    {
                        if (ListUtils.IsNotEmpty(oldslip))
                        {
                            oldHeader = ListUtils.Find(oldslip, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                            oldDetails = ListUtils.Find(oldslip, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                            if (oldHeader != null && oldDetails != null && oldHeader.AcptAnOdrStatus ==30)
                            {
                                if (oldHeader.DebitNoteDiv == 2)
                                {
                                    // �����͏W�v�Ώۂ��珜�O����
                                    continue;
                                }

                                # region [--- DEL 2009/01/20 M.Kubota --- ����`�[�̃w�b�_�[����ύX�����ۂ̓o�^�s��Ή�]
                                //ttlSalesSlips.Sort(SalesHdrComp);
                                
                                //int salesIndex = ttlSalesSlips.BinarySearch(oldslip, SalesHdrComp);

                                //if (salesIndex > -1)
                                //{
                                //    // ����L�[�̔���`�[�f�[�^�����݂���ꍇ
                                //    newSlip = ttlSalesSlips[salesIndex] as ArrayList;
                                //    newHeader = ListUtils.Find(newSlip, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                                //    newDetails = ListUtils.Find(newSlip, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                                //    foreach (SalesDetailWork oldDetail in oldDetails)
                                //    {
                                //        newDetails.Sort(SalesDtlComp);
                                //        int detailIndex = newDetails.BinarySearch(oldDetail, SalesDtlComp);

                                //        if (detailIndex > -1)
                                //        {
                                //            // ����L�[�̔��㖾�׃f�[�^�����݂���ꍇ �� ���ׂ̓��e���ύX���ꂽ or �����ς���Ă��Ȃ�
                                //            SalesDetailWork newDetail = newDetails[detailIndex] as SalesDetailWork;

                                //            newDetail.ShipmentCnt -= oldDetail.ShipmentCnt;            // �o�א� �̕ϓ������l���Z�o����
                                //            newDetail.Cost -= oldDetail.Cost;                          // ���� �̕ϓ������l���Z�o����
                                //            newDetail.SalesMoneyTaxExc -= oldDetail.SalesMoneyTaxExc;  // ������z(�Ŕ�) �̕ϓ������l���Z�o����

                                //            newDetail.ShipmCntDifference = 1;                          // <�d�v> �o�׍������� 1 ��ݒ肷�鎖�ɂ��A"�o�^�ςݖ���"�Ƃ���
                                //        }
                                //        else
                                //        {
                                //            // ����L�[�̔��㖾�׃f�[�^�����݂��Ȃ��ꍇ �� ���ׂ��폜���ꂽ
                                //            // ����`�[�敪(����)�� 0:���� 1:�ԕi 2:�l�� �̖��ׂ������W�v�ΏۂƂ���
                                //            switch (oldDetail.SalesSlipCdDtl)
                                //            {
                                //                case 0:  // ����
                                //                case 1:  // �ԕi
                                //                case 2:  // �l��
                                //                    {
                                //                        SalesDetailWork clnDetail = oldDetail.Clone();
                                //                        clnDetail.ShipmentCnt *= -1;                               // �o�א� �̕����𔽓]������
                                //                        clnDetail.Cost *= -1;                                      // ���� �̕����𔽓]������
                                //                        clnDetail.SalesMoneyTaxExc *= -1;                          // ������z(�Ŕ�) �̕����𔽓]������

                                //                        clnDetail.ShipmCntDifference = -1;                         // <�d�v> �o�׍������� -1 ��ݒ肷�鎖�ɂ��A"�폜���ꂽ����"�Ƃ���
                                //                        newDetails.Add(clnDetail);                                 // �폜���ꂽ���Ƃ��Ēǉ�����
                                //                        break;
                                //                    }
                                //            }
                                //        }
                                //    }
                                //}
                                //else
                                //{
                                //    // �o�^�O ����`�[�f�[�^���A�o�^�� ����`�[�f�[�^�̒��Ɋ܂܂�Ă��Ȃ��ꍇ�A�`�[�폜�Ƃ��Ĉ����B
                                //    ArrayList wrkSlip = new ArrayList();
                                //    ArrayList wrkDetails = new ArrayList();

                                //    SalesSlipWork clnHeader = oldHeader.Clone();
                                //    wrkSlip.Add(clnHeader);
                                //    wrkSlip.Add(wrkDetails);

                                //    foreach (SalesDetailWork oldDetail in oldDetails)
                                //    {
                                //        // ����`�[�敪(����)�� 0:���� 1:�ԕi 2:�l�� �̖��ׂ������W�v�ΏۂƂ���
                                //        switch (oldDetail.SalesSlipCdDtl)
                                //        {
                                //            case 0:  // ����
                                //            case 1:  // �ԕi
                                //            case 2:  // �l��
                                //                {
                                //                    SalesDetailWork clnDetail = oldDetail.Clone();
                                //                    clnDetail.ShipmCntDifference = 0;                              // <�d�v> �`�[�폜�̏ꍇ�ɂ͏o�׍������� 0 ��ݒ肷��(��q�����̒��덇�킹)
                                //                    wrkDetails.Add(clnDetail);
                                //                    break;
                                //                }
                                //        }
                                //    }

                                //    ttlSalesSlips.Add(wrkSlip);
                                //}
                                # endregion

                                //--- ADD 2009/01/20 M.Kubota --->>>
                                // ��r�Ώۍ��ڂ��g��(��ƃR�[�h�E�󒍃X�e�[�^�X�E����`�[�ԍ��{��)����
                                SalesHdrComp.AdvancedMode = true;
                                ttlSalesSlips.Sort(SalesHdrComp);
                                int salesIndex = ttlSalesSlips.BinarySearch(oldslip, SalesHdrComp);

                                if (salesIndex > -1)
                                {
                                    # region [�w�b�_�����܂߂ē���̔���`�[�f�[�^�����݂���ꍇ]
                                    // ����L�[�̔���`�[�f�[�^�����݂���ꍇ
                                    newSlip = ttlSalesSlips[salesIndex] as ArrayList;
                                    newHeader = ListUtils.Find(newSlip, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                                    newDetails = ListUtils.Find(newSlip, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                                    foreach (SalesDetailWork oldDetail in oldDetails)
                                    {
                                        newDetails.Sort(SalesDtlComp);
                                        int detailIndex = newDetails.BinarySearch(oldDetail, SalesDtlComp);

                                        if (detailIndex > -1)
                                        {
                                            // ����L�[�̔��㖾�׃f�[�^�����݂���ꍇ �� ���ׂ̓��e���ύX���ꂽ or �����ς���Ă��Ȃ�
                                            SalesDetailWork newDetail = newDetails[detailIndex] as SalesDetailWork;

                                            newDetail.ShipmentCnt -= oldDetail.ShipmentCnt;            // �o�א� �̕ϓ������l���Z�o����
                                            newDetail.Cost -= oldDetail.Cost;                          // ���� �̕ϓ������l���Z�o����
                                            newDetail.SalesMoneyTaxExc -= oldDetail.SalesMoneyTaxExc;  // ������z(�Ŕ�) �̕ϓ������l���Z�o����

                                            newDetail.ShipmCntDifference = 1;                          // <�d�v> �o�׍������� 1 ��ݒ肷�鎖�ɂ��A"�o�^�ςݖ���"�Ƃ���
                                        }
                                        else
                                        {
                                            // ����L�[�̔��㖾�׃f�[�^�����݂��Ȃ��ꍇ �� ���ׂ��폜���ꂽ
                                            // ����`�[�敪(����)�� 0:���� 1:�ԕi 2:�l�� �̖��ׂ������W�v�ΏۂƂ���
                                            switch (oldDetail.SalesSlipCdDtl)
                                            {
                                                case 0:  // ����
                                                case 1:  // �ԕi
                                                case 2:  // �l��
                                                    {
                                                        SalesDetailWork clnDetail = oldDetail.Clone();
                                                        clnDetail.ShipmentCnt *= -1;                   // �o�א� �̕����𔽓]������
                                                        clnDetail.Cost *= -1;                          // ���� �̕����𔽓]������
                                                        clnDetail.SalesMoneyTaxExc *= -1;              // ������z(�Ŕ�) �̕����𔽓]������

                                                        clnDetail.ShipmCntDifference = -1;             // <�d�v> �o�׍������� -1 ��ݒ肷�鎖�ɂ��A"�폜���ꂽ����"�Ƃ���
                                                        newDetails.Add(clnDetail);                     // �폜���ꂽ���Ƃ��Ēǉ�����
                                                        break;
                                                    }
                                            }
                                        }
                                    }
                                    # endregion
                                }
                                else
                                {
                                    // ��r�Ώۍ��ڂ��k��(��ƃR�[�h�E�󒍃X�e�[�^�X�E����`�[�ԍ�)����
                                    SalesHdrComp.AdvancedMode = false;  
                                    ttlSalesSlips.Sort(SalesHdrComp);
                                    salesIndex = ttlSalesSlips.BinarySearch(oldslip, SalesHdrComp);

                                    if (salesIndex > -1)
                                    {
                                        # region [�w�b�_���ɕύX���������ꍇ]
                                        ArrayList wrkSlip = new ArrayList();
                                        ArrayList wrkDetails = new ArrayList();

                                        SalesSlipWork wrkHeader = oldHeader.Clone();
                                        wrkSlip.Add(wrkHeader);
                                        wrkSlip.Add(wrkDetails);

                                        foreach (SalesDetailWork oldDetail in oldDetails)
                                        {
                                            // ����`�[�敪(����)�� 0:���� 1:�ԕi 2:�l�� �̖��ׂ������W�v�ΏۂƂ���
                                            switch (oldDetail.SalesSlipCdDtl)
                                            {
                                                case 0:  // ����
                                                case 1:  // �ԕi
                                                case 2:  // �l��
                                                    {
                                                        SalesDetailWork clnDetail = oldDetail.Clone();
                                                        clnDetail.ShipmentCnt *= -1;                    // �o�א� �̕����𔽓]������
                                                        clnDetail.Cost *= -1;                           // ���� �̕����𔽓]������
                                                        clnDetail.SalesMoneyTaxExc *= -1;               // ������z(�Ŕ�) �̕����𔽓]������
                                                        clnDetail.ShipmCntDifference = -1;              // <�d�v> �o�׍������� -1 ��ݒ肷�鎖�ɂ��A"�폜���ꂽ����"�Ƃ���
                                                        wrkDetails.Add(clnDetail);                      // �폜���ꂽ���Ƃ��Ēǉ�����
                                                        break;
                                                    }
                                            }
                                        }

                                        ttlSalesSlips.Add(wrkSlip);
                                        # endregion
                                    }
                                    else
                                    {
                                        # region [�`�[���폜���ꂽ�ꍇ]
                                        // �o�^�O ����`�[�f�[�^���A�o�^�� ����`�[�f�[�^�̒��Ɋ܂܂�Ă��Ȃ��ꍇ�A�`�[�폜�Ƃ��Ĉ����B
                                        ArrayList wrkSlip = new ArrayList();
                                        ArrayList wrkDetails = new ArrayList();

                                        SalesSlipWork wrkHeader = oldHeader.Clone();
                                        wrkSlip.Add(wrkHeader);
                                        wrkSlip.Add(wrkDetails);

                                        foreach (SalesDetailWork oldDetail in oldDetails)
                                        {
                                            // ����`�[�敪(����)�� 0:���� 1:�ԕi 2:�l�� �̖��ׂ������W�v�ΏۂƂ���
                                            switch (oldDetail.SalesSlipCdDtl)
                                            {
                                                case 0:  // ����
                                                case 1:  // �ԕi
                                                case 2:  // �l��
                                                    {
                                                        SalesDetailWork clnDetail = oldDetail.Clone();
                                                        clnDetail.ShipmCntDifference = 0;               // <�d�v> �`�[�폜�̏ꍇ�ɂ͏o�׍������� 0 ��ݒ肷��(��q�����̒��덇�킹)
                                                        wrkDetails.Add(clnDetail);
                                                        break;
                                                    }
                                            }
                                        }

                                        ttlSalesSlips.Add(wrkSlip);
                                        # endregion
                                    }
                                }
                                //--- ADD 2009/01/20 M.Kubota ---<<<
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
        /// ���㌎���W�v�f�[�^ �W�v�E�o�^����
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="totaledSalesSlips">���O�W�v�ςݔ���`�[�f�[�^���X�g</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <remarks>���O�W�v���I��������`�[�f�[�^���W�v���A���㌎���W�v�f�[�^�֒ǉ��E�X�V���s���܂��B</remarks>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2020/08/28 �c����</br>
        /// <br>             PMKOBETSU-4076 �^�C���A�E�g�ݒ�</br>
        private int WriteMTtlSales(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, ArrayList totaledSalesSlips, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ���t�擾���i�̃C���X�^���X���擾
            FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlSalesUpdParaWork.EnterpriseCode));
            
            // ���㌎���W�v�f�[�^��r�p�N���X�̃C���X�^���X���擾
            //MTtlSalesSlipComparer mTtlSalesSlipComparer = new MTtlSalesSlipComparer();  // DEL 2010/05/13 ���g�p�̂��ߍ폜

            // �o�^�E�X�V�ΏۂƂȂ锄�㌎���W�v�f�[�^��ێ�����z��
            // -- UPD 2010/03/30 ------------------>>>
            //ArrayList MTtlSalesList = new ArrayList();
            Dictionary<string, MTtlSalesSlipWork> MTtlSalesDic = new Dictionary<string, MTtlSalesSlipWork>();
            // -- UPD 2010/03/30 ------------------<<<
            MTtlSalesSlipWork mTtlSalesSlipWork = null;

            // �`�[�o�^���ɂ͉��Z�A�`�[�폜���ɂ͌��Z���s��
            int sign = (mTtlSalesUpdParaWork.SlipRegDiv == 0) ? -1 : 1;

            # region [���㌎���W�v����]
            foreach (ArrayList slip in totaledSalesSlips)
            {
                SalesSlipWork header = ListUtils.Find(slip, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                ArrayList details = ListUtils.Find(slip, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                if (header == null || ListUtils.IsEmpty(details))
                {
                    continue;
                }

                foreach (SalesDetailWork detail in details)
                {
                    // [�g�p�t���O(0:�o�^�s�� 1:���яW�v�敪�N���A 2:�]�ƈ��R�[�h�N���A 3:�o�^�\), ���㌎���W�v�f�[�^] �����Q�����z��𐶐�
                    object[,] MTtlSalesSlipArray = new object[12, 2];

                    for (int index = 0; index < MTtlSalesSlipArray.GetLength(0); index++)
                    {
                        mTtlSalesSlipWork = new MTtlSalesSlipWork();

                        # region [�L�[���ڂ̐ݒ�]
                        // �L�[���ڂ̐ݒ�
                        MTtlSalesSlipArray[index, 0] = 0;
                        MTtlSalesSlipArray[index, 1] = mTtlSalesSlipWork;

                        mTtlSalesSlipWork.EnterpriseCode = detail.EnterpriseCode;        // ��ƃR�[�h
                        mTtlSalesSlipWork.LogicalDeleteCode = detail.LogicalDeleteCode;  // �_���폜�t���O
                        mTtlSalesSlipWork.AddUpSecCode = header.ResultsAddUpSecCd;       // �v�㋒�_�R�[�h �� ���ьv�㋒�_�R�[�h

                        // ���яW�v�敪 (0:���i���v 1:�݌� 2:���� 3:���)
                        mTtlSalesSlipWork.RsltTtlDivCd = (int)index / 3;

                        switch (mTtlSalesSlipWork.RsltTtlDivCd)
                        {
                            case 0:
                                {
                                    // ���㏤�i�敪 = 0:���i
                                    if (detail.SalesGoodsCd == 0)
                                    {
                                        MTtlSalesSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    // �݌ɍX�V�敪
                                    # region [--- DEL 2009/01/20 M.Kubota --- ���i�l�����W�v�ΏۂƂ���ׂ�"�݌�"�̔�����@��ύX]
                                    //if (detail.StockUpdateDiv)
                                    //{
                                    //    MTtlSalesSlipArray[index, 0] = 1;
                                    //}
                                    # endregion

                                    //--- ADD 2009/01/20 M.Kubota --->>>
                                    // "�݌�"�ɏW�v�������
                                    // �@ �q�ɃR�[�h���ݒ肳��Ă���
                                    // �A ����݌Ɏ�񂹋敪�� 1:�݌�
                                    // �B �o�א���0�ȊO
                                    // �C ����`�[�敪(����)�� 0:���� 1:�ԕi 2:�l�� �̏ꍇ
                                    if (!string.IsNullOrEmpty(detail.WarehouseCode) &&
                                         detail.SalesOrderDivCd == 1 &&
                                         detail.ShipmentCnt != 0 &&
                                        (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || detail.SalesSlipCdDtl == 2))
                                    {
                                        MTtlSalesSlipArray[index, 0] = 1;
                                    }
                                    //--- ADD 2009/01/20 M.Kubota ---<<<
                                    break;
                                }
                            case 2:
                                {
                                    // ���i���� = 0:����
                                    if (detail.GoodsKindCode == 0)
                                    {
                                        MTtlSalesSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    // ����`�[�敪(����) = 5:���
                                    //if (detail.SalesSlipCdDtl == 1)  //DEL 2009/01/20 M.Kubota
                                    if (detail.SalesSlipCdDtl == 5)    //ADD 2009/01/20 M.Kubota
                                    {
                                        MTtlSalesSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                        }

                        // �]�ƈ��敪 (10:�̔��S���� 20:��t�S���� 30:���͒S����)
                        mTtlSalesSlipWork.EmployeeDivCd = (index % 3 + 1) * 10;

                        switch (mTtlSalesSlipWork.EmployeeDivCd)
                        {
                            case 10:
                                {
                                    // 2009/03/04 �Ώۂ̏]�ƈ��R�[�h�������͂̏ꍇ�����R�[�h���쐬���� >>>>>>>>>>>>
                                    // MANTIS 12019
                                    //if (!string.IsNullOrEmpty(header.SalesEmployeeCd))
                                    //{
                                        //// �]�ƈ��R�[�h �� �̔��]�ƈ��R�[�h
                                        //mTtlSalesSlipWork.EmployeeCode = header.SalesEmployeeCd;
                                        //MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    //}

                                    // �]�ƈ��R�[�h �� �̔��]�ƈ��R�[�h
                                    mTtlSalesSlipWork.EmployeeCode = header.SalesEmployeeCd;
                                    MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                    break;
                                }
                            case 20:
                                {
                                    // 2009/03/04 �Ώۂ̏]�ƈ��R�[�h�������͂̏ꍇ�����R�[�h���쐬���� >>>>>>>>>>>>
                                    // MANTIS 12019
                                    //if (!string.IsNullOrEmpty(header.FrontEmployeeCd))
                                    //{
                                    //    // �]�ƈ��R�[�h �� ��t�]�ƈ��R�[�h
                                    //    mTtlSalesSlipWork.EmployeeCode = header.FrontEmployeeCd;
                                    //    MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    //}

                                    // �]�ƈ��R�[�h �� ��t�]�ƈ��R�[�h
                                    mTtlSalesSlipWork.EmployeeCode = header.FrontEmployeeCd;
                                    MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                    break;
                                }
                            case 30:
                                {
                                    // 2009/03/04 �Ώۂ̏]�ƈ��R�[�h�������͂̏ꍇ�����R�[�h���쐬���� >>>>>>>>>>>>
                                    // MANTIS 12019
                                    //if (!string.IsNullOrEmpty(header.SalesInputCode))
                                    //{
                                    //    // �]�ƈ��R�[�h �� ������͎҃R�[�h
                                    //    mTtlSalesSlipWork.EmployeeCode = header.SalesInputCode;
                                    //    MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    //}

                                    // �]�ƈ��R�[�h �� ������͎҃R�[�h
                                    mTtlSalesSlipWork.EmployeeCode = header.SalesInputCode;
                                    MTtlSalesSlipArray[index, 0] = ((int)MTtlSalesSlipArray[index, 0]) + 2;
                                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                    break;
                                }
                        }

                        mTtlSalesSlipWork.CustomerCode = header.CustomerCode;  // ���Ӑ�R�[�h
                        mTtlSalesSlipWork.SupplierCd = detail.SupplierCd;      // �d����R�[�h
                        mTtlSalesSlipWork.SalesCode = detail.SalesCode;        // �̔��敪�R�[�h

                        # endregion

                        # region [�W�v���ڂ̐ݒ�]
                        if ((int)MTtlSalesSlipArray[index, 0] == 3)
                        {
                            // �������莩�В��̔N���x���擾 �����S���|�鎖���\�z����邽�߁A�o�^�\�ȃ��R�[�h�ɂ̂ݐݒ肷��
                            DateTime AddUpDate;
                            dateGetAcs.GetYearMonth(detail.SalesDate, out AddUpDate);
                            mTtlSalesSlipWork.AddUpYearMonth = AddUpDate;                    // �v��N��

                            // �o�׉�
                            //if (header.DebitNoteDiv == 0 && header.SalesSlipCd == 0 && detail.SalesSlipCdDtl == 0)   // DEL 2009/12/24
                            if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 2) && header.SalesSlipCd == 0 && detail.SalesSlipCdDtl == 0)     // ADD 2009/12/24
                            {
                                if (detail.ShipmCntDifference != 1)
                                {
                                    // ���דo�^�̏ꍇ�͉��Z�A���׍폜�̏ꍇ�͌��Z���s��
                                    int value = (detail.ShipmCntDifference == 0) ? 1 : -1;

                                    // "����"�̖��ׂ݂̂��W�v�̑ΏۂƂ��܂��A�܂��`�[�폜���ɂ͌��Z���܂�
                                    mTtlSalesSlipWork.SalesTimes += sign * value;  // �o�׉�
                                }
                            }   

                            // ���㐔�v
                            //if (header.DebitNoteDiv == 0 && detail.SalesSlipCdDtl == 0)                                //DEL 2009/01/20 M.Kubota
                            // 2009/03/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //�ԓ`�A���i�l�������ɐ��ʂ����Z����Ȃ��s��̏C��
                            //if (header.DebitNoteDiv == 0 && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1))  //ADD 2009/01/20 M.Kubota  �ԕi�������㐔�v�̏W�v�ΏۂƂ���
                            //if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1) && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || (detail.SalesSlipCdDtl == 2 && detail.ShipmentCnt != 0)))  //ADD 2009/01/20 M.Kubota  �ԕi�������㐔�v�̏W�v�ΏۂƂ���  // DEL 2009/12/24
                            if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1 || header.DebitNoteDiv == 2) && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || (detail.SalesSlipCdDtl == 2 && detail.ShipmentCnt != 0)))  //ADD 2009/01/20 M.Kubota  �ԕi�������㐔�v�̏W�v�ΏۂƂ���  // ADD 2009/12/24
                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            {
                                # region [--- DEL 2009/01/20 M.Kubota --- �ԕi�̏ꍇ�A���ʂ��}�C�i�X�l�Ŋi�[����Ă���̂ŕ������]����(value)���폜]
                                // ����`�[�敪�� 0:���� �̏ꍇ�͉��Z�A1:�ԕi �̏ꍇ�͌��Z���s��
                                //int value = (header.SalesSlipCd == 0) ? 1 : -1;
                                //mTtlSalesSlipWork.TotalSalesCount += sign * value * detail.ShipmentCnt;  // ���㐔�v
                                # endregion
                                
                                mTtlSalesSlipWork.TotalSalesCount += sign * detail.ShipmentCnt;  // ���㐔�v  //ADD 2009/01/20 M.Kubota
                            }

                            if (header.SalesSlipCd == 0)
                            {
                                switch (detail.SalesSlipCdDtl)
                                {
                                    case 0:  // 0:����
                                        {
                                            // ������z
                                            mTtlSalesSlipWork.SalesMoney = sign * detail.SalesMoneyTaxExc;

                                            // �e�����z
                                            mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            break;
                                        }
                                    case 1:  // 1:�ԕi
                                        {
                                            // �ԕi�z
                                            mTtlSalesSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;

                                            // �e�����z
                                            mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            break;
                                        }
                                    case 2:  // 2:�l��
                                        {
                                            // PM7�̎d�l�ɍ��킹�čs�l���͏W�v�ΏۊO�Ƃ���B
                                            // ���s�l���Ə��i�l���̔��f��UI�Ɠ��l�ɐ��ʂ̗L��(!=0)�Ŕ��f����
                                            if (detail.ShipmentCnt != 0)  //ADD 2009/01/20 M.Kubota
                                            {
                                                // �l�����z
                                                mTtlSalesSlipWork.DiscountPrice = sign * detail.SalesMoneyTaxExc;

                                                // �e�����z
                                                mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);
                                            }
                                            // 2009/03/04 ����̍s�l���͔�����z�ɔ��f���� >>>>>>>>>>>>>>>>>
                                            else
                                            {
                                                // ������z
                                                mTtlSalesSlipWork.SalesMoney = sign * detail.SalesMoneyTaxExc;
                                                // �e�����z
                                                mTtlSalesSlipWork.GrossProfit = sign * detail.SalesMoneyTaxExc;
                                            }
                                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                            break;
                                        }
                                }
                            }
                            else  if (header.SalesSlipCd == 1)
                            {
                                //2009/02/05 >>>>>>>>>>>>>>>>>>>>>>>>>
                                // Mantis 11169�̑Ή� �ԕi�`�[�̍s�l�����z��l�������z�ɃZ�b�g����(�֘AID:11102)

                                //// �ԕi�z
                                //mTtlSalesSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                //// �e�����z
                                //mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                switch (detail.SalesSlipCdDtl)
                                {
                                    case 1:  // 1:�ԕi
                                        {
                                            // �ԕi�z
                                            mTtlSalesSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                            // �e�����z
                                            mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            break;
                                        }
                                    case 2:  // 2:�l��
                                        {

                                            // ���s�l���Ə��i�l���̔��f��UI�Ɠ��l�ɐ��ʂ̗L��(!=0)�Ŕ��f����
                                            if (detail.ShipmentCnt != 0)
                                            {
                                                // �l�����z
                                                mTtlSalesSlipWork.DiscountPrice = sign * detail.SalesMoneyTaxExc;

                                                // �e�����z
                                                mTtlSalesSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);
                                            }
                                            // 2009/03/04 �ԕi�̍s�l���͕ԕi���z�ɔ��f���� >>>>>>>>>>>>>>>>>
                                            else
                                            {
                                                // �ԕi�z
                                                mTtlSalesSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                                // �e�����z
                                                mTtlSalesSlipWork.GrossProfit = sign * detail.SalesMoneyTaxExc;
                                            }
                                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                                            break;
                                        }
                                }
                                //2009/02/05 <<<<<<<<<<<<<<<<<<<<<<<<<

                            }

                            // -- DEL 2010/03/30 ----------------------->>>
                            //MTtlSalesList.Sort(mTtlSalesSlipComparer);

                            //int SearchIndex = MTtlSalesList.BinarySearch(mTtlSalesSlipWork, mTtlSalesSlipComparer);
                            // -- DEL 2010/03/30 -----------------------<<<

                            // -- UPD 2010/03/30 ---------------------------------------->>>
                            //if (SearchIndex < 0)
                            //{
                            //    // ����L�[�����݂��Ȃ��ꍇ�͓o�^���X�g�ɒǉ�����
                            //    MTtlSalesList.Add(mTtlSalesSlipWork);
                            //}
                            //else
                            //{
                            //    // ����L�[�����݂��Ă���ꍇ�͏W�v���ڂ����Z����
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).SalesTimes += mTtlSalesSlipWork.SalesTimes;                  // �����
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).TotalSalesCount += mTtlSalesSlipWork.TotalSalesCount;        // ���㐔�v
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).SalesMoney += mTtlSalesSlipWork.SalesMoney;                  // ������z
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).SalesRetGoodsPrice += mTtlSalesSlipWork.SalesRetGoodsPrice;  // �ԕi���z  //ADD 2009/01/20 M.Kubota
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).DiscountPrice += mTtlSalesSlipWork.DiscountPrice;            // �l�����z
                            //    (MTtlSalesList[SearchIndex] as MTtlSalesSlipWork).GrossProfit += mTtlSalesSlipWork.GrossProfit;                // �e�����z
                            //}

                            if (!MTtlSalesDic.ContainsKey(MakeKeyMTtlSalesSlip(mTtlSalesSlipWork)))
                            {
                                // ����L�[�����݂��Ȃ��ꍇ�͓o�^���X�g�ɒǉ�����
                                MTtlSalesDic.Add(MakeKeyMTtlSalesSlip(mTtlSalesSlipWork), mTtlSalesSlipWork);
                            }
                            else
                            {
                                MTtlSalesSlipWork work = MTtlSalesDic[MakeKeyMTtlSalesSlip(mTtlSalesSlipWork)];
                                // ����L�[�����݂��Ă���ꍇ�͏W�v���ڂ����Z����
                                work.SalesTimes += mTtlSalesSlipWork.SalesTimes;                  // �����
                                work.TotalSalesCount += mTtlSalesSlipWork.TotalSalesCount;        // ���㐔�v
                                work.SalesMoney += mTtlSalesSlipWork.SalesMoney;                  // ������z
                                work.SalesRetGoodsPrice += mTtlSalesSlipWork.SalesRetGoodsPrice;  // �ԕi���z 
                                work.DiscountPrice += mTtlSalesSlipWork.DiscountPrice;            // �l�����z
                                work.GrossProfit += mTtlSalesSlipWork.GrossProfit;                // �e�����z
                            }
                            // -- UPD 2010/03/30 ----------------------------------------<<<
                        }
                        # endregion
                    }
                }
            }
            # endregion

            # region [���㌎���W�v�f�[�^�o�^]

            string sqlText = string.Empty;
            SqlCommand command = new SqlCommand(sqlText, connection, transaction);
            SqlDataReader reader = null;
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
            int dbCommandTimeout = DB_COMMAND_TIMEOUT; // �R�}���h�^�C���A�E�g�i�b�j
            this.GetXmlInfo(ref dbCommandTimeout);
            // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<
            try
            {
                // -- UPD 2010/03/30 -------------------------->>>
                //foreach (MTtlSalesSlipWork item in MTtlSalesList)
                foreach (MTtlSalesSlipWork item in MTtlSalesDic.Values)
                // -- UPD 2010/03/30 --------------------------<<<
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
                    sqlText += " ,MTTL.ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,MTTL.ADDUPYEARMONTHRF" + Environment.NewLine;
                    sqlText += " ,MTTL.RSLTTTLDIVCDRF" + Environment.NewLine;
                    sqlText += " ,MTTL.EMPLOYEEDIVCDRF" + Environment.NewLine;
                    sqlText += " ,MTTL.EMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,MTTL.CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,MTTL.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,MTTL.SALESCODERF" + Environment.NewLine;
                    sqlText += " ,MTTL.SALESTIMESRF" + Environment.NewLine;
                    sqlText += " ,MTTL.TOTALSALESCOUNTRF" + Environment.NewLine;
                    sqlText += " ,MTTL.SALESMONEYRF" + Environment.NewLine;
                    sqlText += " ,MTTL.SALESRETGOODSPRICERF" + Environment.NewLine;
                    sqlText += " ,MTTL.DISCOUNTPRICERF" + Environment.NewLine;
                    sqlText += " ,MTTL.GROSSPROFITRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  MTTLSALESSLIPRF AS MTTL" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  MTTL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND MTTL.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "  AND MTTL.ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  AND MTTL.ADDUPYEARMONTHRF = @FINDADDUPYEARMONTH" + Environment.NewLine;
                    sqlText += "  AND MTTL.RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                    sqlText += "  AND MTTL.EMPLOYEEDIVCDRF = @FINDEMPLOYEEDIVCD" + Environment.NewLine;
                    sqlText += "  AND MTTL.EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "  AND MTTL.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "  AND MTTL.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                    sqlText += "  AND MTTL.SALESCODERF = @FINDSALESCODE" + Environment.NewLine;
                    command.CommandText = sqlText;
                    command.Parameters.Clear();
                    # endregion

                    # region [�����p �p�����[�^�I�u�W�F�N�g�̍쐬]
                    SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter findAddUpSecCode = command.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);      // �v�㋒�_�R�[�h
                    SqlParameter findAddUpYearMonth = command.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);    // �v��N��
                    SqlParameter findRsltTtlDivCd = command.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);        // ���яW�v�敪
                    SqlParameter findEmployeeDivCd = command.Parameters.Add("@FINDEMPLOYEEDIVCD", SqlDbType.Int);      // �]�ƈ��敪
                    SqlParameter findEmployeeCode = command.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);      // �]�ƈ��R�[�h
                    SqlParameter findCustomerCode = command.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);        // ���Ӑ�R�[�h
                    SqlParameter findSupplierCd = command.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);            // �d����R�[�h
                    SqlParameter findSalesCode = command.Parameters.Add("@FINDSALESCODE", SqlDbType.Int);              // �̔��敪�R�[�h
                    # endregion

                    # region [�����p �p�����[�^�I�u�W�F�N�g�̒l�ݒ�]
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);              // ��ƃR�[�h
                    findAddUpSecCode.Value = SqlDataMediator.SqlSetString(item.AddUpSecCode);                  // �v�㋒�_�R�[�h
                    findAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth);  // �v��N��
                    findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // ���яW�v�敪
                    findEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(item.EmployeeDivCd);                 // �]�ƈ��敪
                    // 2009/03/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                    // MANTIS 12019
                    //findEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // �]�ƈ��R�[�h
                    findEmployeeCode.Value = item.EmployeeCode;                  // �]�ƈ��R�[�h
                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(item.CustomerCode);                   // ���Ӑ�R�[�h
                    findSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // �d����R�[�h
                    findSalesCode.Value = SqlDataMediator.SqlSetInt32(item.SalesCode);                         // �̔��敪�R�[�h
                    # endregion

                    command.CommandTimeout = dbCommandTimeout;  //ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή�
                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE MTTLSALESSLIPRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,ADDUPYEARMONTHRF = @ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += " ,RSLTTTLDIVCDRF = @RSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += " ,EMPLOYEEDIVCDRF = @EMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += " ,EMPLOYEECODERF = @EMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF = @SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,SALESCODERF = @SALESCODE" + Environment.NewLine;
                        sqlText += " ,SALESTIMESRF = @SALESTIMES" + Environment.NewLine;
                        sqlText += " ,TOTALSALESCOUNTRF = @TOTALSALESCOUNT" + Environment.NewLine;
                        sqlText += " ,SALESMONEYRF = @SALESMONEY" + Environment.NewLine;
                        sqlText += " ,SALESRETGOODSPRICERF = @SALESRETGOODSPRICE" + Environment.NewLine;
                        sqlText += " ,DISCOUNTPRICERF = @DISCOUNTPRICE" + Environment.NewLine;
                        sqlText += " ,GROSSPROFITRF = @GROSSPROFIT" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                        sqlText += "  AND ADDUPYEARMONTHRF = @FINDADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += "  AND RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEEDIVCDRF = @FINDEMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                        sqlText += "  AND SALESCODERF = @FINDSALESCODE" + Environment.NewLine;
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
                        item.AddUpSecCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("ADDUPSECCODERF"));                  // �v�㋒�_�R�[�h
                        item.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(reader, reader.GetOrdinal("ADDUPYEARMONTHRF"));  // �v��N��
                        item.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("RSLTTTLDIVCDRF"));                   // ���яW�v�敪
                        item.EmployeeDivCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("EMPLOYEEDIVCDRF"));                 // �]�ƈ��敪
                        item.EmployeeCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("EMPLOYEECODERF"));                  // �]�ƈ��R�[�h
                        item.CustomerCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("CUSTOMERCODERF"));                   // ���Ӑ�R�[�h
                        item.SupplierCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SUPPLIERCDRF"));                       // �d����R�[�h
                        item.SalesCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SALESCODERF"));                         // �̔��敪�R�[�h
                        item.SalesTimes += SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SALESTIMESRF"));                      // �����
                        item.TotalSalesCount += SqlDataMediator.SqlGetDouble(reader, reader.GetOrdinal("TOTALSALESCOUNTRF"));           // ���㐔�v
                        item.SalesMoney += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("SALESMONEYRF"));                      // ������z
                        item.SalesRetGoodsPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("SALESRETGOODSPRICERF"));      // �ԕi�z
                        item.DiscountPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("DISCOUNTPRICERF"));                // �l�����z
                        item.GrossProfit += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("GROSSPROFITRF"));                    // �e�����z
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
                        sqlText += "INSERT INTO MTTLSALESSLIPRF" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += " ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += " ,RSLTTTLDIVCDRF" + Environment.NewLine;
                        sqlText += " ,EMPLOYEEDIVCDRF" + Environment.NewLine;
                        sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += " ,SALESCODERF" + Environment.NewLine;
                        sqlText += " ,SALESTIMESRF" + Environment.NewLine;
                        sqlText += " ,TOTALSALESCOUNTRF" + Environment.NewLine;
                        sqlText += " ,SALESMONEYRF" + Environment.NewLine;
                        sqlText += " ,SALESRETGOODSPRICERF" + Environment.NewLine;
                        sqlText += " ,DISCOUNTPRICERF" + Environment.NewLine;
                        sqlText += " ,GROSSPROFITRF" + Environment.NewLine;
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
                        sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,@ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += " ,@RSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += " ,@EMPLOYEEDIVCD" + Environment.NewLine;
                        sqlText += " ,@EMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,@SALESCODE" + Environment.NewLine;
                        sqlText += " ,@SALESTIMES" + Environment.NewLine;
                        sqlText += " ,@TOTALSALESCOUNT" + Environment.NewLine;
                        sqlText += " ,@SALESMONEY" + Environment.NewLine;
                        sqlText += " ,@SALESRETGOODSPRICE" + Environment.NewLine;
                        sqlText += " ,@DISCOUNTPRICE" + Environment.NewLine;
                        sqlText += " ,@GROSSPROFIT" + Environment.NewLine;
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
                    SqlParameter paraAddUpSecCode = command.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraAddUpYearMonth = command.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter paraRsltTtlDivCd = command.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                    SqlParameter paraEmployeeDivCd = command.Parameters.Add("@EMPLOYEEDIVCD", SqlDbType.Int);
                    SqlParameter paraEmployeeCode = command.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = command.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraSupplierCd = command.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSalesCode = command.Parameters.Add("@SALESCODE", SqlDbType.Int);
                    SqlParameter paraSalesTimes = command.Parameters.Add("@SALESTIMES", SqlDbType.Int);
                    SqlParameter paraTotalSalesCount = command.Parameters.Add("@TOTALSALESCOUNT", SqlDbType.Float);
                    SqlParameter paraSalesMoney = command.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
                    SqlParameter paraSalesRetGoodsPrice = command.Parameters.Add("@SALESRETGOODSPRICE", SqlDbType.BigInt);
                    SqlParameter paraDiscountPrice = command.Parameters.Add("@DISCOUNTPRICE", SqlDbType.BigInt);
                    SqlParameter paraGrossProfit = command.Parameters.Add("@GROSSPROFIT", SqlDbType.BigInt);
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
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(item.AddUpSecCode);                  // �v�㋒�_�R�[�h 
                    paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth);  // �v��N��
                    paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // ���яW�v�敪
                    paraEmployeeDivCd.Value = SqlDataMediator.SqlSetInt32(item.EmployeeDivCd);                 // �]�ƈ��敪
                    // 2009/03/04 ������̃L�[���ڂ�NULL���Z�b�g����錻�ۂ����>>>>>>
                    // MANTIS 12019
                    //paraEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // �]�ƈ��R�[�h
                    paraEmployeeCode.Value = item.EmployeeCode;                  // �]�ƈ��R�[�h
                    // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(item.CustomerCode);                   // ���Ӑ�R�[�h
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // �d����R�[�h
                    paraSalesCode.Value = SqlDataMediator.SqlSetInt32(item.SalesCode);                         // �̔��敪�R�[�h
                    paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(item.SalesTimes);                       // �����
                    paraTotalSalesCount.Value = SqlDataMediator.SqlSetDouble(item.TotalSalesCount);            // ���㐔�v
                    paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(item.SalesMoney);                       // ������z
                    paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(item.SalesRetGoodsPrice);       // �ԕi�z
                    paraDiscountPrice.Value = SqlDataMediator.SqlSetInt64(item.DiscountPrice);                 // �l�����z
                    paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(item.GrossProfit);                     // �e�����z
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

            return status;
        }

        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------>>>>>
        #region �ݒ�t�@�C���擾
        /// <summary>
        /// �ݒ�t�@�C���擾
        /// </summary>
        /// <param name="dbCommandTimeout">�^�C���A�E�g����</param>
        /// <remarks>
        /// <br>Note         : �ݒ�t�@�C���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private void GetXmlInfo(ref int dbCommandTimeout)
        {
            // �����l�ݒ�
            string fileName = this.InitializeXmlSettings();

            if (fileName != string.Empty)
            {
                XmlReaderSettings settings = new XmlReaderSettings();

                try
                {
                    using (XmlReader reader = XmlReader.Create(fileName, settings))
                    {
                        while (reader.Read())
                        {
                            //�^�C���A�E�g���Ԃ��擾
                            if (reader.IsStartElement("DbCommandTimeout")) dbCommandTimeout = reader.ReadElementContentAsInt();
                        }
                    }
                }
                catch
                {
                    base.WriteErrorLog(null, "�ݒ�t�@�C���擾�G���[");
                }
            }

        }
        #endregion // �ݒ�t�@�C���擾

        #region XML�t�@�C������
        /// <summary>
        /// XML�t�@�C�����擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : XML���擾�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string InitializeXmlSettings()
        {
            string homeDir = string.Empty;
            string path = string.Empty;

            try
            {
                // �J�����g�f�B���N�g���擾
                homeDir = this.GetCurrentDirectory();

                // �f�B���N�g������XML�t�@�C������A��
                path = Path.Combine(homeDir, XML_FILE_NAME);

                // �t�@�C�������݂��Ȃ��ꍇ�͋󔒂ɂ���
                if (!File.Exists(path))
                {
                    path = string.Empty;
                }
            }
            catch (Exception ex)
            {
                base.WriteErrorLog(ex, "SalesSlipDB.InitializeXmlSettings:" + ex.Message);
            }
            return path;
        }
        #endregion //XML�t�@�C������

        #region �J�����g�t�H���_
        /// <summary>
        /// �J�����g�t�H���_�擾
        /// </summary>
        /// <returns>XML�t�@�C����</returns>
        /// <remarks>
        /// <br>Note         : �J�����g�t�H���_�������s��</br>
        /// <br>Programmer   : �c����</br>
        /// <br>Date         : 2020/08/28</br>
        /// </remarks>
        private string GetCurrentDirectory()
        {
            string defaultDir = string.Empty;
            string homeDir = string.Empty;

            // XML�i�[�f�B���N�g���擾
            try
            {
                // dll�i�[�p�X�������f�B���N�g���Ƃ���
                defaultDir = AppDomain.CurrentDomain.BaseDirectory.TrimEnd(); // �����́u\�v�͏�ɂȂ�

                // ���W�X�g�������USER_AP�̃L�[�����擾
                RegistryKey keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

                if (keyForUSERAP == null)
                {
                    keyForUSERAP = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\WOW6432Node\Broadleaf\Service\Partsman\USER_AP");
                    if (keyForUSERAP == null)
                    {
                        // ���W�X�g�������擾�ł��Ȃ��ꍇ�͏����f�B���N�g�� // �^�p�゠�肦�Ȃ��P�[�X
                        homeDir = defaultDir;
                    }
                    else
                    {
                        homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                    }
                }
                else
                {
                    homeDir = keyForUSERAP.GetValue("InstallDirectory", defaultDir).ToString();
                }

                // �擾�f�B���N�g�������݂��Ȃ��ꍇ�͏����f�B���N�g����ݒ�
                // �^�p�゠�肦�Ȃ��P�[�X
                if (!Directory.Exists(homeDir))
                {
                    homeDir = defaultDir;
                }
            }
            catch (Exception ex)
            {
                //USER_AP��LOG�t�H���_�Ƀ��O�o��
                base.WriteErrorLog(ex, "SalesSlipDB.GetCurrentDirectory:" + ex.Message);
                if (!string.IsNullOrEmpty(defaultDir))
                {
                    homeDir = defaultDir;
                }
            }
            return homeDir;
        }
        #endregion // �J�����g�t�H���_
        // --- ADD �c���� 2020/08/28 PMKOBETSU-4076�̑Ή� ------<<<<<

        // -- ADD 2010/03/30 ----------------------------->>>
        /// <summary>
        /// ���㌎���W�v�f�[�^�pKey��񐶐�
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string MakeKeyMTtlSalesSlip(MTtlSalesSlipWork item)
        {

            return SqlDataMediator.SqlSetString(item.EnterpriseCode) + "-" +                         // ��ƃR�[�h
                    SqlDataMediator.SqlSetString(item.AddUpSecCode) + "-" +                           // �v�㋒�_�R�[�h
                    SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth).ToString() + "-" +  // �v��N��
                    SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd).ToString() + "-" +                 // ���яW�v�敪
                    SqlDataMediator.SqlSetInt32(item.EmployeeDivCd).ToString() + "-" +                // �]�ƈ��敪
                    item.EmployeeCode + "-" +                                                         // �]�ƈ��R�[�h
                    SqlDataMediator.SqlSetInt32(item.CustomerCode).ToString() + "-" +                 // ���Ӑ�R�[�h
                    SqlDataMediator.SqlSetInt32(item.SupplierCd).ToString() + "-" +                   // �d����R�[�h
                    SqlDataMediator.SqlSetInt32(item.SalesCode).ToString();                           // �̔��敪�R�[�h

        }
        // -- ADD 2010/03/30 -----------------------------<<<

        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^ �W�v�E�o�^����
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="totaledSalesSlips">���O�W�v�ςݔ���`�[�f�[�^���X�g</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <remarks>���O�W�v���I��������`�[�f�[�^���W�v���A���i�ʔ��㌎���W�v�f�[�^�֒ǉ��E�X�V���s���܂��B
        /// <br>Update Note: 2012/03/30 �s�i�� </br>
        /// <br>�Ǘ��ԍ�   �F10801804-00 2012/05/24�z�M��</br>
        /// <br>             Redmine#29142 �u���i�l���v�̏ꍇ�͏W�v�ΏۊO�ƂȂ�悤�ɏC������</br>
        /// <br>Update Note: 2012/03/31 �����H</br>							
        /// <br>�Ǘ��ԍ�   �F10707327-00 2012/05/24�z�M��</br>							
        /// <br>             Redmine#29215�@���Ӑ�d�q�����Ƌ��z������Ȃ��̏C��</br>							
        /// </remarks>
        /// <returns>STATUS</returns>
        private int WriteGoodsMTtlSales(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, ArrayList totaledSalesSlips, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // ���t�擾���i�̃C���X�^���X���擾
            FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlSalesUpdParaWork.EnterpriseCode));

            // ���㌎���W�v�f�[�^��r�p�N���X�̃C���X�^���X���擾
            //GoodsMTtlSaSlipComparer goodsMTtlSaSlipComparer = new GoodsMTtlSaSlipComparer();   // DEL 2010/05/13 ���g�p�̂��ߍ폜

            // �o�^�E�X�V�ΏۂƂȂ锄�㌎���W�v�f�[�^��ێ�����z��
            // -- UPD 2010/03/30 ---------------------->>>
            //ArrayList GoodsMTtlSalseList = new ArrayList();
            Dictionary<string, GoodsMTtlSaSlipWork> GoodsMTtlSalseDic = new Dictionary<string, GoodsMTtlSaSlipWork>();
            // -- UPD 2010/03/30 ----------------------<<<
            GoodsMTtlSaSlipWork goodsMTtlSaSlipWork = null;

            // �`�[�o�^���ɂ͉��Z�A�`�[�폜���ɂ͌��Z���s��
            int sign = (mTtlSalesUpdParaWork.SlipRegDiv == 0) ? -1 : 1;

            # region [���i�ʔ��㌎���W�v����]
            foreach (ArrayList slip in totaledSalesSlips)
            {
                SalesSlipWork header = ListUtils.Find(slip, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                ArrayList details = ListUtils.Find(slip, typeof(SalesDetailWork), ListUtils.FindType.Array) as ArrayList;

                if (header == null || ListUtils.IsEmpty(details))
                {
                    continue;
                }

                foreach (SalesDetailWork detail in details)
                {
                    // ���i�ԍ������o�^�̃f�[�^(�s�l���ɑ���)�͏W�v�Ώۂ���O��
                    //if (string.IsNullOrEmpty(detail.GoodsNo))     //DEL �����H�@2012/03/31 Redmine#29215
                    if (string.IsNullOrEmpty(detail.GoodsNo) && detail.BLGoodsCode == 0)    //ADD �����H�@2012/03/31 Redmine#29215
                    {
                        continue;
                    }
                    
                    // [�g�p�t���O(0:�o�^�s�� 1:�o�^�\), ���i�ʔ��㌎���W�v�f�[�^] �����Q�����z��𐶐�
                    object[,] GoodsMTtlSaSlipArray = new object[4, 2];

                    for (int index = 0; index < GoodsMTtlSaSlipArray.GetLength(0); index++)
                    {
                        goodsMTtlSaSlipWork = new GoodsMTtlSaSlipWork();

                        # region [�L�[���ڂ̐ݒ�]
                        // �L�[���ڂ̐ݒ�
                        GoodsMTtlSaSlipArray[index, 0] = 0;
                        GoodsMTtlSaSlipArray[index, 1] = goodsMTtlSaSlipWork;

                        goodsMTtlSaSlipWork.EnterpriseCode = detail.EnterpriseCode;        // ��ƃR�[�h
                        goodsMTtlSaSlipWork.LogicalDeleteCode = detail.LogicalDeleteCode;  // �_���폜�t���O
                        goodsMTtlSaSlipWork.AddUpSecCode = header.ResultsAddUpSecCd;       // �v�㋒�_�R�[�h �� ���ьv�㋒�_�R�[�h

                        // ���яW�v�敪 (0:���i���v 1:�݌� 2:���� 3:���)
                        goodsMTtlSaSlipWork.RsltTtlDivCd = index;

                        switch (goodsMTtlSaSlipWork.RsltTtlDivCd)
                        {
                            case 0:
                                {
                                    // ���㏤�i�敪 = 0:���i
                                    if (detail.SalesGoodsCd == 0)
                                    {
                                        GoodsMTtlSaSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            case 1:
                                {
                                    // �݌ɍX�V�敪
                                    # region [--- DEL 2009/01/20 M.Kubota --- ���i�l�������W�v�ΏۂƂ���ׂ�"�݌�"�̔�����@��ύX]
                                    //if (detail.StockUpdateDiv)
                                    //{
                                    //    GoodsMTtlSaSlipArray[index, 0] = 1;
                                    //}
                                    # endregion

                                    //--- ADD 2009/01/20 M.Kubota --->>>
                                    // "�݌�"�ɏW�v�������
                                    // �@ �q�ɃR�[�h���ݒ肳��Ă���
                                    // �A ����݌Ɏ�񂹋敪�� 1:�݌�
                                    // �B �o�א���0�ȊO
                                    // �C ����`�[�敪(����)�� 0:���� 1:�ԕi 2:�l�� �̏ꍇ
                                    if (!string.IsNullOrEmpty(detail.WarehouseCode) &&
                                         detail.SalesOrderDivCd == 1 &&
                                         detail.ShipmentCnt != 0 &&
                                        (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || detail.SalesSlipCdDtl == 2))
                                    {
                                        GoodsMTtlSaSlipArray[index, 0] = 1;
                                    }
                                    //--- ADD 2009/01/20 M.Kubota ---<<<
                                    break;
                                }
                            case 2:
                                {
                                    // ���i���� = 0:����
                                    if (detail.GoodsKindCode == 0)
                                    {
                                        GoodsMTtlSaSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    // ����`�[�敪(����) = 5:���
                                    //if (detail.SalesSlipCdDtl == 1)  //DEL 2009/01/20 M.Kubota
                                    if (detail.SalesSlipCdDtl == 5)    //ADD 2009/01/20 M.Kubota
                                    {
                                        GoodsMTtlSaSlipArray[index, 0] = 1;
                                    }
                                    break;
                                }
                        }

                        goodsMTtlSaSlipWork.EmployeeCode = header.SalesEmployeeCd;  // �]�ƈ��R�[�h �� �̔��]�ƈ��R�[�h
                        goodsMTtlSaSlipWork.CustomerCode = header.CustomerCode;     // ���Ӑ�R�[�h
                        goodsMTtlSaSlipWork.BLGoodsCode = detail.BLGoodsCode;       // BL���i�R�[�h
                        goodsMTtlSaSlipWork.GoodsMakerCd = detail.GoodsMakerCd;     // ���i���[�J�[�R�[�h
                        goodsMTtlSaSlipWork.GoodsNo = detail.GoodsNo;               // ���i�ԍ�
                        goodsMTtlSaSlipWork.SupplierCd = detail.SupplierCd;         // �d����R�[�h
                        // -- ADD 2010/05/13 --------------------------------------------->>>
                        goodsMTtlSaSlipWork.GoodsName = detail.GoodsName;           // ���i����
                        goodsMTtlSaSlipWork.GoodsNameKana = detail.GoodsNameKana;   // ���i���̃J�i
                        // -- ADD 2010/05/13 ---------------------------------------------<<<

                        # endregion

                        # region [�W�v���ڂ̐ݒ�]
                        if ((int)GoodsMTtlSaSlipArray[index, 0] == 1)
                        {
                            // �������莩�В��̔N���x���擾 �����S���|�鎖���\�z����邽�߁A�o�^�\�ȃ��R�[�h�ɂ̂ݐݒ肷��
                            DateTime AddUpDate;
                            dateGetAcs.GetYearMonth(detail.SalesDate, out AddUpDate);
                            goodsMTtlSaSlipWork.AddUpYearMonth = AddUpDate;                    // �v��N��

                            // �o�׉�
                            //if (header.DebitNoteDiv == 0 && header.SalesSlipCd == 0 && detail.SalesSlipCdDtl == 0)   // DEL 2009/12/24
                            if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 2) && header.SalesSlipCd == 0 && detail.SalesSlipCdDtl == 0)     // ADD 2009/12/24
                            {
                                if (detail.ShipmCntDifference != 1)
                                {
                                    // ���דo�^�̏ꍇ�͉��Z�A���׍폜�̏ꍇ�͌��Z���s��
                                    int value = (detail.ShipmCntDifference == 0) ? 1 : -1;

                                    // "����"�̖��ׂ݂̂��W�v�̑ΏۂƂ��܂��A�܂��`�[�폜���ɂ͌��Z���܂�
                                    goodsMTtlSaSlipWork.SalesTimes += sign * value;  // �o�׉�
                                }
                            }

                            // ���㐔�v
                            //if (header.DebitNoteDiv == 0 && detail.SalesSlipCdDtl == 0)                                //DEL 2009/01/20 M.Kubota
                            // 2009/03/04 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                            //�ԓ`�A���i�l�������ɐ��ʂ����Z����Ȃ��s��̏C��
                            //if (header.DebitNoteDiv == 0 && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1))  //ADD 2009/01/20 M.Kubota  �ԕi�������㐔�v�̏W�v�ΏۂƂ���
                            //if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1) && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || (detail.SalesSlipCdDtl == 2 && detail.ShipmentCnt != 0)))  //ADD 2009/01/20 M.Kubota  �ԕi�������㐔�v�̏W�v�ΏۂƂ���                  // DEL 2009/12/24
                            //if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1 || header.DebitNoteDiv == 2) && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1 || (detail.SalesSlipCdDtl == 2 && detail.ShipmentCnt != 0)))  //ADD 2009/01/20 M.Kubota  �ԕi�������㐔�v�̏W�v�ΏۂƂ���  // ADD 2009/12/24                  //DEL �s�i�� 2012/03/30 Redmine#29142
                            // 2009/03/04 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                            if ((header.DebitNoteDiv == 0 || header.DebitNoteDiv == 1 || header.DebitNoteDiv == 2) && (detail.SalesSlipCdDtl == 0 || detail.SalesSlipCdDtl == 1))  //ADD �s�i�� 2012/03/30 Redmine#29142
                            {
                                # region [--- DEL 2009/01/20 M.Kubota --- �ԕi�̏ꍇ�A���ʂ��}�C�i�X�l�Ŋi�[����Ă���̂ŕ������]����(value)���폜]
                                // ����`�[�敪�� 0:���� �̏ꍇ�͉��Z�A1:�ԕi �̏ꍇ�͌��Z���s��
                                //int value = (header.SalesSlipCd == 0) ? 1 : -1;
                                //goodsMTtlSaSlipWork.TotalSalesCount += sign * value * detail.ShipmentCnt;  // ���㐔�v
                                # endregion

                                goodsMTtlSaSlipWork.TotalSalesCount += sign * detail.ShipmentCnt;  // ���㐔�v  //ADD 2009/01/20 M.Kubota
                            }

                            if (header.SalesSlipCd == 0)
                            {
                                switch (detail.SalesSlipCdDtl)
                                {
                                    case 0:  // 0:����
                                        {
                                            // ������z
                                            goodsMTtlSaSlipWork.SalesMoney = sign * detail.SalesMoneyTaxExc;

                                            // �e�����z
                                            goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            break;
                                        }
                                    case 1:  // 1:�ԕi
                                        {
                                            // �e�����z
                                            goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            // �ԕi�z
                                            goodsMTtlSaSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                            break;
                                        }
                                    case 2:  // 2:�l��
                                        {
                                            // PM7�̎d�l�ɍ��킹�čs�l���͏W�v�ΏۊO�Ƃ���B
                                            // ���s�l���Ə��i�l���̔��f��UI�Ɠ��l�ɐ��ʂ̗L��(!=0)�Ŕ��f����
                                            if (detail.ShipmentCnt != 0)  //ADD 2009/01/20 M.Kubota
                                            {
                                                // �l�����z
                                                goodsMTtlSaSlipWork.DiscountPrice = sign * detail.SalesMoneyTaxExc;

                                                // �e�����z
                                                goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);
                                            }
                                            break;
                                        }
                                }
                            }
                            else if (header.SalesSlipCd == 1)
                            {
                                //2009/02/05 >>>>>>>>>>>>>>>>>>>>>>>>>
                                // Mantis 11169�̑Ή� �ԕi�`�[�̍s�l�����z��l�������z�ɃZ�b�g����(�֘AID:11102)

                                //// �ԕi�z
                                //goodsMTtlSaSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                //// �e�����z
                                //goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                switch (detail.SalesSlipCdDtl)
                                {
                                    case 1:  // 1:�ԕi
                                        {
                                            // �ԕi�z
                                            goodsMTtlSaSlipWork.SalesRetGoodsPrice = sign * detail.SalesMoneyTaxExc;
                                            // �e�����z
                                            goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);

                                            break;
                                        }
                                    case 2:  // 2:�l��
                                        {

                                            // ���s�l���Ə��i�l���̔��f��UI�Ɠ��l�ɐ��ʂ̗L��(!=0)�Ŕ��f����
                                            if (detail.ShipmentCnt != 0)
                                            {
                                                // �l�����z
                                                goodsMTtlSaSlipWork.DiscountPrice = sign * detail.SalesMoneyTaxExc;

                                                // �e�����z
                                                goodsMTtlSaSlipWork.GrossProfit = sign * (detail.SalesMoneyTaxExc - detail.Cost);
                                            }

                                            break;
                                        }
                                }
                                //2009/02/05 <<<<<<<<<<<<<<<<<<<<<<<<<
                            }

                            // -- DEL 2010/03/30 -------------------------->>>
                            //GoodsMTtlSalseList.Sort(goodsMTtlSaSlipComparer);

                            //int SearchIndex = GoodsMTtlSalseList.BinarySearch(goodsMTtlSaSlipWork, goodsMTtlSaSlipComparer);
                            // -- DEL 2010/03/30 --------------------------<<<

                            // -- UPD 2010/03/30 -------------------------->>>
                            //if (SearchIndex < 0)
                            //{
                            //    // ����L�[�����݂��Ȃ��ꍇ�͓o�^���X�g�ɒǉ�����
                            //    GoodsMTtlSalseList.Add(goodsMTtlSaSlipWork);
                            //}
                            //else
                            //{
                            //    // ����L�[�����݂��Ă���ꍇ�͏W�v���ڂ����Z����
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).SalesTimes += goodsMTtlSaSlipWork.SalesTimes;            // �����
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).TotalSalesCount += goodsMTtlSaSlipWork.TotalSalesCount;  // ���㐔�v
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).SalesMoney += goodsMTtlSaSlipWork.SalesMoney;            // ������z
                            //    //(GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).SalesMoney += goodsMTtlSaSlipWork.SalesRetGoodsPrice;    // �ԕi���z  //ADD 2009/01/20 M.Kubota DEL //2009/03/24
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).SalesRetGoodsPrice += goodsMTtlSaSlipWork.SalesRetGoodsPrice;    // �ԕi���z  //ADD 2009/03/24
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).DiscountPrice += goodsMTtlSaSlipWork.DiscountPrice;      // �l�����z  //ADD 2009/03/24
                            //    (GoodsMTtlSalseList[SearchIndex] as GoodsMTtlSaSlipWork).GrossProfit += goodsMTtlSaSlipWork.GrossProfit;          // �e�����z
                            //}

                            if (!GoodsMTtlSalseDic.ContainsKey(MakeKeyGoodsMTtlSaSlip(goodsMTtlSaSlipWork)))
                            {
                                // ����L�[�����݂��Ȃ��ꍇ�͓o�^���X�g�ɒǉ�����
                                GoodsMTtlSalseDic.Add(MakeKeyGoodsMTtlSaSlip(goodsMTtlSaSlipWork), goodsMTtlSaSlipWork);
                            }
                            else
                            {
                                GoodsMTtlSaSlipWork work = GoodsMTtlSalseDic[MakeKeyGoodsMTtlSaSlip(goodsMTtlSaSlipWork)];

                                // ����L�[�����݂��Ă���ꍇ�͏W�v���ڂ����Z����
                                work.SalesTimes += goodsMTtlSaSlipWork.SalesTimes;            // �����
                                work.TotalSalesCount += goodsMTtlSaSlipWork.TotalSalesCount;  // ���㐔�v
                                work.SalesMoney += goodsMTtlSaSlipWork.SalesMoney;            // ������z
                                work.SalesRetGoodsPrice += goodsMTtlSaSlipWork.SalesRetGoodsPrice;    // �ԕi���z 
                                work.DiscountPrice += goodsMTtlSaSlipWork.DiscountPrice;      // �l�����z 
                                work.GrossProfit += goodsMTtlSaSlipWork.GrossProfit;          // �e�����z

                                // -- ADD 2010/05/13 ------------------------------------->>>
                                work.GoodsName = goodsMTtlSaSlipWork.GoodsName;               //���i����
                                work.GoodsNameKana = goodsMTtlSaSlipWork.GoodsNameKana;       //���i���̃J�i
                                // -- ADD 2010/05/13 -------------------------------------<<<
                            }
                            // -- UPD 2010/03/30 --------------------------<<<

                        }
                        # endregion
                    }
                }
            }
            # endregion

            # region [���i�ʔ��㌎���W�v�f�[�^�o�^]

            string sqlText = string.Empty;
            SqlCommand command = new SqlCommand(sqlText, connection, transaction);
            SqlDataReader reader = null;

            try
            {
                // -- UPD 2010/03/30 -------------------------------->>>
                //foreach (GoodsMTtlSaSlipWork item in GoodsMTtlSalseList)
                foreach (GoodsMTtlSaSlipWork item in GoodsMTtlSalseDic.Values)
                // -- UPD 2010/03/30 --------------------------------<<<
                {
                    # region [SELECT��]
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  GODS.CREATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,GODS.UPDATEDATETIMERF" + Environment.NewLine;
                    sqlText += " ,GODS.ENTERPRISECODERF" + Environment.NewLine;
                    sqlText += " ,GODS.FILEHEADERGUIDRF" + Environment.NewLine;
                    sqlText += " ,GODS.UPDEMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,GODS.UPDASSEMBLYID1RF" + Environment.NewLine;
                    sqlText += " ,GODS.UPDASSEMBLYID2RF" + Environment.NewLine;
                    sqlText += " ,GODS.LOGICALDELETECODERF" + Environment.NewLine;
                    sqlText += " ,GODS.ADDUPSECCODERF" + Environment.NewLine;
                    sqlText += " ,GODS.ADDUPYEARMONTHRF" + Environment.NewLine;
                    sqlText += " ,GODS.RSLTTTLDIVCDRF" + Environment.NewLine;
                    sqlText += " ,GODS.EMPLOYEECODERF" + Environment.NewLine;
                    sqlText += " ,GODS.CUSTOMERCODERF" + Environment.NewLine;
                    sqlText += " ,GODS.BLGOODSCODERF" + Environment.NewLine;
                    sqlText += " ,GODS.GOODSMAKERCDRF" + Environment.NewLine;
                    sqlText += " ,GODS.GOODSNORF" + Environment.NewLine;
                    sqlText += " ,GODS.SUPPLIERCDRF" + Environment.NewLine;
                    sqlText += " ,GODS.SALESTIMESRF" + Environment.NewLine;
                    sqlText += " ,GODS.TOTALSALESCOUNTRF" + Environment.NewLine;
                    sqlText += " ,GODS.SALESMONEYRF" + Environment.NewLine;
                    sqlText += " ,GODS.SALESRETGOODSPRICERF" + Environment.NewLine;
                    sqlText += " ,GODS.DISCOUNTPRICERF" + Environment.NewLine;
                    sqlText += " ,GODS.GROSSPROFITRF" + Environment.NewLine;
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  GOODSMTTLSASLIPRF AS GODS" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  GODS.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND GODS.LOGICALDELETECODERF = 0" + Environment.NewLine;
                    sqlText += "  AND GODS.ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                    sqlText += "  AND GODS.ADDUPYEARMONTHRF = @FINDADDUPYEARMONTH" + Environment.NewLine;
                    sqlText += "  AND GODS.RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                    sqlText += "  AND GODS.EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                    sqlText += "  AND GODS.CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                    sqlText += "  AND GODS.BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                    sqlText += "  AND GODS.GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                    sqlText += "  AND GODS.GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
                    sqlText += "  AND GODS.SUPPLIERCDRF = @FINDSUPPLIERCD" + Environment.NewLine;
                    command.CommandText = sqlText;
                    command.Parameters.Clear();
                    # endregion

                    # region [�����p �p�����[�^�I�u�W�F�N�g�̍쐬]
                    SqlParameter findEnterpriseCode = command.Parameters.Add("@FINDENTERPRISECODE", SqlDbType.NChar);  // ��ƃR�[�h
                    SqlParameter findAddUpSecCode = command.Parameters.Add("@FINDADDUPSECCODE", SqlDbType.NChar);      // �v�㋒�_�R�[�h
                    SqlParameter findAddUpYearMonth = command.Parameters.Add("@FINDADDUPYEARMONTH", SqlDbType.Int);    // �v��N��
                    SqlParameter findRsltTtlDivCd = command.Parameters.Add("@FINDRSLTTTLDIVCD", SqlDbType.Int);        // ���яW�v�敪
                    SqlParameter findEmployeeCode = command.Parameters.Add("@FINDEMPLOYEECODE", SqlDbType.NChar);      // �]�ƈ��R�[�h
                    SqlParameter findCustomerCode = command.Parameters.Add("@FINDCUSTOMERCODE", SqlDbType.Int);        // ���Ӑ�R�[�h
                    SqlParameter findBLGoodsCode = command.Parameters.Add("@FINDBLGOODSCODE", SqlDbType.Int);          // BL���i�R�[�h
                    SqlParameter findGoodsMakerCd = command.Parameters.Add("@FINDGOODSMAKERCD", SqlDbType.Int);        // ���i���[�J�[�R�[�h
                    SqlParameter findGoodsNo = command.Parameters.Add("@FINDGOODSNO", SqlDbType.NVarChar);             // ���i�ԍ�
                    SqlParameter findSupplierCd = command.Parameters.Add("@FINDSUPPLIERCD", SqlDbType.Int);            // �d����R�[�h
                    # endregion

                    # region [�����p �p�����[�^�I�u�W�F�N�g�̒l�ݒ�]
                    findEnterpriseCode.Value = SqlDataMediator.SqlSetString(item.EnterpriseCode);              // ��ƃR�[�h
                    findAddUpSecCode.Value = SqlDataMediator.SqlSetString(item.AddUpSecCode);                  // �v�㋒�_�R�[�h
                    findAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth);  // �v��N��
                    findRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // ���яW�v�敪
                    findEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // �]�ƈ��R�[�h
                    findCustomerCode.Value = SqlDataMediator.SqlSetInt32(item.CustomerCode);                   // ���Ӑ�R�[�h
                    findBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(item.BLGoodsCode);                     // BL���i�R�[�h
                    findGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(item.GoodsMakerCd);                   // ���i���[�J�[�R�[�h
                    //findGoodsNo.Value = SqlDataMediator.SqlSetString(item.GoodsNo);                            // ���i�ԍ� //DEL �����H�@2012/03/31 Redmine#29215
                    findGoodsNo.Value = item.GoodsNo;                                                           // ���i�ԍ� //ADD �����H�@2012/03/31 Redmine#29215
                    findSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // �d����R�[�h
                    # endregion

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        # region [UPDATE��]
                        sqlText = string.Empty;
                        sqlText += "UPDATE GOODSMTTLSASLIPRF" + Environment.NewLine;
                        sqlText += "SET" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF = @CREATEDATETIME" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF = @UPDATEDATETIME" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF = @ENTERPRISECODE" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF = @FILEHEADERGUID" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF = @UPDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF = @UPDASSEMBLYID1" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF = @UPDASSEMBLYID2" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF = @LOGICALDELETECODE" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF = @ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,ADDUPYEARMONTHRF = @ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += " ,RSLTTTLDIVCDRF = @RSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += " ,EMPLOYEECODERF = @EMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF = @CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,BLGOODSCODERF = @BLGOODSCODE" + Environment.NewLine;
                        sqlText += " ,GOODSMAKERCDRF = @GOODSMAKERCD" + Environment.NewLine;
                        sqlText += " ,GOODSNORF = @GOODSNO" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF = @SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,SALESTIMESRF = @SALESTIMES" + Environment.NewLine;
                        sqlText += " ,TOTALSALESCOUNTRF = @TOTALSALESCOUNT" + Environment.NewLine;
                        sqlText += " ,SALESMONEYRF = @SALESMONEY" + Environment.NewLine;
                        sqlText += " ,SALESRETGOODSPRICERF = @SALESRETGOODSPRICE" + Environment.NewLine;
                        sqlText += " ,DISCOUNTPRICERF = @DISCOUNTPRICE" + Environment.NewLine;
                        sqlText += " ,GROSSPROFITRF = @GROSSPROFIT" + Environment.NewLine;
                        // -- ADD 2010/05/13 ----------------------------------->>>
                        sqlText += " ,GOODSNAMERF = @GOODSNAME" + Environment.NewLine;
                        sqlText += " ,GOODSNAMEKANARF = @GOODSNAMEKANA" + Environment.NewLine;
                        // -- ADD 2010/05/13 -----------------------------------<<<
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                        sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                        sqlText += "  AND ADDUPYEARMONTHRF = @FINDADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += "  AND RSLTTTLDIVCDRF = @FINDRSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += "  AND EMPLOYEECODERF = @FINDEMPLOYEECODE" + Environment.NewLine;
                        sqlText += "  AND CUSTOMERCODERF = @FINDCUSTOMERCODE" + Environment.NewLine;
                        sqlText += "  AND BLGOODSCODERF = @FINDBLGOODSCODE" + Environment.NewLine;
                        sqlText += "  AND GOODSMAKERCDRF = @FINDGOODSMAKERCD" + Environment.NewLine;
                        sqlText += "  AND GOODSNORF = @FINDGOODSNO" + Environment.NewLine;
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
                        item.AddUpSecCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("ADDUPSECCODERF"));                  // �v�㋒�_�R�[�h
                        item.AddUpYearMonth = SqlDataMediator.SqlGetDateTimeFromYYYYMM(reader, reader.GetOrdinal("ADDUPYEARMONTHRF"));  // �v��N��
                        item.RsltTtlDivCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("RSLTTTLDIVCDRF"));                   // ���яW�v�敪
                        item.EmployeeCode = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("EMPLOYEECODERF"));                  // �]�ƈ��R�[�h
                        item.CustomerCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("CUSTOMERCODERF"));                   // ���Ӑ�R�[�h
                        item.BLGoodsCode = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("BLGOODSCODERF"));                     // BL���i�R�[�h
                        item.GoodsMakerCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("GOODSMAKERCDRF"));                   // ���i���[�J�[�R�[�h
                        //item.GoodsNo = SqlDataMediator.SqlGetString(reader, reader.GetOrdinal("GOODSNORF"));                            // ���i�ԍ�   //DEL �����H�@2012/03/31 Redmine#29215
                        item.GoodsNo = string.Format("{0}", reader["GOODSNORF"]);                                                       // ���i�ԍ� //ADD �����H�@2012/03/31 Redmine#29215
                        item.SupplierCd = SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SUPPLIERCDRF"));                       // �d����R�[�h
                        item.SalesTimes += SqlDataMediator.SqlGetInt32(reader, reader.GetOrdinal("SALESTIMESRF"));                      // �����
                        item.TotalSalesCount += SqlDataMediator.SqlGetDouble(reader, reader.GetOrdinal("TOTALSALESCOUNTRF"));           // ���㐔�v
                        item.SalesMoney += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("SALESMONEYRF"));                      // ������z
                        item.SalesRetGoodsPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("SALESRETGOODSPRICERF"));      // �ԕi�z
                        item.DiscountPrice += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("DISCOUNTPRICERF"));                // �l�����z
                        item.GrossProfit += SqlDataMediator.SqlGetInt64(reader, reader.GetOrdinal("GROSSPROFITRF"));                    // �e�����z
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
                        sqlText += "INSERT INTO GOODSMTTLSASLIPRF" + Environment.NewLine;
                        sqlText += "(" + Environment.NewLine;
                        sqlText += "  CREATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,UPDATEDATETIMERF" + Environment.NewLine;
                        sqlText += " ,ENTERPRISECODERF" + Environment.NewLine;
                        sqlText += " ,FILEHEADERGUIDRF" + Environment.NewLine;
                        sqlText += " ,UPDEMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID1RF" + Environment.NewLine;
                        sqlText += " ,UPDASSEMBLYID2RF" + Environment.NewLine;
                        sqlText += " ,LOGICALDELETECODERF" + Environment.NewLine;
                        sqlText += " ,ADDUPSECCODERF" + Environment.NewLine;
                        sqlText += " ,ADDUPYEARMONTHRF" + Environment.NewLine;
                        sqlText += " ,RSLTTTLDIVCDRF" + Environment.NewLine;
                        sqlText += " ,EMPLOYEECODERF" + Environment.NewLine;
                        sqlText += " ,CUSTOMERCODERF" + Environment.NewLine;
                        sqlText += " ,BLGOODSCODERF" + Environment.NewLine;
                        sqlText += " ,GOODSMAKERCDRF" + Environment.NewLine;
                        sqlText += " ,GOODSNORF" + Environment.NewLine;
                        sqlText += " ,SUPPLIERCDRF" + Environment.NewLine;
                        sqlText += " ,SALESTIMESRF" + Environment.NewLine;
                        sqlText += " ,TOTALSALESCOUNTRF" + Environment.NewLine;
                        sqlText += " ,SALESMONEYRF" + Environment.NewLine;
                        sqlText += " ,SALESRETGOODSPRICERF" + Environment.NewLine;
                        sqlText += " ,DISCOUNTPRICERF" + Environment.NewLine;
                        sqlText += " ,GROSSPROFITRF" + Environment.NewLine;
                        // -- ADD 2010/05/13 --------------------------->>>
                        sqlText += " ,GOODSNAMERF" + Environment.NewLine;
                        sqlText += " ,GOODSNAMEKANARF" + Environment.NewLine;
                        // -- ADD 2010/05/13 ---------------------------<<<
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
                        sqlText += " ,@ADDUPSECCODE" + Environment.NewLine;
                        sqlText += " ,@ADDUPYEARMONTH" + Environment.NewLine;
                        sqlText += " ,@RSLTTTLDIVCD" + Environment.NewLine;
                        sqlText += " ,@EMPLOYEECODE" + Environment.NewLine;
                        sqlText += " ,@CUSTOMERCODE" + Environment.NewLine;
                        sqlText += " ,@BLGOODSCODE" + Environment.NewLine;
                        sqlText += " ,@GOODSMAKERCD" + Environment.NewLine;
                        sqlText += " ,@GOODSNO" + Environment.NewLine;
                        sqlText += " ,@SUPPLIERCD" + Environment.NewLine;
                        sqlText += " ,@SALESTIMES" + Environment.NewLine;
                        sqlText += " ,@TOTALSALESCOUNT" + Environment.NewLine;
                        sqlText += " ,@SALESMONEY" + Environment.NewLine;
                        sqlText += " ,@SALESRETGOODSPRICE" + Environment.NewLine;
                        sqlText += " ,@DISCOUNTPRICE" + Environment.NewLine;
                        sqlText += " ,@GROSSPROFIT" + Environment.NewLine;
                        // -- ADD 2010/05/13 --------------------------->>>
                        sqlText += " ,@GOODSNAME" + Environment.NewLine;
                        sqlText += " ,@GOODSNAMEKANA" + Environment.NewLine;
                        // -- ADD 2010/05/13 ---------------------------<<<
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
                    SqlParameter paraAddUpSecCode = command.Parameters.Add("@ADDUPSECCODE", SqlDbType.NChar);
                    SqlParameter paraAddUpYearMonth = command.Parameters.Add("@ADDUPYEARMONTH", SqlDbType.Int);
                    SqlParameter paraRsltTtlDivCd = command.Parameters.Add("@RSLTTTLDIVCD", SqlDbType.Int);
                    SqlParameter paraEmployeeCode = command.Parameters.Add("@EMPLOYEECODE", SqlDbType.NChar);
                    SqlParameter paraCustomerCode = command.Parameters.Add("@CUSTOMERCODE", SqlDbType.Int);
                    SqlParameter paraBLGoodsCode = command.Parameters.Add("@BLGOODSCODE", SqlDbType.Int);
                    SqlParameter paraGoodsMakerCd = command.Parameters.Add("@GOODSMAKERCD", SqlDbType.Int);
                    SqlParameter paraGoodsNo = command.Parameters.Add("@GOODSNO", SqlDbType.NVarChar);
                    SqlParameter paraSupplierCd = command.Parameters.Add("@SUPPLIERCD", SqlDbType.Int);
                    SqlParameter paraSalesTimes = command.Parameters.Add("@SALESTIMES", SqlDbType.Int);
                    SqlParameter paraTotalSalesCount = command.Parameters.Add("@TOTALSALESCOUNT", SqlDbType.Float);
                    SqlParameter paraSalesMoney = command.Parameters.Add("@SALESMONEY", SqlDbType.BigInt);
                    SqlParameter paraSalesRetGoodsPrice = command.Parameters.Add("@SALESRETGOODSPRICE", SqlDbType.BigInt);
                    SqlParameter paraDiscountPrice = command.Parameters.Add("@DISCOUNTPRICE", SqlDbType.BigInt);
                    SqlParameter paraGrossProfit = command.Parameters.Add("@GROSSPROFIT", SqlDbType.BigInt);
                    // -- ADD 2010/05/13 ---------------------------------------------->>>
                    SqlParameter paraGoodsName = command.Parameters.Add("@GOODSNAME", SqlDbType.NVarChar);
                    SqlParameter paraGoodsNameKana = command.Parameters.Add("@GOODSNAMEKANA", SqlDbType.NVarChar);
                    // -- ADD 2010/05/13 ----------------------------------------------<<<
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
                    paraAddUpSecCode.Value = SqlDataMediator.SqlSetString(item.AddUpSecCode);                  // �v�㋒�_�R�[�h
                    paraAddUpYearMonth.Value = SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth);  // �v��N��
                    paraRsltTtlDivCd.Value = SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd);                   // ���яW�v�敪
                    paraEmployeeCode.Value = SqlDataMediator.SqlSetString(item.EmployeeCode);                  // �]�ƈ��R�[�h
                    paraCustomerCode.Value = SqlDataMediator.SqlSetInt32(item.CustomerCode);                   // ���Ӑ�R�[�h
                    paraBLGoodsCode.Value = SqlDataMediator.SqlSetInt32(item.BLGoodsCode);                     // BL���i�R�[�h
                    paraGoodsMakerCd.Value = SqlDataMediator.SqlSetInt32(item.GoodsMakerCd);                   // ���i���[�J�[�R�[�h
                    //paraGoodsNo.Value = SqlDataMediator.SqlSetString(item.GoodsNo);                            // ���i�ԍ�  //DEL �����H�@2012/03/31 Redmine#29215
                    paraGoodsNo.Value = item.GoodsNo;                                                          // ���i�ԍ�  //ADD �����H�@2012/03/31 Redmine#29215
                    paraSupplierCd.Value = SqlDataMediator.SqlSetInt32(item.SupplierCd);                       // �d����R�[�h
                    paraSalesTimes.Value = SqlDataMediator.SqlSetInt32(item.SalesTimes);                       // �����
                    paraTotalSalesCount.Value = SqlDataMediator.SqlSetDouble(item.TotalSalesCount);            // ���㐔�v
                    paraSalesMoney.Value = SqlDataMediator.SqlSetInt64(item.SalesMoney);                       // ������z
                    paraSalesRetGoodsPrice.Value = SqlDataMediator.SqlSetInt64(item.SalesRetGoodsPrice);       // �ԕi�z
                    paraDiscountPrice.Value = SqlDataMediator.SqlSetInt64(item.DiscountPrice);                 // �l�����z
                    paraGrossProfit.Value = SqlDataMediator.SqlSetInt64(item.GrossProfit);                     // �e�����z
                    // -- ADD 2010/05/13 ---------------------------------------------->>>
                    paraGoodsName.Value = SqlDataMediator.SqlSetString(item.GoodsName);                        // ���i����
                    paraGoodsNameKana.Value = SqlDataMediator.SqlSetString(item.GoodsNameKana);                // ���i���̃J�i
                    // -- ADD 2010/05/13 ----------------------------------------------<<<
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

            return status;
        }

        // -- ADD 2010/03/30 ------------------------------->>>
        /// <summary>
        /// ���i�����W�v�f�[�^Key��񐶐�
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private string MakeKeyGoodsMTtlSaSlip(GoodsMTtlSaSlipWork item)
        {
            return SqlDataMediator.SqlSetString(item.EnterpriseCode) + "-" +                          // ��ƃR�[�h
                    SqlDataMediator.SqlSetString(item.AddUpSecCode) + "-" +                            // �v�㋒�_�R�[�h
                    SqlDataMediator.SqlSetDateTimeFromYYYYMM(item.AddUpYearMonth).ToString() + "-" +    // �v��N��
                    SqlDataMediator.SqlSetInt32(item.RsltTtlDivCd).ToString() + "-" +                  // ���яW�v�敪
                    SqlDataMediator.SqlSetString(item.EmployeeCode) + "-" +                            // �]�ƈ��R�[�h
                    SqlDataMediator.SqlSetInt32(item.CustomerCode).ToString() + "-" +                  // ���Ӑ�R�[�h
                    SqlDataMediator.SqlSetInt32(item.BLGoodsCode).ToString() + "-" +                   // BL���i�R�[�h
                    SqlDataMediator.SqlSetInt32(item.GoodsMakerCd).ToString() + "-" +                  // ���i���[�J�[�R�[�h
                    SqlDataMediator.SqlSetString(item.GoodsNo) + "-" +                                 // ���i�ԍ�
                    SqlDataMediator.SqlSetInt32(item.SupplierCd).ToString();                           // �d����R�[�h
        }
        // -- ADD 2010/03/30 -------------------------------<<<

        # region [��r���\�b�h (���ёւ��⌟���Ŏg�p)]

        /// <summary>
        /// ����f�[�^�p ��r���\�b�h
        /// </summary>
        private class SalesHeaderComparer : IComparer
        {
            public bool AdvancedMode = false;  //ADD 2009/01/20 M.Kubota  ��r���ڂ̊g���t���O

            public int Compare(object x, object y)
            {
                SalesSlipWork xSlip = ListUtils.Find((ArrayList)x, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;
                SalesSlipWork ySlip = ListUtils.Find((ArrayList)y, typeof(SalesSlipWork), ListUtils.FindType.Class) as SalesSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // ��ƃR�[�h�Ŕ�r
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // �󒍃X�e�[�^�X�Ŕ�r
                        cmpret = xSlip.AcptAnOdrStatus - ySlip.AcptAnOdrStatus;
                    }

                    if (cmpret == 0)
                    {
                        // ����`�[�ԍ��Ŕ�r
                        cmpret = string.Compare(xSlip.SalesSlipNum, ySlip.SalesSlipNum);
                    }

                    //--- ADD 2009/01/20 M.Kubota --->>>
                    // ����`�[���ɂ����āA�W�v�̋N�_�ƂȂ�
                    if (this.AdvancedMode)
                    {
                        if (cmpret == 0)
                        {
                            // �o�ד��t�Ŕ�r
                            cmpret = DateTime.Compare(xSlip.ShipmentDay, ySlip.ShipmentDay);
                        }

                        if (cmpret == 0)
                        {
                            // ������t�Ŕ�r
                            cmpret = DateTime.Compare(xSlip.SalesDate, ySlip.SalesDate);
                        }

                        if (cmpret == 0)
                        {
                            // �̔��]�ƈ��R�[�h�Ŕ�r
                            cmpret = string.Compare(xSlip.SalesEmployeeCd, ySlip.SalesEmployeeCd);
                        }

                        if (cmpret == 0)
                        {
                            // ��t�]�ƈ��R�[�h�Ŕ�r
                            cmpret = string.Compare(xSlip.FrontEmployeeCd, ySlip.FrontEmployeeCd);
                        }

                        if (cmpret == 0)
                        {
                            // ������͎҃R�[�h�Ŕ�r
                            cmpret = string.Compare(xSlip.SalesInputCode, ySlip.SalesInputCode);
                        }

                        // �������I�ɔ���`�[���͉�ʂœ��Ӑ�R�[�h���C���\�ɂȂ�����g�p����
                        //if (cmpret == 0)
                        //{
                        //    // ���Ӑ�R�[�h�Ŕ�r
                        //    cmpret = string.Compare(xSlip.CustomerCode, ySlip.CustomerCode);
                        //}
                    }
                    //--- ADD 2009/01/20 M.Kubota ---<<<
                }

                return cmpret;
            }
        }

        /// <summary>
        /// ���㖾�׃f�[�^�p ��r���\�b�h
        /// </summary>
        private class SalesDetailComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                SalesDetailWork xDetail = x as SalesDetailWork;
                SalesDetailWork yDetail = y as SalesDetailWork;

                int cmpret = (xDetail == null ? 0 : 1) - (yDetail == null ? 0 : 1);

                if (cmpret == 0 && xDetail != null)
                {
                    // ��ƃR�[�h�Ŕ�r
                    cmpret = string.Compare(xDetail.EnterpriseCode, yDetail.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // �󒍃X�e�[�^�X�Ŕ�r
                        cmpret = xDetail.AcptAnOdrStatus - yDetail.AcptAnOdrStatus;
                    }

                    if (cmpret == 0)
                    {
                        // ���㖾�גʔԂŔ�r
                        cmpret = (int)(xDetail.SalesSlipDtlNum - yDetail.SalesSlipDtlNum);
                    }
                }

                return cmpret;
            }
        }

        /// <summary>
        /// ���㌎���W�v�f�[�^�p ��r���\�b�h
        /// </summary>
        private class MTtlSalesSlipComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                MTtlSalesSlipWork xSlip = x as MTtlSalesSlipWork;
                MTtlSalesSlipWork ySlip = y as MTtlSalesSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // ��ƃR�[�h�Ŕ�r
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // �v�㋒�_�R�[�h�Ŕ�r
                        cmpret = string.Compare(xSlip.AddUpSecCode, ySlip.AddUpSecCode);
                    }

                    if (cmpret == 0)
                    {
                        // �v��N���Ŕ�r
                        cmpret = DateTime.Compare(xSlip.AddUpYearMonth, ySlip.AddUpYearMonth);
                    }

                    if (cmpret == 0)
                    {
                        // ���яW�v�敪�Ŕ�r
                        cmpret = xSlip.RsltTtlDivCd - ySlip.RsltTtlDivCd;
                    }

                    if (cmpret == 0)
                    {
                        // �]�ƈ��敪�Ŕ�r
                        cmpret = xSlip.EmployeeDivCd - ySlip.EmployeeDivCd;
                    }

                    if (cmpret == 0)
                    {
                        // �]�ƈ��R�[�h�Ŕ�r
                        cmpret = string.Compare(xSlip.EmployeeCode, ySlip.EmployeeCode);
                    }

                    if (cmpret == 0)
                    {
                        // ���Ӑ�R�[�h�Ŕ�r
                        cmpret = xSlip.CustomerCode - ySlip.CustomerCode;
                    }

                    if (cmpret == 0)
                    {
                        // �d����R�[�h�Ŕ�r
                        cmpret = xSlip.SupplierCd - ySlip.SupplierCd;
                    }

                    if (cmpret == 0)
                    {
                        // �̔��敪�R�[�h�Ŕ�r
                        cmpret = xSlip.SalesCode - ySlip.SalesCode;
                    }
                }

                return cmpret;
            }
        }

        /// <summary>
        /// ���i�ʔ��㌎���W�v�f�[�^�p ��r���\�b�h
        /// </summary>
        private class GoodsMTtlSaSlipComparer : IComparer
        {
            public int Compare(object x, object y)
            {
                GoodsMTtlSaSlipWork xSlip = x as GoodsMTtlSaSlipWork;
                GoodsMTtlSaSlipWork ySlip = y as GoodsMTtlSaSlipWork;

                int cmpret = (xSlip == null ? 0 : 1) - (ySlip == null ? 0 : 1);

                if (cmpret == 0 && xSlip != null)
                {
                    // ��ƃR�[�h�Ŕ�r
                    cmpret = string.Compare(xSlip.EnterpriseCode, ySlip.EnterpriseCode);

                    if (cmpret == 0)
                    {
                        // �v�㋒�_�R�[�h�Ŕ�r
                        cmpret = string.Compare(xSlip.AddUpSecCode, ySlip.AddUpSecCode);
                    }

                    if (cmpret == 0)
                    {
                        // �v��N���Ŕ�r
                        cmpret = DateTime.Compare(xSlip.AddUpYearMonth, ySlip.AddUpYearMonth);
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
                        // ���Ӑ�R�[�h�Ŕ�r
                        cmpret = xSlip.CustomerCode - ySlip.CustomerCode;
                    }

                    if (cmpret == 0)
                    {
                        // BL���i�R�[�h�Ŕ�r
                        cmpret = xSlip.BLGoodsCode - ySlip.BLGoodsCode;
                    }

                    if (cmpret == 0)
                    {
                        // ���i���[�J�[�R�[�h�Ŕ�r
                        cmpret = xSlip.GoodsMakerCd - ySlip.GoodsMakerCd;
                    }

                    if (cmpret == 0)
                    {
                        // ���i�ԍ��Ŕ�r
                        cmpret = string.Compare(xSlip.GoodsNo, ySlip.GoodsNo);
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
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.05.19</br>
        public int Delete(MTtlSalesUpdParaWork mTtlSalesUpdParaWork)
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
                status = this.Delete(mTtlSalesUpdParaWork, connection, transaction);
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
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^�𕨗��폜���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.05.19</br>
        public int Delete(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
#if !DEBUG
            // �r�����b�N���s��
            status = this.Lock(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
#endif
            try
            {
                status = this.DeleteMTtlSales(mTtlSalesUpdParaWork, connection, transaction);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ||
                    status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = this.DeleteGoodsMTtlSales(mTtlSalesUpdParaWork, connection, transaction);
                }
            }
            finally
            {
#if !DEBUG
                // �r�����b�N���������
                this.Release(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
#endif
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA���㌎���W�v�f�[�^�𕨗��폜���܂��B
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        private int DeleteMTtlSales(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (mTtlSalesUpdParaWork.MTtlSalesPrcFlg != 1)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("", connection, transaction))
                    {
                        #region [DELETE��]
                        string sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  MTTLSALESSLIPRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

                        // ---UPD 2009/12/24 ----------->>>>
                        //sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                        if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCode))
                        {
                            sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                            command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF >= @FINDADDUPSECCODE" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                            }
                            else if (string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF <= @FINDADDUPSECCODE" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                            }
                            else if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF >= @FINDADDUPSECCODEST AND ADDUPSECCODERF <= @FINDADDUPSECCODEED" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODEST", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                                command.Parameters.Add("FINDADDUPSECCODEED", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                            }
                        }
                        // ---UPD 2009/12/24 -----------<<<

                        if (mTtlSalesUpdParaWork.AddUpYearMonthSt != 0)
                        {
                            sqlText += "  AND ADDUPYEARMONTHRF >= @FINDADDUPYEARMONTHST" + Environment.NewLine;
                            command.Parameters.Add("FINDADDUPYEARMONTHST", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthSt;
                        }

                        if (mTtlSalesUpdParaWork.AddUpYearMonthEd != 0)
                        {
                            sqlText += "  AND ADDUPYEARMONTHRF <= @FINDADDUPYEARMONTHED" + Environment.NewLine;
                            //command.Parameters.Add("FINDADDUPYEARMONTHED", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthSt;  // DEL 2009/12/24
                            command.Parameters.Add("FINDADDUPYEARMONTHED", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthEd;    // ADD 2009/12/24
                        }

                        command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.EnterpriseCode;
                        //command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;    // DEL 2009/12/24

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
            }

            return status;
        }

        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA���i�ʔ��㌎���W�v�f�[�^�𕨗��폜���܂��B
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="connection">�f�[�^�x�[�X�ڑ����</param>
        /// <param name="transaction">�g�����U�N�V�������</param>
        /// <returns>STATUS</returns>
        private int DeleteGoodsMTtlSales(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, SqlConnection connection, SqlTransaction transaction)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (mTtlSalesUpdParaWork.GoodsMTtlSaPrcFlg != 1)
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                try
                {
                    using (SqlCommand command = new SqlCommand("", connection, transaction))
                    {
                        #region [DELETE��]
                        string sqlText = string.Empty;
                        sqlText += "DELETE" + Environment.NewLine;
                        sqlText += "FROM" + Environment.NewLine;
                        sqlText += "  GOODSMTTLSASLIPRF" + Environment.NewLine;
                        sqlText += "WHERE" + Environment.NewLine;
                        sqlText += "  ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;

                        //sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;    // Del 2009/12/24
                        // ---ADD 2009/12/24 -------->>>
                        if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCode))
                        {
                            sqlText += "  AND ADDUPSECCODERF = @FINDADDUPSECCODE" + Environment.NewLine;
                            command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF >= @FINDADDUPSECCODE" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                            }
                            else if (string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF <= @FINDADDUPSECCODE" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                            }
                            else if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                            {
                                sqlText += "  AND ADDUPSECCODERF >= @FINDADDUPSECCODEST AND ADDUPSECCODERF <= @FINDADDUPSECCODEED" + Environment.NewLine;
                                command.Parameters.Add("FINDADDUPSECCODEST", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                                command.Parameters.Add("FINDADDUPSECCODEED", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                            }
                            // ---ADD 2009/12/24 --------<<<
                        }

                        if (mTtlSalesUpdParaWork.AddUpYearMonthSt != 0)
                        {
                            sqlText += "  AND ADDUPYEARMONTHRF >= @FINDADDUPYEARMONTHST" + Environment.NewLine;
                            command.Parameters.Add("FINDADDUPYEARMONTHST", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthSt;
                        }

                        if (mTtlSalesUpdParaWork.AddUpYearMonthEd != 0)
                        {
                            sqlText += "  AND ADDUPYEARMONTHRF <= @FINDADDUPYEARMONTHED" + Environment.NewLine;
                            //command.Parameters.Add("FINDADDUPYEARMONTHED", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthSt;     // DEL 2009/12/24
                            command.Parameters.Add("FINDADDUPYEARMONTHED", SqlDbType.Int).Value = mTtlSalesUpdParaWork.AddUpYearMonthEd;     // ADD 2009/12/24
                        }

                        command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.EnterpriseCode;
                        //command.Parameters.Add("FINDADDUPSECCODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;   // ---DEL 2009/12/24

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
            }

            return status;
        }

        # endregion

        # region [�ďW�v����]

        /// <summary>
        /// �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B
        /// </summary>
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B</br>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.05.19</br>
        /// <br>Update Note: 2009/12/24 杍^ �o�l�D�m�r�ێ�˗��C</br>
        /// <br>                �E�ꊇ���A���X�V�̐V�K��Ή�</br>
        public int ReCount(MTtlSalesUpdParaWork mTtlSalesUpdParaWork)
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
//            SqlCommand command = new SqlCommand("", connection, transaction);
//            SqlDataReader reader = null;
            // ---ADD 2009/12/24 --------<<<

            try
            {
                status = this.ReCountProc(mTtlSalesUpdParaWork, ref connection, ref transaction);  // ADD 2009/12/24

                #region �폜
                // ---DEL 2009/12/24 -------->>>
//                ArrayList newSalesSlips = new ArrayList();

//                # region [�v����t���甄��N����(�J�n�`�I��)���Z�o]

//                // ���t�擾���i�𗘗p����
//                FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlSalesUpdParaWork.EnterpriseCode));

//                DateTime tmpStart;
//                DateTime tmpEnd;
//                int AddUpYearMonthSt = 0;
//                int AddUpYearMonthEd = 0;

//                // �v��N��(�J�n)�����Ɍ��x�J�n�����擾
//                dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlSalesUpdParaWork.AddUpYearMonthSt * 100 + 1), out tmpStart, out tmpEnd);
//                AddUpYearMonthSt = tmpStart.Year * 100 + tmpStart.Month;

//                // �v��N��(�I��)�����Ɍ��x�I�������擾
//                dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlSalesUpdParaWork.AddUpYearMonthEd * 100 + 1), out tmpStart, out tmpEnd);
//                AddUpYearMonthEd = tmpEnd.Year * 100 + tmpEnd.Month;

//                # endregion

//                # region [���㗚���f�[�^�̎擾]

//                // ���㗚���f�[�^���擾
//                string sqlText = string.Empty;
//                sqlText += "SELECT" + Environment.NewLine;
//                sqlText += "  HIST.*" + Environment.NewLine;  // ���ڂ��m�肷��܂� * �ɂ��Ă���
//                sqlText += "FROM" + Environment.NewLine;
//                sqlText += "  SALESHISTORYRF AS HIST" + Environment.NewLine;
//                sqlText += "WHERE" + Environment.NewLine;
//                sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
//                sqlText += "  AND HIST.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
//                sqlText += "  AND HIST.RESULTSADDUPSECCDRF = @FINDRESULTSADDUPSECCD" + Environment.NewLine;
//                sqlText += "  AND (HIST.SALESDATERF >= @FINDSALESDATEST AND HIST.SALESDATERF <= @FINDSALESDATEED)" + Environment.NewLine;
//                command.CommandText = sqlText;
                
//                command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.EnterpriseCode;
//                command.Parameters.Add("FINDRESULTSADDUPSECCD", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;
//                command.Parameters.Add("FINDSALESDATEST", SqlDbType.Int).Value = AddUpYearMonthSt;
//                command.Parameters.Add("FINDSALESDATEED", SqlDbType.Int).Value = AddUpYearMonthEd;

//                reader = command.ExecuteReader();

//                ArrayList headerList = new ArrayList();

//                while (reader.Read())
//                {
//                    headerList.Add(this.CopyToSalesSlipWorkFromReader(reader));
//                }

//                command.Parameters.Clear();

//                # endregion

//                # region [���㗚�𖾍׃f�[�^�̎擾]

//                // ���㗚�𖾍׃f�[�^���擾
//                sqlText = string.Empty;
//                sqlText += "SELECT" + Environment.NewLine;
//                sqlText += "  DTIL.*" + Environment.NewLine;  // ���ڂ��m�肷��܂� * �ɂ��Ă���
//                sqlText += "FROM" + Environment.NewLine;
//                sqlText += "  SALESHISTDTLRF AS DTIL" + Environment.NewLine;
//                sqlText += "WHERE" + Environment.NewLine;
//                sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
//                sqlText += "  AND DTIL.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
//                sqlText += "  AND DTIL.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;

//                command.CommandText = sqlText;

//                SqlParameter findEnterpriseCode = command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar);
//                SqlParameter findSalesSlipNum = command.Parameters.Add("FINDSALESSLIPNUM", SqlDbType.NVarChar);
                
//                foreach (SalesSlipWork header in headerList)
//                {
//                    findEnterpriseCode.Value = header.EnterpriseCode;
//                    findSalesSlipNum.Value = header.SalesSlipNum;

//                    if (!reader.IsClosed)
//                    {
//                        reader.Close();
//                    }

//                    reader = command.ExecuteReader();

//                    ArrayList detail = new ArrayList();

//                    while (reader.Read())
//                    {
//                        detail.Add(this.CopyToSalesDetailWorkFromReader(reader));
//                    }

//                    ArrayList salesSlip = new ArrayList();
//                    salesSlip.Add(header);
//                    salesSlip.Add(detail);
                    
//                    newSalesSlips.Add(salesSlip);
//                }
//                # endregion

//                if (ListUtils.IsEmpty(newSalesSlips))
//                {
//                    status = (int)ConstantManagement.DB_Status.ctDB_EOF;
//                }
//                else
//                {
//#if !DEBUG
//                    // �r�����b�N���s��
//                    status = this.Lock(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
//#endif
//                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//                    {
//                        return status;
//                    }

//                    try
//                    {
//                        // �ďW�v�O�ɑΏ۔͈͂���x�S�č폜����
//                        status = this.Delete(mTtlSalesUpdParaWork, connection, transaction);

//                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
//                        {
//                            return status;
//                        }

//                        // �`�[�o�^�敪�� 2:�ďW�v �ɐݒ�
//                        mTtlSalesUpdParaWork.SlipRegDiv = 2;

//                        // �ďW�v���s��
//                        status = this.Write(mTtlSalesUpdParaWork, newSalesSlips, null, connection, transaction);
//                    }
//                    finally
//                    {
//#if !DEBUG
//                        // �r�����b�N���������
//                        this.Release(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
//#endif
//                    }
//                }
                // ---ADD 2009/12/24 --------<<<
                #endregion 
            }
            finally
            {
                #region �폜
                // ---ADD 2009/12/24 -------->>>
                //if (reader != null)
                //{
                //    if (!reader.IsClosed)
                //    {
                //        reader.Close();
                //    }
                //    reader.Dispose();
                //}

                //if (command != null)
                //{
                //    command.Cancel();
                //    command.Dispose();
                //}
                // ---ADD 2009/12/24 --------<<<
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
        /// <param name="mTtlSalesUpdParaWork">MTtlSalesUpdParaWork�I�u�W�F�N�g</param>
        /// <param name="connection">�c�a�ڑ��I�u�W�F�N�g</param>
        /// <param name="transaction">sqlTransaction�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �w�肳�ꂽ�����Ɋ�Â��āA�e�팎���W�v�f�[�^���ďW�v���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2009/12/24</br>
        public int ReCountProc(MTtlSalesUpdParaWork mTtlSalesUpdParaWork, ref SqlConnection connection, ref SqlTransaction transaction)
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
            Int32 monthRange = ((mTtlSalesUpdParaWork.AddUpYearMonthEd / 100) - (mTtlSalesUpdParaWork.AddUpYearMonthSt / 100)) * 12 + (mTtlSalesUpdParaWork.AddUpYearMonthEd % 100) - (mTtlSalesUpdParaWork.AddUpYearMonthSt % 100) + 1;
            DateTime dt = new DateTime(mTtlSalesUpdParaWork.AddUpYearMonthSt / 100, mTtlSalesUpdParaWork.AddUpYearMonthSt % 100, 1);
            // -- ADD 2010/02/24 ----------------------------------<<<

            try
            {
                // -- ADD 2010/02/24 ------------------------------>>>
                for (int i = 0; i < monthRange; i++)
                {
                    mTtlSalesUpdParaWork.AddUpYearMonthSt = Int32.Parse(dt.ToString("yyyyMM"));
                    mTtlSalesUpdParaWork.AddUpYearMonthEd = Int32.Parse(dt.ToString("yyyyMM"));

                    command.Parameters.Clear();
                // -- ADD 2010/02/24 ------------------------------<<<

                    ArrayList newSalesSlips = new ArrayList();

                    # region [�v����t���甄��N����(�J�n�`�I��)���Z�o]

                    // ���t�擾���i�𗘗p����
                    FinYearTableGenerator dateGetAcs = new FinYearTableGenerator(this.GetCompanyInformation(mTtlSalesUpdParaWork.EnterpriseCode));

                    DateTime tmpStart;
                    DateTime tmpEnd;
                    int AddUpYearMonthSt = 0;
                    int AddUpYearMonthEd = 0;

                    // �v��N��(�J�n)�����Ɍ��x�J�n�����擾
                    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlSalesUpdParaWork.AddUpYearMonthSt * 100 + 1), out tmpStart, out tmpEnd);
                    //AddUpYearMonthSt = tmpStart.Year * 100 + tmpStart.Month;                              // DEL 2009/12/24
                    AddUpYearMonthSt = tmpStart.Year * 10000 + tmpStart.Month * 100 + tmpStart.Day;         // ADD 2009/12/24

                    // �v��N��(�I��)�����Ɍ��x�I�������擾
                    dateGetAcs.GetDaysFromMonth(TDateTime.LongDateToDateTime(mTtlSalesUpdParaWork.AddUpYearMonthEd * 100 + 1), out tmpStart, out tmpEnd);
                    //AddUpYearMonthEd = tmpEnd.Year * 100 + tmpEnd.Month;                                  // DEL 2009/12/24
                    AddUpYearMonthEd = tmpEnd.Year * 10000 + tmpEnd.Month * 100 + tmpEnd.Day;               // ADD 2009/12/24

                    # endregion

                    # region [���㗚���f�[�^�̎擾]

                    // ���㗚���f�[�^���擾
                    string sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  HIST.*" + Environment.NewLine;  // ���ڂ��m�肷��܂� * �ɂ��Ă���
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTORYRF AS HIST" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  HIST.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND HIST.ACPTANODRSTATUSRF = 30" + Environment.NewLine;

                    // ---ADD 2009/12/24 -------->>>
                    if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCode))
                    {
                        sqlText += "  AND HIST.RESULTSADDUPSECCDRF = @FINDRESULTSADDUPSECCD" + Environment.NewLine;
                        command.Parameters.Add("FINDRESULTSADDUPSECCD", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                        {
                            sqlText += "  AND HIST.RESULTSADDUPSECCDRF >= @FINDRESULTSADDUPSECCD" + Environment.NewLine;
                            command.Parameters.Add("FINDRESULTSADDUPSECCD", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                        }
                        else if (string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                        {
                            sqlText += "  AND HIST.RESULTSADDUPSECCDRF <= @FINDRESULTSADDUPSECCD" + Environment.NewLine;
                            command.Parameters.Add("FINDRESULTSADDUPSECCD", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                        }
                        else if (!string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeSt) && !string.IsNullOrEmpty(mTtlSalesUpdParaWork.AddUpSecCodeEd))
                        {
                            sqlText += "  AND HIST.RESULTSADDUPSECCDRF >= @FINDRESULTSADDUPSECCDST AND HIST.RESULTSADDUPSECCDRF <= @FINDRESULTSADDUPSECCDED" + Environment.NewLine;
                            command.Parameters.Add("FINDRESULTSADDUPSECCDST", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeSt;
                            command.Parameters.Add("FINDRESULTSADDUPSECCDED", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCodeEd;
                        }
                    }

                    sqlText += "  AND HIST.LOGICALDELETECODERF = 0 " + Environment.NewLine;
                    // ---ADD 2009/12/24 --------<<<

                    sqlText += "  AND (HIST.SALESDATERF >= @FINDSALESDATEST AND HIST.SALESDATERF <= @FINDSALESDATEED)" + Environment.NewLine;
                    command.CommandText = sqlText;
                    command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.EnterpriseCode;
                    //command.Parameters.Add("FINDRESULTSADDUPSECCD", SqlDbType.NVarChar).Value = mTtlSalesUpdParaWork.AddUpSecCode;  // DEL 2009/12/24
                    command.Parameters.Add("FINDSALESDATEST", SqlDbType.Int).Value = AddUpYearMonthSt;
                    command.Parameters.Add("FINDSALESDATEED", SqlDbType.Int).Value = AddUpYearMonthEd;

                    reader = command.ExecuteReader();

                    ArrayList headerList = new ArrayList();

                    while (reader.Read())
                    {
                        headerList.Add(this.CopyToSalesSlipWorkFromReader(reader));
                    }

                    command.Parameters.Clear();

                    # endregion

                    # region [���㗚�𖾍׃f�[�^�̎擾]

                    // ���㗚�𖾍׃f�[�^���擾
                    sqlText = string.Empty;
                    sqlText += "SELECT" + Environment.NewLine;
                    sqlText += "  DTIL.*" + Environment.NewLine;  // ���ڂ��m�肷��܂� * �ɂ��Ă���
                    sqlText += "FROM" + Environment.NewLine;
                    sqlText += "  SALESHISTDTLRF AS DTIL" + Environment.NewLine;
                    sqlText += "WHERE" + Environment.NewLine;
                    sqlText += "  DTIL.ENTERPRISECODERF = @FINDENTERPRISECODE" + Environment.NewLine;
                    sqlText += "  AND DTIL.ACPTANODRSTATUSRF = 30" + Environment.NewLine;
                    sqlText += "  AND DTIL.SALESSLIPNUMRF = @FINDSALESSLIPNUM" + Environment.NewLine;
                    sqlText += "  AND DTIL.LOGICALDELETECODERF = 0" + Environment.NewLine;             // ADD 2009/12/24

                    command.CommandText = sqlText;

                    SqlParameter findEnterpriseCode = command.Parameters.Add("FINDENTERPRISECODE", SqlDbType.NVarChar);
                    SqlParameter findSalesSlipNum = command.Parameters.Add("FINDSALESSLIPNUM", SqlDbType.NVarChar);

                    foreach (SalesSlipWork header in headerList)
                    {
                        findEnterpriseCode.Value = header.EnterpriseCode;
                        findSalesSlipNum.Value = header.SalesSlipNum;

                        if (!reader.IsClosed)
                        {
                            reader.Close();
                        }

                        reader = command.ExecuteReader();

                        ArrayList detail = new ArrayList();

                        while (reader.Read())
                        {
                            detail.Add(this.CopyToSalesDetailWorkFromReader(reader));
                        }

                        ArrayList salesSlip = new ArrayList();
                        salesSlip.Add(header);
                        salesSlip.Add(detail);

                        newSalesSlips.Add(salesSlip);
                    }

                    // ---ADD 2009/12/24 --->>>
                    if (!reader.IsClosed)
                    {
                        reader.Close();
                    }
                    // ---ADD 2009/12/24 ---<<<
                    # endregion

                    if (ListUtils.IsEmpty(newSalesSlips))
                    {
                        // 2010/07/12 Add >>>
                        status = this.Delete(mTtlSalesUpdParaWork, connection, transaction);

                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }
                        // 2010/07/12 Add <<<
                        status = (int)ConstantManagement.DB_Status.ctDB_EOF;
                    }
                    else
                    {
                        status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     // ADD 2009/12/24
#if !DEBUG
                        // �r�����b�N���s��
                        status = this.Lock(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
#endif
                        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                        {
                            return status;
                        }

                        try
                        {

                            // �ďW�v�O�ɑΏ۔͈͂���x�S�č폜����
                            status = this.Delete(mTtlSalesUpdParaWork, connection, transaction);

                            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                return status;
                            }

                            // �`�[�o�^�敪�� 2:�ďW�v �ɐݒ�
                            mTtlSalesUpdParaWork.SlipRegDiv = 2;

                            // �ďW�v���s��
                            status = this.Write(mTtlSalesUpdParaWork, newSalesSlips, null, connection, transaction);
                        }
                        finally
                        {
#if !DEBUG
                            // �r�����b�N���������
                            this.Release(this.GetLockResourceName(mTtlSalesUpdParaWork), connection, transaction);
#endif
                        }
                    } // ADD 2010/02/24
                    dt = dt.AddMonths(1); // ADD 2010/02/24
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;     // ADD 2010/02/24

                }
            }
            // -- UPD 2010/02/24 ------------------------>>>
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
            // -- UPD 2010/02/24 ------------------------<<<
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

        # endregion
        // ---ADD 2009/12/24--------------------------------------------------------<<<<<<<<<<<<<<<<<

        #region [�N���X�i�[����]
        /// <summary>
        /// �N���X�i�[���� Reader �� salesHistoryWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>salesHistoryWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2008.05.19</br>
        /// </remarks>
        private SalesSlipWork CopyToSalesSlipWorkFromReader(SqlDataReader myReader)
        {
            SalesSlipWork wkSalesSlipWork = new SalesSlipWork();

            this.CopyToSalesSlipWorkFromReader(myReader, ref wkSalesSlipWork);

            return wkSalesSlipWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="wkSalesSlipWork"></param>
        private void CopyToSalesSlipWorkFromReader(SqlDataReader myReader, ref SalesSlipWork wkSalesSlipWork)
        {
            if (wkSalesSlipWork != null)
            {
                #region �N���X�֊i�[
                wkSalesSlipWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                wkSalesSlipWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                wkSalesSlipWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkSalesSlipWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                wkSalesSlipWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                wkSalesSlipWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                wkSalesSlipWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                wkSalesSlipWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                wkSalesSlipWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                wkSalesSlipWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                wkSalesSlipWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                wkSalesSlipWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                wkSalesSlipWork.DebitNoteDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DEBITNOTEDIVRF"));
                wkSalesSlipWork.DebitNLnkSalesSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEBITNLNKSALESSLNUMRF"));
                wkSalesSlipWork.SalesSlipCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDRF"));
                wkSalesSlipWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                wkSalesSlipWork.AccRecDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCRECDIVCDRF"));
                wkSalesSlipWork.SalesInpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPSECCDRF"));
                wkSalesSlipWork.DemandAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DEMANDADDUPSECCDRF"));
                wkSalesSlipWork.ResultsAddUpSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RESULTSADDUPSECCDRF"));
                wkSalesSlipWork.UpdateSecCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDATESECCDRF"));
                wkSalesSlipWork.SalesSlipUpdateCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPUPDATECDRF"));
                wkSalesSlipWork.SearchSlipDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SEARCHSLIPDATERF"));
                wkSalesSlipWork.ShipmentDay = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SHIPMENTDAYRF"));
                wkSalesSlipWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                wkSalesSlipWork.AddUpADate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ADDUPADATERF"));
                wkSalesSlipWork.DelayPaymentDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELAYPAYMENTDIVRF"));
                //wkSalesSlipWork.EstimateFormNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATEFORMNORF"));      // DEL 2009/12/24
                //wkSalesSlipWork.EstimateDivide = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEDIVIDERF"));       // DEL 2009/12/24
                wkSalesSlipWork.InputAgenCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENCDRF"));
                wkSalesSlipWork.InputAgenNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INPUTAGENNMRF"));
                wkSalesSlipWork.SalesInputCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTCODERF"));
                wkSalesSlipWork.SalesInputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESINPUTNAMERF"));
                wkSalesSlipWork.FrontEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEECDRF"));
                wkSalesSlipWork.FrontEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FRONTEMPLOYEENMRF"));
                wkSalesSlipWork.SalesEmployeeCd = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEECDRF"));
                wkSalesSlipWork.SalesEmployeeNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESEMPLOYEENMRF"));
                wkSalesSlipWork.TotalAmountDispWayCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TOTALAMOUNTDISPWAYCDRF"));
                wkSalesSlipWork.TtlAmntDispRateApy = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TTLAMNTDISPRATEAPYRF"));
                wkSalesSlipWork.SalesTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXINCRF"));
                wkSalesSlipWork.SalesTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESTOTALTAXEXCRF"));
                wkSalesSlipWork.SalesPrtTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXINCRF"));
                wkSalesSlipWork.SalesPrtTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTTOTALTAXEXCRF"));
                wkSalesSlipWork.SalesWorkTotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXINCRF"));
                wkSalesSlipWork.SalesWorkTotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKTOTALTAXEXCRF"));
                wkSalesSlipWork.SalesSubtotalTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXINCRF"));
                wkSalesSlipWork.SalesSubtotalTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXEXCRF"));
                wkSalesSlipWork.SalesPrtSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLINCRF"));
                wkSalesSlipWork.SalesPrtSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRTSUBTTLEXCRF"));
                wkSalesSlipWork.SalesWorkSubttlInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLINCRF"));
                wkSalesSlipWork.SalesWorkSubttlExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESWORKSUBTTLEXCRF"));
                wkSalesSlipWork.SalesNetPrice = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESNETPRICERF"));
                wkSalesSlipWork.SalesSubtotalTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSUBTOTALTAXRF"));
                wkSalesSlipWork.ItdedSalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESOUTTAXRF"));
                wkSalesSlipWork.ItdedSalesInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESINTAXRF"));
                wkSalesSlipWork.SalSubttlSubToTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALSUBTTLSUBTOTAXFRERF"));
                wkSalesSlipWork.SalesOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESOUTTAXRF"));
                wkSalesSlipWork.SalAmntConsTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALAMNTCONSTAXINCLURF"));
                wkSalesSlipWork.SalesDisTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXEXCRF"));
                wkSalesSlipWork.ItdedSalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISOUTTAXRF"));
                wkSalesSlipWork.ItdedSalesDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISINTAXRF"));
                wkSalesSlipWork.ItdedPartsDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISOUTTAXRF"));
                wkSalesSlipWork.ItdedPartsDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDPARTSDISINTAXRF"));
                wkSalesSlipWork.ItdedWorkDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISOUTTAXRF"));
                wkSalesSlipWork.ItdedWorkDisInTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDWORKDISINTAXRF"));
                wkSalesSlipWork.ItdedSalesDisTaxFre = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ITDEDSALESDISTAXFRERF"));
                wkSalesSlipWork.SalesDisOutTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISOUTTAXRF"));
                wkSalesSlipWork.SalesDisTtlTaxInclu = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESDISTTLTAXINCLURF"));
                wkSalesSlipWork.PartsDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("PARTSDISCOUNTRATERF"));
                wkSalesSlipWork.RavorDiscountRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("RAVORDISCOUNTRATERF"));
                wkSalesSlipWork.TotalCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("TOTALCOSTRF"));
                wkSalesSlipWork.ConsTaxLayMethod = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CONSTAXLAYMETHODRF"));
                wkSalesSlipWork.ConsTaxRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CONSTAXRATERF"));
                wkSalesSlipWork.FractionProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACTIONPROCCDRF"));
                wkSalesSlipWork.AccRecConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("ACCRECCONSTAXRF"));
                wkSalesSlipWork.AutoDepositCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITCDRF"));
                wkSalesSlipWork.AutoDepositSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("AUTODEPOSITSLIPNORF"));
                wkSalesSlipWork.DepositAllowanceTtl = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALLOWANCETTLRF"));
                wkSalesSlipWork.DepositAlwcBlnce = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("DEPOSITALWCBLNCERF"));
                wkSalesSlipWork.ClaimCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CLAIMCODERF"));
                wkSalesSlipWork.ClaimSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CLAIMSNMRF"));
                wkSalesSlipWork.CustomerCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTOMERCODERF"));
                wkSalesSlipWork.CustomerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAMERF"));
                wkSalesSlipWork.CustomerName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERNAME2RF"));
                wkSalesSlipWork.CustomerSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CUSTOMERSNMRF"));
                wkSalesSlipWork.HonorificTitle = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("HONORIFICTITLERF"));
                wkSalesSlipWork.OutputNameCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OUTPUTNAMECODERF"));
                wkSalesSlipWork.OutputName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("OUTPUTNAMERF"));
                wkSalesSlipWork.CustSlipNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTSLIPNORF"));
                wkSalesSlipWork.SlipAddressDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPADDRESSDIVRF"));
                wkSalesSlipWork.AddresseeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ADDRESSEECODERF"));
                wkSalesSlipWork.AddresseeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAMERF"));
                wkSalesSlipWork.AddresseeName2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEENAME2RF"));
                wkSalesSlipWork.AddresseePostNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEPOSTNORF"));
                wkSalesSlipWork.AddresseeAddr1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR1RF"));
                wkSalesSlipWork.AddresseeAddr3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR3RF"));
                wkSalesSlipWork.AddresseeAddr4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEADDR4RF"));
                wkSalesSlipWork.AddresseeTelNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEETELNORF"));
                wkSalesSlipWork.AddresseeFaxNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ADDRESSEEFAXNORF"));
                wkSalesSlipWork.PartySaleSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSALESLIPNUMRF"));
                wkSalesSlipWork.SlipNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTERF"));
                wkSalesSlipWork.SlipNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE2RF"));
                wkSalesSlipWork.SlipNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPNOTE3RF"));
                wkSalesSlipWork.RetGoodsReasonDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RETGOODSREASONDIVRF"));
                wkSalesSlipWork.RetGoodsReason = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RETGOODSREASONRF"));
                //wkSalesSlipWork.RegiProcDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REGIPROCDATERF"));    // DEL 2009/12/24
                //wkSalesSlipWork.CashRegisterNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CASHREGISTERNORF"));               // DEL 2009/12/24
                //wkSalesSlipWork.PosReceiptNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("POSRECEIPTNORF"));                   // DEL 2009/12/24
                wkSalesSlipWork.DetailRowCount = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DETAILROWCOUNTRF"));
                wkSalesSlipWork.EdiSendDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDISENDDATERF"));
                wkSalesSlipWork.EdiTakeInDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("EDITAKEINDATERF"));
                wkSalesSlipWork.UoeRemark1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK1RF"));
                wkSalesSlipWork.UoeRemark2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UOEREMARK2RF"));
                wkSalesSlipWork.SlipPrintDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTDIVCDRF"));
                wkSalesSlipWork.SlipPrintFinishCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SLIPPRINTFINISHCDRF"));
                wkSalesSlipWork.SalesSlipPrintDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESSLIPPRINTDATERF"));
                wkSalesSlipWork.BusinessTypeCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BUSINESSTYPECODERF"));
                wkSalesSlipWork.BusinessTypeName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BUSINESSTYPENAMERF"));
                //wkSalesSlipWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));                        // DEL 2009/12/24
                wkSalesSlipWork.DeliveredGoodsDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVRF"));
                wkSalesSlipWork.DeliveredGoodsDivNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DELIVEREDGOODSDIVNMRF"));
                wkSalesSlipWork.SalesAreaCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESAREACODERF"));
                wkSalesSlipWork.SalesAreaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESAREANAMERF"));
                //wkSalesSlipWork.ReconcileFlag = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RECONCILEFLAGRF"));                   // DEL 2009/12/24
                wkSalesSlipWork.SlipPrtSetPaperId = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPPRTSETPAPERIDRF"));
                wkSalesSlipWork.CompleteCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("COMPLETECDRF"));
                wkSalesSlipWork.SalesPriceFracProcCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESPRICEFRACPROCCDRF"));
                wkSalesSlipWork.StockGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKGOODSTTLTAXEXCRF"));
                wkSalesSlipWork.PureGoodsTtlTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("PUREGOODSTTLTAXEXCRF"));
                wkSalesSlipWork.ListPricePrintDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICEPRINTDIVRF"));
                wkSalesSlipWork.EraNameDispCd1 = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ERANAMEDISPCD1RF"));
                // ---DEL 2009/12/24 --->>>>
                //wkSalesSlipWork.EstimaTaxDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATAXDIVCDRF"));
                //wkSalesSlipWork.EstimateFormPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ESTIMATEFORMPRTCDRF"));
                //wkSalesSlipWork.EstimateSubject = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATESUBJECTRF"));
                //wkSalesSlipWork.Footnotes1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES1RF"));
                //wkSalesSlipWork.Footnotes2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("FOOTNOTES2RF"));
                //wkSalesSlipWork.EstimateTitle1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE1RF"));
                //wkSalesSlipWork.EstimateTitle2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE2RF"));
                //wkSalesSlipWork.EstimateTitle3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE3RF"));
                //wkSalesSlipWork.EstimateTitle4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE4RF"));
                //wkSalesSlipWork.EstimateTitle5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATETITLE5RF"));
                //wkSalesSlipWork.EstimateNote1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE1RF"));
                //wkSalesSlipWork.EstimateNote2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE2RF"));
                //wkSalesSlipWork.EstimateNote3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE3RF"));
                //wkSalesSlipWork.EstimateNote4 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE4RF"));
                //wkSalesSlipWork.EstimateNote5 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ESTIMATENOTE5RF"));
                //wkSalesSlipWork.EstimateValidityDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("ESTIMATEVALIDITYDATERF"));
                //wkSalesSlipWork.PartsNoPrtCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PARTSNOPRTCDRF"));
                //wkSalesSlipWork.OptionPringDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPTIONPRINGDIVCDRF"));
                //wkSalesSlipWork.RateUseCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEUSECODERF"));
                // ---DEL 2009/12/24 -----<<<<
                #endregion
            }
        }

        /// <summary>
        /// �N���X�i�[���� Reader �� SalesHistDtlWork
        /// </summary>
        /// <param name="myReader">SqlDataReader</param>
        /// <returns>SalesHistDtlWork</returns>
        /// <remarks>
        /// <br>Programmer : 21112�@�v�ۓc�@��</br>
        /// <br>Date       : 2007.10.24</br>
        /// </remarks>
        private SalesDetailWork CopyToSalesDetailWorkFromReader(SqlDataReader myReader)
        {
            SalesDetailWork wkSalesDetailWork = new SalesDetailWork();

            this.CopyToSalesDetailWorkFromReader(myReader, ref wkSalesDetailWork);

            return wkSalesDetailWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myReader"></param>
        /// <param name="wkSalesDetailWork"></param>
        private void CopyToSalesDetailWorkFromReader(SqlDataReader myReader, ref SalesDetailWork wkSalesDetailWork)
        {
            if (wkSalesDetailWork != null)
            {
                #region �N���X�֊i�[
                wkSalesDetailWork.CreateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("CREATEDATETIMERF"));
                wkSalesDetailWork.UpdateDateTime = SqlDataMediator.SqlGetDateTimeFromTicks(myReader, myReader.GetOrdinal("UPDATEDATETIMERF"));
                wkSalesDetailWork.EnterpriseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISECODERF"));
                wkSalesDetailWork.FileHeaderGuid = SqlDataMediator.SqlGetGuid(myReader, myReader.GetOrdinal("FILEHEADERGUIDRF"));
                wkSalesDetailWork.UpdEmployeeCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDEMPLOYEECODERF"));
                wkSalesDetailWork.UpdAssemblyId1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID1RF"));
                wkSalesDetailWork.UpdAssemblyId2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("UPDASSEMBLYID2RF"));
                wkSalesDetailWork.LogicalDeleteCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LOGICALDELETECODERF"));
                wkSalesDetailWork.AcceptAnOrderNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACCEPTANORDERNORF"));
                wkSalesDetailWork.AcptAnOdrStatus = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSRF"));
                wkSalesDetailWork.SalesSlipNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESSLIPNUMRF"));
                wkSalesDetailWork.SalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWNORF"));
                wkSalesDetailWork.SalesRowDerivNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESROWDERIVNORF"));
                wkSalesDetailWork.SectionCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SECTIONCODERF"));
                wkSalesDetailWork.SubSectionCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUBSECTIONCODERF"));
                wkSalesDetailWork.SalesDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("SALESDATERF"));
                wkSalesDetailWork.CommonSeqNo = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COMMONSEQNORF"));
                wkSalesDetailWork.SalesSlipDtlNum = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMRF"));
                wkSalesDetailWork.AcptAnOdrStatusSrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ACPTANODRSTATUSSRCRF"));
                wkSalesDetailWork.SalesSlipDtlNumSrc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESSLIPDTLNUMSRCRF"));
                wkSalesDetailWork.SupplierFormalSync = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERFORMALSYNCRF"));
                wkSalesDetailWork.StockSlipDtlNumSync = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("STOCKSLIPDTLNUMSYNCRF"));
                wkSalesDetailWork.SalesSlipCdDtl = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESSLIPCDDTLRF"));
                //wkSalesDetailWork.DeliGdsCmpltDueDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("DELIGDSCMPLTDUEDATERF"));  // DEL 2009/12/24
                wkSalesDetailWork.GoodsKindCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSKINDCODERF"));
                //wkSalesDetailWork.GoodsSearchDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSSEARCHDIVCDRF"));                       // DEL 2009/12/24
                wkSalesDetailWork.GoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMAKERCDRF"));
                wkSalesDetailWork.MakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERNAMERF"));
                wkSalesDetailWork.MakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("MAKERKANANAMERF"));
                //wkSalesDetailWork.CmpltMakerKanaName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERKANANAMERF"));                  // DEL 2009/12/24
                wkSalesDetailWork.GoodsNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNORF"));
                wkSalesDetailWork.GoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMERF"));
                wkSalesDetailWork.GoodsNameKana = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSNAMEKANARF"));
                wkSalesDetailWork.GoodsLGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSLGROUPRF"));
                wkSalesDetailWork.GoodsLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSLGROUPNAMERF"));
                wkSalesDetailWork.GoodsMGroup = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GOODSMGROUPRF"));
                wkSalesDetailWork.GoodsMGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSMGROUPNAMERF"));
                wkSalesDetailWork.BLGroupCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGROUPCODERF"));
                wkSalesDetailWork.BLGroupName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGROUPNAMERF"));
                wkSalesDetailWork.BLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("BLGOODSCODERF"));
                wkSalesDetailWork.BLGoodsFullName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("BLGOODSFULLNAMERF"));
                wkSalesDetailWork.EnterpriseGanreCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("ENTERPRISEGANRECODERF"));
                wkSalesDetailWork.EnterpriseGanreName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ENTERPRISEGANRENAMERF"));
                wkSalesDetailWork.WarehouseCode = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSECODERF"));
                wkSalesDetailWork.WarehouseName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSENAMERF"));
                wkSalesDetailWork.WarehouseShelfNo = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("WAREHOUSESHELFNORF"));
                wkSalesDetailWork.SalesOrderDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESORDERDIVCDRF"));
                wkSalesDetailWork.OpenPriceDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("OPENPRICEDIVRF"));
                wkSalesDetailWork.GoodsRateRank = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("GOODSRATERANKRF"));
                wkSalesDetailWork.CustRateGrpCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CUSTRATEGRPCODERF"));
                wkSalesDetailWork.ListPriceRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICERATERF"));
                wkSalesDetailWork.RateSectPriceUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTPRICEUNPRCRF"));
                wkSalesDetailWork.RateDivLPrice = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVLPRICERF"));
                wkSalesDetailWork.UnPrcCalcCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDLPRICERF"));
                wkSalesDetailWork.PriceCdLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDLPRICERF"));
                wkSalesDetailWork.StdUnPrcLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCLPRICERF"));
                wkSalesDetailWork.FracProcUnitLPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITLPRICERF"));
                wkSalesDetailWork.FracProcLPrice = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCLPRICERF"));
                wkSalesDetailWork.ListPriceTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXINCFLRF"));
                wkSalesDetailWork.ListPriceTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("LISTPRICETAXEXCFLRF"));
                wkSalesDetailWork.ListPriceChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("LISTPRICECHNGCDRF"));
                wkSalesDetailWork.SalesRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESRATERF"));
                wkSalesDetailWork.RateSectSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTSALUNPRCRF"));
                wkSalesDetailWork.RateDivSalUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVSALUNPRCRF"));
                wkSalesDetailWork.UnPrcCalcCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDSALUNPRCRF"));
                wkSalesDetailWork.PriceCdSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDSALUNPRCRF"));
                wkSalesDetailWork.StdUnPrcSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCSALUNPRCRF"));
                wkSalesDetailWork.FracProcUnitSalUnPrc = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITSALUNPRCRF"));
                wkSalesDetailWork.FracProcSalUnPrc = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCSALUNPRCRF"));
                wkSalesDetailWork.SalesUnPrcTaxIncFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXINCFLRF"));
                wkSalesDetailWork.SalesUnPrcTaxExcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNPRCTAXEXCFLRF"));
                wkSalesDetailWork.SalesUnPrcChngCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNPRCCHNGCDRF"));
                wkSalesDetailWork.CostRate = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("COSTRATERF"));
                wkSalesDetailWork.RateSectCstUnPrc = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATESECTCSTUNPRCRF"));
                wkSalesDetailWork.RateDivUnCst = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEDIVUNCSTRF"));
                wkSalesDetailWork.UnPrcCalcCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("UNPRCCALCCDUNCSTRF"));
                wkSalesDetailWork.PriceCdUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRICECDUNCSTRF"));
                wkSalesDetailWork.StdUnPrcUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("STDUNPRCUNCSTRF"));
                wkSalesDetailWork.FracProcUnitUnCst = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("FRACPROCUNITUNCSTRF"));
                wkSalesDetailWork.FracProcUnCst = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("FRACPROCUNCSTRF"));
                wkSalesDetailWork.SalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SALESUNITCOSTRF"));
                wkSalesDetailWork.SalesUnitCostChngDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESUNITCOSTCHNGDIVRF"));
                wkSalesDetailWork.RateBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("RATEBLGOODSCODERF"));
                wkSalesDetailWork.RateBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("RATEBLGOODSNAMERF"));
                wkSalesDetailWork.PrtBLGoodsCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("PRTBLGOODSCODERF"));
                wkSalesDetailWork.PrtBLGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PRTBLGOODSNAMERF"));
                wkSalesDetailWork.SalesCode = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESCODERF"));
                wkSalesDetailWork.SalesCdNm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SALESCDNMRF"));
                wkSalesDetailWork.WorkManHour = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("WORKMANHOURRF"));
                wkSalesDetailWork.ShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("SHIPMENTCNTRF"));
                //wkSalesDetailWork.AcceptAnOrderCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACCEPTANORDERCNTRF"));                    // DEL 2009/12/24
                //wkSalesDetailWork.AcptAnOdrAdjustCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRADJUSTCNTRF"));                // DEL 2009/12/24
                //wkSalesDetailWork.AcptAnOdrRemainCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("ACPTANODRREMAINCNTRF"));                // DEL 2009/12/24
                //wkSalesDetailWork.RemainCntUpdDate = SqlDataMediator.SqlGetDateTimeFromYYYYMMDD(myReader, myReader.GetOrdinal("REMAINCNTUPDDATERF"));      // DEL 2009/12/24
                wkSalesDetailWork.SalesMoneyTaxInc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXINCRF"));
                wkSalesDetailWork.SalesMoneyTaxExc = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESMONEYTAXEXCRF"));
                wkSalesDetailWork.Cost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("COSTRF"));
                wkSalesDetailWork.GrsProfitChkDiv = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("GRSPROFITCHKDIVRF"));
                wkSalesDetailWork.SalesGoodsCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SALESGOODSCDRF"));
                wkSalesDetailWork.SalesPriceConsTax = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("SALESPRICECONSTAXRF"));
                wkSalesDetailWork.TaxationDivCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("TAXATIONDIVCDRF"));
                wkSalesDetailWork.PartySlipNumDtl = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("PARTYSLIPNUMDTLRF"));
                wkSalesDetailWork.DtlNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("DTLNOTERF"));
                wkSalesDetailWork.SupplierCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("SUPPLIERCDRF"));
                wkSalesDetailWork.SupplierSnm = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SUPPLIERSNMRF"));
                wkSalesDetailWork.OrderNumber = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("ORDERNUMBERRF"));
                wkSalesDetailWork.WayToOrder = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("WAYTOORDERRF"));
                wkSalesDetailWork.SlipMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO1RF"));
                wkSalesDetailWork.SlipMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO2RF"));
                wkSalesDetailWork.SlipMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("SLIPMEMO3RF"));
                wkSalesDetailWork.InsideMemo1 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO1RF"));
                wkSalesDetailWork.InsideMemo2 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO2RF"));
                wkSalesDetailWork.InsideMemo3 = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("INSIDEMEMO3RF"));
                wkSalesDetailWork.BfListPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFLISTPRICERF"));
                wkSalesDetailWork.BfSalesUnitPrice = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFSALESUNITPRICERF"));
                wkSalesDetailWork.BfUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("BFUNITCOSTRF"));
                wkSalesDetailWork.CmpltSalesRowNo = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTSALESROWNORF"));
                wkSalesDetailWork.CmpltGoodsMakerCd = SqlDataMediator.SqlGetInt32(myReader, myReader.GetOrdinal("CMPLTGOODSMAKERCDRF"));
                wkSalesDetailWork.CmpltMakerName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTMAKERNAMERF"));
                wkSalesDetailWork.CmpltGoodsName = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTGOODSNAMERF"));
                wkSalesDetailWork.CmpltShipmentCnt = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSHIPMENTCNTRF"));
                wkSalesDetailWork.CmpltSalesUnPrcFl = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNPRCFLRF"));
                wkSalesDetailWork.CmpltSalesMoney = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTSALESMONEYRF"));
                wkSalesDetailWork.CmpltSalesUnitCost = SqlDataMediator.SqlGetDouble(myReader, myReader.GetOrdinal("CMPLTSALESUNITCOSTRF"));
                wkSalesDetailWork.CmpltCost = SqlDataMediator.SqlGetInt64(myReader, myReader.GetOrdinal("CMPLTCOSTRF"));
                wkSalesDetailWork.CmpltPartySalSlNum = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTPARTYSALSLNUMRF"));
                wkSalesDetailWork.CmpltNote = SqlDataMediator.SqlGetString(myReader, myReader.GetOrdinal("CMPLTNOTERF"));
                #endregion
            }
        }
        #endregion        
    }
}
