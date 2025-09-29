using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller;
using System.Collections;
using Broadleaf.Application.UIData;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Broadleaf.Library.Data;
using System.IO;
using System.Xml.Serialization;
using System.Text;

using Broadleaf.Library.Resources;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using Broadleaf.Library.Collections;
using System.Threading;

namespace Broadleaf.Application.Common
{
	
	/// <summary>
	/// �L���b�V���ƃI�����C���I�t���C����Ԃ��Ǘ�����N���X
    /// �X���b�h�Z�[�t
	/// </summary>
	/// <remarks>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2005.06.03</br>
	/// <br></br>
	/// <br>Update Note: 2006.12.04 23011 �X���b�h�Z�[�t�Ή�</br>
	/// </remarks>
	internal class AddressGuideCacheManager
	{
		/// <summary>
		/// �����[�e�B���O�A�N�Z�X�p�C���^�[�t�F�C�X
		/// </summary>
		private static IOfferAddressInfo AddressInfo = null;
		
		/// <summary>
		/// �Z���}�X�^�̃L���b�V�������邽�߂�Hashtable
		/// �Z���A���R�[�h�P���C���f�b�N�X�ɂ��Ă���ɑΉ�����
		/// ����������ArrayList�������Ă�
		/// </summary>
		private static Hashtable htAddressMasterCache = null;
		
        /// <summary>
        /// �Ǐ����̃��b�N
        /// </summary>
        private static ReaderWriterLock _readerWriterLock = null;

		/// <summary>
		/// static�R���X�g���N�^
		/// </summary>
		static AddressGuideCacheManager()
		{
			//�Z�������[�g�I�u�W�F�N�g���擾
			AddressGuideCacheManager.AddressInfo = MediationOfferAddressInfo.GetOfferAddressInfo();
			
			//�Z���}�X�^�̃L���b�V���p�n�b�V���e�[�u��
			AddressGuideCacheManager.htAddressMasterCache = new Hashtable();

            //���b�N�N���X�̃C���X�^���X�쐬
            _readerWriterLock = new ReaderWriterLock();
		}

        /// <summary>
        /// �n��O���[�v�R�[�h�ŏZ���f�[�^�����[�h����
        /// </summary>
        /// <param name="areaGroupCode"></param>
        public void LoadAreaGroupFromAreaGroupCode(int areaGroupCode)
        {
            List<int> findTargetAreaList = new List<int>();

            //�ǋ�w��̏ꍇ
            //�R�[�h���O�ł��Ή��\
            List<AreaGroup> areaList = null;
            AddressInfoAreaGroupCacheAcs.GetAreaGroupPref(areaGroupCode, out areaList);

            for (int i = 0; i < areaList.Count; i++)
            {
                findTargetAreaList.Add(areaList[i].AreaCode);
            }

            long[] prefUpdateList = new long[findTargetAreaList.Count];

            for (int i = 0; i < findTargetAreaList.Count; i++)
            {
                AddressIndexManageAcs.GetLastUpdateTime(findTargetAreaList[i], out prefUpdateList[i]);
            }

            //�S�Ă̌������[�h����
            for (int index = 0; index < findTargetAreaList.Count; index++)
            {
                LoadArea(findTargetAreaList[index], prefUpdateList[index]);
            }

        }

