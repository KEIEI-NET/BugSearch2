using System;
using System.Collections;

namespace Broadleaf.Application.UIData
{
    /// public class name:   MarketPriceInfo
    /// <summary>
    ///                      ���ꉿ�i���
    /// </summary>
    /// <remarks>
    /// <br>note             :   ���ꉿ�i���w�b�_�t�@�C��</br>
    /// <br>Programmer       :   ��������</br>
    /// <br>Date             :   2010/5/18</br>
    /// <br>Genarated Date   :   2010/06/17  (CSharp File Generated Date)</br>
    /// <br>Update Note      :   </br>
    /// </remarks>
    public class MarketPriceInfo
    {
        /// <summary>���ꉿ�i�n��R�[�h</summary>
        private Int32 _marketPriceAreaCd;

        /// <summary>���ꉿ�i��ʃR�[�h</summary>
        private Int32 _marketPriceKindCd;

        /// <summary>���ꉿ�i�i���R�[�h</summary>
        private Int32 _marketPriceQualityCd;

        /// <summary>���ʑ��ꉿ�i</summary>
        /// <remarks>����T�[�r�X�Ŏ擾�������ʑ��ꉿ�i</remarks>
        private Int64 _dstrMarketPrice;

        /// <summary>���ꉿ�i</summary>
        /// <remarks>�Z�o��̑��ꉿ�i</remarks>
        private Int64 _marketPrice;

        /// <summary>���ꉿ�i�n�於��</summary>
        private string _marketPriceAreaNm = "";

        /// <summary>���ꉿ�i��ʖ���</summary>
        private string _marketPriceKindNm = "";

        /// <summary>���ꉿ�i�i������</summary>
        private string _marketPriceQualityNm = "";

        /// <summary>BL���i�R�[�h</summary>
        private Int32 _bLGoodsCode;

        /// <summary>���i���̃J�i</summary>
        private string _goodsNameKana = "";

        /// <summary>BL���i�R�[�h����</summary>
        private string _bLGoodsName = "";


        /// public propaty name  :  MarketPriceAreaCd
        /// <summary>���ꉿ�i�n��R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�n��R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MarketPriceAreaCd
        {
            get { return _marketPriceAreaCd; }
            set { _marketPriceAreaCd = value; }
        }

        /// public propaty name  :  MarketPriceKindCd
        /// <summary>���ꉿ�i��ʃR�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i��ʃR�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MarketPriceKindCd
        {
            get { return _marketPriceKindCd; }
            set { _marketPriceKindCd = value; }
        }

        /// public propaty name  :  MarketPriceQualityCd
        /// <summary>���ꉿ�i�i���R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�i���R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 MarketPriceQualityCd
        {
            get { return _marketPriceQualityCd; }
            set { _marketPriceQualityCd = value; }
        }

        /// public propaty name  :  DstrMarketPrice
        /// <summary>���ʑ��ꉿ�i�v���p�e�B</summary>
        /// <value>����T�[�r�X�Ŏ擾�������ʑ��ꉿ�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ʑ��ꉿ�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 DstrMarketPrice
        {
            get { return _dstrMarketPrice; }
            set { _dstrMarketPrice = value; }
        }

        /// public propaty name  :  MarketPrice
        /// <summary>���ꉿ�i�v���p�e�B</summary>
        /// <value>�Z�o��̑��ꉿ�i</value>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int64 MarketPrice
        {
            get { return _marketPrice; }
            set { _marketPrice = value; }
        }

        /// public propaty name  :  MarketPriceAreaNm
        /// <summary>���ꉿ�i�n�於�̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�n�於�̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MarketPriceAreaNm
        {
            get { return _marketPriceAreaNm; }
            set { _marketPriceAreaNm = value; }
        }

        /// public propaty name  :  MarketPriceKindNm
        /// <summary>���ꉿ�i��ʖ��̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i��ʖ��̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MarketPriceKindNm
        {
            get { return _marketPriceKindNm; }
            set { _marketPriceKindNm = value; }
        }

