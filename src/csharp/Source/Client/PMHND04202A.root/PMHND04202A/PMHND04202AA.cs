//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�Ɖ���A�N�Z�X�N���X
// �v���O�����T�v   : ���i�Ɖ���A�N�Z�X�N���X�ł�
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370006-00 �쐬�S�� : 杍^
// �� �� ��  2017/07/20  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11470154-00 �쐬�S�� : ���O                              
// �C �� ��  2018/10/16  �C�����e : �n���f�B�^�[�~�i���܎��Ή�
//                                  ����@�\�ƃe�L�X�g�o�͋@�\�̒ǉ�
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections.Generic;

namespace Broadleaf.Application.Controller
{
	/// <summary>
    /// ���i�Ɖ���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
    /// <br>Note		: ���i�Ɖ���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer	: 杍^</br>
    /// <br>Date		: 2017/07/20/br>
    /// <br>Update Note: 2018/10/16 ���O</br>
    /// <br>�@�@�@�@�@ : �n���f�B�^�[�~�i���܎��Ή�</br>
	/// </remarks>    
	public class InspectInfoAcs
	{
		# region ��Private Member
        /// <summary>�C���X�^���X(singleton)</summary>
        private static InspectInfoAcs InspectInfoAccessor;
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IHandyInspectRefDataDB IHandyInspectRefDataDBAdapter = null;
        private Dictionary<string, string> EmployeeDic;
        /// <summary>�]�ƈ��}�X�^�A�N�Z�X�N���X</summary>
        private EmployeeAcs EmployeeAccessor;
        
		# endregion				    
		  
		# region ��Constracter
		/// <summary>
        /// ���i�Ɖ���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note       : ���i�Ɖ���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
		/// </remarks>
        private InspectInfoAcs()
		{
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this.IHandyInspectRefDataDBAdapter = (IHandyInspectRefDataDB)MediationHandyInspectRefDataDB.GetHandyInspectRefDataDB();
                // �]�ƈ��A�N�Z�X�N���X�����������܂��B
                this.EmployeeAccessor = new EmployeeAcs();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this.IHandyInspectRefDataDBAdapter = null;
            }
		}

        /// <summary>
        /// ���i�Ɖ���A�N�Z�X�N���X�̃V���O���g���C���X�^���X�擾����
        /// </summary>
        /// <returns>���i�Ɖ���A�N�Z�X�N���X�̃V���O���g���C���X�^���X</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ɖ���A�N�Z�X�N���X�̃V���O���g���C���X�^���X���擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public static InspectInfoAcs GetInstance()
        {
            if (InspectInfoAccessor == null)
            {
                InspectInfoAccessor = new InspectInfoAcs();
            }

            return InspectInfoAccessor;
        }
		# endregion

