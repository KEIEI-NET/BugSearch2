//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : �݌ɗ������݌ɐ��ݒ�f�[�^�N���X
// �v���O�����T�v   : �݌ɗ������݌ɐ��ݒ�f�[�^�N���X���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �����
// �� �� ��  2009/12/24  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 
// �C �� ��              �C�����e : 
//----------------------------------------------------------------------------//

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// �݌ɗ������݌ɐ��ݒ�f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �݌ɗ������݌ɐ��ݒ茟��������񏉊����y�уC���X�^���X�������s���B</br>
    /// <br>Programmer : �����</br>
    /// <br>Date       : 2009/12/24</br>
    /// </remarks>
    public class StockHistoryExtractInfo
    {
        # region �� Private Field

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        /// <summary>�Ώ۔N���J�n</summary>
        private int _addUpYearMonthSt;
        # endregion �� Private Field

        # region �� Public Propaty
        /// <summary>
        /// ��ƃR�[�h�v���p�e�B
        /// </summary>
        public string EnterpriseCode
        {
            get { return this._enterpriseCode; }
            set { this._enterpriseCode = value; }
        }

        /// <summary>
        /// �Ώ۔N���J�n�v���p�e�B
        /// </summary>
        public int AddUpYearMonthSt
        {
            get { return this._addUpYearMonthSt; }
            set { this._addUpYearMonthSt = value; }
        }
        # endregion �� Public Propaty

        #region ���R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public StockHistoryExtractInfo()
        {

        }
        #endregion
    }
}
