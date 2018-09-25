$(function () {

    $('#datetimepicker').datetimepicker({
        locale: 'pt-br'
    });

    $('#datetimepicker2').datetimepicker({
        locale: 'pt-br'
    });
    $('#datetimepicker3').datetimepicker({
        locale: 'pt-br'
    });
});


//botão para limpar o campo de busca de chamado por número
$('#limparCampo').click(function(){
    $('#queryNumero').val('');
});


//O botão de download para excel deverá iniciar escondido
$('#excel').hide();



$(function () {
    $('[data-toggle="tooltip"]').tooltip(
        {
            html: true,
            trigger: "hover"

        });
});


$(function () {
    $('#selectAcoes').prop("disabled", true);
    $('#constatacao').prop("disabled", true);
    $('#processo').prop("disabled", true);
    $('#detalhes').prop("disabled", true);
    $('#observacoes').prop("disabled", true);
    $('#analise').prop("disabled", true);
    $('#inconsistencia').prop("disabled", true);
    $('#selectOrgaos').prop("disabled", true);
});

function isEmpty(val) {
    return (val === undefined || val == null || val.length <= 0) ? true : false;
}

var padronizaData = function (data) {
    var dia = data.substring(8, 10);
    var mes = data.substring(5, 7);
    var ano = data.substring(0, 4);
    var hor = data.substring(11, 13);
    var min = data.substring(14, 16);

    return dia + '/' + mes + '/' + ano + ' às ' + hor + ':' + min;

};


//Toda vez que forem escolhidos uma data de iníio e fim 
//o botão de download excel ficará escondico
$('#btnInicio').click(function () {
    $('#excel').hide();
});

$('#btnFim').click(function () {
    $('#excel').hide();
});

//Toda vez que forem escolhidos uma bairro e um logradouro
//o botão de download excel ficará escondico



$('#bairro').change(function () {

    paramBairro = document.getElementById("bairro").value;
    
    $.get('/Formulario/Index/Json', { param: paramBairro }).done(function (logradouro) {
       
        console.log(logradouro);

        var options = '<option value=""> </options>';
        $.each(logradouro, function (key, val) {
            options += '<option value="' + val.logradouroId + '">' + val.nome + '</option>';
        });

        $("#logradouro").html(options);
        

    });
});


$('#logradouroLocal').change(function(){
    $('#excel').hide();
});

$('#bairroQueryLocal').change(function () {

    $('#excel').hide();
    $('#queryLocal').empty();

    paramBairro = document.getElementById("bairroQueryLocal").value;

    $.get('/Pesquisas/Local/Index/Json', { param: paramBairro }).done(function (logradouro) {

        var options = '<option value=""> </options>';
        $.each(logradouro, function (key, val) {
            options += '<option value="' + val.logradouroId + '">' + val.nome + '</option>';
        });

        $("#logradouroLocal").html(options);
       

    });
});

$('#pesquisarData').click(function () {

    $("#queryData").empty();
    var dataInicio = document.getElementById('dataInicio').value;
    var dataFim = document.getElementById('dataFim').value;

    if (isEmpty(dataInicio) || isEmpty(dataFim)) {
        alert("Informe uma data de inicio e uma data de fim da pesquisa!");
    } else {
        var obj = {
            'dataInicio': dataInicio,
            'dataFim': dataFim
        };

        $.get('/Pesquisas/Data/Index/Json', obj).done(function (denuncia) {

            var options = "";

            $.each(denuncia, function (key, val) {

                options += '<div class="resposta">' +
                    '<label class="form-control blue">NÚMERO</label>' + '<ul>' +
                    '<li>' + val.numero + '</li>' + '</ul>' +
                    '<label class="form-control  blue">DATA</label>' + '<ul>' +
                    '<li>' + padronizaData(val.data) + '</li>' + '</ul>' +
                    '<label class="form-control  blue">BAIRRO</label>' + '<ul>' +
                    '<li>' + val.bairro + '</li>' + '</ul>' +
                    '<label class="form-control blue" >LOGRADOURO</label>' + '<ul>' +
                    '<li>' + val.logradouro + '</li>' + '</ul>' +
                    '<label class="form-control blue">COMPLEMENTO</label>' + '<ul>' +
                    '<li>' + (val.complemento || '') + '</li>' + '</ul>' +
                    '<label class="form-control blue">PROCESSO</label>' + '<ul>' +
                    '<li>' + (val.processo || '') + '</li>' + '</ul>' +
                    '<label class="form-control blue">RESPOSTA</label>' + '<ul>' +
                    '<li class="justificado">' + val.respostaPadrao + '</li>' + '</ul>' +
                    '<label class="form-control blue">GEOREFERENCIADORES</label>' + '<ul>' +
                    '<li class="justificado"> CEP: ' + val.cep + '</li>' +
                    '<li class="justificado"> Lat: ' + val.lat + '</li>' +
                    '<li class="justificado"> Lng: ' + val.lng + '</li>' + '</ul>' +
                    '</div>';
            });


            $("#queryData").html(options);
            $('#excel').show();

        });
    }

});


