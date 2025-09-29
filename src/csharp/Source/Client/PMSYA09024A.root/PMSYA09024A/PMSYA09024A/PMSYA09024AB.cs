//****************************************************************************//
// �V�X�e��         : PM.NS
// �v���O��������   : ���q�Ǘ��}�X�^�A�N�Z�X�N���X
// �v���O�����T�v   : ���q�Ǘ��}�X�^�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���w�q
// �� �� ��  2009/09/07  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ����
// �C �� �� 2009/10/10   �C�����e : ��Q��Redmine#537�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���n ���
// �C �� ��  2009/12/24  �C�����e : MANTIS[14822] ���q�Ǘ��}�X�^ �L�[�ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : gaoyh
// �C �� ��  2010/04/27  �C�����e : �󒍃}�X�^�i�ԗ��j���R�����^���Œ�ԍ��z��̒ǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : gaoyh
// �C �� ��  2010/05/20  �C�����e : #7651 ���R�����^���Œ�ԍ��z��NULL�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �{�w�C��
// �C �� �� 2010/12/22   �C�����e : PM1015B�@���q�Ǘ��}�X�^�̎��R�����^���Œ�ԍ��z����R�s�[����悤�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10704766-00  �쐬�S�� : wangf
// �C �� �� 2011/08/02   �C�����e : PM1107C�@NS���[�U�[���Ǘv�]�ꗗ_PM7����_�A��895�ɏC��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10801804-00  �쐬�S�� : �e�c ���V
// �C �� �� 2012/09/18   �C�����e : �@���q�Ǘ��}�X�^��������A����̃f�[�^��ҏW���悤�Ƃ���ƃt���[�Y���Ă��܂����̏C��
//                                : �A���q�Ǘ��}�X�^���G���[�ŕۑ��ł��Ȃ��Ȃ錏�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ� 10900269-00  �쐬�S�� : FSI���� ����
// �C �� �� 2013/03/22   �C�����e : SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30744 ���� ����q
// �C �� �� 2013/04/19   �C�����e : SCM��Q��10521�Ή� �߂�l�ɓo�^�ԍ�����ǉ�����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070091-00 �쐬�S�� : 杍^
// �C �� ��  2014/08/01  �C�����e : �S�̏����l�ݒ�}�X�^�f�[�^�擾��Q���C��
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;  // Add 2010/04/27
using System.IO;  // Add 2010/04/27

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���q�Ǘ��}�X�^�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���q�Ǘ��}�X�^�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : ���w�q</br>
    /// <br>Date       : 2009/09/07</br>
    /// <br>Update Note : ���� 2009.10.10</br>
    /// <br>            : ��Q��Redmine#537�̏C��</br>
    /// <br>Update Note : wangf 2011/08/02</br>
    /// <br>            : PM1107C�@NS���[�U�[���Ǘv�]�ꗗ_PM7����_�A��895�ɏC��</br>
    /// <br>Update Note : 2013/03/22 FSI���� ����</br>
    /// <br>            : SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
    /// </remarks>
    public class CarMngInputAcs : IGeneralGuideData
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        private static CarMngInputAcs _carMngInputAcs;
        private AllDefSet _allDefSet;
        private Dictionary<Guid, PMKEN01010E.ColorCdInfoDataTable> _colorInfoDic;       // �J���[���
        private Dictionary<Guid, PMKEN01010E.TrimCdInfoDataTable> _trimInfoDic;         // �g�������
        private Dictionary<Guid, PMKEN01010E.CEqpDefDspInfoDataTable> _cEqpDspInfoDic;  // �������
        private string _ownSectionCode = "";
        private string _ownSectionName = "";
        private static SecInfoAcs _secInfoAcs;											// ���_�A�N�Z�X�N���X
        private string _enterpriseCode;
        private string _loginSectionCode;
        private CarSearchController _carSearchController;
        private GoodsAcs _goodsAcs;
        private IWin32Window _owner = null;
        private List<MakerUMnt> _makerUMntList = null;         // ���[�J�[�}�X�^���X�g
        private ModelNameUAcs _modelNameUAcs;
        private ICarManagementDB _iCarManagementDB;
        private PMKEN01010E.CarModelInfoDataTable _carInfo; // ADD 2013/03/22
        private int _handleInfoCode; // ADD 2013/03/22
        # endregion

        # region �萔
        /// <summary>���_�R�[�h(�S��)</summary>
        public const string ctSectionCode = "00";
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";

        // �K�C�h���ږ�
        # region [�K�C�h����]
        private const string GUIDE_ENTERPRISECODE_TITLE = "EnterpriseCode"; // ��ƃR�[�h
        private const string GUIDE_CARMNGCODE_TITLE = "CarMngCode"; // �Ǘ��ԍ�
        private const string GUIDE_MODELFULLNAME_TITLE = "ModelFullName"; // �Ԏ�
        private const string GUIDE_FULLMODEL_TITLE = "FullModel"; // �^��
        private const string GUIDE_FRAMENO_TITLE = "FrameNo"; // �ԑ�ԍ�
        private const string GUIDE_NUMBERPLATEFORGUIDE_TITLE = "NumberPlateForGuide"; // �o�^�ԍ�
        private const string GUIDE_CUSTOMERCODE_TITLE = "CustomerCode"; // ���Ӑ�R�[�h
        private const string GUIDE_CUSTOMERCODEFORGUIDE_TITLE = "CustomerCodeForGuide"; // ���Ӑ�Guide
        private const string GUIDE_CUSTOMERNAME_TITLE = "CustomerName"; // ���Ӑ於
        private const string GUIDE_CARMNGNO_TITLE = "CarMngNo"; // ���q�Ǘ��ԍ�
        // -- add wangf 2011/08/02 ---------->>>>>
        private const string GUIDE_CARNOTE_TITLE = "CarNote"; // ���q���l
        // -- add wangf 2011/08/02 ----------<<<<<
        // ADD 2013/04/19 SCM��Q��10521�Ή� -------------------------------------->>>>>
        private const string GUIDE_NUMBERPLATE1CODE_TITLE = "NumberPlate1Code"; // ���^�����Ǔo�^�ԍ�
        private const string GUIDE_NUMBERPLATE1NAME_TITLE = "NumberPlate1Name"; // ���^�����ǖ���
        private const string GUIDE_NUMBERPLATE2_TITLE = "NumberPlate2"; // �ԗ��o�^�ԍ��i��ʁj
        private const string GUIDE_NUMBERPLATE3_TITLE = "NumberPlate3"; // �ԗ��o�^�ԍ��i�J�i�j
        private const string GUIDE_NUMBERPLATE4_TITLE = "NumberPlate4"; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
        // ADD 2013/04/19 SCM��Q��10521�Ή� --------------------------------------<<<<<
        # endregion
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        /// <summary>
        /// �����_�R�[�h�v���p�e�B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����_�R�[�h�v���p�e�B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string OwnSectionCode
        {
            get
            {
                if (this._ownSectionCode == "")
                {
                    return this.GetOwnSectionCode();
                }
                else
                {
                    return this._ownSectionCode;
                }
            }
        }

        /// <summary>
        /// �����_���̃v���p�e�B
        /// </summary>
        /// <remarks>
        /// <br>Note       : �����_���̃v���p�e�B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string OwnSectionName
        {
            get
            {
                if (this._ownSectionName == "")
                {
                    return this.GetOwnSectionName();
                }
                else
                {
                    return this._ownSectionName;
                }
            }
        }
        # endregion

        // ===================================================================================== //
        // �񋓑�
        // ===================================================================================== //
        # region Enums
        /// <summary>
        /// �ԗ��������[�h
        /// </summary>
        /// <remarks>
        /// <br>Note       : �ԗ��������[�h�̗񋓑�</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public enum SearchCarMode : int
        {
            /// <summary>�^������</summary>
            FullModelSearch = 1,
            /// <summary>���f���v���[�g����</summary>
            ModelPlateSearch = 2,
        }
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region �R���X�g���N�^
        /// <summary>
        /// ���q�Ǘ��}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��}�X�^�A�N�Z�X�N���X�R���X�g���N�^�����������܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public CarMngInputAcs()
        {
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            this._colorInfoDic = new Dictionary<Guid, PMKEN01010E.ColorCdInfoDataTable>();
            this._trimInfoDic = new Dictionary<Guid, PMKEN01010E.TrimCdInfoDataTable>();
            this._cEqpDspInfoDic = new Dictionary<Guid, PMKEN01010E.CEqpDefDspInfoDataTable>();
            this._carSearchController = new CarSearchController();
            this._modelNameUAcs = new ModelNameUAcs();
            this._iCarManagementDB = MediationCarManagementDB.GetCarManagementDB();
        }

        /// <summary>
        /// ���q�Ǘ��}�X�^�A�N�Z�X�N���X�̃C���X�^���X�擾����
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��}�X�^�A�N�Z�X�N���X�̃C���X�^���X�擾�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public static CarMngInputAcs GetInstance()
        {
            if (_carMngInputAcs == null)
            {
                _carMngInputAcs = new CarMngInputAcs();
            }

            return _carMngInputAcs;
        }

        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// �S�̏����l�ݒ�}�X�^��������
        /// </summary>
        /// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : �S�̏����l�ݒ�}�X�^�����������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public AllDefSet GetAllDefSet()
        {
            return this._allDefSet;
        }

        /// <summary>
        /// ���q�Ǘ��}�X�^�f�[�^���͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="sectionCode">���_�R�[�h</param>
		/// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��}�X�^�f�[�^���͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int ReadInitData(string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;  // ADD 2014/08/01 杍^ Redmine#43125

            // �S�̏����l�ݒ�}�X�^
            if (this._allDefSet == null) // ADD 2014/08/01 杍^ Redmine#43125
            {
                AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
                AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                ArrayList retAllDefSetList;
                //int status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode); // DEL 2014/08/01 杍^ Redmine#43125
                status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode); // ADD 2014/08/01 杍^ Redmine#43125
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
                }
                else
                {
                    this._allDefSet = null;
                }
            }

            // ���i�A�N�Z�X�N���X��������
            string retMessage;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = false;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);

            // ���[�J�[�}�X�^
            List<MakerUMnt> makerList;
            status = this._goodsAcs.GetAllMaker(enterpriseCode, out makerList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (makerList != null) this._makerUMntList = makerList;
            }
            return status;
        }

        // ---------- ADD 2014/08/01 杍^ Redmine#43125 --------- >>>
        /// <summary>
        /// �S�̏����l�ݒ�}�X�^���c�a���擾���܂��B
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �S�̏����l�ݒ�}�X�^�f�[�^���c�a���擾���܂��B</br>
        /// <br>Programmer : 杍^</br>
        /// <br>Date       : 2014/08/01</br>
        /// </remarks>
        public int ReadAllDefSetData(string enterpriseCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            if (this._allDefSet == null)
            {
                // �S�̏����l�ݒ�}�X�^
                AllDefSetAcs allDefSetAcs = new AllDefSetAcs();
                AllDefSetAcs.SearchMode allDefSetSearchMode = AllDefSetAcs.SearchMode.Remote;
                ArrayList retAllDefSetList;
                status = allDefSetAcs.Search(out retAllDefSetList, enterpriseCode, allDefSetSearchMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    this._allDefSet = this.GetAllDefSetFromList(LoginInfoAcquisition.Employee.BelongSectionCode, retAllDefSetList);
                }
                else
                {
                    this._allDefSet = null;
                }
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }
        // ---------- ADD 2014/08/01 杍^ Redmine#43125 --------- <<<

        /// <summary>
        /// �I���J���[���擾����
        /// </summary>
        /// <param name="carRelationGuid">���q��񋤒ʃL�[</param>
        /// <returns>�J���[���s�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : �I���J���[���擾�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMKEN01010E.ColorCdInfoRow GetSelectColorInfo(Guid carRelationGuid)
        {
            PMKEN01010E.ColorCdInfoRow colorInfoRow = null;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = this._colorInfoDic[carRelationGuid];
                PMKEN01010E.ColorCdInfoRow[] rows = (PMKEN01010E.ColorCdInfoRow[])colorInfoDataTable.Select(string.Format("{0}={1}", colorInfoDataTable.SelectionStateColumn.ColumnName, true));
                if (rows.Length > 0) colorInfoRow = rows[0];
            }
            return colorInfoRow;
        }

        /// <summary>
        /// �I���g�������擾����
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <returns>�g�������s�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : �I���g�������擾�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMKEN01010E.TrimCdInfoRow GetSelectTrimInfo(Guid carRelationGuid)
        {
            PMKEN01010E.TrimCdInfoRow trimInfoRow = null;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = this._trimInfoDic[carRelationGuid];
                PMKEN01010E.TrimCdInfoRow[] rows = (PMKEN01010E.TrimCdInfoRow[])trimInfoDataTable.Select(string.Format("{0}={1}", trimInfoDataTable.SelectionStateColumn.ColumnName, true));
                if (rows.Length > 0) trimInfoRow = rows[0];
            }
            return trimInfoRow;
        }

        /// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X����������
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���_����A�N�Z�X�N���X�C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs((int)SecInfoAcs.SearchMode.Remote);
            }

            // ���O�C���S�����_���̎擾
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        /// <summary>
        /// �ԗ����L���b�V���i�J���[�A�g�����A�������j
        /// </summary>
        /// <param name="extraInfo">�ԗ����s�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �ԗ����L���b�V���i�J���[�A�g�����A�������j���s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void CacheCarOtherInfo(ref CarMangInputExtraInfo extraInfo)
        {
            // �ԗ��Č���
            PMKEN01010E carInfoDataset = new PMKEN01010E();
            // --- UPD 2012/09/18 Y.Wakita ---------->>>>>
            //CarSearchResultReport result = this.SearchCar(extraInfo.FullModelFixedNoAry, extraInfo.ModelDesignationNo, extraInfo.CategoryNo, ref carInfoDataset);
            CarSearchResultReport result = this.SearchCar(extraInfo, ref carInfoDataset);
            // --- UPD 2012/09/18 Y.Wakita ----------<<<<<
            if ((result != CarSearchResultReport.retError) && (result != CarSearchResultReport.retFailed))
            {
                //this.CacheCarInfo(ref extraInfo, carInfoDataset);
       
                this.CacheColorInfo(extraInfo, carInfoDataset.ColorCdInfo);                         // �J���[���
                this.CacheTrimInfo(extraInfo, carInfoDataset.TrimCdInfo);                           // �g�������
                this.CacheEquipInfo(extraInfo, carInfoDataset.CEqpDefDspInfo);                      // �������
            }
        }

        // --- ADD 2012/09/18 Y.Wakita ---------->>>>>
        /// <summary>
        /// �ԗ�����(�t���^���Œ�ԍ���茟��)
        /// </summary>
        /// <param name="extraInfo">�ԗ����s�I�u�W�F�N�g</param>
        /// <param name="carInfoDataSet">�ԗ������f�[�^�Z�b�g</param>
        /// <returns>CarSearchResultReport</returns>
        /// <remarks>�^���w��ԍ�����їޕʋ敪�ԍ��́A�ޕʌ����ɂ��t���^���Œ�ԍ��z��̏ꍇ�̂ݕK�{</remarks>
        /// <remarks>
        /// <br>Note       : �ԗ�����(�t���^���Œ�ԍ���茟��)���s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public CarSearchResultReport SearchCar(CarMangInputExtraInfo extraInfo, ref PMKEN01010E carInfoDataSet)
        {
            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            if (extraInfo.FullModelFixedNoAry.Length != 0 && extraInfo.FullModelFixedNoAry[0] != 0)
            {
                ret = this._carSearchController.SearchByFullModelFixedNo(extraInfo, ref carInfoDataSet);
            }
            return ret;
        }
        // --- ADD 2012/09/18 Y.Wakita ----------<<<<<

        /// <summary>
        /// �ԗ�����(�t���^���Œ�ԍ���茟��)
        /// </summary>
        /// <param name="fullModelFixedNo">�t���^���Œ�ԍ��z��</param>
        /// <param name="modelDesignationNo">�^���w��ԍ�(���ݒ��)</param>
        /// <param name="categoryNo">�ޕʋ敪�ԍ�(���ݒ��)</param>
        /// <param name="carInfoDataSet">�ԗ������f�[�^�Z�b�g</param>
        /// <returns>CarSearchResultReport</returns>
        /// <remarks>�^���w��ԍ�����їޕʋ敪�ԍ��́A�ޕʌ����ɂ��t���^���Œ�ԍ��z��̏ꍇ�̂ݕK�{</remarks>
        /// <remarks>
        /// <br>Note       : �ԗ�����(�t���^���Œ�ԍ���茟��)���s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public CarSearchResultReport SearchCar(int[] fullModelFixedNo, int modelDesignationNo, int categoryNo, ref PMKEN01010E carInfoDataSet)
        {
            CarSearchResultReport ret = CarSearchResultReport.retFailed;
            if (fullModelFixedNo.Length != 0 && fullModelFixedNo[0] != 0)
            {
                ret = this._carSearchController.SearchByFullModelFixedNo(fullModelFixedNo, modelDesignationNo, categoryNo, ref carInfoDataSet);
            }
            return ret;
        }

        /// <summary>
        /// ���q����(���q�������o������茟��)
        /// </summary>
        /// <param name="carSearchCondition">���q�������o����</param>
        /// <param name="carInfoDataSet">���q�����f�[�^�Z�b�g</param>
        /// <returns>CarSearchResultReport</returns>
        /// <remarks>
        /// <br>Note       : ���q����(���q�������o������茟��)���s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public CarSearchResultReport SearchCar(CarSearchCondition carSearchCondition, ref PMKEN01010E carInfoDataSet)
        {
            return this._carSearchController.Search(carSearchCondition, ref carInfoDataSet);
        }

        /// <summary>
        /// �ԗ����L���b�V���i�ԗ�������񂩂�L���b�V���j
        /// </summary>
        /// <param name="extraInfo">�ԗ����s�I�u�W�F�N�g</param>
        /// <param name="searchCarInfo">�ԗ��������ʃN���X</param>
        /// <remarks>
        /// <br>Note       : �ԗ����L���b�V���i�ԗ�������񂩂�L���b�V���j���s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note: 2013/03/22 FSI���� ����</br>
        /// <br>�Ǘ��ԍ�   : 10900269-00</br>
        /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// </remarks>
        public void CacheCarInfo(ref CarMangInputExtraInfo extraInfo, PMKEN01010E searchCarInfo)
        {
            PMKEN01010E.CarModelUIDataTable carModelUIDataTable = searchCarInfo.CarModelUIData; // �t�h�p�^�����e�[�u��
            PMKEN01010E.CarModelInfoDataTable carModelInfoDataTable = searchCarInfo.CarModelInfoSummarized; // �^�����v��e�[�u��

            extraInfo.CarRelationGuid = Guid.Empty;
            extraInfo.MakerCode = carModelInfoDataTable[0].MakerCode; // ���[�J�[�R�[�h
            extraInfo.MakerFullName = carModelInfoDataTable[0].MakerFullName; // ���[�J�[�S�p����
            extraInfo.MakerHalfName = carModelInfoDataTable[0].MakerHalfName; // ���[�J�[���p����
            extraInfo.ModelCode = carModelInfoDataTable[0].ModelCode; // �Ԏ�R�[�h
            extraInfo.ModelSubCode = carModelInfoDataTable[0].ModelSubCode; // �Ԏ�T�u�R�[�h
            extraInfo.ModelFullName = carModelInfoDataTable[0].ModelFullName; // �Ԏ�S�p����
            if (extraInfo.ModelFullName.Length > 15) extraInfo.ModelFullName = extraInfo.ModelFullName.Substring(0, 15);
            extraInfo.ModelHalfName = carModelInfoDataTable[0].ModelHalfName; // �Ԏ피�p����
            if (extraInfo.ModelHalfName.Length > 15) extraInfo.ModelHalfName = extraInfo.ModelHalfName.Substring(0, 15);
            extraInfo.SystematicCode = carModelInfoDataTable[0].SystematicCode; // �n���R�[�h
            extraInfo.SystematicName = carModelInfoDataTable[0].SystematicName; // �n������
            extraInfo.ProduceTypeOfYearCd = carModelInfoDataTable[0].ProduceTypeOfYearCd; // ���Y�N���R�[�h
            extraInfo.ProduceTypeOfYearNm = carModelInfoDataTable[0].ProduceTypeOfYearNm; // ���Y�N������
            DateTime sdt;
            DateTime edt;
            int iyy = carModelInfoDataTable[0].StProduceTypeOfYear / 100;
            int imm = carModelInfoDataTable[0].StProduceTypeOfYear % 100;
            if ((iyy == 9999) || (imm == 99))
            {
                sdt = DateTime.MinValue;
            }
            else
            {
                sdt = new DateTime(iyy, imm, 1);
            }
            iyy = carModelInfoDataTable[0].EdProduceTypeOfYear / 100;
            imm = carModelInfoDataTable[0].EdProduceTypeOfYear % 100;
            if ((iyy == 9999) || (imm == 99))
            {
                edt = DateTime.MinValue;
            }
            else
            {
                edt = new DateTime(iyy, imm, 1);
            }
            extraInfo.StProduceTypeOfYear = sdt; // �J�n���Y�N��
            extraInfo.EdProduceTypeOfYear = edt; // �I�����Y�N��
            extraInfo.ProduceTypeOfYearInput = carModelUIDataTable[0].ProduceTypeOfYearInput; // ���Y�N������
            extraInfo.DoorCount = carModelInfoDataTable[0].DoorCount; // �h�A��
            extraInfo.BodyNameCode = carModelInfoDataTable[0].BodyNameCode; // �{�f�B�[���R�[�h
            extraInfo.BodyName = carModelInfoDataTable[0].BodyName; // �{�f�B�[����
            extraInfo.ExhaustGasSign = carModelInfoDataTable[0].ExhaustGasSign; // �r�K�X�L��
            extraInfo.SeriesModel = carModelInfoDataTable[0].SeriesModel; // �V���[�Y�^��
            extraInfo.CategorySignModel = carModelInfoDataTable[0].CategorySignModel; // �^���i�ޕʋL���j
            extraInfo.FullModel = carModelInfoDataTable[0].FullModel; // �^���i�t���^�j
            extraInfo.ModelDesignationNo = carModelUIDataTable[0].ModelDesignationNo; // �^���w��ԍ�
            extraInfo.CategoryNo = carModelUIDataTable[0].CategoryNo; // �ޕʔԍ�
            extraInfo.FrameModel = carModelInfoDataTable[0].FrameModel; // �ԑ�^��
            extraInfo.FrameNo = carModelUIDataTable[0].FrameNo; // �ԑ�ԍ�
            extraInfo.SearchFrameNo = carModelUIDataTable[0].SearchFrameNo; // �ԑ�ԍ��i�����p�j
            extraInfo.StProduceFrameNo = carModelInfoDataTable[0].StProduceFrameNo; // ���Y�ԑ�ԍ��J�n
            extraInfo.EdProduceFrameNo = carModelInfoDataTable[0].EdProduceFrameNo; // ���Y�ԑ�ԍ��I��
            extraInfo.ModelGradeNm = carModelInfoDataTable[0].ModelGradeNm; // �^���O���[�h����
            extraInfo.EngineModelNm = carModelInfoDataTable[0].EngineModelNm; // �G���W���^������
            extraInfo.EngineDisplaceNm = carModelInfoDataTable[0].EngineDisplaceNm; // �r�C�ʖ���
            extraInfo.EDivNm = carModelInfoDataTable[0].EDivNm; // E�敪����
            extraInfo.TransmissionNm = carModelInfoDataTable[0].TransmissionNm; // �~�b�V��������
            extraInfo.ShiftNm = carModelInfoDataTable[0].ShiftNm; // �V�t�g����
            extraInfo.WheelDriveMethodNm = carModelInfoDataTable[0].WheelDriveMethodNm; // �쓮��������
            extraInfo.AddiCarSpec1 = carModelInfoDataTable[0].AddiCarSpec1; // �ǉ�����1
            extraInfo.AddiCarSpec2 = carModelInfoDataTable[0].AddiCarSpec2; // �ǉ�����2
            extraInfo.AddiCarSpec3 = carModelInfoDataTable[0].AddiCarSpec3; // �ǉ�����3
            extraInfo.AddiCarSpec4 = carModelInfoDataTable[0].AddiCarSpec4; // �ǉ�����4
            extraInfo.AddiCarSpec5 = carModelInfoDataTable[0].AddiCarSpec5; // �ǉ�����5
            extraInfo.AddiCarSpec6 = carModelInfoDataTable[0].AddiCarSpec6; // �ǉ�����6
            extraInfo.AddiCarSpecTitle1 = carModelInfoDataTable[0].AddiCarSpecTitle1; // �ǉ������^�C�g��1
            extraInfo.AddiCarSpecTitle2 = carModelInfoDataTable[0].AddiCarSpecTitle2; // �ǉ������^�C�g��2
            extraInfo.AddiCarSpecTitle3 = carModelInfoDataTable[0].AddiCarSpecTitle3; // �ǉ������^�C�g��3
            extraInfo.AddiCarSpecTitle4 = carModelInfoDataTable[0].AddiCarSpecTitle4; // �ǉ������^�C�g��4
            extraInfo.AddiCarSpecTitle5 = carModelInfoDataTable[0].AddiCarSpecTitle5; // �ǉ������^�C�g��5
            extraInfo.AddiCarSpecTitle6 = carModelInfoDataTable[0].AddiCarSpecTitle6; // �ǉ������^�C�g��6
            extraInfo.RelevanceModel = carModelInfoDataTable[0].RelevanceModel; // �֘A�^��
            extraInfo.SubCarNmCd = carModelInfoDataTable[0].SubCarNmCd; // �T�u�Ԗ��R�[�h
            extraInfo.ModelGradeSname = carModelInfoDataTable[0].ModelGradeSname; // �^���O���[�h����
            extraInfo.BlockIllustrationCd = carModelInfoDataTable[0].BlockIllustrationCd; // �u���b�N�C���X�g�R�[�h
            extraInfo.ThreeDIllustNo = carModelInfoDataTable[0].ThreeDIllustNo; // 3D�C���X�gNo
            extraInfo.PartsDataOfferFlag = carModelInfoDataTable[0].PartsDataOfferFlag; // ���i�f�[�^�񋟃t���O

            // ----- UPD 2010/04/27 ------------------------>>>>>
            //extraInfo.FullModelFixedNoAry = this._carSearchController.GetFullModelFixedNoArray(searchCarInfo.CarModelInfo); // �t���^���Œ�ԍ��z��
            int[] fullAry = new int[0];
            string[] freeAry = new string[0];
            this._carSearchController.GetFullModelFixedNoArrayWithFreeSrchMdlFxdNo(searchCarInfo.CarModelInfo, out fullAry, out freeAry);
            extraInfo.FullModelFixedNoAry = fullAry;
            extraInfo.FreeSrchMdlFxdNoAry = freeAry;
            // ----- UPD 2010/04/27 ------------------------<<<<<

            this.CacheColorInfo(extraInfo, searchCarInfo.ColorCdInfo);                         // �J���[���
            this.CacheTrimInfo(extraInfo, searchCarInfo.TrimCdInfo);                           // �g�������
            this.CacheEquipInfo(extraInfo, searchCarInfo.CEqpDefDspInfo);                      // �������

            // ADD 2013/03/22 -------------------->>>>>		        
            extraInfo.DomesticForeignCode = carModelUIDataTable[0].DomesticForeignCode; // ���Y/�O�ԋ敪
            try
            {
                // �n���h���ʒu��������l(���^��)�Ƃ���
                // ���n���h���ʒu�`�F�b�N���s��Ȃ��悤�ɂ���
                extraInfo.HandleInfoCode = 0; // �n���h���ʒu���

                // �^�������őI������Ă��邷�ׂĂ̍s���r����
                int pos = searchCarInfo.CarModelInfo.HandleInfoCdColumn.Ordinal;
                int state = searchCarInfo.CarModelInfo.SelectionStateColumn.Ordinal;
                foreach (DataRow row in searchCarInfo.CarModelInfo.Rows)
                {
                    // �I������Ă��Ȃ��s�̓X�L�b�v����
                    if ((bool)row[state] != true)
                        continue;

                    // �n���h���ʒu�����`�F�b�N����
                    HandleInfoCdRet posKind = (HandleInfoCdRet)row[pos];
                    if (posKind != HandleInfoCdRet.PositionRight && posKind != HandleInfoCdRet.PositionLeft)
                        continue;

                    // �n���h���ʒu���r����
                    if (extraInfo.HandleInfoCode == 0)
                    {
                        // �n���h���ʒu�����Z�b�g����
                        extraInfo.HandleInfoCode = (int)posKind;
                    }
                    else if (extraInfo.HandleInfoCode == (int)HandleInfoCdRet.PositionRight && posKind == HandleInfoCdRet.PositionLeft)
                    {
                        // �E/���n���h�����݂̏ꍇ�͗��^���Ƃ���
                        extraInfo.HandleInfoCode = 0;
                        break;
                    }
                    else if (extraInfo.HandleInfoCode == (int)HandleInfoCdRet.PositionLeft && posKind == HandleInfoCdRet.PositionRight)
                    {
                        // �E/���n���h�����݂̏ꍇ�͗��^���Ƃ���
                        extraInfo.HandleInfoCode = 0;
                        break;
                    }
                }
            }
            catch
            {
                // ��O�����������ꍇ�͗��^��(0)�̂܂܂Ƃ���
                // ���n���h���ʒu�`�F�b�N���s��Ȃ��悤�ɂ���
                extraInfo.HandleInfoCode = 0; // �n���h���ʒu���
            }
            this._handleInfoCode = extraInfo.HandleInfoCode; // �n���h���ʒu���L���b�V��
            this._carInfo = searchCarInfo.CarModelInfo; // �^�������L���b�V������
            // ADD 2013/03/22 --------------------<<<<<
        }

        /// <summary>
        /// �������ݒ菈��(�ԗ����s�I�u�W�F�N�g���������s�I�u�W�F�N�g)
        /// </summary>
        /// <param name="carSpecRow">�������s�I�u�W�F�N�g</param>
        /// <param name="extraInfo">�ԗ����s�I�u�W�F�N�g</param>
        /// <remarks>
        /// <br>Note       : �������ݒ菈��(�ԗ����s�I�u�W�F�N�g���������s�I�u�W�F�N�g)���s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void SetCarSpecFromCarInfoRow(ref CarMngInputDataSet.CarSpecRow carSpecRow, CarMangInputExtraInfo extraInfo)
        {
            if (extraInfo == null) return;

            carSpecRow.ModelGradeNm = extraInfo.ModelGradeNm;                     // �O���[�h
            carSpecRow.BodyName = extraInfo.BodyName;                             // �{�f�B
            carSpecRow.DoorCount = extraInfo.DoorCount;                           // �h�A
            carSpecRow.EDivNm = extraInfo.EDivNm;                                 // �d�敪
            carSpecRow.EngineDisplaceNm = extraInfo.EngineDisplaceNm;             // �r�C��
            carSpecRow.EngineModelNm = extraInfo.EngineModelNm;                   // �G���W��
            carSpecRow.ShiftNm = extraInfo.ShiftNm;                               // �V�t�g
            carSpecRow.TransmissionNm = extraInfo.TransmissionNm;                 // �~�b�V����
            carSpecRow.WheelDriveMethodNm = extraInfo.WheelDriveMethodNm;         // �쓮����
            carSpecRow.AddiCarSpec1 = extraInfo.AddiCarSpec1;                     // �ǉ������P
            carSpecRow.AddiCarSpec2 = extraInfo.AddiCarSpec2;                     // �ǉ������Q 
            carSpecRow.AddiCarSpec3 = extraInfo.AddiCarSpec3;                     // �ǉ������R
            carSpecRow.AddiCarSpec4 = extraInfo.AddiCarSpec4;                     // �ǉ������S
            carSpecRow.AddiCarSpec5 = extraInfo.AddiCarSpec5;                     // �ǉ������T
            carSpecRow.AddiCarSpec6 = extraInfo.AddiCarSpec6;                     // �ǉ������U
        }

        /// <summary>
        /// ���[�J�[���̎擾����
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string GetName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerName;
        }

        /// <summary>
        /// ���[�J�[���̎擾����(���p�J�i����)
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>���[�J�[����</returns>
        /// <remarks>
        /// <br>Note       : ���[�J�[���̎擾����(���p�J�i����)���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string GetKanaName_FromMaker(int makerCode)
        {
            MakerUMnt makerUMnt = this._makerUMntList.Find(
                delegate(MakerUMnt maker)
                {
                    return (maker.GoodsMakerCd == makerCode) ? true : false;
                }
            );
            return (makerUMnt == null) ? string.Empty : makerUMnt.MakerKanaName;
        }

        /// <summary>
        /// �Ԏ햼�̎擾����
        /// </summary>
        /// <param name="makerCode">�J�[���[�J�[�R�[�h</param>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ԏ햼�̂��擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string GetModelFullName(int makerCode, int modelCode, int modelSubCode)
        {
            string retName = string.Empty;
            ModelNameU modelNameU = new ModelNameU();
            modelNameU = this.GetModelInfo(makerCode, modelCode, modelSubCode);
            if (modelNameU != null) retName = modelNameU.ModelFullName;

            return retName;
        }

        /// <summary>
        /// �Ԏ피�p���̎擾����
        /// </summary>
        /// <param name="makerCode">�J�[���[�J�[�R�[�h</param>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ԏ피�p���̂��擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public string GetModelHalfName(int makerCode, int modelCode, int modelSubCode)
        {
            string retName = string.Empty;
            ModelNameU modelNameU = new ModelNameU();
            modelNameU = this.GetModelInfo(makerCode, modelCode, modelSubCode);
            if (modelNameU != null) retName = modelNameU.ModelHalfName;

            return retName;
        }

        /// <summary>
        /// �J���[���I������
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <param name="colorCode">�J���[�R�[�h</param>
        /// <param name="extraInfo">���q�Ǘ����</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �J���[���I���������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public bool SelectColorInfo(Guid carRelationGuid, string colorCode, CarMangInputExtraInfo extraInfo)
        {
            bool ret = false;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = this._colorInfoDic[carRelationGuid];
                ret = this.SelectColorInfo(colorInfoDataTable, colorCode, extraInfo);
            }
            return ret;
        }

        /// <summary>
        /// �J���[���擾����
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <returns>�J���[���f�[�^�e�[�u��</returns>
        /// <remarks>
        /// <br>Note       : �J���[���擾�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMKEN01010E.ColorCdInfoDataTable GetColorInfo(Guid carRelationGuid)
        {
            PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable = null;
            if (this._colorInfoDic.ContainsKey(carRelationGuid))
            {
                colorInfoDataTable = this._colorInfoDic[carRelationGuid];
            }
            return colorInfoDataTable;
        }

        /// <summary>
        /// �g�������擾����
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <returns>�g�������f�[�^�e�[�u��</returns>
        /// <remarks>
        /// <br>Note       : �g�������擾�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMKEN01010E.TrimCdInfoDataTable GetTrimInfo(Guid carRelationGuid)
        {
            PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = null;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                trimInfoDataTable = this._trimInfoDic[carRelationGuid];
            }
            return trimInfoDataTable;
        }

        /// <summary>
        /// �������擾����
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <returns>�������f�[�^�e�[�u��</returns>
        /// <remarks>
        /// <br>Note       : �������擾�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public PMKEN01010E.CEqpDefDspInfoDataTable GetEquipInfo(Guid carRelationGuid)
        {
            PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = null;
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                equipInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
            }
            return equipInfoDataTable;
        }

        /// <summary>
        /// �g�������I������
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <param name="trimCode">�g�����R�[�h</param>
        /// <param name="extraInfo">���q�Ǘ����</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �g�������I���������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public bool SelectTrimInfo(Guid carRelationGuid, string trimCode, CarMangInputExtraInfo extraInfo)
        {
            bool ret = false;
            if (this._trimInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable = this._trimInfoDic[carRelationGuid];
                ret = this.SelectTrimInfo(trimInfoDataTable, trimCode, extraInfo);
            }
            return ret;
        }

        /// <summary>
        /// �������I������
        /// </summary>
        /// <param name="carRelationGuid"></param>
        /// <param name="equipmentGenreCd"></param>
        /// <param name="selectIndex"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �������I���������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public bool SelectEquipInfo(Guid carRelationGuid, string equipmentGenreCd, int selectIndex)
        {
            bool ret = false;
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
                ret = this.SelectEquipInfo(carRelationGuid, eqpDspInfoDataTable, equipmentGenreCd, selectIndex);
            }
            return ret;
        }

        /// <summary>
        /// �������I������
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <param name="categoryObjAry">�������z��</param>
        /// <remarks>
        /// <br>Note       : �������I���������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void SelectEquipInfo(Guid carRelationGuid, byte[] categoryObjAry)
        {
            if ((this._cEqpDspInfoDic.ContainsKey(carRelationGuid)) && (categoryObjAry != null))
            {
                PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];
                if (categoryObjAry.Length > 0)
                {
                    // �w��̑�����I����Ԃɂ���
                    eqpDspInfoDataTable.SetTableFromByteArray(categoryObjAry);
                }
                else
                {
                    // �S�ĉ���
                    foreach (PMKEN01010E.CEqpDefDspInfoRow row in eqpDspInfoDataTable.Rows)
                    {
                        row.SelectionState = false;
                    }
                }
            }
        }

        /// <summary>
        /// �������Ώۑ������בI���^��������
        /// </summary>
        /// <param name="equipInfoDataTable">�g�������f�[�^�e�[�u��</param>
        /// <param name="key">�L�[</param>
        /// <param name="state">�I�����</param>
        /// <remarks>
        /// <br>Note       : �������Ώۑ������בI���^�����������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void SettingEquipInfoAllState(PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable, string key, bool state)
        {
            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])equipInfoDataTable.Select(string.Format("{0}='{1}'", equipInfoDataTable.EquipmentGenreNmColumn.ColumnName, key));

            foreach (PMKEN01010E.CEqpDefDspInfoRow row in rows)
            {
                row.SelectionState = state;
            }
        }

        /// <summary>
        /// �f�[�^�̓Ǎ�����
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <param name="readMode"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�̓Ǎ��������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int ReadDB(ref CarMangInputExtraInfo extraInfo, int readMode, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                CarManagementWork tempWork = new CarManagementWork();
                tempWork.EnterpriseCode = this._enterpriseCode;
                tempWork.CustomerCode = extraInfo.CustomerCode;
                tempWork.CarMngNo = extraInfo.CarMngNo;
                tempWork.CarMngCode = extraInfo.CarMngCode; // 2009/12/24
                Object objCarMngWork = tempWork as object;
                status = this._iCarManagementDB.Read(ref objCarMngWork, readMode);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    extraInfo = this.ConvertCarMngWorkToCarMngExtraInfo(objCarMngWork as CarManagementWork);
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                else
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �f�[�^�o�^����
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�o�^�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int WriteDB(ref CarMangInputExtraInfo extraInfo, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                CarManagementWork work = this.ConvertCarMngExtraInfoToCarMngWork(extraInfo);
                CustomSerializeArrayList workList = new CustomSerializeArrayList();
                workList.Add(work);

                Object objWorkList = workList as object;
                status = this._iCarManagementDB.Write(ref objWorkList);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    workList = objWorkList as CustomSerializeArrayList;
                    work = workList[0] as CarManagementWork;

                    extraInfo = this.ConvertCarMngWorkToCarMngExtraInfo(work);
                }
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^���̘_���폜���������܂�
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ԗ��Ǘ��}�X�^���̘_���폜���������܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
       // public int RevivalLogicalDelete(CarMangInputExtraInfo extraInfo, out string errMsg)
        public int RevivalLogicalDelete(ref CarMangInputExtraInfo extraInfo, out string errMsg) // ADD 2009/10/10
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                CarManagementWork work = this.ConvertCarMngExtraInfoToCarMngWork(extraInfo);
                ArrayList workList = new ArrayList();
                workList.Add(work);

                Object objWorkList = workList as object;
                status = this._iCarManagementDB.RevivalLogicalDelete(ref objWorkList);
                // ----ADD 2009/10/10 -------->>>>> 
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    workList = objWorkList as ArrayList;
                    work = workList[0] as CarManagementWork;

                    extraInfo = this.ConvertCarMngWorkToCarMngExtraInfo(work);
                }
                // ----ADD 2009/10/10 --------<<<<<

            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// �ԗ��Ǘ��}�X�^�����폜���܂�
        /// </summary>
        /// <param name="extraInfo"></param>
        /// <param name="errMsg"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ԗ��Ǘ��}�X�^�����폜���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int Delete(CarMangInputExtraInfo extraInfo, out string errMsg)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            errMsg = string.Empty;
            try
            {
                CarManagementWork work = this.ConvertCarMngExtraInfoToCarMngWork(extraInfo);
                CustomSerializeArrayList workList = new CustomSerializeArrayList();
                workList.Add(work);

                Object objWorkList = workList as object;
                status = this._iCarManagementDB.Delete(objWorkList);
            }
            catch (Exception ex)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                errMsg = ex.Message;
            }

            return status;
        }

        /// <summary>
        /// ���q�Ǘ��K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note		: ���q�Ǘ��K�C�h�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009/09/07</br>
        /// <br>Update Note : wangf</br>
        /// <br>Date		: 2011/08/02</br>
        /// <br>            : PM1107C�@NS���[�U�[���Ǘv�]�ꗗ_PM7����_�A��895�ɏC��</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            CarMngGuideParamWork paraWork = new CarMngGuideParamWork();
            bool isDispCustomerInfo = false;
            bool isDispNewRow = false;

            // �K�C�h�p���������̐ݒ�
            paraWork = this.ConvertHashtableToCarMngGuideParamWork(inParm);

            // ���Ӑ�\���t���O
            if (inParm.ContainsKey("IsDispCustomerInfo"))
            {
                isDispCustomerInfo = (bool)inParm["IsDispCustomerInfo"];
            }

            // �V�K�o�^�s�\���t���O
            if (inParm.ContainsKey("IsDispNewRow"))
            {
                isDispNewRow = (bool)inParm["IsDispNewRow"];
            }

            ArrayList retList;
            // ���_���ݒ�e�[�u���Ǎ���
            status = SearchGuide(out retList, paraWork, isDispCustomerInfo, isDispNewRow);
            // -- add wangf 2011/08/02 ---------->>>>>
            retList.Sort(new CarMngInputCompareList());
            // -- add wangf 2011/08/02 ----------<<<<<
            switch (status)
            {
                case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
                    // �K�C�h�����N����
                    if (guideList.Tables.Count == 0)
                    {
                        // �K�C�h�p�f�[�^�Z�b�g����\�z
                        this.GuideDataSetColumnConstruction(ref guideList);
                    }
                    // �K�C�h�p�f�[�^�Z�b�g�̍쐬
                    this.GetGuideDataSet(ref guideList, retList);

                    break;
                case (int)ConstantManagement.DB_Status.ctDB_EOF:
                    {
                        status = 4;
                        break;
                    }
                default:
                    status = -1;
                    break;
            }
            return status;
        }

        /// <summary>
        /// �K�C�h�p�f�[�^�Z�b�g�쐬����
        /// </summary>
        /// <param name="retDataSet">���ʎ擾�f�[�^�Z�b�g</param>>
        /// <param name="retList">���ʎ擾�A���C���X�g</param>>
        /// <remarks>
        /// <br>Note	   : �K�C�h�p�f�[�^�Z�b�g�������s�Ȃ�</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009/09/07</br>
        /// </remarks>
        private void GetGuideDataSet(ref DataSet retDataSet, ArrayList retList)
        {
            CarMangInputExtraInfo carMangInputExtra = null;
            DataRow guideRow = null;

            // �s�����������ĐV�����f�[�^��ǉ�
            retDataSet.Tables[0].Rows.Clear();
            retDataSet.Tables[0].BeginLoadData();

            int dataCnt = 0;
            while (dataCnt < retList.Count)
            {
                carMangInputExtra = (CarMangInputExtraInfo)retList[dataCnt];
                if (carMangInputExtra.LogicalDeleteCode == 0)
                {
                    guideRow = retDataSet.Tables[0].NewRow();
                    // �f�[�^�R�s�[����
                    CopyToGuideRowFromCarMangInput(ref guideRow, carMangInputExtra);
                    // �f�[�^�ǉ�
                    retDataSet.Tables[0].Rows.Add(guideRow);
                }
                dataCnt++;
            }

            retDataSet.Tables[0].EndLoadData();
        }

        /// <summary>
        /// DataRow�R�s�[�����i�d����N���X�˃K�C�h�pDataRow�j
        /// </summary>
        /// <param name="guideRow">�K�C�h�pDataRow</param>
        /// <param name="carMangInputExtra">�d����N���X</param>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��ԍ��N���X����K�C�h�pDataRow�փR�s�[���s���܂��B</br>
        /// <br>Programmer	: ���w�q</br>
        /// <br>Date		: 2009/09/07</br>
        /// <br>Update Note : wangf</br>
        /// <br>Date		: 2011/08/02</br>
        /// <br>            : PM1107C�@NS���[�U�[���Ǘv�]�ꗗ_PM7����_�A��895�ɏC��</br>
        /// </remarks>
        private void CopyToGuideRowFromCarMangInput(ref DataRow guideRow, CarMangInputExtraInfo carMangInputExtra)
        {
            # region [�f�[�^����K�C�h�ɃZ�b�g�i���������j]
            guideRow[GUIDE_ENTERPRISECODE_TITLE] = carMangInputExtra.EnterpriseCode; // ��ƃR�[�h
            guideRow[GUIDE_CARMNGCODE_TITLE] = carMangInputExtra.CarMngCode; // �Ǘ��ԍ�
            guideRow[GUIDE_MODELFULLNAME_TITLE] = carMangInputExtra.ModelFullName; // �Ԏ�
            guideRow[GUIDE_FULLMODEL_TITLE] = carMangInputExtra.FullModel; // �^��
            guideRow[GUIDE_FRAMENO_TITLE] = carMangInputExtra.FrameNo; // �ԑ�ԍ�
            guideRow[GUIDE_NUMBERPLATEFORGUIDE_TITLE] = carMangInputExtra.NumberPlateForGuide; // �o�^�ԍ�
            guideRow[GUIDE_CUSTOMERCODE_TITLE] = carMangInputExtra.CustomerCode; // ���Ӑ�R�[�h
            guideRow[GUIDE_CUSTOMERCODEFORGUIDE_TITLE] = carMangInputExtra.CustomerCodeForGuide; // ���Ӑ�Guide
            guideRow[GUIDE_CUSTOMERNAME_TITLE] = carMangInputExtra.CustomerName; // ���Ӑ於
            guideRow[GUIDE_CARMNGNO_TITLE] = carMangInputExtra.CarMngNo; // ���q�Ǘ��ԍ�
            // -- add wangf 2011/08/02 ---------->>>>>
            guideRow[GUIDE_CARNOTE_TITLE] = carMangInputExtra.CarNote; // ���q���l
            // -- add wangf 2011/08/02 ----------<<<<<
            // ADD 2013/04/19 SCM��Q��10521�Ή� ---------------------------------->>>>>
            guideRow[GUIDE_NUMBERPLATE1CODE_TITLE] = carMangInputExtra.NumberPlate1Code; // ���^�����Ǔo�^�ԍ�
            guideRow[GUIDE_NUMBERPLATE1NAME_TITLE] = carMangInputExtra.NumberPlate1Name; // ���^�����ǖ���
            guideRow[GUIDE_NUMBERPLATE2_TITLE] = carMangInputExtra.NumberPlate2; // �ԗ��o�^�ԍ��i��ʁj
            guideRow[GUIDE_NUMBERPLATE3_TITLE] = carMangInputExtra.NumberPlate3; // �ԗ��o�^�ԍ��i�J�i�j
            guideRow[GUIDE_NUMBERPLATE4_TITLE] = carMangInputExtra.NumberPlate4; // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------<<<<<
            # endregion
        }

        /// <summary>
        /// �K�C�h�p�f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <param name="guideList">�K�C�h�p�f�[�^�Z�b�g</param>>
        /// <remarks>
        /// <br>Note       : �K�C�h�p�f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note : wangf</br>
        /// <br>Date		: 2011/08/02</br>
        /// <br>            : PM1107C�@NS���[�U�[���Ǘv�]�ꗗ_PM7����_�A��895�ɏC��</br>
        /// </remarks>
        private void GuideDataSetColumnConstruction(ref DataSet guideList)
        {
            DataTable table = new DataTable();
            # region [�K�C�h�p�e�[�u������]
            // ��ƃR�[�h
            table.Columns.Add(GUIDE_ENTERPRISECODE_TITLE, typeof(string));
            // �Ǘ��ԍ�
            table.Columns.Add(GUIDE_CARMNGCODE_TITLE, typeof(string));
            // �Ԏ�
            table.Columns.Add(GUIDE_MODELFULLNAME_TITLE, typeof(string));
            // �^��
            table.Columns.Add(GUIDE_FULLMODEL_TITLE, typeof(string));
            //�ԑ�ԍ�
            table.Columns.Add(GUIDE_FRAMENO_TITLE, typeof(string));
            //�o�^�ԍ�
            table.Columns.Add(GUIDE_NUMBERPLATEFORGUIDE_TITLE, typeof(string));
            //���Ӑ�R�[�h
            table.Columns.Add(GUIDE_CUSTOMERCODE_TITLE, typeof(string));
            //���Ӑ�Guide
            table.Columns.Add(GUIDE_CUSTOMERCODEFORGUIDE_TITLE, typeof(string));
            //���Ӑ於
            table.Columns.Add(GUIDE_CUSTOMERNAME_TITLE, typeof(string));
            // ���q�Ǘ��ԍ�
            table.Columns.Add(GUIDE_CARMNGNO_TITLE, typeof(string));
            // -- add wangf 2011/08/02 ---------->>>>>
            // ���q���l
            table.Columns.Add(GUIDE_CARNOTE_TITLE, typeof(string));
            // -- add wangf 2011/08/02 ----------<<<<<
            // ADD 2013/04/19 SCM��Q��10521�Ή� --------------------------->>>>>
            // ���^�����Ǔo�^�ԍ�
            table.Columns.Add(GUIDE_NUMBERPLATE1CODE_TITLE, typeof(Int32));
            // ���^�����ǖ���
            table.Columns.Add(GUIDE_NUMBERPLATE1NAME_TITLE, typeof(string));
            // �ԗ��o�^�ԍ��i��ʁj
            table.Columns.Add(GUIDE_NUMBERPLATE2_TITLE, typeof(string));
            // �ԗ��o�^�ԍ��i�J�i�j
            table.Columns.Add(GUIDE_NUMBERPLATE3_TITLE, typeof(string));
            // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            table.Columns.Add(GUIDE_NUMBERPLATE4_TITLE, typeof(Int32));
            // ADD 2013/04/19 SCM��Q��10521�Ή� ---------------------------<<<<<
            # endregion
            // �e�[�u���R�s�[
            guideList.Tables.Add(table.Clone());
        }

        /// <summary>
        /// ���q�Ǘ��K�C�h�N���O�f�[�^���݃`�F�b�N����
        /// </summary>
        /// <param name="paramInfo">�K�C�h�����p�̏����I�u�W�F�N�g</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��K�C�h�N���O�f�[�^���݃`�F�b�N�������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public int ExecuteGuidBeforeDataCheck(CarMngGuideParamInfo paramInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            string errMsg = string.Empty;
            CarMngGuideParamWork paramWork = this.ConvertCarMngGuideParamInfoToWork(paramInfo);
            // �f�[�^���݃`�F�b�N
            // �K�C�h�p���������̐ݒ�
            Object carMngGuideWorkObj = paramWork as object;
            Object carMngWorkListObj = (new ArrayList()) as object;
            try
            {
                // �����[�g����
                status = this._iCarManagementDB.SearchGuide(carMngGuideWorkObj, out carMngWorkListObj);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
            }
            catch
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        /// <summary>
        /// ���q�Ǘ��K�C�h�N������
        /// </summary>
        /// <param name="paramInfo">�K�C�h�����p�̏����I�u�W�F�N�g</param>
        /// <param name="selectedInfo">�߂�l</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��K�C�h�N���������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note : wangf</br>
        /// <br>Date		: 2011/08/02</br>
        /// <br>            : PM1107C�@NS���[�U�[���Ǘv�]�ꗗ_PM7����_�A��895�ɏC��</br>
        /// </remarks>
        public int ExecuteGuid(CarMngGuideParamInfo paramInfo, out CarMangInputExtraInfo selectedInfo)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            selectedInfo = new CarMangInputExtraInfo();
            try
            {
                string errMsg = string.Empty;

                TableGuideParent tableGuideParent = null;
                Hashtable inObj = new Hashtable();
                Hashtable retObj = new Hashtable();

                // ��ƃR�[�h
                inObj.Add("EnterpriseCode", paramInfo.EnterpriseCode);
                // ���Ӑ�`�F�b�N�t���O
                inObj.Add("IsCheckCustomerCode", paramInfo.IsCheckCustomerCode);
                // ���Ӑ�R�[�h
                inObj.Add("CustomerCode", paramInfo.CustomerCode);
                // �Ǘ��ԍ��`�F�b�N�t���O
                inObj.Add("IsCheckCarMngCode", paramInfo.IsCheckCarMngCode);
                // �Ǘ��ԍ�
                inObj.Add("CarMngCode", paramInfo.CarMngCode);
                // ���q�Ǘ��敪�`�F�b�N����
                inObj.Add("CheckCarMngCodeType", paramInfo.CheckCarMngCodeType);
                // ���q�Ǘ��敪�`�F�b�N�t���O
                inObj.Add("IsCheckCarMngDivCd", paramInfo.IsCheckCarMngDivCd);
                // ���Ӑ�\���t���O
                inObj.Add("IsDispCustomerInfo", paramInfo.IsDispCustomerInfo);
                if (paramInfo.IsDispCustomerInfo == true)
                {
                    // ���Ӑ�\������
                    tableGuideParent = new TableGuideParent("CARMNGINFOGUIDEPARENT.XML");
                }
                else
                {
                    // ���Ӑ�\���Ȃ�
                    tableGuideParent = new TableGuideParent("CARMNGINFOGUIDEWITHOUTCUSTPARENT.XML");
                }
                // �V�K�o�^�s�\���t���O
                inObj.Add("IsDispNewRow", paramInfo.IsDispNewRow);

                // �K�C�h�N���b�N�̏ꍇ�A�f�[�^���݃`�F�b�N���Ȃ�
                if (paramInfo.IsGuideClick == true)
                {
                    status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                }
                else
                {
                    // �f�[�^���݃`�F�b�N
                    status = this.ExecuteGuidBeforeDataCheck(paramInfo);
                }

                if (status != (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                {
                    // �f�[�^���Ȃ��ꍇ�A�K�C�h���N�����Ȃ�
                    return (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                }
                else
                {
                    if (tableGuideParent.Execute(0, inObj, ref retObj))
                    {
                        // ���Ӑ�R�[�h
                        selectedInfo.CustomerCode = Convert.ToInt32(retObj[GUIDE_CUSTOMERCODE_TITLE].ToString());
                        // ���q�Ǘ��ԍ�
                        selectedInfo.CarMngNo = Convert.ToInt32(retObj[GUIDE_CARMNGNO_TITLE].ToString());
                        // �Ǘ��ԍ�
                        selectedInfo.CarMngCode = retObj[GUIDE_CARMNGCODE_TITLE].ToString();
                        // -- add wangf 2011/08/02 ---------->>>>>
                        // ���q���l
                        selectedInfo.CarNote = retObj[GUIDE_CARNOTE_TITLE].ToString();
                        // -- add wangf 2011/08/02 ----------<<<<<

                        // ADD 2013/04/19 SCM��Q��10521�Ή� ---------------------------------->>>>>
                        // ���^�����Ǔo�^�ԍ�
                        selectedInfo.NumberPlate1Code = (int)retObj[GUIDE_NUMBERPLATE1CODE_TITLE];
                        // ���^�����ǖ���
                        selectedInfo.NumberPlate1Name = retObj[GUIDE_NUMBERPLATE1NAME_TITLE].ToString();
                        // �ԗ��o�^�ԍ��i��ʁj
                        selectedInfo.NumberPlate2 = retObj[GUIDE_NUMBERPLATE2_TITLE].ToString();
                        // �ԗ��o�^�ԍ��i�J�i�j
                        selectedInfo.NumberPlate3 = retObj[GUIDE_NUMBERPLATE3_TITLE].ToString();
                        // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                        selectedInfo.NumberPlate4 = (int)retObj[GUIDE_NUMBERPLATE4_TITLE];
                        // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------<<<<<

                        // �V�K�o�^�̏ꍇ
                        if (selectedInfo.CarMngCode != "�V�K�o�^")
                        {
                            // ���q�Ǘ��}�X�^�̌���
                            status = this.ReadDB(ref selectedInfo, 0, out errMsg);
                        }
                        else
                        {
                            status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
                        }
                    }
                    // �L�����Z��
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                    }
                }
            }
            catch (Exception)
            {
                status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            return status;
        }

        /// <summary>
        /// �J���[�����N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : �J���[�����N���A���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void ClearColorInfo()
        {
            this._colorInfoDic.Clear();
        }

        /// <summary>
        /// �g���������N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : �g���������N���A���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void ClearTrimInfo()
        {
            this._trimInfoDic.Clear();
        }

        /// <summary>
        /// ���������N���A
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���������N���A���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public void ClearEquipInfo()
        {
            this._cEqpDspInfoDic.Clear();
        }

        /// <summary>
        /// �������s�I�u�W�F�N�g�z��擾
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <returns>�������o�C�g�z��</returns>
        /// <remarks>
        /// <br>Note       : �������s�I�u�W�F�N�g�z����擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        public byte[] GetEquipInfoRows(Guid carRelationGuid)
        {
            byte[] equipInfoRows = new byte[0];
            if (this._cEqpDspInfoDic.ContainsKey(carRelationGuid))
            {
                // �������f�[�^�e�[�u���擾
                PMKEN01010E.CEqpDefDspInfoDataTable equipInfoDataTable = this._cEqpDspInfoDic[carRelationGuid];

                if (equipInfoDataTable != null)
                {
                    // �������o�C�g�z��
                    equipInfoRows = equipInfoDataTable.GetByteArray(true);
                }
            }
            return equipInfoRows;
        }
        # endregion

        // ===================================================================================== //
        // �v���C�x�[�g���\�b�h
        // ===================================================================================== //
        # region Private Method
        /// <summary>
        /// �S�̏����l�ݒ�}�X�^�̃��X�g������A�w�肵�����_�Ŏg�p����ݒ���擾���܂��B(���_�R�[�h��������ΑS�Аݒ�j
        /// </summary>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="allDefSetArrayList">�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g���X�g</param>
        /// <returns>�S�̏����l�ݒ�}�X�^�I�u�W�F�N�g</returns>
        /// <remarks>
        /// <br>Note       : �S�̏����l�ݒ�}�X�^�̃��X�g������A�w�肵�����_�Ŏg�p����ݒ���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private AllDefSet GetAllDefSetFromList(string sectionCode, ArrayList allDefSetArrayList)
        {
            if (allDefSetArrayList == null) return null;

            List<AllDefSet> list = new List<AllDefSet>((AllDefSet[])allDefSetArrayList.ToArray(typeof(AllDefSet)));

            AllDefSet allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == sectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (allSecAllDefSet != null) return allSecAllDefSet;

            allSecAllDefSet = list.Find(
                delegate(AllDefSet alldef)
                {
                    if (alldef.SectionCode.Trim() == ctSectionCode.Trim())
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return allSecAllDefSet;
        }

        /// <summary>
        /// �����_�R�[�h�擾����
        /// </summary>
        /// <returns>�����_�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : �����_�R�[�h���擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private string GetOwnSectionCode()
        {
            this.GetOwnSectionInfo();

            return this._ownSectionCode;
        }

        /// <summary>
        /// �����_���̎擾����
        /// </summary>
        /// <returns>�����_�R�[�h</returns>
        /// <remarks>
        /// <br>Note       : �����_���̂��擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private string GetOwnSectionName()
        {
            this.GetOwnSectionInfo();

            return this._ownSectionName;
        }

        /// <summary>
        /// �����_���擾����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �����_�����擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void GetOwnSectionInfo()
        {
            // ���_����A�N�Z�X�N���X�C���X�^���X������
            this.CreateSecInfoAcs();

            // �����_�̎擾
            SecInfoSet secInfoSet;
            _secInfoAcs.GetSecInfo(this._loginSectionCode, out secInfoSet);

            if (secInfoSet != null)
            {
                this._ownSectionCode = secInfoSet.SectionCode;
                this._ownSectionName = secInfoSet.SectionGuideNm;
            }
        }

        /// <summary>
        /// �J���[���L���b�V��
        /// </summary>
        /// <param name="extraInfo">���q�Ǘ����</param>
        /// <param name="colorCdInfoDataTable">�J���[���f�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �J���[���L���b�V�����s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void CacheColorInfo(CarMangInputExtraInfo extraInfo, PMKEN01010E.ColorCdInfoDataTable colorCdInfoDataTable)
        {
            if (this._colorInfoDic.ContainsKey(extraInfo.CarRelationGuid)) this._colorInfoDic.Remove(extraInfo.CarRelationGuid);
            this._colorInfoDic.Add(extraInfo.CarRelationGuid, colorCdInfoDataTable);
        }

        /// <summary>
        /// �g�������L���b�V��
        /// </summary>
        /// <param name="extraInfo">���q�Ǘ����</param>
        /// <param name="trimCdInfoDataTable">�g�������f�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �g�������L���b�V�����s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void CacheTrimInfo(CarMangInputExtraInfo extraInfo, PMKEN01010E.TrimCdInfoDataTable trimCdInfoDataTable)
        {
            if (this._trimInfoDic.ContainsKey(extraInfo.CarRelationGuid)) this._trimInfoDic.Remove(extraInfo.CarRelationGuid);
            this._trimInfoDic.Add(extraInfo.CarRelationGuid, trimCdInfoDataTable);
        }

        /// <summary>
        /// �������L���b�V��
        /// </summary>
        /// <param name="extraInfo">���q�Ǘ����</param>
        /// <param name="cEqpDefDspInfoDataTable">�������f�[�^�e�[�u��</param>
        /// <remarks>
        /// <br>Note       : �������L���b�V�����s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void CacheEquipInfo(CarMangInputExtraInfo extraInfo, PMKEN01010E.CEqpDefDspInfoDataTable cEqpDefDspInfoDataTable)
        {
            if (this._cEqpDspInfoDic.ContainsKey(extraInfo.CarRelationGuid)) this._cEqpDspInfoDic.Remove(extraInfo.CarRelationGuid);
            this._cEqpDspInfoDic.Add(extraInfo.CarRelationGuid, cEqpDefDspInfoDataTable);
        }

        /// <summary>
        /// �Ԏ���擾����
        /// </summary>
        /// <param name="makerCode">�J�[���[�J�[�R�[�h</param>
        /// <param name="modelCode">�Ԏ�R�[�h</param>
        /// <param name="modelSubCode">�Ԏ�T�u�R�[�h</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �Ԏ�����擾���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private ModelNameU GetModelInfo(int makerCode, int modelCode, int modelSubCode)
        {
            ModelNameU modelNameU = null;

            if ((modelCode == 0) && (modelSubCode == 0)) return modelNameU;

            int status = this._modelNameUAcs.Read(out modelNameU, this._enterpriseCode, makerCode, modelCode, modelSubCode);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) modelNameU = null;

            return modelNameU;
        }

        /// <summary>
        /// �J���[���I������
        /// </summary>
        /// <param name="colorInfoDataTable">�J���[���f�[�^�e�[�u��</param>
        /// <param name="colorCode">�J���[�R�[�h</param>
        /// <param name="extraInfo">���q�Ǘ����</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �J���[���I���������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool SelectColorInfo(PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable, string colorCode, CarMangInputExtraInfo extraInfo)
        {
            bool ret = false;
            this.SettingColorInfoAllState(colorInfoDataTable, false);   // �S���בI������
            if (extraInfo != null)
            {
                extraInfo.ColorCode = string.Empty; // �J���[�R�[�h
                extraInfo.ColorName1 = string.Empty; // �J���[����
            }
            if (colorCode != string.Empty)
            {
                PMKEN01010E.ColorCdInfoRow[] rows = (PMKEN01010E.ColorCdInfoRow[])colorInfoDataTable.Select(string.Format("{0}='{1}'", colorInfoDataTable.ColorCodeColumn.ColumnName, colorCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.ColorCdInfoRow colorInfoRow = rows[0];
                    colorInfoRow.SelectionState = true;
                    if (extraInfo != null)
                    {
                        extraInfo.ColorCode = colorInfoRow.ColorCode; // �J���[�R�[�h
                        extraInfo.ColorName1 = colorInfoRow.ColorName1; // �J���[����
                    }
                    ret = true;
                }
            }
            return ret;
        }

        /// <summary>
        /// �J���[���S���בI���^��������
        /// </summary>
        /// <param name="colorInfoDataTable">�J���[���f�[�^�e�[�u��</param>
        /// <param name="state">�I�����</param>
        /// <remarks>
        /// <br>Note       : �J���[���S���בI���^�����������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingColorInfoAllState(PMKEN01010E.ColorCdInfoDataTable colorInfoDataTable, bool state)
        {
            foreach (PMKEN01010E.ColorCdInfoRow colorInfoRow in colorInfoDataTable)
            {
                colorInfoRow.SelectionState = state;
            }
        }

        /// <summary>
        /// �g�������I������
        /// </summary>
        /// <param name="trimInfoDataTable">�g�������f�[�^�e�[�u��</param>
        /// <param name="trimCode">�g�����R�[�h</param>
        /// <param name="extraInfo">���q�Ǘ����</param>
        /// <returns>true:�Y�����萳��I�� false:�Y���Ȃ�</returns>
        /// <remarks>
        /// <br>Note       : �g�������I���������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool SelectTrimInfo(PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable, string trimCode, CarMangInputExtraInfo extraInfo)
        {
            bool ret = false;
            this.SettingTrimInfoAllState(trimInfoDataTable, false); // �S���בI������
            if (extraInfo != null)
            {
                extraInfo.TrimCode = string.Empty; // �g�����R�[�h
                extraInfo.TrimName = string.Empty; // �g��������
            }
            if (trimCode != string.Empty)
            {
                PMKEN01010E.TrimCdInfoRow[] rows = (PMKEN01010E.TrimCdInfoRow[])trimInfoDataTable.Select(string.Format("{0}='{1}'", trimInfoDataTable.TrimCodeColumn.ColumnName, trimCode));
                if (rows.Length > 0)
                {
                    PMKEN01010E.TrimCdInfoRow trimInfoRow = rows[0];
                    trimInfoRow.SelectionState = true;
                    if (extraInfo != null)
                    {
                        extraInfo.TrimCode = trimInfoRow.TrimCode; // �g�����R�[�h
                        extraInfo.TrimName = trimInfoRow.TrimName; // �g��������
                    }
                    ret = true;
                }
            }
            return ret;
        }

        /// <summary>
        /// �g�������S���בI���^��������
        /// </summary>
        /// <param name="trimInfoDataTable">�g�������f�[�^�e�[�u��</param>
        /// <param name="state">�I�����</param>
        /// <remarks>
        /// <br>Note       : �g�������S���בI���^�����������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private void SettingTrimInfoAllState(PMKEN01010E.TrimCdInfoDataTable trimInfoDataTable, bool state)
        {
            foreach (PMKEN01010E.TrimCdInfoRow trimInfoRow in trimInfoDataTable)
            {
                trimInfoRow.SelectionState = state;
            }
        }

        /// <summary>
        /// �������I������
        /// </summary>
        /// <param name="carRelationGuid">�ԗ���񋤒ʃL�[</param>
        /// <param name="eqpDspInfoDataTable">�������f�[�^�e�[�u��</param>
        /// <param name="equipmentGenreCd">�����L�[</param>
        /// <param name="selectIndex">�C���f�b�N�X</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �������I���������s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private bool SelectEquipInfo(Guid carRelationGuid, PMKEN01010E.CEqpDefDspInfoDataTable eqpDspInfoDataTable, string equipmentGenreCd, int selectIndex)
        {
            bool ret = false;

            PMKEN01010E.CEqpDefDspInfoRow[] rows = (PMKEN01010E.CEqpDefDspInfoRow[])eqpDspInfoDataTable.Select(string.Format("{0}='{1}'", eqpDspInfoDataTable.EquipmentGenreNmColumn.ColumnName, equipmentGenreCd));
            if (rows.Length > 0)
            {
                this.SettingEquipInfoAllState(eqpDspInfoDataTable, equipmentGenreCd, false);
                PMKEN01010E.CEqpDefDspInfoRow equipInfoRow = rows[selectIndex];
                equipInfoRow.SelectionState = true;
                ret = true;
            }
            return ret;
        }

        /// <summary>
        /// �ԗ����s�I�u�W�F�N�g���ԗ��Ǘ����[�N�I�u�W�F�N�g����擾
        /// </summary>
        /// <param name="extraInfo">�ԗ����s�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ԗ����s�I�u�W�F�N�g���ԗ��Ǘ����[�N�I�u�W�F�N�g����擾�B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note: 2013/03/22 FSI���� ����</br>
        /// <br>�Ǘ��ԍ�   : 10900269-00</br>
        /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// </remarks>
        private CarManagementWork ConvertCarMngExtraInfoToCarMngWork(CarMangInputExtraInfo extraInfo)
        {
            CarManagementWork carManagementWork = new CarManagementWork();

            carManagementWork.EnterpriseCode = this._enterpriseCode;               // ��ƃR�[�h
            carManagementWork.CreateDateTime = extraInfo.CreateDateTime;           // �쐬����
            carManagementWork.FileHeaderGuid = extraInfo.FileHeaderGuid;           // GUID
            carManagementWork.UpdateDateTime = extraInfo.UpdateDateTime;           // �X�V���t
            carManagementWork.LogicalDeleteCode = extraInfo.LogicalDeleteCode;     // �_���폜�敪
            carManagementWork.CustomerCode = extraInfo.CustomerCode;               // ���Ӑ�R�[�h
            carManagementWork.CarMngNo = extraInfo.CarMngNo;                       // �ԗ��Ǘ��ԍ�
            carManagementWork.CarMngCode = extraInfo.CarMngCode;                   // ���q�Ǘ��R�[�h
            carManagementWork.NumberPlate1Code = extraInfo.NumberPlate1Code;       // ���^�������ԍ�
            // ---- ADD 2009/10/10 ------>>>>>
            if (extraInfo.NumberPlate1Name.Length > 4)
            {
                carManagementWork.NumberPlate1Name = extraInfo.NumberPlate1Name.Substring(0,4);
            }
            else
            {
                carManagementWork.NumberPlate1Name = extraInfo.NumberPlate1Name;       // ���^�����ǖ���
            }
            // ---- ADD 2009/10/10 ------<<<<<
            carManagementWork.NumberPlate2 = extraInfo.NumberPlate2;               // �ԗ��o�^�ԍ��i��ʁj
            carManagementWork.NumberPlate3 = extraInfo.NumberPlate3;               // �ԗ��o�^�ԍ��i�J�i�j
            carManagementWork.NumberPlate4 = extraInfo.NumberPlate4;               // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            carManagementWork.EntryDate = extraInfo.EntryDate;                     // �o�^�N����
            carManagementWork.FirstEntryDate = extraInfo.ProduceTypeOfYearInput;   // ���N�x
            carManagementWork.MakerCode = extraInfo.MakerCode;                     // ���[�J�[�R�[�h
            carManagementWork.MakerFullName = extraInfo.MakerFullName;             // ���[�J�[�S�p����
            carManagementWork.MakerHalfName = extraInfo.MakerHalfName;             // ���[�J�[���p����
            carManagementWork.ModelCode = extraInfo.ModelCode;                     // �Ԏ�R�[�h
            carManagementWork.ModelSubCode = extraInfo.ModelSubCode;               // �Ԏ�T�u�R�[�h
            carManagementWork.ModelFullName = extraInfo.ModelFullName;             // �Ԏ�S�p����
            carManagementWork.ModelHalfName = extraInfo.ModelHalfName;             // �Ԏ피�p����
            carManagementWork.SystematicCode = extraInfo.SystematicCode;           // �n���R�[�h
            carManagementWork.SystematicName = extraInfo.SystematicName;           // �n������
            carManagementWork.ProduceTypeOfYearCd = extraInfo.ProduceTypeOfYearCd; // ���Y�N���R�[�h
            carManagementWork.ProduceTypeOfYearNm = extraInfo.ProduceTypeOfYearNm; // ���Y�N������
            carManagementWork.StProduceTypeOfYear = extraInfo.StProduceTypeOfYear; // �J�n���Y�N��
            carManagementWork.EdProduceTypeOfYear = extraInfo.EdProduceTypeOfYear; // �I�����Y�N��
            carManagementWork.DoorCount = extraInfo.DoorCount;                     // �h�A��
            carManagementWork.BodyNameCode = extraInfo.BodyNameCode;               // �{�f�B�[���R�[�h
            carManagementWork.BodyName = extraInfo.BodyName;                       // �{�f�B�[����
            carManagementWork.ExhaustGasSign = extraInfo.ExhaustGasSign;           // �r�K�X�L��
            carManagementWork.SeriesModel = extraInfo.SeriesModel;                 // �V���[�Y�^��
            carManagementWork.CategorySignModel = extraInfo.CategorySignModel;     // �^���i�ޕʋL���j
            carManagementWork.FullModel = extraInfo.FullModel;                     // �^���i�t���^�j
            carManagementWork.ModelDesignationNo = extraInfo.ModelDesignationNo;   // �^���w��ԍ�
            carManagementWork.CategoryNo = extraInfo.CategoryNo;                   // �ޕʔԍ�
            carManagementWork.FrameModel = extraInfo.FrameModel;                   // �ԑ�^��
            carManagementWork.FrameNo = extraInfo.FrameNo;                         // �ԑ�ԍ�
            carManagementWork.SearchFrameNo = extraInfo.SearchFrameNo;             // �ԑ�ԍ��i�����p�j
            carManagementWork.StProduceFrameNo = extraInfo.StProduceFrameNo;       // ���Y�ԑ�ԍ��J�n
            carManagementWork.EdProduceFrameNo = extraInfo.EdProduceFrameNo;       // ���Y�ԑ�ԍ��I��
            carManagementWork.EngineModel = extraInfo.EngineModel;                 // �����@�^���i�G���W���j
            carManagementWork.ModelGradeNm = extraInfo.ModelGradeNm;               // �^���O���[�h����
            carManagementWork.EngineModelNm = extraInfo.EngineModelNm;             // �G���W���^������
            carManagementWork.EngineDisplaceNm = extraInfo.EngineDisplaceNm;       // �r�C�ʖ���
            carManagementWork.EDivNm = extraInfo.EDivNm;                           // E�敪����
            carManagementWork.TransmissionNm = extraInfo.TransmissionNm;           // �~�b�V��������
            carManagementWork.ShiftNm = extraInfo.ShiftNm;                         // �V�t�g����
            carManagementWork.WheelDriveMethodNm = extraInfo.WheelDriveMethodNm;   // �쓮��������
            carManagementWork.AddiCarSpec1 = extraInfo.AddiCarSpec1;               // �ǉ�����1
            carManagementWork.AddiCarSpec2 = extraInfo.AddiCarSpec2;               // �ǉ�����2
            carManagementWork.AddiCarSpec3 = extraInfo.AddiCarSpec3;               // �ǉ�����3
            carManagementWork.AddiCarSpec4 = extraInfo.AddiCarSpec4;               // �ǉ�����4
            carManagementWork.AddiCarSpec5 = extraInfo.AddiCarSpec5;               // �ǉ�����5
            carManagementWork.AddiCarSpec6 = extraInfo.AddiCarSpec6;               // �ǉ�����6
            carManagementWork.AddiCarSpecTitle1 = extraInfo.AddiCarSpecTitle1;     // �ǉ������^�C�g��1
            carManagementWork.AddiCarSpecTitle2 = extraInfo.AddiCarSpecTitle2;     // �ǉ������^�C�g��2
            carManagementWork.AddiCarSpecTitle3 = extraInfo.AddiCarSpecTitle3;     // �ǉ������^�C�g��3
            carManagementWork.AddiCarSpecTitle4 = extraInfo.AddiCarSpecTitle4;     // �ǉ������^�C�g��4
            carManagementWork.AddiCarSpecTitle5 = extraInfo.AddiCarSpecTitle5;     // �ǉ������^�C�g��5
            carManagementWork.AddiCarSpecTitle6 = extraInfo.AddiCarSpecTitle6;     // �ǉ������^�C�g��6
            carManagementWork.RelevanceModel = extraInfo.RelevanceModel;           // �֘A�^��
            carManagementWork.SubCarNmCd = extraInfo.SubCarNmCd;                   // �T�u�Ԗ��R�[�h
            carManagementWork.ModelGradeSname = extraInfo.ModelGradeSname;         // �^���O���[�h����
            carManagementWork.BlockIllustrationCd = extraInfo.BlockIllustrationCd; // �u���b�N�C���X�g�R�[�h
            carManagementWork.ThreeDIllustNo = extraInfo.ThreeDIllustNo;           // 3D�C���X�gNo
            carManagementWork.PartsDataOfferFlag = extraInfo.PartsDataOfferFlag;   // ���i�f�[�^�񋟃t���O
            carManagementWork.InspectMaturityDate = extraInfo.InspectMaturityDate; // �Ԍ�������
            carManagementWork.LTimeCiMatDate = extraInfo.LTimeCiMatDate;           // �O��Ԍ�������
            carManagementWork.CarInspectYear = extraInfo.CarInspectYear;           // �Ԍ�����
            carManagementWork.Mileage = extraInfo.Mileage;                         // �ԗ����s����
            carManagementWork.CarNo = extraInfo.CarNo;                             // ����
            carManagementWork.FullModelFixedNoAry = extraInfo.FullModelFixedNoAry; // �t���^���Œ�ԍ��z��
            carManagementWork.ColorCode = extraInfo.ColorCode;                     // �J���[�R�[�h
            carManagementWork.ColorName1 = extraInfo.ColorName1;                   // �J���[����
            carManagementWork.TrimCode = extraInfo.TrimCode;                       // �g�����R�[�h
            carManagementWork.TrimName = extraInfo.TrimName;                       // �g��������
            carManagementWork.CategoryObjAry = this.GetEquipInfoRows(extraInfo.CarRelationGuid); // �����I�u�W�F�N�g�z��
            carManagementWork.CarAddInfo1 = extraInfo.CarAddInfo1;                 // �ǉ����P
            carManagementWork.CarAddInfo2 = extraInfo.CarAddInfo2;                 // �ǉ����Q
            carManagementWork.CarNote = extraInfo.CarNote;                         // ���l
            // -------- ADD 2010/04/27 ----------------------->>>>>
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, extraInfo.FreeSrchMdlFxdNoAry);
            carManagementWork.FreeSrchMdlFxdNoAry = ms.GetBuffer(); // ���R�����^���Œ�ԍ��z��
            ms.Close();
            // -------- ADD 2010/04/27 -----------------------<<<<<
            // ADD 2013/03/22 -------------------->>>>>	        
            carManagementWork.DomesticForeignCode = extraInfo.DomesticForeignCode;  // ���Y/�O�ԋ敪
            carManagementWork.HandleInfoCode = extraInfo.HandleInfoCode;  // �n���h���ʒu���
            if (extraInfo.DomesticForeignCode == 2)
            {
                // �O�Ԃ̏ꍇ��VIN�R�[�h(������)���i�[����ׁA�ԑ�ԍ��i�����p�j�ɂ�0���i�[
                carManagementWork.SearchFrameNo = 0;             // �ԑ�ԍ��i�����p�j
            }
            // ADD 2013/03/22 --------------------<<<<<
            return carManagementWork;
        }


        /// <summary>
        /// �ԗ��Ǘ����[�N�I�u�W�F�N�g���ԗ����s�I�u�W�F�N�g����擾
        /// </summary>
        /// <param name="work">�ԗ����s�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �ԗ��Ǘ����[�N�I�u�W�F�N�g���ԗ����s�I�u�W�F�N�g����擾�B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>update Note  : PM1015B�@���q�Ǘ��}�X�^�̎��R�����^���Œ�ԍ��z����R�s�[����悤�ɏC��</br>
        /// <br>             �@�{�w�C��</br>
        /// <br>Date       �@: 2010.12.22</br>
        /// <br>Update Note: 2013/03/22 FSI���� ����</br>
        /// <br>�Ǘ��ԍ�   : 10900269-00</br>
        /// <br>             SPK�ԑ�ԍ�������Ή��ɔ������Y/�O�ԋ敪�̒ǉ�</br>
        /// </remarks>
        private CarMangInputExtraInfo ConvertCarMngWorkToCarMngExtraInfo(CarManagementWork work)
        {
            CarMangInputExtraInfo extraInfo = new CarMangInputExtraInfo();

            extraInfo.EnterpriseCode = this._enterpriseCode;          // ��ƃR�[�h
            extraInfo.CreateDateTime = work.CreateDateTime;           // �쐬����
            extraInfo.FileHeaderGuid = work.FileHeaderGuid;           // GUID
            extraInfo.UpdateDateTime = work.UpdateDateTime;           // �X�V���t
            extraInfo.LogicalDeleteCode = work.LogicalDeleteCode;     // �_���폜�敪
            extraInfo.CustomerCode = work.CustomerCode;               // ���Ӑ�R�[�h
            extraInfo.CarMngNo = work.CarMngNo;                       // �ԗ��Ǘ��ԍ�
            extraInfo.CarMngCode = work.CarMngCode;                   // ���q�Ǘ��R�[�h
            extraInfo.NumberPlate1Code = work.NumberPlate1Code;       // ���^�������ԍ�
            // ---- ADD 2009/10/10 ------>>>>>
            if (work.NumberPlate1Name.Length > 4)
            {
                extraInfo.NumberPlate1Name = work.NumberPlate1Name.Substring(0, 4);
            }
            else
            {
                extraInfo.NumberPlate1Name = work.NumberPlate1Name;       // ���^�����ǖ���
            }
            // ---- ADD 2009/10/10 ------<<<<<
            extraInfo.NumberPlate2 = work.NumberPlate2;               // �ԗ��o�^�ԍ��i��ʁj
            extraInfo.NumberPlate3 = work.NumberPlate3;               // �ԗ��o�^�ԍ��i�J�i�j
            extraInfo.NumberPlate4 = work.NumberPlate4;               // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
            extraInfo.EntryDate = work.EntryDate;                     // �o�^�N����
            extraInfo.ProduceTypeOfYearInput = work.FirstEntryDate;   // ���N�x
            // �N��
            if (work.FirstEntryDate != 0)
            {
                //extraInfo.FirstEntryDate = DateTime.ParseExact(work.FirstEntryDate.ToString(), "yyyyMM", null);
                extraInfo.FirstEntryDate = work.FirstEntryDate;  // ADD 2009/10/10
            }
            extraInfo.MakerCode = work.MakerCode;                     // ���[�J�[�R�[�h
            extraInfo.MakerFullName = work.MakerFullName;             // ���[�J�[�S�p����
            extraInfo.MakerHalfName = work.MakerHalfName;             // ���[�J�[���p����
            extraInfo.ModelCode = work.ModelCode;                     // �Ԏ�R�[�h
            extraInfo.ModelSubCode = work.ModelSubCode;               // �Ԏ�T�u�R�[�h
            extraInfo.ModelFullName = work.ModelFullName;             // �Ԏ�S�p����
            extraInfo.ModelHalfName = work.ModelHalfName;             // �Ԏ피�p����
            extraInfo.SystematicCode = work.SystematicCode;           // �n���R�[�h
            extraInfo.SystematicName = work.SystematicName;           // �n������
            extraInfo.ProduceTypeOfYearCd = work.ProduceTypeOfYearCd; // ���Y�N���R�[�h
            extraInfo.ProduceTypeOfYearNm = work.ProduceTypeOfYearNm; // ���Y�N������
            extraInfo.StProduceTypeOfYear = work.StProduceTypeOfYear; // �J�n���Y�N��
            extraInfo.EdProduceTypeOfYear = work.EdProduceTypeOfYear; // �I�����Y�N��
            extraInfo.DoorCount = work.DoorCount;                     // �h�A��
            extraInfo.BodyNameCode = work.BodyNameCode;               // �{�f�B�[���R�[�h
            extraInfo.BodyName = work.BodyName;                       // �{�f�B�[����
            extraInfo.ExhaustGasSign = work.ExhaustGasSign;           // �r�K�X�L��
            extraInfo.SeriesModel = work.SeriesModel;                 // �V���[�Y�^��
            extraInfo.CategorySignModel = work.CategorySignModel;     // �^���i�ޕʋL���j
            extraInfo.FullModel = work.FullModel;                     // �^���i�t���^�j
            extraInfo.ModelDesignationNo = work.ModelDesignationNo;   // �^���w��ԍ�
            extraInfo.CategoryNo = work.CategoryNo;                   // �ޕʔԍ�
            extraInfo.FrameModel = work.FrameModel;                   // �ԑ�^��
            extraInfo.FrameNo = work.FrameNo;                         // �ԑ�ԍ�
            extraInfo.SearchFrameNo = work.SearchFrameNo;             // �ԑ�ԍ��i�����p�j
            extraInfo.StProduceFrameNo = work.StProduceFrameNo;       // ���Y�ԑ�ԍ��J�n
            extraInfo.EdProduceFrameNo = work.EdProduceFrameNo;       // ���Y�ԑ�ԍ��I��
            extraInfo.EngineModel = work.EngineModel;                 // �����@�^���i�G���W���j
            extraInfo.ModelGradeNm = work.ModelGradeNm;               // �^���O���[�h����
            extraInfo.EngineModelNm = work.EngineModelNm;             // �G���W���^������
            extraInfo.EngineDisplaceNm = work.EngineDisplaceNm;       // �r�C�ʖ���
            extraInfo.EDivNm = work.EDivNm;                           // E�敪����
            extraInfo.TransmissionNm = work.TransmissionNm;           // �~�b�V��������
            extraInfo.ShiftNm = work.ShiftNm;                         // �V�t�g����
            extraInfo.WheelDriveMethodNm = work.WheelDriveMethodNm;   // �쓮��������
            extraInfo.AddiCarSpec1 = work.AddiCarSpec1;               // �ǉ�����1
            extraInfo.AddiCarSpec2 = work.AddiCarSpec2;               // �ǉ�����2
            extraInfo.AddiCarSpec3 = work.AddiCarSpec3;               // �ǉ�����3
            extraInfo.AddiCarSpec4 = work.AddiCarSpec4;               // �ǉ�����4
            extraInfo.AddiCarSpec5 = work.AddiCarSpec5;               // �ǉ�����5
            extraInfo.AddiCarSpec6 = work.AddiCarSpec6;               // �ǉ�����6
            extraInfo.AddiCarSpecTitle1 = work.AddiCarSpecTitle1;     // �ǉ������^�C�g��1
            extraInfo.AddiCarSpecTitle2 = work.AddiCarSpecTitle2;     // �ǉ������^�C�g��2
            extraInfo.AddiCarSpecTitle3 = work.AddiCarSpecTitle3;     // �ǉ������^�C�g��3
            extraInfo.AddiCarSpecTitle4 = work.AddiCarSpecTitle4;     // �ǉ������^�C�g��4
            extraInfo.AddiCarSpecTitle5 = work.AddiCarSpecTitle5;     // �ǉ������^�C�g��5
            extraInfo.AddiCarSpecTitle6 = work.AddiCarSpecTitle6;     // �ǉ������^�C�g��6
            extraInfo.RelevanceModel = work.RelevanceModel;           // �֘A�^��
            extraInfo.SubCarNmCd = work.SubCarNmCd;                   // �T�u�Ԗ��R�[�h
            extraInfo.ModelGradeSname = work.ModelGradeSname;         // �^���O���[�h����
            extraInfo.BlockIllustrationCd = work.BlockIllustrationCd; // �u���b�N�C���X�g�R�[�h
            extraInfo.ThreeDIllustNo = work.ThreeDIllustNo;           // 3D�C���X�gNo
            extraInfo.PartsDataOfferFlag = work.PartsDataOfferFlag;   // ���i�f�[�^�񋟃t���O
            extraInfo.InspectMaturityDate = work.InspectMaturityDate; // �Ԍ�������
            extraInfo.LTimeCiMatDate = work.LTimeCiMatDate;           // �O��Ԍ�������
            extraInfo.CarInspectYear = work.CarInspectYear;           // �Ԍ�����
            extraInfo.Mileage = work.Mileage;                         // �ԗ����s����
            extraInfo.CarNo = work.CarNo;                             // ����
            extraInfo.FullModelFixedNoAry = work.FullModelFixedNoAry; // �t���^���Œ�ԍ��z��
            extraInfo.ColorCode = work.ColorCode;                     // �J���[�R�[�h
            extraInfo.ColorName1 = work.ColorName1;                   // �J���[����
            extraInfo.TrimCode = work.TrimCode;                       // �g�����R�[�h
            extraInfo.TrimName = work.TrimName;                       // �g��������
            extraInfo.CategoryObjAry = work.CategoryObjAry;           // �����I�u�W�F�N�g�z��
            extraInfo.CarAddInfo1 = work.CarAddInfo1;                 // �ǉ����P
            extraInfo.CarAddInfo2 = work.CarAddInfo2;                 // �ǉ����Q
            extraInfo.CarNote = work.CarNote;                         // ���l
            // ----- ADD 2010/04/27 ------------------->>>>>
            // ----- UPD 2010/05/20 ------------------->>>>>
            // ----- UPD 2010/12/22 ------------------->>>>>
            //if (null == work.FreeSrchMdlFxdNoAry)
            if (null == work.FreeSrchMdlFxdNoAry || work.FreeSrchMdlFxdNoAry.Length == 0)
            // ----- UPD 2010/12/22 -------------------<<<<<
            {
                extraInfo.FreeSrchMdlFxdNoAry = new string[0];
            }
            else
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream ms = new MemoryStream(work.FreeSrchMdlFxdNoAry);
                extraInfo.FreeSrchMdlFxdNoAry = (string[])formatter.Deserialize(ms); // ���R�����^���Œ�ԍ��z��
                ms.Close();
            }
            // --- DEL 2012/09/18 Y.Wakita ---------->>>>>
            //// ----ADD 2010/12/22 ------>>>>>
            //if (null == work.FreeSrchMdlFxdNoAry || work.FreeSrchMdlFxdNoAry.Length == 0)
            //{
            //    extraInfo.FreeSrchMdlFxdNoAry = new string[0];
            //}
            //else
            //{
            //    byte[] bfrom = work.FreeSrchMdlFxdNoAry;
            //    string[] freeAry = new string[bfrom.Length];
            //    for (int i = 0; i < bfrom.Length; i++)
            //    {
            //        freeAry[i] = bfrom[i].ToString();
            //    }
            //    extraInfo.FreeSrchMdlFxdNoAry = freeAry;
            //}
            //// ----ADD 2010/12/22 ------<<<<<
            // --- DEL 2012/09/18 Y.Wakita ----------<<<<<

            // ----- UPD 2010/05/20 -------------------<<<<<
            // ----- ADD 2010/04/27 -------------------<<<<<

            // ADD 2013/03/22 -------------------->>>>>	        
            extraInfo.DomesticForeignCode = work.DomesticForeignCode;          // ���Y/�O�ԋ敪
            extraInfo.HandleInfoCode = work.HandleInfoCode;  // �n���h���ʒu���
            this._handleInfoCode = work.HandleInfoCode; // �n���h���ʒu���L���b�V�����N���A����
            this._carInfo = null; // �^�����̃L���b�V�����N���A����(���Ǎ���/�ۑ���)
            // ADD 2013/03/22 --------------------<<<<<



            return extraInfo;
        }

        /// <summary>
        /// �K�C�h�p�̌��������ݒ菈��
        /// </summary>
        /// <param name="inParm"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�p�̌��������ݒ菈�����s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private CarMngGuideParamWork ConvertHashtableToCarMngGuideParamWork(Hashtable inParm)
        {
            CarMngGuideParamWork paraWork = new CarMngGuideParamWork();
            // ��ƃR�[�h�ݒ�L��
            if (inParm.ContainsKey("EnterpriseCode"))
            {
                paraWork.EnterpriseCode = inParm["EnterpriseCode"].ToString();
            }
            // ��ƃR�[�h�ݒ薳��
            else
            {
                paraWork.EnterpriseCode = this._enterpriseCode;
            }

            // ���Ӑ�`�F�b�N�t���O
            if (inParm.ContainsKey("IsCheckCustomerCode"))
            {
                paraWork.IsCheckCustomerCode = (bool)inParm["IsCheckCustomerCode"];
            }

            // ���Ӑ�R�[�h
            if (inParm.ContainsKey("CustomerCode"))
            {
                paraWork.CustomerCode = (Int32)inParm["CustomerCode"];
            }

            // �Ǘ��ԍ��`�F�b�N�t���O
            if (inParm.ContainsKey("IsCheckCarMngCode"))
            {
                paraWork.IsCheckCarMngCode = (bool)inParm["IsCheckCarMngCode"];
            }

            // �Ǘ��ԍ�
            if (inParm.ContainsKey("CarMngCode"))
            {
                paraWork.CarMngCode = inParm["CarMngCode"].ToString();
            }

            // ���q�Ǘ��敪�`�F�b�N����
            if (inParm.ContainsKey("CheckCarMngCodeType"))
            {
                paraWork.CheckCarMngCodeType = (Int32)inParm["CheckCarMngCodeType"];
            }

            // ���q�Ǘ��敪�`�F�b�N�t���O
            if (inParm.ContainsKey("IsCheckCarMngDivCd"))
            {
                paraWork.IsCheckCarMngDivCd = (bool)inParm["IsCheckCarMngDivCd"];
            }

            return paraWork;
        }

        /// <summary>
        /// �K�C�h�p�̌��������ݒ菈���i���[�N�֕ϊ��j
        /// </summary>
        /// <param name="info">�K�C�h�I�u�W�F�N�g</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �K�C�h�p�̌��������ݒ菈���i���[�N�֕ϊ��j���s���܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// </remarks>
        private CarMngGuideParamWork ConvertCarMngGuideParamInfoToWork(CarMngGuideParamInfo info)
        {
            CarMngGuideParamWork work = new CarMngGuideParamWork();

            work.EnterpriseCode = info.EnterpriseCode;
            work.IsCheckCustomerCode = info.IsCheckCustomerCode;
            work.CustomerCode = info.CustomerCode;
            work.IsCheckCarMngCode = info.IsCheckCarMngCode;
            work.CarMngCode = info.CarMngCode;
            work.CheckCarMngCodeType = info.CheckCarMngCodeType;
            work.IsCheckCarMngDivCd = info.IsCheckCarMngDivCd;

            return work;
        }

        /// <summary>
        /// ���q�Ǘ��K�C�h���������iArrayList�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pArrayList</param>
        /// <param name="paraWork">��������</param>
        /// <param name="isDispCustomerInfo">���Ӑ�\���t���O</param>
        /// <param name="isDispNewRow">�V�K�o�^�s�\���t���O</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��K�C�h�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer : ���w�q</br>
        /// <br>Date       : 2009/09/07</br>
        /// <br>Update Note : wangf</br>
        /// <br>Date		: 2011/08/02</br>
        /// <br>            : PM1107C�@NS���[�U�[���Ǘv�]�ꗗ_PM7����_�A��895�ɏC��</br>
        /// </remarks>
        private int SearchGuide(out ArrayList ds, CarMngGuideParamWork paraWork, bool isDispCustomerInfo, bool isDispNewRow)
        {
            ArrayList ar = new ArrayList();
            ds = new ArrayList();

            int status = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            // "�V�K�o�^"�\�����䔻��
            if (isDispNewRow)
            {
                CarMangInputExtraInfo carMangInfo = new CarMangInputExtraInfo();
                carMangInfo.EnterpriseCode = paraWork.EnterpriseCode;
                carMangInfo.CarMngCode = "�V�K�o�^";
                ar.Add(carMangInfo.Clone());
            }

            Object carMngGuideWorkObj = paraWork as object;
            Object carMngWorkListObj = (new ArrayList()) as object;

            // �����[�g����
            status = this._iCarManagementDB.SearchGuide(carMngGuideWorkObj, out carMngWorkListObj);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                ArrayList carMngWorkList = carMngWorkListObj as ArrayList;
                foreach (CarManagementWork work in carMngWorkList)
                {
                    CarMangInputExtraInfo carMangInfo = new CarMangInputExtraInfo();
                    // ��ƃR�[�h
                    carMangInfo.EnterpriseCode = work.EnterpriseCode;
                    // ���Ӑ�R�[�h
                    carMangInfo.CustomerCode = work.CustomerCode;
                    if (work.CustomerCode != 0)
                    {
                        carMangInfo.CustomerCodeForGuide = work.CustomerCode.ToString().PadLeft(8, '0');
                    }
                    else
                    {
                        carMangInfo.CustomerCodeForGuide = string.Empty;
                    }
                    // ���q�Ǘ��ԍ�
                    carMangInfo.CarMngNo = work.CarMngNo;
                    // �Ǘ��ԍ�                    
                    carMangInfo.CarMngCode = work.CarMngCode;
                    // �Ԏ�
                    carMangInfo.ModelFullName = work.ModelFullName;
                    // �^��
                    carMangInfo.FullModel = work.FullModel;
                    // �ԑ�ԍ�
                    carMangInfo.FrameNo = work.FrameNo;
                    // �o�^�ԍ�
                    // ADD 2013/04/19 SCM��Q��10521�Ή� ---------------------------------->>>>>
                    carMangInfo.NumberPlate1Code = work.NumberPlate1Code;       // ���^�����Ǔo�^�ԍ�
                    carMangInfo.NumberPlate1Name = work.NumberPlate1Name;       // ���^�����ǖ���
                    carMangInfo.NumberPlate2 = work.NumberPlate2;               // �ԗ��o�^�ԍ��i��ʁj
                    carMangInfo.NumberPlate3 = work.NumberPlate3;               // �ԗ��o�^�ԍ��i�J�i�j
                    carMangInfo.NumberPlate4 = work.NumberPlate4;               // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                    // ADD 2013/04/19 SCM��Q��10521�Ή� ----------------------------------<<<<<
                    string plate1Name = work.NumberPlate1Name;      // ���^�����ǖ���
                    string plate2 = work.NumberPlate2;              // �ԗ��o�^�ԍ��i��ʁj
                    string plate3 = work.NumberPlate3;              // �ԗ��o�^�ԍ��i�J�i�j
                    string plate4 = work.NumberPlate4 == 0 ? "" : work.NumberPlate4.ToString();   // �ԗ��o�^�ԍ��i�v���[�g�ԍ��j
                    string plateGuideNm = plate1Name.PadRight(4, '�@') + plate2.PadLeft(3, ' ') + plate3.PadRight(1, '�@') + plate4.PadLeft(4, ' ');
                    carMangInfo.NumberPlateForGuide = plateGuideNm;
                    // -- add wangf 2011/08/02 ---------->>>>>
                    carMangInfo.CarNote = work.CarNote;
                    // -- add wangf 2011/08/02 ----------<<<<<

                    // ���Ӑ於
                    carMangInfo.CustomerName = work.CustomerName;
                    ar.Add(carMangInfo.Clone());
                }
            }

            if (ar.Count != 0)
            {
                ds = ar;
            }
            else
            {
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }

            return status;
        }
        # endregion

        // --- ADD 2013/03/22 ---------->>>>>
        /// <summary>
        /// �n���h���ʒu�`�F�b�N
        /// </summary>
        /// <param name="vinCode">VIN�R�[�h</param>
        /// <returns>true:��v false:�s��v</returns>
        public bool CompareHandlePosition(string vinCode)
        {
            try
            {
                // VIN�R�[�h����n���h���ʒu���擾(�E/���n���h���ȊO�̏ꍇ�̓`�F�b�N���s��Ȃ�)
                HandleInfoCdRet posVin = this._carSearchController.GetHandlePositionFromVinCode(vinCode);
                if (posVin != HandleInfoCdRet.PositionRight && posVin != HandleInfoCdRet.PositionLeft)
                    return true;

                if (this._carInfo != null)
                {
                    // �^�������őI������Ă��邷�ׂĂ̍s���r����
                    int pos = this._carInfo.HandleInfoCdColumn.Ordinal;
                    int state = this._carInfo.SelectionStateColumn.Ordinal;
                    foreach (DataRow row in this._carInfo.Rows)
                    {
                        // �I������Ă��Ȃ��s�̓X�L�b�v����
                        if ((bool)row[state] != true)
                            continue;

                        // �E/���n���h���ȊO��1���ł��������ꍇ�͏����𒆒f���A�ʒu�̃`�F�b�N���s��Ȃ�
                        HandleInfoCdRet posKind = (HandleInfoCdRet)row[pos];
                        if (posKind != HandleInfoCdRet.PositionRight && posKind != HandleInfoCdRet.PositionLeft)
                            return true;

                        // �n���h���ʒu���r����
                        if (posKind == posVin)
                        {
                            // 1���ł��n���h���ʒu����v���Ă���ꍇ�A��v�Ƃ���
                            return true;
                        }
                    }

                    // ���ׂĂ̍s�̃n���h���ʒu���قȂ�ꍇ�A�s��v�Ƃ���
                    return false;
                }
                else
                {
                    // �n���h���ʒu���L���b�V���̃`�F�b�N
                    if (this._handleInfoCode != (int)HandleInfoCdRet.PositionRight && this._handleInfoCode != (int)HandleInfoCdRet.PositionLeft)
                        return true;

                    // �n���h���ʒu���r����
                    return this._handleInfoCode == (int)posVin;
                }
            }
            catch
            {
                // ��O�����������ꍇ�̓`�F�b�N���s��Ȃ�
            }

            return true;
        }
        // ADD 2013/03/22 --------------------<<<<<
    }


        // -- add wangf 2011/08/02 ---------->>>>>
        /// <summary>
        /// ���q�Ǘ��f�[�^��r�N���X(���q�Ǘ��R�[�h(����)�A���Ӑ�R�[�h(����))
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���q�Ǘ��K�C�h�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>           : PM1107C�@NS���[�U�[���Ǘv�]�ꗗ_PM7����_�A��895�ɏC��</br>
        /// <br>Programmer : wangf</br>
        /// <br>Date       : 2011/08/02</br>
        /// </remarks>
        internal class CarMngInputCompareList : Comparer<CarMangInputExtraInfo>
        {
            public override int Compare(CarMangInputExtraInfo x, CarMangInputExtraInfo y)
            {
                int result = x.CarMngCode.CompareTo(y.CarMngCode);
                if (result != 0)
                {
                    if ("�V�K�o�^".Equals(x.CarMngCode))
                        result = -1;
                    if ("�V�K�o�^".Equals(y.CarMngCode))
                        result = 1;
                    return result;
                }

                result = x.CustomerCode.CompareTo(y.CustomerCode);
                return result;
            }
        }
        // -- add wangf 2011/08/02 ----------<<<<<
}