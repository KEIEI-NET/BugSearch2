using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using Broadleaf.Library.Resources;
using Broadleaf.Library.Globarization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.UIData;
// TODO : ��SFCMN00201u SFCMN00212i �̎Q�Ƃ�ǉ�
using System.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.LocalAccess;


namespace Broadleaf.Application.Controller
{
	/// <summary>
	/// ���z��ʐݒ�e�[�u���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : ���z��ʐݒ�e�[�u���̃A�N�Z�X������s���܂��B</br>
	/// <br>Programmer : 97134 ���� �딎</br>
	/// <br>Date       : 2005.06.24</br>
	/// <br></br>
	/// <br>UpdateNote : 2005.06.08 �}�X�����`�[���쐬���K�C�h�R�����g�A�E�g</br>
	/// <br>		   : 22033 �O��  �M�j </br>
	/// <br>UpdateNode : 2005.06.13 �����K�C�h�Ή� </br>
	/// <br>           : 99032 �ɓ� ���I</br>
	/// <br>Update Note: 2005.12.17 23003 �|�c�@�܂���</br>
    /// <br>		   :        �E���[�U���̂ݓǍ��E�ҏW����悤�C��</br>	
    /// <br>Update Note: 2006.12.26 22022 �i�� �m�q</br>
    /// <br>					1.SF�ł𗬗p���g�єł��쐬</br>
    /// <br>UpdateNote : 2007.04.04 980023�@�ђJ �k��</br>
    /// <br>                    Read�A�K�C�h��Search �̏��������[�J��DB����̓Ǎ��ɕύX</br>
    /// <br>UpdateNote : 2007.05.07 980023�@�ђJ �k��</br>
    /// <br>                    �K�C�h��Search�̏������A�����w��Ń����[�g�Ǎ��ɂł���悤�ύX</br>
    /// <br>Update Note: 2007.05.17 20031 �É�@���S��</br>
    /// <br>					���ڒǉ�</br>
    /// <br>Update Note: 2007.05.20 980023 �ђJ �k��</br>
    /// <br>					�K�C�hXML���w�莞�̃f�t�H���g��ݒ�</br>
    /// <br>Update Note: 2007.07.04 20031 �É�@���S��</br>
    /// <br>					Read�����������[�gDB�Ǎ����ł���悤�ɕύX</br>
    /// <br>Update Note: 2008.02.08 96012 ���F�@�]</br>
    /// <br>					DC.NS�Ή�(�ʏ�̓����[�gDB�Ǎ��ɕύX)</br>
    /// <br>Programmer : 2008/06/12 30415 �ēc �ύK</br>
    /// <br>                    ���ڍ폜�ׁ̈A�C��</br>
    /// </remarks>

	public class MoneyKindAcs : IGeneralGuideData
	{      
        
		/// <summary>�����[�g�I�u�W�F�N�g�i�[�o�b�t�@</summary>
		private IMoneyKindDB _iMoneyKindDB = null;

        /// <summary>���[�J��DB�I�u�W�F�N�g�i�[�o�b�t�@</summary>
        private MoneyKindLcDB _moneyKindLcDB = null;  // iitani a

        /// <summary>�K�C�h�p�f�[�^�o�b�t�@</summary>
		private static ArrayList _guidBuff_MoneyKind;
		// 2005.12.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
		/// <summary>�_���폜�p�f�[�^�o�b�t�@</summary>
		private static ArrayList _Logical_guidBuff_MoneyKind = null;
		// 2005.12.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

        private const string GUIDE_SEARCHMODE_PARA = "SearchMode";                     // �K�C�h�f�[�^�T�[�`���[�h(0:���[�J��,1:�����[�g) iitani a 2007.05.07

        /// <summary>���[�J���c�a���[�h</summary>
        // 2008.02.08 96012 DC.NS�Ή�(�ʏ�̓����[�gDB�Ǎ��ɕύX) Begin
        //private static bool _isLocalDBRead = true;
        private static bool _isLocalDBRead = false;
        // 2008.02.08 96012 DC.NS�Ή�(�ʏ�̓����[�gDB�Ǎ��ɕύX) end

		/// <summary>
		/// ���z��ʐݒ�e�[�u���A�N�Z�X�N���X�R���X�g���N�^
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�e�[�u���A�N�Z�X�N���X�̐V�����C���X�^���X�����������܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public MoneyKindAcs()
		{
			try
			{
				// �����[�g�I�u�W�F�N�g�擾
				this._iMoneyKindDB = (IMoneyKindDB)MediationMoneyKindDB.GetMoneyKindDB();
			}
			catch (Exception)
			{				
				//�I�t���C������null���Z�b�g
				this._iMoneyKindDB = null;
			}

            // ���[�J��DB�A�N�Z�X�I�u�W�F�N�g�擾
            this._moneyKindLcDB = new MoneyKindLcDB();   // iitani a

            _guidBuff_MoneyKind = new ArrayList();
        }

		/// <summary>�I�����C�����[�h�̗񋓌^�ł��B</summary>
		public enum OnlineMode 
		{
			/// <summary>�I�t���C��</summary>
			Offline,
			/// <summary>�I�����C��</summary>
			Online 
		}
        //================================================================================
        //  �v���p�e�B
        //================================================================================
        #region Public Property

        /// <summary>
        /// ���[�J���c�aRead���[�h
        /// </summary>
        public bool IsLocalDBRead
        {
            get { return _isLocalDBRead; }
            set { _isLocalDBRead = value; }
        }

        #endregion

		/// <summary>
		/// �I�����C�����[�h�擾����
		/// </summary>
		/// <returns>OnlineMode</returns>
		/// <remarks>
		/// <br>Note       : �I�����C�����[�h���擾���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int GetOnlineMode()
		{
			if (this._iMoneyKindDB == null)
			{
				return (int)OnlineMode.Offline;
			}
			else
			{
				return (int)OnlineMode.Online;
			}
		}

		/// <summary>
		/// ���z��ʐݒ�ǂݍ��ݏ���
		/// </summary>
		/// <param name="moneykind">���z��ʐݒ�I�u�W�F�N�g</param>
		/// <returns>���z��ʐݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ��ǂݍ��݂܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int Read(ref MoneyKind moneykind)
		{	

			/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
			GetMoneyKindDataType datatype;
			if(dttype == 0) datatype = GetMoneyKindDataType.OfferMoneyKindData;  //���ް��Ǎ���
			else            datatype = GetMoneyKindDataType.UserMoneyKindData;   //հ���ް��Ǎ��� 
			2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */
            
			try
			{
               
				//�ǂݍ��ވׂɃL�[�ƂȂ鍀�ڂ��Z�b�g
				MoneyKindWork moneykindWork     = new MoneyKindWork();
				moneykindWork.EnterpriseCode = moneykind.EnterpriseCode;
				moneykindWork.PriceStCode    = moneykind.PriceStCode;
				moneykindWork.MoneyKindCode  = moneykind.MoneyKindCode;
				moneykind = null;

                // XML�֕ϊ����A������̃o�C�i���� iitani d
                //byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);

				/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
				int status = this._iMoneyKindDB.Read(ref parabyte     //�޲���ް�
													  ,0               //���ݖ��g�p
													  ,datatype );     //��or���[�U
				2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */

				// 2005.12.17 enokida ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
                //int status = this._iMoneyKindDB.Read(ref parabyte     //�޲���ް�
                //    ,0               //���ݖ��g�p
                //    ,GetMoneyKindDataType.UserMoneyKindData );     //���[�U
                // ���[�J��DB�A�N�Z�X iitani c
                int status = 0;
                if (_isLocalDBRead)
                {
                    // ���[�J��
                    status = this._moneyKindLcDB.Read(ref moneykindWork, 0, Broadleaf.Application.LocalAccess.MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);     //���[�U
                }
                else
                {
                    byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
                    // �����[�g
                    status = this._iMoneyKindDB.Read(ref parabyte     //�޲���ް�
                        ,0               //���ݖ��g�p
                        ,GetMoneyKindDataType.UserMoneyKindData );     //���[�U
                    // 2007.07.04  S.Koga  ADD --------------------------------
                    if(status == 0)
                        moneykindWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte, typeof(MoneyKindWork));
                    // --------------------------------------------------------
                }

				// 2005.12.17 enokida ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end

				if (status == 0)
				{
                    // XML�̓ǂݍ��� iitani d
                    //moneykindWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte, typeof(MoneyKindWork));
					// �N���X�������o�R�s�[
					moneykind = CopyToMoneyKindFromMoneyKindWork(moneykindWork);
				}

				return status;
			}
			catch (Exception)
			{				
				//�ʐM�G���[��-1��߂�
				moneykind = null;
				//�I�t���C������null���Z�b�g
				this._iMoneyKindDB = null;

				return -1;
			}            
		}

