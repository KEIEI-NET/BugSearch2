//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Controller
// �v���O�����T�v   : 
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : �H�� �b�D
// �� �� ��  2008/11/17  �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024  ���X�� �� 
// �� �� ��  2010/10/19  �C�����e : �����ԍ����܂�����������d���`�[�̑Ή�(MANTIS[0015563])
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-00 �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  K2012/06/22 �C�����e : �R�`���i�ʑΉ�
//                                  ����͔����̏ꍇ�A�d���f�[�^���쐬���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-01 �쐬�S�� : FSI���X�� �M�p
// �� �� ��  K2012/12/11 �C�����e : �R�`���i�ʑΉ�
//                                  �R�`���i���S�ʃI�v�V��������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10902931-00  �쐬�S�� : 杍^
// �� �� ��  K2013/10/04  �C�����e : SPK�ɂĕ������_�Ŕ�������M�����s����ƁA�݌ɐ����X�V���ꂸ�A�����c���c���Ă��܂�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11601223-00  �쐬�S�� : ���O
// �� �� ��  K2021/09/22  �C�����e : PMKOBETSU-4189 ���O�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11770181-00  �쐬�S�� : 杍^
// �� �� ��  2021/12/08   �C�����e : PMKOBETSU-4202 �����d����M���� �f�[�^�Ǎ����P�Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11900025-00  �쐬�S�� : �c������
// �� �� ��  2023/01/20   �C�����e : PMKOBETSU-4202 �����d����M������Q�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using System.IO;//ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή�

namespace Broadleaf.Application.Controller.Agent
{
    using LoginWorkerAcs = SingletonPolicy<LoginWorker>;

    // ADD K2012/12/11 START >>>>>>
    using Broadleaf.Application.Common;
    using Broadleaf.Application.Resources;
    // ADD K2012/12/11 END <<<<<<

    /// <summary>
    /// �d���f�[�^DB�̑㗝�l�N���X
    /// </summary>
    /// <remarks>
    /// <br>Update Note: PMKOBETSU-4189�@���O�ǉ�</br>
    /// <br>Programmer : ���O</br>
    /// <br>Date       : K2021/09/22</br>
    /// </remarks>
    public sealed class StockDBAgent
    {
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
        /// <summary>�d���f�[�^�������O</summary>
        private const string CtSearchLogDataMassage = "�d���f�[�^�������s:����������{0}";
        /// <summary>�d���f�[�^�X�V���O</summary>
        private const string CtDbLogDataMassage = "DB�ꊇ�X�V�Ɏ��s:�d���⍇���ԍ�={0};�G���[���e={1}";
        /// <summary>�d���f�[�^��������</summary>
        private const string CtSearchCondition = "���_={0};������={1};UOE�����ԍ�={2};UOE�����s�ԍ�={3};UOE���={4}";
        /// <summary>�Ԋu</summary>
        private const string Str_Space = "  ";
        /// <summary>���O�o��PGID</summary>
        private const string CtLogOutputPgid = "PMUOE01304A";
        /// <summary>���O�o�͋��ʕ��i</summary>
        OutLogCommon LogCommon;
        /// <summary>���엚�����O�A�N�Z�X</summary>
        UoeOprtnHisLogAcs _uoeOprtnHisLogAcs = null;
        #region <�d���⍇���ԍ�>
        /// <summary>�d���⍇���ԍ�</summary>
        private string _uOESalesOrderNo = string.Empty;
        /// <summary>
        /// �d���⍇���ԍ����擾���܂��B
        /// </summary>
        /// <value>�d���⍇���ԍ�</value>
        public string UOESalesOrderNo
        {
            get { return _uOESalesOrderNo; }
            set { _uOESalesOrderNo = value; } 
        }
        #endregion  // <�d���⍇���ԍ�/>

        #region <UOE������/>
        /// <summary>UOE������</summary>
        private int _uOESupplierCd = 0;
        /// <summary>
        /// UOE��������擾���܂��B
        /// </summary>
        /// <value>UOE������</value>
        public int UOESupplierCd
        {
            get { return _uOESupplierCd; }
            set { _uOESupplierCd = value; }
        }
        #endregion  // <UOE������/>
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
        // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
        // ����XML�t�@�C��
        private const string HISLOGOUTSETTINGFILE = "PMUOE01300U_HisLogOutSetting.xml";
        // �o�͐���XML
        private HisLogOutSetting HisLogOutSettingInfoWork;
        /// <summary>
        /// ���엚���̓o�^�A���O�o�͐ݒ�
        /// </summary>
        public HisLogOutSetting HisLogOutSettingInfo
        {
            get
            {
                return this.HisLogOutSettingInfoWork;
            }
        }
        // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<

        #region <Const/>

        /// <summary>
        /// UOE��ʗ񋓑�
        /// </summary>
        public enum UOEKind : int
        {
            /// <summary>UOE</summary>
            UOE = 0,
            /// <summary>�����d����M</summary>
            OroshishoStockReception = 1
        }

        #endregion  // <Const/>

        #region <��������/>

