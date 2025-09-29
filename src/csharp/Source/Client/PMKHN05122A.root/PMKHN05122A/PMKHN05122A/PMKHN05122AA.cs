//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��A�N�Z�X�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/23  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̓��Ӑ�}�X�^�R�[�h�ϊ��A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/23</br>
    /// </remarks>
    public class CustomerConvertAcs
    {
        #region -- Member --

        /// <summary>���Ӑ�}�X�^�R�[�h�ϊ������[�g�I�u�W�F�N�g</summary>
        private ICustomerConvertDB iCustomerConvertDb = null;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@���Ӑ�}�X�^�R�[�h�ϊ��A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A���Ӑ�}�X�^�R�[�h�ϊ��A�N�Z�X�N���X�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public CustomerConvertAcs()
        {
            // CustomerConvertDB�̏��������s���܂��B
            this.iCustomerConvertDb = (ICustomerConvertDB)MediationCustomerConvertDB.GetCustomerConvertDB();
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// �S���҃}�X�^��������
        /// </summary>
        /// <param name="dispWork">��������</param>
        /// <param name="customerConvertList">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�����o��������S���҃}�X�^�̏����擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public int SearchCustomer(CustomerSearchDispWork dispWork, List<CustomerDispInfo> customerConvertList)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �����[�g�I�u�W�F�N�g�����s����ׂɕK�v�ȃp�����[�^�����������܂��B
            object prmObj = this.DispInfoToSearchParamWork(dispWork);
            ArrayList retList = new ArrayList();
            object retObj = retList;

            // �����[�g�I�u�W�F�N�g�����s���ADB����f�[�^���������܂��B
            status = this.iCustomerConvertDb.Search(prmObj, ref retObj);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �f�[�^���擾�ł����ꍇ�́AcustomerConvertList�Ɋi�[���܂��B
                retList = retObj as ArrayList;
                foreach (CustomerSearchWork work in retList)
                {
                    customerConvertList.Add(new CustomerDispInfo(work.CustomerCode, 
                        work.CustomerName, work.LogicalDelete));
                }
            }

            return status;
        }

        /// <summary>
        /// ���Ӑ�R�[�h�ϊ�����
        /// </summary>
        /// <param name="trgTblList">�ϊ��Ώۃe�[�u�����</param>
        /// <param name="cnvDataList">>�ϊ�����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="numberOfTransactions">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���ϊ��������ɓ��Ӑ�R�[�h�̃R�[�h�ϊ����s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public int ConvertCustomer(TargetTableListResult trgTblList, IList<CustomerConvertData> cnvDataList,
            string enterpriseCode, ref int numberOfTransactions)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �����[�g�I�u�W�F�N�g�����s����̂ɕK�v�ȃp�����[�^�����������܂��B
            object paramObj = this.DispInfoToConvertParamWork(trgTblList, cnvDataList, enterpriseCode);

            // �����[�g�I�u�W�F�N�g�����s���A�R�[�h�̕ϊ������s���܂��B
            status = this.iCustomerConvertDb.Convert(paramObj, ref numberOfTransactions);
            return status;
        }

        /// <summary>
        /// �R�[�h�ϊ��Ώۃe�[�u�����X�g�擾����
        /// </summary>
        /// <param name="targetTableMap">�R�[�h�ϊ��Ώۃe�[�u���̃��X�g</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���ϊ��������ɓ��Ӑ�R�[�h�̃R�[�h�ϊ����s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        public int GetConvertTableList(IDictionary<string, TargetTableListResult> targetTableMap)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            IDictionary<string, CustomerTargetTableList> retObjMap = new Dictionary<string, CustomerTargetTableList>();
            Object retObj = retObjMap;

            // �����[�g�I�u�W�F�N�g�����{���A�R�[�h�ϊ��Ώۂ̃e�[�u�����X�g(key:�e�[�u����,value:�J�����̃��X�g)���擾���܂��B
            status = this.iCustomerConvertDb.GetConvertTableList(ref retObj);

            // �X�e�[�^�X�������̏ꍇ�́AXML����擾�������e��ϐ��ɓ���ւ���
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                retObjMap = retObj as IDictionary<string, CustomerTargetTableList>;
                foreach (string key in retObjMap.Keys)
                {
                    targetTableMap[key] = this.TargetTableListToTargetTableListResult(retObjMap[key]);
                }
            }

            return status;
        }

        #endregion

        #region -- Private Method --

        #region -- �����֘A --

        /// <summary>
        /// �f�[�^�ϊ�����
        /// </summary>
        /// <param name="dispInfo">�ϊ��O�f�[�^</param>
        /// <returns>�ϊ���f�[�^</returns>
        /// <remarks>
        /// <br>Note       : CustomerSearchDispWork����CustomerSearchParamWork�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private CustomerSearchParamWork DispInfoToSearchParamWork(CustomerSearchDispWork dispInfo)
        {
            CustomerSearchParamWork prmWk = new CustomerSearchParamWork();
            // ��ƃR�[�h
            prmWk.EnterpriseCode = dispInfo.EnterpriseCode;
            // ���Ӑ�R�[�h(�J�n)
            prmWk.CustomerCodeStart = dispInfo.CustomerCodeStart;
            // ���Ӑ�R�[�h(�I��)
            prmWk.CustomerCodeEnd = dispInfo.CustomerCodeEnd;

            return prmWk;
        }

        #endregion

        #region -- �R�[�h�ϊ��֘A --

        /// <summary>
        /// �f�[�^�ϊ�����
        /// </summary>
        /// <param name="trgTblList">�ϊ��e�[�u�����</param>
        /// <param name="cnvDataList">�ϊ��f�[�^�̃��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�ϊ���f�[�^</returns>
        /// <remarks>
        /// <br>Note       : CustomerConvertData����CustomerConvertParamInfoList�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private CustomerConvertParamInfoList DispInfoToConvertParamWork(TargetTableListResult trgTblList,
            IList<CustomerConvertData> cnvDataList, string enterpriseCode)
        {
            CustomerConvertParamInfoList prmInfoList = new CustomerConvertParamInfoList();
            // ��ƃR�[�h
            prmInfoList.EnterpriseCode = enterpriseCode;
            // �R�[�h�ϊ��Ώۃe�[�u��(������)
            prmInfoList.TargetTable = trgTblList.TargetTable;
            // �R�[�h�ϊ��ΏۃJ������(������)�̃��X�g
            prmInfoList.ColumnList = trgTblList.ColumnList;
            // �R�[�h�ϊ��Ώۃf�[�^�̃��X�g
            prmInfoList.CustomerConvertParamWorkList = new List<CustomerConvertParamWork>(cnvDataList.Count);
            foreach (CustomerConvertData cnvData in cnvDataList)
            {
                CustomerConvertParamWork prmWk = new CustomerConvertParamWork();
                // �ύX�O���Ӑ�R�[�h
                prmWk.BfCustomerCode = cnvData.BfCustomerCd;
                // �ύX�㓾�Ӑ�R�[�h
                prmWk.AfCustomerCode = cnvData.AfCustomerCd;
                prmInfoList.CustomerConvertParamWorkList.Add(prmWk);
            }

            return prmInfoList;
        }

        #endregion

        #region -- �e�[�u�����擾�����֘A --

        /// <summary>
        /// �f�[�^�ϊ�����
        /// </summary>
        /// <param name="trgTblList">�e�[�u�����</param>
        /// <returns>�e�[�u�����</returns>
        /// <remarks>
        /// <br>Note       : TargetTableList����TargetTableListResult�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/23</br>
        /// </remarks>
        private TargetTableListResult TargetTableListToTargetTableListResult(CustomerTargetTableList trgTblList)
        {
            TargetTableListResult trgTblLstRslt = new TargetTableListResult();
            // �Ώۃe�[�u����(������)
            trgTblLstRslt.TargetTable = trgTblList.TargetTable;
            // �Ώۃe�[�u����(�_����)
            trgTblLstRslt.TargetTableName = trgTblList.TargetTableName;
            // �ΏۃJ������(������)�̃��X�g
            trgTblLstRslt.ColumnList = trgTblList.ColumnList;

            return trgTblLstRslt;
        }

        #endregion

        #endregion
    }
}
