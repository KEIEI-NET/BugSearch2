//**********************************************************************//
// System           :   PM.NS                                           //
// Sub System       :                                                   //
// Program name     :   ���[���O���[�v�����ݒ�}�X�^                    //
//                      �f�[�^�N���X                                    //
//                  :   PMKHN09731E.DLL                                 //
// Name Space       :   Broadleaf.Application.UIData                    //
// Programmer       :   30746 ���� ��                                   //
// Date             :   2013/02/18                                      //
//----------------------------------------------------------------------//
// Update Note      :                                                   //
//----------------------------------------------------------------------//
//                 Copyright(C) 2008 Broadleaf Co.,Ltd.                 //
//**********************************************************************//

using System;
using System.Collections;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// public class name:   RoleGroupAuth
    /// <summary>
    ///                      ���[���O���[�v�����ݒ�}�X�^
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���[���O���[�v�����ݒ�}�X�^�w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2013/02/18</br>
    /// <br>Genarated Date   :   2013/02/18  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class RoleGroupAuth
    {
        /// <summary>�쐬����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _createDateTime;

        /// <summary>�X�V����</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</remarks>
        private DateTime _updateDateTime;

        /// <summary>��ƃR�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</remarks>
        private string _enterpriseCode = "";

        /// <summary>GUID</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private Guid _fileHeaderGuid;

        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        /// <remarks>���ʃt�@�C���w�b�_</remarks>
        private string _updEmployeeCode = "";

        /// <summary>�X�V�A�Z���u��ID1</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId1 = "";

        /// <summary>�X�V�A�Z���u��ID2</summary>
        /// <remarks>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</remarks>
        private string _updAssemblyId2 = "";

        /// <summary>�_���폜�敪</summary>
        /// <remarks>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>���[���O���[�v�R�[�h</summary>
        private Int32 _roleGroupCode;

        /// <summary>���[���J�e�S��ID</summary>
        private Int32 _roleCategoryID;

        /// <summary>���[���T�u�J�e�S��ID</summary>
        private Int32 _roleCategorySubID;

        /// <summary>���[���A�C�e��ID</summary>
        private Int32 _roleItemID;

        /// <summary>���[�������敪</summary>
        private Int32 _roleLimitDiv;

        /// public propaty name  :  CreateDateTime
        /// <summary>�쐬�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �쐬�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>�X�V�����v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�����v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  EnterpriseCode
        /// <summary>��ƃR�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ��ƃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  FileHeaderGuid
        /// <summary>GUID�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   GUID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Guid FileHeaderGuid
        {
            get { return _fileHeaderGuid; }
            set { _fileHeaderGuid = value; }
        }

        /// public propaty name  :  UpdEmployeeCode
        /// <summary>�X�V�]�ƈ��R�[�h�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�]�ƈ��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdEmployeeCode
        {
            get { return _updEmployeeCode; }
            set { _updEmployeeCode = value; }
        }

        /// public propaty name  :  UpdAssemblyId1
        /// <summary>�X�V�A�Z���u��ID1�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID1�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId1
        {
            get { return _updAssemblyId1; }
            set { _updAssemblyId1 = value; }
        }

        /// public propaty name  :  UpdAssemblyId2
        /// <summary>�X�V�A�Z���u��ID2�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �X�V�A�Z���u��ID2�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string UpdAssemblyId2
        {
            get { return _updAssemblyId2; }
            set { _updAssemblyId2 = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>�_���폜�敪�v���p�e�B</summary>
        /// <value>���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   �_���폜�敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  RoleGroupCode
        /// <summary>���[���O���[�v�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���O���[�v�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RoleGroupCode
        {
            get { return _roleGroupCode; }
            set { _roleGroupCode = value; }
        }

        /// public propaty name  :  RoleCategoryID
        /// <summary>���[���J�e�S��ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���J�e�S��ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RoleCategoryID
        {
            get { return _roleCategoryID; }
            set { _roleCategoryID = value; }
        }

        /// public propaty name  :  RoleCategorySubID
        /// <summary>���[���T�u�J�e�S��ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���T�u�J�e�S��ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RoleCategorySubID
        {
            get { return _roleCategorySubID; }
            set { _roleCategorySubID = value; }
        }

        /// public propaty name  :  RoleItemID
        /// <summary>���[���A�C�e��ID�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[���A�C�e��ID�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RoleItemID
        {
            get { return _roleItemID; }
            set { _roleItemID = value; }
        }

        /// public propaty name  :  RoleLimitDiv
        /// <summary>���[�������敪�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���[�������敪�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 RoleLimitDiv
        {
            get { return _roleLimitDiv; }
            set { _roleLimitDiv = value; }
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <returns>RoleGroupAuth�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuth�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RoleGroupAuth()
        {
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^�R���X�g���N�^
        /// </summary>
        /// <param name="createDateTime">�쐬����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="updateDateTime">�X�V����(���ʃt�@�C���w�b�_�iDateTime:���x��100�i�m�b�j)</param>
        /// <param name="enterpriseCode">��ƃR�[�h(���ʃt�@�C���w�b�_�i��2��+��2��+�Ǝ�2��+���[�U�[�R�[�h10���j)</param>
        /// <param name="fileHeaderGuid">GUID(���ʃt�@�C���w�b�_)</param>
        /// <param name="updEmployeeCode">�X�V�]�ƈ��R�[�h(���ʃt�@�C���w�b�_)</param>
        /// <param name="updAssemblyId1">�X�V�A�Z���u��ID1(���ʃt�@�C���w�b�_�iUI���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="updAssemblyId2">�X�V�A�Z���u��ID2(���ʃt�@�C���w�b�_�iServer���̍X�V�A�Z���u��ID+�u:�v+�o�[�W�����j)</param>
        /// <param name="logicalDeleteCode">�_���폜�敪(���ʃt�@�C���w�b�_(0:�L��,1:�_���폜,2:�ۗ�,3:���S�폜))</param>
        /// <param name="roleGroupCode">���[���O���[�v�R�[�h</param>
        /// <param name="roleCategoryID">���[���J�e�S��ID</param>
        /// <param name="roleCategorySubID">���[���T�u�J�e�S��ID</param>
        /// <param name="roleItemID">���[���A�C�e��ID</param>
        /// <param name="roleLimitDiv">���[�������敪</param>
        /// <returns>RoleGroupAuth�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuth�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RoleGroupAuth(DateTime createDateTime, DateTime updateDateTime, string enterpriseCode, Guid fileHeaderGuid, string updEmployeeCode, string updAssemblyId1, string updAssemblyId2, Int32 logicalDeleteCode, Int32 roleGroupCode, Int32 roleCategoryID, Int32 roleCategorySubID, Int32 roleItemID, Int32 roleLimitDiv)
        {
            this.CreateDateTime = createDateTime;
            this.UpdateDateTime = updateDateTime;
            this._enterpriseCode = enterpriseCode;
            this._fileHeaderGuid = fileHeaderGuid;
            this._updEmployeeCode = updEmployeeCode;
            this._updAssemblyId1 = updAssemblyId1;
            this._updAssemblyId2 = updAssemblyId2;
            this._logicalDeleteCode = logicalDeleteCode;
            this._roleGroupCode = roleGroupCode;
            this._roleCategoryID = roleCategoryID;
            this._roleCategorySubID = roleCategorySubID;
            this._roleItemID = roleItemID;
            this._roleLimitDiv = roleLimitDiv;
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^
        /// </summary>
        /// <returns>RoleGroupAuth�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note             :   ���g�̓��e�Ɠ�����RoleGroupAuth�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public RoleGroupAuth Clone()
        {
            return new RoleGroupAuth(this._createDateTime, this._updateDateTime, this._enterpriseCode, this._fileHeaderGuid, this._updEmployeeCode, this._updAssemblyId1, this._updAssemblyId2, this._logicalDeleteCode, this._roleGroupCode, this._roleCategoryID, this._roleCategorySubID, this._roleItemID, this._roleLimitDiv);
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�RoleGroupAuth�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuth�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals(RoleGroupAuth target)
        {
            return ((this.CreateDateTime == target.CreateDateTime)
                 && (this.UpdateDateTime == target.UpdateDateTime)
                 && (this.EnterpriseCode == target.EnterpriseCode)
                 && (this.FileHeaderGuid == target.FileHeaderGuid)
                 && (this.UpdEmployeeCode == target.UpdEmployeeCode)
                 && (this.UpdAssemblyId1 == target.UpdAssemblyId1)
                 && (this.UpdAssemblyId2 == target.UpdAssemblyId2)
                 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
                 && (this.RoleGroupCode == target.RoleGroupCode)
                 && (this.RoleCategoryID == target.RoleCategoryID)
                 && (this.RoleCategorySubID == target.RoleCategorySubID)
                 && (this.RoleItemID == target.RoleItemID)
                 && (this.RoleLimitDiv == target.RoleLimitDiv));
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^��r����
        /// </summary>
        /// <param name="roleGroupAuth1">��r����RoleGroupAuth�N���X�̃C���X�^���X</param>
        /// <param name="roleGroupAuth2">��r����RoleGroupAuth�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuth�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals(RoleGroupAuth roleGroupAuth1, RoleGroupAuth roleGroupAuth2)
        {
            return ((roleGroupAuth1.CreateDateTime == roleGroupAuth2.CreateDateTime)
                 && (roleGroupAuth1.UpdateDateTime == roleGroupAuth2.UpdateDateTime)
                 && (roleGroupAuth1.EnterpriseCode == roleGroupAuth2.EnterpriseCode)
                 && (roleGroupAuth1.FileHeaderGuid == roleGroupAuth2.FileHeaderGuid)
                 && (roleGroupAuth1.UpdEmployeeCode == roleGroupAuth2.UpdEmployeeCode)
                 && (roleGroupAuth1.UpdAssemblyId1 == roleGroupAuth2.UpdAssemblyId1)
                 && (roleGroupAuth1.UpdAssemblyId2 == roleGroupAuth2.UpdAssemblyId2)
                 && (roleGroupAuth1.LogicalDeleteCode == roleGroupAuth2.LogicalDeleteCode)
                 && (roleGroupAuth1.RoleGroupCode == roleGroupAuth2.RoleGroupCode)
                 && (roleGroupAuth1.RoleCategoryID == roleGroupAuth2.RoleCategoryID)
                 && (roleGroupAuth1.RoleCategorySubID == roleGroupAuth2.RoleCategorySubID)
                 && (roleGroupAuth1.RoleItemID == roleGroupAuth2.RoleItemID)
                 && (roleGroupAuth1.RoleLimitDiv == roleGroupAuth2.RoleLimitDiv));
        }
        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^��r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�RoleGroupAuth�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuth�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare(RoleGroupAuth target)
        {
            ArrayList resList = new ArrayList();
            if (this.CreateDateTime != target.CreateDateTime) resList.Add("CreateDateTime");
            if (this.UpdateDateTime != target.UpdateDateTime) resList.Add("UpdateDateTime");
            if (this.EnterpriseCode != target.EnterpriseCode) resList.Add("EnterpriseCode");
            if (this.FileHeaderGuid != target.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (this.UpdEmployeeCode != target.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (this.UpdAssemblyId1 != target.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (this.UpdAssemblyId2 != target.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (this.LogicalDeleteCode != target.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (this.RoleGroupCode != target.RoleGroupCode) resList.Add("RoleGroupCode");
            if (this.RoleCategoryID != target.RoleCategoryID) resList.Add("RoleCategoryID");
            if (this.RoleCategorySubID != target.RoleCategorySubID) resList.Add("RoleCategorySubID");
            if (this.RoleItemID != target.RoleItemID) resList.Add("RoleItemID");
            if (this.RoleLimitDiv != target.RoleLimitDiv) resList.Add("RoleLimitDiv");

            return resList;
        }

        /// <summary>
        /// ���[���O���[�v�����ݒ�}�X�^��r����
        /// </summary>
        /// <param name="roleGroupAuth1">��r����RoleGroupAuth�N���X�̃C���X�^���X</param>
        /// <param name="roleGroupAuth2">��r����RoleGroupAuth�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note             :   RoleGroupAuth�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare(RoleGroupAuth roleGroupAuth1, RoleGroupAuth roleGroupAuth2)
        {
            ArrayList resList = new ArrayList();
            if (roleGroupAuth1.CreateDateTime != roleGroupAuth2.CreateDateTime) resList.Add("CreateDateTime");
            if (roleGroupAuth1.UpdateDateTime != roleGroupAuth2.UpdateDateTime) resList.Add("UpdateDateTime");
            if (roleGroupAuth1.EnterpriseCode != roleGroupAuth2.EnterpriseCode) resList.Add("EnterpriseCode");
            if (roleGroupAuth1.FileHeaderGuid != roleGroupAuth2.FileHeaderGuid) resList.Add("FileHeaderGuid");
            if (roleGroupAuth1.UpdEmployeeCode != roleGroupAuth2.UpdEmployeeCode) resList.Add("UpdEmployeeCode");
            if (roleGroupAuth1.UpdAssemblyId1 != roleGroupAuth2.UpdAssemblyId1) resList.Add("UpdAssemblyId1");
            if (roleGroupAuth1.UpdAssemblyId2 != roleGroupAuth2.UpdAssemblyId2) resList.Add("UpdAssemblyId2");
            if (roleGroupAuth1.LogicalDeleteCode != roleGroupAuth2.LogicalDeleteCode) resList.Add("LogicalDeleteCode");
            if (roleGroupAuth1.RoleGroupCode != roleGroupAuth2.RoleGroupCode) resList.Add("RoleGroupCode");
            if (roleGroupAuth1.RoleCategoryID != roleGroupAuth2.RoleCategoryID) resList.Add("RoleCategoryID");
            if (roleGroupAuth1.RoleCategorySubID != roleGroupAuth2.RoleCategorySubID) resList.Add("RoleCategorySubID");
            if (roleGroupAuth1.RoleItemID != roleGroupAuth2.RoleItemID) resList.Add("RoleItemID");
            if (roleGroupAuth1.RoleLimitDiv != roleGroupAuth2.RoleLimitDiv) resList.Add("RoleLimitDiv");

            return resList;
        }
    }
}