        /// <summary>
		/// ���z��ʐݒ�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���z��ʐݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        public MoneyKind Deserialize(string fileName)
        {
            MoneyKind moneykind = null;
            // �t�@�C������n���ăv�����^�Ǘ����[�N�N���X���f�V���A���C�Y����
            moneykind = (MoneyKind)XmlByteSerializer.Deserialize(fileName, typeof(MoneyKind));

            // �t�@�C������n���ċ��z��ʐݒ胏�[�N�N���X���f�V���A���C�Y����
            MoneyKindWork MoneyKindWork = (MoneyKindWork)XmlByteSerializer.Deserialize(fileName, typeof(MoneyKindWork));

            //�f�V���A���C�Y���ʂ����z��ʐݒ�N���X�փR�s�[
            if (MoneyKindWork != null) moneykind = CopyToMoneyKindFromMoneyKindWork(MoneyKindWork);

            return moneykind;
        }

		/// <summary>
		/// ���z��ʐݒ�List�N���X�f�V���A���C�Y����
		/// </summary>
		/// <param name="fileName">�f�V���A���C�Y�Ώ�XML�t�@�C���t���p�X</param>
		/// <returns>���z��ʐݒ�N���XLIST</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ胊�X�g�N���X���f�V���A���C�Y���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public ArrayList ListDeserialize(string fileName)
		{
			ArrayList al = new ArrayList();
			// �t�@�C������n���ċ��z��ʐݒ胏�[�N�N���X���f�V���A���C�Y����
			MoneyKindWork[] MoneyKindWorks = (MoneyKindWork[])XmlByteSerializer.Deserialize(fileName,typeof(MoneyKindWork[]));

			//�f�V���A���C�Y���ʂ����z��ʐݒ�N���X�փR�s�[
			if (MoneyKindWorks != null) 
			{
				al.Capacity = MoneyKindWorks.Length;
				for(int i=0; i < MoneyKindWorks.Length; i++)
				{
					al.Add(CopyToMoneyKindFromMoneyKindWork(MoneyKindWorks[i]));
				}
			}
			return al;

		}

