using System;
using System.Collections;
using System.Text;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;
using System.Collections.Generic;

namespace Broadleaf.Application.Common
{

	/// <summary>
	/// OfferAddressInfoDB�A�N�Z�X�N���X�B
	/// �񓯊����[�h��񋟂���
	/// </summary>
	/// <remarks>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2005.05.28</br>
	/// <br></br>
	/// <br>Update Note: 2008.05.07 ��ؐ��b</br>
    /// <br>             �@DC.NS����NetAdvantage�o�[�W�����A�b�v�Ή�</br>
    /// </remarks>
	public class OfferAddressInfoAcs : IMergeableAddressAcs
	{
		
		/// <summary>
		/// �����[�e�B���O�A�N�Z�X�p�C���^�[�t�F�C�X
		/// </summary>
		private static IOfferAddressInfo AddressInfo = null;
		
		
		private AddressGuideCacheManager cacheManager = null;
		
		/// <summary>
		/// static�R���X�g���N�^
		/// </summary>
		static OfferAddressInfoAcs()
		{
			OfferAddressInfoAcs.AddressInfo = MediationOfferAddressInfo.GetOfferAddressInfo();
		}
		
        /// <summary>
        /// �R���X�g���N�^
        /// </summary>
		public OfferAddressInfoAcs()
		{
			cacheManager = new AddressGuideCacheManager();
		}
		
		/// <summary>
		/// �I�t���C���f�[�^�̏�������
		/// </summary>
		/// <param name="sender">object</param>
		/// <returns>STATUS</returns>
		public int WriteOfflineData(object sender)
		{
            return 0;
			//return AddressGuideCacheManager.WriteOfflineCache();
		}
		
		#region �񓯊����[�h�p���\�b�h
		
        ////�񓯊����[�h�����ǂ���
        //public bool NowLoading
        //{
        //    get
        //    {
        //        return this.cacheManager.NowLoading;
        //    }
        //}

		/// <summary>
		/// �񓯊����[�h�Ɏg�����߂̃f���Q�[�g
		/// </summary>
		private delegate bool AsyncLoadFromEnterpriseCode( string strEnterpriseCode );

        /// <summary>
        /// �S�̏����\���ݒ�����悤���Ĕ񓯊����[�h���邽�߂̃f���Q�[�g
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addressCode2"></param>
        /// <param name="addressCode3"></param>
        /// <returns></returns>
        private delegate bool AsyncLoadFromAllAddressCode(int addressCode1, int addressCode2, int addressCode3);
        

		/// <summary>
		/// �񓯊������p�R�[�o�b�N���\�b�h
		/// </summary>
		/// <param name="iAsyncResult"></param>
		private void AsyncLoadCallbackFromEnterpriseCode(IAsyncResult iAsyncResult)
		{
			AsyncLoadFromEnterpriseCode asyncState = (AsyncLoadFromEnterpriseCode)iAsyncResult.AsyncState;
			
			asyncState.EndInvoke(iAsyncResult);
		}

        /// <summary>
        /// �񓯊������p�R�[�o�b�N���\�b�h
        /// </summary>
        /// <param name="iAsyncResult"></param>
        private void AsyncLoadCallbackFromAddressCode(IAsyncResult iAsyncResult)
        {
            AsyncLoadFromAllAddressCode asyncState = (AsyncLoadFromAllAddressCode)iAsyncResult.AsyncState;

            asyncState.EndInvoke(iAsyncResult);
        }