        /// <summary>
        /// ���������N���X
        /// </summary>
        public sealed class SearchingCondition
        {
            #region <������R�[�h/>

            /// <summary>������R�[�h</summary>
            private readonly int _uoeSupplierCode;
            /// <summary>
            /// ������R�[�h���擾���܂��B
            /// </summary>
            /// <value>������R�[�h</value>
            public int UOESupplierCode { get { return _uoeSupplierCode; } }

            #endregion  // <������R�[�h/>

            #region <UOE�����`�[�ԍ�/>

            /// <summary>UOE�����`�[�ԍ�</summary>
            private readonly int _uoeSalesOrderNo;
            /// <summary>
            /// UOE�����`�[�ԍ����擾���܂��B
            /// </summary>
            /// <value>UOE�����`�[�ԍ�</value>
            public int UOESalesOrderNo { get { return _uoeSalesOrderNo; } } 

            #endregion  // <UOE�����`�[�ԍ�/>

            #region <UOE�����s�ԍ�/>

            /// <summary>UOE�����s�ԍ�</summary>
            private readonly int _uoeSalesOrderRowNo;
            /// <summary>
            /// UOE�����s�ԍ����擾���܂��B
            /// </summary>
            /// <value>UOE�����s�ԍ�</value>
            public int UOESalesOrderRowNo { get { return _uoeSalesOrderRowNo; } }

            #endregion  // <UOE�����s�ԍ�/>

            #region <UOE���/>

            /// <summary>UOE���</summary>
            private readonly int _uoeKind;
            /// <summary>
            /// UOE��ʂ��擾���܂��B
            /// </summary>
            /// <value>UOE���</value>
            public int UOEKind { get { return _uoeKind; } } 

            #endregion  // <UOE���/>

            // ---- ADD K2013/10/04 杍^ ---- >>>>>
            //Thread��
            //���_�R�[�h
            private const string SECTIONSOLT = "SECTIONSOLT";
            private LocalDataStoreSlot sectionSolt = null;

            #region ���񋓑�
            /// <summary>
            /// �I�v�V�����L���L��
            /// </summary>
            public enum Option : int
            {
                /// <summary>�������[�U</summary>
                OFF = 0,
                /// <summary>�L�����[�U</summary>
                ON = 1,
            }
            #endregion

            /// <summary>�e�L�X�g�o�̓I�v�V�������</summary>
            private int _opt_FuTaBa;//OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj

            //��pUSB�p
            Broadleaf.Application.Remoting.ParamData.PurchaseStatus fuTaBaPs;
            // ---- ADD K2013/10/04 杍^ ---- <<<<<

            #region <Constructor/>

            /// <summary>
            /// �J�X�^���R���X�g���N�^
            /// </summary>
            /// <remarks>
            /// UOE��ʂ�<c>0</c>�FUOE���ݒ肳��܂��B
            /// </remarks>
            /// <param name="uoeSupplierCode">������R�[�h</param>
            /// <param name="uoeSalesOrderNo">UOE�����`�[�ԍ�</param>
            /// <param name="uoeSalesOrderRowNo">UOE�����s�ԍ�</param>
            public SearchingCondition(
                int uoeSupplierCode,
                int uoeSalesOrderNo,
                int uoeSalesOrderRowNo
            )
            {
                _uoeSupplierCode    = uoeSupplierCode;
                _uoeSalesOrderNo    = uoeSalesOrderNo;
                _uoeSalesOrderRowNo = uoeSalesOrderRowNo;
                _uoeKind = (int)StockDBAgent.UOEKind.UOE;
            }

            #endregion  // <Constructor/>

            /// <summary>
            /// UOE�����f�[�^�i���������j�𐶐����܂��B
            /// </summary>
            /// <returns>UOE�����f�[�^�i���������j</returns>
            public UOEOrderDtlWork CreateUoeOrderDtlWork()
            {
                UOEOrderDtlWork record = new UOEOrderDtlWork();
                {
                    record.EnterpriseCode       = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
                    //record.SectionCode          = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;

                    // ---- ADD K2013/10/04 杍^ ---- >>>>>
                    //OPT-CPM0110�F�t�^�oUOE�I�v�V�����i�ʁj
                    fuTaBaPs = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(ConstantManagement_SF_PRO.SoftwareCode_OPT_CPM_FutabaUOECtl);
                    if (fuTaBaPs == Broadleaf.Application.Remoting.ParamData.PurchaseStatus.Contract)
                    {
                        this._opt_FuTaBa = (int)Option.ON;
                    }
                    else
                    {
                        this._opt_FuTaBa = (int)Option.OFF;
                    }
                    //�t�^�oUSB��p
                    if (this._opt_FuTaBa == (int)Option.ON)
                    {
                        sectionSolt = Thread.GetNamedDataSlot(SECTIONSOLT);
                        //Thread�ŁA���_������ꍇ�AThread�̋��_���g�p
                        if (Thread.GetData(sectionSolt) != null)
                        {
                            record.SectionCode = ((string)Thread.GetData(Thread.GetNamedDataSlot(SECTIONSOLT))).Trim();
                        }
                        else
                        {
                            record.SectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
                        }
                    }
                    else
                    {
                        record.SectionCode = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
                    }
                    // ---- ADD K2013/10/04 杍^ ---- <<<<<<

                    record.UOESupplierCd        = UOESupplierCode;
                    record.UOESalesOrderNo      = UOESalesOrderNo;
                    record.UOESalesOrderRowNo   = UOESalesOrderRowNo;
                    record.UOEKind              = UOEKind;
                    record.SupplierFormal       = 2;  // 2;�����i�Œ�j
                }
                return record;
            }
        }