        /// <summary>
        /// �n��R�[�h�w��œ����ǋ�ɏ�������n���S�ă��[�h����
        /// </summary>
        /// <param name="addrConnectCd1"></param>
        public void LoadAreaGroupFromAreaCode(int addrConnectCd1)
        {

            int areaGroupCode = 0;

            //�s���ȏZ���A���R�[�h�̏ꍇ
            if (addrConnectCd1 <= 0)
            {
                return;
            }

            //TODO : �����̏����𔲂����Ƃ������Ȃ����ȁH�����ł��Ȃ��H
            ////�w��ǋ�̏Z���f�[�^���L���b�V���ɂ���ꍇ�͂Ȃɂ����Ȃ�
            //if (AddressGuideCacheManager.htAddressMasterCache[addrConnectCd1] != null)
            //{
            //    return;
            //}

            //�n��O���[�v�R�[�h���擾
            if ((areaGroupCode = AddressInfoAreaGroupCacheAcs.GetAreaGroupCodeFromAreaCode(addrConnectCd1)) == 0)
            {
                return;
            }

            List<AreaGroup> alPref;

            //�ǋ�̌��ꗗ���擾
            AddressInfoAreaGroupCacheAcs.GetAreaGroupPref(areaGroupCode, out alPref);

            //���̃R�[�h�ꗗ���擾
            List<int> prefAddrConnectCd1List = new List<int>();

            foreach (AreaGroup pref in alPref)
            {
                prefAddrConnectCd1List.Add(pref.AreaCode);
            }

            //�X�V���X�g�擾
            long[] prefUpdateList = null;

            //���[�J�����\�[�X�ō�����
            prefUpdateList = new long[prefAddrConnectCd1List.Count];

            for (int i = 0; i < prefAddrConnectCd1List.Count; i++)
            {
                AddressIndexManageAcs.GetLastUpdateTime(prefAddrConnectCd1List[i], out prefUpdateList[i]);
            }

            //���ׂĂ̌������[�h����
            for (int index = 0; index < prefAddrConnectCd1List.Count; index++)
            {
                LoadArea(prefAddrConnectCd1List[index], prefUpdateList[index]);
            }

        }

        /// <summary>
        /// �w��Z���R�[�h�ŃL���b�V�������[�h����
        /// </summary>
        /// <param name="addressCode1"></param>
        public void LoadAreaFromAddressCode1(int addressCode1)
        {
            //�w��L�[���[�h�̗X�֔ԍ�����������\���̂��錧�����擾
            int[] prefAddrConnectCd1List = null;

            AddressIndexManageAcs.GetAddrConnectCd1(addressCode1, out prefAddrConnectCd1List);

            //�X�V���X�g�擾
            long[] prefUpdateList = null;

            //���[�J�����\�[�X�ō�����
            prefUpdateList = new long[prefAddrConnectCd1List.Length];

            //�X�V���t�擾
            for (int i = 0; i < prefAddrConnectCd1List.Length; i++)
            {
                AddressIndexManageAcs.GetLastUpdateTime(prefAddrConnectCd1List[i], out prefUpdateList[i]);
            }

            //�S�Ă̌����������Ƀ��[�h����
            for (int index = 0; index < prefAddrConnectCd1List.Length; index++)
            {
                LoadArea(prefAddrConnectCd1List[index], prefUpdateList[index]);
            }

        }

        /// <summary>
        /// �w�茧�̂�����ǋ�̏Z���}�X�^�����ׂă��[�h����B
        /// �L���b�V��������ꍇ�͂�����g��
        /// </summary>
        /// <param name="postNo"></param>
        public void LoadAreaFromPostNo(string postNo)
        {
            //�w��L�[���[�h�̗X�֔ԍ�����������\���̂��錧�����擾
            int[] prefAddrConnectCd1List = null;

            AddressIndexManageAcs.GetAddrConnectCd1(postNo, out prefAddrConnectCd1List);

            //�X�V���X�g�擾
            long[] prefUpdateList = null;

            //���[�J�����\�[�X�ō�����
            prefUpdateList = new long[prefAddrConnectCd1List.Length];

            //�X�V���t�擾
            for (int i = 0; i < prefAddrConnectCd1List.Length; i++)
            {
                AddressIndexManageAcs.GetLastUpdateTime(prefAddrConnectCd1List[i], out prefUpdateList[i]);
            }

            //�����������Ƀ��[�h����
            for (int index = 0; index < prefAddrConnectCd1List.Length; index++)
            {
                LoadArea(prefAddrConnectCd1List[index], prefUpdateList[index]);
            }
        }

