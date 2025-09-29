using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Remoting.ParamData
{
    /// public class name:   SvrMntInfoWork
    /// <summary>
    ///                      サーバーメンテナンス情報ワーク
    /// </summary>
    /// <remarks>
    /// <br>note             :   サーバーメンテナンス情報ワークヘッダファイル</br>
    /// <br>Programmer       :   自動生成</br>
    /// <br>Date             :   2007/2/26</br>
    /// <br>Genarated Date   :   2007/03/05  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class SvrMntInfoWork //: IFileHeader
    {
        /// <summary>作成日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _createDateTime;

        /// <summary>更新日時</summary>
        /// <remarks>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</remarks>
        private DateTime _updateDateTime;

        /// <summary>論理削除区分</summary>
        /// <remarks>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</remarks>
        private Int32 _logicalDeleteCode;

        /// <summary>パッケージ区分</summary>
        private string _productCode = "";

        /// <summary>サーバーメンテナンス連番</summary>
        private Int32 _serverMainteConsNo;

        /// <summary>サーバーメンテナンス区分</summary>
        /// <remarks>1:定期メンテナンス,9:緊急メンテナンス</remarks>
        private Int32 _serverMainteDivCd;

        /// <summary>サーバーメンテナンス開始予定日時</summary>
        /// <remarks>YYYYMMDDHHmm(西暦日付＋時分)</remarks>
        private Int64 _serverMainteStScdl;

        /// <summary>サーバーメンテナンス終了予定日時</summary>
        /// <remarks>YYYYMMDDHHmm(西暦日付＋時分)</remarks>
        private Int64 _serverMainteEdScdl;

        /// <summary>サーバーメンテナンス開始日時</summary>
        /// <remarks>YYYYMMDDHHmm(西暦日付＋時分)</remarks>
        private Int64 _serverMainteStTime;

        /// <summary>サーバーメンテナンス終了日時</summary>
        /// <remarks>YYYYMMDDHHmm(西暦日付＋時分)</remarks>
        private Int64 _serverMainteEdTime;

        /// <summary>サーバーメンテナンス内容</summary>
        private string _serverMainteCntnts = "";

        /// <summary>サーバーメンテナンス案内文</summary>
        private string _serverMainteGidnc = "";


        /// public propaty name  :  CreateDateTime
        /// <summary>作成日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   作成日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime CreateDateTime
        {
            get { return _createDateTime; }
            set { _createDateTime = value; }
        }

        /// public propaty name  :  UpdateDateTime
        /// <summary>更新日時プロパティ</summary>
        /// <value>共通ファイルヘッダ（DateTime:精度は100ナノ秒）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   更新日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public DateTime UpdateDateTime
        {
            get { return _updateDateTime; }
            set { _updateDateTime = value; }
        }

        /// public propaty name  :  LogicalDeleteCode
        /// <summary>論理削除区分プロパティ</summary>
        /// <value>共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   論理削除区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 LogicalDeleteCode
        {
            get { return _logicalDeleteCode; }
            set { _logicalDeleteCode = value; }
        }

        /// public propaty name  :  ProductCode
        /// <summary>パッケージ区分プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   パッケージ区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ProductCode
        {
            get { return _productCode; }
            set { _productCode = value; }
        }

        /// public propaty name  :  ServerMainteConsNo
        /// <summary>サーバーメンテナンス連番プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サーバーメンテナンス連番プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ServerMainteConsNo
        {
            get { return _serverMainteConsNo; }
            set { _serverMainteConsNo = value; }
        }

        /// public propaty name  :  ServerMainteDivCd
        /// <summary>サーバーメンテナンス区分プロパティ</summary>
        /// <value>1:定期メンテナンス,9:緊急メンテナンス</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サーバーメンテナンス区分プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 ServerMainteDivCd
        {
            get { return _serverMainteDivCd; }
            set { _serverMainteDivCd = value; }
        }

        /// public propaty name  :  ServerMainteStScdl
        /// <summary>サーバーメンテナンス開始予定日時プロパティ</summary>
        /// <value>YYYYMMDDHHmm(西暦日付＋時分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サーバーメンテナンス開始予定日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ServerMainteStScdl
        {
            get { return _serverMainteStScdl; }
            set { _serverMainteStScdl = value; }
        }

        /// public propaty name  :  ServerMainteEdScdl
        /// <summary>サーバーメンテナンス終了予定日時プロパティ</summary>
        /// <value>YYYYMMDDHHmm(西暦日付＋時分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サーバーメンテナンス終了予定日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ServerMainteEdScdl
        {
            get { return _serverMainteEdScdl; }
            set { _serverMainteEdScdl = value; }
        }

        /// public propaty name  :  ServerMainteStTime
        /// <summary>サーバーメンテナンス開始日時プロパティ</summary>
        /// <value>YYYYMMDDHHmm(西暦日付＋時分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サーバーメンテナンス開始日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ServerMainteStTime
        {
            get { return _serverMainteStTime; }
            set { _serverMainteStTime = value; }
        }

        /// public propaty name  :  ServerMainteEdTime
        /// <summary>サーバーメンテナンス終了日時プロパティ</summary>
        /// <value>YYYYMMDDHHmm(西暦日付＋時分)</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サーバーメンテナンス終了日時プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int64 ServerMainteEdTime
        {
            get { return _serverMainteEdTime; }
            set { _serverMainteEdTime = value; }
        }

        /// public propaty name  :  ServerMainteCntnts
        /// <summary>サーバーメンテナンス内容プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サーバーメンテナンス内容プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ServerMainteCntnts
        {
            get { return _serverMainteCntnts; }
            set { _serverMainteCntnts = value; }
        }

        /// public propaty name  :  ServerMainteGidnc
        /// <summary>サーバーメンテナンス案内文プロパティ</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   サーバーメンテナンス案内文プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public string ServerMainteGidnc
        {
            get { return _serverMainteGidnc; }
            set { _serverMainteGidnc = value; }
        }


        /// <summary>
        /// サーバーメンテナンス情報ワークコンストラクタ
        /// </summary>
        /// <returns>SvrMntInfoWorkクラスのインスタンス</returns>
        /// <remarks>
        /// <br>Note　　　　　　 :   SvrMntInfoWorkクラスの新しいインスタンスを生成します</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public SvrMntInfoWork()
        {
        }

		/// <summary>
		/// サーバーメンテナンス情報ワークコンストラクタ
		/// </summary>
		/// <param name="createDateTime">作成日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="updateDateTime">更新日時(共通ファイルヘッダ（DateTime:精度は100ナノ秒）)</param>
		/// <param name="logicalDeleteCode">論理削除区分(共通ファイルヘッダ(0:有効,1:論理削除,2:保留,3:完全削除))</param>
		/// <param name="productCode">パッケージ区分</param>
		/// <param name="serverMainteConsNo">サーバーメンテナンス連番(各パッケージ毎に1～連番採番)</param>
		/// <param name="serverMainteDivCd">サーバーメンテナンス区分(1:定期メンテナンス,9:緊急メンテナンス)</param>
		/// <param name="serverMainteStScdl">サーバーメンテナンス開始予定日時(YYYYMMDDHHmm(西暦日付＋時分))</param>
		/// <param name="serverMainteEdScdl">サーバーメンテナンス終了予定日時(YYYYMMDDHHmm(西暦日付＋時分))</param>
		/// <param name="serverMainteStTime">サーバーメンテナンス開始日時(YYYYMMDDHHmm(西暦日付＋時分))</param>
		/// <param name="serverMainteEdTime">サーバーメンテナンス終了日時(YYYYMMDDHHmm(西暦日付＋時分))</param>
		/// <param name="serverMainteCntnts">サーバーメンテナンス内容</param>
		/// <param name="serverMainteGidnc">サーバーメンテナンス案内文</param>
		/// <returns>SvrMntInfoWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SvrMntInfoWorkクラスの新しいインスタンスを生成します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SvrMntInfoWork(DateTime createDateTime,DateTime updateDateTime,Int32 logicalDeleteCode,string productCode,Int32 serverMainteConsNo,Int32 serverMainteDivCd,Int64 serverMainteStScdl,Int64 serverMainteEdScdl,Int64 serverMainteStTime,Int64 serverMainteEdTime,string serverMainteCntnts,string serverMainteGidnc)
		{
			this.CreateDateTime = createDateTime;
			this.UpdateDateTime = updateDateTime;
			this._logicalDeleteCode = logicalDeleteCode;
			this._productCode = productCode;
			this._serverMainteConsNo = serverMainteConsNo;
			this._serverMainteDivCd = serverMainteDivCd;
			this._serverMainteStScdl = serverMainteStScdl;
			this._serverMainteEdScdl = serverMainteEdScdl;
			this._serverMainteStTime = serverMainteStTime;
			this._serverMainteEdTime = serverMainteEdTime;
			this._serverMainteCntnts = serverMainteCntnts;
			this._serverMainteGidnc = serverMainteGidnc;

		}

		/// <summary>
		/// サーバーメンテナンス情報ワーク複製処理
		/// </summary>
		/// <returns>SvrMntInfoWorkクラスのインスタンス</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   自身の内容と等しいSvrMntInfoWorkクラスのインスタンスを返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public SvrMntInfoWork Clone()
		{
			return new SvrMntInfoWork(this._createDateTime,this._updateDateTime,this._logicalDeleteCode,this._productCode,this._serverMainteConsNo,this._serverMainteDivCd,this._serverMainteStScdl,this._serverMainteEdScdl,this._serverMainteStTime,this._serverMainteEdTime,this._serverMainteCntnts,this._serverMainteGidnc);
		}

		/// <summary>
		/// サーバーメンテナンス情報ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のSvrMntInfoWorkクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SvrMntInfoWorkクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public bool Equals(SvrMntInfoWork target)
		{
			return ((this.CreateDateTime == target.CreateDateTime)
				 && (this.UpdateDateTime == target.UpdateDateTime)
				 && (this.LogicalDeleteCode == target.LogicalDeleteCode)
				 && (this.ProductCode == target.ProductCode)
				 && (this.ServerMainteConsNo == target.ServerMainteConsNo)
				 && (this.ServerMainteDivCd == target.ServerMainteDivCd)
				 && (this.ServerMainteStScdl == target.ServerMainteStScdl)
				 && (this.ServerMainteEdScdl == target.ServerMainteEdScdl)
				 && (this.ServerMainteStTime == target.ServerMainteStTime)
				 && (this.ServerMainteEdTime == target.ServerMainteEdTime)
				 && (this.ServerMainteCntnts == target.ServerMainteCntnts)
				 && (this.ServerMainteGidnc == target.ServerMainteGidnc));
		}

		/// <summary>
		/// サーバーメンテナンス情報ワーク比較処理
		/// </summary>
		/// <param name="svrMntInfo1">
		///                    比較するSvrMntInfoWorkクラスのインスタンス
		/// </param>
		/// <param name="svrMntInfo2">比較するSvrMntInfoWorkクラスのインスタンス</param>
		/// <returns>内容が一致するか否か(true:内容は一致する、false:内容は一致しない)</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SvrMntInfoWorkクラスの内容が一致するか比較します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static bool Equals(SvrMntInfoWork svrMntInfo1, SvrMntInfoWork svrMntInfo2)
		{
			return ((svrMntInfo1.CreateDateTime == svrMntInfo2.CreateDateTime)
				 && (svrMntInfo1.UpdateDateTime == svrMntInfo2.UpdateDateTime)
				 && (svrMntInfo1.LogicalDeleteCode == svrMntInfo2.LogicalDeleteCode)
				 && (svrMntInfo1.ProductCode == svrMntInfo2.ProductCode)
				 && (svrMntInfo1.ServerMainteConsNo == svrMntInfo2.ServerMainteConsNo)
				 && (svrMntInfo1.ServerMainteDivCd == svrMntInfo2.ServerMainteDivCd)
				 && (svrMntInfo1.ServerMainteStScdl == svrMntInfo2.ServerMainteStScdl)
				 && (svrMntInfo1.ServerMainteEdScdl == svrMntInfo2.ServerMainteEdScdl)
				 && (svrMntInfo1.ServerMainteStTime == svrMntInfo2.ServerMainteStTime)
				 && (svrMntInfo1.ServerMainteEdTime == svrMntInfo2.ServerMainteEdTime)
				 && (svrMntInfo1.ServerMainteCntnts == svrMntInfo2.ServerMainteCntnts)
				 && (svrMntInfo1.ServerMainteGidnc == svrMntInfo2.ServerMainteGidnc));
		}
		/// <summary>
		/// サーバーメンテナンス情報ワーク比較処理
		/// </summary>
		/// <param name="target">比較対象のSvrMntInfoWorkクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SvrMntInfoWorkクラスの内容が一致するか比較しし、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public ArrayList Compare(SvrMntInfoWork target)
		{
			ArrayList resList = new ArrayList();
			if(this.CreateDateTime != target.CreateDateTime)resList.Add("CreateDateTime");
			if(this.UpdateDateTime != target.UpdateDateTime)resList.Add("UpdateDateTime");
			if(this.LogicalDeleteCode != target.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(this.ProductCode != target.ProductCode)resList.Add("ProductCode");
			if(this.ServerMainteConsNo != target.ServerMainteConsNo)resList.Add("ServerMainteConsNo");
			if(this.ServerMainteDivCd != target.ServerMainteDivCd)resList.Add("ServerMainteDivCd");
			if(this.ServerMainteStScdl != target.ServerMainteStScdl)resList.Add("ServerMainteStScdl");
			if(this.ServerMainteEdScdl != target.ServerMainteEdScdl)resList.Add("ServerMainteEdScdl");
			if(this.ServerMainteStTime != target.ServerMainteStTime)resList.Add("ServerMainteStTime");
			if(this.ServerMainteEdTime != target.ServerMainteEdTime)resList.Add("ServerMainteEdTime");
			if(this.ServerMainteCntnts != target.ServerMainteCntnts)resList.Add("ServerMainteCntnts");
			if(this.ServerMainteGidnc != target.ServerMainteGidnc)resList.Add("ServerMainteGidnc");

			return resList;
		}

		/// <summary>
		/// サーバーメンテナンス情報ワーク比較処理
		/// </summary>
		/// <param name="svrMntInfo1">比較するSvrMntInfoWorkクラスのインスタンス</param>
		/// <param name="svrMntInfo2">比較するSvrMntInfoWorkクラスのインスタンス</param>
		/// <returns>一致しない項目のリスト</returns>
		/// <remarks>
		/// <br>Note　　　　　　 :   SvrMntInfoWorkクラスの内容が一致するか比較し、一致しない項目の名称を返します</br>
		/// <br>Programer        :   自動生成</br>
		/// </remarks>
		public static ArrayList Compare(SvrMntInfoWork svrMntInfo1, SvrMntInfoWork svrMntInfo2)
		{
			ArrayList resList = new ArrayList();
			if(svrMntInfo1.CreateDateTime != svrMntInfo2.CreateDateTime)resList.Add("CreateDateTime");
			if(svrMntInfo1.UpdateDateTime != svrMntInfo2.UpdateDateTime)resList.Add("UpdateDateTime");
			if(svrMntInfo1.LogicalDeleteCode != svrMntInfo2.LogicalDeleteCode)resList.Add("LogicalDeleteCode");
			if(svrMntInfo1.ProductCode != svrMntInfo2.ProductCode)resList.Add("ProductCode");
			if(svrMntInfo1.ServerMainteConsNo != svrMntInfo2.ServerMainteConsNo)resList.Add("ServerMainteConsNo");
			if(svrMntInfo1.ServerMainteDivCd != svrMntInfo2.ServerMainteDivCd)resList.Add("ServerMainteDivCd");
			if(svrMntInfo1.ServerMainteStScdl != svrMntInfo2.ServerMainteStScdl)resList.Add("ServerMainteStScdl");
			if(svrMntInfo1.ServerMainteEdScdl != svrMntInfo2.ServerMainteEdScdl)resList.Add("ServerMainteEdScdl");
			if(svrMntInfo1.ServerMainteStTime != svrMntInfo2.ServerMainteStTime)resList.Add("ServerMainteStTime");
			if(svrMntInfo1.ServerMainteEdTime != svrMntInfo2.ServerMainteEdTime)resList.Add("ServerMainteEdTime");
			if(svrMntInfo1.ServerMainteCntnts != svrMntInfo2.ServerMainteCntnts)resList.Add("ServerMainteCntnts");
			if(svrMntInfo1.ServerMainteGidnc != svrMntInfo2.ServerMainteGidnc)resList.Add("ServerMainteGidnc");

			return resList;
		}
    }
}