        private bool LoadAreaGroupMasterInner(int addressCode1, int addressCode2, int addressCode3)
        {
            ArrayList alAddressWork = new ArrayList();

            try
            {

                //�Z���R�[�h����Z���A���R�[�h���擾
                this.GetAddressWorkFromAddressCode(addressCode1, addressCode2, addressCode3, ref alAddressWork);

                if (alAddressWork == null
                    || alAddressWork.Count <= 0)
                {
                    return false;
                }

                cacheManager.LoadAreaGroupFromAreaCode(((AddressWork)alAddressWork[0]).AddrConnectCd1);

                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// �S�̏����f�[�^��ݒ肵�ďZ���������[�h����
        /// </summary>
        /// <param name="addressCode1"></param>
        /// <param name="addressCode2"></param>
        /// <param name="addressCode3"></param>
        /// <returns></returns>
        public bool LoadAreaGroupMaster(int addressCode1, int addressCode2, int addressCode3)
        {
            AsyncLoadFromAllAddressCode asyncLoad = new AsyncLoadFromAllAddressCode(this.LoadAreaGroupMasterInner);

            asyncLoad.BeginInvoke(addressCode1, addressCode2, addressCode3, new AsyncCallback(this.AsyncLoadCallbackFromAddressCode), asyncLoad);

            return true;
        }

        /// <summary>
        /// �Z�������[�h����
        /// </summary>
        public bool LoadAreaGroupMaster(string strEnterpriseCode)
        {
            //�񓯊����[�h����
            AsyncLoadFromEnterpriseCode asyncLoad = new AsyncLoadFromEnterpriseCode(this.LoadAreaGroupMasterInner);

            asyncLoad.BeginInvoke(strEnterpriseCode, new AsyncCallback(this.AsyncLoadCallbackFromEnterpriseCode), asyncLoad);
            return true;
        }

        /// <summary>
        /// �X�֔ԍ��Ɉ�v����Z���𕡐��擾����
        /// </summary>
        /// <param name="postNoList"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public int ReadAddress(string[] postNoList, out AddressWork[] resultList)
        {
            resultList = null;

            return this.cacheManager.ReadAddress(postNoList, out resultList);
        }

		#region �_�E�����[�h�����ʒm�Ή�

        /// <summary>
        /// �S�̐ݒ�}�X�^���珉���\������ǂ�
        /// </summary>
        /// <param name="strEnterpriseCode"></param>
        /// <param name="allDefSet"></param>
        /// <returns></returns>
        private int GetAllDefSet(string strEnterpriseCode, out AllDefSet allDefSet)
        {
            allDefSet = null;

            AllDefSetAcs allDefSetAcs;

            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            try
            {
                allDefSetAcs = new AllDefSetAcs();

                //throw new System.Exception("�S�̏����\���̃f�[�^�Ƃ�ɂ������Ƃ���");

                //status = allDefSetAcs.Read( out allDefSet, strEnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode );
                status = allDefSetAcs.Read(out allDefSet, LoginInfoAcquisition.EnterpriseCode, LoginInfoAcquisition.Employee.BelongSectionCode);
            }
            catch (Exception)
            {
                return -1;
            }

            return status;
        }

        /// <summary>
        /// �񓯊��ŏZ���}�X�^�����[�h����
        /// ���̔񓯊����[�h�������s���Ă���ꍇ�̓��[�h�Ɏ��s����B
        /// </summary>
        /// <param name="strEnterpriseCode">��ƃR�[�h</param>
        private bool LoadAreaGroupMasterInner(string strEnterpriseCode)
        {
			/*
            try
            {
                AllDefSet allDefSet = new AllDefSet();

                //�w��̊�ƃR�[�h�̏��ɊY������Z���}�X�^���Ȃ�����
                if (this.GetAllDefSet(strEnterpriseCode, out allDefSet) != (int)ConstantManagement.DB_Status.ctDB_NORMAL
                    || allDefSet == null
                    || allDefSet.DefDispAddrCd1 <= 0)
                {
                    return false;
                }

                return LoadAreaGroupMasterInner(allDefSet.DefDispAddrCd1, allDefSet.DefDispAddrCd2, allDefSet.DefDispAddrCd3);
            }
            catch
            {
                return false;
            }
			*/
			return false;
        }

		//�����ʒm�p�C�x���g
		private EventHandler dlFinishCallBack = null;
		
		/// <summary>
		/// �_�E�����[�h�����ʒm�Ή�
		/// </summary>
		/// <param name="strEnterpriseCode"></param>
		/// <param name="dlFinishCallBack"></param>
		/// <returns></returns>
		public bool LoadAreaGroupMaster( string strEnterpriseCode, EventHandler dlFinishCallBack )
		{
			this.dlFinishCallBack = dlFinishCallBack;
			
			//�񓯊����[�h����
            AsyncLoadFromEnterpriseCode asyncLoad = new AsyncLoadFromEnterpriseCode(this.LoadAreaGroupMasterInner);
			
			asyncLoad.BeginInvoke( strEnterpriseCode, new AsyncCallback( this.DlFinishAsyncCallBack ), asyncLoad );
			return true;
		}
		
		/// <summary>
		/// �񓯊��R�[���o�b�N�֐�
		/// </summary>
		/// <param name="iAsyncResult"></param>
		private void DlFinishAsyncCallBack( IAsyncResult iAsyncResult )
		{
			/*
			AsyncLoadFromEnterpriseCode asyncState = (AsyncLoadFromEnterpriseCode)iAsyncResult.AsyncState;
			
			asyncState.EndInvoke(iAsyncResult);
			
			OfflineDataDownloadEventArgs args = new OfflineDataDownloadEventArgs();
			
			//�Z���̊Ǘ��R�[�h��20001
			args.OfflineDataManageCode = 20001;
			
			//������ʒm
			this.dlFinishCallBack( this, args );
			*/
		}
		
		#endregion
		
		#endregion
		
		#region �Z���}�X�^�ǂݍ��݊֐�
		
		/// <summary>
		/// �w��Z���R�[�h�̏Z�����擾����
		/// ���ʃC���^�[�t�F�C�X���\�b�h
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="code2"></param>
		/// <param name="code3"></param>
		/// <param name="code4"></param>
		/// <param name="code5"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddressWork( int code1, long code2, int code3, int code4, int code5, out ArrayList alResult )
		{
			alResult = null;

			//�p�����[�^�쐬
			AddressWork awParam = new AddressWork();
			awParam.AddrConnectCd1 = code1;
			awParam.AddrConnectCd2 = (int)code2;
			awParam.AddrConnectCd3 = code3;
			awParam.AddrConnectCd4 = code4;
			awParam.AddrConnectCd5 = code5;
			
			int status = this.cacheManager.GetAddressWork( awParam, out alResult );

			return status;
		}
		
        /// <summary>
        /// �w��Z���R�[�h�̏Z�����擾����
        /// ���ʃC���^�[�t�F�C�X���\�b�h
        /// </summary>
        /// <param name="addrIndex"></param>
        /// <param name="alResult"></param>
        /// <returns></returns>
		public int GetAddressWork(AddressWork addrIndex, out ArrayList alResult)
		{
			alResult = null;
			int status = this.cacheManager.GetAddressWork( addrIndex, out alResult );
			
			return status;
		}
		
		/// <summary>
		/// ���ʃC���^�[�t�F�C�X���\�b�h
		/// </summary>
		/// <param name="intAddrConnectCd1"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddrIndexWork2( int intAddrConnectCd1, out ArrayList alResult)
		{
			alResult = null;
			int status = this.cacheManager.GetAddrIndexWork2( intAddrConnectCd1, out alResult );
			
			return status;
		}
		
		/// <summary>
		/// ���ʃC���^�[�t�F�C�X���\�b�h
		/// </summary>
		/// <param name="intAddrConnectCd1"></param>
		/// <param name="intAddrConnectCd2"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddrIndexWork3( int intAddrConnectCd1, long intAddrConnectCd2, out ArrayList alResult)
		{
			alResult = null;
			int status = this.cacheManager.GetAddrIndexWork3( intAddrConnectCd1, (int)intAddrConnectCd2, out alResult );

			return status;
		}
		
		/// <summary>
		/// ���ʃC���^�[�t�F�C�X���\�b�h
		/// </summary>
		/// <param name="intAddrConnectCd1"></param>
		/// <param name="intAddrConnectCd2"></param>
		/// <param name="intAddrConnectCd3"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddrIndexWork4( int intAddrConnectCd1, long intAddrConnectCd2, int intAddrConnectCd3, out ArrayList alResult)
		{
			alResult = null;
			int status = this.cacheManager.GetAddrIndexWork4( intAddrConnectCd1, (int)intAddrConnectCd2, intAddrConnectCd3, out alResult );

			return status;
		}
		
		/// <summary>
		/// ���ʃC���^�[�t�F�C�X���\�b�h
		/// </summary>
		/// <param name="intAddrConnectCd1"></param>
		/// <param name="intAddrConnectCd2"></param>
		/// <param name="intAddrConnectCd3"></param>
		/// <param name="intAddrConnectCd4"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddrIndexWork5( int intAddrConnectCd1, long intAddrConnectCd2, int intAddrConnectCd3, int intAddrConnectCd4, out ArrayList alResult)
		{
			alResult = null;
			int status = this.cacheManager.GetAddrIndexWork5( intAddrConnectCd1, (int)intAddrConnectCd2, intAddrConnectCd3, intAddrConnectCd4, out alResult );

			return status;
		}
		
		#endregion
				
		#region ���̑���L���b�V�������֐�
		
		#region �X�֔ԍ��������\�b�h
        /// <summary>
        /// �X�֔ԍ��������\�b�h
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="alResult"></param>
        /// <returns></returns>
        public int GetAddressWorkFromZipCd(string keyword, ref ArrayList alResult)
        {
            return this.cacheManager.GetAddressWorkFromZipCd( keyword, ref alResult );
        }
        /// <summary>
        /// �X�֔ԍ��������\�b�h
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="alResult"></param>
        /// <returns></returns>
		public int GetAddressWorkFromZipCd(string keyword, out ICollection alResult)
		{
            ArrayList result = null;

            int status = this.cacheManager.GetAddressWorkFromZipCd(keyword, ref result);

            alResult = result;

            return status;
		}
		
		#endregion
		
		#region �L�[���[�h�������\�b�h
        /// <summary>
        /// �L�[���[�h�������\�b�h
        /// </summary>
        /// <param name="areaGroupCode"></param>
        /// <param name="addrkey"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
		public int GetAddrFromName( int areaGroupCode, string addrkey, out ICollection resultList )
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            List<AddressWork> addressList = null;
            status = this.cacheManager.GetAddrFromName(areaGroupCode, addrkey, out addressList);

            resultList = addressList;

            return status;
		}
		
		#endregion
		/// <summary>
		/// �Z������
		/// </summary>
		/// <param name="addressCode1"></param>
		/// <param name="addressCode2"></param>
		/// <param name="addressCode3"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		public int GetAddressWorkFromAddressCode(int addressCode1, int addressCode2, int addressCode3, ref ArrayList alResult)
		{
			return this.cacheManager.GetAddressWorkFromAddressCode( addressCode1, addressCode2, addressCode3, ref alResult );
		}
		
		#endregion
		
		#region ���̑��C���^�[�t�F�C�X���\�b�h
		
		/// <summary>
		/// �\���O���b�h�����擾����
		/// </summary>
		public int DisplayGridCount
		{
			get
			{
				return 5;
			}
		}
		
		/// <summary>
		/// �X�e�[�^�X�o�[�\����������擾����
		/// </summary>
		public string StatusBarString
		{
			get
			{
				return "���T���̏Z���͌�����܂������H\r\n�s���������ɔ����A���T���̏Z����������Ȃ��ꍇ�ɂ͕ʂ̏Z�����{�^�����N���b�N���Ă��������B\r\n�ʂ̏Z�����ɂāA���T���̏Z�����������܂��B�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@�@";
			}
		}
		
		#endregion

        /// <summary>
        /// �n��O���[�v�̃X�^�e�B�b�N��������ݒ肷��
        /// </summary>
        /// <param name="areaGroupList"></param>
        public void SetAreaGroupStaticMemory(ArrayList areaGroupList)
        {
            //���̃N���X��Internal�Ȃ̂ł����ł��܂��B
            AddressInfoAreaGroupCacheAcs.SetAreaGroupStaticMemory(areaGroupList);
        }

	}
}
