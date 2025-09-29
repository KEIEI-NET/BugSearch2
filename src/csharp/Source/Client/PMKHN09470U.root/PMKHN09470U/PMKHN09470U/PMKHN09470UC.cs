//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�i�P�Ǝw��j
// �v���O�����T�v   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�i�P�Ǝw��j�̏������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �� �� ��  2010/09/29  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �|���ݒ�}�X�^�����p�̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer	: �� ��</br>
    /// <br>Date		: 2010/09/29</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RateProtyMngConstruction
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region �� Private Members
        private int _cellMoveValue;

        private const int DEFAULT_CELLMOVE_VALUE = 0;
        # endregion �� Private Members


        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region �� Constructors
        /// <summary>
        /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note        : �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/09/29</br>
        /// </remarks>
        public RateProtyMngConstruction()
        {
            this._cellMoveValue = DEFAULT_CELLMOVE_VALUE;
        }

        /// <summary>
        /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note        : �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: �� ��</br>
        /// <br>Date		: 2010/09/29</br>
        /// </remarks>
        public RateProtyMngConstruction(int cellMoveValue)
        {
            this._cellMoveValue = cellMoveValue;
        }
        # endregion �� Constructors


        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region �� Properties
        /// <summary>�Z���ړ��ݒ�v���p�e�B</summary>
        public int CellMoveValue
        {
            get { return this._cellMoveValue; }
            set { this._cellMoveValue = value; }
        }

        /// <summary>
        /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X��������
        /// </summary>
        /// <returns>�|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X</returns>
        public RateProtyMngConstruction Clone()
        {
            return new RateProtyMngConstruction(this._cellMoveValue);
        }

        # endregion �� Properties
    }
}
