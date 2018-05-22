/**
 * @license Copyright (c) 2003-2018, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see https://ckeditor.com/legal/ckeditor-oss-license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
    config.filebrowserImageUploadUrl = "/ImageUpload.ashx";
     // config.filebrowserImageUploadUrl = "/ImageUpload/Upload"
    config.language = 'zh-cn';
    config.toolbarCanCollapse = true;
   // config.skin = 'v2';
    config.image_previewText = ' ';
    config.removeDialogTabs = 'image:advanced;image:Link';
};
