var probs;
function FormSetup() {
    $("#form_button").val();
    $("#addNewSkill").click(() => {
        $("#skillsList").append('<li><input name="Skills" value="' + $("#input_newSkill").val() + '"/>' + '</li>');
        $("#input_newSkill").val("");
        $("#addNewSkill").attr("disabled","disabled");
    });
    RefreshSubmit();
    $('#input_newSkill').on('input', (e) => {
        if ($("#input_newSkill").val().length > 0) $("#addNewSkill").removeAttr("disabled");
    });
    $('#input_name').on('input', (e) => RefreshSubmit());
    $('#input_image').on('input', (e) => alert($('#input_image').val()));
    $('#input_lastName').on('input', (e) => RefreshSubmit());
    $('#input_birthday').on('input', (e) => RefreshSubmit());
    $("#form_button").hover(() => $("#form_button").val(probs), () => $("#form_button").val($("#form_submit").val()));
}
function RefreshSubmit() {
    probs = "";
    if ($("#input_name").val().length == 0) {
        probs += "Nume ";
    }
    if ($("#input_lastName").val().length == 0) {
        probs += "Prenume ";
    }
    if ($("#input_birthday").val().length == 0) {
        probs += "Data Nasterii";
    }
    if (probs.length > 0) {
        probs = "Trebuie:" + probs;
        $("#form_submit").hide();
        $("#form_button").show();
    }
    else {
        $("#form_submit").show();
        $("#form_button").hide();
    }
}
