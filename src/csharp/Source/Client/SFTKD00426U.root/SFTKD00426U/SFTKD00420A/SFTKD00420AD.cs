using System;
using System.Collections;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.IO;
using System.Xml.Serialization;
using System.Text;
using System.Xml;
using System.Windows.Forms;

using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.Remoting.Adapter;
using Broadleaf.Application.Controller;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Data;
using Broadleaf.Xml.Serialization;
using Broadleaf.Library.Resources;
using Broadleaf.Library.Runtime.Serialization;

namespace Broadleaf.Application.Common
{
	
	/// <summary>
	/// AddressWork�̃f�B�X�N�L���b�V�����o�͂����N���X
	/// </summary>
	/// <remarks>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2005.06.03</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	internal class AddressInfoCacheAcs
	{
		
		private readonly static string classID = "Broadleaf.Application.Common.OfferAddressInfoAcs";
		
		private static OfflineDataSerializer serializer = null;
		
		/// <summary>
		/// �X�V���t��ۑ�����w�b�_
		/// �L�[�ɏZ���A���R�[�h�P�A�l��AddressWork
		/// </summary>
		private static Hashtable headerCache = null;
		
		/// <summary>
		/// �X�^�e�B�b�N�R���X�g���N�^
		/// </summary>
		static AddressInfoCacheAcs()
		{
			serializer = new OfflineDataSerializer();

            headerCache = new Hashtable();

            //�L���b�V���̃w�b�_�����͂����œǂݏo���Ă���
            DeSerializeAddressWorkHeader(out headerCache);
		}
		
		#region �ǋ���o�̓��\�b�h
		
		#region Work����UIData�ϊ����\�b�h
		
		private static AreaGroup CopyWorkToData( AreaGroupWork work )
		{
			AreaGroup data = new AreaGroup();
			
			data.CreateDateTime			 = work.CreateDateTime;
			data.UpdateDateTime			 = work.UpdateDateTime;
			data.EnterpriseCode			 = work.EnterpriseCode;
			data.FileHeaderGuid			 = work.FileHeaderGuid;
			data.UpdEmployeeCode			 = work.UpdEmployeeCode;
			data.UpdAssemblyId1			 = work.UpdAssemblyId1;
			data.UpdAssemblyId2			 = work.UpdAssemblyId2;
			data.LogicalDeleteCode			 = work.LogicalDeleteCode;
			data.AreaKind			 = work.AreaKind;
			data.AreaGroupCode			 = work.AreaGroupCode;
			data.AreaCode			 = work.AreaCode;
			data.AreaName			 = work.AreaName;
			
			return data;
		}
		
		private static AreaGroupWork CopyDataToWork( AreaGroup data )
		{
			AreaGroupWork work = new AreaGroupWork();
			
			work.CreateDateTime			 = data.CreateDateTime;
			work.UpdateDateTime			 = data.UpdateDateTime;
			work.EnterpriseCode			 = data.EnterpriseCode;
			work.FileHeaderGuid			 = data.FileHeaderGuid;
			work.UpdEmployeeCode			 = data.UpdEmployeeCode;
			work.UpdAssemblyId1			 = data.UpdAssemblyId1;
			work.UpdAssemblyId2			 = data.UpdAssemblyId2;
			work.LogicalDeleteCode			 = data.LogicalDeleteCode;
			work.AreaKind			 = data.AreaKind;
			work.AreaGroupCode			 = data.AreaGroupCode;
			work.AreaCode			 = data.AreaCode;
			work.AreaName			 = data.AreaName;
			
			return work;
		}
		
		#endregion
		
		/// <summary>
		/// �ǋ����������
		/// </summary>
		/// <returns></returns>
		public static int SerializeAreaGroup( ArrayList alAreaGroup )
		{
			ArrayList alWork = new ArrayList();
			
			foreach( AreaGroup ag in alAreaGroup )
			{
				alWork.Add( CopyDataToWork( ag ) );
			}
			
			int status = serializer.Serialize( classID, new string[]{ "AREAGROUP", LoginInfoAcquisition.EnterpriseCode }, alWork );
			
			return status;
		}
		
		/// <summary>
		/// �ǋ�����[�h����
		/// </summary>
		/// <returns></returns>
		public static ArrayList DeSerializeAreaGroup()
		{
			object obj = serializer.DeSerialize( classID, new string[]{ "AREAGROUP", LoginInfoAcquisition.EnterpriseCode } );
			
			ArrayList alData = new ArrayList();
			
			ArrayList alWork = obj as ArrayList;
			
			if( alWork == null )
			{
				return null;
			}
			
			foreach( AreaGroupWork ag in alWork )
			{
				alData.Add( CopyWorkToData( ag ) );
			}
			
			return alData;
			
		}
		
		#endregion
		
		#region �X�V���t�Ǘ��p�w�b�_���o�̓��\�b�h

        /// <summary>
        /// �L���b�V���p�n�b�V���e�[�u������w�b�_�������o��
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        private static int SerializeAddressWorkHeader(Hashtable header)
        {
            //�f�[�^�Ȃ��Ȃ�߂�
            if (header == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            ArrayList alTmp = new ArrayList();

            //Hashtable����ArrayList�ɕϊ�
            foreach (AddressWork work in header.Values)
            {
                alTmp.Add(work);
            }

            //�f�[�^�Ȃ��Ȃ�߂�
            if (alTmp.Count <= 0)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            //��������
            return serializer.Serialize(classID, new string[] { "ADDRESS", "HEADER" }, alTmp);
        }

        /// <summary>
        /// �L���b�V���p�n�b�V���e�[�u���Ƀw�b�_��ǂݍ���
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        private static int DeSerializeAddressWorkHeader(out Hashtable header)
        {
            ArrayList alTmp = null;
            header = new Hashtable();

            alTmp = serializer.DeSerialize(classID, new string[] { "ADDRESS", "HEADER" }) as ArrayList;

            if (alTmp != null)
            {
                //ArrayList����Hashtable�ɕϊ�
                foreach (AddressWork work in alTmp)
                {
                    //�d������L�[�͂͂���
                    if (header.ContainsKey(work.AddrConnectCd1))
                    {
                        continue;
                    }
                    header.Add(work.AddrConnectCd1, work);
                }
            }

            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }

        /// <summary>
        /// �L���b�V���̍X�V�����擾����
        /// �X�V���t�̊Ǘ��͂��̃N���X�����ɉB�����Ƃ�
        /// </summary>
        /// <param name="addrConnectCd1"></param>
        /// <param name="lastUpdate"></param>
        /// <returns></returns>
        public static int GetCacheUpdateTime(int addrConnectCd1, out long lastUpdate)
        {
            lastUpdate = DateTime.MinValue.Ticks;

            if (!headerCache.ContainsKey(addrConnectCd1))
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            AddressWork work = headerCache[addrConnectCd1] as AddressWork;

            if (work == null)
            {
                return (int)ConstantManagement.DB_Status.ctDB_EOF;
            }

            lastUpdate = work.UpdateDateTime.Ticks;

            //try
            //{
            //    lastUpdate = long.Parse(work.PostNo);
            //}
            //catch
            //{
            //    return (int)ConstantManagement.DB_Status.ctDB_EOF;
            //}
            return (int)ConstantManagement.DB_Status.ctDB_NORMAL;
        }
		
		#endregion
		
		#region ����AddressWork���o�̓��\�b�h
		
		/// <summary>
		/// �w��n��R�[�h�̃f�[�^�������o��
		/// </summary>
        /// <param name="addrConnectCd1"></param>
        /// <param name="lastUpdateTicks"></param>
        /// <param name="alWork"></param>
		/// <returns></returns>
		public static int SerializeAddressWork( int addrConnectCd1, long lastUpdateTicks, ArrayList alWork )
		{
			int status = 0;
			
			//�f�[�^�������Ȃ�߂�
			if( alWork == null || alWork.Count <= 0 )
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}
			
			status = serializer.Serialize( classID, new string[]{ "ADDRESS", addrConnectCd1.ToString() }, alWork );
			
			//�������݂Ɏ��s������߂�
			if( status != (int)ConstantManagement.DB_Status.ctDB_NORMAL )
			{
				return (int)ConstantManagement.DB_Status.ctDB_EOF;
			}

            AddressWork work = null;

            //�w�b�_�����݂��邩�m�F
            if (headerCache.ContainsKey(addrConnectCd1))
            {
                work = headerCache[addrConnectCd1] as AddressWork;
            }
            else
            {
                work = new AddressWork();
                work.AddrConnectCd1 = addrConnectCd1;

                //�w�b�_�ɒǉ����Ƃ�
                headerCache.Add(addrConnectCd1, work);
            }

            //�X�V���t������Ƃ����Ȃ��̂ŗX�֔ԍ��̂Ƃ��ɓ���Ƃ�
            //work.PostNo = lastUpdateTicks.ToString();
            work.UpdateDateTime = new DateTime(lastUpdateTicks);

            //�w�b�_��������
            SerializeAddressWorkHeader(headerCache);
			
			return status;
		}
		
		/// <summary>
		/// �w��n��R�[�h�̃f�[�^��ǂݏo��
		/// </summary>
        /// <param name="addrConnectCd1"></param>
		/// <returns></returns>
		public static ArrayList DeSerializeAddressWork( int addrConnectCd1 )
		{
			return serializer.DeSerialize( classID, new string[]{ "ADDRESS", addrConnectCd1.ToString() } ) as ArrayList;
		}
		
		#endregion
		
		#region ���[�h�̃L���b�V���֘A�̃��\�b�h
		
        ///// <summary>
        ///// ���[�h�̃L���b�V����ۑ�����
        ///// </summary>
        ///// <param name="htAddressWork"></param>
        ///// <returns></returns>
        //public static int SerializeAddressWorkReadCache( Hashtable htAddressWork )
        //{
        //    ArrayList alTmp = new ArrayList();
			
        //    if( htAddressWork != null )
        //    {
        //        foreach( AddressWork awTmp in htAddressWork.Values )
        //        {
        //            alTmp.Add( awTmp );
        //        }
        //    }
        //    return serializer.Serialize( classID, new string[]{ "READCACHE" }, alTmp );
        //}
		
        ///// <summary>
        ///// ���[�h�̃L���b�V�������o��
        ///// </summary>
        ///// <returns></returns>
        //public static Hashtable DeSerializeAddressWorkReadCache()
        //{
        //    Hashtable htTmp = new Hashtable();
			
        //    ArrayList alTmp = serializer.DeSerialize( classID, new string[]{ "READCACHE" } ) as ArrayList;
			
        //    if( alTmp == null )
        //    {
        //        return htTmp;
        //    }
			
        //    foreach( AddressWork awTmp in alTmp )
        //    {
        //        htTmp.Add( AddressInfoCacheAcs.CreateReadCacheHashKey( awTmp ), awTmp );
        //    }
			
        //    return htTmp;
        //}
		
        ///// <summary>
        ///// ���[�h�̃L���b�V���p�L�[�쐬���\�b�h
        ///// </summary>
        ///// <param name="addressCode1"></param>
        ///// <param name="addressCode2"></param>
        ///// <param name="addressCode3"></param>
        ///// <returns></returns>
        //public static string CreateReadCacheHashKey( AddressWork awTmp )
        //{
        //    return CreateReadCacheHashKey( int.Parse( String.Format("{0:D2}{1:D3}", awTmp.AddressCode1Upper, awTmp.AddressCode1Lower ) ), awTmp.AddressCode2, awTmp.AddressCode3 );
        //}
		
        //public static string CreateReadCacheHashKey( int addressCode1, int addressCode2, int addressCode3 )
        //{
        //    return addressCode1.ToString()
        //        + "_"
        //        + addressCode2.ToString()
        //        + "_"
        //        + addressCode3.ToString();
        //}
		
		#endregion
		
	}
}
