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
    /// <br>Update Note: 2012/12/19 �� �B</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00</br>
    /// <br>             MAHNB01001U.Log�����݂���ꍇ���O���o�͂���悤�ɕύX</br>
    /// </remarks>
    public class DelphiSalesSlipInputInitDataFourthAcs
    {
        # region ���R���X�g���N�^
        /// <summary>
        /// �f�t�H���g�R���X�g���N�^�iSingleton�f�U�C���p�^�[�����̗p���Ă���ׁAprivate�Ƃ���j
        /// </summary>
        private DelphiSalesSlipInputInitDataFourthAcs()
        {
        }

        /// <summary>
        /// ������͗p�����l�擾�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        public static DelphiSalesSlipInputInitDataFourthAcs GetInstance()
        {
            if (_delphiSalesSlipInputInitDataFourthAcs == null)
            {
                _delphiSalesSlipInputInitDataFourthAcs = new DelphiSalesSlipInputInitDataFourthAcs();
            }
            return _delphiSalesSlipInputInitDataFourthAcs;
        }
        # endregion

        #region ���v���C�x�[�g�ϐ�
        private static DelphiSalesSlipInputInitDataFourthAcs _delphiSalesSlipInputInitDataFourthAcs;

        private List<RateProtyMng> _rateProtyMngList = null;
        private List<Warehouse> _warehouseList = null;         // �q�ɃR�[�h�}�X�^���X�g
        private List<SlipPrtSet> _slipPrtSetList = null;       // �`�[����ݒ�}�X�^���X�g
        private List<CustSlipMng> _custSlipMngList = null;     // ���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g


        #endregion

        #region ���p�u���b�N�ϐ�
        /// <summary>���[�J��DB�ǂݍ��ݔ���</summary>
#if DEBUG
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#else
        public static readonly bool ctIsLocalDBRead = false; // true:���[�J���Q�� false:�T�[�o�[�Q��
#endif
        private List<UOEGuideName> _uoeGuideNameList = null;   // �t�n�d�K�C�h���̃}�X�^���X�g

        private UOESetting _uoeSetting = null;                 // UOE���Ѓ}�X�^

        /// <summary>�|���D��Ǘ��}�X�^�L���b�V���f���Q�[�g</summary>
        public delegate void CacheRateProtyMngListEventHandler(List<RateProtyMng> rateProtyMngList);

        # endregion

        /// <summary>�|���D��Ǘ��}�X�^�Z�b�g�C�x���g</summary>
        public event CacheRateProtyMngListEventHandler CacheRateProtyMngList;

        # region ���p�u���b�N���\�b�h
        /// <summary>
        /// ������͂Ŏg�p���鏉���f�[�^���c�a���擾���܂��B
        /// </summary>
        /// <param name="enterpriseCode"></param>
        /// <param name="sectionCode"></param>
        /// <returns></returns>
        public int ReadInitDataFourth(string enterpriseCode, string sectionCode)
        {
            ArrayList aList;
            int status = (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            string retMessage;

            #region ���t�n�d�K�C�h���̃}�X�^ PMUOE09032A
            LogWrite("�Q UOE�K�C�h���̃}�X�^���X�g���擾");
            UOEGuideName uOEGuideName = new UOEGuideName();
            uOEGuideName.EnterpriseCode = enterpriseCode;
            uOEGuideName.SectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;
            UOEGuideNameAcs uOEGuideNameAcs = new UOEGuideNameAcs();
            status = uOEGuideNameAcs.Search(out aList, uOEGuideName);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._uoeGuideNameList = new List<UOEGuideName>((UOEGuideName[])aList.ToArray(typeof(UOEGuideName)));
            }
            #endregion

            #region ���t�n�d���Ѓ}�X�^ PMUOE09042A
            LogWrite("�Q UOE���Ѓ}�X�^���擾");
            UOESettingAcs uoeSettingAcs = new UOESettingAcs();
            uoeSettingAcs.Read(out this._uoeSetting, enterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            #endregion

            #region ���q�ɏ��擾 MAKHN09332A
            LogWrite("�Q �q�ɏ����擾");
            WarehouseAcs warehouseAcs = new WarehouseAcs();
            warehouseAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = warehouseAcs.Search(out aList, enterpriseCode, sectionCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._warehouseList = new List<Warehouse>((Warehouse[])aList.ToArray(typeof(Warehouse)));
            }
            #endregion


            #region ���|���D��Ǘ��}�X�^ DCKHN09102A
            LogWrite("�|���D��Ǘ��}�X�^���擾");
            RateProtyMngAcs rateProtyMngAcs = new RateProtyMngAcs();
            int retTotalCnt;
            bool nextDat;
            status = rateProtyMngAcs.Search(out aList, out retTotalCnt, out nextDat, enterpriseCode, string.Empty, out retMessage);
            this._rateProtyMngList = new List<RateProtyMng>();
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._rateProtyMngList = new List<RateProtyMng>((RateProtyMng[])aList.ToArray(typeof(RateProtyMng)));
            }
            this.CacheRateProtyMngListCall();
            #endregion

            #region ���`�[����ݒ�}�X�^ SFURI09022A
            LogWrite("�Q �`�[����ݒ�}�X�^���X�g���擾");
            SlipPrtSetAcs slipPrtSetAcs = new SlipPrtSetAcs();
            slipPrtSetAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = slipPrtSetAcs.SearchSlipPrtSet(out aList, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                if (aList != null) this._slipPrtSetList = new List<SlipPrtSet>((SlipPrtSet[])aList.ToArray(typeof(SlipPrtSet)));
            }
            #endregion

            #region �����Ӑ�}�X�^�i�`�[�Ǘ��j SFURI09022A
            LogWrite("�Q ���Ӑ�}�X�^�i�`�[�Ǘ��j���X�g���擾");
            int count = 0;
            CustSlipMngAcs custSlipMngAcs = new CustSlipMngAcs();
            custSlipMngAcs.IsLocalDBRead = ctIsLocalDBRead;
            status = custSlipMngAcs.SearchOnlyCustSlipMng(out count, enterpriseCode);
            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                this._custSlipMngList = new List<CustSlipMng>((CustSlipMng[])custSlipMngAcs.CustSlipMngList.ToArray(typeof(CustSlipMng)));
            }
            #endregion

            return 0;
        }
        #endregion


        public List<Warehouse> GetWarehouseList()
        {
            return this._warehouseList;
        }
        public List<SlipPrtSet> GetSlipPrtSetList()
        {
            return this._slipPrtSetList;
        }
        public List<CustSlipMng> GetCustSlipMngList()
        {
            return this._custSlipMngList;
        }
                /// <summary>
        /// �|���D��Ǘ��}�X�^�L���b�V���f���Q�[�g �R�[������
        /// </summary>
        public void CacheRateProtyMngListCall()
        {
            if (this.CacheRateProtyMngList != null) this.CacheRateProtyMngList(this._rateProtyMngList);
        }

        public List<RateProtyMng> GetRateProtyMngList()
        {
            return this._rateProtyMngList;
        }


        public List<UOEGuideName> GetUoeGuideNameList()
        {
            return this._uoeGuideNameList;
        }
        public UOESetting GetUoeSetting()
        {
            return this._uoeSetting;
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