        /// public propaty name  :  MarketPriceQualityNm
        /// <summary>���ꉿ�i�i�����̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���ꉿ�i�i�����̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string MarketPriceQualityNm
        {
            get { return _marketPriceQualityNm; }
            set { _marketPriceQualityNm = value; }
        }

        /// public propaty name  :  BLGoodsCode
        /// <summary>BL���i�R�[�h�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public Int32 BLGoodsCode
        {
            get { return _bLGoodsCode; }
            set { _bLGoodsCode = value; }
        }

        /// public propaty name  :  GoodsNameKana
        /// <summary>���i���̃J�i�v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   ���i���̃J�i�v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string GoodsNameKana
        {
            get { return _goodsNameKana; }
            set { _goodsNameKana = value; }
        }

        /// public propaty name  :  BLGoodsName
        /// <summary>BL���i�R�[�h���̃v���p�e�B</summary>
        /// ----------------------------------------------------------------------
        /// <remarks>
        /// <br>note             :   BL���i�R�[�h���̃v���p�e�B</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public string BLGoodsName
        {
            get { return _bLGoodsName; }
            set { _bLGoodsName = value; }
        }


        /// <summary>
        /// ���ꉿ�i���R���X�g���N�^
        /// </summary>
        /// <returns>MarketPriceInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MarketPriceInfo()
        {
        }

        /// <summary>
        /// ���ꉿ�i���R���X�g���N�^
        /// </summary>
        /// <param name="marketPriceAreaCd">���ꉿ�i�n��R�[�h</param>
        /// <param name="marketPriceKindCd">���ꉿ�i��ʃR�[�h</param>
        /// <param name="marketPriceQualityCd">���ꉿ�i�i���R�[�h</param>
        /// <param name="dstrMarketPrice">���ʑ��ꉿ�i(����T�[�r�X�Ŏ擾�������ʑ��ꉿ�i)</param>
        /// <param name="marketPrice">���ꉿ�i(�Z�o��̑��ꉿ�i)</param>
        /// <param name="marketPriceAreaNm">���ꉿ�i�n�於��</param>
        /// <param name="marketPriceKindNm">���ꉿ�i��ʖ���</param>
        /// <param name="marketPriceQualityNm">���ꉿ�i�i������</param>
        /// <param name="bLGoodsCode">BL���i�R�[�h</param>
        /// <param name="goodsNameKana">���i���̃J�i</param>
        /// <param name="bLGoodsName">BL���i�R�[�h����</param>
        /// <returns>MarketPriceInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceInfo�N���X�̐V�����C���X�^���X�𐶐����܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MarketPriceInfo( Int32 marketPriceAreaCd, Int32 marketPriceKindCd, Int32 marketPriceQualityCd, Int64 dstrMarketPrice, Int64 marketPrice, string marketPriceAreaNm, string marketPriceKindNm, string marketPriceQualityNm, Int32 bLGoodsCode, string goodsNameKana, string bLGoodsName )
        {
            this._marketPriceAreaCd = marketPriceAreaCd;
            this._marketPriceKindCd = marketPriceKindCd;
            this._marketPriceQualityCd = marketPriceQualityCd;
            this._dstrMarketPrice = dstrMarketPrice;
            this._marketPrice = marketPrice;
            this._marketPriceAreaNm = marketPriceAreaNm;
            this._marketPriceKindNm = marketPriceKindNm;
            this._marketPriceQualityNm = marketPriceQualityNm;
            this._bLGoodsCode = bLGoodsCode;
            this._goodsNameKana = goodsNameKana;
            this._bLGoodsName = bLGoodsName;

        }

