using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Xml.Serialization;
//----- ueno add---------- start 2008.01.31
using Broadleaf.Application.LocalAccess;
//----- ueno add---------- end 2008.01.31

namespace Broadleaf.Application.Controller
{
    /// <summary>
	/// �|���ݒ�Ǘ��}�X�^�A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
	/// <br>Note       : �|���ݒ�Ǘ��}�X�^�̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30167 ���@�O�M</br>
	/// <br>Date       : 2007.09.12</br>
	/// <br>Update Note: 2008.01.31 30167 ���@�O�M</br>
	/// <br>			 ���[�J���c�a�Ή�</br>
	/// <br>Update Note: 2008.02.27 30167 ���@�O�M</br>
	/// <br>			 ���[�J���c�a�Ή��i�񋟃f�[�^�Ǎ������[�J���Œ�ɏC���j</br>
    /// <br>Update Note: 2008/10/20       �Ɠc�@�M�u</br>
    /// <br>			 �o�O�C���A�d�l�ύX�Ή�</br>
    /// </remarks>
	public class RateMngGoodsCust
	{
		// �e�[�u����
		/// <summary>�|���D��}�X�^�i�񋟁j</summary>
		public const string RATEMNGGOODSCUST_TABLE = "RateMngGoodsCustTable";

		/// <summary>�|���D��}�X�^�ۑ��p</summary>
		public const string RATEMNGGOODSCUST_SAVE_TABLE = "RateMngGoodsCustSaveTable";
		
		// �f�[�^�e�[�u�����ږ�
		/// <summary>�쐬���t</summary>
		public const string CREATEDATETIME = "CreateDateTime";
		/// <summary>�X�V���t</summary>
		public const string UPDATEDATETIME = "UpdateDateTime";
		/// <summary>���_�R�[�h</summary>
		public const string SECTIONCODE	= "SectionCode";
		/// <summary>�P�����</summary>
		public const string UNITPRICEKIND = "UnitPriceKind";
		/// <summary>�|���D�揇��</summary>
        public const string RATEPRIORITYORDER = "RatePriorityOrder";
        /// <summary>�|���ݒ�敪</summary>
		public const string RATESETTINGDIVIDE = "RateSettingDivide";
		/// <summary>�|���ݒ�敪�i���i�j</summary>
		public const string RATEMNGGOODSCD = "RateMngGoodsCD";
		/// <summary>�|���ݒ薼�́i���i�j</summary>
		public const string RATEMNGGOODSNM = "RateMngGoodsNM";
		/// <summary>�|���ݒ�敪�i���Ӑ�j</summary>
		public const string RATEMNGCUSTCD = "RateMngCustCD";
		/// <summary>�|���ݒ薼�́i���Ӑ�j</summary>
		public const string RATEMNGCUSTNM = "RateMngCustNM";
		/// <summary>�I���t���O</summary>
		public const string SELECT_FLAG = "SelectFlag";
		/// <summary>�I���i�O���b�h�\���p�j</summary>
		public const string SELECT = "�I��";
		/// <summary>�����|���ݒ�敪�i�O���b�h�\���p�j</summary>
		public const string RATEMNGALLNM = "�|���ݒ�敪";
		/// <summary>�m��O���b�h�L���t���O�i0:����, 1:�L��j</summary>
		public const string DATAEXIST_FLAG = "DataExistFlag";
		/// <summary>��\���t���O�i0:�\��, 1:��\���j</summary>
		public const string HIDDEN_FLAG = "HiddenFlag";
		/// <summary>GUID</summary>
		public const string FILEHEADERGUID = "FileHeaderGuid";
		
		# region Private Member

		//----- ueno del ---------- start 2008.02.27
		///// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		//private	IRateMngGoodsDB _iRateMngGoodsDB = null;
		//private IRateMngCustDB _iRateMngCustDB = null;
		//----- ueno del ---------- end 2008.02.27

		//----- ueno add ---------- start 2008.01.31
		private RateMngGoodsLcDB _rateMngGoodsLcDB = null;
		private RateMngCustLcDB _rateMngCustLcDB = null;

		private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g
		//----- ueno add ---------- end 2008.01.31

		// �|���ݒ�Ǘ��}�X�^�i���i�E���Ӑ�j���i�[�p
		private DataTable _dateTableList = null;
		
