
//#define _CONST_OFFER_DATE_

using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
//using System.Xml;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
//using Broadleaf.Library.Globarization;
using Broadleaf.Library.Collections;
//using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller.Util;    // ADD 2009/01/22 �@�\�ǉ�
using System.IO;

namespace Broadleaf.Application.Controller
{
    using ProcessConfigAcs = SingletonPolicy<ProcessConfig>;   // ADD 2009/01/30 �@�\�ǉ�
    using UserUpdatingPrimeSettingPair = Pair<ArrayList, ArrayList>;       // ADD 2009/02/03 �@�\�ǉ�
    using LatestPair = Pair<DateTime, int>;
    using Microsoft.Win32;              // ADD 2009/02/03 �@�\�ǉ�

    /// <summary>
    /// �񋟃}�[�W�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �񋟃}�[�W�A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.09.05</br>
    /// <br></br>
    /// <br>Update Note: BL�R�[�h�X�V�敪�̑Ή�(MANTIS[0014775])</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2009/12/11</br>    
    /// <br></br>
    /// <br>Update Note: MANTIS[0014775]�Ή�</br>
    /// <br>             �E�Z���N�g�R�[�h�����镔�i�́A�D�ǐݒ���Q�Ƃ��ĉ��i�Z�b�g����</br>
    /// <br>             �E����񋟓��t�A���i�ŕ������i�}�X�^���������ꍇ�������ł���悤�ɏC��</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/04/23</br>    
    /// <br></br>
    /// <br>Update Note: DC�z�u�Ή��i���׌y���Ή��j</br>
    /// <br>             �E�����[�g��10000������������̂ŁA�A�N�Z�X�N���X���Ή�����</br>
    /// <br>Programmer : 21024�@���X�� ��</br>
    /// <br>Date       : 2010/06/14</br>    
    /// <br></br>
    /// <br>Update Note: ��DB�����Ή�</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2010/06/19</br>    
    /// <br></br>
    /// <br>Update Note: �ڑ������Ή�</br>
    /// <br>Programmer : 22008�@���� ���n</br>
    /// <br>Date       : 2010/07/02</br>    
    /// <br>Update Note: �w�ʍX�V�s��Ή�</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2012/06/26</br>  
    /// <br>Update Note: �i�����S�p�ɍX�V�����̕s��Ή�</br>
    /// <br>Programmer : ����</br>
    /// <br>Date       : 2012/07/02</br> 
    /// <br>Update Note: BL�R�[�h�X�V�s��Ή�</br>
    /// <br>Programmer : �{�{</br>
    /// <br>Date       : 2013/01/31</br> 
    /// <br>Update Note: 2013/05/13 chenyd </br>
    /// <br>�Ǘ��ԍ�   : 10901273-00  2013/06/18�z�M��</br>
    /// <br>           : Redmine#35515 </br>
    /// <br>           : �񋟃f�[�^�X�V���� �������i�����f����Ȃ��̑Ή�</br>
    /// <br>Update Note: 2014/08/21 songg </br>
    /// <br>�Ǘ��ԍ�   : 11070149-00 �d�|��1923 Redmine#35573</br>
    /// <br>           : �񋟃f�[�^�X�V�Łu��� 'System.OutOfMemmoryException' �̗�O���X���[����܂����B�v�̃G���[���������A���i�X�V���ł��Ȃ��B</br>
    /// <br>Update Note: 2017/07/18 �e�c ���V</br>
    /// <br>�Ǘ��ԍ�   : 11300429-00 Redmine#49037</br>
    /// <br>           : �񋟃f�[�^�X�V�Łu��� 'System.OutOfMemmoryException' �̗�O���X���[����܂����B�v�̃G���[���������A���i�X�V���ł��Ȃ��B</br>
    /// <br>Update Note: 2025/08/11 �c������</br>
    /// <br>�Ǘ��ԍ�   : 12170169-00</br>
    /// <br>           : �񋟃f�[�^�̒񋟓��t�������̓��t�ɂȂ��Ă���s��̋~�ϑΉ�</br>
    /// </remarks>
    public class OfferMergeAcs
    {
        #region Private Member

        /// <summary>�������X�V�Ώۃe�[�u��</summary>
        private IDictionary<string, LatestPair> _autopLatestDayDic;

        ///<summary>�������ʃt���O</summary>
        private int _autoFlg = 0;

        /// <summary>��ƃR�[�h</summary>
        private string _enterpriseCode;

        /// <summary>�񋟃f�[�^�X�V�ݒ�</summary>
        private PriceChgSet _priceChgSet;

        // >>> ADD 2009/03/12 *** *** *** *** *** *** *** *** ***
        /// <summary>�O�񏤕i���[�N</summary>
        private GoodsUWork PriGoodsUWork = new GoodsUWork();

        // 2010/04/23 Del >>>
        ///// <summary>�O��񋟉��i���[�N</summary>
        //private GoodsPriceUWork PriorOfrGoodsPriceUWork = new GoodsPriceUWork();

        ///// <summary>�O�񃆁[�U�[���i���[�N</summary>
        //private GoodsPriceUWork PriorGoodsPriceUWork = new GoodsPriceUWork();

        ///// <summary>�V�K�p���i���[�N</summary>
        //private GoodsPriceUWork writeGoodsPriseUwork = new GoodsPriceUWork();

        ///// <summary>�폜�p���i���[�N</summary>
        //private GoodsPriceUWork deleteGoodsPriceUWork = new GoodsPriceUWork();

        //private bool SkipFlg = false; // �����[�J�[��i�Ԃ̎��ɏ������X�L�b�v����
        //private bool FirstFlg = false; // �O��ƈႤ���[�J�[�i�Ԃ̂Ƃ��ɏ����𑖂点��B
        //private bool PriorDelflg = false; // �O�񉿊i�폜�t���O
        // 2010/04/23 Del <<<

        private ArrayList writeGoodsList = null; // ���i���X�g(�����p)
        private ArrayList writePricesList = null; // ���i���X�g(�����p)
        private ArrayList deletePriceList = null; // ���i���X�g(�폜�p)

        private CustomSerializeArrayList lst = null; // �ް����M�p���i����ؽ�

        private ArrayList userUpdatingPMakerList = null;             // ���[�U�[���i���[�J�[���̍X�V�f�[�^���X�g
        private ArrayList userUpdatingModelNameList = null;          // ���[�U�[�Ԏ�}�X�^�X�V�f�[�^���X�g
        private ArrayList userUpdatingGoodsMGroupList = null;        // ���[�U�[���i�����ރ}�X�^�X�V�f�[�^���X�g
        private ArrayList userUpdatingBLGroupList = null;            // ���[�U�[BL�R�[�h�X�V�f�[�^���X�g
        private ArrayList userUpdatingTbsPartsCodeList = null;       // ���[�U�[BL�O���[�v�}�X�^�X�V�f�[�^���X�g
        private ArrayList userUpdatingPartsPosList = null;           // ���[�U�[���ʃ}�X�^�X�V�f�[�^���X�g

        private PriceRevisionParameter priceRevisionParameter = null;// ���i�����p�����[�^

        private Dictionary<int, ArrayList> offerLstPrmSetChg = null; // �D�ǐݒ�ύX�}�X�^ <offerDate,�ύXؽ�> 1.5���� 
        private Dictionary<int, ArrayList> offerLstPrmSet = null;    // �D�ǐݒ�}�X�^     <offerDate,�ݒ�ؽ�> 1.5����

        private CustomSerializeArrayList UsrUpdatePrmsetList = null;  // �D�ǐݒ�}�X�^�X�V���X�g

        private PriceMergeSt pricMergeSt = null;                     // �񋟃f�[�^�X�V�ݒ�

        private StreamWriter writer = null;                          // �e�L�X�g���O�p

        private int prmSetAllUpdCount = 0;

        private int partsPsDate = 0;                                 // ����p�X�V�����ʃ}�X�^�񋟓��t

        private string workDir = string.Empty;
        // <<< ADD 2009/03/12 *** *** *** *** *** *** *** *** *** 

        //------------ ADD By chenyd 2013/05/13 For Redmine #35515------------------------->>>>>
        /// <summary>�������i�}�X�^�e�[�u���A�N�Z�X�N���X</summary>
        private IsolIslandPrcAcs _isolIslandPrcAcs;

        /// <summary>�������i�f�[�^�N���X</summary>
        private static List<IsolIslandPrc> _isolIslandList;
        //------------ ADD By chenyd 2013/05/13 For Redmine #35515--------------------------<<<<<

        // ADD 2025/08/11 �c������ ----->>>>> 
        // �X�L�b�v�Ώۓ��t���X�g�i�Œ�l�j
        // �񋟃f�[�^���X�L�b�v����Ώۓ��t�����X�g�Ƃ��ĕێ��A����ǉ����K�v�ȏꍇ�͈ȉ��̃��X�g��ҏW
        private readonly List<string> SkipOfferDates = new List<string>(
             new string[] { "20260701", "20260703", "20260704", "20260705", "20260706", "20260707" }
            );
        // �X�L�b�v�Ώۊ��ԁi�J�n�j
        private const int SkipOfferTermSt = 20250904;//2025�N09��04��
        // �X�L�b�v�Ώۊ��ԁi�I���j
        private const int SkipOfferTermEd = 20260630;//2026�N06��30��
        // �X�L�b�v�Ώۓ��t���X�g�ɊY�������O��񋟓��t
        string orgDate = string.Empty;
        // �X�L�b�v�Ώۓ��t���X�g�ȊO�̍ŐV�O��񋟓��t
        string candDate = string.Empty;
        // ADD 2025/08/11 �c������ -----<<<<< 

        /// <summary>�}�[�W�f�[�^�̎擾��</summary>
        private IMergeDataGet _iMergeDataGetter;
        // ADD 2009/02/02 �@�\�ǉ��F�Ώۓ��t�擾 ---------->>>>>
        /// <summary>
        /// �}�[�W�f�[�^�̎擾�҂��擾���܂��B
        /// </summary>
        private IMergeDataGet MergeDataGetter
        {
            get
            {
                if (_iMergeDataGetter == null)
                {
                    _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();
                }
                return _iMergeDataGetter;
            }
        }
        // ADD 2008/02/02 �@�\�ǉ��F�Ώۓ��t�擾 ----------<<<<<

        /// <summary>�}�[�W�̎��s��</summary>
        private IOfferMerge _iOfferMerger;
        // ADD 2009/02/02 �@�\�ǉ��F�Ώۓ��t�擾 ---------->>>>>
        /// <summary>
        /// �}�[�W�̎��s�҂��擾���܂��B
        /// </summary>
        private IOfferMerge OfferMerger
        {
            get
            {
                if (_iOfferMerger == null)
                {
                    _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();
                }
                return _iOfferMerger;
            }
        }
        // ADD 2008/02/02 �@�\�ǉ��F�Ώۓ��t�擾 ----------<<<<<

        /// <summary>���̏㏑���t���O</summary>        
        private bool _nameOverwriteFlg;

        //private List<string> lstPartsPos = null;

        // ADD 2009/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ---------->>>>>
        /// <summary>�}�[�W�̃`�F�b�N��</summary>
        private readonly MergeChecker _checker = new MergeChecker();
        /// <summary>
        /// �}�[�W�̃`�F�b�N�҂��擾���܂��B
        /// </summary>
        public MergeChecker Checker { get { return _checker; } }
        // ADD 2008/01/22 �@�\�ǉ��F�o�[�W�����`�F�b�N ----------<<<<<
        // ADD 2009/02/20 �s��Ή�[11708] ---------->>>>>
        /// <summary>���|�I�v�V����</summary>
        private PurchaseOption _option;
        /// <summary>
        /// ���|�I�v�V�������擾���܂��B
        /// </summary>
        public PurchaseOption Option
        {
            get
            {
                if (_option == null)
                {
                    _option = new PurchaseOption();
                }
                return _option;
            }
        }
        // ADD 2009/02/20 �s��Ή�[11708] ----------<<<<<

        #endregion  // Private Member

        #region Constructor

        /// <summary>
        /// �񋟃}�[�W�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �񋟃}�[�W�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30290</br>
        /// <br>Date       : 2008.09.05</br>
        /// </remarks>
        public OfferMergeAcs()
        {
            try
            {
                _myLogger = new MyLogWriter(this); // ADD 2009/02/10 �@�\�ǉ��F���O�o��
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
            }
        }

        #endregion  //  Constructor

        #region Public Methods

        #region [ �p�~���\�b�h ]

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// </remarks>
        [Obsolete("�p�~���\�b�h�ł��B")]
        public int GetOnlineMode()
        {
            //if (this._iPartsPosCodeUDB == null)
            //{
            //    return (int)ConstantManagement.OnlineMode.Offline;
            //}
            //else
            //{
            return (int)ConstantManagement.OnlineMode.Online;
            //}
        }

        #endregion  // [�p�~���\�b�h]

        /// <summary>
        /// �������i���i�����ݒ�擾�j
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns></returns>
        public int Initialize(string enterpriseCode)
        {
            int status = 0;
            PriceChgSetAcs _PriceChgSetAcs = new PriceChgSetAcs();
            status = _PriceChgSetAcs.Read(out _priceChgSet, enterpriseCode);
            if (_priceChgSet.NameUpdDiv == 1) // 0:����@1:���Ȃ�
                _nameOverwriteFlg = false;
            else
                _nameOverwriteFlg = true;
            return status;
        }

        /// <summary>
        /// �}�[�W�����̏㏑�����邵�Ȃ��̐ݒ�擾
        /// </summary>
        /// <returns>true:�㏑������ false:�㏑�����Ȃ�</returns>
        public bool NameOverwrite
        {
            get
            {
                return _nameOverwriteFlg;
            }
        }

        // ADD 2009/02/02 �@�\�ǉ��F�Ώی��� ---------->>>>>
        #region [ ������ ]

        /// <summary>������</summary>
        private readonly ProcessSequenceByDate _processSequence = new ProcessSequenceByDate();
        /// <summary>
        /// ���������擾���܂��B
        /// </summary>
        public ProcessSequenceByDate ProcessSequence { get { return _processSequence; } }

        #endregion  // [ ������ ]

        #region <UI�p/>

        /// <summary>
        /// �Ώۓ��t���擾���A��������ݒ肵�܂��B�iUI�p�j
        /// </summary>
        /// <param name="config">�����\��</param>
        /// <returns>�����[�g�̑Ώۓ��t�擾���\�b�h�ɂē��e���X�V���ꂽ�����\��</returns>
        [Obsolete("UI�p�Ɏc���Ă��郁�\�b�h�iProcessConfig��p�����C���^�[�t�F�[�X���Đ݌v�j")]
        public ProcessConfig GetTargetAndSetProcessSequence(ProcessConfig config)
        {
            ProcessSequence.Clear();

            int blDate = ProcessConfigAcs.Instance.Policy.BLCodeMaster.ToPreviousDateNo();
            int groupDate = ProcessConfigAcs.Instance.Policy.BLGroupMaster.ToPreviousDateNo();
            int goodsMDate = ProcessConfigAcs.Instance.Policy.MiddleGenreMaster.ToPreviousDateNo();
            int modelNmDate = ProcessConfigAcs.Instance.Policy.ModelNameMaster.ToPreviousDateNo();
            int makerDate = ProcessConfigAcs.Instance.Policy.MakerMaster.ToPreviousDateNo();
            //int partsPosDate = ProcessConfigAcs.Instance.Policy.PartsPosCodeMaster.ToPreviousDateNo();
            int partsPosDate = 0;
            int ptmkPriceDate = ProcessConfigAcs.Instance.Policy.GoodsMaster.ToPreviousDateNo();
            int primPartsDate = ProcessConfigAcs.Instance.Policy.GoodsMaster.ToPreviousDateNo();
            int prmSetDate = ProcessConfigAcs.Instance.Policy.PrimeSettingMaster.ToPreviousDateNo();
            int prmSetChgDate = ProcessConfigAcs.Instance.Policy.PrimeSettingChangeMaster.ToPreviousDateNo();

            object objOfferDateList = null;
            int status = MergeDataGetter.GetOfferDate(
               blDate,                  // BL�R�[�h�}�X�^
               groupDate,               // BL�O���[�v�}�X�^
               goodsMDate,              // �����ރ}�X�^
               modelNmDate,             // �Ԏ�}�X�^
               makerDate,               // ���[�J�[�}�X�^
               partsPosDate,            // ���ʃ}�X�^
               ptmkPriceDate,           // ���i�}�X�^
               primPartsDate,           // ���i�}�X�^
               prmSetDate,              // �D�ǐݒ�}�X�^
               prmSetChgDate,           // �D�ǐݒ�ύX�}�X�^
               Option.SearchPartsType,  // ADD 2009/02/20 �s��Ή�[11708] �����F�����^�C�v�̒ǉ�
               Option.BigCarOfferDiv,   // ADD 2009/02/20 �s��Ή�[11708] �����F��^�I�v�V�����̒ǉ�
               out objOfferDateList
            );
            if (!status.Equals((int)Result.RemoteStatus.Normal) || status.Equals((int)Result.RemoteStatus.NotFound))
            {
                return ProcessConfigAcs.Instance.Policy;
            }

            ArrayList offerDateList = objOfferDateList as ArrayList;
            if (offerDateList == null || offerDateList.Count.Equals(0))
            {
                return ProcessConfigAcs.Instance.Policy;
            }

            foreach (PriceUpdManualDataWork offerDateInfo in (ArrayList)offerDateList)
            {
                #region <Debug/>

                Debug.Write(offerDateInfo.OfferDate);
                Debug.Write(", ");
                Debug.Write(offerDateInfo.ReNewOfferDate);
                Debug.Write(", ");
                Debug.Write(offerDateInfo.dataCnt);
                Debug.Write(", ");
                Debug.Write(offerDateInfo.allDatacnt);
                Debug.Write(", ");
                Debug.WriteLine(offerDateInfo.dataDiv);

                #endregion  // <Debug/>

                ProcessConfigItem configItem = ProcessConfigAcs.Instance.Policy[offerDateInfo.dataDiv];
                if (configItem != null)
                {
                    if (offerDateInfo.dataDiv != 7)
                        configItem.PresentCount = offerDateInfo.allDatacnt;
                    else
                        configItem.PresentCount += offerDateInfo.allDatacnt;
                }

                ProcessSequence.Add(offerDateInfo);
            }

            ProcessConfigAcs.Instance.Policy.UpdatePriceRevision();
            return ProcessConfigAcs.Instance.Policy;
        }

        #endregion  // <UI�p/>

