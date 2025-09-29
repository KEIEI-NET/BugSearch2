//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ��A�N�Z�X�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/03/10  �C�����e : �V�K�쐬
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
    /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ��A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̒S���҃}�X�^�R�[�h�ϊ��A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/03/10</br>
    /// </remarks>
    public class EmployeeConvertAcs
    {
        #region -- Member --

        /// <summary>�S���҃}�X�^�R�[�h�ϊ������[�g�I�u�W�F�N�g</summary>
        private IEmployeeConvertDB iEmployeeConvertDb = null;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@�S���҃}�X�^�R�[�h�ϊ��A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A�S���҃}�X�^�R�[�h�ϊ��A�N�Z�X�N���X�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public EmployeeConvertAcs()
        {
            // EmployeeConvertDB�̏��������s���܂��B
            this.iEmployeeConvertDb = (IEmployeeConvertDB)MediationEmployeeConvertDB.GetEmployeeConvertDB();
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// �S���҃}�X�^��������
        /// </summary>
        /// <param name="dispWork">��������</param>
        /// <param name="employeeConvertList">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�����o��������S���҃}�X�^�̏����擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public int SearchEmployee(EmployeeSearchDispWork dispWork, List<EmployeeDispInfo> employeeConvertList)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �����[�g�I�u�W�F�N�g�����s����̂ɕK�v�ȃp�����[�^�����������܂��B
            object prmObj = this.DispInfoToSearchParamWork(dispWork);
            ArrayList retList = new ArrayList();
            object retObj = retList;

            // �����[�g�I�u�W�F�N�g�����s���ADB����f�[�^���������܂��B
            status = this.iEmployeeConvertDb.Search(prmObj, ref retObj);
            if (status == 0)
            {
                // �f�[�^���擾�ł����ꍇ�́AemployeeConvertList�Ɋi�[���܂��B
                retList = retObj as ArrayList;
                foreach (EmployeeSearchWork work in retList)
                {
                    employeeConvertList.Add(new EmployeeDispInfo(work.EmployeeCode, 
                        work.EmployeeName, work.LogicalDelete));
                }
            }

            return status;
        }

        /// <summary>
        /// �S���҃R�[�h�ϊ�����
        /// </summary>
        /// <param name="trgTblList">�ϊ��Ώۃe�[�u�����</param>
        /// <param name="cnvDataList">>�ϊ�����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="numberOfTransactions">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���ϊ��������ɒS���҃R�[�h�̃R�[�h�ϊ����s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public int ConvertEmployee(TargetTableListResult trgTblList, IList<EmployeeConvertData> cnvDataList,
            string enterpriseCode, ref int numberOfTransactions)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �����[�g�I�u�W�F�N�g�����s����̂ɕK�v�ȃp�����[�^�̏��������s���܂��B
            object paramObj = this.DispInfoToConvertParamWork(trgTblList, cnvDataList, enterpriseCode);

            // �����[�g�I�u�W�F�N�g�����s���A�R�[�h�̕ϊ������s���܂��B
            status = this.iEmployeeConvertDb.Convert(paramObj, ref numberOfTransactions);

            return status;
        }

        /// <summary>
        /// �R�[�h�ϊ��Ώۃe�[�u�����X�g�擾����
        /// </summary>
        /// <param name="targetTableMap">�R�[�h�ϊ��Ώۃe�[�u���̃��X�g</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���ϊ��������ɒS���҃R�[�h�̃R�[�h�ϊ����s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        public int GetConvertTableList(IDictionary<string, TargetTableListResult> targetTableMap)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            IDictionary<string, EmployeeTargetTableList> retObjMap = new Dictionary<string, EmployeeTargetTableList>();
            Object retObj = retObjMap;

            // �����[�g�I�u�W�F�N�g�����{���A�R�[�h�ϊ��Ώۂ̃e�[�u�����X�g(key:�e�[�u����,value�F�J�����̃��X�g)���擾���܂��B
            status = this.iEmployeeConvertDb.GetConvertTableList(ref retObj);

            // �X�e�[�^�X�������̏ꍇ�́AXML����擾�������e��ϐ��ɓ���ւ���
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                retObjMap = retObj as IDictionary<string, EmployeeTargetTableList>;
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
        /// <br>Note       : EmployeeSearchDispWork����EmployeeSearchParamWork�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private EmployeeSearchParamWork DispInfoToSearchParamWork(EmployeeSearchDispWork dispInfo)
        {
            EmployeeSearchParamWork prmWk = new EmployeeSearchParamWork();
            // ��ƃR�[�h
            prmWk.EnterpriseCode = dispInfo.EnterpriseCode;
            // �S���҃R�[�h(�J�n)
            prmWk.EmployeeCodeStart = dispInfo.EmployeeCodeStart;
            // �S���҃R�[�h(�I��)
            prmWk.EmployeeCodeEnd = dispInfo.EmployeeCodeEnd;

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
        /// <br>Note       : EmployeeConvertData����EmployeeConvertParamInfoList�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private EmployeeConvertParamInfoList DispInfoToConvertParamWork(TargetTableListResult trgTblList, 
            IList<EmployeeConvertData> cnvDataList, string enterpriseCode)
        {
            EmployeeConvertParamInfoList prmInfoList = new EmployeeConvertParamInfoList();
            // ��ƃR�[�h
            prmInfoList.EnterpriseCode = enterpriseCode;
            // �R�[�h�ϊ��Ώۃe�[�u��(������)
            prmInfoList.TargetTable = trgTblList.TargetTable;
            // �R�[�h�ϊ��ΏۃJ������(������)�̃��X�g
            prmInfoList.ColumnList = trgTblList.ColumnList;
            // �R�[�h�ϊ��Ώۃf�[�^�̃��X�g
            prmInfoList.EmployeeConvertParamWorkList = new List<EmployeeConvertParamWork>(cnvDataList.Count);
            foreach (EmployeeConvertData cnvData in cnvDataList)
            {
                EmployeeConvertParamWork prmWk = new EmployeeConvertParamWork();
                // �ύX�O�S���҃R�[�h
                prmWk.BfEmployeeCode = cnvData.BfEmployeeCd;
                // �ύX��S���҃R�[�h
                prmWk.AfEmployeeCode = cnvData.AfEmployeeCd;
                prmInfoList.EmployeeConvertParamWorkList.Add(prmWk);
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
        /// <br>Date       : 2016/03/10</br>
        /// </remarks>
        private TargetTableListResult TargetTableListToTargetTableListResult(EmployeeTargetTableList trgTblList)
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