        /// <summary>�����������X�g</summary>
        private readonly IList<SearchingCondition> _searchingConditionList = new List<SearchingCondition>();
        /// <summary>
        /// �����������X�g���擾���܂��B
        /// </summary>
        /// <value>�����������X�g</value>
        private IList<SearchingCondition> SearchingConditionList { get { return _searchingConditionList; } }

        /// <summary>
        /// ����������ǉ����܂��B
        /// </summary>
        /// <param name="uoeSupplierCode">������R�[�h</param>
        /// <param name="uoeSalesOrderNo">UOE�����`�[�ԍ�</param>
        /// <param name="uoeSalesOrderRowNo">UOE�����s�ԍ�</param>
        public void AddSearchingCondition(
            int uoeSupplierCode,
            int uoeSalesOrderNo,
            int uoeSalesOrderRowNo
        )
        {
            SearchingConditionList.Add(new SearchingCondition(
                uoeSupplierCode,
                uoeSalesOrderNo,
                uoeSalesOrderRowNo
            ));
        }

        /// <summary>
        /// �����[�g�p�̌����������X�g�𐶐����܂��B
        /// </summary>
        /// <returns>�����[�g�p�̌����������X�g</returns>
        private ArrayList CreateUOEOrderDtlList()
        {
            ArrayList uoeOrderDtlList = new ArrayList();

            foreach (SearchingCondition searchingCondition in SearchingConditionList)
            {
                // �d�b�����������������ɍ��݂���ƁA�����[�g���ŕK������0�Ƃ���̂ŁA����
                if (searchingCondition.UOESalesOrderNo.Equals(ReceivedText.SALES_ORDER_NO_BY_TELEPHONE)) continue;
                
                uoeOrderDtlList.Add(searchingCondition.CreateUoeOrderDtlWork());   
            }

            return uoeOrderDtlList;
        }

        #endregion  // <��������/>

        #region <��������/>

        /// <summary>UOE�d���f�[�^�i����j</summary>
        private UOEStockDataEssence _uoeStockData;
        /// <summary>
        /// UOE�d���f�[�^�i����j���擾���܂��B
        /// </summary>
        /// <value>UOE�d���f�[�^�i����j</value>
        private UOEStockDataEssence UoeStockData { get { return _uoeStockData; } }

        #endregion  // <��������/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        // ------UPD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
        //public StockDBAgent() { }
        public StockDBAgent() 
        {
            GetControlXmlInfo();
        }        
        // ------UPD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<

        #endregion  // <Constructor/>

        /// <summary>
        /// �ꊇ�擾���܂��B
        /// </summary>
        // 2010/10/19 >>>
        //public int Search()
        /// <remarks>
        /// <br>Update Note: PMKOBETSU-4189�@���O�ǉ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : K2021/09/22</br>
        /// <br>Update Note: PMKOBETSU-4202 �����d����M������Q�Ή�</br>
        /// <br>Programmer : �c������</br>
        /// <br>Date       : 2023/01/20</br>
        /// </remarks>
        public int Search(IAgreegate<ReceivedText> receivedTelegramAgreegate)
        // 2010/10/19 <<<
        {
            // 1�p���ځF��������
            ArrayList uoeOrderDtlList = CreateUOEOrderDtlList();
            object objUOEOrderDtlList = (object)uoeOrderDtlList;
            PrintSearchingCondition(uoeOrderDtlList);

            // 2�p���ځF��������
            CustomSerializeArrayList slipGroupList = new CustomSerializeArrayList();
            object objSlipGroupList = (object)slipGroupList;

            // �ꊇ�擾
            int status = (int)Result.RemoteStatus.NotFound;
            if (uoeOrderDtlList.Count > 0)
            {
                IIOWriteUOEOdrDtlDB dbReader = MediationIOWriteUOEOdrDtlDB.GetIOWriteUOEOdrDtlDB();
                // ------DEL 2023/01/20 �c������ �����d����M������Q�Ή� ------>>>>>
                //status = dbReader.Search(
                //    ref objUOEOrderDtlList,
                //    ref objSlipGroupList,
                //    0,  // TODO: 0 �Œ�
                //    ConstantManagement.LogicalMode.GetData0
                //);
                // ------DEL 2023/01/20 �c������ �����d����M������Q�Ή� ------<<<<<
                // ------ADD 2023/01/20 �c������ �����d����M������Q�Ή� ------>>>>>
                //�R�`���i�ʑΉ�(�������ʂ̎擾���@�ύX Search2 ���g�p)
                status = dbReader.Search2(
                    ref objUOEOrderDtlList,
                    ref objSlipGroupList,
                    0,  // TODO: 0 �Œ�
                    ConstantManagement.LogicalMode.GetData0
                );
                // ------ADD 2023/01/20 �c������ �����d����M������Q�Ή� ------<<<<<
            }
            else
            {
                // �d�b�������݂̂̏ꍇ�A��̌������ʂ�ݒ�
                objSlipGroupList = new CustomSerializeArrayList();
            }
            if (status.Equals((int)Result.RemoteStatus.Normal) || status.Equals((int)Result.RemoteStatus.NotFound))
            {
                // 2010/10/19 >>>
                //_uoeStockData = new UOEStockDataEssence(objSlipGroupList as CustomSerializeArrayList);
                _uoeStockData = new UOEStockDataEssence(objSlipGroupList as CustomSerializeArrayList, receivedTelegramAgreegate);
                // 2010/10/19 <<<
            }
            else
            {
                Debug.Assert(status.Equals((int)Result.RemoteStatus.NotFound), "status = " + status.ToString(), "�����[�g�ŃG���[�����H");
                // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
                if (HisLogOutSettingInfoWork.OutFlg)
                {
                    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<
                    // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
                    //���엚�����O��o�^
                    _uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
                    string logMsg = string.Format(CtSearchLogDataMassage, GetSearchCondition(uoeOrderDtlList));
                    _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, logMsg, _uOESupplierCd);
                    WriteClcLogProc(CtLogOutputPgid, logMsg);
                    // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
                }//ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή�

                return (int)Result.Code.Error;
            }

