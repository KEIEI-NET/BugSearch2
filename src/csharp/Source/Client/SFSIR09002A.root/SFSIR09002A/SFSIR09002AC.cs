using System;
using System.Collections;
using System.Data;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// �d���݌ɑS�̐ݒ�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : �d���݌ɑS�̐ݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
    /// <br>Programmer : 19018 Y.Gamoto</br>
    /// <br>Date       : 2005.04.12</br>
    /// <br></br>
    /// <br>Update Note: 2005.06.21 22035 �O�� �O��</br>
    /// <br>           : ������̍Ō�ɂ���X�y�[�X���폜</br>
    /// <br>Update Note: 2006.12.20 20031 �É�@���S��</br>
    /// <br>           : ���ڒǉ�</br>
    /// <br>Update Note: 2007.06.12 30005 �،��@��</br>
    /// <br>           : ���������u�d�����i�擾�P�ʋ敪�v�ǉ�</br>
	/// <br>Update Note: 2008.02.18 30167 ���@�O�M</br>
	/// <br>			 �����x���֘A���ڒǉ�</br>
    /// <br>Update Note: 2008.02.27 20081 �D�c �E�l</br>
    /// <br>			 ���o�א��敪�Q��ǉ�</br>
    /// <br>UpdateNote : 2008/06/06 30415 �ēc �ύK</br>
    /// <br>        	 �E�f�[�^���ڂ̒ǉ�/�폜�ɂ��C��</br>   
    /// <br>UpdateNote : 2008/07/22 30415 �ēc �ύK</br>
    /// <br>        	 �E���ڂ̍폜�ɂ��C��</br>   
    /// <br>UpdateNote : 2008/9/12 30452 ��� �r��</br>
    /// <br>        	 �E�݌Ɍ����敪�̒ǉ�</br>
    /// <br>UpdateNote : 2008.12.01�@21024�@���X�� ��</br>
    /// <br>        	 �ESearch���\�b�h�̎���</br>
    /// <br>        	 �E����擾���ɕs�v�ȏ������J��Ԃ��Ȃ��悤�ɏC��</br>
    /// <br>UpdateNote : 2009.02.25�@20056 ���n ���</br>
    /// <br>        	 �E�d���݌ɑS�̏��̂ݎ擾����Search���\�b�h�ǉ�</br>
    /// </remarks>
    public class StockTtlStAcs
    {
        /// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private IStockTtlStDB _iStockTtlStDB = null;

		//----- ueno add ---------- start 2008.02.18
		// ���z��ʐݒ�}�X�^�A�N�Z�X�N���X
		private MoneyKindAcs _moneyKindAcs = null;

		// ���z��ʋ敪�}�X�^�A�N�Z�X�N���X
		private MnyKindDivAcs _mnyKindDivAcs = null;
		//----- ueno add ---------- end 2008.02.18

        /// <summary>
        /// �d���݌ɑS�̐ݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
        /// </summary>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public StockTtlStAcs()
        {
            try
            {
                // �����[�g�I�u�W�F�N�g�擾
                this._iStockTtlStDB = (IStockTtlStDB)MediationStockTtlStDB.GetStockTtlStDB();

				//----- ueno add ---------- start 2008.02.18
				// ���z��ʐݒ�}�X�^�A�N�Z�X�N���X
				this._moneyKindAcs = new MoneyKindAcs();

				// ���z��ʋ敪�}�X�^�A�N�Z�X�N���X
				this._mnyKindDivAcs = new MnyKindDivAcs();
				//----- ueno add ---------- end 2008.02.18

                // 2008.12.01 Add >>>
                StockTtlSt._autoPayMoneyKindCodeList = null;
                StockTtlSt._mnyKindDivList = null;
                // 2008.12.01 Add <<<
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iStockTtlStDB = null;
            }
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
        /// �I�����C�����[�h�擾
        /// </summary>
        /// <returns>OnlineMode</returns>
        /// <remarks>
        /// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>		
        public int GetOnlineMode()
        {
            if (this._iStockTtlStDB == null)
            {
                return (int)OnlineMode.Offline;
            }
            else
            {
                return (int)OnlineMode.Online;
            }
        }

		//----- ueno add ---------- start 2008.02.18
		#region �����x������敪�R�[�h�擾����
		/// <summary>
		/// �����x������敪�R�[�h�擾����
		/// </summary>
		/// <param name="autoPayMoneyKindCode">�����x������R�[�h</param>
		/// <returns>�����x������敪�R�[�h</returns>
		/// <remarks>
		/// <br>Note       : �����x������敪�R�[�h���擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		public int GetAutoPayMoneyKindDiv(int autoPayMoneyKindCode)
		{
			int autoPayMoneyKindDiv = 0;

			if (StockTtlSt._autoPayMoneyKindCodeList.ContainsKey(autoPayMoneyKindCode) == true)
			{
				MoneyKind moneyKind = (MoneyKind)StockTtlSt._autoPayMoneyKindCodeList[autoPayMoneyKindCode];
				autoPayMoneyKindDiv = moneyKind.MoneyKindDiv;	// ���z��ʋ敪�ݒ�
			}
			return autoPayMoneyKindDiv;
		}
		#endregion

		#region �����x�����햼�̎擾����
		/// <summary>
		/// �����x�����햼�̎擾����
		/// </summary>
		/// <param name="autoPayMoneyKindCode">�����x������R�[�h</param>
		/// <returns>�����x�����햼��</returns>
		/// <remarks>
		/// <br>Note       : �����x�����햼�̂��擾���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		public string GetAutoPayMoneyKindName(int autoPayMoneyKindCode)
		{
			string autoPayMoneyKindName = "";

			if (StockTtlSt._autoPayMoneyKindCodeList.ContainsKey(autoPayMoneyKindCode) == true)
			{
				MoneyKind moneyKind = (MoneyKind)StockTtlSt._autoPayMoneyKindCodeList[autoPayMoneyKindCode];
				autoPayMoneyKindName = moneyKind.MoneyKindName;	// ���햼�̐ݒ�
			}
			return autoPayMoneyKindName;
		}
		#endregion
		//----- ueno add ---------- end 2008.02.18

        /// <summary>
        /// �d���݌ɑS�̐ݒ�ǂݍ��ݏ���
        /// </summary>
        /// <param name="stockttlset">�d���݌ɑS�̐ݒ�I�u�W�F�N�g</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>   
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ��ǂݍ��݂܂��B</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public int Read(out StockTtlSt stockttlset, string enterpriseCode)
        {
            try
            {
				//----- ueno add ---------- start 2008.02.18
				// ���z��ʐݒ�f�[�^�擾�ݒ�
				SetMoneyKindList(enterpriseCode);

				// ���z��ʋ敪�f�[�^�擾�ݒ�
				SetMnyKindDivList();
				//----- ueno add ---------- end 2008.02.18

                stockttlset = null;
                StockTtlStWork stockttlsetWork = new StockTtlStWork();
                stockttlsetWork.EnterpriseCode = enterpriseCode;

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(stockttlsetWork);

                //�d���݌ɑS�̐ݒ�ǂݍ���
                int status = this._iStockTtlStDB.Read(ref parabyte, 0);

                if (status == 0)
                {
                    // XML�̓ǂݍ���
                    stockttlsetWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockTtlStWork));
                    // �N���X�������o�R�s�[
                    stockttlset = CopyToStockTtlStFromStockTtlStWork(stockttlsetWork);
                }
                return status;
            }
            catch (Exception)
            {
                //�ʐM�G���[��-1��߂�
                stockttlset = null;
                //�I�t���C������null���Z�b�g
                this._iStockTtlStDB = null;
                return -1;
            }
        }

        //----- ueno add ---------- start 2008.02.18
		/// <summary>
		/// ���z��ʐݒ�f�[�^�ݒ菈��
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�f�[�^�̎擾���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		private int SetMoneyKindList(string enterpriseCode)
		{
            // 2008.12.01 Del >>>
            //if (StockTtlSt._autoPayMoneyKindCodeList == null)
            //{
            //    StockTtlSt._autoPayMoneyKindCodeList = new SortedList();
            //}

            //ArrayList wkMoneyKindList = null;				// �S�Ă̋��z��ʐݒ胊�X�g
            //int status = this._moneyKindAcs.Search(out wkMoneyKindList, enterpriseCode);

            //if (status == 0)
            //{
            //    foreach (MoneyKind moneyKind in wkMoneyKindList)
            //    {
            //        // ����ݒ�敪��"����"�̃f�[�^�̂ݐݒ肷��
            //        if (moneyKind.PriceStCode == 0)
            //        {
            //            if (StockTtlSt._autoPayMoneyKindCodeList.ContainsKey(moneyKind.MoneyKindCode) == false)
            //            {
            //                // key:����R�[�h, value:���z��ʐݒ�I�u�W�F�N�g
            //                StockTtlSt._autoPayMoneyKindCodeList.Add(moneyKind.MoneyKindCode, moneyKind);
            //            }
            //        }
            //    }
            //}
            if (StockTtlSt._autoPayMoneyKindCodeList == null)
            {
                StockTtlSt._autoPayMoneyKindCodeList = new SortedList();

                ArrayList wkMoneyKindList = null;				// �S�Ă̋��z��ʐݒ胊�X�g
                int status = this._moneyKindAcs.Search(out wkMoneyKindList, enterpriseCode);

                if (status == 0)
                {
                    foreach (MoneyKind moneyKind in wkMoneyKindList)
                    {
                        // ����ݒ�敪��"����"�̃f�[�^�̂ݐݒ肷��
                        if (moneyKind.PriceStCode == 0)
                        {
                            if (StockTtlSt._autoPayMoneyKindCodeList.ContainsKey(moneyKind.MoneyKindCode) == false)
                            {
                                // key:����R�[�h, value:���z��ʐݒ�I�u�W�F�N�g
                                StockTtlSt._autoPayMoneyKindCodeList.Add(moneyKind.MoneyKindCode, moneyKind);
                            }
                        }
                    }
                }
            }
            // 2008.12.01 Del <<<
            return 0;
		}

		/// <summary>
		///  ���z��ʋ敪�f�[�^�ݒ菈��
		/// </summary>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʋ敪�f�[�^�̎擾���s���܂��B</br>
		/// <br>Programmer : 30167 ���@�O�M</br>
		/// <br>Date       : 2008.02.18</br>
		/// </remarks>
		private int SetMnyKindDivList()
		{
            // 2008.12.01 Update >>>
            //if (StockTtlSt._mnyKindDivList == null)
            //{
            //    StockTtlSt._mnyKindDivList = new SortedList();
            //}

            //ArrayList mnyKindDivList = null;
            //this._mnyKindDivAcs.Search(out mnyKindDivList);

            //foreach (MnyKindDiv mnyKindDiv in mnyKindDivList)
            //{
            //    if (StockTtlSt._mnyKindDivList.ContainsKey(mnyKindDiv.MoneyKindDiv) == false)
            //    {
            //        StockTtlSt._mnyKindDivList.Add(mnyKindDiv.MoneyKindDiv, mnyKindDiv.MoneyKindDivName);
            //    }
            //}

            if (StockTtlSt._mnyKindDivList == null)
            {
                StockTtlSt._mnyKindDivList = new SortedList();

                ArrayList mnyKindDivList = null;
                this._mnyKindDivAcs.Search(out mnyKindDivList);

                foreach (MnyKindDiv mnyKindDiv in mnyKindDivList)
                {
                    if (StockTtlSt._mnyKindDivList.ContainsKey(mnyKindDiv.MoneyKindDiv) == false)
                    {
                        StockTtlSt._mnyKindDivList.Add(mnyKindDiv.MoneyKindDiv, mnyKindDiv.MoneyKindDivName);
                    }
                }
            }
            // 2008.12.01 Update <<<
            return 0;
		}
		//----- ueno add ---------- end 2008.02.18

        /// <summary>
        /// �d���݌ɑS�̐ݒ�N���X�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
        /// <returns>�d���݌ɑS�̐ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public StockTtlSt Deserialize(string fileName)
        {
            StockTtlSt stockttlset = null;

            // �t�@�C������n����>�d���݌ɑS�̐ݒ胏�[�N�N���X���f�V���A���C�Y����
            StockTtlStWork stockttlsetWork = (StockTtlStWork)XmlByteSerializer.Deserialize(fileName, typeof(StockTtlStWork));
            //�f�V���A���C�Y���ʂ�>�d���݌ɑS�̐ݒ�N���X�փR�s�[
            if (stockttlsetWork != null) stockttlset = CopyToStockTtlStFromStockTtlStWork(stockttlsetWork);
            return stockttlset;
        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ�List�N���X�f�V���A���C�Y����
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
        /// <returns>�d���݌ɑS�̐ݒ�N���XLIST</returns>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ胊�X�g�N���X���f�V���A���C�Y���܂��B</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>		
        public ArrayList ListDeserialize(string fileName)
        {
            ArrayList al = new ArrayList();
            // �t�@�C������n���Ďd���݌ɑS�̐ݒ胏�[�N�N���X���f�V���A���C�Y����
            StockTtlStWork[] stockttlsetWorks = (StockTtlStWork[])XmlByteSerializer.Deserialize(fileName, typeof(StockTtlStWork[]));

            //�f�V���A���C�Y���ʂ��d���݌ɑS�̐ݒ�N���X�փR�s�[
            if (stockttlsetWorks != null)
            {
                al.Capacity = stockttlsetWorks.Length;
                for (int i = 0; i < stockttlsetWorks.Length; i++)
                {
                    al.Add(CopyToStockTtlStFromStockTtlStWork(stockttlsetWorks[i]));
                }
            }
            return al;
        }

        // 2008.12.01 Add >>>
        /// <summary>
        /// �d���݌ɑS�̐ݒ茟������
        /// </summary>
        /// <param name="retList">�������ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o����܂���</br>
        /// <br>Programmer : 21024 ���X�� ��</br>
        /// <br>Date       : 2008.12.01</br>
        /// </remarks>
        public int Search(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        // 2008.12.01 Add <<<

        /// <summary>
        /// �d���݌ɑS�̐ݒ茟������(�_���폜�f�[�^�܂�)
        /// </summary>
        /// <param name="retList">�������ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂɊ܂݂܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int SearchAll(out ArrayList retList, string enterpriseCode)
        {
            return SearchProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData01);
        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ茟������(���C��)
        /// </summary>
        /// <param name="retList">�������ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�̌����������s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        private int SearchProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            StockTtlStWork stockTtlStWork = new StockTtlStWork();
            stockTtlStWork.EnterpriseCode = enterpriseCode;		// ��ƃR�[�h

            // ���z��ʐݒ�f�[�^�擾�ݒ�
            SetMoneyKindList(enterpriseCode);

            // ���z��ʋ敪�f�[�^�擾�ݒ�
            SetMnyKindDivList();

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = stockTtlStWork;
            object retobj = null;

            // �d���݌ɑS�̐ݒ�S������
            status = this._iStockTtlStDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (StockTtlStWork wkStockTtlStWork in wkList)
                    {
                        retList.Add(CopyToStockTtlStFromStockTtlStWork(wkStockTtlStWork));
                    }
                }
            }

            return status;
        }

        // 2009.02.25 >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        /// <summary>
        /// �d���݌ɑS�̐ݒ茟������
        /// </summary>
        /// <param name="retList">�������ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        public int SearchOnlyStockTtlInfo(out ArrayList retList, string enterpriseCode)
        {
            return SearchOnlyStockTtlInfoProc(out retList, enterpriseCode, ConstantManagement.LogicalMode.GetData0);
        }
        /// <summary>
        /// �d���݌ɑS�̐ݒ茟������(���C��)
        /// </summary>
        /// <param name="retList">�������ʃR���N�V����</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="logicalMode">�_���폜�L��</param>
        /// <returns>STATUS</returns>
        private int SearchOnlyStockTtlInfoProc(out ArrayList retList, string enterpriseCode,
            ConstantManagement.LogicalMode logicalMode)
        {
            int status = 0;

            retList = new ArrayList();
            retList.Clear();

            StockTtlStWork stockTtlStWork = new StockTtlStWork();
            stockTtlStWork.EnterpriseCode = enterpriseCode;		// ��ƃR�[�h

            ArrayList wkList = new ArrayList();
            wkList.Clear();

            object paraobj = stockTtlStWork;
            object retobj = null;

            // �d���݌ɑS�̐ݒ�S������
            status = this._iStockTtlStDB.Search(out retobj, paraobj, 0, logicalMode);

            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                wkList = retobj as ArrayList;
                if (wkList != null)
                {
                    foreach (StockTtlStWork wkStockTtlStWork in wkList)
                    {
                        retList.Add(CopyToStockTtlStFromStockTtlStWork(wkStockTtlStWork));
                    }
                }
            }

            return status;
        }
        // 2009.02.25 <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<

        /// <summary>
        /// �d���݌ɑS�̐ݒ�_���폜����
        /// </summary>
        /// <param name="stockTtlSt">�d���݌ɑS�̐ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�̘_���폜���s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int LogicalDelete(ref StockTtlSt stockTtlSt)
        {
            int status = 0;

            try
            {
                // �d���݌ɑS�̐ݒ�N���X���d���݌ɑS�̐ݒ胏�[�N�N���X�փ����o�R�s�[
                StockTtlStWork stockTtlStWork = CopyToStockTtlStWorkFromStockTtlSt(stockTtlSt);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(stockTtlStWork);

                // �_���폜
                //Object paraObj = (object)stockTtlStWork;
                //status = this._iStockTtlStDB.LogicalDelete(ref paraObj);
                status = this._iStockTtlStDB.LogicalDelete(ref parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �d���݌ɑS�̐ݒ胏�[�N�N���X���f�V���A���C�Y
                    stockTtlStWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockTtlStWork));

                    // �d���݌ɑS�̐ݒ胏�[�N�N���X���d���݌ɑS�̐ݒ�N���X�Ƀ����o�R�s�[
                    //stockTtlStWork = paraObj as StockTtlStWork;
                    //stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);
                    stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iStockTtlStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                return -1;
            }
        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ蕨���폜����
        /// </summary>
        /// <param name="stockTtlSt">�d���݌ɑS�̐ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�̕����폜���s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Delete(StockTtlSt stockTtlSt)
        {
            int status = 0;
            try
            {
                // �d���݌ɑS�̐ݒ�N���X���d���݌ɑS�̐ݒ胏�[�N�N���X�փ����o�R�s�[
                StockTtlStWork stockTtlStWork = CopyToStockTtlStWorkFromStockTtlSt(stockTtlSt);
                // XML�ϊ����A��������o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(stockTtlStWork);

                // �d���݌ɑS�̐ݒ蕨���폜
                status = this._iStockTtlStDB.Delete(parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null��ݒ�
                this._iStockTtlStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                return -1;
            }
        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ�_���폜��������
        /// </summary>
        /// <param name="stockTtlSt">�d���݌ɑS�̐ݒ�I�u�W�F�N�g</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�̘_���폜�������s���܂��B</br>
        /// <br>Programmer : 30415 �ēc �ύK</br>
        /// <br>Date       : 2008/06/06</br>
        /// </remarks>
        public int Revival(ref StockTtlSt stockTtlSt)
        {
            int status = 0;

            try
            {
                // �d���݌ɑS�̐ݒ�N���X���d���݌ɑS�̐ݒ胏�[�N�N���X�փ����o�R�s�[
                StockTtlStWork stockTtlStWork = CopyToStockTtlStWorkFromStockTtlSt(stockTtlSt);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(stockTtlStWork);

                // ����
                //Object paraObj = (object)stockTtlStWork;
                //status = this._iStockTtlStDB.RevivalLogicalDelete(ref paraObj);
                status = this._iStockTtlStDB.RevivalLogicalDelete(ref parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �d���݌ɑS�̐ݒ胏�[�N�N���X���f�V���A���C�Y
                    stockTtlStWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockTtlStWork));

                    // �d���݌ɑS�̐ݒ胏�[�N�N���X���d���݌ɑS�̐ݒ�N���X�Ƀ����o�R�s�[
                    //stockTtlStWork = paraObj as StockTtlStWork;
                    //stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);
                    stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iStockTtlStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                return -1;
            }
        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ�o�^�E�X�V����
        /// </summary>
        /// <param name="stockTtlSt">�d���݌ɑS�̐ݒ�N���X</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�̓o�^�E�X�V���s���܂��B</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public int Write(ref StockTtlSt stockTtlSt)
        {
            /* --- DEL 2008/06/06 -------------------------------->>>>>
            //�N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
            StockTtlStWork stockttlsetWork = CopyToStockTtlStWorkFromStockTtlSt(stockttlset);

            // XML�֕ϊ����A������̃o�C�i����
            byte[] parabyte = XmlByteSerializer.Serialize(stockttlsetWork);
            //object objStockKtlStWork = (object)stockttlsetWork;

            int status = 0;
            try
            {
                //��������
                status = this._iStockTtlStDB.Write(ref parabyte);
                //status = this._iStockTtlStDB.Write(ref objStockKtlStWork);
                if (status == 0)
                {
                    // �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
                    stockttlsetWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockTtlStWork));
                    //ArrayList stockttlsetWorkList = new ArrayList();
                    //stockttlsetWorkList = (ArrayList) objStockKtlStWork;
                    //stockttlsetWork = (StockTtlStWork)stockttlsetWorkList[0];
                    // �N���X�������o�R�s�[
                    stockttlset = CopyToAutoliasetFromStockTtlStWork(stockttlsetWork);
                }
            }
            catch (Exception)
            {
                //�I�t���C������null���Z�b�g
                this._iStockTtlStDB = null;
                //�ʐM�G���[��-1��߂�
                status = -1;
            }
            return status;
               --- DEL 2008/06/06 --------------------------------<<<<< */

            int status = 0;

            try
            {
                // �d���݌ɑS�̐ݒ�N���X���d���݌ɑS�̐ݒ胏�[�N�N���X�փ����o�R�s�[
                StockTtlStWork stockTtlStWork = CopyToStockTtlStWorkFromStockTtlSt(stockTtlSt);

                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(stockTtlStWork);

                // �ۑ�
                //Object paraObj = (object)stockTtlStWork;
                //status = this._iStockTtlStDB.Write(ref paraObj);
                status = this._iStockTtlStDB.Write(ref parabyte);

                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    // �d���݌ɑS�̐ݒ胏�[�N�N���X���f�V���A���C�Y
                    stockTtlStWork = (StockTtlStWork)XmlByteSerializer.Deserialize(parabyte, typeof(StockTtlStWork));

                    // �d���݌ɑS�̐ݒ胏�[�N�N���X����d���݌ɑS�̐ݒ�N���X�փ����o�R�s�[
                    //ArrayList wklist = (ArrayList)paraObj;
                    //stockTtlStWork = wklist[0] as StockTtlStWork;
                    //stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);

                    stockTtlSt = CopyToStockTtlStFromStockTtlStWork(stockTtlStWork);
                }
                return status;
            }
            catch (Exception)
            {
                // �I�t���C������null���Z�b�g
                this._iStockTtlStDB = null;

                // �ʐM�G���[��-1��Ԃ�
                return -1;
            }
        }

        /// <summary>
        /// �d���݌ɑS�̐ݒ�V���A���C�Y����
        /// </summary>
        /// <param name="stockttlset">�V���A���C�Y�Ώێd���݌ɑS�̐ݒ�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public void Serialize(StockTtlSt stockttlset, string fileName)
        {
            //�N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
            StockTtlStWork stockttlWork = CopyToStockTtlStWorkFromStockTtlSt(stockttlset);
            //�]���[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(stockttlWork, fileName);
        }


        /// <summary>
        /// �d���݌ɑS�̐ݒ�List�V���A���C�Y����
        /// </summary>
        /// <param name="stockttlsetList">�V���A���C�Y�Ώێd���݌ɑS�̐ݒ�List�N���X</param>
        /// <param name="fileName">�V���A���C�Y�t�@�C����</param>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�List���̃V���A���C�Y���s���܂��B</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        public void ListSerialize(ArrayList stockttlsetList, string fileName)
        {
            StockTtlStWork[] stockttlsetWorks = new StockTtlStWork[stockttlsetList.Count];
            for (int i = 0; i < stockttlsetList.Count; i++)
            {
                stockttlsetWorks[i] = CopyToStockTtlStWorkFromStockTtlSt((StockTtlSt)stockttlsetList[i]);
            }
            //�d���݌ɑS�̐ݒ胏�[�J�[�N���X���V���A���C�Y
            XmlByteSerializer.Serialize(stockttlsetWorks, fileName);
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�d���݌ɑS�̐ݒ胏�[�N�N���X�ˎd���݌ɑS�̐ݒ�N���X�j
        /// </summary>
        /// <param name="stockTtlStWork">�d���݌ɑS�̐ݒ胏�[�N�N���X</param>
        /// <returns>�d���݌ɑS�̐ݒ�N���X</returns>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ胏�[�N�N���X����d���݌ɑS�̐ݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// <br>-------------------------------------------------------------------------------------------------</br>
        /// <br>Update Note: ���������u�d�����i�擾�P�ʋ敪�v�ǉ�</br>
        /// <br>Programmer : 30005 �،��@��</br>
        /// <br>Date       : 2007.06.12</br>
        /// </remarks>
        private StockTtlSt CopyToStockTtlStFromStockTtlStWork(StockTtlStWork stockTtlStWork)
        {
            StockTtlSt stockTtlSt = new StockTtlSt();

            //�t�@�C���w�b�_����
            stockTtlSt.CreateDateTime = stockTtlStWork.CreateDateTime;
            stockTtlSt.UpdateDateTime = stockTtlStWork.UpdateDateTime;
            stockTtlSt.EnterpriseCode = stockTtlStWork.EnterpriseCode;
            stockTtlSt.FileHeaderGuid = stockTtlStWork.FileHeaderGuid;
            stockTtlSt.UpdEmployeeCode = stockTtlStWork.UpdEmployeeCode;
            stockTtlSt.UpdAssemblyId1 = stockTtlStWork.UpdAssemblyId1;
            stockTtlSt.UpdAssemblyId2 = stockTtlStWork.UpdAssemblyId2;
            stockTtlSt.LogicalDeleteCode = stockTtlStWork.LogicalDeleteCode;

            /* --- DEL 2008/06/06 -------------------------------->>>>>
            //�f�[�^����
            stockTtlSt.StockAllStMngCd = stockTtlStWork.StockAllStMngCd;
            stockTtlSt.ValidDtConsTaxRate1 = stockTtlStWork.ValidDtConsTaxRate1;
            stockTtlSt.ConsTaxRate1 = stockTtlStWork.ConsTaxRate1;
            stockTtlSt.ValidDtConsTaxRate2 = stockTtlStWork.ValidDtConsTaxRate2;
            stockTtlSt.ConsTaxRate2 = stockTtlStWork.ConsTaxRate2;
            stockTtlSt.ValidDtConsTaxRate3 = stockTtlStWork.ValidDtConsTaxRate3;
            stockTtlSt.ConsTaxRate3 = stockTtlStWork.ConsTaxRate3;
               --- DEL 2008/06/06 --------------------------------<<<<< */
            
            //stockttlset.AutoEntryStockCd = stockttlsetWork.AutoEntryStockCd;
            //stockttlset.BeatStockCondCd = stockttlsetWork.BeatStockCondCd;
            stockTtlSt.StockDiscountName = stockTtlStWork.StockDiscountName;

            /* --- DEL 2008/06/06 -------------------------------->>>>>
            stockTtlSt.PartsUnitPrcZeroCd = stockTtlStWork.PartsUnitPrcZeroCd;
            // 2006.06.09 tsuchida add
            stockTtlSt.TotalAmountDispWayCd = stockTtlStWork.TotalAmountDispWayCd;
            stockTtlSt.SuppCTaxLayCd = stockTtlStWork.SuppCTaxLayCd;
               --- DEL 2008/06/06 --------------------------------<<<<< */

            //2007.12.18 TACHIBANA ADD >>>>>>>>>>>>>>>>>>>>>>						
            stockTtlSt.RgdsSlipPrtDiv = stockTtlStWork.RgdsSlipPrtDiv;
            stockTtlSt.RgdsUnPrcPrtDiv = stockTtlStWork.RgdsUnPrcPrtDiv;
            stockTtlSt.RgdsZeroPrtDiv = stockTtlStWork.RgdsZeroPrtDiv;

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //stockTtlSt.IoGoodsCntDiv = stockTtlStWork.IoGoodsCntDiv;
            //stockTtlSt.IoGoodsCntDiv2 = stockTtlStWork.IoGoodsCntDiv2;    // 2008.02.27 add
            //stockTtlSt.SupplierFormalIni = stockTtlStWork.SupplierFormalIni;
            //stockTtlSt.SalesSlipDtlConf = stockTtlStWork.SalesSlipDtlConf;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            stockTtlSt.ListPriceInpDiv = stockTtlStWork.ListPriceInpDiv;
            stockTtlSt.UnitPriceInpDiv = stockTtlStWork.UnitPriceInpDiv;
            stockTtlSt.DtlNoteDispDiv = stockTtlStWork.DtlNoteDispDiv;
			//2007.12.18 TACHIBANA ADD <<<<<<<<<<<<<<<<<<<<<<						

			//----- ueno add ---------- start 2008.02.18
            stockTtlSt.AutoPayMoneyKindCode = stockTtlStWork.AutoPayMoneyKindCode;
            stockTtlSt.AutoPayMoneyKindName = stockTtlStWork.AutoPayMoneyKindName;
            stockTtlSt.AutoPayMoneyKindDiv = stockTtlStWork.AutoPayMoneyKindDiv;
			//----- ueno add ---------- end 2008.02.18

            // --- ADD 2008/06/06 -------------------------------->>>>>
            stockTtlSt.SectionCode = stockTtlStWork.SectionCode;
            stockTtlSt.AutoPayment = stockTtlStWork.AutoPayment;
            stockTtlSt.PriceCostUpdtDiv = stockTtlStWork.PriceCostUpdtDiv;
            stockTtlSt.AutoEntryGoodsDivCd = stockTtlStWork.AutoEntryGoodsDivCd;
            stockTtlSt.PriceCheckDivCd = stockTtlStWork.PriceCheckDivCd;
            stockTtlSt.StockUnitChgDivCd = stockTtlStWork.StockUnitChgDivCd;
            stockTtlSt.SectDspDivCd = stockTtlStWork.SectDspDivCd;
            stockTtlSt.SlipDateClrDivCd = stockTtlStWork.SlipDateClrDivCd;
            stockTtlSt.PaySlipDateClrDiv = stockTtlStWork.PaySlipDateClrDiv;
            stockTtlSt.PaySlipDateAmbit = stockTtlStWork.PaySlipDateAmbit;
            // --- ADD 2008/06/06 --------------------------------<<<<< 
            // --- ADD 2008/09/12 -------------------------------->>>>>
            stockTtlSt.StockSearchDiv = stockTtlStWork.StockSearchDiv;
            // --- ADD 2008/09/12 --------------------------------<<<<<

            // 2009.04.02 30413 ���� ���ڒǉ� >>>>>>START
            stockTtlSt.GoodsNmReDispDivCd = stockTtlStWork.GoodsNmReDispDivCd;
            // 2009.04.02 30413 ���� ���ڒǉ� <<<<<<END
            
            return stockTtlSt;
        }

        /// <summary>
        /// �N���X�����o�[�R�s�[�����i�d���݌ɑS�̐ݒ�N���X�ˎd���݌ɑS�̐ݒ胏�[�N�N���X�j
        /// </summary>
        /// <param name="stockTtlSt">�d���݌ɑS�̃N���X</param>
        /// <returns>�d���݌ɑS�̃��[�N�N���X</returns>
        /// <remarks>
        /// <br>Note       : �d���݌ɑS�̐ݒ�N���X����d���݌ɑS�̐ݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// <br>-------------------------------------------------------------------------------------------------</br>
        /// <br>Update Note: ���������u�d�����i�擾�P�ʋ敪�v�ǉ�</br>
        /// <br>Programmer : 30005 �،��@��</br>
        /// <br>Date       : 2007.06.12</br>
        /// </remarks>
        private StockTtlStWork CopyToStockTtlStWorkFromStockTtlSt(StockTtlSt stockTtlSt)
        {
            StockTtlStWork stockTtlStWork = new StockTtlStWork();

            //�t�@�C���w�b�_����
            stockTtlStWork.CreateDateTime = stockTtlSt.CreateDateTime;
            stockTtlStWork.UpdateDateTime = stockTtlSt.UpdateDateTime;
            stockTtlStWork.EnterpriseCode = stockTtlSt.EnterpriseCode;
            stockTtlStWork.FileHeaderGuid = stockTtlSt.FileHeaderGuid;
            stockTtlStWork.UpdEmployeeCode = stockTtlSt.UpdEmployeeCode;
            stockTtlStWork.UpdAssemblyId1 = stockTtlSt.UpdAssemblyId1;
            stockTtlStWork.UpdAssemblyId2 = stockTtlSt.UpdAssemblyId2;
            stockTtlStWork.LogicalDeleteCode = stockTtlSt.LogicalDeleteCode;

            /* --- DEL 2008/06/06 -------------------------------->>>>>
            //�f�[�^����
            stockTtlStWork.StockAllStMngCd = stockTtlSt.StockAllStMngCd;
            stockTtlStWork.ValidDtConsTaxRate1 = stockTtlSt.ValidDtConsTaxRate1;
            stockTtlStWork.ConsTaxRate1 = stockTtlSt.ConsTaxRate1;
            stockTtlStWork.ValidDtConsTaxRate2 = stockTtlSt.ValidDtConsTaxRate2;
            stockTtlStWork.ConsTaxRate2 = stockTtlSt.ConsTaxRate2;
            stockTtlStWork.ValidDtConsTaxRate3 = stockTtlSt.ValidDtConsTaxRate3;
            stockTtlStWork.ConsTaxRate3 = stockTtlSt.ConsTaxRate3;
               --- DEL 2008/06/06 --------------------------------<<<<< */

            stockTtlStWork.StockDiscountName = stockTtlSt.StockDiscountName.TrimEnd();

            /* --- DEL 2008/06/06 -------------------------------->>>>>
            stockTtlStWork.PartsUnitPrcZeroCd = stockTtlSt.PartsUnitPrcZeroCd;
            stockTtlStWork.TotalAmountDispWayCd = stockTtlSt.TotalAmountDispWayCd;
            stockTtlStWork.SuppCTaxLayCd = stockTtlSt.SuppCTaxLayCd;
               --- DEL 2008/06/06 --------------------------------<<<<< */
            
            //2007.12.18 TACHIBANA ADD >>>>>>>>>>>>>>>>>>>>>>						
            stockTtlStWork.RgdsSlipPrtDiv = stockTtlSt.RgdsSlipPrtDiv;
            stockTtlStWork.RgdsUnPrcPrtDiv = stockTtlSt.RgdsUnPrcPrtDiv;
            stockTtlStWork.RgdsZeroPrtDiv = stockTtlSt.RgdsZeroPrtDiv;

            // --- DEL 2008/07/22 -------------------------------->>>>>
            //stockTtlStWork.IoGoodsCntDiv = stockTtlSt.IoGoodsCntDiv;
            //stockTtlStWork.IoGoodsCntDiv2 = stockTtlSt.IoGoodsCntDiv2;   // 2008.02.27 add
            //stockTtlStWork.SupplierFormalIni = stockTtlSt.SupplierFormalIni;
            //stockTtlStWork.SalesSlipDtlConf = stockTtlSt.SalesSlipDtlConf;
            // --- DEL 2008/07/22 --------------------------------<<<<< 

            stockTtlStWork.ListPriceInpDiv = stockTtlSt.ListPriceInpDiv;
            stockTtlStWork.UnitPriceInpDiv = stockTtlSt.UnitPriceInpDiv;
            stockTtlStWork.DtlNoteDispDiv = stockTtlSt.DtlNoteDispDiv;
			//2007.12.18 TACHIBANA ADD <<<<<<<<<<<<<<<<<<<<<<						

			//----- ueno add ---------- start 2008.02.18
            stockTtlStWork.AutoPayMoneyKindCode = stockTtlSt.AutoPayMoneyKindCode;
            stockTtlStWork.AutoPayMoneyKindName = stockTtlSt.AutoPayMoneyKindName;
            stockTtlStWork.AutoPayMoneyKindDiv = stockTtlSt.AutoPayMoneyKindDiv;
			//----- ueno add ---------- end 2008.02.18

            // --- ADD 2008/06/06 -------------------------------->>>>>
            stockTtlStWork.SectionCode = stockTtlSt.SectionCode;         
            stockTtlStWork.AutoPayment = stockTtlSt.AutoPayment;         
            stockTtlStWork.PriceCostUpdtDiv = stockTtlSt.PriceCostUpdtDiv;   
            stockTtlStWork.AutoEntryGoodsDivCd = stockTtlSt.AutoEntryGoodsDivCd; 
            stockTtlStWork.PriceCheckDivCd = stockTtlSt.PriceCheckDivCd;     
            stockTtlStWork.StockUnitChgDivCd = stockTtlSt.StockUnitChgDivCd;   
            stockTtlStWork.SectDspDivCd = stockTtlSt.SectDspDivCd;        
            stockTtlStWork.SlipDateClrDivCd = stockTtlSt.SlipDateClrDivCd;    
            stockTtlStWork.PaySlipDateClrDiv = stockTtlSt.PaySlipDateClrDiv;
            stockTtlStWork.PaySlipDateAmbit = stockTtlSt.PaySlipDateAmbit;    
            // --- ADD 2008/06/06 --------------------------------<<<<< 

            // --- ADD 2008/09/12 -------------------------------->>>>>
            stockTtlStWork.StockSearchDiv = stockTtlSt.StockSearchDiv;
            // --- ADD 2008/09/12 --------------------------------<<<<<

            // 2009.04.02 30413 ���� ���ڒǉ� >>>>>>START
            stockTtlStWork.GoodsNmReDispDivCd = stockTtlSt.GoodsNmReDispDivCd;
            // 2009.04.02 30413 ���� ���ڒǉ� <<<<<<END

            return stockTtlStWork;
        }


        /// <summary>
        /// �Ώۃf�[�^�`�F�b�N
        /// </summary>
        /// <param name="stockttlset">�Ώۃf�[�^</param>
        /// <param name="stockttlsetPara">�p�����[�^</param>
        /// <returns>�`�F�b�N���ʁitrue:OK false:NG�j</returns>
        /// <remarks>
        /// <br>Note       : �Ώۃf�[�^�ƃp�����[�^���r���܂��B</br>
        /// <br>Programmer : 19018 Y.Gamoto</br>
        /// <br>Date       : 2005.04.12</br>
        /// </remarks>
        private bool checkTarGetData(StockTtlSt stockttlset, StockTtlSt stockttlsetPara)
        {
            // ��ƃR�[�h���r
            if (stockttlsetPara.EnterpriseCode != null)
            {
                if (!stockttlsetPara.EnterpriseCode.Equals(stockttlset.EnterpriseCode))
                    return false;
            }
            return true;
        }

    }
}
