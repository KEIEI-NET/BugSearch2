//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�i�P�Ǝw��j
// �v���O�����T�v   : �|���ݒ�}�X�^�����i�|���D��Ǘ��p�^�[���j�i�P�Ǝw��j�̏������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �k���r
// �� �� ��  2010/08/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �C �� ��  2010/09/29  �C�����e : Redmine14492�Ή�
//----------------------------------------------------------------------------//

using System;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections.Generic; // ADD 2010/09/29

namespace Broadleaf.Windows.Forms
{
    // ---DEL 2010/09/29 -------------------->>>
    ///// <summary>
    ///// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X
    ///// </summary>
    ///// <remarks>
    ///// <br>Note        : �|���ݒ�}�X�^�����p�̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    ///// <br>Programmer	: �k���r</br>
    ///// <br>Date		: 2010/08/12</br>
    ///// <br></br>
    ///// </remarks>
    //[Serializable]
    //public class RateProtyMngConstruction
    //{
    //    // ===================================================================================== //
    //    // �v���C�x�[�g�ϐ�
    //    // ===================================================================================== //
    //    # region �� Private Members
    //    private int _cellMoveValue;

    //    private const int DEFAULT_CELLMOVE_VALUE = 0;
    //    # endregion �� Private Members


    //    // ===================================================================================== //
    //    // �R���X�g���N�^
    //    // ===================================================================================== //
    //    # region �� Constructors
    //    /// <summary>
    //    /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note        : �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
    //    /// <br>Programmer	: �k���r</br>
    //    /// <br>Date		: 2010/08/12</br>
    //    /// </remarks>
    //    public RateProtyMngConstruction()
    //    {
    //        this._cellMoveValue = DEFAULT_CELLMOVE_VALUE;
    //    }

    //    /// <summary>
    //    /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note        : �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
    //    /// <br>Programmer	: �k���r</br>
    //    /// <br>Date		: 2010/08/12</br>
    //    /// </remarks>
    //    public RateProtyMngConstruction(int cellMoveValue)
    //    {
    //        this._cellMoveValue = cellMoveValue;
    //    }
    //    # endregion �� Constructors


    //    // ===================================================================================== //
    //    // �v���p�e�B
    //    // ===================================================================================== //
    //    # region �� Properties
    //    /// <summary>�Z���ړ��ݒ�v���p�e�B</summary>
    //    public int CellMoveValue
    //    {
    //        get { return this._cellMoveValue; }
    //        set { this._cellMoveValue = value; }
    //    }

    //    /// <summary>
    //    /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X��������
    //    /// </summary>
    //    /// <returns>�|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X</returns>
    //    public RateProtyMngConstruction Clone()
    //    {
    //        return new RateProtyMngConstruction(this._cellMoveValue);
    //    }

    //    # endregion �� Properties
    //}
    // ---DEL 2010/09/29 --------------------<<<

    /// <summary>
    /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �|���ݒ�}�X�^�����̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer	: �k���r</br>
    /// <br>Date		: 2010/08/12</br>
    /// </remarks>
    public class RateProtyMngConstructionAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region �� Private Members
        private static RateProtyMngConstruction _rateProtyMngConstruction;
        //private const string XML_FILE_NAME = "PMKHN09473U_Construction.XML"; // DEL 2010/09/29
        private const string XML_FILE_NAME = "PMKHN09470U_Construction.XML"; // ADD 2010/09/29
        private string _xmlFileName = "";
        # endregion �� Private Members


        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region �� Constructors
        /// <summary>
        /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�A�N�Z�X�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note        : �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public RateProtyMngConstructionAcs()
        {
            this._xmlFileName = XML_FILE_NAME;
            if (_rateProtyMngConstruction == null)
            {
                _rateProtyMngConstruction = new RateProtyMngConstruction();
            }
            this.Deserialize();
        }

        /// <summary>
        /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�A�N�Z�X�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note        : �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public RateProtyMngConstructionAcs(string xmlFileName)
        {
            this._xmlFileName = xmlFileName;
            if (_rateProtyMngConstruction == null)
            {
                _rateProtyMngConstruction = new RateProtyMngConstruction();
            }
            this.Deserialize();
        }
        # endregion �� Constructors


        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        # region �� Event
        /// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
        public static event EventHandler DataChanged;
        # endregion �� Event


        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region �� Properties
        /// <summary>�Z���ړ��ݒ�l�v���p�e�B</summary>
        public int CellMove
        {
            get
            {
                if (_rateProtyMngConstruction == null)
                {
                    _rateProtyMngConstruction = new RateProtyMngConstruction();
                }
                return _rateProtyMngConstruction.CellMoveValue;
            }
            set
            {
                if (_rateProtyMngConstruction == null)
                {
                    _rateProtyMngConstruction = new RateProtyMngConstruction();
                }
                _rateProtyMngConstruction.CellMoveValue = value;
            }
        }
        # endregion �� Properties


        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region �� Public Methods
        /// <summary>
        /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_rateProtyMngConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));

            if (DataChanged != null)
            {
                // �f�[�^�ύX�㔭���C�x���g���s
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note        : �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer	: �k���r</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)))
            {
                _rateProtyMngConstruction = UserSettingController.DeserializeUserSetting<RateProtyMngConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));
            }
        }
        # endregion �� Public Methods
    }
}
