//****************************************************************************//
// �V�X�e��         : �����񓚏���
// �v���O��������   : �����񓚏����A�N�Z�X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/07/09  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;
using Broadleaf.Application.UIData.Util;

namespace Broadleaf.Application.Controller.Agent
{
    using RealAccesserType  = EmployeeAcs;
    using RecordType        = KeyValuePair<Employee, EmployeeDtl>;

    /// <summary>
    /// �]�ƈ��}�X�^�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public class EmployeeAgent : AgentPolicy<RealAccesserType, RecordType>
    {
        private const string MY_NAME = "�]�ƈ��}�X�^";
        private const string CLASS_NAME = "EmployeeAgent";  // ���O�p

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public EmployeeAgent() : base() { }

        #endregion // </Constructor>

        /// <summary>
        /// �������܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="employeeCode">�]�ƈ��R�[�h</param>
        /// <returns>�Y������]�ƈ�</returns>
        public RecordType Find(
            string enterpriseCode,
            string employeeCode
        )
        {
            const string METHOD_NAME = "Find()";    // ���O�p

            string key = SCMEntityUtil.FormatEnterpriseCode(enterpriseCode) + SCMEntityUtil.FormatEmployeeCode(employeeCode);
            if (FoundRecordMap.ContainsKey(key))
            {
                return FoundRecordMap[key];
            }

            Employee    foundEmployee       = null;
            EmployeeDtl foundEmployeeDetail = null;
            int status = RealAccesser.Read(out foundEmployee, out foundEmployeeDetail, enterpriseCode, employeeCode);
            if (!status.Equals((int)ResultUtil.ResultCode.Normal) && !status.Equals((int)ResultUtil.ResultCode.NotFound))
            {
                #region <Log>

                string msg = string.Format(
                    "�]�ƈ��}�X�^�̌����G���[�F{0}(��ƃR�[�h={1}, �]�ƈ��R�[�h={2})",
                    status,
                    enterpriseCode,
                    employeeCode
                );
                EasyLogger.WriteDebugLog(CLASS_NAME, METHOD_NAME, LogHelper.GetDebugMsg(msg));

                #endregion // </Log>

                Debug.Assert(false, MY_NAME + "�̌��������s���܂����B");
            }

            if (foundEmployee != null && foundEmployee.LogicalDeleteCode.Equals(0))
            {
                FoundRecordMap.Add(key, new RecordType(foundEmployee, foundEmployeeDetail ?? new EmployeeDtl()));
                return FoundRecordMap[key];
            }

            return new RecordType(foundEmployee ?? new Employee(), foundEmployeeDetail ?? new EmployeeDtl());
        }
    }
}
