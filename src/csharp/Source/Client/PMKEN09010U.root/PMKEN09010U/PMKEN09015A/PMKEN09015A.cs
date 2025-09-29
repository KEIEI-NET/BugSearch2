//****************************************************************************//
// System           : .NS Series
// Program name     : �D�ǐݒ�}�X�^
// Note             : �D�ǐݒ�̓o�^�E�ύX�E�폜���s��
//----------------------------------------------------------------------------//
//                (c)Copyright  2007 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���F
// �� �� ��  2006/02/15  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30415 �ēc �ύK
// �X �V ��  2008/07/01  �C�����e : ���p/�@�\�ׁ̈A�C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 30452 ��� �r��
// �X �V ��  2008/11/27  �C�����e : ��Q8350
//                                  �D�ǐݒ���擾���̏��i�Ǘ����`�F�b�N���폜
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-01 �쐬�S�� : 20056 ���n ���
// �X �V ��  2009.04.06  �C�����e : ��13066 ���_���ޒǉ��Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10402071-01 �쐬�S�� : 20056 ���n ���
// �X �V ��  2009.05.25  �C�����e : ��12060 �ݒ���e���o�^����Ȃ�
//                                : ��13148 �s���f�[�^���o�^�����
//                                : ��13374 �ݒ���e���폜����Ȃ�
//                                : ��13375 �ݒ���e���\������Ȃ�
//                                : ��13380 ST=5�ŕۑ��ł��Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10600008-00 �쐬�S�� : 30517 �Ė� �x��
// �X �V ��  2010/03/02  �C�����e : ��15083 �����}�X�^�ŕ\�������ꌅ�ŕ\������Ă��܂��f�[�^�����錏�̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���|��
// �X �V ��  2012/09/25�@�C�����e : 2012/10/17�z�M���ARedmine#32367 
//                                  ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A�s����ۂ̑Ή�                             
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : ���|��
// �X �V ��  2012/10/08�@�C�����e : 2012/11/14�z�M���ARedmine#32367 
//                                  ���i�Ǘ����}�X�^�ɓ��̓p�^�[����ǉ������Ɣ����A��Q�Ή�                            
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070266-00 �쐬�S�� : 30757 ���X�؁@�M�p 							
// �C �� ��  2015/02/24  �C�����e : SCM������ �b������ʑΉ�
//                                  �@�ǉ����ڂ̎擾�ƍX�V
//                                    �E�D�ǐݒ�ڍז��̂Q(�H�����)
//                                    �E�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370033-00 �쐬�S�� : �c����
// �X �V ��  2018/10/25�@�C�����e : Redmine#49731 �D�ǐݒ�}�X�^�X�V�����̏�Q�Ή�
//                                  ���i�Ǘ����}�X�^�i�d����j���폜���Ȃ��悤�ɕύX                       
//----------------------------------------------------------------------------//
// TODO:�D�ǐݒ�O���[�v=0��L���ȃO���[�v�Ƃ���ꍇ�A��`����L���ɂ��� ���������A�����[�X���͖����Ƃ��邱��
//#define _EXISTS_GROUP0_
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Text;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
//using Broadleaf.Library.Text;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Resources;
using Broadleaf.Library.Resources;  // ADD 2008/07/01
using Broadleaf.Application.Common;
using Broadleaf.Application.Controller.Util;    // ADD 2009/01/14 �d�l�ύX�F�����ނ̂�������\������

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// �D�ǐݒ�R���g���[��
    /// </summary>
    /// <remarks>
    /// <br>UpdateNote : 2008/07/01 30415 �ēc �ύK ���p/�@�\�ǉ��ׁ̈A�C��</br>
    /// <br>UpdateNote : 2009.04.06 20056 ���n ��� ��13066 ���_���ޒǉ��Ή�</br>
    /// <br>UpdateNote : 2009.05.25 20056 ���n ��� ��12060 �ݒ���e���o�^����Ȃ�</br>
    /// <br>                                        ��13148 �s���f�[�^���o�^�����</br>
    /// <br>                                        ��13374 �ݒ���e���폜����Ȃ�</br>
    /// <br>                                        ��13375 �ݒ���e���\������Ȃ�</br>
    /// <br>                                        ��13380 ST=5�ŕۑ��ł��Ȃ�</br>
    /// <br></br>
    /// <br>Update Note: 11070266-00�@SCM������ �b������ʑΉ� </br>
    /// <br>Programmer : 30757 ���X�� �M�p</br>
    /// <br>Date       : 2015/02/24</br>
    /// <br></br>
    /// </remarks>
    //public class PrimeSettingController  // DEL 2008/07/01
    public class PrimeSettingAcs           // ADD 2008/07/01
	{
        # region Constracter
        public PrimeSettingAcs()
		{
            try
            {
                this._dataSet = new DataSet();
                /// <summary>������-�i��-���[�J�[���X�g</summary>
                this._dataSet.Tables.Add(CreateTable(MG_BL_MK_TABLENAME));
                /// <summary>�D�ǐݒ胊�X�g</summary>
                this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_PRIMESETTING));
                /// <summary>�񋟗D�ǐݒ胊�X�g</summary>
                this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_OFFER_PRIMESETTING));
                /// <summary>���[�U�[�D�ǐݒ胊�X�g</summary>
                this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_USER_PRIMESETTING));

                //���[�U�[�폜���X�g(�񋟂Ɩ������o�����R�[�h�̍폜�j
                _UserDeleteList = new ArrayList();
                //���[�U�[�X�V���X�g
                _UserPrimeSettingList = new ArrayList();
                //�D�ǐݒ胊�X�g
                _PrimeSettingList = new Hashtable();
                //���i���[�J�[���X�g
                _PartsMakerList = new Hashtable();
                //BL���i���X�g
                _TbsPartsCodeList = new Hashtable();
                //�����ރ��X�g
                _MiddleGenreList = new Hashtable();
                //������-�i��-���[�J�[���X�g
                _Mg_Bl_Mk_List = new Hashtable();
                //�D�ǐݒ���l���X�g
                _PrimeSettingNoteList = new Hashtable();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                _SupplierList = new Hashtable();
                _GoodsMngList = new Hashtable();
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // �����[�g�I�u�W�F�N�g�擾
                /* --- DEL 2008/07/01 -------------------------------->>>>>
                //primeSettingSearchDB = (IPrimeSettingDB)MediationPrimeSettingDB.GetPrimeSettingDB();
                //offerPrimeSettingSearchDB = (IOfferPrimeSettingDB)MediationOfferPrimeSettingDB.GetOfferPrimeSettingDB();
                //offerTbsPartsCodeDB = (IOfferTbsPartsCodeDB)MediationOfferTbsPartsCodeDB.GetTbsPartsCodeDB();
                //offerMiddleGenreDB = (IOfferMiddleGenreDB)MediationOfferMiddleGenreDB.GetOfferMiddleGenreDB();
                   --- DEL 2008/07/01 --------------------------------<<<<< */

                // --- ADD 2008/07/01 -------------------------------->>>>>
                goodsMngDB = (IGoodsMngDB)MediationGoodsMngDB.GetGoodsMngDB();
                primeSettingSearchDB = (IPrmSettingUDB)MediationPrmSettingUDB.GetPrmSettingUDB();
                offerPrimeSettingSearchDB = (IPrimeSettingDB)MediationPrimeSettingDB.GetPrimeSettingDB();
                offerTbsPartsCodeDB = (ITbsPartsCodeDB)MediationTbsPartsCodeDB.GetTbsPartsCodeDB();
                offerMiddleGenreDB = (IGoodsMGroupDB)MediationGoodsMGroupDB.GetGoodsMGroupDB();
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                pMakerNmDB = (IPMakerNmDB)MediationPMakerNmDB.GetPMakerNmDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                //this._iCutomerInfoSetDB = null;
                //this._iTxtOutCarInfoSetDB = null;
            }
        }
        # endregion

        # region Private Buffers
        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;
        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>���_�R�[�h</summary>
        private string _sectionCode;
        // --- ADD 2008/07/01 --------------------------------<<<<< 
        /// <summary>��{�ݒ�̃^�uID</summary>
        private int _navigeteIndex;//0:MK_BL 1:MG_BL 
        /// <summary>�V�[�N���b�g���[�h</summary>
        private bool _secretMode=true;
        /// <summary>���[�U�[�D�ǐݒ胊���[�g</summary>
        //private IPrimeSettingDB primeSettingSearchDB = null;  // DEL 2008/07/01
        private IPrmSettingUDB primeSettingSearchDB = null;     // ADD 2008/07/01

        /// <summary>�񋟗D�ǐݒ胊���[�g</summary>
        //private IOfferPrimeSettingDB offerPrimeSettingSearchDB = null;  // DEL 2008/07/01
        private IPrimeSettingDB offerPrimeSettingSearchDB = null;         // ADD 2008/07/01

        /// <summary>���[�J�[���̎擾�����[�g</summary>
        private IPMakerNmDB pMakerNmDB = null;

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>���i�Ǘ����擾�����[�g</summary>
        private IGoodsMngDB goodsMngDB = null;
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        /// <summary>BL�R�[�h���X�g�擾�����[�g</summary>
        //private IOfferTbsPartsCodeDB offerTbsPartsCodeDB = null;  // DEL 2008/07/01
        private ITbsPartsCodeDB offerTbsPartsCodeDB = null;         // ADD 2008/07/01

        /// <summary>�����ރR�[�h���X�g�擾�����[�g</summary>
        //private IOfferMiddleGenreDB offerMiddleGenreDB = null;
        private IGoodsMGroupDB offerMiddleGenreDB = null;

        /// <summary>�f�[�^�Z�b�g</summary>
        private DataSet _dataSet = null;

        /// <summary>�񋟍X�V���X�g</summary>
        private ArrayList _UserDeleteList = null;
        /// <summary>���[�U�[�X�V���X�g</summary>
        private ArrayList _UserPrimeSettingList = null;
        /// <summary>�D�ǐݒ胊�X�g</summary>
        private Hashtable _PrimeSettingList = null;
        /// <summary>���i���[�J�[���X�g</summary>
        private Hashtable _PartsMakerList = null;
        /// <summary>BL���i���X�g</summary>
        private Hashtable _TbsPartsCodeList = null;
        /// <summary>���i���[�J�[���X�g</summary>
        private Hashtable _MiddleGenreList = null;
        /// <summary>������-�i��-���[�J�[���X�g</summary>
        private Hashtable _Mg_Bl_Mk_List = null;
        /// <summary>�D�ǐݒ���l���X�g</summary>
        private Hashtable _PrimeSettingNoteList = null;

        private DataTable _originalPrimeSettingTable;

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>���i�Ǘ���񃊃X�g</summary>
        private Hashtable _GoodsMngList = null;

        struct F_KEY_GOODSMNGLIST
        {
            public int goodsMGroup; // ADD 2009/01/26 �d�l�ύX�F���i�Ǘ����ɒ����ރR�[�h��ǉ�
            public int goodsMakerCd;  // ���i���[�J�[�R�[�h
            public int blGoodsCode;   // BL���i�R�[�h
            //public string goodsNo;    // ���i�ԍ�
        }

        /// <summary>�d���惊�X�g</summary>
        private Hashtable _SupplierList = null;
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        // ADD 2009/01/14 �d�l�ύX �����ރR�[�h�̂�������\�� ---------->>>>>
        /// <summary>���[�J�[���X�g</summary>
        private readonly MakerAgreegate _makerList = new MakerAgreegate();
        /// <summary>
        /// ���[�J�[���X�g���擾���܂��B
        /// </summary>
        /// <value>���[�J�[���X�g</value>
        private MakerAgreegate MakerList { get { return _makerList; } }
        // ADD 2009/01/14 �d�l�ύX �����ރR�[�h�̂�������\�� ----------<<<<<
        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
        /// <summary>�֘ABL�R�[�h</summary>
        private readonly RelatedBLCodeAgreegate _relatedBLCode = new RelatedBLCodeAgreegate();
        /// <summary>
        /// �֘ABL�R�[�h���擾���܂��B
        /// </summary>
        /// <value>�֘ABL�R�[�h</value>
        private RelatedBLCodeAgreegate RelatedBLCode { get { return _relatedBLCode; } }
        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<

        /// <summary>
        /// ��ƃR�[�h
        /// </summary>
        public string EnterPriseCode
        {
            get { return this._enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>
        /// ���_�R�[�h
        /// </summary>
        public string SectionCode
        {
            get { return this._sectionCode; }
            set { _sectionCode = value; }
        }
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        /// <summary>
        /// �ݒ�^�u�C���f�b�N�X
        /// </summary>
        public int NavigeteIndex
        {
            get { return this._navigeteIndex; }
            set { _navigeteIndex = value; }
        }

        /// <summary>
        /// ������-�i��-���[�J�[�e�[�u��
        /// </summary>
        public DataTable Mg_Bl_MkTable
        {
            get { return this._dataSet.Tables[MG_BL_MK_TABLENAME]; }
        }
        /// <summary>
        /// ������-�i��-���[�J�[View
        /// </summary>
        public DataView Mg_Bl_MkView
        {
            get { return this._dataSet.Tables[MG_BL_MK_TABLENAME].DefaultView; }
        }

        /// <summary>
        /// �D�ǐݒ�e�[�u��(�񋟁A���[�U�[���}�[�W�j
        /// </summary>
        public DataTable PrimeSettingTable
        {
            get { return this._dataSet.Tables[PrimeSettingInfo.TABLENAME_PRIMESETTING]; }
        }

        /// <summary>
        /// �D�ǐݒ�View
        /// </summary>
        public DataView PrimeSettingView
        {
            get { return this._dataSet.Tables[PrimeSettingInfo.TABLENAME_PRIMESETTING].DefaultView; }
        }

        /// <summary>
        /// �񋟗D�ǐݒ�e�[�u��
        /// </summary>
        public DataTable OfferPrimeSettingTable
        {
            get { return this._dataSet.Tables[PrimeSettingInfo.TABLENAME_OFFER_PRIMESETTING]; }
        }

        /// <summary>
        /// հ�ް�D�ǐݒ�e�[�u��
        /// </summary>
        public DataTable UserPrimeSettingTable
        {
            get { return this._dataSet.Tables[PrimeSettingInfo.TABLENAME_USER_PRIMESETTING]; }
        }

        public DataTable OriginalPrimeSettingTable
        {
            get { return this._originalPrimeSettingTable; }
        }

        public DataView OriginalPrimeSettingView
        {
            get { return this._originalPrimeSettingTable.DefaultView; }
        }

        /// <summary>
        /// ������-�i��-���[�J�[���X�g
        /// </summary>
        /// <remarks>
        /// �L�[�F�����ރR�[�h("0000") + ���[�J�[�R�[�h("0000") + BL�R�[�h("00000000")
        /// </remarks>
        public Hashtable Mg_Bl_Mk_List
        {
            get { return _Mg_Bl_Mk_List; }
        }

        public Hashtable OfferPrimeSettingNote
        {
            get { return _PrimeSettingNoteList; }
        }

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>
        /// ���i�Ǘ���񃊃X�g
        /// </summary>
        public Hashtable GoodsMng
        {
            get { return _GoodsMngList; }
        }
        // --- ADD 2008/07/01 --------------------------------<<<<< 


        public bool SecretMode
        {
            get { return _secretMode; }
            set { _secretMode = value; }
        }   

        public string SecretCode
        {
            get {
                if (SecretMode)
                {
                    return SECRETFILTER;
                }
                else 
                {
                    return "";
                }
            }
        }

        // ADD 2009/01/21 �s��Ή�[6970] ---------->>>>>
        /// <summary>�D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h�̏W����</summary>
        private readonly UserPrimeSettingAgreegate _userPrimeSettingRecords = new UserPrimeSettingAgreegate();
        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h�̏W���̂��擾���܂��B
        /// </summary>
        /// <value>�D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h�̏W����</value>
        private UserPrimeSettingAgreegate UserPrimeSettingRecords { get { return _userPrimeSettingRecords; } }
        // ADD 2009/01/21 �s��Ή�[6970] ----------<<<<<

        # endregion // [Private Buffer]

        # region Public Method
        //public void DataSearch()  // DEL 2008/07/01
        public int DataSearch()     // ADD 2008/07/01
        {
            int status = -1;  // ADD 2008/07/01

            try
            {
                //�����Ń����[�g����f�[�^��ǂݍ���
                //��Ɋe��}�X�^�ǂݍ���

                // --- ADD 2008/07/01 -------------------------------->>>>>
                // �d����Ǎ���
                status = getSupplierList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) && 
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) && 
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // ���i�Ǘ����}�X�^�Ǎ���
                status = getGoodsMngList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // ���i���[�J�[���̓ǂݍ���
                status = getPartsMakerList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // ��BL�R�[�h�ǂݍ���
                status = getOfferTbsPartsList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // �񋟒����ޓǂݍ���
                status = getOfferMiddleGenreList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // �񋟗D�ǐݒ�ǂݍ���
                status = getOfferPrimesettingList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // �񋟗D�ǐݒ���l�ǂݍ���
                status = getOfferPrimeSettingNoteList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // հ�ް�D�ǐݒ�ǂݍ���
                status = getUserPrimesettingList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                // ���X�g�쐬
                status = getMG_BL_MKCdList();

                // --- ADD 2008/07/01 -------------------------------->>>>>
                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<<

                Debug.WriteLine("�D�ǐݒ背�R�[�h���F" + this.PrimeSettingTable.Rows.Count.ToString() + "(" + this._PrimeSettingList.Count.ToString() + ")");
                Debug.WriteLine("�폜���X�g��(���[�U�[�ɂ����āA�񋟂ɂȂ���)�F" + this._UserDeleteList.Count.ToString());
                Debug.WriteLine("���i�Ǘ���񐔁F" + this.GoodsMng.Count.ToString());
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        // 2009.04.06 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �D�ǐݒ�Ď擾
        /// </summary>
        /// <returns></returns>
        public int DataSearchOnlyPrmInfo()
        {
            int status = -1;

            this._dataSet = new DataSet();
            this._dataSet.Tables.Add(CreateTable(MG_BL_MK_TABLENAME));
            this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_PRIMESETTING));
            this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_OFFER_PRIMESETTING));
            this._dataSet.Tables.Add(CreateTable(PrimeSettingInfo.TABLENAME_USER_PRIMESETTING));

            //���[�U�[�폜���X�g(�񋟂Ɩ������o�����R�[�h�̍폜�j
            _UserDeleteList = new ArrayList();
            //���[�U�[�X�V���X�g
            _UserPrimeSettingList = new ArrayList();
            //�D�ǐݒ胊�X�g
            _PrimeSettingList = new Hashtable();
            //���i���[�J�[���X�g
            _PartsMakerList = new Hashtable();
            //BL���i���X�g
            _TbsPartsCodeList = new Hashtable();
            //�����ރ��X�g
            _MiddleGenreList = new Hashtable();
            //������-�i��-���[�J�[���X�g
            _Mg_Bl_Mk_List = new Hashtable();
            //�D�ǐݒ���l���X�g
            _PrimeSettingNoteList = new Hashtable();

            _SupplierList = new Hashtable();
            _GoodsMngList = new Hashtable();

            try
            {
                //�����Ń����[�g����f�[�^��ǂݍ���
                //��Ɋe��}�X�^�ǂݍ���

                // �d����Ǎ���
                status = getSupplierList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // ���i�Ǘ����}�X�^�Ǎ���
                status = getGoodsMngList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // ���i���[�J�[���̓ǂݍ���
                status = getPartsMakerList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // ��BL�R�[�h�ǂݍ���
                status = getOfferTbsPartsList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // �񋟒����ޓǂݍ���
                status = getOfferMiddleGenreList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // �񋟗D�ǐݒ�ǂݍ���
                status = getOfferPrimesettingList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // �񋟗D�ǐݒ���l�ǂݍ���
                status = getOfferPrimeSettingNoteList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // հ�ް�D�ǐݒ�ǂݍ���
                status = getUserPrimesettingList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                // ���X�g�쐬
                status = getMG_BL_MKCdList();

                if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                    (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    return status;
                }

                Debug.WriteLine("�D�ǐݒ背�R�[�h���F" + this.PrimeSettingTable.Rows.Count.ToString() + "(" + this._PrimeSettingList.Count.ToString() + ")");
                Debug.WriteLine("�폜���X�g��(���[�U�[�ɂ����āA�񋟂ɂȂ���)�F" + this._UserDeleteList.Count.ToString());
                Debug.WriteLine("���i�Ǘ���񐔁F" + this.GoodsMng.Count.ToString());
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }
        // 2009.04.06 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �񋟃f�[�^���ύX����Ă��Ȃ������`�F�b�N����
        /// </summary>
        /// <returns>�G���[����</returns>
        public int chekcOfferPrimeSettingList()
        {
            string rowfilter = PrimeSettingView.RowFilter;
            string sort = PrimeSettingView.Sort;

            PrimeSettingView.RowFilter = String.Format("{0}>0", PrimeSettingInfo.COL_PRIMEDISPLAYCODE);
            foreach (DataRowView drv in PrimeSettingView)
            {
                /* --- DEL 2008/07/01 -------------------------------->>>>>
                //OfferPrimeSettingWork offerdrv = (OfferPrimeSettingWork)drv[COL_OFFERPRIMESETTING];

                //if ((PrimeSettingWork)drv[COL_USERPRIMESETTING] == null) continue;

                //PrimeSettingWork userdrv = (PrimeSettingWork)drv[COL_USERPRIMESETTING];
                   --- DEL 2008/07/01 --------------------------------<<<<< */

                // --- ADD 2008/07/01 -------------------------------->>>>>
                PrmSettingWork offerdrv = (PrmSettingWork)drv[COL_OFFERPRIMESETTING];
                
                if ((PrmSettingUWork)drv[COL_USERPRIMESETTING] == null) continue;
                
                PrmSettingUWork userdrv = (PrmSettingUWork)drv[COL_USERPRIMESETTING];
                // --- ADD 2008/07/01 --------------------------------<<<<< 

                /* --- DEL 2008/07/01 -------------------------------->>>>>
                //�D�ǎ�ʖ��̂��ύX����Ă���ꍇ�B
                if ( offerdrv.Prm .PrimeKindName != userdrv.PrimeKindName)
                {
                    //���͉������Ȃ�(�ύX���X�g��\������H�j
                }
                //�񋟂��폜���ꂽ�ꍇ�A���[�U�[�f�[�^�͖����ɂȂ�̂Ń��X�g�A�b�v���č폜�ɂ���(�񋟂������̂ŉ�ʂɂ͏o�Ȃ�)
                if ((offerdrv.LogicalDeleteCode != 0) && (userdrv.LogicalDeleteCode == 0))
                {
                    //���͉������Ȃ�
                }
                   --- DEL 2008/07/01 --------------------------------<<<<< */
            }
            PrimeSettingView.RowFilter = rowfilter;
            PrimeSettingView.Sort = sort;
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prmSettingUWork"></param>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: 11070266-00�@SCM������ �b������ʑΉ� </br>
        /// <br>             ���ڒǉ��i�D�ǐݒ�ڍז��̂Q(�H�����)�A�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�j</br>
        /// <br>Programmer : 30757 ���X�� �M�p</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        private PrmSettingUWork CreatePrmSettingUWorkWhatBLCodeIs0(PrmSettingUWork prmSettingUWork)
        {
            PrmSettingUWork blCodeIs0 = UserPrimeSettingRecords.Find(
                prmSettingUWork.GoodsMGroup,
                0,
                prmSettingUWork.PartsMakerCd,
                0,
                0
            );
            
            if (blCodeIs0 == null)
            {
                blCodeIs0 = new PrmSettingUWork();

                if (prmSettingUWork.TbsPartsCode.Equals(0))
                {
                    blCodeIs0.CreateDateTime = prmSettingUWork.CreateDateTime;
                    blCodeIs0.FileHeaderGuid = prmSettingUWork.FileHeaderGuid;
                    blCodeIs0.LogicalDeleteCode = prmSettingUWork.LogicalDeleteCode;
                    blCodeIs0.UpdAssemblyId1 = prmSettingUWork.UpdAssemblyId1;
                    blCodeIs0.UpdAssemblyId2 = prmSettingUWork.UpdAssemblyId2;
                    blCodeIs0.UpdateDateTime = prmSettingUWork.UpdateDateTime;
                    blCodeIs0.UpdEmployeeCode = prmSettingUWork.UpdEmployeeCode;
                }
                blCodeIs0.EnterpriseCode = prmSettingUWork.EnterpriseCode;
                blCodeIs0.GoodsMGroup = prmSettingUWork.GoodsMGroup;
                blCodeIs0.MakerDispOrder = prmSettingUWork.MakerDispOrder;
                blCodeIs0.OfferDate = prmSettingUWork.OfferDate;
                blCodeIs0.PartsMakerCd = prmSettingUWork.PartsMakerCd;
                blCodeIs0.PrimeDisplayCode = prmSettingUWork.PrimeDisplayCode;
                blCodeIs0.PrimeDispOrder = prmSettingUWork.PrimeDispOrder;
                blCodeIs0.PrmSetDtlName1 = prmSettingUWork.PrmSetDtlName1;
                blCodeIs0.PrmSetDtlName2 = prmSettingUWork.PrmSetDtlName2;
                blCodeIs0.PrmSetDtlNo1 = prmSettingUWork.PrmSetDtlNo1;
                blCodeIs0.PrmSetDtlNo2 = prmSettingUWork.PrmSetDtlNo2;
                blCodeIs0.SectionCode = prmSettingUWork.SectionCode;
                blCodeIs0.TbsPartsCdDerivedNo = prmSettingUWork.TbsPartsCdDerivedNo;
                blCodeIs0.TbsPartsCode = prmSettingUWork.TbsPartsCode;

                blCodeIs0.TbsPartsCode = 0;
                blCodeIs0.TbsPartsCdDerivedNo = 0;
                blCodeIs0.PrimeDispOrder = 0;
                blCodeIs0.PrmSetDtlNo1 = 0;
                blCodeIs0.PrmSetDtlName1 = string.Empty;
                blCodeIs0.PrmSetDtlNo2 = 0;
                blCodeIs0.PrmSetDtlName2 = string.Empty;
                //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                blCodeIs0.PrmSetDtlName2ForFac = string.Empty;
                blCodeIs0.PrmSetDtlName2ForCOw = string.Empty;
                //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<
            }

            blCodeIs0.PrimeDisplayCode = 2; // �����[�g����0�ɂ��Ă����
            return blCodeIs0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prmSettingUWork"></param>
        /// <returns></returns>
        private GoodsMngWork CreateGoodsMngWorkWhatBLCodeIs0(PrmSettingUWork prmSettingUWork)
        {
            GoodsMngWork goodsMngWork = null;

            F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();
            {
                keyGoodsMngList.goodsMGroup = prmSettingUWork.GoodsMGroup;
                keyGoodsMngList.goodsMakerCd = prmSettingUWork.PartsMakerCd;
                keyGoodsMngList.blGoodsCode = 0;
            }
            if (this._GoodsMngList[keyGoodsMngList] != null)
            {
                goodsMngWork = (GoodsMngWork)this._GoodsMngList[keyGoodsMngList];
            }
            else
            {
                goodsMngWork = new GoodsMngWork();
                {
                    goodsMngWork.EnterpriseCode = prmSettingUWork.EnterpriseCode;
                    goodsMngWork.SectionCode    = prmSettingUWork.SectionCode;
                    goodsMngWork.GoodsMGroup    = prmSettingUWork.GoodsMGroup;
                    goodsMngWork.GoodsMakerCd   = prmSettingUWork.PartsMakerCd;
                    goodsMngWork.BLGoodsCode    = 0;
                    goodsMngWork.GoodsNo        = string.Empty;
                    goodsMngWork.SupplierCd     = 0;
                    goodsMngWork.SupplierLot    = 0;
                }
            }

            goodsMngWork.SupplierCd = GetSupplierCodeWhatBLCodeIs0(goodsMngWork.GoodsMGroup, goodsMngWork.GoodsMakerCd);

            return goodsMngWork;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 11070266-00�@SCM������ �b������ʑΉ� </br>
        /// <br>             ���ڒǉ��i�D�ǐݒ�ڍז��̂Q(�H�����)�A�D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)�j</br>
        /// <br>Programmer : 30757 ���X�� �M�p</br>
        /// <br>Date       : 2015/02/24</br>
        /// <br></br>
        /// </remarks>
        public int updatePrimeSettingList(out string errorMessage)
        {
            // �y�ۑ��z�d����R�[�h�̓��̓`�F�b�N
            if (!HasSupplierCodeOfAllMg_Bl_MkView(out errorMessage))
            {
                return UPDATE_CHECK_ERROR;
            }

            string rowfilter = PrimeSettingView.RowFilter;
            string sort = PrimeSettingView.Sort;

            PrimeSettingView.RowFilter = "";
            PrimeSettingView.Sort = "";

            // �\�����ʁA�ύX�t���O�A�`�F�b�N��Ԃ�D�ǐݒ胊�X�g�ɃZ�b�g
            updateCheckPrimeSettingList();

            Dictionary<String, PrmSettingUWork> prmSettingUWorkDic = new Dictionary<String, PrmSettingUWork>();
            Dictionary<String, Int32> supplierCodeDic = new Dictionary<String, Int32>();
            ArrayList deleteList = new ArrayList();

            //---------------------------------------------
            // ���͎d����R�[�h�ꗗ���擾
            //---------------------------------------------
            foreach (DataRowView mgBLMkRow in Mg_Bl_MkView)
            {
                // ���ʐݒ背�R�[�h�͖���
                if (IsCommonRowOfMiddleGBLMakerDataTable(mgBLMkRow)) continue;

                if (((CheckState)mgBLMkRow[COL_CHECKSTATE]).Equals(CheckState.Unchecked) &&
                    !((Int32)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0))
                {
                    continue;
                }

                int goodsMGroup = (Int32)mgBLMkRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int goodsMakerCd = (Int32)mgBLMkRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                int blGoodsCode = (Int32)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE];

                int supplierCd = 0;
                if (mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
                {
                    supplierCd = (Int32)mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD];
                }

                string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(goodsMGroup, blGoodsCode, goodsMakerCd);

                if (!supplierCodeDic.ContainsKey(key))
                {
                    supplierCodeDic.Add(key, supplierCd);
                }
                else
                {
                    if (supplierCd != 0)
                    {
                        supplierCodeDic[key] = supplierCd;
                    }
                }
            }

            //---------------------------------------------
            // �ۑ��ΏہA�폜�Ώۂ̗D�ǐݒ�}�X�^�擾
            //---------------------------------------------
            foreach (DataRowView primeSettingRow in PrimeSettingView)
            {
                int middleGenreCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int makerCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                int blCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
                int selectCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE];
                int prmSetDtl = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];

                string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl);

                if (primeSettingRow[COL_USERPRIMESETTING] == System.DBNull.Value &&
                    UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl) == null)
                {
                    //----------------------------
                    // �񋟃f�[�^
                    //----------------------------

                    // �`�F�b�N�����Ă��Ȃ��ꍇ�͏������Ȃ�
                    if ((CheckState)primeSettingRow[COL_CHECKSTATE] == CheckState.Unchecked)
                    {
                        continue;
                    }

                    // �\���Ȃ��̏ꍇ�͏������Ȃ�
                    if ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
                    {
                        continue;
                    }

                    PrmSettingUWork prmSettingUWork = new PrmSettingUWork();
                    prmSettingUWork.EnterpriseCode = this._enterpriseCode;                                          // ��ƃR�[�h
                    prmSettingUWork.SectionCode = this._sectionCode;                                                // ���_�R�[�h
                    prmSettingUWork.MakerDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
                    prmSettingUWork.PrimeDisplayCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                    prmSettingUWork.PrimeDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER];     // �D�Ǖ\������
                    prmSettingUWork.GoodsMGroup = (Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];     // ���i�����ރR�[�h
                    prmSettingUWork.PartsMakerCd = (Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                    prmSettingUWork.TbsPartsCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
                    prmSettingUWork.TbsPartsCdDerivedNo = (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO];
                    prmSettingUWork.PrmSetDtlNo1 = (Int32)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE];         // �Z���N�g�R�[�h
                    prmSettingUWork.PrmSetDtlName1 = (String)primeSettingRow[PrimeSettingInfo.COL_SELECTNAME];      // �D�ǐݒ�ڍז��̂P
                    prmSettingUWork.PrmSetDtlNo2 = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];      // ��ʃR�[�h
                    prmSettingUWork.PrmSetDtlName2 = (String)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME];   // �D�ǐݒ�ڍז��̂Q
                    //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                    PrmSettingWork offerPrmSettingWork = (PrmSettingWork)primeSettingRow[COL_OFFERPRIMESETTING];
                    prmSettingUWork.PrmSetDtlName2ForFac = offerPrmSettingWork.PrmSetDtlName2ForFac;   // �D�ǐݒ�ڍז��̂Q(�H�����)
                    prmSettingUWork.PrmSetDtlName2ForCOw = offerPrmSettingWork.PrmSetDtlName2ForCOw;   // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                    //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<

                    // BL�R�[�h��0�̏ꍇ�A�D�Ǖ\���敪��2�ɍ׍H�@�������[�g���ŏ������ލۂɁA�����I��0�ɂ���
                    if (prmSettingUWork.TbsPartsCode.Equals(0))
                    {
                        prmSettingUWork.PrimeDisplayCode = 2;
                    }

                    if (!prmSettingUWorkDic.ContainsKey(key))
                    {
                        prmSettingUWorkDic.Add(key, prmSettingUWork);
                    }

                    // BL�R�[�h��0�̃f�[�^���쐬
                    if (!prmSettingUWork.TbsPartsCode.Equals(0))
                    {
                        PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(prmSettingUWork);
                        key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(middleGenreCode, 0, makerCode, 0, 0);

                        if (!prmSettingUWorkDic.ContainsKey(key))
                        {
                            prmSettingUWorkDic.Add(key, bl0PrmSettingUWork);
                        }
                    }
                }
                else
                {
                    //----------------------------
                    // ���[�U�[�f�[�^
                    //----------------------------

                    if ((primeSettingRow[COL_USERPRIMESETTING] == DBNull.Value) ||
                        (UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl) == null))
                    {
                        continue;
                    }

                    PrmSettingWork offerPrmSettingWork = (PrmSettingWork)primeSettingRow[COL_OFFERPRIMESETTING];
                    PrmSettingUWork userPrmSettingUWork = (PrmSettingUWork)primeSettingRow[COL_USERPRIMESETTING];

                    // �`�F�b�N�����Ă��Ȃ��ꍇ�͍폜�Ώ�
                    if ((CheckState)primeSettingRow[COL_CHECKSTATE] == CheckState.Unchecked)
                    {
                        // BL�R�[�h��0�ȊO�̃f�[�^
                        if (!userPrmSettingUWork.TbsPartsCode.Equals(0))
                        {
                            deleteList.Add(userPrmSettingUWork);
                        }
                    }
                    else
                    {
                        if ((userPrmSettingUWork.MakerDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER]) &&
                            (userPrmSettingUWork.PrimeDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER]) &&
                            (userPrmSettingUWork.PrimeDisplayCode == (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]))
                        {
                            // �ύX����Ă��Ȃ��ꍇ

                            // �d����R�[�h���ύX�̔���ɉ�����
                            string where = GetWhere(userPrmSettingUWork.PartsMakerCd, userPrmSettingUWork.GoodsMGroup, userPrmSettingUWork.TbsPartsCode);
                            DataRow[] foundDataRows = this.PrimeSettingTable.Select(where);
                            if (!(bool)foundDataRows[0][COL_CHANGEFLAG])
                            {
                                continue;
                            }
                        }

                        // �ύX����Ă���ꍇ

                        // �D�Ǖ\���敪���u�\�������v�ɕύX���ꂽ�ꍇ�A�폜�Ώ�
                        if (((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]).Equals(0))
                        {
                            // BL�R�[�h��0�ȊO�̃f�[�^
                            if (!userPrmSettingUWork.TbsPartsCode.Equals(0))
                            {
                                deleteList.Add(userPrmSettingUWork);
                            }

                            continue;
                        }

                        userPrmSettingUWork.MakerDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
                        userPrmSettingUWork.PrimeDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER];
                        userPrmSettingUWork.PrimeDisplayCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
                        userPrmSettingUWork.PrmSetDtlName2 = (String)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME];
                        
                        if (userPrmSettingUWork.TbsPartsCode.Equals(0))
                        {
                            // BL�R�[�h��0�̏ꍇ�A�D�Ǖ\���敪��2�ɍ׍H�@�������[�g���ŏ������ލۂɁA�����I��0�ɂ���
                            userPrmSettingUWork.PrimeDisplayCode = 2;
                        }

                        if (!prmSettingUWorkDic.ContainsKey(key))
                        {
                            prmSettingUWorkDic.Add(key, userPrmSettingUWork);
                        }

                        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ---------------->>>>>
                        userPrmSettingUWork.PrmSetDtlName2ForFac = offerPrmSettingWork.PrmSetDtlName2ForFac;   // �D�ǐݒ�ڍז��̂Q(�H�����)
                        userPrmSettingUWork.PrmSetDtlName2ForCOw = offerPrmSettingWork.PrmSetDtlName2ForCOw;   // �D�ǐݒ�ڍז��̂Q(�J�[�I�[�i�[����)
                        //---ADD�@30757 ���X�؁@�M�p�@2015/02/24 11070266-00�@SCM������ �b������ʑΉ� ----------------<<<<<

                        // BL�R�[�h��0�̃f�[�^���쐬
                        if (!userPrmSettingUWork.TbsPartsCode.Equals(0))
                        {
                            PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(userPrmSettingUWork);
                            key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(middleGenreCode, 0, makerCode, 0, 0);

                            if (!prmSettingUWorkDic.ContainsKey(key))
                            {
                                prmSettingUWorkDic.Add(key, bl0PrmSettingUWork);
                            }
                        }
                    }
                }
            }

            //---------------------------------------------
            // �ۑ��Ώۂ̏��i�Ǘ����}�X�^�擾
            //---------------------------------------------
            Dictionary<String, GoodsMngWork> goodsMngWorkDic = new Dictionary<string, GoodsMngWork>();
            foreach (PrmSettingUWork work in prmSettingUWorkDic.Values)
            {
                F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();
                keyGoodsMngList.goodsMGroup = work.GoodsMGroup;
                keyGoodsMngList.goodsMakerCd = work.PartsMakerCd;
                keyGoodsMngList.blGoodsCode = work.TbsPartsCode;

                string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup, work.TbsPartsCode, work.PartsMakerCd);

                if (_GoodsMngList[keyGoodsMngList] == null)
                {
                    // ���i�Ǘ���񃊃X�g�Ƀf�[�^�Ȃ����V�K�쐬

                    GoodsMngWork goodsMngWork = new GoodsMngWork();
                    goodsMngWork.EnterpriseCode = this._enterpriseCode;
                    goodsMngWork.SectionCode = this._sectionCode;
                    goodsMngWork.GoodsMakerCd = work.PartsMakerCd;
                    goodsMngWork.BLGoodsCode = work.TbsPartsCode;
                    goodsMngWork.GoodsMGroup = work.GoodsMGroup;

                    if (supplierCodeDic.ContainsKey(key))
                    {
                        goodsMngWork.SupplierCd = supplierCodeDic[key];
                    }

                    
                    if (goodsMngWork.BLGoodsCode.Equals(0))
                    {
                        goodsMngWork.GoodsNo = string.Empty;
                        goodsMngWork.SupplierLot = 0;

                        // ----- DEL 2012/09/25 xupz for redmine#32367----->>>>>
                        // BL�R�[�h=0�̎d����R�[�h
                        //goodsMngWork.SupplierCd = GetSupplierCodeWhatBLCodeIs0(work.GoodsMGroup, work.PartsMakerCd);
                        // ----- DEL 2012/09/25 xupz for redmine#32367-----<<<<<
                    }
                    

                    if (!goodsMngWorkDic.ContainsKey(key))
                    {
                        goodsMngWorkDic.Add(key, goodsMngWork);
                    }
                }
                else
                {
                    // ���i�Ǘ���񃊃X�g�Ƀf�[�^���聨�X�V

                    // ���i�Ǘ���񃊃X�g����Y���f�[�^�擾
                    GoodsMngWork goodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                    GoodsMngWork tempGoodsMngWork = goodsMngWork.Clone(); // ADD 2012/10/08 xupz for redmine#32367

                    if ((supplierCodeDic.ContainsKey(key)) &&
                        (goodsMngWork.SupplierCd != supplierCodeDic[key]))
                    {
                        //goodsMngWork.SupplierCd = supplierCodeDic[key]; // DEL 2012/10/08 xupz for redmine#32367

                        tempGoodsMngWork.SupplierCd = supplierCodeDic[key]; // ADD 2012/10/08 xupz for redmine#32367

                        if (!goodsMngWorkDic.ContainsKey(key))
                        {
                            //goodsMngWorkDic.Add(key, goodsMngWork); // DEL 2012/10/08 xupz for redmine#32367

                            goodsMngWorkDic.Add(key, tempGoodsMngWork); // ADD 2012/10/08 xupz for redmine#32367
                        }
                    }
                }
            }

            //---------------------------------------------
            // �폜�Ώۂ̏��i�Ǘ����}�X�^�擾
            //---------------------------------------------
            Dictionary<string, GoodsMngWork> delGoodsMngWorkDic = new Dictionary<string, GoodsMngWork>();
            foreach (PrmSettingUWork work in deleteList)
            {
                F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();
                keyGoodsMngList.goodsMGroup = work.GoodsMGroup;
                keyGoodsMngList.goodsMakerCd = work.PartsMakerCd;
                keyGoodsMngList.blGoodsCode = work.TbsPartsCode;

                string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup, work.TbsPartsCode, work.PartsMakerCd);

                // ������ʂ���ꍇ�A�S��ʂ��폜�Ώۂ̎��̂ݏ��i�Ǘ����}�X�^���폜
                ArrayList workList = UserPrimeSettingRecords.FindAll(work.GoodsMGroup, work.TbsPartsCode, work.PartsMakerCd);
                if (workList != null)
                {
                    int totalCount = workList.Count;
                    int count = 0;
                    foreach (PrmSettingUWork temp in deleteList)
                    {
                        if ((work.GoodsMGroup == temp.GoodsMGroup) &&
                            (work.PartsMakerCd == temp.PartsMakerCd) &&
                            (work.TbsPartsCode == temp.TbsPartsCode))
                        {
                            count++;
                        }
                    }
                    if (totalCount != count)
                    {
                        continue;
                    }
                }

                if (_GoodsMngList[keyGoodsMngList] != null)
                {
                    // ���i�Ǘ���񃊃X�g�Ƀf�[�^���聨�폜

                    // ���i�Ǘ���񃊃X�g����Y���f�[�^�擾
                    GoodsMngWork goodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                    if (!delGoodsMngWorkDic.ContainsKey(key))
                    {
                        delGoodsMngWorkDic.Add(key, goodsMngWork);
                    }
                }
            }

            //---------------------------------------------
            // �폜�Ώۂ̏��i�Ǘ����}�X�^(BL�R�[�h=0)�擾
            //---------------------------------------------
            ArrayList bl0GoodsMngWorkList = new ArrayList();
            foreach (GoodsMngWork work in delGoodsMngWorkDic.Values)
            {
                string sectionCd = work.SectionCode.Trim();
                int goodsMGroup = work.GoodsMGroup;
                int makerCd = work.GoodsMakerCd;

                GoodsMngWork bl0GoodsMngWork = new GoodsMngWork();

                int totalCount = 0;
                foreach (GoodsMngWork temp in _GoodsMngList.Values)
                {
                    if ((sectionCd == temp.SectionCode.Trim()) &&
                        (goodsMGroup == temp.GoodsMGroup) &&
                        (makerCd == temp.GoodsMakerCd))
                    {
                        if (temp.BLGoodsCode != 0)
                        {
                            totalCount++;
                        }
                        else
                        {
                            bl0GoodsMngWork = temp;
                        }
                    }
                }

                int count = 0;
                foreach (GoodsMngWork work2 in delGoodsMngWorkDic.Values)
                {
                    if ((sectionCd == work2.SectionCode.Trim()) &&
                        (goodsMGroup == work2.GoodsMGroup) &&
                        (makerCd == work2.GoodsMakerCd) &&
                        (work2.BLGoodsCode != 0))
                    {
                        count++;
                    }
                }

                if (totalCount == count)
                {
                    bl0GoodsMngWorkList.Add(bl0GoodsMngWork);
                }
            }
            foreach (GoodsMngWork work in bl0GoodsMngWorkList)
            {
                string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup, work.BLGoodsCode, work.GoodsMakerCd);

                if (!delGoodsMngWorkDic.ContainsKey(key))
                {
                    delGoodsMngWorkDic.Add(key, work);
                }
            }

            //---------------------------------------------
            // �폜�Ώۂ̗D�ǐݒ�}�X�^(BL�R�[�h=0)�擾
            //---------------------------------------------
            Dictionary<string, PrmSettingUWork> bl0PrmSettingUWorkDic = new Dictionary<string, PrmSettingUWork>();
            foreach (PrmSettingUWork work in deleteList)
            {
                string sectionCd = work.SectionCode.Trim();
                int goodsMGroup = work.GoodsMGroup;
                int makerCd = work.PartsMakerCd;

                ArrayList bl0PrmSettingUWorkList = UserPrimeSettingRecords.FindAll(sectionCd, goodsMGroup, makerCd);
                if (bl0PrmSettingUWorkList == null)
                {
                    continue;
                }

                int totalCount = bl0PrmSettingUWorkList.Count - 1;

                int count = 0;
                foreach (PrmSettingUWork temp in deleteList)
                {
                    if ((sectionCd == temp.SectionCode.Trim()) &&
                        (goodsMGroup == temp.GoodsMGroup) &&
                        (makerCd == temp.PartsMakerCd) &&
                        (temp.TbsPartsCode != 0))
                    {
                        count++;
                    }
                }

                if (totalCount == count)
                {
                    PrmSettingUWork work2 = UserPrimeSettingRecords.Find(goodsMGroup, 0, makerCd, 0, 0);
                    if (work2 == null)
                    {
                        continue;
                    }

                    string key = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work2.GoodsMGroup, 0, work2.PartsMakerCd);
                    if (!bl0PrmSettingUWorkDic.ContainsKey(key))
                    {
                        bl0PrmSettingUWorkDic.Add(key, work2);
                    }
                }
            }
            foreach (PrmSettingUWork work in bl0PrmSettingUWorkDic.Values)
            {
                deleteList.Add(work);
            }

            int status = -1;

            //---------------------------------------------
            // �폜����
            //---------------------------------------------
            if (deleteList.Count > 0)
            {
                ArrayList primeSettingIndexList = new ArrayList();
                for (int index = 0; index < deleteList.Count; index++)
                {
                    PrmSettingUWork work = (PrmSettingUWork)deleteList[index];

                    string goodsKey = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup, 
                                                                                       work.TbsPartsCode, 
                                                                                       work.PartsMakerCd);

                    foreach (PrmSettingUWork work2 in prmSettingUWorkDic.Values)
                    {
                        if ((work.GoodsMGroup == work2.GoodsMGroup) &&
                            (work.TbsPartsCode == work2.TbsPartsCode) &&
                            (work.PartsMakerCd == work2.PartsMakerCd))
                        {
                            string primeKey = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup,
                                                                                               work.TbsPartsCode,
                                                                                               work.PartsMakerCd,
                                                                                               work.PrmSetDtlNo1,
                                                                                               work.PrmSetDtlNo2);
                            if (prmSettingUWorkDic.ContainsKey(primeKey))
                            {
                                primeSettingIndexList.Add(index);
                            }

                            if (delGoodsMngWorkDic.ContainsKey(goodsKey))
                            {
                                delGoodsMngWorkDic.Remove(goodsKey);
                            }
                        }
                    }
                }

                if (primeSettingIndexList.Count > 0)
                {
                    for (int index = primeSettingIndexList.Count - 1; index >= 0; index--)
                    {
                        int deleteIndex = (int)primeSettingIndexList[index];
                        deleteList.RemoveAt(deleteIndex);
                    }
                }

                object primeSettingObj = deleteList;
                ArrayList goodsMngList = new ArrayList();
                foreach (GoodsMngWork work in delGoodsMngWorkDic.Values)
                {
                    goodsMngList.Add(work);
                }
                object goodsMngObj = goodsMngList;

                status = primeSettingSearchDB.Delete(primeSettingObj, goodsMngObj);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                // �폜�������R�[�h�̗D�ǐݒ�}�X�^���DBNull���Z�b�g
                foreach (PrmSettingUWork work in deleteList)
                {
                    foreach (DataRowView view in PrimeSettingView)
                    {
                        if (((Int32)view[PrimeSettingInfo.COL_PARTSMAKERCD] == work.PartsMakerCd) &&
                            ((Int32)view[PrimeSettingInfo.COL_MIDDLEGENRECODE] == work.GoodsMGroup) &&
                            ((Int32)view[PrimeSettingInfo.COL_TBSPARTSCODE] == work.TbsPartsCode) &&
                            ((Int32)view[PrimeSettingInfo.COL_SELECTCODE] == work.PrmSetDtlNo1) &&
                            ((Int32)view[PrimeSettingInfo.COL_PRIMEKINDCODE] == work.PrmSetDtlNo2))
                        {
                            view[COL_USERPRIMESETTING] = DBNull.Value;
                            break;
                        }
                    }
                }
            }

            //---------------------------------------------
            // �X�V����
            //---------------------------------------------
            if (prmSettingUWorkDic.Values.Count > 0)
            {
                ArrayList primeSettingList = new ArrayList();
                foreach (PrmSettingUWork work in prmSettingUWorkDic.Values)
                {
                    primeSettingList.Add(work);
                }
                object primeSettingObj = primeSettingList;

                ArrayList goodsMngList = new ArrayList();
                foreach (GoodsMngWork work in goodsMngWorkDic.Values)
                {
                    goodsMngList.Add(work);
                }
                object goodsMngObj = goodsMngList;

                status = primeSettingSearchDB.Write(ref primeSettingObj, ref goodsMngObj);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }
            }

            // ���i�Ǘ���񃊃X�g�X�V
            status = getGoodsMngList();
            if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
                (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
                (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
            {
                return status;
            }

            // �D�ǐݒ�(���[�U)���X�g�X�V
            status = getUserPrimesettingList();

            //PrimeSettingView.RowFilter = rowfilter;
            //PrimeSettingView.Sort = sort;

            return (status);
        }

        #region �d�l���啝�ɕύX�������ߍ폜
        ///// <summary>
        ///// �f�[�^�X�V
        ///// </summary>
        ///// <returns>�G���[����</returns>
        //public int updatePrimeSettingList(out string errorMessage) // TODO:�y�ۑ��z�����͂��̃��\�b�h�ɏW��
        //{
        //    // ADD 2008/11/25 �s��Ή�[6962] �d�l�ύX �d����R�[�h�͑S�̂ŕK�{���� ---------->>>>>
        //    // �y�ۑ��z�d����R�[�h�̓��̓`�F�b�N
        //    if (!HasSupplierCodeOfAllMg_Bl_MkView(out errorMessage))
        //    {
        //        return UPDATE_CHECK_ERROR;
        //    }
        //    // ADD 2008/11/25 �s��Ή�[6962] �d�l�ύX �d����R�[�h�͑S�̂ŕK�{���� ----------<<<<<

        //    string rowfilter = PrimeSettingView.RowFilter;
        //    string sort = PrimeSettingView.Sort;

        //    // --- ADD 2008/07/01 -------------------------------->>>>>
        //    ArrayList userPrmSettingDelList = new ArrayList();
        //    int status = -1;
        //    // --- ADD 2008/07/01 --------------------------------<<<<< 

        //    try
        //    {
        //        PrimeSettingView.RowFilter = "";
        //        PrimeSettingView.Sort = "";

        //        updateCheckPrimeSettingList();

        //        #region �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃p�����[�^�\�z

        //        _UserPrimeSettingList.Clear();
        //        // ADD 2009/01/27 �d�l�ύX��
        //        IDictionary<string, PrmSettingUWork> writingPrmSettingUWorkMap = new Dictionary<string, PrmSettingUWork>();

        //        // ��\���ɕύX���ꂽ���R�[�h���}�[�N���郊�X�g
        //        IList<int[]> notVisibledMakerBLCodeList = new List<int[]>();  // ADD 2009/01/21 �s��Ή�[6970]

        //        foreach (DataRowView primeSettingRow in PrimeSettingView)
        //        {
        //            int middleGenreCode = (int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];
        //            int makerCode = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
        //            int blCode = (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
        //            int selectCode = (int)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE];
        //            int prmSetDtl = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];
        //            string writingKey = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(middleGenreCode, makerCode, blCode, selectCode, prmSetDtl);
        //            Debug.WriteLine("�D�ǐݒ�}�X�^�i���[�U�[�j�̃p�����[�^���\�z���F" + middleGenreCode.ToString() + ", " + makerCode.ToString() + ", " + blCode.ToString());

        //            // �񋟕��������ă��[�U�[�o�^���������̂͐V�K
        //            // DEL 2009/01/27 �d�l�ύX��
        //            // if (primeSettingRow[COL_USERPRIMESETTING] == System.DBNull.Value)
        //            // ADD 2009/01/27 �d�l�ύX ---------->>>>>
        //            if (
        //                primeSettingRow[COL_USERPRIMESETTING] == System.DBNull.Value
        //                    &&
        //                //UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode) == null
        //                UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl) == null
        //            )
        //            // ADD 2008/01/27 �d�l�ύX ----------<<<<<
        //            {
        //                if ((CheckState)primeSettingRow[COL_CHECKSTATE] == CheckState.Unchecked) continue;  // ADD 2008/07/01
                        
        //                // FIXME:[�S�~�|��]�FBL�R�[�h=0�̃��R�[�h��V�K�o�^
        //                #region �폜�R�[�h
        //                //if (
        //                //    ((CheckState)primeSettingRow[COL_CHECKSTATE]).Equals(CheckState.Unchecked)
        //                //        &&
        //                //    !((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0)
        //                //)
        //                //{
        //                //    continue;
        //                //}
        //                #endregion

        //                // �\���敪��"�\������"�̃f�[�^�͑ΏۊO
        //                if ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)
        //                {
        //                    if (((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0))
        //                    {
        //                        // MEMO:BL�R�[�h��0�̏ꍇ�A�D�Ǖ\���敪��2�ɍ׍H�@�������[�g���ŏ������ލۂɁA�����I��0�ɂ���
        //                        Debug.Assert(false, "�݌v�I�ɂ��肦�Ȃ�");
        //                    }
        //                    else
        //                    {
        //                        continue;
        //                    }
        //                }

        //                //PrimeSettingWork wkPrimeSettingWork = new PrimeSettingWork();  // DEL 2008/07/01
        //                PrmSettingUWork prmSettingUWork = new PrmSettingUWork();      // ADD 2008/07/01

        //                prmSettingUWork.CreateDateTime = DateTime.MinValue;           // �쐬����
        //                prmSettingUWork.UpdateDateTime = DateTime.MinValue;           // �X�V����
        //                prmSettingUWork.EnterpriseCode = this._enterpriseCode;        // ��ƃR�[�h
        //                prmSettingUWork.FileHeaderGuid = Guid.Empty;                  // GUID
        //                prmSettingUWork.UpdEmployeeCode = "";                         // �X�V�]�ƈ��R�[�h
        //                prmSettingUWork.UpdAssemblyId1 = "";                          // �X�V�A�Z���u��ID1
        //                prmSettingUWork.UpdAssemblyId2 = "";                          // �X�V�A�Z���u��ID2
        //                prmSettingUWork.LogicalDeleteCode = 0;                        // �_���폜�敪
        //                prmSettingUWork.MakerDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
        //                prmSettingUWork.PrimeDisplayCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];

        //                // --- DEL 2008/07/01 -------------------------------->>>>>
        //                #region �폜�R�[�h
        //                //wkPrimeSettingWork.DisplayOrder = (Int32)drv[PrimeSettingInfo.COL_DISPLAYORDER];
        //                //wkPrimeSettingWork.MiddleGenreCode = (Int32)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE];
        //                #endregion
        //                //   --- DEL 2008/07/01 --------------------------------<<<<<

        //                // --- ADD 2008/07/01 -------------------------------->>>>>
        //                prmSettingUWork.SectionCode = this._sectionCode;                                 // ���_�R�[�h
        //                prmSettingUWork.PrimeDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER];  // �D�Ǖ\������
        //                prmSettingUWork.GoodsMGroup = (Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];  // ���i�����ރR�[�h
        //                // --- ADD 2008/07/01 --------------------------------<<<<< 

        //                prmSettingUWork.PartsMakerCd = (Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
        //                prmSettingUWork.TbsPartsCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
        //                prmSettingUWork.TbsPartsCdDerivedNo = (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO];

        //                // MEMO:BL�R�[�h��0�̏ꍇ�A�D�Ǖ\���敪��2�ɍ׍H�@�������[�g���ŏ������ލۂɁA�����I��0�ɂ���
        //                if (prmSettingUWork.TbsPartsCode.Equals(0))
        //                {   
        //                    Debug.WriteLine(prmSettingUWork.GoodsMGroup.ToString() + ", " + prmSettingUWork.PartsMakerCd.ToString());
        //                    prmSettingUWork.PrimeDisplayCode = 2;
        //                }
                        
        //                // --- DEL 2008/07/01 -------------------------------->>>>>
        //                #region �폜�R�[�h
        //                //wkPrimeSettingWork.SelectCode = (Int32)drv[PrimeSettingInfo.COL_SELECTCODE];
        //                //wkPrimeSettingWork.PrimeKindCode = (Int32)drv[PrimeSettingInfo.COL_PRIMEKINDCODE];
        //                //wkPrimeSettingWork.PrimeKindName = (string)drv[PrimeSettingInfo.COL_PRIMEKINDNAME];
        //                #endregion
        //                //   --- DEL 2008/07/01 --------------------------------<<<<<

        //                // --- ADD 2008/07/01 -------------------------------->>>>>
        //                prmSettingUWork.PrmSetDtlNo1 = (Int32)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE];        // �Z���N�g�R�[�h
        //                prmSettingUWork.PrmSetDtlName1 = (string)primeSettingRow[PrimeSettingInfo.COL_SELECTNAME];     // �D�ǐݒ�ڍז��̂P
        //                prmSettingUWork.PrmSetDtlNo2 = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];     // ��ʃR�[�h
        //                prmSettingUWork.PrmSetDtlName2 = (string)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME];  // �D�ǐݒ�ڍז��̂Q
        //                // --- ADD 2008/07/01 --------------------------------<<<<< 

        //                // FIXME:�d���������͖���
        //                // ���񋟑��ɂ͋��_�R�[�h���Ȃ����߁A����������+���[�J�[+BL�̃��R�[�h����������
        //                if (!writingPrmSettingUWorkMap.ContainsKey(writingKey))
        //                {
        //                    writingPrmSettingUWorkMap.Add(writingKey, prmSettingUWork);
        //                    _UserPrimeSettingList.Add(prmSettingUWork);

        //                    string writingKeyWhatBLCodeIs0 = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(
        //                        middleGenreCode,
        //                        makerCode,
        //                        0,
        //                        0,
        //                        0
        //                    );
        //                    if (!writingPrmSettingUWorkMap.ContainsKey(writingKeyWhatBLCodeIs0))
        //                    {
        //                        PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(prmSettingUWork);
        //                        writingPrmSettingUWorkMap.Add(writingKeyWhatBLCodeIs0, bl0PrmSettingUWork);
        //                        _UserPrimeSettingList.Add(bl0PrmSettingUWork);
        //                    }
        //                }
        //                else
        //                {
        //                    PrmSettingUWork temp = (PrmSettingUWork)writingPrmSettingUWorkMap[writingKey];
        //                    if ((temp.PrmSetDtlNo1 != prmSettingUWork.PrmSetDtlNo1) ||
        //                        (temp.PrmSetDtlNo2 != prmSettingUWork.PrmSetDtlNo2))
        //                    {
        //                        _UserPrimeSettingList.Add(prmSettingUWork);

        //                        string writingKeyWhatBLCodeIs0 = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(
        //                        middleGenreCode,
        //                        makerCode,
        //                        0,
        //                        0,
        //                        0
        //                    );
        //                        if (!writingPrmSettingUWorkMap.ContainsKey(writingKeyWhatBLCodeIs0))
        //                        {
        //                            PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(prmSettingUWork);
        //                            writingPrmSettingUWorkMap.Add(writingKeyWhatBLCodeIs0, bl0PrmSettingUWork);
        //                            _UserPrimeSettingList.Add(bl0PrmSettingUWork);
        //                        }
        //                    }
        //                }
        //            }
        //            // ���[�U�[�o�^��������
        //            else
        //            {
        //                // ADD 2009/01/27 �d�l�ύX ---------->>>>>
        //                if (
        //                    primeSettingRow[COL_USERPRIMESETTING] == DBNull.Value
        //                        ||
        //                    //UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode) == null
        //                    UserPrimeSettingRecords.Find(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl) == null
        //                )
        //                {
        //                    continue;
        //                }
        //                // ADD 2008/01/27 �d�l�ύX ----------<<<<<
        //                // --- DEL 2008/07/01 -------------------------------->>>>>
        //                #region �폜�R�[�h
        //                //OfferPrimeSettingWork offerdrv = (OfferPrimeSettingWork)drv[COL_OFFERPRIMESETTING];
        //                //PrimeSettingWork userdrv = (PrimeSettingWork)drv[COL_USERPRIMESETTING];
        //                #endregion
        //                //   --- DEL 2008/07/01 --------------------------------<<<<<

        //                // --- ADD 2008/07/01 -------------------------------->>>>>
        //                PrmSettingWork offerPrmSettingWork = (PrmSettingWork)primeSettingRow[COL_OFFERPRIMESETTING];
        //                PrmSettingUWork userPrmSettingUWork = (PrmSettingUWork)primeSettingRow[COL_USERPRIMESETTING];
        //                // --- ADD 2008/07/01 --------------------------------<<<<< 

        //                ////�폜���ꂽ�ꍇ�i�\�������ɕύX�j
        //                //if ((Int32)drv[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0)  // DEL 2008/07/01

        //                //if (((Int32)drv[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] == 0) || ((CheckState)drv[COL_CHECKSTATE] == CheckState.Unchecked))  // ADD 2008/07/01
        //                if ((CheckState)primeSettingRow[COL_CHECKSTATE] == CheckState.Unchecked)
        //                {
        //                    // --- DEL 2008/07/01 -------------------------------->>>>>
        //                    #region �폜�R�[�h
        //                    //userdrv.LogicalDeleteCode = 3;       // �_���폜�敪�i�폜�Ȃ̂œ��e�̓`�F�b�N���Ȃ��j
        //                    //_UserPrimeSettingList.Add(userdrv);
        //                    #endregion
        //                    // --- DEL 2008/07/01 --------------------------------<<<<< 

        //                    // FIXME:BL�R�[�h=0�͖���
        //                    if (!userPrmSettingUWork.TbsPartsCode.Equals(0))
        //                    {
        //                        // �폜���X�g�ɒǉ�
        //                        userPrmSettingDelList.Add(userPrmSettingUWork);  // ADD 2008/07/01

        //                        // �D�ǐݒ���N���A
        //                        primeSettingRow[COL_USERPRIMESETTING] = System.DBNull.Value;
        //                    }
        //                }
        //                else
        //                {
        //                    //�ύX����Ă��Ȃ��ꍇ�͉������Ȃ�
        //                    if (
        //                        //���[�J�[�\������
        //                        userPrmSettingUWork.MakerDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER]   
        //                            &&           
        //                        //userdrv.DisplayOrder == (Int32)drv[PrimeSettingInfo.COL_DISPLAYORDER] &&             //�\������          // DEL 2008/07/01
        //                        //�\������
        //                        userPrmSettingUWork.PrimeDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] // ADD 2008/07/01
        //                            &&          // ADD 2008/07/01
        //                        //�D�Ǖ\���敪
        //                        userPrmSettingUWork.PrimeDisplayCode == (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]
        //                            &&       
        //                        //userdrv.PrimeKindName == (string)drv[PrimeSettingInfo.COL_PRIMEKINDNAME]) continue;  //��ʖ���          // DEL 2008/07/01
        //                        //��ʖ���          
        //                        userPrmSettingUWork.PrmSetDtlName2 == (string)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME]   // ADD 2008/07/01  
        //                    )
        //                    {
        //                        // ADD 2008/11/25 �s��Ή�[6962] �d�l�ύX �d����R�[�h�͑S�̂ŕK�{���� ---------->>>>>
        //                        // TODO:�d����R�[�h���ύX�̔���ɉ�����
        //                        DataRow[] foundDataRows = this.PrimeSettingTable.Select(
        //                            GetWhere(userPrmSettingUWork.PartsMakerCd, userPrmSettingUWork.GoodsMGroup, userPrmSettingUWork.TbsPartsCode)
        //                        );
        //                        if (!(bool)foundDataRows[0][COL_CHANGEFLAG])
        //                        // ADD 2008/11/25 �s��Ή�[6962] �d�l�ύX �d����R�[�h�͑S�̂ŕK�{���� ----------<<<<<
        //                        {
        //                            continue;
        //                        }
        //                    }
        //                    // �Ȍ�A�ύX����Ă���ꍇ�̏���

        //                    userPrmSettingUWork.MakerDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
        //                    //userdrv.DisplayOrder = (Int32)drv[PrimeSettingInfo.COL_DISPLAYORDER];        // DEL 2008/07/01
        //                    userPrmSettingUWork.PrimeDispOrder = (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER];        // ADD 2008/07/01
                            
        //                    // ADD 2009/01/21 �s��Ή�[6970] ---------->>>>>
        //                    // �D�Ǖ\���敪���u�\�������v�ɕύX���ꂽ�ꍇ�A�Y�����鏤�i�Ǘ������폜
        //                    if (((int)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]).Equals(0))
        //                    {
        //                        PrmSettingUWork userPrimeSettingRecord = UserPrimeSettingRecords.Find(
        //                            userPrmSettingUWork.GoodsMGroup,
        //                            userPrmSettingUWork.TbsPartsCode,
        //                            userPrmSettingUWork.PartsMakerCd,
        //                            userPrmSettingUWork.PrmSetDtlNo1,
        //                            userPrmSettingUWork.PrmSetDtlNo2
        //                        );
        //                        if (userPrimeSettingRecord != null)
        //                        {
        //                            if (!userPrimeSettingRecord.PrimeDisplayCode.Equals(0))
        //                            {
        //                                int[] hoges = new int[3];
        //                                hoges[0] = userPrimeSettingRecord.GoodsMGroup;
        //                                hoges[1] = userPrimeSettingRecord.PartsMakerCd;
        //                                hoges[2] = userPrimeSettingRecord.TbsPartsCode;
        //                                notVisibledMakerBLCodeList.Add(hoges);
        //                            }
        //                        }
        //                    }
        //                    // ADD 2009/01/21 �s��Ή�[6970] ----------<<<<<
                            
        //                    userPrmSettingUWork.PrimeDisplayCode = (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
        //                    //userdrv.PrimeKindName = (string)drv[PrimeSettingInfo.COL_PRIMEKINDNAME];     // DEL 2008/07/01

        //                    // MEMO:BL�R�[�h��0�̏ꍇ�A�D�Ǖ\���敪��2�ɍ׍H�@�������[�g���ŏ������ލۂɁA�����I��0�ɂ���
        //                    if (userPrmSettingUWork.TbsPartsCode.Equals(0))
        //                    {
        //                        userPrmSettingUWork.PrimeDisplayCode = 2;
        //                    }

        //                    userPrmSettingUWork.PrmSetDtlName2 = (string)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME];      // ADD 2008/07/01

        //                    // FIXME:�d���������͖���
        //                    // ���񋟑��ɂ͋��_�R�[�h���Ȃ����߁A����������+���[�J�[+BL�̃��R�[�h����������
        //                    if (!writingPrmSettingUWorkMap.ContainsKey(writingKey))
        //                    {
        //                        writingPrmSettingUWorkMap.Add(writingKey, userPrmSettingUWork);
        //                        _UserPrimeSettingList.Add(userPrmSettingUWork);

        //                        string writingKeyWhatBLCodeIs0 = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(
        //                            middleGenreCode,
        //                            makerCode,
        //                            0,
        //                            0,
        //                            0
        //                        );
        //                        if (!writingPrmSettingUWorkMap.ContainsKey(writingKeyWhatBLCodeIs0))
        //                        {
        //                            PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(userPrmSettingUWork);
        //                            writingPrmSettingUWorkMap.Add(writingKeyWhatBLCodeIs0, bl0PrmSettingUWork);
        //                            _UserPrimeSettingList.Add(bl0PrmSettingUWork);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        PrmSettingUWork temp = (PrmSettingUWork)writingPrmSettingUWorkMap[writingKey];
        //                        if ((temp.PrmSetDtlNo1 != userPrmSettingUWork.PrmSetDtlNo1) ||
        //                            (temp.PrmSetDtlNo2 != userPrmSettingUWork.PrmSetDtlNo2))
        //                        {
        //                            _UserPrimeSettingList.Add(userPrmSettingUWork);

        //                            string writingKeyWhatBLCodeIs0 = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(
        //                            middleGenreCode,
        //                            makerCode,
        //                            0,
        //                            0,
        //                            0
        //                        );
        //                            if (!writingPrmSettingUWorkMap.ContainsKey(writingKeyWhatBLCodeIs0))
        //                            {
        //                                PrmSettingUWork bl0PrmSettingUWork = CreatePrmSettingUWorkWhatBLCodeIs0(userPrmSettingUWork);
        //                                writingPrmSettingUWorkMap.Add(writingKeyWhatBLCodeIs0, bl0PrmSettingUWork);
        //                                _UserPrimeSettingList.Add(bl0PrmSettingUWork);
        //                            }
        //                        }
        //                    }

        //                }   // if ((CheckState)primeSettingRow[COL_CHECKSTATE] == CheckState.Unchecked)
        //            }   // if (primeSettingRow[COL_USERPRIMESETTING] == System.DBNull.Value)
        //        }   // foreach (DataRowView primeSettingRow in PrimeSettingView)

        //        #endregion  // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃p�����[�^�\�z

        //        #region ���i�Ǘ����̃p�����[�^�\�z

        //        // --- ADD 2008/07/01 -------------------------------->>>>>
        //        ArrayList goodsMngList = new ArrayList();
        //        F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();

        //        IDictionary<string, GoodsMngWork> entryGoodsMngWorkMap = new Dictionary<string, GoodsMngWork>();

        //        // [�ۑ�]�c������/BL/���[�J�[ �f�[�^�e�[�u���̓��e��W�J
        //        foreach (DataRowView mgBLMkRow in Mg_Bl_MkView)
        //        {
        //            // ���ʐݒ背�R�[�h�͖���
        //            if (IsCommonRowOfMiddleGBLMakerDataTable(mgBLMkRow)) continue;   // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX

        //            //if ((CheckState)mgBLMkRow[COL_CHECKSTATE] == CheckState.Unchecked) continue;
        //            // FIXME:BL�R�[�h=0�ɑΉ����鏤�i�Ǘ������X�V�i��{�ݒ�̃`�F�b�N�Ȃ� && BL�R�[�h��0 �͖����j
        //            if (
        //                ((CheckState)mgBLMkRow[COL_CHECKSTATE]).Equals(CheckState.Unchecked)
        //                    &&
        //                !((int)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0)
        //            )
        //            {
        //                continue;
        //            }

        //            keyGoodsMngList.goodsMGroup = (int)mgBLMkRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]; // ADD 2009/01/26 �d�l�ύX�F���i�Ǘ����ɒ����ރR�[�h��ǉ�
        //            keyGoodsMngList.goodsMakerCd = (int)mgBLMkRow[PrimeSettingInfo.COL_PARTSMAKERCD];  // ���i���[�J�[�R�[�h
        //            keyGoodsMngList.blGoodsCode = (int)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE];   // BL���i�R�[�h
        //            // FIXME:
        //            string writingKey = PrimeSettingAcs.UserPrimeSettingAgreegate.GetKey(
        //                keyGoodsMngList.goodsMGroup,
        //                keyGoodsMngList.goodsMakerCd,
        //                keyGoodsMngList.blGoodsCode
        //            );
        //            Debug.WriteLine("���i�Ǘ����̃p�����[�^���\�z���F" + keyGoodsMngList.goodsMGroup.ToString() + ", " + keyGoodsMngList.goodsMakerCd.ToString() + ", " + keyGoodsMngList.blGoodsCode.ToString());

        //            // ���i�Ǘ���񃊃X�g�Ƀf�[�^�Ȃ������i�Ǘ����֐V�K�o�^
        //            if (_GoodsMngList[keyGoodsMngList] == null)
        //            {
        //                // �d����R�[�h�ݒ肠��H
        //                if (mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD] != System.DBNull.Value)
        //                {
        //                    GoodsMngWork goodsMngWork = new GoodsMngWork();
        //                    goodsMngWork.EnterpriseCode = this._enterpriseCode;                       // ��ƃR�[�h
        //                    goodsMngWork.SectionCode = this._sectionCode;                             // ���_�R�[�h
        //                    goodsMngWork.GoodsMakerCd = (int)mgBLMkRow[PrimeSettingInfo.COL_PARTSMAKERCD];  // ���i���[�J�[�R�[�h
        //                    goodsMngWork.BLGoodsCode = (int)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE];   // BL���i�R�[�h
        //                    goodsMngWork.SupplierCd = (int)mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD];      // �d����R�[�h

        //                    // ADD 2009/01/26 �d�l�ύX���F���i�Ǘ����ɒ����ރR�[�h��ǉ�
        //                    goodsMngWork.GoodsMGroup = (int)mgBLMkRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];    // �����ރR�[�h

        //                    if (goodsMngWork.BLGoodsCode.Equals(0))
        //                    {
        //                        goodsMngWork.GoodsNo = string.Empty;
        //                        goodsMngWork.SupplierLot = 0;
        //                        // UNDONE:BL�R�[�h=0�̎d����R�[�h
        //                        goodsMngWork.SupplierCd = GetSupplierCodeWhatBLCodeIs0(
        //                            goodsMngWork.GoodsMGroup,
        //                            goodsMngWork.GoodsMakerCd
        //                        );
        //                    }

        //                    // FIXME:���i�Ǘ����}�X�^�X�V���X�g�֒ǉ�
        //                    if (!entryGoodsMngWorkMap.ContainsKey(writingKey))
        //                    {
        //                        goodsMngList.Add(goodsMngWork);
        //                        entryGoodsMngWorkMap.Add(writingKey, goodsMngWork);
        //                    }
        //                }
        //                // FIXME:[�S�~�|��]
        //                #region �폜�R�[�h
        //                // ADD 2009/01/27 �d�l�ύX�FBL�R�[�h=0�̏��i�Ǘ�����o�^ ---------->>>>>
        //                //else if (keyGoodsMngList.blGoodsCode.Equals(0)) // MEMO:�d����R�[�h�̐ݒ�Ȃ� && BL�R�[�h=0
        //                //{
        //                //    GoodsMngWork goodsMngWork = new GoodsMngWork();
        //                //    {
        //                //        goodsMngWork.EnterpriseCode = this._enterpriseCode;                       // ��ƃR�[�h
        //                //        goodsMngWork.SectionCode = this._sectionCode;                             // ���_�R�[�h
        //                //        goodsMngWork.GoodsMakerCd = (int)mgBLMkRow[PrimeSettingInfo.COL_PARTSMAKERCD];  // ���i���[�J�[�R�[�h
        //                //        goodsMngWork.BLGoodsCode = (int)mgBLMkRow[PrimeSettingInfo.COL_TBSPARTSCODE];   // BL���i�R�[�h
        //                //        goodsMngWork.GoodsMGroup = (int)mgBLMkRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];    // �����ރR�[�h
        //                //        goodsMngWork.GoodsNo = string.Empty;
        //                //        goodsMngWork.SupplierLot = 0;
        //                //        // UNDONE:BL�R�[�h=0�̎d����R�[�h
        //                //        goodsMngWork.SupplierCd = GetSupplierCodeWhatBLCodeIs0(
        //                //            goodsMngWork.GoodsMGroup,
        //                //            goodsMngWork.GoodsMakerCd
        //                //        );
        //                //    }
        //                //    // FIXME:���i�Ǘ����}�X�^�X�V���X�g�֒ǉ�
        //                //    if (!entryGoodsMngWorkMap.ContainsKey(writingKey))
        //                //    {
        //                //        goodsMngList.Add(goodsMngWork);
        //                //        entryGoodsMngWorkMap.Add(writingKey, goodsMngWork);
        //                //    }
        //                //}
        //                // ADD 2008/01/27 �d�l�ύX�FBL�R�[�h=0�̏��i�Ǘ�����o�^ ----------<<<<<
        //                #endregion
        //            }
        //            // ���i�Ǘ���񃊃X�g�Ƀf�[�^���聨���i�Ǘ������X�V
        //            else
        //            {
        //                // ���i�Ǘ���񃊃X�g����Y���f�[�^�擾
        //                GoodsMngWork goodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

        //                // �d����R�[�h�͐ݒ肳��Ă���H
        //                if (mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
        //                {
        //                    // �y�ۑ��z�d����R�[�h�ύX���聨���i�Ǘ������X�V
        //                    if ((int)mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD] != goodsMngWork.SupplierCd)
        //                    {
        //                        // �d����R�[�h�X�V
        //                        goodsMngWork.SupplierCd = (int)mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD];

        //                        // FIXME:���i�Ǘ����}�X�^�X�V���X�g�֒ǉ�
        //                        if (!entryGoodsMngWorkMap.ContainsKey(writingKey))
        //                        {
        //                            goodsMngList.Add(goodsMngWork);
        //                            entryGoodsMngWorkMap.Add(writingKey, goodsMngWork);
        //                        }
        //                    }
        //                    // DEL 2009/01/21 �s��Ή�[6970] ---------->>>>>
        //                    #region �폜�R�[�h
        //                    //// �D�Ǖ\���敪���u�\�����v�̂Ƃ��͏��i�Ǘ������폜
        //                    //else if (((int)mgBLMkRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]).Equals(0))   // �D�Ǖ\���敪==�\����
        //                    //{
        //                    //    // ���i�Ǘ����}�X�^�X�V���X�g�֒ǉ�
        //                    //    goodsMngList.Add(goodsMngWork);
        //                    //}
        //                    #endregion  // �폜�R�[�h
        //                    // DEL 2009/01/21 �s��Ή�[6970] ----------<<<<<
        //                }
        //                else // �d����R�[�h�̃��R�[�h���݂��Ȃ��ߑΉ����鏤�i�Ǘ���񂪑��݂��Ȃ������̎d����R�[�h��0
        //                {
        //                    if (goodsMngWork.SupplierCd != 0)
        //                    {
        //                        // �d����R�[�h�X�V
        //                        goodsMngWork.SupplierCd = 0;

        //                        // FIXME:���i�Ǘ����}�X�^�X�V���X�g�֒ǉ�
        //                        if (!entryGoodsMngWorkMap.ContainsKey(writingKey))
        //                        {
        //                            goodsMngList.Add(goodsMngWork);
        //                            entryGoodsMngWorkMap.Add(writingKey, goodsMngWork);
        //                        }

        //                        if (goodsMngWork.BLGoodsCode.Equals(0))
        //                        {
        //                            Debug.WriteLine(goodsMngWork.GoodsMakerCd.ToString() + ", " + goodsMngWork.SupplierCd.ToString());
        //                        }
        //                    }
        //                }   // if (mgBLMkRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
        //            }   // if (_GoodsMngList[keyGoodsMngList] == null)
        //        }   // foreach (DataRowView mgBLMkRow in Mg_Bl_MkView)

        //        // FIXME:
        //        foreach (string writingKey in writingPrmSettingUWorkMap.Keys)
        //        {
        //            if (entryGoodsMngWorkMap.ContainsKey(writingKey)) continue;

        //            PrmSettingUWork userPrimeSetting = writingPrmSettingUWorkMap[writingKey];
        //            if (!userPrimeSetting.TbsPartsCode.Equals(0)) continue;

        //            GoodsMngWork goodsMngWork = CreateGoodsMngWorkWhatBLCodeIs0(userPrimeSetting);
        //            goodsMngList.Add(goodsMngWork);
        //            entryGoodsMngWorkMap.Add(writingKey, goodsMngWork);
        //        }

        //        // ADD 2009/01/21 �s��Ή�[6970] �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���폜����Ƃ��͏��i�Ǘ������폜 ---------->>>>>
        //        // �u�\�������v�ɕύX���ꂽ�D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h�ɑΉ����鏤�i�Ǘ�����ǉ�
        //        if (notVisibledMakerBLCodeList.Count > 0)
        //        {
        //            foreach (int[] makerBLCode in notVisibledMakerBLCodeList)
        //            {
        //                keyGoodsMngList.goodsMGroup = makerBLCode[0];
        //                keyGoodsMngList.goodsMakerCd= makerBLCode[1];
        //                keyGoodsMngList.blGoodsCode = makerBLCode[2];
        //                if (_GoodsMngList[keyGoodsMngList] != null)
        //                {
        //                    GoodsMngWork deletingGoodsMng = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];
        //                    bool found = false;
        //                    foreach (GoodsMngWork goodsMngWork in goodsMngList)
        //                    {
        //                        // �������i�Ǘ����͒ǉ����Ȃ�
        //                        if (
        //                            goodsMngWork.GoodsMakerCd.Equals(deletingGoodsMng.GoodsMakerCd)
        //                                &&
        //                            goodsMngWork.BLGoodsCode.Equals(deletingGoodsMng.BLGoodsCode)
        //                        )
        //                        {
        //                            found = true;
        //                            continue;
        //                        }
        //                    }
        //                    if (!found)
        //                    {
        //                        string writingKey = UserPrimeSettingAgreegate.GetKey(
        //                            keyGoodsMngList.goodsMGroup,
        //                            keyGoodsMngList.goodsMakerCd,   // FIXME:
        //                            keyGoodsMngList.blGoodsCode     // FIXME:
        //                        );
        //                        if (!entryGoodsMngWorkMap.ContainsKey(writingKey))
        //                        {
        //                            goodsMngList.Add(deletingGoodsMng);
        //                            entryGoodsMngWorkMap.Add(writingKey, deletingGoodsMng);
        //                        }
        //                    }
        //                }   // if (_GoodsMngList[keyGoodsMngList] != null)
        //            }   // foreach (int[] makerBLCode in notVisibledMakerBLCodeList)
        //        }   // if (notVisibledMakerBLCodeList.Count > 0)
                
        //        // ���i�Ǘ����̍폜���X�g���\�z
        //        ArrayList deletingGoodsMngList = new ArrayList();
        //        if (userPrmSettingDelList.Count > 0)
        //        {
        //            foreach (PrmSettingUWork deletingPrmSettingUWork in userPrmSettingDelList)
        //            {
        //                keyGoodsMngList.goodsMGroup = deletingPrmSettingUWork.GoodsMGroup;  // ADD 2009/01/26 �d�l�ύX�F���i�Ǘ����ɒ����ރR�[�h��ǉ�
        //                keyGoodsMngList.goodsMakerCd= deletingPrmSettingUWork.PartsMakerCd; // ���i���[�J�[�R�[�h
        //                keyGoodsMngList.blGoodsCode = deletingPrmSettingUWork.TbsPartsCode; // BL���i�R�[�h
        //                if (_GoodsMngList[keyGoodsMngList] != null)
        //                {
        //                    GoodsMngWork deletingGoodsMng = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];
        //                    deletingGoodsMngList.Add(deletingGoodsMng);
        //                }
        //            }
        //        }
        //        // ADD 2009/01/21 �s��Ή�[6970] �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���폜����Ƃ��͏��i�Ǘ������폜 ----------<<<<<
        //        #endregion  // ���i�Ǘ����̃p�����[�^�\�z

        //        // ADD 2009/02/17 �s��Ή�[11241] ---------->>>>>
        //        #region BL�R�[�h=0�̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h�̍폜�p�����[�^���\�z

        //        ArrayList deletingPrmSettingUListOfBL0 = new ArrayList();   // BL�R�[�h=0�̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̍폜���X�g
        //        ArrayList deletingGoodsMngListOfBL0 = new ArrayList();      // BL�R�[�h=0�̏��i�Ǘ��}�X�^�̍폜���X�g

        //        // �u�\�������v�ɕύX���ꂽ�D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h�ɑΉ�����BL�R�[�h=0����ǉ�
        //        if (notVisibledMakerBLCodeList.Count > 0)
        //        {
        //            foreach (int[] makerBLCode in notVisibledMakerBLCodeList)
        //            {
        //                int targetMiddleGroup   = makerBLCode[0];   // �����ރR�[�h
        //                int targetMakerCode     = makerBLCode[1];   // ���[�J�[�R�[�h
        //                int targetBLCode        = makerBLCode[2];   // BL�R�[�h

        //                // ��{�ݒ�ŕ\���ΏۂƂȂ��Ă�����̂𒊏o
        //                StringBuilder where = new StringBuilder();
        //                {
        //                    where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(targetMiddleGroup);
        //                    where.Append(ADOUtil.AND);
        //                    where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append(ADOUtil.EQ).Append(targetMakerCode);
        //                    where.Append(ADOUtil.AND);
        //                    where.Append(PrimeSettingAcs.COL_CHECKSTATE).Append(ADOUtil.EQ).Append(1);
        //                }
        //                DataRow[] foundRows = Mg_Bl_MkTable.Select(where.ToString());

        //                // ����̒����� + ���[�J�[�ɑ�����BL�Q���\���ݒ�ƂȂ��Ă���ꍇ�͍폜���Ȃ�
        //                if (foundRows.Length > 1) continue;

        //                if (foundRows.Length.Equals(1))
        //                {
        //                    int foundBLCode = (int)foundRows[0][PrimeSettingInfo.COL_TBSPARTSCODE];
        //                    if (foundBLCode.Equals(targetBLCode))
        //                    {
        //                        // �u�\�������v�ɕύX���ꂽ�D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h���g��������폜
        //                        #region �u�\�������v�ɕύX���ꂽ�D���R�[�h���g��������폜

        //                        // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̍폜���X�g�Ɋ��ɒǉ�����Ă��邩�`�F�b�N
        //                        bool isAddedUserList = false;
        //                        foreach (PrmSettingUWork deletingRecord in userPrmSettingDelList)
        //                        {
        //                            if (
        //                                deletingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                    &&
        //                                deletingRecord.PartsMakerCd.Equals(targetMakerCode)
        //                                    &&
        //                                deletingRecord.TbsPartsCode.Equals(0)
        //                            )
        //                            {
        //                                isAddedUserList = true;
        //                                break;
        //                            }
        //                        }
        //                        // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̍폜���X�g�ɒǉ�����Ă��Ȃ���Βǉ�
        //                        if (!isAddedUserList)
        //                        {
        //                            PrmSettingUWork bl0Record = UserPrimeSettingRecords.Find(
        //                                targetMiddleGroup,
        //                                0,
        //                                targetMakerCode,
        //                                0,
        //                                0
        //                            );
        //                            if (bl0Record != null)
        //                            {
        //                                deletingPrmSettingUListOfBL0.Add(bl0Record);
        //                                //userPrmSettingDelList.Add(bl0Record);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            continue;  // ���ɒǉ�����Ă���΁A���i�Ǘ������ǉ�����Ă���͂�
        //                        }

        //                        // ���i�Ǘ����̍폜���X�g�Ɋ��ɒǉ�����Ă��邩�`�F�b�N
        //                        bool isAddedGoodsList = false;
        //                        foreach (GoodsMngWork deletingRecord in deletingGoodsMngList)
        //                        {
        //                            if (
        //                                deletingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                    &&
        //                                deletingRecord.GoodsMakerCd.Equals(targetMakerCode)
        //                                    &&
        //                                deletingRecord.BLGoodsCode.Equals(0)
        //                            )
        //                            {
        //                                isAddedGoodsList = true;
        //                                break;
        //                            }
        //                        }
        //                        // ���i�Ǘ����̍폜���X�g�ɒǉ�����Ă��Ȃ���Βǉ�
        //                        if (!isAddedGoodsList)
        //                        {
        //                            F_KEY_GOODSMNGLIST goodsMngKey = new F_KEY_GOODSMNGLIST();
        //                            {
        //                                goodsMngKey.goodsMGroup = targetMiddleGroup;
        //                                goodsMngKey.goodsMakerCd= targetMakerCode;
        //                                goodsMngKey.blGoodsCode = 0;
        //                            }
        //                            GoodsMngWork bl0GoodsMngWork = (GoodsMngWork)_GoodsMngList[goodsMngKey];
        //                            if (bl0GoodsMngWork != null)
        //                            {
        //                                deletingGoodsMngListOfBL0.Add(bl0GoodsMngWork);
        //                                //deletingGoodsMngList.Add(bl0GoodsMngWork);
        //                            }
        //                        }

        //                        // �X�V�ΏۂƂȂ��Ă���΁A�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̍X�V���X�g���폜
        //                        foreach (PrmSettingUWork writingRecord in _UserPrimeSettingList)
        //                        {
        //                            if (
        //                                writingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                    &&
        //                                writingRecord.PartsMakerCd.Equals(targetMakerCode)
        //                                    &&
        //                                writingRecord.TbsPartsCode.Equals(0)
        //                            )
        //                            {
        //                                _UserPrimeSettingList.Remove(writingRecord);
        //                                break;
        //                            }
        //                        }

        //                        // �X�V�ΏۂƂȂ��Ă���΁A���i�Ǘ����̍X�V���X�g���폜
        //                        foreach (GoodsMngWork writingRecord in goodsMngList)
        //                        {
        //                            if (
        //                                writingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                    &&
        //                                writingRecord.GoodsMakerCd.Equals(targetMakerCode)
        //                                    &&
        //                                writingRecord.BLGoodsCode.Equals(0)
        //                            )
        //                            {
        //                                goodsMngList.Remove(writingRecord);
        //                                break;
        //                            }
        //                        }

        //                        #endregion  // �u�\�������v�ɕύX���ꂽ�D���R�[�h���g��������폜
        //                    }   // if (foundBLCode.Equals(targetBLCode))
        //                }   // if (foundRows.Length.Equals(1))
        //                else
        //                {
        //                    // ����̒����� + ���[�J�[�ɑ�����BL������������΍폜
        //                    #region ����̒����� + ���[�J�[�ɑ�����BL������������΍폜

        //                    // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̍폜���X�g�Ɋ��ɒǉ�����Ă��邩�`�F�b�N
        //                    bool isAddedUserList = false;
        //                    foreach (PrmSettingUWork deletingRecord in userPrmSettingDelList)
        //                    {
        //                        if (
        //                            deletingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                &&
        //                            deletingRecord.PartsMakerCd.Equals(targetMakerCode)
        //                                &&
        //                            deletingRecord.TbsPartsCode.Equals(0)
        //                        )
        //                        {
        //                            isAddedUserList = true;
        //                            break;
        //                        }
        //                    }
        //                    // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̍폜���X�g�ɒǉ�����Ă��Ȃ���Βǉ�
        //                    if (!isAddedUserList)
        //                    {
        //                        PrmSettingUWork bl0Record = UserPrimeSettingRecords.Find(
        //                            targetMiddleGroup,
        //                            0,
        //                            targetMakerCode,
        //                            0,
        //                            0
        //                        );
        //                        if (bl0Record != null)
        //                        {
        //                            deletingPrmSettingUListOfBL0.Add(bl0Record);
        //                            //userPrmSettingDelList.Add(bl0Record);
        //                        }
        //                    }
        //                    else
        //                    {
        //                        continue;  // ���ɒǉ�����Ă���΁A���i�Ǘ������ǉ�����Ă���͂�
        //                    }

        //                    // ���i�Ǘ����̍폜���X�g�Ɋ��ɒǉ�����Ă��邩�`�F�b�N
        //                    bool isAddedGoodsList = false;
        //                    foreach (GoodsMngWork deletingRecord in deletingGoodsMngList)
        //                    {
        //                        if (
        //                            deletingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                &&
        //                            deletingRecord.GoodsMakerCd.Equals(targetMakerCode)
        //                                &&
        //                            deletingRecord.BLGoodsCode.Equals(0)
        //                        )
        //                        {
        //                            isAddedGoodsList = true;
        //                            break;
        //                        }
        //                    }
        //                    // ���i�Ǘ����̍폜���X�g�ɒǉ�����Ă��Ȃ���Βǉ�
        //                    if (!isAddedGoodsList)
        //                    {
        //                        F_KEY_GOODSMNGLIST goodsMngKey = new F_KEY_GOODSMNGLIST();
        //                        {
        //                            goodsMngKey.goodsMGroup = targetMiddleGroup;
        //                            goodsMngKey.goodsMakerCd = targetMakerCode;
        //                            goodsMngKey.blGoodsCode = 0;
        //                        }
        //                        GoodsMngWork bl0GoodsMngWork = (GoodsMngWork)_GoodsMngList[goodsMngKey];
        //                        if (bl0GoodsMngWork != null)
        //                        {
        //                            deletingGoodsMngListOfBL0.Add(bl0GoodsMngWork);
        //                            //deletingGoodsMngList.Add(bl0GoodsMngWork);
        //                        }
        //                    }

        //                    // �X�V�ΏۂƂȂ��Ă���΁A�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̍X�V���X�g���폜
        //                    foreach (PrmSettingUWork writingRecord in _UserPrimeSettingList)
        //                    {
        //                        if (
        //                            writingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                &&
        //                            writingRecord.PartsMakerCd.Equals(targetMakerCode)
        //                                &&
        //                            writingRecord.TbsPartsCode.Equals(0)
        //                        )
        //                        {
        //                            _UserPrimeSettingList.Remove(writingRecord);
        //                            break;
        //                        }
        //                    }

        //                    // �X�V�ΏۂƂȂ��Ă���΁A���i�Ǘ����̍X�V���X�g���폜
        //                    foreach (GoodsMngWork writingRecord in goodsMngList)
        //                    {
        //                        if (
        //                            writingRecord.GoodsMGroup.Equals(targetMiddleGroup)
        //                                &&
        //                            writingRecord.GoodsMakerCd.Equals(targetMakerCode)
        //                                &&
        //                            writingRecord.BLGoodsCode.Equals(0)
        //                        )
        //                        {
        //                            goodsMngList.Remove(writingRecord);
        //                            break;
        //                        }
        //                    }

        //                    #endregion  // ����̒����� + ���[�J�[�ɑ�����BL������������΍폜
        //                }   // if (foundRows.Length.Equals(1))
        //            }   // foreach (int[] makerBLCode in notVisibledMakerBLCodeList)
        //        }   // if (notVisibledMakerBLCodeList.Count > 0)

        //        #endregion  // BL�R�[�h=0�̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h�̍폜�p�����[�^���\�z
        //        // ADD 2008/02/17 �s��Ή�[11241] ----------<<<<<

        //        #region �����[�g�Ăяo��

        //        #region �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�Ə��i�Ǘ����̍폜

        //        if (userPrmSettingDelList.Count > 0)
        //        {
        //            // DEL 2008/11/21 �s��Ή�[6970] �u�\�����v�̂Ƃ��͍폜����K�v�͂Ȃ� ---------->>>>>
        //            #region �폜�R�[�h
        //            //// ADD 2008/11/04 �s��Ή�[6970] �d�l�ύX ---------->>>>>
        //            //// �폜���鏤�i�Ǘ����
        //            //ArrayList deletingGoodsMngList = new ArrayList();
        //            //foreach (PrmSettingUWork deleteingPrmSettingUWork in userPrmSettingDelList)
        //            //{
        //            //    deletingGoodsMngList.Add(CreateGoodsMngWorkFromMiddleBLMakerTbl(deleteingPrmSettingUWork));
        //            //}
        //            //object objDeletingGoodsMngList = (object)deletingGoodsMngList;
        //            //status = primeSettingSearchDB.Delete(userPrmSettingDelList, objDeletingGoodsMngList);
        //            //// ADD 2008/11/04 �s��Ή�[6970] �d�l�ύX ----------<<<<<
        //            #endregion
        //            // DEL 2008/11/21 �s��Ή�[6970] �u�\�����v�̂Ƃ��͍폜����K�v�͂Ȃ� ----------<<<<<

        //            // DEL 2008/11/04 �s��Ή�[6970]��
        //            //status = primeSettingSearchDB.Delete(userPrmSettingDelList);

        //            // MEMO:�y�f�[�^�x�[�X�폜�z
        //            // ADD 2009/01/21 �s��Ή�[6970] �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���폜����Ƃ��͏��i�Ǘ������폜 ---------->>>>>

        //            // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
        //            //object objDeletingPrimeSettingUList = (object)userPrmSettingDelList;
        //            //object objDeletingGoodsMngList = (object)deletingGoodsMngList;

        //            Dictionary<string, PrmSettingUWork> userPrmSettingDic = new Dictionary<string, PrmSettingUWork>();
        //            foreach (PrmSettingUWork work in userPrmSettingDelList)
        //            {
        //                string key = UserPrimeSettingAgreegate.GetKey(work.GoodsMGroup, work.TbsPartsCode, work.PartsMakerCd,
        //                                                              work.PrmSetDtlNo1, work.PrmSetDtlNo2);

        //                if (!userPrmSettingDic.ContainsKey(key))
        //                {
        //                    userPrmSettingDic.Add(key, work);
        //                }
        //            }

        //            ArrayList addList = new ArrayList();
        //            foreach (PrmSettingUWork work in userPrmSettingDic.Values)
        //            {
        //                addList.Add(work);

        //                ArrayList retList = UserPrimeSettingRecords.FindAll(work.GoodsMGroup, work.TbsPartsCode, work.PartsMakerCd);
        //                if (retList == null)
        //                {
        //                    continue;
        //                }

        //                foreach (PrmSettingUWork work2 in retList)
        //                {
        //                    if (work2.TbsPartsCode == 0)
        //                    {
        //                        continue;
        //                    }

        //                    string key = UserPrimeSettingAgreegate.GetKey(work2.GoodsMGroup, work2.TbsPartsCode, work2.PartsMakerCd,
        //                                                              work2.PrmSetDtlNo1, work2.PrmSetDtlNo2);

        //                    if (!userPrmSettingDic.ContainsKey(key))
        //                    {
        //                        addList.Add(work2);
        //                    }
        //                }
        //            }

        //            object objDeletingPrimeSettingUList = (object)addList;

        //            Dictionary<string, GoodsMngWork> goodsMngWorkDic = new Dictionary<string, GoodsMngWork>();
        //            foreach (GoodsMngWork work in deletingGoodsMngList)
        //            {
        //                string key = work.GoodsMakerCd.ToString("0000") + work.GoodsMGroup.ToString("0000") + work.BLGoodsCode.ToString("00000");
        //                if (!goodsMngWorkDic.ContainsKey(key))
        //                {
        //                    goodsMngWorkDic.Add(key, work);
        //                }
        //            }

        //            ArrayList deleteGoodsMngList = new ArrayList();
        //            foreach (GoodsMngWork work in goodsMngWorkDic.Values)
        //            {
        //                deleteGoodsMngList.Add(work);
        //            }

        //            object objDeletingGoodsMngList = (object)deleteGoodsMngList;
        //            // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

        //            status = primeSettingSearchDB.Delete(objDeletingPrimeSettingUList, objDeletingGoodsMngList);
        //            // ADD 2009/01/21 �s��Ή�[6970] �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���폜����Ƃ��͏��i�Ǘ������폜 ----------<<<<<
        //            // DEL 2009/01/21 �s��Ή�[6970]�� �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���폜����Ƃ��͏��i�Ǘ������폜
        //            //status = primeSettingSearchDB.Delete(userPrmSettingDelList, deletingGoodsMngList);
        //            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //            {
        //                return status;
        //            }
        //        }

        //        #endregion  // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�Ə��i�Ǘ����̍폜

        //        for (int index = 0; index < notVisibledMakerBLCodeList.Count; index++)
        //        {
        //            int[] hoges = notVisibledMakerBLCodeList[index];

        //            ArrayList dataRowViewList = new ArrayList();
        //            foreach (DataRowView primeSettingRow in PrimeSettingView)
        //            {
        //                if ((hoges[0] == (Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]) &&
        //                    (hoges[1] == (Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]) &&
        //                    (hoges[2] == (Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]))
        //                {
        //                    dataRowViewList.Add(primeSettingRow);
        //                }
        //            }

        //            if (dataRowViewList.Count > 1)
        //            {
        //                bool existFlg = false;
        //                foreach (DataRowView drv in dataRowViewList)
        //                {
        //                    if ((Int32)drv[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
        //                    {
        //                        existFlg = true;
        //                        break;
        //                    }
        //                }

        //                if (!existFlg)
        //                {
        //                    continue;
        //                }

        //                DataRowView dr = (DataRowView)dataRowViewList[0];

        //                for (int listIndex = goodsMngList.Count - 1; listIndex >= 0; listIndex--)
        //                {
        //                    GoodsMngWork work = (GoodsMngWork)goodsMngList[listIndex];

        //                    if ((work.GoodsMGroup == (Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]) &&
        //                        (work.GoodsMakerCd == (Int32)dr[PrimeSettingInfo.COL_PARTSMAKERCD]) &&
        //                        (work.BLGoodsCode == (Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]))
        //                    {
        //                        goodsMngList.RemoveAt(listIndex);
        //                    }
        //                }
        //            }
        //        }

        //        foreach (PrmSettingUWork work in _UserPrimeSettingList)
        //        {
        //            if (work.PrimeDisplayCode == 0)
        //            {
        //                for (int index = goodsMngList.Count - 1; index >= 0; index--)
        //                {
        //                    GoodsMngWork gmWork = (GoodsMngWork)goodsMngList[index];

        //                    if (gmWork.FileHeaderGuid != Guid.Empty)
        //                    {
        //                        continue;
        //                    }

        //                    if ((work.PartsMakerCd == gmWork.GoodsMakerCd) &&
        //                        (work.GoodsMGroup == gmWork.GoodsMGroup) &&
        //                        (work.TbsPartsCode == gmWork.BLGoodsCode))
        //                    {
        //                        goodsMngList.RemoveAt(index);
        //                        break;
        //                    }
        //                }
        //            }
        //        }

        //        // MEMO:�y�f�[�^�x�[�X�X�V�z
        //        object objUserPrimeSetting = (object)_UserPrimeSettingList;  // �D�ǐݒ�}�X�^�X�V���X�g
        //        object objGoodsMng = (object)goodsMngList;                   // ���i�Ǘ����}�X�^�X�V���X�g
        //        status = primeSettingSearchDB.Write(ref objUserPrimeSetting, ref objGoodsMng);
        //        if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            return status;
        //        }

        //        //// ADD 2009/02/17 �s��Ή�[11241] ---------->>>>>
        //        //// BL�R�[�h=0�����폜
        //        //if (deletingPrmSettingUListOfBL0.Count > 0)
        //        //{
        //        //    object objDeletingPrimeSettingUListOfBL0 = (object)deletingPrmSettingUListOfBL0;

        //        //    // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
        //        //    //object objDeletingGoodsMngListOfBL0 = (object)deletingGoodsMngListOfBL0;

        //        //    Dictionary<string, GoodsMngWork> goodsMngWorkDic = new Dictionary<string, GoodsMngWork>();
        //        //    foreach (GoodsMngWork work in deletingGoodsMngList)
        //        //    {
        //        //        string key = work.GoodsMakerCd.ToString("0000") + work.GoodsMGroup.ToString("0000") + work.BLGoodsCode.ToString("00000");
        //        //        if (!goodsMngWorkDic.ContainsKey(key))
        //        //        {
        //        //            goodsMngWorkDic.Add(key, work);
        //        //        }
        //        //    }

        //        //    ArrayList deleteGoodsMngList = new ArrayList();
        //        //    foreach (GoodsMngWork work in goodsMngWorkDic.Values)
        //        //    {
        //        //        deleteGoodsMngList.Add(work);
        //        //    }

        //        //    object objDeletingGoodsMngListOfBL0 = (object)deleteGoodsMngList;
        //        //    // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

        //        //    status = primeSettingSearchDB.Delete(objDeletingPrimeSettingUListOfBL0, objDeletingGoodsMngListOfBL0);
        //        //    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        //    {
        //        //        return status;
        //        //    }
        //        //}
        //        //// ADD 2008/02/17 �s��Ή�[11241] ----------<<<<<

        //        #endregion  // �����[�g�Ăяo��

        //        #region ���݂̏�Ԃ��X�V

        //        // ���i�Ǘ���񃊃X�g�X�V
        //        status = getGoodsMngList();
        //        if ((status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) &&
        //            (status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND) &&
        //            (status != (int)ConstantManagement.DB_Status.ctDB_EOF))
        //        {
        //            return status;
        //        }

        //        // �D�ǐݒ�(���[�U)���X�g�X�V
        //        status = getUserPrimesettingList();
        //        // --- ADD 2008/07/01 --------------------------------<<<<< 

        //        #endregion  // ���݂̏�Ԃ��X�V

        //        PrimeSettingView.RowFilter = rowfilter;
        //        PrimeSettingView.Sort = sort;
        //    }
        //    catch (Exception)
        //    {
        //        status = -1;
        //    }

        //    return status;
        //}
        #endregion �d�l���啝�ɕύX�������ߍ폜

        // ADD 2009/01/27 �d�l�ύX �����ރR�[�h�̂�������\�� ---------->>>>>
        /// <summary>
        /// BL�R�[�h��<c>0</c>�̏ꍇ�̎d����R�[�h���擾���܂��B
        /// </summary>
        /// <param name="middleGanreCode">�����ރR�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns></returns>
        private int GetSupplierCodeWhatBLCodeIs0(
            int middleGanreCode,
            int makerCode
        )
        {
            StringBuilder where = new StringBuilder();
            {
                where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append(ADOUtil.EQ).Append(middleGanreCode);
                where.Append(ADOUtil.AND);
                where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append(ADOUtil.EQ).Append(makerCode);
                where.Append(ADOUtil.AND);
                where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append(ADOUtil.NOT_EQ).Append(0);
            }
            DataRow[] foundRows = this.Mg_Bl_MkTable.Select(where.ToString());

            if (foundRows.Length.Equals(0)) return 0;

            int currentSupplierCode = 0;
            {
                if (foundRows[0][PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
                {
                    currentSupplierCode = (int)foundRows[0][PrimeSettingInfo.COL_SUPPLIERCD];
                }

                if (foundRows.Length.Equals(1)) return currentSupplierCode;

                foreach (DataRow foundRow in foundRows)
                {
                    if (foundRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
                    {
                        int foundSupplierCode = (int)foundRow[PrimeSettingInfo.COL_SUPPLIERCD];
                        if (!foundSupplierCode.Equals(currentSupplierCode))
                        {
                            return 0;
                        }
                    }
                }
            }
            return currentSupplierCode;
        }
        // ADD 2009/01/27 �d�l�ύX �����ރR�[�h�̂�������\�� ----------<<<<<

        /// <summary>�X�V�O�`�F�b�N�G���[�萔</summary>
        public const int UPDATE_CHECK_ERROR = -1;

        /// <summary>
        /// �S�Ă̒�����/BL/���[�J�[���R�[�h�Ɏd����R�[�h���ݒ肳��Ă��邩���肵�܂��B
        /// </summary>
        /// <param name="errorMessage">�G���[���b�Z�[�W</param>
        /// <returns>
        /// <c>true</c> :�d����R�[�h���ݒ肳��Ă���B<br/>
        /// <c>false</c>:�d����R�[�h���ݒ肳��Ă��Ȃ��B
        /// </returns>
        private bool HasSupplierCodeOfAllMg_Bl_MkView(out string errorMessage)
        {
            errorMessage = string.Empty;

            string currentRowFilter = this.Mg_Bl_MkView.RowFilter;
            try
            {
                this.Mg_Bl_MkView.RowFilter = string.Empty;

                foreach (DataRowView record in this.Mg_Bl_MkView)
                {
                    if ((CheckState)record[COL_CHECKSTATE] == CheckState.Unchecked) continue;
                    if (IsCommonRowOfMiddleGBLMakerDataTable(record)) continue; // ���ʃ��R�[�h�͖���

                    if (
                        string.IsNullOrEmpty(record[PrimeSettingInfo.COL_SUPPLIERCD].ToString())
                            ||
                        ((int)record[PrimeSettingInfo.COL_SUPPLIERCD]) <= 0
                    )
                    {
                        int makerCode   = (int)record[PrimeSettingInfo.COL_PARTSMAKERCD];
                        int middleCode  = (int)record[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                        int blCode      = (int)record[PrimeSettingInfo.COL_TBSPARTSCODE];

                        if (blCode == 0)
                        {
                            continue;
                        }

                        NoteChangedEventArgs errMsg = new NoteChangedEventArgs(middleCode, blCode, makerCode, string.Empty);

                        errorMessage = "�d����R�[�h�������͂ł��B( " + errMsg.ToString() + " )";

                        return false;
                    }
                }
            }
            finally
            {
                this.Mg_Bl_MkView.RowFilter = currentRowFilter;
            }

            return true;
        }

        /// <summary>
        /// ������/BL/���[�J�[�f�[�^�e�[�u���̃t�B���^��������擾���܂��B
        /// </summary>
        /// <param name="maker">���[�J�[�R�[�h</param>
        /// <param name="middle">�����ރR�[�h</param>
        /// <param name="bl">BL�R�[�h</param>
        /// <returns>������/BL/���[�J�[�f�[�^�e�[�u���̃t�B���^������</returns>
        public static string GetWhere(int maker, int middle, int bl)
        {
            StringBuilder where = new StringBuilder();

            where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append("=").Append(maker);
            where.Append(" and ");
            where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append("=").Append(middle);
            where.Append(" and ");
            where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append("=").Append(bl);

            return where.ToString();
        }

        private static ArrayList CreateArrayList(Hashtable hashTable)
        {
            ArrayList arrayList = new ArrayList();
            foreach (object val in hashTable.Values)
            {
                arrayList.Add(val);

                GoodsMngWork work = (GoodsMngWork)val;
                if (work.GoodsMakerCd.Equals(1002) && work.BLGoodsCode.Equals(92))
                {
                    Debug.WriteLine(work.GoodsMakerCd.ToString() + ", " + work.BLGoodsCode.ToString());
                }
            }
            return arrayList;
        }

        // ADD 2008/11/04 �s��Ή�[6970] �d�l�ύX ---------->>>>>
        /// <summary>
        /// ������/BL/���[�J�[�e�[�u����菤�i�Ǘ����𐶐����܂��B
        /// </summary>
        /// <param name="prmSettingUWork">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j���</param>
        /// <returns>���i�Ǘ����</returns>
        [Obsolete("�폜�\��")]
        private GoodsMngWork CreateGoodsMngWorkFromMiddleBLMakerTbl(PrmSettingUWork prmSettingUWork)
        {
            GoodsMngWork goodsMngWork = new GoodsMngWork();

            goodsMngWork.EnterpriseCode = this._enterpriseCode; // ��ƃR�[�h
            goodsMngWork.SectionCode    = this._sectionCode;    // ���_�R�[�h


            StringBuilder where = new StringBuilder();
            where.Append(PrimeSettingInfo.COL_MIDDLEGENRECODE).Append("=").Append(prmSettingUWork.GoodsMGroup);
            where.Append(" AND ");
            where.Append(PrimeSettingInfo.COL_TBSPARTSCODE).Append("=").Append(prmSettingUWork.TbsPartsCode);
            where.Append(" AND ");
            where.Append(PrimeSettingInfo.COL_PARTSMAKERCD).Append("=").Append(prmSettingUWork.PartsMakerCd);

            DataRow[] foundMiddleBLMakerDataRows = Mg_Bl_MkTable.Select(where.ToString());
            goodsMngWork.GoodsMakerCd   = (int)foundMiddleBLMakerDataRows[0][PrimeSettingInfo.COL_PARTSMAKERCD];    // ���i���[�J�[�R�[�h
            goodsMngWork.BLGoodsCode    = (int)foundMiddleBLMakerDataRows[0][PrimeSettingInfo.COL_TBSPARTSCODE];    // BL���i�R�[�h
            goodsMngWork.SupplierCd     = (int)foundMiddleBLMakerDataRows[0][PrimeSettingInfo.COL_SUPPLIERCD];      // �d����R�[�h


            // ���i�Ǘ����̍X�V����
            F_KEY_GOODSMNGLIST keyOfGoodMngList = new F_KEY_GOODSMNGLIST();
            keyOfGoodMngList.goodsMGroup    = goodsMngWork.GoodsMGroup; // ADD 2009/01/26 �d�l�ύX�F���i�Ǘ����ɒ����ރR�[�h��ǉ�
            keyOfGoodMngList.goodsMakerCd   = goodsMngWork.GoodsMakerCd;// ���i���[�J�[�R�[�h
            keyOfGoodMngList.blGoodsCode    = goodsMngWork.BLGoodsCode; // BL���i�R�[�h

            goodsMngWork.UpdateDateTime = ((GoodsMngWork)_GoodsMngList[keyOfGoodMngList]).UpdateDateTime;

            return goodsMngWork;
        }
        // ADD 2008/11/04 �s��Ή�[6970] �d�l�ύX ----------<<<<<

        /// <summary>
        /// ���i�Ǘ���񃊃X�g�X�V
        /// </summary>
        [Obsolete("�g�p����Ă��Ȃ��Ǝv���邽�߁A�p�~�\��")]
        public void updateGoodsMngList(int goodsMGroup, int goodsMakerCd, int blGoodsCode, int supplierCd)   // TODO:���i�Ǘ���񃊃X�g�̍X�V
        {
            F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();
            GoodsMngWork goodsMngWork;

            keyGoodsMngList.blGoodsCode = blGoodsCode;
            keyGoodsMngList.goodsMakerCd = goodsMakerCd;
            keyGoodsMngList.goodsMGroup = goodsMGroup;  // ADD 2009/01/26 �d�l�ύX�F���i�Ǘ����ɒ����ރR�[�h��ǉ�

            if (_GoodsMngList[keyGoodsMngList] != null)
            {
                goodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                goodsMngWork.SupplierCd = supplierCd;
            }
            else
            {
                goodsMngWork = new GoodsMngWork();
                goodsMngWork.EnterpriseCode = this._enterpriseCode;
                goodsMngWork.SectionCode = this._sectionCode;
                goodsMngWork.GoodsMakerCd = goodsMakerCd;
                goodsMngWork.BLGoodsCode = blGoodsCode;
                goodsMngWork.SupplierCd = supplierCd;

                // ���i�Ǘ���񃊃X�g�ɒǉ�
                _GoodsMngList.Add(keyGoodsMngList, goodsMngWork);
            }
        }

        /// <summary>
        /// �f�[�^�X�V(�񋟂��폜���ꂽ���̃��X�g�j
        /// </summary>
        /// <returns>�G���[�R�[�h ���펞�O</returns>
        /// <remarks>
        /// <br>Update Note: 2018/10/25 �c����</br>
        /// <br>�@�@�@�@�@ : Redmine#49731�̏�Q�Ή�</br>
        /// </remarks>
        public int updateUserDeleteList()
        {
            int status = -1;

            /* --- DEL 2008/07/01 -------------------------------->>>>>
            object obj = (object)_UserDeleteList;
            return primeSettingSearchDB.Update(ref obj);  
               --- DEL 2008/07/01 --------------------------------<<<<< */

            // --- ADD 2008/07/01 -------------------------------->>>>>
            try
            {
                // DEL 2008/11/04 �s��Ή�[6970]��
                //status = primeSettingSearchDB.Delete(objUserDeleteList);

                object objUserDeleteList = (object)_UserDeleteList;

                // ADD 2008/11/04 �s��Ή�[6970] �d�l�ύX ---------->>>>>
                // --- DEL �c���� 2018/10/25 Redmine#49731�̏�Q�Ή�---------->>>>>
                //ArrayList deletingGoodsMngList = new ArrayList();
                //foreach (PrmSettingUWork prmSettingUWork in _UserDeleteList)
                //{
                //    // TODO:���i�Ǘ����̍\�z�i�폜�p�j
                //    if (ContainsGoodsMng(prmSettingUWork.GoodsMGroup, prmSettingUWork.PartsMakerCd, prmSettingUWork.TbsPartsCode))
                //    {
                //        deletingGoodsMngList.Add(GetGoodsMngWork(prmSettingUWork.GoodsMGroup, prmSettingUWork.PartsMakerCd, prmSettingUWork.TbsPartsCode));
                //    }
                //}
                // --- DEL �c���� 2018/10/25 Redmine#49731�̏�Q�Ή�----------<<<<<

                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                //object objDeletingGoodsMngList = (object)deletingGoodsMngList;

                // --- DEL �c���� 2018/10/25 Redmine#49731�̏�Q�Ή�---------->>>>>
                //Dictionary<string, GoodsMngWork> goodsMngWorkDic = new Dictionary<string, GoodsMngWork>();
                //foreach (GoodsMngWork work in deletingGoodsMngList)
                //{
                //    string key = work.GoodsMakerCd.ToString("0000") + work.GoodsMGroup.ToString("0000") + work.BLGoodsCode.ToString("00000");
                //    if (!goodsMngWorkDic.ContainsKey(key))
                //    {
                //        goodsMngWorkDic.Add(key, work);
                //    }
                //}
                // --- DEL �c���� 2018/10/25 Redmine#49731�̏�Q�Ή�----------<<<<<

                ArrayList deleteGoodsMngList = new ArrayList();
                // --- DEL �c���� 2018/10/25 Redmine#49731�̏�Q�Ή�---------->>>>>
                //foreach (GoodsMngWork work in goodsMngWorkDic.Values)
                //{
                //    deleteGoodsMngList.Add(work);
                //}
                // --- DEL �c���� 2018/10/25 Redmine#49731�̏�Q�Ή�----------<<<<<
                object objDeletingGoodsMngList = (object)deleteGoodsMngList;
                // --- CHG 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                status = primeSettingSearchDB.Delete(objUserDeleteList, objDeletingGoodsMngList);   // TODO:�폜���\�b�h��
                // ADD 2008/11/04 �s��Ή�[6970] �d�l�ύX ----------<<<<<
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
            // --- ADD 2008/07/01 --------------------------------<<<<< 
        }

        /// <summary>
        /// �`�F�b�N�������[�J�[�̕\�����ʂ𒆕���/�i��/���[�J�[�r���[�ɃZ�b�g
        /// </summary>
        [Obsolete("�\�����������I�ɘA�Ԃɐݒ肵�����܂��B")]
        public void setMakerDispOrderView()
        {
            // HACK:�\������������������
            string rowfilter = Mg_Bl_MkView.RowFilter;
            string sort = Mg_Bl_MkView.Sort;

            Hashtable MgBlht = new Hashtable();
            int order = 1;
            Mg_Bl_MkView.RowFilter = String.Format("{0}=1", COL_CHECKSTATE);
            Mg_Bl_MkView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_MAKERDISPORDER);
            foreach (DataRowView dr in Mg_Bl_MkView)
            {
                string skey = ((Int32)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4") + ((Int32)dr[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8");
                if (MgBlht[skey] == null)
                {
                    MgBlht.Add(skey, dr);
                    order = 1;
                }
                else
                {
                    order++;
                }
                dr[PrimeSettingInfo.COL_MAKERDISPORDER] = order;
            }
            Mg_Bl_MkView.RowFilter = rowfilter;
            Mg_Bl_MkView.Sort = sort;
        }


        /// <summary>
        /// ���[�J�[�\�����ʁA�ύX�t���O�A�`�F�b�N�{�b�N�X�̏�Ԃ�D�ǐݒ胊�X�g�ɃZ�b�g
        /// </summary>
        public void updateCheckPrimeSettingList()
        {
            string rowfilter = PrimeSettingView.RowFilter;
            PrimeSettingView.RowFilter = "";

            //�L�[���쐬
            foreach (DataRowView primeSettingRow in PrimeSettingView)
            {
                //�L�[���쐬
                string str = ((Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                            + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")
                            + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                            + ((Int32)primeSettingRow[PrimeSettingInfo.COL_SECRETCODE]).ToString("d4")
                            + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]).ToString("d4")
                            ;

                bool changeFlg = false;

                if (_Mg_Bl_Mk_List[str] != null)
                {
                    DataRow MgBlMkdr = (DataRow)_Mg_Bl_Mk_List[str];
                    if (MgBlMkdr[COL_CHECKSTATE] == (object)CheckState.Unchecked)
                    {
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0;
                    }
                    //primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] = MgBlMkdr[PrimeSettingInfo.COL_MAKERDISPORDER];
                    primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] = MgBlMkdr[PrimeSettingAcs.COL_USER_MAKERDISPORDER];
                    primeSettingRow[COL_CHECKSTATE] = MgBlMkdr[COL_CHECKSTATE];
                    if ((CheckState)primeSettingRow[COL_ORIGINAL_CHECKSTATE] != (CheckState)MgBlMkdr[COL_CHECKSTATE])
                    {
                        changeFlg = true;
                    }
                }

                //���[�U�[�o�^���������ꍇ�͉������Ȃ�
                if (primeSettingRow[COL_USERPRIMESETTING] == System.DBNull.Value) continue;

                //�ύX����Ă��Ȃ��ꍇ�͉������Ȃ�
                PrmSettingUWork userdrv = (PrmSettingUWork)primeSettingRow[COL_USERPRIMESETTING];

                primeSettingRow[COL_CHANGEFLAG] = true;

                if (userdrv.MakerDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] &&       //���[�J�[�\������
                    //userdrv.DisplayOrder == (Int32)drv[PrimeSettingInfo.COL_DISPLAYORDER] &&         //�\������          // DEL 2008/07/01
                    userdrv.PrimeDispOrder == (Int32)primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] &&         //�\������          // ADD 2008/07/01
                    userdrv.PrimeDisplayCode == (Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] &&   //�D�Ǖ\���敪
                    //userdrv.PrimeKindName == (string)drv[PrimeSettingInfo.COL_PRIMEKINDNAME])        //��ʖ���          // DEL 2008/07/01
                    userdrv.PrmSetDtlName2 == (string)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME] &&    //��ʖ���          // ADD 2008/07/01
                    changeFlg == false)         
                {
                    primeSettingRow[COL_CHANGEFLAG] = false; 
                }

                
                // --- ADD 2008/07/01 -------------------------------->>>>>
                F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();
                GoodsMngWork goodsMngWork;
                bool supplierChange = false;

                keyGoodsMngList.blGoodsCode = (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];   // BL�R�[�h
                keyGoodsMngList.goodsMakerCd = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];  // ���i���[�J�[�R�[�h
                keyGoodsMngList.goodsMGroup = (int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];// �����ރR�[�h

                // ���i�Ǘ���񃊃X�g�Ƀf�[�^����H
                if (_GoodsMngList[keyGoodsMngList] != null)
                {
                    // ���i�Ǘ���񃊃X�g����Y���f�[�^�擾
                    goodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                    // �d����͐ݒ肳��Ă���H
                    if (primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
                    {
                        // �d����R�[�h���قȂ�ꍇ
                        if (goodsMngWork.SupplierCd != (int)primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD])
                        {
                            supplierChange = true;
                        }
                    }
                    else
                    {
                        // �d���悪�N���A���ꂽ�ꍇ
                        if (goodsMngWork.SupplierCd != 0)
                        {
                            supplierChange = true;
                        }
                    }
                }
                else
                {
                    // �V�K�Ɏd���悪�ݒ肳�ꂽ�ꍇ
                    if (primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] != DBNull.Value)
                    {
                        supplierChange = true;
                    }
                }

                // �d����ȊO���ύX�Ȃ��ꍇ
                if ((bool)primeSettingRow[COL_CHANGEFLAG] == false)
                {
                    // �ύX�t���O�ݒ�
                    primeSettingRow[COL_CHANGEFLAG] = supplierChange;
                }
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }   // foreach (DataRowView primeSettingRow in PrimeSettingView)

            PrimeSettingView.RowFilter = rowfilter;
        }

        /// <summary>
        /// �d����R�[�h�ύX���ɕύX�t���O���X�V����
        /// </summary>
        public void ChangeSupplierCd(int goodsMGroup, int partsMakerCd, int tbsPartsCode, int supplierCd)
        {
            foreach (DataRowView drv in PrimeSettingView)
            {
                if (((int)drv[PrimeSettingInfo.COL_MIDDLEGENRECODE] == goodsMGroup) &&
                    ((int)drv[PrimeSettingInfo.COL_PARTSMAKERCD] == partsMakerCd) &&
                   ((int)drv[PrimeSettingInfo.COL_TBSPARTSCODE] == tbsPartsCode))
                {
                    // �d����R�[�h�X�V
                    drv[PrimeSettingInfo.COL_SUPPLIERCD] = supplierCd;

                    break;
                }
            }
        }

        // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ---------->>>>>
        /// <summary>
        /// �D�ǐݒ���l�n�b�V���e�[�u���̃L�[���擾���܂��B
        /// </summary>
        /// <param name="middleCode">�����ރR�[�h</param>
        /// <param name="blCode">BL�R�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>�����ރR�[�h(4��)+BL�R�[�h(8��)+���[�J�[�R�[�h(4��)</returns>
        public static string GetKeyOfOfferPrimeSettingNote(
            int middleCode,
            int blCode,
            int makerCode
        )
        {
            Debug.WriteLine("�����ށF" + middleCode.ToString() + ", BL�F" + blCode.ToString() + ", ���[�J�[�F" + makerCode.ToString());
            return middleCode.ToString("d4") + blCode.ToString("d8") + makerCode.ToString("d4");
        }
        // ADD 2008/10/30 �s��Ή�[6961] �d�l�ύX ----------<<<<<

        // ADD 2009/01/14 �d�l�ύX�F�����ރR�[�h�̂�������\�� ---------->>>>>
        /// <summary>
        /// �w�肵�����[�J�[�R�[�h���w�肵�������ރR�[�h�Ɋ֘A�t�������肵�܂��B
        /// </summary>
        /// <param name="middleGenreCode">�����ރR�[�h</param>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns></returns>
        public bool ContainsMakerCode(
            int middleGenreCode,
            int makerCode
        )
        {
            return MakerList.ContainsMakerCode(middleGenreCode, makerCode);
        }

        /// <summary>
        /// �����ރR�[�h�Ɋ֘A�t�����[�J�[�R�[�h���������܂��B
        /// </summary>
        /// <param name="middleGenreCode">�����ރR�[�h</param>
        /// <returns>�����ރR�[�h�Ɋ֘A�t�����[�J�[�R�[�h</returns>
        public IList<int> FindMakerCode(int middleGenreCode)
        {
            return MakerList.FindMakerCode(middleGenreCode);
        }
        // ADD 2009/01/14 �d�l�ύX�F�����ރR�[�h�̂�������\�� ----------<<<<<

        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
        /// <summary>
        /// �֘ABL�R�[�h�̕�������擾���܂��B
        /// </summary>
        /// <param name="blCode">BL�R�[�h</param>
        /// <returns>BL�R�[�h("0000") + ":" + ����</returns>
        public string GetRelatedBLCodeName(int blCode)
        {
            string blName = string.Empty;
            if (this._TbsPartsCodeList.ContainsKey(blCode.ToString("d8")))
            {
                blName = ((TbsPartsCodeWork)this._TbsPartsCodeList[blCode.ToString("d8")]).TbsPartsFullName;
            }
            return blCode.ToString("d4") + ":" + blName;
        }
        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<

        # endregion

        #region Private method

        /// <summary>
        /// �����ރ��X�g�擾
        /// </summary>
        //private void getOfferMiddleGenreList()  // DEL 2008/07/01
        private int getOfferMiddleGenreList()     // ADD 2008/07/01
        {
            PrmSettingWork offerMiddleGenreWork = new PrmSettingWork();
            ArrayList al = new ArrayList();
            al.Add(offerMiddleGenreWork);
            object objret = null;
            int status = -1;  // ADD 2008/07/01

            try
            {
                //int status = offerMiddleGenreDB.Search(ref objret, (object)offerMiddleGenreWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);  // DEL 2008/07/01
                status = offerMiddleGenreDB.Search(out objret, (object)offerMiddleGenreWork);  // ADD 2008/07/01

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  // ADD 2008/07/01
                {
                    //foreach (OfferMiddleGenreWork wkOfferMiddleGenreWork in (ArrayList)objret)
                    foreach (GoodsMGroupWork wkOfferMiddleGenreWork in (ArrayList)objret)
                    //���i���[�J�[���ʃN���X
                    {
                        //_MiddleGenreList.Add(((Int32)wkOfferMiddleGenreWork.MiddleGenreCode).ToString("d4"), wkOfferMiddleGenreWork);
                        _MiddleGenreList.Add(((Int32)wkOfferMiddleGenreWork.GoodsMGroup).ToString("d4"), wkOfferMiddleGenreWork);
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

�@      /// <summary>
        /// ���i���[�J�[���X�g�擾
        /// </summary>
        //private void getPartsMakerList()  // DEL 2008/07/01
        private int getPartsMakerList()    // ADD 2008/07/01 
        {
            /* --- DEL 2008/07/01 -------------------------------->>>>>
            PMakerNmWork pMakerNmWork = new PMakerNmWork();

			ArrayList al = new ArrayList();
            al.Add(pMakerNmWork);
               --- DEL 2008/07/01 --------------------------------<<<<< */

            object objret = null;
            int status = -1;  // ADD 2008/07/01 

            try
            {
                //int status = pMakerNmDB.Search(out objret,(object)pMakerNmWork,0,Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                status = pMakerNmDB.Search(out objret, 0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)  // ADD 2008/07/01
                {
                    foreach (PMakerNmWork wkPMakerNmWork in (ArrayList)objret)
                    //���i���[�J�[���ʃN���X
                    {
                        _PartsMakerList.Add(((Int32)wkPMakerNmWork.PartsMakerCode).ToString("d4"), wkPMakerNmWork);
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        // --- ADD 2008/07/01 -------------------------------->>>>>
        /// <summary>
        /// �d���惊�X�g�擾
        /// </summary>
        private int getSupplierList()
        {
            SupplierAcs _supplierAcs = new SupplierAcs();
            Supplier supplier = new Supplier();
            ArrayList supplierList = new ArrayList();
            int status = -1;

            try
            {
                _SupplierList.Clear();

                // �d������擾
                status = _supplierAcs.Search(out supplierList, this._enterpriseCode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (Supplier wkSupplier in supplierList)
                    {
                        // �d���惊�X�g�ɒǉ�
                        _SupplierList.Add(wkSupplier.SupplierCd, wkSupplier);
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ���i�Ǘ���񃊃X�g�擾
        /// </summary>
        private int getGoodsMngList()
        {
            object objret = null;
            object paraObjret = null;
            GoodsMngWork paraGoodsMngWork = new GoodsMngWork();
            F_KEY_GOODSMNGLIST keyGoodMngList = new F_KEY_GOODSMNGLIST();
            int status = -1; 

            try
            {
                // ���i�Ǘ���񃊃X�g�N���A
                _GoodsMngList.Clear();

                if (this.EnterPriseCode != null)
                {
                    // ��ƃR�[�h
                    paraGoodsMngWork.EnterpriseCode = this.EnterPriseCode;
                }
                if (this._sectionCode != null)
                {
                    // ���_�R�[�h
                    paraGoodsMngWork.SectionCode = this._sectionCode;
                }

                paraObjret = paraGoodsMngWork;

                // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //// ���i�Ǘ����擾
                //status = goodsMngDB.Search(out objret, paraObjret, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                // ���i�Ǘ����擾
                status = goodsMngDB.Search(out objret, paraObjret, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetDataAll);
                // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (GoodsMngWork wkGoodsMng in (ArrayList)objret)
                    {
                        // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki 2008/09/12 ADD
                        // �i�ԒP�ʂŐݒ肳��Ă��郌�R�[�h�͖�������B
                        if ( wkGoodsMng.GoodsNo.TrimEnd() != string.Empty ) continue;
                        // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki 2008/09/12 ADD

                        //�L�[���쐬
                        keyGoodMngList.goodsMGroup = wkGoodsMng.GoodsMGroup;    // ADD 2009/01/26 �d�l�ύX�F���i�Ǘ����ɒ����ރR�[�h��ǉ�
                        keyGoodMngList.goodsMakerCd = wkGoodsMng.GoodsMakerCd;  // ���i���[�J�[�R�[�h
                        keyGoodMngList.blGoodsCode = wkGoodsMng.BLGoodsCode;    // BL���i�R�[�h
                        //keyGoodMngList.goodsNo = wkGoodsMng.GoodsNo;            // ���i�ԍ�

                        //DataRow��HashTable�ɓo�^���Ă���
                        _GoodsMngList.Add(keyGoodMngList, wkGoodsMng);  // ���i�Ǘ����̃L���b�V���o�^
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }
        // --- ADD 2008/07/01 --------------------------------<<<<< 

        /// <summary>
        /// BL�R�[�h���X�g�擾
        /// </summary>
        //private void getOfferTbsPartsList()  // DEL 2008/07/01
        private int getOfferTbsPartsList()     // ADD 2008/07/01
        {
            TbsPartsCodeWork tbsPartsCodeWork = new TbsPartsCodeWork();
            
            /* --- DEL 2008/07/01 -------------------------------->>>>>
            ArrayList al = new ArrayList();
            al.Add(tbsPartsCodeWork);
            if (this.EnterPriseCode != null)
            {
                tbsPartsCodeWork.EnterpriseCode = this.EnterPriseCode; 
            }
               --- DEL 2008/07/01 --------------------------------<<<<< */

            object objret = null;
            // --- ADD 2008/07/01 -------------------------------->>>>>
            object paraobj = tbsPartsCodeWork;  
            int status = -1;
            // --- ADD 2008/07/01 --------------------------------<<<<< 

            try
            {
                //int status = offerTbsPartsCodeDB.Search(ref objret, (object)al, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);  // DEL 2008/07/01
                status = offerTbsPartsCodeDB.Search(out objret, paraobj);  // ADD 2008/07/01

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    foreach (TbsPartsCodeWork wktbsPartsCodeWork in (ArrayList)objret)
                    //BL���i�R�[�h���ʃN���X
                    {
                        //�}�ԕt���͏d������̂œǂݔ�΂�
                        //��F1232 0 �t�����g���C�p�[�A�[��
                        //�@�@1232 1 �t�����g���C�p�[�A�[���@�E
                        //�@�@1232 2 �t�����g���C�p�[�A�[���@��
                        if (wktbsPartsCodeWork.TbsPartsCdDerivedNo != 0) continue;
                        _TbsPartsCodeList.Add(((Int32)wktbsPartsCodeWork.TbsPartsCode).ToString("d8"), wktbsPartsCodeWork);
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// ���[�U�[�D�ǐݒ胊�X�g�擾
        /// </summary>
        //private void getUserPrimesettingList()  // DEL 2008/07/01
        private int getUserPrimesettingList()     // ADD 2008/07/01
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            //PrimeSettingParaWork primeSettingParaWork = new PrimeSettingParaWork();  // DEL 2008/07/01
            PrmSettingUWork primeSettingParaWork = new PrmSettingUWork();              // ADD 2008/07/01

            /* --- DEL 2008/07/01 -------------------------------->>>>>
            ArrayList al = new ArrayList();
            al.Add(primeSettingParaWork);
            object objret = null;
               --- DEL 2008/07/01 --------------------------------<<<<< */

            ArrayList wkList = new ArrayList();
            object objret = wkList;

            UserPrimeSettingRecords.Clear();    // ADD 2009/01/21 �s��Ή�[6970]

            int status = -1;  // ADD 2008/07/01

            try
            {
                if (this._enterpriseCode != null)
                {
                    // ��ƃR�[�h
                    primeSettingParaWork.EnterpriseCode = this._enterpriseCode;
                }

                if (this._sectionCode != null)
                {
                    // ���_�R�[�h
                    primeSettingParaWork.SectionCode = this._sectionCode;
                }

                // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                primeSettingParaWork.PrimeDisplayCode = -1;
                // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<

                //int status = primeSettingSearchDB.Search(ref objret, primeSettingParaWork);
                status = primeSettingSearchDB.Search(ref objret, primeSettingParaWork, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    DefaultMakerDispOrderManagaer defaultMakerDispOrderMng = new DefaultMakerDispOrderManagaer();   // ADD 2008/12/05 �s��Ή�[8524] �d�l�ύX �\�������ݒ肳��Ă��Ȃ��ꍇ�A1�`�����ō̔�

                    Debug.WriteLine("�D�ǐݒ�}�X�^�i���[�U�[�j��Ǎ����F");
                    //foreach (PrimeSettingWork wkPrimeSettingWork in (ArrayList)objret)  // DEL 2008/07/01
                    foreach (PrmSettingUWork userPrimeSettingUWork in (ArrayList)objret)     // ADD 2008/07/01
                    {
                        //�L�[���쐬
                        //string str = (wkPrimeSettingWork.MiddleGenreCode.ToString("d4")  // DEL 2008/07/01
                        string str = (userPrimeSettingUWork.GoodsMGroup.ToString("d4")        // ADD 2008/07/01 
                                    + userPrimeSettingUWork.PartsMakerCd.ToString("d4")
                                    + userPrimeSettingUWork.TbsPartsCode.ToString("d8")
                                    + userPrimeSettingUWork.TbsPartsCdDerivedNo.ToString("d2")
                            /* --- DEL 2008/07/01 -------------------------------->>>>>
                            + wkPrimeSettingWork.SelectCode.ToString("d4")
                            + wkPrimeSettingWork.PrimeKindCode.ToString("d2"));
                               --- DEL 2008/07/01 --------------------------------<<<<< */

                                    // --- ADD 2008/07/01 -------------------------------->>>>>
                                    + userPrimeSettingUWork.PrmSetDtlNo1.ToString("d4")
                                    + userPrimeSettingUWork.PrmSetDtlNo2.ToString("d2"));
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        if (userPrimeSettingUWork.TbsPartsCode.Equals(0))
                        {
                            if (userPrimeSettingUWork.GoodsMGroup.Equals(10) && userPrimeSettingUWork.PartsMakerCd.Equals(1185))
                            {
                                // HACK:????
                                Debug.WriteLine("�����ށF" + userPrimeSettingUWork.GoodsMGroup.ToString() + ", ���[�J�[�F" + userPrimeSettingUWork.PartsMakerCd.ToString());
                            }
                        }

                        if (_PrimeSettingList[str] != null) // MEMO:�{���\�b�h��DataSearch()�ŌĂ΂��B���̍ہA��ɒ񋟕��̓ǂݍ��݂��s���A���LHashtable���\�z����Ă���
                        {
                            // MEMO:�Y�����郆�[�U�[�D�ǐݒ�f�[�^���L��
                            if (userPrimeSettingUWork.LogicalDeleteCode == 0)
                            {
                                DataRow primedr = (DataRow)_PrimeSettingList[str];
                                //DataRow�Ɏ擾�������[�N���Z�b�g
                                primedr[COL_USERPRIMESETTING] = userPrimeSettingUWork;

                                //�J�����Ƀf�[�^���Z�b�g
                                primedr[PrimeSettingInfo.COL_MAKERDISPORDER] = userPrimeSettingUWork.MakerDispOrder;
                                
                                // ADD 2008/12/05 �s��Ή�[8524] �d�l�ύX �\�������ݒ肳��Ă��Ȃ��ꍇ�A1�`�����ō̔� ---------->>>>>
                                // �f�t�H���g�̕\������ݒ�p�Ɉꎞ�I�ɕێ�
                                if (userPrimeSettingUWork.MakerDispOrder > 0)
                                {
                                    defaultMakerDispOrderMng.Reserve(
                                        userPrimeSettingUWork.GoodsMGroup,
                                        userPrimeSettingUWork.TbsPartsCode,
                                        userPrimeSettingUWork.MakerDispOrder
                                    );
                                }
                                else
                                {
                                    defaultMakerDispOrderMng.Add(
                                        userPrimeSettingUWork.GoodsMGroup,
                                        userPrimeSettingUWork.TbsPartsCode,
                                        primedr
                                    );
                                }
                                // ADD 2008/12/05 �s��Ή�[8524] �d�l�ύX �\�������ݒ肳��Ă��Ȃ��ꍇ�A1�`�����ō̔� ----------<<<<<

                                //primedr[PrimeSettingInfo.COL_DISPLAYORDER] = wkPrimeSettingWork.DisplayOrder;
                                primedr[PrimeSettingInfo.COL_DISPLAYORDER] = userPrimeSettingUWork.PrimeDispOrder;
                                //primedr[COL_CHECKSTATE] = CheckState.Checked;
                                primedr[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = userPrimeSettingUWork.PrimeDisplayCode;   // TODO:�D�Ǖ\���敪

                                UserPrimeSettingRecords.Add(userPrimeSettingUWork); // ADD 2009/01/21 �s��Ή�[6970]
                            }
                        }
                        //�񋟂������͍̂폜����Ă���f�[�^�Ȃ̂ō폜���X�g�ɓo�^����i�񋟂��_���폜�ł͂Ȃ����R�[�h�폜���ꂽ�j
                        else
                        {
                            userPrimeSettingUWork.LogicalDeleteCode = 3; // �_���폜�敪�i�����폜�Ȃ̂œ��e�̓`�F�b�N���Ȃ��j
                            //���X�g�ɍ폜�Œǉ�(����Ă����ƃ����[�g�ĂԂ����ł����̂Ŋy�j
                            _UserDeleteList.Add(userPrimeSettingUWork);

                            DataRow primeSettingRow = UserPrimeSettingTable.NewRow();
                            UserPrimeSettingTable.Rows.Add(primeSettingRow);

                            /* --- DEL 2008/07/01 -------------------------------->>>>>
                            primedr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = wkPrimeSettingWork.PartsMakerFullName;
                            primedr[PrimeSettingInfo.COL_TBSPARTSCODE] = wkPrimeSettingWork.TbsPartsCode;
                            primedr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = wkPrimeSettingWork.TbsPartsFullName;
                            primedr[PrimeSettingInfo.COL_SELECTNAME] = wkPrimeSettingWork.SelectCode.ToString();
                            primedr[PrimeSettingInfo.COL_PRIMEKINDNAME] = wkPrimeSettingWork.PrimeKindName;
                               --- DEL 2008/07/01 --------------------------------<<<<< */

                            // --- ADD 2008/07/01 -------------------------------->>>>> 
                            PMakerNmWork pMakerNmWork;

                            if (_PartsMakerList[userPrimeSettingUWork.PartsMakerCd.ToString("d4")] != null)
                            {
                                pMakerNmWork = (PMakerNmWork)_PartsMakerList[userPrimeSettingUWork.PartsMakerCd.ToString("d4")];

                                // ���[�J�[���̐ݒ�
                                primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = pMakerNmWork.PartsMakerFullName;
                            }

                            TbsPartsCodeWork tbsPartsCodeWork;

                            if (_TbsPartsCodeList[userPrimeSettingUWork.TbsPartsCode.ToString("d8")] != null)
                            {
                                tbsPartsCodeWork = (TbsPartsCodeWork)_TbsPartsCodeList[userPrimeSettingUWork.TbsPartsCode.ToString("d8")];

                                // �i�ږ��ݒ�
                                primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = tbsPartsCodeWork.TbsPartsFullName;
                            }

                            primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] = userPrimeSettingUWork.TbsPartsCode;
                            primeSettingRow[PrimeSettingInfo.COL_SELECTNAME] = userPrimeSettingUWork.PrmSetDtlName1;
                            primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME] = userPrimeSettingUWork.PrmSetDtlName2;
                            // --- ADD 2008/07/01 --------------------------------<<<<< 
                        }
                    }

                    //defaultMakerDispOrderMng.SetDefaultMakerDispOrder();    // ADD 2008/12/05 �s��Ή�[8524] �d�l�ύX �\�������ݒ肳��Ă��Ȃ��ꍇ�A1�`�����ō̔�
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �񋟗D�ǐݒ胊�X�g�擾
        /// </summary>
        //private void getOfferPrimesettingList()  // DEL 2008/07/01
        private int getOfferPrimesettingList()     // ADD 2008/07/01
        {
            RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile, false);
            object objret = null;
            int status = -1;

            try
            {
                // �񋟗D�ǐݒ�擾
                status = offerPrimeSettingSearchDB.Search(out objret);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //foreach (OfferPrimeSettingWork wkPrimeSettingWork in (ArrayList)objret)  // DEL 2008/07/01
                    foreach (PrmSettingWork wkPrimeSettingWork in (ArrayList)objret)           // ADD 2008/07/01
                    //�D�ǐݒ茋�ʃN���X
                    {
                        // --- DEL 2008/11/27 -------------------------------->>>>>
                        #region �폜�R�[�h
                        //// UNDONE:���_�Ⴂ�͑ΏۂƂ��Ȃ�
                        //if (!ContainsGoodsMng(wkPrimeSettingWork.PartsMakerCd, wkPrimeSettingWork.TbsPartsCode))
                        //{
                        //    Debug.WriteLine("[���_�Ⴂ]���[�J�[�F" + wkPrimeSettingWork.PartsMakerCd.ToString() + ", BL�F" + wkPrimeSettingWork.TbsPartsCode.ToString());
                        //    continue;
                        //}
                        #endregion
                        // --- DEL 2008/11/27 --------------------------------<<<<<
                        DataRow primeSettingRow = PrimeSettingTable.NewRow();
                        PrimeSettingTable.Rows.Add(primeSettingRow);
                        //DataRow�Ɏ擾�������[�N���Z�b�g
                        {   // TODO:�y�񋟂ƃ��[�U�[����ʂ���J�����z
                            primeSettingRow[COL_OFFERPRIMESETTING] = wkPrimeSettingWork;
                            primeSettingRow[COL_USERPRIMESETTING] = null;
                            primeSettingRow[COL_CHANGEFLAG] = false;                // �񋟂͕ύX�s��
                            primeSettingRow[COL_CHECKSTATE] = CheckState.Unchecked; // �񋟂͖��`�F�b�N�i�f�t�H���g�j
                            primeSettingRow[COL_ORIGINAL_CHECKSTATE] = CheckState.Unchecked; // �񋟂͖��`�F�b�N�i�f�t�H���g�j
                        }
                        //�J�����Ƀf�[�^���Z�b�g
                        //�f�t�H���g�\�����ʂ̓��[�J�[�R�[�h��
                        primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] = 0;   // MOD 2009/01/14 �d�l�ύX wkPrimeSettingWork.PartsMakerCd;��0;

                        //�\���敪�͂O�Œ�(�񋟂̏ꍇ�j
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0;
                        primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = wkPrimeSettingWork.DisplayOrder;
                        //primedr[PrimeSettingInfo.COL_MIDDLEGENRECODE] = wkPrimeSettingWork.MiddleGenreCode;  // DEL 2008/07/01
                        primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] = wkPrimeSettingWork.GoodsMGroup;        // ADD 2008/07/01
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] = wkPrimeSettingWork.PartsMakerCd;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] = wkPrimeSettingWork.TbsPartsCode;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO] = wkPrimeSettingWork.TbsPartsCdDerivedNo;
                        /* --- DEL 2008/07/01 -------------------------------->>>>>
                        primedr[PrimeSettingInfo.COL_SELECTCODE] = wkPrimeSettingWork.SelectCode;
                        primedr[PrimeSettingInfo.COL_PRIMEKINDCODE] = wkPrimeSettingWork.PrimeKindCode;
                           --- DEL 2008/07/01 --------------------------------<<<<< */
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        primeSettingRow[PrimeSettingInfo.COL_SELECTCODE] = wkPrimeSettingWork.PrmSetDtlNo1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE] = wkPrimeSettingWork.PrmSetDtlNo2;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 
                        primeSettingRow[PrimeSettingInfo.COL_SECRETCODE] = wkPrimeSettingWork.SecretCode;

                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = "";
                        //Hash�Ƀ��[�J�[������Ζ��̎擾
                        if (_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")] != null)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = ((PMakerNmWork)_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")]).PartsMakerFullName;
                            primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = ((PMakerNmWork)_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")]).PartsMakerHalfName;
                        }
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSHALFNAME] = "";
                        //Hash��BL�R�[�h������Ζ��̎擾
                        if (_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")] != null)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = ((TbsPartsCodeWork)_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")]).TbsPartsFullName;
                            primeSettingRow[PrimeSettingInfo.COL_TBSPARTSHALFNAME] = ((TbsPartsCodeWork)_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")]).TbsPartsHalfName;
                        }

                        primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRENAME] = "";
                        //Hash�ɒ����ރR�[�h������Ζ��̎擾
                        //if (_MiddleGenreList[((Int32)wkPrimeSettingWork.MiddleGenreCode).ToString("d4")] != null)  // DEL 2008/07/01
                        if (_MiddleGenreList[((Int32)wkPrimeSettingWork.GoodsMGroup).ToString("d4")] != null)        // ADD 2008/07/01
                        {
                            //primedr[PrimeSettingInfo.COL_MIDDLEGENRENAME] = ((OfferMiddleGenreWork)_MiddleGenreList[((Int32)wkPrimeSettingWork.MiddleGenreCode).ToString("d4")]).MiddleGenreName;  // DEL 2008/07/01
                            primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRENAME] = ((GoodsMGroupWork)_MiddleGenreList[((Int32)wkPrimeSettingWork.GoodsMGroup).ToString("d4")]).GoodsMGroupName;             // ADD 2008/07/01
                        }

                        /* --- DEL 2008/07/01 -------------------------------->>>>>
                        primedr[PrimeSettingInfo.COL_SELECTNAME] = wkPrimeSettingWork.SelectName;
                        primedr[PrimeSettingInfo.COL_PRIMEKINDNAME] = wkPrimeSettingWork.PrimeKindName;
                           --- DEL 2008/07/01 --------------------------------<<<<< */
                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        primeSettingRow[PrimeSettingInfo.COL_SELECTNAME] = wkPrimeSettingWork.PrmSetDtlName1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME] = wkPrimeSettingWork.PrmSetDtlName2;
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // --- ADD 2008/07/01 -------------------------------->>>>>
                        F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();

                        keyGoodsMngList.blGoodsCode = wkPrimeSettingWork.TbsPartsCode;   // BL�R�[�h
                        keyGoodsMngList.goodsMakerCd = wkPrimeSettingWork.PartsMakerCd;  // ���i���[�J�[�R�[�h
                        keyGoodsMngList.goodsMGroup = wkPrimeSettingWork.GoodsMGroup;   // ADD 2009/01/26 �d�l�ύX�F���i�Ǘ����ɒ����ރR�[�h��ǉ�

                        // ���i�Ǘ���񃊃X�g�Ƀf�[�^����H
                        if (_GoodsMngList[keyGoodsMngList] != null)
                        {
                            // ���i�Ǘ����擾
                            GoodsMngWork paraGoodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                            // TODO:�d����R�[�h����H
                            if (paraGoodsMngWork.SupplierCd != 0)
                            {
                                // TODO:�d����R�[�h��PrimeSettingTable�ɐݒ�
                                primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] = paraGoodsMngWork.SupplierCd;

                                // �d�����񃊃X�g�Ƀf�[�^����H
                                if (_SupplierList[paraGoodsMngWork.SupplierCd] != null)
                                {
                                    // �d������擾
                                    Supplier supplier = (Supplier)_SupplierList[paraGoodsMngWork.SupplierCd];

                                    // �d���於�̐ݒ�
                                    primeSettingRow[PrimeSettingInfo.COL_SUPPLIERNAME] = supplier.SupplierNm1;
                                }
                            }
                        }
                        else
                        {
                            primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] = int.MinValue;    // UNDONE:���_�Ⴂ�͑ΏۂƂ��Ȃ�
                        }
                        // --- ADD 2008/07/01 --------------------------------<<<<< 

                        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
                        primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP] = wkPrimeSettingWork.PrmSetGroup;
                        if (!wkPrimeSettingWork.PrmSetGroup.Equals(0))
                        {
                            Debug.WriteLine("�D�ǐݒ�O���[�v�F" + ((int)primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP]).ToString() + " <- " + wkPrimeSettingWork.PrmSetGroup.ToString());
                            Debug.WriteLine("���F" + wkPrimeSettingWork.GoodsMGroup.ToString() + ", M�F" + wkPrimeSettingWork.PartsMakerCd.ToString() + ", B�F" + wkPrimeSettingWork.TbsPartsCode.ToString());
                        }
                        // FIXME:2009/01/15 �d�l�ύX ���֘ABL�R�[�h�p�R���N�V�����̍\�z�i���Ԃ�K�v�Ȃ��j
                        //RelatedBLCode.Add(primeSettingRow);
                        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<

                        //�L�[���쐬
                        string str = ((Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO]).ToString("d2")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]).ToString("d2");

                        //DataRow��HashTable�ɓo�^���Ă���
                        _PrimeSettingList.Add(str, primeSettingRow);

                        // Add 2009/01/14 �d�l�ύX���F�����ރR�[�h�̂�������\��
                        MakerList.Add(primeSettingRow);
                    }   // foreach (PrmSettingWork wkPrimeSettingWork in (ArrayList)objret)

                    // ADD 2009/01/26 �@�\�ǉ��F������+���[�J�[+BL�R�[�h=0�̃f�[�^��o�^ ---------->>>>>
                    #region <������+���[�J�[+0(BL)/>

                    foreach (PrmSettingWork offerPrimeSettingWork in (ArrayList)objret)
                    {
                        if (offerPrimeSettingWork.TbsPartsCode.Equals(0)) continue;

                        PrmSettingWork wkPrimeSettingWork = new PrmSettingWork();
                        {
                            wkPrimeSettingWork.GoodsMGroup = offerPrimeSettingWork.GoodsMGroup;     // �����ރR�[�h
                            wkPrimeSettingWork.TbsPartsCode = 0;                                    // BL�R�[�h
                            wkPrimeSettingWork.TbsPartsCdDerivedNo = 0;                             // BL�R�[�h�}��
                            wkPrimeSettingWork.PartsMakerCd = offerPrimeSettingWork.PartsMakerCd;   // ���i���[�J�[�R�[�h
                            wkPrimeSettingWork.DisplayOrder = 0;                                    // �\������
                            wkPrimeSettingWork.PrmSetDtlNo1 = 0;                                    // �D�ǐݒ�ڍ׃R�[�h1
                            wkPrimeSettingWork.PrmSetDtlName1 = string.Empty;                       // �D�ǐݒ�ڍז���1
                            wkPrimeSettingWork.PrmSetDtlNo2 = 0;                                    // �D�ǐݒ�ڍ׃R�[�h2
                            wkPrimeSettingWork.PrmSetDtlName2 = string.Empty;                       // �D�ǐݒ�ڍז���2
                            // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------>>>>>
                            wkPrimeSettingWork.SecretCode = offerPrimeSettingWork.SecretCode;       // �V�[�N���b�g�敪
                            // --- ADD 2009/02/19 ��QID:11684�Ή�------------------------------------------------------<<<<<
                        }

                        DataRow primeSettingRow = PrimeSettingTable.NewRow();
                        PrimeSettingTable.Rows.Add(primeSettingRow);
                        // DataRow�Ɏ擾�������[�N���Z�b�g
                        {   //�y�񋟂ƃ��[�U�[����ʂ���J�����z
                            primeSettingRow[COL_OFFERPRIMESETTING] = wkPrimeSettingWork;
                            primeSettingRow[COL_USERPRIMESETTING] = null;
                            primeSettingRow[COL_CHANGEFLAG] = false;                // �񋟂͕ύX�s��
                            primeSettingRow[COL_CHECKSTATE] = CheckState.Checked;   // TODO:�񋟂͖��`�F�b�N�i�f�t�H���g�j�H
                            primeSettingRow[COL_ORIGINAL_CHECKSTATE] = CheckState.Checked;   // TODO:�񋟂͖��`�F�b�N�i�f�t�H���g�j�H
                        }
                        // �J�����Ƀf�[�^���Z�b�g
                        // �f�t�H���g�\�����ʂ̓��[�J�[�R�[�h��
                        primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER] = 0;

                        // �\���敪�͂O�Œ�(�񋟂̏ꍇ�j
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 0;
                        primeSettingRow[PrimeSettingInfo.COL_DISPLAYORDER] = wkPrimeSettingWork.DisplayOrder;
                        primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE] = wkPrimeSettingWork.GoodsMGroup;
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD] = wkPrimeSettingWork.PartsMakerCd;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE] = wkPrimeSettingWork.TbsPartsCode;
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO] = wkPrimeSettingWork.TbsPartsCdDerivedNo;
                        primeSettingRow[PrimeSettingInfo.COL_SELECTCODE] = wkPrimeSettingWork.PrmSetDtlNo1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE] = wkPrimeSettingWork.PrmSetDtlNo2;
                        primeSettingRow[PrimeSettingInfo.COL_SECRETCODE] = wkPrimeSettingWork.SecretCode;
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = string.Empty;
                        primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = string.Empty;
                        // Hash�Ƀ��[�J�[������Ζ��̎擾
                        if (_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")] != null)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = ((PMakerNmWork)_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")]).PartsMakerFullName;
                            primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = ((PMakerNmWork)_PartsMakerList[((Int32)wkPrimeSettingWork.PartsMakerCd).ToString("d4")]).PartsMakerHalfName;
                        }
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = "";
                        primeSettingRow[PrimeSettingInfo.COL_TBSPARTSHALFNAME] = "";
                        // Hash��BL�R�[�h������Ζ��̎擾
                        if (_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")] != null)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = ((TbsPartsCodeWork)_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")]).TbsPartsFullName;
                            primeSettingRow[PrimeSettingInfo.COL_TBSPARTSHALFNAME] = ((TbsPartsCodeWork)_TbsPartsCodeList[((Int32)wkPrimeSettingWork.TbsPartsCode).ToString("d8")]).TbsPartsHalfName;
                        }

                        primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRENAME] = string.Empty;
                        // Hash�ɒ����ރR�[�h������Ζ��̎擾
                        if (_MiddleGenreList[((Int32)wkPrimeSettingWork.GoodsMGroup).ToString("d4")] != null)
                        {
                            primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRENAME] = ((GoodsMGroupWork)_MiddleGenreList[((Int32)wkPrimeSettingWork.GoodsMGroup).ToString("d4")]).GoodsMGroupName;
                        }

                        primeSettingRow[PrimeSettingInfo.COL_SELECTNAME] = wkPrimeSettingWork.PrmSetDtlName1;
                        primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDNAME] = wkPrimeSettingWork.PrmSetDtlName2;

                        F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();

                        keyGoodsMngList.blGoodsCode = wkPrimeSettingWork.TbsPartsCode;   // BL�R�[�h
                        keyGoodsMngList.goodsMakerCd = wkPrimeSettingWork.PartsMakerCd;  // ���i���[�J�[�R�[�h
                        keyGoodsMngList.goodsMGroup = wkPrimeSettingWork.GoodsMGroup;   // ADD 2009/01/26 �d�l�ύX�F���i�Ǘ����ɒ����ރR�[�h��ǉ�

                        // ���i�Ǘ���񃊃X�g�Ƀf�[�^����H
                        if (_GoodsMngList[keyGoodsMngList] != null)
                        {
                            // ���i�Ǘ����擾
                            GoodsMngWork paraGoodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                            // �d����R�[�h����H
                            if (paraGoodsMngWork.SupplierCd != 0)
                            {
                                // �d����R�[�h��PrimeSettingTable�ɐݒ�
                                primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] = paraGoodsMngWork.SupplierCd;

                                // �d�����񃊃X�g�Ƀf�[�^����H
                                if (_SupplierList[paraGoodsMngWork.SupplierCd] != null)
                                {
                                    // �d������擾
                                    Supplier supplier = (Supplier)_SupplierList[paraGoodsMngWork.SupplierCd];

                                    // �d���於�̐ݒ�
                                    primeSettingRow[PrimeSettingInfo.COL_SUPPLIERNAME] = supplier.SupplierNm1;
                                }
                            }
                        }
                        else
                        {
                            primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD] = int.MinValue;
                        }

                        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
                        primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP] = wkPrimeSettingWork.PrmSetGroup;
                        // FIXME:2009/01/15 �d�l�ύX ���֘ABL�R�[�h�p�R���N�V�����̍\�z�i���Ԃ�K�v�Ȃ��j
                        //RelatedBLCode.Add(primeSettingRow);
                        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<

                        //�L�[���쐬
                        string str = ((Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO]).ToString("d2")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_SELECTCODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]).ToString("d2");

                        // DataRow��HashTable�ɓo�^���Ă���
                        if (!_PrimeSettingList.ContainsKey(str))
                        {
                            _PrimeSettingList.Add(str, primeSettingRow);
                        }

                        // Add 2009/01/14 �d�l�ύX���F�����ރR�[�h�̂�������\��
                        MakerList.Add(primeSettingRow);
                    }   // foreach (PrmSettingWork offerPrimeSettingWork in (ArrayList)objret)

                    #endregion  // <������+���[�J�[+0(BL)/>
                    // ADD 2008/01/26 �@�\�ǉ��F������+���[�J�[+BL�R�[�h=0�̃f�[�^��o�^ ----------<<<<<
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                status = -1;
            }

            return status;
        }

        // ADD 2008/11/21 �s��Ή�[8176] �d�l�ύX �I���O���b�h��̔��l�\�� ---------->>>>>
        /// <summary>
        /// ���i�Ǘ����ɊY��������̂����邩���肵�܂��B
        /// </summary>
        /// <param name="goodsMGroup">�����ރR�[�h</param>
        /// <param name="goodsMakerCode">���i���[�J�[�R�[�h</param>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <returns>
        /// <c>true</c> :����<br/>
        /// <c>false</c>:�Ȃ�
        /// </returns>
        private bool ContainsGoodsMng(
            int goodsMGroup,
            int goodsMakerCode,
            int blGoodsCode
        )
        {
            F_KEY_GOODSMNGLIST keyGoodMngList = new F_KEY_GOODSMNGLIST();
            keyGoodMngList.goodsMGroup = goodsMGroup;   // ADD 2009/01/26 �d�l�ύX�F���i�Ǘ����ɒ����ރR�[�h��ǉ�
            keyGoodMngList.goodsMakerCd = goodsMakerCode;
            keyGoodMngList.blGoodsCode = blGoodsCode;
            return GoodsMng.Contains(keyGoodMngList);
        }

        /// <summary>
        /// ���i�Ǘ����n�b�V���e�[�u������ɊY�����鏤�i�Ǘ������擾���܂��B
        /// </summary>
        /// <param name="goodsMGroup">�����ރR�[�h</param>
        /// <param name="goodsMakerCode">���i���[�J�[�R�[�h</param>
        /// <param name="blGoodsCode">BL���i�R�[�h</param>
        /// <returns>���i�Ǘ����</returns>
        private GoodsMngWork GetGoodsMngWork(
            int goodsMGroup,
            int goodsMakerCode,
            int blGoodsCode
        )
        {
            F_KEY_GOODSMNGLIST keyGoodMngList = new F_KEY_GOODSMNGLIST();
            keyGoodMngList.goodsMGroup = goodsMGroup;   // ADD 2009/01/26 �d�l�ύX�F���i�Ǘ����ɒ����ރR�[�h��ǉ�
            keyGoodMngList.goodsMakerCd = goodsMakerCode;
            keyGoodMngList.blGoodsCode = blGoodsCode;
            return GoodsMng[keyGoodMngList] as GoodsMngWork;
        }
        // ADD 2008/11/21 �s��Ή�[8176] �d�l�ύX �I���O���b�h��̔��l�\�� ----------<<<<<

        /// <summary>
        /// �D�ǐݒ���l���X�g�擾
        /// </summary>
        //private void getOfferPrimeSettingNoteList()  // DEL 2008/07/01
        private int getOfferPrimeSettingNoteList()     // ADD 2008/07/01
        {
            object objret = null;
            int status = -1;  // ADD 2008/07/01

            try
            {
                // �D�ǐݒ���l�擾
                status = offerPrimeSettingSearchDB.SearchNote(out objret);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    //foreach (OfferPrimeSettingNoteWork wkOfferPrimeSettingNote in (ArrayList)objret)
                    foreach (PrmSetNoteWork wkOfferPrimeSettingNote in (ArrayList)objret)
                    //BL���i�R�[�h���ʃN���X
                    {
                        //�L�[���쐬
                        //string str = (wkOfferPrimeSettingNote.MiddleGenreCode.ToString("d4")  // DEL 2008/07/01
                        string str = (wkOfferPrimeSettingNote.GoodsMGroup.ToString("d4")        // ADD 2008/07/01
                                    + wkOfferPrimeSettingNote.TbsPartsCode.ToString("d8")
                                    + wkOfferPrimeSettingNote.PartsMakerCd.ToString("d4"));

                        //DataRow��HashTable�ɓo�^���Ă���
                        _PrimeSettingNoteList.Add(str, wkOfferPrimeSettingNote);
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return status;
        }

        /// <summary>
        /// �e�[�u���쐬
        /// </summary>
        private DataTable CreateTable(string TableName)
        {
            DataTable table = new DataTable(TableName);

            // TODO:�e�e�[�u���̍\��
            if (TableName == PrimeSettingInfo.TABLENAME_PRIMESETTING)
            {
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERCD, typeof(int), "���[�J�[�R�[�h"));	//���[�J�[�R�[�h
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERFULLNAME, typeof(string), "���[�J�["));	//�S�p���[�J�[��
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERHALFNAME, typeof(string), "Ұ��"));	//���p���[�J�[��
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCODE, typeof(int), "BL����"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCDDERIVEDNO, typeof(int), "BL�R�[�h�}��"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSFULLNAME, typeof(string), "�i�ږ�"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSHALFNAME, typeof(string), "�i�ږ�(���p)"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRECODE, typeof(int), "������"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRENAME, typeof(string), "�����ޖ�"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SECRETCODE, typeof(int), "�V�[�N���b�g�R�[�h"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTCODE, typeof(int), "�Z���N�g�R�[�h"));
                //table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTNAME, typeof(string), "�Z���N�g����"));     // DEL 2008/07/01
                // MOD 2008/10/30 �s��Ή�[6961]�� �d�l�ύX "�ڍׂP"��"�Z���N�g"
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTNAME, typeof(string), "�Z���N�g"));           // ADD 2008/07/01
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDCODE, typeof(int), "�D�ǎ�ʃR�[�h"));
                //table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDNAME, typeof(string), "�D�ǎ�ʖ���"));  // DEL 2008/07/01
                // MOD 2008/10/30 �s��Ή�[6961]�� �d�l�ύX "�ڍׂQ"��"���"
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDNAME, typeof(string), "���"));            // ADD 2008/07/01 
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERCD, typeof(int), "�d����R�[�h"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERCDDERIVEDNO, typeof(int), "�d����R�[�h�}��"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERNAME, typeof(string), "�d���於��"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MAKERDISPORDER, typeof(int), "�\������"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_DISPLAYORDER, typeof(int), "�\����"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEDISPLAYCODE, typeof(int), ""));	//�\���敪

                table.Columns.Add(CreateColumn(COL_CHANGEFLAG, typeof(bool), ""));	//�ύX�t���O
                table.Columns.Add(CreateColumn(COL_CHECKSTATE, typeof(CheckState), ""));	//�`�F�b�N
                table.Columns.Add(CreateColumn(COL_ORIGINAL_CHECKSTATE, typeof(CheckState), ""));	//�`�F�b�N
                table.Columns.Add(CreateColumn(COL_OFFERPRIMESETTING, typeof(object), ""));	//�񋟗D�ǐݒ�N���X
                table.Columns.Add(CreateColumn(COL_USERPRIMESETTING, typeof(object), ""));	//���[�U�[�D�ǐݒ�N���X

                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRMSETGROUP, typeof(int), "�D�ǐݒ�O���[�v")); // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\��
            }
            else if (TableName == PrimeSettingInfo.TABLENAME_USER_PRIMESETTING)
            {
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERFULLNAME, typeof(string), "���[�J�["));	//�S�p���[�J�[��
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCODE, typeof(int), "BL����"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSFULLNAME, typeof(string), "�i�ږ�"));

                // --- DEL 2008/07/01 -------------------------------->>>>>
                //table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTNAME, typeof(string), "�Z���N�g����"));
                //table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDNAME, typeof(string), "�D�ǎ�ʖ���"));
                // --- DEL 2008/07/01 --------------------------------<<<<< 

                // --- ADD 2008/07/01 -------------------------------->>>>>
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SELECTNAME, typeof(string), "�ڍׂP"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEKINDNAME, typeof(string), "�ڍׂQ"));
                // --- ADD 2008/07/01 --------------------------------<<<<< 
            }
            else if (TableName == MG_BL_MK_TABLENAME)   // MEMO:������/BL/���[�J�[�̃J������
            {
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRECODE, typeof(int), "�����ރR�[�h"));	  //�����ރR�[�h
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MIDDLEGENRENAME, typeof(string), "�����ޖ�"));	  //�����ޖ�
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSCODE, typeof(int), "BL�R�[�h"));	      //BL�R�[�h

                // BL���i��
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_TBSPARTSFULLNAME, typeof(string), "�i�ږ�"));   // MOD 2008/10/28 �s��Ή�[6967] "BL��"��"�i�ږ�"

                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERCD, typeof(int), "���[�J�[�R�[�h"));	  //���[�J�[�R�[�h
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERHALFNAME, typeof(string), "Ұ��"));	  //���p���[�J�[��
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PARTSMAKERFULLNAME, typeof(string), "���[�J�[")); //�S�p���[�J�[��
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_MAKERDISPORDER, typeof(int), "�\����"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SECRETCODE, typeof(int), "�V�[�N���b�g�R�[�h"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRIMEDISPLAYCODE, typeof(int), ""));	          //�\���敪
                table.Columns.Add(CreateColumn(COL_CHECKSTATE, typeof(CheckState), ""));	                          //�`�F�b�N�{�b�N�X�X�e�[�^�X
                table.Columns.Add(CreateColumn(COL_ORIGINAL_CHECKSTATE, typeof(CheckState), ""));	                          //�`�F�b�N�{�b�N�X�X�e�[�^�X
                table.Columns.Add(CreateColumn(COL_MG_BL_MKDATAROW, typeof(object), ""));	                          //�m�[�h

                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_IMPORTANTCODE, typeof(int), ""));	//�d�v�敪(-1�͔��l�����j

                // --- ADD 2008/07/01 -------------------------------->>>>>
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERGUIDE, typeof(Button), ""));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERCD, typeof(int), "�d����R�[�h"));
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_SUPPLIERNAME, typeof(String), "�d����"));
                // --- ADD 2008/07/01 --------------------------------<<<<<

                // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
                table.Columns.Add(CreateColumn(PrimeSettingInfo.COL_PRMSETGROUP, typeof(int), "�D�ǐݒ�O���[�v"));
                table.Columns.Add(CreateColumn(COL_RELATEDBLCODE, typeof(string), "�֘ABL�R�[�h"));
                table.Columns.Add(CreateColumn(COL_GRIDSORTORDER, typeof(int), "�O���b�h�p�\�[�g��"));
                table.Columns.Add(CreateColumn(COL_USER_MAKERDISPORDER, typeof(int), "���[�U�[���ݒ肵���\����"));
                table.Columns.Add(CreateColumn(COL_USER_STATUS, typeof(int), "���[�U�[�o�^���̏��"));
                // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<
            }

            return table;
        }
        
        /// <summary>
        /// �f�[�^�e�[�u���̗���쐬����
        /// </summary>
        /// <param name="columnName">��</param>
        /// <param name="type">�^</param>
        /// <param name="caption">�L���v�V����</param>
        /// <returns></returns>
        private DataColumn CreateColumn(string columnName, Type type, string caption)
        {
            DataColumn dc = new DataColumn();

            dc.ColumnName = columnName;
            dc.DataType = type;
            dc.Caption = caption;

            return dc;
        }
        
        // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX ---------->>>>>
        /// <summary>
        /// ������/�i��/���[�J�[���f�[�^�e�[�u�������������܂��B
        /// </summary>
        private void InitializeMiddleGBLMakerDataTable()
        {
            Mg_Bl_MkTable.Clear();

            // �d����R�[�h�̈ꊇ�ݒ�p�̋��ʃ��R�[�h��ǉ�
            DataRow commonDataRow = Mg_Bl_MkTable.NewRow();

            commonDataRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]     = -1;                   // TODO:���ʐݒ�F�����ރR�[�h
            commonDataRow[PrimeSettingInfo.COL_MIDDLEGENRENAME]     = "����";               // �����ޖ�
            commonDataRow[PrimeSettingInfo.COL_TBSPARTSCODE]        = 0;	                // BL�R�[�h
            commonDataRow[PrimeSettingInfo.COL_TBSPARTSFULLNAME]    = "����";               // BL���i��
            commonDataRow[PrimeSettingInfo.COL_PARTSMAKERCD]        = COMMON_MAKER_CODE;    // TODO:���ʐݒ�F���[�J�[�R�[�h
            commonDataRow[PrimeSettingInfo.COL_PARTSMAKERHALFNAME]  = "����";               // ���p���[�J�[��
            commonDataRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME]  = "����";               // �S�p���[�J�[��
            commonDataRow[PrimeSettingInfo.COL_MAKERDISPORDER]      = 0;                    // �\����
            commonDataRow[PrimeSettingInfo.COL_SECRETCODE]          = 0;                    // �V�[�N���b�g�R�[�h
            commonDataRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE]    = 0;                    // �\���敪
            commonDataRow[COL_CHECKSTATE] = CheckState.Checked;   // �`�F�b�N�{�b�N�X�X�e�[�^�X
            commonDataRow[COL_ORIGINAL_CHECKSTATE] = CheckState.Checked;   // �`�F�b�N�{�b�N�X�X�e�[�^�X
            commonDataRow[COL_MG_BL_MKDATAROW]                      = null;	                // �m�[�h
            commonDataRow[PrimeSettingInfo.COL_IMPORTANTCODE]       = -1;	                // �d�v�敪(-1�͔��l�����j

            #region �d����͓��ɉ����ݒ肵�Ȃ�

            //commonDataRow[PrimeSettingInfo.COL_SUPPLIERGUIDE]       = null;                 // �d����R�[�h
            //commonDataRow[PrimeSettingInfo.COL_SUPPLIERCD]          = 0;                    // �d����K�C�h�{�^��
            //commonDataRow[PrimeSettingInfo.COL_SUPPLIERNAME]        = string.Empty;         // �d���於

            #endregion

            Mg_Bl_MkTable.Rows.Add(commonDataRow);
        }

        /// <summary>
        /// ������/�i��/���[�J�[���f�[�^�e�[�u���̈ꊇ�ݒ�p���ʃ��R�[�h�ł��邩���肵�܂��B
        /// </summary>
        /// <param name="dataRowView">���R�[�h</param>
        /// <returns>
        /// <c>true</c> :�ꊇ�ݒ�p���ʃ��R�[�h�ł���B<br/>
        /// <c>false</c>:�ꊇ�ݒ�p���ʃ��R�[�h�ł͂Ȃ��B
        /// </returns>
        public static bool IsCommonRowOfMiddleGBLMakerDataTable(DataRowView dataRowView)
        {
            return IsCommonRowOfMiddleGBLMakerDataTableByMakerCode((int)dataRowView[PrimeSettingInfo.COL_PARTSMAKERCD]);
        }

        /// <summary>
        /// ������/�i��/���[�J�[���f�[�^�e�[�u���̈ꊇ�ݒ�p���ʃ��R�[�h�ł��邩���肵�܂��B
        /// </summary>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <returns>
        /// <c>true</c> :�ꊇ�ݒ�p���ʃ��R�[�h�ł���B<br/>
        /// <c>false</c>:�ꊇ�ݒ�p���ʃ��R�[�h�ł͂Ȃ��B
        /// </returns>
        public static bool IsCommonRowOfMiddleGBLMakerDataTableByMakerCode(int makerCode)
        {
            return makerCode.Equals(COMMON_MAKER_CODE);
        }
        // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX ----------<<<<<

        /// <summary>
        /// ������/�i��/���[�J�[��
        /// </summary>
        /// <param name="displaycode"></param>
        //private void getMG_BL_MKCdList()  // DEL 2008/07/01
        private int getMG_BL_MKCdList()     // ADD 2008/07/01
        {
            string rowfilter = PrimeSettingView.RowFilter;
            PrimeSettingView.RowFilter = "";
            string sort = PrimeSettingView.Sort;
            int wkMK = -1;
            int wkBL = -1;
            int prmSetDtlNo = -1;
            DataRow priorRow = null;
            CheckState cs = CheckState.Unchecked;
            Hashtable hashTable = new Hashtable();
            int status = 0;  // ADD 2008/07/01

            // TODO:������/BL/���[�J�[ �f�[�^�e�[�u����������
            InitializeMiddleGBLMakerDataTable();    // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX

            try
            {
                // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                //PrimeSettingView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD);
                PrimeSettingView.Sort = (PrimeSettingInfo.COL_MIDDLEGENRECODE + "," + PrimeSettingInfo.COL_PARTSMAKERCD + "," + PrimeSettingInfo.COL_TBSPARTSCODE + "," + PrimeSettingInfo.COL_SECRETCODE + "," + PrimeSettingInfo.COL_PRIMEKINDCODE);
                // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

                foreach (DataRowView primeSettingRow in PrimeSettingView)
                {
                    //if (wkBL == -1) { wkBL = (int)primedrv[PrimeSettingInfo.COL_TBSPARTSCODE]; }
                    //if (wkMK == -1) { wkMK = (int)primedrv[PrimeSettingInfo.COL_PARTSMAKERCD]; }

                    //BL�R�[�h�i�܂��̓��[�J�[�R�[�h�j���ς������e�[�u���ɒǉ�
                    if ((wkBL != (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]) || (wkMK != (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]))
                    {
                        cs = CheckState.Unchecked; // 2009.05.25

                        if ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)    // �񋟕��̃f�t�H���g��0
                        {
                            cs = CheckState.Checked;
                        }
                        //else
                        //{
                        //    primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
                        //    primeSettingRow[COL_CHANGEFLAG] = true;
                        //}

                        // FIXME:BL�R�[�h=0�̃��R�[�h�����[�U�[�o�^���ɂ���ꍇ�A�`�F�b�N�i��D�Ǖ\���敪��0:��\���Œ�j
                        //if (((int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).Equals(0) && primeSettingRow[COL_USERPRIMESETTING] != DBNull.Value)
                        //{
                        //    cs = CheckState.Checked;
                        //}

                        // mgbldr[COL_PRIMEDISPLAYCODE] = displaycode;
                        DataRow mgbldr = _dataSet.Tables[MG_BL_MK_TABLENAME].NewRow();
                        mgbldr[COL_CHECKSTATE] = cs;
                        mgbldr[COL_ORIGINAL_CHECKSTATE] = cs;
                        _dataSet.Tables[MG_BL_MK_TABLENAME].Rows.Add(setMG_BL_MKrow(primeSettingRow, mgbldr));

                        wkBL = (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
                        wkMK = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                        prmSetDtlNo = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];

                        //�L�[���쐬
                        string str = ((Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_SECRETCODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]).ToString("d4")
                                    ;
                        _Mg_Bl_Mk_List.Add(str, mgbldr);
                        // if ((int)primedrv[COL_PARTSMAKERCD] == 1002) MessageBox.Show("");

                        // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                        ////�`�F�b�N��Ԃ����Z�b�g
                        //cs = CheckState.Unchecked;
                        // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                        //�o���Ă���
                        priorRow = mgbldr;
                    }
                    else
                    {
                        if (prmSetDtlNo != (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE])
                        {
                            if ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)    // �񋟕��̃f�t�H���g��0
                            {
                                cs = CheckState.Checked;
                            }
                            //else
                            //{
                            //    primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = 1;
                            //    primeSettingRow[COL_CHANGEFLAG] = true;
                            //}

                            DataRow mgbldr = _dataSet.Tables[MG_BL_MK_TABLENAME].NewRow();
                            mgbldr[COL_CHECKSTATE] = cs;
                            mgbldr[COL_ORIGINAL_CHECKSTATE] = cs;
                            _dataSet.Tables[MG_BL_MK_TABLENAME].Rows.Add(setMG_BL_MKrow(primeSettingRow, mgbldr));

                            wkBL = (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE];
                            wkMK = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];
                            prmSetDtlNo = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE];
                            //�L�[���쐬
                            string str = ((Int32)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]).ToString("d8")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_SECRETCODE]).ToString("d4")
                                    + ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]).ToString("d4")
                                    ;

                            if (!_Mg_Bl_Mk_List.ContainsKey(str))
                            {
                                _Mg_Bl_Mk_List.Add(str, mgbldr);
                                // 2009.05.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
                                ////�`�F�b�N��Ԃ����Z�b�g
                                //cs = CheckState.Unchecked;
                                // 2009.05.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                //�o���Ă���
                                priorRow = mgbldr;
                            }
                        }
                        else
                        {
                            if ((Int32)primeSettingRow[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] != 0)
                            {
                                //�o���Ă�����Row�ɍX�V
                                priorRow[COL_CHECKSTATE] = CheckState.Checked;
                                priorRow[COL_ORIGINAL_CHECKSTATE] = CheckState.Checked;
                                priorRow[PrimeSettingInfo.COL_SECRETCODE] = 0;
                                // 2010/03/02 Add >>>
                                priorRow[PrimeSettingInfo.COL_MAKERDISPORDER] = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
                                priorRow[COL_USER_MAKERDISPORDER] = (Int32)primeSettingRow[PrimeSettingInfo.COL_MAKERDISPORDER];
                                // 2010/03/02 Add <<<
                            }
                        }
                    }

                    if (wkBL == -1) { wkBL = (int)primeSettingRow[PrimeSettingInfo.COL_TBSPARTSCODE]; }
                    if (wkMK == -1) { wkMK = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD]; }
                    if (prmSetDtlNo == -1) { prmSetDtlNo = (int)primeSettingRow[PrimeSettingInfo.COL_PRIMEKINDCODE]; }
                }
                PrimeSettingView.RowFilter = rowfilter;
                PrimeSettingView.Sort = sort;

                this._originalPrimeSettingTable = PrimeSettingTable.Copy();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.ToString());
                status = -1;
            }

            return status;
        }

        public void Copy()
        {
            foreach (DataRowView primeSettingRow in PrimeSettingView)
            {
                primeSettingRow[COL_ORIGINAL_CHECKSTATE] = primeSettingRow[COL_CHECKSTATE];
            }
        }

        /// <summary>
        /// �w��̍s�Ƀf�[�^���Z�b�g
        /// </summary>
        /// <returns>�Z�b�g��̃f�[�^�s</returns>
        private DataRow setMG_BL_MKrow(DataRowView sourcedr, DataRow dr)
        {
            if (IsCommonRowOfMiddleGBLMakerDataTable(sourcedr)) Debug.Assert(false, "���ʐݒ背�R�[�h�������������ȊO�Œǉ�");

            dr[PrimeSettingInfo.COL_MIDDLEGENRECODE] = sourcedr[PrimeSettingInfo.COL_MIDDLEGENRECODE];//key
            dr[PrimeSettingInfo.COL_TBSPARTSCODE] = sourcedr[PrimeSettingInfo.COL_TBSPARTSCODE];//key
            dr[PrimeSettingInfo.COL_PARTSMAKERCD] = sourcedr[PrimeSettingInfo.COL_PARTSMAKERCD];//key
            dr[PrimeSettingInfo.COL_MIDDLEGENRENAME] = sourcedr[PrimeSettingInfo.COL_MIDDLEGENRENAME];
            dr[PrimeSettingInfo.COL_TBSPARTSFULLNAME] = sourcedr[PrimeSettingInfo.COL_TBSPARTSFULLNAME];
            dr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME] = sourcedr[PrimeSettingInfo.COL_PARTSMAKERFULLNAME];
            dr[PrimeSettingInfo.COL_PARTSMAKERHALFNAME] = sourcedr[PrimeSettingInfo.COL_PARTSMAKERHALFNAME];
            //�f�[�^�̃V�[�N���b�g�敪���Z�b�g
            dr[PrimeSettingInfo.COL_SECRETCODE] = sourcedr[PrimeSettingInfo.COL_SECRETCODE];
            //�`�F�b�N�n�m�̃f�[�^�̓V�[�N���b�g���O��
            if (dr[COL_CHECKSTATE] == (object)CheckState.Checked)
                dr[PrimeSettingInfo.COL_SECRETCODE] = 0;

            dr[PrimeSettingInfo.COL_MAKERDISPORDER] = sourcedr[PrimeSettingInfo.COL_MAKERDISPORDER];
            dr[PrimeSettingInfo.COL_PRIMEDISPLAYCODE] = sourcedr[PrimeSettingInfo.COL_PRIMEDISPLAYCODE];
            //dr[COL_TREENODE] = null;
            dr[COL_MG_BL_MKDATAROW] = (object)dr;
            dr[PrimeSettingInfo.COL_IMPORTANTCODE] = -1;

            // --- ADD 2008/07/01 -------------------------------->>>>>
            F_KEY_GOODSMNGLIST keyGoodsMngList = new F_KEY_GOODSMNGLIST();

            keyGoodsMngList.blGoodsCode = (int)sourcedr[PrimeSettingInfo.COL_TBSPARTSCODE];   // BL�R�[�h
            keyGoodsMngList.goodsMakerCd = (int)sourcedr[PrimeSettingInfo.COL_PARTSMAKERCD];  // ���i���[�J�[�R�[�h
            keyGoodsMngList.goodsMGroup = (int)sourcedr[PrimeSettingInfo.COL_MIDDLEGENRECODE];// ADD 2009/01/26 �d�l�ύX�F���i�Ǘ����ɒ����ރR�[�h��ǉ�

            // ���i�Ǘ���񃊃X�g�Ƀf�[�^����H
            if (_GoodsMngList[keyGoodsMngList] != null)
            {
                // ���i�Ǘ����擾
                GoodsMngWork paraGoodsMngWork = (GoodsMngWork)_GoodsMngList[keyGoodsMngList];

                // TODO:�d����R�[�h����H
                if (paraGoodsMngWork.SupplierCd != 0)
                {
                    // �d����R�[�h�ݒ�
                    dr[PrimeSettingInfo.COL_SUPPLIERCD] = paraGoodsMngWork.SupplierCd;

                    // �d�����񃊃X�g�Ƀf�[�^����H
                    if (_SupplierList[paraGoodsMngWork.SupplierCd] != null)
                    {
                        // �d������擾
                        Supplier supplier = (Supplier)_SupplierList[paraGoodsMngWork.SupplierCd];

                        // �d���於�̐ݒ�
                        dr[PrimeSettingInfo.COL_SUPPLIERNAME] = supplier.SupplierNm1;
                    }
                }
             }
             // --- ADD 2008/07/01 --------------------------------<<<<< 

            // ADD 2009/01/14 �d�l�ύX�F�����ނ̂�������\������ ---------->>>>>
            // �d����R�[�h�̃f�t�H���g�ݒ�
            int supplierCode = 0;
            try
            {
                supplierCode = (int)dr[PrimeSettingInfo.COL_SUPPLIERCD];
            }
            catch (InvalidCastException)  // DBNull�̏ꍇ
            {
                supplierCode = 0;
            }
            if (supplierCode.Equals(0))
            {
                // ������+���[�J�[�Ŏd����R�[�h��1�̏ꍇ�A������f�t�H���g�l�Ƃ���
                CodeNamePair<int> supplierPair = MakerList.FindSupplierCodeName(
                    (int)dr[PrimeSettingInfo.COL_MIDDLEGENRECODE],  // �����ރR�[�h
                    (int)dr[PrimeSettingInfo.COL_PARTSMAKERCD]      // ���[�J�[�R�[�h
                );
                if (supplierPair.Code > 0)
                {
                    dr[PrimeSettingInfo.COL_SUPPLIERCD]     = supplierPair.Code;
                    dr[PrimeSettingInfo.COL_SUPPLIERNAME]   = supplierPair.Name;
                }
            }
            // ADD 2009/01/14 �d�l�ύX�F�����ނ̂�������\������ ----------<<<<<
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
            // �D�ǐݒ�O���[�v
            dr[PrimeSettingInfo.COL_PRMSETGROUP] = sourcedr[PrimeSettingInfo.COL_PRMSETGROUP];

            // �֘ABL�R�[�h
            int blCode = (int)sourcedr[PrimeSettingInfo.COL_TBSPARTSCODE];
            dr[COL_RELATEDBLCODE] = GetRelatedBLCodeName(blCode);

            // �O���b�h�p�\�[�g��
            dr[COL_GRIDSORTORDER] = int.MaxValue;

            // ���[�U�[�o�^���̕\����
            dr[COL_USER_MAKERDISPORDER] = (int)sourcedr[PrimeSettingInfo.COL_MAKERDISPORDER];
            // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<

            // ���[�U�[�o�^���̏��
            dr[COL_USER_STATUS] = (int)UserStatus.None;

            return dr;
        }

        # endregion

        # region Const

        private const string SECRETFILTER = "SecretCode=0";
        public const string MG_BL_MK_TABLENAME = "Mg_Bl_Mk_Table";
        //public const string PRIMESETTING_TABLENAME = "PrimeSetting_Table";
        //public const string OFFER_PRIMESETTING_TABLENAME = "Offer_PrimeSetting_Table";
        //public const string USER_PRIMESETTING_TABLENAME = "User_PrimeSetting_Table";

        # region Const�F���ʃw�b�_
        /// <summary>�쐬����</summary>
        public const string COL_FILEHEADER_CREATEDATETIME = "CreateDateTime";
        /// <summary>�X�V����</summary>
        public const string COL_FILEHEADER_UPDATEDATETIME = "UpdateDateTime";
        /// <summary>��ƃR�[�h</summary>
        public const string COL_FILEHEADER_ENTERPRISECODE = "EnterpriseCode";
        /// <summary>GUID</summary>
        public const string COL_FILEHEADER_FILEHEADERGUID = "FileHeaderGuid";
        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        public const string COL_FILEHEADER_UPDEMPLOYEECODE = "UpdEmployeeCode";
        /// <summary>�X�V�A�Z���u��ID1</summary>
        public const string COL_FILEHEADER_UPDASSEMBLYID1 = "UpdAssemblyId1";
        /// <summary>�X�V�A�Z���u��ID2</summary>
        public const string COL_FILEHEADER_UPDASSEMBLYID2 = "UpdAssemblyId2";
        /// <summary>�_���폜�敪</summary>
        public const string COL_FILEHEADER_LOGICALDELETECODE = "LogicalDeleteCode";
        # endregion

        /// <summary>�`�F�b�N�{�b�N�X�X�e�[�^�X </summary>
        public const string COL_CHECKSTATE = "CheckState";
        /// <summary>�ύX�t���O </summary>
        public const string COL_CHANGEFLAG = "ChangeFlag";
        /// <summary>�`�F�b�N�{�b�N�X�X�e�[�^�X </summary>
        public const string COL_ORIGINAL_CHECKSTATE = "Original_CheckState";

        /// <summary>�񋟗D�ǐݒ�N���X </summary>
        public const string COL_OFFERPRIMESETTING = "OfferPrimeSetting";
        /// <summary>հ�ް�D�ǐݒ�N���X </summary>
        public const string COL_USERPRIMESETTING = "UserPrimeSetting";
        /// <summary>������/�i��/���[�J�[���X�g </summary>
        public const string COL_MG_BL_MKDATAROW = "Mg_Bl_Mk_DataRow";
        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
        /// <summary>�֘ABL�R�[�h</summary>
        public const string COL_RELATEDBLCODE = "RelatedBLCode";
        /// <summary>�O���b�h�p�\�[�g��</summary>
        public const string COL_GRIDSORTORDER = "GridSortOrder";
        /// <summary>���[�U�[���ݒ肵���\����</summary>
        public const string COL_USER_MAKERDISPORDER = "UserMakerDispOrder";
        /// <summary>���[�U�[�o�^���̏��</summary>
        public const string COL_USER_STATUS = "UserStatus";
        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<

        #region �폜�R�[�h
        /*
        /// <summary>�����ރR�[�h </summary>
        public const string COL_MIDDLEGENRECODE = "MiddleGenreCode";
        /// <summary>���[�J�[�R�[�h </summary>
        public const string COL_PARTSMAKERCD = "PartsMakerCd";
        /// <summary>BL�R�[�h </summary>
        public const string COL_TBSPARTSCODE = "TbsPartsCode";
        /// <summary>BL�R�[�h�}��</summary>
        public const string COL_TBSPARTSCDDERIVEDNO = "TbsPartsCdDerivedNo";

        /// <summary>�����ޖ��� </summary>
        public const string COL_MIDDLEGENRENAME = "MiddleGenreName";
        /// <summary>���[�J�[����(�S�p) </summary>
        public const string COL_PARTSMAKERFULLNAME = "PartsMakerFullName";
        /// <summary>���[�J�[����(���p) </summary>
        public const string COL_PARTSMAKERHALFNAME = "PartsMakerHalfName";
        /// <summary>BL���i���� </summary>
        public const string COL_TBSPARTSFULLNAME = "TbsPartsFullName";
        /// <summary>BL���i����(���p)</summary>
        public const string COL_TBSPARTSHALFNAME = "TbsPartsHalfName";
		/// <summary>�V�[�N���b�g�敪</summary>
		/// <remarks>0:�ʏ�@1:�V�[�N���b�g</remarks>
		public const string COL_SECRETCODE =  "SecretCode";
		/// <summary>�\������</summary>
		public const string COL_DISPLAYORDER =  "DisplayOrder";
		/// <summary>���[�J�[�\������</summary>
        public const string COL_MAKERDISPORDER = "MakerDisplayOrder";
		/// <summary>�Z���N�g�R�[�h</summary>
		public const string COL_SELECTCODE =  "SelectCode";
		/// <summary>�Z���N�g����</summary>
		public const string COL_SELECTNAME =  "SelectName";
		/// <summary>�D�ǎ�ʃR�[�h</summary>
		public const string COL_PRIMEKINDCODE =  "PrimeKindCode";
		/// <summary>�D�ǎ�ʖ���</summary>
		public const string COL_PRIMEKINDNAME =  "PrimeKindName";
        /// <summary>�d����R�[�h</summary>
        public const string COL_SUPPLIERCD = "SupplierCd";
        /// <summary>�d����R�[�h</summary>
        public const string COL_SUPPLIERNAME = "SupplierName";
        /// <summary>�d����R�[�h�}��</summary>
        public const string COL_SUPPLIERCDDERIVEDNO = "SupplierCdDerivedNo";
        /// <summary>�\���敪</summary>
        /// <remarks>0:�����@1:���i&�����@2:���i</remarks>
        public const string COL_PRIMEDISPLAYCODE = "PrimeDisplayCode";
        /// <summary>�c���[�m�[�h </summary>
      �@//  public const string COL_TREENODE = "TreeNode";
        /// <summary>�`�F�b�N�{�b�N�X�X�e�[�^�X </summary>
        public const string COL_CHECKSTATE = "CheckState";
        /// <summary>�񋟗D�ǐݒ�N���X </summary>
        public const string COL_OFFERPRIMESETTING = "OfferPrimeSetting";
        /// <summary>հ�ް�D�ǐݒ�N���X </summary>
        public const string COL_USERPRIMESETTING = "UserPrimeSetting";
        /// <summary>������/�i��/���[�J�[���X�g </summary>
        public const string COL_MG_BL_MKDATAROW = "Mg_Bl_Mk_DataRow";
        /// <summary>�ύX�t���O </summary>
        public const string COL_CHANGEFLAG = "ChangeFlag";

        /// <summary>�d�v�敪 </summary>
        public const string COL_IMPORTANTCODE = "ImportantCode";
        /// <summary>�D�ǐݒ���l </summary>
        public const string COL_PRIMESETTINGNOTE = "PrimeSettingNote";
        */
        #endregion  // �폜�R�[�h

        /// <summary>���ʐݒ�ƂȂ郁�[�J�[�R�[�h</summary>
        public const int COMMON_MAKER_CODE = 0; // ADD 2008/10/29 �s��Ή�[6969] �d�l�ύX

        /// <summary>
        /// ���[�U�[�o�^���̏�Ԃ̗񋓑�
        /// </summary>
        public enum UserStatus : int
        {
            /// <summary>�Ȃ�</summary>
            None,
            /// <summary>�\���Ώ�</summary>
            ViewingRecord,
            /// <summary>�폜�Ώ�</summary>
            DeletingRecord
        }

        # endregion

        // ADD 2008/12/05 �s��Ή�[8524] �d�l�ύX �\�������ݒ肳��Ă��Ȃ��ꍇ�A1�`�����ō̔� ---------->>>>>
        #region �f�t�H���g�\����

        /// <summary>
        /// �f�t�H���g�\�����̊Ǘ��҃N���X
        /// </summary>
        private sealed class DefaultMakerDispOrderManagaer
        {
            #region <�D�ǐݒ�DataRow/>

            /// <summary>�D�ǐݒ�DataRow�̃}�b�v</summary>
            private readonly IDictionary<string, IList<DataRow>> _primeSettingDataRowMap = new Dictionary<string, IList<DataRow>>();
            /// <summary>
            /// �D�ǐݒ�DataRow�̃}�b�v���擾���܂��B
            /// </summary>
            /// <value>�D�ǐݒ�DataRow�̃}�b�v</value>
            private IDictionary<string, IList<DataRow>> PrimeSettingDataRowMap { get { return _primeSettingDataRowMap; } }

            #endregion  // <<�D�ǐݒ�DataRow/>

            #region <�\��ςݕ\����/>

            /// <summary>�\��ςݕ\�����̃}�b�v</summary>
            private readonly IDictionary<string, IList<int>> _reservedMakerDispOrderMap = new Dictionary<string, IList<int>>();
            /// <summary>
            /// �\��ςݕ\�����̃}�b�v���擾���܂��B
            /// </summary>
            /// <value>�\��ςݕ\�����̃}�b�v</value>
            private IDictionary<string, IList<int>> ReservedMakerDispOrderMap { get { return _reservedMakerDispOrderMap; } } 

            #endregion  // <�\��ςݕ\����/>

            #region <Constructor/>

            /// <summary>
            /// �f�t�H���g�R���X�g���N�^
            /// </summary>
            public DefaultMakerDispOrderManagaer() { }

            #endregion  // <Constructor/>

            /// <summary>
            /// �\��ςݕ\������ݒ肵�܂��B
            /// </summary>
            /// <param name="goodsMGroup">�����ރR�[�h</param>
            /// <param name="tbsPartsCode">BL�R�[�h</param>
            /// <param name="makerDispOrder">�\�񂷂�\�����ԍ�</param>
            public void Reserve(
                int goodsMGroup,
                int tbsPartsCode,
                int makerDispOrder
            )
            {
                string key = GetKey(goodsMGroup, tbsPartsCode);
                if (!ReservedMakerDispOrderMap.ContainsKey(key))
                {
                    ReservedMakerDispOrderMap.Add(key, new List<int>());
                }
                ReservedMakerDispOrderMap[key].Add(makerDispOrder);
            }

            /// <summary>
            /// �Ǘ�����D�ǐݒ�DataRow��ǉ����܂��B
            /// </summary>
            /// <param name="goodsMGroup">�����ރR�[�h</param>
            /// <param name="tbsPartsCode">BL�R�[�h</param>
            /// <param name="primeSettingDataRow">�Ǘ�����D�ǐݒ�DataRow</param>
            public void Add(
                int goodsMGroup,
                int tbsPartsCode,
                DataRow primeSettingDataRow
            )
            {
                string key = GetKey(goodsMGroup, tbsPartsCode);
                if (!PrimeSettingDataRowMap.ContainsKey(key))
                {
                    PrimeSettingDataRowMap.Add(key, new List<DataRow>());
                }
                PrimeSettingDataRowMap[key].Add(primeSettingDataRow);
            }

            /// <summary>
            /// �f�t�H���g�̕\������ݒ肵�܂��B
            /// </summary>
            public void SetDefaultMakerDispOrder()
            {
                if (PrimeSettingDataRowMap.Count.Equals(0)) return;

                foreach (string key in PrimeSettingDataRowMap.Keys)
                {
                    int makerDispOrder = 1; // �f�t�H���g�\������1�`�A��
                    foreach (DataRow settingDataRow in PrimeSettingDataRowMap[key])
                    {
                        makerDispOrder = GetDefaultMakerDispOrder(key, makerDispOrder);
                        
                        settingDataRow[PrimeSettingInfo.COL_MAKERDISPORDER] = makerDispOrder;
                        settingDataRow[COL_CHANGEFLAG] = true;  // �ۑ�����DB�W�J�����悤�ɕύX�t���O��ON

                        makerDispOrder++;
                    }
                }
            }

            /// <summary>
            /// �f�t�H���g�\�����ԍ����擾���܂��B
            /// </summary>
            /// <param name="reservedMapKey">�\��ςݕ\�����ԍ��}�b�v�̃L�[</param>
            /// <param name="makerDispOrderSeed">�\���������Z����V�[�h</param>
            /// <returns>�f�t�H���g�\�����ԍ�</returns>
            private int GetDefaultMakerDispOrder(
                string reservedMapKey,
                int makerDispOrderSeed
            )
            {
                if (!Reserved(reservedMapKey, makerDispOrderSeed))
                {
                    return makerDispOrderSeed;
                }
                else
                {
                    return GetDefaultMakerDispOrder(reservedMapKey, makerDispOrderSeed + 1);
                }
            }

            /// <summary>
            /// �\��ςݕ\�����ԍ������肵�܂��B
            /// </summary>
            /// <param name="key">�}�b�v�̃L�[</param>
            /// <param name="makerDispOrder">�\����</param>
            /// <returns>
            /// <c>true</c> :�\��ς݂ł���B
            /// <c>false</c>:�\��ς݂ł͂Ȃ��B
            /// </returns>
            private bool Reserved(
                string key,
                int makerDispOrder
            )
            {
                if (!ReservedMakerDispOrderMap.ContainsKey(key)) return false;
                return ReservedMakerDispOrderMap[key].IndexOf(makerDispOrder) >= 0;
            }

            /// <summary>
            /// �}�b�v�̃L�[���擾���܂��B
            /// </summary>
            /// <param name="goodsMGroup">�����ރR�[�h</param>
            /// <param name="tbsPartsCode">BL�R�[�h</param>
            /// <returns>�����ރR�[�h("0000") + BL�R�[�h("0000")</returns>
            private static string GetKey(
                int goodsMGroup,
                int tbsPartsCode
            )
            {
                return goodsMGroup.ToString("0000") + tbsPartsCode.ToString("0000");
            }
        }

        #endregion  // �f�t�H���g�\����
        // ADD 2008/12/05 �s��Ή�[8524] �d�l�ύX �\�������ݒ肳��Ă��Ȃ��ꍇ�A1�`�����ō̔� ----------<<<<<

        // ADD 2009/01/14 �d�l�ύX�F�����ނ̂�������\������ ---------->>>>>
        #region <���[�J�[���X�g/>

        /// <summary>
        /// ���[�J�[�̏W���̃N���X
        /// </summary>
        private sealed class MakerAgreegate
        {
            #region <���[�J�[�̃R���N�V����/>

            /// <summary>�����ރR�[�h�ŃO���[�v���������[�J�[�̃}�b�v</summary>
            private readonly IDictionary<int, IDictionary<int, string>> _makerListMap = new Dictionary<int, IDictionary<int, string>>();
            /// <summary>
            /// �����ރR�[�h�ŃO���[�v���������[�J�[�̃}�b�v���擾���܂��B
            /// </summary>
            /// <value>�����ރR�[�h�ŃO���[�v���������[�J�[�̃}�b�v</value>
            private IDictionary<int, IDictionary<int, string>> MakerListMap { get { return _makerListMap; } }

            /// <summary>�����ރR�[�h+���[�J�[�R�[�h�ŃO���[�v�������}�b�v</summary>
            private readonly IDictionary<string, IDictionary<int, string>> _middleMakerMap = new Dictionary<string, IDictionary<int, string>>();
            /// <summary>
            /// �����ރR�[�h+���[�J�[�R�[�h�ŃO���[�v�������}�b�v���擾���܂��B
            /// </summary>
            /// <value>�����ރR�[�h+���[�J�[�R�[�h�ŃO���[�v�������}�b�v</value>
            private IDictionary<string, IDictionary<int, string>> MiddleMakerMap { get { return _middleMakerMap; } }

            #endregion  // <���[�J�[�̃R���N�V����/>

            #region <Constructor/>

            /// <summary>
            /// �f�t�H���g�R���X�g���N�^
            /// </summary>
            public MakerAgreegate() { }

            #endregion  // <Constructor/>

            /// <summary>
            /// ���[�J�[��ǉ����܂��B
            /// </summary>
            /// <param name="primeSettingRow">�D�ǐݒ�e�[�u���̃��R�[�h</param>
            public void Add(DataRow primeSettingRow)
            {
                int middleGenreCode = (int)primeSettingRow[PrimeSettingInfo.COL_MIDDLEGENRECODE];
                int makerCode       = (int)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERCD];

                // �����ރR�[�h�ŃO���[�v��
                if (!MakerListMap.ContainsKey(middleGenreCode))
                {
                    MakerListMap.Add(middleGenreCode, new Dictionary<int, string>());
                }
                IDictionary<int, string> makerMap = MakerListMap[middleGenreCode];
                if (!makerMap.ContainsKey(makerCode))
                {
                    makerMap.Add(makerCode, (string)primeSettingRow[PrimeSettingInfo.COL_PARTSMAKERFULLNAME]);
                }

                // �����ރR�[�h+���[�J�[�R�[�h�ŊǗ�
                string middleGenreCodeKey = ConvertMiddleGenreCodeToKey(middleGenreCode);
                string key = middleGenreCodeKey + ConvertPartsMakerCdToKey(makerCode);
                {
                    if (!MiddleMakerMap.ContainsKey(key))
                    {
                        MiddleMakerMap.Add(key, new Dictionary<int, string>());
                    }
                    IDictionary<int, string> supplierMap = MiddleMakerMap[key];

                    // �d������Ǘ�
                    int supplierCode = 0;
                    string supplierName = string.Empty;
                    try
                    {
                        supplierCode = (int)primeSettingRow[PrimeSettingInfo.COL_SUPPLIERCD];
                        supplierName = (string)primeSettingRow[PrimeSettingInfo.COL_SUPPLIERNAME];
                    }
                    catch (InvalidCastException)    // DBNull�̏ꍇ
                    {
                        supplierCode = 0;
                        supplierName = string.Empty;
                    }
                    if (!supplierMap.ContainsKey(supplierCode))
                    {
                        supplierMap.Add(supplierCode, supplierName);
                    }
                }
            }

            /// <summary>
            /// �d����R�[�h�Ɩ��̂��擾���܂�
            /// </summary>
            /// <param name="middleGenreCode">�����ރR�[�h</param>
            /// <param name="makerCode">���[�J�[�R�[�h</param>
            /// <returns>
            /// �w�肳�ꂽ�����ރR�[�h+���[�J�[�R�[�h�Ɋ֘A����d����R�[�h���S�ē���ł���΁A
            /// ���̎d����R�[�h�Ɩ��̂�Ԃ��܂��B
            /// �i����ȊO�͋�̎d�����Ԃ��܂��j
            /// </returns>
            public CodeNamePair<int> FindSupplierCodeName(
                int middleGenreCode,
                int makerCode
            )
            {
                CodeNamePair<int> emptySupplier = new CodeNamePair<int>(0, string.Empty);
                {
                    string middleGenreCodeKey   = ConvertMiddleGenreCodeToKey(middleGenreCode);
                    string makerCodeKey         = ConvertPartsMakerCdToKey(makerCode);
                    string key = middleGenreCodeKey + makerCodeKey;
                    if (MiddleMakerMap.ContainsKey(key))
                    {
                        IDictionary<int, string> supplierMap = MiddleMakerMap[key];
                        // �����ނƃ��[�J�[�̂܂Ƃ܂�Ŏd����R�[�h��1���̏ꍇ
                        if (supplierMap.Count.Equals(1))
                        {
                            foreach (int supplierCode in supplierMap.Keys)
                            {
                                return new CodeNamePair<int>(supplierCode, supplierMap[supplierCode]);
                            }
                        }
                    }
                }
                return emptySupplier;
            }

            /// <summary>
            /// �w�肵�����[�J�[�R�[�h���w�肵�������ރR�[�h�Ɋ֘A�t�������肵�܂��B
            /// </summary>
            /// <param name="middleGenreCode">�����ރR�[�h</param>
            /// <param name="makerCode">���[�J�[�R�[�h</param>
            /// <returns></returns>
            public bool ContainsMakerCode(
                int middleGenreCode,
                int makerCode
            )
            {
                if (!MakerListMap.ContainsKey(middleGenreCode)) return false;

                return MakerListMap[middleGenreCode].ContainsKey(makerCode);
            }

            /// <summary>
            /// �����ރR�[�h�Ɋ֘A�t�����[�J�[�R�[�h���������܂��B
            /// </summary>
            /// <param name="middleGenreCode">�����ރR�[�h</param>
            /// <returns>�����ރR�[�h�Ɋ֘A�t�����[�J�[�R�[�h</returns>
            public IList<int> FindMakerCode(int middleGenreCode)
            {
                IList<int> foundMakerCodeList = new List<int>();
                {
                    if (MakerListMap.ContainsKey(middleGenreCode))
                    {
                        IDictionary<int, string> makerMap = MakerListMap[middleGenreCode];
                        foreach (int makerCode in makerMap.Keys)
                        {
                            foundMakerCodeList.Add(makerCode);
                        }
                    }
                }
                return foundMakerCodeList;
            }

            #region <�}�b�v�̃L�[/>

            /// <summary>
            /// �����ރR�[�h���L�[�ɕϊ����܂��B
            /// </summary>
            /// <param name="middleGenreCode">�����ރR�[�h</param>
            /// <returns>�L�[�F�����ރR�[�h�i"0000"�j</returns>
            private static string ConvertMiddleGenreCodeToKey(int middleGenreCode)
            {
                return middleGenreCode.ToString("0000");
            }

            /// <summary>
            /// BL�R�[�h���L�[�ɕϊ����܂��B
            /// </summary>
            /// <param name="tbsPartsCode">BL�R�[�h</param>
            /// <returns>�L�[�FBL�R�[�h�i"0000"�j</returns>
            private static string ConvertTbsPartsCodeToKey(int tbsPartsCode)
            {
                return tbsPartsCode.ToString("0000");
            }

            /// <summary>
            /// ���[�J�[�R�[�h���L�[�ɕϊ����܂��B
            /// </summary>
            /// <param name="partsMakerCd">���[�J�[�R�[�h</param>
            /// <returns>�L�[�F���[�J�[�R�[�h�i"0000"�j</returns>
            private static string ConvertPartsMakerCdToKey(int partsMakerCd)
            {
                return partsMakerCd.ToString("0000");
            }

            #endregion  // <�}�b�v�̃L�[/>
        }

        #endregion  // <���[�J�[���X�g/>
        // ADD 2009/01/14 �d�l�ύX�F�����ނ̂�������\������ ----------<<<<<

        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ---------->>>>>
        #region <�֘ABL�R�[�h/>

        /// <summary>
        /// �D�ǐݒ�O���[�v=0���L�������肵�܂��B
        /// </summary>
        /// <value><c>false</c>�F����</value>
        public static bool ExistsGroup0
        {
            get
            {
#if _EXISTS_GROUP0_
                return true;
#else
                return false;
#endif
            }
        }

        /// <summary>
        /// �֘ABL�R�[�h�̏W���̃N���X
        /// </summary>
        private sealed class RelatedBLCodeAgreegate
        {
            #region <�D�ǐݒ�O���[�v�̃}�b�v/>

            /// <summary>�D�ǐݒ�O���[�v�̃}�b�v</summary>
            /// <remarks>
            /// �L�[�F�D�ǐݒ�O���[�v
            /// �l�F�D�ǐݒ背�R�[�h�̃��X�g
            /// </remarks>
            private readonly IDictionary<int, IList<DataRow>> _groupedPrimeSettingMap = new Dictionary<int, IList<DataRow>>();
            /// <summary>
            /// �D�ǐݒ�O���[�v�̃}�b�v���擾���܂��B
            /// </summary>
            /// <remarks>
            /// �L�[�F�D�ǐݒ�O���[�v
            /// �l�F�D�ǐݒ背�R�[�h�̃��X�g
            /// </remarks>
            /// <value>�D�ǐݒ�O���[�v�̃}�b�v</value>
            private IDictionary<int, IList<DataRow>> GroupedPrimeSettingMap { get { return _groupedPrimeSettingMap; } }

            #endregion  // <�D�ǐݒ�O���[�v�̃}�b�v/>

            #region <Constructor/>

            /// <summary>
            /// �f�t�H���g�R���X�g���N�^
            /// </summary>
            public RelatedBLCodeAgreegate() { }

            #endregion  // <Constructor/>

            /// <summary>
            /// �֘ABL�R�[�h��ǉ����܂��B
            /// </summary>
            /// <param name="primeSettingRow">�D�ǐݒ�e�[�u���̃��R�[�h</param>
            public void Add(DataRow primeSettingRow)
            {
                int prmSetGroup = (int)primeSettingRow[PrimeSettingInfo.COL_PRMSETGROUP];

#if _EXISTS_GROUP0_
#else
                if (prmSetGroup.Equals(0)) return;
#endif

                if (!GroupedPrimeSettingMap.ContainsKey(prmSetGroup))
                {
                    GroupedPrimeSettingMap.Add(prmSetGroup, new List<DataRow>());
                }
                GroupedPrimeSettingMap[prmSetGroup].Add(primeSettingRow);
            }
        }

        #endregion  // <�֘ABL�R�[�h/>
        // ADD 2009/01/15 �d�l�ύX�F�֘ABL�R�[�h�̕\�� ----------<<<<<

        // ADD 2009/01/21 �s��Ή�[6970] ---------->>>>>
        #region <�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃w���p�N���X/>

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̏W���̃N���X
        /// </summary>
        private sealed class UserPrimeSettingAgreegate
        {
            #region <�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃R���N�V����/>

            /// <summary>�D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h�̃}�b�v</summary>
            private readonly IDictionary<string, PrmSettingUWork> _userPrimeSettingRecordMap = new Dictionary<string, PrmSettingUWork>();
            /// <summary>
            /// �D�ǐݒ�}�X�^(���[�U�[�o�^���j���R�[�h�̃}�b�v���擾���܂��B
            /// </summary>
            /// <value>�D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h�̃}�b�v</value>
            private IDictionary<string, PrmSettingUWork> UserPrimeSettingRecordMap { get { return _userPrimeSettingRecordMap; } }

            #endregion  // <�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃R���N�V����/>

            #region <Constrcutor/>

            /// <summary>
            /// �f�t�H���g�R���X�g���N�^
            /// </summary>
            public UserPrimeSettingAgreegate() { }

            #endregion  // <Constructor/>

            /// <summary>
            /// �R���N�V�������N���A���܂��B
            /// </summary>
            public void Clear()
            {
                UserPrimeSettingRecordMap.Clear();
            }

            /// <summary>
            /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h��ǉ����܂��B
            /// </summary>
            /// <param name="prmSettingUWork">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h</param>
            public void Add(PrmSettingUWork prmSettingUWork)
            {
                string key = GetKey(prmSettingUWork);
                if (UserPrimeSettingRecordMap.ContainsKey(key))
                {
                    UserPrimeSettingRecordMap.Remove(key);
                }
                UserPrimeSettingRecordMap.Add(key, prmSettingUWork);
            }

            /// <summary>
            /// �������܂��B
            /// </summary>
            /// <param name="middleGenreCode">�����ރR�[�h</param>
            /// <param name="blCode">BL�R�[�h</param>
            /// <param name="makerCode">���[�J�[�R�[�h</param>
            /// <returns>�Y�����郌�R�[�h�������ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
            public PrmSettingUWork Find(
                int middleGenreCode,
                int blCode,
                int makerCode,
                int selectCode,
                int prmSetDtl
            )
            {
                string key = GetKey(middleGenreCode, blCode, makerCode, selectCode, prmSetDtl);
                if (UserPrimeSettingRecordMap.ContainsKey(key))
                {
                    return UserPrimeSettingRecordMap[key];
                }
                return null;
            }

            /// <summary>
            /// �������܂��B
            /// </summary>
            /// <param name="middleGenreCode">�����ރR�[�h</param>
            /// <param name="blCode">BL�R�[�h</param>
            /// <param name="makerCode">���[�J�[�R�[�h</param>
            /// <returns>�Y�����郌�R�[�h�������ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
            public ArrayList FindAll(
                int middleGenreCode,
                int blCode,
                int makerCode
            )
            {
                ArrayList retList = new ArrayList();
                foreach (PrmSettingUWork work in UserPrimeSettingRecordMap.Values)
                {
                    if ((work.GoodsMGroup == middleGenreCode) && (work.TbsPartsCode == blCode) && (work.PartsMakerCd == makerCode))
                    {
                        retList.Add(work);
                    }
                }

                if (retList.Count == 0)
                {
                    return null;
                }
                else
                {
                    return retList;
                }
            }

            /// <summary>
            /// �������܂��B
            /// </summary>
            /// <param name="middleGenreCode">�����ރR�[�h</param>
            /// <param name="blCode">BL�R�[�h</param>
            /// <param name="makerCode">���[�J�[�R�[�h</param>
            /// <returns>�Y�����郌�R�[�h�������ꍇ�A<c>null</c>��Ԃ��܂��B</returns>
            public ArrayList FindAll(
                string sectionCode,
                int middleGenreCode,
                int makerCode
            )
            {
                ArrayList retList = new ArrayList();
                foreach (PrmSettingUWork work in UserPrimeSettingRecordMap.Values)
                {
                    if ((work.SectionCode.Trim() == sectionCode.Trim()) && (work.GoodsMGroup == middleGenreCode) && (work.PartsMakerCd == makerCode))
                    {
                        retList.Add(work);
                    }
                }

                if (retList.Count == 0)
                {
                    return null;
                }
                else
                {
                    return retList;
                }
            }

            #region <�L�[/>

            /// <summary>
            /// �L�[���擾���܂��B
            /// </summary>
            /// <param name="prmSettingUWork">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j���R�[�h</param>
            /// <returns>middleGenreCode.ToString("0000") + blCode.ToString("0000") + makerCode.ToString("0000")</returns>
            private static string GetKey(PrmSettingUWork prmSettingUWork)
            {
                int middleGenreCode = prmSettingUWork.GoodsMGroup;
                int blCode          = prmSettingUWork.TbsPartsCode;
                int makerCode       = prmSettingUWork.PartsMakerCd;
                int selectCode = prmSettingUWork.PrmSetDtlNo1;
                int prmSetDtlNo = prmSettingUWork.PrmSetDtlNo2;
                return GetKey(middleGenreCode, blCode, makerCode, selectCode, prmSetDtlNo);
            }

            /// <summary>
            /// �L�[���擾���܂��B
            /// </summary>
            /// <param name="middleGenreCode">�����ރR�[�h</param>
            /// <param name="blCode">BL�R�[�h</param>
            /// <param name="makerCode">���[�J�[�R�[�h</param>
            /// <returns>middleGenreCode.ToString("0000") + blCode.ToString("0000") + makerCode.ToString("0000")</returns>
            public static string GetKey(
                int middleGenreCode,
                int blCode,
                int makerCode
            )
            {
                return middleGenreCode.ToString("0000") + blCode.ToString("0000") + makerCode.ToString("0000");
            }

            public static string GetKey(
                int middleGenreCode,
                int blCode,
                int makerCode,
                int selectCode,
                int prmSetDtlNo
            )
            {
                return middleGenreCode.ToString("0000") + blCode.ToString("0000") + makerCode.ToString("0000") +
                        selectCode.ToString("0000") + prmSetDtlNo.ToString("0000");
            }

            #endregion  // <�L�[/>
        }

        #endregion  // <�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃w���p�N���X/>
        // ADD 2009/01/21 �s��Ή�[6970] ----------<<<<<
    }
}
