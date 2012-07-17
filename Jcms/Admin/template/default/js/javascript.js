/* [jQuery] */
$(function() {

	/* [Fix Z-Index] */
	$("#main-menu").css("z-index","9999");
	/* [/End Fix Z-Index] */
	
	/* [DropDown Menu] */	
	function addMega(){
		$(this).addClass("hovering");
		}
		function removeMega(){
		$(this).removeClass("hovering");
		}
	var megaConfig = {
		interval: 80,
		sensitivity: 4,
		over: addMega,
		timeout: 300,
		out: removeMega
	}
	$("#main-menu ul li").hoverIntent(megaConfig)
	/* [/End DropDown Menu] */	

	/* [Slide Show] */	
	$('#slide').DDSlider({ 
		trans: 'fading', 
		delay: 50, 
		ease: 'swing', 
		waitTime: 6000, 
		duration: 500, 
		stopSlide: 1, 
		bars: 15, 
		columns: 9, 
		rows: 3, 
		selector: null, 
		arrowNext: null, 
		arrowPrev: null 
		}); 
	/* [/End Slide Show] */	
	
	/* [Colorbox] */
	$("a[rel='colorbox-products-it']").colorbox({maxWidth:980, maxHeight:500, scalePhotos:true, previous:"Immagine precedente", next:"Immagine Successiva", close:"Chiudi", current:"Immagine {current} di {total}"});
	/* [/End Colorbox] */
	
	/* [Modal] */
	$('.modal').jqm({
		modal: true,
		trigger: '#login-modal',
		overlay: 40, 
		overlayClass: 'modal-overlay'})
	$('input.modal-close');	
	/* [/End Modal] */

	/* [Login Form] */	
	$('#username').example('Nome Utente');
	$('#password').example('Password');
	$(".modal-content").validate();
	/* [/End Login Form] */		
	
});	
/* [/End jQuery] */