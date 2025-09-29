using System;
using System.IO;
using Broadleaf.Application.Resources;
using Broadleaf.Application.Common;
using System.Collections.Generic;
using Infragistics.Win.UltraWinEditors;
namespace Broadleaf.Application.UIData
{
    /// <summary>
    /// ����m�F�\�����l�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       :����m�F�\�̌ʏ����l���Ǘ�����N���X�ł��B</br>
    /// <br>Programmer : ������</br>
    /// <br>Date       : 2011/11/29</br>
    /// <br>UpdateNote : �E��Q�Ή�Redmine#28202</br>
    /// <br>Programmer : �c����</br>
    /// <br>Date	   : 2012/01/30</br>
    /// </remarks>
    [Serializable]
    public class SalesConfInputInitData
    {
        // ===================================================================================== //
        // �v���C�x�[�g�ϐ�
        // ===================================================================================== //
        # region Private Members
        //----- DEL 2012/01/30 �c���� Redmine#28202 ----------------------------->>>>>
        //private string _grsProfitCheckLower = string.Empty;//�e�����̉����l
        //private string _grsProfitCheckBest = string.Empty;//�e�����̓K���l
        //private string _grsProfitCheckUpper = string.Empty;//�e�����̏���l
        //----- DEL 2012/01/30 �c���� Redmine#28202 -----------------------------<<<<<
        private string _grsProfitRatePrintVal = string.Empty;//�e����
        private int _zeroSalesPrint; //�����[��
        private int _zeroCostPrint;//�����[��
        private int _zeroGrsProfitPrint;//�e���[��
        private int _zeroUdrGrsProfitPrint;//�e���[���ȉ�
        private int _grsProfitRatePrint;//�e����check�y
        private const string ctXML_FILE_NAME = "MAHNB02340UA_InitialData.XML";
        # endregion

        // ===================================================================================== //
        // �R���X�g���N�^
        // ===================================================================================== //
        # region Constructors
        /// <summary>
        /// ����m�F�\�p�����l�N���X
        /// </summary>
        /// <remarks>
        /// <br>Note       : ����m�F�\�p�����l�N���X�̐V�����C���X�^���X�����������܂��B</br>
        /// <br>Programmer : ������</br>
        /// <br>Date       : 2011/11/29</br>
        /// </remarks>
        public SalesConfInputInitData()
        {
            //
        }      
        # endregion

        // ===================================================================================== //
        // �v���p�e�B
        // ===================================================================================== //
        # region Properties
        //----- DEL 2012/01/30 �c���� Redmine#28202 ------------------->>>>>
        ///// <summary>�e�����̉����l</summary>
        //public string GrsProfitCheckLower
        //{
        //    get { return this._grsProfitCheckLower; }
        //    set { this._grsProfitCheckLower = value; }
        //}

        ///// <summary>�e�����̓K���l</summary>
        //public string GrsProfitCheckBest
        //{
        //    get { return this._grsProfitCheckBest; }
        //    set { this._grsProfitCheckBest = value; }
        //}

        ///// <summary>�e�����̏���l</summary>
        //public string GrsProfitCheckUpper
        //{
        //    get { return this._grsProfitCheckUpper; }
        //    set { this._grsProfitCheckUpper = value; }
        //}
        //----- DEL 2012/01/30 �c���� Redmine#28202 -------------------<<<<<

        /// <summary>�e����</summary>
        public string GrsProfitRatePrintVal
        {
            get { return this._grsProfitRatePrintVal; }
            set { this._grsProfitRatePrintVal = value; }
        }

        /// <summary>�����[��</summary>
        public int ZeroSalesPrint
        {
            get { return this._zeroSalesPrint; }
            set { this._zeroSalesPrint = value; }
        }

        /// <summary>�����[��</summary>
        public int ZeroCostPrint
        {
            get { return this._zeroCostPrint; }
            set { this._zeroCostPrint = value; }
        }

        /// <summary>�e���[��</summary>
        public int ZeroGrsProfitPrint
        {
            get { return this._zeroGrsProfitPrint; }
            set { this._zeroGrsProfitPrint = value; }
        }

        /// <summary>�e���[���ȉ�</summary>
        public int ZeroUdrGrsProfitPrint
        {
            get { return this._zeroUdrGrsProfitPrint; }
            set { this._zeroUdrGrsProfitPrint = value; }
        }

        /// <summary>�e����check�y</summary>
        public int GrsProfitRatePrint
        {
            get { return this._grsProfitRatePrint; }
            set { this._grsProfitRatePrint = value; }
        }
        # endregion

        // ===================================================================================== //
        // �p�u���b�N���\�b�h
        // ===================================================================================== //
        # region Public Methods
        /// <summary>
        /// �V���A���C�Y����
        /// </summary>
        public void Serialize()
        {
            UserSettingController.SerializeUserSetting(this, Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));
        }

        /// <summary>
        /// �f�V���A���C�Y����
        /// </summary>
        public void Deserialize()
        {
            if (UserSettingController.ExistUserSetting(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME)))
            {
                SalesConfInputInitData data = UserSettingController.DeserializeUserSetting<SalesConfInputInitData>(Path.Combine(ConstantManagement_ClientDirectory.UISettings, ctXML_FILE_NAME));

                //----- DEL 2012/01/30 �c���� Redmine#28202 ------------------------>>>>>
                //this._grsProfitCheckLower = data._grsProfitCheckLower;
                //this._grsProfitCheckBest = data._grsProfitCheckBest;
                //this._grsProfitCheckUpper = data._grsProfitCheckUpper;
                //----- DEL 2012/01/30 �c���� Redmine#28202 ------------------------<<<<<
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