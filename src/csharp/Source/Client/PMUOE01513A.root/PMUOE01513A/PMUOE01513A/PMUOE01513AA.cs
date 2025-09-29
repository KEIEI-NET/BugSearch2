//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : トヨタ発注処理
// プログラム概要   : トヨタ発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2009 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10507391-00 作成担当 : 譚洪
// 作 成 日  2009/12/31  修正内容 : 新規作成
//                                  トヨタ電子カタログとの連携用データとして、UOE発注データから発注送信データの作成を行う
//----------------------------------------------------------------------------//
// 管理番号  10507391-00 作成担当 : 譚洪
// 修 正 日  2010/01/19  修正内容 : Redmine:2509
//                                  Redmine指摘事項の対応
//----------------------------------------------------------------------------//
// 管理番号  10507391-00 作成担当 : 譚洪
// 修 正 日  2010/01/22  修正内容 : Redmine:2586
//                                  明細数が多いと品番のセットがずれて設定されてしまうの対応
//----------------------------------------------------------------------------//
// 管理番号  10600008-00 作成担当 : 呉元嘯
// 修 正 日  2010/07/26  修正内容 : PM1011 トヨタ発注処理　自動場合仕様追加
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 呉元嘯
// 修 正 日  2010/08/31  修正内容 : Redmine#13666対応
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 曹文傑
// 修 正 日  2011/01/30  修正内容 : UOE自動化対応、自動化のタイプ追加による変更
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 曹文傑
// 修 正 日  2011/02/21  修正内容 : Redmine#19088の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : 凌小青
// 修 正 日  2011/11/12  修正内容 : Redmine#26485の対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : yangmj
// 修 正 日  2011/12/15  修正内容 : トヨタUOEWebタクティー品番の発注対応
//----------------------------------------------------------------------------//
// 管理番号              作成担当 : FSI 今野
// 作 成 日  2012/09/20  修正内容 : トヨタ発注処理データのソート処理追加
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : wangyl
// 修 正 日  2013/02/06  修正内容 : 10900690-00 2013/03/13配信分の緊急対応
//                                  Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい 
//----------------------------------------------------------------------------//
// 管理番号  11370039-00 作成担当 : 30757 佐々木貴英
// 修 正 日  2017/07/07  修正内容 : トヨタ新WEBUOE対応
//                                  発注データの入力日時Byte配列に0x0d,0x0a,0x09の並びが含まれて
//                                  いるとWEBUOE側で発注データが展開できない不具合対応
//----------------------------------------------------------------------------//
// 管理番号  11370054-00 作成担当 : 30757 佐々木貴英
// 作 成 日  2017/07/12  修正内容 : トヨタ新WEBUOEロボット対応
//                                  ①発注送信データサブファイルを作成しないよう変更
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using Broadleaf.Application.Remoting.ParamData;
using Broadleaf.Application.UIData;
using Broadleaf.Library.Resources;
using Broadleaf.Application.Common;
using System.Collections;
using Broadleaf.Xml.Serialization;
using Broadleaf.Application.Remoting;
using Broadleaf.Application.Remoting.Adapter;
using System.Data;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// トヨタ発注処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : トヨタ発注処理のアクセス制御を行います。</br>
    /// <br>Programmer : 譚洪</br>
    /// <br>Date       : 2009/12/31</br>
    /// <br>Update Note : 2010/01/19 譚洪</br>
    /// <br>              Redmine:2509</br>
    /// <br>              Redmine指摘事項の対応</br>
    /// <br>Update Note : 2010/01/22 譚洪</br>
    /// <br>              Redmine:2586</br>
    /// <br>              明細数が多いと品番のセットがずれて設定されてしまうの対応</br>
    /// <br>Update Note : 2010/07/26 呉元嘯</br>
    /// <br>              PM1011 トヨタ発注処理　自動場合仕様追加</br>
    /// <br>Update Note : 2010/08/31 呉元嘯</br>
    /// <br>              Redmine#13666対応</br>
    /// <br>Update Note : 2011/01/30 曹文傑</br>
    /// <br>              UOE自動化対応、自動化のタイプ追加による変更</br>
    /// <br>Update Note : 2011/02/21 曹文傑</br>
    /// <br>              Redmine#19088の対応</br>
    /// <br>Update Note : 2011/11/29 凌小青</br>
    /// <br>              Redmine#7733の対応</br> 
    /// <br>Update Note: 2011/12/15 yangmj</br>
    /// <br>             トヨタUOEWebタクティー品番の発注対応</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
    /// <br>              RRedmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
    /// <br>Update Note : 2017/07/07 30757 佐々木貴英</br>
    /// <br>管理番号    : 11370039-00 トヨタ新WEBUOE対応</br>
    /// <br>              発注データの入力日時Byte配列に0x0d,0x0a,0x09の並びが含まれて</br>
    /// <br>              いるとWEBUOE側で発注データが展開できない不具合対応</br>
    /// <br>Update Note : 2017/07/12 30757 佐々木貴英</br>
    /// <br>管理番号    : 11370054-00 トヨタ新WEBUOEロボット対応</br>
    /// <br>              発注送信データサブファイルを作成しないよう変更</br>
    /// </remarks>
    public partial class OrderProcAcs
    {
        // --- ADD 2012/09/20 ---------------------------->>>>>
        # region ■Inner Class
        /// <summary>
        /// トヨタ発注処理データソート用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : トヨタ発注処理データのソートを行うクラスです。</br>
        /// <br>Note       : 呼出番号、呼出番号枝番の順にソートします。</br>
        /// <br>Programmer : FSI今野 利裕</br>
        /// <br>Date       : 2012/09/20</br>
        /// </remarks>
        private class UOEOrderDtlWorkComparer : IComparer<UOEOrderDtlWork>
        {
            #region IComparer メンバ

            public int Compare(UOEOrderDtlWork x, UOEOrderDtlWork y)
            {
                // NULLチェックする
                if (x == null || y == null)
                {
                    throw new ArgumentNullException();
                }

                // データを比較する
                if (x.OnlineNo > y.OnlineNo)
                {
                    return 1;
                }
                else if (x.OnlineNo < y.OnlineNo)
                {
                    return -1;
                }
                else
                {
                    if (x.OnlineRowNo > y.OnlineRowNo)
                    {
                        return 1;
                    }
                    else if (x.OnlineRowNo < y.OnlineRowNo)
                    {
                        return -1;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// 仕入明細データソート用クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 仕入明細データのソートを行うクラスです。</br>
        /// <br>Note       : シーケンス番号順にソートします。</br>
        /// <br>Programmer : FSI今野 利裕</br>
        /// <br>Date       : 2012/09/20</br>
        /// </remarks>
        private class StockDetailWorkComparer : IComparer<StockDetailWork>
        {
            private readonly List<long> _CommonSeqNoList = new List<long>();

            public StockDetailWorkComparer(List<UOEOrderDtlWork> _uOEOrderDtlWorkList)
            {
                // シーケンス番号をリスト化する
                foreach (UOEOrderDtlWork item in _uOEOrderDtlWorkList)
                {
                    _CommonSeqNoList.Add(item.CommonSeqNo);
                }
            }

            #region IComparer メンバ

            public int Compare(StockDetailWork x, StockDetailWork y)
            {
                // NULLチェックする
                if (x == null || y == null || _CommonSeqNoList == null)
                {
                    throw new ArgumentNullException();
                }

                // インデックスを取得する
                int a = _CommonSeqNoList.IndexOf(x.CommonSeqNo);
                int b = _CommonSeqNoList.IndexOf(y.CommonSeqNo);
                if (a < 0 || b < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }

                // データを比較する
                if (a > b)
                {
                    return 1;
                }
                else if (a < b)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }

            #endregion
        }
        #endregion
        // --- ADD 2012/09/20 ----------------------------<<<<<

        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private bool _isDataCanged = false;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;// ADD 2010/07/26

        //アクセスクラス
        private static OrderProcAcs _supplierAcs;
        private UoeOrderInfoAcs _uoeOrderInfoAcs;

        //データーテーブル
        private OrderProcDataSet _dataSet;
        private OrderProcDataSet.OrderExpansionDataTable _orderDataTable;

        //従業員マスタ
        private Dictionary<string, EmployeeWork> _employeeWork;
        private IEmployeeDB _iEmployeeDB;                               // 従業員情報 アクセスクラス

        //ＵＯＥ発注データ検索＜アクセスクラス呼び出し＞
        List<UOEOrderDtlWork> _uOEOrderDtlWorkList = null;
        List<StockDetailWork> _stockDetailWorkList = null;

        private int setCount = 0;
        //private string remark2 = string.Empty; // 連携番号を変数に退避    // ADD 2011/01/30 //DEL BY 凌小青 on 2011/11/29 for Redmine#7733
        private List<string> remark2 = new List<string>(); // 連携番号を変数に退避   //ADD BY 凌小青 on 2011/11/29 for Redmine#7733
        private ArrayList _uOEOrderDtlWorkAL = null; //ＵＯＥ発注データのリマーク２を画面入力値へ変更用    // ADD 2011/02/21
        private IUOEOrderDtlDB _iUOEOrderDtlDB = null; //ＵＯＥ発注データアクセスクラス    // ADD 2011/02/21
        # endregion

        #region TelegramEditOrder0103
        /// <summary>
		/// ＵＯＥ送信電文作成＜発注＞（トヨタＰＤ４）
		/// </summary>
        /// <remarks>
        /// <br>Update Note : 2017/07/07 30757 佐々木貴英</br>
        /// <br>管理番号    : 11370039-00 トヨタ新WEBUOE対応</br>
        /// <br>              発注データの入力日時Byte配列に0x0d,0x0a,0x09の並びが含まれて</br>
        /// <br>              いるとWEBUOE側で発注データが展開できない不具合対応</br>
        /// </remarks>
        public class TelegramEditOrder0103
        {

            # region Const Members
            private const Int32 ctDetailLen = 3;	//明細行数
            private const Int32 ctSndTelegramLen = 107; //送信電文サイズ
            //---ADD 2017/07/07 30757 佐々木貴英 トヨタ新WEBUOE対応 ----->>>>>
            /// <summary>
            /// 入力日時要素数
            /// </summary>
            private const byte InputDayTimeElementSize = 4;
            /// <summary>
            /// 入力日時要素デフォルト値
            /// </summary>
            private const byte InputDayTimeElementDefault = 0x20;  
            //---ADD 2017/07/07 30757 佐々木貴英 トヨタ新WEBUOE対応 -----<<<<<
            # endregion

            #region Private Members
            //発注電文
            private byte[] ttflg = new byte[1];	/*      ﾍｯﾄﾞ 通信フラグ       */
            private byte[] rem3 = new byte[12];		/*           ﾘﾏｰｸ3            */
            private byte[] nhkb = new byte[1];		/*      	 納品区分         */
            private byte[] fnhkb = new byte[1];		/*      	 ﾌｫﾛｰ納品区分     */
            private byte[] rem = new byte[8];		/*           ﾘﾏｰｸ1            */
            private byte[] rem2 = new byte[10];		/*           ﾘﾏｰｸ2            */
            private byte[] kyo = new byte[2];		/*           指定拠点         */
            private byte[] user = new byte[2];		/*           お客様担当者ｺｰﾄﾞ */
            private byte[] skbn = new byte[1];		/*           処理区分		  */
            private byte[] nsitei = new byte[6];	/*           納入指定日　　　 */

            private byte[][] mkkb = new byte[ctDetailLen][];	/* ﾗｲﾝ      メーカ区分        */
            private byte[][] hb = new byte[ctDetailLen][];	/*          品番              */
            private byte[][] hsu = new byte[ctDetailLen][];	/*          数量              */
            private byte[][] bo = new byte[ctDetailLen][];	/*          ﾌｫﾛｰｺｰﾄﾞ          */

            //変数
            private Int32 _seq = 1;
            private Int32 _ln = 0;

            private UOESupplier _uOESupplier = null;
            #endregion

            # region Constructors
			/// <summary>
			/// コンストラクタ
			/// </summary>
            public TelegramEditOrder0103()
			{
                for (int i = 0; i < ctDetailLen; i++)
				{
                    mkkb[i] = new byte[1];	//メーカ区分
					hb[i] = new byte[14];	//品番
					hsu[i] = new byte[5];	//数量
					bo[i] = new byte[1];	//ﾌｫﾛｰｺｰﾄﾞ
				}
				_seq = 1;
				Clear();
			}
            # endregion

            # region Properties
            # region SEQ番号
            /// <summary>
            /// SEQ番号
            /// </summary>
            public Int32 Seq
            {
                get
                {
                    return this._seq;
                }
                set
                {
                    this._seq = value;
                }
            }
            # endregion

            # region UOE発注先クラス
            /// <summary>
            /// UOE発注先クラス
            /// </summary>
            public UOESupplier uOESupplier
            {
                get
                {
                    return this._uOESupplier;
                }
                set
                {
                    this._uOESupplier = value;
                }
            }
            # endregion

            # region 送信サイズ
            /// <summary>
            /// 送信サイズ
            /// </summary>
            public Int32 SndTelegramLen
            {
                get
                {
                    return ctSndTelegramLen;
                }
            }
            # endregion
            # endregion

            # region Public Methods
            # region データ初期化処理
            /// <summary>
            /// データ初期化処理
            /// </summary>
            public void Clear()
            {
                _ln = 0;

                //ヘッダー部
                UoeCommonFnc.MemSet(ref ttflg, 0x20, ttflg.Length);		//通信フラグ
                UoeCommonFnc.MemSet(ref rem3, 0x20, rem3.Length);		//リマーク３
                UoeCommonFnc.MemSet(ref nhkb, 0x20, nhkb.Length);		//納品区分
                UoeCommonFnc.MemSet(ref fnhkb, 0x20, fnhkb.Length);		//フォロー納品区分
                UoeCommonFnc.MemSet(ref rem, 0x20, rem.Length);			//リマーク１
                UoeCommonFnc.MemSet(ref rem2, 0x20, rem2.Length);		//リマーク２
                UoeCommonFnc.MemSet(ref kyo, 0x20, kyo.Length);			//指定拠点
                UoeCommonFnc.MemSet(ref user, 0x20, user.Length);		//お客様担当者コード
                UoeCommonFnc.MemSet(ref skbn, 0x20, skbn.Length);		//処理区分
                UoeCommonFnc.MemSet(ref nsitei, 0x20, nsitei.Length);	//納入指定日

                //明細部
                for (int i = 0; i < ctDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref mkkb[i], 0x20, mkkb[i].Length);	//メーカ区分
                    UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);	//品番
                    UoeCommonFnc.MemSet(ref hsu[i], 0x20, hsu[i].Length);	//数量
                    UoeCommonFnc.MemSet(ref bo[i], 0x20, bo[i].Length);	//フォローコード
                }
            }

            /// <summary>
            /// データ明細初期化処理
            /// </summary>
            public void ClearDetail()
            {
                _ln = 0;

                //明細部
                for (int i = 0; i < ctDetailLen; i++)
                {
                    UoeCommonFnc.MemSet(ref mkkb[i], 0x20, mkkb[i].Length);	//メーカ区分
                    UoeCommonFnc.MemSet(ref hb[i], 0x20, hb[i].Length);	//品番
                    UoeCommonFnc.MemSet(ref hsu[i], 0x20, hsu[i].Length);	//数量
                    UoeCommonFnc.MemSet(ref bo[i], 0x20, bo[i].Length);	//フォローコード
                }
            }

            /// <summary>
            /// データ明細初期化処理
            /// </summary>
            public void changeFlg()
            {
                //通信フラグ
                UoeCommonFnc.MemSet(ref ttflg, 0x30, ttflg.Length);		//通信フラグ
            }
            # endregion

            # region データ編集処理
            /// <summary>
            /// データ編集処理
            /// </summary>
            /// <param name="work">ワーク</param>
            /// <remarks>
            /// <br>Update Note: 2011/12/15 yangmj</br>
            /// <br>             トヨタUOEWebタクティー品番の発注対応</br>
            /// <br>Update Note : 2017/07/07 30757 佐々木貴英</br>
            /// <br>管理番号    : 11370039-00 トヨタ新WEBUOE対応</br>
            /// <br>              発注データの入力日時Byte配列に0x0d,0x0a,0x09の並びが含まれて</br>
            /// <br>              いるとWEBUOE側で発注データが展開できない不具合対応</br>
            /// </remarks>
            public void Telegram( UOEOrderDtlWork work )
            {
                //ＴＴＣ部 業務ヘッダー部 ヘッダー部作成
                if (_ln == 0)
                {
                    # region ＜ヘッダー部＞
                    //＜ヘッダー部＞

                    //通信フラグ
                    ttflg[0] = 0x31;
                    //ﾘﾏｰｸ3
                    UoeCommonFnc.MemSet(ref rem3, 0x30, rem3.Length);
                    //---UPD 2017/07/07 30757 佐々木貴英 トヨタ新WEBUOE対応 ----->>>>>
                    //rem3[0] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Day);		//日
                    //rem3[1] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Hour);	    //時
                    //rem3[2] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Minute);	//分
                    //rem3[3] = UoeCommonFnc.ToByteFromInt32(DateTime.Now.Second);	//秒

                    //トヨタ新WEBUOEでは、0x0d,0x0a,0x09の並びがあると発注データとして取り込めない為
                    //日時分秒には空白をセットする
                    UoeCommonFnc.MemSet( 
                          ref rem3
                        , TelegramEditOrder0103.InputDayTimeElementDefault
                        , TelegramEditOrder0103.InputDayTimeElementSize );
                    //---UPD 2017/07/07 30757 佐々木貴英 トヨタ新WEBUOE対応 -----<<<<<

                    //納品区分
                    UoeCommonFnc.MemCopy(ref nhkb, work.UOEDeliGoodsDiv, nhkb.Length);

                    //ﾌｫﾛｰ納品区分
                    UoeCommonFnc.MemCopy(ref fnhkb, work.FollowDeliGoodsDiv, fnhkb.Length);

                    //ﾘﾏｰｸ1
                    UoeCommonFnc.MemCopy(ref rem, work.UoeRemark1, rem.Length);

                    //ﾘﾏｰｸ2
                    UoeCommonFnc.MemCopy(ref rem2, work.UoeRemark2, rem2.Length);

                    //指定拠点（発注先マスタの下２桁）
                    UoeCommonFnc.MemCopy(ref kyo, UoeCommonFnc.GetUnderString(work.UOEResvdSection, kyo.Length), kyo.Length);

                    //お客様担当者ｺｰﾄﾞ（発注先マスタ：依頼者コードの下２桁）
                    UoeCommonFnc.MemCopy(ref user, UoeCommonFnc.GetUnderString(work.EmployeeCode.Trim(), user.Length), user.Length);

                    //処理区分
                    skbn[0] = 0x30;

                    //納入指定日
                    UoeCommonFnc.MemSet(ref nsitei, 0x20, nsitei.Length);
                    # endregion
                }

                # region ＜明細部＞
                //＜明細部＞
                if (_ln < ctDetailLen)
                {
                    //メーカ区分
                    //ﾒｰｶｰｺｰﾄﾞ:0001　→　ｾｯﾄ内容:" "(半角ｽﾍﾟｰｽ)
                    if (work.GoodsMakerCd == 1)
                    {
                        UoeCommonFnc.MemSet(ref mkkb[_ln], 0x20, mkkb[_ln].Length);
                    }
                    //ﾒｰｶｰｺｰﾄﾞ:1396　→　ｾｯﾄ内容:"X"
                    else if (work.GoodsMakerCd == 1396)
                    {
                        UoeCommonFnc.MemSet(ref mkkb[_ln], 0x58, mkkb[_ln].Length);
                    }
                    //ﾒｰｶｰｺｰﾄﾞ:0081　→　ｾｯﾄ内容:"V"
                    else if (work.GoodsMakerCd == 81)
                    {
                        UoeCommonFnc.MemSet(ref mkkb[_ln], 0x56, mkkb[_ln].Length);
                    }
                    else
                    {
                        //なし。
                    }
                    //品番
                    // ----------UPD 2010/07/26---------->>>>>
                    //UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                    //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応 ----->>>>>
                    //ハイフン無しの場合、ハイフンを削除してセット
                    if (this.uOESupplier != null)
                    {
                        if (this.uOESupplier.EnableOdrMakerCd1 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd1 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd1)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else if (this.uOESupplier.EnableOdrMakerCd2 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd2 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd2)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else if (this.uOESupplier.EnableOdrMakerCd3 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd3 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd3)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else if (this.uOESupplier.EnableOdrMakerCd4 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd4 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd4)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else if (this.uOESupplier.EnableOdrMakerCd5 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd5 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd5)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else if (this.uOESupplier.EnableOdrMakerCd6 != 0 && this.uOESupplier.OdrPrtsNoHyphenCd6 == 0 && work.GoodsMakerCd == this.uOESupplier.EnableOdrMakerCd6)
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                        }
                        else
                        {
                            UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNo, hb[_ln].Length);
                        }
                    }
                    //----- ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応 -----<<<<<
                    //----- DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応 ----->>>>>
                    //if (work.GoodsMakerCd == 1)
                    //{
                    //    UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNoNoneHyphen, hb[_ln].Length);
                    //}
                    //else
                    //{
                    //    UoeCommonFnc.MemCopy(ref hb[_ln], work.GoodsNo, hb[_ln].Length);
                    //}
                    //----- DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応 -----<<<<<
                    // ----------UPD 2010/07/26----------<<<<<
                    //数量
                    UoeCommonFnc.MemCopy(ref hsu[_ln], String.Format("{0:D5}", (int)work.AcceptAnOrderCnt), hsu[_ln].Length);

                    //フォローコード
                    UoeCommonFnc.MemCopy(ref bo[_ln], work.BoCode, bo[_ln].Length);

                    //明細数インクリメント
                    _ln++;
                }
                # endregion
            }
            # endregion
            # endregion

            # region private Methods
            # region バイト型配列に変換
            /// <summary>
            /// バイト型配列に変換
            /// </summary>
            /// <returns></returns>
            public byte[] ToByteArray()
            {
                MemoryStream ms = new MemoryStream();
                //ヘッダー部
                ms.Write(ttflg, 0, ttflg.Length);		//通信フラグ
                ms.Write(rem3, 0, rem3.Length);			//リマーク３
                ms.Write(nhkb, 0, nhkb.Length);			//納品区分
                ms.Write(fnhkb, 0, fnhkb.Length);		//フォロー納品区分
                ms.Write(rem, 0, rem.Length);			//リマーク１
                ms.Write(rem2, 0, rem2.Length);			//リマーク２
                ms.Write(kyo, 0, kyo.Length);			//指定拠点
                ms.Write(user, 0, user.Length);			//お客様担当者コード
                ms.Write(skbn, 0, skbn.Length);			//処理区分
                ms.Write(nsitei, 0, nsitei.Length);		//納入指定日

                //明細部
                for (int i = 0; i < ctDetailLen; i++)
                {
                    ms.Write(mkkb[i], 0, mkkb[i].Length);	//メーカ区分
                    ms.Write(hb[i], 0, hb[i].Length);	//品番
                    ms.Write(hsu[i], 0, hsu[i].Length);	//数量
                    ms.Write(bo[i], 0, bo[i].Length);	//フォローコード
                }

                byte[] toByteArray = ms.ToArray();
                ms.Close();
                return (toByteArray);
            }
            # endregion

            # endregion
        }
        //業務区分
        private const Int32 ctTerminalDiv_Order = 1;	//発注
        #endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Note       : デフォルトコンストラクタを行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2011/02/21 曹文傑</br>
        /// <br>             Redmine#19088の対応</br>
        /// </remarks>
        private OrderProcAcs()
        {
            // 変数初期化
            this._dataSet = new OrderProcDataSet();
            this._orderDataTable = this._dataSet.OrderExpansion;

            this.orderDataTable.Rows.Clear();

            this._uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();

            this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();

            this._iUOEOrderDtlDB = (IUOEOrderDtlDB)MediationUOEOrderDtlDB.GetUOEOrderDtlDB(); // ADD 2011/02/21
        }

        /// <summary>
        /// ＵＯＥ発注処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>ＵＯＥ発注処理アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注処理アクセスクラス インスタンス取得を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public static OrderProcAcs GetInstance()
        {
            if (_supplierAcs == null)
            {
                _supplierAcs = new OrderProcAcs();
            }

            return _supplierAcs;
        }
        # endregion

        #region データ変更フラグ
        /// <summary>データ変更フラグプロパティ（true:変更あり false:変更なし）</summary>
        public bool IsDataChanged
        {
            get
            {
                return this._isDataCanged;
            }
            set
            {
                this._isDataCanged = value;
            }
        }
        #endregion

        # region 従業員マスタキャッシュ処理
        /// <summary>
        /// 従業員マスタキャッシュ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 従業員マスタキャッシュ処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public void CacheEmployee()
        {
            object returnEmployee;
            _employeeWork = new Dictionary<string, EmployeeWork>();
            EmployeeWork paraEmployee = new EmployeeWork();
            paraEmployee.EnterpriseCode = this._enterpriseCode; ;

            try
            {

                int status = this._iEmployeeDB.Search(out returnEmployee, paraEmployee, 0, Broadleaf.Library.Resources.ConstantManagement.LogicalMode.GetData0);
                if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (returnEmployee is ArrayList)
                    {
                        foreach (EmployeeWork employeeWork in (ArrayList)returnEmployee)
                        {
                            if (employeeWork.LogicalDeleteCode == 0 &&
                                _employeeWork.ContainsKey(employeeWork.EmployeeCode.Trim()) != true)
                            {
                                this._employeeWork.Add(employeeWork.EmployeeCode.Trim(), employeeWork);
                            }
                        }

                    }
                }
            }
            catch (Exception)
            {
                _employeeWork = new Dictionary<string, EmployeeWork>();
            }

        }

        /// <summary>
        /// 従業員存在チェック
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <param name="employeeName"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : 従業員存在チェックを行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public bool GetEmployeeName(string employeeCode, out string employeeName)
        {
            employeeName = string.Empty;

            if (!this._employeeWork.ContainsKey(employeeCode))
            {
                return false;
            }

            employeeName = this._employeeWork[employeeCode].Name.Trim();

            return true;
        }

        # endregion

        # region 発注検索データセット取得処理
        /// <summary>
        /// 発注検索データセット取得処理
        /// </summary>
        /// <returns>伝票検索データセット</returns>
        /// <remarks>
        /// <br>Note       : 発注検索データセット取得を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public OrderProcDataSet DataSet
        {
            get { return this._dataSet; }
        }

        /// <summary>
        /// 有効入力行存在判定
        /// </summary>
        /// <returns>行存在チェック結果（True : 行あり / False : 行なし）</returns>
        /// <remarks>
        /// <br>Note       : 有効入力行存在判定を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public bool StockRowExists()
        {
            if (this._orderDataTable.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        # endregion

        # region 発注検索データテーブル取得処理
        /// <summary>
        /// 発注検索データテーブル取得処理
        /// </summary>
        /// <returns>伝票検索データセット</returns>
        /// <remarks>
        /// <br>Note       : 発注検索データテーブル取得を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public OrderProcDataSet.OrderExpansionDataTable orderDataTable
        {
            get { return _orderDataTable; }
        }
        # endregion

        #region 選択・非選択状態処理(指定型)
        /// <summary>
        /// 選択・非選択状態処理(指定型)
        /// </summary>
        /// <param name="_uniqueID">ユニークID</param>
        /// <param name="selected">true:選択,false:非選択</param>
        /// <remarks>
        /// <br>Note       : 選択・非選択状態処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public void SelectedRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
            // DataTableに更新をかける。                                   //
            // ------------------------------------------------------------//
            DataRow _row = this.orderDataTable.Rows.Find(_uniqueID);

            // 一致する行が存在する！
            if (_row != null)
            {
                _row.BeginEdit();
                _row[this.orderDataTable.InpSelectColumn.ColumnName] = selected;
                _row.EndEdit();
            }
        }
        # endregion

        # region ■ 画面データクラス→＜検索用＞条件抽出クラス ■
        /// <summary>
        /// 画面データクラス→＜検索用＞条件抽出クラス
        /// </summary>
        /// <param name="inpDisplay">画面データクラス</param>
        /// <remarks>
        /// <br>Note       : 条件抽出を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        private UOESendProcCndtnPara ToUOESendProcCndtnParaFromInpDisplay(InpDisplay inpDisplay)
        {
            UOESendProcCndtnPara para = new UOESendProcCndtnPara();

            para.EnterpriseCode = inpDisplay.EnterpriseCode;
            para.CashRegisterNo = inpDisplay.CashRegisterNo;
            para.SystemDivCd = inpDisplay.SystemDivCd;
            para.St_OnlineNo = inpDisplay.UOESalesOrderNoSt;
            para.Ed_OnlineNo = inpDisplay.UOESalesOrderNoEd;
            para.St_InputDay = inpDisplay.SalesDateSt;
            para.Ed_InputDay = inpDisplay.SalesDateEd;
            para.CustomerCode = inpDisplay.CustomerCode;
            para.UOESupplierCd = inpDisplay.UOESupplierCd;
            para.DataSendCodes = new int[1];
            para.DataSendCodes[0] = 0;
            return para;
        }
        # endregion

        # region ■ ＵＯＥ発注データ 検索処理 ■
        /// <summary>
        /// ＵＯＥ発注データ 検索処理
        /// </summary>
        /// <param name="inpDisplay">検索条件クラス</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ 検索処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2011/01/30 曹文傑</br>
        /// <br>             UOE自動化対応、自動化のタイプ追加による変更</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
        /// <br>              Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
        /// </remarks>
        public int SearchDB(InpDisplay inpDisplay, out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {   //グリッド用テーブルのクリア
                this.orderDataTable.Rows.Clear();

                //ＵＯＥ発注データ検索＜アクセスクラス呼び出し＞
                _uOEOrderDtlWorkList = null;
                _stockDetailWorkList = null;

                UOESendProcCndtnPara para = ToUOESendProcCndtnParaFromInpDisplay(inpDisplay);

                status = _uoeOrderInfoAcs.Search(para, out _uOEOrderDtlWorkList, out _stockDetailWorkList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    return (status);
                }

                int index = 1;

                // --- ADD 2012/09/20 ---------------------------->>>>>
                // 取得した発注データをソートする(呼出番号、呼出番号枝番の順でソート)
                UOEOrderDtlWorkComparer UoeComp = new UOEOrderDtlWorkComparer();
                _uOEOrderDtlWorkList.Sort(UoeComp);

                // ソートした発注データのシーケンス番号順で、仕入明細データをソートする
                StockDetailWorkComparer StockComp = new StockDetailWorkComparer(_uOEOrderDtlWorkList);
                _stockDetailWorkList.Sort(StockComp);
                // --- ADD 2012/09/20 ----------------------------<<<<<

                //-----------------------------------------------------------
                // ＵＯＥ発注データの格納
                //-----------------------------------------------------------
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    OrderProcDataSet.OrderExpansionRow row = this.orderDataTable.NewOrderExpansionRow();
                    row.OrderNo = index++;
                    row.OnlineNo = uOEOrderDtlWork.OnlineNo;
                    row.InputDay = uOEOrderDtlWork.InputDay;
                    row.CustomerSnm = uOEOrderDtlWork.CustomerSnm;
                    row.CashRegisterNo = uOEOrderDtlWork.CashRegisterNo;
                    row.GoodsMakerCd = uOEOrderDtlWork.GoodsMakerCd;
                    row.GoodsNo = uOEOrderDtlWork.GoodsNo;
                    row.GoodsName = uOEOrderDtlWork.GoodsName;
                    row.AcceptAnOrderCnt = uOEOrderDtlWork.AcceptAnOrderCnt;
                    row.UoeRemark1 = uOEOrderDtlWork.UoeRemark1;
                    // ---ADD 2011/01/30--------------->>>>
                    if ("0104".Equals(uOEOrderDtlWork.CommAssemblyId))
                    {
                        row.UoeRemark2 = uOEOrderDtlWork.UoeRemark2;
                    }
                    else
                    {
                        row.UoeRemark2 = string.Empty;
                    }
                    // ---ADD 2011/01/30---------------<<<<
                    row.EmployeeCode = uOEOrderDtlWork.EmployeeCode;
                    row.EmployeeName = uOEOrderDtlWork.EmployeeName;
                    row.OnlineRowNo = uOEOrderDtlWork.OnlineRowNo;
                    row.UOEKind = uOEOrderDtlWork.UOEKind;
                    row.CommonSeqNo = uOEOrderDtlWork.CommonSeqNo;
                    row.SupplierFormal = uOEOrderDtlWork.SupplierFormal;
                    row.StockSlipDtlNum = uOEOrderDtlWork.StockSlipDtlNum;

                    row.UOEDeliGoodsDiv = uOEOrderDtlWork.UOEDeliGoodsDiv;
                    row.UOEResvdSection = uOEOrderDtlWork.UOEResvdSection;
                    row.FollowDeliGoodsDiv = uOEOrderDtlWork.FollowDeliGoodsDiv;
                    row.BoCode = uOEOrderDtlWork.BoCode;
                    row.WarehouseName = uOEOrderDtlWork.WarehouseName;// ADD wangyl 2013/02/06 Redmine#34578

                    this.orderDataTable.AddOrderExpansionRow(row);
                }

                IsDataChanged = true;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }

            return status;
        }

        #region ヘッダー部入力値の保存処理
        /// <summary>
        /// ヘッダー部入力値の保存処理
        /// </summary>
        /// <param name="inpHedDisplay"> ヘッダー部入力クラス</param>
        /// <remarks>
        /// <br>Note       : ヘッダー部入力値の保存処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2011/01/30 曹文傑</br>
        /// <br>             UOE自動化対応、自動化のタイプ追加による変更</br>
        /// </remarks>
        public void UpdtHedaerItem(InpHedDisplay inpHedDisplay)
        {
            DataView orderDataView = new DataView(this.orderDataTable);

            string rowFilterString = "";

            //オンライン番号
            rowFilterString = String.Format("{0} = {1}",
                                                    this.orderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo);

            orderDataView.RowFilter = rowFilterString;

            for (int ix = 0; ix < orderDataView.Count; ix++)
            {
                OrderProcDataSet.OrderExpansionRow dataRow = (OrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                dataRow[this.orderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // ＵＯＥリマーク１
                dataRow[this.orderDataTable.UoeRemark2Column.ColumnName] = inpHedDisplay.UoeRemark2;                    // ＵＯＥリマーク２  // ADD 2011/01/30
                dataRow[this.orderDataTable.EmployeeCodeColumn.ColumnName] = inpHedDisplay.EmployeeCode;                // 従業員コード
                dataRow[this.orderDataTable.EmployeeNameColumn.ColumnName] = inpHedDisplay.EmployeeName;                // 従業員名称

                dataRow[this.orderDataTable.UOEDeliGoodsDivColumn.ColumnName] = inpHedDisplay.UOEDeliGoodsDiv;                // 納品区分
                dataRow[this.orderDataTable.UOEResvdSectionColumn.ColumnName] = inpHedDisplay.UOEResvdSection;                // UOE指定拠点
                dataRow[this.orderDataTable.FollowDeliGoodsDivColumn.ColumnName] = inpHedDisplay.FollowDeliGoodsDiv;             // Ｈ納品区分
                dataRow[this.orderDataTable.UOEDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.DeliveredGoodsDivNm;                // 納品区分名称
                dataRow[this.orderDataTable.UOEResvdSectionNmColumn.ColumnName] = inpHedDisplay.UOEResvdSectionNm;                // UOE指定拠点名称
                dataRow[this.orderDataTable.FollowDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.FollowDeliGoodsDivNm;             // Ｈ納品区分名称
            }

        }

        # endregion

        # endregion

        #region ＵＯＥ発注データ削除件数取得
        /// <summary>
        /// ＵＯＥ発注データ削除件数取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ削除件数取得を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public int GetDeleteCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }

        /// <summary>
        /// ＵＯＥ発注データ選択しないの件数取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ選択しないの件数取得を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public int GetNoSelectCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, false);
                count = orderDataView.Count;
            }
            catch (Exception)
            {
                count = 0;
            }
            return count;
        }
        # endregion

        #region 発注ブロック数の算出
        /// <summary>
        /// ＵＯＥ発注データ発注セット数の算出
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ発注セット数の算出を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>UpdateNote : 2011/02/09 丁建雄</br>
        /// <br>             Redmine#18854対応</br>
        /// </remarks>
        public int GetBlocCount()
        {
            int count = 0;
            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);

                //送信明細数
                int detailIndex = 0;
                //前回ｵﾝﾗｲﾝ番号
                int bfOnlineNo = 0;
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    OrderProcDataSet.OrderExpansionRow dataRow = (OrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                    Int32 onlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];

                    detailIndex++;

                    if (bfOnlineNo == 0 || bfOnlineNo != onlineNo)
                    {
                        count++;
                        bfOnlineNo = onlineNo;
                        detailIndex = 0;
                    }
                    else
                    {
                        if (detailIndex >= 12)
                        {
                            count++;
                            bfOnlineNo = onlineNo;
                            detailIndex = 0;
                        }
                    }
                }

            }
            catch (Exception)
            {
                count = 0;
            }
            //this.setCount = count;    // DEL 2011/02/09
            return count;
        }

        # endregion

        #region 発注ブロック数の算出
        /// <summary>
        /// ＵＯＥ発注データ発注セット数の算出
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ発注セット数の算出を行います。</br>
        /// <br>Programmer : 丁建雄</br>
        /// <br>Date       : 2011/02/09</br>
        /// </remarks>
        public int GetCount(List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int count = 0;

            //前回発注番号
            int bfUOESalesOrderNo = 0;

            for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
            {
                Int32 UOESalesOrderNo = uOEOrderDtlWorkList[i].UOESalesOrderNo;

                if (bfUOESalesOrderNo == 0 || bfUOESalesOrderNo != UOESalesOrderNo)
                {
                    count++;
                    bfUOESalesOrderNo = UOESalesOrderNo;
                }
            }
            this.setCount = count;

            return count;
        }
        #endregion

        #region ＵＯＥ発注データ更新処理
        /// <summary>
        /// データ保存処理
        /// </summary>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="toyotaFlod">フォルダ</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注削除データ</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ保存処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public int WriteDB(int cashRegisterNo, int systemDiv, string toyotaFlod, out string message,
               out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList, 
               out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                //保存データ取得処理
                uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
                stockDetailWorkList = new List<StockDetailWork>();

                uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
                stockDetailWorkDelList = new List<StockDetailWork>();

                status = GetUOEOrderDtlWorkFromRowData(1, cashRegisterNo, systemDiv, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkList == null && uOEOrderDtlWorkDelList == null) return (-1);
                if (uOEOrderDtlWorkList.Count == 0 && uOEOrderDtlWorkDelList.Count == 0) return (-1);

                // システム区分が在庫一括時、数量に０を設定された明細を削除処理
                if (uOEOrderDtlWorkDelList != null && uOEOrderDtlWorkDelList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
                }
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                // 更新
                if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0)
                {
                    status = _uoeOrderInfoAcs.WriteUOEOrderDtl(ref uOEOrderDtlWorkList, ref stockDetailWorkList, out message);
                    if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
                uOEOrderDtlWorkDelList = null;
                stockDetailWorkDelList = null;
                message = ex.Message;
                return -1;
            }

            return status;
        }
        # endregion

        /// <summary>
        /// データ保存処理
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="toyotaFlod">フォルダ</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注削除データ</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ保存処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2010/01/22 譚洪 明細数が多いと品番のセットがずれて設定されてしまうの対応</br>
        /// <br>Update Note: 2011/01/30 曹文傑</br>
        /// <br>             UOE自動化対応、自動化のタイプ追加による変更</br>
        /// <br>Update Note: 2011/02/09 丁建雄</br>
        /// <br>             Redmine#18854対応</br>
        /// <br>Update Note: 2011/02/21 曹文傑</br>
        /// <br>             Redmine#19088の対応</br>
        /// <br>Update Note: 2011/12/15 yangmj</br>
        /// <br>             トヨタUOEWebタクティー品番の発注対応</br>
        /// </remarks>
        public int WriteText(int systemDiv, string toyotaFlod, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList, List<StockDetailWork> stockDetailWorkList,
               // List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList)//DEL 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
               List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, List<StockDetailWork> stockDetailWorkDelList, UOESupplier uoeSupplier)//ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応

        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            FileStream fs = null;

            try
            {
                //  ADD 2011/02/09  >>>
                this.GetCount(uOEOrderDtlWorkList);
                //  ADD 2011/02/09  <<<

                // ---ADD 2011/02/21----------->>>>>
                if (uOEOrderDtlWorkList != null && uOEOrderDtlWorkList.Count > 0)
                {
                // ---ADD 2011/02/21-----------<<<<<
                    // ---ADD 2011/01/30------------------->>>>
                    DataView orderDataView = new DataView(this.orderDataTable);

                    orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);
                    // 発注先マスタのプログラムを参照し、リマーク２へのセット内容変更を行う。
                    for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                    {
                        UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                        for (int j = 0; j < orderDataView.Count; j++)
                        {
                            OrderProcDataSet.OrderExpansionRow dataRow = (OrderProcDataSet.OrderExpansionRow)(orderDataView[j].Row);
                            if ((Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName] == work.OnlineNo)
                            {
                                if ("0104".Equals(work.CommAssemblyId.Trim()))
                                {
                                    work.UoeRemark2 = dataRow[this.orderDataTable.UoeRemark2Column.ColumnName].ToString().Trim();
                                }
                                else
                                {
                                    // なし。
                                }
                                break;
                            }
                            else
                            {
                                // なし。
                            }
                        }
                    }
                    // ---ADD 2011/01/30-------------------<<<<
                // ---ADD 2011/02/21------------------>>>>>
                    this._uOEOrderDtlWorkAL = new ArrayList(uOEOrderDtlWorkList);
                }
                // ---ADD 2011/02/21------------------<<<<<

                fs = new FileStream(toyotaFlod, FileMode.Create, FileAccess.ReadWrite, FileShare.None);
                TelegramEditOrder0103 telegramEditOrder0103 = new TelegramEditOrder0103();
                telegramEditOrder0103.uOESupplier = uoeSupplier;//ADD 2011/12/15 yangmj トヨタUOEWebタクティー品番の発注対応
                byte[] tempbyte = null;
                byte[] countbyte = new byte[4];
                byte[] spacebyte = new byte[103];

                // 先頭 4 Byte：３３＋スペース＋スペース
                if (this.setCount.ToString().Length == 2)
                {
                    //UoeCommonFnc.MemCopy(ref countbyte, this.setCount.ToString(), countbyte.Length);  // DEL 2011/02/09
                    UoeCommonFnc.MemCopy(ref countbyte, this.setCount.ToString() + " " + " ", countbyte.Length);    // ADD 2011/02/09
                }
                // 先頭 4 Byte：スペース＋３＋スペース＋スペース
                else if (this.setCount.ToString().Length == 1)
                {
                    //UoeCommonFnc.MemCopy(ref countbyte, " " + this.setCount.ToString(), countbyte.Length);    // DEL 2011/02/09
                    UoeCommonFnc.MemCopy(ref countbyte, " " + this.setCount.ToString() + " " + " ", countbyte.Length);  // ADD 2011/02/09
                }

                UoeCommonFnc.MemSet(ref spacebyte, 0x20, spacebyte.Length);
                MemoryStream ms = new MemoryStream();
                ms.Write(countbyte, 0, countbyte.Length);
                ms.Write(spacebyte, 0, spacebyte.Length);
                byte[] startDatabyte = ms.ToArray();

                // 実レコード数（先頭 4 Byte）　※残り103 Byte はスペース詰め
                fs.Write(startDatabyte, 0, startDatabyte.Length);

                Int32 fristFlg = 0;
                Int32 onlineNo = -1;
                Int32 detailCount = 0;
                Int32 dataCount = 1;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];
                    //発注番号が変更された
                    if ((fristFlg != 0) && (onlineNo != work.OnlineNo))
                    {
                        tempbyte = telegramEditOrder0103.ToByteArray();

                        fs.Write(tempbyte, 0, tempbyte.Length);

                        for (int j = 0; j < 4 - dataCount; j++)
                        {
                            //電文明細クラス明細のクリア
                            telegramEditOrder0103.ClearDetail();
                            telegramEditOrder0103.changeFlg();

                            tempbyte = telegramEditOrder0103.ToByteArray();

                            fs.Write(tempbyte, 0, tempbyte.Length);
                        }

                        //電文明細クラス全てのクリア
                        telegramEditOrder0103.Clear();
                        //送信電文(JIS)
                        telegramEditOrder0103.Telegram(work);

                        onlineNo = work.OnlineNo;
                        detailCount = 1;
                        dataCount = 1;
                    }
                    else
                    {
                        fristFlg = 1;
                        detailCount = detailCount + 1;

                        if (dataCount == 4 && detailCount == 4)
                        {
                            tempbyte = telegramEditOrder0103.ToByteArray();

                            fs.Write(tempbyte, 0, tempbyte.Length);

                            //電文明細クラス明細のクリア
                            telegramEditOrder0103.ClearDetail();

                            //送信電文(JIS)
                            telegramEditOrder0103.Telegram(work);
                            detailCount = 1;
                            dataCount = 1;

                            onlineNo = work.OnlineNo;

                            continue;                // ADD 2010/01/22
                        }

                        if (dataCount > 4)
                        {
                            tempbyte = telegramEditOrder0103.ToByteArray();

                            fs.Write(tempbyte, 0, tempbyte.Length);

                            //電文明細クラス明細のクリア
                            telegramEditOrder0103.ClearDetail();

                            //送信電文(JIS)
                            telegramEditOrder0103.Telegram(work);
                            detailCount = 1;
                            dataCount = 1;

                            onlineNo = work.OnlineNo;
                        }

                        if (detailCount > 3)
                        {
                            dataCount = dataCount + 1;

                            tempbyte = telegramEditOrder0103.ToByteArray();

                            fs.Write(tempbyte, 0, tempbyte.Length);

                            //電文明細クラス明細のクリア
                            telegramEditOrder0103.ClearDetail();

                            //送信電文(JIS)
                            telegramEditOrder0103.Telegram(work);
                            detailCount = 1;

                            onlineNo = work.OnlineNo;
                        }
                        else
                        {
                            //送信電文(JIS)
                            telegramEditOrder0103.Telegram(work);

                            onlineNo = work.OnlineNo;
                        }
                    }
                }

                tempbyte = telegramEditOrder0103.ToByteArray();

                fs.Write(tempbyte, 0, tempbyte.Length);

                for (int j = 0; j < 4 - dataCount; j++)
                {
                    //電文明細クラス明細のクリア
                    telegramEditOrder0103.ClearDetail();
                    telegramEditOrder0103.changeFlg();

                    tempbyte = telegramEditOrder0103.ToByteArray();

                    fs.Write(tempbyte, 0, tempbyte.Length);
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                if (fs != null)
                {
                    fs.Flush();
                    fs.Close();
                }
            }
            return status;
        }
        #region 選択データの取得処理
        /// <summary>
        /// 選択データの取得処理
        /// </summary>
        /// <param name="mode">0:全て 1:変更データ 2:選択データ</param>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ更新用リスト</param>
        /// <param name="stockDetailWorkList">仕入明細更新用リスト</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注データ削除用リスト</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除用リスト</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : 選択データの取得処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2011/01/30 曹文傑</br>
        /// <br>             UOE自動化対応、自動化のタイプ追加による変更</br>
        /// </remarks>
        public int GetUOEOrderDtlWorkFromRowData(int mode, int cashRegisterNo, int systemDiv, 
                                                                out List<UOEOrderDtlWork> uOEOrderDtlWorkList, out List<StockDetailWork> stockDetailWorkList,
                                                                out List<UOEOrderDtlWork> uOEOrderDtlWorkDelList, out List<StockDetailWork> stockDetailWorkDelList, 
                                                                out string message)
        {
            // 戻値
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            uOEOrderDtlWorkList = new List<UOEOrderDtlWork>();
            stockDetailWorkList = new List<StockDetailWork>();
            uOEOrderDtlWorkDelList = new List<UOEOrderDtlWork>();
            stockDetailWorkDelList = new List<StockDetailWork>();
            message = "";
            //bool firstFlg = true;//DEL BY 凌小青 on 2011/11/12 for Redmine#26485
            string uoeRemark = string.Empty;

            try
            {
                DataView orderDataView = new DataView(this.orderDataTable);

                orderDataView.RowFilter = String.Format("{0} = {1}", this.orderDataTable.InpSelectColumn.ColumnName, true);

                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    string key;
                    List<UOEOrderDtlWork> uOEresultList;
                    List<StockDetailWork> stockresultList;
                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    OrderProcDataSet.OrderExpansionRow dataRow = (OrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                    uOEOrderDtlWork.EmployeeCode = _enterpriseCode;
                    uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.orderDataTable.OnlineNoColumn.ColumnName];
                    uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.orderDataTable.OnlineRowNoColumn.ColumnName];
                    uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.orderDataTable.UOEKindColumn.ColumnName];
                    uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.orderDataTable.CommonSeqNoColumn.ColumnName];
                    uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.orderDataTable.SupplierFormalColumn.ColumnName];
                    uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.orderDataTable.StockSlipDtlNumColumn.ColumnName];

                    key = MakeKey(uOEOrderDtlWork);

                    //データ取得処理
                    uOEresultList = this._uOEOrderDtlWorkList.FindAll(delegate(UOEOrderDtlWork target)
                    {
                        if (key.Equals(MakeKey(target)))
                        {
                            return (true);
                        }
                        else
                        {
                            return (false);
                        }
                    });

                    if (uOEresultList.Count != 0)
                    {
                        UOEOrderDtlWork uOEOrderDtlWorktemp = uOEresultList[0];
                        if (mode == 1 && (systemDiv != 3 
                            || 0 != double.Parse(dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))
                        {
                            // 受信日付
                            uOEOrderDtlWorktemp.ReceiveDate = System.DateTime.Now;
                            // 送信フラグ
                            uOEOrderDtlWorktemp.DataSendCode = 1;
                            // 復旧フラグ
                            uOEOrderDtlWorktemp.DataRecoverDiv = 0;
                            // 送信端末番号
                            uOEOrderDtlWorktemp.SendTerminalNo = cashRegisterNo;
                            // UOEリマーク１
                            uOEOrderDtlWorktemp.UoeRemark1 = dataRow[this.orderDataTable.UoeRemark1Column.ColumnName].ToString().Trim();
                            //-------UPD BY 凌小青 on 2011/11/12 for Redmine#26485 ---->>>>>>>>>
                            //if (firstFlg)
                            //{
                                // UOEリマーク２
                                uoeRemark = "@" + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                                //------UPD BY 凌小青 on 2011/11/29 for Redmie#7733 ---->>>>>>>
                                //this.remark2 = uoeRemark; // ADD 2011/01/31
                                if (!remark2.Contains(uoeRemark))
                                {
                                    remark2.Add(uoeRemark);
                                }
                                //------UPD BY 凌小青 on 2011/11/29 for Redmie#7733 ----<<<<<<<<
                                uOEOrderDtlWorktemp.UoeRemark2 = uoeRemark;
                            //    firstFlg = false;
                            //}
                            //else
                            //{
                            //    uOEOrderDtlWorktemp.UoeRemark2 = uoeRemark;
                            //}
                            //-------UPD BY 凌小青 on 2011/11/12 for Redmine#26485 ----<<<<<<<<<<
                            // 納品区分
                            uOEOrderDtlWorktemp.UOEDeliGoodsDiv = dataRow[this.orderDataTable.UOEDeliGoodsDivColumn.ColumnName].ToString();
                            // 納品区分名称
                            uOEOrderDtlWorktemp.DeliveredGoodsDivNm = dataRow[this.orderDataTable.UOEDeliGoodsDivNmColumn.ColumnName].ToString();
                            // フォロー納品区分
                            uOEOrderDtlWorktemp.FollowDeliGoodsDiv = dataRow[this.orderDataTable.UOEDeliGoodsDivColumn.ColumnName].ToString();
                            // フォロー納品区分名称
                            uOEOrderDtlWorktemp.FollowDeliGoodsDivNm = dataRow[this.orderDataTable.FollowDeliGoodsDivNmColumn.ColumnName].ToString();
                            // UOE指定拠点
                            uOEOrderDtlWorktemp.UOEResvdSection = dataRow[this.orderDataTable.UOEResvdSectionColumn.ColumnName].ToString();
                            // UOE指定拠点名称
                            uOEOrderDtlWorktemp.UOEResvdSectionNm = dataRow[this.orderDataTable.UOEResvdSectionNmColumn.ColumnName].ToString();
                            // 従業員コード
                            uOEOrderDtlWorktemp.EmployeeCode = dataRow[this.orderDataTable.EmployeeCodeColumn.ColumnName].ToString().Trim();
                            // 従業員名称
                            uOEOrderDtlWorktemp.EmployeeName = dataRow[this.orderDataTable.EmployeeNameColumn.ColumnName].ToString().Trim();
                            // BO区分
                            uOEOrderDtlWorktemp.BoCode = dataRow[this.orderDataTable.BoCodeColumn.ColumnName].ToString().Trim();
                            // 受注数量
                            uOEOrderDtlWorktemp.AcceptAnOrderCnt = double.Parse(dataRow[this.orderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString());

                            uOEOrderDtlWorkList.Add(uOEOrderDtlWorktemp);

                            key = MakeStockKey(uOEOrderDtlWorktemp.EnterpriseCode, uOEOrderDtlWorktemp.SupplierFormal, uOEOrderDtlWorktemp.StockSlipDtlNum);
                            stockresultList = this._stockDetailWorkList.FindAll(delegate(StockDetailWork target)
                            {
                                if (key.Equals(MakeStockKey(target.EnterpriseCode, target.SupplierFormal, target.StockSlipDtlNum)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (StockDetailWork stockDetailWork in stockresultList)
                            {
                                stockDetailWorkList.Add(stockDetailWork);
                            }
                        }
                        else
                        {
                            uOEOrderDtlWorkDelList.Add(uOEOrderDtlWorktemp);

                            key = MakeStockKey(uOEOrderDtlWorktemp.EnterpriseCode, uOEOrderDtlWorktemp.SupplierFormal, uOEOrderDtlWorktemp.StockSlipDtlNum);
                            stockresultList = this._stockDetailWorkList.FindAll(delegate(StockDetailWork target)
                            {
                                if (key.Equals(MakeStockKey(target.EnterpriseCode, target.SupplierFormal, target.StockSlipDtlNum)))
                                {
                                    return (true);
                                }
                                else
                                {
                                    return (false);
                                }
                            });

                            foreach (StockDetailWork stockDetailWork in stockresultList)
                            {
                                stockDetailWorkDelList.Add(stockDetailWork);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                uOEOrderDtlWorkList = null;
                stockDetailWorkList = null;
                uOEOrderDtlWorkDelList = null;
                stockDetailWorkDelList = null;
                message = ex.Message;
                status = -1;
            }

            return status;

        }

        #endregion

        #region ＵＯＥ発注データ削除処理
        /// <summary>
        /// ＵＯＥ発注データ削除処理
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ削除処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        public int DeleteDB(out string message)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";

            try
            {
                // 削除対象のＵＯＥ発注データの取得
                List<UOEOrderDtlWork> uOEOrderDtlWorkList = null;
                List<StockDetailWork> stockDetailWorkList = null;
                List<UOEOrderDtlWork> uOEOrderDtlWorkDelList = null;
                List<StockDetailWork> stockDetailWorkDelList = null;

                status = GetUOEOrderDtlWorkFromRowData(2, 0, 0, out uOEOrderDtlWorkList, out stockDetailWorkList, out uOEOrderDtlWorkDelList, out stockDetailWorkDelList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);
                if (uOEOrderDtlWorkDelList == null) return (-1);
                if (stockDetailWorkDelList.Count == 0) return (-1);

                status = _uoeOrderInfoAcs.Delete(uOEOrderDtlWorkDelList, out message);
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL) return (status);

            }
            catch (Exception ex)
            {
                message = ex.Message;
                return -1;
            }
            return status;
        }

        # endregion

        #region Key作成
        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="uOEOrderDtlWork">明細・行</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : Key作成処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        private string MakeKey(UOEOrderDtlWork uOEOrderDtlWork)
        {
            // 明細・行Primary Key
            string key = uOEOrderDtlWork.OnlineNo.ToString() + uOEOrderDtlWork.OnlineRowNo.ToString() + uOEOrderDtlWork.UOEKind.ToString()
                + uOEOrderDtlWork.CommonSeqNo.ToString() + uOEOrderDtlWork.SupplierFormal.ToString() + uOEOrderDtlWork.StockSlipDtlNum.ToString();

            return key;
        }

        /// <summary>
        /// Key作成処理
        /// </summary>
        /// <param name="enterpriseCode">企業コード</param>
        /// <param name="supplierFormal">仕入形式</param>
        /// <param name="stockSlipDtlNum">仕入明細通番</param>
        /// <returns>Key</returns>
        /// <remarks>
        /// <br>Note       : 明細・行Key作成処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// </remarks>
        private string MakeStockKey(string enterpriseCode, int supplierFormal, long stockSlipDtlNum)
        {
            // 明細・行Primary Key
            string key = enterpriseCode.ToString() + supplierFormal.ToString() + stockSlipDtlNum.ToString();
            return key;
        }


        #endregion Key作成

        #region 保存データチェック処理
        /// <summary>
        /// 保存データチェック処理
        /// </summary>
        /// <param name="businessCode">業務区分</param>
        /// <param name="systemDivCd">システム区分</param>
        /// <param name="itemNameList">項目名称リスト</param>
        /// <param name="itemList">項目リスト</param>
        /// <returns>true:保存可 false:保存不可</returns>
        /// <remarks>
        /// <br>Note       : 保存データチェック処理を行います。</br>
        /// <br>Programmer : 譚洪</br>
        /// <br>Date       : 2009/12/31</br>
        /// <br>Update Note: 2010/01/19 譚洪 redmine#2509対応</br>
        /// </remarks>
        public bool SaveDataCheck(int businessCode, int systemDivCd, out List<string> itemNameList, out List<string> itemList)
        {
            itemNameList = new List<string>();
            itemList = new List<string>();

            foreach (OrderProcDataSet.OrderExpansionRow row in this._orderDataTable)
            {
                if (row.InpSelect == true)
                {
                    // システム区分が在庫一括時、数量に０を設定された明細を削除処理
                    if (systemDivCd == 3 && row.AcceptAnOrderCnt == 0)
                    {
                        continue;
                    }
                    //納品区分のチェック
                    // 発注の場合
                    if ((businessCode == ctTerminalDiv_Order)
                        //&& (string.IsNullOrEmpty(row.UOEDeliGoodsDiv)))               // DEL 2010/01/19
                        && (string.IsNullOrEmpty(row.UOEDeliGoodsDivNm)))              // ADD 2010/01/19
                    {
                        itemNameList.Add("納品区分");
                        itemList.Add("OrderExpansion");
                    }

                    //Ｈ納品区分
                    // 発注の場合
                    // トヨタの場合
                    if ((businessCode == ctTerminalDiv_Order)
                        //&& (string.IsNullOrEmpty(row.FollowDeliGoodsDiv)))             // DEL 2010/01/19
                        && (string.IsNullOrEmpty(row.FollowDeliGoodsDivNm)))            // ADD 2010/01/19
                    {
                        itemNameList.Add("Ｈ納品区分");
                        itemList.Add("OrderExpansion");
                    }

                    //指定拠点
                    if ((businessCode == ctTerminalDiv_Order)
                        //&& (string.IsNullOrEmpty(row.UOEResvdSection)))              // DEL 2010/01/19
                        && (string.IsNullOrEmpty(row.UOEResvdSectionNm)))              // ADD 2010/01/19
                    {
                        itemNameList.Add("指定拠点");
                        itemList.Add("OrderExpansion");
                    }

                    //依頼者
                    if ((businessCode == ctTerminalDiv_Order)
                    && (row.EmployeeCode.Trim() == ""))
                    {
                        itemNameList.Add("依頼者");
                        itemList.Add("OrderExpansion");
                    }
                }

                if (itemNameList.Count > 0) break;
            }
            if (itemNameList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion

        #region 自動更新処理
        /// <summary>
        /// 自動更新処理
        /// </summary>
        /// <param name="dir">発注送信データファイル名称</param>
        /// <param name="subDir">発注送信データサブファイル名称</param>
        /// <param name="uoeSupplier">UOE発注先マスタ</param>
        /// <param name="uOEConnectInfo">UOE接続先情報マスタ</param>
        /// <param name="errMess">エラーメッセージ</param>
        /// <param name="results">オンライン番号results</param> //ADD BY 凌小青 on 2011/11/29 for Redmine#7733 
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自動更新を行いします。</br>
        /// <br>Programmer : 呉元嘯</br>
        /// <br>Date       : 2010/07/26</br>
        /// <br>Update Note: 2010/08/31 呉元嘯</br>
        /// <br>             Redmine#13666対応</br>
        /// <br>Update Note: 2011/01/30 曹文傑</br>
        /// <br>             UOE自動化対応、自動化のタイプ追加による変更</br>
        /// <br>Update Note: 2011/02/21 曹文傑</br>
        /// <br>             Redmine#19088の対応</br>
        /// <br>Update Note : 2017/07/12 30757 佐々木貴英</br>
        /// <br>管理番号    : 11370054-00 トヨタ新WEBUOEロボット対応</br>
        /// <br>              発注送信データサブファイルを作成しないよう変更</br>
        /// </remarks>
        //public int AutoUpdateProc(string dir, string subDir, UOESupplier uoeSupplier, UOEConnectInfo uOEConnectInfo, out string errMess)//DEL BY 凌小青 on 2011/11/29 for Redmie#7733
        public int AutoUpdateProc(string dir, string subDir, UOESupplier uoeSupplier, UOEConnectInfo uOEConnectInfo, out string errMess, ref List<string> results)//ADD BY 凌小青 on 2011/11/29 for Redmie#7733
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string subMess = string.Empty;
            errMess = string.Empty;
            int count = 0;
            string subDirStr = string.Empty;
            try
            {
                //---DEL 2017/07/12 30757 佐々木貴英 トヨタ新WEBUOEロボット対応 ----->>>>>
                //if (!string.IsNullOrEmpty( subDir ))
                //{
                //    // サブファイル暗号化プログラム呼び出し
                //    status = xEncryptsFile(subDir, 1);
                //}
                //---DEL 2017/07/12 30757 佐々木貴英 トヨタ新WEBUOEロボット対応 -----<<<<<

                count = this.GetDeleteCount();

                //---DEL 2017/07/12 30757 佐々木貴英 トヨタ新WEBUOEロボット対応 ----->>>>>
                ////暗号化失敗或いはサブテキストファイル未作成場合
                //if ((status != 0) || (string.IsNullOrEmpty(subDir)))
                //{
                //    subDirStr = string.Empty;
                //}
                //else
                //{
                //    subDirStr = subDir;
                //}
                //---DEL 2017/07/12 30757 佐々木貴英 トヨタ新WEBUOEロボット対応 -----<<<<<

                // ----------ADD 2010/08/31----------->>>>>
                // インポート中画面部品のインスタンスを作成
                Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
                // 表示文字を設定
                form.Title = "更新処理中";
                form.Message = "更新処理中です。";
                // ダイアログ表示
                form.Show();
                // ----------ADD 2010/08/31-----------<<<<<

                // 自動化プログラム呼び出し
                //UOE接続先情報マスタある場合
                if (uOEConnectInfo != null)
                {
                    status = xPMPU9011(1, dir, uOEConnectInfo.SocketCommPort, uOEConnectInfo.ReceiveComputerNm, uOEConnectInfo.ClientTimeOut, subDirStr, count, ref errMess);
                }
                else
                {
                    status = xPMPU9011(1, dir, 0, string.Empty, 0, subDirStr, count, ref errMess);
                }
                // ---ADD 2011/02/21-------------->>>>>
                // 発注先マスタのプログラムが「0104」の場合、PMPU9011からの戻り値が「0以外の場合」、ＵＯＥ発注データのリマーク２を画面入力値へ変更
                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL && "0104".Equals(uoeSupplier.CommAssemblyId))
                {
                    if (this._uOEOrderDtlWorkAL != null && this._uOEOrderDtlWorkAL.Count > 0)
                    {
                        object paraObj = this._uOEOrderDtlWorkAL as object;
                        if (this._iUOEOrderDtlDB == null)
                        {
                            this._iUOEOrderDtlDB = (IUOEOrderDtlDB)MediationUOEOrderDtlDB.GetUOEOrderDtlDB(); // ADD 2011/02/21 
                        }
                        // ＵＯＥ発注データリモートを呼び出し、ＵＯＥ発注データを変更する。
                        this._iUOEOrderDtlDB.Write(ref paraObj);
                    }
                }
                // ---ADD 2011/02/21--------------<<<<<
                // ----------ADD 2010/08/31----------->>>>>
                // ダイアログを閉じる
                form.Close();
                // ----------ADD 2010/08/31-----------<<<<<

                switch ((Int16)status)
                {
                    case 0:
                        {
                            errMess = "正常終了。";
                            #region 回答テキストの取込処理
                            UOEOrderDtlToyotaAcs uOEOrderDtlToyotaAcs = new UOEOrderDtlToyotaAcs();

                            ToyotaAnswerDatePara toyotaAnswerDatePara = new ToyotaAnswerDatePara();
                            toyotaAnswerDatePara.EnterpriseCode = this._enterpriseCode;
                            toyotaAnswerDatePara.SectionCode = this._loginSectionCode;
                            toyotaAnswerDatePara.UOESupplierCd = uoeSupplier.UOESupplierCd;
                            toyotaAnswerDatePara.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;

                            // 回答情報の取得を行います
                            // ---UPD 2011/01/30--------------->>>>
                            //status = uOEOrderDtlToyotaAcs.DoSearch(toyotaAnswerDatePara, out errMess);
                            if ("0104".Equals(uoeSupplier.CommAssemblyId))
                            {
                                // OverLoadした別メソッドを呼び出す。
                                //------UPD BY 凌小青 on 2011/11/29 for Redmie#7733 ---->>>>>>>
                                 List<string> result = new List<string>();
                                //status = uOEOrderDtlToyotaAcs.DoSearch(toyotaAnswerDatePara, out errMess, this.remark2);
                                 status = uOEOrderDtlToyotaAcs.DoSearch(toyotaAnswerDatePara, out errMess, this.remark2, ref results);
                                //------UPD BY 凌小青 on 2011/11/29 for Redmie#7733 ----<<<<<<<
                            }
                            else
                            {
                                // 既存のメソッドを呼び出す
                                //status = uOEOrderDtlToyotaAcs.DoSearch(toyotaAnswerDatePara, out errMess);//DEL BY 凌小青 on 2011/11/12 for Redmine#26485
                                List<string> result = new List<string>();//ADD BY 凌小青 on 2011/11/12 for Redmine#26485
                                status = uOEOrderDtlToyotaAcs.DoSearch(toyotaAnswerDatePara, out errMess,ref result);//ADD BY 凌小青 on 2011/11/12 for Redmine#26485
                            }
                            // ---UPD 2011/01/30---------------<<<<

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // トランザクションデータの作成を行います
                                status = uOEOrderDtlToyotaAcs.DoConfirm(toyotaAnswerDatePara, out errMess);
                            }
                            #endregion
                            break;
                        }
                    case 1:
                        {
                            subMess = "電子カタログ起動済みエラー。";
                            break;
                        }
                    case -1:
                        {
                            subMess = "電子カタログエラー。";
                            break;
                        }
                    case -2:
                        {
                            subMess = "メーカー不正。";
                            break;
                        }
                    case -3:
                        {
                            subMess = "送信ファイル無し。";
                            break;
                        }
                    case -4:
                        {
                            subMess = "ソケットエラー。";
                            break;
                        }
                    case -5:
                        {
                            subMess = "パラメータエラー。";
                            break;
                        }
                    case -6:
                        {
                            subMess = "IPアドレス変換エラー。";
                            break;
                        }
                    case -7:
                        {
                            subMess = "回答ファイル無しエラー。";
                            break;
                        }
                    case -8:
                        {
                            subMess = "送受信ファイル削除エラー。";
                            break;
                        }
                    case -9:
                        {
                            subMess = "タイムアウト。";
                            break;
                        }
                    case -10:
                        {
                            subMess = "サービスタイムアウト。";
                            break;
                        }
                    case -11:
                        {
                            subMess = "受信ファイルタイムアウト。";
                            break;
                        }
                    case -12:
                        {
                            subMess = "クライアントタイムアウト。";
                            break;
                        }
                    case -999:
                        {
                            subMess = "その他エラー。";
                            break;
                        }
                    case 999:
                        {
                            subMess = "接続先未設定。";
                            break;
                        }
                }

                // PMPU9011.DLLの戻り値＝「0以外」の場合は
                if (!string.IsNullOrEmpty(subMess))
                {
                    //「ref msg」が入っている場合
                    if (!string.IsNullOrEmpty(errMess))
                    {
                        //上記エラーメッセージと改行後に「ref msg」の値も追加して、メッセージボックスの表示を行う
                        errMess = subMess + "\r\n" + errMess;
                    }
                    else
                    {
                        errMess = subMess;
                    }
                }
            }
            catch (Exception ex)
            {
                errMess = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (Int16)status;

        }

        // --------ADD 2010/07/26-------->>>>>
        /// <summary>
        /// 自動化プログラム
        /// </summary>
        [DllImport("PMPU9011.dll")]
        public extern static int xPMPU9011(int imk, string dir, int port, string pcname, int itimeout, string sdir,int imei, ref string msg);
        
        /// <summary>
        /// サブファイル暗号化
        /// </summary>
        [DllImport("PMPU9012.dll")]
        public extern static int xEncryptsFile(string subFileName, int flag);
        // --------ADD 2010/07/26--------<<<<<
        #endregion
    }
}
