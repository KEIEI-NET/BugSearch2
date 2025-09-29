using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Resources
{
	/// <summary>
	/// .NS �z�M�ē� �萔��`�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : .NS �z�M�ē��̋��ʒ萔��`�N���X�ł��B</br>
	/// <br>Programmer : 23001 �H�R�@����</br>
	/// <br>Date       : 2007.03.07</br>
	/// <br>Update     : 2007.12.06  Kouguchi  �V���C�A�E�g�Ή�</br>
    /// <br></br>
    /// <br>Update Note: 2008.11.19  21024�@���X�� ��</br>
    /// <br>           : PM��ǉ�,�󎚈ʒu�����[�X���폜</br>
    /// </remarks>
	public class ConstantManagement_NS_MGD
	{
		#region << Constructor >>

		/// <summary>
		/// .NS �z�M�ē� �萔��`�N���X�R���X�g���N�^
		/// </summary>
		public ConstantManagement_NS_MGD()
		{
		}

		#endregion



		#region << �z�M�ē��@�V�K�E���ǋ敪 >>

		#region ���z�M�ē��@�V�K�E���ǋ敪

		/// <summary>
		/// �z�M�ē��@�V�K�E���ǋ敪
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		public enum McastGidncNewCustmCd : int 
		{
			/// <summary>
			/// �V�K�ǉ�
			/// </summary>
			NewProgram         = 1,  //0, 
			/// <summary>
			/// ����
			/// </summary>
			Upgrading          = 2,  //1, 
			/// <summary>
			/// ��Q����
			/// </summary>
			BugFix             = 3,  //2,
		}

		#endregion

		#region ���z�M�ē��@�V�K�E���ǋ敪���̎擾����

		/// <summary>
		/// �z�M�ē��@�V�K�E���ǋ敪���̎擾����
		/// </summary>
		/// <param name="mcastGidncNewCustmCd">�z�M�ē��@�V�K�E���ǋ敪</param>
		/// <returns>�z�M�ē��@�V�K�E���ǋ敪����</returns>
		/// <remarks>
		/// <br>Note       : �z�M�ē��@�V�K�E���ǋ敪����z�M�ē��@�V�K�E���ǋ敪���̂̎擾���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		public static string GetMcastGidncNewCustmCdNm( int mcastGidncNewCustmCd )
		{
			string mcastGidncNewCustmCdNm = "";

			switch( mcastGidncNewCustmCd ) {
				// �V�K�ǉ�
				case ( int )McastGidncNewCustmCd.NewProgram:
				{
					mcastGidncNewCustmCdNm = "�V�K";
					break;
				}
				// ����
				case ( int )McastGidncNewCustmCd.Upgrading:
				{
					mcastGidncNewCustmCdNm = "����";
					break;
				}
				// ��Q����
				case ( int )McastGidncNewCustmCd.BugFix:
				{
					mcastGidncNewCustmCdNm = "��Q";
					break;
				}
			}

			return mcastGidncNewCustmCdNm;
		}

		#endregion

		#endregion



		#region << �p�b�P�[�W�敪 >>

		#region ���p�b�P�[�W�敪

		/// <summary>
		/// �p�b�P�[�W�敪
		/// </summary>
		public class ProductCode
		{
            // 2008.11.19 Del >>>
            ///// <summary>
            ///// �����ԃp�b�P�[�W
            ///// </summary>
            //public const string SF = "SuperFrontman";
            // 2008.11.19 Del <<<

            // 2008.11.19 Add >>>
            /// <summary>
            /// �p�[�c�}��
            /// </summary>
            public const string PM = "Partsman";
            // 2008.11.19 Add <<<

			/// <summary>
			/// �p�b�P�[�W�敪���X�g
			/// </summary>
            // 2008.11.19 Update >>>
            //public readonly static string[] ProductCodeList = new string[] { SF };
            public readonly static string[] ProductCodeList = new string[] { PM };
            // 2008.11.19 Update <<<
        }

		#endregion

		#endregion



		#region << �V�X�e���敪 >>

		#region ���V�X�e���敪

		/// <summary>
		/// �V�X�e���敪
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.07</br>
        /// <br></br>
        /// <br>Update Note: 2008.11.19  21024�@���X�� ��</br>
        /// <br>           : PM�p�ɏC��</br>
        /// </remarks>
		public enum SystemDiv : int
		{
			/// <summary>
			/// ����
			/// </summary>
			Common             = 0, 
        }

		#endregion

		#region ���V�X�e���敪���̎擾����

		/// <summary>
		/// �V�X�e���敪���̎擾����
		/// </summary>
		/// <param name="productCode">�p�b�P�[�W�敪</param>
		/// <param name="systemDivCd">�V�X�e���敪</param>
		/// <returns>�V�X�e���敪����</returns>
		/// <remarks>
		/// <br>Note       : �p�b�P�[�W�敪�A�V�X�e���敪����V�X�e���敪���̂̎擾���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.07</br>
        /// <br></br>
        /// <br>Update Note: 2008.11.19  21024�@���X�� ��</br>
        /// <br>           : PM�p�ɏC��</br>
        /// </remarks>
		public static string GetMulticastSystemDivNm( string productCode, int systemDivCd )
		{
			string systemDivNm = "";

			switch( productCode ) {
                // 2008.11.19 Del <<<
                //case ProductCode.SF:
                //{
                //    switch( systemDivCd ) {
                //        case ( int )SystemDiv.Common:
                //        {
                //            systemDivNm = "����";
                //            break;
                //        }
                //        case ( int )SystemDiv.SF:
                //        {
                //            systemDivNm = "����";
                //            break;
                //        }
                //        case ( int )SystemDiv.BK:
                //        {
                //            systemDivNm = "���";
                //            break;
                //        }
                //        case ( int )SystemDiv.CS:
                //        {
                //            systemDivNm = "�Ԕ�";
                //            break;
                //        }
                //    }
                //    break;
                //}
                // 2008.11.19 Del <<<

                // 2008.11.19 Add >>>
                case ProductCode.PM:
                {
                    switch (systemDivCd)
                    {
                        case (int)SystemDiv.Common:
                            systemDivNm = "����";
                            break;
                    }
                    break;
                }
                // 2008.11.19 Add <<<
			}

			return systemDivNm;
		}

		#endregion

		#endregion



		#region << �z�M�ē��@�����e�敪 >>

		#region ���z�M�ē��@�����e�敪

		/// <summary>
		/// �z�M�ē��@�����e�敪
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		public enum MainteDiv : int 
		{
			/// <summary>
			/// ��������e�i���X
			/// </summary>
			Periodic           = 1, 
			/// <summary>
			/// �f�[�^�����e�i���X
			/// </summary>
			Data               = 2, 
			/// <summary>
			/// �ً}�����e�i���X
			/// </summary>
			Emergency          = 9,
		}

		#endregion

		#region ���z�M�ē��@�����e�敪���̎擾����

		/// <summary>
		/// �z�M�ē��@�����e�敪���̎擾����
		/// </summary>
		/// <param name="mainteDivCd">�z�M�ē��@�����e�敪</param>
		/// <returns>�z�M�ē��@�����e�敪����</returns>
		/// <remarks>
		/// <br>Note       : �z�M�ē��@�����e�敪����z�M�ē��@�����e�敪���̂̎擾���s���܂��B</br>
		/// <br>Programmer : 23001 �H�R�@����</br>
		/// <br>Date       : 2007.03.07</br>
		/// </remarks>
		public static string GetServerMainteDivNm( int mainteDivCd )
		{
			string mainteDivNm = "";

			switch( mainteDivCd ) {
				case ( int )MainteDiv.Periodic:
				{
					mainteDivNm = "��������e�i���X";
					break;
				}
				case ( int )MainteDiv.Data:
				{
					mainteDivNm = "�f�[�^�����e�i���X";
					break;
				}
				case ( int )MainteDiv.Emergency:
				{
					mainteDivNm = "�ً}�����e�i���X";
					break;
				}
			}

			return mainteDivNm;
		}

		#endregion

		#endregion



		#region << �z�M�ē��@�ē����e�敪 >>

		#region ���z�M�ē��@�ē����e�敪

		/// <summary>
		/// �z�M�ē��@�ē����e�敪
		/// </summary>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 90027 �����@��</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		public enum McastGidncCntntsCd : int 
		{
			/// <summary>
			/// ����
			/// </summary>
			Common           = 0, 
			/// <summary>
			/// �v���O�����z�M
			/// </summary>
			PgDelivery       = 1, 
			/// <summary>
			/// �T�[�o�[�����e�i���X
			/// </summary>
			SvMaintenance    = 2,
            // 2008.11.19 Del >>>
            ///// <summary>
            ///// �󎚈ʒu�����[�X
            ///// </summary>
            //PrPosition       = 3,
            // 2008.11.19 Del <<<
        }

		#endregion

		#region ���z�M�ē��@�ē����e�敪���̎擾����

		/// <summary>
		/// �z�M�ē��@�ē����e�敪���̎擾����
		/// </summary>
		/// <param name="mcastGidncCntntsCd">�z�M�ē��@�ē����e�敪</param>
		/// <returns>�z�M�ē��@�ē����e�敪����</returns>
		/// <remarks>
		/// <br>Note       : �z�M�ē��@�ē����e�敪����z�M�ē��@�ē����e�敪���̂̎擾���s���܂��B</br>
		/// <br>Programmer : 90027 �����@��</br>
		/// <br>Date       : 2007.12.06</br>
		/// </remarks>
		public static string GetMcastGidncCntntsCdNm( int mcastGidncCntntsCd )
		{
			string mcastGidncCntntsCdNm = "";

			switch( mcastGidncCntntsCd ) {
				case ( int )McastGidncCntntsCd.Common:
				{
					mcastGidncCntntsCdNm = "����";
					break;
				}
				case ( int )McastGidncCntntsCd.PgDelivery:
				{
					mcastGidncCntntsCdNm = "�v���O�����z�M";
					break;
				}
				case ( int )McastGidncCntntsCd.SvMaintenance:
				{
					mcastGidncCntntsCdNm = "�T�[�o�[�����e�i���X";
					break;
				}
                // 2008.11.19 Del >>>
                //case ( int )McastGidncCntntsCd.PrPosition:
                //{
                //    mcastGidncCntntsCdNm = "�󎚈ʒu�����[�X";
                //    break;
                //}
                // 2008.11.19 Del <<<
        }

			return mcastGidncCntntsCdNm;
		}

		#endregion

		#endregion

    }
}
