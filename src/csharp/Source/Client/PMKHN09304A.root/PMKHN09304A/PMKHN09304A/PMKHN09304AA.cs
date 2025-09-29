using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Text;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �|���}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �|���}�X�^�̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 30414 �E �K�j</br>
    /// <br>Date       : 2008/09/25</br>
    /// <br></br>
    /// <br>UpdateNote : Search���\�b�h�ǉ�(�P���Z�o���W���[���Ŏg�p)</br>
    /// <br>Programmer : 21024 ���X�� ��</br>
    /// <br>Date       : 2009.02.11</br>
    /// <br>UpdateNote : Search���\�b�h�ǉ�(�P���Z�o���W���[���Ŏg�p)</br>
    /// <br>Programmer : 30434 �H��</br>
    /// <br>Date       : 2009.11.20</br>
    /// <br>UpdateNote : 2012/11/21 zhuhh</br>
    /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
    /// <br>           : redmine #33230 SearchDel���\�b�h�ǉ�(�_���폜�|���܂�)</br>
    /// <br>UpdateNote : PM-TAB�Ή��̒ǉ�</br>
    /// <br>Programmer : huangt</br>
    /// <br>Date       : 2013/06/13</br>
    /// </remarks>
    public class RateAcs
    {
        #region Public Members
        // ===================================================================================== //
        // �p�u���b�N�����o�[
        // ===================================================================================== //
        //----------------------------------------
        // �|���ݒ�}�X�^�萔��`
        //----------------------------------------
        /// <summary>�쐬���t</summary>
        public const string CREATEDATETIME = "CreateDateTime";
        /// <summary>�X�V���t</summary>
        public const string UPDATEDATETIME = "UpdateDateTime";
        /// <summary>��ƃR�[�h</summary>
        public const string ENTERPRISECODE = "EnterpriseCode";
        /// <summary>GUID</summary>
        public const string FILEHEADERGUID = "FileHeaderGuid";
        /// <summary>�X�V�]�ƈ��R�[�h</summary>
        public const string UPDEMPLOYEECODE = "UpdEmployeeCode";
        /// <summary>�X�V�A�Z���u��ID1</summary>
        public const string UPDASSEMBLYID1 = "UpdAssemblyId1";
        /// <summary>�X�V�A�Z���u��ID2</summary>
        public const string UPDASSEMBLYID2 = "UpdAssemblyId2";
        /// <summary>�_���폜�敪</summary>
        public const string LOGICALDELETECODE = "LogicalDeleteCode";
        /// <summary>���_�R�[�h</summary>
        public const string SECTIONCODE = "���_�R�[�h";
        /// <summary>�P���|���ݒ�敪</summary>
        public const string UNITRATESETDIVCD = "�P���|���ݒ�敪";
        /// <summary>�P�����</summary>
        public const string UNITPRICEKIND = "�P�����";
        /// <summary>�|���ݒ�敪</summary>
        public const string RATESETTINGDIVIDE = "�|���ݒ�敪";
        /// <summary>�|���ݒ�敪�i���i�j</summary>
        public const string RATEMNGGOODSCD = "�|���ݒ�敪�i���i�j";
        /// <summary>�|���ݒ薼�́i���i�j</summary>
        public const string RATEMNGGOODSNM = "�|���ݒ薼�́i���i�j";
        /// <summary>�|���ݒ�敪�i���Ӑ�j</summary>
        public const string RATEMNGCUSTCD = "�|���ݒ�敪�i���Ӑ�j";
        /// <summary>�|���ݒ薼�́i���Ӑ�j</summary>
        public const string RATEMNGCUSTNM = "�|���ݒ薼�́i���Ӑ�j";
        /// <summary>���i���[�J�[�R�[�h</summary>
        public const string GOODSMAKERCD = "���i���[�J�[�R�[�h";
        /// <summary>���i�ԍ�</summary>
        public const string GOODSNO = "���i�ԍ�";
        /// <summary>���i�|�������N</summary>
        public const string GOODSRATERANK = "���i�|�������N";
        /// <summary>BL���i�R�[�h</summary>
        public const string BLGOODSCODE = "BL���i�R�[�h";
        /// <summary>���Ӑ�R�[�h</summary>
        public const string CUSTOMERCODE = "���Ӑ�R�[�h";
        /// <summary>���Ӑ�|���O���[�v�R�[�h</summary>
        public const string CUSTRATEGRPCODE = "���Ӑ�|���O���[�v�R�[�h";
        /// <summary>�d����R�[�h</summary>
        public const string SUPPLIERCD = "�d����R�[�h";
        /// <summary>���b�g��</summary>
        public const string LOTCOUNT = "���b�g��";
        /// <summary>�P���Z�o�敪</summary>
        public const string UNITPRCCALCDIV = "�P���Z�o�敪";
        /// <summary>���i�敪</summary>
        public const string PRICEDIV = "���i�敪";
        /// <summary>���i</summary>
        public const string PRICEFL = "���i";
        /// <summary>�|��</summary>
        public const string RATEVAL = "�|��";
        /// <summary>�P���[�������P��</summary>
        public const string UNPRCFRACPROCUNIT = "�P���[�������P��";
        /// <summary>�P���[�������敪</summary>
        public const string UNPRCFRACPROCDIV = "�P���[�������敪";
        /// <summary>�폜��</summary>
        public const string DELETE_DATE_TITLE = "�폜��";
        /// <summary>���i�|���O���[�v�R�[�h</summary>
        public const string GOODSRATEGRPCODE = "���i������";
        /// <summary>BL�O���[�v�R�[�h</summary>
        public const string BLGLOUPCODE = "BL�O���[�v�R�[�h";
        /// <summary>UP��</summary>
        public const string UPRATE = "UP��";
        /// <summary>�e���m�ۗ�</summary>
        public const string GRSPROFITSECURERATE = "�e���m�ۗ�";

        // �e�[�u����
        /// <summary>�|���e�[�u��</summary>
        public const string RATE_TABLE = "RateTable";

        #endregion

        #region Private Members
        // ===================================================================================== //
        // �v���C�x�[�g�����o�[
        // ===================================================================================== //
        // �����[�g�I�u�W�F�N�g�i�[�o�b�t�@
        private IRateDB _rateDB = null;    // �ېݒ胊���[�g

        private DataSet _dataTableList = null;

        // �����񌋍��p
        private StringBuilder _stringBuilder = null;

        /// <summary>�|���ݒ�敪�i���[�J�[�\���敪�l�j</summary>
        private static readonly List<string> ctRATEDIVVALUE_Maker = new List<string>(new string[] { "A", "B", "C", "D", "E", "F", "G", "K" });
        /// <summary>�|���ݒ�敪�i���i�R�[�h,���i���\���敪�l�j</summary>
        private static readonly List<string> ctRATEDIVVALUE_Goods = new List<string>(new string[] { "A" });
        /// <summary>�|���ݒ�敪�i�w�ʕ\���敪�l�j</summary>
        private static readonly List<string> ctRATEDIVVALUE_GoodsRateRank = new List<string>(new string[] { "B", "C", "G" });
        /// <summary>�|���ݒ�敪�i���i�|���O���[�v�\���敪�l�j</summary>
        private static readonly List<string> ctRATEDIVVALUE_GoodsRateGrpCode = new List<string>(new string[] { "F", "J" });
        /// <summary>�|���ݒ�敪�iBL�O���[�v�R�[�h�j</summary>
        private static readonly List<string> ctRATEDIVVALUE_BLGroupCode = new List<string>(new string[] { "C", "E", "I" });
        /// <summary>�|���ݒ�敪�iBL���i�\���敪�l�j</summary>
        private static readonly List<string> ctRATEDIVVALUE_BLGoods = new List<string>(new string[] { "B", "D", "H" });
        /// <summary>�|���ݒ�敪�i���Ӑ�\���敪�l�j</summary>
        private static readonly List<string> ctRATEDIVVALUE_Customer = new List<string>(new string[] { "1", "2" });
        /// <summary>�|���ݒ�敪�i���Ӑ�|��GR�\���敪�l�j</summary>
        private static readonly List<string> ctRATEDIVVALUE_CustRateGrp = new List<string>(new string[] { "3", "4" });
        /// <summary>�|���ݒ�敪�i�d����\���敪�l�j</summary>
        private static readonly List<string> ctRATEDIVVALUE_SupplierCd = new List<string>(new string[] { "1", "3", "5" });

        #endregion

        #region Construcstor
        /// <summary>
        /// �|���}�X�^�A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        public RateAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._rateDB = (IRateDB)MediationRateDB.GetRateDB();
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._rateDB = null;
            }

            // �f�[�^�Z�b�g����\�z����
            this._dataTableList = new DataSet();
            DataSetColumnConstruction(ref this._dataTableList);

            // �����񌋍��p
            _stringBuilder = new StringBuilder();
        }
        #endregion

        // �񋓌^
        /// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
        public enum OnlineMode
        {
            /// <summary>�I�t���C��</summary>
            Offline,
            /// <summary>�I�����C��</summary>
            Online
        }

        /// <summary>
        /// �I�����C�����[�h�擾����
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        public int GetOnlineMode()
        {
            if (this._rateDB == null)
            {
                return (int)ConstantManagement.OnlineMode.Offline;
            }
            else
            {
                return (int)ConstantManagement.OnlineMode.Online;
            }
        }

        #region Property
        /// <summary>�|���e�[�u��</summary>
        public DataTable DtThirdTable
        {
            get { return this._dataTableList.Tables[RATE_TABLE]; }
        }
        #endregion

        #region ��Static Methods
        /// <summary>
        /// ���Ӑ悪�|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public static bool IsCustomerSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_Customer);
        }

        /// <summary>
        /// ���Ӑ�|���ݒ�GR���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public static bool IsCustRateGrpSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_CustRateGrp);
        }

        /// <summary>
        /// �d���悪�|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public static bool IsSupplierSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 0, 1, ctRATEDIVVALUE_SupplierCd);
        }

        /// <summary>
        /// ���i�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public static bool IsGoodsNoSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_Goods);
        }

        /// <summary>
        /// ���[�J�[���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public static bool IsMakerSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_Maker);
        }

        /// <summary>
        /// �w�ʂ��|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public static bool IsGoodsRateRankSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_GoodsRateRank);
        }

        /// <summary>
        /// ���i�|���O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public static bool IsGoodsRateGrpCodeSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_GoodsRateGrpCode);
        }

        /// <summary>
        /// BL�O���[�v�R�[�h���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public static bool IsBLGroupCodeSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_BLGroupCode);
        }

        /// <summary>
        /// BL���i���|���ݒ�敪�̐ݒ�Ώۂ����擾���܂��B
        /// </summary>
        /// <param name="rateDiv">�|���ݒ�敪</param>
        /// <returns>true:�ݒ�L��</returns>
        public static bool IsBLGoodsSetting(string rateDiv)
        {
            return IsSetting(rateDiv, 1, 1, ctRATEDIVVALUE_BLGoods);
        }

        /// <summary>
        /// �Ώە����񒆂ɁA��r�Ώۃ��X�g�Ɋ܂܂�镶���񂪑��݂��邩���擾���܂��B
        /// </summary>
        /// <param name="target">�Ώە�����</param>
        /// <param name="startIndex">�����񒆂̔�r�����J�n�ʒu</param>
        /// <param name="length">��r������̒���</param>
        /// <param name="judgmentList">��r�Ώۃ��X�g</param>
        /// <returns>true:���݂���</returns>
        private static bool IsSetting(string target, int startIndex, int length, List<string> judgmentList)
        {
            bool ret = false;
            if (target.Length >= (startIndex + length))
            {
                if (judgmentList.Contains(target.Substring(startIndex, length))) ret = true;
            }
            return ret;
        }
        #endregion ��Static Methods

        #region Search ��������
        /// <summary>
        /// ���������i�_���폜�܂܂Ȃ��j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="rate">�|���N���X</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�͒��o�ΏۊO</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        public int Search(out DataTable retList, ref Rate rate, out string message)
        {
            // ����
            int status = SearchProc(out retList, ref rate, 0, out message);
            return status;
        }

        /// <summary>
        /// �|���}�X�^�������������i�_���폜�܂܂Ȃ��j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="rateList">�|���I�u�W�F�N�g���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���X�g�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�͒��o�ΏۊO</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2007.11.14</br>
        /// </remarks>
        public int Search(out DataTable retList, List<Rate> rateList, out string message)
        {
            // ����
            int status = SearchProc(out retList, rateList, 0, out message);
            return status;
        }

        // 2009.02.11 Add >>>
        /// <summary>
        /// �|���}�X�^�������������i�_���폜�܂܂Ȃ��j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="rateList">�|���I�u�W�F�N�g���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���X�g�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�͒��o�ΏۊO</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.02.11</br>
        /// </remarks>
        public int Search(out List<Rate> retList, List<Rate> rateList, out string message)
        {
            // ����
            int status = SearchProc(out retList, rateList, 0, out message);
            return status;
        }
        // 2009.02.11 Add <<<

        // ----- ADD zhuhh 2012/11/21 for Redmine #33230 ----->>>>>
        /// <summary>
        /// �|���}�X�^�������������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="rateList">�|���I�u�W�F�N�g���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>UpdateNote : 2012/11/21 zhuhh</br>
        /// <br>�Ǘ��ԍ�   : 2013/01/16�z�M��</br>
        /// <br>           : redmine #33230 �|���}�X�^���X�g�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�͒��o�ΏۊO</br>
        /// </remarks>
        public int SearchDel(out List<Rate> retList, List<Rate> rateList, out string message)
        {
            // ����
            int status = SearchProc(out retList, rateList, ConstantManagement.LogicalMode.GetData01, out message);
            return status;
        }
        // ----- ADD zhuhh 2012/11/21 for Redmine #33230 -----<<<<<
        #endregion

        #region SearchAll ��������
        /// <summary>
        /// ���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="rate">�|���N���X</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        public int SearchAll(out DataTable retList, ref Rate rate, out string message)
        {
            // ����
            int status = SearchProc(out retList, ref rate, ConstantManagement.LogicalMode.GetData01, out message);
            return status;
        }
        #endregion

        #region SearchAll ��������
        /// <summary>
        /// ���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃA���C���X�g</param>
        /// <param name="rate">�|���N���X</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, ref Rate rate, out string message)
        {
            // ���b�g���ݒ�i�|���A���b�g�f�[�^�S�Ď擾�j
            rate.LotCount = -1;	// ���b�g���i-1:�i���ݖ���, -1�ȊO:�Y�����b�g���ōi�荞�݁j

            // ����
            int status = SearchProc(out retList, ref rate, ConstantManagement.LogicalMode.GetData01, out message);
            return status;
        }
        #endregion

        #region SearchRate ��������
        /// <summary>
        /// ���������i���b�g�ݒ�ȊO�擾�j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃA���C���X�g</param>
        /// <param name="rate">�|���N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̏����Ɉ�v�����f�[�^���������܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        public int SearchRate(out ArrayList retList, ref Rate rate, ConstantManagement.LogicalMode logicalMode, out string message)
        {
            // ���b�g���ݒ�i���b�g�ݒ�ȊO���擾�j
            rate.LotCount = 0;	// ���b�g���i-1:�i���ݖ���, -1�ȊO:�Y�����b�g���ōi�荞�݁j

            // ����
            int status = SearchProc(out retList, ref rate, logicalMode, out message);
            return status;
        }
        #endregion

        #region Write �������ݏ���
        /// <summary>
        /// �������ݏ���
        /// </summary>
        /// <param name="rateList">�ۑ��f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �������ݏ������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        public int Write(ref ArrayList rateList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraRateList = new ArrayList();
                RateWork rateWork = null;

                for (int i = 0; i < rateList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    rateWork = CopyToRateWorkFromRate((Rate)rateList[i]);

                    paraRateList.Add(rateWork);
                }

                object paraObj = (object)paraRateList;

                // �������ݏ���
                status = this._rateDB.Write(ref paraObj);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�o�^�Ɏ��s���܂����B";
                    return status;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._rateDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region LogicalDelete �_���폜����
        /// <summary>
        /// �_���폜����
        /// </summary>
        /// <param name="rateList">�_���폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �_���폜�������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int LogicalDelete(ref ArrayList rateList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraRateList = new ArrayList();
                RateWork rateWork = null;

                for (int i = 0; i < rateList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    rateWork = CopyToRateWorkFromRate((Rate)rateList[i]);

                    paraRateList.Add(rateWork);
                }
                object paraObj = (object)paraRateList;

                // �_���폜����
                status = this._rateDB.LogicalDelete(ref paraObj);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._rateDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return status;
        }
        #endregion

        #region Revival ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="rateList">�_���폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : ���������i�_���폜�����j���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int Revival(ref ArrayList rateList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                // �f�[�^�������[�v
                ArrayList paraRateList = new ArrayList();
                RateWork rateWork = null;

                for (int i = 0; i < rateList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    rateWork = CopyToRateWorkFromRate((Rate)rateList[i]);

                    paraRateList.Add(rateWork);
                }

                object paraObj = (object)paraRateList;

                // �������ݏ���
                status = this._rateDB.RevivalLogicalDelete(ref paraObj);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }
                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._rateDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region Delete �폜����
        /// <summary>
        /// �폜����
        /// </summary>
        /// <param name="rateList">�폜�f�[�^���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �폜�����i�����폜�j���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2007.10.19</br>
        /// </remarks>
        public int Delete(ref ArrayList rateList, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            message = "";

            try
            {
                byte[] paraRateWork = null;
                RateWork rateWork = null;
                ArrayList rateWorkList = new ArrayList();	// ���[�N�N���X�i�[�pArrayList

                // ���[�N�N���X�i�[�pArrayList�֋l�ߑւ�
                for (int i = 0; i < rateList.Count; i++)
                {
                    // �N���X�f�[�^�����[�N�N���X�f�[�^�ɕϊ�
                    rateWork = CopyToRateWorkFromRate((Rate)rateList[i]);
                    rateWorkList.Add(rateWork);
                }
                // ArrayList����z��𐶐�
                RateWork[] rateWorks = (RateWork[])rateWorkList.ToArray(typeof(RateWork));

                // �V���A���C�Y
                paraRateWork = XmlByteSerializer.Serialize(rateWorks);

                // �����폜����
                status = this._rateDB.Delete(paraRateWork);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // ��������̃G���[����
                    message = "�폜�Ɏ��s���܂����B";
                    return status;
                }

                status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                // �I�t���C������null���Z�b�g
                this._rateDB = null;
                // �ʐM�G���[
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            return status;
        }
        #endregion

        #region �f�[�^�Z�b�g����\�z����
        /// <summary>
        /// �f�[�^�Z�b�g����\�z����
        /// </summary>
        /// <param name="ds">�f�[�^�Z�b�g</param>
        /// <remarks>
        /// <br>Note       : �f�[�^�Z�b�g�̗�����\�z���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private void DataSetColumnConstruction(ref DataSet ds)
        {
            //----------------------------------------------------------------
            // �|���e�[�u�����`
            //----------------------------------------------------------------
            DataTable rateTable = new DataTable(RATE_TABLE);

            // �쐬����
            rateTable.Columns.Add(CREATEDATETIME, typeof(DateTime));
            // �X�V����
            rateTable.Columns.Add(UPDATEDATETIME, typeof(DateTime));
            // ��ƃR�[�h
            rateTable.Columns.Add(ENTERPRISECODE, typeof(string));
            // GUID
            rateTable.Columns.Add(FILEHEADERGUID, typeof(Guid));
            // �X�V�]�ƈ��R�[�h
            rateTable.Columns.Add(UPDEMPLOYEECODE, typeof(string));
            // �X�V�A�Z���u��ID1
            rateTable.Columns.Add(UPDASSEMBLYID1, typeof(string));
            // �X�V�A�Z���u��ID2
            rateTable.Columns.Add(UPDASSEMBLYID2, typeof(string));
            // �_���폜�敪
            rateTable.Columns.Add(LOGICALDELETECODE, typeof(Int32));
            // ���_�R�[�h
            rateTable.Columns.Add(SECTIONCODE, typeof(string));
            // �P���|���ݒ�敪
            rateTable.Columns.Add(UNITRATESETDIVCD, typeof(string));
            // �P����ށi�R�[�h�j
            rateTable.Columns.Add(UNITPRICEKIND, typeof(string));
            // �|���ݒ�敪
            rateTable.Columns.Add(RATESETTINGDIVIDE, typeof(string));
            // �|���ݒ�敪�i���i�j
            rateTable.Columns.Add(RATEMNGGOODSCD, typeof(string));
            // �|���ݒ薼�́i���i�j
            rateTable.Columns.Add(RATEMNGGOODSNM, typeof(string));
            // �|���ݒ�敪�i���Ӑ�j
            rateTable.Columns.Add(RATEMNGCUSTCD, typeof(string));
            // �|���ݒ薼�́i���Ӑ�j
            rateTable.Columns.Add(RATEMNGCUSTNM, typeof(string));
            // ���i���[�J�[�R�[�h
            rateTable.Columns.Add(GOODSMAKERCD, typeof(Int32));
            // ���i�ԍ�
            rateTable.Columns.Add(GOODSNO, typeof(string));
            // ���i�|�������N
            rateTable.Columns.Add(GOODSRATERANK, typeof(string));
            // BL���i�R�[�h
            rateTable.Columns.Add(BLGOODSCODE, typeof(Int32));
            // ���Ӑ�R�[�h
            rateTable.Columns.Add(CUSTOMERCODE, typeof(Int32));
            // ���Ӑ�|���O���[�v�R�[�h
            rateTable.Columns.Add(CUSTRATEGRPCODE, typeof(Int32));
            // �d����R�[�h
            rateTable.Columns.Add(SUPPLIERCD, typeof(Int32));
            // ���b�g��
            rateTable.Columns.Add(LOTCOUNT, typeof(double));
            // �P���Z�o�敪
            rateTable.Columns.Add(UNITPRCCALCDIV, typeof(Int32));
            // ���i�敪
            rateTable.Columns.Add(PRICEDIV, typeof(Int32));
            // ���i
            rateTable.Columns.Add(PRICEFL, typeof(double));
            // �|��
            rateTable.Columns.Add(RATEVAL, typeof(double));
            // �P���[�������P��
            rateTable.Columns.Add(UNPRCFRACPROCUNIT, typeof(double));
            // �P���[�������敪
            rateTable.Columns.Add(UNPRCFRACPROCDIV, typeof(Int32));
            // �폜��
            rateTable.Columns.Add(DELETE_DATE_TITLE, typeof(string));
            // ���i�|���O���[�v�R�[�h
            rateTable.Columns.Add(GOODSRATEGRPCODE, typeof(Int32));
            // BL�O���[�v�R�[�h
            rateTable.Columns.Add(BLGLOUPCODE, typeof(Int32));
            // UP��
            rateTable.Columns.Add(UPRATE, typeof(Double));
            // �e���m�ۗ�
            rateTable.Columns.Add(GRSPROFITSECURERATE, typeof(Double));

            this._dataTableList.Tables.Add(rateTable);
        }
        #endregion

        #region �N���X�����o�R�s�[����
        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�|���ݒ�N���X�ˊ|���ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="rate">�|���ݒ�N���X</param>
        /// <returns>RateWork</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ�N���X����|���ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private RateWork CopyToRateWorkFromRate(Rate rate)
        {
            RateWork rateWork = new RateWork();

            // �쐬����
            rateWork.CreateDateTime = rate.CreateDateTime;
            // �X�V����
            rateWork.UpdateDateTime = rate.UpdateDateTime;
            // ��ƃR�[�h
            rateWork.EnterpriseCode = rate.EnterpriseCode;
            // GUID
            rateWork.FileHeaderGuid = rate.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            rateWork.UpdEmployeeCode = rate.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            rateWork.UpdAssemblyId1 = rate.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            rateWork.UpdAssemblyId2 = rate.UpdAssemblyId2;
            // �_���폜�敪
            rateWork.LogicalDeleteCode = rate.LogicalDeleteCode;
            // ���_�R�[�h
            rateWork.SectionCode = rate.SectionCode;
            // �P���|���ݒ�敪
            rateWork.UnitRateSetDivCd = rate.UnitRateSetDivCd;
            // �P�����
            rateWork.UnitPriceKind = rate.UnitPriceKind;
            // �|���ݒ�敪
            rateWork.RateSettingDivide = rate.RateSettingDivide;
            // �|���ݒ�敪�i���i�j
            rateWork.RateMngGoodsCd = rate.RateMngGoodsCd;
            // �|���ݒ薼�́i���i�j
            rateWork.RateMngGoodsNm = rate.RateMngGoodsNm;
            // �|���ݒ�敪�i���Ӑ�j
            rateWork.RateMngCustCd = rate.RateMngCustCd;
            // �|���ݒ薼�́i���Ӑ�j
            rateWork.RateMngCustNm = rate.RateMngCustNm;
            // ���i���[�J�[�R�[�h
            rateWork.GoodsMakerCd = rate.GoodsMakerCd;
            // ���i�ԍ�
            rateWork.GoodsNo = rate.GoodsNo;
            // ���i�|�������N
            rateWork.GoodsRateRank = rate.GoodsRateRank;
            // BL���i�R�[�h
            rateWork.BLGoodsCode = rate.BLGoodsCode;
            // ���Ӑ�R�[�h
            rateWork.CustomerCode = rate.CustomerCode;
            // ���Ӑ�|���O���[�v�R�[�h
            rateWork.CustRateGrpCode = rate.CustRateGrpCode;
            // �d����R�[�h
            rateWork.SupplierCd = rate.SupplierCd;
            // ���b�g��
            rateWork.LotCount = rate.LotCount;
            // ���i
            rateWork.PriceFl = rate.PriceFl;
            // �|��
            rateWork.RateVal = rate.RateVal;
            // �P���[�������P��
            rateWork.UnPrcFracProcUnit = rate.UnPrcFracProcUnit;
            // �P���[�������敪
            rateWork.UnPrcFracProcDiv = rate.UnPrcFracProcDiv;
            // ���i�|���O���[�v�R�[�h
            rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;
            // BL�O���[�v�R�[�h
            rateWork.BLGroupCode = rate.BLGroupCode;
            // UP��
            rateWork.UpRate = rate.UpRate;
            // �e���m�ۗ�
            rateWork.GrsProfitSecureRate = rate.GrsProfitSecureRate;

            return rateWork;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�|���ݒ胏�[�N�N���X�ˊ|���ݒ�N���X�j
        /// </summary>
        /// <param name="rateWork">�|���ݒ胏�[�N�N���X</param>
        /// <returns>Rate</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ胏�[�N�N���X����|���ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private Rate CopyToRateFromRateWork(RateWork rateWork)
        {
            Rate rate = new Rate();

            // �쐬����
            rate.CreateDateTime = rateWork.CreateDateTime;
            // �X�V����
            rate.UpdateDateTime = rateWork.UpdateDateTime;
            // ��ƃR�[�h
            rate.EnterpriseCode = rateWork.EnterpriseCode;
            // GUID
            rate.FileHeaderGuid = rateWork.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            rate.UpdEmployeeCode = rateWork.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            rate.UpdAssemblyId1 = rateWork.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            rate.UpdAssemblyId2 = rateWork.UpdAssemblyId2;
            // �_���폜�敪
            rate.LogicalDeleteCode = rateWork.LogicalDeleteCode;
            // ���_�R�[�h
            rate.SectionCode = rateWork.SectionCode.Trim();
            // �P���|���ݒ�敪
            rate.UnitRateSetDivCd = rateWork.UnitRateSetDivCd.Trim();
            // �P�����
            rate.UnitPriceKind = rateWork.UnitPriceKind.Trim();
            // �|���ݒ�敪
            rate.RateSettingDivide = rateWork.RateSettingDivide.Trim();
            // �|���ݒ�敪�i���i�j
            rate.RateMngGoodsCd = rateWork.RateMngGoodsCd.Trim();
            // �|���ݒ薼�́i���i�j
            rate.RateMngGoodsNm = rateWork.RateMngGoodsNm.Trim();
            // �|���ݒ�敪�i���Ӑ�j
            rate.RateMngCustCd = rateWork.RateMngCustCd.Trim();
            // �|���ݒ薼�́i���Ӑ�j
            rate.RateMngCustNm = rateWork.RateMngCustNm.Trim();
            // ���i���[�J�[�R�[�h
            rate.GoodsMakerCd = rateWork.GoodsMakerCd;
            // ���i�ԍ�
            rate.GoodsNo = rateWork.GoodsNo.Trim();
            // ���i�|�������N
            rate.GoodsRateRank = rateWork.GoodsRateRank.Trim();
            // BL���i�R�[�h
            rate.BLGoodsCode = rateWork.BLGoodsCode;
            // ���Ӑ�R�[�h
            rate.CustomerCode = rateWork.CustomerCode;
            // ���Ӑ�|���O���[�v�R�[�h
            rate.CustRateGrpCode = rateWork.CustRateGrpCode;
            // �d����R�[�h
            rate.SupplierCd = rateWork.SupplierCd;
            // ���b�g��
            rate.LotCount = rateWork.LotCount;
            // ���i
            rate.PriceFl = rateWork.PriceFl;
            // �|��
            rate.RateVal = rateWork.RateVal;
            // �P���[�������P��
            rate.UnPrcFracProcUnit = rateWork.UnPrcFracProcUnit;
            // �P���[�������敪
            rate.UnPrcFracProcDiv = rateWork.UnPrcFracProcDiv;
            // ���i�|���O���[�v�R�[�h
            rate.GoodsRateGrpCode = rateWork.GoodsRateGrpCode;
            // BL�O���[�v�R�[�h
            rate.BLGroupCode = rateWork.BLGroupCode;
            // UP��
            rate.UpRate = rateWork.UpRate;
            // �e���m�ۗ�
            rate.GrsProfitSecureRate = rateWork.GrsProfitSecureRate;
            return rate;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�|���ݒ�N���X��DataRow�j
        /// </summary>
        /// <param name="rateWork">�|���ݒ�N���X</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ胏�[�N�N���X����|���ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DataRow CopyToDataRowFromRateWork(ref RateWork rateWork)
        {
            Rate rate = this.CopyToRateFromRateWork(rateWork);

            // �|���ݒ�}�X�^�ւ̓o�^
            DataRow dr = null;

            dr = this._dataTableList.Tables[RATE_TABLE].NewRow();

            // �쐬����
            dr[CREATEDATETIME] = rate.CreateDateTime;
            // �X�V����
            dr[UPDATEDATETIME] = rate.UpdateDateTime;
            // ��ƃR�[�h
            dr[ENTERPRISECODE] = rate.EnterpriseCode;

            if (rate.FileHeaderGuid == Guid.Empty)
            {
                // GUID
                dr[FILEHEADERGUID] = Guid.NewGuid();
            }
            else
            {
                // GUID
                dr[FILEHEADERGUID] = rate.FileHeaderGuid;
            }
            // �X�V�]�ƈ��R�[�h
            dr[UPDEMPLOYEECODE] = rate.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            dr[UPDASSEMBLYID1] = rate.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            dr[UPDASSEMBLYID2] = rate.UpdAssemblyId2;
            // �_���폜�敪
            dr[LOGICALDELETECODE] = rate.LogicalDeleteCode;
            // ���_�R�[�h
            dr[SECTIONCODE] = rate.SectionCode;
            // �P���|���ݒ�敪
            dr[UNITRATESETDIVCD] = rate.UnitRateSetDivCd;
            // �P�����
            dr[UNITPRICEKIND] = rate.UnitPriceKind;
            // �|���ݒ�敪
            dr[RATESETTINGDIVIDE] = rate.RateSettingDivide;
            // �|���ݒ�敪�i���i�j
            dr[RATEMNGGOODSCD] = rate.RateMngGoodsCd;
            // �|���ݒ薼�́i���i�j
            dr[RATEMNGGOODSNM] = rate.RateMngGoodsNm;
            // �|���ݒ�敪�i���Ӑ�j
            dr[RATEMNGCUSTCD] = rate.RateMngCustCd;
            // �|���ݒ薼�́i���Ӑ�j
            dr[RATEMNGCUSTNM] = rate.RateMngCustNm;
            // ���i���[�J�[�R�[�h
            dr[GOODSMAKERCD] = rate.GoodsMakerCd;
            // ���i�ԍ�
            dr[GOODSNO] = rate.GoodsNo;
            // ���i�|�������N
            dr[GOODSRATERANK] = rate.GoodsRateRank;
            // BL���i�R�[�h
            dr[BLGOODSCODE] = rate.BLGoodsCode;
            // ���Ӑ�R�[�h
            dr[CUSTOMERCODE] = rate.CustomerCode;
            // ���Ӑ�|���O���[�v�R�[�h
            dr[CUSTRATEGRPCODE] = rate.CustRateGrpCode;
            // �d����R�[�h
            dr[SUPPLIERCD] = rate.SupplierCd;
            // ���b�g��
            dr[LOTCOUNT] = rate.LotCount;
            // ���i
            dr[PRICEFL] = rate.PriceFl;
            // �|��
            dr[RATEVAL] = rate.RateVal;
            // �P���[�������P��
            dr[UNPRCFRACPROCUNIT] = rate.UnPrcFracProcUnit;
            // �P���[�������敪
            dr[UNPRCFRACPROCDIV] = rate.UnPrcFracProcDiv;
            // ���i�|���O���[�v�R�[�h
            dr[GOODSRATEGRPCODE] = rate.GoodsRateGrpCode;
            // BL�O���[�v�R�[�h
            dr[BLGLOUPCODE] = rate.BLGroupCode;
            // UP��
            dr[UPRATE] = rate.UpRate;
            // �e���m�ۗ�
            dr[GRSPROFITSECURERATE] = rate.GrsProfitSecureRate;

            // �폜��
            if (rate.LogicalDeleteCode == 0)
            {
                dr[DELETE_DATE_TITLE] = "";
            }
            else
            {
                dr[DELETE_DATE_TITLE] = rate.UpdateDateTimeJpInFormal;
            }

            return dr;
        }
        #endregion

        /// <summary>
        /// �N���X�����o�[�ݒ菈���i�|���ݒ�N���X��DataRow�j
        /// </summary>
        /// <param name="rateWork">�|���ݒ�N���X</param>
        /// <returns>DataRow</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ胏�[�N�N���X����|���ݒ�N���X�փ����o�[�ւ̐ݒ���s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private DataRow SetDataRowFromRateWork(DataRow dr, Rate rate)
        {
            // �쐬����
            dr[CREATEDATETIME] = rate.CreateDateTime;
            // �X�V����
            dr[UPDATEDATETIME] = rate.UpdateDateTime;
            // ��ƃR�[�h
            dr[ENTERPRISECODE] = rate.EnterpriseCode;
            // GUID
            dr[FILEHEADERGUID] = rate.FileHeaderGuid;
            // �X�V�]�ƈ��R�[�h
            dr[UPDEMPLOYEECODE] = rate.UpdEmployeeCode;
            // �X�V�A�Z���u��ID1
            dr[UPDASSEMBLYID1] = rate.UpdAssemblyId1;
            // �X�V�A�Z���u��ID2
            dr[UPDASSEMBLYID2] = rate.UpdAssemblyId2;
            // �_���폜�敪
            dr[LOGICALDELETECODE] = rate.LogicalDeleteCode;
            // ���_�R�[�h
            dr[SECTIONCODE] = rate.SectionCode;
            // �P���|���ݒ�敪
            dr[UNITRATESETDIVCD] = rate.UnitRateSetDivCd;
            // �P�����
            dr[UNITPRICEKIND] = rate.UnitPriceKind;
            // �|���ݒ�敪
            dr[RATESETTINGDIVIDE] = rate.RateSettingDivide;
            // �|���ݒ�敪�i���i�j
            dr[RATEMNGGOODSCD] = rate.RateMngGoodsCd;
            // �|���ݒ薼�́i���i�j
            dr[RATEMNGGOODSNM] = rate.RateMngGoodsNm;
            // �|���ݒ�敪�i���Ӑ�j
            dr[RATEMNGCUSTCD] = rate.RateMngCustCd;
            // �|���ݒ薼�́i���Ӑ�j
            dr[RATEMNGCUSTNM] = rate.RateMngCustNm;
            // ���i���[�J�[�R�[�h
            dr[GOODSMAKERCD] = rate.GoodsMakerCd;
            // ���i�ԍ�
            dr[GOODSNO] = rate.GoodsNo;
            // ���i�|�������N
            dr[GOODSRATERANK] = rate.GoodsRateRank;
            // BL���i�R�[�h
            dr[BLGOODSCODE] = rate.BLGoodsCode;
            // ���Ӑ�R�[�h
            dr[CUSTOMERCODE] = rate.CustomerCode;
            // ���Ӑ�|���O���[�v�R�[�h
            dr[CUSTRATEGRPCODE] = rate.CustRateGrpCode;
            // �d����R�[�h
            dr[SUPPLIERCD] = rate.SupplierCd;
            // ���b�g��
            dr[LOTCOUNT] = rate.LotCount;
            // ���i
            dr[PRICEFL] = rate.PriceFl;
            // �|��
            dr[RATEVAL] = rate.RateVal;
            // �P���[�������P��
            dr[UNPRCFRACPROCUNIT] = rate.UnPrcFracProcUnit;
            // �P���[�������敪
            dr[UNPRCFRACPROCDIV] = rate.UnPrcFracProcDiv;
            // �폜��
            dr[DELETE_DATE_TITLE] = rate.LogicalDeleteCode;
            // ���i�|���O���[�v�R�[�h
            dr[GOODSRATEGRPCODE] = rate.GoodsRateGrpCode;
            // BL�O���[�v�R�[�h
            dr[BLGLOUPCODE] = rate.BLGroupCode;
            // UP��
            dr[UPRATE] = rate.UpRate;
            // �e���m�ۗ�
            dr[GRSPROFITSECURERATE] = rate.GrsProfitSecureRate;

            return dr;
        }

        #region SearchProc �����������C���i�_���폜�܂ށj
        /// <summary>
        /// �����������C���i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="rate">�|���N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private int SearchProc(out DataTable retList
                              , ref Rate rate
                              , ConstantManagement.LogicalMode logicalMode
                              , out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = null;
            message = "";

            try
            {
                //==========================================
                // �|���}�X�^�ǂݍ���
                //==========================================
                //------------------------------------------------------------------
                // �P���|���ݒ�敪�쐬(�P����ށ{�|���ݒ�敪�{�V���敪)
                //   �V���敪���킸�����擾����ꍇ�A�P����ށ{�|���ݒ�敪�ƂȂ�
                //------------------------------------------------------------------
                string wkStr = "";
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(rate.UnitPriceKind);
                _stringBuilder.Append(rate.RateSettingDivide);

                wkStr = _stringBuilder.ToString();

                // ���o�����p�����[�^
                RateWork paraWork = new RateWork();

                paraWork.EnterpriseCode = rate.EnterpriseCode;				// ��ƃR�[�h
                paraWork.SectionCode = rate.SectionCode;					// ���_�R�[�h
                paraWork.UnitRateSetDivCd = wkStr;							// �P���|���ݒ�敪
                paraWork.UnitPriceKind = rate.UnitPriceKind;				// �P�����
                paraWork.RateSettingDivide = rate.RateSettingDivide;		// �|���ݒ�敪
                paraWork.RateMngGoodsCd = rate.RateMngGoodsCd;				// �|���ݒ�敪�i���i�j
                paraWork.RateMngGoodsNm = rate.RateMngGoodsNm;				// �|���ݒ薼�́i���i�j
                paraWork.RateMngCustCd = rate.RateMngCustCd;				// �|���ݒ�敪�i���Ӑ�j
                paraWork.RateMngCustNm = rate.RateMngCustNm;				// �|���ݒ薼�́i���Ӑ�j
                paraWork.GoodsMakerCd = rate.GoodsMakerCd;					// ���i���[�J�[�R�[�h
                paraWork.GoodsNo = rate.GoodsNo;							// ���i�ԍ�
                paraWork.GoodsRateRank = rate.GoodsRateRank;				// ���i�|�������N
                paraWork.BLGoodsCode = rate.BLGoodsCode;					// �a�k���i�R�[�h
                paraWork.CustomerCode = rate.CustomerCode;					// ���Ӑ�R�[�h
                paraWork.CustRateGrpCode = rate.CustRateGrpCode;			// ���Ӑ�|���f�R�[�h
                paraWork.SupplierCd = rate.SupplierCd;						// �d����R�[�h
                paraWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;			// ���i�|���O���[�v�R�[�h
                paraWork.BLGroupCode = rate.BLGroupCode;					// BL�O���[�v�R�[�h
                paraWork.LotCount = -1;										// ���b�g���i-1:�i���ݖ���, -1�ȊO:�Y�����b�g���ōi�荞�݁j
                paraWork.LogicalDeleteCode = (int)logicalMode;				// �_���폜�敪

                ArrayList paraList = new ArrayList();
                paraList.Add(paraWork);

                // �����[�g�߂胊�X�g
                object rateWorkList = null;

                // �|���}�X�^����
                status = this._rateDB.Search(out rateWorkList, paraList, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �f�[�^�e�[�u���ɃZ�b�g
                    foreach (RateWork rateWork in (ArrayList)rateWorkList)
                    {
                        AddRowFromRateWork(rateWork);
                    }
                }

                //==========================================
                // �f�[�^�Z�b�g��Ԃ�
                //==========================================
                retList = this._dataTableList.Tables[RATE_TABLE];

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }
        #endregion

        #region SearchProc �����������C���i�_���폜�܂ށj
        /// <summary>
        /// �����������C���i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃA���C���X�g</param>
        /// <param name="rate">�|���N���X</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList
                              , ref Rate rate
                              , ConstantManagement.LogicalMode logicalMode
                              , out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = new ArrayList();
            message = "";

            try
            {
                ArrayList wkList = new ArrayList();

                //==========================================
                // �|���}�X�^�ǂݍ���
                //==========================================
                //------------------------------------------------------------------
                // �P���|���ݒ�敪�쐬(�P����ށ{�|���ݒ�敪�{�V���敪)
                //   �V���敪���킸�����擾����ꍇ�A�P����ށ{�|���ݒ�敪�ƂȂ�
                //------------------------------------------------------------------
                string wkStr = "";
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(rate.UnitPriceKind);
                _stringBuilder.Append(rate.RateSettingDivide);

                wkStr = _stringBuilder.ToString();

                // ADD 2009/11/20 MANTIS�Ή�[14598]�F�݌ɏ��i�}�X�^�œo�^�ς݂̓��Ӑ�|���O���[�v���\������Ȃ� ---------->>>>>
                // TODO:�P���|���ݒ�敪��␳�c�|���ݒ�敪���ȗ�(��F4A��6A���擾�������ꍇ)�p
                if (wkStr.Length < 3) wkStr = string.Empty; // �ʏ��"14A"����3�����ȏ�ɂȂ�
                // ADD 2009/11/20 MANTIS�Ή�[14598]�F�݌ɏ��i�}�X�^�œo�^�ς݂̓��Ӑ�|���O���[�v���\������Ȃ� ----------<<<<<

                // ���o�����p�����[�^
                RateWork paraWork = new RateWork();

                paraWork.EnterpriseCode = rate.EnterpriseCode;				// ��ƃR�[�h
                paraWork.SectionCode = rate.SectionCode;					// ���_�R�[�h
                paraWork.UnitRateSetDivCd = wkStr;							// �P���|���ݒ�敪
                paraWork.UnitPriceKind = rate.UnitPriceKind;				// �P�����
                paraWork.RateSettingDivide = rate.RateSettingDivide;		// �|���ݒ�敪
                paraWork.RateMngGoodsCd = rate.RateMngGoodsCd;				// �|���ݒ�敪�i���i�j
                paraWork.RateMngGoodsNm = rate.RateMngGoodsNm;				// �|���ݒ薼�́i���i�j
                paraWork.RateMngCustCd = rate.RateMngCustCd;				// �|���ݒ�敪�i���Ӑ�j
                paraWork.RateMngCustNm = rate.RateMngCustNm;				// �|���ݒ薼�́i���Ӑ�j
                paraWork.GoodsMakerCd = rate.GoodsMakerCd;					// ���i���[�J�[�R�[�h
                paraWork.GoodsNo = rate.GoodsNo;							// ���i�ԍ�
                paraWork.GoodsRateRank = rate.GoodsRateRank;				// ���i�|�������N
                paraWork.BLGoodsCode = rate.BLGoodsCode;					// �a�k���i�R�[�h
                paraWork.CustomerCode = rate.CustomerCode;					// ���Ӑ�R�[�h
                paraWork.CustRateGrpCode = rate.CustRateGrpCode;			// ���Ӑ�|���f�R�[�h
                paraWork.SupplierCd = rate.SupplierCd;						// �d����R�[�h
                paraWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;			// ���i�|���O���[�v�R�[�h
                paraWork.BLGroupCode = rate.BLGroupCode;					// BL�O���[�v�R�[�h

                paraWork.LotCount = rate.LotCount;							// ���b�g���i-1:�i���ݖ���, -1�ȊO:�Y�����b�g���ōi�荞�݁j

                ArrayList paraList = new ArrayList();
                paraList.Add(paraWork);

                // �����[�g�߂胊�X�g
                object rateWorkList = null;

                // �|���}�X�^����
                status = this._rateDB.Search(out rateWorkList, paraList, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    wkList = rateWorkList as ArrayList;
                    if (wkList != null)
                    {
                        foreach (RateWork wkRateWork in wkList)
                        {
                            // �����o�R�s�[
                            retList.Add(CopyToRateFromRateWork(wkRateWork));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }
        #endregion

        #region SearchProc �����������C���i�_���폜�܂ށj
        /// <summary>
        /// �����������C���i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃe�[�u��</param>
        /// <param name="rateList">�|���I�u�W�F�N�g���X�g</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̕��������������s���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        private int SearchProc(out DataTable retList
                             , List<Rate> rateList
                             , ConstantManagement.LogicalMode logicalMode
                             , out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = null;
            message = "";

            try
            {
                ArrayList paraList = new ArrayList();
                //==========================================
                // �|���}�X�^�ǂݍ���
                //==========================================
                foreach (Rate rate in rateList)
                {
                    //------------------------------------------------------------------
                    // �P���|���ݒ�敪�쐬(�P����ށ{�|���ݒ�敪�{�V���敪)
                    //   �V���敪���킸�����擾����ꍇ�A�P����ށ{�|���ݒ�敪�ƂȂ�
                    //------------------------------------------------------------------
                    string wkStr = "";
                    _stringBuilder.Remove(0, _stringBuilder.Length);
                    _stringBuilder.Append(rate.UnitPriceKind);
                    _stringBuilder.Append(rate.RateSettingDivide);

                    wkStr = _stringBuilder.ToString();

                    // ���o�����p�����[�^
                    RateWork paraWork = new RateWork();

                    paraWork.EnterpriseCode = rate.EnterpriseCode;				// ��ƃR�[�h
                    paraWork.SectionCode = rate.SectionCode;					// ���_�R�[�h
                    paraWork.UnitRateSetDivCd = wkStr;							// �P���|���ݒ�敪
                    paraWork.UnitPriceKind = rate.UnitPriceKind;				// �P�����
                    paraWork.RateSettingDivide = rate.RateSettingDivide;		// �|���ݒ�敪
                    paraWork.RateMngGoodsCd = rate.RateMngGoodsCd;				// �|���ݒ�敪�i���i�j
                    paraWork.RateMngGoodsNm = rate.RateMngGoodsNm;				// �|���ݒ薼�́i���i�j
                    paraWork.RateMngCustCd = rate.RateMngCustCd;				// �|���ݒ�敪�i���Ӑ�j
                    paraWork.RateMngCustNm = rate.RateMngCustNm;				// �|���ݒ薼�́i���Ӑ�j
                    paraWork.GoodsMakerCd = rate.GoodsMakerCd;					// ���i���[�J�[�R�[�h
                    paraWork.GoodsNo = rate.GoodsNo;							// ���i�ԍ�
                    paraWork.GoodsRateRank = rate.GoodsRateRank;				// ���i�|�������N
                    paraWork.BLGoodsCode = rate.BLGoodsCode;					// �a�k���i�R�[�h
                    paraWork.CustomerCode = rate.CustomerCode;					// ���Ӑ�R�[�h
                    paraWork.CustRateGrpCode = rate.CustRateGrpCode;			// ���Ӑ�|���f�R�[�h
                    paraWork.SupplierCd = rate.SupplierCd;						// �d����R�[�h
                    paraWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;			// ���i�|���O���[�v�R�[�h
                    paraWork.BLGroupCode = rate.BLGroupCode;					// BL�O���[�v�R�[�h

                    paraWork.LotCount = -1;										// ���b�g���i-1:�i���ݖ���, -1�ȊO:�Y�����b�g���ōi�荞�݁j

                    paraList.Add(paraWork);
                }

                // �����[�g�߂胊�X�g
                object rateWorkList = null;

                // �|���}�X�^����
                status = this._rateDB.Search(out rateWorkList, paraList, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �f�[�^�e�[�u���ɃZ�b�g
                    foreach (RateWork rateWork in (ArrayList)rateWorkList)
                    {
                        AddRowFromRateWork(rateWork);
                    }
                }

                //==========================================
                // �f�[�^�Z�b�g��Ԃ�
                //==========================================
                retList = this._dataTableList.Tables[RATE_TABLE];

            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }

        // 2009.02.11 Add >>>
        /// <summary>
        /// �����������C���i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃe�[�u��</param>
        /// <param name="rateList">�|���I�u�W�F�N�g���X�g</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^�̕��������������s���܂��B</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2009.02.11</br>
        /// </remarks>
        private int SearchProc(out List<Rate> retList
                             , List<Rate> rateList
                             , ConstantManagement.LogicalMode logicalMode
                             , out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = null;
            message = "";

            try
            {
                ArrayList paraList = new ArrayList();
                //==========================================
                // �|���}�X�^�ǂݍ���
                //==========================================
                foreach (Rate rate in rateList)
                {
                    //------------------------------------------------------------------
                    // �P���|���ݒ�敪�쐬(�P����ށ{�|���ݒ�敪�{�V���敪)
                    //   �V���敪���킸�����擾����ꍇ�A�P����ށ{�|���ݒ�敪�ƂȂ�
                    //------------------------------------------------------------------
                    string wkStr = "";
                    _stringBuilder.Remove(0, _stringBuilder.Length);
                    _stringBuilder.Append(rate.UnitPriceKind);
                    _stringBuilder.Append(rate.RateSettingDivide);

                    wkStr = _stringBuilder.ToString();

                    // ���o�����p�����[�^
                    RateWork paraWork = new RateWork();

                    paraWork.EnterpriseCode = rate.EnterpriseCode;				// ��ƃR�[�h
                    paraWork.SectionCode = rate.SectionCode;					// ���_�R�[�h
                    paraWork.UnitRateSetDivCd = wkStr;							// �P���|���ݒ�敪
                    paraWork.UnitPriceKind = rate.UnitPriceKind;				// �P�����
                    paraWork.RateSettingDivide = rate.RateSettingDivide;		// �|���ݒ�敪
                    paraWork.RateMngGoodsCd = rate.RateMngGoodsCd;				// �|���ݒ�敪�i���i�j
                    paraWork.RateMngGoodsNm = rate.RateMngGoodsNm;				// �|���ݒ薼�́i���i�j
                    paraWork.RateMngCustCd = rate.RateMngCustCd;				// �|���ݒ�敪�i���Ӑ�j
                    paraWork.RateMngCustNm = rate.RateMngCustNm;				// �|���ݒ薼�́i���Ӑ�j
                    paraWork.GoodsMakerCd = rate.GoodsMakerCd;					// ���i���[�J�[�R�[�h
                    paraWork.GoodsNo = rate.GoodsNo;							// ���i�ԍ�
                    paraWork.GoodsRateRank = rate.GoodsRateRank;				// ���i�|�������N
                    paraWork.BLGoodsCode = rate.BLGoodsCode;					// �a�k���i�R�[�h
                    paraWork.CustomerCode = rate.CustomerCode;					// ���Ӑ�R�[�h
                    paraWork.CustRateGrpCode = rate.CustRateGrpCode;			// ���Ӑ�|���f�R�[�h
                    paraWork.SupplierCd = rate.SupplierCd;						// �d����R�[�h
                    paraWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;			// ���i�|���O���[�v�R�[�h
                    paraWork.BLGroupCode = rate.BLGroupCode;					// BL�O���[�v�R�[�h

                    paraWork.LotCount = -1;										// ���b�g���i-1:�i���ݖ���, -1�ȊO:�Y�����b�g���ōi�荞�݁j

                    paraList.Add(paraWork);
                }

                // �����[�g�߂胊�X�g
                object rateWorkList = null;

                // �|���}�X�^����
                status = this._rateDB.Search(out rateWorkList, paraList, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retList = new List<Rate>();
                    // �f�[�^�e�[�u���ɃZ�b�g
                    foreach (RateWork rateWork in (ArrayList)rateWorkList)
                    {
                        retList.Add(CopyToRateFromRateWork(rateWork));
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }
        // 2009.02.11 Add <<<
        #endregion

        /// <summary>
        /// �|���}�X�^�@���@�f�[�^�e�[�u���@�ǉ�����
        /// </summary>
        /// <param name="rateWork"></param>
        private void AddRowFromRateWork(RateWork rateWork)
        {
            DataRow dr;

            try
            {
                // �|���O���b�h
                dr = CopyToDataRowFromRateWork(ref rateWork);
                this._dataTableList.Tables[RATE_TABLE].Rows.Add(dr);
            }
            catch (Exception)
            {
            }
        }

        #region Read ��������
        /// <summary>
        /// �|�����R�[�h�擾����
        /// </summary>
        /// <param name="rate">�|���f�[�^</param>
        /// <returns>�X�e�[�^�X</returns>
        /// <remarks>
        /// <br>Note       : �����������s���܂��B
        ///                  rate�N���X�Ɍ����f�[�^��ݒ肵�A���ʂ�rate�N���X�Ɋi�[���܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2008/09/25</br>
        /// </remarks>
        public int Read(ref Rate rate)
        {
            try
            {
                int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
                RateWork rateWork = new RateWork();

                // �����f�[�^���H(�P����ށ{�|���ݒ�敪�{�V���敪)
                string wkStr = "";
                _stringBuilder.Remove(0, _stringBuilder.Length);
                _stringBuilder.Append(rate.UnitPriceKind);
                _stringBuilder.Append(rate.RateSettingDivide);

                wkStr = _stringBuilder.ToString();

                // ���o�����p�����[�^
                rateWork.EnterpriseCode = rate.EnterpriseCode;			// ��ƃR�[�h
                rateWork.SectionCode = rate.SectionCode;				// ���_�R�[�h
                rateWork.UnitRateSetDivCd = wkStr;						// �P���|���ݒ�敪
                rateWork.UnitPriceKind = rate.UnitPriceKind;			// �P�����
                rateWork.RateSettingDivide = rate.RateSettingDivide;		// �|���ݒ�敪
                rateWork.RateMngGoodsCd = rate.RateMngGoodsCd;			// �|���ݒ�敪�i���i�j
                rateWork.RateMngGoodsNm = rate.RateMngGoodsNm;			// �|���ݒ薼�́i���i�j
                rateWork.RateMngCustCd = rate.RateMngCustCd;			// �|���ݒ�敪�i���Ӑ�j
                rateWork.RateMngCustNm = rate.RateMngCustNm;			// �|���ݒ薼�́i���Ӑ�j
                rateWork.GoodsMakerCd = rate.GoodsMakerCd;			// ���i���[�J�[�R�[�h
                rateWork.GoodsNo = rate.GoodsNo;					// ���i�ԍ�
                rateWork.GoodsRateRank = rate.GoodsRateRank;			// ���i�|�������N
                rateWork.BLGoodsCode = rate.BLGoodsCode;				// �a�k���i�R�[�h
                rateWork.CustomerCode = rate.CustomerCode;			// ���Ӑ�R�[�h
                rateWork.CustRateGrpCode = rate.CustRateGrpCode;			// ���Ӑ�|���f�R�[�h
                rateWork.SupplierCd = rate.SupplierCd;				// �d����R�[�h
                rateWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;		// ���i�|���O���[�v�R�[�h
                rateWork.BLGroupCode = rate.BLGroupCode;				// BL�O���[�v�R�[�h

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(rateWork);
                status = this._rateDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XML�̓ǂݍ���
                    rateWork = (RateWork)XmlByteSerializer.Deserialize(parabyte, typeof(RateWork));
                }

                if (status == 0)
                {
                    // �N���X�������o�R�s�[
                    rate = CopyToRateFromRateWork(rateWork);
                }

                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                rate = null;
                //�I�t���C������null���Z�b�g
                this._rateDB = null;
                return -1;
            }
        }
        #endregion

        //�@--- ADD hunagt 2013/06/13 PM-TAB�Ή� ---------- >>>>>
        #region PM-TAB�Ή�
        /// <summary>
        /// �|���}�X�^�������������i�_���폜�܂܂Ȃ��j
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="rateList">�|���I�u�W�F�N�g���X�g</param>
        /// <param name="message">���b�Z�[�W</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �|���}�X�^���X�g�̏����Ɉ�v�����f�[�^���������܂��B�_���폜�f�[�^�͒��o�ΏۊO</br>
        /// <br>Programmer : huangt</br>
        /// <br>Date       : 2013/06/13</br>
        /// </remarks>
        public int SearchForTablet(out List<Rate> retList, List<Rate> rateList, out string message)
        {
            // ����
            int status = SearchForTabletProc(out retList, rateList, 0, out message);
            return status;
        }

        private int SearchForTabletProc(out List<Rate> retList
                     , List<Rate> rateList
                     , ConstantManagement.LogicalMode logicalMode
                     , out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = null;
            message = "";

            try
            {
                ArrayList paraList = new ArrayList();
                //==========================================
                // �|���}�X�^�ǂݍ���
                //==========================================
                foreach (Rate rate in rateList)
                {
                    //------------------------------------------------------------------
                    // �P���|���ݒ�敪�쐬(�P����ށ{�|���ݒ�敪�{�V���敪)
                    //   �V���敪���킸�����擾����ꍇ�A�P����ށ{�|���ݒ�敪�ƂȂ�
                    //------------------------------------------------------------------
                    string wkStr = "";
                    _stringBuilder.Remove(0, _stringBuilder.Length);
                    _stringBuilder.Append(rate.UnitPriceKind);
                    _stringBuilder.Append(rate.RateSettingDivide);

                    wkStr = _stringBuilder.ToString();

                    // ���o�����p�����[�^
                    RateWork paraWork = new RateWork();

                    paraWork.EnterpriseCode = rate.EnterpriseCode;				// ��ƃR�[�h
                    paraWork.SectionCode = rate.SectionCode;					// ���_�R�[�h
                    paraWork.UnitRateSetDivCd = wkStr;							// �P���|���ݒ�敪
                    paraWork.UnitPriceKind = rate.UnitPriceKind;				// �P�����
                    paraWork.RateSettingDivide = rate.RateSettingDivide;		// �|���ݒ�敪
                    paraWork.RateMngGoodsCd = rate.RateMngGoodsCd;				// �|���ݒ�敪�i���i�j
                    paraWork.RateMngGoodsNm = rate.RateMngGoodsNm;				// �|���ݒ薼�́i���i�j
                    paraWork.RateMngCustCd = rate.RateMngCustCd;				// �|���ݒ�敪�i���Ӑ�j
                    paraWork.RateMngCustNm = rate.RateMngCustNm;				// �|���ݒ薼�́i���Ӑ�j
                    paraWork.GoodsMakerCd = rate.GoodsMakerCd;					// ���i���[�J�[�R�[�h
                    paraWork.GoodsNo = rate.GoodsNo;							// ���i�ԍ�
                    paraWork.GoodsRateRank = rate.GoodsRateRank;				// ���i�|�������N
                    paraWork.BLGoodsCode = rate.BLGoodsCode;					// �a�k���i�R�[�h
                    paraWork.CustomerCode = rate.CustomerCode;					// ���Ӑ�R�[�h
                    paraWork.CustRateGrpCode = rate.CustRateGrpCode;			// ���Ӑ�|���f�R�[�h
                    paraWork.SupplierCd = rate.SupplierCd;						// �d����R�[�h
                    paraWork.GoodsRateGrpCode = rate.GoodsRateGrpCode;			// ���i�|���O���[�v�R�[�h
                    paraWork.BLGroupCode = rate.BLGroupCode;					// BL�O���[�v�R�[�h

                    paraList.Add(paraWork);
                }

                // �����[�g�߂胊�X�g
                object rateWorkList = null;

                // �|���}�X�^����
                status = this._rateDB.SearchForTablet(out rateWorkList, paraList, 0, logicalMode);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    retList = new List<Rate>();
                    // �f�[�^�e�[�u���ɃZ�b�g
                    foreach (RateWork rateWork in (ArrayList)rateWorkList)
                    {
                        retList.Add(CopyToRateFromRateWork(rateWork));
                    }
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }
        #endregion
        //�@--- ADD hunagt 2013/06/13 PM-TAB�Ή� ---------- <<<<<

    }
}
