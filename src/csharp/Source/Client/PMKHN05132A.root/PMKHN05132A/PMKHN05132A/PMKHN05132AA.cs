//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : PM.NS�����c�[���@���_�R�[�h�ϊ��A�N�Z�X�N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11200041-00 �쐬�S�� : �{��
// �C �� ��  2017/12/15  �C�����e : �V�K�쐬
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
    /// PM.NS�����c�[���@���_�R�[�h�ϊ��A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : PM.NS�����c�[���̋��_�R�[�h�ϊ��A�N�Z�X�N���X�ł��B</br>
    /// <br>Programmer : 30365 �{��</br>
    /// <br>Date       : 2017/12/15</br>
    /// </remarks>
    public class SectionConvertAcs
    {
        #region -- Member --

        /// <summary>���_�R�[�h�ϊ������[�g�I�u�W�F�N�g</summary>
        private ISectionConvertDB iSectionConvertDb;

        #endregion

        #region -- Constructor --

        /// <summary>
        /// PM.NS�����c�[���@���_�R�[�h�ϊ��A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : PM.NS�����c�[���A���_�R�[�h�ϊ��A�N�Z�X�N���X�̏����������s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public SectionConvertAcs()
        {
            // SectionConvertDB�̏��������s���܂�
            this.iSectionConvertDb = (ISectionConvertDB)MediationSectionConvertDB.GetSectionConvertDB();
        }

        #endregion

        #region -- Public Method --

        /// <summary>
        /// ���_��������
        /// </summary>
        /// <param name="prmWk">��������</param>
        /// <param name="sectionConvertList">��������</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵�����o�������狒�_�̏����擾���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public int SearchSection(SectionConvertDispInfo dispInfo, List<SectionDispInfo> sectionConvertList)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �����[�g�I�u�W�F�N�g�����s����̂ɕK�v�ȃp�����[�^�����������܂��B
            object paramObj = this.DispInfoToSearchPrmWork(dispInfo);
            ArrayList retList = new ArrayList();
            object retObj = retList;

            // �����[�g�I�u�W�F�N�g�����s���ADB����f�[�^���������܂��B
            status = this.iSectionConvertDb.Search(paramObj, ref retObj);
            if (status == 0)
            {
                // �f�[�^���擾�ł����ꍇ��sectionConvertList�Ɋi�[���܂��B
                retList = retObj as ArrayList;
                foreach (SectionSearchWork work in retList)
                {
                    sectionConvertList.Add(new SectionDispInfo(work.SectionCd, work.SectionNm, work.LogicalDelete));
                }
            }

            return status;
        }

        /// <summary>
        /// ���_�R�[�h�ϊ�����
        /// </summary>
        /// <param name="trgTblList">�ϊ��Ώۃe�[�u�����</param>
        /// <param name="cnvDataList">>�ϊ�����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="errMes">�G���[���b�Z�[�W</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���ϊ��������ɋ��_�R�[�h�̃R�[�h�ϊ����s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public int ConvertSection(TargetTableListResult trgTblList,�@IList<SectionConvertData> cnvDataList,
                string enterpriseCode, ref long numberOfTransactions)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            // �����[�g�I�u�W�F�N�g�����s����̂ɕK�v�ȃp�����[�^�����������܂��B
            object paramObj = this.DispInfoToConvertPrmWork(trgTblList, cnvDataList, enterpriseCode);

            // �����[�g�I�u�W�F�N�g�����s���A�R�[�h�̕ϊ������s���܂��B
            status = this.iSectionConvertDb.Convert(paramObj, ref numberOfTransactions);

            return status;
        }

        /// <summary>
        /// �R�[�h�ϊ��Ώۃe�[�u�����X�g�擾����
        /// </summary>
        /// <param name="targetTableMap">�R�[�h�ϊ��Ώۃe�[�u���̃��X�g</param>
        /// <returns>�����X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �w�肵���ϊ��������ɋ��_�R�[�h�̃R�[�h�ϊ����s���܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        public int GetConvertTableList(IDictionary<string, TargetTableListResult> targetTableMap)
        {
            // �X�e�[�^�X�̏�����
            int status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            IDictionary<string, SectionTargetTableList> retObjMap = new Dictionary<string, SectionTargetTableList>();
            Object retObj = retObjMap;

            // �����[�g�I�u�W�F�N�g�����{���A�R�[�h�ϊ��Ώۂ̃e�[�u���̃��X�g(key:�e�[�u����,value:�J�����̃��X�g)���擾���܂��B
            status = this.iSectionConvertDb.GetConvertTableList(ref retObj);

            // �X�e�[�^�X�������̏ꍇ�́AXML����擾�������e��ϐ��ɓ���ւ���
            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                retObjMap = retObj as IDictionary<string, SectionTargetTableList>;
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
        /// <br>Note       : SectionConvertDispInfo����SectionSearchParamWork�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        private SectionSearchParamWork DispInfoToSearchPrmWork(SectionConvertDispInfo dispInfo)
        {
            SectionSearchParamWork prmWk = new SectionSearchParamWork();
            // ��ƃR�[�h
            prmWk.EnterPriseCode = dispInfo.EnterpriseCode;
            // ���_�R�[�h(�J�n)
            prmWk.SectionStCd = dispInfo.SectionCdStart;
            // ���_�R�[�h(�I��)
            prmWk.SectionEdCd = dispInfo.SectionCdEnd;

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
        /// <br>Note       : SectionConvertDispInfo����SectionConvertPrmInfoList�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        private SectionConvertPrmInfoList DispInfoToConvertPrmWork(TargetTableListResult trgTblList,
            IList<SectionConvertData> cnvDataList, string enterpriseCode)
        {
            SectionConvertPrmInfoList prmInfoList = new SectionConvertPrmInfoList();
            // ��ƃR�[�h
            prmInfoList.EnterpriseCode = enterpriseCode;
            // �R�[�h�ϊ��Ώۃe�[�u��(������)
            prmInfoList.TargetTable = trgTblList.TargetTable;
            // �R�[�h�ϊ��Ώۂ̃J�����̃��X�g
            prmInfoList.ColumnList = trgTblList.ColumnList;
            // �R�[�h�ϊ��f�[�^�̃��X�g
            prmInfoList.SectionConvertPrmWorkList = new List<SectionConvertPrmWork>(cnvDataList.Count);
            foreach (SectionConvertData cnvData in cnvDataList)
            {
                SectionConvertPrmWork prmWk = new SectionConvertPrmWork(); 
                // �ϊ��O���_�R�[�h
                prmWk.BfSectionCode = cnvData.BfSectionCd;
                // �ϊ��㋒�_�R�[�h
                prmWk.AfSectionCode = cnvData.AfSectionCd;
                prmInfoList.SectionConvertPrmWorkList.Add(prmWk);
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
        /// <br>Note       : SectionTargetTableList����TargetTableListResult�Ƀf�[�^��ϊ����܂��B</br>
        /// <br>Programmer : 30365 �{��</br>
        /// <br>Date       : 2017/12/15</br>
        /// </remarks>
        private TargetTableListResult TargetTableListToTargetTableListResult(SectionTargetTableList trgTblList)
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
