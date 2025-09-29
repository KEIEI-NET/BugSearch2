using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Common;
using System.IO;
using Broadleaf.Application.Resources;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    ///  �|���}�X�^��ʗp���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
    /// <br>Note       : �|���}�X�^��ʂ̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : caohh �A��265</br>
    /// <br>Date       : 2011/08/05</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class RateInputConstruction
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private int _saveInfoDiv;
        private const int DEFAULT_SAVEINFODIV = 0;
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �|���}�X�^��ʗp���[�U�[�ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// <br>Note       : �|���}�X�^��ʗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        public RateInputConstruction()
        {
            this._saveInfoDiv = DEFAULT_SAVEINFODIV;
        }

        /// <summary>
        /// �|���}�X�^��ʗp���[�U�[�ݒ�N���X
		/// </summary>
		/// <remarks>
        /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// <br>Note       : �|���}�X�^��ʗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
		/// </remarks>
        public RateInputConstruction(int saveInfoDiv)
		{
            this._saveInfoDiv = saveInfoDiv;
		}
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�ۑ��O���敪�v���p�e�B</summary>
        public int SaveInfoDiv
        {
            get { return this._saveInfoDiv; }
            set { this._saveInfoDiv = value; }
        }
        # endregion

        /// <summary>
        /// �|���}�X�^��ʗp���[�U�[�ݒ�N���X��������
        /// </summary>
        /// <returns>�|���}�X�^��ʗp���[�U�[�ݒ�N���X</returns>
        public RateInputConstruction Clone()
        {
            return new RateInputConstruction(this._saveInfoDiv);
        }
    }

    /// <summary>
    /// �|���}�X�^��ʗp���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
    /// <br>Note       :�|���}�X�^��ʂ̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : caohh</br>
    /// <br>Date       : 2011/08/05</br>
    /// <br></br>
    /// </remarks>
    public class RateInputConstructionAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private static RateInputConstruction _rateInputConstruction;
        private const string XML_FILE_NAME = "PMKHN09300U_Construction.XML";
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// �|���}�X�^��ʗp���[�U�[�ݒ�N���X�A�N�Z�X�N���X
        /// </summary>
        /// <remarks>
        /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// <br>Note       : �|���}�X�^��ʗp���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        public RateInputConstructionAcs()
        {
            if (_rateInputConstruction == null)
            {
                _rateInputConstruction = new RateInputConstruction();
            }
            this.Deserialize();
        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>�ۑ��O���敪�v���p�e�B</summary>
        public int SaveInfoDiv
        {
            get
            {
                if (_rateInputConstruction == null)
                {
                    _rateInputConstruction = new RateInputConstruction();
                }
                return _rateInputConstruction.SaveInfoDiv;
            }
            set
            {
                if (_rateInputConstruction == null)
                {
                    _rateInputConstruction = new RateInputConstruction();
                }
                _rateInputConstruction.SaveInfoDiv = value;
            }
        }
        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// �|���}�X�^��ʗp���[�U�[�ݒ�N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// <br>Note       : �|���}�X�^��ʗp���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_rateInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
        }

        /// <summary>
        /// �|���}�X�^��ʗp���[�U�[�ݒ�N���X�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>NS���[�U�[���Ǘv�]�ꗗ�A��265�̑Ή�</br>
        /// <br>Note       : �|���}�X�^��ʗp���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : caohh</br>
        /// <br>Date       : 2011/08/05</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                _rateInputConstruction = UserSettingController.DeserializeUserSetting<RateInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
        }
        # endregion
    }
}
