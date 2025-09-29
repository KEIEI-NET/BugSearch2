//****************************************************************************//
// システム         : PM.NSシリーズ
// プログラム名称   : ＵＯＥ共通処理クラス
// プログラム概要   : ＵＯＥ共通処理の定義
//----------------------------------------------------------------------------//
//                (c)Copyright  2008 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10402071-00 作成担当 : 立花 裕輔
// 作 成 日  2008/05/26  修正内容 : 新規作成
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : xuxh
// 修 正 日  2009/12/29  修正内容 : 【要件No.2】
//                                  発注先にトヨタを指定時には、リマーク２の入力は不可とする（連携時、ﾘﾏｰｸ2に連携番号として使用する為）																																							
// 	                                仕入明細（発注データ）の作成を行い通信は行わない様にする			
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : xuxh
// 修 正 日  2009/12/29  修正内容 : 【要件No.3】
//                                  発注先の入力制御（トヨタは入力不可とする）を行う
//----------------------------------------------------------------------------//
// 管理番号  10601190-00 作成担当 : 楊明俊
// 作 成 日  2010/03/08  修正内容 : PM1006 
//                                  UOE発注先が「日産」の場合、UOE発注データのみを作成し、通信は行わないように修正
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : gaoyh
// 作 成 日  2010/04/26  修正内容 : PM1007C 三菱UOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : 高峰
// 作 成 日  2010/05/07  修正内容 : PM1008 明治UOE-WEB対応に伴う仕様追加
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : liyp
// 作 成 日  2011/01/06  修正内容 : PM1008 Web-UOE用の通信アセンブリID定数を追加
//----------------------------------------------------------------------------//
// 管理番号 10607734-00  作成担当 : 朱 猛
// 作 成 日  2011/01/30  修正内容 : UOE自動化改良
//----------------------------------------------------------------------------//
// 管理番号  10607734-01 作成担当 : liyp
// 作 成 日  2011/03/01  修正内容 : 業務区分は「発注」（固定）に制御する
//----------------------------------------------------------------------------//
// 管理番号  10702591-00 作成担当 : 施炳中
// 作 成 日  2011/05/10  修正内容 : マツダWebUOE用の通信アセンブリID定数を追加
//----------------------------------------------------------------------------//
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
	# region ＵＯＥ共通処理
	/// <summary>
	/// ＵＯＥ共通処理
	/// </summary>
	public class UoeCommonFnc
	{
		# region Constructors
		UoeCommonFnc()
		{
		}
		# endregion

        # region Private Methods
        # region 最小値取得
        /// <summary>
        /// 最小値取得
        /// </summary>
        /// <param name="len1">カウント１</param>
        /// <param name="len2">カウント２</param>
        /// <param name="len3">カウント３</param>
        /// <returns>カウント</returns>
        private static int GetMinLength(int len1, int len2, int len3)
        {
            int len = GetMinLength(len1, len2);
            return (GetMinLength(len, len3));
        }
        /// <summary>
        /// 最小値取得
        /// </summary>
        /// <param name="len1">カウント１</param>
        /// <param name="len2">カウント２</param>
        /// <returns>カウント</returns>
        private static int GetMinLength(int len1, int len2)
        {
            return (len1 < len2 ? len1 : len2);
        }

        # endregion
		# endregion

        # region Public Methods
        # region メモリ初期化
        /// <summary>
		/// メモリ初期化
		/// </summary>
		/// <param name="dst">初期化先バッファ</param>
		/// <param name="src">初期化キャラクタ</param>
		/// <param name="count">カウンタ値</param>
		public static void MemSet(ref byte[] dst, byte src, int count)
		{
            MemSet(ref dst, 0, src, count);
		}

        /// <summary>
        /// メモリ初期化
        /// </summary>
        /// <param name="dst">初期化先バッファ</param>
        /// <param name="dstSt">初期化バッファの開始インディックス</param>
        /// <param name="src">初期化キャラクタ</param>
        /// <param name="count">カウンタ値</param>
        public static void MemSet(ref byte[] dst, int dstSt, byte src, int count)
        {
            for (int i = 0; i < GetMinLength(count, dst.Length); i++)
            {
                dst[dstSt+i] = src;
            }
        }
        # endregion

		# region メモリ比較
        /// <summary>
        /// メモリ比較(Byte･String)
        /// </summary>
        /// <param name="src">Byte比較バッファ</param>
        /// <param name="dst">String比較バッファ</param>
        /// <param name="len">カウンタ値</param>
        /// <returns>ステータス</returns>
		public static int MemCmp(byte[] src, string dst, int len)
		{
			return (MemCmp(src, 0, dst, len));
		}
        /// <summary>
        /// メモリ比較(Byte･String)
        /// </summary>
        /// <param name="src">Byte比較バッファ</param>
        /// <param name="srcSt">Byte比較バッファ インディックス</param>
        /// <param name="dst">String比較バッファ</param>
        /// <param name="len">カウンタ値</param>
        /// <returns>ステータス</returns>
		public static int MemCmp(byte[] src, int srcSt, string dst, int len)
		{
			byte[] dstByte = System.Text.Encoding.GetEncoding(932).GetBytes(dst);
			return (MemCmp(src, srcSt, dstByte, 0, len));
		}
        /// <summary>
        /// メモリ比較(Byte･Byte)
        /// </summary>
        /// <param name="src">Byte比較バッファ</param>
        /// <param name="dst">Byte比較バッファ</param>
        /// <param name="len">カウンタ値</param>
        /// <returns>ステータス</returns>
		public static int MemCmp(byte[] src, byte[] dst, int len)
		{
			return (MemCmp(src, 0, dst, 0, len));
		}
        /// <summary>
        /// メモリ比較(Byte[]･Byte[])
        /// </summary>
        /// <param name="src">Byte比較バッファ</param>
        /// <param name="srcSt">Byte比較バッファ インディックス</param>
        /// <param name="dst">Byte比較バッファ</param>
        /// <param name="dstSt">Byte比較バッファ インディックス</param>
        /// <param name="len">カウンタ値</param>
        /// <returns>ステータス</returns>
		public static int MemCmp(byte[] src, int srcSt, byte[] dst, int dstSt, int len)
		{
			int status = 0;
			try
			{
				for (int i=0; i <len; i++)
				{
					if (src[srcSt + i] != dst[dstSt + i])
					{
						status = -1;
						break;
					}
				}
			}
			catch (Exception)
			{
				status = -1;
			}

			return (status);
		}

        /// <summary>
        /// メモリ比較(Byte[]･Byte)
        /// </summary>
        /// <param name="src">Byte比較バッファ</param>
        /// <param name="srcSt">Byte比較バッファ インディックス</param>
        /// <param name="dst">Byte比較</param>
        /// <param name="len">カウンタ値</param>
        /// <returns>ステータス</returns>
        public static int MemCmp(byte[] src, int srcSt, byte dst, int len)
        {
            int status = 0;
            try
            {
                for (int i = 0; i < len; i++)
                {
                    if (src[srcSt + i] != dst)
                    {
                        status = -1;
                        break;
                    }
                }
            }
            catch (Exception)
            {
                status = -1;
            }

            return (status);
        }
		# endregion

		# region メモリ複写
		/// <summary>
        /// メモリ複写(Byte→Byte)
		/// </summary>
		/// <param name="dst">転送先Byte</param>
        /// <param name="src">転送元Byte</param>
		/// <param name="count">カウンタ値</param>
		public static void MemCopy(ref byte[] dst, ref byte[] src, int count)
		{
			MemCopy(ref dst, 0, ref src, 0, count);
		}
        /// <summary>
        /// メモリ複写(Byte→Byte)
        /// </summary>
        /// <param name="dst">転送先Byte</param>
        /// <param name="dstSt">転送先Byte インディックス</param>
        /// <param name="src">転送元Byte</param>
        /// <param name="srcSt">転送元Byte インディックス</param>
        /// <param name="count">カウンタ値</param>
		public static void MemCopy(ref byte[] dst, int dstSt, ref byte[] src, int srcSt, int count)
		{
            try
            {
                count = GetMinLength(dst.Length - dstSt, src.Length - srcSt, count);
			    Buffer.BlockCopy(src, srcSt, dst, dstSt, count);
			}
			catch (Exception)
			{
			}
		}
        /// <summary>
        /// メモリ複写(String→Byte)
        /// </summary>
        /// <param name="dst">転送先Byte</param>
        /// <param name="src">転送元String</param>
        /// <param name="count">カウンタ値</param>
		public static void MemCopy(ref byte[] dst, string src, int count)
		{
			MemCopy(ref dst, src, 0, count);
		}
        /// <summary>
        /// メモリ複写(String→Byte)
        /// </summary>
        /// <param name="dst">転送先Byte</param>
        /// <param name="src">転送元String</param>
        /// <param name="srcSt">転送元String インディックス</param>
        /// <param name="count">カウンタ値</param>
        public static void MemCopy(ref byte[] dst, string src, int srcSt, int count)
		{
			byte[] srcByte = System.Text.Encoding.GetEncoding(932).GetBytes(src);
			MemCopy(ref dst, 0, ref srcByte, srcSt, count);
		}
        /// <summary>
        /// メモリ複写(Byte→String)
        /// </summary>
        /// <param name="dst">転送先String</param>
        /// <param name="src">転送元Byte</param>
        /// <param name="count">カウンタ値</param>
        public static void MemCopy(ref string dst, ref byte[] src, int count)
		{
			MemCopy(ref dst, ref src, 0, count);
		}
        /// <summary>
        /// メモリ複写(Byte→String)
        /// </summary>
        /// <param name="dst">転送先String</param>
        /// <param name="src">転送元Byte</param>
        /// <param name="srcSt">転送元Byte インディックス</param>
        /// <param name="count">カウンタ値</param>
        public static void MemCopy(ref string dst, ref byte[] src, int srcSt, int count)
		{
			try
			{
				byte[] srcByte = new byte[count];
				MemCopy(ref srcByte, 0, ref src, srcSt, count);
				dst = ToStringFromByteStrAry(srcByte);
			}
			catch (Exception)
			{
				dst = "";
			}
		}
		# endregion

		# region 数値→数値Byte変換（Int32→byte[]）
		/// <summary>
		/// 数値→数値Byte変換（Int32→byte[]）
		/// [1]→[0x00,0x01]
		/// </summary>
		/// <param name="cd"></param>
		/// <returns></returns>
		public static byte[] ToByteAryFromInt32(Int32 cd)
		{
			byte[] retByte = new byte[4];
			byte[] cdByte = BitConverter.GetBytes(cd);

			retByte[0] = cdByte[3];
			retByte[1] = cdByte[2];
			retByte[2] = cdByte[1];
			retByte[3] = cdByte[0];
			return (retByte);
		}
		# endregion

		# region 数値→数値Byte変換（Int32→byte）
		/// <summary>
		/// 数値→数値Byte変換（Int32→byte）
		/// [1]→[0x00,0x01]
		/// </summary>
		/// <param name="cd"></param>
		/// <returns></returns>
		public static byte ToByteFromInt32(Int32 cd)
		{
			byte[] retByte = ToByteAryFromInt32(cd);
			return (retByte[3]);
		}
		# endregion

		# region 指定下位桁の文字列抽出
		/// <summary>
		/// 指定下位桁の文字列抽出
		/// </summary>
		/// <param name="str"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static string GetUnderString(string str, int count)
		{
			string underString = "";

			if (str.Length > count)
			{
                underString = GetRemove(str, 0, str.Length - count);
			}
			else
			{
				underString = str;
			}
			return (underString);
		}
		# endregion

		# region 文字列の削除
        /// <summary>
        /// 文字列の削除
        /// </summary>
        /// <param name="str">対象文字列</param>
        /// <param name="start">削除する開始位置</param>
        /// <param name="len">削除する文字長</param>
        /// <returns>削除後文字列</returns>
        public static string GetRemove(string str, int start, int len)
        {
            string returnStr = "";

            try
            {
                returnStr = str.Remove(start, len);
            }
            catch (Exception)
            {
                returnStr = "";
            }
            return (returnStr);
        }
   		# endregion

		# region 文字列の抽出
        /// <summary>
        /// 文字列の抽出
        /// </summary>
        /// <param name="str">対象文字列</param>
        /// <param name="start">抽出する開始位置</param>
        /// <param name="len">抽出する文字長</param>
        /// <returns>抽出後文字列</returns>
        public static string GetSubstring(string str, int start, int len) 
        {
            string returnStr = "";

            try
            {
                len = GetMinLength(len, str.Length - start);
                if (len > 0)
                {
                    returnStr = str.Substring(start, len);
                }
            }
            catch (Exception)
            {
                returnStr = "";
            }
            return (returnStr);
        }
		# endregion

        # region 文字列の抽出
        /// <summary>
        /// 文字列の抽出
        /// </summary>
        /// <param name="str">対象文字列</param>
        /// <param name="start">抽出する開始位置</param>
        /// <returns>抽出後文字列</returns>
        public static string GetSubstring(string str, int start)
        {
            string returnStr = "";

            try
            {
                if (str.Length - start > 0)
                {
                    returnStr = str.Substring(start);
                }
            }
            catch (Exception)
            {
                returnStr = "";
            }
            return (returnStr);
        }
        # endregion


        # region ハイフンなし文字列の取得
        /// <summary>
        /// ハイフンなし文字列の取得
        /// </summary>
        /// <param name="src">ハイフンあり文字列</param>
        /// <returns>ハイフンなし文字列</returns>
        public static string GetNoNoneHyphenString(string src)
        {
            string returnStr = "";

            try
            {
                for (int i = 0; i < src.Length; i++)
                {

                    if (src[i] == '-') continue;
                    returnStr = returnStr + src[i];
                }
            }
            catch (Exception)
            {
                returnStr = "";
            }
            return (returnStr);
        }
        # endregion

		# region 指定上位桁の文字列抽出
		/// <summary>
		/// 指定上位桁の文字列抽出
		/// </summary>
		/// <param name="str"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static string GetUpperString(string str, int count)
		{
			string upperString = "";

			if (str.Length > count)
			{
				upperString = str.Substring(0, count);
			}
			else
			{
				upperString = str;
			}
			return (upperString);
		}
		# endregion

		# region 日付取得処理＜Binary版＞
		/// <summary>
		/// 日付取得処理＜DDHHMMSS Binary版＞
		/// </summary>
		/// <param name="str"></param>
		/// <param name="count"></param>
		/// <returns></returns>
		public static byte[] GetByteAryDateTime()
		{
			byte[] retByte = new byte[8];

			byte[] srcDD = System.Text.Encoding.GetEncoding(932).GetBytes(String.Format("%2d", DateTime.Today.Day));
			retByte[0] = srcDD[0];
			retByte[1] = srcDD[1];

			//時
			byte[] srcHH = System.Text.Encoding.GetEncoding(932).GetBytes(String.Format("%2d", DateTime.Today.Hour));
			retByte[2] = srcHH[0];
			retByte[3] = srcHH[1];

			//分
			byte[] srcMM = System.Text.Encoding.GetEncoding(932).GetBytes(String.Format("%2d", DateTime.Today.Minute));
			retByte[4] = srcMM[0];
			retByte[5] = srcMM[1];

			//秒
			byte[] srcSS = System.Text.Encoding.GetEncoding(932).GetBytes(String.Format("%2d", DateTime.Today.Second));
			retByte[6] = srcSS[0];
			retByte[7] = srcSS[1];

			return (retByte);
		}
		# endregion

		# region Byte[]→string変換（byte[]→string）
		/// <summary>
		/// Byte[]→string変換（byte[]→string）
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		public static string ToStringFromByteStrAry(byte[] src)
		{
			string retString = "";

			try
			{
                int len = GetByteSize(src);
                byte[] dst = new byte[len];
                MemCopy(ref dst, ref src, len);

				retString = System.Text.Encoding.GetEncoding("Shift_JIS").GetString(dst);
			}
			catch (Exception)
			{
				retString = "";
			}
			return (retString);
		}
		# endregion

        # region Byte配列のサイズを取得
        /// <summary>
        /// Byte配列のサイズを取得
        /// </summary>
        /// <param name="src">Byte配列</param>
        /// <returns>サイズ</returns>
        public static int GetByteSize(byte[] src)
        {
            int len = 0;
			try
			{
                for (int i = 0; i < src.Length; i++)
                {
                    if (src[i] == 0x00)
                    {
                        break;
                    }
                    len++;
                }
            }
            catch (Exception)
            {
                len = 0;
            }
            return (len);
        }
        # endregion

        # region 数値Byte[]→数値変換（byte[]→Int32）
        /// <summary>
        /// 文字Byte[]→数値変換（byte[]→Int32）
        /// [0x31,0x32]→[01]
        /// </summary>
        /// <param name="src"></param>
        /// <param name="len"></param>
        /// <returns></returns>
        public static Int32 atobs(byte[] src, int len)
		{
			return(atobs(src, 0, len));
		}
		
		/// <summary>
		/// 文字Byte[]→数値変換（byte[]→Int32）
		/// [0x31,0x32]→[01]
		/// </summary>
		/// <param name="src"></param>
		/// <param name="len"></param>
		/// <returns></returns>
		public static Int32 atobs(byte[] src, int start, int len)
		{
            int idx = 0;
			Int32 cd = 0;
			try
			{
				if (len > 20)
				{
					return (0);
				}

                byte[] dst = new byte[len];
                for (int i = 0; i < dst.Length; i++)
                {
                    if (src[start + i] >= '0' && src[start + i] <= '9')
                    {
                        dst[idx] = src[start+i];
                        idx++;
                    }
                }
				cd = ToInt32FromByteStrAry(dst);
			}
			catch (Exception)
			{
				cd = 0;
			}
			return (cd);
		}
		
		/// <summary>
		/// 文字Byte[]→数値変換（byte[]→Int32）
		/// [0x31,0x32]→[12]
		/// </summary>
		/// <param name="src"></param>
		/// <param name="length"></param>
		/// <returns></returns>
		public static Int32 ToInt32FromByteStrAry(byte[] src)
		{
			Int32 cd = 0;
			try
			{
				string dst = ToStringFromByteStrAry(src);
				cd = Int32.Parse(dst);
			}
			catch (Exception)
			{
				cd = 0;
			}
			return (cd);
		}
		# endregion

		# region 数値Byte[]→数値変換（byte[]→double）
		/// <summary>
		/// 数値Byte[]→数値変換（byte[]→double）
		/// </summary>
		/// <param name="src"></param>
		/// <returns></returns>
		public static double ToDoubleFromByteStrAry(byte[] src)
		{
			double cd = 0;
			try
			{
				string dst = ToStringFromByteStrAry(src);
				cd = double.Parse(dst);
			}
			catch (Exception)
			{
				cd = 0;
			}
			return (cd);
		}
		# endregion

		# region 数値Byte[]→数値変換（byte[]→Int32）
		/// <summary>
		/// 数値Byte[]→数値変換（byte[]→Int32）
		/// [0x01,0x00,0x00,0x00]→[1]
		/// </summary>
		/// <param name="src">変換前値</param>
		/// <returns>変換後値</returns>
		public static Int32 ToInt32FromByteNumAry(byte[] src)
		{
			Int32 cd = 0;

			try
			{
                //変換元のBYTE長が4ﾊﾞｲﾄ未満の対応
                byte[] dst = new byte[4];
                MemSet(ref dst, 0x00, dst.Length);
                MemCopy(ref dst, ref src, src.Length);

                //変換処理
                cd = BitConverter.ToInt32(dst, 0);
			}
			catch (Exception)   
			{
				cd = 0;
			}
			return (cd);
		}
		# endregion

        # region 数値Byte[]→数値変換（byte→Int32）
        /// <summary>
        /// 数値Byte[]→数値変換（byte→Int32）
        /// [0x01]→[1]
        /// </summary>
        /// <param name="src">変換前値</param>
        /// <returns>変換後値</returns>
        public static Int32 ToInt32FromByteNum(byte src)
        {
			Int32 cd = 0;
			try
			{
                byte[] dst = new byte[4];
                MemSet(ref dst, 0x00, dst.Length);
                dst[0] = src;
                cd = ToInt32FromByteNumAry(dst);
            }
            catch (Exception)
            {
                cd = 0;
            }
            return (cd);


        }
   		# endregion


        # region 数値(string)→数値変換（string→Int32）
        /// <summary>
        /// 数値(string)→数値変換（string→Int32）
        /// </summary>
        /// <param name="src">変換元文字数値</param>
        /// <returns>数値</returns>
        public static Int32 ToInt32FromString(string src)
        {
            Int32 cd = 0;

            try
            {
                cd = Int32.Parse(src);
            }
            catch (Exception)
            {
                cd = 0;
            }
            return (cd);
        }
        # endregion

        # region 数値(string)→数値変換（string→Int32）
		/// <summary>
		/// 数値(string)→数値変換（string→Int32）
		/// </summary>
		/// <param name="src">変換元文字数値</param>
		/// <param name="cd">数値</param>
		/// <returns>true:正常 false:エラー</returns>
		public static bool ToInt32FromString(string src, out Int32 cd)
		{
			bool returnBool = true;

			cd = 0;
			try
			{
				cd = Int32.Parse(src);
			}
			catch (Exception)
			{
				returnBool = false;
			}
			return (returnBool);
		}
		# endregion

		# region 数値(string)→数値変換（string→Int32）
		/// <summary>
		/// 数値(string)→数値変換（string→Int32）
		/// </summary>
		/// <param name="src">変換元文字数値</param>
		/// <param name="cd">数値</param>
		/// <returns>true:正常 false:エラー</returns>
		public static bool ToDoubleFromString(string src, out double cd)
		{
			bool returnBool = true;

			cd = 0;
			try
			{
				cd = double.Parse(src);
			}
			catch (Exception)
			{
				returnBool = false;
			}
			return (returnBool);
		}
		# endregion

        # region 日付算出(byte[8]→DateTime)
        /// <summary>
        /// 日付算出(byte[8]→DateTime)
        /// </summary>
        /// <param name="dateByte"></param>
        /// <returns></returns>
        public static DateTime ToDateFromByte(Byte[] dateByte)
        {
            DateTime dateTime = DateTime.Now;

            try
            {
                int int32Yymmdd = atobs(dateByte, dateByte.Length);

                //電文自体にに日付がセットされている
                if (int32Yymmdd != 0)
                {
                    if (int32Yymmdd < 1000000)
                    {
                        int lwk = TDateTime.DateTimeToLongDate(DateTime.Now);		//yyyymmdd
                        lwk /= 1000000;	// yy
                        lwk *= 1000000;	// yy000000

                        int32Yymmdd += lwk;
                    }
                    dateTime = TDateTime.LongDateToDateTime(int32Yymmdd);
                }
                //電文自体にに日付がセットされていない
                else
                {
                    dateTime = DateTime.Now;
                }
            }
            catch (Exception)
            {
                dateTime = DateTime.Now;
            }
            return (dateTime);
        }
        # endregion

        # region 時間算出(byte[8]→int)
        /// <summary>
        /// 時間算出(byte[8]→int)
        /// </summary>
        /// <param name="timeByte"></param>
        /// <returns></returns>
        public static int ToTimeIntFromByte(Byte[] timeByte)
        {
            int timeInt = 0;
            try
            {
                timeInt = atobs(timeByte, timeByte.Length);
                if (timeInt == 0)
                {
                    timeInt = DateTime.Now.Hour * 10000
                            + DateTime.Now.Minute * 100
                            + DateTime.Now.Second;
                }
            }
            catch (Exception)
            {
                timeInt = DateTime.Now.Hour * 10000
                        + DateTime.Now.Minute * 100
                        + DateTime.Now.Second;
            }
            return (timeInt);
        }
        # endregion

		# endregion
	}
	# endregion

	# region ＵＯＥ集定義クラス
	/// <summary>
	/// ＵＯＥ定義クラス
	/// </summary>
    /// <remarks>
    /// <br>Update Note : 2010/03/08 楊明俊</br>
    /// <br>              PM1006 UOE発注先が「日産」の場合、UOE発注データのみを作成し、通信は行わないように修正</br>
    /// <br>Update Note : 2010/04/26 gaoyh</br>
    /// <br>              PM1007C 三菱UOE-WEB対応に伴う仕様追加</br>
    /// <br>Update Note : 2010/05/07 高峰</br>
    /// <br>              PM1008 明治UOE-WEB対応に伴う仕様追加</br>
    /// <br>UpdateNote : 2011/01/06 liyp </br>
    /// <br>            Web-UOE用の通信アセンブリID定数を追加</br>
    /// <br>UpdateNote : 2011/01/30 朱 猛 </br>
    /// <br>            UOE自動化改良</br>
    /// <br>Update Note: 2011/03/01 liyp</br>
    /// <br>             業務区分は「発注」（固定）に制御する</br>
    /// <br>Update Note: 2011/05/10 施炳中</br>
    /// <br>             マツダWebUOE用の通信アセンブリID定数を追加</br>
    /// </remarks>
	public class EnumUoeConst
	{
		# region Const Members
		//業務区分
		public enum TerminalDiv
		{
            ct_None = 0,    //処理なし
            ct_Order = 1,	//発注
			ct_Estmt = 2,	//見積
			ct_Stock = 3,	//在庫確認
			ct_Cancel = 4,	//取消処理
		}

		//システム区分
		public enum ctSystemDivCd
		{
            ct_Input = 0,	//手入力
            ct_Slip = 1,	//伝発
			ct_Search = 2,	//検索
			ct_Lump = 3,	//在庫一括
		}

        //処理区分
        public enum ctProcessDiv
        {
            ct_NORMAL = 0,	//通常
            ct_RECOVER = 1,	//復旧
        }

		//通信プログラムＩＤ
		public const string ctCommAssemblyId_0102 = "0102";	//トヨタ
        public const string ctCommAssemblyId_0103 = "0103";	//トヨタ電子カタログ  // ADD 2009/12/29 xuxh
		public const string ctCommAssemblyId_0202 = "0202";	//ニッサン
        // ---ADD 2010/03/08 ---------------------------------------->>>>>
        public const string ctCommAssemblyId_0203 = "0203";	//日産web-UOE
        public const string ctCommAssemblyId_0204 = "0204";	// ADD 2011/01/06
        // ---ADD 2010/03/08 ----------------------------------------<<<<<
        public const string ctCommAssemblyId_0301 = "0301";	//ミツビシ
        // ---ADD 2010/04/26 gaoyh ---------------------------------------->>>>>
        public const string ctCommAssemblyId_0302 = "0302";	//三菱web-UOE
        public const string ctCommAssemblyId_0303 = "0303";	//ADD 2011/01/06
        // ---ADD 2010/04/26 gaoyh ----------------------------------------<<<<<
		public const string ctCommAssemblyId_0401 = "0401";	//旧マツダ
		public const string ctCommAssemblyId_0402 = "0402";	//新マツダ
		public const string ctCommAssemblyId_0501 = "0501";	//ホンダ
		public const string ctCommAssemblyId_0801 = "0801";	//スバル
		public const string ctCommAssemblyId_1001 = "1001";	//優良メーカー
        public const string ctCommAssemblyId_0502 = "0502";	//e-Parts
        // ---ADD 2010/05/07 ------------------>>>>>
        public const string ctCommAssemblyId_1003 = "1003";	//優良メーカー(SPK他)
        public const string ctCommAssemblyId_1004 = "1004";	//優良メーカー(明治産業)
        // ---ADD 2010/05/07 ------------------<<<<<
        public const string ctCommAssemblyId_0104 = "0104";	// トヨタ自動処理 // ADD 2011/01/30 朱 猛
        // ---ADD 2011/03/01 liyp ----------------------------------------->>>>>
        public const string ctCommAssemblyId_0205 = "0205";
        public const string ctCommAssemblyId_0206 = "0206";
        // ---ADD 2011/03/01 liyp -----------------------------------------<<<<<
        // ---ADD 2011/05/10  ----------------------------------------->>>>>
        public const string ctCommAssemblyId_0403 = "0403";
        // ---ADD 2011/05/10  -----------------------------------------<<<<<
		//エラーコード
		public enum Status
		{
			ct_NORMAL = 0,
			ct_NOT_FOUND = 4,
			ct_EOF = 9,
			ct_WARNING = 999,
			ct_ERROR = 1000,
		}

		//開局 閉局モード
		public enum OpenMode
		{
			ct_OPEN = 0,
			ct_CLOSE = 1,
		}

        // HACK:▼卸商仕入受信処理用
        /// <summary>
        /// 卸商仕入受信処理のUOE発注先種別
        /// </summary>
        public enum ReceivingUOESupplier
        {
            /// <summary>SPK(その他)</summary>
            SPK,
            /// <summary>明治産業</summary>
            Meiji
        }
        // HACK:▲

		//ＵＯＥＪＮＬ更新モード
		public enum UoeJnlWriteMode
		{
			ct_INSERT = 0,
			ct_UPDATE = 1,
		}

		//ログデータ種別区分コード
		//0:記録,1:エラー,9:システム,10:UOE(DSP) 11:UOE(通信)
		public enum ctLogDataKindCd
		{
			ct_RECORD = 0,
			ct_ERROR = 1,
			ct_SYSTEM = 9,
			ct_DSP = 10,
			ct_TERM = 11,
		}

		//操作内容コード(0:起動,1:ログイン,2:データ読込,3:データ挿入,4:データ更新,5:データ論理削除,
		//6:データ削除,7:印刷,8:テキスト出力,9:通信,10:呼出,11:送信,12:受信,13:タイムアウト,14:終了)
		public enum ctLogDataOperationCd
		{
			ct_START = 0,
			ct_LOGIN = 1,
			ct_READ = 2,
			ct_INSERT = 3,
			ct_UPDT = 4,
			ct_LOGDEL = 5,
			ct_DEL = 6,
			ct_PRN = 7,
			ct_TEXTOUT = 8,
			ct_TERM = 9,
			ct_SUMMONS = 10,
			ct_SND = 11,
			ct_REC = 12,
			ct_TIMEOUT = 13,
			ct_END = 14,
		}

		//操作履歴ログデータのフラッシュ有無
		public enum ctOprtnHisLogFlush
		{
			ct_ON = 1,
			ct_OFF = 0,
		}

		//送信フラグ
		public enum ctDataSendCode
		{
			ct_NonProcess = 0, //未処理
			ct_Process = 1, //処理中
			ct_SndNG = 2, //送信エラー
			ct_RcvNG = 3, //受信エラー
			ct_Insert = 5, //回答埋め込み
			ct_OK = 9, //正常終了
		}

		//復旧フラグ
		public enum ctDataRecoverDiv
		{
			ct_NonProcess = 0, //未処理
			ct_YES = 1,	//復旧対象
			ct_NO = 9,	//復旧不要
		}

		//メーカーフォロー計上区分
		public enum ctMakerFollowAddUpDiv
		{
			ct_Sales = 0,	//売上
			ct_Order = 1,	//受注
		}

		//フォロー伝票出力区分
		public enum ctFollowSlipOutputDiv
		{
			ct_Add = 0,	//合算
			ct_Separate = 1,	//別々
		}

		//受信状況(受信有無区分)
		public enum ctReceiveCondition
		{
			ct_SndRcv = 0,	//送受信可能
			ct_Snd = 1,		//送信のみ
		}

		//仕入データ受信区分
		public enum ctStockSlipDtRecvDiv
		{
			ct_Unavailable = 0,	//なし
			ct_Available = 1,	//あり
		}

		//売上仕入区分
		//0:しない　1:する　2:必須入力
		public enum ctSalesStockDiv
		{
			ct_No= 0,			//しない
			ct_Yes = 1,			//する
			ct_Essential = 2,	//必須入力
		}

		//自動入金区分
		//0:しない　1:する
        public enum ctAutoDepositCd
		{
			ct_No = 0,			//しない
			ct_Yes = 1,			//する
		}

        //計上日付区分
        //0:システム日付 1:売上日付
        public enum ctAddUpADateDiv
        {
            ct_System = 0,      //0:システム日付
            ct_Sales = 1,       //1:売上日付
        }

        //定価使用区分
        //0:高い方 1:入力優先 2:オンライン優先
        public enum ctListPriceUseDiv
        {
            ct_Hight = 0,   //0:高い方
            ct_Input = 1,   //1:入力優先
            ct_Online = 2,  //2:オンライン優先
        }

        //代替品番区分
        public enum ctSubstPartsNoDiv
        {
            ct_SubstParts = 0,  //代替品番採用
            ct_OrderParts = 1,  //発注品番採用
        }

        # endregion


		# region Constructors
		/// <summary>
		/// Constructors
		/// </summary>
		public EnumUoeConst()
		{
		}
		# endregion
	}
	# endregion

}