		// �|���D��Ǘ��}�X�^�m����i�[�p
		private DataTable _dateTableSaveList = null;
		
		// �|���ݒ�Ǘ��}�X�^���X�g�ҏW�p
		private StringBuilder _stringBuilder = null;

		// UI�O���b�h�pHashTable
		private Hashtable _gridHashTable = null;
				
		# endregion

		/// <summary>
		/// �|���ݒ�Ǘ��}�X�^�A�N�Z�X�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : �|���ݒ�Ǘ��}�X�^�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.09.12</br>
		/// </remarks>
		public RateMngGoodsCust()
		{
			//----- ueno del ---------- start 2008.02.27
			//try
			//{
			//    // �����[�g�I�u�W�F�N�g�擾
			//    this._iRateMngGoodsDB = (IRateMngGoodsDB)MediationRateMngGoodsDB.GetRateMngGoodsDB();
			//    this._iRateMngCustDB = (IRateMngCustDB)MediationRateMngCustDB.GetRateMngCustDB();
			//}
			//catch (Exception)
			//{
			//    // �I�t���C������null���Z�b�g
			//    this._iRateMngGoodsDB = null;
			//    this._iRateMngCustDB = null;
			//}
			//----- ueno del ---------- end 2008.02.27

			//----- ueno add ---------- start 2008.01.31
			// ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
			this._rateMngGoodsLcDB = new RateMngGoodsLcDB();
			this._rateMngCustLcDB = new RateMngCustLcDB();
			//----- ueno add ---------- end 2008.01.31

			// �f�[�^�Z�b�g����\�z����
			this._dateTableList = new DataTable();
			DataTableColumnConstruction(ref this._dateTableList);

			this._dateTableSaveList = new DataTable();
			DataTableColumnConstruction(ref this._dateTableSaveList);
			
			// ������ҏW�p
			_stringBuilder = new StringBuilder();
			
			// HashTable
			_gridHashTable = new Hashtable();
		}

		//----- ueno add ---------- start 2008.01.31
		#region Public Property

		//================================================================================
		//  �v���p�e�B
		//================================================================================
		/// <summary>
		/// ���[�J���c�aRead���[�h
		/// </summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set { _isLocalDBRead = value; }
		}
		#endregion
		//----- ueno add ---------- end 2008.01.31