            SearchingConditionList.Clear(); // �����������N���A
            return (int)Result.Code.Normal;
        }

        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
        /// <summary>
        /// ����������߂�܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">��������</param>
        /// <returns>stringBuilder</returns>
        /// <remarks>
        /// <br>Note:       PMKOBETSU-4189�@���O�ǉ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        private string GetSearchCondition(ArrayList uoeOrderDtlList)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < uoeOrderDtlList.Count; i++)
            {
                UOEOrderDtlWork item = (UOEOrderDtlWork)uoeOrderDtlList[i];
                //�����������擾
                if (string.IsNullOrEmpty(stringBuilder.ToString()))
                {
                    stringBuilder.Append(string.Format(CtSearchCondition, item.SectionCode, item.UOESupplierCd, item.UOESalesOrderNo, item.UOESalesOrderRowNo, item.UOEKind));
                }
                else
                {
                    stringBuilder.Append(Str_Space);
                    stringBuilder.Append(string.Format(CtSearchCondition, item.SectionCode, item.UOESupplierCd, item.UOESalesOrderNo, item.UOESalesOrderRowNo, item.UOEKind));
                }
            }
            return stringBuilder.ToString();
        }
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<

        #region <DB�̔r������p/>

        /// <summary>
        /// DB�����b�N�������肵�܂��B
        /// </summary>
        /// <param name="status">�����[�g�̏�������</param>
        /// <returns>
        /// <c>true</c> :���b�N��<br/>
        /// <c>false</c>:���b�N���ł͂Ȃ�
        /// </returns>
        private static bool IsLocked(int status)
        {
            return (
                status.Equals((int)Result.RemoteStatus.EnterpriseLock)
                    ||
                status.Equals((int)Result.RemoteStatus.SectionLock)
                    ||
                status.Equals((int)Result.RemoteStatus.WarehouseLock)
            );
        }

        #endregion <DB�̔r������p/>

        /// <summary>
        /// �ꊇ�X�V���܂��B
        /// </summary>
        /// <param name="retMsg">�����[�g�̑�2�p�����[�^</param>
        /// <param name="retItemInfo">�����[�g�̑�3�p�����[�^</param>
        /// <returns>�����[�g�̏������ʃR�[�h</returns>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: �R�`���i���S�ʃI�v�V��������ǉ�</br>
        /// <br>Programmer : FSI���X�� �M�p</br>
        /// <br>Date       : K2012/12/11 </br>
        /// <br>Update Note: PMKOBETSU-4189�@���O�ǉ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public int Write(
            out string retMsg,
            out string retItemInfo
        )
        {
            // 1�p���ځF�X�V����
            CustomSerializeArrayList paraList = UoeStockData.CreateWritingData(CanWriteSumUpInformation());
            // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
            if (HisLogOutSettingInfoWork.OutFlg)
            {
                // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<
                // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
                //���엚�����O��o�^
                _uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
                _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, 0, UoeStockData.LogMsg, _uOESupplierCd);
                // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
            }//ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή�

            object objParaList = (object)paraList;
            //PrintWritingCondition(SearchedResult.RealSlipGroupList);

            // 2�p���ځF���b�Z�[�W
            retMsg = string.Empty;

            // 3�p���ځF���ڏ��
            retItemInfo = string.Empty;

            // �ꊇ�X�V
            IIOWriteControlDB dbWriter = (IIOWriteControlDB)MediationIOWriteControlDB.GetIOWriteControlDB();
            {
                const int SLEEP_SEC = 1000; // 1[sec]
                const int LIMITTER  = 30;   // 30��
                int retryCount = 0;

                int status = (int)Result.RemoteStatus.Normal;

                // ADD K2012/12/11 START >>>>>>
                // �R�`���i���S�ʃI�v�V��������
                PurchaseStatus ps = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                    ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_YamagataCustomControl);
                // ADD K2012/12/11 END <<<<<<

                // add K2012/06/22 >>>
                // DEL K2012/12/11 START >>>>>>
                //if (!UoeStockData.DBWriteFlg)
                // DEL K2012/12/11 END <<<<<<
                // ADD K2012/12/11 START >>>>>>
                // �R�`���i���S�ʃI�v�V�������L���̊��ŁA����UOE�d���f�[�^.DB�X�V�t���O��
                // false(�X�V���Ȃ��j�̏ꍇ�A�����𒆒f����
                if ((PurchaseStatus.Contract == ps) && (!UoeStockData.DBWriteFlg))
                // ADD K2012/12/11 END <<<<<<
                    return status;
                // add K2012/06/22 <<<

                do
                {
                    if (retryCount >= LIMITTER) break;

                    status = dbWriter.Write(ref objParaList, out retMsg, out retItemInfo);

                    if (IsLocked(status))
                    {
                        Thread.Sleep(SLEEP_SEC);
                        retryCount++;
                    }
                }
                while (IsLocked(status));
                if (!status.Equals((int)Result.RemoteStatus.Normal))
                {
                    Debug.Assert(false, "DB�̍X�V�Ɏ��s\n" + status.ToString() + "\n" + retMsg + "\n" + retItemInfo);
                    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
                    if (HisLogOutSettingInfoWork.OutFlg)
                    {
                    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<
                        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
                        //���엚�����O��o�^
                        _uoeOprtnHisLogAcs = new UoeOprtnHisLogAcs();
                        string logMsg = string.Format(CtDbLogDataMassage, _uOESalesOrderNo, retMsg);
                        _uoeOprtnHisLogAcs.logd_update(this, string.Empty, string.Empty, (Int32)EnumUoeConst.ctLogDataOperationCd.ct_END, status, logMsg, _uOESupplierCd);
                        WriteClcLogProc(CtLogOutputPgid, logMsg);
                        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
                    }//ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή�
                }

                #region <�P�Ƃō݌ɒ����f�[�^�����������R�[�h/>

                //if (GetSumUpStockAdjustCount() > 0)
                //{
                //    object objParamLiat = UoeStockData.StockAdjustDBParamList;
                //    string msg = string.Empty;
                //    IStockAdjustDB stockAdjustWriter = (IStockAdjustDB)MediationStockAdjustDB.GetStockAdjustDB();
                //    {
                //        status = stockAdjustWriter.Write(ref objParamLiat, out msg);
                //        if (!status.Equals((int)Result.RemoteStatus.Normal))
                //        {
                //            Debug.Assert(false, "�݌ɒ���DB�̍X�V�Ɏ��s\n" + status.ToString() + "\n" + msg);
                //        }
                //    }
                //}

                #endregion  // <�P�Ƃō݌ɒ����f�[�^�����������R�[�h/>

                return status;
            }
        }

        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
        /// <summary>
        /// CLC���O�o�͏������\�b�h
        /// </summary>
        /// <param name="pgid">�ďo�����\�b�h��</param>
        /// <param name="message">�o�̓��b�Z�[�W�{��</param>
        /// <remarks>
        /// <br>Note       : CLC���O�o�͋��ʃ��\�b�h���ďo</br>
        /// <br>Programmer : �c������</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public void WriteClcLogProc(string pgid, string message)
        {
            try
            {
                if (LogCommon == null)
                {
                    LogCommon = new OutLogCommon();
                }
                LogCommon.OutputClientLog(pgid, message, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.EmployeeCode);
            }
            catch
            {
                // ���O�o�͏����̂��߁A��O�͖�������
            }
        }
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<

        // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
        /// <summary>
        /// �o�͐���XML�t�@�C���擾
        /// </summary>
        /// <remarks>
        /// <br>Note         : �o�͐���XML�t�@�C���擾�������s��</br>
        /// <br>Programmer   : 杍^</br>
        /// <br>Date         : 2021/12/08</br>
        /// </remarks>
        public void GetControlXmlInfo()
        {
            try
            {
                HisLogOutSettingInfoWork = new HisLogOutSetting();
                if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, HISLOGOUTSETTINGFILE)))
                {
                    // XML�����擾����
                    HisLogOutSettingInfoWork = UserSettingController.DeserializeUserSetting<HisLogOutSetting>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, HISLOGOUTSETTINGFILE));
                }
                else
                {
                    HisLogOutSettingInfoWork.OutFlg = false;
                }
            }
            catch
            {
                if (HisLogOutSettingInfoWork == null) HisLogOutSettingInfoWork = new HisLogOutSetting();
                HisLogOutSettingInfoWork.OutFlg = false;
            }
        }
        // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<

        /// <summary>
        /// �v����������߂邩���肵�܂��B
        /// </summary>
        /// <returns>
        /// <c>true</c> :�����߂�<br/>
        /// <c>false</c>:�����܂�Ȃ�
        /// </returns>
        private static bool CanWriteSumUpInformation()
        {
            return !LoginWorkerAcs.Instance.Policy.UOESetting.DistEnterDiv.Equals(
                (int)LoginWorker.OroshishoDistEnterDiv.Manual
            );
        }

        #region <UOE�����f�[�^/>

        /// <summary>
        /// UOE�����f�[�^�̃��R�[�h���������܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>
        /// UOE�����f�[�^�̃��R�[�h�i��������Ȃ������ꍇ�A<c>null</c>��Ԃ��܂��j
        /// </returns>
        public UOEOrderDtlWork FindUOEOrderDtlWork(ReceivedText receivedTelegram)
        {
            return UoeStockData.FindUOEOrderDtlWork(receivedTelegram);
        }

        /// <summary>
        /// UOE�����f�[�^�̃��R�[�h���������܂��B
        /// </summary>
        /// <param name="dtlRelationGuid">���׊֘A�t��GUID</param>
        /// <returns>
        /// UOE�����f�[�^�̃��R�[�h�i��������Ȃ������ꍇ�A<c>null</c>��Ԃ��܂��j
        /// </returns>
        public UOEOrderDtlWork FindUOEOrderDtlWork(Guid dtlRelationGuid)
        {
            return UoeStockData.FindUOEOrderDtlWork(dtlRelationGuid);
        }

        /// <summary>
        /// UOE�����f�[�^�̃��R�[�h�����擾���܂��B
        /// </summary>
        /// <returns>UOE�����f�[�^�̖��׃��R�[�h��</returns>
        public int GetUOEOrderDataCount()
        {
            return UoeStockData.GetUOEOrderDataCount();
        }

        /// <summary>
        /// UOE�����f�[�^�̖��׃��R�[�h��ǉ����܂��B
        /// </summary>
        /// <param name="uoeOrderDtlWork">UOE�����f�[�^�̖��׃��R�[�h</param>
        /// <param name="pairReceivedText">�΂ɂȂ��M�e�L�X�g�i��M�d���j</param>
        public void AddUOEOrderDtlWork(
            UOEOrderDtlWork uoeOrderDtlWork,
            ReceivedText pairReceivedText
        )
        {
            UoeStockData.AddUOEOrderDtlWork(uoeOrderDtlWork, pairReceivedText);
        }

        #endregion  // <UOE�����f�[�^/>

        #region <�������̎d�����׃f�[�^/>

        /// <summary>
        /// �������̎d�����׃f�[�^���������܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>
        /// �������̎d�����׃f�[�^�̃��R�[�h�i��������Ȃ������ꍇ�A<c>null</c>��Ԃ��܂��j
        /// </returns>
        public StockDetailWork FindStockDetailWork(ReceivedText receivedTelegram)
        {
            return UoeStockData.FindStockDetailWork(receivedTelegram);
        }

        /// <summary>
        /// �������̎d�����׃f�[�^��ǉ����܂��B
        /// </summary>
        /// <param name="stockDetailWork">�������̎d�����׃f�[�^�̃��R�[�h</param>
        /// <param name="pairReceivedText">�΂ɂȂ��M�e�L�X�g�i��M�d���j</param>
        public void AddStockDetailWork(
            StockDetailWork stockDetailWork,
            ReceivedText pairReceivedText
        )
        {
            UoeStockData.AddStockDetailWork(stockDetailWork, pairReceivedText);
        }

        #endregion  // <�������̎d�����׃f�[�^/>

        #region <�������̎d���f�[�^/>

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        public StockSlipWork FindStockSlipWork(ReceivedText receivedTelegram)
        {
            return UoeStockData.FindStockSlipWork(receivedTelegram);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        public string FindSupplierSlipNo(ReceivedText receivedTelegram)
        {
            return UoeStockData.FindSupplierSlipNo(receivedTelegram);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        public long GetStockTotalPrice(ReceivedText receivedTelegram)
        {
            return UoeStockData.GetStockTotalPrice(receivedTelegram);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        public long GetStockSubttlPrice(ReceivedText receivedTelegram)
        {
            return UoeStockData.GetStockSubttlPrice(receivedTelegram);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        public int GetDetailRowCount(ReceivedText receivedTelegram)
        {
            return UoeStockData.GetDetailRowCount(receivedTelegram);
        }

        #region �ꎞ�A�B��

        ///// <summary>
        ///// �������̎d���f�[�^�̃}�b�v���擾���܂��B
        ///// </summary>
        ///// <remarks>
        ///// �L�[�F��M�d���̏o�ד`�[�ԍ�
        ///// </remarks>
        ///// <value>�������̎d���f�[�^�̃}�b�v</value>
        //public IDictionary<string, OrderStockData> OrderStockDataMap
        //{
        //    get { return SearchedResult.OrderInfo.StockDataMap; }
        //}

        #endregion

        #endregion  // <�������̎d���f�[�^/>

        #region <�v����̎d���f�[�^/>

        /// <summary>
        /// �v����𔭒����ŏ��������܂��B
        /// </summary>
        public void InitializeSumUpStockInformation()
        {
            UoeStockData.InitializeSumUpStockInformation();
        }

        /// <summary>
        /// �v����̎d�����׃f�[�^�̃}�b�v���擾���܂��B
        /// </summary>
        public IDictionary<int, IList<StockDetailWork>> SumUpStockSlipDetailRecordMap
        {
            get
            {
                return UoeStockData.SumUpStockSlipDetailRecordMap;
            }
        }

        /// <summary>
        /// �v����̎d���f�[�^�̃}�b�v���擾���܂��B
        /// </summary>
        public IDictionary<int, StockSlipWork> SumUpStockSlipRecordMap
        {
            get
            {
                return UoeStockData.SumUpStockSlipRecordMap;
            }
        }

        /// <summary>
        /// �v����̎d�����׃f�[�^�����擾���܂��B
        /// </summary>
        /// <returns>�v����̎d�����׃f�[�^��</returns>
        public int GetSumUpStockDataCount()
        {
            int count = 0;
            {
                foreach (int supplierSlipNo in UoeStockData.SumUpStockSlipDetailRecordMap.Keys)
                {
                    // 2009/10/14 Add >>>
                    //count += UoeStockData.SumUpStockSlipDetailRecordMap[supplierSlipNo].Count;
                    foreach (StockDetailWork stockDetailWork in UoeStockData.SumUpStockSlipDetailRecordMap[supplierSlipNo])
                    {
                        if (FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid) == null) continue;

                        count++;
                    }
                    // 2009/10/14 Add <<<
                }
            }
            return count;
        }

        #endregion  // <�v����̎d���f�[�^/>

        #region <�v����̍݌Ɏd���f�[�^/>

        /// <summary>
        /// �݌ɒ������𔭒����ŏ��������܂��B
        /// </summary>
        public void InitializeSumUpAdjustInformation()
        {
            UoeStockData.InitializeSumUpAdjustInformation();
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^�̃}�b�v���擾���܂��B
        /// </summary>
        public IDictionary<int, IList<StockAdjustDtlWork>> SumUpStockAdjustDetailRecordMap
        {
            get
            {
                return UoeStockData.SumUpStockAdjustDetailRecordMap;
            }
        }

        /// <summary>
        /// �݌ɒ����f�[�^�̃}�b�v���擾���܂��B
        /// </summary>
        public IDictionary<int, StockAdjustWork> SumUpAdjustRecordMap
        {
            get
            {
                return UoeStockData.SumUpAdjustRecordMap;
            }
        }

        /// <summary>
        /// �v����̍݌ɒ������׃f�[�^�����擾���܂��B
        /// </summary>
        /// <returns>�v����̍݌ɒ������׃f�[�^��</returns>
        public int GetSumUpStockAdjustCount()
        {
            int count = 0;
            {
                foreach (int supplierSlipNo in UoeStockData.SumUpStockAdjustDetailRecordMap.Keys)
                {
                    count += UoeStockData.SumUpStockAdjustDetailRecordMap[supplierSlipNo].Count;
                }
            }
            return count;
        }

        #endregion  // <�v����̍݌Ɏd���f�[�^/>

        #region <����MJNL/>

        /// <summary>����MJNL</summary>
        private List<OrderSndRcvJnl> _orderSndRcvJnlList;
        /// <summary>
        /// ����MJNL���擾���܂��B
        /// </summary>
        public List<OrderSndRcvJnl> OrderSndRcvJnlList
        {
            get
            {
                if (_orderSndRcvJnlList == null)
                {
                    _orderSndRcvJnlList = new List<OrderSndRcvJnl>();
                }
                return _orderSndRcvJnlList;
            }
        }

        /// <summary>
        /// UOE�����f�[�^�𑗎�MJNL�փR�s�[���܂��B
        /// </summary>
        public void CopyUOEOrderDataToUOESendReceiveJournal()
        {
            _orderSndRcvJnlList = UoeStockData.CreateOrderSndRcvJnlList();
        }

        #endregion  // <����MJNL/>

        #region <Debug/>

        /// <summary>
        /// ����������\�����܂��B
        /// </summary>
        /// <param name="uoeOrderDtlList">��������</param>
        [Conditional("DEBUG")]
        private static void PrintSearchingCondition(ArrayList uoeOrderDtlList)
        {
            const string LIST_NAME = "ArrayList<UOEOrderDtlWork>";

            for (int i = 0; i < uoeOrderDtlList.Count; i++)
            {
                UOEOrderDtlWork item = (UOEOrderDtlWork)uoeOrderDtlList[i];

                StringBuilder str = new StringBuilder();
                
                str.Append(LIST_NAME).Append("[").Append(i).Append("].SectionCode = ").Append(item.SectionCode).Append("\n");
                str.Append(LIST_NAME).Append("[").Append(i).Append("].UOESupplierCd = ").Append(item.UOESupplierCd).Append("\n");
                str.Append(LIST_NAME).Append("[").Append(i).Append("].UOESalesOrderNo = ").Append(item.UOESalesOrderNo).Append("\n");
                str.Append(LIST_NAME).Append("[").Append(i).Append("].UOESalesOrderRowNo = ").Append(item.UOESalesOrderRowNo).Append("\n");
                str.Append(LIST_NAME).Append("[").Append(i).Append("].UOEKind = ").Append(item.UOEKind).Append("\n");

                Debug.WriteLine(str.ToString());
            }
        }

        /// <summary>
        /// �X�V������\�����܂��B
        /// </summary>
        /// <param name="slipGroupList">�X�V����</param>
        [Conditional("DEBUG")]
        private static void PrintWritingCondition(CustomSerializeArrayList slipGroupList)
        {
            StringBuilder str = new StringBuilder("[�X�V����]\n");
            {
                str.Append("����E�d������I�v�V�����F");
                IOWriteCtrlOptWork ioWriteCtrlOptWork = (IOWriteCtrlOptWork)slipGroupList[0];
                {
                    str.Append(ioWriteCtrlOptWork.GetType().ToString()).Append(Environment.NewLine);
                    str.Append("\t" + "CtrlStartingPoint = ").Append(ioWriteCtrlOptWork.CtrlStartingPoint).Append(Environment.NewLine);
                    str.Append("\t" + "EstimateAddUpRemDiv = ").Append(ioWriteCtrlOptWork.EstimateAddUpRemDiv).Append(Environment.NewLine);
                    str.Append("\t" + "AcpOdrrAddUpRemDiv = ").Append(ioWriteCtrlOptWork.AcpOdrrAddUpRemDiv).Append(Environment.NewLine);
                    str.Append("\t" + "ShipmAddUpRemDiv = ").Append(ioWriteCtrlOptWork.ShipmAddUpRemDiv).Append(Environment.NewLine);
                    str.Append("\t" + "RetGoodsStockEtyDiv = ").Append(ioWriteCtrlOptWork.RetGoodsStockEtyDiv).Append(Environment.NewLine);
                    str.Append("\t" + "SupplierSlipDelDiv = ").Append(ioWriteCtrlOptWork.SupplierSlipDelDiv).Append(Environment.NewLine);
                    str.Append("\t" + "RemainCntMngDiv = ").Append(ioWriteCtrlOptWork.RemainCntMngDiv).Append(Environment.NewLine);
                    str.Append("\t" + "EnterpriseCode = ").Append(ioWriteCtrlOptWork.EnterpriseCode).Append(Environment.NewLine);
                    str.Append("\t" + "CarMngDivCd = ").Append(ioWriteCtrlOptWork.CarMngDivCd).Append(Environment.NewLine);
                }

                str.Append("UOE�����f�[�^�F");
                CustomSerializeArrayList uoeOrderDataList = (CustomSerializeArrayList)slipGroupList[1];
                str.Append(uoeOrderDataList.GetType().ToString()).Append(Environment.NewLine);
                
                str.Append("UOE�����f�[�^�̃��X�g�F");
                ArrayList uoeOrderDtlWorkList = (ArrayList)uoeOrderDataList[0];
                str.Append(uoeOrderDtlWorkList.GetType().ToString()).Append(Environment.NewLine);
                for (int i = 0; i < uoeOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork dtl = (UOEOrderDtlWork)uoeOrderDtlWorkList[i];

                    str.Append("\tuoeOrderDtlWorkList[").Append(i).Append("].AcceptAnOrderCnt = ").Append(dtl.AcceptAnOrderCnt).Append(Environment.NewLine);
                    str.Append("\tuoeOrderDtlWorkList[").Append(i).Append("].AcptAnOdrStatus = ").Append(dtl.AcptAnOdrStatus).Append(Environment.NewLine);

                    str.Append("\tuoeOrderDtlWorkList[").Append(i).Append("].EnterpriseCode = ").Append(dtl.EnterpriseCode).Append(Environment.NewLine);

                    str.Append("\tuoeOrderDtlWorkList[").Append(i).Append("].SectionCode = ").Append(dtl.SectionCode).Append(Environment.NewLine);
                }
            }
            Debug.WriteLine(str.ToString());
        }

        #endregion  // <Debug/>
    }

    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------>>>>>
    /// <summary>
    /// ���엚���̓o�^�A���O�o�͐ݒ�
    /// </summary>
    public class HisLogOutSetting
    {
        // ���엚���̓o�^�A���O�o�͋敪
        private bool _outFlg;

        /// <summary>
        /// ���엚���̓o�^�A���O�o�͐ݒ�N���X
        /// </summary>
        public HisLogOutSetting()
        {

        }

        /// <summary>���엚���̓o�^�A���O�o�͋敪</summary>
        public bool OutFlg
        {
            get { return this._outFlg; }
            set { this._outFlg = value; }
        }
    }
    // ------ADD 2021/12/08 杍^ �����d����M���� �f�[�^�Ǎ����P�Ή� ------<<<<<
}
