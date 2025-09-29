//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���i�����f�[�^�N���X
// �v���O�����T�v   : ���i�������o�����p�����[�^
//----------------------------------------------------------------------------//
//                (c)Copyright  2018 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� :              �쐬�S�� : 
// �� �� �� : ----/--/--   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� : 11470007-00  �쐬�S�� : 30757 ���X�؁@�M�p
// �� �� �� : 2018/04/05   �C�����e : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Resources;  // 2009/12/16 Add

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�������o�����N���X
    /// </summary>
    /// <remarks>
    /// <br>Update Note	: �_���폜���[�h��ǉ�(MANTIS[0014661])</br>
    /// <br>Programmer	: 21024�@���X�� ��</br>
    /// <br>Date		: 2009/12/17</br>
    /// <br></br>
    /// <br>Update Note  : �������ςŁA�Z�b�g���\�����ɃG���[�ɂȂ錏�̑Ή�(MANTIS[0015177])</br>
    /// <br>               �E�J�X�^���R���X�g���N�^�A�N���[�����\�b�h�̒ǉ�</br>
    /// <br>Programmer   : 21024�@���X�� ��</br>
    /// <br>Date         : 2010/03/19</br>
    /// <br></br>
    /// <br>Update Note  : SCM����</br>
    /// <br>                 BL�R�[�h�}�Ԓǉ�</br>
    /// <br>Programmer   : 22018 ��� ���b</br>
    /// <br>Date         : 2011/05/18</br>
    /// <br>Update Note  : 2018/04/05  30757 ���X�؁@�M�p</br>
    /// <br>�Ǘ��ԍ�     : 11470007-00</br>
    /// <br>             : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
    /// <br>               BL���ꕔ�i�R�[�h�֘A�����o�[�̒ǉ�</br>
    /// </remarks>
    public class PartsSearchUIData
    {
        // ��ƃR�[�h
        private string _enterpriseCode;

        // �i��
        private string _prtsNo = string.Empty;

        ////�n�C�t���Ȃ��i��
        //private string _prtsNoNoneHyphen = string.Empty;

        //�a�k�R�[�h
        private int _tbsPartsCode = 0;

        //���i���[�J�[�R�[�h
        private int _partsMakerCode;

        //�����t���O
        private SearchFlag _searchFlg;

        //�����^�C�v
        private SearchType _searchType;

        // 2009/12/17 Add >>>
        //�_���폜���[�h
        private ConstantManagement.LogicalMode _logicalMode = ConstantManagement.LogicalMode.GetData0;
        // 2009/12/17 Add <<<

        /// <summary>�D�ǐݒ���i�[�o�b�t�@(VALUE:�D�ǐݒ���I�u�W�F�N�g)</summary>
        // 2009.02.12 >>>
        //private Dictionary<PrmSettingKey, PrmSettingUWork> _drPrmSettingWork;
        private List<PrmSettingUWork> _drPrmSettingWork;
        // 2009.02.12 <<<

        /// <summary>���_�R�[�h</summary>
        private string _sectionCode;

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        /// <summary>���i�K�p��</summary>
        private DateTime _priceDate;
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD

        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>BL�R�[�h�}��</summary>
        private Int32 _tbsPartsCdDerivedNo;
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        //��������ݒ�
        private SearchCntSetWork _searchCntSetWork;

        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        /// <summary>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</summary>
        private string _blUtyPtThCd = string.Empty;
        /// <summary>BL���ꕔ�i�T�u�R�[�h</summary>
        private Int32 _blUtyPtSbCd = 0;
        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public PartsSearchUIData()
        {
        }

        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <param name="prtsNo">�i��</param>
        /// <param name="partsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="searchFlag">�����t���O</param>
        /// <param name="searchType">�����^�C�v</param>
        /// <param name="prmSettingUWorkList">�D�ǐݒ胊�X�g</param>
        /// <param name="searchCntSetWork">��������ݒ�</param>
        /// <param name="priceDate">���i�K�p��</param>
        /// <param name="tbsPartsCdDerivedNo">BL�R�[�h�}��</param>
        public PartsSearchUIData( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, string sectionCode, int tbsPartsCode, string prtsNo, int partsMakerCode, SearchFlag searchFlag, SearchType searchType, List<PrmSettingUWork> prmSettingUWorkList, SearchCntSetWork searchCntSetWork, DateTime priceDate, Int32 tbsPartsCdDerivedNo )
        {
            _logicalMode = logicalMode;
            _enterpriseCode = enterpriseCode;
            _sectionCode = sectionCode;
            _tbsPartsCode = tbsPartsCode;
            _tbsPartsCdDerivedNo = tbsPartsCdDerivedNo;
            _prtsNo = prtsNo;
            _partsMakerCode = partsMakerCode;
            _searchFlg = searchFlag;
            _searchType = searchType;
            _priceDate = priceDate;
            _searchCntSetWork = searchCntSetWork.Clone();

            _drPrmSettingWork = new List<PrmSettingUWork>();
        }
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<
        // 2010/03/19 Add >>>
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <param name="prtsNo">�i��</param>
        /// <param name="partsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="searchFlag">�����t���O</param>
        /// <param name="searchType">�����^�C�v</param>
        /// <param name="prmSettingUWorkList">�D�ǐݒ胊�X�g</param>
        /// <param name="searchCntSetWork">��������ݒ�</param>
        /// <param name="priceDate">���i�K�p��</param>
        public PartsSearchUIData(ConstantManagement.LogicalMode logicalMode, string enterpriseCode, string sectionCode, int tbsPartsCode, string prtsNo, int partsMakerCode, SearchFlag searchFlag, SearchType searchType, List<PrmSettingUWork> prmSettingUWorkList, SearchCntSetWork searchCntSetWork, DateTime priceDate)
        {
            _logicalMode = logicalMode;
            _enterpriseCode = enterpriseCode;
            _sectionCode = sectionCode;
            _tbsPartsCode = tbsPartsCode;
            _prtsNo = prtsNo;
            _partsMakerCode = partsMakerCode;
            _searchFlg = searchFlag;
            _searchType = searchType;
            _priceDate = priceDate;
            _searchCntSetWork = searchCntSetWork.Clone();

            // TODO�F�N���[������������
            _drPrmSettingWork = new List<PrmSettingUWork>();
        }

        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="logicalMode">�_���폜���[�h</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <param name="prtsNo">�i��</param>
        /// <param name="partsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="searchFlag">�����t���O</param>
        /// <param name="searchType">�����^�C�v</param>
        /// <param name="prmSettingUWorkList">�D�ǐݒ胊�X�g</param>
        /// <param name="searchCntSetWork">��������ݒ�</param>
        /// <param name="priceDate">���i�K�p��</param>
        /// <param name="tbsPartsCdDerivedNo">BL�R�[�h�}��</param>
        /// <param name="blUtyPtThCdRF">BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</param>
        /// <param name="blUtyPtSbCdRF">BL���ꕔ�i�T�u�R�[�h</param>
        /// <remarks>
        /// <br>Note       : BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�̎擾�Ɛݒ�</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>�Ǘ��ԍ�   : 11470007-00</br>
        /// <br>           : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// </remarks>
        public PartsSearchUIData( ConstantManagement.LogicalMode logicalMode, string enterpriseCode, string sectionCode, int tbsPartsCode, string prtsNo, int partsMakerCode, SearchFlag searchFlag, SearchType searchType, List<PrmSettingUWork> prmSettingUWorkList, SearchCntSetWork searchCntSetWork, DateTime priceDate, Int32 tbsPartsCdDerivedNo, string blUtyPtThCdRF, Int32 blUtyPtSbCdRF )
            : this( logicalMode, enterpriseCode, sectionCode, tbsPartsCode, prtsNo, partsMakerCode, searchFlag, searchType, prmSettingUWorkList, searchCntSetWork, priceDate, tbsPartsCdDerivedNo )
        {
            this._blUtyPtThCd = blUtyPtThCdRF;
            this._blUtyPtSbCd = blUtyPtSbCdRF;
        }
        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<

        /// <summary>
        /// �N���[������
        /// </summary>
        /// <returns></returns>
        public PartsSearchUIData Clone()
        {
            // ----UPD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
            #region #�ߋ��R�[�h
            //// --- UPD m.suzuki 2011/05/18 ---------->>>>>
            ////return new PartsSearchUIData(
            ////    _logicalMode,
            ////    _enterpriseCode,
            ////    _sectionCode,
            ////    _tbsPartsCode,
            ////    _prtsNo,
            ////    _partsMakerCode,
            ////    _searchFlg,
            ////    _searchType,
            ////    _drPrmSettingWork,
            ////    _searchCntSetWork,
            ////    _priceDate);
            //return new PartsSearchUIData(
            //    _logicalMode,
            //    _enterpriseCode,
            //    _sectionCode,
            //    _tbsPartsCode,
            //    _prtsNo,
            //    _partsMakerCode,
            //    _searchFlg,
            //    _searchType,
            //    _drPrmSettingWork,
            //    _searchCntSetWork,
            //    _priceDate,
            //    _tbsPartsCdDerivedNo );
            //// --- UPD m.suzuki 2011/05/18 ----------<<<<<
            #endregion //#�ߋ��R�[�h
            return new PartsSearchUIData(
                  this._logicalMode
                , this._enterpriseCode
                , this._sectionCode
                , this._tbsPartsCode
                , this._prtsNo
                , this._partsMakerCode
                , this._searchFlg
                , this._searchType
                , this._drPrmSettingWork
                , this._searchCntSetWork
                , this._priceDate
                , this._tbsPartsCdDerivedNo
                , this._blUtyPtThCd
                , this._blUtyPtSbCd
                );
            // ----UPD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
        }
        // 2010/03/19 Add <<<

        ///// <summary>
        ///// �n�C�t���Ȃ��i��
        ///// </summary>
        //public string PrtsNoNoneHyphen
        //{
        //    get { return _prtsNoNoneHyphen; }
        //    set { _prtsNoNoneHyphen = value; }
        //}

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// <summary>
        /// �i�� [�n�C�t������E�Ȃ�����]
        /// </summary>
        public string PartsNo
        {
            get { return _prtsNo; }
            set { _prtsNo = value; }
        }

        /// <summary>
        /// �a�k�R�[�h
        /// </summary>
        public int TbsPartsCode
        {
            get { return _tbsPartsCode; }
            set { _tbsPartsCode = value; }
        }

        /// <summary>
        /// ���i���[�J�[�R�[�h
        /// </summary>
        public int PartsMakerCode
        {
            get { return _partsMakerCode; }
            set { _partsMakerCode = value; }
        }

        /// <summary>
        /// �����t���O
        /// </summary>
        public SearchFlag SearchFlg
        {
            get { return _searchFlg; }
            set { _searchFlg = value; }
        }

        /// <summary>
        /// �����^�C�v
        /// </summary>
        public SearchType SearchType
        {
            get { return _searchType; }
            set { _searchType = value; }
        }

        /// <summary>�D�ǐݒ��񃊃X�g</summary>
        // 2009.02.12 >>>
        //public Dictionary<PrmSettingKey, PrmSettingUWork> PrmSettingWork
        public List<PrmSettingUWork> PrmSettingWork
        // 2009.02.12 <<<
        {
            get
            {
                // 2009.02.12 >>>
                //if (_drPrmSettingWork == null)
                //    _drPrmSettingWork = new Dictionary<PrmSettingKey, PrmSettingUWork>();
                if (_drPrmSettingWork == null)
                    _drPrmSettingWork = new List<PrmSettingUWork>();
                // 2009.02.12 <<<
                return _drPrmSettingWork;
            }
            set { _drPrmSettingWork = value; }
        }

        /// <summary>���_�R�[�h[�D�ǐݒ�p:���O�C�����_]</summary>
        public string SectionCode
        {
            get { return _sectionCode; }
            set { _sectionCode = value; }
        }

        /// <summary>
        /// ��������ݒ�
        /// </summary>
        public SearchCntSetWork SearchCntSetWork
        {
            get
            {
                if (_searchCntSetWork != null)
                    return _searchCntSetWork;
                return new SearchCntSetWork();
            }
            set { _searchCntSetWork = value; }
        }

        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2009/03/17 ADD
        /// <summary>
        /// ���i�K�p��
        /// </summary>
        public DateTime PriceDate
        {
            get { return _priceDate; }
            set { _priceDate = value; }
        }
        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2009/03/17 ADD

        // 2009/12/17 Add >>>
        /// <summary>
        /// �_���폜���[�h
        /// </summary>
        public ConstantManagement.LogicalMode LogicalMode
        {
            get { return _logicalMode; }
            set { this._logicalMode = value; }
        }
        // 2009/12/17 Add <<<

        // --- ADD m.suzuki 2011/05/18 ---------->>>>>
        /// <summary>
        /// BL�R�[�h�}��
        /// </summary>
        public Int32 TbsPartsCdDerivedNo
        {
            get { return _tbsPartsCdDerivedNo; }
            set { _tbsPartsCdDerivedNo = value; }
        }
        // --- ADD m.suzuki 2011/05/18 ----------<<<<<

        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j ------->>>>>
        /// <summary>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�p�����[�^</summary>
        /// <value>BL���ꕔ�i�R�[�h(�X���[�R�[�h��)</value>
        /// <remarks>
        /// <br>Note       : BL���ꕔ�i�R�[�h(�X���[�R�[�h��)�̎擾�Ɛݒ�</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>�Ǘ��ԍ�   : 11470007-00</br>
        /// <br>           : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// </remarks>
        public string BlUtyPtThCd
        {
            get { return this._blUtyPtThCd; }
            set { this._blUtyPtThCd = value; }
        }
        /// <summary>BL���ꕔ�i�T�u�R�[�h�p�����[�^</summary>
        /// <value>BL���ꕔ�i�T�u�R�[�h</value>
        /// <remarks>
        /// <br>Note       : BL���ꕔ�i�T�u�R�[�h�̎擾�Ɛݒ�</br>
        /// <br>Programmer : 30757 ���X�؁@�M�p</br>
        /// <br>Date       : 2018/04/05</br>
        /// <br>�Ǘ��ԍ�   : 11470007-00</br>
        /// <br>           : NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j</br>
        /// </remarks>
        public Int32 BlUtyPtSbCd
        {
            get { return this._blUtyPtSbCd; }
            set { this._blUtyPtSbCd = value; }
        }
        // ----ADD 2018/04/05 30757 ���X�؁@�M�p 11470007-00 NS3Ai�Ή��iBL���ꕔ�i�R�[�h�Ή��j -------<<<<<
    }

}