        /// <summary>
        /// �Ώۓ��t���擾���A��������ݒ肵�܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�����[�g�̑Ώۓ��t�擾���\�b�h�ɂē��e���X�V���ꂽ�����\��</returns>
        public ProcessConfig GetTargetAndSetProcessSequence(string enterpriseCode)
        {
            const string DATE_NUMBER_FORMAT = "yyyyMMdd";

            // �O�񏈗����ƍX�V�������擾���A�O�񏈗������e�e�[�u���̑Ώۓ��t�Ƃ��ēW�J
            IDictionary<string, LatestPair> latestTableMap;

            if (_autoFlg == 0)
            {
                //latestTableMap = GetLatestHistoryMap(enterpriseCode);// DEL 2025/08/11 �c������
                // ADD 2025/08/11 �c������ ----->>>>>
                // ���i�}�X�^�̑O��񋟓��t��SkipOfferDates���X�g�ɊY������ꍇ�A�Y�����Ȃ��ŐV�̓��t��
                // �擾����i���ۂ̑O��񋟓��t��orgDate�Ŗ߂����j
                orgDate = string.Empty;
                candDate = string.Empty;
                latestTableMap = GetLatestHistoryMapWithSkip(enterpriseCode);
                // ADD 2025/08/11 �c������ -----<<<<< 
            }
            else
            {
                // ADD 2025/08/11 �c������ ----->>>>>
                // PMKHN09210U.exe�ł����{���邪�A�����ł�����x�蓮���Ɠ��������X�g�ɊY�����Ȃ��ŐV���t���擾
                orgDate = string.Empty;
                candDate = string.Empty;
                latestTableMap = GetLatestHistoryMapWithSkip(enterpriseCode);
                // ADD 2025/08/11 �c������ -----<<<<< 
                //latestTableMap = _autopLatestDayDic;// DEL 2025/08/11 �c������
                //_autoFlg = 0;
            }

            #region <BL�R�[�h�}�X�^/>

            int blDate = ProcessConfigAcs.Instance.Policy.BLCodeMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.BL_CODE_MASTER_ID))
            {
                string strBLDate = latestTableMap[ProcessConfig.BL_CODE_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                blDate = int.Parse(strBLDate);
            }

            #endregion  // <BL�R�[�h�}�X�^/>

            #region <BL�O���[�v�}�X�^/>

            int groupDate = ProcessConfigAcs.Instance.Policy.BLGroupMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.BL_GROUP_MASTER_ID))
            {
                string strGroupDate = latestTableMap[ProcessConfig.BL_GROUP_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                groupDate = int.Parse(strGroupDate);
            }

            #endregion  // <BL�O���[�v�}�X�^/>

            #region <�����ރR�[�h�}�X�^/>

            int goodsMDate = ProcessConfigAcs.Instance.Policy.MiddleGenreMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.MIDDLE_GENRE_MASTER_ID))
            {
                string strGoodsMDate = latestTableMap[ProcessConfig.MIDDLE_GENRE_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                goodsMDate = int.Parse(strGoodsMDate);
            }

            #endregion  // <�����ރR�[�h�}�X�^/>

            #region <�Ԏ�}�X�^/>

            int modelNmDate = ProcessConfigAcs.Instance.Policy.ModelNameMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.MODEL_NAME_MASTER_ID))
            {
                string strModelNmDate = latestTableMap[ProcessConfig.MODEL_NAME_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                modelNmDate = int.Parse(strModelNmDate);
            }

            #endregion  // <�Ԏ�}�X�^/>

            #region <���[�J�[�}�X�^/>

            int makerDate = ProcessConfigAcs.Instance.Policy.MakerMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.MAKER_MASTER_ID))
            {
                string strMakerDate = latestTableMap[ProcessConfig.MAKER_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                makerDate = int.Parse(strMakerDate);
            }

            #endregion  // <���[�J�[�}�X�^/>

            #region <���ʃ}�X�^/>

            //int partsPosDate = ProcessConfigAcs.Instance.Policy.PartsPosCodeMaster.ToPreviousDateNo();
            int partsPosDate = 0;
            if (latestTableMap.ContainsKey(ProcessConfig.PARTS_POS_CODE_MASTER_ID))
            {
                //string strPartsPosDate = latestTableMap[ProcessConfig.PARTS_POS_CODE_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                //partsPosDate = int.Parse(strPartsPosDate);
            }

            #endregion  // <���ʃ}�X�^/>


            #region <���i�}�X�^/>

            int ptmkPriceDate = ProcessConfigAcs.Instance.Policy.GoodsMaster.ToPreviousDateNo();

            if (latestTableMap.ContainsKey(ProcessConfig.GOODS_PRICE_MASTER_ID))
            {
                string strPtmkPriceDate = latestTableMap[ProcessConfig.GOODS_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                ptmkPriceDate = int.Parse(strPtmkPriceDate);

            }

            #endregion  // <���i�}�X�^/>

            #region <���i�}�X�^/>

            int primPartsDate = ProcessConfigAcs.Instance.Policy.GoodsMaster.ToPreviousDateNo();

            if (latestTableMap.ContainsKey(ProcessConfig.GOODS_MASTER_ID))
            {
                string strPrimPartsDate = latestTableMap[ProcessConfig.GOODS_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                primPartsDate = int.Parse(strPrimPartsDate);
            }

            ptmkPriceDate = primPartsDate;

            #endregion  // <���i�}�X�^/>

            #region <�D�ǐݒ�}�X�^/>

            int prmSetDate = ProcessConfigAcs.Instance.Policy.PrimeSettingMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.PRIME_SETTING_MASTER_ID))
            {
                string strPrmSetDate = latestTableMap[ProcessConfig.PRIME_SETTING_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                prmSetDate = int.Parse(strPrmSetDate);
            }

            #endregion  // <�D�ǐݒ�}�X�^/>

            #region <�D�ǐݒ�ύX�}�X�^/>

            int prmSetChgDate = ProcessConfigAcs.Instance.Policy.PrimeSettingChangeMaster.ToPreviousDateNo();
            if (latestTableMap.ContainsKey(ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID))
            {
                string strPrmSetChgDate = latestTableMap[ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID].First.ToString(DATE_NUMBER_FORMAT);
                prmSetChgDate = int.Parse(strPrmSetChgDate);
            }

            #endregion  // <�D�ǐݒ�ύX�}�X�^/>

            // �񋟓����擾
            object objOfferDateList = null;
            int status = MergeDataGetter.GetOfferDate(
               blDate,                  // BL�R�[�h�}�X�^
               groupDate,               // BL�O���[�v�}�X�^
               goodsMDate,              // �����ރ}�X�^
               modelNmDate,             // �Ԏ�}�X�^
               makerDate,               // ���[�J�[�}�X�^
               partsPosDate,            // ���ʃ}�X�^
               ptmkPriceDate,           // ���i�}�X�^
               primPartsDate,           // ���i�}�X�^
               prmSetDate,              // �D�ǐݒ�}�X�^
               prmSetChgDate,           // �D�ǐݒ�ύX�}�X�^
               Option.SearchPartsType,  // ADD 2009/02/20 �s��Ή�[11708] �����F�����^�C�v�̒ǉ�
               Option.BigCarOfferDiv,   // ADD 2009/02/20 �s��Ή�[11708] �����F��^�I�v�V�����̒ǉ�
               out objOfferDateList
            );
            if (!status.Equals((int)Result.RemoteStatus.Normal) || status.Equals((int)Result.RemoteStatus.NotFound))
            {
                return ProcessConfigAcs.Instance.Policy;
            }


            // ÷��۸ޏ����� (�Ώۓ��t�擾)
            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
            writer.Write(DateTime.Now + " �Ώۓ��t�擾 " + "status=" + status + "\r\n");
            writer.Flush();
            if (writer != null) writer.Close();

            ArrayList offerDateList = objOfferDateList as ArrayList;
            if (offerDateList == null || offerDateList.Count.Equals(0))
            {
                return ProcessConfigAcs.Instance.Policy;
            }

            // �񋟓��ɂ�鏈�������\�z
            ProcessSequence.Clear();
            {
                foreach (PriceUpdManualDataWork offerDateInfo in (ArrayList)offerDateList)
                {
                    #region <Debug/>

                    Debug.Write(offerDateInfo.OfferDate);
                    Debug.Write(", ");
                    Debug.Write(offerDateInfo.ReNewOfferDate);
                    Debug.Write(", ");
                    Debug.Write(offerDateInfo.dataCnt);
                    Debug.Write(", ");
                    Debug.Write(offerDateInfo.allDatacnt);
                    Debug.Write(", ");
                    Debug.WriteLine(offerDateInfo.dataDiv);

                    #endregion  // <Debug/>


                    //���ʃ}�X�^�Ȃ�A�Ώۓ��t���X�g�ɉ����Ȃ�
                    //if (offerDateInfo.dataDiv == 7)
                    //{
                    //    continue;
                    //}
                    ProcessConfigItem configItem = ProcessConfigAcs.Instance.Policy[offerDateInfo.dataDiv];
                    if (configItem != null)
                    {
                        configItem.PresentCount = offerDateInfo.allDatacnt;
                    }

                    ProcessSequence.Add(offerDateInfo);
                }
            }

            ProcessConfigAcs.Instance.Policy.UpdatePriceRevision();
            return ProcessConfigAcs.Instance.Policy;
        }
        
        // �C���X�g�[�����t�擾
        //-- DEL 2010/06/19 ---------------------------------->>>
        //private DateTime GetInstallDate()
        //{
        //    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\OFFER_AP\localhost\OFFER_DB");
        //    if (key == null)
        //    {
        //        return DateTime.MinValue;
        //    }
        //    string InstalOfferDate = key.GetValue("InstallOfferDate").ToString();
        //    int InstDateint = Int32.Parse(InstalOfferDate.Trim());

        //    DateTime instalOfferDate = DateTime.Parse(InstDateint.ToString("0000/00/00"));

        //    // �C���X�g�[�����t���1�����O����}�[�W�������邽��
        //    return instalOfferDate.AddMonths(-1);
        //}
        //-- DEL 2010/06/19 ----------------------------------<<<

        /// <summary>
        /// InstallOfferDate���擾���܂�
        /// </summary>
        /// <param name="InstallOfferDate">�C���X�g�[�����t</param>
        /// <returns>InstallOfferDate</returns>
        public int getInstallDate(ref DateTime InstallOfferDate)
        {
            
            // -- UPD 2010/06/19 -------------------------------->>>
            //if (_iMergeDataGetter == null)
            //    _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();
            //_iMergeDataGetter.GetInstalDate(ref InstallOfferDate);

            InstallOfferDate = DateTime.Now.AddMonths(-1);
            // -- UPD 2010/06/19 --------------------------------<<<

            return 0;
        }

        /// <summary>
        /// �O�񏈗����ƍX�V�������擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>�Ώۃe�[�u�����ƑO�񏈗����̃}�b�v</returns>
        public IDictionary<string, LatestPair> GetLatestHistoryMap
            (string enterpriseCode)
        {
            object objLatestList = null;
            int status = OfferMerger.GetLatestHistory(enterpriseCode, out objLatestList);
            if (!status.Equals((int)Result.RemoteStatus.Normal) || objLatestList == null)
            {
                return new Dictionary<string, LatestPair>();
            }

            ArrayList latestList = objLatestList as ArrayList;
            if (latestList == null)
            {
                return new Dictionary<string, LatestPair>();
            }
            DateTime InstallOfferDate = DateTime.MinValue;
            // -- UPD 2010/06/19 ------------------------------->>>
            //if (_iMergeDataGetter == null)
            //    _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();
            //_iMergeDataGetter.GetInstalDate(ref InstallOfferDate);

            this.getInstallDate(ref InstallOfferDate);
            // -- UPD 2010/06/19 -------------------------------<<<
            IDictionary<string, LatestPair> latestMap = new Dictionary<string, LatestPair>();
            foreach (PriUpdTblUpdHisWork history in latestList)
            {
                string tableId = ConvertSyncTableNameToTableId(history.SyncTableName);
                if (!latestMap.ContainsKey(tableId))
                {
                    // �O�񏈗���
                    int offerDate = history.OfferDate;
                    DateTime dateTime = DateTime.MinValue;

                    if (!offerDate.Equals(0))
                    {
                        dateTime = DateTime.Parse(history.OfferDate.ToString("0000/00/00"));
                    }
                    // ���߂ċN��������
                    else
                    {
                        // �D�ǥ���ʂ�ڼ޽�؂����t�擾
                        if (tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID) || tableId.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID) || tableId.Equals(ProcessConfig.GOODS_MASTER_ID))
                        {
                            dateTime = InstallOfferDate.AddMonths(-1);//GetInstallDate();
                        }
                        // ���̑���Minvalue
                        else
                        {
                            dateTime = DateTime.MinValue;
                        }
                    }

                    // �X�V����
                    int updatedCount = history.AddUpdateRowsNo;

                    latestMap.Add(tableId, new LatestPair(dateTime, updatedCount));
                    // �D�ǐݒ�ύX�}�X�^�p
                    if (tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID))
                    {
                        latestMap.Add(ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID, new LatestPair(dateTime, updatedCount));
                    }
                }
            }


            // ���i�����p
            if (!latestMap.ContainsKey(ProcessConfig.GOODS_MASTER_ID))
            {
                latestMap.Add(ProcessConfig.GOODS_MASTER_ID, new LatestPair(InstallOfferDate.AddMonths(-1) /*GetInstallDate()*/ , 0));
            }
            //if (!latestMap.ContainsKey(ProcessConfig.GOODS_PRICE_MASTER_ID))
            //{
            //    latestMap.Add(ProcessConfig.GOODS_PRICE_MASTER_ID, new LatestPair(GetInstallDate(), 0));
            //}

            //string key = string.Empty;
            //if (latestMap[ProcessConfig.GOODS_MASTER_ID].First >= latestMap[ProcessConfig.GOODS_PRICE_MASTER_ID].First)
            //{
            //    key = ProcessConfig.GOODS_MASTER_ID;
            //}
            //else
            //{
            //    key = ProcessConfig.GOODS_PRICE_MASTER_ID;
            //}
            //latestMap.Add(ProcessConfig.PRICE_REVISION_ID, new LatestPair(latestMap[key].First, latestMap[key].Second));

            return latestMap;
        }


        // ADD 2025/08/11 �c������ ----->>>>> 
        /// <summary>
        /// �X�L�b�v�Ώۓ��t���l�����ĉ��i�����X�V���������ǂ�A�X�L�b�v�Ώۓ��t�ȊO�̑O�񏈗������擾���܂��B
        /// </summary>
        public IDictionary<string, LatestPair> GetLatestHistoryMapWithSkip(string enterpriseCode)
        {
            orgDate = string.Empty;
            candDate = string.Empty;
            IDictionary<string, LatestPair> latestMap = GetLatestHistoryMap(enterpriseCode);
            Dictionary<string, LatestPair> newLatestMap = new Dictionary<string, LatestPair>(); 
            
            foreach (string key in latestMap.Keys)
            {
                string offerDateStr = latestMap[key].First.ToString("yyyyMMdd");
                // ���i�}�X�^�̑O��񋟓��t���X�L�b�v�Ώۓ��t�Ȃ�A�X�L�b�v�ΏۊO�̍ŐV���t���Ď擾����
                if (key == "GOODSURF")
                {
                    if (SkipOfferDates.Contains(offerDateStr))
                    {
                        // �X�L�b�v�ΏۂɊY�������񋟓��t��ێ�
                        orgDate = offerDateStr;
                        // �X�L�b�v�Ώۓ��ɊY�����Ȃ��ŐV�̗�����t���擾����
                        DateTime newDate = GetPreviousValidOfferDate(enterpriseCode, key, offerDateStr);
                        candDate = newDate.ToString("yyyyMMdd");
                        newLatestMap.Add(key, new LatestPair(newDate, latestMap[key].Second));
                    }
                    else
                    {
                        orgDate = offerDateStr;
                        candDate = orgDate;
                        newLatestMap[key] = latestMap[key];
                    }
                }
                else
                {
                    newLatestMap[key] = latestMap[key];
                }
            }
            return newLatestMap;
        }


        /// <summary>
        /// �X�L�b�v�ΏۊO�̓��t���o��܂ők���ė������������A�X�L�b�v���O�̓��t���擾���܂��B
        /// </summary>
        private DateTime GetPreviousValidOfferDate(string enterpriseCode, string tableId, string currentDate)
        {
            object objHistory = null;
            bool isValid = true;
            DateTime newDate = DateTime.Today.AddMonths(-2);

            while (isValid)
            {
                // �e�[�u��ID���w�肵�āA�X�L�b�v�ΏۊO�̍ŐV������t���擾����
                int status = OfferMerger.GetOtherHistories(enterpriseCode, currentDate, tableId, out objHistory);

                if (status != (int)Result.RemoteStatus.Normal || objHistory == null)
                {
                    return DateTime.Today.AddMonths(-2);//�k���������ɗL���ȃf�[�^���Ȃ��ꍇ�͌��݂�2�����O�̓��t��ݒ肷��
                }
                ArrayList DateList = objHistory as ArrayList;
                if (DateList.Count == 0) return DateTime.Today.AddMonths(-2);//�k���������ɗL���ȃf�[�^���Ȃ��ꍇ�͌��݂�2�����O�̓��t��ݒ肷��
                PriUpdTblUpdHisWork history = (PriUpdTblUpdHisWork)DateList[0];
                if (history.OfferDate == 0) return DateTime.Today.AddMonths(-2);//�L���ȃf�[�^��0�̏ꍇ�����݂�2�����O�̓��t��ݒ肷��
                string OfferDate = history.OfferDate.ToString();
                // �����̒�����X�L�b�v�Ώۃ��X�g�Ɋ܂܂�Ȃ��ŐV�f�[�^��Ԃ�
                if (!SkipOfferDates.Contains(OfferDate))
                {
                    string candOfferDate = history.OfferDate.ToString("0000/00/00");
                    return (DateTime.Parse(candOfferDate));
                }
                currentDate = OfferDate;
            }
            return DateTime.MinValue;
        }
        // ADD 2025/08/11 �c������ -----<<<<< 


        /// <summary>
        /// 
        /// </summary>
        /// <param name="syncTableName"></param>
        /// <returns></returns>
        private static string ConvertSyncTableNameToTableId(string syncTableName)
        {
            if (syncTableName.Equals("BLGROUPURF"))
            {
                return ProcessConfig.BL_GROUP_MASTER_ID;        // BL�O���[�v�}�X�^
            }
            if (syncTableName.Equals("GOODSGROUPURF"))
            {
                return ProcessConfig.MIDDLE_GENRE_MASTER_ID;    // �����ރ}�X�^
            }
            if (syncTableName.Equals("MODELNAMEURF"))
            {
                return ProcessConfig.MODEL_NAME_MASTER_ID;      // �Ԏ�}�X�^
            }
            if (syncTableName.Equals("PARTSPOSCODEURF"))
            {
                return ProcessConfig.PARTS_POS_CODE_MASTER_ID;  // ���ʃ}�X�^
            }
            if (syncTableName.Equals("BLGOODSCDURF"))
            {
                return ProcessConfig.BL_CODE_MASTER_ID;         // BL�R�[�h�}�X�^
            }
            if (syncTableName.Equals("PRMSETTINGURF"))
            {
                return ProcessConfig.PRIME_SETTING_MASTER_ID;   // �D�ǐݒ�}�X�^
            }
            //if (syncTableName.Equals("GOODSMNGURF"))
            if (syncTableName.Equals("GOODSURF"))
            {
                return ProcessConfig.GOODS_MASTER_ID;           // ���i�}�X�^
            }
            if (syncTableName.Equals("PRICEURF"))
            {
                return ProcessConfig.GOODS_PRICE_MASTER_ID;     // ���i�}�X�^
            }
            if (syncTableName.Equals("MAKERURF"))
            {
                return ProcessConfig.MAKER_MASTER_ID;           // ���[�J�[�}�X�^
            }

            return string.Empty;
        }
        // ADD 2008/02/02 �@�\�ǉ��F�Ώی��� ----------<<<<<

        /// <summary>
        /// �����}�[�W����[��]
        /// </summary>
        /// <remarks>
        /// UI����Ăяo��
        /// </remarks>
        /// <returns></returns>
        public int InitialMerge(MergeCond cond) // TODO:[�X�V]�{�^������Ăяo��
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            int offerDate = 0; // �蓮�����}�[�W�͒񋟓��t0�Ƃ���B
            status = DoMerge(offerDate, cond);
            return status;
        }

        #region [ ���� ]

        /// <summary>
        /// ���i�����E�񋟃}�[�W�������s���B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="offerDate"></param>
        /// <param name="dic"></param>
        /// <returns></returns>
        public int MergeOfferToUser(string enterpriseCode, int offerDate, IDictionary<string, LatestPair> dic)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            _autopLatestDayDic = dic;

            MergeCond cond = new MergeCond();
            cond.EnterpriseCode = enterpriseCode;
            cond.BLFlg = 1;
            cond.BLNmOwFlg = _nameOverwriteFlg;          // ���̏㏑���͉��i�����ݒ�ɏ]���B
            cond.BLGroupFlg = 1;
            cond.BLGroupNmOwFlg = _nameOverwriteFlg;     // ���̏㏑���͉��i�����ݒ�ɏ]���B
            cond.GoodsMGroupFlg = 1;
            cond.GoodsMGroupNmOwFlg = _nameOverwriteFlg; // ���̏㏑���͉��i�����ݒ�ɏ]���B
            cond.ModelNameFlg = 1;
            cond.ModelNameNmOwFlg = _nameOverwriteFlg;   // ���̏㏑���͉��i�����ݒ�ɏ]���B
            cond.PMakerFlg = 1;
            cond.PMakerNmOwFlg = _nameOverwriteFlg;      // ���̏㏑���͉��i�����ݒ�ɏ]���B
            cond.PartsPosFlg = 0; // ���ʃ}�X�^�͒񋟃f�[�^�z�M�ɂ�鎩���X�V�Ȃ�(�ΏۊO)
            cond.PartsPosNmOwFlg = _nameOverwriteFlg;    // ���̏㏑���͉��i�����ݒ�ɏ]���B            

            // ADD 2009/02/20 �s��Ή�[11764] ---------->>>>>
            // �D�ǐݒ�}�X�^�i�񋟁j
            cond.PrmSetFlg = 1;
            cond.PrmSetNmOwFlg = _nameOverwriteFlg;
            // �D�ǐݒ�ύX�}�X�^
            cond.PrmSetChgFlg = 1;
            cond.PrmSetChgNmOwFlg = _nameOverwriteFlg;
            // ���i����
            cond.PriceRevisionFlg = 1;
            cond.PriceRevisionNmOwFlg = _nameOverwriteFlg;
            // ADD 2009/02/20 �s��Ή�[11764] ----------<<<<<

            // ����
            _autoFlg = 1;

            status = DoMerge(offerDate, cond);

            //if(status != 0 && status != (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
            return status;


            //status = PriceRevision(enterpriseCode, offerDate);

            //return status;
        }

        #endregion  // [ ���� ]

        /// <summary>
        /// ���i���������擾
        /// </summary>
        /// <param name="enterpriseCd">��ƃR�[�h</param>
        /// <param name="HistStDate">�����擾�͈́u�J�n���v</param>
        /// <param name="HistEdDate">�����擾�͈́u�I�����v</param>
        /// <param name="retList">���i���������f�[�^���X�g</param>
        /// <returns></returns>
        public int GetUpdateHistory(string enterpriseCd, int HistStDate, int HistEdDate, out ArrayList retList)
        {
            int status = 0;
            retList = new ArrayList();

            PriUpdHistCondWork cond = new PriUpdHistCondWork();
            object objList;

            if (_iOfferMerger == null)
                _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();
            cond.EnterpriseCode = enterpriseCd;
            cond.StartDate = HistStDate;
            cond.EndDate = HistEdDate;
            status = _iOfferMerger.GetUpdateHistory(cond, out objList, 0, ConstantManagement.LogicalMode.GetData0);
            if (status != 0)
                return status;
            CustomSerializeArrayList List = objList as CustomSerializeArrayList;
            for (int i = 0; i < List.Count; i++)
            {
                PriUpdTblUpdHisWork histWork = List[i] as PriUpdTblUpdHisWork;
                PriUpdTblUpdHist hist = new PriUpdTblUpdHist();

                hist.CreateDateTime = histWork.CreateDateTime; // �쐬����
                hist.UpdateDateTime = histWork.UpdateDateTime; // �X�V����
                hist.EnterpriseCode = histWork.EnterpriseCode; // ��ƃR�[�h
                hist.FileHeaderGuid = histWork.FileHeaderGuid; // GUID
                hist.UpdEmployeeCode = histWork.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                hist.UpdAssemblyId1 = histWork.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                hist.UpdAssemblyId2 = histWork.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                hist.LogicalDeleteCode = histWork.LogicalDeleteCode; // �_���폜�敪
                hist.UpdateDataDiv = histWork.UpdateDataDiv; // �X�V�f�[�^�敪
                hist.DataUpdateDateTime = histWork.DataUpdateDateTime; // �f�[�^�X�V����
                hist.SyncTableID = histWork.SyncTableID; // �V���N�Ώۃe�[�u��ID
                hist.SyncTableName = histWork.SyncTableName; // �V���N�Ώۃe�[�u����
                if (histWork.AddUpdateRowsNo >= 0)
                    hist.AddUpdateRowsNo = histWork.AddUpdateRowsNo.ToString(); // �ǉ��X�V�s��
                else
                    hist.AddUpdateRowsNo = string.Format("�G���[[{0}]", histWork.AddUpdateRowsNo);
                hist.SyncExecuteDate = histWork.SyncExecuteDate; // �V���N���s���t
                hist.OfferDate = histWork.OfferDate; // �񋟓��t

                hist.OfferVersion = histWork.OfferVersion;  // ADD 2009/01/22 �@�\�ǉ��F�J�����i�񋟃o�[�W�����j�ǉ�

                retList.Add(hist);
            }

            return status;
        }

        // --- ADD 2010/05/24 ---------->>>>>
        /// <summary>
        /// ���i���������폜
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : �폜������ǉ�����</br>
        /// <br>Programmer : ��r��</br>
        /// <br>Date       : 2010/05/24</br>
        /// </remarks>
        public int DeleteHistory(ArrayList retList)
        {
            int status = 0;
            ArrayList historyList = new ArrayList();
            for (int i = 0; i < retList.Count; i++)
            {
                PriUpdTblUpdHist hist = retList[i] as PriUpdTblUpdHist;
                PriUpdTblUpdHisWork histWork = new PriUpdTblUpdHisWork();

                histWork.CreateDateTime = hist.CreateDateTime; // �쐬����
                histWork.UpdateDateTime = hist.UpdateDateTime; // �X�V����
                histWork.EnterpriseCode = hist.EnterpriseCode; // ��ƃR�[�h
                histWork.FileHeaderGuid = hist.FileHeaderGuid; // GUID
                histWork.UpdEmployeeCode = hist.UpdEmployeeCode; // �X�V�]�ƈ��R�[�h
                histWork.UpdAssemblyId1 = hist.UpdAssemblyId1; // �X�V�A�Z���u��ID1
                histWork.UpdAssemblyId2 = hist.UpdAssemblyId2; // �X�V�A�Z���u��ID2
                histWork.LogicalDeleteCode = hist.LogicalDeleteCode; // �_���폜�敪
                histWork.UpdateDataDiv = hist.UpdateDataDiv; // �X�V�f�[�^�敪
                histWork.DataUpdateDateTime = hist.DataUpdateDateTime; // �f�[�^�X�V����
                histWork.SyncTableID = hist.SyncTableID; // �V���N�Ώۃe�[�u��ID
                histWork.SyncTableName = hist.SyncTableName; // �V���N�Ώۃe�[�u����
                histWork.OfferVersion = hist.OfferVersion;  // �񋟃o�[�W����

                historyList.Add(histWork);
            }
            status = _iOfferMerger.DeleteHistory(historyList);
            return status;
        }
        // --- ADD 2010/05/24 -----------<<<<<



        /// <summary>
        /// ���i���������̍ŐV�񋟓��t�擾
        /// </summary>
        /// <param name="offerDate">�ŐV�񋟓��t</param>
        /// <returns></returns>
        public int GetLastOfferDate(out int offerDate)
        {
            if (_iOfferMerger == null)
                _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();
            return _iOfferMerger.GetLastOfferDate(out offerDate);
        }

        #endregion  // Public Methods

        #region Private Methods

        // ADD 2009/02/12 �@�\�ǉ��F���i�����������蓮�ōs�� ---------->>>>>
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="offerDate"></param>
        /// <returns></returns>
        [Obsolete("�p�~���\�b�h")]
        private int PriceRevision(string enterpriseCode, int offerDate)
        {
            PriceRevisionParameter dummy = null;
            return PriceRevision(enterpriseCode, offerDate, out dummy);
        }

        /// <summary>
        /// ���i���������p�p�����[�^�N���X
        /// </summary>
        private class PriceRevisionParameter
        {
            #region <���i�����̃}�[�W���X�g/>

            /// <summary>���i�����̃}�[�W���X�g</summary>
            private CustomSerializeArrayList _mergedPriceRevisionList;
            /// <summary>
            /// ���i�����̃}�[�W���X�g���擾���܂��B
            /// </summary>
            public CustomSerializeArrayList MergedPriceRevisionList
            {
                get
                {
                    if (_mergedPriceRevisionList == null)
                    {
                        _mergedPriceRevisionList = new CustomSerializeArrayList();
                    }
                    return _mergedPriceRevisionList;
                }
                set { _mergedPriceRevisionList = value; }
            }

            #endregion  // <���i�����̃}�[�W���X�g/>

            /// <summary>���i���������̐ݒ�</summary>
            public PriceMergeSt PriceMergeSetting;

            /// <summary>�߂�l�p���X�g</summary>
            public object RetList;

            #region <Constructor/>

            /// <summary>
            /// �J�X�^���R���X�g���N�^
            /// </summary>
            public PriceRevisionParameter(string enterpriseCode)
            {
                PriceMergeSetting = new PriceMergeSt();
                {
                    PriceMergeSetting.EnterpriseCode = enterpriseCode;
                    PriceMergeSetting.NameMergeFlg = 0;
                    PriceMergeSetting.OpenPriceFlg = 0;
                    PriceMergeSetting.PriceManage = 0;
                    PriceMergeSetting.PriceMergeFlg = 0;
                    PriceMergeSetting.GoodsRankMergeFlg = 0;
                    // 2009/12/11 Add >>>
                    PriceMergeSetting.BLGoodeCdMergeFlg = 0;
                    // 2009/12/11 Add <<<
                }
            }

            #endregion  // <Constructor/>
        }
        // ADD 2009/02/12 �@�\�ǉ��F���i�����������蓮�ōs�� ----------<<<<<

        /// <summary>
        /// ���i�����������s���B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="offerDate"></param>
        /// <param name="priceRevisionParameter"></param>
        private int PriceRevision(string enterpriseCode, int offerDate, out PriceRevisionParameter priceRevisionParameter) // ADD 2009/02/12 �@�\�ǉ��Fout PriceRevisionParameter��ǉ�
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            priceRevisionParameter = new PriceRevisionParameter(enterpriseCode);    // ADD 2009/02/12 �@�\�ǉ�

            // ADD 2025/08/11 �c������ ----->>>>>
            string offerDateStr = offerDate.ToString("00000000");
            int prevOfferDate;
            if(orgDate.Equals(string.Empty))
            {
                // �L���ȗ�����t���Ȃ��ꍇ�i���߂Ă̍X�V���j�͍X�V�Ώۂ���O���Ȃ��悤�ɂ��邽�߁A0���Z�b�g����
                prevOfferDate = 0;
            }
            else
            {
                prevOfferDate = int.Parse(orgDate);
            }
            // �O��񋟓��t���X�L�b�v�Ώۊ��ԁ@���@�X�L�b�v�ΏۂɊY�������f�[�^�͍X�V�Ώۂ���O��
            if ((prevOfferDate >= SkipOfferTermSt) && (prevOfferDate <= SkipOfferTermEd) && SkipOfferDates.Contains(offerDateStr))
            {
                return status;
            }
            // ADD 2025/08/11 �c������ -----<<<<<

            if (_iMergeDataGetter == null)
                _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();
            object retList = null;

            CustomSerializeArrayList lstOfferData;

            //if(lst == null) lst = new CustomSerializeArrayList();

            // Ұ��ؽ�(��޼ު��)
            object makerobj = null;

            // Ұ���ꗗ�擾
            status = _iMergeDataGetter.GetMakerInfo(offerDate, out makerobj);

            // ÷��۸ޏ����� (Ұ���ꗗ�擾)
            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
            writer.Write(DateTime.Now + " Ұ���ꗗ�擾 " + "�Ώ�Ұ������ " + ( makerobj as Dictionary<int, int> ).Count + "��" + "\r\n");
            writer.Flush();
            if (writer != null) writer.Close();

            // Ұ��ؽĎ擾�Ŵװ
            if (makerobj == null || ( status != 0 && status != 4 ))
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            // ����
            Dictionary<int, int> makerList = makerobj as Dictionary<int, int>;

            // ���i�����X�V�ݒ�ǂݍ���
            pricMergeSt = new PriceMergeSt();
            pricMergeSt.EnterpriseCode = enterpriseCode;                  // ��ƃR�[�h
            pricMergeSt.NameMergeFlg = _priceChgSet.NameUpdDiv;         // ���̍X�V�敪
            pricMergeSt.OpenPriceFlg = _priceChgSet.OpenPriceDiv;       // �I�[�v�����i�敪
            pricMergeSt.PriceManage = _priceChgSet.PriceMngCnt;        // ���i�Ǘ�����
            pricMergeSt.PriceMergeFlg = _priceChgSet.PriceUpdDiv;        // ���i�X�V�敪
            pricMergeSt.GoodsRankMergeFlg = _priceChgSet.PartsLayerUpdDiv;   // �w�ʍX�V�敪
            // 2009/12/11 Add >>>
            pricMergeSt.BLGoodeCdMergeFlg = _priceChgSet.BLGoodsCdUpdDiv;    // BL�R�[�h�X�V�敪
            // 2009/12/11 Add <<<

            // ���i�}�[�W�p�t���O
            // 2010/04/23 Del >>>
            //SkipFlg = false; // (private) �����[�J�[��i�Ԃ̎��ɏ������X�L�b�v����
            //FirstFlg = false; // (private) �O��ƈႤ���[�J�[�i�Ԃ̂Ƃ��ɏ����𑖂点��B
            //PriorDelflg = false; // (private) �O�񉿊i�폜�t���O
            // 2010/04/23 Del <<<
            
            // new�͍ŏ���1�񂾂�
            if (writeGoodsList == null) writeGoodsList = new ArrayList(); // ���i���X�g(�����ݗp:private)
            if (writePricesList == null) writePricesList = new ArrayList(); // ���i���X�g(�����ݗp:private)
            if (deletePriceList == null) deletePriceList = new ArrayList(); // �폜���X�g(�����ݗp:private)
            if (_isolIslandList == null) _isolIslandList = new List<IsolIslandPrc>();// �������i���X�g// ADD By chenyd 2013/05/13 For Redmine #35515
            // �������i���X�g�擾
            ReflectIsolIslandList(enterpriseCode, out _isolIslandList);// ADD By chenyd 2013/05/13 For Redmine #35515

            // Ұ��ٰ�� 
            foreach (int _makerCd in makerList.Keys)
            {
                // DEL 2014/08/21 songg �d�|��1923 ---->>>>>
                //// հ�ް���i���i�A�����X�g
                //ArrayList UsrGoodsUnitList = null;
                //// 2010/04/23 Add >>>
                //object retObj;
                //List<PrmSettingUWork> prmSettingUWorkList = null;
                //// 2010/04/23 Add <<<

                //// հ�ް�ް��擾
                //// 2010/04/23 Add >>>
                ////status = _iOfferMerger.UsrJoinPartsSearch(enterpriseCode, _makerCd, out UsrGoodsUnitList);
                //UsrGoodsUnitList = new ArrayList();
                //status = _iOfferMerger.UsrPartsSearch(enterpriseCode, "00", _makerCd, out retObj);

                //if (retObj is CustomSerializeArrayList)
                //{
                //    CustomSerializeArrayList customList = (CustomSerializeArrayList)retObj;

                //    foreach (ArrayList al in customList)
                //    {
                //        if (al.Count > 0)
                //        {
                //            if (al[0] is PrmSettingUWork)
                //            {
                //                prmSettingUWorkList = new List<PrmSettingUWork>((PrmSettingUWork[])al.ToArray(typeof(PrmSettingUWork)));
                //            }
                //            else if (al[0] is GetUsrGoodsUnitDataWork)
                //            {
                //                UsrGoodsUnitList = al;
                //            }
                //        }
                //    }
                //}
                //// 2010/04/23 Add <<<

                //// ÷��۸ޏ����� (հ�ް���i���iϽ��擾)
                //writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                //writer.Write(DateTime.Now + " հ�ް���i���i�ް��擾 " + "�Ώ�Ұ�� " + _makerCd + " �Ώی��� " + UsrGoodsUnitList.Count + "��" + "\r\n");
                //writer.Flush();
                //if (writer != null) writer.Close();

                //// հ�ް�ް�������������}�[�W���Ȃ�
                //if (UsrGoodsUnitList.Count == 0 || UsrGoodsUnitList == null) continue;
                // DEL 2014/08/21 songg �d�|��1923 ----<<<<<

                // ADD 2014/08/21 songg �d�|��1923 ---->>>>>
                ArrayList goodsNoList = new ArrayList();
                ArrayList UsrGoodsUnitList = null;
                List<PrmSettingUWork> prmSettingUWorkList = null;
                // DEL 2017/07/18 y.wakita ---->>>>>
                //// 1:�g���^�@2�F���Y�ȊO
                //if (!(_makerCd == 1 || _makerCd == 2))
                //{ 
                //    // հ�ް���i���i�A�����X�g
                //    UsrGoodsUnitList = null;
                //    object retObj;
                //    prmSettingUWorkList = null;

                //    // հ�ް�ް��擾
                //    UsrGoodsUnitList = new ArrayList();
                //    status = _iOfferMerger.UsrPartsSearch(enterpriseCode, "00", _makerCd, goodsNoList, out retObj);

                //    if (retObj is CustomSerializeArrayList)
                //    {
                //        CustomSerializeArrayList customList = (CustomSerializeArrayList)retObj;

                //        foreach (ArrayList al in customList)
                //        {
                //            if (al.Count > 0)
                //            {
                //                if (al[0] is PrmSettingUWork)
                //                {
                //                    prmSettingUWorkList = new List<PrmSettingUWork>((PrmSettingUWork[])al.ToArray(typeof(PrmSettingUWork)));
                //                }
                //                else if (al[0] is GetUsrGoodsUnitDataWork)
                //                {
                //                    UsrGoodsUnitList = al;
                //                }
                //            }
                //        }
                //    }

                //    // ÷��۸ޏ����� (հ�ް���i���iϽ��擾)
                //    writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                //    writer.Write(DateTime.Now + " հ�ް���i���i�ް��擾 " + "�Ώ�Ұ�� " + _makerCd + " �Ώی��� " + UsrGoodsUnitList.Count + "��" + "\r\n");
                //    writer.Flush();
                //    if (writer != null) writer.Close();

                //    // հ�ް�ް�������������}�[�W���Ȃ�
                //    if (UsrGoodsUnitList.Count == 0 || UsrGoodsUnitList == null) continue;
                //}
                // DEL 2017/07/18 y.wakita ----<<<<<
                // ADD 2014/08/21 songg �d�|��1923 ----<<<<<

                // �񋟗p�O��i��
                string GoodsNo = string.Empty;
                string GoodsPriceNo = string.Empty;

                // Ұ�����̑Ώی���
                int makerCnt = 0;
                // �񋟌����̎擾
                makerList.TryGetValue(_makerCd, out makerCnt);

                // 10����ٰ�߂����񂷂邩
                // 2010/06/14 >>>
                //int roupCount = makerCnt / 100000 + 1;
                int roupCount = makerCnt / 10000 + 1;
                // 2010/06/14 <<<

                // �񋟃f�[�^���10������ٰ��
                for (int i = 0; i < roupCount; i++)
                {
                    // �񋟃f�[�^�擾
                    status = _iMergeDataGetter.GetGoodsInfo(offerDate, _makerCd, GoodsNo, GoodsPriceNo, out retList);

                    if (retList != null)
                    {
                        lstOfferData = (CustomSerializeArrayList)retList;

                        // �񋟃f�[�^�擾���G���[��������A���͖��������玟�̃��[�J�[
                        if (status != 0 || lstOfferData.Count == 0)
                        {
                            continue;
                        }

                        // �񋟃��X�g(���i���i��D�Ǖ��i��D�ǉ��i)
                        ArrayList lstPtMkrPrice = null;
                        ArrayList lstPrimeParts = null;
                        ArrayList lstPrimePrice = null;

                        // �O��i�ԗp
                        GoodsNo = string.Empty;
                        GoodsPriceNo = string.Empty;

                        // ADD 2014/08/21 songg �d�|��1923 ---->>>>>
                        // ��DB����A���������i�Ԃ��A�񋟕i�ԃ��X�g�쐬
                        // DEL 2017/07/18 y.wakita ---->>>>>
                        //if (_makerCd == 1 || _makerCd == 2)
                        //{
                        // DEL 2017/07/18 y.wakita ----<<<<<
                            goodsNoList = new ArrayList();
                        // DEL 2017/07/18 y.wakita ---->>>>>
                        //}
                        // DEL 2017/07/18 y.wakita ----<<<<<
                        // ADD 2014/08/21 songg �d�|��1923 ----<<<<<

                        // ���X�g�̒��g���������D�ǂ����f & �Ō�̕i�Ԃ��ꎞ�ޔ�
                        for (int j = 0; j < lstOfferData.Count; j++)
                        {
                            switch (( (ArrayList)lstOfferData[j] )[0].GetType().Name)
                            {
                                case "PtMkrPriceWork": // ���i���i�}�X�^
                                    lstPtMkrPrice = lstOfferData[j] as ArrayList;
                                    GoodsNo = ( lstPtMkrPrice[( lstPtMkrPrice.Count - 1 )] as PtMkrPriceWork ).NewPrtsNoWithHyphen;
                                    // ADD 2014/08/21 songg �d�|��1923 ---->>>>>
                                    // DEL 2017/07/18 y.wakita ---->>>>>
                                    //if (_makerCd == 1 || _makerCd == 2)
                                    //{
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                        for (int k = 0; k < lstPtMkrPrice.Count; k++)
                                        {
                                            // ADD 2025/08/11 �c������ ----->>>>>
                                            // �񋟓��t���X�L�b�v�Ώۂ̏ꍇ�A�X�L�b�v�ΏۂɊY�����Ȃ��ŐV���t��񋟃f�[�^���t�Ƃ��Đݒ肷��
                                            if (SkipOfferDates.Contains(offerDateStr)) (lstPtMkrPrice[k] as PtMkrPriceWork).OfferDate = int.Parse(candDate);
                                            // ADD 2025/08/11 �c������ -----<<<<< 
                                            goodsNoList.Add((lstPtMkrPrice[k] as PtMkrPriceWork).NewPrtsNoWithHyphen);
                                        }
                                    // DEL 2017/07/18 y.wakita ---->>>>>
                                    //}
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                    // ADD 2014/08/21 songg �d�|��1923 ----<<<<<
                                    break;

                                case "PrimePartsWork": // �D�Ǖ��i�}�X�^
                                    lstPrimeParts = lstOfferData[j] as ArrayList;
                                    GoodsNo = ( lstPrimeParts[( lstPrimeParts.Count - 1 )] as PrimePartsWork ).PrimePartsNoWithH;
                                    // ADD 2014/08/21 songg �d�|��1923 ---->>>>>
                                    // DEL 2017/07/18 y.wakita ---->>>>>
                                    //if (_makerCd == 1 || _makerCd == 2)
                                    //{
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                        for (int k = 0; k < lstPrimeParts.Count; k++)
                                        {
                                            // ADD 2025/08/11 �c������ ----->>>>>
                                            // �񋟓��t���X�L�b�v�Ώۂ̏ꍇ�A�X�L�b�v�ΏۂɊY�����Ȃ��ŐV���t��񋟃f�[�^���t�Ƃ��Đݒ肷��
                                            if (SkipOfferDates.Contains(offerDateStr)) (lstPrimeParts[k] as PrimePartsWork).OfferDate = int.Parse(candDate);
                                            // ADD 2025/08/11 �c������ -----<<<<< 
                                            goodsNoList.Add((lstPrimeParts[k] as PrimePartsWork).PrimePartsNoWithH);
                                        }
                                    // DEL 2017/07/18 y.wakita ---->>>>>
                                    //}
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                    // ADD 2014/08/21 songg �d�|��1923 ----<<<<<
                                    break;

                                case "PrmPrtPriceWork": // �D�ǉ��i�}�X�^
                                    lstPrimePrice = lstOfferData[j] as ArrayList;
                                    GoodsPriceNo = ( lstPrimePrice[( lstPrimePrice.Count - 1 )] as PrmPrtPriceWork ).PrimePartsNoWithH;
                                    // ADD 2014/08/21 songg �d�|��1923 ---->>>>>
                                    // DEL 2017/07/18 y.wakita ---->>>>>
                                    //if (_makerCd == 1 || _makerCd == 2)
                                    //{
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                        for (int k = 0; k < lstPrimePrice.Count; k++)
                                        {
                                            // ADD 2025/08/11 �c������ ----->>>>>
                                            // �񋟓��t���X�L�b�v�Ώۂ̏ꍇ�A�X�L�b�v�ΏۂɊY�����Ȃ��ŐV���t��񋟃f�[�^���t�Ƃ��Đݒ肷��
                                            if (SkipOfferDates.Contains(offerDateStr)) (lstPrimePrice[k] as PrmPrtPriceWork).OfferDate = int.Parse(candDate);
                                            // ADD 2025/08/11 �c������ -----<<<<< 
                                            goodsNoList.Add((lstPrimePrice[k] as PrmPrtPriceWork).PrimePartsNoWithH);
                                        }
                                    // DEL 2017/07/18 y.wakita ---->>>>
                                    //}
                                    // DEL 2017/07/18 y.wakita ----<<<<<
                                    // ADD 2014/08/21 songg �d�|��1923 ----<<<<<
                                    break;
                            }
                        }

                        // ADD 2014/08/21 songg �d�|��1923 ---->>>>>
                        // DEL 2017/07/18 y.wakita ---->>>>>
                        //// 1:�g���^�@2�F���Y
                        //if (_makerCd == 1 || _makerCd == 2)
                        //{
                        // DEL 2017/07/18 y.wakita ----<<<<<
                            #region ���[�U�[DB�̏��擾
                            // հ�ް���i���i�A�����X�g
                            UsrGoodsUnitList = null;

                            object retObj;
                            prmSettingUWorkList = null;

                            // հ�ް�ް��擾
                            UsrGoodsUnitList = new ArrayList();
                            status = _iOfferMerger.UsrPartsSearch(enterpriseCode, "00", _makerCd, goodsNoList, out retObj);

                            if (retObj is CustomSerializeArrayList)
                            {
                                CustomSerializeArrayList customList = (CustomSerializeArrayList)retObj;

                                foreach (ArrayList al in customList)
                                {
                                    if (al.Count > 0)
                                    {
                                        if (al[0] is PrmSettingUWork)
                                        {
                                            prmSettingUWorkList = new List<PrmSettingUWork>((PrmSettingUWork[])al.ToArray(typeof(PrmSettingUWork)));
                                        }
                                        else if (al[0] is GetUsrGoodsUnitDataWork)
                                        {
                                            UsrGoodsUnitList = al;
                                        }
                                    }
                                }
                            }

                            // ÷��۸ޏ����� (հ�ް���i���iϽ��擾)
                            writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                            writer.Write(DateTime.Now + " հ�ް���i���i�ް��擾 " + "�Ώ�Ұ�� " + _makerCd + " �Ώی��� " + UsrGoodsUnitList.Count + "��" + "\r\n");
                            writer.Flush();
                            if (writer != null) writer.Close();
                            #endregion

                            // հ�ް�ް�������������}�[�W���Ȃ�
                            if (UsrGoodsUnitList == null || UsrGoodsUnitList.Count == 0) continue;
                        
                        // DEL 2017/07/18 y.wakita ---->>>>>
                        //}
                        // DEL 2017/07/18 y.wakita ----<<<<<
                        // ADD 2014/08/21 songg �d�|��1923 ----<<<<<

                        // ÷��۸ޏ����� (�񋟏��i���iϽ��擾)
                        string PriceSerchLogText = string.Empty;

                        if (lstPtMkrPrice != null) PriceSerchLogText += ( "�񋟓��t" + offerDate + " �Ώ�Ұ�� " + _makerCd + " �Ώی���(���i���iϽ�) " + lstPtMkrPrice.Count + "��" + "\r\n" );
                        if (lstPrimeParts != null) PriceSerchLogText += ( "�񋟓��t" + offerDate + " �Ώ�Ұ�� " + _makerCd + " �Ώی���(�D�Ǖ��iϽ�) " + lstPrimeParts.Count + "��" + "\r\n" );
                        if (lstPrimePrice != null) PriceSerchLogText += ( "�񋟓��t" + offerDate + " �Ώ�Ұ�� " + _makerCd + " �Ώی���(�D�ǉ��iϽ�) " + lstPrimePrice.Count + "��" + "\r\n" );

                        writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                        writer.Write(DateTime.Now + " �񋟏��i���i�ް��擾 \r\n" + PriceSerchLogText + "\r\n");
                        writer.Flush();
                        if (writer != null) writer.Close();

                        // ���i���i�}�X�^�����i����i�}�X�^(����)
                        if (lstPtMkrPrice != null && UsrGoodsUnitList != null)
                        {
                            // 2010/04/23 >>>
                            //CopytoPtmkPriceList(ref lstPtMkrPrice, ref UsrGoodsUnitList, pricMergeSt, ref writeGoodsList, ref writePricesList, ref deletePriceList);
                            CopytoPtmkPriceList(enterpriseCode, ref lstPtMkrPrice, ref UsrGoodsUnitList, pricMergeSt, ref writeGoodsList, ref writePricesList, ref deletePriceList);
                            // 2010/04/23 <<<
                        }
                        // �D�Ǖ��i�}�X�^�����i����i�}�X�^(�D��)
                        if (( lstPrimeParts != null || lstPrimePrice != null ) && UsrGoodsUnitList != null)
                        {
                            // 2010/04/23 >>>
                            //CopytoPrimePartsList(ref lstPrimeParts, ref lstPrimePrice, ref UsrGoodsUnitList, pricMergeSt, ref writeGoodsList, ref writePricesList, ref deletePriceList);
                            CopytoPrimePartsList(enterpriseCode, prmSettingUWorkList, ref lstPrimeParts, ref lstPrimePrice, ref UsrGoodsUnitList, pricMergeSt, ref writeGoodsList, ref writePricesList, ref deletePriceList);
                            // 2010/04/23 <<<
                        }
                    }
                    else
                    {
                        retList = new CustomSerializeArrayList();
                    }
                }
                // ÷��۸ޏ����� (�X�V���i�������X�g�쐬)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " ���i�����X�Vؽč쐬 " + "�Ώ�Ұ�� " + _makerCd + " ���iϽ��X�V���� " + writeGoodsList.Count + "�� " + "���iϽ��X�V���� " + writePricesList.Count + "��" + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();
            }

            // 2010/04/23 Del >>>
            //if (writeGoodsPriseUwork.OfferDate != DateTime.MinValue)
            //{
            //    writePricesList.Add(writeGoodsPriseUwork);
            //    if (deleteGoodsPriceUWork.EnterpriseCode != "")
            //    {
            //        deletePriceList.Add(deleteGoodsPriceUWork);
            //    }
            //    // ������폜���[�N�N���A
            //    writeGoodsPriseUwork = new GoodsPriceUWork();
            //    deleteGoodsPriceUWork = new GoodsPriceUWork();
            //}
            // 2010/04/23 Del <<<

            //lst.Add(writeGoodsList);
            //lst.Add(writePricesList);
            //lst.Add(deletePriceList);

            #region DEL PM.NS1�������W�b�N

            //int status = _iMergeDataGetter.GetGoodsInfo(offerDate, out retList);
            //lstOfferData = (CustomSerializeArrayList)retList;
            //if (status != 0)
            //{

            //    MyLogger.Write(MyLogWriter.PRICE_REVISION, "���i���擾", MyLogWriter.GetPriceRevisionMessage(status, null));  // ADD 2009/02/10 �@�\�ǉ��F���O�o��
            //    return status;
            //}
            //if (lstOfferData.Count == 0) // ���i�E���i�̍X�V�͂Ȃ������ꍇ�A�Ȃɂ������I��
            //{
            //    MyLogger.Write(MyLogWriter.PRICE_REVISION, "���i���擾", MyLogWriter.GetPriceRevisionMessage(status, new ArrayList()));   // ADD 2009/02/10 �@�\�ǉ��F���O�o��
            //    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            //}

            //ArrayList lstPtMkrPrice = null;
            //ArrayList lstPrimeParts = null;
            //ArrayList lstPrimePrice = null;

            //for (int i = 0; i < lstOfferData.Count; i++)
            //{
            //    switch (((ArrayList)lstOfferData[i])[0].GetType().Name)
            //    {
            //        case "PtMkrPriceWork":
            //            lstPtMkrPrice = lstOfferData[i] as ArrayList;          // ���i���i�}�X�^
            //            break;
            //        case "PrimePartsWork":
            //            lstPrimeParts = lstOfferData[i] as ArrayList;          // �D�Ǖ��i�}�X�^
            //            break;
            //        case "PrmPrtPriceWork":
            //            lstPrimePrice = lstOfferData[i] as ArrayList;          // �D�ǉ��i�}�X�^
            //            break;
            //    }
            //}

            //// *** �f�B�N�V���i�����\�} *** *** *** *** *** *** *** *** *** *** ***
            ////
            //// dicPriceUpdate<GoodsMakerCD,lstMaker>     [��g]
            //// ��
            //// ��lstMaker(��CashList)       [���[�J�[���̃A���C���X�g]
            //// ����lstGoods (���i�}�X�^)    [�����̏ꍇ�͕��i���i�}�X�^���擾]
            //// ����lstPrices(���i�}�X�^)    [�����̏ꍇ�͕��i���i�}�X�^���擾]
            //// ��
            //// ��lstMaker(��CashList)       [���[�J�[���̃A���C���X�g]
            //// ����lstGoods (���i�}�X�^)    [�D�ǂ̏ꍇ�͗D�Ǖ��i�}�X�^���擾]
            //// ����lstPrices(���i�}�X�^)    [�D�ǂ̏ꍇ�͗D�ǉ��i�}�X�^���擾]
            ////          : 
            ////          :                   [�ȉ����邾��]
            ////
            //// *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** *** ***

            //// 2009/02/27�@�����Ń��W�b�N
            //ArrayList lstMaker = new ArrayList();   // ���[�J�[���̃��X�g
            //ArrayList lstGoods = new ArrayList();   // �Ƃ肠�������i���X�g�@��ŕύX
            //ArrayList lstPrices = new ArrayList();�@// �Ƃ肠�������i���X�g�@��ŕύX
            //ArrayList lstDummy = new ArrayList();
            //Dictionary<int, ArrayList> dicPriceUpdate = new Dictionary<int, ArrayList>(); // ��g
            //int GoodsMakerCd = 0;

            //// ���i���i�}�X�^
            //#region
            //if (lstPtMkrPrice != null)
            //{
            //    lstGoods = new ArrayList();
            //    lstPrices = new ArrayList();
            //    lstMaker = new ArrayList();

            //    foreach (PtMkrPriceWork PtMkrPriceWork in lstPtMkrPrice)
            //    {
            //        // �ި����؂Ɋ��Ƀ��[�J�[�̃��X�g�������
            //        if (dicPriceUpdate.ContainsKey(PtMkrPriceWork.MakerCode) == true)
            //        {
            //            //���[�J�[���̃��X�g�ŉ�
            //            foreach (ArrayList CashList in dicPriceUpdate[PtMkrPriceWork.MakerCode])
            //            {
            //                // ���i�}�X�^�}�[�W
            //                if (CashList[0] is GoodsUWork)
            //                {
            //                    GoodsUWork GoodsUWork = new GoodsUWork();

            //                    GoodsUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            //                    GoodsUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            //                    GoodsUWork.GoodsNoNoneHyphen = PtMkrPriceWork.NewPrtsNoNoneHyphen;
            //                    GoodsUWork.GoodsName = PtMkrPriceWork.MakerOfferPartsName;
            //                    GoodsUWork.GoodsNameKana = PtMkrPriceWork.MakerOfferPartsKana;
            //                    GoodsUWork.GoodsRateRank = PtMkrPriceWork.PartsLayerCd;
            //                    GoodsUWork.TaxationDivCd = 0; // �O�� �Œ�l
            //                    GoodsUWork.GoodsKindCode = 0; // ���� �Œ�l
            //                    GoodsUWork.OfferDataDiv = 1;  // �񋟋敪�P�F��
            //                    GoodsUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            //                    GoodsUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            //                    CashList.Add(GoodsUWork);
            //                }
            //                // ���i�}�X�^�}�[�W
            //                else if (CashList[0] is GoodsPriceUWork)
            //                {
            //                    GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            //                    GoodsPriceUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            //                    GoodsPriceUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            //                    GoodsPriceUWork.ListPrice = PtMkrPriceWork.PartsPrice;
            //                    GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PtMkrPriceWork.PartsPriceStDate);
            //                    GoodsPriceUWork.OpenPriceDiv = PtMkrPriceWork.OpenPriceDiv;
            //                    GoodsPriceUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            //                    GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            //                    CashList.Add(GoodsPriceUWork);
            //                }
            //                // �G���[
            //                else
            //                {
            //                    return 9;
            //                }

            //            }
            //        }
            //        // �ި����؂�Ұ���̃��X�g���Ȃ����
            //        else
            //        {
            //            lstGoods = new ArrayList();
            //            lstPrices = new ArrayList();
            //            lstMaker = new ArrayList();

            //            GoodsUWork GoodsUWork = new GoodsUWork();

            //            GoodsUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            //            GoodsUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            //            GoodsUWork.GoodsNoNoneHyphen = PtMkrPriceWork.NewPrtsNoNoneHyphen;
            //            GoodsUWork.GoodsName = PtMkrPriceWork.MakerOfferPartsName;
            //            GoodsUWork.GoodsNameKana = PtMkrPriceWork.MakerOfferPartsKana;
            //            GoodsUWork.GoodsRateRank = PtMkrPriceWork.PartsLayerCd;
            //            GoodsUWork.TaxationDivCd = 0; // �O�� �Œ�l
            //            GoodsUWork.GoodsKindCode = 0; // ���� �Œ�l
            //            GoodsUWork.OfferDataDiv = 1;  // �񋟋敪�P�F��
            //            GoodsUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            //            GoodsUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            //            lstGoods.Add(GoodsUWork);

            //            GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            //            GoodsPriceUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            //            GoodsPriceUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            //            GoodsPriceUWork.ListPrice = PtMkrPriceWork.PartsPrice;
            //            GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PtMkrPriceWork.PartsPriceStDate);
            //            GoodsPriceUWork.OpenPriceDiv = PtMkrPriceWork.OpenPriceDiv;
            //            GoodsPriceUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            //            GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            //            lstPrices.Add(GoodsPriceUWork);

            //            lstMaker.Add(lstGoods);
            //            lstMaker.Add(lstPrices);

            //            dicPriceUpdate.Add(GoodsUWork.GoodsMakerCd, lstMaker);
            //        }
            //    }
            //}
            //#endregion

            ////�D�Ǖ��i�}�X�^
            //#region
            //if (lstPrimeParts != null)
            //{
            //    lstGoods = new ArrayList();
            //    lstMaker = new ArrayList();
            //    lstDummy = new ArrayList();

            //    foreach (PrimePartsWork PrimePartsWork in lstPrimeParts)
            //    {
            //        // �ި����؂Ɋ��Ƀ��[�J�[�̃��X�g�������
            //        if (dicPriceUpdate.ContainsKey(PrimePartsWork.PartsMakerCd) == true)
            //        {
            //            GoodsMakerCd = PrimePartsWork.PartsMakerCd;
            //            //���[�J�[���̃��X�g�ŉ�
            //            foreach (ArrayList CashList in dicPriceUpdate[PrimePartsWork.PartsMakerCd])
            //            {
            //                // ���i�}�X�^�}�[�W
            //                if (CashList[0] is GoodsUWork)
            //                {
            //                    // GoodsUWork������ꍇ
            //                    GoodsUWork GoodsUWork = new GoodsUWork();

            //                    GoodsUWork.GoodsMakerCd = PrimePartsWork.PartsMakerCd;
            //                    GoodsUWork.GoodsNo = PrimePartsWork.PrimePartsNoWithH;
            //                    GoodsUWork.GoodsNoNoneHyphen = PrimePartsWork.PrimePartsNoNoneH;
            //                    GoodsUWork.GoodsName = PrimePartsWork.PrimePartsName;
            //                    GoodsUWork.GoodsNameKana = PrimePartsWork.PrimePartsKanaNm;
            //                    GoodsUWork.GoodsRateRank = PrimePartsWork.PartsLayerCd;
            //                    GoodsUWork.TaxationDivCd = 0; // �O�� �Œ�l
            //                    GoodsUWork.GoodsKindCode = 1; // ���̑� �Œ�l
            //                    GoodsUWork.OfferDataDiv = 1; // �񋟋敪�P�F��
            //                    GoodsUWork.OfferDate = ConverIntToDateTime(PrimePartsWork.OfferDate);
            //                    GoodsUWork.UpdateDate = ConverIntToDateTime(PrimePartsWork.OfferDate);

            //                    lstGoods.Add(GoodsUWork);
            //                }
            //                else
            //                {
            //                    // ���[�J�[�͂��邯��GoodsUWork���Ȃ��ꍇ
            //                    //lstGoods = new ArrayList();
            //                    GoodsUWork GoodsUWork = new GoodsUWork();

            //                    GoodsUWork.GoodsMakerCd = PrimePartsWork.PartsMakerCd;
            //                    GoodsUWork.GoodsNo = PrimePartsWork.PrimePartsNoWithH;
            //                    GoodsUWork.GoodsNoNoneHyphen = PrimePartsWork.PrimePartsNoNoneH;
            //                    GoodsUWork.GoodsName = PrimePartsWork.PrimePartsName;
            //                    GoodsUWork.GoodsNameKana = PrimePartsWork.PrimePartsKanaNm;
            //                    GoodsUWork.GoodsRateRank = PrimePartsWork.PartsLayerCd;
            //                    GoodsUWork.TaxationDivCd = 0; // �O�� �Œ�l
            //                    GoodsUWork.GoodsKindCode = 1; // ���̑� �Œ�l
            //                    GoodsUWork.OfferDataDiv = 1; // �񋟋敪�P�F��
            //                    GoodsUWork.OfferDate = ConverIntToDateTime(PrimePartsWork.OfferDate);
            //                    GoodsUWork.UpdateDate = ConverIntToDateTime(PrimePartsWork.OfferDate);

            //                    lstGoods.Add(GoodsUWork);
            //                    lstDummy.Add(lstGoods);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            // ���[�J�[�Ȃ���
            //            lstGoods = new ArrayList();
            //            lstMaker = new ArrayList();

            //            GoodsUWork GoodsUWork = new GoodsUWork();

            //            GoodsUWork.GoodsMakerCd = PrimePartsWork.PartsMakerCd;
            //            GoodsUWork.GoodsNo = PrimePartsWork.PrimePartsNoWithH;
            //            GoodsUWork.GoodsNoNoneHyphen = PrimePartsWork.PrimePartsNoNoneH;
            //            GoodsUWork.GoodsName = PrimePartsWork.PrimePartsName;
            //            GoodsUWork.GoodsNameKana = PrimePartsWork.PrimePartsKanaNm;
            //            GoodsUWork.GoodsRateRank = PrimePartsWork.PartsLayerCd;
            //            GoodsUWork.TaxationDivCd = 0; // �O�� �Œ�l
            //            GoodsUWork.GoodsKindCode = 1; // ���̑� �Œ�l
            //            GoodsUWork.OfferDataDiv = 1; // �񋟋敪�P�F��
            //            GoodsUWork.OfferDate = ConverIntToDateTime(PrimePartsWork.OfferDate);
            //            GoodsUWork.UpdateDate = ConverIntToDateTime(PrimePartsWork.OfferDate);

            //            lstGoods.Add(GoodsUWork);
            //            lstMaker.Add(lstGoods);
            //            dicPriceUpdate.Add(GoodsUWork.GoodsMakerCd, lstMaker);
            //        }
            //    }
            //    if (lstMaker.Count == 0)
            //    {
            //        dicPriceUpdate[GoodsMakerCd].Add(lstGoods);
            //    }
            //}
            //#endregion

            //// �D�ǉ��i
            //#region
            //if (lstPrimePrice != null)
            //{
            //    lstPrices = new ArrayList();
            //    lstMaker = new ArrayList();

            //    foreach (PrmPrtPriceWork PrmPrtPriceWork in lstPrimePrice)
            //    {
            //        lstPrices = new ArrayList();
            //        // �ި����؂Ɋ��Ƀ��[�J�[�̃��X�g�������
            //        if (dicPriceUpdate.ContainsKey(PrmPrtPriceWork.PartsMakerCd) == true)
            //        {
            //            GoodsMakerCd = PrmPrtPriceWork.PartsMakerCd;

            //            ArrayList dictionaryList = new ArrayList();
            //            // ���[�J�[�̃��X�g�����o��
            //            dictionaryList = dicPriceUpdate[PrmPrtPriceWork.PartsMakerCd] as ArrayList;

            //            // ���i�E���i�̗��������Ă�
            //            if (dictionaryList.Count == 2)
            //            {
            //                ArrayList dic1 = dictionaryList[0] as ArrayList;
            //                ArrayList dic2 = dictionaryList[1] as ArrayList;
            //                GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            //                GoodsPriceUWork.GoodsMakerCd = PrmPrtPriceWork.PartsMakerCd;
            //                GoodsPriceUWork.GoodsNo = PrmPrtPriceWork.PrimePartsNoWithH;
            //                GoodsPriceUWork.ListPrice = PrmPrtPriceWork.NewPrice;
            //                GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PrmPrtPriceWork.PriceStartDate);
            //                GoodsPriceUWork.OpenPriceDiv = PrmPrtPriceWork.OpenPriceDiv;
            //                GoodsPriceUWork.OfferDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);
            //                GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);
            //                if (dic1[0] is GoodsPriceUWork)
            //                {
            //                    dic1.Add(GoodsPriceUWork);
            //                }
            //                else if (dic2[0] is GoodsPriceUWork)
            //                {
            //                    dic2.Add(GoodsPriceUWork);
            //                }
            //            }
            //            // �ǂ��������������Ă��Ȃ�
            //            else
            //            {
            //                ArrayList dic3 = dictionaryList[0] as ArrayList;
            //                GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            //                GoodsPriceUWork.GoodsMakerCd = PrmPrtPriceWork.PartsMakerCd;
            //                GoodsPriceUWork.GoodsNo = PrmPrtPriceWork.PrimePartsNoWithH;
            //                GoodsPriceUWork.ListPrice = PrmPrtPriceWork.NewPrice;
            //                GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PrmPrtPriceWork.PriceStartDate);
            //                GoodsPriceUWork.OpenPriceDiv = PrmPrtPriceWork.OpenPriceDiv;
            //                GoodsPriceUWork.OfferDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);
            //                GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);

            //                lstPrices.Add(GoodsPriceUWork);

            //                // ���i�}�X�^�������Ă����ꍇ�͐V�������i�}�X�^���쐬
            //                if (dic3[0] is GoodsUWork)
            //                {
            //                    dictionaryList.Add(lstPrices);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            // ���[�J�[�Ȃ���
            //            lstPrices = new ArrayList();
            //            lstMaker = new ArrayList();
            //            GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            //            GoodsPriceUWork.GoodsMakerCd = PrmPrtPriceWork.PartsMakerCd;
            //            GoodsPriceUWork.GoodsNo = PrmPrtPriceWork.PrimePartsNoWithH;
            //            GoodsPriceUWork.ListPrice = PrmPrtPriceWork.NewPrice;
            //            GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PrmPrtPriceWork.PriceStartDate);
            //            GoodsPriceUWork.OpenPriceDiv = PrmPrtPriceWork.OpenPriceDiv;
            //            GoodsPriceUWork.OfferDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);
            //            GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);

            //            lstPrices.Add(GoodsPriceUWork);
            //            lstMaker.Add(lstPrices);

            //            dicPriceUpdate.Add(GoodsPriceUWork.GoodsMakerCd, lstMaker);
            //        }
            //    }
            //}
            //#endregion

            //#region

            ////// �������W�b�N


            ////ArrayList lstGoods = new ArrayList();
            ////ArrayList lstPrices = new ArrayList();
            ////if (lstPtMkrPrice != null)
            ////{
            ////    foreach (PtMkrPriceWork PtMkrPriceWork in lstPtMkrPrice)
            ////    {
            ////        GoodsUWork GoodsUWork = new GoodsUWork();

            ////        GoodsUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            ////        GoodsUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            ////        GoodsUWork.GoodsNoNoneHyphen = PtMkrPriceWork.NewPrtsNoNoneHyphen;
            ////        GoodsUWork.GoodsName = PtMkrPriceWork.MakerOfferPartsName;
            ////        GoodsUWork.GoodsNameKana = PtMkrPriceWork.MakerOfferPartsKana;
            ////        GoodsUWork.GoodsRateRank = PtMkrPriceWork.PartsLayerCd;
            ////        GoodsUWork.TaxationDivCd = 0; // �O�� �Œ�l
            ////        GoodsUWork.GoodsKindCode = 0; // ���� �Œ�l
            ////        GoodsUWork.OfferDataDiv = 1; // �񋟋敪�P�F��
            ////        GoodsUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            ////        GoodsUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            ////        lstGoods.Add(GoodsUWork);


            ////        GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            ////        GoodsPriceUWork.GoodsMakerCd = PtMkrPriceWork.MakerCode;
            ////        GoodsPriceUWork.GoodsNo = PtMkrPriceWork.NewPrtsNoWithHyphen;
            ////        GoodsPriceUWork.ListPrice = PtMkrPriceWork.PartsPrice;
            ////        GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PtMkrPriceWork.PartsPriceStDate);
            ////        GoodsPriceUWork.OpenPriceDiv = PtMkrPriceWork.OpenPriceDiv;
            ////        GoodsPriceUWork.OfferDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);
            ////        GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PtMkrPriceWork.OfferDate);

            ////        lstPrices.Add(GoodsPriceUWork);
            ////    }
            ////}
            ////if (lstPrimeParts != null)
            ////{
            ////    foreach (PrimePartsWork PrimePartsWork in lstPrimeParts)
            ////    {
            ////        GoodsUWork GoodsUWork = new GoodsUWork();

            ////        GoodsUWork.GoodsMakerCd = PrimePartsWork.PartsMakerCd;
            ////        GoodsUWork.GoodsNo = PrimePartsWork.PrimePartsNoWithH;
            ////        GoodsUWork.GoodsNoNoneHyphen = PrimePartsWork.PrimePartsNoNoneH;
            ////        GoodsUWork.GoodsName = PrimePartsWork.PrimePartsName;
            ////        GoodsUWork.GoodsNameKana = PrimePartsWork.PrimePartsKanaNm;
            ////        GoodsUWork.GoodsRateRank = PrimePartsWork.PartsLayerCd;
            ////        GoodsUWork.TaxationDivCd = 0; // �O�� �Œ�l
            ////        GoodsUWork.GoodsKindCode = 1; // ���̑� �Œ�l
            ////        GoodsUWork.OfferDataDiv = 1; // �񋟋敪�P�F��
            ////        GoodsUWork.OfferDate = ConverIntToDateTime(PrimePartsWork.OfferDate);
            ////        GoodsUWork.UpdateDate = ConverIntToDateTime(PrimePartsWork.OfferDate);

            ////        lstGoods.Add(GoodsUWork);
            ////    }
            ////}
            ////if (lstPrimePrice != null)
            ////{
            ////    foreach (PrmPrtPriceWork PrmPrtPriceWork in lstPrimePrice)
            ////    {
            ////        GoodsPriceUWork GoodsPriceUWork = new GoodsPriceUWork();

            ////        GoodsPriceUWork.GoodsMakerCd = PrmPrtPriceWork.PartsMakerCd;
            ////        GoodsPriceUWork.GoodsNo = PrmPrtPriceWork.PrimePartsNoWithH;
            ////        GoodsPriceUWork.ListPrice = PrmPrtPriceWork.NewPrice;
            ////        GoodsPriceUWork.PriceStartDate = ConverIntToDateTime(PrmPrtPriceWork.PriceStartDate);
            ////        GoodsPriceUWork.OpenPriceDiv = PrmPrtPriceWork.OpenPriceDiv;
            ////        GoodsPriceUWork.OfferDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);
            ////        GoodsPriceUWork.UpdateDate = ConverIntToDateTime(PrmPrtPriceWork.OfferDate);

            ////        lstPrices.Add(GoodsPriceUWork);
            ////    }
            ////}


            ////lst.Add(lstGoods);
            ////lst.Add(lstPrices);
            ////lst.Add(lstClgGoods);
            ////lst.Add(lstClgPrices);

            //#endregion

            //CustomSerializeArrayList lst = new CustomSerializeArrayList();
            //lst.Add(dicPriceUpdate);

            //PriceMergeSt st = new PriceMergeSt();
            //st.EnterpriseCode = enterpriseCode;
            //st.NameMergeFlg = _priceChgSet.NameUpdDiv;
            //st.OpenPriceFlg = _priceChgSet.OpenPriceDiv;
            //st.PriceManage = _priceChgSet.PriceMngCnt;
            //st.PriceMergeFlg = _priceChgSet.PriceUpdDiv;
            //st.GoodsRankMergeFlg = _priceChgSet.PartsLayerUpdDiv;
            #endregion

            // ADD 2009/02/12 �@�\�ǉ��F���i�����������蓮�ōs�� ---------->>>>>
            //priceRevisionParameter.MergedPriceRevisionList = lst;
            //priceRevisionParameter.PriceMergeSetting = pricMergeSt;
            //priceRevisionParameter.RetList = retList;
            //CountPriceRevision(writeGoodsList, writePricesList);
            return status;  // FIXME:���i�����p�̃p�����[�^�������\�z���Ė߂�
            // ADD 2009/02/12 �@�\�ǉ��F���i�����������蓮�ōs�� ----------<<<<<

            #region [ ���� ]

            //if (_iOfferMerger == null)
            //    _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();

            //status = _iOfferMerger.DoPriceRevision(st, lst, out retList);

            //// ADD 2009/02/10 �@�\�ǉ��F���i�����������蓮�ōs�� ---------->>>>>
            //// ���i���������̍X�V�������J�E���g
            //if (status.Equals((int)Result.RemoteStatus.Normal))
            //{
            //    CountPriceRevision(lstGoods, lstPrices);
            //}
            //// ADD 2009/02/10 �@�\�ǉ��F���i�����������蓮�ōs�� ----------<<<<<

            //MyLogger.Write(MyLogWriter.PRICE_REVISION, "���i�������s", MyLogWriter.GetPriceRevisionMessage(status, lst));  // ADD 2009/02/10 �@�\�ǉ��F���O�o��

            //return status;

            #endregion  // [ ���� ]
        }

        // �D�Ǖ��i�}�X�^�i�[
        #region
        // 2010/04/23 >>>
        //private void CopytoPrimePartsList(ref ArrayList lstPrimeParts, ref ArrayList lstPrimePrice, ref ArrayList UsrGoodsUnitList, PriceMergeSt pricMergeSt, ref ArrayList writeGoodsList, ref ArrayList writePricesList, ref ArrayList deletePriceList)
        private void CopytoPrimePartsList(string enterpriseCode, List<PrmSettingUWork> prmSettingUWorkList, ref ArrayList lstPrimeParts, ref ArrayList lstPrimePrice, ref ArrayList UsrGoodsUnitList, PriceMergeSt pricMergeSt, ref ArrayList writeGoodsList, ref ArrayList writePricesList, ref ArrayList deletePriceList)
        // 2010/04/23 <<<
        {
            // 2010/04/23 Add >>>
            // ���[�U�[���i�ɍX�V�Ώۃ��X�g
            List<GetUsrGoodsUnitDataWork> prcUpdtTrgtList = new List<GetUsrGoodsUnitDataWork>();
            // 2010/04/23 Add <<<

            // (���[�U�[)���i�����f�[�^�ŉ�
            foreach (GetUsrGoodsUnitDataWork userGoodsUnitWork in UsrGoodsUnitList)
            {
                if (lstPrimeParts != null)
                {
                    // (��)�D�Ǐ��i�f�[�^�ŉ�
                    foreach (PrimePartsWork primePartsWork in lstPrimeParts)
                    {
                        // �}�[�W�ΏۂƂȂ�L�[����v���Ă�����(Ұ����i��)
                        if (userGoodsUnitWork.GoodsMakerCd == primePartsWork.PartsMakerCd && userGoodsUnitWork.GoodsNo == primePartsWork.PrimePartsNoWithH)
                        {
                            // �O��i�Ԃƈꏏ���ᖳ��������
                            if (!( userGoodsUnitWork.GoodsMakerCd == PriGoodsUWork.GoodsMakerCd && userGoodsUnitWork.GoodsNo == PriGoodsUWork.GoodsNo ))
                            {
                                GoodsUWork writeGoodsUwork = new GoodsUWork();

                                #region �L�[�i�[
                                writeGoodsUwork.CreateDateTime = userGoodsUnitWork.CreateDateTime;
                                writeGoodsUwork.BLGoodsCode = userGoodsUnitWork.BLGoodsCode;
                                writeGoodsUwork.DisplayOrder = userGoodsUnitWork.DisplayOrder;
                                writeGoodsUwork.EnterpriseGanreCode = userGoodsUnitWork.EnterpriseGanreCode;
                                writeGoodsUwork.FileHeaderGuid = userGoodsUnitWork.FileHeaderGuid;
                                writeGoodsUwork.GoodsKindCode = userGoodsUnitWork.GoodsKindCode;
                                writeGoodsUwork.GoodsName = userGoodsUnitWork.GoodsName;
                                writeGoodsUwork.GoodsNameKana = userGoodsUnitWork.GoodsNameKana;
                                writeGoodsUwork.GoodsNoNoneHyphen = userGoodsUnitWork.GoodsNoNoneHyphen;
                                writeGoodsUwork.GoodsNote1 = userGoodsUnitWork.GoodsNote1;
                                writeGoodsUwork.GoodsNote2 = userGoodsUnitWork.GoodsNote2;
                                writeGoodsUwork.GoodsRateRank = userGoodsUnitWork.GoodsRateRank;
                                writeGoodsUwork.GoodsSpecialNote = userGoodsUnitWork.GoodsSpecialNote;
                                writeGoodsUwork.Jan = userGoodsUnitWork.Jan;
                                writeGoodsUwork.LogicalDeleteCode = userGoodsUnitWork.LogicalDeleteCode;
                                writeGoodsUwork.OfferDataDiv = userGoodsUnitWork.OfferDataDiv;
                                writeGoodsUwork.OfferDate = userGoodsUnitWork.OfferDate;
                                writeGoodsUwork.TaxationDivCd = 0;
                                writeGoodsUwork.UpdAssemblyId1 = userGoodsUnitWork.UpdAssemblyId1;
                                writeGoodsUwork.UpdAssemblyId2 = userGoodsUnitWork.UpdAssemblyId2;
                                writeGoodsUwork.UpdateDate = userGoodsUnitWork.UpdateDate;
                                writeGoodsUwork.UpdateDateTime = userGoodsUnitWork.UpdateDateTime;
                                writeGoodsUwork.UpdEmployeeCode = userGoodsUnitWork.UpdEmployeeCode;
                                writeGoodsUwork.EnterpriseCode = userGoodsUnitWork.EnterpriseCode;
                                writeGoodsUwork.GoodsMakerCd = primePartsWork.PartsMakerCd;
                                writeGoodsUwork.GoodsNo = primePartsWork.PrimePartsNoWithH;
                                #endregion

                                #region �}�[�W�Ώۍ��ڊi�[
                                // [���̍X�V] [����]�̏ꍇ
                                bool updateFlg = false;
                                // 2009/12/11 >>>
                                //if (pricMergeSt.NameMergeFlg == 0)
                                if (( pricMergeSt.NameMergeFlg == 0 ) &&
                                    (( !writeGoodsUwork.GoodsName.Equals(primePartsWork.PrimePartsName) ) ||
                                     ( !writeGoodsUwork.GoodsNameKana.Equals(primePartsWork.PrimePartsKanaNm) ) 
                                    )
                                   )
                                // 2009/12/11 <<<
                                {
                                    //writeGoodsUwork.GoodsName = primePartsWork.PrimePartsName; // DEL 2012/07/02 ���� �i�����S�p�ɍX�V�����̕s��Ή�
                                    writeGoodsUwork.GoodsName = primePartsWork.PrimePartsKanaNm; // ADD 2012/07/02 ���� �i�����S�p�ɍX�V�����̕s��Ή�
                                    writeGoodsUwork.GoodsNameKana = primePartsWork.PrimePartsKanaNm;
                                    updateFlg = true;
                                }
                                // [�w�ʍX�V] [����]�̏ꍇ
                                // 2009/12/11 >>>
                                //if (pricMergeSt.GoodsRankMergeFlg == 0)

                                // ----- UPD 2012/06/26 ���� �w�ʍX�V�s��Ή� ----- >>>>>
                                //if (( pricMergeSt.GoodsRankMergeFlg == 0 ) &&
                                //    ( !writeGoodsUwork.GoodsRateRank.Equals(primePartsWork.PartsLayerCd) )
                                //    )
                                if (( pricMergeSt.GoodsRankMergeFlg == 0 
                                        && !writeGoodsUwork.GoodsRateRank.Equals(primePartsWork.PartsLayerCd) 
                                        && !string.Empty.Equals(primePartsWork.PartsLayerCd.Trim()))
                                    || (pricMergeSt.GoodsRankMergeFlg == 2
                                        && !writeGoodsUwork.GoodsRateRank.Equals(primePartsWork.PartsLayerCd))
                                   )
                                // ----- UPD 2012/06/26 ���� �w�ʍX�V�s��Ή� ----- <<<<<
                                // 2009/12/11 <<<
                                {
                                    writeGoodsUwork.GoodsRateRank = primePartsWork.PartsLayerCd;
                                    updateFlg = true;
                                }

                                // 2009/12/11 Add >>>
                                // [BL�R�[�h�X�V] [����]�̏ꍇ
                                // UPD 2013/01/31 T.Miyamoto ------------------------------>>>>>
                                //if (( pricMergeSt.BLGoodeCdMergeFlg == 0 ) &&
                                //    ( !writeGoodsUwork.BLGoodsCode.Equals(primePartsWork.TbsPartsCode) )
                                //   )
                                if (((pricMergeSt.BLGoodeCdMergeFlg == 0) &&                              //�X�V�敪��0:����i�񋟖��ݒ蕪�͍X�V���j
                                    (!writeGoodsUwork.BLGoodsCode.Equals(primePartsWork.TbsPartsCode)) && //���i.BL�R�[�h����.�����i�R�[�h
                                    (primePartsWork.TbsPartsCode != 0))                                   //��.�����i�R�[�h��0
                                 || ((pricMergeSt.BLGoodeCdMergeFlg == 2) &&                              //�X�V�敪��1:����i�������X�V�j
                                    (!writeGoodsUwork.BLGoodsCode.Equals(primePartsWork.TbsPartsCode)))   //���i.BL�R�[�h����.�����i�R�[�h
                                   )
                                // UPD 2013/01/31 T.Miyamoto ------------------------------<<<<<
                                {
                                    writeGoodsUwork.BLGoodsCode = primePartsWork.TbsPartsCode;
                                    updateFlg = true;
                                }
                                // 2009/12/11 Add <<<

                                // ���̖��͑w�ʂ̍X�V������ꍇ�@���i�����E�񋟓��t�E�X�V�N�������X�V����B
                                if (updateFlg)
                                {
                                    writeGoodsUwork.GoodsKindCode = primePartsWork.PartsAttribute;
                                    writeGoodsUwork.OfferDate = ConverIntToDateTime(primePartsWork.OfferDate);
                                    writeGoodsUwork.UpdateDate = DateTime.Now;
                                    writeGoodsUwork.OfferDataDiv = 1;

                                    // �X�V�p���X�g��Add
                                    writeGoodsList.Add(writeGoodsUwork);
                                }
                                #endregion

                                PriGoodsUWork = writeGoodsUwork;
                                break;
                            }
                        }
                    }
                }
                // 2010/04/23 >>>
                #region �폜
                //// ���i�}�X�^�}�[�W
                //if (pricMergeSt.PriceMergeFlg == 0)
                //{
                //    if (lstPrimePrice != null)
                //    {
                //        // �����O��ƈقȂ�񋟉��i��������
                //        if (!( PriorOfrGoodsPriceUWork.GoodsMakerCd == userGoodsUnitWork.GoodsMakerCd && PriorOfrGoodsPriceUWork.GoodsNo == userGoodsUnitWork.GoodsNo ) || FirstFlg == false)
                //        {
                //            // �񋟉��i���X�g����擾
                //            foreach (PrmPrtPriceWork prmPrtPriceWork in lstPrimePrice)
                //            {
                //                // �}�[�W�ΏۂƂȂ�L�[����v���Ă�����(Ұ����i��) 
                //                if (userGoodsUnitWork.GoodsMakerCd == prmPrtPriceWork.PartsMakerCd
                //                      && userGoodsUnitWork.GoodsNo == prmPrtPriceWork.PrimePartsNoWithH)
                //                {
                //                    // �V�����O��񋟃��[�N�Ɋi�[
                //                    PriorOfrGoodsPriceUWork.GoodsMakerCd = prmPrtPriceWork.PartsMakerCd;
                //                    PriorOfrGoodsPriceUWork.GoodsNo = prmPrtPriceWork.PrimePartsNoWithH;
                //                    PriorOfrGoodsPriceUWork.OfferDate = ConverIntToDateTime(prmPrtPriceWork.OfferDate);
                //                    PriorOfrGoodsPriceUWork.OpenPriceDiv = prmPrtPriceWork.OpenPriceDiv;
                //                    PriorOfrGoodsPriceUWork.ListPrice = prmPrtPriceWork.NewPrice;
                //                    PriorOfrGoodsPriceUWork.PriceStartDate = ConverIntToDateTime(prmPrtPriceWork.PriceStartDate);
                //                    PriorOfrGoodsPriceUWork.UpdateDate = ConverIntToDateTime(prmPrtPriceWork.OfferDate);

                //                    FirstFlg = true;  // ����i�Ԉ��ڃt���O��true��
                //                    SkipFlg = false; // �������i������΃X�L�b�v���Ȃ��ɕύX
                //                    PriorDelflg = true;  // �O��񋟃��[�N���폜���Ȃ��悤�ɕύX
                //                    break;
                //                }
                //            }
                //        }

                //        // �O�񉿊i���[�N��new
                //        if (PriorDelflg == false)
                //        {
                //            PriorOfrGoodsPriceUWork = new GoodsPriceUWork();
                //        }

                //        PriorDelflg = false;

                //        // �����O��ƃ��[�J�[��i�Ԃ̂ǂ��炩���Ⴆ��
                //        if (PriorGoodsPriceUWork.GoodsMakerCd != userGoodsUnitWork.GoodsMakerCd || PriorGoodsPriceUWork.GoodsNo != userGoodsUnitWork.GoodsNo)
                //        {
                //            // �f�[�^�����Ă��邩�m�F���邽�߂ɒ񋟓��t�Ŕ��f
                //            if (writeGoodsPriseUwork.OfferDate != DateTime.MinValue)
                //            {
                //                // �O�����Ă��������[�J�[�i�Ԃ��������X�g��Add
                //                writePricesList.Add(writeGoodsPriseUwork);
                //                // �O�����Ă��������[�J�[�i�Ԃ��폜���X�g��Add
                //                if (deleteGoodsPriceUWork.EnterpriseCode != "")
                //                {
                //                    deletePriceList.Add(deleteGoodsPriceUWork);
                //                    deleteGoodsPriceUWork = new GoodsPriceUWork();
                //                }
                //                // ������폜���[�N�N���A
                //                writeGoodsPriseUwork = new GoodsPriceUWork();
                //            }
                //            // �����݉\
                //            SkipFlg = false;
                //        }

                //        // �f�[�^�����Ă��邩�m�F���邽�߂ɒ񋟓��t�Ŕ��f
                //        if (PriorOfrGoodsPriceUWork.OfferDate != DateTime.MinValue)
                //        {
                //            if (SkipFlg == false)
                //            {
                //                DateTime priceStartDate = DateTime.MinValue;
                //                // Datetime�ɕϊ��@�����i�J�n��
                //                if (userGoodsUnitWork.PricePriceStartDate != 0)
                //                {
                //                    priceStartDate = DateTime.Parse(userGoodsUnitWork.PricePriceStartDate.ToString("0000/00/00"));
                //                }
                //                // հ�ް��ں��ސ����}�X�^�̉��i�ێ����������傫�����
                //                if (userGoodsUnitWork.PriceCount >= pricMergeSt.PriceManage)
                //                {
                //                    // հ�ް���i�J�n�����񋟂̉��i�J�n���ȏ�Ȃ��
                //                    if (priceStartDate > PriorOfrGoodsPriceUWork.PriceStartDate)
                //                    {
                //                    }
                //                    // հ�ް�ƒ񋟂̉��i�J�n�����ꏏ�Ȃ�
                //                    else if (priceStartDate == PriorOfrGoodsPriceUWork.PriceStartDate)
                //                    {
                //                        // �X�V�����@��ō쐬
                //                        WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                    }
                //                    // հ�ް���񋟂̉��i�J�n�����傫���ꍇ(���ق͊܂܂�Ȃ�)
                //                    else
                //                    {
                //                        // �V�K���[�N�쐬
                //                        WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                        //deleteGoodsPriceUWork = PriorOfrGoodsPriceUWork;
                //                        if (deleteGoodsPriceUWork.GoodsMakerCd != userGoodsUnitWork.PriceGoodsMakerCd && deleteGoodsPriceUWork.GoodsNo != userGoodsUnitWork.PriceGoodsNo)
                //                        {
                //                            deleteGoodsPriceUWork.EnterpriseCode = _enterpriseCode;
                //                            deleteGoodsPriceUWork.GoodsMakerCd = userGoodsUnitWork.PriceGoodsMakerCd;
                //                            deleteGoodsPriceUWork.GoodsNo = userGoodsUnitWork.PriceGoodsNo;
                //                            deleteGoodsPriceUWork.PriceStartDate = DateTime.Parse(( userGoodsUnitWork.PricePriceStartDate ).ToString("0000/00/00"));
                //                        }
                //                    }
                //                    SkipFlg = true; continue;
                //                }
                //                // հ�ް��ں��ސ����}�X�^�̉��i�ێ�������菬�������
                //                else
                //                {
                //                    // հ�ް�ƒ񋟂̉��i�J�n�����ꏏ�Ȃ�
                //                    if (priceStartDate == PriorOfrGoodsPriceUWork.PriceStartDate)
                //                    {
                //                        // �X�V�����@��ō쐬
                //                        WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                    }
                //                    else
                //                    {
                //                        // �V�K���[�N�쐬
                //                        WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);

                //                    }
                //                    SkipFlg = true; continue;
                //                }
                //            }
                //        }
                //    }
                //}
                #endregion

                if (pricMergeSt.PriceMergeFlg == 0)
                {
                    // �D�ǉ��i���X�g�������ꍇ�͖������ǉ�
                    if (prcUpdtTrgtList.Count == 0)
                    {
                        prcUpdtTrgtList.Add(userGoodsUnitWork);
                    }
                    else
                    {
                        // ���i���ς�����^�C�~���O�ŉ��i�������X�g�̐���
                        if (!( userGoodsUnitWork.GoodsNo.Trim().Equals(prcUpdtTrgtList[0].GoodsNo.Trim()) &&
                               userGoodsUnitWork.GoodsMakerCd.Equals(prcUpdtTrgtList[0].GoodsMakerCd) ))
                        {
                            List<GoodsPriceUWork> addList;
                            List<GoodsPriceUWork> deleteList;
                            this.CreatePrimePartsPriceUpdateDataList(enterpriseCode, prcUpdtTrgtList[0].GoodsNo.Trim(), prcUpdtTrgtList[0].GoodsMakerCd, pricMergeSt, prcUpdtTrgtList, lstPrimePrice, prmSettingUWorkList, out addList, out deleteList);
                            if (addList.Count > 0) writePricesList.AddRange(addList.ToArray());
                            if (deleteList.Count > 0) deletePriceList.AddRange(deleteList.ToArray());

                            prcUpdtTrgtList.Clear();
                        }
                        prcUpdtTrgtList.Add(userGoodsUnitWork);
                    }
                }
                // 2010/04/23 <<<
            }
            // 2010/04/23 Add >>>
            if (pricMergeSt.PriceMergeFlg == 0 && prcUpdtTrgtList.Count > 0)
            {
                // �����ŉ��i��������
                List<GoodsPriceUWork> addList;
                List<GoodsPriceUWork> deleteList;
                this.CreatePrimePartsPriceUpdateDataList(enterpriseCode, prcUpdtTrgtList[0].GoodsNo.Trim(), prcUpdtTrgtList[0].GoodsMakerCd, pricMergeSt, prcUpdtTrgtList, lstPrimePrice, prmSettingUWorkList, out addList, out deleteList);
                if (addList.Count > 0) writePricesList.AddRange(addList.ToArray());
                if (deleteList.Count > 0) deletePriceList.AddRange(deleteList.ToArray());
            }
            // 2010/04/23 Add <<<
        }
        #endregion

        // 2010/04/23 Add >>>
        #region ���i�}�X�^�̍X�V����

        /// <summary>
        /// ���i�������X�g�̐���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="makerCd">���[�J�[�R�[�h</param>
        /// <param name="priceMergeSt">�񋟃f�[�^�X�V�ݒ�}�X�^</param>
        /// <param name="prcUpdtTrgtList">�������i�}�X�^���X�g</param>
        /// <param name="lstPrimePrice">�D�Ǖ��i���i���X�g</param>
        /// <param name="addList">�ǉ��X�V�Ώۃ��X�g</param>
        /// <param name="deleteList">�폜�Ώۃ��X�g</param>
        private void CreatePrimePartsPriceUpdateDataList(string enterpriseCode, string goodsNo, int makerCd, PriceMergeSt priceMergeSt, List<GetUsrGoodsUnitDataWork> prcUpdtTrgtList, ArrayList lstPrimePrice, List<PrmSettingUWork> prmSettingUWorkList, out List<GoodsPriceUWork> addList, out List<GoodsPriceUWork> deleteList)
        {
            addList = new List<GoodsPriceUWork>();
            deleteList = new List<GoodsPriceUWork>();

            if (lstPrimePrice == null || lstPrimePrice.Count == 0) return;

            // �񋟁E���[�U�[���}�[�W�������X�g
            SortedDictionary<int, object> prcList = new SortedDictionary<int, object>();
            // ���[�U�[�ɓ��ꉿ�i�J�n�������镪�̒񋟃��X�g
            Dictionary<int, PrmPrtPriceWork> duplicateList = new Dictionary<int, PrmPrtPriceWork>();

            // ���[�U�[���i�}�X�^���烊�X�g�ǉ�
            foreach (GetUsrGoodsUnitDataWork data in prcUpdtTrgtList)
            {
                if (data.PricePriceStartDate == 0) continue;

                if (!prcList.ContainsKey(data.PricePriceStartDate))
                {
                    prcList.Add(data.PricePriceStartDate, data);
                }
            }

            bool ofrDtExists = false;
            // �񋟗D�ǉ��i�}�X�^���烊�X�g�ǉ�
            foreach (PrmPrtPriceWork prmPrtPriceWork in lstPrimePrice)
            {
                // ���̃��X�g�͕i�ԏ��Ƀ\�[�g����Ă���̂ŁA�i�Ԃ��Ώەi�Ԃ��傫���Ȃ�����Break
                if (prmPrtPriceWork.PrimePartsNoWithH.CompareTo(goodsNo) > 0) break;

                // �}�[�W�ΏۂƂȂ�L�[����v���Ă�����(Ұ����i��) 
                if (makerCd == prmPrtPriceWork.PartsMakerCd
                    && goodsNo == prmPrtPriceWork.PrimePartsNoWithH)
                {
                    // �Z���N�g�R�[�h������ꍇ�͊Y�����i���`�F�b�N����
                    if (prmPrtPriceWork.PrmSetDtlNo1 != 0)
                    {
                        if (prmSettingUWorkList == null) continue;

                        PrmSettingUWork prmSettingWork = prmSettingUWorkList.Find(
                            delegate(PrmSettingUWork target)
                            {
                                if (target.PartsMakerCd == prmPrtPriceWork.PartsMakerCd &&
                                    target.GoodsMGroup == prmPrtPriceWork.GoodsMGroup &&
                                    target.TbsPartsCode == prmPrtPriceWork.TbsPartsCode &&
                                    target.PrmSetDtlNo1 == prmPrtPriceWork.PrmSetDtlNo1

                                   ) return true;

                                return false;
                            });

                        if (prmSettingWork == null) continue;
                    }
                    // ���Ƀ��[�U�[�ɓ��ꉿ�i�J�n��������ꍇ�͏d�����X�g�Ɉڍs
                    if (prcList.ContainsKey(prmPrtPriceWork.PriceStartDate))
                    {
                        duplicateList.Add(prmPrtPriceWork.PriceStartDate, prmPrtPriceWork);
                    }
                    else
                    {
                        prcList.Add(prmPrtPriceWork.PriceStartDate, prmPrtPriceWork);
                    }
                    ofrDtExists = true;
                }
            }

            if (!ofrDtExists) return;

            // ���̎��_�ŁAprcList�ɁA���[�U�[+�񋟂̃��X�g�i�񋟂̏d�����������j�AduplicateList�ɏd�������񋟂̃��X�g�������Ă���

            // �Â������猩�Ă���
            List<GoodsPriceUWork> allList = new List<GoodsPriceUWork>();    �@// ���[�U�[�f�[�^�̍ŐV���i���i���Łj
            GetUsrGoodsUnitDataWork usrGoods = new GetUsrGoodsUnitDataWork(); // ���[�U�[���i

            foreach (int prcStDate in prcList.Keys)
            {
                // ���[�U�[���i
                if (prcList[prcStDate] is GetUsrGoodsUnitDataWork)
                {
                    usrGoods = (GetUsrGoodsUnitDataWork)prcList[prcStDate];
                    GoodsPriceUWork writeWork = new GoodsPriceUWork();
                    writeWork.CreateDateTime = usrGoods.PriceCreateDateTime;
                    writeWork.UpdateDateTime = usrGoods.PriceUpdateDateTime;
                    writeWork.EnterpriseCode = usrGoods.PriceEnterpriseCode;
                    writeWork.FileHeaderGuid = usrGoods.PriceFileHeaderGuid;
                    writeWork.UpdEmployeeCode = usrGoods.PriceUpdEmployeeCode;
                    writeWork.UpdAssemblyId1 = usrGoods.PriceUpdAssemblyId1;
                    writeWork.UpdAssemblyId2 = usrGoods.PriceUpdAssemblyId2;
                    writeWork.LogicalDeleteCode = usrGoods.PriceLogicalDeleteCode;

                    writeWork.GoodsMakerCd = usrGoods.GoodsMakerCd;
                    writeWork.GoodsNo = usrGoods.GoodsNo;
                    writeWork.PriceStartDate = DateTime.Parse(( usrGoods.PricePriceStartDate ).ToString("0000/00/00"));
                    writeWork.SalesUnitCost = usrGoods.PriceSalesUnitCost;
                    writeWork.StockRate = usrGoods.PriceStockRate;
                    writeWork.ListPrice = usrGoods.PriceListPrice;

                    // �񋟃f�[�^���������ꍇ
                    if (duplicateList.ContainsKey(prcStDate))
                    {
                        PrmPrtPriceWork ofrData = duplicateList[prcStDate];

                        writeWork.UpdateDate = DateTime.Now;                                                // �X�V���t
                        writeWork.OfferDate = DateTime.Parse(( ofrData.OfferDate ).ToString("0000/00/00")); // �񋟓��t
                        writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;                                      // �I�[�v�����i�敪

                        // �V�����艿���[���̏ꍇ
                        if (ofrData.NewPrice == 0)
                        {
                            // �񋟃f�[�^�X�V�ݒ�}�X�^�̃I�[�v�����i�敪���Q�Ƃ��ăZ�b�g
                            if (priceMergeSt.OpenPriceFlg == 0)
                            {
                                writeWork.ListPrice = usrGoods.PriceListPrice;  // ���̃��[�U�[���i�����p��
                            }
                            else
                            {
                                writeWork.ListPrice = 0;         // �艿�O
                            }
                        }
                        else
                        {
                            writeWork.ListPrice = ofrData.NewPrice;
                        }
                        //------------ ADD By chenyd 2013/05/13 For Redmine #35515------------------------------->>>>>
                        double listPrice = writeWork.ListPrice;
                        this.ReflectIsolIslandCall(writeWork.GoodsMakerCd, ref listPrice);
                        writeWork.ListPrice = listPrice;
                        //------------ ADD By chenyd 2013/05/13 For Redmine #35515-------------------------------<<<<<

                        // �񋟃f�[�^���������ꍇ�̂݉��i�������X�g�ւ̒ǉ�
                        addList.Add(writeWork);
                    }
                    allList.Add(writeWork);
                }
                else if (prcList[prcStDate] is PrmPrtPriceWork)
                {
                    PrmPrtPriceWork ofrData = (PrmPrtPriceWork)prcList[prcStDate];

                    GoodsPriceUWork writeWork = new GoodsPriceUWork();
                    writeWork.EnterpriseCode = enterpriseCode;              // ��ƃR�[�h
                    writeWork.PriceStartDate = DateTime.Parse(( ofrData.PriceStartDate ).ToString("0000/00/00"));       // ���i�J�n��
                    writeWork.GoodsMakerCd = makerCd;                       // ���[�J�[
                    writeWork.GoodsNo = goodsNo;                            // �i��
                    writeWork.UpdateDate = DateTime.Now;                    // �X�V�N����

                    // ���[�U�[���i�}�X�^�̓��e�����p��(�񋟂���ԌÂ��ꍇ�͓���Ȃ�)
                    writeWork.SalesUnitCost = usrGoods.PriceSalesUnitCost;  // �����P��
                    writeWork.StockRate = usrGoods.PriceStockRate;          // �d����

                    writeWork.OfferDate = DateTime.Parse(( ofrData.OfferDate ).ToString("0000/00/00")); // �񋟓��t
                    writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;          // �I�[�v�����i�敪
                    writeWork.ListPrice = ofrData.NewPrice;                // �艿

                    // �񋟂̕W�����i���[���̏ꍇ
                    if (ofrData.NewPrice == 0)
                    {
                        // �񋟃f�[�^�X�V�ݒ�}�X�^�̃I�[�v�����i�敪���Q�Ƃ��ăZ�b�g
                        if (priceMergeSt.OpenPriceFlg == 0)
                        {
                            if (allList.Count > 0)
                            {
                                writeWork.ListPrice = allList[allList.Count - 1].ListPrice;   // 1�O�̒艿���Z�b�g
                            }
                        }
                    }
                    //------------ ADD By chenyd 2013/05/13 For Redmine #35515------------------------------->>>>>
                    double listPrice = writeWork.ListPrice;
                    this.ReflectIsolIslandCall(writeWork.GoodsMakerCd, ref listPrice);
                    writeWork.ListPrice = listPrice;
                    //------------ ADD By chenyd 2013/05/13 For Redmine #35515-------------------------------<<<<<

                    // ���i�������X�g�ɒǉ�
                    allList.Add(writeWork);

                    // �S�����X�g�ɒǉ�
                    addList.Add(writeWork);
                }
            }

            // �Ǘ������𒴂��Ă���ꍇ�A�Â��f�[�^�������
            if (allList.Count > pricMergeSt.PriceManage)
            {
                // �폜���錏��
                int delCnt = allList.Count - pricMergeSt.PriceManage;

                for (int cnt = 0; cnt < delCnt; cnt++)
                {
                    GoodsPriceUWork data = allList[0];

                    // �쐬�����������Ă���ꍇ�́A���[�U�[�o�^����Ă������Ȃ̂ŁA�폜���X�g�ɒǉ�
                    if (data.CreateDateTime != DateTime.MinValue)
                    {
                        deleteList.Add(data);
                    }

                    // �ǉ��E�X�V�f�[�^�Ɋ܂܂��ꍇ�̓��X�g����폜
                    if (addList.Contains(data)) addList.Remove(data);

                    // �擪�f�[�^������
                    allList.RemoveAt(0);
                }
            }
        }
        #endregion
        // 2010/04/23 Add <<<

        // ���i���i�}�X�^�i�[
        #region
        // 2010/04/23 >>>
        //private void CopytoPtmkPriceList(ref ArrayList lstPtMkrPrice, ref ArrayList UsrGoodsUnitList, PriceMergeSt pricMergeSt, ref ArrayList writeGoodsList, ref ArrayList writePricesList, ref ArrayList deletePriceList)
        private void CopytoPtmkPriceList(string enterpriseCode, ref ArrayList lstPtMkrPrice, ref ArrayList UsrGoodsUnitList, PriceMergeSt pricMergeSt, ref ArrayList writeGoodsList, ref ArrayList writePricesList, ref ArrayList deletePriceList)
        // 2010/04/23 <<<
        {
            // 2010/04/23 Add >>>
            // ���[�U�[���i�ɍX�V�Ώۃ��X�g
            List<GetUsrGoodsUnitDataWork> prcUpdtTrgtList = new List<GetUsrGoodsUnitDataWork>();
            List<PtMkrPriceWork> ptMkrPriceWorkList = new List<PtMkrPriceWork>();
            GetUsrGoodsUnitDataWork beforeGetUsrGoodsUnitDataWork = new GetUsrGoodsUnitDataWork();
            bool purePartsInfoChanged = false;
            // 2010/04/23 Add <<<

            // (���[�U�[)���i�����f�[�^�ŉ�
            foreach (GetUsrGoodsUnitDataWork userGoodsUnitWork in UsrGoodsUnitList)
            {
                // 2010/04/23 Add >>>
                purePartsInfoChanged = ( !( beforeGetUsrGoodsUnitDataWork.GoodsNo.Equals(userGoodsUnitWork.GoodsNo) && beforeGetUsrGoodsUnitDataWork.GoodsMakerCd.Equals(userGoodsUnitWork.GoodsMakerCd) ) );

                // ���i���ς���āA���i�X�V�L��
                if (purePartsInfoChanged && pricMergeSt.PriceMergeFlg == 0 && prcUpdtTrgtList.Count > 0)
                {
                    // �����ŉ��i��������
                    List<GoodsPriceUWork> addList;
                    List<GoodsPriceUWork> deleteList;
                    this.CreatePurePartsPriceUpdateDataList(enterpriseCode, beforeGetUsrGoodsUnitDataWork.GoodsNo, beforeGetUsrGoodsUnitDataWork.GoodsMakerCd, pricMergeSt, prcUpdtTrgtList, ptMkrPriceWorkList, out addList, out deleteList);
                    if (addList.Count > 0) writePricesList.AddRange(addList.ToArray());
                    if (deleteList.Count > 0) deletePriceList.AddRange(deleteList.ToArray());

                    ptMkrPriceWorkList.Clear();
                    prcUpdtTrgtList.Clear();
                }
                prcUpdtTrgtList.Add(userGoodsUnitWork);

                beforeGetUsrGoodsUnitDataWork = userGoodsUnitWork;
                // 2010/04/23 Add <<<
                // (��)���i�f�[�^�ŉ�
                foreach (PtMkrPriceWork ptMkrPriceWork in lstPtMkrPrice)
                {
                    // �}�[�W�ΏۂƂȂ�L�[����v���Ă�����(Ұ����i��) 
                    if (userGoodsUnitWork.GoodsMakerCd == ptMkrPriceWork.MakerCode && userGoodsUnitWork.GoodsNo == ptMkrPriceWork.NewPrtsNoWithHyphen)
                    {
                        // 2010/04/23 Add >>>
                        // �i�ԁA���[�J�[���ς�����畔�i���i���X�g��ǉ�����
                        if (purePartsInfoChanged) ptMkrPriceWorkList.Add(ptMkrPriceWork);
                        // 2010/04/23 Add <<<
                            
                        // *** *** *** *** *** *** ���i�}�X�^ �}�[�W *** *** *** *** *** *** *** *** ***

                        // �O��i�Ԃƈꏏ���ᖳ��������
                        if (!( userGoodsUnitWork.GoodsMakerCd == PriGoodsUWork.GoodsMakerCd && userGoodsUnitWork.GoodsNo == PriGoodsUWork.GoodsNo ))
                        {
                            GoodsUWork writeGoodsUwork = new GoodsUWork();

                            #region �L�[�i�[
                            writeGoodsUwork.CreateDateTime = userGoodsUnitWork.CreateDateTime;
                            writeGoodsUwork.BLGoodsCode = userGoodsUnitWork.BLGoodsCode;
                            writeGoodsUwork.DisplayOrder = userGoodsUnitWork.DisplayOrder;
                            writeGoodsUwork.EnterpriseGanreCode = userGoodsUnitWork.EnterpriseGanreCode;
                            writeGoodsUwork.FileHeaderGuid = userGoodsUnitWork.FileHeaderGuid;
                            writeGoodsUwork.GoodsKindCode = userGoodsUnitWork.GoodsKindCode;
                            writeGoodsUwork.GoodsName = userGoodsUnitWork.GoodsName;
                            writeGoodsUwork.GoodsNameKana = userGoodsUnitWork.GoodsNameKana;
                            writeGoodsUwork.GoodsNoNoneHyphen = userGoodsUnitWork.GoodsNoNoneHyphen;
                            writeGoodsUwork.GoodsNote1 = userGoodsUnitWork.GoodsNote1;
                            writeGoodsUwork.GoodsNote2 = userGoodsUnitWork.GoodsNote2;
                            writeGoodsUwork.GoodsRateRank = userGoodsUnitWork.GoodsRateRank;
                            writeGoodsUwork.GoodsSpecialNote = userGoodsUnitWork.GoodsSpecialNote;
                            writeGoodsUwork.Jan = userGoodsUnitWork.Jan;
                            writeGoodsUwork.LogicalDeleteCode = userGoodsUnitWork.LogicalDeleteCode;
                            writeGoodsUwork.OfferDataDiv = userGoodsUnitWork.OfferDataDiv;
                            writeGoodsUwork.OfferDate = userGoodsUnitWork.OfferDate;
                            writeGoodsUwork.TaxationDivCd = 0;
                            writeGoodsUwork.UpdAssemblyId1 = userGoodsUnitWork.UpdAssemblyId1;
                            writeGoodsUwork.UpdAssemblyId2 = userGoodsUnitWork.UpdAssemblyId2;
                            writeGoodsUwork.UpdateDate = userGoodsUnitWork.UpdateDate;
                            writeGoodsUwork.UpdateDateTime = userGoodsUnitWork.UpdateDateTime;
                            writeGoodsUwork.UpdEmployeeCode = userGoodsUnitWork.UpdEmployeeCode;
                            writeGoodsUwork.EnterpriseCode = userGoodsUnitWork.EnterpriseCode;
                            writeGoodsUwork.GoodsMakerCd = ptMkrPriceWork.MakerCode;
                            writeGoodsUwork.GoodsNo = ptMkrPriceWork.NewPrtsNoWithHyphen;
                            #endregion

                            #region �}�[�W�Ώۍ��ڊi�[
                            // [���̍X�V] [����]�̏ꍇ
                            bool updateFlg = false;
                            // 2009/12/11 >>>
                            //if (pricMergeSt.NameMergeFlg == 0)
                            if ((pricMergeSt.NameMergeFlg == 0) &&
                                ( ( !writeGoodsUwork.GoodsName.Equals(ptMkrPriceWork.MakerOfferPartsName) ) ||
                                  ( !writeGoodsUwork.GoodsNameKana.Equals(ptMkrPriceWork.MakerOfferPartsKana) )
                                )
                               )
                            // 2009/12/11 <<<
                            {
                                //writeGoodsUwork.GoodsName = ptMkrPriceWork.MakerOfferPartsName; // DEL 2012/07/02 ���� �i�����S�p�ɍX�V�����̕s��Ή�
                                writeGoodsUwork.GoodsName = ptMkrPriceWork.MakerOfferPartsKana; // ADD 2012/07/02 ���� �i�����S�p�ɍX�V�����̕s��Ή�
                                writeGoodsUwork.GoodsNameKana = ptMkrPriceWork.MakerOfferPartsKana;
                                updateFlg = true;
                            }
                            // [�w�ʍX�V] [����]�̏ꍇ
                            // 2009/12/11 >>>
                            //if (pricMergeSt.GoodsRankMergeFlg == 0)

                            // ----- UPD 2012/06/26 ���� �w�ʍX�V�s��Ή� ----- >>>>>
                            //if ((pricMergeSt.GoodsRankMergeFlg == 0) &&
                            //    (!writeGoodsUwork.GoodsRateRank.Equals(ptMkrPriceWork.PartsLayerCd))
                            //   )
                            if ((pricMergeSt.GoodsRankMergeFlg == 0
                                    && !writeGoodsUwork.GoodsRateRank.Equals(ptMkrPriceWork.PartsLayerCd)
                                    && !string.Empty.Equals(ptMkrPriceWork.PartsLayerCd.Trim()))
                                || (pricMergeSt.GoodsRankMergeFlg == 2
                                    && !writeGoodsUwork.GoodsRateRank.Equals(ptMkrPriceWork.PartsLayerCd))
                               )
                            // ----- UPD 2012/06/26 ���� �w�ʍX�V�s��Ή� ----- <<<<<

                            // 2009/12/11 <<<
                            {
                                writeGoodsUwork.GoodsRateRank = ptMkrPriceWork.PartsLayerCd;
                                updateFlg = true;
                            }
                            // 2009/12/11 Add >>>
                            // [BL�R�[�h�X�V] [����]�̏ꍇ
                            // UPD 2013/01/31 T.Miyamoto ------------------------------>>>>>
                            ////if (pricMergeSt.BLGoodeCdMergeFlg == 0)
                            //if (( pricMergeSt.BLGoodeCdMergeFlg == 0 ) &&
                            //    ( !writeGoodsUwork.BLGoodsCode.Equals(ptMkrPriceWork.TbsPartsCode) )
                            //   )
                            if (((pricMergeSt.BLGoodeCdMergeFlg == 0) &&                               //�X�V�敪��0:����i�񋟖��ݒ蕪�͍X�V���j
                                 (!writeGoodsUwork.BLGoodsCode.Equals(ptMkrPriceWork.TbsPartsCode)) && //���i.BL�R�[�h����.�����i�R�[�h
                                 (ptMkrPriceWork.TbsPartsCode != 0))                                   //��.�����i�R�[�h��0
                             || ((pricMergeSt.BLGoodeCdMergeFlg == 2) &&                               //�X�V�敪��2:����i�������X�V�j
                                 (!writeGoodsUwork.BLGoodsCode.Equals(ptMkrPriceWork.TbsPartsCode)))   //���i.BL�R�[�h����.�����i�R�[�h
                               )
                            // UPD 2013/01/31 T.Miyamoto ------------------------------<<<<<
                            {
                                writeGoodsUwork.BLGoodsCode = ptMkrPriceWork.TbsPartsCode;
                                updateFlg = true;
                            }
                            // 2009/12/11 Add <<<
                            // ���̖��͑w�ʂ̍X�V������ꍇ�@���i�����E�񋟓��t�E�X�V�N�������X�V����B
                            if (updateFlg)
                            {
                                writeGoodsUwork.GoodsKindCode = 0;
                                writeGoodsUwork.OfferDate = ConverIntToDateTime(ptMkrPriceWork.OfferDate);
                                writeGoodsUwork.UpdateDate = DateTime.Now;
                                writeGoodsUwork.OfferDataDiv = 1;

                                // �X�V�p���X�g��Add
                                writeGoodsList.Add(writeGoodsUwork);
                            }
                            #endregion

                            PriGoodsUWork = writeGoodsUwork;
                            //break;
                        }

                        // *** *** *** *** *** *** ���i�}�X�^ �}�[�W *** *** *** *** *** *** *** *** ***
                        #region �폜
                        //// ���i�X�V�t���O��0:���邾������ 
                        //if (pricMergeSt.PriceMergeFlg == 0)
                        //{
                        //    // �����O��ƈقȂ�񋟉��i��������
                        //    if (!( PriorOfrGoodsPriceUWork.GoodsMakerCd == userGoodsUnitWork.GoodsMakerCd && PriorOfrGoodsPriceUWork.GoodsNo == userGoodsUnitWork.GoodsNo ) || FirstFlg == false)
                        //    {
                        //        // �}�[�W�ΏۂƂȂ�L�[����v���Ă�����(Ұ����i��) 
                        //        if (userGoodsUnitWork.GoodsMakerCd == ptMkrPriceWork.MakerCode
                        //              && userGoodsUnitWork.GoodsNo == ptMkrPriceWork.NewPrtsNoWithHyphen)
                        //        {
                        //            // �V�����O��񋟃��[�N�Ɋi�[
                        //            PriorOfrGoodsPriceUWork.GoodsMakerCd = ptMkrPriceWork.MakerCode;
                        //            PriorOfrGoodsPriceUWork.GoodsNo = ptMkrPriceWork.NewPrtsNoWithHyphen;
                        //            PriorOfrGoodsPriceUWork.OfferDate = ConverIntToDateTime(ptMkrPriceWork.OfferDate);
                        //            PriorOfrGoodsPriceUWork.OpenPriceDiv = ptMkrPriceWork.OpenPriceDiv;
                        //            PriorOfrGoodsPriceUWork.ListPrice = ptMkrPriceWork.PartsPrice;
                        //            PriorOfrGoodsPriceUWork.PriceStartDate = ConverIntToDateTime(ptMkrPriceWork.PartsPriceStDate);
                        //            PriorOfrGoodsPriceUWork.UpdateDate = ConverIntToDateTime(ptMkrPriceWork.OfferDate);

                        //            FirstFlg = true;  // ����i�Ԉ��ڃt���O��true��
                        //            SkipFlg = false; // �������i������΃X�L�b�v���Ȃ��ɕύX
                        //            PriorDelflg = true;  // �O��񋟃��[�N���폜���Ȃ��悤�ɕύX
                        //            break;
                        //        }
                        //    }
                        //}
                        #endregion  // �폜
                    }
                } // ��foreach

                // 2010/04/23 Del >>>
                #region �폜
                //// �O�񉿊i���[�N��new
                //if (PriorDelflg == false)
                //{
                //    PriorOfrGoodsPriceUWork = new GoodsPriceUWork();
                //}

                //PriorDelflg = false;

                //// �����O��ƃ��[�J�[��i�Ԃ̂ǂ��炩���Ⴆ��
                //if (PriorGoodsPriceUWork.GoodsMakerCd != userGoodsUnitWork.GoodsMakerCd || PriorGoodsPriceUWork.GoodsNo != userGoodsUnitWork.GoodsNo)
                //{
                //    // �f�[�^�����Ă��邩�m�F���邽�߂ɒ񋟓��t�Ŕ��f
                //    if (writeGoodsPriseUwork.OfferDate != DateTime.MinValue)
                //    {
                //        // �O�����Ă��������[�J�[�i�Ԃ��������X�g��Add
                //        writePricesList.Add(writeGoodsPriseUwork);
                //        // �O�����Ă��������[�J�[�i�Ԃ��폜���X�g��Add
                //        if (deleteGoodsPriceUWork.EnterpriseCode != "")
                //        {
                //            deletePriceList.Add(deleteGoodsPriceUWork);
                //            deleteGoodsPriceUWork = new GoodsPriceUWork();
                //        }
                //        // ������폜���[�N�N���A
                //        writeGoodsPriseUwork = new GoodsPriceUWork();
                //    }
                //    // �����݉\
                //    SkipFlg = false;
                //}

                //// �f�[�^�����Ă��邩�m�F���邽�߂ɒ񋟓��t�Ŕ��f
                //if (PriorOfrGoodsPriceUWork.OfferDate != DateTime.MinValue)
                //{
                //    if (SkipFlg == false)
                //    {
                //        DateTime priceStartDate = DateTime.MinValue;
                //        // Datetime�ɕϊ��@�����i�J�n��
                //        if (userGoodsUnitWork.PricePriceStartDate != 0)
                //        {
                //            priceStartDate = DateTime.Parse(userGoodsUnitWork.PricePriceStartDate.ToString("0000/00/00"));
                //        }
                //        // հ�ް��ں��ސ����}�X�^�̉��i�ێ����������傫�����
                //        if (userGoodsUnitWork.PriceCount >= pricMergeSt.PriceManage)
                //        {
                //            // հ�ް���i�J�n�����񋟂̉��i�J�n���ȏ�Ȃ��
                //            if (priceStartDate > PriorOfrGoodsPriceUWork.PriceStartDate)
                //            {
                //                SkipFlg = true; continue;
                //            }
                //            // հ�ް�ƒ񋟂̉��i�J�n�����ꏏ�Ȃ�
                //            else if (priceStartDate == PriorOfrGoodsPriceUWork.PriceStartDate)
                //            {
                //                // �X�V�����@��ō쐬
                //                WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                SkipFlg = true; continue;
                //            }
                //            // հ�ް���񋟂̉��i�J�n�����傫���ꍇ(���ق͊܂܂�Ȃ�)
                //            else
                //            {
                //                // �V�K���[�N�쐬
                //                WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);

                //                //deleteGoodsPriceUWork = PriorOfrGoodsPriceUWork;
                //                if (deleteGoodsPriceUWork.GoodsMakerCd != userGoodsUnitWork.PriceGoodsMakerCd && deleteGoodsPriceUWork.GoodsNo != userGoodsUnitWork.PriceGoodsNo)
                //                {
                //                    deleteGoodsPriceUWork.EnterpriseCode = _enterpriseCode;
                //                    deleteGoodsPriceUWork.GoodsMakerCd = userGoodsUnitWork.PriceGoodsMakerCd;
                //                    deleteGoodsPriceUWork.GoodsNo = userGoodsUnitWork.PriceGoodsNo;
                //                    deleteGoodsPriceUWork.PriceStartDate = DateTime.Parse(( userGoodsUnitWork.PricePriceStartDate ).ToString("0000/00/00"));
                //                }
                //                SkipFlg = true; continue;
                //            }
                //        }
                //        // հ�ް��ں��ސ����}�X�^�̉��i�ێ�������菬�������
                //        else
                //        {
                //            // հ�ް�ƒ񋟂̉��i�J�n�����ꏏ�Ȃ�
                //            if (priceStartDate == PriorOfrGoodsPriceUWork.PriceStartDate)
                //            {
                //                // �X�V�����@��ō쐬
                //                WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                SkipFlg = true; continue;
                //            }
                //            else
                //            {
                //                // �V�K���[�N�쐬
                //                WriteNewPrice(userGoodsUnitWork, pricMergeSt, ref writePricesList, ref PriorOfrGoodsPriceUWork);
                //                SkipFlg = true; continue;
                //            }
                //        }
                //    }
                //}
                #endregion
                // 2010/04/23 Del <<<

            } // հ�ްforeach
            // 2010/04/23 Add >>>
            if (pricMergeSt.PriceMergeFlg == 0 && prcUpdtTrgtList.Count > 0)
            {
                // �����ŉ��i��������
                List<GoodsPriceUWork> addList;
                List<GoodsPriceUWork> deleteList;
                this.CreatePurePartsPriceUpdateDataList(enterpriseCode, prcUpdtTrgtList[0].GoodsNo.Trim(), prcUpdtTrgtList[0].GoodsMakerCd, pricMergeSt, prcUpdtTrgtList, ptMkrPriceWorkList, out addList, out deleteList);
                if (addList.Count > 0) writePricesList.AddRange(addList.ToArray());
                if (deleteList.Count > 0) deletePriceList.AddRange(deleteList.ToArray());
            }
            // 2010/04/23 Add <<<
        }
        #endregion


        // 2010/04/23 Add >>>

        #region ���i�}�X�^�̍X�V����

        /// <summary>
        /// ���i�������X�g�̐���
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <param name="makerCd">���[�J�[�R�[�h</param>
        /// <param name="priceMergeSt">�񋟃f�[�^�X�V�ݒ�}�X�^</param>
        /// <param name="prcUpdtTrgtList">���[�U�[���i�}�X�^���X�g</param>
        /// <param name="ptMkrPriceWorkList">�������i���X�g</param>
        /// <param name="addList">�ǉ��X�V�Ώۃ��X�g</param>
        /// <param name="deleteList">�폜�Ώۃ��X�g</param>
        private void CreatePurePartsPriceUpdateDataList(string enterpriseCode, string goodsNo, int makerCd, PriceMergeSt priceMergeSt, List<GetUsrGoodsUnitDataWork> prcUpdtTrgtList, List<PtMkrPriceWork> ptMkrPriceWorkList, out List<GoodsPriceUWork> addList, out List<GoodsPriceUWork> deleteList)
        {
            addList = new List<GoodsPriceUWork>();
            deleteList = new List<GoodsPriceUWork>();

            if (prcUpdtTrgtList == null || prcUpdtTrgtList.Count == 0) return;

            // �񋟁E���[�U�[���}�[�W�������X�g
            SortedDictionary<int, object> prcList = new SortedDictionary<int, object>();
            // ���[�U�[�ɓ��ꉿ�i�J�n�������镪�̒񋟃��X�g
            Dictionary<int, PtMkrPriceWork> duplicateList = new Dictionary<int, PtMkrPriceWork>();

            // ���[�U�[���i�}�X�^���烊�X�g�ǉ�
            foreach (GetUsrGoodsUnitDataWork data in prcUpdtTrgtList)
            {
                if (data.PricePriceStartDate == 0) continue;

                if (!prcList.ContainsKey(data.PricePriceStartDate))
                {
                    prcList.Add(data.PricePriceStartDate, data);
                }
            }

            bool ofrDtExists = false;
            // �񋟗D�ǉ��i�}�X�^���烊�X�g�ǉ�
            foreach (PtMkrPriceWork ptMkrPriceWork in ptMkrPriceWorkList)
            {
                // ���̃��X�g�͕i�ԏ��Ƀ\�[�g����Ă���̂ŁA�i�Ԃ��Ώەi�Ԃ��傫���Ȃ�����Break
                if (ptMkrPriceWork.NewPrtsNoWithHyphen.CompareTo(goodsNo) > 0) break;

                // �}�[�W�ΏۂƂȂ�L�[����v���Ă�����(Ұ����i��) 
                if (makerCd == ptMkrPriceWork.MakerCode
                    && goodsNo == ptMkrPriceWork.NewPrtsNoWithHyphen)
                {
                    // ���Ƀ��[�U�[�ɓ��ꉿ�i�J�n��������ꍇ�͏d�����X�g�Ɉڍs
                    if (prcList.ContainsKey(ptMkrPriceWork.PartsPriceStDate))
                    {
                        duplicateList.Add(ptMkrPriceWork.PartsPriceStDate, ptMkrPriceWork);
                    }
                    else
                    {
                        prcList.Add(ptMkrPriceWork.PartsPriceStDate, ptMkrPriceWork);
                    }

                    ofrDtExists = true;
                }
            }

            if (!ofrDtExists) return;

            // ���̎��_�ŁAprcList�ɁA���[�U�[+�񋟂̃��X�g�i�񋟂̏d�����������j�AduplicateList�ɏd�������񋟂̃��X�g�������Ă���

            // �Â������猩�Ă���
            List<GoodsPriceUWork> allList = new List<GoodsPriceUWork>();    �@// ���[�U�[�f�[�^�̍ŐV���i���i���Łj
            GetUsrGoodsUnitDataWork usrGoods = new GetUsrGoodsUnitDataWork(); // ���[�U�[���i

            foreach (int prcStDate in prcList.Keys)
            {
                // ���[�U�[���i
                if (prcList[prcStDate] is GetUsrGoodsUnitDataWork)
                {
                    usrGoods = (GetUsrGoodsUnitDataWork)prcList[prcStDate];
                    GoodsPriceUWork writeWork = new GoodsPriceUWork();
                    writeWork.CreateDateTime = usrGoods.PriceCreateDateTime;
                    writeWork.UpdateDateTime = usrGoods.PriceUpdateDateTime;
                    writeWork.EnterpriseCode = usrGoods.PriceEnterpriseCode;
                    writeWork.FileHeaderGuid = usrGoods.PriceFileHeaderGuid;
                    writeWork.UpdEmployeeCode = usrGoods.PriceUpdEmployeeCode;
                    writeWork.UpdAssemblyId1 = usrGoods.PriceUpdAssemblyId1;
                    writeWork.UpdAssemblyId2 = usrGoods.PriceUpdAssemblyId2;
                    writeWork.LogicalDeleteCode = usrGoods.PriceLogicalDeleteCode;

                    writeWork.GoodsMakerCd = usrGoods.GoodsMakerCd;
                    writeWork.GoodsNo = usrGoods.GoodsNo;
                    writeWork.PriceStartDate = DateTime.Parse(( usrGoods.PricePriceStartDate ).ToString("0000/00/00"));
                    writeWork.SalesUnitCost = usrGoods.PriceSalesUnitCost;
                    writeWork.StockRate = usrGoods.PriceStockRate;
                    writeWork.ListPrice = usrGoods.PriceListPrice;

                    // �񋟃f�[�^���������ꍇ
                    if (duplicateList.ContainsKey(prcStDate))
                    {
                        PtMkrPriceWork ofrData = duplicateList[prcStDate];

                        writeWork.UpdateDate = DateTime.Now;                                                // �X�V���t
                        writeWork.OfferDate = DateTime.Parse(( ofrData.OfferDate ).ToString("0000/00/00")); // �񋟓��t
                        writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;                                      // �I�[�v�����i�敪

                        // �V�����艿���[���̏ꍇ
                        if (ofrData.PartsPrice == 0)
                        {
                            // �񋟃f�[�^�X�V�ݒ�}�X�^�̃I�[�v�����i�敪���Q�Ƃ��ăZ�b�g
                            if (priceMergeSt.OpenPriceFlg == 0)
                            {
                                writeWork.ListPrice = usrGoods.PriceListPrice;  // ���̃��[�U�[���i�����p��
                            }
                            else
                            {
                                writeWork.ListPrice = 0;         // �艿�O
                            }
                        }
                        else
                        {
                            writeWork.ListPrice = ofrData.PartsPrice;
                        }
                        //------------ ADD By chenyd 2013/05/13 For Redmine #35515------------------------------->>>>>
                        double listPrice = writeWork.ListPrice;
                        this.ReflectIsolIslandCall(writeWork.GoodsMakerCd, ref listPrice);
                        writeWork.ListPrice = listPrice;
                        //------------ ADD By chenyd 2013/05/13 For Redmine #35515-------------------------------<<<<<

                        // �񋟃f�[�^���������ꍇ�̂݉��i�������X�g�ւ̒ǉ�
                        addList.Add(writeWork);
                    }
                    allList.Add(writeWork);
                }
                else if (prcList[prcStDate] is PtMkrPriceWork)
                {
                    PtMkrPriceWork ofrData = (PtMkrPriceWork)prcList[prcStDate];

                    GoodsPriceUWork writeWork = new GoodsPriceUWork();
                    writeWork.EnterpriseCode = enterpriseCode;              // ��ƃR�[�h
                    writeWork.PriceStartDate = DateTime.Parse(( ofrData.PartsPriceStDate ).ToString("0000/00/00"));       // ���i�J�n��
                    writeWork.GoodsMakerCd = makerCd;                       // ���[�J�[
                    writeWork.GoodsNo = goodsNo;                            // �i��
                    writeWork.UpdateDate = DateTime.Now;                    // �X�V�N����

                    // ���[�U�[���i�}�X�^�̓��e�����p��(�񋟂���ԌÂ��ꍇ�͓���Ȃ�)
                    writeWork.SalesUnitCost = usrGoods.PriceSalesUnitCost;   // �����P��
                    writeWork.StockRate = usrGoods.PriceStockRate;           // �d����

                    writeWork.OfferDate = DateTime.Parse(( ofrData.OfferDate ).ToString("0000/00/00")); // �񋟓��t
                    writeWork.OpenPriceDiv = ofrData.OpenPriceDiv;          // �I�[�v�����i�敪
                    writeWork.ListPrice = ofrData.PartsPrice;                // �艿

                    // �񋟂̕W�����i���[���̏ꍇ
                    if (ofrData.PartsPrice == 0)
                    {
                        // �񋟃f�[�^�X�V�ݒ�}�X�^�̃I�[�v�����i�敪���Q�Ƃ��ăZ�b�g
                        if (priceMergeSt.OpenPriceFlg == 0)
                        {
                            if (allList.Count > 0)
                            {
                                writeWork.ListPrice = allList[allList.Count - 1].ListPrice;   // 1�O�̒艿���Z�b�g
                            }
                        }
                    }
                    //------------ ADD By chenyd 2013/05/13 For Redmine #35515------------------------------->>>>>
                    double listPrice = writeWork.ListPrice;
                    this.ReflectIsolIslandCall(writeWork.GoodsMakerCd, ref listPrice);
                    writeWork.ListPrice = listPrice;
                    //------------ ADD By chenyd 2013/05/13 For Redmine #35515-------------------------------<<<<<

                    // ���i�������X�g�ɒǉ�
                    allList.Add(writeWork);

                    // �S�����X�g�ɒǉ�
                    addList.Add(writeWork);
                }
            }

            // �Ǘ������𒴂��Ă���ꍇ�A�Â��f�[�^�������
            if (allList.Count > pricMergeSt.PriceManage)
            {
                // �폜���錏��
                int delCnt = allList.Count - pricMergeSt.PriceManage;

                for (int cnt = 0; cnt < delCnt; cnt++)
                {
                    GoodsPriceUWork data = allList[0];

                    // �쐬�����������Ă���ꍇ�́A���[�U�[�o�^����Ă������Ȃ̂ŁA�폜���X�g�ɒǉ�
                    if (data.CreateDateTime != DateTime.MinValue)
                    {
                        deleteList.Add(data);
                    }

                    // �ǉ��E�X�V�f�[�^�Ɋ܂܂��ꍇ�̓��X�g����폜
                    if (addList.Contains(data)) addList.Remove(data);

                    // �擪�f�[�^������
                    allList.RemoveAt(0);
                }
            }
        }
        #endregion
   
        //------------ ADD By chenyd 2013/05/13 For Redmine #35515----------------------------------------->>>>>
        #region �������i���f
        /// <summary>
        /// �������i�擾����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="_isolIslandList">�������i���X�g</param>
        /// <remarks>
        /// <br>Note       : �������i���擾�������s���܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2013.05.13</br>
        /// </remarks>
        private void ReflectIsolIslandList(string enterpriseCode, out List<IsolIslandPrc> _isolIslandList)
        {
            // �������i�擾
            if (this._isolIslandPrcAcs == null) this._isolIslandPrcAcs = new IsolIslandPrcAcs();
            this._isolIslandPrcAcs.Search(out _isolIslandList, enterpriseCode, false);
            _isolIslandList.Sort(new IsolIslandPrcWorkComparer());
        }

        /// <summary>
        /// �������i���f�C�x���g�R�[��
        /// </summary>
        /// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
        /// <param name="listPrice">�W�����i</param>
        /// <remarks>
        /// <br>Note       : �������i���擾�������s���܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2013.05.13</br>
        /// </remarks>
        private void ReflectIsolIslandCall(int goodsMakerCd, ref double listPrice)
        {
            // �������i���f
            IsolIslandPrc isolIslandPrc = this.GetIsolIslandPrc(goodsMakerCd, listPrice);
            if (isolIslandPrc != null) listPrice = this.GetIsolIslandPrice(isolIslandPrc, listPrice);
        }

        /// <summary>
        /// �������i���擾����
        /// </summary>
        /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
        /// <param name="unitPrice">�W�����i</param>
        /// <returns>�������i</returns>
        /// <remarks>
        /// <br>Note       : �������i���擾�������s���܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2013.05.13</br>
        /// </remarks>
        private IsolIslandPrc GetIsolIslandPrc(int goodsMakerCode, double unitPrice)
        {
            List<IsolIslandPrc> IsolIslandPrcList = _isolIslandList.FindAll(
                delegate(IsolIslandPrc iso)
                {
                    if (iso.MakerCode == goodsMakerCode)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );
            if (IsolIslandPrcList != null && IsolIslandPrcList.Count > 0 && IsolIslandPrcList[0].UpperLimitPrice >= unitPrice) 
                return IsolIslandPrcList[0];
            else 
                return null;      

        }

        /// <summary>
        /// �������i�擾����
        /// </summary>
        /// <param name="isolIslandPrc">�������i</param>
        /// <param name="targetPrice">�W�����i</param>
        /// <returns>retPrice</returns>
        /// <remarks>
        /// <br>Note       : �������i�擾�������s���܂��B</br>
        /// <br>Programmer : chenyd</br>
        /// <br>Date       : 2013.05.13</br>
        /// </remarks>
        private double GetIsolIslandPrice(IsolIslandPrc isolIslandPrc, double targetPrice)
        {
            double retPrice = targetPrice;

            int fracProcDiv = isolIslandPrc.FractionProcCd; // ���z�[�������敪
            double fracProcUnit = isolIslandPrc.FractionProcUnit; // ���z�[�������P��

            if ((isolIslandPrc.UpRate == 0) || (targetPrice == 0)) return 0;

            retPrice = (isolIslandPrc.UpRate < 0) ? targetPrice * (100 + isolIslandPrc.UpRate) * 0.01 : targetPrice * isolIslandPrc.UpRate * 0.01;

            FractionCalculate.FracCalcMoney(retPrice, fracProcUnit, fracProcDiv, out retPrice);

            return retPrice;
        }

        /// <summary>
        /// �������i����r�N���X(���_�R�[�h(����)�E���[�J�[�R�[�h(����)�E������z(����))
        /// </summary>
        private class IsolIslandPrcWorkComparer : Comparer<IsolIslandPrc>
        {
            public override int Compare(IsolIslandPrc x, IsolIslandPrc y)
            {
                int result = x.SectionCode.CompareTo(y.SectionCode);
                if (result != 0) return result;

                result = x.MakerCode.CompareTo(y.MakerCode);
                if (result != 0) return result;

                result = x.UpperLimitPrice.CompareTo(y.UpperLimitPrice);
                return result;
            }
        }
        #endregion
        //------------ ADD By chenyd 2013/05/13 For Redmine #35515-----------------------------------------<<<<<

   
        // 2010/04/23 Add <<<

        // 2010/04/23 >>>
        #region �폜
        // �V�K�쐬���� 
        //private void WriteNewPrice(GetUsrGoodsUnitDataWork userGoodsUnitWork, PriceMergeSt priceMergeSt, ref ArrayList writepriceList, ref GoodsPriceUWork list)
        //{

        //    #region  �L�[�����i�[
        //    writeGoodsPriseUwork.EnterpriseCode = userGoodsUnitWork.PriceEnterpriseCode;
        //    //writeGoodsPriseUwork.UpdateDateTime = userGoodsUnitWork.PriceUpdateDateTime;
        //    writeGoodsPriseUwork.CreateDateTime = userGoodsUnitWork.PriceCreateDateTime;
        //    writeGoodsPriseUwork.UpdAssemblyId1 = userGoodsUnitWork.PriceUpdAssemblyId1;
        //    writeGoodsPriseUwork.UpdAssemblyId2 = userGoodsUnitWork.PriceUpdAssemblyId2;
        //    writeGoodsPriseUwork.FileHeaderGuid = userGoodsUnitWork.PriceFileHeaderGuid;
        //    writeGoodsPriseUwork.LogicalDeleteCode = userGoodsUnitWork.PriceLogicalDeleteCode;

        //    writeGoodsPriseUwork.SalesUnitCost = userGoodsUnitWork.PriceSalesUnitCost;
        //    writeGoodsPriseUwork.StockRate = userGoodsUnitWork.PriceStockRate;
        //    writeGoodsPriseUwork.UpdEmployeeCode = userGoodsUnitWork.PriceUpdEmployeeCode;
        //    writeGoodsPriseUwork.GoodsMakerCd = PriorOfrGoodsPriceUWork.GoodsMakerCd;
        //    writeGoodsPriseUwork.GoodsNo = PriorOfrGoodsPriceUWork.GoodsNo;
        //    writeGoodsPriseUwork.OpenPriceDiv = PriorOfrGoodsPriceUWork.OpenPriceDiv;
        //    writeGoodsPriseUwork.PriceStartDate = PriorOfrGoodsPriceUWork.PriceStartDate;
        //    writeGoodsPriseUwork.OfferDate = PriorOfrGoodsPriceUWork.OfferDate;
        //    writeGoodsPriseUwork.UpdateDate = DateTime.Now;
        //    #endregion

        //    #region �}�[�W�����i�[
        //    // �ʏ퉿�i�̏ꍇ
        //    if (writeGoodsPriseUwork.OpenPriceDiv == 0)
        //    {
        //        writeGoodsPriseUwork.ListPrice = PriorOfrGoodsPriceUWork.ListPrice;
        //    }
        //    // �I�[�v�����i�̏ꍇ
        //    else
        //    {
        //        // �I�[�v�����i�敪��0:���i�����p���̏ꍇ
        //        if (priceMergeSt.OpenPriceFlg == 0)
        //        {
        //            //�@���i���i�����p��
        //            writeGoodsPriseUwork.ListPrice = PriorOfrGoodsPriceUWork.ListPrice;
        //        }
        //        // �I�[�v�����i�敪��1:0�ōX�V��������
        //        else
        //        {
        //            // 0�ōX�V
        //            writeGoodsPriseUwork.ListPrice = 0;
        //        }
        //    }
        //    #endregion

        //    // �O�񃏁[�N�Ƃ��Ċi�[���Ă���
        //    //PriorGoodsPriceUWork = PriorOfrGoodsPriceUWork;
        //    PriorGoodsPriceUWork.CreateDateTime = PriorOfrGoodsPriceUWork.CreateDateTime;
        //    PriorGoodsPriceUWork.EnterpriseCode = PriorOfrGoodsPriceUWork.EnterpriseCode;
        //    PriorGoodsPriceUWork.FileHeaderGuid = PriorOfrGoodsPriceUWork.FileHeaderGuid;
        //    PriorGoodsPriceUWork.GoodsMakerCd = PriorOfrGoodsPriceUWork.GoodsMakerCd;
        //    PriorGoodsPriceUWork.GoodsNo = PriorOfrGoodsPriceUWork.GoodsNo;
        //    PriorGoodsPriceUWork.ListPrice = PriorOfrGoodsPriceUWork.ListPrice;
        //    PriorGoodsPriceUWork.LogicalDeleteCode = PriorOfrGoodsPriceUWork.LogicalDeleteCode;
        //    PriorGoodsPriceUWork.OfferDate = PriorOfrGoodsPriceUWork.OfferDate;
        //    PriorGoodsPriceUWork.OpenPriceDiv = PriorOfrGoodsPriceUWork.OpenPriceDiv;
        //    PriorGoodsPriceUWork.PriceStartDate = PriorOfrGoodsPriceUWork.PriceStartDate;
        //    PriorGoodsPriceUWork.SalesUnitCost = PriorOfrGoodsPriceUWork.SalesUnitCost;
        //    PriorGoodsPriceUWork.StockRate = PriorOfrGoodsPriceUWork.StockRate;
        //    PriorGoodsPriceUWork.UpdAssemblyId1 = PriorOfrGoodsPriceUWork.UpdAssemblyId1;
        //    PriorGoodsPriceUWork.UpdAssemblyId2 = PriorOfrGoodsPriceUWork.UpdAssemblyId2;
        //    PriorGoodsPriceUWork.UpdateDate = PriorOfrGoodsPriceUWork.UpdateDate;
        //    PriorGoodsPriceUWork.UpdateDateTime = PriorOfrGoodsPriceUWork.UpdateDateTime;
        //    PriorGoodsPriceUWork.UpdEmployeeCode = PriorOfrGoodsPriceUWork.UpdEmployeeCode;
        //}
        #endregion
        // 2010/04/23 <<<


        // ADD 2009/01/28 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
        /// <summary>
        /// �D�ǐݒ�}�X�^���}�[�W�ł��邩���肵�܂��B
        /// </summary>
        /// <param name="mergeConditionFromUI">UI����̃}�[�W����</param>
        /// <returns>
        /// <c>true</c> :�ł���<br/>
        /// <c>false</c>:�ł��Ȃ�
        /// </returns>
        private static bool CanMergePrimeSettingMaster(MergeCond mergeConditionFromUI)
        {
            if (mergeConditionFromUI.PrmSetChgFlg.Equals(MergeCond.NOT_DOING_FLG_AS_INT))
            {
                return false;
            }
            if (mergeConditionFromUI.PrmSetFlg.Equals(MergeCond.NOT_DOING_FLG_AS_INT))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�̖��̍��ڂ��}�[�W���邩���肵�܂��B
        /// </summary>
        /// <param name="mergeConditionFromUI">UI����̃}�[�W����</param>
        /// <returns>
        /// <c>true</c> :�ł���<br/>
        /// <c>false</c>:�ł��Ȃ�
        /// </returns>
        private static bool UpdatesNameItemOfPrimeSettingMaster(MergeCond mergeConditionFromUI)
        {
            if (mergeConditionFromUI.PrmSetChgNmOwFlg)
            {
                return true;
            }
            if (mergeConditionFromUI.PrmSetNmOwFlg)
            {
                return true;
            }
            return false;
        }

        #region <���s����/>

        /// <summary>���s����</summary>
        private ProcessResult _processResult;
        /// <summary>
        /// ���s���ʂ��擾���܂��B
        /// </summary>
        public ProcessResult ProcessResult
        {
            get
            {
                if (_processResult == null)
                {
                    _processResult = new ProcessResult();
                }
                return _processResult;
            }
        }

        /// <summary>
        /// �}�[�W�����̑O�������s���܂��B
        /// </summary>
        private void BeginMerge()
        {
            _processResult = null;
        }

        /// <summary>
        /// �}�[�W�����̍X�V�������J�E���g���܂��B
        /// </summary>
        /// <param name="blCodeMasterList">BL�R�[�h�}�X�^�̃��R�[�h���X�g</param>
        /// <param name="blGroupMasterList">BL�O���[�v�}�X�^�̃��R�[�h���X�g</param>
        /// <param name="middleGenreMasterList">�����ރ}�X�^�̃��R�[�h���X�g</param>
        /// <param name="modelNameMasterList">�Ԏ�}�X�^�̃��R�[�h���X�g</param>
        /// <param name="makerMasterList">���[�J�[�}�X�^�̃��R�[�h���X�g</param>
        /// <param name="primeSettingMasterList">�D�ǐݒ�}�X�^�̃��R�[�h���X�g</param>
        /// <param name="partsPosCodeMasterList">���ʃ}�X�^�̃��R�[�h���X�g</param>
        private void CountMerge(
            ArrayList blCodeMasterList,
            ArrayList blGroupMasterList,
            ArrayList middleGenreMasterList,
            ArrayList modelNameMasterList,
            ArrayList makerMasterList,
            ArrayList primeSettingMasterList,
            ArrayList partsPosCodeMasterList
        )
        {
            // BL�R�[�h�}�X�^
            if (!MergeChecker.IsNullOrEmptyArrayList(blCodeMasterList))
            {
                ProcessResult.BLCodeMasterUpdatedCount += blCodeMasterList.Count;
            }
            // BL�O���[�v�}�X�^
            if (!MergeChecker.IsNullOrEmptyArrayList(blGroupMasterList))
            {
                ProcessResult.BLGroupMasterUpdatedCount += blGroupMasterList.Count;
            }
            // �����ރ}�X�^
            if (!MergeChecker.IsNullOrEmptyArrayList(middleGenreMasterList))
            {
                ProcessResult.MiddleGenreMasterUpdatedCount += middleGenreMasterList.Count;
            }
            // �Ԏ�}�X�^
            if (!MergeChecker.IsNullOrEmptyArrayList(modelNameMasterList))
            {
                ProcessResult.ModelNameMasterUpdatedCount += modelNameMasterList.Count;
            }
            // ���[�J�[�}�X�^
            if (!MergeChecker.IsNullOrEmptyArrayList(makerMasterList))
            {
                ProcessResult.MakerMasterUpdatedCount += makerMasterList.Count;
            }
            // �D�ǐݒ�}�X�^
            if (!MergeChecker.IsNullOrEmptyArrayList(primeSettingMasterList))
            {
                //ProcessResult.PrimeSettingMasterUpdatedCount += primeSettingMasterList.Count / 2;   // �_���폜��������̂Ŕ����ɂ���
                ProcessResult.PrimeSettingMasterUpdatedCount += prmSetAllUpdCount;
            }
            // ���ʃ}�X�^
            if (!MergeChecker.IsNullOrEmptyArrayList(partsPosCodeMasterList))
            {
                ProcessResult.PartsPosCodeMasterUpdatedCount += partsPosCodeMasterList.Count;
            }
        }

        /// <summary>
        /// ���i���������̍X�V�������J�E���g���܂��B
        /// </summary>
        /// <param name="goodsMasterList">���i�}�X�^�̃��R�[�h���X�g</param>
        /// <param name="goodsPriceMasterList">���i�}�X�^�̃��R�[�h���X�g</param>
        private void CountPriceRevision(
            ArrayList goodsMasterList,
            ArrayList goodsPriceMasterList
        )
        {
            if (!MergeChecker.IsNullOrEmptyArrayList(goodsMasterList))
            {
                ProcessResult.GoodsMasterUpdatedCount += goodsMasterList.Count;
            }
            if (!MergeChecker.IsNullOrEmptyArrayList(goodsPriceMasterList))
            {
                ProcessResult.GoodsPriceMasterUpdatedCount += goodsPriceMasterList.Count;
            }
        }

        #endregion  // <���s����/>

        #region <���O/>

        /// <summary>���K�[</summary>
        private readonly MyLogWriter _myLogger;
        /// <summary>
        /// ���K�[���擾���܂��B
        /// </summary>
        public MyLogWriter MyLogger { get { return _myLogger; } }

        #endregion  // <���O/>
        // ADD 2008/01/28 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<

        /// <summary>
        /// �}�[�W�������s���B[�Ώ�8�e�[�u��]
        /// </summary>
        /// <param name="offerDate"></param>
        /// <param name="uiCondition"></param>
        /// <returns></returns>
        private int DoMerge(int offerDate, MergeCond uiCondition)
        {
            // ڼ޽�ط��擾
            StreamWriter writer = null;                          // �e�L�X�g���O�p
            RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Broadleaf\Service\Partsman\USER_AP");

            if (key == null) // �����Ă͂����Ȃ��P�[�X
            {
                workDir = @"C:\Program Files\Partsman\USER_AP"; // ���W�X�g���ɏ�񂪂Ȃ����߁A���Ƀf�t�H���g�̃t�H���_��ݒ�
            }
            else
            {
                // ���O��������̫��ގw��
                workDir = key.GetValue("InstallDirectory", @"C:\Program Files\Partsman\USER_AP").ToString();
            }

            Directory.CreateDirectory(@"" + workDir + @"\Log\PMCMN06200S");

            //_autoFlg = uiCondition.PrmSetFlg;
            //_autoFlg = 0;
            if (_iMergeDataGetter == null) _iMergeDataGetter = MediationMergeDataGetDB.GetRemoteObject();

            // ADD 2009/02/02 �@�\�ǉ��F�Ώۓ��t�擾 ---------->>>>>
            #region [ �Ώۓ��t�擾 ]


            // DEL 2009/02/23 �s��Ή�[11818]��
            //ProcessConfig config = GetTargetAndSetProcessSequence(ProcessConfigAcs.Instance.Policy);
            ProcessConfig config = GetTargetAndSetProcessSequence(uiCondition.EnterpriseCode);  // ADD 2009/02/23 �s��Ή�[11818]
            if (ProcessSequence.Count.Equals(0))
            {
                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }

            #endregion  // [ �Ώۓ��t�擾 ]

            int status = 0;

            BeginMerge();

            // �X�V�t���O�ۑ�
            MergeObjectCond UpdateMaster = new MergeObjectCond();
            UpdateMaster.BLFlg = uiCondition.BLFlg;
            UpdateMaster.BLGroupFlg = uiCondition.BLGroupFlg;
            UpdateMaster.GoodsMGroupFlg = uiCondition.GoodsMGroupFlg;
            UpdateMaster.GoodsUFlg = uiCondition.PriceRevisionFlg;
            UpdateMaster.ModelNameFlg = uiCondition.ModelNameFlg;
            UpdateMaster.PartsPosFlg = uiCondition.PartsPosFlg;
            UpdateMaster.PMakerFlg = uiCondition.PMakerFlg;
            UpdateMaster.PrmSetFlg = uiCondition.PrmSetFlg;

            bool margedPartsPosCodeMaster = false;  // ���ʃ}�X�^�̃}�[�W��1��̂�

            //SortedList<string, int> dateSequenceList = ProcessSequence.CreateDateSequenceList();
            //foreach (int enmOfferDate in dateSequenceList.Values)
            SortedList<int, string> dateSequenceList = ProcessSequence.CreateDateSequenceList(); // 1.5����

            // ADD 2025/08/11 �c������ ----->>>>> 
            List<KeyValuePair<int, string>> tempSortList = new List<KeyValuePair<int, string>>();
            List<KeyValuePair<int, string>> dateSequenceListSorted = new List<KeyValuePair<int, string>>();
            foreach (KeyValuePair<int, string> dateSequence in dateSequenceList)
            {
                // �񋟃f�[�^���t���X�L�b�v�Ώۊ��Ԃł���΁A���X�g�̍Ō���Ɉړ�����
                if (dateSequence.Key >= SkipOfferTermSt && dateSequence.Key <= SkipOfferTermEd)
                {
                    // �ꎞ�ޔ�
                    tempSortList.Add(dateSequence);
                }
                else
                {
                    dateSequenceListSorted.Add(dateSequence);
                }
            }
            // �ޔ������f�[�^�����X�g�̍Ō���ɕt����
            dateSequenceListSorted.AddRange(tempSortList);
            // ADD 2025/08/11 �c������ -----<<<<<

            // DEL 2025/08/11 �c������ ----->>>>> 
            //foreach (int enmOfferDate in dateSequenceList.Keys)                                  // 1.5����
            //{
            //    offerDate = enmOfferDate;
            // DEL 2025/08/11 �c������ -----<<<<<
            // ADD 2025/08/11 �c������ ----->>>>> 
            foreach (KeyValuePair<int, string> enmOfferDate in dateSequenceListSorted)
            {
                offerDate = enmOfferDate.Key;
            // ADD 2025/08/11 �c������ -----<<<<<

                // ÷��۸ޏ����� (�Ώۓ��tٰ��)
                writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                writer.Write(DateTime.Now + " �Ώۓ��t���ɍX�V�J�n " + "�񋟓��t " + DateTime.Parse(offerDate.ToString("0000/00/00")) + "\r\n");
                writer.Flush();
                if (writer != null) writer.Close();

                #region 1.5����
                string writeDataFlg = string.Empty;
                dateSequenceList.TryGetValue(offerDate, out writeDataFlg);
                #endregion

                //Debug.WriteLine("�Ώۓ��t�F" + enmOfferDate.ToString());
                #region <Debug/>
#if _CONST_OFFER_DATE_
                offerDate = 20081001;   // HACK:���Ώۓ��t�F�D�ǐݒ�ύX�}�X�^�Ȃ��A�D�ǐݒ�}�X�^�i�񋟃f�[�^���j�Ȃ�
                offerDate = 20090105;   // HACK:���Ώۓ��t�F�D�ǐݒ�ύX�}�X�^����A�D�ǐݒ�}�X�^�i�񋟃f�[�^���j����
                //offerDate = 20080929;   // HACK:���Ώۓ��t�F�D�ǐݒ�ύX�}�X�^�Ȃ��A�D�ǐݒ�}�X�^�i�񋟃f�[�^���j����
#endif
                #endregion  // <Debug/>

                //MyLogger.Write("�Ώۓ��t�擾", "�Ώۃ`�F�b�N", MyLogWriter.GetTargetCheckMessage(offerDate, ProcessSequence));
                // ADD 2009/02/02 �@�\�ǉ��F�Ώۓ��t�擾 ----------<<<<<

                #region [ �}�[�W�p�񋟏��擾 ]

                // �񋟃f�[�^�̎擾����
                MergeInfoGetCond gettingOfferCondition = new MergeInfoGetCond();
                {
                    #region DELETE 1�������W�b�N
                    //gettingOfferCondition.BLFlg = uiCondition.BLFlg;            // BL�R�[�h�}�X�^
                    //gettingOfferCondition.BLGroupFlg = uiCondition.BLGroupFlg;       // BL�O���[�v�}�X�^
                    //gettingOfferCondition.GoodsMGroupFlg = uiCondition.GoodsMGroupFlg;   // �����ރ}�X�^
                    //gettingOfferCondition.ModelNameFlg = uiCondition.ModelNameFlg;     // �Ԏ�}�X�^
                    //gettingOfferCondition.PMakerFlg = uiCondition.PMakerFlg;        // ���[�J�[�}�X�^
                    //gettingOfferCondition.PartsPosFlg = uiCondition.PartsPosFlg;      // ���ʃ}�X�^
                    //if (margedPartsPosCodeMaster == true)
                    //{
                    //    gettingOfferCondition.PartsPosFlg = 0;
                    //}
                    //// ADD 2009/01/28 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                    //if (CanMergePrimeSettingMaster(uiCondition))
                    //{
                    //    gettingOfferCondition.PrmSetChgFlg = MergeCond.DOING_FLG_AS_INT;   // �D�ǐݒ�ύX�}�X�^
                    //    gettingOfferCondition.PrmSetFlg = MergeCond.DOING_FLG_AS_INT;   // �D�ǐݒ�}�X�^
                    //}
                    //else
                    //{
                    //    gettingOfferCondition.PrmSetChgFlg = MergeCond.NOT_DOING_FLG_AS_INT;
                    //    gettingOfferCondition.PrmSetFlg = MergeCond.NOT_DOING_FLG_AS_INT;
                    //}
                    #endregion

                    #region 1.5����

                    gettingOfferCondition.BLFlg = uiCondition.BLFlg;            // BL�R�[�h�}�X�^
                    if (!( writeDataFlg.Contains("0") )) gettingOfferCondition.BLFlg = 0;
                    gettingOfferCondition.BLGroupFlg = uiCondition.BLGroupFlg;       // BL�O���[�v�}�X�^
                    if (!( writeDataFlg.Contains("1") )) gettingOfferCondition.BLGroupFlg = 0;
                    gettingOfferCondition.GoodsMGroupFlg = uiCondition.GoodsMGroupFlg;   // �����ރ}�X�^
                    if (!( writeDataFlg.Contains("2") )) gettingOfferCondition.GoodsMGroupFlg = 0;
                    gettingOfferCondition.ModelNameFlg = uiCondition.ModelNameFlg;     // �Ԏ�}�X�^
                    if (!( writeDataFlg.Contains("3") )) gettingOfferCondition.ModelNameFlg = 0;
                    gettingOfferCondition.PMakerFlg = uiCondition.PMakerFlg;        // ���[�J�[�}�X�^
                    if (!( writeDataFlg.Contains("4") )) gettingOfferCondition.PMakerFlg = 0;
                    gettingOfferCondition.PartsPosFlg = uiCondition.PartsPosFlg;      // ���ʃ}�X�^
                    if (uiCondition.PartsPosFlg != 0)
                    {
                        if (!( writeDataFlg.Contains("7") )) gettingOfferCondition.PartsPosFlg = 0;
                    }

                    // ADD 2009/01/28 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                    if (CanMergePrimeSettingMaster(uiCondition))
                    {
                        gettingOfferCondition.PrmSetChgFlg = MergeCond.DOING_FLG_AS_INT;   // �D�ǐݒ�ύX�}�X�^
                        if (!( writeDataFlg.Contains("5") )) gettingOfferCondition.PrmSetChgFlg = 0;
                        gettingOfferCondition.PrmSetFlg = MergeCond.DOING_FLG_AS_INT;   // �D�ǐݒ�}�X�^
                        if (!( writeDataFlg.Contains("6") )) gettingOfferCondition.PrmSetFlg = 0;
                    }
                    else
                    {
                        gettingOfferCondition.PrmSetChgFlg = MergeCond.NOT_DOING_FLG_AS_INT;
                        gettingOfferCondition.PrmSetFlg = MergeCond.NOT_DOING_FLG_AS_INT;
                    }
                    #endregion

                    //MyLogger.Write(MyLogWriter.MERGING, MyLogWriter.GetTargetTableName(gettingOfferCondition), "�}�[�W�J�n");
                    // ADD 2008/01/28 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<
                }
                object retList = null;
                //if (margedPartsPosCodeMaster == false)
                //{
                status = _iMergeDataGetter.GetMergeData(
                    offerDate,
                    gettingOfferCondition,
                    out retList,
                    Option.SearchPartsType, // ADD 2009/02/20 �s��Ή�[11708] �����F�����^�C�v�̒ǉ�
                    Option.BigCarOfferDiv   // ADD 2009/02/20 �s��Ή�[11708] �����F��^�I�v�V�����̒ǉ�
                );
                //}
                //if (status != 0) return status;
                // ADD 2009/02/03 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                #region Delete
                //if (!status.Equals((int)Result.RemoteStatus.Normal) && !status.Equals((int)Result.RemoteStatus.NotFound))
                //{
                //    MyLogger.Write(MyLogWriter.MERGING, MyLogWriter.GetTargetTableName(gettingOfferCondition), MyLogWriter.GetMergedMessage(status, null));
                //    //break;
                //}
                #endregion
                // ADD 2008/02/03 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<


                if (retList == null) continue;

                //CustomSerializeArrayList lastOfferDataList = (CustomSerializeArrayList)retList;
                ArrayList lastOfferDataList = retList as ArrayList;
                // DEL 2009/02/23 �s��Ή�[11815]��
                //if (lastOfferDataList.Count == 0) return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

                #endregion  // [ �}�[�W�p�񋟏��擾 ]

                _enterpriseCode = uiCondition.EnterpriseCode;
                MergeObjectCond cond = new MergeObjectCond();
                int offerday = 0; // UI����̃}�[�W�̏ꍇ�̒񋟓��t���擾���Ă����B

                #region [ �񋟏��Z�� ]

                ArrayList offerPMakerNmList = null; // �񋟕��i���[�J�[����
                ArrayList offerModelNameList = null; // �񋟎Ԏ�}�X�^
                ArrayList offerGoodsMGroupList = null; // �񋟏��i�����ރ}�X�^
                ArrayList offerBLGroupList = null; // ��BL�O���[�v�}�X�^
                ArrayList offerTbsPartsCodeList = null; // ��BL�R�[�h
                ArrayList offerPartsPosList = null; // �񋟕��ʃ}�X�^
                //ArrayList ofrSupplierLst      = null; // �񋟎d����


                // ADD 2009/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                ArrayList offerPrimeSettingChangeList = null; // �D�ǐݒ�ύX�}�X�^
                ArrayList offerPrimeSettingList = null;       // �D�ǐݒ�}�X�^
                // ADD 2008/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<


                if (offerLstPrmSetChg == null) offerLstPrmSetChg = new Dictionary<int, ArrayList>(); // �D�ǐݒ�ύX�}�X�^ <offerDate,�ύXؽ�> 1.5���� 
                if (offerLstPrmSet == null) offerLstPrmSet = new Dictionary<int, ArrayList>(); // �D�ǐݒ�}�X�^     <offerDate,�ݒ�ؽ�> 1.5����

                //offerLstPrmSetChg.Clear();
                //offerLstPrmSet.Clear();

                ArrayList lstPMakerCond = null;

                for (int i = 0; i < lastOfferDataList.Count; i++)
                {
                    // ADD 2009/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                    if (MergeChecker.IsNullOrEmptyArrayList(lastOfferDataList[i] as ArrayList))
                    {
                        continue;
                    }
                    // ADD 2008/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<

                    switch (( (ArrayList)lastOfferDataList[i] )[0].GetType().Name)
                    {
                        case "PMakerNmWork":          // �񋟕��i���[�J�[����
                            offerPMakerNmList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (PMakerNmWork)offerPMakerNmList[0] ).OfferDate;
                            cond.PMakerFlg = 1;
                            break;
                        case "ModelNameWork":       // �񋟎Ԏ�}�X�^
                            offerModelNameList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (ModelNameWork)offerModelNameList[0] ).OfferDate;
                            cond.ModelNameFlg = 1;

                            lstPMakerCond = new ArrayList();
                            foreach (ModelNameWork ModelNameWork in offerModelNameList)
                            {
                                ModelNameUWork ModelNameUWork = new ModelNameUWork();
                                ModelNameUWork.EnterpriseCode = _enterpriseCode;
                                ModelNameUWork.MakerCode = ModelNameWork.MakerCode;
                                ModelNameUWork.ModelCode = ModelNameWork.ModelCode;
                                ModelNameUWork.ModelSubCode = ModelNameWork.ModelSubCode;
                                ModelNameUWork.ModelUniqueCode = ModelNameWork.ModelUniqueCode;
                                lstPMakerCond.Add(ModelNameUWork);
                            }
                            break;

                        case "GoodsMGroupWork":       // �񋟏��i�����ރ}�X�^
                            offerGoodsMGroupList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (GoodsMGroupWork)offerGoodsMGroupList[0] ).OfferDate;
                            cond.GoodsMGroupFlg = 1;
                            break;

                        case "BLGroupWork":         // ��BL�O���[�v�}�X�^
                            offerBLGroupList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (BLGroupWork)offerBLGroupList[0] ).OfferDate;
                            cond.BLGroupFlg = 1;
                            break;

                        case "TbsPartsCodeWork":    // ��BL�R�[�h
                            offerTbsPartsCodeList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (TbsPartsCodeWork)offerTbsPartsCodeList[0] ).OfferDate;
                            cond.BLFlg = 1;
                            break;

                        case "PartsPosCodeWork":        // �񋟕��ʃ}�X�^
                            offerPartsPosList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (PartsPosCodeWork)offerPartsPosList[0] ).OfferDate;
                            cond.PartsPosFlg = 1;
                            break;

                        // ADD 2009/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                        case "PrmSettingChgWork":   // �D�ǐݒ�ύX�}�X�^
                            offerPrimeSettingChangeList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (PrmSettingChgWork)offerPrimeSettingChangeList[0] ).OfferDate;
                            cond.PrmSetChgFlg = 1;
                            offerLstPrmSetChg.Add(offerday, offerPrimeSettingChangeList);
                            break;

                        case "PrmSettingWork":      // �D�ǐݒ�}�X�^
                            offerPrimeSettingList = lastOfferDataList[i] as ArrayList;
                            offerday = ( (PrmSettingWork)offerPrimeSettingList[0] ).OfferDate;
                            cond.PrmSetFlg = 1;
                            offerLstPrmSet.Add(offerday, offerPrimeSettingList);
                            break;

                        //case "OfrSupplierWork":
                        //    ofrSupplierLst = lstOfferData[i] as ArrayList;        // �񋟎d����i�񋟁j
                        //    cond.SupplierFlg = 1;
                        //    break;
                        // ADD 2008/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<
                    }
                }

                // ÷��۸ޏ����� (�񋟃f�[�^�擾)
                string MasterSerchLogText = string.Empty;

                if (offerPMakerNmList != null) MasterSerchLogText += ( "�񋟓��t" + offerDate + " Ұ��Ͻ��擾 " + offerPMakerNmList.Count + "��" + "\r\n" );
                if (offerModelNameList != null) MasterSerchLogText += ( "�񋟓��t" + offerDate + " �Ԏ�Ͻ��擾 " + offerModelNameList.Count + "��" + "\r\n" );
                if (offerGoodsMGroupList != null) MasterSerchLogText += ( "�񋟓��t" + offerDate + " ������Ͻ��擾 " + offerGoodsMGroupList.Count + "��" + "\r\n" );
                if (offerBLGroupList != null) MasterSerchLogText += ( "�񋟓��t" + offerDate + " BL��ٰ��Ͻ��擾 " + offerBLGroupList.Count + "��" + "\r\n" );
                if (offerTbsPartsCodeList != null) MasterSerchLogText += ( "�񋟓��t" + offerDate + " BL����Ͻ��擾 " + offerTbsPartsCodeList.Count + "��" + "\r\n" );
                if (offerPartsPosList != null) MasterSerchLogText += ( "�񋟓��t" + offerDate + " ����Ͻ��擾 " + offerPartsPosList.Count + "��" + "\r\n" );
                if (offerPrimeSettingChangeList != null) MasterSerchLogText += ( "�񋟓��t" + offerDate + " �D�ǐݒ�ύXϽ��擾 " + offerPrimeSettingChangeList.Count + "��" + "\r\n" );
                if (offerPrimeSettingList != null) MasterSerchLogText += ( "�񋟓��t" + offerDate + " �D�ǐݒ�Ͻ��擾 " + offerPrimeSettingList.Count + "��" + "\r\n" );

                if (MasterSerchLogText != string.Empty)
                {
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer.Write(DateTime.Now + " �񋟃}�X�^�f�[�^�擾 \r\n" + MasterSerchLogText + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();
                }

                #endregion  // [ �񋟏��Z�� ]

                #region [ �}�[�W�p���[�U�[���擾 ]

                if (_iOfferMerger == null) _iOfferMerger = MediationOfferMergeDB.GetRemoteObject();
                cond.EnterpriseCode = _enterpriseCode;
                object retUsrList;
                // �Ԏ�͌������������߁A�񋟂ɂ���f�[�^�݂̂����[�U�[DB����擾����B
                status = _iOfferMerger.GetMergeObject(cond, lstPMakerCond, out retUsrList);
                // ADD 2009/02/03 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                if (!status.Equals((int)Result.RemoteStatus.Normal) && !status.Equals((int)Result.RemoteStatus.NotFound))
                {
                    MyLogger.Write(
                        MyLogWriter.MERGING,
                        MyLogWriter.GetTargetTableName(gettingOfferCondition),
                        MyLogWriter.GetMergedMessage(status, null)
                    );
                    //break;
                }
                // ADD 2008/02/03 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<
                CustomSerializeArrayList lstUsrData = (CustomSerializeArrayList)retUsrList;

                ArrayList userPMakerNmList = null;        // ���[�U�[���i���[�J�[����
                ArrayList userModelNameList = null;     // ���[�U�[�Ԏ�}�X�^
                ArrayList userGoodsMGroupList = null;     // ���[�U�[���i�����ރ}�X�^
                ArrayList userBLGroupList = null;       // ���[�U�[BL�O���[�v�}�X�^
                ArrayList usrTbsPartsCodeLst = null;  // ���[�U�[BL�R�[�h
                //ArrayList usrSupplierLst = null;      // ���[�U�[�d����}�X�^
                ArrayList userPartsPosList = null;      // ���[�U�[���ʃ}�X�^

                // ADD 2009/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                ArrayList userPrimeSettingList = null;  // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j
                // ADD 2008/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<

                for (int i = 0; i < lstUsrData.Count; i++)
                {
                    // ADD 2009/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                    if (MergeChecker.IsNullOrEmptyArrayList(lstUsrData[i] as ArrayList)) continue;
                    // ADD 2008/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<

                    if (( (ArrayList)lstUsrData[i] ).Count == 0) continue;

                    switch (( (ArrayList)lstUsrData[i] )[0].GetType().Name)
                    {
                        case "MakerUWork":
                            userPMakerNmList = lstUsrData[i] as ArrayList;          // ���[�U�[���i���[�J�[����
                            break;
                        case "ModelNameUWork":
                            userModelNameList = lstUsrData[i] as ArrayList;       // ���[�U�[�Ԏ�}�X�^
                            break;
                        case "GoodsGroupUWork":
                            userGoodsMGroupList = lstUsrData[i] as ArrayList;       // ���[�U�[���i�����ރ}�X�^
                            break;
                        case "BLGroupUWork":
                            userBLGroupList = lstUsrData[i] as ArrayList;         // ���[�U�[BL�O���[�v�}�X�^
                            break;
                        case "BLGoodsCdUWork":
                            usrTbsPartsCodeLst = lstUsrData[i] as ArrayList;    // ���[�U�[BL�R�[�h
                            break;
                        //case "SupplierWork":
                        //    usrSupplierLst = lstUsrData[i] as ArrayList;        // ���[�U�[�d����}�X�^
                        //    break;
                        case "PartsPosCodeUWork":
                            userPartsPosList = lstUsrData[i] as ArrayList;        // ���[�U�[���ʃ}�X�^
                            break;
                        // ADD 2009/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                        case "PrmSettingUWork": // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j
                            userPrimeSettingList = lstUsrData[i] as ArrayList;
                            break;
                        // ADD 2008/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<
                    }
                }

                #endregion  // [ �}�[�W�p���[�U�[���擾 ]

                #region [ �񋟁����[�U�[�f�[�^�ϊ����� ]

                if (userUpdatingPMakerList == null) userUpdatingPMakerList = new ArrayList();  // ���[�U�[���i���[�J�[���̍X�V�f�[�^���X�g
                if (userUpdatingModelNameList == null) userUpdatingModelNameList = new ArrayList();  // ���[�U�[�Ԏ�}�X�^�X�V�f�[�^���X�g
                if (userUpdatingGoodsMGroupList == null) userUpdatingGoodsMGroupList = new ArrayList();  // ���[�U�[���i�����ރ}�X�^�X�V�f�[�^���X�g
                if (userUpdatingBLGroupList == null) userUpdatingBLGroupList = new ArrayList();  // ���[�U�[BL�R�[�h�X�V�f�[�^���X�g
                if (userUpdatingTbsPartsCodeList == null) userUpdatingTbsPartsCodeList = new ArrayList();  // ���[�U�[BL�O���[�v�}�X�^�X�V�f�[�^���X�g
                if (userUpdatingPartsPosList == null) userUpdatingPartsPosList = new ArrayList();  // ���[�U�[���ʃ}�X�^�X�V�f�[�^���X�g
                //ArrayList usrUpdateSupplierLst = new ArrayList();                                      // ���[�U�[�d����}�X�^�X�V�f�[�^���X�g

                #region [ ���i���[�J�[�}�X�^ ]
                if (offerPMakerNmList != null)
                {
                    int cnt = 0;
                    if (userPMakerNmList != null)
                        cnt = userPMakerNmList.Count;
                    foreach (PMakerNmWork pMakerNmWork in offerPMakerNmList)
                    {
                        bool flg = false;
                        MakerUWork usrPMakerNm = null;

                        for (int i = 0; i < cnt; i++)
                        {
                            usrPMakerNm = userPMakerNmList[i] as MakerUWork;
                            if (pMakerNmWork.PartsMakerCode == usrPMakerNm.GoodsMakerCd)
                            {
                                flg = true;
                                break;
                            }
                        }

                        if (flg == false)
                        {
                            usrPMakerNm = null;
                        }
                        if (ConvertPMakerNm(pMakerNmWork, ref usrPMakerNm))
                            userUpdatingPMakerList.Add(usrPMakerNm);
                    }
                }
                #endregion

                #region [ �Ԏ햼�̃}�X�^ ]
                if (offerModelNameList != null)
                {
                    int cnt = 0;
                    if (userModelNameList != null)
                        cnt = userModelNameList.Count;
                    foreach (ModelNameWork ModelNameWork in offerModelNameList)
                    {
                        bool flg = false;
                        ModelNameUWork usrModelName = null;
                        for (int i = 0; i < cnt; i++)
                        {
                            usrModelName = userModelNameList[i] as ModelNameUWork;
                            if (ModelNameWork.ModelUniqueCode == usrModelName.ModelUniqueCode)
                            {
                                flg = true;
                                break;
                            }
                        }
                        if (flg == false)
                        {
                            usrModelName = null;
                        }
                        if (ConvertModelName(ModelNameWork, ref usrModelName))
                            userUpdatingModelNameList.Add(usrModelName);
                    }
                }
                #endregion

                #region [ ���i�����ރ}�X�^ ]
                if (offerGoodsMGroupList != null)
                {
                    int cnt = 0;
                    if (userGoodsMGroupList != null)
                        cnt = userGoodsMGroupList.Count;
                    foreach (GoodsMGroupWork GoodsMGroupWork in offerGoodsMGroupList)
                    {
                        bool flg = false;
                        GoodsGroupUWork usrGoodsGroup = null;
                        for (int i = 0; i < cnt; i++)
                        {
                            usrGoodsGroup = userGoodsMGroupList[i] as GoodsGroupUWork;
                            if (GoodsMGroupWork.GoodsMGroup == usrGoodsGroup.GoodsMGroup)
                            {
                                flg = true;
                                break;
                            }
                        }
                        if (flg == false)
                        {
                            usrGoodsGroup = null;
                        }
                        if (ConvertGoodsMGroup(uiCondition.GoodsMGroupNmOwFlg, GoodsMGroupWork, ref usrGoodsGroup))
                            userUpdatingGoodsMGroupList.Add(usrGoodsGroup);
                    }
                }
                #endregion

                #region [ BL�O���[�v�R�[�h�}�X�^ ]
                if (offerBLGroupList != null)
                {
                    int cnt = 0;
                    if (userBLGroupList != null)
                        cnt = userBLGroupList.Count;
                    foreach (BLGroupWork BLGroupWork in offerBLGroupList)
                    {
                        bool flg = false;
                        BLGroupUWork usrBLGroup = null;
                        for (int i = 0; i < cnt; i++)
                        {
                            usrBLGroup = userBLGroupList[i] as BLGroupUWork;
                            if (BLGroupWork.BLGroupCode == usrBLGroup.BLGroupCode)
                            {
                                flg = true;
                                break;
                            }
                        }
                        if (flg == false)
                        {
                            usrBLGroup = null;
                        }
                        if (ConvertBLGroup(uiCondition.BLGroupNmOwFlg, BLGroupWork, ref usrBLGroup))
                            userUpdatingBLGroupList.Add(usrBLGroup);
                    }
                }
                #endregion

                #region [ �a�k�R�[�h�}�X�^ ]
                if (offerTbsPartsCodeList != null)
                {
                    int cnt = 0;
                    if (usrTbsPartsCodeLst != null)
                        cnt = usrTbsPartsCodeLst.Count;
                    foreach (TbsPartsCodeWork TbsPartsCodeWork in offerTbsPartsCodeList)
                    {
                        bool flg = false;
                        BLGoodsCdUWork usrBLGoodsCd = null;
                        for (int i = 0; i < cnt; i++)
                        {
                            usrBLGoodsCd = usrTbsPartsCodeLst[i] as BLGoodsCdUWork;
                            if (TbsPartsCodeWork.TbsPartsCode == usrBLGoodsCd.BLGoodsCode)
                            {
                                flg = true;
                                break;
                            }
                        }
                        if (flg == false)
                        {
                            usrBLGoodsCd = null;
                        }
                        if (ConvertBL(uiCondition.BLNmOwFlg, TbsPartsCodeWork, ref usrBLGoodsCd))
                            userUpdatingTbsPartsCodeList.Add(usrBLGoodsCd);
                    }

                }
                #endregion

                #region [ �d����}�X�^ ]
                /*if (ofrSupplierLst != null)
            {
                int cnt = 0;
                if (usrSupplierLst != null)
                    cnt = usrSupplierLst.Count;
                foreach (OfrSupplierWork OfrSupplierWork in ofrSupplierLst)
                {
                    bool flg = false;
                    SupplierWork usrSupplier = null;
                    for (int i = 0; i < cnt; i++)
                    {
                        usrSupplier = usrSupplierLst[i] as SupplierWork;
                        if (OfrSupplierWork.SupplierCd == usrSupplier.SupplierCd)
                        {
                            flg = true;
                            break;
                        }
                    }
                    if (flg == false)
                    {
                        usrSupplier = null;
                    }
                    if (ConvertSupplier(enterpriseCode, OfrSupplierWork, ref usrSupplier))
                        usrUpdateSupplierLst.Add(usrSupplier);
                }
            }*/
                #endregion

                #region [ ���ʃ}�X�^ ]
                if (offerPartsPosList != null && !margedPartsPosCodeMaster)   // ���ʃ}�X�^�̃}�[�W��1��̂�
                //if (offerPartsPosList != null)
                {
                    int cnt = 0;
                    if (userPartsPosList != null)
                        cnt = userPartsPosList.Count;
                    //lstPartsPos = new List<string>();
                    foreach (PartsPosCodeWork PartsPosCodeWork in offerPartsPosList)
                    {
                        bool flg = false;
                        PartsPosCodeUWork usrPartsPos = null;
                        for (int i = 0; i < cnt; i++)
                        {
                            usrPartsPos = userPartsPosList[i] as PartsPosCodeUWork;
                            if (PartsPosCodeWork.SearchPartsPosCode == usrPartsPos.SearchPartsPosCode
                                && PartsPosCodeWork.TbsPartsCode == usrPartsPos.TbsPartsCode)
                            {
                                flg = true;
                                break;
                            }
                        }
                        if (flg == false)
                        {
                            usrPartsPos = null;
                        }
                        if (ConvertPartsPos(uiCondition.PartsPosNmOwFlg, PartsPosCodeWork, ref usrPartsPos, Option.SearchPartsType, Option.BigCarOfferDiv))
                        {
                            userUpdatingPartsPosList.Add(usrPartsPos);
                        }
                    }
                    margedPartsPosCodeMaster = true;
                }
                #endregion

                // ADD 2009/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j
                #region [ �D�ǐݒ�}�X�^ ]

                //if (UsrUpdatePrmsetList == null) UsrUpdatePrmsetList = new CustomSerializeArrayList();
                //if (offerLstPrmSet != null && offerLstPrmSet.Count > 0) UsrUpdatePrmsetList.Add(offerLstPrmSet);
                //if (offerLstPrmSetChg != null && offerLstPrmSetChg.Count > 0) UsrUpdatePrmsetList.Add(offerLstPrmSetChg);

                //// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�X�V�f�[�^���X�g�ƍ폜���X�g
                //UserUpdatingPrimeSettingPair userUpdatingPrimeSettingPair = PrimeSettingMergeFacade.Merge(
                //    offerDate,
                //    offerPrimeSettingChangeList,
                //    offerPrimeSettingList,
                //    userPrimeSettingList,
                //    UpdatesNameItemOfPrimeSettingMaster(uiCondition)
                //);
                //ArrayList updatingPrmSettingUWorkList = userUpdatingPrimeSettingPair.First; // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�X�V���X�g
                //ArrayList deletingPrmSettingUWorkList = userUpdatingPrimeSettingPair.Second;// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�폜���X�g

                #endregion  // [ �D�ǐݒ�}�X�^ ]
                // ADD 2008/02/06 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<

                #endregion  // [ �񋟁����[�U�[�f�[�^�ϊ����� ]

                #region [ ���[�U�[DB�֏����� ]

                #region 1.5���Ή��ɂ����tfor���̉��Ɉړ�(�ꊇ�X�V)
                //CustomSerializeArrayList lstUsrUpdateData = new CustomSerializeArrayList();
                //if (userUpdatingPMakerList.Count > 0) // ���[�U�[���i���[�J�[���̍X�V�f�[�^���X�g
                //    lstUsrUpdateData.Add(userUpdatingPMakerList);
                //if (userUpdatingModelNameList.Count > 0) // ���[�U�[�Ԏ�}�X�^�X�V�f�[�^���X�g
                //    lstUsrUpdateData.Add(userUpdatingModelNameList);
                //if (userUpdatingGoodsMGroupList.Count > 0) // ���[�U�[���i�����ރ}�X�^�X�V�f�[�^���X�g
                //    lstUsrUpdateData.Add(userUpdatingGoodsMGroupList);
                //if (userUpdatingBLGroupList.Count > 0) // ���[�U�[BL�R�[�h�X�V�f�[�^���X�g
                //    lstUsrUpdateData.Add(userUpdatingBLGroupList);
                //if (userUpdatingTbsPartsCodeList.Count > 0) // ���[�U�[BL�O���[�v�}�X�^�X�V�f�[�^���X�g
                //    lstUsrUpdateData.Add(userUpdatingTbsPartsCodeList);
                //if (usrUpdateSupplierLst.Count > 0) // ���[�U�[�d����}�X�^�X�V�f�[�^���X�g
                //    lstUsrUpdateData.Add(usrUpdateSupplierLst);
                #region DELETE
                // ADD 2009/02/09 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�X�V�f�[�^���X�g
                //if (updatingPrmSettingUWorkList.Count > 0)
                //{
                //    lstUsrUpdateData.Add(updatingPrmSettingUWorkList);
                //}
                ////�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�폜�f�[�^���X�g
                //if (deletingPrmSettingUWorkList.Count > 0)
                //{
                //    // �폜���鏤�i�Ǘ������擾
                //    ArrayList deletingGoodsMngWorkList = PrimeSettingMergeFacade.GetGoodsMngWorkList(
                //        deletingPrmSettingUWorkList
                //    );
                //    // �D�ǐݒ�}�X�^�i���[�U�[�o�^���j���폜
                //    IPrmSettingUDB dbDeleter = (IPrmSettingUDB)MediationPrmSettingUDB.GetPrmSettingUDB();
                //    {
                //        object objDeletingPrimeSettingUWorkList = (object)deletingPrmSettingUWorkList;
                //        object objDeletingGoodsMngWorkList = (object)deletingGoodsMngWorkList;
                //        status = dbDeleter.Delete(objDeletingPrimeSettingUWorkList, objDeletingGoodsMngWorkList);
                //        //if (!status.Equals((int)Result.RemoteStatus.Normal))
                //        //{
                //        //    MyLogger.Write(
                //        //        MyLogWriter.MERGING,
                //        //        MyLogWriter.GetTargetTableName(gettingOfferCondition),
                //        //        MyLogWriter.GetMergedMessage(status, lstUsrUpdateData)
                //        //    );
                //        //    break;
                //        //}
                //    }
                //}
                // ADD 2008/02/09 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<
                #endregion

                //if (userUpdatingPartsPosList.Count > 0) // ���[�U�[���ʃ}�X�^�X�V�f�[�^���X�g
                //    lstUsrUpdateData.Add(userUpdatingPartsPosList);
                #endregion

                // ADD 2009/02/03 �@�\�ǉ��F���i���� ---------->>>>>
                #region [ ���i�������� ]

                if (uiCondition.PriceRevisionFlg.Equals(MergeCond.DOING_FLG_AS_INT) && ( ( writeDataFlg.Contains("8") ) || ( writeDataFlg.Contains("9") ) ))
                {
                    status = PriceRevision(_enterpriseCode, offerDate, out priceRevisionParameter);
                    if (!( status.Equals((int)Result.RemoteStatus.Normal) || status.Equals((int)Result.RemoteStatus.NotFound) ))
                    {
                        MyLogger.Write(MyLogWriter.PRICE_REVISION, string.Empty, MyLogWriter.GetPriceRevisionMessage(status, null));
                        return status;  // ADD 2010/07/02 �ُ�I�������ꍇ�́A�������s��Ȃ�
                        //break;
                    }
                }
                if (priceRevisionParameter == null)
                {
                    priceRevisionParameter = new PriceRevisionParameter(_enterpriseCode);
                }

                #endregion  // [ ���i�������� ]
                // ADD 2008/02/03 �@�\�ǉ��F���i���� ----------<<<<<

                #region 1.5���Ή��ɂ����tFor���̉��Ɉړ�(�ꊇ�X�V)
                /*
                if (lstUsrUpdateData.Count > 0 || priceRevisionParameter.MergedPriceRevisionList.Count > 0 || offerLstPrmSet.Count > 0 || offerLstPrmSetChg.Count > 0)
                {
                    int updateDataDiv;
                    int _offerDate;

                    // DEL 2009/02/11 �@�\�ǉ��F���i�������蓮�ōs�� ---------->>>>>
                    #region �폜�R�[�h
                    //if (offerDate == 0)
                    //{
                    //    updateDataDiv = 0;  // HACK:�蓮
                    //    _offerDate = offerday;
                    //}
                    //else
                    //{
                    //    updateDataDiv = 1;  // HACK:����
                    //    _offerDate = offerDate;
                    //}
                    #endregion
                    // DEL 2009/02/11 �@�\�ǉ��F���i�������蓮�ōs�� ----------<<<<<
                    // ADD 2009/02/11 �@�\�ǉ��F���i�������蓮�ōs�� ---------->>>>>
                    updateDataDiv = 0;  // �蓮
                    _offerDate = offerDate;
                    // ADD 2009/02/11 �@�\�ǉ��F���i�������蓮�ōs�� ----------<<<<<
                    // ADD 2009/02/10 �s��Ή�[11706] ---------->>>>>
                    // �D�ǐݒ�}�X�^���}�[�W������������������ꍇ�A�����Ƃ݂Ȃ�
                    if (CanMergePrimeSettingMaster(uiCondition))
                    {
                        updateDataDiv = 1;  // ����
                    }
                    // ADD 2009/02/19 �s��Ή�[11706] ----------<<<<<
                    // DEL 2009/02/11 �@�\�ǉ����F���i�������蓮�ōs��
                    //status = _iOfferMerger.WriteMergeData(updateDataDiv, _offerDate, lstUsrUpdateData);
                    status = _iOfferMerger.WriteManual(
                        updateDataDiv,
                        _offerDate,
                        priceRevisionParameter.PriceMergeSetting,
                        priceRevisionParameter.MergedPriceRevisionList,
                        out priceRevisionParameter.RetList,
                        lstUsrUpdateData,
                        UsrUpdatePrmsetList,
                        _enterpriseCode,
                        Checker.CurrentVersion,
                        uiCondition.PrmSetNmOwFlg
                    );
                    // ADD 2009/02/03 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                    if (!status.Equals((int)Result.RemoteStatus.Normal) && !status.Equals((int)Result.RemoteStatus.NotFound))
                    {
                        MyLogger.Write(
                            MyLogWriter.MERGING,
                            MyLogWriter.GetTargetTableName(gettingOfferCondition),
                            MyLogWriter.GetMergedMessage(status, lstUsrUpdateData)
                        );
                        break;
                    }

                    // �X�V�������J�E���g
                    CountMerge(
                        userUpdatingTbsPartsCodeList,
                        userUpdatingBLGroupList,
                        userUpdatingGoodsMGroupList,
                        userUpdatingModelNameList,
                        userUpdatingPMakerList,
                        UsrUpdatePrmsetList,
                        userUpdatingPartsPosList
                    );

                    // �蓮�̏ꍇ�̏ꍇ�͕��ʃ}�X�^�̃}�[�W��1��̂�
                    if (_autoFlg == 0)
                    {
                        margedPartsPosCodeMaster = true;
                    }

                    //MyLogger.Write(
                    //    MyLogWriter.MERGING,
                    //    MyLogWriter.GetTargetTableName(gettingOfferCondition),
                    //    MyLogWriter.GetMergedMessage(status, lstUsrUpdateData)
                    //);
                    // ADD 2008/02/03 �@�\�ǉ��F�D�ǐݒ�}�X�^ ----------<<<<<
                }   // if (lstUsrUpdateData.Count > 0)

                

                #if _CONST_OFFER_DATE_
                break;  // 1�񕪂̂�
                #endif
            */
                #endregion

                #endregion  // [ ���[�U�[DB�֏����� ]

            }   // foreach (int enmOfferDate in dateSequenceList.Values)

            #region 1.5���� ADD հ�ްDB�֏�����

            // �X�V���X�g��Add
            CustomSerializeArrayList lstUsrUpdateData = new CustomSerializeArrayList();
            if (userUpdatingPMakerList.Count > 0)       // ���[�U�[���i���[�J�[���̍X�V�f�[�^���X�g
                lstUsrUpdateData.Add(userUpdatingPMakerList);
            if (userUpdatingModelNameList.Count > 0)    // ���[�U�[�Ԏ�}�X�^�X�V�f�[�^���X�g
                lstUsrUpdateData.Add(userUpdatingModelNameList);
            if (userUpdatingGoodsMGroupList.Count > 0)  // ���[�U�[���i�����ރ}�X�^�X�V�f�[�^���X�g
                lstUsrUpdateData.Add(userUpdatingGoodsMGroupList);
            if (userUpdatingBLGroupList.Count > 0)      // ���[�U�[BL�R�[�h�X�V�f�[�^���X�g
                lstUsrUpdateData.Add(userUpdatingBLGroupList);
            if (userUpdatingTbsPartsCodeList.Count > 0) // ���[�U�[BL�O���[�v�}�X�^�X�V�f�[�^���X�g
                lstUsrUpdateData.Add(userUpdatingTbsPartsCodeList);
            if (userUpdatingPartsPosList.Count > 0)     // ���[�U�[���ʃ}�X�^�X�V�f�[�^���X�g
                lstUsrUpdateData.Add(userUpdatingPartsPosList);

            if (lst == null) lst = new CustomSerializeArrayList();

            lst.Add(writeGoodsList);
            lst.Add(writePricesList);
            lst.Add(deletePriceList);

            priceRevisionParameter.MergedPriceRevisionList = lst;
            priceRevisionParameter.PriceMergeSetting = pricMergeSt;
            CountPriceRevision(writeGoodsList, writePricesList);

            if (UsrUpdatePrmsetList == null) UsrUpdatePrmsetList = new CustomSerializeArrayList();
            if (offerLstPrmSet != null && offerLstPrmSet.Count > 0) UsrUpdatePrmsetList.Add(offerLstPrmSet);
            if (offerLstPrmSetChg != null && offerLstPrmSetChg.Count > 0) UsrUpdatePrmsetList.Add(offerLstPrmSetChg);


            // �X�V���X�g�����݂���ꍇ
            if (lstUsrUpdateData.Count > 0 || priceRevisionParameter.MergedPriceRevisionList.Count > 0 || offerLstPrmSet.Count > 0 || offerLstPrmSetChg.Count > 0)
            {
                int updateDataDiv;
                int _offerDate;

                updateDataDiv = 0;  // �蓮
                _offerDate = offerDate;
                prmSetAllUpdCount = 0;

                // �����t���O�������
                if (_autoFlg == 1) updateDataDiv = 1;  // ����

                object updateMasterobj = UpdateMaster;

                status = _iOfferMerger.WriteManual(
                    updateDataDiv,
                    _offerDate,
                    priceRevisionParameter.PriceMergeSetting,
                    priceRevisionParameter.MergedPriceRevisionList,
                    out priceRevisionParameter.RetList,
                    lstUsrUpdateData,
                    UsrUpdatePrmsetList,
                    _enterpriseCode,
                    Checker.CurrentVersion,
                    uiCondition.PrmSetNmOwFlg,
                    ref prmSetAllUpdCount,
                    updateMasterobj,
                    partsPsDate
                );
                // ADD 2009/02/03 �@�\�ǉ��F�D�ǐݒ�}�X�^ ---------->>>>>
                if (!status.Equals((int)Result.RemoteStatus.Normal) && !status.Equals((int)Result.RemoteStatus.NotFound))
                {
                    //MyLogger.Write(MyLogWriter.MERGING, MyLogWriter.GetTargetTableName(gettingOfferCondition), MyLogWriter.GetMergedMessage(status, lstUsrUpdateData));
                    //break;
                }



                // �X�V�������J�E���g
                CountMerge(
                    userUpdatingTbsPartsCodeList,
                    userUpdatingBLGroupList,
                    userUpdatingGoodsMGroupList,
                    userUpdatingModelNameList,
                    userUpdatingPMakerList,
                    UsrUpdatePrmsetList,
                    userUpdatingPartsPosList
                );

                // ÷��۸ޏ����� (�񋟃f�[�^�擾)
                string writeUserDBLogText = string.Empty;

                if (userUpdatingPMakerList != null) writeUserDBLogText += ( "Ұ��Ͻ� " + userUpdatingPMakerList.Count + "��" + "\r\n" );
                if (userUpdatingModelNameList != null) writeUserDBLogText += ( "�Ԏ�Ͻ� " + userUpdatingModelNameList.Count + "��" + "\r\n" );
                if (userUpdatingGoodsMGroupList != null) writeUserDBLogText += ( "������Ͻ� " + userUpdatingGoodsMGroupList.Count + "��" + "\r\n" );
                if (userUpdatingBLGroupList != null) writeUserDBLogText += ( "BL��ٰ��Ͻ� " + userUpdatingBLGroupList.Count + "��" + "\r\n" );
                if (userUpdatingTbsPartsCodeList != null) writeUserDBLogText += ( "BL����Ͻ� " + userUpdatingTbsPartsCodeList.Count + "��" + "\r\n" );
                if (userUpdatingPartsPosList != null) writeUserDBLogText += ( "����Ͻ� " + userUpdatingPartsPosList.Count + "��" + "\r\n" );
                if (UsrUpdatePrmsetList != null) writeUserDBLogText += ( "�D�ǐݒ�Ͻ� " + prmSetAllUpdCount + "��" + "\r\n" );
                if (writeGoodsList != null) writeUserDBLogText += ( "���iϽ�" + writeGoodsList.Count + "��" + "\r\n" );
                if (writePricesList != null) writeUserDBLogText += ( "���iϽ�" + writePricesList.Count + "��" + "\r\n" );

                if (writeUserDBLogText != string.Empty)
                {
                    writer = new StreamWriter(@"" + workDir + @"\Log\PMCMN06200S\PriceRevision.txt", true, System.Text.Encoding.GetEncoding("shift-jis"));
                    writer.Write(DateTime.Now + " հ�ްDB�X�V���� " + "status = " + status + "\r\n" + writeUserDBLogText + "\r\n");
                    writer.Flush();
                    if (writer != null) writer.Close();
                }
            }
            #endregion

            // �o�[�W�������X�V DELETE
            //status = Checker.UpdateVersion();   // ADD 2009/02/20 �s��Ή�[11707]

            #region �ر����
            if (writeGoodsList != null) writeGoodsList.Clear();
            if (writePricesList != null) writePricesList.Clear();
            if (deletePriceList != null) deletePriceList.Clear();
            if (lst != null) lst.Clear();
            if (userUpdatingPMakerList != null) userUpdatingPMakerList.Clear();
            if (userUpdatingModelNameList != null) userUpdatingModelNameList.Clear();
            if (userUpdatingGoodsMGroupList != null) userUpdatingGoodsMGroupList.Clear();
            if (userUpdatingBLGroupList != null) userUpdatingBLGroupList.Clear();
            if (userUpdatingTbsPartsCodeList != null) userUpdatingTbsPartsCodeList.Clear();
            if (userUpdatingPartsPosList != null) userUpdatingPartsPosList.Clear();
            if (priceRevisionParameter.MergedPriceRevisionList != null) priceRevisionParameter.MergedPriceRevisionList.Clear();
            if (offerLstPrmSetChg != null) offerLstPrmSetChg.Clear();
            if (offerLstPrmSet != null) offerLstPrmSet.Clear();
            if (UsrUpdatePrmsetList != null) UsrUpdatePrmsetList.Clear();
            if (lstUsrUpdateData != null) lstUsrUpdateData.Clear();
            if (userUpdatingPMakerList != null) userUpdatingPMakerList.Clear();
            if (userUpdatingModelNameList != null) userUpdatingModelNameList.Clear();
            if (userUpdatingGoodsMGroupList != null) userUpdatingGoodsMGroupList.Clear();
            if (userUpdatingBLGroupList != null) userUpdatingBLGroupList.Clear();
            if (userUpdatingTbsPartsCodeList != null) userUpdatingTbsPartsCodeList.Clear();
            if (userUpdatingPartsPosList != null) userUpdatingPartsPosList.Clear();
            if (offerLstPrmSetChg != null) offerLstPrmSetChg.Clear();
            if (offerLstPrmSet != null) offerLstPrmSet.Clear();
            #endregion

            return status;
        }

        #region �R���o�[�g����[�񋟁����[�U�[]
        /// <summary>
        /// �񋟎Ԏ햼�̃f�[�^�����[�U�[�Ԏ햼�̃f�[�^�ɕϊ�����
        /// </summary>
        /// <param name="ofrPMakerNm">�񋟎Ԏ햼�̃f�[�^</param>
        /// <param name="usrPMakerNm">[�o��]���[�U�[�Ԏ햼�̃f�[�^</param>
        private bool ConvertPMakerNm(PMakerNmWork ofrPMakerNm, ref MakerUWork usrPMakerNm)
        {
            if (usrPMakerNm == null)
            {
                usrPMakerNm = new MakerUWork();

                usrPMakerNm.EnterpriseCode = _enterpriseCode;
                usrPMakerNm.GoodsMakerCd = ofrPMakerNm.PartsMakerCode; // ���i���[�J�[�R�[�h
            }
            else
            {
                if (usrPMakerNm.LogicalDeleteCode != 0)
                    return false;
            }
            usrPMakerNm.OfferDate = ConverIntToDateTime(ofrPMakerNm.OfferDate); // �񋟓��t
            usrPMakerNm.OfferDataDiv = 1; // �񋟃f�[�^

            usrPMakerNm.MakerName = ofrPMakerNm.PartsMakerFullName; // ���i���[�J�[���́i�S�p�j
            usrPMakerNm.MakerKanaName = ofrPMakerNm.PartsMakerHalfName; // ���i���[�J�[���́i���p�j
            return true;
        }

        /// <summary>
        /// �񋟎Ԏ햼�̃f�[�^�����[�U�[�Ԏ햼�̃f�[�^�ɕϊ�����
        /// </summary>
        /// <param name="ofrModelName">�񋟎Ԏ햼�̃f�[�^</param>
        /// <param name="usrModelName">[�o��]���[�U�[�Ԏ햼�̃f�[�^</param>
        private bool ConvertModelName(ModelNameWork ofrModelName, ref ModelNameUWork usrModelName)
        {
            if (usrModelName == null)
            {
                usrModelName = new ModelNameUWork();

                usrModelName.EnterpriseCode = _enterpriseCode;
                usrModelName.ModelUniqueCode = ofrModelName.ModelUniqueCode; // �Ԏ�R�[�h�i���j�[�N�j
                usrModelName.MakerCode = ofrModelName.MakerCode; // ���[�J�[�R�[�h
                usrModelName.ModelCode = ofrModelName.ModelCode; // �Ԏ�R�[�h
                usrModelName.ModelSubCode = ofrModelName.ModelSubCode; // �Ԏ�T�u�R�[�h
            }
            else
            {
                if (usrModelName.LogicalDeleteCode != 0)
                    return false;
            }
            usrModelName.OfferDate = ConverIntToDateTime(ofrModelName.OfferDate); // �񋟓��t
            usrModelName.OfferDataDiv = 1; // �񋟃f�[�^

            usrModelName.ModelFullName = ofrModelName.ModelFullName; // �Ԏ�S�p����
            usrModelName.ModelHalfName = ofrModelName.ModelHalfName; // �Ԏ피�p����
            usrModelName.ModelAliasName = ofrModelName.ModelAliasName; // �Ԏ�Ăі�����
            return true;
        }

        /// <summary>
        /// �񋟏��i�����ރR�[�h�f�[�^�����[�U�[���i�����ރR�[�h�f�[�^�ɕϊ�����
        /// </summary>
        /// <param name="owFlg">�㏑���t���O</param>
        /// <param name="ofrGoodsMGroup">�񋟏��i�����ރR�[�h�f�[�^</param>
        /// <param name="usrGoodsMGroup">[�o��]���[�U�[���i�����ރR�[�h�f�[�^</param>
        private bool ConvertGoodsMGroup(bool owFlg, GoodsMGroupWork ofrGoodsMGroup, ref GoodsGroupUWork usrGoodsMGroup)
        {
            if (usrGoodsMGroup == null)
            {
                usrGoodsMGroup = new GoodsGroupUWork();

                usrGoodsMGroup.EnterpriseCode = _enterpriseCode;
                usrGoodsMGroup.OfferDataDiv = 1; // �񋟃f�[�^
                usrGoodsMGroup.GoodsMGroup = ofrGoodsMGroup.GoodsMGroup; // ���i�����ރR�[�h

                usrGoodsMGroup.OfferDate = ConverIntToDateTime(ofrGoodsMGroup.OfferDate); // �񋟓��t
                usrGoodsMGroup.GoodsMGroupName = ofrGoodsMGroup.GoodsMGroupName; // ���i�����ޖ���
            }
            else
            {
                if (usrGoodsMGroup.LogicalDeleteCode != 0)
                    return false;
                if (owFlg)
                {
                    usrGoodsMGroup.OfferDate = ConverIntToDateTime(ofrGoodsMGroup.OfferDate); // �񋟓��t
                    usrGoodsMGroup.OfferDataDiv = 1; // �񋟃f�[�^

                    usrGoodsMGroup.GoodsMGroupName = ofrGoodsMGroup.GoodsMGroupName; // ���i�����ޖ���
                }
            }
            return true;
        }

        /// <summary>
        /// ��BL�O���[�v�f�[�^�����[�U�[BL�O���[�v�f�[�^�ɕϊ�����
        /// </summary>
        /// <param name="owFlg">�㏑���t���O</param>
        /// <param name="ofrBLGroup">��BL�O���[�v�f�[�^</param>
        /// <param name="usrBLGroup">[�o��]���[�U�[BL�O���[�v�f�[�^</param>
        private bool ConvertBLGroup(bool owFlg, BLGroupWork ofrBLGroup, ref BLGroupUWork usrBLGroup)
        {
            if (usrBLGroup == null)
            {
                usrBLGroup = new BLGroupUWork();

                usrBLGroup.EnterpriseCode = _enterpriseCode;
                usrBLGroup.OfferDataDiv = 1; // �񋟃f�[�^
                usrBLGroup.BLGroupCode = ofrBLGroup.BLGroupCode; // BL�O���[�v�R�[�h
                usrBLGroup.GoodsMGroup = ofrBLGroup.GoodsMGroup; // ���i�����ރR�[�h

                usrBLGroup.OfferDate = ConverIntToDateTime(ofrBLGroup.OfferDate); // �񋟓��t

                usrBLGroup.BLGroupName = ofrBLGroup.BLGroupName; // BL�O���[�v�R�[�h����
                usrBLGroup.BLGroupKanaName = ofrBLGroup.BLGroupKanaName; // BL�O���[�v�R�[�h����

            }
            else
            {
                if (usrBLGroup.LogicalDeleteCode != 0)
                    return false;
                if (owFlg)
                {
                    usrBLGroup.OfferDate = ConverIntToDateTime(ofrBLGroup.OfferDate); // �񋟓��t
                    usrBLGroup.OfferDataDiv = 1; // �񋟃f�[�^

                    usrBLGroup.BLGroupName = ofrBLGroup.BLGroupName; // BL�O���[�v�R�[�h����
                    usrBLGroup.BLGroupKanaName = ofrBLGroup.BLGroupKanaName; // BL�O���[�v�R�[�h����
                }
            }

            return true;
        }

        /// <summary>
        /// ��BL�f�[�^�����[�U�[BL�f�[�^�ɕϊ�����
        /// </summary>
        /// <param name="owFlg">�㏑���t���O</param>
        /// <param name="ofrBL">��BL�f�[�^</param>
        /// <param name="usrBL">[�o��]���[�U�[BL�f�[�^</param>
        private bool ConvertBL(bool owFlg, TbsPartsCodeWork ofrBL, ref BLGoodsCdUWork usrBL)
        {
            if (usrBL == null)
            {
                usrBL = new BLGoodsCdUWork();

                usrBL.EnterpriseCode = _enterpriseCode;
                usrBL.OfferDataDiv = 1; // �񋟃f�[�^
                usrBL.BLGoodsCode = ofrBL.TbsPartsCode; // BL�R�[�h
                usrBL.BLGoodsGenreCode = ofrBL.EquipGenre; // ��������
                usrBL.BLGroupCode = ofrBL.BLGroupCode; // BL�O���[�v�R�[�h
                usrBL.GoodsRateGrpCode = ofrBL.GoodsMGroup; // ���i�����ރR�[�h

                usrBL.OfferDate = ConverIntToDateTime(ofrBL.OfferDate); // �񋟓��t

                usrBL.BLGoodsFullName = ofrBL.TbsPartsFullName; // BL�R�[�h���́i�S�p�j
                usrBL.BLGoodsHalfName = ofrBL.TbsPartsHalfName; // BL�R�[�h���́i���p�j
            }
            else
            {
                if (usrBL.LogicalDeleteCode != 0)
                    return false;
                if (owFlg)
                {
                    usrBL.OfferDate = ConverIntToDateTime(ofrBL.OfferDate); // �񋟓��t
                    usrBL.OfferDataDiv = 1; // �񋟃f�[�^

                    usrBL.BLGoodsFullName = ofrBL.TbsPartsFullName; // BL�R�[�h���́i�S�p�j
                    usrBL.BLGoodsHalfName = ofrBL.TbsPartsHalfName; // BL�R�[�h���́i���p�j
                }
            }

            return true;
        }

        /*/// <summary>
        /// �񋟎d����f�[�^�����[�U�[�d����f�[�^�ɕϊ�����
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="ofrSupplier">�񋟎d����f�[�^</param>
        /// <param name="usrSupplier">[�o��]���[�U�[�d����f�[�^</param>
        private bool ConvertSupplier(string enterpriseCode, OfrSupplierWork ofrSupplier, ref SupplierWork usrSupplier)
        {
            if (usrSupplier == null)
            {
                usrSupplier = new SupplierWork();

                usrSupplier.EnterpriseCode = enterpriseCode;
                usrSupplier.SupplierCd = ofrSupplier.SupplierCd; // �d����R�[�h
                usrSupplier.SupplierNm1 = ofrSupplier.SupplierNm1; // �d���於
                usrSupplier.SupplierKana = ofrSupplier.SupplierKana; // �d����J�i
                usrSupplier.SupplierSnm = ofrSupplier.SupplierSnm; // �d���旪��
            }
            else
            {
                if (usrSupplier.LogicalDeleteCode != 0)
                    return false;
                if (overwriteFlg)
                {
                    usrSupplier.SupplierNm1 = ofrSupplier.SupplierNm1; // �d���於
                    usrSupplier.SupplierKana = ofrSupplier.SupplierKana; // �d����J�i
                    usrSupplier.SupplierSnm = ofrSupplier.SupplierSnm; // �d���旪��
                }
            }

            return true;
        }*/

        /// <summary>
        /// �� ���ʃf�[�^�����[�U�[ ���ʃf�[�^�ɕϊ�����
        /// </summary>
        /// <param name="owFlg">�㏑���t���O</param>
        /// <param name="partsPosCodeWork">�� ���ʃf�[�^</param>
        /// <param name="usrPartsPos">[�o��]���[�U�[ ���ʃf�[�^</param>
        /// <param name="BigOfferDiv"></param>
        /// <param name="SearchType"></param>
        private bool ConvertPartsPos(bool owFlg, PartsPosCodeWork partsPosCodeWork, ref PartsPosCodeUWork usrPartsPos, int SearchType, int BigOfferDiv)
        {
            #region DELETE 1����
            ///////<summary> ��^�񋟋敪 �_���</summary>
            //PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData);
            ///////<summary> ����B�^�C�v�i�O���j �_��� </summary>
            //PurchaseStatus ps2 = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData);
            ///////<summary> �����^�C�v�i��{�j �_��� </summary>
            //PurchaseStatus ps3 = LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicOfferData);
            //bool bigFlg = false; // ��^�_��t���O
            //bool exteriorFlg = false; // �O���_��t���O
            //bool basicFlg = false; // ��{�_��t��
            //if (ps == PurchaseStatus.Contract || ps == PurchaseStatus.Trial_Contract) // ��^�_��Ȃ��̏ꍇ�}�[�W���Ȃ�
            //    bigFlg = true;
            //if (ps2 == PurchaseStatus.Contract || ps2 == PurchaseStatus.Trial_Contract) // �O���_��Ȃ��̏ꍇ�}�[�W���Ȃ�
            //    exteriorFlg = true;
            //else if (ps3 == PurchaseStatus.Contract || ps3 == PurchaseStatus.Trial_Contract) // ��{�_��Ȃ��̏ꍇ�}�[�W���Ȃ�
            //    basicFlg = true;
            //if (usrPartsPos == null)
            //{
            //    if ((bigFlg && partsPosCodeWork.BigCarOfferDiv == 0)
            //        || (bigFlg == false && partsPosCodeWork.BigCarOfferDiv == 1))
            //        return false;
            //    if ((exteriorFlg && partsPosCodeWork.SearchPartsType != 20)
            //        || (basicFlg && partsPosCodeWork.SearchPartsType != 10))
            //        return false;
            //    //string key = string.Format("{0}{1}", partsPosCodeWork.SearchPartsPosCode, partsPosCodeWork.TbsPartsCode);
            //    //if (lstPartsPos.Contains(key))
            //    //    return false;
            //    //lstPartsPos.Add(key);

            //    usrPartsPos = new PartsPosCodeUWork();

            //    usrPartsPos.EnterpriseCode = _enterpriseCode;
            //    usrPartsPos.CustomerCode = 0; // ���ʐݒ�
            //    usrPartsPos.SearchPartsPosCode = partsPosCodeWork.SearchPartsPosCode; // �������ʃR�[�h
            //    usrPartsPos.SearchPartsPosName = partsPosCodeWork.SearchPartsPosName; // �������ʃR�[�h����
            //    usrPartsPos.PosDispOrder = partsPosCodeWork.PosDispOrder; // �������ʕ\������
            //    usrPartsPos.TbsPartsCode = partsPosCodeWork.TbsPartsCode; // BL�R�[�h
            //    usrPartsPos.TbsPartsCdDerivedNo = partsPosCodeWork.TbsPartsCdDerivedNo; // BL�R�[�h�}��
            //}
            //else
            //{
            //    if ((bigFlg && partsPosCodeWork.BigCarOfferDiv == 0)
            //        || (bigFlg == false && partsPosCodeWork.BigCarOfferDiv == 1))
            //        return false;
            //    if ((exteriorFlg && partsPosCodeWork.SearchPartsType != 20)
            //        || (basicFlg && partsPosCodeWork.SearchPartsType != 10))
            //        return false;
            //    if (usrPartsPos.LogicalDeleteCode != 0)
            //        return false;
            //    if (owFlg)
            //    {
            //        usrPartsPos.SearchPartsPosName = partsPosCodeWork.SearchPartsPosName; // �������ʃR�[�h����
            //    }
            //}
            #endregion

            if (partsPosCodeWork.BigCarOfferDiv == BigOfferDiv && partsPosCodeWork.SearchPartsType == SearchType)
            {
                if (usrPartsPos == null)
                {
                    usrPartsPos = new PartsPosCodeUWork();

                    usrPartsPos.EnterpriseCode = _enterpriseCode;
                    usrPartsPos.CustomerCode = 0; // ���ʐݒ�
                    usrPartsPos.SearchPartsPosCode = partsPosCodeWork.SearchPartsPosCode; // �������ʃR�[�h
                    usrPartsPos.SearchPartsPosName = partsPosCodeWork.SearchPartsPosName; // �������ʃR�[�h����
                    usrPartsPos.PosDispOrder = partsPosCodeWork.PosDispOrder; // �������ʕ\������
                    usrPartsPos.TbsPartsCode = partsPosCodeWork.TbsPartsCode; // BL�R�[�h
                    usrPartsPos.TbsPartsCdDerivedNo = partsPosCodeWork.TbsPartsCdDerivedNo; // BL�R�[�h�}��
                    usrPartsPos.OfferDate = ConverIntToDateTime(partsPosCodeWork.OfferDate); // �񋟓��t
                    usrPartsPos.OfferDataDiv = 1; // ��
                }
                else
                {
                    usrPartsPos.SearchPartsPosName = partsPosCodeWork.SearchPartsPosName; // �������ʃR�[�h����
                    usrPartsPos.OfferDate = ConverIntToDateTime(partsPosCodeWork.OfferDate); // �񋟓��t
                    usrPartsPos.OfferDataDiv = 1; // ��
                }

                partsPsDate = partsPosCodeWork.OfferDate;

            }
            else
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// ���t�ϊ�����(int -> DateTime)
        /// </summary>
        /// <param name="date">�ϊ�������t�f�[�^(YYYYMMDD)</param>
        /// <returns></returns>
        private DateTime ConverIntToDateTime(int date)
        {
            if (date < 0)
                return DateTime.MinValue;
            int year = date / 10000;
            int month = ( date % 10000 ) / 100;
            int day = ( date % 10000 ) % 100;
            if (year == 0 || month == 0 || day == 0)
                return DateTime.MinValue;
            return new DateTime(year, month, day);
        }
        #endregion

        #endregion  // Private Methods
    }
}
