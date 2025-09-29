//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �|���ݒ�}�X�^�i�|���D��Ǘ��p�^�[���j�i�i�Ԏw��j
// �v���O�����T�v   : �|���ݒ�}�X�^�i�|���D��Ǘ��p�^�[���j�i�i�Ԏw��j�̏������s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���O
// �� �� ��  2010/08/12  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �� ��
// �C �� ��  2010/09/29  �C�����e : Redmine14492�Ή�
//----------------------------------------------------------------------------//

using System;
using System.IO;

using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    // ---DEL 2010/09/29 -------------------->>>
    ///// <summary>
    ///// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X
    ///// </summary>
    ///// <remarks>
    ///// <br>Note        : �|���ݒ�}�X�^�����p�̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    ///// <br>Programmer	: ���O</br>
    ///// <br>Date		: 2010/08/12</br>
    ///// <br></br>
    ///// </remarks>
    //[Serializable]
    //public class RateProtyMngBlCdConstruction
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
    //    /// <br>Programmer	: ���O</br>
    //    /// <br>Date		: 2010/08/12</br>
    //    /// </remarks>
    //    public RateProtyMngBlCdConstruction()
    //    {
    //        this._cellMoveValue = DEFAULT_CELLMOVE_VALUE;
    //    }

    //    /// <summary>
    //    /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X
    //    /// </summary>
    //    /// <remarks>
    //    /// <br>Note        : �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
    //    /// <br>Programmer	: ���O</br>
    //    /// <br>Date		: 2010/08/12</br>
    //    /// </remarks>
    //    public RateProtyMngBlCdConstruction(int cellMoveValue)
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
    //    public RateProtyMngBlCdConstruction Clone()
    //    {
    //        return new RateProtyMngBlCdConstruction(this._cellMoveValue);
    //    }

    //    # endregion �� Properties
    //}
    // ---DEL 2010/09/29 --------------------<<<

    /// <summary>
    /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : �|���ݒ�}�X�^�����̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer	: ���O</br>
    /// <br>Date		: 2010/08/12</br>
    /// </remarks>
    public class RateProtyMngBlCdConstructionAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region �� Private Members
        //private static RateProtyMngBlCdConstruction _rateProtyMngBlCdConstruction; // DEL 2010/09/29
        private static RateProtyMngConstruction _rateProtyMngBlCdConstruction; // ADD 2010/09/29
        //private const string XML_FILE_NAME = "PMKHN09472U_Construction.XML"; // DEL 2010/09/29
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
        /// <br>Programmer	: ���O</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public RateProtyMngBlCdConstructionAcs()
        {
            this._xmlFileName = XML_FILE_NAME;
            if (_rateProtyMngBlCdConstruction == null)
            {
                //_rateProtyMngBlCdConstruction = new RateProtyMngBlCdConstruction(); // DEL 2010/09/29
                _rateProtyMngBlCdConstruction = new RateProtyMngConstruction(); // ADD 2010/09/29
            }
            this.Deserialize();
        }

        /// <summary>
        /// �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�A�N�Z�X�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note        : �|���ݒ�}�X�^�����p���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer	: ���O</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public RateProtyMngBlCdConstructionAcs(string xmlFileName)
        {
            this._xmlFileName = xmlFileName;
            if (_rateProtyMngBlCdConstruction == null)
            {
                //_rateProtyMngBlCdConstruction = new RateProtyMngBlCdConstruction(); // DEL 2010/09/29
                _rateProtyMngBlCdConstruction = new RateProtyMngConstruction(); // ADD 2010/09/29
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
                if (_rateProtyMngBlCdConstruction == null)
                {
                    //_rateProtyMngBlCdConstruction = new RateProtyMngBlCdConstruction(); // DEL 2010/09/29
                    _rateProtyMngBlCdConstruction = new RateProtyMngConstruction(); // ADD 2010/09/29
                }
                return _rateProtyMngBlCdConstruction.CellMoveValue;
            }
            set
            {
                if (_rateProtyMngBlCdConstruction == null)
                {
                    //_rateProtyMngBlCdConstruction = new RateProtyMngBlCdConstruction(); // DEL 2010/09/29
                    _rateProtyMngBlCdConstruction = new RateProtyMngConstruction(); // ADD 2010/09/29
                }
                _rateProtyMngBlCdConstruction.CellMoveValue = value;
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
        /// <br>Programmer	: ���O</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_rateProtyMngBlCdConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));

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
        /// <br>Programmer	: ���O</br>
        /// <br>Date		: 2010/08/12</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)))
            {
                //_rateProtyMngBlCdConstruction = UserSettingController.DeserializeUserSetting<RateProtyMngBlCdConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)); // DEL 2010/09/29
                _rateProtyMngBlCdConstruction = UserSettingController.DeserializeUserSetting<RateProtyMngConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)); // ADD 2010/09/29
            }
        }
        # endregion �� Public Methods
    }
}
