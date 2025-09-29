//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��A�N�Z�X�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2015 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2016/02/18  �C�����e : �V�K�쐬
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
    /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̑q�Ƀ}�X�^�R�[�h�ϊ��A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2016/02/18</br>
    /// </remarks>
    public class WarehouseConvertAcs
    {
        #region -- Member --

        /// <summary>�q�Ƀ}�X�^�R�[�h�ϊ������[�g�I�u�W�F�N�g</summary>
        private IWarehouseConvertDB iWarehouseConvertDb;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@�q�Ƀ}�X�^�R�[�h�ϊ��A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A�q�Ƀ}�X�^�R�[�h�ϊ��A�N�Z�X�N���X�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public WarehouseConvertAcs()
        {
            // WarehouseConvertDB�̏��������s���܂�
            this.iWarehouseConvertDb = (IWarehouseConvertDB)MediationWarehouseConvertDB.GetWarehouseConvertDB();
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// �q�Ƀ}�X�^��������
        /// </summary>
        /// <param name="prmWk">��������</param>
        /// <param name="warehouseConvertList">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�����o��������q�Ƀ}�X�^�̏����擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public int SearchWarehouse(WarehouseConvertDispInfo dispInfo, List<WarehouseDispInfo> warehouseConvertList)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �����[�g�I�u�W�F�N�g�����s����̂ɕK�v�ȃp�����[�^�����������܂��B
            object paramObj = this.DispInfoToSearchPrmWork(dispInfo);
            ArrayList retList = new ArrayList();
            object retObj = retList;

            // �����[�g�I�u�W�F�N�g�����s���ADB����f�[�^���������܂��B
            status = this.iWarehouseConvertDb.Search(paramObj, ref retObj);
            if (status == 0)
            {
                // �f�[�^���擾�ł����ꍇ��warehouseConvertList�Ɋi�[���܂��B
                retList = retObj as ArrayList;
                foreach (WarehouseSearchWork work in retList)
                {
                    warehouseConvertList.Add(new WarehouseDispInfo(work.WarehouseCd, work.WarehouseNm, work.LogicalDelete));
                }
            }

            return status;
        }

        /// <summary>
        /// �q�ɃR�[�h�ϊ�����
        /// </summary>
        /// <param name="trgTblList">�ϊ��Ώۃe�[�u�����</param>
        /// <param name="cnvDataList">>�ϊ�����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="errMes">�G���[���b�Z�[�W</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���ϊ��������ɑq�ɃR�[�h�̃R�[�h�ϊ����s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public int ConvertWarehouse(TargetTableListResult trgTblList,�@IList<WarehouseConvertData> cnvDataList,
                string enterpriseCode, ref long numberOfTransactions)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �����[�g�I�u�W�F�N�g�����s����̂ɕK�v�ȃp�����[�^�����������܂��B
            object paramObj = this.DispInfoToConvertPrmWork(trgTblList, cnvDataList, enterpriseCode);

            // �����[�g�I�u�W�F�N�g�����s���A�R�[�h�̕ϊ������s���܂��B
            status = this.iWarehouseConvertDb.Convert(paramObj, ref numberOfTransactions);

            return status;
        }

        /// <summary>
        /// �R�[�h�ϊ��Ώۃe�[�u�����X�g�擾����
        /// </summary>
        /// <param name="targetTableMap">�R�[�h�ϊ��Ώۃe�[�u���̃��X�g</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���ϊ��������ɑq�ɃR�[�h�̃R�[�h�ϊ����s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        public int GetConvertTableList(IDictionary<string, TargetTableListResult> targetTableMap)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            IDictionary<string, WarehouseTargetTableList> retObjMap = new Dictionary<string, WarehouseTargetTableList>();
            Object retObj = retObjMap;

            // �����[�g�I�u�W�F�N�g�����{���A�R�[�h�ϊ��Ώۂ̃e�[�u���̃��X�g(key:�e�[�u����,value:�J�����̃��X�g)���擾���܂��B
            status = this.iWarehouseConvertDb.GetConvertTableList(ref retObj);

            // �X�e�[�^�X�������̏ꍇ�́AXML����擾�������e��ϐ��ɓ���ւ���
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                retObjMap = retObj as IDictionary<string, WarehouseTargetTableList>;
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
        /// <param name="cvnData">�ϊ��O�f�[�^</param>
        /// <returns>�ϊ���f�[�^</returns>
        /// <remarks>
        /// <br>Note       : WarehouseConvertDispInfo����WarehouseSearchParamWork�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private WarehouseSearchParamWork DispInfoToSearchPrmWork(WarehouseConvertDispInfo dispInfo)
        {
            WarehouseSearchParamWork prmWk = new WarehouseSearchParamWork();
            // ��ƃR�[�h
            prmWk.EnterPriseCode = dispInfo.EnterpriseCode;
            // �q�ɃR�[�h(�J�n)
            prmWk.WarehouseStCd = dispInfo.WarehouseCdStart;
            // �q�ɃR�[�h(�I��)
            prmWk.WarehouseEdCd = dispInfo.WarehouseCdEnd;

            return prmWk;
        }

        #endregion

        #region -- �ϊ��֘A --

        /// <summary>
        /// �f�[�^�ϊ�����
        /// </summary>
        /// <param name="trgTblList">�ϊ��e�[�u�����</param>
        /// <param name="cnvDataList">�ϊ��f�[�^�̃��X�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�ϊ���f�[�^</returns>
        /// <remarks>
        /// <br>Note       : WarehouseConvertDispInfo����WarehouseConvertPrmInfoList�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private WarehouseConvertPrmInfoList DispInfoToConvertPrmWork(TargetTableListResult trgTblList,
            IList<WarehouseConvertData> cnvDataList, string enterpriseCode)
        {
            WarehouseConvertPrmInfoList prmInfoList = new WarehouseConvertPrmInfoList();
            // ��ƃR�[�h
            prmInfoList.EnterpriseCode = enterpriseCode;
            // �R�[�h�ϊ��Ώۃe�[�u��(������)
            prmInfoList.TargetTable = trgTblList.TargetTable;
            // �R�[�h�ϊ��Ώۂ̃J�����̃��X�g
            prmInfoList.ColumnList = trgTblList.ColumnList;
            // �R�[�h�ϊ��f�[�^�̃��X�g
            prmInfoList.WarehouseConvertPrmWorkList = new List<WarehouseConvertPrmWork>(cnvDataList.Count);
            foreach (WarehouseConvertData cnvData in cnvDataList)
            {
                WarehouseConvertPrmWork prmWk = new WarehouseConvertPrmWork(); 
                // �ϊ��O�q�ɃR�[�h
                prmWk.BfWarehouseCode = cnvData.BfWarehouseCd;
                // �ϊ���q�ɃR�[�h
                prmWk.AfWarehouseCode = cnvData.AfWarehouseCd;
                prmInfoList.WarehouseConvertPrmWorkList.Add(prmWk);
            }

            return prmInfoList;
        }

        #endregion

        #region -- �e�[�u�����擾�֘A --

        /// <summary>
        /// �f�[�^�ϊ�����
        /// </summary>
        /// <param name="trgTblList">�e�[�u�����</param>
        /// <returns>�e�[�u�����</returns>
        /// <remarks>
        /// <br>Note       : WarehouseTargetTableList����TargetTableListResult�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2016/02/18</br>
        /// </remarks>
        private TargetTableListResult TargetTableListToTargetTableListResult(WarehouseTargetTableList trgTblList)
        {
            TargetTableListResult trgTblLstRslt = new TargetTableListResult();
            // �e�[�u����(������)
            trgTblLstRslt.TargetTable = trgTblList.TargetTable;
            // �e�[�u����(�_����)
            trgTblLstRslt.TargetTableName = trgTblList.TargetTableName;
            // �J������(������)�̃��X�g
            trgTblLstRslt.ColumnList = new List<string>(trgTblList.ColumnList);

            return trgTblLstRslt;
        }

        #endregion

        #endregion
    }
}
