using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Text;
using Broadleaf.Windows.Forms;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i��֐ݒ�}�X�^�i���[�U�[�o�^�j�e�[�u���A�N�Z�X�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note        : ���i��֐ݒ�}�X�^�i���[�U�[�o�^�j�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer  : 30413 ����</br>
    /// <br>Date        : 2008.07.25</br>
    /// <br>UpdateNote  : 2008/11/28 30462 �s�V�m���@�o�O�C��</br>
    /// </remarks>
    public class PartsSubstUAcs : IGeneralGuideData
    {
        // --------------------------------------------------
		#region Private Members

		// �X�^�e�B�b�N�T�[�`�p
		private static Hashtable _goodschange_Stc = null;

		// ���i��֐ݒ�}�X�^�i���[�U�[�o�^�j�����[�g�I�u�W�F�N�g�i�[�o�b�t�@
		private IPartsSubstUDB _iPartsSubstUDB = null;
		
		// ���[�J�[�A�N�Z�X�N���X
		private MakerAcs _makerAcs = null;
		
		// ���[�J�[�f�[�^�i�[�p
		private static Hashtable _makerList_Stc = null;
		
		private static bool _isLocalDBRead = false;	// �f�t�H���g�̓����[�g

		// �K�C�h�p
        private const string GUIDE_XML_FILENAME = "PARTSSUBSTUGUIDEPARENT.XML";	    // XML�t�@�C����
		private const string GUIDE_ENTERPRISECODE_TITLE = "EnterpriseCode";			// ��ƃR�[�h
		private const string GUIDE_CHGSRCMAKERCD_TITLE = "ChgSrcMakerCd";			// �ϊ������[�J�[
		private const string GUIDE_CHGSRCGOODSNO_TITLE = "ChgSrcGoodsNo";			// �ϊ������i�ԍ�
		private const string GUIDE_CHGDESTMAKERCD_TITLE = "ChgDestMakerCd";			// �ϊ��惁�[�J�[
		private const string GUIDE_CHGDESTGOODSNO_TITLE = "ChgDestGoodsNo";			// �ϊ��揤�i�ԍ�

        // ADD 2008/11/28 �s��Ή�[8317] ---------->>>>>
        /// <summary>���O�C�����[�U�[</summary>
        private readonly Employee _loginWorker;           

        /// <summary>�����_�R�[�h</summary>
        private readonly string _ownSectionCode;
        // ADD 2008/11/28 �s��Ή�[8317] ----------<<<<<
        #endregion 

		#region enum
		/// <summary>
		/// �敪
		/// </summary>
		public enum Division:int
		{
			// ���[�U�[�f�[�^
			User = 0,
			// �񋟃f�[�^
			Offer = 1
		}
		#endregion

		#region Constructor

		/// <summary>
        /// ���i��֐ݒ�}�X�^�i���[�U�[�o�^�j�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
        /// <br>Note        : ���i��֐ݒ�}�X�^�i���[�U�[�o�^�j�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public PartsSubstUAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
                this._iPartsSubstUDB = (IPartsSubstUDB)MediationPartsSubstUDB.GetPartsSubstUDB();
				
				// ���[�J�[�A�N�Z�X�N���X
				this._makerAcs = new MakerAcs();
				
				// ���[�J���t���O�ݒ�
				this._makerAcs.IsLocalDBRead = this.IsLocalDBRead;

                // ADD 2008/11/28 �s��Ή�[8317] ---------->>>>>
                if (LoginInfoAcquisition.Employee != null)
                {
                    this._loginWorker = LoginInfoAcquisition.Employee.Clone();
                    this._ownSectionCode = this._loginWorker.BelongSectionCode;
                }
                // ADD 2008/11/28 �s��Ή�[8317] ----------<<<<<

			}
			catch( Exception )
			{
				// �I�t���C������null���Z�b�g
                this._iPartsSubstUDB = null;
			}
		}
		#endregion

        // --------------------------------------------------
        #region Properties
		/// <summary>
		/// ���[�J���c�aRead���[�h
		/// </summary>
		public bool IsLocalDBRead
		{
			get { return _isLocalDBRead; }
			set { _isLocalDBRead = value; }
		}
        #endregion

		// --------------------------------------------------
		#region GetOnlineMode
		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note        : �I�����C�����[�h�̎擾���s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int GetOnlineMode()
		{
			// �I�����C�����[�h���擾
			if( this._iPartsSubstUDB == null )
			{
				// �I�t���C��
				return ( int )ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				// �I�����C��
				return ( int )ConstantManagement.OnlineMode.Online;
			}
		}
		#endregion

		#region ���[�J�[���̎擾
		/// <summary>
		/// ���[�J�[���̎擾
		/// </summary>
		/// <remarks>
		/// <param name="goodsMakerCd">���[�J�[�R�[�h</param>
		/// <returns>���[�J�[����</returns>
		/// <br>Note        : ���[�J�[���̂��擾���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public string GetMakerName(int goodsMakerCd)
		{
			string retStr = "";

			if ((_makerList_Stc != null)&&(_makerList_Stc.ContainsKey(goodsMakerCd) == true))
			{
				retStr = _makerList_Stc[goodsMakerCd].ToString();
			}
			return retStr;
		}
		#endregion

		// --------------------------------------------------
		#region Search Methods
		/// <summary>
		///��������(�_���폜����)
		/// </summary>
		/// <param name="retList">�Q�ƌ��ʃ��X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note        : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�͌����ΏۊO�ł��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int Search(out ArrayList retList, string enterpriseCode)
		{
			// ���i��֌���
			return SearchCommon(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
		}

		/// <summary>
		///��������(�_���폜�܂�)
		/// </summary>
		/// <param name="retList">�Q�ƌ��ʃ��X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note        : �}�X�^���̌����������s���܂��B�_���폜�f�[�^�������ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int SearchAll(out ArrayList retList, string enterpriseCode)
		{
            // ���i��֌���
			return SearchCommon(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// �}�X�^���������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="belongSectionCode">���_�R�[�h</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note        : �擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int Search(ref DataSet ds, string enterpriseCode)
		{
			ArrayList retList = new ArrayList();

			int status = 0;

			// �}�X�^�T�[�`
			status = SearchAll(out retList, enterpriseCode);
			if (status != 0)
			{
				return status;
			}

			ArrayList wkList = retList.Clone() as ArrayList;
			SortedList wkSort = new SortedList();
			string hKey = "";
			
			// --- [�S��] --- //
			// ���̂܂ܑS���Ԃ�
			foreach (PartsSubstU wkPartsSubstU in wkList)
			{
				if (wkPartsSubstU.LogicalDeleteCode == 0)
				{
					hKey = CreateHashKey(wkPartsSubstU);
					wkSort.Add(hKey, wkPartsSubstU);
				}
			}

            PartsSubstU[] partsSubstU = new PartsSubstU[wkSort.Count];

			// �f�[�^�����ɖ߂�
			for (int i = 0; i < wkSort.Count; i++)
			{
                partsSubstU[i] = (PartsSubstU)wkSort.GetByIndex(i);
			}

			byte[] retbyte = XmlByteSerializer.Serialize(partsSubstU);
			XmlByteSerializer.ReadXml(ref ds, retbyte);

			return status;
		}

		/// <summary>
		///��������
		/// </summary>
		/// <param name="retList">�Q�ƌ��ʃ��X�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�敪</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note        : �}�X�^���̌����������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		private int SearchCommon(out ArrayList retList, string enterpriseCode, ConstantManagement.LogicalMode logicalMode)
		{
			int status = 0;
			bool nextData;
			int retTotalCnt;
			ArrayList list = new ArrayList();
			retList = new ArrayList();
			retList.Clear();
			retTotalCnt = 0;

			_goodschange_Stc = new Hashtable();

			// ���[�J�[�}�X�^�ǂݍ���
			ReadMaker(enterpriseCode);
			
			// ���[�U�[
			status = SearchUsrProc(ref list, out retTotalCnt, out nextData, enterpriseCode, logicalMode, 0, null);

			retList = list;
            return status;
		}

		/// <summary>
        /// ���i��֐ݒ�}�X�^�������������[�U�[��
        /// </summary>
        /// <param name="retList">�Ǎ����ʃR���N�V����</param>
        /// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevMaker��null�̏ꍇ�̂ݖ߂�)</param>
        /// <param name="nextData">���f�[�^�L��</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
        /// <param name="readCnt">�Ǎ�����</param>
        /// <param name="prevPartsSubst">�O��ŏI���i��֐ݒ�I�u�W�F�N�g�i�����null�w��K�{�j</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note        : ���i��֐ݒ�}�X�^�̌����������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		private int SearchUsrProc(ref ArrayList retList, out int retTotalCnt, out bool nextData, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, int readCnt, PartsSubstU prevPartsSubst)
		{
			//����������
			int status = 0;
			retTotalCnt = 0;
			nextData = false;
			string hKey;

			//�������o�N���X(D)�̐ݒ�
            PartsSubstUWork partsSubstUWork = new PartsSubstUWork();
			if (prevPartsSubst != null) partsSubstUWork = CopyToPartsSubstUWorkFromPartsSubstU(prevPartsSubst);
            partsSubstUWork.EnterpriseCode = enterpriseCode;

            ArrayList paraList = new ArrayList();
            paraList.Clear();
            object paraobj = partsSubstUWork;
            //object retobj = null;
            object retobj = paraList;
		
			// ���[�J��
			if (_isLocalDBRead)
			{
                // �V�K�ł̓��[�J�������������Ȃ̂Ŗ�����
			}
			// �����[�g
			else
			{
                // ���i��֌���
				status = this._iPartsSubstUDB.Search(ref retobj, paraobj, 0, logicalMode);
			}

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					paraList = retobj as ArrayList;

					if (paraList != null)
					{
						foreach (PartsSubstUWork wkPartsSubstUWork in paraList)
						{
							hKey = CreateHashKey(wkPartsSubstUWork);
							if (_goodschange_Stc[hKey] != null)
							{
								continue;
							}

							PartsSubstU partsSubstU = CopyToPartsSubstUFromPartsSubstUWork(wkPartsSubstUWork);
							retList.Add(partsSubstU);
							// static�ێ�
							_goodschange_Stc[hKey] = partsSubstU;
						}
					}
					break;
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
					break;
				default:
					return status;
			}

			//�S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if (readCnt == 0) retTotalCnt = retList.Count;
			return status;
		}

        #endregion

        // --------------------------------------------------
		#region Read Methods
		/// <summary>
        /// �ǂݍ��ݏ���
		/// </summary>
        /// <param name="partsSubstU">���i��֐ݒ�i���[�U�[�o�^�j�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="chgSrcMakerCd">�ϊ����R�[�h</param>
        /// <param name="chgSrcGoodsNo">�ϊ������i�ԍ�</param>
        /// <param name="chgDestMakerCd">�ϊ���R�[�h</param>
        /// <param name="chgDestGoodsNo">�ϊ��揤�i�ԍ�</param>
        /// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : �}�X�^���̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int Read(out PartsSubstU partsSubstU, string enterpriseCode, Int32 chgSrcMakerCd, string chgSrcGoodsNo, Int32 chgDestMakerCd, string chgDestGoodsNo)
		{
			int status = 0;

			partsSubstU = new PartsSubstU();
			
			// ���[�U�[
			status = this.ReadUProc(out partsSubstU, enterpriseCode, chgSrcMakerCd, chgSrcGoodsNo, chgDestMakerCd, chgDestGoodsNo);
			
            return status;
		}

		/// <summary>
        /// ���i��֐ݒ�}�X�^�ǂݍ��ݏ��������[�U�[��
		/// </summary>
        /// <param name="partsSubstU">���i��֐ݒ�i���[�U�[�o�^�j�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="chgSrcMakerCd">�ϊ����R�[�h</param>
        /// <param name="chgSrcGoodsNo">�ϊ������i�ԍ�</param>
        /// <param name="chgDestMakerCd">�ϊ���R�[�h</param>
        /// <param name="chgDestGoodsNo">�ϊ��揤�i�ԍ�</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : ���i��֐ݒ�i���[�U�[�o�^�j�̓ǂݍ��ݏ������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private int ReadUProc(out PartsSubstU partsSubstU, string enterpriseCode, Int32 chgSrcMakerCd, string chgSrcGoodsNo, Int32 chgDestMakerCd, string chgDestGoodsNo)
		{
            int status = 0;
            partsSubstU = null;

            try
            {
                // �L�[�����Z�b�g
                PartsSubstUWork partsSubstUWork = new PartsSubstUWork();
                partsSubstUWork.EnterpriseCode = enterpriseCode;   // ��ƃR�[�h
                partsSubstUWork.ChgSrcMakerCd = chgSrcMakerCd;     // �ϊ������[�J�[
                partsSubstUWork.ChgSrcGoodsNo = chgSrcGoodsNo;     // �ϊ������i�ԍ�
                partsSubstUWork.ChgDestMakerCd = chgDestMakerCd;   // �ϊ��惁�[�J�[
                partsSubstUWork.ChgDestGoodsNo = chgDestGoodsNo;   // �ϊ��揤�i�ԍ�

                object paraObj = new object();
                paraObj = partsSubstUWork;

				// ���[�J��
            	if (_isLocalDBRead)
				{
                    // �V�K�ł̓��[�J�������������Ȃ̂Ŗ�����
				}
            	// �����[�g
				else
				{
                    // ���i��֐ݒ�i���[�U�[�o�^�j�ǂݍ���
                    status = this._iPartsSubstUDB.Read(ref paraObj, 0);
				}

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					// ���ʂ������o�R�s�[
                    partsSubstU = this.CopyToPartsSubstUFromPartsSubstUWork((PartsSubstUWork)paraObj);
				}
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                partsSubstU = null;
                this._iPartsSubstUDB = null;

                // �ʐM�G���[��-1��Ԃ�
				status = -1;
            }
			return status;
		}
        
        #endregion

        // --------------------------------------------------
		#region ReadMaker
		/// <summary>
		/// ���[�J�[�f�[�^�ǂݍ��ݏ���
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note        : ���[�J�[�}�X�^����S���擾���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		private int ReadMaker(string enterpriseCode)
		{
			_makerList_Stc = new Hashtable();
			
			ArrayList makerList;
			int status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
			
			status = this._makerAcs.SearchAll(out makerList, enterpriseCode);

			if ((status == 0) && (makerList.Count > 0))
			{
				foreach (MakerUMnt makerUMnt in (ArrayList)makerList)
				{
					//---------------------------------
					// Key  �F���[�J�[�R�[�h
					// Value�F���[�J�[����
					//---------------------------------
					_makerList_Stc.Add(makerUMnt.GoodsMakerCd, makerUMnt.MakerName);
				}
			}
			return status;
		}
		#endregion ReadMaker

		// --------------------------------------------------
		#region Write Methods
		/// <summary>
        /// ���i��֐ݒ�}�X�^�o�^�E�X�V����
		/// </summary>
        /// <param name="partsSubstU">���i��֐ݒ�i���[�U�[�o�^�j�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : ���i��֐ݒ�i���[�U�[�o�^�j�̏������ݏ������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int Write(ref PartsSubstU partsSubstU)
		{
			int status = 0;

			try
			{
                GoodsAcs goodsAcs = new GoodsAcs();
                object paraObj = new object();
                CustomSerializeArrayList csList = new CustomSerializeArrayList();
                string msg = "";

                // ADD 2008/11/28 �s��Ή�[8317] ---------->>>>>
                #region < �o�^�f�[�^�������� >
                GoodsUnitData goodsUnitData = new GoodsUnitData();

                ArrayList gunitList = new ArrayList();

                GoodsCndtn goodsCndtn = new GoodsCndtn();

                string searchCode;
                int searchType = GetSearchType(partsSubstU.ChgDestGoodsNo, out searchCode);

                // ���i���������ݒ�
                goodsCndtn.EnterpriseCode = partsSubstU.EnterpriseCode;
                goodsCndtn.SectionCode = this._ownSectionCode;
                goodsCndtn.GoodsMakerCd = partsSubstU.ChgDestMakerCd;
                goodsCndtn.MakerName = "";
                goodsCndtn.GoodsNo = partsSubstU.ChgDestGoodsNo;
                goodsCndtn.GoodsNoSrchTyp = searchType;

                string message;
                List<GoodsUnitData> list = new List<GoodsUnitData>();

                status = goodsAcs.SearchPartsFromGoodsNoNonVariousSearch(goodsCndtn, false, out list, out message);
                
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �Y���̏��i�A���f�[�^�擾
                    goodsUnitData = (GoodsUnitData)list[0];

                    // ���i�}�X�^�o�^�ΏہH
                    if ((goodsUnitData.OfferKubun == 3) || (goodsUnitData.OfferKubun == 4))
                    {
                        // ���i�A���f�[�^���X�g�֒ǉ�
                        gunitList.Add(goodsUnitData);
                    }
                }
                #endregion

                // ���i�A���f�[�^
                csList.Add(gunitList);
                // ADD 2008/11/28 �s��Ή�[8317] ----------<<<<<

                // ���i��֐ݒ�I�u�W�F�N�g�̒ǉ�
                csList.Add(partsSubstU);
                paraObj = csList;

                // ���i�}�X�^�N���X���o�R���ĕ��i��֐ݒ�̏�������
                status = goodsAcs.WriteRelation(ref paraObj, out msg);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    PartsSubstU wkPartsSubstU = (PartsSubstU)((CustomSerializeArrayList)paraObj)[0];
                    partsSubstU = wkPartsSubstU.Clone();
                }

                //PartsSubstUWork partsSubstUWork = CopyToPartsSubstUWorkFromPartsSubstU(partsSubstU);

                //ArrayList paraList = new ArrayList();
                //paraList.Add(partsSubstUWork);
                //object paraobj = paraList;

                //// ���i��֐ݒ�i���[�U�[�o�^�j��������
                //status = this._iPartsSubstUDB.Write(ref paraobj);

                //if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL )
                //{
                //    paraList = (ArrayList)paraobj;

                //    partsSubstU = CopyToPartsSubstUFromPartsSubstUWork((PartsSubstUWork)paraList[0]);
                //}
			}
			catch( Exception )
			{
				// �I�t���C������null���Z�b�g
				this._iPartsSubstUDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}
			return status;
		}
		#endregion

		// --------------------------------------------------
		#region LogicalDelete Methods
		/// <summary>
        /// ���i��֐ݒ�}�X�^�_���폜����
        /// </summary>
        /// <param name="partsSubstU">���i��֐ݒ�i���[�U�[�o�^�j�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : ���i��֐ݒ�i���[�U�[�o�^�j�̘_���폜�������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int LogicalDelete(ref PartsSubstU partsSubstU)
		{
			int status = 0;

			try
			{
                PartsSubstUWork partsSubstUWork = CopyToPartsSubstUWorkFromPartsSubstU(partsSubstU);
				
				ArrayList paraList = new ArrayList();
				paraList.Add(partsSubstUWork);
				object paraObj = paraList;

                // ���i��֐ݒ�i���[�U�[�o�^�j�_���폜
				status = this._iPartsSubstUDB.LogicalDelete(ref paraObj);

				if( status == ( int )ConstantManagement.DB_Status.ctDB_NORMAL )
				{
					paraList = (ArrayList)paraObj;
					// �N���X�������o�R�s�[
                    partsSubstU = CopyToPartsSubstUFromPartsSubstUWork((PartsSubstUWork)paraList[0]);
				}
			}
			catch( Exception )
			{
				// �I�t���C������null���Z�b�g
				this._iPartsSubstUDB = null;

				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}
			return status;
        }
		#endregion

		// --------------------------------------------------
		#region Delete Methods

		/// <summary>
        /// ���i��֐ݒ�}�X�^�����폜����
		/// </summary>
        /// <param name="partsSubstU">���i��֐ݒ�i���[�U�[�o�^�j�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : ���i��֐ݒ�i���[�U�[�o�^�j�̕����폜�������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int Delete(PartsSubstU partsSubstU)
		{
			int status = 0;

			try
			{
                PartsSubstUWork partsSubstUWork = CopyToPartsSubstUWorkFromPartsSubstU(partsSubstU);
				
                ArrayList paraList = new ArrayList();
                paraList.Add(partsSubstUWork);
                object paraObj = paraList;

                // ���i��֐ݒ�i���[�U�[�o�^�j�����폜
                status = this._iPartsSubstUDB.Delete(paraObj);
				
				return status;
			}
			catch (Exception)
			{
				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}
			return status;
		}
		#endregion

		// --------------------------------------------------
		#region Revival Methods
		/// <summary>
        /// ���i��֐ݒ�}�X�^�_���폜��������
        /// </summary>
        /// <param name="partsSubstU">���i��֐ݒ�i���[�U�[�o�^�j�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
        /// <br>Note        : ���i��֐ݒ�i���[�U�[�o�^�j�̘_���폜�����������s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		public int Revival(ref PartsSubstU partsSubstU)
		{
			int status = 0;

			try
			{
                PartsSubstUWork partsSubstUWork = CopyToPartsSubstUWorkFromPartsSubstU(partsSubstU);
				ArrayList paraList = new ArrayList();
				paraList.Add(partsSubstUWork);
				object paraobj = paraList;

                // ���i��֐ݒ�i���[�U�[�o�^�j�_���폜����
				status = this._iPartsSubstUDB.RevivalLogicalDelete(ref paraobj);

				if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
				{
					paraList = (ArrayList)paraobj;
					// �N���X�������o�R�s�[
                    partsSubstU = CopyToPartsSubstUFromPartsSubstUWork((PartsSubstUWork)paraList[0]);
				}
				return status;
			}
			catch( Exception )
			{
				// �ʐM�G���[��-1��Ԃ�
				status = -1;
			}
			return status;
		}
		#endregion

		// --------------------------------------------------
		#region MemberCopy Methods
        /// <summary>
        /// �N���X�����o�R�s�[�����i���[�U�[���i��֐ݒ胏�[�N�N���X�˕��i��֐ݒ�N���X)
		/// </summary>
        /// <param name="partsSubstUWork">���[�U�[���i��֐ݒ胏�[�N�N���X</param>
        /// <returns>���[�U�[���i��֐ݒ�N���X</returns>
		/// <remarks>
        /// <br>Note        : ���[�U�[���i��֐ݒ胏�[�N�N���X����
        ///                   ���[�U�[���i��֐ݒ�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		private PartsSubstU CopyToPartsSubstUFromPartsSubstUWork(PartsSubstUWork partsSubstUWork)
		{
            PartsSubstU partsSubstU = new PartsSubstU();

			partsSubstU.CreateDateTime			= partsSubstUWork.CreateDateTime;      // �쐬����
			partsSubstU.UpdateDateTime			= partsSubstUWork.UpdateDateTime;      // �X�V����
			partsSubstU.EnterpriseCode			= partsSubstUWork.EnterpriseCode;      // ��ƃR�[�h
			partsSubstU.FileHeaderGuid			= partsSubstUWork.FileHeaderGuid;      // GUID
			partsSubstU.UpdEmployeeCode		= partsSubstUWork.UpdEmployeeCode;     // �X�V�]�ƈ��R�[�h
			partsSubstU.UpdAssemblyId1			= partsSubstUWork.UpdAssemblyId1;      // �X�V�A�Z���u��ID1
			partsSubstU.UpdAssemblyId2			= partsSubstUWork.UpdAssemblyId2;      // �X�V�A�Z���u��ID2
			partsSubstU.LogicalDeleteCode		= partsSubstUWork.LogicalDeleteCode;   // �_���폜�敪
			partsSubstU.ChgSrcMakerCd			= partsSubstUWork.ChgSrcMakerCd;       // �ϊ������[�J�[
			partsSubstU.ChgSrcGoodsNo			= partsSubstUWork.ChgSrcGoodsNo;       // �ϊ������i�ԍ�
			partsSubstU.ChgSrcGoodsNoNoneHp	= partsSubstUWork.ChgSrcGoodsNoNoneHp; // �ϊ������i�ԍ�(�n�C�t����)
			partsSubstU.ChgDestMakerCd			= partsSubstUWork.ChgDestMakerCd;      // �ϊ��惁�[�J�[
			partsSubstU.ChgDestGoodsNo			= partsSubstUWork.ChgDestGoodsNo;      // �ϊ��揤�i�ԍ�
			partsSubstU.ChgDestGoodsNoNoneHp	= partsSubstUWork.ChgDestGoodsNoNoneHp;// �ϊ��揤�i�ԍ�(�n�C�t����)
			partsSubstU.ApplyStaDate			= partsSubstUWork.ApplyStaDate;        // �K�p�J�n��
			partsSubstU.ApplyEndDate			= partsSubstUWork.ApplyEndDate;        // �K�p�I����
			
			return partsSubstU;
		}

        /// <summary>
        /// �N���X�����o�R�s�[�����i���i��֐ݒ�N���X�˃��[�U�[���i��֐ݒ胏�[�N�N���X)
		/// </summary>
        /// <param name="partsSubstU">���[�U�[���i��֐ݒ�N���X</param>
        /// <returns>���[�U�[���i��֐ݒ胏�[�N�N���X</returns>
		/// <remarks>
        /// <br>Note        : ���[�U�[���i��֐ݒ�N���X����
        ///                   ���[�U�[���i��֐ݒ胏�[�N�N���X�փ����o�R�s�[���s���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private PartsSubstUWork CopyToPartsSubstUWorkFromPartsSubstU(PartsSubstU partsSubstU)
		{
            PartsSubstUWork partsSubstUWork = new PartsSubstUWork();

			// �n�C�t���J�b�g
			partsSubstU.ChgSrcGoodsNoNoneHp = partsSubstU.ChgSrcGoodsNo.Replace("-", "");
			partsSubstU.ChgDestGoodsNoNoneHp = partsSubstU.ChgDestGoodsNo.Replace("-", "");

			partsSubstUWork.CreateDateTime			= partsSubstU.CreateDateTime;      // �쐬����
			partsSubstUWork.UpdateDateTime			= partsSubstU.UpdateDateTime;      // �X�V����
			partsSubstUWork.EnterpriseCode			= partsSubstU.EnterpriseCode;      // ��ƃR�[�h
			partsSubstUWork.FileHeaderGuid			= partsSubstU.FileHeaderGuid;      // GUID
			partsSubstUWork.UpdEmployeeCode		= partsSubstU.UpdEmployeeCode;     // �X�V�]�ƈ��R�[�h
			partsSubstUWork.UpdAssemblyId1			= partsSubstU.UpdAssemblyId1;      // �X�V�A�Z���u��ID1
			partsSubstUWork.UpdAssemblyId2			= partsSubstU.UpdAssemblyId2;      // �X�V�A�Z���u��ID2
			partsSubstUWork.LogicalDeleteCode		= partsSubstU.LogicalDeleteCode;   // �_���폜�敪
			partsSubstUWork.ChgSrcMakerCd			= partsSubstU.ChgSrcMakerCd;       // �ϊ������[�J�[
			partsSubstUWork.ChgSrcGoodsNo			= partsSubstU.ChgSrcGoodsNo;       // �ϊ������i�ԍ�
			partsSubstUWork.ChgSrcGoodsNoNoneHp	= partsSubstU.ChgSrcGoodsNoNoneHp; // �ϊ������i�ԍ�(�n�C�t����)
			partsSubstUWork.ChgDestMakerCd			= partsSubstU.ChgDestMakerCd;      // �ϊ��惁�[�J�[
			partsSubstUWork.ChgDestGoodsNo			= partsSubstU.ChgDestGoodsNo;      // �ϊ��揤�i�ԍ�
			partsSubstUWork.ChgDestGoodsNoNoneHp	= partsSubstU.ChgDestGoodsNoNoneHp;// �ϊ��揤�i�ԍ�(�n�C�t����)
			partsSubstUWork.ApplyStaDate			= partsSubstU.ApplyStaDate;        // �K�p�J�n��
			partsSubstUWork.ApplyEndDate			= partsSubstU.ApplyEndDate;        // �K�p�I����
			
			return partsSubstUWork;
		}
		# endregion

		# region HashTable�pKey�쐬
		/// <summary>
		/// HashTable�pKey�쐬
		/// </summary>
        /// <param name="partsSubstU">���i��֐ݒ�N���X</param>
		/// <returns>Hash�pKey</returns>
		/// <remarks>
        /// <br>Note        : ���i��֐ݒ�N���X����n�b�V���e�[�u���p��
		///				 	  �L�[���쐬���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        private string CreateHashKey(PartsSubstU partsSubstU)
		{
			return partsSubstU.ChgSrcMakerCd.ToString("d6") +
					partsSubstU.ChgSrcGoodsNo.PadRight(40) +
					partsSubstU.ChgDestMakerCd.ToString("d6") +
					partsSubstU.ChgDestGoodsNo.PadRight(40);
		}

		/// <summary>
		/// HashTable�pKey�쐬
		/// </summary>
        /// <param name="partsSubstU">���i��֐ݒ胏�[�N�N���X</param>
		/// <returns>Hash�pKey</returns>
		/// <remarks>
        /// <br>Note        : ���i��֐ݒ胏�[�N�N���X����n�b�V���e�[�u���p��
		///					  �L�[���쐬���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
		private string CreateHashKey(PartsSubstUWork partsSubstUWork)
		{
			return partsSubstUWork.ChgSrcMakerCd.ToString("d6") +
					partsSubstUWork.ChgSrcGoodsNo.PadRight(40) +
					partsSubstUWork.ChgDestMakerCd.ToString("d6") +
					partsSubstUWork.ChgDestGoodsNo.PadRight(40);
		}

        #endregion HashTable�pKey�쐬

        // --------------------------------------------------
        #region Guide Methods

        /// <summary>
        /// �}�X�^�K�C�h�N������
        /// </summary>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="partsSubstU">�擾�f�[�^</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note        : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, out PartsSubstU partsSubstU)
        {
            int status = -1;
            partsSubstU = new PartsSubstU();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
            Hashtable inObj = new Hashtable();
            Hashtable retObj = new Hashtable();

            // ��ƃR�[�h
            inObj.Add(GUIDE_ENTERPRISECODE_TITLE, enterpriseCode);

            if (tableGuideParent.Execute(0, inObj, ref retObj))
            {
				partsSubstU.ChgSrcMakerCd = Convert.ToInt32(retObj[GUIDE_CHGSRCMAKERCD_TITLE]);	    // �ϊ������[�J�[
				partsSubstU.ChgDestMakerCd = Convert.ToInt32(retObj[GUIDE_CHGDESTMAKERCD_TITLE]);	// �ϊ��惁�[�J�[
                partsSubstU.ChgSrcGoodsNo = retObj[GUIDE_CHGSRCGOODSNO_TITLE].ToString();			// �ϊ������i�ԍ�
                partsSubstU.ChgDestGoodsNo = retObj[GUIDE_CHGDESTGOODSNO_TITLE].ToString();		    // �ϊ��揤�i�ԍ�
                
                status = 0;
            }
            // �L�����Z��
            else
            {
                status = 1;
            }

            return status;
        }

        /// <summary>
        /// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
        /// </summary>
        /// <param name="mode"></param>
        /// <param name="inParm"></param>
        /// <param name="guideList"></param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
        /// <remarks>
        /// <br>Note	    : �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
        /// <br>Programmer  : 30413 ����</br>
        /// <br>Date        : 2008.07.25</br>
        /// </remarks>
        public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
        {
            int status = -1;
            string enterpriseCode = "";

            // ��ƃR�[�h�ݒ�L��
            if (inParm.ContainsKey(GUIDE_ENTERPRISECODE_TITLE))
            {
                enterpriseCode = inParm[GUIDE_ENTERPRISECODE_TITLE].ToString();
            }
            // ��ƃR�[�h�ݒ薳��
            else
            {
                // �L�蓾�Ȃ��̂ŃG���[
                return status;
            }

            // �}�X�^�e�[�u���Ǎ���
			status = Search(ref guideList, enterpriseCode);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					break;
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						status = 4;
						break;
					}
				default:
					status = -1;
					break;
			}
            return status;
        }
        #endregion

        // ADD 2008/11/28 �s��Ή�[8317] ---------->>>>>
        #region �����^�C�v�擾����
        /// <summary>
        /// �����^�C�v�擾����
        /// </summary>
        /// <param name="inputCode">���͂��ꂽ�R�[�h</param>
        /// <param name="searchCode">�����p�R�[�h�i*�������j</param>
        /// <returns>0:���S��v���� 1:�O����v���� 2:�����v���� 3:�B������</returns>
        /// <remarks>
        /// <br>Note		: ����������@���擾���鏈�����s���܂��B</br>
        /// <br>Programmer  : 30462 �s�V</br>
        /// <br>Date        : 2008.11.28</br>
        /// </remarks>
        public int GetSearchType(string inputCode, out string searchCode)
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
        #endregion �����^�C�v�擾����
        // ADD 2008/11/28 �s��Ή�[8317] ----------<<<<<
	}
}
