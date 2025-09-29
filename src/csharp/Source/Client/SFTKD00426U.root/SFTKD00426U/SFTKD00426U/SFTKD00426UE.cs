using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using Broadleaf.Library;
using Broadleaf.Windows.Forms;
using Broadleaf.Application.Common;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Windows.Forms;
using Broadleaf.Application.Controller;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// AddressGuide�N���X�B�����ŏZ���K�C�h�̃_�C�A���O�N���X���Ăяo���B
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: 2007.03.15 980076 �Ȓ��@����Y</br>
	/// <br>		   : �X�֔ԍ��K�C�h����ƂȂ�悤�ɕύX</br>
	/// </remarks>
	public class AddressGuide
	{
        /// <summary>
        /// �}�[�W�����A�N�Z�X�N���X
        /// </summary>
		private MergedAddressAcs mergedAddressAcs = null;
		
        /// <summary>
        /// �Z���A�N�Z�X�N���X
        /// </summary>
        private OfferAddressInfoAcs offerAddressInfoAcs = null;

        /// <summary>
        /// �L���b�V���̑S�̏���
        /// </summary>
        private static AllDefSet[] cacheAllDefSet = null;

        /// <summary>
		/// �񓯊����[�h�\���B
		/// SearchAddress()���Ă΂�Ă���Ԃ͔񓯊����[�h�ł��Ȃ�
        /// AreaGroup���O������擾�ł���悤�ɕύX
		/// </summary>
		public AddressGuide()
		{
			this.mergedAddressAcs = new MergedAddressAcs();
			this.offerAddressInfoAcs = new OfferAddressInfoAcs();

            ////TODO : Debug
            //AreaGroupAcs acs = new AreaGroupAcs();
            //ArrayList list = null;

            //acs.SearchAll(out list, LoginInfoAcquisition.EnterpriseCode);

            //this.offerAddressInfoAcs.SetAreaGroupStaticMemory(list);
		}

        /// <summary>
        /// AreaGroup, AllDefSet���O������擾�ł���悤�ɕύX
        /// </summary>
        public AddressGuide(AreaGroup[] areaGroupList, AllDefSet[] allDefSet ) : this()
        {
            this.offerAddressInfoAcs.SetAreaGroupStaticMemory( new ArrayList( areaGroupList) );

            cacheAllDefSet = allDefSet;
        }

        #region ����x��̃��\�b�h�B

        /// <summary>
		/// ��ƃR�[�h���w�肵�ďZ���K�C�h�����J��
		/// </summary>
		/// <param name="enterpriseCode">��ƃR�[�h</param>
		/// <param name="agResult">����</param>
		/// <returns>DialogResult</returns>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : 23011�@����@���N</br>
		/// <br>Date       : 2005.06.02</br>
		/// <br></br>
		/// <br>Update Note: </br>
		/// </remarks>
        [Obsolete("�\���󂠂�܂��� public DialogResult ShowAddressGuide(out AddressGuideResult result) ���g�p���Ă��������B�Ή���낵�����肢���܂��B���", false)]
        public DialogResult SearchAddress(string enterpriseCode, ref AddressGuideResult agResult)
		{
            return this.ShowAddressGuide(out agResult);
		}

        /// <summary>
        /// �w��̏Z���R�[�h���f�t�H���g�ʒu�ɂ��ăK�C�h���Ђ炭
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addressCode2"></param>
        /// <param name="addressCode3"></param>
        /// <param name="agResult"></param>
        /// <returns></returns>
        [Obsolete("�\���󂠂�܂��� public DialogResult ShowAddressGuide(int addressCode1, int addressCode2, int addressCode3, out AddressGuideResult result) ���g�p���Ă��������B�Ή���낵�����肢���܂��B���", false)]
        public DialogResult SearchAddress(int addressCode1, int addressCode2, int addressCode3, ref AddressGuideResult agResult)
        {
            return ShowAddressGuide(addressCode1, addressCode2, addressCode3, out agResult);
        }

        /// <summary>
        /// �X�֔ԍ����w�肵�ďZ������������
        /// </summary>
        /// <param name="strPostNo">�X�֔ԍ��̃L�[���[�h</param>
        /// <param name="agResult">����</param>
        /// <returns>DialogResult</returns>
        [Obsolete("�\���󂠂�܂��� public DialogResult ShowPostNoSearchGuide(string postNoKeyword, out AddressGuideResult result) ���g�p���Ă��������B�Ή���낵�����肢���܂��B���", false)]
        public DialogResult SearchAddressFromPostNo(string strPostNo, ref AddressGuideResult agResult)
        {
            return this.ShowPostNoSearchGuide(strPostNo, out agResult);
        }

        /// <summary>
        /// �񓯊����[�h�p�֐�
        /// </summary>
        /// <param name="strEnterpriseCode">��ƃR�[�h</param>
        [Obsolete("�\���󂠂�܂��� public void LoadAddress() ���g�p���Ă��������B�Ή���낵�����肢���܂��B���", false)]
        public void LoadAddress(string strEnterpriseCode)
        {
            this.LoadAddress();
        }

        #endregion

        private int GetAllDefSetFromCache(string sectionCode, out AllDefSet allDefSet)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            allDefSet = null;

            if (cacheAllDefSet == null)
            {
                return status;
            }

            for (int i = 0; i < cacheAllDefSet.Length; i++)
            {
                if (cacheAllDefSet[i].SectionCode == sectionCode)
                {
                    allDefSet = cacheAllDefSet[i];
                    status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                    break;
                }
            }

            return status;
        }

        /// <summary>
        /// �S�̐ݒ�}�X�^���珉���\������ǂ�
        /// </summary>
        /// <param name="strEnterpriseCode"></param>
        /// <param name="allDefSet"></param>
        /// <returns></returns>
        private int GetAllDefSetFromRemote(string strEnterpriseCode, out AllDefSet allDefSet)
        {
            allDefSet = null;

            AllDefSetAcs allDefSetAcs;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            allDefSetAcs = new AllDefSetAcs();
            //throw new System.Exception("�S�̏����\���̃f�[�^�Ƃ�ɂ������Ƃ���");

            //status = allDefSetAcs.Read( out allDefSet, strEnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode );
            status = allDefSetAcs.Read(out allDefSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);

            return status;
        }

        /// <summary>
        /// �Z�������擾����
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addressCode2"></param>
        /// <param name="addressCode3"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private int GetAddressWork( int addressCode1, int addressCode2, int addressCode3, out AddressWork result )
        {
            result = null;
            ArrayList resultList = new ArrayList();

            int status = this.offerAddressInfoAcs.GetAddressWorkFromAddressCode(addressCode1, addressCode2, addressCode3, ref resultList);

            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                return status;
            }

            if (resultList == null || resultList.Count <= 0)
            {
                return status;
            }

            result = resultList[0] as AddressWork;
            return status;
        }

        /// <summary>
        /// �K�C�h�\����������
        /// </summary>
        /// <param name="addressConnectCd1"></param>
        /// <param name="addressConnectCd2"></param>
        /// <param name="addressConnectCd3"></param>
        /// <param name="addressConnectCd4"></param>
        /// <param name="addressConnectCd5"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private DialogResult ShowAddressGuideInner(int addressConnectCd1, int addressConnectCd2, int addressConnectCd3, int addressConnectCd4, int addressConnectCd5, out AddressGuideResult result)
        {
            result = null;

            //�f�t�H���g�I���ʒu���w�肵�đ��쐬
            AddressGuideWindow agDialog = new AddressGuideWindow(addressConnectCd1,
                addressConnectCd2, addressConnectCd3, addressConnectCd4,
                addressConnectCd5);

            //OK�ȊO���I�����ꂽ��
            if (agDialog.ShowDialog() != DialogResult.OK)
            {
                return DialogResult.Cancel;
            }

            AddressData addressWorkResult = agDialog.GetResult();

            //�I������Ă��Ȃ������ꍇ
            if (addressWorkResult == null)
            {
                return DialogResult.Cancel;
            }

            result = new AddressGuideResult(addressWorkResult);

            return DialogResult.OK;
        }

        /// <summary>
        /// �f�t�H���g�\�����g�p���ăK�C�h���J���܂�
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public DialogResult ShowAddressGuide(out AddressGuideResult result)
        {
			/* --- 2007.03.15 men del sta ---------------------------------- //
            AllDefSet allDefSet = null;

            //�f�t�H���g�I���ʒu���擾
            int status = 0;

            //�܂��̓L���b�V������f�[�^�擾
            status = GetAllDefSetFromCache(LoginInfoAcquisition.Employee.BelongSectionCode, out allDefSet);

            //�L���b�V���Ƀf�[�^���������
            if( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ){
                status = this.GetAllDefSetFromRemote(LoginInfoAcquisition.EnterpriseCode, out allDefSet);
            }

            //�S�̏��������Ȃ��Ȃ�f�t�H���g�\��
            if ( status != 0 || allDefSet == null)
            {
                return this.ShowAddressGuideInner(0, 0, 0, 0, 0, out result);
            }

            AddressWork defaultAddress = null;

            //�S�̏����̏Z���R�[�h�ŏZ�����擾
            status = this.GetAddressWork(allDefSet.DefDispAddrCd1, allDefSet.DefDispAddrCd2, allDefSet.DefDispAddrCd3, out defaultAddress );

            //�s���ȏZ���R�[�h�Ȃ�f�t�H���g�\��
            if (status != 0 || defaultAddress == null)
            {
                return ShowAddressGuideInner(0, 0, 0, 0, 0, out result);
            }

            return ShowAddressGuideInner(defaultAddress.AddrConnectCd1, defaultAddress.AddrConnectCd2, defaultAddress.AddrConnectCd3, defaultAddress.AddrConnectCd4, defaultAddress.AddrConnectCd5, out result);
			// --- 2007.03.15 men del end ----------------------------------- */

			// --- 2007.03.15 men add sta ----------------------------------- //
			result = null;
			return DialogResult.Cancel;
			// --- 2007.03.15 men add end ----------------------------------- //
		}

        /// <summary>
        /// �Z���R�[�h���w�肵�ăK�C�h��\�����܂�
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addressCode2"></param>
        /// <param name="addressCode3"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public DialogResult ShowAddressGuide(int addressCode1, int addressCode2, int addressCode3, out AddressGuideResult result)
        {
			/* --- 2007.03.15 men del sta ---------------------------------- //
            int status;
            result = null;

            AddressWork defaultAddress = null;

            status = GetAddressWork(addressCode1, addressCode2, addressCode3, out defaultAddress);

            //�s���ȏZ���R�[�h�̏ꍇ
            if (status != 0 || defaultAddress == null)
            {
                //�S�̏����\���ݒ���擾
                AllDefSet allDefSet = null;

                //�S�̏�������f�[�^�擾�B�L���b�V���̃f�[�^������Ƃ��͂�����g��
                status = GetAllDefSetFromCache(LoginInfoAcquisition.Employee.BelongSectionCode, out allDefSet);

                //�L���b�V���Ƀf�[�^�������ꍇ�̓����[�g����擾
                if( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL ){
                    status = GetAllDefSetFromRemote(LoginInfoAcquisition.EnterpriseCode, out allDefSet);
                }

                //����ł��S�̏������Ƃ�Ȃ�������
                if (allDefSet == null)
                {
                    return ShowAddressGuideInner(0, 0, 0, 0, 0, out result);
                }

                status = GetAddressWork(allDefSet.DefDispAddrCd1, allDefSet.DefDispAddrCd2, allDefSet.DefDispAddrCd3, out defaultAddress);

                //�S�̏����̏Z�����Ƃ�Ȃ��Ȃ�f�t�H���g�\��
                if (status != 0 || defaultAddress == null)
                {
                    return ShowAddressGuideInner(0, 0, 0, 0, 0, out result);
                }

                return ShowAddressGuideInner(defaultAddress.AddrConnectCd1, defaultAddress.AddrConnectCd2, defaultAddress.AddrConnectCd3, defaultAddress.AddrConnectCd4, defaultAddress.AddrConnectCd5, out result);
            }
            else
            {
                return ShowAddressGuideInner(defaultAddress.AddrConnectCd1, defaultAddress.AddrConnectCd2, defaultAddress.AddrConnectCd3, defaultAddress.AddrConnectCd4, defaultAddress.AddrConnectCd5, out result);
            }
			// --- 2007.03.15 men del end ----------------------------------- */

			// --- 2007.03.15 men add sta ----------------------------------- //
			result = null;					
			return DialogResult.Cancel;
			// --- 2007.03.15 men add end ----------------------------------- //
		}

        /// <summary>
        /// �X�֔ԍ������K�C�h��\������
        /// </summary>
        /// <param name="postNoKeyword"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public DialogResult ShowPostNoSearchGuide(string postNoKeyword, out AddressGuideResult result)
        {
            result = null;

            if (!LoginInfoAcquisition.OnlineFlag)
            {
                return DialogResult.Cancel;
            }

            //�X�֔ԍ������_�C�A���O�쐬
            PostCodeSearchWindow pcswDialog = new PostCodeSearchWindow(postNoKeyword, this.mergedAddressAcs);

            //�m�肪������Ȃ�������
            if (pcswDialog.ShowDialog() != DialogResult.OK)
            {
                return DialogResult.Cancel;
            }

            AddressData awTmp = pcswDialog.GetResult();

            //�Ȃɂ��I������Ă��Ȃ������ꍇ
            if (awTmp == null)
            {
                return DialogResult.Cancel;
            }

            result = new AddressGuideResult(awTmp);

            return DialogResult.OK;
        }

		/// <summary>
		/// �Z���R�[�h�����������
		/// </summary>
		/// <param name="addressCode1">�s���{���s��S�R�[�h</param>
		/// <param name="addressCode2">�����R�[�h</param>
		/// <param name="addressCode3">���R�[�h</param>
		/// <param name="agResult">����</param>
		/// <returns>DialogResult</returns>
		public DialogResult SearchAddressFromAddressCode(int addressCode1, int addressCode2, int addressCode3, ref AddressGuideResult agResult )
		{
			if( !LoginInfoAcquisition.OnlineFlag )
			{
				return DialogResult.Cancel;
			}
			
			ArrayList alResult = new ArrayList();
			
			//�Z���R�[�h�Ō���
			if( this.offerAddressInfoAcs.GetAddressWorkFromAddressCode( addressCode1, addressCode2, addressCode3, ref alResult ) != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return DialogResult.Cancel;
			}
			
			//�Z���R�[�h�ɊY������Z���}�X�^���ꌏ���Ȃ������ꍇ
			if( alResult == null || alResult.Count <= 0 )
			{
				return DialogResult.Cancel;
			}
			
			//�����X�֔ԍ����������ꍇ�̏���
			if( alResult.Count > 1 )
			{
				ArrayList alTmp = null;
				
				MergedAddressAcs.CreateData( alResult, out alTmp );
				PostNoSelectWindow posSelectWin = new PostNoSelectWindow( alTmp );
				
				//�����X�֔ԍ��I�𑋂��L�����Z�����ꂽ��߂�
				if( posSelectWin.ShowDialog() != DialogResult.OK )
				{
					return DialogResult.Cancel;
				}
				
				AddressData adResult = posSelectWin.GetResult();
				
				//���ʂ������Ȃ�߂�
				if( adResult == null )
				{
					return DialogResult.Cancel;
				}
				
				agResult.AddressCode1Lower = adResult.AddressCode1Lower;
				agResult.AddressCode1Upper = adResult.AddressCode1Upper;
				agResult.AddressCode2 = adResult.AddressCode2;
				agResult.AddressCode3 = adResult.AddressCode3;
				agResult.AddressName = adResult.AddressName;
				agResult.PostNo = adResult.PostNo;
			}
			else
			{
				agResult.AddressCode1Lower = ((AddressWork)alResult[0]).AddressCode1Lower;
				agResult.AddressCode1Upper = ((AddressWork)alResult[0]).AddressCode1Upper;
				agResult.AddressCode2 = ((AddressWork)alResult[0]).AddressCode2;
				agResult.AddressCode3 = ((AddressWork)alResult[0]).AddressCode3;
				agResult.AddressName = ((AddressWork)alResult[0]).AddressName;
				agResult.PostNo = ((AddressWork)alResult[0]).PostNo;
			}
			
			return DialogResult.OK;
		}

        /// <summary>
        /// �Z���������[�h����
        /// </summary>
        public void LoadAddress()
        {
			/* --- 2007.03.15 men del sta ----------------------------------- //
			//if (!LoginInfoAcquisition.OnlineFlag)
            //{
            //    return;
            //}

            AllDefSet allDefSet = null;
            int status = 0;

            //�܂��̓L���b�V��������
            status = GetAllDefSetFromCache(LoginInfoAcquisition.Employee.BelongSectionCode, out allDefSet );

            //���Ȃ������烊���[�g
            if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
            {
                status = GetAllDefSetFromRemote(LoginInfoAcquisition.EnterpriseCode, out allDefSet);
            }

            //�f�[�^�������ꍇ�͋�̃f�[�^��
            if ( status != 0 || allDefSet == null)
            {
                allDefSet = new AllDefSet();
            }

            this.offerAddressInfoAcs.LoadAreaGroupMaster(allDefSet.DefDispAddrCd1, allDefSet.DefDispAddrCd2, allDefSet.DefDispAddrCd3);
			// --- 2007.03.15 men del end ----------------------------------- */

		}

	}
	
	/// <summary>
	/// AddressGuide�̏������ʊi�[�p�p�����[�^�N���X
	/// </summary>
	public class AddressGuideResult
	{
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
		public AddressGuideResult()
		{
			this.Clear();
		}
		/// <summary>
		/// �R���X�g���N�^
		/// </summary>
		/// <param name="aw"></param>
		public AddressGuideResult( AddressData aw )
		{
			this._AddressCode1Lower = aw.AddressCode1Lower;
			this._AddressCode1Upper = aw.AddressCode1Upper;
			this._AddressCode2 = aw.AddressCode2;
			this._AddressCode3 = aw.AddressCode3;
			this._AddressName = aw.AddressName;
			this._PostNo = aw.PostNo;
		}
		/// <summary>
		/// �N���A
		/// </summary>
		public void Clear()
		{
			this._AddressCode1Lower = 0;
			this._AddressCode1Upper = 0;
			this._AddressCode2 = 0;
			this._AddressCode3 = 0;
			this._AddressName = "";
			this._PostNo = "";
		}
		
		#region �t�B�[���h
		
		private string _PostNo;

		private int _AddressCode1Upper;

		private int _AddressCode1Lower;

		private int _AddressCode2;

		private int _AddressCode3;

		private string _AddressName;

		#endregion
		
		#region �v���p�e�B
        /// <summary>
        /// �X�֔ԍ�
        /// </summary>
		public string PostNo
		{
			get
			{
				return this._PostNo;
			}
			set
			{
				this._PostNo = value;
			}
		}
		/// <summary>
        /// AddressCode1
		/// </summary>
		public int AddressCode1
		{
			get
			{
				return int.Parse( String.Format("{0:D2}{1:D3}", this.AddressCode1Upper, this.AddressCode1Lower ) );
			}
		}
		/// <summary>
        /// AddressCode1
		/// </summary>
		public int AddressCode1Upper
		{
			get
			{
				return this._AddressCode1Upper;
			}
			set
			{
				this._AddressCode1Upper = value;
			}
		}
        /// <summary>
        /// AddressCode1
        /// </summary>
		public int AddressCode1Lower
		{
			get
			{
				return this._AddressCode1Lower;
			}
			set
			{
				this._AddressCode1Lower = value;
			}
		}
        /// <summary>
        /// AddressCode2
        /// </summary>
		public int AddressCode2
		{
			get
			{
				return this._AddressCode2;
			}
			set
			{
				this._AddressCode2 = value;
			}
		}
		/// <summary>
        /// AddressCode3
		/// </summary>
		public int AddressCode3
		{
			get
			{
				return this._AddressCode3;
			}
			set
			{
				this._AddressCode3 = value;
			}
		}
		/// <summary>
        /// AddressName
		/// </summary>
		public string AddressName
		{
			get
			{
				return this._AddressName;
			}
			set
			{
				this._AddressName = value;
			}
		}
		
		#endregion
		
	}
	

}
