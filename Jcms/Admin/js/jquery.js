/* [jQuery List DragSort] */
	
// jQuery List DragSort v0.4.1
// License: http://dragsort.codeplex.com/license
(function(b){b.fn.dragsort=function(o){var e=b.extend({},b.fn.dragsort.defaults,o),j=[],a=null,l=null;this.selector&&b("head").append("<style type='text/css'>"+(this.selector.split(",").join(" "+e.dragSelector+",")+" "+e.dragSelector)+" { cursor: move; }</style>");this.each(function(p,k){if(b(k).is("table")&&b(k).children().size()==1&&b(k).children().is("tbody"))k=b(k).children().get(0);var n={draggedItem:null,placeHolderItem:null,pos:null,offset:null,offsetLimit:null,scroll:null,container:k,init:function(){b(this.container).attr("data-listIdx", p).mousedown(this.grabItem).find(e.dragSelector).css("cursor","move");b(this.container).children(e.itemSelector).each(function(d){b(this).attr("data-itemIdx",d)})},grabItem:function(d){if(!(d.which!=1||b(d.target).is(e.dragSelectorExclude))){for(var c=d.target;!b(c).is("[data-listIdx='"+b(this).attr("data-listIdx")+"'] "+e.dragSelector);){if(c==this)return;c=c.parentNode}a!=null&&a.draggedItem!=null&&a.dropItem();b(d.target).css("cursor","move");a=j[b(this).attr("data-listIdx")];a.draggedItem= b(c).closest(e.itemSelector);c=parseInt(a.draggedItem.css("marginTop"));var f=parseInt(a.draggedItem.css("marginLeft"));a.offset=a.draggedItem.offset();a.offset.top=d.pageY-a.offset.top+(isNaN(c)?0:c)-1;a.offset.left=d.pageX-a.offset.left+(isNaN(f)?0:f)-1;if(!e.dragBetween){c=b(a.container).outerHeight()==0?Math.max(1,Math.round(0.5+b(a.container).children(e.itemSelector).size()*a.draggedItem.outerWidth()/b(a.container).outerWidth()))*a.draggedItem.outerHeight():b(a.container).outerHeight();a.offsetLimit= b(a.container).offset();a.offsetLimit.right=a.offsetLimit.left+b(a.container).outerWidth()-a.draggedItem.outerWidth();a.offsetLimit.bottom=a.offsetLimit.top+c-a.draggedItem.outerHeight()}c=a.draggedItem.height();f=a.draggedItem.width();var h=a.draggedItem.attr("style");a.draggedItem.attr("data-origStyle",h?h:"");if(e.itemSelector=="tr"){a.draggedItem.children().each(function(){b(this).width(b(this).width())});a.placeHolderItem=a.draggedItem.clone().attr("data-placeHolder",true);a.draggedItem.after(a.placeHolderItem); a.placeHolderItem.children().each(function(){b(this).css({borderWidth:0,width:b(this).width()+1,height:b(this).height()+1}).html("&nbsp;")})}else{a.draggedItem.after(e.placeHolderTemplate);a.placeHolderItem=a.draggedItem.next().css({height:c,width:f}).attr("data-placeHolder",true)}a.draggedItem.css({position:"absolute",opacity:0.8,"z-index":999,height:c,width:f});b(j).each(function(g,i){i.createDropTargets();i.buildPositionTable()});a.scroll={moveX:0,moveY:0,maxX:b(document).width()-b(window).width(), maxY:b(document).height()-b(window).height()};a.scroll.scrollY=window.setInterval(function(){if(e.scrollContainer!=window)b(e.scrollContainer).scrollTop(b(e.scrollContainer).scrollTop()+a.scroll.moveY);else{var g=b(e.scrollContainer).scrollTop();if(a.scroll.moveY>0&&g<a.scroll.maxY||a.scroll.moveY<0&&g>0){b(e.scrollContainer).scrollTop(g+a.scroll.moveY);a.draggedItem.css("top",a.draggedItem.offset().top+a.scroll.moveY+1)}}},10);a.scroll.scrollX=window.setInterval(function(){if(e.scrollContainer!= window)b(e.scrollContainer).scrollLeft(b(e.scrollContainer).scrollLeft()+a.scroll.moveX);else{var g=b(e.scrollContainer).scrollLeft();if(a.scroll.moveX>0&&g<a.scroll.maxX||a.scroll.moveX<0&&g>0){b(e.scrollContainer).scrollLeft(g+a.scroll.moveX);a.draggedItem.css("left",a.draggedItem.offset().left+a.scroll.moveX+1)}}},10);a.setPos(d.pageX,d.pageY);b(document).bind("selectstart",a.stopBubble);b(document).bind("mousemove",a.swapItems);b(document).bind("mouseup",a.dropItem);e.scrollContainer!=window&& b(window).bind("DOMMouseScroll mousewheel",a.wheel);return false}},setPos:function(d,c){var f=c-this.offset.top,h=d-this.offset.left;if(!e.dragBetween){f=Math.min(this.offsetLimit.bottom,Math.max(f,this.offsetLimit.top));h=Math.min(this.offsetLimit.right,Math.max(h,this.offsetLimit.left))}this.draggedItem.parents().each(function(){if(b(this).css("position")!="static"&&(!b.browser.mozilla||b(this).css("display")!="table")){var m=b(this).offset();f-=m.top;h-=m.left;return false}});if(e.scrollContainer== window){c-=b(window).scrollTop();d-=b(window).scrollLeft();c=Math.max(0,c-b(window).height()+5)+Math.min(0,c-5);d=Math.max(0,d-b(window).width()+5)+Math.min(0,d-5)}else{var g=b(e.scrollContainer),i=g.offset();c=Math.max(0,c-g.height()-i.top)+Math.min(0,c-i.top);d=Math.max(0,d-g.width()-i.left)+Math.min(0,d-i.left)}a.scroll.moveX=d==0?0:d*e.scrollSpeed/Math.abs(d);a.scroll.moveY=c==0?0:c*e.scrollSpeed/Math.abs(c);this.draggedItem.css({top:f,left:h})},wheel:function(d){if((b.browser.safari||b.browser.mozilla)&& a&&e.scrollContainer!=window){var c=b(e.scrollContainer),f=c.offset();if(d.pageX>f.left&&d.pageX<f.left+c.width()&&d.pageY>f.top&&d.pageY<f.top+c.height()){f=d.detail?d.detail*5:d.wheelDelta/-2;c.scrollTop(c.scrollTop()+f);d.preventDefault()}}},buildPositionTable:function(){var d=this.draggedItem==null?null:this.draggedItem.get(0),c=[];b(this.container).children(e.itemSelector).each(function(f,h){if(h!=d){var g=b(h).offset();g.right=g.left+b(h).width();g.bottom=g.top+b(h).height();g.elm=h;c.push(g)}}); this.pos=c},dropItem:function(){if(a.draggedItem!=null){b(a.container).find(e.dragSelector).css("cursor","move");a.placeHolderItem.before(a.draggedItem);var d=a.draggedItem.attr("data-origStyle");if(d=="")a.draggedItem.removeAttr("style");else{a.draggedItem.attr("style",d);a.removeAttr("data-origStyle")}a.placeHolderItem.remove();b("[data-dropTarget]").remove();window.clearInterval(a.scroll.scrollY);window.clearInterval(a.scroll.scrollX);var c=false;b(j).each(function(){b(this.container).children(e.itemSelector).each(function(f){if(parseInt(b(this).attr("data-itemIdx"))!= f){c=true;b(this).attr("data-itemIdx",f)}})});c&&e.dragEnd.apply(a.draggedItem);a.draggedItem=null;b(document).unbind("selectstart",a.stopBubble);b(document).unbind("mousemove",a.swapItems);b(document).unbind("mouseup",a.dropItem);e.scrollContainer!=window&&b(window).unbind("DOMMouseScroll mousewheel",a.wheel);return false}},stopBubble:function(){return false},swapItems:function(d){if(a.draggedItem==null)return false;a.setPos(d.pageX,d.pageY);for(var c=a.findPos(d.pageX,d.pageY),f=a,h=0;c==-1&&e.dragBetween&& h<j.length;h++){c=j[h].findPos(d.pageX,d.pageY);f=j[h]}if(c==-1||b(f.pos[c].elm).attr("data-placeHolder"))return false;l==null||l.top>a.draggedItem.offset().top||l.left>a.draggedItem.offset().left?b(f.pos[c].elm).before(a.placeHolderItem):b(f.pos[c].elm).after(a.placeHolderItem);b(j).each(function(g,i){i.createDropTargets();i.buildPositionTable()});l=a.draggedItem.offset();return false},findPos:function(d,c){for(var f=0;f<this.pos.length;f++)if(this.pos[f].left<d&&this.pos[f].right>d&&this.pos[f].top< c&&this.pos[f].bottom>c)return f;return-1},createDropTargets:function(){e.dragBetween&&b(j).each(function(){var d=b(this.container).find("[data-placeHolder]"),c=b(this.container).find("[data-dropTarget]");if(d.size()>0&&c.size()>0)c.remove();else d.size()==0&&c.size()==0&&b(this.container).append(a.placeHolderItem.clone().removeAttr("data-placeHolder").attr("data-dropTarget",true))})}};n.init();j.push(n)});return this};b.fn.dragsort.defaults={itemSelector:"li",dragSelector:"li",dragSelectorExclude:"input, textarea, a[href]", dragEnd:function(){},dragBetween:false,placeHolderTemplate:"<li>&nbsp;</li>",scrollContainer:window,scrollSpeed:5}})(jQuery);
/* [/End jQuery List DragSort] */







/* [jqModal] */
/*
 * jqModal - Minimalist Modaling with jQuery
 *   (http://dev.iceburg.net/jquery/jqModal/)
 *
 * Copyright (c) 2007,2008 Brice Burgess <bhb@iceburg.net>
 * Dual licensed under the MIT and GPL licenses:
 *   http://www.opensource.org/licenses/mit-license.php
 *   http://www.gnu.org/licenses/gpl.html
 * 
 * $Version: 03/01/2009 +r14
 */
(function($) {
$.fn.jqm=function(o){
var p={
overlay: 50,
overlayClass: 'jqmOverlay',
closeClass: 'jqmClose',
trigger: '.jqModal',
ajax: F,
ajaxText: '',
target: F,
modal: F,
toTop: F,
onShow: F,
onHide: F,
onLoad: F
};
return this.each(function(){if(this._jqm)return H[this._jqm].c=$.extend({},H[this._jqm].c,o);s++;this._jqm=s;
H[s]={c:$.extend(p,$.jqm.params,o),a:F,w:$(this).addClass('jqmID'+s),s:s};
if(p.trigger)$(this).jqmAddTrigger(p.trigger);
});};

$.fn.jqmAddClose=function(e){return hs(this,e,'jqmHide');};
$.fn.jqmAddTrigger=function(e){return hs(this,e,'jqmShow');};
$.fn.jqmShow=function(t){return this.each(function(){t=t||window.event;$.jqm.open(this._jqm,t);});};
$.fn.jqmHide=function(t){return this.each(function(){t=t||window.event;$.jqm.close(this._jqm,t)});};

$.jqm = {
hash:{},
open:function(s,t){var h=H[s],c=h.c,cc='.'+c.closeClass,z=(parseInt(h.w.css('z-index'))),z=(z>0)?z:3000,o=$('<div></div>').css({height:'100%',width:'100%',position:'fixed',left:0,top:0,'z-index':z-1,opacity:c.overlay/100});if(h.a)return F;h.t=t;h.a=true;h.w.css('z-index',z);
 if(c.modal) {if(!A[0])L('bind');A.push(s);}
 else if(c.overlay > 0)h.w.jqmAddClose(o);
 else o=F;

 h.o=(o)?o.addClass(c.overlayClass).prependTo('body'):F;
 if(ie6){$('html,body').css({height:'100%',width:'100%'});if(o){o=o.css({position:'absolute'})[0];for(var y in {Top:1,Left:1})o.style.setExpression(y.toLowerCase(),"(_=(document.documentElement.scroll"+y+" || document.body.scroll"+y+"))+'px'");}}

 if(c.ajax) {var r=c.target||h.w,u=c.ajax,r=(typeof r == 'string')?$(r,h.w):$(r),u=(u.substr(0,1) == '@')?$(t).attr(u.substring(1)):u;
  r.html(c.ajaxText).load(u,function(){if(c.onLoad)c.onLoad.call(this,h);if(cc)h.w.jqmAddClose($(cc,h.w));e(h);});}
 else if(cc)h.w.jqmAddClose($(cc,h.w));

 if(c.toTop&&h.o)h.w.before('<span id="jqmP'+h.w[0]._jqm+'"></span>').insertAfter(h.o);	
 (c.onShow)?c.onShow(h):h.w.show();e(h);return F;
},
close:function(s){var h=H[s];if(!h.a)return F;h.a=F;
 if(A[0]){A.pop();if(!A[0])L('unbind');}
 if(h.c.toTop&&h.o)$('#jqmP'+h.w[0]._jqm).after(h.w).remove();
 if(h.c.onHide)h.c.onHide(h);else{h.w.hide();if(h.o)h.o.remove();} return F;
},
params:{}};
var s=0,H=$.jqm.hash,A=[],ie6=$.browser.msie&&($.browser.version == "6.0"),F=false,
i=$('<iframe src="javascript:false;document.write(\'\');" class="jqm"></iframe>').css({opacity:0}),
e=function(h){if(ie6)if(h.o)h.o.html('<p style="width:100%;height:100%"/>').prepend(i);else if(!$('iframe.jqm',h.w)[0])h.w.prepend(i); f(h);},
f=function(h){try{$(':input:visible',h.w)[0].focus();}catch(_){}},
L=function(t){$()[t]("keypress",m)[t]("keydown",m)[t]("mousedown",m);},
m=function(e){var h=H[A[A.length-1]],r=(!$(e.target).parents('.jqmID'+h.s)[0]);if(r)f(h);return !r;},
hs=function(w,t,c){return w.each(function(){var s=this._jqm;$(t).each(function() {
 if(!this[c]){this[c]=[];$(this).click(function(){for(var i in {jqmShow:1,jqmHide:1})for(var s in this[i])if(H[this[i][s]])H[this[i][s]].w[i](this);return F;});}this[c].push(s);});});};
})(jQuery);
/* [/End jqModal] */