        /// <summary>
        /// �����擾����
        /// �T�[�o�̃f�[�^�X�V���m�F����
        /// </summary>
        /// <param name="addressConnectCd1"></param>
        /// <param name="lastUpdate"></param>
        /// <returns></returns>
        private static void LoadArea(int addressConnectCd1, long lastUpdate)
        {
            object objMaster;
            ArrayList alMaster = null;
            AddressWork awIndex1 = new AddressWork();

            awIndex1.AddrConnectCd1 = addressConnectCd1;

            long cacheUpdate = 0;

            //�����݃��b�N�l��
            _readerWriterLock.AcquireWriterLock(Timeout.Infinite);

            try
            {
                //���Ƀ��[�h����Ă���Ȃ�Ζ߂�
                if (AddressGuideCacheManager.htAddressMasterCache.ContainsKey(addressConnectCd1))
                {
                    return;
                }

                //�L���b�V���̍ŏI�X�V���擾����
                AddressInfoCacheAcs.GetCacheUpdateTime(addressConnectCd1, out cacheUpdate);

                if (LoginInfoAcquisition.OnlineFlag)
                {

                    //�L���b�V���̓��t�ƃT�[�o�̍X�V���t���r
                    if (lastUpdate > cacheUpdate
                        || cacheUpdate == 0)
                    {
                        //--�L���b�V���X�V--
                        int status;

                        if ((status = AddressGuideCacheManager.AddressInfo.SearchAddressWork(awIndex1, out objMaster)) == (int)ConstantManagement.DB_Status.ctDB_NORMAL && objMaster != null)
                        {
                            CustomSerializeArrayList customSerializeArrayList = objMaster as CustomSerializeArrayList;

                            if (customSerializeArrayList != null && customSerializeArrayList.Count > 0)
                            {
                                alMaster = customSerializeArrayList[0] as ArrayList;

                                if (alMaster != null)
                                {
                                    //AddressWork�����o��
                                    AddressInfoCacheAcs.SerializeAddressWork(addressConnectCd1, lastUpdate, alMaster);
                                }
                            }
                        }
                        //-----------------
                    }
                }

                //�܂��f�[�^���擾�ł��Ă��Ȃ�������L���b�V������擾
                if (alMaster == null || alMaster.Count <= 0)
                {
                    alMaster = AddressInfoCacheAcs.DeSerializeAddressWork(addressConnectCd1);
                }

                //�f�[�^����ꂽ�烁�����̃L���b�V���ɒǉ�
                if (alMaster != null)
                {
                    //�����L�[�ɂ��ăL���b�V����Hashtable�ɕۑ�
                    AddressGuideCacheManager.htAddressMasterCache.Add(addressConnectCd1, alMaster);
                }
            }
            finally
            {
                //�����݃��b�N�J��
                _readerWriterLock.ReleaseWriterLock();
            }

        }
		
		#region �Z���}�X�^�̃L���b�V������w��AddressWork����������֐�
		
