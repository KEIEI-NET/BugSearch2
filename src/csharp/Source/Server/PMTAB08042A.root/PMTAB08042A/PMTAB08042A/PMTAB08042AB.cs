//****************************************************************************//
// �V�X�e��         : PM-Tablet
// �v���O��������   : ���i�ڍ׏��JSON�N���X
// �v���O�����T�v   : ���i�ڍ׏��JSON�f�[�^��߂�B
//----------------------------------------------------------------------------//
//                (c)Copyright  2017 Broadleaf Co.,Ltd.
//============================================================================//
// ����
//----------------------------------------------------------------------------//
// �Ǘ��ԍ�  11370090-00  �쐬�S�� : chenyk
// �� �� ��  2017.11.02   �C�����e : �V�K�쐬
//----------------------------------------------------------------------------//
using System;
using System.Collections.Generic;
using System.Text;

namespace Broadleaf.Application.Controller
{
    /// <summary>
    /// ���i�ڍ׏��JSON�N���X
    /// </summary>
    /// <remarks>
    /// <br>Note       : ���i�ڍ׏��JSON�N���X������s���܂��B</br>
    /// <br>Programmer : chenyk</br>
    /// <br>Date       : 2017.11.02</br>
    /// </remarks>
    public class JSPartsDetailInfo
    {
        #region Private Members
        /// <summary>���[�J�[�R�[�h</summary>
        private int PartsMakerCodeField;
        /// <summary>���[�J�[��</summary>
        private string PartsMakerFullNameField = "";
        /// <summary>�i��</summary>
        private string PrimePartsNameField = "";
        /// <summary>�i��</summary>
        private string PrimePartsNoField = "";
        /// <summary>���i����</summary>
        private string GoodsDetailDescField = "";
        /// <summary>���L</summary>
        private string PrimePartsSpecialNoteField = "";
        /// <summary>���[�J�[���z�[���y�[�WURL</summary>
        private string PrmPartsMakerUrlField = "";
        /// <summary>�J�^���O���y�[�WURL</summary>
        private string PrmPartsCatalogUriField = "";
        /// <summary>���i���y�[�WURL</summary>
        private string PrmPtDescMovieUriField = "";
        /// <summary>���@�i�����j�i���i���@�P�ʕt���j</summary>
        private string GoodsSizeLengthWithUnitField = "";
        /// <summary>���@�i���j�i���i���@�P�ʕt���j</summary>
        private string GoodsSizeWidthWithUnitField = "";
        /// <summary>���@�i�����j�i���i���@�P�ʕt���j</summary>
        private string GoodsSizeHeightWithUnitField = "";
        /// <summary>�����@�i�����j�i���i�����@�P�ʕt���j</summary>
        private string GoodsPkgBoxLengthWithUnitField = "";
        /// <summary>�����@�i���j�i���i�����@�P�ʕt���j</summary>
        private string GoodsPkgBoxWidthWithUnitField = "";
        /// <summary>�����@�i�����j�i���i�����@�P�ʕt���j</summary>
        private string GoodsPkgBoxHeightWithUnitField = "";
        /// <summary>���i�e�ʁi���i���e�ʒP�ʕt���j</summary>
        private string GoodsVolumeWithUnitField = "";
        /// <summary>���i�d�ʁi���i�d�ʒP�ʕt���j</summary>
        private string GoodsWeightWithUnitField = "";
        /// <summary>���i�T���l�C���摜�L���敪</summary>
        private short GoodsTmbImgExtDivField;
        /// <summary>�摜1</summary>
        private string GoodsTmbImgFlName1Field = "";
        /// <summary>�摜2</summary>
        private string GoodsTmbImgFlName2Field = "";
        /// <summary>�摜3</summary>
        private string GoodsTmbImgFlName3Field = "";
        /// <summary>�摜4</summary>
        private string GoodsTmbImgFlName4Field = "";
        /// <summary>�摜5</summary>
        private string GoodsTmbImgFlName5Field = "";
        /// <summary>�摜6</summary>
        private string GoodsTmbImgFlName6Field = "";
        /// <summary>�摜7</summary>
        private string GoodsTmbImgFlName7Field = "";
        /// <summary>�摜8</summary>
        private string GoodsTmbImgFlName8Field = "";
        /// <summary>�摜9</summary>
        private string GoodsTmbImgFlName9Field = "";
        /// <summary>�̔��I�����i�p�ԓ��t�j</summary>
        private string CarPrtsDiscontDateField = "";
        #endregion

