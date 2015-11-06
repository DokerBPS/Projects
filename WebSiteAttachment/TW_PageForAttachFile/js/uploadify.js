function setUploadify() {
    $(function () {
        $("#file_upload").uploadify({
            'swf': 'uploadify.swf',
            'uploader': '/Upload.ashx',
            'multi': false,
            'fileSizeLimit': '500MB',
            'successTimeout': 72000,
            'auto': true,
            'width': 84,
            'height': 18
        });
    });
}