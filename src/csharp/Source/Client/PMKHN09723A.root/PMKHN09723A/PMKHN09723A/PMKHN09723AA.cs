//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���[���O���[�v�����ݒ�}�X�^                    //
//                      �A�N�Z�X�N���X                                  //
//                  :   PMKHN09723A.DLL                                 //
// Name Space       :   Broadleaf.Application.Controller                //
// Programmer       :   30746 ���� ��                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using System.Data;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���[���O���[�v���̐ݒ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���[���O���[�v���̐ݒ�̃A�N�Z�X������s���܂��B</br>
    /// <br></br>
    /// </remarks>
    public class RoleGroupNameStAcs : IGeneralGuideData
    {
        #region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private IRoleGroupNameStDB _iRoleGroupNameStDB = null;

        #endregion

        #region -- �R���X�g���N�^ --
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
        static RoleGroupNameStAcs()
        {
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
        public RoleGroupNameStAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iRoleGroupNameStDB = (IRoleGroupNameStDB)MediationRoleGroupNameStDB.GetRoleGroupNameStDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iRoleGroupNameStDB = null;
            }
        }
        #endregion

        #region -- �I�����C�����[�h�擾���� --
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h�̎擾���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iRoleGroupNameStDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        #endregion

        #region -- �ǂݍ��ݏ��� --
        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="roleGroupNameSt">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="roleGroupCode">���[���O���[�v�R�[�h</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int Read(out RoleGroupNameSt roleGroupNameSt, string enterpriseCode, int roleGroupCode)
        {
            return ReadProc(out roleGroupNameSt, enterpriseCode, roleGroupCode);
        }

        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="roleGroupNameSt">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="roleGroupCode">���[���O���[�v�R�[�h</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out RoleGroupNameSt roleGroupNameSt, string enterpriseCode, int roleGroupCode)
        {
            int status = 0;

            roleGroupNameSt = null;

            try
            {
                RoleGroupNameStWork roleGroupNameStWork = new RoleGroupNameStWork();
                roleGroupNameStWork.EnterpriseCode = enterpriseCode;
                roleGroupNameStWork.RoleGroupCode = roleGroupCode;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(roleGroupNameStWork);

                status = this._iRoleGroupNameStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�̓ǂݍ���
                    roleGroupNameStWork = (RoleGroupNameStWork)XmlByteSerializer.Deserialize(parabyte, typeof(RoleGroupNameStWork));
                    // ���[�N��UI�f�[�^�N���X
                    roleGroupNameSt = CopyToRoleGroupNameStFromRoleGroupNameStWork(roleGroupNameStWork);
                }

                return status;
            }
            catch (Exception)
            {
                roleGroupNameSt = null;
                // �I�t���C������null���Z�b�g
                this._iRoleGroupNameStDB = null;
                // �ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �o�^��X�V���� --
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="roleGroupNameSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref RoleGroupNameSt roleGroupNameSt)
        {
            int status = 0;

            // UI�f�[�^�N���X�����[�N
            RoleGroupNameStWork roleGroupNameStWork = CopyToRoleGroupNameStWorkFromRoleGroupNameSt(roleGroupNameSt);

            object obj = roleGroupNameStWork;

            try
            {
                // �������ݏ���
                status = this._iRoleGroupNameStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (obj is ArrayList)
                    {
                        roleGroupNameStWork = (RoleGroupNameStWork)((ArrayList)obj)[0];
                        // ���[�N��UI�f�[�^�N���X
                        roleGroupNameSt = CopyToRoleGroupNameStFromRoleGroupNameStWork(roleGroupNameStWork);
                    }
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iRoleGroupNameStDB = null;
                // �ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
        }
        #endregion

        #region -- �폜���� --
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="roleGroupNameSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v���̐ݒ�̘_���폜���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref RoleGroupNameSt roleGroupNameSt)
        {
            int status = 0;

            // UI�f�[�^�N���X�����[�N
            RoleGroupNameStWork roleGroupNameStWork = CopyToRoleGroupNameStWorkFromRoleGroupNameSt(roleGroupNameSt);

            object obj = roleGroupNameStWork;

            try
            {
                // �_���폜
                status = this._iRoleGroupNameStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    roleGroupNameStWork = (RoleGroupNameStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    roleGroupNameSt = CopyToRoleGroupNameStFromRoleGroupNameStWork(roleGroupNameStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRoleGroupNameStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="roleGroupNameSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v���̐ݒ�̕����폜���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Delete(RoleGroupNameSt roleGroupNameSt)
        {
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                RoleGroupNameStWork roleGroupNameStWork = CopyToRoleGroupNameStWorkFromRoleGroupNameSt(roleGroupNameSt);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(roleGroupNameStWork);

                // �����폜
                status = this._iRoleGroupNameStDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRoleGroupNameStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �������� --
        /// <summary>
        /// ���[���O���[�v���̐ݒ蕜������
        /// </summary>
        /// <param name="roleGroupNameSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v���̐ݒ�̕������s���܂�</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref RoleGroupNameSt roleGroupNameSt)
        {
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                RoleGroupNameStWork roleGroupNameStWork = CopyToRoleGroupNameStWorkFromRoleGroupNameSt(roleGroupNameSt);

                object obj = roleGroupNameStWork;

                // ��������
                status = this._iRoleGroupNameStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    roleGroupNameStWork = (RoleGroupNameStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    roleGroupNameSt = CopyToRoleGroupNameStFromRoleGroupNameStWork(roleGroupNameStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iRoleGroupNameStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �������� --
        /// <summary>
        /// ���[���O���[�v���̐ݒ茟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v���̐ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode);
        }

        /// <summary>
        /// ���[���O���[�v���̐ݒ茟������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���[���O���[�v���̐ݒ�̌����������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode)
        {
            int status = 0;

            RoleGroupNameStWork roleGroupNameStWork = new RoleGroupNameStWork();
            roleGroupNameStWork.EnterpriseCode = enterpriseCode;

            retList = new ArrayList();

            object paraobj = roleGroupNameStWork;
            object retobj = null;

            // ���[���O���[�v���̐ݒ�̑S����
            status = this._iRoleGroupNameStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (RoleGroupNameStWork wkRoleGroupNameStWork in workList)
                {
                    // �S���ǉ�
                    retList.Add(CopyToRoleGroupNameStFromRoleGroupNameStWork(wkRoleGroupNameStWork));
                }
            }

            return status;
        }

        /// <summary>
        /// �}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Search(ref DataSet ds, string enterpriseCode)
        {
            return Search2(ref ds, enterpriseCode);
        }

        /// <summary>
        /// �}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Search2(ref DataSet ds, string enterpriseCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // �}�X�^�T�[�`
            status = SearchProc(out retList, enterpriseCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList workList = retList.Clone() as ArrayList;
            SortedList workSort = new SortedList();

            // --- [�S��] --- //
            // ���̂܂ܑS���Ԃ�
            foreach (RoleGroupNameSt wkRoleGroupNameSt in workList)
            {
                if (wkRoleGroupNameSt.LogicalDeleteCode == 0)
                {
                    workSort.Add(wkRoleGroupNameSt.RoleGroupCode, wkRoleGroupNameSt);
                }
            }

            RoleGroupNameSt[] roleGroupNameSt = new RoleGroupNameSt[workSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < workSort.Count; i++)
            {
                roleGroupNameSt[i] = (RoleGroupNameSt)workSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(roleGroupNameSt);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }
        #endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[�N�N���X��UI�f�[�^�N���X�j
        /// </summary>
        /// <param name="roleGroupNameStWork">���[�N�N���X</param>
        /// <returns>UI�f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���[�N�N���X����UI�f�[�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private RoleGroupNameSt CopyToRoleGroupNameStFromRoleGroupNameStWork(RoleGroupNameStWork roleGroupNameStWork)
        {
            RoleGroupNameSt roleGroupNameSt = new RoleGroupNameSt();

            roleGroupNameSt.CreateDateTime = roleGroupNameStWork.CreateDateTime;
            roleGroupNameSt.UpdateDateTime = roleGroupNameStWork.UpdateDateTime;
            roleGroupNameSt.EnterpriseCode = roleGroupNameStWork.EnterpriseCode;
            roleGroupNameSt.FileHeaderGuid = roleGroupNameStWork.FileHeaderGuid;
            roleGroupNameSt.UpdEmployeeCode = roleGroupNameStWork.UpdEmployeeCode;
            roleGroupNameSt.UpdAssemblyId1 = roleGroupNameStWork.UpdAssemblyId1;
            roleGroupNameSt.UpdAssemblyId2 = roleGroupNameStWork.UpdAssemblyId2;
            roleGroupNameSt.LogicalDeleteCode = roleGroupNameStWork.LogicalDeleteCode;

            roleGroupNameSt.RoleGroupCode = roleGroupNameStWork.RoleGroupCode;                  // ���[���O���[�v�R�[�h
            roleGroupNameSt.RoleGroupName = roleGroupNameStWork.RoleGroupName;                  // ���[���O���[�v����

            return roleGroupNameSt;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUI�f�[�^�N���X�˃��[�N�N���X�j
        /// </summary>
        /// <param name="roleGroupNameSt">UI�f�[�^�N���X</param>
        /// <returns>���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : UI�f�[�^�N���X���烏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private RoleGroupNameStWork CopyToRoleGroupNameStWorkFromRoleGroupNameSt(RoleGroupNameSt roleGroupNameSt)
        {
            RoleGroupNameStWork roleGroupNameStWork = new RoleGroupNameStWork();

            roleGroupNameStWork.CreateDateTime = roleGroupNameSt.CreateDateTime;
            roleGroupNameStWork.UpdateDateTime = roleGroupNameSt.UpdateDateTime;
            roleGroupNameStWork.EnterpriseCode = roleGroupNameSt.EnterpriseCode;
            roleGroupNameStWork.FileHeaderGuid = roleGroupNameSt.FileHeaderGuid;
            roleGroupNameStWork.UpdEmployeeCode = roleGroupNameSt.UpdEmployeeCode;
            roleGroupNameStWork.UpdAssemblyId1 = roleGroupNameSt.UpdAssemblyId1;
            roleGroupNameStWork.UpdAssemblyId2 = roleGroupNameSt.UpdAssemblyId2;
            roleGroupNameStWork.LogicalDeleteCode = roleGroupNameSt.LogicalDeleteCode;

            roleGroupNameStWork.RoleGroupCode = roleGroupNameSt.RoleGroupCode;                  // ���[���O���[�v�R�[�h
            roleGroupNameStWork.RoleGroupName = roleGroupNameSt.RoleGroupName;                  // ���[���O���[�v����

            return roleGroupNameStWork;
        }
        #endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note        : �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";

            // ��ƃR�[�h�ݒ�L��
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                enterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // ��ƃR�[�h�ݒ薳��
            else
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }

            // ���[���O���[�v���̐ݒ�}�X�^�̓Ǎ�
            status = Search(ref guideList, enterpriseCode);

            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }

            return status;
        }

        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="roleGroupNameSt">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note        : ���[���O���[�v���̐ݒ�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out RoleGroupNameSt roleGroupNameSt)
        {
            return ExecuteGuid2(enterpriseCode, out roleGroupNameSt);
        }

        /// <summary>
        /// ���[���O���[�v���̐ݒ�}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="roleGroupNameSt">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note        : ���[���O���[�v���̐ݒ�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid2(string enterpriseCode, out RoleGroupNameSt roleGroupNameSt)
        {
            int status = -1;
            roleGroupNameSt = new RoleGroupNameSt();

            TableGuideParent tableGuideParent = new TableGuideParent("ROLEGROUPNAMESTGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode = retObj["RoleGroupCode"].ToString();
                roleGroupNameSt.RoleGroupCode = int.Parse(strCode);
                roleGroupNameSt.RoleGroupName = retObj["RoleGroupName"].ToString();
                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }
        #endregion
    }
}