//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �d���`�F�b�N���X�g
// �v���O�����T�v   : �d���`�F�b�N���X�g���[���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �� �� ��  2009/05/10  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��               �C�����e : 
//----------------------------------------------------------------------------//

using System;
using System.IO;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using System.Collections;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_�ϊ��ݒ��ʂ̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2009.05.10</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class SectionCdInputConstruction
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members

        private ArrayList _secCdCSV;
        private ArrayList _secCdPM;

        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public SectionCdInputConstruction()
        {

        }

        /// <summary>
        /// ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public SectionCdInputConstruction(ArrayList aList, ArrayList bList)
        {
            this._secCdCSV = aList;
            this._secCdPM = bList;

        }
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>���͕��@�ݒ�l�v���p�e�B</summary>
        public ArrayList SecCdCSV
        {
            get { return this._secCdCSV; }
            set { this._secCdCSV = value; }
        }
        /// <summary>PM�f�[�^���X�g</summary>
        public ArrayList SecCdPM
        {
            get { return this._secCdPM; }
            set { this._secCdPM = value; }
        }
        # endregion

        /// <summary>
        /// ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X��������
        /// </summary>
        /// <returns>���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X</returns>
        public SectionCdInputConstruction Clone()
        {
            return new SectionCdInputConstruction(this._secCdCSV,this._secCdPM);
        }
    }

    /// <summary>
    /// ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���_�ϊ��ݒ��ʂ̃��[�U�[�ݒ�����Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2009.05.10</br>
    /// <br></br>
    /// </remarks>
    public class SectionCdInputConstructionAcs
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private static SectionCdInputConstruction _sectionCdInputConstruction;
        private const string XML_FILE_NAME = "PMKOU02050U_Construction.XML";
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X�A�N�Z�X�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public SectionCdInputConstructionAcs()
        {
            if (_sectionCdInputConstruction == null)
            {
                _sectionCdInputConstruction = new SectionCdInputConstruction();
            }
            this.Deserialize();
        }
        # endregion

        // ===================================================================================== //
        // �C�x���g
        // ===================================================================================== //
        # region Event
        /// <summary>�f�[�^�ύX�㔭���C�x���g</summary>
        public static event EventHandler DataChanged;
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>���͕��@�ݒ�l�v���p�e�B</summary>
        public ArrayList InputSecCdCSV
        {
            get
            {
                if (_sectionCdInputConstruction == null)
                {
                    _sectionCdInputConstruction = new SectionCdInputConstruction();
                }
                return _sectionCdInputConstruction.SecCdCSV;
            }
            set
            {
                if (_sectionCdInputConstruction == null)
                {
                    _sectionCdInputConstruction = new SectionCdInputConstruction();
                }
                _sectionCdInputConstruction.SecCdCSV = value;
            }
        }
        /// <summary>���͕��@�ݒ�l�v���p�e�B</summary>
        public ArrayList InputSecCdPM
        {
            get
            {
                if (_sectionCdInputConstruction == null)
                {
                    _sectionCdInputConstruction = new SectionCdInputConstruction();
                }
                return _sectionCdInputConstruction.SecCdPM;
            }
            set
            {
                if (_sectionCdInputConstruction == null)
                {
                    _sectionCdInputConstruction = new SectionCdInputConstruction();
                }
                _sectionCdInputConstruction.SecCdPM = value;
            }
        }

        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(_sectionCdInputConstruction, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));

            if (DataChanged != null)
            {
                // �f�[�^�ύX�㔭���C�x���g���s
                DataChanged(this, new EventArgs());
            }
        }

        /// <summary>
        /// ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_�ϊ��ݒ��ʗp���[�U�[�ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : ����</br>
        /// <br>Date       : 2009.05.10</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)))
            {
                _sectionCdInputConstruction = UserSettingController.DeserializeUserSetting<SectionCdInputConstruction>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME));
            }
        }
        # endregion
    }
}
