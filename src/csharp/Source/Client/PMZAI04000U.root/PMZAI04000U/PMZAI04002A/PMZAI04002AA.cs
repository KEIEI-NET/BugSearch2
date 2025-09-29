# region ��using
using System;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Collections;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Application.Resources;
# endregion

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �`�[���� �e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note         : �`�[�������s���܂��B</br>
    /// <br>Programmer   : 22018  ��� ���b</br>
    /// <br>Date         : 2008.09.01</br>
    /// <br>Update Note  : 2009/02/16 30414 �E �K�j ��QID:10825,11543�Ή�</br>
    /// <br>             : 2009/04/03       �Ɠc �M�u�@�s��Ή�[12857]</br>
    /// </remarks>
    public class StockAdjRefAcs
    {
        # region ��Private Member
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IStockAdjRefSearchDB _iStockAdjRefSearchDB = null;
        

        /// <summary>���_�I�v�V�����t���O</summary>
        private bool _optSection;
		// ���_�A�N�Z�X�N���X
        private static SecInfoAcs _secInfoAcs;													
        private StockAdjDataSet _dataSet;
        
        private static StockAdjDataSet.StockAdjustDataTable _stockSlipCache;
        private static StockAdjRefSearchParaWork _paraStockSlipCache;

        private static SortedList _nameList;
        private static StockAdjRefAcs _searchSlipAcs;

        private AdjustStockAcs _adjustStockAcs;

        private string _enterpriseCode;             // ��ƃR�[�h

        private const string MESSAGE_NoResult = "���������Ɉ�v����`�[�͑��݂��܂���B";
        private const string MESSAGE_ErrResult = "�`�[���̎擾�Ɏ��s���܂����B";
        private const string MESSAGE_NONOWNSECTION = "�����_��񂪎擾�ł��܂���ł����B���_�ݒ���s���Ă���N�����Ă��������B";
		private const string ct_DateFormat = "yyyy/MM/dd";

        // �󕥌��`�[�敪���̃f�B�N�V���i��
        private Dictionary<int, string> _acPaySlipCdNmDic;
        // �󕥌�����敪���̃f�B�N�V���i��
        private Dictionary<int, string> _acPayTransCdNmDic;

        # endregion

        // �f���Q�[�g����
        public event GetNameListEventHandler GetNameList;
        public delegate SortedList GetNameListEventHandler();

        public event SettingStatusBarMessageEventHandler StatusBarMessageSetting;
        public delegate void SettingStatusBarMessageEventHandler(object sender, string message);

        # region ��Constracter
        /// <summary>
        /// �`�[���� �e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : ���i�啪�ރ}�X�^ �e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public StockAdjRefAcs()
        {
            //�@��ƃR�[�h���擾����
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
            
            // ���_OP�̔���
            this._optSection = ((int)LoginInfoAcquisition.SoftwarePurchasedCheckForCompany(ConstantManagement_SF_PRO.SoftwareCode_OPT_CMN_SECTION) > 0);
            this._dataSet = new StockAdjDataSet();

            this._adjustStockAcs = AdjustStockAcs.GetInstance();

            // ���̃f�B�N�V���i������
            CreateNameDictionary();

            // ���O�C�����i�ŒʐM��Ԃ��m�F
            if (LoginInfoAcquisition.OnlineFlag)
            {
                try
                {
                    // �����[�g�I�u�W�F�N�g�擾
                    this._iStockAdjRefSearchDB = (IStockAdjRefSearchDB)MediationStockAdjRefSearchDB.GetStockAdjRefSearchDB();
                }
                catch (Exception)
                {
                    //�I�t���C������null���Z�b�g
                    this._iStockAdjRefSearchDB = null;
                }
            }
            else
            {
                // �I�t���C�����̃f�[�^�ǂݍ���
                //this.SearchOfflineData();
                MessageBox.Show("�I�t���C����Ԃ̂��ߌ��������s�ł��܂���B");
            }
        }
        /// <summary>
        /// ���̃f�B�N�V���i���̐���
        /// </summary>
        private void CreateNameDictionary()
        {
            // �󕥌��`�[�敪
            _acPaySlipCdNmDic = new Dictionary<int, string>();
            _acPaySlipCdNmDic.Add( 10, "�d��" );
            _acPaySlipCdNmDic.Add( 11, "���" );
            _acPaySlipCdNmDic.Add( 12, "��v��" );
            _acPaySlipCdNmDic.Add( 13, "�݌Ɏd��" );
            _acPaySlipCdNmDic.Add( 20, "����" );
            _acPaySlipCdNmDic.Add( 21, "���v��" );
            _acPaySlipCdNmDic.Add( 22, "�ϑ�" );
            _acPaySlipCdNmDic.Add( 23, "����" );
            _acPaySlipCdNmDic.Add( 30, "�ړ��o��" );
            _acPaySlipCdNmDic.Add( 31, "�ړ�����" );
            _acPaySlipCdNmDic.Add( 40, "����" );
            _acPaySlipCdNmDic.Add( 41, "����" );
            _acPaySlipCdNmDic.Add( 42, "�}�X�^�����e" );
            _acPaySlipCdNmDic.Add( 50, "�I��" );
            // 2009.01.08 add [9639]
            // �݌ɑg���E���������Ȃǂłł��������f�[�^�̋敪��ǉ�
            // 60�F�g���A61�F�����A70�F��[���ɁA71�F��[�o��
            _acPaySlipCdNmDic.Add( 60, "�g��" );
            _acPaySlipCdNmDic.Add( 61, "����" );
            _acPaySlipCdNmDic.Add( 70, "��[����" );
            _acPaySlipCdNmDic.Add( 71, "��[�o��" );
            // 2009.01.08 add [9639]

            // �󕥌�����敪
            _acPayTransCdNmDic = new Dictionary<int, string>();
            _acPayTransCdNmDic.Add( 10, "�ʏ�`�[" );
            _acPayTransCdNmDic.Add( 11, "�ԕi" );
            _acPayTransCdNmDic.Add( 12, "�l��" );
            _acPayTransCdNmDic.Add( 20, "�ԓ`" );
            _acPayTransCdNmDic.Add( 21, "�폜" );
            _acPayTransCdNmDic.Add( 22, "����" );
            _acPayTransCdNmDic.Add( 30, "�݌ɐ�����" );
            _acPayTransCdNmDic.Add( 31, "��������" );
            _acPayTransCdNmDic.Add( 32, "���Ԓ���" );
            _acPayTransCdNmDic.Add( 33, "�s�Ǖi" );
            _acPayTransCdNmDic.Add( 34, "���o" );
            _acPayTransCdNmDic.Add( 35, "����" );
            _acPayTransCdNmDic.Add( 40, "�ߕs���X�V" );
            _acPayTransCdNmDic.Add( 90, "���" );
        }
        # endregion

        /// <summary>
        /// �`�[�����A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�`�[�����A�N�Z�X�N���X �C���X�^���X</returns>
        public static StockAdjRefAcs GetInstance()
        {
            if (_searchSlipAcs == null)
            {
                _searchSlipAcs = new StockAdjRefAcs();
            }

            return _searchSlipAcs;
        }

        /// <summary>
        /// �`�[�����f�[�^�Z�b�g�擾����
        /// </summary>
        /// <returns>�`�[�����f�[�^�Z�b�g</returns>
        public StockAdjDataSet DataSet
        {
            get { return this._dataSet; }
        }

        # region ��public int GetOnlineMode()
        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2006.12.04</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._iStockAdjRefSearchDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }
        # endregion

        #region ��Private Method


        /// <summary>
        /// �`�[�f�[�^�e�[�u�� �L���b�V������
        /// </summary>
        private void CacheStockSlipTable()
        {
            if (_stockSlipCache == null)
            {
                _stockSlipCache = new StockAdjDataSet.StockAdjustDataTable();
            }

            this._dataSet.StockAdjust.AcceptChanges();
            _stockSlipCache = (StockAdjDataSet.StockAdjustDataTable)this._dataSet.StockAdjust.Copy();
        }

        /// <summary>
        /// ���������N���X(�ĕ\���p) �L���b�V������
        /// </summary>
        private void CacheParaStockSlip(StockAdjRefSearchParaWork stockAdjRefSearchParaWork)
        {
            // ���������l
            if (_paraStockSlipCache == null)
            {
                _paraStockSlipCache = new StockAdjRefSearchParaWork();
            }
            _paraStockSlipCache = stockAdjRefSearchParaWork;

            // ����
            if (_nameList == null)
            {
                _nameList = new SortedList();
            }

            // �f���Q�[�g�ɂĉ�ʂ̖��̍��ڒl���X�g���擾�E�i�[
            if (this.GetNameList != null)
            {
                _nameList = this.GetNameList();
            }
        }

        #endregion


        #region ��Public Method

        /// <summary>
        /// �`�[��� �Ǎ��E�f�[�^�Z�b�g�i�[���s����
        /// </summary>
        /// <param name="ioWriteMASIRReadWork">�d���`�[�����p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �ђJ</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        public int SetSearchData(StockAdjRefSearchParaWork stockAdjRefSearchParaWork)
        {
            List<StockAdjRefSearchRetWork> retData;
            
            // �����[�g�Ăяo��
            int status = this.Search( out retData, stockAdjRefSearchParaWork );
            this.ClearStockAdjustDataTable();

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                for (int i = 0; i < retData.Count; i++)
                {
                    // 1���׎擾
                    StockAdjRefSearchRetWork stockAdjRefSearchRetWork = retData[i];

                    // �f�[�^�e�[�u���Ɋi�[
                    CopyToTable( stockAdjRefSearchRetWork );
                }

                // �����f�[�^�̃L���b�V��
                this.CacheStockSlipTable();

                // ���������̃L���b�V��
                this.CacheParaStockSlip(stockAdjRefSearchParaWork);
            }
            else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                     (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
            {
                if (this.StatusBarMessageSetting != null)
                {
                    this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                }
            }
            return status;
        }

        /// <summary>
        /// �f�[�^�e�[�u���i�[����
        /// </summary>
        /// <param name="stockAdjRefSearchRetWork"></param>
        private void CopyToTable( StockAdjRefSearchRetWork retWork )
        {
            // �V�K�s�擾
            StockAdjDataSet.StockAdjustRow row = _dataSet.StockAdjust.NewStockAdjustRow();

            # region [copy]
            row.RowNo = _dataSet.StockAdjust.Rows.Count + 1;    // �s��
            row.EnterpriseCode = retWork.EnterpriseCode; // ��ƃR�[�h
            row.SectionCode = retWork.SectionCode; // ���_�R�[�h
            row.SectionGuideSnm = retWork.SectionGuideSnm; // ���_�K�C�h����
            row.WarehouseCode = retWork.WarehouseCode; // �q�ɃR�[�h
            row.WarehouseName = retWork.WarehouseName; // �q�ɖ���
            row.AcPaySlipCd = retWork.AcPaySlipCd; // �󕥌��`�[�敪
            row.AcPaySlipCdNm = this.GetAcPaySlipCdName( retWork.AcPaySlipCd ); // �󕥌��`�[�敪����
            row.AcPayTransCd = retWork.AcPayTransCd; // �󕥌�����敪
            row.AcPayTransCdNm = this.GetAcPayTransCdName( retWork.AcPayTransCd ); // �󕥌�����敪����
            row.InputDay = this.GetDate( retWork.InputDay ); // ���͓��t
            row.AdjustDate = this.GetDate( retWork.AdjustDate ); // �������t
            row.StockAdjustSlipNo = retWork.StockAdjustSlipNo; // �݌ɒ����`�[�ԍ�
            row.StockAgentCode = retWork.StockAgentCode; // ���͒S���҃R�[�h
            row.StockAgentName = retWork.StockAgentName; // ���͒S���Җ���
            row.SlipNote = retWork.SlipNote; // �`�[���l
            row.StockSubttlPrice = retWork.StockSubttlPrice; // �d�����z���v
            row.StockAdjObject = retWork; // ����work�I�u�W�F�N�g
            # endregion

            // �ǉ�
            _dataSet.StockAdjust.AddStockAdjustRow( row );
        }

        /// <summary>
        /// �󕥌�����敪���̎擾����
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string GetAcPayTransCdName( int acPayTransCd )
        {
            if ( _acPayTransCdNmDic == null )
            {
                return string.Empty;
            }
            else if ( !_acPayTransCdNmDic.ContainsKey( acPayTransCd ) )
            {
                return string.Empty;
            }
            else
            {
                return _acPayTransCdNmDic[acPayTransCd]; 
            }
        }

        /// <summary>
        /// �󕥌��`�[�敪���̎擾����
        /// </summary>
        /// <param name="acPaySlipCd"></param>
        /// <returns></returns>
        public string GetAcPaySlipCdName( int acPaySlipCd )
        {
            if ( _acPaySlipCdNmDic == null )
            {
                return string.Empty;
            }
            else if ( !_acPaySlipCdNmDic.ContainsKey( acPaySlipCd ) )
            {
                return string.Empty;
            }
            else
            {
                return _acPaySlipCdNmDic[acPaySlipCd];
            }
        }
        /// <summary>
        /// ���t������@�擾����
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        private string GetDate( DateTime dateTime )
        {
            if ( dateTime != DateTime.MinValue )
            {
                //return dateTime.ToString( "yyyy�NMM��dd��" );         //DEL 2009/04/03 �s��Ή�[12857]
                return dateTime.ToString("yyyy/MM/dd");                 //ADD 2009/04/03 �s��Ή�[12857]
            }
            else
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// �f�[�^�Z�b�g�N���A����
        /// </summary>
        public void ClearStockAdjustDataTable()
        {
            this._dataSet.StockAdjust.Rows.Clear();

            // �L���b�V���f�[�^�̎�蒼��(�N���A��Ԃɂ���)
            this.CacheStockSlipTable();
            this.CacheParaStockSlip(null);
        }
        
        /// <summary>
        /// �`�[��� �ǂݍ��ݏ���
        /// </summary>
        /// <param name="stockSlipWorks">�d���f�[�^ �I�u�W�F�N�g�z��</param>
        /// <param name="stockAdjRefSearchParaWork">�d���`�[�����p�����[�^�N���X</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �`�[����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �ђJ</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        public int Search(out List<StockAdjRefSearchRetWork> stockAdjRefSearchRetWorks, StockAdjRefSearchParaWork stockAdjRefSearchParaWork)
        {
            

            try
            {
                int status;
                stockAdjRefSearchRetWorks = new List<StockAdjRefSearchRetWork>();

                // �I�����C���̏ꍇ�����[�g�擾
                if (LoginInfoAcquisition.OnlineFlag)
                {
                    CustomSerializeArrayList paraList = new CustomSerializeArrayList();
                    paraList.Add(stockAdjRefSearchParaWork);

                    CustomSerializeArrayList retList = new CustomSerializeArrayList();

                    object paraObj = (object)paraList;
                    object retObj = (object)retList;

                    //�`�[���擾
                    status = this._iStockAdjRefSearchDB.Search(ref paraObj, out retObj);
                    
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                    {
                        int setCount = 0;
                        retList = (CustomSerializeArrayList)retObj;
                        for (int i = 0; i < retList.Count; i++)
                        {
                            stockAdjRefSearchRetWorks.Add((StockAdjRefSearchRetWork)retList[i]);
                            setCount++;
                        }
                    }
                    else if ((status == (int)ConstantManagement.DB_Status.ctDB_EOF) ||
                             (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND))
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_NoResult);
                        }
                    }
                    else
                    {
                        if (this.StatusBarMessageSetting != null)
                        {
                            this.StatusBarMessageSetting(this, MESSAGE_ErrResult);
                        }
                    }
                }
                else	// �I�t���C���̏ꍇ
                {
                    //status = ReadStaticMemory(out lgoodsganre, enterpriseCode, largeGoodsGanreCode);
                    status = -1;
                }

                return status;
            }
            catch (Exception)
            {
                stockAdjRefSearchRetWorks = null;
                //�I�t���C������null���Z�b�g
                this._iStockAdjRefSearchDB= null;
                //�ʐM�G���[��-1��߂�
                return -1;
            }
        }

        /// <summary>
        /// �`�[�f�[�^�e�[�u���L���b�V���擾����
        /// </summary>
        /// <returns>�`�[�f�[�^�e�[�u���L���b�V��</returns>
        public StockAdjDataSet.StockAdjustDataTable GetStockSlipTableCache()
        {
            return _stockSlipCache;
        }

        /// <summary>
        /// ��ʖ��̍��ڒl���X�g �L���b�V���擾����
        /// </summary>
        /// <returns>��ʖ��̍��ڒl���X�g �L���b�V��</returns>
        public SortedList GetCacheNmaeList()
        {
            return _nameList;
        }


        /// <summary>
        /// ���������N���X�L���b�V���擾����
        /// </summary>
        /// <returns>���������N���X�L���b�V��</returns>
        public StockAdjRefSearchParaWork GetParaStockSlipCache()
        {
            return _paraStockSlipCache;
        }

        /// <summary>
        /// �I���s�e�[�u���f�[�^�擾����
        /// </summary>
        /// <param name="getRowNo">�O���b�h�I��RowNo</param>
        /// <returns>�d���f�[�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �f�[�^�e�[�u������A�w��s�̎d���f�[�^�N���X��Ԃ��܂��B</br>
        /// <br>Programmer : 980023 �ђJ  �k��</br>
        /// <br>Date       : 2008.09.02</br>
        /// </remarks>
        public StockAdjRefSearchRetWork GetSelectedRowData(int getRowNo)
        {
            return (StockAdjRefSearchRetWork)this._dataSet.StockAdjust[getRowNo].StockAdjObject;
        }

        /// <summary>
        /// �Ώۓ`�[���׏��擾����
        /// </summary>
        /// <param name="supplierSlipNo">�`�[�ԍ�</param>
        public void SetDetailData(int stockAdjustSlipNo)
		{
            // �݌Ɏd���`�[�̓ǂݍ���
            StockAdjust stockAdjust;
            List<StockAdjustDtl> stockAdjustDtlList;

            int status = this._adjustStockAcs.ReadDBData( stockAdjustSlipNo, out stockAdjust, out stockAdjustDtlList );
            if ( status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL )
            {
                int rowNo = 1;

                // ���ו\���Ƀf�[�^�i�[
                foreach ( StockAdjustDtl stockAdjustDtl in stockAdjustDtlList )
                {
                    // �s����
                    StockAdjDataSet.StockAdjustDtlRow row = this._dataSet.StockAdjustDtl.NewStockAdjustDtlRow();

                    // �s���e�Z�b�g
                    # region [row]
                    row.RowNo = rowNo++;
                    row.GoodsNo = stockAdjustDtl.GoodsNo; // ���i�ԍ�
                    row.GoodsName = stockAdjustDtl.GoodsName; // ���i����
                    row.MakerName = stockAdjustDtl.MakerName; // ���[�J�[����
                    // --- CHG 2009/02/16 ��QID:11543�Ή�------------------------------------------------------>>>>>
                    //row.BLGoodsCode = stockAdjustDtl.BLGoodsCode; // BL���i�R�[�h
                    if (stockAdjustDtl.BLGoodsCode != 0)
                    {
                        row.BLGoodsCode = stockAdjustDtl.BLGoodsCode.ToString("00000"); // BL���i�R�[�h
                    }
                    else
                    {
                        row.BLGoodsCode = "";
                    }
                    // --- CHG 2009/02/16 ��QID:11543�Ή�------------------------------------------------------<<<<<
                    row.ListPriceFl = stockAdjustDtl.ListPriceFl; // �艿�i�����j
                    row.OpenPriceDiv = stockAdjustDtl.OpenPriceDiv; // �I�[�v�����i�敪
                    row.ListPriceFlView = this.GetListPriceFlForView( stockAdjustDtl ); // �艿�i�\���p�j
                    row.AdjustCount = stockAdjustDtl.AdjustCount; // ������
                    row.StockUnitPriceFl = stockAdjustDtl.StockUnitPriceFl; // �d���P���i�Ŕ�,�����j
                    row.StockPriceTaxExc = stockAdjustDtl.StockPriceTaxExc; // �d�����z�i�Ŕ����j
                    row.DtlNote = stockAdjustDtl.DtlNote; // ���ה��l
                    // --- ADD 2009/02/16 ��QID:10825�Ή�------------------------------------------------------>>>>>
                    row.WarehouseCode = stockAdjustDtl.WarehouseCode;
                    row.WarehouseName = stockAdjustDtl.WarehouseName;
                    // --- ADD 2009/02/16 ��QID:10825�Ή�------------------------------------------------------<<<<<
                    // >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>  m.suzuki m.suzuki 2008/09/30 ADD
                    row.WarehouseShelfNo = stockAdjustDtl.WarehouseShelfNo; // �I��
                    // <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<  m.suzuki m.suzuki 2008/09/30 ADD
                    # endregion

                    // �s�ǉ�
                    this._dataSet.StockAdjustDtl.AddStockAdjustDtlRow( row );
                }
            }
		}
        /// <summary>
        /// �\���p �W�����i ���e�擾����
        /// </summary>
        /// <param name="stockAdjustDtl"></param>
        /// <returns></returns>
        private string GetListPriceFlForView( StockAdjustDtl stockAdjustDtl )
        {
            if ( stockAdjustDtl.OpenPriceDiv == 0 )
            {
                // 0:�ʏ�
                return stockAdjustDtl.ListPriceFl.ToString( "#,##0" );
            }
            else
            {
                // 1:�I�[�v�����i
                return "�I�[�v�����i";
            }
        }

		// ===================================================================================== //
		// ���i�֘A����
		// ===================================================================================== //
		# region Goods Control Methods

		/// <summary>
		/// �����^�C�v�擾����
		/// </summary>
		/// <param name="inputCode">���͂��ꂽ�R�[�h</param>
		/// <param name="searchCode">�����p�R�[�h�i*�������j</param>
		/// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
		public static int GetSearchType(string inputCode, out string searchCode)
		{
			searchCode = inputCode;
			if (String.IsNullOrEmpty(inputCode)) return 0;

			if (inputCode.Contains("*"))
			{
				searchCode = inputCode.Replace("*", "");
				string firstString = inputCode.Substring(0, 1);
				string lastString = inputCode.Substring(inputCode.Length - 1, 1);

				if ((firstString == "*") && (lastString == "*"))
				{
					return 3;
				}
				else if (firstString == "*")
				{
					return 2;
				}
				else if (lastString == "*")
				{
					return 1;
				}
				else
				{
					return 3;
				}
			}
			else
			{
				// *�����݂��Ȃ����ߊ��S��v����
				return 0;
			}
		}

		# endregion

        /// <summary>
        /// ���_����A�N�Z�X�N���X�C���X�^���X������
        /// </summary>
        internal void CreateSecInfoAcs()
        {
            if (_secInfoAcs == null)
            {
                _secInfoAcs = new SecInfoAcs();
            }

            // ���O�C���S�����_���̎擾
            if (_secInfoAcs.SecInfoSet == null)
            {
                throw new ApplicationException(MESSAGE_NONOWNSECTION);
            }
        }

        // 2008.12.25 [9573]
        ///// <summary>
        ///// �{�Ћ@�\�^���_�@�\�`�F�b�N����
        ///// </summary>
        ///// <returns>true:�{�Ћ@�\ false:���_�@�\</returns>
        //public bool IsMainOfficeFunc()
        //{
        //    bool isMainOfficeFunc = false;

        //    // ���_����A�N�Z�X�N���X�C���X�^���X������
        //    this.CreateSecInfoAcs();

        //    // ���O�C���S�����_���̎擾
        //    SecInfoSet secInfoSet = _secInfoAcs.SecInfoSet;

        //    if (secInfoSet != null)
        //    {
        //        // �{�Ћ@�\���H
        //        if (secInfoSet.MainOfficeFuncFlag == 1)
        //        {
        //            isMainOfficeFunc = true;
        //        }
        //    }
        //    else
        //    {
        //        throw new ApplicationException(MESSAGE_NONOWNSECTION);
        //    }

        //    return isMainOfficeFunc;
        //}
        // 2008.12.25 [9573]

		# endregion
    }
}
