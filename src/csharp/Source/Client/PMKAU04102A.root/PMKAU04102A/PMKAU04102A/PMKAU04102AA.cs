using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Collections;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �X�V����\���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �X�V����\���A�N�Z�X�N���X</br>
    /// <br>Programmer  : 30414 �E �K�j</br>
    /// <br>Date        : 2008/09/29</br>
    /// </remarks>
    public class UpdHisDspAcs
    {
        #region Private Members

        private string _enterpriseCode;

        private IUpdHisDspDB _iUpdHisDspDB;

        private SecInfoAcs _secInfoAcs;
        private SupplierAcs _supplierAcs;
        private CustomerInfoAcs _customerInfoAcs;
        private DateGetAcs _dateGetAcs;

        private Dictionary<string, SecInfoSet> _secInfoSetDic;
        private Dictionary<int, Supplier> _supplierDic;

        #endregion Private Members


        #region Constructor

        /// <summary>
        /// �X�V����\���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note        : �X�V����\���A�N�Z�X�N���X�̃C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        public UpdHisDspAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iUpdHisDspDB = (IUpdHisDspDB)MediationUpdHisDspDB.GetUpdHisDspDB();

            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iUpdHisDspDB = null;
            }

            // ��ƃR�[�h���擾
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;

            this._secInfoAcs = new SecInfoAcs();
            this._supplierAcs = new SupplierAcs();
            this._customerInfoAcs = new CustomerInfoAcs();
            this._dateGetAcs = DateGetAcs.GetInstance();

            // �e��}�X�^�Ǎ�
            ReadSecInfoSet();
            ReadSupplier();
        }

        #endregion Constructor


        #region Public Methods

        /// <summary>
        /// ���_���̎擾����
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>���_����</returns>
        /// <remarks>
        /// <br>Note        : ���_���̂��擾���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        public string GetSectionName(string sectionCode)
        {
            string sectionName = "";

            if (this._secInfoSetDic.ContainsKey(sectionCode.Trim()))
            {
                sectionName = this._secInfoSetDic[sectionCode.Trim()].SectionGuideNm.Trim();
            }

            return sectionName;
        }

        /// <summary>
        /// ���Ӑ於�̎擾����
        /// </summary>
        /// <param name="customerCode">���Ӑ�R�[�h</param>
        /// <returns>���Ӑ於��</returns>
        /// <remarks>
        /// <br>Note        : ���Ӑ於�̂��擾���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        public string GetCustomerName(int customerCode)
        {
            string customerName = "";

            try
            {
                CustomerInfo customerInfo;

                int status = this._customerInfoAcs.ReadDBData(this._enterpriseCode, customerCode, out customerInfo);
                if (status == 0)
                {
                    customerName = customerInfo.CustomerSnm.Trim();
                }
            }
            catch
            {
                customerName = "";
            }

            return customerName;
        }

        /// <summary>
        /// �d���於�̎擾����
        /// </summary>
        /// <param name="supplierCode">�d����R�[�h</param>
        /// <returns>�d���於��</returns>
        /// <remarks>
        /// <br>Note        : �d���於�̂��擾���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        public string GetSupplierName(int supplierCode)
        {
            string supplierName = "";

            if (this._supplierDic.ContainsKey(supplierCode))
            {
                supplierName = this._supplierDic[supplierCode].SupplierSnm.Trim();
            }

            return supplierName;
        }

        /// <summary>
        /// ����N�����擾����
        /// </summary>
        /// <returns>����N����</returns>
        /// <remarks>
        /// <br>Note        : ����N�������擾���܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        public DateTime GetStartYearDate()
        {
            DateTime startYearDate = new DateTime();

            try
            {
                int year;
                DateTime dateTime;

                this._dateGetAcs.GetThisYearMonth(out dateTime, out year, out dateTime, out dateTime, out startYearDate, out dateTime);
            }
            catch
            {
                startYearDate = new DateTime();
            }

            return startYearDate;
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="extrInfo">��������</param>
        /// <param name="updHisDspWorkList">�������ʃ��X�g</param>
        /// <returns>�X�e�[�^�X</returns>
        public int Search(ExtrInfo_UpdHisDspWork extrInfo, out List<RsltInfo_UpdHisDspWork> updHisDspWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            updHisDspWorkList = new List<RsltInfo_UpdHisDspWork>();

            ArrayList retList;

            object paraObj = extrInfo;
            object retObj;

            try
            {
                status = this._iUpdHisDspDB.Search(out retObj, paraObj);
                if (status == 0)
                {
                    retList = retObj as ArrayList;
                    foreach (RsltInfo_UpdHisDspWork rsltInfo in retList)
                    {
                        updHisDspWorkList.Add(rsltInfo);
                    }
                }
            }
            catch
            {
                status = -1;
                updHisDspWorkList = new List<RsltInfo_UpdHisDspWork>();
            }

            return (status);
        }

        #endregion Public Methods


        #region Private Methods

        /// <summary>
        /// ���_�}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        : ���_�}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void ReadSecInfoSet()
        {
            this._secInfoSetDic = new Dictionary<string, SecInfoSet>();

            try
            {
                foreach (SecInfoSet secInfoSet in this._secInfoAcs.SecInfoSetList)
                {
                    if (secInfoSet.LogicalDeleteCode != 0)
                    {
                        continue;
                    }

                    this._secInfoSetDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                }
            }
            catch
            {
                this._secInfoSetDic = new Dictionary<string, SecInfoSet>();
            }
        }

        /// <summary>
        /// �d����}�X�^�Ǎ�����
        /// </summary>
        /// <remarks>
        /// <br>Note        :�d����}�X�^��ǂݍ��݁A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer  : 30414 �E �K�j</br>
        /// <br>Date        : 2008/09/29</br>
        /// </remarks>
        private void ReadSupplier()
        {
            this._supplierDic = new Dictionary<int, Supplier>();

            try
            {
                ArrayList retList;

                int status = this._supplierAcs.SearchAll(out retList, this._enterpriseCode);
                if (status == 0)
                {
                    foreach (Supplier supplier in retList)
                    {
                        if (supplier.LogicalDeleteCode != 0)
                        {
                            continue;
                        }

                        this._supplierDic.Add(supplier.SupplierCd, supplier);
                    }
                }
            }
            catch
            {
                this._supplierDic = new Dictionary<int, Supplier>();
            }
        }

        #endregion Private Methods
    }
}
