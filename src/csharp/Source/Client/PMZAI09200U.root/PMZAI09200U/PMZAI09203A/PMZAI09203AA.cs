using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Library.Resources;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�݌Ɉꊇ�o�^�C���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�݌Ɉꊇ�o�^�C���̃f�[�^�擾�A�ۑ�����S�ʂ��s���B</br>
    /// <br>Programmer : 33045 ��� �r��</br>
    /// <br>Date       : 2008.12.22</br>
    /// <br></br>
    /// <br>Update Note: 2009.02.16 30452 ��� �r��</br>
    /// <br>            �E���x�A�b�v�Ή�</br>
    /// <br>Update Note: 2009.02.18 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�11649(�G���[�����̏C���ADataTable�������召��������ʂ���悤�C��)</br>
    /// <br>Update Note: 2009/02/19 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�11721(���i�}�X�^����(���[�U)�̍ő匟������3200���ɌŒ�)</br>
    /// <br>Update Note: 2009/03/03 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12104,12103,12081,12074,12075</br>
    /// <br>Update Note: 2009/03/05 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12082,12070,12132,12073,12205</br>
    /// <br>Update Note: 2009/03/10 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12080</br>
    /// <br>Update Note: 2009/03/10 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�12223</br>
    /// <br>Update Note: 2009/04/03 30452 ��� �r��</br>
    /// <br>            �E��Q�Ή�13070</br>
    /// <br>Update Note: 2010/01/08 30434 �H�� �b�D</br>
    /// <br>            �E��Q�Ή�14861</br>
    /// <br>Update Note: 2010/08/31 ����</br>
    /// <br>            �Eredmine #13980</br>
    /// <br>Update Note: 2010/12/15 22008 ���� ���n</br>
    /// <br>            �E�݌Ƀ}�X�^�ɑ��݂��郌�R�[�h���\������Ȃ��s��̏C���i�X�암�i�l�Ŕ����j</br>
    /// <br>Update Note: 2011/07/22 �A��916�@����R</br>
    /// <br>            �E�݌Ƀ}�X�^��V�K�쐬����ꍇ�A�C���������̂����ł͖������ׂɂ���S�Ă̏��i���݌Ƀ}�X�^�ɏ������܂�Ă��܂��APM7�Ɠ����d�l�ɂ���</br>
    /// <br>Update Note: 2011/08/03 ����R</br>
    /// <br>            �ERedmine23379</br>
    /// <br>�@�݌ɓo�^���ɊǗ��敪�P�E�Q�������͂̏ꍇ�A�R�[�h�O���Z�b�g���Ē����l�ɂ��܂����B</br>
    /// <br>�A�Ǘ��敪�}�X�^�ɓo�^�̖����R�[�h�̓��͂��������ۂ́A�}�X�^�̑��݃`�F�b�N���s�킸�ɓo�^�\�Ƃ��܂���</br>
    /// <br>Update Note: 2011/08/23 wangf</br>
    /// <br>            �ERedmine23907</br>
    /// <br>            �E�\���敪�u�V�K�o�^�v���Ώۋ敪�u�݌Ɂv�̏ꍇ�͘A��916�̉��C�͔��f�����</br>
    /// <br>Update Note: 2011/10/17 30517 �Ė� �x��</br>
    /// <br>            �EMantis.17857�@�Ώۋ敪���w���i�x�̏ꍇ�A���݌ɐ����{�ɂȂ��Ă��܂��s��̑Ή�</br>
    /// <br>Update Note: 2011/12/31 ���H��</br> 
    /// <br>�Ǘ��ԍ�     10707327-00 2012/01/25�z�M��</br> 							
    /// <br>             Redmine27530 ���i�݌Ɉꊇ�o�^/�u�O�~�v�̊|���f�[�^�̓o�^</br> 										 
    /// <br>Update Note: 2012/09/11 yangmj ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
    /// <br>�Ǘ��ԍ�   : 10707327-00 PM1203G</br> 							
    /// <br>             Redmine32095 ���i�݌Ɉꊇ�o�^�C���Łu�S�Ẳ��i��񂪏�����v</br> 		 
    /// <br>Update Note: 2013/01/24 gezh </br>
    /// <br>             Redmine#33361 ���i�݌Ɉꊇ�o�^�C���̃T�[�o�[���׌y���̏C��</br>	
    /// <br>Update Note: 2013/03/18 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           : Redmine#34962 �@�u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���Ή�</br>
    /// <br>Update Note: 2013/04/25 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           : Redmine#35018 �@�u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���Ή�</br>
    /// <br>Update Note: 2013/05/11 yangyi</br>
    /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
    /// <br>           : Redmine#35018 �u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���@���̂Q�Ή�</br>
    /// <br>Update Note: 2015/01/14 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11100008-00</br>
    /// <br>           : Redmine#44473 ���i�݌Ɉꊇ�o�^�C���ɂč݌ɍ폜�����폜�����������t�ɂȂ��Ă��Ȃ��Ή�</br>
    /// <br>Update Note: 2015/08/17 �c����</br>
    /// <br>�Ǘ��ԍ�   : 11170052-00</br>
    /// <br>           : Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
    /// </remarks>
    public class GoodsStockAcs
    {
        #region ��private�萔
        // �|���}�X�^�̏����l
        private const string CT_UnitRateSetDivCd = "36A"; // �P���|���ݒ�敪
        private const string CT_UnitPriceKind = "3"; // �P�����
        private const string CT_RateSettingDivide = "6A"; // �|���ݒ�敪
        private const string CT_RateMngGoodsCd = "A"; // �|���ݒ�敪�i���i�j
        private const string CT_RateMngGoodsNm = "Ұ���{�i��"; // �|���ݒ薼�́i���i�j
        private const string CT_RateMngCustCd = "6"; // �|���ݒ�敪�i���Ӑ�j
        private const string CT_RateMngCustNm = "�ݒ�Ȃ�"; // �|���ݒ薼�́i���Ӑ�j
        private const double CT_UnPrcFracProcUnit = 1; // �P���[�������P��
        private const Int32 CT_UnPrcFracProcDiv = 2; // �P���[�������敪
        private const double CT_LotCount = 9999999.99; // ���b�g���̏����l

        //private const Int32 CT_MaxSearchNum = 3200; // �ő匟���� // ADD 2009/02/19 DEL 2010/12/15
        private const Int32 CT_MaxSearchNum = 0; // �ő匟���� // ADD 2010/12/15
        #endregion

        #region ��private�ϐ�
        // ��ƃR�[�h
        private string _enterpriseCode;
        // ���O�C�����_�R�[�h
        private string _loginSectionCode;
        
        // ���i�݌Ɉꊇ�o�^�C���A�N�Z�X�N���X
        private static GoodsStockAcs _goodsStockAcs;
        // ���i�}�X�^�A�N�Z�X
        private GoodsAcs _goodsAcs;
        // �݌Ƀ}�X�^�A�N�Z�X
        private SearchStockAcs _searchStockAcs;
        // �d����}�X�^�A�N�Z�X
        private SupplierAcs _supplierAcs;
        // �q�Ƀ}�X�^�A�N�Z�X
        private WarehouseAcs _warehouseAcs;
        // BL�R�[�h�}�X�^�A�N�Z�X
        private BLGoodsCdAcs _blGoodsCdAcs;
        // �Ǘ����_�K�C�h
        private SecInfoSetAcs _secInfoSetAcs; // ADD 2009/03/10

        // ���i�Ǘ����}�X�^�A�N�Z�X
        private GoodsMngAcs _goodsMngAcs;
        // �|���}�X�^�A�N�Z�X
        private RateAcs _rateAcs;
        // �|���D��Ǘ��}�X�^�A�N�Z�X
        private RateProtyMngAcs _rateProtyMngAcs;

        // �O���b�h�\���e�[�u��
        private GoodsStockDataSet _goodsStockDataSet;
        private GoodsStockDataSet.GoodsStockDataTable _goodsStockDataTable;
        private DataTable _originalGoodsStockDataTable; // �ύX�L���`�F�b�N�p �������̃f�[�^

        private List<GoodsUnitData> _originalGoodsUnitDataList; // �ҏW�����p���i�A���f�[�^
        // �|���}�X�^���
        private List<Rate> _originalRateList;
        //// �|���}�X�^���(�S�Аݒ�ŊY���̂���������)
        //private List<Rate> _originalAllSectionRateList; // DEL 2009/02/04 

        // �|���D��Ǘ����L���t���O(true:�Y������Afalse:�Y���Ȃ�)
        private bool _rateProtyMngFlg;

        //-----ADD 2011/08/03---------->>>>>
        private bool _noneflag = true;
        private bool _havenullsectionrow = false ;


        public bool NoneFlag
        {
            get { return _noneflag; }
    
        }

        public bool HaveNullSectionRow
        {
            get { return _havenullsectionrow; }

        }

        //-----ADD 2011/08/03----------<<<<<

        // --- ADD 2009/02/04 -------------------------------->>>>>
        // �L�����Z�������t���O
        private bool _cancelFlg;

        // BL�R�[�h��(���p)���X�g
        private Dictionary<int, string> _blGoodsCdUMntList;
        // �����於�̃��X�g
        private Dictionary<int, string> _supplierList;
        // --- ADD 2009/02/04 --------------------------------<<<<<
        private bool _outMaxCount = false;  // ADD gezh 2013/01/24 Redmine#33361�u20000���v�̉��C��
        private Dictionary<string, SecInfoSet> _sectionDic;  // ADD gezh 2013/01/24 Redmine#33361 Client�[�̉��C�ć@
        #endregion

        #region ���R���X�g���N�^
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
        public GoodsStockAcs()
        {
            //this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode; // DEL 2009/02/04
            //this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode; // DEL 2009/02/04
            this._enterpriseCode = LoginInfoAcquisition.EnterpriseCode.TrimEnd(); // ADD 2009/02/04
            this._loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode.TrimEnd(); // ADD 2009/02/04

            this._goodsAcs = new GoodsAcs();
            string msg;
            this._goodsAcs.SearchInitial(this._enterpriseCode, this._loginSectionCode, out msg);

            this._goodsMngAcs = new GoodsMngAcs();
            this._rateAcs = new RateAcs();
            this._rateProtyMngAcs = new RateProtyMngAcs();
            this._supplierAcs = new SupplierAcs();
            this._warehouseAcs = new WarehouseAcs();
            this._blGoodsCdAcs = new BLGoodsCdAcs();
            this._secInfoSetAcs = new SecInfoSetAcs(); // ADD 2009/03/10

            this._searchStockAcs = new SearchStockAcs();
            this._goodsStockDataSet = new GoodsStockDataSet();
            this._goodsStockDataTable = this._goodsStockDataSet.GoodsStock;
            this._originalGoodsStockDataTable = new DataTable();

            this._goodsStockDataTable.CaseSensitive = true; // ADD 2009.02.18
            this._originalGoodsStockDataTable.CaseSensitive = true; // ADD 2009.02.18

            this._originalRateList = new List<Rate>();
            //this._originalAllSectionRateList = new List<Rate>(); // DEL 2009/02/04

            this._rateProtyMngFlg = this.SearchRateProtyMng();

            this._cancelFlg = false; // ADD 2009/02/04
        }

        /// <summary>
        /// �݌Ɉꊇ�o�^�A�N�Z�X�N���X �C���X�^���X�擾����
        /// </summary>
        /// <returns>�݌Ɉꊇ�o�^�A�N�Z�X�N���X �C���X�^���X</returns>
        public static GoodsStockAcs GetInstance()
        {
            if (_goodsStockAcs == null)
            {
                _goodsStockAcs = new GoodsStockAcs();
            }

            return _goodsStockAcs;
        }
        #endregion

        #region ��public�v���p�e�B
        /// <summary>
        /// ���i�݌Ƀf�[�^�e�[�u���v���p�e�B
        /// </summary>
        public GoodsStockDataSet.GoodsStockDataTable GoodsStockDataTable
        {
            get { return _goodsStockDataTable; }
        }

        /// <summary>
        /// �������̏��i�݌Ƀf�[�^�e�[�u���v���p�e�B
        /// </summary>
        public DataTable OriginalGoodsStockDataTable
        {
            get { return _originalGoodsStockDataTable; }
        }

        /// <summary>
        /// �|���D��Ǘ����̗L�����v���p�e�B
        /// </summary>
        public bool RateProtyMngExist
        {
            get { return this._rateProtyMngFlg; }
        }

        // --- ADD 2009/02/04 -------------------------------->>>>>
        /// <summary>
        /// �L�����Z���t���O�v���p�e�B
        /// </summary>
        public bool CancelFlg
        {
            get { return this._cancelFlg; }
            set { this._cancelFlg = value; }
        }
        // --- ADD 2009/02/04 --------------------------------<<<<<
        // ADD gezh 2013/01/24 Redmine#33361 �u20000���v�̉��C�� ----->>>>>
        /// <summary>
        /// �ő匏���v���p�e�B
        /// </summary>
        public bool OutMaxCount
        {
            get { return this._outMaxCount; }
            set { this._outMaxCount = value; }
        }
        // ADD gezh 2013/01/24 Redmine#33361 �u20000���v�̉��C�� -----<<<<<
        #endregion

        #region �� public���\�b�h

        #region �� ��������
        /// <summary>
        /// ���i�A���f�[�^(�񋟕�)��������
        /// </summary>
        /// <returns></returns>
        public int SearchOfferGoodsUnitData(ExtractInfo extractInfo, out string errMsg)
        {
            // �O�񌟍�����������
            this._goodsStockDataTable.Clear(); // ADD 2009/02/04
            _outMaxCount = false;  // ADD gezh 2013/01/24 Redmine#33361�u20000���v�̉��C��
            errMsg = string.Empty;

            List<GoodsUnitData> goodsUnitDataList;
            PartsInfoDataSet partsInfoDataSet;

            // ���o�����̍쐬
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = extractInfo.GoodsMakerCd;
            goodsCndtn.GoodsNo = extractInfo.GoodsNo;

            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New)
            {
                goodsCndtn.BLGoodsCode = extractInfo.BLGoodsCode;
            }

            goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/16

            // ���i�}�X�^�i�񋟃f�[�^�j����
            int status = this._goodsAcs.SearchPartsOfNonGoodsNo(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out errMsg);

            if (status == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
            {
                // --- DEL 2009/02/04 -------------------------------->>>>>
                #region �폜
                //// �񋟃f�[�^�̑I��
                //goodsUnitDataList = this.GetOfferGoodsUnitData(goodsUnitDataList);

                //if (goodsUnitDataList.Count != 0)
                //{
                //    // ���i�A���f�[�^��GoodsStock�e�[�u���Ɋi�[
                //    this.SetGoodsStockDataTableFromGoodsUnitDataList(goodsUnitDataList, extractInfo);

                //    // �s�ԍ��̐ݒ�
                //    this.SetRowNumber();

                //    // �������̏��i�A���f�[�^����ێ�
                //    this._originalGoodsStockDataTable = this._goodsStockDataTable.Copy();
                //    this._originalGoodsUnitDataList = goodsUnitDataList;
                //}
                //else
                //{
                //    this._goodsStockDataTable.Clear();
                //    this._originalGoodsStockDataTable.Clear();
                //    this._originalGoodsUnitDataList = null;

                //    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //}
                #endregion
                // --- DEL 2009/02/04 --------------------------------<<<<<
                // --- ADD 2009/02/04 -------------------------------->>>>>

                // �|���}�X�^���擾����
                int rateStat;
                ArrayList retList;

                // ���O�C�����_�ł̌���
                // �����ݒ�
                Rate rate = new Rate();
                rate.EnterpriseCode = this._enterpriseCode;
                rate.UnitPriceKind = CT_UnitPriceKind;
                rate.RateSettingDivide = CT_RateSettingDivide;
                rate.UnitRateSetDivCd = CT_UnitRateSetDivCd;

                rateStat = this._rateAcs.SearchAll(out retList, ref rate, out errMsg);

                if (rateStat == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && retList != null
                    && retList.Count != 0)
                {
                    // --- DEL 2009/02/16 -------------------------------->>>>>
                    //foreach (Rate retRate in retList)
                    //{
                    //    this._originalRateList.Add(retRate);
                    //}
                    // --- DEL 2009/02/16 --------------------------------<<<<<
                    this._originalRateList = new List<Rate>((Rate[])retList.ToArray(typeof(Rate))); // ADD 2009/02/16
                }

                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    if (this._cancelFlg)
                    {
                        break;
                    }

                    // ���[�U�f�[�^�`�F�b�N
                    if(!this.CheckOfferGoodsUnitData(goodsUnitData))
                    {
                        continue;
                    }

                    // GoodsStock�e�[�u���Ɋi�[
                    this.SetGoodsStockDataRow(goodsUnitData, null);
                }

                // --- ADD 2009/03/06 -------------------------------->>>>>
                // �i�ԁA���[�J�[�A�q�ɂŃ\�[�g
                DataTable tmpTable = this._goodsStockDataTable.Copy();
                this._goodsStockDataTable.Clear();

                DataRow[] drList = tmpTable.Select("",
                    this._goodsStockDataTable.GoodsNoColumn.ColumnName + ", "
                    + this._goodsStockDataTable.GoodsMakerColumn.ColumnName + ", "
                    + this._goodsStockDataTable.WarehouseCodeColumn.ColumnName);

                foreach (DataRow dr in drList)
                {
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    if (this._goodsStockDataTable.Rows.Count >= extractInfo.MaxCount)
                    {
                        break;
                    }
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<

                    this._goodsStockDataTable.ImportRow(dr);
                    // ADD gezh 2013/01/24 Redmine#33361 �u20000���v�̉��C�� ----->>>>>
                    if (this._goodsStockDataTable.Rows.Count >= 20000)
                    {
                        _outMaxCount = true;
                        break;
                    }
                    // ADD gezh 2013/01/24 Redmine#33361 �u20000���v�̉��C�� -----<<<<<
                }
                // --- ADD 2009/03/06 --------------------------------<<<<<

                // �s�ԍ��̐ݒ�
                //this.SetRowNumber();// DEL 2009/03/06
                this.SetRowNumber(extractInfo); // ADD 2009/03/06

                if (this._goodsStockDataTable.Rows.Count != 0)
                {
                    this._originalGoodsStockDataTable = this._goodsStockDataTable.Copy();
                    this._originalGoodsUnitDataList = goodsUnitDataList;
                }
                else
                {
                    this._goodsStockDataTable.Clear();
                    this._originalGoodsStockDataTable.Clear();
                    this._originalGoodsUnitDataList = null;

                    if (!this._cancelFlg) // ADD 2009/02/04
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                // --- ADD 2009/02/04 --------------------------------<<<<<

            }
            else if (status == (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN)
            {
                this._goodsStockDataTable.Clear();
                this._originalGoodsStockDataTable.Clear();
                this._originalGoodsUnitDataList = null;

                return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
            }
            else
            {
                this._goodsStockDataTable.Clear();
                this._originalGoodsStockDataTable.Clear();
                this._originalGoodsUnitDataList = null;
            }

            return status;
        }

        /// <summary>
        /// ���i�A���f�[�^(���[�U�[��)��������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2015/08/17 �c����</br>
        /// <br>�Ǘ��ԍ�   : 11170052-00</br>
        /// <br>           : Redmine#47036 ���i�݌Ɉꊇ�o�^�C�� �Ǘ����_�E�q�ɂ̒ǉ�</br>
        /// </remarks>
        public int SearchUserGoodsUnitData(ExtractInfo extractInfo, out string errMsg)
        {
            // �O�񌟍�����������
            this._goodsStockDataTable.Clear(); // ADD 2009/02/04
            _outMaxCount = false;  // ADD gezh 2013/01/24 Redmine#33361�u20000���v�̉��C��
            errMsg = string.Empty;

            List<GoodsUnitData> goodsUnitDataList;

            // ���o�����̍쐬
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsMakerCd = extractInfo.GoodsMakerCd;
            goodsCndtn.GoodsNo = extractInfo.GoodsNo;

            //----- ADD 2015/08/17 �c���� Redmine#47036 ---------->>>>>
            // �Ώۋ敪�F�݌�-���i/�݌ɂ̏ꍇ�A�Ǘ����_�E�q�ɂ�ǉ�����
            if (extractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods
               || extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                goodsCndtn.AddUpSectionCode = extractInfo.AddUpSectionCode;
                goodsCndtn.WarehouseCode = extractInfo.WarehouseCode;
            }
            //----- ADD 2015/08/17 �c���� Redmine#47036 ----------<<<<<

            if (extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods
                || extractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                goodsCndtn.GoodsMGroup = extractInfo.GoodsMGroup;
                goodsCndtn.BLGoodsCode = extractInfo.BLGoodsCode;
            }

            // �O����v
            goodsCndtn.GoodsNoSrchTyp = 1;
            // ���i���� (0,1����)
            goodsCndtn.GoodsKindCode = 9; // ADD 2009/02/03

            goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/16

            int targetDiv = 0;
            switch (extractInfo.TargetDiv)
            {
                case ExtractInfo.TargetDivState.Goods:
                    targetDiv = 0;
                    break;
                case ExtractInfo.TargetDivState.GoodsStock:
                    targetDiv = 1;
                    break;
                case ExtractInfo.TargetDivState.StockGoods:
                    targetDiv = 2;
                    break;
                case ExtractInfo.TargetDivState.Stock:
                    targetDiv = 3;
                    break;
                default:
                    break;
            }

            // ���� (�_���폜�f�[�^���擾����)
            //int status = this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out errMsg); // DEL 2009/02/19
            //int status = this._goodsAcs.Search(goodsCndtn, CT_MaxSearchNum, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out errMsg); // ADD 2009/02/19 //DEL yangyi 2013/03/18 Redmine#34962 
            int status = this._goodsAcs.Search(goodsCndtn, extractInfo.MaxCount, targetDiv, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out errMsg); //ADD yangyi 2013/03/18 Redmine#34962 

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2009/02/04 -------------------------------->>>>>
                #region �폜
                //if (goodsUnitDataList.Count != 0)
                //{
                //    // �Ώۋ敪�̔��f
                //    if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                //        &&
                //        (extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock
                //        || extractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
                //        )
                //    {
                //        // ���o�����u�q�ɃR�[�h�v�u�v�㋒�_�v�̔��f
                //        this.FilterGoodsUnitDataByExtractInfo(goodsUnitDataList, extractInfo);

                //        // �u�C���o�^�v�A�Ώۋ敪���u�݌Ɂv�u�݌�-���i�v�̏ꍇ
                //        // ���i���_���폜�łȂ��A�݌ɓo�^������f�[�^�̂ݕ\��
                //        this.FilterGoodsUnitDataByExistGoods(goodsUnitDataList);
                //    }
                //    else if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                //        && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
                //    {
                //        // �u�V�K�o�^�v�A�Ώۋ敪���u�݌Ɂv�u�݌�-���i�v�̏ꍇ
                //        // ���i���_���폜�łȂ��A�݌ɓo�^���Ȃ��f�[�^�̂ݕ\��
                //        this.FilterGoodsUnitDataByNoGoods(goodsUnitDataList);
                //    }

                //    if (goodsUnitDataList.Count == 0)
                //    {
                //        this._goodsStockDataTable.Clear();
                //        this._originalGoodsStockDataTable.Clear();
                //        this._originalGoodsUnitDataList = null;
                //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //    }

                //    // ���i�A���f�[�^��GoodsStock�e�[�u���Ɋi�[
                //    this.SetGoodsStockDataTableFromGoodsUnitDataList(goodsUnitDataList, extractInfo);

                //    // �o�͎w��̔��f (�|���}�X�^���Q�Ƃ���ׁAGoodsStock�e�[�u���쐬��Ƀt�B���^�������s��)
                //    if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                //        && extractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock)
                //    {
                //        this.FilterGoodsUnitDataByOutputDiv(extractInfo);
                //    }

                //    if (this._goodsStockDataTable.Rows.Count == 0)
                //    {
                //        this._goodsStockDataTable.Clear();
                //        this._originalGoodsStockDataTable.Clear();
                //        this._originalGoodsUnitDataList = null;
                //        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //    }

                //    // �s�ԍ��̐ݒ�
                //    this.SetRowNumber();

                //    // �������̏��i�A���f�[�^����ێ�
                //    this._originalGoodsStockDataTable = this._goodsStockDataTable.Copy();
                //    this._originalGoodsUnitDataList = goodsUnitDataList;
                //}
                //else
                //{
                //    this._goodsStockDataTable.Clear();
                //    this._originalGoodsStockDataTable.Clear();
                //    this._originalGoodsUnitDataList = null;

                //    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                //}
                #endregion
                // --- DEL 2009/02/04 --------------------------------<<<<<
                // --- ADD 2009/02/04 -------------------------------->>>>>

                // �|���}�X�^���擾����
                int rateStat;
                ArrayList retList;

                // ���O�C�����_�ł̌���
                // �����ݒ�
                Rate rate = new Rate();
                rate.EnterpriseCode = this._enterpriseCode;
                rate.UnitPriceKind = CT_UnitPriceKind;
                rate.RateSettingDivide = CT_RateSettingDivide;
                rate.UnitRateSetDivCd = CT_UnitRateSetDivCd;

                rateStat = this._rateAcs.SearchAll(out retList, ref rate, out errMsg);

                if (rateStat == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    && retList != null
                    && retList.Count != 0)
                {
                    // --- DEL 2009/02/16 -------------------------------->>>>>
                    //foreach (Rate retRate in retList)
                    //{
                    //    this._originalRateList.Add(retRate);
                    //}
                    // --- DEL 2009/02/16 --------------------------------<<<<<
                    this._originalRateList = new List<Rate>((Rate[])retList.ToArray(typeof(Rate))); // ADD 2009/02/16
                }

                foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
                {
                    if (this._cancelFlg)
                    {
                        break;
                    }

                    if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                        && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
                    {
                        // �\���敪�u�V�K�o�^�v�A�Ώۋ敪�u�݌Ɂv
                        //if (!this.CheckGoodsUnitDataByNoGoods(goodsUnitData)) // DEL 2009/03/10
                        if (!this.FilterGoodsUnitDataForNewStock(goodsUnitData, extractInfo)) // ADD 2009/03/10
                        {
                            continue;
                        }
                    }
                    else if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                        &&
                        (extractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock
                        || extractInfo.TargetDiv == ExtractInfo.TargetDivState.StockGoods)
                        )
                    {
                        // �\���敪�u�C���o�^�v�A�Ώۋ敪�u�݌Ɂv�܂��́u�݌ɏ��i�v
                        // ���o�����u�q�ɃR�[�h�v�u�v�㋒�_�v�̔��f
                        this.FilterGoodsUnitDataByExtractInfo(goodsUnitData, extractInfo);

                        // ���i���_���폜�łȂ��A�݌ɓo�^������f�[�^�̂ݕ\��
                        if (!this.FilterGoodsUnitDataByExistGoods(goodsUnitData))
                        {
                            continue;
                        }
                    }

                    // ���i�A���f�[�^��GoodsStock�e�[�u���Ɋi�[
                    if (extractInfo.TargetDiv != ExtractInfo.TargetDivState.Goods
                    &&
                    (goodsUnitData.StockList != null && goodsUnitData.StockList.Count != 0)
                    )
                    {
                        // �Ώۋ敪�u���i-�݌Ɂv�A�u�݌�-���i�v�ō݌Ƀ��X�g�����݂���ꍇ
                        for (int j = 0; j < goodsUnitData.StockList.Count; j++)
                        {
                            // ���R�[�h�͍݌ɒP�ʂō쐬
                            Stock stock = goodsUnitData.StockList[j];

                            this.SetGoodsStockDataRow(goodsUnitData, stock);
                        }
                    }
                    else
                    {
                        // �Ώۋ敪�u���i�v�܂��͍݌Ƀ��X�g�����݂��Ȃ�
                        this.SetGoodsStockDataRow(goodsUnitData, null);
                    }
                }

                // �o�͎w��̔��f (�|���}�X�^���Q�Ƃ���ׁAGoodsStock�e�[�u���쐬��Ƀt�B���^�������s��)
                if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                    && extractInfo.TargetDiv != ExtractInfo.TargetDivState.Stock)
                {
                    this.FilterGoodsUnitDataByOutputDiv(extractInfo);
                }

                // --- ADD 2009/03/06 -------------------------------->>>>>
                // �i�ԁA���[�J�[�A�q�ɂŃ\�[�g
                DataTable tmpTable = this._goodsStockDataTable.Copy();
                this._goodsStockDataTable.Clear();

                DataRow[] drList = tmpTable.Select("",
                    this._goodsStockDataTable.GoodsNoColumn.ColumnName + ", "
                    + this._goodsStockDataTable.GoodsMakerColumn.ColumnName + ", "
                    + this._goodsStockDataTable.WarehouseCodeColumn.ColumnName);

                foreach (DataRow dr in drList)
                {
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 ------->>>>>>>>>>>
                    // --- DEL yangyi 2013/04/25 for Redmine#35018 ------->>>>>>>>>>>
                    //if (extractInfo.TargetDiv != ExtractInfo.TargetDivState.GoodsStock
                    //    && this._goodsStockDataTable.Rows.Count >= extractInfo.MaxCount)
                    // --- DEL yangyi 2013/04/25 for Redmine#35018 -------<<<<<<<<<<<
                    // --- ADD yangyi 2013/04/25 for Redmine#35018 ------->>>>>>>>>>>
                    if (this._goodsStockDataTable.Rows.Count >= extractInfo.MaxCount)
                    // --- ADD yangyi 2013/04/25 for Redmine#35018 -------<<<<<<<<<<<
                    {
                         break;
                    }
                    // --- ADD yangyi 2013/03/18 for Redmine#34962 -------<<<<<<<<<<<


                    this._goodsStockDataTable.ImportRow(dr);

                    // ADD gezh 2013/01/24 Redmine#33361 �u20000���v�̉��C�� ----->>>>>
                    if (this._goodsStockDataTable.Rows.Count >= 20000)
                    {
                        _outMaxCount = true;
                        break;
                    }
                    // ADD gezh 2013/01/24 Redmine#33361 �u20000���v�̉��C�� -----<<<<<
                }
                // --- ADD 2009/03/06 --------------------------------<<<<<

                // �s�ԍ��̐ݒ�
                //this.SetRowNumber(); // DEL 2009/03/06
                this.SetRowNumber(extractInfo); // ADD 2009/03/06

                if (this._goodsStockDataTable.Rows.Count != 0)
                {
                    this._originalGoodsStockDataTable = this._goodsStockDataTable.Copy();
                    this._originalGoodsUnitDataList = goodsUnitDataList;
                }
                else
                {
                    this._goodsStockDataTable.Clear();
                    this._originalGoodsStockDataTable.Clear();
                    this._originalGoodsUnitDataList = null;

                    if (!this._cancelFlg) // ADD 2009/02/04
                    {
                        return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                    }
                }
                // --- ADD 2009/02/04 --------------------------------<<<<<
            }
            else
            {
                this._goodsStockDataTable.Clear();
                this._originalGoodsStockDataTable.Clear();
                this._originalGoodsUnitDataList = null;
            }

            return status;
        }

        
        #endregion

        #region �� �ۑ�����
        /// <summary>
        /// DB�X�V����
        /// </summary>
        /// <param name="beforeExtractInfo">�O�񌟍����̒��o����</param>
        /// <param name="newExtractInfo">�ۑ��{�^���������̒��o����</param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Update Note: 2013/05/11 yangyi</br>
        /// <br>�Ǘ��ԍ�   : 10801804-00 20150515�z�M���̑Ή�</br>
        /// <br>           : Redmine#35018 �u���i�݌Ɉꊇ�C���v�̃T�[�o�[���׌y���@���̂Q�Ή�</br>
        /// </remarks>
        public int Write(ExtractInfo beforeExtractInfo, ExtractInfo newExtractInfo, out string msg)
        {
            // Write�����S�̂̃X�e�[�^�X(��ł��G���[������΃G���[��Ԃ�)
            int writeStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

            msg = string.Empty;
            int methodRes = (int)ConstantManagement.MethodResult.ctFNC_CANCEL;

            GoodsUnitData goodsUnitData;
            List<Stock> prevStockList;
            List<Rate> rateList;

            List<GoodsUnitData> errGoodsUnitDataList = new List<GoodsUnitData>();

            // ������(����)���i�L�[dictionary(�X�V�͏��i�A���f�[�^�P�ʂ̂���)
            //Dictionary<string, int> finishKeyDic = new Dictionary<string, int>(); // DEL 2009/02/04
            Dictionary<string, List<int>> finishKeyDic = new Dictionary<string, List<int>>(); // ADD 2009/02/04

            // ������(�G���[)���i�L�[dictionary(�X�V�͏��i�A���f�[�^�P�ʂ̂���)
            Dictionary<string, List<int>> errKeyDic = new Dictionary<string, List<int>>(); // ADD 2009.02.18

            int count = 0;// ADD 2011/07/22
            // goodsStock�e�[�u��1�s���X�V����
            _noneflag = true;// ADD 2011/08/03
            _havenullsectionrow = false;// ADD 2011/08/03
            foreach (DataRow dr in this._goodsStockDataTable.Rows)
            {
                /* --- DEL 2011/08/23 ----->>>>>
                 //--- ADD 2011/07/22 -----<<<<<
                // --- ADD 2011/08/03 -----<<<<<
                if (dr[4].ToString()  == "1" )
                {
                    count++;
                    continue;
                }
                // --- ADD 2011/08/03 -----<<<<<
                bool ComparerRowFlag = true;
                if (string.IsNullOrEmpty(dr[this._goodsStockDataTable.SectionCodeColumn.ColumnName].ToString()))
                {
                    _havenullsectionrow = true;// ADD 2011/08/03
                    DataRow originalDr = _originalGoodsStockDataTable.Rows[count];
                    for (int i = 0; i < this._goodsStockDataTable.Columns.Count; i++)
                    {              
                        if (!((originalDr[i]).ToString()).Equals(((dr[i]).ToString())))
                        {
                            ComparerRowFlag = false;
                            _noneflag = false;// ADD 2011/08/03
                            break;
                        }
                    }
                }

                count++;
                if (ComparerRowFlag == true && string.IsNullOrEmpty(dr[this._goodsStockDataTable.SectionCodeColumn.ColumnName].ToString()))
                    continue;

                // --- ADD 2011/07/22 -----<<<<<
                // --- DEL 2011/08/23 ----<<<<<*/
                // --- ADD 2011/08/23 ----->>>>>
                // �\���敪�u�V�K�o�^�v���Ώۋ敪�u�݌Ɂv�̏ꍇ�͘A��916�̉��C�͔��f�����
                if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New && beforeExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
                {
                    if (dr[4].ToString() == "1")
                    {
                        count++;
                        continue;
                    }
                    bool ComparerRowFlag = true;
                    if (string.IsNullOrEmpty(dr[this._goodsStockDataTable.SectionCodeColumn.ColumnName].ToString()))
                    {
                        _havenullsectionrow = true;
                        DataRow originalDr = _originalGoodsStockDataTable.Rows[count];
                        for (int i = 0; i < this._goodsStockDataTable.Columns.Count; i++)
                        {
                            if (!((originalDr[i]).ToString()).Equals(((dr[i]).ToString())))
                            {
                                ComparerRowFlag = false;
                                _noneflag = false;
                                break;
                            }
                        }
                    }

                    count++;
                    if (ComparerRowFlag == true && string.IsNullOrEmpty(dr[this._goodsStockDataTable.SectionCodeColumn.ColumnName].ToString()))
                        continue;
                }
                // --- ADD 2011/08/23 -----<<<<<

                // 1���i�A���f�[�^�̍X�V���ʃX�e�[�^�X
                int dbUpdateStatus = (int)ConstantManagement.DB_Status.ctDB_NORMAL;

                // �����ςݏ��i�`�F�b�N
                // --- DEL 2009/02/04 -------------------------------->>>>>
                //if (finishKeyDic.ContainsKey(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()))
                //{
                //    if (finishKeyDic[dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()]
                //        == (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName])
                //    {
                //        // ������
                //        continue;
                //    }
                //}
                // --- DEL 2009/02/04 --------------------------------<<<<<
                //----- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 ----->>>>>
                if (string.IsNullOrEmpty(dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString()))
                {
                    continue;
                }
                //----- ADD 2013/05/11 yangyi Redmine#35018��#53-No.7 -----<<<<<
                // --- ADD 2009/02/04 -------------------------------->>>>>
                if (finishKeyDic.ContainsKey(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()))
                {
                    if (finishKeyDic[dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()]
                        .Contains((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]))
                    {
                        // --- ADD 2009.02.18 -------------------------------->>>>>
                        // ������(����)
                        // �G���[�t���O
                        dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 0;
                        // --- ADD 2009.02.18 --------------------------------<<<<<

                        continue;
                    }
                }
                // --- ADD 2009/02/04 --------------------------------<<<<<

                // --- ADD 2009.02.18 -------------------------------->>>>>
                if (errKeyDic.ContainsKey(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()))
                {
                    if (errKeyDic[dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()]
                        .Contains((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]))
                    {
                        // ������(�G���[)
                        // �G���[�t���O
                        dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 1;

                        continue;
                    }
                }
                // --- ADD 2009.02.18 --------------------------------<<<<<

                // �X�V�p�f�[�^���X�g���擾
                methodRes = this.SetGoodsUnitDataListFromGoodsStockDataTable(dr, out goodsUnitData, out prevStockList, out rateList, beforeExtractInfo, newExtractInfo);

                try
                {
                    if (methodRes == (int)ConstantManagement.MethodResult.ctFNC_NORMAL)
                    {
                        if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                            && goodsUnitData.LogicalDeleteCode == 1)
                        {
                            // ���i�A���f�[�^�_���폜
                            dbUpdateStatus = this._goodsAcs.Delete(ref goodsUnitData, prevStockList, ref rateList, out msg);
                        }
                        else
                        {
                            // ���i�A���f�[�^�X�V(�݌ɂ̘_���폜��������)
                            dbUpdateStatus = this._goodsAcs.Write(ref goodsUnitData, prevStockList, ref rateList, out msg);
                        }
                    }
                }
                catch
                {
                    dbUpdateStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }

                // --- DEL 2009.02.18 -------------------------------->>>>>
                //// �����ς݂̃L�[�l��ۑ�
                //if (goodsUnitData != null)
                //{
                //    //finishKeyDic.Add(goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd); // DEL 2009/02/04
                //    // --- ADD 2009/02/04 -------------------------------->>>>>
                //    if (finishKeyDic.ContainsKey(goodsUnitData.GoodsNo))
                //    {
                //        finishKeyDic[goodsUnitData.GoodsNo].Add(goodsUnitData.GoodsMakerCd);
                //    }
                //    else
                //    {
                //        List<int> goodsMakerCdList = new List<int>();
                //        goodsMakerCdList.Add(goodsUnitData.GoodsMakerCd);

                //        finishKeyDic.Add(goodsUnitData.GoodsNo, goodsMakerCdList);
                //    }
                //    // --- ADD 2009/02/04 --------------------------------<<<<<

                //    // MethodResult.ctFNC_CANCEL�͊��_���폜�s���A�X�V���K�v�Ȃ��s�Ȃ̂ŃG���[�ł͂Ȃ�
                //    if ((methodRes != (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                //        && methodRes != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                //        || dbUpdateStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                //    {
                //        // �G���[�s�̏����c��
                //        errGoodsUnitDataList.Add(goodsUnitData.Clone());

                //        writeStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                //    }
                //}
                // --- DEL 2009.02.18 --------------------------------<<<<<
                // --- ADD 2009.02.18 -------------------------------->>>>>
                if ((methodRes != (int)ConstantManagement.MethodResult.ctFNC_NORMAL
                        && methodRes != (int)ConstantManagement.MethodResult.ctFNC_CANCEL)
                        || dbUpdateStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ������(�G���[)�L�[�̕ۑ�
                    if (errKeyDic.ContainsKey(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()))
                    {
                        errKeyDic[dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()]
                            .Add((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                    }
                    else
                    {
                        List<int> goodsMakerCdList = new List<int>();
                        goodsMakerCdList.Add((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);

                        errKeyDic.Add(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(), goodsMakerCdList);
                    }

                    // �G���[�t���O
                    dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 1;
                    
                    // --- ADD 2009/03/10 -------------------------------->>>>>
                    // �G���[���b�Z�[�W
                    if (!string.IsNullOrEmpty(msg))
                    {
                        msg = msg.Replace("\r\n", string.Empty);
                        dr[this._goodsStockDataTable.ErrorMessageColumn.ColumnName] = msg + " (ST = " + dbUpdateStatus + ")"; // ADD 2009/03/10
                    }
                    else
                    {
                        // �\�����Ȃ��G���[
                        dr[this._goodsStockDataTable.ErrorMessageColumn.ColumnName] = "�ۑ������ɂė�O���������܂���" + " (ST = " + dbUpdateStatus + ")"; // ADD 2009/03/10
                    }
                    // --- ADD 2009/03/10 --------------------------------<<<<<

                    // 1���ł��G���[������΃G���[��Ԃ�
                    writeStatus = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                }
                else
                {
                    // ������(����)�L�[�̕ۑ�
                    if (finishKeyDic.ContainsKey(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()))
                    {
                        finishKeyDic[dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()]
                            .Add((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                    }
                    else
                    {
                        List<int> goodsMakerCdList = new List<int>();
                        goodsMakerCdList.Add((int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);

                        finishKeyDic.Add(dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(), goodsMakerCdList);
                    }

                    // �G���[�t���O
                    dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 0;
                }
                // --- ADD 2009.02.18 --------------------------------<<<<<
            }

            #region ���G���[����
            if (writeStatus != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // --- DEL 2009.02.18 -------------------------------->>>>>
                // �G���[�s������ꍇ�A�O���b�h���N���A���Ȃ��̂Ńf�[�^�̋l�ւ����s��
                //DataTable originalBackUp = this._originalGoodsStockDataTable.Copy();
                //this._originalGoodsStockDataTable.Clear();

                //foreach (DataRow dr in this._goodsStockDataTable.Rows)
                //{
                //    bool isErrGoods = false;

                //    foreach (GoodsUnitData errGoodsUnitData in errGoodsUnitDataList)
                //    {

                //        // �G���[�s�̔���
                //        if (dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == errGoodsUnitData.GoodsNo
                //            && (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == errGoodsUnitData.GoodsMakerCd)
                //        {
                //            isErrGoods = true;
                //            break;
                //        }
                //    }

                //    if (isErrGoods)
                //    {
                //        // �G���[�s�̏ꍇ�A�X�V���f�[�^����DataRow���擾
                //        foreach (DataRow backupDr in originalBackUp.Rows)
                //        {
                //            if (backupDr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString() == dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()
                //                && (int)backupDr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] == (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName])
                //            {
                //                if (
                //                    (backupDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == null
                //                    || backupDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == DBNull.Value)
                //                    ||
                //                    backupDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString() == dr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString()
                //                    )
                //                {
                //                    // �G���[�s�̏ꍇ�A�G���[�t���O = 1
                //                    dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 1;
                //                    this._originalGoodsStockDataTable.ImportRow(backupDr);

                //                    break;
                //                }
                //            }
                //        }
                //    }
                //    else
                //    {
                //        // ���폈���s�̏ꍇ�A�G���[�t���O = 0
                //        dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] = 0;
                //        this._originalGoodsStockDataTable.ImportRow(dr);
                //    }
                //}
                // --- DEL 2009.02.18 --------------------------------<<<<<
                // --- ADD 2009.02.18 -------------------------------->>>>>
                // �G���[�s������ꍇ�A�O���b�h���N���A���Ȃ��̂Ńf�[�^�̋l�ւ����s��
                DataTable originalBackUp = this._originalGoodsStockDataTable.Copy();
                this._originalGoodsStockDataTable.Clear();

                foreach (DataRow dr in this._goodsStockDataTable.Rows)
                {
                    if ((int)dr[this._goodsStockDataTable.UpdateErrFlgColumn.ColumnName] == 0)
                    {
                        // ����s
                        this._originalGoodsStockDataTable.ImportRow(dr);
                    }
                    else
                    {
                        // �G���[�s
                        //if (dr[this._goodsStockDataTable.RowNumberColumn.ColumnName].ToString() != "�V�K") // DEL 2009/03/06
                        if (dr[this._goodsStockDataTable.RowIndexColumn.ColumnName].ToString() != "�V�K") // ADD 2009/03/06
                        {
                            DataRow[] backupDr = originalBackUp.Select(
                                //this._goodsStockDataTable.RowNumberColumn.ColumnName + " = '" + dr[this._goodsStockDataTable.RowNumberColumn.ColumnName].ToString() + "'"); // DEL 2009/03/06
                                this._goodsStockDataTable.RowIndexColumn.ColumnName + " = '" + dr[this._goodsStockDataTable.RowIndexColumn.ColumnName].ToString() + "'"); // ADD 2009/03/06

                            if (backupDr.Length != 0)
                            {
                                this._originalGoodsStockDataTable.ImportRow(backupDr[0]);
                            }
                        }
                    }
                }
                // --- ADD 2009.02.18 --------------------------------<<<<<
            }

            #endregion

            if (writeStatus == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                // �|�����X�g�͍X�V��Ď擾���K�v�Ȃ̂ŃN���A
                this._originalRateList.Clear(); // ADD 2009/02/03
            }

            return writeStatus;
        }

        #endregion

        #region �� ���S�폜����
        /// <summary>
        /// ���i���S�폜����
        /// </summary>
        /// <returns></returns>
        public int GoodsCompleteDelete(string goodsNo, int goodsMakerCd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg;

            // �X�V�p���i�A�����X�g���瓯���i�̃f�[�^���擾
            GoodsUnitData goodsUnitData = this.GetOriginalGoodsUnitData(goodsNo, goodsMakerCd);

            status = this._goodsAcs.CompleteDelete(goodsUnitData, out msg);

            return status;
        }

        /// <summary>
        /// �݌Ɋ��S�폜����
        /// </summary>
        /// <returns></returns>
        public int StockCompleteDelete(string goodsNo, int goodsMakerCd, string warehouseCd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg;

            // �X�V�p���i�A�����X�g���瓯���i�̃f�[�^���擾
            GoodsUnitData goodsUnitData = this.GetOriginalGoodsUnitData(goodsNo, goodsMakerCd);

            // prevStock���X�g���쐬
            List<Stock> prevStockList = new List<Stock>(); // ADD 2009/03/10

            // �q�ɃR�[�h�ɊY������݌ɏ����擾
            foreach (Stock stock in goodsUnitData.StockList)
            {
                prevStockList.Add(stock.Clone()); // ADD 2009/03/10

                if (stock.WarehouseCode == warehouseCd)
                {
                    stock.LogicalDeleteCode = 3;
                }
            }

            List<Rate> rateList = new List<Rate>();

            //status = this._goodsAcs.Write(ref goodsUnitData, out msg); // DEL 2009/03/10
            status = this._goodsAcs.Write(ref goodsUnitData, prevStockList, ref rateList, out msg); // ADD 2009/03/10

            return status;
        }
        #endregion

        #region �� ��������
        /// <summary>
        /// ���i��������
        /// </summary>
        /// <returns></returns>
        public int GoodsRevive(string goodsNo, int goodsMakerCd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg;

            // �X�V�p���i�A�����X�g���瓯���i�̃f�[�^���擾
            GoodsUnitData goodsUnitData = this.GetOriginalGoodsUnitData(goodsNo, goodsMakerCd);

            status = this._goodsAcs.Revival(ref goodsUnitData, out msg);

            return status;
        }

        /// <summary>
        /// �݌ɕ�������
        /// </summary>
        /// <returns></returns>
        public int StockRevive(string goodsNo, int goodsMakerCd, string warehouseCd)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            string msg;

            // �X�V�p���i�A�����X�g���瓯���i�̃f�[�^���擾
            GoodsUnitData goodsUnitData = this.GetOriginalGoodsUnitData(goodsNo, goodsMakerCd);

            // prevStock���X�g���쐬
            List<Stock> prevStockList = new List<Stock>(); // ADD 2009/04/03

            // �q�ɃR�[�h�ɊY������݌ɏ����擾
            foreach (Stock stock in goodsUnitData.StockList)
            {
                prevStockList.Add(stock.Clone()); // ADD 2009/04/03

                if (stock.WarehouseCode == warehouseCd)
                {
                    stock.LogicalDeleteCode = 0;
                }
            }

            List<Rate> rateList = new List<Rate>(); // ADD 2009/04/03

            //status = this._goodsAcs.Write(ref goodsUnitData, out msg); // DEL 2009/04/03
            status = this._goodsAcs.Write(ref goodsUnitData, prevStockList, ref rateList, out msg); // ADD 2009/04/03

            return status;
        }

        #endregion

        #region �� �L�[�d���`�F�b�N
        /// <summary>
        /// �L�[�d���`�F�b�N���s��
        /// </summary>
        /// <param name="goodsNo">�i��</param>
        /// <param name="makerCd">���[�J�[</param>
        /// <param name="warehouseCd">�q�ɃR�[�h(���i�`�F�b�N����string.Empty)</param>
        /// <returns>true�F�L�[�d�������Afalse�F�L�[�d������</returns>
        /// <remarks>
        /// <br>�V�K�ǉ��s�p</br>
        /// </remarks>
        public bool CheckKeyDuplication(string goodsNo, int makerCd, string warehouseCd)
        {
            List<GoodsUnitData> goodsUnitDataList;
            //PartsInfoDataSet partsInfoDataSet; // DEL 2009/03/03
            string msg;
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsNo = goodsNo;
            goodsCndtn.GoodsMakerCd = makerCd;

            goodsCndtn.IsSettingSupplier = 1;  // ADD 2009/02/16
            goodsCndtn.IsSettingVariousMst = 1;  // ADD 2009/02/16

            //int status = this._goodsAcs.SearchPartsFromGoodsNoWholeWord(goodsCndtn, out partsInfoDataSet, out goodsUnitDataList, out msg); // DEL 2009/03/03
            int status = this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out goodsUnitDataList, out msg); // ADD 2009/03/03

            if (goodsUnitDataList.Count == 0)
            {
                // �Y�����Ȃ���Ώd������
                return true;
            }
            else
            {
                if (warehouseCd == string.Empty)
                {
                    // ���i�`�F�b�N�̏ꍇ�A�Y���i�L�[�d���j����
                    return false;
                }
                else
                {
                    if (goodsUnitDataList[0].StockList == null
                        || goodsUnitDataList[0].StockList.Count == 0)
                    {
                        // �݌ɂ��Ȃ��̂ŃL�[�d������
                        return true;
                    }
                    else
                    {
                        foreach (Stock stock in goodsUnitDataList[0].StockList)
                        {
                            if (stock.WarehouseCode == warehouseCd)
                            {
                                // �����q�ɂ�����ꍇ�A�Y���i�L�[�d���j����
                                return false;
                            }
                        }

                        return true;
                    }
                }
            }
        }
        #endregion

        #endregion

        #region ��private���\�b�h

        #region �� �����n����
        /// <summary>
        /// �|���D��Ǘ��}�X�^���擾����
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>�|���D��Ǘ������������A�Y�����R�[�h�̗L����Ԃ�</br>
        /// </remarks>
        private bool SearchRateProtyMng()
        {
            int status;
            ArrayList retList;
            int retCount;
            bool nextData;
            string errMsg;

            // ���O�C�����_�Ō���
            status = this._rateProtyMngAcs.Search(
                out retList, out retCount, out nextData, this._enterpriseCode, this._loginSectionCode, out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && retList.Count != 0)
            {
                foreach (RateProtyMng rateProtyMng in retList)
                {
                    if (rateProtyMng.UnitPriceKind == Convert.ToInt32(CT_UnitPriceKind) 
                        && rateProtyMng.SectionCode == this._loginSectionCode// ADD ���H�� 2011/12/31 Redmine#27530
                        && rateProtyMng.RateSettingDivide == CT_RateSettingDivide)
                    {
                        return true;
                    }
                }
            }

            // �S�Аݒ�Ō���
            status = this._rateProtyMngAcs.Search(
                out retList, out retCount, out nextData, this._enterpriseCode, "00", out errMsg);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
                && retList.Count != 0)
            {
                foreach (RateProtyMng rateProtyMng in retList)
                {
                    if (rateProtyMng.UnitPriceKind == Convert.ToInt32(CT_UnitPriceKind)
                        && rateProtyMng.SectionCode.Equals("00")// ADD ���H�� 2011/12/31 Redmine#27530
                        && rateProtyMng.RateSettingDivide == CT_RateSettingDivide)
                    {
                        return true;
                    }
                }
            }

            // ���݂��Ȃ�
            return false;
        }

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// ���i�A���f�[�^(�񋟕�)����A���[�U�f�[�^�ɓo�^�̂���f�[�^�����O����
        ///// </summary>
        ///// <returns>���i�A���f�[�^(�񋟕��̂�)</returns>
        //private List<GoodsUnitData> GetOfferGoodsUnitData(List<GoodsUnitData> goodsUnitDataList)
        //{
        //    List<GoodsUnitData> offerGoodsUnitDataList = new List<GoodsUnitData>();
        //    string errMsg;

        //    foreach (GoodsUnitData goodsUnitData in goodsUnitDataList)
        //    {
        //        // ���[�U�f�[�^
        //        GoodsCndtn goodsCndtn = new GoodsCndtn();

        //        goodsCndtn.EnterpriseCode = this._enterpriseCode;
        //        goodsCndtn.GoodsNo = goodsUnitData.GoodsNo;
        //        goodsCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd;

        //        List<GoodsUnitData> userGoodsUnitDataList;

        //        this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out userGoodsUnitDataList, out errMsg);

        //        if (userGoodsUnitDataList.Count == 0)
        //        {
        //            // ���[�U�f�[�^�ɓ������i��������Ε\���Ώۂɒǉ�
        //            offerGoodsUnitDataList.Add(goodsUnitData);
        //        }
        //    }

        //    return offerGoodsUnitDataList;
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        // --- ADD 2009/02/04 -------------------------------->>>>>
        /// <summary>
        /// ���i�A���f�[�^�i���[�U���j���݃`�F�b�N
        /// </summary>
        /// <param name="goodsUnitData">���i�A���f�[�^(�񋟕�)</param>
        /// <returns>true:���[�U�f�[�^�ɂȂ� false�F���[�U�f�[�^�ɂ���</returns>
        /// <remarks>
        /// <br>���i�A���f�[�^(�񋟕�)�����[�U���ɂ����݂��邩�`�F�b�N����</br>
        /// </remarks>
        private bool CheckOfferGoodsUnitData(GoodsUnitData goodsUnitData)
        {
            string errMsg;

            // ���[�U�f�[�^
            GoodsCndtn goodsCndtn = new GoodsCndtn();

            goodsCndtn.EnterpriseCode = this._enterpriseCode;
            goodsCndtn.GoodsNo = goodsUnitData.GoodsNo;
            goodsCndtn.GoodsMakerCd = goodsUnitData.GoodsMakerCd;

            // ���i���� (0,1����)
            goodsCndtn.GoodsKindCode = 9;

            goodsCndtn.IsSettingSupplier = 1; // ADD 2009/02/16
            goodsCndtn.IsSettingVariousMst = 1; // ADD 2009/02/16

            List<GoodsUnitData> userGoodsUnitDataList;

            this._goodsAcs.Search(goodsCndtn, ConstantManagement.LogicalMode.GetData01, out userGoodsUnitDataList, out errMsg);

            if (userGoodsUnitDataList.Count == 0)
            {
                return true;
            }

            return false;
        }
        // --- ADD 2009/02/04 --------------------------------<<<<<

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// �݌ɓo�^�̂Ȃ����i�݂̂��擾
        ///// </summary>
        ///// <param name="goodsUnitDataList"></param>
        ///// <param name="extractInfo"></param>
        ///// <returns></returns>
        //private void FilterGoodsUnitDataByNoGoods(List<GoodsUnitData> goodsUnitDataList)
        //{
        //    for (int i = goodsUnitDataList.Count - 1; i >= 0; i--)
        //    {
        //        if (goodsUnitDataList[i].LogicalDeleteCode != 0
        //            ||
        //            (goodsUnitDataList[i].StockList != null
        //            && goodsUnitDataList[i].StockList.Count != 0)
        //            )
        //        {
        //            goodsUnitDataList.RemoveAt(i);
        //        }
        //    }
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        // --- DEL 2009/03/10 -------------------------------->>>>>
        // --- ADD 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// �݌ɓo�^�̂Ȃ����i�݂̂��擾
        ///// </summary>
        ///// <param name="goodsUnitDataList"></param>
        ///// <param name="extractInfo"></param>
        ///// <returns>true:�݌ɂȂ� false�F�݌ɂ���</returns>
        //private bool CheckGoodsUnitDataByNoGoods(GoodsUnitData goodsUnitData)
        //{
        //    if (goodsUnitData.LogicalDeleteCode != 0
        //        ||
        //        (goodsUnitData.StockList != null
        //        && goodsUnitData.StockList.Count != 0)
        //        )
        //    {
        //        return false;
        //    }

        //    return true;
        //}
        //// --- ADD 2009/02/04 --------------------------------<<<<<
        // --- DEL 2009/03/10 --------------------------------<<<<<
        // --- ADD 2009/03/10 -------------------------------->>>>>
        /// <summary>
        /// �V�K�o�^�A�݌ɂ̏ꍇ�̃t�B���^����
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="extractInfo"></param>
        /// <returns></returns>
        private bool FilterGoodsUnitDataForNewStock(GoodsUnitData goodsUnitData, ExtractInfo extractInfo)
        {
            if (goodsUnitData.LogicalDeleteCode != 0)
            {
                return false;
            }

            if (goodsUnitData.StockList == null
                || goodsUnitData.StockList.Count == 0)
            {
                return true;
            }

            List<Stock> stockList = goodsUnitData.StockList;

            // �w��q�ɁA���_�ȊO�̍݌ɏ�������
            for (int i = stockList.Count - 1; i >= 0; i--)
            {
                if (stockList[i].WarehouseCode.Trim() != extractInfo.WarehouseCode.Trim())
                {
                    stockList.RemoveAt(i);
                }
            }

            if (stockList.Count == 0)
            {
                // ���q�ɂ������ꍇ�͕\���Ώ�
                return true;
            }
            else
            {
                if (stockList[0].LogicalDeleteCode != 0
                    || stockList[0].SectionCode.Trim().PadLeft(2, '0') == extractInfo.AddUpSectionCode.Trim())
                {
                    return false;
                }
                else
                {
                    // �����_�łȂ����_���폜�Ŗ����ꍇ�A�\���Ώ�
                    return true;
                }
            }
        }
        // --- ADD 2009/03/10 --------------------------------<<<<<

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// ���o�����u�q�Ɂv�u�Ǘ����_�v�ɍ��v���鏤�i�݌ɂ݂̂��擾
        ///// </summary>
        ///// <param name="goodsUnitDataList"></param>
        ///// <remarks>�݌ɗL���`�F�b�N�̌�ɌĂ΂��̂ŁA�݌ɂ����݂��邱�Ƃ�O��Ƃ���</remarks>
        //private void FilterGoodsUnitDataByExtractInfo(List<GoodsUnitData> goodsUnitDataList, ExtractInfo extractInfo)
        //{
        //    foreach(GoodsUnitData goodsUnitData in goodsUnitDataList)
        //    {
        //        List<Stock> stockList = goodsUnitData.StockList;

        //        for (int i = stockList.Count - 1; i >= 0; i--)
        //        {
        //            if (!string.IsNullOrEmpty(extractInfo.WarehouseCode)
        //                && !string.IsNullOrEmpty(extractInfo.SectionCode))
        //            {
        //                if (stockList[i].WarehouseCode != extractInfo.WarehouseCode
        //                    || stockList[i].SectionCode != extractInfo.AddUpSectionCode)
        //                {
        //                    stockList.RemoveAt(i);
        //                }
        //            }
        //            else if (!string.IsNullOrEmpty(extractInfo.WarehouseCode))
        //            {
        //                if (stockList[i].WarehouseCode != extractInfo.WarehouseCode)
        //                {
        //                    stockList.RemoveAt(i);
        //                }
        //            }
        //            else if (!string.IsNullOrEmpty(extractInfo.SectionCode))
        //            {
        //                if (stockList[i].SectionCode != extractInfo.AddUpSectionCode)
        //                {
        //                    stockList.RemoveAt(i);
        //                }
        //            }
        //        }
        //    }
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        // --- ADD 2009/02/04 -------------------------------->>>>>
        /// <summary>
        /// ���o�����u�q�Ɂv�u�Ǘ����_�v�ɍ��v���鏤�i�݌ɂ݂̂��擾
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        private void FilterGoodsUnitDataByExtractInfo(GoodsUnitData goodsUnitData, ExtractInfo extractInfo)
        {
            List<Stock> stockList = goodsUnitData.StockList;

            if (stockList == null)
            {
                return;
            }

            for (int i = stockList.Count - 1; i >= 0; i--)
            {
                if (!string.IsNullOrEmpty(extractInfo.WarehouseCode)
                    //&& !string.IsNullOrEmpty(extractInfo.SectionCode)) // DEL 2009/03/10
                    && !string.IsNullOrEmpty(extractInfo.AddUpSectionCode)) // ADD 2009/03/10
                {
                    if (stockList[i].WarehouseCode != extractInfo.WarehouseCode
                        || stockList[i].SectionCode != extractInfo.AddUpSectionCode)
                    {
                        stockList.RemoveAt(i);
                    }
                }
                else if (!string.IsNullOrEmpty(extractInfo.WarehouseCode))
                {
                    if (stockList[i].WarehouseCode != extractInfo.WarehouseCode)
                    {
                        stockList.RemoveAt(i);
                    }
                }
                //else if (!string.IsNullOrEmpty(extractInfo.SectionCode)) // DEL 2009/03/10
                else if (!string.IsNullOrEmpty(extractInfo.AddUpSectionCode)) // ADD 2009/03/10
                {
                    if (stockList[i].SectionCode != extractInfo.AddUpSectionCode)
                    {
                        stockList.RemoveAt(i);
                    }
                }
            }
        }
        // --- ADD 2009/02/04 --------------------------------<<<<<

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// �݌ɓo�^�̂��鏤�i�݂̂��擾
        ///// </summary>
        ///// <param name="goodsUnitDataList"></param>
        ///// <param name="extractInfo"></param>
        ///// <returns></returns>
        //private void FilterGoodsUnitDataByExistGoods(List<GoodsUnitData> goodsUnitDataList)
        //{
        //    for (int i = goodsUnitDataList.Count - 1; i >= 0; i--)
        //    {
        //        if (goodsUnitDataList[i].LogicalDeleteCode != 0
        //            || goodsUnitDataList[i].StockList == null
        //            || goodsUnitDataList[i].StockList.Count == 0)
        //        {
        //            goodsUnitDataList.RemoveAt(i);
        //        }
        //    }
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        // --- ADD 2009/02/04 -------------------------------->>>>>
        /// <summary>
        /// �݌ɓo�^�̂��鏤�i�݂̂��擾
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <param name="extractInfo"></param>
        /// <returns>true:�݌ɂ��� false:�݌ɂȂ�</returns>
        private bool FilterGoodsUnitDataByExistGoods(GoodsUnitData goodsUnitData)
        {
            if (goodsUnitData.LogicalDeleteCode != 0
                || goodsUnitData.StockList == null
                || goodsUnitData.StockList.Count == 0)
            {
                return false;
            }

            return true;
        }
        // --- ADD 2009/02/04 --------------------------------<<<<<

        /// <summary>
        /// �o�͎w��ɂ��t�B���^����
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        /// <returns></returns>
        private void FilterGoodsUnitDataByOutputDiv(ExtractInfo extractInfo)
        {
            string fillStr = string.Empty;

            if (extractInfo.OutputDiv == ExtractInfo.OutputDivState.UserPrice)
            {
                // ���[�U���i�A���iUP��(�|���}�X�^)�ɒl���ݒ肳��Ă���
                fillStr = this._goodsStockDataTable.PriceFlColumn.ColumnName + " <> 0 OR "
                         + this._goodsStockDataTable.UpRateColumn.ColumnName + " <> 0";
            }
            else if (extractInfo.OutputDiv == ExtractInfo.OutputDivState.CostPrice)
            {
                // ���P��1,2,3�̉��ꂩ�ɒl���ݒ肳��Ă���
                fillStr = this._goodsStockDataTable.SalesUnitCost1Column.ColumnName + " <> 0 OR "
                         + this._goodsStockDataTable.SalesUnitCost2Column.ColumnName + " <> 0 OR "
                         + this._goodsStockDataTable.SalesUnitCost3Column.ColumnName + " <> 0";
            }

            DataTable tmpTable = this._goodsStockDataTable.Copy();
            this._goodsStockDataTable.Clear();

            //DataRow[] drList = tmpTable.Select(fillStr, this._goodsStockDataTable.RowNumberColumn.ColumnName); // DEL 2009/03/06
            DataRow[] drList = tmpTable.Select(fillStr); // ADD 2009/03/06

            foreach (DataRow dr in drList)
            {
                this._goodsStockDataTable.ImportRow(dr);
            }
        }

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// ���i�A���f�[�^���珤�i�݌Ƀe�[�u���ւ̃f�[�^�l�֏���
        ///// </summary>
        ///// <param name="goodsUnitDataList"></param>
        //private void SetGoodsStockDataTableFromGoodsUnitDataList(List<GoodsUnitData> goodsUnitDataList, ExtractInfo extractInfo)
        //{
        //    // �e�[�u���̏�����
        //    this._goodsStockDataTable.Clear();

        //    for (int i = 0; i < goodsUnitDataList.Count; i++)
        //    {
        //        GoodsUnitData goodsUnitData = goodsUnitDataList[i];

        //        if (extractInfo.TargetDiv != ExtractInfo.TargetDivState.Goods
        //            && 
        //            (goodsUnitData.StockList != null && goodsUnitData.StockList.Count != 0)
        //            )
        //        {
        //            // �Ώۋ敪�u���i-�݌Ɂv�A�u�݌�-���i�v�ō݌Ƀ��X�g�����݂���ꍇ
        //            for (int j = 0; j < goodsUnitData.StockList.Count; j++)
        //            {
        //                // ���R�[�h�͍݌ɒP�ʂō쐬
        //                Stock stock = goodsUnitData.StockList[j];

        //                this.SetGoodsStockDataRow(goodsUnitData, stock);
        //            }
        //        }
        //        else
        //        {
        //            // �Ώۋ敪�u���i�v�܂��͍݌Ƀ��X�g�����݂��Ȃ�
        //            this.SetGoodsStockDataRow(goodsUnitData, null);
        //        }
        //    }
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        /// <summary>
        /// �݌Ƀf�[�^���珤�i�݌Ƀe�[�u���ւ̃f�[�^�l�֏���
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        private void SetGoodsStockDataTableFromStockList(List<Stock> stockList)
        {
            // �e�[�u���̏�����
            this._goodsStockDataTable.Clear();

            foreach (Stock stock in stockList)
            {
                // �݌ɏ��̂ݐݒ�
                this.SetGoodsStockDataRow(null, stock);
            }
        }

        /// <summary>
        /// ���i�A���f�[�^�A�݌Ƀf�[�^���A���i�݌Ƀe�[�u��1���R�[�h�̐ݒ���s���B
        /// </summary>
        /// <param name="goodsUnitDataList"></param>
        private void SetGoodsStockDataRow(GoodsUnitData goodsUnitData, Stock stock)
        {
            DataRow dr = this._goodsStockDataTable.NewRow();

            if (goodsUnitData != null)
            {
                dr[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] = goodsUnitData.LogicalDeleteCode; // �_���폜�t���O
                if (goodsUnitData.LogicalDeleteCode != 0)
                {
                    // �_���폜�f�[�^�̏ꍇ�A�폜����ݒ�
                    dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] = goodsUnitData.UpdateDate; // ���i�폜��(�X�V��)
                }
                dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName] = goodsUnitData.GoodsNo; // �i��
                dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName] = goodsUnitData.GoodsName; // �i��
                dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName] = goodsUnitData.GoodsMakerCd; // ���[�J�[�R�[�h
                dr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName] = goodsUnitData.MakerName; // ���[�J�[��
                dr[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName] = goodsUnitData.GoodsNameKana; // �i���J�i
                dr[this._goodsStockDataTable.JanColumn.ColumnName] = goodsUnitData.Jan; // JAN�R�[�h
                dr[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName] = goodsUnitData.BLGoodsCode; // BL�R�[�h
                dr[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName] = this.GetBLGoodsHalfName(goodsUnitData.BLGoodsCode); // BL�R�[�h��
                dr[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName] = goodsUnitData.EnterpriseGanreCode;
                dr[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName] = goodsUnitData.EnterpriseGanreName;
                dr[this._goodsStockDataTable.GoodsRateRankColumn.ColumnName] = goodsUnitData.GoodsRateRank;
                dr[this._goodsStockDataTable.GoodsKindCodeColumn.ColumnName] = goodsUnitData.GoodsKindCode;
                dr[this._goodsStockDataTable.TaxationDivCdColumn.ColumnName] = goodsUnitData.TaxationDivCd;
                dr[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName] = goodsUnitData.GoodsMGroup;
                dr[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName] = goodsUnitData.GoodsMGroupName;
                dr[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName] = goodsUnitData.BLGroupCode;
                dr[this._goodsStockDataTable.BLGroupNameColumn.ColumnName] = goodsUnitData.BLGroupName;
                if (goodsUnitData.GoodsPriceList.Count != 0)
                {
                    dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[0].PriceStartDate);
                    dr[this._goodsStockDataTable.ListPrice1Column.ColumnName] = goodsUnitData.GoodsPriceList[0].ListPrice;
                    dr[this._goodsStockDataTable.OpenPriceDiv1Column.ColumnName] = goodsUnitData.GoodsPriceList[0].OpenPriceDiv;
                    dr[this._goodsStockDataTable.StockRate1Column.ColumnName] = goodsUnitData.GoodsPriceList[0].StockRate;
                    dr[this._goodsStockDataTable.SalesUnitCost1Column.ColumnName] = goodsUnitData.GoodsPriceList[0].SalesUnitCost;
                    dr[this._goodsStockDataTable.OfferDate1Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[0].OfferDate); // ADD 2010/08/31
                    if (goodsUnitData.GoodsPriceList.Count != 1)
                    {
                        dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[1].PriceStartDate);
                        dr[this._goodsStockDataTable.ListPrice2Column.ColumnName] = goodsUnitData.GoodsPriceList[1].ListPrice;
                        dr[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName] = goodsUnitData.GoodsPriceList[1].OpenPriceDiv;
                        dr[this._goodsStockDataTable.StockRate2Column.ColumnName] = goodsUnitData.GoodsPriceList[1].StockRate;
                        dr[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName] = goodsUnitData.GoodsPriceList[1].SalesUnitCost;
                        dr[this._goodsStockDataTable.OfferDate2Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[1].OfferDate); // ADD 2010/08/31
                        if (goodsUnitData.GoodsPriceList.Count != 2)
                        {
                            dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[2].PriceStartDate);
                            dr[this._goodsStockDataTable.ListPrice3Column.ColumnName] = goodsUnitData.GoodsPriceList[2].ListPrice;
                            dr[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName] = goodsUnitData.GoodsPriceList[2].OpenPriceDiv;
                            dr[this._goodsStockDataTable.StockRate3Column.ColumnName] = goodsUnitData.GoodsPriceList[2].StockRate;
                            dr[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName] = goodsUnitData.GoodsPriceList[2].SalesUnitCost;
                            dr[this._goodsStockDataTable.OfferDate3Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[2].OfferDate); // ADD 2010/08/31

                            // --- ADD 2010/08/11 ---------->>>>>
                            if (goodsUnitData.GoodsPriceList.Count != 3)
                            {
                                dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[3].PriceStartDate);
                                dr[this._goodsStockDataTable.ListPrice4Column.ColumnName] = goodsUnitData.GoodsPriceList[3].ListPrice;
                                dr[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName] = goodsUnitData.GoodsPriceList[3].OpenPriceDiv;
                                dr[this._goodsStockDataTable.StockRate4Column.ColumnName] = goodsUnitData.GoodsPriceList[3].StockRate;
                                dr[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName] = goodsUnitData.GoodsPriceList[3].SalesUnitCost;
                                dr[this._goodsStockDataTable.OfferDate4Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[3].OfferDate); // ADD 2010/08/31

                                if (goodsUnitData.GoodsPriceList.Count != 4)
                                {
                                    dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[4].PriceStartDate);
                                    dr[this._goodsStockDataTable.ListPrice5Column.ColumnName] = goodsUnitData.GoodsPriceList[4].ListPrice;
                                    dr[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName] = goodsUnitData.GoodsPriceList[4].OpenPriceDiv;
                                    dr[this._goodsStockDataTable.StockRate5Column.ColumnName] = goodsUnitData.GoodsPriceList[4].StockRate;
                                    dr[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName] = goodsUnitData.GoodsPriceList[4].SalesUnitCost;
                                    dr[this._goodsStockDataTable.OfferDate5Column.ColumnName] = ConvertLongDateFromDateTime(goodsUnitData.GoodsPriceList[4].OfferDate); // ADD 2010/08/31
                                }
                            }

                            // --- ADD 2010/08/11 ----------<<<<<
                        }
                    }
                }

                // �|���}�X�^���
                this.GetRateInfo(ref dr, goodsUnitData.GoodsNo, goodsUnitData.GoodsMakerCd);
            }

            // �݌ɏ��
            if (stock != null)
            {
                dr[_goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] = stock.LogicalDeleteCode; // �_���폜�t���O

                if (stock.LogicalDeleteCode != 0)
                {
                    // �_���폜�f�[�^�̏ꍇ�A�폜����ݒ�
                    dr[_goodsStockDataTable.StockDeleteDateColumn.ColumnName] = stock.UpdateDate; // ���i�폜��(�X�V��)
                }
                dr[_goodsStockDataTable.OriginalWarehouseCodeColumn.ColumnName] = stock.WarehouseCode.Trim().PadLeft(4, '0');
                dr[_goodsStockDataTable.WarehouseCodeColumn.ColumnName] = stock.WarehouseCode.Trim().PadLeft(4, '0');
                dr[_goodsStockDataTable.WarehouseNameColumn.ColumnName] = stock.WarehouseName;
                // --- ADD 2009/03/10 -------------------------------->>>>>
                dr[_goodsStockDataTable.SectionCodeColumn.ColumnName] = stock.SectionCode.Trim().PadLeft(2, '0');
                /* ---------------- DEL gezh 2013/01/24 Redmine#33361 Client�[�̉��C�ć@ ---------->>>>>
                SecInfoSet secInfoSet;
                int status = this._secInfoSetAcs.Read(out secInfoSet, this._enterpriseCode, stock.SectionCode.Trim().PadLeft(2, '0'));
                <<<<<-------------- DEL gezh 2013/01/24 Redmine#33361 Client�[�̉��C�ć@ ------------ */
                // ADD gezh 2013/01/24 Redmine#33361 Client�[�̉��C�ć@ ----->>>>>
                if (this._sectionDic == null)
                {
                    this.ReadSecInfoSet();
                }

                SecInfoSet secInfoSet;
                this._sectionDic.TryGetValue(stock.SectionCode.Trim().PadLeft(2, '0'), out secInfoSet);
                // ADD gezh 2013/01/24 Redmine#33361 Client�[�̉��C�ć@ -----<<<<<
                if (secInfoSet != null)
                {
                    dr[_goodsStockDataTable.SectionGuideSnmColumn.ColumnName] = secInfoSet.SectionGuideSnm;
                }
                // --- ADD 2009/03/10 --------------------------------<<<<<
                dr[_goodsStockDataTable.WarehouseShelfNoColumn.ColumnName] = stock.WarehouseShelfNo;
                dr[_goodsStockDataTable.DuplicationShelfNo1Column.ColumnName] = stock.DuplicationShelfNo1;
                dr[_goodsStockDataTable.DuplicationShelfNo2Column.ColumnName] = stock.DuplicationShelfNo2;
                //dr[_goodsStockDataTable.PartsManagementDivide1Column.ColumnName] = stock.PartsManagementDivide1;//DEL 2011/08/03
                dr[_goodsStockDataTable.PartsManagementDivide1Column.ColumnName] = string.IsNullOrEmpty((stock.PartsManagementDivide1).Trim()) ? "0" : stock.PartsManagementDivide1;//ADD 2011/08/03
                //dr[_goodsStockDataTable.PartsManagementDivide2Column.ColumnName] = stock.PartsManagementDivide2;//DEL 2011/08/03
                dr[_goodsStockDataTable.PartsManagementDivide2Column.ColumnName] = string.IsNullOrEmpty((stock.PartsManagementDivide2).Trim()) ? "0" : stock.PartsManagementDivide2;//ADD 2011/08/03
                dr[_goodsStockDataTable.StockSupplierCodeColumn.ColumnName] = stock.StockSupplierCode;
                dr[_goodsStockDataTable.StockSupplierSnmColumn.ColumnName] = this.GetSupplierSnm(stock.StockSupplierCode);
                dr[_goodsStockDataTable.StockDivColumn.ColumnName] = stock.StockDiv;
                dr[_goodsStockDataTable.SalesOrderUnitColumn.ColumnName] = stock.SalesOrderUnit;
                dr[_goodsStockDataTable.MinimumStockCntColumn.ColumnName] = stock.MinimumStockCnt;
                dr[_goodsStockDataTable.MaximumStockCntColumn.ColumnName] = stock.MaximumStockCnt;
                dr[_goodsStockDataTable.SupplierStockColumn.ColumnName] = stock.SupplierStock;
                dr[_goodsStockDataTable.ArrivalCntColumn.ColumnName] = stock.ArrivalCnt;
                dr[_goodsStockDataTable.ShipmentCntColumn.ColumnName] = stock.ShipmentCnt;
                dr[_goodsStockDataTable.AcpOdrCountColumn.ColumnName] = stock.AcpOdrCount;
                dr[_goodsStockDataTable.MovingSupliStockColumn.ColumnName] = stock.MovingSupliStock;
                dr[_goodsStockDataTable.NowStockCntColumn.ColumnName] = stock.SupplierStock
                                                                      + stock.ArrivalCnt - stock.ShipmentCnt
                                                                      - stock.AcpOdrCount - stock.MovingSupliStock;
                // --- ADD 2009/03/05 -------------------------------->>>>>
                dr[_goodsStockDataTable.OriginalStockUnitPriceFlColumn.ColumnName] = stock.StockUnitPriceFl;
                dr[_goodsStockDataTable.StockUnitPriceFlColumn.ColumnName] = stock.StockUnitPriceFl;
                // --- ADD 2009/03/05 --------------------------------<<<<<

            }
            else
            {
                //-----ADD 2011/08/03---------->>>>>
                dr[_goodsStockDataTable.PartsManagementDivide1Column.ColumnName] = "0";
                dr[_goodsStockDataTable.PartsManagementDivide2Column.ColumnName] = "0";
                //-----ADD 2011/08/03----------<<<<<
            }

            this._goodsStockDataTable.Rows.Add(dr);
        }

        /// <summary>
        /// �|���}�X�^�̍��ڎ擾
        /// </summary>
        /// <param name="dr"></param>
        private void GetRateInfo(ref DataRow dr, string goodsNo, int goodsMakerCd)
        {
            // --- DEL 2009/02/04 -------------------------------->>>>>
            //int status;

            //// �����ς݂̊|����񂪂���Ύ擾
            //Rate orgRate = this.GetOriginalRate(goodsNo, goodsMakerCd);

            //if (orgRate != null)
            //{
            //    dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = orgRate.PriceFl;
            //    dr[_goodsStockDataTable.UpRateColumn.ColumnName] = orgRate.UpRate;

            //    return;
            //}

            //ArrayList retList;
            //string errMsg;

            //// ���O�C�����_�ł̌���
            //// �����ݒ�
            //Rate rate = new Rate();
            //rate.EnterpriseCode = this._enterpriseCode;
            //rate.UnitPriceKind = CT_UnitPriceKind;
            //rate.RateSettingDivide = CT_RateSettingDivide;
            //rate.UnitRateSetDivCd = CT_UnitRateSetDivCd;
            //rate.SectionCode = this._loginSectionCode; // ���_�R�[�h
            //rate.GoodsNo = goodsNo;
            //rate.GoodsMakerCd = goodsMakerCd;

            //status = this._rateAcs.SearchAll(out retList, ref rate, out errMsg);

            //if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
            //    && retList.Count != 0)
            //{
            //    // ���O�C�����_�ŊY��������΁A���X�g�ɕۑ�
            //    this._originalRateList.Add((Rate)retList[0]);
            //}
            //else
            //{
            //    // ���O�C�����_�ő��݂��Ȃ��ꍇ�A�S�Аݒ�Ō���
            //    rate.SectionCode = "00";

            //    status = this._rateAcs.SearchAll(out retList, ref rate, out errMsg);

            //    if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL
            //        && retList.Count != 0)
            //    {
            //        // �S�Аݒ�ŊY��������΁A���X�g�ɕۑ�
            //        this._originalAllSectionRateList.Add((Rate)retList[0]);
            //    }
            //}

            //if (retList.Count != 0)
            //{
            //    Rate retRate = (Rate)retList[0];

            //    dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = retRate.PriceFl;
            //    dr[_goodsStockDataTable.UpRateColumn.ColumnName] = retRate.UpRate;
            //}
            // --- DEL 2009/02/04 --------------------------------<<<<<
            // --- DEL 2009/02/16 -------------------------------->>>>>
            //// --- ADD 2009/02/04 -------------------------------->>>>>
            //// ���O�C�����_�ŊY��������ΐݒ�
            //foreach (Rate rate in this._originalRateList)
            //{
            //    if (rate.SectionCode.TrimEnd() == this._loginSectionCode.TrimEnd()
            //        && rate.GoodsNo == goodsNo
            //        && rate.GoodsMakerCd == goodsMakerCd)
            //    {
            //        dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = rate.PriceFl;
            //        dr[_goodsStockDataTable.UpRateColumn.ColumnName] = rate.UpRate;

            //        return;
            //    }
            //}

            //// �S�Аݒ�ŊY��������ΐݒ�
            //foreach (Rate rate in this._originalRateList)
            //{
            //    if (rate.SectionCode.TrimEnd() == "00"
            //        && rate.GoodsNo == goodsNo
            //        && rate.GoodsMakerCd == goodsMakerCd)
            //    {
            //        dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = rate.PriceFl;
            //        dr[_goodsStockDataTable.UpRateColumn.ColumnName] = rate.UpRate;

            //        return;
            //    }
            //}
            //// --- ADD 2009/02/04 --------------------------------<<<<<
            // --- DEL 2009/02/16 --------------------------------<<<<<
            // --- ADD 2009/02/16 -------------------------------->>>>>
            // ���O�C�����_�ŊY��������ΐݒ�
            Rate rate = null;
            rate = this._originalRateList.Find(
                delegate(Rate orgRate)
                {
                    if ((orgRate.GoodsNo == goodsNo) &&
                        (orgRate.GoodsMakerCd == goodsMakerCd) &&
                        (orgRate.SectionCode.TrimEnd() == this._loginSectionCode.TrimEnd()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (rate != null)
            {
                dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = rate.PriceFl;
                dr[_goodsStockDataTable.UpRateColumn.ColumnName] = rate.UpRate;
                return;
            }

            // �S�Аݒ�ŊY��������ΐݒ�
            rate = null;
            rate = this._originalRateList.Find(
                delegate(Rate orgRate)
                {
                    if ((orgRate.GoodsNo == goodsNo) &&
                        (orgRate.GoodsMakerCd == goodsMakerCd) &&
                        (orgRate.SectionCode.TrimEnd() == "00"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            if (rate != null)
            {
                dr[_goodsStockDataTable.PriceFlColumn.ColumnName] = rate.PriceFl;
                dr[_goodsStockDataTable.UpRateColumn.ColumnName] = rate.UpRate;
                return;
            }
            // --- ADD 2009/02/16 --------------------------------<<<<<
        }

        /// <summary>
        /// �d���旪�̎擾
        /// </summary>
        /// <param name="supplierCd"></param>
        /// <returns></returns>
        private string GetSupplierSnm(int supplierCd)
        {
            // --- DEL 2009/02/04 -------------------------------->>>>>
            //Supplier supplier;

            //int status = this._supplierAcs.Read(out supplier, this._enterpriseCode, supplierCd); 

            //if (status == 0)
            //{
            //    return supplier.SupplierSnm;
            //}

            //return string.Empty;
            // --- DEL 2009/02/04 --------------------------------<<<<<
            // --- ADD 2009/02/04 -------------------------------->>>>>
            if (this._supplierList == null)
            {
                this._supplierList = new Dictionary<int, string>();
 
                ArrayList arrayList;
                this._supplierAcs.SearchAll(out arrayList, this._enterpriseCode);

                foreach (Supplier supplier in arrayList)
                {
                    this._supplierList.Add(supplier.SupplierCd, supplier.SupplierSnm);
                }
            }

            if (this._supplierList.ContainsKey(supplierCd))
            {
                return this._supplierList[supplierCd];
            }

            return string.Empty;
            // --- ADD 2009/02/04 --------------------------------<<<<<
        }

        /// <summary>
        /// BL�R�[�h����(�J�i)�擾
        /// </summary>
        /// <param name="supplierCd"></param>
        /// <returns></returns>
        private string GetBLGoodsHalfName(int blGoodsCd)
        {
            // --- DEL 2009/02/04 -------------------------------->>>>>
            //BLGoodsCdUMnt blGoodsCdUMnt;

            //int status = this._blGoodsCdAcs.Read(out blGoodsCdUMnt, this._enterpriseCode, blGoodsCd);

            //if (status == 0)
            //{
            //    return blGoodsCdUMnt.BLGoodsHalfName;
            //}

            //return string.Empty;
            // --- DEL 2009/02/04 --------------------------------<<<<<
            // --- ADD 2009/02/04 -------------------------------->>>>>
            if (this._blGoodsCdUMntList == null)
            {
                this._blGoodsCdUMntList = new Dictionary<int, string>();

                ArrayList arrList;
                this._blGoodsCdAcs.SearchAll(out arrList, this._enterpriseCode);

                foreach (BLGoodsCdUMnt blGoodsCdUMnt in arrList)
                {
                    this._blGoodsCdUMntList.Add(blGoodsCdUMnt.BLGoodsCode, blGoodsCdUMnt.BLGoodsHalfName);
                }
            }

            if (this._blGoodsCdUMntList.ContainsKey(blGoodsCd))
            {
                return this._blGoodsCdUMntList[blGoodsCd];
            }

            return string.Empty;
            // --- ADD 2009/02/04 --------------------------------<<<<<
        }
        // ADD gezh 2013/01/24 Redmine#33361 Client�[�̉��C�ć@ ----->>>>>
        /// <summary>
        /// ���_���擾
        /// </summary>
        private void ReadSecInfoSet()
        {
            this._sectionDic = new Dictionary<string, SecInfoSet>();

            ArrayList retList;

            try
            {
                int status = this._secInfoSetAcs.SearchAll(out retList, LoginInfoAcquisition.EnterpriseCode);
                if (status == 0)
                {
                    foreach (SecInfoSet secInfoSet in retList)
                    {
                        if (secInfoSet.LogicalDeleteCode == 0)
                        {
                            this._sectionDic.Add(secInfoSet.SectionCode.Trim(), secInfoSet);
                        }
                    }
                }
            }
            catch
            {
                this._sectionDic = new Dictionary<string, SecInfoSet>();
            }
        }
        // ADD gezh 2013/01/24 Redmine#33361 Client�[�̉��C�ć@ ----->>>>>
        #endregion

        #region �� �X�V�n����
        /// <summary>
        /// ���i�݌Ƀe�[�u�����珤�i�A���f�[�^�ւ̃f�[�^�l�֏���
        /// </summary>
        /// <param name="extractInfo">�������̒��o����</param>
        /// <param name="dr">�X�V��f�[�^��1�s�f�[�^</param>
        /// <param name="goodsUnitDataList"></param>
        /// <returns>0:�X�V�Ώۍs�A1:�X�V�s�v�s�A���̑�:�G���[</returns>
        /// <remarks>
        /// <br>UpdateNote       : 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// <br>Update Note      : 2011/12/31 ���H��</br> 
        /// <br>                 �Ǘ��ԍ� 10707327-00 2012/01/25�z�M��</br> 							
        /// <br>                 Redmine27530 ���i�݌Ɉꊇ�o�^/�u�O�~�v�̊|���f�[�^�̓o�^</br> 		 
        /// <br>Update Note      : 2012/09/11 yangmj ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// <br>�Ǘ��ԍ�         : 10707327-00 PM1203G</br> 							
        /// <br>                   Redmine32095 ���i�݌Ɉꊇ�o�^�C���Łu�S�Ẳ��i��񂪏�����v</br>
        /// <br>Update Note      : 2015/01/14 �c����</br>
        /// <br>�Ǘ��ԍ�         : 11100008-00</br>
        /// <br>                 : Redmine#44473 ���i�݌Ɉꊇ�o�^�C���ɂč݌ɍ폜�����폜�����������t�ɂȂ��Ă��Ȃ��Ή�</br>
        /// </remarks>
        private int SetGoodsUnitDataListFromGoodsStockDataTable(DataRow dr,
            out GoodsUnitData goodsUnitData, out List<Stock> prevStockList, out List<Rate> rateList, ExtractInfo beforeExtractInfo, ExtractInfo newExtractInfo)
        {
            // �X�V�v�t���O
            bool updateFlg = false;

            // �X�V�p���i�A���f�[�^
            goodsUnitData = GetOriginalGoodsUnitData(
                    dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(), (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
            prevStockList = new List<Stock>();
            rateList = new List<Rate>();

            //----- ADD YANGMJ 2012/09/11 REDMINE#32095 ----->>>>>
            string goodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
            if (goodsNo.Contains("'"))
            {
                goodsNo = goodsNo.Replace("'", "''");
            }
            //----- ADD YANGMJ 2012/09/11 REDMINE#32095 -----<<<<<

            if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && beforeExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                #region �� �V�K�o�^-���i
                // �񋟃f�[�^�Ȃ̂ŁA�_���폜�s�͂Ȃ�
                // �폜�\��s
                //if (dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != null
                //    && dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != DBNull.Value) // DEL 2009/02/05
                if ((int)dr[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName] != 0) // ADD 2009/02/05
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }

                // ���i�J�n���ɓ��͂�������Ώ����ΏۊO
                if (
                    (dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == null
                    || dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == DBNull.Value)
                    &&
                    (dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == null
                    || dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == DBNull.Value)
                    &&
                    (dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == null
                    || dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == DBNull.Value)
                    // --- ADD 2010/08/11 ---------->>>>>
                    &&
                    (dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] == null
                    || dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] == DBNull.Value)
                    &&
                    (dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] == null
                    || dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] == DBNull.Value)
                    // --- ADD 2010/08/11 ----------<<<<<
                    )
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }

                if (goodsUnitData == null)
                {
                    goodsUnitData = new GoodsUnitData();
                    goodsUnitData.EnterpriseCode = this._enterpriseCode; // ��ƃR�[�h
                    goodsUnitData.LogicalDeleteCode = 0; // �_���폜�t���O
                    goodsUnitData.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // �i��
                    goodsUnitData.GoodsMakerCd = (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // ���[�J�[�R�[�h
                    goodsUnitData.MakerName = dr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // ���[�J�[��
                    goodsUnitData.OfferDataDiv = 0; // �񋟋敪�u���[�U�[�v
                }
                goodsUnitData.UpdEmployeeCode = newExtractInfo.StockAgentCode; // ���͒S���҃R�[�h
                goodsUnitData.UpdEmployeeName = newExtractInfo.StockAgentName; // ���͒S���Җ�
                goodsUnitData.GoodsNoNoneHyphen = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // �n�C�t�������i��
                goodsUnitData.GoodsName = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // �i��
                // --- UPD 2010/06/08 ---------->>>>>
                //goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].ToString(); // �i���J�i
                goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // �i���J�i
                // --- UPD 2010/06/08 ----------<<<<<
                goodsUnitData.Jan = dr[this._goodsStockDataTable.JanColumn.ColumnName].ToString(); // JAN�R�[�h
                goodsUnitData.BLGoodsCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName]); // BL�R�[�h
                goodsUnitData.BLGoodsName = dr[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].ToString(); // BL�R�[�h��
                goodsUnitData.EnterpriseGanreCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName]); // ���Е��ރR�[�h
                goodsUnitData.EnterpriseGanreName = dr[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].ToString();
                goodsUnitData.GoodsRateRank = dr[this._goodsStockDataTable.GoodsRateRankColumn.ColumnName].ToString();
                goodsUnitData.GoodsKindCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsKindCodeColumn.ColumnName]);
                goodsUnitData.TaxationDivCd = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.TaxationDivCdColumn.ColumnName]);
                goodsUnitData.GoodsMGroup = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName]);
                goodsUnitData.GoodsMGroupName = dr[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].ToString();
                goodsUnitData.BLGroupCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName]);
                goodsUnitData.BLGroupName = dr[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].ToString();

                // ���i���
                goodsUnitData.GoodsPriceList = new List<GoodsPrice>();

                List<GoodsPrice> goodsPriceList = MakeNewGoodsPriceList(dr);

                if (goodsPriceList != null)
                {
                    goodsUnitData.GoodsPriceList.AddRange(goodsPriceList);
                }

                // �݌ɏ��
                goodsUnitData.StockList = new List<Stock>();

                // �|�����
                Rate rate = new Rate();

                if ((dr[this._goodsStockDataTable.PriceFlColumn.ColumnName] != null
                    && dr[this._goodsStockDataTable.PriceFlColumn.ColumnName] != DBNull.Value)
                    ||
                    (dr[this._goodsStockDataTable.UpRateColumn.ColumnName] != null
                    && dr[this._goodsStockDataTable.UpRateColumn.ColumnName] != DBNull.Value))
                {
                    // --- ADD ���H�� 2011/12/31 Redmine#27530 ---------->>>>>
                    if (RateProtyMngExist && (Convert.ToInt64(dr[this._goodsStockDataTable.PriceFlColumn.ColumnName]) != 0
                        || Convert.ToDouble(dr[this._goodsStockDataTable.UpRateColumn.ColumnName]) != 0))
                    {
                    // --- ADD ���H�� 2011/12/31 Redmine#27530 ----------<<<<<
                        // �K���V�K�ɂȂ�
                        rate.EnterpriseCode = this._enterpriseCode;
                        rate.SectionCode = this._loginSectionCode;
                        rate.UnitRateSetDivCd = CT_UnitRateSetDivCd; // �P���|���ݒ�敪
                        rate.UnitPriceKind = CT_UnitPriceKind; // �P�����
                        rate.RateSettingDivide = CT_RateSettingDivide; // �|���ݒ�敪
                        rate.RateMngGoodsCd = CT_RateMngGoodsCd; // �|���ݒ�敪�i���i�j
                        rate.RateMngGoodsNm = CT_RateMngGoodsNm; // �|���ݒ薼�́i���i�j
                        rate.RateMngCustCd = CT_RateMngCustCd; // �|���ݒ�敪�i���Ӑ�j
                        rate.RateMngCustNm = CT_RateMngCustNm; // �|���ݒ薼�́i���Ӑ�j
                        rate.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                        rate.GoodsNo = goodsUnitData.GoodsNo;
                        rate.PriceFl = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.PriceFlColumn.ColumnName]);
                        rate.UpRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.UpRateColumn.ColumnName]);
                        rate.LotCount = CT_LotCount; // ���b�g���̏����l
                        rate.UnPrcFracProcUnit = CT_UnPrcFracProcUnit; // �P���[�������P��
                        rate.UnPrcFracProcDiv = CT_UnPrcFracProcDiv; // �P���[�������敪

                        rateList.Add(rate);
                    }// ADD ���H�� 2011/12/31 Redmine#27530
                }

                updateFlg = true; // ADD 2009/02/04

                #endregion
            }
            else if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && beforeExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                #region �� �V�K�o�^-�݌�
                // �݌ɂ͂Ȃ��̂Ř_���폜�s�͂Ȃ�
                // �폜�\��s
                //if (dr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != null
                //    && dr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != DBNull.Value) // DEL 2009/02/05
                if ((int)dr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] != 0) // ADD 2009/02/05
                {
                    // �����ΏۊO
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }
                else
                {
                    // --- ADD 2009/03/10 -------------------------------->>>>>
                    if (goodsUnitData.StockList.Count != 0)
                    {
                        // �X�V�O�ɕҏW�O�݌Ƀ��X�g���쐬
                        foreach (Stock prevStock in goodsUnitData.StockList)
                        {
                            prevStockList.Add(prevStock.Clone());
                        }

                        // �V�K-�݌ɂ̏ꍇ�́A1���i1�݌�(�q�ɂ��K�{�̂���)
                        Stock stock = goodsUnitData.StockList[0];

                        stock.UpdEmployeeCode = newExtractInfo.StockAgentCode; // ���͒S���҃R�[�h
                        stock.UpdEmployeeName = newExtractInfo.StockAgentName; // ���͒S���Җ�
                        stock.LogicalDeleteCode = 0; // �_���폜�t���O
                        stock.WarehouseCode = beforeExtractInfo.WarehouseCode; // �q�ɃR�[�h
                        stock.WarehouseName = beforeExtractInfo.WarehouseName; // �q�ɖ�
                        stock.SectionCode = beforeExtractInfo.AddUpSectionCode; // �Ǘ����_�R�[�h
                        stock.WarehouseShelfNo = dr[this._goodsStockDataTable.WarehouseShelfNoColumn.ColumnName].ToString(); // �I��
                        stock.DuplicationShelfNo1 = dr[this._goodsStockDataTable.DuplicationShelfNo1Column.ColumnName].ToString(); // �d���I��
                        stock.DuplicationShelfNo2 = dr[this._goodsStockDataTable.DuplicationShelfNo2Column.ColumnName].ToString(); // �d���I��2
                        stock.PartsManagementDivide1 = dr[this._goodsStockDataTable.PartsManagementDivide1Column.ColumnName].ToString(); // �Ǘ��敪1
                        stock.PartsManagementDivide2 = dr[this._goodsStockDataTable.PartsManagementDivide2Column.ColumnName].ToString(); // �Ǘ��敪2
                        stock.StockSupplierCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName]); // ������
                        stock.StockDiv = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.StockDivColumn.ColumnName]); // �݌ɋ敪
                        stock.SalesOrderUnit = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName]); // �������b�g
                        stock.MinimumStockCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName]); // �Œ�݌ɐ�
                        stock.MaximumStockCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName]); // �ō��݌ɐ�
                        stock.SupplierStock = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SupplierStockColumn.ColumnName]); // �d���݌�
                        stock.ArrivalCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ArrivalCntColumn.ColumnName]); // ���א�
                        stock.ShipmentCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ShipmentCntColumn.ColumnName]); // �o�א�
                        stock.AcpOdrCount = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName]); // �󒍐�
                        stock.MovingSupliStock = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName]);// �ړ����d���݌ɐ�
                        stock.StockUnitPriceFl = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName]); // �I���]���P�� // ADD 2009/03/05
                        stock.UpdateDate = DateTime.Today;

                        goodsUnitData.StockList.Add(stock);

                        updateFlg = true;
                    }
                    // --- ADD 2009/03/10 --------------------------------<<<<<
                    else
                    {
                        // �݌ɏ��ǉ�
                        goodsUnitData.StockList = new List<Stock>();
                        Stock stock = new Stock(); // DEL 2009/03/10

                        stock.EnterpriseCode = this._enterpriseCode; // ��ƃR�[�h
                        stock.UpdEmployeeCode = newExtractInfo.StockAgentCode; // ���͒S���҃R�[�h
                        stock.UpdEmployeeName = newExtractInfo.StockAgentName; // ���͒S���Җ�
                        stock.LogicalDeleteCode = 0; // �_���폜�t���O
                        stock.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // �i��
                        stock.GoodsNoNoneHyphen = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // �n�C�t�������i��
                        stock.GoodsName = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // �i��
                        stock.GoodsMakerCd = (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // ���[�J�[�R�[�h
                        stock.MakerName = dr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // ���[�J�[��
                        stock.WarehouseCode = beforeExtractInfo.WarehouseCode; // �q�ɃR�[�h
                        stock.WarehouseName = beforeExtractInfo.WarehouseName; // �q�ɖ�
                        stock.SectionCode = beforeExtractInfo.AddUpSectionCode; // �Ǘ����_�R�[�h
                        stock.WarehouseShelfNo = dr[this._goodsStockDataTable.WarehouseShelfNoColumn.ColumnName].ToString(); // �I��
                        stock.DuplicationShelfNo1 = dr[this._goodsStockDataTable.DuplicationShelfNo1Column.ColumnName].ToString(); // �d���I��
                        stock.DuplicationShelfNo2 = dr[this._goodsStockDataTable.DuplicationShelfNo2Column.ColumnName].ToString(); // �d���I��2
                        stock.PartsManagementDivide1 = dr[this._goodsStockDataTable.PartsManagementDivide1Column.ColumnName].ToString(); // �Ǘ��敪1
                        stock.PartsManagementDivide2 = dr[this._goodsStockDataTable.PartsManagementDivide2Column.ColumnName].ToString(); // �Ǘ��敪2
                        stock.StockSupplierCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName]); // ������
                        stock.StockDiv = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.StockDivColumn.ColumnName]); // �݌ɋ敪
                        stock.SalesOrderUnit = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName]); // �������b�g
                        stock.MinimumStockCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName]); // �Œ�݌ɐ�
                        stock.MaximumStockCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName]); // �ō��݌ɐ�
                        stock.SupplierStock = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SupplierStockColumn.ColumnName]); // �d���݌�
                        stock.ArrivalCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ArrivalCntColumn.ColumnName]); // ���א�
                        stock.ShipmentCnt = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ShipmentCntColumn.ColumnName]); // �o�א�
                        stock.AcpOdrCount = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName]); // �󒍐�
                        stock.MovingSupliStock = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName]);// �ړ����d���݌ɐ�
                        // --- ADD 2009/03/05 -------------------------------->>>>>
                        stock.StockUnitPriceFl = ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName]); // �I���]���P�� // ADD 2009/03/05
                        // --- ADD 2009/03/05 --------------------------------<<<<<
                        stock.CreateDateTime = DateTime.Today;
                        stock.UpdateDate = DateTime.Today;

                        goodsUnitData.StockList.Add(stock);

                        updateFlg = true; // ADD 2009/02/04
                    }
                }
                #endregion
            }
            else if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && beforeExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                #region �� �C���o�^-���i
                // �_���폜�s
                if ((int)dr[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] != 0)
                {
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }

                // ���i�폜�\��s
                //if (dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != null
                //    && dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != DBNull.Value) // DEL 2009/02/05
                if ((int)dr[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName] != 0) // ADD 2009/02/05
                {
                    // �_���폜�t���O��1���Z�b�g
                    goodsUnitData.LogicalDeleteCode = 1;

                    //----- ADD 2015/01/14 �c���� Redmine#44473 ----->>>>>
                    // �݌ɍ폜
                    foreach (Stock stock in goodsUnitData.StockList)
                    {
                        stock.LogicalDeleteCode = 1;
                        stock.UpdateDate = DateTime.Today;
                    }
                    //----- ADD 2015/01/14 �c���� Redmine#44473 -----<<<<<

                    // �|���i���O�C�����_�j�擾
                    Rate rate = GetOriginalRate(
                        dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                        (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                        this._loginSectionCode // ADD 2009/02/04
                        );

                    if (rate != null)
                    {
                        rate.LogicalDeleteCode = 3;
                        rateList.Add(rate);
                    }

                    updateFlg = true; // ADD 2009/02/04
                }
                else
                {
                    if (GoodsUpdateCheck(goodsUnitData, dr))
                    {
                        //goodsUnitData.EnterpriseCode = this._enterpriseCode; // ��ƃR�[�h
                        goodsUnitData.LogicalDeleteCode = 0; // �_���폜�t���O
                        goodsUnitData.UpdEmployeeCode = newExtractInfo.StockAgentCode; // ���͒S���҃R�[�h
                        goodsUnitData.UpdEmployeeName = newExtractInfo.StockAgentName; // ���͒S���Җ�
                        //goodsUnitData.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // �i��
                        goodsUnitData.GoodsNoNoneHyphen = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // �n�C�t�������i��
                        goodsUnitData.GoodsName = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // �i��
                        //goodsUnitData.GoodsMakerCd = (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // ���[�J�[�R�[�h
                        goodsUnitData.MakerName = dr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // ���[�J�[��
                        // --- UPD 2010/06/08 ---------->>>>>
                        //goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].ToString(); // �i���J�i
                        goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // �i���J�i
                        // --- UPD 2010/06/08 ----------<<<<<
                        goodsUnitData.Jan = dr[this._goodsStockDataTable.JanColumn.ColumnName].ToString(); // JAN�R�[�h
                        goodsUnitData.BLGoodsCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName]); // BL�R�[�h
                        goodsUnitData.BLGoodsName = dr[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].ToString(); // BL�R�[�h��
                        goodsUnitData.EnterpriseGanreCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName]); // ���Е��ރR�[�h
                        goodsUnitData.EnterpriseGanreName = dr[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].ToString();
                        goodsUnitData.GoodsRateRank = dr[this._goodsStockDataTable.GoodsRateRankColumn.ColumnName].ToString();
                        goodsUnitData.GoodsKindCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsKindCodeColumn.ColumnName]);
                        goodsUnitData.TaxationDivCd = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.TaxationDivCdColumn.ColumnName]);
                        goodsUnitData.GoodsMGroup = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName]);
                        goodsUnitData.GoodsMGroupName = dr[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].ToString();
                        goodsUnitData.BLGroupCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName]);
                        goodsUnitData.BLGroupName = dr[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].ToString();

                        updateFlg = true; // ADD 2009/02/04
                    }

                    // ���i���
                    if (PriceUpdateCheck(goodsUnitData, dr))
                    {
                        goodsUnitData.GoodsPriceList = new List<GoodsPrice>();

                        List<GoodsPrice> goodsPriceList = MakeNewGoodsPriceList(dr);

                        if (goodsPriceList != null)
                        {
                            goodsUnitData.GoodsPriceList.AddRange(goodsPriceList);
                        }

                        updateFlg = true; // ADD 2009/02/04
                    }

                    // �݌ɏ��
                    //// �����ꍇ�ł�List��new�͕K�v
                    //goodsUnitData.StockList = new List<Stock>();

                    // 2011/10/17 Add >>>
                    // �݌ɏ��
                    // �����i��GoodsStock���X�g
                    DataRow[] drList = this._goodsStockDataTable.Select(
                        this._goodsStockDataTable.GoodsNoColumn.ColumnName
                        + " = '"
                        //+ dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()//DEL YANGMJ REDMINE#32095
                        + goodsNo// ADD YANGMJ 2012/09/11 REDMINE#32095
                        + "' AND "
                        + this._goodsStockDataTable.GoodsMakerColumn.ColumnName
                        + " = "
                        + dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].ToString()
                        );

                    // �X�V�O�ɕҏW�O�݌Ƀ��X�g���쐬
                    foreach (Stock prevStock in goodsUnitData.StockList)
                    {
                        prevStockList.Add(prevStock.Clone());
                    }
                    // 2011/10/17 Add <<<

                    // �|��
                    Rate rate = GetOriginalRate(
                        dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                        (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                        this._loginSectionCode); // ADD 2009/02/04

                    if (RateUpdateCheck(rate, dr))
                    {
                        if (rate == null)
                        {
                            // �S�Аݒ�œǍ���
                            //rate = GetOriginalAllSectionRate(
                            //    dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(), (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]); // DEL 2009/02/04
                            rate = GetOriginalRate(
                                dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                                (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                                "00"); // ADD 2009/02/04

                            if (rate == null)
                            {
                                rate = new Rate();

                                rate.EnterpriseCode = this._enterpriseCode;
                                rate.SectionCode = this._loginSectionCode;
                                rate.UnitRateSetDivCd = CT_UnitRateSetDivCd; // �P���|���ݒ�敪
                                rate.UnitPriceKind = CT_UnitPriceKind; // �P�����
                                rate.RateSettingDivide = CT_RateSettingDivide; // �|���ݒ�敪
                                rate.RateMngGoodsCd = CT_RateMngGoodsCd; // �|���ݒ�敪�i���i�j
                                rate.RateMngGoodsNm = CT_RateMngGoodsNm; // �|���ݒ薼�́i���i�j
                                rate.RateMngCustCd = CT_RateMngCustCd; // �|���ݒ�敪�i���Ӑ�j
                                rate.RateMngCustNm = CT_RateMngCustNm; // �|���ݒ薼�́i���Ӑ�j
                                rate.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                                rate.GoodsNo = goodsUnitData.GoodsNo;
                                rate.LotCount = CT_LotCount; // ���b�g���̏����l
                                rate.UnPrcFracProcUnit = CT_UnPrcFracProcUnit; // �P���[�������P��
                                rate.UnPrcFracProcDiv = CT_UnPrcFracProcDiv; // �P���[�������敪
                            }
                            // DEL 2010/01/08 MANTIS�Ή�[14861]�F�|���}�X�^���ڂɒl���ݒ肳��Ă��郌�R�[�h���X�V�ł��Ȃ� ---------->>>>>
                            // FIXME:�����I�Ƀ��O�C�����_�ɕύX���Ă���̂ŁA�폜
                            //else
                            //{
                            //    // �S�Аݒ肩�狒�_�̂ݕύX
                            //    rate.SectionCode = this._loginSectionCode;
                            //}
                            // DEL 2010/01/08 MANTIS�Ή�[14861]�F�|���}�X�^���ڂɒl���ݒ肳��Ă��郌�R�[�h���X�V�ł��Ȃ� ----------<<<<<
                        }

                        rate.PriceFl = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.PriceFlColumn.ColumnName]);
                        rate.UpRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.UpRateColumn.ColumnName]);

                        rateList.Add(rate);

                        updateFlg = true; // ADD 2009/02/04
                    }
                }
                #endregion
            }
            else if (beforeExtractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && beforeExtractInfo.TargetDiv == ExtractInfo.TargetDivState.Stock)
            {
                #region �� �C���o�^-�݌�
                // �����i��GoodsStock���X�g
                DataRow[] drList = this._goodsStockDataTable.Select(
                    this._goodsStockDataTable.GoodsNoColumn.ColumnName
                    + " = '"
                    //+ dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()//DEL YANGMJ REDMINE#32095
                    + goodsNo//ADD YANGMJ 2012/09/11 REDMINE#32095
                    + "' AND "
                    + this._goodsStockDataTable.GoodsMakerColumn.ColumnName
                    + " = "
                    + dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].ToString()
                    );

                // �X�V�O�ɕҏW�O�݌Ƀ��X�g���쐬
                foreach (Stock prevStock in goodsUnitData.StockList)
                {
                    prevStockList.Add(prevStock.Clone());
                }

                // �݌ɏ��
                foreach (DataRow goodsStockDr in drList)
                {
                    if ((int)goodsStockDr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] != 0)
                    {
                        // �_���폜�s
                        continue;
                    }

                    // �C���o�^-�݌ɂ̏ꍇ�͕K���Y������
                    Stock originalStock = GetOriginalStock(goodsUnitData, goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString());

                    //if (goodsStockDr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != null
                    //    && goodsStockDr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != DBNull.Value) // DEL 2009/02/05
                    if ((int)goodsStockDr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] != 0) // ADD 2009/02/05
                    {
                        // �폜�\��s
                        originalStock.LogicalDeleteCode = 1;
                        originalStock.UpdateDate = DateTime.Today; // ADD 2015/01/14 �c���� Redmine#44473
                        updateFlg = true; // ADD 2009/02/04
                    }
                    else
                    {
                        if (StockUpdateCheck(originalStock, goodsStockDr))
                        {
                            //originalStock.EnterpriseCode = this._enterpriseCode; // ��ƃR�[�h
                            originalStock.UpdEmployeeCode = newExtractInfo.StockAgentCode; // ���͒S���҃R�[�h
                            originalStock.UpdEmployeeName = newExtractInfo.StockAgentName; // ���͒S���Җ�
                            originalStock.LogicalDeleteCode = 0; // �_���폜�t���O
                            //originalStock.SectionCode = newExtractInfo.AddUpSectionCode; // �Ǘ����_�R�[�h
                            //originalStock.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // �i��
                            //originalStock.GoodsNoNoneHyphen = goodsStockDr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // �n�C�t�������i��
                            //originalStock.GoodsName = goodsStockDr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // �i��
                            //originalStock.GoodsMakerCd = (int)goodsStockDr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // ���[�J�[�R�[�h
                            //originalStock.MakerName = goodsStockDr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // ���[�J�[��
                            //originalStock.WarehouseCode = newExtractInfo.WarehouseCode; // �q�ɃR�[�h
                            //originalStock.WarehouseName = newExtractInfo.WarehouseName; // �q�ɖ�
                            originalStock.WarehouseShelfNo = goodsStockDr[this._goodsStockDataTable.WarehouseShelfNoColumn.ColumnName].ToString(); // �I��
                            originalStock.DuplicationShelfNo1 = goodsStockDr[this._goodsStockDataTable.DuplicationShelfNo1Column.ColumnName].ToString(); // �d���I��
                            originalStock.DuplicationShelfNo2 = goodsStockDr[this._goodsStockDataTable.DuplicationShelfNo2Column.ColumnName].ToString(); // �d���I��2
                            originalStock.PartsManagementDivide1 = goodsStockDr[this._goodsStockDataTable.PartsManagementDivide1Column.ColumnName].ToString(); // �Ǘ��敪1
                            originalStock.PartsManagementDivide2 = goodsStockDr[this._goodsStockDataTable.PartsManagementDivide2Column.ColumnName].ToString(); // �Ǘ��敪2
                            originalStock.StockSupplierCode = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName]); // ������
                            originalStock.StockDiv = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.StockDivColumn.ColumnName]); // �݌ɋ敪
                            originalStock.SalesOrderUnit = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName]); // �������b�g
                            originalStock.MinimumStockCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName]); // �Œ�݌ɐ�
                            originalStock.MaximumStockCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName]); // �ō��݌ɐ�
                            originalStock.SupplierStock = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.SupplierStockColumn.ColumnName]); // �d���݌�
                            originalStock.ArrivalCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.ArrivalCntColumn.ColumnName]); // ���א�
                            originalStock.ShipmentCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.ShipmentCntColumn.ColumnName]); // �o�א�
                            originalStock.AcpOdrCount = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName]); // �󒍐�
                            originalStock.MovingSupliStock = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName]);// �ړ����d���݌ɐ�
                            // --- ADD 2009/03/05 -------------------------------->>>>>
                            originalStock.StockUnitPriceFl = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName]); // �I���]���P�� // ADD 2009/03/05
                            // --- ADD 2009/03/05 --------------------------------<<<<<
                            //originalStock.CreateDateTime = DateTime.Today;
                            originalStock.UpdateDate = DateTime.Today;

                            updateFlg = true; // ADD 2009/02/04
                        }
                    }
                }
                #endregion
            }
            else
            {
                #region �� �C���o�^-���i�݌ɁA�݌ɏ��i

                if ((int)dr[this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] != 0)
                {
                    // ���i�_���폜�s
                    return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
                }

                //if (dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != null
                //    && dr[this._goodsStockDataTable.GoodsDeleteDateColumn.ColumnName] != DBNull.Value)
                if ((int)dr[this._goodsStockDataTable.GoodsDeleteReserveFlgColumn.ColumnName] != 0)
                {
                    // ���i�폜�\��s

                    // �_���폜�t���O��1���Z�b�g
                    goodsUnitData.LogicalDeleteCode = 1;

                    //----- ADD 2015/01/14 �c���� Redmine#44473 ----->>>>>
                    // �݌ɍ폜
                    foreach (Stock stock in goodsUnitData.StockList)
                    {
                        stock.LogicalDeleteCode = 1;
                        stock.UpdateDate = DateTime.Today;
                    }
                    //----- ADD 2015/01/14 �c���� Redmine#44473 -----<<<<<

                    // �|���擾
                    Rate rate = GetOriginalRate(
                        dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                        (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                        this._loginSectionCode); // ADD 2009/02/04

                    if (rate != null)
                    {
                        rate.LogicalDeleteCode = 3;
                        rateList.Add(rate);
                    }

                    updateFlg = true; // ADD 2009/02/04
                }
                else
                {
                    if (this.GoodsUpdateCheck(goodsUnitData, dr))
                    {
                        // ���i���
                        goodsUnitData.EnterpriseCode = this._enterpriseCode; // ��ƃR�[�h
                        goodsUnitData.LogicalDeleteCode = 0; // �_���폜�t���O
                        goodsUnitData.UpdEmployeeCode = newExtractInfo.StockAgentCode; // ���͒S���҃R�[�h
                        goodsUnitData.UpdEmployeeName = newExtractInfo.StockAgentName; // ���͒S���Җ�
                        goodsUnitData.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // �i��
                        goodsUnitData.GoodsNoNoneHyphen = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // �n�C�t�������i��
                        goodsUnitData.GoodsName = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // �i��
                        goodsUnitData.GoodsMakerCd = (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // ���[�J�[�R�[�h
                        goodsUnitData.MakerName = dr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // ���[�J�[��
                        // --- UPD 2010/06/08 ---------->>>>>
                        //goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].ToString(); // �i���J�i
                        goodsUnitData.GoodsNameKana = dr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // �i���J�i
                        // --- UPD 2010/06/08 ----------<<<<<
                        goodsUnitData.Jan = dr[this._goodsStockDataTable.JanColumn.ColumnName].ToString(); // JAN�R�[�h
                        goodsUnitData.BLGoodsCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName]); // BL�R�[�h
                        goodsUnitData.BLGoodsName = dr[this._goodsStockDataTable.BLGoodsNameColumn.ColumnName].ToString(); // BL�R�[�h��
                        goodsUnitData.EnterpriseGanreCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName]); // ���Е��ރR�[�h
                        goodsUnitData.EnterpriseGanreName = dr[this._goodsStockDataTable.EnterpriseGanreNameColumn.ColumnName].ToString();
                        goodsUnitData.GoodsRateRank = dr[this._goodsStockDataTable.GoodsRateRankColumn.ColumnName].ToString();
                        goodsUnitData.GoodsKindCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsKindCodeColumn.ColumnName]);
                        goodsUnitData.TaxationDivCd = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.TaxationDivCdColumn.ColumnName]);
                        goodsUnitData.GoodsMGroup = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMGroupColumn.ColumnName]);
                        goodsUnitData.GoodsMGroupName = dr[this._goodsStockDataTable.GoodsMGroupNameColumn.ColumnName].ToString();
                        goodsUnitData.BLGroupCode = ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.BLGroupCodeColumn.ColumnName]);
                        goodsUnitData.BLGroupName = dr[this._goodsStockDataTable.BLGroupNameColumn.ColumnName].ToString();

                        updateFlg = true; // ADD 2009/02/04
                    }

                    // ���i���
                    if (PriceUpdateCheck(goodsUnitData, dr))
                    {
                        goodsUnitData.GoodsPriceList = new List<GoodsPrice>();

                        List<GoodsPrice> goodsPriceList = MakeNewGoodsPriceList(dr);

                        if (goodsPriceList != null)
                        {
                            goodsUnitData.GoodsPriceList.AddRange(goodsPriceList);
                        }

                        updateFlg = true; // ADD 2009/02/04
                    }

                    // �݌ɏ��
                    // �����i��GoodsStock���X�g
                    DataRow[] drList = this._goodsStockDataTable.Select(
                        this._goodsStockDataTable.GoodsNoColumn.ColumnName
                        + " = '"
                        //+ dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString()//DEL YANGMJ REDMINE#32095
                        + goodsNo//ADD YANGMJ 2012/09/11 REDMINE#32095
                        + "' AND "
                        + this._goodsStockDataTable.GoodsMakerColumn.ColumnName
                        + " = "
                        + dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName].ToString()
                        );

                    // �X�V�O�ɕҏW�O�݌Ƀ��X�g���쐬
                    foreach (Stock prevStock in goodsUnitData.StockList)
                    {
                        prevStockList.Add(prevStock.Clone());
                    }

                    foreach (DataRow goodsStockDr in drList)
                    {
                        if (goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == null
                        || goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName] == DBNull.Value)
                        {
                            // �q�ɃR�[�h�������s�͏����ΏۊO
                            continue;
                        }

                        if ((int)goodsStockDr[this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] != 0)
                        {
                            // �݌ɘ_�����폜�s
                            continue;
                        }

                        // �ҏW�p�̍݌ɏ��
                        Stock originalStock = GetOriginalStock(goodsUnitData, goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString());

                        bool isNewStockRow = false;

                        if (originalStock == null)
                        {
                            // �V�K�݌�
                            originalStock = new Stock();
                            isNewStockRow = true;
                        }

                        //if (goodsStockDr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != null
                        //    && goodsStockDr[this._goodsStockDataTable.StockDeleteDateColumn.ColumnName] != DBNull.Value) // DEL 2009/02/05
                        if ((int)goodsStockDr[this._goodsStockDataTable.StockDeleteReserveFlgColumn.ColumnName] != 0) // ADD 2009/02/05
                        {
                            // �݌ɍ폜�\��s
                            originalStock.LogicalDeleteCode = 1;
                            originalStock.UpdateDate = DateTime.Today; // ADD 2015/01/14 �c���� Redmine#44473
                            updateFlg = true; // ADD 2009/02/04
                        }
                        else
                        {
                            if (StockUpdateCheck(originalStock, goodsStockDr))
                            {
                                originalStock.EnterpriseCode = this._enterpriseCode; // ��ƃR�[�h
                                originalStock.UpdEmployeeCode = newExtractInfo.StockAgentCode; // ���͒S���҃R�[�h
                                originalStock.UpdEmployeeName = newExtractInfo.StockAgentName; // ���͒S���Җ�
                                originalStock.LogicalDeleteCode = 0; // �_���폜�t���O
                                if (isNewStockRow)
                                {
                                    originalStock.SectionCode = this.GetAddUpSectionCode(goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString()); // �Ǘ����_�R�[�h
                                    originalStock.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(); // �i��
                                    originalStock.GoodsNoNoneHyphen = goodsStockDr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString().Replace("-", string.Empty); // �n�C�t�������i��
                                    originalStock.GoodsName = goodsStockDr[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString(); // �i��
                                    originalStock.GoodsMakerCd = (int)goodsStockDr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]; // ���[�J�[�R�[�h
                                    originalStock.MakerName = goodsStockDr[this._goodsStockDataTable.GoodsMakerNameColumn.ColumnName].ToString(); // ���[�J�[��
                                    originalStock.WarehouseCode = goodsStockDr[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString(); // �q�ɃR�[�h
                                    originalStock.WarehouseName = goodsStockDr[this._goodsStockDataTable.WarehouseNameColumn.ColumnName].ToString(); // �q�ɖ�
                                }
                                originalStock.WarehouseShelfNo = goodsStockDr[this._goodsStockDataTable.WarehouseShelfNoColumn.ColumnName].ToString(); // �I��
                                originalStock.DuplicationShelfNo1 = goodsStockDr[this._goodsStockDataTable.DuplicationShelfNo1Column.ColumnName].ToString(); // �d���I��
                                originalStock.DuplicationShelfNo2 = goodsStockDr[this._goodsStockDataTable.DuplicationShelfNo2Column.ColumnName].ToString(); // �d���I��2
                                originalStock.PartsManagementDivide1 = goodsStockDr[this._goodsStockDataTable.PartsManagementDivide1Column.ColumnName].ToString(); // �Ǘ��敪1
                                originalStock.PartsManagementDivide2 = goodsStockDr[this._goodsStockDataTable.PartsManagementDivide2Column.ColumnName].ToString(); // �Ǘ��敪2
                                originalStock.StockSupplierCode = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName]); // ������
                                originalStock.StockDiv = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.StockDivColumn.ColumnName]); // �݌ɋ敪
                                originalStock.SalesOrderUnit = ConvertToInt32FromGridValue(goodsStockDr[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName]); // �������b�g
                                originalStock.MinimumStockCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName]); // �Œ�݌ɐ�
                                originalStock.MaximumStockCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName]); // �ō��݌ɐ�
                                originalStock.SupplierStock = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.SupplierStockColumn.ColumnName]); // �d���݌�
                                originalStock.ArrivalCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.ArrivalCntColumn.ColumnName]); // ���א�
                                originalStock.ShipmentCnt = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.ShipmentCntColumn.ColumnName]); // �o�א�
                                originalStock.AcpOdrCount = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName]); // �󒍐�
                                originalStock.MovingSupliStock = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName]);// �ړ����d���݌ɐ�
                                // --- ADD 2009/03/05 -------------------------------->>>>>
                                originalStock.StockUnitPriceFl = ConvertToDoubleFromGridValue(goodsStockDr[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName]); // �I���]���P�� // ADD 2009/03/05
                                // --- ADD 2009/03/05 --------------------------------<<<<<
                                if (originalStock.CreateDateTime == DateTime.MinValue)
                                {
                                    // �ǉ��s�̏ꍇ�ݒ�
                                    originalStock.CreateDateTime = DateTime.Today;
                                }
                                originalStock.UpdateDate = DateTime.Today;

                                if (isNewStockRow)
                                {
                                    // �ǉ��s�̏ꍇ�A���i�A���f�[�^�ɒǉ�
                                    goodsUnitData.StockList.Add(originalStock);
                                }

                                updateFlg = true; // ADD 2009/02/04
                            }
                        }
                    }

                    // �|��
                    Rate rate = GetOriginalRate(
                        dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                        (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                        this._loginSectionCode);

                    if (RateUpdateCheck(rate, dr))
                    {
                        if (rate == null)
                        {
                            // �S�Аݒ�œǍ���
                            //rate = GetOriginalAllSectionRate(
                            //    dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(), (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]); // DEL 2009/02/04
                            rate = GetOriginalRate(
                                dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString(),
                                (int)dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName],
                                "00"); // ADD 2009/02/04

                            if (rate == null)
                            {
                                rate = new Rate();

                                rate.EnterpriseCode = this._enterpriseCode;
                                rate.SectionCode = this._loginSectionCode;
                                rate.UnitRateSetDivCd = CT_UnitRateSetDivCd; // �P���|���ݒ�敪
                                rate.UnitPriceKind = CT_UnitPriceKind; // �P�����
                                rate.RateSettingDivide = CT_RateSettingDivide; // �|���ݒ�敪
                                rate.RateMngGoodsCd = CT_RateMngGoodsCd; // �|���ݒ�敪�i���i�j
                                rate.RateMngGoodsNm = CT_RateMngGoodsNm; // �|���ݒ薼�́i���i�j
                                rate.RateMngCustCd = CT_RateMngCustCd; // �|���ݒ�敪�i���Ӑ�j
                                rate.RateMngCustNm = CT_RateMngCustNm; // �|���ݒ薼�́i���Ӑ�j
                                rate.GoodsMakerCd = goodsUnitData.GoodsMakerCd;
                                rate.GoodsNo = goodsUnitData.GoodsNo;
                                rate.LotCount = CT_LotCount; // ���b�g���̏����l
                                rate.UnPrcFracProcUnit = CT_UnPrcFracProcUnit; // �P���[�������P��
                                rate.UnPrcFracProcDiv = CT_UnPrcFracProcDiv; // �P���[�������敪
                            }
                            // DEL 2010/01/08 MANTIS�Ή�[14861]�F�|���}�X�^���ڂɒl���ݒ肳��Ă��郌�R�[�h���X�V�ł��Ȃ� ---------->>>>>
                            // FIXME:�����I�Ƀ��O�C�����_�ɕύX���Ă���̂ŁA�폜
                            //else
                            //{
                            //    // �S�Аݒ肩�狒�_�̂ݕύX
                            //    rate.SectionCode = this._loginSectionCode;
                            //}
                            // DEL 2010/01/08 MANTIS�Ή�[14861]�F�|���}�X�^���ڂɒl���ݒ肳��Ă��郌�R�[�h���X�V�ł��Ȃ� ----------<<<<<
                        }

                        rate.PriceFl = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.PriceFlColumn.ColumnName]);
                        rate.UpRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.UpRateColumn.ColumnName]);

                        rateList.Add(rate);

                        updateFlg = true; // ADD 2009/02/04
                    }
                }
                #endregion
            }

            // --- ADD 2009/02/04 -------------------------------->>>>>
            if (updateFlg)
            {
                return (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            }
            else
            {
                // �X�V�Ώۂ��Ȃ����i
                return (int)ConstantManagement.MethodResult.ctFNC_CANCEL;
            }
            // --- ADD 2009/02/04 --------------------------------<<<<<
        }

        /// <summary>
        /// �X�V�p���i���X�g�쐬����
        /// </summary>
        /// <param name="dr"></param>
        /// <returns>���i�J�n���Ń\�[�g���ꂽ���i���X�g</returns>
        private List<GoodsPrice> MakeNewGoodsPriceList(DataRow dr)
        {
            // ���i�J�n���S�ē��͂��������null��Ԃ�
            if (
                (dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == null
                || dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == DBNull.Value)
                &&
                (dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == null
                || dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == DBNull.Value)
                &&
                (dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == null
                || dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == DBNull.Value)
                // --- ADD 2010/08/11 ---------->>>>>
                &&
                (dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] == null
                || dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] == DBNull.Value)
                &&
                (dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] == null
                || dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] == DBNull.Value)

                // --- ADD 2010/08/11 ----------<<<<<
                )
            {
                return null;
            }

            List<GoodsPrice> goodsPriceList = new List<GoodsPrice>();

            if (dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] != null
                && dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] != DBNull.Value)
            {
                GoodsPrice goodsPrice1 = new GoodsPrice();
                goodsPrice1.EnterpriseCode = this._enterpriseCode;
                goodsPrice1.GoodsMakerCd = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                goodsPrice1.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                goodsPrice1.PriceStartDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.PriceStartDate1Column.ColumnName]);
                goodsPrice1.ListPrice = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ListPrice1Column.ColumnName]);
                goodsPrice1.OpenPriceDiv = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.OpenPriceDiv1Column.ColumnName]);
                goodsPrice1.StockRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockRate1Column.ColumnName]);
                goodsPrice1.SalesUnitCost = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SalesUnitCost1Column.ColumnName]);
                // --- ADD 2010/08/31 ---------->>>>>
                if (dr[this._goodsStockDataTable.OfferDate1Column.ColumnName] != null && dr[this._goodsStockDataTable.OfferDate1Column.ColumnName] != DBNull.Value)
                {
                    goodsPrice1.OfferDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.OfferDate1Column.ColumnName]);
                }
                // --- ADD 2010/08/31 ----------<<<<<

                goodsPriceList.Add(goodsPrice1);
            }

            if (dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] != null
                && dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] != DBNull.Value)
            {
                GoodsPrice goodsPrice2 = new GoodsPrice();
                goodsPrice2.EnterpriseCode = this._enterpriseCode;
                goodsPrice2.GoodsMakerCd = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                goodsPrice2.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                goodsPrice2.PriceStartDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.PriceStartDate2Column.ColumnName]);
                goodsPrice2.ListPrice = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ListPrice2Column.ColumnName]);
                goodsPrice2.OpenPriceDiv = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName]);
                goodsPrice2.StockRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockRate2Column.ColumnName]);
                goodsPrice2.SalesUnitCost = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName]);
                // --- ADD 2010/08/31 ---------->>>>>
                if (dr[this._goodsStockDataTable.OfferDate2Column.ColumnName] != null && dr[this._goodsStockDataTable.OfferDate2Column.ColumnName] != DBNull.Value)
                {
                    goodsPrice2.OfferDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.OfferDate2Column.ColumnName]);
                }
                // --- ADD 2010/08/31 ----------<<<<<

                goodsPriceList.Add(goodsPrice2);
            }

            if (dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] != null
                && dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] != DBNull.Value)
            {
                GoodsPrice goodsPrice3 = new GoodsPrice();
                goodsPrice3.EnterpriseCode = this._enterpriseCode;
                goodsPrice3.GoodsMakerCd = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                goodsPrice3.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                goodsPrice3.PriceStartDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.PriceStartDate3Column.ColumnName]);
                goodsPrice3.ListPrice = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ListPrice3Column.ColumnName]);
                goodsPrice3.OpenPriceDiv = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName]);
                goodsPrice3.StockRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockRate3Column.ColumnName]);
                goodsPrice3.SalesUnitCost = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName]);
                // --- ADD 2010/08/31 ---------->>>>>
                if (dr[this._goodsStockDataTable.OfferDate3Column.ColumnName] != null && dr[this._goodsStockDataTable.OfferDate3Column.ColumnName] != DBNull.Value)
                {
                    goodsPrice3.OfferDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.OfferDate3Column.ColumnName]);
                }
                // --- ADD 2010/08/31 ----------<<<<<

                goodsPriceList.Add(goodsPrice3);
            }

            // --- ADD 2010/08/11 ---------->>>>>
            if (dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] != null
                && dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName] != DBNull.Value)
            {
                GoodsPrice goodsPrice4 = new GoodsPrice();
                goodsPrice4.EnterpriseCode = this._enterpriseCode;
                goodsPrice4.GoodsMakerCd = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                goodsPrice4.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                goodsPrice4.PriceStartDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.PriceStartDate4Column.ColumnName]);
                goodsPrice4.ListPrice = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ListPrice4Column.ColumnName]);
                goodsPrice4.OpenPriceDiv = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName]);
                goodsPrice4.StockRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockRate4Column.ColumnName]);
                goodsPrice4.SalesUnitCost = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName]);
                // --- ADD 2010/08/31 ---------->>>>>
                if (dr[this._goodsStockDataTable.OfferDate4Column.ColumnName] != null && dr[this._goodsStockDataTable.OfferDate4Column.ColumnName] != DBNull.Value)
                {
                    goodsPrice4.OfferDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.OfferDate4Column.ColumnName]);
                }
                // --- ADD 2010/08/31 ----------<<<<<

                goodsPriceList.Add(goodsPrice4);
            }

            if (dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] != null
                && dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName] != DBNull.Value)
            {
                GoodsPrice goodsPrice5 = new GoodsPrice();
                goodsPrice5.EnterpriseCode = this._enterpriseCode;
                goodsPrice5.GoodsMakerCd = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.GoodsMakerColumn.ColumnName]);
                goodsPrice5.GoodsNo = dr[this._goodsStockDataTable.GoodsNoColumn.ColumnName].ToString();
                goodsPrice5.PriceStartDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.PriceStartDate5Column.ColumnName]);
                goodsPrice5.ListPrice = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.ListPrice5Column.ColumnName]);
                goodsPrice5.OpenPriceDiv = this.ConvertToInt32FromGridValue(dr[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName]);
                goodsPrice5.StockRate = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.StockRate5Column.ColumnName]);
                goodsPrice5.SalesUnitCost = this.ConvertToDoubleFromGridValue(dr[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName]);
                // --- ADD 2010/08/31 ---------->>>>>
                if (dr[this._goodsStockDataTable.OfferDate5Column.ColumnName] != null && dr[this._goodsStockDataTable.OfferDate5Column.ColumnName] != DBNull.Value)
                {
                    goodsPrice5.OfferDate = this.ConvertDateTimeFromLongDate((int)dr[this._goodsStockDataTable.OfferDate5Column.ColumnName]);
                }
                // --- ADD 2010/08/31 ----------<<<<<

                goodsPriceList.Add(goodsPrice5);
            }

            // --- ADD 2010/08/11 ----------<<<<<

            // �J�n���Ń\�[�g
            goodsPriceList.Sort(ComparisonByPriceStartDate);

            return goodsPriceList;
        }

        /// <summary>
        /// �J�n���\�[�g�ݒ�
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int ComparisonByPriceStartDate(GoodsPrice x, GoodsPrice y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    return x.PriceStartDate.CompareTo(y.PriceStartDate);
                }
            }
        }

        /// <summary>
        /// �X�V�L���`�F�b�N����(���i)
        /// </summary>
        /// <param name="originalGoodsUnitData">�ύX�O�̏��i�A���f�[�^</param>
        /// <param name="goodsStockRow">���i�݌Ƀf�[�^�i�ύX��j</param>
        /// <returns>true:�X�V����Afalse�F�X�V�Ȃ�</returns>
        /// <remarks>
        /// <br>UpdateNote       : 2010/06/08 ���� ��Q�E���ǑΉ��i�V�������[�X�Č��j</br>
        /// </remarks>
        private bool GoodsUpdateCheck(GoodsUnitData originalGoodsUnitData, DataRow goodsStockRow)
        {
            if (originalGoodsUnitData == null)
            {
                return true;
            }

            // ���i���`�F�b�N
            if (originalGoodsUnitData.GoodsNameKana
                != goodsStockRow[this._goodsStockDataTable.GoodsNameKanaColumn.ColumnName].ToString()
                ||
                originalGoodsUnitData.Jan
                != goodsStockRow[this._goodsStockDataTable.JanColumn.ColumnName].ToString()
                ||
                originalGoodsUnitData.BLGoodsCode
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.BLGoodsCodeColumn.ColumnName])
                ||
                originalGoodsUnitData.EnterpriseGanreCode
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.EnterpriseGanreCodeColumn.ColumnName])
                ||
                originalGoodsUnitData.GoodsRateRank
                != goodsStockRow[this._goodsStockDataTable.GoodsRateRankColumn.ColumnName].ToString()
                ||
                originalGoodsUnitData.GoodsKindCode
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.GoodsKindCodeColumn.ColumnName])
                ||
                originalGoodsUnitData.TaxationDivCd
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.TaxationDivCdColumn.ColumnName])
                // --- ADD 2010/06/08 ---------->>>>>
                ||
                originalGoodsUnitData.GoodsName
                != goodsStockRow[this._goodsStockDataTable.GoodsNameColumn.ColumnName].ToString()
                // --- ADD 2010/06/08 ----------<<<<<
                )
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// �X�V�L���`�F�b�N����(���i)
        /// </summary>
        /// <param name="originalGoodsUnitData">�ύX�O�̏��i�A���f�[�^</param>
        /// <param name="goodsStockRow">���i�݌Ƀf�[�^�i�ύX��j</param>
        /// <returns>true:�X�V����Afalse�F�X�V�Ȃ�</returns>
        private bool PriceUpdateCheck(GoodsUnitData originalGoodsUnitData, DataRow goodsStockRow)
        {
            if (originalGoodsUnitData == null)
            {
                return true;
            }

            // ���i���X�g�����݂���
            if (originalGoodsUnitData.GoodsPriceList != null
                && originalGoodsUnitData.GoodsPriceList.Count != 0)
            {
                if (
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == null
                    ||
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate1Column.ColumnName] == DBNull.Value
                    ||
                    originalGoodsUnitData.GoodsPriceList[0].PriceStartDate
                    != ConvertDateTimeFromLongDate((int)goodsStockRow[this._goodsStockDataTable.PriceStartDate1Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[0].ListPrice
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ListPrice1Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[0].OpenPriceDiv
                    != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.OpenPriceDiv1Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[0].StockRate
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockRate1Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[0].SalesUnitCost
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SalesUnitCost1Column.ColumnName])
                    )
                {
                    // ���i���X�g���폜����Ă���ꍇ��������ɊY������
                    return true;
                }

                if (originalGoodsUnitData.GoodsPriceList.Count > 1)
                {
                    if (
                        goodsStockRow[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == null
                    || 
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate2Column.ColumnName] == DBNull.Value
                    ||
                    originalGoodsUnitData.GoodsPriceList[1].PriceStartDate
                    != ConvertDateTimeFromLongDate((int)goodsStockRow[this._goodsStockDataTable.PriceStartDate2Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[1].ListPrice
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ListPrice2Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[1].OpenPriceDiv
                    != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.OpenPriceDiv2Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[1].StockRate
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockRate2Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[1].SalesUnitCost
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SalesUnitCost2Column.ColumnName])
                    )
                    {
                        return true;
                    }
                }
                else
                {
                    if (ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.PriceStartDate2Column.ColumnName]) != 0)
                    {
                        return true;
                    }
                }

                if (originalGoodsUnitData.GoodsPriceList.Count > 2)
                {
                    if (
                        goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == null
                    || 
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == DBNull.Value
                    ||
                    originalGoodsUnitData.GoodsPriceList[2].PriceStartDate
                    != ConvertDateTimeFromLongDate((int)goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[2].ListPrice
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ListPrice3Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[2].OpenPriceDiv
                    != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.OpenPriceDiv3Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[2].StockRate
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockRate3Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[2].SalesUnitCost
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SalesUnitCost3Column.ColumnName])
                    )
                    {
                        return true;
                    }
                }
                else
                {
                    if (ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName]) != 0)
                    {
                        return true;
                    }
                }

                // --- ADD 2010/08/11 ---------->>>>>
                if (originalGoodsUnitData.GoodsPriceList.Count > 3)
                {
                    if (
                        goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == null
                    ||
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == DBNull.Value
                    ||
                    originalGoodsUnitData.GoodsPriceList[3].PriceStartDate
                    != ConvertDateTimeFromLongDate((int)goodsStockRow[this._goodsStockDataTable.PriceStartDate4Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[3].ListPrice
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ListPrice4Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[3].OpenPriceDiv
                    != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.OpenPriceDiv4Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[3].StockRate
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockRate4Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[3].SalesUnitCost
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SalesUnitCost4Column.ColumnName])
                    )
                    {
                        return true;
                    }
                }
                else
                {
                    if (ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.PriceStartDate4Column.ColumnName]) != 0)
                    {
                        return true;
                    }
                }

                if (originalGoodsUnitData.GoodsPriceList.Count > 4)
                {
                    if (
                        goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == null
                    ||
                    goodsStockRow[this._goodsStockDataTable.PriceStartDate3Column.ColumnName] == DBNull.Value
                    ||
                    originalGoodsUnitData.GoodsPriceList[4].PriceStartDate
                    != ConvertDateTimeFromLongDate((int)goodsStockRow[this._goodsStockDataTable.PriceStartDate5Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[4].ListPrice
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ListPrice5Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[4].OpenPriceDiv
                    != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.OpenPriceDiv5Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[4].StockRate
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockRate5Column.ColumnName])
                    ||
                    originalGoodsUnitData.GoodsPriceList[4].SalesUnitCost
                    != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SalesUnitCost5Column.ColumnName])
                    )
                    {
                        return true;
                    }
                }
                else
                {
                    if (ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.PriceStartDate5Column.ColumnName]) != 0)
                    {
                        return true;
                    }
                }


                // --- ADD 2010/08/11 ----------<<<<<
            }
            else
            {
                if (ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.PriceStartDate1Column.ColumnName]) != 0)
                {
                    return true;
                }
            }

            return false;
        }
        
        /// <summary>
        /// �X�V�L���`�F�b�N����(�|��)
        /// </summary>
        /// <param name="originalGoodsUnitData">�ύX�O�̊|��</param>
        /// <param name="goodsStockRow">���i�݌Ƀf�[�^�i�ύX��j</param>
        /// <returns>true:�X�V����Afalse�F�X�V�Ȃ�</returns>
        private bool RateUpdateCheck(Rate originalRate, DataRow goodsStockRow)
        {
            if (originalRate == null)
            {
                if (ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.PriceFlColumn.ColumnName]) != 0
                    ||
                    ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.UpRateColumn.ColumnName]) != 0)
                {
                    // �V�K�쐬
                    return true;
                }
                else
                {
                    // �쐬���Ȃ�
                    return false;
                }
            }

            if (originalRate.PriceFl
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.PriceFlColumn.ColumnName])
                ||
                originalRate.UpRate
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.UpRateColumn.ColumnName])
                )
            {
                // �l���ς���Ă���ꍇ�A�v�X�V
                return true;
            }

            return false;
        }

        /// <summary>
        /// �X�V�L���`�F�b�N����(�݌�)
        /// </summary>
        /// <param name="originalGoodsUnitData">�ύX�O�̍݌�</param>
        /// <param name="goodsStockRow">���i�݌Ƀf�[�^�i�ύX��j</param>
        /// <returns>true:�X�V����Afalse�F�X�V�Ȃ�</returns>
        private bool StockUpdateCheck(Stock originalStock, DataRow goodsStockRow)
        {
            if (
                originalStock.WarehouseCode
                != goodsStockRow[this._goodsStockDataTable.WarehouseCodeColumn.ColumnName].ToString()
                ||
                originalStock.WarehouseShelfNo
                != goodsStockRow[this._goodsStockDataTable.WarehouseShelfNoColumn.ColumnName].ToString()
                ||
                originalStock.DuplicationShelfNo1
                != goodsStockRow[this._goodsStockDataTable.DuplicationShelfNo1Column.ColumnName].ToString()
                ||
                originalStock.DuplicationShelfNo2
                != goodsStockRow[this._goodsStockDataTable.DuplicationShelfNo2Column.ColumnName].ToString()
                ||
                originalStock.PartsManagementDivide1
                != goodsStockRow[this._goodsStockDataTable.PartsManagementDivide1Column.ColumnName].ToString()
                ||
                originalStock.PartsManagementDivide2
                != goodsStockRow[this._goodsStockDataTable.PartsManagementDivide2Column.ColumnName].ToString()
                ||
                originalStock.StockSupplierCode
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.StockSupplierCodeColumn.ColumnName])
                ||
                originalStock.StockDiv
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.StockDivColumn.ColumnName])
                ||
                originalStock.SalesOrderUnit
                != ConvertToInt32FromGridValue(goodsStockRow[this._goodsStockDataTable.SalesOrderUnitColumn.ColumnName])
                ||
                originalStock.MaximumStockCnt
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.MaximumStockCntColumn.ColumnName])
                ||
                originalStock.MinimumStockCnt
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.MinimumStockCntColumn.ColumnName])
                ||
                originalStock.SupplierStock
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.SupplierStockColumn.ColumnName])
                ||
                originalStock.ArrivalCnt
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ArrivalCntColumn.ColumnName])
                ||
                originalStock.ShipmentCnt
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.ShipmentCntColumn.ColumnName])
                ||
                originalStock.AcpOdrCount
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.AcpOdrCountColumn.ColumnName])
                ||
                originalStock.MovingSupliStock
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.MovingSupliStockColumn.ColumnName])
                // --- ADD 2009/03/05 -------------------------------->>>>>
                ||
                originalStock.StockUnitPriceFl
                != ConvertToDoubleFromGridValue(goodsStockRow[this._goodsStockDataTable.StockUnitPriceFlColumn.ColumnName]) // ADD 2009/03/05
                // --- ADD 2009/03/05 --------------------------------<<<<<
                )
            {
                return true;
            }

            return false;

        }

        /// <summary>
        /// �Ǘ����_�擾����
        /// </summary>
        /// <param name="warehouseCode"></param>
        private string GetAddUpSectionCode(string warehouseCode)
        {
            Warehouse warehouse;

            int status = this._warehouseAcs.Read(out warehouse, this._enterpriseCode, string.Empty, warehouseCode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return warehouse.SectionCode;
            }

            return string.Empty;
        }

        #endregion

        #region �� ���̑�����

        /// <summary>
        /// �w�肵���L�[�ɊY������X�V�O���i�A���f�[�^���擾����
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <returns></returns>
        private GoodsUnitData GetOriginalGoodsUnitData(string goodsNo, int goodsMakerCd)
        {
            if (this._originalGoodsUnitDataList == null)
            {
                // �V�K-���i�ŃO���b�h�\���Ȃ��ŏ��i�ǉ������ꍇ�̂�
                return null;
            }
            // --- DEL 2009/02/16 -------------------------------->>>>>
            //foreach (GoodsUnitData goodsUnitData in this._originalGoodsUnitDataList)
            //{
            //    if (goodsUnitData.GoodsNo == goodsNo && goodsUnitData.GoodsMakerCd == goodsMakerCd)
            //    {
            //        return goodsUnitData;
            //    }
            //}

            //return null;
            // --- DEL 2009/02/16 --------------------------------<<<<<
            // --- ADD 2009/02/16 -------------------------------->>>>>
            GoodsUnitData goodsUnitData = null;

            goodsUnitData = this._originalGoodsUnitDataList.Find(
                delegate(GoodsUnitData orgGoodsUnitData)
                {
                    if (orgGoodsUnitData.GoodsNo == goodsNo
                        && orgGoodsUnitData.GoodsMakerCd == goodsMakerCd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return goodsUnitData;
            // --- ADD 2009/02/16 --------------------------------<<<<<
        }

        /// <summary>
        /// �w�肵���L�[�ɊY������|���f�[�^(���O�C�����_)���擾����
        /// </summary>
        /// <param name="goodsNo"></param>
        /// <param name="goodsMakerCd"></param>
        /// <param name="sectionCd"></param>
        /// <returns></returns>
        private Rate GetOriginalRate(string goodsNo, int goodsMakerCd, string sectionCd)
        {
            // --- DEL 2009/02/16 -------------------------------->>>>>
            //foreach (Rate rate in this._originalRateList)
            //{
            //    if (rate.GoodsNo == goodsNo
            //        && rate.GoodsMakerCd == goodsMakerCd)
            //    {
            //        return rate;
            //    }
            //}

            //return null;
            // --- DEL 2009/02/16 --------------------------------<<<<<

            // --- ADD 2009/02/16 -------------------------------->>>>>
            Rate rate;
            rate = this._originalRateList.Find(
                delegate(Rate orgRate)
                {
                    if ((orgRate.GoodsNo == goodsNo) &&
                        (orgRate.GoodsMakerCd == goodsMakerCd) &&
                        (orgRate.SectionCode.TrimEnd() == sectionCd.TrimEnd()))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return rate;
            // --- ADD 2009/02/16 -------------------------------->>>>>
        }

        // --- DEL 2009/02/04 -------------------------------->>>>>
        ///// <summary>
        ///// �w�肵���L�[�ɊY������|���f�[�^�i�S�Аݒ�j���擾����
        ///// </summary>
        ///// <param name="goodsNo"></param>
        ///// <param name="goodsMakerCd"></param>
        ///// <returns></returns>
        //private Rate GetOriginalAllSectionRate(string goodsNo, int goodsMakerCd)
        //{
        //    foreach (Rate rate in this._originalAllSectionRateList)
        //    {
        //        if (rate.GoodsNo == goodsNo
        //            && rate.GoodsMakerCd == goodsMakerCd)
        //        {
        //            return rate;
        //        }
        //    }

        //    return null;
        //}
        // --- DEL 2009/02/04 --------------------------------<<<<<

        /// <summary>
        /// �w�肵���L�[�ɊY������݌Ƀf�[�^���擾����
        /// </summary>
        /// <param name="goodsUnitData"></param>
        /// <param name="warehouseCd"></param>
        /// <returns></returns>
        private Stock GetOriginalStock(GoodsUnitData goodsUnitData, string warehouseCd)
        {
            if (goodsUnitData.StockList == null
                || goodsUnitData.StockList.Count == 0)
            {
                return null;
            }

            // --- DEL 2009/02/16 -------------------------------->>>>>
            //foreach (Stock stock in goodsUnitData.StockList)
            //{
            //    if (stock.WarehouseCode == warehouseCd)
            //    {
            //        return stock;
            //    }
            //}

            //return null;
            // --- DEL 2009/02/16 --------------------------------<<<<<
            // --- ADD 2009/02/16 -------------------------------->>>>>
            Stock stock = null;

            stock = goodsUnitData.StockList.Find(
                delegate(Stock orgStock)
                {
                    if (orgStock.WarehouseCode == warehouseCd)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            );

            return stock;
            // --- ADD 2009/02/16 --------------------------------<<<<<
        }

        /// <summary>
        /// �s�ԍ��ݒ�
        /// </summary>
        private void SetRowNumber(ExtractInfo extractInfo)
        {
            // --- DEL 2009/03/06 -------------------------------->>>>>
            //for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
            //{
            //    this._goodsStockDataTable
            //        .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = i + 1;
            //}
            // --- DEL 2009/03/06 --------------------------------<<<<<
            // --- ADD 2009/03/06 -------------------------------->>>>>
            if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.New
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                // �\���敪�u�V�K�o�^�v-�Ώۋ敪�u���i�v
                // �_���폜�s�͂��肦�Ȃ�
                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = i + 1;
                    this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = i + 1;
                }
            }
            else if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
           && extractInfo.TargetDiv == ExtractInfo.TargetDivState.Goods)
            {
                // �\���敪�u�C���o�^�v-�Ώۋ敪�u���i�v
                // ���i�̘_���폜�����O
                int deleteRowIndex = 0;
                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] == 0)
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = deleteRowIndex + 1;
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    }
                }

                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] != 0)
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = "-";
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    } 
                }
            }
            else if (extractInfo.DisplayDiv == ExtractInfo.DisplayDivState.Update
                && extractInfo.TargetDiv == ExtractInfo.TargetDivState.GoodsStock)
            {
                // �\���敪�u�C���o�^�v-�Ώۋ敪�u���i-�݌Ɂv
                // ���i�A�݌ɂ̘_���폜�����O
                int deleteRowIndex = 0;
                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] == 0
                        &&
                        (int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] == 0
                        )
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = deleteRowIndex + 1;
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    }
                }

                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.GoodsLogicalDeleteFlgColumn.ColumnName] != 0
                        ||
                        (int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] != 0
                        )
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = "-";
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    }
                }
            }
            else
            {
                // �Ώۋ敪�u�݌Ɂv�u�݌�-���i�v
                // �݌ɂ̘_���폜�����O(���i�̘_���폜�͏�����Ă���)
                int deleteRowIndex = 0;
                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] == 0)
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = deleteRowIndex + 1;
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    }
                }

                for (int i = 0; i < this._goodsStockDataTable.Rows.Count; i++)
                {
                    if ((int)this._goodsStockDataTable
                        .Rows[i][this._goodsStockDataTable.StockLogicalDeleteFlgColumn.ColumnName] != 0)
                    {
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowNumberColumn.ColumnName] = "-";
                        this._goodsStockDataTable
                            .Rows[i][this._goodsStockDataTable.RowIndexColumn.ColumnName] = deleteRowIndex + 1;

                        deleteRowIndex++;
                    }
                }
            }

            // --- ADD 2009/03/06 --------------------------------<<<<<
        }

        /// <summary>
        /// DateTime��LongDate(8��)�̕ϊ�����
        /// </summary>
        /// <returns></returns>
        private Int32 ConvertLongDateFromDateTime(DateTime date)
        {
            return date.Year * 10000 + date.Month * 100 + date.Day;
        }

        /// <summary>
        /// LongDate(8��)��DateTime�̕ϊ�����
        /// </summary>
        /// <returns></returns>
        private DateTime ConvertDateTimeFromLongDate(Int32 date)
        {
            int year = date / 10000;
            int month = (date / 100) % 100;
            int day = date % 100;

            return new DateTime(year, month, day);
        }


        /// <summary>
        /// DBNull���܂ލ��ڂ̐��l�ϊ�����(�����p)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private Int32 ConvertToInt32FromGridValue(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        } 

        /// <summary>
        /// DBNull���܂ލ��ڂ̐��l�ϊ�����(�����p)
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private double ConvertToDoubleFromGridValue(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToDouble(obj);
            }
        }
        #endregion

        #endregion
    }
}
