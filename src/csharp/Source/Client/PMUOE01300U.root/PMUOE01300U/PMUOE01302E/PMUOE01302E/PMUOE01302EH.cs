//****************************************************************************//
// �V�X�e��         : �����d����M����
// �v���O��������   : �����d����M����Model
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
// �� �� ��  2009/10/09  �C�����e : ���|�I�v�V���������̏ꍇ�A�݌ɐ؂���܂ނƃG���[�ɂȂ�s��̏C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024  ���X�� �� 
// �� �� ��  2009/10/14  �C�����e : PM���甭�����č݌ɐ؂�̖��ׂ��������ꍇ��
//                                  �d�����ׂ��������̖��ו��ł���s��̏C��(MANTIS[0014423]) 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024  ���X�� �� 
// �� �� ��  2009/10/15  �C�����e : �]�ƈ����̂�16���𒴂���ꍇ�ɃG���[�ɂȂ�s��̏C��(MANTIS[0014375]) 
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�              �쐬�S�� : 21024  ���X�� �� 
// �� �� ��  2010/10/19  �C�����e : �@�����ԍ����܂�����������d���`�[�̑Ή�(MANTIS[0015563])
//                                 �A�݌ɒ����f�[�^�̍쐬�ɂ��āA�o�ɓ`�[�ԍ��{�q�ɒP�ʂō쐬����(MANTIS[0016442])
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-00 �쐬�S�� : 30517 �Ė� �x��
// �� �� ��  K2012/06/22 �C�����e : �R�`���i�ʑΉ�
//                                  ����͔����̏ꍇ�A�d���f�[�^���쐬���Ȃ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10802197-01 �쐬�S�� : FSI���X�� �M�p
// �� �� ��  K2012/12/11 �C�����e : �R�`���i�ʑΉ�
//                                  �R�`���i���S�ʃI�v�V��������ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  10801804-00 �쐬�S�� : �����
// �� �� ��  2013/05/08  �C�����e : 2013/06/18�z�M�� 
//                                 �@Redmine#35459 �G���[�w�����Ɏ��s���܂����B�d�������d���f�[�^�����݂��܂��B�x���o�͂����
//                                 �ARedmine#35611 �R�`���i���S�ʃI�v�V��������ǉ�(�d�b�������̑Ή�)
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11070100-00 �쐬�S�� : ���N�n��
// �� �� ��  2014/05/30  �C�����e : Redmine 42755 �G���[�u�d�������d���f�[�^�����݂��܂��v�̑Ή�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11601223-00  �쐬�S�� : ���O
// �� �� ��  K2021/09/22  �C�����e : PMKOBETSU-4189 ���O�ǉ�
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11800082-00  �쐬�S�� : ���O
// �� �� ��  K2022/04/14  �C�����e : PMKOBETSU-4223 �R�`���iUOE���M�������ɃG���[�ƂȂ����ꍇ�d���f�[�^���쐬����Ȃ����ۂ��C��
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11900025-00  �쐬�S�� : �c������
// �� �� ��  2023/01/20   �C�����e : PMKOBETSU-4202 �����d����M������Q�Ή�
//----------------------------------------------------------------------------//

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

using Broadleaf.Library.Collections;
using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.Remoting.ParamData;
// ADD K2012/12/11 START >>>>>>
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Controller;// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
// ADD K2012/12/11 END <<<<<<

namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// UOE�d���f�[�^�iUOE�����f�[�^ + ������� + �d�����j�̃w���p�N���X
    /// </summary>
    /// <remarks>��UOE�d���f�[�^�͑���ł��B</remarks>
    public class UOEStockDataEssence
    {
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
        #region <���O���e/>
        /// <summary>���O���e</summary>
        private string _logMsg = string.Empty;
        /// <summary>
        /// ���O���e���擾���܂��B
        /// </summary>
        /// <value>���O���e</value>
        public string LogMsg { get { return _logMsg; } }
        #endregion  // <���O���e/>
        // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
        // add K2012/06/22 >>>
        #region DB�X�V�t���O
        private bool _dbWriteFlg = false;

        /// <summary>DB�X�V�t���O</summary>
        public bool DBWriteFlg
        {
            get { return _dbWriteFlg; }
        }
        #endregion
        // add K2012/06/22 <<<

        // ADD K2012/12/11 START >>>>>>
        #region �R�`���i���S�ʃI�v�V��������t���O
        /// <summary>
        /// �R�`���i���S�ʃI�v�V��������t���O
        /// </summary>
        private PurchaseStatus _optionYamagataCustomControl = PurchaseStatus.Uncontract;
        #endregion �R�`���i���S�ʃI�v�V��������
        // ADD K2012/12/11 END <<<<<<

        #region <�������ꂽUOE�d���f�[�^/>

        /// <summary>�������ꂽUOE�d���f�[�^</summary>
        private readonly CustomSerializeArrayList _searchedSlipGroupList;
        /// <summary>
        /// �������ꂽUOE�d���f�[�^���擾���܂��B
        /// </summary>
        private CustomSerializeArrayList SearchedSlipGroupList { get { return _searchedSlipGroupList; } }

        #endregion  // <�������ꂽUOE�d���f�[�^/>

        #region <UOE�����f�[�^/>

        /// <summary>�������ꂽUOE�����f�[�^�̃}�b�v</summary>
        /// <remarks>�L�[�FUOE�����`�[�ԍ�("000000") + UOE�����s�ԍ�("00")</remarks>
        private readonly IDictionary<string, UOEOrderDtlWork> _searchedUOEOrderDetailRecordMap = new Dictionary<string, UOEOrderDtlWork>();
        /// <summary>
        /// �������ꂽUOE�����f�[�^�̃}�b�v���擾���܂��B
        /// </summary>
        private IDictionary<string, UOEOrderDtlWork> SearchedUOEOrderDetailRecordMap
        {
            get { return _searchedUOEOrderDetailRecordMap; }
        }

        #region <�L�[/>

        /// <summary>
        /// UOE�����f�[�^�̃}�b�v�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="uoeOrderDetailRecord">UOE�����f�[�^�̃��R�[�h</param>
        /// <returns>UOE�����ԍ�("000000") + UOE�����s�ԍ�("00")</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459�̑Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        private static string GetUOEOrderDertailKey(UOEOrderDtlWork uoeOrderDetailRecord)
        {
            // UPD ����� for Redmine#35459 2013/05/08  ---->>>>>>
            //return GetUOEOrderDertailKey(uoeOrderDetailRecord.UOESalesOrderNo, uoeOrderDetailRecord.UOESalesOrderRowNo);
            return GetUOEOrderDertailKey(uoeOrderDetailRecord.UOESalesOrderNo, uoeOrderDetailRecord.UOESalesOrderRowNo, uoeOrderDetailRecord.UOESectionSlipNo);
            // UPD ����� for Redmine#35459 2013/05/08  ----<<<<<<
        }

        /// <summary>
        /// UOE�����f�[�^�̃}�b�v�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>�d���⍇���ԍ�("000000") + �񓚓d���Ή��s("00") + �o�ד`�[�ԍ�("000000")</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459�̑Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        private static string GetUOEOrderDertailKey(ReceivedText receivedTelegram)
        {
            int uoeSalesOrderNo     = int.Parse(receivedTelegram.UOESalesOrderNo);
            int uoeSalesOrderRowNo  = int.Parse(receivedTelegram.UOESalesOrderRowNo);

            // UPD ����� for Redmine#35459 2013/05/08  ---->>>>>>
            string uoeSectionSlipNo = receivedTelegram.UOESectionSlipNo;
            //return GetUOEOrderDertailKey(uoeSalesOrderNo, uoeSalesOrderRowNo);
            return GetUOEOrderDertailKey(uoeSalesOrderNo, uoeSalesOrderRowNo, uoeSectionSlipNo);
            // UPD ����� for Redmine#35459 2013/05/08  ----<<<<<<
        }

        // UPD ����� for Redmine#35459 2013/05/08    ------>>>>>>
        /// <summary>
        /// UOE�����f�[�^�̃}�b�v�̃L�[���擾���܂��B
        /// </summary>
        /// <param name="uoeSalesOrderNo">UOE�����ԍ�</param>
        /// <param name="uoeSalesOrderRowNo">UOE�����s�ԍ�</param>
        /// <param name="uoeSectionSlipNo">�o�ד`�[�ԍ�</param>
        /// <returns>UOE�����ԍ�("000000") + UOE�����s�ԍ�("00")+ �o�ד`�[�ԍ�("000000")</returns>
        //private static string GetUOEOrderDertailKey(
        //    int uoeSalesOrderNo,
        //    int uoeSalesOrderRowNo
        //)
        //{
        //    return uoeSalesOrderNo.ToString("000000") + uoeSalesOrderRowNo.ToString("00");
        //}
        private static string GetUOEOrderDertailKey(
            int uoeSalesOrderNo,
            int uoeSalesOrderRowNo,
            string uoeSectionSlipNo
        )
        {
            return uoeSalesOrderNo.ToString("000000") + uoeSalesOrderRowNo.ToString("00")
                + uoeSectionSlipNo.Trim().PadLeft(6, '0');
        }
        // UPD ����� for Redmine#35459 2013/05/08    ------<<<<<<

        #endregion  // <�L�[/>

        #region <�d�b������/>

        /// <summary>�V���ɓo�^����UOE�����f�[�^���R�[�h�̃��X�g</summary>
        /// <remarks>�d�b��������z��</remarks>
        private readonly IList<UOEOrderDtlWork> _insertingUOEOrderDetailRecordList = new List<UOEOrderDtlWork>();
        /// <summary>
        /// �V���ɓo�^����UOE�����f�[�^���R�[�h�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>�d�b��������z��</remarks>
        private IList<UOEOrderDtlWork> InsertingUOEOrderDetailRecordList
        {
            get { return _insertingUOEOrderDetailRecordList; }
        }

        /// <summary>
        /// UOE�����f�[�^�̃��R�[�h��ǉ����܂��B
        /// </summary>
        /// <param name="uoeOrderDtlWork">UOE�����f�[�^�̃��R�[�h</param>
        /// <param name="pairReceivedText">�΂ɂȂ��M�e�L�X�g�i��M�d���j</param>
        /// <remarks>
        /// <br>Update Note: Redmine#35611�̑Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08 </br>
        /// <br>Update Note: PMKOBETSU-4223 �R�`���i�d���f�[�^���쐬����Ȃ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : K2022/04/14</br>
        /// </remarks>
        public void AddUOEOrderDtlWork(
            UOEOrderDtlWork uoeOrderDtlWork,
            ReceivedText pairReceivedText
        )
        {
            InsertingUOEOrderDetailRecordList.Add(uoeOrderDtlWork);


            // ADD ����� for Redmine#356111 2013/05/08   ---->>>>>>
            // --- UPD K2022/04/14 ���O PMKOBETSU-4223�̑Ή� --->>>>>
            //if (PurchaseStatus.Contract == _optionYamagataCustomControl)
            // �R�`���i�I�v�V��������A���d���⍇���ԍ�= 0�̎��AUOE�����f�[�^���쐬���Ȃ�
            if (PurchaseStatus.Contract == _optionYamagataCustomControl && int.Parse(pairReceivedText.UOESalesOrderNo) == 0)
            // --- UPD K2022/04/14 ���O PMKOBETSU-4223�̑Ή� ---<<<<<
            {
                string key = uoeOrderDtlWork.UOESalesOrderNo.ToString("000000")
                        + uoeOrderDtlWork.UOESalesOrderRowNo.ToString("00")
                        + uoeOrderDtlWork.UOESectionSlipNo.Trim().PadLeft(6, '0');
                if (!_noAddUoeOderList.Contains(key))
                {
                    _noAddUoeOderList.Add(key);
                }
            }
            // ADD ����� for Redmine#356111 2013/05/08   ----<<<<<<
        }

        #endregion  // <�d�b������/>

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int GetUOEOrderDataCount()
        {
            return SearchedUOEOrderDetailRecordMap.Values.Count + InsertingUOEOrderDetailRecordList.Count;
        }

        #endregion  // <UOE�����f�[�^/>

        #region <UOE�����f�[�^�Ǝd�����׃f�[�^�̂Ȃ�/>

        /// <summary>UOE�����`�[�ԍ�+UOE�����ԍ� �� �d�����גʔ� ���Ȃ��}�b�v</summary>
        private readonly IDictionary<string, long> _chainKeyMap = new Dictionary<string, long>();
        /// <summary>
        /// UOE�����`�[�ԍ�+UOE�����ԍ� �� �d�����גʔ� ���Ȃ��}�b�v���擾���܂��B
        /// </summary>
        private IDictionary<string, long> ChainKeyMap
        {
            get { return _chainKeyMap; }
        }

        #endregion  // <UOE�����f�[�^�Ǝd�����׃f�[�^�̂Ȃ�/>

        #region <UOE�����f�[�^�Ǝd���f�[�^�̂Ȃ�/>

        /// <summary>UOE�����`�[�ԍ�+UOE�����ԍ� �� �d���`�[�ԍ� ���Ȃ��}�b�v</summary>
        //private readonly IDictionary<string, int> _bridgeKeyMap = new Dictionary<string, int>();  // DEL ����� for Redmine#35459 2013/05/08
        private readonly IDictionary<string, long> _bridgeKeyMap = new Dictionary<string, long>();  // ADD ����� for Redmine#35459 2013/05/08
        /// <summary>
        /// UOE�����`�[�ԍ�+UOE�����ԍ� �� �d���`�[�ԍ� ���Ȃ��}�b�v���擾���܂��B
        /// </summary>
        //private IDictionary<string, int> BridgeKeyMap  // DEL ����� for Redmine#35459 2013/05/08
        private IDictionary<string, long> BridgeKeyMap   // ADD ����� for Redmine#35459 2013/05/08
        {
            get { return _bridgeKeyMap; }
        }

        #endregion  // <UOE�����f�[�^�Ǝd���f�[�^�̂Ȃ�/>

        // add K2012/06/22 >>>
        // �ǉ����Ȃ��e�f�[�^�̃��X�g
        private List<string> _noAddUoeOderList = new List<string>();
        //private List<int> _noAddStockSlipList = new List<int>(); // DEL ����� for Redmine#35459 2013/05/08
        private List<long> _noAddStockSlipList = new List<long>(); // ADD ����� for Redmine#35459 2013/05/08
        private List<long> _noAddStockDetailList = new List<long>();
        private const string CtLogDataMassage = "�v�X�V�ް�:UOE�����ް�={0}��;�d���ް�={1}��;�d�������ް�={2}��;�݌ɒ����ް�={3}��;�݌ɒ��������ް�={4}��";// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
        // add K2012/06/22 <<<

        #region <�������̎d�����׃f�[�^/>

        /// <summary>�������ꂽ�d�����׃f�[�^�̃}�b�v</summary>
        /// <remarks>�L�[�F�d�����גʔ�</remarks>
        private readonly IDictionary<long, StockDetailWork> _searchedStockDetailRecordMap = new Dictionary<long, StockDetailWork>();
        /// <summary>
        /// �������ꂽ�d�����׃f�[�^�̃}�b�v���擾���܂��B
        /// </summary>
        private IDictionary<long, StockDetailWork> SearchedStockDetailRecordMap
        {
            get { return _searchedStockDetailRecordMap; }
        }

        #region <�d�b������/>

        /// <summary>�V���ɓo�^���锭�����̎d�����׃f�[�^���R�[�h�̃��X�g</summary>
        /// <remarks>�d�b��������z��</remarks>
        private readonly IList<StockDetailWork> _insertingOrderStockDetailRecordList = new List<StockDetailWork>();
        /// <summary>
        /// �V���ɓo�^���锭�����̎d�����׃f�[�^���R�[�h�̃��X�g���擾���܂��B
        /// </summary>
        /// <remarks>�d�b��������z��</remarks>
        private IList<StockDetailWork> InsertingOrderStockDetailRecordList
        {
            get { return _insertingOrderStockDetailRecordList; }
        }

        /// <summary>�d�b�������̎d���`�[�ԍ��i���j�̃}�b�v</summary>
        /// <remarks>�L�[�F��M�d���̏o�ד`�[�ԍ�</remarks>
        //private readonly IDictionary<string, int> _telOrderSupplierSlipNoMap = new Dictionary<string, int>();  // DEL ����� for Redmine#35459 2013/05/08
        private readonly IDictionary<string, long> _telOrderSupplierSlipNoMap = new Dictionary<string, long>();  // ADD ����� for Redmine#35459 2013/05/08
        /// <summary>
        /// �d�b�������̎d���`�[�ԍ��i���j�̃}�b�v
        /// </summary>
        /// <remarks>�L�[�F��M�d���̏o�ד`�[�ԍ�</remarks>
        //private IDictionary<string, int> TelOrderSupplierSlipNoMap  // DEL ����� for Redmine#35459 2013/05/08
        private IDictionary<string, long> TelOrderSupplierSlipNoMap   // ADD ����� for Redmine#35459 2013/05/08
        {
            get { return _telOrderSupplierSlipNoMap; }
        }

        /// <summary>�d�b�������̎d���`�[�ԍ��i���j�̃J�E���^</summary>
        /// <remarks>�f�N�������g����Ă����܂��B</remarks>
        private int _telOrderSupplierSlipNoCount = 0;
        /// <summary>
        /// �d�b�������̎d���`�[�ԍ��i���j�̃J�E���^
        /// </summary>
        /// <remarks>�f�N�������g����Ă����܂��B</remarks>
        private int TelOrderSupplierSlipNoCount
        {
            get { return _telOrderSupplierSlipNoCount; }
            set { _telOrderSupplierSlipNoCount = value; }
        }

        #endregion  // <�d�b������/>

        /// <summary>�`�[�Ɩ��׃��X�g�i�d�b�������܂ށj�̃}�b�v</summary>
        //private readonly IDictionary<int, IList<StockDetailWork>> _stockSlipDetailRecordMap = new Dictionary<int, IList<StockDetailWork>>();  // DEL ����� for Redmine#35459 2013/05/08
        private readonly IDictionary<long, IList<StockDetailWork>> _stockSlipDetailRecordMap = new Dictionary<long, IList<StockDetailWork>>();  // ADD ����� for Redmine#35459 2013/05/08
        /// <summary>
        /// �`�[�Ɩ��׃��X�g�i�d�b�������܂ށj�̃}�b�v���擾���܂��B
        /// </summary>
        //private IDictionary<int, IList<StockDetailWork>> StockSlipDetailRecordMap  // DEL ����� for Redmine#35459 2013/05/08
        private IDictionary<long, IList<StockDetailWork>> StockSlipDetailRecordMap   // ADD ����� for Redmine#35459 2013/05/08
        {
            get { return _stockSlipDetailRecordMap; }
        } 

        #endregion  // <�������̎d�����׃f�[�^/>

        // 2010/10/19 Add >>>
        #region <��M�d��/>

        /// <summary>��M�d���̏W����</summary>
        private readonly IAgreegate<ReceivedText> _receivedTelegramAgreegate;
        /// <summary>
        /// ��M�d���̏W���̂��擾���܂��B
        /// </summary>
        /// <value>��M�d���̏W����</value>
        protected IAgreegate<ReceivedText> ReceivedTelegramAgreegate { get { return _receivedTelegramAgreegate; } }
        #endregion  // <��M�d��/>
        // 2010/10/19 Add <<<

        /// <summary>
        /// �������̎d�����׃f�[�^��ǉ����܂��B�i�d�b��������z��j
        /// </summary>
        /// <param name="stockDetailWork">�������̎d�����׃f�[�^�̃��R�[�h</param>
        /// <param name="pairReceivedText">�΂ɂȂ��M�e�L�X�g�i��M�d���j</param>
        /// <remarks>
        /// <br>Update Note: Redmine#35459��Redmine#35611�̑Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08 </br>
        /// <br>Update Note: PMKOBETSU-4223 �R�`���i�d���f�[�^���쐬����Ȃ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : K2022/04/14 </br>
        /// </remarks>
        public void AddStockDetailWork(
            StockDetailWork stockDetailWork,
            ReceivedText pairReceivedText
        )
        {
            InsertingOrderStockDetailRecordList.Add(stockDetailWork);

            // ���̎d���`�[�ԍ���ݒ�
            string key = pairReceivedText.ToSlipNo();
            if (!TelOrderSupplierSlipNoMap.ContainsKey(key))
            {
                TelOrderSupplierSlipNoMap.Add(key, --TelOrderSupplierSlipNoCount);
            }
            //int telOrderSupplierSlipNo = TelOrderSupplierSlipNoMap[key];  // DEL ����� for Redmine#35459 2013/05/08
            long telOrderSupplierSlipNo = TelOrderSupplierSlipNoMap[key];   // ADD ����� for Redmine#35459 2013/05/08

            // �d�����׃f�[�^
            if (!StockSlipDetailRecordMap.ContainsKey(telOrderSupplierSlipNo))
            {
                StockSlipDetailRecordMap.Add(telOrderSupplierSlipNo, new List<StockDetailWork>());
            }
            StockSlipDetailRecordMap[telOrderSupplierSlipNo].Add(stockDetailWork);

            // �d���f�[�^
            if (!StockSlipRecordMap.ContainsKey(telOrderSupplierSlipNo))
            {
                StockSlipRecordMap.Add(telOrderSupplierSlipNo, new StockSlipWork());
            }

            // ADD ����� for Redmine#35611 2013/05/08   ---->>>>>>
            // --- UPD K2022/04/14 ���O PMKOBETSU-4223�̑Ή� --->>>>>
            //if (PurchaseStatus.Contract == _optionYamagataCustomControl)
            // �R�`���i�I�v�V��������A���d���⍇���ԍ�= 0�̎��A�d���f�[�^(����)���쐬���Ȃ�
            if (PurchaseStatus.Contract == _optionYamagataCustomControl && int.Parse(pairReceivedText.UOESalesOrderNo) == 0)
            // --- UPD K2022/04/14 ���O PMKOBETSU-4223�̑Ή� ---<<<<<
            {
                // �d�b���������A�d���`�[�ԍ��Ɣ��㖾�גʔԂ��u0�v
                long key2 = 0;

                if (!_noAddStockSlipList.Contains(key2))
                    _noAddStockSlipList.Add(key2);
                if (!_noAddStockDetailList.Contains(key2))
                    _noAddStockDetailList.Add(key2);
            }
            // ADD ����� for Redmine#35611 2013/05/08   ----<<<<<<
        }

        #region <�������̎d���f�[�^/>

        /// <summary>�d���f�[�^�i�d�b�������܂ށj�̃}�b�v</summary>
        /// <remarks>�L�[�F�d���`�[�ԍ�</remarks>
        //private readonly IDictionary<int, StockSlipWork> _stockSlipRecordMap = new Dictionary<int, StockSlipWork>();  // DEL ����� for Redmine#35459 2013/05/08
        private readonly IDictionary<long, StockSlipWork> _stockSlipRecordMap = new Dictionary<long, StockSlipWork>();  // ADD ����� for Redmine#35459 2013/05/08
        /// <summary>
        /// �d���f�[�^�i�d�b�������܂ށj�̃}�b�v���擾���܂��B
        /// </summary>
        //private IDictionary<int, StockSlipWork> StockSlipRecordMap // DEL ����� for Redmine#35459 2013/05/08
        private IDictionary<long, StockSlipWork> StockSlipRecordMap  // ADD ����� for Redmine#35459 2013/05/08
        {
            get { return _stockSlipRecordMap; }
        }

        #endregion  // <�������̎d���f�[�^/>

        #region <�v����̎d���n�f�[�^/>

        /// <summary>�v����̎d���f�[�^�̃}�b�v</summary>
        private IDictionary<int, StockSlipWork> _sumUpStockSlipRecordMap;
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<int, StockSlipWork> SumUpStockSlipRecordMap
        {
            get
            {
                if (_sumUpStockSlipRecordMap == null)
                {
                    _sumUpStockSlipRecordMap = new Dictionary<int, StockSlipWork>();
                }
                return _sumUpStockSlipRecordMap;
            }
        }

        /// <summary>�v����̎d�����׃f�[�^�̃}�b�v</summary>
        private IDictionary<int, IList<StockDetailWork>> _sumUpStockSlipDetailRecordMap;
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<int, IList<StockDetailWork>> SumUpStockSlipDetailRecordMap
        {
            get
            {
                if (_sumUpStockSlipDetailRecordMap == null)
                {
                    _sumUpStockSlipDetailRecordMap = new Dictionary<int, IList<StockDetailWork>>();
                }
                return _sumUpStockSlipDetailRecordMap;
            }
        }

        /// <summary>
        /// �v����̎d���f�[�^�A�d�����׃f�[�^�𔭒����̎d���f�[�^�A�d�����׃f�[�^�ŏ��������܂��B
        /// </summary>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: �R�`���i���S�ʃI�v�V��������ǉ�</br>
        /// <br>Programmer : FSI���X�� �M�p</br>
        /// <br>Date       : K2012/12/11 </br>
        /// <br>Update Note: PMKOBETSU-4223 �R�`���i�d���f�[�^���쐬����Ȃ��Ή�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : K2022/04/14 </br>
        /// </remarks>
        public void InitializeSumUpStockInformation()
        {
            SumUpStockSlipRecordMap.Clear();
            SumUpStockSlipDetailRecordMap.Clear();
            
            // 2010/10/19 >>>
#if False
            foreach (int supplierSlipNo in StockSlipDetailRecordMap.Keys)
            {
                // �v����̎d���f�[�^
                StockSlipWork copySlip = StockSlipRecordMap[supplierSlipNo].Clone();
                SumUpStockSlipRecordMap.Add(supplierSlipNo, copySlip);

                // �v����̎d�����׃f�[�^
                SumUpStockSlipDetailRecordMap.Add(supplierSlipNo, new List<StockDetailWork>());
                foreach (StockDetailWork stockDetailWork in StockSlipDetailRecordMap[supplierSlipNo])
                {
                    StockDetailWork copyRecord = stockDetailWork.Clone();

                    SumUpStockSlipDetailRecordMap[supplierSlipNo].Add(copyRecord);
                }
            }
#endif

            int slipNo = 0;
            foreach (string uoeSlipNo in ReceivedTelegramAgreegate.GroupedListMap.Keys)
            {
                IList<ReceivedText> uoeSlip = ReceivedTelegramAgreegate.GroupedListMap[uoeSlipNo];
                StockSlipWork work = new StockSlipWork();
                // del K2012/06/22 >>>
                //work.PartySaleSlipNum = uoeSlipNo;
                //SumUpStockSlipRecordMap.Add(slipNo, work);
                // del K2012/06/22 <<<
                // ADD K2012/12/11 START >>>>>>
                // �R�`���i���S�ʃI�v�V�����������̏ꍇ
                if (PurchaseStatus.Contract != _optionYamagataCustomControl)
                {
                    work.PartySaleSlipNum = uoeSlipNo;
                    SumUpStockSlipRecordMap.Add(slipNo, work);
                }
                // ADD K2012/12/11 END <<<<<<

                List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
                SumUpStockSlipDetailRecordMap.Add(slipNo, new List<StockDetailWork>());

                bool updFlg = true; // add K2012/06/22

                // ����o�ד`�[�ԍ��ɂ������M�e�L�X�g�i���ׁj�̃��[�v
                foreach (ReceivedText receivedTelegram in uoeSlip)
                {
                    //SumUpStockSlipDetailRecordMap[slipNo].Add(FindStockDetailWork(receivedTelegram).Clone());   // del K2012/06/22
                    // ADD K2012/12/11 START >>>>>>
                    // --- UPD K2022/04/14 ���O PMKOBETSU-4223�̑Ή� --->>>>>
                    //if (PurchaseStatus.Contract != _optionYamagataCustomControl)
                    // �R�`���i���S�ʃI�v�V�����Ȃ��A���邢�͓d���⍇���ԍ��� 0�̎��A�d���f�[�^���쐬����
                    if (PurchaseStatus.Contract != _optionYamagataCustomControl || int.Parse(receivedTelegram.UOESalesOrderNo) != 0)
                    // --- UPD K2022/04/14 ���O PMKOBETSU-4223�̑Ή� ---<<<<<
                    {
                        // �R�`���i���S�ʃI�v�V�����������̏ꍇ
                        SumUpStockSlipDetailRecordMap[slipNo].Add(FindStockDetailWork(receivedTelegram).Clone());
                        continue;
                    }
                    // ADD K2012/12/11 END <<<<<<
                    // add K2012/06/22 >>>
                    StockDetailWork stockDetailWorkList2 = new StockDetailWork();
                    stockDetailWorkList2 = FindStockDetailWork2(receivedTelegram);
                    if (stockDetailWorkList2 == null)
                    {
                        stockDetailWorkList2 = new StockDetailWork();
                        updFlg = false;
                    }
                    SumUpStockSlipDetailRecordMap[slipNo].Add(stockDetailWorkList2.Clone());
                    // add K2012/06/22 <<<
                }
                // DEL K2012/12/11 START >>>>>>
                //// add K2012/06/22 >>>
                //if (updFlg)
                //    work.PartySaleSlipNum = uoeSlipNo;
                //SumUpStockSlipRecordMap.Add(slipNo, work);
                //// add K2012/06/22 <<<
                // DEL K2012/12/11 END <<<<<<
                // ADD K2012/12/11 START >>>>>>
                if (PurchaseStatus.Contract == _optionYamagataCustomControl)
                {
                    // �R�`���i���S�ʃI�v�V�������L���̏ꍇ
                    // DEL  by ����� for Redmine#35611 on 2013/05/08 --------->>>>>>>
                    //if (updFlg)
                    //    work.PartySaleSlipNum = uoeSlipNo;
                    // DEL  by ����� for Redmine#35611 on 2013/05/08 ---------<<<<<<<<

                    // ADD by ����� for Redmine#35611 on 2013/05/08 --------->>>>>>>
                    if (updFlg)
                    {
                        work.PartySaleSlipNum = uoeSlipNo;
                    }
                    else
                    {
                        work.PartySaleSlipNum = "FALSE" + uoeSlipNo;
                    }
                    // ADD by ����� for Redmine#35611 on 2013/05/08 ---------<<<<<<<<


                    SumUpStockSlipRecordMap.Add(slipNo, work);
                }
                // ADD K2012/12/11 END <<<<<<
                slipNo++;
            }
            // 2010/10/19 <<<
        }

        #endregion  // <�v����̎d���n�f�[�^/>

        #region <�v����̍݌Ɍn�f�[�^/>

        /// <summary>�v����̍݌ɒ����f�[�^�̃}�b�v</summary>
        private IDictionary<int, StockAdjustWork> _sumUpAdjustRecordMap;
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<int, StockAdjustWork> SumUpAdjustRecordMap
        {
            get
            {
                if (_sumUpAdjustRecordMap == null)
                {
                    _sumUpAdjustRecordMap = new Dictionary<int, StockAdjustWork>();
                }
                return _sumUpAdjustRecordMap;
            }
        }

        /// <summary>�v����̍݌ɒ������׃f�[�^�̃}�b�v</summary>
        private IDictionary<int, IList<StockAdjustDtlWork>> _sumUpStockAdjustDetailRecordMap;
        /// <summary>
        /// 
        /// </summary>
        public IDictionary<int, IList<StockAdjustDtlWork>> SumUpStockAdjustDetailRecordMap
        {
            get
            {
                if (_sumUpStockAdjustDetailRecordMap == null)
                {
                    _sumUpStockAdjustDetailRecordMap = new Dictionary<int, IList<StockAdjustDtlWork>>();
                }
                return _sumUpStockAdjustDetailRecordMap;
            }
        }

        /// <summary>
        /// �v����̍݌ɒ����f�[�^�A�݌ɒ������׃f�[�^�𔭒����̎d���f�[�^�A�d�����׃f�[�^�ŏ��������܂��B
        /// </summary>
        public void InitializeSumUpAdjustInformation()
        {
            SumUpAdjustRecordMap.Clear();
            SumUpStockAdjustDetailRecordMap.Clear();

            // 2010/10/19 �A�Ή� >>>
#if False
            foreach (int supplierSlipNo in StockSlipDetailRecordMap.Keys)
            {
                // �v����̍݌ɒ����f�[�^
                StockAdjustWork stockAdjustWork = CreateStockAdjustWork(StockSlipRecordMap[supplierSlipNo]);
                SumUpAdjustRecordMap.Add(supplierSlipNo, stockAdjustWork);

                // �v����̍݌ɒ������׃f�[�^
                IList<StockAdjustDtlWork> stockAdjustDtlWorkList = new List<StockAdjustDtlWork>();
                foreach (StockDetailWork stockDetailWork in StockSlipDetailRecordMap[supplierSlipNo])
                {
                    // ����������
                    const int SLIP_START = 1;       // �@�V�X�e���敪�� 1:�`��
                    const int NONE_WAREHOUSE = 0;   // �A�q�ɃR�[�h�� 0
                    // 2009/10/09 Add >>>
                    // ��M����UOE�����f�[�^�Ɋ܂܂�Ȃ��f�[�^�͏������Ȃ�
                    if (FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid) == null) continue;
                    // 2009/10/09 Add <<<
                    if (
                        FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid).SystemDivCd.Equals(SLIP_START)
                            ||
                        string.IsNullOrEmpty(stockDetailWork.WarehouseCode.Trim())
                            ||
                        stockDetailWork.WarehouseCode.Equals(NONE_WAREHOUSE)
                    )
                    {
                        continue;
                    }
                    StockAdjustDtlWork stockAdjustDtlWork = CreateStockAdjustDtlWork(stockDetailWork);
                    stockAdjustDtlWorkList.Add(stockAdjustDtlWork);
                }

                if (stockAdjustDtlWorkList.Count > 0)
                {
                    SumUpStockAdjustDetailRecordMap.Add(supplierSlipNo, stockAdjustDtlWorkList);
                }
            }

