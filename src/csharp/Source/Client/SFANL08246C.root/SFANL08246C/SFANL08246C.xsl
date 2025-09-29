<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <xsl:apply-templates />
  </xsl:template>

  <xsl:template match="DataSet/WriteTable">
    <xsl:for-each select="*">
      <!-- Guid項目には{}を付ける -->
      <xsl:if test="name()='FileHeaderGuid'">{</xsl:if>
      <!-- 全ての列を列挙 -->
      <xsl:value-of select="text()"/>
      <!-- Guid項目には{}を付ける -->
      <xsl:if test="name()='FileHeaderGuid'">}</xsl:if>
      <!-- 列と列の間にカンマを挿入 -->
      <xsl:if test="position()!=last()">,</xsl:if>
      <!-- 最後の列の後には改行を入れる -->
      <xsl:if test="position()=last()"><xsl:text>&#13;&#10;</xsl:text></xsl:if>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>
