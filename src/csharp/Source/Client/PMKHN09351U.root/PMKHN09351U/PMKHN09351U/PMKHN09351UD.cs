//**********************************************************************//
// �V�X�e��         �F.NS�V���[�Y
// �v���O��������   �F���Ӑ�ꊇ�C��
// �v���O�����T�v   �F���Ӑ�̕ύX���ꊇ�ōs��
// ---------------------------------------------------------------------//
//					Copyright(c) 2008 Broadleaf Co.,Ltd.				//
// =====================================================================//
// ����
// ---------------------------------------------------------------------//
// �Ǘ��ԍ�                 �쐬�S���F30414 �E �K�j
// �C����    2008/11/27     �C�����e�F�V�K�쐬
// ---------------------------------------------------------------------//

using System;
using System.IO;

using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ꊇ�C���p�̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2008/11/20</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class CustomerCustomerChangeConstruction
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
        /// ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public CustomerCustomerChangeConstruction()
        {
            this._cellMoveValue = DEFAULT_CELLMOVE_VALUE;
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X
        /// </summary>
        /// <param name="cellMoveValue">�Z���ړ��ݒ�l</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public CustomerCustomerChangeConstruction(int cellMoveValue)
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
        /// ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X��������
        /// </summary>
        /// <returns>���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X</returns>
        public CustomerCustomerChangeConstruction Clone()
        {
            return new CustomerCustomerChangeConstruction(this._cellMoveValue);
        }

        # endregion �� Properties
    }

    /// <summary>
    /// ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���Ӑ�ꊇ�C���̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2008/11/20</br>
    /// <br>Update Note: </br>
    /// <br>2006.11.27 men �R���X�g���N�^�ɂ�XML�̃p�X���擾����悤�ɉ��ǁi�݌ɕ��i�Ή��j</br>
    /// </remarks>
    public class CustomerCustomerChangeConstructionAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region �� Private Members
        private static CustomerCustomerChangeConstruction _customerSearchConstruction;
        private const string XML_FILE_NAME = "PMKHN09351U_Construction.XML";
        private string _xmlFileName = "";
        # endregion �� Private Members


        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region �� Constructors
        /// <summary>
        /// ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X�A�N�Z�X�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public CustomerCustomerChangeConstructionAcs()
        {
            this._xmlFileName = XML_FILE_NAME;
            if (_customerSearchConstruction == null)
            {
                _customerSearchConstruction = new CustomerCustomerChangeConstruction();
            }
            this.Deserialize();
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X�A�N�Z�X�N���X
        /// </summary>
        /// <param name="xmlFileName">XML�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public CustomerCustomerChangeConstructionAcs(string xmlFileName)
        {
            this._xmlFileName = xmlFileName;
            if (_customerSearchConstruction == null)
            {
                _customerSearchConstruction = new CustomerCustomerChangeConstruction();
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
                if (_customerSearchConstruction == null)
                {
                    _customerSearchConstruction = new CustomerCustomerChangeConstruction();
                }
                return _customerSearchConstruction.CellMoveValue;
            }
            set
            {
                if (_customerSearchConstruction == null)
                {
                    _customerSearchConstruction = new CustomerCustomerChangeConstruction();
                }
                _customerSearchConstruction.CellMoveValue = value;
            }
        }
        # endregion �� Properties


        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region �� Public Methods
        /// <summary>
        /// ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 980079 ��ؐ��b</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_customerSearchConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));

            if (DataChanged != null)
            {
                // �f�[�^�ύX�㔭���C�x���g���s
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���Ӑ�ꊇ�C���p���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 980079 ��ؐ��b</br>
        /// <br>Date       : 2008/11/20</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName)))
            {
                _customerSearchConstruction = UserSettingController.DeserializeUserSetting<CustomerCustomerChangeConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, this._xmlFileName));
            }
        }
        # endregion �� Public Methods
    }
}