		/// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
		public enum OnlineMode
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online
		}

		//----- ueno del ---------- start 2008.02.27
		///// <summary>
		///// �I�����C�����[�h�擾����
		///// </summary>
		///// <returns>OnlineMode</returns>
		///// <remarks>
		///// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		///// <br>Programmer : 30167 ��� �O�M</br>
		///// <br>Date       : 2007.09.12</br>
		///// </remarks>
		//public int GetOnlineMode()
		//{
		//    if (this._iRateMngGoodsDB == null)
		//    {
		//        return (int)ConstantManagement.OnlineMode.Offline;
		//    }
		//    else
		//    {
		//        return (int)ConstantManagement.OnlineMode.Online;
		//    }
		//}
		//----- ueno del ---------- end 2008.02.27

        /// <summary>
        /// ���������i�_���폜�܂ށj
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>		
        /// <param name="sectionCode">���_�R�[�h</param>		
        /// <param name="message">���b�Z�[�W</param>		
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.09.12</br>
        /// </remarks>
        public int SearchAll(out DataTable retList, out int retTotalCnt, out bool nextData, string enterpriseCode, string sectionCode, out string message)
        {
            // ����
            int status = 0;
			status = SearchProc(out retList, out retTotalCnt, out nextData, enterpriseCode, sectionCode, ConstantManagement.LogicalMode.GetDataAll, out message);
            return status;
        }

		/// <summary>
		/// �m��O���b�h�p�f�[�^�e�[�u���������擾����
		/// </summary>
		/// <param name="retDataTable">�m��O���b�h�p�f�[�^�e�[�u��</param>		
		/// <remarks>
		/// <br>Note       : �m��O���b�h�p�f�[�^�e�[�u�����������擾���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.09.13</br>
		/// </remarks>
		public void GetListSaveDataTable(out DataTable retDataTable)
		{
			// �f�[�^�Z�b�g��������Ԃ�
			retDataTable = this._dateTableSaveList;
		}

		/// <summary>
		/// UI�O���b�h�p�n�b�V���e�[�u���擾����
		/// </summary>
		/// <param name="retHashTable">UI�O���b�h�p�n�b�V���e�[�u��</param>		
		/// <remarks>
		/// <br>Note       : UI�O���b�h�p�n�b�V���e�[�u�����擾���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.09.21</br>
		/// </remarks>
		public void GetUiGridHashTable(out Hashtable retHashTable)
		{
			// �n�b�V���e�[�u����Ԃ�
			retHashTable = this._gridHashTable;
		}

        // --- DEL 2009/01/14 --------------------------------------------------------------------->>>>>
        ///// <summary>
        ///// �|���ݒ�Ǘ��}�X�^�ǂݍ��ݏ���
        ///// </summary>
        ///// <param name="retList">�Ǎ����ʃR���N�V����</param>
        ///// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
        ///// <param name="nextData">���f�[�^�L��</param>
        ///// <param name="enterpriseCode">��ƃR�[�h</param>
        ///// <param name="sectionCode">���_�R�[�h</param>
        ///// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        ///// <param name="message">�G���[���b�Z�[�W</param>
        ///// <returns>�|���ݒ�Ǘ��}�X�^�N���X</returns>
        ///// <remarks>
        ///// <br>Note       : �|���ݒ�Ǘ��}�X�^����ǂݍ��݂܂��B</br>
        ///// <br>Programmer : 30167 ��� �O�M</br>
        ///// <br>Date       : 2007.09.12</br>
        ///// </remarks>
        //private int SearchProc(out DataTable  retList
        //                     ,out int retTotalCnt
        //                     ,out bool nextData
        //                     ,string enterpriseCode
        //                     ,string sectionCode
        //                     ,ConstantManagement.LogicalMode logicalMode
        //                     ,out string message)
        //{
        //    int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
        //    retList = null;
        //    retTotalCnt = 0;
        //    nextData = false;
        //    message = "";
        //    ArrayList paraList = null;

        //    try
        //    {
        //        //------------------------------
        //        // �R���{�{�b�N�X�f�[�^������
        //        //------------------------------
        //        RateProtyMng._rateSettingDivideGoodsTable = new SortedList();
        //        RateProtyMng._rateSettingDivideCustTable = new SortedList();
				
        //        //==========================================
        //        // �|���ݒ�Ǘ��i���i�j�}�X�^�ǂݍ���
        //        //==========================================
        //        // ���o�����p�����[�^
        //        RateMngGoodsWork rateMngGoodsParaWork = new RateMngGoodsWork();
        //        paraList = new ArrayList();
				
        //        rateMngGoodsParaWork.LogicalDeleteCode = 0;
        //        paraList.Add(rateMngGoodsParaWork);
				
        //        // �����[�g�߂胊�X�g
        //        object rateMngGoodsWorkList = null;

        //        //----- ueno upd ---------- start 2008.02.27
        //        // �񋟃f�[�^�̓��[�J���Œ�
        //        List<RateMngGoodsWork> wkRateMngGoodsWorkList = new List<RateMngGoodsWork>();
        //        status = this._rateMngGoodsLcDB.Search(out wkRateMngGoodsWorkList, rateMngGoodsParaWork, 0, logicalMode);
				
        //        if(status == 0)
        //        {
        //            ArrayList al = new ArrayList();
        //            al.AddRange(wkRateMngGoodsWorkList);
        //            rateMngGoodsWorkList = (object)al;
        //        }
        //        //----- ueno upd ---------- end 2008.02.27
				
        //        if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
        //        {
        //            // �f�[�^�e�[�u���ɃZ�b�g
        //            foreach (RateMngGoodsWork wkRateMngGoodsWork in (ArrayList)rateMngGoodsWorkList)
        //            {
        //                //--------------------------------
        //                // �|���ݒ�Ǘ��i���i�j�f�[�^�ݒ�
        //                //--------------------------------
        //                // �����񌋍�(��:A Ұ���{���i)				
        //                _stringBuilder.Remove(0, _stringBuilder.Length);	//������
        //                _stringBuilder.Append(wkRateMngGoodsWork.RateMngGoodsCd.Trim());
        //                _stringBuilder.Append(" ");
        //                _stringBuilder.Append(wkRateMngGoodsWork.RateMngGoodsNm);

        //                string goodsAllName = _stringBuilder.ToString();		// �R���{�{�b�N�X�\���p

        //                // ���o�^�Ȃ�ݒ肷��
        //                if (RateProtyMng._rateSettingDivideGoodsTable.ContainsKey(wkRateMngGoodsWork.RateMngGoodsCd.Trim()) == false)
        //                {
        //                    RateProtyMng._rateSettingDivideGoodsTable.Add(wkRateMngGoodsWork.RateMngGoodsCd.Trim(), goodsAllName);
        //                }

        //                //==========================================
        //                // �|���ݒ�Ǘ��i���Ӑ�j�}�X�^�ǂݍ���
        //                //==========================================
        //                // ���o�����p�����[�^
        //                RateMngCustWork rateMngCustParaWork = new RateMngCustWork();
        //                paraList = new ArrayList();
        //                paraList.Add(rateMngCustParaWork);
						
        //                // �����[�g�߂胊�X�g
        //                object rateMngCustWorkList = null;

        //                //----- ueno upd ---------- start 2008.02.27
        //                // �񋟃f�[�^�̓��[�J���Œ�
        //                List<RateMngCustWork> wkRateMngCustWorkList = new List<RateMngCustWork>();
        //                status = this._rateMngCustLcDB.Search(out wkRateMngCustWorkList, rateMngCustParaWork, 0, logicalMode);
						
        //                if(status == 0)
        //                {
        //                    ArrayList al = new ArrayList();
        //                    al.AddRange(wkRateMngCustWorkList);
        //                    rateMngCustWorkList = (object)al;
        //                }
        //                //----- ueno upd ---------- end 2008.01.31

        //                // �f�[�^�e�[�u���ɃZ�b�g
        //                foreach (RateMngCustWork wkRateMngCustWork in (ArrayList)rateMngCustWorkList)
        //                {
        //                    // �f�[�^�e�[�u���Z�b�g
        //                    AddRowFromGoodsCustWork(wkRateMngGoodsWork, wkRateMngCustWork);

        //                    //----------------------------------
        //                    // �|���ݒ�Ǘ��i���Ӑ�j�f�[�^�ݒ�
        //                    //----------------------------------
        //                    // �����񌋍�(��:1 ���Ӑ�{�d����)				
        //                    _stringBuilder.Remove(0, _stringBuilder.Length);	//������
        //                    _stringBuilder.Append(wkRateMngCustWork.RateMngCustCd.Trim());
        //                    _stringBuilder.Append(" ");
        //                    _stringBuilder.Append(wkRateMngCustWork.RateMngCustNm);

        //                    string custAllName = _stringBuilder.ToString();		// �R���{�{�b�N�X�\���p

        //                    // ���o�^�Ȃ�ݒ肷��
        //                    if (RateProtyMng._rateSettingDivideCustTable.ContainsKey(wkRateMngCustWork.RateMngCustCd.Trim()) == false)
        //                    {
        //                        RateProtyMng._rateSettingDivideCustTable.Add(wkRateMngCustWork.RateMngCustCd.Trim(), custAllName);
        //                    }
        //                }
        //            }
        //            // �f�[�^�e�[�u����Ԃ�
        //            retList = this._dateTableList;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        message = ex.Message;
        //    }
        //    return status;
        //}
        // --- DEL 2009/01/14 ---------------------------------------------------------------------<<<<<

        // --- ADD 2009/01/14 --------------------------------------------------------------------->>>>>
        /// <summary>
        /// �|���ݒ�Ǘ��}�X�^�ǂݍ��ݏ���
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="sectionCode">���_�R�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="message">�G���[���b�Z�[�W</param>
        /// <returns>�|���ݒ�Ǘ��}�X�^�N���X</returns>
        /// <remarks>
        /// <br>Note       : �|���ݒ�Ǘ��}�X�^����ǂݍ��݂܂��B</br>
        /// <br>Programmer : 30414 �E �K�j</br>
        /// <br>Date       : 2009/01/14</br>
        /// </remarks>
        private int SearchProc(out DataTable retList
                             , out int retTotalCnt
                             , out bool nextData
                             , string enterpriseCode
                             , string sectionCode
                             , ConstantManagement.LogicalMode logicalMode
                             , out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            retList = null;
            retTotalCnt = 0;
            nextData = false;
            message = "";
            ArrayList paraList = null;

            try
            {
                //------------------------------
                // �R���{�{�b�N�X�f�[�^������
                //------------------------------
                RateProtyMng._rateSettingDivideGoodsTable = new SortedList();
                RateProtyMng._rateSettingDivideCustTable = new SortedList();

                //==========================================
                // �|���ݒ�Ǘ��i���i�j�}�X�^�ǂݍ���
                //==========================================
                // ���o�����p�����[�^
                RateMngGoodsWork rateMngGoodsParaWork = new RateMngGoodsWork();
                paraList = new ArrayList();

                rateMngGoodsParaWork.LogicalDeleteCode = 0;
                paraList.Add(rateMngGoodsParaWork);

                // �񋟃f�[�^�̓��[�J���Œ�
                List<RateMngGoodsWork> wkRateMngGoodsWorkList;
                status = this._rateMngGoodsLcDB.Search(out wkRateMngGoodsWorkList, rateMngGoodsParaWork, 0, logicalMode);
                if (status == 0)
                {
                    //ArrayList al = new ArrayList();
                    //al.AddRange(wkRateMngGoodsWorkList);
                    //rateMngGoodsWorkList = (object)al;
                }

                //==========================================
                // �|���ݒ�Ǘ��i���Ӑ�j�}�X�^�ǂݍ���
                //==========================================
                // ���o�����p�����[�^
                RateMngCustWork rateMngCustParaWork = new RateMngCustWork();
                paraList = new ArrayList();
                paraList.Add(rateMngCustParaWork);

                // �񋟃f�[�^�̓��[�J���Œ�
                List<RateMngCustWork> wkRateMngCustWorkList;
                status = this._rateMngCustLcDB.Search(out wkRateMngCustWorkList, rateMngCustParaWork, 0, logicalMode);
                if (status == 0)
                {
                    //ArrayList al = new ArrayList();
                    //al.AddRange(wkRateMngCustWorkList);
                    //rateMngCustWorkList = (object)al;
                }

                foreach (RateMngGoodsWork rateMngGoodsWork in wkRateMngGoodsWorkList)
                {
                    //--------------------------------
                    // �|���ݒ�Ǘ��i���i�j�f�[�^�ݒ�
                    //--------------------------------
                    // �����񌋍�(��:A Ұ���{���i)				
                    _stringBuilder.Remove(0, _stringBuilder.Length);	// ������
                    _stringBuilder.Append(rateMngGoodsWork.RateMngGoodsCd.Trim());
                    _stringBuilder.Append(" ");
                    _stringBuilder.Append(rateMngGoodsWork.RateMngGoodsNm);

                    // �R���{�{�b�N�X�\���p
                    string goodsAllName = _stringBuilder.ToString();		

                    // ���o�^�Ȃ�ݒ肷��
                    if (RateProtyMng._rateSettingDivideGoodsTable.ContainsKey(rateMngGoodsWork.RateMngGoodsCd.Trim()) == false)
                    {
                        RateProtyMng._rateSettingDivideGoodsTable.Add(rateMngGoodsWork.RateMngGoodsCd.Trim(), goodsAllName);
                    }
                }

                foreach (RateMngCustWork rateMngCustWork in wkRateMngCustWorkList)
                {
                    //----------------------------------
                    // �|���ݒ�Ǘ��i���Ӑ�j�f�[�^�ݒ�
                    //----------------------------------
                    // �����񌋍�(��:1 ���Ӑ�{�d����)				
                    _stringBuilder.Remove(0, _stringBuilder.Length);	// ������
                    _stringBuilder.Append(rateMngCustWork.RateMngCustCd.Trim());
                    _stringBuilder.Append(" ");
                    _stringBuilder.Append(rateMngCustWork.RateMngCustNm);

                    // �R���{�{�b�N�X�\���p
                    string custAllName = _stringBuilder.ToString();		

                    // ���o�^�Ȃ�ݒ肷��
                    if (RateProtyMng._rateSettingDivideCustTable.ContainsKey(rateMngCustWork.RateMngCustCd.Trim()) == false)
                    {
                        RateProtyMng._rateSettingDivideCustTable.Add(rateMngCustWork.RateMngCustCd.Trim(), custAllName);
                    }
                }

                foreach (RateMngGoodsWork rateMngGoodsWork in wkRateMngGoodsWorkList)
                {
                    if (rateMngGoodsWork.RateMngGoodsCd.Trim() == "A")
                    {
                        foreach (RateMngCustWork rateMngCustWork in wkRateMngCustWorkList)
                        {
                            // �f�[�^�e�[�u���Z�b�g
                            AddRowFromGoodsCustWork(rateMngGoodsWork, rateMngCustWork);
                        }
                    }
                }

                foreach (RateMngCustWork rateMngCustWork in wkRateMngCustWorkList)
                {
                    foreach (RateMngGoodsWork rateMngGoodsWork in wkRateMngGoodsWorkList)
                    {
                        if (rateMngGoodsWork.RateMngGoodsCd.Trim() != "A")
                        {
                            // �f�[�^�e�[�u���Z�b�g
                            AddRowFromGoodsCustWork(rateMngGoodsWork, rateMngCustWork);
                        }
                    }
                }

                // �f�[�^�e�[�u����Ԃ�
                retList = this._dateTableList;
            }
            catch (Exception ex)
            {
                message = ex.Message;
            }
            return status;
        }
        // --- ADD 2009/01/14 ---------------------------------------------------------------------<<<<<

		/// <summary>
		/// �|���ݒ�Ǘ��i���i�E���Ӑ�j�}�X�^�@���@�f�[�^�e�[�u���ǉ�����
		/// </summary>
		/// <param name="rateMngGoodsWork">�Ǎ����ʃR���N�V�����i���i�j</param>
		/// <param name="rateMngCustWork">�Ǎ����ʃR���N�V�����i���Ӑ�j</param>
		/// <remarks>
		/// <br>Note       : �|���ݒ�Ǘ��i���i�E���Ӑ�j�}�X�^�̃f�[�^���}�[�W���ăf�[�^�e�[�u���ɒǉ����܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.09.17</br>
		/// </remarks>
		private void AddRowFromGoodsCustWork(RateMngGoodsWork rateMngGoodsWork, RateMngCustWork rateMngCustWork)
		{
			DataRow dr;
			string listSearchStr = "";
			try
			{
                //// --- ADD 2008/10/20 --------------------------------------------------------------------------->>>>>
                // �|���ݒ�敪��"6L:�w��Ȃ� �w��Ȃ�"��\�����Ȃ�
                if ((rateMngGoodsWork.RateMngGoodsCd.Trim() == "L") && (rateMngCustWork.RateMngCustCd.Trim() == "6"))
                {
                    return;
                }
                //// --- ADD 2008/10/20 ---------------------------------------------------------------------------<<<<<

				dr = this._dateTableList.NewRow();

				dr[CREATEDATETIME] = rateMngGoodsWork.CreateDateTime;	// ���i�����Ƃ肠�����ݒ肵�Ă���
				dr[UPDATEDATETIME] = rateMngGoodsWork.UpdateDateTime;	// ���i�����Ƃ肠�����ݒ肵�Ă���

				dr[SECTIONCODE] = "";		// �������ݎ��g�p
				dr[UNITPRICEKIND] = 0;		// �������ݎ��g�p

                string rateSetting = rateMngCustWork.RateMngCustCd.Trim() + rateMngGoodsWork.RateMngGoodsCd.Trim();
                if (RateProtyMng._ratePriorityOrderDic.ContainsKey(rateSetting))
                {
                    dr[RATEPRIORITYORDER] = RateProtyMng._ratePriorityOrderDic[rateSetting];	// �������ݎ��g�p
                }
                else
                {
                    dr[RATEPRIORITYORDER] = 0;	// �������ݎ��g�p
                }
				dr[RATEMNGGOODSCD] = rateMngGoodsWork.RateMngGoodsCd.Trim();
				dr[RATEMNGCUSTCD]  = rateMngCustWork.RateMngCustCd.Trim();
				dr[RATEMNGGOODSNM] = rateMngGoodsWork.RateMngGoodsNm;
				dr[RATEMNGCUSTNM]  = rateMngCustWork.RateMngCustNm;

                // �����񌋍�(��:A1 Ұ���{���i ���Ӑ�{�d����)
                // �����񌋍�(��:1B ���Ӑ�{�d���� Ұ���{�w��+BL����)
				_stringBuilder.Remove(0, _stringBuilder.Length);	//������
                _stringBuilder.Append(rateMngCustWork.RateMngCustCd.Trim());
                _stringBuilder.Append(rateMngGoodsWork.RateMngGoodsCd.Trim());
                listSearchStr = _stringBuilder.ToString();
                _stringBuilder.Append(" ");
                _stringBuilder.Append(rateMngCustWork.RateMngCustNm);
                _stringBuilder.Append("+");
                _stringBuilder.Append(rateMngGoodsWork.RateMngGoodsNm);

				dr[RATEMNGALLNM] = _stringBuilder.ToString();	// �O���b�h�\���p
				dr[RATESETTINGDIVIDE] = listSearchStr;			// �|���ݒ�敪(��:A1)
				dr[DATAEXIST_FLAG] = 0;							// �m��O���b�h�L���t���O
				dr[HIDDEN_FLAG] = 0;							// �\���t���O
				
				dr[SELECT_FLAG] = false;						// �I���t���O�ifalse:���I�����, true:�I����ԁj
				dr[SELECT] = "";								// �I���i"":���I�����, �I��:�I����ԁj

				dr[FILEHEADERGUID] = Guid.NewGuid();			// �V�KGUID�쐬

				this._dateTableList.Rows.Add(dr);

				// �n�b�V���e�[�u���X�V
				if (this._gridHashTable.ContainsKey(dr[FILEHEADERGUID]) == true)
				{
					this._gridHashTable.Remove(dr[FILEHEADERGUID]);
				}
				this._gridHashTable.Add(dr[FILEHEADERGUID], dr);
			}
			catch
			{
			}
		}
		
		/// <summary>
		/// �f�[�^�e�[�u������\�z����
		/// </summary>
		/// <remarks>
		/// <param name="wkTable">�f�[�^�e�[�u��</param>
		/// <br>Note       : �f�[�^�e�[�u���̗�����\�z���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.09.13</br>
		/// </remarks>
		private void DataTableColumnConstruction(ref DataTable wkTable)
		{
			// �쐬���t�i�������ݎ��g�p�j
			wkTable.Columns.Add(CREATEDATETIME, typeof(DateTime));

			// �X�V���t�i�������ݎ��g�p�j
			wkTable.Columns.Add(UPDATEDATETIME, typeof(DateTime));
			
			// ���_�R�[�h�i�������ݎ��g�p�j
			wkTable.Columns.Add(SECTIONCODE, typeof(string));
			
			// �P����ށi�������ݎ��g�p�j
			wkTable.Columns.Add(UNITPRICEKIND, typeof(Int32));

            // --- DEL 2009/01/13 --------------------------------------------------------------------->>>>>
            //// �|���D�揇��
            //wkTable.Columns.Add(RATEPRIORITYORDER, typeof(Int32));
            // --- DEL 2009/01/13 ---------------------------------------------------------------------<<<<<

			// �|���ݒ�敪
			wkTable.Columns.Add(RATESETTINGDIVIDE, typeof(string));
			
			// �|���ݒ�敪�i���i�j
			wkTable.Columns.Add(RATEMNGGOODSCD, typeof(string));

			// �|���ݒ�敪�i���Ӑ�j
			wkTable.Columns.Add(RATEMNGCUSTCD, typeof(string));
			
			// �|���ݒ薼�́i���i�j
			wkTable.Columns.Add(RATEMNGGOODSNM, typeof(string));

			// �|���ݒ薼�́i���Ӑ�j
			wkTable.Columns.Add(RATEMNGCUSTNM, typeof(string));
			
			// �I���t���O
			wkTable.Columns.Add(SELECT_FLAG, typeof(bool));
			
			// �I���i�O���b�h�\���p�j
			wkTable.Columns.Add(SELECT, typeof(string));

            // --- ADD 2009/01/13 --------------------------------------------------------------------->>>>>
            // �|���D�揇��
            wkTable.Columns.Add(RATEPRIORITYORDER, typeof(Int32));
            // --- ADD 2009/01/13 ---------------------------------------------------------------------<<<<<
			
			// �|���ݒ胊�X�g�\���p������
			wkTable.Columns.Add(RATEMNGALLNM, typeof(string));

			// �m��O���b�h�L���t���O
			wkTable.Columns.Add(DATAEXIST_FLAG, typeof(int));
			
			// �\���t���O
			wkTable.Columns.Add(HIDDEN_FLAG, typeof(int));
			
			// GUID
			wkTable.Columns.Add(FILEHEADERGUID, typeof(Guid));
		}
	}
}