		/// <summary>
		/// ���z��ʐݒ�o�^�E�X�V����
		/// </summary>
		/// <param name="moneykind">���z��ʐݒ�N���X</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�̓o�^�E�X�V���s���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int Write(ref MoneyKind moneykind)
		{
			// �N���X���烏�[�J�[�N���X�Ƀ����o�R�s�[
			MoneyKindWork moneykindWork = CopyToMoneyKindWorkFromMoneyKind(moneykind);

			// XML�֕ϊ����A������̃o�C�i����
			byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);

			
			int status = 0;
			try
			{
				//				// XML�̏������݁i�V���A���C�Y�����j
				//				this.MoneyKindSerialize(moneykind, this.fileName);
				//��������
				//  �����݂��s����̂̓��[�U�[�f�[�^�̂�
				status = this._iMoneyKindDB.Write(ref parabyte, GetMoneyKindDataType.UserMoneyKindData);
				if ( status == 0 )
				{
					// �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
					moneykindWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte, typeof(MoneyKindWork) );
					// �N���X�������o�R�s�[
					moneykind = CopyToMoneyKindFromMoneyKindWork(moneykindWork);

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.02 TAKAHASHI ADD START
					if(_guidBuff_MoneyKind != null)
					{
						SortedList sortList = new SortedList();
						
						//���ɃL���b�V��������΍폜
                        foreach (MoneyKind moneyKindwk in _guidBuff_MoneyKind)
                        {
                            if (moneyKindwk.PriceStCode == moneykind.PriceStCode)
                            {
                                if (moneyKindwk.MoneyKindCode == moneykind.MoneyKindCode)
                                {
                                    _guidBuff_MoneyKind.Remove(moneyKindwk);
                                    break;
                                }
                            }
                        }

						//�L���b�V���ɍ���Write����ǉ�				
						_guidBuff_MoneyKind.Add(moneykind);
						
					}
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.02 TAKAHASHI ADD END
					// 2005.12.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if(_Logical_guidBuff_MoneyKind != null)
					{
						SortedList sortList = new SortedList();

                        foreach (MoneyKind moneyKindwks in _Logical_guidBuff_MoneyKind)
                        {
							if((moneyKindwks.PriceStCode == moneykind.PriceStCode)&&
								(moneyKindwks.MoneyKindCode == moneykind.MoneyKindCode))
							{
								_Logical_guidBuff_MoneyKind.Remove(moneyKindwks);
								break;
							}
						}
						// �L���b�V���ɒǉ�
						_Logical_guidBuff_MoneyKind.Add(moneykind);
					}
					// 2005.12.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
				}
			}
			catch (Exception)
			{
				// �I�t���C������null���Z�b�g
				this._iMoneyKindDB = null;
				
				// �ʐM�G���[��-1��߂�
				status = -1;
			}
			return status;
		}

		/// <summary>
		/// ���z��ʐݒ�V���A���C�Y����
		/// </summary>
		/// <param name="moneykind">�V���A���C�Y�Ώۋ��z��ʐݒ�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
        public void Serialize(MoneyKind moneykind,string fileName)
		{
			//			//�v�����^�Ǘ����[�J�[�N���X���V���A���C�Y
			//			XmlByteSerializer.Serialize(moneykind,fileName);

			//���z��ʐݒ�N���X������z��ʐݒ胏�[�J�[�N���X�Ƀ����o�R�s�[
			MoneyKindWork MoneyKindWork = CopyToMoneyKindWorkFromMoneyKind(moneykind);
			//���z��ʃ��[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(MoneyKindWork,fileName);

		}

		/// <summary>
		/// ���z��ʐݒ�List�V���A���C�Y����
		/// </summary>
		/// <param name="moneykindList">�V���A���C�Y�Ώۋ��z��ʐݒ�List�N���X</param>
		/// <param name="fileName">�V���A���C�Y�t�@�C����</param>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�List���̃V���A���C�Y���s���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public void ListSerialize(ArrayList moneykindList,string fileName)
		{
			//			// ArrayList����z��𐶐�
			//			MoneyKind[] moneykinds = (MoneyKind[])moneykindList.ToArray(typeof(MoneyKind));
			//			// �v�����^�Ǘ����[�J�[�N���X���V���A���C�Y
			//			XmlByteSerializer.Serialize(moneykinds,fileName);

			MoneyKindWork[] MoneyKindWorks = new MoneyKindWork[moneykindList.Count];
			for(int i= 0; i < moneykindList.Count; i++)
			{
				MoneyKindWorks[i] = CopyToMoneyKindWorkFromMoneyKind((MoneyKind)moneykindList[i]);
			}
			//���z��ʐݒ胏�[�J�[�N���X���V���A���C�Y
			XmlByteSerializer.Serialize(MoneyKindWorks,fileName);

		}

		/// <summary>
		/// ���z��ʐݒ�_���폜����
		/// </summary>
		/// <param name="moneykind">���z��ʐݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�̘_���폜���s���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int LogicalDelete(ref MoneyKind moneykind)
		{
			try
			{
				MoneyKindWork moneykindWork = CopyToMoneyKindWorkFromMoneyKind(moneykind);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
				// �_���폜
				int status = this._iMoneyKindDB.LogicalDelete(ref parabyte, GetMoneyKindDataType.UserMoneyKindData);

				if (status == 0)
				{
					// �t�@�C������n���ă��[�N�N���X���f�V���A���C�Y����
					moneykindWork = (MoneyKindWork)XmlByteSerializer.Deserialize( parabyte, typeof(MoneyKindWork));
					// �N���X�������o�R�s�[
					moneykind = CopyToMoneyKindFromMoneyKindWork(moneykindWork);

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.02 TAKAHASHI ADD START
					if(_guidBuff_MoneyKind != null)
					{
						foreach (MoneyKind moneyKindwk in _guidBuff_MoneyKind)
						{
							if (moneyKindwk.PriceStCode == moneykind.PriceStCode)
							{
								if (moneyKindwk.MoneyKindCode == moneykind.MoneyKindCode)
								{
									_guidBuff_MoneyKind.Remove(moneyKindwk);
									break;
								}
							}
						}		
					}
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.02 TAKAHASHI ADD END
					// 2005.12.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if(_Logical_guidBuff_MoneyKind != null)
					{
                        foreach (MoneyKind moneyKindwks in _Logical_guidBuff_MoneyKind)
						{
							if ((moneyKindwks.PriceStCode == moneykind.PriceStCode)&&
								 (moneyKindwks.MoneyKindCode == moneykind.MoneyKindCode))
							{
								_Logical_guidBuff_MoneyKind.Remove(moneyKindwks);
								_Logical_guidBuff_MoneyKind.Add(moneykind);
								break;
							}
						}		
					}
					// 2005.12.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
					
				}

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iMoneyKindDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// ���z��ʐݒ蕨���폜����
		/// </summary>
		/// <param name="moneykind">���z��ʐݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�̕����폜���s���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int Delete(MoneyKind moneykind)
		{
			try
			{
				MoneyKindWork moneykindWork = CopyToMoneyKindWorkFromMoneyKind(moneykind);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
				// ���[�U�[�o�^�������폜
				int status = this._iMoneyKindDB.Delete(parabyte, GetMoneyKindDataType.UserMoneyKindData);
				// 2005.12.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
				if(status == 0)
				{
					if(_Logical_guidBuff_MoneyKind != null)
					{
                        foreach(MoneyKind moneyKindwk in  _Logical_guidBuff_MoneyKind)
						{
							if((moneyKindwk.PriceStCode == moneykindWork.PriceStCode)&&
								(moneyKindwk.MoneyKindCode == moneykindWork.MoneyKindCode))
							{
								_Logical_guidBuff_MoneyKind.Remove(moneyKindwk);
								break;
							}
						}
					}
				}
				// 2005.12.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				
				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iMoneyKindDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// ���z��ʐݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ茟���������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int GetCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,0);
		}

		/// <summary>
		/// ���z��ʐݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>�擾����</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ茟���������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int GetAllCnt(out int retTotalCnt,string enterpriseCode)
		{
			return GetCntProc(out retTotalCnt,enterpriseCode,ConstantManagement.LogicalMode.GetData01);
		}

		/// <summary>
		/// ���z��ʐݒ萔��������
		/// </summary>
		/// <param name="retTotalCnt">�f�[�^����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�ް��̂� 1:�폜�ް��̂� 2:�S�ް�)</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ萔�̌������s���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private int GetCntProc(out int retTotalCnt,string enterpriseCode,ConstantManagement.LogicalMode logicalMode)
		{
			MoneyKindWork moneykindWork = new MoneyKindWork();
			moneykindWork.EnterpriseCode = enterpriseCode;
			int sumTotalCnt = 0;
			
            //K.HIIRO
			//// XML�֕ϊ����A������̃o�C�i����
			//byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
            //
			////����
            //
			///* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
			////  �񋟕����擾
			//int status = this._iMoneyKindDB.SearchCnt(out sumTotalCnt, 
			//										   parabyte, 
			//										   0,                               //�����敪 ���g�p
			//										   logicalMode,                     //�_���폜�L��
			//										   GetMoneyKindDataType.OfferMoneyKindData); //�擾�Ώۃf�[�^
			//if ( status != 0 ){
			//	sumTotalCnt = 0;
			//}
			//2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */
            //
			//retTotalCnt = sumTotalCnt;
            //
			////  ���[�U�o�^�����擾
			//int status =     this._iMoneyKindDB.SearchCnt(out sumTotalCnt, 
			//	parabyte, 
			//	0,                               //�����敪  ���g�p
			//	logicalMode,                     //�_���폜�L��
			//	GetMoneyKindDataType.UserMoneyKindData); //�擾�Ώۃf�[�^
			//if ( status != 0 )
			//{
			//	sumTotalCnt = 0;
			//}
            int status;
            retTotalCnt = sumTotalCnt;
            //  ���[�U�o�^�����擾
            if (_isLocalDBRead)
            {
                status = this._moneyKindLcDB.SearchCnt(out retTotalCnt,
                    moneykindWork,
                    0,
                    logicalMode,
                    MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);
            }
            else
            {
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
                status = this._iMoneyKindDB.SearchCnt(out sumTotalCnt,
                    parabyte,
                    0,                               //�����敪  ���g�p
                    logicalMode,                     //�_���폜�L��
                    GetMoneyKindDataType.UserMoneyKindData); //�擾�Ώۃf�[�^
            }
            if (status != 0)
            {
                sumTotalCnt = 0;
            }
            //K.HIIRO

			retTotalCnt += sumTotalCnt;

			return status;
		}


		/// <summary>
		/// ���z��ʐݒ�S���������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�̑S�����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int Search(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int  retTotalCnt;
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,0,null);			
		}

		/// <summary>
		/// ���z��ʐݒ茟�������i�_���폜�܂ށj
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>		
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�̑S�����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int SearchAll(out ArrayList retList,string enterpriseCode)
		{
			bool nextData;
			int	 retTotalCnt;
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData01,0,null);
		}

		/// <summary>
		/// �����w����z��ʐݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevMoneyKind">�O��ŏI���z��ʐݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ċ��z��ʐݒ�̌����������s���܂��B�_���폜�f�[�^�͒��o�ΏۊO�ƂȂ�܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int SearchSpecification(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,MoneyKind prevMoneyKind)
		{			
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,0,readCnt,prevMoneyKind);			
		}

		/// <summary>
		/// �����w����z��ʐݒ茟�������i�_���폜�����j
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevMoneyKind��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="readCnt">�Ǎ�����</param>		
		/// <param name="prevMoneyKind">�O��ŏI���z��ʐݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>			
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �������w�肵�ċ��z��ʐݒ�̌����������s���܂��B�_���폜�f�[�^�����o�ΏۂƂȂ�܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int SearchSpecificationAll(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,int readCnt,MoneyKind prevMoneyKind)
		{			
			return SearchProc(out retList,out retTotalCnt,out nextData,enterpriseCode,ConstantManagement.LogicalMode.GetData0,readCnt,prevMoneyKind);

			
		}

		/// <summary>
		/// ���z��ʐݒ�_���폜��������
		/// </summary>
		/// <param name="moneykind">���z��ʐݒ�I�u�W�F�N�g</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�̕������s���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int Revival(ref MoneyKind moneykind)
		{
			try
			{
				MoneyKindWork MoneyKindWork = CopyToMoneyKindWorkFromMoneyKind(moneykind);
				// XML�֕ϊ����A������̃o�C�i����
				byte[] parabyte = XmlByteSerializer.Serialize(MoneyKindWork);
				// ���[�U�[�o�^����������
				int status = this._iMoneyKindDB.RevivalLogicalDelete(ref parabyte, GetMoneyKindDataType.UserMoneyKindData);

				if (status == 0)
				{
					// �t�@�C������n���ď]�ƈ����[�N�N���X���f�V���A���C�Y����
					MoneyKindWork = (MoneyKindWork)XmlByteSerializer.Deserialize(parabyte, typeof(MoneyKindWork));
					// �N���X�������o�R�s�[
					moneykind = CopyToMoneyKindFromMoneyKindWork(MoneyKindWork);

					// >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> 2005.11.02 TAKAHASHI ADD START
					if(_guidBuff_MoneyKind != null)
					{
						SortedList sortList = new SortedList();
						_guidBuff_MoneyKind.Add(moneykind);

                        foreach (MoneyKind moneyKinds in _guidBuff_MoneyKind)
						{
							string keyOfList = moneyKinds.PriceStCode + "," + moneyKinds.MoneyKindCode;
							sortList.Add(keyOfList, moneyKinds);
						}

						_guidBuff_MoneyKind.Clear();
						_guidBuff_MoneyKind.AddRange(sortList.Values);
					}
					// <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< 2005.11.02 TAKAHASHI ADD END
					// 2005.12.20 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
					if(_Logical_guidBuff_MoneyKind != null)
					{
                        foreach (MoneyKind moneyKindwks in _Logical_guidBuff_MoneyKind)
						{
							if ((moneyKindwks.PriceStCode == moneykind.PriceStCode)&&
								(moneyKindwks.MoneyKindCode == moneykind.MoneyKindCode))
							{
								_Logical_guidBuff_MoneyKind.Remove(moneyKindwks);
								_Logical_guidBuff_MoneyKind.Add(moneykind);
								break;
							}
						}		
					}
					// 2005.12.20 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				
				}

				return status;
			}
			catch (Exception)
			{
				//�I�t���C������null���Z�b�g
				this._iMoneyKindDB = null;
				//�ʐM�G���[��-1��߂�
				return -1;
			}
		}

		/// <summary>
		/// ���z��ʐݒ茟������
		/// </summary>
		/// <param name="retList">�Ǎ����ʃR���N�V����</param>
		/// <param name="retTotalCnt">�Ǎ��Ώۃf�[�^������(prevEmployee��null�̏ꍇ�̂ݖ߂�)</param>
		/// <param name="nextData">���f�[�^�L��</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="logicalMode">�_���폜�L��(0:���K�f�[�^�̂� 1:�폜�f�[�^�̂� 2:�S�f�[�^)</param>
		/// <param name="readCnt">�Ǎ�����</param>
		/// <param name="prevMoneyKind">�O��ŏI���z��ʐݒ�f�[�^�I�u�W�F�N�g�i�����null�w��K�{�j</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�̌����������s���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private int SearchProc(out ArrayList retList,out int retTotalCnt,out bool nextData,string enterpriseCode,ConstantManagement.LogicalMode logicalMode,int readCnt,MoneyKind prevMoneyKind)
		{

			nextData = false;	    // ���f�[�^�L��������
			retTotalCnt     = 0;    // 0�ŏ�����
			int totalCnt    = 0;
			//            int totalCntUsr = 0;

			//			MoneyKindWork[] mnkindWkAly;
			MoneyKindWork[] mnkindUsrWkAly;

			retList = new ArrayList();
			retList.Clear();

			//���o�������ڗp�ɃN���X���쐬���A���o�����Z�b�g
			MoneyKindWork moneykindWork = new MoneyKindWork();
			moneykindWork.EnterpriseCode = enterpriseCode;

            // 2008.12.01 Del >>>
            ////���o�����ݒ�p�N���X��XML�֕ϊ����A������̃o�C�i����
            //byte[] parabyte    = XmlByteSerializer.Serialize(moneykindWork);    
            //byte[] parabyteUsr = XmlByteSerializer.Serialize(moneykindWork);
            // 2008.12.01 Del <<<

			//���o���ʎ󂯑��p�o�C�i��
			//            byte[] retbyte;
			byte[] retbyteUsr;
           

			if ( prevMoneyKind != null )
			{
				moneykindWork = CopyToMoneyKindWorkFromMoneyKind(prevMoneyKind);
			}
			moneykindWork.EnterpriseCode = enterpriseCode;

			#region 2005.12.17 enokida DEL
			/* 2005.12.17 enokida DEL >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
						// ---------------- //
						// �f�[�^�擾
						// ---------------- //
						int status = 0;
						int status_o = 0;
						int status_u = 0;
						if (readCnt == 0){
							//�S���Ǎ�
							status_u = this._iMoneyKindDB.Search( out retbyteUsr,  parabyteUsr, 0, logicalMode, GetMoneyKindDataType.UserMoneyKindData);
							status_o = this._iMoneyKindDB.Search( out retbyte,     parabyte,    0, logicalMode, GetMoneyKindDataType.OfferMoneyKindData);
						}else{
							status_u = this._iMoneyKindDB.SearchSpecification( out retbyteUsr, out totalCnt,    out nextData, parabyteUsr, 0, logicalMode, readCnt,GetMoneyKindDataType.UserMoneyKindData  );
							status_o = this._iMoneyKindDB.SearchSpecification( out retbyte,    out totalCntUsr, out nextData, parabyte,    0, logicalMode, readCnt,GetMoneyKindDataType.OfferMoneyKindData );
							retTotalCnt = totalCntUsr + totalCnt;
						}

						// ---------------- //
						// XML�̓ǂݍ���
						// ---------------- //
						if( ( status_o == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) || 
							( status_o == ( int )ConstantManagement.DB_Status.ctDB_EOF ) ) {
							// ----- �񋟃f�[�^�擾 ----- //
							mnkindWkAly = (MoneyKindWork[])XmlByteSerializer.Deserialize(retbyte,     typeof(MoneyKindWork[]));
							for ( int i = 0; i < mnkindWkAly.Length; i++ )
							{					
								MoneyKindWork wkMoneyKindWork = (MoneyKindWork)mnkindWkAly[i];      // �T�[�`���ʎ擾
								retList.Add( CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // �L�^��Ǘ��N���X�փ����o�R�s�[
							}
						}
						else {
							return status_o;
						}

						if( ( status_u == ( int )ConstantManagement.DB_Status.ctDB_NORMAL ) || 
							( status_u == ( int )ConstantManagement.DB_Status.ctDB_EOF ) ) {
							// ----- ���[�U�[�f�[�^�擾 ----- //                
							mnkindUsrWkAly = (MoneyKindWork[])XmlByteSerializer.Deserialize(retbyteUsr, typeof(MoneyKindWork[]));
							for ( int i = 0; i < mnkindUsrWkAly.Length; i++ )
							{
								MoneyKindWork wkMoneyKindWork = (MoneyKindWork)mnkindUsrWkAly[i];   // �T�[�`���ʎ擾
								retList.Add( CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // �L�^��Ǘ��N���X�փ����o�R�s�[
							}
						}
						else {
							return status_u;
						}

						// �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
						if ( readCnt == 0 )
						{
							retTotalCnt = retList.Count;
						}
			
						//���X�g��������ёւ�����
						IMnyKindComp imnykindcmp = new IMnyKindComp();
						retList.Sort(imnykindcmp);

						// STATUS��ݒ�
						if( ( status_o == ( int )ConstantManagement.DB_Status.ctDB_EOF ) && 
							( status_u == ( int )ConstantManagement.DB_Status.ctDB_EOF ) && 
							( retList.Count == 0 ) ) {
							status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
						}
						else {
							status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
						}

						return status;
			 2005.12.17 enokida DEL <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end */
			#endregion

			// 2005.12.17 enokida ADD >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> start
			int status = 0;
            //K.HIIRO
            //if (readCnt == 0)
            //{
            //    //�S���Ǎ�
            //    status = this._iMoneyKindDB.Search( out retbyteUsr,  parabyteUsr, 0, logicalMode, GetMoneyKindDataType.UserMoneyKindData);
            //}
            //else
            //{
            //    status = this._iMoneyKindDB.SearchSpecification(out retbyteUsr, out totalCnt, out nextData, parabyteUsr, 0, logicalMode, readCnt, GetMoneyKindDataType.UserMoneyKindData);
            //    retTotalCnt = totalCnt;
            //}
            //// ---------------- //
            //// XML�̓ǂݍ���
            //// ---------------- //
            //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
            //    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
            //{
            //    // ----- ���[�U�[�f�[�^�擾 ----- //                
            //    mnkindUsrWkAly = (MoneyKindWork[])XmlByteSerializer.Deserialize(retbyteUsr, typeof(MoneyKindWork[]));
            //    for ( int i = 0; i < mnkindUsrWkAly.Length; i++ )
            //    {
            //    	MoneyKindWork wkMoneyKindWork = (MoneyKindWork)mnkindUsrWkAly[i];   // �T�[�`���ʎ擾
            //    	retList.Add( CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // �L�^��Ǘ��N���X�փ����o�R�s�[
            //    }
            //}
            //else
            //{
            //    return status;
            //}
            if (_isLocalDBRead)
            {
                List<MoneyKindWork> workList = new List<MoneyKindWork>();
                if (readCnt == 0)
                {
                    //�S���Ǎ�
                    status = this._moneyKindLcDB.Search(out workList, moneykindWork, 0, logicalMode, MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);
                }
                else
                {
                    status = this._moneyKindLcDB.SearchSpecification(out workList, out totalCnt, out nextData, moneykindWork, 0, logicalMode, readCnt, MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);
                    retTotalCnt = totalCnt;
                }
                if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                {
                    // ----- ���[�U�[�f�[�^�擾 ----- //                
                    for (int i = 0; i < workList.Count; ++i)
                    {
                        retList.Add(CopyToMoneyKindFromMoneyKindWork(workList[i]));    // �L�^��Ǘ��N���X�փ����o�R�s�[
                    }
                }
                else
                {
                    return status;
                }
            }
            else
            {
                // 2008.12.01 Update >>>
                //if (readCnt == 0)
                //{
                //    //�S���Ǎ�
                //    status = this._iMoneyKindDB.Search( out retbyteUsr,  parabyteUsr, 0, logicalMode, GetMoneyKindDataType.UserMoneyKindData);
                //}
                //else
                //{
                //    status = this._iMoneyKindDB.SearchSpecification(out retbyteUsr, out totalCnt, out nextData, parabyteUsr, 0, logicalMode, readCnt, GetMoneyKindDataType.UserMoneyKindData);
                //    retTotalCnt = totalCnt;
                //}
                //// ---------------- //
                //// XML�̓ǂݍ���
                //// ---------------- //
                //if ((status == (int)ConstantManagement.DB_Status.ctDB_NORMAL) ||
                //    (status == (int)ConstantManagement.DB_Status.ctDB_EOF))
                //{
                //    // ----- ���[�U�[�f�[�^�擾 ----- //                
                //    mnkindUsrWkAly = (MoneyKindWork[])XmlByteSerializer.Deserialize(retbyteUsr, typeof(MoneyKindWork[]));
                //    for ( int i = 0; i < mnkindUsrWkAly.Length; i++ )
                //    {
                //        MoneyKindWork wkMoneyKindWork = (MoneyKindWork)mnkindUsrWkAly[i];   // �T�[�`���ʎ擾
                //        retList.Add( CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // �L�^��Ǘ��N���X�փ����o�R�s�[
                //    }
                //}
                //else
                //{
                //    return status;
                //}
                if (readCnt == 0)
                {
                    object retObj;
                    object paraObj = moneykindWork;			//���o�����ݒ�p�N���X��XML�֕ϊ����A������̃o�C�i����

                    //�S���Ǎ�
                    status = this._iMoneyKindDB.Search(out retObj, paraObj, 0, logicalMode, GetMoneyKindDataType.UserMoneyKindData);

                    if (( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) ||
                        ( status == (int)ConstantManagement.DB_Status.ctDB_EOF ))
                    {

                        foreach (MoneyKindWork wkMoneyKindWork in (ArrayList)retObj)
                        {
                            retList.Add(CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // �L�^��Ǘ��N���X�փ����o�R�s�[
                        }
                    }
                    else
                    {
                        return status;
                    }
                }
                else
                {
                    //���o�����ݒ�p�N���X��XML�֕ϊ����A������̃o�C�i����
                    byte[] parabyte    = XmlByteSerializer.Serialize(moneykindWork);    
                    byte[] parabyteUsr = XmlByteSerializer.Serialize(moneykindWork);
                    status = this._iMoneyKindDB.SearchSpecification(out retbyteUsr, out totalCnt, out nextData, parabyteUsr, 0, logicalMode, readCnt, GetMoneyKindDataType.UserMoneyKindData);
                    retTotalCnt = totalCnt;

                    // ---------------- //
                    // XML�̓ǂݍ���
                    // ---------------- //
                    if (( status == (int)ConstantManagement.DB_Status.ctDB_NORMAL ) ||
                        ( status == (int)ConstantManagement.DB_Status.ctDB_EOF ))
                    {
                        // ----- ���[�U�[�f�[�^�擾 ----- //                
                        mnkindUsrWkAly = (MoneyKindWork[])XmlByteSerializer.Deserialize(retbyteUsr, typeof(MoneyKindWork[]));
                        for (int i = 0; i < mnkindUsrWkAly.Length; i++)
                        {
                            MoneyKindWork wkMoneyKindWork = (MoneyKindWork)mnkindUsrWkAly[i];   // �T�[�`���ʎ擾
                            retList.Add(CopyToMoneyKindFromMoneyKindWork(wkMoneyKindWork));    // �L�^��Ǘ��N���X�փ����o�R�s�[
                        }
                    }
                    else
                    {
                        return status;
                    }
                }
                // 2008.12.01 Update <<<
            }
            //K.HIIRO

			// �S�����[�h�̏ꍇ�͖߂�l�̌������Z�b�g
			if ( readCnt == 0 )
			{
				retTotalCnt = retList.Count;
			}
			
			//���X�g��������ёւ�����
			IMnyKindComp imnykindcmp = new IMnyKindComp();
			retList.Sort(imnykindcmp);

			// STATUS��ݒ�
			if( ( status == ( int )ConstantManagement.DB_Status.ctDB_EOF ) && 
				( retList.Count == 0 ) ) 
			{
				status = ( int )ConstantManagement.DB_Status.ctDB_EOF;
			}
			else 
			{
				status = ( int )ConstantManagement.DB_Status.ctDB_NORMAL;
			}

			return status;
			// 2005.12.17 enokida ADD <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< end
		}

        
		/// <summary>
		/// ���z��ʃN���X���ёւ��p�N���X
		/// </summary>
		/// <remarks>
		/// <br>Note       : ���z�ݒ�敪������敪������R�[�h���ɕ��ёւ���N���X�B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public class IMnyKindComp : IComparer  
		{
			int IComparer.Compare( Object x, Object y )  
			{

				int retst = 0;
                MoneyKind mnkindX = (MoneyKind)x;
                MoneyKind mnkindY = (MoneyKind)y;

				//���z�ݒ�敪���r
				retst = mnkindX.PriceStCode - mnkindY.PriceStCode;  
				if(retst == 0)
				{
					//����敪���r
					retst = mnkindX.MoneyKindDiv - mnkindY.MoneyKindDiv;
					if(retst == 0)
					{
						//����R�[�h���r               
						retst = mnkindX.MoneyKindCode - mnkindY.MoneyKindCode;
					} 

				}

				return retst;
			}
		}


		/// <summary>
		/// ���z��ʐݒ茟�������iDataSet�p�j
		/// </summary>
		/// <param name="ds">�擾���ʊi�[�pDataSet</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		public int SearchDS(ref DataSet ds,string enterpriseCode)
		{
			MoneyKindWork moneykindWork = new MoneyKindWork();
			moneykindWork.EnterpriseCode = enterpriseCode;

            //K.HIIRO
			//// XML�֕ϊ����A������̃o�C�i����
			//byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
            //
			//byte[] retbyte;
            //
			//// ���z��ʃT�[�`
			//int status = this._iMoneyKindDB.Search(out retbyte, parabyte, 0, 0, GetMoneyKindDataType.UserMoneyKindData);
            //
			//if ( status == 0 )
			//{
			//	XmlByteSerializer.ReadXml(ref ds, retbyte);
			//}
            int status;
            if (_isLocalDBRead)
            {
                List<MoneyKindWork> workList = new List<MoneyKindWork>();
                status = this._moneyKindLcDB.Search(out workList, moneykindWork, 0, 0, MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);
                if (status == 0)
                {
                    byte[] retbyte = XmlByteSerializer.Serialize(workList);
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            else
            {
                // XML�֕ϊ����A������̃o�C�i����
                byte[] parabyte = XmlByteSerializer.Serialize(moneykindWork);
                byte[] retbyte;
                // ���z��ʃT�[�`
                status = this._iMoneyKindDB.Search(out retbyte, parabyte, 0, 0, GetMoneyKindDataType.UserMoneyKindData);
                if (status == 0)
                {
                    XmlByteSerializer.ReadXml(ref ds, retbyte);
                }
            }
            //K.HIIRO
				
			return status;
		}

        /// <summary>
        /// ���z��ʐݒ胍�[�J���f�[�^���������iDataSet(�K�C�h)�p�j
        /// </summary>
        /// <param name="ds">�擾���ʊi�[�pDataSet</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : ���z��ʐݒ�̌����������s���A�擾���ʂ�DataSet�ŕԂ��܂��B</br>
        /// <br>Programmer : 980023 �ђJ �k��</br>
        /// <br>Date       : 2007.04.04</br>
        /// </remarks>
        public int SearchLocalDB(string enterpriseCode, int priceStCode, ref DataSet ds)
        {
            MoneyKindWork moneykindWork = new MoneyKindWork();
            moneykindWork.EnterpriseCode = enterpriseCode;

            MoneyKind moneyKind = new MoneyKind();

            List<MoneyKindWork> moneyKindWorkList = new List<MoneyKindWork>();
            ArrayList ar = new ArrayList();

            // ���z��ʃT�[�`
            int status = this._moneyKindLcDB.Search(out moneyKindWorkList, moneykindWork, 0, 0, Broadleaf.Application.LocalAccess.MoneyKindLcDB.GetMoneyKindDataType.UserMoneyKindData);
            if (status == 0)
            {
                foreach (MoneyKindWork retMoneyKindWork in moneyKindWorkList)
                {
                    if ((retMoneyKindWork.PriceStCode == priceStCode) && (retMoneyKindWork.LogicalDeleteCode == 0))
                    {
                        moneyKind = CopyToMoneyKindFromMoneyKindWork(retMoneyKindWork);
                        // �T�[�`���ʎ擾
                        ar.Add(moneyKind.Clone());
                    }
                }
            }

            ArrayList wkList = ar.Clone() as ArrayList;
            SortedList wkSort = new SortedList();

            // --- [�S��] --- //
            // ���̂܂ܑS���Ԃ�
            foreach (MoneyKind wkMoneyKind in wkList)
            {
                if (wkMoneyKind.LogicalDeleteCode == 0)
                {
                    wkSort.Add(wkMoneyKind.MoneyKindCode, wkMoneyKind);
                }
            }

            MoneyKind[] moneyKinds = new MoneyKind[wkSort.Count];

            // �f�[�^�����ɖ߂�
            for (int i = 0; i < wkSort.Count; i++)
            {
                moneyKinds[i] = (MoneyKind)wkSort.GetByIndex(i);
            }

            byte[] retbyte = XmlByteSerializer.Serialize(moneyKinds);
            XmlByteSerializer.ReadXml(ref ds, retbyte);

            return status;
        }

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���z��ʐݒ胏�[�N�N���X�ˋ��z��ʐݒ�N���X�j
		/// </summary>
		/// <returns>���z��ʐݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ胏�[�N�N���X������z��ʐݒ�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private MoneyKind CopyToMoneyKindFromMoneyKindWork(MoneyKindWork moneyKindWorkBuf)

			// <param name="MoneyKindWork">���z��ʐݒ胏�[�N�N���X</param>
		{
			MoneyKind moneykind = new MoneyKind();

			//�t�@�C���w�b�_����
			moneykind.CreateDateTime    = moneyKindWorkBuf.CreateDateTime;
			moneykind.UpdateDateTime    = moneyKindWorkBuf.UpdateDateTime;
			moneykind.EnterpriseCode    = moneyKindWorkBuf.EnterpriseCode.TrimEnd();
			moneykind.FileHeaderGuid    = moneyKindWorkBuf.FileHeaderGuid;
			moneykind.UpdEmployeeCode   = moneyKindWorkBuf.UpdEmployeeCode.TrimEnd();
			moneykind.UpdAssemblyId1    = moneyKindWorkBuf.UpdAssemblyId1.TrimEnd();
			moneykind.UpdAssemblyId2    = moneyKindWorkBuf.UpdAssemblyId2.TrimEnd();
			moneykind.LogicalDeleteCode = moneyKindWorkBuf.LogicalDeleteCode;

			moneykind.PriceStCode       = moneyKindWorkBuf.PriceStCode;
			moneykind.MoneyKindCode     = moneyKindWorkBuf.MoneyKindCode;
			moneykind.MoneyKindName     = moneyKindWorkBuf.MoneyKindName.TrimEnd();
			moneykind.MoneyKindDiv      = moneyKindWorkBuf.MoneyKindDiv;

            // 2007.05.17  S.Koga  Add ----------------------------------------
            //moneykind.RegiMgCd          = moneyKindWorkBuf.RegiMgCd;  // DEL 2008/06/12
            // ----------------------------------------------------------------

			return moneykind;
		}

		/// <summary>
		/// �N���X�����o�[�R�s�[�����i���z��ʐݒ�N���X�ˋ��z��ʐݒ胏�[�N�N���X�j
		/// </summary>
		/// <param name="moneykind">���z��ʐݒ胏�[�N�N���X</param>
		/// <returns>���z��ʐݒ�N���X</returns>
		/// <remarks>
		/// <br>Note       : ���z��ʐݒ�N���X������z��ʐݒ胏�[�N�N���X�փ����o�[�̃R�s�[���s���܂��B</br>
		/// <br>Programmer : 97134 ���� �딎</br>
		/// <br>Date       : 2005.06.24</br>
		/// </remarks>
		private MoneyKindWork CopyToMoneyKindWorkFromMoneyKind(MoneyKind moneykind)
		{

			MoneyKindWork moneyKindWorkBuf = new MoneyKindWork();

			moneyKindWorkBuf.CreateDateTime		= moneykind.CreateDateTime;
			moneyKindWorkBuf.UpdateDateTime		= moneykind.UpdateDateTime;
			moneyKindWorkBuf.EnterpriseCode		= moneykind.EnterpriseCode;
			moneyKindWorkBuf.FileHeaderGuid		= moneykind.FileHeaderGuid;
			moneyKindWorkBuf.UpdEmployeeCode	= moneykind.UpdEmployeeCode;
			moneyKindWorkBuf.UpdAssemblyId1		= moneykind.UpdAssemblyId1;
			moneyKindWorkBuf.UpdAssemblyId2		= moneykind.UpdAssemblyId2;
			moneyKindWorkBuf.LogicalDeleteCode	= moneykind.LogicalDeleteCode;

			moneyKindWorkBuf.PriceStCode        = moneykind.PriceStCode;
			moneyKindWorkBuf.MoneyKindCode      = moneykind.MoneyKindCode;
			moneyKindWorkBuf.MoneyKindName      = moneykind.MoneyKindName;
			moneyKindWorkBuf.MoneyKindDiv       = moneykind.MoneyKindDiv;

            // 2007.05.17  S.Koga  add ----------------------------------------
            //moneyKindWorkBuf.RegiMgCd           = moneykind.RegiMgCd;  // DEL 2008/06/12
            // ----------------------------------------------------------------

			return moneyKindWorkBuf;
		}

        /// <summary>
        /// �}�X�^�K�C�h�N������(�ʏ�(���[�J��))
        /// </summary>
        /// <param name="itemsDisp">�擾�f�[�^</param>
        /// <param name="enterpriseCode">��ƃR�[�h</param>
        /// <param name="guideMode">�K�C�h�N�����[�h</param>
        /// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
        /// <remarks>
        /// <br>Note       : �}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
        /// <br>Programmer : 980023 �ђJ �k��</br>
        /// <br>Date       : 2007.05.07</br>
        /// </remarks>
        public int ExecuteGuid(string enterpriseCode, int priceStCode, out MoneyKind moneyKind, string guideXmlParentFile)
        {
            if (_isLocalDBRead)
            {
                // ���[�J��
                return this.ExecuteGuid(enterpriseCode, priceStCode, out moneyKind, guideXmlParentFile, 0);
            }
            else
            {
                // �����[�g
                return this.ExecuteGuid(enterpriseCode, priceStCode, out moneyKind, guideXmlParentFile, 1);
            }
        }

		// �}�X�����`�[���쐬�K�C�h 2005.06.08 Misaki Del
		/// <summary>
		/// ���z��ʃK�C�h�N������
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="moneyKind">�擾�f�[�^</param>
		/// <param name="priceStCode">�擾�f�[�^</param>
		/// <param name="guideXmlParentFile">�擾�f�[�^</param>
		/// <returns>STATUS[0:�擾����,1:�L�����Z��]</returns>
		/// <remarks>
		/// <br>Note		: ���z��ʐݒ�}�X�^�̈ꗗ�\���@�\�����K�C�h���N�����܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2005.05.20</br>
		/// <br>UpdateNote : 2005.09.13 ���z�ݒ�敪���Ƀf�[�^���擾�ł���悤�ɕύX</br>
		/// <br>           : 23011 ��� ���N</br>
		/// </remarks>
        // ----- iitani c ---------- start 2007.05.07
        //public int ExecuteGuid(string enterpriseCode, int priceStCode, out MoneyKind moneyKind, string guideXmlParentFile)
        public int ExecuteGuid(string enterpriseCode, int priceStCode, out MoneyKind moneyKind, string guideXmlParentFile, int searchMode)
        // ----- iitani c ---------- end 2007.05.07
        {
			int status = -1;
            moneyKind = new MoneyKind();
            
            // ----- iitani a ---------- start  2007.05.20
            if (guideXmlParentFile == "")
            {
                // �f�t�H���g�ݒ�
                guideXmlParentFile = "MONEYKINDGUIDEPARENT.XML";
            }
            // ----- iitani a ---------- end  2007.05.20

			TableGuideParent tableGuideParent = new TableGuideParent(guideXmlParentFile);
			// �����ݒ�p�̃n�b�V���e�[�u��
			Hashtable inObj = new Hashtable();
			// �K�C�h�őI�����ꂽ�f�[�^���Z�b�g����n�b�V���e�[�u��
			Hashtable retObj = new Hashtable();

			// ��ƃR�[�h
			inObj.Add("EnterpriseCode", enterpriseCode);
			inObj.Add("PriceStCode", priceStCode );
            inObj.Add(GUIDE_SEARCHMODE_PARA, searchMode);  // �K�C�h�f�[�^�T�[�`���[�h(0:���[�J��,1:�����[�g) iitani a 2007.05.07
			
			if (tableGuideParent.Execute(0, inObj, ref retObj))
			{
				Object retMoneyKind = (Object)moneyKind;
				// �擾�����f�[�^���N���X�ɃZ�b�g
				TableGuideParent.HashTableToClassProperty(retObj, ref retMoneyKind);
				moneyKind = (MoneyKind)retMoneyKind;
                status = 0;
			}
			else
			{
				status = 1;
			}
			return status;
		}
		
		/// <summary>
		/// ��������
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="ds">�f�[�^�Z�b�g</param>
		/// <param name="priceStCode">���z�ݒ�敪</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �K�C�h�p�f�[�^�o�b�t�@����Ȃ烊���[�g����f�[�^���擾����</br>
		/// <br>Programmer : 99032 �ɓ� ���I</br>
		/// <br>Date       : 2005.06.13</br>
		/// <br>UpdateNote : 2005.09.13 ���z�ݒ�敪���Ƀf�[�^���擾�ł���悤�ɕύX</br>
		/// <br>           : 23011 ��� ���N</br>
		/// </remarks>
		private int SearchDS(string enterpriseCode, int priceStCode, ref DataSet ds)
		{
			int status = 0;
			SortedList sortList = new SortedList();
			
			// �o�b�t�@����Ȃ�f�[�^���擾
			if((_guidBuff_MoneyKind == null)||(_guidBuff_MoneyKind.Count == 0))
			{
				status = Search(out _guidBuff_MoneyKind,enterpriseCode);
				/*
								// 2005.12.16 N.TANIFUJI DEL  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
								//�\�[�g
								foreach (MoneyKind moneyKind in _guidBuff_MoneyKind)
								{
									string keyOfList = moneyKind.PriceStCode + "," + moneyKind.MoneyKindCode;
									sortList.Add(keyOfList, moneyKind);
								}

								_guidBuff_MoneyKind.Clear();
								_guidBuff_MoneyKind.AddRange(sortList.Values);
								// 2005.12.16 N.TANIFUJI DEL  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END
				*/
				if(status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
					return status;
			}
			
			MoneyKind[] moneyKinds = null;
			
			ArrayList alTmp = new ArrayList();
			
			sortList.Clear();
			//�Ώۂ̋敪�������ꍇ�̂݌��ʂɒǉ�
            foreach(MoneyKind moneyKind in _guidBuff_MoneyKind)
			{
				if(( moneyKind.PriceStCode == priceStCode )&&(moneyKind.LogicalDeleteCode == 0))
				{
					alTmp.Add( moneyKind );
				}
			}
			
			// 2005.12.16 N.TANIFUJI ADD  >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> START
            foreach(MoneyKind moneyKindsort in alTmp)
            {
				sortList.Add(moneyKindsort.MoneyKindCode, moneyKindsort);
			}

			alTmp.Clear();
			alTmp.AddRange(sortList.Values);
			// 2005.12.16 N.TANIFUJI ADD  <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<< END

            moneyKinds = (MoneyKind[])alTmp.ToArray(typeof(MoneyKind));
			byte[] retByte = XmlByteSerializer.Serialize(moneyKinds);
			XmlByteSerializer.ReadXml(ref ds,retByte);
			
			return status;
		}
		
		#region IGeneralGuidData Method
		/// <summary>
		/// �ėp�K�C�h�f�[�^�擾(IGeneralGuidData�C���^�[�t�F�[�X����)
		/// </summary>
		/// <param name="mode"></param>
		/// <param name="inParm"></param>
		/// <param name="guideList"></param>
		/// <returns>STATUS[0:�擾����,1:�L�����Z��,4:���R�[�h����]</returns>
		/// <remarks>
		/// <br>Note		: �ėp�K�C�h�ݒ�p�f�[�^���擾���܂��B</br>
		/// <br>Programmer	: 22024 ����@�_�u</br>
		/// <br>Date		: 2005.05.20</br>
		/// <br>UpdateNote : 2005.09.13 ���z�ݒ�敪���Ƀf�[�^���擾�ł���悤�ɕύX</br>
		/// <br>           : 23011 ��� ���N</br>
		/// </remarks>
		public int GetGuideData(int mode, Hashtable inParm, ref DataSet guideList)
		{
			int status   = -1;
			string enterpriseCode = "";
			int priceStCode = 0;
			
			// ��ƃR�[�h�ݒ�L��
			if ( inParm.ContainsKey("EnterpriseCode") && inParm.ContainsKey("PriceStCode") )
			{
				enterpriseCode = inParm["EnterpriseCode"].ToString();
				priceStCode = (int)inParm["PriceStCode"];
			}
				// ��ƃR�[�h�A���z�ݒ�敪�̎w�薳��
			else 
			{
				return status;
			}

            // ���z��ʐݒ�e�[�u���Ǎ��݁iDataSet�p�j���[�J��DB�ɕύX iitani c 
            //status = SearchDS(enterpriseCode, priceStCode, ref guideList);
            // ----- iitani c ---------- start 2007.05.07
            //status = SearchLocalDB(enterpriseCode, priceStCode, ref guideList);
            int searchMode = 0;
            if (inParm.ContainsKey(GUIDE_SEARCHMODE_PARA))
            {
                searchMode = int.Parse(inParm[GUIDE_SEARCHMODE_PARA].ToString());
            }

            if (searchMode == 1)
            {
                status = SearchDS(enterpriseCode, priceStCode, ref guideList);
            }
            else
            {
                status = SearchLocalDB(enterpriseCode, priceStCode, ref guideList);
            }
            // ----- iitani c ---------- end 2007.05.07

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
					status = -1;
					break;
			}

			return status;
		}
		#endregion
		//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> Del
	
	
		/// <summary>
		/// �L���b�V���擾����
		/// </summary>
		/// <param name="retList">�f�[�^�o�b�t�@</param>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="mode">0:�_���폜������,1:�_���폜���܂�</param>
		/// <returns>STATUS</returns>
		/// <remarks>
		/// <br>Note       : �f�[�^�o�b�t�@���擾���܂�</br>
		/// <br>Programmer : 22021 �J���@�͍K</br>
		/// <br>Date       : 2005.12.20</br>
		/// </remarks>
		public int GetBuff(out ArrayList retList, string enterpriseCode, int mode)
		{
			int status = 0;
		
			// �K�C�h�p�o�b�t�@�Ƀf�[�^��������΃����[�g���擾����
			if((_guidBuff_MoneyKind == null)||(_guidBuff_MoneyKind.Count == 0))
			{
				if(_guidBuff_MoneyKind == null){_guidBuff_MoneyKind = new ArrayList();}
				_guidBuff_MoneyKind.Clear();
	
				if(_Logical_guidBuff_MoneyKind == null){_Logical_guidBuff_MoneyKind = new ArrayList();}
				_Logical_guidBuff_MoneyKind.Clear();
				ArrayList insMoneyKindAll = new ArrayList();
				status = SearchAll(out insMoneyKindAll, enterpriseCode);

				foreach(MoneyKind MoneyKinds in insMoneyKindAll)
                {
                    if (MoneyKinds.LogicalDeleteCode == 0)
                    {
                        _guidBuff_MoneyKind.Add(MoneyKinds);
                    }
                    _Logical_guidBuff_MoneyKind.Add(MoneyKinds);
                }
            }
			if(mode == 0)
			{
				retList = _guidBuff_MoneyKind;
			}
			else
			{
				retList = _Logical_guidBuff_MoneyKind;
			}
				return status;
		}
	
	}
}