/* [Shadowbox] */

/*
 * Shadowbox.js, version 3.0.3
 * http://shadowbox-js.com/
 *
 * Copyright 2007-2010, Michael J. I. Jackson
 * Date: 2011-01-16 17:05:49 +0000
 */
(function(T,p){var g={version:"3.0.3"};var Y=navigator.userAgent.toLowerCase();if(Y.indexOf("windows")>-1||Y.indexOf("win32")>-1){g.isWindows=true}else{if(Y.indexOf("macintosh")>-1||Y.indexOf("mac os x")>-1){g.isMac=true}else{if(Y.indexOf("linux")>-1){g.isLinux=true}}}g.isIE=Y.indexOf("msie")>-1;g.isIE6=Y.indexOf("msie 6")>-1;g.isIE7=Y.indexOf("msie 7")>-1;g.isGecko=Y.indexOf("gecko")>-1&&Y.indexOf("safari")==-1;g.isWebKit=Y.indexOf("applewebkit/")>-1;var e=/#(.+)$/,M=/^(light|shadow)box\[(.*?)\]/i,o=/\s*([a-z_]*?)\s*=\s*(.+)\s*/,ar=/[0-9a-z]+$/i,ap=/(.+\/)shadowbox\.js/i;var w=false,m=false,V={},ai=0,O,aa;g.current=-1;g.dimensions=null;g.ease=function(K){return 1+Math.pow(K-1,3)};g.errorInfo={fla:{name:"Flash",url:"http://www.adobe.com/products/flashplayer/"},qt:{name:"QuickTime",url:"http://www.apple.com/quicktime/download/"},wmp:{name:"Windows Media Player",url:"http://www.microsoft.com/windows/windowsmedia/"},f4m:{name:"Flip4Mac",url:"http://www.flip4mac.com/wmv_download.htm"}};g.gallery=[];g.onReady=aj;g.path=null;g.player=null;g.playerId="sb-player";g.options={animate:true,animateFade:true,autoplayMovies:true,continuous:false,enableKeys:true,flashParams:{bgcolor:"#000000",allowfullscreen:true},flashVars:{},flashVersion:"9.0.115",handleOversize:"resize",handleUnsupported:"link",onChange:aj,onClose:aj,onFinish:aj,onOpen:aj,showMovieControls:true,skipSetup:false,slideshowDelay:0,viewportPadding:20};g.getCurrent=function(){return g.current>-1?g.gallery[g.current]:null};g.hasNext=function(){return g.gallery.length>1&&(g.current!=g.gallery.length-1||g.options.continuous)};g.isOpen=function(){return w};g.isPaused=function(){return aa=="pause"};g.applyOptions=function(K){V=ao({},g.options);ao(g.options,K)};g.revertOptions=function(){ao(g.options,V)};g.init=function(au,ax){if(m){return}m=true;if(g.skin.options){ao(g.options,g.skin.options)}if(au){ao(g.options,au)}if(!g.path){var aw,S=document.getElementsByTagName("script");for(var av=0,K=S.length;av<K;++av){aw=ap.exec(S[av].src);if(aw){g.path=aw[1];break}}}if(ax){g.onReady=ax}aq()};g.open=function(S){if(w){return}var K=g.makeGallery(S);g.gallery=K[0];g.current=K[1];S=g.getCurrent();if(S==null){return}g.applyOptions(S.options||{});f();if(g.gallery.length){S=g.getCurrent();if(g.options.onOpen(S)===false){return}w=true;g.skin.onOpen(S,U)}};g.close=function(){if(!w){return}w=false;if(g.player){g.player.remove();g.player=null}if(typeof aa=="number"){clearTimeout(aa);aa=null}ai=0;af(false);g.options.onClose(g.getCurrent());g.skin.onClose();g.revertOptions()};g.play=function(){if(!g.hasNext()){return}if(!ai){ai=g.options.slideshowDelay*1000}if(ai){O=X();aa=setTimeout(function(){ai=O=0;g.next()},ai);if(g.skin.onPlay){g.skin.onPlay()}}};g.pause=function(){if(typeof aa!="number"){return}ai=Math.max(0,ai-(X()-O));if(ai){clearTimeout(aa);aa="pause";if(g.skin.onPause){g.skin.onPause()}}};g.change=function(K){if(!(K in g.gallery)){if(g.options.continuous){K=(K<0?g.gallery.length+K:0);if(!(K in g.gallery)){return}}else{return}}g.current=K;if(typeof aa=="number"){clearTimeout(aa);aa=null;ai=O=0}g.options.onChange(g.getCurrent());U(true)};g.next=function(){g.change(g.current+1)};g.previous=function(){g.change(g.current-1)};g.setDimensions=function(aG,ax,aE,aF,aw,K,aC,az){var aB=aG,av=ax;var aA=2*aC+aw;if(aG+aA>aE){aG=aE-aA}var au=2*aC+K;if(ax+au>aF){ax=aF-au}var S=(aB-aG)/aB,aD=(av-ax)/av,ay=(S>0||aD>0);if(az&&ay){if(S>aD){ax=Math.round((av/aB)*aG)}else{if(aD>S){aG=Math.round((aB/av)*ax)}}}g.dimensions={height:aG+aw,width:ax+K,innerHeight:aG,innerWidth:ax,top:Math.floor((aE-(aG+aA))/2+aC),left:Math.floor((aF-(ax+au))/2+aC),oversized:ay};return g.dimensions};g.makeGallery=function(aw){var K=[],av=-1;if(typeof aw=="string"){aw=[aw]}if(typeof aw.length=="number"){ac(aw,function(ay,az){if(az.content){K[ay]=az}else{K[ay]={content:az}}});av=0}else{if(aw.tagName){var S=g.getCache(aw);aw=S?S:g.makeObject(aw)}if(aw.gallery){K=[];var ax;for(var au in g.cache){ax=g.cache[au];if(ax.gallery&&ax.gallery==aw.gallery){if(av==-1&&ax.content==aw.content){av=K.length}K.push(ax)}}if(av==-1){K.unshift(aw);av=0}}else{K=[aw];av=0}}ac(K,function(ay,az){K[ay]=ao({},az)});return[K,av]};g.makeObject=function(av,au){var aw={content:av.href,title:av.getAttribute("title")||"",link:av};if(au){au=ao({},au);ac(["player","title","height","width","gallery"],function(ax,ay){if(typeof au[ay]!="undefined"){aw[ay]=au[ay];delete au[ay]}});aw.options=au}else{aw.options={}}if(!aw.player){aw.player=g.getPlayer(aw.content)}var K=av.getAttribute("rel");if(K){var S=K.match(M);if(S){aw.gallery=escape(S[2])}ac(K.split(";"),function(ax,ay){S=ay.match(o);if(S){aw[S[1]]=S[2]}})}return aw};g.getPlayer=function(au){if(au.indexOf("#")>-1&&au.indexOf(document.location.href)==0){return"inline"}var av=au.indexOf("?");if(av>-1){au=au.substring(0,av)}var S,K=au.match(ar);if(K){S=K[0].toLowerCase()}if(S){if(g.img&&g.img.ext.indexOf(S)>-1){return"img"}if(g.swf&&g.swf.ext.indexOf(S)>-1){return"swf"}if(g.flv&&g.flv.ext.indexOf(S)>-1){return"flv"}if(g.qt&&g.qt.ext.indexOf(S)>-1){if(g.wmp&&g.wmp.ext.indexOf(S)>-1){return"qtwmp"}else{return"qt"}}if(g.wmp&&g.wmp.ext.indexOf(S)>-1){return"wmp"}}return"iframe"};function f(){var av=g.errorInfo,aw=g.plugins,ay,az,aC,au,aB,S,aA,K;for(var ax=0;ax<g.gallery.length;++ax){ay=g.gallery[ax];az=false;aC=null;switch(ay.player){case"flv":case"swf":if(!aw.fla){aC="fla"}break;case"qt":if(!aw.qt){aC="qt"}break;case"wmp":if(g.isMac){if(aw.qt&&aw.f4m){ay.player="qt"}else{aC="qtf4m"}}else{if(!aw.wmp){aC="wmp"}}break;case"qtwmp":if(aw.qt){ay.player="qt"}else{if(aw.wmp){ay.player="wmp"}else{aC="qtwmp"}}break}if(aC){if(g.options.handleUnsupported=="link"){switch(aC){case"qtf4m":aB="shared";S=[av.qt.url,av.qt.name,av.f4m.url,av.f4m.name];break;case"qtwmp":aB="either";S=[av.qt.url,av.qt.name,av.wmp.url,av.wmp.name];break;default:aB="single";S=[av[aC].url,av[aC].name]}ay.player="html";ay.content='<div class="sb-message">'+s(g.lang.errors[aB],S)+"</div>"}else{az=true}}else{if(ay.player=="inline"){au=e.exec(ay.content);if(au){aA=ag(au[1]);if(aA){ay.content=aA.innerHTML}else{az=true}}else{az=true}}else{if(ay.player=="swf"||ay.player=="flv"){K=(ay.options&&ay.options.flashVersion)||g.options.flashVersion;if(g.flash&&!g.flash.hasFlashPlayerVersion(K)){ay.width=310;ay.height=177}}}}if(az){g.gallery.splice(ax,1);if(ax<g.current){--g.current}else{if(ax==g.current){g.current=ax>0?ax-1:ax}}--ax}}}function af(K){if(!g.options.enableKeys){return}(K?j:a)(document,"keydown",W)}function W(au){if(au.metaKey||au.shiftKey||au.altKey||au.ctrlKey){return}var S=l(au),K;switch(S){case 81:case 88:case 27:K=g.close;break;case 37:K=g.previous;break;case 39:K=g.next;break;case 32:K=typeof aa=="number"?g.pause:g.play;break}if(K){G(au);K()}}function U(ay){af(false);var ax=g.getCurrent();var au=(ax.player=="inline"?"html":ax.player);if(typeof g[au]!="function"){throw"unknown player "+au}if(ay){g.player.remove();g.revertOptions();g.applyOptions(ax.options||{})}g.player=new g[au](ax,g.playerId);if(g.gallery.length>1){var av=g.gallery[g.current+1]||g.gallery[0];if(av.player=="img"){var S=new Image();S.src=av.content}var aw=g.gallery[g.current-1]||g.gallery[g.gallery.length-1];if(aw.player=="img"){var K=new Image();K.src=aw.content}}g.skin.onLoad(ay,r)}function r(){if(!w){return}if(typeof g.player.ready!="undefined"){var K=setInterval(function(){if(w){if(g.player.ready){clearInterval(K);K=null;g.skin.onReady(J)}}else{clearInterval(K);K=null}},10)}else{g.skin.onReady(J)}}function J(){if(!w){return}g.player.append(g.skin.body,g.dimensions);g.skin.onShow(q)}function q(){if(!w){return}if(g.player.onLoad){g.player.onLoad()}g.options.onFinish(g.getCurrent());if(!g.isPaused()){g.play()}af(true)}if(!Array.prototype.indexOf){Array.prototype.indexOf=function(S,au){var K=this.length>>>0;au=au||0;if(au<0){au+=K}for(;au<K;++au){if(au in this&&this[au]===S){return au}}return -1}}function X(){return(new Date).getTime()}function ao(K,au){for(var S in au){K[S]=au[S]}return K}function ac(av,aw){var S=0,K=av.length;for(var au=av[0];S<K&&aw.call(au,S,au)!==false;au=av[++S]){}}function s(S,K){return S.replace(/\{(\w+?)\}/g,function(au,av){return K[av]})}function aj(){}function ag(K){return document.getElementById(K)}function z(K){K.parentNode.removeChild(K)}var ak=true,L=true;function an(){var K=document.body,S=document.createElement("div");ak=typeof S.style.opacity==="string";S.style.position="fixed";S.style.margin=0;S.style.top="20px";K.appendChild(S,K.firstChild);L=S.offsetTop==20;K.removeChild(S)}g.getStyle=(function(){var K=/opacity=([^)]*)/,S=document.defaultView&&document.defaultView.getComputedStyle;return function(ax,aw){var av;if(!ak&&aw=="opacity"&&ax.currentStyle){av=K.test(ax.currentStyle.filter||"")?(parseFloat(RegExp.$1)/100)+"":"";return av===""?"1":av}if(S){var au=S(ax,null);if(au){av=au[aw]}if(aw=="opacity"&&av==""){av="1"}}else{av=ax.currentStyle[aw]}return av}})();g.appendHTML=function(au,S){if(au.insertAdjacentHTML){au.insertAdjacentHTML("BeforeEnd",S)}else{if(au.lastChild){var K=au.ownerDocument.createRange();K.setStartAfter(au.lastChild);var av=K.createContextualFragment(S);au.appendChild(av)}else{au.innerHTML=S}}};g.getWindowSize=function(K){if(document.compatMode==="CSS1Compat"){return document.documentElement["client"+K]}return document.body["client"+K]};g.setOpacity=function(au,K){var S=au.style;if(ak){S.opacity=(K==1?"":K)}else{S.zoom=1;if(K==1){if(typeof S.filter=="string"&&(/alpha/i).test(S.filter)){S.filter=S.filter.replace(/\s*[\w\.]*alpha\([^\)]*\);?/gi,"")}}else{S.filter=(S.filter||"").replace(/\s*[\w\.]*alpha\([^\)]*\)/gi,"")+" alpha(opacity="+(K*100)+")"}}};g.clearOpacity=function(K){g.setOpacity(K,1)};function C(K){return K.target}function Q(K){return[K.pageX,K.pageY]}function G(K){K.preventDefault()}function l(K){return K.keyCode}function j(au,S,K){jQuery(au).bind(S,K)}function a(au,S,K){jQuery(au).unbind(S,K)}jQuery.fn.shadowbox=function(K){return this.each(function(){var au=jQuery(this);var av=jQuery.extend({},K||{},jQuery.metadata?au.metadata():jQuery.meta?au.data():{});var S=this.className||"";av.width=parseInt((S.match(/w:(\d+)/)||[])[1])||av.width;av.height=parseInt((S.match(/h:(\d+)/)||[])[1])||av.height;Shadowbox.setup(au,av)})};var D=false,N;if(document.addEventListener){N=function(){document.removeEventListener("DOMContentLoaded",N,false);g.load()}}else{if(document.attachEvent){N=function(){if(document.readyState==="complete"){document.detachEvent("onreadystatechange",N);g.load()}}}}function i(){if(D){return}try{document.documentElement.doScroll("left")}catch(K){setTimeout(i,1);return}g.load()}function aq(){if(document.readyState==="complete"){return g.load()}if(document.addEventListener){document.addEventListener("DOMContentLoaded",N,false);T.addEventListener("load",g.load,false)}else{if(document.attachEvent){document.attachEvent("onreadystatechange",N);T.attachEvent("onload",g.load);var K=false;try{K=T.frameElement===null}catch(S){}if(document.documentElement.doScroll&&K){i()}}}}g.load=function(){if(D){return}if(!document.body){return setTimeout(g.load,13)}D=true;an();g.onReady();if(!g.options.skipSetup){g.setup()}g.skin.init()};g.plugins={};if(navigator.plugins&&navigator.plugins.length){var am=[];ac(navigator.plugins,function(K,S){am.push(S.name)});am=am.join(",");var d=am.indexOf("Flip4Mac")>-1;g.plugins={fla:am.indexOf("Shockwave Flash")>-1,qt:am.indexOf("QuickTime")>-1,wmp:!d&&am.indexOf("Windows Media")>-1,f4m:d}}else{var B=function(K){var S;try{S=new ActiveXObject(K)}catch(au){}return !!S};g.plugins={fla:B("ShockwaveFlash.ShockwaveFlash"),qt:B("QuickTime.QuickTime"),wmp:B("wmplayer.ocx"),f4m:false}}var c=/^(light|shadow)box/i,Z="shadowboxCacheKey",h=1;g.cache={};g.select=function(S){var au=[];if(!S){var K;ac(document.getElementsByTagName("a"),function(ax,ay){K=ay.getAttribute("rel");if(K&&c.test(K)){au.push(ay)}})}else{var aw=S.length;if(aw){if(typeof S=="string"){if(g.find){au=g.find(S)}}else{if(aw==2&&typeof S[0]=="string"&&S[1].nodeType){if(g.find){au=g.find(S[0],S[1])}}else{for(var av=0;av<aw;++av){au[av]=S[av]}}}}else{au.push(S)}}return au};g.setup=function(K,S){ac(g.select(K),function(au,av){g.addCache(av,S)})};g.teardown=function(K){ac(g.select(K),function(S,au){g.removeCache(au)})};g.addCache=function(au,K){var S=au[Z];if(S==p){S=h++;au[Z]=S;j(au,"click",b)}g.cache[S]=g.makeObject(au,K)};g.removeCache=function(K){a(K,"click",b);delete g.cache[K[Z]];K[Z]=null};g.getCache=function(S){var K=S[Z];return(K in g.cache&&g.cache[K])};g.clearCache=function(){for(var K in g.cache){g.removeCache(g.cache[K].link)}g.cache={}};function b(K){g.open(this);if(g.gallery.length){G(K)}}
/*
 * Sizzle CSS Selector Engine - v1.0
 *  Copyright 2009, The Dojo Foundation
 *  Released under the MIT, BSD, and GPL Licenses.
 *  More information: http://sizzlejs.com/
 *
 * Modified for inclusion in Shadowbox.js
 */
g.find=(function(){var aD=/((?:\((?:\([^()]+\)|[^()]+)+\)|\[(?:\[[^[\]]*\]|['"][^'"]*['"]|[^[\]'"]+)+\]|\\.|[^ >+~,(\[\\]+)+|[>+~])(\s*,\s*)?((?:.|\r|\n)*)/g,aE=0,aG=Object.prototype.toString,ay=false,ax=true;[0,0].sort(function(){ax=false;return 0});var au=function(aP,aK,aS,aT){aS=aS||[];var aV=aK=aK||document;if(aK.nodeType!==1&&aK.nodeType!==9){return[]}if(!aP||typeof aP!=="string"){return aS}var aQ=[],aM,aX,a0,aL,aO=true,aN=av(aK),aU=aP;while((aD.exec(""),aM=aD.exec(aU))!==null){aU=aM[3];aQ.push(aM[1]);if(aM[2]){aL=aM[3];break}}if(aQ.length>1&&az.exec(aP)){if(aQ.length===2&&aA.relative[aQ[0]]){aX=aH(aQ[0]+aQ[1],aK)}else{aX=aA.relative[aQ[0]]?[aK]:au(aQ.shift(),aK);while(aQ.length){aP=aQ.shift();if(aA.relative[aP]){aP+=aQ.shift()}aX=aH(aP,aX)}}}else{if(!aT&&aQ.length>1&&aK.nodeType===9&&!aN&&aA.match.ID.test(aQ[0])&&!aA.match.ID.test(aQ[aQ.length-1])){var aW=au.find(aQ.shift(),aK,aN);aK=aW.expr?au.filter(aW.expr,aW.set)[0]:aW.set[0]}if(aK){var aW=aT?{expr:aQ.pop(),set:aC(aT)}:au.find(aQ.pop(),aQ.length===1&&(aQ[0]==="~"||aQ[0]==="+")&&aK.parentNode?aK.parentNode:aK,aN);aX=aW.expr?au.filter(aW.expr,aW.set):aW.set;if(aQ.length>0){a0=aC(aX)}else{aO=false}while(aQ.length){var aZ=aQ.pop(),aY=aZ;if(!aA.relative[aZ]){aZ=""}else{aY=aQ.pop()}if(aY==null){aY=aK}aA.relative[aZ](a0,aY,aN)}}else{a0=aQ=[]}}if(!a0){a0=aX}if(!a0){throw"Syntax error, unrecognized expression: "+(aZ||aP)}if(aG.call(a0)==="[object Array]"){if(!aO){aS.push.apply(aS,a0)}else{if(aK&&aK.nodeType===1){for(var aR=0;a0[aR]!=null;aR++){if(a0[aR]&&(a0[aR]===true||a0[aR].nodeType===1&&aB(aK,a0[aR]))){aS.push(aX[aR])}}}else{for(var aR=0;a0[aR]!=null;aR++){if(a0[aR]&&a0[aR].nodeType===1){aS.push(aX[aR])}}}}}else{aC(a0,aS)}if(aL){au(aL,aV,aS,aT);au.uniqueSort(aS)}return aS};au.uniqueSort=function(aL){if(aF){ay=ax;aL.sort(aF);if(ay){for(var aK=1;aK<aL.length;aK++){if(aL[aK]===aL[aK-1]){aL.splice(aK--,1)}}}}return aL};au.matches=function(aK,aL){return au(aK,null,null,aL)};au.find=function(aR,aK,aS){var aQ,aO;if(!aR){return[]}for(var aN=0,aM=aA.order.length;aN<aM;aN++){var aP=aA.order[aN],aO;if((aO=aA.leftMatch[aP].exec(aR))){var aL=aO[1];aO.splice(1,1);if(aL.substr(aL.length-1)!=="\\"){aO[1]=(aO[1]||"").replace(/\\/g,"");aQ=aA.find[aP](aO,aK,aS);if(aQ!=null){aR=aR.replace(aA.match[aP],"");break}}}}if(!aQ){aQ=aK.getElementsByTagName("*")}return{set:aQ,expr:aR}};au.filter=function(aU,aT,aX,aN){var aM=aU,aZ=[],aR=aT,aP,aK,aQ=aT&&aT[0]&&av(aT[0]);while(aU&&aT.length){for(var aS in aA.filter){if((aP=aA.match[aS].exec(aU))!=null){var aL=aA.filter[aS],aY,aW;aK=false;if(aR===aZ){aZ=[]}if(aA.preFilter[aS]){aP=aA.preFilter[aS](aP,aR,aX,aZ,aN,aQ);if(!aP){aK=aY=true}else{if(aP===true){continue}}}if(aP){for(var aO=0;(aW=aR[aO])!=null;aO++){if(aW){aY=aL(aW,aP,aO,aR);var aV=aN^!!aY;if(aX&&aY!=null){if(aV){aK=true}else{aR[aO]=false}}else{if(aV){aZ.push(aW);aK=true}}}}}if(aY!==p){if(!aX){aR=aZ}aU=aU.replace(aA.match[aS],"");if(!aK){return[]}break}}}if(aU===aM){if(aK==null){throw"Syntax error, unrecognized expression: "+aU}else{break}}aM=aU}return aR};var aA=au.selectors={order:["ID","NAME","TAG"],match:{ID:/#((?:[\w\u00c0-\uFFFF-]|\\.)+)/,CLASS:/\.((?:[\w\u00c0-\uFFFF-]|\\.)+)/,NAME:/\[name=['"]*((?:[\w\u00c0-\uFFFF-]|\\.)+)['"]*\]/,ATTR:/\[\s*((?:[\w\u00c0-\uFFFF-]|\\.)+)\s*(?:(\S?=)\s*(['"]*)(.*?)\3|)\s*\]/,TAG:/^((?:[\w\u00c0-\uFFFF\*-]|\\.)+)/,CHILD:/:(only|nth|last|first)-child(?:\((even|odd|[\dn+-]*)\))?/,POS:/:(nth|eq|gt|lt|first|last|even|odd)(?:\((\d*)\))?(?=[^-]|$)/,PSEUDO:/:((?:[\w\u00c0-\uFFFF-]|\\.)+)(?:\((['"]*)((?:\([^\)]+\)|[^\2\(\)]*)+)\2\))?/},leftMatch:{},attrMap:{"class":"className","for":"htmlFor"},attrHandle:{href:function(aK){return aK.getAttribute("href")}},relative:{"+":function(aQ,aL){var aN=typeof aL==="string",aP=aN&&!/\W/.test(aL),aR=aN&&!aP;if(aP){aL=aL.toLowerCase()}for(var aM=0,aK=aQ.length,aO;aM<aK;aM++){if((aO=aQ[aM])){while((aO=aO.previousSibling)&&aO.nodeType!==1){}aQ[aM]=aR||aO&&aO.nodeName.toLowerCase()===aL?aO||false:aO===aL}}if(aR){au.filter(aL,aQ,true)}},">":function(aQ,aL){var aO=typeof aL==="string";if(aO&&!/\W/.test(aL)){aL=aL.toLowerCase();for(var aM=0,aK=aQ.length;aM<aK;aM++){var aP=aQ[aM];if(aP){var aN=aP.parentNode;aQ[aM]=aN.nodeName.toLowerCase()===aL?aN:false}}}else{for(var aM=0,aK=aQ.length;aM<aK;aM++){var aP=aQ[aM];if(aP){aQ[aM]=aO?aP.parentNode:aP.parentNode===aL}}if(aO){au.filter(aL,aQ,true)}}},"":function(aN,aL,aP){var aM=aE++,aK=aI;if(typeof aL==="string"&&!/\W/.test(aL)){var aO=aL=aL.toLowerCase();aK=K}aK("parentNode",aL,aM,aN,aO,aP)},"~":function(aN,aL,aP){var aM=aE++,aK=aI;if(typeof aL==="string"&&!/\W/.test(aL)){var aO=aL=aL.toLowerCase();aK=K}aK("previousSibling",aL,aM,aN,aO,aP)}},find:{ID:function(aL,aM,aN){if(typeof aM.getElementById!=="undefined"&&!aN){var aK=aM.getElementById(aL[1]);return aK?[aK]:[]}},NAME:function(aM,aP){if(typeof aP.getElementsByName!=="undefined"){var aL=[],aO=aP.getElementsByName(aM[1]);for(var aN=0,aK=aO.length;aN<aK;aN++){if(aO[aN].getAttribute("name")===aM[1]){aL.push(aO[aN])}}return aL.length===0?null:aL}},TAG:function(aK,aL){return aL.getElementsByTagName(aK[1])}},preFilter:{CLASS:function(aN,aL,aM,aK,aQ,aR){aN=" "+aN[1].replace(/\\/g,"")+" ";if(aR){return aN}for(var aO=0,aP;(aP=aL[aO])!=null;aO++){if(aP){if(aQ^(aP.className&&(" "+aP.className+" ").replace(/[\t\n]/g," ").indexOf(aN)>=0)){if(!aM){aK.push(aP)}}else{if(aM){aL[aO]=false}}}}return false},ID:function(aK){return aK[1].replace(/\\/g,"")},TAG:function(aL,aK){return aL[1].toLowerCase()},CHILD:function(aK){if(aK[1]==="nth"){var aL=/(-?)(\d*)n((?:\+|-)?\d*)/.exec(aK[2]==="even"&&"2n"||aK[2]==="odd"&&"2n+1"||!/\D/.test(aK[2])&&"0n+"+aK[2]||aK[2]);aK[2]=(aL[1]+(aL[2]||1))-0;aK[3]=aL[3]-0}aK[0]=aE++;return aK},ATTR:function(aO,aL,aM,aK,aP,aQ){var aN=aO[1].replace(/\\/g,"");if(!aQ&&aA.attrMap[aN]){aO[1]=aA.attrMap[aN]}if(aO[2]==="~="){aO[4]=" "+aO[4]+" "}return aO},PSEUDO:function(aO,aL,aM,aK,aP){if(aO[1]==="not"){if((aD.exec(aO[3])||"").length>1||/^\w/.test(aO[3])){aO[3]=au(aO[3],null,null,aL)}else{var aN=au.filter(aO[3],aL,aM,true^aP);if(!aM){aK.push.apply(aK,aN)}return false}}else{if(aA.match.POS.test(aO[0])||aA.match.CHILD.test(aO[0])){return true}}return aO},POS:function(aK){aK.unshift(true);return aK}},filters:{enabled:function(aK){return aK.disabled===false&&aK.type!=="hidden"},disabled:function(aK){return aK.disabled===true},checked:function(aK){return aK.checked===true},selected:function(aK){aK.parentNode.selectedIndex;return aK.selected===true},parent:function(aK){return !!aK.firstChild},empty:function(aK){return !aK.firstChild},has:function(aM,aL,aK){return !!au(aK[3],aM).length},header:function(aK){return/h\d/i.test(aK.nodeName)},text:function(aK){return"text"===aK.type},radio:function(aK){return"radio"===aK.type},checkbox:function(aK){return"checkbox"===aK.type},file:function(aK){return"file"===aK.type},password:function(aK){return"password"===aK.type},submit:function(aK){return"submit"===aK.type},image:function(aK){return"image"===aK.type},reset:function(aK){return"reset"===aK.type},button:function(aK){return"button"===aK.type||aK.nodeName.toLowerCase()==="button"},input:function(aK){return/input|select|textarea|button/i.test(aK.nodeName)}},setFilters:{first:function(aL,aK){return aK===0},last:function(aM,aL,aK,aN){return aL===aN.length-1},even:function(aL,aK){return aK%2===0},odd:function(aL,aK){return aK%2===1},lt:function(aM,aL,aK){return aL<aK[3]-0},gt:function(aM,aL,aK){return aL>aK[3]-0},nth:function(aM,aL,aK){return aK[3]-0===aL},eq:function(aM,aL,aK){return aK[3]-0===aL}},filter:{PSEUDO:function(aQ,aM,aN,aR){var aL=aM[1],aO=aA.filters[aL];if(aO){return aO(aQ,aN,aM,aR)}else{if(aL==="contains"){return(aQ.textContent||aQ.innerText||S([aQ])||"").indexOf(aM[3])>=0}else{if(aL==="not"){var aP=aM[3];for(var aN=0,aK=aP.length;aN<aK;aN++){if(aP[aN]===aQ){return false}}return true}else{throw"Syntax error, unrecognized expression: "+aL}}}},CHILD:function(aK,aN){var aQ=aN[1],aL=aK;switch(aQ){case"only":case"first":while((aL=aL.previousSibling)){if(aL.nodeType===1){return false}}if(aQ==="first"){return true}aL=aK;case"last":while((aL=aL.nextSibling)){if(aL.nodeType===1){return false}}return true;case"nth":var aM=aN[2],aT=aN[3];if(aM===1&&aT===0){return true}var aP=aN[0],aS=aK.parentNode;if(aS&&(aS.sizcache!==aP||!aK.nodeIndex)){var aO=0;for(aL=aS.firstChild;aL;aL=aL.nextSibling){if(aL.nodeType===1){aL.nodeIndex=++aO}}aS.sizcache=aP}var aR=aK.nodeIndex-aT;if(aM===0){return aR===0}else{return(aR%aM===0&&aR/aM>=0)}}},ID:function(aL,aK){return aL.nodeType===1&&aL.getAttribute("id")===aK},TAG:function(aL,aK){return(aK==="*"&&aL.nodeType===1)||aL.nodeName.toLowerCase()===aK},CLASS:function(aL,aK){return(" "+(aL.className||aL.getAttribute("class"))+" ").indexOf(aK)>-1},ATTR:function(aP,aN){var aM=aN[1],aK=aA.attrHandle[aM]?aA.attrHandle[aM](aP):aP[aM]!=null?aP[aM]:aP.getAttribute(aM),aQ=aK+"",aO=aN[2],aL=aN[4];return aK==null?aO==="!=":aO==="="?aQ===aL:aO==="*="?aQ.indexOf(aL)>=0:aO==="~="?(" "+aQ+" ").indexOf(aL)>=0:!aL?aQ&&aK!==false:aO==="!="?aQ!==aL:aO==="^="?aQ.indexOf(aL)===0:aO==="$="?aQ.substr(aQ.length-aL.length)===aL:aO==="|="?aQ===aL||aQ.substr(0,aL.length+1)===aL+"-":false},POS:function(aO,aL,aM,aP){var aK=aL[2],aN=aA.setFilters[aK];if(aN){return aN(aO,aM,aL,aP)}}}};var az=aA.match.POS;for(var aw in aA.match){aA.match[aw]=new RegExp(aA.match[aw].source+/(?![^\[]*\])(?![^\(]*\))/.source);aA.leftMatch[aw]=new RegExp(/(^(?:.|\r|\n)*?)/.source+aA.match[aw].source)}var aC=function(aL,aK){aL=Array.prototype.slice.call(aL,0);if(aK){aK.push.apply(aK,aL);return aK}return aL};try{Array.prototype.slice.call(document.documentElement.childNodes,0)}catch(aJ){aC=function(aO,aN){var aL=aN||[];if(aG.call(aO)==="[object Array]"){Array.prototype.push.apply(aL,aO)}else{if(typeof aO.length==="number"){for(var aM=0,aK=aO.length;aM<aK;aM++){aL.push(aO[aM])}}else{for(var aM=0;aO[aM];aM++){aL.push(aO[aM])}}}return aL}}var aF;if(document.documentElement.compareDocumentPosition){aF=function(aL,aK){if(!aL.compareDocumentPosition||!aK.compareDocumentPosition){if(aL==aK){ay=true}return aL.compareDocumentPosition?-1:1}var aM=aL.compareDocumentPosition(aK)&4?-1:aL===aK?0:1;if(aM===0){ay=true}return aM}}else{if("sourceIndex" in document.documentElement){aF=function(aL,aK){if(!aL.sourceIndex||!aK.sourceIndex){if(aL==aK){ay=true}return aL.sourceIndex?-1:1}var aM=aL.sourceIndex-aK.sourceIndex;if(aM===0){ay=true}return aM}}else{if(document.createRange){aF=function(aN,aL){if(!aN.ownerDocument||!aL.ownerDocument){if(aN==aL){ay=true}return aN.ownerDocument?-1:1}var aM=aN.ownerDocument.createRange(),aK=aL.ownerDocument.createRange();aM.setStart(aN,0);aM.setEnd(aN,0);aK.setStart(aL,0);aK.setEnd(aL,0);var aO=aM.compareBoundaryPoints(Range.START_TO_END,aK);if(aO===0){ay=true}return aO}}}}function S(aK){var aL="",aN;for(var aM=0;aK[aM];aM++){aN=aK[aM];if(aN.nodeType===3||aN.nodeType===4){aL+=aN.nodeValue}else{if(aN.nodeType!==8){aL+=S(aN.childNodes)}}}return aL}(function(){var aL=document.createElement("div"),aM="script"+(new Date).getTime();aL.innerHTML="<a name='"+aM+"'/>";var aK=document.documentElement;aK.insertBefore(aL,aK.firstChild);if(document.getElementById(aM)){aA.find.ID=function(aO,aP,aQ){if(typeof aP.getElementById!=="undefined"&&!aQ){var aN=aP.getElementById(aO[1]);return aN?aN.id===aO[1]||typeof aN.getAttributeNode!=="undefined"&&aN.getAttributeNode("id").nodeValue===aO[1]?[aN]:p:[]}};aA.filter.ID=function(aP,aN){var aO=typeof aP.getAttributeNode!=="undefined"&&aP.getAttributeNode("id");return aP.nodeType===1&&aO&&aO.nodeValue===aN}}aK.removeChild(aL);aK=aL=null})();(function(){var aK=document.createElement("div");aK.appendChild(document.createComment(""));if(aK.getElementsByTagName("*").length>0){aA.find.TAG=function(aL,aP){var aO=aP.getElementsByTagName(aL[1]);if(aL[1]==="*"){var aN=[];for(var aM=0;aO[aM];aM++){if(aO[aM].nodeType===1){aN.push(aO[aM])}}aO=aN}return aO}}aK.innerHTML="<a href='#'></a>";if(aK.firstChild&&typeof aK.firstChild.getAttribute!=="undefined"&&aK.firstChild.getAttribute("href")!=="#"){aA.attrHandle.href=function(aL){return aL.getAttribute("href",2)}}aK=null})();if(document.querySelectorAll){(function(){var aK=au,aM=document.createElement("div");aM.innerHTML="<p class='TEST'></p>";if(aM.querySelectorAll&&aM.querySelectorAll(".TEST").length===0){return}au=function(aQ,aP,aN,aO){aP=aP||document;if(!aO&&aP.nodeType===9&&!av(aP)){try{return aC(aP.querySelectorAll(aQ),aN)}catch(aR){}}return aK(aQ,aP,aN,aO)};for(var aL in aK){au[aL]=aK[aL]}aM=null})()}(function(){var aK=document.createElement("div");aK.innerHTML="<div class='test e'></div><div class='test'></div>";if(!aK.getElementsByClassName||aK.getElementsByClassName("e").length===0){return}aK.lastChild.className="e";if(aK.getElementsByClassName("e").length===1){return}aA.order.splice(1,0,"CLASS");aA.find.CLASS=function(aL,aM,aN){if(typeof aM.getElementsByClassName!=="undefined"&&!aN){return aM.getElementsByClassName(aL[1])}};aK=null})();function K(aL,aQ,aP,aT,aR,aS){for(var aN=0,aM=aT.length;aN<aM;aN++){var aK=aT[aN];if(aK){aK=aK[aL];var aO=false;while(aK){if(aK.sizcache===aP){aO=aT[aK.sizset];break}if(aK.nodeType===1&&!aS){aK.sizcache=aP;aK.sizset=aN}if(aK.nodeName.toLowerCase()===aQ){aO=aK;break}aK=aK[aL]}aT[aN]=aO}}}function aI(aL,aQ,aP,aT,aR,aS){for(var aN=0,aM=aT.length;aN<aM;aN++){var aK=aT[aN];if(aK){aK=aK[aL];var aO=false;while(aK){if(aK.sizcache===aP){aO=aT[aK.sizset];break}if(aK.nodeType===1){if(!aS){aK.sizcache=aP;aK.sizset=aN}if(typeof aQ!=="string"){if(aK===aQ){aO=true;break}}else{if(au.filter(aQ,[aK]).length>0){aO=aK;break}}}aK=aK[aL]}aT[aN]=aO}}}var aB=document.compareDocumentPosition?function(aL,aK){return aL.compareDocumentPosition(aK)&16}:function(aL,aK){return aL!==aK&&(aL.contains?aL.contains(aK):true)};var av=function(aK){var aL=(aK?aK.ownerDocument||aK:0).documentElement;return aL?aL.nodeName!=="HTML":false};var aH=function(aK,aR){var aN=[],aO="",aP,aM=aR.nodeType?[aR]:aR;while((aP=aA.match.PSEUDO.exec(aK))){aO+=aP[0];aK=aK.replace(aA.match.PSEUDO,"")}aK=aA.relative[aK]?aK+"*":aK;for(var aQ=0,aL=aM.length;aQ<aL;aQ++){au(aK,aM[aQ],aN)}return au.filter(aO,aN)};return au})();g.lang={code:"it",of:"di",loading:"in caricamento",cancel:"Annulla",next:"Avanti",previous:"Indietro",play:"Play",pause:"Pausa",close:"Chiudi",errors:{single:'È necessario installare il plugin <a href="{0}">{1}</a> per poter vedere questo contenuto.',shared:'È necessario installare i plugin <a href="{0}">{1}</a> e <a href="{2}">{3}</a> per poter vedere questo contenuto.',either:'È necessario installare o il plugin <a href="{0}">{1}</a> o <a href="{2}">{3}</a> per poter vedere questo contenuto.'}};g.iframe=function(S,au){this.obj=S;this.id=au;var K=ag("sb-overlay");this.height=S.height?parseInt(S.height,10):K.offsetHeight;this.width=S.width?parseInt(S.width,10):K.offsetWidth};g.iframe.prototype={append:function(K,au){var S='<iframe id="'+this.id+'" name="'+this.id+'" height="100%" width="100%" frameborder="0" marginwidth="0" marginheight="0" style="visibility:hidden" onload="this.style.visibility=\'visible\'" scrolling="auto"';if(g.isIE){S+=' allowtransparency="true"';if(g.isIE6){S+=" src=\"javascript:false;document.write('');\""}}S+="></iframe>";K.innerHTML=S},remove:function(){var K=ag(this.id);if(K){z(K);if(g.isGecko){delete T.frames[this.id]}}},onLoad:function(){var K=g.isIE?ag(this.id).contentWindow:T.frames[this.id];K.location.href=this.obj.content}};var al=false,A=[],H=["sb-nav-close","sb-nav-next","sb-nav-play","sb-nav-pause","sb-nav-previous"],F,ah,v,P=true;function ae(au,aE,aB,az,aF){var K=(aE=="opacity"),aA=K?g.setOpacity:function(aG,aH){aG.style[aE]=""+aH+"px"};if(az==0||(!K&&!g.options.animate)||(K&&!g.options.animateFade)){aA(au,aB);if(aF){aF()}return}var aC=parseFloat(g.getStyle(au,aE))||0;var aD=aB-aC;if(aD==0){if(aF){aF()}return}az*=1000;var av=X(),ay=g.ease,ax=av+az,aw;var S=setInterval(function(){aw=X();if(aw>=ax){clearInterval(S);S=null;aA(au,aB);if(aF){aF()}}else{aA(au,aC+ay((aw-av)/az)*aD)}},10)}function I(){F.style.height=g.getWindowSize("Height")+"px";F.style.width=g.getWindowSize("Width")+"px"}function ad(){F.style.top=document.documentElement.scrollTop+"px";F.style.left=document.documentElement.scrollLeft+"px"}function y(K){if(K){ac(A,function(S,au){au[0].style.visibility=au[1]||""})}else{A=[];ac(g.options.troubleElements,function(au,S){ac(document.getElementsByTagName(S),function(av,aw){A.push([aw,aw.style.visibility]);aw.style.visibility="hidden"})})}}function x(au,K){var S=ag("sb-nav-"+au);if(S){S.style.display=K?"":"none"}}function n(K,ax){var aw=ag("sb-loading"),au=g.getCurrent().player,av=(au=="img"||au=="html");if(K){g.setOpacity(aw,0);aw.style.display="block";var S=function(){g.clearOpacity(aw);if(ax){ax()}};if(av){ae(aw,"opacity",1,g.options.fadeDuration,S)}else{S()}}else{var S=function(){aw.style.display="none";g.clearOpacity(aw);if(ax){ax()}};if(av){ae(aw,"opacity",0,g.options.fadeDuration,S)}else{S()}}}function at(aC){var ax=g.getCurrent();ag("sb-title-inner").innerHTML=ax.title||"";var aD,az,S,aE,aA;if(g.options.displayNav){aD=true;var aB=g.gallery.length;if(aB>1){if(g.options.continuous){az=aA=true}else{az=(aB-1)>g.current;aA=g.current>0}}if(g.options.slideshowDelay>0&&g.hasNext()){aE=!g.isPaused();S=!aE}}else{aD=az=S=aE=aA=false}x("close",aD);x("next",az);x("play",S);x("pause",aE);x("previous",aA);var K="";if(g.options.displayCounter&&g.gallery.length>1){var aB=g.gallery.length;if(g.options.counterType=="skip"){var aw=0,av=aB,au=parseInt(g.options.counterLimit)||0;if(au<aB&&au>2){var ay=Math.floor(au/2);aw=g.current-ay;if(aw<0){aw+=aB}av=g.current+(au-ay);if(av>aB){av-=aB}}while(aw!=av){if(aw==aB){aw=0}K+='<a onclick="Shadowbox.change('+aw+');"';if(aw==g.current){K+=' class="sb-counter-current"'}K+=">"+(++aw)+"</a>"}}else{K=[g.current+1,g.lang.of,aB].join(" ")}}ag("sb-counter").innerHTML=K;aC()}function u(av){var K=ag("sb-title-inner"),au=ag("sb-info-inner"),S=0.35;K.style.visibility=au.style.visibility="";if(K.innerHTML!=""){ae(K,"marginTop",0,S)}ae(au,"marginTop",0,S,av)}function ab(au,aA){var ay=ag("sb-title"),K=ag("sb-info"),av=ay.offsetHeight,aw=K.offsetHeight,ax=ag("sb-title-inner"),az=ag("sb-info-inner"),S=(au?0.35:0);ae(ax,"marginTop",av,S);ae(az,"marginTop",aw*-1,S,function(){ax.style.visibility=az.style.visibility="hidden";aA()})}function E(K,av,S,ax){var aw=ag("sb-wrapper-inner"),au=(S?g.options.resizeDuration:0);ae(v,"top",av,au);ae(aw,"height",K,au,ax)}function t(K,av,S,aw){var au=(S?g.options.resizeDuration:0);ae(v,"left",av,au);ae(v,"width",K,au,aw)}function R(aA,au){var aw=ag("sb-body-inner"),aA=parseInt(aA),au=parseInt(au),S=v.offsetHeight-aw.offsetHeight,K=v.offsetWidth-aw.offsetWidth,ay=ah.offsetHeight,az=ah.offsetWidth,ax=parseInt(g.options.viewportPadding)||20,av=(g.player&&g.options.handleOversize!="drag");return g.setDimensions(aA,au,ay,az,S,K,ax,av)}var k={};k.markup='<div id="sb-container"><div id="sb-overlay"></div><div id="sb-wrapper"><div id="sb-title"><div id="sb-title-inner"></div></div><div id="sb-wrapper-inner"><div id="sb-body"><div id="sb-body-inner"></div><div id="sb-loading"><div id="sb-loading-inner"><span>{loading}</span></div></div></div></div><div id="sb-info"><div id="sb-info-inner"><div id="sb-counter"></div><div id="sb-nav"><a id="sb-nav-close" title="{close}" onclick="Shadowbox.close()"></a><a id="sb-nav-next" title="{next}" onclick="Shadowbox.next()"></a><a id="sb-nav-play" title="{play}" onclick="Shadowbox.play()"></a><a id="sb-nav-pause" title="{pause}" onclick="Shadowbox.pause()"></a><a id="sb-nav-previous" title="{previous}" onclick="Shadowbox.previous()"></a></div></div></div></div></div>';k.options={animSequence:"sync",counterLimit:10,counterType:"default",displayCounter:true,displayNav:true,fadeDuration:0.35,initialHeight:160,initialWidth:320,modal:false,overlayColor:"#000",overlayOpacity:0.5,resizeDuration:0.35,showOverlay:true,troubleElements:["select","object","embed","canvas"]};k.init=function(){g.appendHTML(document.body,s(k.markup,g.lang));k.body=ag("sb-body-inner");F=ag("sb-container");ah=ag("sb-overlay");v=ag("sb-wrapper");if(!L){F.style.position="absolute"}if(!ak){var au,K,S=/url\("(.*\.png)"\)/;ac(H,function(aw,ax){au=ag(ax);if(au){K=g.getStyle(au,"backgroundImage").match(S);if(K){au.style.backgroundImage="none";au.style.filter="progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true,src="+K[1]+",sizingMethod=scale);"}}})}var av;j(T,"resize",function(){if(av){clearTimeout(av);av=null}if(w){av=setTimeout(k.onWindowResize,10)}})};k.onOpen=function(K,au){P=false;F.style.display="block";I();var S=R(g.options.initialHeight,g.options.initialWidth);E(S.innerHeight,S.top);t(S.width,S.left);if(g.options.showOverlay){ah.style.backgroundColor=g.options.overlayColor;g.setOpacity(ah,0);if(!g.options.modal){j(ah,"click",g.close)}al=true}if(!L){ad();j(T,"scroll",ad)}y();F.style.visibility="visible";if(al){ae(ah,"opacity",g.options.overlayOpacity,g.options.fadeDuration,au)}else{au()}};k.onLoad=function(S,K){n(true);while(k.body.firstChild){z(k.body.firstChild)}ab(S,function(){if(!w){return}if(!S){v.style.visibility="visible"}at(K)})};k.onReady=function(av){if(!w){return}var S=g.player,au=R(S.height,S.width);var K=function(){u(av)};switch(g.options.animSequence){case"hw":E(au.innerHeight,au.top,true,function(){t(au.width,au.left,true,K)});break;case"wh":t(au.width,au.left,true,function(){E(au.innerHeight,au.top,true,K)});break;default:t(au.width,au.left,true);E(au.innerHeight,au.top,true,K)}};k.onShow=function(K){n(false,K);P=true};k.onClose=function(){if(!L){a(T,"scroll",ad)}a(ah,"click",g.close);v.style.visibility="hidden";var K=function(){F.style.visibility="hidden";F.style.display="none";y(true)};if(al){ae(ah,"opacity",0,g.options.fadeDuration,K)}else{K()}};k.onPlay=function(){x("play",false);x("pause",true)};k.onPause=function(){x("pause",false);x("play",true)};k.onWindowResize=function(){if(!P){return}I();var K=g.player,S=R(K.height,K.width);t(S.width,S.left);E(S.innerHeight,S.top);if(K.onWindowResize){K.onWindowResize()}};g.skin=k;T.Shadowbox=g})(window);
/* [/End Shadowbox] */





/* [Replace browse input field] */
(function($){$.fn.filestyle=function(options){var settings={width:250};if(options){$.extend(settings,options);};return this.each(function(){var self=this;var wrapper=$("<div>").css({"width":settings.imagewidth+"px","height":settings.imageheight+"px","background":"url("+settings.image+") 0 0 no-repeat","background-position":"right","display":"inline","position":"absolute","overflow":"hidden"});var filename=$('<input class="file">').addClass($(self).attr("class")).css({"display":"inline","width":settings.width+"px"});$(self).before(filename);$(self).wrap(wrapper);$(self).css({"position":"relative","height":settings.imageheight+"px","width":settings.width+"px","display":"inline","cursor":"pointer","opacity":"0.0"});if($.browser.mozilla){if(/Win/.test(navigator.platform)){$(self).css("margin-left","-142px");}else{$(self).css("margin-left","-168px");};}else{$(self).css("margin-left",settings.imagewidth-settings.width+"px");};$(self).bind("change",function(){filename.val($(self).val());});});};})(jQuery);
/* [/End Replace browse input field] */







/* [Collapser] */

/* 
 * jQuery - Collapser - Plugin v1.0
 * http://www.aakashweb.com/
 * Copyright 2010, Aakash Chakravarthy
 * Released under the MIT License.
 */
(function($){$.fn.collapser=function(options,beforeCallback,afterCallback){var defaults={target:'next',targetOnly:null,effect:'slide',changeText:true,expandHtml:'Expand',collapseHtml:'Collapse',expandClass:'',collapseClass:''};var options=$.extend(defaults,options);var expHtml,collHtml,effectShow,effectHide;if(options.effect=='slide'){effectShow='slideDown';effectHide='slideUp';}else{effectShow='fadeIn';effectHide='fadeOut';}if(options.changeText==true){expHtml=options.expandHtml;collHtml=options.collapseHtml;}function callBeforeCallback(obj){if(beforeCallback!==undefined){beforeCallback.apply(obj);}}function callAfterCallback(obj){if(afterCallback!==undefined){afterCallback.apply(obj);}}function hideElement(obj,method){callBeforeCallback(obj);if(method==1){obj[options.target](options.targetOnly)[effectHide]();obj.html(expHtml);obj.removeClass(options.collapseClass);obj.addClass(options.expandClass);}else{$(document).find(options.target)[effectHide]();obj.html(expHtml);obj.removeClass(options.collapseClass);obj.addClass(options.expandClass);}callAfterCallback(obj);}function showElement(obj,method){callBeforeCallback(obj)
if(method==1){obj[options.target](options.targetOnly)[effectShow]();obj.html(collHtml);obj.removeClass(options.expandClass);obj.addClass(options.collapseClass);}else{$(document).find(options.target)[effectShow]();obj.html(collHtml);obj.removeClass(options.expandClass);obj.addClass(options.collapseClass);}callAfterCallback(obj);}function toggleElement(obj,method){if(method==1){if(obj[options.target](options.targetOnly).is(':visible')){hideElement(obj,1);}else{showElement(obj,1);}}else{if($(document).find(options.target).is(':visible')){hideElement(obj,2);}else{showElement(obj,2);}}}return this.each(function(){if($.fn[options.target]&&$(this)[options.target]()){$(this).toggle(function(){toggleElement($(this),1);},function(){toggleElement($(this),1);});}else{$(this).toggle(function(){toggleElement($(this),2);},function(){toggleElement($(this),2);});}if($.fn[options.target]&&$(this)[options.target]()){if($(this)[options.target]().is(':hidden')){$(this).html(expHtml);$(this).removeClass(options.collapseClass);$(this).addClass(options.expandClass);}else{$(this).html(collHtml);$(this).removeClass(options.expandClass);$(this).addClass(options.collapseClass);}}else{if($(document).find(options.target).is(':hidden')){$(this).html(expHtml);}else{$(this).html(collHtml);}}});};})(jQuery);
/* [/End Collapser] */






/* [Context Menu] */

// jQuery Context Menu Plugin
//
// Version 1.01
//
// Cory S.N. LaViska
// A Beautiful Site (http://abeautifulsite.net/)
//
// More info: http://abeautifulsite.net/2008/09/jquery-context-menu-plugin/
//
// Terms of Use
//
// This plugin is dual-licensed under the GNU General Public License
//   and the MIT License and is copyright A Beautiful Site, LLC.
//
if(jQuery)( function() {
	$.extend($.fn, {
		
		contextMenu: function(o, callback) {
			// Defaults
			if( o.menu == undefined ) return false;
			if( o.inSpeed == undefined ) o.inSpeed = 150;
			if( o.outSpeed == undefined ) o.outSpeed = 75;
			// 0 needs to be -1 for expected results (no fade)
			if( o.inSpeed == 0 ) o.inSpeed = -1;
			if( o.outSpeed == 0 ) o.outSpeed = -1;
			// Loop each context menu
			$(this).each( function() {
				var el = $(this);
				var offset = $(el).offset();
				// Add contextMenu class
				$('#' + o.menu).addClass('contextMenu');
				// Simulate a true right click
				$(this).mousedown( function(e) {
					var evt = e;
					evt.stopPropagation();
					$(this).mouseup( function(e) {
						e.stopPropagation();
						var srcElement = $(this);
						$(this).unbind('mouseup');
						if( evt.button == 2 ) {
							// Hide context menus that may be showing
							$(".contextMenu").hide();
							// Get this context menu
							var menu = $('#' + o.menu);
							
							if( $(el).hasClass('disabled') ) return false;
							
							// Detect mouse position
							var d = {}, x, y;
							if( self.innerHeight ) {
								d.pageYOffset = self.pageYOffset;
								d.pageXOffset = self.pageXOffset;
								d.innerHeight = self.innerHeight;
								d.innerWidth = self.innerWidth;
							} else if( document.documentElement &&
								document.documentElement.clientHeight ) {
								d.pageYOffset = document.documentElement.scrollTop;
								d.pageXOffset = document.documentElement.scrollLeft;
								d.innerHeight = document.documentElement.clientHeight;
								d.innerWidth = document.documentElement.clientWidth;
							} else if( document.body ) {
								d.pageYOffset = document.body.scrollTop;
								d.pageXOffset = document.body.scrollLeft;
								d.innerHeight = document.body.clientHeight;
								d.innerWidth = document.body.clientWidth;
							}
							(e.pageX) ? x = e.pageX : x = e.clientX + d.scrollLeft;
							(e.pageY) ? y = e.pageY : y = e.clientY + d.scrollTop;
							
							// Show the menu
							$(document).unbind('click');
							$(menu).css({ top: y, left: x }).fadeIn(o.inSpeed);
							// Hover events
							$(menu).find('A').mouseover( function() {
								$(menu).find('LI.hover').removeClass('hover');
								$(this).parent().addClass('hover');
							}).mouseout( function() {
								$(menu).find('LI.hover').removeClass('hover');
							});
							
							// Keyboard
							$(document).keypress( function(e) {
								switch( e.keyCode ) {
									case 38: // up
										if( $(menu).find('LI.hover').size() == 0 ) {
											$(menu).find('LI:last').addClass('hover');
										} else {
											$(menu).find('LI.hover').removeClass('hover').prevAll('LI:not(.disabled)').eq(0).addClass('hover');
											if( $(menu).find('LI.hover').size() == 0 ) $(menu).find('LI:last').addClass('hover');
										}
									break;
									case 40: // down
										if( $(menu).find('LI.hover').size() == 0 ) {
											$(menu).find('LI:first').addClass('hover');
										} else {
											$(menu).find('LI.hover').removeClass('hover').nextAll('LI:not(.disabled)').eq(0).addClass('hover');
											if( $(menu).find('LI.hover').size() == 0 ) $(menu).find('LI:first').addClass('hover');
										}
									break;
									case 13: // enter
										$(menu).find('LI.hover A').trigger('click');
									break;
									case 27: // esc
										$(document).trigger('click');
									break
								}
							});
							
							// When items are selected
							$('#' + o.menu).find('A').unbind('click');
							$('#' + o.menu).find('LI:not(.disabled) A').click( function() {
								$(document).unbind('click').unbind('keypress');
								$(".contextMenu").hide();
								// Callback
								if( callback ) callback( $(this).attr('href').substr(1), $(srcElement), {x: x - offset.left, y: y - offset.top, docX: x, docY: y} );
								return false;
							});
							
							// Hide bindings
							setTimeout( function() { // Delay for Mozilla
								$(document).click( function() {
									$(document).unbind('click').unbind('keypress');
									$(menu).fadeOut(o.outSpeed);
									return false;
								});
							}, 0);
						}
					});
				});
				
				// Disable text selection
				if( $.browser.mozilla ) {
					$('#' + o.menu).each( function() { $(this).css({ 'MozUserSelect' : 'none' }); });
				} else if( $.browser.msie ) {
					$('#' + o.menu).each( function() { $(this).bind('selectstart.disableTextSelect', function() { return false; }); });
				} else {
					$('#' + o.menu).each(function() { $(this).bind('mousedown.disableTextSelect', function() { return false; }); });
				}
				// Disable browser context menu (requires both selectors to work in IE/Safari + FF/Chrome)
				$(el).add($('UL.contextMenu')).bind('contextmenu', function() { return false; });
				
			});
			return $(this);
		},
		
		// Disable context menu items on the fly
		disableContextMenuItems: function(o) {
			if( o == undefined ) {
				// Disable all
				$(this).find('LI').addClass('disabled');
				return( $(this) );
			}
			$(this).each( function() {
				if( o != undefined ) {
					var d = o.split(',');
					for( var i = 0; i < d.length; i++ ) {
						$(this).find('A[href="' + d[i] + '"]').parent().addClass('disabled');
						
					}
				}
			});
			return( $(this) );
		},
		
		// Enable context menu items on the fly
		enableContextMenuItems: function(o) {
			if( o == undefined ) {
				// Enable all
				$(this).find('LI.disabled').removeClass('disabled');
				return( $(this) );
			}
			$(this).each( function() {
				if( o != undefined ) {
					var d = o.split(',');
					for( var i = 0; i < d.length; i++ ) {
						$(this).find('A[href="' + d[i] + '"]').parent().removeClass('disabled');
						
					}
				}
			});
			return( $(this) );
		},
		
		// Disable context menu(s)
		disableContextMenu: function() {
			$(this).each( function() {
				$(this).addClass('disabled');
			});
			return( $(this) );
		},
		
		// Enable context menu(s)
		enableContextMenu: function() {
			$(this).each( function() {
				$(this).removeClass('disabled');
			});
			return( $(this) );
		},
		
		// Destroy context menu(s)
		destroyContextMenu: function() {
			// Destroy specified context menus
			$(this).each( function() {
				// Disable action
				$(this).unbind('mousedown').unbind('mouseup');
			});
			return( $(this) );
		}
		
	});
})(jQuery);
/* [/End Context Menu] */







/* [Treeview] */

/*
 * Treeview 1.4 - jQuery plugin to hide and show branches of a tree
 * 
 * http://bassistance.de/jquery-plugins/jquery-plugin-treeview/
 * http://docs.jquery.com/Plugins/Treeview
 *
 * Copyright (c) 2007 Jörn Zaefferer
 *
 * Dual licensed under the MIT and GPL licenses:
 *   http://www.opensource.org/licenses/mit-license.php
 *   http://www.gnu.org/licenses/gpl.html
 *
 * Revision: $Id: jquery.treeview.js 4684 2008-02-07 19:08:06Z joern.zaefferer $
 *
 */
eval(function(p,a,c,k,e,r){e=function(c){return(c<a?'':e(parseInt(c/a)))+((c=c%a)>35?String.fromCharCode(c+29):c.toString(36))};if(!''.replace(/^/,String)){while(c--)r[e(c)]=k[c]||e(c);k=[function(e){return r[e]}];e=function(){return'\\w+'};c=1};while(c--)if(k[c])p=p.replace(new RegExp('\\b'+e(c)+'\\b','g'),k[c]);return p}(';(4($){$.1l($.F,{E:4(b,c){l a=3.n(\'.\'+b);3.n(\'.\'+c).o(c).m(b);a.o(b).m(c);8 3},s:4(a,b){8 3.n(\'.\'+a).o(a).m(b).P()},1n:4(a){a=a||"1j";8 3.1j(4(){$(3).m(a)},4(){$(3).o(a)})},1h:4(b,a){b?3.1g({1e:"p"},b,a):3.x(4(){T(3)[T(3).1a(":U")?"H":"D"]();7(a)a.A(3,O)})},12:4(b,a){7(b){3.1g({1e:"D"},b,a)}1L{3.D();7(a)3.x(a)}},11:4(a){7(!a.1k){3.n(":r-1H:G(9)").m(k.r);3.n((a.1F?"":"."+k.X)+":G(."+k.W+")").6(">9").D()}8 3.n(":y(>9)")},S:4(b,c){3.n(":y(>9):G(:y(>a))").6(">1z").C(4(a){c.A($(3).19())}).w($("a",3)).1n();7(!b.1k){3.n(":y(>9:U)").m(k.q).s(k.r,k.t);3.G(":y(>9:U)").m(k.u).s(k.r,k.v);3.1r("<J 14=\\""+k.5+"\\"/>").6("J."+k.5).x(4(){l a="";$.x($(3).B().1o("14").13(" "),4(){a+=3+"-5 "});$(3).m(a)})}3.6("J."+k.5).C(c)},z:4(g){g=$.1l({N:"z"},g);7(g.w){8 3.1K("w",[g.w])}7(g.p){l d=g.p;g.p=4(){8 d.A($(3).B()[0],O)}}4 1m(b,c){4 L(a){8 4(){K.A($("J."+k.5,b).n(4(){8 a?$(3).B("."+a).1i:1I}));8 1G}}$("a:10(0)",c).C(L(k.u));$("a:10(1)",c).C(L(k.q));$("a:10(2)",c).C(L())}4 K(){$(3).B().6(">.5").E(k.Z,k.Y).E(k.I,k.M).P().E(k.u,k.q).E(k.v,k.t).6(">9").1h(g.1f,g.p);7(g.1E){$(3).B().1D().6(">.5").s(k.Z,k.Y).s(k.I,k.M).P().s(k.u,k.q).s(k.v,k.t).6(">9").12(g.1f,g.p)}}4 1d(){4 1C(a){8 a?1:0}l b=[];j.x(4(i,e){b[i]=$(e).1a(":y(>9:1B)")?1:0});$.V(g.N,b.1A(""))}4 1c(){l b=$.V(g.N);7(b){l a=b.13("");j.x(4(i,e){$(e).6(">9")[1y(a[i])?"H":"D"]()})}}3.m("z");l j=3.6("Q").11(g);1x(g.1w){18"V":l h=g.p;g.p=4(){1d();7(h){h.A(3,O)}};1c();17;18"1b":l f=3.6("a").n(4(){8 3.16.15()==1b.16.15()});7(f.1i){f.m("1v").1u("9, Q").w(f.19()).H()}17}j.S(g,K);7(g.R){1m(3,g.R);$(g.R).H()}8 3.1t("w",4(a,b){$(b).1s().o(k.r).o(k.v).o(k.t).6(">.5").o(k.I).o(k.M);$(b).6("Q").1q().11(g).S(g,K)})}});l k=$.F.z.1J={W:"W",X:"X",q:"q",Y:"q-5",M:"t-5",u:"u",Z:"u-5",I:"v-5",v:"v",t:"t",r:"r",5:"5"};$.F.1p=$.F.z})(T);',62,110,'|||this|function|hitarea|find|if|return|ul||||||||||||var|addClass|filter|removeClass|toggle|expandable|last|replaceClass|lastExpandable|collapsable|lastCollapsable|add|each|has|treeview|apply|parent|click|hide|swapClass|fn|not|show|lastCollapsableHitarea|div|toggler|handler|lastExpandableHitarea|cookieId|arguments|end|li|control|applyClasses|jQuery|hidden|cookie|open|closed|expandableHitarea|collapsableHitarea|eq|prepareBranches|heightHide|split|class|toLowerCase|href|break|case|next|is|location|deserialize|serialize|height|animated|animate|heightToggle|length|hover|prerendered|extend|treeController|hoverClass|attr|Treeview|andSelf|prepend|prev|bind|parents|selected|persist|switch|parseInt|span|join|visible|binary|siblings|unique|collapsed|false|child|true|classes|trigger|else'.split('|'),0,{}))
$(document).ready(function(){
	// second example
	$("#browser").treeview({
	    // animated:"fast",
		persist: "cookie"
	});
	$("#samplebutton").click(function(){
		var branches = $("<li><span class='folder'>New Sublist</span><ul>" + 
			"<li><span class='file'>Item1</span></li>" + 
			"<li><span class='file'>Item2</span></li></ul></li>").appendTo("#browser");
		$("#browser").treeview({
			add: branches
		});
	});
	// Third example
	$("#browser-admin").treeview({
		// animated:"fast",
		persist: "cookie"
    });
    $("#modules-admin").treeview({
    // animated:"fast",
    persist: "cookie"
    });
	$("#samplebutton").click(function(){
		var branches = $("<li><span class='folder'>New Sublist</span><ul>" + 
			"<li><span class='file'>Item1</span></li>" + 
			"<li><span class='file'>Item2</span></li></ul></li>").appendTo("#browser-admin");
		$("#browser-admin").treeview({
			add: branches
		});
	});    
});
/* [/End Treeview] */






/* [jQuery Tools] */

/*
 * jQuery Tools 1.2.3 - The missing UI library for the Web
 * 
 * [tabs, tooltip, overlay]
 * 
 * NO COPYRIGHTS OR LICENSES. DO WHAT YOU LIKE.
 * 
 * http://flowplayer.org/tools/
 * 
 * File generated: Thu Jun 17 00:37:57 GMT 2010
 */
(function(c){function p(e,b,a){var d=this,l=e.add(this),h=e.find(a.tabs),i=b.jquery?b:e.children(b),j;h.length||(h=e.children());i.length||(i=e.parent().find(b));i.length||(i=c(b));c.extend(this,{click:function(f,g){var k=h.eq(f);if(typeof f=="string"&&f.replace("#","")){k=h.filter("[href*="+f.replace("#","")+"]");f=Math.max(h.index(k),0)}if(a.rotate){var n=h.length-1;if(f<0)return d.click(n,g);if(f>n)return d.click(0,g)}if(!k.length){if(j>=0)return d;f=a.initialIndex;k=h.eq(f)}if(f===j)return d;
g=g||c.Event();g.type="onBeforeClick";l.trigger(g,[f]);if(!g.isDefaultPrevented()){o[a.effect].call(d,f,function(){g.type="onClick";l.trigger(g,[f])});j=f;h.removeClass(a.current);k.addClass(a.current);return d}},getConf:function(){return a},getTabs:function(){return h},getPanes:function(){return i},getCurrentPane:function(){return i.eq(j)},getCurrentTab:function(){return h.eq(j)},getIndex:function(){return j},next:function(){return d.click(j+1)},prev:function(){return d.click(j-1)},destroy:function(){h.unbind(a.event).removeClass(a.current);
i.find("a[href^=#]").unbind("click.T");return d}});c.each("onBeforeClick,onClick".split(","),function(f,g){c.isFunction(a[g])&&c(d).bind(g,a[g]);d[g]=function(k){c(d).bind(g,k);return d}});if(a.history&&c.fn.history){c.tools.history.init(h);a.event="history"}h.each(function(f){c(this).bind(a.event,function(g){d.click(f,g);return g.preventDefault()})});i.find("a[href^=#]").bind("click.T",function(f){d.click(c(this).attr("href"),f)});if(location.hash)d.click(location.hash);else if(a.initialIndex===
0||a.initialIndex>0)d.click(a.initialIndex)}c.tools=c.tools||{version:"1.2.3"};c.tools.tabs={conf:{tabs:"a",current:"current",onBeforeClick:null,onClick:null,effect:"default",initialIndex:0,event:"click",rotate:false,history:false},addEffect:function(e,b){o[e]=b}};var o={"default":function(e,b){this.getPanes().hide().eq(e).show();b.call()},fade:function(e,b){var a=this.getConf(),d=a.fadeOutSpeed,l=this.getPanes();d?l.fadeOut(d):l.hide();l.eq(e).fadeIn(a.fadeInSpeed,b)},slide:function(e,b){this.getPanes().slideUp(200);
this.getPanes().eq(e).slideDown(400,b)},ajax:function(e,b){this.getPanes().eq(0).load(this.getTabs().eq(e).attr("href"),b)}},m;c.tools.tabs.addEffect("horizontal",function(e,b){m||(m=this.getPanes().eq(0).width());this.getCurrentPane().animate({width:0},function(){c(this).hide()});this.getPanes().eq(e).animate({width:m},function(){c(this).show();b.call()})});c.fn.tabs=function(e,b){var a=this.data("tabs");if(a){a.destroy();this.removeData("tabs")}if(c.isFunction(b))b={onBeforeClick:b};b=c.extend({},
c.tools.tabs.conf,b);this.each(function(){a=new p(c(this),e,b);c(this).data("tabs",a)});return b.api?a:this}})(jQuery);
(function(f){function p(a,b,c){var h=c.relative?a.position().top:a.offset().top,e=c.relative?a.position().left:a.offset().left,i=c.position[0];h-=b.outerHeight()-c.offset[0];e+=a.outerWidth()+c.offset[1];var j=b.outerHeight()+a.outerHeight();if(i=="center")h+=j/2;if(i=="bottom")h+=j;i=c.position[1];a=b.outerWidth()+a.outerWidth();if(i=="center")e-=a/2;if(i=="left")e-=a;return{top:h,left:e}}function t(a,b){var c=this,h=a.add(c),e,i=0,j=0,m=a.attr("title"),q=n[b.effect],k,r=a.is(":input"),u=r&&a.is(":checkbox, :radio, select, :button, :submit"),
s=a.attr("type"),l=b.events[s]||b.events[r?u?"widget":"input":"def"];if(!q)throw'Nonexistent effect "'+b.effect+'"';l=l.split(/,\s*/);if(l.length!=2)throw"Tooltip: bad events configuration for "+s;a.bind(l[0],function(d){clearTimeout(i);if(b.predelay)j=setTimeout(function(){c.show(d)},b.predelay);else c.show(d)}).bind(l[1],function(d){clearTimeout(j);if(b.delay)i=setTimeout(function(){c.hide(d)},b.delay);else c.hide(d)});if(m&&b.cancelDefault){a.removeAttr("title");a.data("title",m)}f.extend(c,{show:function(d){if(!e){if(m)e=
f(b.layout).addClass(b.tipClass).appendTo(document.body).hide().append(m);else if(b.tip)e=f(b.tip).eq(0);else{e=a.next();e.length||(e=a.parent().next())}if(!e.length)throw"Cannot find tooltip for "+a;}if(c.isShown())return c;e.stop(true,true);var g=p(a,e,b);d=d||f.Event();d.type="onBeforeShow";h.trigger(d,[g]);if(d.isDefaultPrevented())return c;g=p(a,e,b);e.css({position:"absolute",top:g.top,left:g.left});k=true;q[0].call(c,function(){d.type="onShow";k="full";h.trigger(d)});g=b.events.tooltip.split(/,\s*/);
e.bind(g[0],function(){clearTimeout(i);clearTimeout(j)});g[1]&&!a.is("input:not(:checkbox, :radio), textarea")&&e.bind(g[1],function(o){o.relatedTarget!=a[0]&&a.trigger(l[1].split(" ")[0])});return c},hide:function(d){if(!e||!c.isShown())return c;d=d||f.Event();d.type="onBeforeHide";h.trigger(d);if(!d.isDefaultPrevented()){k=false;n[b.effect][1].call(c,function(){d.type="onHide";k=false;h.trigger(d)});return c}},isShown:function(d){return d?k=="full":k},getConf:function(){return b},getTip:function(){return e},
getTrigger:function(){return a}});f.each("onHide,onBeforeShow,onShow,onBeforeHide".split(","),function(d,g){f.isFunction(b[g])&&f(c).bind(g,b[g]);c[g]=function(o){f(c).bind(g,o);return c}})}f.tools=f.tools||{version:"1.2.3"};f.tools.tooltip={conf:{effect:"toggle",fadeOutSpeed:"fast",predelay:0,delay:30,opacity:1,tip:0,position:["top","center"],offset:[0,0],relative:false,cancelDefault:true,events:{def:"mouseenter,mouseleave",input:"focus,blur",widget:"focus mouseenter,blur mouseleave",tooltip:"mouseenter,mouseleave"},
layout:"<div/>",tipClass:"tooltip"},addEffect:function(a,b,c){n[a]=[b,c]}};var n={toggle:[function(a){var b=this.getConf(),c=this.getTip();b=b.opacity;b<1&&c.css({opacity:b});c.show();a.call()},function(a){this.getTip().hide();a.call()}],fade:[function(a){var b=this.getConf();this.getTip().fadeTo(b.fadeInSpeed,b.opacity,a)},function(a){this.getTip().fadeOut(this.getConf().fadeOutSpeed,a)}]};f.fn.tooltip=function(a){var b=this.data("tooltip");if(b)return b;a=f.extend(true,{},f.tools.tooltip.conf,a);
if(typeof a.position=="string")a.position=a.position.split(/,?\s/);this.each(function(){b=new t(f(this),a);f(this).data("tooltip",b)});return a.api?b:this}})(jQuery);
(function(a){function t(d,b){var c=this,i=d.add(c),o=a(window),k,f,m,g=a.tools.expose&&(b.mask||b.expose),n=Math.random().toString().slice(10);if(g){if(typeof g=="string")g={color:g};g.closeOnClick=g.closeOnEsc=false}var p=b.target||d.attr("rel");f=p?a(p):d;if(!f.length)throw"Could not find Overlay: "+p;d&&d.index(f)==-1&&d.click(function(e){c.load(e);return e.preventDefault()});a.extend(c,{load:function(e){if(c.isOpened())return c;var h=q[b.effect];if(!h)throw'Overlay: cannot find effect : "'+b.effect+
'"';b.oneInstance&&a.each(s,function(){this.close(e)});e=e||a.Event();e.type="onBeforeLoad";i.trigger(e);if(e.isDefaultPrevented())return c;m=true;g&&a(f).expose(g);var j=b.top,r=b.left,u=f.outerWidth({margin:true}),v=f.outerHeight({margin:true});if(typeof j=="string")j=j=="center"?Math.max((o.height()-v)/2,0):parseInt(j,10)/100*o.height();if(r=="center")r=Math.max((o.width()-u)/2,0);h[0].call(c,{top:j,left:r},function(){if(m){e.type="onLoad";i.trigger(e)}});g&&b.closeOnClick&&a.mask.getMask().one("click",
c.close);b.closeOnClick&&a(document).bind("click."+n,function(l){a(l.target).parents(f).length||c.close(l)});b.closeOnEsc&&a(document).bind("keydown."+n,function(l){l.keyCode==27&&c.close(l)});return c},close:function(e){if(!c.isOpened())return c;e=e||a.Event();e.type="onBeforeClose";i.trigger(e);if(!e.isDefaultPrevented()){m=false;q[b.effect][1].call(c,function(){e.type="onClose";i.trigger(e)});a(document).unbind("click."+n).unbind("keydown."+n);g&&a.mask.close();return c}},getOverlay:function(){return f},
getTrigger:function(){return d},getClosers:function(){return k},isOpened:function(){return m},getConf:function(){return b}});a.each("onBeforeLoad,onStart,onLoad,onBeforeClose,onClose".split(","),function(e,h){a.isFunction(b[h])&&a(c).bind(h,b[h]);c[h]=function(j){a(c).bind(h,j);return c}});k=f.find(b.close||".close");if(!k.length&&!b.close){k=a('<a class="close"></a>');f.prepend(k)}k.click(function(e){c.close(e)});b.load&&c.load()}a.tools=a.tools||{version:"1.2.3"};a.tools.overlay={addEffect:function(d,
b,c){q[d]=[b,c]},conf:{close:null,closeOnClick:true,closeOnEsc:true,closeSpeed:"fast",effect:"default",fixed:!a.browser.msie||a.browser.version>6,left:"center",load:false,mask:null,oneInstance:true,speed:"normal",target:null,top:"10%"}};var s=[],q={};a.tools.overlay.addEffect("default",function(d,b){var c=this.getConf(),i=a(window);if(!c.fixed){d.top+=i.scrollTop();d.left+=i.scrollLeft()}d.position=c.fixed?"fixed":"absolute";this.getOverlay().css(d).fadeIn(c.speed,b)},function(d){this.getOverlay().fadeOut(this.getConf().closeSpeed,
d)});a.fn.overlay=function(d){var b=this.data("overlay");if(b)return b;if(a.isFunction(d))d={onBeforeLoad:d};d=a.extend(true,{},a.tools.overlay.conf,d);this.each(function(){b=new t(a(this),d);s.push(b);a(this).data("overlay",b)});return d.api?b:this}})

$.tools=$.tools||{version:'@VERSION'};var instances=[],tool,KEYS=[75,76,38,39,74,72,40,37],LABELS={};tool=$.tools.dateinput={conf:{format:'mm/dd/yy',selectors:false,yearRange:[-5,5],lang:'en',offset:[0,0],speed:0,firstDay:0,min:undefined,max:undefined,trigger:false,css:{prefix:'cal',input:'date',root:0,head:0,title:0,prev:0,next:0,month:0,year:0,days:0,body:0,weeks:0,today:0,current:0,week:0,off:0,sunday:0,focus:0,disabled:0,trigger:0}},localize:function(language,labels){$.each(labels,function(key,val){labels[key]=val.split(",");});LABELS[language]=labels;}};tool.localize("en",{months:'January,February,March,April,May,June,July,August,September,October,November,December',shortMonths:'Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec',days:'Sunday,Monday,Tuesday,Wednesday,Thursday,Friday,Saturday',shortDays:'Sun,Mon,Tue,Wed,Thu,Fri,Sat'});function dayAm(year,month){return 32-new Date(year,month,32).getDate();}
function zeropad(val,len){val=''+val;len=len||2;while(val.length<len){val="0"+val;}
return val;}
var Re=/d{1,4}|m{1,4}|yy(?:yy)?|"[^"]*"|'[^']*'/g,tmpTag=$("<a/>");function format(date,fmt,lang){var d=date.getDate(),D=date.getDay(),m=date.getMonth(),y=date.getFullYear(),flags={d:d,dd:zeropad(d),ddd:LABELS[lang].shortDays[D],dddd:LABELS[lang].days[D],m:m+1,mm:zeropad(m+1),mmm:LABELS[lang].shortMonths[m],mmmm:LABELS[lang].months[m],yy:String(y).slice(2),yyyy:y};var ret=fmt.replace(Re,function($0){return $0 in flags?flags[$0]:$0.slice(1,$0.length-1);});return tmpTag.html(ret).html();}
function integer(val){return parseInt(val,10);}
function isSameDay(d1,d2){return d1.getFullYear()===d2.getFullYear()&&d1.getMonth()==d2.getMonth()&&d1.getDate()==d2.getDate();}
function parseDate(val){if(!val){return;}
if(val.constructor==Date){return val;}
if(typeof val=='string'){var els=val.split("-");if(els.length==3){return new Date(integer(els[0]),integer(els[1])-1,integer(els[2]));}
if(!/^-?\d+$/.test(val)){return;}
val=integer(val);}
var date=new Date();date.setDate(date.getDate()+val);return date;}
function Dateinput(input,conf){var self=this,now=new Date(),css=conf.css,labels=LABELS[conf.lang],root=$("#"+css.root),title=root.find("#"+css.title),trigger,pm,nm,currYear,currMonth,currDay,value=input.attr("data-value")||conf.value||input.val(),min=input.attr("min")||conf.min,max=input.attr("max")||conf.max,opened;if(min===0){min="0";}
value=parseDate(value)||now;min=parseDate(min||conf.yearRange[0]*365);max=parseDate(max||conf.yearRange[1]*365);if(!labels){throw"Dateinput: invalid language: "+conf.lang;}
if(input.attr("type")=='date'){var tmp=$("<input/>");$.each("class,disabled,id,maxlength,name,readonly,required,size,style,tabindex,title,value".split(","),function(i,attr){tmp.attr(attr,input.attr(attr));});input.replaceWith(tmp);input=tmp;}
input.addClass(css.input);var fire=input.add(self);if(!root.length){root=$('<div><div><a/><div/><a/></div><div><div/><div/></div></div>').hide().css({position:'absolute'}).attr("id",css.root);root.children().eq(0).attr("id",css.head).end().eq(1).attr("id",css.body).children().eq(0).attr("id",css.days).end().eq(1).attr("id",css.weeks).end().end().end().find("a").eq(0).attr("id",css.prev).end().eq(1).attr("id",css.next);title=root.find("#"+css.head).find("div").attr("id",css.title);if(conf.selectors){var monthSelector=$("<select/>").attr("id",css.month),yearSelector=$("<select/>").attr("id",css.year);title.html(monthSelector.add(yearSelector));}
var days=root.find("#"+css.days);for(var d=0;d<7;d++){days.append($("<span/>").text(labels.shortDays[(d+conf.firstDay)%7]));}
$("body").append(root);}
if(conf.trigger){trigger=$("<a/>").attr("href","#").addClass(css.trigger).click(function(e){self.show();return e.preventDefault();}).insertAfter(input);}
var weeks=root.find("#"+css.weeks);yearSelector=root.find("#"+css.year);monthSelector=root.find("#"+css.month);function select(date,conf,e){value=date;currYear=date.getFullYear();currMonth=date.getMonth();currDay=date.getDate();e=e||$.Event("api");e.type="change";fire.trigger(e,[date]);if(e.isDefaultPrevented()){return;}
input.val(format(date,conf.format,conf.lang));input.data("date",date);self.hide(e);}
function onShow(ev){ev.type="onShow";fire.trigger(ev);$(document).bind("keydown.d",function(e){if(e.ctrlKey){return true;}
var key=e.keyCode;if(key==8){input.val("");return self.hide(e);}
if(key==27){return self.hide(e);}
if($(KEYS).index(key)>=0){if(!opened){self.show(e);return e.preventDefault();}
var days=$("#"+css.weeks+" a"),el=$("."+css.focus),index=days.index(el);el.removeClass(css.focus);if(key==74||key==40){index+=7;}
else if(key==75||key==38){index-=7;}
else if(key==76||key==39){index+=1;}
else if(key==72||key==37){index-=1;}
if(index>41){self.addMonth();el=$("#"+css.weeks+" a:eq("+(index-42)+")");}else if(index<0){self.addMonth(-1);el=$("#"+css.weeks+" a:eq("+(index+42)+")");}else{el=days.eq(index);}
el.addClass(css.focus);return e.preventDefault();}
if(key==34){return self.addMonth();}
if(key==33){return self.addMonth(-1);}
if(key==36){return self.today();}
if(key==13){if(!$(e.target).is("select")){$("."+css.focus).click();}}
return $([16,17,18,9]).index(key)>=0;});$(document).bind("click.d",function(e){var el=e.target;if(!$(el).parents("#"+css.root).length&&el!=input[0]&&(!trigger||el!=trigger[0])){self.hide(e);}});}
$.extend(self,{show:function(e){if(input.attr("readonly")||input.attr("disabled")||opened){return;}
e=e||$.Event();e.type="onBeforeShow";fire.trigger(e);if(e.isDefaultPrevented()){return;}
$.each(instances,function(){this.hide();});opened=true;monthSelector.unbind("change").change(function(){self.setValue(yearSelector.val(),$(this).val());});yearSelector.unbind("change").change(function(){self.setValue($(this).val(),monthSelector.val());});pm=root.find("#"+css.prev).unbind("click").click(function(e){if(!pm.hasClass(css.disabled)){self.addMonth(-1);}
return false;});nm=root.find("#"+css.next).unbind("click").click(function(e){if(!nm.hasClass(css.disabled)){self.addMonth();}
return false;});self.setValue(value);var pos=input.offset();if(/iPad/i.test(navigator.userAgent)){pos.top-=$(window).scrollTop();}
root.css({top:pos.top+input.outerHeight({margins:true})+conf.offset[0],left:pos.left+conf.offset[1]});if(conf.speed){root.show(conf.speed,function(){onShow(e);});}else{root.show();onShow(e);}
return self;},setValue:function(year,month,day){var date=integer(month)>=-1?new Date(integer(year),integer(month),integer(day||1)):year||value;if(date<min){date=min;}
else if(date>max){date=max;}
year=date.getFullYear();month=date.getMonth();day=date.getDate();if(month==-1){month=11;year--;}else if(month==12){month=0;year++;}
if(!opened){select(date,conf);return self;}
currMonth=month;currYear=year;var tmp=new Date(year,month,1-conf.firstDay),begin=tmp.getDay(),days=dayAm(year,month),prevDays=dayAm(year,month-1),week;if(conf.selectors){monthSelector.empty();$.each(labels.months,function(i,m){if(min<new Date(year,i+1,-1)&&max>new Date(year,i,0)){monthSelector.append($("<option/>").html(m).attr("value",i));}});yearSelector.empty();var yearNow=now.getFullYear();for(var i=yearNow+conf.yearRange[0];i<yearNow+conf.yearRange[1];i++){if(min<=new Date(i+1,-1,1)&&max>new Date(i,0,0)){yearSelector.append($("<option/>").text(i));}}
monthSelector.val(month);yearSelector.val(year);}else{title.html(labels.months[month]+" "+year);}
weeks.empty();pm.add(nm).removeClass(css.disabled);for(var j=!begin?-7:0,a,num;j<(!begin?35:42);j++){a=$("<a/>");if(j%7===0){week=$("<div/>").addClass(css.week);weeks.append(week);}
if(j<begin){a.addClass(css.off);num=prevDays-begin+j+1;date=new Date(year,month-1,num);}else if(j>=begin+days){a.addClass(css.off);num=j-days-begin+1;date=new Date(year,month+1,num);}else{num=j-begin+1;date=new Date(year,month,num);if(isSameDay(value,date)){a.attr("id",css.current).addClass(css.focus);}else if(isSameDay(now,date)){a.attr("id",css.today);}}
if(min&&date<min){a.add(pm).addClass(css.disabled);}
if(max&&date>max){a.add(nm).addClass(css.disabled);}
a.attr("href","#"+num).text(num).data("date",date);week.append(a);}
weeks.find("a").click(function(e){var el=$(this);if(!el.hasClass(css.disabled)){$("#"+css.current).removeAttr("id");el.attr("id",css.current);select(el.data("date"),conf,e);}
return false;});if(css.sunday){weeks.find(css.week).each(function(){var beg=conf.firstDay?7-conf.firstDay:0;$(this).children().slice(beg,beg+1).addClass(css.sunday);});}
return self;},setMin:function(val,fit){min=parseDate(val);if(fit&&value<min){self.setValue(min);}
return self;},setMax:function(val,fit){max=parseDate(val);if(fit&&value>max){self.setValue(max);}
return self;},today:function(){return self.setValue(now);},addDay:function(amount){return this.setValue(currYear,currMonth,currDay+(amount||1));},addMonth:function(amount){return this.setValue(currYear,currMonth+(amount||1),currDay);},addYear:function(amount){return this.setValue(currYear+(amount||1),currMonth,currDay);},hide:function(e){if(opened){e=$.Event();e.type="onHide";fire.trigger(e);$(document).unbind("click.d").unbind("keydown.d");if(e.isDefaultPrevented()){return;}
root.hide();opened=false;}
return self;},getConf:function(){return conf;},getInput:function(){return input;},getCalendar:function(){return root;},getValue:function(dateFormat){return dateFormat?format(value,dateFormat,conf.lang):value;},isOpen:function(){return opened;}});$.each(['onBeforeShow','onShow','change','onHide'],function(i,name){if($.isFunction(conf[name])){$(self).bind(name,conf[name]);}
self[name]=function(fn){if(fn){$(self).bind(name,fn);}
return self;};});input.bind("focus click",self.show).keydown(function(e){var key=e.keyCode;if(!opened&&$(KEYS).index(key)>=0){self.show(e);return e.preventDefault();}
return e.shiftKey||e.ctrlKey||e.altKey||key==9?true:e.preventDefault();});if(parseDate(input.val())){select(value,conf);}}
$.expr[':'].date=function(el){var type=el.getAttribute("type");return type&&type=='date'||!!$(el).data("dateinput");};$.fn.dateinput=function(conf){if(this.data("dateinput")){return this;}
conf=$.extend(true,{},tool.conf,conf);$.each(conf.css,function(key,val){if(!val&&key!='prefix'){conf.css[key]=(conf.css.prefix||'')+(val||key);}});var els;this.each(function(){var el=new Dateinput($(this),conf);instances.push(el);var input=el.getInput().data("dateinput",el);els=els?els.add(input):input;});return els?els:this;};

(jQuery);
/* [/End jQuery Tools] */






/* [Cookie plugin] */

/**
 * Cookie plugin
 *
 * Copyright (c) 2006 Klaus Hartl (stilbuero.de)
 * Dual licensed under the MIT and GPL licenses:
 * http://www.opensource.org/licenses/mit-license.php
 * http://www.gnu.org/licenses/gpl.html
 *
 */

/**
 * Create a cookie with the given name and value and other optional parameters.
 *
 * @example $.cookie('the_cookie', 'the_value');
 * @desc Set the value of a cookie.
 * @example $.cookie('the_cookie', 'the_value', {expires: 7, path: '/', domain: 'jquery.com', secure: true});
 * @desc Create a cookie with all available options.
 * @example $.cookie('the_cookie', 'the_value');
 * @desc Create a session cookie.
 * @example $.cookie('the_cookie', null);
 * @desc Delete a cookie by passing null as value.
 *
 * @param String name The name of the cookie.
 * @param String value The value of the cookie.
 * @param Object options An object literal containing key/value pairs to provide optional cookie attributes.
 * @option Number|Date expires Either an integer specifying the expiration date from now on in days or a Date object.
 *                             If a negative value is specified (e.g. a date in the past), the cookie will be deleted.
 *                             If set to null or omitted, the cookie will be a session cookie and will not be retained
 *                             when the the browser exits.
 * @option String path The value of the path atribute of the cookie (default: path of page that created the cookie).
 * @option String domain The value of the domain attribute of the cookie (default: domain of page that created the cookie).
 * @option Boolean secure If true, the secure attribute of the cookie will be set and the cookie transmission will
 *                        require a secure protocol (like HTTPS).
 * @type undefined
 *
 * @name $.cookie
 * @cat Plugins/Cookie
 * @author Klaus Hartl/klaus.hartl@stilbuero.de
 */

/**
 * Get the value of a cookie with the given name.
 *
 * @example $.cookie('the_cookie');
 * @desc Get the value of a cookie.
 *
 * @param String name The name of the cookie.
 * @return The value of the cookie.
 * @type String
 *
 * @name $.cookie
 * @cat Plugins/Cookie
 * @author Klaus Hartl/klaus.hartl@stilbuero.de
 */
jQuery.cookie = function(name, value, options) {
    if (typeof value != 'undefined') { // name and value given, set cookie
        options = options || {};
        if (value === null) {
            value = '';
            options.expires = -1;
        }
        var expires = '';
        if (options.expires && (typeof options.expires == 'number' || options.expires.toUTCString)) {
            var date;
            if (typeof options.expires == 'number') {
                date = new Date();
                date.setTime(date.getTime() + (options.expires * 24 * 60 * 60 * 1000));
            } else {
                date = options.expires;
            }
            expires = '; expires=' + date.toUTCString(); // use expires attribute, max-age is not supported by IE
        }
        var path = options.path ? '; path=' + options.path : '';
        var domain = options.domain ? '; domain=' + options.domain : '';
        var secure = options.secure ? '; secure' : '';
        document.cookie = [name, '=', encodeURIComponent(value), expires, path, domain, secure].join('');
    } else { // only name given, get cookie
        var cookieValue = null;
        if (document.cookie && document.cookie != '') {
            var cookies = document.cookie.split(';');
            for (var i = 0; i < cookies.length; i++) {
                var cookie = jQuery.trim(cookies[i]);
                // Does this cookie string begin with the name we want?
                if (cookie.substring(0, name.length + 1) == (name + '=')) {
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
};
/* [/End Cookie plugin] */