$('#pesquisarLocal').click(function () {

    var bairro = document.getElementById('bairroQueryLocal').value;
    var logradouro = document.getElementById('logradouroLocal').value;



    if (isEmpty(bairro) || isEmpty(logradouro)) {
        alert("Selecione um bairro e um logradouro!");
    } else {
        var obj = {
            'bairro': bairro,
            'logradouro': logradouro
        };


        var options = "";

        $.get('/Pesquisas/Local/Index/JsonLocais', obj).done(function (denuncia) {

            $.each(denuncia, function (key, val) {

                options += '<div class="resposta">' +
                    '<label class="form-control blue">NÚMERO</label>' + '<ul>' +
                    '<li>' + val.numero + '</li>' + '</ul>' +
                    '<label class="form-control  blue">DATA</label>' + '<ul>' +
                    '<li>' + padronizaData(val.data) + '</li>' + '</ul>' +
                    '<label class="form-control  blue">BAIRRO</label>' + '<ul>' +
                    '<li>' + val.bairro + '</li>' + '</ul>' +
                    '<label class="form-control blue" >LOGRADOURO</label>' + '<ul>' +
                    '<li>' + val.logradouro + '</li>' + '</ul>' +
                    '<label class="form-control blue">COMPLEMENTO</label>' + '<ul>' +
                    '<li>' + (val.complemento || '') + '</li>' + '</ul>' +
                    '<label class="form-control blue">PROCESSO</label>' + '<ul>' +
                    '<li>' + (val.processo || '') + '</li>' + '</ul>' +
                    '<label class="form-control blue">RESPOSTA</label>' + '<ul>' +
                    '<li class="justificado">' + val.respostaPadrao + '</li>' + '</ul>' +
                    '<label class="form-control blue">GEOREFERENCIADORES</label>' + '<ul>' +
                    '<li class="justificado"> CEP: ' + val.cep + '</li>' +
                    '<li class="justificado"> Lat: ' + val.lat + '</li>' +
                    '<li class="justificado"> Lng: ' + val.lng + '</li>' + '</ul>' +
                    '</div>';
            });

            $("#queryLocal").html(options);
            $('#excel').show();

        });


    }

});



$('#pesquisarNumero').click(function () {

    $("#queryNumeroEncontrado").empty();
    var numero = document.getElementById('queryNumero').value;


    if (isEmpty(numero)) {
        alert("Informe um numero!");
    } else {
        var obj =
        {
            'numero': numero
        };


        var options = "";

        $.get('/Pesquisas/Numero/Index/Json', obj).done(function (denuncia) {


            $.each(denuncia, function (key, val) {

                options += '<div class="resposta">' +
                    '<label class="form-control blue">NÚMERO</label>' + '<ul>' +
                    '<li>' + val.numero + '</li>' + '</ul>' +
                    '<label class="form-control  blue">DATA</label>' + '<ul>' +
                    '<li>' + padronizaData(val.data) + '</li>' + '</ul>' +
                    '<label class="form-control  blue">BAIRRO</label>' + '<ul>' +
                    '<li>' + val.bairro + '</li>' + '</ul>' +
                    '<label class="form-control blue" >LOGRADOURO</label>' + '<ul>' +
                    '<li>' + val.logradouro + '</li>' + '</ul>' +
                    '<label class="form-control blue">COMPLEMENTO</label>' + '<ul>' +
                    '<li>' + (val.complemento || '') + '</li>' + '</ul>' +
                    '<label class="form-control blue">PROCESSO</label>' + '<ul>' +
                    '<li>' + (val.processo || '') + '</li>' + '</ul>' +
                    '<label class="form-control blue">RESPOSTA</label>' + '<ul>' +
                    '<li class="justificado">' + val.respostaPadrao + '</li>' + '</ul>' +
                    '<label class="form-control blue">GEOREFERENCIADORES</label>' + '<ul>' +
                    '<li class="justificado"> CEP: ' + val.cep + '</li>' +
                    '<li class="justificado"> Lat: ' + val.lat + '</li>' +
                    '<li class="justificado"> Lng: ' + val.lng + '</li>' + '</ul>' +
                    '</div>';
            });

            $("#queryNumeroEncontrado").html(options);

        });


    }

});