        /// <summary>
        /// ���ꉿ�i��񕡐�����
        /// </summary>
        /// <returns>MarketPriceInfo�N���X�̃C���X�^���X</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   ���g�̓��e�Ɠ�����MarketPriceInfo�N���X�̃C���X�^���X��Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public MarketPriceInfo Clone()
        {
            return new MarketPriceInfo( this._marketPriceAreaCd, this._marketPriceKindCd, this._marketPriceQualityCd, this._dstrMarketPrice, this._marketPrice, this._marketPriceAreaNm, this._marketPriceKindNm, this._marketPriceQualityNm, this._bLGoodsCode, this._goodsNameKana, this._bLGoodsName );
        }

        /// <summary>
        /// ���ꉿ�i����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�MarketPriceInfo�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceInfo�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public bool Equals( MarketPriceInfo target )
        {
            return ((this.MarketPriceAreaCd == target.MarketPriceAreaCd)
                 && (this.MarketPriceKindCd == target.MarketPriceKindCd)
                 && (this.MarketPriceQualityCd == target.MarketPriceQualityCd)
                 && (this.DstrMarketPrice == target.DstrMarketPrice)
                 && (this.MarketPrice == target.MarketPrice)
                 && (this.MarketPriceAreaNm == target.MarketPriceAreaNm)
                 && (this.MarketPriceKindNm == target.MarketPriceKindNm)
                 && (this.MarketPriceQualityNm == target.MarketPriceQualityNm)
                 && (this.BLGoodsCode == target.BLGoodsCode)
                 && (this.GoodsNameKana == target.GoodsNameKana)
                 && (this.BLGoodsName == target.BLGoodsName));
        }

        /// <summary>
        /// ���ꉿ�i����r����
        /// </summary>
        /// <param name="marketPriceInfo1">
        ///                    ��r����MarketPriceInfo�N���X�̃C���X�^���X
        /// </param>
        /// <param name="marketPriceInfo2">��r����MarketPriceInfo�N���X�̃C���X�^���X</param>
        /// <returns>���e����v���邩�ۂ�(true:���e�͈�v����Afalse:���e�͈�v���Ȃ�)</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceInfo�N���X�̓��e����v���邩��r���܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static bool Equals( MarketPriceInfo marketPriceInfo1, MarketPriceInfo marketPriceInfo2 )
        {
            return ((marketPriceInfo1.MarketPriceAreaCd == marketPriceInfo2.MarketPriceAreaCd)
                 && (marketPriceInfo1.MarketPriceKindCd == marketPriceInfo2.MarketPriceKindCd)
                 && (marketPriceInfo1.MarketPriceQualityCd == marketPriceInfo2.MarketPriceQualityCd)
                 && (marketPriceInfo1.DstrMarketPrice == marketPriceInfo2.DstrMarketPrice)
                 && (marketPriceInfo1.MarketPrice == marketPriceInfo2.MarketPrice)
                 && (marketPriceInfo1.MarketPriceAreaNm == marketPriceInfo2.MarketPriceAreaNm)
                 && (marketPriceInfo1.MarketPriceKindNm == marketPriceInfo2.MarketPriceKindNm)
                 && (marketPriceInfo1.MarketPriceQualityNm == marketPriceInfo2.MarketPriceQualityNm)
                 && (marketPriceInfo1.BLGoodsCode == marketPriceInfo2.BLGoodsCode)
                 && (marketPriceInfo1.GoodsNameKana == marketPriceInfo2.GoodsNameKana)
                 && (marketPriceInfo1.BLGoodsName == marketPriceInfo2.BLGoodsName));
        }
        /// <summary>
        /// ���ꉿ�i����r����
        /// </summary>
        /// <param name="target">��r�Ώۂ�MarketPriceInfo�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceInfo�N���X�̓��e����v���邩��r�����A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public ArrayList Compare( MarketPriceInfo target )
        {
            ArrayList resList = new ArrayList();
            if ( this.MarketPriceAreaCd != target.MarketPriceAreaCd ) resList.Add( "MarketPriceAreaCd" );
            if ( this.MarketPriceKindCd != target.MarketPriceKindCd ) resList.Add( "MarketPriceKindCd" );
            if ( this.MarketPriceQualityCd != target.MarketPriceQualityCd ) resList.Add( "MarketPriceQualityCd" );
            if ( this.DstrMarketPrice != target.DstrMarketPrice ) resList.Add( "DstrMarketPrice" );
            if ( this.MarketPrice != target.MarketPrice ) resList.Add( "MarketPrice" );
            if ( this.MarketPriceAreaNm != target.MarketPriceAreaNm ) resList.Add( "MarketPriceAreaNm" );
            if ( this.MarketPriceKindNm != target.MarketPriceKindNm ) resList.Add( "MarketPriceKindNm" );
            if ( this.MarketPriceQualityNm != target.MarketPriceQualityNm ) resList.Add( "MarketPriceQualityNm" );
            if ( this.BLGoodsCode != target.BLGoodsCode ) resList.Add( "BLGoodsCode" );
            if ( this.GoodsNameKana != target.GoodsNameKana ) resList.Add( "GoodsNameKana" );
            if ( this.BLGoodsName != target.BLGoodsName ) resList.Add( "BLGoodsName" );

            return resList;
        }

