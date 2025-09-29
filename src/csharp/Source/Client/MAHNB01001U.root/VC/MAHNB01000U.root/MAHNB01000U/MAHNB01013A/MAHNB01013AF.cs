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
    /// ������͗p�����l�擾�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ������͂̏����l�擾�f�[�^������s���܂��B</br>
    /// <br>Update Note : 2010/05/30 20056 ���n ��� </br>
    /// <br>              ���ʕ�����(�U�����ǁ{�V�����ǁ{���R�����{SCM)</br>
    /// <br>Update Note: 2012/12/19 �� �B</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             MAHNB01001U.Log�����݂���ꍇ���O���o�͂���悤�ɕύX</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataFifthAcs
    {
        # region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private DelphiSalesSlipInputInitDataFifthAcs()
        {
        }

        /// <summary>
        /// ������͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        public static DelphiSalesSlipInputInitDataFifthAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataFifthAcs == null)
            {
                _delphiSalesSlipInputInitDataFifthAcs = new DelphiSalesSlipInputInitDataFifthAcs();
            }
            return _delphiSalesSlipInputInitDataFifthAcs;
        }
        # endregion

        #region ���v���C�x�[�g�ϐ�
        private static DelphiSalesSlipInputInitDataFifthAcs _delphiSalesSlipInputInitDataFifthAcs;

        private List<MakerUMnt> _makerUMntList = null;         // ���[�J�[�}�X�^���X�g
        private List<BLGoodsCdUMnt> _blGoodsCdUMntList = null; // �a�k�R�[�h�}�X�^���X�g

        //private double _taxRate = 0; // 2010/05/30

        ///// <summary> ���̓��[�h</summary> // 2010/05/30
        //private int _inputMode; // 2010/05/30

        private GoodsAcs _goodsAcs;
        private IWin32Window _owner = null;
        #endregion

        #region ���p�u���b�N�ϐ�
        /// <summary>���[�J��DB�ǂݍ��ݔ���</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#else
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#endif
        # endregion

        #region ���f���Q�[�g
        /// <summary>������z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheSalesProcMoneyListEventHandler(List<SalesProcMoney> salesProcMoneyList);
        /// <summary>�d�����z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheStockProcMoneyListEventHandler(List<StockProcMoney> stockProcMoneyList);
        /// <summary>�|���D��Ǘ��}�X�^�L���b�V���f���Q�[�g</summary>
        public delegate void CacheRateProtyMngListEventHandler(List<RateProtyMng> rateProtyMngList);

        #endregion

        # region ���p�u���b�N���\�b�h
        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataFifth(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region �����i�A�N�Z�X�N���X��������(�L���b�V���Ȃ�)
            LogWrite("�P ���i�A�N�Z�X�N���X��������");
            string retMessage;
            this._goodsAcs = new GoodsAcs();
            this._goodsAcs.IsLocalDBRead = ctIsLocalDBRead;
            this._goodsAcs.Owner = this._owner;
            this._goodsAcs.SearchInitial(enterpriseCode, sectionCode, out retMessage);
            #endregion

            #region �����[�J�[�}�X�^
            LogWrite("�P ���[�J�[���X�g���擾");
            List<MakerUMnt> makerList;
            status = this._goodsAcs.GetAllMaker(enterpriseCode, out makerList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (makerList != null) this._makerUMntList = makerList;
            }
            #endregion

            #region ���a�k�R�[�h���X�g
            LogWrite("�P BL�R�[�h���X�g���擾");
            List<BLGoodsCdUMnt> blGoodsList;
            status = this._goodsAcs.GetAllBLGoodsCd(enterpriseCode, out blGoodsList);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (blGoodsList != null) this._blGoodsCdUMntList = blGoodsList;
            }
            #endregion

            return 0;
        }
        #endregion

        public List<MakerUMnt> GetMakerUMntList()
        {
            return this._makerUMntList;
        }
        public List<BLGoodsCdUMnt> GetBlGoodsCdUMntList()
        {
            return this._blGoodsCdUMntList;
        }
        public GoodsAcs GetGoodsAcs()
        {
            return this._goodsAcs;

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
    }
}