var limparCampos = function () {
    $('#selectAcoes').empty();
    $('#constatacao').val('');
    $('#processo').val('');
    $('#detalhes').val('');
    $('#observacoes').val('');
    $('#analise').val('');
    $('#inconsistencia').val('');
    $('#selectOrgaos').empty();
};


$('#categoria').change(function () {

    limparCampos();

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
    ) {

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

    } else {

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
    ) {

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

    } else {
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

    if (parseInt(id) <= 3 || id === "10") {

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
    } else {
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

    if (id === "8") {

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
    } else {
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

    if (parseInt(id) <= 3 || id === "10") {

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
    } else {
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

    if (id === "11" || id === "12") {

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
    } else {
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

    if (id === "13" || id === "14") {

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
    } else {
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

    if (parseInt(id) <= 2) {

        $('#selectAcoes').removeAttr('disabled');

        if (id === "0") {



            var options = arrayEfetivo;
            $('#selectAcoes').empty();
            $.each(options, function (i, p) {
                $('#selectAcoes').append($('<option></option>').val(p).html(p));
            });


        } else {
            var opt = arrayNãoEfetivo;
            $('#selectAcoes').empty();
            $.each(opt, function (i, p) {
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




    } else {

        $('#selectAcoes').attr("disabled", "disabled");

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

    if (id === "13" || id === "14") {

        $('#selectOrgaos').removeAttr('disabled');


        var optOrgaos = arrayOrgaos;
        $('#selectOrgaos').empty();
        $.each(optOrgaos, function (i, p) {
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

    } else {

        $('#selectOrgaos').attr("disabled", "disabled");

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

$('#btnGerarResposta').click(function () {
    var data = document.getElementById("data").value || "";

    if (!isEmpty(data)) {

        var id = document.getElementById("categoria").value;
        var acaoAdotada = document.getElementById("selectAcoes").value || "";
        var constatacao = document.getElementById("constatacao").value || "";
        var processo = document.getElementById("processo").value || "";
        var detalhes = document.getElementById("detalhes").value || "";
        var observacoes = document.getElementById("observacoes").value || "";
        var inconsistencia = document.getElementById("inconsistencia").value || "";
        var analise = document.getElementById("analise").value || "";
        var orgaos = document.getElementById("selectOrgaos").value || "";
        var respostaPadrao = "";


        //textos para o inicio da resposta padrão gerada
        var textoInicial01 = "A equipe vistoriou o local em ";
        var textoInicial02 = "Informamos que a sua solicitação foi incluída no processo administrativo ";
        var textoInicial03 = "A equipe realizou operação de ordenamento urbano no local em ";
        var textoInicial04 = "A equipe analisou sua solicitação em ";

        //textos para o meio da resposta padrão gerada

        var textoMeio01 = " horas, onde constatou ";
        var textoMeio02 = ". A ação adotada foi ";
        var textoMeio03 = ". Para realizar operação de ordenamento urbano foi aberto o processo administrativo ";
        var textoMeio04 = " com objetivo de planejar operação de ordenamento urbano, o que dependerá do forte apoio dos órgãos de segurança. Acompanhe o andamento do processo pelo site http://www2.rio.rj.gov.br/sicop/ . A Coordenadoria de Controle Urbano agradece a sua solicitação!";
        var textoMeio05 = " e será realizada operação de ordenamento urbano com apoio de outros órgãos públicos. Acompanhe o andamento do processo pelo site http://www2.rio.rj.gov.br/sicop/ . A Coordenadoria de Controle Urbano agradece a sua solicitação!";
        var textoMeio06 = " com objetivo de legalizar e organizar as atividades no local. Acompanhe o andamento do processo pelo site http://www2.rio.rj.gov.br/sicop/ . A Coordenadoria de Controle Urbano agradece a sua solicitação!";
        var textoMeio07 = ". Caso a irregularidade retorne, favor registrar novo chamado 1746. A Coordenadoria de Controle Urbano agradece a confiança!";
        var textoMeio08 = " horas, e não foram constatadas evidências de irregularidades. Caso a irregularidade retorne, favor registrar novo chamado 1746. A Coordenadoria de Controle Urbano agradece a confiança!";
        var textoMeio09 = ". No momento da fiscalização, não ocorriam irregularidades. Caso ocorram, favor registrar novo chamado 1746. A Coordenadoria de Controle Urbano agradece a confiança!";
        var textoMeio10 = " horas, e não foi possível atendê-lo porque ";
        var textoMeio11 = " e não foi possível atendê-lo porque se trata de ";
        var textoMeio12 = ". Favor registrar novo chamado 1746 contendo ";

        //textos para o fim da resposta padrão gerada

        var textoFim01 = ". Caso a irregularidade persista, favor registrar uma reclamação por meio da Central 1746. A Coordenadoria de Controle Urbano agradece a confiança!";
        var textoFim02 = " e será necessário apoio de outros órgãos públicos. Acompanhe o andamento do processo pelo site http://www2.rio.rj.gov.br/sicop/ . A Coordenadoria de Controle Urbano agradece a sua solicitação!";
        var textoFim03 = ". A Coordenadoria de Controle Urbano agradece a sua solicitação!";
        var textoFim04 = ". A Coordenadoria de Controle Urbano fiscaliza atividades econômicas exercidas em áreas públicas. ";
        var textoFim05 = " Por isso, sua solicitação será transferida a ";

        var arrayResposta =
            [
                textoInicial01 + data.substring(0, 10) + ", às" + data.substring(10) +
                textoMeio01 + constatacao + textoMeio02 + acaoAdotada + textoMeio07,

                textoInicial01 + data.substring(0, 10) + ", às" + data.substring(10) +
                textoMeio01 + constatacao + textoMeio02 + acaoAdotada + textoMeio07,

                textoInicial01 + data.substring(0, 10) + ", às" + data.substring(10) +
                textoMeio01 + constatacao + textoMeio02 + acaoAdotada + textoMeio03 +
                processo + textoFim02,

                textoInicial01 + data.substring(0, 10) + ", às" + data.substring(10) +
                textoMeio01 + constatacao + "." + textoMeio03 + processo + textoFim02,

                textoInicial02 + processo + textoMeio04,

                textoInicial02 + processo + textoMeio05,

                textoInicial02 + processo + textoMeio06,

                textoInicial03 + data.substring(0, 10) + ', às ' + data.substring(10) +
                'horas, e' + detalhes + textoMeio07,

                "Em " + data.substring(0, 10) + ', às ' + data.substring(10) + " horas, foi observado " +
                observacoes + ".",

                textoInicial03 + data.substring(0, 10) + ', às ' + data.substring(10) + textoMeio08,

                textoInicial03 + data.substring(0, 10) + ', às ' + data.substring(10) + textoMeio01 +
                constatacao + textoMeio09,

                textoInicial03 + data.substring(0, 10) + ', às ' + data.substring(10) + textoMeio10 +
                inconsistencia + textoMeio12 + detalhes + textoFim03,

                textoInicial01 + data.substring(0, 10) + ', às ' + data.substring(10) + textoMeio10 +
                inconsistencia + textoMeio12 + detalhes + textoFim03,

                textoInicial04 + data.substring(0, 10) + textoMeio11 + analise + textoFim04 +
                textoFim05 + orgaos + ".",

                textoInicial01 + data.substring(0, 10) + ', às ' + data.substring(10) + " horas " + textoMeio11 +
                analise + textoFim04 + textoFim05 + orgaos + "."

            ];

        $('#respostaPadrao').val(arrayResposta[parseInt(id)] || '');
    } else {
        alert("Preencha a data!!!");
    }

});

