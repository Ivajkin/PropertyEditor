﻿
$(document).ready(function () {

    var errorMessages4Status = {
        add_success: "Property successfully added",
        add_error: "Wrong property name",
        edit_success: "Property successfully edited",
        edit_error: "Error during property edit",
        delete_success: "Property successfully deleted",
        ready: ""
    };

    function getURLParameter(name) {
        return decodeURIComponent((new RegExp('[?|&]' + name + '=' + '([^&;]+?)(&|#|;|$)').exec(location.search) || [, ""])[1].replace(/\+/g, '%20')) || null;
    }

    // --------------------------------------------------------+
    // Статус текущего действия.
    function showStatus(status) {
        $("#message-box")
                .empty()
                .append(errorMessages4Status[status])
                .fadeIn("fast")
                .fadeOut(4000);
    }
    var status = getURLParameter("status");
    showStatus(status);

    // --------------------------------------------------------+
    // Удаление параметра.
    $(".delete-button").click(function () {
        var row = $(this).parent().parent();
        var propertyName = row.find('.hidden-property-name').text();


        // Удаляем DOM элемент
        row.remove();

        // Посылаем запрос на удаление объекта из базы данных.
        $.post('/PropertyEditor/Delete',
                { Name: propertyName },
                function (status) {
                    showStatus(status);
                });
    });

    // --------------------------------------------------------+
    // Добавление.
    $(".add-button").click(function () {
        setAddDialogVisibility(true);
    });

    // --------------------------------------------+
    // Форма добавления параметров.
    $("#AddForm").validate({
        focusInvalid: false,
        focusCleanup: true,
        rules: {
            "Name-Add": {
                required: true,
                minlength: 2,
                maxlength: 17
            },
            "Value-Add": {
                required: true,
                minlength: 2,
                maxlength: 17
            }
        },
        messages: {
            "Name-Add": {
                required: "Укажите название параметра!",
                minlength: "Не менее 2 символов",
                maxlength: "Не более 17 символов"
            },
            "Value-Add": {
                required: "Укажите значение параметра!",
                minlength: "Не менее 2 символов",
                maxlength: "Не более 17 символов"
            }
        }
    });

    /*$("#AddFormSumbitButton").click(function () {
    var Name = $("#Name").value(),
    Type = $("#Type").value(),
    Value = $("#Value").value();
    // Посылаем запрос на создание объекта в базе данных.
    $.post('/PropertyEditor/Add',
    {
    Name: Name,
    Type: Type,
    Value: Value
    },
    function (status) {
    setAddDialogVisibility(false);
    showStatus(status);
    });
    });*/
    function setAddDialogVisibility(isVisible) {
        if (isVisible) {
            $("#add-dialog-container").show();
        } else {
            $(".dialog-container").hide();
        }
    }
    setAddDialogVisibility(false);
    // Скрываем диалог при нажатии за его пределы.
    $(".dialog-container").click(function (e) {
        if (this == e.target) {
            $(".dialog-container").hide();
        }
    });
    // --------------------------------------------------------+
    // Изменение.

    function saveProperty(property, callback) {
        $.post("/PropertyEditor/Edit",
                property,
                function (status) {
                    showStatus(status);
                    callback(status == "edit_success");
                });
    }

    function setEdit(element, enable) {
        var parent = $(element).parent();
        var input = parent.find("input.property-value"),
            div = parent.find("div.property-value");
        if (enable) {
            $("input.property-value").hide();
            $("div.property-value").show();
            input.show();
            div.hide();
            $("div.property-value").click(inputEvents.edit);
            $(element).unbind('click');
        } else {
            input.hide();
            div.show();
            $("div.property-value").click(inputEvents.edit);
        }
    }
    var inputEvents = {
        edit: function () {
            setEdit(this, true);
        },
        save: function () {
            setEdit(this, false);

            var parent = $(this).parent().parent();
            var input = parent.find("input.property-value");
            var nameDOM = parent.find(".hidden-property-name");
            var typeDOM = parent.find(".hidden-property-type");
            var textFieldDOM = parent.find("div.property-value");

            // Меняем видимое значение и подготавливаем функции для отката, если ответ от базы будет отрицательный
            var oldValue = textFieldDOM.text();
            textFieldDOM.tearDown = function (oldValue) {
                this.text(oldValue);
            } .bind(textFieldDOM, oldValue);
            input.tearDown = textFieldDOM.tearDown.bind(input);
            var text = input.attr("value");
            if (typeDOM.text() == 1) { text = "\"" + text + "\""; }
            textFieldDOM.text(text);

            // Сам процесс сохранения
            var property = {
                name: nameDOM.text(),
                type: typeDOM.text(),
                value: input.attr("value")
            };
            saveProperty(property, function (textField, input, saved) {
                if (!saved) {
                    textField.tearDown();
                    input.tearDown();
                }
            } .bind(this, textFieldDOM, input));
        }
    };
    $("div.property-value").click(inputEvents.edit);
    $("input.property-value").change(inputEvents.save);

    // Скрываем поле ввода.
    $("input.property-value").hide();
});