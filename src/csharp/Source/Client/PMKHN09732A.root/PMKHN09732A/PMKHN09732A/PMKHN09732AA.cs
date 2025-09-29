//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���[���O���[�v�����ݒ�}�X�^                    //
//                      �A�N�Z�X�N���X                                  //
//                  :   PMKHN09732A.DLL                                 //
// Name Space       :   Broadleaf.Application.Controller                //
// Programmer       :   30746 ���� ��                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���[���O���[�v�����ݒ�}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30746 ���� ��</br>
    /// <br>Date       : 2013/02/18</br>
    /// <br></br>
    /// </remarks>
    public class RoleGroupAuthAcs
    {
        #region Private Member

        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        // ���[���O���[�v�����ݒ�}�X�^
        private IRoleGroupAuthDB _iRoleGroupAuthDB = null;

        #endregion

        #region Constructor

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ�}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public RoleGroupAuthAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iRoleGroupAuthDB = (IRoleGroupAuthDB)MediationRoleGroupAuthDB.GetRoleGroupAuthDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRoleGroupAuthDB = null;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iRoleGroupAuthDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        /// <summary>
        /// ���쌠���敪�ǂݍ��ݏ���
        /// </summary>
        /// <param name="roleGroupAuth">���[���O���[�v�����ݒ�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="roleGroupCode">���[���O���[�v�R�[�h</param>
        /// <param name="roleCategoryID">���[���J�e�S��ID</param>
        /// <param name="roleCategorySubID">���[���T�u�J�e�S��ID</param>
        /// <param name="roleItemID">���[���A�C�e��ID</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���쌠���敪��ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Read(out RoleGroupAuth roleGroupAuth, string enterpriseCode, Int32 roleGroupCode, Int32 roleCategoryID, Int32 roleCategorySubID, Int32 roleItemID)
        {
            try
            {
                // �L�[���̐ݒ�
                roleGroupAuth = null;

                RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();
                roleGroupAuthWork.EnterpriseCode = enterpriseCode;
                roleGroupAuthWork.RoleGroupCode = roleGroupCode;
                roleGroupAuthWork.RoleCategoryID = roleCategoryID;
                roleGroupAuthWork.RoleCategorySubID = roleCategorySubID;
                roleGroupAuthWork.RoleItemID = roleItemID;

                // ���[���O���[�v�����ݒ胏�[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)roleGroupAuthWork;

                // ���[���O���[�v�����ݒ�ǂݍ���
                int status = this._iRoleGroupAuthDB.Read(ref paraObj, 0);

                if (status == 0)
                {
                    // �ǂݍ��݌��ʂ����[���O���[�v�����ݒ胏�[�J�[�N���X�ɐݒ�
                    RoleGroupAuthWork wkRoleGroupAuthWork = (RoleGroupAuthWork)paraObj;
                    // ���[���O���[�v�����ݒ胏�[�J�[�N���X���烍�[���O���[�v�����ݒ�N���X�ɃR�s�[
                    roleGroupAuth = CopyToRoleGroupAuthFromRoleGroupAuthWork(wkRoleGroupAuthWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRoleGroupAuthDB = null;
                //�ʐM�G���[��-1��߂�
                roleGroupAuth = null;
                return -1;
            }
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�V���A���C�Y����
        /// </summary>
        /// <param name="roleGroupAuth">�V���A���C�Y�Ώۃ��[���O���[�v�����ݒ�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public void Serialize(RoleGroupAuth roleGroupAuth, string fileName)
        {
            // ���[���O���[�v�����ݒ�N���X���烍�[���O���[�v�����ݒ胏�[�J�[�N���X�Ƀ����o�R�s�[
            RoleGroupAuthWork roleGroupAuthWork = CopyToRoleGroupAuthWorkFromRoleGroupAuth(roleGroupAuth);

            // ���[���O���[�v�����ݒ胏�[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(roleGroupAuthWork, fileName);
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�List�V���A���C�Y����
        /// </summary>
        /// <param name="arrRoleGroupAuth">�V���A���C�Y�Ώۃ��[���O���[�v�����ݒ�List�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ�List���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public void ListSerialize(ArrayList arrRoleGroupAuth, string fileName)
        {
            RoleGroupAuthWork[] roleGroupAuthWorks = new RoleGroupAuthWork[arrRoleGroupAuth.Count];

            for (int i = 0; i < arrRoleGroupAuth.Count; i++)
            {
                roleGroupAuthWorks[i] = CopyToRoleGroupAuthWorkFromRoleGroupAuth((RoleGroupAuth)arrRoleGroupAuth[i]);
            }

            // ���[���O���[�v�����ݒ胏�[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(roleGroupAuthWorks, fileName);
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�N���X�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
        /// <returns>���[���O���[�v�����ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public RoleGroupAuth Deserialize(string fileName)
        {
            RoleGroupAuth roleGroupAuth = null;

            // �t�@�C������n���ă��[���O���[�v�����ݒ胏�[�N�N���X���f�V���A���C�Y����
            RoleGroupAuthWork roleGroupAuthWork = (RoleGroupAuthWork)XmlByteSerializer.Deserialize(fileName, typeof(RoleGroupAuthWork));

            // �f�V���A���C�Y���ʂ����[���O���[�v�����ݒ�N���X�փR�s�[
            if (roleGroupAuthWork != null) roleGroupAuth = CopyToRoleGroupAuthFromRoleGroupAuthWork(roleGroupAuthWork);

            return roleGroupAuth;
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�o�^�E�X�V����
        /// </summary>
        /// <param name="roleGroupAuth">���[���O���[�v�����ݒ�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Write(ref RoleGroupAuth roleGroupAuth)
        {
            RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();

            // ���[���O���[�v�����ݒ�N���X���烍�[���O���[�v�����ݒ胏�[�N�N���X�Ƀ����o�R�s�[
            roleGroupAuthWork = CopyToRoleGroupAuthWorkFromRoleGroupAuth(roleGroupAuth);

            // ���[���O���[�v�����ݒ�̓o�^�E�X�V����ݒ�
            ArrayList paraList = new ArrayList();
            paraList.Add(roleGroupAuthWork);
            object paraObj = paraList;

            int status = 0;
            try
            {
                // ���[���O���[�v�����ݒ菑������
                status = this._iRoleGroupAuthDB.Write(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    // ���[���O���[�v�����ݒ�N���X���烍�[���O���[�v�����ݒ胏�[�N�N���X�Ƀ����o�R�s�[
                    roleGroupAuth = this.CopyToRoleGroupAuthFromRoleGroupAuthWork((RoleGroupAuthWork)paraList[0]);
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iRoleGroupAuthDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�_���폜����
        /// </summary>
        /// <param name="roleGroupAuth">���[���O���[�v�����ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : ���[���O���[�v�����ݒ���̘_���폜���s���܂��B<br />
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int LogicalDelete(ref RoleGroupAuth roleGroupAuth)
        {
            int status = 0;

            try
            {
                RoleGroupAuthWork roleGroupAuthWork = CopyToRoleGroupAuthWorkFromRoleGroupAuth(roleGroupAuth);

                ArrayList paraList = new ArrayList();
                paraList.Add(roleGroupAuthWork);
                object paraObj = paraList;

                // ���[���O���[�v�����ݒ�N���X�_���폜
                status = this._iRoleGroupAuthDB.LogicalDelete(ref paraObj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraObj;
                    // �N���X�������o�R�s�[
                    roleGroupAuth = CopyToRoleGroupAuthFromRoleGroupAuthWork((RoleGroupAuthWork)paraList[0]);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRoleGroupAuthDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ蕨���폜����
        /// </summary>
        /// <param name="roleGroupAuth">���[���O���[�v�����ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : ���[���O���[�v�����ݒ���̕����폜���s���܂��B<br />
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Delete(RoleGroupAuth roleGroupAuth)
        {
            try
            {
                RoleGroupAuthWork roleGroupAuthWork = CopyToRoleGroupAuthWorkFromRoleGroupAuth(roleGroupAuth);

                ArrayList paraList = new ArrayList();
                paraList.Add(roleGroupAuthWork);
                object paraObj = paraList;

                // ���[���O���[�v�����ݒ蕨���폜
                int status = this._iRoleGroupAuthDB.Delete(paraObj);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRoleGroupAuthDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�_���폜��������
        /// </summary>
        /// <param name="roleGroupAuth">���[���O���[�v�����ݒ薼�̃I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// Note       : ���[���O���[�v�����ݒ���̕������s���܂��B<br />
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int Revival(ref RoleGroupAuth roleGroupAuth)
        {
            try
            {
                RoleGroupAuthWork roleGroupAuthWork = CopyToRoleGroupAuthWorkFromRoleGroupAuth(roleGroupAuth);
                ArrayList paraList = new ArrayList();
                paraList.Add(roleGroupAuthWork);
                object paraobj = paraList;

                // ��������
                int status = this._iRoleGroupAuthDB.RevivalLogicalDelete(ref paraobj);

                if (status == 0)
                {
                    paraList = (ArrayList)paraobj;
                    // �N���X�������o�R�s�[
                    roleGroupAuth = CopyToRoleGroupAuthFromRoleGroupAuthWork((RoleGroupAuthWork)paraList[0]);
                }
                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRoleGroupAuthDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="roleGroupCode">���[���O���[�v�R�[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer  : 30746 ���� ��</br>
        /// <br>Date        : 2013/02/18</br>
        /// </remarks>
        public int Search(ref DataSet ds, int roleGroupCode, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // ���[���O���[�v�����ݒ�}�X�^�T�[�`
            status = SearchAll(roleGroupCode, out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList wkList = retList.Clone() as ArrayList;
            SortedList wkSort = new SortedList();
            ArrayList ar = new ArrayList();


            foreach (RoleGroupAuth wkRoleGroupAuth in wkList)
            {
                if (wkRoleGroupAuth.LogicalDeleteCode == 0)
                {
                    if (roleGroupCode == 0)
                    {
                        wkSort.Add(wkRoleGroupAuth.Clone().RoleGroupCode, wkRoleGroupAuth.Clone());
                    }
                    else if (roleGroupCode.Equals(wkRoleGroupAuth.RoleGroupCode))
                    {
                        wkSort.Add(wkRoleGroupAuth.Clone().RoleGroupCode, wkRoleGroupAuth.Clone());

                    }
                }
            }
            ar.AddRange(wkSort.Values);

            RoleGroupAuth[] roleGroupAuths = new RoleGroupAuth[ar.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < ar.Count; i++)
            {
                roleGroupAuths[i] = (RoleGroupAuth)ar[i];
            }

            byte[] retbyte = XmlByteSerializer.Serialize(roleGroupAuths);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

        /// <summary>
        /// ���[���O���[�v�R�[�h�w�� ���[���O���[�v�������������i�_���폜�܂ށj
        /// </summary>
        /// <param name="roleGroupCode">���[���O���[�v�R�[�h</param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>     
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        public int SearchAll(Int32 roleGroupCode, out ArrayList retList, string enterpriseCode)
        {
            bool nextData;
            int retTotalCnt;
            int status = 0;
            ArrayList list = new ArrayList();

            retList = new ArrayList();
            retList.Clear();
            retTotalCnt = 0;

            // ���[�U�[
            status = SearchRoleGroupAuthProc(roleGroupCode, ref list, out retTotalCnt, out nextData, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, 0);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    break;
                default:

                    return status;
            }

            // �������ʌ�����0���ȊO�ł���΃X�e�[�^�X��0(����)�ɐݒ�
            if (retTotalCnt != 0)
            {
                status = 0;
            }

            retList = list;

            return status;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[���O���[�v�����ݒ胏�[�N�N���X�˃��[���O���[�v�����ݒ�N���X�j
        /// </summary>
        /// <param name="roleGroupAuthWork">���[���O���[�v�����ݒ胏�[�N�N���X</param>
        /// <returns>���[���O���[�v�����ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ胏�[�N�N���X���烍�[���O���[�v�����ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private RoleGroupAuth CopyToRoleGroupAuthFromRoleGroupAuthWork(RoleGroupAuthWork roleGroupAuthWork)
        {
            RoleGroupAuth roleGroupAuth = new RoleGroupAuth();

            roleGroupAuth.CreateDateTime = roleGroupAuthWork.CreateDateTime;
            roleGroupAuth.UpdateDateTime = roleGroupAuthWork.UpdateDateTime;
            roleGroupAuth.EnterpriseCode = roleGroupAuthWork.EnterpriseCode;
            roleGroupAuth.FileHeaderGuid = roleGroupAuthWork.FileHeaderGuid;
            roleGroupAuth.UpdEmployeeCode = roleGroupAuthWork.UpdEmployeeCode;
            roleGroupAuth.UpdAssemblyId1 = roleGroupAuthWork.UpdAssemblyId1;
            roleGroupAuth.UpdAssemblyId2 = roleGroupAuthWork.UpdAssemblyId2;
            roleGroupAuth.LogicalDeleteCode = roleGroupAuthWork.LogicalDeleteCode;

            roleGroupAuth.RoleGroupCode = roleGroupAuthWork.RoleGroupCode;          // ���[���O���[�v�R�[�h
            roleGroupAuth.RoleCategoryID = roleGroupAuthWork.RoleCategoryID;        // ���[���J�e�S��ID
            roleGroupAuth.RoleCategorySubID = roleGroupAuthWork.RoleCategorySubID;  // ���[���T�u�J�e�S��ID
            roleGroupAuth.RoleItemID = roleGroupAuthWork.RoleItemID;                // ���[���A�C�e��ID
            roleGroupAuth.RoleLimitDiv = roleGroupAuthWork.RoleLimitDiv;            // ���[�������敪

            return roleGroupAuth;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[���O���[�v�����N���X�˃��[���O���[�v�������[�N�N���X�j
        /// </summary>
        /// <param name="roleGroupAuth">���[���O���[�v�������[�N�N���X</param>
        /// <returns>���[���O���[�v�����N���X</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����N���X���烍�[���O���[�v�������[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private RoleGroupAuthWork CopyToRoleGroupAuthWorkFromRoleGroupAuth(RoleGroupAuth roleGroupAuth)
        {
            RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();

            roleGroupAuthWork.CreateDateTime = roleGroupAuth.CreateDateTime;
            roleGroupAuthWork.UpdateDateTime = roleGroupAuth.UpdateDateTime;
            roleGroupAuthWork.EnterpriseCode = roleGroupAuth.EnterpriseCode;
            roleGroupAuthWork.FileHeaderGuid = roleGroupAuth.FileHeaderGuid;
            roleGroupAuthWork.UpdEmployeeCode = roleGroupAuth.UpdEmployeeCode;
            roleGroupAuthWork.UpdAssemblyId1 = roleGroupAuth.UpdAssemblyId1;
            roleGroupAuthWork.UpdAssemblyId2 = roleGroupAuth.UpdAssemblyId2;
            roleGroupAuthWork.LogicalDeleteCode = roleGroupAuth.LogicalDeleteCode;

            roleGroupAuthWork.RoleGroupCode = roleGroupAuth.RoleGroupCode;          // ���[���O���[�v�R�[�h
            roleGroupAuthWork.RoleCategoryID = roleGroupAuth.RoleCategoryID;        // ���[���J�e�S��ID
            roleGroupAuthWork.RoleCategorySubID = roleGroupAuth.RoleCategorySubID;  // ���[���T�u�J�e�S��ID
            roleGroupAuthWork.RoleItemID = roleGroupAuth.RoleItemID;                // ���[���A�C�e��ID
            roleGroupAuthWork.RoleLimitDiv = roleGroupAuth.RoleLimitDiv;            // ���[�������敪

            return roleGroupAuthWork;
        }

        /// <summary>
        /// ���[���O���[�v������������
        /// </summary>
        /// <param name="roleGroupCode">���[���O���[�v�R�[�h</param>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v�����ݒ�̌����������s���܂��B</br>
        /// <br>Programmer : 30746 ���� ��</br>
        /// <br>Date       : 2013/02/18</br>
        /// </remarks>
        private int SearchRoleGroupAuthProc(Int32 roleGroupCode, ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt)
        {
            RoleGroupAuthWork roleGroupAuthWork = new RoleGroupAuthWork();

            // ���f�[�^�L��������
            nextData = false;
            // �Ǎ��Ώۃf�[�^������0�ŏ�����
            retTotalCnt = 0;

            int status = 0;

            ArrayList workList = new ArrayList();
            object retObj = workList;

            if (retList.Count == 0)
            {
                // �L�[�w��
                roleGroupAuthWork.RoleGroupCode = roleGroupCode;
                roleGroupAuthWork.EnterpriseCode = enterpriseCode;

                // ���[���O���[�v�����ݒ胏�[�J�[�N���X���I�u�W�F�N�g�ɐݒ�
                object paraObj = (object)roleGroupAuthWork;

                // ���[���O���[�v�R�[�h�w��S���Ǎ�
                status = this._iRoleGroupAuthDB.Search(ref retObj, paraObj, 0, logicalMode);

                switch (status)
                {
                    case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                        workList = retObj as ArrayList;
                        if (workList != null)
                        {
                            foreach (RoleGroupAuthWork wkRoleGroupAuthWork in workList)
                            {
                                // �����[�g�p�����[�^�f�[�^ �� �f�[�^�N���X
                                RoleGroupAuth wkRoleGroupAuth = CopyToRoleGroupAuthFromRoleGroupAuthWork(wkRoleGroupAuthWork);
                                // �f�[�^�N���X��Ǎ����ʂփR�s�[
                                retList.Add(wkRoleGroupAuth);
                            }
                        }
                        break;
                    case (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND:
                    case (int)ConstantManagement.DB_Status.ctDB_EOF:
                        break;
                    default:
                        return status;
                }
            }

            // �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
            if (readCnt == 0) retTotalCnt = retList.Count;

            return status;
        }

        #endregion

    }
}