//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ送信編集結果クラス
// プログラム概要   : ＵＯＥ送信編集結果の定義を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

namespace Broadleaf.Application.UIData
{
	# region ＵＯＥ送信編集結果（ヘッダー）クラス
	/// <summary>
	/// ＵＯＥ送信編集結果（ヘッダー）クラス
	/// </summary>
	public class UoeSndHed
	{
		# region Private Members
		/// <summary>業務区分</summary>
		private Int32 _businessCode;

		/// <summary>通信アセンブリID</summary>
		private string _commAssemblyId;

		/// <summary>UOE発注先コード</summary>
		private Int32 _uOESupplierCd;

		/// <summary>ＵＯＥ送信編集（明細）クラス</summary>
		private List<UoeSndDtl> _uoeSndDtlList;
		# endregion

		# region Properties
		/// <summary>
		/// 業務区分
		/// </summary>
		public Int32 BusinessCode
		{
			get { return _businessCode; }
			set { _businessCode = value; }
		}

		/// <summary>
		/// 通信アセンブリID
		/// </summary>
		public string CommAssemblyId
		{
			get { return _commAssemblyId; }
			set { _commAssemblyId = value; }
		}

		/// <summary>
		/// UOE発注先コード
		/// </summary>
		public Int32 UOESupplierCd
		{
			get { return _uOESupplierCd; }
			set { _uOESupplierCd = value; }
		}

		/// <summary>
		/// ＵＯＥ送信編集結果（明細）クラス
		/// </summary>
		public List<UoeSndDtl> UoeSndDtlList
		{
			get { return _uoeSndDtlList; }
			set { _uoeSndDtlList = value; }
		}
		# endregion

		# region Constructors
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public UoeSndHed()
		{
			_commAssemblyId = "";
			_businessCode = 0;
			_uOESupplierCd = 0;
			_uoeSndDtlList = new List<UoeSndDtl>();
		}
		# endregion
	}
	# endregion

	# region ＵＯＥ送信編集結果（明細）クラス
	/// <summary>
	/// ＵＯＥ送信編集結果（明細）クラス
	/// </summary>
	public class UoeSndDtl
	{
		# region Private Members
		/// <summary>発注回答番号</summary>
		private Int32 _uOESalesOrderNo;

		/// <summary>発注回答行番号</summary>
		private List<Int32> _lINENO;

		/// <summary>送信電文(JIS)</summary>
		private Byte[] _sndTelegram;

        /// <summary>送信電文サイズ</summary>
        private Int32 _sndTelegramLen;

		# endregion

		# region Properties
		/// <summary>
		/// 発注回答番号
		/// </summary>
		public Int32 UOESalesOrderNo
		{
			get { return _uOESalesOrderNo; }
			set { _uOESalesOrderNo = value; }
		}

		/// <summary>
		/// 発注回答行番号
		/// </summary>
		public List<Int32> UOESalesOrderRowNo
		{
			get { return _lINENO; }
			set { _lINENO = value; }
		}

		/// <summary>
		/// 送信電文
		/// </summary>
		public Byte[] SndTelegram
		{
			get { return _sndTelegram; }
			set { _sndTelegram = value; }
		}
		# endregion

        /// <summary>
        /// 送信電文サイズ
        /// </summary>
        public Int32 SndTelegramLen
        {
            get { return _sndTelegramLen; }
            set { _sndTelegramLen = value; }
        }

		# region Constructors
		public UoeSndDtl()
		{
			_uOESalesOrderNo = 0;
			_lINENO = new List<int>();
			_sndTelegram = new byte[2048];
            _sndTelegramLen = 0;
		}
		# endregion

	}
	# endregion
}
