//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : Web�T�[�o�Ƒ���M���鏈���C���^�[�t�F�[�X
// �v���O�����T�v   : Web�T�[�o�Ƒ���M���鏈�����s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2010/05/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// UOE Web�N���C�A���g�C���^�[�t�F�[�X
    /// </summary>
    /// <remarks>
    /// <br>Note		: Web�T�[�o�Ƒ���M���鏈���C���^�[�t�F�[�X</br>
    /// <br>Programmer	: ����</br>
    /// <br>Date		: 2010/05/07</br>
    /// </remarks>
    public interface IUOEWebClient
    {
        /// <summary>
        /// Web�T�[�o�Ƒ���M���܂��B
        /// </summary>
        /// <param name="uoeSendingData">���M�d���f�[�^</param>
        /// <param name="isReceivingStock">�d����M�����t���O</param>
        /// <param name="uoeReceivedData">��M�d���f�[�^</param>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>�������ʃX�e�[�^�X</returns>
        int SendAndReceive(
            UoeSndHed uoeSendingData,
            bool isReceivingStock,
            out UoeRecHed uoeReceivedData,
            out string errorMessage
        );
    }

    /// <summary>
    /// UOE Web�N���C�A���g�̃t�@�N�g���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: UOE Web�N���C�A���g�̃t�@�N�g���N���X</br>
    /// <br>Programmer	: ����</br>
    /// <br>Date		: 2010/05/07</br>
    /// </remarks>
    public static class UOEWebClientFactory
    {
        /// <summary>
        /// UOE Web�N���C�A���g�𐶐����܂��B
        /// </summary>
        /// <param name="uoeSupplier">UOE������</param>
        /// <returns>
        /// <c>EnumUoeConst.ctCommAssemblyId_1004</c>�̏ꍇ�A�����Y�Ƃ�Ԃ��܂��B
        /// (�Y���Ȃ��̏ꍇ�A<c>string.Empty</c>��Ԃ��܂�)
        /// </returns>
        public static IUOEWebClient Create(UOESupplier uoeSupplier)
        {
            switch (uoeSupplier.CommAssemblyId)
            {
                case EnumUoeConst.ctCommAssemblyId_1004:    //�D�ǃ��[�J�[(�����Y��)
                    return new MeijiWebClient(uoeSupplier);
                case EnumUoeConst.ctCommAssemblyId_1003:    //�D�ǃ��[�J�[(��NET)
                    return new NetWebClient(uoeSupplier);
                default:
                    throw new ArgumentException("�D��UOE Web�ł͖��T�|�[�g�̒ʐM�A�Z���u��ID�ł��B");
            }
        }
    }
}
