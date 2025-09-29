using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Resources;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Collections;
using Broadleaf.Library.Globarization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using Broadleaf.Xml.Serialization;
using Broadleaf.Windows.Forms;

namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// �d�����z�����敪�ݒ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : �d�����z�����敪�ݒ�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 30167 ��� �O�M</br>
    /// <br>Date       : 2007.08.20</br>
    /// <br>Update Note: 2009.07.13 20056 ���n ��� LoginInfoAcquisition.OnlineFlag���Q�Ƃ��Đ���ؑւ��s��Ȃ�(���Online)</br>
    /// </remarks>
	public class StockProcMoneyAcs : IGeneralGuideData
	{
		# region Private Member

		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IStockProcMoneyDB _iStockProcMoneyDB = null;

		// Static�i�[�pHashTable
		private static Hashtable _static_StockProcMoneyTable = null;

		/// <summary>�d�����z�����敪�ݒ�}�X�^�N���XSearch�t���O</summary>
		private static bool _searchFlg;

		// �K�C�h�ݒ�t�@�C����
		private const string GUIDE_XML_FILENAME = "STOCKPROCMONEYGUIDEPARENT.XML";	// XML�t�@�C����

		// �K�C�h�p�����[�^
		private const string GUIDE_ENTERPRISECODE_PARA = "EnterpriseCode";			// ��ƃR�[�h

		// �K�C�h���ڃ^�C�v
		private const string GUIDE_TYPE_STR = "System.String";						// String�^

		// �K�C�h���ږ�
		private const string FRACPROCMONEYDIV_TITLE = "FracProcMoneyDiv";			// �[�������Ώۋ��z�敪
		private const string FRACTIONPROCCODE_TITLE = "FractionProcCode";			// �[�������R�[�h
		private const string UPPERLIMITPRICE_TITLE	= "UpperLimitPrice";			// ����敪
		private const string FRACTIONPROCUNIT_TITLE = "FractionProcUnit";			// �[�������P��
        private const string FRACTIONPROCCDNM_TITLE = "FractionProcCdNm";           // �[�������敪��

		# endregion

		/// <summary>
		/// �d�����z�����敪�ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public StockProcMoneyAcs()
		{
			// ��������������
			MemoryCreate();

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// ���O�C�����i�ŒʐM��Ԃ��m�F
            //if (LoginInfoAcquisition.OnlineFlag)
            //{
            //    try
            //    {
            //        // �����[�g�I�u�W�F�N�g�擾
            //        this._iStockProcMoneyDB = (IStockProcMoneyDB)MediationStockProcMoneyDB.GetStockProcMoneyDB();
            //    }
            //    catch (Exception)
            //    {		
            //        // �I�t���C������null���Z�b�g
            //        this._iStockProcMoneyDB = null;
            //    }
            //}
            //else
            //{
            //    // �I�t���C�����̃f�[�^�ǂݍ���(������)
            //}

            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iStockProcMoneyDB = (IStockProcMoneyDB)MediationStockProcMoneyDB.GetStockProcMoneyDB();
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iStockProcMoneyDB = null;
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
        }

        /// <summary>
		/// �d�����z�����敪�ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		static StockProcMoneyAcs()
        {
            // Static�i�[�pHashTable
			_static_StockProcMoneyTable = new Hashtable();
        }

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
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iStockProcMoneyDB == null)
			{
				return (int)ConstantManagement.OnlineMode.Offline;
			}
			else
			{
				return (int)ConstantManagement.OnlineMode.Online;
			}
		}

		/// <summary>
		/// �d�����z�����敪�ݒ� Static�������S���擾����
		/// </summary>
		/// <param name="retList">�d�����z�����敪�ݒ�}�X�^ �N���XList</param>
		/// <returns>�X�e�[�^�X(0:����I��, -1:�G���[, 9:�f�[�^����)</returns>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�}�X�^ Static�������̑S�����擾���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		public int SearchStaticMemory(out ArrayList retList, string enterpriseCode)
		{
			retList = new ArrayList();
			retList.Clear();
			SortedList sortedList = new SortedList();

			if ((_static_StockProcMoneyTable == null) || (_static_StockProcMoneyTable.Count == 0))
			{
				this.SearchAll(out retList, enterpriseCode);

				return 0;
			}
			else if (_static_StockProcMoneyTable.Count == 0)
			{
				return 9;
			}

			foreach (StockProcMoney stockProcMoney in _static_StockProcMoneyTable.Values)
			{
				sortedList.Add(CreateHashKey(stockProcMoney), stockProcMoney);
			}
			retList.AddRange(sortedList.Values);

			return 0;
		}

		/// <summary>
		/// �d�����z�����敪�ݒ�ǂݍ��ݏ���
		/// </summary>
		/// <param name="stockProcMoney">�d�����z�����敪�ݒ�I�u�W�F�N�g</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="upperLimitPrice">������z</param>
		/// <returns>�d�����z�����敪�ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ����ǂݍ��݂܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Read(out StockProcMoney stockProcMoney, string enterpriseCode, Int32 fracProcMoneyDiv, Int32 fractionProcCode, Double upperLimitPrice)
		{			
			try
			{
				int status = 0;
				stockProcMoney = null;
				StockProcMoneyWork stockProcMoneyWork = new StockProcMoneyWork();
				
				// �L�[���ڐݒ�
				stockProcMoneyWork.EnterpriseCode	= enterpriseCode;
				stockProcMoneyWork.FracProcMoneyDiv = fracProcMoneyDiv;
				stockProcMoneyWork.FractionProcCode = fractionProcCode;
				stockProcMoneyWork.UpperLimitPrice	= upperLimitPrice;

				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(stockProcMoneyWork);

				// �d�����z�����敪�ݒ�ǂݍ���
				status = this._iStockProcMoneyDB.Read(ref parabyte, 0);

				// XML�̓ǂݍ��� 
				stockProcMoneyWork = (StockProcMoneyWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockProcMoneyWork));
				
				if (status == 0)
				{
					// �N���X�������o�R�s�[
					stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(stockProcMoneyWork);

					// Static�ɕێ�
					_static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney;
				}
				return status;
			}
			catch (Exception)
			{				
				// �ʐM�G���[��-1��߂�
				stockProcMoney = null;
				// �I�t���C������null���Z�b�g
				this._iStockProcMoneyDB = null;
				return -1;
			}
		}

		/// <summary>
		/// �d�����z�����敪�ݒ�o�^�E�X�V����
		/// </summary>
		/// <param name="stockProcMoney">�d�����z�����敪�ݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ���̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Write(ref StockProcMoney stockProcMoney)
		{
			int status = 0;

			try
			{
				// �d�����z�����敪�ݒ�N���X����d�����z�����敪�ݒ胏�[�N�N���X�Ƀ����o�R�s�[
				StockProcMoneyWork stockProcMoneyWork = CopyToStockProcMoneyWorkFromStockProcMoney(stockProcMoney);

				ArrayList paraList = new ArrayList();
				paraList.Add(stockProcMoneyWork);
				object paraObj = (object)paraList;

				//�d�����z�����敪�ݒ菑������
				status = this._iStockProcMoneyDB.Write(ref paraObj);
				
				if (status == 0)
				{
					paraList = paraObj as ArrayList;
					stockProcMoneyWork = (StockProcMoneyWork)paraList[0];

					// �N���X�������o�R�s�[
					stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(stockProcMoneyWork);

					// Static�ɍX�V
					_static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney;
				}
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iStockProcMoneyDB = null;
				// �ʐM�G���[��-1��߂�
				status = -1;
			}

			return status;
		}

		/// <summary>
		/// �d�����z�����敪�ݒ�_���폜����
		/// </summary>
		/// <param name="stockProcMoney">�d�����z�����敪�ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ���̘_���폜���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int LogicalDelete(ref StockProcMoney stockProcMoney)
		{
			try
			{
				int status = 0;

				// �d�����z�����敪�ݒ�N���X����d�����z�����敪�ݒ胏�[�N�N���X�Ƀ����o�R�s�[
				StockProcMoneyWork stockProcMoneyWork = CopyToStockProcMoneyWorkFromStockProcMoney(stockProcMoney);

				ArrayList paraList = new ArrayList();
				paraList.Add(stockProcMoneyWork);

				object paraObj = (object)paraList;

				// �_���폜
				status = this._iStockProcMoneyDB.LogicalDelete(ref paraObj);

				if (status == 0)
				{
					paraList = paraObj as ArrayList;
					stockProcMoneyWork = (StockProcMoneyWork)paraList[0];

					// �N���X�������o�R�s�[
					stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(stockProcMoneyWork);

					// Static�ɍX�V
					_static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney.Clone();
				}
				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iStockProcMoneyDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �d�����z�����敪�ݒ蕨���폜����
		/// </summary>
		/// <param name="stockProcMoney">�d�����z�����敪�ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ���̕����폜���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Delete(StockProcMoney stockProcMoney)
		{
			try
			{
				int status = 0;

				// �d�����z�����敪�ݒ�N���X����d�����z�����敪�ݒ胏�[�N�N���X�Ƀ����o�R�s�[
				StockProcMoneyWork stockProcMoneyWork = CopyToStockProcMoneyWorkFromStockProcMoney(stockProcMoney);
				
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(stockProcMoneyWork);

				// �����폜
				status = this._iStockProcMoneyDB.Delete(parabyte);

				// Static�ɍX�V
				_static_StockProcMoneyTable.Remove(CreateHashKey(stockProcMoney));

				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iStockProcMoneyDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �d�����z�����敪�ݒ茟�������i�_���폜�܂܂Ȃ��j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Search(out ArrayList retList, string enterpriseCode)
		{
			int retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, enterpriseCode, 0, null);
		}

		/// <summary>
		/// �d�����z�����敪�ݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList,string enterpriseCode)
		{
			int retTotalCnt;
			return SearchProc(out retList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
		}

		/// <summary>
		/// �d�����z�����敪�ݒ�_���폜��������
		/// </summary>
		/// <param name="stockProcMoney">�d�����z�����敪�ݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ���̕������s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		public int Revival(ref StockProcMoney stockProcMoney)
		{
			try
			{
				int status = 0;

				// �d�����z�����敪�ݒ�N���X����d�����z�����敪�ݒ胏�[�N�N���X�Ƀ����o�R�s�[
				StockProcMoneyWork stockProcMoneyWork = CopyToStockProcMoneyWorkFromStockProcMoney(stockProcMoney);

				ArrayList paraList = new ArrayList();
				paraList.Add(stockProcMoneyWork);
				object paraObj = (object)paraList;

				// ��������
				status = this._iStockProcMoneyDB.RevivalLogicalDelete(ref paraObj);

				if (status == 0)
				{
					paraList = paraObj as ArrayList;
					stockProcMoneyWork = (StockProcMoneyWork)paraList[0];

					// �N���X�������o�R�s�[
					stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(stockProcMoneyWork);

					// Static�ɕێ�
					_static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney;
				}
				return status;
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iStockProcMoneyDB = null;
				// �ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// �d�����z�����敪�ݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevStockProcMoney��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="prevStockProcMoney">�O��ŏI�d�����z�����敪�ݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�̌����������s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private int SearchProc(out ArrayList retList, out int retTotalCnt, string enterpriseCode, ConstantManagement.LogicalMode logicalMode, StockProcMoney prevStockProcMoney)
		{
			StockProcMoneyWork stockProcMoneyWork = new StockProcMoneyWork();
			
			if (prevStockProcMoney != null)
			{
				// �d�����z�����敪�ݒ�N���X����d�����z�����敪�ݒ胏�[�N�N���X�Ƀ����o�R�s�[
				stockProcMoneyWork = CopyToStockProcMoneyWorkFromStockProcMoney(prevStockProcMoney);
			}
			stockProcMoneyWork.EnterpriseCode = enterpriseCode;

			// �i�荞�ݖ���
			stockProcMoneyWork.FracProcMoneyDiv = -1;	// �[�������Ώۋ��z�敪
			stockProcMoneyWork.FractionProcCode = -1;	// �[�������R�[�h

			retList = new ArrayList();
			retList.Clear();

			retTotalCnt = 0;
			int status = 0;

			ArrayList paraList = new ArrayList();
			paraList.Clear();	// �擾�f�[�^�i�[�p���[�N�N���A

			object retObj = null;

			ArrayList al = new ArrayList();
			al.Add(stockProcMoneyWork);
			object paraObj = al;

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// �I�t���C���̏ꍇ�̓L���b�V������ǂ�
            //if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    status = SearchStaticMemory(out retList, enterpriseCode);
            //}
            //else
            //{
            //    StockProcMoney stockProcMoney = new StockProcMoney();

            //    // ����
            //    status = this._iStockProcMoneyDB.Search(out retObj, paraObj, 0, logicalMode);

            //    if (status == 0)
            //    {
            //        // �d�����z�����敪�ݒ�}�X�^���[�J�[�N���X��UI�N���XStatic�]�L����
            //        CopyToStaticFromWorker(retObj as ArrayList);

            //        // �p�����[�^���n���ė��Ă��邩�m�F
            //        paraList = retObj as ArrayList;
            //        StockProcMoneyWork[] wkStockProcMoneyWork = new StockProcMoneyWork[paraList.Count];

            //        // �f�[�^�����ɖ߂�
            //        for (int i = 0; i < paraList.Count; i++)
            //        {
            //            wkStockProcMoneyWork[i] = (StockProcMoneyWork)paraList[i];
            //        }
            //        for (int i = 0; i < wkStockProcMoneyWork.Length; i++)
            //        {
            //            stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(wkStockProcMoneyWork[i]);
            //            // �T�[�`���ʎ擾
            //            retList.Add(stockProcMoney);
            //            // �X�^�e�B�b�N�X�V
            //            _static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney;
            //        }
            //        // SearchFlg ON
            //        _searchFlg = true;
            //    }
            //}

            // �I�t���C���̏ꍇ�̓L���b�V������ǂ�
            StockProcMoney stockProcMoney = new StockProcMoney();

            // ����
            status = this._iStockProcMoneyDB.Search(out retObj, paraObj, 0, logicalMode);

            if (status == 0)
            {
                // �d�����z�����敪�ݒ�}�X�^���[�J�[�N���X��UI�N���XStatic�]�L����
                CopyToStaticFromWorker(retObj as ArrayList);

                // �p�����[�^���n���ė��Ă��邩�m�F
                paraList = retObj as ArrayList;
                StockProcMoneyWork[] wkStockProcMoneyWork = new StockProcMoneyWork[paraList.Count];

                // �f�[�^�����ɖ߂�
                for (int i = 0; i < paraList.Count; i++)
                {
                    wkStockProcMoneyWork[i] = (StockProcMoneyWork)paraList[i];
                }
                for (int i = 0; i < wkStockProcMoneyWork.Length; i++)
                {
                    stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(wkStockProcMoneyWork[i]);
                    // �T�[�`���ʎ擾
                    retList.Add(stockProcMoney);
                    // �X�^�e�B�b�N�X�V
                    _static_StockProcMoneyTable[CreateHashKey(stockProcMoney)] = stockProcMoney;
                }
                // SearchFlg ON
                _searchFlg = true;
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

			return status;
		}

        /// <summary>
        /// �d�����z�����敪�ݒ�}�X�^���������iDataSet�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d�����z�����敪�ݒ�}�X�^�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		public int Search(ref DataSet ds, string enterpriseCode, int fracProcMoneyDiv, int fractionProcCode)
        {
            ArrayList ar = new ArrayList();
            ArrayList stockProcMoneyList = new ArrayList();

            int status = 0;
            int retTotalCnt;

            // 2009.07.13 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
            //// �I�����C�����ASearch���s���Ă��Ȃ��ꍇ�i�I�t���C���̏ꍇ�̓R���X�g���N�^��Static�W�J�ς݁j
            //if (( !_searchFlg ) && ( LoginInfoAcquisition.OnlineFlag ))
            //{
            //    // �d�����z�����敪�ݒ�}�X�^�T�[�`
            //    status = this.SearchProc(out stockProcMoneyList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
            //    if (status == 0)
            //    {
            //    }
            //    else
            //    {
            //        return status;
            //    }
            //}

            // �I�����C�����ASearch���s���Ă��Ȃ��ꍇ�i�I�t���C���̏ꍇ�̓R���X�g���N�^��Static�W�J�ς݁j
            if (!_searchFlg)
            {
                // �d�����z�����敪�ݒ�}�X�^�T�[�`
                status = this.SearchProc(out stockProcMoneyList, out retTotalCnt, enterpriseCode, ConstantManagement.LogicalMode.GetDataAll, null);
                if (status == 0)
                {
                }
                else
                {
                    return status;
                }
            }
            // 2009.07.13 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

            // Static����K�C�h�\���i�I��/�I�t���ʁj	
			foreach (StockProcMoney stockProcMoney in _static_StockProcMoneyTable.Values)
            {
                // �[�������Ώۋ敪���w�肳��Ă���ꍇ�͂����ōi�荞��
				if ((fracProcMoneyDiv == -1) || (stockProcMoney.FracProcMoneyDiv == fracProcMoneyDiv))
                {
                    // �[�������R�[�h���w�肳��Ă���ꍇ�͂����ōi�荞��
                    if ((fractionProcCode == -1) || (stockProcMoney.FractionProcCode == fractionProcCode))
                    {
                        // �S�Е\��
                        ar.Add(stockProcMoney.Clone());
                    }
                }
            }

            ArrayList wkList = ar.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [�S��] --- //
            // ���̂܂ܑS���Ԃ�
			foreach (StockProcMoney wkStockProcMoney in wkList)
            {
				if (wkStockProcMoney.LogicalDeleteCode == 0)
                {
					wkSort.Add(CreateHashKey(wkStockProcMoney), wkStockProcMoney);
                }
            }

			StockProcMoney[] stockProcMoneys = new StockProcMoney[wkSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < wkSort.Count; i++)
            {
				stockProcMoneys[i] = (StockProcMoney)wkSort.GetByIndex(i);
            }

			byte[] retbyte = XmlByteSerializer.Serialize(stockProcMoneys);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�d�����z�����敪�ݒ胏�[�N�N���X�ˎd�����z�����敪�ݒ�N���X�j
		/// </summary>
		/// <param name="stockProcMoneyWork">�d�����z�����敪�ݒ胏�[�N�N���X</param>
		/// <returns>�d�����z�����敪�ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ胏�[�N�N���X����d�����z�����敪�ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private StockProcMoney CopyToStockProcMoneyFromStockProcMoneyWork(StockProcMoneyWork stockProcMoneyWork)
		{
			StockProcMoney stockProcMoney = new StockProcMoney();

			stockProcMoney.CreateDateTime		= stockProcMoneyWork.CreateDateTime;
			stockProcMoney.UpdateDateTime		= stockProcMoneyWork.UpdateDateTime;
			stockProcMoney.EnterpriseCode		= stockProcMoneyWork.EnterpriseCode;
			stockProcMoney.FileHeaderGuid		= stockProcMoneyWork.FileHeaderGuid;
			stockProcMoney.UpdEmployeeCode		= stockProcMoneyWork.UpdEmployeeCode;
			stockProcMoney.UpdAssemblyId1		= stockProcMoneyWork.UpdAssemblyId1;
			stockProcMoney.UpdAssemblyId2		= stockProcMoneyWork.UpdAssemblyId2;
			stockProcMoney.LogicalDeleteCode	= stockProcMoneyWork.LogicalDeleteCode;
			stockProcMoney.FracProcMoneyDiv		= stockProcMoneyWork.FracProcMoneyDiv;
			stockProcMoney.FractionProcCode		= stockProcMoneyWork.FractionProcCode;
			stockProcMoney.UpperLimitPrice		= stockProcMoneyWork.UpperLimitPrice;
			stockProcMoney.FractionProcUnit		= stockProcMoneyWork.FractionProcUnit;
			stockProcMoney.FractionProcCd		= stockProcMoneyWork.FractionProcCd;

			// �K�C�h�p���̐ݒ�
			stockProcMoney.FractionProcCdNm		= StockProcMoney.GetFractionProcCdNm(stockProcMoneyWork.FractionProcCd);

			return stockProcMoney;
		}
		
		/// <summary>
		/// �N���X�����o�[�R�s�[�����i�d�����z�����敪�ݒ�N���X�ˎd�����z�����敪�ݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="stockProcMoney">�d�����z�����敪�ݒ胏�[�N�N���X</param>
		/// <returns>�d�����z�����敪�ݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�N���X����d�����z�����敪�ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.20</br>
		/// </remarks>
		private StockProcMoneyWork CopyToStockProcMoneyWorkFromStockProcMoney(StockProcMoney stockProcMoney)
		{
			StockProcMoneyWork stockProcMoneyWork = new StockProcMoneyWork();

			stockProcMoneyWork.CreateDateTime		= stockProcMoney.CreateDateTime;
			stockProcMoneyWork.UpdateDateTime		= stockProcMoney.UpdateDateTime;
			stockProcMoneyWork.EnterpriseCode		= stockProcMoney.EnterpriseCode.Trim();
			stockProcMoneyWork.FileHeaderGuid		= stockProcMoney.FileHeaderGuid;
			stockProcMoneyWork.UpdEmployeeCode		= stockProcMoney.UpdEmployeeCode;
			stockProcMoneyWork.UpdAssemblyId1		= stockProcMoney.UpdAssemblyId1;
			stockProcMoneyWork.UpdAssemblyId2		= stockProcMoney.UpdAssemblyId2;
			stockProcMoneyWork.LogicalDeleteCode	= stockProcMoney.LogicalDeleteCode;
			stockProcMoneyWork.FracProcMoneyDiv		= stockProcMoney.FracProcMoneyDiv;
			stockProcMoneyWork.FractionProcCode		= stockProcMoney.FractionProcCode;
			stockProcMoneyWork.UpperLimitPrice		= stockProcMoney.UpperLimitPrice;
			stockProcMoneyWork.FractionProcUnit		= stockProcMoney.FractionProcUnit;
			stockProcMoneyWork.FractionProcCd		= stockProcMoney.FractionProcCd;

			return stockProcMoneyWork;
		}

		/// <summary>
		/// �N���X�����o�R�s�[���� (�K�C�h�I���f�[�^�ˎd�����z�����敪�ݒ�}�X�^�N���X)
		/// </summary>
		/// <param name="guideData">�K�C�h�I���f�[�^</param>
		/// <returns>�d�����z�����敪�ݒ�}�X�^�N���X</returns>
		/// <remarks>
		/// <br>Note       : �K�C�h�I���f�[�^����d�����z�����敪�ݒ�}�X�^�N���X�փ����o�R�s�[���s���܂��B</br>
		/// <br>Programmer : 30167 ��� �O�M</br>
		/// <br>Date       : 2007.08.28</br>
		/// </remarks>
		private StockProcMoney CopyToStockProcMoneyFromGuideData(Hashtable guideData)
		{
			StockProcMoney stockProcMoney = new StockProcMoney();

			stockProcMoney.FracProcMoneyDiv = int.Parse(guideData[FRACPROCMONEYDIV_TITLE].ToString());		    // �[�������Ώۋ��z�敪
			stockProcMoney.FractionProcCode = int.Parse(guideData[FRACTIONPROCCODE_TITLE].ToString());		    // �[�������R�[�h
			stockProcMoney.UpperLimitPrice	= double.Parse(guideData[UPPERLIMITPRICE_TITLE].ToString());	    // ����敪
			stockProcMoney.FractionProcUnit = double.Parse(guideData[FRACTIONPROCUNIT_TITLE].ToString());	    // �[�������P��
			stockProcMoney.FractionProcCdNm = guideData[FRACTIONPROCCDNM_TITLE].ToString();                     // �[�������敪��(�K�C�h�p)
            stockProcMoney.FractionProcCd = StockProcMoney.GetFractionProcCd(stockProcMoney.FractionProcCdNm);  // �[�������敪

			return stockProcMoney;
		}

		/// <summary>
		/// �d�����z�����敪�ݒ�}�X�^�K�C�h�N������
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="fracProcMoneyDiv">�[�������Ώۋ��z�敪</param>
		/// <param name="fractionProcCode">�[�������R�[�h</param>
		/// <param name="stockProcMoney">�擾�f�[�^</param>
		/// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
		/// <remarks>
		/// <br>Note		: �d�����z�����敪�ݒ�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
		/// <br>Programmer	: 30167 ��� �O�M</br>
		/// <br>Date		: 2007.08.28</br>
		/// </remarks>
		public int ExecuteGuid(string enterpriseCode, int fracProcMoneyDiv, int fractionProcCode, out StockProcMoney stockProcMoney)
		{
			int status = -1;
			stockProcMoney = new StockProcMoney();

            TableGuideParent tableGuideParent = new TableGuideParent(GUIDE_XML_FILENAME);
			Hashtable inObj = new Hashtable();
			Hashtable retObj = new Hashtable();

			inObj.Add(GUIDE_ENTERPRISECODE_PARA, enterpriseCode);	// ��ƃR�[�h
			inObj.Add(FRACPROCMONEYDIV_TITLE, fracProcMoneyDiv);	// �[�������Ώۋ��z�敪
			inObj.Add(FRACTIONPROCCODE_TITLE, fractionProcCode);	// �[�������R�[�h

			// �K�C�h�N��
			if (tableGuideParent.Execute(0, inObj, ref retObj))
			{
				// �I���f�[�^�̎擾
				stockProcMoney = CopyToStockProcMoneyFromGuideData(retObj);
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
		/// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
		/// <br>Programmer	: 30167 ��� �O�M</br>
		/// <br>Date		: 2007.08.28</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status = -1;
			string enterpriseCode = "";
			int fracProcMoneyDiv = -1;
			int fractionProcCode = -1;

			// ��ƃR�[�h�ݒ�L��
			if (inParm.ContainsKey(GUIDE_ENTERPRISECODE_PARA))
			{
				enterpriseCode = inParm[GUIDE_ENTERPRISECODE_PARA].ToString();
			}
			// ��ƃR�[�h�ݒ薳��
			else
			{
				// �L�蓾�Ȃ��̂ŃG���[
				return status;
			}

			// �[�������Ώۋ��z�敪
			if (inParm.ContainsKey(FRACPROCMONEYDIV_TITLE))
			{
				fracProcMoneyDiv = int.Parse(inParm[FRACPROCMONEYDIV_TITLE].ToString());
			}

			// �[�������R�[�h
			if (inParm.ContainsKey(FRACTIONPROCCODE_TITLE))
			{
				fractionProcCode = int.Parse(inParm[FRACTIONPROCCODE_TITLE].ToString());
            }

            _searchFlg = false;

            // �f�[�^�擾
			status = Search(ref guideList, enterpriseCode, fracProcMoneyDiv, fractionProcCode);

			switch (status)
			{
				case (int)ConstantManagement.DB_Status.ctDB_NORMAL:
					{
						break;
					}
				case (int)ConstantManagement.DB_Status.ctDB_EOF:
					{
						status = 4;
						break;
					}
				default:
					{
						status = -1;
						break;
					}
			}
			return status;
		}

		/// <summary>
		/// ��������������
		/// </summary>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�A�N�Z�X�N���X���ێ����郁�����𐶐����܂��B</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		private void MemoryCreate()
		{

			// �d�����z�����敪�ݒ�}�X�^�N���XStatic
			if (_static_StockProcMoneyTable == null)
			{
				_static_StockProcMoneyTable = new Hashtable();
			}
		}

		/// <summary>
		/// �d�����z�����敪�ݒ胏�[�J�[�N���X�iList�j �� UI�N���X�ϊ�����
		/// </summary>
		/// <param name="stockProcMoneyWorkList">�d�����z�����敪�ݒ�}�X�^���[�J�[�N���X��ArrayList</param>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�}�X�^���[�J�[�N���X��UI�̃N���X�ɕϊ����āA
		///					 Search�pStatic�������ɕێ����܂��B</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		private void CopyToStaticFromWorker(List<StockProcMoneyWork> stockProcMoneyWorkList)
		{
			ArrayList stockProcMoneyWorkArray = new ArrayList();
			stockProcMoneyWorkArray.AddRange(stockProcMoneyWorkList);

			CopyToStaticFromWorker(stockProcMoneyWorkArray);
		}

		/// <summary>
		/// �d�����z�����敪�ݒ胏�[�J�[�N���X�iArrayList�j �� UI�N���X�ϊ�����
		/// </summary>
		/// <param name="stockProcMoneyWorkList">�d�����z�����敪�ݒ�}�X�^���[�J�[�N���X��ArrayList</param>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ胏�[�J�[�N���X��UI�̃N���X�ɕϊ����āA
		///					 Search�pStatic�������ɕێ����܂��B</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		private void CopyToStaticFromWorker(ArrayList stockProcMoneyWorkList)
		{
			string hashKey;
			foreach (StockProcMoneyWork wkStockProcMoneyWork in stockProcMoneyWorkList)
			{
				StockProcMoney stockProcMoney = CopyToStockProcMoneyFromStockProcMoneyWork(wkStockProcMoneyWork);

				// HashKey:�[�������Ώۋ��z�敪�A�[�������R�[�h�A������z
				hashKey = CreateHashKey(stockProcMoney);

				_static_StockProcMoneyTable[hashKey] = stockProcMoney;
			}
		}

		/// <summary>
		/// HashTable�pKey�쐬
		/// </summary>
		/// <param name="stockProcMoney">�d�����z�����敪�ݒ�N���X</param>
		/// <returns>Hash�pKey</returns>
		/// <remarks>
		/// <br>Note       : �d�����z�����敪�ݒ�N���X����n�b�V���e�[�u���p��
		///					 �L�[���쐬���܂��B</br>
		/// <br>Programer  : 30167 ���@�O�M</br>
		/// <br>Date       : 2007.08.30</br>
		/// </remarks>
		private string CreateHashKey(StockProcMoney stockProcMoney)
		{
			return stockProcMoney.FracProcMoneyDiv.ToString("d9") +
				   stockProcMoney.FractionProcCode.ToString("d9") +
				   stockProcMoney.UpperLimitPrice.ToString("000000000.00");
		}
	}
}
