//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �o�i�E�݌Ɉꊇ�X�V
// �v���O�����T�v   : �o�i�E�݌Ɉꊇ�X�V
//----------------------------------------------------------------------------//
//                (c)Copyright  2016 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11270001-00  �쐬�S�� : �v��
// �� �� �� : 2016/01/22   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Resources;
using System.IO;
using Broadleaf.Application.Common;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data;

namespace Broadleaf.Windows.Forms
{
    /// <summary>
    /// �������p�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �������p�N���X�B</br>
    /// <br>Programmer : �v��</br>
    /// <br>Date       : 2016/01/22</br>
    /// </remarks>
    public class PMMAX02010UC
    {
        #region Public Member
        /// <summary>
        /// �ݒ�XML�t�@�C����
        /// </summary>
        public string XML_FILE_NAME = "UISettings_PMMAX02010U.xml";
        #endregion

        #region Private Member
        // ���[�U�[�ݒ胊�X�g
        private ExportSalesData _exportSalesDataList;
        #endregion

        # region �v���p�e�B
        /// <summary>
        /// ���ʂ̃��[�U�[
        /// </summary>
        public ExportSalesData ExportSalesDataList
        {
            get { return _exportSalesDataList; }
            set { _exportSalesDataList = value; }
        }
        # endregion

        #region �R���X�g���N�^
        /// <summary>
        /// PMMAX02010UC�̃R���X�g���N�^
        /// </summary>
        public PMMAX02010UC()
        {

        }
        #endregion

        # region Public Methods
        /// <summary>
        /// �o�i�ꊇ�X�V�p���[�U�[�ݒ�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�i�ꊇ�X�V�p���[�U�[�ݒ�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public void Serialize()
        {
            try
            {
                // �V���A���C�Y����
                UserSettingController.SerializeUserSetting(_exportSalesDataList, Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// �o�i�ꊇ�X�V�p���[�U�[�ݒ�f�V���A���C�Y����
        /// </summary>
        /// <remarks>
        /// <br>Note       : �o�i�ꊇ�X�V�p���[�U�[�ݒ�f�V���A���C�Y����</br>
        /// <br>Programmer : �v��</br>
        /// <br>Date       : 2016/01/22</br>
        /// </remarks>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME))))
            {
                try
                {
                    this._exportSalesDataList = UserSettingController.DeserializeUserSetting<ExportSalesData>(Path.Combine(ConstantManagement_ClientDirectory.NSCurrentDirectory, Path.Combine(ConstantManagement_ClientDirectory.UISettings, XML_FILE_NAME)));

                }
                catch
                {
                    this._exportSalesDataList = new ExportSalesData();
                }
            }
            else
            {
                this._exportSalesDataList = new ExportSalesData();
            }
        }
        # endregion
    }

    #region �o�i�ꊇ�X�V�p���[�U�[�ݒ���N���X(XML�p)
    /// <summary>
    /// �o�i�ꊇ�X�V�p���[�U�[�ݒ���N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�i�ꊇ�X�V�̃��[�U�[�ݒ�����Ǘ����郊�X�g</br>
    /// <br>Programmer : �v��</br>
    /// <br>Date       : 2016/01/22</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ExportSalesData
    {
        private List<ExportSalesFormSaveItems> _exportSalesDataList;

        /// <summary>
        /// 
        /// </summary>
        public List<ExportSalesFormSaveItems> ExportSalesDataList
        {
            get
            {
                if (_exportSalesDataList == null) _exportSalesDataList = new List<ExportSalesFormSaveItems>();
                return _exportSalesDataList;
            }
            set
            {
                _exportSalesDataList = value;
            }
        }
    }

    /// <summary>
    /// �o�i�ꊇ�X�V�p���[�U�[�ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �o�i�ꊇ�X�V�̃��[�U�[�ݒ�����Ǘ�����N���X</br>
    /// <br>Programmer : �v��</br>
    /// <br>Date       : 2016/01/22</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class ExportSalesFormSaveItems
    {
        # region �R���X�g���N�^

        /// <summary>
        /// ���Ӑ�d�q�������[�U�[�ݒ���N���X
        /// </summary>
        public ExportSalesFormSaveItems()
        {

        }

        # endregion // �R���X�g���N�^

        # region �v���C�x�[�g�ϐ�

        // ��ƃR�[�h
        private string _enterPriseCode = "";

        // ���O�C�����_�R�[�h
        private string _loginSectionCode = "";

        // ���iMAX���Ӑ�R�[�h
        private string _maxCustomerCode = "";

        // �q�ɃR�[�h���X�g
        private string _wareCodeList = "";

        // BL�R�[�h
        private string _blCode = "";

        // ���i���[�J�[�R�[�h
        private string _makerCode = "";

        // �����ރR�[�h
        private string _goodsMGroup = "";

        // ���i�|���O���[�v�R�[�h
        private string _rateGrpCode = "";

        // �d����R�[�h
        private string _supplierCd = "";

        // �����������l
        private int _salesRateLow;

        // �̔��P�������l
        private int _salesPriceLow;

        // �`�F�b�N���X�g�o�͑I��
        private int _checkSelect;

        // �`�F�b�N���X�g�o�͐�
        private string _checkFilePath = "";

        # endregion // �v���C�x�[�g�ϐ�

        # region �v���p�e�B

        /// <summary>��ƃR�[�h</summary>
        public string EnterPriseCode
        {
            get { return this._enterPriseCode; }
            set { this._enterPriseCode = value; }
        }

        /// <summary>���O�C�����_�R�[�h</summary>
        public string LoginSectionCode
        {
            get { return this._loginSectionCode; }
            set { this._loginSectionCode = value; }
        }

        /// <summary>���iMAX���Ӑ�R�[�h</summary>
        public string MaxCustomerCode
        {
            get { return this._maxCustomerCode; }
            set { this._maxCustomerCode = value; }
        }

        /// <summary>�q�ɃR�[�h���X�g</summary>
        public string WareCodeList
        {
            get { return this._wareCodeList; }
            set { this._wareCodeList = value; }
        }

        /// <summary>BL�R�[�h</summary>
        public string BlCode
        {
            get { return this._blCode; }
            set { this._blCode = value; }
        }

        /// <summary>���i���[�J�[�R�[�h</summary>
        public string MakerCode
        {
            get { return this._makerCode; }
            set { this._makerCode = value; }
        }

        /// <summary>�����ރR�[�h</summary>
        public string GoodsMGroup
        {
            get { return this._goodsMGroup; }
            set { this._goodsMGroup = value; }
        }

        /// <summary>���i�|���O���[�v�R�[�h</summary>
        public string RateGrpCode
        {
            get { return this._rateGrpCode; }
            set { this._rateGrpCode = value; }
        }

        /// <summary>�d����R�[�h</summary>
        public string SupplierCd
        {
            get { return this._supplierCd; }
            set { this._supplierCd = value; }
        }

        /// <summary>�����������l</summary>
        public int SalesRateLow
        {
            get { return this._salesRateLow; }
            set { this._salesRateLow = value; }
        }

        /// <summary>�̔��P�������l</summary>
        public int SalesPriceLow
        {
            get { return this._salesPriceLow; }
            set { this._salesPriceLow = value; }
        }

        /// <summary>�`�F�b�N���X�g�o�͑I��</summary>
        public int CheckSelect
        {
            get { return this._checkSelect; }
            set { this._checkSelect = value; }
        }

        /// <summary>�`�F�b�N���X�g�o�͐�</summary>
        public string CheckFilePath
        {
            get { return this._checkFilePath; }
            set { this._checkFilePath = value; }
        }

        # endregion
    }
    #endregion
}