		/// <summary>
		/// �w��̏Z���A���R�[�h��
		/// �Y������Z���}�X�^�̏����擾����B
		/// </summary>
		/// <param name="addrIndex">�Z�����</param>
		/// <param name="alResult">���ʂ�����ArrayList</param>
		public int GetAddressWork(AddressWork addrIndex, out ArrayList alResult)
		{
			alResult = new ArrayList();
			
			//�Z���A���R�[�h�P�̎w�肪�Ȃ��ꍇ�͉������Ȃ�
			if( addrIndex.AddrConnectCd1 <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			
			//�Y������ǋ�̃f�[�^�����ׂă��[�h����
			this.LoadAreaGroupFromAreaCode( addrIndex.AddrConnectCd1 );
			
            //�Ǎ����b�N�l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);
            try
            {
                ArrayList alTarget = AddressGuideCacheManager.htAddressMasterCache[addrIndex.AddrConnectCd1] as ArrayList;

                if (alTarget == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                //�����ł������悤�ɂ���Ȋ����ɏ����Ă܂�

                //����
                if (addrIndex.AddrConnectCd2 <= 0)
                {
                    //�Z���}�X�^�P�Ȃ�OK
                    foreach (AddressWork aw in alTarget)
                    {
                        if ((aw.AddrConnectCd1 == addrIndex.AddrConnectCd1 && aw.AddrConnectCd1 > 0)
                            && aw.AddrConnectCd2 <= 0)
                        {
                            alResult.Add(aw);
                        }
                    }
                }
                else if (addrIndex.AddrConnectCd3 <= 0)
                {
                    foreach (AddressWork aw in alTarget)
                    {
                        if ((aw.AddrConnectCd1 == addrIndex.AddrConnectCd1 && aw.AddrConnectCd1 > 0)
                            && (aw.AddrConnectCd2 == addrIndex.AddrConnectCd2 && aw.AddrConnectCd2 > 0)
                            && aw.AddrConnectCd3 <= 0)
                        {
                            alResult.Add(aw);
                        }
                    }
                }
                else if (addrIndex.AddrConnectCd4 <= 0)
                {
                    foreach (AddressWork aw in alTarget)
                    {
                        if ((aw.AddrConnectCd1 == addrIndex.AddrConnectCd1 && aw.AddrConnectCd1 > 0)
                            && (aw.AddrConnectCd2 == addrIndex.AddrConnectCd2 && aw.AddrConnectCd2 > 0)
                            && (aw.AddrConnectCd3 == addrIndex.AddrConnectCd3 && aw.AddrConnectCd3 > 0)
                            && aw.AddrConnectCd4 <= 0)
                        {
                            alResult.Add(aw);
                        }
                    }
                }
                else if (addrIndex.AddrConnectCd5 <= 0)
                {
                    foreach (AddressWork aw in alTarget)
                    {
                        if ((aw.AddrConnectCd1 == addrIndex.AddrConnectCd1 && aw.AddrConnectCd1 > 0)
                            && (aw.AddrConnectCd2 == addrIndex.AddrConnectCd2 && aw.AddrConnectCd2 > 0)
                            && (aw.AddrConnectCd3 == addrIndex.AddrConnectCd3 && aw.AddrConnectCd3 > 0)
                            && (aw.AddrConnectCd4 == addrIndex.AddrConnectCd4 && aw.AddrConnectCd4 > 0)
                            && aw.AddrConnectCd5 <= 0)
                        {
                            alResult.Add(aw);
                        }
                    }
                }
                else
                {
                    foreach (AddressWork aw in alTarget)
                    {
                        if ((aw.AddrConnectCd1 == addrIndex.AddrConnectCd1 && aw.AddrConnectCd1 > 0)
                            && (aw.AddrConnectCd2 == addrIndex.AddrConnectCd2 && aw.AddrConnectCd2 > 0)
                            && (aw.AddrConnectCd3 == addrIndex.AddrConnectCd3 && aw.AddrConnectCd3 > 0)
                            && (aw.AddrConnectCd4 == addrIndex.AddrConnectCd4 && aw.AddrConnectCd4 > 0)
                            && (aw.AddrConnectCd5 == addrIndex.AddrConnectCd5 && aw.AddrConnectCd5 > 0))
                        {
                            alResult.Add(aw);
                        }
                    }
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		
		/// <summary>
		/// �Y������Z���C���f�b�N�X�}�X�^2�̏����擾����
		/// </summary>
        /// <param name="intAddrConnectCd1"></param>
        /// <param name="alResult"></param>
		public int GetAddrIndexWork2( int intAddrConnectCd1, out ArrayList alResult)
		{
			alResult = null;
			
			AddressIndex2WorkComparer comp = new AddressIndex2WorkComparer();
			
			//�Z���A���R�[�h�P�̎w�肪�Ȃ��ꍇ�͉������Ȃ�
			if( intAddrConnectCd1 <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			
			//�Y������ǋ�̃f�[�^�����ׂă��[�h����
			this.LoadAreaGroupFromAreaCode( intAddrConnectCd1 );
			
            //�Ǎ����b�N�l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                ArrayList alTarget = AddressGuideCacheManager.htAddressMasterCache[intAddrConnectCd1] as ArrayList;

                if (alTarget == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                alResult = new ArrayList();

                //����
                foreach (AddressWork aw in alTarget)
                {
                    if ((intAddrConnectCd1 == aw.AddrConnectCd1)
                        && aw.AddrConnectCd2 > 0)
                    {
                        if (alResult.BinarySearch(aw, comp) >= 0)
                        {
                            continue;
                        }
                        //TODO : �N���[������H
                        alResult.Add(aw);
                    }
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		/// <summary>
		/// �Y������Z���C���f�b�N�X�}�X�^3�̏����擾����
		/// </summary>
        /// <param name="intAddrConnectCd1"></param>
        /// <param name="intAddrConnectCd2"></param>
        /// <param name="alResult"></param>
		public int GetAddrIndexWork3( int intAddrConnectCd1, int intAddrConnectCd2, out ArrayList alResult)
		{
			AddressIndex3WorkComparer comp = new AddressIndex3WorkComparer();

			alResult = null;
			
			//�Z���A���R�[�h�P�̎w�肪�Ȃ��ꍇ�͉������Ȃ�
			if( intAddrConnectCd1 <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			
			//�Y������ǋ�̃f�[�^�����ׂă��[�h����
			this.LoadAreaGroupFromAreaCode( intAddrConnectCd1 );
			
            //�Ǎ����b�N�l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                ArrayList alTarget = AddressGuideCacheManager.htAddressMasterCache[intAddrConnectCd1] as ArrayList;

                if (alTarget == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                alResult = new ArrayList();

                //����
                foreach (AddressWork aw in alTarget)
                {
                    if ((aw.AddrConnectCd1 == intAddrConnectCd1)
                        && (aw.AddrConnectCd2 > 0 && aw.AddrConnectCd2 == intAddrConnectCd2)
                        && aw.AddrConnectCd3 > 0)
                    {
                        if (alResult.BinarySearch(aw, comp) >= 0)
                        {
                            continue;
                        }
                        //TODO : �N���[������H
                        alResult.Add(aw);
                    }
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		
		/// <summary>
		/// �Y������Z���C���f�b�N�X�}�X�^4�̏����擾����
		/// </summary>
        /// <param name="intAddrConnectCd1"></param>
        /// <param name="intAddrConnectCd2"></param>
        /// <param name="intAddrConnectCd3"></param>
        /// <param name="alResult"></param>
		public int GetAddrIndexWork4( int intAddrConnectCd1, int intAddrConnectCd2, int intAddrConnectCd3, out ArrayList alResult)
		{
			AddressIndex4WorkComparer comp = new AddressIndex4WorkComparer();
			alResult = null;
			
			//�Z���A���R�[�h�P�̎w�肪�Ȃ��ꍇ�͉������Ȃ�
			if( intAddrConnectCd1 <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			
			//�Y������ǋ�̃f�[�^�����ׂă��[�h����
			this.LoadAreaGroupFromAreaCode( intAddrConnectCd1 );
			
                        //�Ǎ����b�N�l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                ArrayList alTarget = AddressGuideCacheManager.htAddressMasterCache[intAddrConnectCd1] as ArrayList;

                if (alTarget == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                alResult = new ArrayList();

                //����
                foreach (AddressWork aw in alTarget)
                {
                    if ((aw.AddrConnectCd1 == intAddrConnectCd1)
                        && (aw.AddrConnectCd2 > 0 && aw.AddrConnectCd2 == intAddrConnectCd2)
                        && (aw.AddrConnectCd3 > 0 && aw.AddrConnectCd3 == intAddrConnectCd3)
                        && aw.AddrConnectCd4 > 0)
                    {
                        if (alResult.BinarySearch(aw, comp) >= 0)
                        {
                            continue;
                        }
                        alResult.Add(aw);
                    }
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		
		/// <summary>
		/// �Y������Z���C���f�b�N�X�}�X�^�̏����擾����
		/// </summary>
        /// <param name="intAddrConnectCd1"></param>
        /// <param name="intAddrConnectCd2"></param>
        /// <param name="intAddrConnectCd3"></param>
        /// <param name="intAddrConnectCd4"></param>
        /// <param name="alResult"></param>
		public int GetAddrIndexWork5( int intAddrConnectCd1, int intAddrConnectCd2, int intAddrConnectCd3, int intAddrConnectCd4, out ArrayList alResult)
		{
			AddressIndex5WorkComparer comp = new AddressIndex5WorkComparer();
			alResult = null;
			
			//�Z���A���R�[�h�P�̎w�肪�Ȃ��ꍇ�͉������Ȃ�
			if( intAddrConnectCd1 <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
			}
			
			//�Y������ǋ�̃f�[�^�����ׂă��[�h����
			this.LoadAreaGroupFromAreaCode( intAddrConnectCd1 );
			
            //�Ǎ����b�N�l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {
                ArrayList alTarget = AddressGuideCacheManager.htAddressMasterCache[intAddrConnectCd1] as ArrayList;

                if (alTarget == null)
                {
                    return (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND;
                }

                alResult = new ArrayList();

                //����
                foreach (AddressWork aw in alTarget)
                {
                    if ((aw.AddrConnectCd1 == intAddrConnectCd1)
                        && (aw.AddrConnectCd2 > 0 && aw.AddrConnectCd2 == intAddrConnectCd2)
                        && (aw.AddrConnectCd3 > 0 && aw.AddrConnectCd3 == intAddrConnectCd3)
                        && (aw.AddrConnectCd4 > 0 && aw.AddrConnectCd4 == intAddrConnectCd4)
                        && aw.AddrConnectCd5 > 0)
                    {
                        if (alResult.BinarySearch(aw, comp) >= 0)
                        {
                            continue;
                        }
                        alResult.Add(aw);
                    }
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

			return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
		}
		
		#endregion
		
		#region ��L���b�V�������֐�

		/// <summary>
		/// �X�֔ԍ��L�[���[�h�����p�֐�
		/// �L���b�V����Ή�
		/// </summary>
        /// <param name="postNoKeyword">�X�֔ԍ��̃L�[���[�h</param>
        /// <param name="resultList">���ʂ�����ArrayList</param>
		/// <returns>�G���[�R�[�h</returns>
        //[Obsolete("�X�֔ԍ������̓T�[�o�ւ̕��S�ƃ^�C���A�E�g�̂��ߎg�p���Ȃ��ł��������B", true )]
        public int GetAddressWorkFromZipCd(string postNoKeyword, ref ArrayList resultList)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;
            string searchKeyword = Strings.StrConv(postNoKeyword, VbStrConv.Narrow, 0);

            //�w��X�֔ԍ����������錧�����[�h����
            LoadAreaFromPostNo(searchKeyword);

            //�Ǎ����b�N�l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                resultList = new ArrayList();

                int[] targetAddrConnectCd1 = null;

                //�w��X�֔ԍ������݂���Z���̏Z���A���R�[�h���擾
                status = AddressIndexManageAcs.GetAddrConnectCd1(searchKeyword, out targetAddrConnectCd1);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //�����Ώۂ͑��݂���\��������ꏊ�̂�
                for (int i = 0; i < targetAddrConnectCd1.Length; i++)
                {
                    ArrayList list = htAddressMasterCache[targetAddrConnectCd1[i]] as ArrayList;

                    for (int j = 0; j < list.Count; j++)
                    {
                        AddressWork work = list[j] as AddressWork;

                        //�O����v����
                        if (work.PostNo.IndexOf(searchKeyword) == 0)
                        {
                            resultList.Add(work);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }

                ////�L���b�V�����璼����
                //foreach (ArrayList list in htAddressMasterCache.Values)
                //{
                //    for (int j = 0; j < list.Count; j++)
                //    {
                //        AddressWork work = list[j] as AddressWork;

                //        //�O����v����
                //        if (work.PostNo.IndexOf(keyword) == 0)
                //        {
                //            resultList.Add(work);
                //            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                //        }
                //    }
                //}
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

            return status;
		}
		
        #region �`���[�g�p���\�b�h

        /// <summary>
        /// �Z�����擾����
        /// </summary>
        /// <param name="postNoList"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public int ReadAddress(string[] postNoList, out AddressWork[] resultList)
        {
            resultList = null;

            if (postNoList == null || postNoList.Length <= 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            resultList = new AddressWork[postNoList.Length];

            for (int i = 0; i < postNoList.Length; i++)
            {
                AddressWork singleResult = null;

                ReadSingleAddress(postNoList[i], out singleResult);

                resultList[i] = singleResult;
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// �X�֔ԍ��Ɉ�v����Z�����ꌏ�擾����
        /// </summary>
        /// <param name="postNoKeyword"></param>
        /// <param name="addressWork"></param>
        /// <returns></returns>
        public int ReadSingleAddress(string postNoKeyword, out AddressWork addressWork)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            addressWork = null;

            //�w��X�֔ԍ��̏Z���ŊY������\����������̂����[�h����
            LoadAreaFromPostNo(postNoKeyword);

            //�Ǎ����b�N�l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                //�w��Z�����猟��
                int[] targetAddrConnectCd1 = null;

                //�w��X�֔ԍ������݂���Z���̏Z���A���R�[�h���擾
                status = AddressIndexManageAcs.GetAddrConnectCd1(postNoKeyword, out targetAddrConnectCd1);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //�����Ώۂ͑��݂���\��������ꏊ�̂�
                for (int i = 0; i < targetAddrConnectCd1.Length; i++)
                {
                    ArrayList list = htAddressMasterCache[targetAddrConnectCd1[i]] as ArrayList;

                    for (int j = 0; j < list.Count; j++)
                    {
                        AddressWork work = list[j] as AddressWork;

                        if (work.PostNo.IndexOf(postNoKeyword) >= 0)
                        {
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                            addressWork = work.Clone() as AddressWork;

                            return status;
                        }
                    }
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

            return status;

        }

        #endregion

        /// <summary>
        /// �Z�����擾
        /// </summary>
        /// <param name="areaGroupCode"></param>
        /// <param name="addrkey"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
        public int GetAddrFromName(int areaGroupCode, string addrkey, out List<AddressWork> resultList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            resultList = new List<AddressWork>();

            //�w��̒n������[�h����
            LoadAreaGroupFromAreaGroupCode(areaGroupCode);

            //�Ǎ����b�N�l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                string searchKeyword = Strings.StrConv(addrkey, VbStrConv.Katakana | VbStrConv.Narrow, 0);

                List<AreaGroup> findTargetList = null;

                AddressInfoAreaGroupCacheAcs.GetAreaGroupPref(areaGroupCode, out findTargetList);

                for (int i = 0; i < findTargetList.Count; i++)
                {
                    ArrayList list = htAddressMasterCache[findTargetList[i].AreaCode] as ArrayList;

                    for (int j = 0; j < list.Count; j++)
                    {
                        AddressWork work = list[j] as AddressWork;

                        if (work.AddressKana.IndexOf(searchKeyword) >= 0
                            || work.AddressName.IndexOf(searchKeyword) >= 0)
                        {

                            resultList.Add(work);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

            return status;
        }

		/// <summary>
		/// �Z���R�[�h����Z������������
		/// �I�t���C���Ή�
		/// </summary>
		/// <param name="addressCode1">�Z���R�[�h�P</param>
		/// <param name="addressCode2">�Z���R�[�h�Q</param>
		/// <param name="addressCode3">�Z���R�[�h�R</param>
		/// <param name="alResult">�Z���R�[�h�S</param>
		/// <returns>�G���[�R�[�h</returns>
		public int GetAddressWorkFromAddressCode(int addressCode1, int addressCode2, int addressCode3, ref ArrayList alResult)
		{
            int status = (int)ConstantManagement.DB_Status.ctDB_EOF;

            alResult = new ArrayList();

            //�w��Z���R�[�h�����[�h����
            LoadAreaFromAddressCode1(addressCode1);

            //�Ǎ����b�N�l��
            _readerWriterLock.AcquireReaderLock(Timeout.Infinite);

            try
            {

                int[] targetAddrConnectCd1 = null;

                //�w��X�֔ԍ������݂���Z���̏Z���A���R�[�h���擾
                status = AddressIndexManageAcs.GetAddrConnectCd1(addressCode1, out targetAddrConnectCd1);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return status;
                }

                //�L���b�V�����璼����
                for (int i = 0; i < targetAddrConnectCd1.Length; i++)
                {
                    ArrayList list = htAddressMasterCache[targetAddrConnectCd1[i]] as ArrayList;

                    for (int j = 0; j < list.Count; j++)
                    {
                        AddressWork work = list[j] as AddressWork;

                        if ((work.AddressCode1Upper * 1000 + work.AddressCode1Lower) == addressCode1
                            && work.AddressCode2 == addressCode2
                            && work.AddressCode3 == addressCode3)
                        {

                            alResult.Add(work);
                            status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
                        }
                    }
                }
            }
            finally
            {
                //�Ǎ����b�N�J��
                _readerWriterLock.ReleaseReaderLock();
            }

            return status;
		}
		
		#endregion
		
		#region �Z���f�[�^�N���X�p�R���p���[�^
		
		class AddressIndex2WorkComparer : IComparer
		{
			
			#region IComparer �����o
			
			public int Compare(object x, object y)
			{
				AddressWork a1 = x as AddressWork;
				AddressWork a2 = y as AddressWork;

				if( a1.AddrConnectCd1 > a2.AddrConnectCd1 )
				{
					return 1;
				}
				if( a1.AddrConnectCd1 < a2.AddrConnectCd1 )
				{
					return -1;
				}
				if( a1.AddrConnectCd2 > a2.AddrConnectCd2 )
				{
					return 1;
				}
				if( a1.AddrConnectCd2 < a2.AddrConnectCd2 )
				{
					return -1;
				}
				return 0;
			}
			
			#endregion
			
		}
		
		
		class AddressIndex3WorkComparer : IComparer
		{
			
			#region IComparer �����o
			
			public int Compare(object x, object y)
			{
				AddressWork a1 = x as AddressWork;
				AddressWork a2 = y as AddressWork;
				
				if( a1.AddrConnectCd1 > a2.AddrConnectCd1 )
				{
					return 1;
				}
				if( a1.AddrConnectCd1 < a2.AddrConnectCd1 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd2 > a2.AddrConnectCd2 )
				{
					return 1;
				}
				if( a1.AddrConnectCd2 < a2.AddrConnectCd2 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd3 > a2.AddrConnectCd3 )
				{
					return 1;
				}
				if( a1.AddrConnectCd3 < a2.AddrConnectCd3 )
				{
					return -1;
				}
				
				return 0;
			}
			
			#endregion
			
		}
		
		class AddressIndex4WorkComparer : IComparer
		{
			
			#region IComparer �����o
			
			public int Compare(object x, object y)
			{
				AddressWork a1 = x as AddressWork;
				AddressWork a2 = y as AddressWork;
				
				if( a1.AddrConnectCd1 > a2.AddrConnectCd1 )
				{
					return 1;
				}
				if( a1.AddrConnectCd1 < a2.AddrConnectCd1 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd2 > a2.AddrConnectCd2 )
				{
					return 1;
				}
				if( a1.AddrConnectCd2 < a2.AddrConnectCd2 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd3 > a2.AddrConnectCd3 )
				{
					return 1;
				}
				if( a1.AddrConnectCd3 < a2.AddrConnectCd3 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd4 > a2.AddrConnectCd4 )
				{
					return 1;
				}
				if( a1.AddrConnectCd4 < a2.AddrConnectCd4 )
				{
					return -1;
				}
				
				return 0;
			}
			
			#endregion
			
		}

		class AddressIndex5WorkComparer : IComparer
		{
			
			#region IComparer �����o
			
			public int Compare(object x, object y)
			{
				AddressWork a1 = x as AddressWork;
				AddressWork a2 = y as AddressWork;
				
				if( a1.AddrConnectCd1 > a2.AddrConnectCd1 )
				{
					return 1;
				}
				if( a1.AddrConnectCd1 < a2.AddrConnectCd1 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd2 > a2.AddrConnectCd2 )
				{
					return 1;
				}
				if( a1.AddrConnectCd2 < a2.AddrConnectCd2 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd3 > a2.AddrConnectCd3 )
				{
					return 1;
				}
				if( a1.AddrConnectCd3 < a2.AddrConnectCd3 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd4 > a2.AddrConnectCd4 )
				{
					return 1;
				}
				if( a1.AddrConnectCd4 < a2.AddrConnectCd4 )
				{
					return -1;
				}
				
				if( a1.AddrConnectCd5 > a2.AddrConnectCd5 )
				{
					return 1;
				}
				if( a1.AddrConnectCd5 < a2.AddrConnectCd5 )
				{
					return -1;
				}
				
				return 0;
			}
			
			#endregion
			
		}

		#endregion
		
	}

}
