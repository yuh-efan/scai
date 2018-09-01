var Share={
                href:encodeURIComponent(encodeURIComponent(location.href)),
                title:encodeURIComponent(encodeURIComponent(document.title)),
                titleS:[],
                imgS:[],
                init:function()
                {
                    Share.titleS[0]="订阅到鲜果";
                    Share.titleS[1]="分享到人人网";
                    Share.titleS[2]="收藏到qq书签";
                    Share.titleS[3]="转贴到开心网";
                    Share.titleS[4]="收藏到豆瓣";
                    Share.titleS[5]="分享至新浪微博";
                    Share.titleS[6]="分享到Google Buzz";
                    Share.titleS[7]="分享到网易微博";  
                    
                    Share.imgS[0]="/images/share_xg.gif";
                    Share.imgS[1]="/images/share_rr.gif";
                    Share.imgS[2]="/images/share_qq.gif";
                    Share.imgS[3]="/images/share_ks.gif";
                    Share.imgS[4]="/images/share_db.gif";
                    Share.imgS[5]="/images/share_xl.gif";
                    Share.imgS[6]="/images/share_gg.gif";
                    Share.imgS[7]="/images/share_wy.gif";
                },
                write:function()
                {
                    Share.init();
                    var p="width=930,height=470,left=50,top=50,toolbar=no,menubar=no,location=no,scrollbars=yes,status=yes,resizable=yes"
                    var s="";
                    
                    s+="<a href=javascript:window.open('http://www.xianguo.com/service/submitfav/?link="+Share.href+"&title="+Share.title+"','favit0','"+p+"');void(0) title='"+Share.titleS[0]+"'>";
                    s+="<img src='"+Share.imgS[0]+"' />";
                    s+="</a>";
                    
                    s+="<a href=javascript:window.open('http://share.renren.com/share/buttonshare.do?link="+Share.href+"&title="+Share.title+"','favit1','"+p+"');void(0) title='"+Share.titleS[1]+"'>";
                    s+="<img src='"+Share.imgS[1]+"' />";
                    s+="</a>";
                    
                    s+="<a href=javascript:window.open('http://shuqian.qq.com/post?from=3&uri="+Share.href+"&title="+Share.title+"&jumpback=2&noui=1','favit2','"+p+"');void(0) title='"+Share.titleS[2]+"'>";
                    s+="<img src='"+Share.imgS[2]+"' />";
                    s+="</a>";
                    
                    s+="<a href=javascript:window.open('http://www.kaixin001.com/repaste/share.php?&rurl="+Share.href+"&rtitle="+Share.title+"&rcontent="+Share.title+""+Share.href+"','favit3','"+p+"');void(0) title='"+Share.titleS[3]+"'>";
                    s+="<img src='"+Share.imgS[3]+"' />";
                    s+="</a>";
                    
                    
                    s+="<a href=javascript:window.open('http://www.douban.com/recommend/?url="+Share.href+"&title="+Share.title+"','favit4','"+p+"');void(0) title='"+Share.titleS[4]+"'>";
                    s+="<img src='"+Share.imgS[4]+"' />";
                    s+="</a>";
                    
                    s+="<a href=javascript:window.open('http://v.t.sina.com.cn/share/share.php?url="+Share.href+"&title="+Share.title+"&source=bookmark','favit5','"+p+"');void(0) title='"+Share.titleS[5]+"'>";
                    s+="<img src='"+Share.imgS[5]+"' />";
                    s+="</a>";
                    
                    s+="<a href=javascript:window.open('http://www.google.com/reader/link?url="+Share.href+"&title="+Share.title+"&snippet="+Share.title+""+Share.href+"&srcUrl="+Share.href+"&srcTitle="+encodeURIComponent(encodeURIComponent('搜菜网'))+"','favit6','"+p+"');void(0) title='"+Share.titleS[6]+"'>";
                    s+="<img src='"+Share.imgS[6]+"' />";
                    s+="</a>";
                    
                    s+="<a href=javascript:window.open('http://t.163.com/article/user/checkLogin.do?link="+Share.href+"&source="+encodeURIComponent(encodeURIComponent('网易跟贴'))+"&info="+Share.title+""+Share.href+"','favit7','"+p+"');void(0) title='"+Share.titleS[7]+"'>";
                    s+="<img src='"+Share.imgS[7]+"' />";
                    s+="</a>";
                    
                    document.write(s);
                }
            }
            Share.write();