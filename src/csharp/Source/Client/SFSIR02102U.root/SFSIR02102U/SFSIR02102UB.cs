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
		/// �x�����z���擾�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note		: �x�����z�����擾����N���X�ł��B</br>
		///	<br>			: �擾���ʂ̓R���X�g���N�^�����̃R�[���o�b�N���\�b�h�ɂĕԂ��܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2006.05.18</br>
		/// <br></br>
		/// <br>UpdateNote	: </br>
		/// </remarks>
		private class GetCustPaymentPrc
		{
			#region Delegate
			/// <summary>���ʂ�Ԃ����߂̃R�[���o�b�N�f���Q�[�g</summary>
			public delegate void Callback(SearchSuplierPayRet searchSuplierPayRet);
			#endregion

			#region PrivateMember
			// �f���Q�[�g�I�u�W�F�N�g
			private Callback callbackDelegate;
			// �x�������A�N�Z�X�N���X
			private PaymentSlpSearch paymentSlpSearch;
			// �d������/�x�����z���擾�p�p�����[�^
			private SearchPaymentParameter parameter;
			#endregion

			#region Constructor
			/// <summary>
			/// �x�����z���擾�N���X(�ʃX���b�h�p)
			/// </summary>
			/// <param name="searchPaymentParameter">�d������/�x�����z���擾�p�p�����[�^</param>
			/// <param name="callback">Main���\�b�h�I�����R�[���o�b�N���\�b�h</param>
			/// <remarks>
			/// <br>Note		: �g�p���郁���o�̏��������s���܂��B</br>
			/// <br>Programmer	: 22024 ����@�_�u</br>
			/// <br>Date		: 2006.05.18</br>
			/// </remarks>
			public GetCustPaymentPrc(SearchPaymentParameter searchPaymentParameter, Callback callback)
			{
				// �x�������A�N�Z�X�N���X
				paymentSlpSearch = new PaymentSlpSearch();

				// ���Ӑ���/���Ӑ���z���擾�p�p�����[�^
				parameter = searchPaymentParameter;

				// �R�[���o�b�N���\�b�h�̃f���Q�[�g�o�^
				callbackDelegate = callback;
			}
			#endregion

			#region PublicMethod
			/// <summary>
			/// ���C������
			/// </summary>
			/// <remarks>
			/// <br>Note		: �x�����z���̎擾���s���܂��B</br>
			/// <br>Programmer	: 22024 ����@�_�u</br>
			/// <br>Date		: 2006.05.18</br>
			/// </remarks>
			public void GetPaymentInfo()
			{
				try
				{
					// �x���֘A�f�[�^�擾�����i�d����R�[�h�w��j
					SearchSuplierPayRet searchSuplierPayRet;
					int st = paymentSlpSearch.ReadCustomPaymentInfo(parameter, out searchSuplierPayRet);
					if (st == 0)
					{
						// �R�[���o�b�N�f���Q�[�g�����s���Č��ʂ�Ԃ�
						if (callbackDelegate != null)
							callbackDelegate(searchSuplierPayRet);
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
	}
}
