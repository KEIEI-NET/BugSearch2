using System;
using System.Text;
using System.Threading;
using System.Collections.Generic;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	partial class SFSIR02102UA
	{
		/// <summary>
		/// �N���W�b�g��Ж��̎擾�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note		: �N���W�b�g��Ж��̂��擾����N���X�ł��B</br>
		/// <br>			: �擾���ʂ̓R���X�g���N�^�����̃R�[���o�b�N���\�b�h�ɂĕԂ��܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.18</br>
		/// <br></br>
        /// <br>UpdateNote	: 2007.09.05 �D�c �E�l DC.NS�p�Ƀ��C�A�E�g�ύX ��s���̎擾�N���X�ɕύX����</br>
		/// </remarks>
        // 2007.09.05 hikita upd start ------------------------------------------------->>
        /*
        private class GetCreditCompanyNamePrc  
   		{
			#region Delegate
			/// <summary>���ʂ�Ԃ����߂̃R�[���o�b�N�f���Q�[�g</summary>
			public delegate void Callback(string creditCompanyCode, string creditCompanyName);
   			#endregion

			#region PrivateMember
			// �f���Q�[�g�I�u�W�F�N�g
			private Callback callbackDelegate;
			// �N���W�b�g��Ѓe�[�u���A�N�Z�X�N���X
			private CreditCmpAcs creditCmpAcs;
			// ���擾�p�p�����[�^ ��ƃR�[�h
			private string _enterpriseCode;
			// ���擾�p�p�����[�^ �N���W�b�g��ЃR�[�h
			private string _creditCompanyCode;
			#endregion

			#region Constructor
			/// <summary>
			/// �N���W�b�g��Ж��̎擾�N���X
			/// </summary>
			/// <param name="enterpriseCode">���擾�p�p�����[�^ ��ƃR�[�h</param>
			/// <param name="creditCompanyCode">���擾�p�p�����[�^ �N���W�b�g��ЃR�[�h</param>
			/// <param name="callback">Main���\�b�h�I�����R�[���o�b�N���\�b�h</param>
			/// <remarks>
			/// <br>Note		: �g�p���郁���o�̏��������s���܂��B</br>
			/// <br>Programmer	: 22024 ����@�_�u</br>
			/// <br>Date		: 2006.05.18</br>
			/// </remarks>
			public GetCreditCompanyNamePrc(string enterpriseCode, string creditCompanyCode, Callback callback)
			{
				// �N���W�b�g��Ѓe�[�u���A�N�Z�X�N���X
				this.creditCmpAcs = new CreditCmpAcs();

				// ���擾�p�p�����[�^
				_enterpriseCode = enterpriseCode;
				_creditCompanyCode = creditCompanyCode;

				// �R�[���o�b�N���\�b�h�̃f���Q�[�g�o�^
				callbackDelegate = callback;
			}
			#endregion

			#region PublicMethod
			/// <summary>
			/// ���C������
			/// </summary>
			/// <remarks>
			/// <br>Note		: �N���W�b�g��Ж��̂̎擾���s���܂��B</br>
			/// <br>Programmer	: 22024 ����@�_�u</br>
			/// <br>Date		: 2006.05.18</br>
			/// </remarks>
			public void GetCreditCmpNm()
			{
				try
				{
					// �N���W�b�g��Ў擾
					CreditCmp creditCmp = new CreditCmp();
					int st = creditCmpAcs.Read(out creditCmp, _enterpriseCode, _creditCompanyCode);
					if (st == 0)
					{
						// �R�[���o�b�N�f���Q�[�g�����s���Č��ʂ�Ԃ� �� ���\�b�h�R�[���o�b�N
						if (callbackDelegate != null)
							callbackDelegate(_creditCompanyCode, creditCmp.CreditCompanyName);
					}
					else
					{
						// �R�[���o�b�N�f���Q�[�g�����s���Č��ʂ�Ԃ� �� ���\�b�h�R�[���o�b�N
						if (callbackDelegate != null)
							callbackDelegate("", "");
					}
				}
				catch (ThreadAbortException)
				{
					// �X���b�h���f��
				}
				catch (Exception)
				{
					// ���̑��G���[��  �������������ł͂Ȃ��̂ŁA�G���[�������Ă�����
				}
			}
			#endregion
		}
        */
        private class GetBankNamePrc
        {
            #region Delegate
            /// <summary>���ʂ�Ԃ����߂̃R�[���o�b�N�f���Q�[�g</summary>
            public delegate void Callback(Int32 bankCode, string bankName);
            #endregion

            #region PrivateMember
            // �f���Q�[�g�I�u�W�F�N�g
            private Callback callbackDelegate;
            // ���[�U�[�K�C�h�e�[�u���A�N�Z�X�N���X
            private UserGuideAcs userGuideAcs;
            // ���擾�p�p�����[�^ ��ƃR�[�h
            private string _enterpriseCode;
            // ���擾�p�p�����[�^ ��s�R�[�h
            private Int32 _bankCode;
            #endregion

            #region Constructor
            /// <summary>
            /// ��s���̎擾�N���X
            /// </summary>
            /// <param name="enterpriseCode">���擾�p�p�����[�^ ��ƃR�[�h</param>
            /// <param name="bankCode">���擾�p�p�����[�^ ��s�R�[�h</param>
            /// <param name="callback">Main���\�b�h�I�����R�[���o�b�N���\�b�h</param>
            /// <remarks>
            /// <br>Note		: �g�p���郁���o�̏��������s���܂��B</br>
            /// <br>Programmer	: 20081 �D�c�@�E�l</br>
            /// <br>Date		: 2007.09.05</br>
            /// </remarks>
            public GetBankNamePrc(string enterpriseCode, Int32 bankCode, Callback callback)
            {
                // ���[�U�[�K�C�h�e�[�u���A�N�Z�X�N���X
                this.userGuideAcs = new UserGuideAcs();

                // ���擾�p�p�����[�^
                _enterpriseCode = enterpriseCode;
                _bankCode = bankCode;

                // �R�[���o�b�N���\�b�h�̃f���Q�[�g�o�^
                callbackDelegate = callback;
            }
            #endregion

            #region PublicMethod
            /// <summary>
            /// ���C������
            /// </summary>
            /// <remarks>
            /// <br>Note		: ��s���̂̎擾���s���܂��B</br>
            /// <br>Programmer	: 20081 �D�c�@�E�l</br>
            /// <br>Date		: 2007.09.05</br>
            /// </remarks>
            public void GetBankName()
            {
                try
                {
                    // ��s���擾
                    string guideName = "";

                    int st = userGuideAcs.GetGuideName(out guideName, _enterpriseCode, 46, _bankCode);
                    
                    if (st == 0)
                    {
                        // �R�[���o�b�N�f���Q�[�g�����s���Č��ʂ�Ԃ� �� ���\�b�h�R�[���o�b�N
                        if (callbackDelegate != null)
                            callbackDelegate(_bankCode, guideName);
                    }
                    else
                    {
                        // �R�[���o�b�N�f���Q�[�g�����s���Č��ʂ�Ԃ� �� ���\�b�h�R�[���o�b�N
                        if (callbackDelegate != null)
                            callbackDelegate(0, "");
                    }
                }
                catch (ThreadAbortException)
                {
                    // �X���b�h���f��
                }
                catch (Exception)
                {
                    // ���̑��G���[��  �������������ł͂Ȃ��̂ŁA�G���[�������Ă�����
                }
            }
            #endregion
        }
        // 2007.09.05 hikita upd end ---------------------------------------------------<<
	}
}
