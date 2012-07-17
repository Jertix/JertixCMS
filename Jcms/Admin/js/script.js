	/* [jNotify] */
	$(document).ready(function () {
		setTimeout(function () {
			$('.jnotify-container').fadeOut('fast');
		}, 8000);
	});
	/* [/End jNotify] */

/* [jQuery] */
$(function() {

	/* [Tooltips and Calendar] */
	$("ul.tabs").tabs("div.panes > div");
	$(".css_tooltip").tooltip({ position: "bottom left", opacity: 0.98, predelay: 500, offset: [-10, -5]});	
	$(".date input").dateinput();
	/* [/End Tooltips and Calendar] */	
	
	/* [FAQ] */
	$('.sidebar-left h2').collapser({
		target: 'next',
		targetOnly: 'ul',
		changeText: 0,
		expandClass: 'expArrow',
		collapseClass: 'collArrow'
	});
	/* [/End FAQ] */
	
	/* [Collapse Left Sidebar] */	
	$('.dash-expand').collapser({
		target: 'next',
		targetOnly: '.dash-content',
		changeText: 0,
		expandClass: 'expArrow',
		collapseClass: 'collArrow'
	});
	/* [/End Collapse Left Sidebar] */
	
	/* [Replace browse input field] */
	 $("input[type=file]").filestyle({ 
		image: "img/general/general-choose-file.png",
		imageheight : 22,
		imagewidth : 82,
		width : 160
	 });
	/* [/End Replace browse input field] */
	
	/* [ShadowBox] */
	Shadowbox.init({
	    viewportPadding: "5"
    });
	/* [/End ShadowBox] */

/* [Modal] */
$('#dialog').jqm();

	$('.modal').jqm({
		modal: true,
		trigger: '#delete',
		overlay: 20, 
		overlayClass: 'modal-overlay'})
	$('input.modal-close');
	/* [/End Modal] */	
	
	/* [jNotify] */
	$(".btn-saves a, .btn-preview a, .btn-addanother, .btn-continue-editing, .btn-close, .group-move-up, .group-move-down, .group-add, .group-delete").bind("click", function (e){
		// prevent default behavior
		e.preventDefault();	
		var $ex = $($(this).attr("href")), code = $.trim($ex.text());	
		// execute the sample code
		$.globalEval(code);
	});
	/* [/End jNotify] */

	/* [Preloader] */
	var image1 = $('<img />').attr('src', 'img/general/general-modal.png');
	var image1 = $('<img />').attr('src', 'img/general/tooltip-triangle.png');
	var image1 = $('<img />').attr('src', 'img/general/tooltip-bg.jpg');
	var image1 = $('<img />').attr('src', 'img/icons/notify-error.jpg');
	var image1 = $('<img />').attr('src', 'img/icons/notify-successful.jpg');
	var image1 = $('<img />').attr('src', 'img/icons/notify-warning.jpg');	
	/* [/End Preloader] */

});
/* [/End jQuery] */