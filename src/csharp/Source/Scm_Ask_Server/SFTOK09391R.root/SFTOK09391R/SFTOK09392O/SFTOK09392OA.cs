using System;
using System.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// PM�]�ƈ�DB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : PM�]�ƈ�DB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 22011�@Kashihara</br>
	/// <br>Date       : 2013.05.28</br>
    /// <br>Note       : ����ꗗ_PM-TAB No.48</br>
    /// <br>Programmer : �A����</br>
    /// <br>Date       : 2013/06/11</br>
    /// <br>Note       : �\�[�X�`�F�b�N�m�F�����ꗗ��No.32</br>
    /// <br>Programmer : �A����</br>
    /// <br>Date       : 2013/06/17</br>
    /// <br>Note       : ��10663 #43465 �^�u���b�g�S���ґΉ�</br>
    /// <br>Programmer : �g�� �F��</br>
    /// <br>Date       : 2014/10/03</br>
    /// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	[APServerTarget(ConstantManagement_SF_PRO.ServerCode_SCM_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��
	public interface IPMEmployeeDB
	{
		/// <summary>
		/// �w�肳�ꂽPM�]�ƈ�Guid��PM�]�ƈ���߂��܂�
		/// </summary>
		/// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
		/// <param name="readMode">�����敪</param>
		/// <returns>STATUS</returns>
		int Read(ref byte[] parabyte , int readMode);

        /// <summary>
        /// �w�肳�ꂽPM�]�ƈ�Guid��PM�]�ƈ���߂��܂�
        /// </summary>
        /// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
        /// <param name="readMode">�����敪</param>
        /// <returns>STATUS</returns>
        [MustCustomSerialization]
        int Read(
            [CustomSerializationMethodParameterAttribute("SFTOK09386D", "Broadleaf.Application.Remoting.ParamData.EmployeeWork")]
			ref object parabyte,
            int readMode);

        /// <summary>
        /// �]�ƈ�����o�^�A�X�V���܂�
        /// </summary>
        /// <param name="paraobj">WorkerWork�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        int Write(ref object paraobj);

        //---DEL �A���� 2013/06/17 �\�[�X�`�F�b�N�m�F�����ꗗ��No.32�̑Ή�--->>>>>
        ////--ADD �A���� 2013/06/11 ����ꗗ_PM-TAB No.48--->>>>>
        ///// <summary>
        ///// �w�肳�ꂽ�����̋��_���LIST��S�Ė߂��܂�
        ///// </summary>
        ///// <param name="parabyte">WorkerWork�I�u�W�F�N�g</param>
        ///// <param name="searchPara">��������</param>
        ///// <param name="readMode">�����敪</param>
        ///// <param name="logicalMode">�_���폜�敪</param>
        ///// <returns>STATUS</returns>
        //[MustCustomSerialization]
        //int Search(
        //    [CustomSerializationMethodParameterAttribute("SFTOK09394D", "Broadleaf.Application.Remoting.ParamData.PMEmployeeWork")]
        //    out object parabyte,
        //    PMEmployeeWork searchPara,
        //    int readMode,
        //    ConstantManagement.LogicalMode logicalMode);
        ////--ADD �A���� 2013/06/11 ����ꗗ_PM-TAB No.48---<<<<<
        //---DEL �A���� 2013/06/17 �\�[�X�`�F�b�N�m�F�����ꗗ��No.32�̑Ή�--->>>>>

        //---ADD �A���� 2013/06/17 �\�[�X�`�F�b�N�m�F�����ꗗ��No.9�̑Ή�--->>>>>
        /// <summary>
        /// PMTAB�]�ƈ��������ʏ���ǉ��E�X�V���܂��B
        /// </summary>
        /// <param name="pmTabEmployeeWorkList">�ǉ��E�X�V����PMTAB�]�ƈ��������ʏ��</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�]�ƈ��������ʏ���ǉ��E�X�V���܂��B</br>
        /// <br>Programmer : �A���� </br>
        /// <br>Date       : 2013.05.29</br>
        [MustCustomSerialization]
        int WriteForTablet(
            [CustomSerializationMethodParameterAttribute("SFTOK09394D", "Broadleaf.Application.Remoting.ParamData.PMEmployeeWork")]
            ref object pmTabEmployeeWorkList);
        //---ADD �A���� 2013/06/17 �\�[�X�`�F�b�N�m�F�����ꗗ��No.32�̑Ή�--->>>>>

        // ADD 2014/10/03 ��10663 #43465 �^�u���b�g�S���ґΉ� ---------------------------->>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �w�肳�ꂽ�����̏]�ƈ�LIST��S�Ė߂��܂�
        /// </summary>
        /// <param name="retObj">��������</param>
        /// <param name="paraObj">�����p�����[�^</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6::���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : PMTAB�]�ƈ��������ʏ����������܂��B</br>
        [MustCustomSerialization]
        int SearchForTablet(
            [CustomSerializationMethodParameterAttribute("SFTOK09394D", "Broadleaf.Application.Remoting.ParamData.PMEmployeeWork")]
			out object retObj,
            object paraObj,
            ConstantManagement.LogicalMode logicalMode);
        // ADD 2014/10/03 ��10663 #43465 �^�u���b�g�S���ґΉ� ----------------------------<<<<<<<<<<<<<<<<<<<<<<<<
    }
}