using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
    //*************************************************************
    // �� ���o���e�[�u�����ɁA��������N���X���`���܂��B
    //    ��������N���X�͓`�[��������C���^�t�F�[�X���������܂��B
    //    ��������N���X�C���X�^���X�́A(�C���^�t�F�[�X�����������)�A
    //    �`�[����m�F�t�h��ShowDialog�Ɉ����Ƃ��ēn�������o���܂��B
    //*************************************************************

    # region �� �`�[��������C���^�t�F�[�X ��
    /// <summary>
    /// �`�[��������C���^�t�F�[�X
    /// </summary>
    public interface ISlipPrintCndtn
    {
        /// <summary>��ƃR�[�h</summary>
        string EnterpriseCode { get;set;}

        /// <summary>�ǉ����</summary>
        ArrayList ExtrData { get;set;}
    }
    # endregion �� �`�[��������C���^�t�F�[�X ��

    # region �� ����`�[������� ��
    /// <summary>
    /// ����`�[��������N���X
    /// </summary>
    public class SalesSlipPrintCndtn : ISlipPrintCndtn
    {
        # region �� �t�B�[���h ��
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�`�[�j�d�x���X�g</summary>
        private List<SalesSlipKey> _salesSlipKeyList;
        /// <summary>�ǉ����</summary>
        private ArrayList _extrData;
        /// <summary>�Ĕ��s�敪</summary>
        private bool _reissueDiv;
        // --- ADD m.suzuki 2010/07/09 ---------->>>>>
        /// <summary>QR�쐬�敪</summary>
        private bool _makeQRDiv;
        // --- ADD m.suzuki 2010/07/09 ----------<<<<<
        //zhouzy add 2011.09.15 add begin
        //���ʒ��[�i�����[�g�`�[�ȊO�j����p�t���O�i0�F����A1�F������Ȃ��j
        int _nomalSalesSlipPrintFlag;
        //�����[�g���[�i�����[�g�`�[�ȊO�j����p�t���O�i0�F����A1�F������Ȃ��j
        int _remoteSalesSlipPrintFlag;
        //�r�b�l���M�t���O
        bool _scmFlg;
        //�r�b�l�S�̐ݒ�̔���`�[����敪
        int _SCMTotalSettingSalesSlipPrtDiv;
        //zhouzy add 2011.09.15 add end
        # endregion �� �t�B�[���h ��

        # region �� �v���p�e�B ��
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// ����`�[�j�d�x���X�g
        /// </summary>
        public List<SalesSlipKey> SalesSlipKeyList
        {
            get { return _salesSlipKeyList; }
            set { _salesSlipKeyList = value; }
        }

        /// <summary>
        /// �ǉ����v���p�e�B�i�\���j
        /// </summary>
        public ArrayList ExtrData
        {
            get { return _extrData; }
            set { _extrData = value; }
        }
        /// <summary>
        /// �Ĕ��s�敪
        /// </summary>
        public bool ReissueDiv
        {
            get { return _reissueDiv; }
            set { _reissueDiv = value; }
        }
        // --- ADD m.suzuki 2010/07/09 ---------->>>>>
        /// <summary>
        /// QR�쐬�敪
        /// </summary>
        public bool MakeQRDiv
        {
            get { return _makeQRDiv; }
            set { _makeQRDiv = value; }
        }
        // --- ADD m.suzuki 2010/07/09 ----------<<<<<
        
        //zhouzy add 2011.09.15 add begin
        /// <summary>
        /// ���ʒ��[�i�����[�g�`�[�ȊO�j����p�t���O
        /// </summary>
        public int NomalSalesSlipPrintFlag
        {
            get { return this._nomalSalesSlipPrintFlag; }
            set { this._nomalSalesSlipPrintFlag = value; }
        }
        /// <summary>
        /// ���ʒ��[�i�����[�g�`�[�ȊO�j����p�t���O
        /// </summary>
        public int RemoteSalesSlipPrintFlag
        {
            get { return this._remoteSalesSlipPrintFlag; }
            set { this._remoteSalesSlipPrintFlag = value; }
        }

        /// <summary>
        /// SCM���M�t���O
        /// </summary>
        public bool ScmFlg
        {
            get { return this._scmFlg; }
            set { _scmFlg = value; }
        }

        /// <summary>
        /// �r�b�l�S�̐ݒ�̔���`�[����敪
        /// </summary>
        public int SCMTotalSettingSalesSlipPrtDiv
        {
            get { return this._SCMTotalSettingSalesSlipPrtDiv; }
            set { _SCMTotalSettingSalesSlipPrtDiv = value; }         
        }
            //zhouzy add 2011.09.15 add end
        # endregion �� �v���p�e�B ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public SalesSlipPrintCndtn()
        {
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="salesSlipKeyList">�`�[�j�d�x���X�g</param>
        /// <param name="extrData">�ǉ����</param>
        public SalesSlipPrintCndtn( string enterpriseCode, List<SalesSlipKey> salesSlipKeyList, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._salesSlipKeyList = salesSlipKeyList;
            this._extrData = extrData;
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� ����`�[�j�d�x ��
        /// <summary>
        /// ����`�[�j�d�x���ځ@�\����
        /// </summary>
        public struct SalesSlipKey
        {
            private int _acptAnOdrStatus;
            private string _salesSlipNum;

            /// <summary>
            /// �󒍃X�e�[�^�X
            /// </summary>
            public int AcptAnOdrStatus
            {
                get { return _acptAnOdrStatus; }
                set { _acptAnOdrStatus = value; }
            }
            /// <summary>
            /// �`�[�ԍ�
            /// </summary>
            public string SalesSlipNum
            {
                get { return _salesSlipNum; }
                set { _salesSlipNum = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="acptAnOdrStatus">�󒍃X�e�[�^�X</param>
            /// <param name="salesSlipNum">�`�[�ԍ�</param>
            public SalesSlipKey( int acptAnOdrStatus, string salesSlipNum )
            {
                this._acptAnOdrStatus = acptAnOdrStatus;
                this._salesSlipNum = salesSlipNum;
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="salesSlip">����`�[</param>
            public SalesSlipKey( SalesSlip salesSlip )
            {
                this._acptAnOdrStatus = salesSlip.AcptAnOdrStatus;
                this._salesSlipNum = salesSlip.SalesSlipNum;
            }

        }
        # endregion �� ����`�[�j�d�x ��
    }
    # endregion �� ����`�[������� ��

    # region �� ���Ϗ�������� ��
    /// <summary>
    /// ���Ϗ���������N���X
    /// </summary>
    public class EstFmPrintCndtn : ISlipPrintCndtn
    {
        # region �� �t�B�[���h ��
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>���Ϗ��P�ʃ��X�g</summary>
        private List<EstFmUnitData> _estFmUnitDataList;
        /// <summary>���Ϗ����l�ݒ�f�[�^</summary>
        private EstimateDefSet _estimateDefSet;
        /// <summary>�ǉ����</summary>
        private ArrayList _extrData;
        # endregion �� �t�B�[���h ��

        # region �� �v���p�e�B ��
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// ���Ϗ��P�ʃf�[�^���X�g
        /// </summary>
        public List<EstFmUnitData> EstFmUnitDataList
        {
            get { return _estFmUnitDataList; }
            set { _estFmUnitDataList = value; }
        }
        /// <summary>
        /// ���Ϗ����l�ݒ�f�[�^
        /// </summary>
        public EstimateDefSet EstimateDefSet
        {
            get { return _estimateDefSet; }
            set { _estimateDefSet = value; }
        }
        /// <summary>
        /// �ǉ����v���p�e�B�i�\���j
        /// </summary>
        public ArrayList ExtrData
        {
            get { return _extrData; }
            set { _extrData = value; }
        }
        # endregion �� �v���p�e�B ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public EstFmPrintCndtn()
        {
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="estFmUnitDataList">�`�[�j�d�x���X�g</param>
        /// <param name="estimateDefSet">���Ϗ����l�ݒ�f�[�^</param>
        /// <param name="extrData">�ǉ����</param>
        public EstFmPrintCndtn( string enterpriseCode, List<EstFmUnitData> estFmUnitDataList, EstimateDefSet estimateDefSet, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._estFmUnitDataList = estFmUnitDataList;
            this._estimateDefSet = estimateDefSet;
            this._extrData = extrData;
        }
        # endregion �� �R���X�g���N�^ ��

        # region [���Ϗ��P�ʃf�[�^]
        /// <summary>
        /// ���Ϗ��P�ʃf�[�^
        /// </summary>
        public class EstFmUnitData
        {
            /// <summary>���Ϗ��w�b�_</summary>
            private FrePEstFmHead _frePEstFmHead;
            /// <summary>���Ϗ����׃��X�g</summary>
            private List<FrePEstFmDetail> _frePEstFmDetailList;
            /// <summary>�������</summary>
            private int _printCount;

            /// <summary>
            /// ���Ϗ��w�b�_�@�v���p�e�B
            /// </summary>
            public FrePEstFmHead FrePEstFmHead
            {
                get { return _frePEstFmHead; }
                set { _frePEstFmHead = value; }
            }
            /// <summary>
            /// ���Ϗ����׃��X�g�@�v���p�e�B
            /// </summary>
            public List<FrePEstFmDetail> FrePEstFmDetailList
            {
                get { return _frePEstFmDetailList; }
                set { _frePEstFmDetailList = value; }
            }
            /// <summary>
            /// ��������@�v���p�e�B
            /// </summary>
            public int PrintCount
            {
                get { return _printCount; }
                set { _printCount = value; }
            }

            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            public EstFmUnitData()
            {
                _printCount = 1; // ��������̏����l�͂P
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="frePEstFmHead">���Ϗ��w�b�_</param>
            /// <param name="frePEstFmDetailList">���Ϗ����׃��X�g</param>
            /// <param name="printCount">�������</param>
            public EstFmUnitData( FrePEstFmHead frePEstFmHead, List<FrePEstFmDetail> frePEstFmDetailList, int printCount )
            {
                _frePEstFmHead = frePEstFmHead;
                _frePEstFmDetailList = frePEstFmDetailList;
                _printCount = printCount;
            }
        }
        # endregion
    }
    # endregion �� ���Ϗ�������� ��

    # region �� �d���`�[������� ��
    /// <summary>
    /// �d���`�[��������N���X
    /// </summary>
    public class StockSlipPrintCndtn : ISlipPrintCndtn
    {
        # region �� �t�B�[���h ��
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�`�[�j�d�x���X�g</summary>
        private List<StockSlipKey> _stockSlipKeyList;
        /// <summary>�ǉ����</summary>
        private ArrayList _extrData;
        # endregion �� �t�B�[���h ��

        # region �� �v���p�e�B ��
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// �d���`�[�j�d�x���X�g
        /// </summary>
        public List<StockSlipKey> StockSlipKeyList
        {
            get { return _stockSlipKeyList; }
            set { _stockSlipKeyList = value; }
        }

        /// <summary>
        /// �ǉ����v���p�e�B�i�\���j
        /// </summary>
        public ArrayList ExtrData
        {
            get { return _extrData; }
            set { _extrData = value; }
        }
        # endregion �� �v���p�e�B ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public StockSlipPrintCndtn()
        {
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="stockSlipKeyList">�`�[�j�d�x���X�g</param>
        /// <param name="extrData">�ǉ����</param>
        public StockSlipPrintCndtn( string enterpriseCode, List<StockSlipKey> stockSlipKeyList, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._stockSlipKeyList = stockSlipKeyList;
            this._extrData = extrData;
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� �d���`�[�j�d�x ��
        /// <summary>
        /// �d���`�[�j�d�x���ځ@�\����
        /// </summary>
        public struct StockSlipKey
        {
            /// <summary>�d���`��</summary>
            private int _supplierFormal;
            /// <summary>�d���`�[�ԍ�</summary>
            private int _supplierSlipNo;

            /// <summary>
            /// �d���`��
            /// </summary>
            public int SupplierFormal
            {
                get { return _supplierFormal; }
                set { _supplierFormal = value; }
            }
            /// <summary>
            /// �d���`�[�ԍ�
            /// </summary>
            public int SupplierSlipNo
            {
                get { return _supplierSlipNo; }
                set { _supplierSlipNo = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="supplierFormal">�󒍃X�e�[�^�X</param>
            /// <param name="supplierSlipNo">�`�[�ԍ�</param>
            public StockSlipKey( int supplierFormal, int supplierSlipNo )
            {
                this._supplierFormal = supplierFormal;
                this._supplierSlipNo = supplierSlipNo;
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="stockSlip">�d���`�[</param>
            public StockSlipKey( StockSlip stockSlip )
            {
                this._supplierFormal = stockSlip.SupplierFormal;
                this._supplierSlipNo = stockSlip.SupplierSlipNo;
            }
        }
        # endregion �� �d���`�[�j�d�x ��
    }
    # endregion �� �d���`�[������� ��

    # region �� �݌Ɉړ��`�[������� ��
    /// <summary>
    /// �݌Ɉړ��`�[��������N���X
    /// </summary>
    public class StockMoveSlipPrintCndtn : ISlipPrintCndtn
    {
        # region �� �t�B�[���h ��
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>�`�[�j�d�x���X�g</summary>
        private List<StockMoveSlipKey> _stockMoveSlipKeyList;
        /// <summary>�ǉ����</summary>
        private ArrayList _extrData;
        /// <summary>�Ĕ��s�敪</summary>
        private bool _reissueDiv;
        # endregion �� �t�B�[���h ��

        # region �� �v���p�e�B ��
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// �݌Ɉړ��`�[�j�d�x���X�g
        /// </summary>
        public List<StockMoveSlipKey> StockMoveSlipKeyList
        {
            get { return _stockMoveSlipKeyList; }
            set { _stockMoveSlipKeyList = value; }
        }

        /// <summary>
        /// �ǉ����v���p�e�B�i�\���j
        /// </summary>
        public ArrayList ExtrData
        {
            get { return _extrData; }
            set { _extrData = value; }
        }
        /// <summary>
        /// �Ĕ��s�敪
        /// </summary>
        public bool ReissueDiv
        {
            get { return _reissueDiv; }
            set { _reissueDiv = value; }
        }
        # endregion �� �v���p�e�B ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public StockMoveSlipPrintCndtn()
        {
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="stockMoveSlipKeyList">�`�[�j�d�x���X�g</param>
        /// <param name="extrData">�ǉ����</param>
        public StockMoveSlipPrintCndtn( string enterpriseCode, List<StockMoveSlipKey> stockMoveSlipKeyList, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._stockMoveSlipKeyList = stockMoveSlipKeyList;
            this._extrData = extrData;
        }
        # endregion �� �R���X�g���N�^ ��

        # region �� �݌Ɉړ��`�[�j�d�x ��
        /// <summary>
        /// �݌Ɉړ��`�[�j�d�x���ځ@�\����
        /// </summary>
        public struct StockMoveSlipKey
        {
            private int _stockMoveFormal;
            private int _stockMoveSlipNo;

            /// <summary>
            /// �݌Ɉړ��`��
            /// </summary>
            public int StockMoveFormal
            {
                get { return _stockMoveFormal; }
                set { _stockMoveFormal = value; }
            }
            /// <summary>
            /// �݌Ɉړ��`�[�ԍ�
            /// </summary>
            public int StockMoveSlipNo
            {
                get { return _stockMoveSlipNo; }
                set { _stockMoveSlipNo = value; }
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="stockMoveFormal">�݌Ɉړ��`��</param>
            /// <param name="stockMoveSlipNo">�݌Ɉړ��`�[�ԍ�</param>
            public StockMoveSlipKey( int stockMoveFormal, int stockMoveSlipNo )
            {
                this._stockMoveFormal = stockMoveFormal;
                this._stockMoveSlipNo = stockMoveSlipNo;
            }
            /// <summary>
            /// �R���X�g���N�^
            /// </summary>
            /// <param name="stockMove">�݌Ɉړ��f�[�^</param>
            public StockMoveSlipKey( StockMove stockMove )
            {
                this._stockMoveFormal = stockMove.StockMoveFormal;
                this._stockMoveSlipNo = stockMove.StockMoveSlipNo;
            }
        }
        # endregion �� �݌Ɉړ��`�[�j�d�x ��
    }
    # endregion �� ����`�[������� ��

    # region �� UOE�`�[������� ��
    /// <summary>
    /// UOE�`�[��������N���X
    /// </summary>
    public class UOESlipPrintCndtn : ISlipPrintCndtn
    {
        # region �� �t�B�[���h ��
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        /// <summary>UOE�`�[�P�ʃ��X�g</summary>
        private List<UoeSales> _uoeSalesList;
        /// <summary>�ǉ����</summary>
        private ArrayList _extrData;
        # endregion �� �t�B�[���h ��

        # region �� �v���p�e�B ��
        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }
        /// <summary>
        /// UOE�`�[�P�ʃf�[�^���X�g
        /// </summary>
        public List<UoeSales> UOESalesList
        {
            get { return _uoeSalesList; }
            set { _uoeSalesList = value; }
        }
        /// <summary>
        /// �ǉ����v���p�e�B�i�\���j
        /// </summary>
        public ArrayList ExtrData
        {
            get { return _extrData; }
            set { _extrData = value; }
        }
        # endregion �� �v���p�e�B ��

        # region �� �R���X�g���N�^ ��
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public UOESlipPrintCndtn()
        {
        }
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="uoeSalesList">�`�[�j�d�x���X�g</param>
        /// <param name="extrData">�ǉ����</param>
        public UOESlipPrintCndtn( string enterpriseCode, List<UoeSales> uoeSalesList, ArrayList extrData )
        {
            this._enterpriseCode = enterpriseCode;
            this._uoeSalesList = uoeSalesList;
            this._extrData = extrData;
        }
        # endregion �� �R���X�g���N�^ ��
    }
    # endregion �� UOE�`�[������� ��

}
