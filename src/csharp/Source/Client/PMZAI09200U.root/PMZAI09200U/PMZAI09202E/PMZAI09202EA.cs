using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ��ʓ��͏����ێ��N���X
    /// </summary>
    public class ExtractInfo
    {
        # region �� Private Field

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>���O�C�����_�R�[�h</summary>
        private string _sectionCode;
        /// <summary>���O�C�����_�K�C�h����</summary>
        private string _sectionGuidNm;

        /// <summary>�\���敪</summary>
        private DisplayDivState _displayDiv;
        /// <summary>�Ώۋ敪</summary>
        private TargetDivState _targetDiv;
        /// <summary>�o�͎w��</summary>
        private OutputDivState _outputDiv;

        /// <summary>���i���[�J�[�R�[�h</summary>
        private int _goodsMakerCd;
        /// <summary>���[�J�[����</summary>
        private string _makerName;
        /// <summary>���i������</summary>
        private int _goodsMGroup;
        /// <summary>���i�����ޖ�</summary>
        private string _goodsMGroupName;
        /// <summary>�q�ɃR�[�h</summary>
        private string _warehouseCode;
        /// <summary>�q�ɖ���</summary>
        private string _warehouseName;
        /// <summary>�i��</summary>
        private string _goodsNo;
        /// <summary>�i��</summary>
        private string _goodsName;
        /// <summary>�a�k�R�[�h</summary>
        private int _blGoodsCode;
        /// <summary>�a�k�R�[�h��</summary>
        private string _blGoodsName;
        /// <summary>�Ǘ����_�R�[�h</summary>
        private string _addUpSectionCode;
        /// <summary>�Ǘ����_�K�C�h����</summary>
        private string _addUpSectionGuidNm;
        /// <summary>���͒S���҃R�[�h</summary>
        private string _stockAgentCode;
        /// <summary>���͒S���Җ���</summary>
        private string _stockAgentName;

        /// <summary>�폜�ς݃f�[�^�\���{�^�����</summary>
        private bool _deleteIndication;

        // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
        /// <summary>�ő�o�͌���</summary>
        private int  _maxCount;
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

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
        /// ���_�R�[�h�v���p�e�B
        /// </summary>
        public string SectionCode
        {
            get { return this._sectionCode; }
            set { this._sectionCode = value; }
        }
        /// <summary>
        /// ���_�K�C�h���̃v���p�e�B
        /// </summary>
        public string SectionGuidNm
        {
            get { return this._sectionGuidNm; }
            set { this._sectionGuidNm = value; }
        }

        /// <summary>
        /// �\���敪�v���p�e�B
        /// </summary>
        public DisplayDivState DisplayDiv
        {
            get { return this._displayDiv; }
            set { this._displayDiv = value; }
        }
        /// <summary>
        /// �Ώۋ敪�v���p�e�B
        /// </summary>
        public TargetDivState TargetDiv
        {
            get { return this._targetDiv; }
            set { this._targetDiv = value; }
        }
        /// <summary>
        /// �o�͎w��v���p�e�B
        /// </summary>
        public OutputDivState OutputDiv
        {
            get { return this._outputDiv; }
            set { this._outputDiv = value; }
        }

        /// <summary>
        /// ���i���[�J�[�R�[�h�v���p�e�B
        /// </summary>
        public int GoodsMakerCd
        {
            get { return this._goodsMakerCd; }
            set { this._goodsMakerCd = value; }
        }
        /// <summary>
        /// ���[�J�[���̃v���p�e�B
        /// </summary>
        public string MakerName
        {
            get { return this._makerName; }
            set { this._makerName = value; }
        }
        /// <summary>
        /// ���i�����ރR�[�h�v���p�e�B
        /// </summary>
        public int GoodsMGroup
        {
            get { return this._goodsMGroup; }
            set { this._goodsMGroup = value; }
        }
        /// <summary>
        /// ���i�����ޖ��̃v���p�e�B
        /// </summary>
        public string GoodsMGroupName
        {
            get { return this._goodsMGroupName; }
            set { this._goodsMGroupName = value; }
        }
        /// <summary>
        /// �q�ɃR�[�h�v���p�e�B
        /// </summary>
        public string WarehouseCode
        {
            get { return this._warehouseCode; }
            set { this._warehouseCode = value; }
        }
        /// <summary>
        /// �q�ɖ��̃v���p�e�B
        /// </summary>
        public string WarehouseName
        {
            get { return this._warehouseName; }
            set { this._warehouseName = value; }
        }
        /// <summary>
        /// �i�ԃv���p�e�B
        /// </summary>
        public string GoodsNo
        {
            get { return this._goodsNo; }
            set { this._goodsNo = value; }
        }
        /// <summary>
        /// �i���v���p�e�B
        /// </summary>
        public string GoodsName
        {
            get { return this._goodsName; }
            set { this._goodsName = value; }
        }
        /// <summary>
        /// BL�R�[�h�v���p�e�B
        /// </summary>
        public int BLGoodsCode
        {
            get { return this._blGoodsCode; }
            set { this._blGoodsCode = value; }
        }
        /// <summary>
        /// BL�R�[�h���̃v���p�e�B
        /// </summary>
        public string BLGoodsName
        {
            get { return this._blGoodsName; }
            set { this._blGoodsName = value; }
        }
        /// <summary>
        /// �Ǘ����_�R�[�h�v���p�e�B
        /// </summary>
        public string AddUpSectionCode
        {
            get { return this._addUpSectionCode; }
            set { this._addUpSectionCode = value; }
        }
        /// <summary>
        /// �Ǘ����_���̃v���p�e�B
        /// </summary>
        public string AddUpSectionGuidNm
        {
            get { return this._addUpSectionGuidNm; }
            set { this._addUpSectionGuidNm = value; }
        }
        /// <summary>
        /// ���͒S���҃R�[�h�v���p�e�B
        /// </summary>
        public string StockAgentCode
        {
            get { return this._stockAgentCode; }
            set { this._stockAgentCode = value; }
        }
        /// <summary>
        /// ���͒S���Җ��̃v���p�e�B
        /// </summary>
        public string StockAgentName
        {
            get { return this._stockAgentName; }
            set { this._stockAgentName = value; }
        }

        /// <summary>
        /// �폜�ς݃f�[�^�\���{�^�����
        /// </summary>
        public bool DeleteIndication
        {
            get { return this._deleteIndication; }
            set { this._deleteIndication = value; }
        }

        // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
        /// <summary>
        /// �ő�o�͌���
        /// </summary>
        public int MaxCount
        {
            get { return this._maxCount; }
            set { this._maxCount = value; }
        }
        // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<
        
        # endregion �� Public Propaty

        #region ���R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public ExtractInfo()
        {
        }
        #endregion

        #region ���񋓑�

        /// <summary>
        /// �\���敪�@�񋓑�
        /// </summary>
        public enum DisplayDivState
        {
            /// <summary>�V�K�o�^</summary>
            New = 0,
            /// <summary>�C���o�^</summary>
            Update = 1,
        }

        /// <summary>
        /// �Ώۋ敪 �񋓑�
        /// </summary>
        public enum TargetDivState
        {
            /// <summary>���i</summary>
            Goods = 0,
            /// <summary>���i-�݌�</summary>
            GoodsStock = 1,
            /// <summary>�݌�-���i</summary>
            StockGoods = 2,
            /// <summary>�݌�</summary>
            Stock = 3,
        }

        /// <summary>
        /// �o�͎w��@�񋓑�
        /// </summary>
        public enum OutputDivState
        {
            /// <summary>�S��</summary>
            All = 0,
            /// <summary>���[�U���i�ݒ蕪</summary>
            UserPrice = 1,
            /// <summary>�����ݒ蕪</summary>
            CostPrice = 2,
        }
        #endregion
    }
}
