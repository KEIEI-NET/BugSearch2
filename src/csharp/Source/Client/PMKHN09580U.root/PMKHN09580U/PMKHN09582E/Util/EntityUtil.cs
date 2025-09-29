//****************************************************************************//
// �V�X�e��         : �v�����^�ݒ�}�X�^�i�T�[�o�p�j
// �v���O��������   : �v�����^�ݒ�}�X�^�i�T�[�o�p�j���f��
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/09/16  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;

namespace Broadleaf.Application.UIData.Util
{
    /// <summary>
    /// �G���e�B�e�B���[�e�B���e�B
    /// </summary>
    public static class EntityUtil
    {
        /// <summary>
        /// �폜����Ă��邩���f���܂��B
        /// </summary>
        /// <param name="record">���R�[�h</param>
        /// <returns>
        /// <c>true</c> :�폜����Ă��܂��B<br/>
        /// <c>false</c>:�폜����Ă��܂���B
        /// </returns>
        public static bool Deleted(IRecordHeader record)
        {
            if (record == null) return true;
            return !record.LogicalDeleteCode.Equals(0);
        }

        /// <summary>
        /// �폜����Ă���ꍇ�A�폜�����擾���܂��B
        /// </summary>
        /// <param name="record">���R�[�h</param>
        /// <param name="specialDeletedDate">�폜���𖾎��I�Ɏw�肷��ꍇ�̃p�����[�^</param>
        /// <returns>�X�V���� ���폜����Ă��Ȃ��ꍇ�A<c>string.Empty</c>��Ԃ��܂��B</returns>
        public static string GetDeletedDateIf(
            IRecordHeader record,
            string specialDeletedDate
        )
        {
            if (Deleted(record))
            {
                if (string.IsNullOrEmpty(specialDeletedDate))
                {
                    return record.UpdateDateTime.ToString("yyyy/MM/dd");
                }
                return specialDeletedDate;
            }
            return string.Empty;
        }

        /// <summary>
        /// ���R���ɕϊ����܂��B
        /// </summary>
        /// <param name="numberText">���R���̃e�L�X�g</param>
        /// <returns>���l �����l�Ƃ��Ĉ����Ȃ��ꍇ�A<c>0</c>��Ԃ��܂��B</returns>
        public static int ConvertNaturalNumberIf(string numberText)
        {
            #region <Guard Phrase>

            if (string.IsNullOrEmpty(numberText)) return 0;

            #endregion // </Guard Phrase>

            int naturalNumber = 0;
            if (int.TryParse(numberText.Trim(), out naturalNumber))
            {
                return naturalNumber;
            }
            return 0;
        }
    }
}
