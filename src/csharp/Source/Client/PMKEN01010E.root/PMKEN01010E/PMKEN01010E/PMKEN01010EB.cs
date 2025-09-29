using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Common
{
    /// <summary>
    /// 車両検索タイプ列挙体
    /// </summary>
    /// <remarks>
    /// <br>Note       : 検索条件の１つとして車両検索の方法をUI側から指定します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    public enum CarSearchType : int
    {
        /// <summary> 未指定(通常は使用しない) </summary>
        csNone = 0,

        /// <summary> 類別検索 </summary>
        csCategory = 1,

        /// <summary> 型式検索 </summary>
        csModel = 2,

        /// <summary> エンジン型式検索 </summary>
        csEngineModel = 3,

        /// <summary> プレート検索 </summary>
        csPlate = 4
    };

    /// <summary>
    /// 車両型式クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車両型式にまつわるデータと処理を実装します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class CarModel
    {
        private const char _Delimiter = '-';  // 区切り文字
        private string _ExhaustGasSign;       // 排ガス規制識別記号
        private string _SeriesModel;          // シリーズ型式
        private string _CategorySign;         // 類別記号

        /// <summary>
        /// 車両型式クラスコンストラクタ
        /// </summary>
        public CarModel()
        {
            Clear();
        }

        /// <summary>
        /// 車両型式クリア
        /// </summary>
        /// <remarks>
        /// 車両型式を構成するメンバを全て初期化します。
        /// </remarks>
        internal void Clear()
        {
            ExhaustGasSign = "";
            SeriesModel = "";
            CategorySign = "";
        }

        /// <summary>
        /// 車両型式内容のコピーメソッド
        /// </summary>
        /// <param name="Source">コピー元の車両型式クラス</param>
        internal void Assign(CarModel Source)
        {
            _ExhaustGasSign = Source._ExhaustGasSign;
            _SeriesModel = Source._SeriesModel;
            _CategorySign = Source._CategorySign;
        }

        # region Property

        /// <summary>
        /// 排ガス記号
        /// </summary>
        public string ExhaustGasSign
        {
            get { return _ExhaustGasSign; }
            set { _ExhaustGasSign = value.ToUpper(); }
        }

        /// <summary>
        /// シリーズ型式
        /// </summary>
        public string SeriesModel
        {
            get { return _SeriesModel; }
            set { _SeriesModel = value.ToUpper(); }
        }

        /// <summary>
        /// 類別記号
        /// </summary>
        public string CategorySign
        {
            get { return _CategorySign; }
            set { _CategorySign = value.ToUpper(); }
        }

        /// <summary>
        /// フル型式
        /// </summary>
        /// <remarks>
        /// "xxx-xxx-xxx"の文字列でフル型式を取得します。
        /// "xxx-xxx-xxx"の文字列でフル型式を設定した場合は、文字列に含まれるハイフン(-)を区切りとして
        /// 自動的に排ガス規制識別区分やシリーズ型式などに分解されます。
        /// </remarks>
        public string FullModel
        {
            get
            {
                string _FullModel = "";

                // 排ガス規制識別記号の設定
                if (ExhaustGasSign != "")
                {
                    _FullModel = ExhaustGasSign;
                }

                // シリーズ型式の設定
                if (SeriesModel != "")
                {
                    if (_FullModel != "")
                    {
                        _FullModel += _Delimiter;
                    }

                    _FullModel += SeriesModel;
                }

                // 類別記号の設定
                if (CategorySign != "")
                {
                    if (_FullModel != "")
                    {
                        _FullModel += _Delimiter;
                    }

                    _FullModel += CategorySign;
                }

                return _FullModel;
            }

            set
            {
                Clear();  // 車両型式を初期化

                // ハイフンで分解して配列に格納
                string[] Models = value.Split(new char[] { _Delimiter });

                if (Models.Length == 1)
                {
                    SeriesModel = Models[0];  // 分解結果が１つの場合はシリーズ型式固定とする
                }
                else
                {
                    // 分解結果が複数存在する場合は順に設定していく
                    for (int iCnt = 0; iCnt < Models.Length; iCnt++)
                    {
                        switch (iCnt)
                        {
                            case 0:
                                ExhaustGasSign = Models[iCnt];  // 排ガス規制識別区分
                                break;
                            case 1:
                                SeriesModel = Models[iCnt];     // シリーズ型式
                                break;
                            case 2:
                                CategorySign = Models[iCnt];  // 類別記号
                                break;
                            default:
                                break;
                        }

                    }
                }
            }
        }

        /// <summary>
        /// フル型式判定
        /// </summary>
        /// <remarks>
        /// フル型式が設定されていれば true を返します。
        /// それ以外は false を返します。
        /// </remarks>
        public bool IsFullModel
        {
            // 排ガス規制識別区分とシリーズ型式が入力されていればフル型式と判定する
            get { return (_ExhaustGasSign != "") && (_SeriesModel != ""); }
        }

        # endregion

    }

    /// <summary>
    /// エンジン型式クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : エンジン型式にまつわるデータと処理を実装します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: </br>
    /// </remarks>
    [Serializable]
    public class EngineModel
    {
        private const char _Delimiter = '-';  // 区切り文字
        private string _ModelNm;              // エンジン型式名称(フル型式からハイフンを除いた物)
        private string _FullModel;            // エンジンフル型式
        private string _Model;                // エンジン型式(車検証記載形式)

        /// <summary>
        /// エンジン型式クラスコンストラクタ
        /// </summary>
        public EngineModel()
        {
            Clear();
        }

        /// <summary>
        /// エンジン型式クリア
        /// </summary>
        /// <remarks>
        /// エンジン型式を構成するメンバを全て初期化します。
        /// </remarks>
        internal void Clear()
        {
            _ModelNm = "";
            _FullModel = "";
            _Model = "";
        }

        /// <summary>
        /// エンジン型式内容のコピーメソッド
        /// </summary>
        /// <param name="Source">コピー元のエンジン型式クラス</param>
        internal void Assign(EngineModel Source)
        {
            _ModelNm = Source._ModelNm;
            _FullModel = Source._FullModel;
            _Model = Source._Model;
        }

        # region Property

        /// <summary>
        /// エンジン型式名称
        /// </summary>
        /// <remarks>
        /// エンジンフル型式からハイフンを除いた文字列(例:1NZ-FE → 1NZFE)
        /// </remarks>
        public string ModelNm
        {
            get { return _ModelNm; }
            set { _ModelNm = value; }
        }

        /// <summary>
        /// エンジンフル型式
        /// </summary>
        /// <remarks>
        /// エンジンフル型式を指定する事によって、エンジン型式名称とエンジン型式も同時に設定されます。
        /// </remarks>
        public string FullModel
        {
            get { return _FullModel; }

            set
            {
                Clear();  // 車両型式を初期化

                _FullModel = value.ToUpper();

                // ハイフンで分解して配列に格納
                string[] Models = value.Split(new char[] { _Delimiter });

                // 分解結果が複数存在する場合は順に設定していく
                for (int iCnt = 0; iCnt < Models.Length; iCnt++)
                {
                    if (iCnt == 0) { _Model = Models[iCnt]; };  // エンジン型式を設定
                    _ModelNm += Models[iCnt].ToUpper();                   // エンジン型式名称を設定
                }
            }
        }

        /// <summary>
        /// エンジン型式
        /// </summary>
        /// <remarks>
        /// 車検証に記載されているエンジンの型式(例:1NZ-FE → 1NZ)
        /// </remarks>
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }

        # endregion
    }

    /// <summary>
    /// 車両検索条件クラス
    /// </summary>
    /// <remarks>
    /// <br>Note       : 車両検索を行うための検索条件を管理します。</br>
    /// <br>Programmer : 30290</br>
    /// <br>Date       : 2008.05.15</br>
    /// <br></br>
    /// <br>Update Note: 2010/04/21  22018 鈴木 正臣</br>
    /// <br>             自由検索オプション対応（自由検索型式マスメンで使用する自由検索ONLY区分を追加）</br>
    /// <br></br>
    /// <br>Update Note: 2010/06/04  22018  鈴木 正臣</br>
    /// <br>             成果物統合</br>
    /// <br>               自由検索 2010/04/21 の組込</br>
    /// </remarks>
    [Serializable]
    public class CarSearchCondition
    {
        # region Private Members

        private CarSearchType _Type;        // 車両検索タイプ
        private Int32 _MakerCode;           // メーカーコード
        private Int32 _ModelCode;           // 車種コード
        private Int32 _ModelSubCode = -1;   // 車種サブコード
        private Int32 _ModelDesignationNo;  // 型式指定番号
        private Int32 _CategoryNo;          // 類別区分番号
        private CarModel _CarModel;         // 車両型式
        private EngineModel _EngineModel;   // エンジン型式
        private string _ModelPlate;         // モデルプレート
        /// <summary>元号表示区分１</summary>
        /// <remarks>0:西暦　1:和暦（年式）</remarks>
        private Int32 _eraNameDispCd1;
        // --- ADD m.suzuki 2010/04/21 ---------->>>>>
        private bool _freeSearchModelOnly; // 自由検索型式のみ抽出区分
        // --- ADD m.suzuki 2010/04/21 ----------<<<<<
        # endregion

        /// <summary>
        /// 車両検索条件クラスコンストラクタ
        /// </summary>
        /// <remarks>車両検索条件クラスのコンストラクタ</remarks>
        public CarSearchCondition()
        {
            _CarModel = new CarModel();
            _EngineModel = new EngineModel();
            Clear();
        }

        /// <summary>
        /// 車両検索条件クラスデストラクタ
        /// </summary>
        ~CarSearchCondition()
        {
            _CarModel = null;
            _EngineModel = null;
        }

        /// <summary>
        /// 車両検索条件クリアメソッド
        /// </summary>
        public void Clear()
        {
            _Type = CarSearchType.csNone;
            _MakerCode = 0;
            _ModelCode = 0;
            _ModelSubCode = -1;
            _ModelDesignationNo = 0;
            _CategoryNo = 0;
            _ModelPlate = "";
            _CarModel.Clear();
            _EngineModel.Clear();
        }

        /// <summary>
        /// 車両検索条件内容のコピーメソッド
        /// </summary>
        /// <param name="Source">コピー元の車両検索条件クラス</param>
        public void Assign(CarSearchCondition Source)
        {
            _Type = Source._Type;
            _MakerCode = Source._MakerCode;
            _ModelCode = Source._ModelCode;
            _ModelSubCode = Source._ModelSubCode;
            _ModelDesignationNo = Source._ModelDesignationNo;
            _CategoryNo = Source._CategoryNo;
            _ModelPlate = Source._ModelPlate;
            CarModel.Assign(Source.CarModel);
            EngineModel.Assign(Source.EngineModel);
            _eraNameDispCd1 = Source.EraNameDispCd1;
        }

        /// <summary>
        /// 車両検索タイププロパティ
        /// </summary>
        public CarSearchType Type
        {
            get { return _Type; }
            set { _Type = value; }
        }

        /// <summary>
        /// メーカーコードプロパティ
        /// </summary>
        public Int32 MakerCode
        {
            get { return _MakerCode; }
            set { _MakerCode = value; }
        }

        /// <summary>
        /// 車種コードプロパティ
        /// </summary>
        public Int32 ModelCode
        {
            get { return _ModelCode; }
            set { _ModelCode = value; }
        }

        /// <summary>
        /// 車種サブコード
        /// </summary>
        public Int32 ModelSubCode
        {
            get { return _ModelSubCode; }
            set { _ModelSubCode = value; }
        }

        /// <summary>
        /// 型式指定番号プロパティ
        /// </summary>
        public Int32 ModelDesignationNo
        {
            get { return _ModelDesignationNo; }
            set { _ModelDesignationNo = value; }
        }

        /// <summary>
        /// 類別区分番号プロパティ
        /// </summary>
        public Int32 CategoryNo
        {
            get { return _CategoryNo; }
            set { _CategoryNo = value; }
        }

        /// <summary>
        /// モデルプレートプロパティ
        /// </summary>
        public String ModelPlate
        {
            get { return _ModelPlate; }
            set { _ModelPlate = value.ToUpper(); }
        }

        /// <summary>
        /// 型式プロパティ
        /// </summary>
        public CarModel CarModel
        {
            get { return _CarModel; }
        }

        /// <summary>
        /// エンジン型式プロパティ
        /// </summary>
        public EngineModel EngineModel
        {
            get { return _EngineModel; }
            set { _EngineModel = value; }
        }

        /// public propaty name  :  EraNameDispCd1
        /// <summary>元号表示区分１プロパティ</summary>
        /// <value>0:西暦　1:和暦（年式）</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   元号表示区分１プロパティ</br>
        /// <br>Programer        :   自動生成</br>
        /// </remarks>
        public Int32 EraNameDispCd1
        {
            get { return _eraNameDispCd1; }
            set { _eraNameDispCd1 = value; }
        }

        // --- ADD m.suzuki 2010/04/21 ---------->>>>>
        /// <summary>
        /// 自由検索型式のみ抽出区分
        /// </summary>
        public bool FreeSearchModelOnly
        {
            get { return _freeSearchModelOnly; }
            set { _freeSearchModelOnly = value; }
        }
        // --- ADD m.suzuki 2010/04/21 ----------<<<<<

        /// <summary>
        /// 検索条件設定完了プロパティ
        /// </summary>
        /// <remarks>
        /// 検索条件準備が出来ている場合は true を返します。
        /// 準備が出来ていない場合は false を返します。
        /// </remarks>
        public bool IsReady
        {
            get
            {
                bool _ret = false;

                switch (_Type)
                {
                    // 類別検索条件
                    case CarSearchType.csCategory:
                        // 型式指定番号が0以上であれば、類別区分番号は 0 でも構わない。
                        _ret = _ModelDesignationNo > 0;
                        break;
                    // 型式検索条件
                    case CarSearchType.csModel:
                        if (_CarModel.IsFullModel)
                        {
                            // フル型式と判断された場合
                            _ret = true;
                        }
                        else
                        {
                            // シリーズ型式と判断された場合
                            _ret = _CarModel.SeriesModel != "";
                        }
                        break;
                    // エンジン型式検索条件
                    case CarSearchType.csEngineModel:
                        _ret = _EngineModel.ModelNm != "";
                        break;
                    default:
                        break;
                }

                return _ret;
            }
        }
    }
}
