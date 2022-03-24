$(function (e) {

    $("#idguardar").on("click", function () {
  
        GuardarMedico()
    });
 
    $("#txtStartDate, #txtEndDate").datepicker({
        autoclose: true,
        format: "dd/mm/yyyy"
    });
 

    $("#iddirecto").on("click", function () {
        if ($("#iddirecto").prop('checked', true)) {
            $("#idcompensacion").prop('checked', false)
            var valorchek = 'directo'
            $("#iddirectohidden").val(valorchek);
            $("#idcompensacionhidden").val("");
        } else {
            var valorchek = ''
            $("#idcompensacionhidden").val("");
        }


    });

    $("#idcompensacion").on("click", function () {
        if ($("#idcompensacion").prop('checked', true)) {
            $("#iddirecto").prop('checked', false)
            var valorchek = 'compensacion'
            $("#idcompensacionhidden").val(valorchek);
            $("#iddirectohidden").val("");
        } else {
            var valorchek = ''
            $("#idcompensacionhidden").val("");
        }

    });
       

});

 
  
       // public int ide_contrato { get; set; }
       // public string ? cod_medico { get; set; }
       // public string ? cod_sede { get; set; }
       // public string ? flg_forma_pago { get; set; }
       // public float mnt_mensual { get; set; }
       // public DateTime fec_inicio { get; set; }
       // public DateTime fec_fin { get; set; }
       // public DateTime @fec_registro { get; set; }
       // public string ? usr_registro { get; set; }
       // public string ? flg_estado { get; set; }
function GuardarMedico() {
    console.log("entro fncion guardar");
    var valorfinal;

    if ($("#iddirectohidden").val() != '') {
        valorfinal = $("#iddirectohidden").val();
    } else {
        valorfinal = $("#idcompensacionhidden").val();
    }

    console.log(valorfinal);
    //Verificacion=
    var txtMedicos = $("#txtMedicos").val();
    var idrentamensual = $("#idrentamensual").val();
    //var iddirecto = $("#iddirecto").val();
    //var idcompensacion = $("#idcompensacion").val();
    var txtStartDate = $("#txtStartDate").val();
    var txtEndDate = $("#txtEndDate").val();
    var idduracion = $("#idduracion").val();
 
    var parametro = new Object();

    parametro.cod_medico = txtMedicos;
    parametro.mnt_mensual = idrentamensual;
    parametro.flg_forma_pago = valorfinal;
    parametro.fec_inicio = txtStartDate;
    parametro.fec_fin = txtEndDate;
    //parametro.fec_registro = idduracion;
    parametro.flg_estado= 1;
     
    Post("Mantenimiento/GuardarMedicosContrato", parametro).done(function (response) {
        console.log("-----------respuesta del guardado");
        console.log(response);
        console.log(response.data);

        if (response.data.code == 0) {
            fnAlertSuccess(response.data.message, function () {
                window.location = fnBaseUrlWeb("Mantenimiento/Index");
            });

        } else {
            fnAlertError(response.data.message);
        }
    });
}


function obtenervalor(valorchek) {
    return valorchek;
}