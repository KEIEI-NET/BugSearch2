using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;
using System.IO;
using System.Windows.Forms;

using Broadleaf.Application.UIData;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ����`�[����(Delphi)�����l�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ����`�[����(Delphi)�̏����l�擾�f�[�^������s���܂��B</br>
    /// <br>Programmer : LDNS</br>
    /// <br>Date       : 2010/05/29</br>
    /// <br></br>
    /// <br>Update Note : 2010/05/30 20056 ���n ��� </br>
    /// <br>              ���ʕ�����(�U�����ǁ{�V�����ǁ{���R�����{SCM)</br>
    /// <br>Update Note : 2010/07/29 20056 ���n ��� </br>
    /// <br>              �\���敪�}�X�^������^�C�~���O�Ɏ擾�ł��Ȃ����̑Ή�(�����擾�}�X�^�ŏI���Ƀ��X�g��null�̏ꍇ�A�Ď擾����)</br>
    /// <br>Update Note : 2012/02/07 2012/03/28�z�M���@#28284 liusy</br>
    /// <br>              �N�����̃}�X�^�擾�������ɓ��Ӑ�|���O���[�v�̎擾������ǉ�����</br>
    /// <br>Update Note : 2012/12/19 �� �B</br>
    /// <br>�Ǘ��ԍ�    : 10801804-00</br>
    /// <br>              MAHNB01001U.Log�����݂���ꍇ���O���o�͂���悤�ɕύX</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataAcs
    {
        # region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private DelphiSalesSlipInputInitDataAcs()
        {
        }

        /// <summary>
        /// ������͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        public static DelphiSalesSlipInputInitDataAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataAcs == null)
            {
                _delphiSalesSlipInputInitDataAcs = new DelphiSalesSlipInputInitDataAcs();
            }
            return _delphiSalesSlipInputInitDataAcs;
        }
        # endregion

        #region ���v���C�x�[�g�ϐ�
        private static DelphiSalesSlipInputInitDataAcs _delphiSalesSlipInputInitDataAcs;
        private GoodsAcs _goodsAcs;

        private List<RateProtyMng> _rateProtyMngList = null;
        private List<SubSection> _subSectionList = null;       // ����}�X�^���X�g
        private List<MakerUMnt> _makerUMntList = null;         // ���[�J�[�}�X�^���X�g
        private List<BLGoodsCdUMnt> _blGoodsCdUMntList = null; // �a�k�R�[�h�}�X�^���X�g
        private PosTerminalMg _posTerminalMg = null;
        private ArrayList _allCustRateGroupList = null;        // ���Ӑ�}�X�^�S�����X�g
        private IWin32Window _owner = null;
        private List<TbsPartsCodeWork> _tbsPartsCodeList = null; // �񋟂a�k�R�[�h�}�X�^���X�g // 2010/05/30
        private List<PriceSelectSet> _displayDivList = null;              // �\���敪���X�g // 2010/07/29

        #endregion

        #region ���p�u���b�N�ϐ�
        /// <summary>���[�J��DB�ǂݍ��ݔ���</summary>
        /// <br>Update Note: 2009/09/08 ���M ���q�Ǘ��@�\�Ή�</br>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#else
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#endif
        #endregion

        #region ���f���Q�[�g
        /// <summary>������z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheSalesProcMoneyListEventHandler(List<SalesProcMoney> salesProcMoneyList);
        /// <summary>�d�����z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheStockProcMoneyListEventHandler(List<StockProcMoney> stockProcMoneyList);
        // --- ADD 2010/03/01 ---------->>>>>
        /// <summary>�|���D��Ǘ��}�X�^�L���b�V���f���Q�[�g</summary>
        public delegate void CacheRateProtyMngListEventHandler(List<RateProtyMng> rateProtyMngList);
        // --- ADD 2010/03/01 ----------<<<<<
        #endregion

        #region ���C�x���g
        /// <summary>������z�����敪�ݒ�L���b�V���C�x���g</summary>
        public event CacheSalesProcMoneyListEventHandler CacheSalesProcMoneyList;
        /// <summary>�d�����z�����敪�ݒ�Z�b�g�C�x���g</summary>
        public event CacheStockProcMoneyListEventHandler CacheStockProcMoneyList;
        /// <summary>�|���D��Ǘ��}�X�^�Z�b�g�C�x���g</summary>
        public event CacheRateProtyMngListEventHandler CacheRateProtyMngList;
        #endregion

        # region ���p�u���b�N���\�b�h
        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <returns>STATUS</returns>
        /// <br>Update Note: 2009/10/19 ���M �ێ�˗��A�@�\�Ή�</br>
        /// <br>Update Note : 2010/03/01 ����� PM.NS�ێ�˗��T�����ǑΉ�</br>
        /// <br>             �P�����W���[���̊|���D��Ǘ��}�X�^�L���b�V���������g�p����悤�ɕύX</br>
        /// <br>Update Note : 2012/02/07 liusy</br>
        /// <br>             �N�����̃}�X�^�擾�������ɓ��Ӑ�|���O���[�v�̎擾������ǉ�����</br>
        public int ReadInitData(string enterpriseCode, string sectionCode)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region �����i�A�N�Z�X�N���X��������(�L���b�V���Ȃ�)
            LogWrite("�P���i�A�N�Z�X�N���X��������");
            string retMessage;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = ctIsLocalDBRead;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);
            #endregion

            //>>>2010/05/30
            #region ���񋟂a�k�R�[�h���X�g
            this._tbsPartsCodeList = this._goodsAcs.OfrBLList;
            LogWrite("�����������񋟂a�k�R�[�h���X�g�����F" + this._tbsPartsCodeList.Count.ToString());
            #endregion
            //<<<2010/05/30

            #region �����[�J�[�}�X�^
            LogWrite("�P���[�J�[���X�g���擾");
            List<MakerUMnt> makerList;
            status = this._goodsAcs.GetAllMaker(enterpriseCode, out makerList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (makerList != null) this._makerUMntList = makerList;
            }
            #endregion

            #region ���a�k�R�[�h���X�g
            LogWrite("�PBL�R�[�h���X�g���擾");
            List<BLGoodsCdUMnt> blGoodsList;
            status = this._goodsAcs.GetAllBLGoodsCd(enterpriseCode, out blGoodsList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (blGoodsList != null) this._blGoodsCdUMntList = blGoodsList;
            }
            #endregion

            //>>>2010/07/29
            #region ���\���敪�}�X�^ PMHNB09003A
            ArrayList aList = new ArrayList();
            LogWrite("�\���敪�}�X�^���擾");
            PriceSelectSetAcs priceSelectSetAcs = new PriceSelectSetAcs();
            status = priceSelectSetAcs.Search(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._displayDivList = new List<PriceSelectSet>((PriceSelectSet[])aList.ToArray(typeof(PriceSelectSet))); ;
            }
            else
            {
                this._displayDivList = new List<PriceSelectSet>();
            }
            #endregion
            //<<<2010/07/29

            //add by liusy #28284 2012/02/07 ---->>>>>
            // ���Ӑ�|���O���[�v�ăZ�b�g
            CustRateGroupAcs custRateGroupAcs = new CustRateGroupAcs();
            ArrayList custRateGroupList;
            LogWrite("���Ӑ�|���O���[�v���擾");
            status = custRateGroupAcs.Search(out custRateGroupList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._allCustRateGroupList = custRateGroupList;
            }
            else
            {
                this._allCustRateGroupList = new ArrayList();
            }
            //add by liusy #28284 2012/02/07 ----<<<<<
            return 0;
        }

        #region ��DEBUG���O�o��
        /// <summary>
        /// ���O�o��(DEBUG)����
        /// </summary>
        /// <param name="pMsg"></param>
        public static void LogWrite(string pMsg)
        {
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#if DEBUG
            if (SalesSlipInputInitDataAcs._Log_Check == 0)
            {
                if (System.IO.File.Exists("MAHNB01001U.Log"))
                {
                    SalesSlipInputInitDataAcs._Log_Check = 1;
                }
                else
                {
                    SalesSlipInputInitDataAcs._Log_Check = 2;
                }

            }

            if (SalesSlipInputInitDataAcs._Log_Check == 1)
            {
            // --- UPD T.Nishi 2012/12/19 ----------<<<<<
            System.IO.FileStream _fs;										// �t�@�C���X�g���[��
            System.IO.StreamWriter _sw;										// �X�g���[��writer
            _fs = new FileStream("MAHNB01001U.Log", FileMode.Append, FileAccess.Write, FileShare.Write);
            _sw = new System.IO.StreamWriter(_fs, System.Text.Encoding.GetEncoding("shift_jis"));
            DateTime edt = DateTime.Now;
            //yyyy/MM/dd hh:mm:ss
            _sw.WriteLine(string.Format("{0,-19} {1,-5} ==> {2}", edt, edt.Millisecond, pMsg));
            if (_sw != null)
                _sw.Close();
            if (_fs != null)
                _fs.Close();
            // --- UPD T.Nishi 2012/12/19 ---------->>>>>
            //#endif
        }
        // --- UPD T.Nishi 2012/12/19 ----------<<<<<
    }

        #endregion

        //���[�J�[�}�X�^
        public List<MakerUMnt> GetMakerUMntList()
        {
            return this._makerUMntList;
        }
        //�a�k�R�[�h���X�g
        public List<BLGoodsCdUMnt> GetBlGoodsCdUMntList()
        {
            return this._blGoodsCdUMntList;
        }
        public GoodsAcs GetGoodsAcs()
        {
            return this._goodsAcs;
        }

        //>>>2010/05/30
        // ��BL�R�[�h���X�g
        public List<TbsPartsCodeWork> GetTbsPartsCodeList()
        {
            return this._tbsPartsCodeList;
        }
        //<<<2010/05/30

        //>>>2010/07/29
        public List<PriceSelectSet> GetDisplayDivList()
        {
            return this._displayDivList;
        }
        //<<<2010/07/29

        //add by liusy 2012/02/07 #28284 ----->>>>>
        public ArrayList GetCustRateGroupList()
        {
            return this._allCustRateGroupList;
        }
        //add by liusy 2012/02/07 #28284 -----<<<<<
        
        # endregion

    }
}