        #region Property
        /// <summary>
        /// ���[�J�[�R�[�h
        /// </summary>
        public int PartsMakerCode
        {
            get { return PartsMakerCodeField; }
            set { PartsMakerCodeField = value; }
        }
        /// <summary>
        /// ���[�J�[��
        /// </summary>
        public string PartsMakerFullName
        {
            get { return PartsMakerFullNameField; }
            set { PartsMakerFullNameField = value; }
        }
        /// <summary>
        /// �i��
        /// </summary>
        public string PrimePartsName
        {
            get { return PrimePartsNameField; }
            set { PrimePartsNameField = value; }
        }
        /// <summary>
        /// �i��
        /// </summary>
        public string PrimePartsNo
        {
            get { return PrimePartsNoField; }
            set { PrimePartsNoField = value; }
        }
        /// <summary>
        /// ���i����
        /// </summary>
        public string GoodsDetailDesc
        {
            get { return GoodsDetailDescField; }
            set { GoodsDetailDescField = value; }
        }
        /// <summary>
        /// ���L
        /// </summary>
        public string PrimePartsSpecialNote
        {
            get { return PrimePartsSpecialNoteField; }
            set { PrimePartsSpecialNoteField = value; }
        }
        /// <summary>
        /// ���[�J�[���z�[���y�[�WURL
        /// </summary>
        public string PrmPartsMakerUrl
        {
            get { return PrmPartsMakerUrlField; }
            set { PrmPartsMakerUrlField = value; }
        }
        /// <summary>
        /// �J�^���O���y�[�WURL
        /// </summary>
        public string PrmPartsCatalogUri
        {
            get { return PrmPartsCatalogUriField; }
            set { PrmPartsCatalogUriField = value; }
        }
        /// <summary>
        /// ���i���y�[�WURL
        /// </summary>
        public string PrmPtDescMovieUri
        {
            get { return PrmPtDescMovieUriField; }
            set { PrmPtDescMovieUriField = value; }
        }
        /// <summary>
        /// ���@�i�����j�i���i���@�P�ʕt���j
        /// </summary>
        public string GoodsSizeLengthWithUnit
        {
            get { return GoodsSizeLengthWithUnitField; }
            set { GoodsSizeLengthWithUnitField = value; }
        }
        /// <summary>
        /// ���@�i���j�i���i���@�P�ʕt���j
        /// </summary>
        public string GoodsSizeWidthWithUnit
        {
            get { return GoodsSizeWidthWithUnitField; }
            set { GoodsSizeWidthWithUnitField = value; }
        }
        /// <summary>
        /// ���@�i�����j�i���i���@�P�ʕt���j
        /// </summary>
        public string GoodsSizeHeightWithUnit
        {
            get { return GoodsSizeHeightWithUnitField; }
            set { GoodsSizeHeightWithUnitField = value; }
        }
        /// <summary>
        /// �����@�i�����j�i���i�����@�P�ʕt���j
        /// </summary>
        public string GoodsPkgBoxLengthWithUnit
        {
            get { return GoodsPkgBoxLengthWithUnitField; }
            set { GoodsPkgBoxLengthWithUnitField = value; }
        }
        /// <summary>
        /// �����@�i���j�i���i�����@�P�ʕt���j
        /// </summary>
        public string GoodsPkgBoxWidthWithUnit
        {
            get { return GoodsPkgBoxWidthWithUnitField; }
            set { GoodsPkgBoxWidthWithUnitField = value; }
        }
        /// <summary>
        /// �����@�i�����j�i���i�����@�P�ʕt���j
        /// </summary>
        public string GoodsPkgBoxHeightWithUnit
        {
            get { return GoodsPkgBoxHeightWithUnitField; }
            set { GoodsPkgBoxHeightWithUnitField = value; }
        }
        /// <summary>
        /// ���i�e�ʁi���i���e�ʒP�ʕt���j
        /// </summary>
        public string GoodsVolumeWithUnit
        {
            get { return GoodsVolumeWithUnitField; }
            set { GoodsVolumeWithUnitField = value; }
        }
        /// <summary>
        /// ���i�d�ʁi���i�d�ʒP�ʕt���j
        /// </summary>
        public string GoodsWeightWithUnit
        {
            get { return GoodsWeightWithUnitField; }
            set { GoodsWeightWithUnitField = value; }
        }
        /// <summary>
        /// ���i�T���l�C���摜�L���敪
        /// </summary>
        public short GoodsTmbImgExtDiv
        {
            get { return GoodsTmbImgExtDivField; }
            set { GoodsTmbImgExtDivField = value; }
        }
        /// <summary>
        /// �摜1
        /// </summary>
        public string GoodsTmbImgFlName1
        {
            get { return GoodsTmbImgFlName1Field; }
            set { GoodsTmbImgFlName1Field = value; }
        }
        /// <summary>
        /// �摜2
        /// </summary>
        public string GoodsTmbImgFlName2
        {
            get { return GoodsTmbImgFlName2Field; }
            set { GoodsTmbImgFlName2Field = value; }
        }
        /// <summary>
        /// �摜3
        /// </summary>
        public string GoodsTmbImgFlName3
        {
            get { return GoodsTmbImgFlName3Field; }
            set { GoodsTmbImgFlName3Field = value; }
        }
        /// <summary>
        /// �摜4
        /// </summary>
        public string GoodsTmbImgFlName4
        {
            get { return GoodsTmbImgFlName4Field; }
            set { GoodsTmbImgFlName4Field = value; }
        }
        /// <summary>
        /// �摜5
        /// </summary>
        public string GoodsTmbImgFlName5
        {
            get { return GoodsTmbImgFlName5Field; }
            set { GoodsTmbImgFlName5Field = value; }
        }
        /// <summary>
        /// �摜6
        /// </summary>
        public string GoodsTmbImgFlName6
        {
            get { return GoodsTmbImgFlName6Field; }
            set { GoodsTmbImgFlName6Field = value; }
        }
        /// <summary>
        /// �摜7
        /// </summary>
        public string GoodsTmbImgFlName7
        {
            get { return GoodsTmbImgFlName7Field; }
            set { GoodsTmbImgFlName7Field = value; }
        }
        /// <summary>
        /// �摜8
        /// </summary>
        public string GoodsTmbImgFlName8
        {
            get { return GoodsTmbImgFlName8Field; }
            set { GoodsTmbImgFlName8Field = value; }
        }
        /// <summary>
        /// �摜9
        /// </summary>
        public string GoodsTmbImgFlName9
        {
            get { return GoodsTmbImgFlName9Field; }
            set { GoodsTmbImgFlName9Field = value; }
        }
        /// <summary>
        /// �̔��I�����i�p�ԓ��t�j
        /// </summary>
        public string CarPrtsDiscontDate
        {
            get { return CarPrtsDiscontDateField; }
            set { CarPrtsDiscontDateField = value; }
        }
        #endregion
    }
}
