//****************************************************************************//
// �V�X�e��         : .NS�V���[�Y
// �v���O��������   : �]�ƈ����[���ݒ�}�X�^
// �v���O�����T�v   : �]�ƈ����[���ݒ�}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30747 �O�ˁ@�L��
// �� �� ��  2013/02/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

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
    /// �]�ƈ����[���ݒ�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �]�ƈ����[���ݒ�̃A�N�Z�X������s���܂��B</br>
    /// <br></br>
    /// </remarks>
    public class EmployeeRoleStAcs : IGeneralGuideData
    {
        #region -- �����[�g�I�u�W�F�N�g�i�[�o�b�t�@ --
        /// <summary>
        /// �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        /// </summary>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private IEmployeeRoleStDB _iEmployeeRoleStDB = null;

        #endregion

        #region -- �R���X�g���N�^ --
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
        static EmployeeRoleStAcs()
        {
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �V�����C���X�^���X�����������܂��B</br>
        /// <br></br>
        /// </remarks>
        public EmployeeRoleStAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iEmployeeRoleStDB = (IEmployeeRoleStDB)MediationEmployeeRoleStDB.GetEmployeeRoleStDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iEmployeeRoleStDB = null;
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
            if (this._iEmployeeRoleStDB == null)
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
        /// <param name="employeeRoleSt">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="roleGroupCode">���[���O���[�v�R�[�h</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        public int Read(out EmployeeRoleSt employeeRoleSt, string enterpriseCode, string employeeCode, int roleGroupCode)
        {
            return ReadProc(out employeeRoleSt, enterpriseCode, employeeCode, roleGroupCode);
        }

        /// <summary>
        /// �ǂݍ��ݏ���
        /// </summary>
        /// <param name="employeeRoleSt">UI�f�[�^�N���X</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <param name="roleGroupCode">���[���O���[�v�R�[�h</param>
        /// <remarks>
        /// <br>Note       : </br>
        /// <br></br>
        /// </remarks>
        private int ReadProc(out EmployeeRoleSt employeeRoleSt, string enterpriseCode, string employeeCode, int roleGroupCode)
        {
            int status = 0;

            employeeRoleSt = null;

            try
            {
                EmployeeRoleStWork employeeRoleStWork = new EmployeeRoleStWork();
                employeeRoleStWork.EnterpriseCode = enterpriseCode;
                employeeRoleStWork.EmployeeCode = employeeCode;
                employeeRoleStWork.RoleGroupCode = roleGroupCode;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(employeeRoleStWork);

                status = this._iEmployeeRoleStDB.Read(ref parabyte, 0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // XML�̓ǂݍ���
                    employeeRoleStWork = (EmployeeRoleStWork)XmlByteSerializer.Deserialize(parabyte, typeof(EmployeeRoleStWork));
                    // ���[�N��UI�f�[�^�N���X
                    employeeRoleSt = CopyToEmployeeRoleStFromEmployeeRoleStWork(employeeRoleStWork);
                }

                return status;
            }
            catch (Exception)
            {
                employeeRoleSt = null;
                // �I�t���C������null���Z�b�g
                this._iEmployeeRoleStDB = null;
                // �ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �o�^��X�V���� --
        /// <summary>
        /// �o�^�E�X�V����
        /// </summary>
        /// <param name="employeeRoleSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �o�^�E�X�V�������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Write(ref EmployeeRoleSt employeeRoleSt)
        {
            int status = 0;

            // UI�f�[�^�N���X�����[�N
            EmployeeRoleStWork employeeRoleStWork = CopyToEmployeeRoleStWorkFromEmployeeRoleSt(employeeRoleSt);

            object obj = employeeRoleStWork;

            try
            {
                // �������ݏ���
                status = this._iEmployeeRoleStDB.Write(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (obj is ArrayList)
                    {
                        employeeRoleStWork = (EmployeeRoleStWork)((ArrayList)obj)[0];
                        // ���[�N��UI�f�[�^�N���X
                        employeeRoleSt = CopyToEmployeeRoleStFromEmployeeRoleStWork(employeeRoleStWork);
                    }
                }
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iEmployeeRoleStDB = null;
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
        /// <param name="employeeRoleSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����[���ݒ�̘_���폜���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int LogicalDelete(ref EmployeeRoleSt employeeRoleSt)
        {
            int status = 0;

            // UI�f�[�^�N���X�����[�N
            EmployeeRoleStWork employeeRoleStWork = CopyToEmployeeRoleStWorkFromEmployeeRoleSt(employeeRoleSt);

            object obj = employeeRoleStWork;

            try
            {
                // �_���폜
                status = this._iEmployeeRoleStDB.LogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    employeeRoleStWork = (EmployeeRoleStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    employeeRoleSt = CopyToEmployeeRoleStFromEmployeeRoleStWork(employeeRoleStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iEmployeeRoleStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �����폜����
        /// </summary>
        /// <param name="employeeRoleSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����[���ݒ�̕����폜���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Delete(EmployeeRoleSt employeeRoleSt)
        {
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                EmployeeRoleStWork employeeRoleStWork = CopyToEmployeeRoleStWorkFromEmployeeRoleSt(employeeRoleSt);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(employeeRoleStWork);

                // �����폜
                status = this._iEmployeeRoleStDB.Delete(parabyte);

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iEmployeeRoleStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �������� --
        /// <summary>
        /// �]�ƈ����[���ݒ蕜������
        /// </summary>
        /// <param name="employeeRoleSt">UI�f�[�^�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����[���ݒ�̕������s���܂�</br>
        /// <br></br>
        /// </remarks>
        public int Revival(ref EmployeeRoleSt employeeRoleSt)
        {
            int status = 0;

            try
            {
                // UI�f�[�^�N���X�����[�N
                EmployeeRoleStWork employeeRoleStWork = CopyToEmployeeRoleStWorkFromEmployeeRoleSt(employeeRoleSt);

                object obj = employeeRoleStWork;

                // ��������
                status = this._iEmployeeRoleStDB.RevivalLogicalDelete(ref obj);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    employeeRoleStWork = (EmployeeRoleStWork)obj;
                    // ���[�N��UI�f�[�^�N���X
                    employeeRoleSt = CopyToEmployeeRoleStFromEmployeeRoleStWork(employeeRoleStWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iEmployeeRoleStDB = null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }
        #endregion

        #region -- �������� --
        /// <summary>
        /// �]�ƈ����[���ݒ茟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����[���ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br></br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, "");
        }

        /// <summary>
        /// �]�ƈ����[���ݒ茟�������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����[���ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br></br>
        /// </remarks>
        public int Search3(out ArrayList retList, string enterpriseCode, string employeeCode)
        {
            return SearchProc(out retList, enterpriseCode, employeeCode);
        }

        /// <summary>
        /// �]�ƈ����[���ݒ茟������
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����[���ݒ�̌����������s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode, string employeeCode)
        {
            int status = 0;

            EmployeeRoleStWork employeeRoleStWork = new EmployeeRoleStWork();
            employeeRoleStWork.EnterpriseCode = enterpriseCode;
            employeeRoleStWork.EmployeeCode = employeeCode;

            retList = new ArrayList();

            object paraobj = employeeRoleStWork;
            object retobj = null;

            // �]�ƈ����[���ݒ�̑S����
            status = this._iEmployeeRoleStDB.Search(out retobj, paraobj, 0, ConstantManagement.LogicalMode.GetData01);

            if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                ArrayList workList = retobj as ArrayList;

                foreach (EmployeeRoleStWork wkEmployeeRoleStWork in workList)
                {
                    // �S���ǉ�
                    retList.Add(CopyToEmployeeRoleStFromEmployeeRoleStWork(wkEmployeeRoleStWork));
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
            return Search2(ref ds, enterpriseCode, "");
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
        public int Search2(ref DataSet ds, string enterpriseCode, string employeeCode)
        {
            ArrayList retList = new ArrayList();

            int status = 0;

            // �}�X�^�T�[�`
            status = SearchProc(out retList, enterpriseCode, employeeCode);
            if (status != 0)
            {
                return status;
            }

            ArrayList workList = retList.Clone() as ArrayList;
            SortedList workSort = new SortedList();

            // --- [�S��] --- //
            // ���̂܂ܑS���Ԃ�
            foreach (EmployeeRoleSt wkEmployeeRoleSt in workList)
            {
                if (wkEmployeeRoleSt.LogicalDeleteCode == 0)
                {
                    workSort.Add(wkEmployeeRoleSt.RoleGroupCode, wkEmployeeRoleSt);
                }
            }

            EmployeeRoleSt[] employeeRoleSt = new EmployeeRoleSt[workSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < workSort.Count; i++)
            {
                employeeRoleSt[i] = (EmployeeRoleSt)workSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(employeeRoleSt);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }
        #endregion

        #region -- �N���X�����o�[�R�s�[���� --
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i���[�N�N���X��UI�f�[�^�N���X�j
        /// </summary>
        /// <param name="employeeRoleStWork">���[�N�N���X</param>
        /// <returns>UI�f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : ���[�N�N���X����UI�f�[�^�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private EmployeeRoleSt CopyToEmployeeRoleStFromEmployeeRoleStWork(EmployeeRoleStWork employeeRoleStWork)
        {
            EmployeeRoleSt employeeRoleSt = new EmployeeRoleSt();

            employeeRoleSt.CreateDateTime = employeeRoleStWork.CreateDateTime;
            employeeRoleSt.UpdateDateTime = employeeRoleStWork.UpdateDateTime;
            employeeRoleSt.EnterpriseCode = employeeRoleStWork.EnterpriseCode;
            employeeRoleSt.FileHeaderGuid = employeeRoleStWork.FileHeaderGuid;
            employeeRoleSt.UpdEmployeeCode = employeeRoleStWork.UpdEmployeeCode;
            employeeRoleSt.UpdAssemblyId1 = employeeRoleStWork.UpdAssemblyId1;
            employeeRoleSt.UpdAssemblyId2 = employeeRoleStWork.UpdAssemblyId2;
            employeeRoleSt.LogicalDeleteCode = employeeRoleStWork.LogicalDeleteCode;
            employeeRoleSt.EmployeeCode = employeeRoleStWork.EmployeeCode;                      // �]�ƈ��R�[�h
            employeeRoleSt.RoleGroupCode = employeeRoleStWork.RoleGroupCode;                    // ���[���O���[�v�R�[�h
            employeeRoleSt.RoleGroupName = employeeRoleStWork.RoleGroupName;                    // ���[���O���[�v����
            employeeRoleSt.EmployeeName = employeeRoleStWork.EmployeeName;                      // �]�ƈ�����

            return employeeRoleSt;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����iUI�f�[�^�N���X�˃��[�N�N���X�j
        /// </summary>
        /// <param name="employeeRoleSt">UI�f�[�^�N���X</param>
        /// <returns>���[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : UI�f�[�^�N���X���烏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br></br>
        /// </remarks>
        private EmployeeRoleStWork CopyToEmployeeRoleStWorkFromEmployeeRoleSt(EmployeeRoleSt employeeRoleSt)
        {
            EmployeeRoleStWork employeeRoleStWork = new EmployeeRoleStWork();

            employeeRoleStWork.CreateDateTime = employeeRoleSt.CreateDateTime;
            employeeRoleStWork.UpdateDateTime = employeeRoleSt.UpdateDateTime;
            employeeRoleStWork.EnterpriseCode = employeeRoleSt.EnterpriseCode;
            employeeRoleStWork.FileHeaderGuid = employeeRoleSt.FileHeaderGuid;
            employeeRoleStWork.UpdEmployeeCode = employeeRoleSt.UpdEmployeeCode;
            employeeRoleStWork.UpdAssemblyId1 = employeeRoleSt.UpdAssemblyId1;
            employeeRoleStWork.UpdAssemblyId2 = employeeRoleSt.UpdAssemblyId2;
            employeeRoleStWork.LogicalDeleteCode = employeeRoleSt.LogicalDeleteCode;
            employeeRoleStWork.EmployeeCode = employeeRoleSt.EmployeeCode;                      // �]�ƈ��R�[�h
            employeeRoleStWork.RoleGroupCode = employeeRoleSt.RoleGroupCode;                    // ���[���O���[�v�R�[�h
            employeeRoleStWork.RoleGroupName = employeeRoleSt.RoleGroupName;                    // ���[���O���[�v����
            employeeRoleStWork.EmployeeName = employeeRoleSt.EmployeeName;                      // �]�ƈ�����

            return employeeRoleStWork;
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

            // �]�ƈ����[���ݒ�}�X�^�̓Ǎ�
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
        /// �]�ƈ����[���ݒ�}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeRoleSt">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note        : �]�ƈ����[���ݒ�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out EmployeeRoleSt employeeRoleSt)
        {
            return ExecuteGuid2(enterpriseCode, out employeeRoleSt);
        }

        /// <summary>
        /// �]�ƈ����[���ݒ�}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeRoleSt">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note        : �]�ƈ����[���ݒ�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br></br>
        /// </remarks>
        public int ExecuteGuid2(string enterpriseCode, out EmployeeRoleSt employeeRoleSt)
        {
            int status = -1;
            employeeRoleSt = new EmployeeRoleSt();

            TableGuideParent tableGuideParent = new TableGuideParent("EMPLOYEEROLESTGUIDEPARENT.XML");
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add("EnterpriseCode", enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
                string strCode = retObj["RoleGroupCode"].ToString();
                employeeRoleSt.EmployeeCode = retObj["EmployeeCode"].ToString();
                employeeRoleSt.RoleGroupCode = int.Parse(strCode);
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
