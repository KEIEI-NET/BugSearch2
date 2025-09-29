//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �s�a�n���o��
// �v���O�����T�v   : �s�a�n���o��
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270029-00  �쐬�S�� : �͌��с@�ꐶ
// �� �� �� : 2016/05/20   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�J�e�S���ϊ��p�f�[�^���f���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : XML�t�@�C������ǂݍ��񂾃f�[�^���f���N���X</br>
    /// <br>Programmer  : �͌��с@�ꐶ</br>
    /// <br>Date        : 2016/05/20</br>
    /// </remarks>
    [Serializable]
    public class TBOGoodsMGroup
    {
        /// <summary>
        /// ���i�J�e�S��
        /// </summary>
        private string category;
        /// <summary>
        /// ���i������
        /// </summary>
        private string goodsMGroup;

        /// <summary>
        /// ���i�J�e�S��
        /// </summary>
        public string Category
        {
            get { return this.category; }
            set { this.category = value; }
        }
        /// <summary>
        /// ���i������
        /// </summary>
        public string GoodsMGroup
        {
            get { return this.goodsMGroup; }
            set { this.goodsMGroup = value; }
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public TBOGoodsMGroup()
        {
            this.category = String.Empty;
            this.goodsMGroup = String.Empty;
        }

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="category">���i�J�e�S��</param>
        /// <param name="goodsMGroup">���i������</param>
        public TBOGoodsMGroup(string category, string goodsMGroup)
        {
            this.category = category;
            this.goodsMGroup = goodsMGroup;
        }
    }
}
