using System;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;

namespace Broadleaf.Windows.Forms
{
	/// <summary>
	/// ZŠƒf[ƒ^ƒNƒ‰ƒX
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011@–ìŒû@’¨˜N</br>
	/// <br>Date       : 2006.01.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public class AddressData : ICloneable
	{
		private object target = null;
		
		private int _addressCode1Upper = 0;
		
		private int _addressCode1Lower = 0;
		
		private int _addressCode2 = 0;
		
		private int _addressCode3 = 0;
		
		private int _addrConnectCd4 = 0;
		
		private int _addrConnectCd5 = 0;
		
		private string _divAddress4 = "";
		
		private string _divAddress5 = "";
		
        /// <summary>
        /// ƒRƒ“ƒXƒgƒ‰ƒNƒ^
        /// </summary>
		public AddressData() : this( new AddressWork() )
		{
		}
		/// <summary>
		/// ƒRƒ“ƒXƒgƒ‰ƒNƒ^
		/// </summary>
		/// <param name="target"></param>
		public AddressData( object target )
		{
			this.target = target;
		}
		
		/// <summary>
		/// —X•Ö”Ô†‚ğæ“¾‚·‚é
		/// </summary>
		public string PostNo
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).PostNo;
				}
				return ((PostNumber)target).PostNo;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).PostNo = value;
				}
				else
				{
					((PostNumber)target).PostNo = value;
				}
			}
		}
		
		/// <summary>
		/// “s“¹•{Œ§ƒR[ƒh‚ğæ“¾‚·‚é
		/// </summary>
		public int AddressCode1Upper
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).AddressCode1Upper;
				}
				return _addressCode1Upper;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).AddressCode1Upper = value;
				}
				else
				{
					_addressCode1Upper = value;
				}
			}
		}
		
		/// <summary>
		/// s‹æŒSƒR[ƒh‚ğæ“¾‚·‚é
		/// </summary>
		public int AddressCode1Lower
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).AddressCode1Lower;
				}
				return _addressCode1Lower;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).AddressCode1Lower = value;
				}
				else
				{
					_addressCode1Lower = value;
				}
			}
		}
		
		/// <summary>
		/// ’¬‘ºƒR[ƒh‚ğæ“¾‚·‚é
		/// </summary>
		public int AddressCode2
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).AddressCode2;
				}
				return _addressCode2;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).AddressCode2 = value;
				}
				else
				{
					_addressCode2 = value;
				}
			}
		}
		
		/// <summary>
		/// šƒR[ƒh‚ğæ“¾‚·‚é
		/// </summary>
		public int AddressCode3
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).AddressCode3;
				}
				return _addressCode3;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).AddressCode3 = value;
				}
				else
				{
					_addressCode3 = value;
				}
			}
		}
		
		/// <summary>
		/// ZŠ–¼Ì‚ğæ“¾‚·‚é
		/// </summary>
		public string AddressName
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).AddressName;
				}
				return ((PostNumber)target).AddressName;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).AddressName = value;
				}
				else
				{
					((PostNumber)target).AddressName = value;
				}
			}

		}
		
		/// <summary>
		/// ZŠƒJƒi‚ğæ“¾‚·‚é
		/// </summary>
		public string AddressKana
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).AddressKana;
				}
				return ((PostNumber)target).AddressKana;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).AddressKana = value;
				}
				else
				{
					((PostNumber)target).AddressKana = value;
				}
			}

		}

		/// <summary>
		/// ZŠ˜AŒ‹ƒR[ƒh‚P‚ğæ“¾‚·‚é
		/// </summary>
		public int AddrConnectCd1
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).AddrConnectCd1;
				}
				return ((PostNumber)target).AddrConnectCd1;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).AddrConnectCd1 = value;
				}
				else
				{
					((PostNumber)target).AddrConnectCd1 = value;
				}
			}
		}
		
		/// <summary>
		/// ZŠ˜AŒ‹ƒR[ƒh‚Q‚ÉŠY“–‚·‚é‚à‚Ì‚ğæ“¾‚·‚é
		/// </summary>
		public long AddrConnectCd2
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).AddrConnectCd2;
				}
				return ((PostNumber)target).NlpoCode;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).AddrConnectCd2 = (int)value;
				}
				else
				{
					((PostNumber)target).NlpoCode = value;
				}
			}

		}

		/// <summary>
		/// ZŠ˜AŒ‹ƒR[ƒh‚R‚ÉŠY“–‚·‚é‚à‚Ì‚ğæ“¾‚·‚é
		/// </summary>
		public int AddrConnectCd3
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).AddrConnectCd3;
				}
				return ((PostNumber)target).TownAreaCode;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).AddrConnectCd3 = value;
				}
				else
				{
					((PostNumber)target).TownAreaCode = value;
				}
			}
		}
		
		/// <summary>
		/// ZŠ˜AŒ‹ƒR[ƒh‚S‚ÉŠY“–‚·‚é‚à‚Ì‚ğæ“¾‚·‚é
		/// </summary>
		public int AddrConnectCd4
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).AddrConnectCd4;
				}
				return _addrConnectCd4;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).AddrConnectCd4 = value;
				}
				else
				{
					_addrConnectCd4 = value;
				}
			}
		}
		
		/// <summary>
		/// ZŠ˜AŒ‹ƒR[ƒh‚T‚ÉŠY“–‚·‚é‚à‚Ì‚ğæ“¾‚·‚é
		/// </summary>
		public int AddrConnectCd5
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).AddrConnectCd5;
				}
				return _addrConnectCd5;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).AddrConnectCd5 = value;
				}
				else
				{
					_addrConnectCd5 = value;
				}
			}
		}
		
		/// <summary>
		/// •ªŠ„ZŠ–¼Ì‚P‚ğæ“¾‚·‚é
		/// </summary>
		public string DivAddress1
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).DivAddress1;
				}
				return ((PostNumber)target).ADOJpName;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).DivAddress1 = value;
				}
				else
				{
					((PostNumber)target).ADOJpName = value;
				}
			}
			
		}

		/// <summary>
		/// •ªŠ„ZŠ–¼Ì‚Q‚ğæ“¾‚·‚é
		/// </summary>
		public string DivAddress2
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).DivAddress2;
				}
				return ((PostNumber)target).MunicipalitiesName;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).DivAddress2 = value;
				}
				else
				{
					((PostNumber)target).MunicipalitiesName = value;
				}
			}
			
		}

		/// <summary>
		/// •ªŠ„ZŠ–¼Ì‚R‚ğæ“¾‚·‚é
		/// </summary>
		public string DivAddress3
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).DivAddress3;
				}
				return ((PostNumber)target).TownAreaName;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).DivAddress3 = value;
				}
				else
				{
					((PostNumber)target).TownAreaName = value;
				}
			}
		}

		/// <summary>
		/// •ªŠ„ZŠ–¼Ì‚S‚ğæ“¾‚·‚é
		/// </summary>
		public string DivAddress4
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).DivAddress4;
				}
				return _divAddress4;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).DivAddress4 = value;
				}
				else
				{
					_divAddress4 = value;
				}
			}
		}
		
		/// <summary>
		/// •ªŠ„ZŠ–¼Ì‚T‚ğæ“¾‚·‚é
		/// </summary>
		public string DivAddress5
		{
			get
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					return ((AddressWork)target).DivAddress5;
				}
				return _divAddress5;
			}
			set
			{
				if( target.GetType() == typeof( AddressWork ) )
				{
					((AddressWork)target).DivAddress5 = value;
				}
				else
				{
					_divAddress5 = value;
				}
			}
		}
		
		#region ICloneable ƒƒ“ƒo
		/// <summary>
		/// ƒNƒ[ƒ“æ“¾
		/// </summary>
		/// <returns></returns>
		public object Clone()
		{
			if( this.target.GetType() == typeof( AddressWork ) )
			{
				return new AddressData( ((AddressWork)this.target).Clone() );
			}
			else
			{
				return new AddressData( ((PostNumber)this.target).Clone() );
			}
		}
		
		#endregion
		
	}
	
}
