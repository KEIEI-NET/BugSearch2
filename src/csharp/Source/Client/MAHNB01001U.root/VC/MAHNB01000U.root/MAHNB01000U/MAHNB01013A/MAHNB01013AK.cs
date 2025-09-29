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
    /// </remarks>
    public class DelphiSalesSlipInputInitDataNinthAcs
    {
        # region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private DelphiSalesSlipInputInitDataNinthAcs()
        {
        }

        /// <summary>
        /// ������͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        public static DelphiSalesSlipInputInitDataNinthAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataNinthAcs == null)
            {
                _delphiSalesSlipInputInitDataNinthAcs = new DelphiSalesSlipInputInitDataNinthAcs();
            }
            return _delphiSalesSlipInputInitDataNinthAcs;
        }
        # endregion

        #region ���v���C�x�[�g�ϐ�
        private static DelphiSalesSlipInputInitDataNinthAcs _delphiSalesSlipInputInitDataNinthAcs;
        private List<SalesProcMoney> _salesProcMoneyList = null;
        private List<StockProcMoney> _stockProcMoneyList = null;
        private List<RateProtyMng> _rateProtyMngList = null; // ADD 2010/03/01
        #endregion

        #region ���f���Q�[�g
        /// <summary>������z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheSalesProcMoneyListEventHandler(List<SalesProcMoney> salesProcMoneyList);
        /// <summary>�d�����z�����敪�ݒ�L���b�V���f���Q�[�g</summary>
        public delegate void CacheStockProcMoneyListEventHandler(List<StockProcMoney> stockProcMoneyList);
        #endregion

        #region ���C�x���g
        /// <summary>������z�����敪�ݒ�L���b�V���C�x���g</summary>
        public event CacheSalesProcMoneyListEventHandler CacheSalesProcMoneyList;
        /// <summary>�d�����z�����敪�ݒ�Z�b�g�C�x���g</summary>
        public event CacheStockProcMoneyListEventHandler CacheStockProcMoneyList;
        #endregion

        #region ���p�u���b�N�ϐ�
        /// <summary>���[�J��DB�ǂݍ��ݔ���</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#else
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#endif
        # endregion

        # region ���p�u���b�N���\�b�h
        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataNinth(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;

            #region ��������z�����敪�ݒ�}�X�^ DCHMB09112A
            SalesProcMoneyAcs salesProcMoneyAcs = new SalesProcMoneyAcs();
            salesProcMoneyAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = salesProcMoneyAcs.Search(out aList, enterpriseCode);
            this._salesProcMoneyList = new List<SalesProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._salesProcMoneyList = new List<SalesProcMoney>((SalesProcMoney[])aList.ToArray(typeof(SalesProcMoney)));
            }
            this.CacheSalesProcMoneyListCall();
            #endregion

            #region ���d�����z�����敪�ݒ�}�X�^ DCKON09102A
            StockProcMoneyAcs stockProcMoneyAcs = new StockProcMoneyAcs();
            status = stockProcMoneyAcs.Search(out aList, enterpriseCode);
            this._stockProcMoneyList = new List<StockProcMoney>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._stockProcMoneyList = new List<StockProcMoney>((StockProcMoney[])aList.ToArray(typeof(StockProcMoney)));
            }
            this.CacheStockProcMoneyListCall();
            #endregion

            return 0;
        }
        #endregion

        # region ��������z�����敪�ݒ�}�X�^���䏈��
        /// <summary>
        /// ������z�����敪�ݒ�L���b�V���f���Q�[�g �R�[������
        /// </summary>
        public void CacheSalesProcMoneyListCall()
        {
            if (this.CacheSalesProcMoneyList != null) this.CacheSalesProcMoneyList(this._salesProcMoneyList);
        }
        # endregion

        # region ���d�����z�����敪�ݒ�}�X�^���䏈��
        /// <summary>
        /// �d�����z�����敪�ݒ�L���b�V���f���Q�[�g �R�[������
        /// </summary>
        public void CacheStockProcMoneyListCall()
        {
            if (this.CacheStockProcMoneyList != null) this.CacheStockProcMoneyList(this._stockProcMoneyList);
        }
        # endregion

        public List<SalesProcMoney> GetSalesProcMoneyList()
        {
            return this._salesProcMoneyList;
        }
        public List<StockProcMoney> GetStockProcMoneyList()
        {
            return this._stockProcMoneyList;
        }
    }
}
