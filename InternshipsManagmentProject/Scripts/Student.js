function FormSetup(submitName) {
    $("#addNewSkill").click(() => $("#skillsList").append('<li><input name="Skills" value="' + $("#input_newSkill").val() + '"/>' + '</li>'));
    RefreshSubmit();
    $('#input_name').on('input', (e) => RefreshSubmit());
    $("#form_button").hover(() => $("#form_button").val("Name cannot be empty!"), () => $("#form_button").val(submitName));
}
function RefreshSubmit() {
    if ($("#input_name").val().length == 0) {
        $("#form_submit").hide();
        $("#form_button").show();
    }
    else {
        $("#form_submit").show();
        $("#form_button").hide();
    }
}
