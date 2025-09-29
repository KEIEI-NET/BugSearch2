//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ受信結果クラス
// プログラム概要   : ＵＯＥ受信結果の定義
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
	# region ＵＯＥ受信結果（ヘッダー）クラス
	/// <summary>
	/// ＵＯＥ受信結果（ヘッダー）クラス
	/// </summary>
	public class UoeRecHed
	{
		# region Private Members
		/// <summary>業務区分</summary>
		private Int32 _businessCode;

		//通信アセンブリID
		private string _commAssemblyId;

		//UOE発注先コード
		private Int32 _uOESupplierCd;

		/// <summary>ＵＯＥ受信結果（明細）クラス</summary>
		private List<UoeRecDtl> _uoeRecDtlList;
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
		/// ＵＯＥ受信編集結果（明細）クラス
		/// </summary>
		public List<UoeRecDtl> UoeRecDtlList
		{
			get { return _uoeRecDtlList; }
			set { _uoeRecDtlList = value; }
		}
		# endregion

		# region Constructors
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public UoeRecHed()
		{
			_commAssemblyId = "";
			_uOESupplierCd = 0;
			_uoeRecDtlList = new List<UoeRecDtl>();
		}
		# endregion
	}
	# endregion

	# region ＵＯＥ受信結果（明細）クラス
	/// <summary>
	/// ＵＯＥ受信結果（明細）クラス
	/// </summary>
	public class UoeRecDtl
	{
		# region Private Members
		/// <summary>発注回答番号</summary>
		private Int32 _uOESalesOrderNo;

		/// <summary>発注回答行番号</summary>
		private List<Int32> _lINENO;

		/// <summary>受信電文(JIS)</summary>
		private Byte[] _recTelegram;

        /// <summary>送信電文サイズ</summary>
        private Int32 _recTelegramLen;

		/// <summary>データ送信区分</summary>
		private Int32 _dataSendCode;

		/// <summary>データ復旧区分</summary>
		private Int32 _dataRecoverDiv;

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
		/// 受信電文
		/// </summary>
		public Byte[] RecTelegram
		{
			get { return _recTelegram; }
			set { _recTelegram = value; }
		}

        /// <summary>
        /// 受信電文サイズ
        /// </summary>
        public Int32 RecTelegramLen
        {
            get { return _recTelegramLen; }
            set { _recTelegramLen = value; }
        }

		/// <summary>
		/// データ送信区分
		/// </summary>
		public Int32 DataSendCode
		{
			get { return _dataSendCode; }
			set { _dataSendCode = value; }
		}

		/// <summary>
		/// データ復旧区分
		/// </summary>
		public Int32 DataRecoverDiv
		{
			get { return _dataRecoverDiv; }
			set { _dataRecoverDiv = value; }
		}


		# endregion

		# region Constructors
		public UoeRecDtl()
		{
			_uOESalesOrderNo = 0;
			_lINENO = new List<int>();
			_recTelegram = new byte[2048];
			_dataSendCode = 0;
			_dataRecoverDiv = 0;
            _recTelegramLen = 0;
		}
		# endregion

	}
	# endregion
}
