jQuery(function ($) {
	$.validator.addMethod('number', function (value, element) {
		return this.optional(element) || /^\d+$/.test(value);
	});

});