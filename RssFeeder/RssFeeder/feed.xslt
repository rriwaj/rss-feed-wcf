<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="/">
    <html lang="en" xmlns="http://www.w3.org/1999/xhtml">
      <head>
        <title>Creating Rss feed with xslt styles. </title>
        <link rel="stylesheet" type="text/css" href="/Contents/Styles/feed.css"/>
      </head>
      <body>
        <div class="rssWrapper">
          <div class="rssHeader">
            <xsl:for-each select="rss/channel">
              <div class="rssFeedTitle" style="color: #00aeef;">
                <xsl:value-of select ="title"></xsl:value-of>
                <img src="{image/url}" style="float:right;"/>
              </div>
              <div class="rssFeedDescription">
                <p>
                  <xsl:value-of select ="description"></xsl:value-of>
                </p>
                <p>
                  Language: <xsl:value-of select ="language"></xsl:value-of>
                </p>
                <p>
                  <xsl:value-of select ="copyright"></xsl:value-of>
                </p>
              </div>
            </xsl:for-each>
          </div>
          <div class="rssFeeds">
            <div class="rssFeedTitle"> Recent Posts</div>
            <xsl:for-each select="rss/channel/item">
              <div class="rssFeedItem">
                <div class="rssFeedItemHeading">
                  <a href="{link}" rel="bookmark">
                    <xsl:value-of select ="title"></xsl:value-of>
                  </a>
                </div>
                <div class="rssFeedItemDateAuthor">
                  <p>
                    <span class="rssDimText">Posted on: </span>
                    <xsl:value-of select="pubDate"/>
                  </p>
                  <p>
                    <span class="rssDimText"> Author: </span>
                    <xsl:value-of select ="author"></xsl:value-of>
                  </p>
                </div>
                <div class="rssFeedItemSummary">
                  <xsl:value-of select="description"/>
                </div>
              </div>

            </xsl:for-each>
          </div>

        </div>

      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>