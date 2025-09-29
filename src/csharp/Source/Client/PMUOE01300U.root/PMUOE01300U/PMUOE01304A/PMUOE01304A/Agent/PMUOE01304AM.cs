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

using System;
using System.Collections.Generic;
using System.Text;

using Broadleaf.Application.Controller.Util;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller.Agent
{
    using LoginWorkerAcs = SingletonPolicy<LoginWorker>;
    using MakerDB = SingletonPolicy<MakerMasterDBAgent>;

    /// <summary>
    /// ���iDB�A�N�Z�X�̑㗝�l�N���X
    /// </summary>
    public sealed class GoodsDBAgent
    {
        #region <�{���̃A�N�Z�T/>

        /// <summary>�{���̃A�N�Z�T</summary>
        private readonly GoodsAcs _realAccesser = new GoodsAcs();
        /// <summary>
        /// �{���̃A�N�Z�T���擾���܂��B
        /// </summary>
        /// <value>�{���̃A�N�Z�T</value>
        private GoodsAcs RealAccesser { get { return _realAccesser; } }

        #endregion  // <�{���̃A�N�Z�T/>

        #region <���i�A���f�[�^��null���X�g/>

        /// <summary>���i�A���f�[�^��null���X�g</summary>
        private readonly List<GoodsUnitData> _nullGoodsUnitDataList;
        /// <summary>
        /// ���i�A���f�[�^��null���X�g���擾���܂��B
        /// </summary>
        /// <value>���i�A���f�[�^��null���X�g</value>
        private List<GoodsUnitData> NullGoodsUnitDataList { get { return _nullGoodsUnitDataList; } }

        #endregion  // <���i�A���f�[�^��null���X�g/>

        #region <�i�Ԍ���/>

        /// <summary>2�Ԗڂ̕i�Ԍ�����</summary>
        private IGoodsFaindable _secondGoodsFinder;
        /// <summary>
        /// 2�Ԗڂ̕i�Ԍ����҂��擾���܂��B
        /// </summary>
        private IGoodsFaindable SecondGoodsFinder
        {
            get
            {
                if (_secondGoodsFinder == null)
                {
                    // ���������������S��v�ŕi�Ԍ���
                    _secondGoodsFinder = new GoodsFinderThatSearchPartsFromGoodsNoNonVariousSearchWholeWord(
                        RealAccesser
                    );
                }
                return _secondGoodsFinder;
            }
        }

        #endregion  // <�i�Ԍ���/>

        #region <Constructor/>

        /// <summary>
        /// �f�t�H���g�R���X�g���N�^
        /// </summary>
        public GoodsDBAgent()
        {
            _nullGoodsUnitDataList = new List<GoodsUnitData>();
            _nullGoodsUnitDataList.Add(null);
        }

        #endregion  // <Constructor/>

        #region <�q��/>

        /// <summary>
        /// ���O�C�����_�̑q�ɃR�[�h(�~3)���A�Y������ŏ��̍݌ɂ��������܂��B
        /// </summary>
        /// <remarks>
        /// �q�ɃR�[�h1�A2�A3 �̏��Ɍ������܂��B
        /// </remarks>
        /// <param name="makerCode">���[�J�[�R�[�h</param>
        /// <param name="goodsNo">�i��</param>
        /// <returns>�Y������݌Ɂi�Y������݌ɂ��Ȃ��ꍇ�A<c>null</c>��Ԃ��܂��B�j</returns>
        public Stock FindFirstStockByLoginWorkers3WarehouseCodes(
            int makerCode,
            string goodsNo
        )
        {
            // ���[�J�[�R�[�h�ƕi�Ԃōi�荞��
            GoodsUnitData goodsUnitData = new GoodsUnitData();
            int status = RealAccesser.Read(
                LoginWorkerAcs.Instance.Policy.SectionProfile.Code.Trim(),
                makerCode,
                goodsNo,
                out goodsUnitData
            );
            if (!status.Equals((int)Result.RemoteStatus.Normal) || goodsUnitData == null)
            {
                goodsUnitData = SecondGoodsFinder.Find(makerCode, goodsNo);
                if (goodsUnitData == null) return null;
            }

            // �q�ɃR�[�h�Ō���
            string[] gettingWarehouseCodes = new string[3] {
                LoginWorkerAcs.Instance.Policy.SectionInfo.SectWarehouseCd1,
                LoginWorkerAcs.Instance.Policy.SectionInfo.SectWarehouseCd2,
                LoginWorkerAcs.Instance.Policy.SectionInfo.SectWarehouseCd3
            };
            foreach (string gettingWarehouseCode in gettingWarehouseCodes)
            {
                Stock stock = RealAccesser.GetStockFromStockList(
                    gettingWarehouseCode,
                    makerCode,
                    goodsNo,
                    goodsUnitData.StockList
                );
                if (stock != null) return stock;
            }

            return null;
        }

        #endregion  // <�q��/>

        #region <���i����/>

        /// <summary>���i�A���f�[�^�̃��X�g�̃}�b�v</summary>
        private readonly IDictionary<string, List<GoodsUnitData>> _goodsUnitDataListMap = new Dictionary<string, List<GoodsUnitData>>();
        /// <summary>
        /// ���i�A���f�[�^�̃��X�g�̃}�b�v���擾���܂��B
        /// </summary>
        /// <value>���i�A���f�[�^�̃��X�g�̃}�b�v</value>
        public IDictionary<string, List<GoodsUnitData>> GoodsUnitDataListMap
        { 
            get { return _goodsUnitDataListMap; }
        }

        /// <summary>
        /// �L�[���擾���܂��B
        /// </summary>
        /// <param name="goodsNo">���i�ԍ�</param>
        /// <param name="uoeSupplier">UOE������</param>
        /// <returns>���i�ԍ� + "-" + ���[�J�[�R�[�h("000000")�~5</returns>
        private static string GetKey(
            string goodsNo,
            UOESupplierHelper uoeSupplier
        )
        {
            StringBuilder key = new StringBuilder();
            {
                key.Append(goodsNo).Append("-");

                List<int> makerCodeList = uoeSupplier.CreateSearchingMakerCodeListForGoodsAcs();
                foreach (int makerCode in makerCodeList)
                {
                    key.Append(makerCode.ToString("000000"));
                }
            }
            return key.ToString();
        }

        /// <summary>
        /// �i�Ԍ������s���܂��B
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <param name="uoeSupplier">UOE������</param>
        /// <returns>���i�A���f�[�^</returns>
        public GoodsUnitData FindFirstGoodsUnitData(
            ReceivedText receivedTelegram,
            UOESupplierHelper uoeSupplier
        )
        {
            string goodsNo = receivedTelegram.ToGoodsNo();

            string key = GetKey(goodsNo, uoeSupplier);
            if (GoodsUnitDataListMap.ContainsKey(key))
            {
                return GoodsUnitDataListMap[key][0];
            }

            // �V���Ɍ���
            GoodsCndtn searchingCondition = new GoodsCndtn();
            {
                searchingCondition.EnterpriseCode   = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code;
                searchingCondition.SectionCode      = LoginWorkerAcs.Instance.Policy.SectionProfile.Code;
                searchingCondition.GoodsNo          = goodsNo;
            }

            List<GoodsUnitData> goodsUnitDataList = null;
            string message = string.Empty;
            int status = RealAccesser.SearchPartsFromGoodsNoNonVariousSearch(
                searchingCondition,
                false,
                uoeSupplier.CreateSearchingMakerCodeListForGoodsAcs(),
                out goodsUnitDataList,
                out message
            );
            if (goodsUnitDataList == null || goodsUnitDataList.Count.Equals(0))
            {
                GoodsUnitDataListMap.Add(key, NullGoodsUnitDataList);
                return null;
            }

            // �������ʂ�ێ�
            GoodsUnitDataListMap.Add(key, goodsUnitDataList);

            return goodsUnitDataList[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="receivedTelegram">��M�d��</param>
        /// <param name="uoeSupplier">UOE������</param>
        /// <returns></returns>
        public GoodsPrice FindFirstGoodsPrice(
            ReceivedText receivedTelegram,
            UOESupplierHelper uoeSupplier
        )
        {
            GoodsUnitData goodsUnitData = FindFirstGoodsUnitData(receivedTelegram, uoeSupplier);
            if (goodsUnitData == null) return null;

            return goodsUnitData.GoodsPriceList[0];
        }

        #endregion  // <���i����/>

        #region <�i�Ԍ���/>

        /// <summary>
        /// �i�Ԍ����C���^�[�t�F�[�X
        /// </summary>
        private interface IGoodsFaindable
        {
            /// <summary>
            /// �i�Ԍ������܂��B
            /// </summary>
            /// <param name="makerCode">���[�J�[�R�[�h</param>
            /// <param name="goodsNo">�i��</param>
            /// <returns>���i���i����0�̏ꍇ�A<c>null</c>��Ԃ��܂��j</returns>
            GoodsUnitData Find(
                int makerCode,
                string goodsNo
            );
        }

        /// <summary>
        /// ���������������S��v�ŕi�Ԍ�������N���X
        /// </summary>
        private sealed class GoodsFinderThatSearchPartsFromGoodsNoNonVariousSearchWholeWord : IGoodsFaindable
        {
            #region <IGoodsFaindable �����o/>

            /// <summary>
            /// ���������������S��v�ŕi�Ԍ������܂��B
            /// </summary>
            /// <param name="makerCode">���[�J�[�R�[�h</param>
            /// <param name="goodsNo">�i��</param>
            /// <returns>���i���i����0�̏ꍇ�A<c>null</c>��Ԃ��܂��j</returns>
            public GoodsUnitData Find(
                int makerCode,
                string goodsNo
            )
            {
                string key = GetKey(makerCode, goodsNo);
                if (GoodsUnitDataMap.ContainsKey(key)) return GoodsUnitDataMap[key];

                if (SearchPartsFromGoodsNoNonVariousSearchWholeWord(
                    CreateGoodsCndtnList(makerCode, goodsNo)
                ).Equals((int)Result.RemoteStatus.Normal))
                {
                    if (GoodsUnitDataMap.ContainsKey(key)) return GoodsUnitDataMap[key];
                }

                return null;
            }

            #endregion  // <IGoodsFaindable �����o/>

            #region <�{���̃A�N�Z�T/>

            /// <summary>�{���̃A�N�Z�T</summary>
            private readonly GoodsAcs _realAccesser;
            /// <summary>
            /// �{���̃A�N�Z�T���擾���܂��B
            /// </summary>
            /// <value>�{���̃A�N�Z�T</value>
            private GoodsAcs RealAccesser { get { return _realAccesser; } }

            #endregion  // <�{���̃A�N�Z�T/>

            #region <���i�A���f�[�^�̃��[�J���L���b�V��/>

            /// <summary>���i�A���f�[�^�}�b�v</summary>
            private readonly IDictionary<string, GoodsUnitData> _goodsUnitDataMap = new Dictionary<string, GoodsUnitData>();
            /// <summary>
            /// ���i�A���f�[�^�}�b�v���擾���܂��B
            /// </summary>
            private IDictionary<string, GoodsUnitData> GoodsUnitDataMap { get { return _goodsUnitDataMap; } }

            #endregion  // <���i�A���f�[�^�̃��[�J���L���b�V��/>

            #region <Constructor/>

            /// <summary>
            /// �J�X�^���R���X�g���N�^
            /// </summary>
            /// <param name="realAccesser">�{���̃A�N�Z�T</param>
            public GoodsFinderThatSearchPartsFromGoodsNoNonVariousSearchWholeWord(GoodsAcs realAccesser)
            {
                _realAccesser = realAccesser;
            }

            #endregion  // <Constructor/>

            #region <�i�Ԍ����i���������������S��v�j/>

            /// <summary>
            /// ���i�A�N�Z�X�N���X�̒��o�������X�g�𐶐����܂��B
            /// </summary>
            /// <param name="makerCode">���[�J�[�R�[�h</param>
            /// <param name="goodsNo">�i��</param>
            /// <returns>���i�A�N�Z�X�N���X�̒��o�������X�g</returns>
            private static List<GoodsCndtn> CreateGoodsCndtnList(
                int makerCode,
                string goodsNo
            )
            {
                List<GoodsCndtn> goodsCndtnList = new List<GoodsCndtn>();
                {
                    GoodsCndtn goodsCndtn = new GoodsCndtn();
                    {
                        goodsCndtn.EnterpriseCode   = LoginWorkerAcs.Instance.Policy.EnterpriseProfile.Code.Trim();
                        goodsCndtn.SectionCode      = LoginWorkerAcs.Instance.Policy.SectionProfile.Code.Trim();

                        MakerSet foundMaker = MakerDB.Instance.Policy.Find(makerCode);
                        if (foundMaker != null)
                        {
                            goodsCndtn.MakerName = foundMaker.MakerName;
                        }
                        goodsCndtn.GoodsNoSrchTyp   = 0;
                        goodsCndtn.GoodsMakerCd     = makerCode;
                        goodsCndtn.GoodsNo          = goodsNo;
                        goodsCndtn.JoinSearchDiv    = (int)GoodsCndtn.JoinSearchDivType.NoSearch;
                    }
                    goodsCndtnList.Add(goodsCndtn);
                }
                return goodsCndtnList;
            }

            /// <summary>
            /// ���������������S��v�ŕi�Ԍ������܂��B
            /// </summary>
            /// <remarks>
            /// �ڐA���FDCHAT02105AA.cs::OrderListAcs.GoodsRead()
            /// </remarks>
            /// <param name="goodsCndtnList">���i���o�����N���X���X�g</param>
            /// <returns>���ʃR�[�h</returns>
            private int SearchPartsFromGoodsNoNonVariousSearchWholeWord(List<GoodsCndtn> goodsCndtnList)
            {
                // ���������������S��v�ŏ��i�����擾
                List<List<GoodsUnitData>> goodsUnitDataListList = null; // 2�p����
                string message = string.Empty;                          // 3�p����
                int status = RealAccesser.SearchPartsFromGoodsNoNonVariousSearchWholeWord(
                    goodsCndtnList,
                    out goodsUnitDataListList,
                    out message
                );
                if ((goodsUnitDataListList != null) && (goodsUnitDataListList.Count > 0))
                {
                    for (int i = 0; i < goodsUnitDataListList.Count; i++)
                    {
                        List<GoodsUnitData> goodsUnitDataList = goodsUnitDataListList[i];
                        
                        for (int j = 0; j < goodsUnitDataList.Count; j++)
                        {
                            GoodsUnitData goodsUnitData = goodsUnitDataList[j];
                            string key = CreateKeyForGoodsUnitDataMap(goodsUnitData);
                            if (GoodsUnitDataMap.ContainsKey(key))
                            {
                                // ���ꏤ�i�����݂��Ă���ꍇ�͍폜
                                GoodsUnitDataMap.Remove(key);
                            }
                            GoodsUnitDataMap.Add(key, goodsUnitData);
                        }
                    }
                }

                return status;
            }

            /// <summary>
            /// ���i�A���f�[�^�̃��[�J���L���b�V���p�L�[���쐬���܂��B
            /// </summary>
            /// <remarks>
            /// �ڐA���FDCHAT02105AA.cs::OrderListAcs.CreateKey_GoodsUnitData()
            /// </remarks>
            /// <param name="goodsUnitData">���i�A���f�[�^</param>
            /// <returns>���[�J�[�R�[�h(0000) + "-" + �i��</returns>
            private static string CreateKeyForGoodsUnitDataMap(GoodsUnitData goodsUnitData)
            {
                return GetKey(goodsUnitData.GoodsMakerCd, goodsUnitData.GoodsNo);
            }

            /// <summary>
            /// ���i�A���f�[�^�̃��[�J���L���b�V���p�L�[���쐬���܂��B
            /// </summary>
            /// <param name="goodsMakerCode">���[�J�[�R�[�h</param>
            /// <param name="goodsNo">�i��</param>
            /// <returns>���[�J�[�R�[�h(0000) + "-" + �i��</returns>
            private static string GetKey(
                int goodsMakerCode,
                string goodsNo
            )
            {
                // ���[�J�[�R�[�h + �i��
                return goodsMakerCode.ToString("d04") + "-" + goodsNo;
            }

            #endregion  // <�i�Ԍ����i���������������S��v�j/>
        }

        #endregion  // <�i�Ԍ���/>
    }
}
