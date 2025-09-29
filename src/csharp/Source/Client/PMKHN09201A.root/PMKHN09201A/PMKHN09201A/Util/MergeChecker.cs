//****************************************************************************//
// �V�X�e��         : �񋟃f�[�^�X�V����
// �v���O��������   : �@�\�ǉ��ɔ����ǉ��N���X
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2009/02/03  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : ���� ���n
// �� �� ��  2012/02/08  �C�����e : �O���I�v�V�����̔�����@�̕s����C��
//----------------------------------------------------------------------------//
//#define _VERSION_CHECK_IS_FALSE_

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Controller;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Util
{
    using UserUpdatingPrimeSettingPair = Pair<ArrayList, ArrayList>;

    #region <��������/>

    /// <summary>
    /// �������ʃN���X
    /// </summary>
    public static class Result
    {
        // TODO:���ʂ̒萔�ɒl�����킹�邱��
        /// <summary>
        /// �����[�g�̏������ʂ̗񋓑�
        /// </summary>
        public enum RemoteStatus : int
        {
            /// <summary>����I��</summary>
            Normal = 0,
            /// <summary>����0</summary>
            NotFound = 4
        }

        /// <summary>
        /// �������ʃR�[�h�񋓑�
        /// </summary>
        public enum Code : int
        {
            /// <summary>����</summary>
            Normal = (int)RemoteStatus.Normal
        }
    }

    #endregion  // <��������/>

    #region <�}�[�W�`�F�b�N/>

    /// <summary>
    /// �}�[�W�̃`�F�b�N�҃N���X
    /// </summary>
    public sealed class MergeChecker
    {
        #region <Const/>

        /// <summary>
        /// �Ώۃf�[�^�̗񋓑�
        /// </summary>
        public enum TargetData : int
        {
            /// <summary>BL�R�[�h�}�X�^</summary>
            BLCodeMaster,
            /// <summary>BL�O���[�v�}�X�^</summary>
            BLGroupMaster,
            /// <summary>�����ރ}�X�^</summary>
            MiddleGenreMaster,
            /// <summary>�Ԏ�}�X�^</summary>
            CarTypeMaster,
            /// <summary>���[�J�[�}�X�^</summary>
            MakerMaster,
            /// <summary>���ʃ}�X�^</summary>
            PartsPOSCodeMaster,
            /// <summary>���i����</summary>
            PriceRevision
        }

        #endregion  // <Const/>

        #region <���݂̃o�[�W����/>

        /// <summary>���݂̃o�[�W����</summary>
        private string _currentVersion;
        /// <summary>
        /// ���݂̃o�[�W�������擾���܂��B
        /// </summary>
        public string CurrentVersion { get { return _currentVersion; } }

        #endregion  // <���݂̃o�[�W����/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public MergeChecker() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// �}�[�W�ς݂����肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�}�[�W�ς�<br/>
        /// <c>false</c>:�}�[�W�ς݂ł͂Ȃ�
        /// </returns>
        public bool IsMerged()
        {
            string msg = string.Empty;
            return IsMerged(out msg);
        }

        /// <summary>
        /// �}�[�W�ς݂����肵�܂��B
        /// </summary>
        /// <param name="msg">���s���ʂ̃��b�Z�[�W</param>
        /// <returns>
        /// <c>true</c> :�}�[�W�ς�<br/>
        /// <c>false</c>:�}�[�W�ς݂ł͂Ȃ�
        /// </returns>
        public bool IsMerged(out string msg)
        {
            msg = string.Empty;
        #if _VERSION_CHECK_IS_FALSE_
            msg = "�}�[�W���K�v�ł�";
            return false;
        #else
            // �o�[�W�����`�F�b�N�����[�g�̌Ăяo���i�}�[�W�`�F�b�N���\�b�h�j
            VersionCheckAcs realChecker = new VersionCheckAcs();
            {
                int mergeCheckResult = 0;
                int status = realChecker.MergeCheck(out mergeCheckResult, out _currentVersion);

                //mergeCheckResult = 2;
                if (status.Equals((int)Result.RemoteStatus.Normal))
                {
                    switch (mergeCheckResult)
                    {
                        case 0: msg = "�}�[�W�ς�";     break;
                        case 1: msg = "���i����������"; break;
                        case 2: msg = "���i���������s"; break;
                    }
                    if (mergeCheckResult == 0)
                        return mergeCheckResult.Equals(0);   // 0:����/1:������/2:�����s
                    else
                        return mergeCheckResult.Equals(1);
                }
                msg = "�����[�g�G���[(status=" + status.ToString() + ")";
            }

            // -- UPD 2010/06/19 --------------------------->>>
            //�����[�g�G���[�̏ꍇ�͏��������Ȃ��悤�ɂ��邽�߁ATrue�Ƃ���
            //return false;
            return true;  
            // -- UPD 2010/06/19 ---------------------------<<<
#endif
        }

        /// <summary>
        /// �o�[�W�������X�V���܂��B
        /// </summary>
        /// <returns>�����[�g�̌��ʃR�[�h</returns>
        public int UpdateVersion()
        {
            VersionCheckAcs realChecker = new VersionCheckAcs();
            {
                return realChecker.UpdateVersion(ref _currentVersion);
            }
        }

        /// <summary>
        /// <c>ArrayList</c>��<c>null</c>�܂��͋󂩔��肵�܂��B
        /// </summary>
        /// <param name="arrayList"><c>ArrayList</c>���p���������X�g</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>�܂��͋�ł���B<br/>
        /// <c>false</c>:�v�f����
        /// </returns>
        public static bool IsNullOrEmptyArrayList(ArrayList arrayList)
        {
            return arrayList == null || arrayList.Count.Equals(0);
        }
    }

    #endregion  // <�}�[�W�`�F�b�N/>

    #region <�R���t�B�O/>

    /// <summary>
    /// �����\���̍��ڃN���X
    /// </summary>
    public sealed class ProcessConfigItem
    {
        #region <�I��/>

        /// <summary>�I��</summary>
        private bool _selected;
        /// <summary>
        /// �I���̃A�N�Z�T
        /// </summary>
        /// <value>�I��</value>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }

        #endregion  // <�I��/>

        #region <����ID�i�Ώۃf�[�^ID�j/>

        /// <summary>����ID�i�Ώۃf�[�^ID�j</summary>
        private string _processId;
        /// <summary>
        /// ����ID�i�Ώۃf�[�^ID�j�̃A�N�Z�T
        /// </summary>
        /// <value>����ID�i�Ώۃf�[�^ID�j</value>
        public string ProcessId
        {
            get { return _processId; }
            set { _processId = value; }
        }

        #endregion  // <����ID�i�Ώۃf�[�^ID�j/>

        #region <�������́i�Ώۃf�[�^���j/>�j

        /// <summary>�������́i�Ώۃf�[�^���j</summary>
        private string _processName;
        /// <summary>
        /// �������́i�Ώۃf�[�^���j�̃A�N�Z�T
        /// </summary>
        /// <value>�������́i�Ώۃf�[�^���j</value>
        public string ProcessName
        {
            get { return _processName; }
            set { _processName = value; }
        }

        #endregion  // <����ID�i�Ώۃf�[�^ID�j/>

        #region <���̂��X�V����t���O/>

        /// <summary>���̂��X�V����t���O</summary>
        private bool _updatingName;
        /// <summary>
        /// ���̂��X�V����t���O�̃A�N�Z�T
        /// </summary>
        /// <value>���̂��X�V����t���O</value>
        public bool UpdatingName
        {
            get { return _updatingName; }
            set { _updatingName = value; }
        }

        #endregion  // <���̂��X�V����t���O/>

        #region <�O�񏈗���/>

        /// <summary>�O�񏈗���</summary>
        private DateTime _previousDate;
        /// <summary>
        /// �O�񏈗����̃A�N�Z�T
        /// </summary>
        /// <value>�O�񏈗���</value>
        public DateTime PreviousDate
        {
            get { return _previousDate; }
            set { _previousDate = value; }
        }

        /// <summary>
        /// �O�񏈗����𐔒l�\���ɕϊ����܂��B
        /// </summary>
        /// <returns>���l�\���ɕϊ����ꂽ�O�񏈗���</returns>
        public int ToPreviousDateNo()
        {
            return int.Parse(PreviousDate.ToString("yyyyMMdd"));
        }

        #endregion  // <�O�񏈗���/>

        #region <�X�V����/>

        /// <summary>�X�V����</summary>
        private int _previousCount;
        /// <summary>
        /// �X�V�����̃A�N�Z�T
        /// </summary>
        /// <value>�X�V����</value>
        public int PreviousCount
        {
            get { return _previousCount; }
            set { _previousCount = value; }
        }

        #endregion  // <�X�V����/>

        #region <�Ώی���/>

        /// <summary>�Ώی���</summary>
        private int _presentCount;
        /// <summary>
        /// �Ώی����̃A�N�Z�T
        /// </summary>
        /// <value>�Ώی���</value>
        public int PresentCount
        {
            get { return _presentCount; }
            set { _presentCount = value; }
        }

        #endregion  // <�Ώی���/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="selected">�I��</param>
        /// <param name="processId">����ID�i�Ώۃf�[�^ID�j</param>
        /// <param name="processName">�������́i�Ώۃf�[�^���́j</param>
        /// <param name="updatingName">���̂��X�V����t���O</param>
        /// <param name="previousDate">�O�񏈗���</param>
        /// <param name="previousCount">�X�V����</param>
        /// <param name="presentCount">�Ώی���</param>
        public ProcessConfigItem(
            bool selected,
            string processId,
            string processName,
            bool updatingName,
            DateTime previousDate,
            int previousCount,
            int presentCount
        )
        {
            _selected       = selected;
            _processId      = processId;
            _processName    = processName;
            _updatingName   = updatingName;
            _previousDate   = previousDate;
            _previousCount  = previousCount;
            _presentCount   = presentCount;
        }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="processId">����ID�i�Ώۃf�[�^ID�j</param>
        /// <param name="processName">�������́i�Ώۃf�[�^���́j</param>
        public ProcessConfigItem(
            string processId,
            string processName
        )  : this(false, processId, processName, false, DateTime.MinValue, 0, 0)
        { }

        #endregion  // <Constructor/>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="prevUpdDate"></param>
        /// <returns></returns>
        public static DateTime ConvertPreviousDate(string prevUpdDate)
        {
            if (string.IsNullOrEmpty(prevUpdDate.Trim()))
            {
                return DateTime.MinValue;
            }
            return DateTime.Parse(prevUpdDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rowCnt"></param>
        /// <returns></returns>
        public static int ConvertPreviousCount(string rowCnt)
        {
            if (string.IsNullOrEmpty(rowCnt.Trim()))
            {
                return 0;
            }
            return int.Parse(rowCnt);
        }
    }

    /// <summary>
    /// �����\���N���X
    /// </summary>
    public sealed class ProcessConfig
    {
        #region <�\�����ڂ̃R���N�V����/>

        /// <summary>�\�����ڂ̃}�b�v</summary>
        /// <remarks>�L�[�F����ID</remarks>
        private readonly IDictionary<string, ProcessConfigItem> _itemMap = new Dictionary<string, ProcessConfigItem>();
        /// <summary>
        /// �\�����ڂ̃}�b�v���擾���܂��B
        /// </summary>
        /// <value>�\�����ڂ̃}�b�v</value>
        private IDictionary<string, ProcessConfigItem> ItemMap { get { return _itemMap; } }

        #endregion  // <�\�����ڂ̃R���N�V����/>

        #region <BL�R�[�h�}�X�^/>

        /// <summary>BL�R�[�h�}�X�^��ID</summary>
        public const string BL_CODE_MASTER_ID = "BLGOODSCDURF";
        /// <summary>BL�R�[�h�}�X�^�̖���</summary>
        public const string BL_CODE_MASTER_NAME = "BL�R�[�h�}�X�^";

        /// <summary>
        /// BL�R�[�h�}�X�^�̏����\���̍��ڂ��擾���܂��B
        /// </summary>
        /// <returns>BL�R�[�h�}�X�^�̏����\���̍���</returns>
        public ProcessConfigItem BLCodeMaster
        {
            get
            {
                ProcessConfigItem item = this[BL_CODE_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(BL_CODE_MASTER_ID, BL_CODE_MASTER_NAME);
            }
        }

        #endregion  // <BL�R�[�h�}�X�^/>

        #region <BL�O���[�v�}�X�^/>

        /// <summary>BL�O���[�v�}�X�^��ID</summary>
        public const string BL_GROUP_MASTER_ID = "BLGROUPURF";
        /// <summary>BL�O���[�v�}�X�^�̖���</summary>
        public const string BL_GROUP_MASTER_NAME = "BL�O���[�v�}�X�^";

        /// <summary>
        /// BL�O���[�v�}�X�^�̏����\���̍��ڂ��擾���܂��B
        /// </summary>
        /// <returns>BL�O���[�v�}�X�^�̏����\���̍���</returns>
        public ProcessConfigItem BLGroupMaster
        {
            get
            {
                ProcessConfigItem item = this[BL_GROUP_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(BL_GROUP_MASTER_ID, BL_GROUP_MASTER_NAME);
            }
        }

        #endregion  // <BL�O���[�v�}�X�^/>

        #region <�����ރ}�X�^/>

        /// <summary>�����ރ}�X�^��ID</summary>
        public const string MIDDLE_GENRE_MASTER_ID = "GOODSGROUPURF";
        /// <summary>�����ރ}�X�^�̖���</summary>
        public const string MIDDLE_GENRE_MASTER_NAME = "�����ރ}�X�^";

        /// <summary>
        /// �����ރ}�X�^�̏����\���̍��ڂ��擾���܂��B
        /// </summary>
        /// <returns>�����ރ}�X�^�̏����\���̍���</returns>
        public ProcessConfigItem MiddleGenreMaster
        {
            get
            {
                ProcessConfigItem item = this[MIDDLE_GENRE_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(MIDDLE_GENRE_MASTER_ID, MIDDLE_GENRE_MASTER_NAME);
            }
        }

        #endregion  // <�����ރ}�X�^/>

        #region <�Ԏ�}�X�^/>

        /// <summary>�Ԏ�}�X�^��ID</summary>
        public const string MODEL_NAME_MASTER_ID = "MODELNAMEURF";
        /// <summary>�Ԏ�}�X�^�̖���</summary>
        public const string MODEL_NAME_MASTER_NAME = "�Ԏ�}�X�^";

        /// <summary>
        /// �Ԏ�}�X�^�̏����\���̍��ڂ��擾���܂��B
        /// </summary>
        /// <returns>�Ԏ�}�X�^�̏����\���̍���</returns>
        public ProcessConfigItem ModelNameMaster
        {
            get
            {
                ProcessConfigItem item = this[MODEL_NAME_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(MODEL_NAME_MASTER_ID, MODEL_NAME_MASTER_NAME);
            }
        }

        #endregion  // <�Ԏ�}�X�^/>

        #region <���[�J�[�}�X�^/>

        /// <summary>���[�J�[�}�X�^��ID</summary>
        public const string MAKER_MASTER_ID = "MAKERURF";
        /// <summary>���[�J�[�}�X�^�̖���</summary>
        public const string MAKER_MASTER_NAME = "���[�J�[�}�X�^";

        /// <summary>
        /// ���[�J�[�}�X�^�̏����\���̍��ڂ��擾���܂��B
        /// </summary>
        /// <returns>���[�J�[�}�X�^�̏����\���̍���</returns>
        public ProcessConfigItem MakerMaster
        {
            get
            {
                ProcessConfigItem item = this[MAKER_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(MAKER_MASTER_ID, MAKER_MASTER_NAME);
            }
        }

        #endregion  // <���[�J�[�}�X�^/>

        #region <���ʃ}�X�^/>

        /// <summary>���ʃ}�X�^��ID</summary>
        public const string PARTS_POS_CODE_MASTER_ID = "PARTSPOSCODEURF";
        /// <summary>���ʃ}�X�^�̖���</summary>
        public const string PARTS_POS_CODE_MASTER_NAME = "���ʃ}�X�^";

        /// <summary>
        /// ���ʃ}�X�^�̏����\���̍��ڂ��擾���܂��B
        /// </summary>
        /// <returns>���ʃ}�X�^�̏����\���̍���</returns>
        public ProcessConfigItem PartsPosCodeMaster
        {
            get
            {
                ProcessConfigItem item = this[PARTS_POS_CODE_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(PARTS_POS_CODE_MASTER_ID, PARTS_POS_CODE_MASTER_NAME);
            }
        }

        #endregion  // <���ʃ}�X�^/>

        #region <�D�ǐݒ�ύX�}�X�^/>

        /// <summary>�D�ǐݒ�ύX�}�X�^��ID</summary>
        public const string PRIME_SETTING_CHANGE_MASTER_ID = "PRMSETTINGCHGRF";
        /// <summary>�D�ǐݒ�ύX�}�X�^�̖���</summary>
        public const string PRIME_SETTING_CHANGE_MASTER_NAME = "�D�ǐݒ�ύX�}�X�^";

        /// <summary>
        /// �D�ǐݒ�}�X�^�̏����\���̍��ڂ��擾���܂��B
        /// </summary>
        /// <returns>�D�ǐݒ�}�X�^�̏����\���̍���</returns>
        public ProcessConfigItem PrimeSettingChangeMaster
        {
            get
            {
                ProcessConfigItem item = this[PRIME_SETTING_CHANGE_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(PRIME_SETTING_CHANGE_MASTER_ID, PRIME_SETTING_CHANGE_MASTER_NAME);
            }
        }

        #endregion  // <�D�ǐݒ�ύX�}�X�^/>

        /// <summary>
        /// 
        /// </summary>
        public DateTime LatestPreviousDateOfPrimeSetting
        {
            get
            {
                return PrimeSettingChangeMaster.PreviousDate >= PrimeSettingMaster.PreviousDate
                            ?
                        PrimeSettingChangeMaster.PreviousDate : PrimeSettingMaster.PreviousDate;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int TotalPreviousCountOfPrimeSetting
        {
            get { return PrimeSettingChangeMaster.PreviousCount + PrimeSettingMaster.PreviousCount; } 
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�̑Ώی����̍��v���擾���܂��B
        /// </summary>
        public int TotalPresentCountOfPrimeSetting
        {
            get { return PrimeSettingChangeMaster.PresentCount + PrimeSettingMaster.PresentCount; }
        }

        #region <�D�ǐݒ�}�X�^/>

        /// <summary>�D�ǐݒ�}�X�^��ID</summary>
        public const string PRIME_SETTING_MASTER_ID = "PRMSETTINGURF";
        /// <summary>�D�ǐݒ�}�X�^�̖���</summary>
        public const string PRIME_SETTING_MASTER_NAME = "�D�ǐݒ�}�X�^";

        /// <summary>
        /// �D�ǐݒ�}�X�^�̏����\���̍��ڂ��擾���܂��B
        /// </summary>
        /// <returns>�D�ǐݒ�}�X�^�̏����\���̍���</returns>
        public ProcessConfigItem PrimeSettingMaster
        {
            get
            {
                ProcessConfigItem item = this[PRIME_SETTING_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(PRIME_SETTING_MASTER_ID, PRIME_SETTING_MASTER_NAME);
            }
        }

        #endregion  // <�D�ǐݒ�}�X�^/>

        #region <���i�}�X�^/>

        /// <summary>���i�}�X�^��ID</summary>
        public const string GOODS_MASTER_ID = "GOODSURF";
        /// <summary>���i�}�X�^�̖���</summary>
        public const string GOODS_MASTER_NAME = "���i�}�X�^";

        /// <summary>
        /// ���i�}�X�^�̏����\���̍��ڂ��擾���܂��B
        /// </summary>
        /// <returns>���i�}�X�^�̏����\���̍���</returns>
        public ProcessConfigItem GoodsMaster
        {
            get
            {
                ProcessConfigItem item = this[GOODS_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(GOODS_MASTER_ID, GOODS_MASTER_NAME);
            }
        }

        #endregion  // <���i�}�X�^/>

        #region <���i�}�X�^/>

        /// <summary>���i�}�X�^��ID</summary>
        public const string GOODS_PRICE_MASTER_ID = "GOODSPRICEURF";
        /// <summary>���i�}�X�^�̖���</summary>
        public const string GOODS_PRICE_MASTER_NAME = "���i�}�X�^";

        /// <summary>
        /// ���i�}�X�^�̏����\���̍��ڂ��擾���܂��B
        /// </summary>
        /// <returns>���i�}�X�^�̏����\���̍���</returns>
        public ProcessConfigItem GoodsPriceMaster
        {
            get
            {
                ProcessConfigItem item = this[GOODS_PRICE_MASTER_ID];
                if (item != null) return item;
                return new ProcessConfigItem(GOODS_PRICE_MASTER_ID, GOODS_PRICE_MASTER_NAME);
            }
        }

        #endregion  // <���i�}�X�^/>

        #region <���i����/>

        /// <summary>���i������ID</summary>
        public const string PRICE_REVISION_ID = "PriceRevision";
        /// <summary>���i�����̖���</summary>
        public const string PRICE_REVISION_NAME = "���i����";

        /// <summary>
        /// ���i�����̏����\���̍��ڂ��擾���܂��B
        /// </summary>
        /// <value>���i�����̏����\���̍���</value>
        public ProcessConfigItem PriceRevision
        {
            get
            {
                ProcessConfigItem item = this[PRICE_REVISION_ID];
                if (item != null) return item;
                return new ProcessConfigItem(PRICE_REVISION_ID, PRICE_REVISION_NAME);
            }
        }

        /// <summary>
        /// ���i�����̏����\�����X�V���܂��B
        /// </summary>
        /// <remarks>���i�����̑O�񏈗����͏��i�}�X�^�Ɖ��i�}�X�^�ōŋ߂̕���ݒ�</remarks>
        public void UpdatePriceRevision()
        {
            // ���i�����̑O�񏈗����͏��i�}�X�^�Ɖ��i�}�X�^�ōŋ߂̕���ݒ�
            ProcessConfigItem previousItem = (
                GoodsMaster.PreviousDate >= GoodsPriceMaster.PreviousDate ? GoodsMaster : GoodsPriceMaster
            );

            //ProcessConfigItem previousItem = GoodsMaster;

            PriceRevision.PreviousDate = previousItem.PreviousDate;
            PriceRevision.PreviousCount = previousItem.PreviousCount; // MOD 2009/02/23 �s��Ή�[11802] .PreviousCount��.PresentCount
            PriceRevision.PresentCount = GoodsMaster.PresentCount + GoodsPriceMaster.PresentCount;
        }

        #endregion  // <���i����/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public ProcessConfig() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���������܂��B
        /// </summary>
        /// <param name="processConfigItemList">�����\���̍��ڂ̃��X�g</param>
        public void Initialize(IList<ProcessConfigItem> processConfigItemList)
        {
            ItemMap.Clear();
            foreach (ProcessConfigItem item in processConfigItemList)
            {
                if (!ItemMap.ContainsKey(item.ProcessId))
                {
                    ItemMap.Add(item.ProcessId, item);
                }
            }

            UpdatePriceRevision();
        }

        #region <Indexer/>

        /// <summary>
        /// �C���f�N�T
        /// </summary>
        /// <param name="processId">����ID�i�Ώۃf�[�^ID�j</param>
        /// <returns>�Y�����鏈���\���̍��ځi�Y�����Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��j</returns>
        public ProcessConfigItem this[string processId]
        {
            get
            {
                if (ItemMap.ContainsKey(processId))
                {
                    return ItemMap[processId];
                }
                return null;
            }
        }

        /// <summary>
        /// �C���f�N�T
        /// </summary>
        /// <param name="index">
        /// �C���f�b�N�X<br/>
        /// <c>0</c>:BL�R�[�h�}�X�^
        /// <c>1</c>:BL�O���[�v�}�X�^
        /// <c>2</c>:�����ރ}�X�^
        /// <c>3</c>:�Ԏ�}�X�^
        /// <c>4</c>:���[�J�[�}�X�^
        /// <c>5</c>:�D�ǐݒ�ύX�}�X�^
        /// <c>6</c>:�D�ǐݒ�}�X�^
        /// <c>7</c>:���i�}�X�^
        /// <c>8</c>:���i�}�X�^
        /// </param>
        /// <returns>�Y�����鏈���\���̍��ځi�Y�����Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��j</returns>
        public ProcessConfigItem this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: // BL�R�[�h�}�X�^
                        return this[BL_CODE_MASTER_ID];
                    case 1: // BL�O���[�v�}�X�^
                        return this[BL_GROUP_MASTER_ID];
                    case 2: // �����ރ}�X�^
                        return this[MIDDLE_GENRE_MASTER_ID];
                    case 3: // �Ԏ�}�X�^
                        return this[MODEL_NAME_MASTER_ID];
                    case 4: // ���[�J�[�}�X�^
                        return this[MAKER_MASTER_ID];
                    case 5: // �D�ǐݒ�ύX�}�X�^
                        return this[PRIME_SETTING_CHANGE_MASTER_ID];
                    case 6: // �D�ǐݒ�}�X�^
                        return this[PRIME_SETTING_MASTER_ID];

                    // ADD 2009/02/24 �s��Ή�[11802] ---------->>>>>
                    case 7: // ���ʃ}�X�^
                        return this[PARTS_POS_CODE_MASTER_ID];
                    case 8: // ���i�}�X�^
                        return this[GOODS_MASTER_ID];
                    case 9: // ���i�}�X�^
                        return this[GOODS_PRICE_MASTER_ID];
                    default:// ���i����
                        return this[PRICE_REVISION_ID];
                    // ADD 2009/02/24 �s��Ή�[11802] ----------<<<<<
                }
            }
        }

        #endregion  // <Indexer/>
    }

    #endregion  // <�R���t�B�O/>

    #region <������/>

    /// <summary>
    /// ���t�ɂ�鏈�����N���X
    /// </summary>
    public sealed class ProcessSequenceByDate
    {
        #region <���������X�g/>

        /// <summary>�������̃��X�g</summary>
        /// <remarks>�L�[�F�Ώۃf�[�^�敪("00") + �񋟓��t("yyyyMMddhhmmss")</remarks>
        private readonly SortedList<string, PriceUpdManualDataWork> _processSequenceList = new SortedList<string, PriceUpdManualDataWork>();
        /// <summary>
        /// �������̃��X�g���擾���܂��B
        /// </summary>
        public SortedList<string, PriceUpdManualDataWork> ProcessSequenceList
        {
            get { return _processSequenceList; }
        }

        #endregion  // <���������X�g/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public ProcessSequenceByDate() { }

        #endregion  // <Constructor/>

        /// <summary>
        /// �N���A���܂��B
        /// </summary>
        public void Clear()
        {
            ProcessSequenceList.Clear();
        }

        /// <summary>
        /// ����������ǉ����܂��B
        /// </summary>
        /// <param name="offerDateInfo">�񋟓��t���</param>
        public void Add(PriceUpdManualDataWork offerDateInfo)
        {
            string key = GetProcessSequenceKey(offerDateInfo);
            ProcessSequenceList.Add(key, offerDateInfo);
        }

        
        /// <summary>
        /// �������擾���܂��B
        /// </summary>
        public int Count
        {
            get { return ProcessSequenceList.Count;  }
        }

        #region DLETE 1����
        ///// <summary>
        ///// ���t�̏��������X�g�𐶐����܂��B
        ///// </summary>
        ///// <returns>���t�̏��������X�g</returns>
        //public SortedList<string, int> CreateDateSequenceList()
        //{
        //    SortedList<string, int> dateSeqList = new SortedList<string, int>();
        //    {
        //        foreach (PriceUpdManualDataWork dateInfo in ProcessSequenceList.Values)
        //        {
        //            string key = dateInfo.OfferDate.ToString("yyyyMMdd");
        //            if (!dateSeqList.ContainsKey(key))
        //            {
        //                dateSeqList.Add(key, int.Parse(key));
        //            }
        //        }
        //    }
        //    return dateSeqList;
        //}
        #endregion

        #region 1.5����
        /// <summary>
        /// ���t�̏��������X�g�𐶐����܂��B
        /// </summary>
        /// <returns>���t�̏��������X�g</returns>
        public SortedList<int, string> CreateDateSequenceList()
        {
            SortedList<int, string> dateSeqList = new SortedList<int, string>();
            {
                foreach (PriceUpdManualDataWork dateInfo in ProcessSequenceList.Values)
                {
                    //string key = dateInfo.OfferDate.ToString("yyyyMMdd");

                    int key = int.Parse(dateInfo.OfferDate.ToString("yyyyMMdd"));
                    string value = dateInfo.dataDiv.ToString();

                    if (!dateSeqList.ContainsKey(key))
                    {
                        dateSeqList.Add(key, value);
                    }
                    else
                    {
                        dateSeqList[key] += ("," + value);
                    }
                }
            }
            return dateSeqList;
        }
        
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offerDate"></param>
        /// <returns></returns>
        public int FindAllDataCount(int offerDate)
        {
            DateTime offerDateTime = ConvertDateTime(offerDate);
            foreach (PriceUpdManualDataWork item in ProcessSequenceList.Values)
            {
                if (item.OfferDate.Equals(offerDateTime))
                {
                    return item.allDatacnt;
                }
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offerDate"></param>
        /// <returns></returns>
        public static DateTime ConvertDateTime(int offerDate)
        {
            string strOfferDate = offerDate.ToString("00000000");
            DateTime offerDateTime = new DateTime(
                int.Parse(strOfferDate.Substring(0, 4)),
                int.Parse(strOfferDate.Substring(4, 2)),
                int.Parse(strOfferDate.Substring(6, 2))
            );
            return offerDateTime;
        }

        /// <summary>
        /// ���������X�g�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="offerDateInfo">���i�����������t�擾�f�[�^���R�[�h</param>
        /// <returns>�Ώۃf�[�^�敪("00") + �񋟓��t("yyyyMMddhhmmss")</returns>
        private static string GetProcessSequenceKey(PriceUpdManualDataWork offerDateInfo)
        {
            return offerDateInfo.dataDiv.ToString("00") + offerDateInfo.OfferDate.ToString("yyyyMMddhhmmss");
        }
    }

    #endregion  // <������/>

    #region <�D�ǐݒ�}�X�^�̃}�[�W����/>

    #region <Facade/>

    /// <summary>
    /// �D�ǐݒ�}�X�^�̃}�[�W�����̑����N���X
    /// </summary>
    public static class PrimeSettingMergeFacade
    {
        /// <summary>
        /// �D�ǐݒ�}�X�^���}�[�W���܂��B
        /// </summary>
        /// <param name="offerDate">�񋟓�</param>
        /// <param name="changeRecordList">�D�ǐݒ�ύX�}�X�^�̃��R�[�h���X�g</param>
        /// <param name="offerRecordList">�D�ǐݒ�}�X�^�i�񋟃f�[�^���j�̃��R�[�h���X�g</param>
        /// <param name="userRecordList">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h���X�g</param>
        /// <param name="updatesNameItem">���̍��ڂ��X�V����t���O</param>
        /// <returns>
        /// �}�[�W���ʁi�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̍X�V���郌�R�[�h���X�g�ƍ폜���郌�R�[�h���X�g�j
        /// </returns>
        public static UserUpdatingPrimeSettingPair Merge(
            int offerDate,
            ArrayList changeRecordList,
            ArrayList offerRecordList,
            ArrayList userRecordList,
            bool updatesNameItem
        )
        {
            string strOfferDate = offerDate.ToString("0000/00/00");
            DateTime offerDateTime = DateTime.Parse(strOfferDate);

            PrimeSettingMerger merger = new PrimeSettingMerger(
                offerDateTime,
                updatesNameItem,
                changeRecordList,
                offerRecordList
            );
            merger.Merge(userRecordList);

            return new UserUpdatingPrimeSettingPair(
                merger.UpdatingUserRecordList,
                merger.DeletingUserRecordList
            );
        }

        /// <summary>
        /// ���i�Ǘ����̃��R�[�h�̃��X�g���擾���܂��B
        /// </summary>
        /// <param name="prmSettingUWorkList">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h�̃��X�g</param>
        /// <returns>�Ή����鏤�i�Ǘ����̃��R�[�h�̃��X�g</returns>
        public static ArrayList GetGoodsMngWorkList(ArrayList prmSettingUWorkList)
        {
            #region <���_�ʂɕ���/>

            // ���_�ʂɕ���
            IDictionary<string, IList<PrmSettingUWork>> prmSettingUWorkListMap = new Dictionary<string, IList<PrmSettingUWork>>();
            foreach (PrmSettingUWork prmSettingUWork in prmSettingUWorkList)
            {
                string sectionCode = prmSettingUWork.SectionCode;
                if (!prmSettingUWorkListMap.ContainsKey(sectionCode))
                {
                    prmSettingUWorkListMap.Add(sectionCode, new List<PrmSettingUWork>());
                }
                prmSettingUWorkListMap[sectionCode].Add(prmSettingUWork);
            }

            #endregion  // <���_�ʂɕ���/>

            // ���i�Ǘ����̃��R�[�h�̃��X�g���\�z
            ArrayList goodsMngWorkList = new ArrayList();
            {
                foreach (string sectionCode in prmSettingUWorkListMap.Keys)
                {
                    #region <��������/>

                    GoodsMngWork searchingCondition = new GoodsMngWork();
                    {
                        searchingCondition.EnterpriseCode = prmSettingUWorkListMap[sectionCode][0].EnterpriseCode;  // ��ƃR�[�h
                        searchingCondition.SectionCode    = sectionCode;    // ���_�R�[�h
                    }

                    #endregion  // <��������/>

                    #region <���i�Ǘ���������/>

                    IGoodsMngDB dbReader = (IGoodsMngDB)MediationGoodsMngDB.GetGoodsMngDB();

                    object objSearchedList = null;
                    object objSearchingCondition = (object)searchingCondition;
                    int status = dbReader.Search(
                        out objSearchedList,
                        objSearchingCondition,
                        0,
                        Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0
                    );
                    if (!status.Equals((int)Result.RemoteStatus.Normal))
                    {
                        continue;
                    }
                    ArrayList searchedList = objSearchedList as ArrayList;
                    if (MergeChecker.IsNullOrEmptyArrayList(searchedList))
                    {
                        continue;
                    }

                    #endregion  // <���i�Ǘ���������/>

                    // �������ʂ� ������+���[�J�[+BL �ŕ���
                    const string MIDDLE_FORMAT  = "0000";
                    const string MAKER_FORMAT   = "0000";
                    const string BL_FORMAT      = "0000";
                    IDictionary<string, GoodsMngWork> searchedMap = new Dictionary<string, GoodsMngWork>();
                    foreach (GoodsMngWork goodsMngWork in searchedList)
                    {
                        StringBuilder key = new StringBuilder();
                        {
                            key.Append(goodsMngWork.GoodsMGroup.ToString(MIDDLE_FORMAT));
                            key.Append(goodsMngWork.GoodsMakerCd.ToString(MAKER_FORMAT));
                            key.Append(goodsMngWork.BLGoodsCode.ToString(BL_FORMAT));
                        }
                        if (!searchedMap.ContainsKey(key.ToString()))
                        {
                            searchedMap.Add(key.ToString(), goodsMngWork);
                        }
                    }

                    // �������ʂ�W�J
                    foreach (PrmSettingUWork prmSettingUWork in prmSettingUWorkListMap[sectionCode])
                    {
                        StringBuilder key = new StringBuilder();
                        {
                            key.Append(prmSettingUWork.GoodsMGroup.ToString(MIDDLE_FORMAT));
                            key.Append(prmSettingUWork.PartsMakerCd.ToString(MAKER_FORMAT));
                            key.Append(prmSettingUWork.TbsPartsCode.ToString(BL_FORMAT));
                        }
                        if (searchedMap.ContainsKey(key.ToString()))
                        {
                            goodsMngWorkList.Add(searchedMap[key.ToString()]);
                        }
                    }
                }   // foreach (string sectionCode in prmSettingUWorkListMap.Keys)
            }
            return goodsMngWorkList;
        }
    }

    #endregion  // <Fcade/>

    /// <summary>
    /// �D�ǐݒ�}�X�^�̃}�[�W�҃N���X
    /// </summary>
    public sealed class PrimeSettingMerger
    {
        #region <�񋟓���/>

        /// <summary>�񋟓���</summary>
        private readonly DateTime _offerDateTime;
        /// <summary>
        /// �񋟓������擾���܂��B
        /// </summary>
        private DateTime OfferDateTime { get { return _offerDateTime; } }

        /// <summary>�񋟓��t</summary>
        private int _offerDate;
        /// <summary>
        /// �񋟓��t���擾���܂��B
        /// </summary>
        private int OfferDate
        {
            get
            {
                if (!_offerDate.Equals(0))
                {
                    return _offerDate;
                }
                else
                {
                    return int.Parse(OfferDateTime.ToString("yyyyMMdd"));
                }
            }

            set { _offerDate = value; }
        }

        #endregion  // <�񋟓���/>

        #region <���̍��ڂ��X�V����t���O/>

        /// <summary>���̍��ڂ��X�V����t���O</summary>
        private readonly bool _updatesNameItem;
        /// <summary>
        /// ���̍��ڂ��X�V����t���O���擾���܂��B
        /// </summary>
        private bool UpdatesNameItem { get { return _updatesNameItem; } }

        #endregion  // <���̍��ڂ��X�V����t���O/>

        #region <�D�ǐݒ�ύX�}�X�^/>

        /// <summary>�D�ǐݒ�ύX�}�X�^�̃��R�[�h���X�g</summary>
        private readonly ArrayList _changeRecordList;
        /// <summary>
        /// �D�ǐݒ�ύX�}�X�^�̃��R�[�h
        /// </summary>
        private ArrayList ChangeRecordList { get { return _changeRecordList; } }

        #endregion  // <�D�ǐݒ�ύX�}�X�^/>

        #region <�D�ǐݒ�}�X�^�i�񋟃f�[�^���j/>

        /// <summary>�D�ǐݒ�}�X�^�i�񋟃f�[�^���j�̃��R�[�h���X�g</summary>
        private readonly ArrayList _offerRecordList;
        /// <summary>
        /// �D�ǐݒ�}�X�^�i�񋟃f�[�^���j�̃��R�[�h���X�g���擾���܂��B
        /// </summary>
        private ArrayList OfferRecordList { get { return _offerRecordList; } }

        #endregion  // <�D�ǐݒ�}�X�^�i�񋟃f�[�^��/>�j

        #region <�D�ǐݒ�}�X�^�i���[�U�[�o�^���j/>

        /// <summary>�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h�}�b�v</summary>
        /// <remarks>�L�[�F�\�z���ɍ̔ԁi�}�[�W�p�̃f�[�^�e�[�u����ID�Ɠ����l�ɂȂ�j</remarks>
        private readonly IDictionary<long, PrmSettingUWork> _userRecordMap = new Dictionary<long, PrmSettingUWork>();
        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h�}�b�v���擾���܂��B
        /// </summary>
        /// <remarks>
        /// �L�[�F�\�z���ɍ̔ԁi�}�[�W�p�̃f�[�^�e�[�u����ID�Ɠ����l�ɂȂ�j
        /// </remarks>
        private IDictionary<long, PrmSettingUWork> UserRecordMap { get { return _userRecordMap; } }

        #endregion  // <�D�ǐݒ�}�X�^�i���[�U�[�o�^���j/>

        #region <�}�[�W�p�f�[�^/>

        /// <summary>�}�[�W�p�f�[�^�Z�b�g</summary>
        private PrimeSetting _mergingUserDataSet;
        /// <summary>
        /// �}�[�W�p�f�[�^�Z�b�g���擾���܂��B
        /// </summary>
        private PrimeSetting MergingUserDataSet
        {
            get
            {
                if (_mergingUserDataSet == null)
                {
                    _mergingUserDataSet = new PrimeSetting();
                }
                return _mergingUserDataSet;
            }
        }

        /// <summary>
        /// �}�[�W�p�f�[�^�e�[�u�����擾���܂��B
        /// </summary>
        private PrimeSetting.UserDataTable MergingUserDataTable
        {
            get { return MergingUserDataSet.User; }
        }

        #endregion  // <�}�[�W�p�f�[�^/>

        #region <�}�[�W����/>

        /// <summary>�X�V����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h���X�g</summary>
        private readonly ArrayList _updatingUserRecordList = new ArrayList();
        /// <summary>
        /// �X�V����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h���X�g���擾���܂��B
        /// </summary>
        public ArrayList UpdatingUserRecordList { get { return _updatingUserRecordList; } }

        /// <summary>�폜����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h���X�g</summary>
        private readonly ArrayList _deletingUserRecordList = new ArrayList();
        /// <summary>
        /// �폜����D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h���X�g���擾���܂��B
        /// </summary>
        public ArrayList DeletingUserRecordList { get { return _deletingUserRecordList; } }

        #endregion  // <�}�[�W����/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="offerDateTime">�񋟓���</param>
        /// <param name="updatesNameItem">���̍��ڂ��X�V����t���O</param>
        /// <param name="changeRecordList">�D�ǐݒ�ύX�}�X�^�̃��R�[�h���X�g</param>
        /// <param name="offerRecordList">�D�ǐݒ�}�X�^�i�񋟃f�[�^���j�̃��R�[�h���X�g</param>
        public PrimeSettingMerger(
            DateTime offerDateTime,
            bool updatesNameItem,
            ArrayList changeRecordList,
            ArrayList offerRecordList
        )
        {
            _offerDateTime  = offerDateTime;    // �񋟓���
            _updatesNameItem= updatesNameItem;  // ���̍��ڂ��X�V����t���O

            // �D�ǐݒ�ύX�}�X�^
            if (!MergeChecker.IsNullOrEmptyArrayList(changeRecordList))
            {
                _changeRecordList = changeRecordList;
            }
            else
            {
                _changeRecordList = new ArrayList();
            }

            // �D�ǐݒ�}�X�^�i�񋟃f�[�^���j
            if (!MergeChecker.IsNullOrEmptyArrayList(offerRecordList))
            {
                _offerRecordList = offerRecordList;
            }
            else
            {
                _offerRecordList = new ArrayList();
            }
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// �}�[�W���܂��B
        /// </summary>
        /// <param name="userRecordList">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h���X�g</param>
        public void Merge(ArrayList userRecordList)
        {
            // �}�[�W�̏���
            InitializeMergingUserInfo(userRecordList);

            // �D�ǐݒ�ύX�}�X�^�ɂ��}�[�W
            MergeByPrimeSettingChangeMaster();

            // �D�ǐݒ�}�X�^�i�񋟃f�[�^���j�ɂ��}�[�W
            MergeByPrimeSettingOfferMaster();

            // �X�V���X�g�ƍ폜���X�g�ɓW�J
            SetUpdatingUserRecordListAndDeletingRecordList();
        }

        #region <�}�[�W�̏���/>

        /// <summary>
        /// �}�[�W���邽�߂̗D�ǐݒ�}�X�^�i���[�U�[�o�^���j�������������܂��B
        /// </summary>
        /// <param name="userRecordList">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h���X�g</param>
        private void InitializeMergingUserInfo(ArrayList userRecordList)
        {
            MergingUserDataTable.Clear();
            if (MergeChecker.IsNullOrEmptyArrayList(userRecordList)) return;

            long idCount = 0;
            foreach (PrmSettingUWork prmSettingUWork in userRecordList)
            {
                long currentId = idCount++;

                UserRecordMap.Add(currentId, prmSettingUWork);

                MergingUserDataTable.AddUserRow(
                    currentId,
                    prmSettingUWork.GoodsMGroup,
                    prmSettingUWork.PartsMakerCd,
                    prmSettingUWork.TbsPartsCode,
                    prmSettingUWork.PrmSetDtlNo1,
                    prmSettingUWork.PrmSetDtlName1,
                    prmSettingUWork.PrmSetDtlNo2,
                    prmSettingUWork.PrmSetDtlName2,
                    prmSettingUWork.PrimeDisplayCode,
                    (int)PrimeSetting.RowStatus.None,
                    prmSettingUWork.OfferDate
                );
            }
        }

        #endregion  // <�}�[�W�̏���/>

        #region <�D�ǐݒ�ύX�}�X�^�ɂ��}�[�W/>

        /// <summary>�����敪�F�폜</summary>
        private const int DELETING = 1;

        /// <summary>
        /// �D�ǐݒ�ύX�}�X�^�ɂ��}�[�W���s���܂��B
        /// </summary>
        private void MergeByPrimeSettingChangeMaster()
        {
            foreach (PrmSettingChgWork prmSettingChgWork in ChangeRecordList)
            {
                string filter = GetWhere(prmSettingChgWork);
                Debug.WriteLine("�D�ǐݒ�ύX�}�X�^�̃t�B���^�F" + filter);

                DataRow[] foundRows = MergingUserDataTable.Select(filter);
                {
                    // �Ώۃ`�F�b�N�F�Ώۃ��R�[�h���Ȃ��ꍇ�A�������s��Ȃ�
                    if (foundRows.Length.Equals(0)) continue;

                    PrintPrmSettingChgWork(prmSettingChgWork);

                    foreach (PrimeSetting.UserRow mergingRow in foundRows)
                    {
                        // �Ώۃ`�F�b�N�F�񋟓����񋟃f�[�^�ƃ��[�U�[�f�[�^�œ���̏ꍇ�́A�������s��Ȃ�
                        if (mergingRow.OfferDate.Equals(prmSettingChgWork.OfferDate)) continue;

                        // �폜����
                        if (prmSettingChgWork.ProcDivCd.Equals(DELETING))
                        {
                            mergingRow.Status = (int)PrimeSetting.RowStatus.Deleting;
                            continue;
                        }

                        // �D�ǐݒ�ڍ׃R�[�h1��ύX
                        SetPrmSetDtlNo1(mergingRow, prmSettingChgWork);

                        // �D�ǐݒ�ڍ׃R�[�h2��ύX
                        SetPrmSetDtlNo2(mergingRow, prmSettingChgWork);

                        // �D�Ǖ\���敪
                        SetPrimeDisplayCode(mergingRow, prmSettingChgWork);

                        // �񋟓��t
                        if (mergingRow.Status.Equals((int)PrimeSetting.RowStatus.Updating))
                        {
                            // �D�ǐݒ�}�X�^�i�񋟃f�[�^���j�ɂ��}�[�W�Ɠ������t�i�̂͂��j
                            //mergingRow.OfferDate = prmSettingChgWork.OfferDate;
                            OfferDate = prmSettingChgWork.OfferDate;
                        }
                    }   // foreach (PrimeSetting.UserRow mergingRow in foundRows)
                }
            }   // foreach (PrmSettingChgWork prmSettingChgWork in ChangeRecordList)
        }

        /// <summary>
        /// �D�ǐݒ�ڍ׃R�[�h1��ݒ肵�܂��B
        /// </summary>
        /// <param name="mergingRow">�}�[�W�p�f�[�^�s</param>
        /// <param name="prmSettingChgWork">�D�ǐݒ�ύX�}�X�^�̃��R�[�h</param>
        private static void SetPrmSetDtlNo1(
            PrimeSetting.UserRow mergingRow,
            PrmSettingChgWork prmSettingChgWork
        )
        {
            // �ύX��D�ǐݒ�ڍ׃R�[�h1�� -1 �̏ꍇ�͏��������Ȃ�
            if (prmSettingChgWork.AfPrmSetDtlNo1 < 0) return;

            mergingRow.PrmSetDtlNo1 = prmSettingChgWork.AfPrmSetDtlNo1;
            mergingRow.Status = (int)PrimeSetting.RowStatus.Updating;
        }

        /// <summary>
        /// �D�ǐݒ�ڍ׃R�[�h2��ݒ肵�܂��B
        /// </summary>
        /// <param name="mergingRow">�}�[�W�p�f�[�^�s</param>
        /// <param name="prmSettingChgWork">�D�ǐݒ�ύX�}�X�^�̃��R�[�h</param>
        private static void SetPrmSetDtlNo2(
            PrimeSetting.UserRow mergingRow,
            PrmSettingChgWork prmSettingChgWork
        )
        {
            // �ύX��D�ǐݒ�ڍ׃R�[�h2�� -1 �̏ꍇ�͏��������Ȃ�
            if (prmSettingChgWork.AfPrmSetDtlNo2 < 0) return;

            mergingRow.PrmSetDtlNo2 = prmSettingChgWork.AfPrmSetDtlNo2;
            mergingRow.Status = (int)PrimeSetting.RowStatus.Updating;
        }

        /// <summary>
        /// �D�Ǖ\���敪��ݒ肵�܂��B
        /// </summary>
        /// <param name="mergingRow">�}�[�W�p�f�[�^�s</param>
        /// <param name="prmSettingChgWork">�D�ǐݒ�ύX�}�X�^�̃��R�[�h</param>
        private static void SetPrimeDisplayCode(
            PrimeSetting.UserRow mergingRow,
            PrmSettingChgWork prmSettingChgWork
        )
        {
            // �ύX��D�Ǖ\���敪�� 1, 2 �̏ꍇ�A�X�V����
            if (
                prmSettingChgWork.AfPrimeDisplayCode.Equals(1)  // ���i������
                    ||
                prmSettingChgWork.AfPrimeDisplayCode.Equals(2)  // ���i
            )
            {
                mergingRow.PrimeDisplayCode = prmSettingChgWork.AfPrimeDisplayCode;
                mergingRow.Status = (int)PrimeSetting.RowStatus.Updating;
            }
        }

        #endregion  // <�D�ǐݒ�ύX�}�X�^�ɂ��}�[�W/>

        #region <�D�ǐݒ�}�X�^�i�񋟃f�[�^���j�ɂ��}�[�W/>

        /// <summary>
        /// �D�ǐݒ�}�X�^�i�񋟃f�[�^���j�ɂ��}�[�W���s���܂��B
        /// </summary>
        private void MergeByPrimeSettingOfferMaster()
        {
            foreach (PrmSettingWork prmSettingWork in OfferRecordList)
            {
                string filter = GetWhere(prmSettingWork);
                Debug.WriteLine("�D�ǐݒ�}�X�^�i�񋟁j�̃t�B���^�F" + filter);

                DataRow[] foundRows = MergingUserDataTable.Select(filter);
                {
                    // �Ώۃ`�F�b�N�F�Ώۃ��R�[�h���Ȃ��ꍇ�A�������s��Ȃ�
                    if (foundRows.Length.Equals(0)) continue;

                    PrintPrmSettingWork(prmSettingWork);

                    foreach (PrimeSetting.UserRow mergingRow in foundRows)
                    {
                        // �Ώۃ`�F�b�N�F�񋟓����񋟃f�[�^�ƃ��[�U�[�f�[�^�œ���̏ꍇ�́A�������s��Ȃ�
                        if (mergingRow.OfferDate.Equals(prmSettingWork.OfferDate)) continue;

                        // �D�ǐݒ�ڍ�1
                        SetPrmSetDtl1(mergingRow, prmSettingWork);

                        // �D�ǐݒ�ڍ�2
                        SetPrmSetDtl2(mergingRow, prmSettingWork);

                        // �񋟓��t
                        if (mergingRow.Status.Equals((int)PrimeSetting.RowStatus.Updating))
                        {
                            // �D�ǐݒ�ύX�}�X�^�ɂ��}�[�W�Ɠ������t�i�̂͂��j
                            //mergingRow.OfferDate = prmSettingWork.OfferDate;
                            OfferDate = prmSettingWork.OfferDate;
                        }
                    }   // foreach (PrimeSetting.UserRow mergingRow in foundRows)
                }
            }   // foreach (PrmSettingChgWork prmSettingChgWork in ChangeRecordList)
        }

        /// <summary>
        /// �D�ǐݒ�ڍ�1��ݒ肵�܂��B
        /// </summary>
        /// <param name="mergingRow">�}�[�W�p�f�[�^�s</param>
        /// <param name="prmSettingWork">�D�ǐݒ�}�X�^�i�񋟃f�[�^���j�̃��R�[�h</param>
        private void SetPrmSetDtl1(
            PrimeSetting.UserRow mergingRow,
            PrmSettingWork prmSettingWork
        )
        {
            // �D�ǐݒ�ڍ׃R�[�h1 ���D�ǐݒ�ڍ׃R�[�h1�͑ΏۊO
            //mergingRow.PrmSetDtlNo1 = prmSettingWork.PrmSetDtlNo1;

            // �D�ǐݒ�ڍז���1
            if (UpdatesNameItem)
            {
                mergingRow.PrmSetDtlName1 = prmSettingWork.PrmSetDtlName1;
            }

            mergingRow.Status = (int)PrimeSetting.RowStatus.Updating;
        }

        /// <summary>
        /// �D�ǐݒ�ڍ�2��ݒ肵�܂��B
        /// </summary>
        /// <param name="mergingRow">�}�[�W�p�f�[�^�s</param>
        /// <param name="prmSettingWork">�D�ǐݒ�}�X�^�i�񋟃f�[�^���j�̃��R�[�h</param>
        private void SetPrmSetDtl2(
            PrimeSetting.UserRow mergingRow,
            PrmSettingWork prmSettingWork
        )
        {
            // �D�ǐݒ�ڍ׃R�[�h2 ���D�ǐݒ�ڍ׃R�[�h2�͑ΏۊO
            //mergingRow.PrmSetDtlNo2 = prmSettingWork.PrmSetDtlNo2;

            // �D�ǐݒ�ڍז���2
            if (UpdatesNameItem)
            {
                mergingRow.PrmSetDtlName2 = prmSettingWork.PrmSetDtlName2;
            }

            mergingRow.Status = (int)PrimeSetting.RowStatus.Updating;
        }

        #endregion  // <�D�ǐݒ�}�X�^�i�񋟃f�[�^���j�ɂ��}�[�W/>

        #region <�t�B���^/>

        /// <summary>
        /// �D�ǐݒ�}�X�^�i�񋟃f�[�^���j�ɂ��}�[�W�ł�where����擾���܂��B
        /// </summary>
        /// <param name="prmSettingWork">�D�ǐݒ�}�X�^�i�񋟃f�[�^���j�̃��R�[�h</param>
        /// <returns>��{where��</returns>
        private string GetWhere(PrmSettingWork prmSettingWork)
        {
            return GetBaseWhere(
                prmSettingWork.GoodsMGroup,
                prmSettingWork.PartsMakerCd,
                prmSettingWork.TbsPartsCode
            );
        }

        /// <summary>
        /// �D�ǐݒ�ύX�}�X�^�ɂ��}�[�W�ł�where����擾���܂��B
        /// </summary>
        /// <param name="prmSettingChgWork">�D�ǐݒ�ύX�}�X�^�̃��R�[�h</param>
        /// <returns>��{where�� and �D�ǐݒ�ڍ׃R�[�h1 and �D�ǐݒ�ڍ׃R�[�h2</returns>
        private string GetWhere(PrmSettingChgWork prmSettingChgWork)
        {
            string baseWhere = GetBaseWhere(prmSettingChgWork);

            int prmSetDtlNo1 = prmSettingChgWork.PrmSetDtlNo1;   // �D�ǐݒ�ڍ׃R�[�h1
            int prmSetDtlNo2 = prmSettingChgWork.PrmSetDtlNo2;   // �D�ǐݒ�ڍ׃R�[�h2

            StringBuilder where = new StringBuilder(baseWhere);
            {
                where.Append(ADOUtil.AND);
                where.Append(MergingUserDataTable.PrmSetDtlNo1Column.ColumnName).Append(ADOUtil.EQ).Append(prmSetDtlNo1);
                where.Append(ADOUtil.AND);
                where.Append(MergingUserDataTable.PrmSetDtlNo2Column.ColumnName).Append(ADOUtil.EQ).Append(prmSetDtlNo2);
            }
            return where.ToString();
        }

        /// <summary>
        /// ��{where����擾���܂��B
        /// </summary>
        /// <param name="prmSettingChgWork">�D�ǐݒ�ύX�}�X�^�̃��R�[�h</param>
        /// <returns>where �����ރR�[�h and ���i���[�J�[�R�[�h and BL�R�[�h</returns>
        private string GetBaseWhere(PrmSettingChgWork prmSettingChgWork)
        {
            int goodsMGroup = prmSettingChgWork.GoodsMGroup;    // �����ރR�[�h
            int partsMakerCd = prmSettingChgWork.PartsMakerCd;   // ���i���[�J�[�R�[�h
            int tbsPartsCode = prmSettingChgWork.TbsPartsCode;   // BL�R�[�h

            return GetBaseWhere(goodsMGroup, partsMakerCd, tbsPartsCode);
        }

        /// <summary>
        /// ��{where����擾���܂��B
        /// </summary>
        /// <param name="goodsMGroup">�����ރR�[�h</param>
        /// <param name="partsMakerCd">���i���[�J�[�R�[�h</param>
        /// <param name="tbsPartsCode">BL�R�[�h</param>
        /// <returns>where �����ރR�[�h and ���i���[�J�[�R�[�h and BL�R�[�h</returns>
        private string GetBaseWhere(
            int goodsMGroup,
            int partsMakerCd,
            int tbsPartsCode
        )
        {
            StringBuilder where = new StringBuilder();
            {
                where.Append(MergingUserDataTable.GoodsMGroupColumn.ColumnName).Append(ADOUtil.EQ).Append(goodsMGroup);
                where.Append(ADOUtil.AND);
                where.Append(MergingUserDataTable.PartsMakerCdColumn.ColumnName).Append(ADOUtil.EQ).Append(partsMakerCd);
                where.Append(ADOUtil.AND);
                where.Append(MergingUserDataTable.TbsPartsCodeColumn.ColumnName).Append(ADOUtil.EQ).Append(tbsPartsCode);
            }
            return where.ToString();
        }

        #endregion  // <�t�B���^/>

        #region <�X�V���X�g�ƍ폜���X�g�ɓW�J/>

        /// <summary>
        /// �X�V���X�g�ƍ폜���X�g�ɓW�J���܂��B
        /// </summary>
        private void SetUpdatingUserRecordListAndDeletingRecordList()
        {
            // �X�V���X�g���\�z
            UpdatingUserRecordList.Clear();
            {
                string updatingFilter = GetWhere(PrimeSetting.RowStatus.Updating);

                DataRow[] foundRows = MergingUserDataTable.Select(updatingFilter);

                foreach (PrimeSetting.UserRow updatingRow in foundRows)
                {
                    long currentId = updatingRow.Id;

                    // �ύX�O�̍X�V���R�[�h��_���폜���郌�R�[�h�Ƃ��ēo�^
                    UpdatingUserRecordList.Add(CreateLogicalDeletingRecord(UserRecordMap[currentId]));

                    // �X�V���R�[�h��o�^
                    UpdatingUserRecordList.Add(GetMergedRecord(
                        UserRecordMap[currentId],
                        updatingRow
                    ));
                }
            }

            // �폜���X�g���\�z
            DeletingUserRecordList.Clear();
            {
                string deletingFilter = GetWhere(PrimeSetting.RowStatus.Deleting);

                DataRow[] foundRows = MergingUserDataTable.Select(deletingFilter);

                foreach (PrimeSetting.UserRow deletingRow in foundRows)
                {
                    long currentId = deletingRow.Id;
                    DeletingUserRecordList.Add(UserRecordMap[currentId]);
                }
            }
        }

        /// <summary>
        /// �_���폜�Ƃ��郌�R�[�h�𐶐����܂��B
        /// </summary>
        /// <param name="prmSettingUWork">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h</param>
        /// <returns>�_���폜�Ƃ��郌�R�[�h</returns>
        private PrmSettingUWork CreateLogicalDeletingRecord(PrmSettingUWork prmSettingUWork)
        {
            PrmSettingUWork logicalDeletingRecord = new PrmSettingUWork();
            {
                logicalDeletingRecord.CreateDateTime    = prmSettingUWork.CreateDateTime;   // �쐬����
                logicalDeletingRecord.EnterpriseCode    = prmSettingUWork.EnterpriseCode;   // ��ƃR�[�h
                logicalDeletingRecord.LogicalDeleteCode = 2;    // �_���폜�敪(0:�L��, 1:�_���폜, 2:�ۗ�, 3:���S�폜)
                logicalDeletingRecord.UpdateDateTime    = prmSettingUWork.UpdateDateTime;   // �X�V���� 

                logicalDeletingRecord.SectionCode       = prmSettingUWork.SectionCode;      // ���_�R�[�h
                logicalDeletingRecord.GoodsMGroup       = prmSettingUWork.GoodsMGroup;      // ���i�����ރR�[�h
                logicalDeletingRecord.TbsPartsCode      = prmSettingUWork.TbsPartsCode;     // BL�R�[�h
                logicalDeletingRecord.TbsPartsCdDerivedNo = prmSettingUWork.TbsPartsCdDerivedNo;    // BL�R�[�h�}��
                logicalDeletingRecord.MakerDispOrder    = prmSettingUWork.MakerDispOrder;   // ���[�J�[�\������
                logicalDeletingRecord.PartsMakerCd      = prmSettingUWork.PartsMakerCd;     // ���i���[�J�[�R�[�h
                logicalDeletingRecord.PrimeDispOrder    = prmSettingUWork.PrimeDispOrder;   // �D�Ǖ\������
                logicalDeletingRecord.PrmSetDtlNo1      = prmSettingUWork.PrmSetDtlNo1;     // �D�ǐݒ�ڍ׃R�[�h1
                logicalDeletingRecord.PrmSetDtlName1    = prmSettingUWork.PrmSetDtlName1;   // �D�ǐݒ�ڍז���1
                logicalDeletingRecord.PrmSetDtlNo2      = prmSettingUWork.PrmSetDtlNo2;     // �D�ǐݒ�ڍ׃R�[�h2
                logicalDeletingRecord.PrmSetDtlName2    = prmSettingUWork.PrmSetDtlName2;   // �D�ǐݒ�ڍז���2
                logicalDeletingRecord.PrimeDisplayCode  = prmSettingUWork.PrimeDisplayCode; // �D�Ǖ\���敪
                logicalDeletingRecord.OfferDate         = prmSettingUWork.OfferDate;        // �񋟓��t
            }
            return logicalDeletingRecord;
        }

        /// <summary>
        /// �l���}�[�W�������R�[�h���擾���܂��B
        /// </summary>
        /// <param name="prmSettingUWork">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃��R�[�h</param>
        /// <param name="mergingRow">�}�[�W�p�f�[�^�s</param>
        private PrmSettingUWork GetMergedRecord(
            PrmSettingUWork prmSettingUWork,
            PrimeSetting.UserRow mergingRow
        )
        {
            // �D�ǐݒ�ڍ�1
            prmSettingUWork.PrmSetDtlNo1    = mergingRow.PrmSetDtlNo1;
            prmSettingUWork.PrmSetDtlName1  = mergingRow.PrmSetDtlName1;

            // �D�ǐݒ�ڍ�2
            prmSettingUWork.PrmSetDtlNo2    = mergingRow.PrmSetDtlNo2;
            prmSettingUWork.PrmSetDtlName2  = mergingRow.PrmSetDtlName2;

            // �D�Ǖ\���敪
            prmSettingUWork.PrimeDisplayCode= mergingRow.PrimeDisplayCode;

            // �񋟓��t
            prmSettingUWork.OfferDate = OfferDate;

            PrintMergingUserRecord(prmSettingUWork);

            return prmSettingUWork;
        }

        /// <summary>
        /// �}�[�W���ʓW�J�p��where����擾���܂��B
        /// </summary>
        /// <param name="rowStatus">�}�[�W�p�f�[�^�s�̃X�e�[�^�X��̒l</param>
        /// <returns>�}�[�W�p�f�[�^�s�̃X�e�[�^�X��̒l</returns>
        private string GetWhere(PrimeSetting.RowStatus rowStatus)
        {
            StringBuilder where = new StringBuilder();
            {
                where.Append(MergingUserDataTable.StatusColumn.ColumnName).Append(ADOUtil.EQ).Append((int)rowStatus);
            }
            return where.ToString();
        }

        #endregion  // <�X�V���X�g�ƍ폜���X�g�ɓW�J/>

        #region <Debug/>

        /// <summary>
        /// �D�ǐݒ�ύX�}�X�^�̃��R�[�h�̓��e��\�����܂��B
        /// </summary>
        /// <param name="prmSettingChgWork">�D�ǐݒ�ύX�}�X�^�̃��R�[�h</param>
        [Conditional("DEBUG")]
        private static void PrintPrmSettingChgWork(PrmSettingChgWork prmSettingChgWork)
        {
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�i�񋟃f�[�^���j�̃��R�[�h�̓��e��\�����܂��B
        /// </summary>
        /// <param name="prmSettingWork">�D�ǐݒ�}�X�^�i�񋟃f�[�^���j�̃��R�[�h</param>
        [Conditional("DEBUG")]
        private static void PrintPrmSettingWork(PrmSettingWork prmSettingWork)
        {
            int goodsMGroup = prmSettingWork.GoodsMGroup;   // �����ރR�[�h
            int partsMakerCd = prmSettingWork.PartsMakerCd; // ���i���[�J�[�R�[�h
            int tbsPartsCode = prmSettingWork.TbsPartsCode; // BL�R�[�h

            // �D�ǐݒ�ڍ�1
            int prmSetDtlNo1 = prmSettingWork.PrmSetDtlNo1;
            string prmSetDtlName1 = prmSettingWork.PrmSetDtlName1;

            // �D�ǐݒ�ڍ�2
            int prmSetDtlNo2 = prmSettingWork.PrmSetDtlNo2;
            string prmSetDtlName2 = prmSettingWork.PrmSetDtlName2;

            // �񋟓��t
            int offerDate = prmSettingWork.OfferDate;

            StringBuilder line = new StringBuilder();
            {
                line.Append("(��)�����ށF").Append(goodsMGroup).Append(",");
                line.Append("(��)���[�J�[�F").Append(partsMakerCd).Append(",");
                line.Append("(��)BL�F").Append(tbsPartsCode).Append(",");
                line.Append("(��)�ڍ׃R�[�h1�F").Append(prmSetDtlNo1).Append(",");
                line.Append("(��)�ڍז���1�F").Append(prmSetDtlName1).Append(",");
                line.Append("(��)�ڍ׃R�[�h2�F").Append(prmSetDtlNo2).Append(",");
                line.Append("(��)�ڍז���2�F").Append(prmSetDtlName2).Append(",");
                line.Append("(��)�񋟓��F").Append(offerDate);
            }
            Debug.WriteLine(line.ToString());
        }

        /// <summary>
        /// �D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃}�[�W���郌�R�[�h�̓��e��\�����܂��B
        /// </summary>
        /// <param name="userRecord">�D�ǐݒ�}�X�^�i���[�U�[�o�^���j�̃}�[�W���郌�R�[�h</param>
        [Conditional("DEBUG")]
        private static void PrintMergingUserRecord(PrmSettingUWork userRecord)
        {
            int goodsMGroup = userRecord.GoodsMGroup;   // �����ރR�[�h
            int partsMakerCd = userRecord.PartsMakerCd; // ���i���[�J�[�R�[�h
            int tbsPartsCode = userRecord.TbsPartsCode; // BL�R�[�h

            // �D�ǐݒ�ڍ�1
            int prmSetDtlNo1 = userRecord.PrmSetDtlNo1;
            string prmSetDtlName1 = userRecord.PrmSetDtlName1;

            // �D�ǐݒ�ڍ�2
            int prmSetDtlNo2 = userRecord.PrmSetDtlNo2;
            string prmSetDtlName2 = userRecord.PrmSetDtlName2;

            // �D�Ǖ\���敪
            int primeDisplayCode = userRecord.PrimeDisplayCode;

            // �񋟓��t
            int offerDate = userRecord.OfferDate;

            StringBuilder line = new StringBuilder();
            {
                line.Append("�����ށF").Append(goodsMGroup).Append(",");
                line.Append("���[�J�[�F").Append(partsMakerCd).Append(",");
                line.Append("BL�F").Append(tbsPartsCode).Append(",");
                line.Append("�ڍ׃R�[�h1�F").Append(prmSetDtlNo1).Append(",");
                line.Append("�ڍז���1�F").Append(prmSetDtlName1).Append(",");
                line.Append("�ڍ׃R�[�h2�F").Append(prmSetDtlNo2).Append(",");
                line.Append("�ڍז���2�F").Append(prmSetDtlName2).Append(",");
                line.Append("�\���敪�F").Append(primeDisplayCode).Append(",");
                line.Append("�񋟓��F").Append(offerDate);
            }
            Debug.WriteLine(line.ToString());
        }

        #endregion  // <Debug/>
    }

    #endregion  // <�D�ǐݒ�}�X�^�̃}�[�W����/>

    #region <���s����/>

    /// <summary>
    /// ���s���ʃN���X
    /// </summary>
    public sealed class ProcessResult
    {
        #region <BL�R�[�h�}�X�^/>

        /// <summary>BL�R�[�h�}�X�^�̍X�V����</summary>
        private int _blCodeMasterUpdatedCount;
        /// <summary>
        /// BL�R�[�h�}�X�^�̍X�V�����̃A�N�Z�T
        /// </summary>
        public int BLCodeMasterUpdatedCount
        {
            get { return _blCodeMasterUpdatedCount; }
            set { _blCodeMasterUpdatedCount = value; }
        }

        #endregion  // <BL�R�[�h�}�X�^/>

        #region <BL�O���[�v�}�X�^/>

        /// <summary>BL�O���[�v�}�X�^�̍X�V����</summary>
        private int _blGroupMasterUpdatedCount;
        /// <summary>
        /// BL�O���[�v�}�X�^�̍X�V�����̃A�N�Z�T
        /// </summary>
        public int BLGroupMasterUpdatedCount
        {
            get { return _blGroupMasterUpdatedCount; }
            set { _blGroupMasterUpdatedCount = value; }
        }

        #endregion  // <BL�O���[�v�}�X�^/>

        #region <�����ރ}�X�^/>

        /// <summary>�����ރ}�X�^�̍X�V����</summary>
        private int _middleGenreMasterUpdatedCount;
        /// <summary>
        /// �����ރ}�X�^�̍X�V�����̃A�N�Z�T
        /// </summary>
        public int MiddleGenreMasterUpdatedCount
        {
            get { return _middleGenreMasterUpdatedCount; }
            set { _middleGenreMasterUpdatedCount = value; }
        }

        #endregion  // <�����ރ}�X�^/>

        #region <�Ԏ�}�X�^/>

        /// <summary>�Ԏ�}�X�^�̍X�V����</summary>
        private int _modelNameMasterUpdatedCount;
        /// <summary>
        /// �Ԏ�}�X�^�̍X�V�����̃A�N�Z�T
        /// </summary>
        public int ModelNameMasterUpdatedCount
        {
            get { return _modelNameMasterUpdatedCount; }
            set { _modelNameMasterUpdatedCount = value; }
        }

        #endregion  // <�Ԏ�}�X�^/>

        #region <���[�J�[�}�X�^/>

        /// <summary>���[�J�[�}�X�^�̍X�V����</summary>
        private int _makerMasterUpdatedCount;
        /// <summary>
        /// ���[�J�[�}�X�^�̍X�V�����̃A�N�Z�T
        /// </summary>
        public int MakerMasterUpdatedCount
        {
            get { return _makerMasterUpdatedCount; }
            set { _makerMasterUpdatedCount = value; }
        }

        #endregion  // <���[�J�[�}�X�^/>

        #region <�D�ǐݒ�}�X�^/>

        /// <summary>�D�ǐݒ�}�X�^�̍X�V����</summary>
        private int _primeSettingMasterUpdatedCount;
        /// <summary>
        /// �D�ǐݒ�}�X�^�̍X�V�����̃A�N�Z�T
        /// </summary>
        public int PrimeSettingMasterUpdatedCount
        {
            get { return _primeSettingMasterUpdatedCount; }
            set { _primeSettingMasterUpdatedCount = value; }
        }

        #endregion  // <�D�ǐݒ�}�X�^/>

        #region <���ʃ}�X�^/>

        /// <summary>���ʃ}�X�^�̍X�V����</summary>
        private int _partsPosCodeMasterUpdatedCount;
        /// <summary>
        /// ���ʃ}�X�^�̍X�V�����̃A�N�Z�T
        /// </summary>
        public int PartsPosCodeMasterUpdatedCount
        {
            get { return _partsPosCodeMasterUpdatedCount; }
            set { _partsPosCodeMasterUpdatedCount = value; }
        }

        #endregion  // <���ʃ}�X�^/>

        #region <���i�}�X�^/>

        /// <summary>���i�}�X�^�̍X�V����</summary>
        private int _goodsMasterUpdatedCount;
        /// <summary>
        /// ���i�}�X�^�̍X�V�����̃A�N�Z�T
        /// </summary>
        public int GoodsMasterUpdatedCount
        {
            get { return _goodsMasterUpdatedCount; }
            set { _goodsMasterUpdatedCount = value; }
        }

        #endregion  // <���i�}�X�^/>

        #region <���i�}�X�^/>

        /// <summary>���i�}�X�^�̍X�V����</summary>
        private int _goodsPriceMasterUpdatedCount;
        /// <summary>
        /// ���i�}�X�^�̍X�V�����̃A�N�Z�T
        /// </summary>
        public int GoodsPriceMasterUpdatedCount
        {
            get { return _goodsPriceMasterUpdatedCount; }
            set { _goodsPriceMasterUpdatedCount = value; }
        }

        #endregion  // <���i�}�X�^/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public ProcessResult() { }

        #endregion  // <Constructor/>

        #region <���i����/>

        /// <summary>
        /// ���i�����̍X�V�������擾���܂��B
        /// </summary>
        /// <value>���i�}�X�^�̍X�V���� + ���i�}�X�^�̍X�V����</value>
        public int PriceRevisionUpdatedCount
        {
            get { return GoodsMasterUpdatedCount + GoodsPriceMasterUpdatedCount; }
        }

        #endregion  // <���i����/>

        #region <Indexer/>

        /// <summary>
        /// �C���f�N�T
        /// </summary>
        /// <param name="tableId">�e�[�u��ID</param>
        /// <returns>�Y������X�V����</returns>
        public int this[string tableId]
        {
            get
            {
                if (tableId.Equals(ProcessConfig.BL_CODE_MASTER_ID))
                {
                    return BLCodeMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.BL_GROUP_MASTER_ID))
                {
                    return BLGroupMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.MIDDLE_GENRE_MASTER_ID))
                {
                    return MiddleGenreMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.MODEL_NAME_MASTER_ID))
                {
                    return ModelNameMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.MAKER_MASTER_ID))
                {
                    return MakerMasterUpdatedCount;
                }
                if (
                    tableId.Equals(ProcessConfig.PRIME_SETTING_CHANGE_MASTER_ID)
                        ||
                    tableId.Equals(ProcessConfig.PRIME_SETTING_MASTER_ID)
                )
                {
                    return PrimeSettingMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.PARTS_POS_CODE_MASTER_ID))
                {
                    return PartsPosCodeMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.GOODS_MASTER_ID))
                {
                    return GoodsMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.GOODS_PRICE_MASTER_ID))
                {
                    return GoodsPriceMasterUpdatedCount;
                }
                if (tableId.Equals(ProcessConfig.PRICE_REVISION_ID))
                {
                    return PriceRevisionUpdatedCount;
                }
                return 0;
            }
        }

        #endregion  // <Indexer/>
    }

    #endregion  // <���s����/>

    #region <���O/>

    /// <summary>
    /// ���K�[�N���X
    /// </summary>
    public sealed class MyLogWriter
    {
        #region <���O�̏����ݎ�/>

        /// <summary>���O�̏����ݎ�</summary>
        private readonly OperationHistoryLog _logWriter = new OperationHistoryLog();
        /// <summary>
        /// ���O�̏����ݎ҂��擾���܂��B
        /// </summary>
        private OperationHistoryLog LogWriter { get { return _logWriter; } }

        #endregion  // <���O�̏����ݎ�/>

        #region <�ێ���/>

        /// <summary>�ێ���</summary>
        private readonly object _owner;
        /// <summary>
        /// �ێ��҂��擾���܂��B
        /// </summary>
        private object Owner { get { return _owner; } }

        #endregion  // <�ێ���/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="owner">�ێ���</param>
        public MyLogWriter(object owner)
        {
            _owner = owner;
        }

        #endregion  // <Constructor/>

        /// <summary>
        /// ���O���������݂܂�
        /// </summary>
        /// <param name="processName">�e�����̖���</param>
        /// <param name="stepName">�����敪</param>
        /// <param name="data">�X�V���e</param>
        public void Write(
            string processName,
            string stepName,
            string data
        )
        {
            const string PROGRAM_ID = "PMKHN09201A";
            const string PROGRAM_NAME = "�񋟃f�[�^�X�V����";
            const int OPERATION_CODE = 0;
            const int STATUS = 0;

            LogWriter.WriteOperationLog(
                Owner,
                DateTime.Now,
                LogDataKind.SystemLog,
                PROGRAM_ID,
                PROGRAM_NAME,
                processName,
                OPERATION_CODE,
                STATUS,
                stepName,
                data
            );
        }

        #region <����/>

        /// <summary>
        /// �Ώۓ��t�擾�̃��O�p���b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="offerDate">�񋟓�</param>
        /// <param name="processSequence"></param>
        /// <returns></returns>
        public static string GetTargetCheckMessage(
            int offerDate,
            ProcessSequenceByDate processSequence
        )
        {
            DateTime offerDateTime = ProcessSequenceByDate.ConvertDateTime(offerDate);
            int allDataCount = processSequence.FindAllDataCount(offerDate);

            StringBuilder msg = new StringBuilder();
            {
                msg.Append("�Ώۓ��t:").Append(offerDateTime.ToString("yyyy/MM/dd"));
                msg.Append(" ");
                msg.Append("����").Append(allDataCount).Append("��");
            }
            return msg.ToString();
        }

        /// <summary>�}�[�W����</summary>
        public const string MERGING = "�X�V����";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public static string GetTargetTableName(MergeInfoGetCond condition)
        {
            const string SEPARATOR = ",";

            StringBuilder msg = new StringBuilder();
            {
                // BL�R�[�h�}�X�^
                if (condition.BLFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    msg.Append(ProcessConfig.BL_CODE_MASTER_NAME);
                }
                // BL�O���[�v�}�X�^
                if (condition.BLGroupFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.BL_GROUP_MASTER_NAME);
                }
                // �����ރ}�X�^
                if (condition.GoodsMGroupFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.MIDDLE_GENRE_MASTER_NAME);
                }
                // �Ԏ�}�X�^
                if (condition.ModelNameFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.MODEL_NAME_MASTER_NAME);
                }
                // ���[�J�[�}�X�^
                if (condition.PMakerFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.MAKER_MASTER_NAME);
                }
                // �D�ǐݒ�}�X�^
                if (
                    condition.PrmSetChgFlg.Equals(MergeCond.DOING_FLG_AS_INT)
                        ||
                    condition.PrmSetFlg.Equals(MergeCond.DOING_FLG_AS_INT)
                )
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.PRIME_SETTING_MASTER_NAME);
                }
                // ���ʃ}�X�^
                if (condition.PartsPosFlg.Equals(MergeCond.DOING_FLG_AS_INT))
                {
                    if (!string.IsNullOrEmpty(msg.ToString())) msg.Append(SEPARATOR);
                    msg.Append(ProcessConfig.PARTS_POS_CODE_MASTER_NAME);
                }
            }
            return msg.ToString();
        }

        /// <summary>
        /// �}�[�W�����̃��O�p���b�Z�[�W���擾���܂��B
        /// </summary>
        /// <param name="status">�����[�g�̏�������</param>
        /// <param name="lstUsrUpdateData">IOfferMerge.WriteMergeData()�ɓn�����X�V���X�g</param>
        /// <returns>"����I��(������)" �܂��� �����[�g�̃G���[�R�[�h</returns>
        public static string GetMergedMessage(
            int status,
            ArrayList lstUsrUpdateData
        )
        {
            StringBuilder msg = new StringBuilder();
            {
                if (status.Equals((int)Result.RemoteStatus.Normal))
                {
                    int sum = 0;
                    if (!MergeChecker.IsNullOrEmptyArrayList(lstUsrUpdateData))
                    {
                        foreach (ArrayList itemList in lstUsrUpdateData)
                        {
                            sum += itemList.Count;
                        }
                    }
                    msg.Append("����I��(").Append(sum).Append("��)");
                }
                else
                {
                    msg.Append("�����[�g�G���[(status=").Append(status).Append(")");
                }
            }
            return msg.ToString();
        }

        /// <summary>���i����</summary>
        public const string PRICE_REVISION = "���i����";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        /// <param name="lstUsrUpdateData"></param>
        public static string GetPriceRevisionMessage(int status, ArrayList lstUsrUpdateData)
        {
            return GetMergedMessage(status, lstUsrUpdateData);
        }

        #endregion  // <����/>
    }

    #endregion  // <���O/>

    #region <���|�I�v�V����/>

    /// <summary>
    /// ���|�I�v�V�����N���X
    /// </summary>
    public sealed class PurchaseOption
    {
        #region <�����^�C�v/>

        /// <summary>�����^�C�v</summary>
        private readonly int _searchPartsType = -1;
        /// <summary>
        /// �����^�C�v���擾���܂��B
        /// </summary>
        public int SearchPartsType { get { return _searchPartsType; } }

        /// <summary>
        /// �����^�C�v���擾���܂��B
        /// </summary>
        /// <returns>
        /// ��{�񋟃f�[�^�I�v�V�����`�F�b�N���s���A�߂�l��0���傫���ꍇ<c>10</c><br/>
        /// �O���񋟃f�[�^�I�v�V�����`�F�b�N���s���A�߂�l��0���傫���ꍇ<c>20</c>
        /// </returns>
        private static int GetSearchPartsType()
        {
            int status = -1;  // ADD 2012/02/08

            // �I�v�V�����`�F�b�N
            int checkedResult = (int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BasicOfferData   // ��{�񋟃f�[�^�I�v�V����
            );
            if (checkedResult > 0)
            {
                //return 10; // DEL 2012/02/08
                status = 10; // ADD 2012/02/08
            }
            checkedResult = (int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_OutsideOfferData // �O���񋟃f�[�^�I�v�V����
            );
            if (checkedResult > 0)
            {
                //return 20; // DEL 2012/02/08
                status = 20; // ADD 2012/02/08
            }

            //return -1;  //DEL 2012/02/08
            return status; // ADD 2012/02/08
        }

        #endregion  // <�����^�C�v/>

        #region <��^�I�v�V����/>

        /// <summary>��^�I�v�V����</summary>
        private readonly int _bigCarOfferDiv = 0;
        /// <summary>
        /// ��^�I�v�V�������擾���܂��B
        /// </summary>
        public int BigCarOfferDiv { get { return _bigCarOfferDiv; } }

        /// <summary>
        /// ��^�I�v�V�������擾���܂��B
        /// </summary>
        /// <returns>
        /// ��^�I�v�V�����`�F�b�N���s���A�߂�l��0���傫���ꍇ<c>1</c>�A����ȊO <c>0</c>
        /// </returns>
        private static int GetBigCarOfferDiv()
        {
            // �I�v�V�����`�F�b�N
            int checkedResult = (int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_BigCarOfferData  // ��^�I�v�V����
            );
            return checkedResult > 0 ? 1 : 0;
        }

        #endregion  // <��^�I�v�V����/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public PurchaseOption()
        {
            _bigCarOfferDiv = GetBigCarOfferDiv();
            _searchPartsType= GetSearchPartsType();
        }

        #endregion  // <Constructor/>
    }

    #endregion  // <���|�I�v�V����/>

    #region <ADO.NET/>

    /// <summary>
    /// ADO.NET�̃��[�e�B���e�B
    /// </summary>
    public static class ADOUtil
    {
        /// <summary>=�L�[���[�h</summary>
        public const string EQ = "=";

        /// <summary>�����L�[���[�h</summary>
        public const string NOT_EQ = "<>";

        /// <summary>AND�L�[���[�h</summary>
        public const string AND = " AND ";

        /// <summary>OR�L�[���[�h</summary>
        public const string OR = " OR ";

        /// <summary>�~���̃L�[���[�h</summary>
        public const string DESC = " DESC";

        /// <summary>�J���}�L�[���[�h</summary>
        public const string COMMA = ",";

        /// <summary>LIKE�L�[���[�h</summary>
        public const string LIKE = " LIKE ";

        /// <summary>���C���h�J�[�h�L�[���[�h</summary>
        public const string WILD = "%";

        /// <summary>���L�[���[�h</summary>
        public const string LARGE_EQ = ">=";

        /// <summary>���L�[���[�h</summary>
        public const string LARGE = ">";

        /// <summary>���L�[���[�h</summary>
        public const string LESS_EQ = "<=";

        /// <summary>���L�[���[�h</summary>
        public const string LESS = "<";

        /// <summary>NOT�L�[���[�h</summary>
        public const string NOT = "<>";

        /// <summary>(�L�[���[�h</summary>
        public const string BEGIN_BLOCK = "(";

        /// <summary>)�L�[���[�h</summary>
        public const string END_BLOCK = ")";

        /// <summary>
        /// SQL�̕�����l�\�L���擾���܂��B
        /// </summary>
        /// <param name="val">������l</param>
        /// <returns>SQL�̕�����l�\�L</returns>
        public static string GetString(string val)
        {
            return "'" + val + "'";
        }

        /// <summary>
        /// SQL�̕�����l�\�L���擾���܂��B
        /// </summary>
        /// <param name="number">���l</param>
        /// <returns>SQL�̕�����l�\�L</returns>
        public static string GetString(int number)
        {
            return GetString(number.ToString());
        }

        /// <summary>
        /// SQL�̃��[���h�J�[�h�t��������\�L���擾���܂��B
        /// </summary>
        /// <param name="val">������l</param>
        /// <returns>SQL�̃��[���h�J�[�h�t��������\�L</returns>
        public static string GetWild(string val)
        {
            return GetString(WILD + val + WILD);
        }

        /// <summary>
        /// DataRow�̔z�񂩂�DataTable�𐶐����܂��B
        /// </summary>
        /// <typeparam name="TDataTable">DataTable�̌^</typeparam>
        /// <param name="dataRows">DataRow�̔z��</param>
        /// <returns>�V����DataTable�̃C���X�^���X</returns>
        public static TDataTable CreateDataTable<TDataTable>(DataRow[] dataRows) where TDataTable : DataTable, new()
        {
            TDataTable dataTable = new TDataTable();
            foreach (DataRow dataRow in dataRows)
            {
                dataTable.Rows.Add(dataRow.ItemArray);
            }
            return dataTable;
        }

        /// <summary>
        /// DataRow�z����^�t��DataRow�z��ɕϊ����܂��B
        /// </summary>
        /// <typeparam name="TDataRow">�^�t��DataRow�̌^</typeparam>
        /// <param name="dataRows">DataRow�z��</param>
        /// <returns>�^�t��DataRow�z��</returns>
        public static TDataRow[] ConvertAll<TDataRow>(DataRow[] dataRows) where TDataRow : DataRow
        {
            return Array.ConvertAll<DataRow, TDataRow>(dataRows, delegate(DataRow dataRow) { return (TDataRow)dataRow; });
        }
    }

    #endregion  // <ADO.NET/>

    #region <Pair/>

    /// <summary>
    /// �l�̃y�A�N���X
    /// </summary>
    /// <typeparam name="TFirst">1�Ԗڂ̒l�̌^</typeparam>
    /// <typeparam name="TSecond">2�Ԗڂ̒l�̌^</typeparam>
    public class Pair<TFirst, TSecond>
    {
        /// <summary>1�Ԗڂ̒l</summary>
        private readonly TFirst _first;
        /// <summary>
        /// 1�Ԗڂ̒l���擾���܂��B
        /// </summary>
        /// <value>1�Ԗڂ̒l</value>
        public TFirst First { get { return _first; } }

        /// <summary>2�Ԗڂ̒l���擾���܂��B</summary>
        private readonly TSecond _second;
        /// <summary>
        /// 2�Ԗڂ̒l���擾���܂��B
        /// </summary>
        /// <value>2�Ԗڂ̒l</value>
        public TSecond Second { get { return _second; } }

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="first">1�Ԗڂ̒l</param>
        /// <param name="second">2�Ԗڂ̒l</param>
        public Pair(
            TFirst first,
            TSecond second
        )
        {
            _first = first;
            _second = second;
        }

        #region <object override/>

        /// <summary>
        /// ������ɕϊ����܂��B
        /// </summary>
        /// <returns>������</returns>
        public override string ToString()
        {
            return First.ToString() + "," + Second.ToString();
        }

        #endregion  // <object override/>
    }

    #endregion  // <Pair/>

    #region <Singleton/>

    /// <summary>
    /// �V���O���g��������N���X
    /// </summary>
    /// <typeparam name="T">�V���O���g���Ƃ���N���X</typeparam>
    public sealed class SingletonPolicy<T> where T : class, new()
    {
        #region <Singleton Idiom/>

        /// <summary>�����I�u�W�F�N�g</summary>
        private static readonly object _syncRoot = new object();

        /// <summary>�V���O���g���C���X�^���X</summary>
        private static SingletonPolicy<T> _instance;
        /// <summary>
        /// �V���O���g���C���X�^���X���擾���܂��B
        /// </summary>
        /// <value>�V���O���g���C���X�^���X</value>
        public static SingletonPolicy<T> Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                        {
                            _instance = new SingletonPolicy<T>();
                        }
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        private SingletonPolicy()
        {
            _policy = new T();
        }

        #endregion  // <Singleton Idiom/>

        /// <summary>�V���O���g���Ƃ���C���X�^���X</summary>
        private readonly T _policy;
        /// <summary>
        /// �V���O���g���Ƃ���C���X�^���X���擾���܂��B
        /// </summary>
        /// <value>�V���O���g���Ƃ���C���X�^���X</value>
        public T Policy
        {
            get { return _policy; }
        }
    }

    #endregion  // <Singleton/>
}
