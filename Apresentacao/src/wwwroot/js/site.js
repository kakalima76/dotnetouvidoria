$(function () {
    $('#datetimepicker2').datetimepicker({
        locale: 'pt-br'
    });
});

$(function () {
    $('[data-toggle="tooltip"]').tooltip(
    {
        html: true,
        trigger: "hover"
        
    });
});


$('#bairro').change(function(){

    paramBairro = document.getElementById("bairro").value;
                                                                   
    $.get('/Formulario/Index/Json', {param: paramBairro}).done(function (logradouro) {
        
        var options = '<option value=""> </options>';
        $.each(logradouro, function(key, val){
            options += '<option value="' + val.logradouroId + '">' + val.nome + '</option>';    
        });

        $("#logradouro").html('<option></options').html(options);
    
    });
});

$('#categoria').change(function(){

    var id = document.getElementById("categoria").value;
    $('[data-toggle="tooltip"]').tooltip('dispose'); //destruo todos os tooltips
    
    
    console.log(id);

    if
        ( 
            parseInt(id) <= 1 || parseInt(id) >= 7
        )
    {
       
        $('#processo').attr("disabled", "disabled");
       
        $(function () {
            $('#label_processo').tooltip(
            {
                    
            toggle: 'tooltip',
            placement: 'top',
            trigger: "hover"
        
            });
        });

        $('#label_processo').attr('data-original-title', "Campo desnecessário");

    }else{
       
        $('#processo').removeAttr('disabled');

        $(function () {
            $('#label_processo').tooltip(
            {
                    
            toggle: 'tooltip',
            placement: 'top',
            trigger: "hover"
        
            });   
        });

        $('#label_processo').attr('data-original-title', 'Campo requerido');
       
    }

    if

    (
        id === "7" || id === "11" || id === "12"
    )
        {

                $('#detalhes').removeAttr('disabled');

                $(function () {
                    $('#label_detalhes').tooltip(
                    {
                            
                    toggle: 'tooltip',
                    placement: 'top',
                    trigger: "hover"
                
                });   
        });

        $('#label_detalhes').attr('data-original-title', 'Campo requerido');

    }else{
                $('#detalhes').attr("disabled", "disabled");
            
                $(function () {
                    $('#label_detalhes').tooltip(
                    {
                            
                    toggle: 'tooltip',
                    placement: 'top',
                    trigger: "hover"
                
                    });
                });

        $('#label_detalhes').attr('data-original-title', "Campo desnecessário");

    }

    if(parseInt(id) <= 3 || id === "10")
    {
        
            $('#constatacao').removeAttr('disabled');

            $(function () {
                $('#label_constatacao').tooltip(
                {
                        
                toggle: 'tooltip',
                placement: 'top',
                trigger: "hover"
            
            });   
    });

        $('#label_constatacao').attr('data-original-title', 'Campo requerido');
    }else{
            $('#constatacao').attr("disabled", "disabled");
            
            $(function () {
                $('#label_constatacao').tooltip(
                {
                    
                    toggle: 'tooltip',
                    placement: 'top',
                    trigger: "hover"
        
                });
        });

        $('label_constatacao').attr('data-original-title', "Campo desnecessário");
    }

    if(id === "8")
    {
        
                $('#observacoes').removeAttr('disabled');

                $(function () {
                    $('#label_observacoes').tooltip(
                    {
                            
                    toggle: 'tooltip',
                    placement: 'top',
                    trigger: "hover"
                
                });   
        });

        $('label_observacoes').attr('data-original-title', "Campo requerido");
    }else{
                $('#observacoes').attr("disabled", "disabled");
            
                 $(function () {
                    $('#label_observacoes').tooltip(
                    {
                        
                        toggle: 'tooltip',
                        placement: 'top',
                        trigger: "hover"
            
                    });
        });

        $('#label_observacoes').attr('data-original-title', "Campo desnecessário");
    }

});

