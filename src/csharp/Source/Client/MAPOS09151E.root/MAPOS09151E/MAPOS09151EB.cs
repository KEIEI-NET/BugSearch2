using System;
using System.Collections;
using System.IO;
using Broadleaf.Library.Globarization;

namespace Broadleaf.Application.UIData
{
    /// <summary>端末管理設定マスタローカル保存情報クラス</summary>
    /// <remarks>
    /// <br>Note       : 端末管理設定のローカル保存情報を定義するクラスです。</br>
    /// <br>Programmer : 20031 古賀　小百合</br>
    /// <br>Date       : 2007.07.03</br>
    /// <br></br>
    /// </remarks>
    [Serializable]
    public class PosTerminalMgXMLData
    {
        /// <summary>企業コード</summary>
        /// <remarks>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</remarks>
        private string _enterpriseCode = "";

        /// <summary>拠点コード</summary>
        //private string _sectionCode = "";

        /// <summary>レジ番号</summary>
        private Int32 _cashRegisterNo;

        /// public propaty name  :  EnterpriseCode
        /// <summary>企業コードプロパティ</summary>
        /// <value>共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   企業コードプロパティ</br>
        /// <br>Programer        :   20031 古賀　小百合</br>
        /// </remarks>
        public string EnterpriseCode
        {
            get { return _enterpriseCode; }
            set { _enterpriseCode = value; }
        }

        /// public propaty name  :  SectionCode
        /// <summary>拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   拠点コードプロパティ</br>
        /// <br>Programer        :   20031 古賀　小百合</br>
        /// </remarks>
        //public string SectionCode
        //{
        //    get { return _sectionCode; }
        //    set { _sectionCode = value; }
        //}

        /// public propaty name  :  CashRegisterNo
        /// <summary>レジ番号プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   レシート印刷種別プロパティ</br>
        /// <br>Programer        :   20031 古賀　小百合</br>
        /// </remarks>
        public Int32 CashRegisterNo
        {
            get { return _cashRegisterNo; }
            set { _cashRegisterNo = value; }
        }

        /// <summary>端末管理印刷設定マスタコンストラクタ
        /// </summary>
        /// <returns>PosTerminalMgXMLDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PosTerminalMgXMLDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   20031 古賀　小百合</br>
        /// </remarks>
        public PosTerminalMgXMLData()
        {
        }

        /// <summary>端末管理設定マスタコンストラクタ</summary>
        /// <param name="enterpriseCode">企業コード(共通ファイルヘッダ（国2桁+県2桁+業種2桁+ユーザーコード10桁）)</param>
        /// <param name="sectionCode">拠点コード</param>
        /// <param name="cashRegisterNo">レジ番号</param>
        /// <returns>PosTerminalMgXMLDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PosTerminalMgXMLDataクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   20031 古賀　小百合</br>
        /// </remarks>
        //public PosTerminalMgXMLData(string enterpriseCode, string sectionCode, Int32 cashRegisterNo)
        public PosTerminalMgXMLData(string enterpriseCode, Int32 cashRegisterNo)
        {
            this._enterpriseCode = enterpriseCode;
            //this._sectionCode = sectionCode;
            this._cashRegisterNo = cashRegisterNo;
        }

        /// <summary>端末管理設定設定マスタ複製処理</summary>
        /// <returns>PosTerminalMgXMLDataクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいPosTerminalMgXMLDataクラスのインスタンスを返します</br>
        /// <br>Programer        :   20031 古賀　小百合</br>
        /// </remarks>
        public PosTerminalMgXMLData Clone()
        {
            //return new PosTerminalMgXMLData(this._enterpriseCode, this._sectionCode, this._cashRegisterNo);
            return new PosTerminalMgXMLData(this._enterpriseCode, this._cashRegisterNo);
        }

        /// <summary>端末管理設定マスタ比較処理</summary>
        /// <param name="target">比較対象のPosTerminalMgXMLDataクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   PosTerminalMgXMLDataクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   20031 古賀　小百合</br>
        /// </remarks>
        public bool Equals(PosTerminalMgXMLData target)
        {
            return ((this.EnterpriseCode == target.EnterpriseCode)
                 //&& (this.SectionCode == target.SectionCode)
                 && (this.CashRegisterNo == target.CashRegisterNo));
        }
    }
}
