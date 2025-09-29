//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : Partsman Product�萔��`�N���X
// �v���O�����T�v   : Partsman Product ���ʒ萔�Ǘ��N���X�ł��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2021 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11601223-00  �쐬�S�� : ���X�ؘj
// �� �� ��  2021/10/12   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Net;

namespace Broadleaf.Application.Resources
{
    /// <summary>
    /// Partsman Product�萔��`�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note		: Partsman Product ���ʒ萔�Ǘ��N���X�ł��B</br>
    /// <br>Programmer	: ���X�ؘj</br>
    /// <br>Date		: 2021/10/12</br>
    /// </remarks>
    public class ConstantManagement_PM_PRO
    {
        #region �� public Members

        /// <summary> �Z�L�����e�B�v���g�R��</summary>
        public enum ScrtyPrtclType : int
        {
              SSL30 = (int)SecurityProtocolType.Ssl3
            , TLS10 = (int)SecurityProtocolType.Tls
            , TLS11 = (int)(SecurityProtocolType)0x00000300
            , TLS12 = (int)(SecurityProtocolType)0x00000C00
        }
        #endregion �� public Members

        # region �� Constructor
        /// <summary>
        /// Partsman Product�萔��`�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : Partsman Product�萔��`�N���X�̐V�����C���X�^���X�𐶐����܂��B</br>
        /// <br>Programmer : ���X�ؘj</br>
        /// <br>Date	   : 2021/10/12</br>
        /// </remarks>
        public ConstantManagement_PM_PRO()
        {
        }
        #endregion �� Constructor

        #region �� Public Methods

        #region �萔��`

        /// <summary> �Z�L�����e�B�v���g�R��</summary>
        public static SecurityProtocolType ScrtyPrtcl
        {
            get
            {
                return (SecurityProtocolType)(
                      ScrtyPrtclType.SSL30
                    | ScrtyPrtclType.TLS10
                    | ScrtyPrtclType.TLS11
                    | ScrtyPrtclType.TLS12
                    );
            }
        }
        #endregion // �萔��`

        #endregion // �� Public Methods

    }
}
