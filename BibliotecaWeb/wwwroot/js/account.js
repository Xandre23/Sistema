﻿$(document).ready(function () {
    $("#frm-create-account").validate({
        rules: {
            inputNome: {
                required: true,
                maxlength: 20,
                minlength: 5

            },
            inputSobrenome: {
                required: true,
                maxlength: 80,
                minlength: 4
            },

            inputEmail: {
                required: true,
                email: true

            },
            inputPassword: {
                required: true

            }
        },
        messages: {
            inputNome: {
                required: 'Por favor, Insira seu nome',
                minlength: 'Nome deve ter no mínimo 5 caracteres',
                maxlength: 'Nome é muito grande'
            },
            inputSobrenome: {
                required: 'Por favor, Insira seu sobrenome.',
                minlength: 'Sobrenome deve ter no mínimo 10 caracteres',
                maxlength: 'Sobrenome é muito grande'
            },
            inputEmail: {
                required: 'Por favor, Insira seu email.',
                email: "Preencha com um E-mail válido",
            },
            inputPassword: {
                required: 'Por favor, Insira sua senha.'
            }
        },
        submitHandler: function () {
            var user = {
                Nome: $("#inputNome").val(),
                Sobrenome: $("#inputSobrenome").val(),
                Email: $("#inputEmail").val(),
                Senha: $("#inputPassword").val(),
                Sexo: $("#inputSexo option:selected").val()
               
                
            }

            $.ajax({
                type: "post",
                url: "/Account/Create",
                data: user,
                datatype: "json",
                success: function () {
                    
                    alert("Cadastro realizado com sucesso");
                    window.location.href = "/Account/Login";
             
                },
                error: function () {
                    alert('Não foi possivel realizar seu cadastro, tente novamente com outro email!');
                }
            });
        },
    });
});


$("#frm-login").click(function () {

    const parameters = {
        email: $("#emaillg").val(),
        password: $("#senhalg").val()
    }
    if (!parameters.email || !parameters.password){
    return;
}
$.ajax({
    type: "POST",
    url: "/Account/Login",
    data: $.param(parameters),
    dataType: "json",
    success: function (response) {
        console.log(response);
        if (response.code != 200) {
            alert(response.message);
        } else {
            window.location.href = "/Account/Admin";
        }
    },
    error: function () {
        alert("Login ou senha invalidos");
       
    }
});
});

