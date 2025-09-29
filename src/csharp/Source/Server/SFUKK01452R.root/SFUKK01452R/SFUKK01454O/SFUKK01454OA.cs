using System;
using System.Collections;
using System.Data.SqlClient;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Remoting
{
	/// <summary>
	/// ����/����READDB RemoteObject�C���^�[�t�F�[�X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ����/����READDB RemoteObject Interface�ł��B</br>
	/// <br>Programmer : 90027�@�����@��</br>
	/// <br>Date       : 2005.08.16</br>
	/// <br></br>
	/// <br>Update Note: 2007.04.06 18322 T.Kimura Search�֐���DB�R�l�N�V������n���ł��쐬</br>
	/// <br></br>
	/// </remarks>

    [APServerTarget(ConstantManagement_SF_PRO.ServerCode_UserAP)]		//���A�v���P�[�V�����T�[�o�[�̐ڑ���𑮐��Ŏw��

	public interface IDepositReadDB
	{
		#region �J�X�^���V���A���C�Y

        /// <summary>
        /// ����/����READLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="depsitDataWork">��������</param>
        /// <param name="depositAlwWork">��������</param>
        /// <param name="searchParaDepositRead">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 90027�@�����@��</br>
        /// <br>Date       : 2005.08.16</br>
        //--- DEL 2008/06/27 M.Kubota --->>>
        //    int Search(
        //        [CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
        //        out object depsitMainWork,
        ////        [CustomSerializationMethodParameterAttribute("SFUKK01346D","Broadleaf.Application.Remoting.ParamData.DepositAlwWork")]
        //        out object depositAlwWork,
        //        object searchParaDepositRead,
        //        int readMode,
        //        ConstantManagement.LogicalMode logicalMode);
        //--- DEL 2008/06/27 M.Kubota ---<<<
        //--- ADD 2008/06/27 M.Kubota --->>>
        int Search(
            [CustomSerializationMethodParameterAttribute("SFUKK01343D", "Broadleaf.Application.Remoting.ParamData.DepsitDataWork")]
            out object depsitDataWork,
            [CustomSerializationMethodParameterAttribute("SFUKK01346D", "Broadleaf.Application.Remoting.ParamData.DepositAlwWork")]
            out object depositAlwWork,
            object searchParaDepositRead,
            int readMode,
            ConstantManagement.LogicalMode logicalMode);
        //--- ADD 2008/06/27 M.Kubota ---<<<

        # region --- DEL 2008/06/27 M.Kubota ---
        //--- UI ���� SqlConnection ��n���H �g���Ė�������폜
# if false
        // �� 20070406 18322 a
        /// <summary>
        /// ����/����READLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="depsitMainWork">��������</param>
        /// <param name="depositAlwWork">��������</param>
        /// <param name="searchParaDepositRead">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <param name="sqlConnection">DB�R�l�N�V����</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 18322 T.Kimura</br>
        /// <br>Date       : 2007.04.06</br>
        int Search(
            [CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
            out object depsitMainWork,
            out object depositAlwWork,
            object searchParaDepositRead,
            int readMode,
            ConstantManagement.LogicalMode logicalMode,
            ref SqlConnection sqlConnection);
        // �� 20070406 18322 a

//		/// <summary>
//		/// �w�肳�ꂽ��ƃR�[�h�̓���/����READ��߂��܂�
//		/// </summary>
//		/// <param name="depsitMainWork">DepsitMainWork�I�u�W�F�N�g</param>
//        /// <param name="depositAlwWork">DepositAlwWork�I�u�W�F�N�g</param>
//        /// <param name="searchParaDepositRead">�����p�����[�^</param>
//        /// <param name="readMode">�����敪</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : �w�肳�ꂽ��ƃR�[�h�̓���/����READ��߂��܂�</br>
//		/// <br>Programmer : 90027�@�����@��</br>
//		/// <br>Date       : 2005.08.16</br>
//		[MustCustomSerialization]
//		int Read(
//			[CustomSerializationMethodParameterAttribute("SFUKK01343D","Broadleaf.Application.Remoting.ParamData.DepsitMainWork")]
//			ref object depsitMainWork,
//            [CustomSerializationMethodParameterAttribute("SFUKK01346D","Broadleaf.Application.Remoting.ParamData.DepositAlwWork")]
//            ref object depositAlwWork,
//            object searchParaDepositRead,
//            int readMode
//			);
# endif			
        # endregion

        #endregion



        /// <summary>
        /// ����/����READLIST��S�Ė߂��܂��i�_���폜�����j
        /// </summary>
        /// <param name="DepsitDataWork">��������</param>
        /// <param name="DepositAlwWork">��������</param>
        /// <param name="searchParaDepositRead">�����p�����[�^</param>
        /// <param name="readMode">�����敪</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�ۗ��ް��̂� 3:���S�폜�ް��̂� 4:�S�� 5:���K�ް�+�폜�ް� 6:���K�ް�+�폜�ް�+�ۗ��ް�)</param>
        /// <returns>STATUS</returns>
        /// <br>Note       : </br>
        /// <br>Programmer : 90027�@�����@��</br>
        /// <br>Date       : 2005.08.16</br>
        int Search(out byte[] DepsitDataWork , out byte[] DepositAlwWork , object searchParaDepositRead , int readMode,ConstantManagement.LogicalMode logicalMode);

//		/// <summary>
//		/// �w�肳�ꂽ����/����READGuid�̓���/����READ��߂��܂�
//		/// </summary>
//		/// <param name="DepsitMainWork">DepsitMainWork</param>
//        /// <param name="DepositAlwWork">DepositAlwWork</param>
//        /// <param name="searchParaDepositRead">�����p�����[�^</param>
//        /// <param name="readMode">�����敪</param>
//		/// <returns>STATUS</returns>
//		/// <br>Note       : �w�肳�ꂽ����/����READGuid�̓���/����READ��߂��܂�</br>
//		/// <br>Programmer : 90027�@�����@��</br>
//		/// <br>Date       : 2005.08.16</br>
//		int Read(ref byte[] DepsitMainWork , ref byte[] DepositAlwWork , byte[] searchParaDepositRead , int readMode);

	}
}
