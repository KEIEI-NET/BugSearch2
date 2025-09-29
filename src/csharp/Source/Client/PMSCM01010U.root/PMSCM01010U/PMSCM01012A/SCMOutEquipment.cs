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
// �� �� ��  2009/08/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// SCM�O���i�N���X
    /// </summary>
    public static class SCMOutEquipment
    {
        /// <summary>
        /// �O���i���菈��
        /// </summary>
        /// <param name="blCode">BL�R�[�h</param>
        /// <returns>true:�O���i false:�O���i�ȊO</returns>
        public static bool CheckOutEquipment(int blCode)
        {
            bool ret = false;

            int[] outEquip = new int[] {
                1102,
                1103,
                1104,
                1105,
                1106,
                1107,
                1108,
                1702,
                2104,
                2204,
                3104,
                3204,
                4102,
                4103,
                4104,
                4105,
                4106,
                4107,
                4108
                // TODO:�O���i��ǉ�����ꍇ�ABL�R�[�h�������ɒǉ�
            };

            ArrayList outEquipList = new ArrayList(outEquip);

            if (outEquipList.Contains(blCode)) ret = true;

            return ret;
        }
    }
}
