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

        $("#logradouro").html(options);
    
    });
});

$('#categoria').change(function(){

    var id = document.getElementById("categoria").value;
    $('[data-toggle="tooltip"]').tooltip('dispose'); //destruo todos os tooltips
    var arrayEfetivo =

    [
        "",
        "a retirada imediata e emissão da Notificação de Desocupação",
        "o ajuste imediato e emissão da Notificação de Adequação",
        "a aplicação de multa",
        "a apreensão de mercadorias e equipamentos",
        "a apreensão de mercadorias",
        "a apreensão de equipamentos",
    ];

    var arrayNãoEfetivo = 

    [
        "",
        "a emissão da Notificação de Desocupação", 
        "a emissão da Notificação de Adequação",
        "a emissão e fixação na estrutura da Notificação a Desocupação"
    ];

    var arrayOrgaos = 
    [
        "",
        "Guarda Municipal do Rio de Janeiro - GM-Rio",
        "Companhia Municipal de Limpeza Urbana - COMLURB",
        "Coordenadoria de Licenciamento e Fiscalização - CLF",
        "Coordenação de Feiras - CFE",
        "Vigilância Sanitária - VISA",
        "Secretaria Municipal de Assistência Social e Direitos Humanos - SMASDH",
        "Secretaria Municipal de Conservação e Meio Ambiente - SECONSERMA",
        "Secretaria Municipal de Desenvolvimento, Emprego e Inovação - SMDEI",
        "Secretaria Municipal de Fazenda - SMF",
        "Secretaria Municipal de Ordem Pública - SEOP",
        "Secretaria Municipal de Transportes - SMTR",
        "Secretaria Municipal de Urbanismo, Infraestrutura e Habitação - SMUIH",
        "Companhia de Engenharia de Tráfego do RJ - CET-Rio",
        "Companhia Municipal de Energia e Iluminação - RIOLUZ"
    ];
          

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

        $('#label_constatacao').attr('data-original-title', "Campo desnecessário");
    }

    if(id === "11" || id === "12")
    {
        
                $('#inconsistencia').removeAttr('disabled');

                $(function () {
                    $('#label_inconsistencia').tooltip(
                    {
                            
                    toggle: 'tooltip',
                    placement: 'top',
                    trigger: "hover"
                
                });   
        });

        $('#label_inconsistencia').attr('data-original-title', "Campo requerido");
    }else{
                $('#inconsistencia').attr("disabled", "disabled");
            
                 $(function () {
                    $('#label_inconsistencia').tooltip(
                    {
                        
                        toggle: 'tooltip',
                        placement: 'top',
                        trigger: "hover"
            
                    });
        });

        $('#label_inconsistencia').attr('data-original-title', "Campo desnecessário");
    }

    if(id === "13" || id === "14")
    {
        
                $('#analise').removeAttr('disabled');

                $(function () {
                    $('#label_analise').tooltip(
                    {
                            
                    toggle: 'tooltip',
                    placement: 'top',
                    trigger: "hover"
                
                });   
        });

        $('#label_analise').attr('data-original-title', "Campo requerido");
    }else{
                $('#analise').attr("disabled", "disabled");
            
                 $(function () {
                    $('#label_analise').tooltip(
                    {
                        
                        toggle: 'tooltip',
                        placement: 'top',
                        trigger: "hover"
            
                    });
        });

        $('#label_analise').attr('data-original-title', "Campo desnecessário");
    }

    if(parseInt(id) <= 2){

        if(id === "0"){
            

            var options = arrayEfetivo;
            $('#selectAcoes').empty();
            $.each(options, function(i, p) {
                $('#selectAcoes').append($('<option></option>').val(p).html(p));
            });


        }else{
            var opt = arrayNãoEfetivo;
            $('#selectAcoes').empty();
            $.each(opt, function(i, p) {
                $('#selectAcoes').append($('<option></option>').val(p).html(p));
            });
        }

        $(function () {
            $('#label_acoes').tooltip(
            {
                    
            toggle: 'tooltip',
            placement: 'top',
            trigger: "hover"
        
            });   
        });

        $('#label_acoes').attr('data-original-title', "Campo requerido");
       



    }else{

            $('#selectAcoes').empty();

            $(function () {
                $('#label_acoes').tooltip(
                {
                    
                    toggle: 'tooltip',
                    placement: 'top',
                    trigger: "hover"
        
            });
        });

        $('#label_acoes').attr('data-original-title', "Campo desnecessário");

    }

    if(id === "13" || id === "14"){

        var optOrgaos = arrayOrgaos;
        $('#selectOrgaos').empty();
        $.each(optOrgaos, function(i, p) {
            $('#selectOrgaos').append($('<option></option>').val(p).html(p));
        });


        $(function () {
            $('#label_orgaos').tooltip(
            {
                    
            toggle: 'tooltip',
            placement: 'top',
            trigger: "hover"
        
            });   
        });

        $('#label_orgaos').attr('data-original-title', "Campo requerido");

    }else{

        $('#selectOrgaos').empty();

        
            $(function () {
                $('#label_orgaos').tooltip(
                {
                    
                    toggle: 'tooltip',
                    placement: 'top',
                    trigger: "hover"
        
            });
        });

        $('#label_orgaos').attr('data-original-title', "Campo desnecessário");


    }


    //Ainda há funções a serem implementadas...passando para algom mais divertido

 




});

