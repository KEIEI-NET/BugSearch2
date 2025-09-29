using System;
using System.Collections;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Application.Common;
using System.Collections.Generic;

namespace Broadleaf.Windows.Forms
{
	
	/// <summary>
	/// �Z���K�C�h�p�Z���A�N�Z�X�N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2006.01.11</br>
	/// <br></br>
	/// <br>Update Note: 2007.03.15 980076 �Ȓ��@����Y</br>
	/// <br>		   : �X�֔ԍ��K�C�h����ƂȂ�悤�ɕύX</br>
	/// </remarks>
	internal class MergedAddressAcs
	{
		private IMergeableAddressAcs iAddressAcs = null;
		
		private IMergeableAddressAcs offerAddressInfoAcs = null;
		
		private IMergeableAddressAcs postNumberAcs = null;
		
		public MergedAddressAcs()
		{
			this.offerAddressInfoAcs = new OfferAddressInfoAcs();
			this.postNumberAcs = new PostNumberAcs();
			
			//�f�t�H���g�ŏZ���}�X�^�A�N�Z�X�N���X
			//this.iAddressAcs = offerAddressInfoAcs;			// 2007.03.15 men del
			this.iAddressAcs = postNumberAcs;					// 2007.03.15 men add
		}
		
		/// <summary>
		/// �Z���A�N�Z�X�N���X�̃^�C�v
		/// </summary>
		public enum AddressAcsType
		{
			OfferAddressInfoAcs,
			PostNumberAcs
		}
		
		/// <summary>
		/// ���݂̃A�N�Z�X�N���X�̃^�C�v���擾����
		/// </summary>
		public AddressAcsType CurrentAcsType
		{
			get
			{
				if( this.iAddressAcs == this.offerAddressInfoAcs )
				{
					return AddressAcsType.OfferAddressInfoAcs;
				}
				else
				{
					return AddressAcsType.PostNumberAcs;
				}
			}
		}
		
		/// <summary>
		/// ���݂̃A�N�Z�X�N���X���`�F���W����
		/// </summary>
		public void SetNextAcs()
		{
			if( this.iAddressAcs == this.offerAddressInfoAcs )
			{
				this.iAddressAcs = this.postNumberAcs;
			}
			else
			{
				this.iAddressAcs = this.offerAddressInfoAcs;
			}
		}
		
		#region IMergeableAddressAcs �����o
		
        /// <summary>
        /// �Z������
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
			ArrayList alTmp = null;
			
			int status = this.iAddressAcs.GetAddressWork( code1, code2, code3, code4, code5, out alTmp );
			
			CreateData( alTmp, out alResult );
			
			return status;
		}

        /// <summary>
        /// �X�֔ԍ��ŏZ���擾
        /// </summary>
        /// <param name="keyword"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
		public int GetAddressWorkFromZipCd(string keyword, out List<AddressData> resultList )
		{
            ICollection collection = null;

			int status = this.iAddressAcs.GetAddressWorkFromZipCd( keyword,  out collection);
			
			//CreateData( alTmp, out alResult );
            CreateAddressDataList(collection, out resultList);

			return status;
		}
		
        //public int GetCountFromZipCd(string keyword, out int intCount)
        //{
        //    int status = this.iAddressAcs.GetCountFromZipCd( keyword, out intCount );
        //    return status;
        //}

        public int GetAddrFromName(int areaGroupCode, string addrkey, out List<AddressData> resultList)
		{
            ICollection collection = null;

            int status = this.iAddressAcs.GetAddrFromName(areaGroupCode, addrkey, out collection);

            CreateAddressDataList(collection, out resultList);

            return status;
		}
		
        //public int GetCountFromName(string addrkey, out int intCount)
        //{
        //    int status = this.iAddressAcs.GetCountFromName( addrkey, out intCount );
        //    return status;
        //}
		
		public int GetAddrIndexWork2(int code1, out ArrayList alResult)
		{
			ArrayList alTmp = null;
			
			int status = this.iAddressAcs.GetAddrIndexWork2( code1, out alTmp );
			
			CreateData( alTmp, out alResult );
			
			return status;
		}
		
		public int GetAddrIndexWork3(int code1, long code2, out ArrayList alResult)
		{
			ArrayList alTmp = null;

			int status = this.iAddressAcs.GetAddrIndexWork3( code1, code2, out alTmp );
			
			CreateData( alTmp, out alResult );
			
			return status;
		}
		
		public int GetAddrIndexWork4(int code1, long code2, int code3, out ArrayList alResult)
		{
			ArrayList alTmp = null;
			
			int status = this.iAddressAcs.GetAddrIndexWork4( code1, code2, code3, out alTmp );
			
			CreateData( alTmp, out alResult );

			return status;
		}
		
		public int GetAddrIndexWork5(int code1, long code2, int code3, int code4, out ArrayList alResult)
		{
			ArrayList alTmp = null;
			
			int status = this.iAddressAcs.GetAddrIndexWork5( code1, code2, code3, code4, out alTmp );
			
			CreateData( alTmp, out alResult );
			
			return status;
		}
		
        ///// <summary>
        ///// ���ݔ񓯊����[�h�����ǂ���
        ///// </summary>
        //public bool NowLoading
        //{
        //    get
        //    {
        //        return this.iAddressAcs.NowLoading;
        //    }
        //}
		
		/// <summary>
		/// �X�e�[�^�X�o�[�\����������擾����
		/// </summary>
		public string StatusBarString
		{
			get
			{
				return this.iAddressAcs.StatusBarString;
			}
		}
		
		/// <summary>
		/// �\���O���b�h�����擾����
		/// </summary>
		public int DisplayGridCount
		{
			get
			{
				return this.iAddressAcs.DisplayGridCount;
			}
		}
		
		#endregion
		
		/// <summary>
		/// ���[�N��ArrayList���璆�ԃf�[�^��ArrayList�����
		/// </summary>
		/// <param name="src"></param>
		/// <param name="dest"></param>
		public static void CreateData( ArrayList src, out ArrayList dest )
		{
			dest = new ArrayList();
			
			if( src == null )
			{
				return;
			}
			
			foreach( object obj in src )
			{
				dest.Add( new AddressData( obj ) );
			}
		}

        public static void CreateAddressDataList<T>(T srcList, out List<AddressData> destList) where T : ICollection
        {
            destList = new List<AddressData>();

            if (srcList == null)
            {
                return;
            }

            foreach (object src in srcList)
            {
                destList.Add(new AddressData(src));
            }
        }

	}

}
