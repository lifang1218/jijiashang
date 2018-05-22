var FeedbackUtil = {
	feed:function(feedbackurl) {
		var stylehtml = '<style>';
		stylehtml += '#feedback_popup_wrap{z-index:100199; background:rgba(0, 0, 0, 0.35); filter:progid:DXImageTransform.Microsoft.gradient(startColorstr=#55000000, endColorstr=#55000000);';
		stylehtml += ' -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#55000000, endColorstr=#55000000)";}';
		stylehtml += '#feedback_popup h2, #feedback_popup h2 .close, .pop_box .button, .pop_box .button_fd, .loginlist li span, .pop_login li.cwts em{ background:url(../source/img/layer_sprite.jpg) no-repeat;} ';
		stylehtml += '#feedback_popup { background:rgba(0, 0, 0, 0.20); filter:progid:DXImageTransform.Microsoft.gradient(startColorstr=#44000000, endColorstr=#44000000);';
		stylehtml += ' -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#44000000, endColorstr=#44000000)"; clear:both; left:50%; margin-left:0px;    padding:4px; position:absolute; top:300px; width:auto; z-index:100299;}';
		stylehtml += '#feedback_popup h2{ background-position:left top; background-repeat:repeat-x; height:33px; line-height:33px; border:1px solid #475529; border-bottom:1px solid #71a205; padding-left:12px; color:#000; font-size:12px; font-weight:normal; overflow:hidden; width:548px;}';
		stylehtml += '#feedback_popup h2 .close { background-position:-90px -35px; cursor:pointer; float:right; width:12px; height:12px; margin:10px 10px 0 0; _display:inline; z-index:10; overflow:hidden;}';
		stylehtml += '#feedback_popup .pop_line{ background:url(../source/img/layer_btbg.jpg) no-repeat bottom center; clear:both; height:12px; margin-bottom:30px;}';
		stylehtml += '#feedback_popup .pop_box{ width:560px; background:#fff; padding:30px 0; border:1px solid #666; border-top:0;}';
		stylehtml += '#feedback_popup .pop_box a.green{ text-decoration:underline; font-size:12px; color:#557917;}';
		stylehtml += '#feedback_popup .pop_box a.red{ text-decoration:underline; font-size:14px; color:#FF4800;}';
		stylehtml += '#feedback_popup .pop_box a:hover{ text-decoration:underline; color:#557917;}';
		stylehtml += '#feedback_popup .pop_box .button{ background-position:0 -35px; float:left; width:85px; height:32px; cursor:pointer; border:0; font-size:14px; color:#fff; font-weight:bold; line-height:32px;}';

		stylehtml += '.pop_login{ height:auto; overflow:hidden; zoom:1; padding-left:70px; position:relative;}';
		stylehtml += '.pop_login li{ clear:both; height:42px; overflow:hidden; line-height:27px;zoom:1; }';
		stylehtml += '.pop_login li .l{ width:94px; text-align:right; font-size:14px; float:left;}';
		stylehtml += '.pop_login li .r{ float:left;}';
		stylehtml += '.pop_login li .r .input{ float:left; width:188px; height:25px; overflow:hidden; border:1px solid #bbb; background-color:#E5E5E5; margin-right:10px;}';
		stylehtml += '.pop_login li .r .wid{ width:84px;}';
		stylehtml += '.pop_login li .r .input input, .pop_login #login_username, .pop_login #login_password, .pop_login #tcentry ul .zcinput, .pop_login #tcentry ul .yzinput, .pop_login #feedback_popup_main ul input{ width:176px; height:23px; line-height:23px; padding:0 5px; border:0; margin:1px 2px 0 0; font-size:12px;}';
		stylehtml += '.pop_login li .r .wid input{ width:83px;}';
		stylehtml += '.pop_login li .r .t_right{ float:left; width:18px; height:18px; background-position:-2546px -17px; margin-top:5px;display:none;}';
		stylehtml += '.pop_login li .r .t_wrong{float:left;font-style: normal; margin-left:6px; display:inline; width:135px; height:25px; line-height:25px; border:1px solid #FF4E01; color:#FF4E01; background-color:#FFECE5; padding:0 7px; position:relative;display:none;}';
		stylehtml += '.pop_login li .r .t_wrong em{ width:7px; height:11px; position:absolute; left:-7px; top:7px; background-position:-2572px -24px;}';
		stylehtml += '.pop_login li.yzm .r .t_wrong{ width:90px;}';
		stylehtml += '.pop_login li .r label{ float:left; color:#999;}';
		stylehtml += '.pop_login li .r img{ float:left; margin-right:10px;}';
		stylehtml += '.pop_login li .r a{ float:left; margin-right:10px;color:#FF4800;}';
		stylehtml += '.pop_login .yzm .r a{ color:#272727;}';
		stylehtml += '.pop_login li .r strong{ font-size:14px; float:left; margin-right:10px;}';
		stylehtml += '.pop_login .yhxy{}';
		stylehtml += '.pop_login .yhxy .r input{ float:left; margin:7px 7px 0 0; *margin-top:3px;}';
		stylehtml += '.pop_login .yhxy .r p{ float:left; color:#666;}';
		stylehtml += '.pop_login .yhxy .r p a{ float:none;}';
		stylehtml += '.pop_login .zc p{ float:left; color:#707070;}';
		stylehtml += '.pop_login .zc p a{ float:none; color:#FF5000; text-decoration:underline;}';
		stylehtml += '.pop_login .zc p a:hover{ text-decoration:none;}';
		stylehtml += '.pop_login.h30 li{ height:30px;}';
		stylehtml += '.pop_login.h30 li .l{ width:58px;}';
		stylehtml += '.pop_login li.cwts { background-color:#FFECE5; border:1px solid #FF4E01; color:#FF4E01; height:52px; line-height:18px; overflow:visible; padding:15px 7px 0;  position:absolute; right:35px; top:0; width:140px;}';
		stylehtml += '.pop_login li.cwts em { background-position:-90px -50px; display:block; height:11px; left:-7px; position:absolute; top:27px; width:7px;}';

		stylehtml += '.pop_login_p1, .pop_login_p2{ margin:0 0 10px 70px;}';
		stylehtml += '.pop_login_p1{ font-size:14px; color:#333; margin-bottom:20px;}';
		stylehtml += '.pop_login_p2{ font-size:12px; color:#666;}';

		stylehtml += '#feedback_popup .loginlist{ padding-left:10px; background:#f7f7f7; overflow:hidden; width:400px; margin-left:70px;}';
		stylehtml += '#feedback_popup .loginlist li{ height:36px; line-height:36px; float:left; padding-right:20px;}';
		stylehtml += '#feedback_popup .loginlist li span{ padding:3px 8px;}';
		stylehtml += '#feedback_popup .loginlist li.rr span{ background-position:0 -129px;}';
		stylehtml += '#feedback_popup .loginlist li.sina span{ background-position:-22px -129px;}';
		stylehtml += '#feedback_popup .loginlist li.kx span{ background-position:-44px -129px;}';
		stylehtml += '#feedback_popup .loginlist li.qq span{ background-position:-66px -129px;}';
		stylehtml += '.PopupBox{position:absolute;left:450px;top:70px;z-index:100799;border:5px solid #D5DCD0;height:39px;_display:inline;_clear:both;}';
		stylehtml += '.PopupBox .PopupBox_c{background-color:#fff;border:1px solid #B7C2B1;color:#666;line-height:37px;height:37px;padding-right:40px;_display:inline;}';
		stylehtml += '.PopupBox .PopupBox_c .success{float:left;width:24px;height:20px;background-position:0 -1558px;margin:8px 10px 0 15px;display:inline;}';
		stylehtml += '.PopupBox .PopupBox_c .failure{float:left;width:24px;height:24px;background-position:0 -1582px;margin:6px 10px 0 15px;display:inline;}';
		stylehtml += '.PopupBox .PopupBox_c .loading{display:inline;float:left;margin:10px 10px 0 20px;}';

		stylehtml += '</style>';

		var bghtml= '<div style="position: absolute; left: 0px; top: 0px; width: 903px; height: 83px; display: block;" id="feedback_popup_wrap"></div>';
		var html = stylehtml+bghtml;

		html +='<div id="feedback_popup">';
		html +='<form  id="feedback_form" target="feedback_iframe" method="POST">';
		html +='<input type="hidden" name="url" value="'+window.location.href+'" />';
		html +='<h2><a href="javascript:void(0);" target="_self" onclick="FeedbackUtil.close();return false;" class="close"></a>留言</h2>';
		html +='<div class="pop_box">';
		html +='<!-- 登录框 s -->';
			html +='<ul class="pop_login" style="padding-left:10px;">';
				html +='<li><span class="l">您的手机号：</span>';
					html +='<span class="r">';
						html +='<span class="input"><input type="text"  tabindex="1" id="fb_email" name="fb_email"></span>';
						html +='<em class="t_right"></em><em class="t_wrong" id="email_wrong">手机号<em></em></em><label id="email_label">输入您的手机号</label>';
					html +='</span>';
				html +='</li>';
				html +='<li style="height:200px;width:100%"><span class="l">留言：</span>';
					html +='<span class="r" style="width:400px;height:100%">';
						html +='<span class="input" style="width:400px;height:180px">';
							html +='<textarea tabindex="2" onclick="FeedbackUtil.onfocus();" style="width:400px;height:180px;color:#999999;font-size:14px;line-height:18px;" rows="" cols="" id="fb_content" name="content" >请在这里输入您的留言。</textarea>';
						html +='</span>';
					html +='</span>';
				html +='</li>';
				html +='<li ><p style="padding-left:90px;color:#999999" id="content_tip">留言内容请控制在1000字以内</p></li>';
				html +='<li class="zc">';
					html +='<span class="l">&nbsp;</span>';
					html +='<input type="button" onclick="FeedbackUtil.send(\''+feedbackurl+'\')" value="提    交" class="button" tabindex="7">';
				html +='</li>';
			html +='</ul>';
			html +='</div>';
			html +='<!-- 登录框 e -->';
			html +='</form>';
			html +='<iframe name="feedback_iframe" id="feedback_iframe"  style="display:none"></iframe>';
			html +='</div>';

		if(!$("#feedback_popup")[0]) {
			$('body').append(html);
		}

		var top = $(document).scrollTop()+parseInt(($(window).height()-$('#feedback_popup').height())/2);
		var left = $(document).scrollLeft()+parseInt(($(window).width()-$('#feedback_popup').width())/2);
		$('#feedback_popup').show().css({'left':left,'top':top});

		$('#feedback_popup_wrap').show().css({width:$(document).width(),height:$(document).height()});

		$('object[name=UmiwiMediaPlayback]').css('visibility', 'hidden');
		$('embed[name=UmiwiMediaPlayback]').css('visibility', 'hidden');

		$(document).keydown(function(event){
			if(event.keyCode == 27){
				FeedbackUtil.close();
			} else if(event.keyCode == 13){
				//FeedbackUtil.send(feedbackurl);
			}
		});

	},


	send:function(feedbackurl) {
		var email = $('#fb_email').val();
		var content = $('#fb_content').val();
		var filter=/^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$/
		if (!filter.test(email)) {

			$("#email_wrong").html('Email格式错误').show();
			$("#email_label").hide();
			return '';
		}

		if(content == '') {

			$("#content_tip").html('留言内容不能为空');
			return '';
		}

		var url = window.location.href;
		$.getScript('http://sc.chinaz.com/?app=web&t='+Date.parse(new Date())+'&email='+encodeURIComponent(email)+'&content='+encodeURIComponent(content)+'&url='+encodeURIComponent(url));
		FeedbackUtil.tip('succ', '您的留言提交成功，我们会尽快联系您!');
		FeedbackUtil.close();
 

	},

	callback:function(code){
		if(code == 'succ') {
			FeedbackUtil.close();
			FeedbackUtil.tip('succ', '您的留言提交成功，我们会尽快联系您反馈!');
		} else {
			FeedbackUtil.tip('fail', '提交失败，请返回重试');
		}
	},

	close:function(){
		$('#feedback_popup_wrap').hide();
		$('#feedback_popup').hide();
		$('object[name=UmiwiMediaPlayback]').css('visibility', 'visible');
		$('embed[name=UmiwiMediaPlayback]').css('visibility', 'visible');

	},

	onfocus:function(){
		if($("#fb_content").val() == '请在这里输入的留言。'){
			$("#fb_content").val('')
		}

	},

	codehtml:{
		'audit':'<div class="PopupBox_c"><span class="success"></span>',
		'succ':'<div class="PopupBox_c"><span class="success"></span>',
		'fail':'<div class="PopupBox_c"><span class="failure"></span>',
		'same':'<div class="PopupBox_c"><span class="success"></span>',
		'wait':'<div class="PopupBox_c"><img src="../source/img/loading.gif" class="loading" />'
	},

	tip:function(code, msg, obj )
	{
		if(typeof code == 'undefined')return;
		if(typeof msg == 'undefined')
		{
			msg='';
		}
		if(code=='wait')
		{
			if(msg=='')msg='加载中...';

		}

		var pophtml = '<div class="PopupBox" id="PopupBox" style="display:none;"><div class="PopupBox_c"><span class="success"></span>留言成功！</div></div>';
		if(!$('#PopupBox')[0]) {
			$('body').append(pophtml);
		}

		$('#PopupBox').html(this.codehtml[code]+msg+'</div>');

		if(obj)
		{
			var pos = $(obj).offset();

			$('#PopupBox').show().css({'left':(pos.left-20),'top':(pos.top-5-$('#PopupBox').outerHeight())});

		}else
		{
			var top = $(document).scrollTop()+parseInt(($(window).height()-$('#PopupBox').height())/2);
			var left = $(document).scrollLeft()+parseInt(($(window).width()-$('#PopupBox').width())/2);
			$('#PopupBox').show().css({'left':left,'top':top});
		}
		if(code=='succ'|| code=='fail' || code=='same' || code == 'audit')
		{

			if(typeof MsgHandle != 'undefined')
			{
				clearTimeout(MsgHandle);
			}
			MsgHandle = setTimeout(function(){$('#PopupBox').fadeOut(500);},2000);
		}

	}

};


