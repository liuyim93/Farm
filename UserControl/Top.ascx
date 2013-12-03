<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Top.ascx.cs" Inherits="UserControl_Top" %>
<div class="uc_top">
    <div class="uc_top_logo">
        <a href="Index.aspx" target="_self"><img src="Images/logo.jpg" alt="" width="440px" height="70px" /></a>
    </div>
    <div class="uc_top_menu">
        <ul>
            <li><a href="Index.aspx" target="_self">首页</a></li>
            <li><img src="Images/menu_mid.png" / width="1px" height="35px"></li>
            <li><a href="FarmIntro.aspx" target="_self">农家简介</a></li>
            <li><img src="Images/menu_mid.png" / width="1px" height="35px"></li>
            <li><a href="House_Default.aspx" target="_self">住宿设施</a></li>
            <li><img src="Images/menu_mid.png" / width="1px" height="35px"></li>
            <li><a href="" target="_self">农家菜肴</a></li>
            <li><img src="Images/menu_mid.png" / width="1px" height="35px"></li>
            <li><a href="" target="_self">农家娱乐</a></li>
            <li><img src="Images/menu_mid.png" / width="1px" height="35px"></li>
            <li><a href="" target="_self">农家荣誉</a></li>
            <li><img src="Images/menu_mid.png" / width="1px" height="35px"></li>
            <li><a href="" target="_self">周边景点</a></li>
            <li><img src="Images/menu_mid.png" / width="1px" height="35px"></li>
            <li><a href="" target="_self">最新动态</a></li>
            <li><img src="Images/menu_mid.png" / width="1px" height="35px"></li>
            <li><a href="" target="_self">联系我们</a></li>
        </ul>
    </div>
    <div id="picplayer">        
    </div>
     <script type="text/javascript">
                    var p = $('#picplayer');
                    var pics1 = [{ url: 'Images/banner1.jpg', link: 'http://www.jb51.net/#', time: 5000 }, { url: 'Images/banner2.jpg', link: 'http://www.jb51.net/#', time: 4000 },
{ url: '../Images/banner3.jpg', link: 'http://www.jb51.net', time: 6000 }, { url: 'http://img.jb51.net/online/picPlayer/2.jpg', link: 'http://www.jb51.net', time: 6000 },
{ url: 'http://img.jb51.net/online/picPlayer/1.jpg', link: 'http://www.jb51.net', time: 6000}];
                    initPicPlayer(pics1, p.css('width').split('px')[0], p.css('height').split('px')[0]);
                    function initPicPlayer(pics, w, h) {
                        //选中的图片 
                        var selectedItem;
                        //选中的按钮 
                        var selectedBtn;
                        //自动播放的id 
                        var playID;
                        //选中图片的索引 
                        var selectedIndex;
                        //容器 
                        var p = $('#picplayer');
                        p.text('');
                        p.append('<div id="piccontent"></div>');
                        var c = $('#piccontent');
                        for (var i = 0; i < pics.length; i++) {
                            //添加图片到容器中 
                            c.append('<a href="' + pics[i].link + '" target="_blank"><img id="picitem' + i + '" style="display: none;z-index:' + i + '" src="' + pics[i].url + '" /></a>');
                        }
                        //按钮容器，绝对定位在右下角 
                        p.append('<div id="picbtnHolder" style="position:absolute;top:' + (h - 30) + 'px;width:' + w + 'px;height:20px;z-index:10000;"></div>');
                        // 
                        var btnHolder = $('#picbtnHolder');
                        btnHolder.append('<div id="picbtns" style="float:right; padding-right:10px;"></div>');
                        var btns = $('#picbtns');
                        // 
                        for (var i = 0; i < pics.length; i++) {
                            //增加图片对应的按钮 
                            btns.append('<span id="picbtn' + i + '" style="cursor:pointer; border:solid 1px #ccc;background-color:#eee; display:inline-block;width:16px;height:16px;text-align:center;margin-left:1px;"> ' + (i + 1) + ' </span> ');
                            $('#picbtn' + i).data('index', i);
                            $('#picbtn' + i).click(
                        function (event) {
                            if (selectedItem.attr('src') == $('#picitem' + $(this).data('index')).attr('src')) {
                                return;
                            }
                            setSelectedItem($(this).data('index'));
                        }
                    );
                        }
                        btns.append(' ');
                        /// 
                        setSelectedItem(0);
                        //显示指定的图片index 
                        function setSelectedItem(index) {
                            selectedIndex = index;
                            clearInterval(playID);
                            //alert(index); 
                            if (selectedItem) selectedItem.fadeOut('fast');
                            selectedItem = $('#picitem' + index);
                            selectedItem.fadeIn('slow');
                            // 
                            if (selectedBtn) {
                                selectedBtn.css('backgroundColor', '#eee');
                                selectedBtn.css('color', '#000');
                            }
                            selectedBtn = $('#picbtn' + index);
                            selectedBtn.css('backgroundColor', '#8f0100');
                            selectedBtn.css('color', '#fff');
                            //自动播放 
                            playID = setInterval(function () {
                                var index = selectedIndex + 1;
                                if (index > pics.length - 1) index = 0;
                                setSelectedItem(index);
                            }, pics[index].time);
                        }
                    }                  
    </script>
</div>