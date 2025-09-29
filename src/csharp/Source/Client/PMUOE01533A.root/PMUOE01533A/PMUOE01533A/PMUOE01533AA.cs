//****************************************************************************//
// システム         : PM.NS
// プログラム名称   : 三菱発注処理
// プログラム概要   : 三菱発注処理を行う
//----------------------------------------------------------------------------//
//                (c)Copyright  2010 Broadleaf Co.,Ltd.
//============================================================================//
// 履歴
//----------------------------------------------------------------------------//
// 管理番号  10601191-00 作成担当 : gaoyh
// 作 成 日  2010/04/20  修正内容 : 新規作成
//                                  三菱Web-UOEとの連携用データとして、UOE発注データから三菱Web-UOE用システム連携ファイルの作成を行う
// 管理番号              作成担当 : gaoyh
// 作 成 日  2010/05/07  修正内容 : #7086 発注可能数のチェック
// 管理番号              作成担当 : gaoyh
// 作 成 日  2010/05/18  修正内容 : #7591 三菱発注処理 ファイルの存在チェック追加
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 曹文傑
// 修 正 日  2010/12/31  修正内容 : UOE自動化改良
//----------------------------------------------------------------------------//
// 管理番号  10607734-00 作成担当 : 曹文傑
// 修 正 日  2011/01/13  修正内容 : UOE自動化改良redmine:#18531
//----------------------------------------------------------------------------//
// 管理番号  10900690-00 作成担当 : wangyl
// 修 正 日  2013/02/06  修正内容 : 10900690-00 2013/03/13配信分の緊急対応
//                                  Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい 
//----------------------------------------------------------------------------//

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
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
using System.Runtime.InteropServices;           // ADD 2010/12/31

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// 三菱発注処理アクセスクラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 三菱発注処理のアクセス制御を行います。</br>
    /// <br>Programmer : gaoyh</br>
    /// <br>Date       : 2010/04/20</br>
    /// <br>UpdateNote : 2010/12/31 曹文傑 UOE自動化改良</br>
    /// <br>UpdateNote : 2011/01/13 曹文傑 UOE自動化改良redmine:#18531</br>
    /// <br>Update Note : 2013/02/06 wangyl</br>
    /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
    /// <br>              Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
    /// </remarks>
    public partial class MitsubishiOrderProcAcs
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        private bool _isDataCanged = false;
        private string _enterpriseCode = LoginInfoAcquisition.EnterpriseCode;
        private string _loginSectionCode = LoginInfoAcquisition.Employee.BelongSectionCode;   // ADD 2010/12/31

        //アクセスクラス
        private static MitsubishiOrderProcAcs _supplierAcs;
        private UoeOrderInfoAcs _uoeOrderInfoAcs;

        //データーテーブル
        private MitsubishiOrderProcDataSet _dataSet;
        private MitsubishiOrderProcDataSet.OrderExpansionDataTable _orderDataTable;

        //従業員マスタ
        private Dictionary<string, EmployeeWork> _employeeWork;
        private IEmployeeDB _iEmployeeDB;                               // 従業員情報 アクセスクラス

        //ＵＯＥ発注データ検索＜アクセスクラス呼び出し＞
        List<UOEOrderDtlWork> _uOEOrderDtlWorkList = null;
        List<StockDetailWork> _stockDetailWorkList = null;

        //private int setCount = 0; // DEL 2010/05/07

        // ファイル（ストリーム）
        private FileStream _uoeFileStream = null;
        # endregion

        #region ASATOUOEXMLEditOrder
        /// <summary>
        /// 三菱WebUOE用発注連携ファイル(発注)作成
        /// </summary>
        private class ASATOUOTXMLEditOrder
        {
            #region const member
            private const string ROOT = "CAPS_INFO";            // 開始
            private const string ELEMENT_VIN = "VIN";            // ｼｬｼNo.
            private const string ELEMENT_SPC_MODEL = "SPC_MODEL";            // 型式指定番号(運型)
            private const string ELEMENT_MODEL = "MODEL";            // 型式
            private const string ELEMENT_CLAS = "CLAS";            // 類別
            private const string ELEMENT_OPC = "OPC";            // 艤装
            private const string ELEMENT_EXT = "EXT";            // 外装
            private const string ELEMENT_INT = "INT";            // 内装
            private const string ELEMENT_PD1 = "PD1";            // 車輌生産時期範囲（から）
            private const string ELEMENT_PD2 = "PD2";            // 車輌生産時期範囲（まで）
            private const string ELEMENT_TODAY = "TODAY";            // 作成年月日
            private const string ELEMENT_TIME = "TIME";            // 作成時分
            private const string ELEMENT_PGM_VER = "PGM_VER";            // ﾌﾟﾛｸﾞﾗﾑﾊﾞｰｼﾞｮﾝ
            private const string ELEMENT_TOTAL_PRICE = "TOTAL_PRICE";            // 合計金額
            private const string ELEMENT_NUMBER_OF_PARTS = "NUMBER_OF_PARTS";            // 部品総数

            private const string ELEMENT_PARTS_INFO = "PARTS_INFO";            // 部品情報
            private const string ELEMENT_LINE_NO = "LINE_NO";            // ﾗｲﾝNo.
            private const string ELEMENT_PNC = "PNC";            // 品名ｺｰﾄﾞ
            private const string ELEMENT_PART_QTY = "PART_QTY";            // 数量
            private const string ELEMENT_PART_NO = "PART_NO";            // 部品番号
            private const string ELEMENT_PART_NAME = "PART_NAME";            // 部品名称
            private const string ELEMENT_QTY = "QTY";            // 個数
            private const string ELEMENT_PART_UNIT_PRICE = "PART_UNIT_PRICE";            // 単価
            private const string ELEMENT_PART_SPEC = "PART_SPEC";            // 固有情報（編集）
            private const string ELEMENT_PART_REMARK = "PART_REMARK";            // 固有情報（備考）
            private const string ELEMENT_PART_COLOR = "PART_COLOR";            // 固有情報（色）
            private const string ELEMENT_RPN = "RPN";            // 代替部番
            private const string ELEMENT_RPN_PRICE = "RPN_PRICE";            // 代)単価
            private const string ELEMENT_RPN_SPEC = "RPN_SPEC";            // 代)固有情報（編集）
            private const string ELEMENT_RPN_REMARK = "RPN_REMARK";            // 代)固有情報（備考）
            private const string ELEMENT_RPN_COLOR = "RPN_COLOR";            // 代)固有情報（色）

            // 最大明細数
            private const int ctDetailLen = 999;
            #endregion

            # region Private Members
            // 
            private XmlWriter xmlWriter;
            //変数
            private Int32 _ln = 0;
            private byte[] remark = new byte[10];
            # endregion

            # region Constructors
            /// <summary>
            /// コンストラクタ
            /// <param name="fileStream">ファイル（ストリーム）</param>
            /// </summary>
            public ASATOUOTXMLEditOrder(FileStream fileStream)
            {
                // Settings
                XmlWriterSettings xmlSetting = new XmlWriterSettings();
                xmlSetting.Encoding = Encoding.GetEncoding(932); // Shift-JS
                xmlSetting.Indent = true;
                xmlSetting.IndentChars = ("  ");
                xmlSetting.OmitXmlDeclaration = false;

                xmlWriter = XmlWriter.Create(fileStream, xmlSetting);
            }

            # endregion

            # region データ編集処理
            /// <summary>
            /// データ編集処理
            /// </summary>
            /// <param name="work">ワーク</param>
            public void NodeWrite(UOEOrderDtlWork work)
            {
                // コメント = "@" + システム区分（1桁）+連携No.(　連携No.=UI処理で選択したUOE発注ﾃﾞｰﾀのｵﾝﾗｲﾝ番号（OnlineNoRF）の下8桁0詰め)
                UoeCommonFnc.MemCopy(ref remark, work.UoeRemark2, remark.Length);
                // ヘッダー部作成
                if (_ln == 0)
                {
                    xmlWriter.WriteStartDocument();
                    // ROOT
                    xmlWriter.WriteStartElement(ROOT);            // 開始

                    # region <ヘッダー部>
                    xmlWriter.WriteStartElement(ELEMENT_VIN);            // ｼｬｼNo.
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_SPC_MODEL);            // 型式指定番号(運型)
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteElementString(ELEMENT_MODEL, System.Text.Encoding.Default.GetString(remark));            // 型式
                    xmlWriter.WriteStartElement(ELEMENT_CLAS);            // 類別
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_OPC);            // 艤装
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_EXT);            // 外装
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_INT);            // 内装
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PD1);            // 車輌生産時期範囲（から）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PD2);            // 車輌生産時期範囲（まで）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TODAY);            // 作成年月日
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TIME);            // 作成時分
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PGM_VER);            // ﾌﾟﾛｸﾞﾗﾑﾊﾞｰｼﾞｮﾝ
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TOTAL_PRICE);            // 合計金額
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_NUMBER_OF_PARTS);            // 部品総数
                    xmlWriter.WriteFullEndElement();
                    # endregion
                }

                # region <名細部>
                if (_ln < ctDetailLen)
                {
                    xmlWriter.WriteStartElement(ELEMENT_PARTS_INFO);            // 部品情報(開始)
                    xmlWriter.WriteElementString(ELEMENT_LINE_NO, String.Format("{0:D3}", work.OnlineRowNo));            // ﾗｲﾝNo.
                    xmlWriter.WriteStartElement(ELEMENT_PNC);            // 品名ｺｰﾄﾞ
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteElementString(ELEMENT_PART_QTY, Convert.ToString(work.AcceptAnOrderCnt));            // 数量
                    xmlWriter.WriteElementString(ELEMENT_PART_NO, work.GoodsNoNoneHyphen);            // 部品番号
                    xmlWriter.WriteStartElement(ELEMENT_PART_NAME);            // 部品名称
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_QTY);            // 個数
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_UNIT_PRICE);            // 単価
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_SPEC);            // 固有情報（編集）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_REMARK);            // 固有情報（備考）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_COLOR);            // 固有情報（色）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN);            // 代替部番
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_PRICE);            // 代)単価
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_SPEC);            // 代)固有情報（編集）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_REMARK);            // 代)固有情報（備考）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_COLOR);            // 代)固有情報（色）
                    xmlWriter.WriteFullEndElement();

                    xmlWriter.WriteFullEndElement();                                    // 部品情報(終了)

                    _ln++;
                }
                # endregion
            }

            # region <ファイル終了>
            /// <summary>
            /// ファイル終了処理
            /// </summary>
            public void FileEnd()
            {
                // Write The Close Tag for the Root element
                xmlWriter.WriteFullEndElement();
                xmlWriter.WriteEndDocument();

                xmlWriter.Flush();
                xmlWriter.Close();
            }
            # endregion
            # endregion
        }
        #endregion

        // --------ADD 2010/12/31--------->>>>>
        #region AutoASATOUOEXMLEditOrder
        /// <summary>
        /// 三菱WebUOE用発注連携ファイル(発注)作成(自動)
        /// </summary>
        private class AutoASATOUOEXMLEditOrder
        {
            #region const member
            private const string ROOT = "CAPS_INFO";            // 開始
            private const string ELEMENT_VIN = "VIN";            // ｼｬｼNo.
            private const string ELEMENT_SPC_MODEL = "SPC_MODEL";            // 型式指定番号(運型)
            private const string ELEMENT_MODEL = "MODEL";            // 型式
            private const string ELEMENT_CLAS = "CLAS";            // 類別
            private const string ELEMENT_OPC = "OPC";            // 艤装
            private const string ELEMENT_EXT = "EXT";            // 外装
            private const string ELEMENT_INT = "INT";            // 内装
            private const string ELEMENT_PD1 = "PD1";            // 車輌生産時期範囲（から）
            private const string ELEMENT_PD2 = "PD2";            // 車輌生産時期範囲（まで）
            private const string ELEMENT_TODAY = "TODAY";            // 作成年月日
            private const string ELEMENT_TIME = "TIME";            // 作成時分
            private const string ELEMENT_PGM_VER = "PGM_VER";            // ﾌﾟﾛｸﾞﾗﾑﾊﾞｰｼﾞｮﾝ
            private const string ELEMENT_TOTAL_PRICE = "TOTAL_PRICE";            // 合計金額
            private const string ELEMENT_NUMBER_OF_PARTS = "NUMBER_OF_PARTS";            // 部品総数

            private const string ELEMENT_PARTS_INFO = "PARTS_INFO";            // 部品情報
            private const string ELEMENT_LINE_NO = "LINE_NO";            // ﾗｲﾝNo.
            private const string ELEMENT_PNC = "PNC";            // 品名ｺｰﾄﾞ
            private const string ELEMENT_PART_QTY = "PART_QTY";            // 数量
            private const string ELEMENT_PART_NO = "PART_NO";            // 部品番号
            private const string ELEMENT_PART_NAME = "PART_NAME";            // 部品名称
            private const string ELEMENT_QTY = "QTY";            // 個数
            private const string ELEMENT_PART_UNIT_PRICE = "PART_UNIT_PRICE";            // 単価
            private const string ELEMENT_PART_SPEC = "PART_SPEC";            // 固有情報（編集）
            private const string ELEMENT_PART_REMARK = "PART_REMARK";            // 固有情報（備考）
            private const string ELEMENT_PART_COLOR = "PART_COLOR";            // 固有情報（色）
            private const string ELEMENT_RPN = "RPN";            // 代替部番
            private const string ELEMENT_RPN_PRICE = "RPN_PRICE";            // 代)単価
            private const string ELEMENT_RPN_SPEC = "RPN_SPEC";            // 代)固有情報（編集）
            private const string ELEMENT_RPN_REMARK = "RPN_REMARK";            // 代)固有情報（備考）
            private const string ELEMENT_RPN_COLOR = "RPN_COLOR";            // 代)固有情報（色）

            // 最大明細数
            private const int ctDetailLen = 999;
            #endregion

            # region Private Members
            // 
            private XmlWriter xmlWriter;
            //変数
            private Int32 _ln = 0;
            private byte[] remark;
            # endregion

            # region Constructors
            /// <summary>
            /// コンストラクタ
            /// <param name="fileStream">ファイル（ストリーム）</param>
            /// </summary>
            public AutoASATOUOEXMLEditOrder(FileStream fileStream)
            {
                // Settings
                XmlWriterSettings xmlSetting = new XmlWriterSettings();
                xmlSetting.Encoding = Encoding.GetEncoding(932); // Shift-JS
                xmlSetting.Indent = true;
                xmlSetting.IndentChars = ("  ");
                xmlSetting.OmitXmlDeclaration = false;

                xmlWriter = XmlWriter.Create(fileStream, xmlSetting);
            }

            # endregion

            # region データ編集処理
            /// <summary>
            /// データ編集処理
            /// </summary>
            /// <param name="work">ワーク</param>
            public void NodeWrite(UOEOrderDtlWork work)
            {
                if (!work.UoeRemark1.Trim().Equals(string.Empty))
                {
                    remark = new byte[work.UoeRemark1.Length];
                    // コメント = "@" + システム区分（1桁）+連携No.(　連携No.=UI処理で選択したUOE発注ﾃﾞｰﾀのｵﾝﾗｲﾝ番号（OnlineNoRF）の下8桁0詰め)
                    UoeCommonFnc.MemCopy(ref remark, work.UoeRemark1, remark.Length);
                }
                else
                {
                    //なし。
                }
                // ヘッダー部作成
                if (_ln == 0)
                {
                    xmlWriter.WriteStartDocument();
                    // ROOT
                    xmlWriter.WriteStartElement(ROOT);            // 開始

                    # region <ヘッダー部>
                    xmlWriter.WriteStartElement(ELEMENT_VIN);            // ｼｬｼNo.
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_SPC_MODEL);            // 型式指定番号(運型)
                    xmlWriter.WriteFullEndElement();
                    if (!work.UoeRemark1.Trim().Equals(string.Empty))
                    {
                        xmlWriter.WriteElementString(ELEMENT_MODEL, System.Text.Encoding.Default.GetString(remark));            // 型式
                    }
                    else
                    {
                        xmlWriter.WriteStartElement(ELEMENT_MODEL);            // 型式
                        xmlWriter.WriteFullEndElement();
                    }
                    xmlWriter.WriteStartElement(ELEMENT_CLAS);            // 類別
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_OPC);            // 艤装
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_EXT);            // 外装
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_INT);            // 内装
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PD1);            // 車輌生産時期範囲（から）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PD2);            // 車輌生産時期範囲（まで）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TODAY);            // 作成年月日
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TIME);            // 作成時分
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PGM_VER);            // ﾌﾟﾛｸﾞﾗﾑﾊﾞｰｼﾞｮﾝ
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_TOTAL_PRICE);            // 合計金額
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_NUMBER_OF_PARTS);            // 部品総数
                    xmlWriter.WriteFullEndElement();
                    # endregion
                }

                # region <名細部>
                if (_ln < ctDetailLen)
                {
                    xmlWriter.WriteStartElement(ELEMENT_PARTS_INFO);            // 部品情報(開始)
                    xmlWriter.WriteElementString(ELEMENT_LINE_NO, String.Format("{0:D3}", work.OnlineRowNo));            // ﾗｲﾝNo.
                    xmlWriter.WriteStartElement(ELEMENT_PNC);            // 品名ｺｰﾄﾞ
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteElementString(ELEMENT_PART_QTY, Convert.ToString(work.AcceptAnOrderCnt));            // 数量
                    xmlWriter.WriteElementString(ELEMENT_PART_NO, work.GoodsNoNoneHyphen);            // 部品番号
                    xmlWriter.WriteStartElement(ELEMENT_PART_NAME);            // 部品名称
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_QTY);            // 個数
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_UNIT_PRICE);            // 単価
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_SPEC);            // 固有情報（編集）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_REMARK);            // 固有情報（備考）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_PART_COLOR);            // 固有情報（色）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN);            // 代替部番
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_PRICE);            // 代)単価
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_SPEC);            // 代)固有情報（編集）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_REMARK);            // 代)固有情報（備考）
                    xmlWriter.WriteFullEndElement();
                    xmlWriter.WriteStartElement(ELEMENT_RPN_COLOR);            // 代)固有情報（色）
                    xmlWriter.WriteFullEndElement();

                    xmlWriter.WriteFullEndElement();                                    // 部品情報(終了)

                    _ln++;
                }
                # endregion
            }

            # region <ファイル終了>
            /// <summary>
            /// ファイル終了処理
            /// </summary>
            public void FileEnd()
            {
                // Write The Close Tag for the Root element
                xmlWriter.WriteFullEndElement();
                xmlWriter.WriteEndDocument();

                xmlWriter.Flush();
                xmlWriter.Close();
            }
            # endregion
            # endregion
        }
        #endregion

        #region ASATOUOESubTextEditOrder
        ///// <summary>
        ///// ＵＯＥ送信電文作成＜発注＞（トヨタＰＤ４）
        ///// </summary>
        /// <summary>
        /// 日産Web-UOEシステム連携ファイル(発注)作成
        /// </summary>
        private class ASATOUOESubTextEditOrder
        {
            #region Private Members
            //サブ発注電文
            private byte[] subRemark = new byte[15];		/*      	 サブコメント         */
            private byte[] subDeliGoodsDiv = new byte[1];		/*           サブ納品区分            */
            private byte[][] subBoCode = null;		/*      	 サブBO区分         */
            private int boCodeLength;

            #endregion

            # region Constructors
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public ASATOUOESubTextEditOrder(int boCodeLen)
            {
                subBoCode = new byte[boCodeLen][];
                boCodeLength = boCodeLen;
                for (int i = 0; i < boCodeLength; i++)
                {
                    subBoCode[i] = new byte[1];	// 部品番号
                }
                Clear();
            }
            # endregion

            # region Public Methods
            # region データ初期化処理
            /// <summary>
            /// データ初期化処理
            /// </summary>
            public void Clear()
            {
                // 明細部
                UoeCommonFnc.MemSet(ref subRemark, 0x20, subRemark.Length);		// コメント
                UoeCommonFnc.MemSet(ref subDeliGoodsDiv, 0x20, subDeliGoodsDiv.Length);		// 納品区分
                for (int i = 0; i < boCodeLength; i++)
                {
                    UoeCommonFnc.MemSet(ref subBoCode[i], 0x20, subBoCode[i].Length);	// 部品番号
                }
            }
            # endregion

            # region サブデータ編集処理
            /// <summary>
            /// サブデータ編集処理
            /// </summary>
            /// <param name="work">ワーク</param>
            /// <param name="page">ワーク</param>
            public void Telegram(UOEOrderDtlWork work, int subBoCodeIndex)
            {
                //ＴＴＣ部 業務ヘッダー部 ヘッダー部作成
                if (subBoCodeIndex == 0)
                {
                    //＜ヘッダー部＞
                    // コメント = "@" + システム区分（1桁）+連携No.(　連携No.=UI処理で選択したUOE発注ﾃﾞｰﾀのｵﾝﾗｲﾝ番号（OnlineNoRF）の下8桁0詰め)
                    UoeCommonFnc.MemCopy(ref subRemark, work.UoeRemark2, subRemark.Length);
                    // 納品区分
                    UoeCommonFnc.MemCopy(ref subDeliGoodsDiv, work.UOEDeliGoodsDiv, subDeliGoodsDiv.Length);

                    //＜明細部＞
                    // BO区分
                    UoeCommonFnc.MemCopy(ref subBoCode[subBoCodeIndex], work.BoCode, subBoCode[subBoCodeIndex].Length);
                }

                if (subBoCodeIndex > 0)
                {
                    //＜明細部＞
                    // BO区分
                    UoeCommonFnc.MemCopy(ref subBoCode[subBoCodeIndex], work.BoCode, subBoCode[subBoCodeIndex].Length);
                }

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
                ms.Write(subRemark, 0, subRemark.Length);			// コメント
                ms.Write(subDeliGoodsDiv, 0, subDeliGoodsDiv.Length);	// 納品区分
                //明細部
                for (int i = 0; i < boCodeLength; i++)
                {
                    ms.Write(subBoCode[i], 0, subBoCode[i].Length);	// BO区分
                }

                byte[] toByteArray = ms.ToArray();
                ms.Close();
                return (toByteArray);
            }
            # endregion

            # endregion
        }
        #endregion
        // --------ADD 2010/12/31---------<<<<<

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructor
        /// <summary>
        /// デフォルトコンストラクタ（Singletonデザインパターンを採用している為、privateとする）
        /// </summary>
        /// <remarks>
        /// <br>Note       : デフォルトコンストラクタを行います。</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        private MitsubishiOrderProcAcs()
        {
            this.OrderDataTable.Rows.Clear();

            this._uoeOrderInfoAcs = UoeOrderInfoAcs.GetInstance();

            this._iEmployeeDB = (IEmployeeDB)MediationEmployeeDB.GetEmployeeDB();
        }

        /// <summary>
        /// ＵＯＥ発注処理アクセスクラス インスタンス取得処理
        /// </summary>
        /// <returns>ＵＯＥ発注処理アクセスクラス インスタンス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注処理アクセスクラス インスタンス取得を行います。</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public static MitsubishiOrderProcAcs GetInstance()
        {
            if (_supplierAcs == null)
            {
                _supplierAcs = new MitsubishiOrderProcAcs();
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

        #region ファイル（ストリーム）
        /// <summary>UOEfileStream</summary>
        private FileStream UoeFileStream
        {
            get
            {
                return this._uoeFileStream;
            }
            set
            {
                this._uoeFileStream = value;
            }
        }
        #endregion

        # region 従業員マスタキャッシュ処理
        /// <summary>
        /// 従業員マスタキャッシュ処理
        /// </summary>
        /// <remarks>
        /// <br>Note       : 従業員マスタキャッシュ処理を行います。</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
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
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
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
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        private MitsubishiOrderProcDataSet DataSet
        {
            get
            {
                if (_dataSet == null)
                {
                    _dataSet = new MitsubishiOrderProcDataSet();
                }
                return _dataSet;
            }
        }
        /// <summary>
        /// 有効入力行存在判定
        /// </summary>
        /// <returns>行存在チェック結果（True : 行あり / False : 行なし）</returns>
        /// <remarks>
        /// <br>Note       : 有効入力行存在判定を行います。</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public bool StockRowExists()
        {
            if (this.OrderDataTable.Rows.Count > 0)
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
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public MitsubishiOrderProcDataSet.OrderExpansionDataTable OrderDataTable
        {
            get
            {
                if (_orderDataTable == null)
                {
                    _orderDataTable = this.DataSet.OrderExpansion;
                }
                return _orderDataTable;
            }
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
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public void SelectedRow(int _uniqueID, bool selected)
        {
            // ------------------------------------------------------------//
            // Find メソッドを使う但し、Viewのソート順を変更したくない為、 //
            // DataTableに更新をかける。                                   //
            // ------------------------------------------------------------//
            DataRow _row = this.OrderDataTable.Rows.Find(_uniqueID);

            // 一致する行が存在する！
            if (_row != null)
            {
                _row.BeginEdit();
                _row[this.OrderDataTable.InpSelectColumn.ColumnName] = selected;
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
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        private UOESendProcCndtnPara ToUOESendProcCndtnParaFromInpDisplay(MitsubishiInpDisplay inpDisplay)
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

        // --- ADD 2010/12/31 --------- >>>>>
        #region ヘッダー部入力値の保存処理
        /// <summary>
        /// ヘッダー部入力値の保存処理
        /// </summary>
        /// <param name="inpHedDisplay"> ヘッダー部入力クラス</param>
        /// <remarks>
        /// <br>Note       : ヘッダー部入力値の保存処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        public void UpdtHedaerItem(MitsubishiInpHedDisplay inpHedDisplay)
        {
            DataView orderDataView = new DataView(this.OrderDataTable);

            string rowFilterString = "";

            //オンライン番号
            rowFilterString = String.Format("{0} = {1}",
                                                    this.OrderDataTable.OnlineNoColumn.ColumnName, inpHedDisplay.OnlineNo);

            orderDataView.RowFilter = rowFilterString;

            for (int ix = 0; ix < orderDataView.Count; ix++)
            {
                MitsubishiOrderProcDataSet.OrderExpansionRow dataRow = (MitsubishiOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                
                dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName] = inpHedDisplay.UoeRemark1;                    // ＵＯＥリマーク１

                dataRow[this.OrderDataTable.UOEDeliGoodsDivColumn.ColumnName] = inpHedDisplay.UOEDeliGoodsDiv;                // 納品区分
                dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName] = inpHedDisplay.DeliveredGoodsDivNm;                // 納品区分名称
                
            }

        }
        # endregion
        // --- ADD 2010/12/31 --------- <<<<<

        # region ■ ＵＯＥ発注データ 検索処理 ■
        /// <summary>
        /// ＵＯＥ発注データ 検索処理
        /// </summary>
        /// <param name="inpDisplay">検索条件クラス</param>
        /// <param name="message">メッセージ</param>
        /// <returns>ステータス</returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ 検索処理を行います。</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// <br>Update Note : 2013/02/06 wangyl</br>
        /// <br>管理番号    : 10900690-00 2013/03/13配信分の</br>
        /// <br>              Redmine#34578の対応 倉庫毎に倉庫毎に発注を行った際、倉庫毎にまとまらない（表示順位）倉庫単位にリマークを直したい </br>
        /// </remarks>
        public int SearchDB(MitsubishiInpDisplay inpDisplay, out string message)
        {
            int status = (int)ConstantManagement.MethodResult.ctFNC_NORMAL;
            message = "";

            try
            {   //グリッド用テーブルのクリア
                this.OrderDataTable.Rows.Clear();

                //ＵＯＥ発注データ検索＜アクセスクラス呼び出し＞
                _uOEOrderDtlWorkList = null;
                _stockDetailWorkList = null;

                UOESendProcCndtnPara para = ToUOESendProcCndtnParaFromInpDisplay(inpDisplay);

                status = _uoeOrderInfoAcs.Search(para, out _uOEOrderDtlWorkList, out _stockDetailWorkList, out message);

                if (status != (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                {
                    if (status == (int)ConstantManagement.DB_Status.ctDB_NOT_FOUND)
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_NO_RETURN;
                        return (status);
                    }
                    else
                    {
                        status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
                        return (status);
                    }
                }

                int index = 1;

                //-----------------------------------------------------------
                // ＵＯＥ発注データの格納
                //-----------------------------------------------------------
                foreach (UOEOrderDtlWork uOEOrderDtlWork in _uOEOrderDtlWorkList)
                {
                    MitsubishiOrderProcDataSet.OrderExpansionRow row = this.OrderDataTable.NewOrderExpansionRow();
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
                    row.UOEDeliGoodsDivNm = uOEOrderDtlWork.DeliveredGoodsDivNm; // ADD 2010/12/31
                    row.BoCode = uOEOrderDtlWork.BoCode;
                    row.WarehouseName = uOEOrderDtlWork.WarehouseName;// ADD wangyl 2013/02/06 Redmine#34578
                    this.OrderDataTable.AddOrderExpansionRow(row);
                }

                IsDataChanged = true;

            }
            catch (Exception ex)
            {
                message = ex.Message;
                status = (int)ConstantManagement.MethodResult.ctFNC_ERROR;
            }

            return status;
        }

        # endregion

        #region ＵＯＥ発注データ削除件数取得
        /// <summary>
        /// ＵＯＥ発注データ削除件数取得
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ削除件数取得を行います。</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public int GetDeleteCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
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
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public int GetNoSelectCount()
        {
            int count = 0;

            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, false);
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
        /*------------------------- DEL 2010/05/07 -------------------------------------
        /// <summary>
        /// ＵＯＥ発注データ発注セット数の算出
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// <br>Note       : ＵＯＥ発注データ発注セット数の算出を行います。</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public int GetBlocCount()
        {
            int count = 0;
            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                // 送信明細数
                int detailIndex = 0;
                // 前回ｵﾝﾗｲﾝ番号
                int bfOnlineNo = 0;
                // 最大8明細
                int maxDetailCount = 8;
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    MitsubishiOrderProcDataSet.OrderExpansionRow dataRow = (MitsubishiOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);

                    Int32 onlineNo = (Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName];

                    if (ix == 0)
                    {
                        count++;
                        bfOnlineNo = onlineNo;
                        detailIndex = 1;
                    }
                    // 同じｵﾝﾗｲﾝ番号ではない場合
                    else if (bfOnlineNo != onlineNo)
                    {
                        count++;
                        bfOnlineNo = onlineNo;
                        detailIndex = 1;
                    }
                    // 同じｵﾝﾗｲﾝ番号場合
                    else if (bfOnlineNo == onlineNo)
                    {
                        detailIndex++;
                        if (detailIndex > maxDetailCount)
                        {
                            count++;
                            detailIndex = 1;
                        }
                    }
                }

            }
            catch (Exception)
            {
                count = 0;
            }
            this.setCount = count;
            return count;
        }

        ------------------------- DEL 2010/05/07 -------------------------------------*/
        # endregion

        #region ＵＯＥ発注データ更新処理
        /// <summary>
        /// データ保存処理
        /// </summary>
        /// <param name="cashRegisterNo">端末番号</param>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <param name="stockDetailWorkList">仕入明細データ</param>
        /// <param name="uOEOrderDtlWorkDelList">UOE発注削除データ</param>
        /// <param name="stockDetailWorkDelList">仕入明細削除データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ保存処理を行います。</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public int WriteDB(int cashRegisterNo, int systemDiv, out string message,
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
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ保存処理を行います。</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public int WriteFile(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                ASATOUOTXMLEditOrder aSATOUOTXMLEditOrder = new ASATOUOTXMLEditOrder(this.UoeFileStream);

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];

                    aSATOUOTXMLEditOrder.NodeWrite(work);

                }

                aSATOUOTXMLEditOrder.FileEnd();

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.CloseFileStream();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // ----- ADD 2010/05/18 ---------------->>>>>
            finally
            {
                this.CloseFileStream();
            }
            // ----- ADD 2010/05/18 ----------------<<<<<
            return status;
        }

        // --------ADD 2010/12/31--------->>>>>
        /// <summary>
        /// データ保存処理
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : データ保存処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        public int WriteAutoFile(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                AutoASATOUOEXMLEditOrder aSATOUOTXMLEditOrder = new AutoASATOUOEXMLEditOrder(this.UoeFileStream);

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];

                    aSATOUOTXMLEditOrder.NodeWrite(work);
                }

                aSATOUOTXMLEditOrder.FileEnd();

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.CloseFileStream();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            finally
            {
                this.CloseFileStream();
            }
            return status;
        }

        /// <summary>
        /// サブデータ保存処理
        /// </summary>
        /// <param name="systemDiv">システム区分</param>
        /// <param name="message">Message</param>
        /// <param name="uOEOrderDtlWorkList">UOE発注データ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : サブデータ保存処理を行います。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/12/31</br>
        /// <br>UpdateNote : 2011/01/13 曹文傑 UOE自動化改良redmine:#18531</br>
        /// </remarks>
        public int WriteSubText(int systemDiv, out string message,
               List<UOEOrderDtlWork> uOEOrderDtlWorkList)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            message = "";
            this.UoeFileStream.SetLength(0);
            try
            {
                ASATOUOESubTextEditOrder aSATOUOESubTextEditOrder = new ASATOUOESubTextEditOrder(uOEOrderDtlWorkList.Count);
                byte[] tempbyte = null;

                for (int i = 0; i < uOEOrderDtlWorkList.Count; i++)
                {
                    UOEOrderDtlWork work = (UOEOrderDtlWork)uOEOrderDtlWorkList[i];

                    //送信電文(JIS)
                    aSATOUOESubTextEditOrder.Telegram(work, i);
                }

                tempbyte = aSATOUOESubTextEditOrder.ToByteArray();
                this.UoeFileStream.Write(tempbyte, 0, tempbyte.Length);

                //電文明細クラス全てのクリア
                aSATOUOESubTextEditOrder.Clear();

                this.UoeFileStream.Flush();
            }
            catch (Exception ex)
            {
                message = ex.Message;
                this.CloseFileStream();
                return (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }
            // ----- ADD 2011/01/13 ---------------->>>>>
            finally
            {
                this.CloseFileStream();
            }
            // ----- ADD 2011/01/13 ----------------<<<<<
            return status;
        }
        // --------ADD 2010/12/31---------<<<<<

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
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// <br>UpdateNote : 2010/12/31 曹文傑 UOE自動化改良</br>
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
            try
            {
                DataView orderDataView = new DataView(this.OrderDataTable);
                orderDataView.RowFilter = String.Format("{0} = {1}", this.OrderDataTable.InpSelectColumn.ColumnName, true);
                for (int ix = 0; ix < orderDataView.Count; ix++)
                {
                    string key;
                    List<UOEOrderDtlWork> uOEresultList;
                    List<StockDetailWork> stockresultList;
                    UOEOrderDtlWork uOEOrderDtlWork = new UOEOrderDtlWork();

                    MitsubishiOrderProcDataSet.OrderExpansionRow dataRow = (MitsubishiOrderProcDataSet.OrderExpansionRow)(orderDataView[ix].Row);
                    uOEOrderDtlWork.EmployeeCode = _enterpriseCode;
                    uOEOrderDtlWork.OnlineNo = (Int32)dataRow[this.OrderDataTable.OnlineNoColumn.ColumnName];
                    uOEOrderDtlWork.OnlineRowNo = (Int32)dataRow[this.OrderDataTable.OnlineRowNoColumn.ColumnName];
                    uOEOrderDtlWork.UOEKind = (Int32)dataRow[this.OrderDataTable.UOEKindColumn.ColumnName];
                    uOEOrderDtlWork.CommonSeqNo = (Int64)dataRow[this.OrderDataTable.CommonSeqNoColumn.ColumnName];
                    uOEOrderDtlWork.SupplierFormal = (Int32)dataRow[this.OrderDataTable.SupplierFormalColumn.ColumnName];
                    uOEOrderDtlWork.StockSlipDtlNum = (Int64)dataRow[this.OrderDataTable.StockSlipDtlNumColumn.ColumnName];
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
                              || 0 != double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString())))
                        {
                            // 受信日付
                            uOEOrderDtlWorktemp.ReceiveDate = System.DateTime.Now;
                            // 送信フラグ
                            uOEOrderDtlWorktemp.DataSendCode = 1;
                            // 復旧フラグ
                            uOEOrderDtlWorktemp.DataRecoverDiv = 0;
                            // 送信端末番号
                            uOEOrderDtlWorktemp.SendTerminalNo = cashRegisterNo;
                            // -----ADD 2010/12/31---------->>>>>
                            // UOEリマーク1
                            uOEOrderDtlWorktemp.UoeRemark1 = dataRow[this.OrderDataTable.UoeRemark1Column.ColumnName].ToString();
                            // 納品区分
                            uOEOrderDtlWorktemp.UOEDeliGoodsDiv = dataRow[this.OrderDataTable.UOEDeliGoodsDivColumn.ColumnName].ToString();
                            // 納品区分名称
                            uOEOrderDtlWorktemp.DeliveredGoodsDivNm = dataRow[this.OrderDataTable.UOEDeliGoodsDivNmColumn.ColumnName].ToString();
                            // BO区分
                            uOEOrderDtlWorktemp.BoCode = dataRow[this.OrderDataTable.BoCodeColumn.ColumnName].ToString();
                            // -----ADD 2010/12/31----------<<<<<
                            // UOEリマーク２
                            uOEOrderDtlWorktemp.UoeRemark2 = "@" + uOEOrderDtlWorktemp.SystemDivCd.ToString() + uOEOrderDtlWorktemp.OnlineNo.ToString("000000000").Substring(1, 8);
                            // 受注数量
                            uOEOrderDtlWorktemp.AcceptAnOrderCnt = double.Parse(dataRow[this.OrderDataTable.AcceptAnOrderCntColumn.ColumnName].ToString());
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
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
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
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
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
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        private string MakeStockKey(string enterpriseCode, int supplierFormal, long stockSlipDtlNum)
        {
            // 明細・行Primary Key
            string key = enterpriseCode.ToString() + supplierFormal.ToString() + stockSlipDtlNum.ToString();
            return key;
        }


        #endregion Key作成

        /// <summary>
        /// ファイルがオープン中チェック
        /// </summary>
        /// <param name="toyotaFlod">フォルダ</param>
        /// <returns>BOOL</returns>
        /// <remarks>
        /// <br>Note       : UOE発注先マスタ収得を行います。</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public bool GetCanWriteFlg(string toyotaFlod)
        {
            string mess = string.Empty;
            this.UoeFileStream = null;
            try
            {
                this.UoeFileStream = new FileStream(toyotaFlod, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.Read);
                return true;
            }
            catch (Exception ex)
            {
                mess = ex.Message;
                this.CloseFileStream();
                return false;
            }
        }

        /// <summary>
        /// ファイル（ストリーム）をクローズ
        /// </summary>
        /// <remarks>
        /// <br>Note       :  ファイル（ストリーム）をクローズする。</br>
        /// <br>Programmer : gaoyh</br>
        /// <br>Date       : 2010/04/20</br>
        /// </remarks>
        public void CloseFileStream()
        {
            if (UoeFileStream != null)
            {
                UoeFileStream.Close();
            }
        }

        // --------ADD 2010/12/31--------->>>>>
        #region 自動更新処理
        /// <summary>
        /// 自動更新処理
        /// </summary>
        /// <param name="dir">発注送信データファイル名称</param>
        /// <param name="subDir">発注送信データサブファイル名称</param>
        /// <param name="uoeSupplier">UOE発注先マスタ</param>
        /// <param name="uOEConnectInfo">UOE接続先情報マスタ</param>
        /// <param name="errMess">エラーメッセージ</param>
        /// <returns>STATUS</returns>
        /// <remarks>
        /// <br>Note       : 自動更新を行いします。</br>
        /// <br>Programmer : 曹文傑</br>
        /// <br>Date       : 2010/12/31</br>
        /// </remarks>
        public int AutoUpdateProc(string dir, string subDir, UOESupplier uoeSupplier, UOEConnectInfo uOEConnectInfo, out string errMess)
        {
            int status = (int)ConstantManagement.DB_Status.ctDB_NORMAL;
            string subMess = string.Empty;
            errMess = string.Empty;
            int count = 0;
            // インポート中画面部品のインスタンスを作成
            Broadleaf.Windows.Forms.SFCMN00299CA form = new Broadleaf.Windows.Forms.SFCMN00299CA();
            try
            {
                count = this.GetDeleteCount();

                // 表示文字を設定
                form.Title = "更新処理中";
                form.Message = "更新処理中です。";
                // ダイアログ表示
                form.Show();

                // 自動化プログラム呼び出し
                //UOE接続先情報マスタある場合
                if (uOEConnectInfo != null)
                {
                    status = xPMPU9011(3, dir, uOEConnectInfo.SocketCommPort, uOEConnectInfo.ReceiveComputerNm, uOEConnectInfo.ClientTimeOut, subDir, count, ref errMess);
                }
                else
                {
                    status = xPMPU9011(3, dir, 0, string.Empty, 0, subDir, count, ref errMess);
                }

                // ダイアログを閉じる
                form.Close();

                switch ((Int16)status)
                {
                    case 0:
                        {
                            errMess = "正常終了。";
                            #region 回答テキストの取込処理
                            UOEOrderDtlMitsubishiAcs uOEOrderDtlMitsubishiAcs = new UOEOrderDtlMitsubishiAcs();

                            AnswerDateMitsubishiPara answerDateMitsubishiPara = new AnswerDateMitsubishiPara();
                            answerDateMitsubishiPara.EnterpriseCode = this._enterpriseCode;
                            answerDateMitsubishiPara.SectionCode = this._loginSectionCode;
                            answerDateMitsubishiPara.UOESupplierCd = uoeSupplier.UOESupplierCd;
                            answerDateMitsubishiPara.AnswerSaveFolder = uoeSupplier.AnswerSaveFolder;

                            // 回答情報の取得を行います
                            status = uOEOrderDtlMitsubishiAcs.DoSearch(answerDateMitsubishiPara, out errMess);

                            if (status == (int)ConstantManagement.DB_Status.ctDB_NORMAL)
                            {
                                // トランザクションデータの作成を行います
                                status = uOEOrderDtlMitsubishiAcs.DoConfirm(answerDateMitsubishiPara, out errMess);
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
                // ダイアログを閉じる
                form.Close();
                errMess = ex.Message;
                status = (int)ConstantManagement.DB_Status.ctDB_ERROR;
            }

            return (Int16)status;

        }

        /// <summary>
        /// 自動化プログラム
        /// </summary>
        [DllImport("PMPU9011.dll")]
        public extern static int xPMPU9011(int imk, string dir, int port, string pcname, int itimeout, string sdir, int imei, ref string msg);
        #endregion
        // --------ADD 2010/12/31---------<<<<<
    }
}