#endif
            // �݌ɒ������׃f�[�^���A��U�܂Ƃ߂�ׂ̃��X�g
            Dictionary<StockSlipWork, List<StockAdjustDtlWork>> tempList = new Dictionary<StockSlipWork, List<StockAdjustDtlWork>>();

            // �ŏ��ɁAUOE�o�ɓ`�[�ԍ��P�ʂō݌ɒ������׃f�[�^�𐶐�����
            foreach (string uoeSlipNo in ReceivedTelegramAgreegate.GroupedListMap.Keys)
            {
                StockSlipWork stockSlipWork = null;
                IList<ReceivedText> uoeSlip = ReceivedTelegramAgreegate.GroupedListMap[uoeSlipNo];
                //tempList.Add(uoeSlipNo,new List<StockAdjustDtlWork>());
                // �o�ד`�[�ԍ��ɂ������M�e�L�X�g�i���ׁj�̃��[�v
                foreach (ReceivedText receivedTelegram in uoeSlip)
                {
                    StockDetailWork stockDetailWork = FindStockDetailWork(receivedTelegram);

                    // ����������
                    const int SLIP_START = 1;       // �@�V�X�e���敪�� 1:�`��
                    const int NONE_WAREHOUSE = 0;   // �A�q�ɃR�[�h�� 0
                    // ��M����UOE�����f�[�^�Ɋ܂܂�Ȃ��f�[�^�͏������Ȃ�
                    if (FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid) == null) continue;
                    if (
                        FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid).SystemDivCd.Equals(SLIP_START)
                            ||
                        string.IsNullOrEmpty(stockDetailWork.WarehouseCode.Trim())
                            ||
                        stockDetailWork.WarehouseCode.Equals(NONE_WAREHOUSE)
                    )
                    {
                        continue;
                    }
                    StockAdjustDtlWork stockAdjustDtlWork = CreateStockAdjustDtlWork(stockDetailWork);

                    if (stockSlipWork == null)
                    {
                        StockSlipWork work = FindStockSlipWork(receivedTelegram);
                        if (work == null)
                            stockSlipWork = new StockSlipWork();
                        else
                            stockSlipWork = work.Clone();

                        tempList.Add(stockSlipWork, new List<StockAdjustDtlWork>());
                    }

                    tempList[stockSlipWork].Add(stockAdjustDtlWork);
                }
            }

            int slipNo = 0;

            // ���_�o�ɔԍ��P�ʂł܂Ƃ߂�ꂽ���ׂ��A�q�ɖ��ɕ����Ă���f�[�^�ǉ�
            foreach (StockSlipWork stockslipWork in tempList.Keys)
            {
                List<StockAdjustDtlWork> list = tempList[stockslipWork];

                ArrayList workArray = DivisionStockAdjustData(list);
                if (workArray != null && workArray.Count > 0)
                {
                    foreach (List<StockAdjustDtlWork> oneBlock in workArray)
                    {
                        if (oneBlock.Count == 0) continue;

                        StockAdjustWork stockAdjustWork = CreateStockAdjustWork(stockslipWork);
                        SumUpAdjustRecordMap.Add(++slipNo, stockAdjustWork);

                        SumUpStockAdjustDetailRecordMap.Add(slipNo, oneBlock);
                    }
                }
            }
            // 2010/10/19 <<<
        }

        // 2010/10/19 Add >>>
        /// <summary>
        ///  �݌ɒ������׃��X�g��q�ɏ��Ƀ\�[�g���ĕԂ��܂��B
        /// </summary>
        /// <param name="stockAdjustDtlWorkList"></param>
        /// <returns></returns>
        private static ArrayList DivisionStockAdjustData(List<StockAdjustDtlWork> stockAdjustDtlWorkList)
        {
            if (stockAdjustDtlWorkList == null || stockAdjustDtlWorkList.Count == 0) return null;

            ArrayList retList = new ArrayList();
            SortedDictionary<string, List<StockAdjustDtlWork>> sortedList = new SortedDictionary<string, List<StockAdjustDtlWork>>();

            string warehouseCode;
            foreach (StockAdjustDtlWork stockAdjustDtlWork in stockAdjustDtlWorkList)
            {
                warehouseCode = stockAdjustDtlWork.WarehouseCode.Trim();
                if (!sortedList.ContainsKey(warehouseCode))
                {
                    sortedList.Add(warehouseCode, new List<StockAdjustDtlWork>());
                }
                sortedList[warehouseCode].Add(stockAdjustDtlWork);
            }

            foreach (List<StockAdjustDtlWork> tempList in sortedList.Values)
            {
                retList.Add(tempList);
            }

            return retList;
        }
        // 2010/10/19 Add <<<

        /// <summary>
        /// �d���f�[�^����݌ɒ����f�[�^�𐶐����܂��B
        /// </summary>
        /// <param name="stockSlipWork">�d���f�[�^</param>
        /// <returns>�݌ɒ����f�[�^</returns>
        private static StockAdjustWork CreateStockAdjustWork(StockSlipWork stockSlipWork)
        {
            StockAdjustWork stockAdjustWork = new StockAdjustWork();
            {
                // 003.��ƃR�[�h
                stockAdjustWork.EnterpriseCode = stockSlipWork.EnterpriseCode;
                // 009.���_�R�[�h
                stockAdjustWork.SectionCode = stockSlipWork.SectionCode;

                // 014.�󕥌��`�[�敪
                stockAdjustWork.AcPaySlipCd = stockSlipWork.SupplierSlipCd;

                // 015.�d�����_�R�[�h
                stockAdjustWork.StockSectionCd = stockSlipWork.StockSectionCd;
                // 016.�d�����͎҃R�[�h
                stockAdjustWork.StockInputCode = stockSlipWork.StockInputCode;
                // 017.�d�����͎Җ���
                stockAdjustWork.StockInputName = stockSlipWork.StockInputName;
                // 018.�d���S���҃R�[�h
                stockAdjustWork.StockAgentCode = stockSlipWork.StockAgentCode;
                // 019.�d���S���Җ���
                stockAdjustWork.StockAgentName = stockSlipWork.StockAgentName;
                // 020.�d�����z���v
                stockAdjustWork.StockSubttlPrice = stockSlipWork.StockSubttlPrice;
            }
            return stockAdjustWork;
        }

        /// <summary>
        /// �d�����׃f�[�^����݌ɒ������׃f�[�^�𐶐����܂��B
        /// </summary>
        /// <param name="stockDetailWork">�d�����׃f�[�^</param>
        /// <returns>�݌ɒ������׃f�[�^</returns>
        private static StockAdjustDtlWork CreateStockAdjustDtlWork(StockDetailWork stockDetailWork)
        {
            StockAdjustDtlWork stockAdjustDtlWork = new StockAdjustDtlWork();
            {
                // 003.��ƃR�[�h
                stockAdjustDtlWork.EnterpriseCode = stockDetailWork.EnterpriseCode;
                // 009.���_�R�[�h
                stockAdjustDtlWork.SectionCode = stockDetailWork.SectionCode;
                // 012.�d���`���i���j
                stockAdjustDtlWork.SupplierFormalSrc = stockDetailWork.SupplierFormal;
                // 013.�d�����גʔԁi���j
                stockAdjustDtlWork.StockSlipDtlNumSrc = stockDetailWork.StockSlipDtlNum;
                // 014.�󕥌��`�[�敪�F�v�㌳�̓`�[�敪
                stockAdjustDtlWork.AcPaySlipCd = stockDetailWork.StockSlipCdDtl;
                // 018.���i���[�J�[�R�[�h
                stockAdjustDtlWork.GoodsMakerCd = stockDetailWork.GoodsMakerCd;
                // 019.���[�J�[����
                stockAdjustDtlWork.MakerName = stockDetailWork.MakerName;
                // 020.���i�ԍ�
                stockAdjustDtlWork.GoodsNo = stockDetailWork.GoodsNo;
                // 021.���i����
                stockAdjustDtlWork.GoodsName = stockDetailWork.GoodsName;
                // 022.�d���P���i�Ŕ�, �����j
                stockAdjustDtlWork.StockUnitPriceFl = stockDetailWork.StockUnitPriceFl;
                // 023.�ύX�O�d���P���i�����j
                stockAdjustDtlWork.BfStockUnitPriceFl = stockDetailWork.BfStockUnitPriceFl;
                // 024.������
                stockAdjustDtlWork.AdjustCount = stockDetailWork.StockCount;
                // 026.�q�ɃR�[�h
                stockAdjustDtlWork.WarehouseCode = stockDetailWork.WarehouseCode;
                // 027.�q�ɖ���
                stockAdjustDtlWork.WarehouseName = stockDetailWork.WarehouseName;
                // 028.BL���i�R�[�h
                stockAdjustDtlWork.BLGoodsCode = stockDetailWork.BLGoodsCode;
                // 029.BL���i�R�[�h���́i�S�p�j
                stockAdjustDtlWork.BLGoodsFullName = stockDetailWork.BLGoodsFullName;
                // 030.�q�ɒI��
                stockAdjustDtlWork.WarehouseShelfNo = stockDetailWork.WarehouseShelfNo;
                // 031.�艿�i�����j
                stockAdjustDtlWork.ListPriceFl = stockDetailWork.ListPriceTaxExcFl;
            }
            return stockAdjustDtlWork;
        }

        #endregion  // <�v����̍݌Ɍn�f�[�^/>

        #region <Constructor/>

        /// <summary>
        /// �J�X�^���R���X�g���N�^
        /// </summary>
        /// <param name="seachedSlipGroupList">�������ꂽUOE�d���f�[�^</param>
        /// <param name="receivedTelegramAgreegate">��M�d��</param>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: �R�`���i���S�ʃI�v�V��������ǉ�</br>
        /// <br>Programmer : FSI���X�� �M�p</br>
        /// <br>Date       : K2012/12/11 </br>
        /// <br>Update Note: Redmine#35459�̑Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        // 2010/10/19 >>>
        //public UOEStockDataEssence(CustomSerializeArrayList seachedSlipGroupList)
        public UOEStockDataEssence(CustomSerializeArrayList seachedSlipGroupList, IAgreegate<ReceivedText> receivedTelegramAgreegate)
        // 2010/10/19 <<<
        {
            _searchedSlipGroupList = seachedSlipGroupList;
            _receivedTelegramAgreegate = receivedTelegramAgreegate;     // 2010/10/19 Add

            //if (IsNullOrEmpty(seachedSlipGroupList)) return;   // DEL  by ����� for Redmine#35459 on 2013/05/08 

            // ADD K2012/12/11 START >>>>>>
            #region �R�`���i���S�ʃI�v�V��������
            // �R�`���i���S�ʃI�v�V��������
            _optionYamagataCustomControl = LoginInfoAcquisition.SoftwarePurchasedCheckForUSB(
                ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_YamagataCustomControl);
            #endregion �R�`���i���S�ʃI�v�V��������
            // ADD K2012/12/11 END <<<<<<

            if (IsNullOrEmpty(seachedSlipGroupList)) return;   // ADD by ����� for Redmine#35459 on 2013/05/08

            // UOE�����f�[�^
            #region <UOE�����f�[�^/>

            ArrayList uoeOrderDtlWorkList = seachedSlipGroupList[0] as ArrayList;
            if (IsNullOrEmpty(uoeOrderDtlWorkList)) return;

            foreach (UOEOrderDtlWork uoeOrderDtlWork in uoeOrderDtlWorkList)
            {
                // modified by ����� for Redmine#35459 on 2013/05/08 begin
                //string key = GetUOEOrderDertailKey(uoeOrderDtlWork);
                string key = uoeOrderDtlWork.UOESalesOrderNo.ToString("000000") + uoeOrderDtlWork.UOESalesOrderRowNo.ToString("00");
                // modified by ����� for Redmine#35459 on 2013/05/08 end
                if (!SearchedUOEOrderDetailRecordMap.ContainsKey(key))
                {
                    SearchedUOEOrderDetailRecordMap.Add(key, uoeOrderDtlWork);
                }
                else
                {
                    Debug.Assert(false, "����UOE�����f�[�^�H");
                }

                // UOE�����f�[�^�Ɣ������̎d�����׃f�[�^���Ȃ��}�b�v
                if (!ChainKeyMap.ContainsKey(key))
                {
                    ChainKeyMap.Add(key, uoeOrderDtlWork.StockSlipDtlNum);
                }

                // UOE�����f�[�^�Ɣ������̎d���f�[�^���Ȃ��}�b�v
                if (!BridgeKeyMap.ContainsKey(key))
                {
                    BridgeKeyMap.Add(key, uoeOrderDtlWork.SupplierSlipNo);
                }

                // add K2012/06/22 >>>
                // DEL K2012/12/11 START >>>>>>
                //// �e�f�[�^�̒ǉ����Ȃ����X�g���쐬
                //if (uoeOrderDtlWork.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input)
                // DEL K2012/12/11 END <<<<<<

                // DEL  by ����� for Redmine#35611 on 2013/05/08 --------->>>>>>>
                // ADD K2012/12/11 START >>>>>>
                // �R�`���i���S�ʃI�v�V�������L��������͂̏ꍇ�A�e�f�[�^�̒ǉ����Ȃ����X�g���쐬
                //if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (uoeOrderDtlWork.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input))
                //// ADD K2012/12/11 END <<<<<<
                //{
                //    if (!_noAddStockSlipList.Contains(uoeOrderDtlWork.SupplierSlipNo))
                //        _noAddStockSlipList.Add(uoeOrderDtlWork.SupplierSlipNo);
                //    if (!_noAddStockDetailList.Contains(uoeOrderDtlWork.StockSlipDtlNum))
                //        _noAddStockDetailList.Add(uoeOrderDtlWork.StockSlipDtlNum);
                //    if (!_noAddUoeOderList.Contains(key))
                //        _noAddUoeOderList.Add(key);
                //}
                //// add K2012/06/22 <<<
                // DEL  by ����� for Redmine#35611 on 2013/05/08 ---------<<<<<<<<
            }

            #endregion  // <UOE�����f�[�^/>

            // �d���f�[�^�Ǝd�����׃f�[�^
            if (seachedSlipGroupList.Count <= 1) return;

            #region <�d���f�[�^�Ǝd�����׃f�[�^/>

            for (int i = 1; i < seachedSlipGroupList.Count; i++)
            {
                if (i > 1) break;   // HACK:Search()���ʂ̍\�����āH

                // �d���f�[�^
                CustomSerializeArrayList stockSlipList = seachedSlipGroupList[i] as CustomSerializeArrayList;
                if (stockSlipList == null)    continue;
                if (stockSlipList.Count <= 1) continue;

                int innerIndex = 0;
                while (innerIndex < stockSlipList.Count)
                {
                    //StockSlipWork stockSlipWork = stockSlipList[0] as StockSlipWork;
                    StockSlipWork stockSlipWork = stockSlipList[innerIndex++] as StockSlipWork;
                    if (stockSlipWork == null) continue;

                    //if (!SearchedStockSlipRecordMap.ContainsKey(stockSlipWork.SupplierSlipNo))
                    //{
                    StockSlipRecordMap.Add(stockSlipWork.SupplierSlipNo, stockSlipWork);
                    //}

                    // �`�[���Ƃɂ܂Ƃ߂�}�b�v�ɓ`�[��ǉ�
                    //if (!SearchedStockSlipDetailRecordMap.ContainsKey(stockSlipWork.SupplierSlipNo))
                    //{
                    StockSlipDetailRecordMap.Add(stockSlipWork.SupplierSlipNo, new List<StockDetailWork>());
                    //}

                    // �d�����׃f�[�^
                    ArrayList stockDetailList = stockSlipList[innerIndex++] as ArrayList;
                    if (stockDetailList == null) continue;
                    if (stockDetailList.Count.Equals(0)) continue;

                    foreach (StockDetailWork stockDetailWork in stockDetailList)
                    {
                        //if (!SearchedStockDetailRecordMap.ContainsKey(stockDetailWork.StockSlipDtlNum))
                        //{
                        SearchedStockDetailRecordMap.Add(stockDetailWork.StockSlipDtlNum, stockDetailWork);

                        // �`�[���Ƃɂ܂Ƃ߂�}�b�v�ɖ��ׂ�ǉ�
                        StockSlipDetailRecordMap[stockSlipWork.SupplierSlipNo].Add(stockDetailWork);
                        //}
                    }   // foreach (StockDetailWork stockDetailWork in stockDetailList)
                }   // while (innerIndex < stockSlipList.Count)
            }   // for (int i = 1; i < seachedSlipGroupList.Count; i++)

            #endregion  // <�d���f�[�^�Ǝd�����׃f�[�^/>


            // ADD by ����� for Redmine#35459 on 2013/05/08 --------->>>>>>>
            # region �V�L�[���A�e�}�b�v�̍č쐬
            IDictionary<string, UOEOrderDtlWork> newSearchedUOEOrderDetailRecordMap = new Dictionary<string, UOEOrderDtlWork>();

            IDictionary<long, StockSlipWork> newStockSlipRecordMap = new Dictionary<long, StockSlipWork>();
            IDictionary<long, IList<StockDetailWork>> newStockSlipDetailRecordMap = new Dictionary<long, IList<StockDetailWork>>();
            IDictionary<long, StockDetailWork> newSearchedStockDetailRecordMap = new Dictionary<long, StockDetailWork>();

            ChainKeyMap.Clear();
            BridgeKeyMap.Clear();

            // �d�����[�v
            IIterator<ReceivedText> receivedTextIterator = receivedTelegramAgreegate.CreateIterator();
            while (receivedTextIterator.HasNext())
            {
                ReceivedText receivedText = receivedTextIterator.GetNext();
                {
                    // �d���̏o�ד`�[�ԍ�
                    string uoeSectionSlipNo = receivedText.UOESectionSlipNo.Trim().PadLeft(6, '0');

                    // �C���O�̂j�����F�d���⍇���ԍ��@�{�@�񓚓d���Ή��s
                    string uoeOrderKey = receivedText.UOESalesOrderNo.Trim().PadLeft(6, '0') + receivedText.UOESalesOrderRowNo.Trim().PadLeft(2, '0');
                    // �C���O�̂j�����F�d���⍇���ԍ��@�{�@�񓚓d���Ή��s�@�{�o�ד`�[�ԍ�
                    string newUoeOrderKey = uoeOrderKey + uoeSectionSlipNo;

                    // �V�j�������g�p���āA�V�������ꂽUOE�����f�[�^�̃}�b�v���쐬����
                    UOEOrderDtlWork uoeOrderDtlWorkTemp;
                    if (SearchedUOEOrderDetailRecordMap.TryGetValue(uoeOrderKey, out uoeOrderDtlWorkTemp))
                    {
                        UOEOrderDtlWork uoeOrderDtlWork = this.UOEOrderDtlWorkCopy(uoeOrderDtlWorkTemp);
                        newSearchedUOEOrderDetailRecordMap.Add(newUoeOrderKey, uoeOrderDtlWork);

                        // UOE�����f�[�^�̎d���`�[�ԍ�
                        int supplierSlipNo = uoeOrderDtlWork.SupplierSlipNo;
                        // UOE�����f�[�^�̎d�����גʔ�
                        long stockSlipDtlNum = uoeOrderDtlWork.StockSlipDtlNum;

                        // �V�d���`�[�ԍ��FUOE�����f�[�^�̎d���`�[�ԍ��@�{�@�d���̏o�ד`�[�ԍ�
                        long newStockSlipDtlNum = long.Parse(stockSlipDtlNum.ToString() + uoeSectionSlipNo);
                        // �V�d�����גʔԁFUOE�����f�[�^�̎d�����גʔԁ@�{�@�d���̏o�ד`�[�ԍ�
                        long newSupplierSlipNo = long.Parse(supplierSlipNo.ToString() + uoeSectionSlipNo);

                        // UOE�����f�[�^�Ɣ������̎d�����׃f�[�^���Ȃ��}�b�v
                        if (!ChainKeyMap.ContainsKey(newUoeOrderKey))
                        {
                            ChainKeyMap.Add(newUoeOrderKey, newStockSlipDtlNum);
                        }

                        // UOE�����f�[�^�Ɣ������̎d���f�[�^���Ȃ��}�b�v
                        if (!BridgeKeyMap.ContainsKey(newUoeOrderKey))
                        {
                            BridgeKeyMap.Add(newUoeOrderKey, newSupplierSlipNo);
                        }

                        // �V�j�������g�p���āA�V�d���f�[�^�i�d�b�������܂ށj�̃}�b�v���쐬����
                        if (!newStockSlipRecordMap.ContainsKey(newSupplierSlipNo))
                        {
                            StockSlipWork stockSlipWorkTemp;
                            if (StockSlipRecordMap.TryGetValue(supplierSlipNo, out stockSlipWorkTemp))
                            {
                                StockSlipWork stockSlipWork = this.StockSlipWorkCopy(stockSlipWorkTemp);
                                newStockSlipRecordMap.Add(newSupplierSlipNo, stockSlipWork);
                            }
                            }

                        // �V�j�������g�p���āA�������ꂽ�d�����׃f�[�^�̃}�b�v���쐬����
                        if (!newSearchedStockDetailRecordMap.ContainsKey(newStockSlipDtlNum))
                        {
                            StockDetailWork stockDetailWorkTemp;
                            if (SearchedStockDetailRecordMap.TryGetValue(stockSlipDtlNum, out stockDetailWorkTemp))
                            {
                                StockDetailWork stockDetailWork = this.StockDetailWorkCopy(stockDetailWorkTemp);
                                newSearchedStockDetailRecordMap.Add(newStockSlipDtlNum, stockDetailWork);
                            }
                        }

                        // �V�j�������g�p���āA�`�[�Ɩ��׃��X�g�i�d�b�������܂ށj�̃}�b�v���쐬����
                        if (!newStockSlipDetailRecordMap.ContainsKey(newSupplierSlipNo))
                        {
                            if (StockSlipDetailRecordMap.ContainsKey(supplierSlipNo))
                            {
                                List<StockDetailWork> stockDetailWorkList = new List<StockDetailWork>();
                                stockDetailWorkList.AddRange(StockSlipDetailRecordMap[supplierSlipNo]);
                                newStockSlipDetailRecordMap.Add(newSupplierSlipNo, stockDetailWorkList);
                            }
                        }

                        // ADD by ����� for Redmine#35611 on 2013/05/08 --------->>>>>>>
                        if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (uoeOrderDtlWork.SystemDivCd == (int)EnumUoeConst.ctSystemDivCd.ct_Input))
                        {
                            if (!_noAddStockSlipList.Contains(newSupplierSlipNo))
                                _noAddStockSlipList.Add(newSupplierSlipNo);
                            if (!_noAddStockDetailList.Contains(newStockSlipDtlNum))
                                _noAddStockDetailList.Add(newStockSlipDtlNum);
                            if (!_noAddUoeOderList.Contains(newUoeOrderKey))
                                _noAddUoeOderList.Add(newUoeOrderKey);
                        }
                        // ADD by ����� for Redmine#35611 on 2013/05/08 ---------<<<<<<<<

                    }
                }
            }

            // �������ꂽUOE�����f�[�^�̃}�b�v���č쐬
            SearchedUOEOrderDetailRecordMap.Clear();
            foreach (string uoeOrderKey in newSearchedUOEOrderDetailRecordMap.Keys)
            {
                SearchedUOEOrderDetailRecordMap.Add(uoeOrderKey, newSearchedUOEOrderDetailRecordMap[uoeOrderKey]);
            }

            // �d���f�[�^�i�d�b�������܂ށj�̃}�b�v���č쐬
            StockSlipRecordMap.Clear();
            foreach (long supplierSlipNo in newStockSlipRecordMap.Keys)
            {
                StockSlipRecordMap.Add(supplierSlipNo, newStockSlipRecordMap[supplierSlipNo]);
            }

            // �������ꂽ�d�����׃f�[�^�̃}�b�v���č쐬
            SearchedStockDetailRecordMap.Clear();
            foreach (long stockSlipDtlNum in newSearchedStockDetailRecordMap.Keys)
            {
                SearchedStockDetailRecordMap.Add(stockSlipDtlNum, newSearchedStockDetailRecordMap[stockSlipDtlNum]);
            }

            // �`�[�Ɩ��׃��X�g�i�d�b�������܂ށj�̃}�b�v���č쐬
            StockSlipDetailRecordMap.Clear();
            foreach (long supplierSlipNo in newStockSlipDetailRecordMap.Keys)
            {
                StockSlipDetailRecordMap.Add(supplierSlipNo, newStockSlipDetailRecordMap[supplierSlipNo]);
            }
            # endregion
            // ADD by ����� for Redmine#35459 on 2013/05/08 ---------<<<<<<<
        }

        // ADD by ����� for Redmine#35459 on 2013/05/08 --------->>>>>>>
        /// <summary>
        /// UOE�����f�[�^���R�s�[����
        /// </summary>
        /// <param name="UOEOrderDtlWorkSrc">��UOE�����f�[�^</param>
        /// <returns>�VUOE�����f�[�^</returns>
        /// <remarks>
        /// <br>Note       : UOE�����f�[�^���R�s�[����</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08</br>
        /// </remarks>
        private UOEOrderDtlWork UOEOrderDtlWorkCopy(UOEOrderDtlWork UOEOrderDtlWorkSrc)
        {
            UOEOrderDtlWork UOEOrderDtlWorkRs = new UOEOrderDtlWork();

            UOEOrderDtlWorkRs.CreateDateTime = UOEOrderDtlWorkSrc.CreateDateTime;
            UOEOrderDtlWorkRs.UpdateDateTime = UOEOrderDtlWorkSrc.UpdateDateTime;
            UOEOrderDtlWorkRs.EnterpriseCode = UOEOrderDtlWorkSrc.EnterpriseCode;
            UOEOrderDtlWorkRs.FileHeaderGuid = UOEOrderDtlWorkSrc.FileHeaderGuid;
            UOEOrderDtlWorkRs.UpdEmployeeCode = UOEOrderDtlWorkSrc.UpdEmployeeCode;
            UOEOrderDtlWorkRs.UpdAssemblyId1 = UOEOrderDtlWorkSrc.UpdAssemblyId1;
            UOEOrderDtlWorkRs.UpdAssemblyId2 = UOEOrderDtlWorkSrc.UpdAssemblyId2;
            UOEOrderDtlWorkRs.LogicalDeleteCode = UOEOrderDtlWorkSrc.LogicalDeleteCode;
            UOEOrderDtlWorkRs.SystemDivCd = UOEOrderDtlWorkSrc.SystemDivCd;
            UOEOrderDtlWorkRs.UOESalesOrderNo = UOEOrderDtlWorkSrc.UOESalesOrderNo;
            UOEOrderDtlWorkRs.UOESalesOrderRowNo = UOEOrderDtlWorkSrc.UOESalesOrderRowNo;
            UOEOrderDtlWorkRs.SendTerminalNo = UOEOrderDtlWorkSrc.SendTerminalNo;
            UOEOrderDtlWorkRs.UOESupplierCd = UOEOrderDtlWorkSrc.UOESupplierCd;
            UOEOrderDtlWorkRs.UOESupplierName = UOEOrderDtlWorkSrc.UOESupplierName;
            UOEOrderDtlWorkRs.CommAssemblyId = UOEOrderDtlWorkSrc.CommAssemblyId;
            UOEOrderDtlWorkRs.OnlineNo = UOEOrderDtlWorkSrc.OnlineNo;
            UOEOrderDtlWorkRs.OnlineRowNo = UOEOrderDtlWorkSrc.OnlineRowNo;
            UOEOrderDtlWorkRs.SalesDate = UOEOrderDtlWorkSrc.SalesDate;
            UOEOrderDtlWorkRs.InputDay = UOEOrderDtlWorkSrc.InputDay;
            UOEOrderDtlWorkRs.DataUpdateDateTime = UOEOrderDtlWorkSrc.DataUpdateDateTime;
            UOEOrderDtlWorkRs.UOEKind = UOEOrderDtlWorkSrc.UOEKind;
            UOEOrderDtlWorkRs.SalesSlipNum = UOEOrderDtlWorkSrc.SalesSlipNum;
            UOEOrderDtlWorkRs.AcptAnOdrStatus = UOEOrderDtlWorkSrc.AcptAnOdrStatus;
            UOEOrderDtlWorkRs.SalesSlipDtlNum = UOEOrderDtlWorkSrc.SalesSlipDtlNum;
            UOEOrderDtlWorkRs.SectionCode = UOEOrderDtlWorkSrc.SectionCode;
            UOEOrderDtlWorkRs.SubSectionCode = UOEOrderDtlWorkSrc.SubSectionCode;
            UOEOrderDtlWorkRs.CustomerCode = UOEOrderDtlWorkSrc.CustomerCode;
            UOEOrderDtlWorkRs.CustomerSnm = UOEOrderDtlWorkSrc.CustomerSnm;
            UOEOrderDtlWorkRs.CashRegisterNo = UOEOrderDtlWorkSrc.CashRegisterNo;
            UOEOrderDtlWorkRs.CommonSeqNo = UOEOrderDtlWorkSrc.CommonSeqNo;
            UOEOrderDtlWorkRs.SupplierFormal = UOEOrderDtlWorkSrc.SupplierFormal;
            UOEOrderDtlWorkRs.SupplierSlipNo = UOEOrderDtlWorkSrc.SupplierSlipNo;
            UOEOrderDtlWorkRs.StockSlipDtlNum = UOEOrderDtlWorkSrc.StockSlipDtlNum;
            UOEOrderDtlWorkRs.BoCode = UOEOrderDtlWorkSrc.BoCode;
            UOEOrderDtlWorkRs.UOEDeliGoodsDiv = UOEOrderDtlWorkSrc.UOEDeliGoodsDiv;
            UOEOrderDtlWorkRs.DeliveredGoodsDivNm = UOEOrderDtlWorkSrc.DeliveredGoodsDivNm;
            UOEOrderDtlWorkRs.FollowDeliGoodsDiv = UOEOrderDtlWorkSrc.FollowDeliGoodsDiv;
            UOEOrderDtlWorkRs.FollowDeliGoodsDivNm = UOEOrderDtlWorkSrc.FollowDeliGoodsDivNm;
            UOEOrderDtlWorkRs.UOEResvdSection = UOEOrderDtlWorkSrc.UOEResvdSection;
            UOEOrderDtlWorkRs.UOEResvdSectionNm = UOEOrderDtlWorkSrc.UOEResvdSectionNm;
            UOEOrderDtlWorkRs.EmployeeCode = UOEOrderDtlWorkSrc.EmployeeCode;
            UOEOrderDtlWorkRs.EmployeeName = UOEOrderDtlWorkSrc.EmployeeName;
            UOEOrderDtlWorkRs.GoodsMakerCd = UOEOrderDtlWorkSrc.GoodsMakerCd;
            UOEOrderDtlWorkRs.MakerName = UOEOrderDtlWorkSrc.MakerName;
            UOEOrderDtlWorkRs.GoodsNo = UOEOrderDtlWorkSrc.GoodsNo;
            UOEOrderDtlWorkRs.GoodsNoNoneHyphen = UOEOrderDtlWorkSrc.GoodsNoNoneHyphen;
            UOEOrderDtlWorkRs.GoodsName = UOEOrderDtlWorkSrc.GoodsName;
            UOEOrderDtlWorkRs.WarehouseCode = UOEOrderDtlWorkSrc.WarehouseCode;
            UOEOrderDtlWorkRs.WarehouseName = UOEOrderDtlWorkSrc.WarehouseName;
            UOEOrderDtlWorkRs.WarehouseShelfNo = UOEOrderDtlWorkSrc.WarehouseShelfNo;
            UOEOrderDtlWorkRs.AcceptAnOrderCnt = UOEOrderDtlWorkSrc.AcceptAnOrderCnt;
            UOEOrderDtlWorkRs.ListPrice = UOEOrderDtlWorkSrc.ListPrice;
            UOEOrderDtlWorkRs.SalesUnitCost = UOEOrderDtlWorkSrc.SalesUnitCost;
            UOEOrderDtlWorkRs.SupplierCd = UOEOrderDtlWorkSrc.SupplierCd;
            UOEOrderDtlWorkRs.SupplierSnm = UOEOrderDtlWorkSrc.SupplierSnm;
            UOEOrderDtlWorkRs.UoeRemark1 = UOEOrderDtlWorkSrc.UoeRemark1;
            UOEOrderDtlWorkRs.UoeRemark2 = UOEOrderDtlWorkSrc.UoeRemark2;
            UOEOrderDtlWorkRs.ReceiveDate = UOEOrderDtlWorkSrc.ReceiveDate;
            UOEOrderDtlWorkRs.ReceiveTime = UOEOrderDtlWorkSrc.ReceiveTime;
            UOEOrderDtlWorkRs.AnswerMakerCd = UOEOrderDtlWorkSrc.AnswerMakerCd;
            UOEOrderDtlWorkRs.AnswerPartsNo = UOEOrderDtlWorkSrc.AnswerPartsNo;
            UOEOrderDtlWorkRs.AnswerPartsName = UOEOrderDtlWorkSrc.AnswerPartsName;
            UOEOrderDtlWorkRs.SubstPartsNo = UOEOrderDtlWorkSrc.SubstPartsNo;
            UOEOrderDtlWorkRs.UOESectOutGoodsCnt = UOEOrderDtlWorkSrc.UOESectOutGoodsCnt;
            UOEOrderDtlWorkRs.BOShipmentCnt1 = UOEOrderDtlWorkSrc.BOShipmentCnt1;
            UOEOrderDtlWorkRs.BOShipmentCnt2 = UOEOrderDtlWorkSrc.BOShipmentCnt2;
            UOEOrderDtlWorkRs.BOShipmentCnt3 = UOEOrderDtlWorkSrc.BOShipmentCnt3;
            UOEOrderDtlWorkRs.MakerFollowCnt = UOEOrderDtlWorkSrc.MakerFollowCnt;
            UOEOrderDtlWorkRs.NonShipmentCnt = UOEOrderDtlWorkSrc.NonShipmentCnt;
            UOEOrderDtlWorkRs.UOESectStockCnt = UOEOrderDtlWorkSrc.UOESectStockCnt;
            UOEOrderDtlWorkRs.BOStockCount1 = UOEOrderDtlWorkSrc.BOStockCount1;
            UOEOrderDtlWorkRs.BOStockCount2 = UOEOrderDtlWorkSrc.BOStockCount2;
            UOEOrderDtlWorkRs.BOStockCount3 = UOEOrderDtlWorkSrc.BOStockCount3;
            UOEOrderDtlWorkRs.UOESectionSlipNo = UOEOrderDtlWorkSrc.UOESectionSlipNo;
            UOEOrderDtlWorkRs.BOSlipNo1 = UOEOrderDtlWorkSrc.BOSlipNo1;
            UOEOrderDtlWorkRs.BOSlipNo2 = UOEOrderDtlWorkSrc.BOSlipNo2;
            UOEOrderDtlWorkRs.BOSlipNo3 = UOEOrderDtlWorkSrc.BOSlipNo3;
            UOEOrderDtlWorkRs.EOAlwcCount = UOEOrderDtlWorkSrc.EOAlwcCount;
            UOEOrderDtlWorkRs.BOManagementNo = UOEOrderDtlWorkSrc.BOManagementNo;
            UOEOrderDtlWorkRs.AnswerListPrice = UOEOrderDtlWorkSrc.AnswerListPrice;
            UOEOrderDtlWorkRs.AnswerSalesUnitCost = UOEOrderDtlWorkSrc.AnswerSalesUnitCost;
            UOEOrderDtlWorkRs.UOESubstMark = UOEOrderDtlWorkSrc.UOESubstMark;
            UOEOrderDtlWorkRs.UOEStockMark = UOEOrderDtlWorkSrc.UOEStockMark;
            UOEOrderDtlWorkRs.PartsLayerCd = UOEOrderDtlWorkSrc.PartsLayerCd;
            UOEOrderDtlWorkRs.MazdaUOEShipSectCd1 = UOEOrderDtlWorkSrc.MazdaUOEShipSectCd1;
            UOEOrderDtlWorkRs.MazdaUOEShipSectCd2 = UOEOrderDtlWorkSrc.MazdaUOEShipSectCd2;
            UOEOrderDtlWorkRs.MazdaUOEShipSectCd3 = UOEOrderDtlWorkSrc.MazdaUOEShipSectCd3;
            UOEOrderDtlWorkRs.MazdaUOESectCd1 = UOEOrderDtlWorkSrc.MazdaUOESectCd1;
            UOEOrderDtlWorkRs.MazdaUOESectCd2 = UOEOrderDtlWorkSrc.MazdaUOESectCd2;
            UOEOrderDtlWorkRs.MazdaUOESectCd3 = UOEOrderDtlWorkSrc.MazdaUOESectCd3;
            UOEOrderDtlWorkRs.MazdaUOESectCd4 = UOEOrderDtlWorkSrc.MazdaUOESectCd4;
            UOEOrderDtlWorkRs.MazdaUOESectCd5 = UOEOrderDtlWorkSrc.MazdaUOESectCd5;
            UOEOrderDtlWorkRs.MazdaUOESectCd6 = UOEOrderDtlWorkSrc.MazdaUOESectCd6;
            UOEOrderDtlWorkRs.MazdaUOESectCd7 = UOEOrderDtlWorkSrc.MazdaUOESectCd7;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt1 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt1;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt2 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt2;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt3 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt3;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt4 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt4;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt5 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt5;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt6 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt6;
            UOEOrderDtlWorkRs.MazdaUOEStockCnt7 = UOEOrderDtlWorkSrc.MazdaUOEStockCnt7;
            UOEOrderDtlWorkRs.UOEDistributionCd = UOEOrderDtlWorkSrc.UOEDistributionCd;
            UOEOrderDtlWorkRs.UOEOtherCd = UOEOrderDtlWorkSrc.UOEOtherCd;
            UOEOrderDtlWorkRs.UOEHMCd = UOEOrderDtlWorkSrc.UOEHMCd;
            UOEOrderDtlWorkRs.BOCount = UOEOrderDtlWorkSrc.BOCount;
            UOEOrderDtlWorkRs.UOEMarkCode = UOEOrderDtlWorkSrc.UOEMarkCode;
            UOEOrderDtlWorkRs.SourceShipment = UOEOrderDtlWorkSrc.SourceShipment;
            UOEOrderDtlWorkRs.ItemCode = UOEOrderDtlWorkSrc.ItemCode;
            UOEOrderDtlWorkRs.UOECheckCode = UOEOrderDtlWorkSrc.UOECheckCode;
            UOEOrderDtlWorkRs.HeadErrorMassage = UOEOrderDtlWorkSrc.HeadErrorMassage;
            UOEOrderDtlWorkRs.LineErrorMassage = UOEOrderDtlWorkSrc.LineErrorMassage;
            UOEOrderDtlWorkRs.DataSendCode = UOEOrderDtlWorkSrc.DataSendCode;
            UOEOrderDtlWorkRs.DataRecoverDiv = UOEOrderDtlWorkSrc.DataRecoverDiv;
            UOEOrderDtlWorkRs.EnterUpdDivSec = UOEOrderDtlWorkSrc.EnterUpdDivSec;
            UOEOrderDtlWorkRs.EnterUpdDivBO1 = UOEOrderDtlWorkSrc.EnterUpdDivBO1;
            UOEOrderDtlWorkRs.EnterUpdDivBO2 = UOEOrderDtlWorkSrc.EnterUpdDivBO2;
            UOEOrderDtlWorkRs.EnterUpdDivBO3 = UOEOrderDtlWorkSrc.EnterUpdDivBO3;
            UOEOrderDtlWorkRs.EnterUpdDivMaker = UOEOrderDtlWorkSrc.EnterUpdDivMaker;
            UOEOrderDtlWorkRs.EnterUpdDivEO = UOEOrderDtlWorkSrc.EnterUpdDivEO;

            UOEOrderDtlWorkRs.DtlRelationGuid = UOEOrderDtlWorkSrc.DtlRelationGuid;

            return UOEOrderDtlWorkRs;
        }

        /// <summary>
        /// �d���f�[�^���R�s�[����
        /// </summary>
        /// <param name="StockSlipWorkSrc">���d���f�[�^</param>
        /// <returns>�V�d���f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �d���f�[�^���R�s�[����</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08</br>
        /// </remarks>
        private StockSlipWork StockSlipWorkCopy(StockSlipWork StockSlipWorkSrc)
        {
            StockSlipWork StockSlipWorkRs = new StockSlipWork();

            StockSlipWorkRs.CreateDateTime = StockSlipWorkSrc.CreateDateTime;
            StockSlipWorkRs.UpdateDateTime = StockSlipWorkSrc.UpdateDateTime;
            StockSlipWorkRs.EnterpriseCode = StockSlipWorkSrc.EnterpriseCode;
            StockSlipWorkRs.FileHeaderGuid = StockSlipWorkSrc.FileHeaderGuid;
            StockSlipWorkRs.UpdEmployeeCode = StockSlipWorkSrc.UpdEmployeeCode;
            StockSlipWorkRs.UpdAssemblyId1 = StockSlipWorkSrc.UpdAssemblyId1;
            StockSlipWorkRs.UpdAssemblyId2 = StockSlipWorkSrc.UpdAssemblyId2;
            StockSlipWorkRs.LogicalDeleteCode = StockSlipWorkSrc.LogicalDeleteCode;
            StockSlipWorkRs.SupplierFormal = StockSlipWorkSrc.SupplierFormal;
            StockSlipWorkRs.SupplierSlipNo = StockSlipWorkSrc.SupplierSlipNo;
            StockSlipWorkRs.SectionCode = StockSlipWorkSrc.SectionCode;
            StockSlipWorkRs.SubSectionCode = StockSlipWorkSrc.SubSectionCode;
            StockSlipWorkRs.DebitNoteDiv = StockSlipWorkSrc.DebitNoteDiv;
            StockSlipWorkRs.DebitNLnkSuppSlipNo = StockSlipWorkSrc.DebitNLnkSuppSlipNo;
            StockSlipWorkRs.SupplierSlipCd = StockSlipWorkSrc.SupplierSlipCd;
            StockSlipWorkRs.StockGoodsCd = StockSlipWorkSrc.StockGoodsCd;
            StockSlipWorkRs.AccPayDivCd = StockSlipWorkSrc.AccPayDivCd;
            StockSlipWorkRs.StockSectionCd = StockSlipWorkSrc.StockSectionCd;
            StockSlipWorkRs.StockAddUpSectionCd = StockSlipWorkSrc.StockAddUpSectionCd;
            StockSlipWorkRs.StockSlipUpdateCd = StockSlipWorkSrc.StockSlipUpdateCd;
            StockSlipWorkRs.InputDay = StockSlipWorkSrc.InputDay;
            StockSlipWorkRs.ArrivalGoodsDay = StockSlipWorkSrc.ArrivalGoodsDay;
            StockSlipWorkRs.StockDate = StockSlipWorkSrc.StockDate;
            StockSlipWorkRs.StockAddUpADate = StockSlipWorkSrc.StockAddUpADate;
            StockSlipWorkRs.DelayPaymentDiv = StockSlipWorkSrc.DelayPaymentDiv;
            StockSlipWorkRs.PayeeCode = StockSlipWorkSrc.PayeeCode;
            StockSlipWorkRs.PayeeSnm = StockSlipWorkSrc.PayeeSnm;
            StockSlipWorkRs.SupplierCd = StockSlipWorkSrc.SupplierCd;
            StockSlipWorkRs.SupplierNm1 = StockSlipWorkSrc.SupplierNm1;
            StockSlipWorkRs.SupplierNm2 = StockSlipWorkSrc.SupplierNm2;
            StockSlipWorkRs.SupplierSnm = StockSlipWorkSrc.SupplierSnm;
            StockSlipWorkRs.BusinessTypeCode = StockSlipWorkSrc.BusinessTypeCode;
            StockSlipWorkRs.BusinessTypeName = StockSlipWorkSrc.BusinessTypeName;
            StockSlipWorkRs.SalesAreaCode = StockSlipWorkSrc.SalesAreaCode;
            StockSlipWorkRs.SalesAreaName = StockSlipWorkSrc.SalesAreaName;
            StockSlipWorkRs.StockInputCode = StockSlipWorkSrc.StockInputCode;
            StockSlipWorkRs.StockInputName = StockSlipWorkSrc.StockInputName;
            StockSlipWorkRs.StockAgentCode = StockSlipWorkSrc.StockAgentCode;
            StockSlipWorkRs.StockAgentName = StockSlipWorkSrc.StockAgentName;
            StockSlipWorkRs.SuppTtlAmntDspWayCd = StockSlipWorkSrc.SuppTtlAmntDspWayCd;
            StockSlipWorkRs.TtlAmntDispRateApy = StockSlipWorkSrc.TtlAmntDispRateApy;
            StockSlipWorkRs.StockTotalPrice = StockSlipWorkSrc.StockTotalPrice;
            StockSlipWorkRs.StockSubttlPrice = StockSlipWorkSrc.StockSubttlPrice;
            StockSlipWorkRs.StockTtlPricTaxInc = StockSlipWorkSrc.StockTtlPricTaxInc;
            StockSlipWorkRs.StockTtlPricTaxExc = StockSlipWorkSrc.StockTtlPricTaxExc;
            StockSlipWorkRs.StockNetPrice = StockSlipWorkSrc.StockNetPrice;
            StockSlipWorkRs.StockPriceConsTax = StockSlipWorkSrc.StockPriceConsTax;
            StockSlipWorkRs.TtlItdedStcOutTax = StockSlipWorkSrc.TtlItdedStcOutTax;
            StockSlipWorkRs.TtlItdedStcInTax = StockSlipWorkSrc.TtlItdedStcInTax;
            StockSlipWorkRs.TtlItdedStcTaxFree = StockSlipWorkSrc.TtlItdedStcTaxFree;
            StockSlipWorkRs.StockOutTax = StockSlipWorkSrc.StockOutTax;
            StockSlipWorkRs.StckPrcConsTaxInclu = StockSlipWorkSrc.StckPrcConsTaxInclu;
            StockSlipWorkRs.StckDisTtlTaxExc = StockSlipWorkSrc.StckDisTtlTaxExc;
            StockSlipWorkRs.ItdedStockDisOutTax = StockSlipWorkSrc.ItdedStockDisOutTax;
            StockSlipWorkRs.ItdedStockDisInTax = StockSlipWorkSrc.ItdedStockDisInTax;
            StockSlipWorkRs.ItdedStockDisTaxFre = StockSlipWorkSrc.ItdedStockDisTaxFre;
            StockSlipWorkRs.StockDisOutTax = StockSlipWorkSrc.StockDisOutTax;
            StockSlipWorkRs.StckDisTtlTaxInclu = StockSlipWorkSrc.StckDisTtlTaxInclu;
            StockSlipWorkRs.TaxAdjust = StockSlipWorkSrc.TaxAdjust;
            StockSlipWorkRs.BalanceAdjust = StockSlipWorkSrc.BalanceAdjust;
            StockSlipWorkRs.SuppCTaxLayCd = StockSlipWorkSrc.SuppCTaxLayCd;
            StockSlipWorkRs.SupplierConsTaxRate = StockSlipWorkSrc.SupplierConsTaxRate;
            StockSlipWorkRs.AccPayConsTax = StockSlipWorkSrc.AccPayConsTax;
            StockSlipWorkRs.StockFractionProcCd = StockSlipWorkSrc.StockFractionProcCd;
            StockSlipWorkRs.AutoPayment = StockSlipWorkSrc.AutoPayment;
            StockSlipWorkRs.AutoPaySlipNum = StockSlipWorkSrc.AutoPaySlipNum;
            StockSlipWorkRs.RetGoodsReasonDiv = StockSlipWorkSrc.RetGoodsReasonDiv;
            StockSlipWorkRs.RetGoodsReason = StockSlipWorkSrc.RetGoodsReason;
            StockSlipWorkRs.PartySaleSlipNum = StockSlipWorkSrc.PartySaleSlipNum;
            StockSlipWorkRs.SupplierSlipNote1 = StockSlipWorkSrc.SupplierSlipNote1;
            StockSlipWorkRs.SupplierSlipNote2 = StockSlipWorkSrc.SupplierSlipNote2;
            StockSlipWorkRs.DetailRowCount = StockSlipWorkSrc.DetailRowCount;
            StockSlipWorkRs.EdiSendDate = StockSlipWorkSrc.EdiSendDate;
            StockSlipWorkRs.EdiTakeInDate = StockSlipWorkSrc.EdiTakeInDate;
            StockSlipWorkRs.UoeRemark1 = StockSlipWorkSrc.UoeRemark1;
            StockSlipWorkRs.UoeRemark2 = StockSlipWorkSrc.UoeRemark2;
            StockSlipWorkRs.SlipPrintDivCd = StockSlipWorkSrc.SlipPrintDivCd;
            StockSlipWorkRs.SlipPrintFinishCd = StockSlipWorkSrc.SlipPrintFinishCd;
            StockSlipWorkRs.StockSlipPrintDate = StockSlipWorkSrc.StockSlipPrintDate;
            StockSlipWorkRs.SlipPrtSetPaperId = StockSlipWorkSrc.SlipPrtSetPaperId;
            StockSlipWorkRs.SlipAddressDiv = StockSlipWorkSrc.SlipAddressDiv;
            StockSlipWorkRs.AddresseeCode = StockSlipWorkSrc.AddresseeCode;
            StockSlipWorkRs.AddresseeName = StockSlipWorkSrc.AddresseeName;
            StockSlipWorkRs.AddresseeName2 = StockSlipWorkSrc.AddresseeName2;
            StockSlipWorkRs.AddresseePostNo = StockSlipWorkSrc.AddresseePostNo;
            StockSlipWorkRs.AddresseeAddr1 = StockSlipWorkSrc.AddresseeAddr1;
            StockSlipWorkRs.AddresseeAddr3 = StockSlipWorkSrc.AddresseeAddr3;
            StockSlipWorkRs.AddresseeAddr4 = StockSlipWorkSrc.AddresseeAddr4;
            StockSlipWorkRs.AddresseeTelNo = StockSlipWorkSrc.AddresseeTelNo;
            StockSlipWorkRs.AddresseeFaxNo = StockSlipWorkSrc.AddresseeFaxNo;
            StockSlipWorkRs.DirectSendingCd = StockSlipWorkSrc.DirectSendingCd;

            return StockSlipWorkRs;
        }

        /// <summary>
        /// �d�����׃f�[�^���R�s�[����
        /// </summary>
        /// <param name="StockDetailWorkSrc">���d�����׃f�[�^</param>
        /// <returns>�V�d�����׃f�[�^</returns>
        /// <remarks>
        /// <br>Note       : �d�����׃f�[�^���R�s�[����</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08</br>
        /// </remarks>
        private StockDetailWork StockDetailWorkCopy(StockDetailWork StockDetailWorkSrc)
        {
            StockDetailWork StockDetailWorkRs = new StockDetailWork();

            StockDetailWorkRs.CreateDateTime = StockDetailWorkSrc.CreateDateTime;
            StockDetailWorkRs.UpdateDateTime = StockDetailWorkSrc.UpdateDateTime;
            StockDetailWorkRs.EnterpriseCode = StockDetailWorkSrc.EnterpriseCode;
            StockDetailWorkRs.FileHeaderGuid = StockDetailWorkSrc.FileHeaderGuid;
            StockDetailWorkRs.UpdEmployeeCode = StockDetailWorkSrc.UpdEmployeeCode;
            StockDetailWorkRs.UpdAssemblyId1 = StockDetailWorkSrc.UpdAssemblyId1;
            StockDetailWorkRs.UpdAssemblyId2 = StockDetailWorkSrc.UpdAssemblyId2;
            StockDetailWorkRs.LogicalDeleteCode = StockDetailWorkSrc.LogicalDeleteCode;
            StockDetailWorkRs.AcceptAnOrderNo = StockDetailWorkSrc.AcceptAnOrderNo;
            StockDetailWorkRs.SupplierFormal = StockDetailWorkSrc.SupplierFormal;
            StockDetailWorkRs.SupplierSlipNo = StockDetailWorkSrc.SupplierSlipNo;
            StockDetailWorkRs.StockRowNo = StockDetailWorkSrc.StockRowNo;
            StockDetailWorkRs.SectionCode = StockDetailWorkSrc.SectionCode;
            StockDetailWorkRs.SubSectionCode = StockDetailWorkSrc.SubSectionCode;
            StockDetailWorkRs.CommonSeqNo = StockDetailWorkSrc.CommonSeqNo;
            StockDetailWorkRs.StockSlipDtlNum = StockDetailWorkSrc.StockSlipDtlNum;
            StockDetailWorkRs.SupplierFormalSrc = StockDetailWorkSrc.SupplierFormalSrc;
            StockDetailWorkRs.StockSlipDtlNumSrc = StockDetailWorkSrc.StockSlipDtlNumSrc;
            StockDetailWorkRs.AcptAnOdrStatusSync = StockDetailWorkSrc.AcptAnOdrStatusSync;
            StockDetailWorkRs.SalesSlipDtlNumSync = StockDetailWorkSrc.SalesSlipDtlNumSync;
            StockDetailWorkRs.StockSlipCdDtl = StockDetailWorkSrc.StockSlipCdDtl;
            StockDetailWorkRs.StockInputCode = StockDetailWorkSrc.StockInputCode;
            StockDetailWorkRs.StockInputName = StockDetailWorkSrc.StockInputName;
            StockDetailWorkRs.StockAgentCode = StockDetailWorkSrc.StockAgentCode;
            StockDetailWorkRs.StockAgentName = StockDetailWorkSrc.StockAgentName;
            StockDetailWorkRs.GoodsKindCode = StockDetailWorkSrc.GoodsKindCode;
            StockDetailWorkRs.GoodsMakerCd = StockDetailWorkSrc.GoodsMakerCd;
            StockDetailWorkRs.MakerName = StockDetailWorkSrc.MakerName;
            StockDetailWorkRs.MakerKanaName = StockDetailWorkSrc.MakerKanaName;
            StockDetailWorkRs.CmpltMakerKanaName = StockDetailWorkSrc.CmpltMakerKanaName;
            StockDetailWorkRs.GoodsNo = StockDetailWorkSrc.GoodsNo;
            StockDetailWorkRs.GoodsName = StockDetailWorkSrc.GoodsName;
            StockDetailWorkRs.GoodsNameKana = StockDetailWorkSrc.GoodsNameKana;
            StockDetailWorkRs.GoodsLGroup = StockDetailWorkSrc.GoodsLGroup;
            StockDetailWorkRs.GoodsLGroupName = StockDetailWorkSrc.GoodsLGroupName;
            StockDetailWorkRs.GoodsMGroup = StockDetailWorkSrc.GoodsMGroup;
            StockDetailWorkRs.GoodsMGroupName = StockDetailWorkSrc.GoodsMGroupName;
            StockDetailWorkRs.BLGroupCode = StockDetailWorkSrc.BLGroupCode;
            StockDetailWorkRs.BLGroupName = StockDetailWorkSrc.BLGroupName;
            StockDetailWorkRs.BLGoodsCode = StockDetailWorkSrc.BLGoodsCode;
            StockDetailWorkRs.BLGoodsFullName = StockDetailWorkSrc.BLGoodsFullName;
            StockDetailWorkRs.EnterpriseGanreCode = StockDetailWorkSrc.EnterpriseGanreCode;
            StockDetailWorkRs.EnterpriseGanreName = StockDetailWorkSrc.EnterpriseGanreName;
            StockDetailWorkRs.WarehouseCode = StockDetailWorkSrc.WarehouseCode;
            StockDetailWorkRs.WarehouseName = StockDetailWorkSrc.WarehouseName;
            StockDetailWorkRs.WarehouseShelfNo = StockDetailWorkSrc.WarehouseShelfNo;
            StockDetailWorkRs.StockOrderDivCd = StockDetailWorkSrc.StockOrderDivCd;
            StockDetailWorkRs.OpenPriceDiv = StockDetailWorkSrc.OpenPriceDiv;
            StockDetailWorkRs.GoodsRateRank = StockDetailWorkSrc.GoodsRateRank;
            StockDetailWorkRs.CustRateGrpCode = StockDetailWorkSrc.CustRateGrpCode;
            StockDetailWorkRs.SuppRateGrpCode = StockDetailWorkSrc.SuppRateGrpCode;
            StockDetailWorkRs.ListPriceTaxExcFl = StockDetailWorkSrc.ListPriceTaxExcFl;
            StockDetailWorkRs.ListPriceTaxIncFl = StockDetailWorkSrc.ListPriceTaxIncFl;
            StockDetailWorkRs.StockRate = StockDetailWorkSrc.StockRate;
            StockDetailWorkRs.RateSectStckUnPrc = StockDetailWorkSrc.RateSectStckUnPrc;
            StockDetailWorkRs.RateDivStckUnPrc = StockDetailWorkSrc.RateDivStckUnPrc;
            StockDetailWorkRs.UnPrcCalcCdStckUnPrc = StockDetailWorkSrc.UnPrcCalcCdStckUnPrc;
            StockDetailWorkRs.PriceCdStckUnPrc = StockDetailWorkSrc.PriceCdStckUnPrc;
            StockDetailWorkRs.StdUnPrcStckUnPrc = StockDetailWorkSrc.StdUnPrcStckUnPrc;
            StockDetailWorkRs.FracProcUnitStcUnPrc = StockDetailWorkSrc.FracProcUnitStcUnPrc;
            StockDetailWorkRs.FracProcStckUnPrc = StockDetailWorkSrc.FracProcStckUnPrc;
            StockDetailWorkRs.StockUnitPriceFl = StockDetailWorkSrc.StockUnitPriceFl;
            StockDetailWorkRs.StockUnitTaxPriceFl = StockDetailWorkSrc.StockUnitTaxPriceFl;
            StockDetailWorkRs.StockUnitChngDiv = StockDetailWorkSrc.StockUnitChngDiv;
            StockDetailWorkRs.BfStockUnitPriceFl = StockDetailWorkSrc.BfStockUnitPriceFl;
            StockDetailWorkRs.BfListPrice = StockDetailWorkSrc.BfListPrice;
            StockDetailWorkRs.RateBLGoodsCode = StockDetailWorkSrc.RateBLGoodsCode;
            StockDetailWorkRs.RateBLGoodsName = StockDetailWorkSrc.RateBLGoodsName;
            StockDetailWorkRs.RateGoodsRateGrpCd = StockDetailWorkSrc.RateGoodsRateGrpCd;
            StockDetailWorkRs.RateGoodsRateGrpNm = StockDetailWorkSrc.RateGoodsRateGrpNm;
            StockDetailWorkRs.RateBLGroupCode = StockDetailWorkSrc.RateBLGroupCode;
            StockDetailWorkRs.RateBLGroupName = StockDetailWorkSrc.RateBLGroupName;
            StockDetailWorkRs.StockCount = StockDetailWorkSrc.StockCount;
            StockDetailWorkRs.OrderCnt = StockDetailWorkSrc.OrderCnt;
            StockDetailWorkRs.OrderAdjustCnt = StockDetailWorkSrc.OrderAdjustCnt;
            StockDetailWorkRs.OrderRemainCnt = StockDetailWorkSrc.OrderRemainCnt;
            StockDetailWorkRs.RemainCntUpdDate = StockDetailWorkSrc.RemainCntUpdDate;
            StockDetailWorkRs.StockPriceTaxExc = StockDetailWorkSrc.StockPriceTaxExc;
            StockDetailWorkRs.StockPriceTaxInc = StockDetailWorkSrc.StockPriceTaxInc;
            StockDetailWorkRs.StockGoodsCd = StockDetailWorkSrc.StockGoodsCd;
            StockDetailWorkRs.StockPriceConsTax = StockDetailWorkSrc.StockPriceConsTax;
            StockDetailWorkRs.TaxationCode = StockDetailWorkSrc.TaxationCode;
            StockDetailWorkRs.StockDtiSlipNote1 = StockDetailWorkSrc.StockDtiSlipNote1;
            StockDetailWorkRs.SalesCustomerCode = StockDetailWorkSrc.SalesCustomerCode;
            StockDetailWorkRs.SalesCustomerSnm = StockDetailWorkSrc.SalesCustomerSnm;
            StockDetailWorkRs.SlipMemo1 = StockDetailWorkSrc.SlipMemo1;
            StockDetailWorkRs.SlipMemo2 = StockDetailWorkSrc.SlipMemo2;
            StockDetailWorkRs.SlipMemo3 = StockDetailWorkSrc.SlipMemo3;
            StockDetailWorkRs.InsideMemo1 = StockDetailWorkSrc.InsideMemo1;
            StockDetailWorkRs.InsideMemo2 = StockDetailWorkSrc.InsideMemo2;
            StockDetailWorkRs.InsideMemo3 = StockDetailWorkSrc.InsideMemo3;
            StockDetailWorkRs.SupplierCd = StockDetailWorkSrc.SupplierCd;
            StockDetailWorkRs.SupplierSnm = StockDetailWorkSrc.SupplierSnm;
            StockDetailWorkRs.AddresseeCode = StockDetailWorkSrc.AddresseeCode;
            StockDetailWorkRs.AddresseeName = StockDetailWorkSrc.AddresseeName;
            StockDetailWorkRs.DirectSendingCd = StockDetailWorkSrc.DirectSendingCd;
            StockDetailWorkRs.OrderNumber = StockDetailWorkSrc.OrderNumber;
            StockDetailWorkRs.WayToOrder = StockDetailWorkSrc.WayToOrder;
            StockDetailWorkRs.DeliGdsCmpltDueDate = StockDetailWorkSrc.DeliGdsCmpltDueDate;
            StockDetailWorkRs.ExpectDeliveryDate = StockDetailWorkSrc.ExpectDeliveryDate;
            StockDetailWorkRs.OrderDataCreateDiv = StockDetailWorkSrc.OrderDataCreateDiv;
            StockDetailWorkRs.OrderDataCreateDate = StockDetailWorkSrc.OrderDataCreateDate;
            StockDetailWorkRs.OrderFormIssuedDiv = StockDetailWorkSrc.OrderFormIssuedDiv;

            StockDetailWorkRs.DtlRelationGuid = StockDetailWorkSrc.DtlRelationGuid;

            return StockDetailWorkRs;
        }
        // ADD by ����� for Redmine#35459 on 2013/05/08 ---------<<<<<<<

        /// <summary>
        /// <c>ArrayList</c>��<c>null</c>���󂩔��肵�܂��B
        /// </summary>
        /// <param name="arrayList">ArrayList</param>
        /// <returns>
        /// <c>true</c> :<c>null</c>�܂��͋�ł���B<br/>
        /// <c>false</c>:�v�f����
        /// </returns>
        private static bool IsNullOrEmpty(ArrayList arrayList)
        {
            return arrayList == null || arrayList.Count.Equals(0);
        }

        #endregion  // <Constructor/>

        #region <����/>

        #region <UOE�����f�[�^/>

        /// <summary>
        /// UOE�����f�[�^�̃��R�[�h���������܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>�Y������UOE�����f�[�^�̃��R�[�h�i�Y�����郌�R�[�h���Ȃ������ꍇ�A<c>null</c>��Ԃ��܂��j</returns>
        public UOEOrderDtlWork FindUOEOrderDtlWork(ReceivedText receivedTelegram)
        {
            string key = GetUOEOrderDertailKey(receivedTelegram);
            if (SearchedUOEOrderDetailRecordMap.ContainsKey(key))
            {
                return SearchedUOEOrderDetailRecordMap[key];
            }

            UOEOrderDtlWork foundRecord = FindUOEOrderDtlWork(receivedTelegram.DtlRelationGuid);
            return foundRecord;
        }

        /// <summary>
        /// UOE�����f�[�^�̃��R�[�h���������܂��B
        /// </summary>
        /// <param name="dtlRelationGuid">GUID</param>
        /// <returns>�Y������UOE�����f�[�^�̃��R�[�h�i�Y�����郌�R�[�h���Ȃ������ꍇ�A<c>null</c>��Ԃ��܂��j</returns>
        /// <remarks>
        /// <br>Update Note: �R�`���i�����d����M��Q</br>
        /// <br>Programmer : �c������</br>
        /// <br>Date       : 2013/01/20 </br>
        /// </remarks>
        public UOEOrderDtlWork FindUOEOrderDtlWork(Guid dtlRelationGuid)
        {
            // ------ADD 2023/01/20 �c������ �����d����M������Q�Ή� ------>>>>>
            if(dtlRelationGuid != Guid.Empty)
            {
            // ------ADD 2023/01/20 �c������ �����d����M������Q�Ή� ------<<<<<        	
	            foreach (UOEOrderDtlWork uoeOrderDtlWork in InsertingUOEOrderDetailRecordList)
	            {
	                if (uoeOrderDtlWork.DtlRelationGuid.Equals(dtlRelationGuid))
	                {
	                    return uoeOrderDtlWork;
	                }
	            }
	
	            foreach (UOEOrderDtlWork uoeOrderDtlWork in SearchedUOEOrderDetailRecordMap.Values)
	            {
	                if (uoeOrderDtlWork.DtlRelationGuid.Equals(dtlRelationGuid))
	                {
	                    return uoeOrderDtlWork;
	                }
	            }
            // ------ADD 2023/01/20 �c������ �����d����M������Q�Ή� ------>>>>>
            }
            // ------ADD 2023/01/20 �c������ �����d����M������Q�Ή� ------<<<<<        	

            return null;
        }

        #endregion  // <UOE�����f�[�^/>

        #region <�d�����׃f�[�^/>

        /// <summary>
        /// �d�����׃f�[�^�̃��R�[�h���������܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>�Y������d�����׃f�[�^�̃��R�[�h�i�Y�����郌�R�[�h���Ȃ������ꍇ�A<c>null</c>��Ԃ��܂��j</returns>
        public StockDetailWork FindStockDetailWork(ReceivedText receivedTelegram)
        {
            string chainKey = GetUOEOrderDertailKey(receivedTelegram);
            if (!ChainKeyMap.ContainsKey(chainKey))
            {
                return FindStockDetailWorkByScanning(receivedTelegram);
            }

            long key = ChainKeyMap[chainKey];
            if (!SearchedStockDetailRecordMap.ContainsKey(key))
            {
                return FindStockDetailWorkByScanning(receivedTelegram);
            }

            return SearchedStockDetailRecordMap[key];
        }

        // add K2012/06/22 >>>
        /// <summary>
        /// �d�����׃f�[�^�̃��R�[�h���������܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>�Y������d�����׃f�[�^�̃��R�[�h�i�Y�����郌�R�[�h���Ȃ������ꍇ�A<c>null</c>��Ԃ��܂��j</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459�̑Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        public StockDetailWork FindStockDetailWork2(ReceivedText receivedTelegram)
        {
            // ADD by ����� for Redmine#35611 on 2013/05/08 --------->>>>>>>
            // �R�`���i�A���A�d�b�����̏ꍇ�A�d�����׃f�[�^���쐬���Ȃ�
            if ((PurchaseStatus.Contract == _optionYamagataCustomControl)
                && receivedTelegram.IsTelephoneOrder())
            {
                    return null;
            }
            // ADD by ����� for Redmine#35611 on 2013/05/08 ---------<<<<<<<<

            string chainKey = GetUOEOrderDertailKey(receivedTelegram);
            if (!ChainKeyMap.ContainsKey(chainKey))
            {
                return FindStockDetailWorkByScanning(receivedTelegram);
            }

            long key = ChainKeyMap[chainKey];
            if (!SearchedStockDetailRecordMap.ContainsKey(key))
            {
                return FindStockDetailWorkByScanning(receivedTelegram);
            }
            if (_noAddStockDetailList.Contains(key))
                return null;
            //int key2 = BridgeKeyMap[chainKey]; // DEL ����� for Redmine#35459 2013/05/08
            long key2 = BridgeKeyMap[chainKey];  // ADD ����� for Redmine#35459 2013/05/08
            if (_noAddStockSlipList.Contains(key2))
                return null;

            return SearchedStockDetailRecordMap[key];
        }
        // add K2012/06/22 <<<

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram"></param>
        /// <returns></returns>
        private StockDetailWork FindStockDetailWorkByScanning(ReceivedText receivedTelegram)
        {
            foreach (IList<StockDetailWork> stockDetailWorkList in StockSlipDetailRecordMap.Values)
            {
                foreach (StockDetailWork stockDetailWork in stockDetailWorkList)
                {
                    if (stockDetailWork.DtlRelationGuid.Equals(receivedTelegram.DtlRelationGuid))
                    {
                        return stockDetailWork;
                    }
                }
            }
            return null;
        }

        #endregion  // <�d�����׃f�[�^/>

        #region <�d���f�[�^/>

        /// <summary>
        /// �d���f�[�^�̃��R�[�h���������܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>�Y������d���f�[�^�̃��R�[�h�i�Y�����郌�R�[�h���Ȃ������ꍇ�A<c>null</c>��Ԃ��܂��j</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459�̑Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        public StockSlipWork FindStockSlipWork(ReceivedText receivedTelegram)
        {
            string bridgeKey = GetUOEOrderDertailKey(receivedTelegram);
            if (!BridgeKeyMap.ContainsKey(bridgeKey))
            {
                return FindStockSlipWorkAtTelOrder(receivedTelegram);
            }

            //int key = BridgeKeyMap[bridgeKey]; // DEL ����� for Redmine#35459 2013/05/08
            long key = BridgeKeyMap[bridgeKey];  // ADD ����� for Redmine#35459 2013/05/08
            if (!StockSlipRecordMap.ContainsKey(key))
            {
                return FindStockSlipWorkAtTelOrder(receivedTelegram);
            }

            return StockSlipRecordMap[key];
        }

        /// <summary>
        /// �d�b�������̎d���f�[�^���������܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>�Y������d���f�[�^�̃��R�[�h�i�Y�����郌�R�[�h���Ȃ������ꍇ�A<c>null</c>��Ԃ��܂��j</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459�̑Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        private StockSlipWork FindStockSlipWorkAtTelOrder(ReceivedText receivedTelegram)
        {
            string key = receivedTelegram.ToSlipNo();
            if (!TelOrderSupplierSlipNoMap.ContainsKey(key))
            {
                return null;
            }

            //int telOrderSupplierSlipNo = TelOrderSupplierSlipNoMap[key];  // DEL ����� for Redmine#35459 2013/05/08
            long telOrderSupplierSlipNo = TelOrderSupplierSlipNoMap[key];   // ADD ����� for Redmine#35459 2013/05/08
            if (!StockSlipRecordMap.ContainsKey(telOrderSupplierSlipNo))
            {
                return null;
            }

            return StockSlipRecordMap[telOrderSupplierSlipNo];
        }

        /// <summary>
        /// �d���`�[�ԍ����������܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>�Y������d���`�[�ԍ��i�Y������d���`�[�ԍ����Ȃ������ꍇ�A<c>string.Empty</c>��Ԃ��܂��j</returns>
        /// <remarks>
        /// <br>Update Note: Redmine#35459�̑Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08 </br>
        /// </remarks>
        public string FindSupplierSlipNo(ReceivedText receivedTelegram)
        {
            string bridgeKey = GetUOEOrderDertailKey(receivedTelegram);
            if (!BridgeKeyMap.ContainsKey(bridgeKey))
            {
                string slipNo = receivedTelegram.ToSlipNo();
                if (TelOrderSupplierSlipNoMap.ContainsKey(slipNo))
                {
                    return TelOrderSupplierSlipNoMap[slipNo].ToString();
                }
                return string.Empty;
            }

            //int key = BridgeKeyMap[bridgeKey]; // DEL ����� for Redmine#35459 2013/05/08
            long key = BridgeKeyMap[bridgeKey];  // ADD ����� for Redmine#35459 2013/05/08
            if (!StockSlipRecordMap.ContainsKey(key))
            {
                string slipNo = receivedTelegram.ToSlipNo();
                if (TelOrderSupplierSlipNoMap.ContainsKey(slipNo))
                {
                    return TelOrderSupplierSlipNoMap[slipNo].ToString();
                }
                return string.Empty;
            }

            return key.ToString();
        }

        #endregion  // <�d���f�[�^/>

        #endregion  // <����/>

        #region <���v/>

        /// <summary>
        /// �d�����z���v���擾���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>�d�����׃f�[�^�̎d�����z�i�Ŕ����j���v</returns>
        public long GetStockTotalPrice(ReceivedText receivedTelegram)
        {
            string strSupplierSlipNo = FindSupplierSlipNo(receivedTelegram);
            if (string.IsNullOrEmpty(strSupplierSlipNo)) return 0;

            int supplierSlipNo = int.Parse(strSupplierSlipNo);
            if (!StockSlipDetailRecordMap.ContainsKey(supplierSlipNo)) return 0;

            long sum = 0;
            foreach (StockDetailWork stockDetailWork in StockSlipDetailRecordMap[supplierSlipNo])
            {
                sum += stockDetailWork.StockPriceTaxExc;
            }
            return sum;
        }

        /// <summary>
        /// �d�����z���v���擾���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>�d�����׃f�[�^�̎d�����z�i�ō��݁j���v</returns>
        public long GetStockSubttlPrice(ReceivedText receivedTelegram)
        {
            string strSupplierSlipNo = FindSupplierSlipNo(receivedTelegram);
            if (string.IsNullOrEmpty(strSupplierSlipNo)) return 0;

            int supplierSlipNo = int.Parse(strSupplierSlipNo);
            if (!StockSlipDetailRecordMap.ContainsKey(supplierSlipNo)) return 0;

            long sum = 0;
            foreach (StockDetailWork stockDetailWork in StockSlipDetailRecordMap[supplierSlipNo])
            {
                sum += stockDetailWork.StockPriceTaxInc;
            }
            return sum;
        }

        /// <summary>
        /// ���׍s�����擾���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <returns>�֘A����d�����׃f�[�^�̐�</returns>
        public int GetDetailRowCount(ReceivedText receivedTelegram)
        {
            string strSupplierSlipNo = FindSupplierSlipNo(receivedTelegram);
            if (string.IsNullOrEmpty(strSupplierSlipNo)) return 0;

            int supplierSlipNo = int.Parse(strSupplierSlipNo);
            if (!StockSlipDetailRecordMap.ContainsKey(supplierSlipNo)) return 0;

            return StockSlipDetailRecordMap[supplierSlipNo].Count;
        }

        #endregion  // <���v/>

        #region <��ƃR�[�h/>

        /// <summary>
        /// ��ƃR�[�h���擾���܂��B
        /// </summary>
        private string EnterpriseCode
        {
            get
            {
                if (SearchedUOEOrderDetailRecordMap.Values.Count > 0)
                {
                    foreach (UOEOrderDtlWork uoeOrderDetail in SearchedUOEOrderDetailRecordMap.Values)
                    {
                        return uoeOrderDetail.EnterpriseCode;
                    }
                }
                if (InsertingUOEOrderDetailRecordList.Count > 0)
                {
                    return InsertingUOEOrderDetailRecordList[0].EnterpriseCode;
                }
                return string.Empty;
            }
        }

        #endregion  // <��ƃR�[�h/>

        #region <����E�d������I�v�V����/>

        /// <summary>
        /// ����E�d������I�v�V�����𐶐����܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>����E�d������I�v�V����</returns>
        private static IOWriteCtrlOptWork CreateIOWriteCtrlOption(string enterpriseCode)
        {
            // ����E�d������I�v�V������ݒ�
            IOWriteCtrlOptWork ioWriteCtrlOption = new IOWriteCtrlOptWork();
            {
                // ����N�_�i0:����, 1:�d��, 2:�d�����㓯���v��, 9:���ݒ�j
                ioWriteCtrlOption.CtrlStartingPoint = 1;

                // ���σf�[�^�v��c�敪�i0:�c��, 1:�c���Ȃ��j
                ioWriteCtrlOption.EstimateAddUpRemDiv = 0;

                // �󒍃f�[�^�v��c�敪�i0:�c��, 1:�c���Ȃ��j
                ioWriteCtrlOption.AcpOdrrAddUpRemDiv = 0;

                // �o�׃f�[�^�v��c�敪�i0:�c��, 1:�c���Ȃ��j
                ioWriteCtrlOption.ShipmAddUpRemDiv = 0;

                // �ԕi���݌ɓo�^�敪�i0:����, 1:���Ȃ��j
                ioWriteCtrlOption.RetGoodsStockEtyDiv = 0;

                // �d���`�[�폜�敪�i0:���Ȃ�, 1:�m�F, 2:����i����F���d�������v��̎d���`�[�𔄓`�폜���ɓ����폜�j�j
                ioWriteCtrlOption.SupplierSlipDelDiv = 0;

                // �c���Ǘ��敪�i0:����, 1:���Ȃ��@���`�[�폜���Ɏc�ɖ߂����ǂ����j
                ioWriteCtrlOption.RemainCntMngDiv = 0;

                // ��ƃR�[�h�i�r������̃L�[�Ƃ��ėp�����ƃR�[�h�j
                ioWriteCtrlOption.EnterpriseCode = enterpriseCode;

                // �ԗ��Ǘ��敪�i0:���Ȃ�, 1:����j
                ioWriteCtrlOption.CarMngDivCd = 0;
            }
            return ioWriteCtrlOption;
        }

        #endregion  // <����E�d������I�v�V����/>

        #region <�`�[���גǉ����f�[�^/>

        /// <summary>�`�[���גǉ����f�[�^�̃J�E���^</summary>
        private static int _slipDetailAddInfoCount;

        /// <summary>
        /// �`�[���גǉ����f�[�^�𐶐����܂��B
        /// </summary>
        /// <param name="dtlRelationGuid">���׊֘A�t��GUID</param>
        /// <returns>�`�[���גǉ����f�[�^</returns>
        private static SlipDetailAddInfoWork CreateSlipDetailAddInfoWork(Guid dtlRelationGuid)
        {
            SlipDetailAddInfoWork slipDetailAddInfoWork = new SlipDetailAddInfoWork();
            {
                slipDetailAddInfoWork.DtlRelationGuid = dtlRelationGuid;
                slipDetailAddInfoWork.GoodsEntryDiv = 0;    // 0:�Ȃ��^1:����
                slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                slipDetailAddInfoWork.PriceUpdateDiv = 0;    // 0:�Ȃ��^1:����
                slipDetailAddInfoWork.PriceStartDate = DateTime.MinValue;
                slipDetailAddInfoWork.GoodsOfferDate = DateTime.MinValue;
                slipDetailAddInfoWork.CarRelationGuid = Guid.Empty;
                slipDetailAddInfoWork.SlipDtlRegOrder = (++_slipDetailAddInfoCount);    // �`�[�ԍ��Ƒ召�𓯂��֌W�ɂ���
                slipDetailAddInfoWork.AddUpRemDiv = 1;    // 0:����d������I�v�V�����ɏ����^1:�c���^2:�c���Ȃ�
            }
            return slipDetailAddInfoWork;
        }

        #endregion  // <�`�[���גǉ����f�[�^/>

        /// <summary>
        /// �����ރf�[�^�𐶐����܂��B
        /// </summary>
        /// <param name="writingSumUpInformation">�v����̏����݃t���O</param>
        /// <returns>�����ރf�[�^</returns>
        /// <remarks>
        /// <br></br>
        /// <br>Update Note: �R�`���i���S�ʃI�v�V��������ǉ�</br>
        /// <br>Programmer : FSI���X�� �M�p</br>
        /// <br>Date       : K2012/12/11 </br>
        /// <br></br>
        /// <br>Update Note: Redmine#35459�̑Ή�</br>
        /// <br>Programmer : �����</br>
        /// <br>Date       : 2013/05/08 </br>
        /// <br>Update Note: 2014/05/30 ���N�n��</br>
        /// <br>             Redmine 42755 �G���[�u�d�������d���f�[�^�����݂��܂��v�̑Ή�</br>
        /// <br>Update Note: PMKOBETSU-4189�@���O�ǉ�</br>
        /// <br>Programmer : ���O</br>
        /// <br>Date       : K2021/09/22</br>
        /// </remarks>
        public CustomSerializeArrayList CreateWritingData(bool writingSumUpInformation)
        {
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------>>>>>
            //UOE�����f�[�^����
            int uoeOrderDataCount = 0;
            //UOE�����f�[�^(�d�b��)����
            int uoeOrderDataTelCount = 0;
            //�d���f�[�^(������)����
            int stockSlipOrderCount = 0;
            //�d�����׃f�[�^(������)����
            int stockDetailOrderCount = 0;
            //�d���f�[�^����
            int stockSlipCount = 0;
            //�d�����׃f�[�^����
            int stockDetailCount = 0;
            //�݌ɒ����f�[�^����
            int stockAdjustCount = 0;
            //�݌ɒ������׃f�[�^����
            int stockAdjustDetailCount = 0;
            // ------ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή� ------<<<<<
            CustomSerializeArrayList writingData = new CustomSerializeArrayList();
            {
                if (GetUOEOrderDataCount().Equals(0)) return writingData;

                // ����E�d������I�v�V����
                #region <����E�d������I�v�V����/>

                writingData.Add(CreateIOWriteCtrlOption(EnterpriseCode));

                #endregion  // <����E�d������I�v�V����/>

                // UOE�����f�[�^
                #region <UOE�����f�[�^/>

                ArrayList uoeOrderDataList = new ArrayList();
                {
                    foreach (UOEOrderDtlWork uoeOrderDtlWork in SearchedUOEOrderDetailRecordMap.Values)
                    {
                        UOEOrderDtlWork writingRecord = FormatWritingData(uoeOrderDtlWork);
                        // add K2012/06/22 >>>
                        string key = GetUOEOrderDertailKey(uoeOrderDtlWork);
                        // DEL K2012/12/11 END <<<<<<
                        //if (_noAddUoeOderList.Contains(key))
                        // DEL K2012/12/11 END <<<<<<
                        // ADD K2012/12/11 START >>>>>>
                        // �R�`���i���S�ʃI�v�V�������L�����ǉ����Ȃ����X�g�ɑ��݂���f�[�^�̏ꍇ�A�o�^�ΏۂƂ��Ȃ�
                        if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (_noAddUoeOderList.Contains(key)))
                        // ADD K2012/12/11 END <<<<<<
                                continue;
                        // add K2012/06/22 <<<
                        uoeOrderDataList.Add(writingRecord);
                        uoeOrderDataCount++;// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
                    }
                    foreach (UOEOrderDtlWork uoeOrderDtlWork in InsertingUOEOrderDetailRecordList)
                    {
                        UOEOrderDtlWork writingRecord = FormatWritingData(uoeOrderDtlWork);
                        // add K2012/06/22 >>>
                        string key = GetUOEOrderDertailKey(uoeOrderDtlWork);
                        // DEL K2012/12/11 END <<<<<<
                        //if (_noAddUoeOderList.Contains(key))
                        // DEL K2012/12/11 END <<<<<<
                        // ADD K2012/12/11 START >>>>>>
                        // �R�`���i���S�ʃI�v�V�������L�����ǉ����Ȃ����X�g�ɑ��݂���f�[�^�̏ꍇ�A�o�^�ΏۂƂ��Ȃ�
                        if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (_noAddUoeOderList.Contains(key)))
                        // ADD K2012/12/11 END <<<<<<
                            continue;
                        // add K2012/06/22 <<<
                        uoeOrderDataList.Add(writingRecord);
                        uoeOrderDataTelCount++;// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
                    }
                }
                // add K2012/06/22 >>>
                // DEL K2012/12/11 END <<<<<<
                //// UOE�����f�[�^�̍X�V�Ώۂ�0�Ȃ�DB�X�V���s��Ȃ�
                //if (uoeOrderDataList.Count == 0)
                // DEL K2012/12/11 END <<<<<<
                // ADD K2012/12/11 START >>>>>>
                // �R�`���i���S�ʃI�v�V�������L������UOE�����f�[�^�̍X�V�Ώۂ�0�Ȃ�DB�X�V���s��Ȃ�
                if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (uoeOrderDataList.Count == 0))
                // ADD K2012/12/11 END <<<<<<
                {
                    this._dbWriteFlg = false;
                }
                else
                    this._dbWriteFlg = true;
                // add K2012/06/22 <<<
                CustomSerializeArrayList uoeOrderData = new CustomSerializeArrayList();
                {
                    uoeOrderData.Add(uoeOrderDataList);
                }
                if (uoeOrderData.Count > 0)
                {
                    writingData.Add(uoeOrderData);
                }

                #endregion  // <UOE�����f�[�^/>

                // �������̎d���f�[�^�Ǝd�����׃f�[�^
                #region <�������̎d���f�[�^�Ǝd�����׃f�[�^/>

                CustomSerializeArrayList orderStockData = new CustomSerializeArrayList();
                {
                    //foreach (int supplierSlipNo in StockSlipDetailRecordMap.Keys)  // DEL ����� for Redmine#35459 2013/05/08
                    foreach (long supplierSlipNo in StockSlipDetailRecordMap.Keys)   // ADD ����� for Redmine#35459 2013/05/08
                    {
                        // �d�b�������̔���
                        if (supplierSlipNo > 0) continue;

                        CustomSerializeArrayList slipList = new CustomSerializeArrayList();
                        {
                            // �������̎d���f�[�^
                            StockSlipWork writingRecord = FormatWritingData(StockSlipRecordMap[supplierSlipNo], true);

                            // add K2012/06/22 >>>
                            // DEL K2012/12/11 END <<<<<<
                            //if (_noAddStockSlipList.Contains(writingRecord.SupplierSlipNo))
                            //    //if (stockSlipKey.Contains(writingRecord.SupplierSlipNo))
                            // DEL K2012/12/11 END <<<<<<
                            // ADD K2012/12/11 START >>>>>>
                            // �R�`���i���S�ʃI�v�V�������L�����ǉ����Ȃ����X�g�ɑ��݂���f�[�^�̏ꍇ�A�o�^�ΏۂƂ��Ȃ�
                            if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (_noAddStockSlipList.Contains(writingRecord.SupplierSlipNo)))
                            // ADD K2012/12/11 END <<<<<<
                                continue;
                            // add K2012/06/22 <<<
                            slipList.Add(writingRecord);
                            stockSlipOrderCount++;// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
                        }
                        // �������̎d�����׃f�[�^ 
                        ArrayList stockDetailList = new ArrayList();
                        {
                            foreach (StockDetailWork stockDetailWork in StockSlipDetailRecordMap[supplierSlipNo])
                            {
                                StockDetailWork writingRecord = FormatWritingData(stockDetailWork, true);
                                // add K2012/06/22 >>>
                                // DEL K2012/12/11 END <<<<<<
                                //if (_noAddStockDetailList.Contains(writingRecord.StockSlipDtlNum))
                                //    //if (stockDetailKey.Contains(writingRecord.StockSlipDtlNum))
                                // DEL K2012/12/11 END <<<<<<
                                // ADD K2012/12/11 START >>>>>>
                                // �R�`���i���S�ʃI�v�V�������L�����ǉ����Ȃ����X�g�ɑ��݂���f�[�^�̏ꍇ�A�o�^�ΏۂƂ��Ȃ�
                                if ((PurchaseStatus.Contract == _optionYamagataCustomControl) && (_noAddStockDetailList.Contains(writingRecord.StockSlipDtlNum)))
                                // ADD K2012/12/11 END <<<<<<
                                    continue;
                                // add K2012/06/22 <<<
                                stockDetailList.Add(writingRecord);
                                stockDetailOrderCount++;// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
                            }
                        }
                        slipList.Add(stockDetailList);

                        if (slipList.Count > 0)
                        {
                            writingData.Add(slipList);
                        }

                        //orderStockData.Add(slipList);
                    }
                }
                //writingData.Add(orderStockData);

                #endregion  // <�������̎d���f�[�^�Ǝd�����׃f�[�^/>

                if (!writingSumUpInformation) return writingData;

                // �v����̎d���f�[�^�Ǝd�����׃f�[�^
                #region <�v����̎d���f�[�^�Ǝd�����׃f�[�^/>

                if (SumUpStockSlipDetailRecordMap.Count > 0)
                {
                    CustomSerializeArrayList sumUpStockData = new CustomSerializeArrayList();
                    {
                        _slipDetailAddInfoCount = 0;

                        // 2010/10/19 >>>
                        //// �`�[�ԍ����\�[�g
                        //SortedList<int, int> sortedSupplierSlipNoList = new SortedList<int, int>();
                        //{
                        //    foreach (int supplierSlipNo in SumUpStockSlipDetailRecordMap.Keys)
                        //    {
                        //        sortedSupplierSlipNoList.Add(supplierSlipNo, supplierSlipNo);
                        //    }
                        //}

                        // �d���`�[�ԍ�(�����`�[�ԍ�)���Ƀ\�[�g
                        SortedList<string, int> sortedSupplierSlipNoList = new SortedList<string, int>();
                        {
                            foreach (int supplierSlipNo in SumUpStockSlipRecordMap.Keys)
                            {
                                sortedSupplierSlipNoList.Add(SumUpStockSlipRecordMap[supplierSlipNo].PartySaleSlipNum, supplierSlipNo);
                            }
                        }
                        // 2010/10/19 <<<
                        foreach (int supplierSlipNo in sortedSupplierSlipNoList.Values)
                        {
                            // add K2012/06/22 >>>
                            // DEL K2012/12/11 END <<<<<<
                            //if (string.IsNullOrEmpty(SumUpStockSlipRecordMap[supplierSlipNo].PartySaleSlipNum))
                            // DEL K2012/12/11 END <<<<<<
                            // ADD K2012/12/11 START >>>>>>
                            // �R�`���i���S�ʃI�v�V�������L���������`�[�ԍ����ݒ肳��Ă��Ȃ��ꍇ�A
                            // �{�X�e�[�g�����g���̈ȍ~�̏������X�L�b�v����
                            String PartySaleSlipNum = SumUpStockSlipRecordMap[supplierSlipNo].PartySaleSlipNum;  // ADD by ����� for Redmine#35611 on 2013/05/08
                            if (   (PurchaseStatus.Contract == _optionYamagataCustomControl) 
                                // && (string.IsNullOrEmpty(SumUpStockSlipRecordMap[supplierSlipNo].PartySaleSlipNum)))  // DEL  by ����� for Redmine#35611 on 2013/05/08
                                // && (!(string.IsNullOrEmpty(PartySaleSlipNum)) && "FALSE".Equals(PartySaleSlipNum.Substring(0, 5))))  // ADD by ����� for Redmine#35611 on 2013/05/08// DEL 2014/05/30 ���N�n�� Redmine 42755 �G���[�u�d�������d���f�[�^�����݂��܂��v�̑Ή�
                                && (!(string.IsNullOrEmpty(PartySaleSlipNum)) && PartySaleSlipNum.Length >= 5 && "FALSE".Equals(PartySaleSlipNum.Substring(0, 5))))// ADD 2014/05/30 ���N�n�� Redmine 42755 �G���[�u�d�������d���f�[�^�����݂��܂��v�̑Ή�
                            // ADD K2012/12/11 END <<<<<<
                                continue;
                            // add K2012/06/22 <<<
                            CustomSerializeArrayList slipList = new CustomSerializeArrayList();
                            {
                                // �v����̎d���f�[�^
                                StockSlipWork writingRecord = FormatWritingData(SumUpStockSlipRecordMap[supplierSlipNo], false);
                                slipList.Add(writingRecord);
                                stockSlipCount++;// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
                            }
                            // �v����̎d�����׃f�[�^ 
                            ArrayList stockDetailList = new ArrayList();
                            {
                                foreach (StockDetailWork stockDetailWork in SumUpStockSlipDetailRecordMap[supplierSlipNo])
                                {
                                    // 2009/10/14 Add >>>
                                    if (FindUOEOrderDtlWork(stockDetailWork.DtlRelationGuid) == null) continue;
                                    // 2009/10/14 Add <<<
                                    StockDetailWork writingRecord = FormatWritingData(stockDetailWork, false);
                                    stockDetailList.Add(writingRecord);
                                    stockDetailCount++;// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
                                }
                            }
                            slipList.Add(stockDetailList);

                            // �`�[���גǉ����f�[�^
                            ArrayList slipDetailAddInfoList = new ArrayList();
                            {
                                foreach (StockDetailWork stockDetailWork in stockDetailList)
                                {
                                    SlipDetailAddInfoWork slipDetailAddInfoWork = CreateSlipDetailAddInfoWork(stockDetailWork.DtlRelationGuid);
                                    slipDetailAddInfoList.Add(slipDetailAddInfoWork);
                                }
                            }
                            slipList.Add(slipDetailAddInfoList);

                            writingData.Add(slipList);

                            //sumUpStockData.Add(slipList);
                        }   // foreach (int supplierSlipNo in sortedSupplierSlipNoList.Values)
                    }   // CustomSerializeArrayList sumUpStockData = new CustomSerializeArrayList();
                    //writingData.Add(sumUpStockData);
                }   // if (SumUpStockSlipDetailRecordMap.Count > 0)

                #endregion  // <�v����̎d���f�[�^�Ǝd�����׃f�[�^/>

                // �v����̍݌ɒ����f�[�^�ƍ݌ɒ������׃f�[�^
                #region <�v����̎d���f�[�^�Ǝd�����׃f�[�^/>

                // �݌ɒ������׃f�[�^�� 0�� �̏ꍇ�����肦��̂ŁA�݌ɒ������׃f�[�^�̌����������Ɋ܂�
                if (SumUpStockAdjustDetailRecordMap.Count > 0 && SumUpStockAdjustDetailRecordMap.Values.Count > 0)
                {
                    CustomSerializeArrayList sumUpAdjustData = new CustomSerializeArrayList();
                    {
                        foreach (int supplierSlipNo in SumUpStockAdjustDetailRecordMap.Keys)
                        {
                            CustomSerializeArrayList adjustList = new CustomSerializeArrayList();
                            {
                                // �v����̍݌ɒ����f�[�^
                                ArrayList stockAdjustWork = new ArrayList();
                                {
                                    // 2009/10/15 >>>
                                    //stockAdjustWork.Add(SumUpAdjustRecordMap[supplierSlipNo]);
                                    stockAdjustWork.Add(FormatWritingData(SumUpAdjustRecordMap[supplierSlipNo], true));
                                    // 2009/10/15 <<<
                                }
                                adjustList.Add(stockAdjustWork);
                                stockAdjustCount++;// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
                            }
                            // �v����̍݌ɒ������׃f�[�^ 
                            ArrayList stockAdjustDetailList = new ArrayList();
                            {
                                foreach (StockAdjustDtlWork stockAdjustDetailWork in SumUpStockAdjustDetailRecordMap[supplierSlipNo])
                                {
                                    // 2009/10/15 >>>
                                    //stockAdjustDetailList.Add(stockAdjustDetailWork);
                                    stockAdjustDetailList.Add(FormatWritingData(stockAdjustDetailWork, true));
                                    stockAdjustDetailCount++;// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
                                    // 2009/10/15 <<<
                                }
                            }
                            adjustList.Add(stockAdjustDetailList);

                            // 2009/02/26 �݌ɒ����̃p�����[�^�\�����ύX
                            //writingData.Add(adjustList);
                            sumUpAdjustData.Add(adjustList);

                            _stockAdjustDBParamList = adjustList;   // HACK:<�P�Ƃō݌ɒ����f�[�^�����������R�[�h/>
                            //sumUpAdjustData.Add(slipList);
                        }   // foreach (int supplierSlipNo in SumUpStockAdjustDetailRecordMap.Keys)
                    }   // CustomSerializeArrayList sumUpAdjustData = new CustomSerializeArrayList();

                    writingData.Add(sumUpAdjustData);   // 2009/02/26 �݌ɒ����̃p�����[�^�\�����ύX
                }   // if (SumUpStockAdjustDetailRecordMap.Count > 0 && SumUpStockAdjustDetailRecordMap.Values.Count > 0)

                #endregion  // <�v����̎d���f�[�^�Ǝd�����׃f�[�^/>
            }
            _logMsg = string.Format(CtLogDataMassage, uoeOrderDataCount, stockSlipCount, stockDetailCount, stockAdjustCount, stockAdjustDetailCount);// ADD K2021/09/22 ���O PMKOBETSU-4189�̑Ή�
            return writingData;
        }

        #region <�����ݗp�t�H�[�}�b�g/>

        /// <summary>
        /// UOE�����f�[�^�̃��R�[�h�������ݗp�Ƀt�H�[�}�b�g���܂��B
        /// </summary>
        /// <param name="src">�����R�[�h</param>
        private static UOEOrderDtlWork FormatWritingData(UOEOrderDtlWork src)
        {
            UOEOrderDtlWork nullValue = new UOEOrderDtlWork();
            {
                src.CreateDateTime      = nullValue.CreateDateTime;     // 001.�쐬����
                src.UpdateDateTime      = nullValue.UpdateDateTime;     // 002.�X�V����
                // 003.��ƃR�[�h
                src.FileHeaderGuid      = nullValue.FileHeaderGuid;     // 004.GUID
                src.UpdEmployeeCode     = nullValue.UpdEmployeeCode;    // 005.�X�V�]�ƈ��R�[�h
                src.UpdAssemblyId1      = nullValue.UpdAssemblyId1;     // 006.�X�V�A�Z���u��ID1
                src.UpdAssemblyId2      = nullValue.UpdAssemblyId2;     // 007.�X�V�A�Z���u��ID2
                src.LogicalDeleteCode   = nullValue.LogicalDeleteCode;  // 008.�_���폜�敪

                src.OnlineNo            = nullValue.OnlineNo;           // 016.�I�����C���ԍ�
                // 017.�I�����C���s�ԍ�
            }
            return src;
        }

        /// <summary>
        /// �d���f�[�^�̃��R�[�h�������ݗp�Ƀt�H�[�}�b�g���܂��B
        /// </summary>
        /// <param name="src">�����R�[�h</param>
        /// <param name="isOrder"></param>
        private static StockSlipWork FormatWritingData(
            StockSlipWork src,
            bool isOrder
        )
        {
            StockSlipWork nullValue = new StockSlipWork();
            {
                if (!isOrder)
                {
                    src.CreateDateTime      = nullValue.CreateDateTime;     // 001.�쐬����
                    src.UpdateDateTime      = nullValue.UpdateDateTime;     // 002.�X�V����
                    // 003.��ƃR�[�h
                    src.FileHeaderGuid      = nullValue.FileHeaderGuid;     // 004.GUID
                    src.UpdEmployeeCode     = nullValue.UpdEmployeeCode;    // 005.�X�V�]�ƈ��R�[�h
                    src.UpdAssemblyId1      = nullValue.UpdAssemblyId1;     // 006.�X�V�A�Z���u��ID1
                    src.UpdAssemblyId2      = nullValue.UpdAssemblyId2;     // 007.�X�V�A�Z���u��ID2
                    src.LogicalDeleteCode   = nullValue.LogicalDeleteCode;  // 008.�_���폜�敪
                }
                src.SupplierSlipNo = nullValue.SupplierSlipNo;  // 010.�d���`�[�ԍ�

                // 2009/10/15 >>>
                // �����␳
                if (src.StockInputName.Length > 16) src.StockInputName = src.StockInputName.Substring(0, 16);   // �d�����͎Җ���
                if (src.StockAgentName.Length > 16) src.StockAgentName = src.StockAgentName.Substring(0, 16);   // �d���S���Җ���
                // 2009/10/15 <<<
            }
            return src;
        }

        /// <summary>
        /// �d�����׃f�[�^�̃��R�[�h�������ݗp�Ƀt�H�[�}�b�g���܂��B
        /// </summary>
        /// <param name="src">�����R�[�h</param>
        /// <param name="isOrder"></param>
        private static StockDetailWork FormatWritingData(
            StockDetailWork src,
            bool isOrder
        )
        {
            StockDetailWork nullValue = new StockDetailWork();
            {
                if (!isOrder)
                {
                    src.CreateDateTime      = nullValue.CreateDateTime;     // 001.�쐬����
                    src.UpdateDateTime      = nullValue.UpdateDateTime;     // 002.�X�V����
                    // 003.��ƃR�[�h
                    src.FileHeaderGuid      = nullValue.FileHeaderGuid;     // 004.GUID
                    src.UpdEmployeeCode     = nullValue.UpdEmployeeCode;    // 005.�X�V�]�ƈ��R�[�h
                    src.UpdAssemblyId1      = nullValue.UpdAssemblyId1;     // 006.�X�V�A�Z���u��ID1
                    src.UpdAssemblyId2      = nullValue.UpdAssemblyId2;     // 007.�X�V�A�Z���u��ID2
                    src.LogicalDeleteCode   = nullValue.LogicalDeleteCode;  // 008.�_���폜�敪

                    src.StockSlipDtlNum = nullValue.StockSlipDtlNum;    // 016.�d�����גʔ�
                }
                src.AcceptAnOrderNo = nullValue.AcceptAnOrderNo;    // 009.�󒍔ԍ�
                src.SupplierSlipNo  = nullValue.SupplierSlipNo;     // 011.�d���`�[�ԍ�
                // 012.�d���s�ԍ�
                // 015.���ʒʔ�

                // 2009/10/15 >>>
                // �����␳
                if (src.StockInputName.Length > 16) src.StockInputName = src.StockInputName.Substring(0, 16);   // �d�����͎Җ���
                if (src.StockAgentName.Length > 16) src.StockAgentName = src.StockAgentName.Substring(0, 16);   // �d���S���Җ���
                // 2009/10/15 <<<

            }
            return src;
        }

        // 2009/10/15 Add >>>
        /// <summary>
        /// �݌ɒ����f�[�^�̃��R�[�h�������ݗp�Ƀt�H�[�}�b�g���܂��B
        /// </summary>
        /// <param name="src">�����R�[�h</param>
        /// <param name="isOrder"></param>
        private static StockAdjustWork FormatWritingData(
            StockAdjustWork src,
            bool isOrder
        )
        {
            StockAdjustWork nullValue = new StockAdjustWork();
            {
                if (!isOrder)
                {
                }

                // �����␳
                if (src.StockInputName.Length > 16) src.StockInputName = src.StockInputName.Substring(0, 16);   // �d�����͎Җ���
                if (src.StockAgentName.Length > 16) src.StockAgentName = src.StockAgentName.Substring(0, 16);   // �d���S���Җ���
            }
            return src;
        }

        /// <summary>
        /// �݌ɒ������׃f�[�^�̃��R�[�h�������ݗp�Ƀt�H�[�}�b�g���܂��B
        /// </summary>
        /// <param name="src">�����R�[�h</param>
        /// <param name="isOrder"></param>
        private static StockAdjustDtlWork FormatWritingData(
            StockAdjustDtlWork src,
            bool isOrder
        )
        {
            StockAdjustDtlWork nullValue = new StockAdjustDtlWork();
            {
                if (!isOrder)
                {
                }
            }
            return src;
        }

        // 2009/10/15 Add <<<

        #endregion  // <�����ݗp�t�H�[�}�b�g/>

        #region <����MJNL/>

        /// <summary>
        /// ����MJNL���R�[�h�̃��X�g�𐶐����܂��B
        /// </summary>
        /// <returns>����MJNL���R�[�h�̃��X�g</returns>
        public List<OrderSndRcvJnl> CreateOrderSndRcvJnlList()
        {
            List<OrderSndRcvJnl> orderSndRcvJnlList = new List<OrderSndRcvJnl>();
            {
                foreach (UOEOrderDtlWork uoeOrderDtlWork in SearchedUOEOrderDetailRecordMap.Values)
                {
                    orderSndRcvJnlList.Add(CreateOrderSndRcvJnl(uoeOrderDtlWork));
                }
                foreach (UOEOrderDtlWork uoeOrderDtlWork in InsertingUOEOrderDetailRecordList)
                {
                    orderSndRcvJnlList.Add(CreateOrderSndRcvJnl(uoeOrderDtlWork));
                }
            }
            return orderSndRcvJnlList;
        }

        /// <summary>
        /// ����MJNL���R�[�h�𐶐����܂��B
        /// </summary>
        /// <param name="src">UOE�����f�[�^�̖��׃��R�[�h</param>
        /// <returns>����MJNL���R�[�h</returns>
        private static OrderSndRcvJnl CreateOrderSndRcvJnl(UOEOrderDtlWork src)
        {
            OrderSndRcvJnl record = new OrderSndRcvJnl();
            {
                #region <�����o�t�B�[���h���R�s�[/>

                record.AcceptAnOrderCnt = src.AcceptAnOrderCnt;
                record.AcptAnOdrStatus = src.AcptAnOdrStatus;
                record.AnswerListPrice = src.AnswerListPrice;
                record.AnswerMakerCd = src.AnswerMakerCd;
                record.AnswerPartsName = src.AnswerPartsName;
                record.AnswerPartsNo = src.AnswerPartsNo;
                record.AnswerSalesUnitCost = src.AnswerSalesUnitCost;
                record.BoCode = src.BoCode;
                record.BOCount = src.BOCount;
                record.BOManagementNo = src.BOManagementNo;
                record.BOShipmentCnt1 = src.BOShipmentCnt1;
                record.BOShipmentCnt2 = src.BOShipmentCnt2;
                record.BOShipmentCnt3 = src.BOShipmentCnt3;
                record.BOSlipNo1 = src.BOSlipNo1;
                record.BOSlipNo2 = src.BOSlipNo2;
                record.BOSlipNo3 = src.BOSlipNo3;
                record.BOStockCount1 = src.BOStockCount1;
                record.BOStockCount2 = src.BOStockCount2;
                record.BOStockCount3 = src.BOStockCount3;
                record.CashRegisterNo = src.CashRegisterNo;
                record.CommAssemblyId = src.CommAssemblyId;
                record.CommonSeqNo = src.CommonSeqNo;
                record.CreateDateTime = src.CreateDateTime;
                //record.CreateDateTimeAdFormal = src.CreateDateTimeAdFormal;
                //record.CreateDateTimeAdInFormal = src.CreateDateTimeAdInFormal;
                //record.CreateDateTimeJpFormal = src.CreateDateTimeJpFormal;
                //record.CreateDateTimeJpInFormal = src.CreateDateTimeJpInFormal;
                record.CustomerCode = src.CustomerCode;
                record.CustomerSnm = src.CustomerSnm;
                record.DataRecoverDiv = src.DataRecoverDiv;
                record.DataSendCode = src.DataSendCode;
                record.DataUpdateDateTime = src.DataUpdateDateTime;
                //record.DataUpdateDateTimeAdFormal = src.DataUpdateDateTimeAdFormal;
                //record.DataUpdateDateTimeAdInFormal = src.DataUpdateDateTimeAdInFormal;
                //record.DataUpdateDateTimeJpFormal = src.DataUpdateDateTimeJpFormal;
                //record.DataUpdateDateTimeJpInFormal = src.DataUpdateDateTimeJpInFormal;
                record.DeliveredGoodsDivNm = src.DeliveredGoodsDivNm;
                record.DtlRelationGuid = src.DtlRelationGuid;
                record.EmployeeCode = src.EmployeeCode;
                record.EmployeeName = src.EmployeeName;
                record.EnterpriseCode = src.EnterpriseCode;
                //record.EnterpriseName = src.EnterpriseName;
                record.EnterUpdDivBO1 = src.EnterUpdDivBO1;
                record.EnterUpdDivBO2 = src.EnterUpdDivBO2;
                record.EnterUpdDivBO3 = src.EnterUpdDivBO3;
                record.EnterUpdDivEO = src.EnterUpdDivEO;
                record.EnterUpdDivMaker = src.EnterUpdDivMaker;
                record.EnterUpdDivSec = src.EnterUpdDivSec;
                record.EOAlwcCount = src.EOAlwcCount;
                record.FileHeaderGuid = src.FileHeaderGuid;
                record.FollowDeliGoodsDiv = src.FollowDeliGoodsDiv;
                record.FollowDeliGoodsDivNm = src.FollowDeliGoodsDivNm;
                record.GoodsMakerCd = src.GoodsMakerCd;
                record.GoodsName = src.GoodsName;
                record.GoodsNo = src.GoodsNo;
                record.GoodsNoNoneHyphen = src.GoodsNoNoneHyphen;
                record.HeadErrorMassage = src.HeadErrorMassage;
                record.InputDay = src.InputDay;
                //record.InputDayAdFormal = src.InputDayAdFormal;
                //record.InputDayAdInFormal = src.InputDayAdInFormal;
                //record.InputDayJpFormal = src.InputDayJpFormal;
                //record.InputDayJpInFormal = src.InputDayJpInFormal;
                record.ItemCode = src.ItemCode;
                record.LineErrorMassage = src.LineErrorMassage;
                record.ListPrice = src.ListPrice;
                record.LogicalDeleteCode = src.LogicalDeleteCode;
                record.MakerFollowCnt = src.MakerFollowCnt;
                record.MakerName = src.MakerName;
                record.MazdaUOESectCd1 = src.MazdaUOESectCd1;
                record.MazdaUOESectCd2 = src.MazdaUOESectCd2;
                record.MazdaUOESectCd3 = src.MazdaUOESectCd3;
                record.MazdaUOESectCd4 = src.MazdaUOESectCd4;
                record.MazdaUOESectCd5 = src.MazdaUOESectCd5;
                record.MazdaUOESectCd6 = src.MazdaUOESectCd6;
                record.MazdaUOESectCd7 = src.MazdaUOESectCd7;
                record.MazdaUOEShipSectCd1 = src.MazdaUOEShipSectCd1;
                record.MazdaUOEShipSectCd2 = src.MazdaUOEShipSectCd2;
                record.MazdaUOEShipSectCd3 = src.MazdaUOEShipSectCd3;
                record.MazdaUOEStockCnt1 = src.MazdaUOEStockCnt1;
                record.MazdaUOEStockCnt2 = src.MazdaUOEStockCnt2;
                record.MazdaUOEStockCnt3 = src.MazdaUOEStockCnt3;
                record.MazdaUOEStockCnt4 = src.MazdaUOEStockCnt4;
                record.MazdaUOEStockCnt5 = src.MazdaUOEStockCnt5;
                record.MazdaUOEStockCnt6 = src.MazdaUOEStockCnt6;
                record.MazdaUOEStockCnt7 = src.MazdaUOEStockCnt7;
                record.NonShipmentCnt = src.NonShipmentCnt;
                record.OnlineNo = src.OnlineNo;
                record.OnlineRowNo = src.OnlineRowNo;
                record.PartsLayerCd = src.PartsLayerCd;
                record.ReceiveDate = src.ReceiveDate;
                //record.ReceiveDateAdFormal = src.ReceiveDateAdFormal;
                //record.ReceiveDateAdInFormal = src.ReceiveDateAdInFormal;
                //record.ReceiveDateJpFormal = src.ReceiveDateJpFormal;
                //record.ReceiveDateJpInFormal = src.ReceiveDateJpInFormal;
                record.ReceiveTime = src.ReceiveTime;
                record.SalesDate = src.SalesDate;
                //record.SalesDateAdFormal = src.SalesDateAdFormal;
                //record.SalesDateAdInFormal = src.SalesDateAdInFormal;
                //record.SalesDateJpFormal = src.SalesDateJpFormal;
                //record.SalesDateJpInFormal = src.SalesDateJpInFormal;
                record.SalesSlipDtlNum = src.SalesSlipDtlNum;
                record.SalesSlipNum = src.SalesSlipNum;
                record.SalesUnitCost = src.SalesUnitCost;
                record.SectionCode = src.SectionCode;
                record.SendTerminalNo = src.SendTerminalNo;
                record.SourceShipment = src.SourceShipment;
                record.StockSlipDtlNum = src.StockSlipDtlNum;
                record.SubSectionCode = src.SubSectionCode;
                record.SubstPartsNo = src.SubstPartsNo;
                record.SupplierCd = src.SupplierCd;
                record.SupplierFormal = src.SupplierFormal;
                record.SupplierSlipNo = src.SupplierSlipNo;
                record.SupplierSnm = src.SupplierSnm;
                record.SystemDivCd = src.SystemDivCd;
                record.UOECheckCode = src.UOECheckCode;
                record.UOEDeliGoodsDiv = src.UOEDeliGoodsDiv;
                record.UOEDistributionCd = src.UOEDistributionCd;
                record.UOEHMCd = src.UOEHMCd;
                record.UOEKind = src.UOEKind;
                record.UOEMarkCode = src.UOEMarkCode;
                record.UOEOtherCd = src.UOEOtherCd;
                record.UoeRemark1 = src.UoeRemark1;
                record.UoeRemark2 = src.UoeRemark2;
                record.UOEResvdSection = src.UOEResvdSection;
                record.UOEResvdSectionNm = src.UOEResvdSectionNm;
                record.UOESalesOrderNo = src.UOESalesOrderNo;
                record.UOESalesOrderRowNo = src.UOESalesOrderRowNo;
                record.UOESectionSlipNo = src.UOESectionSlipNo;
                record.UOESectOutGoodsCnt = src.UOESectOutGoodsCnt;
                record.UOESectStockCnt = src.UOESectStockCnt;
                record.UOEStockMark = src.UOEStockMark;
                record.UOESubstMark = src.UOESubstMark;
                record.UOESupplierCd = src.UOESupplierCd;
                record.UOESupplierName = src.UOESupplierName;
                record.UpdAssemblyId1 = src.UpdAssemblyId1;
                record.UpdAssemblyId2 = src.UpdAssemblyId2;
                record.UpdateDateTime = src.UpdateDateTime;
                //record.UpdateDateTimeAdFormal = src.UpdateDateTimeAdFormal;
                //record.UpdateDateTimeAdInFormal = src.UpdateDateTimeAdInFormal;
                //record.UpdateDateTimeJpFormal = src.UpdateDateTimeJpFormal;
                //record.UpdateDateTimeJpInFormal = src.UpdateDateTimeJpInFormal;
                record.UpdEmployeeCode = src.UpdEmployeeCode;
                //record.UpdEmployeeName = src.UpdEmployeeName;
                record.WarehouseCode = src.WarehouseCode;
                record.WarehouseName = src.WarehouseName;
                record.WarehouseShelfNo = src.WarehouseShelfNo;

                #endregion  // <�����o�t�B�[���h���R�s�[/>
            }
            return record;
        }

        #endregion  // <����MJNL/>

        #region <�P�Ƃō݌ɒ����f�[�^�����������R�[�h/>

        /// <summary>�݌ɒ����f�[�^�A�݌ɒ������׃f�[�^�������ރp�����[�^</summary>
        private CustomSerializeArrayList _stockAdjustDBParamList;
        /// <summary>
        /// �݌ɒ����f�[�^�A�݌ɒ������׃f�[�^�������ރp�����[�^���擾���܂��B
        /// </summary>
        public CustomSerializeArrayList StockAdjustDBParamList
        {
            get { return _stockAdjustDBParamList; }
        }

        #endregion  // <�P�Ƃō݌ɒ����f�[�^�����������R�[�h/>
    }
}
