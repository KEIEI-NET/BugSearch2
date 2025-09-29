//**********************************************************************
// System           :   PM.NS
// Sub System       :
// Program name     :   �ȒP�⍇���ڑ����DB�����[�g�I�u�W�F�N�g
//                  :   PMSCM00205R.DLL
// Name Space       :   Broadleaf.Application.Remoting
// Programmer       :   21024�@���X�� ��
// Date             :   2010/03/25
//----------------------------------------------------------------------
// Update Note      :
//----------------------------------------------------------------------
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//**********************************************************************

using System;
using System.Collections;
using System.Data;
using System.Text;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Data;
using Broadleaf.Library.Data.SqlTypes;
using Broadleaf.Library.Data.SqlClient;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;

namespace Broadleaf.Application.Remoting
{
    /// <summary>
    /// �ȒP�⍇���ڑ���񃊃��[�g�I�u�W�F�N�g
    /// </summary>
    /// <remarks>
    /// <br>Note       : �ȒP�⍇���ڑ����̎��f�[�^������s���N���X�ł��B</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/03/25</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class SimplInqCnectInfoDB : RemoteDB,ISimplInqCnectInfoDB
    {
        /// <summary>
        /// �ȒP�⍇���ڑ����DB�����[�g�I�u�W�F�N�g�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���ɂȂ�</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        public SimplInqCnectInfoDB() 
        {

        }

        # region [Delete]
        /// <summary>
        /// �ȒP�⍇���ڑ������폜���܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList">�폜����ȒP�⍇���ڑ��������܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �ȒP�⍇���ڑ����̃L�[�l����v����ȒP�⍇���ڑ������폜���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        public int Delete(string enterpriseCode, object simplInqCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            // �p�����[�^�̃L���X�g
            ArrayList paraList = simplInqCnectInfoList as ArrayList;

            status = this.DeleteProc(enterpriseCode, paraList);

            return status;
        }

        /// <summary>
        /// �ȒP�⍇���ڑ������폜���܂�
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList">�ȒP�⍇���ڑ��������i�[���� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : simplInqCnectInfoList �Ɋi�[����Ă���ȒP�⍇���ڑ������𕨗��폜���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        private int DeleteProc(string enterpriseCode, ArrayList simplInqCnectInfoList)
        {
            List<SimplInqCnectInfo> delList = new List<SimplInqCnectInfo>();

            foreach (SimplInqCnectInfoWork work in simplInqCnectInfoList)
            {
                delList.Add(CopyToSimplInqCnectInfoFromSimplInqCnectInfoWork(work));
            }

            return SimplInqCnectInfoController.DeleteConnectionInfo(enterpriseCode, delList);
        }

        # endregion

        # region [Search]
        /// <summary>
        /// �ȒP�⍇���ڑ������̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList">��������</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ώۊ�Ƃ̊ȒP�⍇���ڑ����S�Ď擾���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        public int Search(string enterpriseCode, out object simplInqCnectInfoList)
        {
            ArrayList retList;
            int status = SearchProc(enterpriseCode, out retList);

            simplInqCnectInfoList = (object)retList;

            return status;
        }

        /// <summary>
        /// �ȒP�⍇���ڑ������̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList">�ȒP�⍇���ڑ��������i�[���� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : �Ώۊ�Ƃ̊ȒP�⍇���ڑ�����S�� ArrayList �Ŏ擾���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        private int SearchProc(string enterpriseCode, out ArrayList simplInqCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            simplInqCnectInfoList = new ArrayList();
            List<SimplInqCnectInfo> infoList = SimplInqCnectInfoController.GetConnectionInfolist(enterpriseCode);

            if (infoList != null && infoList.Count > 0)
            {
                foreach (SimplInqCnectInfo info in infoList)
                {
                    simplInqCnectInfoList.Add(CopyToSimplInqCnectInfoWorkFromSimplInqCnectInfo(info));
                }
            }

            if (simplInqCnectInfoList.Count > 0)
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            else
                status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            return status;
        }
        # endregion

        # region [Write]
        /// <summary>
        /// �ȒP�⍇���ڑ�������ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="simplInqCnectInfoList">�ǉ��E�X�V����ȒP�⍇���ڑ��������܂� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : simplInqCnectInfoList �Ɋi�[����Ă���ȒP�⍇���ڑ�������ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        public int Write(string enterpriseCode, object simplInqCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            ArrayList paraList = null;
            if (simplInqCnectInfoList is SimplInqCnectInfoWork)
            {
                paraList = new ArrayList();
                paraList.Add((SimplInqCnectInfoWork)simplInqCnectInfoList);
            }
            else if (simplInqCnectInfoList is ArrayList)
            {
                paraList = simplInqCnectInfoList as ArrayList;
            }

            return WriteProc(enterpriseCode, paraList);
        }

        /// <summary>
        /// �ȒP�⍇���ڑ�������ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="simplInqCnectInfoList">�ǉ�����ȒP�⍇���ڑ��������i�[���� ArrayList</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : simplInqCnectInfoList �Ɋi�[����Ă���ȒP�⍇���ڑ�������ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        private int WriteProc(string enterpriseCode,ArrayList simplInqCnectInfoList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            if (simplInqCnectInfoList == null || simplInqCnectInfoList.Count == 0) return status;

            List<SimplInqCnectInfo> addList = new List<SimplInqCnectInfo>();

            foreach (SimplInqCnectInfoWork work in simplInqCnectInfoList)
            {
                addList.Add(CopyToSimplInqCnectInfoFromSimplInqCnectInfoWork(work));
            }

            if (addList.Count > 0)
            {
                status = SimplInqCnectInfoController.AddConnectionInfo(enterpriseCode, addList);
            }

            return status;
        }
        # endregion

        # region [�N���X�i�[����]

        /// <summary>
        /// �N���X�i�[�����iSimplInqCnectInfo��SimplInqCnectInfoWork)
        /// </summary>
        /// <param name="simplInqCnectInfo">CmtCnectInfo�I�u�W�F�N�g</param>
        /// <returns>CMTCnectInfoWork�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private SimplInqCnectInfoWork CopyToSimplInqCnectInfoWorkFromSimplInqCnectInfo(SimplInqCnectInfo simplInqCnectInfo)
        {
            SimplInqCnectInfoWork work = new SimplInqCnectInfoWork();

            work.CashRegisterNo = simplInqCnectInfo.CashRegisterNo;
            work.CustomerCode = simplInqCnectInfo.CustomerCode;

            return work;
        }

        /// <summary>
        /// �N���X�i�[�����iSimplInqCnectInfo��SimplInqCnectInfoWork)
        /// </summary>
        /// <param name="simplInqCnectInfoWork">CMTCnectInfoWork�I�u�W�F�N�g</param>
        /// <returns>CmtCnectInfo�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Programmer : 21024�@���X�� ��</br>
        /// <br>Date       : 2010/03/25</br>
        /// </remarks>
        private SimplInqCnectInfo CopyToSimplInqCnectInfoFromSimplInqCnectInfoWork(SimplInqCnectInfoWork simplInqCnectInfoWork)
        {
            SimplInqCnectInfo info = new SimplInqCnectInfo();

            info.CashRegisterNo = simplInqCnectInfoWork.CashRegisterNo;
            info.CustomerCode = simplInqCnectInfoWork.CustomerCode;

            return info;
        }

        # endregion
    }
}
