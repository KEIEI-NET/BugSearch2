using System;
using System.Collections;
using System.Collections.Generic;
using Broadleaf.Application.Remoting.ParamData;

namespace Broadleaf.Application.Common
{

	/// <summary>
	/// �Z���K�C�h�Ŏg�����߂̋��ʃC���^�[�t�F�C�X
	/// �X�֔ԍ��}�X�^�ƏZ���}�X�^�ŋ���
	/// </summary>
	/// <remarks>
	/// <br>Note       : </br>
	/// <br>Programmer : 23011�@����@���N</br>
	/// <br>Date       : 2006.01.06</br>
	/// <br></br>
	/// <br>Update Note: </br>
	/// </remarks>
	public interface IMergeableAddressAcs
	{
		/// <summary>
		/// �w��Z���R�[�h�̏Z�����擾����̂Ɏg��
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="code2"></param>
		/// <param name="code3"></param>
		/// <param name="code4"></param>
		/// <param name="code5"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddressWork( int code1, long code2, int code3, int code4, int code5, out ArrayList alResult );
		
		/// <summary>
		/// �R�[�h�P�ɂԂ牺������̂��擾
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddrIndexWork2( int code1, out ArrayList alResult);
		
		/// <summary>
		/// �R�[�h�Q�ɂԂ牺������̂��擾
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="code2"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddrIndexWork3( int code1, long code2, out ArrayList alResult);
		
		/// <summary>
		/// �R�[�h�R�ɂԂ牺������̂��擾
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="code2"></param>
		/// <param name="code3"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddrIndexWork4( int code1, long code2, int code3, out ArrayList alResult);
		
		/// <summary>
		/// �R�[�h�S�ɂԂ牺������̂��擾
		/// </summary>
		/// <param name="code1"></param>
		/// <param name="code2"></param>
		/// <param name="code3"></param>
		/// <param name="code4"></param>
		/// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddrIndexWork5( int code1, long code2, int code3, int code4, out ArrayList alResult);
		
		/// <summary>
		/// �X�֔ԍ��̃L�[���[�h����Z������������
		/// �R�[�h�͕����擾�̌��݈ʒu���������߂Ɏg��
		/// </summary>
		/// <param name="keyword"></param>
        /// <param name="alResult"></param>
		/// <returns></returns>
		int GetAddressWorkFromZipCd( string keyword, out ICollection alResult );
		
        ///// <summary>
        ///// �w��̗X�֔ԍ��L�[���[�h�ɊY�����錏�����擾����
        ///// </summary>
        ///// <param name="keyword"></param>
        ///// <param name="intCount"></param>
        ///// <returns></returns>
        //int GetCountFromZipCd( string keyword, out int intCount );
		
        /// <summary>
        /// �w��ǋ悩��L�[���[�h�ŏZ�����擾����
        /// </summary>
        /// <param name="areaGroup"></param>
        /// <param name="addrkey"></param>
        /// <param name="resultList"></param>
        /// <returns></returns>
		int GetAddrFromName( int areaGroup, string addrkey, out ICollection resultList );
		
        ///// <summary>
        ///// �w��L�[���[�h�ɊY������Z���̌������擾����
        ///// </summary>
        ///// <param name="addrkey"></param>
        ///// <param name="intCount"></param>
        ///// <returns></returns>
        //int GetCountFromName( string addrkey, out int intCount );
		
        ///// <summary>
        ///// ���ݔ񓯊����[�h�����ǂ���
        ///// </summary>
        //bool NowLoading
        //{
        //    get;
        //}
		
		/// <summary>
		/// �X�e�[�^�X�o�[�ɕ\�����镶������擾����
		/// </summary>
		string StatusBarString
		{
			get;
		}
		
		/// <summary>
		/// �\���O���b�h�̐����擾����
		/// </summary>
		int DisplayGridCount
		{
			get;
		}
		
	}
	
}
