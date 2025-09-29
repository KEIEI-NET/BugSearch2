using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   CnectOrgNSSecInfo
    /// <summary>
    ///                      連結元NS拠点情報
    /// </summary>
    /// <remarks>
    /// <br>note             :   連結元NS拠点情報ヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2014/9/15</br>
    /// <br>Genarated Date   :   2014/09/15  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class CnectOrgNSSecInfo
    {
        /// <summary>連結元企業コード</summary>
        private string _cnectOriginalEpCd = "";

        /// <summary>連結元拠点コード</summary>
        private string _cnectOriginalSecCd = "";

        /// <summary>連結元拠点ガイド名称</summary>
        private string _cnectOriginalSecGNm = "";


        /// public propaty name  :  CnectOriginalEpCd
        /// <summary>連結元企業コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結元企業コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOriginalEpCd
        {
            get { return _cnectOriginalEpCd; }
            set { _cnectOriginalEpCd = value; }
        }

        /// public propaty name  :  CnectOriginalSecCd
        /// <summary>連結元拠点コードプロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結元拠点コードプロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOriginalSecCd
        {
            get { return _cnectOriginalSecCd; }
            set { _cnectOriginalSecCd = value; }
        }

        /// public propaty name  :  CnectOriginalSecGNm
        /// <summary>連結元拠点ガイド名称プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   連結元拠点ガイド名称プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string CnectOriginalSecGNm
        {
            get { return _cnectOriginalSecGNm; }
            set { _cnectOriginalSecGNm = value; }
        }


        /// <summary>
        /// 連結元NS拠点情報コンストラクタ
        /// </summary>
        /// <returns>CnectOrgNSSecInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CnectOrgNSSecInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CnectOrgNSSecInfo()
        {
        }

        /// <summary>
        /// 連結元NS拠点情報コンストラクタ
        /// </summary>
        /// <param name="cnectOriginalEpCd">連結元企業コード</param>
        /// <param name="cnectOriginalSecCd">連結元拠点コード</param>
        /// <param name="cnectOriginalSecGNm">連結元拠点ガイド名称</param>
        /// <returns>CnectOrgNSSecInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CnectOrgNSSecInfoクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CnectOrgNSSecInfo(string cnectOriginalEpCd, string cnectOriginalSecCd, string cnectOriginalSecGNm)
        {
            this._cnectOriginalEpCd = cnectOriginalEpCd;
            this._cnectOriginalSecCd = cnectOriginalSecCd;
            this._cnectOriginalSecGNm = cnectOriginalSecGNm;

        }

        /// <summary>
        /// 連結元NS拠点情報複製処理
        /// </summary>
        /// <returns>CnectOrgNSSecInfoクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   自身の内容と等しいCnectOrgNSSecInfoクラスのインスタンスを返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public CnectOrgNSSecInfo Clone()
        {
            return new CnectOrgNSSecInfo(this._cnectOriginalEpCd, this._cnectOriginalSecCd, this._cnectOriginalSecGNm);
        }

        /// <summary>
        /// 連結元NS拠点情報比較処理
        /// </summary>
        /// <param name="target">比較対象のCnectOrgNSSecInfoクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CnectOrgNSSecInfoクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public bool Equals(CnectOrgNSSecInfo target)
        {
            return ((this.CnectOriginalEpCd == target.CnectOriginalEpCd)
                 && (this.CnectOriginalSecCd == target.CnectOriginalSecCd)
                 && (this.CnectOriginalSecGNm == target.CnectOriginalSecGNm));
        }

        /// <summary>
        /// 連結元NS拠点情報比較処理
        /// </summary>
        /// <param name="cnectOrgNSSecInfo1">
        ///                    比較するCnectOrgNSSecInfoクラスのインスタンス
        /// </param>
        /// <param name="cnectOrgNSSecInfo2">比較するCnectOrgNSSecInfoクラスのインスタンス</param>
        /// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CnectOrgNSSecInfoクラスの内容が一致するか比較します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static bool Equals(CnectOrgNSSecInfo cnectOrgNSSecInfo1, CnectOrgNSSecInfo cnectOrgNSSecInfo2)
        {
            return ((cnectOrgNSSecInfo1.CnectOriginalEpCd == cnectOrgNSSecInfo2.CnectOriginalEpCd)
                 && (cnectOrgNSSecInfo1.CnectOriginalSecCd == cnectOrgNSSecInfo2.CnectOriginalSecCd)
                 && (cnectOrgNSSecInfo1.CnectOriginalSecGNm == cnectOrgNSSecInfo2.CnectOriginalSecGNm));
        }
        /// <summary>
        /// 連結元NS拠点情報比較処理
        /// </summary>
        /// <param name="target">比較対象のCnectOrgNSSecInfoクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CnectOrgNSSecInfoクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public ArrayList Compare(CnectOrgNSSecInfo target)
        {
            ArrayList resList = new ArrayList();
            if (this.CnectOriginalEpCd != target.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (this.CnectOriginalSecCd != target.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (this.CnectOriginalSecGNm != target.CnectOriginalSecGNm) resList.Add("CnectOriginalSecGNm");

            return resList;
        }

        /// <summary>
        /// 連結元NS拠点情報比較処理
        /// </summary>
        /// <param name="cnectOrgNSSecInfo1">比較するCnectOrgNSSecInfoクラスのインスタンス</param>
        /// <param name="cnectOrgNSSecInfo2">比較するCnectOrgNSSecInfoクラスのインスタンス</param>
        /// <returns>一致しない項目のリスト</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   CnectOrgNSSecInfoクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public static ArrayList Compare(CnectOrgNSSecInfo cnectOrgNSSecInfo1, CnectOrgNSSecInfo cnectOrgNSSecInfo2)
        {
            ArrayList resList = new ArrayList();
            if (cnectOrgNSSecInfo1.CnectOriginalEpCd != cnectOrgNSSecInfo2.CnectOriginalEpCd) resList.Add("CnectOriginalEpCd");
            if (cnectOrgNSSecInfo1.CnectOriginalSecCd != cnectOrgNSSecInfo2.CnectOriginalSecCd) resList.Add("CnectOriginalSecCd");
            if (cnectOrgNSSecInfo1.CnectOriginalSecGNm != cnectOrgNSSecInfo2.CnectOriginalSecGNm) resList.Add("CnectOriginalSecGNm");

            return resList;
        }
    }
}
