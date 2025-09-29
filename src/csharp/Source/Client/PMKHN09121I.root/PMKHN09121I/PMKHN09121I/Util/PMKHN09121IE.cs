//****************************************************************************//
// �V�X�e��         : �Z�L�����e�B�Ǘ�
// �v���O��������   : ���쌠���ݒ�UI�F���쌠���ݒ�}�X�^
// �v���O�����T�v   : �t�H�[���R���g���[���Ɋւ��鋤�ʏ������������܂��B
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/07/31  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;

using Broadleaf.Application.Controller.Util;

using Infragistics.Win.UltraWinGrid;

namespace Broadleaf.Application.Common.Util
{
    /// <summary>
    /// �t�H�[���R���g���[���̃��[�e�B���e�B
    /// </summary>
    public static class FormControlUtil
    {
        #region <UltraGrid/>

        /// <summary>
        /// �f�[�^�O���b�h�̃J�����̕\����ݒ肵�܂��B
        /// </summary>
        /// <param name="targetGrid">�ݒ肷��f�[�^�O���b�h</param>
        /// <param name="columnIndexAndCaptionThatHiddenIsFalseList">�\������J�����̃C���f�b�N�X�ƃL���v�V�����̃y�A�̃��X�g</param>
        public static void SetDataGridColumnHidden(
            UltraGrid targetGrid,
            IList<Pair<int, string>> columnIndexAndCaptionThatHiddenIsFalseList
        )
        {
            // �o���h���擾
            UltraGridBand band = targetGrid.DisplayLayout.Bands[0];

            // ��̕\���^��\��
            for (int iClm = 0; iClm < band.Columns.Count; iClm++) band.Columns[iClm].Hidden = true;
            foreach (Pair<int, string> enmIndexAndCaption in columnIndexAndCaptionThatHiddenIsFalseList)
            {
                band.Columns[enmIndexAndCaption.First].Hidden = false;

                if (!enmIndexAndCaption.Second.Equals(string.Empty))
                {
                    band.Columns[enmIndexAndCaption.First].Header.Caption = enmIndexAndCaption.Second;
                }
            }
        }

        /// <summary>
        /// �f�[�^�O���b�h�̃J�����̕\������ݒ肵�܂��B
        /// </summary>
        /// <param name="targetGrid">�ݒ肷��f�[�^�O���b�h</param>
        /// <param name="sortedIndexByVisiblePositionList">�\�����Ƀ\�[�g���ꂽ�J�����C���f�b�N�X�̃��X�g</param>
        public static void SetDataGridColumnHeaderVisiblePosition(
            UltraGrid targetGrid,
            IList<Pair<int, string>> sortedIndexByVisiblePositionList
        )
        {
            // �o���h���擾
            UltraGridBand band = targetGrid.DisplayLayout.Bands[0];

            for (int i = 0; i < sortedIndexByVisiblePositionList.Count; i++)
            {
                band.Columns[sortedIndexByVisiblePositionList[i].First].Header.VisiblePosition = i;
            }
        }

        #endregion  // <UltraGrid/>
    }
}
