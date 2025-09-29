using System;
using System.IO;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using Infragistics.Win.UltraWinEditors;
namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// 売上確認表初期値クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       :売上確認表の個別初期値を管理するクラスです。</br>
    /// <br>Programmer : 凌小青</br>
    /// <br>Date       : 2011/11/29</br>
    /// <br>UpdateNote : ・障害対応Redmine#28202</br>
    /// <br>Programmer : 田建委</br>
    /// <br>Date	   : 2012/01/30</br>
    /// </remarks>
    [Serializable]
    public class SalesConfInputInitData
    {
        // ===================================================================================== //
        // プライベート変数
        // ===================================================================================== //
        # region Private Members
        //----- DEL 2012/01/30 田建委 Redmine#28202 ----------------------------->>>>>
        //private string _grsProfitCheckLower = string.Empty;//粗利率の下限値
        //private string _grsProfitCheckBest = string.Empty;//粗利率の適正値
        //private string _grsProfitCheckUpper = string.Empty;//粗利率の上限値
        //----- DEL 2012/01/30 田建委 Redmine#28202 -----------------------------<<<<<
        private string _grsProfitRatePrintVal = string.Empty;//粗利率
        private int _zeroSalesPrint; //売価ゼロ
        private int _zeroCostPrint;//原価ゼロ
        private int _zeroGrsProfitPrint;//粗利ゼロ
        private int _zeroUdrGrsProfitPrint;//粗利ゼロ以下
        private int _grsProfitRatePrint;//粗利率check框
        private const string ctXML_FILE_NAME = "MAHNB02340UA_InitialData.XML";
        # endregion

        // ===================================================================================== //
        // コンストラクタ
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// 売上確認表用初期値クラス
        /// </summary>
        /// <remarks>
        /// <br>Note       : 売上確認表用初期値クラスの新しいインスタンスを初期化します。</br>
        /// <br>Programmer : 凌小青</br>
        /// <br>Date       : 2011/11/29</br>
        /// </remarks>
        public SalesConfInputInitData()
        {
            //
        }      
        # endregion

        // ===================================================================================== //
        // プロパティ
        // ===================================================================================== //
        # region Properties
        //----- DEL 2012/01/30 田建委 Redmine#28202 ------------------->>>>>
        ///// <summary>粗利率の下限値</summary>
        //public string GrsProfitCheckLower
        //{
        //    get { return this._grsProfitCheckLower; }
        //    set { this._grsProfitCheckLower = value; }
        //}

        ///// <summary>粗利率の適正値</summary>
        //public string GrsProfitCheckBest
        //{
        //    get { return this._grsProfitCheckBest; }
        //    set { this._grsProfitCheckBest = value; }
        //}

        ///// <summary>粗利率の上限値</summary>
        //public string GrsProfitCheckUpper
        //{
        //    get { return this._grsProfitCheckUpper; }
        //    set { this._grsProfitCheckUpper = value; }
        //}
        //----- DEL 2012/01/30 田建委 Redmine#28202 -------------------<<<<<

        /// <summary>粗利率</summary>
        public string GrsProfitRatePrintVal
        {
            get { return this._grsProfitRatePrintVal; }
            set { this._grsProfitRatePrintVal = value; }
        }

        /// <summary>売価ゼロ</summary>
        public int ZeroSalesPrint
        {
            get { return this._zeroSalesPrint; }
            set { this._zeroSalesPrint = value; }
        }

        /// <summary>原価ゼロ</summary>
        public int ZeroCostPrint
        {
            get { return this._zeroCostPrint; }
            set { this._zeroCostPrint = value; }
        }

        /// <summary>粗利ゼロ</summary>
        public int ZeroGrsProfitPrint
        {
            get { return this._zeroGrsProfitPrint; }
            set { this._zeroGrsProfitPrint = value; }
        }

        /// <summary>粗利ゼロ以下</summary>
        public int ZeroUdrGrsProfitPrint
        {
            get { return this._zeroUdrGrsProfitPrint; }
            set { this._zeroUdrGrsProfitPrint = value; }
        }

        /// <summary>粗利率check框</summary>
        public int GrsProfitRatePrint
        {
            get { return this._grsProfitRatePrint; }
            set { this._grsProfitRatePrint = value; }
        }
        # endregion

        // ===================================================================================== //
        // パブリックメソッド
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// シリアライズ処理
        /// </summary>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(this, Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));
        }

        /// <summary>
        /// デシリアライズ処理
        /// </summary>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME)))
            {
                SalesConfInputInitData data = UserSettingController.DeserializeUserSetting<SalesConfInputInitData>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));

                //----- DEL 2012/01/30 田建委 Redmine#28202 ------------------------>>>>>
                //this._grsProfitCheckLower = data._grsProfitCheckLower;
                //this._grsProfitCheckBest = data._grsProfitCheckBest;
                //this._grsProfitCheckUpper = data._grsProfitCheckUpper;
                //----- DEL 2012/01/30 田建委 Redmine#28202 ------------------------<<<<<
                this._grsProfitRatePrint = data._grsProfitRatePrint;
                this._grsProfitRatePrintVal = data._grsProfitRatePrintVal;
                this._zeroCostPrint = data._zeroCostPrint;
                this._zeroGrsProfitPrint = data._zeroGrsProfitPrint;
                this._zeroSalesPrint = data._zeroSalesPrint;
                this._zeroUdrGrsProfitPrint = data._zeroUdrGrsProfitPrint;
            }
        }
        # endregion
    }
}