        /// <summary>
        /// ���ꉿ�i����r����
        /// </summary>
        /// <param name="marketPriceInfo1">��r����MarketPriceInfo�N���X�̃C���X�^���X</param>
        /// <param name="marketPriceInfo2">��r����MarketPriceInfo�N���X�̃C���X�^���X</param>
        /// <returns>��v���Ȃ����ڂ̃��X�g</returns>
        /// <remarks>
        /// <br>Note�@�@�@�@�@�@ :   MarketPriceInfo�N���X�̓��e����v���邩��r���A��v���Ȃ����ڂ̖��̂�Ԃ��܂�</br>
        /// <br>Programer        :   ��������</br>
        /// </remarks>
        public static ArrayList Compare( MarketPriceInfo marketPriceInfo1, MarketPriceInfo marketPriceInfo2 )
        {
            ArrayList resList = new ArrayList();
            if ( marketPriceInfo1.MarketPriceAreaCd != marketPriceInfo2.MarketPriceAreaCd ) resList.Add( "MarketPriceAreaCd" );
            if ( marketPriceInfo1.MarketPriceKindCd != marketPriceInfo2.MarketPriceKindCd ) resList.Add( "MarketPriceKindCd" );
            if ( marketPriceInfo1.MarketPriceQualityCd != marketPriceInfo2.MarketPriceQualityCd ) resList.Add( "MarketPriceQualityCd" );
            if ( marketPriceInfo1.DstrMarketPrice != marketPriceInfo2.DstrMarketPrice ) resList.Add( "DstrMarketPrice" );
            if ( marketPriceInfo1.MarketPrice != marketPriceInfo2.MarketPrice ) resList.Add( "MarketPrice" );
            if ( marketPriceInfo1.MarketPriceAreaNm != marketPriceInfo2.MarketPriceAreaNm ) resList.Add( "MarketPriceAreaNm" );
            if ( marketPriceInfo1.MarketPriceKindNm != marketPriceInfo2.MarketPriceKindNm ) resList.Add( "MarketPriceKindNm" );
            if ( marketPriceInfo1.MarketPriceQualityNm != marketPriceInfo2.MarketPriceQualityNm ) resList.Add( "MarketPriceQualityNm" );
            if ( marketPriceInfo1.BLGoodsCode != marketPriceInfo2.BLGoodsCode ) resList.Add( "BLGoodsCode" );
            if ( marketPriceInfo1.GoodsNameKana != marketPriceInfo2.GoodsNameKana ) resList.Add( "GoodsNameKana" );
            if ( marketPriceInfo1.BLGoodsName != marketPriceInfo2.BLGoodsName ) resList.Add( "BLGoodsName" );

            return resList;
        }
    }
}