        # region public
        /// <summary>
        /// ���i�Ɖ��񃊃X�g�̎擾����
        /// </summary>
        /// <param name="handyInspectParamWork">�����p�����[�^</param>
        /// <param name="handyInspectDataList">���i�Ɖ���</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ɖ��񃊃X�g���擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// <br>Update Note: 2018/10/16 ���O</br>
        /// <br>�@�@�@�@�@ : �n���f�B�^�[�~�i���܎��Ή�</br>
        /// </remarks>
        public int Search(HandyInspectParamWork handyInspectParamWork, out ArrayList handyInspectDataList)
		{
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            string ErrMsg = string.Empty;
            object HandyInspectResultObj = null;
            handyInspectDataList = new ArrayList();

            object HandyInspectParamObj = (object)handyInspectParamWork;

            // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�---------->>>>>
            try
            {
            // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�----------<<<<<
                Status = this.IHandyInspectRefDataDBAdapter.Search(out HandyInspectResultObj, HandyInspectParamObj, out ErrMsg);
            // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�---------->>>>>
            }
            catch (OutOfMemoryException)
            {
                Status = -100; // OutOfMemoryException
            }
            // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�----------<<<<<

            if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                handyInspectDataList = HandyInspectResultObj as ArrayList;
            }
            return Status;
        }

        /// <summary>
        /// ���i�Ɖ���̓o�^����
        /// </summary>
        /// <param name="delHandyInspectDataList">��s���i�f�[�^�����폜�f�[�^</param>
        /// <param name="handyInspectDataList">���i�o�^�f�[�^</param>
        /// <param name="mode">0:�蓮���i�f�[�^�o�^����,1:��s���i�����o�^����</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ɖ���̓o�^�������s���B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public int WriteInspectData(ArrayList delHandyInspectDataList, ArrayList handyInspectDataList, int mode)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            object DelHandyInspectDataObj = null;
            try
            {
                if (delHandyInspectDataList != null && delHandyInspectDataList.Count > 0)
                {
                    DelHandyInspectDataObj = (object)delHandyInspectDataList;
                }
                object HandyInspectDataObj = (object)handyInspectDataList;
                // ���i�����o�^����
                Status = this.IHandyInspectRefDataDBAdapter.WriteInspectData(DelHandyInspectDataObj, HandyInspectDataObj, mode);
            }
            catch
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return Status;
        }

        /// <summary>
        /// ���i�K�C�h�f�[�^�̎擾����
        /// </summary>
        /// <param name="handyInspectParamWork">�����p�����[�^</param>
        /// <param name="handyInspectDataList">���i�f�[�^</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�K�C�h�f�[�^���擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public int SearchGuid(HandyInspectDataWork handyInspectParamWork, out ArrayList handyInspectDataList)
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            object InspectDataObj = null;
            handyInspectDataList = new ArrayList();
            try
            {
                object HandyInspectParamObj = (object)handyInspectParamWork;

                Status = this.IHandyInspectRefDataDBAdapter.SearchGuid(HandyInspectParamObj, out InspectDataObj);
                handyInspectDataList = InspectDataObj as ArrayList;
            }
            catch
            {
                Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return Status;
        }
        // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�---------->>>>>
        /// <summary>
        /// ���i�Ɖ���̍폜����
        /// </summary>
        /// <param name="delInspectDataObj">�폜�p�����[�^</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���i�Ɖ�����폜���܂��B</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : 2019/10/16</br>
        /// </remarks>
        public int DeleteInspectData(object delInspectDataObj, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            message = string.Empty;

            status = this.IHandyInspectRefDataDBAdapter.DeleteInspectData(delInspectDataObj, out message);

            return status;
        }
        // --- ADD ���O 2018/10/16 �n���f�B�^�[�~�i���܎��Ή�----------<<<<<
        # endregion

        #region �]�ƈ��}�X�^�Ǎ�
        /// <summary>
        /// �]�ƈ��}�X�^�Ǎ�����
        /// </summary>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ��}�X�^��Ǎ��A�o�b�t�@�ɕێ����܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public int ReadEmployee()
        {
            int Status = (int)ConstantManagement.DB_Status.ctDB_ERROR;

            this.EmployeeDic = new Dictionary<string, string>();

            try
            {
                ArrayList RetList;
                ArrayList RetList2;
                Status = this.EmployeeAccessor.Search(out RetList, out RetList2, LoginInfoAcquisition.EnterpriseCode);
                if (Status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (Employee EmployeeWork in RetList)
                    {
                        if (EmployeeWork.LogicalDeleteCode == 0)
                        {
                            this.EmployeeDic.Add(EmployeeWork.EmployeeCode.Trim().PadLeft(4, '0'), EmployeeWork.Name.Trim());
                        }
                    }
                }
            }
            catch
            {
                // �����Ȃ�
            }

            return Status;
        }
        #endregion �]�ƈ��}�X�^�Ǎ�

        #region �]�ƈ����̎擾
        /// <summary>
        /// �]�ƈ����̎擾����
        /// </summary>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�]�ƈ�����</returns>
        /// <remarks>
        /// <br>Note       : �]�ƈ����̂��擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2017/07/20</br>
        /// </remarks>
        public string GetEmployeeName(string employeeCode)
        {
            string EmployeeName = string.Empty;

            if (this.EmployeeDic.ContainsKey(employeeCode.Trim().PadLeft(4, '0')))
            {
                EmployeeName = this.EmployeeDic[employeeCode.Trim().PadLeft(4, '0')];
            }

            return EmployeeName;
        }
        #endregion �]�ƈ����̎擾
    }
}
