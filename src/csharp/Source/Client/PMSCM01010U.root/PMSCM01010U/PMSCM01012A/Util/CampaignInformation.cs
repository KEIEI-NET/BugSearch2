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
// �� �� ��  2009/05/22  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 杍^
// �C �� ��  2011/08/15  �C�����e : Redmine#23554 �|���}�X�^�̔������ݒ肠��Ŋ��A�L�����y�[���̔����z�ݒ肠��̏ꍇ�A�������̓N���A�̑Ή�
//----------------------------------------------------------------------------//
using System;

using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Util
{
    /// <summary>
    /// �L�����y�[�����N���X
    /// </summary>
    public sealed class CampaignInformation
    {
        #region <�L�����y�[���Ǘ��f�[�^>

        /// <summary>�L�����y�[���Ǘ��f�[�^</summary>
        private CampaignMng _campaignMng;
        /// <summary>�L�����y�[���Ǘ��f�[�^���擾���܂��B</summary>
        private CampaignMng CampaignMng { get { return _campaignMng; } }

        #endregion // </�L�����y�[���Ǘ��f�[�^>

        #region <Constructor>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public CampaignInformation() : this(null) { }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="campaignMng">�L�����y�[���Ǘ��f�[�^</param>
        public CampaignInformation(CampaignMng campaignMng)
        {
            _campaignMng = campaignMng;
        }

        #endregion // </Constructor>

        /// <summary>
        /// �L���t���O���擾���܂��B
        /// </summary>
        public bool Enabled
        {
            get { return CampaignMng != null; }
        }

        /// <summary>
        /// �L�����y�[���R�[�h���擾���܂��B
        /// </summary>
        public int CampaignCode
        {
            get
            {
                if (CampaignMng == null)
                {
                    return 0;
                }
                return CampaignMng.CampaignCode;
            }
        }

        // ADD 2011/08/15 ---- >>>>>
        /// <summary>
        /// �L�����y�[�������擾���܂��B
        /// </summary>
        public double RateVal
        {
            get
            {
                if (CampaignMng == null)
                {
                    return 0;
                }
                return CampaignMng.RateVal;
            }
        }
        // ADD 2011/08/15 ---- <<<<<
    }
}
