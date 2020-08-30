'use strict';

const e = React.createElement;

var accsesToken = null;

function sendRequest(action, type, method, data, afterLoad) {
    var request = new XMLHttpRequest();
    request.open(method, action);
    if (accsesToken != null)
        request.setRequestHeader('Authorization', accsesToken);
    request.setRequestHeader('Content-Type', type);
    request.addEventListener("readystatechange", () => {
        if (request.readyState === 4 && request.status === 200) {
            afterLoad(true, request.responseText);
        }
        if (request.readyState === 4 && request.status == 400) {
            afterLoad(false, request.responseText);
        }
        if (request.readyState === 4 && request.status != 400 && request.status != 200) {
            alert("Возникла ошибка при обработке запроса. Код " + request.status);
        }
    });
    request.send(data);
}

function loginRequest(e) {
    e.preventDefault();

    var form = document.forms.loginForm;
    var data = { "login": form.login.value, "password": form.password.value };

    form.submitBtn.disabled = true;

    sendRequest("../api/login", "application/json; charset=UTF-8", "POST", JSON.stringify(data), (s, r) => {
        var respons = JSON.parse(r);
        if (s) {
            if (respons.success) {
                accsesToken = respons.message;
                render(webHook);
            }
            else {
                document.getElementById("resultResponse").innerText = respons.message;
            }
        }
        else {
            document.getElementById("resultResponse").innerText = "Ошибка авторизации.";
            if (respons.hasOwnProperty('errors')) {
                if (respons.errors.hasOwnProperty('login')) {
                    document.getElementById("resultResponse").innerText += " " + respons.errors.login[0];
                }
                if (respons.errors.hasOwnProperty('password')) {
                    document.getElementById("resultResponse").innerText += " " + respons.errors.password[0];
                }
            }
        }
        form.submitBtn.disabled = true;
    });
}

function setWebHook() {
    document.getElementById("setWebHookeBtn").disabled = true;
    document.getElementById("removeWebHookeBtn").disabled = true;
    sendRequest("../api/setWebHook", "application/json; charset=UTF-8", "POST", "", (s, r) => {
        var respons = JSON.parse(r);
        document.getElementById("setWebHookResult").innerText = respons.message;
        document.getElementById("setWebHookeBtn").disabled = false;
        document.getElementById("removeWebHookeBtn").disabled = false;
    });
}

function removeWebHook() {
    document.getElementById("setWebHookeBtn").disabled = true;
    document.getElementById("removeWebHookeBtn").disabled = true;
    sendRequest("../api/removeWebHook", "application/json; charset=UTF-8", "POST", "", (s, r) => {
        var respons = JSON.parse(r);
        document.getElementById("setWebHookResult").innerText = respons.message;
        document.getElementById("setWebHookeBtn").disabled = false;
        document.getElementById("removeWebHookeBtn").disabled = false;
    });
}

function loginForm() {
    return e("div", { class: "w-100 row justify-content-center"}, e('form', {
        name: "loginForm", class: "col-md-4", onSubmit: loginRequest },
        e("div", { class: "form-group mt-5" },
            e("label", { for: "loginForm_loginField" }, "Логин"),
            e("input", { type: "text", pattern: "^\\w+$", name: "login", class: "form-control", id: "loginForm_loginField" }, null),
        ),
        e("div", { class: "form-group" },
            e("label", { for: "loginForm_passwordField" }, "Пароль"),
            e("input", { type: "password", pattern: "^[\\w\\d!]+$", name: "password", class: "form-control", id: "loginForm_passwordField" }, null),
        ),
        e("span", { class: "row mt-5 text-center justify-content-center", id: "resultResponse"}, ""),
        e("input", { type: "submit", name:"submitBtn", value: "Войти", class: "btn btn-primary mt-5" }, null),
    ));
}

function webHook() {
    return e("div", { class: "text-center mt-5 w-100" },
        e("div", { class: "row" }, e("div", { class: "col-md-6" }, e("input", { type: "button", id:"setWebHookeBtn", value: "Включить", class: "btn btn-primary", onClick: setWebHook }, null)),
                                   e("div", { class: "col-md-6" }, e("input", { type: "button", id:"removeWebHookeBtn", value: "Отключить", class: "btn btn-primary", onClick: removeWebHook }, null))),
        e("span", { class: "row mt-5 text-center", id: "setWebHookResult" }, ""));
}

function desctiption() {
    return e("div", { class: "col mt-5" },
        e("h2", {}, "Бот для Viber"),
        e("p", {}, "Бот реализует часть возможностей Viber Bot API."),
        e("p", {}, "Для установки WebHook войдите, затем перейдите на вкладку WebHooke и нажмите кнопку Включить."),
        e("p", {}, "После успешной активации WebHook бот сможет принимать сообщения от пользователей Viber."),
    );
}

function needLogin() {
    return e("div", { class: "col mt-5" },
        e("p", {}, "Для активации WebHook необходимо войти."),
    );
}

function wasLogin() {
    return e("div", { class: "col mt-5" },
        e("p", {}, "Вы уже вошли."),
    );
}


function render(content) {
    ReactDOM.render(
        e(content),
        document.getElementById('root')
    );
}
