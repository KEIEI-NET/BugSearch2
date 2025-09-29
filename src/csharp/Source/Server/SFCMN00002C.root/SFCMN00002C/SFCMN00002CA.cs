//**********************************************************************//
// System           :   SuperFrontman                                   //
// Sub System       :                                                   //
// Program name     :   ���t�����N���X                                  //
//                  :   Broadleaf.SFLibrary.Globarization               //
// Name Space       :   Broadleaf.                                      //
// Programer        :   R.Sokei                                         //
// Date             :   2004.12.04                                      //
//----------------------------------------------------------------------//
// Update Note      :   2009.05.29 21027 T.Sugawa                       //
//                  :   1.���a64�N �� ����1�N�ƂȂ�悤�ɏC��           //
//                  :     [���a]�`1989.01.07�A[����]1989.01.08�`        //
//                  :   2012.03.30 nogchi VSS566                        //
//                  :     �������Ή�                                    //
//                  :   2018.12.19 31983 S.Tomohiro                     //
//                  :     �V�����Ή��ɍ��킹�A.NET Framework�Ɉ˂�Ȃ�  //
//                  :     ���������t�̕ϊ��ɑΉ�                      //
//                  :     ���킹�Č�������XML�ێ��ɑΉ�               //
//                  :     ��ʓ��t���ڂ̃t�H�[�}�b�g��XML�ێ��ɑΉ�     //
//----------------------------------------------------------------------//
//                 Copyright(c)2004 Broadleaf Co.,Ltd.                  //
//**********************************************************************//
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Broadleaf.Library.Globarization
{

	/// <summary>
	/// <see cref="TDateTime"/>TDateTime�N���X�ŗ��p����񋓑̂ł��B
	/// TDateTime�ŗ��p����DateTime�^�̓����`�����`���܂�
	/// </summary>
	/// <remarks>
	/// <br><see cref="TDateTimeFormat"/>TDateTime�ŗ��p����DateTime�^�̓����`�����`���܂�</br>
	/// </remarks>
	public enum TDateTimeFormat : int
	{
		/// <summary>
		/// "YYYYMMDD"�̌`��(��: 20050301)
		/// </summary>
		df4Y2M2D = 1,
		/// <summary>
		/// "YYMMDD"�̌`��(��: 050301)
		/// </summary>
		df2Y2M2D = 2,
		/// <summary>
		/// (�a��)GGYYMMDD�̌`��(��: 170301)
		/// </summary>
		dfG2Y2M2D = 31,
		/// <summary>
		/// YYYY�NMM���̌`��
		/// </summary>
		df4Y2M = 4,
		/// <summary>
		/// YY�NMM���̌`��
		/// </summary>
		df2Y2M = 5,
		/// <summary>
		/// ����YY�NMM���̌`��
		/// </summary>
		dfG2Y2M = 32,
		/// <summary>
		/// MM��DD���̌`��
		/// </summary>
		df2M2D = 6,
		/// <summary>
		/// YYYY�N�̌`��
		/// </summary>
		df4Y = 7,
		/// <summary>
		/// MM���̌`��
		/// </summary>
		df2Y = 8,
		/// <summary>
		/// ����YY�N�̌`��
		/// </summary>
		dfG2Y = 33,
		/// <summary>
		/// MM���̌`��
		/// </summary>
		df2M = 9,
		/// <summary>
		/// DD���̌`��
		/// </summary>
		df2D = 10
	}

	/// <summary>
	/// <see cref="TDateTime"/>TDateTime�N���X�ŗ��p����񋓑̂ł��B
	/// TDateTime�ň������t�^�𕶎���ɕϊ�����ۂ̏o�͌`�����`���܂�
	/// </summary>
	/// <remarks>
	/// <br><see cref="TDateTimeStringFormat"/>TDateTime�ň������t�^�𕶎���ɕϊ�����ۂ̏o�͌`�����`���܂�</br>
	/// </remarks>
	public enum TDateTimeStringFormat : int
	{
		//	case "YYYYMMDD":
		/// <summary>
		/// "YYYY�NMM��DD��"�̌`��(��: "2005�N03��01��")
		/// "YYYYMMDD"
		/// </summary>
		df4Y2M2D = 0,

		//	case "YYMMDD":
		/// <summary>
		/// "YY�NMM��DD��"�̌`��(��: "05�N03��01��")
		/// "YYMMDD":
		/// </summary>
		df2Y2M2D = 1,

		//	case "GGYYMMDD":
		/// <summary>
		/// ����YY�NMM��DD���̌`��(��: "����17�N03��01��")
		/// "GGYYMMDD":
		/// </summary>
		dfG2Y2M2D = 2,

		//	case "YYYYMM":
		/// <summary>
		/// YYYY�NMM���̌`��(��: "2005�N03��")
		/// "YYYYMM":
		/// </summary>
		df4Y2M = 3,
		/// <summary>
		/// xx�Nxx���̌`��
		/// </summary>
		df2Y2M = 4,
		/// <summary>
		/// ����xx�Nxx��xx���̌`��
		/// </summary>
		dfG2Y2M = 5,
		/// <summary>
		/// xx��xx���̌`��
		/// </summary>
		df2M2D = 6,
		/// <summary>
		/// xxxx�N�̌`��
		/// </summary>
		df4Y = 7,
		/// <summary>
		/// xx���̌`��
		/// </summary>
		df2Y = 8,
		/// <summary>
		/// ����xx�N�̌`��
		/// </summary>
		dfG2Y = 9,
		/// <summary>
		/// xx���̌`��
		/// </summary>
		df2M = 10,
		/// <summary>
		/// xx���̌`��
		/// </summary>
		df2D = 11

		//	case "GGyymmdd":
		//	case "ggYYMMDD":
		//	case "ggyymmdd":
		//	case "GGYYMM":
		//	case "GGyymm":
		//	case "GGYY":
		//	case "GGyy":
		//	case "ggYYMM":
		//	case "ggyymm":
		//	case "ggYY":
		//	case "YYYYmmdd":
		//	case "yyyymmdd":
		//	case "YYYYmm":
		//	case "MMDD":
		//	case "YYYY":
		//	case "MM":
		//	case "DD":
		//	case "YYYY/MM/DD":
		//	case "YYYY/mm/dd":
		//	case "YY/MM/DD":
		//	case "YYYY.MM.DD":
		//	case "YYYY.mm.dd":
		//	case "YY.MM.DD":
		//	case "GGYY/MM/DD":
		//	case "GGyy/mm/dd":
		//	case "ggYY/MM/DD":
		//	case "ggyy/mm/dd":
		//	case "GGYY.MM.DD":
		//	case "GGyy.mm.dd":
		//	case "GGYY.MM":
		//	case "GGyy.mm":
		//	case "GGYY/MM":
		//	case "ggYY.MM.DD":
		//	case "ggyy.mm.dd":
		//	case "ggYY.MM":
		//	case "ggyy.mm":
		//	case "HHMMSS":
		//	case "HHMM":
		//	case "HH":
		//	case "HH:MM:SS":
		//	case "HH:MM":
	}

	/// <summary>
	/// LongDate�`�����t�̕ҏW���@
	/// </summary>
	public enum TLongDateEditor
	{
		/// <summary>
		/// �ҏW����
		/// </summary>
		Non,
		/// <summary>
		/// �[���T�v���X
		/// </summary>
		ZeroSuppress
	}

    /// <summary>
    /// �������X�g�擾���̃��[�h�B�ǂ̌����ȍ~���擾���邩�̐ݒ�Ɏg�p����B
    /// �����΂炭�͕����ȍ~��\�����邱�Ƃ����Ȃ��Ǝv���邽�߁A
    /// �@2019�N�V�����ȍ~���擾���郂�[�h�͒ǉ����Ă��܂���B
    /// �@�K�v������ꍇ�Ƀ��[�h�̒ǉ����s���Ă��������B
    /// </summary>
    public enum TDateTimeGengouMode : int
    {
        /// <summary>
        /// �f�t�H���g�F0
        /// �i�ʏ�͖����ȍ~���擾���郂�[�h�Ɠ����œ��삵�܂����ATDateEdit�̂悤�ɕ����ȍ~���O��Ƃ����悤�ȏꍇ��
        /// �@�Ăяo�����œK�؂ȃ��[�h�ɕύX���Ă��������j
        /// </summary>
        Default = 0,
        /// <summary>
        /// �����ȍ~���擾���郂�[�h�F1
        /// </summary>
        StartsWithMeiji = 1,
        /// <summary>
        /// �吳�ȍ~���擾���郂�[�h�F2
        /// </summary>
        StartsWithTaisho = 2,
        /// <summary>
        /// ���a�ȍ~���擾���郂�[�h�F3
        /// </summary>
        StartsWithShowa = 3,
        /// <summary>
        /// �����ȍ~���擾���郂�[�h�F4
        /// </summary>
        StartsWithHeisei = 4,
    }

    /// <summary>
    /// �����f�[�^�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : XML����ǂݍ��񂾌����̏���ێ�����N���X�ł��B</br>
    /// <br>Programmer : 31983 �F�A �^��</br>
    /// <br>Date       : 2018.12.12</br>
    /// </remarks>
    public class EraInfo
    {
        /// <summary>
        /// �������i��F�����j
        /// </summary>
        private string _eraName;
        /// <summary>
        /// �������́i��F���j
        /// </summary>
        private string _eraShortName;
        /// <summary>
        /// �����啶���������i��FH�j
        /// </summary>
        private string _eraUpperInitial;
        /// <summary>
        /// �����������������i��Fh�j
        /// </summary>
        private string _eraLowerInitial;
        /// <summary>
        /// �����J�n��
        /// </summary>
        private DateTime _startDate;
        /// <summary>
        /// �����I�����i���s�̌����̏ꍇ�́ADateTime.MaxValue��ݒ�j
        /// </summary>
        private DateTime _endDate;

        /// <summary>
        /// �������i��F�����j
        /// </summary>
        public string EraName
        {
            get { return this._eraName; }
            set { this._eraName = value; }
        }

        /// <summary>
        /// �������́i��F���j
        /// </summary>
        public string EraShortName
        {
            get { return this._eraShortName; }
            set { this._eraShortName = value; }
        }

        /// <summary>
        /// �����啶���������i��FH�j
        /// </summary>
        public string EraUpperInitial
        {
            get { return this._eraUpperInitial; }
            set { this._eraUpperInitial = value; }
        }

        /// <summary>
        /// �����������������i��Fh�j
        /// </summary>
        public string EraLowerInitial
        {
            get { return this._eraLowerInitial; }
            set { this._eraLowerInitial = value; }
        }

        /// <summary>
        /// �����J�n��
        /// </summary>
        public DateTime StartDate
        {
            get { return this._startDate; }
            set { this._startDate = value; }
        }

        /// <summary>
        /// �����I����
        /// </summary>
        public DateTime EndDate
        {
            get { return this._endDate; }
            set { this._endDate = value; }
        }

        /// <summary>
        /// ���݂̌������ۂ�
        /// </summary>
        public bool IsPresentEra
        {
            get { return (_startDate <= DateTime.Today) && (DateTime.Today <= _endDate); }
        }

        /// <summary>
        /// ����a��N�ϊ����̊�N
        /// �i�J�n�N��1�N�O�B������N���������ƂŘa��N���Z�o����j
        /// </summary>
        public int BaseYear
        {
            get { return _startDate.Year - 1; }
        }
    }

    /// <summary>
    /// �e�t�H�[���̃t�H�[�}�b�g���
    /// </summary>
    public class FormDateFormatInfo
    {
        /// <summary>
        /// �t�H�[����
        /// </summary>
        private string _formName;
        /// <summary>
        /// 
        /// </summary>
        private DateFormatInfo[] _dateFormatInfoArray;

        /// <summary>
        /// �t�H�[����
        /// </summary>
        public string FormName
        {
            get { return _formName; }
            set { _formName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateFormatInfo[] DateFormatInfoArray
        {
            get { return _dateFormatInfoArray; }
            set { _dateFormatInfoArray = value; }
        }
    }

    /// <summary>
    /// �e�R���|�[�l���g�̓��t�t�H�[�}�b�g���
    /// </summary>
    public class DateFormatInfo
    {
        /// <summary>
        /// �R���|�[�l���g��
        /// </summary>
        private string _componentName;

        /// <summary>
        /// ���t�t�H�[�}�b�g
        /// </summary>
        private string _dateFormat;

        /// <summary>
        /// �R���|�[�l���g����
        /// </summary>
        public string ComponentName
        {
            get { return _componentName; }
            set { _componentName = value; }
        }
        /// <summary>
        /// ���t�t�H�[�}�b�g
        /// </summary>
        public string DateFormat
        {
            get { return _dateFormat; }
            set { _dateFormat = value; }
        }
    }


	/// <summary>
	/// ���t��������N���X
	/// </summary>
	/// <remarks>
	/// <br>Note       :  ���t,�����Ɋ֘A����e�푀���񋟂��܂�</br>
	/// <br>Programmer : 980056 R.Sokei</br>
	/// <br>Date       : 2004.11.27</br>
	/// <br></br>
	/// </remarks>
	public class TDateTime
	{
		private const int ctYearDef = 19000000;		// YYYY --> 1900
		private const int ctMonthDayDef = 101;		// MMDD --> 0101

        /// <summary>
        /// ��������XML�t�@�C��
        /// </summary>
        private const string ERAINFO_XML_FILENAME = "ERAINFO.xml";
        /// <summary>
        /// ���t�t�H�[�}�b�g����XML�t�@�C��
        /// </summary>
        private const string DATETIMEFORMATINFO_XML_FILENAME = "DATETIMEFORMATINFO.xml";
        /// <summary>
        /// �������
        /// </summary>
        private static ArrayList _eraInfoList = new ArrayList();
        /// <summary>
        /// �������X�g
        /// </summary>
        private static ArrayList _eraNameList = new ArrayList();
        /// <summary>
        /// ���t�t�H�[�}�b�g��񃊃X�g
        /// </summary>
        private static Dictionary<string, Dictionary<string, string>> _formDateTimeFormat = null;

		/// **********************************************************************
		/// Module name      : xDateTime
		/// <summary>
		///                    ���t�����N���X�R���X�g���N�^
		/// </summary>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���t�����N���X�R���X�g���N�^</br>
		/// <br>Programer        :   R.Sokei                     </br>
		/// <br>Date             :   2004.12.04                  </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		private TDateTime()
		{
			//
			// �����o���S�� static �Ȃ̂ŁA�C���X�^���X����������Ȃ��悤�ɂ���
			//
		}

		// �V�X�e�����t�̎擾(SF.NET)
		// �V�X�e���������擾����(SF.NET)
		/// **********************************************************************
		/// Module name      : GetSFDateNow
		/// <summary>
		///                    SF.NET�V�X�e���Œ�`����Ă���V�X�e�����t
		///                    ���擾���܂�(SF.NET�V�X�e�����t)
		/// </summary>
		/// <returns>
		///                    SF�V�X�e�����t(DateTime�^)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SF.NET�V�X�e���̌��݂̓��t�Ǝ������擾���܂�</br>
		/// <br>Programer        :   R.Sokei                                     </br>
		/// <br>Date             :   2004.12.06                                  </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static DateTime GetSFDateNow()
		{
			// ���[�J�[�V�X�e�����ŃT�[�o�������g�p����K�v������ꍇ�́A
			// �ȉ��̋L�q��ύX���ăT�[�o������Ԃ��悤�ɕύX���Ă�������

			DateTime myDateTime = DateTime.Now;
			return myDateTime;
		}

		// �V�X�e�����t�̎擾(SF.NET)(YYYYMMDD)
		// �V�X�e���������擾����(SF.NET)(HHMMDD)
		/// **********************************************************************
		/// Module name      : GetSFDateNow
		/// <summary>
		///                    SF.NET�V�X�e���Œ�`����Ă���V�X�e�����t
		///                    ���擾���܂�(SF.NET�V�X�e�����t)
		/// </summary>
		/// <param name="dateFormat">
		///                    ���t�t�H�[�}�b�g�`��
		/// </param>
		/// <returns>
		///                    SF�V�X�e�����t(Int�^)(YYYYMMDD�`��)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   SF�V�X�e���̌��݂̓��t���擾����</br>
		/// <br>                     �߂�l�́A�w�肳�ꂽ�`��(YYYYMMDD,YYYYMM���)��int�^��Ԃ�</br>
		/// <br>Programer        :   R.Sokei                         </br>
		/// <br>Date             :   2004.12.06                      </br>
		/// <br>Update Note      :                 </br>
		/// </remarks>
		/// **********************************************************************
		public static int GetSFDateNow(string dateFormat)
		{
			// ���[�J�[�V�X�e�����ŃT�[�o�������g�p����K�v������ꍇ�́A
			// �ȉ��̋L�q��ύX���ăT�[�o������Ԃ��悤�ɕύX���Ă�������

			// ���݂̓��t�������擾
			DateTime myDateTime = DateTime.Now;
			int ldate = 0;
			switch (dateFormat.Trim().ToUpper())
			{
				case "YYYYMMDD":
					{
						// ���t��YYYYMMDD�`���ɕϊ�
						ldate = DateTimeToLongDate(myDateTime);
						break;
					}
				case "YYYYMM":
					{
						// ���t��YYYYMMDD�`���ɕϊ�
						ldate = DateTimeToLongDate("YYYYMM", myDateTime);
						break;
					}
				case "YYYY":
					{
						// ���t��YYYYMMDD�`���ɕϊ�
						ldate = DateTimeToLongDate("YYYY", myDateTime);
						break;
					}
				case "MM":
					{
						// ���t��YYYYMMDD�`���ɕϊ�
						ldate = DateTimeToLongDate("MM", myDateTime);
						break;
					}
				case "DD":
					{
						// ���t��YYYYMMDD�`���ɕϊ�
						ldate = DateTimeToLongDate("DD", myDateTime);
						break;
					}
				case "HHMMSS":
					{
						ldate = DateTimeToLongDate("HHMMSS", myDateTime);
						break;
					}
			}

			return ldate;
		}

		// LongDate�^(YYYYMMDD) -> DateTime�^�ɕϊ�
		/// **********************************************************************
		/// Module name      : LongDateToDateTime
		/// <summary>
		///                    LongDate�^(YYYYMMDD)�̓��t��DateTime�^�ɕϊ����܂�
		/// </summary>
		/// <param name="inLongDate">
		///                    �ϊ��Ώۓ��t(LonDate�`��)
		/// </param>
		/// <returns>
		///                    ���t�ϊ�����(DateTime�^)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <list type="bullet">
		/// <item>longDateFormat�`�� : �ϊ���(���͂�2004/12/10�̏ꍇ)</item>
		/// <item>YYYYMMDD : 20041210</item>
		/// <item>YYYYMM   : 200412</item>
		/// <item>YYMMDD   : 041210</item>
		/// <item>MMDD     : 1210</item>
		/// </list>
		/// <br>Note�@�@�@�@�@�@ :   LongDate�`��(YYYYMMDD)�̓��t��DateTime�^�ɕϊ�����</br>
		/// <br>Programer        :   R.Sokei                                    </br>
		/// <br>Date             :   2004.12.06                                      </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static DateTime LongDateToDateTime(int inLongDate)
		{
			return LongDateToDateTime("YYYYMMDD", inLongDate);
		}

		// LongDate�^(YYYYMMDD) -> DateTime�^�ɕϊ�
		/// **********************************************************************
		/// Module name      : LongDateToDateTime
		/// <summary>
		///                    LongDate�^(YYYYMMDD)�̓��t��DateTime�^�ɕϊ����܂�
		/// </summary>
		/// <param name="longDateFormat">
		///                    LongDate���t�t�H�[�}�b�g�`��
		/// </param>
		/// <param name="inLongDate">
		///                    �ϊ��Ώۓ��t(LonDate�`��)
		/// </param>
		/// <returns>
		///                    ���t�ϊ�����(DateTime�^)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <list type="bullet">
		/// <item>longDateFormat�`�� : �ϊ���(���͂�2004/12/10�̏ꍇ)</item>
		/// <item>YYYYMMDD : 20041210</item>
		/// <item>YYYYMM   : 200412</item>
		/// <item>YYMMDD   : 041210</item>
		/// <item>MMDD     : 1210</item>
		/// </list>
		/// <br>Note�@�@�@�@�@�@ :   LongDate�`��(YYYYMMDD)�̓��t��DateTime�^�ɕϊ�����</br>
		/// <br>Programer        :   R.Sokei                                    </br>
		/// <br>Date             :   2004.12.06                                      </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static DateTime LongDateToDateTime(string longDateFormat, int inLongDate)
		{
			DateTime tmpDateTime = new DateTime(0);
			if (inLongDate > 0)
			{
				try
				{
					// LongDate�`���̒l�`�F�b�N

					// LongDate-->String�ɕϊ�
					string sStrDate = LongDateToBaseString(longDateFormat, inLongDate);

					switch (longDateFormat.ToUpper())
					{
						case "YYYYMMDD":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "yyyyMMdd");
								break;
							}
						case "YYYYMM":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "yyyyMM");
								break;
							}
						case "YYMMDD":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "yyMMdd");
								break;
							}
						case "MMDD":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "MMdd");
								break;
							}
						case "HHMMSS":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "HHmmss");
								break;
							}
						case "HHMM":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "HHmm");
								break;
							}
						case "MMSS":
							{
								tmpDateTime = DateTimeParseExact(sStrDate, "mmss");
								break;
							}
						default:
							{
								break;
							}
					}
				}
				catch (ArgumentNullException)
				{
					tmpDateTime = new DateTime(0);
					// �w�肳�ꂽ�l��NULL�̏ꍇ
				}
				catch (FormatException)
				{
					tmpDateTime = new DateTime(0);
					// �w�菑���ʂ�ɕϊ��ł��Ȃ��ꍇ�̗�O
				}
			}

			return tmpDateTime;
		}

		/// **********************************************************************
		/// Module name      : DateTimeParseExact
		/// <summary>
		///                    ���t������\���������DateTime�^�ɕϊ����܂�
		/// </summary>
		/// <param name="inStrDate">
		///                    �ϊ��Ώۓ��t(string�^)
		/// </param>
		/// <param name="dateFormatStr">
		///                    �ϊ��Ώۓ��t�̃t�H�[�}�b�g�`��(YYYYMMDD,YYYYMM,...)
		/// </param>
		/// <returns>
		///                    ���t�ϊ�����(DateTime�^)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���t������\���������DateTime�^�ɕϊ����܂�</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		/// **********************************************************************
		private static DateTime DateTimeParseExact(string inStrDate, string dateFormatStr)
		{

            // ������null�̏ꍇ�͗�O
            if (inStrDate == null || dateFormatStr == null)
            {
                throw new ArgumentNullException("�������ݒ肳��Ă��܂���B");
            }

            // �{�N���X���Ŏg�p����`���̂ݎ󂯕t���܂�
            string[] splitStr;

            #region �����񕪊�����
            try
            {
                switch (dateFormatStr)
                {
                    case "yyyy/M/d":
                    case "ggyy/M/d":
                        splitStr = inStrDate.Split(new char[] { '/' });
                        if (splitStr.Length != 3)
                        {
                            // 3�����łȂ��ꍇ�͔N�����̕����ł͂Ȃ��Ɣ��f���ė�O�Ƃ���B
                            throw new FormatException("������͗L���� DateTime �ł͂���܂���ł����B");
                        }
                        break;
                    case "yyyyMMdd":
                        splitStr = new string[] { inStrDate.Substring(0, 4), inStrDate.Substring(4, 2), inStrDate.Substring(6, 2) };
                        break;
                    case "yyyyMM":
                        splitStr = new string[] { inStrDate.Substring(0, 4), inStrDate.Substring(4, 2) };
                        break;
                    case "yyMMdd":
                    case "HHmmss":
                        splitStr = new string[] { inStrDate.Substring(0, 2), inStrDate.Substring(2, 2), inStrDate.Substring(4, 2) };
                        break;
                    case "MMdd":
                    case "HHmm":
                    case "mmss":
                        splitStr = new string[] { inStrDate.Substring(0, 2), inStrDate.Substring(2, 2) };
                        break;
                    default:
                        splitStr = new string[0];
                        break;
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                // Substring�Ɏ��s�����ꍇ��FormatException�i���b�Z�[�W��DateTime.ParseExact�Ɠ����ɂ��Ă����j
                throw new FormatException("������͗L���� DateTime �ł͂���܂���ł����B");
            }
            #endregion

            #region �e�^�����Ƃ�DateTime��������
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;
            int hour = 0;
            int minute = 0;
            int second = 0;

            try
            {
                switch (dateFormatStr)
                {
                    case "yyyy/M/d":
                    case "yyyyMMdd":
                        year = Int32.Parse(splitStr[0]);
                        month = Int32.Parse(splitStr[1]);
                        day = Int32.Parse(splitStr[2]);
                        break;
                    case "ggyy/M/d":
                        year = GetYearFromJapaneseYear(splitStr[0]);
                        month = Int32.Parse(splitStr[1]);
                        day = Int32.Parse(splitStr[2]);

                        // �����w��̏ꍇ�A�������N�i1868�N�j9��8�����O�̏ꍇ�͗�O
                        if (year < 1868 || (year == 1868 && month < 9) || (year == 1868 && month == 9 && day < 8))
                        {
                            // DateTime.Parse�̎��Ɠ������b�Z�[�W�ɂ��Ă���
                            throw new FormatException("������ŕ\����� DateTime ���J�����_�[ System.Globalization.JapaneseCalendar �ŃT�|�[�g����Ă��܂���B");
                        }

                        break;
                    case "yyyyMM":
                        year = Int32.Parse(splitStr[0]);
                        month = Int32.Parse(splitStr[1]);
                        day = 1;
                        break;
                    case "yyMMdd":
                        year = Int32.Parse(splitStr[0]) + 2000;     // 2���w��̏ꍇ�́A2000�N��Ƃ��Čv�Z����
                        month = Int32.Parse(splitStr[1]);
                        day = Int32.Parse(splitStr[2]);
                        break;
                    case "MMdd":
                        month = Int32.Parse(splitStr[0]);
                        day = Int32.Parse(splitStr[1]);
                        break;
                    case "HHmmss":
                        hour = Int32.Parse(splitStr[0]);
                        minute = Int32.Parse(splitStr[1]);
                        second = Int32.Parse(splitStr[2]);
                        break;
                    case "HHmm":
                        hour = Int32.Parse(splitStr[0]);
                        minute = Int32.Parse(splitStr[1]);
                        break;
                    case "mmss":
                        minute = Int32.Parse(splitStr[0]);
                        second = Int32.Parse(splitStr[1]);
                        break;
                    default:
                        // ��L�ȊO�̃p�^�[�����������ꍇ�́A������ǉ����Ă��������B
                        // �󂯓����p�^�[���ȊO��FormatException��throw���܂��B
                        throw new FormatException("�����̏������s���ł��B");
                }
            }
            catch (IndexOutOfRangeException)
            {
                // �z�肵�����ɕ����ł��Ă��Ȃ������ꍇ
                throw new FormatException("�����̏������s���ł��B");
            }

            #endregion
            DateTime returnDt;
            try
            {
                returnDt = new DateTime(year, month, day, hour, minute, second);
            }
            catch (ArgumentException)
            {
                // ���t�ɕϊ��ł��Ȃ��i13���Ȃǁj�ꍇ�́AFormatException��throw�i���b�Z�[�W��DateTime.Parse�̂��̂ɍ��킹��j
                throw new FormatException("������ŕ\����� DateTime ���J�����_�[ System.Globalization.GregorianCalendar �ŃT�|�[�g����Ă��܂���B");
            }

            return returnDt;
        }

        /// <summary>
        /// �a��̔N���琼��ɕϊ����ĕԋp���܂��B
        /// �{���\�b�h�ň�����a��͖����ȍ~�̂��̂Ƃ��A
        /// ����2�����i��F�����j�E�����擪1�����i��F���j�E�������p�啶���i��FH�j�E�������p�������i��Fh�j�݂̂������܂��B
        /// ����ȊO�̂��̂�t�^���Ă���ꍇ�́A��O��ԋp���܂��B
        /// </summary>
        /// <exception cref="System.FormatException">
        /// ���L�̏ꍇ�AFormatException���������܂��B
        /// �@�E�������󕶎��̏ꍇ
        /// �@�E�����ɖ����ȍ~�̌������w�肵�Ă��Ȃ��ꍇ
        /// �@�E�����̎w�肪����2�����E�����擪1�����E�������p�啶���E�������p�������ȊO�̏ꍇ
        /// �@�E������������������ɐ����ȊO�̂��̂��܂܂��ꍇ
        /// �@�E������������������̌�����3���ȏ�̏ꍇ
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// ������null�̏ꍇ�AArgumentNullException���������܂�
        /// </exception>
        /// <param name="japaneseYearStr">�a��̔N�i�����{�N�̌���������j</param>
        /// <returns>����̔N</returns>
        private static int GetYearFromJapaneseYear(string japaneseYearStr)
        {
            if (japaneseYearStr == null)
            {
                throw new ArgumentNullException("�a��̔N�̐ݒ肪����܂���B");
            }
            else if (japaneseYearStr == string.Empty)
            {
                throw new FormatException("�a��̔N�ɋ󕶎����ݒ肳��Ă��܂��B");
            }

            // �e�����̐ݒ育�ƂɁA�Ώۂ̌����ƔN�ɕ�������
            string gengo = string.Empty;
            string japaneseYear = string.Empty;

            ArrayList eraInfoList = GetEraInfoList();

            foreach (EraInfo info in eraInfoList)
            {
                // ��X�̌�����Replace�̂��߂ɁA�ݒ肳��Ă��錳�����̂��̂�ێ����Ă���
                if (japaneseYearStr.StartsWith(info.EraName))
                {
                    gengo = info.EraName;
                    break;
                }
                else if (japaneseYearStr.StartsWith(info.EraShortName))
                {
                    gengo = info.EraShortName;
                    break;
                }
                else if (japaneseYearStr.StartsWith(info.EraUpperInitial))
                {
                    gengo = info.EraUpperInitial;
                    break;
                }
                else if (japaneseYearStr.StartsWith(info.EraLowerInitial))
                {
                    gengo = info.EraLowerInitial;
                    break;
                }
            }

            if (string.IsNullOrEmpty(gengo))
            {
                throw new FormatException("�������������ݒ肳��Ă��܂���B");
            }

            japaneseYear = japaneseYearStr.Replace(gengo, string.Empty).Trim();

            if (string.IsNullOrEmpty(japaneseYear))
            {
                throw new FormatException("�N���������ݒ肳��Ă��܂���B");
            }

            return GetYearFromJapaneseYear(gengo, japaneseYear);
        }

        /// <summary>
        /// �a��̔N���琼��ɕϊ����ĕԋp���܂��B
        /// �{���\�b�h�ň�����a��͖����ȍ~�̂��̂Ƃ��A
        /// ����2�����i��F�����j�E�����擪1�����i��F���j�E�������p�啶���i��FH�j�E�������p�������i��Fh�j�݂̂������܂��B
        /// ����ȊO�̂��̂�t�^���Ă���ꍇ�́A��O��ԋp���܂��B
        /// </summary>
        /// <exception cref="System.FormatException">
        /// ���L�̏ꍇ�AFormatException���������܂��B
        /// �@�E�������󕶎��̏ꍇ
        /// �@�E�����ɖ����ȍ~�̌������w�肵�Ă��Ȃ��ꍇ
        /// �@�E�����̎w�肪����2�����E�����擪1�����E�������p�啶���E�������p�������ȊO�̏ꍇ
        /// �@�E������������������ɐ����ȊO�̂��̂��܂܂��ꍇ
        /// �@�E������������������̌�����3���ȏ�̏ꍇ
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// ������null�̏ꍇ�AArgumentNullException���������܂�
        /// </exception>
        /// <param name="gengo">����</param>
        /// <param name="japaneseYear">�a��̔N�i�N�̂݁j</param>
        /// <returns>����̔N</returns>
        private static int GetYearFromJapaneseYear(string gengo, string japaneseYear)
        {
            // �����`�F�b�N
            if (gengo == null)
            {
                throw new ArgumentNullException("�������������ݒ肳��Ă��܂���B");
            }
            else if (gengo == string.Empty)
            {
                throw new FormatException("�������������ݒ肳��Ă��܂���B");
            }
            else if (japaneseYear == null)
            {
                throw new ArgumentNullException("�N���������ݒ肳��Ă��܂���B");
            }
            else if (japaneseYear == string.Empty)
            {
                throw new FormatException("�N���������ݒ肳��Ă��܂���B");
            }
            else if (japaneseYear.Length > 2)
            {
                throw new FormatException("�N��3���ȏ�̒l���ݒ肳��Ă��܂��B");
            }

            // ��N�i�e������0�N�ɑ������鐼��j���Z�o
            ArrayList eraInfoList = GetEraInfoList();
            int baseYear = 0;

            foreach (EraInfo info in eraInfoList)
            {
                if (gengo == info.EraName || gengo == info.EraShortName || gengo == info.EraUpperInitial || gengo == info.EraLowerInitial)
                {
                    baseYear = info.BaseYear;
                    break;
                }
            }

            if (baseYear == 0)
            {
                throw new FormatException("�������������ݒ肳��Ă��܂���B");
            }

            // �����ȊO���܂܂��FormatException�͂��̂܂�throw���邽�߁AParse������try-catch�͂��Ȃ�
            return Int32.Parse(japaneseYear) + baseYear;

        }

		// DateTime�^ -> LongDate�^(YYYYMMDD)�ɕϊ�
		/// **********************************************************************
		/// Module name      : DateTimeToLongDate
		/// <summary>
		///                    DateTime�^�̓��t��LongDate�^(YYYYMMDD)�ɕϊ����܂�
		/// </summary>
		/// <param name="inDateTime">
		///                    �ϊ��Ώۓ��t(DateTime�^)
		/// </param>
		/// <returns>
		///                    ���t�ϊ�����(LonDate�`��)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   DateTime�^�̓��t��LongDate�`��(YYYYMMDD)�ɕϊ�����</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		/// **********************************************************************
		public static int DateTimeToLongDate(DateTime inDateTime)
		{
			int rLongDate = 0;

			//if (inDateTime != DateTime.MinValue)
			//{
			rLongDate = Convert.ToInt32(inDateTime.ToString("yyyyMMdd"));
			//}

			return rLongDate;
		}

		/// **********************************************************************
		/// Module name      : DateTimeToLongDate
		/// <summary>
		///                    DateTime�^�̓��t��LongDate�^(YYYYMMDD)�ɕϊ����܂�
		/// </summary>
		/// <param name="dateFormat">
		///                    ���t�t�H�[�}�b�g�`��
		/// </param>
		/// <param name="inDateTime">
		///                    �ϊ��Ώۓ��t(DateTime�^)
		/// </param>
		/// <returns>
		///                    ���t�ϊ�����(LonDate�`��)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   DateTime�^�̓��t��LongDate�`��(YYYYMMDD)�ɕϊ�����</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		/// **********************************************************************
		public static int DateTimeToLongDate(string dateFormat, DateTime inDateTime)
		{
			int rLongDate = 0;
			// �w��`���̌��ɕҏW
			//if ((inDateTime == null) || (inDateTime == DateTime.MinValue))
			//{
			//    rLongDate = 0;
			//}
			//else
			{
				switch (dateFormat.ToUpper())
				{
					case "YYYYMMDD":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("yyyyMMdd"));
							break;
						}
					case "YYMMDD":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("yyMMdd"));
							break;
						}
					case "YYYYMM":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("yyyyMM"));
							break;
						}
					case "MMDD":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("MMdd"));
							break;
						}
					case "YYYY":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("yyyy"));
							break;
						}
					case "MM":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("MM"));
							break;
						}
					case "DD":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("dd"));
							break;
						}
					case "HHMMSS":
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("HHmmss"));
							break;
						}
					default:
						{
							rLongDate = Convert.ToInt32(inDateTime.ToString("yyyyMMdd"));
							break;
						}
				}
			}

			return rLongDate;
		}

		// ���t����(�N,��,��)
		// ���t����(�N,��,��)(YYYYMMDD)
		/// **********************************************************************
		/// Module name      : SplitDate
		/// <summary>
		///                    �w�肳�ꂽ���t��(����,�N,��,��)�ɕ������܂�
		/// </summary>
		/// <param name="dateFormat">
		///                    ���t�t�H�[�}�b�g�`��
		/// </param>
		/// <param name="orgDate">
		///                    �����Ώۓ��t(YYYYMMDD�`��)
		/// </param>
		/// <param name="rGengo">
		///                    ��������(����)
		/// </param>
		/// <param name="rYear">
		///                    ��������(�N)
		/// </param>
		/// <param name="rMonth">
		///                    ��������(��)
		/// </param>
		/// <param name="rDay">
		///                    ��������(��)
		/// </param>
		/// <returns>
		///                    ��������(0:����, -1:�������s)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���t��N,��,���ɕ������Ďw�肳�ꂽ�����ɕԂ�</br>
		/// <br>                     �߂�l�́A��������(����)��Ԃ�</br>
		/// <br>Programer        :   R.Sokei                            </br>
		/// <br>Date             :   2004.12.06                              </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static int SplitDate(string dateFormat, int orgDate, ref string rGengo, ref int rYear, ref int rMonth, ref int rDay)
		{
			if (orgDate == 0)
			{
				rGengo = "";
				rYear = 0;
				rMonth = 0;
				rDay = 0;
				return 0;
			}

			rGengo = "";
			int lYear = 0, lMonth = 0, lDay = 0;

			//// ���͒l���s���ȏꍇ�́A�f�t�H���g�l�Ɏ����ϊ�
			//if (orgDate < (ctYearDef + ctMonthDayDef))
			//    orgDate = orgDate + ctYearDef;

			//// DateTime�^�ɕϊ�
			//DateTime orgDateTime = LongDateToDateTime("YYYYMMDD", orgDate);

			//// ���t����
			//SplitDate(dateFormat, orgDateTime, ref lGengo, ref lYear, ref lMonth, ref lDay);

			//rGengo = lGengo;
			//rYear = lYear;
			//rMonth = lMonth;
			//rDay = lDay;
			//return 0;

			lYear = (orgDate / 10000);
			lMonth = ((orgDate % 10000) / 100);
			lDay = orgDate % 100;

			// ����,�N �𕪊������
			switch (dateFormat.ToUpper())
			{
				case "YYYYMMDD":
					{
						lYear = (orgDate / 10000);
						lMonth = ((orgDate % 10000) / 100);
						lDay = orgDate % 100;
						break;
					}
				case "YYMMDD":
					{
						//lyy = ((orgDate % 1000000) / 10000);
						lYear = (orgDate / 10000);
						lMonth = ((orgDate % 10000) / 100);
						lDay = orgDate % 100;
						break;
					}
				case "YYYYMM":
					{
						lYear = (orgDate / 100);
						lMonth = ((orgDate % 10000) / 100);
						lDay = 1;
						break;
					}
				case "GGYYMMDD":
					{
						try
						{
							int lMonthTmp = lMonth;
							int lDayTmp = lDay;

                            // ��������񃊃X�g�͐V�����������珇�ɕ���ł���
                            ArrayList eraInfoList = GetEraInfoList();

                            if (lMonthTmp == 0)
                            {
                                // ���w�肪�Ȃ��ꍇ�̌����ݒ��1��1���Ƃ���B
                                // �@����O�p�^�[����
                                // �@�@�����̏I���N�̏ꍇ�́A���̔N�̍ŏI�����̊J�n���Ƃ���B

                                lMonthTmp = 1;
                                lDayTmp = 1;

                                // �������A�����̏I���N�̏ꍇ�͌�̌�����D�悷��B�i�����I������12/31�̏ꍇ�������j
                                foreach (EraInfo info in eraInfoList)
                                {
                                    if (lYear == info.EndDate.Year)
                                    {
                                        // �I�����̗�����ݒ肵�Ď��̌��������Ƃ���B�i���̔N�̍ŏI�����ɂȂ�j
                                        DateTime eraEndDateNextDay = info.EndDate.AddDays(1);
                                        if (lYear != eraEndDateNextDay.Year)
                                        {
                                            // �����̏I������12��31���i�����I�������������N�̂��߈�v���Ȃ��j�̏ꍇ��1��1���Ƃ���B�i����������break�j
                                            // �������A�����̊J�n���ƏI�����������N�̏ꍇ�́A���̌����̊J�n����ݒ肷��B�i���̔N�̍ŏI�����ɂȂ�j
                                            if (lYear == info.StartDate.Year)
                                            {
                                                lMonthTmp = info.StartDate.Month;
                                                lDayTmp = info.StartDate.Day;
                                            }
                                            break;
                                        }

                                        lMonthTmp = eraEndDateNextDay.Month;
                                        lDayTmp = eraEndDateNextDay.Day;
                                        break;
                                    }
                                    else if (info.StartDate.Year < lYear && lYear < info.EndDate.Year)
                                    {
                                        // �Ώۂ̌����Ɋ܂܂��ꍇ�́A�Ȍ�̌���������K�v���Ȃ�����break����B
                                        // �i�������A���N�ɑ�������N�̏ꍇ�͑O�̌����̏I���N�ɓ����邽�߁A�����p���j
                                        break;
                                    }
                                }
                            }
                            else if (lDayTmp == 0)
                            {
                                // ���w�肪�Ȃ��ꍇ�̓��ݒ��1���Ƃ���B
                                // �@����O�p�^�[����
                                // �@�@�����̏I���N���̏ꍇ�́A���̔N���̍ŏI�����̊J�n���Ƃ���B

                                lDayTmp = 1;

                                // ��r�p�ɔN����A���������l������
                                int yyyyMm = lYear * 100 + lMonthTmp;

                                // �������A�����̏I���N���̏ꍇ�͌�̌�����D�悷��B�i�����I������12/31�̏ꍇ�������j
                                foreach (EraInfo info in eraInfoList)
                                {
                                    // ��r�p�Ɍ����̊J�n�E�I���N����A���������l������
                                    int eraStartYyyyMm = info.StartDate.Year * 100 + info.StartDate.Month;
                                    int eraEndYyyyMm = info.EndDate.Year * 100 + info.EndDate.Month;

                                    // �����̏I���N�E���̏ꍇ�͌�̌�����D�悷��B
                                    if (yyyyMm == eraEndYyyyMm)
                                    {
                                        DateTime eraEndDateNextDay = info.EndDate.AddDays(1);

                                        if (lMonthTmp != eraEndDateNextDay.Month)
                                        {
                                            // �����̏I�����������i�����I���������������j�̏ꍇ��1���Ƃ���B�i����������break�j
                                            // �������A�����̊J�n���������N���̏ꍇ�́A���̌����̊J�n����ݒ肷��B
                                            if (yyyyMm == eraStartYyyyMm)
                                            {
                                                lDayTmp = info.StartDate.Day;
                                            }
                                            break;
                                        }

                                        // ����ȊO�̏ꍇ�́A�I�����̗�����ݒ肵�Ď��̌��������Ƃ���B
                                        lDayTmp = eraEndDateNextDay.Day;
                                        break;
                                    }
                                    else if (eraStartYyyyMm < yyyyMm && yyyyMm < eraEndYyyyMm)
                                    {
                                        // �N�����Ώۂ̌����Ɋ܂܂��ꍇ�́A�Ȍ�̌���������K�v���Ȃ�����break����B
                                        // �i�������A���N�ɑ�������N�̉������̏ꍇ�͑O�̌����̏I���N���ɓ����邽�߁A�����p���j
                                        break;
                                    }
                                }
                            }

                            GetJapaneseEraFromYMD(lYear, lMonthTmp, lDayTmp, ref rGengo, ref lYear);
						}
                        catch (ArgumentOutOfRangeException)
						{
                            // ���t�͈̔͂𒴂����ꍇ
						}

						break;
					}
				default:
					{
						break;
					}
			}
			rYear = lYear;
			// ��,�� �𕪊�
			rMonth = lMonth;
			rDay = lDay;

			return 0;
		}

        //2012.03.30 23011 noguchi ����Ăяo���ƃI�[�o�[�w�b�h���傫�����߃N���X�ϐ��� >>
        // �����擾�̏ꍇ�̂݁AJapanese�J���`���[�̃J�����_�[���擾����
        private static System.Globalization.Calendar calendar = new System.Globalization.JapaneseCalendar();
        private static System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ja-JP");
        //>> 2012.03.30 23011 noguchi ����Ăяo���ƃI�[�o�[�w�b�h���傫�����߃N���X�ϐ���



		/// **********************************************************************
		/// Module name      : SplitDate
		/// <summary>
		///                    �w�肳�ꂽ���t��(����,�N,��,��)�ɕ������܂�
		/// </summary>
		/// <param name="dateFormat">
		///                    ���t�t�H�[�}�b�g�`��
		/// </param>
		/// <param name="orgDate">
		///                    �����Ώۓ��t(DateTime�^)
		/// </param>
		/// <param name="rGengo">
		///                    ��������(����)
		/// </param>
		/// <param name="rYear">
		///                    ��������(�N)
		/// </param>
		/// <param name="rMonth">
		///                    ��������(��)
		/// </param>
		/// <param name="rDay">
		///                    ��������(��)
		/// </param>
		/// <returns>
		///                    ��������(0:����, -1:�������s)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   ���t��N,��,���ɕ������Ďw�肳�ꂽ�����ɕԂ�</br>
		/// <br>                     �߂�l�́A��������(����)��Ԃ�</br>
		/// <br>Programer        :   R.Sokei                            </br>
		/// <br>Date             :   2004.12.06                              </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static int SplitDate(string dateFormat, DateTime orgDate, ref string rGengo, ref int rYear, ref int rMonth, ref int rDay)
		{
			rGengo = ""; rYear = 0; rMonth = 0; rDay = 0;
			int lYyyy = 0, lYy = 0, lMonth = 0, lDay = 0;

			lYyyy = Convert.ToInt32(orgDate.ToString("yyyy"));
			lYy = Convert.ToInt32(orgDate.ToString("yy"));
			lMonth = Convert.ToInt32(orgDate.ToString("MM"));
			lDay = Convert.ToInt32(orgDate.ToString("dd"));

			// ����,�N �𕪊������
			switch (dateFormat)
			{
				case "YYYYMMDD":
					{
						lYy = lYyyy;
						//rMonth = rMonth
						//rDay = rDay
						break;
					}
				case "YYMMDD":
					{
						//lyy = ((orgDate % 1000000) / 10000);
						//lyy = (orgDate / 10000);
						//lMonth = ((orgDate % 10000) / 100);
						//lDay = orgDate % 100;
						break;
					}
				case "YYYYMM":
					{
						lYy = lYyyy;
						//lMonth = ((orgDate % 10000) / 100);
						lDay = 1;
						break;
					}
				case "GGYYMMDD":
					{
                        //2012.03.30 23011 noguchi �s���ȓ��t�̏ꍇ�ɂ͌����擾�̏������s�Ȃ�Ȃ��B
                        //��O���������ăX�s�[�h��������B
                        if (orgDate != DateTime.MinValue
                            && orgDate != DateTime.MaxValue)
                        {
                            try
                            {
                                GetJapaneseEraFromYMD(orgDate, ref rGengo, ref lYy);
                            }
                            catch (System.ArgumentOutOfRangeException)
                            {
                                // ���t�͈̔͂𒴂����ꍇ
                            }
                        }

						break;
					}
				default:
					{
						lYy = lYyyy;
						break;
					}
			}

			rYear = lYy;
			rMonth = lMonth;
			rDay = lDay;

			return 0;
		}

        /// <summary>
        /// ����̔N���������ɘa��̌����ƔN��ԋp���܂��B
        /// ��CultureInfo��"ja-JP"��ݒ肵���ۂ�DateTime.ToString(DateTime, CultureInfo)�Ɠ��l�ɁA
        /// �@���������1868�N1��1���`�Ƃ��A������O�̓����w�肵���ꍇ��ArgumentOutOfRangeException��throw���܂��B
        /// �@�܂��A�����̓��t�Ɋւ��ẮA�ŐV�̌�����ԋp���܂��B
        /// </summary>
        /// <param name="year">����̔N</param>
        /// <param name="month">��</param>
        /// <param name="day">��</param>
        /// <param name="gengo">�����i�ԋp�l�j</param>
        /// <param name="japaneseYear">�a��̔N�i�ԋp�l�j</param>
        private static void GetJapaneseEraFromYMD(int year, int month, int day, ref string gengo, ref int japaneseYear)
        {
            GetJapaneseEraFromYMD(new DateTime(year, month, day), ref gengo, ref japaneseYear);
        }

        /// <summary>
        /// ����̔N���������ɘa��̌����ƔN��ԋp���܂��B
        /// ��CultureInfo��"ja-JP"��ݒ肵���ۂ�DateTime.ToString(DateTime, CultureInfo)�Ɠ��l�ɁA
        /// �@���������1868�N1��1���`�Ƃ��A������O�̓����w�肵���ꍇ��ArgumentOutOfRangeException��throw���܂��B
        /// �@�܂��A�����̓��t�Ɋւ��ẮA�ŐV�̌�����ԋp���܂��B
        /// </summary>
        /// <param name="dt">�擾�Ώۂ̓��t</param>
        /// <param name="gengo">�����i�ԋp�l�j</param>
        /// <param name="japaneseYear">�a��̔N�i�ԋp�l�j</param>
        private static void GetJapaneseEraFromYMD(DateTime dt, ref string gengo, ref int japaneseYear)
        {
            gengo = string.Empty;
            japaneseYear = 0;

            ArrayList eraInfoList = GetEraInfoList();

            foreach (EraInfo info in eraInfoList)
            {
                // �n���ꂽ���t���A�e�����̊J�n�`�I�����Ɋ܂܂�Ă��邩���m�F����
                if (info.StartDate <= dt && dt <= info.EndDate)
                {
                    gengo = info.EraName;
                    japaneseYear = dt.Year - info.BaseYear;
                    break;
                }
            }

            // �������O�ɂ��Ă͗�O�Ƃ���i�G���[���b�Z�[�W��DateTime.ToString(DateTime, CultureInfo)�̗�O�������Ɠ��l�j
            if (gengo == string.Empty)
            {
                throw new ArgumentOutOfRangeException("�w�肳�ꂽ�����́A�L���Ȓl�͈͓̔��ɂ���܂���B\r\n�p�����[�^��: ���Ԓl���N���͈̔͂𒴂��Ă��܂��B");
            }

            return;
        }

		// �w����t���w����YY�NMM��DD���x�ɕҏW����    GGYYMMDD, GGYY/MM/DD, GGYY.MM.DD
		// �w����t���w����YY�NMM���x�ɕҏW����        GGYY/MM, GGYY.MM
		// �w����t���w����YY�N�x�ɕҏW����            GGYY
		// �w����t���w����YY�NMM��DD���x�ɕҏW����    ggYYMMDD, ggYY/MM/DD, ggYY.MM.DD
		// �w����t���w����YY�NMM���x�ɕҏW����        ggYY/MM, ggYY.MM
		// �w����t���w����YY�N�x�ɕҏW����            ggYY
		// �w����t���wYYYY�NMM��DD���x�ɕҏW����      YYYYMMDD, YYYY/MM/DD, YYYY.MM.DD
		// �w����t���wYYYY�NMM���x�ɕҏW����          YYYYMM, YYYY/MM, YYYY.MM
		// �w����t���wYYYY�N�x�ɕҏW����              YYYY

		// �w����t���w����YY/MM/DD�x�ɕҏW����
		// �w����t���w����YY/MM�x�ɕҏW����
		// �w����t���w����YY/MM/DD�x�ɕҏW����
		// �w����t���w����YY/MM�x�ɕҏW����
		// �w����t���w����YY�x�ɕҏW����
		// �w����t���wYYYY/MM/DD���x�ɕҏW����
		// �w����t���wYYYY/MM�x�ɕҏW����
		// �w����t���wYYYY�x�ɕҏW����

		// �w����t���w����YY.MM.DD�x�ɕҏW����
		// �w����t���w����YY.MM�x�ɕҏW����
		// �w����t���w����YY.MM.DD�x�ɕҏW����
		// �w����t���w����YY.MM�x�ɕҏW����
		// �w����t���w����YY�x�ɕҏW����
		// �w����t���wYYYY.MM.DD���x�ɕҏW����
		// �w����t���wYYYY.MM�x�ɕҏW����
		// �w����t���wYYYY�x�ɕҏW����
		// �w�莞�����wHH��MM��SS�b�x�ɕҏW����
		// �w�莞�����wHH��MM���x�ɕҏW����
		// �w�莞�����wHH���x�ɕҏW����
		// �w�莞�����wHH:MM:SS�x�ɕҏW����
		// �w�莞�����wHH:MM�x�ɕҏW����
		// �w�莞�����wHH�x�ɕҏW����

		///// <summary>
		///// DateTime --> ���t������ϊ�
		///// </summary>
		///// <param name="dateFormat">���t�t�H�[�}�b�g�`��</param>
		///// <param name="inDateTime">�ϊ��Ώۓ��t(DateTime�^)</param>
		///// <returns>���t�ϊ�����(�w�肳�ꂽ�`���̕�����)</returns>
		///// <remarks>
		///// <br>Note		 :   DateTime�^,LongDate�^(YYYYMMDD)�̓��t���w�肳�ꂽ�t�H�[�}�b�g</br>
		/////	<br>		 	     �`���̕�����ɕϊ����܂�</br>
		/////	<br>					���t�t�H�[�}�b�g�́A�ȉ��̗l�����w�肵�܂�</br>
		/////	<br>					</br>
		/////	<br>					�t�H�[�}�b�g�`�� : �o�͌���(��)</br>
		/////	<br>					</br>
		/////	<br>				YYYYMMDD   : 2004�N01��01��</br>
		/////	<br>				YYYYmmdd   : 2004�N 1�� 1��</br>
		/////	<br>				YYYYMM     : 2004�N01��</br>
		/////	<br>				YYYYmm     : 2004�N 1��</br>
		/////	<br>				GGYYMMDD   : ����16�N01��01��</br>
		/////	<br>				GGyymmdd   : ���� 5�N 1�� 1��</br>
		/////	<br>				GGYYMM     : ����16�N01��</br>
		/////	<br>				GGyymm     : ���� 5�N 1��</br>
		/////	<br>				ggYYMM     : H16�N01��</br>
		/////	<br>				ggyymm     : H 5�N 1��</br>
		/////	<br>				ggYY/MM/DD : H16/01/01</br>
		/////	<br>				ggyy/mm/dd : H 5/ 1/ 1</br>
		/////	<br>				ggYY/MM    : H16/01</br>
		/////	<br>				ggyy/mm    : H 5/ 1</br>
		/////	<br>				ggYY.MM.DD : H16.01.01</br>
		/////	<br>				ggyy.mm.dd : H 5. 1. 1</br>
		/////	<br>				ggYY.MM    : H16.01</br>
		/////	<br>				ggyy.mm    : H 5. 1</br>
		/////	<br>				GGYY       : ����16�N</br>
		/////	<br>				ggYY       : H16�N</br>
		/////	<br>				GGyy       : ���� 5�N</br>
		/////	<br>				ggyy       : H 5�N</br>
		/////	<br>				YYYY/MM/DD : 2004/01/01</br>
		/////	<br>				YYYY/mm/dd : 2004/ 1/ 1</br>
		/////	<br>				YYYY.MM.DD : 2004.01.01</br>
		/////	<br>				YYYY.mm.dd : 2004. 1. 1</br>
		/////	<br>				exggYY     : H16</br>
		/////	<br>				exggyy     : H 5</br>
		/////	<br>				ggYY.      : H16</br>
		/////	<br>				ggyy.      : H 5</br>
		/////	<br>				ggYY/      : H16</br>
		/////	<br>				ggyy/      : H 5</br>
		/////	<br>				GG         : ����</br>
		/////	<br>				gg         : H</br>
		/////	�E	<br>            	GGYY/MM    : H18/08</br>
		/////                         ���̒�`���Ԉ���Ă��܂��B �{�� GGYY/MM �ł͈ȉ��� exGGYY/MM �Ɠ����̌��ʂ�Ԃ��Ȃ����
		/////			                �����܂��񂪁A���ɂ��̒�`���g�p���Ă��鏈��������̂ł��̂܂܂ɂ��Ă����܂��B
		/////	<br>				exGGYY/MM  : ��L GGYY/MM �̑���Ɏg�p���Ă��������B ���� + �N + / +��  ��) ����18/08</br>
		/////	<br>				</br>
		///// <br>Programer        :   R.Sokei</br>
		///// <br>Date             :   2004.12.06</br>
		///// </remarks>

		/// <summary>
		/// DateTime --> ���t������ϊ�
		/// </summary>
		/// <param name="dateFormat">���t�t�H�[�}�b�g�`��</param>
		/// <param name="inDateTime">�ϊ��Ώۓ��t(DateTime�^)</param>
		/// <returns>���t�ϊ�����(�w�肳�ꂽ�`���̕�����)</returns>
		/// <remarks>
		/// <br>Note		 :   DateTime�^,LongDate�^(YYYYMMDD)�̓��t���w�肳�ꂽ�t�H�[�}�b�g</br>
		///	<br>		 	     �`���̕�����ɕϊ����܂�</br>
		///	<br>					</br>
		///	<br>					</br>
		///
		///	���t�t�H�[�}�b�g�́A�ȉ��̗l�����w�肵�܂�
		/// <list type="bullet">
		///	<item>�t�H�[�}�b�g�`��(dateFormat) : �o�͌���(��)</item>
		///	<item>YYYYMMDD   : 2004�N01��01��</item>
		///	<item>YYYYmmdd   : 2004�N 1�� 1��</item>
		///	<item>YYYYMM     : 2004�N01��</item>
		///	<item>YYYYmm     : 2004�N 1��</item>
		///	<item>GGYYMMDD   : ����16�N01��01��</item>
		///	<item>GGyymmdd   : ���� 5�N 1�� 1��</item>
		///	<item>GGYYMM     : ����16�N01��</item>
		///	<item>GGyymm     : ���� 5�N 1��</item>
		///	<item>ggYYMM     : H16�N01��</item>
		///	<item>ggyymm     : H 5�N 1��</item>
		///	<item>ggYY/MM/DD : H16/01/01</item>
		///	<item>ggyy/mm/dd : H 5/ 1/ 1</item>
		///	<item>ggYY/MM    : H16/01</item>
		///	<item>ggyy/mm    : H 5/ 1</item>
		///	<item>ggYY.MM.DD : H16.01.01</item>
		///	<item>ggyy.mm.dd : H 5. 1. 1</item>
		///	<item>ggYY.MM    : H16.01</item>
		///	<item>ggyy.mm    : H 5. 1</item>
		///	<item>GGYY       : ����16�N</item>
		///	<item>ggYY       : H16�N</item>
		///	<item>GGyy       : ���� 5�N</item>
		///	<item>ggyy       : H 5�N</item>
		///	<item>YYYY/MM/DD : 2004/01/01</item>
		///	<item>YYYY/mm/dd : 2004/ 1/ 1</item>
		///	<item>YYYY.MM.DD : 2004.01.01</item>
		///	<item>YYYY.mm.dd : 2004. 1. 1</item>
		///	<item>exggYY     : H16</item>
		///	<item>exggyy     : H 5</item>
		///	<item>ggYY.      : H16</item>
		///	<item>ggyy.      : H 5</item>
		///	<item>ggYY/      : H16</item>
		///	<item>ggyy/      : H 5</item>
		///	<item>GG         : ����</item>
		///	<item>gg         : H</item>
		/// <item>GGYY/MM    : H18/08
		/// ���̒�`���Ԉ���Ă��܂��B �{�� GGYY/MM �ł͈ȉ��� exGGYY/MM �Ɠ����̌��ʂ�Ԃ��Ȃ����
		///	�����܂��񂪁A���ɂ��̒�`���g�p���Ă��鏈��������̂ł��̂܂܂ɂ��Ă����܂��B</item>
		///	<item>				exGGYY/MM  : ��L GGYY/MM �̑���Ɏg�p���Ă��������B ���� + �N + / +��  ��) ����18/08</item>
		/// </list>
		///	<br>				</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// </remarks>
		public static string DateTimeToString(string dateFormat, DateTime inDateTime)
		{
			string rDate;
			string rGengo = ""; int rYear = 0; int rMonth = 0; int rDay = 0;

			SplitDate("GGYYMMDD", inDateTime, ref rGengo, ref rYear, ref rMonth, ref rDay);

			// �w��`���̌��ɕҏW
			if (inDateTime.Equals(DateTime.MinValue))
			{
				// ���t�f�[�^��������(DateTime.MinValue)�̏ꍇ�͕������Ԃ��Ȃ�
				rDate = "";
			}
			else
			{
				switch (dateFormat)
				{
					case "GGYYMMDD":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("�NMM��dd��");
							break;
						}
					case "GGyymmdd":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "�N" + inDateTime.ToString("%M").PadLeft(2) + "��" + inDateTime.ToString("%d").PadLeft(2) + "��";
							break;
						}
					case "ggYYMMDD":
						{
							// �����擾 �v���܂�
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("�NMM��dd��");
							break;
						}
					case "ggyymmdd":
						{
							// �����擾
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "�N" + inDateTime.ToString("%M").PadLeft(2) + "��" + inDateTime.ToString("%d").PadLeft(2) + "��";
							break;
						}
					case "GGYYMM":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("�NMM��");
							break;
						}
					case "GGyymm":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "�N" + inDateTime.ToString("%M").PadLeft(2) + "��";
							break;
						}
					case "GGYY":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + "�N";
							break;
						}
					case "GGyy":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "�N";
							break;
						}
					case "ggYYMM":
						{
							// �����擾
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("�NMM��");
							break;
						}
					case "ggyymm":
						{
							// �����擾
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "�N" + inDateTime.ToString("%M").PadLeft(2) + "��";
							break;
						}
					case "ggYY":
						{
							// �����擾
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + "�N";
							break;
						}
					case "ggyy":
						{
							// �����擾
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "�N";
							break;
						}
					case "gg":
						{
							// �����擾
							rDate = GetRyakGou(rGengo);
							break;
						}
					case "GG":
						{
							rDate = rGengo;
							break;
						}
					case "exggYY":
						{
							// �g���`���Œ�`����Ă��܂��B
							// ���ꌋ�ʂ̓����� "ggYY." ���g�p���Ă�������

							// �����擾
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0');
							break;
						}
					case "exggyy":
						{
							// �g���`���Œ�`����Ă��܂��B
							// ���ꌋ�ʂ̓����� "ggyy." ���g�p���Ă�������

							// �����擾
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2);
							break;
						}
					case "ggYY.":
						{
							// �����擾
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0');
							break;
						}
					case "ggyy.":
						{
							// �����擾
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2);
							break;
						}
					case "ggYY/":
						{
							// �����擾
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0');
							break;
						}
					case "ggyy/":
						{
							// �����擾
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2);
							break;
						}
					case "YYYYMMDD":
						{
							rDate = inDateTime.ToString("yyyy�NMM��dd��");
							break;
						}
					case "YYYYmmdd":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "�N" + inDateTime.ToString("%M").PadLeft(2) + "��" + inDateTime.ToString("%d").PadLeft(2) + "��";
							break;
						}
					case "yyyymmdd":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "�N" + inDateTime.ToString("%M").PadLeft(2) + "��" + inDateTime.ToString("%d").PadLeft(2) + "��";
							break;
						}
					case "YYMMDD":
						{
							rDate = inDateTime.ToString("yy�NMM��dd��");
							break;
						}
					case "YYYYMM":
						{
							rDate = inDateTime.ToString("yyyy�NMM��");
							break;
						}
					case "YYYYmm":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "�N" + inDateTime.ToString("%M").PadLeft(2) + "��";
							break;
						}
					case "MMDD":
						{
							rDate = inDateTime.ToString("MM��dd��");
							break;
						}
					case "YYYY":
						{
							rDate = inDateTime.ToString("yyyy�N");
							break;
						}
					case "MM":
						{
							rDate = inDateTime.ToString("MM��");
							break;
						}
					case "DD":
						{
							rDate = inDateTime.ToString("dd��");
							break;
						}
					case "YYYY/MM/DD":
						{
							rDate = inDateTime.ToString("yyyy/MM/dd");
							break;
						}
					case "YYYY/mm/dd":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "/" + inDateTime.ToString("%M").PadLeft(2) + "/" + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "YY/MM/DD":
						{
							rDate = inDateTime.ToString("yy/MM/dd");
							break;
						}
					case "YYYY/MM":
						{
							rDate = inDateTime.ToString("yyyy/MM");
							break;
						}
					case "YYYY/mm":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "/" + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "YYYY.MM.DD":
						{
							rDate = inDateTime.ToString("yyyy.MM.dd");
							break;
						}
					case "YY/MM":
						{
							rDate = inDateTime.ToString("yy").PadLeft(2, '0') + "/" + inDateTime.ToString("%M").PadLeft(2, '0');
							break;
						}
					case "YY/mm":
						{
							rDate = inDateTime.ToString("yy").PadLeft(2, '0') + "/" + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "YYYY.MM":
						{
							rDate = inDateTime.ToString("yyyy.MM");
							break;
						}
					case "YYYY.mm":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "." + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "YYYY.mm.dd":
						{
							rDate = inDateTime.ToString("yyyy").PadLeft(4) + "." + inDateTime.ToString("%M").PadLeft(2) + "." + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "YY.MM.DD":
						{
							//rDate = inDateTime.ToString("yy.MM.dd");
							rDate = inDateTime.ToString("yy").PadLeft(2, '0') + "." + inDateTime.ToString("%M").PadLeft(2, '0') + "." + inDateTime.ToString("%d").PadLeft(2, '0');
							break;
						}
					case "YY.MM":
						{
							rDate = inDateTime.ToString("yy").PadLeft(2, '0') + "." + inDateTime.ToString("%M").PadLeft(2, '0');
							break;
						}
					case "YY.mm":
						{
							rDate = inDateTime.ToString("yy").PadLeft(2) + "." + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "GGYY/MM/DD":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("/MM/dd");
							break;
						}
					case "GGyy/mm/dd":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "/" + inDateTime.ToString("%M").PadLeft(2) + "/" + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "ggYY/MM/DD":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("/MM/dd");
							break;
						}
					case "ggyy/mm/dd":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "/" + inDateTime.ToString("%M").PadLeft(2) + "/" + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "GGYY.MM.DD":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString(".MM.dd");
							break;
						}
					case "GGyy.mm.dd":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "." + inDateTime.ToString("%M").PadLeft(2) + "." + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "GGYY.MM":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString(".MM");
							break;
						}
					case "GGyy.mm":
						{
							rDate = rGengo + rYear.ToString().PadLeft(2) + "." + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "GGYY/MM":
						{
							// ���̒�`���Ԉ���Ă��܂��B �{�� GGYY/MM �ł͈ȉ��� exGGYY/MM �Ɠ����̌��ʂ�Ԃ��Ȃ����
							// �����܂��񂪁A���ɂ��̒�`���g�p���Ă��鏈��������̂ł��̂܂܂ɂ��Ă����܂��B
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("/MM");
							break;
						}
					case "exGGYY/MM":
						{
							// ��L GGYY/MM �̑���Ɏg�p���Ă��������B ���� + �N + / +��  ��) ����18/08
							rDate = rGengo + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("/MM");
							break;
						}
					case "ggYY/MM":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString("/MM");
							break;
						}
					case "ggyy/mm":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "/" + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "ggYY.MM.DD":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString(".MM.dd");
							break;
						}
					case "ggyy.mm.dd":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "." + inDateTime.ToString("%M").PadLeft(2) + "." + inDateTime.ToString("%d").PadLeft(2);
							break;
						}
					case "ggYY.MM":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2, '0') + inDateTime.ToString(".MM");
							break;
						}
					case "ggyy.mm":
						{
							rDate = GetRyakGou(rGengo) + rYear.ToString().PadLeft(2) + "." + inDateTime.ToString("%M").PadLeft(2);
							break;
						}
					case "HHMMSS":
						{
							rDate = inDateTime.ToString("HH��mm��ss�b");
							break;
						}
					case "HHMM":
						{
							rDate = inDateTime.ToString("HH��mm��");
							break;
						}
					case "hhmm":
						{
							rDate = inDateTime.ToString("H��m��");
							break;
						}
					case "HH":
						{
							rDate = inDateTime.ToString("HH��");
							break;
						}
					case "HH:MM:SS":
						{
							rDate = inDateTime.ToString("HH:mm:ss");
							break;
						}
					case "HH:MM":
						{
							rDate = inDateTime.ToString("HH:mm");
							break;
						}
					case "":
					default:
						{
							rDate = inDateTime.ToString("yyyy�NMM��dd��");
							break;
						}
				}
			}
			return rDate;
		}

		/// <summary>
		/// DateTime --> ���t������ϊ�
		/// </summary>
		/// <param name="dateFormat">���t�t�H�[�}�b�g�`��</param>
		/// <param name="inDateTime">�ϊ��Ώۓ��t(DateTime�^)</param>
		/// <param name="defaultStr">inDateTime���s���ȓ��t�A�ŏ��l�������ꍇ�ɕԂ�������</param>
		/// <returns>���t�ϊ�����(�w�肳�ꂽ�`���̕�����)</returns>
		/// <remarks>
		/// <list type="bullet">
		///	<item>�t�H�[�}�b�g�`��(dateFormat) : �o�͌���(��)</item>
		///	<item>YYYYMMDD   : 2004�N01��01��</item>
		///	<item>YYYYmmdd   : 2004�N 1�� 1��</item>
		///	<item>YYYYMM     : 2004�N01��</item>
		///	<item>YYYYmm     : 2004�N 1��</item>
		///	<item>GGYYMMDD   : ����16�N01��01��</item>
		///	<item>GGyymmdd   : ���� 5�N 1�� 1��</item>
		///	<item>GGYYMM     : ����16�N01��</item>
		///	<item>GGyymm     : ���� 5�N 1��</item>
		///	<item>ggYYMM     : H16�N01��</item>
		///	<item>ggyymm     : H 5�N 1��</item>
		///	<item>ggYY/MM/DD : H16/01/01</item>
		///	<item>ggyy/mm/dd : H 5/ 1/ 1</item>
		///	<item>ggYY/MM    : H16/01</item>
		///	<item>ggyy/mm    : H 5/ 1</item>
		///	<item>ggYY.MM.DD : H16.01.01</item>
		///	<item>ggyy.mm.dd : H 5. 1. 1</item>
		///	<item>ggYY.MM    : H16.01</item>
		///	<item>ggyy.mm    : H 5. 1</item>
		///	<item>GGYY       : ����16�N</item>
		///	<item>ggYY       : H16�N</item>
		///	<item>GGyy       : ���� 5�N</item>
		///	<item>ggyy       : H 5�N</item>
		///	<item>YYYY/MM/DD : 2004/01/01</item>
		///	<item>YYYY/mm/dd : 2004/ 1/ 1</item>
		///	<item>YYYY.MM.DD : 2004.01.01</item>
		///	<item>YYYY.mm.dd : 2004. 1. 1</item>
		///	<item>exggYY     : H16</item>
		///	<item>exggyy     : H 5</item>
		///	<item>ggYY.      : H16</item>
		///	<item>ggyy.      : H 5</item>
		///	<item>ggYY/      : H16</item>
		///	<item>ggyy/      : H 5</item>
		///	<item>GG         : ����</item>
		///	<item>gg         : H</item>
		/// <item>GGYY/MM    : H18/08
		/// ���̒�`���Ԉ���Ă��܂��B �{�� GGYY/MM �ł͈ȉ��� exGGYY/MM �Ɠ����̌��ʂ�Ԃ��Ȃ����
		///	�����܂��񂪁A���ɂ��̒�`���g�p���Ă��鏈��������̂ł��̂܂܂ɂ��Ă����܂��B</item>
		///	<item>				exGGYY/MM  : ��L GGYY/MM �̑���Ɏg�p���Ă��������B ���� + �N + / +��  ��) ����18/08</item>
		/// </list>
		/// <br>Note       : DateTime���w�肳�ꂽ���t�t�H�[�}�b�g�`���̕�����ɕϊ����܂�</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.08.04</br>
		/// </remarks>
		public static string DateTimeToString(string dateFormat, DateTime inDateTime, string defaultStr)
		{

			// ���t�L�����`�F�b�N
			if (!IsAvailableDate(inDateTime))
			{
				return defaultStr;
			}
			else
			{
				// ������ϊ�
				return DateTimeToString(dateFormat, inDateTime);
			}
		}

		// ��������(��,��,�b)
		// ��������(��,��,�b)(HHMMSS)

		// �����������擾����(�����擾)
		/// <summary>
		/// �����������擾����(�����擾)
		/// </summary>
		/// <param name="year">�N</param>
		/// <param name="month">��</param>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : R.Sokei</br>
		/// <br>Date       : 2005.07.10</br>
		/// </remarks>
		public static int GetLastDate(int year, int month)
		{
			return DateTime.DaysInMonth(year, month);
		}

		/// <summary>
		/// �����������擾����(�����擾)
		/// </summary>
		/// <param name="inLongDate">YYYYMMDD�`��(8��)�̓��t</param>
		/// <remarks>
		/// <br>Note       : </br>
		/// <br>Programmer : R.Sokei</br>
		/// <br>Date       : 2005.07.10</br>
		/// </remarks>
		public static int GetLastDate(int inLongDate)
		{
			DateTime dt = LongDateToDateTime(inLongDate);
			return DateTime.DaysInMonth(dt.Year, dt.Month);
		}


		///// <summary>
		///// �����������擾����(�����擾)
		///// </summary>
		///// <param name="inLongdateFormat">inLongDate�̃t�H�[�}�b�g�`�����w�肵�܂�</param>
		///// <param name="inLongDate">���l�`���̓��t</param>
		///// <remarks>
		///// <br>Note       : </br>
		///// <br>Programmer : R.Sokei</br>
		///// <br>Date       : 2005.07.10</br>
		///// <br>��)</br>
		///// <br>inLongDate��YYYYMMDD�`���̏ꍇ�AinLongdateFormat�� TDateTimeFormat.df4Y2M2D ���w�肷��</br>
		///// <br>inLongDate��YYYYMM�`���̏ꍇ�AinLongdateFormat�� TDateTimeFormat.df4Y2M ���w�肷��</br>
		///// </remarks>
		//		public static int GetLastDate(TDateTimeFormat inLongdateFormat, int inLongDate)
		//		{
		//			TDateTimeFormat.df4Y2M
		//			DateTime dt = LongDateToDateTime( ,inLongDate);
		//			return DateTime.DaysInMonth(dt.Year , dt.Month);
		//		}


		// �w����t�̗j�����擾����

		// �N���̉��Z
		// �N���̌��Z
		// �����̉��Z
		// �����̌��Z
		// �����̉��Z
		// �����̌��Z

		// �[�N����

		// �w�莞�����wAM/PM HH:MM:SS�x�ɕҏW����
		// �w�莞�����wAM/PM HH:MM�x�ɕҏW����
		// �w�莞�����wAM/PM HH�x�ɕҏW����

		/// <summary>
		///
		/// </summary>
		/// <param name="dateFormat"></param>
		/// <param name="inDateTime"></param>
		/// <returns></returns>
		public static string[] DateTimeToStringArray(string dateFormat, DateTime inDateTime)
		{
			string[] strTmp = new string[4];
			StringBuilder rDate1 = new StringBuilder();
			StringBuilder rDate2 = new StringBuilder();
			StringBuilder rDate3 = new StringBuilder();
			StringBuilder rDate4 = new StringBuilder();

			string rGengo = ""; int rYear = 0; int rMonth = 0; int rDay = 0;

			SplitDate("GGYYMMDD", inDateTime, ref rGengo, ref rYear, ref rMonth, ref rDay);

			if (dateFormat.Equals("YYYYMM"))
			{
				//case "GGyymmdd":
				rDate1.Append(rGengo);
				rDate1.Append(rYear.ToString().PadLeft(2));
				rDate1.Append("�N");
				rDate1.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate1.Append("��");
				//case "ggyy/mm/dd":
				rDate2.Append(GetRyakGou(rGengo));
				rDate2.Append(rYear.ToString().PadLeft(2));
				rDate2.Append("/");
				rDate2.Append(inDateTime.Month.ToString().PadLeft(2));
				//case "YYYYmmdd":
				rDate3.Append(inDateTime.Year.ToString().PadLeft(4));
				rDate3.Append("�N");
				rDate3.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate3.Append("��");
				//case "YYYY/mm/dd":
				rDate4.Append(inDateTime.Year.ToString().PadLeft(4));
				rDate4.Append("/");
				rDate4.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate4.Append("/");
			}
			else
			{
				//case "GGyymmdd":
				rDate1.Append(rGengo);
				rDate1.Append(rYear.ToString().PadLeft(2));
				rDate1.Append("�N");
				rDate1.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate1.Append("��");
				rDate1.Append(inDateTime.Day.ToString().PadLeft(2));
				rDate1.Append("��");
				//case "ggyy/mm/dd":
				rDate2.Append(GetRyakGou(rGengo));
				rDate2.Append(rYear.ToString().PadLeft(2));
				rDate2.Append("/");
				rDate2.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate2.Append("/");
				rDate2.Append(inDateTime.Day.ToString().PadLeft(2));
				//case "YYYYmmdd":
				rDate3.Append(inDateTime.Year.ToString().PadLeft(4));
				rDate3.Append("�N");
				rDate3.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate3.Append("��");
				rDate3.Append(inDateTime.Day.ToString().PadLeft(2));
				rDate3.Append("��");
				//case "YYYY/mm/dd":
				rDate4.Append(inDateTime.Year.ToString().PadLeft(4));
				rDate4.Append("/");
				rDate4.Append(inDateTime.Month.ToString().PadLeft(2));
				rDate4.Append("/");
				rDate4.Append(inDateTime.Day.ToString().PadLeft(2));
				rDate4.Append("/");
			}

			strTmp.SetValue(rDate1.ToString(), 0);
			strTmp.SetValue(rDate2.ToString(), 1);
			strTmp.SetValue(rDate3.ToString(), 2);
			strTmp.SetValue(rDate4.ToString(), 3);

			return strTmp;
		}

		private static string LongDateToBaseString(string longDateFormat, int inLongDate)
		{
			return inLongDate.ToString().PadLeft(longDateFormat.Length, '0');
		}

		/// <summary>
		///  LongDate�`���̓��t���w�肳�ꂽ�t�H�[�}�b�g �`���̕�����ɕϊ����܂�
		/// </summary>
		/// <param name="longDateFormat">�ϊ��Ώۓ��t�̃t�H�[�}�b�g�`��(LongDate�`�� YYYYMMDD or YYYYMM)</param>
		/// <param name="dateFormat">�ϊ�������t�t�H�[�}�b�g�`��(YYYYMMDD, YYYYMM�E�E�E)</param>
		/// <param name="inLongDate">�ϊ��Ώۓ��t(LongDate�`��)</param>
		/// <param name="longDateEditor">LongDate�`�����t�̕ҏW���@(TLongDateEditor.ZeroSuppress �́AlongDateFormat��"YYYYMMDD","YYYYMM"���̂ݗL��)</param>
		/// <returns>���t�ϊ�����(string)</returns>
		/// <remarks>
		/// <list type="bullet">
		///	<item>�t�H�[�}�b�g�`��(dateFormat) : �o�͌���(��)</item>
		///	<item>YYYYMMDD   : 2004�N01��01��</item>
		///	<item>YYYYmmdd   : 2004�N 1�� 1��</item>
		///	<item>YYYYMM     : 2004�N01��</item>
		///	<item>YYYYmm     : 2004�N 1��</item>
		///	<item>GGYYMMDD   : ����16�N01��01��</item>
		///	<item>GGyymmdd   : ���� 5�N 1�� 1��</item>
		///	<item>GGYYMM     : ����16�N01��</item>
		///	<item>GGyymm     : ���� 5�N 1��</item>
		///	<item>ggYYMM     : H16�N01��</item>
		///	<item>ggyymm     : H 5�N 1��</item>
		///	<item>ggYY/MM/DD : H16/01/01</item>
		///	<item>ggyy/mm/dd : H 5/ 1/ 1</item>
		///	<item>ggYY/MM    : H16/01</item>
		///	<item>ggyy/mm    : H 5/ 1</item>
		///	<item>ggYY.MM.DD : H16.01.01</item>
		///	<item>ggyy.mm.dd : H 5. 1. 1</item>
		///	<item>ggYY.MM    : H16.01</item>
		///	<item>ggyy.mm    : H 5. 1</item>
		///	<item>GGYY       : ����16�N</item>
		///	<item>ggYY       : H16�N</item>
		///	<item>GGyy       : ���� 5�N</item>
		///	<item>ggyy       : H 5�N</item>
		///	<item>YYYY/MM/DD : 2004/01/01</item>
		///	<item>YYYY/mm/dd : 2004/ 1/ 1</item>
		///	<item>YYYY.MM.DD : 2004.01.01</item>
		///	<item>YYYY.mm.dd : 2004. 1. 1</item>
		///	<item>exggYY     : H16</item>
		///	<item>exggyy     : H 5</item>
		///	<item>ggYY.      : H16</item>
		///	<item>ggyy.      : H 5</item>
		///	<item>ggYY/      : H16</item>
		///	<item>ggyy/      : H 5</item>
		///	<item>GG         : ����</item>
		///	<item>gg         : H</item>
		/// <item>GGYY/MM    : H18/08
		/// ���̒�`���Ԉ���Ă��܂��B �{�� GGYY/MM �ł͈ȉ��� exGGYY/MM �Ɠ����̌��ʂ�Ԃ��Ȃ����
		///	�����܂��񂪁A���ɂ��̒�`���g�p���Ă��鏈��������̂ł��̂܂܂ɂ��Ă����܂��B</item>
		///	<item>				exGGYY/MM  : ��L GGYY/MM �̑���Ɏg�p���Ă��������B ���� + �N + / +��  ��) ����18/08</item>
		/// </list>
		/// <br>Note�@�@�@�@�@�@ :   LongDate�`���̓��t���w�肳�ꂽ�t�H�[�}�b�g �`���̕�����ɕϊ����܂�</br>
		/// <br>                     �����񍶑��͕K�v�ɉ����ă[�����߂���܂�</br>
		/// <br>                     longDateFormat��YYYYMMDD�`���̏ꍇ�ɁA���t��00���ƁA�S�ċ󔒂Ŗ߂�܂�</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		public static string LongDateToString(string longDateFormat, string dateFormat, int inLongDate, TLongDateEditor longDateEditor)
		{
			if (inLongDate.Equals(0))
			{
				return "";
			}
			else
			{
				//-- 2009.05.29 Add Start by T.Sugawa ------------------------------------------------//
				if (longDateFormat == "YYYYMM")
				{
					int year = inLongDate / 100;
					int month = inLongDate % 100;

					switch (year)
					{
						case 1989:		//@ ���a64�N �� ����1�N�Ή�
							// ���� 1�� �� 1989/1/8(����)�ɒu������ and "YYYYMMDD"�ɕύX
							if (month == 1)
							{
								inLongDate = inLongDate * 100 + 8;
								longDateFormat = "YYYYMMDD";
							}
							break;
						default:
							break;
					}
				}
				//-- 2009.05.29 Add End by T.Sugawa --------------------------------------------------//

				// �[���T�v���X����K�v������ꍇ
				if (longDateEditor == TLongDateEditor.ZeroSuppress)
				{
					// 2006.11.08���݁A
					// YYYYMMDD�`���œ��͓��t�������ꍇ(��: 20061100 ��)�A�ϊ�����镶����͋󕶎���ɂȂ�܂�
					// ���̏ꍇ�ɁATLongDateEditor.ZeroSuppress ��L���ɂ������ꍇ�́A�ȉ��̏����܂���
					// ChangeDateFormatZeroSuppress �̏����ɏC�����K�v�ɂȂ�܂�

					// dateFormat --> �[���T�v���X����ꍇ�̓[���ɊY������L�q���폜���� ��) ���t��20060800�œ��͂���Ă���ꍇ "YYYYMMDD" ----> "YYYYMM"
					//string chgFormat = ChangeDateFormatZeroSuppress(longDateFormat, ref inLongDate, dateFormat);			// 2009.05.29 Chg T.Sugawa
					string chgFormat = ChangeDateFormatZeroSuppress(ref longDateFormat, ref inLongDate, dateFormat);

					// LongDate --> DateTime�ϊ�
					DateTime dt = LongDateToDateTime(longDateFormat, inLongDate);

					// DateTime�ϊ� --> String�ϊ�
					return DateTimeToString(chgFormat, dt);
				}
				// �[���T�v���X����K�v�������ꍇ�͂��̂܂ܕϊ����������s����
				else
				{
					// LongDate --> DateTime�ϊ�
					DateTime dt = LongDateToDateTime(longDateFormat, inLongDate);

					// DateTime�ϊ� --> String�ϊ�
					return DateTimeToString(dateFormat, dt);
				}
			}
		}

		/// <summary>
		/// �ҏW������ύX����(�[���T�v���X)
		/// </summary>
		/// <param name="inLongDataFormat">���l�`���̓��͓��t�̃t�H�[�}�b�g(YYYYMMDD or YYYYMM)</param>
		/// <param name="inLongDate">���l�`���̓��͓��t</param>
		/// <param name="orgDateFormat">�ϊ�������t�t�H�[�}�b�g</param>
		/// <returns></returns>
		//private static string ChangeDateFormatZeroSuppress(string inLongDataFormat, ref int inLongDate, string orgDateFormat)		// 2009.05.29 Chg T.Sugawa
		private static string ChangeDateFormatZeroSuppress(ref string inLongDataFormat, ref int inLongDate, string orgDateFormat)
		{
			string inLDateStr = inLongDataFormat;
			string retDateFormat = orgDateFormat;
			if (inLDateStr == "")
			{
				inLDateStr = "YYYYMMDD";
			}

			if (inLDateStr == "YYYYMMDD")
			{
				int day = inLongDate % 100;
				if (day.Equals(0))
				{
					// ���t�������ꍇ ".dd", "/dd", "dd" ���폜����
					retDateFormat = retDateFormat.Replace(".dd", "");
					retDateFormat = retDateFormat.Replace("/dd", "");
					retDateFormat = retDateFormat.Replace(".DD", "");
					retDateFormat = retDateFormat.Replace("/DD", "");
					retDateFormat = retDateFormat.Replace("dd", "");
					retDateFormat = retDateFormat.Replace("DD", "");

					// YYYYMMDD�`���Ń[���T�v���X��L���ɂ������ꍇ�́A�ȉ��̏����̃R�����g���O���ėL���ȃR�[�h�ɂ��܂�

					// inLongDate  = inLongDate + 8; // ���a64�N ----> �������N�̏���

					// ����L������L���ɂ��邱�ƂŁALongDateToDateTime���œ��t�������l�ɕϊ������̂�h�����Ƃ��ł��܂�
				}
			}
			else if (inLDateStr == "YYYYMM")
			{
				int month = inLongDate % 100;
				if (month.Equals(0))
				{
					// ���������ꍇ ���t��"mm"���폜����
					retDateFormat = retDateFormat.Replace(".dd", "");
					retDateFormat = retDateFormat.Replace("/dd", "");
					retDateFormat = retDateFormat.Replace(".DD", "");
					retDateFormat = retDateFormat.Replace("/DD", "");
					retDateFormat = retDateFormat.Replace("dd", "");
					retDateFormat = retDateFormat.Replace("DD", "");

					retDateFormat = retDateFormat.Replace("mm", "");
					retDateFormat = retDateFormat.Replace("MM", "");

                    int year = inLongDate / 100;

                    // �����J�n�N�̏ꍇ�́A���̔N�̈�Ԍ�̌����̌��Ƃ���
                    // ��������񃊃X�g�͐V�����������珇�Ԃɓ����Ă���
                    ArrayList eraInfoList = GetEraInfoList();
                    bool isEraStartYear = false;
                    foreach (EraInfo info in eraInfoList)
                    {
                        if (info.StartDate.Year < year)
                        {
                            // �J�n���̔N����̏ꍇ�́A�Ȍ�̌���������K�v���Ȃ����߃��[�v�𔲂���
                            break;
                        }
                        if (year == info.StartDate.Year)
                        {
                            if (info.StartDate.Day == 1 || info.StartDate.Month == 12)
                            {
                                // 1���Ɍ������n�܂�A�������́A12���Ɍ������n�܂�ꍇ�́A���̌��Ƃ��Ĉ���
                                inLongDate = inLongDate + info.StartDate.Month;
                            }
                            else
                            {
                                // ����ȊO�́A�����J�n���̗����Ƃ��Ĉ���
                                inLongDate = inLongDate + info.StartDate.Month + 1;
                            }
                            isEraStartYear = true;
                            break;
                        }
                    }

                    // �����J�n���łȂ��ꍇ�́A1���Ƃ��Ĉ���
                    if (!isEraStartYear)
                    {
                        inLongDate = inLongDate + 1;
                    }
				}
			}

			return retDateFormat;
		}

		/// **********************************************************************
		/// Module name      : LongDateToString
		/// <summary>
		///                    LongDate�`���̓��t���w�肳�ꂽ�t�H�[�}�b�g �`���̕�����ɕϊ����܂�
		/// </summary>
		/// <param name="longDateFormat">
		///                    �ϊ��Ώۓ��t�̃t�H�[�}�b�g�`��(LongDate�`�� YYYYMMDD or YYYYMM)
		/// </param>
		/// <param name="dateFormat">
		///                    ���t�t�H�[�}�b�g�`��(YYYYMMDD, YYYYMM�E�E�E)
		/// </param>
		/// <param name="inLongDate">
		///                    �ϊ��Ώۓ��t(LongDate�`��)
		/// </param>
		/// <returns>
		///                    ���t�ϊ�����(string)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <list type="bullet">
		///	<item>�t�H�[�}�b�g�`��(dateFormat) : �o�͌���(��)</item>
		///	<item>YYYYMMDD   : 2004�N01��01��</item>
		///	<item>YYYYmmdd   : 2004�N 1�� 1��</item>
		///	<item>YYYYMM     : 2004�N01��</item>
		///	<item>YYYYmm     : 2004�N 1��</item>
		///	<item>GGYYMMDD   : ����16�N01��01��</item>
		///	<item>GGyymmdd   : ���� 5�N 1�� 1��</item>
		///	<item>GGYYMM     : ����16�N01��</item>
		///	<item>GGyymm     : ���� 5�N 1��</item>
		///	<item>ggYYMM     : H16�N01��</item>
		///	<item>ggyymm     : H 5�N 1��</item>
		///	<item>ggYY/MM/DD : H16/01/01</item>
		///	<item>ggyy/mm/dd : H 5/ 1/ 1</item>
		///	<item>ggYY/MM    : H16/01</item>
		///	<item>ggyy/mm    : H 5/ 1</item>
		///	<item>ggYY.MM.DD : H16.01.01</item>
		///	<item>ggyy.mm.dd : H 5. 1. 1</item>
		///	<item>ggYY.MM    : H16.01</item>
		///	<item>ggyy.mm    : H 5. 1</item>
		///	<item>GGYY       : ����16�N</item>
		///	<item>ggYY       : H16�N</item>
		///	<item>GGyy       : ���� 5�N</item>
		///	<item>ggyy       : H 5�N</item>
		///	<item>YYYY/MM/DD : 2004/01/01</item>
		///	<item>YYYY/mm/dd : 2004/ 1/ 1</item>
		///	<item>YYYY.MM.DD : 2004.01.01</item>
		///	<item>YYYY.mm.dd : 2004. 1. 1</item>
		///	<item>exggYY     : H16</item>
		///	<item>exggyy     : H 5</item>
		///	<item>ggYY.      : H16</item>
		///	<item>ggyy.      : H 5</item>
		///	<item>ggYY/      : H16</item>
		///	<item>ggyy/      : H 5</item>
		///	<item>GG         : ����</item>
		///	<item>gg         : H</item>
		/// <item>GGYY/MM    : H18/08
		/// ���̒�`���Ԉ���Ă��܂��B �{�� GGYY/MM �ł͈ȉ��� exGGYY/MM �Ɠ����̌��ʂ�Ԃ��Ȃ����
		///	�����܂��񂪁A���ɂ��̒�`���g�p���Ă��鏈��������̂ł��̂܂܂ɂ��Ă����܂��B</item>
		///	<item>				exGGYY/MM  : ��L GGYY/MM �̑���Ɏg�p���Ă��������B ���� + �N + / +��  ��) ����18/08</item>
		/// </list>
		/// <br>Note�@�@�@�@�@�@ :   LongDate�`���̓��t���w�肳�ꂽ�t�H�[�}�b�g �`���̕�����ɕϊ����܂�</br>
		/// <br>                     �����񍶑��͕K�v�ɉ����ă[�����߂���܂�</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		/// **********************************************************************
		public static string LongDateToString(string longDateFormat, string dateFormat, int inLongDate)
		{
			return LongDateToString(longDateFormat, dateFormat, inLongDate, TLongDateEditor.Non);
		}

		/// **********************************************************************
		/// Module name      : LongDateToString
		/// <summary>
		///                    LongDate�`���̓��t���w�肳�ꂽ�t�H�[�}�b�g �`���̕�����ɕϊ����܂�
		/// </summary>
		/// <param name="dateFormat">
		///                    ���t�t�H�[�}�b�g�`��
		/// </param>
		/// <param name="inLongDate">
		///                    �ϊ��Ώۓ��t(LongDate�`��)
		/// </param>
		/// <returns>
		///                    ���t�ϊ�����(string)
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   LongDate�`���̓��t��YYYYMMDD�̕�����ɕϊ����܂�</br>
		/// <br>                     �����񍶑��͕K�v�ɉ����ă[�����߂���܂�</br>
		/// <br>Programer        :   R.Sokei</br>
		/// <br>Date             :   2004.12.06</br>
		/// <br>Update Note      :</br>
		/// </remarks>
		/// **********************************************************************
		public static string LongDateToString(string dateFormat, int inLongDate)
		{
			if (inLongDate.Equals(0))
			{
				return "";
			}
			else
			{
				// LongDate --> DateTime�ϊ�
				DateTime dt = LongDateToDateTime("YYYYMMDD", inLongDate);

				// DateTime�ϊ� --> String�ϊ�
				return DateTimeToString(dateFormat, dt);
			}
		}

		/// **********************************************************************
		/// Module name      : GetRyakGou
		/// <summary>
		///                    �w�肳�ꂽ�����̗������擾����
		///                    �w�肳�ꂽ���������݂��Ȃ��ꍇ�́A�ŐV�̌����̗��̂�ԋp����
		/// </summary>
		/// <param name="inGengou">
		///                    ����
		/// </param>
		/// <returns>
		///                    ����
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   �w�肳�ꂽ�����̗������擾����</br>
		/// <br>Programer        :   R.Sokei                            </br>
		/// <br>Date             :   2004.12.06                              </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static string GetRyakGou(string inGengou)
		{

            ArrayList eraInfoList = GetEraInfoList();

			string rRyakugo = ((EraInfo)eraInfoList[0]).EraUpperInitial;    
            foreach (EraInfo info in eraInfoList)
            {
                if (inGengou.Trim() == info.EraName)
                {
                    rRyakugo = info.EraUpperInitial;
                    break;
                }
            }

			return rRyakugo;
		}

		/// **********************************************************************
		/// Module name      : GetDayOfWeek
		/// <summary>
		///                    �j�����擾����
		///
		/// </summary>
		/// <param name="inDateTime">
		///                    �Ώۓ��t
		/// </param>
		/// <returns>
		///                    �j��
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   �j�����擾����</br>
		/// <br>Programer        :   R.Sokei                            </br>
		/// <br>Date             :   2004.12.06                              </br>
		/// <br>Update Note      :                  </br>
		/// </remarks>
		/// **********************************************************************
		public static string GetDayOfWeek(DateTime inDateTime)
		{
			return GetDayOfWeek("DDDSYS", inDateTime);
		}

		/// **********************************************************************
		/// Module name      : GetDayOfWeek
		/// <summary>
		///                    �j�����擾����
		///
		/// </summary>
		/// <param name="dateFormat">
		///                    �j���t�H�[�}�b�g�`��
		/// </param>
		/// <param name="inDateTime">
		///                    �Ώۓ��t
		/// </param>
		/// <returns>
		///                    �j��
		/// </returns>
		/// ----------------------------------------------------------------------
		/// <remarks>
		/// <br>Note�@�@�@�@�@�@ :   �j�����擾����    </br>
		/// <br>Programer        :   R.Sokei           </br>
		/// <br>Date             :   2004.12.06        </br>
		/// <br>Update Note      :                     </br>
		/// </remarks>
		/// **********************************************************************
		public static string GetDayOfWeek(string dateFormat, DateTime inDateTime)
		{
			string[] lWeeks = { "��", "��", "��", "��", "��", "��", "�y" };
			string lWeekChar = "�j��";
			string strWeek;

			switch (dateFormat.Trim())
			{
				case "DDDSYS":
					{
						strWeek = lWeeks[(int)inDateTime.DayOfWeek] + lWeekChar;
						break;
					}
				case "DDDCC":
					{
						strWeek = lWeeks[(int)inDateTime.DayOfWeek] + lWeekChar;
						break;
					}
				case "DDDENG":
					{
						strWeek = inDateTime.DayOfWeek.ToString();
						break;
					}
				case "DDD":
					{
						strWeek = lWeeks[(int)inDateTime.DayOfWeek].ToString();
						break;
					}
				default:
					{   // �f�t�H���g�́A���݂̌���(����)��Ԃ�
						strWeek = lWeeks[(int)inDateTime.DayOfWeek] + lWeekChar;
						break;
					}
			}

			return strWeek;
		}

		// ���t�L�����`�F�b�N
		/// <summary>
		/// ���t�̗L�����`�F�b�N����
		/// </summary>
		/// <param name="dateFormat">���͓��t������̓��t�`��</param>
		/// <param name="inDateTime">�`�F�b�N�Ώۓ��t(DateTime)</param>
		/// <returns>���t�L����: true:�L��, false:����(�s���ȓ��t)</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ���t������̗̂L�����`�F�b�N���܂�</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public static bool IsAvailableDate(TDateTimeFormat dateFormat, DateTime inDateTime)
		{
			bool isAvailable = true;

			try
			{
				string datestr = inDateTime.Year.ToString() + "/" + inDateTime.Month.ToString() + "/" + inDateTime.Day.ToString();
				DateTime dateTime = DateTime.Parse(datestr);

				if (dateFormat >= TDateTimeFormat.dfG2Y2M2D)
				{
                    // ��������̏ꍇ�́A�������N�i1868�N�j���O�̏ꍇ�͖����Ɣ��f
                    if (inDateTime.Year < 1868)
                    {
                        return false;
                    }
				}

				switch (dateFormat)
				{

					// "YYYYMMDD"�̌`��(��: 20050301)
					case TDateTimeFormat.df4Y2M2D:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}

							break;
						}

					// "YYMMDD"�̌`��(��: 050301)
					case TDateTimeFormat.df2Y2M2D:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// (�a��)GGYYMMDD�̌`��(��: 170301)
					case TDateTimeFormat.dfG2Y2M2D:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// YYYY�NMM���̌`��
					case TDateTimeFormat.df4Y2M:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// YY�NMM���̌`��
					case TDateTimeFormat.df2Y2M:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// ����YY�NMM���̌`��
					case TDateTimeFormat.dfG2Y2M:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// MM��DD���̌`��
					case TDateTimeFormat.df2M2D:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// YYYY�N�̌`��
					case TDateTimeFormat.df4Y:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// MM���̌`��
					case TDateTimeFormat.df2Y:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// ����YY�N�̌`��
					case TDateTimeFormat.dfG2Y:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// MM���̌`��
					case TDateTimeFormat.df2M:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}

					// DD���̌`��
					case TDateTimeFormat.df2D:
						{
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}
					default:
						{
							// �f�t�H���g�́A���݂̌���(����)��Ԃ�
							if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Month <= 1))
							{
								isAvailable = false;
							}
							else if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Month <= 1))
							{
								isAvailable = false;
							}
							break;
						}
				}

				return isAvailable;
			}
			catch (ArgumentNullException)
			{
				// �w�肳�ꂽ�l��NULL�̏ꍇ
				isAvailable = false;
				return isAvailable;
			}
			catch (FormatException)
			{
				// �w�菑���ʂ�ɕϊ��ł��Ȃ��ꍇ�̗�O
				isAvailable = false;
				return isAvailable;
			}
		}

		/// <summary>
		/// ���t�̗L�����`�F�b�N����
		/// </summary>
		/// <param name="dateFormat">���͓��t������̓��t�`��</param>
		/// <param name="inDateTimeString">�`�F�b�N�Ώۓ��t������</param>
		/// <returns>���t�L����: true:�L��, false:����(�s���ȓ��t)</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ���t������̗̂L�����`�F�b�N���܂�</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public static bool IsAvailableDate(TDateTimeFormat dateFormat, string inDateTimeString)
		{
			bool isAvailable = true;

			try
			{
				DateTime dateTime;
				System.Globalization.Calendar calendar = new System.Globalization.JapaneseCalendar();
				System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("ja-JP");
				culture.DateTimeFormat.Calendar = calendar;
				string datestr = inDateTimeString;

				switch (dateFormat)
				{
					// "YYYYMMDD"�̌`��(��: 20050301)
					case TDateTimeFormat.df4Y2M2D:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// "YYMMDD"�̌`��(��: 050301)
					case TDateTimeFormat.df2Y2M2D:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// (�a��)GGYYMMDD�̌`��(��: 170301)
					case TDateTimeFormat.dfG2Y2M2D:
						{
                            // �擾���������E�a��̔N�͎g�p���Ă��炸�A��O���������邩�ۂ��ɂ����g�p���Ă��Ȃ����߁A�V�����̉��Ή��ł͓��ɉ������Ȃ��B
							dateTime = DateTimeParseExact(datestr, "ggyy/M/d");

							if (dateFormat >= TDateTimeFormat.dfG2Y2M2D)
							{
                                // ��������̏ꍇ�́A�������N�i1868�N�j���O�̏ꍇ�͖����Ɣ��f
                                if (dateTime.Year < 1868)
                                {
                                    return false;
                                }
							}
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// YYYY�NMM���̌`��
					case TDateTimeFormat.df4Y2M:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// YY�NMM���̌`��
					case TDateTimeFormat.df2Y2M:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// ����YY�NMM���̌`��
					case TDateTimeFormat.dfG2Y2M:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// MM��DD���̌`��
					case TDateTimeFormat.df2M2D:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// YYYY�N�̌`��
					case TDateTimeFormat.df4Y:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// MM���̌`��
					case TDateTimeFormat.df2Y:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// ����YY�N�̌`��
					case TDateTimeFormat.dfG2Y:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// MM���̌`��
					case TDateTimeFormat.df2M:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					// DD���̌`��
					case TDateTimeFormat.df2D:
						{
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}

					default:
						{
							// �f�t�H���g�́A���݂̌���(����)��Ԃ�
							dateTime = DateTimeParseExact(datestr, "yyyy/M/d");
							if ((dateTime.Year <= 1) && (dateTime.Month <= 1) && (dateTime.Day <= 1))
							{
								isAvailable = false;
							}
							else if (datestr.Equals("1/1/1"))
							{
								isAvailable = false;
							}

							break;
						}
				}

				return isAvailable;
			}
			catch (ArgumentNullException)
			{
				// �w�肳�ꂽ�l��NULL�̏ꍇ
				isAvailable = false;
				return isAvailable;
			}
			catch (FormatException)
			{
				// �w�菑���ʂ�ɕϊ��ł��Ȃ��ꍇ�̗�O
				isAvailable = false;
				return isAvailable;
			}
		}

		// ���t�L�����`�F�b�N
		/// <summary>
		/// ���t�̗L�����`�F�b�N����
		/// </summary>
		/// <param name="inDateTime">�`�F�b�N�Ώۓ��t(DateTime)</param>
		/// <returns>���t�L����: true:�L��, false:����(�s���ȓ��t)</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ���t������̗̂L�����`�F�b�N���܂�</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public static bool IsAvailableDate(DateTime inDateTime)
		{
			bool isAvailable = true;

			if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Day <= 1))
			{
				isAvailable = false;
			}

			return isAvailable;
		}

		/// <summary>
		/// ���t�̗L�����`�F�b�N����
		/// </summary>
		/// <param name="inDateTime">�`�F�b�N�Ώۓ��t(DateTime)</param>
		/// <param name="mode">0:MinValue(0001/01/01)��s���Ȗ����ȓ��t�Ɣ��肷��, 1:0:MinValue(0001/01/01)��L���ȓ��t�Ɣ��肷��</param>
		/// <returns>���t�L����: true:�L��, false:����(�s���ȓ��t)</returns>
		/// <remarks>
		/// <br>Note       : �w�肳�ꂽ���t������̗̂L�����`�F�b�N���܂�</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public static bool IsAvailableDate(DateTime inDateTime, int mode)
		{
			bool isAvailable = true;

			if (mode.Equals(0))
			{
				if ((inDateTime.Year <= 1) && (inDateTime.Month <= 1) && (inDateTime.Day <= 1))
				{
					isAvailable = false;
				}
			}
			else
			{
				if ((inDateTime.Year < 1) && (inDateTime.Month < 1) && (inDateTime.Day < 1))
				{
					isAvailable = false;
				}
			}

			return isAvailable;
		}

		/// <summary>
		/// �������X�g�擾
		/// </summary>
		/// <param name="rGList">�������X�g(�擾�p)</param>
		/// <returns>�����X�e�[�^�X 0:����</returns>
		/// <remarks>
		/// <br>Note       : �������X�g���擾���܂�</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.03.22</br>
		/// </remarks>
		public static int GetGengouList(out ArrayList rGList)
		{

            rGList = GetEraNameList();

			return 0;
		}

        /// <summary>
        /// �������X�g�擾�i����̌����ȍ~���擾�j
        /// </summary>
        /// <param name="rGList">�������X�g(�擾�v)</param>
        /// <param name="mode">�擾���錳���̃��[�h</param>
        /// <returns>�����X�e�[�^�X 0:����</returns>
        /// <remarks>
        /// <br>Note       : �������X�g���擾���܂�</br>
        /// <br>             ��{�I�ɍ���͎擾�����������X�g����s�v�Ȍ������폜���鏈�����e�v���O�������ōs�킸�A�{���\�b�h���g�p���Ă��������B</br>
        /// <br>Programmer : 31983 S.Tomohiro</br>
        /// <br>Date       : 2018.12.11</br>
        /// </remarks>
        public static int GetGengouList(out ArrayList rGList, TDateTimeGengouMode mode)
        {
            // �ŐV�������炢���̌������擾���邩�𔻒f����B
            rGList = new ArrayList();
            ArrayList eraNameList = GetEraNameList();
            int getEraCount = eraNameList.Count - (int)mode + 1;

            // �擾�����A�ԋp�pList�Ɉڂ��ւ�
            foreach (string eraName in eraNameList)
            {
                if (getEraCount <= 0)
                {
                    break;
                }

                rGList.Add(eraName);
                getEraCount--;
            }

            return 0;
        }

		/// <summary>
		/// �a�����-->LongDate(YYYYMMDD)�ϊ�
        /// �ϊ��Ɏ��s�����ۂ́A����1�N1��1����ԋp���܂��B
        /// ���{���\�b�h�ł́A�����Ƃ��Č����{�N�����̕������ΏۂƂ��܂��B
        /// �@�܂��A�N�����̋�؂蕶���́A"/" "-" "."��3��ނ����e���܂��B
        /// �@�����ɂ��ẮA����2�����E�����擪1�����E�������p�啶���E�������p�����������e���܂��B
        /// �@����ȊO�̌`���̒l�������ꍇ���A.NET Framework�̓���ɏ]���ĕϊ������݂܂����A
        /// �@���삷��[���̏�Ԃɂ���ẮA�V�����ւ̑Ή����ł��Ȃ��ꍇ������܂��B
        /// �@�����b���t�^���ꂽ������ɂ��Ă��A.NET Framework�̓���ɏ]���ĕϊ������݂܂��B
		/// </summary>
		/// <param name="japaneseDate">�a�����(�� "����17�N8��1��")</param>
		/// <returns>�ϊ����t(YYYYMMDD)</returns>
		/// <remarks>
		/// <br>Note       : �a������LongDate�^(YYYYMMDD)�̓��t�ɕϊ����܂�</br>
		/// <br>Programmer : 980056 R.Sokei</br>
		/// <br>Date       : 2005.08.08</br>
		/// </remarks>
		public static int JapaneseDateStringToLongDate(string japaneseDate)
		{
            // DateTime�ɕϊ��������̂�LongDate�ɕϊ����ĕԋp
			return DateTimeToLongDate(JapaneseDateStringToDateTime(japaneseDate));
        }

        /// <summary>
        /// �a�����-->DateTime�ϊ�
        /// �ϊ��Ɏ��s�����ۂ́A����1�N1��1����ԋp���܂��B
        /// ���{���\�b�h�ł́A�����Ƃ��Č����{�N�����̕������ΏۂƂ��܂��B
        /// �@�܂��A�N�����̋�؂蕶���́A"/" "-" "."��3��ނ����e���܂��B
        /// �@�����ɂ��ẮA����2�����E�����擪1�����E�������p�啶���E�������p�����������e���܂��B
        /// �@����ȊO�̌`���̒l�������ꍇ���A.NET Framework�̓���ɏ]���ĕϊ������݂܂����A
        /// �@���삷��[���̏�Ԃɂ���ẮA�V�����ւ̑Ή����ł��Ȃ��ꍇ������܂��B
        /// �@�����b���t�^���ꂽ������ɂ��Ă��A.NET Framework�̓���ɏ]���ĕϊ������݂܂��B
        /// ���{���\�b�h�́A���X���݂���JapaneseDateStringToLongDate���\�b�h�����Ƃɂ��Ă��܂�
        /// </summary>
        /// <param name="japaneseDate">�a�����(�� "����17�N8��1��")</param>
        /// <returns>�ϊ����t(DateTime�^)</returns>
        /// <remarks>
        /// <br>Note       : �a������DateTime�^�ɕϊ����܂�</br>
        /// <br>Programmer : 31983 S.Tomohiro</br>
        /// <br>Date       : 2019.02.14</br>
        /// </remarks>
        public static DateTime JapaneseDateStringToDateTime(string japaneseDate)
        {
            DateTime retDateTime = new DateTime(1, 1, 1);
            bool canConvert = false;

            try
            {
                string tmpDate = japaneseDate.Trim();

                // ��؂蕶����"�N"�E"��"�E"."�E"-"��"/"�ɕϊ��i���ׂĂ̋�؂蕶����"/"�ɂ���j
                tmpDate = japaneseDate.Replace("�N", "/");
                tmpDate = tmpDate.Replace("��", "/");
                tmpDate = tmpDate.Replace(".", "/");
                tmpDate = tmpDate.Replace("-", "/");

                // "��"���폜����
                tmpDate = tmpDate.Replace("��", string.Empty);

                // "/"�ŏI����Ă���ꍇ�́A�Ō��"/"���폜�i�N�⌎�݂̂̎w��̏ꍇ�����j
                if (tmpDate.EndsWith("/"))
                {
                    tmpDate = tmpDate.Substring(0, tmpDate.Length - 1);
                }

                // "/"�ŕ�����𕪊�
                string[] splitStr = tmpDate.Split(new char[] { '/' });

                string year = string.Empty;
                string month = string.Empty;
                string day = string.Empty;

                // 1�����̏ꍇ�͔N�������w�肳��Ă���Ɣ��f���āA���E����1��1���Ƃ��ď���
                if (splitStr.Length == 1)
                {
                    year = GetYearFromJapaneseYear(splitStr[0].Trim()).ToString();
                    month = "1";
                    day = "1";

                    canConvert = true;
                }
                // 2����ꍇ�͔N�����w�肳��Ă���Ɣ��f���āA����1���Ƃ��ď���
                else if (splitStr.Length == 2)
                {
                    year = GetYearFromJapaneseYear(splitStr[0].Trim()).ToString();
                    month = splitStr[1].Trim();
                    day = "1";

                    canConvert = true;
                }
                // 3����ꍇ�͔N�������w�肳��Ă���Ɣ��f���ď���
                else if (splitStr.Length == 3)
                {
                    year = GetYearFromJapaneseYear(splitStr[0].Trim()).ToString();
                    month = splitStr[1].Trim();
                    day = splitStr[2].Trim();

                    canConvert = true;
                }
                // ��L�ȊO�̃p�^�[���ɂ��ẮA�������W�b�N�ŏ��������s�icanConvert��false�Ȃ̂ŁA�����ł͓��ɉ������Ȃ��j

                if (canConvert)
                {
                    retDateTime = DateTime.Parse(year + "/" + month + "/" + day);
                }
            }
            catch (Exception)
            {
                // ��������̗�O��catch�����ꍇ�́A�����̃��W�b�N�ŏ��������s
                canConvert = false;
            }
            finally
            {
                if (!canConvert)
                {
                    // �ϊ��ł��Ȃ������ꍇ�͊�����JapaneseDateStringToLongDate���������s
                    IFormatProvider format = new System.Globalization.CultureInfo("ja-JP", true);

                    try
                    {
                        retDateTime = System.DateTime.Parse(
                            japaneseDate,
                            format,
                            System.Globalization.DateTimeStyles.None);
                    }
                    catch (ArgumentNullException)
                    {
                        retDateTime = new DateTime(1, 1, 1);
                    }
                    catch (FormatException)
                    {
                        retDateTime = new DateTime(1, 1, 1);
                    }
                }
            }

            // DateTime�^-->LongDate�^
            return retDateTime;
        }

        /// <summary>
        /// ���t���i�iTDateEdit�ETDateEdit2�EBDateEdit�j�̓��t�t�H�[�}�b�g�擾�����B
        /// �w�肵���t�H�[�����ƃR���|�[�l���g�ɐݒ肳�ꂽ���O����A���t�t�H�[�}�b�g���擾����B
        /// XML�ɐݒ肪�Ȃ��ꍇ�́Astring.Empty��ԋp����B
        /// ��TDateEdit�ETDateEdit2�EBDateEdit�ȊO����̌Ăяo���͑z�肵�Ă��܂���̂ŁA
        /// �@�ʏ��PG����̗��p�͍s��Ȃ��ł��������B
        /// </summary>
        /// <param name="formName">�t�H�[�����B�����ABroadleaf.Windows.Forms���O��Ԃ̂��̂��w�肷��B</param>
        /// <param name="componentName">�R���|�[�l���g�ɐݒ肳�ꂽ���O�iName�v���p�e�B�̒l�j</param>
        /// <returns>XML�ɐݒ肳��Ă�����t�t�H�[�}�b�g�B�ݒ肪�Ȃ��ꍇ��string.Empty�B</returns>
        public static string GetDateFormat(string formName, string componentName)
        {
            if (_formDateTimeFormat == null)
            {
                ReadDateFormatInfoXml();
            }

            Dictionary<string, string> dateTimeFormat;
            if (_formDateTimeFormat.TryGetValue(formName, out dateTimeFormat))
            {
                string format;
                if (dateTimeFormat.TryGetValue(componentName, out format))
                {
                    return format;
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// �w�肵�������̊�N�i�����Ɛ���ɂȂ�N�B�e������0�N�ɑ����j�擾�����B
        /// �������ɑ��݂��Ȃ��������w�肳�ꂽ�ꍇ��0��ԋp���܂��B
        /// </summary>
        /// <param name="eraName">������</param>
        /// <returns>��N</returns>
        public static int GetBaseYear(string eraName)
        {
            int baseYear = 0;
            ArrayList eraInfoList = GetEraInfoList();

            foreach (EraInfo info in eraInfoList)
            {
                if (info.EraName == eraName)
                {
                    baseYear = info.BaseYear;
                    break;
                }
            }

            return baseYear;
        }

        #region private methods
        /// <summary>
        /// ������񃊃X�g�̎擾�B
        /// ������񂪓ǂݍ��܂�Ă��Ȃ��ꍇ��XML��ǂݍ���ŕԋp�A�ǂݍ��ݍς݂̏ꍇ�͓ǂݍ��ݍς݃f�[�^��ԋp����B
        /// </summary>
        /// <returns>������񃊃X�g</returns>
        private static ArrayList GetEraInfoList()
        {
            // ������񂪓ǂݍ��܂�Ă��Ȃ��ꍇ�́A�ǂݍ��݂��s���B
            if (_eraInfoList.Count == 0)
            {
                ReadEraInfoXml();
            }

            return _eraInfoList;
        }

        /// <summary>
        /// ���������X�g�̎擾�B
        /// ������񂪓ǂݍ��܂�Ă��Ȃ��ꍇ��XML��ǂݍ���ŕԋp�A�ǂݍ��ݍς݂̏ꍇ�͓ǂݍ��ݍς݃f�[�^��ԋp����B
        /// </summary>
        /// <returns>������񃊃X�g</returns>
        private static ArrayList GetEraNameList()
        {
            // ������񂪓ǂݍ��܂�Ă��Ȃ��ꍇ�́A�ǂݍ��݂��s���B
            if (_eraNameList.Count == 0)
            {
                ReadEraInfoXml();
            }

            return (ArrayList)(_eraNameList.Clone());
        }

        /// <summary>
        /// �������XML�̓ǂݍ��ݏ���
        /// ���������XML�����݂��Ȃ��ꍇ�A�t�@�C���̒��g���Ȃ��ꍇ�́A�����R���{�{�b�N�X����ŕ\������܂��B
        /// �@�����R���{�{�b�N�X����ŕ\�������悤�Ȗ₢���킹���󂯂��ۂ́AXML�̔j���E�������^���Ă��������B
        /// ���Ăяo�����ōs���Ă���0���`�F�b�N�����蔲���Ă��܂��ꍇ�����邱�Ƃ��m�F���ꂽ���߁A
        /// �@���ꌳ����񂪊��ɓo�^����Ă���ꍇ�͂��̌����̒ǉ����X�L�b�v����悤�ɂ��Ă��܂��B
        /// </summary>
        private static void ReadEraInfoXml()
        {
            EraInfo[] eraInfoArray = null;
            string assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location.ToString();
            string filePath = Path.Combine(Path.GetDirectoryName(assemblyPath), ERAINFO_XML_FILENAME);
            if (File.Exists(filePath))
            {
                // XML���猳�����N���X�z��Ƀf�V���A���C�Y����
                eraInfoArray = (EraInfo[])XmlDeserialize(filePath, typeof(EraInfo[]));
                if (eraInfoArray != null)
                {
                    foreach (EraInfo info in eraInfoArray)
                    {
                        // ������񃊃X�g�Ɠ����ɁA���������X�g���쐬���Ă���
                        // �I������23:59:59.9999999�ɐݒ肷��B
                        info.EndDate = info.EndDate.AddTicks(863999999999L);

                        // �񓯊������ł̏d���ǉ���h�����߁A�����ł��`�F�b�N�����Ă���List��Add����
                        if (!_eraNameList.Contains(info.EraName))
                        {
                            _eraNameList.Add(info.EraName);
                            _eraInfoList.Add(info);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ���t�t�H�[�}�b�g���XML�̓ǂݍ��ݏ���
        /// ���t�t�H�[�}�b�g���͔C�ӏ��̂��߁A�t�@�C�����Ȃ��ꍇ��1�����f�[�^���Ȃ��ꍇ�ł��G���[�Ƃ��Ȃ��B
        /// </summary>
        private static void ReadDateFormatInfoXml()
        {
            _formDateTimeFormat = new Dictionary<string, Dictionary<string, string>>();

            FormDateFormatInfo[] FormDateFormatInfoArray = null;
            string assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location.ToString();
            string filePath = Path.Combine(Path.GetDirectoryName(assemblyPath), DATETIMEFORMATINFO_XML_FILENAME);
            if (File.Exists(filePath))
            {
                // XML������t�t�H�[�}�b�g���N���X�z��Ƀf�V���A���C�Y����
                FormDateFormatInfoArray = (FormDateFormatInfo[])XmlDeserialize(filePath, typeof(FormDateFormatInfo[]));
                if (FormDateFormatInfoArray != null)
                {
                    // �擾�����f�[�^��Dictionary�`���ɕϊ�
                    foreach (FormDateFormatInfo formInfo in FormDateFormatInfoArray)
                    {
                        Dictionary<string, string> dateFormatInfo;
                        bool containsKey = false;
                        if (_formDateTimeFormat.ContainsKey(formInfo.FormName))
                        {
                            dateFormatInfo = _formDateTimeFormat[formInfo.FormName];
                            containsKey = true;
                        }
                        else
                        {
                            dateFormatInfo = new Dictionary<string, string>();
                        }

                        foreach (DateFormatInfo formatInfo in formInfo.DateFormatInfoArray)
                        {
                            if (dateFormatInfo.ContainsKey(formatInfo.ComponentName))
                            {
                                continue;
                            }

                            dateFormatInfo.Add(formatInfo.ComponentName, formatInfo.DateFormat);
                        }

                        if (!containsKey)
                        {
                            _formDateTimeFormat.Add(formInfo.FormName, dateFormatInfo);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// XML�����t�@�C�� �f�V���A���C�Y�����B
        /// ���ʏ��XmlByteSerializer��Read/Write�Ńt�@�C�����J���Ă��܂����߁A
        /// �@���������H�Ƀt�@�C���̔r���G���[�ɂȂ�ꍇ������܂��B
        /// �@���̂��߁A�{���i�Ǝ���Read���[�h�i�ǂݎ���p�j�Ńt�@�C�����J���A
        /// �@�r��������s��Ȃ��悤�ɂ��Ă��܂��B
        /// </summary>
        /// <param name="fileName">�f�V���A���C�Y�t�@�C����</param>
        /// <param name="type">�f�V���A���C�Y�I�u�W�F�N�g�^�C�v</param>
        /// <returns>�f�V���A���C�Y�I�u�W�F�N�g</returns>
        static private object XmlDeserialize(string fileName, Type type)
        {
            System.IO.FileStream fs = null;
            try
            {
                // XmlSerializer�I�u�W�F�N�g�̍쐬
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(type);
                // �ǂݎ���p�Ńt�@�C�����J��
                fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, FileAccess.Read);
                // XML�t�@�C������ǂݍ��݁A�t�V���A��������
                object ret = (object)serializer.Deserialize(fs);
                return ret;
            }
            finally
            {
                // ����
                if (fs != null) fs.Close();
            }
        }

        #endregion
    }
}
